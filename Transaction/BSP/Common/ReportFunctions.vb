Imports System.Windows.Forms
Imports Common_PPT
Imports Common_BOL
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Data.SqlClient
Imports Store_PPT
Imports Store_BOL
Imports Accounts_BOL
Imports System.IO
Imports Production_BOL
Public Class ReportFunctions

    Public Sub AccountsCashReconcilation()

        ' Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        'WorkBooks
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet

        Dim xlAppDetail As Excel.Application
        Dim xlWorkBookDetail As Excel.Workbook
        Dim sheetDetail As Excel.Worksheet

        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlApp = New Excel.Application
        xlAppDetail = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\CashReconcilationReport_Template.xls"
        Dim TemPathDetail As String = Application.StartupPath & "\Reports\Accounts\Excel\DetailofLessExpenditure_Template.xls"


        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\CashReconcilationReport_Template.xls")
        Else
            MsgBox("Cash Reconcilation report template missing.Please contact system administrator.")
            Exit Sub
        End If

        If (File.Exists(TemPathDetail)) Then
            xlWorkBookDetail = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\DetailofLessExpenditure_Template.xls")
        Else
            MsgBox("Detail of Less Expenditure report template missing.Please contact system administrator.")
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

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Accounts Reports")
        If Not di.Exists Then
            di.Create()
        End If

        sheet = xlWorkBook.Sheets("Sheet1")
        ' sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        sheetDetail = xlWorkBookDetail.Sheets("Sheet1")
        ' sheetDetail = DirectCast(xlWorkBookDetail.Sheets(1), Excel.Worksheet)

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
        cmd.CommandText = "Accounts.CashReconcilationReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Amonth", GlobalPPT.IntLoginMonth)
        cmd.Parameters.AddWithValue("@AYear", GlobalPPT.intLoginYear)
        cmd.Parameters.AddWithValue("@CurrentActiveMonthYearID", GlobalPPT.strActMthYearID)
        'cmd.Parameters.AddWithValue("@CurrentActiveMonthYearID", "22r262")

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "CashReconcilationReport")
        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

        If ds.Tables(5).Rows(0).Item("PettyCount") = 1 Then
            If Not (MessageBox.Show("Petty cash Receipt & Payment Transaction not approved? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                Exit Sub
            End If
        End If


        If Not (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth And GlobalPPT.intLoginYear <= GlobalPPT.intActiveYear) Then
            lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
        ElseIf (GlobalPPT.IntActiveMonth = 1 And GlobalPPT.IntLoginMonth = 12) Then
            lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
        End If

        sheet.Cells(3, 9) = Format(Date.Today, "dd/MM/yyyy")
        sheet.Cells(7, 1) = "CASH RECONCILATION  " & lTextmonth & ""
        'sheet.Cells(7, 1).font = Color.Blue
        sheet.Cells(6, 7) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
        sheet.Cells(6, 9) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")

        ''for details Report
        sheetDetail.Cells(2, 11) = Format(Date.Today, "dd/MM/yyyy")
        sheetDetail.Cells(5, 1) = "DETAILS OF LESS EXPENDITURE ITEMS " & lTextmonth & ""
        sheetDetail.Cells(4, 9) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
        sheetDetail.Cells(4, 11) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")

        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        sheet.Cells(4, 2) = "Estate/Mill :" & lEstate & " "
        sheetDetail.Cells(3, 1) = "Estate/Mill :" & lEstate & " "

        Dim strMonthlyAccountsRptName As String = String.Empty
        strMonthlyAccountsRptName = "CASH RECONCILATION" & "_" & lTextmonth & ""

        Dim StrPath As String = "" & sDirName & "\BSP Accounts Reports\" & strMonthlyAccountsRptName & ".xls"

        Dim strMonthlyAccountsRptNameDetail As String = String.Empty
        strMonthlyAccountsRptNameDetail = "DETAILS OF LESS EXPENDITURE ITEMS" & "_" & lTextmonth & ""

        Dim StrPathDetail As String = "" & sDirName & "\BSP Accounts Reports\" & strMonthlyAccountsRptNameDetail & ".xls"


        If ds.Tables(0) IsNot Nothing And ds.Tables(1) IsNot Nothing And ds.Tables(2) IsNot Nothing And ds.Tables(3) IsNot Nothing And ds.Tables(4) IsNot Nothing Then
            Dim LCashOnHand As Decimal = 0
            Dim lAuthorizedFloat As Decimal = 0

            If ds.Tables(2).Rows.Count <> 0 Then
                sheet.Cells(9, 7) = ds.Tables(2).Rows(0).Item("AuthorizedFloat")
                LCashOnHand = ds.Tables(2).Rows(0).Item("CashOnHand")
                sheet.Cells(10, 7) = ds.Tables(2).Rows(0).Item("CashOnHand")
            End If






            Dim PCRCount As Integer
            PCRCount = ds.Tables(1).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 13
            Dim LrowNo As Integer = 0
            Dim lAmount As Decimal = 0
            lRowCount = lRowCount + 1

            While (PCRCount > 0)

                sheet.Cells(lRowCount, 2) = ds.Tables(1).Rows(LrowNo).Item("ReceiptNo")
                sheet.Cells(lRowCount, 3) = ds.Tables(1).Rows(LrowNo).Item("ReceiptDate")
                sheet.Cells(lRowCount, 4) = "Rp"
                sheet.Cells(lRowCount, 5) = ds.Tables(1).Rows(LrowNo).Item("Amount")
                lAmount = lAmount + ds.Tables(1).Rows(LrowNo).Item("Amount")
                PCRCount = PCRCount - 1
                lRowCount = lRowCount + 1
                LrowNo = LrowNo + 1

            End While
            sheet.Cells(lRowCount, 2) = "Amount"
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 6) = "Rp"
            sheet.Cells(lRowCount, 7) = lAmount
            lRowCount = lRowCount + 1
            sheet.Cells(lRowCount, 2) = "Available Cash"
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 6) = "Rp"
            Dim lAvailableCash As Decimal = 0
            lAvailableCash = lAmount + LCashOnHand
            sheet.Cells(lRowCount, 7) = lAvailableCash

            lRowCount = lRowCount + 1
            sheet.Cells(lRowCount, 2) = "Less Expenditure "
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 6) = "Rp"
            Dim lCalcCash As Decimal = 0
            If ds.Tables(3).Rows.Count <> 0 Then
                sheet.Cells(lRowCount, 7) = ds.Tables(3).Rows(0).Item("TotalPCPwithoutDiscrepancyDescp")

                lCalcCash = lAvailableCash - Val(ds.Tables(3).Rows(0).Item("TotalPCPwithoutDiscrepancyDescp"))
            End If


            lRowCount = lRowCount + 1
            sheet.Cells(lRowCount, 2) = "Calculated Cash on Hand"
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 6) = "Rp"

            sheet.Cells(lRowCount, 7) = lCalcCash

            lRowCount = lRowCount + 3

            sheet.Cells(lRowCount, 2) = "Difference"
            sheet.Cells(lRowCount, 2).font.bold = True

            lRowCount = lRowCount + 1
            sheet.Cells(lRowCount, 2) = "Any Disreprancy Explanation"
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 6) = "Rp"

            sheet.Cells(lRowCount, 7) = ds.Tables(4).Rows(0).Item("DiscrpDescpAmount")

            lRowCount = lRowCount + 1
            sheet.Cells(lRowCount, 2) = "Actual"
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 6) = "Rp"
            Dim lActualCash As Decimal = 0
            lActualCash = lCalcCash - Val(ds.Tables(4).Rows(0).Item("DiscrpDescpAmount"))
            sheet.Cells(lRowCount, 7) = lActualCash

            '   lRowCount = lRowCount + 5
            lRowCount = lRowCount + 3

            sheet.Cells(lRowCount, 2) = "Prepared By :"
            sheet.Cells(lRowCount, 4) = "Checked By :"
            sheet.Cells(lRowCount, 8) = "Authorized By :"
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 4).font.bold = True
            sheet.Cells(lRowCount, 8).font.bold = True
            lRowCount = lRowCount + 1

            sheet.Cells(lRowCount, 2) = "_________________"
            sheet.Cells(lRowCount, 4) = "_________________"
            sheet.Cells(lRowCount, 8) = "_________________"

            lRowCount = lRowCount + 4
            sheet.Cells(lRowCount, 7) = "Acknowledged By :"
            sheet.Cells(lRowCount, 7).font.bold = True
            sheet.Cells(lRowCount + 1, 7) = "__________________"
            lRowCount = lRowCount + 3
            sheet.Range(sheet.Cells(9, 2), sheet.Cells(9, 10)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(lRowCount, 2), sheet.Cells(lRowCount + 1, 10)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(9, 1), sheet.Cells(lRowCount - 1, 1)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(9, 10), sheet.Cells(lRowCount - 1, 10)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous



            Dim lRowcountDetail As Integer
            lRowcountDetail = 13

            sheetDetail.Cells(lRowcountDetail, 2) = "Saldo petty cash"
            sheetDetail.Cells(lRowcountDetail, 2).font.bold = True
            'sheetDetail.Range(sheetDetail.Cells(lRowcountDetail, 2), sheetDetail.Cells(lRowcountDetail, 4)).Merge()
            'sheetDetail.Range(sheetDetail.Cells(lRowcountDetail, 5), sheetDetail.Cells(lRowcountDetail, 7)).Merge()
            sheetDetail.Cells(lRowcountDetail, 10) = LCashOnHand
            sheetDetail.Cells(lRowcountDetail, 12) = LCashOnHand
            lRowcountDetail = lRowcountDetail + 1
            sheetDetail.Cells(lRowcountDetail, 2) = "Penerimaan P/Cash dari Central"
            sheetDetail.Cells(lRowcountDetail, 2).font.bold = True
            '  sheetDetail.Range(sheetDetail.Cells(lRowcountDetail, 2), sheetDetail.Cells(lRowcountDetail, 4)).Merge()
            ' sheetDetail.Cells(lRowcountDetail, 3) = "P/Cash"
            ' sheetDetail.Range(sheetDetail.Cells(lRowcountDetail, 5), sheetDetail.Cells(lRowcountDetail, 7)).Merge()
            lRowcountDetail = lRowcountDetail + 1
            PCRCount = ds.Tables(1).Rows.Count
            Dim LrowNoDetal As Integer = 0
            Dim lAmountDetail As Decimal = 0
            Dim lAmountCalc As Decimal = 0

            lAmountDetail = LCashOnHand
            While (PCRCount > 0)

                sheetDetail.Cells(lRowcountDetail, 1) = ds.Tables(1).Rows(LrowNoDetal).Item("ReceiptDate")
                sheetDetail.Cells(lRowcountDetail, 2) = ds.Tables(1).Rows(LrowNoDetal).Item("ReceiptDescp")
                sheetDetail.Cells(lRowcountDetail, 3) = "P/Cash"
                sheetDetail.Cells(lRowcountDetail, 4) = ds.Tables(1).Rows(LrowNoDetal).Item("ReceiptNo")
                sheetDetail.Cells(lRowcountDetail, 5) = ds.Tables(6).Rows(0).Item("PCashReceiptAccountType")
                sheetDetail.Cells(lRowcountDetail, 10) = ds.Tables(1).Rows(LrowNoDetal).Item("Amount")
                lAmountDetail = lAmountDetail + ds.Tables(1).Rows(LrowNoDetal).Item("Amount")
                lAmountCalc = lAmountDetail
                sheetDetail.Cells(lRowcountDetail, 12) = lAmountDetail

                PCRCount = PCRCount - 1
                lRowcountDetail = lRowcountDetail + 1
                LrowNoDetal = LrowNoDetal + 1
            End While



            Dim PCPCount As Integer
            PCPCount = ds.Tables(0).Rows.Count
            '  lRowcountDetail = lRowcountDetail + 2
            Dim LrowNoPCP As Integer = 0
            Dim lPCPAmount As Decimal = 0
            LrowNoDetal = 0
            While (PCPCount > 0)

                sheetDetail.Cells(lRowcountDetail, 1) = ds.Tables(0).Rows(LrowNoDetal).Item("VoucherDate")
                sheetDetail.Cells(lRowcountDetail, 2) = ds.Tables(0).Rows(LrowNoDetal).Item("PayDescp")
                sheetDetail.Cells(lRowcountDetail, 3) = ds.Tables(0).Rows(LrowNoDetal).Item("PaidTo")
                sheetDetail.Cells(lRowcountDetail, 4) = ds.Tables(0).Rows(LrowNoDetal).Item("VoucherNo")
                sheetDetail.Cells(lRowcountDetail, 5) = ds.Tables(0).Rows(LrowNoDetal).Item("AccountCode")
                sheetDetail.Cells(lRowcountDetail, 6) = ds.Tables(0).Rows(LrowNoDetal).Item("T0")
                sheetDetail.Cells(lRowcountDetail, 7) = ds.Tables(0).Rows(LrowNoDetal).Item("T1")
                sheetDetail.Cells(lRowcountDetail, 8) = ds.Tables(0).Rows(LrowNoDetal).Item("T2")
                sheetDetail.Cells(lRowcountDetail, 9) = ds.Tables(0).Rows(LrowNoDetal).Item("T3")

                sheetDetail.Cells(lRowcountDetail, 11) = ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                lAmountDetail = lAmountDetail - ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                sheetDetail.Cells(lRowcountDetail, 12) = lAmountDetail
                lPCPAmount = lPCPAmount + ds.Tables(0).Rows(LrowNoDetal).Item("Amount")

                PCPCount = PCPCount - 1
                lRowcountDetail = lRowcountDetail + 1
                LrowNoDetal = LrowNoDetal + 1
            End While

            lRowcountDetail = lRowcountDetail + 1

            sheetDetail.Cells(lRowcountDetail, 2) = "Total"
            sheetDetail.Cells(lRowcountDetail, 2).font.bold = True
            sheetDetail.Cells(lRowcountDetail, 10) = lAmountCalc
            sheetDetail.Cells(lRowcountDetail, 10).font.bold = True
            sheetDetail.Cells(lRowcountDetail, 11) = lPCPAmount
            sheetDetail.Cells(lRowcountDetail, 11).font.bold = True
            sheetDetail.Cells(lRowcountDetail, 12) = lAmountCalc - lPCPAmount
            sheetDetail.Cells(lRowcountDetail, 12).font.bold = True



            sheetDetail.Protect("RANNBSP@2010")
            '   sheetDetail.Unprotect("RANNBSP@2010")
            'sheetDetail.password.Protect("RANNBSP@2010")

            If (File.Exists(StrPathDetail)) Then
                File.Delete(StrPathDetail)
                xlWorkBookDetail.SaveAs(StrPathDetail, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBookDetail.SaveAs(StrPathDetail, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            xlApp.StatusBar = True
            xlApp.Visible = True
            sheet.Protect("RANNBSP@2010")
            '  sheet.Unprotect("RANNBSP@2010")
            ' sheet.password.Protect = "RANNBSP@2010"
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            '     sheetDetail.ProtectionMode = True
            '

        End If
        ''  Cursor = Cursors.Arrow
        'Dim xlApp1 As Excel.Application
        'Dim x1Book As Excel.Workbook
        'Dim sheet2 As Excel.Worksheet
        ''  sheet2 = xlWorkBook.Sheets("Sheet1")
        ''  Dim StrPathDetail1 As String = "" & sDirName & "\BSP Accounts Reports\ACCOUNTS LEDGER_COM_OCT-2009  (PROVISIONAL).xls"
        ''  b = StrPathDetail1

        'xlApp1 = CreateObject("Excel.Application")
        'x1Book = xlApp.Workbooks.Open("" & sDirName & "\BSP Accounts Reports\ACCOUNTS LEDGER_COM_OCT-2009  (PROVISIONAL).xls")
        'sheet2 = x1Book.Worksheets(1)
        'sheet2.Unprotect("RANNBSP@2010")

        'ACCOUNTS LEDGER_COM_OCT-2009  (PROVISIONAL)

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Public Sub LedgerReport(ByVal modid As Integer, ByVal AMonth As Integer, ByVal AYear As Integer, ByVal strFiscalYearToDate As String, ByVal strFiscalYearFromDate As String)

        Dim objAccountBOL As New AccountsMonthendclosingBOL
        '  Dim objAccountDAL As New Accounts_DAL.AccountsMonthEndProcessingDAL

        'Saravana : 11 aug 2010 : This Task monitor checking is done in VechileLedgerFrm under btnreport click.....

        'Dim dsCheck As New DataSet

        'dsCheck = AccountsMonthendclosingBOL.LedgerReportCheck(modid)

        'If modid = 6 Then
        '    If dsCheck.Tables(0).Rows(0).Item("AccountCount").ToString = "N" Then
        '        If Not (MessageBox.Show("Store monthly Processing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        '            Exit Sub
        '        End If
        '    End If
        'ElseIf modid = 2 Then
        '    If dsCheck.Tables(0).Rows(0).Item("Complete").ToString = "N" Then
        '        If Not (MessageBox.Show("Store monthly Processing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

        '            Exit Sub
        '        End If
        '    End If
        'Else
        '    If dsCheck.Tables(0).Rows(0).Item("Complete").ToString = "N" Then
        '        If Not (MessageBox.Show("Vehicle monthly Processing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        '            Exit Sub
        '        End If


        '    End If

        'End If

        ' Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim LedgerFlag As Boolean = True



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
        cmd.CommandText = "Accounts.LedgerReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Amonth", AMonth)
        cmd.Parameters.AddWithValue("@AYear", AYear)
        cmd.Parameters.AddWithValue("@Modid", modid)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "LedgerReport")

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim ReportDirectory As String = String.Empty
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template.xls"

        ''For Memory Exception or Old format or invalid type library; Error Handling.
        ''------*------
        'xlApp.Visible = False
        'xlApp.UserControl = False
        'Dim oBooks As Object = xlApp.Workbooks
        'Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")
        'oBooks.GetType().InvokeMember("Add", Reflection.BindingFlags.InvokeMethod, Nothing, oBooks, Nothing, ci)
        ''------*------
        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template.xls")
        Else
            MsgBox("Ledger report template missing.Please contact system administrator.")
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

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Accounts Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        Dim LmodName As String = String.Empty
        If modid = 6 Then
            LmodName = "ACCOUNTS LEDGER"
        ElseIf modid = 3 Then
            LmodName = "VEHICLE LEDGER"
        ElseIf modid = 2 Then
            LmodName = "STORE LEDGER"
        ElseIf modid = 1 Then
            LmodName = "CHECKROLL LEDGER"
        End If
        Dim lTextmonth As String = String.Empty
        Dim objCommonBOl As New GlobalBOL

        lTextmonth = objCommonBOl.PMonthName(AMonth, AYear, GlobalPPT.strLang)

        If AMonth = GlobalPPT.IntActiveMonth Then
            lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
            'ElseIf (GlobalPPT.IntActiveMonth = 1 And GlobalPPT.IntLoginMonth = 12) Then
            '    lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
        End If

        Dim lEstAbbr As String = ""
        If ds.Tables(1).Rows.Count <> 0 Then
            lEstAbbr = ds.Tables(1).Rows(0).Item("Abbrevation").ToString()
        End If
        Dim StrPath As String = ""
        If lEstAbbr <> "" Then
            StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lEstAbbr & "_" & lTextmonth & ".xls"
        Else
            StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lTextmonth & ".xls"
        End If
        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)

        If ds.Tables(0).Rows.Count = 0 Then
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells(4, 1) = "" & LmodName & " " & lTextmonth & ""
            sheet.Cells(2, 1) = "Estate/Mill :" & lEstate
            sheet.Cells(2, 14) = strFiscalYearFromDate 'Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
            sheet.Cells(2, 16) = strFiscalYearToDate 'Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
            'edit
            sheet.Protect("RANNBSP@2010")
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            xlApp.Visible = True
            '  Cursor = Cursors.Arrow
            Exit Sub
        End If
        Dim LrowNoLedger As Integer = 0
        If ds IsNot Nothing Then
            Dim CountLedgerType As Integer = 0
            CountLedgerType = ds.Tables(0).Rows.Count
            Dim LedgerCount As Integer = 0
            LedgerCount = ds.Tables(1).Rows.Count

            Dim lLedgerType As String
            Dim lLedgerRow As Integer
            If CountLedgerType > 0 Then

                Dim sheet As Excel.Worksheet
                sheet = xlWorkBook.Sheets("Sheet1")
                sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
                Dim sheetNo As Excel.Worksheet
                While (CountLedgerType > 0)
                    sheetNo = xlWorkBook.Worksheets.Add
                    sheet.UsedRange.Copy(Type.Missing.Value)
                    sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

                    lLedgerType = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
                    lLedgerRow = CountLedgerType - 1
                    If lEstAbbr <> "" Then
                        sheetNo.Name = " " & lEstAbbr & "_" & lLedgerType & " "
                    Else
                        sheetNo.Name = " " & lLedgerType & " "
                    End If

                    sheetNo.Cells(2, 1) = "Estate/Mill :" & lEstate & " "


                    sheetNo.Cells(2, 14) = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    sheetNo.Cells(2, 16) = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                    sheetNo.Cells(4, 1) = "" & LmodName & " " & lTextmonth & ""


                    Dim lRowCountLedger As Integer
                    lRowCountLedger = 10



                    sheetNo.Cells(9, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
                    sheetNo.Cells(9, 5) = "Journal Consolidation"
                    sheetNo.Cells(9, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
                    'sheetNo.Cells(9, 9) = lLedgerType

                    If modid = 1 Or modid = 2 Or modid = 3 Then
                        sheetNo.Cells(9, 9) = "GJ"
                    Else
                        sheetNo.Cells(9, 9) = lLedgerType
                    End If

                    sheetNo.Cells(9, 16) = "1"
                    LedgerFlag = True

                    While (LedgerCount > 0 And LedgerFlag = True)
                        sheetNo.Cells(lRowCountLedger, 1).NumberFormat = "@"
                        sheetNo.Cells(lRowCountLedger, 1) = ds.Tables(1).Rows(LrowNoLedger).Item("oldAccountCode")
                        sheetNo.Cells(lRowCountLedger, 2).NumberFormat = "@"
                        sheetNo.Cells(lRowCountLedger, 2) = ds.Tables(1).Rows(LrowNoLedger).Item("AccountCode")
                        sheetNo.Cells(lRowCountLedger, 3).NumberFormat = "@"
                        sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")

                        'sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference")
                        If modid = 2 Then
                            If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-ITNIN") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-ITNIN", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-ITNOUT") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-ITNOUT", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-SIV") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-SIV", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-IDN") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-IDN", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-STA") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-STA", "GJ")
                            End If
                        ElseIf modid = 3 Then
                            If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("VehicleDistribution") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("VehicleDistribution", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("WORKSHOP") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("WORKSHOP", "GJ")
                            End If
                        ElseIf modid = 1 Then
                            ' Check whether this condition really required here - "GJ = GENERAL JOURNAL" ?
                            If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-HARVESTING") Then
                                sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-HARVESTING", "GJ")
                            End If
                        Else
                            sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference")
                        End If


                        If modid = 3 Then
                            sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Descp")
                        Else
                            sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Description")
                        End If

                        'sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Description")
                        sheetNo.Cells(lRowCountLedger, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
                        sheetNo.Cells(lRowCountLedger, 7) = ds.Tables(1).Rows(LrowNoLedger).Item("Deb")
                        sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")

                        If modid = 1 Or modid = 2 Or modid = 3 Then
                            sheetNo.Cells(lRowCountLedger, 9) = "GJ"
                        Else
                            sheetNo.Cells(lRowCountLedger, 9) = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
                        End If


                        ' sheetNo.Cells(lRowCountLedger, 3).numberformat = "@"

                        sheetNo.Cells(lRowCountLedger, 10) = "" & GlobalPPT.strUserName & ""
                        sheetNo.Cells(lRowCountLedger, 11) = ds.Tables(1).Rows(LrowNoLedger).Item("T0")
                        sheetNo.Cells(lRowCountLedger, 12) = ds.Tables(1).Rows(LrowNoLedger).Item("T1")
                        sheetNo.Cells(lRowCountLedger, 13) = ds.Tables(1).Rows(LrowNoLedger).Item("T2")
                        sheetNo.Cells(lRowCountLedger, 14) = ds.Tables(1).Rows(LrowNoLedger).Item("T3")
                        sheetNo.Cells(lRowCountLedger, 15) = ds.Tables(1).Rows(LrowNoLedger).Item("T4")
                        sheetNo.Cells(lRowCountLedger, 16) = "2"
                        LedgerCount = LedgerCount - 1
                        lRowCountLedger = lRowCountLedger + 1
                        LrowNoLedger = LrowNoLedger + 1

                        If LedgerCount > 1 Then
                            If lLedgerType <> ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType") Then
                                LedgerFlag = False
                            End If
                        End If

                    End While

                    'sheetNo.Range("A1").EntireColumn.ColumnWidth = 13
                    'sheetNo.Range("B1").EntireColumn.ColumnWidth = 13
                    'sheetNo.Range("C1").EntireColumn.ColumnWidth = 12
                    'sheetNo.Range("D1").EntireColumn.ColumnWidth = 15
                    'sheetNo.Range("E1").EntireColumn.ColumnWidth = 35
                    'sheetNo.Range("F1").EntireColumn.ColumnWidth = 13
                    'sheetNo.Range("G1").EntireColumn.ColumnWidth = 16
                    'sheetNo.Range("H1").EntireColumn.ColumnWidth = 15
                    'sheetNo.Range("I1").EntireColumn.ColumnWidth = 15
                    'sheetNo.Range("J1").EntireColumn.ColumnWidth = 15
                    'sheetNo.Range("K1").EntireColumn.ColumnWidth = 10
                    'sheetNo.Range("L1").EntireColumn.ColumnWidth = 10
                    'sheetNo.Range("M1").EntireColumn.ColumnWidth = 10
                    'sheetNo.Range("N1").EntireColumn.ColumnWidth = 10
                    'sheetNo.Range("O1").EntireColumn.ColumnWidth = 10
                    'sheetNo.Range("P1").EntireColumn.ColumnWidth = 15


                    sheetNo.Columns().AutoFit()


                    CountLedgerType = CountLedgerType - 1
                    sheetNo.Protect("RANNBSP@2010")

                End While
                sheet.Visible = False
                xlApp.Visible = True


                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If


            End If
        End If
        '  Cursor = Cursors.Arrow

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

    Public Sub LedgerReport_Checkroll(ByVal modid As Integer, ByVal AMonth As Integer, ByVal AYear As Integer, ByVal strFiscalYearToDate As String, ByVal strFiscalYearFromDate As String)
        Dim objAccountBOL As New AccountsMonthendclosingBOL

        ' Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim LedgerFlag As Boolean = True

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
        cmd.CommandText = "Accounts.LedgerReport_Checkroll"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Amonth", AMonth)
        cmd.Parameters.AddWithValue("@AYear", AYear)
        cmd.Parameters.AddWithValue("@Modid", modid)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "LedgerReport")


        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim ReportDirectory As String = String.Empty
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template_Checkroll.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template_Checkroll.xls")
        Else
            MsgBox("Ledger report template missing.Please contact system administrator.")
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

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Accounts Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        'The following condtion was n ot required here, It was kept for future enhancements
        Dim LmodName As String = String.Empty
        If modid = 6 Then
            LmodName = "ACCOUNTS LEDGER"
        ElseIf modid = 3 Then
            LmodName = "VEHICLE LEDGER"
        ElseIf modid = 2 Then
            LmodName = "STORE LEDGER"
        ElseIf modid = 1 Then
            LmodName = "CHECKROLL LEDGER"
        End If
        Dim lTextmonth As String = String.Empty
        Dim objCommonBOl As New GlobalBOL

        lTextmonth = objCommonBOl.PMonthName(AMonth, AYear, GlobalPPT.strLang)

        If AMonth = GlobalPPT.IntActiveMonth Then
            lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
        End If



        Dim lEstAbbr As String = ""
        If ds.Tables(1).Rows.Count <> 0 Then
            lEstAbbr = ds.Tables(1).Rows(0).Item("Abbrevation").ToString()
        End If
        Dim StrPath As String = ""
        If lEstAbbr <> "" Then
            StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lEstAbbr & "_" & lTextmonth & ".xls"
        Else
            StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lTextmonth & ".xls"
        End If
        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)

        'Table 0 is always retun one record - CHECKROLL JOURNAL, so changing the checking for table 1 
        'If ds.Tables(0).Rows.Count = 0 Then
        If ds.Tables(1).Rows.Count = 0 Then
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells(3, 5) = "" & LmodName & " " & lTextmonth & ""
            sheet.Cells(2, 1) = "Estate/Mill :" & lEstate
            sheet.Cells(2, 10) = strFiscalYearFromDate 'Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
            sheet.Cells(2, 12) = strFiscalYearToDate 'Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            xlApp.Visible = True
            Exit Sub
        End If

        Dim LrowNoLedger As Integer = 0
        If ds IsNot Nothing Then
            Dim CountLedgerType As Integer = 0
            CountLedgerType = ds.Tables(0).Rows.Count
            Dim LedgerCount As Integer = 0
            LedgerCount = ds.Tables(1).Rows.Count

            Dim lLedgerType As String
            Dim lLedgerRow As Integer
            If CountLedgerType > 0 Then

                Dim sheet As Excel.Worksheet
                sheet = xlWorkBook.Sheets("Sheet1")
                sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
                Dim sheetNo As Excel.Worksheet

                While (CountLedgerType > 0)
                    sheetNo = xlWorkBook.Worksheets.Add
                    sheet.UsedRange.Copy(Type.Missing.Value)
                    sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

                    'palani
                    'lLedgerType = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
                    lLedgerType = ds.Tables(0).Rows(LrowNoLedger).Item("WSheetTitle").ToString()

                    lLedgerRow = CountLedgerType - 1
                    If lEstAbbr <> "" Then
                        'sheetNo.Name = " " & lEstAbbr & "_" & lLedgerType & " "
                        sheetNo.Name = " " & lEstAbbr & " "
                    Else
                        sheetNo.Name = " " & lLedgerType & " "
                    End If

                    sheetNo.Cells(2, 1) = "Estate/Mill :" & lEstate & " "


                    'sheetNo.Cells(2, 10) = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    'sheetNo.Cells(2, 12) = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                    'sheetNo.Cells(3, 5) = "" & LmodName & " " & lTextmonth & ""


                    'sheetNo.Cells(6, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
                    'sheetNo.Cells(6, 5) = "Journal Consolidation"
                    'sheetNo.Cells(6, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""


                    'If modid = 1 Or modid = 2 Or modid = 3 Then
                    '    sheetNo.Cells(6, 9) = "GJ"
                    'Else
                    '    sheetNo.Cells(6, 9) = lLedgerType
                    'End If

                    'sheetNo.Cells(6, 16) = "1"

                    sheetNo.Cells(2, 9) = ds.Tables(1).Rows(0).Item("FromDT").ToString()
                    sheetNo.Cells(2, 19) = ds.Tables(1).Rows(0).Item("ToDT").ToString()

                    sheetNo.Cells(3, 4) = "" & LmodName & " " & lTextmonth & ""


                    sheetNo.Cells(6, 2) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
                    sheetNo.Cells(6, 4) = "Journal Consolidation"
                    sheetNo.Cells(6, 5) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""


                    If modid = 1 Or modid = 2 Or modid = 3 Then
                        sheetNo.Cells(6, 8) = "GJ"
                    Else
                        sheetNo.Cells(6, 8) = lLedgerType
                    End If

                    sheetNo.Cells(6, 15) = "1"

                    LedgerFlag = True

                    Dim lRowCountLedger As Integer
                    lRowCountLedger = 7

                    While (LedgerCount > 0 And LedgerFlag = True)

                        sheetNo.Cells(lRowCountLedger, 1).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 1).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 1).NumberFormat = "@"
                        sheetNo.Cells(lRowCountLedger, 1) = ds.Tables(1).Rows(LrowNoLedger).Item("oldAccountCode")
                        'sheetNo.Cells(lRowCountLedger, 2).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 2).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 2).NumberFormat = "@"
                        'sheetNo.Cells(lRowCountLedger, 2) = "" 'ds.Tables(1).Rows(LrowNoLedger).Item("AccountCode")
                        'sheetNo.Cells(lRowCountLedger, 3).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 3).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 3).NumberFormat = "@"
                        'sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
                        sheetNo.Cells(lRowCountLedger, 2).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 2).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 2).NumberFormat = "@"
                        sheetNo.Cells(lRowCountLedger, 2) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")

                        'sheetNo.Cells(lRowCountLedger, 4).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 4).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 3).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 3).Font.Size = 8                 'Added by Stanley@30-07-2011
                        If modid = 2 Then
                            'If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-ITNIN") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-ITNIN", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-ITNOUT") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-ITNOUT", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-SIV") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-SIV", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-IDN") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-IDN", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-STA") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-STA", "GJ")
                            'End If
                            If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-ITNIN") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-ITNIN", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-ITNOUT") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-ITNOUT", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-SIV") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-SIV", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-IDN") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-IDN", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("STORE-STA") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("STORE-STA", "GJ")
                            End If
                        ElseIf modid = 3 Then
                            'If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("VehicleDistribution") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("VehicleDistribution", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("WORKSHOP") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("WORKSHOP", "GJ")
                            'End If
                            If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("VehicleDistribution") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("VehicleDistribution", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("WORKSHOP") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("WORKSHOP", "GJ")
                            End If
                        ElseIf modid = 1 Then

                            '','','CHECKROLL-HARVESTING',
                            'CHECKROLL-ON_COST','CHECKROLL-PREMI_PANEN','CHECKROLL-FIELD_ACTIVITIES','CHECKROLL-ASTEK',
                            'CHECKROLL-TAX','CHECKROLL-ACTUAL_TOTAL_COST','CHECKROLL-STANDARD_TOTAL_COST'

                            ' Check whether this condition really required here - "GJ = GENERAL JOURNAL" ?
                            'If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ADVANCE_PAYMENT") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ADVANCE_PAYMENT", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-CHECKROLL") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-CHECKROLL", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-HARVESTING") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-HARVESTING", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ON_COST") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ON_COST", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-PREMI_PANEN") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-PREMI_PANEN", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-HARVESTING") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-HARVESTING", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ON_COST") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ON_COST", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-PREMI_PANEN") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-PREMI_PANEN", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-FIELD_ACTIVITIES") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-FIELD_ACTIVITIES", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ASTEK") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ASTEK", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-TAX") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-TAX", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ACTUAL_TOTAL_COST") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ACTUAL_TOTAL_COST", "GJ")
                            'ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-STANDARD_TOTAL_COST") Then
                            '    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-STANDARD_TOTAL_COST", "GJ")
                            'End If


                            If ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ADVANCE_PAYMENT") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ADVANCE_PAYMENT", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-CHECKROLL") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-CHECKROLL", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-HARVESTING") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-HARVESTING", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ON_COST") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ON_COST", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-PREMI_PANEN") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-PREMI_PANEN", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-HARVESTING") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-HARVESTING", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ON_COST") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ON_COST", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-PREMI_PANEN") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-PREMI_PANEN", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-FIELD_ACTIVITIES") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-FIELD_ACTIVITIES", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ASTEK") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ASTEK", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-TAX") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-TAX", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-ACTUAL_TOTAL_COST") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-ACTUAL_TOTAL_COST", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-DEDUCTIONS") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-DEDUCTIONS", "GJ")
                            ElseIf ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Contains("CHECKROLL-STANDARD_TOTAL_COST") Then
                                sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference").ToString.Replace("CHECKROLL-STANDARD_TOTAL_COST", "GJ")
                            End If
                        Else
                            'sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference")
                            sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference")
                        End If

                        sheetNo.Cells(lRowCountLedger, 5).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 5).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'If modid = 3 Then
                        'sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Descp")
                        sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("Descp")
                        '     Else
                        'sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Description")
                        '    End If

                        'sheetNo.Cells(lRowCountLedger, 6).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 6).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
                        'sheetNo.Cells(lRowCountLedger, 7).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 7).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 7) = ds.Tables(1).Rows(LrowNoLedger).Item("Deb")
                        'sheetNo.Cells(lRowCountLedger, 8).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 8).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 5).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 5).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 5) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
                        sheetNo.Cells(lRowCountLedger, 6).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 6).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 6) = ds.Tables(1).Rows(LrowNoLedger).Item("Deb")
                        sheetNo.Cells(lRowCountLedger, 7).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 7).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'Commented by Stanley@04-08-2011 sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")
                        ''Added by Stanley@04-08-2011.b
                        'If ds.Tables(1).Rows(LrowNoLedger).Item("Deb") = "D" Then
                        '    If ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount") >= 0 Then
                        '        sheetNo.Cells(lRowCountLedger, 8).numberformat = "#,##0.00"
                        '    Else
                        '        sheetNo.Cells(lRowCountLedger, 8).numberformat = "(#,##0.00)"
                        '    End If
                        'Else
                        '    sheetNo.Cells(lRowCountLedger, 8).numberformat = "(#,##0.00)"
                        'End If

                        'If ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount") >= 0 Then
                        '    sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")
                        'Else
                        '    sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount") * -1
                        'End If
                        ''Added by Stanley@04-08-2011.e

                        'Added by Stanley@25-08-2011.b
                        'sheetNo.Cells(lRowCountLedger, 8).numberformat = "#,##0.00_);(#,##0.00)"
                        'If ds.Tables(1).Rows(LrowNoLedger).Item("Deb") = "D" Then
                        '    sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")
                        'Else
                        '    sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount") * -1
                        'End If
                        'sheetNo.Cells(lRowCountLedger, 7).numberformat = "#,##0.00_);(#,##0.00)"
                        sheetNo.Cells(lRowCountLedger, 7).numberformat = "#,##0_);(#,##0)"
                        If ds.Tables(1).Rows(LrowNoLedger).Item("Deb") = "D" Then
                            sheetNo.Cells(lRowCountLedger, 7) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")
                        Else
                            sheetNo.Cells(lRowCountLedger, 7) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount") * -1
                        End If
                        'Added by Stanley@25-08-2011.e

                        'sheetNo.Cells(lRowCountLedger, 9).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 9).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'If modid = 1 Or modid = 2 Or modid = 3 Then
                        '    sheetNo.Cells(lRowCountLedger, 9) = "GJ"
                        'Else
                        '    sheetNo.Cells(lRowCountLedger, 9) = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
                        'End If
                        sheetNo.Cells(lRowCountLedger, 8).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 8).Font.Size = 8                 'Added by Stanley@30-07-2011
                        If modid = 1 Or modid = 2 Or modid = 3 Then
                            sheetNo.Cells(lRowCountLedger, 8) = "GJ"
                        Else
                            sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
                        End If

                        ' sheetNo.Cells(lRowCountLedger, 3).numberformat = "@"

                        'sheetNo.Cells(lRowCountLedger, 10).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 10).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 10) = "" & GlobalPPT.strUserName & ""
                        'sheetNo.Cells(lRowCountLedger, 11).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 11).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 11).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 11) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T0").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T0"))
                        'sheetNo.Cells(lRowCountLedger, 12).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 12).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 12).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 12) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T1").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T1"))
                        'sheetNo.Cells(lRowCountLedger, 13).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 13).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 13).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 13) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T2").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T2"))
                        'sheetNo.Cells(lRowCountLedger, 14).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 14).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 14).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 14) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T3").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T3"))
                        'sheetNo.Cells(lRowCountLedger, 15).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 15).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 15).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 15) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T4").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T4"))
                        'sheetNo.Cells(lRowCountLedger, 16).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 16).Font.Size = 8                 'Added by Stanley@30-07-2011
                        'sheetNo.Cells(lRowCountLedger, 16) = "2"
                        sheetNo.Cells(lRowCountLedger, 9).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 9).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 9) = "" & GlobalPPT.strUserName & ""
                        sheetNo.Cells(lRowCountLedger, 10).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 10).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 10).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 10) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T0").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T0"))
                        sheetNo.Cells(lRowCountLedger, 11).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 11).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 11).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 11) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T1").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T1"))
                        sheetNo.Cells(lRowCountLedger, 12).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 12).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 12).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 12) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T2").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T2"))
                        sheetNo.Cells(lRowCountLedger, 13).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 13).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 13).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 13) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T3").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T3"))
                        sheetNo.Cells(lRowCountLedger, 14).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 14).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 14).NumberFormat = "@"       'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 14) = IIf(ds.Tables(1).Rows(LrowNoLedger).Item("T4").ToString().Trim() = "", "-", ds.Tables(1).Rows(LrowNoLedger).Item("T4"))
                        sheetNo.Cells(lRowCountLedger, 15).Font.Name = "Verdana"         'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 15).Font.Size = 8                 'Added by Stanley@30-07-2011
                        sheetNo.Cells(lRowCountLedger, 15) = "2"
                        LedgerCount = LedgerCount - 1
                        lRowCountLedger = lRowCountLedger + 1
                        LrowNoLedger = LrowNoLedger + 1

                        'If LedgerCount > 1 Then
                        'If lLedgerType <> ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType") Then
                        'LedgerFlag = False
                        'End If
                        'End Ifw

                        ' Added by Stanley@30-07-2011.b
                        Dim FlagRecBefore As String
                        Dim FlagRecNext As String
                        ' Added by Stanley@30-07-2011.e


                        If LedgerCount < 1 Then
                            LedgerFlag = False
                        Else
                            ' Added by Stanley@30-07-2011.b
                            If ds.Tables(1).Rows(LrowNoLedger - 1).Item("FLAG").ToString().Trim().EndsWith("|") = True Then
                                FlagRecBefore = ds.Tables(1).Rows(LrowNoLedger - 1).Item("FLAG").ToString.Substring(0, Len(ds.Tables(1).Rows(LrowNoLedger - 1).Item("FLAG").ToString) - 1)
                            Else
                                FlagRecBefore = ds.Tables(1).Rows(LrowNoLedger - 1).Item("FLAG").ToString
                            End If

                            If ds.Tables(1).Rows(LrowNoLedger).Item("FLAG").ToString().Trim().EndsWith("|") = True Then
                                FlagRecNext = ds.Tables(1).Rows(LrowNoLedger).Item("FLAG").ToString.Substring(0, Len(ds.Tables(1).Rows(LrowNoLedger).Item("FLAG").ToString) - 1)
                            Else
                                FlagRecNext = ds.Tables(1).Rows(LrowNoLedger).Item("FLAG").ToString
                            End If
                            ' Added by Stanley@30-07-2011.e

                            If ds.Tables(1).Rows(LrowNoLedger - 1).Item("FLAG").ToString().Trim().EndsWith("|") = True _
                            And ds.Tables(1).Rows(LrowNoLedger).Item("FLAG").ToString().Trim().EndsWith("|") = False Then
                                lRowCountLedger += 1
                                ' Added by Stanley@30-07-2011.b
                            ElseIf FlagRecBefore <> FlagRecNext Then
                                lRowCountLedger += 1
                                ' Added by Stanley@30-07-2011.e
                            End If
                        End If
                    End While

                    'Commented by Palani, bcas the first column is stretched more 
                    sheetNo.Columns().AutoFit()
                    sheetNo.Range("E1").EntireColumn.ColumnWidth = 40

                    CountLedgerType = CountLedgerType - 1
                    sheetNo.Protect("RANNBSP@2010")

                End While
                sheet.Visible = False
                xlApp.Visible = True


                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If


            End If
        End If
        '  Cursor = Cursors.Arrow

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub


    'Public Sub LedgerReport(ByVal modid As Integer, ByVal AMonth As Integer, ByVal AYear As Integer, ByVal strFiscalYearToDate As String, ByVal strFiscalYearFromDate As String)

    '    Dim objAccountBOL As New AccountsMonthendclosingBOL
    '    '  Dim objAccountDAL As New Accounts_DAL.AccountsMonthEndProcessingDAL

    '    'Saravana : 11 aug 2010 : This Task monitor checking is done in VechileLedgerFrm under btnreport click.....

    '    'Dim dsCheck As New DataSet

    '    'dsCheck = AccountsMonthendclosingBOL.LedgerReportCheck(modid)

    '    'If modid = 6 Then
    '    '    If dsCheck.Tables(0).Rows(0).Item("AccountCount").ToString = "N" Then
    '    '        If Not (MessageBox.Show("Store monthly Processing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
    '    '            Exit Sub
    '    '        End If
    '    '    End If
    '    'ElseIf modid = 2 Then
    '    '    If dsCheck.Tables(0).Rows(0).Item("Complete").ToString = "N" Then
    '    '        If Not (MessageBox.Show("Store monthly Processing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

    '    '            Exit Sub
    '    '        End If
    '    '    End If
    '    'Else
    '    '    If dsCheck.Tables(0).Rows(0).Item("Complete").ToString = "N" Then
    '    '        If Not (MessageBox.Show("Vehicle monthly Processing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
    '    '            Exit Sub
    '    '        End If


    '    '    End If

    '    'End If






    '    ' Cursor = Cursors.WaitCursor
    '    Dim xlApp As Excel.Application
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim strServerUserName As String = String.Empty
    '    Dim strServerPassword As String = String.Empty
    '    Dim strDSN As String = String.Empty
    '    Dim StrInitialCatlog As String = String.Empty
    '    Dim LedgerFlag As Boolean = True



    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDataSource").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""
    '    StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


    '   Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"    '   
    'Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim cmd1 As New SqlCommand
    '    Dim da As New SqlDataAdapter
    '    con = New SqlConnection(constr)

    '    con.Open()


    '    cmd.Connection = con
    '    cmd.CommandText = "Accounts.LedgerReport"
    '   cmd.CommandTimeout = 1800
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
    '    cmd.Parameters.AddWithValue("@Amonth", AMonth)
    '    cmd.Parameters.AddWithValue("@AYear", AYear)
    '    cmd.Parameters.AddWithValue("@Modid", modid)

    '    Dim tblAdt As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(ds, "LedgerReport")

    '    Dim ReportDirectory As String = String.Empty
    '    xlApp = New Excel.Application

    '    Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template.xls"

    '    ''For Memory Exception or Old format or invalid type library; Error Handling.
    '    ''------*------
    '    'xlApp.Visible = False
    '    'xlApp.UserControl = False
    '    'Dim oBooks As Object = xlApp.Workbooks
    '    'Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-US")
    '    'oBooks.GetType().InvokeMember("Add", Reflection.BindingFlags.InvokeMethod, Nothing, oBooks, Nothing, ci)
    '    ''------*------
    '    If (File.Exists(TemPath)) Then
    '        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template.xls")
    '    Else
    '        MsgBox("Ledger report template missing.Please contact system administrator.")
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

    '    Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Accounts Reports")
    '    ' Determine whether the directory exists.
    '    If Not di.Exists Then
    '        di.Create()
    '    End If





    '    Dim LmodName As String = String.Empty
    '    If modid = 6 Then
    '        LmodName = "ACCOUNTS LEDGER"
    '    ElseIf modid = 3 Then
    '        LmodName = "VEHICLE LEDGER"
    '    ElseIf modid = 2 Then
    '        LmodName = "STORE LEDGER"
    '    End If
    '    Dim lTextmonth As String = String.Empty
    '    Dim objCommonBOl As New GlobalBOL

    '    lTextmonth = objCommonBOl.PMonthName(AMonth, AYear, GlobalPPT.strLang)

    '    If Not (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth And GlobalPPT.intLoginYear <= GlobalPPT.intActiveYear) Then
    '        lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
    '    ElseIf (GlobalPPT.IntActiveMonth = 1 And GlobalPPT.IntLoginMonth = 12) Then
    '        lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
    '    End If

    '    Dim lEstAbbr As String = ""
    '    If ds.Tables(1).Rows.Count <> 0 Then
    '        lEstAbbr = ds.Tables(1).Rows(0).Item("Abbrevation").ToString()
    '    End If
    '    Dim StrPath As String = ""
    '    If lEstAbbr <> "" Then
    '        StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lEstAbbr & "_" & lTextmonth & ".xls"
    '    Else
    '        StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lTextmonth & ".xls"
    '    End If
    '    Dim lEstate As String
    '    Dim strArray As String()
    '    strArray = GlobalPPT.strEstateName.Split("-")
    '    lEstate = strArray(1)

    '    If ds.Tables(0).Rows.Count = 0 Then
    '        Dim sheet As Excel.Worksheet
    '        sheet = xlWorkBook.Sheets("Sheet1")
    '        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '        sheet.Cells(4, 1) = "" & LmodName & " " & lTextmonth & ""
    '        sheet.Cells(2, 1) = "Estate/Mill :" & lEstate
    '        sheet.Cells(2, 14) = strFiscalYearFromDate 'Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
    '        sheet.Cells(2, 16) = strFiscalYearToDate 'Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If
    '        xlApp.Visible = True
    '        '  Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If
    '    Dim LrowNoLedger As Integer = 0
    '    If ds IsNot Nothing Then
    '        Dim CountLedgerType As Integer = 0
    '        CountLedgerType = ds.Tables(0).Rows.Count
    '        Dim LedgerCount As Integer = 0
    '        LedgerCount = ds.Tables(1).Rows.Count

    '        Dim lLedgerType As String
    '        Dim lLedgerRow As Integer
    '        If CountLedgerType > 0 Then

    '            Dim sheet As Excel.Worksheet
    '            sheet = xlWorkBook.Sheets("Sheet1")
    '            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '            Dim sheetNo As Excel.Worksheet
    '            While (CountLedgerType > 0)
    '                sheetNo = xlWorkBook.Worksheets.Add
    '                sheet.UsedRange.Copy(Type.Missing.Value)
    '                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

    '                lLedgerType = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
    '                lLedgerRow = CountLedgerType - 1
    '                If lEstAbbr <> "" Then
    '                    sheetNo.Name = " " & lEstAbbr & "_" & lLedgerType & " "
    '                Else
    '                    sheetNo.Name = " " & lLedgerType & " "
    '                End If

    '                sheetNo.Cells(2, 1) = "Estate/Mill :" & lEstate & " "


    '                sheetNo.Cells(2, 14) = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                sheetNo.Cells(2, 16) = ds.Tables(1).Rows(0).Item("ToDT").ToString()

    '                sheetNo.Cells(4, 1) = "" & LmodName & " " & lTextmonth & ""


    '                Dim lRowCountLedger As Integer
    '                lRowCountLedger = 10


    '                sheetNo.Cells(9, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
    '                sheetNo.Cells(9, 5) = "Journal Consolidation"
    '                sheetNo.Cells(9, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
    '                sheetNo.Cells(9, 9) = lLedgerType
    '                sheetNo.Cells(9, 16) = "1"
    '                LedgerFlag = True

    '                While (LedgerCount > 0 And LedgerFlag = True)
    '                    sheetNo.Cells(lRowCountLedger, 1) = ds.Tables(1).Rows(LrowNoLedger).Item("oldAccountCode")
    '                    sheetNo.Cells(lRowCountLedger, 2) = ds.Tables(1).Rows(LrowNoLedger).Item("AccountCode")
    '                    sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
    '                    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference")

    '                    If modid = 3 Then
    '                        sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Descp")
    '                    Else
    '                        sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Description")
    '                    End If

    '                    'sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Description")
    '                    sheetNo.Cells(lRowCountLedger, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
    '                    sheetNo.Cells(lRowCountLedger, 7) = ds.Tables(1).Rows(LrowNoLedger).Item("Deb")
    '                    sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")

    '                    sheetNo.Cells(lRowCountLedger, 9) = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
    '                    sheetNo.Cells(lRowCountLedger, 10) = "" & GlobalPPT.strUserName & ""
    '                    sheetNo.Cells(lRowCountLedger, 11) = ds.Tables(1).Rows(LrowNoLedger).Item("T0")
    '                    sheetNo.Cells(lRowCountLedger, 12) = ds.Tables(1).Rows(LrowNoLedger).Item("T1")
    '                    sheetNo.Cells(lRowCountLedger, 13) = ds.Tables(1).Rows(LrowNoLedger).Item("T2")
    '                    sheetNo.Cells(lRowCountLedger, 14) = ds.Tables(1).Rows(LrowNoLedger).Item("T3")
    '                    sheetNo.Cells(lRowCountLedger, 15) = ds.Tables(1).Rows(LrowNoLedger).Item("T4")
    '                    sheetNo.Cells(lRowCountLedger, 16) = "2"
    '                    LedgerCount = LedgerCount - 1
    '                    lRowCountLedger = lRowCountLedger + 1
    '                    LrowNoLedger = LrowNoLedger + 1

    '                    If LedgerCount > 1 Then
    '                        If lLedgerType <> ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType") Then
    '                            LedgerFlag = False
    '                        End If
    '                    End If

    '                End While

    '                sheetNo.Range("A1").EntireColumn.ColumnWidth = 13
    '                sheetNo.Range("B1").EntireColumn.ColumnWidth = 13
    '                sheetNo.Range("C1").EntireColumn.ColumnWidth = 12
    '                sheetNo.Range("D1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("E1").EntireColumn.ColumnWidth = 35
    '                sheetNo.Range("F1").EntireColumn.ColumnWidth = 13
    '                sheetNo.Range("G1").EntireColumn.ColumnWidth = 16
    '                sheetNo.Range("H1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("I1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("J1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("K1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("L1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("M1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("N1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("O1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("P1").EntireColumn.ColumnWidth = 15
    '                CountLedgerType = CountLedgerType - 1
    '                sheetNo.Protect("RANNBSP@2010")

    '            End While
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
    '    '  Cursor = Cursors.Arrow

    'End Sub
    Public Sub ProductionMonthlyReport()

        ' Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim sheet As Excel.Worksheet

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlApp = New Excel.Application
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\MonthlyProductionReport_Template.xlsx"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\MonthlyProductionReport_Template.xlsx")
        Else
            MsgBox("Monthly production report template missing.Please contact system administrator.")
            Exit Sub
        End If

        'Dim sheet As Excel.Worksheet
        'xlApp = New Excel.Application
        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\MonthlyProductionReport_Template.xlsx")
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
        cmd.CommandText = "Production.ProductionSupplierSelect"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd.Parameters.AddWithValue("@WeighingDate", Date.Today())
        cmd.Parameters.AddWithValue("@LoginYear", GlobalPPT.intLoginYear)


        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "ProductionSupplierSelect")

        Dim objCommonBOl As New GlobalBOL
        Dim Logmonth As String = String.Empty
        Logmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

        ' Dim Pageno As Integer
        '  Pageno = 1
        sheet.Cells(1, 8) = Date.Today
        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        sheet.Cells(2, 1) = "Estate/Mill :" & lEstate
        sheet.Cells(2, 6) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        sheet.Cells(2, 8) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        ' sheet.Cells(2, 8) = Pageno
        strMonthlyProdRptName = "PRODUCTION MONTHLY REPORT" & "_" & Logmonth & ""  'ds.Tables(0).Rows(0).Item("ToDT").ToString()
        sheet.Cells(5, 1) = "PRODUCTION MONTHLY REPORT" & " " & Logmonth & ""
        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"

        'If ds.Tables(0).Rows.Count = 0 Then

        '    If (File.Exists(StrPath)) Then
        '        File.Delete(StrPath)
        '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        '    Else
        '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        '    End If

        '    xlApp.Visible = True
        '    '  Cursor = Cursors.Arrow
        '    Exit Sub
        'End If



        If ds IsNot Nothing Then
            Dim CountSupplier As Integer = 0
            CountSupplier = ds.Tables(0).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 13

            'Dim psuplierName As String
            'Dim pWeighingDate As Date
            'Dim pEstate As String
            Dim pSupplierRow As Integer = 0



            'If ds.Tables(0).Rows.Count = 0 Then
            '    xlApp.Visible = True
            '    '   Cursor = Cursors.Arrow
            '    Exit Sub
            'End If

            If CountSupplier > 0 Then
                While (CountSupplier > 0)
                    ' psuplierName = ds.Tables(0).Rows(pSupplierRow).Item("SupplierName").ToString()

                    '   pEstate = ds.Tables(0).Rows(0).Item("EstateName").ToString()

                    ' pWeighingDate = Date.Today
                    'Dim ds1 As New DataSet
                    'ds1 = ProductionMonthEndClosingBOL.ProductionMonthlyReport(psuplierName, pWeighingDate)

                    'If ds1.Tables(0).Rows.Count = 0 Then
                    '    xlApp.Visible = True
                    '    Exit Sub
                    'End If

                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2) = ds.Tables(0).Rows(pSupplierRow).Item("SupplierName")
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3) = (ds.Tables(1).Rows(0).Item("MonthValue") / 1000)
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5) = (ds.Tables(2).Rows(0).Item("YearValue") / 1000)
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    lRowCount = lRowCount + 1
                    CountSupplier = CountSupplier - 1
                    pSupplierRow = pSupplierRow + 1
                End While
                'sheet.Visible = True

            End If
            sheet.Protect("RANNBSP@2010")
            xlApp.Visible = True

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

        End If
        '  Cursor = Cursors.Arrow

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
    End Sub

    Public Sub DispatchCPOPKOReport()
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strFullMonthName As String = String.Empty
        Dim objGlobalBOL As New GlobalBOL
        strFullMonthName = objGlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

        strMonthlyProdRptName = "Dispatch - CPO and PKO for the Month " & strFullMonthName & ""

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

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


        xlApp.Visible = True
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


        Dim intRowCount As Integer
        Dim intPKORowCount As Integer

        Dim con1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim da1 As New SqlDataAdapter


        strDSN = GlobalPPT.SelectedDB.DSN
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
        cmd1.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd1.Parameters.AddWithValue("@Period", GlobalPPT.IntLoginMonth)
        cmd1.Parameters.AddWithValue("@FYear", GlobalPPT.intLoginYear)
        cmd1.Parameters.AddWithValue("@ToDate", System.DateTime.Today)
        cmd1.Parameters.AddWithValue("@ToDateYear", System.DateTime.Today)

        Dim ds As New DataSet
        Dim tblAdt As New Odbc.OdbcDataAdapter

        da1.SelectCommand = cmd1
        da1.Fill(ds, "Sample")

        If ds.Tables(0).Rows.Count > 0 Then
            sheet.Cells(13, 2) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
            sheet.Cells(19, 4) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            sheet.Cells(13, 3) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
            sheet.Cells(19, 5) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
        End If
        If ds.Tables(2).Rows.Count > 0 Then
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
        Dim lEstate As String
        Dim lDate As String
        Dim lMonth As String
        'Dim lYear As String

        ' If ds.Tables(8).Rows.Count > 0 Then
        lDate = Format(System.DateTime.Now, "dd/MM/yyyy")
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        'lMonth = ds.Tables(8).Rows(0).Item("Amonth")
        'lYear = ds.Tables(8).Rows(0).Item("AYear")
        Dim objCommonBOl As New GlobalBOL
        lMonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
        sheet.Cells(5, 1) = "Estate/Mill :" & lEstate & " "
        sheet.Cells(3, 7) = "Date :" & lDate & " "
        sheet.Cells(8, 1) = "Dispatch - CPO and PKO for the Month " & lMonth & " " '& lYear & " "
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

        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
        sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

    End Sub

End Class
