Imports Production_PPT
Imports Production_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports System.Math
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Drawing.Printing

Public Class ProductionCPOReportFrm

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If cbMonth.SelectedValue Is Nothing Or cbYear.SelectedValue Is Nothing Then
            If GlobalPPT.strLang <> "en" Then
                MessageBox.Show("Silahkan Pilih Bulan dan Tahun")
            Else
                MessageBox.Show("Please Choose Month and Year")
            End If

            Exit Sub

        End If
        'ProductionKCPReport()
        ProductionRecordCPO()
    End Sub

    Private Sub ProductionCPOReportFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ProductionKCPReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetInterface()
        If GlobalPPT.strLang <> "en" Then
            ' btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnReport.Text = "Lihat Laporan"
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GetInterface()

        Dim ds As New DataSet
        Dim objProductionKCPReportPPT As New ProductionKCPReportPPT
        Dim objProductionKCPReportBOL As New ProductionKCPReportBOL
        ds = objProductionKCPReportBOL.GetInterfaceYear(objProductionKCPReportPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            cbYear.DataSource = ds.Tables(0)
            cbYear.DisplayMember = "AYear"
            cbYear.ValueMember = "AYear"
        End If


        Dim Months As New ArrayList

        'add month structure entries to the arraylist
        With Months
            .Add("JANUARY")
            .Add("FEBRUARY")
            .Add("MARCH")
            .Add("APRIL")
            .Add("MAY")
            .Add("JUNE")
            .Add("JULY")
            .Add("AUGUST")
            .Add("SEPTEMBER")
            .Add("OCTOBER")
            .Add("NOVEMBER")
            .Add("DECEMBER")
        End With

        cbMonth.DataSource = Months

        'If cbYear.SelectedValue = Date.Now.Year Then
        '    cbYear.SelectedValue = Date.Now.Year
        'Else
        '    cbYear.SelectedIndex = 0
        'End If
        cbYear.SelectedValue = Date.Now.Year

        Select Case Date.Now.Month
            Case 1
                cbMonth.SelectedIndex = 0
            Case 2
                cbMonth.SelectedIndex = 1
            Case 3
                cbMonth.SelectedIndex = 2
            Case 4
                cbMonth.SelectedIndex = 3
            Case 5
                cbMonth.SelectedIndex = 4
            Case 6
                cbMonth.SelectedIndex = 5
            Case 7
                cbMonth.SelectedIndex = 6
            Case 8
                cbMonth.SelectedIndex = 7
            Case 9
                cbMonth.SelectedIndex = 8
            Case 10
                cbMonth.SelectedIndex = 9
            Case 11
                cbMonth.SelectedIndex = 10
            Case 12
                cbMonth.SelectedIndex = 11
        End Select

    End Sub

    Private Sub ProductionRecordCPO()
        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty

        Dim strProductionRptName As String = String.Empty
        'Dim DtotalShifthrs1, DtotalShifthrs2, DtotalShifthrs3, DtotalOperationhrs, DtotalProdHrs, DtotalBreakDownHrs As Decimal
        'Dim ltotalShifthrs1, ltotalShifthrs2, ltotalShifthrs3, ltotalOperationhrs, ltotalProdHrs, ltotalBreakDownHrs As Decimal


        xlApp = New Excel.Application

        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\ProductionRecord(CPO).xls")

        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Production_Record_CPO_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Production_Record_CPO_Template.xls")
        Else
            MsgBox("Production record cpo report template missing.Please contact system administrator.")
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

        'Dim FYear, period As String
        Dim objCommonBOl As New GlobalBOL

        'period = cbMonth.SelectedIndex + 1 'ds.Tables(0).Rows(0).Item("Period").ToString()
        'FYear = cbYear.SelectedValue.ToString()

        ' SelectedMonth = objCommonBOl.PMonthName(period, FYear, GlobalPPT.strLang)

        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(cbMonth.SelectedIndex + 1, cbYear.Text, GlobalPPT.strLang)
        strProductionRptName = "Production Record CPO " & lTextmonth

        sheet.Cells(5, 1) = "Estate/Mill : " & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1)
        sheet.Cells(5, 9) = "Date : " & Format(Date.Today, "dd/MM/yyyy")
        'sheet.Cells(5, 9) = "Page : 1 of 1"
        'sheet.Cells(1, 9) = "From: " + Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
        'sheet.Cells(1, 11) = "To: " + Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        sheet.Cells(8, 1) = "PRODUCTION RECORD CPO " & lTextmonth

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
        cmd.CommandText = "Production.CPOProductionRecordReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ReportMonth", cbMonth.SelectedIndex + 1)
        cmd.Parameters.AddWithValue("@ReportYear", cbYear.SelectedValue)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "ProductionRecordCPOReport")



        If ds.Tables(0) IsNot Nothing Then

            If ds.Tables(0).Rows.Count = 0 Then

                sheet.Protect("RANNBSP@2010")
                Dim StrPath As String = "" & sDirName & "\BSP Production Reports\Production_Record_CPO_" & strProductionRptName & ".xls"
                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If

                xlApp.Visible = True
                Cursor = Cursors.Arrow
                Exit Sub
            End If

            If ds.Tables(0).Rows.Count > 0 Then

                Dim liRowCount As Integer = 14
                Dim liDataCount As Integer
                ' Dim ldPreviousBalancedFFB, ldEstimateBalancedFFB, ldLastThrouput As Decimal
                Dim ldFFBReceived, ldFFBProcessed, ldFFBBalanced, ldOil, ldFFA, ldKernal, ldOER, ldKER, ldThroughPut As Decimal
                Dim liOPHrs As String = "00:00"


                ' For Each dr As DataRow In ds.Tables(0).Rows

                Dim lTotalRecord As Integer
                lTotalRecord = ds.Tables(0).Rows.Count

                While (lTotalRecord > 0)
                    For i = 1 To 11
                        With sheet
                            .Cells(liRowCount, i).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(liRowCount, i).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(liRowCount, i).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(liRowCount, i).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        End With
                    Next i

                    With sheet
                        .Cells(liRowCount, 1) = ds.Tables(0).Rows(liDataCount).Item("ProductionLogDate")
                        .Cells(liRowCount, 2) = ds.Tables(0).Rows(liDataCount).Item("FFBReceived")
                        ldFFBReceived = ldFFBReceived + ds.Tables(0).Rows(liDataCount).Item("FFBReceived")
                      
                        .Cells(liRowCount, 3) = ds.Tables(0).Rows(liDataCount).Item("FFBProcessedACT")
                        ldFFBProcessed = ldFFBProcessed + ds.Tables(0).Rows(liDataCount).Item("FFBProcessedACT")
          
                        .Cells(liRowCount, 4) = ds.Tables(0).Rows(liDataCount).Item("BalanceFFBBFQty")
                        ldFFBBalanced = ldFFBBalanced + ds.Tables(0).Rows(liDataCount).Item("BalanceFFBBFQty")
                       
                        .Cells(liRowCount, 5) = ds.Tables(0).Rows(liDataCount).Item("Oil")
                        ldOil = ldOil + ds.Tables(0).Rows(liDataCount).Item("Oil")
                       
                        .Cells(liRowCount, 6) = ds.Tables(0).Rows(liDataCount).Item("FFAP")
                        ldFFA = ldFFA + ds.Tables(0).Rows(liDataCount).Item("FFAP")
           
                        .Cells(liRowCount, 7) = ds.Tables(0).Rows(liDataCount).Item("Kernel")
                        ldKernal = ldKernal + ds.Tables(0).Rows(liDataCount).Item("Kernel")
          
                        .Cells(liRowCount, 8) = ds.Tables(0).Rows(liDataCount).Item("OER")
                        ldOER = ldOER + ds.Tables(0).Rows(liDataCount).Item("OER")
           
                        .Cells(liRowCount, 9) = ds.Tables(0).Rows(liDataCount).Item("KER")
                        ldKER = ldKER + ds.Tables(0).Rows(liDataCount).Item("KER")
                        .Cells(liRowCount, 10) = ds.Tables(0).Rows(liDataCount).Item("EffectiveProcessingHours").ToString
                        liOPHrs = AddHours(ds.Tables(0).Rows(liDataCount).Item("EffectiveProcessingHours").ToString, liOPHrs)
                        .Cells(liRowCount, 11) = ds.Tables(0).Rows(liDataCount).Item("Throughput")
                        ldThroughPut = ldThroughPut + ds.Tables(0).Rows(liDataCount).Item("Throughput")


                    End With
                    liDataCount = liDataCount + 1
                    liRowCount = liRowCount + 1
                    lTotalRecord = lTotalRecord - 1
                End While
                '   Next

                For i = 1 To 11
                    With sheet
                        .Cells((14 + ds.Tables(0).Rows.Count), i).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells((14 + ds.Tables(0).Rows.Count), i).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells((14 + ds.Tables(0).Rows.Count), i).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells((14 + ds.Tables(0).Rows.Count), i).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    End With
                Next i
                lTotalRecord = ds.Tables(0).Rows.Count

                sheet.Cells((14 + ds.Tables(0).Rows.Count), 1) = "Total"
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 2) = ldFFBReceived
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 3) = ldFFBProcessed
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 4) = ldFFBBalanced
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 5) = ldOil
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 6) = ldFFA
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 7) = ldKernal
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 8) = ldOER / lTotalRecord
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 9) = ldKER / lTotalRecord
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 10) = liOPHrs '(ltsOPHrs.TotalHours).ToString().PadLeft(2, "0") + ":" + ltsOPHrs.Minutes.ToString().PadLeft(2, "0").Substring(0, 2)
                sheet.Cells((14 + ds.Tables(0).Rows.Count), 11) = ldThroughPut / lTotalRecord


                sheet.Protect("RANNBSP@2010")
                Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strProductionRptName & ".xls"

                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If

                xlApp.Visible = True

            End If

        End If



        Cursor = Cursors.Arrow

    End Sub

    Private Function AddHours(ByVal EffProcessHours As String, ByVal TotalEffProcessHours As String)

        Dim strArr(), strArr1() As String
        Dim Str, Str1 As String
        Str = EffProcessHours
        strArr = Str.Split(":")
        Str1 = TotalEffProcessHours
        strArr1 = Str1.Split(":")

        Dim Lhrs, lmin As Integer

        Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

        lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

        If lmin >= 60 Then
            lmin = lmin - 60
            Lhrs = Lhrs + 1
        End If
        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs)
        Else
            Strhrs2 = Lhrs
        End If

        If lmin < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin)
        Else
            StrMin2 = lmin
        End If

        TotalEffProcessHours = Strhrs2 + ":" + StrMin2
        Return TotalEffProcessHours

    End Function

End Class