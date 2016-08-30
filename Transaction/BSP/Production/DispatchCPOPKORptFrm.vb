Imports Production_PPT
Imports Production_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Public Class DispatchCPOPKORptFrm

    Private Sub DispatchCPOPKORptFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DispatchCPOPKORptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetInterface()
        If GlobalPPT.strLang <> "en" Then
            ' btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnReport.Text = "Lihat Laporan"
        End If
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        ' End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strFullMonthName As String = String.Empty
        Dim objGlobalBOL As New GlobalBOL
        strFullMonthName = objGlobalBOL.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

        strMonthlyProdRptName = "DISPATCH - CPO AND Kernel FOR THE MONTH " & strFullMonthName & ""

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        xlApp = New Excel.Application
        ' xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Dispatch_CPO_PKO_for_the_month_Template.xls")
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Dispatch_CPO_PKO_for_the_month_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Dispatch_CPO_PKO_for_the_month_Template.xls")
        Else
            MsgBox("Dispatch CPO PKO for the month report template missing.Please contact system administrator.")
            Exit Sub
        End If

        Dim ReportDirectory As String = String.Empty

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Production Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If



        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


        Dim intRowCount As Integer
        Dim intPKORowCount As Integer

        Dim con1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim da1 As New SqlDataAdapter


        strDSN = GlobalPPT.SelectedDB.Server
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr1 As String = " Data Source=" & strDSN & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"
        con1 = New SqlConnection(constr1)
        con1.Open()

        cmd1.Connection = con1
        cmd1.CommandText = "Production.DispatchCPOandPKOForMonth" ' '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & strSSTIssueID & "' "
        cmd1.CommandTimeout = 1800
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        ' cmd1.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd1.Parameters.AddWithValue("@Period", (cbMonth.SelectedIndex) + 1)
        cmd1.Parameters.AddWithValue("@FYear", cbYear.Text)
        cmd1.Parameters.AddWithValue("@ToDate", System.DateTime.Today)
        cmd1.Parameters.AddWithValue("@ToDateYear", System.DateTime.Today)

        Dim ds As New DataSet
        Dim tblAdt As New Odbc.OdbcDataAdapter

        da1.SelectCommand = cmd1
        da1.Fill(ds, "Sample")

        Dim lEstate As String
        Dim lDate As String

        lDate = Format(System.DateTime.Now, "dd/MM/yyyy")
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        sheet.Cells(5, 1) = "Estate/Mill :" & lEstate & " "
        sheet.Cells(3, 7) = "Date :" & lDate & " "
        sheet.Cells(8, 1) = strMonthlyProdRptName
        sheet.Cells(5, 6) = "From :" & Format(ds.Tables(8).Rows(0).Item("FromDT"), "dd/MM/yyyy")
        sheet.Cells(5, 7) = "To :" & Format(ds.Tables(8).Rows(0).Item("ToDT"), "dd/MM/yyyy")


        If ds.Tables(0).Rows.Count > 0 Then
            sheet.Cells(13, 2) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
            sheet.Cells(19, 4) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            sheet.Cells(13, 3) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
            sheet.Cells(19, 5) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
        End If
        If ds.Tables(2).Rows.Count > 0 Then
            sheet.Cells(14, 1) = "Kernel"
            sheet.Cells(14, 2) = ds.Tables(2).Rows(0).Item("PKOMillWeightMonth")
            sheet.Cells(20, 4) = ds.Tables(2).Rows(0).Item("PKOMillWeightMonth")
        End If
        If ds.Tables(3).Rows.Count > 0 Then
            sheet.Cells(14, 3) = ds.Tables(3).Rows(0).Item("PKOMillWeightYear")
            sheet.Cells(20, 5) = ds.Tables(3).Rows(0).Item("PKOMillWeightYear")
        End If



        If ds.Tables(6).Rows.Count > 0 And ds.Tables(7).Rows.Count > 0 Then
            sheet.Cells(19, 1) = ds.Tables(6).Rows(0).Item("CropYieldCode")
            sheet.Cells(19, 2) = ds.Tables(6).Rows(0).Item("QtyMonthToDate")
            sheet.Cells(19, 3) = ds.Tables(6).Rows(0).Item("QtyYearToDate")
            sheet.Cells(19, 6) = (ds.Tables(6).Rows(0).Item("QtyMonthToDate") - ds.Tables(0).Rows(0).Item("CPOMillWeightMonth"))
            sheet.Cells(19, 7) = (ds.Tables(6).Rows(0).Item("QtyYearToDate") - ds.Tables(1).Rows(0).Item("CPOMillWeightYear"))
            sheet.Cells(20, 1) = ds.Tables(7).Rows(0).Item("CropYieldCode")
            sheet.Cells(20, 2) = ds.Tables(7).Rows(0).Item("QtyMonthToDate")
            sheet.Cells(20, 3) = ds.Tables(7).Rows(0).Item("QtyYearToDate")
            sheet.Cells(20, 6) = (ds.Tables(7).Rows(0).Item("QtyMonthToDate") - ds.Tables(2).Rows(0).Item("PKOMillWeightMonth"))
            sheet.Cells(20, 7) = (ds.Tables(7).Rows(0).Item("QtyYearToDate") - ds.Tables(3).Rows(0).Item("PKOMillWeightYear"))
        End If

        intRowCount = ds.Tables(4).Rows.Count
        Dim intRow As Integer = 25
        Dim i As Integer = 0
        If intRowCount > 0 Then
            While intRowCount > 0

                sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 1) = ds.Tables(4).Rows(i).Item("DispatchDate")

                sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 2) = ds.Tables(4).Rows(i).Item("ProductCode")

                sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 3) = ds.Tables(4).Rows(i).Item("ShipPontoon")

                sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 4) = ds.Tables(4).Rows(i).Item("DOA")

                sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 5) = ds.Tables(4).Rows(i).Item("DCL")

                sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 6) = ds.Tables(4).Rows(i).Item("DepartureDate")

                sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 7) = ds.Tables(4).Rows(i).Item("MillWeight")

                sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intRow, 8) = ds.Tables(4).Rows(i).Item("LoadingLocationCode")

                sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intRow, 9) = ds.Tables(4).Rows(i).Item("BAPNo")
                intRowCount = intRowCount - 1
                intRow = intRow + 1
                i = i + 1

            End While
        End If


        Dim intPKORow As Integer = intRow
        Dim j As Integer = 0

        'End If

        intPKORowCount = ds.Tables(5).Rows.Count
        If intPKORowCount > 0 Then
            While intPKORowCount > 0

                'sheet.Cells(int3rdTableStarCount, 4).VerticalAlignment = Excel.Constants.xlTop
                'sheet.Cells(int3rdTableStarCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intPKORow, 1) = ds.Tables(5).Rows(j).Item("DispatchDate")

                sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                sheet.Cells(intPKORow, 2) = ds.Tables(5).Rows(j).Item("ProductCode")



                sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                sheet.Cells(intPKORow, 3) = ds.Tables(5).Rows(j).Item("ShipPontoon")




                sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intPKORow, 4) = ds.Tables(5).Rows(j).Item("DOA")



                sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                sheet.Cells(intPKORow, 5) = ds.Tables(5).Rows(j).Item("DCL")


                sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                sheet.Cells(intPKORow, 6) = ds.Tables(5).Rows(j).Item("DepartureDate")




                sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intPKORow, 7) = ds.Tables(5).Rows(j).Item("MillWeight")


                sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intPKORow, 8) = ds.Tables(5).Rows(j).Item("LoadingLocationCode")


                sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(intPKORow, 9) = ds.Tables(5).Rows(j).Item("BAPNo")

                intPKORowCount = intPKORowCount - 1
                intPKORow = intPKORow + 1
                j = j + 1

            End While

        End If
        xlApp.Visible = True
        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
        sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

    End Sub
End Class