Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class EquipmentLookup

    Public psEquipmentId As String = String.Empty
    Public psEquipmentCode As String = String.Empty
    Public psEquipmentName As String = String.Empty
    Public psRGNStockCOAIDValue As String = String.Empty
    Public psRGNVarianceCOAIDValue As String = String.Empty

    Private Sub EquipmentLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Dim objEquip As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.GetEquipment(objEquip, "NO")
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgEquipment.AutoGenerateColumns = False
                dgEquipment.DataSource = ds.Tables(0)
            End If
        End If

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EquipmentLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchEquipment.Text = rm.GetString("searchEquipment.Text")
            panEquipmentLookUp.CaptionText = rm.GetString("panEquipmentLookUp.CaptionText")

            lblEquipmentCode.Text = rm.GetString("lblEquipmentCode.Text")
            lblEquipName.Text = rm.GetString("lblEquipName.Text")
            dgEquipment.Columns("dgclEquipmentID").HeaderText = rm.GetString("dgEquipment.Columns(dgclEquipmentID).HeaderText")
            dgEquipment.Columns("dgclEquipmentCode").HeaderText = rm.GetString("dgEquipment.Columns(dgclEquipmentCode).HeaderText")
            dgEquipment.Columns("dgclEquipmentName").HeaderText = rm.GetString("dgEquipment.Columns(dgclEquipmentName).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearAfterSearch()

        txtEquipSearch.Text = String.Empty
        txtEquipDescSearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        ClearAfterSearch()
        Me.Close()

    End Sub

    Private Sub btnEquipSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objEquipPPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objEquipPPT.MachineCode = txtEquipSearch.Text.Trim()
        objEquipPPT.MachineName = txtEquipDescSearch.Text.Trim()
        ds = StoreIssueVoucherBOL.GetEquipment(objEquipPPT, "NO")
        If Not ds Is Nothing Then
            If (ds.Tables(0).Rows.Count <= 0) Then
                lblNoRecord.Visible = True
                'dgStation.Visible = False
                dgEquipment.DataSource = ds.Tables(0)
            Else
                lblNoRecord.Visible = False
                dgEquipment.Visible = True
                dgEquipment.AutoGenerateColumns = False
                dgEquipment.DataSource = ds.Tables(0)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgEquipment_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgEquipment.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub EquipmentLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Grid_Click()

        If dgEquipment.RowCount <> 0 Then
            Dim objEquip As New StoreIssueVoucherPPT
            psEquipmentId = dgEquipment.CurrentRow.Cells("dgclEquipmentId").Value.ToString()
            psEquipmentCode = dgEquipment.CurrentRow.Cells("dgclEquipmentCode").Value.ToString()
            psEquipmentName = dgEquipment.CurrentRow.Cells("dgclEquipmentName").Value.ToString()
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            '' MessageBox.Show("There is no record to select")
        End If

    End Sub

    Private Sub dgEquipment_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgEquipment.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
            e.Handled = True
        End If
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgEquipment, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgStation, e)
        'End If
    End Sub

    Private Sub dgEquipment_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgEquipment.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgEquipment, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EquipmentLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class