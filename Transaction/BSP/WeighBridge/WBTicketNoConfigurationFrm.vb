Imports BSP
Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports BSP.MDIParent

Public Class WBTicketNoConfigurationFrm
    Private _lconcurrencyId As Byte() = Nothing
    Private lWBTicketNoConfigID As String = String.Empty
    Private lSerialNo As Integer = Nothing
    Private lOtherSerialNo As Integer = Nothing
    Private _DeleteColumnIndex As Integer = 1

    Private strAction As String = String.Empty
    Shadows mdiparent As New MDIParent

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

        Private Sub WBTicketNoConfigurationFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub WBTicketNoConfigurationFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select_WbTicketNo()
        SetUICulture(GlobalPPT.strLang)
        txtNewPassword.Enabled = False
        btnTicketPassSave.Enabled = False
        btnTicketPassReset.Enabled = False
        If txtSerialNo.ReadOnly = False Then
            btnReset.Enabled = True
            btnSave.Enabled = True
        Else
            btnReset.Enabled = False
            btnSave.Enabled = False
        End If
        If Not objUserLoginBOl.Privilege_weighbridge(btnSave, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub Select_WbTicketNo()
        Dim dtSerialNoCount As DataTable
        Dim objWBTNCPPT As New WBTicketNoConfigurationPPT
        Dim objWBTNCBOL As New WBTicketNoConfigurationBOL
        'With objWBTNCPPT
        '    .SerialNo = txtSerialNo.Text.Trim
        '    .OtherSerialNo = txtSerialNo.Text.Trim
        '    .WBTicketNoConfigID = lWBTicketNoConfigID
        'End With
        dtSerialNoCount = objWBTNCBOL.WBTicketNoConfiguration_Select(objWBTNCPPT)
        If dtSerialNoCount.Rows.Count > 0 Then
            If dtSerialNoCount.Rows(0).Item("SerialNoCount") > 0 Then
                txtSerialNo.Text = dtSerialNoCount.Rows(0).Item("SerialNo").ToString()
                txtSerialNo.ReadOnly = True
            Else
                txtSerialNo.ReadOnly = False
            End If
            If dtSerialNoCount.Rows(0).Item("OtherSerialNocount") > 0 Then
                txtOtherSerialNo.Text = dtSerialNoCount.Rows(0).Item("OtherSerialNo").ToString()
                txtOtherSerialNo.ReadOnly = True
            Else
                Me.txtOtherSerialNo.ReadOnly = False
            End If
        Else
            txtSerialNo.ReadOnly = False
            txtOtherSerialNo.ReadOnly = False
        End If
    End Sub

    Private Function IsFormValid()
        If Me.txtSerialNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("Serial No. required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtSerialNo.Focus()
            Return False
        End If
        If Me.txtOtherSerialNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("Other Serial No. required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtOtherSerialNo.Focus()
            Return False
        End If
        If txtOtherSerialNo.Text = txtSerialNo.Text Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("Serial No. & Other Serial No. Should not be same", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtOtherSerialNo.Focus()
            Return False
        End If
        Return True

    End Function

    Private Sub ClearEntryForm()
        Me.txtSerialNo.Text = String.Empty
        Me.txtOtherSerialNo.Text = String.Empty
        Me.lWBTicketNoConfigID = String.Empty
        If Not objUserLoginBOl.Privilege_weighbridge(btnSave, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not IsFormValid() Then Exit Sub
        Dim dt As New DataTable
        Dim SerialNocount As Integer
        Dim objWBTNCPPT As New WBTicketNoConfigurationPPT
        Dim objWBTNCBOL As New WBTicketNoConfigurationBOL
        With objWBTNCPPT
            .SerialNo = txtSerialNo.Text.Trim
            .OtherSerialNo = txtOtherSerialNo.Text.Trim
            .WBTicketNoConfigID = lWBTicketNoConfigID
        End With
        If lWBTicketNoConfigID = "" Then
            dt = objWBTNCBOL.WBTicketNoConfigurationID_isExist(objWBTNCPPT) 'for Validation process DN No. and GRN No. is exists
            If dt.Rows.Count > 0 Then
                SerialNocount = dt.Rows(0).Item("SerialNocount")
                If SerialNocount > 0 Then
                    DisplayInfoMessage("Msg4")
                    '' MessageBox.Show("Serial No. already exist, Please check", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    dt = objWBTNCBOL.Save_WBTicketNoConfiguration(objWBTNCPPT)
                    If dt.Rows.Count > 0 Then
                        lWBTicketNoConfigID = dt.Rows(0).Item("WBTicketNoConfigID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
                        txtSerialNo.ReadOnly = True
                        txtOtherSerialNo.ReadOnly = True
                        DisplayInfoMessage("Msg5")
                        ''MessageBox.Show("Record inserted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        btnReset.Enabled = False
                        btnSave.Enabled = False
                    Else
                        DisplayInfoMessage("Msg6")
                        ''MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearEntryForm()
    End Sub

    Private Function IsPassChangeValid()
        If Me.txtNewPassword.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg7")
            ''MessageBox.Show("New Password Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNewPassword.Focus()
            Return False
        End If
        If Me.txtNewPassword.Text.Length > 16 Then
            DisplayInfoMessage("Msg8")
            '' MessageBox.Show("Password Must be less than 16 characters", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNewPassword.Focus()
            Return False
        End If
        If Me.txtNewPassword.Text.Length < 6 Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("Password Must be atlest 6 characters", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNewPassword.Focus()
            Return False
        End If
        If chkChangePassword.Checked = False Then
            DisplayInfoMessage("Msg10")
            '' MessageBox.Show("Check the Option Change Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtOtherSerialNo.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnTicketPassSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicketPassSave.Click
        If Not IsPassChangeValid() Then Exit Sub
        Dim objWBTicketNoConfigPPT As New WBTicketNoConfigurationPPT
        Dim objWBTicketNoConfigBOL As New WBTicketNoConfigurationBOL
        Dim rowsaffected As Integer = 0
        With objWBTicketNoConfigPPT
            '.Password = txtNewPassword.Text
            .Password = (WBTicketLoginFrm.psEncrypt(txtNewPassword.Text))
        End With
        If chkChangePassword.Checked = True Then
            rowsaffected = objWBTicketNoConfigBOL.UpdateWBTicketNo_Password(objWBTicketNoConfigPPT)
            If rowsaffected > 0 Then
                DisplayInfoMessage("Msg11")
                '' MessageBox.Show("Password has been Changed Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNewPassword.Text = String.Empty
                chkChangePassword.Checked = False
            Else
                DisplayInfoMessage("Msg12")
                ''MessageBox.Show("Failed to Change Password", " ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNewPassword.Text = String.Empty
            End If
        End If

        'Dim _WBTicketNoConfiguration As New WBTicketNoConfigurationEntity
        'With _WBTicketNoConfiguration
        '    '.WBTicketNoConfigID = Me.lWBTicketNoConfigID
        '    '.EstateID = UserProfile.EstateId
        '    '.SerialNo = txtSerialNo.Text.Trim
        '    '.OtherSerialNo = txtOtherSerialNo.Text.Trim
        '    .UserName = Me.txtUserName.Text.Trim
        '    .Password = Me.txtPassword.Text.Trim
        '    .NewPassword = Me.txtNewPassword.Text.Trim


        'End With

        'If _WBTicketNoConfiguration.Validate Then
        '    Try
        '        'If Not String.IsNullOrEmpty(_WBTicketNoConfiguration.WBTicketNoConfigID) Then
        '        '    _WBTicketNoConfiguration.ConcurrencyId = Weighbridge.Manager.WBTicketNoConfigurationManager.GetConcurrencyId(_WBTicketNoConfiguration.WBTicketNoConfigID)
        '        'End If

        '        _WBTicketNoConfiguration = WBTicketNoConfigurationManager.WBLoginPasswordChange(_WBTicketNoConfiguration)

        '        If _WBTicketNoConfiguration.IsTransactionSuccess Then

        '            If Me.lWBTicketNoConfigID <> "" Then
        '                MessageBox.Show(Common.Constants.Message.update, "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Else
        '                MessageBox.Show(Common.Constants.Message.Save, "Save Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            End If
        '            Me.txtSerialNo.Focus()
        '            ClearEntryForm()
        '        Else
        '            MessageBox.Show(_WBTicketNoConfiguration.ErrorMessage, "Save Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If


        '    Catch ex As CustomSqlException
        '        MessageBox.Show(ex.Message, " SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub

    Private Sub btnTicketPassReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicketPassReset.Click
        'Me.txtUserName.Text = String.Empty
        'Me.txtPassword.Text = String.Empty
        Me.txtNewPassword.Text = String.Empty
        If Not objUserLoginBOl.Privilege_weighbridge(btnTicketPassSave, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub btnTicketPassClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicketPassClose.Click
        Me.Close()
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBTicketNoConfigurationFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            tcWBTicketConfiguration.TabPages("tpWBTicketConfig").Text = rm.GetString("tcWBTicketConfiguration.TabPages(tpWBTicketConfig).Text")
            tcWBTicketConfiguration.TabPages("tpWBTicketPassword").Text = rm.GetString("tcWBTicketConfiguration.TabPages(tpWBTicketPassword).Text")
         
            lblSerialNo.Text = rm.GetString("lblSerialNo.Text")
            lblOtherSerialNo.Text = rm.GetString("lblOtherSerialNo.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            lblNewPassword.Text = rm.GetString("lblNewPassword.Text")
            btnTicketPassSave.Text = rm.GetString("btnTicketPassSave.Text")
            btnTicketPassReset.Text = rm.GetString("btnTicketPassReset.Text")
            btnTicketPassClose.Text = rm.GetString("btnTicketPassClose.Text")
            chkChangePassword.Text = rm.GetString("chkChangePassword.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBTicketNoConfigurationFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub chkChangePassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangePassword.CheckedChanged
        If chkChangePassword.Checked = True Then
            txtNewPassword.Enabled = True
            btnTicketPassSave.Enabled = True
            btnTicketPassReset.Enabled = True
            lblNewPassword.ForeColor = Color.Red
            txtNewPassword.Focus()
        Else
            txtNewPassword.Enabled = False
            btnTicketPassSave.Enabled = False
            btnTicketPassReset.Enabled = False
            lblNewPassword.ForeColor = Color.Black
        End If
        If Not objUserLoginBOl.Privilege_weighbridge(btnTicketPassSave, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    '   If Char.IsControl(e.KeyChar) Then Exit Sub
    '    If e.KeyChar = "-Select-" Then
    'Dim txt As TextBox = CType(sender, TextBox)
    '        If txt.Text.IndexOf("-Select-") < 0 Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If
    '    Else
    '        e.Handled = True
    '    End If

    Private Sub txtSerialNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialNo.Leave
        If txtSerialNo.Text.Trim <> String.Empty Then
            Dim i As Integer = txtSerialNo.Text.Length
            Dim str As String = txtSerialNo.Text.Substring(i - 1, 1)
            Try
                If 0 < str > 9 Then
                    'integer
                End If
            Catch ex As InvalidCastException
                DisplayInfoMessage("Msg13")
                ''MessageBox.Show("Invalid Serial No", "BSP", MessageBoxButtons.OK)
                txtSerialNo.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub txtOtherSerialNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherSerialNo.Leave
     
        If txtOtherSerialNo.Text.Trim <> String.Empty Then
            'If txtSerialNo.Text = txtOtherSerialNo.Text Then
            '    MessageBox.Show("Serial No & Other Serial No. Should not be same", "BSP", MessageBoxButtons.OK)
            'Else
            Dim i As Integer = txtOtherSerialNo.Text.Length
            Dim str As String = txtOtherSerialNo.Text.Substring(i - 1, 1)
            Try
                If 0 < str > 9 Then
                    'integer
                End If
            Catch ex As InvalidCastException
                DisplayInfoMessage("Msg14")
                ''MessageBox.Show("Invalid Other Serial No", "BSP", MessageBoxButtons.OK)
                txtOtherSerialNo.Focus()
                Exit Sub
            End Try
            'End If
        End If
    End Sub

    Private Sub txtSerialNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerialNo.KeyDown
       
    End Sub

    Private Sub txtSerialNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialNo.KeyPress, txtOtherSerialNo.KeyPress
        If Char.IsDigit(e.KeyChar) Then Exit Sub
        'If Char.IsLetterOrDigit(e.KeyChar) Then Exit Sub
        If Char.IsControl(e.KeyChar) Then Exit Sub

        If e.KeyChar = "" Then
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.IndexOf("") < 0 Then
                e.Handled = False
                e.Handled = True
            End If
        Else
            e.Handled = True
        End If
    End Sub
End Class