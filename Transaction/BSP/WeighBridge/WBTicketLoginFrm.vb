Imports System.Security.Cryptography
Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Text
Imports System.Collections.Specialized

Public Class WBTicketLoginFrm
    Private lbtVector() As Byte = {240, 3, 45, 29, 0, 76, 173, 59}
    Private lscryptoKey As String = "ChangeThis!"
    Public Sub GetCredentials()
        Dim ds As New DataSet
        'Dim objLogin As New LoginAuthenticationManager
        Dim dt As DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        Me.txtPassword.Text = psEncrypt(Me.txtPassword.Text)

        'Dim objLoginProperty As New WBWeighingInOutEntity
        objWBTicketInOutPPT.Usercode = txtUserName.Text.Trim
        objWBTicketInOutPPT.Password = txtPassword.Text.Trim

        'objLoginProperty.UserCode = Me.txtUserName.Text.Trim
        'objLoginProperty.Password = Me.txtPassword.Text

        'Dim LoginDetails As Weighbridge.Entity.WBWeighingInOutCollection
        dt = objWBTicketInOutBOL.WBWeighingInOutSecurity_Select(objWBTicketInOutPPT)

        'LoginDetails = Weighbridge.Manager.WBWeighingInOutManager.WBManualWeightAuthentication(New WBWeighingInOutEntity With {.Usercode = Me.txtUserName.Text, .Password = Me.txtPassword.Text, .EstateID = UserProfile.EstateId})
        'Dim LoginDetails As LoginAuthenticationCollection = LoginAuthenticationManager.GetList(New LoginAuthenticationEntity With {.UserCode = Me.txtUserName.Text, .Password = Me.txtPassword.Text, .EstateID = UserProfile.EstateId})
        If dt.Rows.Count > 0 Then
            GlobalPPT.strUserName = IIf(IsDBNull(dt.Rows(0).Item("WBTicketUserCode")), "", dt.Rows(0).Item("WBTicketUserCode"))
            GlobalPPT.strPassword = IIf(IsDBNull(dt.Rows(0).Item("WBTicketPassword")), "", dt.Rows(0).Item("WBTicketPassword"))
            'Me.DialogResult = DialogResult.OK
        Else
            txtUserName.Text = String.Empty
            txtPassword.Text = String.Empty
            'Exit Sub
        End If

        'If LoginDetails.Count > 0 Then

        '    UserProfile.lStrUser = IIf(IsDBNull(LoginDetails.Item(0).UserCode), "", LoginDetails.Item(0).UserCode)
        '    UserProfile.lStrPwd = IIf(IsDBNull(LoginDetails.Item(0).Password), "", LoginDetails.Item(0).Password)
        '    '' UserProfile.EstateId = IIf(IsDBNull(LoginDetails.Item(0).EstateID), "", LoginDetails.Item(0).EstateID)
        '    ''UserProfile.EstateName = IIf(IsDBNull(LoginDetails.Item(0).EstateName), "", LoginDetails.Item(0).EstateName)
        '    ''UserProfile.EstateCode = IIf(IsDBNull(LoginDetails.Item(0).EstateCode), "", LoginDetails.Item(0).EstateCode)
        '    'UserProfile.lRoleName = IIf(IsDBNull(LoginDetails.Item(0).RoleName), "", LoginDetails.Item(0).RoleName)

        '    'If IIf(IsDBNull(LoginDetails.Item(0).Rootuser), False, LoginDetails.Item(0).Rootuser) = True Then
        '    '    UserProfile.lGBrootuser = True
        '    'Else
        '    '    UserProfile.lGBrootuser = False
        '    'End If
        '    Me.DialogResult = DialogResult.OK
        'End If


        If Me.txtUserName.Text = GlobalPPT.strUserName Then
            If Me.txtPassword.Text = GlobalPPT.strPassword Then
                Me.DialogResult = DialogResult.OK
            Else
                DisplayInfoMessage("Msg1")
                ''MsgBox("Invalid user name or password", MsgBoxStyle.Information, "BSP")
                Exit Sub
            End If
        Else
            DisplayInfoMessage("Msg1")
            txtUserName.Text = String.Empty
            txtPassword.Text = String.Empty
            txtUserName.Focus()
            ''MessageBox.Show("Invalid User Name or Password", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    'Private Sub WBTicketLoginFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Public Function psEncrypt(ByVal strpwd As String) As String
        Dim loCryptoClass As New TripleDESCryptoServiceProvider
        Dim loCryptoProvider As New MD5CryptoServiceProvider
        Dim lbtBuffer() As Byte
        Try
            lbtBuffer = System.Text.Encoding.ASCII.GetBytes(strpwd)
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey))

            loCryptoClass.IV = lbtVector
            strpwd = Convert.ToBase64String(loCryptoClass.CreateEncryptor().TransformFinalBlock(lbtBuffer, 0, lbtBuffer.Length()))

            psEncrypt = strpwd
        Catch ex As CryptographicException
            Throw ex
        Catch ex As FormatException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            loCryptoClass.Clear()
            loCryptoProvider.Clear()
            loCryptoClass = Nothing
            loCryptoProvider = Nothing
        End Try
    End Function

    Private Function IsFormValid()
        If txtUserName.Text = String.Empty Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("User Name Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUserName.Focus()
            Return False
        End If
        If txtPassword.Text = String.Empty Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("Password Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Focus()
            Return False
        End If
        'If txtPassword.Text.Length > 16 Then
        '    MessageBox.Show("Password must be less than 16 Characters", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtPassword.Text = String.Empty
        '    txtPassword.Focus()
        '    Return False
        'End If
        'If txtPassword.Text.Length < 6 Then
        '    MessageBox.Show("Password must be atleast 6 Characters", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtPassword.Text = String.Empty
        '    txtPassword.Focus()
        '    Return False
        'End If

        Return True
    End Function

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Not IsFormValid() Then Exit Sub
        GetCredentials()
        Exit Sub
        'Me.Close()
    End Sub

    Private Sub btnTicketPassClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub WBTicketLoginFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub WBTicketLoginFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserName.Text = String.Empty
        txtPassword.Text = String.Empty
        SetUICulture(GlobalPPT.strLang)
        txtUserName.Focus()
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBTicketLoginFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)


            lblUserName.Text = rm.GetString("lblUserName.Text")
            lblPassword.Text = rm.GetString("lblPassword.Text")
            btnLogin.Text = rm.GetString("btnLogin.Text")
            btnclose.Text = rm.GetString("btnclose.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBTicketLoginFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

End Class