Imports CheckRoll_BOL
Imports Common_PPT
Imports Common_BOL
Imports Common_DAL
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal

Public Class WorkingDistributionReportFrm


    Dim FromDate As Date
    Dim ToDate As Date
    Dim lGangTypecheck As Boolean
    Dim lHKforblock As Decimal
    Dim lHKforblockTotal As Decimal
    Dim lHKforGangTotal As Decimal
    Dim lHKforYOPTotal As Decimal = 0
    Dim lDaysCalc As Integer
    Dim Lrowgangno As Integer = 0
    Dim LrowYOP As Integer = 0
    Dim lTotalDistriChk As Boolean = True
    Dim lTotalDistriGangChk As Boolean = True
    Dim LrowYOPTotalRecord As Integer = 0
    Dim LrowgangTotalRecord As Integer = 0
    Dim LrowYOPalreadyCheck As Boolean = 0

    Private Sub WorkingDistributionReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetInterface()
    End Sub

    Private Sub GetInterface()

        Dim ds As New DataSet

        Dim objMaterialUsageReportDAL As New MaterialUsageReport_BOL
        ds = objMaterialUsageReportDAL.GetInterfaceYear()
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
        ' If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        ' KillAllExcels()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim fMsg As New ProgressingFrm
        fMsg.TopMost = True
        fMsg.Show()
        ' fMsg.lblMessage.Refresh()
        fMsg.lblTitle.Refresh()
        fMsg.lblTitle.Text = "Working Distribution Report Processing . . ."
        fMsg.lblTitle.Refresh()

        If rdPanen.Checked = True Then
            TeamPanenReport()
        ElseIf RdRawat.Checked = True Then
            RawatTeamReport()
        Else
            general()
        End If

        fMsg.Close()

    End Sub


    'Private Sub TeamRawatReport()
    '    Cursor = Cursors.WaitCursor


    '    Dim xlApp As Excel.Application
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim strServerUserName As String = String.Empty
    '    Dim strServerPassword As String = String.Empty
    '    Dim strDSN As String = String.Empty
    '    Dim StrInitialCatlog As String = String.Empty
    '    Dim MaterialusageFlag As Boolean = True



    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDataSource").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""
    '    StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


    '     Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"

    ' Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim cmd1 As New SqlCommand
    '    Dim da As New SqlDataAdapter
    '    con = New SqlConnection(constr)

    '    con.Open()


    '    cmd.Connection = con
    '    cmd.CommandText = "checkroll.CRWorkingDistributionRawatReport"

    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
    '    cmd.Parameters.AddWithValue("@Amonth", (cbMonth.SelectedIndex) + 1)
    '    cmd.Parameters.AddWithValue("@AYear", cbYear.Text)


    '    Dim tblAdt As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(ds, "WorkingDistributionReport")

    '    Dim ReportDirectory As String = String.Empty
    '    xlApp = New Excel.Application

    '    Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx"
    '    If (File.Exists(TemPath)) Then
    '        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx")
    '    Else
    '        MsgBox("Material Usage report template missing.Please contact system administrator.")
    '        ' Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

    '    Dim sDirName As String
    '    sDirName = ReportDirectory + ":"
    '    Dim dDir As New DirectoryInfo(sDirName)

    '    If Not dDir.Exists Then
    '        MessageBox.Show("Report directory not found", "BSP")
    '        ' Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP CheckRoll Reports")

    '    If Not di.Exists Then
    '        di.Create()
    '    End If

    '    Dim lTextmonth As String = String.Empty
    '    Dim objCommonBOl As New GlobalBOL

    '    lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

    '    lTextmonth = " WORKING DISTRIBUTION FOR " & lTextmonth & "(TEAM RAWAT )"

    '    Dim StrPath As String = ""

    '    StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

    '    Dim lEstate As String
    '    Dim strArray As String()
    '    strArray = GlobalPPT.strEstateName.Split("-")
    '    lEstate = strArray(1)

    '    If ds.Tables(0).Rows.Count < 1 Then
    '        Dim TotalDays As Integer = 30
    '        Dim sheet As Excel.Worksheet
    '        sheet = xlWorkBook.Sheets("Sheet1")
    '        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '        sheet.Cells(8, 2) = lEstate
    '        sheet.Cells(2, 1).numberformat = "@"
    '        sheet.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
    '        '    sheet.Cells(10, 2) = "" & cbMonth.Text & "" & cbYear.Text & ""
    '        sheet.Cells(4, 1) = lTextmonth
    '        sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Range(sheet.Cells(13, 1), sheet.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 1) = "Activity"
    '        sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 2)).Merge()
    '        sheet.Range(sheet.Cells(12, 1), sheet.Cells(13, 1)).Merge()
    '        'sheet.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

    '        sheet.Cells(12, 1).font.bold = True
    '        sheet.Cells(12, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 3) = "HK"
    '        sheet.Cells(12, 3).font.bold = True
    '        sheet.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

    '        sheet.Cells(13, 3) = "OT"
    '        sheet.Cells(13, 3).font.bold = True
    '        sheet.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
    '        'sheetNo.Range(sheetNo.Cells(12, 4), sheetNo.Cells(13, TotalDays + 4)).Merge()
    '        sheet.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
    '        sheet.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

    '        Dim lColumnCount As Integer
    '        lColumnCount = 4
    '        sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Range(sheet.Cells(13, 3), sheet.Cells(13, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Range(sheet.Cells(11, 36), sheet.Cells(11, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Range(sheet.Cells(12, 36), sheet.Cells(12, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        FromDate = GlobalPPT.FiscalYearFromDate
    '        While TotalDays >= 0
    '            sheet.Cells(13, lColumnCount).numberformat = "@"
    '            sheet.Cells(13, lColumnCount) = Format(FromDate, "dd")
    '            sheet.Cells(13, lColumnCount).font.bold = True
    '            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
    '            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '            FromDate = DateAdd(DateInterval.Day, 1, FromDate)
    '            lColumnCount = lColumnCount + 1
    '            TotalDays = TotalDays - 1
    '        End While
    '        sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
    '        sheet.Cells(12, lColumnCount) = "Total HK  & OT"
    '        sheet.Cells(12, lColumnCount).font.bold = True
    '        sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
    '        sheet.Cells(12, lColumnCount) = "Account Code"
    '        sheet.Cells(12, lColumnCount).font.bold = True
    '        sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
    '        sheet.Cells(12, lColumnCount) = "Old Account Code"
    '        sheet.Cells(12, lColumnCount).font.bold = True
    '        sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(12, lColumnCount + 4)).Merge()
    '        sheet.Cells(12, lColumnCount) = "T Analysis"
    '        sheet.Cells(12, lColumnCount).font.bold = True
    '        sheet.Cells(12, lColumnCount).HorizontalAlignment = Excel.Constants.xlCenter
    '        sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

    '        sheet.Cells(13, lColumnCount) = "T0"
    '        sheet.Cells(13, lColumnCount).font.bold = True
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Cells(13, lColumnCount) = "T1"
    '        sheet.Cells(13, lColumnCount).font.bold = True
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Cells(13, lColumnCount) = "T2"
    '        sheet.Cells(13, lColumnCount).font.bold = True
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Cells(13, lColumnCount) = "T3"
    '        sheet.Cells(13, lColumnCount).font.bold = True
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        lColumnCount = lColumnCount + 1
    '        sheet.Cells(13, lColumnCount) = "T4"
    '        sheet.Cells(13, lColumnCount).font.bold = True
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous


    '        sheet.Columns().AutoFit()
    '        sheet.Protect("RANNBSP@2010")
    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If

    '        xlApp.Visible = True
    '        Cursor = Cursors.Default
    '        Exit Sub
    '    End If




    '    Dim LrowNo As Integer = 0
    '    Dim lsheetRowNo As Integer = 0
    '    Lrowgangno = 0
    '    LrowYOP = 0
    '    LrowYOPTotalRecord = 0
    '    LrowgangTotalRecord = 0


    '    If ds IsNot Nothing Then
    '        Dim GangTypeCount As Integer = 0
    '        GangTypeCount = ds.Tables(0).Rows.Count
    '        Dim TotalDays As Integer
    '        Dim lWorkingDistributionType As String
    '        Dim LtotalRecord As Integer
    '        LtotalRecord = ds.Tables(1).Rows.Count
    '        If GangTypeCount > 0 Then

    '            Dim sheet As Excel.Worksheet
    '            sheet = xlWorkBook.Sheets("Sheet1")
    '            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '            Dim sheetNo As Excel.Worksheet

    '            While (GangTypeCount > 0 And LtotalRecord > 0)
    '                sheetNo = xlWorkBook.Worksheets.Add
    '                sheet.UsedRange.Copy(Type.Missing.Value)
    '                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

    '                sheet.Cells(2, 1).numberformat = "@"
    '                sheet.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
    '                GangTypeCount = GangTypeCount - 1
    '                lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
    '                sheetNo.Cells(8, 2) = lEstate
    '                sheetNo.Cells(9, 2) = lWorkingDistributionType
    '                lWorkingDistributionType = lWorkingDistributionType.Replace("/", "")
    '                '  sheetNo.Cells(10, 2) = "" & cbMonth.Text & "" & cbYear.Text & ""
    '                sheetNo.Name = " " & lWorkingDistributionType & " "
    '                lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
    '                FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()

    '                sheetNo.Cells(4, 1) = lTextmonth



    '                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)

    '                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Range(sheetNo.Cells(13, 1), sheetNo.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 1) = "Activity"
    '                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, 2)).Merge()
    '                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(13, 1)).Merge()
    '                sheetNo.Cells(12, 1).font.bold = True
    '                sheetNo.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 3) = "HK"
    '                sheetNo.Cells(12, 3).font.bold = True
    '                sheetNo.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

    '                sheetNo.Cells(13, 3) = "OT"
    '                sheetNo.Cells(13, 3).font.bold = True
    '                sheetNo.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
    '                'sheetNo.Range(sheetNo.Cells(12, 4), sheetNo.Cells(13, TotalDays + 4)).Merge()
    '                sheetNo.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
    '                sheetNo.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

    '                Dim lColumnCount As Integer
    '                lColumnCount = 4
    '                sheetNo.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Range(sheetNo.Cells(13, 3), sheetNo.Cells(13, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Range(sheetNo.Cells(11, TotalDays + 6), sheetNo.Cells(11, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Range(sheetNo.Cells(12, TotalDays + 6), sheetNo.Cells(12, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

    '                While TotalDays >= 0
    '                    sheetNo.Cells(13, lColumnCount).numberformat = "@"
    '                    sheetNo.Cells(13, lColumnCount) = Format(FromDate, "dd")
    '                    sheetNo.Cells(13, lColumnCount).font.bold = True
    '                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
    '                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                    FromDate = DateAdd(DateInterval.Day, 1, FromDate)
    '                    lColumnCount = lColumnCount + 1
    '                    TotalDays = TotalDays - 1
    '                End While
    '                sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
    '                sheetNo.Cells(12, lColumnCount) = "Total HK  & OT"
    '                sheetNo.Cells(12, lColumnCount).font.bold = True
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
    '                sheetNo.Cells(12, lColumnCount) = "Account Code"
    '                sheetNo.Cells(12, lColumnCount).font.bold = True
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
    '                sheetNo.Cells(12, lColumnCount) = "Old Account Code"
    '                sheetNo.Cells(12, lColumnCount).font.bold = True
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(12, lColumnCount + 4)).Merge()
    '                sheetNo.Cells(12, lColumnCount) = "T Analysis"
    '                sheetNo.Cells(12, lColumnCount).font.bold = True
    '                sheetNo.Cells(12, lColumnCount).HorizontalAlignment = Excel.Constants.xlCenter
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

    '                sheetNo.Cells(13, lColumnCount) = "T0"
    '                sheetNo.Cells(13, lColumnCount).font.bold = True
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Cells(13, lColumnCount) = "T1"
    '                sheetNo.Cells(13, lColumnCount).font.bold = True
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Cells(13, lColumnCount) = "T2"
    '                sheetNo.Cells(13, lColumnCount).font.bold = True
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Cells(13, lColumnCount) = "T3"
    '                sheetNo.Cells(13, lColumnCount).font.bold = True
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                lColumnCount = lColumnCount + 1
    '                sheetNo.Cells(13, lColumnCount) = "T4"
    '                sheetNo.Cells(13, lColumnCount).font.bold = True
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                Dim lYOPtype As String
    '                lsheetRowNo = 12
    '                Dim lDistribdate As Date
    '                Dim lCheckBlock As String = String.Empty
    '                Dim lCheckBlockName As Boolean = False
    '                Dim lCheckYOPType As Boolean = False
    '                lGangTypecheck = True
    '                Dim lChksubblockDistrDate As Boolean = True
    '                lCheckBlockName = True


    '                If LtotalRecord > 0 Then
    '                    While lCheckYOPType = False And LtotalRecord > 0 And lGangTypecheck = True
    '                        lsheetRowNo = lsheetRowNo + 2
    '                        lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                        sheetNo.Cells(lsheetRowNo, 1) = "YOP :" & lYOPtype & ""
    '                        lsheetRowNo = lsheetRowNo + 2
    '                        lCheckBlockName = False
    '                        lChksubblockDistrDate = False
    '                        While (lCheckBlockName = False And LtotalRecord > 0 And lChksubblockDistrDate = False)
    '                            sheetNo.Cells(lsheetRowNo, 1) = ds.Tables(1).Rows(LrowNo).Item("Activity").ToString
    '                            FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()

    '                            sheetNo.Cells(lsheetRowNo, 2) = ds.Tables(1).Rows(LrowNo).Item("BlockName").ToString()
    '                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("HK").ToString
    '                            lCheckBlock = ds.Tables(1).Rows(LrowNo).Item("BlockName").ToString()
    '                            lChksubblockDistrDate = True
    '                            lHKforblock = 0
    '                            While lChksubblockDistrDate = True
    '                                lDistribdate = ds.Tables(1).Rows(LrowNo).Item("RDate").ToString
    '                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                lDaysCalc = lDaysCalc + 4
    '                                sheetNo.Cells(lsheetRowNo, lDaysCalc).Numberformat = "0.00"
    '                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("TotalHK")
    '                                lHKforblock = lHKforblock + ds.Tables(1).Rows(LrowNo).Item("TotalHK")
    '                                lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                                LrowNo = LrowNo + 1
    '                                lTotalDistriChk = False
    '                                LtotalRecord = LtotalRecord - 1
    '                                If LtotalRecord > 0 Then
    '                                    If lCheckBlock <> ds.Tables(1).Rows(LrowNo).Item("BlockName") Or lYOPtype <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString Or lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Or ds.Tables(1).Rows(LrowNo).Item("HK").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("HK").ToString() Then
    '                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                        lDaysCalc = TotalDays + 5
    '                                        LrowNo = LrowNo - 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("COACode")
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("OldCOACode")
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T0")
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T1")
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T2")
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T3")
    '                                        lDaysCalc = lDaysCalc + 1
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T4")
    '                                        lsheetRowNo = lsheetRowNo + 1
    '                                        lChksubblockDistrDate = False
    '                                        LrowNo = LrowNo + 1
    '                                        If lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then
    '                                            lCheckYOPType = True
    '                                            lGangTypecheck = False
    '                                            lCheckBlockName = True
    '                                            lChksubblockDistrDate = False

    '                                            lHKforblockTotal = 0
    '                                            If LrowYOP < ds.Tables(2).Rows.Count Then
    '                                                sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
    '                                                sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                                sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("HK").ToString
    '                                                sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                While lTotalDistriChk = False
    '                                                    lDistribdate = ds.Tables(2).Rows(LrowYOP).Item("RDate").ToString
    '                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                                    lDaysCalc = lDaysCalc + 4
    '                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                    lHKforblockTotal = lHKforblockTotal + ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                    LrowYOP = LrowYOP + 1

    '                                                    If LrowYOP < ds.Tables(2).Rows.Count Then
    '                                                        If ds.Tables(2).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(2).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                            lsheetRowNo = lsheetRowNo + 1
    '                                                            lHKforblockTotal = 0
    '                                                            lTotalDistriChk = False
    '                                                            sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
    '                                                            sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("HK").ToString
    '                                                            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

    '                                                            While lTotalDistriChk = False
    '                                                                lDistribdate = ds.Tables(2).Rows(LrowYOP).Item("RDate").ToString
    '                                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                                                lDaysCalc = lDaysCalc + 4
    '                                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                                lHKforblockTotal = lHKforblockTotal + ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                                LrowYOP = LrowYOP + 1
    '                                                                If ds.Tables(2).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(2).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                                    lTotalDistriChk = False
    '                                                                Else
    '                                                                    lTotalDistriChk = True
    '                                                                End If

    '                                                            End While
    '                                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforblockTotal

    '                                                            lTotalDistriChk = True
    '                                                        ElseIf ds.Tables(1).Rows(LrowYOP).Item("HK").ToString = ds.Tables(1).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                            lTotalDistriChk = False

    '                                                        ElseIf lYOPtype <> ds.Tables(2).Rows(LrowYOP).Item("YOP").ToString() Or lWorkingDistributionType <> ds.Tables(2).Rows(LrowYOP).Item("GangName").ToString() Then
    '                                                            lTotalDistriChk = True
    '                                                        Else
    '                                                            lTotalDistriChk = False
    '                                                        End If
    '                                                    Else
    '                                                        lTotalDistriChk = True
    '                                                    End If


    '                                                End While
    '                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforblockTotal

    '                                                'lHKforGangTotal = 0
    '                                                'lTotalDistriGangChk = True
    '                                                'lsheetRowNo = lsheetRowNo + 2
    '                                                'sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
    '                                                'sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                                'sheetNo.Cells(lsheetRowNo, 3) = "HK"
    '                                                'sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                                'TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                                'sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                'While lTotalDistriGangChk = True And Lrowgangno < ds.Tables(3).Rows.Count
    '                                                '    lDistribdate = ds.Tables(3).Rows(Lrowgangno).Item("RDate").ToString
    '                                                '    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                                '    lDaysCalc = lDaysCalc + 4
    '                                                '    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(3).Rows(Lrowgangno).Item("TotalHkGang")
    '                                                '    lHKforGangTotal = lHKforGangTotal + ds.Tables(3).Rows(Lrowgangno).Item("TotalHkGang")
    '                                                '    Lrowgangno = Lrowgangno + 1

    '                                                '    If Lrowgangno < ds.Tables(3).Rows.Count Then
    '                                                '        If ds.Tables(1).Rows(Lrowgangno).Item("HK").ToString = ds.Tables(1).Rows(Lrowgangno - 1).Item("HK").ToString Then
    '                                                '            lsheetRowNo = lsheetRowNo + 1
    '                                                '            sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
    '                                                '            sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                                '            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(3).Rows(Lrowgangno).Item("HK").ToString
    '                                                '            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                                '            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                                '            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                '            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

    '                                                '            lTotalDistriChk = True
    '                                                '        ElseIf lWorkingDistributionType <> ds.Tables(3).Rows(Lrowgangno).Item("GangName").ToString() Then
    '                                                '            lTotalDistriGangChk = False
    '                                                '        Else
    '                                                '            lTotalDistriGangChk = True
    '                                                '        End If
    '                                                '    Else
    '                                                '        lTotalDistriGangChk = False
    '                                                '    End If

    '                                                'End While
    '                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
    '                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

    '                                                sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
    '                                                sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
    '                                                sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"

    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

    '                                            End If


    '                                        ElseIf lYOPtype <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString Then


    '                                            lCheckBlockName = True
    '                                            lsheetRowNo = lsheetRowNo + 2

    '                                            lHKforblockTotal = 0
    '                                            sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
    '                                            sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(LrowYOP).Item("HK").ToString
    '                                            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                            While lTotalDistriChk = False And LrowYOP < ds.Tables(2).Rows.Count
    '                                                lDistribdate = ds.Tables(2).Rows(LrowYOP).Item("RDate").ToString
    '                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                                lDaysCalc = lDaysCalc + 4
    '                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                lHKforblockTotal = lHKforblockTotal + ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                LrowYOP = LrowYOP + 1


    '                                                If LrowYOP < ds.Tables(2).Rows.Count Then
    '                                                    If ds.Tables(2).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(2).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                        lsheetRowNo = lsheetRowNo + 1
    '                                                        lHKforblockTotal = 0
    '                                                        lTotalDistriChk = False
    '                                                        sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
    '                                                        sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                                        sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(LrowYOP).Item("HK").ToString
    '                                                        sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

    '                                                        While lTotalDistriChk = False
    '                                                            lDistribdate = ds.Tables(2).Rows(LrowYOP).Item("RDate").ToString
    '                                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                                            lDaysCalc = lDaysCalc + 4
    '                                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                            lHKforblockTotal = lHKforblockTotal + ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                            LrowYOP = LrowYOP + 1
    '                                                            If ds.Tables(2).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(2).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                                lTotalDistriChk = False
    '                                                            Else
    '                                                                lTotalDistriChk = True
    '                                                            End If

    '                                                        End While
    '                                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforblockTotal

    '                                                        lTotalDistriChk = True

    '                                                    ElseIf ds.Tables(1).Rows(LrowYOP).Item("HK").ToString = ds.Tables(1).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                        lTotalDistriChk = False

    '                                                    ElseIf lYOPtype <> ds.Tables(2).Rows(LrowYOP).Item("YOP").ToString() Or lWorkingDistributionType <> ds.Tables(2).Rows(LrowYOP).Item("GangName").ToString() Then
    '                                                        lTotalDistriChk = True
    '                                                    Else
    '                                                        lTotalDistriChk = False
    '                                                    End If
    '                                                Else
    '                                                    lTotalDistriChk = True
    '                                                End If


    '                                            End While
    '                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforblockTotal


    '                                        Else
    '                                            lCheckBlockName = False
    '                                        End If

    '                                    Else
    '                                        lChksubblockDistrDate = True
    '                                    End If
    '                                Else
    '                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                    lDaysCalc = TotalDays + 5
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
    '                                    LrowNo = LrowNo - 1
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("COACode")
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("OldCOACode")
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T0")
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T1")
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T2")
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T3")
    '                                    lDaysCalc = lDaysCalc + 1
    '                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T4")
    '                                    lsheetRowNo = lsheetRowNo + 1
    '                                    lChksubblockDistrDate = False
    '                                    lCheckBlockName = True
    '                                    LrowNo = LrowNo + 1

    '                                    lHKforblockTotal = 0
    '                                    If LrowYOP < ds.Tables(2).Rows.Count Then
    '                                        sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
    '                                        sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                        sheetNo.Cells(lsheetRowNo, 3) = "HK"
    '                                        sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                        While lTotalDistriChk = False
    '                                            lDistribdate = ds.Tables(2).Rows(LrowYOP).Item("RDate").ToString
    '                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                            lDaysCalc = lDaysCalc + 4
    '                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                            lHKforblockTotal = lHKforblockTotal + ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                            LrowYOP = LrowYOP + 1

    '                                            If LrowYOP < ds.Tables(2).Rows.Count Then
    '                                                If ds.Tables(2).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(2).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                    lsheetRowNo = lsheetRowNo + 1
    '                                                    lTotalDistriChk = False
    '                                                    sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
    '                                                    sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                                    sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(LrowYOP).Item("HK").ToString
    '                                                    sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

    '                                                    While lTotalDistriChk = False
    '                                                        lDistribdate = ds.Tables(2).Rows(LrowYOP).Item("RDate").ToString
    '                                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                                        lDaysCalc = lDaysCalc + 4
    '                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
    '                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                        lHKforblockTotal = lHKforblockTotal + ds.Tables(2).Rows(LrowYOP).Item("TotalHkYOP")
    '                                                        LrowYOP = LrowYOP + 1
    '                                                        If ds.Tables(2).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(2).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                            lTotalDistriChk = False
    '                                                        Else
    '                                                            lTotalDistriChk = True
    '                                                        End If

    '                                                    End While
    '                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforblockTotal

    '                                                    lTotalDistriChk = True
    '                                                ElseIf ds.Tables(1).Rows(LrowYOP).Item("HK").ToString = ds.Tables(1).Rows(LrowYOP - 1).Item("HK").ToString Then
    '                                                    lTotalDistriChk = False

    '                                                ElseIf lYOPtype <> ds.Tables(2).Rows(LrowYOP).Item("YOP").ToString() Or lWorkingDistributionType <> ds.Tables(2).Rows(LrowYOP).Item("GangName").ToString() Then
    '                                                    lTotalDistriChk = True
    '                                                Else
    '                                                    lTotalDistriChk = False
    '                                                End If
    '                                            Else
    '                                                lTotalDistriChk = True
    '                                            End If

    '                                        End While
    '                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforblockTotal
    '                                    End If

    '                                    'lHKforGangTotal = 0
    '                                    'lTotalDistriGangChk = True
    '                                    'lsheetRowNo = lsheetRowNo + 2
    '                                    'sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
    '                                    'sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                    'sheetNo.Cells(lsheetRowNo, 3) = "HK"
    '                                    'sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                    'TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                    'sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                    'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                    'While lTotalDistriGangChk = True
    '                                    '    lDistribdate = ds.Tables(3).Rows(Lrowgangno).Item("RDate").ToString
    '                                    '    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                    '    lDaysCalc = lDaysCalc + 4
    '                                    '    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(3).Rows(Lrowgangno).Item("TotalHkGang")
    '                                    '    lHKforGangTotal = lHKforGangTotal + ds.Tables(3).Rows(Lrowgangno).Item("TotalHkGang")
    '                                    '    Lrowgangno = Lrowgangno + 1

    '                                    '    If Lrowgangno < ds.Tables(3).Rows.Count Then

    '                                    '        If ds.Tables(1).Rows(Lrowgangno).Item("HK").ToString = "OT" Then
    '                                    '            lsheetRowNo = lsheetRowNo + 1
    '                                    '            sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
    '                                    '            sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                    '            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(3).Rows(Lrowgangno).Item("HK").ToString
    '                                    '            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                    '            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                    '            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                    '            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

    '                                    '            lTotalDistriChk = True

    '                                    '        ElseIf lWorkingDistributionType <> ds.Tables(3).Rows(Lrowgangno).Item("GangName").ToString() Then
    '                                    '            lTotalDistriGangChk = False
    '                                    '        Else
    '                                    '            lTotalDistriGangChk = True
    '                                    '        End If

    '                                    '    Else
    '                                    '        lTotalDistriGangChk = False
    '                                    '    End If


    '                                    'End While
    '                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
    '                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
    '                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal
    '                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
    '                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
    '                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

    '                                    sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
    '                                    sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
    '                                    sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"

    '                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous


    '                                End If

    '                            End While
    '                            If LtotalRecord > 1 Then
    '                                If lYOPtype <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString And lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then
    '                                    lCheckYOPType = True
    '                                    lGangTypecheck = False
    '                                    lChksubblockDistrDate = True


    '                                ElseIf lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then
    '                                    lCheckYOPType = True
    '                                    lGangTypecheck = False
    '                                    lChksubblockDistrDate = True
    '                                    lsheetRowNo = lsheetRowNo + 2



    '                                Else
    '                                    lCheckYOPType = False
    '                                    lGangTypecheck = True
    '                                    lChksubblockDistrDate = False



    '                                End If
    '                            End If
    '                        End While



    '                    End While
    '                End If
    '                sheetNo.Columns().AutoFit()
    '                'sheetNo.Protect("RANNBSP@2010")
    '            End While


    '            sheet.Visible = False

    '        End If
    '    End If

    '    xlApp.Visible = True


    '    If (File.Exists(StrPath)) Then
    '        File.Delete(StrPath)
    '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '    Else
    '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '    End If

    '    Cursor = Cursors.Default
    'End Sub

    Private Sub General()
        Cursor = Cursors.WaitCursor

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim MaterialusageFlag As Boolean = True



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
        cmd.CommandText = "checkroll.CRWorkingDistributionGeneralReport"

        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Amonth", (cbMonth.SelectedIndex) + 1)
        cmd.Parameters.AddWithValue("@AYear", cbYear.Text)


        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "WorkingDistributionReport")

        Dim ReportDirectory As String = String.Empty
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx"
        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx")
        Else
            MsgBox("Material Usage report template missing.Please contact system administrator.")
            ' Cursor = Cursors.Arrow
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            ' Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP CheckRoll Reports")

        If Not di.Exists Then
            di.Create()
        End If

        Dim lTextmonth As String = String.Empty
        Dim objCommonBOl As New GlobalBOL

        lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

        lTextmonth = " WORKING DISTRIBUTION FOR " & lTextmonth & "(GENERAL)"

        Dim StrPath As String = ""

        StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)

        If ds.Tables(0).Rows.Count < 1 Then
            Dim TotalDays As Integer = 30
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells(8, 2) = lEstate
            sheet.Cells(2, 1).numberformat = "@"
            sheet.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
            '    sheet.Cells(10, 2) = "" & cbMonth.Text & "" & cbYear.Text & ""
            sheet.Cells(4, 1) = lTextmonth
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(13, 1), sheet.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 1) = "Activity"
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 2)).Merge()
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(13, 1)).Merge()
            'sheet.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(12, 1).font.bold = True
            sheet.Cells(12, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 3) = "HK"
            sheet.Cells(12, 3).font.bold = True
            sheet.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(13, 3) = "OT"
            sheet.Cells(13, 3).font.bold = True
            sheet.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
            'sheetNo.Range(sheetNo.Cells(12, 4), sheetNo.Cells(13, TotalDays + 4)).Merge()
            sheet.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
            sheet.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

            Dim lColumnCount As Integer
            lColumnCount = 4
            sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(13, 3), sheet.Cells(13, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(11, 36), sheet.Cells(11, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(12, 36), sheet.Cells(12, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            FromDate = GlobalPPT.FiscalYearFromDate
            While TotalDays >= 0
                sheet.Cells(13, lColumnCount).numberformat = "@"
                sheet.Cells(13, lColumnCount) = Format(FromDate, "dd")
                sheet.Cells(13, lColumnCount).font.bold = True
                sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
                sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                FromDate = DateAdd(DateInterval.Day, 1, FromDate)
                lColumnCount = lColumnCount + 1
                TotalDays = TotalDays - 1
            End While
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Total HK  & OT"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Account Code"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Old Account Code"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(12, lColumnCount + 4)).Merge()
            sheet.Cells(12, lColumnCount) = "T Analysis"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).HorizontalAlignment = Excel.Constants.xlCenter
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(13, lColumnCount) = "T0"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T1"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T2"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T3"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T4"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous


            sheet.Columns().AutoFit()
            sheet.Protect("RANNBSP@2010")
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            xlApp.Visible = True
            Cursor = Cursors.Default
            Exit Sub
        End If




        Dim LrowNo As Integer = 0
        Dim lsheetRowNo As Integer = 0
        Lrowgangno = 0
        LrowYOP = 0
        LrowYOPTotalRecord = 0
        LrowgangTotalRecord = 0


        If ds IsNot Nothing Then
            Dim GangTypeCount As Integer = 0
            GangTypeCount = ds.Tables(0).Rows.Count
            Dim TotalDays As Integer
            Dim lWorkingDistributionType As String
            Dim LtotalRecord As Integer
            LtotalRecord = ds.Tables(1).Rows.Count
            If GangTypeCount > 0 Then

                Dim sheet As Excel.Worksheet
                sheet = xlWorkBook.Sheets("Sheet1")
                sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
                Dim sheetNo As Excel.Worksheet

                While (GangTypeCount > 0 And LtotalRecord > 0)
                    sheetNo = xlWorkBook.Worksheets.Add
                    sheet.UsedRange.Copy(Type.Missing.Value)
                    sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

                    sheetNo.Cells(2, 1).numberformat = "@"
                    sheetNo.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
                    GangTypeCount = GangTypeCount - 1
                    lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
                    sheetNo.Cells(8, 2) = lEstate
                    sheetNo.Cells(9, 2) = lWorkingDistributionType
                    lWorkingDistributionType = lWorkingDistributionType.Replace("/", "")
                    '  sheetNo.Cells(10, 2) = "" & cbMonth.Text & "" & cbYear.Text & ""
                    sheetNo.Name = " " & lWorkingDistributionType & " "
                    If lWorkingDistributionType = "01L" Then
                        sheetNo.Name = " " & lWorkingDistributionType & " "
                    End If

                    lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
                    FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                    sheetNo.Cells(4, 1) = lTextmonth



                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)

                    sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(13, 1), sheetNo.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, 1) = "Activity"
                    sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, 2)).Merge()
                    sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(13, 1)).Merge()
                    sheetNo.Cells(12, 1).font.bold = True
                    sheetNo.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, 3) = "HK"
                    sheetNo.Cells(12, 3).font.bold = True
                    sheetNo.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(13, 3) = "OT"
                    sheetNo.Cells(13, 3).font.bold = True
                    sheetNo.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
                    'sheetNo.Range(sheetNo.Cells(12, 4), sheetNo.Cells(13, TotalDays + 4)).Merge()
                    sheetNo.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
                    sheetNo.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

                    Dim lColumnCount As Integer
                    lColumnCount = 4
                    sheetNo.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(13, 3), sheetNo.Cells(13, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(11, TotalDays + 6), sheetNo.Cells(11, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(12, TotalDays + 6), sheetNo.Cells(12, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                    While TotalDays >= 0
                        sheetNo.Cells(13, lColumnCount).numberformat = "@"
                        sheetNo.Cells(13, lColumnCount) = Format(FromDate, "dd")
                        sheetNo.Cells(13, lColumnCount).font.bold = True
                        sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                        sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                        sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                        FromDate = DateAdd(DateInterval.Day, 1, FromDate)
                        lColumnCount = lColumnCount + 1
                        TotalDays = TotalDays - 1
                    End While
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "Total HK  & OT"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "Account Code"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "Old Account Code"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(12, lColumnCount + 4)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "T Analysis"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).HorizontalAlignment = Excel.Constants.xlCenter
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(13, lColumnCount) = "T0"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T1"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T2"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T3"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T4"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                    lsheetRowNo = 12
                    Dim lDistribdate As Date
                    Dim lCheckBlock As String = String.Empty
                    Dim lCheckBlockName As Boolean = False
                    lGangTypecheck = True
                    Dim lChksubblockDistrDate As Boolean = True
                    lCheckBlockName = True

                    If LtotalRecord > 0 Then
                        lCheckBlockName = False
                        lChksubblockDistrDate = False
                        lsheetRowNo = lsheetRowNo + 2
                        While (lCheckBlockName = False And LtotalRecord > 0 And lChksubblockDistrDate = False)
                            sheetNo.Cells(lsheetRowNo, 1) = ds.Tables(1).Rows(LrowNo).Item("Activity").ToString()

                            FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("HK").ToString()
                            lChksubblockDistrDate = True
                            lHKforblock = 0
                            While lChksubblockDistrDate = True And LrowNo < ds.Tables(1).Rows.Count
                                lDistribdate = ds.Tables(1).Rows(LrowNo).Item("RDate").ToString
                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                lDaysCalc = lDaysCalc + 4
                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("TotalHK")
                                lHKforblock = lHKforblock + ds.Tables(1).Rows(LrowNo).Item("TotalHK")
                                LrowNo = LrowNo + 1
                                lTotalDistriChk = False
                                LtotalRecord = LtotalRecord - 1

                                If LtotalRecord > 0 Then
                                    'If ds.Tables(1).Rows(LrowNo).Item("Activity").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("Activity").ToString() _
                                    '    Or ds.Tables(1).Rows(LrowNo).Item("HK").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("HK").ToString() _
                                    '    Or lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() _
                                    '    Or ds.Tables(1).Rows(LrowNo).Item("T0").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T0").ToString() _
                                    '    Or ds.Tables(1).Rows(LrowNo).Item("T1").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T1").ToString() _
                                    '    Or ds.Tables(1).Rows(LrowNo).Item("T2").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T2").ToString() _
                                    '    Or ds.Tables(1).Rows(LrowNo).Item("T3").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T3").ToString() _
                                    '    Or ds.Tables(1).Rows(LrowNo).Item("T4").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T4").ToString() Then

                                    If ds.Tables(1).Rows(LrowNo).Item("Activity").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("Activity").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("HK").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("HK").ToString() _
                                      Or lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("T0").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T0").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("T1").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T1").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("T2").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T2").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("T3").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T3").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("T4").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T4").ToString() _
                                      Or ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("COACode").ToString() Then


                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                        lDaysCalc = TotalDays + 5
                                        LrowNo = LrowNo - 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("COACode")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("OldCOACode")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T0")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T1")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T2")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T3")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T4")
                                        lsheetRowNo = lsheetRowNo + 1
                                        lChksubblockDistrDate = False
                                        LrowNo = LrowNo + 1
                                        If lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() And Lrowgangno < ds.Tables(2).Rows.Count Then
                                            lGangTypecheck = False
                                            lCheckBlockName = True
                                            lChksubblockDistrDate = False
                                            lHKforGangTotal = 0
                                            lTotalDistriGangChk = True
                                            lsheetRowNo = lsheetRowNo + 2
                                            'If lWorkingDistributionType = "01L" Then
                                            '    sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                            'End If
                                            sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                            sheetNo.Cells(lsheetRowNo, 1).font.bold = True

                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            While lTotalDistriGangChk = True
                                                lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                lDaysCalc = lDaysCalc + 4
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                Lrowgangno = Lrowgangno + 1
                                                If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                    If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString <> ds.Tables(2).Rows(Lrowgangno - 1).Item("HK").ToString Or lWorkingDistributionType <> ds.Tables(2).Rows(Lrowgangno).Item("GangName").ToString Then
                                                        lTotalDistriGangChk = False
                                                    Else
                                                        lTotalDistriGangChk = True
                                                    End If
                                                Else
                                                    lTotalDistriGangChk = False
                                                End If
                                            End While
                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                            'Palani
                                            lHKforGangTotal = 0

                                            ''Grand OT
                                            If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString = "OT" Then
                                                    lsheetRowNo = lsheetRowNo + 1
                                                    sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                                    sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                                    sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                    lTotalDistriGangChk = True
                                                    While lTotalDistriGangChk = True
                                                        lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                        lDaysCalc = lDaysCalc + 4
                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                        lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                        Lrowgangno = Lrowgangno + 1

                                                        If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                            If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString() = "HK" Or lWorkingDistributionType <> ds.Tables(2).Rows(Lrowgangno).Item("GangName").ToString Then
                                                                lTotalDistriGangChk = False
                                                            Else
                                                                lTotalDistriGangChk = True
                                                            End If
                                                        Else
                                                            lTotalDistriGangChk = False
                                                        End If
                                                    End While
                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                                    'Palani
                                                    lHKforGangTotal = 0
                                                End If
                                            End If

                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

                                            'sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
                                            'sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
                                            'sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"
                                            sheetNo.Cells(lsheetRowNo + 3, 3) = "Dibuat,"
                                            sheetNo.Cells(lsheetRowNo + 3, 20) = "Diperiksa,"
                                            sheetNo.Cells(lsheetRowNo + 3, 32) = "Disetujui,"

                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        Else
                                            lCheckBlockName = False
                                            'lChksubblockDistrDate = True
                                        End If
                                    Else
                                        lChksubblockDistrDate = True
                                        lCheckBlockName = False
                                    End If
                                Else
                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                    lDaysCalc = TotalDays + 5
                                    LrowNo = LrowNo - 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("COACode")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("OldCOACode")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T0")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T1")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T2")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T3")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T4")
                                    lsheetRowNo = lsheetRowNo + 1
                                    lChksubblockDistrDate = False
                                    LrowNo = LrowNo + 1
                                    If Lrowgangno < ds.Tables(2).Rows.Count Then
                                        lGangTypecheck = False
                                        lCheckBlockName = True
                                        lChksubblockDistrDate = False
                                        lHKforGangTotal = 0
                                        lTotalDistriGangChk = True
                                        lsheetRowNo = lsheetRowNo + 2
                                        sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                        sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                        sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        While lTotalDistriGangChk = True
                                            lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                            lDaysCalc = lDaysCalc + 4
                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                            lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                            Lrowgangno = Lrowgangno + 1
                                            If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString() <> ds.Tables(2).Rows(Lrowgangno - 1).Item("HK").ToString() Or lWorkingDistributionType <> ds.Tables(2).Rows(Lrowgangno).Item("GangName").ToString() Then
                                                    lTotalDistriGangChk = False
                                                Else
                                                    lTotalDistriGangChk = True
                                                End If
                                            Else
                                                lTotalDistriGangChk = False
                                            End If
                                        End While
                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                        'Palani
                                        lHKforGangTotal = 0

                                        ''Grand OT
                                        If Lrowgangno < ds.Tables(2).Rows.Count Then
                                            If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString = "OT" Then
                                                lsheetRowNo = lsheetRowNo + 1
                                                sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                                sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                                sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                lTotalDistriGangChk = True
                                                While lTotalDistriGangChk = True
                                                    lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                    lDaysCalc = lDaysCalc + 4
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                    lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                    Lrowgangno = Lrowgangno + 1

                                                    If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                        If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString() = "HK" Then
                                                            lTotalDistriGangChk = False
                                                        Else
                                                            lTotalDistriGangChk = True
                                                        End If
                                                    Else
                                                        lTotalDistriGangChk = False
                                                    End If
                                                End While
                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                                'Palani
                                                lHKforGangTotal = 0
                                            End If
                                        End If

                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

                                        'sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
                                        'sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
                                        'sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"
                                        sheetNo.Cells(lsheetRowNo + 3, 3) = "Dibuat,"
                                        sheetNo.Cells(lsheetRowNo + 3, 20) = "Diperiksa,"
                                        sheetNo.Cells(lsheetRowNo + 3, 32) = "Disetujui,"

                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

                                    End If

                                End If

                            End While
                        End While


                    End If


                    sheetNo.Columns().AutoFit()
                    'sheetNo.Protect("RANNBSP@2010")
                End While


                sheet.Visible = False

            End If
        End If

        xlApp.Visible = True


        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        Cursor = Cursors.Default

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Private Sub RawatTeamReport()
        Cursor = Cursors.WaitCursor

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim MaterialusageFlag As Boolean = True

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
        cmd.CommandText = "checkroll.CRWorkingDistributionRawatReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Amonth", (cbMonth.SelectedIndex) + 1)
        cmd.Parameters.AddWithValue("@AYear", cbYear.Text)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "WorkingDistributionReport")

        Dim ReportDirectory As String = String.Empty
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx"
        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx")
        Else
            MsgBox("Material Usage report template missing.Please contact system administrator.")
            ' Cursor = Cursors.Arrow
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            ' Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP CheckRoll Reports")

        If Not di.Exists Then
            di.Create()
        End If

        Dim lTextmonth As String = String.Empty
        Dim objCommonBOl As New GlobalBOL

        lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

        lTextmonth = " WORKING DISTRIBUTION FOR " & lTextmonth & "(TEAM RAWAT)"

        Dim StrPath As String = ""

        StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)

        'NO RECORDS
        If ds.Tables(0).Rows.Count < 1 Then
            Dim TotalDays As Integer = 30
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells(8, 2) = lEstate
            sheet.Cells(2, 1).numberformat = "@"
            sheet.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
            '    sheet.Cells(10, 2) = "" & cbMonth.Text & "" & cbYear.Text & ""
            sheet.Cells(4, 1) = lTextmonth
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(13, 1), sheet.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 1) = "Activity"
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 2)).Merge()
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(13, 1)).Merge()
            'sheet.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(12, 1).font.bold = True
            sheet.Cells(12, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 3) = "HK"
            sheet.Cells(12, 3).font.bold = True
            sheet.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(13, 3) = "OT"
            sheet.Cells(13, 3).font.bold = True
            sheet.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
            'sheetNo.Range(sheetNo.Cells(12, 4), sheetNo.Cells(13, TotalDays + 4)).Merge()
            sheet.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
            sheet.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

            Dim lColumnCount As Integer
            lColumnCount = 4
            sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(13, 3), sheet.Cells(13, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(11, 36), sheet.Cells(11, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(12, 36), sheet.Cells(12, 42)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            FromDate = GlobalPPT.FiscalYearFromDate
            While TotalDays >= 0
                sheet.Cells(13, lColumnCount).numberformat = "@"
                sheet.Cells(13, lColumnCount) = Format(FromDate, "dd")
                sheet.Cells(13, lColumnCount).font.bold = True
                sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
                sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                FromDate = DateAdd(DateInterval.Day, 1, FromDate)
                lColumnCount = lColumnCount + 1
                TotalDays = TotalDays - 1
            End While
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Total HK  & OT"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Account Code"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Old Account Code"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(12, lColumnCount + 4)).Merge()
            sheet.Cells(12, lColumnCount) = "T Analysis"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).HorizontalAlignment = Excel.Constants.xlCenter
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(13, lColumnCount) = "T0"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T1"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T2"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T3"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            lColumnCount = lColumnCount + 1
            sheet.Cells(13, lColumnCount) = "T4"
            sheet.Cells(13, lColumnCount).font.bold = True
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Columns().AutoFit()
            sheet.Protect("RANNBSP@2010")
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            xlApp.Visible = True
            Cursor = Cursors.Default

            ' put CultureInfo back to original
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

            Exit Sub
        End If

        ' IF Got Records
        Dim LrowNo As Integer = 0
        Dim lsheetRowNo As Integer = 0
        Lrowgangno = 0
        LrowYOP = 0
        LrowYOPTotalRecord = 0
        LrowgangTotalRecord = 0

        If ds IsNot Nothing Then
            Dim GangTypeCount As Integer = 0
            GangTypeCount = ds.Tables(0).Rows.Count
            Dim TotalDays As Integer
            Dim lWorkingDistributionType As String
            Dim LtotalRecord As Integer
            LtotalRecord = ds.Tables(1).Rows.Count
            If GangTypeCount > 0 Then

                Dim sheet As Excel.Worksheet
                sheet = xlWorkBook.Sheets("Sheet1")
                sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
                Dim sheetNo As Excel.Worksheet

                While (GangTypeCount > 0 And LtotalRecord > 0)
                    sheetNo = xlWorkBook.Worksheets.Add
                    sheet.UsedRange.Copy(Type.Missing.Value)
                    sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

                    sheetNo.Cells(2, 1).numberformat = "@"
                    sheetNo.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
                    GangTypeCount = GangTypeCount - 1
                    lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
                    'Palani - Debug Here
                    sheetNo.Cells(8, 2) = lEstate
                    sheetNo.Cells(9, 2) = lWorkingDistributionType
                    lWorkingDistributionType = lWorkingDistributionType.Replace("/", "")
                    '  sheetNo.Cells(10, 2) = "" & cbMonth.Text & "" & cbYear.Text & ""
                    sheetNo.Name = " " & lWorkingDistributionType & " "
                    If lWorkingDistributionType = "01L" Then
                        sheetNo.Name = " " & lWorkingDistributionType & " "
                    End If

                    lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
                    FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                    sheetNo.Cells(4, 1) = lTextmonth

                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)

                    sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(13, 1), sheetNo.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, 1) = "Activity"
                    sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, 2)).Merge()
                    sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(13, 1)).Merge()
                    sheetNo.Cells(12, 1).font.bold = True
                    sheetNo.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(12, 3) = "HK"
                    sheetNo.Cells(12, 3).font.bold = True
                    sheetNo.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(13, 3) = "OT"
                    sheetNo.Cells(13, 3).font.bold = True
                    sheetNo.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
                    sheetNo.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
                    sheetNo.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

                    Dim lColumnCount As Integer
                    lColumnCount = 4
                    sheetNo.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(13, 3), sheetNo.Cells(13, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(11, TotalDays + 6), sheetNo.Cells(11, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Range(sheetNo.Cells(12, TotalDays + 6), sheetNo.Cells(12, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                    'printing the Header
                    While TotalDays >= 0
                        sheetNo.Cells(13, lColumnCount).numberformat = "@"
                        sheetNo.Cells(13, lColumnCount) = Format(FromDate, "dd")
                        sheetNo.Cells(13, lColumnCount).font.bold = True
                        sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                        sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                        sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                        FromDate = DateAdd(DateInterval.Day, 1, FromDate)
                        lColumnCount = lColumnCount + 1
                        TotalDays = TotalDays - 1
                    End While

                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "Total HK  & OT"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "Account Code"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "Old Account Code"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(12, lColumnCount + 4)).Merge()
                    sheetNo.Cells(12, lColumnCount) = "T Analysis"
                    sheetNo.Cells(12, lColumnCount).font.bold = True
                    sheetNo.Cells(12, lColumnCount).HorizontalAlignment = Excel.Constants.xlCenter
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(13, lColumnCount) = "T0"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T1"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T2"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T3"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    lColumnCount = lColumnCount + 1
                    sheetNo.Cells(13, lColumnCount) = "T4"
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    ' Until this Header portion 

                    lsheetRowNo = 12
                    Dim lDistribdate As Date
                    Dim lYOPType As String = String.Empty 'Variable used to store the YOP
                    Dim lCheckBlockName As Boolean = False
                    lGangTypecheck = True
                    Dim lChksubblockDistrDate As Boolean = True
                    lCheckBlockName = True
                    lYOPType = ""
                    If LtotalRecord > 0 Then
                        lCheckBlockName = False
                        lChksubblockDistrDate = False

                        'To Print the YOP : 1994 in 14th ROW
                        lsheetRowNo = lsheetRowNo + 2

                        While (lCheckBlockName = False And LtotalRecord > 0 And lChksubblockDistrDate = False)
                            If lYOPType = "" Or lYOPType <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString() Then
                                sheetNo.Cells(lsheetRowNo, 1) = "YOP :" & ds.Tables(1).Rows(LrowNo).Item("YOP").ToString() & ""
                                lsheetRowNo = lsheetRowNo + 2
                                'Printing the First record in 16th ROW
                            End If

                            lYOPType = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString()
                            sheetNo.Cells(lsheetRowNo, 1) = ds.Tables(1).Rows(LrowNo).Item("Activity").ToString()
                            FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("HK").ToString()
                            lChksubblockDistrDate = True
                            lHKforblock = 0
                            'DATE COLUMN
                            While lChksubblockDistrDate = True And LrowNo < ds.Tables(1).Rows.Count
                                lDistribdate = ds.Tables(1).Rows(LrowNo).Item("RDate").ToString
                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                lDaysCalc = lDaysCalc + 4
                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("TotalHK")

                                ''Palani(-Debugging)
                                'Debug.Print("GANG " & lWorkingDistributionType)
                                'Debug.Print("YOP " & lYOPType)
                                'Debug.Print("DIST. DATE " & lDistribdate)
                                'Debug.Print("ROW " & lsheetRowNo & "COLUMN " & lDaysCalc)
                                'Debug.Print(ds.Tables(1).Rows(LrowNo).Item("TotalHK"))

                                'Incrementing the Row Total (Total HK & OT Column) Variable (After below IF condition Value is Printed)
                                lHKforblock = lHKforblock + ds.Tables(1).Rows(LrowNo).Item("TotalHK")
                                ' Incrementing the Record Number
                                LrowNo = LrowNo + 1
                                lTotalDistriChk = False
                                LtotalRecord = LtotalRecord - 1

                                If LtotalRecord > 0 Then
                                    'This Loop for Printing the ROW Total (Total HK & OT Column)
                                    'Checking all the Field Values (ACTIVITY, HK,YOP,GANGNAME,T0,T1,T2,T3,T4 & BlockName except RDATE(Distribution DATE)
                                    If lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("Activity").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("Activity").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("HK").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("HK").ToString() _
                                    Or lYOPType <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("T0").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T0").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("T1").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T1").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("T2").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T2").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("T3").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T3").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("T4").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("T4").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("BlockName").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("BlockName").ToString() _
                                    Or ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() <> ds.Tables(1).Rows(LrowNo - 1).Item("COACode").ToString() Then 'BlockName & COA Code Added by PALANI

                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                        lDaysCalc = TotalDays + 5
                                        LrowNo = LrowNo - 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                        'Printing the LINE Total
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("COACode")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("OldCOACode")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T0")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T1")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T2")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T3")
                                        lDaysCalc = lDaysCalc + 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T4")
                                        lsheetRowNo = lsheetRowNo + 1
                                        lChksubblockDistrDate = False
                                        LrowNo = LrowNo + 1

                                        'Incrementing LrowNo variable with 1, Checking with the next record whether SAME YOP or Different
                                        ' #### Check HERE ####

                                        'If lYOPType <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString() And LrowYOP < ds.Tables(3).Rows.Count Then

                                        'If lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() And _
                                        'lYOPType <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString() _
                                        'And LrowYOP < ds.Tables(3).Rows.Count Then

                                        If (lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Or _
                                        lYOPType <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString()) And _
                                        LrowYOP < ds.Tables(3).Rows.Count Then

                                            lCheckBlockName = True
                                            lChksubblockDistrDate = False
                                            lHKforYOPTotal = 0
                                            lTotalDistriGangChk = True
                                            lsheetRowNo = lsheetRowNo + 2
                                            sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
                                            sheetNo.Cells(lsheetRowNo, 1).font.bold = True

                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(3).Rows(LrowYOP).Item("HK").ToString
                                            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            While lTotalDistriGangChk = True
                                                'Palani - Debug Here
                                                lDistribdate = ds.Tables(3).Rows(LrowYOP).Item("RDate").ToString
                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                lDaysCalc = lDaysCalc + 4
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                                lHKforYOPTotal = lHKforYOPTotal + ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                                LrowYOP = LrowYOP + 1
                                                If LrowYOP < ds.Tables(3).Rows.Count Then
                                                    If ds.Tables(3).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(3).Rows(LrowYOP - 1).Item("HK").ToString _
                                                    Or lWorkingDistributionType <> ds.Tables(3).Rows(LrowYOP).Item("GangName").ToString _
                                                    Or lYOPType <> ds.Tables(3).Rows(LrowYOP).Item("YOP").ToString() Then
                                                        lTotalDistriGangChk = False
                                                    Else
                                                        lTotalDistriGangChk = True
                                                    End If
                                                Else
                                                    lTotalDistriGangChk = False
                                                End If
                                            End While
                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                            'Sub Total - Line Total
                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforYOPTotal
                                            lsheetRowNo = lsheetRowNo + 2

                                            ' Rest of OT line total
                                            lHKforYOPTotal = 0

                                            ''SUB OT
                                            If LrowYOP < ds.Tables(3).Rows.Count Then
                                                If ds.Tables(3).Rows(LrowYOP).Item("HK").ToString = "OT" Then
                                                    lsheetRowNo = lsheetRowNo - 1
                                                    sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
                                                    sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(3).Rows(LrowYOP).Item("HK").ToString
                                                    sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                    lTotalDistriGangChk = True
                                                    While lTotalDistriGangChk = True
                                                        lDistribdate = ds.Tables(3).Rows(LrowYOP).Item("RDate").ToString
                                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                        lDaysCalc = lDaysCalc + 4
                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                                        lHKforYOPTotal = lHKforYOPTotal + ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                                        LrowYOP = LrowYOP + 1

                                                        If LrowYOP < ds.Tables(3).Rows.Count Then
                                                            If ds.Tables(3).Rows(LrowYOP).Item("HK").ToString() = "HK" _
                                                            Or lWorkingDistributionType <> ds.Tables(3).Rows(LrowYOP).Item("GangName").ToString _
                                                            Or lYOPType <> ds.Tables(3).Rows(LrowYOP).Item("YOP").ToString() Then
                                                                lTotalDistriGangChk = False
                                                            Else
                                                                lTotalDistriGangChk = True
                                                            End If
                                                        Else
                                                            lTotalDistriGangChk = False
                                                        End If
                                                    End While
                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforYOPTotal
                                                    lsheetRowNo = lsheetRowNo + 2
                                                End If
                                            End If
                                        End If

                                        'palani 10 May 2011
                                        lHKforYOPTotal = 0

                                        'FOR GRAND TOTAL - WORKING CORRECTLY
                                        If lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() _
                                        And Lrowgangno < ds.Tables(2).Rows.Count Then
                                            lGangTypecheck = False
                                            lCheckBlockName = True
                                            lChksubblockDistrDate = False
                                            lHKforGangTotal = 0
                                            lTotalDistriGangChk = True
                                            lsheetRowNo = lsheetRowNo + 2
                                            sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                            sheetNo.Cells(lsheetRowNo, 1).font.bold = True

                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                            sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            While lTotalDistriGangChk = True
                                                lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                lDaysCalc = lDaysCalc + 4
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                Lrowgangno = Lrowgangno + 1
                                                If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                    If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString <> ds.Tables(2).Rows(Lrowgangno - 1).Item("HK").ToString Or lWorkingDistributionType <> ds.Tables(2).Rows(Lrowgangno).Item("GangName").ToString Then
                                                        lTotalDistriGangChk = False
                                                    Else
                                                        lTotalDistriGangChk = True
                                                    End If
                                                Else
                                                    lTotalDistriGangChk = False
                                                End If
                                            End While
                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                            'Palani
                                            lHKforGangTotal = 0

                                            ''Grand OT
                                            If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString = "OT" Then
                                                    lsheetRowNo = lsheetRowNo + 1
                                                    sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                                    sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                                    sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                    sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                    lTotalDistriGangChk = True
                                                    While lTotalDistriGangChk = True
                                                        lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                        lDaysCalc = lDaysCalc + 4
                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                        lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                        Lrowgangno = Lrowgangno + 1

                                                        If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                            If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString() = "HK" Or lWorkingDistributionType <> ds.Tables(2).Rows(Lrowgangno).Item("GangName").ToString Then
                                                                lTotalDistriGangChk = False
                                                            Else
                                                                lTotalDistriGangChk = True
                                                            End If
                                                        Else
                                                            lTotalDistriGangChk = False
                                                        End If
                                                    End While
                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                                    'Palani
                                                    lHKforGangTotal = 0
                                                End If
                                            End If

                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

                                            'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                            'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                            'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

                                            'sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
                                            'sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
                                            'sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"
                                            sheetNo.Cells(lsheetRowNo + 3, 3) = "Dibuat,"
                                            sheetNo.Cells(lsheetRowNo + 3, 20) = "Diperiksa,"
                                            sheetNo.Cells(lsheetRowNo + 3, 32) = "Disetujui,"

                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        Else
                                            lCheckBlockName = False
                                            'lChksubblockDistrDate = True
                                        End If
                                    Else
                                        lChksubblockDistrDate = True
                                        lCheckBlockName = False
                                    End If
                                Else

                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                    lDaysCalc = TotalDays + 5
                                    LrowNo = LrowNo - 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("COACode")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("OldCOACode")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "@"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T0")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T1")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T2")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T3")
                                    lDaysCalc = lDaysCalc + 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("T4")
                                    lsheetRowNo = lsheetRowNo + 1
                                    lChksubblockDistrDate = False
                                    LrowNo = LrowNo + 1

                                    If LrowYOP < ds.Tables(3).Rows.Count Then
                                        lCheckBlockName = True
                                        lChksubblockDistrDate = False
                                        lHKforYOPTotal = 0
                                        lTotalDistriGangChk = True
                                        lsheetRowNo = lsheetRowNo + 2
                                        sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
                                        sheetNo.Cells(lsheetRowNo, 1).font.bold = True

                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(3).Rows(LrowYOP).Item("HK").ToString
                                        sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        While lTotalDistriGangChk = True
                                            lDistribdate = ds.Tables(3).Rows(LrowYOP).Item("RDate").ToString
                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                            lDaysCalc = lDaysCalc + 4
                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                            lHKforYOPTotal = lHKforYOPTotal + ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                            LrowYOP = LrowYOP + 1
                                            If LrowYOP < ds.Tables(3).Rows.Count Then
                                                If ds.Tables(3).Rows(LrowYOP).Item("HK").ToString <> ds.Tables(3).Rows(LrowYOP - 1).Item("HK").ToString _
                                                Or lWorkingDistributionType <> ds.Tables(3).Rows(LrowYOP).Item("GangName").ToString _
                                                Or lYOPType <> ds.Tables(3).Rows(LrowYOP).Item("YOP").ToString() Then
                                                    lTotalDistriGangChk = False
                                                Else
                                                    lTotalDistriGangChk = True
                                                End If
                                            Else
                                                lTotalDistriGangChk = False
                                            End If
                                        End While
                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforYOPTotal

                                        'Palani
                                        lHKforYOPTotal = 0

                                        ''SUB OT
                                        If LrowYOP < ds.Tables(3).Rows.Count Then
                                            If ds.Tables(3).Rows(LrowYOP).Item("HK").ToString = "OT" Then
                                                lsheetRowNo = lsheetRowNo - 1
                                                sheetNo.Cells(lsheetRowNo, 1) = "Sub Total"
                                                sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(3).Rows(LrowYOP).Item("HK").ToString
                                                sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                lTotalDistriGangChk = True
                                                While lTotalDistriGangChk = True
                                                    lDistribdate = ds.Tables(3).Rows(LrowYOP).Item("RDate").ToString
                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                    lDaysCalc = lDaysCalc + 4
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                                    lHKforYOPTotal = lHKforYOPTotal + ds.Tables(3).Rows(LrowYOP).Item("TotalHkYOP")
                                                    LrowYOP = LrowYOP + 1

                                                    If LrowYOP < ds.Tables(3).Rows.Count Then
                                                        'If LrowYOP < ds.Tables(2).Rows.Count Then
                                                        If ds.Tables(3).Rows(LrowYOP).Item("HK").ToString() = "HK" _
                                                        Or lWorkingDistributionType <> ds.Tables(3).Rows(LrowYOP).Item("GangName").ToString _
                                                        Or lYOPType <> ds.Tables(3).Rows(LrowYOP).Item("YOP").ToString() Then
                                                            lTotalDistriGangChk = False
                                                        Else
                                                            lTotalDistriGangChk = True
                                                        End If
                                                    Else
                                                        lTotalDistriGangChk = False
                                                    End If
                                                End While
                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforYOPTotal
                                            End If
                                        End If
                                    End If

                                    'palani 10 May 2011
                                    lHKforYOPTotal = 0

                                    If Lrowgangno < ds.Tables(2).Rows.Count Then
                                        lGangTypecheck = False
                                        lCheckBlockName = True
                                        lChksubblockDistrDate = False
                                        lHKforGangTotal = 0
                                        lTotalDistriGangChk = True
                                        lsheetRowNo = lsheetRowNo + 2
                                        sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                        sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                        sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        While lTotalDistriGangChk = True
                                            lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                            lDaysCalc = lDaysCalc + 4
                                            sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                            lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                            Lrowgangno = Lrowgangno + 1
                                            If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString() <> ds.Tables(2).Rows(Lrowgangno - 1).Item("HK").ToString() Or lWorkingDistributionType <> ds.Tables(2).Rows(Lrowgangno).Item("GangName").ToString() Then
                                                    lTotalDistriGangChk = False
                                                Else
                                                    lTotalDistriGangChk = True
                                                End If
                                            Else
                                                lTotalDistriGangChk = False
                                            End If
                                        End While

                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                        'Palani
                                        lHKforGangTotal = 0

                                        ''Grand OT
                                        If Lrowgangno < ds.Tables(2).Rows.Count Then
                                            If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString = "OT" Then
                                                lsheetRowNo = lsheetRowNo + 1
                                                sheetNo.Cells(lsheetRowNo, 1) = "Grand Total"
                                                sheetNo.Cells(lsheetRowNo, 1).font.bold = True
                                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString
                                                sheetNo.Cells(lsheetRowNo, 3).font.bold = True
                                                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 1, 1), sheetNo.Cells(lsheetRowNo + 1, TotalDays + 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                                lTotalDistriGangChk = True
                                                While lTotalDistriGangChk = True
                                                    lDistribdate = ds.Tables(2).Rows(Lrowgangno).Item("RDate").ToString
                                                    lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                                    lDaysCalc = lDaysCalc + 4
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                    lHKforGangTotal = lHKforGangTotal + ds.Tables(2).Rows(Lrowgangno).Item("TotalHkGang")
                                                    Lrowgangno = Lrowgangno + 1

                                                    If Lrowgangno < ds.Tables(2).Rows.Count Then
                                                        If ds.Tables(2).Rows(Lrowgangno).Item("HK").ToString() = "HK" Then
                                                            lTotalDistriGangChk = False
                                                        Else
                                                            lTotalDistriGangChk = True
                                                        End If
                                                    Else
                                                        lTotalDistriGangChk = False
                                                    End If
                                                End While
                                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, ToDate))
                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5).numberformat = "0.00"
                                                sheetNo.Cells(lsheetRowNo, TotalDays + 5) = lHKforGangTotal

                                                'Palani
                                                lHKforGangTotal = 0
                                            End If
                                        End If

                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

                                        'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                        'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                                        'sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32)).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft

                                        'sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
                                        'sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
                                        'sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"
                                        sheetNo.Cells(lsheetRowNo + 3, 3) = "Dibuat,"
                                        sheetNo.Cells(lsheetRowNo + 3, 20) = "Diperiksa,"
                                        sheetNo.Cells(lsheetRowNo + 3, 32) = "Disetujui,"

                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

                                    End If

                                End If

                            End While
                        End While


                    End If


                    sheetNo.Columns().AutoFit()
                    'sheetNo.Protect("RANNBSP@2010")
                End While


                sheet.Visible = False

            End If
        End If

        xlApp.Visible = True


        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Cursor = Cursors.Default
    End Sub

    Private Sub TeamPanenReport()
        Cursor = Cursors.WaitCursor

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim MaterialusageFlag As Boolean = True

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
        cmd.CommandText = "checkroll.CRWorkingDistributionReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Amonth", (cbMonth.SelectedIndex) + 1)
        cmd.Parameters.AddWithValue("@AYear", cbYear.Text)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "WorkingDistributionReport")

        Dim ReportDirectory As String = String.Empty
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx"
        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\WorkingDistribution_Template.xlsx")
        Else
            MsgBox("Material Usage report template missing.Please contact system administrator.")
            ' Cursor = Cursors.Arrow
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            ' Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP CheckRoll Reports")

        If Not di.Exists Then
            di.Create()
        End If

        Dim lTextmonth As String = String.Empty
        Dim objCommonBOl As New GlobalBOL

        lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

        lTextmonth = " WORKING DISTRIBUTION FOR " & lTextmonth & "(TEAM PANEN )"

        Dim StrPath As String = ""

        StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)

        ' NO RECORDS
        If ds.Tables(0).Rows.Count < 1 Then
            Dim TotalDays As Integer = 30
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells(8, 2) = lEstate
            sheet.Cells(2, 1).numberformat = "@"
            sheet.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
            sheet.Cells(4, 1) = lTextmonth
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(13, 1), sheet.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 1) = "Activity"
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 2)).Merge()
            sheet.Range(sheet.Cells(12, 1), sheet.Cells(13, 1)).Merge()

            sheet.Cells(12, 1).font.bold = True
            sheet.Cells(12, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 3) = "HK"
            sheet.Cells(12, 3).font.bold = True
            sheet.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(13, 3) = "OT"
            sheet.Cells(13, 3).font.bold = True
            sheet.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
            sheet.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
            sheet.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

            Dim lColumnCount As Integer
            lColumnCount = 4
            sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(13, 3), sheet.Cells(13, 35)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            FromDate = GlobalPPT.FiscalYearFromDate
            'Printing the Dates
            While TotalDays >= 0
                sheet.Cells(13, lColumnCount).numberformat = "@"
                sheet.Cells(13, lColumnCount) = Format(FromDate, "dd")
                sheet.Cells(13, lColumnCount).font.bold = True
                sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
                sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                FromDate = DateAdd(DateInterval.Day, 1, FromDate)
                lColumnCount = lColumnCount + 1
                TotalDays = TotalDays - 1
            End While

            sheet.Range(sheet.Cells(12, lColumnCount), sheet.Cells(13, lColumnCount)).Merge()
            sheet.Cells(12, lColumnCount) = "Total HK  & OT"
            sheet.Cells(12, lColumnCount).font.bold = True
            sheet.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

            sheet.Columns().AutoFit()
            sheet.Protect("RANNBSP@2010")
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            xlApp.Visible = True
            Cursor = Cursors.Default
            Exit Sub
        End If

        ' ### From Here ### 
        Dim LrowNo As Integer = 0
        Dim lsheetRowNo As Integer = 0
        Lrowgangno = 0
        LrowYOP = 0
        LrowYOPTotalRecord = 0
        LrowgangTotalRecord = 0

        If ds IsNot Nothing Then

            Dim GangTypeCount As Integer = 0

            'Total No Of Gangs
            GangTypeCount = ds.Tables(0).Rows.Count
            Dim TotalDays As Integer
            Dim lWorkingDistributionType As String
            Dim LtotalRecord As Integer
            LtotalRecord = ds.Tables(1).Rows.Count

            'TABLE (0) Returns the Gangs
            'Below If Condition Checking when no records
            If GangTypeCount < 1 Then
                MsgBox("No Records matching the given condition")
                Exit Sub
            End If

            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            Dim sheetNo As Excel.Worksheet

            'NEw Worksheet (Every Gang)
            While (GangTypeCount > 0 And LtotalRecord > 0)
                sheetNo = xlWorkBook.Worksheets.Add
                sheet.UsedRange.Copy(Type.Missing.Value)
                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

                sheet.Cells(2, 1).numberformat = "@"
                sheet.Cells(2, 1) = "Date :" & Format(Date.Now, "dd/MM/yy") & ""
                GangTypeCount = GangTypeCount - 1
                lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
                sheetNo.Cells(8, 2) = lEstate
                sheetNo.Cells(9, 2) = lWorkingDistributionType
                lWorkingDistributionType = lWorkingDistributionType.Replace("/", "")
                sheetNo.Name = " " & lWorkingDistributionType & " "
                lWorkingDistributionType = ds.Tables(1).Rows(LrowNo).Item("GangName").ToString()
                FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                sheetNo.Cells(4, 1) = lTextmonth

                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)

                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells(13, 1), sheetNo.Cells(13, TotalDays + 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(12, 1) = "Activity"
                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, 2)).Merge()
                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(13, 1)).Merge()
                sheetNo.Cells(12, 1).font.bold = True
                sheetNo.Cells(13, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(13, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(12, 3) = "HK"
                sheetNo.Cells(12, 3).font.bold = True
                sheetNo.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(13, 3) = "OT"
                sheetNo.Cells(13, 3).font.bold = True
                sheetNo.Cells(13, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(12, TotalDays + 12).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(12, TotalDays + 12).HorizontalAlignment = Excel.Constants.xlLeft
                sheetNo.Cells(12, 3).HorizontalAlignment = Excel.Constants.xlCenter
                sheetNo.Cells(13, 3).HorizontalAlignment = Excel.Constants.xlCenter

                Dim lColumnCount As Integer
                lColumnCount = 4
                sheetNo.Cells(13, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells(13, 3), sheetNo.Cells(13, TotalDays + 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells(11, TotalDays + 6), sheetNo.Cells(11, TotalDays + 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                'sheetNo.Range(sheetNo.Cells(12, TotalDays + 6), sheetNo.Cells(12, TotalDays + 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                'sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                'sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                ' For Printing Days Hear
                While TotalDays >= 0
                    sheetNo.Cells(13, lColumnCount).numberformat = "@"
                    sheetNo.Cells(13, lColumnCount) = Format(FromDate, "dd")
                    sheetNo.Cells(13, lColumnCount).font.bold = True
                    sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                    sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                    FromDate = DateAdd(DateInterval.Day, 1, FromDate)
                    lColumnCount = lColumnCount + 1
                    TotalDays = TotalDays - 1
                End While

                sheetNo.Range(sheetNo.Cells(12, lColumnCount), sheetNo.Cells(13, lColumnCount)).Merge()
                sheetNo.Cells(12, lColumnCount) = "Total HK  & OT"
                sheetNo.Cells(12, lColumnCount).font.bold = True
                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

                Dim lYOPtype As String
                lsheetRowNo = 12
                Dim lDistribdate As Date
                Dim lCheckBlock As String = String.Empty
                Dim lCheckBlockName As Boolean = False
                Dim lCheckYOPType As Boolean = False
                lGangTypecheck = True
                Dim lChksubblockDistrDate As Boolean = True
                lCheckBlockName = True

                If LtotalRecord > 0 Then

                    lCheckBlockName = False
                    lChksubblockDistrDate = False
                    lsheetRowNo = lsheetRowNo + 2

                    While lCheckYOPType = False And LtotalRecord > 0 And lGangTypecheck = True

                        lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
                        sheetNo.Cells(lsheetRowNo, 1) = "YOP :" & lYOPtype & ""
                        lsheetRowNo = lsheetRowNo + 1
                        lCheckBlockName = False
                        lChksubblockDistrDate = False

                        While (lCheckBlockName = False And LrowNo < ds.Tables(1).Rows.Count And lChksubblockDistrDate = False)
                            sheetNo.Cells(lsheetRowNo, 1) = "Harvesting"
                            FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                            sheetNo.Cells(lsheetRowNo, 2) = ""
                            sheetNo.Cells(lsheetRowNo, 3) = "HK"
                            lChksubblockDistrDate = True
                            lHKforblock = 0

                            While lChksubblockDistrDate = True And LrowNo < ds.Tables(1).Rows.Count
                                lDistribdate = ds.Tables(1).Rows(LrowNo).Item("RDate").ToString
                                lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                                lDaysCalc = lDaysCalc + 4
                                sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("HK")
                                sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                lHKforblock = lHKforblock + ds.Tables(1).Rows(LrowNo).Item("HK")
                                lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
                                LrowNo = LrowNo + 1
                                lTotalDistriChk = False
                                LtotalRecord = LtotalRecord - 1

                                If LtotalRecord > 0 Then
                                    If lYOPtype <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString Or _
                                        lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then

                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                        lDaysCalc = TotalDays + 5
                                        LrowNo = LrowNo - 1
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock

                                        lsheetRowNo = lsheetRowNo + 2
                                        lChksubblockDistrDate = False
                                        LrowNo = LrowNo + 1

                                        If lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then
                                            lCheckYOPType = True
                                            lGangTypecheck = False
                                            lCheckBlockName = True
                                            lChksubblockDistrDate = False
                                            lHKforblockTotal = 0
                                        ElseIf lYOPtype <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString Then
                                            lCheckBlockName = True
                                        Else
                                            lCheckBlockName = False
                                        End If
                                    Else
                                        lChksubblockDistrDate = True
                                    End If
                                Else
                                    TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
                                    lDaysCalc = TotalDays + 5
                                    'LrowNo = LrowNo - 1
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc).numberformat = "0.00"
                                    sheetNo.Cells(lsheetRowNo, lDaysCalc) = lHKforblock
                                End If

                            End While

                        End While

                        If LtotalRecord > 1 Then
                            If lYOPtype <> ds.Tables(1).Rows(LrowNo).Item("YOP").ToString And lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then
                                lCheckYOPType = True
                                lGangTypecheck = False
                                lChksubblockDistrDate = True
                            ElseIf lWorkingDistributionType <> ds.Tables(1).Rows(LrowNo).Item("GangName").ToString() Then
                                lCheckYOPType = True
                                lGangTypecheck = False
                                lChksubblockDistrDate = True
                                lsheetRowNo = lsheetRowNo + 2
                            Else
                                lCheckYOPType = False
                                lGangTypecheck = True
                                lChksubblockDistrDate = False
                            End If
                        Else
                            lChksubblockDistrDate = True
                        End If
                    End While
                End If


                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 3), sheetNo.Cells(lsheetRowNo + 3, 7)).Merge()
                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 20), sheetNo.Cells(lsheetRowNo + 3, 24)).Merge()
                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 3, 32), sheetNo.Cells(lsheetRowNo + 3, 35)).Merge()

                'sheetNo.Cells(lsheetRowNo + 3, 3) = "Approved By"
                'sheetNo.Cells(lsheetRowNo + 3, 20) = "Checked By"
                'sheetNo.Cells(lsheetRowNo + 3, 32) = "Created By"
                sheetNo.Cells(lsheetRowNo + 3, 3) = "Dibuat,"
                sheetNo.Cells(lsheetRowNo + 3, 20) = "Diperiksa,"
                sheetNo.Cells(lsheetRowNo + 3, 32) = "Disetujui,"

                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 3), sheetNo.Cells(lsheetRowNo + 7, 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 7, 20), sheetNo.Cells(lsheetRowNo + 7, 24)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells(lsheetRowNo + 37, 32), sheetNo.Cells(lsheetRowNo + 7, 35)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous

                sheetNo.Columns().AutoFit()
                'sheetNo.Protect("RANNBSP@2010")

            End While
            sheet.Visible = False
        End If

        xlApp.Visible = True

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Cursor = Cursors.Default
    End Sub

    Private Sub KillAllExcels()
        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            proc.Kill()
        Next
    End Sub

    Private Sub rdPanen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPanen.CheckedChanged
        If rdPanen.Checked = True Then
            RdRawat.Checked = False
            RdGeneral.Checked = False
        End If
    End Sub

    Private Sub RdRawat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdRawat.CheckedChanged
        If RdRawat.Checked = True Then
            rdPanen.Checked = False
            RdGeneral.Checked = False
        End If
    End Sub

    Private Sub RdGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdGeneral.CheckedChanged
        If RdGeneral.Checked = True Then
            rdPanen.Checked = False
            RdRawat.Checked = False
        End If
    End Sub
End Class