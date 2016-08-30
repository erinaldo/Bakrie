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

Public Class DailyQualityProductionRptFrm


    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Cursor = Cursors.WaitCursor

        ViewReport(dtpDate.Value)

        Cursor = Cursors.Arrow

    End Sub

    Private Sub ViewReport(ByVal dtValue As Date)


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet

        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty

        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        xlApp = New Excel.Application
        'xlApp.Cursor = Excel.XlMousePointer.xlWait
        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\DailyQualityProductionReport.xlsx")

        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Daily_Quality_Production_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Daily_Quality_Production_Template.xls")
        Else
            MsgBox("Daily quality production report template missing.Please contact system administrator.")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
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

        sheet.Cells(3, 2) = "Estate/Mill : " & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1)
        sheet.Cells(3, 5) = "Date : " & Format(Date.Now, "dd/MM/yyyy")  'from date
        'sheet.Cells(3, 9) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")  'from date
        'sheet.Cells(3, 11) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy") 'to date
        sheet.Cells(6, 2) = "DAILY QUALITY PRODUCTIONS - " & Format(dtpDate.Value, "dd/MM/yyyy") & ""

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


        cmd.Connection = con
        cmd.CommandText = "[Production].[DailyQualityProductionsReport]"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Date", Format(dtpDate.Value, "yyyy/MM/dd"))

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DailyProductionReport")

        'Try

        If ds.Tables(0) IsNot Nothing Then

            If ds.Tables(0).Rows.Count > 0 Then

                With sheet
                    'CPO Production
                    .Cells(11, 4) = Convert.ToString(ds.Tables(0).Rows(0)("CPOFFA")) & "%"
                    .Cells(12, 4) = Convert.ToString(ds.Tables(0).Rows(0)("CPOMoisture")) & "%"
                    .Cells(13, 4) = Convert.ToString(ds.Tables(0).Rows(0)("CPODirt")) & "%"
                    .Cells(11, 5) = Convert.ToString(ds.Tables(0).Rows(0)("DayCPOFFA")) & "%"
                    .Cells(12, 5) = Convert.ToString(ds.Tables(0).Rows(0)("DAYCPOMoisture")) & "%"
                    .Cells(13, 5) = Convert.ToString(ds.Tables(0).Rows(0)("DAYCPODIrt")) & "%"

                    'CPKO Production
                    .Cells(14, 4) = Convert.ToString(ds.Tables(0).Rows(0)("CPKOFFA")) & "%"
                    .Cells(15, 4) = Convert.ToString(ds.Tables(0).Rows(0)("CPKOMoisture")) & "%"
                    .Cells(16, 4) = Convert.ToString(ds.Tables(0).Rows(0)("CPKODirt")) & "%"

                    'Kernel Fresh Production
                    .Cells(17, 4) = Convert.ToString(ds.Tables(0).Rows(0)("FKMoisture")) & "%"
                    .Cells(18, 4) = Convert.ToString(ds.Tables(0).Rows(0)("FKDirt")) & "%"
                    .Cells(19, 4) = Convert.ToString(ds.Tables(0).Rows(0)("FKBrokenKernel")) & "%"
                    .Cells(20, 4) = Convert.ToString(ds.Tables(0).Rows(0)("FKNutPressCake")) & "%"

                    'Kernel After Dryer
                    .Cells(21, 4) = Convert.ToString(ds.Tables(0).Rows(0)("KAMoisture")) & "%"
                    .Cells(22, 4) = Convert.ToString(ds.Tables(0).Rows(0)("KADirt")) & "%"
                    .Cells(23, 4) = Convert.ToString(ds.Tables(0).Rows(0)("KABrokenKernel")) & "%"
                    .Cells(24, 4) = Convert.ToString(ds.Tables(0).Rows(0)("KANutPressCake")) & "%"
                    .Cells(21, 5) = Convert.ToString(ds.Tables(0).Rows(0)("DayKAMoisture")) & "%"
                    .Cells(22, 5) = Convert.ToString(ds.Tables(0).Rows(0)("DAYKADirt")) & "%"
                    .Cells(23, 5) = Convert.ToString(ds.Tables(0).Rows(0)("DAYKABrokenKernel")) & "%"


                End With
            End If
        End If


        Dim liRowCount As Integer = 31

        'CPKO Production
        Dim ldCPKOSumCurrentReading As Decimal = 0
        If ds.Tables(1) IsNot Nothing Then
            If ds.Tables(1).Rows.Count > 0 Then
                For Each dr In ds.Tables(1).Rows
                    With sheet
                        '.Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 2) = Convert.ToString(dr("TankNo"))
                        .Cells(liRowCount, 3) = Convert.ToString(dr("CurrentReading"))
                        .Cells(liRowCount, 3).numberformat = "0.000"
                        .Cells(liRowCount, 4) = Convert.ToString(dr("FFAP"))
                        .Cells(liRowCount, 5) = Convert.ToString(dr("MoistureP"))
                        .Cells(liRowCount, 5).font.bold = False
                        .Cells(liRowCount, 6) = Convert.ToString(dr("DirtP"))
                        '.Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    End With
                    liRowCount = liRowCount + 1
                    ldCPKOSumCurrentReading += Convert.ToDecimal(dr("CurrentReading"))
                Next
            Else
                With sheet
                    .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                liRowCount = liRowCount + 1
            End If
            
        End If

        'With sheet
        '    .Cells(liRowCount - 1, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        'End With

        If ds.Tables(2) IsNot Nothing Then
            'If ds.Tables(2).Rows.Count > 0 Then
            For Each dr In ds.Tables(2).Rows
                With sheet
                    .Cells(liRowCount, 2) = Convert.ToString(dr("Location")) & " :"
                    .Cells(liRowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = Convert.ToString(dr("CurrentReading"))
                    .Cells(liRowCount, 3).numberformat = "0.000"
                End With
                liRowCount = liRowCount + 1
                ldCPKOSumCurrentReading += Convert.ToDecimal(dr("CurrentReading"))
            Next
            'Else
            '    liRowCount = liRowCount + 1
            'End If
        End If
        'liRowCount = liRowCount + 1
        With sheet
            .Cells(liRowCount, 2) = "Total Stock CPKO :"
            .Cells(liRowCount, 2).font.bold = True
            .Cells(liRowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
            .Cells(liRowCount, 3) = ldCPKOSumCurrentReading
            .Cells(liRowCount, 3).font.bold = True
            .Cells(liRowCount, 3).numberformat = "0.000"
        End With

        liRowCount = liRowCount + 2

        With sheet

            .Cells(liRowCount, 2) = "CPO Production"
            .Cells(liRowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
            .Cells(liRowCount, 2).font.bold = True

            liRowCount = liRowCount + 1

            .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

            .Cells(liRowCount, 2) = "Storage Tank"
            .Cells(liRowCount, 2).font.bold = True
            .Cells(liRowCount, 3) = "TONS"
            .Cells(liRowCount, 3).font.bold = True
            .Cells(liRowCount, 4) = "FFA (%)"
            .Cells(liRowCount, 4).font.bold = True
            .Cells(liRowCount, 5) = "Moisture (%)"
            .Cells(liRowCount, 5).font.bold = True
            .Cells(liRowCount, 6) = "Dirt (%)"
            .Cells(liRowCount, 6).font.bold = True

            .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        End With

        liRowCount = liRowCount + 1

        'CPO Production
        Dim ldCPOSumCurrentReading As Decimal = 0
        If ds.Tables(3) IsNot Nothing Then
            If ds.Tables(3).Rows.Count > 0 Then
                For Each dr In ds.Tables(3).Rows
                    With sheet
                        ' .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 2) = Convert.ToString(dr("TankNo"))
                        .Cells(liRowCount, 3) = Convert.ToString(dr("CurrentReading"))
                        .Cells(liRowCount, 3).numberformat = "0.000"
                        .Cells(liRowCount, 4) = Convert.ToString(dr("FFAP"))
                        .Cells(liRowCount, 5) = Convert.ToString(dr("MoistureP"))
                        .Cells(liRowCount, 6) = Convert.ToString(dr("DirtP"))
                        ' .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    End With
                    liRowCount = liRowCount + 1
                    ldCPOSumCurrentReading += Convert.ToDecimal(dr("CurrentReading"))
                Next
            Else
                With sheet
                    .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                End With
                liRowCount = liRowCount + 1
            End If
        End If

        'With sheet
        '    .Cells(liRowCount - 1, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        '    .Cells(liRowCount - 1, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        'End With


        If ds.Tables(4) IsNot Nothing Then
            For Each dr In ds.Tables(4).Rows
                With sheet
                    .Cells(liRowCount, 2) = Convert.ToString(dr("Location")) & " :"
                    .Cells(liRowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = Convert.ToString(dr("CurrentReading"))
                    .Cells(liRowCount, 3).numberformat = "0.000"
                End With
                liRowCount = liRowCount + 1
                ldCPOSumCurrentReading += Convert.ToDecimal(dr("CurrentReading"))
            Next
        End If

        With sheet
            .Cells(liRowCount, 2) = "Total Stock CPO :"
            .Cells(liRowCount, 2).font.bold = True
            .Cells(liRowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
            .Cells(liRowCount, 3) = ldCPOSumCurrentReading
            .Cells(liRowCount, 3).numberformat = "0.000"
            .Cells(liRowCount, 3).font.bold = True
        End With

        liRowCount = liRowCount + 4

        With sheet
            .Cells(liRowCount, 2) = "Checked By"
            .Cells(liRowCount, 2).font.bold = True
            .Cells(liRowCount, 4) = "Acknowledged By"
            .Cells(liRowCount, 4).font.bold = True
            .Cells(liRowCount, 6) = "Approved By"
            .Cells(liRowCount, 6).font.bold = True
            liRowCount = liRowCount + 4
            .Cells(liRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            .Cells(liRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        End With



        Dim strProductionRptName As String
        strProductionRptName = Format(dtpDate.Value, "dd/MM/yyyy")
        strProductionRptName = strProductionRptName.Replace("/", "-")
        sheet.Protect("RANNBSP@2010")
        'Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\DailyQualityProductionReport_" & strProductionRptName & ".xls"
        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\DAILY QUALITY PRODUCTIONS " & strProductionRptName & ".xls"

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' xlApp.Workbooks.Open(StrPath)

        'xlApp.StatusBar = True
        xlApp.Visible = True

    End Sub

    Private Sub PnlSearch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlSearch.Paint

    End Sub

    Private Sub DailyQualityProductionRptFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub DailyQualityProductionRptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        dtpDate.MaxDate = dtpDate.Value

        If GlobalPPT.strLang <> "en" Then
            '  btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnViewReport.Text = "Lihat Laporan"
        End If
    End Sub
End Class