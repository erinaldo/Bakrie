<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperatingBudgetHourFrm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperatingBudgetHourFrm))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbOperatingBudgetByHour = New System.Windows.Forms.TabControl
        Me.tbOperatingBudget = New System.Windows.Forms.TabPage
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgOperatingHours = New System.Windows.Forms.DataGridView
        Me.OperatingBudgetByHoursID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoOfHours = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BalanceTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBudgetTotal = New System.Windows.Forms.Label
        Me.lblBudgetTotalL = New System.Windows.Forms.Label
        Me.grpButtons = New System.Windows.Forms.GroupBox
        Me.btnResetGeneral = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtRevDec = New System.Windows.Forms.TextBox
        Me.txtBudgetDec = New System.Windows.Forms.TextBox
        Me.lblRevisionDec = New System.Windows.Forms.Label
        Me.lblBudgetDec = New System.Windows.Forms.Label
        Me.txtRevAug = New System.Windows.Forms.TextBox
        Me.txtBudgetAug = New System.Windows.Forms.TextBox
        Me.lblRevisionAug = New System.Windows.Forms.Label
        Me.lblBudgetAug = New System.Windows.Forms.Label
        Me.txtRevApr = New System.Windows.Forms.TextBox
        Me.txtBudgetApr = New System.Windows.Forms.TextBox
        Me.lblRevisionApr = New System.Windows.Forms.Label
        Me.lblBudgetApr = New System.Windows.Forms.Label
        Me.txtRevNov = New System.Windows.Forms.TextBox
        Me.txtBudgetNov = New System.Windows.Forms.TextBox
        Me.lblRevisionNov = New System.Windows.Forms.Label
        Me.lblBudgetNov = New System.Windows.Forms.Label
        Me.txtRevJul = New System.Windows.Forms.TextBox
        Me.txtBudgetJul = New System.Windows.Forms.TextBox
        Me.lblRevisionJul = New System.Windows.Forms.Label
        Me.lblBudgetJul = New System.Windows.Forms.Label
        Me.txtRevMar = New System.Windows.Forms.TextBox
        Me.txtBudgetMar = New System.Windows.Forms.TextBox
        Me.lblRevisionMar = New System.Windows.Forms.Label
        Me.lblBudgetMar = New System.Windows.Forms.Label
        Me.txtRevOct = New System.Windows.Forms.TextBox
        Me.txtBudgetOct = New System.Windows.Forms.TextBox
        Me.lblRevisionOct = New System.Windows.Forms.Label
        Me.lblBudgetOct = New System.Windows.Forms.Label
        Me.txtRevJun = New System.Windows.Forms.TextBox
        Me.txtBudgetJun = New System.Windows.Forms.TextBox
        Me.lblRevisionJun = New System.Windows.Forms.Label
        Me.lblBudgetJun = New System.Windows.Forms.Label
        Me.txtRevFeb = New System.Windows.Forms.TextBox
        Me.txtBudgetFeb = New System.Windows.Forms.TextBox
        Me.lblRevisionFeb = New System.Windows.Forms.Label
        Me.lblBudgetFeb = New System.Windows.Forms.Label
        Me.txtRevSep = New System.Windows.Forms.TextBox
        Me.txtBudgetSep = New System.Windows.Forms.TextBox
        Me.lblRevisionSep = New System.Windows.Forms.Label
        Me.lblBudgetSep = New System.Windows.Forms.Label
        Me.txtRevMay = New System.Windows.Forms.TextBox
        Me.txtBudgetMay = New System.Windows.Forms.TextBox
        Me.lblRevisionMay = New System.Windows.Forms.Label
        Me.lblBudgetMay = New System.Windows.Forms.Label
        Me.txtRevJan = New System.Windows.Forms.TextBox
        Me.txtBudgetJan = New System.Windows.Forms.TextBox
        Me.lblRevisionJan = New System.Windows.Forms.Label
        Me.lblBudgetJan = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblRevision = New System.Windows.Forms.Label
        Me.lblBudget = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblStatusL = New System.Windows.Forms.Label
        Me.lblVersionNo = New System.Windows.Forms.Label
        Me.lblVersionNoL = New System.Windows.Forms.Label
        Me.lblDistribute = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNoOfHours = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblNoOfHours = New System.Windows.Forms.Label
        Me.lblDriverName = New System.Windows.Forms.Label
        Me.lblDriver = New System.Windows.Forms.Label
        Me.lblVHDescp = New System.Windows.Forms.Label
        Me.btnSearchVHNo = New System.Windows.Forms.Button
        Me.txtVHNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblVHNo = New System.Windows.Forms.Label
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.btnSearchVHGroup = New System.Windows.Forms.Button
        Me.txtVHGroup = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblVHGroup = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBudgetYear = New System.Windows.Forms.Label
        Me.lblBudgetyearL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.dgOperatingHourView = New System.Windows.Forms.DataGridView
        Me.OperatingBudgetByHoursIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYearView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAGroupView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescpView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHNoView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDescpView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpNameView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoOfHoursView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJanView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetFebView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMarView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAprView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJunView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJulView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAugView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetSepView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetOctView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetNovView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetDecView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJanView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevFebView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMarView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAprView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJunView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJulView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAugView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevSepView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevOctView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevNovView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevDecView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BalanceTotalView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNoView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlOperatingBudgetByHour = New Stepi.UI.ExtendedPanel
        Me.btnSearchVHNoView = New System.Windows.Forms.Button
        Me.lblVHDescpView = New System.Windows.Forms.Label
        Me.lblVHNoView = New System.Windows.Forms.Label
        Me.btnSearchVHGroupView = New System.Windows.Forms.Button
        Me.txtCOAGroupView = New System.Windows.Forms.TextBox
        Me.txtVHNoView = New System.Windows.Forms.TextBox
        Me.lblCOADescpView = New System.Windows.Forms.Label
        Me.lblCOAGroupV = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.lblBudgetYearV = New System.Windows.Forms.Label
        Me.cmbBudgetyear = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.cmsOperatingHours = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.tbOperatingBudgetByHour.SuspendLayout()
        Me.tbOperatingBudget.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgOperatingHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpButtons.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgOperatingHourView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOperatingBudgetByHour.SuspendLayout()
        Me.cmsOperatingHours.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbOperatingBudgetByHour
        '
        Me.tbOperatingBudgetByHour.Controls.Add(Me.tbOperatingBudget)
        Me.tbOperatingBudgetByHour.Controls.Add(Me.tbView)
        Me.tbOperatingBudgetByHour.Location = New System.Drawing.Point(14, 12)
        Me.tbOperatingBudgetByHour.Name = "tbOperatingBudgetByHour"
        Me.tbOperatingBudgetByHour.SelectedIndex = 0
        Me.tbOperatingBudgetByHour.Size = New System.Drawing.Size(975, 641)
        Me.tbOperatingBudgetByHour.TabIndex = 5
        '
        'tbOperatingBudget
        '
        Me.tbOperatingBudget.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbOperatingBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbOperatingBudget.Controls.Add(Me.btnSaveAll)
        Me.tbOperatingBudget.Controls.Add(Me.btnPrint)
        Me.tbOperatingBudget.Controls.Add(Me.btnResetAll)
        Me.tbOperatingBudget.Controls.Add(Me.btnClose)
        Me.tbOperatingBudget.Controls.Add(Me.GroupBox2)
        Me.tbOperatingBudget.Controls.Add(Me.lblBudgetTotal)
        Me.tbOperatingBudget.Controls.Add(Me.lblBudgetTotalL)
        Me.tbOperatingBudget.Controls.Add(Me.grpButtons)
        Me.tbOperatingBudget.Controls.Add(Me.GroupBox3)
        Me.tbOperatingBudget.Controls.Add(Me.GroupBox1)
        Me.tbOperatingBudget.Location = New System.Drawing.Point(4, 22)
        Me.tbOperatingBudget.Name = "tbOperatingBudget"
        Me.tbOperatingBudget.Padding = New System.Windows.Forms.Padding(3)
        Me.tbOperatingBudget.Size = New System.Drawing.Size(967, 615)
        Me.tbOperatingBudget.TabIndex = 0
        Me.tbOperatingBudget.Text = "Operating Hour"
        Me.tbOperatingBudget.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(538, 578)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(97, 25)
        Me.btnSaveAll.TabIndex = 24
        Me.btnSaveAll.Text = "Save "
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(838, 578)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 25)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(638, 578)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(97, 25)
        Me.btnResetAll.TabIndex = 25
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(738, 578)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(97, 25)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgOperatingHours)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 394)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(939, 173)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        '
        'dgOperatingHours
        '
        Me.dgOperatingHours.AllowUserToAddRows = False
        Me.dgOperatingHours.AllowUserToDeleteRows = False
        Me.dgOperatingHours.AllowUserToOrderColumns = True
        Me.dgOperatingHours.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgOperatingHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOperatingHours.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgOperatingHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOperatingHours.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OperatingBudgetByHoursID, Me.EstateID, Me.BudgetYear, Me.COAID, Me.COAGroup, Me.COADescp, Me.VHID, Me.VHNo, Me.VHDescp, Me.EmpName, Me.NoOfHours, Me.BudgetJan, Me.BudgetFeb, Me.BudgetMar, Me.BudgetApr, Me.BudgetMay, Me.BudgetJun, Me.BudgetJul, Me.BudgetAug, Me.BudgetSep, Me.BudgetOct, Me.BudgetNov, Me.BudgetDec, Me.RevJan, Me.RevFeb, Me.RevMar, Me.RevApr, Me.RevMay, Me.RevJun, Me.RevJul, Me.RevAug, Me.RevSep, Me.RevOct, Me.RevNov, Me.RevDec, Me.BalanceTotal, Me.Status, Me.VersionNo})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOperatingHours.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgOperatingHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOperatingHours.EnableHeadersVisualStyles = False
        Me.dgOperatingHours.Location = New System.Drawing.Point(3, 17)
        Me.dgOperatingHours.Name = "dgOperatingHours"
        Me.dgOperatingHours.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgOperatingHours.RowHeadersVisible = False
        Me.dgOperatingHours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOperatingHours.Size = New System.Drawing.Size(933, 153)
        Me.dgOperatingHours.TabIndex = 0
        Me.dgOperatingHours.TabStop = False
        '
        'OperatingBudgetByHoursID
        '
        Me.OperatingBudgetByHoursID.DataPropertyName = "OperatingBudgetByHoursID"
        Me.OperatingBudgetByHoursID.HeaderText = "OperatingBudgetByHoursID"
        Me.OperatingBudgetByHoursID.Name = "OperatingBudgetByHoursID"
        Me.OperatingBudgetByHoursID.Visible = False
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.Visible = False
        '
        'BudgetYear
        '
        Me.BudgetYear.DataPropertyName = "BudgetYear"
        Me.BudgetYear.HeaderText = "BudgetYear"
        Me.BudgetYear.Name = "BudgetYear"
        '
        'COAID
        '
        Me.COAID.DataPropertyName = "COAID"
        Me.COAID.HeaderText = "COAID"
        Me.COAID.Name = "COAID"
        Me.COAID.Visible = False
        '
        'COAGroup
        '
        Me.COAGroup.DataPropertyName = "COAGroup"
        Me.COAGroup.HeaderText = "VehicleGroup"
        Me.COAGroup.Name = "COAGroup"
        '
        'COADescp
        '
        Me.COADescp.DataPropertyName = "COADescp"
        Me.COADescp.HeaderText = "COADescp"
        Me.COADescp.Name = "COADescp"
        '
        'VHID
        '
        Me.VHID.DataPropertyName = "VHID"
        Me.VHID.HeaderText = "VHID"
        Me.VHID.Name = "VHID"
        Me.VHID.Visible = False
        '
        'VHNo
        '
        Me.VHNo.DataPropertyName = "VHNO"
        Me.VHNo.HeaderText = "VHNo"
        Me.VHNo.Name = "VHNo"
        '
        'VHDescp
        '
        Me.VHDescp.DataPropertyName = "VHDescp"
        Me.VHDescp.HeaderText = "VHDescp"
        Me.VHDescp.Name = "VHDescp"
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "Driver"
        Me.EmpName.Name = "EmpName"
        '
        'NoOfHours
        '
        Me.NoOfHours.DataPropertyName = "NoOfHours"
        Me.NoOfHours.HeaderText = "NoOfHours"
        Me.NoOfHours.Name = "NoOfHours"
        '
        'BudgetJan
        '
        Me.BudgetJan.DataPropertyName = "BudgetJan"
        Me.BudgetJan.HeaderText = "BudgetJan"
        Me.BudgetJan.Name = "BudgetJan"
        '
        'BudgetFeb
        '
        Me.BudgetFeb.DataPropertyName = "BudgetFeb"
        Me.BudgetFeb.HeaderText = "BudgetFeb"
        Me.BudgetFeb.Name = "BudgetFeb"
        '
        'BudgetMar
        '
        Me.BudgetMar.DataPropertyName = "BudgetMar"
        Me.BudgetMar.HeaderText = "BudgetMar"
        Me.BudgetMar.Name = "BudgetMar"
        '
        'BudgetApr
        '
        Me.BudgetApr.DataPropertyName = "BudgetApr"
        Me.BudgetApr.HeaderText = "BudgetApr"
        Me.BudgetApr.Name = "BudgetApr"
        '
        'BudgetMay
        '
        Me.BudgetMay.DataPropertyName = "BudgetMay"
        Me.BudgetMay.HeaderText = "BudgetMay"
        Me.BudgetMay.Name = "BudgetMay"
        '
        'BudgetJun
        '
        Me.BudgetJun.DataPropertyName = "BudgetJun"
        Me.BudgetJun.HeaderText = "BudgetJun"
        Me.BudgetJun.Name = "BudgetJun"
        '
        'BudgetJul
        '
        Me.BudgetJul.DataPropertyName = "BudgetJul"
        Me.BudgetJul.HeaderText = "BudgetJul"
        Me.BudgetJul.Name = "BudgetJul"
        '
        'BudgetAug
        '
        Me.BudgetAug.DataPropertyName = "BudgetAug"
        Me.BudgetAug.HeaderText = "BudgetAug"
        Me.BudgetAug.Name = "BudgetAug"
        '
        'BudgetSep
        '
        Me.BudgetSep.DataPropertyName = "BudgetSep"
        Me.BudgetSep.HeaderText = "BudgetSep"
        Me.BudgetSep.Name = "BudgetSep"
        '
        'BudgetOct
        '
        Me.BudgetOct.DataPropertyName = "BudgetOct"
        Me.BudgetOct.HeaderText = "BudgetOct"
        Me.BudgetOct.Name = "BudgetOct"
        '
        'BudgetNov
        '
        Me.BudgetNov.DataPropertyName = "BudgetNov"
        Me.BudgetNov.HeaderText = "BudgetNov"
        Me.BudgetNov.Name = "BudgetNov"
        '
        'BudgetDec
        '
        Me.BudgetDec.DataPropertyName = "BudgetDec"
        Me.BudgetDec.HeaderText = "BudgetDec"
        Me.BudgetDec.Name = "BudgetDec"
        '
        'RevJan
        '
        Me.RevJan.DataPropertyName = "RevJan"
        Me.RevJan.HeaderText = "RevJan"
        Me.RevJan.Name = "RevJan"
        '
        'RevFeb
        '
        Me.RevFeb.DataPropertyName = "RevFeb"
        Me.RevFeb.HeaderText = "RevFeb"
        Me.RevFeb.Name = "RevFeb"
        '
        'RevMar
        '
        Me.RevMar.DataPropertyName = "RevMar"
        Me.RevMar.HeaderText = "RevMar"
        Me.RevMar.Name = "RevMar"
        '
        'RevApr
        '
        Me.RevApr.DataPropertyName = "RevApr"
        Me.RevApr.HeaderText = "RevApr"
        Me.RevApr.Name = "RevApr"
        '
        'RevMay
        '
        Me.RevMay.DataPropertyName = "RevMay"
        Me.RevMay.HeaderText = "RevMay"
        Me.RevMay.Name = "RevMay"
        '
        'RevJun
        '
        Me.RevJun.DataPropertyName = "RevJun"
        Me.RevJun.HeaderText = "RevJun"
        Me.RevJun.Name = "RevJun"
        '
        'RevJul
        '
        Me.RevJul.DataPropertyName = "RevJul"
        Me.RevJul.HeaderText = "RevJul"
        Me.RevJul.Name = "RevJul"
        '
        'RevAug
        '
        Me.RevAug.DataPropertyName = "RevAug"
        Me.RevAug.HeaderText = "RevAug"
        Me.RevAug.Name = "RevAug"
        '
        'RevSep
        '
        Me.RevSep.DataPropertyName = "RevSep"
        Me.RevSep.HeaderText = "RevSep"
        Me.RevSep.Name = "RevSep"
        '
        'RevOct
        '
        Me.RevOct.DataPropertyName = "RevOct"
        Me.RevOct.HeaderText = "RevOct"
        Me.RevOct.Name = "RevOct"
        '
        'RevNov
        '
        Me.RevNov.DataPropertyName = "RevNov"
        Me.RevNov.HeaderText = "RevNov"
        Me.RevNov.Name = "RevNov"
        '
        'RevDec
        '
        Me.RevDec.DataPropertyName = "RevDec"
        Me.RevDec.HeaderText = "RevDec"
        Me.RevDec.Name = "RevDec"
        '
        'BalanceTotal
        '
        Me.BalanceTotal.DataPropertyName = "BalanceTotal"
        Me.BalanceTotal.HeaderText = "BalanceTotal"
        Me.BalanceTotal.Name = "BalanceTotal"
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'VersionNo
        '
        Me.VersionNo.DataPropertyName = "VersionNo"
        Me.VersionNo.HeaderText = "VersionNo"
        Me.VersionNo.Name = "VersionNo"
        '
        'lblBudgetTotal
        '
        Me.lblBudgetTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetTotal.Location = New System.Drawing.Point(822, 326)
        Me.lblBudgetTotal.Name = "lblBudgetTotal"
        Me.lblBudgetTotal.Size = New System.Drawing.Size(117, 21)
        Me.lblBudgetTotal.TabIndex = 91
        '
        'lblBudgetTotalL
        '
        Me.lblBudgetTotalL.AutoSize = True
        Me.lblBudgetTotalL.Location = New System.Drawing.Point(712, 330)
        Me.lblBudgetTotalL.Name = "lblBudgetTotalL"
        Me.lblBudgetTotalL.Size = New System.Drawing.Size(79, 13)
        Me.lblBudgetTotalL.TabIndex = 90
        Me.lblBudgetTotalL.Text = "Budget Total"
        '
        'grpButtons
        '
        Me.grpButtons.BackColor = System.Drawing.Color.Transparent
        Me.grpButtons.Controls.Add(Me.btnResetGeneral)
        Me.grpButtons.Controls.Add(Me.btnAdd)
        Me.grpButtons.Location = New System.Drawing.Point(702, 347)
        Me.grpButtons.Name = "grpButtons"
        Me.grpButtons.Size = New System.Drawing.Size(237, 44)
        Me.grpButtons.TabIndex = 23
        Me.grpButtons.TabStop = False
        '
        'btnResetGeneral
        '
        Me.btnResetGeneral.BackgroundImage = CType(resources.GetObject("btnResetGeneral.BackgroundImage"), System.Drawing.Image)
        Me.btnResetGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetGeneral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetGeneral.Image = CType(resources.GetObject("btnResetGeneral.Image"), System.Drawing.Image)
        Me.btnResetGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetGeneral.Location = New System.Drawing.Point(128, 13)
        Me.btnResetGeneral.Name = "btnResetGeneral"
        Me.btnResetGeneral.Size = New System.Drawing.Size(97, 25)
        Me.btnResetGeneral.TabIndex = 25
        Me.btnResetGeneral.Text = "Reset"
        Me.btnResetGeneral.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(13, 13)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 25)
        Me.btnAdd.TabIndex = 24
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.Label37)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtRevDec)
        Me.GroupBox3.Controls.Add(Me.txtBudgetDec)
        Me.GroupBox3.Controls.Add(Me.lblRevisionDec)
        Me.GroupBox3.Controls.Add(Me.lblBudgetDec)
        Me.GroupBox3.Controls.Add(Me.txtRevAug)
        Me.GroupBox3.Controls.Add(Me.txtBudgetAug)
        Me.GroupBox3.Controls.Add(Me.lblRevisionAug)
        Me.GroupBox3.Controls.Add(Me.lblBudgetAug)
        Me.GroupBox3.Controls.Add(Me.txtRevApr)
        Me.GroupBox3.Controls.Add(Me.txtBudgetApr)
        Me.GroupBox3.Controls.Add(Me.lblRevisionApr)
        Me.GroupBox3.Controls.Add(Me.lblBudgetApr)
        Me.GroupBox3.Controls.Add(Me.txtRevNov)
        Me.GroupBox3.Controls.Add(Me.txtBudgetNov)
        Me.GroupBox3.Controls.Add(Me.lblRevisionNov)
        Me.GroupBox3.Controls.Add(Me.lblBudgetNov)
        Me.GroupBox3.Controls.Add(Me.txtRevJul)
        Me.GroupBox3.Controls.Add(Me.txtBudgetJul)
        Me.GroupBox3.Controls.Add(Me.lblRevisionJul)
        Me.GroupBox3.Controls.Add(Me.lblBudgetJul)
        Me.GroupBox3.Controls.Add(Me.txtRevMar)
        Me.GroupBox3.Controls.Add(Me.txtBudgetMar)
        Me.GroupBox3.Controls.Add(Me.lblRevisionMar)
        Me.GroupBox3.Controls.Add(Me.lblBudgetMar)
        Me.GroupBox3.Controls.Add(Me.txtRevOct)
        Me.GroupBox3.Controls.Add(Me.txtBudgetOct)
        Me.GroupBox3.Controls.Add(Me.lblRevisionOct)
        Me.GroupBox3.Controls.Add(Me.lblBudgetOct)
        Me.GroupBox3.Controls.Add(Me.txtRevJun)
        Me.GroupBox3.Controls.Add(Me.txtBudgetJun)
        Me.GroupBox3.Controls.Add(Me.lblRevisionJun)
        Me.GroupBox3.Controls.Add(Me.lblBudgetJun)
        Me.GroupBox3.Controls.Add(Me.txtRevFeb)
        Me.GroupBox3.Controls.Add(Me.txtBudgetFeb)
        Me.GroupBox3.Controls.Add(Me.lblRevisionFeb)
        Me.GroupBox3.Controls.Add(Me.lblBudgetFeb)
        Me.GroupBox3.Controls.Add(Me.txtRevSep)
        Me.GroupBox3.Controls.Add(Me.txtBudgetSep)
        Me.GroupBox3.Controls.Add(Me.lblRevisionSep)
        Me.GroupBox3.Controls.Add(Me.lblBudgetSep)
        Me.GroupBox3.Controls.Add(Me.txtRevMay)
        Me.GroupBox3.Controls.Add(Me.txtBudgetMay)
        Me.GroupBox3.Controls.Add(Me.lblRevisionMay)
        Me.GroupBox3.Controls.Add(Me.lblBudgetMay)
        Me.GroupBox3.Controls.Add(Me.txtRevJan)
        Me.GroupBox3.Controls.Add(Me.txtBudgetJan)
        Me.GroupBox3.Controls.Add(Me.lblRevisionJan)
        Me.GroupBox3.Controls.Add(Me.lblBudgetJan)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.lblRevision)
        Me.GroupBox3.Controls.Add(Me.lblBudget)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 109)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(937, 211)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(364, 31)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 2349
        Me.Label24.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(364, 54)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 13)
        Me.Label25.TabIndex = 2348
        Me.Label25.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(364, 90)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 2347
        Me.Label26.Text = ":"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(364, 113)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 2346
        Me.Label27.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(364, 154)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 13)
        Me.Label28.TabIndex = 2345
        Me.Label28.Text = ":"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(364, 177)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 13)
        Me.Label31.TabIndex = 2344
        Me.Label31.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(583, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 2343
        Me.Label11.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(583, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 2342
        Me.Label13.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(583, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 13)
        Me.Label15.TabIndex = 2341
        Me.Label15.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(583, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 2340
        Me.Label17.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(583, 156)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(11, 13)
        Me.Label22.TabIndex = 2339
        Me.Label22.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(583, 179)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 2338
        Me.Label23.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(799, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 2337
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(799, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 2336
        Me.Label9.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(799, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 2335
        Me.Label5.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(799, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 2334
        Me.Label7.Text = ":"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(799, 156)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 2333
        Me.Label29.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(799, 179)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 13)
        Me.Label30.TabIndex = 2332
        Me.Label30.Text = ":"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(850, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 103
        Me.Label21.Text = "Hours"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(638, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 102
        Me.Label20.Text = "Hours"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(438, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 13)
        Me.Label19.TabIndex = 101
        Me.Label19.Text = "Hours"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(204, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "Hours"
        '
        'txtRevDec
        '
        Me.txtRevDec.Location = New System.Drawing.Point(814, 175)
        Me.txtRevDec.Name = "txtRevDec"
        Me.txtRevDec.Size = New System.Drawing.Size(116, 21)
        Me.txtRevDec.TabIndex = 39
        '
        'txtBudgetDec
        '
        Me.txtBudgetDec.Location = New System.Drawing.Point(814, 152)
        Me.txtBudgetDec.Name = "txtBudgetDec"
        Me.txtBudgetDec.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetDec.TabIndex = 22
        '
        'lblRevisionDec
        '
        Me.lblRevisionDec.AutoSize = True
        Me.lblRevisionDec.Location = New System.Drawing.Point(762, 180)
        Me.lblRevisionDec.Name = "lblRevisionDec"
        Me.lblRevisionDec.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionDec.TabIndex = 97
        Me.lblRevisionDec.Text = "Dec"
        '
        'lblBudgetDec
        '
        Me.lblBudgetDec.AutoSize = True
        Me.lblBudgetDec.Location = New System.Drawing.Point(762, 156)
        Me.lblBudgetDec.Name = "lblBudgetDec"
        Me.lblBudgetDec.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetDec.TabIndex = 96
        Me.lblBudgetDec.Text = "Dec"
        '
        'txtRevAug
        '
        Me.txtRevAug.Location = New System.Drawing.Point(816, 113)
        Me.txtRevAug.Name = "txtRevAug"
        Me.txtRevAug.Size = New System.Drawing.Size(116, 21)
        Me.txtRevAug.TabIndex = 35
        '
        'txtBudgetAug
        '
        Me.txtBudgetAug.Location = New System.Drawing.Point(816, 89)
        Me.txtBudgetAug.Name = "txtBudgetAug"
        Me.txtBudgetAug.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetAug.TabIndex = 18
        '
        'lblRevisionAug
        '
        Me.lblRevisionAug.AutoSize = True
        Me.lblRevisionAug.Location = New System.Drawing.Point(762, 117)
        Me.lblRevisionAug.Name = "lblRevisionAug"
        Me.lblRevisionAug.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionAug.TabIndex = 93
        Me.lblRevisionAug.Text = "Aug"
        '
        'lblBudgetAug
        '
        Me.lblBudgetAug.AutoSize = True
        Me.lblBudgetAug.Location = New System.Drawing.Point(762, 96)
        Me.lblBudgetAug.Name = "lblBudgetAug"
        Me.lblBudgetAug.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetAug.TabIndex = 92
        Me.lblBudgetAug.Text = "Aug"
        '
        'txtRevApr
        '
        Me.txtRevApr.Location = New System.Drawing.Point(816, 52)
        Me.txtRevApr.Name = "txtRevApr"
        Me.txtRevApr.Size = New System.Drawing.Size(116, 21)
        Me.txtRevApr.TabIndex = 31
        '
        'txtBudgetApr
        '
        Me.txtBudgetApr.Location = New System.Drawing.Point(816, 28)
        Me.txtBudgetApr.Name = "txtBudgetApr"
        Me.txtBudgetApr.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetApr.TabIndex = 14
        '
        'lblRevisionApr
        '
        Me.lblRevisionApr.AutoSize = True
        Me.lblRevisionApr.Location = New System.Drawing.Point(762, 55)
        Me.lblRevisionApr.Name = "lblRevisionApr"
        Me.lblRevisionApr.Size = New System.Drawing.Size(27, 13)
        Me.lblRevisionApr.TabIndex = 89
        Me.lblRevisionApr.Text = "Apr"
        '
        'lblBudgetApr
        '
        Me.lblBudgetApr.AutoSize = True
        Me.lblBudgetApr.Location = New System.Drawing.Point(762, 31)
        Me.lblBudgetApr.Name = "lblBudgetApr"
        Me.lblBudgetApr.Size = New System.Drawing.Size(27, 13)
        Me.lblBudgetApr.TabIndex = 88
        Me.lblBudgetApr.Text = "Apr"
        '
        'txtRevNov
        '
        Me.txtRevNov.Location = New System.Drawing.Point(600, 175)
        Me.txtRevNov.Name = "txtRevNov"
        Me.txtRevNov.Size = New System.Drawing.Size(116, 21)
        Me.txtRevNov.TabIndex = 38
        '
        'txtBudgetNov
        '
        Me.txtBudgetNov.Location = New System.Drawing.Point(600, 153)
        Me.txtBudgetNov.Name = "txtBudgetNov"
        Me.txtBudgetNov.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetNov.TabIndex = 21
        '
        'lblRevisionNov
        '
        Me.lblRevisionNov.AutoSize = True
        Me.lblRevisionNov.Location = New System.Drawing.Point(551, 180)
        Me.lblRevisionNov.Name = "lblRevisionNov"
        Me.lblRevisionNov.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionNov.TabIndex = 85
        Me.lblRevisionNov.Text = "Nov"
        '
        'lblBudgetNov
        '
        Me.lblBudgetNov.AutoSize = True
        Me.lblBudgetNov.Location = New System.Drawing.Point(551, 156)
        Me.lblBudgetNov.Name = "lblBudgetNov"
        Me.lblBudgetNov.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetNov.TabIndex = 84
        Me.lblBudgetNov.Text = "Nov"
        '
        'txtRevJul
        '
        Me.txtRevJul.Location = New System.Drawing.Point(600, 113)
        Me.txtRevJul.Name = "txtRevJul"
        Me.txtRevJul.Size = New System.Drawing.Size(116, 21)
        Me.txtRevJul.TabIndex = 34
        '
        'txtBudgetJul
        '
        Me.txtBudgetJul.Location = New System.Drawing.Point(600, 89)
        Me.txtBudgetJul.Name = "txtBudgetJul"
        Me.txtBudgetJul.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetJul.TabIndex = 17
        '
        'lblRevisionJul
        '
        Me.lblRevisionJul.AutoSize = True
        Me.lblRevisionJul.Location = New System.Drawing.Point(551, 119)
        Me.lblRevisionJul.Name = "lblRevisionJul"
        Me.lblRevisionJul.Size = New System.Drawing.Size(22, 13)
        Me.lblRevisionJul.TabIndex = 81
        Me.lblRevisionJul.Text = "Jul"
        '
        'lblBudgetJul
        '
        Me.lblBudgetJul.AutoSize = True
        Me.lblBudgetJul.Location = New System.Drawing.Point(551, 96)
        Me.lblBudgetJul.Name = "lblBudgetJul"
        Me.lblBudgetJul.Size = New System.Drawing.Size(22, 13)
        Me.lblBudgetJul.TabIndex = 80
        Me.lblBudgetJul.Text = "Jul"
        '
        'txtRevMar
        '
        Me.txtRevMar.Location = New System.Drawing.Point(600, 52)
        Me.txtRevMar.Name = "txtRevMar"
        Me.txtRevMar.Size = New System.Drawing.Size(116, 21)
        Me.txtRevMar.TabIndex = 30
        '
        'txtBudgetMar
        '
        Me.txtBudgetMar.Location = New System.Drawing.Point(600, 28)
        Me.txtBudgetMar.Name = "txtBudgetMar"
        Me.txtBudgetMar.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetMar.TabIndex = 13
        '
        'lblRevisionMar
        '
        Me.lblRevisionMar.AutoSize = True
        Me.lblRevisionMar.Location = New System.Drawing.Point(551, 56)
        Me.lblRevisionMar.Name = "lblRevisionMar"
        Me.lblRevisionMar.Size = New System.Drawing.Size(28, 13)
        Me.lblRevisionMar.TabIndex = 77
        Me.lblRevisionMar.Text = "Mar"
        '
        'lblBudgetMar
        '
        Me.lblBudgetMar.AutoSize = True
        Me.lblBudgetMar.Location = New System.Drawing.Point(551, 31)
        Me.lblBudgetMar.Name = "lblBudgetMar"
        Me.lblBudgetMar.Size = New System.Drawing.Size(28, 13)
        Me.lblBudgetMar.TabIndex = 76
        Me.lblBudgetMar.Text = "Mar"
        '
        'txtRevOct
        '
        Me.txtRevOct.Location = New System.Drawing.Point(390, 175)
        Me.txtRevOct.Name = "txtRevOct"
        Me.txtRevOct.Size = New System.Drawing.Size(116, 21)
        Me.txtRevOct.TabIndex = 37
        '
        'txtBudgetOct
        '
        Me.txtBudgetOct.Location = New System.Drawing.Point(390, 152)
        Me.txtBudgetOct.Name = "txtBudgetOct"
        Me.txtBudgetOct.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetOct.TabIndex = 20
        '
        'lblRevisionOct
        '
        Me.lblRevisionOct.AutoSize = True
        Me.lblRevisionOct.Location = New System.Drawing.Point(331, 179)
        Me.lblRevisionOct.Name = "lblRevisionOct"
        Me.lblRevisionOct.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionOct.TabIndex = 73
        Me.lblRevisionOct.Text = "Oct"
        '
        'lblBudgetOct
        '
        Me.lblBudgetOct.AutoSize = True
        Me.lblBudgetOct.Location = New System.Drawing.Point(331, 156)
        Me.lblBudgetOct.Name = "lblBudgetOct"
        Me.lblBudgetOct.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetOct.TabIndex = 72
        Me.lblBudgetOct.Text = "Oct"
        '
        'txtRevJun
        '
        Me.txtRevJun.Location = New System.Drawing.Point(390, 114)
        Me.txtRevJun.Name = "txtRevJun"
        Me.txtRevJun.Size = New System.Drawing.Size(116, 21)
        Me.txtRevJun.TabIndex = 33
        '
        'txtBudgetJun
        '
        Me.txtBudgetJun.Location = New System.Drawing.Point(390, 91)
        Me.txtBudgetJun.Name = "txtBudgetJun"
        Me.txtBudgetJun.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetJun.TabIndex = 16
        '
        'lblRevisionJun
        '
        Me.lblRevisionJun.AutoSize = True
        Me.lblRevisionJun.Location = New System.Drawing.Point(331, 117)
        Me.lblRevisionJun.Name = "lblRevisionJun"
        Me.lblRevisionJun.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJun.TabIndex = 69
        Me.lblRevisionJun.Text = "Jun"
        '
        'lblBudgetJun
        '
        Me.lblBudgetJun.AutoSize = True
        Me.lblBudgetJun.Location = New System.Drawing.Point(332, 94)
        Me.lblBudgetJun.Name = "lblBudgetJun"
        Me.lblBudgetJun.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJun.TabIndex = 68
        Me.lblBudgetJun.Text = "Jun"
        '
        'txtRevFeb
        '
        Me.txtRevFeb.Location = New System.Drawing.Point(390, 52)
        Me.txtRevFeb.Name = "txtRevFeb"
        Me.txtRevFeb.Size = New System.Drawing.Size(116, 21)
        Me.txtRevFeb.TabIndex = 29
        '
        'txtBudgetFeb
        '
        Me.txtBudgetFeb.Location = New System.Drawing.Point(390, 28)
        Me.txtBudgetFeb.Name = "txtBudgetFeb"
        Me.txtBudgetFeb.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetFeb.TabIndex = 12
        '
        'lblRevisionFeb
        '
        Me.lblRevisionFeb.AutoSize = True
        Me.lblRevisionFeb.Location = New System.Drawing.Point(331, 58)
        Me.lblRevisionFeb.Name = "lblRevisionFeb"
        Me.lblRevisionFeb.Size = New System.Drawing.Size(27, 13)
        Me.lblRevisionFeb.TabIndex = 65
        Me.lblRevisionFeb.Text = "Feb"
        '
        'lblBudgetFeb
        '
        Me.lblBudgetFeb.AutoSize = True
        Me.lblBudgetFeb.Location = New System.Drawing.Point(331, 33)
        Me.lblBudgetFeb.Name = "lblBudgetFeb"
        Me.lblBudgetFeb.Size = New System.Drawing.Size(27, 13)
        Me.lblBudgetFeb.TabIndex = 64
        Me.lblBudgetFeb.Text = "Feb"
        '
        'txtRevSep
        '
        Me.txtRevSep.Location = New System.Drawing.Point(166, 177)
        Me.txtRevSep.Name = "txtRevSep"
        Me.txtRevSep.Size = New System.Drawing.Size(116, 21)
        Me.txtRevSep.TabIndex = 36
        '
        'txtBudgetSep
        '
        Me.txtBudgetSep.Location = New System.Drawing.Point(166, 152)
        Me.txtBudgetSep.Name = "txtBudgetSep"
        Me.txtBudgetSep.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetSep.TabIndex = 19
        '
        'lblRevisionSep
        '
        Me.lblRevisionSep.AutoSize = True
        Me.lblRevisionSep.Location = New System.Drawing.Point(109, 180)
        Me.lblRevisionSep.Name = "lblRevisionSep"
        Me.lblRevisionSep.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionSep.TabIndex = 61
        Me.lblRevisionSep.Text = "Sep"
        '
        'lblBudgetSep
        '
        Me.lblBudgetSep.AutoSize = True
        Me.lblBudgetSep.Location = New System.Drawing.Point(109, 154)
        Me.lblBudgetSep.Name = "lblBudgetSep"
        Me.lblBudgetSep.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetSep.TabIndex = 60
        Me.lblBudgetSep.Text = "Sep"
        '
        'txtRevMay
        '
        Me.txtRevMay.Location = New System.Drawing.Point(166, 114)
        Me.txtRevMay.Name = "txtRevMay"
        Me.txtRevMay.Size = New System.Drawing.Size(116, 21)
        Me.txtRevMay.TabIndex = 32
        '
        'txtBudgetMay
        '
        Me.txtBudgetMay.Location = New System.Drawing.Point(166, 91)
        Me.txtBudgetMay.Name = "txtBudgetMay"
        Me.txtBudgetMay.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetMay.TabIndex = 15
        '
        'lblRevisionMay
        '
        Me.lblRevisionMay.AutoSize = True
        Me.lblRevisionMay.Location = New System.Drawing.Point(109, 117)
        Me.lblRevisionMay.Name = "lblRevisionMay"
        Me.lblRevisionMay.Size = New System.Drawing.Size(30, 13)
        Me.lblRevisionMay.TabIndex = 57
        Me.lblRevisionMay.Text = "May"
        '
        'lblBudgetMay
        '
        Me.lblBudgetMay.AutoSize = True
        Me.lblBudgetMay.Location = New System.Drawing.Point(109, 94)
        Me.lblBudgetMay.Name = "lblBudgetMay"
        Me.lblBudgetMay.Size = New System.Drawing.Size(30, 13)
        Me.lblBudgetMay.TabIndex = 56
        Me.lblBudgetMay.Text = "May"
        '
        'txtRevJan
        '
        Me.txtRevJan.Location = New System.Drawing.Point(166, 53)
        Me.txtRevJan.Name = "txtRevJan"
        Me.txtRevJan.Size = New System.Drawing.Size(116, 21)
        Me.txtRevJan.TabIndex = 28
        '
        'txtBudgetJan
        '
        Me.txtBudgetJan.Location = New System.Drawing.Point(166, 30)
        Me.txtBudgetJan.Name = "txtBudgetJan"
        Me.txtBudgetJan.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetJan.TabIndex = 11
        '
        'lblRevisionJan
        '
        Me.lblRevisionJan.AutoSize = True
        Me.lblRevisionJan.Location = New System.Drawing.Point(109, 56)
        Me.lblRevisionJan.Name = "lblRevisionJan"
        Me.lblRevisionJan.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJan.TabIndex = 53
        Me.lblRevisionJan.Text = "Jan"
        '
        'lblBudgetJan
        '
        Me.lblBudgetJan.AutoSize = True
        Me.lblBudgetJan.Location = New System.Drawing.Point(109, 33)
        Me.lblBudgetJan.Name = "lblBudgetJan"
        Me.lblBudgetJan.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJan.TabIndex = 52
        Me.lblBudgetJan.Text = "Jan"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Revision"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Budget"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Revision"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Budget"
        '
        'lblRevision
        '
        Me.lblRevision.AutoSize = True
        Me.lblRevision.Location = New System.Drawing.Point(10, 56)
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Size = New System.Drawing.Size(55, 13)
        Me.lblRevision.TabIndex = 3
        Me.lblRevision.Text = "Revision"
        '
        'lblBudget
        '
        Me.lblBudget.AutoSize = True
        Me.lblBudget.Location = New System.Drawing.Point(10, 31)
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.Size = New System.Drawing.Size(47, 13)
        Me.lblBudget.TabIndex = 2
        Me.lblBudget.Text = "Budget"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Controls.Add(Me.lblStatusL)
        Me.GroupBox1.Controls.Add(Me.lblVersionNo)
        Me.GroupBox1.Controls.Add(Me.lblVersionNoL)
        Me.GroupBox1.Controls.Add(Me.lblDistribute)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNoOfHours)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblNoOfHours)
        Me.GroupBox1.Controls.Add(Me.lblDriverName)
        Me.GroupBox1.Controls.Add(Me.lblDriver)
        Me.GroupBox1.Controls.Add(Me.lblVHDescp)
        Me.GroupBox1.Controls.Add(Me.lblCOADescp)
        Me.GroupBox1.Controls.Add(Me.btnSearchVHGroup)
        Me.GroupBox1.Controls.Add(Me.btnSearchVHNo)
        Me.GroupBox1.Controls.Add(Me.txtVHGroup)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtVHNo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblVHGroup)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblVHNo)
        Me.GroupBox1.Controls.Add(Me.lblBudgetYear)
        Me.GroupBox1.Controls.Add(Me.lblBudgetyearL)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(937, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(853, 36)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 20)
        Me.lblStatus.TabIndex = 187
        '
        'lblStatusL
        '
        Me.lblStatusL.AutoSize = True
        Me.lblStatusL.ForeColor = System.Drawing.Color.Black
        Me.lblStatusL.Location = New System.Drawing.Point(771, 39)
        Me.lblStatusL.Name = "lblStatusL"
        Me.lblStatusL.Size = New System.Drawing.Size(80, 13)
        Me.lblStatusL.TabIndex = 186
        Me.lblStatusL.Text = "Status        :"
        '
        'lblVersionNo
        '
        Me.lblVersionNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVersionNo.Location = New System.Drawing.Point(853, 12)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(83, 21)
        Me.lblVersionNo.TabIndex = 185
        '
        'lblVersionNoL
        '
        Me.lblVersionNoL.AutoSize = True
        Me.lblVersionNoL.ForeColor = System.Drawing.Color.Black
        Me.lblVersionNoL.Location = New System.Drawing.Point(771, 16)
        Me.lblVersionNoL.Name = "lblVersionNoL"
        Me.lblVersionNoL.Size = New System.Drawing.Size(78, 13)
        Me.lblVersionNoL.TabIndex = 184
        Me.lblVersionNoL.Text = "Version No :"
        '
        'lblDistribute
        '
        Me.lblDistribute.Location = New System.Drawing.Point(582, 71)
        Me.lblDistribute.Name = "lblDistribute"
        Me.lblDistribute.Size = New System.Drawing.Size(154, 23)
        Me.lblDistribute.TabIndex = 9
        Me.lblDistribute.Text = "Distribute to 12 Months"
        Me.lblDistribute.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(436, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 13)
        Me.Label6.TabIndex = 183
        Me.Label6.Text = ":"
        '
        'txtNoOfHours
        '
        Me.txtNoOfHours.Location = New System.Drawing.Point(456, 73)
        Me.txtNoOfHours.Name = "txtNoOfHours"
        Me.txtNoOfHours.Size = New System.Drawing.Size(124, 21)
        Me.txtNoOfHours.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(438, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = ":"
        '
        'lblNoOfHours
        '
        Me.lblNoOfHours.AutoSize = True
        Me.lblNoOfHours.ForeColor = System.Drawing.Color.Red
        Me.lblNoOfHours.Location = New System.Drawing.Point(346, 78)
        Me.lblNoOfHours.Name = "lblNoOfHours"
        Me.lblNoOfHours.Size = New System.Drawing.Size(76, 13)
        Me.lblNoOfHours.TabIndex = 181
        Me.lblNoOfHours.Text = "No Of Hours"
        '
        'lblDriverName
        '
        Me.lblDriverName.BackColor = System.Drawing.SystemColors.Control
        Me.lblDriverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDriverName.Location = New System.Drawing.Point(456, 44)
        Me.lblDriverName.Name = "lblDriverName"
        Me.lblDriverName.Size = New System.Drawing.Size(122, 21)
        Me.lblDriverName.TabIndex = 179
        '
        'lblDriver
        '
        Me.lblDriver.AutoSize = True
        Me.lblDriver.Location = New System.Drawing.Point(346, 46)
        Me.lblDriver.Name = "lblDriver"
        Me.lblDriver.Size = New System.Drawing.Size(43, 13)
        Me.lblDriver.TabIndex = 178
        Me.lblDriver.Text = "Driver"
        '
        'lblVHDescp
        '
        Me.lblVHDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblVHDescp.Location = New System.Drawing.Point(621, 12)
        Me.lblVHDescp.Name = "lblVHDescp"
        Me.lblVHDescp.Size = New System.Drawing.Size(144, 29)
        Me.lblVHDescp.TabIndex = 177
        '
        'btnSearchVHNo
        '
        Me.btnSearchVHNo.BackgroundImage = CType(resources.GetObject("btnSearchVHNo.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVHNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHNo.FlatAppearance.BorderSize = 0
        Me.btnSearchVHNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHNo.Location = New System.Drawing.Point(578, 2)
        Me.btnSearchVHNo.Name = "btnSearchVHNo"
        Me.btnSearchVHNo.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHNo.TabIndex = 176
        Me.btnSearchVHNo.TabStop = False
        Me.btnSearchVHNo.UseVisualStyleBackColor = True
        '
        'txtVHNo
        '
        Me.txtVHNo.Location = New System.Drawing.Point(456, 8)
        Me.txtVHNo.Name = "txtVHNo"
        Me.txtVHNo.Size = New System.Drawing.Size(122, 21)
        Me.txtVHNo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(436, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = ":"
        '
        'lblVHNo
        '
        Me.lblVHNo.AutoSize = True
        Me.lblVHNo.ForeColor = System.Drawing.Color.Red
        Me.lblVHNo.Location = New System.Drawing.Point(346, 14)
        Me.lblVHNo.Name = "lblVHNo"
        Me.lblVHNo.Size = New System.Drawing.Size(67, 13)
        Me.lblVHNo.TabIndex = 174
        Me.lblVHNo.Text = "Vehicle No"
        '
        'lblCOADescp
        '
        Me.lblCOADescp.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescp.Location = New System.Drawing.Point(113, 66)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(139, 26)
        Me.lblCOADescp.TabIndex = 172
        '
        'btnSearchVHGroup
        '
        Me.btnSearchVHGroup.BackgroundImage = CType(resources.GetObject("btnSearchVHGroup.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVHGroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHGroup.FlatAppearance.BorderSize = 0
        Me.btnSearchVHGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHGroup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHGroup.Location = New System.Drawing.Point(279, 36)
        Me.btnSearchVHGroup.Name = "btnSearchVHGroup"
        Me.btnSearchVHGroup.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHGroup.TabIndex = 171
        Me.btnSearchVHGroup.TabStop = False
        Me.btnSearchVHGroup.UseVisualStyleBackColor = True
        '
        'txtVHGroup
        '
        Me.txtVHGroup.Location = New System.Drawing.Point(116, 42)
        Me.txtVHGroup.Name = "txtVHGroup"
        Me.txtVHGroup.Size = New System.Drawing.Size(136, 21)
        Me.txtVHGroup.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = ":"
        '
        'lblVHGroup
        '
        Me.lblVHGroup.AutoSize = True
        Me.lblVHGroup.ForeColor = System.Drawing.Color.Red
        Me.lblVHGroup.Location = New System.Drawing.Point(10, 42)
        Me.lblVHGroup.Name = "lblVHGroup"
        Me.lblVHGroup.Size = New System.Drawing.Size(87, 13)
        Me.lblVHGroup.TabIndex = 169
        Me.lblVHGroup.Text = "Vehicle Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = ":"
        '
        'lblBudgetYear
        '
        Me.lblBudgetYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYear.Location = New System.Drawing.Point(114, 14)
        Me.lblBudgetYear.Name = "lblBudgetYear"
        Me.lblBudgetYear.Size = New System.Drawing.Size(138, 21)
        Me.lblBudgetYear.TabIndex = 166
        '
        'lblBudgetyearL
        '
        Me.lblBudgetyearL.AutoSize = True
        Me.lblBudgetyearL.Location = New System.Drawing.Point(10, 14)
        Me.lblBudgetyearL.Name = "lblBudgetyearL"
        Me.lblBudgetyearL.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetyearL.TabIndex = 165
        Me.lblBudgetyearL.Text = "Budget Year"
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.GroupBox5)
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(967, 615)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgOperatingHourView)
        Me.GroupBox5.Controls.Add(Me.pnlOperatingBudgetByHour)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(943, 428)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'dgOperatingHourView
        '
        Me.dgOperatingHourView.AllowUserToAddRows = False
        Me.dgOperatingHourView.AllowUserToDeleteRows = False
        Me.dgOperatingHourView.AllowUserToOrderColumns = True
        Me.dgOperatingHourView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgOperatingHourView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOperatingHourView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgOperatingHourView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOperatingHourView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OperatingBudgetByHoursIDView, Me.EstateIDView, Me.BudgetYearView, Me.COAIDView, Me.COAGroupView, Me.COADescpView, Me.VHNoView, Me.VHDescpView, Me.EmpNameView, Me.VHIDView, Me.NoOfHoursView, Me.BudgetJanView, Me.BudgetFebView, Me.BudgetMarView, Me.BudgetAprView, Me.BudgetMayView, Me.BudgetJunView, Me.BudgetJulView, Me.BudgetAugView, Me.BudgetSepView, Me.BudgetOctView, Me.BudgetNovView, Me.BudgetDecView, Me.RevJanView, Me.RevFebView, Me.RevMarView, Me.RevAprView, Me.RevMayView, Me.RevJunView, Me.RevJulView, Me.RevAugView, Me.RevSepView, Me.RevOctView, Me.RevNovView, Me.RevDecView, Me.BalanceTotalView, Me.VersionNoView, Me.StatusView})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOperatingHourView.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgOperatingHourView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOperatingHourView.EnableHeadersVisualStyles = False
        Me.dgOperatingHourView.Location = New System.Drawing.Point(3, 174)
        Me.dgOperatingHourView.Name = "dgOperatingHourView"
        Me.dgOperatingHourView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgOperatingHourView.RowHeadersVisible = False
        Me.dgOperatingHourView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOperatingHourView.Size = New System.Drawing.Size(937, 251)
        Me.dgOperatingHourView.TabIndex = 120
        Me.dgOperatingHourView.TabStop = False
        '
        'OperatingBudgetByHoursIDView
        '
        Me.OperatingBudgetByHoursIDView.DataPropertyName = "OperatingBudgetByHoursID"
        Me.OperatingBudgetByHoursIDView.HeaderText = "OperatingBudgetByHoursID"
        Me.OperatingBudgetByHoursIDView.Name = "OperatingBudgetByHoursIDView"
        Me.OperatingBudgetByHoursIDView.Visible = False
        '
        'EstateIDView
        '
        Me.EstateIDView.DataPropertyName = "EstateID"
        Me.EstateIDView.HeaderText = "EstateID"
        Me.EstateIDView.Name = "EstateIDView"
        Me.EstateIDView.Visible = False
        '
        'BudgetYearView
        '
        Me.BudgetYearView.DataPropertyName = "BudgetYear"
        Me.BudgetYearView.HeaderText = "BudgetYear"
        Me.BudgetYearView.Name = "BudgetYearView"
        '
        'COAIDView
        '
        Me.COAIDView.DataPropertyName = "COAID"
        Me.COAIDView.HeaderText = "COAID"
        Me.COAIDView.Name = "COAIDView"
        Me.COAIDView.Visible = False
        '
        'COAGroupView
        '
        Me.COAGroupView.DataPropertyName = "COAGroup"
        Me.COAGroupView.HeaderText = "VehicleGroup"
        Me.COAGroupView.Name = "COAGroupView"
        '
        'COADescpView
        '
        Me.COADescpView.DataPropertyName = "COADescp"
        Me.COADescpView.HeaderText = "COADescp"
        Me.COADescpView.Name = "COADescpView"
        '
        'VHNoView
        '
        Me.VHNoView.DataPropertyName = "VHNo"
        Me.VHNoView.HeaderText = "VHNO"
        Me.VHNoView.Name = "VHNoView"
        '
        'VHDescpView
        '
        Me.VHDescpView.DataPropertyName = "VHDescp"
        Me.VHDescpView.HeaderText = "VHDescp"
        Me.VHDescpView.Name = "VHDescpView"
        '
        'EmpNameView
        '
        Me.EmpNameView.DataPropertyName = "EmpName"
        Me.EmpNameView.HeaderText = "Driver"
        Me.EmpNameView.Name = "EmpNameView"
        '
        'VHIDView
        '
        Me.VHIDView.DataPropertyName = "VHID"
        Me.VHIDView.HeaderText = "VHID"
        Me.VHIDView.Name = "VHIDView"
        Me.VHIDView.Visible = False
        '
        'NoOfHoursView
        '
        Me.NoOfHoursView.DataPropertyName = "NoOfHours"
        Me.NoOfHoursView.HeaderText = "NoOfHours"
        Me.NoOfHoursView.Name = "NoOfHoursView"
        Me.NoOfHoursView.Visible = False
        '
        'BudgetJanView
        '
        Me.BudgetJanView.DataPropertyName = "BudgetJan"
        Me.BudgetJanView.HeaderText = "BudgetJan"
        Me.BudgetJanView.Name = "BudgetJanView"
        Me.BudgetJanView.Visible = False
        '
        'BudgetFebView
        '
        Me.BudgetFebView.DataPropertyName = "BudgetFeb"
        Me.BudgetFebView.HeaderText = "BudgetFeb"
        Me.BudgetFebView.Name = "BudgetFebView"
        Me.BudgetFebView.Visible = False
        '
        'BudgetMarView
        '
        Me.BudgetMarView.DataPropertyName = "BudgetMar"
        Me.BudgetMarView.HeaderText = "BudgetMar"
        Me.BudgetMarView.Name = "BudgetMarView"
        Me.BudgetMarView.Visible = False
        '
        'BudgetAprView
        '
        Me.BudgetAprView.DataPropertyName = "BudgetApr"
        Me.BudgetAprView.HeaderText = "BudgetApr"
        Me.BudgetAprView.Name = "BudgetAprView"
        Me.BudgetAprView.Visible = False
        '
        'BudgetMayView
        '
        Me.BudgetMayView.DataPropertyName = "BudgetMay"
        Me.BudgetMayView.HeaderText = "BudgetMay"
        Me.BudgetMayView.Name = "BudgetMayView"
        Me.BudgetMayView.Visible = False
        '
        'BudgetJunView
        '
        Me.BudgetJunView.DataPropertyName = "BudgetJun"
        Me.BudgetJunView.HeaderText = "BudgetJun"
        Me.BudgetJunView.Name = "BudgetJunView"
        Me.BudgetJunView.Visible = False
        '
        'BudgetJulView
        '
        Me.BudgetJulView.DataPropertyName = "BudgetJul"
        Me.BudgetJulView.HeaderText = "BudgetJul"
        Me.BudgetJulView.Name = "BudgetJulView"
        Me.BudgetJulView.Visible = False
        '
        'BudgetAugView
        '
        Me.BudgetAugView.DataPropertyName = "BudgetAug"
        Me.BudgetAugView.HeaderText = "BudgetAug"
        Me.BudgetAugView.Name = "BudgetAugView"
        Me.BudgetAugView.Visible = False
        '
        'BudgetSepView
        '
        Me.BudgetSepView.DataPropertyName = "BudgetSep"
        Me.BudgetSepView.HeaderText = "BudgetSep"
        Me.BudgetSepView.Name = "BudgetSepView"
        Me.BudgetSepView.Visible = False
        '
        'BudgetOctView
        '
        Me.BudgetOctView.DataPropertyName = "BudgetOct"
        Me.BudgetOctView.HeaderText = "BudgetOct"
        Me.BudgetOctView.Name = "BudgetOctView"
        Me.BudgetOctView.Visible = False
        '
        'BudgetNovView
        '
        Me.BudgetNovView.DataPropertyName = "BudgetNov"
        Me.BudgetNovView.HeaderText = "BudgetNov"
        Me.BudgetNovView.Name = "BudgetNovView"
        Me.BudgetNovView.Visible = False
        '
        'BudgetDecView
        '
        Me.BudgetDecView.DataPropertyName = "BudgetDec"
        Me.BudgetDecView.HeaderText = "BudgetDec"
        Me.BudgetDecView.Name = "BudgetDecView"
        Me.BudgetDecView.Visible = False
        '
        'RevJanView
        '
        Me.RevJanView.DataPropertyName = "RevJan"
        Me.RevJanView.HeaderText = "RevJan"
        Me.RevJanView.Name = "RevJanView"
        Me.RevJanView.Visible = False
        '
        'RevFebView
        '
        Me.RevFebView.DataPropertyName = "RevFeb"
        Me.RevFebView.HeaderText = "RevFeb"
        Me.RevFebView.Name = "RevFebView"
        Me.RevFebView.Visible = False
        '
        'RevMarView
        '
        Me.RevMarView.DataPropertyName = "RevMar"
        Me.RevMarView.HeaderText = "RevMar"
        Me.RevMarView.Name = "RevMarView"
        Me.RevMarView.Visible = False
        '
        'RevAprView
        '
        Me.RevAprView.DataPropertyName = "RevApr"
        Me.RevAprView.HeaderText = "RevApr"
        Me.RevAprView.Name = "RevAprView"
        Me.RevAprView.Visible = False
        '
        'RevMayView
        '
        Me.RevMayView.DataPropertyName = "RevMay"
        Me.RevMayView.HeaderText = "RevMay"
        Me.RevMayView.Name = "RevMayView"
        Me.RevMayView.Visible = False
        '
        'RevJunView
        '
        Me.RevJunView.DataPropertyName = "RevJun"
        Me.RevJunView.HeaderText = "RevJun"
        Me.RevJunView.Name = "RevJunView"
        Me.RevJunView.Visible = False
        '
        'RevJulView
        '
        Me.RevJulView.DataPropertyName = "RevJul"
        Me.RevJulView.HeaderText = "RevJul"
        Me.RevJulView.Name = "RevJulView"
        Me.RevJulView.Visible = False
        '
        'RevAugView
        '
        Me.RevAugView.DataPropertyName = "RevAug"
        Me.RevAugView.HeaderText = "RevAug"
        Me.RevAugView.Name = "RevAugView"
        Me.RevAugView.Visible = False
        '
        'RevSepView
        '
        Me.RevSepView.DataPropertyName = "RevSep"
        Me.RevSepView.HeaderText = "RevSep"
        Me.RevSepView.Name = "RevSepView"
        Me.RevSepView.Visible = False
        '
        'RevOctView
        '
        Me.RevOctView.DataPropertyName = "RevOct"
        Me.RevOctView.HeaderText = "RevOct"
        Me.RevOctView.Name = "RevOctView"
        Me.RevOctView.Visible = False
        '
        'RevNovView
        '
        Me.RevNovView.DataPropertyName = "RevNov"
        Me.RevNovView.HeaderText = "RevNov"
        Me.RevNovView.Name = "RevNovView"
        Me.RevNovView.Visible = False
        '
        'RevDecView
        '
        Me.RevDecView.DataPropertyName = "RevDec"
        Me.RevDecView.HeaderText = "RevDec"
        Me.RevDecView.Name = "RevDecView"
        Me.RevDecView.Visible = False
        '
        'BalanceTotalView
        '
        Me.BalanceTotalView.DataPropertyName = "BalanceTotal"
        Me.BalanceTotalView.HeaderText = "BalanceTotal"
        Me.BalanceTotalView.Name = "BalanceTotalView"
        '
        'VersionNoView
        '
        Me.VersionNoView.DataPropertyName = "VersionNo"
        Me.VersionNoView.HeaderText = "VersionNo"
        Me.VersionNoView.Name = "VersionNoView"
        '
        'StatusView
        '
        Me.StatusView.DataPropertyName = "Status"
        Me.StatusView.HeaderText = "Status"
        Me.StatusView.Name = "StatusView"
        '
        'pnlOperatingBudgetByHour
        '
        Me.pnlOperatingBudgetByHour.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlOperatingBudgetByHour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlOperatingBudgetByHour.BorderColor = System.Drawing.Color.Gray
        Me.pnlOperatingBudgetByHour.CaptionColorOne = System.Drawing.Color.White
        Me.pnlOperatingBudgetByHour.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlOperatingBudgetByHour.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOperatingBudgetByHour.CaptionSize = 40
        Me.pnlOperatingBudgetByHour.CaptionText = "Search Operating Budget By Hours"
        Me.pnlOperatingBudgetByHour.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.btnSearchVHNoView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.lblVHDescpView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.lblVHNoView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.btnSearchVHGroupView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.txtCOAGroupView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.txtVHNoView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.lblCOADescpView)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.lblCOAGroupV)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.lblsearchCategory)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.lblBudgetYearV)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.cmbBudgetyear)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.btnSearch)
        Me.pnlOperatingBudgetByHour.Controls.Add(Me.btnviewReport)
        Me.pnlOperatingBudgetByHour.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlOperatingBudgetByHour.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlOperatingBudgetByHour.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlOperatingBudgetByHour.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOperatingBudgetByHour.ForeColor = System.Drawing.Color.Black
        Me.pnlOperatingBudgetByHour.Location = New System.Drawing.Point(3, 17)
        Me.pnlOperatingBudgetByHour.Name = "pnlOperatingBudgetByHour"
        Me.pnlOperatingBudgetByHour.Size = New System.Drawing.Size(937, 157)
        Me.pnlOperatingBudgetByHour.TabIndex = 119
        '
        'btnSearchVHNoView
        '
        Me.btnSearchVHNoView.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnSearchVHNoView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHNoView.FlatAppearance.BorderSize = 0
        Me.btnSearchVHNoView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHNoView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHNoView.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHNoView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHNoView.Location = New System.Drawing.Point(557, 76)
        Me.btnSearchVHNoView.Name = "btnSearchVHNoView"
        Me.btnSearchVHNoView.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHNoView.TabIndex = 141
        Me.btnSearchVHNoView.TabStop = False
        Me.btnSearchVHNoView.UseVisualStyleBackColor = True
        '
        'lblVHDescpView
        '
        Me.lblVHDescpView.ForeColor = System.Drawing.Color.Blue
        Me.lblVHDescpView.Location = New System.Drawing.Point(619, 80)
        Me.lblVHDescpView.Name = "lblVHDescpView"
        Me.lblVHDescpView.Size = New System.Drawing.Size(148, 29)
        Me.lblVHDescpView.TabIndex = 169
        '
        'lblVHNoView
        '
        Me.lblVHNoView.AutoSize = True
        Me.lblVHNoView.ForeColor = System.Drawing.Color.Black
        Me.lblVHNoView.Location = New System.Drawing.Point(428, 64)
        Me.lblVHNoView.Name = "lblVHNoView"
        Me.lblVHNoView.Size = New System.Drawing.Size(42, 13)
        Me.lblVHNoView.TabIndex = 166
        Me.lblVHNoView.Text = "VH No"
        '
        'btnSearchVHGroupView
        '
        Me.btnSearchVHGroupView.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnSearchVHGroupView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHGroupView.FlatAppearance.BorderSize = 0
        Me.btnSearchVHGroupView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHGroupView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHGroupView.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHGroupView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHGroupView.Location = New System.Drawing.Point(346, 73)
        Me.btnSearchVHGroupView.Name = "btnSearchVHGroupView"
        Me.btnSearchVHGroupView.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHGroupView.TabIndex = 140
        Me.btnSearchVHGroupView.TabStop = False
        Me.btnSearchVHGroupView.UseVisualStyleBackColor = True
        '
        'txtCOAGroupView
        '
        Me.txtCOAGroupView.Location = New System.Drawing.Point(221, 80)
        Me.txtCOAGroupView.MaxLength = 50
        Me.txtCOAGroupView.Name = "txtCOAGroupView"
        Me.txtCOAGroupView.Size = New System.Drawing.Size(115, 21)
        Me.txtCOAGroupView.TabIndex = 1
        '
        'txtVHNoView
        '
        Me.txtVHNoView.Location = New System.Drawing.Point(422, 81)
        Me.txtVHNoView.Name = "txtVHNoView"
        Me.txtVHNoView.Size = New System.Drawing.Size(116, 21)
        Me.txtVHNoView.TabIndex = 2
        '
        'lblCOADescpView
        '
        Me.lblCOADescpView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOADescpView.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescpView.Location = New System.Drawing.Point(218, 118)
        Me.lblCOADescpView.Name = "lblCOADescpView"
        Me.lblCOADescpView.Size = New System.Drawing.Size(171, 18)
        Me.lblCOADescpView.TabIndex = 141
        Me.lblCOADescpView.Text = "COA Descp"
        '
        'lblCOAGroupV
        '
        Me.lblCOAGroupV.AutoSize = True
        Me.lblCOAGroupV.ForeColor = System.Drawing.Color.Black
        Me.lblCOAGroupV.Location = New System.Drawing.Point(217, 64)
        Me.lblCOAGroupV.Name = "lblCOAGroupV"
        Me.lblCOAGroupV.Size = New System.Drawing.Size(58, 13)
        Me.lblCOAGroupV.TabIndex = 118
        Me.lblCOAGroupV.Text = "VHGroup"
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.ForeColor = System.Drawing.Color.Black
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'lblBudgetYearV
        '
        Me.lblBudgetYearV.AutoSize = True
        Me.lblBudgetYearV.ForeColor = System.Drawing.Color.Black
        Me.lblBudgetYearV.Location = New System.Drawing.Point(105, 64)
        Me.lblBudgetYearV.Name = "lblBudgetYearV"
        Me.lblBudgetYearV.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetYearV.TabIndex = 16
        Me.lblBudgetYearV.Text = "Budget Year"
        '
        'cmbBudgetyear
        '
        Me.cmbBudgetyear.FormattingEnabled = True
        Me.cmbBudgetyear.Location = New System.Drawing.Point(108, 80)
        Me.cmbBudgetyear.Name = "cmbBudgetyear"
        Me.cmbBudgetyear.Size = New System.Drawing.Size(89, 21)
        Me.cmbBudgetyear.TabIndex = 117
        Me.cmbBudgetyear.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(602, 118)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 25)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(745, 118)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(147, 25)
        Me.btnviewReport.TabIndex = 4
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'cmsOperatingHours
        '
        Me.cmsOperatingHours.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsOperatingHours.Name = "cmsITNIn"
        Me.cmsOperatingHours.Size = New System.Drawing.Size(160, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditUpdateToolStripMenuItem
        '
        Me.EditUpdateToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditUpdateToolStripMenuItem.Image = CType(resources.GetObject("EditUpdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditUpdateToolStripMenuItem.Name = "EditUpdateToolStripMenuItem"
        Me.EditUpdateToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditUpdateToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(149, 33)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 13)
        Me.Label32.TabIndex = 2355
        Me.Label32.Text = ":"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(149, 56)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 13)
        Me.Label33.TabIndex = 2354
        Me.Label33.Text = ":"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(149, 92)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 13)
        Me.Label34.TabIndex = 2353
        Me.Label34.Text = ":"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(149, 115)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(11, 13)
        Me.Label35.TabIndex = 2352
        Me.Label35.Text = ":"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(149, 156)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 13)
        Me.Label36.TabIndex = 2351
        Me.Label36.Text = ":"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(149, 179)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(11, 13)
        Me.Label37.TabIndex = 2350
        Me.Label37.Text = ":"
        '
        'OperatingBudgetHourFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1026, 665)
        Me.ContextMenuStrip = Me.cmsOperatingHours
        Me.Controls.Add(Me.tbOperatingBudgetByHour)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "OperatingBudgetHourFrm"
        Me.Text = "OperatingBudgetByCost"
        Me.tbOperatingBudgetByHour.ResumeLayout(False)
        Me.tbOperatingBudget.ResumeLayout(False)
        Me.tbOperatingBudget.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgOperatingHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpButtons.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgOperatingHourView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOperatingBudgetByHour.ResumeLayout(False)
        Me.pnlOperatingBudgetByHour.PerformLayout()
        Me.cmsOperatingHours.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbOperatingBudgetByHour As System.Windows.Forms.TabControl
    Friend WithEvents tbOperatingBudget As System.Windows.Forms.TabPage
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblVHDescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHNo As System.Windows.Forms.Button
    Friend WithEvents txtVHNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVHNo As System.Windows.Forms.Label
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHGroup As System.Windows.Forms.Button
    Friend WithEvents txtVHGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVHGroup As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYear As System.Windows.Forms.Label
    Friend WithEvents lblBudgetyearL As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNoOfHours As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNoOfHours As System.Windows.Forms.Label
    Friend WithEvents lblDriverName As System.Windows.Forms.Label
    Friend WithEvents lblDriver As System.Windows.Forms.Label
    Friend WithEvents lblDistribute As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRevDec As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetDec As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionDec As System.Windows.Forms.Label
    Friend WithEvents lblBudgetDec As System.Windows.Forms.Label
    Friend WithEvents txtRevAug As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetAug As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionAug As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAug As System.Windows.Forms.Label
    Friend WithEvents txtRevApr As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetApr As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionApr As System.Windows.Forms.Label
    Friend WithEvents lblBudgetApr As System.Windows.Forms.Label
    Friend WithEvents txtRevNov As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetNov As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionNov As System.Windows.Forms.Label
    Friend WithEvents lblBudgetNov As System.Windows.Forms.Label
    Friend WithEvents txtRevJul As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJul As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionJul As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJul As System.Windows.Forms.Label
    Friend WithEvents txtRevMar As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMar As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionMar As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMar As System.Windows.Forms.Label
    Friend WithEvents txtRevOct As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetOct As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionOct As System.Windows.Forms.Label
    Friend WithEvents lblBudgetOct As System.Windows.Forms.Label
    Friend WithEvents txtRevJun As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJun As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionJun As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJun As System.Windows.Forms.Label
    Friend WithEvents txtRevFeb As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetFeb As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionFeb As System.Windows.Forms.Label
    Friend WithEvents lblBudgetFeb As System.Windows.Forms.Label
    Friend WithEvents txtRevSep As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetSep As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionSep As System.Windows.Forms.Label
    Friend WithEvents lblBudgetSep As System.Windows.Forms.Label
    Friend WithEvents txtRevMay As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMay As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionMay As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMay As System.Windows.Forms.Label
    Friend WithEvents txtRevJan As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJan As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionJan As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJan As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBudgetTotal As System.Windows.Forms.Label
    Friend WithEvents lblBudgetTotalL As System.Windows.Forms.Label
    Friend WithEvents grpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetGeneral As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dgOperatingHours As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOperatingBudgetByHour As Stepi.UI.ExtendedPanel
    Friend WithEvents btnSearchVHNoView As System.Windows.Forms.Button
    Friend WithEvents lblVHDescpView As System.Windows.Forms.Label
    Friend WithEvents lblVHNoView As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHGroupView As System.Windows.Forms.Button
    Friend WithEvents txtVHNoView As System.Windows.Forms.TextBox
    Friend WithEvents txtCOAGroupView As System.Windows.Forms.TextBox
    Friend WithEvents lblCOADescpView As System.Windows.Forms.Label
    Friend WithEvents lblCOAGroupV As System.Windows.Forms.Label
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYearV As System.Windows.Forms.Label
    Friend WithEvents cmbBudgetyear As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatusL As System.Windows.Forms.Label
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblVersionNoL As System.Windows.Forms.Label
    Friend WithEvents cmsOperatingHours As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperatingBudgetByHoursID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOfHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgOperatingHourView As System.Windows.Forms.DataGridView
    Friend WithEvents OperatingBudgetByHoursIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYearView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAGroupView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescpView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHNoView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDescpView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpNameView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoOfHoursView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJanView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetFebView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMarView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAprView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJunView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJulView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAugView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetSepView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetOctView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNovView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetDecView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJanView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevFebView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMarView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAprView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJunView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJulView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAugView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevSepView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevOctView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNovView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDecView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceTotalView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNoView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
End Class
