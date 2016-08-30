<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionQcdCenexFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionQcdCenexFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.TabSave = New System.Windows.Forms.TabPage()
        Me.btnTrain = New System.Windows.Forms.Button()
        Me.btnCat = New System.Windows.Forms.Button()
        Me.btnLoadLoc = New System.Windows.Forms.Button()
        Me.txtLoadLoc = New System.Windows.Forms.TextBox()
        Me.txttrain = New System.Windows.Forms.TextBox()
        Me.txtCat = New System.Windows.Forms.TextBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.txtSEDO = New System.Windows.Forms.TextBox()
        Me.lblse = New System.Windows.Forms.Label()
        Me.lbldestination = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtmgppm = New System.Windows.Forms.TextBox()
        Me.lblmgppm = New System.Windows.Forms.Label()
        Me.txtKOH = New System.Windows.Forms.TextBox()
        Me.lblkoh = New System.Windows.Forms.Label()
        Me.txtMST = New System.Windows.Forms.TextBox()
        Me.lblmst = New System.Windows.Forms.Label()
        Me.txtVFA = New System.Windows.Forms.TextBox()
        Me.lblvfa = New System.Windows.Forms.Label()
        Me.txtNH3 = New System.Windows.Forms.TextBox()
        Me.lblnh3 = New System.Windows.Forms.Label()
        Me.txtNrc = New System.Windows.Forms.TextBox()
        Me.lblnrc = New System.Windows.Forms.Label()
        Me.txtTSC = New System.Windows.Forms.TextBox()
        Me.lbltsc = New System.Windows.Forms.Label()
        Me.txtDrcPer = New System.Windows.Forms.TextBox()
        Me.lbldrcper = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblquantity = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lbllodinglocation = New System.Windows.Forms.Label()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.lbltruck = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.TabSearch = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtstor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsqcdcnx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.txtSearchCat = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblSearchCat = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchTrain = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchTrain = New System.Windows.Forms.Label()
        Me.TabContainerMain.SuspendLayout()
        Me.TabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabSearch.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsqcdcnx.SuspendLayout()
        Me.pnlSearchLPO.SuspendLayout()
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
        Me.TabSave.Controls.Add(Me.btnTrain)
        Me.TabSave.Controls.Add(Me.btnCat)
        Me.TabSave.Controls.Add(Me.btnLoadLoc)
        Me.TabSave.Controls.Add(Me.txtLoadLoc)
        Me.TabSave.Controls.Add(Me.txttrain)
        Me.TabSave.Controls.Add(Me.txtCat)
        Me.TabSave.Controls.Add(Me.txtDestination)
        Me.TabSave.Controls.Add(Me.txtSEDO)
        Me.TabSave.Controls.Add(Me.lblse)
        Me.TabSave.Controls.Add(Me.lbldestination)
        Me.TabSave.Controls.Add(Me.btnSave)
        Me.TabSave.Controls.Add(Me.btnUpdate)
        Me.TabSave.Controls.Add(Me.btnReset)
        Me.TabSave.Controls.Add(Me.btnClose)
        Me.TabSave.Controls.Add(Me.GroupBox1)
        Me.TabSave.Controls.Add(Me.dtpDate)
        Me.TabSave.Controls.Add(Me.lbllodinglocation)
        Me.TabSave.Controls.Add(Me.lblcategory)
        Me.TabSave.Controls.Add(Me.lbltruck)
        Me.TabSave.Controls.Add(Me.lbldate)
        Me.TabSave.Name = "TabSave"
        Me.TabSave.UseVisualStyleBackColor = True
        '
        'btnTrain
        '
        resources.ApplyResources(Me.btnTrain, "btnTrain")
        Me.btnTrain.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTrain.FlatAppearance.BorderSize = 0
        Me.btnTrain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTrain.Name = "btnTrain"
        Me.btnTrain.TabStop = False
        Me.btnTrain.UseVisualStyleBackColor = True
        '
        'btnCat
        '
        resources.ApplyResources(Me.btnCat, "btnCat")
        Me.btnCat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCat.FlatAppearance.BorderSize = 0
        Me.btnCat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCat.Name = "btnCat"
        Me.btnCat.TabStop = False
        Me.btnCat.UseVisualStyleBackColor = True
        '
        'btnLoadLoc
        '
        resources.ApplyResources(Me.btnLoadLoc, "btnLoadLoc")
        Me.btnLoadLoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLoadLoc.FlatAppearance.BorderSize = 0
        Me.btnLoadLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoadLoc.Name = "btnLoadLoc"
        Me.btnLoadLoc.TabStop = False
        Me.btnLoadLoc.UseVisualStyleBackColor = True
        '
        'txtLoadLoc
        '
        resources.ApplyResources(Me.txtLoadLoc, "txtLoadLoc")
        Me.txtLoadLoc.Name = "txtLoadLoc"
        '
        'txttrain
        '
        resources.ApplyResources(Me.txttrain, "txttrain")
        Me.txttrain.Name = "txttrain"
        '
        'txtCat
        '
        resources.ApplyResources(Me.txtCat, "txtCat")
        Me.txtCat.Name = "txtCat"
        '
        'txtDestination
        '
        resources.ApplyResources(Me.txtDestination, "txtDestination")
        Me.txtDestination.Name = "txtDestination"
        '
        'txtSEDO
        '
        resources.ApplyResources(Me.txtSEDO, "txtSEDO")
        Me.txtSEDO.Name = "txtSEDO"
        '
        'lblse
        '
        resources.ApplyResources(Me.lblse, "lblse")
        Me.lblse.Name = "lblse"
        '
        'lbldestination
        '
        resources.ApplyResources(Me.lbldestination, "lbldestination")
        Me.lbldestination.Name = "lbldestination"
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSave.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        resources.ApplyResources(Me.btnUpdate, "btnUpdate")
        Me.btnUpdate.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnUpdate.Image = Global.BSP.My.Resources.Resources.user_add
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Controls.Add(Me.txtmgppm)
        Me.GroupBox1.Controls.Add(Me.lblmgppm)
        Me.GroupBox1.Controls.Add(Me.txtKOH)
        Me.GroupBox1.Controls.Add(Me.lblkoh)
        Me.GroupBox1.Controls.Add(Me.txtMST)
        Me.GroupBox1.Controls.Add(Me.lblmst)
        Me.GroupBox1.Controls.Add(Me.txtVFA)
        Me.GroupBox1.Controls.Add(Me.lblvfa)
        Me.GroupBox1.Controls.Add(Me.txtNH3)
        Me.GroupBox1.Controls.Add(Me.lblnh3)
        Me.GroupBox1.Controls.Add(Me.txtNrc)
        Me.GroupBox1.Controls.Add(Me.lblnrc)
        Me.GroupBox1.Controls.Add(Me.txtTSC)
        Me.GroupBox1.Controls.Add(Me.lbltsc)
        Me.GroupBox1.Controls.Add(Me.txtDrcPer)
        Me.GroupBox1.Controls.Add(Me.lbldrcper)
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.lblquantity)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtmgppm
        '
        resources.ApplyResources(Me.txtmgppm, "txtmgppm")
        Me.txtmgppm.Name = "txtmgppm"
        '
        'lblmgppm
        '
        resources.ApplyResources(Me.lblmgppm, "lblmgppm")
        Me.lblmgppm.Name = "lblmgppm"
        '
        'txtKOH
        '
        resources.ApplyResources(Me.txtKOH, "txtKOH")
        Me.txtKOH.Name = "txtKOH"
        '
        'lblkoh
        '
        resources.ApplyResources(Me.lblkoh, "lblkoh")
        Me.lblkoh.Name = "lblkoh"
        '
        'txtMST
        '
        resources.ApplyResources(Me.txtMST, "txtMST")
        Me.txtMST.Name = "txtMST"
        '
        'lblmst
        '
        resources.ApplyResources(Me.lblmst, "lblmst")
        Me.lblmst.Name = "lblmst"
        '
        'txtVFA
        '
        resources.ApplyResources(Me.txtVFA, "txtVFA")
        Me.txtVFA.Name = "txtVFA"
        '
        'lblvfa
        '
        resources.ApplyResources(Me.lblvfa, "lblvfa")
        Me.lblvfa.Name = "lblvfa"
        '
        'txtNH3
        '
        resources.ApplyResources(Me.txtNH3, "txtNH3")
        Me.txtNH3.Name = "txtNH3"
        '
        'lblnh3
        '
        resources.ApplyResources(Me.lblnh3, "lblnh3")
        Me.lblnh3.Name = "lblnh3"
        '
        'txtNrc
        '
        resources.ApplyResources(Me.txtNrc, "txtNrc")
        Me.txtNrc.Name = "txtNrc"
        '
        'lblnrc
        '
        resources.ApplyResources(Me.lblnrc, "lblnrc")
        Me.lblnrc.Name = "lblnrc"
        '
        'txtTSC
        '
        resources.ApplyResources(Me.txtTSC, "txtTSC")
        Me.txtTSC.Name = "txtTSC"
        '
        'lbltsc
        '
        resources.ApplyResources(Me.lbltsc, "lbltsc")
        Me.lbltsc.Name = "lbltsc"
        '
        'txtDrcPer
        '
        resources.ApplyResources(Me.txtDrcPer, "txtDrcPer")
        Me.txtDrcPer.Name = "txtDrcPer"
        '
        'lbldrcper
        '
        resources.ApplyResources(Me.lbldrcper, "lbldrcper")
        Me.lbldrcper.Name = "lbldrcper"
        '
        'txtQuantity
        '
        resources.ApplyResources(Me.txtQuantity, "txtQuantity")
        Me.txtQuantity.Name = "txtQuantity"
        '
        'lblquantity
        '
        resources.ApplyResources(Me.lblquantity, "lblquantity")
        Me.lblquantity.Name = "lblquantity"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Value = New Date(2016, 8, 25, 0, 0, 0, 0)
        '
        'lbllodinglocation
        '
        resources.ApplyResources(Me.lbllodinglocation, "lbllodinglocation")
        Me.lbllodinglocation.Name = "lbllodinglocation"
        '
        'lblcategory
        '
        resources.ApplyResources(Me.lblcategory, "lblcategory")
        Me.lblcategory.Name = "lblcategory"
        '
        'lbltruck
        '
        resources.ApplyResources(Me.lbltruck, "lbltruck")
        Me.lbltruck.Name = "lbltruck"
        '
        'lbldate
        '
        resources.ApplyResources(Me.lbldate, "lbldate")
        Me.lbldate.Name = "lbldate"
        '
        'TabSearch
        '
        resources.ApplyResources(Me.TabSearch, "TabSearch")
        Me.TabSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.TabSearch.Controls.Add(Me.lblView)
        Me.TabSearch.Controls.Add(Me.dgvView)
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
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.dgtxtDocDate, Me.dgtxtprod, Me.dgvtxtstor})
        Me.dgvView.ContextMenuStrip = Me.cmsqcdcnx
        Me.dgvView.EnableHeadersVisualStyles = False
        Me.dgvView.GridColor = System.Drawing.Color.Gray
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
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
        resources.ApplyResources(Me.dgtxtDocDate, "dgtxtDocDate")
        Me.dgtxtDocDate.Name = "dgtxtDocDate"
        Me.dgtxtDocDate.ReadOnly = True
        '
        'dgtxtprod
        '
        Me.dgtxtprod.DataPropertyName = "QCNXTrain"
        resources.ApplyResources(Me.dgtxtprod, "dgtxtprod")
        Me.dgtxtprod.Name = "dgtxtprod"
        Me.dgtxtprod.ReadOnly = True
        '
        'dgvtxtstor
        '
        Me.dgvtxtstor.DataPropertyName = "QCNXCategory"
        resources.ApplyResources(Me.dgvtxtstor, "dgvtxtstor")
        Me.dgvtxtstor.Name = "dgvtxtstor"
        Me.dgvtxtstor.ReadOnly = True
        '
        'cmsqcdcnx
        '
        resources.ApplyResources(Me.cmsqcdcnx, "cmsqcdcnx")
        Me.cmsqcdcnx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsqcdcnx.Name = "cmsqcdcnx"
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
        Me.pnlSearchLPO.CaptionText = "Search QCD Analysis Finished Goods"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchCat)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchCat)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchTrain)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchTrain)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        '
        'txtSearchCat
        '
        resources.ApplyResources(Me.txtSearchCat, "txtSearchCat")
        Me.txtSearchCat.Name = "txtSearchCat"
        '
        'lblSearch
        '
        resources.ApplyResources(Me.lblSearch, "lblSearch")
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.Name = "lblSearch"
        '
        'lblSearchCat
        '
        resources.ApplyResources(Me.lblSearchCat, "lblSearchCat")
        Me.lblSearchCat.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchCat.ForeColor = System.Drawing.Color.Black
        Me.lblSearchCat.Name = "lblSearchCat"
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
        'txtSearchTrain
        '
        resources.ApplyResources(Me.txtSearchTrain, "txtSearchTrain")
        Me.txtSearchTrain.Name = "txtSearchTrain"
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
        'lblSearchTrain
        '
        resources.ApplyResources(Me.lblSearchTrain, "lblSearchTrain")
        Me.lblSearchTrain.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchTrain.ForeColor = System.Drawing.Color.Black
        Me.lblSearchTrain.Name = "lblSearchTrain"
        '
        'ProductionQcdCenexFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionQcdCenexFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.TabSave.ResumeLayout(False)
        Me.TabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSearch.ResumeLayout(False)
        Me.TabSearch.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsqcdcnx.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents TabSave As System.Windows.Forms.TabPage
    Friend WithEvents txtSEDO As System.Windows.Forms.TextBox
    Friend WithEvents lblse As System.Windows.Forms.Label
    Friend WithEvents lbldestination As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVFA As System.Windows.Forms.TextBox
    Friend WithEvents lblvfa As System.Windows.Forms.Label
    Friend WithEvents txtNH3 As System.Windows.Forms.TextBox
    Friend WithEvents lblnh3 As System.Windows.Forms.Label
    Friend WithEvents txtNrc As System.Windows.Forms.TextBox
    Friend WithEvents lblnrc As System.Windows.Forms.Label
    Friend WithEvents txtTSC As System.Windows.Forms.TextBox
    Friend WithEvents lbltsc As System.Windows.Forms.Label
    Friend WithEvents txtDrcPer As System.Windows.Forms.TextBox
    Friend WithEvents lbldrcper As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblquantity As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbllodinglocation As System.Windows.Forms.Label
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents lbltruck As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents TabSearch As System.Windows.Forms.TabPage
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents txtKOH As System.Windows.Forms.TextBox
    Friend WithEvents lblkoh As System.Windows.Forms.Label
    Friend WithEvents txtMST As System.Windows.Forms.TextBox
    Friend WithEvents lblmst As System.Windows.Forms.Label
    Friend WithEvents txtCat As System.Windows.Forms.TextBox
    Friend WithEvents txttrain As System.Windows.Forms.TextBox
    Friend WithEvents txtLoadLoc As System.Windows.Forms.TextBox
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents txtSearchCat As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblSearchCat As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchTrain As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchTrain As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents btnCat As System.Windows.Forms.Button
    Friend WithEvents btnLoadLoc As System.Windows.Forms.Button
    Friend WithEvents btnTrain As System.Windows.Forms.Button
    Friend WithEvents cmsqcdcnx As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtstor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtmgppm As System.Windows.Forms.TextBox
    Friend WithEvents lblmgppm As System.Windows.Forms.Label
End Class
