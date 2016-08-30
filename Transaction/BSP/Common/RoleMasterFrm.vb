Imports Common_BOL
Imports Common_PPT

Public Class RoleMasterFrm
    Private strAction As Integer
    Public _RoleID As String = String.Empty

    'Private Sub RoleMasterFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If (e.KeyCode = Keys.Enter And (Me.ActiveControl.GetType() = GetType(TextBox)) Or (Me.ActiveControl.GetType()) = (GetType(ComboBox)) Then
    '        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub txtUserRoleName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserRoleName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub RoleMasterFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        btnDelete.Enabled = False
        txtUserRoleName.Focus()
        FillGrid()
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RoleMasterFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblUserRoleName.Text = rm.GetString("lblUserRoleName.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnDelete.Text = rm.GetString("btnDelete.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillGrid()
        Dim RoleTable As DataTable
        RoleTable = RoleMasterBOL.SelectAllRoleMaster()
        dgvViewUserRoleName.DataSource = RoleTable
    End Sub
    Private Function validatePage() As Boolean
        If (String.IsNullOrEmpty(Me.txtUserRoleName.Text) Or Me.txtUserRoleName.Text = " ") Then
            'Me.ErrorProvider1.SetError(txtUserRoleName, "Cannot leave User Name blank")
            'MsgBox("Cannot leave User Name blank")
            ' MsgBox("This field is required")
            'If MessageBox.Show("This field is required", "UserRoleName", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.OK Then
            'End If
            MessageBox.Show("This field is required", "User Role Name")
            txtUserRoleName.Focus()
            Return False
        Else
            Me.ErrorProvider1.SetError(txtUserRoleName, "")
        End If
        Return True
    End Function
    Private Sub ClearAll()
        txtUserRoleName.Text = ""
        btnSave.Text = "Save"
        btnDelete.Enabled = False
        txtUserRoleName.Focus()
        btnSave.Enabled = True
    End Sub

    'Private Sub dgvViewUserRoleName_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewUserRoleName.CellDoubleClick
    '    Dim CurrentRowIndex As Integer = dgvViewUserRoleName.CurrentRow.Index
    '    txtUserRoleName.Text = dgvViewUserRoleName.Rows(CurrentRowIndex).Cells("RoleName").Value.ToString
    '    '.Columns.Item("MenuName").HeaderText = "Menu Name"
    '    _RoleID = dgvViewUserRoleName.Rows(CurrentRowIndex).Cells("RoleID").Value.ToString
    '    btnSave.Text = "Update"
    '    btnDelete.Enabled = True
    '    txtUserRoleName.Focus()

    'End Sub
    Private Sub FillSelectedRecordDetails()
        Dim objRolePPT As New Common_PPT.RoleMasterPPT()
        If Me.dgvViewUserRoleName.SelectedRows(0).Cells("RoleName").Value = "SuperAdmin" Then 'Or Me.dgvViewUserRoleName.SelectedRows(0).Cells("RoleName").Value = "Admin" Then
            Me.txtUserRoleName.Text = Me.dgvViewUserRoleName.SelectedRows(0).Cells("RoleName").Value
            btnDelete.Enabled = False
            btnSave.Enabled = False
            Return
        Else
            ClearAll()
        End If
        Me.txtUserRoleName.Text = Me.dgvViewUserRoleName.SelectedRows(0).Cells("RoleName").Value
        _RoleID = Me.dgvViewUserRoleName.SelectedRows(0).Cells("RoleNo").Value
        'Me.txtDisplayName.Text = Me.dgvUser.SelectedRows(0).Cells("DisplayName").Value
        btnSave.Text = "Update"
        btnSave.Enabled = True
        btnDelete.Enabled = True
        txtUserRoleName.Focus()
    End Sub
    Private Sub dgvViewUserRoleName_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvViewUserRoleName.DoubleClick
        If dgvViewUserRoleName.Rows.Count > 0 Then
            FillSelectedRecordDetails()
        End If
    End Sub

    Private Sub txtUserRoleName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserRoleName.KeyPress
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

    Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If validatePage() Then
            Dim objRolePPT As New Common_PPT.RoleMasterPPT()
            objRolePPT.RoleName = txtUserRoleName.Text
            Dim strSave As String = btnSave.Text
            If strSave = "Save" Then
                Dim dataTable As New DataTable() '
                dataTable = Common_BOL.RoleMasterBOL.SelectRoleName(objRolePPT) '
                If dataTable.Rows.Count = 0 Then
                    objRolePPT = Common_BOL.RoleMasterBOL.InsertRoleMaster(objRolePPT)
                    MessageBox.Show("Data Successfully Saved")
                    ClearAll()
                Else
                    MessageBox.Show("User Name already Exist. Please try with different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question) ' MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
                End If
                'objRolePPT = Common_BOL.RoleMasterBOL.InsertRoleMaster(objRolePPT)
            ElseIf btnSave.Text = "Update" Then
                objRolePPT.RoleID = Me._RoleID
                objRolePPT = Common_BOL.RoleMasterBOL.UpdateRoleMaster(objRolePPT)
                MessageBox.Show("Data Successfully Updated")
            End If
            FillGrid()
            ClearAll()
            txtUserRoleName.Focus()
        End If
    End Sub

    Private Sub btnReset_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearAll()
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            DeleteRole()
            'Else
            'FillGrid()
        End If
        'Dim objRolePPT As New Common_PPT.RoleMasterPPT()
        'objRolePPT.RoleID = Me._RoleID
        '' Dim intResult As Integer
        'If txtUserRoleName.Text <> "" Then
        '    If MessageBox.Show("You are about to delete the selected record. Are you sure? If yes please click OK", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.OK Then
        '        objRolePPT = Common_BOL.RoleMasterBOL.DeleteRoleMaster(objRolePPT)
        '        ' txtUserRoleName.Focus()
        '        MessageBox.Show("Data Successfully Deleted")
        '    End If
        '    FillGrid()
        'End If
        'ClearAll()
    End Sub

    
    Private Sub RoleMasterFrm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtUserRoleName.Focus()
    End Sub

    Private Sub dgvViewUserRoleName_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvViewUserRoleName.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvViewUserRoleName.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvViewUserRoleName.ClearSelection()
                    Me.dgvViewUserRoleName.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        add()
    End Sub

    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        FillSelectedRecordDetails()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            DeleteRole()
        Else
            FillGrid()
        End If
    End Sub
    Private Sub add()
        txtUserRoleName.Text = ""
        txtUserRoleName.Focus()
    End Sub
    Private Sub DeleteRole()
        'DataGridView.Item(ColumnName,Row).Value
        'Dim str As String = dgvViewUserRoleName.Item("RoleName", dgvViewUserRoleName.SelectedRows(0).Index).Value.ToString
        'If str = "101" Or str = "100" Then
        ' MsgBox("Not allowed to edit this designation", MsgBoxStyle.Critical, "Warning")
        'Else
        Dim objRoleBOL As New RoleMasterBOL
        Dim objRolePPT As New RoleMasterPPT
        'Dim objDesgBOL As New UserMasterBOL
        'Dim objDesgPPT As New UserMasterPPT
        objRolePPT.RoleID = dgvViewUserRoleName.Item("RoleNo", dgvViewUserRoleName.SelectedRows(0).Index).Value.ToString
        ''Dim objRolePPT As New Common_PPT.RoleMasterPPT()
        ''objRolePPT.RoleID = Me._RoleID
        ''objRolePPT = Common_BOL.RoleMasterBOL.DeleteRoleMaster(objRolePPT)

        If RoleMasterBOL.DeleteRoleMaster(objRolePPT) = 1 Then
            MessageBox.Show("Data Successfully Deleted")
            FillGrid()
            ClearAll()
        Else
            ClearAll()
            Exit Sub
        End If
        'MsgBox("Data Successfullly Deleted")
        'FillGrid()
        'ClearAll()
        'txtUserRoleName.Text = ""
        'txtUserRoleName.Focus()
        'btnSave.Enabled = True
        'Else
        'intResult = Common_BOL.UserMasterBOL.DeleteDesignation(objDesigPPT)
        'MessageBox.Show("Data Successfully Deleted")
        'FillGrid()
        'txtUserRoleName.Text = ""
        'txtUserRoleName.Focus()
        'MsgBox(strErrorDeleteMessage, MsgBoxStyle.Critical, "SADC-Message")
        'End If
        'End If
    End Sub
End Class
