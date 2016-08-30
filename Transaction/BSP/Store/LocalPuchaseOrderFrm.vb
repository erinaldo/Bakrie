Imports Common_BOL
Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class LocalPuchaseOrderFrm

    Public psLPOStockCategoryID As String = String.Empty
    Public psLPOStockCategory As String = String.Empty
    Public psLPOStockCategoryDescp As String = String.Empty

    Public Shared psLPOStockCOAID As String = String.Empty
    Public Shared psLPOVarianceCOAID As String = String.Empty

    Public Shared StrFrmName As String
    Public lSupplierID As String = String.Empty
    Public lSupplierCode As String = String.Empty
    Public lContractID As String = String.Empty
    Public lContractName As String = String.Empty
    Public lStockCategory As String = String.Empty
    Public Shared lStockCategoryID As String = String.Empty
    Public Shared lStockCategoryCode As String = String.Empty
    Public lStockCode As String = String.Empty
    Public lStockDesc As String = String.Empty
    Public lUnitprice As String = String.Empty
    Public lUnit As String = String.Empty
    Public UOM As String = String.Empty

    Public lStockID As String = String.Empty
    Public tDecide As String = String.Empty
    Private AddFlag As Boolean = True
    Public btnAddFlag As Boolean = True

    Dim dtLPOAdd As New DataTable("ToDgvLPOAdd")
    Dim columnLPOAdd As DataColumn
    Dim rowLPOAdd As DataRow
    Public dtAddFlag As Boolean = False
    Public lSTID As String

    Public lT0Id As String = String.Empty
    Public lT1Id As String = String.Empty
    Public lT2Id As String = String.Empty
    Public lT3Id As String = String.Empty
    Public lT4Id As String = String.Empty
    Public lSTLPOID As String = String.Empty
    Dim dtLPODetails As New DataTable("todgvLPODetails")
    Public lSTLPODetID As String = String.Empty
    Public lSTLPONo As String
    Public lStrQty As String
    Public lSupplierName As String
    Public lStrValue As String
    Public lModifiedOn As String
    Public lTempStockCode As String
    Dim isDecimal As Boolean
    Public lPartNo As String = String.Empty
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Dim lSTLPODetailID As String = String.Empty
    Public Shared psSTLPOID As String = String.Empty



    Private Sub DisableFieldsApprovalMode()

        grpApproval.Visible = True
        txtLPORemarks.Enabled = False
        txtStockCode.Enabled = False
        txtQty.Enabled = False
        txtLPOTotalPrice.Enabled = False
        txtLPORemarks.Enabled = False
        txtContractNo.Enabled = False
        txtSupplierCode.Enabled = False
        txtStockCategory.Enabled = False
        btnSearchStockCategory.Enabled = False
        txtStockCode.Enabled = False
        txtUnitPrice.Enabled = False

        txtT0.Enabled = False
        txtT1.Enabled = False
        txtT2.Enabled = False
        txtT0.Enabled = False
        txtT3.Enabled = False
        txtT4.Enabled = False
        btnSaveAll.Visible = False
        btnSaveAll.Enabled = False
        btnResetAll.Visible = False

        btnSearchT0.Enabled = False
        btnSearchT1.Enabled = False
        btnSearchT2.Enabled = False
        btnSearchT3.Enabled = False
        btnSearchT4.Enabled = False
        dtpLPODate.Enabled = False
        btnAdd.Enabled = False
        btnReset.Enabled = False

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tabLPOContainer.TabPages("tabLPO").Text = rm.GetString("tabLPOContainer.TabPages(tabLPO).Text ")
            'tabLPOContainer.TabPages("tabLPOView").Text = rm.GetString(" tabLPOContainer.TabPages(tabLPOView).Text")
            lblStockCategory.Text = rm.GetString("lblStockCategory.Text")
            lblLPONo.Text = rm.GetString("lblLPONo.Text")
            lblLPODate.Text = rm.GetString("lblLPODate.Text")
            lblStockCode.Text = rm.GetString("lblStockCode.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblSuppName.Text = rm.GetString("lblSuppName.Text")
            lblContractNo.Text = rm.GetString("lblContractNo.Text")
            lblUnitPrice.Text = rm.GetString("lblUnitPrice.Text")
            lblTotalPrice.Text = rm.GetString("lblTotalPrice.Text")
            lblQuantity.Text = rm.GetString("lblQuantity.Text")
            lblMainStatus.Text = rm.GetString("lblMainStatus.Text")
            lblStockDescription.Text = rm.GetString("lblStockDescription.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            lblT0.Text = rm.GetString("lblT0.Text")
            lblT1.Text = rm.GetString("lblT1.Text")
            lblT2.Text = rm.GetString("lblT2.Text")
            lblT3.Text = rm.GetString("lblT3.Text")
            lblT4.Text = rm.GetString("lblT4.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")
            btnReset.Text = rm.GetString("btnReset.Text")

            ''''''View Page''''

            chkLPOViewDate.Text = rm.GetString("chkLPOViewDate.Text")
            lblLPONoView.Text = rm.GetString("lblLPONoView.Text")
            lblStatusLPOView.Text = rm.GetString("lblStatusLPOView.Text")
            btnLPOViewSearch.Text = rm.GetString("btnLPOViewSearch.Text")
            btnLPOViewReport.Text = rm.GetString("btnLPOViewReport.Text")
            pnlSearchLPO.Text = rm.GetString("pnlSearchLPO.Text")
            lblSearch.Text = rm.GetString("lblSearch.Text")

            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnviewReport.Text")

            '''''''''''''GRID CAPTIONS'''''''''''''''''''''''''''''
            dgvLPODetails.Columns("LPOStockCode").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOStockCode).HeaderText")
            dgvLPODetails.Columns("LPOStockDesc").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOStockDesc).HeaderText")
            dgvLPODetails.Columns("LPOQty").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOQty).HeaderText")
            dgvLPODetails.Columns("LPOTotalPrice").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOTotalPrice).HeaderText")
            dgvLPODetails.Columns("LPOUnitPrice").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOUnitPrice).HeaderText")
            dgvLPODetails.Columns("LPOT0").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOT0).HeaderText")
            dgvLPODetails.Columns("LPOT1").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOT1).HeaderText")
            dgvLPODetails.Columns("LPOT2").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOT2).HeaderText")
            dgvLPODetails.Columns("LPOT3").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOT3).HeaderText")
            dgvLPODetails.Columns("LPOT4").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOT4).HeaderText")
            dgvLPODetails.Columns("LPOStatus").HeaderText = rm.GetString("dgvLPODetails.Columns(LPOStatus).HeaderText")

            ''''''''View Grid''''''''''''''''
            dgvLPOView.Columns("dgclLPONo").HeaderText = rm.GetString("dgvLPOView.Columns(dgclLPONo).HeaderText")
            dgvLPOView.Columns("dgclLPODate").HeaderText = rm.GetString("dgvLPOView.Columns(dgclLPODate).HeaderText")
            dgvLPOView.Columns("dgclSupplierName").HeaderText = rm.GetString("dgvLPOView.Columns(dgclSupplierName).HeaderText")
            dgvLPOView.Columns("dgclMainStatus").HeaderText = rm.GetString("dgvLPOView.Columns(dgclMainStatus).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub BindLPOMast_inApproval(ByVal strSTLPOID As String, ByVal strLPONo As String, ByVal strLPODate As String, ByVal strMainStatus As String, ByVal strRemarks As String, ByVal strSupplierName As String, ByVal strSupplierID As String, ByVal strContractNo As String, ByVal strContractID As String, ByVal strStockCategoryID As String, ByVal strStockCategory As String, ByVal strStockCategoryDescp As String)

        lSTLPOID = strSTLPOID
        txtLPONo.Text = strLPONo
        'Dim dateVal As DateTime = strLPODate
        Me.dtpLPODate.Value = New Date(strLPODate.Substring(6, 4), strLPODate.Substring(3, 2), strLPODate.Substring(0, 2))
        'dtpLPODate.Value = New Date(
        lSTLPONo = strLPONo
        ' lblStatus.Text = strMainStatus
        txtSupplierCode.Text = strSupplierName
        txtContractNo.Text = strContractNo
        txtLPORemarks.Text = strRemarks
        txtStockCategory.Text = strStockCategory
        lblStockCategoryDescp.Text = strStockCategoryDescp
        psLPOStockCategoryID = strStockCategoryID
        EditLPOViewApprovalMode(lSTLPOID)

    End Sub

    Public Sub BindingTotal()

    End Sub

    Private Sub ResetAll()

        ClearAll()
        lSTLPOID = String.Empty
        EnableFieldsOnResetAll()
        LocalPurchaseOrderBOL.ClearGridView(dgvLPODetails)
        btnPrint.Enabled = False
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

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub


    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub



    Private Sub ClearAll()

        DeleteMultientry.Clear()

        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSIVDate)
        FormatDateTimePicker(dtpLPODate)
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        txtStockCategory.Enabled = True
        txtLPORemarks.Text = String.Empty
        txtSupplierCode.Text = String.Empty
        txtContractNo.Text = String.Empty
        txtStockCategory.Text = String.Empty
        lblStockCategoryDescp.Text = String.Empty
        txtStockCode.Text = String.Empty
        lblStockDescDetails.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        txtQty.Text = String.Empty
        txtLPOTotalPrice.Text = String.Empty
        If txtContractNo.Text.Trim() = String.Empty Then
            txtAccountCode.Text = String.Empty
            Me.lContractID = String.Empty
        End If
        lblSupplierName.Text = String.Empty
        'txtT0.Text = String.Empty
        'lblT0Value.Text = String.Empty
        txtT1.Text = String.Empty
        lblT1Value.Text = String.Empty
        txtT2.Text = String.Empty
        lblT2Value.Text = String.Empty
        txtT3.Text = String.Empty
        lblT3Value.Text = String.Empty
        txtT4.Text = String.Empty
        lblT4Value.Text = String.Empty
        lblPartNoDesc.Text = String.Empty
        txtTotalPurchase.Text = "0.0"
        txtVATPercent.Text = "10"
        txtTransportationCost.Text = "0.0"
        txtTotal.Text = "0.0"
    End Sub


    Private Sub EnableFieldsOnResetAll()
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        txtSupplierCode.Enabled = True
        btnSearchSupplier.Enabled = True
        txtLPORemarks.Enabled = True
        txtContractNo.Enabled = True
        btnSearchContract.Enabled = True
        btnSearchStockCategory.Enabled = True
        txtLPORemarks.Text = ""
        txtSupplierCode.Text = ""
        txtContractNo.Text = ""
        txtUnitPrice.Enabled = True
        txtStockCode.ReadOnly = False
        txtT0.Enabled = True
        txtT1.Enabled = True
        txtT2.Enabled = True
        txtT3.Enabled = True
        txtT4.Enabled = True
        txtQty.Enabled = True
        btnSearchT0.Enabled = True
        btnSearchT1.Enabled = True
        btnSearchT2.Enabled = True
        btnSearchT3.Enabled = True
        btnSearchT4.Enabled = True
        btnAdd.Enabled = True
        btnReset.Enabled = True
        dtpLPODate.Format = DateTimePickerFormat.Custom
        dtpLPODate.Enabled = True
        toGetLPONo()
        lblStatusDesc.Text = "OPEN"
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        Dim ds As New DataSet
        ClearGridView(dgvLPODetails)
        btnSearchStockCode.Enabled = True
    End Sub



    Public Sub EditLPOViewApprovalMode(ByVal STLPOIDVal As String)

        Me.cmsLPO.Visible = False
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable
        'If dgvLPOView.Rows.Count > 0 Then
        'Me.btnSaveAll.Text = "Update All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Update All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Update Semua"
        End If
        'lSTLPOID = Me.dgvLPOView.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString()

        dtpLPODate.Enabled = False

        With objLPOPPT
            .STLPOID = STLPOIDVal
        End With
        If dtLPOAdd.Rows.Count <> 0 Then
            lSTLPODetID = dtLPOAdd.Rows(0).Item("STLPODetID").ToString()
        End If

        dtLPOAdd = objLPOBOL.GetLPODetailsView(objLPOPPT)
        dgvLPODetails.AutoGenerateColumns = False
        Me.dgvLPODetails.DataSource = dtLPOAdd
        TotalFromGridAvroval()
    End Sub



    Private Sub LocalPuchaseOrderFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub LocalPuchaseOrderFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        Dim frm As New StoreIssueVoucherApprovalFrm
        Dim mdiparent As New MDIParent
        'ClearAllControls()
        SetUICulture(GlobalPPT.strLang)
        If mdiparent.strMenuID = "M2" Then
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpLPODate)
            FormatDateTimePicker(dtpLPODate)
            toGetLPONo()

            dtpLPODate.Focus()
            dtpLPODate.Format = DateTimePickerFormat.Custom
            dtpLPODate.CustomFormat = "dd/MM/yyyy"


            'BindDgvLpoDetails()
            cbLPOViewStatus.SelectedIndex = 1
            Me.cbLPOViewStatus.Text = Me.cbLPOViewStatus.Items(1)
            tabLPOContainer.SelectedTab = tabLPOView
            GridLPOViewBind()

        ElseIf mdiparent.strMenuID = "M13" Then
            toloadLPO_inApproval()
            grpApproval.Visible = True
            cmbLPOStatus.Text = "--Select Status--"
            Me.dtpLPODate.Format = DateTimePickerFormat.Custom
            Me.dtpLPODate.CustomFormat = "dd/MM/yyyy"
            Me.lblRejectedReason.Visible = False
            Me.txtRejectedReason.Visible = False

            DisableFieldsApprovalMode()
        End If


        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpLPODate)
        'FormatDateTimePicker(dtpLPODate)
        txtT0.Text = Helper.T0Default(0)
        lblT0Value.Text = Helper.T0Default(1)
        'Dim _T0value(2) As String
        '_T0value = GlobalPPT.strEstateName.Split("-")

    End Sub

    Private Sub toloadLPO_inApproval()
        Dim MdiParent As New MDIParent

        If MdiParent.strMenuID = "M13" Then
            tabLPOContainer.SelectedTab = tabLPO
            tabLPOContainer.TabPages.Remove(tabLPOView)
        Else

        End If
    End Sub


    Private Sub toGetLPONo()

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        objLPOPPT = objLPOBOL.GetLPONO(objLPOPPT)
        Dim PONo As String = objLPOBOL.GetPOAutoNo()
        txtLPONo.Text = PONo

        With objLPOPPT
            If .LPONo <> "" Then
                'Me.txtLPONo.Text = .LPONo

            Else
                DisplayInfoMessage("Msg01")
                'MessageBox.Show("No records for LPO in Store Configuration")
            End If
            objLPOPPT = objLPOBOL.GetLPOID(objLPOPPT)
            lSTLPOID = .STLPOID
            lSTLPODetID = .STLPODetID
        End With

    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub txtStockCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave

        If txtStockCode.Text.Trim() <> String.Empty Then

            Dim dt As New DataTable
            Dim dtStock As New DataTable
            Dim objIPRPPT As New IPRPPT
            Dim objIPRBOL As New IPRBOL

            objIPRPPT.STCategoryCode = psLPOStockCategory.Trim
            objIPRPPT.STCategory = Me.txtStockCategory.Text.Trim
            objIPRPPT.STCategoryID = psLPOStockCategoryID.Trim

            objIPRPPT.StockCode = Me.txtStockCode.Text.Trim
            dt = objIPRBOL.StockCodeSearch(objIPRPPT)

            If dt.Rows.Count <> 0 Then

                Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString().Trim
                Me.lblStockDescDetails.Text = dt.Rows(0).Item("StockDesc").ToString()
                Me.txtUnitPrice.Text = dt.Rows(0).Item("UnitPrice").ToString()
                Me.lblUnit.Visible = True
                Me.lStockID = dt.Rows(0).Item("StockId").ToString()
                Me.lblStockDescDetails.Visible = True

            Else

                DisplayInfoMessage("Msg27")
                'MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtStockCode.Text = String.Empty
                txtStockCode.Focus()

            End If

        Else

            lblStockDescDetails.Text = String.Empty
            lStockID = String.Empty
            lblPartNoDesc.Text = String.Empty
            txtUnitPrice.Text = String.Empty
            txtLPOTotalPrice.Text = String.Empty

        End If

    End Sub


    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click


        'Dim frmStockCodeLookup As New StockCodeByCategoryLookup
        'frmStockCodeLookup.ShowDialog()
        'If frmStockCodeLookup._lStockID <> String.Empty Then
        '    lStockCode = frmStockCodeLookup._lStockCode
        '    lStockID = frmStockCodeLookup._lStockID
        '    lStockDesc = frmStockCodeLookup._lStockDesc
        '    lUnitprice = frmStockCodeLookup._lStockUnitprice
        '    lUnit = frmStockCodeLookup._lUnit
        '    Me.txtStockCode.Text = lStockCode
        '    Me.lblStockDescDetails.Text = lStockDesc
        '    Me.txtUnitPrice.Text = lUnitprice
        '    Me.lblPartNoDesc.Text = frmStockCodeLookup._lPartNo
        '    Me.lPartNo = frmStockCodeLookup._lPartNo
        'End If

        Me.Cursor = Cursors.WaitCursor
        GlobalPPT.IsStockCategory = False

        If txtStockCategory.Text.Trim() = String.Empty Then

            DisplayInfoMessage("Msg40")
            'MessageBox.Show("Please Enter Stock Category")
            txtStockCategory.Focus()

        Else

            Dim ObjStockCode As New IPRPPT
            Dim ObjStockBOL As New IPRBOL
            Dim stockDt As New DataTable
            Dim StockCategory As New StockCodeLookUp()
            Dim result As DialogResult = StockCodeLookUp.ShowDialog()

            If StockCodeLookUp.DialogResult = Windows.Forms.DialogResult.OK Then

                lStockCode = StockCodeLookUp._lStockCode.Trim
                lStockID = StockCodeLookUp._lStockID
                lStockDesc = StockCodeLookUp._lStockDesc
                lUnitprice = StockCodeLookUp._lStockUnitprice
                lUnit = StockCodeLookUp._lUnit
                UOM = StockCodeLookUp._UOM

                Me.txtStockCode.Text = lStockCode.Trim
                Me.lblStockDescDetails.Text = lStockDesc
                Me.txtUnitPrice.Text = lUnitprice
                Me.lblPartNoDesc.Text = StockCodeLookUp._lPartNo
                Me.lPartNo = StockCodeLookUp._lPartNo
                txtUOM.Text = UOM
            End If

        End If

        Me.Cursor = Cursors.Arrow


    End Sub


    Private Sub btnSearchT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT0.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T0"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT0.Text = frmTLookup.strTValue
            lT0Id = frmTLookup.strTId
            lblT0Value.Text = frmTLookup.strTDesc
            Dim T0Desc As String = frmTLookup.strTDesc
        End If

    End Sub


    Private Sub btnSearchT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT1.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T1"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT1.Text = frmTLookup.strTValue
            lT1Id = frmTLookup.strTId
            lblT1Value.Text = frmTLookup.strTDesc
        End If
    End Sub



    Private Sub btnSearchT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT2.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T2"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT2.Text = frmTLookup.strTValue
            lT2Id = frmTLookup.strTId
            lblT2Value.Text = frmTLookup.strTDesc
        End If
    End Sub


    Private Sub btnSearchT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT3.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T3"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT3.Text = frmTLookup.strTValue
            lT3Id = frmTLookup.strTId
            lblT3Value.Text = frmTLookup.strTDesc
        End If

    End Sub


    Private Sub clearControls()

        txtStockCode.Text = ""
        lblStockDescDetails.Text = ""
        lblPartNoDesc.Text = ""
        txtQty.Text = ""
        'lblUOM.Text = "DispUOM"
        txtUnitPrice.Text = ""
        txtLPOTotalPrice.Text = ""
        ' txtT0.Text = ""
        txtT1.Text = ""
        txtT2.Text = ""
        txtT3.Text = ""
        txtLPORemarks.Text = ""
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        'lblT0Value.Text = ""
        lblT1Value.Text = ""
        lblT2Value.Text = ""
        lblT3Value.Text = ""
        lblT4Value.Text = ""
        txtT4.Text = ""

    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Add_Clicked()

        'GlobalPPT.IsRetainFocus = True

    End Sub


    Private Function IsValidSaveAll() As Boolean

        'If btnSaveAll.Text = "Save All" Or btnSaveAll.Text = "Simpan" Then
        If dgvLPODetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg02")
            'MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStockCategory.Focus()
            Return False
        End If
        'End If
        'If btnSaveAll.Text = "Update All" Then ' in and condtition add indonesia word for update all and validate
        If dgvLPODetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg03")
            'MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStockCategory.Focus()
            Return False
        End If
        'End If

        Return True
    End Function


    Private Sub SaveAll()

        If IsValidSaveAll() = False Then
            Exit Sub
        End If
        Dim rowaffected As Integer = 0

        'If IsValidSaveAll() = False Then
        '    Exit Sub
        'End If

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim intResult As Integer = 0

        Dim objLPOBOL As New LocalPurchaseOrderBOL

        With objLPOPPT
            .LPONo = txtLPONo.Text.Trim()
            .STLPOID = lSTLPOID
            .SupplierID = lSupplierID
            .LPODate = dtpLPODate.Value
            .ContractID = lContractID
            .Remarks = txtLPORemarks.Text.Trim()
            .MainStatus = "OPEN"
            .STCategoryID = psLPOStockCategoryID
            .UOM = txtUOM.Text.Trim()
            .VAT = txtVATTotal.Text.Trim()
            .VATPercent = txtVATPercent.Text.Trim()
            .TransportationCost = txtTransportationCost.Text.Trim()
            .MRCNo = txtMRCNo.Text.Trim()
            .TOTAL = txtTotalPurchase.Text.Trim()
            .TotalAll = txtTotal.Text.Trim()
        End With

        Dim ds As New DataSet

        'If btnSaveAll.Text.Trim() = "Save All" Then
        If lSTLPOID = String.Empty Then

            ds = LocalPurchaseOrderBOL.SaveSTLPO(objLPOPPT)
            'dgvLPODetails.DataSource = ds.Tables(0)
        ElseIf lSTLPOID <> String.Empty Then
            'ElseIf btnSaveAll.Text.Trim() = "Update All" Then
            DeleteMultiEntryRecords()
            ds = LocalPurchaseOrderBOL.UpdateSTLPO(objLPOPPT)
            '  MessageBox.Show("Data Successfully Updated")
        End If

        Dim DataGridViewRow As DataGridViewRow

        'If Me.btnSaveAll.Text.Trim() = "Save All" Then
        If lSTLPOID = String.Empty Then

            If IsValidSaveAll() = False Then
                Exit Sub
            End If
            Dim dsDetails As New DataSet
            For Each DataGridViewRow In dgvLPODetails.Rows
                With objLPOPPT
                    .STLPOID = ds.Tables(0).Rows(0).Item("STLPOID")
                    .LPONo = DataGridViewRow.Cells("LPONo").Value.ToString()
                    .StockID = DataGridViewRow.Cells("LPOStockID").Value.ToString()
                    .OrderQty = DataGridViewRow.Cells("LPOQty").Value.ToString()
                    .UnitPrice = DataGridViewRow.Cells("LPOUnitPrice").Value.ToString()
                    .Status = DataGridViewRow.Cells("LPOStatus").Value.ToString()
                    '.RejectedReason = DataGridViewRow.Cells("LPORejectedReason").Value.ToString()
                    .SupplierID = DataGridViewRow.Cells("LPOSupplierID").Value.ToString()
                    .T0 = DataGridViewRow.Cells("LPOT0Id").Value.ToString()
                    .T1 = DataGridViewRow.Cells("LPOT1Id").Value.ToString()
                    .T2 = DataGridViewRow.Cells("LPOT2Id").Value.ToString()
                    .T3 = DataGridViewRow.Cells("LPOT3Id").Value.ToString()
                    .T4 = DataGridViewRow.Cells("LPOT4Id").Value.ToString()
                    .Value = DataGridViewRow.Cells("LPOTotalPrice").Value.ToString()
                    .PendingQty = DataGridViewRow.Cells("LPOQty").Value.ToString()

                End With

                dsDetails = LocalPurchaseOrderBOL.SaveSTLPODetails(objLPOPPT)
            Next

            DisplayInfoMessage("Msg31")
            'MsgBox("Data Successfully Saved")

            'btnSaveAll.Text = "Save All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Save All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Simpan Semua"
            End If

            LocalPurchaseOrderBOL.ClearGridView(dgvLPODetails)

            ClearAll()
            EnableFieldsOnResetAll()

        ElseIf lSTLPOID <> String.Empty Then
            'ElseIf btnSaveAll.Text = "Update All" Then

            'If IsValidSaveAll() = False Then
            '    Exit Sub
            'End If

            Dim dsDetails As New DataSet

            For Each DataGridViewRow In dgvLPODetails.Rows
                With objLPOPPT


                    .SupplierID = DataGridViewRow.Cells("LPOSupplierID").Value.ToString()
                    '.STLPODetID = lSTLPODetID
                    .STLPODetID = DataGridViewRow.Cells("LPOSTLPODetID").Value.ToString()
                    '.LPONo = DataGridViewRow.Cells("LPONo").Value.ToString()
                    .StockID = DataGridViewRow.Cells("LPOStockID").Value.ToString()
                    .OrderQty = DataGridViewRow.Cells("LPOQty").Value.ToString()
                    .UnitPrice = DataGridViewRow.Cells("LPOUnitPrice").Value.ToString()
                    .Status = "OPEN"
                    '.RejectedReason = DataGridViewRow.Cells("LPORejectedReason").Value.ToString()
                    .T0 = DataGridViewRow.Cells("LPOT0Id").Value.ToString()
                    .T1 = DataGridViewRow.Cells("LPOT1Id").Value.ToString()
                    .T2 = DataGridViewRow.Cells("LPOT2Id").Value.ToString()
                    .T3 = DataGridViewRow.Cells("LPOT3Id").Value.ToString()
                    .T4 = DataGridViewRow.Cells("LPOT4Id").Value.ToString()

                    .Value = DataGridViewRow.Cells("LPOTotalPrice").Value.ToString()
                    ' .PendingQty = DataGridViewRow.Cells("LPOPendingQuantity").Value.ToString()
                    .PendingQty = DataGridViewRow.Cells("LPOQty").Value.ToString()

                End With
                If DataGridViewRow.Cells("LPOSTLPODetID").Value.ToString <> String.Empty Then

                    dsDetails = LocalPurchaseOrderBOL.UpdateSTLPODetails(objLPOPPT)
                Else

                    dsDetails = LocalPurchaseOrderBOL.SaveSTLPODetails(objLPOPPT)
                End If



            Next

            DisplayInfoMessage("Msg32")
            'MsgBox("Data Successfully Updated")

            'btnSaveAll.Text = "Save All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Save All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Simpan Semua"
            End If

            lblStatus.Text = "OPEN"
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
        End If

        ClearAll()
        EnableFieldsOnResetAll()
        LocalPurchaseOrderBOL.ClearGridView(dgvLPODetails)
        txtStockCategory.Enabled = True
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ResetAll()
        btnAddFlag = True

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub ClearAllControls()
        dtpLPODate.Value = Date.Today
        dtpLPODate.Format = DateTimePickerFormat.Custom
        dtpLPODate.CustomFormat = "dd/MM/yyyy"
        txtSupplierCode.Text = String.Empty
        txtSupplierCode.Enabled = True
        btnSearchContract.Enabled = True
        btnSearchStockCategory.Enabled = True
        btnSearchSupplier.Enabled = True
        txtContractNo.Text = String.Empty
        txtStockCategory.Text = String.Empty
        lblStockCategoryDescp.Text = String.Empty
        txtLPORemarks.Text = String.Empty
        lblStatusDesc.Text = "Open"
        clearControls()
        ClearGridView(dgvLPODetails)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearControls()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim mdiparent As New MDIParent

        If (dgvLPODetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And mdiparent.strMenuID = "M2" And btnSaveAll.Enabled = True) Then
            If MsgBox(rm.GetString("Msg43"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

    Private Function checkValues() As Boolean

        If (txtLPONo.Text = String.Empty) Then
            DisplayInfoMessage("Msg04")
            'MessageBox.Show("LPO No not selected ", "Please select LPO Number ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLPONo.Focus()
            Return False
        End If
        If (txtSupplierCode.Text = String.Empty) Then
            DisplayInfoMessage("Msg05")
            'MessageBox.Show("Supplier not Selected", "Please select Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierCode.Focus()
            Return False
        End If
        If (txtStockCategory.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg40")
            'MessageBox.Show("Stock Category not Selected", "Please select Stock Category", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCategory.Focus()
            Return False
        End If
        If (txtStockCode.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg06")
            'MessageBox.Show("Stock Code not Selected", "Please select Stock Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCode.Focus()
            Return False
        End If
        If (txtQty.Text = String.Empty) Then
            DisplayInfoMessage("Msg07")
            'MessageBox.Show("Quantity is Empty", "Please give Quantity ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQty.Focus()
            Return False
        End If

        If (txtQty.Text.Trim <> String.Empty) Then
            If (CDbl(txtQty.Text.Trim) <= 0 Or CDbl(txtQty.Text.Trim) <= 0.0) Then
                DisplayInfoMessage("Msg36")
                'MessageBox.Show("Quantity Should be greater than 0", "Please give Quantity ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Return False
            End If
        End If

        If (txtUnitPrice.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg39")
            'MessageBox.Show("Unit Price is Empty", "Please give Unit Price ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitPrice.Focus()
            Return False
        ElseIf (txtUnitPrice.Text.Trim = 0) Then
            DisplayInfoMessage("Msg41")
            'MessageBox.Show("Unit Price should not be zero", "Please give Unit Price ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitPrice.Focus()
            Return False

        End If


        If (txtT0.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg08")
            'MessageBox.Show("T0 is Empty", "Please give T0 value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtT0.Focus()
            Return False
        End If
        Return True

    End Function

    Private Sub Add_Clicked()
        If btnAddFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (checkValues() = False) Then
                Exit Sub
            Else
                If txtUnitPrice.Text.Trim <> String.Empty And txtQty.Text.Trim <> String.Empty Then
                    Me.txtLPOTotalPrice.Text = CDbl(Convert.ToDecimal(txtQty.Text) * CDbl(Convert.ToDecimal(txtUnitPrice.Text)))
                End If

                saveLPODetails()
                lblStatus.Text = "Open"
                clear()
            End If
        ElseIf btnAddFlag = False Then
            If (checkValues() = False) Then
                Exit Sub
            Else
                UpdateLPODetails()
                lblStatus.Text = "Open"
                clear()
            End If
        End If

        TotalFromDataGrid()
        'For Each o As DataGridViewRow In dgvLPODetails
        '    subTotal += CDbl(o.Cells(6).Value)
        '    txtTotalPurchase.Text = subTotal
        'Next


    End Sub

    Public Sub TotalFromDataGrid()
        TotalGrid("LPOTotalPrice")
    End Sub

    Public Sub TotalGrid(_index As String)
        Dim subTotal As Double
        For i As Integer = 0 To dgvLPODetails.Rows.Count - 1
            Try
                If dgvLPODetails.Rows(i).Cells(_index).Value IsNot Nothing Then
                    'Dim coma As String = dgvLPODetails.Rows(i).Cells(_index).Value
                    'Dim value As Int64
                    'If coma.Contains(".") Then
                    '    Dim commaSplit(1) As String
                    '    commaSplit = coma.Split(".")
                    '    value = Convert.ToInt64(commaSplit(0))
                    'ElseIf coma.Contains(",") Then
                    '    Dim commaSplit(1) As String
                    '    commaSplit = coma.Split(",")
                    '    value = Convert.ToInt64(commaSplit(0))
                    'Else
                    '    value = Convert.ToInt64(dgvLPODetails.Rows(i).Cells(_index).Value)
                    'End If
                    Dim value As Double
                    value = Convert.ToDouble(dgvLPODetails.Rows(i).Cells(_index).Value)
                    subTotal += value
                End If
            Catch ex As Exception

            End Try
        Next
        txtTotalPurchase.Text = Format(subTotal, "0.00")
        CalculateTotalAfterVAT()
    End Sub

    Public Sub TotalFromGridAvroval()
        TotalGrid("LPOTotalPrice")
    End Sub


    Private Sub saveLPODetails()

        Dim intRowcount As Integer = dtLPOAdd.Rows.Count

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        With objLPOPPT

            'Dim strSTLPOID As String = lSTLPOID
            objLPOPPT.ContractID = lContractID
            'Dim strContractID As String = lContractID
            objLPOPPT.StockID = lStockID
            Dim strRemarks As String = .Remarks
            ' Dim strSTLPODetID As String = lSTLPODetID
            Dim strStockID As String = lStockID
            objLPOPPT.MainStatus = lblStatusDesc.Text

        End With
        If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 
            rowLPOAdd = dtLPOAdd.NewRow()

            If intRowcount = 0 And dtAddFlag = False Then

                columnLPOAdd = New DataColumn("LPONo", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("LPODate", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("SupplierName", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("StockID", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("OrderQty", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("UnitPrice", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("TotalPrice", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("MainStatus", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("Remarks", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("APSupplierID", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("ContractId", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)

                columnLPOAdd = New DataColumn("T0Value", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T0Id", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T0Desc", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)


                columnLPOAdd = New DataColumn("T1Value", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T1Id", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T1Desc", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)


                columnLPOAdd = New DataColumn("T2Value", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T2Id", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T2Desc", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)

                columnLPOAdd = New DataColumn("T3Value", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T3Id", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T3Desc", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)

                columnLPOAdd = New DataColumn("T4Value", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T4Id", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("T4Desc", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("ContractNo", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)
                columnLPOAdd = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)

                columnLPOAdd = New DataColumn("UOM", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)

                columnLPOAdd = New DataColumn("MRCNo", System.Type.[GetType]("System.String"))
                dtLPOAdd.Columns.Add(columnLPOAdd)

                'columnLPOAdd = New DataColumn("STLPOID", System.Type.[GetType]("System.String"))
                'dtLPOAdd.Columns.Add(columnLPOAdd)


                'Assign the column value from text box value

                rowLPOAdd("LPONo") = txtLPONo.Text.Trim()
                rowLPOAdd("LPODate") = dtpLPODate.Text.Trim()
                rowLPOAdd("SupplierName") = txtSupplierCode.Text.Trim()
                rowLPOAdd("ContractNo") = txtContractNo.Text.Trim()
                rowLPOAdd("StockCode") = txtStockCode.Text.Trim()
                rowLPOAdd("StockDesc") = lblStockDescDetails.Text.Trim()
                If txtQty.Text <> String.Empty Then
                    rowLPOAdd("OrderQty") = txtQty.Text.Trim()
                Else
                    rowLPOAdd("OrderQty") = 0
                End If
                If txtUnitPrice.Text <> String.Empty Then
                    rowLPOAdd("UnitPrice") = txtUnitPrice.Text.Trim()
                End If
                If txtLPOTotalPrice.Text <> String.Empty Then
                    rowLPOAdd("TotalPrice") = txtLPOTotalPrice.Text.Trim()
                End If
                rowLPOAdd("MainStatus") = lblStatusDesc.Text.Trim()
                rowLPOAdd("Remarks") = txtLPORemarks.Text.Trim()
                rowLPOAdd("APSupplierID") = lSupplierID
                rowLPOAdd("ContractId") = lContractID

                rowLPOAdd("T0Value") = txtT0.Text.Trim()
                rowLPOAdd("T0Id") = Me.lT0Id
                rowLPOAdd("T0Desc") = Me.lblT0Value.Text.Trim

                rowLPOAdd("T1Value") = txtT1.Text.Trim()
                rowLPOAdd("T1Id") = Me.lT1Id
                rowLPOAdd("T1Desc") = Me.lblT1Value.Text.Trim

                rowLPOAdd("T2Value") = txtT2.Text.Trim()
                rowLPOAdd("T2Id") = Me.lT2Id
                rowLPOAdd("T2Desc") = Me.lblT2Value.Text.Trim

                rowLPOAdd("T3Value") = txtT3.Text.Trim()
                rowLPOAdd("T3Id") = Me.lT3Id
                rowLPOAdd("T3Desc") = Me.lblT3Value.Text.Trim

                rowLPOAdd("T4value") = txtT4.Text.Trim()
                rowLPOAdd("T4Id") = Me.lT4Id
                rowLPOAdd("T4Desc") = Me.lblT4Value.Text.Trim
                rowLPOAdd("PartNo") = lPartNo

                rowLPOAdd("StockID") = lStockID
                rowLPOAdd("UOM") = txtUOM.Text
                rowLPOAdd("MRCNo") = txtMRCNo.Text
                'rowLPOAdd("STLPOID") = lSTLPOID

                dtLPOAdd.Rows.InsertAt(rowLPOAdd, intRowcount)
                dtAddFlag = True

            Else

                'Append values to the Dt from second time

                rowLPOAdd("LPONo") = txtLPONo.Text.Trim()
                rowLPOAdd("LPODate") = dtpLPODate.Text.Trim()
                rowLPOAdd("ContractNo") = txtContractNo.Text.Trim()
                rowLPOAdd("SupplierName") = txtSupplierCode.Text.Trim()

                rowLPOAdd("StockCode") = txtStockCode.Text.Trim()
                rowLPOAdd("StockDesc") = lblStockDescDetails.Text.Trim()
                If txtQty.Text <> String.Empty Then
                    rowLPOAdd("OrderQty") = txtQty.Text.Trim()
                End If
                If txtUnitPrice.Text <> String.Empty Then
                    rowLPOAdd("UnitPrice") = txtUnitPrice.Text.Trim()
                End If
                If txtLPOTotalPrice.Text <> String.Empty Then
                    rowLPOAdd("TotalPrice") = txtLPOTotalPrice.Text.Trim()
                End If

                rowLPOAdd("MainStatus") = lblStatusDesc.Text.Trim()
                rowLPOAdd("Remarks") = txtLPORemarks.Text.Trim()
                rowLPOAdd("APSupplierID") = lSupplierID
                rowLPOAdd("ContractId") = lContractID

                rowLPOAdd("T0Value") = txtT0.Text.Trim()
                rowLPOAdd("T0Id") = Me.lT0Id
                rowLPOAdd("T0Desc") = Me.lblT0Value.Text.Trim

                rowLPOAdd("T1Value") = txtT1.Text.Trim()
                rowLPOAdd("T1Id") = Me.lT1Id
                rowLPOAdd("T1Desc") = Me.lblT1Value.Text.Trim

                rowLPOAdd("T2Value") = txtT2.Text.Trim()
                rowLPOAdd("T2Id") = Me.lT2Id
                rowLPOAdd("T2Desc") = Me.lblT2Value.Text.Trim

                rowLPOAdd("T3Value") = txtT3.Text.Trim()
                rowLPOAdd("T3Id") = Me.lT3Id
                rowLPOAdd("T3Desc") = Me.lblT3Value.Text.Trim

                rowLPOAdd("T4value") = txtT4.Text.Trim()
                rowLPOAdd("T4Id") = Me.lT4Id
                rowLPOAdd("T4Desc") = Me.lblT4Value.Text.Trim

                rowLPOAdd("StockID") = lStockID
                'rowLPOAdd("STLPOID") = lSTLPOID
                'rowLPOAdd("APSupplierID") = lSupplierID
                'rowLPOAdd("ContractId") = lContractID
                rowLPOAdd("PartNo") = lPartNo
                Try
                    rowLPOAdd("UOM") = txtUOM.Text
                    rowLPOAdd("MRCNo") = txtMRCNo.Text
                Catch ex As Exception

                End Try

                dtLPOAdd.Rows.InsertAt(rowLPOAdd, intRowcount)

            End If

            With dgvLPODetails
                .DataSource = dtLPOAdd
                .AutoGenerateColumns = False
            End With
            btnSaveAll.Focus()
        Else
            DisplayInfoMessage("Msg09")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearControls()
        End If
    End Sub

    Private Sub dgvLPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLPODetails.CellDoubleClick
        BindDgvLpoDetails()
    End Sub

    Private Sub txtQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.Leave
        If txtUnitPrice.Text = "" Then
            txtUnitPrice.Text = 0.0
        End If
        If txtUnitPrice.Text <> String.Empty And txtQty.Text <> String.Empty Then
            Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))
        End If
        ' Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))

    End Sub
    Private Sub btnSearcT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearcT4.Click
        Dim strSIVT4analysisID As String = String.Empty
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T4"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT4.Text = frmTLookup.strTValue
            lT4Id = frmTLookup.strTId
            lblT4Value.Text = frmTLookup.strTDesc
        End If

    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
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

                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then

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
        'If (e.KeyCode = Keys.Enter) Then
        '    SendKeys.Send("{Tab}")
        'End If

    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub btnLPOSearchView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPOViewSearch.Click
        GridLPOViewBind()
    End Sub

    Private Sub EditLPOView()
        Me.cmsLPO.Visible = False
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable
        If dgvLPOView.Rows.Count > 0 Then

            'Me.btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            lSTLPOID = Me.dgvLPOView.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString()
            lSupplierID = Me.dgvLPOView.SelectedRows(0).Cells("dgclSupplierID").Value.ToString()
            lContractID = Me.dgvLPOView.SelectedRows(0).Cells("dgclContractID").Value.ToString()
            dtpLPODate.Enabled = False
            'txtIPRNo.ReadOnly = True
            With objLPOPPT
                .STLPOID = lSTLPOID
            End With

            'dtLPODetails = objLPOBOL.GetLPODetailsInfo(objLPOPPT)
            dtLPOAdd = objLPOBOL.GetLPODetailsView(objLPOPPT)
            If dtLPOAdd.Rows.Count <> 0 Then
                lSTLPODetID = dtLPOAdd.Rows(0).Item("STLPODetID").ToString()
            End If

            Me.dgvLPODetails.AutoGenerateColumns = False
            Me.dgvLPODetails.DataSource = dtLPOAdd

            Me.txtLPONo.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclLPONo").Value.ToString()
            Dim Str As String = Me.dgvLPOView.SelectedRows(0).Cells("dgclLPODate").Value.ToString()
            'Me.dtpLPODate.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclLPODate").Value.ToString()
            Me.dtpLPODate.Text = New Date(Str.Substring(6, 4), Str.Substring(3, 2), Str.Substring(0, 2))
            'Me.txtSupplierCode.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclSupplierName").Value.ToString()
            Me.txtSupplierCode.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclSupplierNameCode").Value.ToString()
            Me.txtContractNo.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclContractNo").Value.ToString()
            Me.txtLPORemarks.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            psLPOStockCategoryID = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategoryID").Value.ToString()
            IPRPPT.strGlobalCategoryID = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategoryID").Value.ToString()
            Me.lblStockCategoryDescp.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategoryDescp").Value.ToString()
            Me.txtStockCategory.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategory").Value.ToString()
            Me.txtStockCategory.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategory").Value.ToString()
            psLPOStockCategory = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategory").Value.ToString()

            'psLPOStockCategory = Me.dgvLPOView.SelectedRows(0).Cells("dgclStockCategory").Value.ToString()
            ''lSupplierID = Me.dgvLPODetails.SelectedRows(0).Cells("LPOSupplierID").Value.ToString()
            lblStatusDesc.Text = Me.dgvLPOView.SelectedRows(0).Cells("dgclMainStatus").Value.ToString
            objLPOPPT.SupplierID = lSupplierID

            Me.tabLPOContainer.SelectedTab = tabLPO
            Me.dtpLPODate.Text = New Date(Str.Substring(6, 4), Str.Substring(3, 2), Str.Substring(0, 2))

        Else
            DisplayInfoMessage("Msg10")
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub GridLPOViewBind()
        'ClearGridView(dgvLPOView)

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable
        With objLPOPPT
            '''''


            Dim str As String = cbLPOViewStatus.SelectedItem.ToString()

            If chkLPOViewDate.Checked = True Then
                '.LPODate = Format(Me.dtpLPOViewDate.Value, "MM/dd/yyyy")
                .LPODate = dtpLPOViewDate.Value
            Else
                .LPODate = Nothing
            End If
            .LPONo = Me.txtLPOViewNo.Text.Trim

            .MainStatus = cbLPOViewStatus.SelectedItem.ToString()


            '''''
            'If chkLPOViewDate.Checked = True Then
            '    dtpLPOViewDate.Enabled = True
            '    .LPODate = dtpLPOViewDate.Value 'Format(Me.dtpLPOViewDate.Value, "MM/dd/yyyy")
            'Else
            '    dtpLPOViewDate.Enabled = False
            '    .LPODate = Nothing
            'End If
            '.LPONo = Trim(Me.txtLPOViewNo.Text)
            'If cbLPOViewStatus.SelectedItem.ToString.Trim.ToUpper = "SELECT ALL" Then
            '    .Status = String.Empty
            'Else
            '    .Status = cbLPOViewStatus.SelectedItem.ToString.Trim
            'End If


        End With

        dt = objLPOBOL.GetLPODetails(objLPOPPT)
        If Not dt Is Nothing Then
            If dt.Rows.Count <> 0 Then

                dgvLPOView.AutoGenerateColumns = False
                Me.dgvLPOView.DataSource = dt

                'dgvLPOView.Columns("RejectedReason").Visible = False
                lblView.Visible = False
            Else
                ClearGridView(dgvLPOView) '''''clear the records from grid view
                lblView.Visible = True
                Exit Sub
            End If
        End If

        'dgvLPOView.AutoGenerateColumns = False
    End Sub
    Private Sub dgvLPOView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLPOView.KeyDown

        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
    End Sub

    Private Sub dgvLPOViewDetails_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvLPOView.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvLPOView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvLPOView.ClearSelection()
                    Me.dgvLPOView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub
    Private Function StockCodeExist(ByVal StockCode As String) As Boolean
        Dim objDataGridViewRow As New DataGridViewRow
        'If AddFlag = True Then
        For Each objDataGridViewRow In dgvLPODetails.Rows
            If StockCode = objDataGridViewRow.Cells("LPOStockCode").Value.ToString() Then
                txtStockCode.Text = ""
                'txtRequestedQty.Text = ""
                txtStockCode.Focus()
                Return True
            End If
        Next
        Return False
        'End If
    End Function

    Private Sub dgvLPOViewDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLPOView.CellDoubleClick
        EditViewGridRecord()
    End Sub

    Private Sub BindDgvLpoDetails()

        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim objLPOPPT As New LocalPurchaseOrderPPT

        If dgvLPODetails.Rows.Count > 0 Then
            'Me.btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
            ClearFieldsOnGridClick()

            Me.txtStockCode.Text = dgvLPODetails.SelectedRows(0).Cells("LPOStockCode").Value.ToString()
            lTempStockCode = dgvLPODetails.SelectedRows(0).Cells("LPOStockCode").Value.ToString()

            If Not dgvLPODetails.SelectedRows(0).Cells("LPOUnitPrice").Value Is Nothing Then
                Me.txtUnitPrice.Text = dgvLPODetails.SelectedRows(0).Cells("LPOUnitPrice").Value.ToString()
            End If
            Me.txtQty.Text = dgvLPODetails.SelectedRows(0).Cells("LPOQTY").Value.ToString()
            Me.txtUnitPrice.Text = dgvLPODetails.SelectedRows(0).Cells("LPOUnitPrice").Value.ToString()

            Me.lblStockDescDetails.Text = dgvLPODetails.SelectedRows(0).Cells("LPOStockDesc").Value.ToString()
            If Not dgvLPODetails.SelectedRows(0).Cells("LPOTotalPrice").Value Is DBNull.Value Then
                Me.txtLPOTotalPrice.Text = dgvLPODetails.SelectedRows(0).Cells("LPOTotalPrice").Value.ToString()
            End If
            Me.txtT0.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT0").Value.ToString()

            Me.txtT1.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT1").Value.ToString()
            Me.txtT2.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT2").Value.ToString()
            Me.txtT3.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT3").Value.ToString()
            Me.txtT4.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT4").Value.ToString()
            Me.lblT0Value.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT0Desc").Value.ToString()
            Me.lblT1Value.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT1Desc").Value.ToString()
            Me.lblT2Value.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT2Desc").Value.ToString()
            Me.lblT3Value.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT3Desc").Value.ToString()
            Me.lblT4Value.Text = dgvLPODetails.SelectedRows(0).Cells("LPOT4Desc").Value.ToString()
            'txtUOM.Text = 

            Me.lT0Id = dgvLPODetails.SelectedRows(0).Cells("LPOT0Id").Value.ToString()
            Me.lT1Id = dgvLPODetails.SelectedRows(0).Cells("LPOT1Id").Value.ToString()
            Me.lT2Id = dgvLPODetails.SelectedRows(0).Cells("LPOT2Id").Value.ToString()
            Me.lT3Id = dgvLPODetails.SelectedRows(0).Cells("LPOT3Id").Value.ToString()
            Me.lT4Id = dgvLPODetails.SelectedRows(0).Cells("LPOT4Id").Value.ToString()

            Me.lblPartNoDesc.Text = dgvLPODetails.SelectedRows(0).Cells("LPOPartNo").Value.ToString()

            lStockID = dgvLPODetails.SelectedRows(0).Cells("LPOStockID").Value.ToString()
            If Not dgvLPODetails.SelectedRows(0).Cells("LPOSTLPODetID").Value Is Nothing Then
                lSTLPODetID = dgvLPODetails.SelectedRows(0).Cells("LPOSTLPODetID").Value.ToString()
            Else
                lSTLPODetID = Nothing
            End If

            AddFlag = False
            btnAddFlag = False
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub ClearFieldsOnGridClick()

        Me.txtStockCode.Text = String.Empty
        lTempStockCode = String.Empty

        Me.txtUnitPrice.Text = String.Empty
        Me.txtQty.Text = String.Empty
        Me.txtUnitPrice.Text = String.Empty
        Me.lblStockDescDetails.Text = String.Empty
        Me.txtLPOTotalPrice.Text = String.Empty

        'Me.txtT0.Text = String.Empty

        Me.txtT1.Text = String.Empty
        Me.txtT2.Text = String.Empty
        Me.txtT3.Text = String.Empty
        Me.txtT4.Text = String.Empty
        'Me.lblT0Value.Text = String.Empty
        Me.lblT1Value.Text = String.Empty
        Me.lblT2Value.Text = String.Empty
        Me.lblT3Value.Text = String.Empty
        Me.lblT4Value.Text = String.Empty

        Me.lT0Id = String.Empty
        Me.lT1Id = String.Empty
        Me.lT2Id = String.Empty
        Me.lT3Id = String.Empty
        Me.lT4Id = String.Empty
        Me.lblPartNoDesc.Text = String.Empty
        lStockID = String.Empty
        lSTLPODetID = String.Empty

    End Sub

    Private Sub tabLPOContainer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabLPOContainer.Click

        If tabLPOContainer.SelectedTab Is tabLPO = True Then
            If tabLPOContainer.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgvLPODetails.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ResetAll()
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


        ElseIf tabLPOContainer.SelectedTab Is tabLPOView = True Then

            If (dgvLPODetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And btnSaveAll.Enabled = True) Then
                If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ClearGridView(dgvLPODetails)
                    GlobalPPT.IsRetainFocus = False
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    GridLPOViewBind()
                Else
                    tabLPOContainer.SelectedTab = tabLPO
                End If
            Else
                ResetAll()
                GridLPOViewBind()
            End If

        End If

    End Sub
    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then

            Dim objDataGridViewRow As New DataGridViewRow

            For iCount As Integer = 1 To grdname.Rows.Count
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next

            If grdname.Rows.Count = 1 Then
                grdname.Rows.RemoveAt(0)
            End If
        End If

    End Sub
    'Private Sub tabLPOContainer_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabLPOContainer.Selected
    '    'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
    '    '    MsgBox(PrivilegeError)
    '    'End If
    '    GridLPOViewBind()
    '    Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpLPODate)
    '    Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpLPOViewDate)
    '    ' BindDgvLpoDetails()
    'End Sub
    Private Sub UpdateLPOView()

        If dgvLPOView.SelectedRows(0).Cells("dgclMainStatus").Value <> "OPEN" And dgvLPOView.SelectedRows(0).Cells("dgclMainStatus").Value <> "REJECTED" Then
            EditLPOView()
            'btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            ' btnAdd.Text = "Update"
            btnSaveAll.Enabled = False
            btnResetAll.Enabled = True
            txtSupplierCode.Enabled = False
            btnSearchSupplier.Enabled = False
            txtStockCategory.Enabled = False
            btnSearchStockCategory.Enabled = False
            txtLPORemarks.Enabled = False
            txtContractNo.Enabled = False
            btnSearchContract.Enabled = False
            btnSearchStockCategory.Enabled = False

            txtStockCode.ReadOnly = True

            txtQty.Enabled = False
            txtUnitPrice.Enabled = False
            txtT0.Enabled = False
            txtT1.Enabled = False
            txtT2.Enabled = False
            txtT3.Enabled = False
            txtT4.Enabled = False
            btnSearchT0.Enabled = False
            btnSearchT1.Enabled = False
            btnSearchT2.Enabled = False
            btnSearchT3.Enabled = False
            btnSearcT4.Enabled = False
            btnAdd.Enabled = False
            btnReset.Enabled = False

            btnSearchStockCode.Enabled = False
            dgvLPODetails.ReadOnly = True

        Else
            EditLPOView()
            txtSupplierCode.Enabled = False
            btnSearchSupplier.Enabled = False
            btnSearchContractNo.Enabled = False
            txtStockCategory.Enabled = False
            btnSearchStockCategory.Enabled = False
            txtContractNo.Enabled = False

            btnSaveAll.Enabled = True
            btnResetAll.Enabled = True
            'gbAddSingEntry.Visible = True
            txtStockCode.Enabled = True
            txtQty.Enabled = True
            btnSearchStockCode.Enabled = True
            dgvLPODetails.Enabled = True
            txtUnitPrice.Text = String.Empty
            txtLPOTotalPrice.Text = String.Empty
            txtT0.Enabled = True
            txtT1.Enabled = True
            txtT2.Enabled = True
            txtT3.Enabled = True
            txtT4.Enabled = True

            lblStockDescDetails.Text = String.Empty

            'txtStockCode.Text = String.Empty

        End If
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        TotalGrid("LPOTotalPrice")
    End Sub
    Private Sub UpdateLPODetails()

        Dim intCount As Integer = dgvLPODetails.CurrentRow.Index
        If lTempStockCode = txtStockCode.Text Then
            dgvLPODetails.Rows(intCount).Cells("LPOStockCode").Value = Me.txtStockCode.Text
            dgvLPODetails.Rows(intCount).Cells("LPOStockId").Value = Me.lStockID
            dgvLPODetails.Rows(intCount).Cells("LPOStockDesc").Value = Me.lblStockDescDetails.Text
            If txtUnitPrice.Text <> "" Then
                dgvLPODetails.Rows(intCount).Cells("LPOUnitPrice").Value = CDbl(Me.txtUnitPrice.Text)
            End If
            If txtQty.Text <> "" Then
                dgvLPODetails.Rows(intCount).Cells("LPOQty").Value = CDbl(Me.txtQty.Text)
            End If

            dgvLPODetails.Rows(intCount).Cells("LPOTotalPrice").Value = Me.txtLPOTotalPrice.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT0").Value = Me.txtT0.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT0Id").Value = Me.lT0Id
            dgvLPODetails.Rows(intCount).Cells("LPOT0Desc").Value = Me.lblT0Value.Text


            dgvLPODetails.Rows(intCount).Cells("LPOT1").Value = Me.txtT1.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT1Id").Value = Me.lT1Id
            dgvLPODetails.Rows(intCount).Cells("LPOT1Desc").Value = Me.lblT1Value.Text


            dgvLPODetails.Rows(intCount).Cells("LPOT2").Value = Me.txtT2.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT2Id").Value = Me.lT2Id
            dgvLPODetails.Rows(intCount).Cells("LPOT2Desc").Value = Me.lblT2Value.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT3").Value = Me.txtT3.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT3Id").Value = Me.lT3Id
            dgvLPODetails.Rows(intCount).Cells("LPOT3Desc").Value = Me.lblT3Value.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT4").Value = Me.txtT4.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT4Id").Value = Me.lT4Id
            dgvLPODetails.Rows(intCount).Cells("LPOT4Desc").Value = Me.lblT4Value.Text


            dgvLPODetails.Rows(intCount).Cells("LPOContractNo").Value = Me.txtContractNo.Text
            dgvLPODetails.Rows(intCount).Cells("LPOContractId").Value = Me.lContractID
            btnAddFlag = True
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            clear()
            btnSaveAll.Focus()
        ElseIf Not StockCodeExist(txtStockCode.Text) Then
            dgvLPODetails.Rows(intCount).Cells("LPOStockCode").Value = Me.txtStockCode.Text
            dgvLPODetails.Rows(intCount).Cells("LPOStockId").Value = Me.lStockID
            dgvLPODetails.Rows(intCount).Cells("LPOStockDesc").Value = Me.lblStockDescDetails.Text
            If txtUnitPrice.Text <> "" Then
                dgvLPODetails.Rows(intCount).Cells("LPOUnitPrice").Value = CDbl(Me.txtUnitPrice.Text)
            End If
            If txtQty.Text <> "" Then
                dgvLPODetails.Rows(intCount).Cells("LPOQty").Value = CDbl(Me.txtQty.Text)
            End If

            dgvLPODetails.Rows(intCount).Cells("LPOTotalPrice").Value = Me.txtLPOTotalPrice.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT0").Value = Me.txtT0.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT0Id").Value = Me.lT0Id
            dgvLPODetails.Rows(intCount).Cells("LPOT0Desc").Value = Me.lblT0Value.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT1").Value = Me.txtT1.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT1Id").Value = Me.lT1Id
            dgvLPODetails.Rows(intCount).Cells("LPOT1Desc").Value = Me.lblT1Value.Text


            dgvLPODetails.Rows(intCount).Cells("LPOT2").Value = Me.txtT2.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT2Id").Value = Me.lT2Id
            dgvLPODetails.Rows(intCount).Cells("LPOT2Desc").Value = Me.lblT2Value.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT3").Value = Me.txtT3.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT3Id").Value = Me.lT3Id
            dgvLPODetails.Rows(intCount).Cells("LPOT3Desc").Value = Me.lblT3Value.Text

            dgvLPODetails.Rows(intCount).Cells("LPOT4").Value = Me.txtT4.Text
            dgvLPODetails.Rows(intCount).Cells("LPOT4Id").Value = Me.lT4Id
            dgvLPODetails.Rows(intCount).Cells("LPOT4Desc").Value = Me.lblT4Value.Text


            dgvLPODetails.Rows(intCount).Cells("LPOContractNo").Value = Me.txtContractNo.Text
            dgvLPODetails.Rows(intCount).Cells("LPOContractId").Value = Me.lContractID
            btnAddFlag = True
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            clear()
            btnSaveAll.Focus()
        Else
            DisplayInfoMessage("Msg11")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearControls()
        End If

    End Sub
    Private Sub clear()

        txtStockCategory.Enabled = True

        txtStockCode.Text = String.Empty
        lblStockDescDetails.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        txtQty.Text = String.Empty
        txtLPOTotalPrice.Text = String.Empty
        lblPartNoDesc.Text = String.Empty
        If txtContractNo.Text.Trim() = String.Empty Then
            txtAccountCode.Text = String.Empty
            Me.lContractID = String.Empty
        End If

        'txtT0.Text = String.Empty
        'lblT0Value.Text = String.Empty
        txtT1.Text = String.Empty
        lblT1Value.Text = String.Empty
        txtT2.Text = String.Empty
        lblT2Value.Text = String.Empty
        txtT3.Text = String.Empty
        lblT3Value.Text = String.Empty
        txtT4.Text = String.Empty
        lblT4Value.Text = String.Empty
        txtUOM.Clear()
        txtMRCNo.Clear()
    End Sub
    Private Sub DeleteLPOVIew()
        Me.cmsLPO.Visible = False

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable
        If dgvLPOView.Rows.Count > 0 Then
            If dgvLPOView.SelectedRows(0).Cells("dgclMainStatus").Value.ToString() = "OPEN" Or dgvLPOView.SelectedRows(0).Cells("dgclMainStatus").Value.ToString() = "REJECTED" Then
                If MsgBox(rm.GetString("Msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Me.lSTLPOID = Me.dgvLPOView.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString()
                    With objLPOPPT
                        .STLPOID = Me.lSTLPOID
                    End With
                    objLPOBOL.DeleteLPODetail(objLPOPPT)
                    GridLPOViewBind()
                Else
                    DisplayInfoMessage("Msg12")
                    'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                DisplayInfoMessage("Msg13")
                'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            DisplayInfoMessage("Msg14")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub chkLPOViewDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLPOViewDate.CheckedChanged
        If chkLPOViewDate.Checked = True Then
            dtpLPOViewDate.Enabled = True
        Else
            dtpLPOViewDate.Enabled = False
        End If
    End Sub
    Private Sub AddLPO()
        btnAddFlag = True
        Me.tabLPOContainer.SelectedTab = tabLPO
        toGetLPONo()
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        AddLPO()
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        EditViewGridRecord()

    End Sub

    Private Sub EditViewGridRecord()

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvLPOView.RowCount > 0 Then
                    UpdateLPOView()
                End If
            End If
        End If

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteLPOVIew()
    End Sub

    Private Sub btnLPOConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPOConform.Click
        ConfirmApproval()
        'Dim rowsAffected As Integer = 0
        'Dim objLPOPPT As New LocalPurchaseOrderPPT
        'Dim objLPOBOL As New LocalPurchaseOrderBOL
        'If cmbLPOStatus.SelectedItem = String.Empty Then
        '    MessageBox.Show("Please select status to Approve")
        'Else
        '    If cmbLPOStatus.SelectedItem = "REJECTED" And txtRejectedReason.Text = String.Empty Then
        '        MessageBox.Show("Please enter valid Rejected reason")
        '        Exit Sub
        '    End If
        '    With objLPOPPT
        '        .STLPOID = lSTLPOID
        '        '.LPODate = lModifiedOn
        '        .Status = cmbLPOStatus.SelectedItem.ToString()
        '        If .Status = "REJECTED" Then
        '            .RejectedReason = txtRejectedReason.Text
        '        Else
        '            .RejectedReason = String.Empty
        '        End If
        '        .Remarks = txtLPORemarks.Text
        '    End With
        '        rowsAffected = objLPOBOL.Update_LPOApproval(objLPOPPT)
        '    If rowsAffected > 0 Then
        '        If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '            MessageBox.Show(" Approved Successfully ")
        '            LocalPurchaseOrderApprovalFrm.Refresh()
        '            Me.Close()
        '        Else
        '            MessageBox.Show(" Confirmation Failed ", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    End If
        'End If

    End Sub
    Private Function IsValidComboSelect() As Boolean
        If cmbLPOStatus.SelectedIndex = -1 Then
            DisplayInfoMessage("Msg15")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        If (cmbLPOStatus.Text = "--Select Status--") Then
            DisplayInfoMessage("Msg16")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        Return True
    End Function
    Private Sub ConfirmApproval()
        If IsValidComboSelect() = False Then
            Exit Sub
        End If

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOApprovalPPT As New LocalPurchaseOrderApprovalPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL

        With objLPOPPT
            .STLPOID = lSTLPOID
            '.LPODate = lModifiedOn
            .Status = cmbLPOStatus.SelectedItem.ToString()
        End With

        If cmbLPOStatus.SelectedItem.ToString() = "APPROVED" Then
            txtRejectedReason.Text = String.Empty
            If MsgBox(rm.GetString("Msg34"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                objLPOPPT.Status = "APPROVED"
                objLPOBOL.Update_LPOApproval(objLPOPPT)
                DisplayInfoMessage("Msg17")
                'MessageBox.Show("Approved Successfully")

                'Call TaskMonitor Update after successful approval -Start

                Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                Dim dsTaskMonitorUPDATE As New DataSet
                objStoreMonthEndClosingPPT.ModID = 2
                objStoreMonthEndClosingPPT.Task = "Local Purchase Order approval"
                objStoreMonthEndClosingPPT.Complete = "Y"
                dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)

                'Call TaskMonitor Update after successful approval -End

                GlobalPPT.IsButtonClose = True
                Me.Close()

            End If
        ElseIf cmbLPOStatus.SelectedItem.ToString() = "REJECTED" Then
            If txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg18")
                'MessageBox.Show("Please enter the rejected reason")
                txtRejectedReason.Focus()
                Exit Sub
            Else
                If MsgBox(rm.GetString("Msg19"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Reject the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    objLPOPPT.Status = "REJECTED"
                    objLPOPPT.RejectedReason = txtRejectedReason.Text.Trim()
                    Dim ds As New DataSet
                    objLPOBOL.Update_LPOApproval(objLPOPPT)
                    DisplayInfoMessage("Msg20")
                    'MessageBox.Show("Rejected Successfully")
                    txtRejectedReason.Text = String.Empty

                    GlobalPPT.IsButtonClose = True
                    Me.Close()

                End If
            End If
        End If
    End Sub
    Private Sub cmbLPOStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLPOStatus.SelectedIndexChanged
        If cmbLPOStatus.SelectedItem = "REJECTED" Then
            lblRejectedReason.Visible = True
            txtRejectedReason.Visible = True

        Else
            lblRejectedReason.Visible = False
            txtRejectedReason.Visible = False

        End If
    End Sub
    'Private Sub txtT0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT0.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    Private Sub txtT0_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT0.Leave
        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T0Value = txtT0.Text.Trim()
            objSIV.TDecide = "T0"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg21")
                'MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                Me.lblT0Name.Text = String.Empty
                Me.txtT0.Text = String.Empty
                lT0Id = String.Empty
                txtT0.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT0Value.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT0.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT0Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT0Value.Text = String.Empty
            Me.txtT0.Text = String.Empty
            lT0Id = String.Empty
        End If
    End Sub
    'Private Sub txtT1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT1.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub
    Private Sub txtT1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT1.Leave
        If txtT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T1Value = txtT1.Text.Trim()
            objSIV.TDecide = "T1"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg22")
                'MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
                Me.lblT1Name.Text = String.Empty
                Me.txtT1.Text = String.Empty
                lT1Id = String.Empty
                txtT1.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT1Value.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT1.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT1Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT1Value.Text = String.Empty
            Me.txtT1.Text = String.Empty
            lT1Id = String.Empty
        End If
    End Sub
    'Private Sub txtT2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT2.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    Private Sub txtT2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT2.Leave
        If txtT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T2Value = txtT2.Text.Trim()
            objSIV.TDecide = "T2"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg23")
                'MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
                Me.lblT2Name.Text = String.Empty
                Me.txtT2.Text = String.Empty
                lT2Id = String.Empty
                txtT2.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT2Value.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT2.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT2Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT2Value.Text = String.Empty
            Me.txtT2.Text = String.Empty
            lT2Id = String.Empty
        End If
    End Sub

    'Private Sub txtT3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT3.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    Private Sub txtT3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT3.Leave
        If txtT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T3Value = txtT3.Text.Trim()
            objSIV.TDecide = "T3"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg24")
                'MessageBox.Show("Invalid T3 Value,Please Choose it from look up")
                Me.lblT3Value.Text = String.Empty
                Me.txtT3.Text = String.Empty
                lT3Id = String.Empty
                txtT3.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    'Me.lblT3Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                    lblT3Value.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT3.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT3Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT3Value.Text = String.Empty
            Me.txtT3.Text = String.Empty
            lT3Id = String.Empty
        End If
    End Sub

    'Private Sub txtT4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT4.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub
    Private Sub txtT4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        If txtT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T4Value = txtT4.Text.Trim()
            objSIV.TDecide = "T4"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg25")
                'MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
                Me.lblT4Name.Text = String.Empty
                Me.txtT4.Text = String.Empty
                lT4Id = String.Empty
                txtT4.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT4Value.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT4.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT4Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT4Value.Text = String.Empty
            Me.txtT4.Text = String.Empty
            lT4Id = String.Empty
        End If
    End Sub

    'Private Sub txtContractNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContractNo.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    Private Sub txtContractNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractNo.Leave
        If txtContractNo.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.ContractNo = txtContractNo.Text.Trim()
            objSIV.TDecide = "ContractNO"
            ds = StoreIssueVoucherBOL.ContractIDSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg26")
                'MessageBox.Show("Invalid Contract No  Value,Please Choose it from look up")
                'Me.lblContactNo.Text = String.Empty
                Me.txtContractNo.Text = String.Empty
                'lContractID = String.Empty
                txtContractNo.Focus()
                Exit Sub
            Else

                If ds.Tables(0).Rows(0).Item("ContractNo").ToString() <> String.Empty Then
                    Me.txtContractNo.Text = ds.Tables(0).Rows(0).Item("ContractNo").ToString()
                End If
                lContractID = ds.Tables(0).Rows(0).Item("ContractId").ToString()
            End If
        Else
            'Me.lblT4Name.Text = String.Empty
            Me.txtContractNo.Text = String.Empty
            'lContractID = String.Empty
        End If
    End Sub

    'Private Sub txtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockCode.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub



    'Private Sub txtUnitPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnitPrice.Leave
    '    If txtUnitPrice.Text <> String.Empty And txtQty.Text <> String.Empty Then
    '        Me.txtLPOTotalPrice.Text = CDbl(Convert.ToDecimal(txtQty.Text) * CDbl(Convert.ToDecimal(txtUnitPrice.Text)))
    '    End If
    'End Sub
    'Private Sub dtpLPODate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpLPODate.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    'Private Sub txtLPORemarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLPORemarks.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    'Private Sub txtSupplierName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSupplierCode.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    'Private Sub btnAdd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnAdd.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    'Private Sub btnReset_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnReset.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub

    'Private Sub btnSaveAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSaveAll.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub
    'Private Sub btnResetAll_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnResetAll.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub
    Private Sub EditLPOView123(ByVal STLPOIDVal As String)
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        objLPOPPT.STLPOID = STLPOIDVal
        dtLPOAdd = objLPOBOL.GetLPODetailsView(objLPOPPT)
        dgvLPODetails.DataSource = dtLPOAdd
    End Sub
    Private Sub dgvLPODetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLPODetails.KeyDown
        If e.KeyCode = Keys.Return Then
            BindDgvLpoDetails()
            e.Handled = True
        End If
    End Sub
    Private Sub txtSupplierCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Leave

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPONBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable
        If txtSupplierCode.Text.Trim <> String.Empty Then
            objLPOPPT.SupplierID = txtSupplierCode.Text.Trim
            dt = objLPONBOL.SearchSupplier(objLPOPPT)
            If dt.Rows.Count <> 0 Then
                lSupplierName = dt.Rows(0).Item("SupplierName").ToString()
                Me.lblSupplierName.Text = lSupplierName
                lSupplierCode = dt.Rows(0).Item("SupplierCode").ToString()
                lSupplierID = dt.Rows(0).Item("APSupplierID").ToString()
            Else
                DisplayInfoMessage("Msg28")
                'MessageBox.Show("Invalid Supplier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSupplierCode.Text = String.Empty
                txtSupplierCode.Focus()
            End If

        Else

            lblSupplierName.Text = String.Empty
            lSupplierName = String.Empty
            lSupplierCode = String.Empty
            lSupplierID = String.Empty

        End If

    End Sub
    Private Sub btnSearchSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSupplier.Click
        Dim objLPONo As New APSupplierLookUp()
        objLPONo.BindSupplier()
        Dim result As DialogResult = APSupplierLookUp.ShowDialog()
        If APSupplierLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            lSupplierID = APSupplierLookUp._lSupplierID
            lSupplierCode = APSupplierLookUp._lSupplierCode.Trim

            lSupplierName = APSupplierLookUp._lSupplierName.Trim
            lblSupplierName.Text = lSupplierName.Trim
            Me.txtSupplierCode.Text = lSupplierCode.Trim
        End If
    End Sub

    Private Sub btnSearchContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchContract.Click
        Dim frmContratNoLookup As New ContractNoLookup
        frmContratNoLookup.ShowDialog()
        If frmContratNoLookup.strContractId <> String.Empty Then
            Me.txtContractNo.Text = frmContratNoLookup.strContractNo.Trim
            lContractID = frmContratNoLookup.strContractId
            'Me.lblContractorValue.Text = frmContratNoLookup.strContractName
        End If
    End Sub

    Private Sub txtUnitPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub
    Private Sub txtUnitPrice_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrice.Leave
        If txtUnitPrice.Text <> String.Empty And txtQty.Text <> String.Empty Then
            Me.txtLPOTotalPrice.Text = CDbl(Convert.ToDecimal(txtQty.Text) * CDbl(Convert.ToDecimal(txtUnitPrice.Text)))
        End If
    End Sub

    Private Sub txtUnitPrice_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnitPrice.KeyDown
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

                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then

                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        isDecimal = twoDecimalPlaces.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If
        'If (e.KeyCode = Keys.Enter) Then
        '    SendKeys.Send("{Tab}")
        'End If

    End Sub



    'Private Sub txtUsageCOACode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If txtUsageCOACode.Text.Trim() <> String.Empty Then
    '        If txtUsageCOACode.Text.Trim.ToString.Length <> 13 Then
    '            DisplayInfoMessage("Msg29")
    '            'MessageBox.Show("Please enter 13 digit Account code")
    '            Exit Sub
    '        End If

    '        Dim ds As New DataSet
    '        Dim objLPOPPT As New LocalPurchaseOrderPPT

    '        objLPOPPT.COACode = txtUsageCOACode.Text.Trim()
    '        ds = LocalPurchaseOrderBOL.AcctlookupSearch(objLPOPPT, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            DisplayInfoMessage("Msg30")
    '            'MessageBox.Show("Invalid Usage COA Account code,Please Choose it from look up")
    '            txtUsageCOACode.Text = String.Empty
    '            lblUsageCOADescp.Text = String.Empty
    '            psLPOUsageCOAID = String.Empty
    '            ''GlobalPPT.psAcctExpenditureType = String.Empty
    '            txtUsageCOACode.Focus()
    '            Exit Sub
    '        Else
    '            If Not ds.Tables(0).Rows(0).Item("COACode") Is DBNull.Value Then
    '                txtUsageCOACode.Text = ds.Tables(0).Rows(0).Item("COACode")
    '            Else
    '                txtUsageCOACode.Text = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("COADescp") Is DBNull.Value Then
    '                lblUsageCOADescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
    '            Else
    '                lblUsageCOADescp.Text = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("COAID") Is DBNull.Value Then
    '                psLPOUsageCOAID = ds.Tables(0).Rows(0).Item("COAID")
    '            Else
    '                psLPOUsageCOAID = String.Empty
    '            End If
    '            ''If Not ds.Tables(0).Rows(0).Item("ExpenditureAG") Is DBNull.Value Then
    '            ''    GlobalPPT.psAcctExpenditureType = ds.Tables(0).Rows(0).Item("ExpenditureAG")
    '            ''    lsVDExpenditureAG = ds.Tables(0).Rows(0).Item("ExpenditureAG")
    '            ''Else
    '            ''    GlobalPPT.psAcctExpenditureType = String.Empty
    '            ''    lsVDExpenditureAG = String.Empty
    '            ''End If

    '        End If
    '    Else
    '        txtUsageCOACode.Text = String.Empty
    '        lblUsageCOADescp.Text = String.Empty
    '        psLPOUsageCOAID = String.Empty
    '        ''GlobalPPT.psAcctExpenditureType = String.Empty
    '    End If
    'End Sub


    'Private Sub btnSearchUsageCOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUsageCOA.Click
    '    Dim frmAcctcodeLookup As New COALookup
    '    Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
    '    If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.txtUsageCOACode.Text = frmAcctcodeLookup.strAcctcode
    '        psLPOUsageCOAID = frmAcctcodeLookup.strAcctId
    '        lblUsageCOADescp.Text = frmAcctcodeLookup.strAcctDescp
    '        '' GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
    '        ''lsVDExpenditureAG = frmAcctcodeLookup.strAcctExpenditureAG
    '    End If
    'End Sub

    Private Sub tabLPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabLPO.Click
        'ResetAll()
    End Sub

    Private Sub DeleteStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteStripMenuItem3.Click

        If dgvLPODetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvLPODetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else
            If MsgBox(rm.GetString("Msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                DeleteMultientrydatagrid()
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub DeleteMultientrydatagrid()


        If Not dgvLPODetails.SelectedRows(0).Cells("LPOSTLPODetID").Value Is Nothing Then
            lSTLPODetailID = dgvLPODetails.SelectedRows(0).Cells("LPOSTLPODetID").Value.ToString
        Else
            lSTLPODetailID = String.Empty
        End If


        lDelete = 0
        If lSTLPODetailID <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lSTLPODetailID)

        End If
        Dim Dr As DataRow
        Dr = dtLPOAdd.Rows.Item(dgvLPODetails.CurrentRow.Index)
        Dr.Delete()
        dtLPOAdd.AcceptChanges()
        lSTLPODetailID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL


        lDelete = DeleteMultientry.Count

        While (lDelete > 0)

            With objLPOPPT
                .STLPODetID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntLPODetailDelete As New Integer
            IntLPODetailDelete = objLPOBOL.DeleteMultiEntryLPO(objLPOPPT)

            lDelete = lDelete - 1

        End While


    End Sub



    'Private Sub LocalPuchaseOrderFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    '    'Dim mdiparent As New MDIParent
    '    'If dgvLPODetails.RowCount > 0 And mdiparent.strMenuID = "M2" Then

    '    '    If MsgBox(rm.GetString("Msg38"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

    '    '    End If

    '    'End If

    'End Sub

    Private Sub btnLPOViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPOViewReport.Click

        Dim ObjRecordExist As New Object
        Dim ObjLPOPPT As New LocalPurchaseOrderPPT
        Dim ObjLPOBOL As New LocalPurchaseOrderBOL
        ObjRecordExist = ObjLPOBOL.LPORecordIsExisT(ObjLPOPPT)
        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg35")
            'MsgBox("No Records Available!")

        Else
            StrFrmName = "LPOReport"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub


    Private Sub dgvLPOView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLPOView.CellContentClick

        If e.ColumnIndex = 23 Then

            Dim ObjRecordExist As New Object
            Dim ObjLPOPPT As New LocalPurchaseOrderPPT
            Dim ObjLPOBOL As New LocalPurchaseOrderBOL
            ObjRecordExist = ObjLPOBOL.LPORecordIsExisT(ObjLPOPPT)
            If ObjRecordExist = 0 Then
                DisplayInfoMessage("Msg35")
                'MsgBox("No Records Available!")

            Else
                psSTLPOID = dgvLPOView.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString
                StrFrmName = "LPOReport"
                ReportODBCMethod.ShowDialog()
                StrFrmName = ""
                psSTLPOID = ""
            End If

        End If

    End Sub



    Private Sub btnSearchStockCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCategory.Click

        NonStockIPRFrm.StrFrmName = "LPO"

        Me.Cursor = Cursors.WaitCursor

        txtStockCode.Text = String.Empty
        lblStockDescDetails.Text = String.Empty


        Dim frmStockCategoryLookup As New CategoryLookup
        frmStockCategoryLookup.ShowDialog()

        If frmStockCategoryLookup._lStockCategoryID <> String.Empty Then

            txtStockCategory.Text = frmStockCategoryLookup._lStockCategoryCode.Trim
            psLPOStockCategory = frmStockCategoryLookup._lStockCategoryCode.Trim
            psLPOStockCategoryDescp = frmStockCategoryLookup._lStockCategory.Trim
            lblStockCategoryDescp.Text = frmStockCategoryLookup._lStockCategory.Trim

            psLPOStockCategoryID = frmStockCategoryLookup._lStockCategoryID.Trim
            psLPOStockCOAID = frmStockCategoryLookup._lStockCOAID
            psLPOVarianceCOAID = frmStockCategoryLookup._lVarianceCOAID

        End If

        Me.Cursor = Cursors.Arrow


    End Sub


    Private Sub txtStockCategory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCategory.Leave

        NonStockIPRFrm.StrFrmName = "LPO"

        If txtStockCategory.Text.Trim() <> String.Empty Then

            Dim dt As New DataTable
            Dim CategoryDesc As String
            Dim objLPOPPT As New LocalPurchaseOrderPPT
            Dim objLPOBOL As New LocalPurchaseOrderBOL
            CategoryDesc = Me.txtStockCategory.Text.Trim
            dt = objLPOBOL.StockCategorySearch(CategoryDesc)

            If dt.Rows.Count > 0 Then


                txtStockCode.Text = String.Empty
                lblDescription.Text = String.Empty
                lblUnit.Text = String.Empty

                If dt.Rows(0).Item("STCategoryDescp") <> String.Empty Then
                    lStockDesc = dt.Rows(0).Item("STCategoryDescp").ToString()
                    lblStockCategoryDescp.Text = lStockDesc
                End If
                If dt.Rows(0).Item("STCategoryCode") <> String.Empty Then
                    psLPOStockCategory = dt.Rows(0).Item("STCategoryCode").ToString().Trim
                End If

                psLPOStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()
                IPRPPT.strGlobalCategoryID = dt.Rows(0).Item("STCategoryID").ToString()

                If dt.Rows(0).Item("StockCOAID").ToString() <> String.Empty Then
                    psLPOStockCOAID = dt.Rows(0).Item("StockCOAID").ToString()
                End If
                If dt.Rows(0).Item("VarianceCOAID").ToString() <> String.Empty Then
                    psLPOVarianceCOAID = dt.Rows(0).Item("VarianceCOAID").ToString()
                End If

            Else

                DisplayInfoMessage("Msg42")
                'MessageBox.Show("Invalid Stock Category , Please choose correct category from lookup")

                txtStockCategory.Text = String.Empty
                lblStockCategoryDescp.Text = String.Empty
                lStockDesc = String.Empty
                psLPOStockCategoryID = String.Empty
                psLPOStockCOAID = String.Empty
                psLPOVarianceCOAID = String.Empty
                IPRPPT.strGlobalCategoryID = String.Empty
                ''btnSearchStockCategory.Focus()
                Exit Sub

            End If

        Else

            txtStockCategory.Text = String.Empty
            lblStockCategoryDescp.Text = String.Empty
            lStockDesc = String.Empty
            psLPOStockCategoryID = String.Empty
            psLPOStockCOAID = String.Empty
            psLPOVarianceCOAID = String.Empty
            IPRPPT.strGlobalCategoryID = String.Empty
            ''btnSearchStockCategory.Focus()

        End If

    End Sub


    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        'If Val(txtQty.Text) > 0 Then
        '    txtQty.Text = Format(Val(txtQty.Text), "0")
        'End If

    End Sub

    Private Sub EditStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditStripMenuItem2.Click
        BindDgvLpoDetails()
    End Sub

    Private Sub LocalPuchaseOrderFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim mdiparent As New MDIParent

        If (dgvLPODetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False

            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M2"
                'mdiparent.lblMenuName.Text = "IPR"

            End If

        End If

    End Sub

    Private Sub txtLPOTotalPrice_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLPOTotalPrice.TextChanged
        'Dim vat As Double = (Convert.ToDouble(txtLPOTotalPrice.Text) * 10) / 100 'Default 10% from Total Price or Total PO
        'txtVATTotal.Text = vat.ToString()
    End Sub

    Public Sub CalculateTotalAfterVAT()
        Try
            If txtTotalPurchase.Text IsNot Nothing And txtTotalPurchase.Text <> "" Then
                'Dim total As Int64 = (Convert.ToInt64(txtTotalPurchase.Text) * Convert.ToInt64(txtVATPercent.Text)) / 100
                Dim total As Double = (Convert.ToDouble(txtTotalPurchase.Text) * Convert.ToDouble(txtVATPercent.Text)) / 100
                txtVATTotal.Text = Format(total, "0.00")
            End If
            'txtTotal.Text = Convert.ToInt64(txtTotalPurchase.Text) + Convert.ToInt64(txtVATTotal.Text) + Convert.ToInt64(txtTransportationCost.Text)
            Dim totals As Double
            totals = Convert.ToDouble(txtTotalPurchase.Text) + Convert.ToDouble(txtVATTotal.Text) + Convert.ToDouble(txtTransportationCost.Text)
            txtTotal.Text = Format(totals, "0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalPurchase_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalPurchase.TextChanged
        CalculateTotalAfterVAT()
    End Sub

    Private Sub txtVATPercent_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATPercent.TextChanged
        CalculateTotalAfterVAT()
    End Sub

    Private Sub txtTransportationCost_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTransportationCost.TextChanged
        Try
            If txtTransportationCost.Text IsNot Nothing Then
                Dim nilai = (Convert.ToInt64(txtTransportationCost.Text) + Convert.ToInt64(txtTotalPurchase.Text)) + Convert.ToInt64(txtVATTotal.Text)
                txtTotal.Text = nilai
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
