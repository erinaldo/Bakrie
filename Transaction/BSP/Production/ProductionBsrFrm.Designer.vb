<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionBsrFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionBsrFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.TabSave = New System.Windows.Forms.TabPage()
        Me.btnprod = New System.Windows.Forms.Button()
        Me.btnstor = New System.Windows.Forms.Button()
        Me.txtprod = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtstorage = New System.Windows.Forms.TextBox()
        Me.txtshifthours = New System.Windows.Forms.TextBox()
        Me.txtbreakdowntime = New System.Windows.Forms.TextBox()
        Me.txtstarttime = New System.Windows.Forms.TextBox()
        Me.txtstoptime = New System.Windows.Forms.TextBox()
        Me.txtassistant = New System.Windows.Forms.TextBox()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnreset = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtcreepbsr = New System.Windows.Forms.TextBox()
        Me.txtsludgebsr = New System.Windows.Forms.TextBox()
        Me.txtwash = New System.Windows.Forms.TextBox()
        Me.txtbutiran = New System.Windows.Forms.TextBox()
        Me.txtskim = New System.Windows.Forms.TextBox()
        Me.txttreelac = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabSearch = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvViewBSR = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtstor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsbsr = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.txtSearchType = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblSearchType = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchSource = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchSource = New System.Windows.Forms.Label()
        Me.TabContainerMain.SuspendLayout()
        Me.TabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabSearch.SuspendLayout()
        CType(Me.dgvViewBSR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsbsr.SuspendLayout()
        Me.pnlSearchLPO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabContainerMain
        '
        resources.ApplyResources(Me.TabContainerMain, "TabContainerMain")
        Me.TabContainerMain.Controls.Add(Me.TabSave)
        Me.TabContainerMain.Controls.Add(Me.TabSearch)
        Me.TabContainerMain.Name = "TabContainerMain"
        Me.TabContainerMain.SelectedIndex = 0
        '
        'TabSave
        '
        resources.ApplyResources(Me.TabSave, "TabSave")
        Me.TabSave.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.TabSave.Controls.Add(Me.btnprod)
        Me.TabSave.Controls.Add(Me.btnstor)
        Me.TabSave.Controls.Add(Me.txtprod)
        Me.TabSave.Controls.Add(Me.Label14)
        Me.TabSave.Controls.Add(Me.txtstorage)
        Me.TabSave.Controls.Add(Me.txtshifthours)
        Me.TabSave.Controls.Add(Me.txtbreakdowntime)
        Me.TabSave.Controls.Add(Me.txtstarttime)
        Me.TabSave.Controls.Add(Me.txtstoptime)
        Me.TabSave.Controls.Add(Me.txtassistant)
        Me.TabSave.Controls.Add(Me.dtpdate)
        Me.TabSave.Controls.Add(Me.btnsave)
        Me.TabSave.Controls.Add(Me.btnupdate)
        Me.TabSave.Controls.Add(Me.btnreset)
        Me.TabSave.Controls.Add(Me.btnclose)
        Me.TabSave.Controls.Add(Me.GroupBox1)
        Me.TabSave.Controls.Add(Me.Label9)
        Me.TabSave.Controls.Add(Me.Label6)
        Me.TabSave.Controls.Add(Me.Label5)
        Me.TabSave.Controls.Add(Me.Label4)
        Me.TabSave.Controls.Add(Me.Label3)
        Me.TabSave.Controls.Add(Me.Label2)
        Me.TabSave.Controls.Add(Me.Label1)
        Me.TabSave.Name = "TabSave"
        Me.TabSave.UseVisualStyleBackColor = True
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
        'btnstor
        '
        resources.ApplyResources(Me.btnstor, "btnstor")
        Me.btnstor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnstor.FlatAppearance.BorderSize = 0
        Me.btnstor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnstor.Name = "btnstor"
        Me.btnstor.TabStop = False
        Me.btnstor.UseVisualStyleBackColor = True
        '
        'txtprod
        '
        resources.ApplyResources(Me.txtprod, "txtprod")
        Me.txtprod.Name = "txtprod"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'txtstorage
        '
        resources.ApplyResources(Me.txtstorage, "txtstorage")
        Me.txtstorage.Name = "txtstorage"
        '
        'txtshifthours
        '
        resources.ApplyResources(Me.txtshifthours, "txtshifthours")
        Me.txtshifthours.Name = "txtshifthours"
        '
        'txtbreakdowntime
        '
        resources.ApplyResources(Me.txtbreakdowntime, "txtbreakdowntime")
        Me.txtbreakdowntime.Name = "txtbreakdowntime"
        '
        'txtstarttime
        '
        resources.ApplyResources(Me.txtstarttime, "txtstarttime")
        Me.txtstarttime.Name = "txtstarttime"
        '
        'txtstoptime
        '
        resources.ApplyResources(Me.txtstoptime, "txtstoptime")
        Me.txtstoptime.Name = "txtstoptime"
        '
        'txtassistant
        '
        resources.ApplyResources(Me.txtassistant, "txtassistant")
        Me.txtassistant.Name = "txtassistant"
        '
        'dtpdate
        '
        resources.ApplyResources(Me.dtpdate, "dtpdate")
        Me.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpdate.Name = "dtpdate"
        '
        'btnsave
        '
        resources.ApplyResources(Me.btnsave, "btnsave")
        Me.btnsave.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnsave.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnsave.Name = "btnsave"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnupdate
        '
        resources.ApplyResources(Me.btnupdate, "btnupdate")
        Me.btnupdate.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnupdate.Image = Global.BSP.My.Resources.Resources.user_add
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.UseVisualStyleBackColor = True
        '
        'btnreset
        '
        resources.ApplyResources(Me.btnreset, "btnreset")
        Me.btnreset.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnreset.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnreset.Name = "btnreset"
        Me.btnreset.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        resources.ApplyResources(Me.btnclose, "btnclose")
        Me.btnclose.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnclose.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnclose.Name = "btnclose"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.txtcreepbsr)
        Me.GroupBox1.Controls.Add(Me.txtsludgebsr)
        Me.GroupBox1.Controls.Add(Me.txtwash)
        Me.GroupBox1.Controls.Add(Me.txtbutiran)
        Me.GroupBox1.Controls.Add(Me.txtskim)
        Me.GroupBox1.Controls.Add(Me.txttreelac)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtcreepbsr
        '
        resources.ApplyResources(Me.txtcreepbsr, "txtcreepbsr")
        Me.txtcreepbsr.Name = "txtcreepbsr"
        '
        'txtsludgebsr
        '
        resources.ApplyResources(Me.txtsludgebsr, "txtsludgebsr")
        Me.txtsludgebsr.Name = "txtsludgebsr"
        '
        'txtwash
        '
        resources.ApplyResources(Me.txtwash, "txtwash")
        Me.txtwash.Name = "txtwash"
        '
        'txtbutiran
        '
        resources.ApplyResources(Me.txtbutiran, "txtbutiran")
        Me.txtbutiran.Name = "txtbutiran"
        '
        'txtskim
        '
        resources.ApplyResources(Me.txtskim, "txtskim")
        Me.txtskim.Name = "txtskim"
        '
        'txttreelac
        '
        resources.ApplyResources(Me.txttreelac, "txttreelac")
        Me.txttreelac.Name = "txttreelac"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
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
        'TabSearch
        '
        resources.ApplyResources(Me.TabSearch, "TabSearch")
        Me.TabSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.TabSearch.Controls.Add(Me.lblView)
        Me.TabSearch.Controls.Add(Me.dgvViewBSR)
        Me.TabSearch.Controls.Add(Me.pnlSearchLPO)
        Me.TabSearch.Name = "TabSearch"
        Me.TabSearch.UseVisualStyleBackColor = True
        '
        'lblView
        '
        resources.ApplyResources(Me.lblView, "lblView")
        Me.lblView.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Name = "lblView"
        '
        'dgvViewBSR
        '
        resources.ApplyResources(Me.dgvViewBSR, "dgvViewBSR")
        Me.dgvViewBSR.AllowUserToAddRows = False
        Me.dgvViewBSR.AllowUserToDeleteRows = False
        Me.dgvViewBSR.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvViewBSR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvViewBSR.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvViewBSR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvViewBSR.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvViewBSR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvViewBSR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.dgtxtDocDate, Me.dgtxtprod, Me.dgvtxtstor})
        Me.dgvViewBSR.ContextMenuStrip = Me.cmsbsr
        Me.dgvViewBSR.EnableHeadersVisualStyles = False
        Me.dgvViewBSR.GridColor = System.Drawing.Color.Gray
        Me.dgvViewBSR.MultiSelect = False
        Me.dgvViewBSR.Name = "dgvViewBSR"
        Me.dgvViewBSR.ReadOnly = True
        Me.dgvViewBSR.RowHeadersVisible = False
        Me.dgvViewBSR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'dgtxtDocID
        '
        Me.dgtxtDocID.DataPropertyName = "TransId"
        resources.ApplyResources(Me.dgtxtDocID, "dgtxtDocID")
        Me.dgtxtDocID.Name = "dgtxtDocID"
        Me.dgtxtDocID.ReadOnly = True
        '
        'dgtxtDocDate
        '
        Me.dgtxtDocDate.DataPropertyName = "DocDate"
        resources.ApplyResources(Me.dgtxtDocDate, "dgtxtDocDate")
        Me.dgtxtDocDate.Name = "dgtxtDocDate"
        Me.dgtxtDocDate.ReadOnly = True
        '
        'dgtxtprod
        '
        Me.dgtxtprod.DataPropertyName = "BSRProduct"
        resources.ApplyResources(Me.dgtxtprod, "dgtxtprod")
        Me.dgtxtprod.Name = "dgtxtprod"
        Me.dgtxtprod.ReadOnly = True
        '
        'dgvtxtstor
        '
        Me.dgvtxtstor.DataPropertyName = "BSRStorage"
        resources.ApplyResources(Me.dgvtxtstor, "dgvtxtstor")
        Me.dgvtxtstor.Name = "dgvtxtstor"
        Me.dgvtxtstor.ReadOnly = True
        '
        'cmsbsr
        '
        resources.ApplyResources(Me.cmsbsr, "cmsbsr")
        Me.cmsbsr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsbsr.Name = "cmsbsr"
        '
        'AddToolStripMenuItem
        '
        resources.ApplyResources(Me.AddToolStripMenuItem, "AddToolStripMenuItem")
        Me.AddToolStripMenuItem.Image = Global.BSP.My.Resources.Resources.user_add1
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        '
        'EditToolStripMenuItem
        '
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        Me.EditToolStripMenuItem.Image = Global.BSP.My.Resources.Resources.icon_edit
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        '
        'DeleteToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        Me.DeleteToolStripMenuItem.Image = Global.BSP.My.Resources.Resources.icon_delete
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
        Me.pnlSearchLPO.CaptionText = "Search BSR Details"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchType)
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchType)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchSource)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchSource)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        '
        'txtSearchType
        '
        resources.ApplyResources(Me.txtSearchType, "txtSearchType")
        Me.txtSearchType.Name = "txtSearchType"
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
        'lblSearchType
        '
        resources.ApplyResources(Me.lblSearchType, "lblSearchType")
        Me.lblSearchType.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchType.ForeColor = System.Drawing.Color.Black
        Me.lblSearchType.Name = "lblSearchType"
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
        'txtSearchSource
        '
        resources.ApplyResources(Me.txtSearchSource, "txtSearchSource")
        Me.txtSearchSource.Name = "txtSearchSource"
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
        'lblSearchSource
        '
        resources.ApplyResources(Me.lblSearchSource, "lblSearchSource")
        Me.lblSearchSource.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchSource.ForeColor = System.Drawing.Color.Black
        Me.lblSearchSource.Name = "lblSearchSource"
        '
        'ProductionBsrFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionBsrFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.TabSave.ResumeLayout(False)
        Me.TabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSearch.ResumeLayout(False)
        Me.TabSearch.PerformLayout()
        CType(Me.dgvViewBSR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsbsr.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents TabSave As System.Windows.Forms.TabPage
    Friend WithEvents TabSearch As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents btnreset As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtassistant As System.Windows.Forms.TextBox
    Friend WithEvents txtshifthours As System.Windows.Forms.TextBox
    Friend WithEvents txtbreakdowntime As System.Windows.Forms.TextBox
    Friend WithEvents txtstarttime As System.Windows.Forms.TextBox
    Friend WithEvents txtstoptime As System.Windows.Forms.TextBox
    Friend WithEvents txtcreepbsr As System.Windows.Forms.TextBox
    Friend WithEvents txtsludgebsr As System.Windows.Forms.TextBox
    Friend WithEvents txtwash As System.Windows.Forms.TextBox
    Friend WithEvents txtbutiran As System.Windows.Forms.TextBox
    Friend WithEvents txtskim As System.Windows.Forms.TextBox
    Friend WithEvents txttreelac As System.Windows.Forms.TextBox
    Friend WithEvents txtstorage As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtprod As System.Windows.Forms.TextBox
    Friend WithEvents btnprod As System.Windows.Forms.Button
    Friend WithEvents btnstor As System.Windows.Forms.Button
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents txtSearchType As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblSearchType As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchSource As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchSource As System.Windows.Forms.Label
    Friend WithEvents dgvViewBSR As System.Windows.Forms.DataGridView
    Friend WithEvents cmsbsr As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtstor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
