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

Public Class MaterialUsageRptFrm


    Dim FromDate As Date
    Dim ToDate As Date
    Dim lDivTypecheck As Boolean
    Dim lRepeatDate As Date
    Dim lRepeatStockCode As String
    Dim lRepeatDateCals As Decimal

    Private Sub MaterialUsageRptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        '  End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim fMsg As New ProgressingFrm
        Try
            fMsg.TopMost = True
            fMsg.Show()

            fMsg.lblTitle.Refresh()
            fMsg.lblTitle.Text = "Material Usage Report Processing . . ."
            fMsg.lblTitle.Refresh()

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
            cmd.CommandText = "checkroll.CRMaterialUsageReport_New"
            cmd.CommandTimeout = 1800
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
            cmd.Parameters.AddWithValue("@Amonth", (cbMonth.SelectedIndex) + 1)
            cmd.Parameters.AddWithValue("@AYear", cbYear.Text)

            Dim tblAdt As New SqlDataAdapter
            Dim ds As New DataSet
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "CRMaterialUsageReport")

            Dim ReportDirectory As String = String.Empty
            xlApp = New Excel.Application

            Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\MaterialUsage_Template.xlsx"
            If (File.Exists(TemPath)) Then
                xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\MaterialUsage_Template.xlsx")
            Else
                MsgBox("Material Usage report template missing.Please contact system administrator.")
                Exit Sub
            End If

            ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

            Dim sDirName As String
            sDirName = ReportDirectory + ":"
            Dim dDir As New DirectoryInfo(sDirName)

            If Not dDir.Exists Then
                MessageBox.Show("Report directory not found", "BSP")
                Exit Sub
            End If

            Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP CheckRoll Reports")
            ' Determine whether the directory exists.
            If Not di.Exists Then
                di.Create()
            End If

            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL

            lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

            lTextmonth = " Material Usage Report for " & lTextmonth

            Dim StrPath As String = ""

            StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

            Dim lEstate As String
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            lEstate = strArray(1)

            'TABLE (0) Returns the Division Name - DIVISI 01, DIVISI 02 etc ....
            'Below If Condition Checking when no records
            If ds.Tables(0).Rows.Count < 1 Then
                MsgBox("No Records matching the given condition")
                Exit Sub
            End If

            Dim intDivisionNameTotal As Int16
            intDivisionNameTotal = ds.Tables(0).Rows.Count

            Dim intDivisionRunningNo As Int16
            intDivisionRunningNo = 0

            Dim strDivisionName As String = ""

            Dim intTotalNoOfRecords As Integer = 0
            intTotalNoOfRecords = ds.Tables(1).Rows.Count

            Dim intRecRunningNo As Integer = 0
            Dim intExcelRunningNo As Integer = 0
            intExcelRunningNo = 0

            Dim intYOP As String = ""

            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

            Dim sheetNo As Excel.Worksheet

            'Following While Loop for Every Division should be printed in individual WorkSheet
            While (intDivisionRunningNo < intDivisionNameTotal)
                'Taking the division names from Table (0) - Do not change it to Table (1)
                strDivisionName = ds.Tables(0).Rows(intDivisionRunningNo).Item("DivName").ToString()

                sheetNo = xlWorkBook.Worksheets.Add
                sheet.UsedRange.Copy(Type.Missing.Value)
                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)
                sheetNo.Name = " " & strDivisionName & " "
                sheetNo.Cells(2, 1) = "Estate/Mill :" & lEstate & " "
                sheet.Cells(4, 1) = lTextmonth

                intExcelRunningNo = 9
                sheetNo.Cells(intExcelRunningNo, 1) = "DIV :" & strDivisionName & ""
                sheetNo.Cells(intExcelRunningNo, 1).font.bold = True

                'Following loop spins all the Division records (Table(0) Division) 
                While (ds.Tables(1).Rows(intRecRunningNo).Item("DivName").ToString() = strDivisionName)
                    intYOP = ds.Tables(1).Rows(intRecRunningNo).Item("YOP").ToString()

                    intExcelRunningNo += 1
                    sheetNo.Cells(intExcelRunningNo, 1) = "YOP :" & intYOP.ToString() & ""
                    sheetNo.Cells(intExcelRunningNo, 1).font.bold = True

                    'Do not delete the following line - bcas it is used in the header
                    FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                    intExcelRunningNo += 2
                    ' Printing the ******************* HEADER *******************
                    PrintHeader(intExcelRunningNo, sheetNo)

                    ' in header procedure fromdate variable is changed,so assigning value again
                    FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()
                    intExcelRunningNo += 2

                    'Dim lDistribdate As Date
                    'lDistribdate = ds.Tables(1).Rows(intRecRunningNo).Item("DistbDate").ToString

                    'Important : Do Not Increment the Record Number in Dataset
                    'intRecRunningNo += 1

                    While (ds.Tables(1).Rows(intRecRunningNo).Item("DivName").ToString() = strDivisionName _
                           And ds.Tables(1).Rows(intRecRunningNo).Item("YOP").ToString() = intYOP)

                        Dim lDistribdate As Date
                        lDistribdate = ds.Tables(1).Rows(intRecRunningNo).Item("DistbDate").ToString

                        Dim strCOACode As String = ds.Tables(1).Rows(intRecRunningNo).Item("COACode").ToString()
                        Dim strDescription As String = ds.Tables(1).Rows(intRecRunningNo).Item("Description").ToString()
                        Dim strStockcode As String = ds.Tables(1).Rows(intRecRunningNo).Item("Stockcode").ToString()
                        Dim strStockDesc As String = ds.Tables(1).Rows(intRecRunningNo).Item("StockDesc").ToString()
                        Dim strUOM As String = ds.Tables(1).Rows(intRecRunningNo).Item("UOM").ToString()
                        'Dim dblTotalUsageQty As Double = Val(ds.Tables(1).Rows(intRecRunningNo).Item("UsageQty").ToString())

                        'intRecRunningNo += 1
                        'Put a checking here, to see whether last record, if yes, next loop is not applicable

                        Dim blDuplicatesFound As Boolean = False
                        Dim dblTotalUsageQty As Double = 0

                        While (ds.Tables(1).Rows(intRecRunningNo).Item("DivName").ToString() = strDivisionName _
                           And ds.Tables(1).Rows(intRecRunningNo).Item("YOP").ToString() = intYOP _
                           And ds.Tables(1).Rows(intRecRunningNo).Item("COACode").ToString() = strCOACode _
                             And ds.Tables(1).Rows(intRecRunningNo).Item("DistbDate").ToString() = lDistribdate)

                            blDuplicatesFound = True

                            dblTotalUsageQty += Val(ds.Tables(1).Rows(intRecRunningNo).Item("UsageQty").ToString())

                            intRecRunningNo += 1
                            If intRecRunningNo > (intTotalNoOfRecords - 1) Then
                                Exit While
                            End If
                        End While

                        sheetNo.Cells(intExcelRunningNo, 1) = strCOACode
                        sheetNo.Cells(intExcelRunningNo, 2) = strDescription
                        sheetNo.Cells(intExcelRunningNo, 3) = strStockcode
                        sheetNo.Cells(intExcelRunningNo, 4) = strStockDesc
                        sheetNo.Cells(intExcelRunningNo, 5) = strUOM

                        Dim lDaysCalc As Integer
                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
                        lDaysCalc = lDaysCalc + 6
                        sheetNo.Cells(intExcelRunningNo, lDaysCalc).numberformat = "0.00"
                        sheetNo.Cells(intExcelRunningNo, lDaysCalc) = dblTotalUsageQty

                        'Grand Total
                        Dim intGTColumn As Int16
                        intGTColumn = DateDiff(DateInterval.Day, FromDate, ToDate) + 7
                        sheetNo.Cells(intExcelRunningNo, intGTColumn) = "=SUM(R" & intExcelRunningNo & "C6:R" & intExcelRunningNo & "C" & (intGTColumn - 1).ToString & ")"



                        intExcelRunningNo += 1

                        If blDuplicatesFound = False Then
                            intRecRunningNo += 1
                        End If
                        If intRecRunningNo > (intTotalNoOfRecords - 1) Then
                            Exit While
                        End If
                    End While

                    If intRecRunningNo > (intTotalNoOfRecords - 1) Then
                        Exit While
                    End If
                End While

                intExcelRunningNo += 3
                sheetNo.Cells(intExcelRunningNo, 2) = "Prepared By :"
                sheetNo.Cells(intExcelRunningNo, 6) = "Checked By :"
                sheetNo.Cells(intExcelRunningNo, 15) = "Approved By :"
                sheetNo.Cells(intExcelRunningNo, 2).font.bold = True
                sheetNo.Cells(intExcelRunningNo, 6).font.bold = True
                sheetNo.Cells(intExcelRunningNo, 15).font.bold = True
                intExcelRunningNo += 3

                sheetNo.Cells(intExcelRunningNo, 2) = "_________________"
                sheetNo.Cells(intExcelRunningNo, 6) = "_________________"
                sheetNo.Cells(intExcelRunningNo, 15) = "_________________"

                intDivisionRunningNo += 1

                sheetNo.Columns().AutoFit()
                sheetNo.Protect("RANNBSP@2010")

                sheet.Visible = False
            End While

            xlApp.Visible = True

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            ' put CultureInfo back to original
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
            fMsg.Close()
        End Try
    End Sub


    Private Sub PrintHeader(ByVal intExcelRunningNo As Integer, ByVal ewsTemp As Excel.Worksheet)
        Dim TotalDays As Integer
        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)

        ewsTemp.Range(ewsTemp.Cells(intExcelRunningNo, 1), ewsTemp.Cells(intExcelRunningNo, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Range(ewsTemp.Cells(intExcelRunningNo, 1), ewsTemp.Cells(intExcelRunningNo, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, 1) = "Account Code"
        ewsTemp.Cells(intExcelRunningNo, 1).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, 2) = "Account Descp"
        ewsTemp.Cells(intExcelRunningNo, 2).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, 3) = "Stock Code"
        ewsTemp.Cells(intExcelRunningNo, 3).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, 4) = "Material"
        ewsTemp.Cells(intExcelRunningNo, 4).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, 5) = "Unit"
        ewsTemp.Cells(intExcelRunningNo, 5).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, 5).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, 6) = "Usage"
        ewsTemp.Cells(intExcelRunningNo, 6).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, 6).HorizontalAlignment = Excel.Constants.xlCenter
        ewsTemp.Cells(intExcelRunningNo, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, TotalDays + 7).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, TotalDays + 7).HorizontalAlignment = Excel.Constants.xlLeft

        ewsTemp.Range(ewsTemp.Cells(intExcelRunningNo, 6), ewsTemp.Cells(intExcelRunningNo, TotalDays + 7)).Merge()

        intExcelRunningNo += 1

        Dim lColumnCount As Integer
        lColumnCount = 6
        ewsTemp.Cells(intExcelRunningNo, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Range(ewsTemp.Cells(intExcelRunningNo, 6), ewsTemp.Cells(intExcelRunningNo, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        'Following While Loop for Printing the Dates
        While TotalDays >= 0
            ewsTemp.Cells(intExcelRunningNo, lColumnCount).numberformat = "@"
            ewsTemp.Cells(intExcelRunningNo, lColumnCount) = Format(FromDate, "dd")
            ewsTemp.Cells(intExcelRunningNo, lColumnCount).font.bold = True
            ewsTemp.Cells(intExcelRunningNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
            FromDate = DateAdd(DateInterval.Day, 1, FromDate)
            lColumnCount = lColumnCount + 1
            TotalDays = TotalDays - 1
        End While

        ewsTemp.Cells(intExcelRunningNo, lColumnCount) = "Total"
        ewsTemp.Cells(intExcelRunningNo, lColumnCount).font.bold = True
        ewsTemp.Cells(intExcelRunningNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
        ewsTemp.Cells(intExcelRunningNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    End Sub


    'Private Sub btnReport_Click_Orig(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
    '    Dim fMsg As New ProgressingFrm
    '    fMsg.TopMost = True
    '    fMsg.Show()
    '    ' fMsg.lblMessage.Refresh()
    '    fMsg.lblTitle.Refresh()
    '    fMsg.lblTitle.Text = "Material Usage Report Processing . . ."
    '    fMsg.lblTitle.Refresh()



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


    '    Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim cmd1 As New SqlCommand
    '    Dim da As New SqlDataAdapter
    '    con = New SqlConnection(constr)

    '    con.Open()


    '    cmd.Connection = con
    '    cmd.CommandText = "checkroll.CRMaterialUsageReport_New"
    '    cmd.CommandTimeout = 1800
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
    '    cmd.Parameters.AddWithValue("@Amonth", (cbMonth.SelectedIndex) + 1)
    '    cmd.Parameters.AddWithValue("@AYear", cbYear.Text)


    '    Dim tblAdt As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(ds, "CRMaterialUsageReport")

    '    Dim ReportDirectory As String = String.Empty
    '    xlApp = New Excel.Application

    '    Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\MaterialUsage_Template.xlsx"
    '    '' "\Reports\Accounts\Excel\CashReconcilationReport_Template.xls"
    '    If (File.Exists(TemPath)) Then
    '        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\MaterialUsage_Template.xlsx")
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
    '    ' Determine whether the directory exists.
    '    If Not di.Exists Then
    '        di.Create()
    '    End If

    '    Dim lTextmonth As String = String.Empty
    '    Dim objCommonBOl As New GlobalBOL

    '    lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

    '    lTextmonth = " Material Usage Report for " & lTextmonth

    '    Dim StrPath As String = ""

    '    StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

    '    Dim lEstate As String
    '    Dim strArray As String()
    '    strArray = GlobalPPT.strEstateName.Split("-")
    '    lEstate = strArray(1)

    '    If ds.Tables(0).Rows.Count < 1 Then
    '        Dim sheet As Excel.Worksheet
    '        sheet = xlWorkBook.Sheets("Sheet1")
    '        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '        sheet.Cells(4, 1) = lTextmonth
    '        sheet.Cells(2, 1) = "Estate/Mill :" & lEstate

    '        sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 31)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Range(sheet.Cells(12, 1), sheet.Cells(12, 31)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 1) = "Account Code"
    '        sheet.Cells(12, 1).font.bold = True
    '        sheet.Cells(12, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 2) = "Account Descp"
    '        sheet.Cells(12, 2).font.bold = True
    '        sheet.Cells(12, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 3) = "Stock Code"
    '        sheet.Cells(12, 3).font.bold = True
    '        sheet.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 4) = "Material"
    '        sheet.Cells(12, 4).font.bold = True
    '        sheet.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 5) = "Unit"
    '        sheet.Cells(12, 5).font.bold = True
    '        sheet.Cells(12, 5).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 6) = "Usage"
    '        sheet.Cells(12, 6).font.bold = True
    '        sheet.Cells(12, 6).HorizontalAlignment = Excel.Constants.xlCenter '.xlLeft
    '        'sheet.Cells(12, 6).VerticalAlignment = Excel.Constants.xlCenter '.xlLeft
    '        sheet.Cells(12, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Cells(12, 32).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '        sheet.Range(sheet.Cells(12, 6), sheet.Cells(12, 31)).Merge()

    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If
    '        xlApp.Visible = True
    '        '  Cursor = Cursors.Arrow
    '        Cursor = Cursors.Default
    '        Exit Sub
    '    End If

    '    Dim LrowNo As Integer = 0
    '    Dim lsheetRowNo As Integer = 0
    '    ' Dim TotalRecordCount As Integer = 0

    '    If ds IsNot Nothing Then
    '        Dim DivTypeCount As Integer = 0
    '        DivTypeCount = ds.Tables(0).Rows.Count
    '        ' TotalRecordCount = ds.Tables(1).Rows.Count

    '        Dim TotalDays As Integer

    '        Dim lMaterialusageType As String
    '        Dim LtotalRecord As Integer
    '        LtotalRecord = ds.Tables(1).Rows.Count

    '        '    Dim lMaterialusageRow As Integer
    '        If DivTypeCount > 0 Then

    '            Dim sheet As Excel.Worksheet
    '            sheet = xlWorkBook.Sheets("Sheet1")
    '            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '            Dim sheetNo As Excel.Worksheet
    '            lDivTypecheck = False
    '            'Following While Loop for Every Division should be printed in individual WorkSheet
    '            While (DivTypeCount > 0 And lDivTypecheck = False)
    '                sheetNo = xlWorkBook.Worksheets.Add
    '                sheet.UsedRange.Copy(Type.Missing.Value)
    '                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

    '                If ds.Tables(1).Rows(LrowNo).Item("DivName").ToString() = "" Then
    '                    lMaterialusageType = "No Div"
    '                    sheetNo.Cells(9, 1) = "DIV :"
    '                    sheetNo.Cells(9, 1).font.bold = True
    '                    sheetNo.Cells(10, 1) = "YOP :"
    '                    sheetNo.Cells(10, 1).font.bold = True
    '                    lDivTypecheck = True
    '                Else
    '                    lMaterialusageType = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString()
    '                    sheetNo.Cells(9, 1) = "DIV :" & lMaterialusageType & ""
    '                    sheetNo.Cells(9, 1).font.bold = True
    '                    sheetNo.Cells(10, 1) = "YOP :" & (ds.Tables(1).Rows(LrowNo).Item("YOP").ToString()) & ""
    '                    sheetNo.Cells(10, 1).font.bold = True
    '                End If

    '                sheetNo.Name = " " & lMaterialusageType & " "
    '                sheetNo.Cells(2, 1) = "Estate/Mill :" & lEstate & " "

    '                FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                ToDate = ds.Tables(1).Rows(0).Item("ToDT").ToString()

    '                sheetNo.Cells(4, 1) = lTextmonth

    '                '  DivTypeCount = DivTypeCount - 1

    '                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)

    '                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Range(sheetNo.Cells(12, 1), sheetNo.Cells(12, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 1) = "Account Code"
    '                sheetNo.Cells(12, 1).font.bold = True
    '                sheetNo.Cells(12, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 2) = "Account Descp"
    '                sheetNo.Cells(12, 2).font.bold = True
    '                sheetNo.Cells(12, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 3) = "Stock Code"
    '                sheetNo.Cells(12, 3).font.bold = True
    '                sheetNo.Cells(12, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 4) = "Material"
    '                sheetNo.Cells(12, 4).font.bold = True
    '                sheetNo.Cells(12, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 5) = "Unit"
    '                sheetNo.Cells(12, 5).font.bold = True
    '                sheetNo.Cells(12, 5).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, 6) = "Usage"
    '                sheetNo.Cells(12, 6).font.bold = True
    '                sheetNo.Cells(12, 6).HorizontalAlignment = Excel.Constants.xlCenter
    '                sheetNo.Cells(12, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, TotalDays + 7).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(12, TotalDays + 7).HorizontalAlignment = Excel.Constants.xlLeft

    '                sheetNo.Range(sheetNo.Cells(12, 6), sheetNo.Cells(12, TotalDays + 7)).Merge()

    '                Dim lColumnCount As Integer
    '                lColumnCount = 6
    '                sheetNo.Cells(13, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Range(sheetNo.Cells(13, 6), sheetNo.Cells(13, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                '   sheetNo.Cells(12, TotalDays + 7).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

    '                'Following While Loop for Printing the Dates
    '                While TotalDays >= 0
    '                    sheetNo.Cells(13, lColumnCount).numberformat = "@"
    '                    sheetNo.Cells(13, lColumnCount) = Format(FromDate, "dd")
    '                    sheetNo.Cells(13, lColumnCount).font.bold = True
    '                    sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                    FromDate = DateAdd(DateInterval.Day, 1, FromDate)
    '                    lColumnCount = lColumnCount + 1
    '                    TotalDays = TotalDays - 1
    '                End While

    '                sheetNo.Cells(13, lColumnCount) = "Total"
    '                sheetNo.Cells(13, lColumnCount).font.bold = True
    '                sheetNo.Cells(12, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                sheetNo.Cells(13, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                Dim lDivtype As String
    '                Dim lYOPtype As String


    '                If lMaterialusageType <> "No Div" Then
    '                    lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString
    '                    lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                Else
    '                    lDivtype = ""
    '                End If

    '                lsheetRowNo = 14
    '                Dim lDistribdate As Date
    '                Dim lCheckAccCode As String = String.Empty
    '                Dim lcheckStockCode As String = String.Empty
    '                Dim lCheckaccountStockCode As Boolean = False

    '                Dim startIndex, EndIndex, lcount, TCount As New Integer
    '                Dim oRng As Excel.Range

    '                startIndex = lsheetRowNo

    '                If lMaterialusageType = "No Div" And LtotalRecord > 0 Then
    '                    'Following While Loop for Records don't have Division Names
    '                    While (LtotalRecord > 0 And lDivtype = "")
    '                        If lCheckAccCode <> ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() Or lCheckAccCode = "" Then
    '                            sheetNo.Cells(lsheetRowNo, 1) = ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() & " / " & ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                            sheetNo.Cells(lsheetRowNo, 2) = ds.Tables(1).Rows(LrowNo).Item("Description").ToString()
    '                        End If
    '                        sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString()
    '                        sheetNo.Cells(lsheetRowNo, 4) = ds.Tables(1).Rows(LrowNo).Item("StockDesc").ToString()
    '                        sheetNo.Cells(lsheetRowNo, 5) = ds.Tables(1).Rows(LrowNo).Item("UOM").ToString()

    '                        lCheckAccCode = ds.Tables(1).Rows(LrowNo).Item("COACode").ToString()
    '                        lcheckStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString()
    '                        Dim lDaysCalc As Integer

    '                        FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                        lCheckaccountStockCode = False
    '                        lRepeatDate = "01/01/1900"
    '                        Dim Ltotal As Decimal = 0

    '                        'Following While Loop for printing the Qty for the above COA COde & Supplier Code (DATE COLUMN)
    '                        While lCheckaccountStockCode = False
    '                            lDistribdate = ds.Tables(1).Rows(LrowNo).Item("DistbDate").ToString

    '                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                            lDaysCalc = lDaysCalc + 6
    '                            If lRepeatDate = lDistribdate And lRepeatStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString Then
    '                                lRepeatDateCals = lRepeatDateCals + ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                            Else
    '                                lRepeatDateCals = ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                            End If

    '                            lRepeatDate = ds.Tables(1).Rows(LrowNo).Item("DistbDate").ToString
    '                            lRepeatStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString


    '                            '   sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = lRepeatDateCals
    '                            EndIndex = TotalDays + 6

    '                            '  Ltotal = Ltotal + Val(ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString())

    '                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                            ' sheetNo.Cells(lsheetRowNo, (7 + TotalDays)) = Ltotal
    '                            oRng = sheetNo.Cells.Item(lsheetRowNo, TotalDays + 6)
    '                            oRng.Formula = "=SUM(F" & startIndex & ":AJ" & EndIndex & ")"
    '                            LrowNo = LrowNo + 1
    '                            LtotalRecord = LtotalRecord - 1

    '                            If LtotalRecord > 1 Then
    '                                If (lCheckAccCode <> ds.Tables(1).Rows(LrowNo).Item("COACode")) Or (lcheckStockCode <> ds.Tables(1).Rows(LrowNo).Item("Stockcode")) Then
    '                                    lCheckaccountStockCode = True
    '                                    lsheetRowNo = lsheetRowNo + 1
    '                                End If
    '                            Else
    '                                lCheckaccountStockCode = True
    '                            End If
    '                        End While

    '                        lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString
    '                    End While
    '                    ' DivTypeCount = DivTypeCount - 1
    '                ElseIf LtotalRecord > 0 Then
    '                    ' SAME DIVISION
    '                    'While (LtotalRecord > 0 And lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString)

    '                    While (LtotalRecord > 0 And lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString) ' And lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString)
    '                        lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString
    '                        lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString

    '                        If lCheckAccCode <> ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() Or lCheckAccCode = "" Then
    '                            sheetNo.Cells(lsheetRowNo, 1) = ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() & "/" & ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                            sheetNo.Cells(lsheetRowNo, 2) = ds.Tables(1).Rows(LrowNo).Item("Description").ToString()
    '                        End If
    '                        sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString()
    '                        sheetNo.Cells(lsheetRowNo, 4) = ds.Tables(1).Rows(LrowNo).Item("StockDesc").ToString()
    '                        sheetNo.Cells(lsheetRowNo, 5) = ds.Tables(1).Rows(LrowNo).Item("UOM").ToString()

    '                        lCheckAccCode = ds.Tables(1).Rows(LrowNo).Item("COACode").ToString()
    '                        lcheckStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString()
    '                        Dim lDaysCalc As Integer

    '                        FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                        lCheckaccountStockCode = False
    '                        lRepeatDate = "01/01/1900"
    '                        Dim Ltotal As Decimal = 0

    '                        'Following While Loop for printing the Qty for the above COA COde & Supplier Code (DATE COLUMN)
    '                        While lCheckaccountStockCode = False
    '                            lDistribdate = ds.Tables(1).Rows(LrowNo).Item("DistbDate").ToString
    '                            lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                            lDaysCalc = lDaysCalc + 6

    '                            If lRepeatDate = lDistribdate And lRepeatStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString Then
    '                                lRepeatDateCals = lRepeatDateCals + ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                            Else
    '                                lRepeatDateCals = ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                            End If

    '                            lRepeatDate = ds.Tables(1).Rows(LrowNo).Item("DistbDate").ToString
    '                            lRepeatStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString


    '                            sheetNo.Cells(lsheetRowNo, lDaysCalc) = lRepeatDateCals

    '                            Ltotal = Ltotal + Val(ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString())
    '                            LtotalRecord = LtotalRecord - 1

    '                            TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                            sheetNo.Cells(lsheetRowNo, (7 + TotalDays)) = Ltotal

    '                            LrowNo = LrowNo + 1

    '                            If LtotalRecord > 1 Then
    '                                If (lCheckAccCode <> ds.Tables(1).Rows(LrowNo).Item("COACode")) Or (lcheckStockCode <> ds.Tables(1).Rows(LrowNo).Item("Stockcode")) Then
    '                                    lCheckaccountStockCode = True
    '                                    lsheetRowNo = lsheetRowNo + 1
    '                                End If
    '                            Else
    '                                lCheckaccountStockCode = True
    '                            End If
    '                        End While

    '                        Dim lSameDivYOP As Boolean = True
    '                        If LrowNo = ds.Tables(1).Rows.Count Then
    '                            LrowNo = LrowNo - 2
    '                        End If

    '                        If LrowNo < 0 Then
    '                            lSameDivYOP = True
    '                            LrowNo = 0
    '                        Else
    '                            If lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString And lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString Then
    '                                lSameDivYOP = True
    '                            Else
    '                                lSameDivYOP = False
    '                            End If
    '                        End If

    '                        ' This IF condition takes care of Printing the YEar 
    '                        If (LtotalRecord > 0 And lSameDivYOP = False) Then

    '                            lsheetRowNo = lsheetRowNo + 5

    '                            If lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString Then

    '                                lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString
    '                                lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString

    '                                sheetNo.Cells(lsheetRowNo, 1) = "YOP :" & lYOPtype & ""
    '                                sheetNo.Cells(lsheetRowNo, 1).font.bold = True

    '                                TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                lsheetRowNo = lsheetRowNo + 2
    '                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 1), sheetNo.Cells(lsheetRowNo, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, 1) = "Account Code"
    '                                sheetNo.Cells(lsheetRowNo, 1).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo, 1).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, 2) = "Account Descp"
    '                                sheetNo.Cells(lsheetRowNo, 2).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo, 2).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, 3) = "Stock Code"
    '                                sheetNo.Cells(lsheetRowNo, 3).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo, 3).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, 4) = "Material"
    '                                sheetNo.Cells(lsheetRowNo, 4).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo, 4).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, 5) = "Unit"
    '                                sheetNo.Cells(lsheetRowNo, 5).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo, 5).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, 6) = "Usage"
    '                                sheetNo.Cells(lsheetRowNo, 6).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo, 6).HorizontalAlignment = Excel.Constants.xlCenter
    '                                sheetNo.Cells(lsheetRowNo, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous

    '                                sheetNo.Cells(lsheetRowNo, TotalDays + 7).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 6), sheetNo.Cells(lsheetRowNo, TotalDays + 7)).Merge()
    '                                lsheetRowNo = lsheetRowNo + 1
    '                                lColumnCount = 6
    '                                sheetNo.Cells(lsheetRowNo, 6).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Range(sheetNo.Cells(lsheetRowNo, 6), sheetNo.Cells(lsheetRowNo, TotalDays + 7)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '                                '   sheetNo.Cells(lsheetRowNo, TotalDays + 7).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                While TotalDays >= 0
    '                                    sheetNo.Cells(lsheetRowNo, lColumnCount).numberformat = "@"
    '                                    sheetNo.Cells(lsheetRowNo, lColumnCount) = Format(FromDate, "dd")
    '                                    sheetNo.Cells(lsheetRowNo, lColumnCount).font.bold = True
    '                                    sheetNo.Cells(lsheetRowNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                                    FromDate = DateAdd(DateInterval.Day, 1, FromDate)
    '                                    lColumnCount = lColumnCount + 1
    '                                    TotalDays = TotalDays - 1
    '                                End While
    '                                sheetNo.Cells(lsheetRowNo, lColumnCount) = "Total"
    '                                sheetNo.Cells(lsheetRowNo, lColumnCount).font.bold = True
    '                                sheetNo.Cells(lsheetRowNo - 1, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeLeft).linestyle = Excel.XlLineStyle.xlContinuous
    '                                sheetNo.Cells(lsheetRowNo, lColumnCount).borders(Excel.XlBordersIndex.xlEdgeRight).linestyle = Excel.XlLineStyle.xlContinuous

    '                                lsheetRowNo = lsheetRowNo + 1
    '                                Dim lFirstRecordcheck As Boolean = True
    '                                'While (LtotalRecord > 0 And lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString)
    '                                While (LtotalRecord > 0 And lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString) And lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                                    lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString

    '                                    If lCheckAccCode <> ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() Or lCheckAccCode = "" Or lFirstRecordcheck = True Then
    '                                        sheetNo.Cells(lsheetRowNo, 1) = ds.Tables(1).Rows(LrowNo).Item("COACode").ToString() & "/" & ds.Tables(1).Rows(LrowNo).Item("YOP").ToString
    '                                        sheetNo.Cells(lsheetRowNo, 2) = ds.Tables(1).Rows(LrowNo).Item("Description").ToString()
    '                                    End If
    '                                    lFirstRecordcheck = False
    '                                    sheetNo.Cells(lsheetRowNo, 3) = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString()
    '                                    sheetNo.Cells(lsheetRowNo, 4) = ds.Tables(1).Rows(LrowNo).Item("StockDesc").ToString()
    '                                    sheetNo.Cells(lsheetRowNo, 5) = ds.Tables(1).Rows(LrowNo).Item("UOM").ToString()

    '                                    lCheckAccCode = ds.Tables(1).Rows(LrowNo).Item("COACode").ToString()
    '                                    lcheckStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString()

    '                                    FromDate = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                                    lCheckaccountStockCode = False
    '                                    lRepeatDate = "01/01/1900"
    '                                    Ltotal = 0
    '                                    While lCheckaccountStockCode = False
    '                                        lDistribdate = ds.Tables(1).Rows(LrowNo).Item("DistbDate").ToString
    '                                        lDaysCalc = Math.Abs(DateDiff(DateInterval.Day, FromDate, lDistribdate))
    '                                        lDaysCalc = lDaysCalc + 6
    '                                        If lRepeatDate = lDistribdate And lRepeatStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString Then
    '                                            lRepeatDateCals = lRepeatDateCals + ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                                        Else
    '                                            lRepeatDateCals = ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                                        End If

    '                                        lRepeatDate = ds.Tables(1).Rows(LrowNo).Item("DistbDate").ToString
    '                                        lRepeatStockCode = ds.Tables(1).Rows(LrowNo).Item("Stockcode").ToString
    '                                        '   sheetNo.Cells(lsheetRowNo, lDaysCalc) = ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString()
    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = lRepeatDateCals
    '                                        Ltotal = Ltotal + Val(ds.Tables(1).Rows(LrowNo).Item("UsageQty").ToString())

    '                                        sheetNo.Cells(lsheetRowNo, lDaysCalc) = lRepeatDateCals
    '                                        TotalDays = DateDiff(DateInterval.Day, FromDate, ToDate)
    '                                        sheetNo.Cells(lsheetRowNo, (7 + TotalDays)) = Ltotal
    '                                        LrowNo = LrowNo + 1
    '                                        LtotalRecord = LtotalRecord - 1
    '                                        If LtotalRecord > 1 Then
    '                                            If (lCheckAccCode <> ds.Tables(1).Rows(LrowNo).Item("COACode")) Or (lcheckStockCode <> ds.Tables(1).Rows(LrowNo).Item("Stockcode")) Then
    '                                                lCheckaccountStockCode = True
    '                                                lsheetRowNo = lsheetRowNo + 1
    '                                            End If
    '                                        Else
    '                                            lCheckaccountStockCode = True
    '                                        End If
    '                                        If LrowNo = ds.Tables(1).Rows.Count Then
    '                                            LrowNo = LrowNo - 2
    '                                        End If

    '                                    End While

    '                                    'From here Send the Control to 'YEar Printing IF condtion
    '                                    ' following End while added by Palani
    '                                End While

    '                            End If
    '                        End If
    '                    End While
    '                End If

    '                sheetNo.Columns().AutoFit()
    '                lDivTypecheck = False

    '                'MsgBox(lDivtype & ds.Tables(1).Rows(LrowNo).Item("DivName").ToString)
    '                'MsgBox(lYOPtype & ds.Tables(1).Rows(LrowNo).Item("YOP").ToString)
    '                'MsgBox(LtotalRecord)
    '                '(LtotalRecord > 0 And lDivtype = ds.Tables(1).Rows(LrowNo).Item("DivName").ToString And lYOPtype = ds.Tables(1).Rows(LrowNo).Item("YOP").ToString)

    '                DivTypeCount = DivTypeCount - 1
    '            End While

    '            Dim intFooter As Integer
    '            intFooter = lsheetRowNo + 3

    '            sheetNo.Cells(intFooter, 2) = "Prepared By :"
    '            sheetNo.Cells(intFooter, 6) = "Checked By :"
    '            sheetNo.Cells(intFooter, 15) = "Approved By :"
    '            sheetNo.Cells(intFooter, 2).font.bold = True
    '            sheetNo.Cells(intFooter, 6).font.bold = True
    '            sheetNo.Cells(intFooter, 15).font.bold = True
    '            intFooter = intFooter + 3

    '            sheetNo.Cells(intFooter, 2) = "_________________"
    '            sheetNo.Cells(intFooter, 6) = "_________________"
    '            sheetNo.Cells(intFooter, 15) = "_________________"



    '            sheet.Visible = False
    '            xlApp.Visible = True


    '            If (File.Exists(StrPath)) Then
    '                File.Delete(StrPath)
    '                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '            Else
    '                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '            End If
    '        End If
    '    End If
    '    Cursor = Cursors.Default
    '    fMsg.Close()
    'End Sub


End Class