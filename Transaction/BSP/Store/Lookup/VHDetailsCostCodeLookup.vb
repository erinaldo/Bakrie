Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class VHDetailsCostCodeLookup

    Public psVHDetailsCostCode As String = String.Empty
    Public psVHDetailsCostCodeID As String = String.Empty
    Public psVHDetailsDesc As String = String.Empty
    Public psType As String = String.Empty


    Private Sub VHDetailsCostCodeLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        ' BindGrid(psType)
        'Dim objVHDetailsCostCode As New StoreIssueVoucherPPT
        'Dim ds As New DataSet
        'ds = StoreIssueVoucherBOL.GetVHDetailsCostCode(objVHDetailsCostCode, "NO")
        'If Not ds Is Nothing Then
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        dgVHDetailsCostcode.AutoGenerateColumns = False
        '        dgVHDetailsCostcode.DataSource = ds.Tables(0)
        '    End If
        'End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ClearAfterSearch()

        txtVHDetailsCostCodeSearch.Text = String.Empty
        txtVHDetailsCostdesc.Text = String.Empty

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHDetailsCostCodeLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchVHDetailsCostCode.Text = rm.GetString("lblsearchVHDetailsCostCode.Text")
            panVHDetailsCostcodeLookUp.CaptionText = rm.GetString("panVHDetailsCostcodeLookUp.CaptionText")
            lblVHDetailsCostCode.Text = rm.GetString("lblVHDetailsCostCode.Text")
            lblVHDetailsCostCodeDesc.Text = rm.GetString("lblVHDetailsCostCodeDesc.Text")

            dgVHDetailsCostcode.Columns("dgclVHDetailCostCodeID").HeaderText = rm.GetString("dgVHDetailsCostcode.Columns(dgclVHDetailCostCodeID).HeaderText")
            dgVHDetailsCostcode.Columns("dgclVHDetailCostCode").HeaderText = rm.GetString("dgVHDetailsCostcode.Columns(dgclVHDetailCostCode).HeaderText")
            dgVHDetailsCostcode.Columns("dgclVHDescp").HeaderText = rm.GetString("dgVHDetailsCostcode.Columns(dgclVHDescp).HeaderText")
        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnVHDetailsCostCodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVHDetailsCostCodeSearch.Click
        Me.Cursor = Cursors.WaitCursor
        BindGrid(psType)
        'ClearAfterSearch()
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub BindGrid(ByVal psSIVVHType)

        psType = psSIVVHType
        Dim objVHDetailsCostCodePPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objVHDetailsCostCodePPT.VHDetailCostCode = txtVHDetailsCostCodeSearch.Text.Trim()
        objVHDetailsCostCodePPT.VHDetailCostDesc = txtVHDetailsCostdesc.Text.Trim()
        objVHDetailsCostCodePPT.Type = psType
        ds = StoreIssueVoucherBOL.GetVHDetailsCostCode(objVHDetailsCostCodePPT, "NO")
        If Not ds Is Nothing Then
            If (ds.Tables(0).Rows.Count <= 0) Then
                lblNoRecord.Visible = True
                dgVHDetailsCostcode.DataSource = ds.Tables(0)
            Else
                lblNoRecord.Visible = False
                dgVHDetailsCostcode.Visible = True
                dgVHDetailsCostcode.AutoGenerateColumns = False
                dgVHDetailsCostcode.DataSource = ds.Tables(0)
            End If
        End If

    End Sub

    Private Sub dgVHDetailsCostcode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVHDetailsCostcode.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub VHDetailsCostCodeLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub Grid_Click()

        If dgVHDetailsCostcode.RowCount <> 0 Then
            Dim objYOP As New StoreIssueVoucherPPT
            psVHDetailsCostCodeID = dgVHDetailsCostcode.CurrentRow.Cells("dgclVHDetailCostCodeID").Value.ToString()
            psVHDetailsCostCode = dgVHDetailsCostcode.CurrentRow.Cells("dgclVHDetailCostCode").Value.ToString()
            psVHDetailsDesc = dgVHDetailsCostcode.CurrentRow.Cells("dgclVHDescp").Value.ToString()
            psType = dgVHDetailsCostcode.CurrentRow.Cells("dgclType").Value.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            ''MessageBox.Show("There is no record to select")
        End If

    End Sub
    Private Sub dgVHDetailsCostcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVHDetailsCostcode.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
        End If
        e.Handled = True


        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgVHDetailsCostcode, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgVHDetailsCostcode, e)
        'End If
    End Sub

    Private Sub dgVHDetailsCostcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVHDetailsCostcode.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgVHDetailsCostcode, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHDetailsCostCodeLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub panVHDetailsCostcodeLookUp_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panVHDetailsCostcodeLookUp.Paint

    End Sub
End Class