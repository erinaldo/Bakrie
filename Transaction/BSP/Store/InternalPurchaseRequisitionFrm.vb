Imports System.Globalization
Imports XML.Generator
Imports XML.Generator.Domain
Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient

Public Class InternalPurchaseRequisitionFrm

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
    Public DTFlag As Boolean = False
    Private AddFlag As Boolean = True
    Public Shared StrFrmName As String = String.Empty
    Public lclassifiaction As String = String.Empty

    Public lModifiedOn As String = String.Empty
    Public strMenuID As String = String.Empty
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")

    Dim dtIPRDetails As New DataTable("todgvIPRDetails")
    Dim columnIPRDetails As DataColumn
    Dim rowIPRDetails As DataRow
    Shadows mdiparent As New MDIParent
    Public psIPRUsageCOAID As String = String.Empty
    Dim lsVDExpenditureAG As String = String.Empty
    Public btnCategoryClickFlag = False

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionFrm))

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Public Shared psIPRID As String = String.Empty

    Private Sub InternalPurchaseRequisitionFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub VisibilityLastPurchasenTotalPrice(Optional _value As Boolean = False)
        lblUnitPrice.Visible = _value
        lblColonLastPurchasePrice.Visible = _value
        lblUnitPriceValue.Visible = _value
        lblTotalPrice.Visible = _value
        lblColonTotalPrice.Visible = _value
        lblTotalValue.Visible = _value
        lblLastPurchahes.Visible = _value
        lbllast.Visible = _value
        lblColonLast.Visible = _value
        dgvIPRDetails.Columns.Item("dgclUnitPrice").Visible = _value
        dgvIPRDetails.Columns.Item("dgclTotalPrice").Visible = _value
        dgvIPRDetails.Columns.Item("dgvLastPurchasePrice").Visible = _value
    End Sub

    Private Sub InternalPurchaseRequisitionFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim checkVisibility = InternalPurchaseRequisitionApprovalFrm.Visibility
        'If (checkVisibility = False) Then
        '    VisibilityLastPurchasenTotalPriceFalse()
        'Else
        '    VisibilityLastPurchasenTotalPriceTrue()
        '    lblUnitPriceValue.Text = String.Empty
        '    lblTotalValue.Text = String.Empty
        'End If
        If (Not hasLoadVisibility) Then
            VisibilityLastPurchasenTotalPrice()
        End If

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        If mdiparent.strMenuID = "M1" Then
            txtCategory.Enabled = True
            dtpIPRDate.Format = DateTimePickerFormat.Custom
            dtpIPRDate.CustomFormat = "dd/MM/yyyy"
            dtpviewIPRDate.Format = DateTimePickerFormat.Custom
            dtpviewIPRDate.CustomFormat = "dd/MM/yyyy"
            dtpRequiredDate.Format = DateTimePickerFormat.Custom
            dtpRequiredDate.CustomFormat = "dd/MM/yyyy"
            dtpRequiredDate.Enabled = True
            GlobalBOL.SetDateTimePicker(Me.dtpIPRDate)
            GlobalBOL.SetDateTimePicker(Me.dtpviewIPRDate)
            lblStockDesc.Visible = False
            lblCategoryCode.Visible = False
            'lblTotalValue.Visible = False
            lblUnitValue.Visible = False
            'lblUnitPriceValue.Visible = False
            lblUnitValue.Visible = False
            lblAvailableValue.Visible = False
            lblPartnovalue.Visible = False
            lblMinQtyValue.Visible = False
            toGetIPRNo()
            Enable_SingleEntry()
            cmbStatus.Text = "OPEN"
            GridIPRViewBind()
            tcIPR.SelectedTab = tbView
            SetUICulture(GlobalPPT.strLang)
            gbApproval.Visible = False
            btnConfirm.Visible = False
            txtCategory.Focus()
            bind_cmbClassification()
            lblDay.Visible = False
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
            'lblTotalValue.Visible = False
            lblUnitValue.Visible = False
            'lblUnitPriceValue.Visible = False
            lblUnitValue.Visible = False
            lblAvailableValue.Visible = False
            lblPartnovalue.Visible = False
            lblMinQtyValue.Visible = False
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
            'bind_cmbClassification()
            SetUICulture(GlobalPPT.strLang)
            txtRejectedReason.Text = String.Empty
        End If
    End Sub

    Private Sub toloadIPR_inApproval()
        Dim MdiParent As New MDIParent

        If MdiParent.strMenuID = "M12" Then
            tcIPR.SelectedTab = tbIPR
            tcIPR.TabPages.Remove(tbView)
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
            cmbClassification.Text = "-SELECT-"
        End If
    End Sub

    Private Sub cmbClassification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClassification.SelectedIndexChanged
        Dim dtDays As DataTable
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        If Not cmbClassification Is Nothing Then
            If (cmbClassification.SelectedIndex >= 0) Then
                lclassifiaction = cmbClassification.SelectedValue.ToString()
                objIPRPPT.Classification = lclassifiaction
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
                cmbClassification.Text = "-SELECT-"
            End If
        End If
        If lblDays.Text <> String.Empty Then
            dtpRequiredDate.Text = dtpIPRDate.Value.AddDays(lblDays.Text)
            lblDay.Visible = True
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

    Private Sub Enable_SingleEntry()
        'txtCategory.ReadOnly = False
        'btnSearchCategory.Enabled = True
        txtDeliveredTo.ReadOnly = False
        cmbClassification.Enabled = True
        txtUsageCOACode.ReadOnly = False
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Add_Clicked()
        'GlobalPPT.IsRetainFocus = True

    End Sub
    Private Sub Add_Clicked()

        If AddFlag = True Then
            If lblUnitPriceValue.Text.Trim <> String.Empty And txtStockCode.Text.Trim <> String.Empty Then
                CalcTotalValue()
            End If
            Insert_MultiEntry()

        Else
            Update_MultiEntry()
        End If


    End Sub
    Private Sub Insert_MultiEntry()

        If Not IsFormValidAdd() Then Exit Sub

        Dim intRowcount As Integer = dtIPRDetails.Rows.Count
        Dim i As Integer = dgvIPRDetails.Rows.Count
        AddFlag = True
        If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 
            rowIPRDetails = dtIPRDetails.NewRow()
            If intRowcount = 0 And DTFlag = False Then
                columnIPRDetails = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("AvailableQty", System.Type.[GetType]("System.Decimal"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
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
                columnIPRDetails = New DataColumn("STIPRDetID", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("MinQty", System.Type.[GetType]("System.Decimal"))
                dtIPRDetails.Columns.Add(columnIPRDetails)
                columnIPRDetails = New DataColumn("LastPurchasePrice", System.Type.[GetType]("System.Decimal"))
                dtIPRDetails.Columns.Add(columnIPRDetails)

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
                If lblAvailableValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
                Else
                    rowIPRDetails("AvailableQty") = 0
                End If
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
                    rowIPRDetails("STIPRDetID") = lSTIPRDetID
                Else
                    rowIPRDetails("STIPRDetID") = String.Empty
                End If
                If lblPartnovalue.Text.Trim <> String.Empty Then
                    rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
                Else
                    rowIPRDetails("PartNo") = String.Empty
                End If
                If lblMinQtyValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("MinQty") = CDbl(lblMinQtyValue.Text)
                    'Format(Val(txtRequestedQty.Text), "0")
                Else
                    rowIPRDetails("MinQty") = 0
                End If

                If lblLastPurchahes.Text.Trim <> String.Empty Then
                    rowIPRDetails("LastPurchasePrice") = CDbl(lblLastPurchahes.Text)
                Else
                    rowIPRDetails("LastPurchasePrice") = 0
                End If

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
                If lblAvailableValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
                Else
                    rowIPRDetails("AvailableQty") = 0
                End If
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
                    rowIPRDetails("STIPRDetID") = lSTIPRDetID
                Else
                    rowIPRDetails("STIPRDetID") = String.Empty
                End If
                If lblPartnovalue.Text.Trim <> String.Empty Then
                    rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
                Else
                    rowIPRDetails("PartNo") = String.Empty
                End If
                If lblMinQtyValue.Text.Trim <> String.Empty Then
                    rowIPRDetails("MinQty") = CDbl(lblMinQtyValue.Text)
                Else
                    rowIPRDetails("MinQty") = 0
                End If

                If lblLastPurchahes.Text.Trim <> String.Empty Then
                    rowIPRDetails("LastPurchasePrice") = CDbl(lblLastPurchahes.Text)
                Else
                    rowIPRDetails("LastPurchasePrice") = 0
                End If

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
            With dgvIPRDetails
                .AutoGenerateColumns = False
                .DataSource = dtIPRDetails
                clearMultiEntry()
                Disable_SingleEntry()
                txtMakeandModel.Focus()
            End With
        Else
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg02")
        End If
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub Update_MultiEntry()
        If Not IsFormValidAdd() Then Exit Sub
        Dim strStCode As String = txtStockCode.Text.ToString()
        For i As Integer = 0 To dgvIPRDetails.Rows.Count - 1
            If i <> dgvIPRDetails.CurrentRow.Index Then
                If strStCode = dgvIPRDetails.Rows(i).Cells("dgclStockCode").Value.ToString() Then
                    MsgBox("Stock Code already exist in this TN-IN Details")
                    clearMultiEntry()
                    txtStockCode.Focus()
                    Exit Sub
                End If
            Else
            End If
        Next
        If strStCode = dgvIPRDetails.CurrentRow.Cells("dgclStockCode").Value.ToString() Then
        End If

        Dim dgvrow As Integer
        Dim Str As String = dgvIPRDetails.Columns.Item(1).Name
        If AddFlag = False And dgvIPRDetails.Rows.Count > 0 Then
            dgvrow = dgvIPRDetails.CurrentRow.Index
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
            If lblAvailableValue.Text.Trim <> String.Empty Then
                rowIPRDetails("AvailableQty") = lblAvailableValue.Text.ToString()
            Else
                rowIPRDetails("AvailableQty") = 0
            End If
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
                rowIPRDetails("STIPRDetID") = lSTIPRDetID
            Else
                rowIPRDetails("STIPRDetID") = String.Empty
            End If
            If lblPartnovalue.Text.Trim <> String.Empty Then
                rowIPRDetails("PartNo") = lblPartnovalue.Text.ToString()
            Else
                rowIPRDetails("PartNo") = String.Empty
            End If
            If lblMinQtyValue.Text.Trim <> String.Empty Then
                rowIPRDetails("MinQty") = CDbl(lblMinQtyValue.Text)
            Else
                rowIPRDetails("MinQty") = 0
            End If
            dtIPRDetails.Rows.InsertAt(rowIPRDetails, dgvrow)
            dgvIPRDetails.DataSource = dtIPRDetails
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            clearMultiEntry()
            AddFlag = True
        End If
    End Sub

    Private Sub clearMultiEntry()

        txtStockCode.Text = String.Empty
        txtStockCode.ReadOnly = False
        btnSearchStockCode.Enabled = True
        lblStockDesc.Text = String.Empty
        lblAvailableValue.Text = String.Empty
        lblUnitValue.Text = String.Empty
        lblUnitPriceValue.Text = String.Empty
        lblLastPurchahes.Text = String.Empty
        txtRequestedQty.Text = String.Empty
        txtRequestedQty.ReadOnly = False
        lblPartnovalue.Text = String.Empty
        lblMinQtyValue.Text = String.Empty
        lStockID = String.Empty
        'lSTITNInDetID = String.Empty
        Me.lblTotalValue.Text = String.Empty
        txtCategory.Enabled = True
        btnSearchCategory.Enabled = True
        txtMakeandModel.ReadOnly = False
        txtFixedAssetNo.ReadOnly = False
        txtChassisSerialNo.ReadOnly = False
        txtEngine.ReadOnly = False
        btnSaveAll.Enabled = True
        'dtpRequiredDate.Enabled = True
        gbAddSingEntry.Visible = True
        'btnAdd.Text = "Add"
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

    Private Function StockCodeExist(ByVal StockCode As String) As Boolean
        Dim objDataGridViewRow As New DataGridViewRow
        If AddFlag = True Then
            For Each objDataGridViewRow In dgvIPRDetails.Rows
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

    Private Function IsFormValidAdd()

        If (dtpRequiredDate.Value.Date) <= (dtpIPRDate.Value.Date) Then
            'MessageBox.Show(" Required date must be greater than IPRDate ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg03")
            dtpRequiredDate.Focus()
            Return False
        End If

        If txtIPRNo.Text.Trim = String.Empty Then
            'MessageBox.Show("IPR No. Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg10")
            txtIPRNo.Focus()
            Return False
        End If


        ''If txtUsageCOACode.Text = String.Empty Then
        ''    MessageBox.Show("Usage COA Code field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    txtUsageCOACode.Focus()
        ''    Return False
        ''End If
        If txtCategory.Text.Trim = String.Empty Then
            'MessageBox.Show("Category field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg05")
            txtCategory.Focus()
            Return False

        End If

        If lblCategoryCode.Text.Trim = String.Empty Then
            'MessageBox.Show("Category Code missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg04")
            Return False
        End If

        'If cmbClassification.Text.Trim = String.Empty Then
        '    'MessageBox.Show("Classification Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DisplayInfoMessage("msg36")
        '    cmbClassification.Focus()
        '    Return False
        'End If

        'If txtUsageCOACode.Text.Trim = String.Empty Then
        '    'MessageBox.Show("Usage COA Code Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DisplayInfoMessage("msg38")
        '    txtUsageCOACode.Focus()
        '    Return False
        'End If

        If txtStockCode.Text.Trim = String.Empty Then
            'MessageBox.Show("Stock Code Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg06")
            txtStockCode.Focus()
            Return False
        End If
        If lblStockDesc.Text.Trim = String.Empty Then
            'MessageBox.Show("Stock Description missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg07")
            Return False
        End If
        If txtRequestedQty.Text.Trim = String.Empty Then
            'MessageBox.Show("Requested Quantity missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg08")
            txtRequestedQty.Focus()
            Return False
        End If
        If lblUnitPriceValue.Text.Trim = String.Empty Then
            'MessageBox.Show("Unit price missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg09")
            Return False
        End If
        'If lblAvailableValue.Text.Trim = String.Empty Then
        '    lblAvailableValue.Text = "0"
        '    MessageBox.Show("due to Null value of Avilable Qty assigened zero by default", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    'Return False
        'End If

        'If cmbClassification.Text.Trim = String.Empty Then
        '    'MessageBox.Show("Classification Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DisplayInfoMessage("msg36")
        '    Return False
        'End If

        'If txtUsageCOACode.Text.Trim = String.Empty Then
        '    'MessageBox.Show("Usage COA Code Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DisplayInfoMessage("msg38")
        '    txtUsageCOACode.Focus()
        '    Return False
        'End If

        Return True

    End Function

    Private Function IsFormValidSaveAll()

        If txtIPRNo.Text.Trim = String.Empty Then
            'MessageBox.Show("IPR No. Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg10")
            txtIPRNo.Focus()
            Return False
        End If
        If (dtpRequiredDate.Value.Date) <= (dtpIPRDate.Value.Date) Then
            'MessageBox.Show(" Required date must be greater than IPRDate ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg13")
            Return False
        End If
        If txtCategory.Text = String.Empty Then
            'MessageBox.Show("Category field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg05")
            txtCategory.Focus()
            Return False
        End If
        'If cmbClassification.Text.Trim = String.Empty Then
        '    'MessageBox.Show("Classification Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DisplayInfoMessage("msg36")
        '    cmbClassification.Focus()
        '    Return False
        'End If

        'If txtUsageCOACode.Text.Trim = String.Empty Then
        '    'MessageBox.Show("Usage COA Code Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    DisplayInfoMessage("msg38")
        '    txtUsageCOACode.Focus()
        '    Return False
        'End If

        If dgvIPRDetails.Rows.Count = 0 Then
            'MessageBox.Show("Stock Items Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg12")
            txtStockCode.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub toGetIPRNo()
        Dim objStorePPT As New IPRPPT
        Dim objStoreBOL As New IPRBOL
        Dim PRNo As String
        objStorePPT = objStoreBOL.GetIPRNo(objStorePPT)
        PRNo = objStoreBOL.GetPRAutoNo()
        txtIPRNo.Text = PRNo
        With objStorePPT
            If .IPRNo <> String.Empty Then
                'Me.txtIPRNo.Text = .IPRNo
            Else
                'MessageBox.Show("IPR Deatils Missing in STConfiguration Table", "Failed to generate IPR No.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DisplayInfoMessage("msg14")
            End If
        End With
    End Sub


    Private Sub txtRequestedQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestedQty.Leave
        If lblUnitPriceValue.Text.Trim <> String.Empty And txtStockCode.Text.Trim <> String.Empty Then
            CalcTotalValue()
        End If
        ''If lblUnitPriceValue.Text.Trim <> String.Empty And txtStockCode.Text.Trim <> String.Empty Then

        ''    If Me.txtStockCode.Text = Nothing Then
        ''        Me.txtStockCode.Focus()
        ''        'MessageBox.Show("Stock code required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''        Exit Sub
        ''    Else
        ''        If Me.txtRequestedQty.Text = Nothing Then
        ''            Me.lblTotalValue.Text = String.Empty
        ''            Exit Sub
        ''        Else
        ''            Me.lblTotalValue.Visible = True
        ''            Me.lblTotalValue.Text = CDec(Convert.ToDecimal(lblUnitPriceValue.Text) * Convert.ToDecimal(txtRequestedQty.Text))
        ''            Me.lblTotalValue.Text = Decimal.Round(CDec(Me.lblTotalValue.Text), 2)
        ''        End If
        ''    End If
        ''Else
        ''    'MessageBox.Show("UnitPrice required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    Exit Sub
        ''End If
        ConvertToDecimal2(txtRequestedQty)
    End Sub

    Function ConvertToDecimal2(text As TextBox) As String
        If Not String.IsNullOrEmpty(text.Text) Then
            Dim convert As Decimal = Math.Round(System.Convert.ToDouble(text.Text), 2)
            text.Text = convert.ToString()

        End If
    End Function

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
                    'Me.lblTotalValue.Visible = True
                    Me.lblTotalValue.Text = CDec(Convert.ToDecimal(lblUnitPriceValue.Text) * Convert.ToDecimal(txtRequestedQty.Text))
                    Me.lblTotalValue.Text = Decimal.Round(CDec(Me.lblTotalValue.Text), 2)
                Else
                    'MessageBox.Show("UnitPrice required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DisplayInfoMessage("msg15")
                    Exit Sub
                End If

            End If
        End If

        'MessageBox.Show("UnitPrice required ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click


        SaveAll()

        'If Not IsFormValidSaveAll() Then Exit Sub

        'Dim rowsAffected As Integer = 0
        'Dim dt As New DataTable
        'Dim objIPRPPT As New IPRPPT
        'Dim objIPRBOL As New IPRBOL

        'With objIPRPPT
        '    .IPRdate = dtpIPRDate.Value
        '    .DeliveredTo = txtDeliveredTo.Text.Trim
        '    .IPRNo = txtIPRNo.Text.Trim
        '    .Classification = lblClassificationID.Text 'cmbClassification.Text.Trim
        '    .STCategoryID = lStockCategoryID 'STCategoryID
        '    .RequiredFor = txtRequiredFor.Text.Trim
        '    .RequiredDate = dtpRequiredDate.Value
        '    '.D = txtD.Text
        '    .MainStatus = "OPEN"
        '    .MakeModel = txtMakeandModel.Text.Trim
        '    .Engine = txtEngine.Text.Trim
        '    .ChassisSerialNo = txtChassisSerialNo.Text.Trim
        '    .FixedAssetNo = txtFixedAssetNo.Text.Trim
        '    .Remarks = txtRemarks.Text
        '    .COAID = psIPRUsageCOAID
        '    .STIPRID = lSTIPRID 'lSTIPRID to differentiate for update
        'End With

        'If lSTIPRID = "" Then
        '    dt = objIPRBOL.Save_IPR(objIPRPPT)
        '    If dt.Rows.Count > 0 Then
        '        lSTIPRID = dt.Rows(0).Item("STIPRID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
        '    Else
        '        'MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        DisplayInfoMessage("msg16")
        '        rowsAffected = objIPRBOL.Delete_IPRDetail(objIPRPPT)
        '        Exit Sub
        '    End If
        'Else
        '    DeleteMultiEntryRecords()
        '    rowsAffected = objIPRBOL.Update_IPR(objIPRPPT)

        '    If rowsAffected = 1 Then
        '    Else
        '        'MessageBox.Show("Failed to update Records", "Error occured in updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        DisplayInfoMessage("msg17")
        '        Exit Sub
        '    End If
        'End If

        'Dim arrayListInfo As New ArrayList()
        'Dim DataGridViewRow As DataGridViewRow
        'For Each DataGridViewRow In dgvIPRDetails.Rows
        '    With objIPRPPT
        '        .stockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
        '        .RequestedQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
        '        .UnitPrice = CDbl(DataGridViewRow.Cells("dgclUnitPrice").Value.ToString())
        '        .Status = lblStatusDesc.Text
        '        .RejectedReason = txtRejectedReason.Text
        '        .value = DataGridViewRow.Cells("dgclTotalPrice").Value.ToString()
        '        .AvailableQty = DataGridViewRow.Cells("dgclAvailableQty").Value.ToString()
        '        .RequestedQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
        '        .PendingQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
        '        .STIPRID = lSTIPRID
        '        .STIPRDetID = DataGridViewRow.Cells("dgclSTIPRDetID").Value.ToString() 'to differentiate for update
        '    End With
        '    If objIPRPPT.STIPRDetID = "" Then
        '        rowsAffected = objIPRBOL.Save_IPRDetail(objIPRPPT)
        '    Else
        '        rowsAffected = objIPRBOL.Update_IPRDetail(objIPRPPT)
        '    End If
        'Next
        'If rowsAffected = 1 Then
        '    If objIPRPPT.STIPRDetID = "" Then
        '        'MessageBox.Show("Records inserted Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        DisplayInfoMessage("msg18")
        '    Else
        '        'MessageBox.Show("Records updated Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        DisplayInfoMessage("msg19")
        '    End If
        'Else
        '    'MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    DisplayInfoMessage("msg20")
        '    rowsAffected = objIPRBOL.Delete_IPRDetail(objIPRPPT)

        'End If
        'Enable_SingleEntry()
        'ClearGridView(dgvIPRDetails)
        ''btnSaveAll.Text = "Save All"
        'If GlobalPPT.strLang = "en" Then
        '    btnSaveAll.Text = "Save All"
        'ElseIf GlobalPPT.strLang = "ms" Then
        '    btnSaveAll.Text = "Simpan Semua"
        'End If

        'ClearSingleEntry()
        'toGetIPRNo()
        'clearMultiEntry()
        'txtCategory.ReadOnly = False
        'lblStatusDesc.Text = "OPEN"

    End Sub

    Private Sub SaveAll()

        If Not IsFormValidSaveAll() Then Exit Sub

        Dim rowsAffected As Integer = 0
        Dim dt As New DataTable
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL

        With objIPRPPT
            .IPRdate = dtpIPRDate.Value
            .MRCNo = txtMrcNo.Text.Trim()
            .DeliveredTo = txtDeliveredTo.Text.Trim
            .IPRNo = txtIPRNo.Text.Trim
            .Classification = lblClassificationID.Text 'cmbClassification.Text.Trim
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
            .STIPRID = lSTIPRID 'lSTIPRID to differentiate for update
        End With

        If lSTIPRID = "" Then
            dt = objIPRBOL.Save_IPR(objIPRPPT)
            If dt.Rows.Count > 0 Then
                lSTIPRID = dt.Rows(0).Item("STIPRID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
            Else
                'MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DisplayInfoMessage("msg16")
                rowsAffected = objIPRBOL.Delete_IPRDetail(objIPRPPT)
                Exit Sub
            End If
        Else
            DeleteMultiEntryRecords()
            rowsAffected = objIPRBOL.Update_IPR(objIPRPPT)

            If rowsAffected = 1 Then
            Else
                'MessageBox.Show("Failed to update Records", "Error occured in updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DisplayInfoMessage("msg17")
                Exit Sub
            End If
        End If

        Dim arrayListInfo As New ArrayList()
        Dim DataGridViewRow As DataGridViewRow
        For Each DataGridViewRow In dgvIPRDetails.Rows
            With objIPRPPT
                .stockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
                .RequestedQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
                .UnitPrice = CDbl(DataGridViewRow.Cells("dgclUnitPrice").Value.ToString())
                .Status = lblStatusDesc.Text
                .RejectedReason = txtRejectedReason.Text
                .value = DataGridViewRow.Cells("dgclTotalPrice").Value.ToString()
                .AvailableQty = DataGridViewRow.Cells("dgclAvailableQty").Value.ToString()
                .RequestedQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
                .PendingQty = CDbl(DataGridViewRow.Cells("dgclRequestedQty").Value.ToString())
                .STIPRID = lSTIPRID
                .STIPRDetID = DataGridViewRow.Cells("dgclSTIPRDetID").Value.ToString() 'to differentiate for update
            End With
            If objIPRPPT.STIPRDetID = "" Then
                rowsAffected = objIPRBOL.Save_IPRDetail(objIPRPPT)
            Else
                rowsAffected = objIPRBOL.Update_IPRDetail(objIPRPPT)
            End If
        Next
        If rowsAffected = 1 Then
            If objIPRPPT.STIPRDetID = "" Then
                'MessageBox.Show("Records inserted Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DisplayInfoMessage("msg18")
            Else
                'MessageBox.Show("Records updated Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DisplayInfoMessage("msg19")
            End If
        Else
            'MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisplayInfoMessage("msg20")
            rowsAffected = objIPRBOL.Delete_IPRDetail(objIPRPPT)

        End If
        Enable_SingleEntry()
        ClearGridView(dgvIPRDetails)
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        ClearSingleEntry()
        toGetIPRNo()
        clearMultiEntry()
        txtCategory.ReadOnly = False
        lblStatusDesc.Text = "OPEN"

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub BindIPRDetailsGrid()
        'Dim dtStock As DataTable
        Dim objIPRBOL As New IPRBOL
        Dim objPPT As New IPRPPT
        If dgvIPRDetails.Rows.Count > 0 Then
            'Me.btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
            Me.txtStockCode.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            If dgvIPRDetails.SelectedRows(0).Cells("dgclUnit").Value <> String.Empty Then
                Me.lblUnitValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclUnit").Value.ToString()
            End If
            'If dgvIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value = String.Empty Then
            Me.lblTotalValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value.ToString()
            'End If
            Me.lblUnitPriceValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
            Me.txtRequestedQty.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclRequestedQty").Value
            Me.lblStockDesc.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
            Me.lblAvailableValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
            lStockID = dgvIPRDetails.SelectedRows(0).Cells("dgclStockID").Value.ToString()
            lSTIPRDetID = dgvIPRDetails.SelectedRows(0).Cells("dgclSTIPRDetID").Value.ToString()
            lblPartnovalue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclPartNo").Value.ToString()
            lblMinQtyValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclMinimumQty").Value.ToString()
            lblLastPurchahes.Text = dgvIPRDetails.SelectedRows(0).Cells("dgvLastPurchasePrice").Value

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
            'Me.lblUnitPriceValue.Visible = True
            'Me.lblTotalValue.Visible = True
            Me.lblUnitValue.Visible = True
            Me.lblStockDesc.Visible = True
            lblCategoryCode.Visible = True
            lblAvailableValue.Visible = True
            lblPartnovalue.Visible = True
            lblMinQtyValue.Visible = True
        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub dgvIPRDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIPRDetails.KeyDown
        If e.KeyCode = Keys.Return Then
            BindIPRDetailsGrid()
            e.Handled = True
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearMultiEntry()
    End Sub

    Private Sub ResetAll()


        ClearGridView(dgvIPRDetails)
        'btnAdd.Text = "Add"
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
        toGetIPRNo()
        lblStatusDesc.Text = "OPEN"
        AddFlag = True
        txtCategory.ReadOnly = False
        lblClassificationID.Text = String.Empty
        psIPRUsageCOAID = String.Empty

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click

        ResetAll()


    End Sub

    Private Sub ClearSingleEntry()

        DeleteMultientry.Clear()

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
        lblDays.Text = String.Empty
        lblDay.Visible = False
        'txtD.Text = String.Empty
        lblCategoryCode.Visible = False
        dtpIPRDate.Enabled = True
        lSTIPRID = String.Empty
        lSTIPRDetID = String.Empty
        lbloldAccountCode.Text = String.Empty
        lblRejectReason.Visible = False
        lblcolon21.Visible = False
        lblRejectreasondesc.Text = String.Empty
    End Sub

    Private Sub GridIPRViewBind()
        dgvIRPView.DataSource = Nothing

        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        With objIPRPPT
            Dim str As String = cmbStatus.SelectedItem.ToString()

            'If cmbStatus.SelectedItem.ToString() = "SELECT ALL" Then
            'If chkIPRdate.Checked = True Then
            '    .IPRdate = Format(Me.dtpviewIPRDate.Value, "MM/dd/yyyy")
            'Else
            '    .IPRdate = Nothing
            'End If
            '.IPRNo = String.Empty
            '.DeliveredTo = String.Empty
            '.Classification = String.Empty
            '.RequiredFor = String.Empty
            '.STCategory = String.Empty
            '.MainStatus = String.Empty
            'Else

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

        dt = objIPRBOL.GetIPRDetails(objIPRPPT)
        If dt.Rows.Count <> 0 Then

            dgvIRPView.AutoGenerateColumns = False
            Me.dgvIRPView.DataSource = dt

            dgvIRPView.AutoGenerateColumns = False

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

    Public Sub ResetAllOnTabClick()
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
        dgvIPRDetails.Enabled = True
        ClearGridView(dgvIPRDetails)
        gbAddSingEntry.Visible = True
        'btnAdd.Text = "Add"
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
        toGetIPRNo()
        lblStatusDesc.Text = "OPEN"
        cmbClassification.Text = "-SELECT-"
        lblClassificationID.Text = String.Empty
        psIPRUsageCOAID = String.Empty

        dtpIPRDate.Focus()

    End Sub
    Private Sub tcIPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcIPR.Click

        If tcIPR.SelectedTab Is tbIPR = True Then
            If tcIPR.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgvIPRDetails.RowCount > 0 Then
                        If MsgBox(rm.GetString("msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ResetAllOnTabClick()
                        Else
                            Exit Sub
                        End If
                    Else
                        ResetAll()
                    End If
                End If
            Else
                Exit Sub '--if approval screen--'
            End If
        ElseIf tcIPR.SelectedTab Is tbView = True Then
            chkIPRdate.Focus()
            If (dgvIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And btnSaveAll.Enabled = True) Then
                If MsgBox(rm.GetString("msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    cmbStatus.Text = "OPEN"
                    GridIPRViewBind()
                    ClearGridView(dgvIPRDetails)
                    GlobalPPT.IsRetainFocus = False
                Else
                    tcIPR.SelectedTab = tbIPR
                End If
            Else
                ResetAll()
                cmbStatus.Text = "OPEN"
                GridIPRViewBind()
            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        End If
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub btnviewIPRdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objIPRPPT As New IPRPPT
        Dim objIPRView As New IPRViewLookUp()
        Dim Result As DialogResult = IPRViewLookUp.ShowDialog()

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

    Private Sub btnSearchCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCategory.Click

        btnCategoryClickFlag = True

        clearMultiEntry()
        Dim StockCategory As New CategoryLookup()
        'StockCategory.BindStockCategory()
        NonStockIPRFrm.StrFrmName = "IPR"
        Dim result As DialogResult = CategoryLookup.ShowDialog()

        If CategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then

            txtCategory.Text = String.Empty
            lblCategoryCode.Text = String.Empty
            txtCategory.Text = CategoryLookup._lStockCategoryCode
            lblCategoryCode.Text = CategoryLookup._lStockCategory
            lStockCategoryID = CategoryLookup._lStockCategoryID
            IPRPPT.strGlobalCategoryID = CategoryLookup._lStockCategoryID

            If txtCategory.Text <> String.Empty And lblCategoryCode.Text <> String.Empty Then

                Me.lblCategoryCode.Visible = True
                'Me.txtRequiredFor.Focus()
                cmbClassification.Focus()
            Else

                txtCategory.Text = String.Empty
                lblCategoryCode.Text = String.Empty
                'MessageBox.Show(" Invalid category  ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DisplayInfoMessage("msg21")
                txtCategory.Focus()

            End If

        End If

        btnCategoryClickFlag = False

    End Sub

    Private Sub txtCategory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCategory.Leave

        NonStockIPRFrm.StrFrmName = "IPR"

        If Me.txtCategory.Text.Trim = String.Empty Then

            Me.lblCategoryCode.Text = String.Empty
            txtCategory.Text = String.Empty
            Exit Sub

        ElseIf Me.txtCategory.Text.Trim <> String.Empty And btnCategoryClickFlag = False Then

            Dim dt As New DataTable
            Dim CategoryDesc As String
            Dim objIPRPPT As New StoreIssueVoucherPPT
            Dim objIPRData As New StoreIssueVoucherBOL
            CategoryDesc = Me.txtCategory.Text.Trim
            dt = objIPRData.StockCategorySearch(CategoryDesc)

            If dt.Rows.Count > 0 Then

                Me.lblCategoryCode.Visible = True
                Me.lblCategoryCode.Text = dt.Rows(0).Item("STCategoryDescp").ToString()
                lStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()
                IPRPPT.strGlobalCategoryID = dt.Rows(0).Item("STCategoryID").ToString()

            Else

                'MessageBox.Show("Invalid Category")
                DisplayInfoMessage("msg22")
                txtCategory.Text = String.Empty
                Me.lblCategoryCode.Text = String.Empty
                Me.txtCategory.Focus()

            End If

        End If

    End Sub

    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click

        Me.Cursor = Cursors.WaitCursor
        GlobalPPT.IsStockCategory = True
        If Me.txtCategory.Text = String.Empty Then
            'MessageBox.Show("Category field Required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg23")
            txtCategory.Focus()
        Else
            Dim stockDt As New DataTable
            Dim ObjStockBOL As New IPRBOL
            Dim ObjStockCode As New IPRPPT
            Dim StockCategory As New StockCodeLookUp()

            Dim result As DialogResult = StockCodeLookUp.ShowDialog()

            If StockCodeLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
                txtStockCode.Text = StockCodeLookUp._lStockCode
                lblStockDesc.Text = StockCodeLookUp._lStockDesc
                lblUnitPriceValue.Text = StockCodeLookUp._lStockUnitprice
                lblLastPurchahes.Text = StockCodeLookUp._lStockLastPurchasePrice
                lblUnitValue.Text = StockCodeLookUp._lUnit
                lStockID = StockCodeLookUp._lStockID
                lblAvailableValue.Text = StockCodeLookUp._lAvailableQty
                lblMinQtyValue.Text = StockCodeLookUp._lMinQty
                lblPartnovalue.Text = StockCodeLookUp._lPartNo
                lblMinQtyValue.Text = StockCodeLookUp._lMinQty
                'ObjStockCode.stockID = StockCodeLookUp._lStockID
                'If Me.lStockID <> String.Empty Then
                '    stockDt = ObjStockBOL.GetAvailableQTy(ObjStockCode)
                '    If stockDt.Rows.Count <> 0 Then
                '        Me.lblUnitPriceValue.Text = Convert.ToInt32(stockDt.Rows(0).Item("UnitPrice")).ToString()
                '        Me.lblAvailableValue.Text = stockDt.Rows(0).Item("AvailableQty").ToString()
                '        If lblAvailableValue.Text = String.Empty Then
                '            lblAvailableValue.Text = "0"
                '        End If
                '    End If
                'End If
                lblStockDesc.Visible = True
                'lblUnitPriceValue.Visible = True
                lblUnitValue.Visible = True
                lblAvailableValue.Visible = True
                lblPartnovalue.Visible = True
                lblMinQtyValue.Visible = True

                'txtStockCode.Text = lStockCode
                'lblStockDesc.Text = lStockDesc
                'lblUnitValue.Text = lUnit
                txtRequestedQty.Focus()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave

        If txtStockCode.Text = String.Empty Then

            Me.lblUnitValue.Text = String.Empty
            Me.lblStockDesc.Text = String.Empty
            Me.lblUnitPriceValue.Text = String.Empty
            Me.lblTotalValue.Text = String.Empty
            Me.lblAvailableValue.Text = String.Empty
            Me.lblPartnovalue.Text = String.Empty

            Exit Sub

        End If

        Dim dt As New DataTable
        Dim dtStock As New DataTable
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        objIPRPPT.STCategoryCode = Me.lblCategoryCode.Text
        objIPRPPT.STCategory = Me.txtCategory.Text
        objIPRPPT.STCategoryID = lStockCategoryID
        objIPRPPT.StockCode = Me.txtStockCode.Text
        dt = objIPRBOL.StockCodeSearch(objIPRPPT)

        If dt.Rows.Count <> 0 Then

            lStockID = dt.Rows(0).Item("StockId").ToString()
            Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString()
            Me.lblStockDesc.Text = dt.Rows(0).Item("StockDesc").ToString()
            Me.lblUnitValue.Text = dt.Rows(0).Item("UOM").ToString()
            If Not dt.Rows(0).Item("AvailableQty") Is DBNull.Value Then
                lblAvailableValue.Text = CDbl(dt.Rows(0).Item("AvailableQty"))
            Else
                lblAvailableValue.Text = String.Empty
            End If

            If Not dt.Rows(0).Item("LastPurchasePrice") Is DBNull.Value Then
                lblUnitPriceValue.Text = CDbl(dt.Rows(0).Item("LastPurchasePrice"))
            Else
                lblUnitPriceValue.Text = String.Empty
            End If


            If Not dt.Rows(0).Item("PartNo") Is DBNull.Value Then
                lblPartnovalue.Text = dt.Rows(0).Item("PartNo")
            Else
                lblPartnovalue.Text = String.Empty
            End If

            If Not dt.Rows(0).Item("MinQty") Is DBNull.Value Then
                lblMinQtyValue.Text = CDbl(dt.Rows(0).Item("MinQty"))
            Else
                lblMinQtyValue.Text = String.Empty
            End If

            lblAvailableValue.Visible = True
            'lblUnitPriceValue.Visible = True
            Me.lblUnitValue.Visible = True
            Me.lblStockDesc.Visible = True
            'Me.lblTotalValue.Visible = True
            lblPartnovalue.Visible = True
            lblMinQtyValue.Visible = True

        Else

            'MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg24")
            txtStockCode.Text = String.Empty
            txtStockCode.Focus()

        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GridIPRViewBind()
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

                        If txtBox.Text.Trim.Contains(".") Then
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

    Private Sub dgvIPRDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRDetails.CellDoubleClick

        BindIPRDetailsGrid()

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
                dgvIPRDetails.Enabled = False
                If dgvIPRDetails.RowCount > 0 Then
                    txtStockCode.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
                    If dgvIPRDetails.SelectedRows(0).Cells("dgclUnit").Value <> String.Empty Then
                        lblUnitValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclUnit").Value.ToString()
                    End If
                    lblTotalValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclTotalPrice").Value.ToString()
                    lblUnitPriceValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
                    txtRequestedQty.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclRequestedQty").Value.ToString()
                    lblStockDesc.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
                    lblAvailableValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
                    lblPartnovalue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclPartNo").Value.ToString()
                    lblMinQtyValue.Text = dgvIPRDetails.SelectedRows(0).Cells("dgclMinimumQty").Value.ToString()
                End If
                'lblUnitPriceValue.Visible = True
                'lblTotalValue.Visible = True
                lblUnitValue.Visible = True
                lblStockDesc.Visible = True
                lblCategoryCode.Visible = True
                lblAvailableValue.Visible = True
                lblPartnovalue.Visible = True
                lblMinQtyValue.Visible = True
                'dtpRequiredDate.Enabled = False
            Else

                btnSaveAll.Enabled = True
                btnResetAll.Enabled = True

                Edit_IPRView()
                If cmbClassification.Text = String.Empty Then
                    lblDay.Text = String.Empty
                    lblDays.Text = String.Empty
                End If

                gbAddSingEntry.Visible = True
                txtMakeandModel.ReadOnly = False
                txtEngine.ReadOnly = False
                txtFixedAssetNo.ReadOnly = False
                txtChassisSerialNo.ReadOnly = False
                txtStockCode.ReadOnly = False
                txtRequestedQty.ReadOnly = False
                btnSearchStockCode.Enabled = True
                dgvIPRDetails.Enabled = True
                lblUnitPriceValue.Text = String.Empty
                lblTotalValue.Text = String.Empty
                lblUnitValue.Text = String.Empty
                lblStockDesc.Text = String.Empty
                lblAvailableValue.Text = String.Empty
                txtStockCode.Text = String.Empty
                txtRequestedQty.Text = String.Empty
                'dtpRequiredDate.Enabled = True
            End If
        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

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

    Private Sub btnviewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCategory.Click

        Dim StockCategory As New CategoryLookup()
        StockCategory.BindStockCategory()
        NonStockIPRFrm.StrFrmName = "IPR"

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

    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click

        Dim ObjRecordExist As New Object
        Dim ObjIPRPPT As New IPRPPT
        Dim ObjIPRBOL As New IPRBOL
        ObjRecordExist = ObjIPRBOL.IPRRecordIsExisT(ObjIPRPPT)

        If ObjRecordExist = 0 Then
            'MsgBox("No Record(s) Available!")
            DisplayInfoMessage("msg25")
        Else
            StrFrmName = "IPR"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub

    Private Sub AddIPR()
        Me.tcIPR.SelectedTab = tbIPR
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
        ClearGridView(dgvIPRDetails)
        gbAddSingEntry.Visible = True
        'btnAdd.Text = "Add"
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
        toGetIPRNo()
        lblStatusDesc.Text = "OPEN"
    End Sub

    Private Sub Edit_IPRView()

        Dim RequiredDate As String
        Me.cmsIPR.Visible = False
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable

        If dgvIRPView.Rows.Count > 0 Then

            Me.txtIPRNo.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRNo").Value.ToString()
            Dim str As String = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRdate").Value.ToString()
            Me.dtpIPRDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            txtMrcNo.Text = dgvIRPView.SelectedRows(0).Cells("dgvMRCNo").Value
            'gvCategoryCode
            'Me.txtCategory.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()
            'IPRPPT.strGlobalCategoryDesc = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()

            Me.txtCategory.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvCategoryCode").Value.ToString()
            IPRPPT.strGlobalCategoryDesc = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategory").Value.ToString()


            bind_cmbClassification()
            cmbClassification.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvClassification").Value.ToString()
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
            If Not (dgvIRPView.SelectedRows(0).Cells("gvRejectedReason").Value Is DBNull.Value Or dgvIRPView.SelectedRows(0).Cells("gvRejectedReason").Value Is Nothing) Then
                lblRejectreasondesc.Text = dgvIRPView.SelectedRows(0).Cells("gvRejectedReason").Value
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
            txtRemarks.Text = Me.dgvIRPView.SelectedRows(0).Cells("gvRemarks").Value.ToString()
            lblCategoryCode.Visible = True
            lStockCategoryID = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategoryID").Value.ToString()
            IPRPPT.strGlobalCategoryID = Me.dgvIRPView.SelectedRows(0).Cells("gvSTCategoryID").Value.ToString()
            'Me.btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            DTFlag = True
            lSTIPRID = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRID").Value.ToString()
            dtpIPRDate.Enabled = False
            txtIPRNo.ReadOnly = True

            With objIPRPPT
                .STIPRID = lSTIPRID
            End With
            dtIPRDetails = objIPRBOL.GetIPRDetailsInfo(objIPRPPT)
            If dtIPRDetails.Rows.Count <> 0 Then
                gvlSTIPRDetID = dtIPRDetails.Rows(0).Item("STIPRDetID").ToString()
            End If
            'Me.dgvIPRDetails.Visible = False
            'Me.dgvIPRDetails.Visible = True
            Me.dgvIPRDetails.AutoGenerateColumns = False
            Me.dgvIPRDetails.DataSource = dtIPRDetails
            Enable_SingleEntry()
            txtCategory.ReadOnly = True
            btnSearchCategory.Enabled = False
            Me.tcIPR.SelectedTab = tbIPR

        Else
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisplayInfoMessage("msg26")
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Public Sub BindIPRDet_inApproval(ByVal strSTIPRID As String)
        'Dim mdiparent As New MDIParent
        'mdiparent.strMenuID = "M12"
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        With objIPRPPT
            .STIPRID = strSTIPRID
        End With
        dt = objIPRBOL.GetIPRDetailsInfo(objIPRPPT)
        Me.dgvIPRDetails.AutoGenerateColumns = False
        Me.dgvIPRDetails.DataSource = dt


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
        dgvIPRDetails.Enabled = True
        'lblUnitPriceValue.Visible = True
        'lblTotalValue.Visible = True
        lblUnitValue.Visible = True
        lblStockDesc.Visible = True
        lblCategoryCode.Visible = True
        lblAvailableValue.Visible = True
        lblPartnovalue.Visible = True
        lblMinQtyValue.Visible = True
        strMenuID = "M12"
    End Sub

    Public Sub BindIPRMast_inApproval(ByVal strSTIPRID As String, ByVal strSTIPRNo As String, ByVal strSTIPRDate As String, ByVal strClassification As String, ByVal strRequiredfor As String, ByVal strRequiredDate As String, ByVal strD As String, ByVal strDeliveredto As String, ByVal strCategory As String, ByVal strCategoryCode As String, ByVal strStatus As String, ByVal strMakeModel As String, ByVal strEngine As String, ByVal strChassisSerialNo As String, ByVal strFixedAssetNo As String, ByVal strModifiedOn As String, ByVal strRemarks As String, ByVal strUsageCOAID As String, ByVal strUsageCOACode As String, ByVal strUsageCOADescp As String, MRCNo As String)

        lSTIPRID = strSTIPRID
        txtIPRNo.Text = strSTIPRNo
        dtpIPRDate.Value = strSTIPRDate
        dtpRequiredDate.Value = strRequiredDate
        'Me.dtpIPRDate.Format = DateTimePickerFormat.Custom
        'Me.dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        bind_cmbClassification()
        'cmbClassification.Text = strClassification
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
        txtRemarks.Enabled = False
        txtMrcNo.Text = MRCNo
        lModifiedOn = strModifiedOn
        lblCategoryCode.Text = strCategoryCode
        lblCategoryCode.Visible = True
        txtIPRNo.ReadOnly = True
        txtIPRNo.Enabled = False
        cmbClassification.Enabled = False
        txtUsageCOACode.ReadOnly = True
        txtUsageCOACode.Enabled = False
        'txtD.ReadOnly = True
        txtRequiredFor.ReadOnly = True
        txtRequiredFor.Enabled = False
        txtDeliveredTo.ReadOnly = True
        txtDeliveredTo.Enabled = False
        txtMakeandModel.ReadOnly = True
        txtEngine.ReadOnly = True
        txtChassisSerialNo.ReadOnly = True
        txtFixedAssetNo.ReadOnly = True
        txtStockCode.Enabled = False
        txtRequestedQty.Enabled = False
        txtMakeandModel.Enabled = False
        txtEngine.Enabled = False
        txtChassisSerialNo.Enabled = False
        txtFixedAssetNo.Enabled = False
    End Sub

    Private Sub DeleteIPRVIew()
        Me.cmsIPR.Visible = False

        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        If dgvIRPView.Rows.Count > 0 Then
            If dgvIRPView.SelectedRows(0).Cells("gvMainStatus").Value = "OPEN" Then
                'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                If MsgBox(rm.GetString("msg27"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Me.lSTIPRID = Me.dgvIRPView.SelectedRows(0).Cells("gvIPRID").Value.ToString()
                    With objIPRPPT
                        .STIPRID = Me.lSTIPRID
                    End With
                    objIPRBOL.Delete_IPRDetail(objIPRPPT)
                    GridIPRViewBind()
                End If
            Else
                'MessageBox.Show("Not valid record to delete, status must be OPEN ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DisplayInfoMessage("msg28")
            End If
        Else
            'MessageBox.Show(" No Records to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("msg29")
        End If
    End Sub

    Private Sub cmsIPR_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cmsIPR.PreviewKeyDown
        If e.KeyCode = 46 Or e.KeyCode = 110 Then
            EditViewGridRecord()
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        AddIPR()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteIPRVIew()
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            If mdiparent.strMenuID = "M1" Then
                tcIPR.TabPages("tbIPR").Text = rm.GetString("tcIPR.TabPages(tbIPR).Text")
                tcIPR.TabPages("tbView").Text = rm.GetString("tcIPR.TabPages(tbView).Text")
            Else
                tcIPR.TabPages("tbIPR").Text = rm.GetString("tcIPR.TabPages(tbIPR).Text")
                btnConfirm.Text = rm.GetString("btnConfirm.Text")
                gbApproval.Text = rm.GetString(" gbApproval.Text")
                lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
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
            lblAvailableQty.Text = rm.GetString("lblAvailableQty.Text")
            lblDeliveredTo.Text = rm.GetString("lblDeliveredTo.Text")
            lblClassification.Text = rm.GetString("lblClassification.Text")
            lblRequiredFor.Text = rm.GetString("lblRequiredFor.Text")
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
            lblMinQty.Text = rm.GetString("lblMinQty.Text")
            gbSingleEntry.Text = rm.GetString("gbSingleEntry.Text")
            gbMultientry.Text = rm.GetString("gbMultientry.Text")
            'gbEnquipmentData.Text = rm.GetString("gbEnquipmentData.Text")
            'gbIPRAdd.Text	Detail IPR
            dgvIPRDetails.Columns("dgclStockCode").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclStockCode).HeaderText")
            dgvIPRDetails.Columns("dgclStockDesc").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclStockDesc).HeaderText")
            dgvIPRDetails.Columns("dgclPartNo").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclPartNo).HeaderText")
            dgvIPRDetails.Columns("dgclAvailableQty").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclAvailableQty).HeaderText")
            dgvIPRDetails.Columns("dgclMinimumQty").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclMinimumQty).HeaderText")
            dgvIPRDetails.Columns("dgclunit").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclunit).HeaderText")
            dgvIPRDetails.Columns("dgclUnitPrice").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclUnitPrice).HeaderText")
            dgvIPRDetails.Columns("dgclRequestedQty").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclRequestedQty).HeaderText")
            dgvIPRDetails.Columns("dgclTotalPrice").HeaderText = rm.GetString("dgvIPRDetails.Columns(dgclTotalPrice).HeaderText")

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        'Me.Close()
        '
        'If (dgvIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) Then
        '    If MsgBox(rm.GetString("msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        Me.Close()
        '    Else
        '        tcIPR.SelectedTab = tbIPR
        '    End If
        'Else
        '    Me.Close()
        'End If

        If (dgvIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) And mdiparent.strMenuID = "M1" And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("msg40"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        ''

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

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Dim rowsAffected As Integer = 0
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        If cbApprovalStatus.SelectedItem = String.Empty Then
            'MessageBox.Show("Please select status to Approve")
            DisplayInfoMessage("msg30")
        Else
            If cbApprovalStatus.SelectedItem = "REJECTED" And txtRejectedReason.Text.Trim() = String.Empty Then
                'MessageBox.Show("Please enter valid Rejected reason")
                DisplayInfoMessage("msg31")
            Else
                With objIPRPPT
                    .STIPRID = lSTIPRID
                    '.IPRdate = lModifiedOn
                    .Status = cbApprovalStatus.SelectedItem.ToString()
                    .Remarks = txtRemarks.Text.Trim()
                    .RejectedReason = txtRejectedReason.Text.Trim()
                End With
                rowsAffected = objIPRBOL.Update_IPRApproval(objIPRPPT)
                If rowsAffected > 0 Then
                    'MessageBox.Show(" Confirmation Succeded ", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DisplayInfoMessage("msg32")

                    'Call TaskMonitor Update after successful approval -Start
                    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    Dim dsApprovalCheck As New DataSet
                    dsApprovalCheck = StoreMonthEndClosingBOL.ApprovalCheck(objStoreMonthEndClosingPPT)
                    'Call TaskMonitor Update after successful approval -End

                    InternalPurchaseRequisitionApprovalFrm.Refresh()

                    GlobalPPT.IsButtonClose = True
                    Me.Close()
                Else
                    'MessageBox.Show(" Confirmation Failed ", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DisplayInfoMessage("msg33")
                End If
            End If
        End If

    End Sub

    Private Sub tbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbView.Click
        GridIPRViewBind()
    End Sub

    Private Sub txtCategory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCategory.KeyPress
        'If Char.IsLetter(e.KeyChar) Then Exit Sub
        'If Char.IsControl(e.KeyChar) Then Exit Sub

        'If e.KeyChar = " " Then
        '    Dim txt As TextBox = CType(sender, TextBox)
        '    If txt.Text.IndexOf(" ") < 0 Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'Else
        '    e.Handled = True
        'End If
    End Sub


    Private Sub dgvIRPView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIRPView.KeyDown
        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
    End Sub

    Private Sub btnSearchUsageCOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUsageCOA.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtUsageCOACode.Text = frmAcctcodeLookup.strAcctcode
            psIPRUsageCOAID = frmAcctcodeLookup.strAcctId
            lblUsageCOADescp.Text = frmAcctcodeLookup.strAcctDescp
            lbloldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode
            '' GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            ''lsVDExpenditureAG = frmAcctcodeLookup.strAcctExpenditureAG
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtUsageCOA_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsageCOACode.Leave

        If txtUsageCOACode.Text.Trim() <> String.Empty Then
            If txtUsageCOACode.Text.Trim.ToString.Length <> 13 Then
                'MessageBox.Show("Please enter 13 digit Account code")
                DisplayInfoMessage("msg34")
                txtUsageCOACode.Text = String.Empty
                Exit Sub
            End If

            Dim ds As New DataSet
            Dim objIPRPPT As New IPRPPT
            Dim objIPRBOL As New IPRBOL
            objIPRPPT.COACode = txtUsageCOACode.Text.Trim()
            ds = objIPRBOL.AcctlookupSearch(objIPRPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid Usage COA Account code,Please Choose it from look up")
                DisplayInfoMessage("msg35")
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

    Private Sub dtpIPRDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpIPRDate.ValueChanged

        If lblDays.Text <> String.Empty Then
            dtpRequiredDate.Text = dtpIPRDate.Value.AddDays(lblDays.Text)
        End If

    End Sub

    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click

        If dgvIPRDetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvIPRDetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else
            If MsgBox(rm.GetString("msg27"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                DeleteMultientrydatagrid()
            Else
                Exit Sub
            End If

        End If

    End Sub

    Private Sub DeleteMultientrydatagrid()



        lSTIPRDetID = dgvIPRDetails.SelectedRows(0).Cells("dgclSTIPRDetID").Value.ToString

        lDelete = 0
        If lSTIPRDetID <> "" Then

            'Dim intRowcount As Integer = dtDeleteMERecord.Rows.Count

            'rowMultipleEntryDelete = dtDeleteMERecord.NewRow()
            'If intRowcount = 0 Then
            '    DeletecolumnJournal = New DataColumn("AccjournalID", System.Type.[GetType]("System.String"))
            '    If dtDeleteMERecord.Columns.Contains("AccjournalID") = False Then
            '        dtDeleteMERecord.Columns.Add(DeletecolumnJournal)
            '    End If
            '    rowMultipleEntryDelete("AccJournalID") = lAccJournalID
            'Else
            '    rowMultipleEntryDelete("AccJournalID") = lAccJournalID
            'End If
            'dtDeleteMERecord.Rows.InsertAt(rowMultipleEntryDelete, intRowcount)
            'DgDeleteRecord.DataSource = dtDeleteMERecord


            'kumar anothertry

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lSTIPRDetID)


        End If
        Dim Dr As DataRow
        Dr = dtIPRDetails.Rows.Item(dgvIPRDetails.CurrentRow.Index)
        Dr.Delete()
        dtIPRDetails.AcceptChanges()
        lSTIPRDetID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL

        'For Each GridViewRowMEJournal In DgDeleteRecord.Rows
        '    If GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString() <> String.Empty Then
        '        With objJournalPPT
        '            .AccJournalID = GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString()
        '        End With
        '        Dim IntJournalDetailDelete As New Integer
        '        IntJournalDetailDelete = JournalBOL.DeleteMultiEntryJournal(objJournalPPT)
        '    End If
        'Next
        'ClearGridView(DgDeleteRecord)
        lDelete = DeleteMultientry.Count

        While (lDelete > 0)
            ' If GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString() <> String.Empty Then
            With objIPRPPT
                .STIPRDetID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntIPRDetailDelete As New Integer
            IntIPRDetailDelete = objIPRBOL.DeleteMultiEntryIPR(objIPRPPT)
            ' End If
            lDelete = lDelete - 1

        End While

        'ClearGridView(DgDeleteRecord)


    End Sub



    'Private Sub InternalPurchaseRequisitionFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    Dim mdiparent As New MDIParent
    '    If dgvIPRDetails.RowCount > 0 And mdiparent.strMenuID = "M1" Then

    '        If MsgBox(rm.GetString("msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            '

    '            '
    '        End If

    '    End If

    'End Sub

    Private Sub dgvIRPView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIRPView.CellContentClick

        If e.ColumnIndex = 20 Then

            Dim ObjRecordExist As New Object
            Dim ObjIPRPPT As New IPRPPT
            Dim ObjIPRBOL As New IPRBOL
            ObjRecordExist = ObjIPRBOL.IPRRecordIsExisT(ObjIPRPPT)

            If ObjRecordExist = 0 Then
                'MsgBox("No Record(s) Available!")
                DisplayInfoMessage("msg25")
            Else
                psIPRID = dgvIRPView.SelectedRows(0).Cells("gvIPRID").Value.ToString

                StrFrmName = "IPR"
                ReportODBCMethod.ShowDialog()
                StrFrmName = ""
                psIPRID = ""

            End If

        End If

    End Sub

    Private Sub txtRequestedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRequestedQty.TextChanged

        If Val(txtRequestedQty.Text) > 0 Then
            'txtRequestedQty.Text = Format(Val(txtRequestedQty.Text), "0")            
        End If

    End Sub

    Private Sub lblMinQtyValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMinQtyValue.TextChanged

        If lblMinQtyValue.Text <> String.Empty Then
            lblMinQtyValue.Text = Format(Val(lblMinQtyValue.Text), "0")
        End If

    End Sub

    Private Sub lblAvailableValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAvailableValue.TextChanged

        If lblAvailableValue.Text <> String.Empty Then
            lblAvailableValue.Text = Format(Val(lblAvailableValue.Text), "0")
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

    'Private Sub InternalPurchaseRequisitionFrm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    '    MenuChange()

    'End Sub


    'Private Sub InternalPurchaseRequisitionFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    '    MenuChange()

    'End Sub

    'Private Sub MenuChange()

    '    If (mdiparent.strMenuID = "M1" And dgvIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) Then
    '        If MsgBox(rm.GetString("msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            cmbStatus.Text = "OPEN"
    '            GridIPRViewBind()
    '            mdiparent.strIsMenuChange = "OK"
    '        Else
    '            ''
    '            tcIPR.SelectedTab = tbIPR
    '            mdiparent.strIsMenuChange = "Cancel"
    '            'Exit Sub
    '            ''
    '        End If
    '    Else
    '        cmbStatus.Text = "OPEN"
    '        GridIPRViewBind()

    '    End If

    'End Sub

    Private Sub InternalPurchaseRequisitionFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (mdiparent.strMenuID = "M1" And dgvIPRDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M1"
                'mdiparent.lblMenuName.Text = "IPR"
            End If

        End If

    End Sub
    Private guid As Guid
    Public hasLoadVisibility As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        guid = System.Guid.NewGuid()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub lblUnitPrice_VisibleChanged(sender As Object, e As System.EventArgs) Handles lblUnitPrice.VisibleChanged
        Console.WriteLine()
    End Sub

    Private Sub BtnXML_Click(sender As System.Object, e As System.EventArgs) Handles BtnXML.Click
        Dim objIPR As New IPRBOL
        Dim dt As New DataTable
        Dim dtDetail As New DataTable

        dt = objIPR.GenerateIPRXML(Nothing)

        Dim profile As New Profile
        With profile
            .NameXML = "RequisitionImport"
            .FirstTag = "SSPRRequisitionImport"
            .SecondTag = "Requisition"
            .Creator = New String() {dt.Columns.Item("creator").ColumnName, dt.Rows(0).Item("creator").ToString()}
            .Descr = New String() {dt.Columns.Item("descr").ColumnName, dt.Rows(0).Item("descr").ToString()}
            .ReqStatus = New String() {dt.Columns.Item("reqStatus").ColumnName, dt.Rows(0).Item("reqStatus").ToString()}
        End With

        Dim profileLines As New List(Of ProfileLine)
        Dim profileNameValues As New List(Of ProfileNameValue)


        For Each o As DataRow In dt.Rows
            Dim profileLine As New ProfileLine

            dtDetail = objIPR.GenerateIPRXML(o.Item("Id").ToString())
            For Each oDetail As DataRow In dtDetail.Rows
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "nextRoleId"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "orderDate"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "businessUnitCode"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "quantity"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "requisitioner"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "isRequisitionOnly"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "itemCode"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "description"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "unitOfMeasure"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "unitPrice"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "costCentreCode"))
                profileNameValues.Add(BSPXMLGenerator.WriteXML(dt, oDetail, "currencyCode"))
                Exit For
            Next

            With profileLine
                .Id = o.Item("Id").ToString()
                .Line = "line"
                .LTName = New String() {dt.Columns.Item("LTName").ColumnName, o.Item("LTName").ToString()}
                .ProfileNameValue = profileNameValues
                .Fields = "fields"
            End With
            profileLines.Add(profileLine)
        Next

        BSPXMLGenerator.Generate(profile, profileLines, profileNameValues)
    End Sub


End Class