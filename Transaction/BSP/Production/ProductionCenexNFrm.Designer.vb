<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionCenexNFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductionCenexNFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabContainerMain = New System.Windows.Forms.TabControl()
        Me.TabSave = New System.Windows.Forms.TabPage()
        Me.btncnxstor = New System.Windows.Forms.Button()
        Me.btncnxprod = New System.Windows.Forms.Button()
        Me.txtcnxstor = New System.Windows.Forms.TextBox()
        Me.txtcnxprod = New System.Windows.Forms.TextBox()
        Me.txtstoptime = New System.Windows.Forms.TextBox()
        Me.txtstarttime = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btncnxprodR = New System.Windows.Forms.Button()
        Me.btncnxstorR = New System.Windows.Forms.Button()
        Me.txtrecvstor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtrecvprod = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtlossngain = New System.Windows.Forms.TextBox()
        Me.txtconcdry = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtconcwet = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtwashing = New System.Windows.Forms.TextBox()
        Me.txtlimbah = New System.Windows.Forms.TextBox()
        Me.txtlatexprocdry = New System.Windows.Forms.TextBox()
        Me.txtlatexprocwet = New System.Windows.Forms.TextBox()
        Me.txtsludge = New System.Windows.Forms.TextBox()
        Me.txtrecvdry = New System.Windows.Forms.TextBox()
        Me.txtskimdry = New System.Windows.Forms.TextBox()
        Me.txtrecvwet = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtassistantcenex = New System.Windows.Forms.TextBox()
        Me.txtshifthourscenex = New System.Windows.Forms.TextBox()
        Me.txtbreaktimecenex = New System.Windows.Forms.TextBox()
        Me.lblstoragerm = New System.Windows.Forms.Label()
        Me.lblproducttype = New System.Windows.Forms.Label()
        Me.lblshifthours = New System.Windows.Forms.Label()
        Me.lblstoptime = New System.Windows.Forms.Label()
        Me.lblassistant = New System.Windows.Forms.Label()
        Me.lblstarttime = New System.Windows.Forms.Label()
        Me.lblbreakdowntime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.TabSearch = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.dgtxtDocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtDocDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtxtprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtxtstor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmscnx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TabContainerMain.SuspendLayout()
        Me.TabSave.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabSearch.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmscnx.SuspendLayout()
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
        Me.TabSave.Controls.Add(Me.btncnxstor)
        Me.TabSave.Controls.Add(Me.btncnxprod)
        Me.TabSave.Controls.Add(Me.txtcnxstor)
        Me.TabSave.Controls.Add(Me.txtcnxprod)
        Me.TabSave.Controls.Add(Me.txtstoptime)
        Me.TabSave.Controls.Add(Me.txtstarttime)
        Me.TabSave.Controls.Add(Me.btnSave)
        Me.TabSave.Controls.Add(Me.btnUpdate)
        Me.TabSave.Controls.Add(Me.btnReset)
        Me.TabSave.Controls.Add(Me.btnClose)
        Me.TabSave.Controls.Add(Me.GroupBox1)
        Me.TabSave.Controls.Add(Me.dtpDate)
        Me.TabSave.Controls.Add(Me.txtassistantcenex)
        Me.TabSave.Controls.Add(Me.txtshifthourscenex)
        Me.TabSave.Controls.Add(Me.txtbreaktimecenex)
        Me.TabSave.Controls.Add(Me.lblstoragerm)
        Me.TabSave.Controls.Add(Me.lblproducttype)
        Me.TabSave.Controls.Add(Me.lblshifthours)
        Me.TabSave.Controls.Add(Me.lblstoptime)
        Me.TabSave.Controls.Add(Me.lblassistant)
        Me.TabSave.Controls.Add(Me.lblstarttime)
        Me.TabSave.Controls.Add(Me.lblbreakdowntime)
        Me.TabSave.Controls.Add(Me.lbldate)
        Me.TabSave.Name = "TabSave"
        Me.TabSave.UseVisualStyleBackColor = True
        '
        'btncnxstor
        '
        resources.ApplyResources(Me.btncnxstor, "btncnxstor")
        Me.btncnxstor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btncnxstor.FlatAppearance.BorderSize = 0
        Me.btncnxstor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btncnxstor.Name = "btncnxstor"
        Me.btncnxstor.TabStop = False
        Me.btncnxstor.UseVisualStyleBackColor = True
        '
        'btncnxprod
        '
        resources.ApplyResources(Me.btncnxprod, "btncnxprod")
        Me.btncnxprod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btncnxprod.FlatAppearance.BorderSize = 0
        Me.btncnxprod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btncnxprod.Name = "btncnxprod"
        Me.btncnxprod.TabStop = False
        Me.btncnxprod.UseVisualStyleBackColor = True
        '
        'txtcnxstor
        '
        resources.ApplyResources(Me.txtcnxstor, "txtcnxstor")
        Me.txtcnxstor.Name = "txtcnxstor"
        '
        'txtcnxprod
        '
        resources.ApplyResources(Me.txtcnxprod, "txtcnxprod")
        Me.txtcnxprod.Name = "txtcnxprod"
        '
        'txtstoptime
        '
        resources.ApplyResources(Me.txtstoptime, "txtstoptime")
        Me.txtstoptime.Name = "txtstoptime"
        '
        'txtstarttime
        '
        resources.ApplyResources(Me.txtstarttime, "txtstarttime")
        Me.txtstarttime.Name = "txtstarttime"
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
        Me.GroupBox1.Controls.Add(Me.btncnxprodR)
        Me.GroupBox1.Controls.Add(Me.btncnxstorR)
        Me.GroupBox1.Controls.Add(Me.txtrecvstor)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtrecvprod)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtlossngain)
        Me.GroupBox1.Controls.Add(Me.txtconcdry)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtconcwet)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtwashing)
        Me.GroupBox1.Controls.Add(Me.txtlimbah)
        Me.GroupBox1.Controls.Add(Me.txtlatexprocdry)
        Me.GroupBox1.Controls.Add(Me.txtlatexprocwet)
        Me.GroupBox1.Controls.Add(Me.txtsludge)
        Me.GroupBox1.Controls.Add(Me.txtrecvdry)
        Me.GroupBox1.Controls.Add(Me.txtskimdry)
        Me.GroupBox1.Controls.Add(Me.txtrecvwet)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'btncnxprodR
        '
        resources.ApplyResources(Me.btncnxprodR, "btncnxprodR")
        Me.btncnxprodR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btncnxprodR.FlatAppearance.BorderSize = 0
        Me.btncnxprodR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btncnxprodR.Name = "btncnxprodR"
        Me.btncnxprodR.TabStop = False
        Me.btncnxprodR.UseVisualStyleBackColor = True
        '
        'btncnxstorR
        '
        resources.ApplyResources(Me.btncnxstorR, "btncnxstorR")
        Me.btncnxstorR.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btncnxstorR.FlatAppearance.BorderSize = 0
        Me.btncnxstorR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btncnxstorR.Name = "btncnxstorR"
        Me.btncnxstorR.TabStop = False
        Me.btncnxstorR.UseVisualStyleBackColor = True
        '
        'txtrecvstor
        '
        resources.ApplyResources(Me.txtrecvstor, "txtrecvstor")
        Me.txtrecvstor.Name = "txtrecvstor"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'txtrecvprod
        '
        resources.ApplyResources(Me.txtrecvprod, "txtrecvprod")
        Me.txtrecvprod.Name = "txtrecvprod"
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
        'txtlossngain
        '
        resources.ApplyResources(Me.txtlossngain, "txtlossngain")
        Me.txtlossngain.Name = "txtlossngain"
        '
        'txtconcdry
        '
        resources.ApplyResources(Me.txtconcdry, "txtconcdry")
        Me.txtconcdry.Name = "txtconcdry"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'txtconcwet
        '
        resources.ApplyResources(Me.txtconcwet, "txtconcwet")
        Me.txtconcwet.Name = "txtconcwet"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'txtwashing
        '
        resources.ApplyResources(Me.txtwashing, "txtwashing")
        Me.txtwashing.Name = "txtwashing"
        '
        'txtlimbah
        '
        resources.ApplyResources(Me.txtlimbah, "txtlimbah")
        Me.txtlimbah.Name = "txtlimbah"
        '
        'txtlatexprocdry
        '
        resources.ApplyResources(Me.txtlatexprocdry, "txtlatexprocdry")
        Me.txtlatexprocdry.Name = "txtlatexprocdry"
        '
        'txtlatexprocwet
        '
        resources.ApplyResources(Me.txtlatexprocwet, "txtlatexprocwet")
        Me.txtlatexprocwet.Name = "txtlatexprocwet"
        '
        'txtsludge
        '
        resources.ApplyResources(Me.txtsludge, "txtsludge")
        Me.txtsludge.Name = "txtsludge"
        '
        'txtrecvdry
        '
        resources.ApplyResources(Me.txtrecvdry, "txtrecvdry")
        Me.txtrecvdry.Name = "txtrecvdry"
        '
        'txtskimdry
        '
        resources.ApplyResources(Me.txtskimdry, "txtskimdry")
        Me.txtskimdry.Name = "txtskimdry"
        '
        'txtrecvwet
        '
        resources.ApplyResources(Me.txtrecvwet, "txtrecvwet")
        Me.txtrecvwet.Name = "txtrecvwet"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
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
        'dtpDate
        '
        resources.ApplyResources(Me.dtpDate, "dtpDate")
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Name = "dtpDate"
        '
        'txtassistantcenex
        '
        resources.ApplyResources(Me.txtassistantcenex, "txtassistantcenex")
        Me.txtassistantcenex.Name = "txtassistantcenex"
        '
        'txtshifthourscenex
        '
        resources.ApplyResources(Me.txtshifthourscenex, "txtshifthourscenex")
        Me.txtshifthourscenex.Name = "txtshifthourscenex"
        '
        'txtbreaktimecenex
        '
        resources.ApplyResources(Me.txtbreaktimecenex, "txtbreaktimecenex")
        Me.txtbreaktimecenex.Name = "txtbreaktimecenex"
        '
        'lblstoragerm
        '
        resources.ApplyResources(Me.lblstoragerm, "lblstoragerm")
        Me.lblstoragerm.Name = "lblstoragerm"
        '
        'lblproducttype
        '
        resources.ApplyResources(Me.lblproducttype, "lblproducttype")
        Me.lblproducttype.Name = "lblproducttype"
        '
        'lblshifthours
        '
        resources.ApplyResources(Me.lblshifthours, "lblshifthours")
        Me.lblshifthours.Name = "lblshifthours"
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
        Me.dgvView.ContextMenuStrip = Me.cmscnx
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
        Me.dgtxtprod.DataPropertyName = "LCNXProduct"
        resources.ApplyResources(Me.dgtxtprod, "dgtxtprod")
        Me.dgtxtprod.Name = "dgtxtprod"
        Me.dgtxtprod.ReadOnly = True
        '
        'dgvtxtstor
        '
        Me.dgvtxtstor.DataPropertyName = "LCNXStorage"
        resources.ApplyResources(Me.dgvtxtstor, "dgvtxtstor")
        Me.dgvtxtstor.Name = "dgvtxtstor"
        Me.dgvtxtstor.ReadOnly = True
        '
        'cmscnx
        '
        resources.ApplyResources(Me.cmscnx, "cmscnx")
        Me.cmscnx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmscnx.Name = "ContextMenuStrip1"
        '
        'AddToolStripMenuItem
        '
        resources.ApplyResources(Me.AddToolStripMenuItem, "AddToolStripMenuItem")
        Me.AddToolStripMenuItem.BackgroundImage = Global.BSP.My.Resources.Resources.user_add1
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        '
        'EditToolStripMenuItem
        '
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        Me.EditToolStripMenuItem.BackgroundImage = Global.BSP.My.Resources.Resources.icon_edit
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        '
        'DeleteToolStripMenuItem
        '
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        Me.DeleteToolStripMenuItem.BackgroundImage = Global.BSP.My.Resources.Resources.icon_delete
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
        Me.pnlSearchLPO.CaptionText = "Search ProductionLog Cenex Details"
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
        'ProductionCenexNFrm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.Controls.Add(Me.TabContainerMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProductionCenexNFrm"
        Me.TabContainerMain.ResumeLayout(False)
        Me.TabSave.ResumeLayout(False)
        Me.TabSave.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabSearch.ResumeLayout(False)
        Me.TabSearch.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmscnx.ResumeLayout(False)
        Me.pnlSearchLPO.ResumeLayout(False)
        Me.pnlSearchLPO.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabContainerMain As System.Windows.Forms.TabControl
    Friend WithEvents TabSave As System.Windows.Forms.TabPage
    Friend WithEvents TabSearch As System.Windows.Forms.TabPage
    Friend WithEvents lblstoragerm As System.Windows.Forms.Label
    Friend WithEvents lblproducttype As System.Windows.Forms.Label
    Friend WithEvents lblshifthours As System.Windows.Forms.Label
    Friend WithEvents lblstoptime As System.Windows.Forms.Label
    Friend WithEvents lblassistant As System.Windows.Forms.Label
    Friend WithEvents lblstarttime As System.Windows.Forms.Label
    Friend WithEvents lblbreakdowntime As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents txtshifthourscenex As System.Windows.Forms.TextBox
    Friend WithEvents txtbreaktimecenex As System.Windows.Forms.TextBox
    Friend WithEvents txtassistantcenex As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtlatexprocdry As System.Windows.Forms.TextBox
    Friend WithEvents txtlatexprocwet As System.Windows.Forms.TextBox
    Friend WithEvents txtsludge As System.Windows.Forms.TextBox
    Friend WithEvents txtrecvdry As System.Windows.Forms.TextBox
    Friend WithEvents txtskimdry As System.Windows.Forms.TextBox
    Friend WithEvents txtrecvwet As System.Windows.Forms.TextBox
    Friend WithEvents txtlimbah As System.Windows.Forms.TextBox
    Friend WithEvents txtwashing As System.Windows.Forms.TextBox
    Friend WithEvents txtconcwet As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtconcdry As System.Windows.Forms.TextBox
    Friend WithEvents txtlossngain As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
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
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents txtstoptime As System.Windows.Forms.TextBox
    Friend WithEvents txtstarttime As System.Windows.Forms.TextBox
    Friend WithEvents txtrecvprod As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtrecvstor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtcnxprod As System.Windows.Forms.TextBox
    Friend WithEvents txtcnxstor As System.Windows.Forms.TextBox
    Friend WithEvents btncnxprod As System.Windows.Forms.Button
    Friend WithEvents btncnxstor As System.Windows.Forms.Button
    Friend WithEvents btncnxstorR As System.Windows.Forms.Button
    Friend WithEvents btncnxprodR As System.Windows.Forms.Button
    Friend WithEvents cmscnx As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgtxtDocID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtDocDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgtxtprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvtxtstor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
