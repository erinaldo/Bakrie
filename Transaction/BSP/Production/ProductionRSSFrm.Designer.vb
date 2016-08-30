<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionRSSFrm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionRSSFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.tabSave = New System.Windows.Forms.TabPage()
        Me.txtstorage = New System.Windows.Forms.TextBox()
        Me.btnSearchSource = New System.Windows.Forms.Button()
        Me.lblsource = New System.Windows.Forms.Label()
        Me.btnprod = New System.Windows.Forms.Button()
        Me.txtproduct = New System.Windows.Forms.TextBox()
        Me.lblproducttype = New System.Windows.Forms.Label()
        Me.txtShiftHours = New System.Windows.Forms.TextBox()
        Me.lblshifthours = New System.Windows.Forms.Label()
        Me.txtBreakDownTime = New System.Windows.Forms.TextBox()
        Me.txtEndTime = New System.Windows.Forms.TextBox()
        Me.txtStartTime = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLatexProcess = New System.Windows.Forms.TextBox()
        Me.lbllatexprocess = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtAssistant = New System.Windows.Forms.TextBox()
        Me.lblstoptime = New System.Windows.Forms.Label()
        Me.lblassistant = New System.Windows.Forms.Label()
        Me.lblstarttime = New System.Windows.Forms.Label()
        Me.lblbreakdowntime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.tabSearchView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.cmsProductionRSS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchAssistant = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchTcktNum = New System.Windows.Forms.Label()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtAssistant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabContainerMain.SuspendLayout()
        Me.tabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSearchView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsProductionRSS.SuspendLayout()
        Me.pnlSearchLPO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabContainerMain
        '
        resources.ApplyResources(Me.TabContainerMain, "TabContainerMain")
        Me.TabContainerMain.Controls.Add(Me.tabSave)
        Me.TabContainerMain.Controls.Add(Me.tabSearchView)
        Me.TabContainerMain.Name = "TabContainerMain"
        Me.TabContainerMain.SelectedIndex = 0
        '
        'tabSave
        '
        resources.ApplyResources(Me.tabSave, "tabSave")
        Me.tabSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabSave.Controls.Add(Me.txtstorage)
        Me.tabSave.Controls.Add(Me.btnSearchSource)
        Me.tabSave.Controls.Add(Me.lblsource)
        Me.tabSave.Controls.Add(Me.btnprod)
        Me.tabSave.Controls.Add(Me.txtproduct)
        Me.tabSave.Controls.Add(Me.lblproducttype)
        Me.tabSave.Controls.Add(Me.txtShiftHours)
        Me.tabSave.Controls.Add(Me.lblshifthours)
        Me.tabSave.Controls.Add(Me.txtBreakDownTime)
        Me.tabSave.Controls.Add(Me.txtEndTime)
        Me.tabSave.Controls.Add(Me.txtStartTime)
        Me.tabSave.Controls.Add(Me.GroupBox1)
        Me.tabSave.Controls.Add(Me.dtpDate)
        Me.tabSave.Controls.Add(Me.txtAssistant)
        Me.tabSave.Controls.Add(Me.lblstoptime)
        Me.tabSave.Controls.Add(Me.lblassistant)
        Me.tabSave.Controls.Add(Me.lblstarttime)
        Me.tabSave.Controls.Add(Me.lblbreakdowntime)
        Me.tabSave.Controls.Add(Me.lbldate)
        Me.tabSave.Name = "tabSave"
        Me.tabSave.UseVisualStyleBackColor = True
        '
        'txtstorage
        '
        resources.ApplyResources(Me.txtstorage, "txtstorage")
        Me.txtstorage.Name = "txtstorage"
        '
        'btnSearchSource
        '
        resources.ApplyResources(Me.btnSearchSource, "btnSearchSource")
        Me.btnSearchSource.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchSource.FlatAppearance.BorderSize = 0
        Me.btnSearchSource.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchSource.Name = "btnSearchSource"
        Me.btnSearchSource.TabStop = False
        Me.btnSearchSource.UseVisualStyleBackColor = True
        '
        'lblsource
        '
        resources.ApplyResources(Me.lblsource, "lblsource")
        Me.lblsource.Name = "lblsource"
        '
        'btnprod
        '
        resources.ApplyResources(Me.btnprod, "btnprod")
        Me.btnprod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnprod.FlatAppearance.BorderSize = 0
        Me.btnprod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnprod.Name = "btnprod"
        Me.btnprod.TabStop = False
        Me.btnprod.UseVisualStyleBackColor = True
        '
        'txtproduct
        '
        resources.ApplyResources(Me.txtproduct, "txtproduct")
        Me.txtproduct.Name = "txtproduct"
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
        'txtStartTime
        '
        resources.ApplyResources(Me.txtStartTime, "txtStartTime")
        Me.txtStartTime.Name = "txtStartTime"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.txtLatexProcess)
        Me.GroupBox1.Controls.Add(Me.lbllatexprocess)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnResetAll)
        Me.GroupBox1.Controls.Add(Me.btnSaveAll)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtLatexProcess
        '
        resources.ApplyResources(Me.txtLatexProcess, "txtLatexProcess")
        Me.txtLatexProcess.Name = "txtLatexProcess"
        '
        'lbllatexprocess
        '
        resources.ApplyResources(Me.lbllatexprocess, "lbllatexprocess")
        Me.lbllatexprocess.Name = "lbllatexprocess"
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Button3.Image = Global.BSP.My.Resources.Resources.user_add
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnClose.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        resources.ApplyResources(Me.btnResetAll, "btnResetAll")
        Me.btnResetAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnResetAll.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        resources.ApplyResources(Me.btnSaveAll, "btnSaveAll")
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSaveAll.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.UseVisualStyleBackColor = True
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
        'tabSearchView
        '
        resources.ApplyResources(Me.tabSearchView, "tabSearchView")
        Me.tabSearchView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tabSearchView.Controls.Add(Me.lblView)
        Me.tabSearchView.Controls.Add(Me.dgvView)
        Me.tabSearchView.Controls.Add(Me.pnlSearchLPO)
        Me.tabSearchView.Name = "tabSearchView"
        Me.tabSearchView.UseVisualStyleBackColor = True
        '
        'lblView
        '
        resources.ApplyResources(Me.lblView, "lblView")
        Me.lblView.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Name = "lblView"
        '
        'dgvView
        '
        resources.ApplyResources(Me.dgvView, "dgvView")
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.DateTwo, Me.dgtxtAssistant})
        Me.dgvView.ContextMenuStrip = Me.cmsProductionRSS
        Me.dgvView.EnableHeadersVisualStyles = False
        Me.dgvView.GridColor = System.Drawing.Color.Gray
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'cmsProductionRSS
        '
        resources.ApplyResources(Me.cmsProductionRSS, "cmsProductionRSS")
        Me.cmsProductionRSS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsProductionRSS.Name = "cmsIPR"
        '
        'AddToolStripMenuItem
        '
        resources.ApplyResources(Me.AddToolStripMenuItem, "AddToolStripMenuItem")
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        '
        'EditToolStripMenuItem
        '
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        '
        'DeleteToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        '
        'pnlSearchLPO
        '
        resources.ApplyResources(Me.pnlSearchLPO, "pnlSearchLPO")
        Me.pnlSearchLPO.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.pnlSearchLPO.BorderColor = System.Drawing.Color.Gray
        Me.pnlSearchLPO.CaptionColorOne = System.Drawing.Color.White
        Me.pnlSearchLPO.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlSearchLPO.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearchLPO.CaptionSize = 40
        Me.pnlSearchLPO.CaptionText = "Search Production RSS Data"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchAssistant)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchTcktNum)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.DataGridView3)
        Me.Panel1.Name = "Panel1"
        '
        'DataGridView3
        '
        resources.ApplyResources(Me.DataGridView3, "DataGridView3")
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        '
        'lblSearch
        '
        resources.ApplyResources(Me.lblSearch, "lblSearch")
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.Name = "lblSearch"
        '
        'Label67
        '
        resources.ApplyResources(Me.Label67, "Label67")
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.Name = "Label67"
        '
        'chkDocDate
        '
        resources.ApplyResources(Me.chkDocDate, "chkDocDate")
        Me.chkDocDate.Name = "chkDocDate"
        Me.chkDocDate.UseVisualStyleBackColor = True
        '
        'dtpSearchDocDate
        '
        resources.ApplyResources(Me.dtpSearchDocDate, "dtpSearchDocDate")
        Me.dtpSearchDocDate.CalendarTitleBackColor = System.Drawing.Color.Blue
        Me.dtpSearchDocDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpSearchDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchDocDate.Name = "dtpSearchDocDate"
        '
        'btnLPOViewReport
        '
        resources.ApplyResources(Me.btnLPOViewReport, "btnLPOViewReport")
        Me.btnLPOViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnLPOViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnLPOViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnLPOViewReport.Name = "btnLPOViewReport"
        Me.btnLPOViewReport.UseVisualStyleBackColor = True
        '
        'txtSearchAssistant
        '
        resources.ApplyResources(Me.txtSearchAssistant, "txtSearchAssistant")
        Me.txtSearchAssistant.Name = "txtSearchAssistant"
        '
        'btnViewSearch
        '
        resources.ApplyResources(Me.btnViewSearch, "btnViewSearch")
        Me.btnViewSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewSearch.Name = "btnViewSearch"
        Me.btnViewSearch.UseVisualStyleBackColor = True
        '
        'lblSearchTcktNum
        '
        resources.ApplyResources(Me.lblSearchTcktNum, "lblSearchTcktNum")
        Me.lblSearchTcktNum.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchTcktNum.ForeColor = System.Drawing.Color.Black
        Me.lblSearchTcktNum.Name = "lblSearchTcktNum"
        '
        'dgtxtDocID
        '
        Me.dgtxtDocID.DataPropertyName = "Id"
        resources.ApplyResources(Me.dgtxtDocID, "dgtxtDocID")
        Me.dgtxtDocID.Name = "dgtxtDocID"
        Me.dgtxtDocID.ReadOnly = True
        '
        'DateTwo
        '
        Me.DateTwo.DataPropertyName = "DocDate"
        resources.ApplyResources(Me.DateTwo, "DateTwo")
        Me.DateTwo.Name = "DateTwo"
        Me.DateTwo.ReadOnly = True
        '
        'dgtxtAssistant
        '
        Me.dgtxtAssistant.DataPropertyName = "Assistant"
        resources.ApplyResources(Me.dgtxtAssistant, "dgtxtAssistant")
        Me.dgtxtAssistant.Name = "dgtxtAssistant"
        Me.dgtxtAssistant.ReadOnly = True
        '
        'ProductionRSSFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionRSSFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.tabSave.ResumeLayout(False)
        Me.tabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSearchView.ResumeLayout(False)
        Me.tabSearchView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsProductionRSS.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents tabSave As System.Windows.Forms.TabPage
    Friend WithEvents lblproducttype As System.Windows.Forms.Label
    Friend WithEvents txtShiftHours As System.Windows.Forms.TextBox
    Friend WithEvents lblshifthours As System.Windows.Forms.Label
    Friend WithEvents txtBreakDownTime As System.Windows.Forms.TextBox
    Friend WithEvents txtEndTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStartTime As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLatexProcess As System.Windows.Forms.TextBox
    Friend WithEvents lbllatexprocess As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAssistant As System.Windows.Forms.TextBox
    Friend WithEvents lblstoptime As System.Windows.Forms.Label
    Friend WithEvents lblassistant As System.Windows.Forms.Label
    Friend WithEvents lblstarttime As System.Windows.Forms.Label
    Friend WithEvents lblbreakdowntime As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents tabSearchView As System.Windows.Forms.TabPage
    Friend WithEvents btnprod As System.Windows.Forms.Button
    Friend WithEvents txtproduct As System.Windows.Forms.TextBox
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchAssistant As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchTcktNum As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents cmsProductionRSS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtstorage As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchSource As System.Windows.Forms.Button
    Friend WithEvents lblsource As System.Windows.Forms.Label
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTwo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtAssistant As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
