Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports System.Data.SqlClient

Public Class IPRViewLookUp
    Public _lSupplier As String = String.Empty

    Private Sub IPRDetailSearchGrid()
        Dim dt As New DataTable
        Dim objIPRBOL As New IPRBOL
        Dim objIPRPPT As New IPRPPT
        With objIPRPPT
            .DeliveredTo = txtSupplierSearch.Text
            .Classification = Me.lblSearchColumn.Text
        End With
        dt = objIPRBOL.GetIPRDetails(objIPRPPT)
        Me.dgvIPRDetails.AutoGenerateColumns = False
        With Me.dgvIPRDetails
            .DataSource = dt
            .Columns.Item("gvIPRNo").Visible = False
            .Columns.Item("gvClassification").Visible = False
            .Columns.Item("gvDeliveredTo").Visible = False
            .Columns.Item("gvRequiredfor").Visible = False
            .Columns.Item("gvMainstatus").Visible = False
            .Columns.Item("gvCategory").Visible = False
        End With


    End Sub

    Private Sub WBSupplierLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblSearchColumn.Text = "IPRdate"
        IPRDetailSearchGrid()
    End Sub
    Private Sub DvgSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.dgvIPRDetails.Rows.Count > 0 Then

            Me._lSupplier = Me.dgvIPRDetails.SelectedRows(0).Cells("Supplier").Value

        End If
    End Sub
    Private Sub btnGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGO.Click
        ' SupplierGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub dgvSupplier_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub pnlSupplierSearch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlsearchIPRView.Paint

    End Sub

    Private Sub dgvSupplier_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRDetails.CellDoubleClick
        Grid_Click()
    End Sub

    Private Sub dgvIPRDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRDetails.CellContentClick

    End Sub

    Private Sub IPRViewLookUp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub Grid_Click()
        If dgvIPRDetails.Rows.Count > 0 Then
            Me._lSupplier = Me.dgvIPRDetails.SelectedRows(0).Cells("Supplier").Value
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub dgvIPRDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIPRDetails.KeyDown
        If e.KeyCode = Keys.Return Then
            Grid_Click()
        End If
        e.Handled = True


        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvIPRDetails, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvIPRDetails, e)
        'End If
    End Sub
End Class