Imports System.Windows.Forms
Imports Common_PPT
Imports Common_BOL
Imports Common_DAL
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Data.SqlClient
Imports System.IO
Imports Production_BOL
Imports System.Globalization


Public Class MillworkinghrscpoReportInterfacefrm

    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNINReportInterfacefrm))

    Private Sub MillworkinghrscpoReportInterfacefrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

  
    Private Sub MillworkinghrscpoReportInterfacefrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        cmbCPOPKO.SelectedIndex = 0
        If GlobalPPT.strLang <> "en" Then
            ' btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnViewReport.Text = "Lihat Laporan"
        End If

    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MillworkinghrscpoReportInterfacefrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText")
            btnViewReport.Text = rm.GetString("btnviewReport.Text")
 

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MillworkinghrscpoReportInterfacefrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewReport.Click

        Cursor = Cursors.WaitCursor
        ProductionMillWorkingHours(dtpDate.Value)

    End Sub
    Private Sub ProductionMillWorkingHours(ByVal dtValue As Date)

        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim strcpopko As String = String.Empty

        Dim strMonthlyProdRptName As String = String.Empty
        xlApp = New Excel.Application

        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_hours_Report.xlsx")

        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Mill_Working_Hours_Report_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_Hours_Report_Template.xls")
        Else
            MsgBox("Mill working hours report template missing.Please contact system administrator.")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("Report directory not found", "BSP")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Production Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If


        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


        'strDSN = "" & ConfigurationManager.AppSettings.Item("oDataSource").ToString & ""
        'strServerUserName = "" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
        'strServerPassword = "" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""
        'StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()

        strcpopko = cmbCPOPKO.Text
        cmd.Connection = con
        cmd.CommandText = "Production.MillWorkingHoursReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd.Parameters.AddWithValue("@ProductionLogDate", dtValue)
        cmd.Parameters.AddWithValue("@CPOPKO", strcpopko)

        'Dim tblAdt As New SqlDataAdapter
        'Dim ds As New DataSet
        'tblAdt.SelectCommand = cmd
        'tblAdt.Fill(ds, "MillWorkingHoursReport1")

        Dim tblAdt1 As New SqlDataAdapter
        Dim ds1 As New DataSet
        tblAdt1.SelectCommand = cmd
        tblAdt1.Fill(ds1, "MillWorkinHoursReport")


        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty


        lTextmonth = Format(dtpDate.Value, "dd/MM/yyyy")
        lTextmonth = lTextmonth.Replace("/", "-")
        sheet.Cells(1, 13) = Format(Date.Today, "dd/MM/yyyy")
        sheet.Cells(3, 10) = ""
        sheet.Cells(3, 12) = ""

        Dim strArray As String()
        Dim lestate As String
        strArray = GlobalPPT.strEstateName.Split("-")
        lestate = strArray(1)
        sheet.Cells(2, 1) = "Estate/Mill : " & lestate & " "

        strMonthlyProdRptName = "MILL WORKING HOURS REPORT " & strcpopko & " " & lTextmonth & ""
        sheet.Cells(1, 6) = "MILL WORKING HOURS REPORT - " & strcpopko & " "
        sheet.Cells(2, 6) = "DATE : " & Format(dtpDate.Value, "dd/MM/yyyy") & ""
        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"


        If ds1.Tables(0) IsNot Nothing And ds1.Tables(0).Rows.Count <> 0 Then


            Dim TotalCount As Integer = 0

            TotalCount = ds1.Tables(0).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 9
            Dim LrowNo As Integer = 0

            While (TotalCount > 0)

                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1) = ds1.Tables(0).Rows(LrowNo).Item("ProductionLogDate").ToString
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                Dim lStartTime, lStoptime As DateTime

                If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime1") Is DBNull.Value Then

                    lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime1")
                    lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime1")


                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
                            '   DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
                            ' DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 2) = strTotalhrs + ":00"
                        ' DtotalShifthrs1 = strTotalhrs + ":00"
                    End If
                End If


                If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime2") Is DBNull.Value Then
                    lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime2")
                    lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime2")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
                            ' DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
                            '  DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 3) = strTotalhrs + ":00"
                        ' DtotalShifthrs2 = strTotalhrs + ":00"
                    End If
                End If
                If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime3") Is DBNull.Value Then
                    lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime3")
                    lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime3")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
                            '  DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
                            '  DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 4) = strTotalhrs + ":00"
                        ' DtotalShifthrs3 = strTotalhrs + ":00"
                    End If
                End If

                Dim lTotalHours As String = String.Empty
                lTotalHours = ds1.Tables(0).Rows(LrowNo).Item("TotalHours")
                'If lTotalHours < 10 Then
                '    lTotalHours = "0" + lTotalHours
                'End If
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5) = lTotalHours
                '  DtotalOperationhrs = lTotalHours
                Dim lProductionHours As String = String.Empty
                lProductionHours = ds1.Tables(0).Rows(LrowNo).Item("ProductionHours").ToString
                'If lProductionHours < 10 Then
                '    lProductionHours = "0" + lProductionHours
                'End If
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6) = lProductionHours
                '  DtotalProdHrs = lProductionHours
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                'sheet.Cells(lRowCount, 7) = ds1.Tables(0).Rows(LrowNo).Item("TotalHours") - ds1.Tables(0).Rows(LrowNo).Item("ProductionHours")

                Dim lBKDownHours As String = ""
                If ds1.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString <> "" Then
                    lBKDownHours = ds1.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString
                    'If lBKDownHours < 10 Then
                    '    lBKDownHours = "0" + lBKDownHours
                    'End If
                    sheet.Cells(lRowCount, 8) = lBKDownHours
                    '  DtotalBreakDownHrs = lBKDownHours
                End If

                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13) = ds1.Tables(0).Rows(LrowNo).Item("Remarks").ToString.Trim()

                TotalCount = TotalCount - 1
                lRowCount = lRowCount + 1
                LrowNo = LrowNo + 1


            End While




        End If

        '    Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
        sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        '  xlApp.Workbooks.Open(StrPath)
        xlApp.Visible = True

        Cursor = Cursors.Arrow
        strcpopko = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        '  End If
    End Sub
End Class