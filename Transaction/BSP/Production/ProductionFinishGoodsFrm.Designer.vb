<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionFinishGoodsFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionFinishGoodsFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.tabSave = New System.Windows.Forms.TabPage()
        Me.btnStation = New System.Windows.Forms.Button()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.btnprod = New System.Windows.Forms.Button()
        Me.txtproduct = New System.Windows.Forms.TextBox()
        Me.txtstorage = New System.Windows.Forms.TextBox()
        Me.btnSearchSource = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblremarks = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lbllocation = New System.Windows.Forms.Label()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDrc = New System.Windows.Forms.TextBox()
        Me.lbldrc = New System.Windows.Forms.Label()
        Me.txtQtyWet = New System.Windows.Forms.TextBox()
        Me.lblcenexw = New System.Windows.Forms.Label()
        Me.txtQtyDry = New System.Windows.Forms.TextBox()
        Me.lblcenexd = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblgrade = New System.Windows.Forms.Label()
        Me.lblstation = New System.Windows.Forms.Label()
        Me.lblstorage = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.tabSearchView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtstor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.txtSearchStor = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblSearchStor = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchProd = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchProd = New System.Windows.Forms.Label()
        Me.cmsProductionFinishGoods = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabContainerMain.SuspendLayout()
        Me.tabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSearchView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchLPO.SuspendLayout()
        Me.cmsProductionFinishGoods.SuspendLayout()
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
        Me.tabSave.Controls.Add(Me.btnStation)
        Me.tabSave.Controls.Add(Me.txtStation)
        Me.tabSave.Controls.Add(Me.btnprod)
        Me.tabSave.Controls.Add(Me.txtproduct)
        Me.tabSave.Controls.Add(Me.txtstorage)
        Me.tabSave.Controls.Add(Me.btnSearchSource)
        Me.tabSave.Controls.Add(Me.txtRemarks)
        Me.tabSave.Controls.Add(Me.lblremarks)
        Me.tabSave.Controls.Add(Me.txtLocation)
        Me.tabSave.Controls.Add(Me.lbllocation)
        Me.tabSave.Controls.Add(Me.btnSaveAll)
        Me.tabSave.Controls.Add(Me.Button3)
        Me.tabSave.Controls.Add(Me.btnResetAll)
        Me.tabSave.Controls.Add(Me.btnClose)
        Me.tabSave.Controls.Add(Me.GroupBox1)
        Me.tabSave.Controls.Add(Me.dtpDate)
        Me.tabSave.Controls.Add(Me.lblgrade)
        Me.tabSave.Controls.Add(Me.lblstation)
        Me.tabSave.Controls.Add(Me.lblstorage)
        Me.tabSave.Controls.Add(Me.lbldate)
        Me.tabSave.Name = "tabSave"
        Me.tabSave.UseVisualStyleBackColor = True
        '
        'btnStation
        '
        resources.ApplyResources(Me.btnStation, "btnStation")
        Me.btnStation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStation.FlatAppearance.BorderSize = 0
        Me.btnStation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnStation.Name = "btnStation"
        Me.btnStation.TabStop = False
        Me.btnStation.UseVisualStyleBackColor = True
        '
        'txtStation
        '
        resources.ApplyResources(Me.txtStation, "txtStation")
        Me.txtStation.Name = "txtStation"
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
        'txtRemarks
        '
        resources.ApplyResources(Me.txtRemarks, "txtRemarks")
        Me.txtRemarks.Name = "txtRemarks"
        '
        'lblremarks
        '
        resources.ApplyResources(Me.lblremarks, "lblremarks")
        Me.lblremarks.Name = "lblremarks"
        '
        'txtLocation
        '
        resources.ApplyResources(Me.txtLocation, "txtLocation")
        Me.txtLocation.Name = "txtLocation"
        '
        'lbllocation
        '
        resources.ApplyResources(Me.lbllocation, "lbllocation")
        Me.lbllocation.Name = "lbllocation"
        '
        'btnSaveAll
        '
        resources.ApplyResources(Me.btnSaveAll, "btnSaveAll")
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSaveAll.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.Button3.Image = Global.BSP.My.Resources.Resources.user_add
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        resources.ApplyResources(Me.btnResetAll, "btnResetAll")
        Me.btnResetAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnResetAll.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Controls.Add(Me.lbldrc)
        Me.GroupBox1.Controls.Add(Me.txtQtyWet)
        Me.GroupBox1.Controls.Add(Me.lblcenexw)
        Me.GroupBox1.Controls.Add(Me.txtQtyDry)
        Me.GroupBox1.Controls.Add(Me.lblcenexd)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtDrc
        '
        resources.ApplyResources(Me.txtDrc, "txtDrc")
        Me.txtDrc.Name = "txtDrc"
        '
        'lbldrc
        '
        resources.ApplyResources(Me.lbldrc, "lbldrc")
        Me.lbldrc.Name = "lbldrc"
        '
        'txtQtyWet
        '
        resources.ApplyResources(Me.txtQtyWet, "txtQtyWet")
        Me.txtQtyWet.Name = "txtQtyWet"
        '
        'lblcenexw
        '
        resources.ApplyResources(Me.lblcenexw, "lblcenexw")
        Me.lblcenexw.Name = "lblcenexw"
        '
        'txtQtyDry
        '
        resources.ApplyResources(Me.txtQtyDry, "txtQtyDry")
        Me.txtQtyDry.Name = "txtQtyDry"
        '
        'lblcenexd
        '
        resources.ApplyResources(Me.lblcenexd, "lblcenexd")
        Me.lblcenexd.Name = "lblcenexd"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        '
        'lblgrade
        '
        resources.ApplyResources(Me.lblgrade, "lblgrade")
        Me.lblgrade.Name = "lblgrade"
        '
        'lblstation
        '
        resources.ApplyResources(Me.lblstation, "lblstation")
        Me.lblstation.Name = "lblstation"
        '
        'lblstorage
        '
        resources.ApplyResources(Me.lblstorage, "lblstorage")
        Me.lblstorage.Name = "lblstorage"
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
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgtxtDocID, Me.dgtxtDocDate, Me.dgtxtprod, Me.dgvtxtstor})
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
        Me.dgtxtprod.DataPropertyName = "Product"
        resources.ApplyResources(Me.dgtxtprod, "dgtxtprod")
        Me.dgtxtprod.Name = "dgtxtprod"
        Me.dgtxtprod.ReadOnly = True
        '
        'dgvtxtstor
        '
        Me.dgvtxtstor.DataPropertyName = "Storage"
        resources.ApplyResources(Me.dgvtxtstor, "dgvtxtstor")
        Me.dgvtxtstor.Name = "dgvtxtstor"
        Me.dgvtxtstor.ReadOnly = True
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
        Me.pnlSearchLPO.CaptionText = "Search ProductionLog Finish Goods Details"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchStor)
        Me.pnlSearchLPO.Controls.Add(Me.Panel1)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchStor)
        Me.pnlSearchLPO.Controls.Add(Me.Label67)
        Me.pnlSearchLPO.Controls.Add(Me.chkDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.dtpSearchDocDate)
        Me.pnlSearchLPO.Controls.Add(Me.btnLPOViewReport)
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchProd)
        Me.pnlSearchLPO.Controls.Add(Me.btnViewSearch)
        Me.pnlSearchLPO.Controls.Add(Me.lblSearchProd)
        Me.pnlSearchLPO.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlSearchLPO.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlSearchLPO.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlSearchLPO.Moveable = True
        Me.pnlSearchLPO.Name = "pnlSearchLPO"
        '
        'txtSearchStor
        '
        resources.ApplyResources(Me.txtSearchStor, "txtSearchStor")
        Me.txtSearchStor.Name = "txtSearchStor"
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'lblSearch
        '
        resources.ApplyResources(Me.lblSearch, "lblSearch")
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.Name = "lblSearch"
        '
        'lblSearchStor
        '
        resources.ApplyResources(Me.lblSearchStor, "lblSearchStor")
        Me.lblSearchStor.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchStor.ForeColor = System.Drawing.Color.Black
        Me.lblSearchStor.Name = "lblSearchStor"
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
        'txtSearchProd
        '
        resources.ApplyResources(Me.txtSearchProd, "txtSearchProd")
        Me.txtSearchProd.Name = "txtSearchProd"
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
        'lblSearchProd
        '
        resources.ApplyResources(Me.lblSearchProd, "lblSearchProd")
        Me.lblSearchProd.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchProd.ForeColor = System.Drawing.Color.Black
        Me.lblSearchProd.Name = "lblSearchProd"
        '
        'cmsProductionFinishGoods
        '
        resources.ApplyResources(Me.cmsProductionFinishGoods, "cmsProductionFinishGoods")
        Me.cmsProductionFinishGoods.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsProductionFinishGoods.Name = "cmsIPR"
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
        'ProductionFinishGoodsFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.cmsProductionFinishGoods
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionFinishGoodsFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.tabSave.ResumeLayout(False)
        Me.tabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSearchView.ResumeLayout(False)
        Me.tabSearchView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.cmsProductionFinishGoods.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents tabSave As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDrc As System.Windows.Forms.TextBox
    Friend WithEvents lbldrc As System.Windows.Forms.Label
    Friend WithEvents txtQtyWet As System.Windows.Forms.TextBox
    Friend WithEvents lblcenexw As System.Windows.Forms.Label
    Friend WithEvents txtQtyDry As System.Windows.Forms.TextBox
    Friend WithEvents lblcenexd As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblgrade As System.Windows.Forms.Label
    Friend WithEvents lblstation As System.Windows.Forms.Label
    Friend WithEvents lblstorage As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents tabSearchView As System.Windows.Forms.TabPage
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblremarks As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents lbllocation As System.Windows.Forms.Label
    Friend WithEvents txtstorage As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchSource As System.Windows.Forms.Button
    Friend WithEvents btnprod As System.Windows.Forms.Button
    Friend WithEvents txtproduct As System.Windows.Forms.TextBox
    Friend WithEvents btnStation As System.Windows.Forms.Button
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents cmsProductionFinishGoods As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents txtSearchStor As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblSearchStor As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchProd As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchProd As System.Windows.Forms.Label
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtstor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
