Imports Accounts_BOL
Imports Accounts_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Math
Imports Excel = Microsoft.Office.Interop.Excel

Public Class PettyCashPaymentReportFrm

    Public Shared strVoucherNo As String = String.Empty
    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Public Shared rptName As String = String.Empty

    Private Sub PettyCashPaymentReportFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PettyCashPaymentReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        Dim Todate As Date = GlobalPPT.FiscalYearToDate.Date
        dtpviewVoucherDate.MaxDate = New DateTime(Todate.Year, Todate.Month, Todate.Day)
        dtpviewVoucherDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        BindDataGrid()
        If GlobalPPT.strLang <> "en" Then

            '    'PnlSearch.CaptionText = "Search Petty Cash Payment"
            '    'lblsearchBy.Text = "Search By"
            '    'lblvoucherNoSearch.Text = "Voucher No"
            '    'chkVoucherDate.Text = "Voucher Date"
            '    'btnSearch.Text = "Search"
            '    dgvPettyCashPaymentView.Columns("ViewReport"). = "View Report"

            'Else
            PnlSearch.CaptionText = "Cari Pembayaran Tunai Petty"
            lblsearchBy.Text = "Cari menurut"
            lblvoucherNoSearch.Text = "No Voucher"
            chkVoucherDate.Text = "Voucher Tanggal"
            btnSearch.Text = "Cari"
            dgvPettyCashPaymentView.Columns("dgclVoucherNo").HeaderText = "No Voucher"
            dgvPettyCashPaymentView.Columns("dgclVoucherDate").HeaderText = "Voucher Tanggal"
            dgvPettyCashPaymentView.Columns("dgclDistributionDescp").HeaderText = "membayar"
            dgvPettyCashPaymentView.Columns("ViewReport").HeaderText = "Lihat Laporan"
            '  dgvPettyCashPaymentView.Columns("ViewReport").Name = "Lihat Laporan"



        End If






    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkVoucherDate.Checked = False And txtVoucherNoSearch.Text.Trim = "" Then
            If GlobalPPT.strLang = "en" Then
                MsgBox("Please Enter Criteria to Search!")
            Else
                MsgBox("Silahkan Masukkan Kriteria untuk Pencarian.")
            End If
        End If

        BindDataGrid()
        If dgvPettyCashPaymentView.Rows.Count = 0 Then
            If GlobalPPT.strLang = "en" Then
                MsgBox("No record(s) found matching your search criteria.")
            Else
                MsgBox("Tidak ada catatan(s) yang cocok dengan kriteria pencarian Anda.")
            End If
        End If

        'Dim xlApp As Excel.Application
        'Dim xlWorkBook As Excel.Workbook
        'Dim sheet As Excel.Worksheet

        'Dim SDirName As String
        'SDirName = "C:"
        ''  sheet2 = xlWorkBook.Sheets("Sheet1")
        ''  Dim StrPathDetail1 As String = "" & sDirName & "\BSP Accounts Reports\Test.xls"
        ''  b = StrPathDetail1

        'xlApp = CreateObject("Excel.Application")
        'xlWorkBook = xlApp.Workbooks.Open("" & SDirName & "\BSP Accounts Reports\Test.xls")
        '' xlWorkBook.Protect("RANNBSP@2010")

        'sheet = xlWorkBook.Sheets("Sheet1")
        'sheet.Protect("RANNBSP@2010")
        ''sheet.Protection.AllowFormattingCells = True
        ''sheet.Unprotect("RANNBSP@2010")

    End Sub

    Private Sub BindDataGrid()

        Try

            Dim mdiparent As New MDIParent

            Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
            Dim objPettyCashPaymentBOL As New PettyCashPaymentBOL
            Dim dt As New DataTable

            With objPettyCashPaymentPPT

                If chkVoucherDate.Checked = True Then
                    .lVoucherDate = Format(Me.dtpviewVoucherDate.Value, "yyyy/MM/dd")
                Else
                    .lVoucherDate = "01/01/1900"
                End If

                .Approved = "Y"
                .VoucherNo = Me.txtVoucherNoSearch.Text.Trim

            End With

            dt = objPettyCashPaymentBOL.GetPettyCashPaymentForReport(objPettyCashPaymentPPT)
            '  If dt.Rows.Count <> 0 Then

            dgvPettyCashPaymentView.AutoGenerateColumns = False
            Me.dgvPettyCashPaymentView.DataSource = dt

          



        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub dgvPettyCashPaymentView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPettyCashPaymentView.CellContentClick

        If e.ColumnIndex = 9 Then

            strVoucherNo = dgvPettyCashPaymentView.CurrentRow.Cells("dgclVoucherNo").Value.ToString()
            rptName = "PCP"
            PettyCashPaymentReportView.ShowDialog()
        End If

    End Sub

    Private Sub chkVoucherDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVoucherDate.CheckedChanged
        If chkVoucherDate.Checked = True Then
            dtpviewVoucherDate.Enabled = True
        Else
            dtpviewVoucherDate.Enabled = False
        End If
    End Sub

 

End Class