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

Public Class ProductionKCPReportFrm

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If cbMonth.SelectedValue Is Nothing Or cbYear.SelectedValue Is Nothing Then
            
            If GlobalPPT.strLang <> "en" Then
                MessageBox.Show("Silahkan Pilih Bulan dan Tahun")
            Else
                MessageBox.Show("Please Choose Month and Year")
            End If

            Exit Sub

        End If
        ProductionKCPReport()
        ProductionRecordKCP()
    End Sub

    Private Sub ProductionKCPReportFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub ProductionRecordKCP()
       
        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        Dim sheet As Excel.Worksheet
        xlApp = New Excel.Application



        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\ProductionRecordKCP_Report_Template.xls"

        If (File.Exists(TemPath)) Then

            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\Reports\Production\Excel\ProductionRecordKCP_Report_Template.xls")
        Else
            MsgBox("Production Record KCP report template missing.Please contact system administrator.")
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

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()



        cmd.Connection = con
        cmd.CommandText = "Production.rptProductionRecordKCPSelect"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'cmd.Parameters.AddWithValue("@ProductionLogDate", DateTime.Now.ToString())
        cmd.Parameters.AddWithValue("@LoginYear", cbYear.SelectedValue)
        cmd.Parameters.AddWithValue("@LoginMonth", cbMonth.SelectedIndex + 1)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "rptProductionRecordKCPSelect")
        Dim Pageno As Integer
        Pageno = 1
        If ds.Tables(0).Rows.Count > 0 Then
        Else
            MessageBox.Show("No record in Fiscal Year for Production Record KCP Report")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim objCommonBOl As New GlobalBOL
        Dim FYear, period, SelectedMonth As String
        period = ds.Tables(0).Rows(0).Item("Period").ToString()
        FYear = ds.Tables(0).Rows(0).Item("FYear").ToString()
        SelectedMonth = objCommonBOl.PMonthName(period, FYear, GlobalPPT.strLang)
        sheet.Cells(4, 10) = Date.Today
        sheet.Cells(5, 2) = "Estate/Mill :" & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1) & " "
        sheet.Cells(6, 8) = ds.Tables(0).Rows(0).Item("FromDT").ToString()
        sheet.Cells(6, 10) = ds.Tables(0).Rows(0).Item("ToDT").ToString()
        ' sheet.Cells(5, 10) = Pageno

        strMonthlyProdRptName = "PRODUCTION RECORD KCP" & " " & SelectedMonth & ""
        sheet.Cells(8, 2) = "PRODUCTION RECORD KCP" & " " & SelectedMonth & ""


        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
        If ds.Tables(1).Rows.Count = 0 Then
            sheet.Protect("RANNBSP@2010")

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


        If ds IsNot Nothing Then
            Dim CountSupplier As Integer = 0
            CountSupplier = ds.Tables(1).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 14
            Dim Row As Integer = 0
            sheet.Cells(8, 2) = "PRODUCTION RECORD KCP" & " " & SelectedMonth & ""
            Dim lcount As Integer = 0

            If CountSupplier > 0 Then
                While (CountSupplier > 0)

                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2) = ds.Tables(1).Rows(lcount).Item("DateCol").ToString()

                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3) = ds.Tables(1).Rows(lcount).Item("KernelReceived").ToString()

                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4) = ds.Tables(1).Rows(lcount).Item("KernelProcessed").ToString()


                    If (ds.Tables(1).Rows(lcount).Item("KernelReceived").ToString() = String.Empty) Then
                        sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    Else
                        sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(lRowCount, 5) = (ds.Tables(1).Rows(lcount).Item("KernelReceived")) - (ds.Tables(1).Rows(lcount).Item("KernelProcessed"))
                    End If

                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6) = ds.Tables(1).Rows(lcount).Item("PRODUCTIONTONPKO").ToString()


                    sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 7) = ds.Tables(1).Rows(lcount).Item("FFA").ToString()


                    sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 8) = ds.Tables(1).Rows(lcount).Item("ExtractionRate").ToString()

                    sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 9) = ds.Tables(1).Rows(lcount).Item("EffectiveHrs").ToString()

                    sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 10) = ds.Tables(1).Rows(lcount).Item("Throughput").ToString()

                    sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 11) = ds.Tables(1).Rows(lcount).Item("Remarks").ToString()

                    lRowCount = lRowCount + 1
                    CountSupplier = CountSupplier - 1
                    Row = Row + 1
                    lcount = lcount + 1
                End While
                sheet.Visible = True
                xlApp.Visible = True
                sheet.Protect("RANNBSP@2010")

                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If
            End If
        End If

        Cursor = Cursors.Arrow
    End Sub

    Private Sub ProductionKCPReport()


        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        Dim sheet As Excel.Worksheet
        xlApp = New Excel.Application




        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\ProductionKCP_Report_Template.xls"

        If (File.Exists(TemPath)) Then

            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\Reports\Production\Excel\ProductionKCP_Report_Template.xls")
        Else
            MsgBox("Production KCP Report template missing.Please contact system administrator.")
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
        cmd.CommandText = "Production.rptProductionKCPSelect"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ' cmd.Parameters.AddWithValue("@ProductionLogDate", DateTime.Now.ToString())
        cmd.Parameters.AddWithValue("@LoginYear", cbYear.SelectedValue)
        cmd.Parameters.AddWithValue("@LoginMonth", cbMonth.SelectedIndex + 1)


        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd

        tblAdt.Fill(ds, "rptProductionKCPSelect")
        If ds.Tables(0).Rows.Count > 0 Then
        Else
            MessageBox.Show("No record in Fiscal Year for Production KCP Report")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        'Try
        If ds IsNot Nothing Then
            Dim lRowCount As Integer
            lRowCount = 13
            Dim Pageno As Integer
            Pageno = 1

            Dim objCommonBOl As New GlobalBOL
            Dim FYear, period, SelectedMonth As String

            period = ds.Tables(0).Rows(0).Item("Period").ToString()
            FYear = ds.Tables(0).Rows(0).Item("FYear").ToString()

            SelectedMonth = objCommonBOl.PMonthName(period, FYear, GlobalPPT.strLang)

            sheet.Cells(1, 8) = Date.Today
            sheet.Cells(2, 1) = "Estate/Mill :" & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1) & " "
            sheet.Cells(3, 6) = ds.Tables(0).Rows(0).Item("FromDT").ToString()
            sheet.Cells(3, 8) = ds.Tables(0).Rows(0).Item("ToDT").ToString()
            ' sheet.Cells(2, 8) = Pageno

            strMonthlyProdRptName = "PRODUCTION KCP REPORT" & " " & SelectedMonth & ""
            sheet.Cells(5, 1) = "PRODUCTION KCP REPORT" & " " & SelectedMonth & ""

            xlApp.Visible = True
            Cursor = Cursors.Arrow


            If ds.Tables(1).Rows.Count > 0 Then
                sheet.Cells(13, 2) = ds.Tables(1).Rows(0).Item("KernelProcessedACTMTD")
            Else
                sheet.Cells(13, 2) = "0.00"
            End If

            If ds.Tables(8).Rows.Count > 0 Then
                sheet.Cells(13, 3) = ds.Tables(8).Rows(0).Item("KernelProcessedACTYT")
            Else
                sheet.Cells(13, 3) = "0.00"
            End If


            If ds.Tables(1).Rows.Count > 0 And ds.Tables(8).Rows.Count > 0 Then
                sheet.Cells(13, 4) = (ds.Tables(8).Rows(0).Item("KernelProcessedACTYT") - ds.Tables(1).Rows(0).Item("KernelProcessedACTMTD"))
            End If


            If ds.Tables(15).Rows.Count > 0 Then
                sheet.Cells(13, 6) = ds.Tables(15).Rows(0).Item("KernelProcessedACTYT")
            Else
                sheet.Cells(13, 6) = "0.00"
            End If

            If ds.Tables(22).Rows.Count > 0 Then
                sheet.Cells(14, 5) = ds.Tables(22).Rows(0).Item("Bud")
            End If


            If ds.Tables(1).Rows.Count > 0 And ds.Tables(6).Rows.Count > 0 Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim Minstr As String
                Dim str As String
                Dim strArr() As String
                Dim Effect As Decimal
                str = ds.Tables(6).Rows(0).Item("EPHMTD").ToString()
                strArr = str.Split(":")
                Hrs = strArr(0)
                If strArr(1) <> "00" Then
                    Min = Math.Round(strArr(1) / 60, 2) * 100
                End If
                Minstr = "." + Convert.ToString(Min)
                Effect = Convert.ToString(Hrs) + Minstr
                Try
                    sheet.Cells(14, 2) = (ds.Tables(1).Rows(0).Item("KernelProcessedACTMTD")) / Effect
                Catch ex As DivideByZeroException
                    sheet.Cells(14, 2) = "0.00"
                End Try
            Else
                sheet.Cells(14, 2) = "0.00"
            End If


            If ds.Tables(8).Rows.Count > 0 And ds.Tables(13).Rows.Count > 0 Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim Minstr As String
                Dim str As String
                Dim strArr() As String
                Dim Effect As Decimal
                str = ds.Tables(13).Rows(0).Item("EPHYTD").ToString()
                strArr = str.Split(":")
                Hrs = strArr(0)
                If strArr(1) <> "00" Then
                    Min = Math.Round(strArr(1) / 60, 2) * 100
                End If
                Minstr = "." + Convert.ToString(Min)
                Effect = Convert.ToString(Hrs) + Minstr
                Try
                    sheet.Cells(14, 3) = (ds.Tables(8).Rows(0).Item("KernelProcessedACTYT")) / Effect
                Catch ex As DivideByZeroException
                    sheet.Cells(14, 3) = "0.00"
                End Try
            Else
                sheet.Cells(14, 3) = "0.00"
            End If


            If ds.Tables(15).Rows.Count > 0 And ds.Tables(20).Rows.Count > 0 Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim Minstr As String
                Dim str As String
                Dim strArr() As String
                Dim Effect As Decimal
                str = ds.Tables(20).Rows(0).Item("EPHLYTD")
                strArr = str.Split(":")
                Hrs = strArr(0)
                If strArr(1) <> "00" Then
                    Min = Math.Round(strArr(1) / 60, 2) * 100
                End If
                Minstr = "." + Convert.ToString(Min)
                Effect = Convert.ToString(Hrs) + Minstr
                Try
                    sheet.Cells(14, 6) = (ds.Tables(15).Rows(0).Item("KernelProcessedACTYT")) / Effect
                Catch ex As DivideByZeroException
                    sheet.Cells(14, 6) = "0.00"
                End Try
            Else
                sheet.Cells(14, 6) = "0.00"
            End If

            If ds.Tables(3).Rows.Count > 0 Then
                ' sheet.Cells(14, 2) = ds.Tables(3).Rows(0).Item("THROM")
                sheet.Cells(15, 2) = ds.Tables(3).Rows(0).Item("Mill")
                sheet.Cells(16, 2) = ds.Tables(3).Rows(0).Item("NOOFSHIFTS")
                ' sheet.Cells(19, 2) = ds.Tables(3).Rows(0).Item("OERMTD")
            Else
                sheet.Cells(15, 2) = "0"
                sheet.Cells(16, 2) = "0"
                ' sheet.Cells(19, 2) = "0"
            End If

            If ds.Tables(10).Rows.Count > 0 Then
                'sheet.Cells(14, 3) = ds.Tables(10).Rows(0).Item("THROY")
                sheet.Cells(15, 3) = ds.Tables(10).Rows(0).Item("Mill")
                sheet.Cells(16, 3) = ds.Tables(10).Rows(0).Item("NOOFSHIFTS")
                'sheet.Cells(19, 3) = ds.Tables(10).Rows(0).Item("OERYTD")
            Else
                sheet.Cells(15, 3) = "0"
                sheet.Cells(16, 3) = "0"
                ' sheet.Cells(19, 3) = "0"
            End If

            If ds.Tables(17).Rows.Count > 0 Then
                'sheet.Cells(14, 6) = ds.Tables(17).Rows(0).Item("THROYTD")
                sheet.Cells(15, 6) = ds.Tables(17).Rows(0).Item("Mill")
                sheet.Cells(16, 6) = ds.Tables(17).Rows(0).Item("NOOFSHIFTS")
                ' sheet.Cells(19, 6) = ds.Tables(17).Rows(0).Item("OERLYTD")
            Else
                sheet.Cells(15, 6) = "0"
                sheet.Cells(16, 6) = "0"
                ' sheet.Cells(19, 6) = "0"
            End If


            If ds.Tables(3).Rows.Count > 0 And ds.Tables(10).Rows.Count > 0 Then
                'sheet.Cells(14, 4) = (ds.Tables(10).Rows(0).Item("THROY") - ds.Tables(3).Rows(0).Item("THROM"))
                sheet.Cells(15, 4) = (ds.Tables(10).Rows(0).Item("Mill") - ds.Tables(3).Rows(0).Item("Mill"))
                sheet.Cells(16, 4) = (ds.Tables(10).Rows(0).Item("NOOFSHIFTS") - ds.Tables(3).Rows(0).Item("NOOFSHIFTS"))
                ' sheet.Cells(19, 4) = (ds.Tables(10).Rows(0).Item("OERYTD") - ds.Tables(3).Rows(0).Item("OERMTD"))
            End If

            If ds.Tables(2).Rows.Count > 0 Then
                sheet.Cells(18, 2) = ds.Tables(2).Rows(0).Item("QtyMonthToDate")
            Else
                sheet.Cells(18, 2) = "0.00"
            End If
            If ds.Tables(9).Rows.Count > 0 Then
                sheet.Cells(18, 3) = ds.Tables(9).Rows(0).Item("QtyYearToDate")
            Else
                sheet.Cells(18, 3) = "0.00"
            End If

            If ds.Tables(2).Rows.Count > 0 And ds.Tables(9).Rows.Count > 0 Then
                sheet.Cells(18, 4) = (ds.Tables(9).Rows(0).Item("QtyYearToDate") - ds.Tables(2).Rows(0).Item("QtyMonthToDate"))
            End If


            If ds.Tables(16).Rows.Count > 0 Then
                sheet.Cells(18, 6) = ds.Tables(16).Rows(0).Item("QtyYearToDate")
            Else
                sheet.Cells(18, 6) = "0.00"
            End If


            If ds.Tables(2).Rows.Count > 0 And ds.Tables(1).Rows.Count > 0 Then
                'Try
                If ds.Tables(2).Rows(0).Item("QtyMonthToDate") <> 0 And ds.Tables(1).Rows(0).Item("KernelProcessedACTMTD") <> 0 Then
                    sheet.Cells(19, 2) = (ds.Tables(2).Rows(0).Item("QtyMonthToDate")) / (ds.Tables(1).Rows(0).Item("KernelProcessedACTMTD"))
                Else
                    sheet.Cells(19, 2) = "0.00"
                End If

                'Catch ex As DivideByZeroException

                'End Try
                'Else
                '    sheet.Cells(19, 2) = "0.00"
            End If

            If ds.Tables(9).Rows.Count > 0 And ds.Tables(8).Rows.Count > 0 Then
                Try
                    sheet.Cells(19, 3) = (ds.Tables(9).Rows(0).Item("QtyYearToDate")) / (ds.Tables(8).Rows(0).Item("KernelProcessedACTYT"))
                Catch ex As DivideByZeroException
                    sheet.Cells(19, 3) = "0.00"
                End Try
            Else
                sheet.Cells(19, 3) = "0.00"
            End If

            If ds.Tables(16).Rows.Count > 0 And ds.Tables(15).Rows.Count > 0 Then
                Try
                    sheet.Cells(19, 6) = (ds.Tables(16).Rows(0).Item("QtyYearToDate")) / (ds.Tables(15).Rows(0).Item("KernelProcessedACTYT"))
                Catch ex As DivideByZeroException
                    sheet.Cells(19, 6) = "0.00"
                End Try
            Else
                sheet.Cells(19, 6) = "0.00"
            End If

            If ds.Tables(6).Rows.Count > 0 Then
                sheet.Cells(20, 2) = ds.Tables(6).Rows(0).Item("EPHMTD")
            Else
                sheet.Cells(20, 2) = "0:00"
            End If

            If ds.Tables(13).Rows.Count > 0 Then
                sheet.Cells(20, 3) = ds.Tables(13).Rows(0).Item("EPHYTD")
            Else
                sheet.Cells(20, 3) = "0:00"
            End If


            If ds.Tables(20).Rows.Count > 0 Then
                sheet.Cells(20, 6) = ds.Tables(20).Rows(0).Item("EPHLYTD")
            Else
                sheet.Cells(20, 6) = "0:00"
            End If




            If ds.Tables(2).Rows.Count > 0 And ds.Tables(6).Rows.Count > 0 Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim Minstr As String
                Dim str As String
                Dim strArr() As String
                Dim Effect As Decimal
                str = ds.Tables(6).Rows(0).Item("EPHMTD").ToString()
                strArr = str.Split(":")
                Hrs = strArr(0)
                If strArr(1) <> "00" Then
                    Min = Math.Round(strArr(1) / 60, 2) * 100
                End If
                Minstr = "." + Convert.ToString(Min)
                Effect = Convert.ToString(Hrs) + Minstr
                Try
                    sheet.Cells(21, 2) = (ds.Tables(2).Rows(0).Item("QtyMonthToDate")) / Effect
                Catch ex As DivideByZeroException
                    sheet.Cells(21, 2) = "0.00"
                End Try
            Else
                sheet.Cells(21, 2) = "0.00"
            End If


            If ds.Tables(9).Rows.Count > 0 And ds.Tables(13).Rows.Count > 0 Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim Minstr As String
                Dim str As String
                Dim strArr() As String
                Dim Effect As Decimal
                str = ds.Tables(13).Rows(0).Item("EPHYTD").ToString()
                strArr = str.Split(":")
                Hrs = strArr(0)
                If strArr(1) <> "00" Then
                    Min = Math.Round(strArr(1) / 60, 2) * 100
                End If
                Minstr = "." + Convert.ToString(Min)
                Effect = Convert.ToString(Hrs) + Minstr
                Try
                    sheet.Cells(21, 3) = (ds.Tables(9).Rows(0).Item("QtyYearToDate")) / Effect
                Catch ex As DivideByZeroException
                    sheet.Cells(21, 3) = "0.00"
                End Try
            Else
                sheet.Cells(21, 3) = "0.00"
            End If

            If ds.Tables(16).Rows.Count > 0 And ds.Tables(20).Rows.Count > 0 Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim Minstr As String
                Dim str As String
                Dim strArr() As String
                Dim Effect As Decimal
                str = ds.Tables(20).Rows(0).Item("EPHLYTD").ToString()
                strArr = str.Split(":")
                Hrs = strArr(0)
                If strArr(1) <> "00" Then
                    Min = Math.Round(strArr(1) / 60, 2) * 100
                End If
                Minstr = "." + Convert.ToString(Min)
                Effect = Convert.ToString(Hrs) + Minstr
                Try
                    sheet.Cells(21, 6) = (ds.Tables(16).Rows(0).Item("QtyYearToDate")) / Effect
                Catch ex As DivideByZeroException
                    sheet.Cells(21, 6) = "0.00"
                End Try
            Else
                sheet.Cells(21, 6) = "0.00"
            End If

            If ds.Tables(23).Rows.Count > 0 Then
                sheet.Cells(22, 2) = ds.Tables(23).Rows(0).Item("PKOProductionFFAPMTD")
            Else
                sheet.Cells(22, 2) = "0.00"
            End If

            If ds.Tables(24).Rows.Count > 0 Then
                sheet.Cells(22, 3) = ds.Tables(24).Rows(0).Item("PKOProductionFFAPYTD")
            Else
                sheet.Cells(22, 3) = "0.00"
            End If


            If ds.Tables(25).Rows.Count > 0 Then
                sheet.Cells(22, 6) = ds.Tables(25).Rows(0).Item("PKOProductionFFAPYTD")
            Else
                sheet.Cells(22, 6) = "0.00"
            End If


            If ds.Tables(24).Rows.Count > 0 And ds.Tables(23).Rows.Count > 0 Then
                sheet.Cells(22, 4) = (ds.Tables(24).Rows(0).Item("PKOProductionFFAPYTD") - ds.Tables(23).Rows(0).Item("PKOProductionFFAPMTD"))
            End If
            sheet.Protect("RANNBSP@2010")


            sheet.Visible = True
            xlApp.Visible = True

            Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
        End If

        Cursor = Cursors.Arrow
        'Catch ex As Exception
        '    MsgBox(ex)
        'End Try

    End Sub

End Class