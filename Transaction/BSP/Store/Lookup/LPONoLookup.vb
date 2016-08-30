Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports System.Data.SqlClient

Public Class LPONoLookup

    Public _lLPONo As String = String.Empty
    Public _lSTLPOID As String = String.Empty
    Public _lSTLPODetID As String = String.Empty
    Public _lSTLPOSupplierID As String = String.Empty
    Public _lSTLPOSupplierName As String = String.Empty

    Public Sub BindLPONo()

        Dim dt As New DataTable
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        objEMDNPPT.LPONoSearch = txtLPONo.Text
        dt = objEMDNBOL.SearchLPONo(objEMDNPPT)

        dgvLPONo.AutoGenerateColumns = False
        dgvLPONo.DataSource = dt
        dgvLPONo.AutoGenerateColumns = False

        'dgvLPONo.Columns("dgclSTLPOID").Visible = False
        'dgvLPONo.Columns("dgclSTLPODetID").Visible = False
        'dgvLPONo.Columns("dgclLPOSupplierID").Visible = False
        'dgvLPONo.Columns("dgclLPOSupplierName").Visible = False


    End Sub

    Private Sub LPONoLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtLPONo.Focus()
        BindLPONo()

    End Sub
    Private Sub dgvLPONo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLPONo.CellDoubleClick

        If dgvLPONo.Rows.Count > 0 Then
            Me._lLPONo = dgvLPONo.SelectedRows(0).Cells("dgclLPONo").Value
            _lSTLPOID = dgvLPONo.SelectedRows(0).Cells("dgclSTLPOID").Value
            _lSTLPODetID = dgvLPONo.SelectedRows(0).Cells("dgclSTLPODetID").Value
            _lSTLPOSupplierID = dgvLPONo.SelectedRows(0).Cells("dgclLPOSupplierID").Value
            _lSTLPOSupplierName = dgvLPONo.SelectedRows(0).Cells("dgclLPOSupplierName").Value
            DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub dgvLPONo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLPONo.KeyDown

        If e.KeyCode = Keys.Return Then
            _lLPONo = dgvLPONo.SelectedRows(0).Cells("dgclLPONo").Value
            _lSTLPOID = dgvLPONo.SelectedRows(0).Cells("dgclSTLPOID").Value
            _lSTLPODetID = dgvLPONo.SelectedRows(0).Cells("dgclSTLPODetID").Value
            _lSTLPOSupplierID = dgvLPONo.SelectedRows(0).Cells("dgclLPOSupplierID").Value
            DialogResult = DialogResult.OK
        End If
        e.Handled = True


        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvLPONo, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvLPONo, e)
        'End If

    End Sub

    Private Sub btnLPONoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPONoSearch.Click

        BindLPONo()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ClearAfterSearch()

        txtLPONo.Text = String.Empty

    End Sub

    Private Sub LPONoLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class