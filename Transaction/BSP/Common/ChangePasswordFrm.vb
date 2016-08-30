Imports Common_PPT
Imports Common_BOL
Public Class ChangePasswordFrm
    Private Sub ChangePasswordFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        'cbUserName.SelectedIndex = 0
        cbUserName.Focus()
        FillUserName()
    End Sub
    Private Sub cbUserName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbUserName.KeyDown, txtNewPassword.KeyDown, txtConfirmNewPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub FillUserName()
        Dim dtUserName As DataTable = Common_BOL.UserMasterBOL.selectAllUserName()
        Dim dr As DataRow = dtUserName.NewRow
        dr(0) = "-1"
        dr(1) = "--Select--"
        dtUserName.Rows.InsertAt(dr, 0)
        cbUserName.DataSource = dtUserName
        ''cbDesignation.DataSource = Common_BOL.UserMasterBOL.SelectAllDesignations()
        cbUserName.DisplayMember = "UserName"
        cbUserName.ValueMember = "UserID"
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChangePasswordFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblUserName.Text = rm.GetString("lblUserName.Text")
            lblRole.Text = rm.GetString("lblRole.Text")
            lblDesignation.Text = rm.GetString("lblDesignation.Text")
            lblNewPassword.Text = rm.GetString("lblNewPassword.Text")
            lblConfirmNewPassword.Text = rm.GetString("lblConfirmNewPassword.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objUserPPT As New Common_PPT.UserMasterPPT()

        If Not Validation() Then
            Return
        End If
        If Not PasswordValidation() Then
            Return
        End If
        objUserPPT.MSPwd = txtConfirmNewPassword.Text
        'objUserPPT.CPUserID = Me.UserID
        objUserPPT = Common_BOL.UserMasterBOL.UpdateChangePassword(objUserPPT)
        MessageBox.Show("Data Successfully Updated")
        Clear()

    End Sub
    Private Function PasswordValidation() As Boolean
        If txtNewPassword.Text = txtConfirmNewPassword.Text Then
            Return True
        Else
            MsgBox("Password Mismatch")
            txtConfirmNewPassword.Focus()
            Return False
        End If
    End Function
    Private Function Validation() As Boolean
        If cbUserName.SelectedIndex = 0 Then
            MessageBox.Show("This field is required", "User Name")
            cbUserName.Focus()
            Return False
        ElseIf (String.IsNullOrEmpty(Me.txtNewPassword.Text) Or Me.txtNewPassword.Text = " ") Then
            MessageBox.Show("This field is required", "New Password")
            txtNewPassword.Focus()
            Return False
        ElseIf (String.IsNullOrEmpty(Me.txtConfirmNewPassword.Text) Or Me.txtConfirmNewPassword.Text = " ") Then
            MessageBox.Show("This field is required", "Confirm New Password")
            txtConfirmNewPassword.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtDesignation.Text = ""
        cbUserName.SelectedIndex = 0
        'cbUserName.Text = ""
        txtRole.Text = ""
        txtNewPassword.Text = ""
        txtConfirmNewPassword.Text = ""
        cbUserName.Focus()
    End Sub
    Private Sub Clear()
        txtDesignation.Text = ""
        cbUserName.SelectedIndex = 0
        'cbUserName.Text = ""
        txtRole.Text = ""
        txtNewPassword.Text = ""
        txtConfirmNewPassword.Text = ""
        cbUserName.Focus()
    End Sub

    Private Sub ChangePasswordFrm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cbUserName.Focus()
    End Sub

    Private Sub cbUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUserName.SelectedIndexChanged

        UserMasterPPT.CPUserID = cbUserName.SelectedValue.ToString()
        If UserMasterPPT.CPUserID <> Nothing Then
            FillDesg()
        End If
    End Sub
    Private Sub FillDesg()
        Dim objPPT As New Common_PPT.UserMasterPPT()
        Dim dtUserName As DataTable = Common_BOL.UserMasterBOL.ChangePasswordDesgName(objPPT)
        If dtUserName.Rows.Count <> 0 Then
            txtDesignation.Text = dtUserName.Rows(0).Item("Desg").ToString()
            txtRole.Text = dtUserName.Rows(0).Item("RoleName").ToString()
        End If
    End Sub
End Class
