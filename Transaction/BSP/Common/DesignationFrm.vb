Imports Common_PPT
Imports Common_BOL
Public Class DesignationFrm
    Public _DesigID As String = String.Empty

    Private Sub DesignationFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        btnDelete.Enabled = False
        FillGrid()
        ClearALL()
        txtDesignation.Focus()
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DesignationFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDesignation.Text = rm.GetString("lblDesignation.Text")
            lblDesignationLevel.Text = rm.GetString("lblDesignationLevel.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnDelete.Text = rm.GetString("btnDelete.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not Validation() Then
            Return
        End If
        Dim objDesigPPT As New Common_PPT.UserMasterPPT()
        '  Dim objDesigBOL As New Common_BOL.UserMasterBOL()
        objDesigPPT.Desg = txtDesignation.Text
        'IIf(cbDesignationLevel.Text <> "", Nothing)
        objDesigPPT.DLevel = CInt(cbDesignationLevel.Text)


        If btnSave.Text = "Save" Then

            Dim dataTable As New DataTable()
            dataTable = Common_BOL.UserMasterBOL.SelectDesgName(objDesigPPT) '
            If dataTable.Rows.Count = 0 Then
                objDesigPPT = Common_BOL.UserMasterBOL.InsertDesignation(objDesigPPT)
                MessageBox.Show("Data Successfully Saved")
                ClearALL()
            Else
                MessageBox.Show("Designation Name already Exist. Please try with different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)

            End If
        ElseIf btnSave.Text = "Update" Then
            If txtDesignation.Text = "Admin" And cbDesignationLevel.Text = "101" Then
                MsgBox("Cant give 101")
                Return
            End If
            objDesigPPT.DesgID = Me._DesigID
            objDesigPPT = Common_BOL.UserMasterBOL.UpdateDesignation(objDesigPPT)
            MessageBox.Show("Data Successfully Updated")
        End If
        FillGrid()
        ClearALL()
    End Sub
    Private Function Validation() As Boolean
        ' If txtDesignation.Text.Trim = String.Empty Then
        If (String.IsNullOrEmpty(Me.txtDesignation.Text) Or Me.txtDesignation.Text = " ") Then
            'MsgBox("Cannot leave Designation Name blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Designation")
            txtDesignation.Focus()
            Return False

        ElseIf cbDesignationLevel.SelectedIndex = 0 Then
            'MsgBox("Cannot leave Designation Level blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "DesignationLevel")
            cbDesignationLevel.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub FillGrid()
        Dim desigTable As New DataTable()
        desigTable = UserMasterBOL.SelectAllDesignations()
        dgvViewDesignation.DataSource = desigTable
    End Sub
    Private Sub ClearALL()
        txtDesignation.Text = ""
        cbDesignationLevel.SelectedIndex = 0
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        Me._DesigID = String.Empty
        txtDesignation.Focus()
    End Sub
    Private Sub FillSelectedRecordDetails()
        Dim objRolePPT As New Common_PPT.RoleMasterPPT()  ''
        ' If GlobalPPT.strUserName = "SuperAdmin" Then
        'SuperAdmin()
        'If Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "SuperAdmin" Then 'Or Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "Admin" Then
        Me.txtDesignation.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value
        Me.cbDesignationLevel.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("DLevels").Value
        'If GlobalPPT.strUserName = "SuperAdmin" Then
        txtDesignation.Enabled = False
        cbDesignationLevel.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False

        'ElseIf Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "Admin" Then
        'Me.txtDesignation.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value
        'Me.cbDesignationLevel.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("DLevels").Value
        _DesigID = Me.dgvViewDesignation.SelectedRows(0).Cells("DesgNo").Value
        'txtDesignation.Enabled = False
        'cbDesignationLevel.Enabled = True
        'btnSave.Text = "Update"
        'btnSave.Enabled = True
        'btnDelete.Enabled = False
        'Return
        'End If
        ''   ElseIf GlobalPPT.strUserName = "Admin" Then
        'If Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "SuperAdmin" Or Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "Admin" Then
        '    Me.txtDesignation.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value
        '    Me.cbDesignationLevel.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("DLevels").Value
        '    'If GlobalPPT.strUserName = "SuperAdmin" Then
        '    txtDesignation.Enabled = False
        '    cbDesignationLevel.Enabled = False
        '    btnDelete.Enabled = False
        '    btnSave.Enabled = False
        '    Return
        'End If

        'btnDelete.Enabled = False
        'btnSave.Enabled = False
        'txtDesignation.Enabled = False
        'cbDesignationLevel.Enabled = False
        ''Else
        'ClearALL()

        '' End If ''
        'Me.txtDesignation.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value
        'Me.cbDesignationLevel.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("DLevels").Value
        '_DesigID = Me.dgvViewDesignation.SelectedRows(0).Cells("DesgNo").Value
        ''Me.txtDisplayName.Text = Me.dgvUser.SelectedRows(0).Cells("DisplayName").Value
        btnSave.Text = "Update"
        txtDesignation.Enabled = True
        cbDesignationLevel.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = True
        txtDesignation.Focus()
        Return
    End Sub
    Private Sub SuperAdmin()
        If Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "SuperAdmin" Or Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value = "Admin" Then
            Me.txtDesignation.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("Designation").Value
            Me.cbDesignationLevel.Text = Me.dgvViewDesignation.SelectedRows(0).Cells("DLevels").Value
            ' If GlobalPPT.strUserName = "SuperAdmin" Then
            txtDesignation.Enabled = False
            cbDesignationLevel.Enabled = False
        Else
            ClearALL()
        End If
    End Sub

    Private Sub dgvViewDesignation_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvViewDesignation.DoubleClick
        'dgvUser.Rows [1].Enabled  = false;
        If dgvViewDesignation.Rows.Count > 0 Then
            FillSelectedRecordDetails()
        End If
    End Sub

    Private Sub txtDesignation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesignation.KeyDown, cbDesignationLevel.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub dgvViewDesignation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewDesignation.CellDoubleClick
    '    Dim intCurrentRowIndex As Integer = dgvViewDesignation.CurrentRow.Index
    '    txtDesignation.Text = dgvViewDesignation.Rows(intCurrentRowIndex).Cells("Desg").Value.ToString()
    '    cbDesignationLevel.Text = dgvViewDesignation.Rows(intCurrentRowIndex).Cells("DLevel").Value.ToString()
    '    _DesigID = dgvViewDesignation.Rows(intCurrentRowIndex).Cells("DesgID").Value.ToString()

    '    btnSave.Text = "Update"
    '    btnDelete.Enabled = True
    'End Sub
    Private Sub txtDesignation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesignation.KeyPress
        'If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
        '    Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
        '    And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
        '    Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
        '    'Allowed space
        '    If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
        '        e.Handled = True
        '    End If
        'End If
        '' Allowed backspace
        'If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
        '    e.Handled = False
        'End If
    End Sub


    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            DeleteDesg()
        Else
            FillGrid()
        End If


        ''If Validation() Then
        'Dim objDesigPPT As New Common_PPT.UserMasterPPT()
        'Dim intResult As Integer
        'objDesigPPT.DesgID = Me._DesigID
        'If txtDesignation.Text <> "" Then
        '    'Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    'If res = DialogResult.Yes Then
        '    If MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.OK Then
        '        intResult = Common_BOL.UserMasterBOL.DeleteDesignation(objDesigPPT)
        '        MessageBox.Show("Data Successfully Deleted")
        '    End If
        '    FillGrid()
        'End If
        'ClearALL()
        'cbDesignationLevel.Text = ""
        ' ''End If
    End Sub

    Private Sub btnReset_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtDesignation.Text = ""
        cbDesignationLevel.SelectedIndex = 0
        txtDesignation.Focus()
        ClearALL()
        btnSave.Text = "Save"
        btnSave.Enabled = True
        btnDelete.Enabled = False
    End Sub

    Private Sub DesignationFrm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtDesignation.Focus()
    End Sub

    'Private Sub MenuStrip1_Click(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles cmsDesig.ItemClicked
    '    'Get the text of the item that was clicked on.
    '    'gridRole.CurrentRow.Index.ToString
    '    Dim strAction As String = e.ClickedItem.Text

    '    If strAction = "Add" Then
    '        add()
    '    ElseIf strAction = "Edit/Update" Then
    '        activateUpdate()
    '    ElseIf strAction = "Delete" Then
    '        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If res = DialogResult.Yes Then
    '            Delete()
    '        Else
    '            FillGrid()
    '        End If
    '    Else
    '        MsgBox("Unknown value selected", MsgBoxStyle.Critical, "SADC-Message")
    '    End If
    'End Sub

    Private Sub add()
        txtDesignation.Text = ""
        txtDesignation.Focus()
        cbDesignationLevel.SelectedIndex = 0
    End Sub
    Private Sub activateUpdate()
        Dim objDesigPPT As New Common_PPT.UserMasterPPT()
        objDesigPPT.Desg = txtDesignation.Text
        'IIf(cbDesignationLevel.Text <> "", Nothing)
        ' objDesigPPT.DLevel = CInt(cbDesignationLevel.SelectedItem.ToString())
        objDesigPPT.DesgID = Me._DesigID
        objDesigPPT = Common_BOL.UserMasterBOL.UpdateDesignation(objDesigPPT)
        MessageBox.Show("Data Successfully Updated")
        'End If
        FillGrid()
        ClearALL()
    End Sub
    Private Sub Delete()
        Dim objDesigPPT As New Common_PPT.UserMasterPPT()
        Dim intResult As Integer
        objDesigPPT.DesgID = Me._DesigID
        If txtDesignation.Text <> "" Then
            'Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If res = DialogResult.Yes Then
            If MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.OK Then
                intResult = Common_BOL.UserMasterBOL.DeleteDesignation(objDesigPPT)
                MessageBox.Show("Data Successfully Deleted")
            End If
            FillGrid()
        End If
        ClearALL()
        cbDesignationLevel.Text = ""
    End Sub

    'Private Sub dgvViewDesignation_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvViewDesignation.MouseClick
    '    Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvViewDesignation.HitTest(e.X, e.Y)
    '    If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
    '        Return
    '    End If
    '    If dgvViewDesignation.CurrentRow.Index >= 0 And dgvViewDesignation.CurrentCell.ColumnIndex >= 0 Then

    '        ' Load context menu on right mouse click
    '        'If dgvViewDesignation.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then
    '        Me.dgvViewDesignation.ClearSelection()
    '        Me.dgvViewDesignation.Rows(htIsHeader.RowIndex).Selected = True
    '        Dim ldRect As Rectangle
    '        Dim lpPosCell As Point

    '        ldRect = dgvViewDesignation.GetCellDisplayRectangle(dgvViewDesignation.CurrentCell.ColumnIndex, dgvViewDesignation.CurrentRow.Index, True)
    '        lpPosCell = CType(ldRect.Location, Point)
    '        Me.cmsDesig.Show(dgvViewDesignation, lpPosCell)
    '        ' Me.cmsDelete.Show(Me.dgVehicleBatchDetails, dgVehicleBatchDetails.SelectedRows)
    '        'Me.cmsDelete.Show(Me.dgVehicleBatchDetails, e.Location)

    '    End If
    '    'End If
    'End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        add()
    End Sub

    Private Sub SaveUPdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveUPdateToolStripMenuItem.Click
        FillSelectedRecordDetails()
        'activateUpdate()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'Delete()
        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            DeleteDesg()
        Else
            FillGrid()
        End If
    End Sub
    Private Sub DeleteDesg()
        Dim str As String = dgvViewDesignation.Item("DLevels", dgvViewDesignation.SelectedRows(0).Index).Value.ToString
        Dim objDesgBOL As New UserMasterBOL
        Dim objDesgPPT As New UserMasterPPT
        objDesgPPT.DesgID = dgvViewDesignation.Item("DesgNo", dgvViewDesignation.SelectedRows(0).Index).Value.ToString

        If UserMasterBOL.DeleteDesignation(objDesgPPT) = 1 Then
            MessageBox.Show("Data Successfully Deleted")
            FillGrid()
            ClearALL()
        Else
            ClearALL()
            Exit Sub
        End If
    End Sub

    Private Sub dgvViewDesignation_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvViewDesignation.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvViewDesignation.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvViewDesignation.ClearSelection()
                    Me.dgvViewDesignation.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

End Class
