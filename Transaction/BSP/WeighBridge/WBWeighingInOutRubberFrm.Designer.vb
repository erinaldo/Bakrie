<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBWeighingInOutRubberFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WBWeighingInOutRubberFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.tabSave = New System.Windows.Forms.TabPage()
        Me.btnSearchEstate = New System.Windows.Forms.Button()
        Me.btnSearchTicketNum = New System.Windows.Forms.Button()
        Me.btnSearchTruck = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDrc = New System.Windows.Forms.TextBox()
        Me.txtDry = New System.Windows.Forms.TextBox()
        Me.txtWet = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.wbdry = New System.Windows.Forms.Label()
        Me.wbwet = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtDiv = New System.Windows.Forms.TextBox()
        Me.txtEstateID = New System.Windows.Forms.TextBox()
        Me.txtTicketNum = New System.Windows.Forms.TextBox()
        Me.txtDocID = New System.Windows.Forms.TextBox()
        Me.txtVehicleID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.tabSearchView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.cmsWBRubber = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.txtSearchVehicleID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblStatusLPOView = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchWBTcktNum = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchTcktNum = New System.Windows.Forms.Label()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtWbTcktNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabContainerMain.SuspendLayout()
        Me.tabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSearchView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsWBRubber.SuspendLayout()
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
        Me.tabSave.Controls.Add(Me.btnSearchEstate)
        Me.tabSave.Controls.Add(Me.btnSearchTicketNum)
        Me.tabSave.Controls.Add(Me.btnSearchTruck)
        Me.tabSave.Controls.Add(Me.btnSaveAll)
        Me.tabSave.Controls.Add(Me.btnReset)
        Me.tabSave.Controls.Add(Me.btnClose)
        Me.tabSave.Controls.Add(Me.GroupBox1)
        Me.tabSave.Controls.Add(Me.dtpDate)
        Me.tabSave.Controls.Add(Me.txtDiv)
        Me.tabSave.Controls.Add(Me.txtEstateID)
        Me.tabSave.Controls.Add(Me.txtTicketNum)
        Me.tabSave.Controls.Add(Me.txtDocID)
        Me.tabSave.Controls.Add(Me.txtVehicleID)
        Me.tabSave.Controls.Add(Me.Label4)
        Me.tabSave.Controls.Add(Me.Label6)
        Me.tabSave.Controls.Add(Me.Label3)
        Me.tabSave.Controls.Add(Me.Label2)
        Me.tabSave.Controls.Add(Me.Label1)
        Me.tabSave.Controls.Add(Me.lbldate)
        Me.tabSave.Name = "tabSave"
        Me.tabSave.UseVisualStyleBackColor = True
        '
        'btnSearchEstate
        '
        resources.ApplyResources(Me.btnSearchEstate, "btnSearchEstate")
        Me.btnSearchEstate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchEstate.FlatAppearance.BorderSize = 0
        Me.btnSearchEstate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchEstate.Name = "btnSearchEstate"
        Me.btnSearchEstate.TabStop = False
        Me.btnSearchEstate.UseVisualStyleBackColor = True
        '
        'btnSearchTicketNum
        '
        resources.ApplyResources(Me.btnSearchTicketNum, "btnSearchTicketNum")
        Me.btnSearchTicketNum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchTicketNum.FlatAppearance.BorderSize = 0
        Me.btnSearchTicketNum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchTicketNum.Name = "btnSearchTicketNum"
        Me.btnSearchTicketNum.TabStop = False
        Me.btnSearchTicketNum.UseVisualStyleBackColor = True
        '
        'btnSearchTruck
        '
        resources.ApplyResources(Me.btnSearchTruck, "btnSearchTruck")
        Me.btnSearchTruck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchTruck.FlatAppearance.BorderSize = 0
        Me.btnSearchTruck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchTruck.Name = "btnSearchTruck"
        Me.btnSearchTruck.TabStop = False
        Me.btnSearchTruck.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        resources.ApplyResources(Me.btnSaveAll, "btnSaveAll")
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSaveAll.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        resources.ApplyResources(Me.btnReset, "btnReset")
        Me.btnReset.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnReset.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnReset.Name = "btnReset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnClose.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.txtDrc)
        Me.GroupBox1.Controls.Add(Me.txtDry)
        Me.GroupBox1.Controls.Add(Me.txtWet)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.wbdry)
        Me.GroupBox1.Controls.Add(Me.wbwet)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtDrc
        '
        resources.ApplyResources(Me.txtDrc, "txtDrc")
        Me.txtDrc.Name = "txtDrc"
        '
        'txtDry
        '
        resources.ApplyResources(Me.txtDry, "txtDry")
        Me.txtDry.Name = "txtDry"
        '
        'txtWet
        '
        resources.ApplyResources(Me.txtWet, "txtWet")
        Me.txtWet.Name = "txtWet"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'wbdry
        '
        resources.ApplyResources(Me.wbdry, "wbdry")
        Me.wbdry.Name = "wbdry"
        '
        'wbwet
        '
        resources.ApplyResources(Me.wbwet, "wbwet")
        Me.wbwet.Name = "wbwet"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        '
        'txtDiv
        '
        resources.ApplyResources(Me.txtDiv, "txtDiv")
        Me.txtDiv.Name = "txtDiv"
        '
        'txtEstateID
        '
        resources.ApplyResources(Me.txtEstateID, "txtEstateID")
        Me.txtEstateID.Name = "txtEstateID"
        '
        'txtTicketNum
        '
        resources.ApplyResources(Me.txtTicketNum, "txtTicketNum")
        Me.txtTicketNum.Name = "txtTicketNum"
        '
        'txtDocID
        '
        resources.ApplyResources(Me.txtDocID, "txtDocID")
        Me.txtDocID.Name = "txtDocID"
        '
        'txtVehicleID
        '
        resources.ApplyResources(Me.txtVehicleID, "txtVehicleID")
        Me.txtVehicleID.Name = "txtVehicleID"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
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
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.dgtxtDocDate, Me.dgtxtWbTcktNum})
        Me.dgvView.ContextMenuStrip = Me.cmsWBRubber
        Me.dgvView.EnableHeadersVisualStyles = False
        Me.dgvView.GridColor = System.Drawing.Color.Gray
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'cmsWBRubber
        '
        resources.ApplyResources(Me.cmsWBRubber, "cmsWBRubber")
        Me.cmsWBRubber.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsWBRubber.Name = "cmsIPR"
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
        Me.pnlSearchLPO.CaptionText = "Search Rubber In Out Data"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchVehicleID)
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblStatusLPOView)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchWBTcktNum)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchTcktNum)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        '
        'txtSearchVehicleID
        '
        resources.ApplyResources(Me.txtSearchVehicleID, "txtSearchVehicleID")
        Me.txtSearchVehicleID.Name = "txtSearchVehicleID"
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
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
        'lblStatusLPOView
        '
        resources.ApplyResources(Me.lblStatusLPOView, "lblStatusLPOView")
        Me.lblStatusLPOView.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusLPOView.ForeColor = System.Drawing.Color.Black
        Me.lblStatusLPOView.Name = "lblStatusLPOView"
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
        'txtSearchWBTcktNum
        '
        resources.ApplyResources(Me.txtSearchWBTcktNum, "txtSearchWBTcktNum")
        Me.txtSearchWBTcktNum.Name = "txtSearchWBTcktNum"
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
        'dgtxtDocDate
        '
        Me.dgtxtDocDate.DataPropertyName = "DocDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        Me.dgtxtDocDate.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.dgtxtDocDate, "dgtxtDocDate")
        Me.dgtxtDocDate.Name = "dgtxtDocDate"
        Me.dgtxtDocDate.ReadOnly = True
        '
        'dgtxtWbTcktNum
        '
        Me.dgtxtWbTcktNum.DataPropertyName = "WBTicketNo"
        resources.ApplyResources(Me.dgtxtWbTcktNum, "dgtxtWbTcktNum")
        Me.dgtxtWbTcktNum.Name = "dgtxtWbTcktNum"
        Me.dgtxtWbTcktNum.ReadOnly = True
        '
        'WBWeighingInOutRubberFrm
        '
        Me.AcceptButton = Me.btnSaveAll
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WBWeighingInOutRubberFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.tabSave.ResumeLayout(False)
        Me.tabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSearchView.ResumeLayout(False)
        Me.tabSearchView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsWBRubber.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents tabSave As System.Windows.Forms.TabPage
    Friend WithEvents tabSearchView As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDiv As System.Windows.Forms.TextBox
    Friend WithEvents txtEstateID As System.Windows.Forms.TextBox
    Friend WithEvents txtVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents wbdry As System.Windows.Forms.Label
    Friend WithEvents wbwet As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDrc As System.Windows.Forms.TextBox
    Friend WithEvents txtDry As System.Windows.Forms.TextBox
    Friend WithEvents txtWet As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtDocID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmsWBRubber As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblStatusLPOView As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchWBTcktNum As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchTcktNum As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents txtSearchVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents btnSearchTruck As System.Windows.Forms.Button
    Friend WithEvents txtTicketNum As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchTicketNum As System.Windows.Forms.Button
    Friend WithEvents btnSearchEstate As System.Windows.Forms.Button
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtWbTcktNum As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
