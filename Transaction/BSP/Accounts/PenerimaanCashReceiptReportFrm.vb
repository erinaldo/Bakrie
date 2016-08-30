Imports Accounts_BOL
Imports Accounts_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Math
Imports Excel = Microsoft.Office.Interop.Excel

Public Class PenerimaanCashReceiptReportFrm

    Public Shared strReceiptNo As String = String.Empty
    Public Shared rptName As String = String.Empty

        Private Sub PenerimaanCashReceiptReportFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PettyCashReceiptReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        Dim Todate As Date = GlobalPPT.FiscalYearToDate.Date
        dtpviewVoucherDate.MaxDate = New DateTime(Todate.Year, Todate.Month, Todate.Day)
        dtpviewVoucherDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        BindDataGrid()

        If GlobalPPT.strLang <> "en" Then

            '    lblsearchBy.Text = "Search By"
            '    chkVoucherDate.Text = "Receipt Date"
            '    lblvoucherNoSearch.Text = "Receipt No"
            '    btnSearch.Text = "Search"
            'Else
            lblsearchBy.Text = "Cari menurut"
            chkVoucherDate.Text = "Tanggal Penerimaan"
            lblvoucherNoSearch.Text = "Penerimaan No"
            btnSearch.Text = "Cari"
            dgvReceiptView.Columns("dgclReceiptDate").HeaderText = "Tanggal Penerimaan"
            dgvReceiptView.Columns("dgclReceiptNo").HeaderText = "Penerimaan No"
            dgvReceiptView.Columns("dgclReceivedFrom").HeaderText = "Penerimaan dari"
            dgvReceiptView.Columns("dgclReconcilationDate").HeaderText = "bentuk rekonsiliasi kas tanggal"
            dgvReceiptView.Columns("dgclAmount").HeaderText = "jumlah"
            ' dgvReceiptView.Columns("ViewReport").HeaderText = "Lihat Laporan"


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
        If dgvReceiptView.Rows.Count = 0 Then
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



        Dim mdiparent As New MDIParent

        Dim objPettyCashReceiptPPT As New PettyCashReceiptPPT
        Dim objPettyCashReceiptBOL As New PettyCashReceiptBOL
        Dim dt As New DataTable

        With objPettyCashReceiptPPT

            If chkVoucherDate.Checked = True Then
                .ReceiptDate = Format(Me.dtpviewVoucherDate.Value, "yyyy/MM/dd")
            Else
                .ReceiptDate = Nothing
            End If
            .Approved = "Y"
            .ReceiptNo = Me.txtVoucherNoSearch.Text.Trim
        End With

        dt = objPettyCashReceiptBOL.GetPettyCashDetails(objPettyCashReceiptPPT)
        dgvReceiptView.AutoGenerateColumns = False
        Me.dgvReceiptView.DataSource = dt

     

       

    End Sub

    Private Sub chkVoucherDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVoucherDate.CheckedChanged
        If chkVoucherDate.Checked = True Then
            dtpviewVoucherDate.Enabled = True
        Else
            dtpviewVoucherDate.Enabled = False
        End If
    End Sub



    Private Sub dgvReceiptView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceiptView.CellContentClick
        If e.ColumnIndex = 6 Then
            strReceiptNo = dgvReceiptView.CurrentRow.Cells("dgclReceiptNo").Value.ToString()
            rptName = "PCR"
            PettyCashPaymentReportView.ShowDialog()
        End If

    End Sub
End Class