Imports Common_PPT
Imports Common_BOL

Public Class RolePrivilegeFrm

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FillModule()

        Dim dtDesig As DataTable = Common_BOL.RolePrivilegeBOL.SelectAllModule()
        Dim dr As DataRow = dtDesig.NewRow
        dr(0) = "-1"
        dr(1) = "--Select--"
        dtDesig.Rows.InsertAt(dr, 0)
        cbModule.DataSource = dtDesig
        cbModule.DisplayMember = "ModName"
        cbModule.ValueMember = "ModID"
        cbModule.Enabled = True

    End Sub

    Private Sub FillRole()

        Dim dtDesig As DataTable = Common_BOL.RoleMasterBOL.SelectAllRoleMaster()
        Dim dr As DataRow = dtDesig.NewRow
        dr(0) = "-1"
        dr(1) = "--Select--"
        dtDesig.Rows.InsertAt(dr, 0)
        cbRoleName.DataSource = dtDesig
        cbRoleName.DisplayMember = "RoleName"
        cbRoleName.ValueMember = "RoleID"

    End Sub

    Private Sub RolePrivilegeFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)

        cbAllowAdd.SelectedIndex = 0
        cbAllowDelete.SelectedIndex = 0
        'cbVisible.SelectedIndex = 0
        cbAllowUpdate.SelectedIndex = 0
        'btnDelete.Enabled = False
        cbModule.Enabled = False
        'cbMenu.Enabled = False

        FillRole()

    End Sub

    Private Sub cbRoleName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbRoleName.KeyDown, cbModule.KeyDown, cbMenuGroup.KeyDown, chkIncludeAllMenuGroup.KeyDown, cbMenu.KeyDown, chkIncludeAllMenu.KeyDown, cbVisible.KeyDown, cbAllowAdd.KeyDown, cbAllowUpdate.KeyDown, cbAllowDelete.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RolePrivilegeFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblRoleName.Text = rm.GetString("lblRoleName.Text")
            lblModule.Text = rm.GetString("lblModule.Text")
            lblMenuGroup.Text = rm.GetString("lblMenuGroup.Text")
            lblMenu.Text = rm.GetString("lblMenu.Text")
            lblVisible.Text = rm.GetString("lblVisible.Text")
            lblAllowAdd.Text = rm.GetString("lblAllowAdd.Text")
            lblAllowUpdate.Text = rm.GetString("lblAllowUpdate.Text")
            lblAllowDelete.Text = rm.GetString("lblAllowDelete.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function Validation() As Boolean
        If cbRoleName.SelectedIndex = 0 Then 'cbRoleName.Text = "" Then
            MessageBox.Show("This field is required", "Role Name")
            cbRoleName.Focus()
            Return False
        ElseIf cbModule.SelectedIndex = 0 Then
            'If cbModule.SelectedIndex = 0 Then
            MessageBox.Show("This field is required", "Module")
            cbModule.Focus()
            Return False
        ElseIf cbMenuGroup.Text = "" Then
            'If cbMenuGroup.SelectedIndex = 0 Then
            'MsgBox("Cannot leave MenuGroup blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Menu Group")
            cbMenuGroup.Focus()
            Return False
        ElseIf cbMenu.Text = "" Then
            'If cbMenu.SelectedIndex = 0 Then
            'MsgBox("Cannot leave Menu blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Menu")
            cbMenu.Focus()
            Return False
        ElseIf cbVisible.Text = "" Then
            'If cbVisible.SelectedIndex = 0 Then
            'MsgBox("Cannot leave Visible blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Visible")
            cbVisible.Focus()
            Return False
        ElseIf cbAllowAdd.Text = "" Then
            'If cbAllowAdd.SelectedIndex = 0 Then
            'MsgBox("Cannot leave Designation Level blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Allow Add")
            cbAllowAdd.Focus()
            Return False
        ElseIf cbAllowUpdate.Text = "" Then
            'If cbAllowUpdate.SelectedIndex = 0 Then
            'MsgBox("Cannot leave Designation Level blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Allow Update")
            cbAllowUpdate.Focus()
            Return False
        ElseIf cbAllowDelete.Text = "" Then
            'If cbAllowDelete.SelectedIndex = 0 Then
            'MsgBox("Cannot leave Designation Level blank")
            'MsgBox("This field is required")
            MessageBox.Show("This field is required", "Allow Delete")
            cbAllowDelete.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not Validation() Then
            Return
        End If
        Dim intInsert As Integer = 0
        Dim objRolePPT As New Common_PPT.RolePrivilegePPT()
        objRolePPT.RoleID = cbRoleName.SelectedValue.ToString()
        objRolePPT.ModID = CInt(cbModule.SelectedValue.ToString)
        If cbVisible.SelectedItem = "Yes" Then
            objRolePPT.Visible = 1
        Else
            objRolePPT.Visible = 0
        End If
        If cbAllowAdd.SelectedItem = "Yes" Then
            objRolePPT.RAdd = 1
        Else
            objRolePPT.RAdd = 0
        End If
        If cbAllowUpdate.SelectedItem = "Yes" Then
            objRolePPT.RUpdate = 1
        Else
            objRolePPT.RUpdate = 0
        End If
        If cbAllowDelete.SelectedItem = "Yes" Then
            objRolePPT.RDelete = 1
        Else
            objRolePPT.RDelete = 0
        End If
        If btnSave.Text = "Save" Then
            If chkIncludeAllMenuGroup.Checked = True And chkIncludeAllMenu.Checked = True Then
                'Dim dataTable As New DataTable()

                'For i As Integer = 0 To RolePrivilegePPT.dtMenuGroup.Rows.Count - 1

                For j As Integer = 0 To RolePrivilegePPT.dtMenu.Rows.Count - 1
                    objRolePPT.MenuGroupID = RolePrivilegePPT.dtMenu.Rows(j).Item("MenuGroupID").ToString()
                    objRolePPT.MenuID = RolePrivilegePPT.dtMenu.Rows(j).Item("MenuID").ToString()
                    intInsert = Common_BOL.RolePrivilegeBOL.InsertRolePrivilege(objRolePPT)

                Next
                'Next
            ElseIf chkIncludeAllMenuGroup.Checked = False And chkIncludeAllMenu.Checked = True Then
                ''        '   objRolePPT.MenuGroupID = cbMenuGroup.SelectedValue.ToString()
                For j As Integer = 0 To RolePrivilegePPT.dtMenu.Rows.Count - 1
                    objRolePPT.MenuGroupID = cbMenuGroup.SelectedValue.ToString
                    '  Dim int As Integer = RolePrivilegePPT.dtMenu.Columns.Count
                    Dim strMenuGroup As String = RolePrivilegePPT.dtMenu.Rows(j).Item("MenuGroupID").ToString()
                    If objRolePPT.MenuGroupID = strMenuGroup Then  'RolePrivilegePPT.dtMenu.Rows(j).Item("MenuGroupID").ToString() Then
                        objRolePPT.MenuID = RolePrivilegePPT.dtMenu.Rows(j).Item("MenuID").ToString()
                        intInsert = Common_BOL.RolePrivilegeBOL.InsertRolePrivilege(objRolePPT)
                    End If
                Next
            ElseIf chkIncludeAllMenuGroup.Checked = False And chkIncludeAllMenu.Checked = False Then
                objRolePPT.MenuGroupID = cbMenuGroup.SelectedValue.ToString
                objRolePPT.MenuID = cbMenu.SelectedValue.ToString
                'objRolePPT.MenuGroupID = RolePrivilegePPT.dtMenu.Rows(0).Item("MenuGroupID").ToString()
                'objRolePPT.MenuID = RolePrivilegePPT.dtMenu.Rows(0).Item("MenuID").ToString()
                intInsert = Common_BOL.RolePrivilegeBOL.InsertRolePrivilege(objRolePPT)

            End If
            MsgBox("Data Successfully Added")
            clearall()
        ElseIf btnSave.Text = "Update" Then

            objRolePPT.RolePrivilegeID = Me.dgvViewPrivilege.SelectedRows(0).Cells("RolePrivilegeID").Value
            objRolePPT.MenuGroupID = Me.dgvViewPrivilege.SelectedRows(0).Cells("MenuGroupID").Value
            objRolePPT.MenuID = Me.dgvViewPrivilege.SelectedRows(0).Cells("MenuID").Value
            objRolePPT.ModID = Me.dgvViewPrivilege.SelectedRows(0).Cells("ModId").Value
            objRolePPT.RoleID = Me.dgvViewPrivilege.SelectedRows(0).Cells("RoleID").Value
            intInsert = Common_BOL.RolePrivilegeBOL.UpdateRolePrivilege(objRolePPT)
            MsgBox("Data Successfully Updated")
            btnSave.Text = "Save"
            'btnDelete.Enabled = False
            cbRoleName.Enabled = True
        End If
        FillGrid()
        clearall()
        cbMenuGroup.Enabled = False

    End Sub

    Private Sub FillSelectedRecordDetails()
        Dim objRolePPT As New Common_PPT.RolePrivilegePPT()
        Me.cbRoleName.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("RoleName").Value
        'objRolePPT.RolePrivilegeID = Me.dgvViewPrivilege.SelectedRows(0).Cells("RolePrivilegeID").Value
        'objRolePPT.MenuGroupID = Me.dgvViewPrivilege.SelectedRows(0).Cells("MenuGroupID").Value
        Me.cbModule.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("ModuleName").Value
        Me.cbMenuGroup.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("MenuGroup").Value
        Me.cbMenu.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("MenuName").Value
        'Me.cbVisible.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("Visible").Value
        Dim Visible As String = String.Empty
        Visible = Me.dgvViewPrivilege.SelectedRows(0).Cells("Visible").Value
        If Visible = 0 Then
            cbVisible.Text = "NO"
        Else
            cbVisible.Text = "YES"
        End If

        'Me.cbAllowAdd.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("AllowAdd").Value
        Dim Add As String = String.Empty
        Add = dgvViewPrivilege.SelectedRows(0).Cells("AllowAdd").Value
        If Add = 0 Then
            cbAllowAdd.Text = "NO"
        Else
            cbAllowAdd.Text = "YES"

        End If

        'Me.cbAllowUpdate.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("AllowEdit").Value
        Dim Edit As String = String.Empty
        Edit = dgvViewPrivilege.SelectedRows(0).Cells("AllowEdit").Value
        If Edit = 0 Then
            cbAllowUpdate.Text = "NO"
        Else
            cbAllowUpdate.Text = "YES"

        End If

        ' Me.cbAllowDelete.Text = Me.dgvViewPrivilege.SelectedRows(0).Cells("AllowDelete").Value
        Dim Del As String = String.Empty
        Del = dgvViewPrivilege.SelectedRows(0).Cells("AllowDelete").Value
        If Del = 0 Then
            cbAllowDelete.Text = "NO"
        Else
            cbAllowDelete.Text = "YES"

        End If

        btnSave.Text = "Update"
        ' btnDelete.Enabled = True
        btnSave.Enabled = True
        cbRoleName.Enabled = False
        'clearall()
    End Sub

    Private Sub FillGrid()

        Dim RoleTable As DataTable
        Dim objPPT As New RolePrivilegePPT
        objPPT.RoleID = cbRoleName.SelectedValue.ToString()
        If cbModule.Items.Count <> 0 Then
            Dim str1 As String = cbModule.Items(9).ToString()

            If cbModule.SelectedValue <> -1 Then
                objPPT.ModID = CInt(cbModule.SelectedValue.ToString())
            End If

        End If
        RoleTable = RolePrivilegeBOL.SelectAllRolePrivilege(objPPT)
        dgvViewPrivilege.DataSource = RoleTable
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearall()
        cbRoleName.SelectedIndex = 0
        cbModule.SelectedIndex = 0
        ' cbMenu.SelectedIndex = 0
        btnSave.Text = "Save"
        cbRoleName.Enabled = True
    End Sub

    Private Sub clearall()
        'cbRoleName.Focus()
        'cbRoleName.Enabled = True
        'cbRoleName.SelectedIndex = 0
        btnSave.Text = "Save"
        'cbRoleName.SelectedIndex = 0
        cbModule.SelectedIndex = 0
        ' cbMenu.SelectedIndex = 0
        cbVisible.SelectedIndex = 0
        cbAllowAdd.SelectedIndex = 0
        cbAllowUpdate.SelectedIndex = 0
        cbAllowDelete.SelectedIndex = 0
        chkIncludeAllMenuGroup.Checked = True
        cbAllowAdd.Enabled = True
        cbAllowUpdate.Enabled = True
        cbAllowDelete.Enabled = True

    End Sub

    Private Sub RolePrivilegeFrm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        cbRoleName.Focus()
    End Sub

    Private Sub cbVisible_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVisible.SelectedIndexChanged
        If cbVisible.Text = "No" Then
            cbAllowAdd.Enabled = False
            cbAllowDelete.Enabled = False
            cbAllowUpdate.Enabled = False
            cbAllowAdd.SelectedItem = "No"
            cbAllowUpdate.SelectedItem = "No"
            cbAllowDelete.SelectedItem = "No"
            'Return False
        Else
            cbAllowAdd.Enabled = True
            cbAllowDelete.Enabled = True
            cbAllowUpdate.Enabled = True
            cbAllowAdd.SelectedItem = "Yes"
            cbAllowUpdate.SelectedItem = "Yes"
            cbAllowDelete.SelectedItem = "Yes"

            If cbMenuGroup.SelectedValue.ToString() = "M2" Or cbMenuGroup.SelectedValue.ToString() = "M3" Or cbMenuGroup.SelectedValue.ToString() = "M4" Then

                cbAllowAdd.Enabled = False
                cbAllowUpdate.Enabled = False
                cbAllowDelete.Enabled = False
            Else
                cbAllowAdd.Enabled = True
                cbAllowUpdate.Enabled = True
                cbAllowDelete.Enabled = True
                cbVisible.SelectedItem = "Yes"
                cbAllowAdd.SelectedItem = "Yes"
                cbAllowUpdate.SelectedItem = "Yes"
                cbAllowDelete.SelectedItem = "Yes"
            End If
        End If
    End Sub

    Private Sub cbModule_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbModule.SelectedIndexChanged
        cbMenu.DataSource = Nothing
        cbMenu.Items.Clear()
        Dim objPPT As New Common_PPT.RolePrivilegePPT()
        If cbModule.SelectedIndex > 0 Then
            objPPT.ModID = CInt(cbModule.SelectedValue.ToString())
            Dim dtModName As DataTable = Common_BOL.RolePrivilegeBOL.SelectAllMenuGroup(objPPT)
            cbMenuGroup.DataSource = dtModName
            If GlobalPPT.strLang = "en" Then
                cbMenuGroup.DisplayMember = "MenuGroup"
            Else
                cbMenuGroup.DisplayMember = "MenuNameB"
            End If
            cbMenuGroup.ValueMember = "MenuGroupID"

            If dgvViewPrivilege.DataSource.GetType() Is GetType(DataTable) Then
                Dim dt As DataTable = dgvViewPrivilege.DataSource
                dt.DefaultView.RowFilter = " ModID = " + objPPT.ModID.ToString()
            End If


            'commented by palani
            'FillGrid()
            Exit Sub
        End If

        'If cbModule.Items(0).ToString() <> "" Then
        '    FillGrid()
        'End If
        ''        cbMenuGroup.DisplayMember = "MenuGroup"
        ''        cbMenuGroup.ValueMember = "MenuGroupID"
        ''    End If
        ''End Sub


    End Sub

    Private Sub chkIncludeAllMenuGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeAllMenuGroup.CheckedChanged

        If chkIncludeAllMenuGroup.Checked = True Then
            cbMenuGroup.Enabled = False
            chkIncludeAllMenu.Checked = True
            chkIncludeAllMenu.Enabled = False
        Else
            cbMenuGroup.Enabled = True
            chkIncludeAllMenu.Enabled = True
        End If
        MenuGroupSelect()
    End Sub

    Private Sub cbMenuGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMenuGroup.SelectedIndexChanged

        MenuGroupSelect()
        If cbMenuGroup.SelectedValue.ToString() = "M2" Or cbMenuGroup.SelectedValue.ToString() = "M3" Or cbMenuGroup.SelectedValue.ToString() = "M4" Then
            cbVisible.SelectedItem = "Yes"
            cbAllowAdd.Enabled = False
            cbAllowUpdate.Enabled = False
            cbAllowDelete.Enabled = False
        Else
            cbAllowAdd.Enabled = True
            cbAllowUpdate.Enabled = True
            cbAllowDelete.Enabled = True
            cbVisible.SelectedItem = "Yes"
            cbAllowAdd.SelectedItem = "Yes"
            cbAllowUpdate.SelectedItem = "Yes"
            cbAllowDelete.SelectedItem = "Yes"

        End If
    End Sub

    Private Sub MenuGroupSelect()
        ''Dim objPPT As New Common_PPT.RolePrivilegePPT()
        ''Dim dtModName As DataTable = Common_BOL.RolePrivilegeBOL.SelectAllMenu(objPPT)
        ''Dim dr As DataRow = dtModName.NewRow
        ''dr(0) = "-1"
        ''dr(1) = "--Select--"
        ''dtModName.Rows.InsertAt(dr, 0)
        ''cbMenuGroup.DataSource = dtModName

        Dim objPPT As New Common_PPT.RolePrivilegePPT()
        Dim dtModName As DataTable = Nothing
        If cbModule.Items.Count <> 0 Then
            objPPT.ModID = CInt(cbModule.SelectedValue.ToString)
        End If
        If cbMenuGroup.Items.Count <> 0 Then
            objPPT.MenuGroupID = cbMenuGroup.SelectedValue.ToString
        End If



        If chkIncludeAllMenuGroup.Checked = True Then
            objPPT.IncludeAll = 1
        Else
            objPPT.IncludeAll = 0
        End If
        ' objPPT.IncludeAll = cbxIncludeAllMenuGroup.Checked
        If cbMenuGroup.Items.Count <> 0 Then
            dtModName = Common_BOL.RolePrivilegeBOL.SelectAllMenu(objPPT)
            cbMenu.DataSource = dtModName
        End If




        If GlobalPPT.strLang = "en" Then
            cbMenu.DisplayMember = "MenuName"
        Else
            cbMenu.DisplayMember = "MenuNameB"
        End If
        cbMenu.ValueMember = "MenuID"
    End Sub

    Private Sub dgvViewPrivilege_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewPrivilege.CellDoubleClick
        If dgvViewPrivilege.Rows.Count > 0 Then
            FillSelectedRecordDetails()
            'clearall()
        End If
    End Sub

    Private Sub DeleteUser()
        Dim objRoleBOL As New Common_BOL.RolePrivilegeBOL
        Dim objRolePPT As New Common_PPT.RolePrivilegePPT

        objRolePPT.RolePrivilegeID = dgvViewPrivilege.Item("RolePrivilegeID", dgvViewPrivilege.SelectedRows(0).Index).Value.ToString


        If RolePrivilegeBOL.DeleteRolePrivilege(objRolePPT) = 1 Then
            MessageBox.Show("Data Successfully Deleted")
            FillGrid()
            clearall()
        Else
            clearall()
            Exit Sub
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgvViewPrivilege.RowCount > 0 Then
            Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                DeleteUser()
                FillGrid()
                clearall()
            Else
                FillGrid()

            End If
        Else
            MessageBox.Show("There is No record to Delete")

        End If
    End Sub

    Private Sub cbRoleName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRoleName.SelectedIndexChanged

        FillGrid()
        FillModule()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvViewPrivilege.RowCount > 0 Then
            Dim res As DialogResult = MessageBox.Show("Are you sure you want to delete this Record? If yes please click OK", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                DeleteUser()
                FillGrid()
                clearall()
            Else
                FillGrid()
                'clearall()
            End If
        Else
            MessageBox.Show("There is No record to Delete")

        End If
    End Sub

    Private Sub SaveUPdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveUPdateToolStripMenuItem.Click
        If dgvViewPrivilege.Rows.Count > 0 Then
            FillSelectedRecordDetails()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        clearall()
    End Sub

    'Private Sub chkIncludeAllMenu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeAllMenu.CheckedChanged
    '    cbMenu.Enabled = True
    'End Sub
End Class
