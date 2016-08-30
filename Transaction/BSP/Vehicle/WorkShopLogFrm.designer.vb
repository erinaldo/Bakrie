<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkShopLogFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkShopLogFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.plIB1 = New System.Windows.Forms.Panel
        Me.tbcWorkshop = New System.Windows.Forms.TabControl
        Me.tbpgAdd = New System.Windows.Forms.TabPage
        Me.gbAddReset = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSaveOrUpdate = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.gbListOfWorkshopLog = New System.Windows.Forms.GroupBox
        Me.dgWorkshopRunningLog = New System.Windows.Forms.DataGridView
        Me.LogDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Workshop = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vehicle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalHrs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Activity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountCodeDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Posted = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbWorkshopLog = New System.Windows.Forms.GroupBox
        Me.txtEndHr = New System.Windows.Forms.TextBox
        Me.txtEndMin = New System.Windows.Forms.TextBox
        Me.txtStartMin = New System.Windows.Forms.TextBox
        Me.txtStartHr = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblShowVehicleDesc = New System.Windows.Forms.Label
        Me.lblShowWorkshopDesc = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblOldAccountCode = New System.Windows.Forms.Label
        Me.cmbWorkshopCode = New System.Windows.Forms.ComboBox
        Me.lblShowAccountCodeDesc = New System.Windows.Forms.Label
        Me.lblShowOldAccountCode = New System.Windows.Forms.Label
        Me.gbDivYopSubBlock = New System.Windows.Forms.GroupBox
        Me.txtYOP = New System.Windows.Forms.TextBox
        Me.lblBlock = New System.Windows.Forms.Label
        Me.lblColon8 = New System.Windows.Forms.Label
        Me.lblYOP = New System.Windows.Forms.Label
        Me.lblColon7 = New System.Windows.Forms.Label
        Me.lblDIV = New System.Windows.Forms.Label
        Me.lblColon6 = New System.Windows.Forms.Label
        Me.ibtnLookUpDIV = New System.Windows.Forms.Button
        Me.txtSubBlock = New System.Windows.Forms.TextBox
        Me.txtDIV = New System.Windows.Forms.TextBox
        Me.ibtnLookUpSubBlock = New System.Windows.Forms.Button
        Me.gbTAnalysis = New System.Windows.Forms.GroupBox
        Me.lblT1Name = New System.Windows.Forms.Label
        Me.lblT2Name = New System.Windows.Forms.Label
        Me.lblT3Name = New System.Windows.Forms.Label
        Me.lblT4Name = New System.Windows.Forms.Label
        Me.lblT0Name = New System.Windows.Forms.Label
        Me.ibtnSearchTAnalysisT4 = New System.Windows.Forms.Button
        Me.lblColon19 = New System.Windows.Forms.Label
        Me.lblTAnalysisT4 = New System.Windows.Forms.Label
        Me.lblColon18 = New System.Windows.Forms.Label
        Me.lblTAnalysisT3 = New System.Windows.Forms.Label
        Me.lblColon17 = New System.Windows.Forms.Label
        Me.lblTAnalysisT2 = New System.Windows.Forms.Label
        Me.lblColon15 = New System.Windows.Forms.Label
        Me.lblTAnalysisT1 = New System.Windows.Forms.Label
        Me.lblColon16 = New System.Windows.Forms.Label
        Me.lblTAnalysisT0 = New System.Windows.Forms.Label
        Me.ibtnSearchTAnalysisT0 = New System.Windows.Forms.Button
        Me.txtT0 = New System.Windows.Forms.TextBox
        Me.ibtnSearchTAnalysisT1 = New System.Windows.Forms.Button
        Me.txtT4 = New System.Windows.Forms.TextBox
        Me.txtT1 = New System.Windows.Forms.TextBox
        Me.ibtnSearchTAnalysisT2 = New System.Windows.Forms.Button
        Me.txtT3 = New System.Windows.Forms.TextBox
        Me.txtT2 = New System.Windows.Forms.TextBox
        Me.ibtnSearchTAnalysisT3 = New System.Windows.Forms.Button
        Me.lblColon12 = New System.Windows.Forms.Label
        Me.lblColon11 = New System.Windows.Forms.Label
        Me.lblColon10 = New System.Windows.Forms.Label
        Me.lblColon9 = New System.Windows.Forms.Label
        Me.lblColon5 = New System.Windows.Forms.Label
        Me.lblColon4 = New System.Windows.Forms.Label
        Me.ibtnSearchVehicle = New System.Windows.Forms.Button
        Me.lblColon3 = New System.Windows.Forms.Label
        Me.lblActivity = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.lblColon2 = New System.Windows.Forms.Label
        Me.ibtnSearchAccountCode = New System.Windows.Forms.Button
        Me.ibtnSearchOperatorCode = New System.Windows.Forms.Button
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.txtAccountCode = New System.Windows.Forms.TextBox
        Me.txtOperatorCode = New System.Windows.Forms.TextBox
        Me.lblAccountCode = New System.Windows.Forms.Label
        Me.lblShowOperatorName = New System.Windows.Forms.Label
        Me.lblOperatorCode = New System.Windows.Forms.Label
        Me.txtTotalHrs = New System.Windows.Forms.TextBox
        Me.txtActivity = New System.Windows.Forms.TextBox
        Me.lblTotalHrs = New System.Windows.Forms.Label
        Me.lblEndTime = New System.Windows.Forms.Label
        Me.lblStartTime = New System.Windows.Forms.Label
        Me.txtVehicleCode = New System.Windows.Forms.TextBox
        Me.lblVehicleCode = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblWorkshopLogNo = New System.Windows.Forms.Label
        Me.tpViewVRL = New System.Windows.Forms.TabPage
        Me.pnlESearch = New System.Windows.Forms.Panel
        Me.dgWorkshop = New System.Windows.Forms.DataGridView
        Me.WDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkshopCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WPosted = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PnlSearch = New Stepi.UI.ExtendedPanel
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblViewVehicleCode = New System.Windows.Forms.Label
        Me.chkDate = New System.Windows.Forms.CheckBox
        Me.lblSearchby = New System.Windows.Forms.Label
        Me.dtpSearchBydate = New System.Windows.Forms.DateTimePicker
        Me.txtWorkshopSearch = New System.Windows.Forms.TextBox
        Me.pnlSearchDetails = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblColon29 = New System.Windows.Forms.Label
        Me.cmsAddEditDelete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiViewAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiViewEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiViewDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.plIB1.SuspendLayout()
        Me.tbcWorkshop.SuspendLayout()
        Me.tbpgAdd.SuspendLayout()
        Me.gbAddReset.SuspendLayout()
        Me.gbListOfWorkshopLog.SuspendLayout()
        CType(Me.dgWorkshopRunningLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbWorkshopLog.SuspendLayout()
        Me.gbDivYopSubBlock.SuspendLayout()
        Me.gbTAnalysis.SuspendLayout()
        Me.tpViewVRL.SuspendLayout()
        Me.pnlESearch.SuspendLayout()
        CType(Me.dgWorkshop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlSearch.SuspendLayout()
        Me.pnlSearchDetails.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAddEditDelete.SuspendLayout()
        Me.cmsView.SuspendLayout()
        Me.SuspendLayout()
        '
        'plIB1
        '
        Me.plIB1.AutoScroll = True
        Me.plIB1.BackColor = System.Drawing.Color.Transparent
        Me.plIB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.plIB1.Controls.Add(Me.tbcWorkshop)
        Me.plIB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plIB1.Location = New System.Drawing.Point(0, 0)
        Me.plIB1.Name = "plIB1"
        Me.plIB1.Size = New System.Drawing.Size(960, 732)
        Me.plIB1.TabIndex = 12
        '
        'tbcWorkshop
        '
        Me.tbcWorkshop.Controls.Add(Me.tbpgAdd)
        Me.tbcWorkshop.Controls.Add(Me.tpViewVRL)
        Me.tbcWorkshop.Location = New System.Drawing.Point(3, 3)
        Me.tbcWorkshop.Name = "tbcWorkshop"
        Me.tbcWorkshop.SelectedIndex = 0
        Me.tbcWorkshop.Size = New System.Drawing.Size(950, 769)
        Me.tbcWorkshop.TabIndex = 0
        '
        'tbpgAdd
        '
        Me.tbpgAdd.BackColor = System.Drawing.Color.Transparent
        Me.tbpgAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgAdd.Controls.Add(Me.gbAddReset)
        Me.tbpgAdd.Controls.Add(Me.gbListOfWorkshopLog)
        Me.tbpgAdd.Controls.Add(Me.gbWorkshopLog)
        Me.tbpgAdd.Location = New System.Drawing.Point(4, 22)
        Me.tbpgAdd.Name = "tbpgAdd"
        Me.tbpgAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpgAdd.Size = New System.Drawing.Size(942, 743)
        Me.tbpgAdd.TabIndex = 0
        Me.tbpgAdd.Text = "Workshop Log"
        Me.tbpgAdd.UseVisualStyleBackColor = True
        '
        'gbAddReset
        '
        Me.gbAddReset.Controls.Add(Me.btnPrint)
        Me.gbAddReset.Controls.Add(Me.btnClose)
        Me.gbAddReset.Controls.Add(Me.btnSaveOrUpdate)
        Me.gbAddReset.Controls.Add(Me.btnReset)
        Me.gbAddReset.Location = New System.Drawing.Point(6, 453)
        Me.gbAddReset.Name = "gbAddReset"
        Me.gbAddReset.Size = New System.Drawing.Size(926, 33)
        Me.gbAddReset.TabIndex = 36
        Me.gbAddReset.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(807, 8)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 25)
        Me.btnPrint.TabIndex = 40
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(700, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 25)
        Me.btnClose.TabIndex = 39
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveOrUpdate
        '
        Me.btnSaveOrUpdate.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveOrUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveOrUpdate.Image = CType(resources.GetObject("btnSaveOrUpdate.Image"), System.Drawing.Image)
        Me.btnSaveOrUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveOrUpdate.Location = New System.Drawing.Point(486, 8)
        Me.btnSaveOrUpdate.Name = "btnSaveOrUpdate"
        Me.btnSaveOrUpdate.Size = New System.Drawing.Size(98, 25)
        Me.btnSaveOrUpdate.TabIndex = 37
        Me.btnSaveOrUpdate.Text = "Add"
        Me.btnSaveOrUpdate.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(593, 8)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(98, 25)
        Me.btnReset.TabIndex = 38
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'gbListOfWorkshopLog
        '
        Me.gbListOfWorkshopLog.Controls.Add(Me.dgWorkshopRunningLog)
        Me.gbListOfWorkshopLog.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gbListOfWorkshopLog.Location = New System.Drawing.Point(5, 488)
        Me.gbListOfWorkshopLog.Name = "gbListOfWorkshopLog"
        Me.gbListOfWorkshopLog.Size = New System.Drawing.Size(926, 195)
        Me.gbListOfWorkshopLog.TabIndex = 41
        Me.gbListOfWorkshopLog.TabStop = False
        Me.gbListOfWorkshopLog.Text = "Workshop Running Log Records"
        '
        'dgWorkshopRunningLog
        '
        Me.dgWorkshopRunningLog.AllowUserToAddRows = False
        Me.dgWorkshopRunningLog.AllowUserToDeleteRows = False
        Me.dgWorkshopRunningLog.AllowUserToResizeColumns = False
        Me.dgWorkshopRunningLog.AllowUserToResizeRows = False
        Me.dgWorkshopRunningLog.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgWorkshopRunningLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgWorkshopRunningLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWorkshopRunningLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgWorkshopRunningLog.ColumnHeadersHeight = 30
        Me.dgWorkshopRunningLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgWorkshopRunningLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LogDate, Me.Workshop, Me.Vehicle, Me.StartTime, Me.EndTime, Me.TotalHrs, Me.Activity, Me.AccountCode, Me.AccountCodeDescp, Me.Id, Me.Posted})
        Me.dgWorkshopRunningLog.EnableHeadersVisualStyles = False
        Me.dgWorkshopRunningLog.GridColor = System.Drawing.Color.Gray
        Me.dgWorkshopRunningLog.Location = New System.Drawing.Point(12, 23)
        Me.dgWorkshopRunningLog.MultiSelect = False
        Me.dgWorkshopRunningLog.Name = "dgWorkshopRunningLog"
        Me.dgWorkshopRunningLog.ReadOnly = True
        Me.dgWorkshopRunningLog.RowHeadersVisible = False
        Me.dgWorkshopRunningLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgWorkshopRunningLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWorkshopRunningLog.Size = New System.Drawing.Size(898, 150)
        Me.dgWorkshopRunningLog.TabIndex = 42
        Me.dgWorkshopRunningLog.TabStop = False
        '
        'LogDate
        '
        Me.LogDate.DataPropertyName = "LogDate"
        Me.LogDate.Frozen = True
        Me.LogDate.HeaderText = "Date"
        Me.LogDate.Name = "LogDate"
        Me.LogDate.ReadOnly = True
        '
        'Workshop
        '
        Me.Workshop.DataPropertyName = "WorkVHID"
        Me.Workshop.Frozen = True
        Me.Workshop.HeaderText = "Workshop Code"
        Me.Workshop.Name = "Workshop"
        Me.Workshop.ReadOnly = True
        Me.Workshop.Width = 110
        '
        'Vehicle
        '
        Me.Vehicle.DataPropertyName = "VHID"
        Me.Vehicle.Frozen = True
        Me.Vehicle.HeaderText = "Vehicle Code"
        Me.Vehicle.Name = "Vehicle"
        Me.Vehicle.ReadOnly = True
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.StartTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.StartTime.Frozen = True
        Me.StartTime.HeaderText = "Start Time"
        Me.StartTime.Name = "StartTime"
        Me.StartTime.ReadOnly = True
        Me.StartTime.Width = 96
        '
        'EndTime
        '
        Me.EndTime.DataPropertyName = "EndTime"
        Me.EndTime.Frozen = True
        Me.EndTime.HeaderText = "End Time"
        Me.EndTime.Name = "EndTime"
        Me.EndTime.ReadOnly = True
        Me.EndTime.Width = 89
        '
        'TotalHrs
        '
        Me.TotalHrs.DataPropertyName = "TotalHrs"
        Me.TotalHrs.Frozen = True
        Me.TotalHrs.HeaderText = "Total Hrs"
        Me.TotalHrs.Name = "TotalHrs"
        Me.TotalHrs.ReadOnly = True
        Me.TotalHrs.Width = 88
        '
        'Activity
        '
        Me.Activity.DataPropertyName = "Activity"
        Me.Activity.Frozen = True
        Me.Activity.HeaderText = "Activity"
        Me.Activity.Name = "Activity"
        Me.Activity.ReadOnly = True
        Me.Activity.Width = 76
        '
        'AccountCode
        '
        Me.AccountCode.DataPropertyName = "COACode"
        Me.AccountCode.Frozen = True
        Me.AccountCode.HeaderText = "Account Code"
        Me.AccountCode.Name = "AccountCode"
        Me.AccountCode.ReadOnly = True
        Me.AccountCode.Width = 110
        '
        'AccountCodeDescp
        '
        Me.AccountCodeDescp.DataPropertyName = "COADescp"
        Me.AccountCodeDescp.Frozen = True
        Me.AccountCodeDescp.HeaderText = "Account Code Desc"
        Me.AccountCodeDescp.Name = "AccountCodeDescp"
        Me.AccountCodeDescp.ReadOnly = True
        Me.AccountCodeDescp.Width = 140
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.Frozen = True
        Me.Id.HeaderText = "ID"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 46
        '
        'Posted
        '
        Me.Posted.DataPropertyName = "Posted"
        Me.Posted.HeaderText = "Posted"
        Me.Posted.Name = "Posted"
        Me.Posted.ReadOnly = True
        Me.Posted.Visible = False
        Me.Posted.Width = 76
        '
        'gbWorkshopLog
        '
        Me.gbWorkshopLog.Controls.Add(Me.txtEndHr)
        Me.gbWorkshopLog.Controls.Add(Me.txtEndMin)
        Me.gbWorkshopLog.Controls.Add(Me.txtStartMin)
        Me.gbWorkshopLog.Controls.Add(Me.txtStartHr)
        Me.gbWorkshopLog.Controls.Add(Me.Label2)
        Me.gbWorkshopLog.Controls.Add(Me.Label36)
        Me.gbWorkshopLog.Controls.Add(Me.Label37)
        Me.gbWorkshopLog.Controls.Add(Me.Label20)
        Me.gbWorkshopLog.Controls.Add(Me.Label35)
        Me.gbWorkshopLog.Controls.Add(Me.lblShowVehicleDesc)
        Me.gbWorkshopLog.Controls.Add(Me.lblShowWorkshopDesc)
        Me.gbWorkshopLog.Controls.Add(Me.Label1)
        Me.gbWorkshopLog.Controls.Add(Me.lblOldAccountCode)
        Me.gbWorkshopLog.Controls.Add(Me.cmbWorkshopCode)
        Me.gbWorkshopLog.Controls.Add(Me.lblShowAccountCodeDesc)
        Me.gbWorkshopLog.Controls.Add(Me.lblShowOldAccountCode)
        Me.gbWorkshopLog.Controls.Add(Me.gbDivYopSubBlock)
        Me.gbWorkshopLog.Controls.Add(Me.gbTAnalysis)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon12)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon11)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon10)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon9)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon5)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon4)
        Me.gbWorkshopLog.Controls.Add(Me.ibtnSearchVehicle)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon3)
        Me.gbWorkshopLog.Controls.Add(Me.lblActivity)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon1)
        Me.gbWorkshopLog.Controls.Add(Me.lblColon2)
        Me.gbWorkshopLog.Controls.Add(Me.ibtnSearchAccountCode)
        Me.gbWorkshopLog.Controls.Add(Me.ibtnSearchOperatorCode)
        Me.gbWorkshopLog.Controls.Add(Me.dtpDate)
        Me.gbWorkshopLog.Controls.Add(Me.txtAccountCode)
        Me.gbWorkshopLog.Controls.Add(Me.txtOperatorCode)
        Me.gbWorkshopLog.Controls.Add(Me.lblAccountCode)
        Me.gbWorkshopLog.Controls.Add(Me.lblShowOperatorName)
        Me.gbWorkshopLog.Controls.Add(Me.lblOperatorCode)
        Me.gbWorkshopLog.Controls.Add(Me.txtTotalHrs)
        Me.gbWorkshopLog.Controls.Add(Me.txtActivity)
        Me.gbWorkshopLog.Controls.Add(Me.lblTotalHrs)
        Me.gbWorkshopLog.Controls.Add(Me.lblEndTime)
        Me.gbWorkshopLog.Controls.Add(Me.lblStartTime)
        Me.gbWorkshopLog.Controls.Add(Me.txtVehicleCode)
        Me.gbWorkshopLog.Controls.Add(Me.lblVehicleCode)
        Me.gbWorkshopLog.Controls.Add(Me.lblDate)
        Me.gbWorkshopLog.Controls.Add(Me.lblWorkshopLogNo)
        Me.gbWorkshopLog.Location = New System.Drawing.Point(6, 0)
        Me.gbWorkshopLog.Name = "gbWorkshopLog"
        Me.gbWorkshopLog.Size = New System.Drawing.Size(926, 451)
        Me.gbWorkshopLog.TabIndex = 6
        Me.gbWorkshopLog.TabStop = False
        '
        'txtEndHr
        '
        Me.txtEndHr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndHr.Location = New System.Drawing.Point(378, 99)
        Me.txtEndHr.MaxLength = 2
        Me.txtEndHr.Name = "txtEndHr"
        Me.txtEndHr.Size = New System.Drawing.Size(40, 21)
        Me.txtEndHr.TabIndex = 15
        '
        'txtEndMin
        '
        Me.txtEndMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndMin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndMin.Location = New System.Drawing.Point(441, 100)
        Me.txtEndMin.MaxLength = 2
        Me.txtEndMin.Name = "txtEndMin"
        Me.txtEndMin.Size = New System.Drawing.Size(40, 21)
        Me.txtEndMin.TabIndex = 16
        '
        'txtStartMin
        '
        Me.txtStartMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartMin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartMin.Location = New System.Drawing.Point(210, 100)
        Me.txtStartMin.MaxLength = 2
        Me.txtStartMin.Name = "txtStartMin"
        Me.txtStartMin.Size = New System.Drawing.Size(40, 21)
        Me.txtStartMin.TabIndex = 14
        '
        'txtStartHr
        '
        Me.txtStartHr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartHr.Location = New System.Drawing.Point(141, 100)
        Me.txtStartHr.MaxLength = 2
        Me.txtStartHr.Name = "txtStartHr"
        Me.txtStartHr.Size = New System.Drawing.Size(40, 21)
        Me.txtStartHr.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(724, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "HH:mm"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(486, 105)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(26, 13)
        Me.Label36.TabIndex = 246
        Me.Label36.Text = "Min"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(422, 105)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(19, 13)
        Me.Label37.TabIndex = 245
        Me.Label37.Text = "hr"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(252, 103)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(26, 13)
        Me.Label20.TabIndex = 242
        Me.Label20.Text = "Min"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(183, 103)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(19, 13)
        Me.Label35.TabIndex = 241
        Me.Label35.Text = "hr"
        '
        'lblShowVehicleDesc
        '
        Me.lblShowVehicleDesc.AutoSize = True
        Me.lblShowVehicleDesc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblShowVehicleDesc.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblShowVehicleDesc.Location = New System.Drawing.Point(348, 69)
        Me.lblShowVehicleDesc.Name = "lblShowVehicleDesc"
        Me.lblShowVehicleDesc.Size = New System.Drawing.Size(0, 13)
        Me.lblShowVehicleDesc.TabIndex = 230
        '
        'lblShowWorkshopDesc
        '
        Me.lblShowWorkshopDesc.AutoSize = True
        Me.lblShowWorkshopDesc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblShowWorkshopDesc.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblShowWorkshopDesc.Location = New System.Drawing.Point(716, 37)
        Me.lblShowWorkshopDesc.Name = "lblShowWorkshopDesc"
        Me.lblShowWorkshopDesc.Size = New System.Drawing.Size(0, 13)
        Me.lblShowWorkshopDesc.TabIndex = 229
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(115, 229)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = ":"
        '
        'lblOldAccountCode
        '
        Me.lblOldAccountCode.AutoSize = True
        Me.lblOldAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblOldAccountCode.Location = New System.Drawing.Point(8, 229)
        Me.lblOldAccountCode.Name = "lblOldAccountCode"
        Me.lblOldAccountCode.Size = New System.Drawing.Size(109, 13)
        Me.lblOldAccountCode.TabIndex = 227
        Me.lblOldAccountCode.Text = "Old Account Code"
        '
        'cmbWorkshopCode
        '
        Me.cmbWorkshopCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWorkshopCode.FormattingEnabled = True
        Me.cmbWorkshopCode.Location = New System.Drawing.Point(555, 37)
        Me.cmbWorkshopCode.Name = "cmbWorkshopCode"
        Me.cmbWorkshopCode.Size = New System.Drawing.Size(146, 21)
        Me.cmbWorkshopCode.TabIndex = 10
        '
        'lblShowAccountCodeDesc
        '
        Me.lblShowAccountCodeDesc.AutoSize = True
        Me.lblShowAccountCodeDesc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblShowAccountCodeDesc.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblShowAccountCodeDesc.Location = New System.Drawing.Point(348, 203)
        Me.lblShowAccountCodeDesc.Name = "lblShowAccountCodeDesc"
        Me.lblShowAccountCodeDesc.Size = New System.Drawing.Size(0, 13)
        Me.lblShowAccountCodeDesc.TabIndex = 225
        '
        'lblShowOldAccountCode
        '
        Me.lblShowOldAccountCode.AutoSize = True
        Me.lblShowOldAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblShowOldAccountCode.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblShowOldAccountCode.Location = New System.Drawing.Point(138, 231)
        Me.lblShowOldAccountCode.Name = "lblShowOldAccountCode"
        Me.lblShowOldAccountCode.Size = New System.Drawing.Size(43, 13)
        Me.lblShowOldAccountCode.TabIndex = 222
        Me.lblShowOldAccountCode.Text = "         "
        '
        'gbDivYopSubBlock
        '
        Me.gbDivYopSubBlock.Controls.Add(Me.txtYOP)
        Me.gbDivYopSubBlock.Controls.Add(Me.lblBlock)
        Me.gbDivYopSubBlock.Controls.Add(Me.lblColon8)
        Me.gbDivYopSubBlock.Controls.Add(Me.lblYOP)
        Me.gbDivYopSubBlock.Controls.Add(Me.lblColon7)
        Me.gbDivYopSubBlock.Controls.Add(Me.lblDIV)
        Me.gbDivYopSubBlock.Controls.Add(Me.lblColon6)
        Me.gbDivYopSubBlock.Controls.Add(Me.ibtnLookUpDIV)
        Me.gbDivYopSubBlock.Controls.Add(Me.txtSubBlock)
        Me.gbDivYopSubBlock.Controls.Add(Me.txtDIV)
        Me.gbDivYopSubBlock.Controls.Add(Me.ibtnLookUpSubBlock)
        Me.gbDivYopSubBlock.Location = New System.Drawing.Point(8, 263)
        Me.gbDivYopSubBlock.Name = "gbDivYopSubBlock"
        Me.gbDivYopSubBlock.Size = New System.Drawing.Size(344, 110)
        Me.gbDivYopSubBlock.TabIndex = 22
        Me.gbDivYopSubBlock.TabStop = False
        '
        'txtYOP
        '
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(128, 50)
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.ReadOnly = True
        Me.txtYOP.Size = New System.Drawing.Size(150, 21)
        Me.txtYOP.TabIndex = 0
        Me.txtYOP.TabStop = False
        '
        'lblBlock
        '
        Me.lblBlock.AutoSize = True
        Me.lblBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlock.ForeColor = System.Drawing.Color.Black
        Me.lblBlock.Location = New System.Drawing.Point(11, 86)
        Me.lblBlock.Name = "lblBlock"
        Me.lblBlock.Size = New System.Drawing.Size(64, 13)
        Me.lblBlock.TabIndex = 253
        Me.lblBlock.Text = "Field No"
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(107, 87)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(11, 13)
        Me.lblColon8.TabIndex = 279
        Me.lblColon8.Text = ":"
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.ForeColor = System.Drawing.Color.Black
        Me.lblYOP.Location = New System.Drawing.Point(11, 54)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(30, 13)
        Me.lblYOP.TabIndex = 254
        Me.lblYOP.Text = "YOP"
        '
        'lblColon7
        '
        Me.lblColon7.AutoSize = True
        Me.lblColon7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon7.Location = New System.Drawing.Point(107, 54)
        Me.lblColon7.Name = "lblColon7"
        Me.lblColon7.Size = New System.Drawing.Size(11, 13)
        Me.lblColon7.TabIndex = 278
        Me.lblColon7.Text = ":"
        '
        'lblDIV
        '
        Me.lblDIV.AutoSize = True
        Me.lblDIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDIV.ForeColor = System.Drawing.Color.Black
        Me.lblDIV.Location = New System.Drawing.Point(11, 22)
        Me.lblDIV.Name = "lblDIV"
        Me.lblDIV.Size = New System.Drawing.Size(29, 13)
        Me.lblDIV.TabIndex = 255
        Me.lblDIV.Text = "Afdeling"
        '
        'lblColon6
        '
        Me.lblColon6.AutoSize = True
        Me.lblColon6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon6.Location = New System.Drawing.Point(107, 22)
        Me.lblColon6.Name = "lblColon6"
        Me.lblColon6.Size = New System.Drawing.Size(11, 13)
        Me.lblColon6.TabIndex = 277
        Me.lblColon6.Text = ":"
        '
        'ibtnLookUpDIV
        '
        Me.ibtnLookUpDIV.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnLookUpDIV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnLookUpDIV.FlatAppearance.BorderSize = 0
        Me.ibtnLookUpDIV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnLookUpDIV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnLookUpDIV.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnLookUpDIV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnLookUpDIV.Location = New System.Drawing.Point(290, 11)
        Me.ibtnLookUpDIV.Name = "ibtnLookUpDIV"
        Me.ibtnLookUpDIV.Size = New System.Drawing.Size(30, 35)
        Me.ibtnLookUpDIV.TabIndex = 21
        Me.ibtnLookUpDIV.TabStop = False
        Me.ibtnLookUpDIV.UseVisualStyleBackColor = True
        Me.ibtnLookUpDIV.Visible = False
        '
        'txtSubBlock
        '
        Me.txtSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubBlock.Location = New System.Drawing.Point(128, 81)
        Me.txtSubBlock.Name = "txtSubBlock"
        Me.txtSubBlock.Size = New System.Drawing.Size(150, 21)
        Me.txtSubBlock.TabIndex = 23
        '
        'txtDIV
        '
        Me.txtDIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIV.Location = New System.Drawing.Point(128, 19)
        Me.txtDIV.Name = "txtDIV"
        Me.txtDIV.ReadOnly = True
        Me.txtDIV.Size = New System.Drawing.Size(150, 21)
        Me.txtDIV.TabIndex = 20
        Me.txtDIV.TabStop = False
        '
        'ibtnLookUpSubBlock
        '
        Me.ibtnLookUpSubBlock.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnLookUpSubBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnLookUpSubBlock.FlatAppearance.BorderSize = 0
        Me.ibtnLookUpSubBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnLookUpSubBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnLookUpSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnLookUpSubBlock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnLookUpSubBlock.Location = New System.Drawing.Point(290, 74)
        Me.ibtnLookUpSubBlock.Name = "ibtnLookUpSubBlock"
        Me.ibtnLookUpSubBlock.Size = New System.Drawing.Size(30, 35)
        Me.ibtnLookUpSubBlock.TabIndex = 24
        Me.ibtnLookUpSubBlock.TabStop = False
        Me.ibtnLookUpSubBlock.UseVisualStyleBackColor = True
        '
        'gbTAnalysis
        '
        Me.gbTAnalysis.Controls.Add(Me.lblT1Name)
        Me.gbTAnalysis.Controls.Add(Me.lblT2Name)
        Me.gbTAnalysis.Controls.Add(Me.lblT3Name)
        Me.gbTAnalysis.Controls.Add(Me.lblT4Name)
        Me.gbTAnalysis.Controls.Add(Me.lblT0Name)
        Me.gbTAnalysis.Controls.Add(Me.ibtnSearchTAnalysisT4)
        Me.gbTAnalysis.Controls.Add(Me.lblColon19)
        Me.gbTAnalysis.Controls.Add(Me.lblTAnalysisT4)
        Me.gbTAnalysis.Controls.Add(Me.lblColon18)
        Me.gbTAnalysis.Controls.Add(Me.lblTAnalysisT3)
        Me.gbTAnalysis.Controls.Add(Me.lblColon17)
        Me.gbTAnalysis.Controls.Add(Me.lblTAnalysisT2)
        Me.gbTAnalysis.Controls.Add(Me.lblColon15)
        Me.gbTAnalysis.Controls.Add(Me.lblTAnalysisT1)
        Me.gbTAnalysis.Controls.Add(Me.lblColon16)
        Me.gbTAnalysis.Controls.Add(Me.lblTAnalysisT0)
        Me.gbTAnalysis.Controls.Add(Me.ibtnSearchTAnalysisT0)
        Me.gbTAnalysis.Controls.Add(Me.txtT0)
        Me.gbTAnalysis.Controls.Add(Me.ibtnSearchTAnalysisT1)
        Me.gbTAnalysis.Controls.Add(Me.txtT4)
        Me.gbTAnalysis.Controls.Add(Me.txtT1)
        Me.gbTAnalysis.Controls.Add(Me.ibtnSearchTAnalysisT2)
        Me.gbTAnalysis.Controls.Add(Me.txtT3)
        Me.gbTAnalysis.Controls.Add(Me.txtT2)
        Me.gbTAnalysis.Controls.Add(Me.ibtnSearchTAnalysisT3)
        Me.gbTAnalysis.Location = New System.Drawing.Point(370, 263)
        Me.gbTAnalysis.Name = "gbTAnalysis"
        Me.gbTAnalysis.Size = New System.Drawing.Size(539, 174)
        Me.gbTAnalysis.TabIndex = 25
        Me.gbTAnalysis.TabStop = False
        '
        'lblT1Name
        '
        Me.lblT1Name.AutoSize = True
        Me.lblT1Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1Name.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblT1Name.Location = New System.Drawing.Point(214, 52)
        Me.lblT1Name.Name = "lblT1Name"
        Me.lblT1Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT1Name.TabIndex = 289
        '
        'lblT2Name
        '
        Me.lblT2Name.AutoSize = True
        Me.lblT2Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2Name.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblT2Name.Location = New System.Drawing.Point(214, 86)
        Me.lblT2Name.Name = "lblT2Name"
        Me.lblT2Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT2Name.TabIndex = 288
        '
        'lblT3Name
        '
        Me.lblT3Name.AutoSize = True
        Me.lblT3Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3Name.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblT3Name.Location = New System.Drawing.Point(214, 117)
        Me.lblT3Name.Name = "lblT3Name"
        Me.lblT3Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT3Name.TabIndex = 287
        '
        'lblT4Name
        '
        Me.lblT4Name.AutoSize = True
        Me.lblT4Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4Name.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblT4Name.Location = New System.Drawing.Point(214, 146)
        Me.lblT4Name.Name = "lblT4Name"
        Me.lblT4Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT4Name.TabIndex = 286
        '
        'lblT0Name
        '
        Me.lblT0Name.AutoSize = True
        Me.lblT0Name.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0Name.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblT0Name.Location = New System.Drawing.Point(214, 22)
        Me.lblT0Name.Name = "lblT0Name"
        Me.lblT0Name.Size = New System.Drawing.Size(0, 13)
        Me.lblT0Name.TabIndex = 285
        '
        'ibtnSearchTAnalysisT4
        '
        Me.ibtnSearchTAnalysisT4.AccessibleName = "T4"
        Me.ibtnSearchTAnalysisT4.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchTAnalysisT4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchTAnalysisT4.FlatAppearance.BorderSize = 0
        Me.ibtnSearchTAnalysisT4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchTAnalysisT4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchTAnalysisT4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchTAnalysisT4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchTAnalysisT4.Location = New System.Drawing.Point(158, 136)
        Me.ibtnSearchTAnalysisT4.Name = "ibtnSearchTAnalysisT4"
        Me.ibtnSearchTAnalysisT4.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchTAnalysisT4.TabIndex = 35
        Me.ibtnSearchTAnalysisT4.TabStop = False
        Me.ibtnSearchTAnalysisT4.UseVisualStyleBackColor = True
        '
        'lblColon19
        '
        Me.lblColon19.AutoSize = True
        Me.lblColon19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon19.Location = New System.Drawing.Point(47, 149)
        Me.lblColon19.Name = "lblColon19"
        Me.lblColon19.Size = New System.Drawing.Size(11, 13)
        Me.lblColon19.TabIndex = 284
        Me.lblColon19.Text = ":"
        '
        'lblTAnalysisT4
        '
        Me.lblTAnalysisT4.AutoSize = True
        Me.lblTAnalysisT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAnalysisT4.ForeColor = System.Drawing.Color.Black
        Me.lblTAnalysisT4.Location = New System.Drawing.Point(7, 146)
        Me.lblTAnalysisT4.Name = "lblTAnalysisT4"
        Me.lblTAnalysisT4.Size = New System.Drawing.Size(21, 13)
        Me.lblTAnalysisT4.TabIndex = 256
        Me.lblTAnalysisT4.Text = "T4"
        '
        'lblColon18
        '
        Me.lblColon18.AutoSize = True
        Me.lblColon18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon18.Location = New System.Drawing.Point(47, 116)
        Me.lblColon18.Name = "lblColon18"
        Me.lblColon18.Size = New System.Drawing.Size(11, 13)
        Me.lblColon18.TabIndex = 283
        Me.lblColon18.Text = ":"
        '
        'lblTAnalysisT3
        '
        Me.lblTAnalysisT3.AutoSize = True
        Me.lblTAnalysisT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAnalysisT3.ForeColor = System.Drawing.Color.Black
        Me.lblTAnalysisT3.Location = New System.Drawing.Point(9, 115)
        Me.lblTAnalysisT3.Name = "lblTAnalysisT3"
        Me.lblTAnalysisT3.Size = New System.Drawing.Size(21, 13)
        Me.lblTAnalysisT3.TabIndex = 257
        Me.lblTAnalysisT3.Text = "T3"
        '
        'lblColon17
        '
        Me.lblColon17.AutoSize = True
        Me.lblColon17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon17.Location = New System.Drawing.Point(47, 84)
        Me.lblColon17.Name = "lblColon17"
        Me.lblColon17.Size = New System.Drawing.Size(11, 13)
        Me.lblColon17.TabIndex = 282
        Me.lblColon17.Text = ":"
        '
        'lblTAnalysisT2
        '
        Me.lblTAnalysisT2.AutoSize = True
        Me.lblTAnalysisT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAnalysisT2.ForeColor = System.Drawing.Color.Black
        Me.lblTAnalysisT2.Location = New System.Drawing.Point(7, 84)
        Me.lblTAnalysisT2.Name = "lblTAnalysisT2"
        Me.lblTAnalysisT2.Size = New System.Drawing.Size(21, 13)
        Me.lblTAnalysisT2.TabIndex = 258
        Me.lblTAnalysisT2.Text = "T2"
        '
        'lblColon15
        '
        Me.lblColon15.AutoSize = True
        Me.lblColon15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon15.Location = New System.Drawing.Point(47, 20)
        Me.lblColon15.Name = "lblColon15"
        Me.lblColon15.Size = New System.Drawing.Size(11, 13)
        Me.lblColon15.TabIndex = 281
        Me.lblColon15.Text = ":"
        '
        'lblTAnalysisT1
        '
        Me.lblTAnalysisT1.AutoSize = True
        Me.lblTAnalysisT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAnalysisT1.ForeColor = System.Drawing.Color.Black
        Me.lblTAnalysisT1.Location = New System.Drawing.Point(7, 53)
        Me.lblTAnalysisT1.Name = "lblTAnalysisT1"
        Me.lblTAnalysisT1.Size = New System.Drawing.Size(21, 13)
        Me.lblTAnalysisT1.TabIndex = 259
        Me.lblTAnalysisT1.Text = "T1"
        '
        'lblColon16
        '
        Me.lblColon16.AutoSize = True
        Me.lblColon16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon16.Location = New System.Drawing.Point(47, 53)
        Me.lblColon16.Name = "lblColon16"
        Me.lblColon16.Size = New System.Drawing.Size(11, 13)
        Me.lblColon16.TabIndex = 280
        Me.lblColon16.Text = ":"
        '
        'lblTAnalysisT0
        '
        Me.lblTAnalysisT0.AutoSize = True
        Me.lblTAnalysisT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAnalysisT0.ForeColor = System.Drawing.Color.Red
        Me.lblTAnalysisT0.Location = New System.Drawing.Point(7, 22)
        Me.lblTAnalysisT0.Name = "lblTAnalysisT0"
        Me.lblTAnalysisT0.Size = New System.Drawing.Size(21, 13)
        Me.lblTAnalysisT0.TabIndex = 260
        Me.lblTAnalysisT0.Text = "T0"
        '
        'ibtnSearchTAnalysisT0
        '
        Me.ibtnSearchTAnalysisT0.AccessibleName = "T0"
        Me.ibtnSearchTAnalysisT0.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchTAnalysisT0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchTAnalysisT0.FlatAppearance.BorderSize = 0
        Me.ibtnSearchTAnalysisT0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchTAnalysisT0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchTAnalysisT0.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchTAnalysisT0.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchTAnalysisT0.Location = New System.Drawing.Point(160, 9)
        Me.ibtnSearchTAnalysisT0.Name = "ibtnSearchTAnalysisT0"
        Me.ibtnSearchTAnalysisT0.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchTAnalysisT0.TabIndex = 27
        Me.ibtnSearchTAnalysisT0.TabStop = False
        Me.ibtnSearchTAnalysisT0.UseVisualStyleBackColor = True
        '
        'txtT0
        '
        Me.txtT0.AccessibleName = "T0"
        Me.txtT0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT0.Location = New System.Drawing.Point(67, 18)
        Me.txtT0.Name = "txtT0"
        Me.txtT0.Size = New System.Drawing.Size(84, 21)
        Me.txtT0.TabIndex = 26
        '
        'ibtnSearchTAnalysisT1
        '
        Me.ibtnSearchTAnalysisT1.AccessibleName = "T1"
        Me.ibtnSearchTAnalysisT1.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchTAnalysisT1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchTAnalysisT1.FlatAppearance.BorderSize = 0
        Me.ibtnSearchTAnalysisT1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchTAnalysisT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchTAnalysisT1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchTAnalysisT1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchTAnalysisT1.Location = New System.Drawing.Point(160, 40)
        Me.ibtnSearchTAnalysisT1.Name = "ibtnSearchTAnalysisT1"
        Me.ibtnSearchTAnalysisT1.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchTAnalysisT1.TabIndex = 29
        Me.ibtnSearchTAnalysisT1.TabStop = False
        Me.ibtnSearchTAnalysisT1.UseVisualStyleBackColor = True
        '
        'txtT4
        '
        Me.txtT4.AccessibleName = "T4"
        Me.txtT4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT4.Location = New System.Drawing.Point(65, 142)
        Me.txtT4.Name = "txtT4"
        Me.txtT4.Size = New System.Drawing.Size(84, 21)
        Me.txtT4.TabIndex = 34
        '
        'txtT1
        '
        Me.txtT1.AccessibleName = "T1"
        Me.txtT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT1.Location = New System.Drawing.Point(67, 49)
        Me.txtT1.Name = "txtT1"
        Me.txtT1.Size = New System.Drawing.Size(84, 21)
        Me.txtT1.TabIndex = 28
        '
        'ibtnSearchTAnalysisT2
        '
        Me.ibtnSearchTAnalysisT2.AccessibleName = "T2"
        Me.ibtnSearchTAnalysisT2.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchTAnalysisT2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchTAnalysisT2.FlatAppearance.BorderSize = 0
        Me.ibtnSearchTAnalysisT2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchTAnalysisT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchTAnalysisT2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchTAnalysisT2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchTAnalysisT2.Location = New System.Drawing.Point(160, 75)
        Me.ibtnSearchTAnalysisT2.Name = "ibtnSearchTAnalysisT2"
        Me.ibtnSearchTAnalysisT2.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchTAnalysisT2.TabIndex = 31
        Me.ibtnSearchTAnalysisT2.TabStop = False
        Me.ibtnSearchTAnalysisT2.UseVisualStyleBackColor = True
        '
        'txtT3
        '
        Me.txtT3.AccessibleName = "T3"
        Me.txtT3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT3.Location = New System.Drawing.Point(65, 111)
        Me.txtT3.Name = "txtT3"
        Me.txtT3.Size = New System.Drawing.Size(84, 21)
        Me.txtT3.TabIndex = 32
        '
        'txtT2
        '
        Me.txtT2.AccessibleName = "T2"
        Me.txtT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT2.Location = New System.Drawing.Point(67, 80)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.Size = New System.Drawing.Size(84, 21)
        Me.txtT2.TabIndex = 30
        '
        'ibtnSearchTAnalysisT3
        '
        Me.ibtnSearchTAnalysisT3.AccessibleName = "T3"
        Me.ibtnSearchTAnalysisT3.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchTAnalysisT3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchTAnalysisT3.FlatAppearance.BorderSize = 0
        Me.ibtnSearchTAnalysisT3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchTAnalysisT3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchTAnalysisT3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchTAnalysisT3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchTAnalysisT3.Location = New System.Drawing.Point(160, 106)
        Me.ibtnSearchTAnalysisT3.Name = "ibtnSearchTAnalysisT3"
        Me.ibtnSearchTAnalysisT3.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchTAnalysisT3.TabIndex = 33
        Me.ibtnSearchTAnalysisT3.TabStop = False
        Me.ibtnSearchTAnalysisT3.UseVisualStyleBackColor = True
        '
        'lblColon12
        '
        Me.lblColon12.AutoSize = True
        Me.lblColon12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon12.Location = New System.Drawing.Point(609, 104)
        Me.lblColon12.Name = "lblColon12"
        Me.lblColon12.Size = New System.Drawing.Size(11, 13)
        Me.lblColon12.TabIndex = 221
        Me.lblColon12.Text = ":"
        '
        'lblColon11
        '
        Me.lblColon11.AutoSize = True
        Me.lblColon11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon11.Location = New System.Drawing.Point(115, 69)
        Me.lblColon11.Name = "lblColon11"
        Me.lblColon11.Size = New System.Drawing.Size(11, 13)
        Me.lblColon11.TabIndex = 220
        Me.lblColon11.Text = ":"
        '
        'lblColon10
        '
        Me.lblColon10.AutoSize = True
        Me.lblColon10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon10.Location = New System.Drawing.Point(361, 104)
        Me.lblColon10.Name = "lblColon10"
        Me.lblColon10.Size = New System.Drawing.Size(11, 13)
        Me.lblColon10.TabIndex = 217
        Me.lblColon10.Text = ":"
        '
        'lblColon9
        '
        Me.lblColon9.AutoSize = True
        Me.lblColon9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon9.Location = New System.Drawing.Point(115, 36)
        Me.lblColon9.Name = "lblColon9"
        Me.lblColon9.Size = New System.Drawing.Size(11, 13)
        Me.lblColon9.TabIndex = 216
        Me.lblColon9.Text = ":"
        '
        'lblColon5
        '
        Me.lblColon5.AutoSize = True
        Me.lblColon5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon5.Location = New System.Drawing.Point(115, 197)
        Me.lblColon5.Name = "lblColon5"
        Me.lblColon5.Size = New System.Drawing.Size(11, 13)
        Me.lblColon5.TabIndex = 215
        Me.lblColon5.Text = ":"
        '
        'lblColon4
        '
        Me.lblColon4.AutoSize = True
        Me.lblColon4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon4.Location = New System.Drawing.Point(115, 165)
        Me.lblColon4.Name = "lblColon4"
        Me.lblColon4.Size = New System.Drawing.Size(11, 13)
        Me.lblColon4.TabIndex = 214
        Me.lblColon4.Text = ":"
        '
        'ibtnSearchVehicle
        '
        Me.ibtnSearchVehicle.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchVehicle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchVehicle.FlatAppearance.BorderSize = 0
        Me.ibtnSearchVehicle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchVehicle.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchVehicle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchVehicle.Location = New System.Drawing.Point(292, 59)
        Me.ibtnSearchVehicle.Name = "ibtnSearchVehicle"
        Me.ibtnSearchVehicle.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchVehicle.TabIndex = 12
        Me.ibtnSearchVehicle.TabStop = False
        Me.ibtnSearchVehicle.UseVisualStyleBackColor = True
        '
        'lblColon3
        '
        Me.lblColon3.AutoSize = True
        Me.lblColon3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon3.Location = New System.Drawing.Point(115, 133)
        Me.lblColon3.Name = "lblColon3"
        Me.lblColon3.Size = New System.Drawing.Size(11, 13)
        Me.lblColon3.TabIndex = 213
        Me.lblColon3.Text = ":"
        '
        'lblActivity
        '
        Me.lblActivity.AutoSize = True
        Me.lblActivity.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblActivity.ForeColor = System.Drawing.Color.Red
        Me.lblActivity.Location = New System.Drawing.Point(8, 133)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(49, 13)
        Me.lblActivity.TabIndex = 212
        Me.lblActivity.Text = "Activity"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(531, 37)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 212
        Me.lblColon1.Text = ":"
        '
        'lblColon2
        '
        Me.lblColon2.AutoSize = True
        Me.lblColon2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon2.Location = New System.Drawing.Point(115, 101)
        Me.lblColon2.Name = "lblColon2"
        Me.lblColon2.Size = New System.Drawing.Size(11, 13)
        Me.lblColon2.TabIndex = 211
        Me.lblColon2.Text = ":"
        '
        'ibtnSearchAccountCode
        '
        Me.ibtnSearchAccountCode.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchAccountCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchAccountCode.FlatAppearance.BorderSize = 0
        Me.ibtnSearchAccountCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchAccountCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchAccountCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchAccountCode.Location = New System.Drawing.Point(298, 191)
        Me.ibtnSearchAccountCode.Name = "ibtnSearchAccountCode"
        Me.ibtnSearchAccountCode.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchAccountCode.TabIndex = 21
        Me.ibtnSearchAccountCode.TabStop = False
        Me.ibtnSearchAccountCode.UseVisualStyleBackColor = True
        '
        'ibtnSearchOperatorCode
        '
        Me.ibtnSearchOperatorCode.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.ibtnSearchOperatorCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ibtnSearchOperatorCode.FlatAppearance.BorderSize = 0
        Me.ibtnSearchOperatorCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ibtnSearchOperatorCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSearchOperatorCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.ibtnSearchOperatorCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ibtnSearchOperatorCode.Location = New System.Drawing.Point(297, 159)
        Me.ibtnSearchOperatorCode.Name = "ibtnSearchOperatorCode"
        Me.ibtnSearchOperatorCode.Size = New System.Drawing.Size(30, 35)
        Me.ibtnSearchOperatorCode.TabIndex = 19
        Me.ibtnSearchOperatorCode.TabStop = False
        Me.ibtnSearchOperatorCode.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(139, 36)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(150, 21)
        Me.dtpDate.TabIndex = 9
        Me.dtpDate.Value = New Date(2009, 4, 4, 0, 0, 0, 0)
        '
        'txtAccountCode
        '
        Me.txtAccountCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountCode.Location = New System.Drawing.Point(139, 198)
        Me.txtAccountCode.MaxLength = 50
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.Size = New System.Drawing.Size(150, 20)
        Me.txtAccountCode.TabIndex = 20
        '
        'txtOperatorCode
        '
        Me.txtOperatorCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtOperatorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperatorCode.Location = New System.Drawing.Point(139, 166)
        Me.txtOperatorCode.MaxLength = 50
        Me.txtOperatorCode.Name = "txtOperatorCode"
        Me.txtOperatorCode.Size = New System.Drawing.Size(150, 20)
        Me.txtOperatorCode.TabIndex = 19
        '
        'lblAccountCode
        '
        Me.lblAccountCode.AutoSize = True
        Me.lblAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAccountCode.ForeColor = System.Drawing.Color.Red
        Me.lblAccountCode.Location = New System.Drawing.Point(8, 197)
        Me.lblAccountCode.Name = "lblAccountCode"
        Me.lblAccountCode.Size = New System.Drawing.Size(86, 13)
        Me.lblAccountCode.TabIndex = 114
        Me.lblAccountCode.Text = "Account Code"
        '
        'lblShowOperatorName
        '
        Me.lblShowOperatorName.AutoSize = True
        Me.lblShowOperatorName.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblShowOperatorName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblShowOperatorName.Location = New System.Drawing.Point(348, 171)
        Me.lblShowOperatorName.Name = "lblShowOperatorName"
        Me.lblShowOperatorName.Size = New System.Drawing.Size(0, 13)
        Me.lblShowOperatorName.TabIndex = 112
        '
        'lblOperatorCode
        '
        Me.lblOperatorCode.AutoSize = True
        Me.lblOperatorCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblOperatorCode.Location = New System.Drawing.Point(7, 165)
        Me.lblOperatorCode.Name = "lblOperatorCode"
        Me.lblOperatorCode.Size = New System.Drawing.Size(92, 13)
        Me.lblOperatorCode.TabIndex = 111
        Me.lblOperatorCode.Text = "Operator Code"
        '
        'txtTotalHrs
        '
        Me.txtTotalHrs.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalHrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalHrs.Location = New System.Drawing.Point(634, 103)
        Me.txtTotalHrs.MaxLength = 6
        Me.txtTotalHrs.Name = "txtTotalHrs"
        Me.txtTotalHrs.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalHrs.TabIndex = 17
        Me.txtTotalHrs.TabStop = False
        '
        'txtActivity
        '
        Me.txtActivity.BackColor = System.Drawing.SystemColors.Window
        Me.txtActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActivity.Location = New System.Drawing.Point(139, 134)
        Me.txtActivity.MaxLength = 200
        Me.txtActivity.Name = "txtActivity"
        Me.txtActivity.Size = New System.Drawing.Size(552, 20)
        Me.txtActivity.TabIndex = 18
        '
        'lblTotalHrs
        '
        Me.lblTotalHrs.AutoSize = True
        Me.lblTotalHrs.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalHrs.ForeColor = System.Drawing.Color.Red
        Me.lblTotalHrs.Location = New System.Drawing.Point(527, 104)
        Me.lblTotalHrs.Name = "lblTotalHrs"
        Me.lblTotalHrs.Size = New System.Drawing.Size(58, 13)
        Me.lblTotalHrs.TabIndex = 118
        Me.lblTotalHrs.Text = "Total Hrs"
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEndTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEndTime.Location = New System.Drawing.Point(294, 104)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(60, 13)
        Me.lblEndTime.TabIndex = 119
        Me.lblEndTime.Text = "End Time"
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblStartTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStartTime.Location = New System.Drawing.Point(8, 102)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(67, 13)
        Me.lblStartTime.TabIndex = 120
        Me.lblStartTime.Text = "Start Time"
        '
        'txtVehicleCode
        '
        Me.txtVehicleCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtVehicleCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleCode.Location = New System.Drawing.Point(139, 69)
        Me.txtVehicleCode.MaxLength = 50
        Me.txtVehicleCode.Name = "txtVehicleCode"
        Me.txtVehicleCode.Size = New System.Drawing.Size(150, 20)
        Me.txtVehicleCode.TabIndex = 11
        '
        'lblVehicleCode
        '
        Me.lblVehicleCode.AutoSize = True
        Me.lblVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblVehicleCode.ForeColor = System.Drawing.Color.Red
        Me.lblVehicleCode.Location = New System.Drawing.Point(8, 69)
        Me.lblVehicleCode.Name = "lblVehicleCode"
        Me.lblVehicleCode.Size = New System.Drawing.Size(82, 13)
        Me.lblVehicleCode.TabIndex = 115
        Me.lblVehicleCode.Text = "Vehicle Code"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(8, 36)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 116
        Me.lblDate.Text = "Date"
        '
        'lblWorkshopLogNo
        '
        Me.lblWorkshopLogNo.AutoSize = True
        Me.lblWorkshopLogNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblWorkshopLogNo.ForeColor = System.Drawing.Color.Red
        Me.lblWorkshopLogNo.Location = New System.Drawing.Point(422, 37)
        Me.lblWorkshopLogNo.Name = "lblWorkshopLogNo"
        Me.lblWorkshopLogNo.Size = New System.Drawing.Size(98, 13)
        Me.lblWorkshopLogNo.TabIndex = 117
        Me.lblWorkshopLogNo.Text = "Workshop Code"
        '
        'tpViewVRL
        '
        Me.tpViewVRL.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpViewVRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpViewVRL.Controls.Add(Me.pnlESearch)
        Me.tpViewVRL.Controls.Add(Me.PnlSearch)
        Me.tpViewVRL.Location = New System.Drawing.Point(4, 22)
        Me.tpViewVRL.Name = "tpViewVRL"
        Me.tpViewVRL.Padding = New System.Windows.Forms.Padding(3)
        Me.tpViewVRL.Size = New System.Drawing.Size(942, 743)
        Me.tpViewVRL.TabIndex = 1
        Me.tpViewVRL.Text = "View"
        Me.tpViewVRL.UseVisualStyleBackColor = True
        '
        'pnlESearch
        '
        Me.pnlESearch.Controls.Add(Me.dgWorkshop)
        Me.pnlESearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlESearch.Location = New System.Drawing.Point(3, 147)
        Me.pnlESearch.Name = "pnlESearch"
        Me.pnlESearch.Size = New System.Drawing.Size(936, 324)
        Me.pnlESearch.TabIndex = 41
        '
        'dgWorkshop
        '
        Me.dgWorkshop.AllowUserToAddRows = False
        Me.dgWorkshop.AllowUserToDeleteRows = False
        Me.dgWorkshop.AllowUserToResizeColumns = False
        Me.dgWorkshop.AllowUserToResizeRows = False
        Me.dgWorkshop.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgWorkshop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgWorkshop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWorkshop.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgWorkshop.ColumnHeadersHeight = 30
        Me.dgWorkshop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgWorkshop.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WDate, Me.WorkshopCode, Me.WPosted})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgWorkshop.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgWorkshop.EnableHeadersVisualStyles = False
        Me.dgWorkshop.GridColor = System.Drawing.Color.Gray
        Me.dgWorkshop.Location = New System.Drawing.Point(2, 2)
        Me.dgWorkshop.MultiSelect = False
        Me.dgWorkshop.Name = "dgWorkshop"
        Me.dgWorkshop.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWorkshop.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgWorkshop.RowHeadersVisible = False
        Me.dgWorkshop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWorkshop.Size = New System.Drawing.Size(376, 320)
        Me.dgWorkshop.TabIndex = 4
        Me.dgWorkshop.VirtualMode = True
        '
        'WDate
        '
        Me.WDate.DataPropertyName = "LogDate"
        Me.WDate.HeaderText = "Date"
        Me.WDate.Name = "WDate"
        Me.WDate.ReadOnly = True
        '
        'WorkshopCode
        '
        Me.WorkshopCode.DataPropertyName = "WorkshopVHID"
        Me.WorkshopCode.HeaderText = "Workshop Code"
        Me.WorkshopCode.Name = "WorkshopCode"
        Me.WorkshopCode.ReadOnly = True
        Me.WorkshopCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WorkshopCode.Width = 150
        '
        'WPosted
        '
        Me.WPosted.DataPropertyName = "Posted"
        Me.WPosted.HeaderText = "Posted"
        Me.WPosted.Name = "WPosted"
        Me.WPosted.ReadOnly = True
        '
        'PnlSearch
        '
        Me.PnlSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PnlSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Search Workshop Log"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.btnViewReport)
        Me.PnlSearch.Controls.Add(Me.btnSearch)
        Me.PnlSearch.Controls.Add(Me.lblViewVehicleCode)
        Me.PnlSearch.Controls.Add(Me.chkDate)
        Me.PnlSearch.Controls.Add(Me.lblSearchby)
        Me.PnlSearch.Controls.Add(Me.dtpSearchBydate)
        Me.PnlSearch.Controls.Add(Me.txtWorkshopSearch)
        Me.PnlSearch.Controls.Add(Me.pnlSearchDetails)
        Me.PnlSearch.Controls.Add(Me.lblColon29)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(936, 144)
        Me.PnlSearch.TabIndex = 39
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(710, 69)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(150, 29)
        Me.btnViewReport.TabIndex = 509
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(533, 69)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(150, 29)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblViewVehicleCode
        '
        Me.lblViewVehicleCode.AutoSize = True
        Me.lblViewVehicleCode.BackColor = System.Drawing.Color.Transparent
        Me.lblViewVehicleCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblViewVehicleCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblViewVehicleCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblViewVehicleCode.Location = New System.Drawing.Point(342, 43)
        Me.lblViewVehicleCode.Name = "lblViewVehicleCode"
        Me.lblViewVehicleCode.Size = New System.Drawing.Size(98, 13)
        Me.lblViewVehicleCode.TabIndex = 95
        Me.lblViewVehicleCode.Text = "Workshop Code"
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(147, 43)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(49, 17)
        Me.chkDate.TabIndex = 0
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'lblSearchby
        '
        Me.lblSearchby.AutoSize = True
        Me.lblSearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchby.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchby.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchby.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchby.Location = New System.Drawing.Point(3, 43)
        Me.lblSearchby.Name = "lblSearchby"
        Me.lblSearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchby.TabIndex = 94
        Me.lblSearchby.Text = "Search By"
        '
        'dtpSearchBydate
        '
        Me.dtpSearchBydate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSearchBydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchBydate.Location = New System.Drawing.Point(143, 69)
        Me.dtpSearchBydate.Name = "dtpSearchBydate"
        Me.dtpSearchBydate.Size = New System.Drawing.Size(169, 20)
        Me.dtpSearchBydate.TabIndex = 1
        '
        'txtWorkshopSearch
        '
        Me.txtWorkshopSearch.Location = New System.Drawing.Point(336, 69)
        Me.txtWorkshopSearch.Name = "txtWorkshopSearch"
        Me.txtWorkshopSearch.Size = New System.Drawing.Size(169, 20)
        Me.txtWorkshopSearch.TabIndex = 2
        '
        'pnlSearchDetails
        '
        Me.pnlSearchDetails.Controls.Add(Me.DataGridView1)
        Me.pnlSearchDetails.Location = New System.Drawing.Point(0, 157)
        Me.pnlSearchDetails.Name = "pnlSearchDetails"
        Me.pnlSearchDetails.Size = New System.Drawing.Size(1124, 425)
        Me.pnlSearchDetails.TabIndex = 33
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Size = New System.Drawing.Size(1118, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'lblColon29
        '
        Me.lblColon29.AutoSize = True
        Me.lblColon29.BackColor = System.Drawing.Color.Transparent
        Me.lblColon29.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblColon29.ForeColor = System.Drawing.Color.Black
        Me.lblColon29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColon29.Location = New System.Drawing.Point(129, 43)
        Me.lblColon29.Name = "lblColon29"
        Me.lblColon29.Size = New System.Drawing.Size(12, 13)
        Me.lblColon29.TabIndex = 70
        Me.lblColon29.Text = ":"
        '
        'cmsAddEditDelete
        '
        Me.cmsAddEditDelete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsAddEditDelete.Name = "cmsIPR"
        Me.cmsAddEditDelete.Size = New System.Drawing.Size(149, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EditToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'cmsView
        '
        Me.cmsView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiViewAdd, Me.tsmiViewEdit, Me.tsmiViewDelete})
        Me.cmsView.Name = "cmsIPR"
        Me.cmsView.Size = New System.Drawing.Size(149, 70)
        '
        'tsmiViewAdd
        '
        Me.tsmiViewAdd.Image = CType(resources.GetObject("tsmiViewAdd.Image"), System.Drawing.Image)
        Me.tsmiViewAdd.Name = "tsmiViewAdd"
        Me.tsmiViewAdd.Size = New System.Drawing.Size(148, 22)
        Me.tsmiViewAdd.Text = "Add"
        '
        'tsmiViewEdit
        '
        Me.tsmiViewEdit.Image = CType(resources.GetObject("tsmiViewEdit.Image"), System.Drawing.Image)
        Me.tsmiViewEdit.Name = "tsmiViewEdit"
        Me.tsmiViewEdit.Size = New System.Drawing.Size(148, 22)
        Me.tsmiViewEdit.Text = "Edit / Update"
        '
        'tsmiViewDelete
        '
        Me.tsmiViewDelete.Image = CType(resources.GetObject("tsmiViewDelete.Image"), System.Drawing.Image)
        Me.tsmiViewDelete.Name = "tsmiViewDelete"
        Me.tsmiViewDelete.Size = New System.Drawing.Size(148, 22)
        Me.tsmiViewDelete.Text = "Delete"
        '
        'WorkShopLogFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(960, 732)
        Me.Controls.Add(Me.plIB1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "WorkShopLogFrm"
        Me.Text = "Vehicle Running Log"
        Me.plIB1.ResumeLayout(False)
        Me.tbcWorkshop.ResumeLayout(False)
        Me.tbpgAdd.ResumeLayout(False)
        Me.gbAddReset.ResumeLayout(False)
        Me.gbListOfWorkshopLog.ResumeLayout(False)
        CType(Me.dgWorkshopRunningLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbWorkshopLog.ResumeLayout(False)
        Me.gbWorkshopLog.PerformLayout()
        Me.gbDivYopSubBlock.ResumeLayout(False)
        Me.gbDivYopSubBlock.PerformLayout()
        Me.gbTAnalysis.ResumeLayout(False)
        Me.gbTAnalysis.PerformLayout()
        Me.tpViewVRL.ResumeLayout(False)
        Me.pnlESearch.ResumeLayout(False)
        CType(Me.dgWorkshop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.pnlSearchDetails.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAddEditDelete.ResumeLayout(False)
        Me.cmsView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plIB1 As System.Windows.Forms.Panel
    Friend WithEvents tbcWorkshop As System.Windows.Forms.TabControl
    Friend WithEvents tpViewVRL As System.Windows.Forms.TabPage
    Friend WithEvents pnlSearchDetails As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblColon29 As System.Windows.Forms.Label
    Friend WithEvents txtWorkshopSearch As System.Windows.Forms.TextBox
    Friend WithEvents tbpgAdd As System.Windows.Forms.TabPage
    Friend WithEvents dtpSearchBydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbWorkshopLog As System.Windows.Forms.GroupBox
    Friend WithEvents pnlESearch As System.Windows.Forms.Panel
    Friend WithEvents gbListOfWorkshopLog As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSaveOrUpdate As System.Windows.Forms.Button
    Friend WithEvents gbAddReset As System.Windows.Forms.GroupBox
    Friend WithEvents ibtnSearchVehicle As System.Windows.Forms.Button
    Friend WithEvents lblActivity As System.Windows.Forms.Label
    Friend WithEvents ibtnSearchAccountCode As System.Windows.Forms.Button
    Friend WithEvents ibtnSearchOperatorCode As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents txtOperatorCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountCode As System.Windows.Forms.Label
    Friend WithEvents lblShowOperatorName As System.Windows.Forms.Label
    Friend WithEvents lblOperatorCode As System.Windows.Forms.Label
    Friend WithEvents txtTotalHrs As System.Windows.Forms.TextBox
    Friend WithEvents txtActivity As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalHrs As System.Windows.Forms.Label
    Friend WithEvents lblEndTime As System.Windows.Forms.Label
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents txtVehicleCode As System.Windows.Forms.TextBox
    Friend WithEvents lblVehicleCode As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblWorkshopLogNo As System.Windows.Forms.Label
    Friend WithEvents lblColon12 As System.Windows.Forms.Label
    Friend WithEvents lblColon11 As System.Windows.Forms.Label
    Friend WithEvents lblColon10 As System.Windows.Forms.Label
    Friend WithEvents lblColon9 As System.Windows.Forms.Label
    Friend WithEvents lblColon5 As System.Windows.Forms.Label
    Friend WithEvents lblColon4 As System.Windows.Forms.Label
    Friend WithEvents lblColon3 As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents lblColon2 As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents lblColon7 As System.Windows.Forms.Label
    Friend WithEvents lblColon6 As System.Windows.Forms.Label
    Friend WithEvents txtT4 As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSearchTAnalysisT4 As System.Windows.Forms.Button
    Friend WithEvents txtT3 As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSearchTAnalysisT3 As System.Windows.Forms.Button
    Friend WithEvents txtT2 As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSearchTAnalysisT2 As System.Windows.Forms.Button
    Friend WithEvents txtT1 As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSearchTAnalysisT1 As System.Windows.Forms.Button
    Friend WithEvents txtT0 As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSearchTAnalysisT0 As System.Windows.Forms.Button
    Friend WithEvents txtSubBlock As System.Windows.Forms.TextBox
    Friend WithEvents ibtnLookUpSubBlock As System.Windows.Forms.Button
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents txtDIV As System.Windows.Forms.TextBox
    Friend WithEvents ibtnLookUpDIV As System.Windows.Forms.Button
    Friend WithEvents lblTAnalysisT0 As System.Windows.Forms.Label
    Friend WithEvents lblTAnalysisT1 As System.Windows.Forms.Label
    Friend WithEvents lblTAnalysisT2 As System.Windows.Forms.Label
    Friend WithEvents lblTAnalysisT3 As System.Windows.Forms.Label
    Friend WithEvents lblTAnalysisT4 As System.Windows.Forms.Label
    Friend WithEvents lblDIV As System.Windows.Forms.Label
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents lblBlock As System.Windows.Forms.Label
    Friend WithEvents lblColon19 As System.Windows.Forms.Label
    Friend WithEvents lblColon18 As System.Windows.Forms.Label
    Friend WithEvents lblColon17 As System.Windows.Forms.Label
    Friend WithEvents lblColon15 As System.Windows.Forms.Label
    Friend WithEvents lblColon16 As System.Windows.Forms.Label
    Friend WithEvents dgWorkshopRunningLog As System.Windows.Forms.DataGridView
    Friend WithEvents dgWorkshop As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAddEditDelete As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblViewVehicleCode As System.Windows.Forms.Label
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmsView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiViewAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiViewEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiViewDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDivYopSubBlock As System.Windows.Forms.GroupBox
    Friend WithEvents gbTAnalysis As System.Windows.Forms.GroupBox
    Friend WithEvents LogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Workshop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vehicle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Activity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountCodeDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Posted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblShowOldAccountCode As System.Windows.Forms.Label
    Friend WithEvents lblShowAccountCodeDesc As System.Windows.Forms.Label
    Friend WithEvents cmbWorkshopCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOldAccountCode As System.Windows.Forms.Label
    Friend WithEvents lblShowWorkshopDesc As System.Windows.Forms.Label
    Friend WithEvents lblShowVehicleDesc As System.Windows.Forms.Label
    Friend WithEvents lblT0Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents lblT2Name As System.Windows.Forms.Label
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT4Name As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents WDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkshopCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WPosted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEndHr As System.Windows.Forms.TextBox
    Friend WithEvents txtEndMin As System.Windows.Forms.TextBox
    Friend WithEvents txtStartMin As System.Windows.Forms.TextBox
    Friend WithEvents txtStartHr As System.Windows.Forms.TextBox
End Class
