Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient
Public Class NonStockIPRFrm

    Public lStockCategory As String = String.Empty
    Public Shared lStockCategoryID As String = String.Empty
    Public Shared lStockCategoryCode As String = String.Empty
    Public lStockCode As String = String.Empty
    Public lStockDesc As String = String.Empty
    Public lUnitprice As String = String.Empty
    Public lUnit As String = String.Empty
    Public lStockID As String = String.Empty
    Public lSTIPRID As String = String.Empty
    Public gvlSTIPRID As String = String.Empty
    Public gvlSTIPRDetID As String = String.Empty
    Public lSTIPRDetID As String = String.Empty
    Public lclassification As String = String.Empty
    Public DTFlag As Boolean = False
    Private AddFlag As Boolean = True
    Public Shared StrFrmName As String = String.Empty

    Public lModifiedOn As String = String.Empty
    Public strMenuID As String = String.Empty
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")

    Dim dtIPRDetails As New DataTable("todgvIPRDetails")
    Dim columnIPRDetails As DataColumn
    Dim rowIPRDetails As DataRow
    Shadows mdiparent As New MDIParent
    Public psIPRUsageCOAID As String = String.Empty
    Dim lsVDExpenditureAG As String = String.Empty
    Public btnCategoryClickFlag = False
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NonStockIPRFrm))

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Public Shared psNonIPRID As String = String.Empty
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NonStockIPRFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NonStockIPRFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            If mdiparent.strMenuID = "M164" Then
                tcIPR.TabPages("tbIPR").Text = rm.GetString("tcIPR.TabPages(tbIPR).Text")
                tcIPR.TabPages("tbView").Text = rm.GetString("tcIPR.TabPages(tbView).Text")
            Else
                tcIPR.TabPages("tbIPR").Text = rm.GetString("tcIPR.TabPages(tbIPR).Text")
                btnConfirm.Text = rm.GetString("btnConfirm.Text")
                gbApproval.Text = rm.GetString(" gbApproval.Text")
                lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
                lblApprovalStatus.Text = rm.GetString("lblApprovalStatus.Text")
            End If
            lblUsageCOACode.Text = rm.GetString("lblUsageCOACode.Text")
            lblIPRDate.Text = rm.GetString("lblIPRDate.Text")
            lblCategory.Text = rm.GetString("lblCategory.Text")
            lblStockCode.Text = rm.GetString("lblStockCode.Text")
            lblRequestedQty.Text = rm.GetString("lblRequestedQty.Text")
            lblUnit.Text = rm.GetString("lblUnit.Text")
            lblIPRNo.Text = rm.GetString("lblIPRNo.Text")
            lblCategcode.Text = rm.GetString("lblCategcode.Text")
            lblStockDes.Text = rm.GetString("lblStockDes.Text")
            lblUnitPrice.Text = rm.GetString("lblUnitPrice.Text")
            lblTotalPrice.Text = rm.GetString("lblTotalPrice.Text")
            'lblAvailableQty.Text = rm.GetString("lblAvailableQty.Text")
            lblDeliveredTo.Text = rm.GetString("lblDeliveredTo.Text")
            lblClassification.Text = rm.GetString("lblClassification.Text")
            lblRequiredFor.Text = rm.GetString("lblRequiredFor.Text")
            lblRequiredDate.Text = rm.GetString("lblRequiredDate.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblUsageCOADesc.Text = rm.GetString("lblUsageCOADesc.Text")
            lblStatus.Text = rm.GetString("lblStatus.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            gbIPRAdd.Text = rm.GetString("gbIPRAdd.Text")
            gbEnquipmentData.Text = rm.GetString("gbEnquipmentData.Text")
            lblMakeandModel.Text = rm.GetString("lblMakeandModel.Text")
            lblChassisSerialNo.Text = rm.GetString("lblChassisSerialNo.Text")
            lblEngine.Text = rm.GetString("lblEngine.Text")
            lblFixedAssetNo.Text = rm.GetString("lblFixedAssetNo.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            pnlCategorySearch.Text = rm.GetString("pnlCategorySearch.Text")
            lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
            lblviewIPRDate.Text = rm.GetString("lblviewIPRDate.Text")
            lblviewIPRno.Text = rm.GetString("lblviewIPRno.Text")
            lblviewCategory.Text = rm.GetString("lblviewCategory.Text")
            lblviewClassification.Text = rm.GetString("lblviewClassification.Text")
            lblviewRequiredfor.Text = rm.GetString("lblviewRequiredfor.Text")
            lblviewDeliveredto.Text = rm.GetString("lblviewDeliveredto.Text")
            lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")
            pnlCategorySearch.Text = rm.GetString("pnlCategorySearch.Text")
            lblPartNo.Text = rm.GetString("lblPartNo.text")
            'lblMinQty.Text = rm.GetString("lblMinQty.Text")
            gbSingleEntry.Text = rm.GetString("gbSingleEntry.Text")
            gbMultientry.Text = rm.GetString("gbMultientry.Text")
            'gbEnquipmentData.Text = rm.GetString("gbEnquipmentData.Text")
            'gbIPRAdd.Text	Detail IPR
            dgvNonStockIPRDetails.Columns("dgclStockCode").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclStockCode).HeaderText")
            dgvNonStockIPRDetails.Columns("dgclStockDesc").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclStockDesc).HeaderText")
            dgvNonStockIPRDetails.Columns("dgclPartNo").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclPartNo).HeaderText")
            'dgvNonStockIPRDetails.Columns("dgclAvailableQty").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclAvailableQty).HeaderText")
            'dgvNonStockIPRDetails.Columns("dgclMinimumQty").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclMinimumQty).HeaderText")
            dgvNonStockIPRDetails.Columns("dgclunit").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclunit).HeaderText")
            dgvNonStockIPRDetails.Columns("dgclUnitPrice").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclUnitPrice).HeaderText")
            dgvNonStockIPRDetails.Columns("dgclRequestedQty").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclRequestedQty).HeaderText")
            dgvNonStockIPRDetails.Columns("dgclTotalPrice").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclTotalPrice).HeaderText")

            dgvIRPView.Columns("gvIPRNo").HeaderText = rm.GetString("dgvIRPView.Columns(gvIPRNo).HeaderText")
            dgvIRPView.Columns("gvIPRDate").HeaderText = rm.GetString("dgvIRPView.Columns(gvIPRDate).HeaderText")
            dgvIRPView.Columns("gvSTCategory").HeaderText = rm.GetString("dgvIRPView.Columns(gvSTCategory).HeaderText")
            dgvIRPView.Columns("gvRequiredfor").HeaderText = rm.GetString("dgvIRPView.Columns(gvRequiredfor).HeaderText")
            dgvIRPView.Columns("gvlRequiredDate").HeaderText = rm.GetString("dgvIRPView.Columns(gvlRequiredDate).HeaderText")
            'dgvIRPView.Columns("gvD").HeaderText = rm.GetString("dgvIRPView.Columns(gvD).HeaderText")
            dgvIRPView.Columns("gvDeliveredto").HeaderText = rm.GetString("dgvIRPView.Columns(gvDeliveredto).HeaderText")
            dgvIRPView.Columns("gvClassification").HeaderText = rm.GetString("dgvIRPView.Columns(gvClassification).HeaderText")
            dgvIRPView.Columns("gvMainStatus").HeaderText = rm.GetString("dgvIRPView.Columns(gvMainStatus).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NonStockIPRFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        If mdiparent.strMenuID = "M164" Then

            txtCategory.Enabled = True
            dtpIPRDate.Format = DateTimePickerFormat.Custom
            dtpIPRDate.CustomFormat = "dd/MM/yyyy"
            dtpviewIPRDate.Format = DateTimePickerFormat.Custom
            dtpviewIPRDate.CustomFormat = "dd/MM/yyyy"
            dtpRequiredDate.Format = DateTimePickerFormat.Custom
            dtpRequiredDate.CustomFormat = "dd/MM/yyyy"
            GlobalBOL.SetDateTimePicker(Me.dtpIPRDate)
            GlobalBOL.SetDateTimePicker(Me.dtpviewIPRDate)
            'GlobalBOL.SetDateTimePicker(Me.dtpRequiredDate)
            lblStockDesc.Visible = False
            lblCategoryCode.Visible = False
            lblTotalValue.Visible = False
            lblUnitValue.Visible = False
            lblUnitPriceValue.Visible = False
            lblUnitValue.Visible = False
            'lblAvailableValue.Visible = False
            lblPartnovalue.Visible = False
            ' lblMinQtyValue.Visible = False
            'toGetIPRNo()
            Enable_SingleEntry()
            cmbStatus.Text = "OPEN"
            GridIPRViewBind()
            tcIPR.SelectedTab = tbView
            'SetUICulture(GlobalPPT.strLang)
            gbApproval.Visible = False
            btnConfirm.Visible = False
            txtCategory.Focus()
            btnSearchCategory.Enabled = True
            gbAddSingEntry.Visible = True
            bind_cmbClassification()
            If lblStatusDesc.Text = "REJECTED" Then
                lblRejectReason.Visible = True
                lblcolon21.Visible = True
                lblRejectreasondesc.Visible = True
            End If
        ElseIf strMenuID = "M12" Then
            toloadIPR_inApproval()
            dtpIPRDate.Format = DateTimePickerFormat.Custom
            dtpIPRDate.CustomFormat = "dd/MM/yyyy"
            dtpRequiredDate.Format = DateTimePickerFormat.Custom
            dtpRequiredDate.CustomFormat = "dd/MM/yyyy"
            gbApproval.Visible = True
            lblRejectedReason.Visible = False
            txtRejectedReason.Visible = False
            lblColon15.Visible = False
            lblStockDesc.Visible = False
            lblTotalValue.Visible = False
            lblUnitValue.Visible = False
            lblUnitPriceValue.Visible = False
            lblUnitValue.Visible = False
            ' lblAvailableValue.Visible = False
            lblPartnovalue.Visible = False
            '  lblMinQtyValue.Visible = False
            gbAddSingEntry.Visible = False
            btnSaveAll.Enabled = False
            btnResetAll.Enabled = False
            btnSearchStockCode.Enabled = False
            txtStockCode.ReadOnly = True
            txtRequestedQty.ReadOnly = True
            txtRemarks.ReadOnly = True
            dtpIPRDate.Enabled = False
            dtpRequiredDate.Enabled = False
            cbApprovalStatus.SelectedIndex = 0
            txtRejectedReason.Text = String.Empty
            If cmbClassification.Text = String.Empty Then
                lblDay.Text = String.Empty
                lblDays.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub bind_cmbClassification()
        Dim dt As DataTable
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        dt = objIPRBOL.bind_cmbClassification(objIPRPPT)

        If dt.Rows.Count > 0 Then
            cmbClassification.DataSource = dt
            cmbClassification.DisplayMember = "Classification"
            cmbClassification.ValueMember = "Classification"
            cmbClassification.SelectedIndex = -1
            'cmbClassification.Text = "-SELECT-"
        End If
    End Sub

    Private Sub cmbClassification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassification.SelectedIndexChanged
        Dim dtDays As DataTable
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        If Not cmbClassification Is Nothing Then
            If (cmbClassification.SelectedIndex >= 0) Then
                lclassification = cmbClassification.SelectedValue.ToString()
                objIPRPPT.Classification = lclassification
                dtDays = objIPRBOL.Classification_DaysGet(objIPRPPT)
                If dtDays.Rows.Count > 0 Then
                    lblDays.Text = dtDays.Rows(0).Item("Days").ToString()
                    lblClassificationID.Text = dtDays.Rows(0).Item("ClassificationID").ToString()
                    If lblDays.Text > 1 Then
                        lblDay.Text = "Days"
                    Else
                        lblDay.Text = "Day"
                    End If
                End If
                'cmbClassification.Text = "-SELECT-"
            End If
        End If
        If lblDays.Text <> String.Empty Then
            dtpRequiredDate.Text = dtpIPRDate.Value.AddDays(lblDays.Text)
            lblDay.Visible = True
        End If
    End Sub

    Private Sub toloadIPR_inApproval()
        Dim MdiParent As New MDIParent

        If MdiParent.strMenuID = "M165" Then
            tcIPR.SelectedTab = tbIPR
            tcIPR.TabPages.Remove(tbView)
        End If
    End Sub

    Public Sub BindIPRMast_inApproval(ByVal strSTIPRID As String, ByVal strSTIPRNo As String, ByVal strSTIPRDate As String, ByVal strClassification As String, ByVal strRequiredfor As String, ByVal strRequiredDate As String, ByVal strD As String, ByVal strDeliveredto As String, ByVal strCategory As String, ByVal strCategoryCode As String, ByVal strStatus As String, ByVal strMakeModel As String, ByVal strEngine As String, ByVal strChassisSerialNo As String, ByVal strFixedAssetNo As String, ByVal strModifiedOn As String, ByVal strRemarks As String, ByVal strUsageCOAID As String, ByVal strUsageCOACode As String, ByVal strUsageCOADescp As String)
        lSTIPRID = strSTIPRID
        txtIPRNo.Text = strSTIPRNo
        dtpIPRDate.Value = strSTIPRDate
        dtpRequiredDate.Value = strRequiredDate
        bind_cmbClassification()
        cmbClassification.Text = strClassification
        txtUsageCOACode.Text = strUsageCOACode
        lblUsageCOADescp.Text = strUsageCOADescp
        psIPRUsageCOAID = strUsageCOAID
        txtCategory.Text = strCategory
        txtRequiredFor.Text = strRequiredfor
        txtDeliveredTo.Text = strDeliveredto
        'txtD.Text = strD
        lblStatusDesc.Text = strStatus
        txtMakeandModel.Text = strMakeModel
        txtEngine.Text = strEngine
        txtChassisSerialNo.Text = strChassisSerialNo
        txtFixedAssetNo.Text = strFixedAssetNo
        txtRemarks.Text = strRemarks
        lModifiedOn = strModifiedOn
        lblCategoryCode.Text = strCategoryCode
        lblCategoryCode.Visible = True
        txtIPRNo.ReadOnly = True
        cmbClassification.Enabled = False
        txtUsageCOACode.ReadOnly = True
        'txtD.ReadOnly = True
        txtRequiredFor.ReadOnly = True
        txtDeliveredTo.ReadOnly = True
        txtMakeandModel.ReadOnly = True
        txtEngine.ReadOnly = True
        txtChassisSerialNo.ReadOnly = True
        txtFixedAssetNo.ReadOnly = True
    End Sub

    Public Sub BindIPRDet_inApproval(ByVal strSTIPRID As String)
        'Dim mdiparent As New MDIParent
        'mdiparent.strMenuID = "M12"
        Dim ObjNonStockIPRBOL As New NonStockIPRBOL
        Dim ObjNonStockIPRPPT As New NonStockIPRPPT
        Dim dt As New DataTable
        With ObjNonStockIPRPPT
            .STNonStockIPRID = strSTIPRID
        End With
        dt = ObjNonStockIPRBOL.GetNonStockIPRDetails(ObjNonStockIPRPPT)
        Me.dgvNonStockIPRDetails.AutoGenerateColumns = False
        Me.dgvNonStockIPRDetails.DataSource = dt


        'If dgvIPRDetails.RowCount > 0 Then
        '    'If dgvIPRDetails.SelectedRows(0).Cells("dgclUnit").Value <> String.Empty Then
        '    lblUnitValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclUnit").Value
        '    'End If
        '    lblTotalValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value.ToString()
        '    lblUnitPriceValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
        '    txtRequestedQty.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclRequestedQty").Value.ToString()
        '    lblStockDesc.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
        '    lblAvailableValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
        'End If
        dgvNonStockIPRDetails.Enabled = True
        lblUnitPriceValue.Visible = True
        lblTotalValue.Visible = True
        lblUnitValue.Visible = True
        lblStockDesc.Visible = True
        lblCategoryCode.Visible = True
        'lblAvailableValue.Visible = True
        lblPartnovalue.Visible = True
        'lblMinQtyValue.Visible = True
        strMenuID = "M12"
    End Sub

    Private Sub btnSearchCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCategory.Click

        btnCategoryClickFlag = True
        clearMultiEntry()
        StrFrmName = "NonStockIPR"
        Dim StockCategory As New CategoryLookup()
        'StockCategory.BindStockCategory()
        Dim result As DialogResult = CategoryLookup.ShowDialog()

        If CategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then

            txtCategory.Text = String.Empty
            lblCategoryCode.Text = String.Empty
            txtCategory.Text = CategoryLookup._lStockCategoryCode.Trim
            lblCategoryCode.Text = CategoryLookup._lStockCategory.Trim
            lStockCategoryID = CategoryLookup._lStockCategoryID

            If txtCategory.Text.Trim <> String.Empty And lblCategoryCode.Text.Trim <> String.Empty Then

                Me.lblCategoryCode.Visible = True
                Me.txtRequiredFor.Focus()

            Else

                txtCategory.Text = String.Empty
                lblCategoryCode.Text = String.Empty
                DisplayInfoMessage("msg00")
                'MessageBox.Show(" Invalid category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCategory.Focus()

            End If

        End If

        btnCategoryClickFlag = False
        StrFrmName = ""

    End Sub

    Private Sub btnSearchUsageCOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUsageCOA.Click
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtUsageCOACode.Text = frmAcctcodeLookup.strAcctcode.Trim
            psIPRUsageCOAID = frmAcctcodeLookup.strAcctId
            lblUsageCOADescp.Text = frmAcctcodeLookup.strAcctDescp.Trim
            '' GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            ''lsVDExpenditureAG = frmAcctcodeLookup.strAcctExpenditureAG
        End If
    End Sub

    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click

        GlobalPPT.IsStockCategory = True
        If Me.txtCategory.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg01")

            'MessageBox.Show("Category field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCategory.Focus()
        Else
            Dim stockDt As New DataTable
            Dim ObjNonStockIPRBOL As New NonStockIPRBOL
            Dim ObjNonStockIPRPPT As New NonStockIPRPPT
            Dim StockCode As New NonStockCodeLookup()
            Dim result As DialogResult = NonStockCodeLookup.ShowDialog()
            If NonStockCodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
                txtStockCode.Text = NonStockCodeLookup._lStockCode.Trim
                lblStockDesc.Text = NonStockCodeLookup._lStockDesc.Trim
                lblUnitPriceValue.Text = NonStockCodeLookup._lStockUnitprice
                'lblUnitPriceValue.Text = NonStockCodeLookup._lStockLastPurchasePrice
                lblUnitValue.Text = NonStockCodeLookup._lUnit.Trim
                lStockID = NonStockCodeLookup._lStockID
                'lblAvailableValue.Text = StockCodeLookUp._lAvailableQty
                'lblMinQtyValue.Text = StockCodeLookUp._lMinQty
                lblPartnovalue.Text = NonStockCodeLookup._lPartNo.Trim
                'lblMinQtyValue.Text = StockCodeLookUp._lMinQty
                lblStockDesc.Visible = True
                lblUnitPriceValue.Visible = True
                lblUnitValue.Visible = True
                ' lblAvailableValue.Visible = True
                lblPartnovalue.Visible = True
                ' lblMinQtyValue.Visible = True
                txtRequestedQty.Focus()
            End If
        End If

    End Sub

    Private Sub txtRequestedQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestedQty.Leave
        If lblUnitPriceValue.Text.Trim <> String.Empty And txtStockCode.Text.Trim <> String.Empty Then
            CalcTotalValue()
        End If
    End Sub

    Private Sub CalcTotalValue()
        If Me.txtStockCode.Text = Nothing Then
            Me.txtStockCode.Focus()
            'MessageBox.Show("Stock code required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            If Me.txtRequestedQty.Text = Nothing Then
                Me.lblTotalValue.Text = String.Empty
                Exit Sub
            Else
                If lblUnitPriceValue.Text.Trim <> String.Empty Then
                    Me.lblTotalValue.Visible = True
                    Me.lblTotalValue.Text = CDec(Convert.ToDecimal(lblUnitPriceValue.Text) * Convert.ToDecimal(txtRequestedQty.Text))
                    Me.lblTotalValue.Text = Decimal.Round(CDec(Me.lblTotalValue.Text), 2)
                Else
                    DisplayInfoMessage("msg02")
                    'MessageBox.Show("UnitPrice required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If
        End If

        'MessageBox.Show("UnitPrice required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Function IsFormValidAdd()

        If txtIPRNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg14")
            'MessageBox.Show("IPR No. Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtIPRNo.Focus()
            Return False
        End If

        If txtCategory.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg04")
            'MessageBox.Show("Category field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCategory.Focus()
            Return False
        End If

        If lblCategoryCode.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg05")
            'MessageBox.Show("Category Code missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If cmbClassification.Text.Trim = String.Empty Then
            'MessageBox.Show("Classification Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg38")
            cmbClassification.Focus()
            Return False
        End If
        If (dtpRequiredDate.Value.Date) <= (dtpIPRDate.Value.Date) Then
            DisplayInfoMessage("msg03")
            'MessageBox.Show(" Required date must be greater than IPRDate ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpRequiredDate.Focus()
            Return False
        End If
        If txtUsageCOACode.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg40")
            'MessageBox.Show("Usage COA Code field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsageCOACode.Focus()
            Return False
        End If
       

        ''If txtUsageCOACode.Text = String.Empty Then
        ''    MessageBox.Show("Usage COA Code field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    txtUsageCOACode.Focus()
        ''    Return False
        ''End If
        
        If txtStockCode.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg06")
            'MessageBox.Show("Stock Code Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtStockCode.Focus()
            Return False
        End If
        If lblStockDesc.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg07")
            'MessageBox.Show("Stock Description missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If txtRequestedQty.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg08")
            'MessageBox.Show("Requested Quantity missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRequestedQty.Focus()
            Return False
        End If
        If lblUnitPriceValue.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg09")
            'MessageBox.Show("Unit price missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If lblUnitPriceValue.Text.Trim = 0 Then
            DisplayInfoMessage("msg10")
            'MessageBox.Show("Unit Price is Zero", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Function StockCodeExist(ByVal StockCode As String) As Boolean
        Dim objDataGridViewRow As New DataGridViewRow
        If AddFlag = True Then
            For Each objDataGridViewRow In dgvNonStockIPRDetails.Rows
                If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
                    txtStockCode.Text = ""
                    txtRequestedQty.Text = ""
                    txtStockCode.Focus()
                    Return True
                End If
            Next
            Return False
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If AddFlag = True Then
            If lblUnitPriceValue.Text.Trim <> String.Empty And txtStockCode.Text.Trim <> String.Empty Then
                CalcTotalValue()
            End If
            Insert_MultiEntry()

        Else
            Update_MultiEntry()
        End If

        'GlobalPPT.IsRetainFocus = True

    End Sub

    Private Sub Insert_MultiEntry()
        If Not IsFormValidAdd() Then Exit Sub
        Dim intRowcount As Integer = dtIPRDetails.Rows.Count
        Dim i As Integer = dgvNonStockIPRDetails.Rows.Count
        AddFlag = True
        If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 
            rowIPRDetails = dtIPRDetails.NewRow()
            If intRowcount = 0 And DTFlag = False Then
                columnIPRDetails = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                'columnIPRDetails = New DataColumn("AvailableQty", System.Type.[GetType]("System.Decimal"))
                'dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("Unit", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("UnitPrice", System.Type.[GetType]("System.Decimal"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("RequestedQty", System.Type.[GetType]("System.Decimal"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("TotalPrice", System.Type.[GetType]("System.Decimal"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("StockID", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("STNonStockIPRDetID", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                'columnIPRDetails = New DataColumn("MinQty", System.Type.[GetType]("System.Decimal"))
                'dtIPRDetails.Columns.Add(columnIPRDetails)

                If txtStockCode.Text.Trim <> String.Empty Then
                    rowIPRDetails("StockCode") = txtStockCode.Text.ToString()
                Else
                    rowIPRDetails("StockCode") = String.Empty
                End If
                If lblStockDesc.Text.Trim <> String.Empty Then
                    rowIPRDetails("StockDesc") = lblStockDesc.Text.ToString()
                Else
                    rowIPRDetails("StockDesc") = String.Empty
                End If
                'If lblAvailableValue.Text.Trim <> String.Empty Then
                '    rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
                'Else
                '    rowIPRDetails("AvailableQty") = 0
                'End If
                If lblUnitValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("Unit") = lblUnitValue.Text.ToString()
                Else
                    rowIPRDetails("Unit") = String.Empty
                End If
                If lblUnitPriceValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("UnitPrice") = CDbl(lblUnitPriceValue.Text)
                Else
                    rowIPRDetails("UnitPrice") = 0
                End If
                If txtRequestedQty.Text.Trim <> String.Empty Then
                    rowIPRDetails("RequestedQty") = CDbl(txtRequestedQty.Text)
                Else
                    rowIPRDetails("RequestedQty") = 0
                End If

                If lblTotalValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("TotalPrice") = CDbl(lblTotalValue.Text)
                Else
                    rowIPRDetails("TotalPrice") = 0
                End If
                If lStockID <> String.Empty Then
                    rowIPRDetails("StockID") = lStockID
                Else
                    rowIPRDetails("StockID") = String.Empty
                End If
                If lSTIPRDetID <> String.Empty Then
                    rowIPRDetails("STNonStockIPRDetID") = lSTIPRDetID
                Else
                    rowIPRDetails("STNonStockIPRDetID") = String.Empty
                End If
                If lblPartnovalue.Text.Trim <> String.Empty Then
                    rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
                Else
                    rowIPRDetails("PartNo") = String.Empty
                End If
                'If lblMinQtyValue.Text.Trim <> String.Empty Then
                '    rowIPRDetails("MinQty") = CDbl(lblMinQtyValue.Text)
                'Else
                '    rowIPRDetails("MinQty") = 0
                'End If

                dtIPRDetails.Rows.InsertAt(rowIPRDetails, intRowcount)
                DTFlag = True
            Else
                If txtStockCode.Text.Trim <> String.Empty Then
                    rowIPRDetails("StockCode") = txtStockCode.Text.ToString()
                Else
                    rowIPRDetails("StockCode") = String.Empty
                End If
                If lblStockDesc.Text.Trim <> String.Empty Then
                    rowIPRDetails("StockDesc") = lblStockDesc.Text.ToString()
                Else
                    rowIPRDetails("StockDesc") = String.Empty
                End If
                'If lblAvailableValue.Text.Trim <> String.Empty Then
                '    rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
                'Else
                '    rowIPRDetails("AvailableQty") = 0
                'End If
                If lblUnitValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("Unit") = lblUnitValue.Text.ToString()
                Else
                    rowIPRDetails("Unit") = String.Empty
                End If
                If lblUnitPriceValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("UnitPrice") = CDbl(lblUnitPriceValue.Text)
                Else
                    rowIPRDetails("UnitPrice") = 0
                End If
                If txtRequestedQty.Text.Trim <> String.Empty Then
                    rowIPRDetails("RequestedQty") = CDbl(txtRequestedQty.Text)
                Else
                    rowIPRDetails("RequestedQty") = 0
                End If

                If lblTotalValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("TotalPrice") = CDbl(lblTotalValue.Text)
                Else
                    rowIPRDetails("TotalPrice") = 0
                End If
                If lStockID <> String.Empty Then
                    rowIPRDetails("StockID") = lStockID
                Else
                    rowIPRDetails("StockID") = String.Empty
                End If
                If lSTIPRDetID <> String.Empty Then
                    rowIPRDetails("STNonStockIPRDetID") = lSTIPRDetID
                Else
                    rowIPRDetails("STNonStockIPRDetID") = String.Empty
                End If
                If lblPartnovalue.Text.Trim <> String.Empty Then
                    rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
                Else
                    rowIPRDetails("PartNo") = String.Empty
                End If
                'If lblMinQtyValue.Text.Trim <> String.Empty Then
                '    rowIPRDetails("MinQty") = CDbl(lblMinQtyValue.Text)
                'Else
                '    rowIPRDetails("MinQty") = 0
                'End If

                ''rowIPRDetails("StockCode") = txtStockCode.Text.ToString()
                ''rowIPRDetails("StockDesc") = lblStockDesc.Text.ToString()
                ''rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
                ''rowIPRDetails("Unit") = lblUnitValue.Text.ToString()
                ''rowIPRDetails("UnitPrice") = lblUnitPriceValue.Text.ToString()
                ''rowIPRDetails("RequestedQty") = txtRequestedQty.Text.ToString()
                ''rowIPRDetails("TotalPrice") = lblTotalValue.Text.ToString()
                ''rowIPRDetails("StockID") = lStockID ' Adding new Stock in Update mode so Stock ID will be null.
                ''rowIPRDetails("STIPRDetID") = "" 'lSTIPRDetID
                ''rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
                ''rowIPRDetails("MinQty") = lblMinQtyValue.Text

                dtIPRDetails.Rows.InsertAt(rowIPRDetails, intRowcount)
            End If
            With dgvNonStockIPRDetails
                .AutoGenerateColumns = False
                .DataSource = dtIPRDetails
                clearMultiEntry()
                Disable_SingleEntry()
                txtMakeandModel.Focus()
            End With
        Else
            DisplayInfoMessage("msg11")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Update_MultiEntry()
        If Not IsFormValidAdd() Then Exit Sub
        Dim strStCode As String = txtStockCode.Text.ToString()
        For i As Integer = 0 To dgvNonStockIPRDetails.Rows.Count - 1
            If i <> dgvNonStockIPRDetails.CurrentRow.Index Then
                If strStCode = dgvNonStockIPRDetails.Rows(i).Cells("dgclStockCode").Value.ToString() Then
                    DisplayInfoMessage("msg12")
                    'MsgBox("Stock Code already exist in this ITN-IN Details")
                    clearMultiEntry()
                    txtStockCode.Focus()
                    Exit Sub
                End If
            Else
            End If
        Next
        If strStCode = dgvNonStockIPRDetails.CurrentRow.Cells("dgclStockCode").Value.ToString() Then
        End If

        Dim dgvrow As Integer
        Dim Str As String = dgvNonStockIPRDetails.Columns.Item(1).Name
        If AddFlag = False And dgvNonStockIPRDetails.Rows.Count > 0 Then
            dgvrow = dgvNonStockIPRDetails.CurrentRow.Index
            dtIPRDetails.Rows.RemoveAt(dgvrow)
            rowIPRDetails = dtIPRDetails.NewRow()
            If txtStockCode.Text.Trim <> String.Empty Then
                rowIPRDetails("StockCode") = txtStockCode.Text.ToString()
            Else
                rowIPRDetails("StockCode") = String.Empty
            End If
            If lblStockDesc.Text.Trim <> String.Empty Then
                rowIPRDetails("StockDesc") = lblStockDesc.Text.ToString()
            Else
                rowIPRDetails("StockDesc") = String.Empty
            End If
            'If lblAvailableValue.Text.Trim <> String.Empty Then
            '    rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
            'Else
            '    rowIPRDetails("AvailableQty") = 0
            'End If
            If lblUnitValue.Text.Trim <> String.Empty Then
                rowIPRDetails("Unit") = lblUnitValue.Text.ToString()
            Else
                rowIPRDetails("Unit") = String.Empty
            End If
            If lblUnitPriceValue.Text.Trim <> String.Empty Then
                rowIPRDetails("UnitPrice") = lblUnitPriceValue.Text.ToString()
            Else
                rowIPRDetails("UnitPrice") = 0
            End If
            If txtRequestedQty.Text.Trim <> String.Empty Then
                rowIPRDetails("RequestedQty") = txtRequestedQty.Text.ToString()
            Else
                rowIPRDetails("RequestedQty") = 0
            End If
            If lblTotalValue.Text.Trim <> String.Empty Then
                rowIPRDetails("TotalPrice") = lblTotalValue.Text.ToString()
            Else
                rowIPRDetails("TotalPrice") = 0
            End If

            ' rowIPRDetails("StockID") = lStockID ' Adding new Stock in Update mode so Stock ID will be null.
            If lStockID <> String.Empty Then
                rowIPRDetails("StockID") = lStockID
            Else
                rowIPRDetails("StockID") = String.Empty
            End If
            If lSTIPRDetID <> String.Empty Then
                rowIPRDetails("STNonStockIPRDetID") = lSTIPRDetID
            Else
                rowIPRDetails("STNonStockIPRDetID") = String.Empty
            End If
            If lblPartnovalue.Text.Trim <> String.Empty Then
                rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
            Else
                rowIPRDetails("PartNo") = String.Empty
            End If
            'If lblMinQtyValue.Text.Trim <> String.Empty Then
            '    rowIPRDetails("MinQty") = CDbl(lblMinQtyValue.Text)
            'Else
            '    rowIPRDetails("MinQty") = 0
            'End If
            dtIPRDetails.Rows.InsertAt(rowIPRDetails, dgvrow)
            dgvNonStockIPRDetails.DataSource = dtIPRDetails
            ''btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            clearMultiEntry()
            AddFlag = True
        End If
    End Sub

    Private Sub Disable_SingleEntry()
        txtCategory.ReadOnly = True
        btnSearchCategory.Enabled = False
        txtDeliveredTo.ReadOnly = True
        cmbClassification.Enabled = False
        txtUsageCOACode.ReadOnly = True
        btnSearchUsageCOA.Enabled = False
        btnSearchUsageCOA.Enabled = False
        txtRequiredFor.ReadOnly = True
        'txtD.ReadOnly = True
        'txtRejectedReason.ReadOnly = True
        'txtMakeandModel.ReadOnly = True
        'txtChassisSerialNo.ReadOnly = True
        'txtEngine.ReadOnly = True
        'txtFixedAssetNo.ReadOnly = True
        txtRemarks.ReadOnly = True
    End Sub

   
    Private Sub txtRequestedQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRequestedQty.KeyDown
        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains("") Then
                            isDecimal = False
                            Return
                        End If

                        isDecimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        isDecimal = reDecimalPlaces.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtRequestedQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRequestedQty.KeyPress
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub txtStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave

        If txtStockCode.Text = String.Empty Then
            Me.lblUnitValue.Text = String.Empty
            Me.lblStockDesc.Text = String.Empty
            Me.lblUnitPriceValue.Text = String.Empty
            Me.lblTotalValue.Text = String.Empty
            'Me.lblAvailableValue.Text = String.Empty
            Me.lblPartnovalue.Text = String.Empty
            Exit Sub
        End If

        Dim dt As New DataTable
        Dim dtStock As New DataTable
        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        objNonStockIPRPPT.STCategoryCode = Me.lblCategoryCode.Text
        objNonStockIPRPPT.STCategory = Me.txtCategory.Text
        objNonStockIPRPPT.STCategoryID = lStockCategoryID
        objNonStockIPRPPT.StockCode = Me.txtStockCode.Text
        dt = objNonStockIPRBOL.StockCodeSearch(objNonStockIPRPPT)
        If dt.Rows.Count <> 0 Then
            lStockID = dt.Rows(0).Item("NonStockID").ToString()
            Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString()
            Me.lblStockDesc.Text = dt.Rows(0).Item("StockDesc").ToString()
            Me.lblUnitValue.Text = dt.Rows(0).Item("UOM").ToString()
            'If Not dt.Rows(0).Item("AvailableQty") Is DBNull.Value Then
            '    lblAvailableValue.Text = CDbl(dt.Rows(0).Item("AvailableQty"))
            'Else
            '    lblAvailableValue.Text = String.Empty
            'End If

            'If Not dt.Rows(0).Item("UnitPrice") Is DBNull.Value Then
            '    ' If dt.Rows(0).Item("UnitPrice") <> String.Empty Then
            '    lblUnitPriceValue.Text = CDbl(dt.Rows(0).Item("UnitPrice"))
            '    'End If
            'Else
            '    lblUnitPriceValue.Text = String.Empty
            'End If

            If Not dt.Rows(0).Item("UnitPrice") Is DBNull.Value Then
                lblUnitPriceValue.Text = CDbl(dt.Rows(0).Item("UnitPrice"))
            Else
                lblUnitPriceValue.Text = String.Empty
            End If


            If Not dt.Rows(0).Item("PartNo") Is DBNull.Value Then
                lblPartnovalue.Text = dt.Rows(0).Item("PartNo")
            Else
                lblPartnovalue.Text = String.Empty
            End If

            'If Not dt.Rows(0).Item("MinQty") Is DBNull.Value Then
            '    lblMinQtyValue.Text = CDbl(dt.Rows(0).Item("MinQty"))
            'Else
            '    lblMinQtyValue.Text = String.Empty
            'End If



            'lblAvailableValue.Visible = True
            lblUnitPriceValue.Visible = True
            'objIPRPPT.stockID = dt.Rows(0).Item("StockID").ToString()
            Me.lblUnitValue.Visible = True
            Me.lblStockDesc.Visible = True
            Me.lblTotalValue.Visible = True
            lblPartnovalue.Visible = True
            'lblMinQtyValue.Visible = True
        Else
            DisplayInfoMessage("msg13")
            'MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtStockCode.Text = String.Empty
            txtStockCode.Focus()
        End If
        'If objIPRPPT.stockID <> String.Empty Then
        '    dtStock = objIPRBOL.GetAvailableQTy(objIPRPPT)
        '    If dtStock.Rows.Count <> 0 Then
        '        Me.lblUnitPriceValue.Text = dtStock.Rows(0).Item("UnitPrice").ToString
        '        Me.lblAvailableValue.Text = dtStock.Rows(0).Item("AvailableQty").ToString
        '        If lblAvailableValue.Text = String.Empty Then
        '            lblAvailableValue.Text = "0"
        '        End If
        '        Me.lblUnitPriceValue.Visible = True
        '        lblAvailableValue.Visible = True
        '    End If
        'End If
    End Sub

    Private Sub dgvNonStockIPRDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNonStockIPRDetails.CellDoubleClick
        BindIPRDetailsGrid()
    End Sub

    Private Sub BindIPRDetailsGrid()
        If dgvNonStockIPRDetails.Rows.Count > 0 Then

            ''btnAdd.Text = "Update"

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If

            Me.txtStockCode.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            If dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclUnit").Value <> String.Empty Then
                Me.lblUnitValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclUnit").Value.ToString()
            End If
            'If dgvIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value = String.Empty Then
            Me.lblTotalValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value.ToString()
            'End If
            Me.lblUnitPriceValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
            Me.txtRequestedQty.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclRequestedQty").Value.ToString()
            Me.lblStockDesc.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
            ' Me.lblAvailableValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
            lStockID = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclStockID").Value.ToString()
            lSTIPRDetID = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclSTIPRDetID").Value.ToString()
            lblPartnovalue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclPartNo").Value.ToString()
            'lblMinQtyValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclMinimumQty").Value.ToString()
            'If lStockID <> Nothing Then
            '    objPPT.stockID = lStockID
            '    dtStock = objIPRBOL.GetAvailableQTy(objPPT)
            '    If dtStock.Rows.Count <> 0 Then
            '        Me.lblUnitPriceValue.Text = dtStock.Rows(0).Item("UnitPrice").ToString
            '        Me.lblAvailableValue.Text = dtStock.Rows(0).Item("AvailableQty").ToString
            '        Me.lblUnitPriceValue.Visible = True
            '        lblAvailableValue.Visible = True
            '    End If
            'End If
            AddFlag = False
            Me.lblUnitPriceValue.Visible = True
            Me.lblTotalValue.Visible = True
            Me.lblUnitValue.Visible = True
            Me.lblStockDesc.Visible = True
            lblCategoryCode.Visible = True
            'lblAvailableValue.Visible = True
            lblPartnovalue.Visible = True
            'lblMinQtyValue.Visible = True
        End If
    End Sub

    Private Sub dgvNonStockIPRDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvNonStockIPRDetails.KeyDown
        If e.KeyCode = Keys.Return Then
            BindIPRDetailsGrid()
            e.Handled = True
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearMultiEntry()
    End Sub

    Private Sub clearMultiEntry()
        txtStockCode.Text = String.Empty
        txtStockCode.ReadOnly = False
        btnSearchStockCode.Enabled = True
        lblStockDesc.Text = String.Empty
        'lblAvailableValue.Text = String.Empty
        lblUnitValue.Text = String.Empty
        lblUnitPriceValue.Text = String.Empty
        txtRequestedQty.Text = String.Empty
        txtRequestedQty.ReadOnly = False
        lblPartnovalue.Text = String.Empty
        'lblMinQtyValue.Text = String.Empty
        lStockID = String.Empty
        'lSTITNInDetID = String.Empty
        lblTotalValue.Text = String.Empty
        txtCategory.Enabled = True
        btnSearchCategory.Enabled = True
        txtMakeandModel.ReadOnly = False
        txtFixedAssetNo.ReadOnly = False
        txtChassisSerialNo.ReadOnly = False
        txtEngine.ReadOnly = False
        btnSaveAll.Enabled = True
        dtpRequiredDate.Enabled = False
        gbAddSingEntry.Visible = True
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        AddFlag = True

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


    End Sub

    Private Function IsFormValidSaveAll()

        If txtIPRNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg14")
            'MessageBox.Show("IPR No. Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If txtCategory.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg15")
            'MessageBox.Show("Category field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCategory.Focus()
            Return False
        End If
        If txtUsageCOACode.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg40")
            'MessageBox.Show("Usage COA Code field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsageCOACode.Focus()
            Return False
        End If
        If dgvNonStockIPRDetails.Rows.Count = 0 Then
            DisplayInfoMessage("msg16")
            'MessageBox.Show("Stock Items Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If (dtpRequiredDate.Value.Date) <= (dtpIPRDate.Value.Date) Then
            DisplayInfoMessage("msg17") '
            'MessageBox.Show(" Required date must be greater than IPRDate ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Sub SaveAll()

        If Not IsFormValidSaveAll() Then Exit Sub
        Dim rowsAffected As Integer = 0
        Dim Iprnocount As Integer = 0
        Dim dt As New DataTable
        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        With objNonStockIPRPPT
            .IPRdate = dtpIPRDate.Value
            .DeliveredTo = txtDeliveredTo.Text.Trim
            .IPRNo = txtIPRNo.Text.Trim
            .Classification = lblClassificationID.Text
            .STCategoryID = lStockCategoryID 'STCategoryID
            .RequiredFor = txtRequiredFor.Text.Trim
            .RequiredDate = dtpRequiredDate.Value
            '.D = txtD.Text
            .MainStatus = "OPEN"
            .MakeModel = txtMakeandModel.Text.Trim
            .Engine = txtEngine.Text.Trim
            .ChassisSerialNo = txtChassisSerialNo.Text.Trim
            .FixedAssetNo = txtFixedAssetNo.Text.Trim
            .Remarks = txtRemarks.Text
            .COAID = psIPRUsageCOAID
            .STNonStockIPRID = lSTIPRID 'lSTIPRID to differentiate for update
        End With

        If lSTIPRID = "" Then
            'dt = objNonStockIPRBOL.Save_STNonStockIPR(objNonStockIPRPPT)
            'If dt.Rows.Count > 0 Then
            '    lSTIPRID = dt.Rows(0).Item("STNonStockIPRID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
            'Else
            '    MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    rowsAffected = objNonStockIPRBOL.Delete_STNonStockIPRDetail(objNonStockIPRPPT)
            '    Exit Sub
            'End If
            dt = objNonStockIPRBOL.STNonStockIPRNo_isExist(objNonStockIPRPPT)
            If dt.Rows.Count > 0 Then
                Iprnocount = dt.Rows.Count 'dt.Rows(0).Item("STNonStockIPRID")
                If Iprnocount > 0 Then
                    DisplayInfoMessage("msg18")
                    'MessageBox.Show("IPR No already Exist", " ", MessageBoxButtons.OK)
                    Exit Sub
                Else
                    DeleteMultiEntryRecords()
                    dt = objNonStockIPRBOL.Save_STNonStockIPR(objNonStockIPRPPT)
                    If dt.Rows.Count > 0 Then
                        lSTIPRID = dt.Rows(0).Item("STNonStockIPRID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
                    Else
                        DisplayInfoMessage("msg19")
                        'MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        rowsAffected = objNonStockIPRBOL.Delete_STNonStockIPRDetail(objNonStockIPRPPT)
                        Exit Sub
                    End If
                End If
            Else
                'Exit Sub
                dt = objNonStockIPRBOL.Save_STNonStockIPR(objNonStockIPRPPT)
                If dt.Rows.Count > 0 Then
                    lSTIPRID = dt.Rows(0).Item("STNonStockIPRID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
                Else
                    DisplayInfoMessage("msg20")
                    'MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowsAffected = objNonStockIPRBOL.Delete_STNonStockIPRDetail(objNonStockIPRPPT)
                    Exit Sub
                End If

            End If
        Else
            rowsAffected = objNonStockIPRBOL.Update_STNonStockIPR(objNonStockIPRPPT)
            If rowsAffected = 1 Then
            Else
                DisplayInfoMessage("msg21")
                'MessageBox.Show("Failed to update Records", "Error occured in updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim arrayListInfo As New ArrayList()
        Dim DataGridViewRow As DataGridViewRow
        For Each DataGridViewRow In dgvNonStockIPRDetails.Rows
            With objNonStockIPRPPT
                .stockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
                .RequestedQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
                .UnitPrice = CDbl(DataGridViewRow.Cells("dgclUnitPrice").Value.ToString())
                .Status = lblStatusDesc.Text
                .RejectedReason = txtRejectedReason.Text
                .value = DataGridViewRow.Cells("dgclTotalPrice").Value.ToString()
                .RequestedQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
                .PendingQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
                .STNonStockIPRID = lSTIPRID
                .STNonStockIPRDetID = DataGridViewRow.Cells("dgclSTIPRDetID").Value.ToString() 'to differentiate for update
            End With
            If objNonStockIPRPPT.STNonStockIPRDetID = "" Then
                rowsAffected = objNonStockIPRBOL.Save_STNonStockIPRDetail(objNonStockIPRPPT)
            Else
                rowsAffected = objNonStockIPRBOL.Update_STNonStockIPRDetail(objNonStockIPRPPT)
            End If
        Next
        If rowsAffected = 1 Then
            If objNonStockIPRPPT.STNonStockIPRDetID = "" Then
                DisplayInfoMessage("msg22")
                'MessageBox.Show("Records inserted Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DisplayInfoMessage("msg23")
                'MessageBox.Show("Records updated Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("msg24")
            'MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rowsAffected = objNonStockIPRBOL.Delete_STNonStockIPRDetail(objNonStockIPRPPT)

        End If
        Enable_SingleEntry()
        ClearGridView(dgvNonStockIPRDetails)

        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        ClearSingleEntry()
        'toGetIPRNo()
        clearMultiEntry()
        txtCategory.ReadOnly = False
        lblStatusDesc.Text = "OPEN"

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()

    End Sub

    Private Sub Enable_SingleEntry()

        DeleteMultientry.Clear()

        'txtCategory.ReadOnly = False
        'btnSearchCategory.Enabled = True

        txtIPRNo.ReadOnly = False
        txtIPRNo.Enabled = True
        txtDeliveredTo.ReadOnly = False
        cmbClassification.Enabled = True
        txtUsageCOACode.ReadOnly = False
        txtUsageCOACode.Enabled = True
        btnSearchUsageCOA.Enabled = True
        txtRequiredFor.ReadOnly = False

        'txtD.ReadOnly = False
        'txtRejectedReason.ReadOnly = False
        'txtMakeandModel.ReadOnly = False
        'txtChassisSerialNo.ReadOnly = False
        'txtEngine.ReadOnly = False
        'txtFixedAssetNo.ReadOnly = False

        txtRemarks.ReadOnly = False
    End Sub

    Private Sub ClearSingleEntry()
        txtIPRNo.Text = String.Empty
        cmbClassification.Text = Nothing
        txtUsageCOACode.Text = String.Empty
        lblUsageCOADescp.Text = String.Empty
        txtRequiredFor.Text = String.Empty
        txtDeliveredTo.Text = String.Empty
        txtMakeandModel.Text = String.Empty
        txtEngine.Text = String.Empty
        txtChassisSerialNo.Text = String.Empty
        txtFixedAssetNo.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtCategory.Text = String.Empty
        'txtD.Text = String.Empty
        lblCategoryCode.Visible = False
        dtpIPRDate.Enabled = True
        lSTIPRID = String.Empty
        lSTIPRDetID = String.Empty
        lblDay.Text = String.Empty
        lblDays.Text = String.Empty
        lblRejectReason.Visible = False
        lblcolon21.Visible = False
        lblRejectreasondesc.Text = String.Empty
    End Sub

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
                'If grdname.Rows.Count - 1 Then
                '    grdname.Rows.RemoveAt(0)
                'End If
            Next
        End If
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click

        ResetAll()

    End Sub

    Private Sub ResetAll()

        ClearGridView(dgvNonStockIPRDetails)
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        Enable_SingleEntry()
        dtpIPRDate.Format = DateTimePickerFormat.Custom
        dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpIPRDate)
        dtpIPRDate.Enabled = True
        ClearSingleEntry()
        clearMultiEntry()
        'toGetIPRNo()
        lblStatusDesc.Text = "OPEN"
        AddFlag = True
        txtCategory.ReadOnly = False
        dtpRequiredDate.Enabled = False
        psIPRUsageCOAID = String.Empty
        lblClassificationID.Text = String.Empty

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'If (dgvNonStockIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) Then
        '    If MsgBox(rm.GetString("msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        GridIPRViewBind()
        '    Else
        '        tcIPR.SelectedTab = tbIPR
        '    End If
        'Else
        '    Me.Close()
        'End If

        If (dgvNonStockIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) And mdiparent.strMenuID = "M164" And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("msg42"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsRetainFocus = True
                GlobalPPT.IsButtonClose = False
                Exit Sub
            End If
        Else
            Me.Close()
        End If

    End Sub
    Private Sub ResetAllOnTabClick()

        txtCategory.ReadOnly = False
        txtCategory.Focus()
        btnSearchCategory.Enabled = True
        txtMakeandModel.ReadOnly = False
        txtEngine.ReadOnly = False
        txtChassisSerialNo.ReadOnly = False
        txtFixedAssetNo.ReadOnly = False
        txtStockCode.ReadOnly = False
        txtRequestedQty.ReadOnly = False
        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        btnSearchStockCode.Enabled = True
        dgvNonStockIPRDetails.Enabled = True
        ClearGridView(dgvNonStockIPRDetails)
        gbAddSingEntry.Visible = True
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        Enable_SingleEntry()
        dtpIPRDate.Format = DateTimePickerFormat.Custom
        dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpIPRDate)
        dtpIPRDate.Enabled = True
        ClearSingleEntry()
        clearMultiEntry()
        'toGetIPRNo()
        lblStatusDesc.Text = "OPEN"
        dtpRequiredDate.Enabled = False
        lblClassificationID.Text = String.Empty
        psIPRUsageCOAID = String.Empty

        dtpIPRDate.Focus()

    End Sub

    Private Sub tcIPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcIPR.Click

        If tcIPR.SelectedTab Is tbIPR = True Then
            If tcIPR.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgvNonStockIPRDetails.RowCount > 0 Then
                        If MsgBox(rm.GetString("msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ResetAllOnTabClick()
                        Else
                            Exit Sub
                        End If
                    Else
                        ResetAllOnTabClick()
                    End If
                End If
            Else
                Exit Sub '--if approval screen--'
            End If

        ElseIf tcIPR.SelectedTab Is tbView = True Then
            chkIPRdate.Focus()
            If (dgvNonStockIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And btnSaveAll.Enabled = True) Then
                If MsgBox(rm.GetString("msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ClearGridView(dgvNonStockIPRDetails)
                    GlobalPPT.IsRetainFocus = False
                    cmbStatus.Text = "OPEN"
                    GridIPRViewBind()
                Else
                    tcIPR.SelectedTab = tbIPR
                End If
            Else
                ResetAll()
                cmbStatus.Text = "OPEN"
                GridIPRViewBind()
            End If
            'GridIPRViewBind()

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub GridIPRViewBind()

        dgvIRPView.DataSource = Nothing

        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        Dim dt As New DataTable
        With objNonStockIPRPPT
            Dim str As String = cmbStatus.SelectedItem.ToString()

            If chkIPRdate.Checked = True Then
                '.IPRdate = Format(Me.dtpviewIPRDate.Value, "MM/dd/yyyy")
                .IPRdate = dtpviewIPRDate.Value
            Else
                .IPRdate = Nothing
            End If
            .IPRNo = Me.txtviewIPRNo.Text.Trim
            .DeliveredTo = Me.txtviewDeliveredto.Text.Trim
            .Classification = Me.txtviewClassification.Text.Trim
            .RequiredFor = Me.txtviewRequiredfor.Text.Trim
            .STCategory = Me.txtviewCategory.Text.Trim
            .MainStatus = cmbStatus.SelectedItem.ToString()
            'End If
        End With

        dt = objNonStockIPRBOL.GetNonStockIPRSearch_Details(objNonStockIPRPPT)
        If dt.Rows.Count <> 0 Then

            dgvIRPView.AutoGenerateColumns = False
            Me.dgvIRPView.DataSource = dt

            lblView.Visible = False
            txtviewIPRNo.Text = String.Empty
            txtviewDeliveredto.Text = String.Empty
            txtviewClassification.Text = String.Empty
            txtviewRequiredfor.Text = String.Empty
            txtviewCategory.Text = String.Empty
        Else
            lblView.Visible = True
            Exit Sub
        End If

    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click

        Dim ObjRecordExist As New Object
        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        ObjRecordExist = objNonStockIPRBOL.STNonStockIPRRecordIsExist(objNonStockIPRPPT)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("msg25")
            'MsgBox("No Record(s) Available!")
        Else

            StrFrmName = "NonStockIPR"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GridIPRViewBind()
    End Sub

    Private Sub btnviewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCategory.Click

        Dim StockCategory As New CategoryLookup()
        StrFrmName = "NonStockIPR"
        StockCategory.BindStockCategory()

        Dim result As DialogResult = CategoryLookup.ShowDialog()

        If CategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then

            Me.lStockCategory = CategoryLookup._lStockCategoryCode
            Me.txtviewCategory.Text = lStockCategory

            Me.lblCategoryCode.Visible = True
            lStockCategoryCode = CategoryLookup._lStockCategory
            Me.lblCategoryCode.Text = lStockCategoryCode

            lStockCategoryID = CategoryLookup._lStockCategoryID
            Me.txtStockCode.Focus()

        End If
        StrFrmName = String.Empty

    End Sub

    Private Sub dgvIRPView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIRPView.CellDoubleClick

        EditViewGridRecord()

    End Sub
    Private Sub EditViewGridRecord()

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                Update_IPRView()
            End If
        End If

    End Sub
    Private Sub Update_IPRView()

        If dgvIRPView.RowCount > 0 Then

            If dgvIRPView.SelectedRows(0).Cells("gvMainStatus").Value <> "OPEN" And dgvIRPView.SelectedRows(0).Cells("gvMainStatus").Value <> "REJECTED" Then

                Edit_IPRView()
                btnSaveAll.Enabled = False
                'btnResetAll.Enabled = False
                Disable_SingleEntry()
                gbAddSingEntry.Visible = False
                txtMakeandModel.ReadOnly = True
                txtEngine.ReadOnly = True
                txtFixedAssetNo.ReadOnly = True
                txtChassisSerialNo.ReadOnly = True
                txtStockCode.ReadOnly = True
                txtRequestedQty.ReadOnly = True
                btnSearchStockCode.Enabled = False
                dgvNonStockIPRDetails.Enabled = False

                If dgvNonStockIPRDetails.RowCount > 0 Then

                    txtStockCode.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
                    If dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclUnit").Value <> String.Empty Then
                        lblUnitValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclUnit").Value.ToString()
                    End If

                    lblTotalValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value.ToString()
                    lblUnitPriceValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
                    txtRequestedQty.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclRequestedQty").Value.ToString()
                    lblStockDesc.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
                    'lblAvailableValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
                    lblPartnovalue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclPartNo").Value.ToString()
                    'lblMinQtyValue.Text = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclMinimumQty").Value.ToString()

                End If

                lblUnitPriceValue.Visible = True
                lblTotalValue.Visible = True
                lblUnitValue.Visible = True
                lblStockDesc.Visible = True
                lblCategoryCode.Visible = True
                'lblAvailableValue.Visible = True
                lblPartnovalue.Visible = True
                'lblMinQtyValue.Visible = True
                dtpRequiredDate.Enabled = False
                'txtIPRNo.ReadOnly = True
                txtUsageCOACode.Enabled = False
                btnSearchUsageCOA.Enabled = False
                txtIPRNo.Enabled = False
            Else

                Edit_IPRView()
                btnSaveAll.Enabled = True
                btnResetAll.Enabled = True
                gbAddSingEntry.Visible = True
                txtMakeandModel.ReadOnly = False
                txtEngine.ReadOnly = False
                txtFixedAssetNo.ReadOnly = False
                txtChassisSerialNo.ReadOnly = False
                txtStockCode.ReadOnly = False
                txtRequestedQty.ReadOnly = False
                btnSearchStockCode.Enabled = True
                dgvNonStockIPRDetails.Enabled = True
                lblUnitPriceValue.Text = String.Empty
                lblTotalValue.Text = String.Empty
                lblUnitValue.Text = String.Empty
                lblStockDesc.Text = String.Empty
                'lblAvailableValue.Text = String.Empty
                txtStockCode.Text = String.Empty
                txtRequestedQty.Text = String.Empty
                'dtpRequiredDate.Enabled = True
                'txtIPRNo.ReadOnly = True
                txtUsageCOACode.Enabled = False
                btnSearchUsageCOA.Enabled = False
                txtIPRNo.Enabled = False
            End If

        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub Edit_IPRView()
        Dim RequiredDate As String
        Me.cmsIPR.Visible = False
        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        Dim dt As New DataTable
        If dgvIRPView.Rows.Count > 0 Then
            Me.txtIPRNo.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRNo").Value.ToString()
            Dim str As String = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRdate").Value.ToString()
            Me.dtpIPRDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            'Me.txtCategory.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()
            'IPRPPT.strGlobalCategoryDesc = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()

            Me.txtCategory.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvCategoryCode").Value.ToString()
            IPRPPT.strGlobalCategoryDesc = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()

            Me.cmbClassification.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvClassification").Value.ToString()
            psIPRUsageCOAID = Me.dgvIRPView.SelectedRows(0).Cells("gvUsageCOAID").Value.ToString()
            Me.txtUsageCOACode.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvUsageCOACode").Value.ToString()
            Me.lblUsageCOADescp.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvUsageCOADescp").Value.ToString()
            Me.txtRequiredFor.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvRequiredFor").Value.ToString()
            Me.txtDeliveredTo.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvDeliveredTo").Value.ToString()
            Me.lblStatusDesc.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvMainStatus").Value.ToString()
            Me.txtMakeandModel.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvMakeModel").Value.ToString()
            Me.txtEngine.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvEngine").Value.ToString()
            Me.txtFixedAssetNo.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvFixedAssetNo").Value.ToString()
            Me.txtChassisSerialNo.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvChassisSerialNo").Value.ToString()
            Me.lblCategoryCode.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()

            If Not dgvIRPView.SelectedRows(0).Cells("gvRejectedReason").Value Is DBNull.Value Then
                lblRejectreasondesc.Text = dgvIRPView.SelectedRows(0).Cells("gvRejectedReason").Value.ToString()
                lblRejectReason.Visible = True
                lblcolon21.Visible = True
                lblRejectreasondesc.Visible = True
            Else
                lblRejectReason.Visible = False
                lblcolon21.Visible = False
                lblRejectreasondesc.Text = String.Empty
            End If
            IPRPPT.strGlobalCategoryCode = Me.dgvIRPView.SelectedRows(0).Cells("gvCategoryCode").Value.ToString()
            If Not Me.dgvIRPView.SelectedRows(0).Cells("gvlRequiredDate").Value Is DBNull.Value Then
                RequiredDate = Me.dgvIRPView.SelectedRows(0).Cells("gvlRequiredDate").Value.ToString()
                dtpRequiredDate.Text = New Date(RequiredDate.Substring(6, 4), RequiredDate.Substring(3, 2), RequiredDate.Substring(0, 2))
            Else
                dtpRequiredDate.Text = Date.Today
            End If
            ' Dim RequiredDate As String = Me.dgvIRPView.SelectedRows(0).Cells("gvlRequiredDate").Value.ToString()
            'dtpRequiredDate.Text = New Date(RequiredDate.Substring(6, 4), RequiredDate.Substring(3, 2), RequiredDate.Substring(0, 2))
            'txtD.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvD").Value.ToString()
            txtRemarks.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvRemarks").Value.ToString()
            lblCategoryCode.Visible = True
            lStockCategoryID = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategoryID").Value.ToString()
            IPRPPT.strGlobalCategoryID = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategoryID").Value.ToString()

            ''btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            DTFlag = True
            lSTIPRID = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRID").Value.ToString()
            dtpIPRDate.Enabled = False
            txtIPRNo.ReadOnly = True
            With objNonStockIPRPPT
                .STNonStockIPRID = lSTIPRID
            End With
            dtIPRDetails = objNonStockIPRBOL.GetNonStockIPRDetails(objNonStockIPRPPT)
            If dtIPRDetails.Rows.Count <> 0 Then
                gvlSTIPRDetID = dtIPRDetails.Rows(0).Item("STNonStockIPRDetID").ToString()
            End If
            'Me.dgvNonStockIPRDetails.Visible = False
            'Me.dgvNonStockIPRDetails.Visible = True
            Me.dgvNonStockIPRDetails.AutoGenerateColumns = False
            Me.dgvNonStockIPRDetails.DataSource = dtIPRDetails
            Enable_SingleEntry()
            txtCategory.ReadOnly = True
            btnSearchCategory.Enabled = False
            Me.tcIPR.SelectedTab = tbIPR

        Else
            DisplayInfoMessage("msg26")
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        AddIPR()
    End Sub

    Private Sub AddIPR()
        Me.tcIPR.SelectedTab = tbIPR
        txtCategory.ReadOnly = False
        txtIPRNo.Focus()
        btnSearchCategory.Enabled = True
        txtMakeandModel.ReadOnly = False
        txtEngine.ReadOnly = False
        txtChassisSerialNo.ReadOnly = False
        txtFixedAssetNo.ReadOnly = False
        txtStockCode.ReadOnly = False
        txtRequestedQty.ReadOnly = False
        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        btnSearchStockCode.Enabled = True
        ClearGridView(dgvNonStockIPRDetails)
        gbAddSingEntry.Visible = True
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        Enable_SingleEntry()
        dtpIPRDate.Format = DateTimePickerFormat.Custom
        dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpIPRDate)
        dtpIPRDate.Enabled = True
        ClearSingleEntry()
        clearMultiEntry()
        'toGetIPRNo()
        lblStatusDesc.Text = "OPEN"
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteIPRVIew()
    End Sub

    Private Sub DeleteIPRVIew()
        Me.cmsIPR.Visible = False

        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        Dim dt As New DataTable
        If dgvIRPView.Rows.Count > 0 Then
            If dgvIRPView.SelectedRows(0).Cells("gvMainStatus").Value = "OPEN" Then
                If MsgBox(rm.GetString("msg27"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Me.lSTIPRID = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRID").Value.ToString()
                    With objNonStockIPRPPT
                        .STNonStockIPRID = Me.lSTIPRID
                    End With
                    objNonStockIPRBOL.Delete_STNonStockIPRDetail(objNonStockIPRPPT)
                    GridIPRViewBind()
                End If
            Else
                DisplayInfoMessage("msg28")
                'MessageBox.Show("Not a valid record to delete, status must be OPEN ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("msg29")
            'MessageBox.Show(" No Records to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgvIRPView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIRPView.KeyDown
        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
    End Sub

    Private Sub dgvIRPView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvIRPView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvIRPView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvIRPView.ClearSelection()
                    Me.dgvIRPView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub txtUsageCOACode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsageCOACode.Leave
        If txtUsageCOACode.Text.Trim() <> String.Empty Then
            If txtUsageCOACode.Text.Trim.ToString.Length <> 13 Then
                DisplayInfoMessage("msg30")
                'MessageBox.Show("Please enter 13 digit Account code")
                txtUsageCOACode.Focus()
                Exit Sub
            End If

            Dim ds As New DataSet
            Dim objIPRPPT As New IPRPPT
            Dim objIPRBOL As New IPRBOL
            objIPRPPT.COACode = txtUsageCOACode.Text.Trim()
            ds = objIPRBOL.AcctlookupSearch(objIPRPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("msg31")
                'MessageBox.Show("Invalid Usage COA Account code,Please Choose it from look up")
                txtUsageCOACode.Text = String.Empty
                lblUsageCOADescp.Text = String.Empty
                psIPRUsageCOAID = String.Empty
                ''GlobalPPT.psAcctExpenditureType = String.Empty
                txtUsageCOACode.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("COACode") Is DBNull.Value Then
                    txtUsageCOACode.Text = ds.Tables(0).Rows(0).Item("COACode")
                Else
                    txtUsageCOACode.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("COADescp") Is DBNull.Value Then
                    lblUsageCOADescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
                Else
                    lblUsageCOADescp.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("COAID") Is DBNull.Value Then
                    psIPRUsageCOAID = ds.Tables(0).Rows(0).Item("COAID")
                Else
                    psIPRUsageCOAID = String.Empty
                End If
                ''If Not ds.Tables(0).Rows(0).Item("ExpenditureAG") Is DBNull.Value Then
                ''    GlobalPPT.psAcctExpenditureType = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                ''    lsVDExpenditureAG = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                ''Else
                ''    GlobalPPT.psAcctExpenditureType = String.Empty
                ''    lsVDExpenditureAG = String.Empty
                ''End If

            End If
        Else
            txtUsageCOACode.Text = String.Empty
            lblUsageCOADescp.Text = String.Empty
            psIPRUsageCOAID = String.Empty
            ''GlobalPPT.psAcctExpenditureType = String.Empty
        End If
    End Sub

    Private Sub txtCategory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCategory.Leave

        StrFrmName = "NonStockIPR"

        If Me.txtCategory.Text.Trim = String.Empty Then

            Me.lblCategoryCode.Text = String.Empty
            txtCategory.Text = String.Empty
            Exit Sub

        ElseIf Me.txtCategory.Text.Trim <> String.Empty And btnCategoryClickFlag = False Then

            Dim dt As New DataTable
            Dim objStkCategoryPPT As New NonStockIPRPPT
            Dim objStkCategoryBOL As New NonStockIPRBOL

            objStkCategoryPPT.STCategory = Me.txtCategory.Text.Trim
            dt = objStkCategoryBOL.GetNonStockCategory(objStkCategoryPPT, "YES")


            If dt.Rows.Count > 0 Then

                Me.lblCategoryCode.Visible = True
                If dt.Rows(0).Item("STCategoryDescp") <> String.Empty Then
                    Me.lblCategoryCode.Text = dt.Rows(0).Item("STCategoryDescp").ToString()
                Else
                    Me.lblCategoryCode.Text = String.Empty
                End If

                'Me.lblCategoryCode.Text = dt.Rows(0).Item("STCategoryCode").ToString()
                lStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()

            Else

                DisplayInfoMessage("msg32")
                'MessageBox.Show("Invalid Category")
                txtCategory.Text = String.Empty
                Me.lblCategoryCode.Text = String.Empty
                Me.txtCategory.Focus()

            End If

        End If

        StrFrmName = String.Empty

    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim rowsAffected As Integer = 0
        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL
        If cbApprovalStatus.SelectedItem = String.Empty Then
            DisplayInfoMessage("msg33")
            'MessageBox.Show("Please select status to Approve")
        Else
            If cbApprovalStatus.SelectedItem = "REJECTED" And txtRejectedReason.Text = String.Empty Then
                DisplayInfoMessage("msg34")
                'MessageBox.Show("Please enter valid Rejected reason")
            Else
                With objNonStockIPRPPT
                    .STNonStockIPRID = lSTIPRID
                    '.IPRdate = lModifiedOn
                    .Status = cbApprovalStatus.SelectedItem.ToString()
                    .Remarks = txtRemarks.Text
                    .RejectedReason = txtRejectedReason.Text
                End With
                If MsgBox(rm.GetString("msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Approve the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    rowsAffected = objNonStockIPRBOL.Update_STNonStockIPRApproval(objNonStockIPRPPT)
                    If rowsAffected > 0 Then
                        DisplayInfoMessage("msg36")
                        'MessageBox.Show(" Confirmation Succeded ", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'Call TaskMonitor Update after successful approval -Start
                        Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                        Dim dsApprovalCheck As New DataSet
                        dsApprovalCheck = StoreMonthEndClosingBOL.ApprovalCheck(objStoreMonthEndClosingPPT)
                        'Call TaskMonitor Update after successful approval -End

                        InternalPurchaseRequisitionApprovalFrm.Refresh()

                        GlobalPPT.IsButtonClose = True
                        Me.Close()

                    Else
                        DisplayInfoMessage("msg37")
                        'MessageBox.Show(" Confirmation Failed ", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub NonStockIPRFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbApprovalStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbApprovalStatus.SelectedIndexChanged
        If cbApprovalStatus.SelectedItem = "REJECTED" Then
            lblRejectedReason.Visible = True
            txtRejectedReason.Visible = True
            lblColon15.Visible = True
            txtRejectedReason.Text = String.Empty
        Else
            lblRejectedReason.Visible = False
            txtRejectedReason.Visible = False
            lblColon15.Visible = False
            txtRejectedReason.Text = String.Empty

        End If
    End Sub

    Private Sub dtpIPRDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpIPRDate.ValueChanged

        If lblDays.Text <> String.Empty Then
            dtpRequiredDate.Text = dtpIPRDate.Value.AddDays(lblDays.Text)
        End If

    End Sub

    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click

        If dgvNonStockIPRDetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvNonStockIPRDetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else
            DeleteMultientrydatagrid()
        End If


    End Sub


    Private Sub DeleteMultientrydatagrid()



        lSTIPRDetID = dgvNonStockIPRDetails.SelectedRows(0).Cells("dgclSTIPRDetID").Value.ToString

        lDelete = 0
        If lSTIPRDetID <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lSTIPRDetID)


        End If
        Dim Dr As DataRow
        Dr = dtIPRDetails.Rows.Item(dgvNonStockIPRDetails.CurrentRow.Index)
        Dr.Delete()
        dtIPRDetails.AcceptChanges()
        lSTIPRDetID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objIPRPPT As New NonStockIPRPPT
        Dim objIPRBOL As New NonStockIPRBOL

        lDelete = DeleteMultientry.Count

        While (lDelete > 0)

            With objIPRPPT
                .STNonStockIPRDetID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntIPRDetailDelete As New Integer
            IntIPRDetailDelete = objIPRBOL.DeleteMultiEntryNonIPR(objIPRPPT)

            lDelete = lDelete - 1

        End While


    End Sub


    'Private Sub NonStockIPRFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    Dim mdiparent As New MDIParent
    '    If dgvNonStockIPRDetails.RowCount > 0 And mdiparent.strMenuID = "M164" Then

    '        If MsgBox(rm.GetString("msg41"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            'SaveAll()
    '        End If

    '    End If

    'End Sub

    Private Sub dgvIRPView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIRPView.CellContentClick

        If e.ColumnIndex = 21 Then

            Dim ObjRecordExist As New Object
            Dim objNonStockIPRPPT As New NonStockIPRPPT
            Dim objNonStockIPRBOL As New NonStockIPRBOL
            ObjRecordExist = objNonStockIPRBOL.STNonStockIPRRecordIsExist(objNonStockIPRPPT)

            If ObjRecordExist = 0 Then
                DisplayInfoMessage("msg25")
                'MsgBox("No Record(s) Available!")
            Else
                psNonIPRID = dgvIRPView.SelectedRows(0).Cells("gvIPRID").Value.ToString
                StrFrmName = "NonStockIPR"
                ReportODBCMethod.ShowDialog()
                StrFrmName = ""
                psNonIPRID = ""
            End If

        End If

    End Sub

    Private Sub txtRequestedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestedQty.TextChanged

        If Val(txtRequestedQty.Text) > 0 Then
            txtRequestedQty.Text = Format(Val(txtRequestedQty.Text), "0")
        End If

    End Sub

    Private Sub EditMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMenuItem.Click

        BindIPRDetailsGrid()

    End Sub

    Private Sub chkIPRdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIPRdate.CheckedChanged

        If chkIPRdate.Checked = True Then
            dtpviewIPRDate.Enabled = True
        Else
            dtpviewIPRDate.Enabled = False
        End If

    End Sub


    'Private Sub NonStockIPRFrm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave

    '    MenuChange()

    'End Sub


    'Private Sub NonStockIPRFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    MenuChange()
    'End Sub

    'Private Sub MenuChange()

    '    Dim MdiParent As New MDIParent
    '    If (MdiParent.strMenuID = "M164" And dgvNonStockIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) Then
    '        If MsgBox(rm.GetString("msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            cmbStatus.Text = "OPEN"
    '            GridIPRViewBind()
    '            MdiParent.strIsMenuChange = "OK"
    '        Else
    '            tcIPR.SelectedTab = tbIPR
    '            MdiParent.strIsMenuChange = "Cancel"
    '            'Exit Sub 
    '        End If
    '    Else
    '        cmbStatus.Text = "OPEN"
    '        GridIPRViewBind()
    '    End If

    'End Sub

    Private Sub NonStockIPRFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (mdiparent.strMenuID = "M164" And dgvNonStockIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M164"
                'mdiparent.lblMenuName.Text = "Non-IPR"
            End If
        End If

    End Sub

End Class