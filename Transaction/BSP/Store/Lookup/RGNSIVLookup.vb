Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class RGNSIVLookup

    Public strSIVNo As String = String.Empty
    Public strSTIssueID As String = String.Empty


    Private Sub RGNSIVLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BindGrid()

    End Sub

    Private Sub BindGrid()

        Dim objRGNPPt As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        objRGNPPt.SIVNO = txtSIVSearch.Text

        ds = ReturnGoodsNoteBOL.RGNSIVGet(objRGNPPt, "NO")
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgSIVNo.AutoGenerateColumns = False
                dgSIVNo.DataSource = ds.Tables(0)
                objRGNPPt.STIssueID = ds.Tables(0).Rows(0).Item("STIssueID")
                dgSIVNo.Visible = True
                lblNoRecord.Visible = False
            Else
                'dgSIVNo.Visible = False
                dgSIVNo.DataSource = ds.Tables(0)
                lblNoRecord.Visible = True
            End If
        End If

    End Sub

    Private Sub dgSIV_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSIVNo.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub Grid_Click()

        If dgSIVNo.RowCount <> 0 Then
            Dim objSiv As New ReturnGoodsNotePPT
            strSIVNo = dgSIVNo.CurrentRow.Cells("SIVNo").Value.ToString()
            strSTIssueID = dgSIVNo.CurrentRow.Cells("STIssueId").Value.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            ''MessageBox.Show("There is no record to select")
        End If

    End Sub

    Private Sub ClearAfterSearch()

        txtSIVSearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btnSIVSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSIVSearch.Click

        BindGrid()
        dgSIVNo.Focus()

    End Sub

    Private Sub dgSIVNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgSIVNo.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
        End If
        e.Handled = True

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgSIVNo, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgSIVNo, e)
        'End If

    End Sub

    Private Sub RGNSIVLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgSIVNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgSIVNo.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgSIVNo, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RGNSIVLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class