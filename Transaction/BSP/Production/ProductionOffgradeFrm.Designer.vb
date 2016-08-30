<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionOffgradeFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionOffgradeFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.TabSave = New System.Windows.Forms.TabPage()
        Me.btnprod = New System.Windows.Forms.Button()
        Me.txtprod = New System.Windows.Forms.TextBox()
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.btnStorage = New System.Windows.Forms.Button()
        Me.txtstorage = New System.Windows.Forms.TextBox()
        Me.lblstorage = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.txtContract = New System.Windows.Forms.TextBox()
        Me.txtIdTruck = New System.Windows.Forms.TextBox()
        Me.lblidtruck = New System.Windows.Forms.Label()
        Me.txtDeliveryOrderNo = New System.Windows.Forms.TextBox()
        Me.lblorderno = New System.Windows.Forms.Label()
        Me.lblcustomer = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDrc = New System.Windows.Forms.TextBox()
        Me.lbldrc = New System.Windows.Forms.Label()
        Me.txtDry = New System.Windows.Forms.TextBox()
        Me.lbldry = New System.Windows.Forms.Label()
        Me.txtWet = New System.Windows.Forms.TextBox()
        Me.lblwet = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblcontact = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.TabSearch = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtstor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMSSales = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSearchLPO = New Stepi.UI.ExtendedPanel()
        Me.txtSearchType = New System.Windows.Forms.TextBox()
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
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSSales.SuspendLayout()
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
        Me.TabSave.Controls.Add(Me.btnprod)
        Me.TabSave.Controls.Add(Me.txtprod)
        Me.TabSave.Controls.Add(Me.lblProduct)
        Me.TabSave.Controls.Add(Me.btnStorage)
        Me.TabSave.Controls.Add(Me.txtstorage)
        Me.TabSave.Controls.Add(Me.lblstorage)
        Me.TabSave.Controls.Add(Me.txtCustomer)
        Me.TabSave.Controls.Add(Me.txtContract)
        Me.TabSave.Controls.Add(Me.txtIdTruck)
        Me.TabSave.Controls.Add(Me.lblidtruck)
        Me.TabSave.Controls.Add(Me.txtDeliveryOrderNo)
        Me.TabSave.Controls.Add(Me.lblorderno)
        Me.TabSave.Controls.Add(Me.lblcustomer)
        Me.TabSave.Controls.Add(Me.btnSave)
        Me.TabSave.Controls.Add(Me.btnUpdate)
        Me.TabSave.Controls.Add(Me.btnReset)
        Me.TabSave.Controls.Add(Me.btnClose)
        Me.TabSave.Controls.Add(Me.GroupBox1)
        Me.TabSave.Controls.Add(Me.dtpDate)
        Me.TabSave.Controls.Add(Me.lblcontact)
        Me.TabSave.Controls.Add(Me.lbldate)
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
        'txtprod
        '
        resources.ApplyResources(Me.txtprod, "txtprod")
        Me.txtprod.Name = "txtprod"
        '
        'lblProduct
        '
        resources.ApplyResources(Me.lblProduct, "lblProduct")
        Me.lblProduct.Name = "lblProduct"
        '
        'btnStorage
        '
        resources.ApplyResources(Me.btnStorage, "btnStorage")
        Me.btnStorage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStorage.FlatAppearance.BorderSize = 0
        Me.btnStorage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnStorage.Name = "btnStorage"
        Me.btnStorage.TabStop = False
        Me.btnStorage.UseVisualStyleBackColor = True
        '
        'txtstorage
        '
        resources.ApplyResources(Me.txtstorage, "txtstorage")
        Me.txtstorage.Name = "txtstorage"
        '
        'lblstorage
        '
        resources.ApplyResources(Me.lblstorage, "lblstorage")
        Me.lblstorage.Name = "lblstorage"
        '
        'txtCustomer
        '
        resources.ApplyResources(Me.txtCustomer, "txtCustomer")
        Me.txtCustomer.Name = "txtCustomer"
        '
        'txtContract
        '
        resources.ApplyResources(Me.txtContract, "txtContract")
        Me.txtContract.Name = "txtContract"
        '
        'txtIdTruck
        '
        resources.ApplyResources(Me.txtIdTruck, "txtIdTruck")
        Me.txtIdTruck.Name = "txtIdTruck"
        '
        'lblidtruck
        '
        resources.ApplyResources(Me.lblidtruck, "lblidtruck")
        Me.lblidtruck.Name = "lblidtruck"
        '
        'txtDeliveryOrderNo
        '
        resources.ApplyResources(Me.txtDeliveryOrderNo, "txtDeliveryOrderNo")
        Me.txtDeliveryOrderNo.Name = "txtDeliveryOrderNo"
        '
        'lblorderno
        '
        resources.ApplyResources(Me.lblorderno, "lblorderno")
        Me.lblorderno.Name = "lblorderno"
        '
        'lblcustomer
        '
        resources.ApplyResources(Me.lblcustomer, "lblcustomer")
        Me.lblcustomer.Name = "lblcustomer"
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
        Me.GroupBox1.Controls.Add(Me.txtDrc)
        Me.GroupBox1.Controls.Add(Me.lbldrc)
        Me.GroupBox1.Controls.Add(Me.txtDry)
        Me.GroupBox1.Controls.Add(Me.lbldry)
        Me.GroupBox1.Controls.Add(Me.txtWet)
        Me.GroupBox1.Controls.Add(Me.lblwet)
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
        'txtDry
        '
        resources.ApplyResources(Me.txtDry, "txtDry")
        Me.txtDry.Name = "txtDry"
        '
        'lbldry
        '
        resources.ApplyResources(Me.lbldry, "lbldry")
        Me.lbldry.Name = "lbldry"
        '
        'txtWet
        '
        resources.ApplyResources(Me.txtWet, "txtWet")
        Me.txtWet.Name = "txtWet"
        '
        'lblwet
        '
        resources.ApplyResources(Me.lblwet, "lblwet")
        Me.lblwet.Name = "lblwet"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        '
        'lblcontact
        '
        resources.ApplyResources(Me.lblcontact, "lblcontact")
        Me.lblcontact.Name = "lblcontact"
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
        Me.dgvView.ContextMenuStrip = Me.CMSSales
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
        Me.dgtxtprod.DataPropertyName = "OGStorage"
        resources.ApplyResources(Me.dgtxtprod, "dgtxtprod")
        Me.dgtxtprod.Name = "dgtxtprod"
        Me.dgtxtprod.ReadOnly = True
        '
        'dgvtxtstor
        '
        Me.dgvtxtstor.DataPropertyName = "OGProduct"
        resources.ApplyResources(Me.dgvtxtstor, "dgvtxtstor")
        Me.dgvtxtstor.Name = "dgvtxtstor"
        Me.dgvtxtstor.ReadOnly = True
        '
        'CMSSales
        '
        resources.ApplyResources(Me.CMSSales, "CMSSales")
        Me.CMSSales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMSSales.Name = "CMSSales"
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
        Me.pnlSearchLPO.CaptionText = "Search Offgrade Sales"
        Me.pnlSearchLPO.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlSearchLPO.Controls.Add(Me.txtSearchType)
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
        'ProductionOffgradeFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionOffgradeFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.TabSave.ResumeLayout(False)
        Me.TabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSearch.ResumeLayout(False)
        Me.TabSearch.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSSales.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents TabSave As System.Windows.Forms.TabPage
    Friend WithEvents txtIdTruck As System.Windows.Forms.TextBox
    Friend WithEvents lblidtruck As System.Windows.Forms.Label
    Friend WithEvents txtDeliveryOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents lblorderno As System.Windows.Forms.Label
    Friend WithEvents lblcustomer As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDrc As System.Windows.Forms.TextBox
    Friend WithEvents lbldrc As System.Windows.Forms.Label
    Friend WithEvents txtDry As System.Windows.Forms.TextBox
    Friend WithEvents lbldry As System.Windows.Forms.Label
    Friend WithEvents txtWet As System.Windows.Forms.TextBox
    Friend WithEvents lblwet As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblcontact As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents TabSearch As System.Windows.Forms.TabPage
    Friend WithEvents txtContract As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents lblstorage As System.Windows.Forms.Label
    Friend WithEvents CMSSales As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents txtstorage As System.Windows.Forms.TextBox
    Friend WithEvents pnlSearchLPO As Stepi.UI.ExtendedPanel
    Friend WithEvents txtSearchType As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblSearchType As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkDocDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpSearchDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLPOViewReport As System.Windows.Forms.Button
    Friend WithEvents txtSearchSource As System.Windows.Forms.TextBox
    Friend WithEvents btnViewSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearchSource As System.Windows.Forms.Label
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStorage As System.Windows.Forms.Button
    Friend WithEvents btnprod As System.Windows.Forms.Button
    Friend WithEvents txtprod As System.Windows.Forms.TextBox
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtstor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
