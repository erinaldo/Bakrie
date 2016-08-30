<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewReport))
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.txtSource1 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.AutoScroll = True
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRV.DisplayBackgroundEdge = False
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.ForeColor = System.Drawing.Color.Silver
        Me.CRV.Location = New System.Drawing.Point(0, 0)
        Me.CRV.Name = "CRV"
        Me.CRV.ReuseParameterValuesOnRefresh = True
        Me.CRV.SelectionFormula = ""
        Me.CRV.ShowCloseButton = False
        Me.CRV.ShowGroupTreeButton = False
        Me.CRV.ShowParameterPanelButton = False
        Me.CRV.Size = New System.Drawing.Size(1070, 691)
        Me.CRV.TabIndex = 0
        Me.CRV.ViewTimeSelectionFormula = ""
        '
        'txtSource1
        '
        Me.txtSource1.Location = New System.Drawing.Point(539, 480)
        Me.txtSource1.Name = "txtSource1"
        Me.txtSource1.Size = New System.Drawing.Size(340, 20)
        Me.txtSource1.TabIndex = 121
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtSource)
        Me.Panel2.Controls.Add(Me.txtFormula)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 691)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1070, 10)
        Me.Panel2.TabIndex = 5
        Me.Panel2.Visible = False
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(536, 6)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(246, 20)
        Me.txtSource.TabIndex = 125
        Me.txtSource.Visible = False
        '
        'txtFormula
        '
        Me.txtFormula.Location = New System.Drawing.Point(257, 5)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(269, 20)
        Me.txtFormula.TabIndex = 122
        Me.txtFormula.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(128, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 30)
        Me.btnClose.TabIndex = 119
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(12, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 30)
        Me.Button1.TabIndex = 120
        Me.Button1.Text = "&Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(271, -46)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 30)
        Me.Button3.TabIndex = 124
        Me.Button3.Text = "&Show Report"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'ViewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 701)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.txtSource1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ViewReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtSource1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
End Class
