<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionCrumbRubberFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionCrumbRubberFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.tabSave = New System.Windows.Forms.TabPage()
        Me.txtstorage = New System.Windows.Forms.TextBox()
        Me.btnSearchSource = New System.Windows.Forms.Button()
        Me.btnprod = New System.Windows.Forms.Button()
        Me.txtproduct = New System.Windows.Forms.TextBox()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRStorage = New System.Windows.Forms.TextBox()
        Me.btnRStorage = New System.Windows.Forms.Button()
        Me.btnRProduct = New System.Windows.Forms.Button()
        Me.txtRProduct = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtStkAkhir = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAdjust = New System.Windows.Forms.TextBox()
        Me.txtLatexProcess = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIntakeDry = New System.Windows.Forms.TextBox()
        Me.txtStAwal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRecDry = New System.Windows.Forms.TextBox()
        Me.txtRecWet = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.txtShiftHours = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBreakDownTime = New System.Windows.Forms.TextBox()
        Me.txtEndTime = New System.Windows.Forms.TextBox()
        Me.txtStartTime = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAssistant = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabSearchView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkDocDate = New System.Windows.Forms.CheckBox()
        Me.dtpSearchDocDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLPOViewReport = New System.Windows.Forms.Button()
        Me.txtSearchAssistant = New System.Windows.Forms.TextBox()
        Me.btnViewSearch = New System.Windows.Forms.Button()
        Me.lblSearchTcktNum = New System.Windows.Forms.Label()
        Me.cmsProductionCrumbRubber = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtAssistant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabContainerMain.SuspendLayout()
        Me.tabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSearchView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchLPO.SuspendLayout()
        Me.cmsProductionCrumbRubber.SuspendLayout()
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
        Me.tabSave.Controls.Add(Me.btnprod)
        Me.tabSave.Controls.Add(Me.txtproduct)
        Me.tabSave.Controls.Add(Me.btnSaveAll)
        Me.tabSave.Controls.Add(Me.btnupdate)
        Me.tabSave.Controls.Add(Me.GroupBox1)
        Me.tabSave.Controls.Add(Me.btnResetAll)
        Me.tabSave.Controls.Add(Me.txtShiftHours)
        Me.tabSave.Controls.Add(Me.btnClose)
        Me.tabSave.Controls.Add(Me.Label8)
        Me.tabSave.Controls.Add(Me.txtBreakDownTime)
        Me.tabSave.Controls.Add(Me.txtEndTime)
        Me.tabSave.Controls.Add(Me.txtStartTime)
        Me.tabSave.Controls.Add(Me.Label7)
        Me.tabSave.Controls.Add(Me.Label6)
        Me.tabSave.Controls.Add(Me.Label5)
        Me.tabSave.Controls.Add(Me.txtAssistant)
        Me.tabSave.Controls.Add(Me.dtpDate)
        Me.tabSave.Controls.Add(Me.Label4)
        Me.tabSave.Controls.Add(Me.Label3)
        Me.tabSave.Controls.Add(Me.Label2)
        Me.tabSave.Controls.Add(Me.Label1)
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
        'btnSaveAll
        '
        resources.ApplyResources(Me.btnSaveAll, "btnSaveAll")
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnSaveAll.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnupdate
        '
        resources.ApplyResources(Me.btnupdate, "btnupdate")
        Me.btnupdate.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnupdate.Image = Global.BSP.My.Resources.Resources.user_add
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.txtRStorage)
        Me.GroupBox1.Controls.Add(Me.btnRStorage)
        Me.GroupBox1.Controls.Add(Me.btnRProduct)
        Me.GroupBox1.Controls.Add(Me.txtRProduct)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtStkAkhir)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtAdjust)
        Me.GroupBox1.Controls.Add(Me.txtLatexProcess)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtIntakeDry)
        Me.GroupBox1.Controls.Add(Me.txtStAwal)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtRecDry)
        Me.GroupBox1.Controls.Add(Me.txtRecWet)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtRStorage
        '
        resources.ApplyResources(Me.txtRStorage, "txtRStorage")
        Me.txtRStorage.Name = "txtRStorage"
        '
        'btnRStorage
        '
        resources.ApplyResources(Me.btnRStorage, "btnRStorage")
        Me.btnRStorage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRStorage.FlatAppearance.BorderSize = 0
        Me.btnRStorage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnRStorage.Name = "btnRStorage"
        Me.btnRStorage.TabStop = False
        Me.btnRStorage.UseVisualStyleBackColor = True
        '
        'btnRProduct
        '
        resources.ApplyResources(Me.btnRProduct, "btnRProduct")
        Me.btnRProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRProduct.FlatAppearance.BorderSize = 0
        Me.btnRProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnRProduct.Name = "btnRProduct"
        Me.btnRProduct.TabStop = False
        Me.btnRProduct.UseVisualStyleBackColor = True
        '
        'txtRProduct
        '
        resources.ApplyResources(Me.txtRProduct, "txtRProduct")
        Me.txtRProduct.Name = "txtRProduct"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'txtStkAkhir
        '
        resources.ApplyResources(Me.txtStkAkhir, "txtStkAkhir")
        Me.txtStkAkhir.Name = "txtStkAkhir"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'txtAdjust
        '
        resources.ApplyResources(Me.txtAdjust, "txtAdjust")
        Me.txtAdjust.Name = "txtAdjust"
        '
        'txtLatexProcess
        '
        resources.ApplyResources(Me.txtLatexProcess, "txtLatexProcess")
        Me.txtLatexProcess.Name = "txtLatexProcess"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'txtIntakeDry
        '
        resources.ApplyResources(Me.txtIntakeDry, "txtIntakeDry")
        Me.txtIntakeDry.Name = "txtIntakeDry"
        '
        'txtStAwal
        '
        resources.ApplyResources(Me.txtStAwal, "txtStAwal")
        Me.txtStAwal.Name = "txtStAwal"
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
        'txtRecDry
        '
        resources.ApplyResources(Me.txtRecDry, "txtRecDry")
        Me.txtRecDry.Name = "txtRecDry"
        '
        'txtRecWet
        '
        resources.ApplyResources(Me.txtRecWet, "txtRecWet")
        Me.txtRecWet.Name = "txtRecWet"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'btnResetAll
        '
        resources.ApplyResources(Me.btnResetAll, "btnResetAll")
        Me.btnResetAll.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnResetAll.Image = Global.BSP.My.Resources.Resources.refresh
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'txtShiftHours
        '
        resources.ApplyResources(Me.txtShiftHours, "txtShiftHours")
        Me.txtShiftHours.Name = "txtShiftHours"
        Me.txtShiftHours.ReadOnly = True
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.btnbaground
        Me.btnClose.Image = Global.BSP.My.Resources.Resources.Close_32
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
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
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
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
        'txtAssistant
        '
        resources.ApplyResources(Me.txtAssistant, "txtAssistant")
        Me.txtAssistant.Name = "txtAssistant"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
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
        Me.dgvView.EnableHeadersVisualStyles = False
        Me.dgvView.GridColor = System.Drawing.Color.Gray
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
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
        Me.pnlSearchLPO.CaptionText = "Search Production Crumb Rubber SIR Data"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
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
        'cmsProductionCrumbRubber
        '
        resources.ApplyResources(Me.cmsProductionCrumbRubber, "cmsProductionCrumbRubber")
        Me.cmsProductionCrumbRubber.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsProductionCrumbRubber.Name = "cmsIPR"
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
        'ProductionCrumbRubberFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.ContextMenuStrip = Me.cmsProductionCrumbRubber
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionCrumbRubberFrm"
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
        Me.cmsProductionCrumbRubber.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents tabSave As System.Windows.Forms.TabPage
    Friend WithEvents tabSearchView As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAssistant As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBreakDownTime As System.Windows.Forms.TextBox
    Friend WithEvents txtEndTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStartTime As System.Windows.Forms.TextBox
    Friend WithEvents txtShiftHours As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRecDry As System.Windows.Forms.TextBox
    Friend WithEvents txtRecWet As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIntakeDry As System.Windows.Forms.TextBox
    Friend WithEvents txtStAwal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLatexProcess As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAdjust As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtStkAkhir As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnprod As System.Windows.Forms.Button
    Friend WithEvents txtproduct As System.Windows.Forms.TextBox
    Friend WithEvents txtstorage As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchSource As System.Windows.Forms.Button
    Friend WithEvents txtRStorage As System.Windows.Forms.TextBox
    Friend WithEvents btnRStorage As System.Windows.Forms.Button
    Friend WithEvents btnRProduct As System.Windows.Forms.Button
    Friend WithEvents txtRProduct As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
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
    Friend WithEvents cmsProductionCrumbRubber As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateTwo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtAssistant As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
