﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalaryAndWagesAdministrationFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalaryAndWagesAdministrationFrm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbSalaryAndWagesAdminstration = New System.Windows.Forms.TabControl
        Me.tbSalaryAndWages = New System.Windows.Forms.TabPage
        Me.btnPrintSummary = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GrpGrid = New System.Windows.Forms.GroupBox
        Me.dgAdminExpand = New System.Windows.Forms.DataGridView
        Me.AdminExpendID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BDGYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBudgetTotal = New System.Windows.Forms.Label
        Me.lblBudgetTotalL = New System.Windows.Forms.Label
        Me.grpMonths = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblPinkDecL = New System.Windows.Forms.Label
        Me.lblRevisionDec = New System.Windows.Forms.Label
        Me.lblBudgetDec = New System.Windows.Forms.Label
        Me.lblPinkAugL = New System.Windows.Forms.Label
        Me.lblRevisionAug = New System.Windows.Forms.Label
        Me.lblBudgetAug = New System.Windows.Forms.Label
        Me.lblPinkAprL = New System.Windows.Forms.Label
        Me.lblRevisionApr = New System.Windows.Forms.Label
        Me.lblBudgetApr = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.lblPinkNovL = New System.Windows.Forms.Label
        Me.lblRevisionNov = New System.Windows.Forms.Label
        Me.lblBudgetNov = New System.Windows.Forms.Label
        Me.lblPinkJulL = New System.Windows.Forms.Label
        Me.lblRevisionJul = New System.Windows.Forms.Label
        Me.lblBudgetJul = New System.Windows.Forms.Label
        Me.lblPinkMarL = New System.Windows.Forms.Label
        Me.lblRevisionMar = New System.Windows.Forms.Label
        Me.lblBudgetMar = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.lblPinkOctL = New System.Windows.Forms.Label
        Me.lblRevisionOct = New System.Windows.Forms.Label
        Me.lblBudgetOct = New System.Windows.Forms.Label
        Me.lblPinkJunL = New System.Windows.Forms.Label
        Me.lblRevisionJun = New System.Windows.Forms.Label
        Me.lblBudgetJun = New System.Windows.Forms.Label
        Me.lblPinkFebL = New System.Windows.Forms.Label
        Me.lblRevisionFeb = New System.Windows.Forms.Label
        Me.lblBudgetFeb = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.lblPinkSepL = New System.Windows.Forms.Label
        Me.lblRevisionSep = New System.Windows.Forms.Label
        Me.lblBudgetSep = New System.Windows.Forms.Label
        Me.lblPinkMayL = New System.Windows.Forms.Label
        Me.lblRevisionMay = New System.Windows.Forms.Label
        Me.lblBudgetMay = New System.Windows.Forms.Label
        Me.lblPinkJanL = New System.Windows.Forms.Label
        Me.lblRevisionJan = New System.Windows.Forms.Label
        Me.lblBudgetJan = New System.Windows.Forms.Label
        Me.lblPinkDec = New System.Windows.Forms.Label
        Me.lblPinkNov = New System.Windows.Forms.Label
        Me.lblPinkAug = New System.Windows.Forms.Label
        Me.lblPinkJul = New System.Windows.Forms.Label
        Me.lblPinkApr = New System.Windows.Forms.Label
        Me.lblPinkMar = New System.Windows.Forms.Label
        Me.lblPinkOct = New System.Windows.Forms.Label
        Me.lblPinkJun = New System.Windows.Forms.Label
        Me.lblPinkFeb = New System.Windows.Forms.Label
        Me.lblPinkSep = New System.Windows.Forms.Label
        Me.lblPinkJan = New System.Windows.Forms.Label
        Me.lblPinkMay = New System.Windows.Forms.Label
        Me.txtRevDec = New System.Windows.Forms.TextBox
        Me.txtBudgetDec = New System.Windows.Forms.TextBox
        Me.txtRevAug = New System.Windows.Forms.TextBox
        Me.txtBudgetAug = New System.Windows.Forms.TextBox
        Me.txtRevApr = New System.Windows.Forms.TextBox
        Me.txtBudgetApr = New System.Windows.Forms.TextBox
        Me.txtRevNov = New System.Windows.Forms.TextBox
        Me.txtBudgetNov = New System.Windows.Forms.TextBox
        Me.txtRevJul = New System.Windows.Forms.TextBox
        Me.txtBudgetJul = New System.Windows.Forms.TextBox
        Me.txtRevMar = New System.Windows.Forms.TextBox
        Me.txtBudgetMar = New System.Windows.Forms.TextBox
        Me.txtRevOct = New System.Windows.Forms.TextBox
        Me.txtBudgetOct = New System.Windows.Forms.TextBox
        Me.txtRevJun = New System.Windows.Forms.TextBox
        Me.txtBudgetJun = New System.Windows.Forms.TextBox
        Me.txtRevFeb = New System.Windows.Forms.TextBox
        Me.txtBudgetFeb = New System.Windows.Forms.TextBox
        Me.txtRevSep = New System.Windows.Forms.TextBox
        Me.txtBudgetSep = New System.Windows.Forms.TextBox
        Me.txtRevMay = New System.Windows.Forms.TextBox
        Me.txtBudgetMay = New System.Windows.Forms.TextBox
        Me.txtRevJan = New System.Windows.Forms.TextBox
        Me.txtBudgetJan = New System.Windows.Forms.TextBox
        Me.lblRPM3 = New System.Windows.Forms.Label
        Me.lblRPM2 = New System.Windows.Forms.Label
        Me.lblRPM1 = New System.Windows.Forms.Label
        Me.lblRPM = New System.Windows.Forms.Label
        Me.lblPinks = New System.Windows.Forms.Label
        Me.lblRevisions = New System.Windows.Forms.Label
        Me.lblBudgets = New System.Windows.Forms.Label
        Me.lblPinkSlipL = New System.Windows.Forms.Label
        Me.lblRevisionL = New System.Windows.Forms.Label
        Me.lblBudgetL = New System.Windows.Forms.Label
        Me.lblPinkSlip = New System.Windows.Forms.Label
        Me.lblRevision = New System.Windows.Forms.Label
        Me.lblBudget = New System.Windows.Forms.Label
        Me.grpBudgetYear = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblOldAccCode = New System.Windows.Forms.Label
        Me.txtPercentage = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblPercentage = New System.Windows.Forms.Label
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblDay = New System.Windows.Forms.Label
        Me.txtUnit = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblUnit = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblQty = New System.Windows.Forms.Label
        Me.txtSubDesc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSubDesc = New System.Windows.Forms.Label
        Me.lblOldCOACode = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblStatusL = New System.Windows.Forms.Label
        Me.lblVersionNo = New System.Windows.Forms.Label
        Me.lblVersionNoL = New System.Windows.Forms.Label
        Me.btnDistribute = New System.Windows.Forms.Button
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.btnSearchAccountCode = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalPrice = New System.Windows.Forms.TextBox
        Me.txtCOACode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBudgetYear = New System.Windows.Forms.Label
        Me.lblTotalPrice = New System.Windows.Forms.Label
        Me.lblCOA = New System.Windows.Forms.Label
        Me.lblBudgetyearL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.tbSalaryAndWagesAdminstration.SuspendLayout()
        Me.tbSalaryAndWages.SuspendLayout()
        Me.GrpGrid.SuspendLayout()
        CType(Me.dgAdminExpand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMonths.SuspendLayout()
        Me.grpBudgetYear.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbSalaryAndWagesAdminstration
        '
        Me.tbSalaryAndWagesAdminstration.Controls.Add(Me.tbSalaryAndWages)
        Me.tbSalaryAndWagesAdminstration.Controls.Add(Me.tbView)
        Me.tbSalaryAndWagesAdminstration.Location = New System.Drawing.Point(12, 2)
        Me.tbSalaryAndWagesAdminstration.Name = "tbSalaryAndWagesAdminstration"
        Me.tbSalaryAndWagesAdminstration.SelectedIndex = 0
        Me.tbSalaryAndWagesAdminstration.Size = New System.Drawing.Size(1089, 720)
        Me.tbSalaryAndWagesAdminstration.TabIndex = 1
        '
        'tbSalaryAndWages
        '
        Me.tbSalaryAndWages.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbSalaryAndWages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbSalaryAndWages.Controls.Add(Me.btnPrintSummary)
        Me.tbSalaryAndWages.Controls.Add(Me.btnPrint)
        Me.tbSalaryAndWages.Controls.Add(Me.btnReset)
        Me.tbSalaryAndWages.Controls.Add(Me.btnAdd)
        Me.tbSalaryAndWages.Controls.Add(Me.btnResetAll)
        Me.tbSalaryAndWages.Controls.Add(Me.btnSaveAll)
        Me.tbSalaryAndWages.Controls.Add(Me.btnClose)
        Me.tbSalaryAndWages.Controls.Add(Me.GrpGrid)
        Me.tbSalaryAndWages.Controls.Add(Me.lblBudgetTotal)
        Me.tbSalaryAndWages.Controls.Add(Me.lblBudgetTotalL)
        Me.tbSalaryAndWages.Controls.Add(Me.grpMonths)
        Me.tbSalaryAndWages.Controls.Add(Me.grpBudgetYear)
        Me.tbSalaryAndWages.Location = New System.Drawing.Point(4, 22)
        Me.tbSalaryAndWages.Name = "tbSalaryAndWages"
        Me.tbSalaryAndWages.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSalaryAndWages.Size = New System.Drawing.Size(1081, 694)
        Me.tbSalaryAndWages.TabIndex = 0
        Me.tbSalaryAndWages.Text = "Salary & Wages "
        Me.tbSalaryAndWages.UseVisualStyleBackColor = True
        '
        'btnPrintSummary
        '
        Me.btnPrintSummary.BackgroundImage = CType(resources.GetObject("btnPrintSummary.BackgroundImage"), System.Drawing.Image)
        Me.btnPrintSummary.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrintSummary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintSummary.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnPrintSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintSummary.Location = New System.Drawing.Point(944, 663)
        Me.btnPrintSummary.Name = "btnPrintSummary"
        Me.btnPrintSummary.Size = New System.Drawing.Size(106, 25)
        Me.btnPrintSummary.TabIndex = 252
        Me.btnPrintSummary.Text = "Print Summary"
        Me.btnPrintSummary.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Image = Global.BSP.My.Resources.Resources.script_48x48
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(832, 663)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 25)
        Me.btnPrint.TabIndex = 251
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(882, 494)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(97, 25)
        Me.btnReset.TabIndex = 250
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(779, 494)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 25)
        Me.btnAdd.TabIndex = 249
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(609, 663)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(106, 25)
        Me.btnResetAll.TabIndex = 244
        Me.btnResetAll.Text = "Reset"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(497, 663)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(106, 25)
        Me.btnSaveAll.TabIndex = 243
        Me.btnSaveAll.Text = "Save "
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(721, 663)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 25)
        Me.btnClose.TabIndex = 245
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GrpGrid
        '
        Me.GrpGrid.Controls.Add(Me.dgAdminExpand)
        Me.GrpGrid.Location = New System.Drawing.Point(11, 517)
        Me.GrpGrid.Name = "GrpGrid"
        Me.GrpGrid.Size = New System.Drawing.Size(1021, 145)
        Me.GrpGrid.TabIndex = 248
        Me.GrpGrid.TabStop = False
        '
        'dgAdminExpand
        '
        Me.dgAdminExpand.AllowUserToAddRows = False
        Me.dgAdminExpand.AllowUserToDeleteRows = False
        Me.dgAdminExpand.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgAdminExpand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgAdminExpand.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgAdminExpand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAdminExpand.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgAdminExpand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAdminExpand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdminExpendID, Me.BDGYear, Me.EstateID, Me.COAId, Me.COACode, Me.COADescp, Me.BudgetJan, Me.BudgetFeb, Me.BudgetMar, Me.BudgetApr, Me.BudgetMay, Me.BudgetJun, Me.BudgetJul, Me.BudgetAug, Me.BudgetSep, Me.BudgetOct, Me.BudgetNov, Me.BudgetDec, Me.RevJan, Me.RevFeb, Me.RevMar, Me.RevApr, Me.RevMay, Me.RevJun, Me.RevJul, Me.RevAug, Me.RevSep, Me.RevOct, Me.RevNov, Me.RevDec, Me.PinkJan, Me.PinkFeb, Me.PinkMar, Me.PinkApr, Me.PinkMay, Me.PinkJun, Me.PinkJul, Me.PinkAug, Me.PinkSep, Me.PinkOct, Me.PinkNov, Me.PinkDec, Me.Amount, Me.Remarks, Me.BudgetTotal, Me.VersionNo, Me.Status})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAdminExpand.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgAdminExpand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAdminExpand.EnableHeadersVisualStyles = False
        Me.dgAdminExpand.GridColor = System.Drawing.Color.Gray
        Me.dgAdminExpand.Location = New System.Drawing.Point(3, 17)
        Me.dgAdminExpand.Name = "dgAdminExpand"
        Me.dgAdminExpand.RowHeadersVisible = False
        Me.dgAdminExpand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAdminExpand.ShowCellErrors = False
        Me.dgAdminExpand.Size = New System.Drawing.Size(1015, 125)
        Me.dgAdminExpand.TabIndex = 120
        '
        'AdminExpendID
        '
        Me.AdminExpendID.DataPropertyName = "AdminExpendID"
        Me.AdminExpendID.HeaderText = "AdminExpendID"
        Me.AdminExpendID.Name = "AdminExpendID"
        Me.AdminExpendID.Visible = False
        Me.AdminExpendID.Width = 123
        '
        'BDGYear
        '
        Me.BDGYear.DataPropertyName = "BDGYear"
        Me.BDGYear.HeaderText = "Budget Year"
        Me.BDGYear.Name = "BDGYear"
        Me.BDGYear.Width = 101
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.Visible = False
        Me.EstateID.Width = 80
        '
        'COAId
        '
        Me.COAId.DataPropertyName = "COAId"
        Me.COAId.HeaderText = "COA Id"
        Me.COAId.Name = "COAId"
        Me.COAId.Visible = False
        Me.COAId.Width = 73
        '
        'COACode
        '
        Me.COACode.DataPropertyName = "COACode"
        Me.COACode.HeaderText = "COA Code"
        Me.COACode.Name = "COACode"
        Me.COACode.Width = 91
        '
        'COADescp
        '
        Me.COADescp.DataPropertyName = "COADescp"
        Me.COADescp.HeaderText = "COA Descp"
        Me.COADescp.Name = "COADescp"
        Me.COADescp.Width = 96
        '
        'BudgetJan
        '
        Me.BudgetJan.DataPropertyName = "BudgetJan"
        Me.BudgetJan.HeaderText = "BudgetJan"
        Me.BudgetJan.Name = "BudgetJan"
        Me.BudgetJan.Width = 90
        '
        'BudgetFeb
        '
        Me.BudgetFeb.DataPropertyName = "BudgetFeb"
        Me.BudgetFeb.HeaderText = "BudgetFeb"
        Me.BudgetFeb.Name = "BudgetFeb"
        Me.BudgetFeb.Width = 91
        '
        'BudgetMar
        '
        Me.BudgetMar.DataPropertyName = "BudgetMar"
        Me.BudgetMar.HeaderText = "BudgetMar"
        Me.BudgetMar.Name = "BudgetMar"
        Me.BudgetMar.Width = 92
        '
        'BudgetApr
        '
        Me.BudgetApr.DataPropertyName = "BudgetApr"
        Me.BudgetApr.HeaderText = "BudgetApr"
        Me.BudgetApr.Name = "BudgetApr"
        Me.BudgetApr.Width = 91
        '
        'BudgetMay
        '
        Me.BudgetMay.DataPropertyName = "BudgetMay"
        Me.BudgetMay.HeaderText = "BudgetMay"
        Me.BudgetMay.Name = "BudgetMay"
        Me.BudgetMay.Width = 94
        '
        'BudgetJun
        '
        Me.BudgetJun.DataPropertyName = "BudgetJun"
        Me.BudgetJun.HeaderText = "BudgetJun"
        Me.BudgetJun.Name = "BudgetJun"
        Me.BudgetJun.Width = 90
        '
        'BudgetJul
        '
        Me.BudgetJul.DataPropertyName = "BudgetJul"
        Me.BudgetJul.HeaderText = "BudgetJul"
        Me.BudgetJul.Name = "BudgetJul"
        Me.BudgetJul.Width = 86
        '
        'BudgetAug
        '
        Me.BudgetAug.DataPropertyName = "BudgetAug"
        Me.BudgetAug.HeaderText = "BudgetAug"
        Me.BudgetAug.Name = "BudgetAug"
        Me.BudgetAug.Width = 93
        '
        'BudgetSep
        '
        Me.BudgetSep.DataPropertyName = "BudgetSep"
        Me.BudgetSep.HeaderText = "BudgetSep"
        Me.BudgetSep.Name = "BudgetSep"
        Me.BudgetSep.Width = 93
        '
        'BudgetOct
        '
        Me.BudgetOct.DataPropertyName = "BudgetOct"
        Me.BudgetOct.HeaderText = "BudgetOct"
        Me.BudgetOct.Name = "BudgetOct"
        Me.BudgetOct.Width = 90
        '
        'BudgetNov
        '
        Me.BudgetNov.DataPropertyName = "BudgetNov"
        Me.BudgetNov.HeaderText = "BudgetNov"
        Me.BudgetNov.Name = "BudgetNov"
        Me.BudgetNov.Width = 93
        '
        'BudgetDec
        '
        Me.BudgetDec.DataPropertyName = "BudgetDec"
        Me.BudgetDec.HeaderText = "BudgetDec"
        Me.BudgetDec.Name = "BudgetDec"
        Me.BudgetDec.Width = 93
        '
        'RevJan
        '
        Me.RevJan.DataPropertyName = "RevJan"
        Me.RevJan.HeaderText = "RevJan"
        Me.RevJan.Name = "RevJan"
        Me.RevJan.Visible = False
        Me.RevJan.Width = 72
        '
        'RevFeb
        '
        Me.RevFeb.DataPropertyName = "RevFeb"
        Me.RevFeb.HeaderText = "RevFeb"
        Me.RevFeb.Name = "RevFeb"
        Me.RevFeb.Visible = False
        Me.RevFeb.Width = 73
        '
        'RevMar
        '
        Me.RevMar.DataPropertyName = "RevMar"
        Me.RevMar.HeaderText = "RevMar"
        Me.RevMar.Name = "RevMar"
        Me.RevMar.Visible = False
        Me.RevMar.Width = 74
        '
        'RevApr
        '
        Me.RevApr.DataPropertyName = "RevApr"
        Me.RevApr.HeaderText = "RevApr"
        Me.RevApr.Name = "RevApr"
        Me.RevApr.Visible = False
        Me.RevApr.Width = 73
        '
        'RevMay
        '
        Me.RevMay.DataPropertyName = "RevMay"
        Me.RevMay.HeaderText = "RevMay"
        Me.RevMay.Name = "RevMay"
        Me.RevMay.Visible = False
        Me.RevMay.Width = 76
        '
        'RevJun
        '
        Me.RevJun.DataPropertyName = "RevJun"
        Me.RevJun.HeaderText = "RevJun"
        Me.RevJun.Name = "RevJun"
        Me.RevJun.Visible = False
        Me.RevJun.Width = 72
        '
        'RevJul
        '
        Me.RevJul.DataPropertyName = "RevJul"
        Me.RevJul.HeaderText = "RevJul"
        Me.RevJul.Name = "RevJul"
        Me.RevJul.Visible = False
        Me.RevJul.Width = 68
        '
        'RevAug
        '
        Me.RevAug.DataPropertyName = "RevAug"
        Me.RevAug.HeaderText = "RevAug"
        Me.RevAug.Name = "RevAug"
        Me.RevAug.Visible = False
        Me.RevAug.Width = 75
        '
        'RevSep
        '
        Me.RevSep.DataPropertyName = "RevSep"
        Me.RevSep.HeaderText = "RevSep"
        Me.RevSep.Name = "RevSep"
        Me.RevSep.Visible = False
        Me.RevSep.Width = 75
        '
        'RevOct
        '
        Me.RevOct.DataPropertyName = "RevOct"
        Me.RevOct.HeaderText = "RevOct"
        Me.RevOct.Name = "RevOct"
        Me.RevOct.Visible = False
        Me.RevOct.Width = 72
        '
        'RevNov
        '
        Me.RevNov.DataPropertyName = "RevNov"
        Me.RevNov.HeaderText = "RevNov"
        Me.RevNov.Name = "RevNov"
        Me.RevNov.Visible = False
        Me.RevNov.Width = 75
        '
        'RevDec
        '
        Me.RevDec.DataPropertyName = "RevDec"
        Me.RevDec.HeaderText = "RevDec"
        Me.RevDec.Name = "RevDec"
        Me.RevDec.Visible = False
        Me.RevDec.Width = 75
        '
        'PinkJan
        '
        Me.PinkJan.DataPropertyName = "PinkJan"
        Me.PinkJan.HeaderText = "PinkJan"
        Me.PinkJan.Name = "PinkJan"
        Me.PinkJan.Visible = False
        Me.PinkJan.Width = 74
        '
        'PinkFeb
        '
        Me.PinkFeb.DataPropertyName = "PinkFeb"
        Me.PinkFeb.HeaderText = "PinkFeb"
        Me.PinkFeb.Name = "PinkFeb"
        Me.PinkFeb.Visible = False
        Me.PinkFeb.Width = 75
        '
        'PinkMar
        '
        Me.PinkMar.DataPropertyName = "PinkMar"
        Me.PinkMar.HeaderText = "PinkMar"
        Me.PinkMar.Name = "PinkMar"
        Me.PinkMar.Visible = False
        Me.PinkMar.Width = 76
        '
        'PinkApr
        '
        Me.PinkApr.DataPropertyName = "PinkApr"
        Me.PinkApr.HeaderText = "PinkApr"
        Me.PinkApr.Name = "PinkApr"
        Me.PinkApr.Visible = False
        Me.PinkApr.Width = 75
        '
        'PinkMay
        '
        Me.PinkMay.DataPropertyName = "PinkMay"
        Me.PinkMay.HeaderText = "PinkMay"
        Me.PinkMay.Name = "PinkMay"
        Me.PinkMay.Visible = False
        Me.PinkMay.Width = 78
        '
        'PinkJun
        '
        Me.PinkJun.DataPropertyName = "PinkJun"
        Me.PinkJun.HeaderText = "PinkJun"
        Me.PinkJun.Name = "PinkJun"
        Me.PinkJun.Visible = False
        Me.PinkJun.Width = 74
        '
        'PinkJul
        '
        Me.PinkJul.DataPropertyName = "PinkJul"
        Me.PinkJul.HeaderText = "PinkJul"
        Me.PinkJul.Name = "PinkJul"
        Me.PinkJul.Visible = False
        Me.PinkJul.Width = 70
        '
        'PinkAug
        '
        Me.PinkAug.DataPropertyName = "PinkAug"
        Me.PinkAug.HeaderText = "PinkAug"
        Me.PinkAug.Name = "PinkAug"
        Me.PinkAug.Visible = False
        Me.PinkAug.Width = 77
        '
        'PinkSep
        '
        Me.PinkSep.DataPropertyName = "PinkSep"
        Me.PinkSep.HeaderText = "PinkSep"
        Me.PinkSep.Name = "PinkSep"
        Me.PinkSep.Visible = False
        Me.PinkSep.Width = 77
        '
        'PinkOct
        '
        Me.PinkOct.DataPropertyName = "PinkOct"
        Me.PinkOct.HeaderText = "PinkOct"
        Me.PinkOct.Name = "PinkOct"
        Me.PinkOct.Visible = False
        Me.PinkOct.Width = 74
        '
        'PinkNov
        '
        Me.PinkNov.DataPropertyName = "PinkNov"
        Me.PinkNov.HeaderText = "PinkNov"
        Me.PinkNov.Name = "PinkNov"
        Me.PinkNov.Visible = False
        Me.PinkNov.Width = 77
        '
        'PinkDec
        '
        Me.PinkDec.DataPropertyName = "PinkDec"
        Me.PinkDec.HeaderText = "PinkDec"
        Me.PinkDec.Name = "PinkDec"
        Me.PinkDec.Visible = False
        Me.PinkDec.Width = 77
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Amount"
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 75
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 82
        '
        'BudgetTotal
        '
        Me.BudgetTotal.DataPropertyName = "BudgetTotal"
        Me.BudgetTotal.HeaderText = "BudgetTotal"
        Me.BudgetTotal.Name = "BudgetTotal"
        Me.BudgetTotal.Width = 99
        '
        'VersionNo
        '
        Me.VersionNo.DataPropertyName = "VersionNo"
        Me.VersionNo.HeaderText = "VersionNo"
        Me.VersionNo.Name = "VersionNo"
        Me.VersionNo.Width = 89
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 67
        '
        'lblBudgetTotal
        '
        Me.lblBudgetTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetTotal.Location = New System.Drawing.Point(844, 470)
        Me.lblBudgetTotal.Name = "lblBudgetTotal"
        Me.lblBudgetTotal.Size = New System.Drawing.Size(135, 21)
        Me.lblBudgetTotal.TabIndex = 247
        '
        'lblBudgetTotalL
        '
        Me.lblBudgetTotalL.AutoSize = True
        Me.lblBudgetTotalL.Location = New System.Drawing.Point(735, 470)
        Me.lblBudgetTotalL.Name = "lblBudgetTotalL"
        Me.lblBudgetTotalL.Size = New System.Drawing.Size(96, 13)
        Me.lblBudgetTotalL.TabIndex = 246
        Me.lblBudgetTotalL.Text = "Budget Total   :"
        '
        'grpMonths
        '
        Me.grpMonths.Controls.Add(Me.Label29)
        Me.grpMonths.Controls.Add(Me.Label30)
        Me.grpMonths.Controls.Add(Me.Label31)
        Me.grpMonths.Controls.Add(Me.Label26)
        Me.grpMonths.Controls.Add(Me.Label27)
        Me.grpMonths.Controls.Add(Me.Label28)
        Me.grpMonths.Controls.Add(Me.Label21)
        Me.grpMonths.Controls.Add(Me.Label20)
        Me.grpMonths.Controls.Add(Me.Label19)
        Me.grpMonths.Controls.Add(Me.lblPinkDecL)
        Me.grpMonths.Controls.Add(Me.lblRevisionDec)
        Me.grpMonths.Controls.Add(Me.lblBudgetDec)
        Me.grpMonths.Controls.Add(Me.lblPinkAugL)
        Me.grpMonths.Controls.Add(Me.lblRevisionAug)
        Me.grpMonths.Controls.Add(Me.lblBudgetAug)
        Me.grpMonths.Controls.Add(Me.lblPinkAprL)
        Me.grpMonths.Controls.Add(Me.lblRevisionApr)
        Me.grpMonths.Controls.Add(Me.lblBudgetApr)
        Me.grpMonths.Controls.Add(Me.Label32)
        Me.grpMonths.Controls.Add(Me.Label33)
        Me.grpMonths.Controls.Add(Me.Label34)
        Me.grpMonths.Controls.Add(Me.Label35)
        Me.grpMonths.Controls.Add(Me.Label36)
        Me.grpMonths.Controls.Add(Me.Label37)
        Me.grpMonths.Controls.Add(Me.Label38)
        Me.grpMonths.Controls.Add(Me.Label39)
        Me.grpMonths.Controls.Add(Me.Label40)
        Me.grpMonths.Controls.Add(Me.lblPinkNovL)
        Me.grpMonths.Controls.Add(Me.lblRevisionNov)
        Me.grpMonths.Controls.Add(Me.lblBudgetNov)
        Me.grpMonths.Controls.Add(Me.lblPinkJulL)
        Me.grpMonths.Controls.Add(Me.lblRevisionJul)
        Me.grpMonths.Controls.Add(Me.lblBudgetJul)
        Me.grpMonths.Controls.Add(Me.lblPinkMarL)
        Me.grpMonths.Controls.Add(Me.lblRevisionMar)
        Me.grpMonths.Controls.Add(Me.lblBudgetMar)
        Me.grpMonths.Controls.Add(Me.Label41)
        Me.grpMonths.Controls.Add(Me.Label42)
        Me.grpMonths.Controls.Add(Me.Label43)
        Me.grpMonths.Controls.Add(Me.Label44)
        Me.grpMonths.Controls.Add(Me.Label45)
        Me.grpMonths.Controls.Add(Me.Label46)
        Me.grpMonths.Controls.Add(Me.Label47)
        Me.grpMonths.Controls.Add(Me.Label48)
        Me.grpMonths.Controls.Add(Me.Label49)
        Me.grpMonths.Controls.Add(Me.lblPinkOctL)
        Me.grpMonths.Controls.Add(Me.lblRevisionOct)
        Me.grpMonths.Controls.Add(Me.lblBudgetOct)
        Me.grpMonths.Controls.Add(Me.lblPinkJunL)
        Me.grpMonths.Controls.Add(Me.lblRevisionJun)
        Me.grpMonths.Controls.Add(Me.lblBudgetJun)
        Me.grpMonths.Controls.Add(Me.lblPinkFebL)
        Me.grpMonths.Controls.Add(Me.lblRevisionFeb)
        Me.grpMonths.Controls.Add(Me.lblBudgetFeb)
        Me.grpMonths.Controls.Add(Me.Label50)
        Me.grpMonths.Controls.Add(Me.Label51)
        Me.grpMonths.Controls.Add(Me.Label52)
        Me.grpMonths.Controls.Add(Me.Label53)
        Me.grpMonths.Controls.Add(Me.Label54)
        Me.grpMonths.Controls.Add(Me.Label55)
        Me.grpMonths.Controls.Add(Me.Label56)
        Me.grpMonths.Controls.Add(Me.Label57)
        Me.grpMonths.Controls.Add(Me.Label58)
        Me.grpMonths.Controls.Add(Me.lblPinkSepL)
        Me.grpMonths.Controls.Add(Me.lblRevisionSep)
        Me.grpMonths.Controls.Add(Me.lblBudgetSep)
        Me.grpMonths.Controls.Add(Me.lblPinkMayL)
        Me.grpMonths.Controls.Add(Me.lblRevisionMay)
        Me.grpMonths.Controls.Add(Me.lblBudgetMay)
        Me.grpMonths.Controls.Add(Me.lblPinkJanL)
        Me.grpMonths.Controls.Add(Me.lblRevisionJan)
        Me.grpMonths.Controls.Add(Me.lblBudgetJan)
        Me.grpMonths.Controls.Add(Me.lblPinkDec)
        Me.grpMonths.Controls.Add(Me.lblPinkNov)
        Me.grpMonths.Controls.Add(Me.lblPinkAug)
        Me.grpMonths.Controls.Add(Me.lblPinkJul)
        Me.grpMonths.Controls.Add(Me.lblPinkApr)
        Me.grpMonths.Controls.Add(Me.lblPinkMar)
        Me.grpMonths.Controls.Add(Me.lblPinkOct)
        Me.grpMonths.Controls.Add(Me.lblPinkJun)
        Me.grpMonths.Controls.Add(Me.lblPinkFeb)
        Me.grpMonths.Controls.Add(Me.lblPinkSep)
        Me.grpMonths.Controls.Add(Me.lblPinkJan)
        Me.grpMonths.Controls.Add(Me.lblPinkMay)
        Me.grpMonths.Controls.Add(Me.txtRevDec)
        Me.grpMonths.Controls.Add(Me.txtBudgetDec)
        Me.grpMonths.Controls.Add(Me.txtRevAug)
        Me.grpMonths.Controls.Add(Me.txtBudgetAug)
        Me.grpMonths.Controls.Add(Me.txtRevApr)
        Me.grpMonths.Controls.Add(Me.txtBudgetApr)
        Me.grpMonths.Controls.Add(Me.txtRevNov)
        Me.grpMonths.Controls.Add(Me.txtBudgetNov)
        Me.grpMonths.Controls.Add(Me.txtRevJul)
        Me.grpMonths.Controls.Add(Me.txtBudgetJul)
        Me.grpMonths.Controls.Add(Me.txtRevMar)
        Me.grpMonths.Controls.Add(Me.txtBudgetMar)
        Me.grpMonths.Controls.Add(Me.txtRevOct)
        Me.grpMonths.Controls.Add(Me.txtBudgetOct)
        Me.grpMonths.Controls.Add(Me.txtRevJun)
        Me.grpMonths.Controls.Add(Me.txtBudgetJun)
        Me.grpMonths.Controls.Add(Me.txtRevFeb)
        Me.grpMonths.Controls.Add(Me.txtBudgetFeb)
        Me.grpMonths.Controls.Add(Me.txtRevSep)
        Me.grpMonths.Controls.Add(Me.txtBudgetSep)
        Me.grpMonths.Controls.Add(Me.txtRevMay)
        Me.grpMonths.Controls.Add(Me.txtBudgetMay)
        Me.grpMonths.Controls.Add(Me.txtRevJan)
        Me.grpMonths.Controls.Add(Me.txtBudgetJan)
        Me.grpMonths.Controls.Add(Me.lblRPM3)
        Me.grpMonths.Controls.Add(Me.lblRPM2)
        Me.grpMonths.Controls.Add(Me.lblRPM1)
        Me.grpMonths.Controls.Add(Me.lblRPM)
        Me.grpMonths.Controls.Add(Me.lblPinks)
        Me.grpMonths.Controls.Add(Me.lblRevisions)
        Me.grpMonths.Controls.Add(Me.lblBudgets)
        Me.grpMonths.Controls.Add(Me.lblPinkSlipL)
        Me.grpMonths.Controls.Add(Me.lblRevisionL)
        Me.grpMonths.Controls.Add(Me.lblBudgetL)
        Me.grpMonths.Controls.Add(Me.lblPinkSlip)
        Me.grpMonths.Controls.Add(Me.lblRevision)
        Me.grpMonths.Controls.Add(Me.lblBudget)
        Me.grpMonths.Location = New System.Drawing.Point(11, 195)
        Me.grpMonths.Name = "grpMonths"
        Me.grpMonths.Size = New System.Drawing.Size(1027, 271)
        Me.grpMonths.TabIndex = 9
        Me.grpMonths.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(806, 29)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 2331
        Me.Label29.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(806, 52)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 13)
        Me.Label30.TabIndex = 2330
        Me.Label30.Text = ":"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(806, 77)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 13)
        Me.Label31.TabIndex = 2329
        Me.Label31.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(806, 113)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 2328
        Me.Label26.Text = ":"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(806, 136)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 2327
        Me.Label27.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(806, 161)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 13)
        Me.Label28.TabIndex = 2326
        Me.Label28.Text = ":"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(806, 195)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 2325
        Me.Label21.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(806, 218)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 2324
        Me.Label20.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(806, 243)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 2323
        Me.Label19.Text = ":"
        '
        'lblPinkDecL
        '
        Me.lblPinkDecL.AutoSize = True
        Me.lblPinkDecL.Location = New System.Drawing.Point(750, 242)
        Me.lblPinkDecL.Name = "lblPinkDecL"
        Me.lblPinkDecL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkDecL.TabIndex = 2322
        Me.lblPinkDecL.Text = "Dec"
        '
        'lblRevisionDec
        '
        Me.lblRevisionDec.AutoSize = True
        Me.lblRevisionDec.Location = New System.Drawing.Point(750, 218)
        Me.lblRevisionDec.Name = "lblRevisionDec"
        Me.lblRevisionDec.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionDec.TabIndex = 2321
        Me.lblRevisionDec.Text = "Dec"
        '
        'lblBudgetDec
        '
        Me.lblBudgetDec.AutoSize = True
        Me.lblBudgetDec.Location = New System.Drawing.Point(750, 195)
        Me.lblBudgetDec.Name = "lblBudgetDec"
        Me.lblBudgetDec.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetDec.TabIndex = 2320
        Me.lblBudgetDec.Text = "Dec"
        '
        'lblPinkAugL
        '
        Me.lblPinkAugL.AutoSize = True
        Me.lblPinkAugL.Location = New System.Drawing.Point(750, 159)
        Me.lblPinkAugL.Name = "lblPinkAugL"
        Me.lblPinkAugL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkAugL.TabIndex = 2319
        Me.lblPinkAugL.Text = "Aug"
        '
        'lblRevisionAug
        '
        Me.lblRevisionAug.AutoSize = True
        Me.lblRevisionAug.Location = New System.Drawing.Point(750, 134)
        Me.lblRevisionAug.Name = "lblRevisionAug"
        Me.lblRevisionAug.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionAug.TabIndex = 2318
        Me.lblRevisionAug.Text = "Aug"
        '
        'lblBudgetAug
        '
        Me.lblBudgetAug.AutoSize = True
        Me.lblBudgetAug.Location = New System.Drawing.Point(750, 110)
        Me.lblBudgetAug.Name = "lblBudgetAug"
        Me.lblBudgetAug.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetAug.TabIndex = 2317
        Me.lblBudgetAug.Text = "Aug"
        '
        'lblPinkAprL
        '
        Me.lblPinkAprL.AutoSize = True
        Me.lblPinkAprL.Location = New System.Drawing.Point(750, 74)
        Me.lblPinkAprL.Name = "lblPinkAprL"
        Me.lblPinkAprL.Size = New System.Drawing.Size(27, 13)
        Me.lblPinkAprL.TabIndex = 2316
        Me.lblPinkAprL.Text = "Apr"
        '
        'lblRevisionApr
        '
        Me.lblRevisionApr.AutoSize = True
        Me.lblRevisionApr.Location = New System.Drawing.Point(750, 50)
        Me.lblRevisionApr.Name = "lblRevisionApr"
        Me.lblRevisionApr.Size = New System.Drawing.Size(27, 13)
        Me.lblRevisionApr.TabIndex = 2315
        Me.lblRevisionApr.Text = "Apr"
        '
        'lblBudgetApr
        '
        Me.lblBudgetApr.AutoSize = True
        Me.lblBudgetApr.Location = New System.Drawing.Point(750, 26)
        Me.lblBudgetApr.Name = "lblBudgetApr"
        Me.lblBudgetApr.Size = New System.Drawing.Size(27, 13)
        Me.lblBudgetApr.TabIndex = 2314
        Me.lblBudgetApr.Text = "Apr"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(567, 32)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 13)
        Me.Label32.TabIndex = 2313
        Me.Label32.Text = ":"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(567, 55)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 13)
        Me.Label33.TabIndex = 2312
        Me.Label33.Text = ":"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(567, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 13)
        Me.Label34.TabIndex = 2311
        Me.Label34.Text = ":"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(567, 116)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(11, 13)
        Me.Label35.TabIndex = 2310
        Me.Label35.Text = ":"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(567, 139)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 13)
        Me.Label36.TabIndex = 2309
        Me.Label36.Text = ":"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(567, 164)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(11, 13)
        Me.Label37.TabIndex = 2308
        Me.Label37.Text = ":"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(567, 198)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 13)
        Me.Label38.TabIndex = 2307
        Me.Label38.Text = ":"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(567, 221)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(11, 13)
        Me.Label39.TabIndex = 2306
        Me.Label39.Text = ":"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(567, 246)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 13)
        Me.Label40.TabIndex = 2305
        Me.Label40.Text = ":"
        '
        'lblPinkNovL
        '
        Me.lblPinkNovL.AutoSize = True
        Me.lblPinkNovL.Location = New System.Drawing.Point(516, 245)
        Me.lblPinkNovL.Name = "lblPinkNovL"
        Me.lblPinkNovL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkNovL.TabIndex = 2304
        Me.lblPinkNovL.Text = "Nov"
        '
        'lblRevisionNov
        '
        Me.lblRevisionNov.AutoSize = True
        Me.lblRevisionNov.Location = New System.Drawing.Point(516, 221)
        Me.lblRevisionNov.Name = "lblRevisionNov"
        Me.lblRevisionNov.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionNov.TabIndex = 2303
        Me.lblRevisionNov.Text = "Nov"
        '
        'lblBudgetNov
        '
        Me.lblBudgetNov.AutoSize = True
        Me.lblBudgetNov.Location = New System.Drawing.Point(516, 198)
        Me.lblBudgetNov.Name = "lblBudgetNov"
        Me.lblBudgetNov.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetNov.TabIndex = 2302
        Me.lblBudgetNov.Text = "Nov"
        '
        'lblPinkJulL
        '
        Me.lblPinkJulL.AutoSize = True
        Me.lblPinkJulL.Location = New System.Drawing.Point(516, 162)
        Me.lblPinkJulL.Name = "lblPinkJulL"
        Me.lblPinkJulL.Size = New System.Drawing.Size(22, 13)
        Me.lblPinkJulL.TabIndex = 2301
        Me.lblPinkJulL.Text = "Jul"
        '
        'lblRevisionJul
        '
        Me.lblRevisionJul.AutoSize = True
        Me.lblRevisionJul.Location = New System.Drawing.Point(516, 137)
        Me.lblRevisionJul.Name = "lblRevisionJul"
        Me.lblRevisionJul.Size = New System.Drawing.Size(22, 13)
        Me.lblRevisionJul.TabIndex = 2300
        Me.lblRevisionJul.Text = "Jul"
        '
        'lblBudgetJul
        '
        Me.lblBudgetJul.AutoSize = True
        Me.lblBudgetJul.Location = New System.Drawing.Point(516, 113)
        Me.lblBudgetJul.Name = "lblBudgetJul"
        Me.lblBudgetJul.Size = New System.Drawing.Size(22, 13)
        Me.lblBudgetJul.TabIndex = 2299
        Me.lblBudgetJul.Text = "Jul"
        '
        'lblPinkMarL
        '
        Me.lblPinkMarL.AutoSize = True
        Me.lblPinkMarL.Location = New System.Drawing.Point(516, 77)
        Me.lblPinkMarL.Name = "lblPinkMarL"
        Me.lblPinkMarL.Size = New System.Drawing.Size(28, 13)
        Me.lblPinkMarL.TabIndex = 2298
        Me.lblPinkMarL.Text = "Mar"
        '
        'lblRevisionMar
        '
        Me.lblRevisionMar.AutoSize = True
        Me.lblRevisionMar.Location = New System.Drawing.Point(516, 53)
        Me.lblRevisionMar.Name = "lblRevisionMar"
        Me.lblRevisionMar.Size = New System.Drawing.Size(28, 13)
        Me.lblRevisionMar.TabIndex = 2297
        Me.lblRevisionMar.Text = "Mar"
        '
        'lblBudgetMar
        '
        Me.lblBudgetMar.AutoSize = True
        Me.lblBudgetMar.Location = New System.Drawing.Point(516, 29)
        Me.lblBudgetMar.Name = "lblBudgetMar"
        Me.lblBudgetMar.Size = New System.Drawing.Size(32, 13)
        Me.lblBudgetMar.TabIndex = 2296
        Me.lblBudgetMar.Text = "Mar "
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(333, 32)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(11, 13)
        Me.Label41.TabIndex = 2295
        Me.Label41.Text = ":"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(333, 55)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(11, 13)
        Me.Label42.TabIndex = 2294
        Me.Label42.Text = ":"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(333, 80)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(11, 13)
        Me.Label43.TabIndex = 2293
        Me.Label43.Text = ":"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(333, 116)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(11, 13)
        Me.Label44.TabIndex = 2292
        Me.Label44.Text = ":"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(333, 139)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(11, 13)
        Me.Label45.TabIndex = 2291
        Me.Label45.Text = ":"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(333, 164)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(11, 13)
        Me.Label46.TabIndex = 2290
        Me.Label46.Text = ":"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(333, 198)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(11, 13)
        Me.Label47.TabIndex = 2289
        Me.Label47.Text = ":"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(333, 221)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(11, 13)
        Me.Label48.TabIndex = 2288
        Me.Label48.Text = ":"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(333, 246)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(11, 13)
        Me.Label49.TabIndex = 2287
        Me.Label49.Text = ":"
        '
        'lblPinkOctL
        '
        Me.lblPinkOctL.AutoSize = True
        Me.lblPinkOctL.Location = New System.Drawing.Point(290, 245)
        Me.lblPinkOctL.Name = "lblPinkOctL"
        Me.lblPinkOctL.Size = New System.Drawing.Size(26, 13)
        Me.lblPinkOctL.TabIndex = 2286
        Me.lblPinkOctL.Text = "Oct"
        '
        'lblRevisionOct
        '
        Me.lblRevisionOct.AutoSize = True
        Me.lblRevisionOct.Location = New System.Drawing.Point(290, 221)
        Me.lblRevisionOct.Name = "lblRevisionOct"
        Me.lblRevisionOct.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionOct.TabIndex = 2285
        Me.lblRevisionOct.Text = "Oct"
        '
        'lblBudgetOct
        '
        Me.lblBudgetOct.AutoSize = True
        Me.lblBudgetOct.Location = New System.Drawing.Point(290, 198)
        Me.lblBudgetOct.Name = "lblBudgetOct"
        Me.lblBudgetOct.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetOct.TabIndex = 2284
        Me.lblBudgetOct.Text = "Oct"
        '
        'lblPinkJunL
        '
        Me.lblPinkJunL.AutoSize = True
        Me.lblPinkJunL.Location = New System.Drawing.Point(290, 162)
        Me.lblPinkJunL.Name = "lblPinkJunL"
        Me.lblPinkJunL.Size = New System.Drawing.Size(26, 13)
        Me.lblPinkJunL.TabIndex = 2283
        Me.lblPinkJunL.Text = "Jun"
        '
        'lblRevisionJun
        '
        Me.lblRevisionJun.AutoSize = True
        Me.lblRevisionJun.Location = New System.Drawing.Point(290, 137)
        Me.lblRevisionJun.Name = "lblRevisionJun"
        Me.lblRevisionJun.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJun.TabIndex = 2282
        Me.lblRevisionJun.Text = "Jun"
        '
        'lblBudgetJun
        '
        Me.lblBudgetJun.AutoSize = True
        Me.lblBudgetJun.Location = New System.Drawing.Point(290, 113)
        Me.lblBudgetJun.Name = "lblBudgetJun"
        Me.lblBudgetJun.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJun.TabIndex = 2281
        Me.lblBudgetJun.Text = "Jun"
        '
        'lblPinkFebL
        '
        Me.lblPinkFebL.AutoSize = True
        Me.lblPinkFebL.Location = New System.Drawing.Point(290, 77)
        Me.lblPinkFebL.Name = "lblPinkFebL"
        Me.lblPinkFebL.Size = New System.Drawing.Size(27, 13)
        Me.lblPinkFebL.TabIndex = 2280
        Me.lblPinkFebL.Text = "Feb"
        '
        'lblRevisionFeb
        '
        Me.lblRevisionFeb.AutoSize = True
        Me.lblRevisionFeb.Location = New System.Drawing.Point(290, 53)
        Me.lblRevisionFeb.Name = "lblRevisionFeb"
        Me.lblRevisionFeb.Size = New System.Drawing.Size(27, 13)
        Me.lblRevisionFeb.TabIndex = 2279
        Me.lblRevisionFeb.Text = "Feb"
        '
        'lblBudgetFeb
        '
        Me.lblBudgetFeb.AutoSize = True
        Me.lblBudgetFeb.Location = New System.Drawing.Point(290, 29)
        Me.lblBudgetFeb.Name = "lblBudgetFeb"
        Me.lblBudgetFeb.Size = New System.Drawing.Size(27, 13)
        Me.lblBudgetFeb.TabIndex = 2278
        Me.lblBudgetFeb.Text = "Feb"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(120, 29)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(11, 13)
        Me.Label50.TabIndex = 2277
        Me.Label50.Text = ":"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(120, 52)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(11, 13)
        Me.Label51.TabIndex = 2276
        Me.Label51.Text = ":"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(120, 77)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(11, 13)
        Me.Label52.TabIndex = 2275
        Me.Label52.Text = ":"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(120, 113)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(11, 13)
        Me.Label53.TabIndex = 2274
        Me.Label53.Text = ":"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(120, 136)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(11, 13)
        Me.Label54.TabIndex = 2273
        Me.Label54.Text = ":"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(120, 161)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(11, 13)
        Me.Label55.TabIndex = 2272
        Me.Label55.Text = ":"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(120, 195)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(11, 13)
        Me.Label56.TabIndex = 2271
        Me.Label56.Text = ":"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(120, 218)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(11, 13)
        Me.Label57.TabIndex = 2270
        Me.Label57.Text = ":"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(120, 243)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(11, 13)
        Me.Label58.TabIndex = 2269
        Me.Label58.Text = ":"
        '
        'lblPinkSepL
        '
        Me.lblPinkSepL.AutoSize = True
        Me.lblPinkSepL.Location = New System.Drawing.Point(72, 242)
        Me.lblPinkSepL.Name = "lblPinkSepL"
        Me.lblPinkSepL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkSepL.TabIndex = 2268
        Me.lblPinkSepL.Text = "Sep"
        '
        'lblRevisionSep
        '
        Me.lblRevisionSep.AutoSize = True
        Me.lblRevisionSep.Location = New System.Drawing.Point(72, 218)
        Me.lblRevisionSep.Name = "lblRevisionSep"
        Me.lblRevisionSep.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionSep.TabIndex = 2267
        Me.lblRevisionSep.Text = "Sep"
        '
        'lblBudgetSep
        '
        Me.lblBudgetSep.AutoSize = True
        Me.lblBudgetSep.Location = New System.Drawing.Point(72, 195)
        Me.lblBudgetSep.Name = "lblBudgetSep"
        Me.lblBudgetSep.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetSep.TabIndex = 2266
        Me.lblBudgetSep.Text = "Sep"
        '
        'lblPinkMayL
        '
        Me.lblPinkMayL.AutoSize = True
        Me.lblPinkMayL.Location = New System.Drawing.Point(72, 159)
        Me.lblPinkMayL.Name = "lblPinkMayL"
        Me.lblPinkMayL.Size = New System.Drawing.Size(30, 13)
        Me.lblPinkMayL.TabIndex = 2265
        Me.lblPinkMayL.Text = "May"
        '
        'lblRevisionMay
        '
        Me.lblRevisionMay.AutoSize = True
        Me.lblRevisionMay.Location = New System.Drawing.Point(72, 134)
        Me.lblRevisionMay.Name = "lblRevisionMay"
        Me.lblRevisionMay.Size = New System.Drawing.Size(30, 13)
        Me.lblRevisionMay.TabIndex = 2264
        Me.lblRevisionMay.Text = "May"
        '
        'lblBudgetMay
        '
        Me.lblBudgetMay.AutoSize = True
        Me.lblBudgetMay.Location = New System.Drawing.Point(72, 110)
        Me.lblBudgetMay.Name = "lblBudgetMay"
        Me.lblBudgetMay.Size = New System.Drawing.Size(30, 13)
        Me.lblBudgetMay.TabIndex = 2263
        Me.lblBudgetMay.Text = "May"
        '
        'lblPinkJanL
        '
        Me.lblPinkJanL.AutoSize = True
        Me.lblPinkJanL.Location = New System.Drawing.Point(72, 74)
        Me.lblPinkJanL.Name = "lblPinkJanL"
        Me.lblPinkJanL.Size = New System.Drawing.Size(26, 13)
        Me.lblPinkJanL.TabIndex = 2262
        Me.lblPinkJanL.Text = "Jan"
        '
        'lblRevisionJan
        '
        Me.lblRevisionJan.AutoSize = True
        Me.lblRevisionJan.Location = New System.Drawing.Point(72, 50)
        Me.lblRevisionJan.Name = "lblRevisionJan"
        Me.lblRevisionJan.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJan.TabIndex = 2261
        Me.lblRevisionJan.Text = "Jan"
        '
        'lblBudgetJan
        '
        Me.lblBudgetJan.AutoSize = True
        Me.lblBudgetJan.Location = New System.Drawing.Point(72, 26)
        Me.lblBudgetJan.Name = "lblBudgetJan"
        Me.lblBudgetJan.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJan.TabIndex = 2260
        Me.lblBudgetJan.Text = "Jan"
        '
        'lblPinkDec
        '
        Me.lblPinkDec.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkDec.Location = New System.Drawing.Point(834, 242)
        Me.lblPinkDec.Name = "lblPinkDec"
        Me.lblPinkDec.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkDec.TabIndex = 84
        '
        'lblPinkNov
        '
        Me.lblPinkNov.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkNov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkNov.Location = New System.Drawing.Point(592, 242)
        Me.lblPinkNov.Name = "lblPinkNov"
        Me.lblPinkNov.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkNov.TabIndex = 83
        '
        'lblPinkAug
        '
        Me.lblPinkAug.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkAug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkAug.Location = New System.Drawing.Point(834, 159)
        Me.lblPinkAug.Name = "lblPinkAug"
        Me.lblPinkAug.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkAug.TabIndex = 82
        '
        'lblPinkJul
        '
        Me.lblPinkJul.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkJul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkJul.Location = New System.Drawing.Point(592, 159)
        Me.lblPinkJul.Name = "lblPinkJul"
        Me.lblPinkJul.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkJul.TabIndex = 81
        '
        'lblPinkApr
        '
        Me.lblPinkApr.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkApr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkApr.Location = New System.Drawing.Point(834, 74)
        Me.lblPinkApr.Name = "lblPinkApr"
        Me.lblPinkApr.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkApr.TabIndex = 80
        '
        'lblPinkMar
        '
        Me.lblPinkMar.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkMar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkMar.Location = New System.Drawing.Point(592, 74)
        Me.lblPinkMar.Name = "lblPinkMar"
        Me.lblPinkMar.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkMar.TabIndex = 79
        '
        'lblPinkOct
        '
        Me.lblPinkOct.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkOct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkOct.Location = New System.Drawing.Point(367, 242)
        Me.lblPinkOct.Name = "lblPinkOct"
        Me.lblPinkOct.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkOct.TabIndex = 78
        '
        'lblPinkJun
        '
        Me.lblPinkJun.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkJun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkJun.Location = New System.Drawing.Point(367, 159)
        Me.lblPinkJun.Name = "lblPinkJun"
        Me.lblPinkJun.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkJun.TabIndex = 77
        '
        'lblPinkFeb
        '
        Me.lblPinkFeb.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkFeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkFeb.Location = New System.Drawing.Point(367, 74)
        Me.lblPinkFeb.Name = "lblPinkFeb"
        Me.lblPinkFeb.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkFeb.TabIndex = 76
        '
        'lblPinkSep
        '
        Me.lblPinkSep.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkSep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkSep.Location = New System.Drawing.Point(145, 242)
        Me.lblPinkSep.Name = "lblPinkSep"
        Me.lblPinkSep.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkSep.TabIndex = 75
        '
        'lblPinkJan
        '
        Me.lblPinkJan.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkJan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkJan.Location = New System.Drawing.Point(145, 74)
        Me.lblPinkJan.Name = "lblPinkJan"
        Me.lblPinkJan.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkJan.TabIndex = 74
        '
        'lblPinkMay
        '
        Me.lblPinkMay.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkMay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkMay.Location = New System.Drawing.Point(145, 159)
        Me.lblPinkMay.Name = "lblPinkMay"
        Me.lblPinkMay.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkMay.TabIndex = 73
        '
        'txtRevDec
        '
        Me.txtRevDec.Location = New System.Drawing.Point(834, 218)
        Me.txtRevDec.Name = "txtRevDec"
        Me.txtRevDec.Size = New System.Drawing.Size(135, 21)
        Me.txtRevDec.TabIndex = 32
        '
        'txtBudgetDec
        '
        Me.txtBudgetDec.Location = New System.Drawing.Point(834, 195)
        Me.txtBudgetDec.Name = "txtBudgetDec"
        Me.txtBudgetDec.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetDec.TabIndex = 20
        '
        'txtRevAug
        '
        Me.txtRevAug.Location = New System.Drawing.Point(834, 134)
        Me.txtRevAug.Name = "txtRevAug"
        Me.txtRevAug.Size = New System.Drawing.Size(135, 21)
        Me.txtRevAug.TabIndex = 28
        '
        'txtBudgetAug
        '
        Me.txtBudgetAug.Location = New System.Drawing.Point(834, 110)
        Me.txtBudgetAug.Name = "txtBudgetAug"
        Me.txtBudgetAug.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetAug.TabIndex = 16
        '
        'txtRevApr
        '
        Me.txtRevApr.Location = New System.Drawing.Point(834, 50)
        Me.txtRevApr.Name = "txtRevApr"
        Me.txtRevApr.Size = New System.Drawing.Size(135, 21)
        Me.txtRevApr.TabIndex = 24
        '
        'txtBudgetApr
        '
        Me.txtBudgetApr.Location = New System.Drawing.Point(834, 26)
        Me.txtBudgetApr.Name = "txtBudgetApr"
        Me.txtBudgetApr.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetApr.TabIndex = 12
        '
        'txtRevNov
        '
        Me.txtRevNov.Location = New System.Drawing.Point(592, 218)
        Me.txtRevNov.Name = "txtRevNov"
        Me.txtRevNov.Size = New System.Drawing.Size(135, 21)
        Me.txtRevNov.TabIndex = 31
        '
        'txtBudgetNov
        '
        Me.txtBudgetNov.Location = New System.Drawing.Point(592, 195)
        Me.txtBudgetNov.Name = "txtBudgetNov"
        Me.txtBudgetNov.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetNov.TabIndex = 19
        '
        'txtRevJul
        '
        Me.txtRevJul.Location = New System.Drawing.Point(592, 134)
        Me.txtRevJul.Name = "txtRevJul"
        Me.txtRevJul.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJul.TabIndex = 27
        '
        'txtBudgetJul
        '
        Me.txtBudgetJul.Location = New System.Drawing.Point(592, 110)
        Me.txtBudgetJul.Name = "txtBudgetJul"
        Me.txtBudgetJul.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetJul.TabIndex = 15
        '
        'txtRevMar
        '
        Me.txtRevMar.Location = New System.Drawing.Point(592, 50)
        Me.txtRevMar.Name = "txtRevMar"
        Me.txtRevMar.Size = New System.Drawing.Size(135, 21)
        Me.txtRevMar.TabIndex = 2223
        '
        'txtBudgetMar
        '
        Me.txtBudgetMar.Location = New System.Drawing.Point(592, 26)
        Me.txtBudgetMar.Name = "txtBudgetMar"
        Me.txtBudgetMar.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetMar.TabIndex = 11
        '
        'txtRevOct
        '
        Me.txtRevOct.Location = New System.Drawing.Point(367, 218)
        Me.txtRevOct.Name = "txtRevOct"
        Me.txtRevOct.Size = New System.Drawing.Size(135, 21)
        Me.txtRevOct.TabIndex = 30
        '
        'txtBudgetOct
        '
        Me.txtBudgetOct.Location = New System.Drawing.Point(367, 195)
        Me.txtBudgetOct.Name = "txtBudgetOct"
        Me.txtBudgetOct.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetOct.TabIndex = 18
        '
        'txtRevJun
        '
        Me.txtRevJun.Location = New System.Drawing.Point(367, 134)
        Me.txtRevJun.Name = "txtRevJun"
        Me.txtRevJun.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJun.TabIndex = 26
        '
        'txtBudgetJun
        '
        Me.txtBudgetJun.Location = New System.Drawing.Point(367, 110)
        Me.txtBudgetJun.Name = "txtBudgetJun"
        Me.txtBudgetJun.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetJun.TabIndex = 14
        '
        'txtRevFeb
        '
        Me.txtRevFeb.Location = New System.Drawing.Point(367, 50)
        Me.txtRevFeb.Name = "txtRevFeb"
        Me.txtRevFeb.Size = New System.Drawing.Size(135, 21)
        Me.txtRevFeb.TabIndex = 21
        '
        'txtBudgetFeb
        '
        Me.txtBudgetFeb.Location = New System.Drawing.Point(367, 26)
        Me.txtBudgetFeb.Name = "txtBudgetFeb"
        Me.txtBudgetFeb.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetFeb.TabIndex = 10
        '
        'txtRevSep
        '
        Me.txtRevSep.Location = New System.Drawing.Point(145, 218)
        Me.txtRevSep.Name = "txtRevSep"
        Me.txtRevSep.Size = New System.Drawing.Size(135, 21)
        Me.txtRevSep.TabIndex = 29
        '
        'txtBudgetSep
        '
        Me.txtBudgetSep.Location = New System.Drawing.Point(145, 195)
        Me.txtBudgetSep.Name = "txtBudgetSep"
        Me.txtBudgetSep.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetSep.TabIndex = 17
        '
        'txtRevMay
        '
        Me.txtRevMay.Location = New System.Drawing.Point(145, 134)
        Me.txtRevMay.Name = "txtRevMay"
        Me.txtRevMay.Size = New System.Drawing.Size(135, 21)
        Me.txtRevMay.TabIndex = 25
        '
        'txtBudgetMay
        '
        Me.txtBudgetMay.Location = New System.Drawing.Point(145, 110)
        Me.txtBudgetMay.Name = "txtBudgetMay"
        Me.txtBudgetMay.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetMay.TabIndex = 13
        '
        'txtRevJan
        '
        Me.txtRevJan.Location = New System.Drawing.Point(145, 50)
        Me.txtRevJan.Name = "txtRevJan"
        Me.txtRevJan.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJan.TabIndex = 21
        '
        'txtBudgetJan
        '
        Me.txtBudgetJan.Location = New System.Drawing.Point(145, 26)
        Me.txtBudgetJan.Name = "txtBudgetJan"
        Me.txtBudgetJan.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetJan.TabIndex = 9
        '
        'lblRPM3
        '
        Me.lblRPM3.AutoSize = True
        Me.lblRPM3.Location = New System.Drawing.Point(875, 10)
        Me.lblRPM3.Name = "lblRPM3"
        Me.lblRPM3.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM3.TabIndex = 48
        Me.lblRPM3.Text = "RPM"
        '
        'lblRPM2
        '
        Me.lblRPM2.AutoSize = True
        Me.lblRPM2.Location = New System.Drawing.Point(627, 10)
        Me.lblRPM2.Name = "lblRPM2"
        Me.lblRPM2.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM2.TabIndex = 47
        Me.lblRPM2.Text = "RPM"
        '
        'lblRPM1
        '
        Me.lblRPM1.AutoSize = True
        Me.lblRPM1.Location = New System.Drawing.Point(403, 10)
        Me.lblRPM1.Name = "lblRPM1"
        Me.lblRPM1.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM1.TabIndex = 46
        Me.lblRPM1.Text = "RPM"
        '
        'lblRPM
        '
        Me.lblRPM.AutoSize = True
        Me.lblRPM.Location = New System.Drawing.Point(175, 10)
        Me.lblRPM.Name = "lblRPM"
        Me.lblRPM.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM.TabIndex = 45
        Me.lblRPM.Text = "RPM"
        '
        'lblPinks
        '
        Me.lblPinks.AutoSize = True
        Me.lblPinks.Location = New System.Drawing.Point(6, 242)
        Me.lblPinks.Name = "lblPinks"
        Me.lblPinks.Size = New System.Drawing.Size(56, 13)
        Me.lblPinks.TabIndex = 8
        Me.lblPinks.Text = "Pink Slip"
        '
        'lblRevisions
        '
        Me.lblRevisions.AutoSize = True
        Me.lblRevisions.Location = New System.Drawing.Point(6, 218)
        Me.lblRevisions.Name = "lblRevisions"
        Me.lblRevisions.Size = New System.Drawing.Size(55, 13)
        Me.lblRevisions.TabIndex = 7
        Me.lblRevisions.Text = "Revision"
        '
        'lblBudgets
        '
        Me.lblBudgets.AutoSize = True
        Me.lblBudgets.Location = New System.Drawing.Point(6, 195)
        Me.lblBudgets.Name = "lblBudgets"
        Me.lblBudgets.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgets.TabIndex = 6
        Me.lblBudgets.Text = "Budget"
        '
        'lblPinkSlipL
        '
        Me.lblPinkSlipL.AutoSize = True
        Me.lblPinkSlipL.Location = New System.Drawing.Point(6, 159)
        Me.lblPinkSlipL.Name = "lblPinkSlipL"
        Me.lblPinkSlipL.Size = New System.Drawing.Size(56, 13)
        Me.lblPinkSlipL.TabIndex = 5
        Me.lblPinkSlipL.Text = "Pink Slip"
        '
        'lblRevisionL
        '
        Me.lblRevisionL.AutoSize = True
        Me.lblRevisionL.Location = New System.Drawing.Point(6, 134)
        Me.lblRevisionL.Name = "lblRevisionL"
        Me.lblRevisionL.Size = New System.Drawing.Size(55, 13)
        Me.lblRevisionL.TabIndex = 4
        Me.lblRevisionL.Text = "Revision"
        '
        'lblBudgetL
        '
        Me.lblBudgetL.AutoSize = True
        Me.lblBudgetL.Location = New System.Drawing.Point(6, 110)
        Me.lblBudgetL.Name = "lblBudgetL"
        Me.lblBudgetL.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetL.TabIndex = 3
        Me.lblBudgetL.Text = "Budget"
        '
        'lblPinkSlip
        '
        Me.lblPinkSlip.AutoSize = True
        Me.lblPinkSlip.Location = New System.Drawing.Point(6, 74)
        Me.lblPinkSlip.Name = "lblPinkSlip"
        Me.lblPinkSlip.Size = New System.Drawing.Size(56, 13)
        Me.lblPinkSlip.TabIndex = 2
        Me.lblPinkSlip.Text = "Pink Slip"
        '
        'lblRevision
        '
        Me.lblRevision.AutoSize = True
        Me.lblRevision.Location = New System.Drawing.Point(6, 50)
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Size = New System.Drawing.Size(55, 13)
        Me.lblRevision.TabIndex = 1
        Me.lblRevision.Text = "Revision"
        '
        'lblBudget
        '
        Me.lblBudget.AutoSize = True
        Me.lblBudget.Location = New System.Drawing.Point(6, 26)
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.Size = New System.Drawing.Size(47, 13)
        Me.lblBudget.TabIndex = 0
        Me.lblBudget.Text = "Budget"
        '
        'grpBudgetYear
        '
        Me.grpBudgetYear.AutoSize = True
        Me.grpBudgetYear.Controls.Add(Me.Label18)
        Me.grpBudgetYear.Controls.Add(Me.Label17)
        Me.grpBudgetYear.Controls.Add(Me.Label16)
        Me.grpBudgetYear.Controls.Add(Me.lblOldAccCode)
        Me.grpBudgetYear.Controls.Add(Me.txtPercentage)
        Me.grpBudgetYear.Controls.Add(Me.Label8)
        Me.grpBudgetYear.Controls.Add(Me.lblPercentage)
        Me.grpBudgetYear.Controls.Add(Me.txtMonth)
        Me.grpBudgetYear.Controls.Add(Me.Label10)
        Me.grpBudgetYear.Controls.Add(Me.lblMonth)
        Me.grpBudgetYear.Controls.Add(Me.txtDay)
        Me.grpBudgetYear.Controls.Add(Me.Label12)
        Me.grpBudgetYear.Controls.Add(Me.lblDay)
        Me.grpBudgetYear.Controls.Add(Me.txtUnit)
        Me.grpBudgetYear.Controls.Add(Me.Label7)
        Me.grpBudgetYear.Controls.Add(Me.lblUnit)
        Me.grpBudgetYear.Controls.Add(Me.txtQty)
        Me.grpBudgetYear.Controls.Add(Me.Label6)
        Me.grpBudgetYear.Controls.Add(Me.lblQty)
        Me.grpBudgetYear.Controls.Add(Me.txtSubDesc)
        Me.grpBudgetYear.Controls.Add(Me.Label1)
        Me.grpBudgetYear.Controls.Add(Me.lblSubDesc)
        Me.grpBudgetYear.Controls.Add(Me.lblOldCOACode)
        Me.grpBudgetYear.Controls.Add(Me.lblStatus)
        Me.grpBudgetYear.Controls.Add(Me.lblStatusL)
        Me.grpBudgetYear.Controls.Add(Me.lblVersionNo)
        Me.grpBudgetYear.Controls.Add(Me.lblVersionNoL)
        Me.grpBudgetYear.Controls.Add(Me.btnDistribute)
        Me.grpBudgetYear.Controls.Add(Me.lblCOADescp)
        Me.grpBudgetYear.Controls.Add(Me.btnSearchAccountCode)
        Me.grpBudgetYear.Controls.Add(Me.Label5)
        Me.grpBudgetYear.Controls.Add(Me.txtTotalPrice)
        Me.grpBudgetYear.Controls.Add(Me.txtCOACode)
        Me.grpBudgetYear.Controls.Add(Me.Label4)
        Me.grpBudgetYear.Controls.Add(Me.Label3)
        Me.grpBudgetYear.Controls.Add(Me.Label2)
        Me.grpBudgetYear.Controls.Add(Me.lblBudgetYear)
        Me.grpBudgetYear.Controls.Add(Me.lblTotalPrice)
        Me.grpBudgetYear.Controls.Add(Me.lblCOA)
        Me.grpBudgetYear.Controls.Add(Me.lblBudgetyearL)
        Me.grpBudgetYear.Location = New System.Drawing.Point(6, 2)
        Me.grpBudgetYear.Name = "grpBudgetYear"
        Me.grpBudgetYear.Size = New System.Drawing.Size(1032, 191)
        Me.grpBudgetYear.TabIndex = 4
        Me.grpBudgetYear.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(902, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 214
        Me.Label18.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(902, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 13)
        Me.Label17.TabIndex = 213
        Me.Label17.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(137, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 13)
        Me.Label16.TabIndex = 212
        Me.Label16.Text = ":"
        '
        'lblOldAccCode
        '
        Me.lblOldAccCode.AutoSize = True
        Me.lblOldAccCode.Location = New System.Drawing.Point(9, 63)
        Me.lblOldAccCode.Name = "lblOldAccCode"
        Me.lblOldAccCode.Size = New System.Drawing.Size(90, 13)
        Me.lblOldAccCode.TabIndex = 211
        Me.lblOldAccCode.Text = "Old COA Code"
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(627, 93)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(135, 21)
        Me.txtPercentage.TabIndex = 209
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(607, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 13)
        Me.Label8.TabIndex = 208
        Me.Label8.Text = ":"
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.Location = New System.Drawing.Point(532, 93)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(19, 13)
        Me.lblPercentage.TabIndex = 207
        Me.lblPercentage.Text = "%"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(627, 63)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(135, 21)
        Me.txtMonth.TabIndex = 206
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(607, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 13)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(532, 63)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 204
        Me.lblMonth.Text = "Month"
        '
        'txtDay
        '
        Me.txtDay.Location = New System.Drawing.Point(627, 37)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(135, 21)
        Me.txtDay.TabIndex = 203
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(607, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 13)
        Me.Label12.TabIndex = 202
        Me.Label12.Text = ":"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(532, 37)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(30, 13)
        Me.lblDay.TabIndex = 201
        Me.lblDay.Text = "Day"
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(154, 122)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(135, 21)
        Me.txtUnit.TabIndex = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(137, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 13)
        Me.Label7.TabIndex = 199
        Me.Label7.Text = ":"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(5, 118)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(29, 13)
        Me.lblUnit.TabIndex = 198
        Me.lblUnit.Text = "Unit"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(154, 150)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(135, 21)
        Me.txtQty.TabIndex = 197
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(137, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 13)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = ":"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(5, 146)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(27, 13)
        Me.lblQty.TabIndex = 195
        Me.lblQty.Text = "Qty"
        '
        'txtSubDesc
        '
        Me.txtSubDesc.Location = New System.Drawing.Point(154, 93)
        Me.txtSubDesc.Name = "txtSubDesc"
        Me.txtSubDesc.Size = New System.Drawing.Size(135, 21)
        Me.txtSubDesc.TabIndex = 194
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(137, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = ":"
        '
        'lblSubDesc
        '
        Me.lblSubDesc.AutoSize = True
        Me.lblSubDesc.Location = New System.Drawing.Point(5, 93)
        Me.lblSubDesc.Name = "lblSubDesc"
        Me.lblSubDesc.Size = New System.Drawing.Size(61, 13)
        Me.lblSubDesc.TabIndex = 192
        Me.lblSubDesc.Text = "Sub Desc"
        '
        'lblOldCOACode
        '
        Me.lblOldCOACode.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblOldCOACode.Location = New System.Drawing.Point(154, 67)
        Me.lblOldCOACode.Name = "lblOldCOACode"
        Me.lblOldCOACode.Size = New System.Drawing.Size(118, 15)
        Me.lblOldCOACode.TabIndex = 191
        Me.lblOldCOACode.Text = "Old COACode"
        Me.lblOldCOACode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(920, 69)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 20)
        Me.lblStatus.TabIndex = 147
        '
        'lblStatusL
        '
        Me.lblStatusL.AutoSize = True
        Me.lblStatusL.ForeColor = System.Drawing.Color.Black
        Me.lblStatusL.Location = New System.Drawing.Point(798, 70)
        Me.lblStatusL.Name = "lblStatusL"
        Me.lblStatusL.Size = New System.Drawing.Size(75, 13)
        Me.lblStatusL.TabIndex = 146
        Me.lblStatusL.Text = "Status        "
        '
        'lblVersionNo
        '
        Me.lblVersionNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVersionNo.Location = New System.Drawing.Point(920, 43)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(83, 21)
        Me.lblVersionNo.TabIndex = 143
        '
        'lblVersionNoL
        '
        Me.lblVersionNoL.AutoSize = True
        Me.lblVersionNoL.ForeColor = System.Drawing.Color.Black
        Me.lblVersionNoL.Location = New System.Drawing.Point(798, 44)
        Me.lblVersionNoL.Name = "lblVersionNoL"
        Me.lblVersionNoL.Size = New System.Drawing.Size(73, 13)
        Me.lblVersionNoL.TabIndex = 142
        Me.lblVersionNoL.Text = "Version No "
        '
        'btnDistribute
        '
        Me.btnDistribute.Location = New System.Drawing.Point(838, 13)
        Me.btnDistribute.Name = "btnDistribute"
        Me.btnDistribute.Size = New System.Drawing.Size(165, 23)
        Me.btnDistribute.TabIndex = 7
        Me.btnDistribute.Text = "Distribute to 12 months"
        Me.btnDistribute.UseVisualStyleBackColor = True
        '
        'lblCOADescp
        '
        Me.lblCOADescp.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescp.Location = New System.Drawing.Point(336, 31)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(152, 49)
        Me.lblCOADescp.TabIndex = 141
        Me.lblCOADescp.Text = "COA Desc"
        '
        'btnSearchAccountCode
        '
        Me.btnSearchAccountCode.BackgroundImage = CType(resources.GetObject("btnSearchAccountCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchAccountCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchAccountCode.FlatAppearance.BorderSize = 0
        Me.btnSearchAccountCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchAccountCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchAccountCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAccountCode.Location = New System.Drawing.Point(295, 33)
        Me.btnSearchAccountCode.Name = "btnSearchAccountCode"
        Me.btnSearchAccountCode.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchAccountCode.TabIndex = 140
        Me.btnSearchAccountCode.TabStop = False
        Me.btnSearchAccountCode.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(767, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "IDR"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.Location = New System.Drawing.Point(627, 11)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.Size = New System.Drawing.Size(135, 21)
        Me.txtTotalPrice.TabIndex = 6
        '
        'txtCOACode
        '
        Me.txtCOACode.Location = New System.Drawing.Point(154, 37)
        Me.txtCOACode.Name = "txtCOACode"
        Me.txtCOACode.Size = New System.Drawing.Size(135, 21)
        Me.txtCOACode.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(607, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = ":"
        '
        'lblBudgetYear
        '
        Me.lblBudgetYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYear.Location = New System.Drawing.Point(154, 11)
        Me.lblBudgetYear.Name = "lblBudgetYear"
        Me.lblBudgetYear.Size = New System.Drawing.Size(135, 21)
        Me.lblBudgetYear.TabIndex = 4
        '
        'lblTotalPrice
        '
        Me.lblTotalPrice.AutoSize = True
        Me.lblTotalPrice.ForeColor = System.Drawing.Color.Red
        Me.lblTotalPrice.Location = New System.Drawing.Point(532, 11)
        Me.lblTotalPrice.Name = "lblTotalPrice"
        Me.lblTotalPrice.Size = New System.Drawing.Size(67, 13)
        Me.lblTotalPrice.TabIndex = 2
        Me.lblTotalPrice.Text = "Total Price"
        '
        'lblCOA
        '
        Me.lblCOA.AutoSize = True
        Me.lblCOA.ForeColor = System.Drawing.Color.Red
        Me.lblCOA.Location = New System.Drawing.Point(9, 37)
        Me.lblCOA.Name = "lblCOA"
        Me.lblCOA.Size = New System.Drawing.Size(33, 13)
        Me.lblCOA.TabIndex = 1
        Me.lblCOA.Text = "COA"
        '
        'lblBudgetyearL
        '
        Me.lblBudgetyearL.AutoSize = True
        Me.lblBudgetyearL.Location = New System.Drawing.Point(9, 11)
        Me.lblBudgetyearL.Name = "lblBudgetyearL"
        Me.lblBudgetyearL.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetyearL.TabIndex = 0
        Me.lblBudgetyearL.Text = "Budget Year"
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(1081, 694)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'SalaryAndWagesAdministrationFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1117, 698)
        Me.Controls.Add(Me.tbSalaryAndWagesAdminstration)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SalaryAndWagesAdministrationFrm"
        Me.Text = "SalaryAndWagesAdministrationFrm"
        Me.tbSalaryAndWagesAdminstration.ResumeLayout(False)
        Me.tbSalaryAndWages.ResumeLayout(False)
        Me.tbSalaryAndWages.PerformLayout()
        Me.GrpGrid.ResumeLayout(False)
        CType(Me.dgAdminExpand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMonths.ResumeLayout(False)
        Me.grpMonths.PerformLayout()
        Me.grpBudgetYear.ResumeLayout(False)
        Me.grpBudgetYear.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbSalaryAndWagesAdminstration As System.Windows.Forms.TabControl
    Friend WithEvents tbSalaryAndWages As System.Windows.Forms.TabPage
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GrpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgAdminExpand As System.Windows.Forms.DataGridView
    Friend WithEvents AdminExpendID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BDGYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBudgetTotal As System.Windows.Forms.Label
    Friend WithEvents lblBudgetTotalL As System.Windows.Forms.Label
    Friend WithEvents grpMonths As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblPinkDecL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionDec As System.Windows.Forms.Label
    Friend WithEvents lblBudgetDec As System.Windows.Forms.Label
    Friend WithEvents lblPinkAugL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionAug As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAug As System.Windows.Forms.Label
    Friend WithEvents lblPinkAprL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionApr As System.Windows.Forms.Label
    Friend WithEvents lblBudgetApr As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblPinkNovL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionNov As System.Windows.Forms.Label
    Friend WithEvents lblBudgetNov As System.Windows.Forms.Label
    Friend WithEvents lblPinkJulL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJul As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJul As System.Windows.Forms.Label
    Friend WithEvents lblPinkMarL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionMar As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMar As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblPinkOctL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionOct As System.Windows.Forms.Label
    Friend WithEvents lblBudgetOct As System.Windows.Forms.Label
    Friend WithEvents lblPinkJunL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJun As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJun As System.Windows.Forms.Label
    Friend WithEvents lblPinkFebL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionFeb As System.Windows.Forms.Label
    Friend WithEvents lblBudgetFeb As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents lblPinkSepL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionSep As System.Windows.Forms.Label
    Friend WithEvents lblBudgetSep As System.Windows.Forms.Label
    Friend WithEvents lblPinkMayL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionMay As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMay As System.Windows.Forms.Label
    Friend WithEvents lblPinkJanL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJan As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJan As System.Windows.Forms.Label
    Friend WithEvents lblPinkDec As System.Windows.Forms.Label
    Friend WithEvents lblPinkNov As System.Windows.Forms.Label
    Friend WithEvents lblPinkAug As System.Windows.Forms.Label
    Friend WithEvents lblPinkJul As System.Windows.Forms.Label
    Friend WithEvents lblPinkApr As System.Windows.Forms.Label
    Friend WithEvents lblPinkMar As System.Windows.Forms.Label
    Friend WithEvents lblPinkOct As System.Windows.Forms.Label
    Friend WithEvents lblPinkJun As System.Windows.Forms.Label
    Friend WithEvents lblPinkFeb As System.Windows.Forms.Label
    Friend WithEvents lblPinkSep As System.Windows.Forms.Label
    Friend WithEvents lblPinkJan As System.Windows.Forms.Label
    Friend WithEvents lblPinkMay As System.Windows.Forms.Label
    Friend WithEvents txtRevDec As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetDec As System.Windows.Forms.TextBox
    Friend WithEvents txtRevAug As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetAug As System.Windows.Forms.TextBox
    Friend WithEvents txtRevApr As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetApr As System.Windows.Forms.TextBox
    Friend WithEvents txtRevNov As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetNov As System.Windows.Forms.TextBox
    Friend WithEvents txtRevJul As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJul As System.Windows.Forms.TextBox
    Friend WithEvents txtRevMar As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMar As System.Windows.Forms.TextBox
    Friend WithEvents txtRevOct As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetOct As System.Windows.Forms.TextBox
    Friend WithEvents txtRevJun As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJun As System.Windows.Forms.TextBox
    Friend WithEvents txtRevFeb As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetFeb As System.Windows.Forms.TextBox
    Friend WithEvents txtRevSep As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetSep As System.Windows.Forms.TextBox
    Friend WithEvents txtRevMay As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMay As System.Windows.Forms.TextBox
    Friend WithEvents txtRevJan As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJan As System.Windows.Forms.TextBox
    Friend WithEvents lblRPM3 As System.Windows.Forms.Label
    Friend WithEvents lblRPM2 As System.Windows.Forms.Label
    Friend WithEvents lblRPM1 As System.Windows.Forms.Label
    Friend WithEvents lblRPM As System.Windows.Forms.Label
    Friend WithEvents lblPinks As System.Windows.Forms.Label
    Friend WithEvents lblRevisions As System.Windows.Forms.Label
    Friend WithEvents lblBudgets As System.Windows.Forms.Label
    Friend WithEvents lblPinkSlipL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionL As System.Windows.Forms.Label
    Friend WithEvents lblBudgetL As System.Windows.Forms.Label
    Friend WithEvents lblPinkSlip As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents grpBudgetYear As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblOldAccCode As System.Windows.Forms.Label
    Friend WithEvents txtPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtSubDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSubDesc As System.Windows.Forms.Label
    Friend WithEvents lblOldCOACode As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatusL As System.Windows.Forms.Label
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblVersionNoL As System.Windows.Forms.Label
    Friend WithEvents btnDistribute As System.Windows.Forms.Button
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchAccountCode As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtCOACode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYear As System.Windows.Forms.Label
    Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
    Friend WithEvents lblCOA As System.Windows.Forms.Label
    Friend WithEvents lblBudgetyearL As System.Windows.Forms.Label
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents btnPrintSummary As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
