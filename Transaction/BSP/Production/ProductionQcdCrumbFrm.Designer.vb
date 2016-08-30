<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionQcdCrumbFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionQcdCrumbFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.TabSave = New System.Windows.Forms.TabPage()
        Me.btnStor = New System.Windows.Forms.Button()
        Me.btnLoadLoc = New System.Windows.Forms.Button()
        Me.btnProd = New System.Windows.Forms.Button()
        Me.btnCat = New System.Windows.Forms.Button()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.txtLoadLoc = New System.Windows.Forms.TextBox()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.txtDoNumber = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNoLot = New System.Windows.Forms.TextBox()
        Me.lblnolot = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblproduct = New System.Windows.Forms.Label()
        Me.txtVehicleNumber = New System.Windows.Forms.TextBox()
        Me.txtNoPallet = New System.Windows.Forms.TextBox()
        Me.lblnopallet = New System.Windows.Forms.Label()
        Me.lblvehicleno = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.txtAshContent = New System.Windows.Forms.TextBox()
        Me.txtDirtContent = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbldirtcontent = New System.Windows.Forms.Label()
        Me.txtLc = New System.Windows.Forms.TextBox()
        Me.lbllc = New System.Windows.Forms.Label()
        Me.txtNitrogenContent = New System.Windows.Forms.TextBox()
        Me.lblncp = New System.Windows.Forms.Label()
        Me.txtVolatileMater = New System.Windows.Forms.TextBox()
        Me.lblvmp = New System.Windows.Forms.Label()
        Me.txtMooneyViscosity = New System.Windows.Forms.TextBox()
        Me.lblmooney = New System.Windows.Forms.Label()
        Me.txtPri = New System.Windows.Forms.TextBox()
        Me.lblpri = New System.Windows.Forms.Label()
        Me.txtP30 = New System.Windows.Forms.TextBox()
        Me.lblp30 = New System.Windows.Forms.Label()
        Me.txtMillWeight = New System.Windows.Forms.TextBox()
        Me.lblmillweight = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lbldono = New System.Windows.Forms.Label()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.lblgrade = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.TabSearch = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtstor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBCrm = New System.Windows.Forms.ContextMenuStrip(Me.components)
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
        Me.lblgrad = New System.Windows.Forms.Label()
        Me.txtgrade = New System.Windows.Forms.TextBox()
        Me.btngrad = New System.Windows.Forms.Button()
        Me.TabContainerMain.SuspendLayout()
        Me.TabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabSearch.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMBCrm.SuspendLayout()
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
        Me.TabSave.Controls.Add(Me.btngrad)
        Me.TabSave.Controls.Add(Me.txtgrade)
        Me.TabSave.Controls.Add(Me.lblgrad)
        Me.TabSave.Controls.Add(Me.btnStor)
        Me.TabSave.Controls.Add(Me.btnLoadLoc)
        Me.TabSave.Controls.Add(Me.btnProd)
        Me.TabSave.Controls.Add(Me.btnCat)
        Me.TabSave.Controls.Add(Me.txtProduct)
        Me.TabSave.Controls.Add(Me.txtLoadLoc)
        Me.TabSave.Controls.Add(Me.txtStorage)
        Me.TabSave.Controls.Add(Me.txtDoNumber)
        Me.TabSave.Controls.Add(Me.txtCategory)
        Me.TabSave.Controls.Add(Me.txtDest)
        Me.TabSave.Controls.Add(Me.Label5)
        Me.TabSave.Controls.Add(Me.txtNoLot)
        Me.TabSave.Controls.Add(Me.lblnolot)
        Me.TabSave.Controls.Add(Me.Label2)
        Me.TabSave.Controls.Add(Me.lblproduct)
        Me.TabSave.Controls.Add(Me.txtVehicleNumber)
        Me.TabSave.Controls.Add(Me.txtNoPallet)
        Me.TabSave.Controls.Add(Me.lblnopallet)
        Me.TabSave.Controls.Add(Me.lblvehicleno)
        Me.TabSave.Controls.Add(Me.btnSave)
        Me.TabSave.Controls.Add(Me.btnUpdate)
        Me.TabSave.Controls.Add(Me.btnReset)
        Me.TabSave.Controls.Add(Me.btnClose)
        Me.TabSave.Controls.Add(Me.GroupBox1)
        Me.TabSave.Controls.Add(Me.dtpDate)
        Me.TabSave.Controls.Add(Me.lbldono)
        Me.TabSave.Controls.Add(Me.lblcategory)
        Me.TabSave.Controls.Add(Me.lblgrade)
        Me.TabSave.Controls.Add(Me.lbldate)
        Me.TabSave.Name = "TabSave"
        Me.TabSave.UseVisualStyleBackColor = True
        '
        'btnStor
        '
        resources.ApplyResources(Me.btnStor, "btnStor")
        Me.btnStor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStor.FlatAppearance.BorderSize = 0
        Me.btnStor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnStor.Name = "btnStor"
        Me.btnStor.TabStop = False
        Me.btnStor.UseVisualStyleBackColor = True
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
        'btnProd
        '
        resources.ApplyResources(Me.btnProd, "btnProd")
        Me.btnProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnProd.FlatAppearance.BorderSize = 0
        Me.btnProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnProd.Name = "btnProd"
        Me.btnProd.TabStop = False
        Me.btnProd.UseVisualStyleBackColor = True
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
        'txtProduct
        '
        resources.ApplyResources(Me.txtProduct, "txtProduct")
        Me.txtProduct.Name = "txtProduct"
        '
        'txtLoadLoc
        '
        resources.ApplyResources(Me.txtLoadLoc, "txtLoadLoc")
        Me.txtLoadLoc.Name = "txtLoadLoc"
        '
        'txtStorage
        '
        resources.ApplyResources(Me.txtStorage, "txtStorage")
        Me.txtStorage.Name = "txtStorage"
        '
        'txtDoNumber
        '
        resources.ApplyResources(Me.txtDoNumber, "txtDoNumber")
        Me.txtDoNumber.Name = "txtDoNumber"
        '
        'txtCategory
        '
        resources.ApplyResources(Me.txtCategory, "txtCategory")
        Me.txtCategory.Name = "txtCategory"
        '
        'txtDest
        '
        resources.ApplyResources(Me.txtDest, "txtDest")
        Me.txtDest.Name = "txtDest"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtNoLot
        '
        resources.ApplyResources(Me.txtNoLot, "txtNoLot")
        Me.txtNoLot.Name = "txtNoLot"
        '
        'lblnolot
        '
        resources.ApplyResources(Me.lblnolot, "lblnolot")
        Me.lblnolot.Name = "lblnolot"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'lblproduct
        '
        resources.ApplyResources(Me.lblproduct, "lblproduct")
        Me.lblproduct.Name = "lblproduct"
        '
        'txtVehicleNumber
        '
        resources.ApplyResources(Me.txtVehicleNumber, "txtVehicleNumber")
        Me.txtVehicleNumber.Name = "txtVehicleNumber"
        '
        'txtNoPallet
        '
        resources.ApplyResources(Me.txtNoPallet, "txtNoPallet")
        Me.txtNoPallet.Name = "txtNoPallet"
        '
        'lblnopallet
        '
        resources.ApplyResources(Me.lblnopallet, "lblnopallet")
        Me.lblnopallet.Name = "lblnopallet"
        '
        'lblvehicleno
        '
        resources.ApplyResources(Me.lblvehicleno, "lblvehicleno")
        Me.lblvehicleno.Name = "lblvehicleno"
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
        Me.GroupBox1.Controls.Add(Me.txtPO)
        Me.GroupBox1.Controls.Add(Me.lblPO)
        Me.GroupBox1.Controls.Add(Me.txtAshContent)
        Me.GroupBox1.Controls.Add(Me.txtDirtContent)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lbldirtcontent)
        Me.GroupBox1.Controls.Add(Me.txtLc)
        Me.GroupBox1.Controls.Add(Me.lbllc)
        Me.GroupBox1.Controls.Add(Me.txtNitrogenContent)
        Me.GroupBox1.Controls.Add(Me.lblncp)
        Me.GroupBox1.Controls.Add(Me.txtVolatileMater)
        Me.GroupBox1.Controls.Add(Me.lblvmp)
        Me.GroupBox1.Controls.Add(Me.txtMooneyViscosity)
        Me.GroupBox1.Controls.Add(Me.lblmooney)
        Me.GroupBox1.Controls.Add(Me.txtPri)
        Me.GroupBox1.Controls.Add(Me.lblpri)
        Me.GroupBox1.Controls.Add(Me.txtP30)
        Me.GroupBox1.Controls.Add(Me.lblp30)
        Me.GroupBox1.Controls.Add(Me.txtMillWeight)
        Me.GroupBox1.Controls.Add(Me.lblmillweight)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'txtPO
        '
        resources.ApplyResources(Me.txtPO, "txtPO")
        Me.txtPO.Name = "txtPO"
        '
        'lblPO
        '
        resources.ApplyResources(Me.lblPO, "lblPO")
        Me.lblPO.Name = "lblPO"
        '
        'txtAshContent
        '
        resources.ApplyResources(Me.txtAshContent, "txtAshContent")
        Me.txtAshContent.Name = "txtAshContent"
        '
        'txtDirtContent
        '
        resources.ApplyResources(Me.txtDirtContent, "txtDirtContent")
        Me.txtDirtContent.Name = "txtDirtContent"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'lbldirtcontent
        '
        resources.ApplyResources(Me.lbldirtcontent, "lbldirtcontent")
        Me.lbldirtcontent.Name = "lbldirtcontent"
        '
        'txtLc
        '
        resources.ApplyResources(Me.txtLc, "txtLc")
        Me.txtLc.Name = "txtLc"
        '
        'lbllc
        '
        resources.ApplyResources(Me.lbllc, "lbllc")
        Me.lbllc.Name = "lbllc"
        '
        'txtNitrogenContent
        '
        resources.ApplyResources(Me.txtNitrogenContent, "txtNitrogenContent")
        Me.txtNitrogenContent.Name = "txtNitrogenContent"
        '
        'lblncp
        '
        resources.ApplyResources(Me.lblncp, "lblncp")
        Me.lblncp.Name = "lblncp"
        '
        'txtVolatileMater
        '
        resources.ApplyResources(Me.txtVolatileMater, "txtVolatileMater")
        Me.txtVolatileMater.Name = "txtVolatileMater"
        '
        'lblvmp
        '
        resources.ApplyResources(Me.lblvmp, "lblvmp")
        Me.lblvmp.Name = "lblvmp"
        '
        'txtMooneyViscosity
        '
        resources.ApplyResources(Me.txtMooneyViscosity, "txtMooneyViscosity")
        Me.txtMooneyViscosity.Name = "txtMooneyViscosity"
        '
        'lblmooney
        '
        resources.ApplyResources(Me.lblmooney, "lblmooney")
        Me.lblmooney.Name = "lblmooney"
        '
        'txtPri
        '
        resources.ApplyResources(Me.txtPri, "txtPri")
        Me.txtPri.Name = "txtPri"
        '
        'lblpri
        '
        resources.ApplyResources(Me.lblpri, "lblpri")
        Me.lblpri.Name = "lblpri"
        '
        'txtP30
        '
        resources.ApplyResources(Me.txtP30, "txtP30")
        Me.txtP30.Name = "txtP30"
        '
        'lblp30
        '
        resources.ApplyResources(Me.lblp30, "lblp30")
        Me.lblp30.Name = "lblp30"
        '
        'txtMillWeight
        '
        resources.ApplyResources(Me.txtMillWeight, "txtMillWeight")
        Me.txtMillWeight.Name = "txtMillWeight"
        '
        'lblmillweight
        '
        resources.ApplyResources(Me.lblmillweight, "lblmillweight")
        Me.lblmillweight.Name = "lblmillweight"
        '
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        '
        'lbldono
        '
        resources.ApplyResources(Me.lbldono, "lbldono")
        Me.lbldono.Name = "lbldono"
        '
        'lblcategory
        '
        resources.ApplyResources(Me.lblcategory, "lblcategory")
        Me.lblcategory.Name = "lblcategory"
        '
        'lblgrade
        '
        resources.ApplyResources(Me.lblgrade, "lblgrade")
        Me.lblgrade.Name = "lblgrade"
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
        Me.dgvView.ContextMenuStrip = Me.CMBCrm
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
        Me.dgtxtprod.DataPropertyName = "QCRMProduct"
        resources.ApplyResources(Me.dgtxtprod, "dgtxtprod")
        Me.dgtxtprod.Name = "dgtxtprod"
        Me.dgtxtprod.ReadOnly = True
        '
        'dgvtxtstor
        '
        Me.dgvtxtstor.DataPropertyName = "QCRMStorage"
        resources.ApplyResources(Me.dgvtxtstor, "dgvtxtstor")
        Me.dgvtxtstor.Name = "dgvtxtstor"
        Me.dgvtxtstor.ReadOnly = True
        '
        'CMBCrm
        '
        resources.ApplyResources(Me.CMBCrm, "CMBCrm")
        Me.CMBCrm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.CMBCrm.Name = "CMBCrm"
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
        Me.pnlSearchLPO.CaptionText = "Search QCD Analysis Crumb Rubber"
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
        'lblgrad
        '
        resources.ApplyResources(Me.lblgrad, "lblgrad")
        Me.lblgrad.Name = "lblgrad"
        '
        'txtgrade
        '
        resources.ApplyResources(Me.txtgrade, "txtgrade")
        Me.txtgrade.Name = "txtgrade"
        '
        'btngrad
        '
        resources.ApplyResources(Me.btngrad, "btngrad")
        Me.btngrad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btngrad.FlatAppearance.BorderSize = 0
        Me.btngrad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btngrad.Name = "btngrad"
        Me.btngrad.TabStop = False
        Me.btngrad.UseVisualStyleBackColor = True
        '
        'ProductionQcdCrumbFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionQcdCrumbFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.TabSave.ResumeLayout(False)
        Me.TabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSearch.ResumeLayout(False)
        Me.TabSearch.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMBCrm.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents TabSave As System.Windows.Forms.TabPage
    Friend WithEvents txtVehicleNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtNoPallet As System.Windows.Forms.TextBox
    Friend WithEvents lblnopallet As System.Windows.Forms.Label
    Friend WithEvents lblvehicleno As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLc As System.Windows.Forms.TextBox
    Friend WithEvents lbllc As System.Windows.Forms.Label
    Friend WithEvents txtNitrogenContent As System.Windows.Forms.TextBox
    Friend WithEvents lblncp As System.Windows.Forms.Label
    Friend WithEvents txtVolatileMater As System.Windows.Forms.TextBox
    Friend WithEvents lblvmp As System.Windows.Forms.Label
    Friend WithEvents txtMooneyViscosity As System.Windows.Forms.TextBox
    Friend WithEvents lblmooney As System.Windows.Forms.Label
    Friend WithEvents txtPri As System.Windows.Forms.TextBox
    Friend WithEvents lblpri As System.Windows.Forms.Label
    Friend WithEvents txtP30 As System.Windows.Forms.TextBox
    Friend WithEvents lblp30 As System.Windows.Forms.Label
    Friend WithEvents txtMillWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblmillweight As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldono As System.Windows.Forms.Label
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents lblgrade As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents TabSearch As System.Windows.Forms.TabPage
    Friend WithEvents txtAshContent As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDest As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNoLot As System.Windows.Forms.TextBox
    Friend WithEvents lblnolot As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblproduct As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents txtDirtContent As System.Windows.Forms.TextBox
    Friend WithEvents lbldirtcontent As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtDoNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents txtLoadLoc As System.Windows.Forms.TextBox
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
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
    Friend WithEvents btnLoadLoc As System.Windows.Forms.Button
    Friend WithEvents btnProd As System.Windows.Forms.Button
    Friend WithEvents btnCat As System.Windows.Forms.Button
    Friend WithEvents btnStor As System.Windows.Forms.Button
    Friend WithEvents CMBCrm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtstor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblgrad As System.Windows.Forms.Label
    Friend WithEvents btngrad As System.Windows.Forms.Button
    Friend WithEvents txtgrade As System.Windows.Forms.TextBox
End Class
