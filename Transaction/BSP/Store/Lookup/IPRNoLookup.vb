Imports Store_BOL
Imports Common_BOL
Imports Store_PPT
Imports System.Data.SqlClient

Public Class IPRNoLookup

    Public _lIPRNo As String = String.Empty
    Public _lSTIPRID As String = String.Empty
    Public _lSTIPRDetID As String = String.Empty


    Public Sub BindIPRNo()

        Dim dt As New DataTable
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        objEMDNPPT.IPRNoSearch = txtIPRNo.Text
        dt = objEMDNBOL.SearchIPRNo(objEMDNPPT)

        dgvIPRNo.AutoGenerateColumns = False

        dgvIPRNo.DataSource = dt
        'dgvIPRNo.AutoGenerateColumns = False

        'dgvIPRNo.Columns("dgclSTIPRID").Visible = False
        'dgvIPRNo.Columns("dgclSTIPRDetID").Visible = False

    End Sub

    Private Sub IPRNoLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Clear()
        txtIPRNo.Focus()
        BindIPRNo()

    End Sub

    Private Sub IPRNo_Click()

        If dgvIPRNo.Rows.Count > 0 Then
            _lIPRNo = dgvIPRNo.SelectedRows(0).Cells("dgclIPRNo").Value
            _lSTIPRID = dgvIPRNo.SelectedRows(0).Cells("dgclSTIPRID").Value
            _lSTIPRDetID = dgvIPRNo.SelectedRows(0).Cells("dgclSTIPRDetID").Value
            DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub dgvIPRNo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRNo.CellDoubleClick

        IPRNo_Click()
        Clear()

    End Sub

    Private Sub dgvIPRNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIPRNo.KeyDown

        If e.KeyCode = Keys.Return Then
            IPRNo_Click()
            DialogResult = DialogResult.OK
        End If
        e.Handled = True

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvIPRNo, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvIPRNo, e)
        'End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = DialogResult.Cancel

    End Sub

    Private Sub ClearAfterSearch()

        txtIPRNo.Text = String.Empty

    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIPRNoSearch.Click

        BindIPRNo()

    End Sub

    Private Sub Clear()

        txtIPRNo.Text = String.Empty

    End Sub

    Private Sub IPRNoLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class