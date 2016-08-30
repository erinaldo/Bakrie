Imports Store_BOL
Imports Common_BOL
Imports Store_PPT
Imports System.Data.SqlClient

Public Class SupplierLookup

    Public _lSupplierID As String = String.Empty
    Public _lSupplierDesc As String = String.Empty

    Public Sub BindSupplier()

        Dim dt As New DataTable
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        objEMDNPPT.SendersLocationSearch = txtSupplier.Text
        dt = objEMDNBOL.SearchSupplier(objEMDNPPT)
        dgvSupplier.AutoGenerateColumns = False
        dgvSupplier.DataSource = dt

        txtSupplier.Focus()

    End Sub

    Private Sub SupplierLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BindSupplier()
        txtSupplier.Focus()

    End Sub

    Private Sub SupplierGrid_Click()

        If dgvSupplier.Rows.Count > 0 Then
            _lSupplierID = dgvSupplier.SelectedRows(0).Cells("dgclSupplierID").Value
            _lSupplierDesc = dgvSupplier.SelectedRows(0).Cells("dgclSupplier").Value
            DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub dgvSupplier_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSupplier.CellDoubleClick

        SupplierGrid_Click()

    End Sub

    Private Sub dgvSupplier_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Then
            SupplierGrid_Click()
            e.Handled = True
        End If

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvSupplier, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvSupplier, e)
        'End If

    End Sub

    Private Sub btnSupplierSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierSearch.Click

        BindSupplier()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = DialogResult.Cancel

    End Sub

    Private Sub ClearAfterSearch()

        txtSupplier.Text = String.Empty

    End Sub

    Private Sub SupplierLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class