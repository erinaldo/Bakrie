<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginFrm
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()        
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginFrm))
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtUName = New System.Windows.Forms.TextBox()
        Me.lblUname = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.cmbEstate = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cmbLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.lblEstate = New System.Windows.Forms.Label()
        Me.lstAyear = New System.Windows.Forms.ListBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lstAMonth = New System.Windows.Forms.ListBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.cmbServer = New System.Windows.Forms.ComboBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblVersionNo = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.btnLogin, "btnLogin")
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'txtUName
        '
        resources.ApplyResources(Me.txtUName, "txtUName")
        Me.txtUName.Name = "txtUName"
        '
        'lblUname
        '
        resources.ApplyResources(Me.lblUname, "lblUname")
        Me.lblUname.BackColor = System.Drawing.Color.White
        Me.lblUname.ForeColor = System.Drawing.Color.DimGray
        Me.lblUname.Name = "lblUname"
        '
        'lblPass
        '
        resources.ApplyResources(Me.lblPass, "lblPass")
        Me.lblPass.BackColor = System.Drawing.Color.White
        Me.lblPass.ForeColor = System.Drawing.Color.DimGray
        Me.lblPass.Name = "lblPass"
        '
        'txtPass
        '
        resources.ApplyResources(Me.txtPass, "txtPass")
        Me.txtPass.Name = "txtPass"
        Me.txtPass.UseSystemPasswordChar = True
        '
        'cmbEstate
        '
        Me.cmbEstate.FormattingEnabled = True
        resources.ApplyResources(Me.cmbEstate, "cmbEstate")
        Me.cmbEstate.Name = "cmbEstate"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'cmbLanguage
        '
        Me.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.Items.AddRange(New Object() {resources.GetString("cmbLanguage.Items"), resources.GetString("cmbLanguage.Items1")})
        resources.ApplyResources(Me.cmbLanguage, "cmbLanguage")
        Me.cmbLanguage.Name = "cmbLanguage"
        '
        'lblLanguage
        '
        resources.ApplyResources(Me.lblLanguage, "lblLanguage")
        Me.lblLanguage.BackColor = System.Drawing.Color.White
        Me.lblLanguage.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLanguage.Name = "lblLanguage"
        '
        'lblEstate
        '
        resources.ApplyResources(Me.lblEstate, "lblEstate")
        Me.lblEstate.BackColor = System.Drawing.Color.White
        Me.lblEstate.ForeColor = System.Drawing.Color.DimGray
        Me.lblEstate.Name = "lblEstate"
        '
        'lstAyear
        '
        Me.lstAyear.FormattingEnabled = True
        resources.ApplyResources(Me.lstAyear, "lstAyear")
        Me.lstAyear.Name = "lstAyear"
        '
        'lblYear
        '
        resources.ApplyResources(Me.lblYear, "lblYear")
        Me.lblYear.BackColor = System.Drawing.Color.White
        Me.lblYear.ForeColor = System.Drawing.Color.DimGray
        Me.lblYear.Name = "lblYear"
        '
        'lstAMonth
        '
        Me.lstAMonth.FormattingEnabled = True
        Me.lstAMonth.Items.AddRange(New Object() {resources.GetString("lstAMonth.Items"), resources.GetString("lstAMonth.Items1"), resources.GetString("lstAMonth.Items2"), resources.GetString("lstAMonth.Items3"), resources.GetString("lstAMonth.Items4"), resources.GetString("lstAMonth.Items5"), resources.GetString("lstAMonth.Items6"), resources.GetString("lstAMonth.Items7"), resources.GetString("lstAMonth.Items8"), resources.GetString("lstAMonth.Items9"), resources.GetString("lstAMonth.Items10"), resources.GetString("lstAMonth.Items11")})
        resources.ApplyResources(Me.lstAMonth, "lstAMonth")
        Me.lstAMonth.Name = "lstAMonth"
        '
        'lblMonth
        '
        resources.ApplyResources(Me.lblMonth, "lblMonth")
        Me.lblMonth.BackColor = System.Drawing.Color.White
        Me.lblMonth.ForeColor = System.Drawing.Color.DimGray
        Me.lblMonth.Name = "lblMonth"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblServer)
        Me.GroupBox1.Controls.Add(Me.cmbServer)
        Me.GroupBox1.Controls.Add(Me.cmbLanguage)
        Me.GroupBox1.Controls.Add(Me.btnLogin)
        Me.GroupBox1.Controls.Add(Me.lblMonth)
        Me.GroupBox1.Controls.Add(Me.txtUName)
        Me.GroupBox1.Controls.Add(Me.lstAMonth)
        Me.GroupBox1.Controls.Add(Me.lblUname)
        Me.GroupBox1.Controls.Add(Me.lblYear)
        Me.GroupBox1.Controls.Add(Me.lblPass)
        Me.GroupBox1.Controls.Add(Me.lstAyear)
        Me.GroupBox1.Controls.Add(Me.txtPass)
        Me.GroupBox1.Controls.Add(Me.lblEstate)
        Me.GroupBox1.Controls.Add(Me.cmbEstate)
        Me.GroupBox1.Controls.Add(Me.lblLanguage)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'lblServer
        '
        resources.ApplyResources(Me.lblServer, "lblServer")
        Me.lblServer.BackColor = System.Drawing.Color.White
        Me.lblServer.ForeColor = System.Drawing.Color.DimGray
        Me.lblServer.Name = "lblServer"
        '
        'cmbServer
        '
        Me.cmbServer.FormattingEnabled = True
        resources.ApplyResources(Me.cmbServer, "cmbServer")
        Me.cmbServer.Name = "cmbServer"
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Name = "lblVersion"
        '
        'lblVersionNo
        '
        resources.ApplyResources(Me.lblVersionNo, "lblVersionNo")
        Me.lblVersionNo.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionNo.ForeColor = System.Drawing.Color.White
        Me.lblVersionNo.Name = "lblVersionNo"
        '
        'lblTitle
        '
        resources.ApplyResources(Me.lblTitle, "lblTitle")
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Name = "lblTitle"
        '
        'LoginFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ControlBox = False
        Me.Controls.Add(Me.lblVersionNo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginFrm"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtUName As System.Windows.Forms.TextBox
    Friend WithEvents lblUname As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstate As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents cmbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lstAyear As System.Windows.Forms.ListBox
    Friend WithEvents lblEstate As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lstAMonth As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents cmbServer As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
End Class
