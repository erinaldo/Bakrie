Imports Common_PPT
Imports Common_BOL

Public Class UserMasterFrm

    Private Sub UserMasterFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        FillGrid()
        FillDesignation()
        FillRole()
        ClearAll()
        txtUserName.Focus()
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UserMasterFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblUserName.Text = rm.GetString("lblUserName.Text")
            lblRole.Text = rm.GetString("lblRole.Text")
            lblPassword.Text = rm.GetString("lblPassword.Text")
            lblDisplayName.Text = rm.GetString("lblDisplayName.Text")
            lblDesignation.Text = rm.GetString("lblDesignation.Text")
            lblConfirmPassword.Text = rm.GetString("lblConfirmPassword.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnDelete.Text = rm.GetString("btnDelete.Text")
            dgvUser.Columns("UserName").HeaderText = rm.GetString("dgvUser.Columns(UserName).HeaderText")
            dgvUser.Columns("DisplayName").HeaderText = rm.GetString("dgvUser.Columns(DisplayName).HeaderText")
            dgvUser.Columns("Designation").HeaderText = rm.GetString("dgvUser.Columns(Designation).HeaderText")
            dgvUser.Columns("Role").HeaderText = rm.GetString("dgvUser.Columns(Role).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillGrid()
        Dim UserTable As DataTable
        UserTable = UserMasterBOL.selectAllUserMaster()
        dgvUser.AutoGenerateColumns = False
        dgvUser.DataSource = UserTable
    End Sub
    Private Sub FillDesignation()
        Dim dtDesig As DataTable = Common_BOL.UserMasterBOL.SelectAllDesignations()
        Dim dr As DataRow = dtDesig.NewRow
        dr(0) = "-1"
        dr(1) = "--Select--"
        dtDesig.Rows.InsertAt(dr, 0)
        cbDesignation.DataSource = dtDesig
        'cbDesignation.DataSource = Common_BOL.UserMasterBOL.SelectAllDesignations()
        cbDesignation.DisplayMember = "Desg"
        cbDesignation.ValueMember = "DesgID"
        'cbDesignation.Text = " --Select-- "
    End Sub
    Private Sub FillRole()
        Dim dtRole As DataTable = Common_BOL.RoleMasterBOL.SelectAllRoleMaster()
        Dim dr As DataRow = dtRole.NewRow
        dr(0) = "-1"
        dr(1) = "--Select--"
        dtRole.Rows.InsertAt(dr, 0)

        cbRole.DataSource = dtRole
        cbRole.DisplayMember = "RoleName"
        cbRole.ValueMember = "RoleID"
        'cbRole.Text = "--Select --"
    End Sub
    Private Sub ClearAll()
        txtUserName.Text = ""
        txtDisplayName.Text = ""
        cbDesignation.SelectedIndex = 0
        cbRole.SelectedIndex = 0
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""
        btnSave.Text = "Save"
        btnSave.Enabled = True
        btnDelete.Enabled = False
        txtUserName.Focus()
    End Sub
    Public Function IsUserValid() As Boolean
        Dim blUserValid As Boolean = False
        Dim objUserPPT As New Common_PPT.UserMasterPPT()
        objUserPPT.MSUserName = txtUserName.Text
        Dim dataTable As New DataTable()
        dataTable = Common_BOL.UserMasterBOL.SelectUserName(objUserPPT)
        If dataTable.Rows.Count <> 0 Then
            blUserValid = False
        Else
            blUserValid = True
        End If
    End Function
    Private Function PasswordValidation() As Boolean
        If txtPassword.Text = txtConfirmPassword.Text Then
            Return True
        Else
            MsgBox("Password Mismatch", )
            txtConfirmPassword.Focus()
            Return False
        End If
    End Function

    'Private Function Validation() As Boolean
    '    If txtUserName.Text.Trim = String.Empty Then
    '        MsgBox("Please Enter User Name")
    '    End If
    '    If txtDisplayName.Text.Trim = String.Empty Then
    '        MsgBox("Please Enter Display Name")
    '    End If
    '    If cbDesignation.SelectedIndex = 0 Then
    '        MsgBox("Please Select the Designation")
    '    End If
    '    If cbRole.SelectedIndex = 0 Then
    '        MsgBox("Please Select the Role")
    '    End If
    '    If txtPassword.Text.Trim = String.Empty Then
    '        MsgBox("Please Enter Password")
    '    End If
    '    If txtConfirmPassword.Text.Trim = String.Empty Then
    '        MsgBox("Please Enter Confirm Password")
    '    End If

    'End Function

    'Private Sub dgvUser_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUser.CellContentDoubleClick
    '    'objUserPPT.MSUserID = Me._UserID
    '    'Dim _MSUserID As New Common_PPT.UserMasterPPT()
    '    'Dim CurrentRowIndex As Integer = dgvUser.CurrentRow.Index
    '    ' Me.txtEstateName.Text = Me.dgEstate.SelectedRows(0).Cells("EstateName").Value
    '    'txtUserName.Text = dgvUser.SelectedRows .Item ((CurrentRowIndex).Cells("UserName").Value.ToString
    '    'txtUserName.Text = dgvUser.Rows(CurrentRowIndex).Cells("UserName").Value.ToString
    '    'objUserPPT.MSUserID = dgvUser.Rows(CurrentRowIndex).Cells("UserID").Value.ToString
    '    'txtDisplayName.Text = dgvUser.Rows(CurrentRowIndex).Cells("DisplayName").Value.ToString
    '    'cbDesignation.Text = dgvUser.Rows(CurrentRowIndex).Cells("Designation").Value.ToString
    '    'cbRole.Text = dgvUser.Rows(CurrentRowIndex).Cells("Role").Value.ToString
    '    'txtPassword.Text = dgvUser.Rows(CurrentRowIndex).Cells("Password").Value.ToString
    '    'txtConfirmPassword.Text = dgvUser.Rows(CurrentRowIndex).Cells("Password").Value.ToString
    '    ' End If
    'End Sub
    Private Sub FillSelectedRecordDetails()
        Dim objUserPPT As New Common_PPT.UserMasterPPT()
        ''If Me.dgvUser.SelectedRows(0).Cells("UserName").Value = "SuperAdmin" Or Me.dgvUser.SelectedRows(0).Cells("UserName").Value = "Admin" Then
        ''    Me.txtUserName.Text = Me.dgvUser.SelectedRows(0).Cells("UserName").Value
        ''    Me.txtDisplayName.Text = Me.dgvUser.SelectedRows(0).Cells("DisplayName").Value
        ''    Me.cbDesignation.Text = Me.dgvUser.SelectedRows(0).Cells("Designation").Value
        ''    Me.cbRole.Text = Me.dgvUser.SelectedRows(0).Cells("Role").Value
        ''    Me.txtPassword.Text = Me.dgvUser.SelectedRows(0).Cells("Password").Value
        ''    Me.txtConfirmPassword.Text = Me.dgvUser.SelectedRows(0).Cells("Password").Value
        ''    btnDelete.Enabled = False
        ''    btnSave.Enabled = False
        ''    Return
        ''Else
        ''    ClearAll()
        ''End If ''
        Me.txtUserName.Text = Me.dgvUser.SelectedRows(0).Cells("UserName").Value
        objUserPPT.MSUserID = Me.dgvUser.SelectedRows(0).Cells("UserID").Value
        Me.txtDisplayName.Text = Me.dgvUser.SelectedRows(0).Cells("DisplayName").Value
        Me.cbDesignation.Text = Me.dgvUser.SelectedRows(0).Cells("Designation").Value
        Me.cbRole.Text = Me.dgvUser.SelectedRows(0).Cells("Role").Value
        Me.txtPassword.Text = Me.dgvUser.SelectedRows(0).Cells("Password").Value
        Me.txtConfirmPassword.Text = Me.dgvUser.SelectedRows(0).Cells("Password").Value
        btnSave.Text = "Update"
        btnDelete.Enabled = True
        btnSave.Enabled = True
    End Sub

    Private Sub dgvUser_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvUser.DoubleClick
        'dgvUser.Rows [1].Enabled  = false
        ' dgvUser.EditIndex()
        If dgvUser.Rows.Count > 0 Then
            FillSelectedRecordDetails()

        End If
    End Sub

    Private Sub txtUserName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyDown, txtDisplayName.KeyDown, cbDesignation.KeyDown, cbRole.KeyDown, txtPassword.KeyDown, txtConfirmPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
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

    Private Sub txtDisplayName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplayName.KeyPress
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
    Private Function Validation() As Boolean
        ' If txtDesignation.Text.Trim = String.Empty Then
        If (String.IsNullOrEmpty(Me.txtUserName.Text) Or Me.txtUserName.Text = " ") Then
            MessageBox.Show("This field is required", "User Name")
            'MsgBox("This field is required")
            txtUserName.Focus()
            Return False

        ElseIf (String.IsNullOrEmpty(Me.txtDisplayName.Text) Or Me.txtDisplayName.Text = " ") Then
            MessageBox.Show("This field is required", "Display Name")
            'MsgBox("This field is required")
            txtDisplayName.Focus()
            Return False
        ElseIf cbDesignation.SelectedIndex = 0 Then
            MessageBox.Show("This field is required", "Designation")
            'MsgBox("This field is required")
            cbDesignation.Focus()
            Return False
        ElseIf cbRole.SelectedIndex = 0 Then
            MessageBox.Show("This field is required", "Role")
            'MsgBox("This field is required")
            cbRole.Focus()
            Return False
        ElseIf (String.IsNullOrEmpty(Me.txtPassword.Text) Or Me.txtPassword.Text = " ") Then
            MessageBox.Show("This field is required", "Password")
            'MsgBox("This field is required")
            txtPassword.Focus()
            Return False
        ElseIf (String.IsNullOrEmpty(Me.txtConfirmPassword.Text) Or Me.txtConfirmPassword.Text = " ") Then
            MessageBox.Show("This field is required", "ConfirmPassword")
            'MsgBox("This field is required")
            txtConfirmPassword.Focus()
            Return False
            ' ElseIf (txtPassword.Text) = (txtConfirmPassword.Text) Then
        Else
            Return True
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not Validation() Then
            Return
        End If
        Dim objUserPPT As New Common_PPT.UserMasterPPT()
        objUserPPT.MSUserName = txtUserName.Text
        objUserPPT.MSDispName = txtDisplayName.Text
        objUserPPT.MSPwd = txtPassword.Text
        objUserPPT.MSDesgID = cbDesignation.SelectedValue
        objUserPPT.MSRoleID = cbRole.SelectedValue
        Dim strSave As String = btnSave.Text
        If Not PasswordValidation() Then
            Return
        End If
        If strSave = "Save" Then
            Dim dataTable As New DataTable()
            dataTable = Common_BOL.UserMasterBOL.SelectUserName(objUserPPT)
            If dataTable.Rows.Count = 0 Then
                objUserPPT = Common_BOL.UserMasterBOL.InsertUserMaster(objUserPPT)
                MessageBox.Show("Data Successfully Saved")
                ClearAll()
            Else
                MessageBox.Show("User Name already Exist. Please try with different name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) ' MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)
            End If
        ElseIf btnSave.Text = "Update" Then

            ' objUserPPT.MSUserID = dgvUser.Rows(dgvUser.SelectedCells.Index).Cells("UserID").Value.ToString() 'Me.UserID
            objUserPPT.MSUserID = Me.dgvUser.SelectedRows(0).Cells("UserID").Value
            objUserPPT = Common_BOL.UserMasterBOL.UpdateUserMaster(objUserPPT)
            MessageBox.Show("Data Successfully Updated")
        End If
        FillGrid()
        ClearAll()
        Exit Sub
        FillGrid()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearAll()
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            DeleteUser()
        Else
            FillGrid()
        End If
        ''Dim objUserPPT As New Common_PPT.UserMasterPPT()
        ''objUserPPT.MSUserID = dgvUser.Rows(dgvUser.CurrentRow.Index).Cells("UserID").Value.ToString()
        ' ''Dim intResult As Integer
        ''If txtUserName.Text <> "" Then
        ''    If MessageBox.Show("You are about to delete the selected record. Are you sure? If yes please click OK", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.OK Then
        ''        Dim intResult As Integer = Common_BOL.UserMasterBOL.DeleteUserMaster(objUserPPT)
        ''        txtUserName.Focus()
        ''        MessageBox.Show("Data Successfully Deleted")
        ''    End If
        ''    FillGrid()
        ''End If
        ''ClearAll()
    End Sub

    Private Sub UserMasterFrm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtUserName.Focus()
    End Sub

    Private Sub dgvUser_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvUser.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvUser.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvUser.ClearSelection()
                    Me.dgvUser.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        ClearAll()
    End Sub

    Private Sub SaveUPdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveUPdateToolStripMenuItem.Click
        FillSelectedRecordDetails()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            DeleteUser()
        Else
            FillGrid()
        End If
    End Sub
    'Private Sub add()
    '    txtUserName.Text = ""
    '    txtDisplayName.Text = ""
    'End Sub
    Private Sub DeleteUser()
        Dim objUserBOL As New UserMasterBOL
        Dim objUserPPT As New UserMasterPPT
        objUserPPT.UserID = dgvUser.Item("UserID", dgvUser.SelectedRows(0).Index).Value.ToString

        If UserMasterBOL.DeleteUserMaster(objUserPPT) = 1 Then
            MessageBox.Show("Data Successfully Deleted")
            FillGrid()
            ClearAll()
        Else
            ClearAll()
            Exit Sub
        End If
    End Sub
End Class
