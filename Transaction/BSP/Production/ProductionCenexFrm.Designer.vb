<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionCenexFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionCenexFrm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmbStorageRm = New System.Windows.Forms.ComboBox()
        Me.lblstoragerm = New System.Windows.Forms.Label()
        Me.cmbProductType = New System.Windows.Forms.ComboBox()
        Me.lblproducttype = New System.Windows.Forms.Label()
        Me.txtShiftHours = New System.Windows.Forms.TextBox()
        Me.lblshifthours = New System.Windows.Forms.Label()
        Me.txtBreakDownTime = New System.Windows.Forms.TextBox()
        Me.txtEndTime = New System.Windows.Forms.TextBox()
        Me.cmbStartTime = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLossesGain = New System.Windows.Forms.TextBox()
        Me.lbllossesgain = New System.Windows.Forms.Label()
        Me.txtConcentratedDry = New System.Windows.Forms.TextBox()
        Me.lblconcentratedd = New System.Windows.Forms.Label()
        Me.txtConcentratedWet = New System.Windows.Forms.TextBox()
        Me.lblconcentratedw = New System.Windows.Forms.Label()
        Me.txtWashing = New System.Windows.Forms.TextBox()
        Me.txtLimbah = New System.Windows.Forms.TextBox()
        Me.lblwashing = New System.Windows.Forms.Label()
        Me.lbllimbah = New System.Windows.Forms.Label()
        Me.txtSludge = New System.Windows.Forms.TextBox()
        Me.txtSkimDry = New System.Windows.Forms.TextBox()
        Me.lblsludge = New System.Windows.Forms.Label()
        Me.lblskimdry = New System.Windows.Forms.Label()
        Me.txtLatexProcessDry = New System.Windows.Forms.TextBox()
        Me.txtLatexProcessWet = New System.Windows.Forms.TextBox()
        Me.lbllatexdry = New System.Windows.Forms.Label()
        Me.lbllatexwet = New System.Windows.Forms.Label()
        Me.wbbtndelete = New System.Windows.Forms.Button()
        Me.wbbtnadd = New System.Windows.Forms.Button()
        Me.txtReceivedDry = New System.Windows.Forms.TextBox()
        Me.txtReceivedWet = New System.Windows.Forms.TextBox()
        Me.lblreceivedd = New System.Windows.Forms.Label()
        Me.lblreceivedw = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtAssistant = New System.Windows.Forms.TextBox()
        Me.lblstoptime = New System.Windows.Forms.Label()
        Me.lblassistant = New System.Windows.Forms.Label()
        Me.lblstarttime = New System.Windows.Forms.Label()
        Me.lblbreakdowntime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lbltest = New System.Windows.Forms.Label()
        Me.dgvtransfer = New System.Windows.Forms.DataGridView()
        Me.dgtxtWet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvtransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.TabPage1.Controls.Add(Me.cmbStorageRm)
        Me.TabPage1.Controls.Add(Me.lblstoragerm)
        Me.TabPage1.Controls.Add(Me.cmbProductType)
        Me.TabPage1.Controls.Add(Me.lblproducttype)
        Me.TabPage1.Controls.Add(Me.txtShiftHours)
        Me.TabPage1.Controls.Add(Me.lblshifthours)
        Me.TabPage1.Controls.Add(Me.txtBreakDownTime)
        Me.TabPage1.Controls.Add(Me.txtEndTime)
        Me.TabPage1.Controls.Add(Me.cmbStartTime)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dtpDate)
        Me.TabPage1.Controls.Add(Me.txtAssistant)
        Me.TabPage1.Controls.Add(Me.lblstoptime)
        Me.TabPage1.Controls.Add(Me.lblassistant)
        Me.TabPage1.Controls.Add(Me.lblstarttime)
        Me.TabPage1.Controls.Add(Me.lblbreakdowntime)
        Me.TabPage1.Controls.Add(Me.lbldate)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmbStorageRm
        '
        resources.ApplyResources(Me.cmbStorageRm, "cmbStorageRm")
        Me.cmbStorageRm.FormattingEnabled = True
        Me.cmbStorageRm.Name = "cmbStorageRm"
        '
        'lblstoragerm
        '
        resources.ApplyResources(Me.lblstoragerm, "lblstoragerm")
        Me.lblstoragerm.Name = "lblstoragerm"
        '
        'cmbProductType
        '
        resources.ApplyResources(Me.cmbProductType, "cmbProductType")
        Me.cmbProductType.FormattingEnabled = True
        Me.cmbProductType.Name = "cmbProductType"
        '
        'lblproducttype
        '
        resources.ApplyResources(Me.lblproducttype, "lblproducttype")
        Me.lblproducttype.Name = "lblproducttype"
        '
        'txtShiftHours
        '
        resources.ApplyResources(Me.txtShiftHours, "txtShiftHours")
        Me.txtShiftHours.Name = "txtShiftHours"
        '
        'lblshifthours
        '
        resources.ApplyResources(Me.lblshifthours, "lblshifthours")
        Me.lblshifthours.Name = "lblshifthours"
        '
        'txtBreakDownTime
        '
        resources.ApplyResources(Me.txtBreakDownTime, "txtBreakDownTime")
        Me.txtBreakDownTime.Name = "txtBreakDownTime"
        '
        'txtEndTime
        '
        resources.ApplyResources(Me.txtEndTime, "txtEndTime")
        Me.txtEndTime.Name = "txtEndTime"
        '
        'cmbStartTime
        '
        resources.ApplyResources(Me.cmbStartTime, "cmbStartTime")
        Me.cmbStartTime.Name = "cmbStartTime"
        '
        'Button4
        '
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Button4.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.Button4.Name = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Button3.Image = Global.BSP.My.Resources.Resources.user_add
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Button2.Image = Global.BSP.My.Resources.Resources.refresh
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Button1.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.dgvtransfer)
        Me.GroupBox1.Controls.Add(Me.txtLossesGain)
        Me.GroupBox1.Controls.Add(Me.lbllossesgain)
        Me.GroupBox1.Controls.Add(Me.txtConcentratedDry)
        Me.GroupBox1.Controls.Add(Me.lblconcentratedd)
        Me.GroupBox1.Controls.Add(Me.txtConcentratedWet)
        Me.GroupBox1.Controls.Add(Me.lblconcentratedw)
        Me.GroupBox1.Controls.Add(Me.txtWashing)
        Me.GroupBox1.Controls.Add(Me.txtLimbah)
        Me.GroupBox1.Controls.Add(Me.lblwashing)
        Me.GroupBox1.Controls.Add(Me.lbllimbah)
        Me.GroupBox1.Controls.Add(Me.txtSludge)
        Me.GroupBox1.Controls.Add(Me.txtSkimDry)
        Me.GroupBox1.Controls.Add(Me.lblsludge)
        Me.GroupBox1.Controls.Add(Me.lblskimdry)
        Me.GroupBox1.Controls.Add(Me.txtLatexProcessDry)
        Me.GroupBox1.Controls.Add(Me.txtLatexProcessWet)
        Me.GroupBox1.Controls.Add(Me.lbllatexdry)
        Me.GroupBox1.Controls.Add(Me.lbllatexwet)
        Me.GroupBox1.Controls.Add(Me.wbbtndelete)
        Me.GroupBox1.Controls.Add(Me.wbbtnadd)
        Me.GroupBox1.Controls.Add(Me.txtReceivedDry)
        Me.GroupBox1.Controls.Add(Me.txtReceivedWet)
        Me.GroupBox1.Controls.Add(Me.lblreceivedd)
        Me.GroupBox1.Controls.Add(Me.lblreceivedw)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtLossesGain
        '
        resources.ApplyResources(Me.txtLossesGain, "txtLossesGain")
        Me.txtLossesGain.Name = "txtLossesGain"
        '
        'lbllossesgain
        '
        resources.ApplyResources(Me.lbllossesgain, "lbllossesgain")
        Me.lbllossesgain.Name = "lbllossesgain"
        '
        'txtConcentratedDry
        '
        resources.ApplyResources(Me.txtConcentratedDry, "txtConcentratedDry")
        Me.txtConcentratedDry.Name = "txtConcentratedDry"
        '
        'lblconcentratedd
        '
        resources.ApplyResources(Me.lblconcentratedd, "lblconcentratedd")
        Me.lblconcentratedd.Name = "lblconcentratedd"
        '
        'txtConcentratedWet
        '
        resources.ApplyResources(Me.txtConcentratedWet, "txtConcentratedWet")
        Me.txtConcentratedWet.Name = "txtConcentratedWet"
        '
        'lblconcentratedw
        '
        resources.ApplyResources(Me.lblconcentratedw, "lblconcentratedw")
        Me.lblconcentratedw.Name = "lblconcentratedw"
        '
        'txtWashing
        '
        resources.ApplyResources(Me.txtWashing, "txtWashing")
        Me.txtWashing.Name = "txtWashing"
        '
        'txtLimbah
        '
        resources.ApplyResources(Me.txtLimbah, "txtLimbah")
        Me.txtLimbah.Name = "txtLimbah"
        '
        'lblwashing
        '
        resources.ApplyResources(Me.lblwashing, "lblwashing")
        Me.lblwashing.Name = "lblwashing"
        '
        'lbllimbah
        '
        resources.ApplyResources(Me.lbllimbah, "lbllimbah")
        Me.lbllimbah.Name = "lbllimbah"
        '
        'txtSludge
        '
        resources.ApplyResources(Me.txtSludge, "txtSludge")
        Me.txtSludge.Name = "txtSludge"
        '
        'txtSkimDry
        '
        resources.ApplyResources(Me.txtSkimDry, "txtSkimDry")
        Me.txtSkimDry.Name = "txtSkimDry"
        '
        'lblsludge
        '
        resources.ApplyResources(Me.lblsludge, "lblsludge")
        Me.lblsludge.Name = "lblsludge"
        '
        'lblskimdry
        '
        resources.ApplyResources(Me.lblskimdry, "lblskimdry")
        Me.lblskimdry.Name = "lblskimdry"
        '
        'txtLatexProcessDry
        '
        resources.ApplyResources(Me.txtLatexProcessDry, "txtLatexProcessDry")
        Me.txtLatexProcessDry.Name = "txtLatexProcessDry"
        '
        'txtLatexProcessWet
        '
        resources.ApplyResources(Me.txtLatexProcessWet, "txtLatexProcessWet")
        Me.txtLatexProcessWet.Name = "txtLatexProcessWet"
        '
        'lbllatexdry
        '
        resources.ApplyResources(Me.lbllatexdry, "lbllatexdry")
        Me.lbllatexdry.Name = "lbllatexdry"
        '
        'lbllatexwet
        '
        resources.ApplyResources(Me.lbllatexwet, "lbllatexwet")
        Me.lbllatexwet.Name = "lbllatexwet"
        '
        'wbbtndelete
        '
        resources.ApplyResources(Me.wbbtndelete, "wbbtndelete")
        Me.wbbtndelete.Name = "wbbtndelete"
        Me.wbbtndelete.UseVisualStyleBackColor = True
        '
        'wbbtnadd
        '
        resources.ApplyResources(Me.wbbtnadd, "wbbtnadd")
        Me.wbbtnadd.Name = "wbbtnadd"
        Me.wbbtnadd.UseVisualStyleBackColor = True
        '
        'txtReceivedDry
        '
        resources.ApplyResources(Me.txtReceivedDry, "txtReceivedDry")
        Me.txtReceivedDry.Name = "txtReceivedDry"
        '
        'txtReceivedWet
        '
        resources.ApplyResources(Me.txtReceivedWet, "txtReceivedWet")
        Me.txtReceivedWet.Name = "txtReceivedWet"
        '
        'lblreceivedd
        '
        resources.ApplyResources(Me.lblreceivedd, "lblreceivedd")
        Me.lblreceivedd.Name = "lblreceivedd"
        '
        'lblreceivedw
        '
        resources.ApplyResources(Me.lblreceivedw, "lblreceivedw")
        Me.lblreceivedw.Name = "lblreceivedw"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        '
        'txtAssistant
        '
        resources.ApplyResources(Me.txtAssistant, "txtAssistant")
        Me.txtAssistant.Name = "txtAssistant"
        '
        'lblstoptime
        '
        resources.ApplyResources(Me.lblstoptime, "lblstoptime")
        Me.lblstoptime.Name = "lblstoptime"
        '
        'lblassistant
        '
        resources.ApplyResources(Me.lblassistant, "lblassistant")
        Me.lblassistant.Name = "lblassistant"
        '
        'lblstarttime
        '
        resources.ApplyResources(Me.lblstarttime, "lblstarttime")
        Me.lblstarttime.Name = "lblstarttime"
        '
        'lblbreakdowntime
        '
        resources.ApplyResources(Me.lblbreakdowntime, "lblbreakdowntime")
        Me.lblbreakdowntime.Name = "lblbreakdowntime"
        '
        'lbldate
        '
        resources.ApplyResources(Me.lbldate, "lbldate")
        Me.lbldate.Name = "lbldate"
        '
        'TabPage2
        '
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lbltest
        '
        resources.ApplyResources(Me.lbltest, "lbltest")
        Me.lbltest.Name = "lbltest"
        '
        'dgvtransfer
        '
        resources.ApplyResources(Me.dgvtransfer, "dgvtransfer")
        Me.dgvtransfer.AllowUserToAddRows = False
        Me.dgvtransfer.AllowUserToDeleteRows = False
        Me.dgvtransfer.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvtransfer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvtransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvtransfer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvtransfer.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvtransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvtransfer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtransfer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvtransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtransfer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtWet, Me.dgtxtDry})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvtransfer.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvtransfer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvtransfer.EnableHeadersVisualStyles = False
        Me.dgvtransfer.GridColor = System.Drawing.Color.Gray
        Me.dgvtransfer.MultiSelect = False
        Me.dgvtransfer.Name = "dgvtransfer"
        Me.dgvtransfer.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtransfer.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvtransfer.RowHeadersVisible = False
        Me.dgvtransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvtransfer.ShowCellErrors = False
        Me.dgvtransfer.TabStop = False
        '
        'dgtxtWet
        '
        resources.ApplyResources(Me.dgtxtWet, "dgtxtWet")
        Me.dgtxtWet.Name = "dgtxtWet"
        Me.dgtxtWet.ReadOnly = True
        '
        'dgtxtDry
        '
        resources.ApplyResources(Me.dgtxtDry, "dgtxtDry")
        Me.dgtxtDry.Name = "dgtxtDry"
        Me.dgtxtDry.ReadOnly = True
        '
        'ProductionCenexFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionCenexFrm"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvtransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtShiftHours As System.Windows.Forms.TextBox
    Friend WithEvents lblshifthours As System.Windows.Forms.Label
    Friend WithEvents txtBreakDownTime As System.Windows.Forms.TextBox
    Friend WithEvents txtEndTime As System.Windows.Forms.TextBox
    Friend WithEvents cmbStartTime As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents wbbtndelete As System.Windows.Forms.Button
    Friend WithEvents wbbtnadd As System.Windows.Forms.Button
    Friend WithEvents txtReceivedDry As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedWet As System.Windows.Forms.TextBox
    Friend WithEvents lblreceivedd As System.Windows.Forms.Label
    Friend WithEvents lblreceivedw As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAssistant As System.Windows.Forms.TextBox
    Friend WithEvents lblstoptime As System.Windows.Forms.Label
    Friend WithEvents lblassistant As System.Windows.Forms.Label
    Friend WithEvents lblstarttime As System.Windows.Forms.Label
    Friend WithEvents lblbreakdowntime As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmbStorageRm As System.Windows.Forms.ComboBox
    Friend WithEvents lblstoragerm As System.Windows.Forms.Label
    Friend WithEvents cmbProductType As System.Windows.Forms.ComboBox
    Friend WithEvents lblproducttype As System.Windows.Forms.Label
    Friend WithEvents txtLossesGain As System.Windows.Forms.TextBox
    Friend WithEvents lbllossesgain As System.Windows.Forms.Label
    Friend WithEvents txtConcentratedDry As System.Windows.Forms.TextBox
    Friend WithEvents lblconcentratedd As System.Windows.Forms.Label
    Friend WithEvents txtConcentratedWet As System.Windows.Forms.TextBox
    Friend WithEvents lblconcentratedw As System.Windows.Forms.Label
    Friend WithEvents txtWashing As System.Windows.Forms.TextBox
    Friend WithEvents txtLimbah As System.Windows.Forms.TextBox
    Friend WithEvents lblwashing As System.Windows.Forms.Label
    Friend WithEvents lbllimbah As System.Windows.Forms.Label
    Friend WithEvents txtSludge As System.Windows.Forms.TextBox
    Friend WithEvents txtSkimDry As System.Windows.Forms.TextBox
    Friend WithEvents lblsludge As System.Windows.Forms.Label
    Friend WithEvents lblskimdry As System.Windows.Forms.Label
    Friend WithEvents txtLatexProcessDry As System.Windows.Forms.TextBox
    Friend WithEvents txtLatexProcessWet As System.Windows.Forms.TextBox
    Friend WithEvents lbllatexdry As System.Windows.Forms.Label
    Friend WithEvents lbllatexwet As System.Windows.Forms.Label
    Friend WithEvents lbltest As System.Windows.Forms.Label
    Friend WithEvents dgvtransfer As System.Windows.Forms.DataGridView
    Friend WithEvents dgtxtWet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDry As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
