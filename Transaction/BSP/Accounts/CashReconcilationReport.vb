Imports System.Windows.Forms
Imports Common_PPT
Imports Common_BOL
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Data.SqlClient
Imports Accounts_BOL
Imports System.IO
Imports Accounts_DAL



Public Class CashReconcilationReport

    Public Sub AccountsCashReconcilation(ByVal CashReconDate As Date, ByVal CashReconTempDate As Date)

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
        xlApp = New Excel.Application
        xlAppDetail = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\CashReconciliationReport_Template.xls"
        Dim TemPathDetail As String = Application.StartupPath & "\Reports\Accounts\Excel\DetailofLessExpenditure_Template.xls"


        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\CashReconciliationReport_Template.xls")
        Else
            MsgBox("Cash Reconciliation report template missing.Please contact system administrator.")
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
        cmd.Parameters.AddWithValue("@CashReconDate", CashReconTempDate)
        'cmd.Parameters.AddWithValue("@AYear", GlobalPPT.intLoginYear)
        'cmd.Parameters.AddWithValue("@CurrentActiveMonthYearID", GlobalPPT.strActMthYearID)
        'cmd.Parameters.AddWithValue("@CurrentActiveMonthYearID", "22r262")

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "CashReconcilationReport")
        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = Format(CashReconDate, "dd-MM-yyyy")

        'If ds.Tables(5).Rows(0).Item("PettyCount") = 1 Then
        '    If Not (MessageBox.Show("Petty cash Receipt & Payment Transaction not approved? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        '        Exit Sub
        '    End If
        'End If


        If CashReconDate <> CashReconTempDate Then
            lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
            sheet.Cells(7, 1) = "CASH RECONCILIATION (PROVISIONAL) " & Format(CashReconDate, "dd/MM/yyyy") & ""
            sheetDetail.Cells(5, 1) = "DETAILS OF LESS EXPENDITURE ITEMS (PROVISIONAL) " & Format(CashReconDate, "dd/MM/yyyy") & ""
        Else
            sheet.Cells(7, 1) = "CASH RECONCILIATION  " & Format(CashReconDate, "dd/MM/yyyy") & ""
            sheetDetail.Cells(5, 1) = "DETAILS OF LESS EXPENDITURE ITEMS " & Format(CashReconDate, "dd/MM/yyyy") & ""
        End If

        sheet.Cells(3, 9) = Format(Date.Today, "dd/MM/yyyy")
        ' sheet.Cells(7, 1) = "CASH RECONCILIATION  " & Format(CashReconDate, "dd/MM/yyyy") & ""
        'sheet.Cells(7, 1).font = Color.Blue
        Dim lFromDate, lToDate As Date
        lFromDate = ds.Tables(7).Rows(0).Item("FromDT")
        lToDate = ds.Tables(7).Rows(0).Item("ToDT")
        sheet.Cells(6, 7) = Format(lFromDate, "dd/MM/yyyy")
        sheet.Cells(6, 9) = Format(lToDate, "dd/MM/yyyy")

        ''for details Report
        sheetDetail.Cells(2, 12) = Format(Date.Today, "dd/MM/yyyy")

        
        sheetDetail.Cells(4, 10) = Format(lFromDate, "dd/MM/yyyy")
        sheetDetail.Cells(4, 12) = Format(lToDate, "dd/MM/yyyy")

        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        sheet.Cells(4, 2) = "Estate/Mill :" & lEstate & " "
        sheetDetail.Cells(3, 1) = "Estate/Mill :" & lEstate & " "

        Dim strMonthlyAccountsRptName As String = String.Empty
        strMonthlyAccountsRptName = "CASH RECONCILIATION" & "_" & lTextmonth & ""

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
            lRowCount = lRowCount + 3

            sheet.Cells(lRowCount, 2) = "_________________"
            sheet.Cells(lRowCount, 4) = "_________________"
            sheet.Cells(lRowCount, 8) = "_________________"

            lRowCount = lRowCount + 4
            sheet.Cells(lRowCount, 7) = "Acknowledged By :"
            sheet.Cells(lRowCount, 7).font.bold = True
            lRowCount = lRowCount + 3
            sheet.Cells(lRowCount, 7) = "__________________"
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
            sheetDetail.Cells(lRowcountDetail, 11) = LCashOnHand
            sheetDetail.Cells(lRowcountDetail, 13) = LCashOnHand
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
            lAmountCalc = lAmountDetail
            While (PCRCount > 0)

                sheetDetail.Cells(lRowcountDetail, 1) = ds.Tables(1).Rows(LrowNoDetal).Item("ReceiptDate")
                sheetDetail.Cells(lRowcountDetail, 2) = ds.Tables(1).Rows(LrowNoDetal).Item("ReceiptDescp")
                sheetDetail.Cells(lRowcountDetail, 3) = "P/Cash"
                sheetDetail.Cells(lRowcountDetail, 4) = ds.Tables(1).Rows(LrowNoDetal).Item("ReceiptNo")
                sheetDetail.Cells(lRowcountDetail, 5) = ds.Tables(6).Rows(0).Item("PCashReceiptAccountType")
                sheetDetail.Cells(lRowcountDetail, 6) = ds.Tables(6).Rows(0).Item("OldCOACode")
                sheetDetail.Cells(lRowcountDetail, 7) = ds.Tables(1).Rows(0).Item("T0")
                sheetDetail.Cells(lRowcountDetail, 8) = ds.Tables(1).Rows(0).Item("T1")
                sheetDetail.Cells(lRowcountDetail, 9) = ds.Tables(1).Rows(0).Item("T2")
                sheetDetail.Cells(lRowcountDetail, 10) = ds.Tables(1).Rows(0).Item("T3")
                sheetDetail.Cells(lRowcountDetail, 11) = ds.Tables(1).Rows(LrowNoDetal).Item("Amount")
                lAmountDetail = lAmountDetail + ds.Tables(1).Rows(LrowNoDetal).Item("Amount")
                lAmountCalc = lAmountDetail
                sheetDetail.Cells(lRowcountDetail, 13) = lAmountDetail

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
                sheetDetail.Cells(lRowcountDetail, 6) = ds.Tables(0).Rows(LrowNoDetal).Item("OldAccountCode")
                sheetDetail.Cells(lRowcountDetail, 7) = ds.Tables(0).Rows(LrowNoDetal).Item("T0")
                sheetDetail.Cells(lRowcountDetail, 8) = ds.Tables(0).Rows(LrowNoDetal).Item("T1")
                sheetDetail.Cells(lRowcountDetail, 9) = ds.Tables(0).Rows(LrowNoDetal).Item("T2")
                sheetDetail.Cells(lRowcountDetail, 10) = ds.Tables(0).Rows(LrowNoDetal).Item("T3")

                If ds.Tables(0).Rows(LrowNoDetal).Item("TransactionType") = "Credit" Then
                    sheetDetail.Cells(lRowcountDetail, 12) = -(ds.Tables(0).Rows(LrowNoDetal).Item("Amount"))
                    lAmountDetail = lAmountDetail + ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                    lPCPAmount = lPCPAmount - ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                Else
                    sheetDetail.Cells(lRowcountDetail, 12) = ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                    lAmountDetail = lAmountDetail - ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                    lPCPAmount = lPCPAmount + ds.Tables(0).Rows(LrowNoDetal).Item("Amount")
                End If


                sheetDetail.Cells(lRowcountDetail, 13) = lAmountDetail


                PCPCount = PCPCount - 1
                lRowcountDetail = lRowcountDetail + 1
                LrowNoDetal = LrowNoDetal + 1
            End While

            lRowcountDetail = lRowcountDetail + 1

            sheetDetail.Cells(lRowcountDetail, 2) = "Total"
            sheetDetail.Cells(lRowcountDetail, 2).font.bold = True
            sheetDetail.Cells(lRowcountDetail, 11) = lAmountCalc
            sheetDetail.Cells(lRowcountDetail, 11).font.bold = True
            sheetDetail.Cells(lRowcountDetail, 12) = lPCPAmount
            sheetDetail.Cells(lRowcountDetail, 12).font.bold = True
            sheetDetail.Cells(lRowcountDetail, 13) = lAmountCalc - lPCPAmount
            sheetDetail.Cells(lRowcountDetail, 13).font.bold = True



            sheet.Protect("RANNBSP@2010")
            sheetDetail.Protect("RANNBSP@2010")

            '   sheetDetail.Unprotect("RANNBSP@2010")
            'sheetDetail.password.Protect("RANNBSP@2010")

            If (File.Exists(StrPathDetail)) Then
                File.Delete(StrPathDetail)
                xlWorkBookDetail.SaveAs(StrPathDetail, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBookDetail.SaveAs(StrPathDetail, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            '     sheetDetail.ProtectionMode = True
            '
            xlApp.StatusBar = True
            '   xlAppDetail.Visible = True
            xlApp.Visible = True


            '  xlAppDetail.Visible = True

        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim fMsg As New ProgressingFrm
        fMsg.TopMost = True
        fMsg.Show()
        ' fMsg.lblMessage.Refresh()
        fMsg.lblTitle.Refresh()
        fMsg.lblTitle.Text = "Cash Reconciliation Report Processing . . ."
        fMsg.lblTitle.Refresh()

        If chkConfirmation.Checked = False Then

            'If GlobalPPT.strLang = "en" Then
            '    MsgBox("Please Select Confirmation")
            '    chkConfirmation.Focus()
            'Else
            '    MsgBox("Silahkan Pilih Konfirmasi")
            '    chkConfirmation.Focus()
            'End If
            Dim ReportDate As Date
            Dim RptDate() As String
            Dim RptDatestring As String
            RptDatestring = "01/01/1900"

            RptDate = RptDatestring.Split("/")

            ReportDate = RptDate(1) + "/" + RptDate(0) + "/" + RptDate(2)

            AccountsCashReconcilation(dtpCashReconcilationDate.Value, ReportDate)
        Else

            Dim dsCalc As DataSet
            dsCalc = AccountsMonthendclosingBOL.CalculatePettyCashCF(dtpCashReconcilationDate.Value)

            AccountsCashReconcilation(dtpCashReconcilationDate.Value, dtpCashReconcilationDate.Value)
            chkConfirmation.Checked = False
            CashReconDate()
        End If

        fMsg.Close()
           

    End Sub

    
    Private Sub btnHistoryReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistoryReport.Click

        If ddlHistoryDate.Text = "" Then
            Exit Sub
        End If

        Dim fMsg As New ProgressingFrm
        fMsg.TopMost = True
        fMsg.Show()
        ' fMsg.lblMessage.Refresh()
        fMsg.lblTitle.Refresh()
        fMsg.lblTitle.Text = "Cash Reconciliation Report Processing . . ."
        fMsg.lblTitle.Refresh()


        Dim ReportDate As Date
        Dim RptDate() As String
        Dim RptDatestring As String
        RptDatestring = ddlHistoryDate.Text

        RptDate = RptDatestring.Split("/")

        ReportDate = RptDate(1) + "/" + RptDate(0) + "/" + RptDate(2)
        '  ReportDate = CDate(ddlHistoryDate.Text)
        AccountsCashReconcilation(ReportDate, ReportDate)
        fMsg.Close()
    End Sub

    Private Sub CashReconcilationReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CashReconcilationReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkConfirmation.Checked = False
        CashReconDate()

        If ddlMonth.Text = "" Then
            gpCashHistory.Enabled = False
        Else
            gpCashHistory.Enabled = True
        End If




        If GlobalPPT.strLang = "en" Then


            PnlSearch.CaptionText = "Cash Reconciliation Report"

            GpCashReconcilation.Text = "Cash Reconciliation"
            lblCashReconDate.Text = "Cash Reconciliation Date"
            btnviewReport.Text = "View Report"

            gpCashHistory.Text = "Cash Reconciliation History"
            lblYear.Text = "Year"
            lblmonth.Text = "Month"
            lblDate.Text = "Date"
            BtnHistoryDate.Text = "Get Date"

            btnHistoryReport.Text = "View Report"
            chkConfirmation.Text = "check this to confirm Cash Reconciliation"



        Else
            PnlSearch.CaptionText = "Rekonsiliasi Kas laporan"
            GpCashReconcilation.Text = "Rekonsiliasi Kas"
            lblCashReconDate.Text = "Rekonsiliasi Kas Tanggal"
            btnviewReport.Text = "lihat laporan"

            gpCashHistory.Text = "Rekonsiliasi Kas Sejarah"
            lblYear.Text = "Tahun"
            lblmonth.Text = "Bulan"
            lblDate.Text = "Tanggal"
            BtnHistoryDate.Text = "Dapatkan tanggal"
            btnHistoryReport.Text = "lihat laporan"
            chkConfirmation.Text = "cek ini untuk mengkonfirmasi Kas Rekonsiliasi"

        End If


















    End Sub

    Private Sub CashReconDate()
        Dim Ds As New DataSet

        Ds = AccountsMonthendclosingBOL.PettyCashCFDate()

        If GlobalPPT.IntLoginMonth <> GlobalPPT.IntActiveMonth Then
            GpCashReconcilation.Enabled = False
        Else
            GpCashReconcilation.Enabled = True
            If CDate(Ds.Tables(0).Rows(0).Item("FromDate").ToString) < GlobalPPT.FiscalYearToDate Then
                dtpCashReconcilationDate.MinDate = Ds.Tables(0).Rows(0).Item("FromDate").ToString
                dtpCashReconcilationDate.MaxDate = GlobalPPT.FiscalYearToDate
                dtpCashReconcilationDate.Value = Ds.Tables(0).Rows(0).Item("FromDate").ToString
            Else
                dtpCashReconcilationDate.Value = GlobalPPT.FiscalYearToDate
                dtpCashReconcilationDate.MaxDate = GlobalPPT.FiscalYearToDate
                GpCashReconcilation.Enabled = False
            End If


            ddlYear.DataSource = Ds.Tables(1)
            ddlYear.DisplayMember = "ValueName"
            ddlYear.ValueMember = "Ayear"

            ddlMonth.DataSource = Ds.Tables(2)
            ddlMonth.DisplayMember = "ValueName"
            ddlMonth.ValueMember = "RecordMonths"
        End If

       



    End Sub




    Private Sub BtnHistoryDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistoryDate.Click

        Dim lAmonth As Integer
        If ddlMonth.Text = "January" Then
            lAmonth = 1
        ElseIf ddlMonth.Text = "February" Then
            lAmonth = 2
        ElseIf ddlMonth.Text = "March" Then
            lAmonth = 3
        ElseIf ddlMonth.Text = "April" Then
            lAmonth = 4
        ElseIf ddlMonth.Text = "May" Then
            lAmonth = 5
        ElseIf ddlMonth.Text = "June" Then
            lAmonth = 6
        ElseIf ddlMonth.Text = "July" Then
            lAmonth = 7
        ElseIf ddlMonth.Text = "August" Then
            lAmonth = 8
        ElseIf ddlMonth.Text = "September" Then
            lAmonth = 9
        ElseIf ddlMonth.Text = "October" Then
            lAmonth = 10
        ElseIf ddlMonth.Text = "November" Then
            lAmonth = 11
        ElseIf ddlMonth.Text = "December" Then
            lAmonth = 12
        End If


        Dim Ds As New DataSet
        Ds = AccountsMonthendclosingBOL.PettyCashCFCashReconDate(lAmonth, ddlYear.Text)

        ddlHistoryDate.DataSource = Ds.Tables(0)
        ddlHistoryDate.DisplayMember = "ValueName"
        ddlHistoryDate.ValueMember = "CashReconDate"

        ddlHistoryDate.Enabled = True
        btnHistoryReport.Enabled = True

    End Sub

    Private Sub ddlMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        ddlHistoryDate.Enabled = False
        btnHistoryReport.Enabled = False
    End Sub

    Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        ddlHistoryDate.Enabled = False
        btnHistoryReport.Enabled = False
    End Sub
End Class