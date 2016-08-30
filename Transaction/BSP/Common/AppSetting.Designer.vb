<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppSetting
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppSetting))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.gpChangePassword = New System.Windows.Forms.GroupBox()
        Me.btnSaveAndExit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDSN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.dgwDatabaseList = New System.Windows.Forms.DataGridView()
        Me.gpChangePassword.SuspendLayout()
        CType(Me.dgwDatabaseList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(118, 158)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 25)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(320, 158)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(95, 25)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'gpChangePassword
        '
        Me.gpChangePassword.BackColor = System.Drawing.Color.Transparent
        Me.gpChangePassword.Controls.Add(Me.btnSaveAndExit)
        Me.gpChangePassword.Controls.Add(Me.btnDelete)
        Me.gpChangePassword.Controls.Add(Me.txtID)
        Me.gpChangePassword.Controls.Add(Me.btnSave)
        Me.gpChangePassword.Controls.Add(Me.Label6)
        Me.gpChangePassword.Controls.Add(Me.btnReset)
        Me.gpChangePassword.Controls.Add(Me.txtDB)
        Me.gpChangePassword.Controls.Add(Me.Label5)
        Me.gpChangePassword.Controls.Add(Me.txtDSN)
        Me.gpChangePassword.Controls.Add(Me.Label4)
        Me.gpChangePassword.Controls.Add(Me.txtPassword)
        Me.gpChangePassword.Controls.Add(Me.Label3)
        Me.gpChangePassword.Controls.Add(Me.txtUser)
        Me.gpChangePassword.Controls.Add(Me.Label2)
        Me.gpChangePassword.Controls.Add(Me.txtServer)
        Me.gpChangePassword.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChangePassword.Location = New System.Drawing.Point(12, 12)
        Me.gpChangePassword.Name = "gpChangePassword"
        Me.gpChangePassword.Size = New System.Drawing.Size(665, 196)
        Me.gpChangePassword.TabIndex = 2
        Me.gpChangePassword.TabStop = False
        Me.gpChangePassword.Text = "Database Settings"
        '
        'btnSaveAndExit
        '
        Me.btnSaveAndExit.BackgroundImage = CType(resources.GetObject("btnSaveAndExit.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAndExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAndExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAndExit.Image = CType(resources.GetObject("btnSaveAndExit.Image"), System.Drawing.Image)
        Me.btnSaveAndExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAndExit.Location = New System.Drawing.Point(454, 158)
        Me.btnSaveAndExit.Name = "btnSaveAndExit"
        Me.btnSaveAndExit.Size = New System.Drawing.Size(196, 25)
        Me.btnSaveAndExit.TabIndex = 113
        Me.btnSaveAndExit.Text = "Save and Exit"
        Me.btnSaveAndExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(219, 158)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(95, 25)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(454, 25)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(196, 21)
        Me.txtID.TabIndex = 112
        Me.txtID.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(28, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Database"
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(117, 51)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(298, 21)
        Me.txtDB.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "DSN"
        '
        'txtDSN
        '
        Me.txtDSN.Location = New System.Drawing.Point(117, 131)
        Me.txtDSN.Name = "txtDSN"
        Me.txtDSN.Size = New System.Drawing.Size(298, 21)
        Me.txtDSN.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(117, 104)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(298, 21)
        Me.txtPassword.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "User"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(117, 77)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(298, 21)
        Me.txtUser.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "DB Server"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(117, 25)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(298, 21)
        Me.txtServer.TabIndex = 1
        '
        'dgwDatabaseList
        '
        Me.dgwDatabaseList.AllowUserToAddRows = False
        Me.dgwDatabaseList.AllowUserToDeleteRows = False
        Me.dgwDatabaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwDatabaseList.Location = New System.Drawing.Point(12, 214)
        Me.dgwDatabaseList.MultiSelect = False
        Me.dgwDatabaseList.Name = "dgwDatabaseList"
        Me.dgwDatabaseList.ReadOnly = True
        Me.dgwDatabaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwDatabaseList.Size = New System.Drawing.Size(665, 170)
        Me.dgwDatabaseList.TabIndex = 4
        '
        'AppSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(699, 396)
        Me.Controls.Add(Me.dgwDatabaseList)
        Me.Controls.Add(Me.gpChangePassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AppSetting"
        Me.Text = "Database Settings"
        Me.gpChangePassword.ResumeLayout(False)
        Me.gpChangePassword.PerformLayout()
        CType(Me.dgwDatabaseList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents gpChangePassword As System.Windows.Forms.GroupBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDSN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents dgwDatabaseList As System.Windows.Forms.DataGridView
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSaveAndExit As System.Windows.Forms.Button
End Class
