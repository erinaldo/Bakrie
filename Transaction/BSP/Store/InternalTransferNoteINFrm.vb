Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient
Imports System.Math
Public Class InternalTransferNoteINFrm

    Private lStockCode As String = String.Empty
    Private lStockDesc As String = String.Empty
    Private lUnitprice As String = String.Empty
    Private lUnit As String = String.Empty
    Private lStockID As String = String.Empty
    Private lCOAID As String = String.Empty
    Private lStockCOAID As String = String.Empty
    Private lVarianceCOAID As String = String.Empty
    Private lAccountCode As String = String.Empty
    Private lAccountDesc As String = String.Empty

    Private lSenderLocation As String = String.Empty
    Private lSupplierCOAID As String = String.Empty

    Private lT0 As String = String.Empty
    Private lT1 As String = String.Empty
    Private lT2 As String = String.Empty
    Private lT3 As String = String.Empty
    Private lT4 As String = String.Empty

    Private lSenderLocationID As String = String.Empty
    Private lPartNo As String = String.Empty
    Private lSTITNIn As String = String.Empty
    Private lSTITNInID As String = String.Empty
    Private lSTITNInDetID As String = String.Empty
    Private lAvailableQty As Double = 0.0
    Private gvSTITNInDetID As String = String.Empty
    Private lModifiedOn As String = String.Empty
    Private DTFlag As Boolean = False
    Private AddFlag As Boolean = True

    'For Approval Part 
    Private AppSTDPrice As Double = 0.0
    Private AppStockCOAID As String = String.Empty
    Private AppValue As Double = 0.0
    Private AppSTDPriceValue As Double = 0.0
    Private AppVariancePrice As Double = 0.0
    Private AppVarianceCOAID As String = String.Empty

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")

    Dim dtITNIn As New DataTable("dgvITNIn")
    Dim columnITNIn As DataColumn
    Dim rowITNIn As DataRow
    Shadows mdiparent As New MDIParent
    Public Shared StrFrmName As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteINFrm))
    Dim btnAddGridHeaderClick As Boolean = False


    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Public lsSTInternalTransferInDetailsID As String = String.Empty
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteINFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub InternalTransferNoteINFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        If mdiparent.strMenuID = "M8" Then
            dtpITNDate.Format = DateTimePickerFormat.Custom
            dtpITNDate.CustomFormat = "dd/MM/yyyy"
            dtpviewITNDate.Format = DateTimePickerFormat.Custom
            dtpviewITNDate.CustomFormat = "dd/MM/yyyy"
            GlobalBOL.SetDateTimePicker(dtpITNDate)
            GlobalBOL.SetDateTimePicker(dtpviewITNDate)
            lblAccountDesc.Visible = False
            lblAvailablevalue.Visible = False
            lblUnitValue.Visible = False
            'lblUnitPriceValue.Visible = False
            lblStockDesc.Visible = False
            lblPartNo.Visible = False
            cbStatus.SelectedItem = "OPEN"
            btnSearchAccCode.Visible = False
            tcITNIN.SelectedTab = tbpgView
            BindITNINViewgrid()
            SetUICulture(GlobalPPT.strLang)
            If lblStatusDesc.Text = "REJECTED" Then
                lblRejectReason.Visible = True
                lblcolon21.Visible = True
                lblRejectreasondesc.Visible = True
            End If
        ElseIf strMenuID = "M119" Then
            toloadITNIn_inApproval()
            dtpITNDate.Format = DateTimePickerFormat.Custom
            dtpITNDate.CustomFormat = "dd/MM/yyyy"
            gbITNInApproval.Visible = True
            gbsave.Visible = False
            lblRejectedReason.Visible = False
            txtRejectedReason.Visible = False
            lblColon15.Visible = False
            lblStockDesc.Visible = False
            lblUnitValue.Visible = False
            lblUnitValue.Visible = False
            lblAvailablevalue.Visible = False
            btnSaveAll.Enabled = False
            btnResetAll.Enabled = False
            lblAccountDesc.Visible = False
            lblPartNo.Visible = False
            txtITNINNo.ReadOnly = True
            txtSendersLocation.ReadOnly = True
            dtpITNDate.Enabled = False
            txtRemarks.ReadOnly = True
            txtStockCode.ReadOnly = True
            txtTransferQty.ReadOnly = True
            txtUnitPrice.ReadOnly = True
            btnSearchAccCode.Enabled = False
            btnSearchStockCode.Enabled = False
            btnSearchSendersLocation.Enabled = False
            BtnVehicle.Enabled = False
            txtStockCode.Text = String.Empty
            lblAccCode.Text = String.Empty
            txtTransferQty.Text = String.Empty
            txtUnitPrice.Text = String.Empty
            cbApprovalStatus.SelectedIndex = 0
            SetUICulture(GlobalPPT.strLang)
            txtRejectedReason.Text = String.Empty
        End If
    End Sub

    Private Sub InternalTransferNoteINFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim mdiparent As New MDIParent

        If (dgvITNIn.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) And mdiparent.strMenuID = "M8" And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

    Public Sub BindITNInMast_inApproval(ByVal strSTITNInID As String, ByVal strITNInNo As String, ByVal strITNInDate As Date, ByVal strSendersLocation As String, ByVal strStatus As String, ByVal strRemarks As String, ByVal strT0 As String, ByVal strT1 As String, ByVal strT2 As String, ByVal strT3 As String, ByVal strT4 As String, ByVal strSendersLocationID As String, ByVal strSupplierCOAID As String, strOperatorName As String, strTransportDate As DateTime, strVehicleNo As String, strMRCNo As String)
        lSTITNInID = strSTITNInID
        txtITNINNo.Text = strITNInNo
        dtpITNDate.Value = strITNInDate
        dtpITNDate.Format = DateTimePickerFormat.Custom
        dtpITNDate.CustomFormat = "dd/MM/yyyy"
        txtSendersLocation.Text = strSendersLocation
        lSenderLocationID = strSendersLocationID
        lT0 = strT0
        lT1 = strT1
        lT2 = strT2
        lT3 = strT3
        lT4 = strT4
        lSupplierCOAID = strSupplierCOAID
        lblStatusDesc.Text = strStatus
        txtRemarks.Text = strRemarks
        'lModifiedOn = strModifiedOn
        txtITNINNo.ReadOnly = True
        txtOperatorName.Text = strOperatorName
        dtpTransportDate.Value = strTransportDate
        txtVehicleNo.Text = strVehicleNo
        txtMRCNo.Text = strMRCNo
    End Sub

    Public Sub BindITNInDet_inApproval(ByVal strSTITNInID As String)
        Dim objITNInPPT As New InternalTransferNoteINPPT
        Dim objITNInBOL As New InternalTransferNoteINBOL
        Dim dt As New DataTable
        With objITNInPPT
            .STInternalTransferInID = strSTITNInID
        End With
        dt = objITNInBOL.ITNInDetails_Select(objITNInPPT)
        Me.dgvITNIn.AutoGenerateColumns = False
        Me.dgvITNIn.DataSource = dt
        strMenuID = "M119"
    End Sub

    Private Sub toloadITNIn_inApproval()
        Dim MdiParent As New MDIParent

        If MdiParent.strMenuID = "M119" Then
            tcITNIN.SelectedTab = tbpgITNInAdd
            tcITNIN.TabPages.Remove(tbpgView)

        Else
            'tcIPR.SelectedTab = tbIPR
            'tcIPR.TabPages.Remove(tbView)
            'cmbSIVNO.Text = sivnumberVal
            'fillIssueBtachTotalValueDs(sivnumberVal)
            ''//Remove tab page
            ''tabControl1.TabPages.Remove(tabPage2);
            ''//Insert at index 1
            ''tabControl1.TabPages.Insert(1, tabPage2);
        End If
    End Sub

    Private Sub btnSearchSendersLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSendersLocation.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then

            lSenderLocationID = SenderReceiverLocLookup._lSenderLocationID

            If Not SenderReceiverLocLookup._lT0 Is DBNull.Value Then
                lT0 = SenderReceiverLocLookup._lT0
            Else
                lT0 = String.Empty
            End If
            If Not SenderReceiverLocLookup._lT1 Is DBNull.Value Then
                lT1 = SenderReceiverLocLookup._lT1
            Else
                lT1 = String.Empty
            End If

            If Not SenderReceiverLocLookup._lT2 Is DBNull.Value Then
                lT2 = SenderReceiverLocLookup._lT2
            Else
                lT2 = String.Empty
            End If
            If Not SenderReceiverLocLookup._lT3 Is DBNull.Value Then
                lT3 = SenderReceiverLocLookup._lT3
            Else
                lT3 = String.Empty
            End If
            If Not SenderReceiverLocLookup._lT4 Is DBNull.Value Then
                lT4 = SenderReceiverLocLookup._lT4
            Else
                lT4 = String.Empty
            End If

            txtSendersLocation.Text = SenderReceiverLocLookup._lSenderLocation

        End If
    End Sub

    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click

        Dim stockDt As New DataTable
        Dim ObjStockBOL As New IPRBOL
        Dim ObjStockCode As New IPRPPT
        'Dim StockCategory As New StockCodeLookUp()
        'Dim result As DialogResult = StockCodeByCategoryLookup.ShowDialog()
        'If StockCodeByCategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then
        Dim frmStockCodeLookup As New StockCodeByCategoryLookup
        frmStockCodeLookup.ShowDialog()

        If frmStockCodeLookup._lStockCode <> String.Empty Then

            lStockCode = frmStockCodeLookup._lStockCode
            lStockDesc = frmStockCodeLookup._lStockDesc
            lUnitprice = frmStockCodeLookup._lStockUnitprice
            lUnit = frmStockCodeLookup._lUnit
            lStockID = frmStockCodeLookup._lStockID
            lPartNo = frmStockCodeLookup._lPartNo
            lStockCOAID = frmStockCodeLookup._lCOAID
            lVarianceCOAID = frmStockCodeLookup._lVarianceCOAID
            lblAvailablevalue.Text = frmStockCodeLookup._lAvailableQty
            lblAccCode.Text = frmStockCodeLookup._lAccountCode
            lblAccountDesc.Text = frmStockCodeLookup._lAccountDesc

            'ObjStockCode.stockID = StockCodeLookUp._lStockID
            'If Me.lStockID <> String.Empty Then
            '    stockDt = ObjStockBOL.GetAvailableQTy(ObjStockCode)
            '    If stockDt.Rows.Count <> 0 Then
            '        lblUnitPriceValue.Text = stockDt.Rows(0).Item("UnitPrice").ToString()
            '        lblAvailablevalue.Text = stockDt.Rows(0).Item("AvailableQty").ToString()
            '        If lblAvailablevalue.Text = String.Empty Then
            '            lblAvailablevalue.Text = "0"
            '        End If
            '    End If
            'End If

            lblStockDesc.Visible = True
            lblAccountDesc.Visible = True
            '  lblUnitPriceValue.Visible = True
            lblUnitValue.Visible = True
            lblAvailablevalue.Visible = True
            lblPartNo.Visible = True
            txtStockCode.Text = lStockCode
            lblStockDesc.Text = lStockDesc
            txtUnitPrice.Text = lUnitprice
            lblUnitValue.Text = lUnit
            lblPartNo.Text = lPartNo

        End If

    End Sub

    Private Sub btnSearchAccCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccCode.Click
        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        Dim Account As New COALookup()
        Dim result As DialogResult = COALookup.ShowDialog()
        If COALookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lCOAID = COALookup.strAcctId
            lAccountCode = COALookup.strAcctcode
            lAccountDesc = COALookup.strAcctDescp
            lblAccCode.Text = lAccountCode
            lblAccountDesc.Text = lAccountDesc
        End If
        lblAccountDesc.Visible = True
    End Sub

    Private Sub MultiEntryvisible_True()
        lblStockDesc.Visible = True
        ' lblUnitPriceValue.Visible = True
        lblUnitValue.Visible = True
        lblAvailablevalue.Visible = True
        lblAccountDesc.Visible = True
        lblPartNo.Visible = True
    End Sub

    Private Sub txtStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave

        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL

        If txtStockCode.Text = String.Empty Then

            Me.lblUnitValue.Text = String.Empty
            Me.lblStockDesc.Text = String.Empty
            Me.txtUnitPrice.Text = String.Empty
            Me.lblAvailablevalue.Text = String.Empty
            lblPartNo.Text = String.Empty
            Exit Sub

        End If

        Dim dt As New DataTable
        Dim dtStock As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        objITNINPPT.StockID = Me.txtStockCode.Text

        dt = objITNINBOL.STITNInStockCodeGet(objITNINPPT)
        If dt.Rows.Count <> 0 Then
            Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString()
            lStockCode = dt.Rows(0).Item("StockCode").ToString()
            lStockID = dt.Rows(0).Item("StockID").ToString()
            Me.lblStockDesc.Text = dt.Rows(0).Item("StockDesc").ToString()
            lStockDesc = dt.Rows(0).Item("StockDesc")
            lStockID = dt.Rows(0).Item("StockID").ToString()
            Me.lblUnitValue.Text = dt.Rows(0).Item("UOM").ToString()
            lUnit = dt.Rows(0).Item("UOM").ToString()
            lblAvailablevalue.Text = CDbl(dt.Rows(0).Item("AvailableQty"))
            If Not dt.Rows(0).Item("UnitPrice") Is DBNull.Value Then
                txtUnitPrice.Text = CDbl(dt.Rows(0).Item("UnitPrice"))
            Else
                txtUnitPrice.Text = "0.00"
            End If
            lUnitprice = txtUnitPrice.Text

            lblPartNo.Text = dt.Rows(0).Item("PartNo")
            lblAccCode.Text = dt.Rows(0).Item("AccountCode").ToString()
            lblAccountDesc.Text = dt.Rows(0).Item("AccountDesc")
            lStockCOAID = dt.Rows(0).Item("StockCOAID")
            lVarianceCOAID = dt.Rows(0).Item("VarianceCOAID")
            lblAvailablevalue.Text = dt.Rows(0).Item("AvailableQty")
            lblAvailablevalue.Visible = True
            lblAccountDesc.Visible = True
            ' lblUnitPriceValue.Visible = True
            'objIPRPPT.stockID = dt.Rows(0).Item("StockID").ToString()
            Me.lblUnitValue.Visible = True
            Me.lblStockDesc.Visible = True
            lblPartNo.Visible = True

            ''
            'lStockCode = frmStockCodeLookup._lStockCode
            'lStockDesc = frmStockCodeLookup._lStockDesc
            'lUnitprice = frmStockCodeLookup._lStockUnitprice
            ''lUnit = frmStockCodeLookup._lUnit
            'lStockID = frmStockCodeLookup._lStockID
            'lPartNo = frmStockCodeLookup._lPartNo
            'lStockCOAID = frmStockCodeLookup._lCOAID
            'lVarianceCOAID = frmStockCodeLookup._lVarianceCOAID
            'lblAvailablevalue.Text = frmStockCodeLookup._lAvailableQty
            'lblAccCode.Text = frmStockCodeLookup._lAccountCode
            'lblAccountDesc.Text = frmStockCodeLookup._lAccountDesc
            ''

        Else

            DisplayInfoMessage("Msg01")
            'MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtStockCode.Text = String.Empty
            Me.lblUnitValue.Text = String.Empty
            Me.lblStockDesc.Text = String.Empty
            Me.txtUnitPrice.Text = String.Empty
            Me.lblAvailablevalue.Text = String.Empty
            lblPartNo.Text = String.Empty
            lStockID = String.Empty
            txtStockCode.Focus()

        End If
      
        'If objIPRPPT.stockID <> String.Empty Then
        '    dtStock = objIPRBOL.GetAvailableQTy(objIPRPPT)
        '    If dtStock.Rows.Count <> 0 Then
        '        Me.lblUnitPriceValue.Text = dtStock.Rows(0).Item("UnitPrice").ToString
        '        Me.lblAvailablevalue.Text = dtStock.Rows(0).Item("AvailableQty").ToString
        '        Me.lblUnitPriceValue.Visible = True
        '        lblAvailablevalue.Visible = True
        '    End If
        'End If

    End Sub

    Private Sub txtAccountCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub


    Private Sub txtAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        If lblAccCode.Text = String.Empty Then
            lblAccountDesc.Text = String.Empty
            'txtAccountCode.Focus()
            Exit Sub
        End If
        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        objITNINPPT.COACode = lblAccCode.Text.Trim
        dt = objITNINBOL.AcctlookupSearch(objITNINPPT)
        If dt.Rows.Count <> 0 Then
            lblAccountDesc.Text = dt.Rows(0).Item("COADescp").ToString()
            lblAccountDesc.Visible = True
        Else
            DisplayInfoMessage("Msg02")
            'MessageBox.Show("Invalid Account code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblAccCode.Text = String.Empty
            lblAccountDesc.Text = String.Empty
            '  txtAccountCode.Focus()
        End If

    End Sub

    Private Function IsGridValidAdd()
        If txtStockCode.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg03")
            'MessageBox.Show(" Please check StockCode", " StockCode Missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtStockCode.Focus()
            Return False
        End If
        If txtTransferQty.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg04")
            'MessageBox.Show(" Please enter Transfer Qty", " Transfer Qty not entered", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTransferQty.Focus()
            Return False
        ElseIf txtTransferQty.Text.Trim = 0 Then
            DisplayInfoMessage("Msg05")
            'MessageBox.Show(" Please enter Transfer Qty", " Transfer Qty quantity can not be zero ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTransferQty.Focus()
            Return False
        End If
        'If txtAccountCode.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please enter Account Code", " Account Code not entered", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtAccountCode.Focus()
        '    Return False
        'End If
        If txtUnitPrice.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg06")
            'MessageBox.Show(" Please enter Unit Price", " Unit Price Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUnitPrice.Focus()
            Return False
        End If
        If txtUnitPrice.Text.Trim <= 0 Then
            DisplayInfoMessage("Msg07")
            'MessageBox.Show("Unit Price should not be Zero ", " Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUnitPrice.Focus()
            Return False
        End If
        If txtSendersLocation.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg08")
            'MessageBox.Show(" Please enter SendersLocation", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSendersLocation.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function IsFormValid()
        If dtpITNDate.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg09")
            'MessageBox.Show(" Please check ITNDate", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If txtITNINNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg10")
            'MessageBox.Show(" Please enter ITN No.", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtITNINNo.Focus()
            Return False
        End If
        If txtSendersLocation.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg11")
            'MessageBox.Show(" Please enter SendersLocation", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSendersLocation.Focus()
            Return False
        End If
        If dgvITNIn.RowCount = 0 Then
            DisplayInfoMessage("Msg12")
            'MessageBox.Show("ITN-IN Details Required!!! ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtITNINNo.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function StockCodeExist(ByVal StockCode As String) As Boolean
        Dim objDataGridViewRow As New DataGridViewRow
        If AddFlag = True Then
            For Each objDataGridViewRow In dgvITNIn.Rows
                If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
                    txtStockCode.Text = ""
                    txtTransferQty.Text = ""
                    txtStockCode.Focus()
                    Return True
                End If
            Next
            Return False
        End If
    End Function

    Private Sub clearMultiEntry()
        txtStockCode.Text = String.Empty
        lblStockDesc.Text = String.Empty
        txtStockCode.ReadOnly = False
        btnSearchStockCode.Enabled = True
        lblPartNo.Text = String.Empty
        lblAvailablevalue.Text = String.Empty
        lblUnitValue.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        lblAccCode.Text = String.Empty
        '  txtAccountCode.ReadOnly = False
        btnSearchAccCode.Enabled = True
        lblAccountDesc.Text = String.Empty
        txtTransferQty.Text = String.Empty
        txtTransferQty.ReadOnly = False
        lStockID = String.Empty
        lCOAID = String.Empty
        lSTITNInDetID = String.Empty
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        AddFlag = True
    End Sub

    Private Sub clearSingleEntry()

        DeleteMultientry.Clear()

        txtITNINNo.Text = String.Empty
        txtITNINNo.ReadOnly = False
        txtSendersLocation.Text = String.Empty
        txtSendersLocation.ReadOnly = False
        btnSearchSendersLocation.Enabled = True
        txtRemarks.Text = String.Empty
        txtRemarks.ReadOnly = False
        txtRemarks.Enabled = True
        dtpITNDate.Enabled = True
        lSTITNIn = String.Empty
        lSenderLocationID = String.Empty
        lblStatusDesc.Text = "OPEN"
        btnSaveAll.Enabled = True
        gbsave.Enabled = True
        txtOperatorName.Clear()
        txtVehicleNo.Clear()
        txtMRCNo.Clear()
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If AddFlag = True Then
        '    Insert_MultiEntry()

        'Else
        '    Update_MultiEntry()
        'End If
    End Sub

    Private Sub Insert_MultiEntry()
        If Not IsGridValidAdd() Then Exit Sub
        Dim intRowcount As Integer = dtITNIn.Rows.Count
        Dim i As Integer = dgvITNIn.Rows.Count
        AddFlag = True
        If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 
            rowITNIn = dtITNIn.NewRow()
            If intRowcount = 0 And DTFlag = False Then
                columnITNIn = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("AvailableQty", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("Unit", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("UnitPrice", System.Type.[GetType]("System.Decimal"))
                dtITNIn.Columns.Add(columnITNIn)
                'columnITNIn = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                'dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("AccountCode", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("AccountDesc", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("TransferINQty", System.Type.[GetType]("System.Decimal"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("TransferINValue", System.Type.[GetType]("System.Decimal"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("StockID", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("STInternalTransferInDetailsID", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("StockCOAID", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                columnITNIn = New DataColumn("VarianceCOAID", System.Type.[GetType]("System.String"))
                dtITNIn.Columns.Add(columnITNIn)
                rowITNIn("StockCode") = txtStockCode.Text.ToString()
                rowITNIn("StockDesc") = lblStockDesc.Text.ToString()
                rowITNIn("PartNo") = lblPartNo.Text.ToString()
                rowITNIn("AvailableQty") = lblAvailablevalue.Text.ToString()
                rowITNIn("Unit") = lblUnitValue.Text.ToString()
                rowITNIn("UnitPrice") = txtUnitPrice.Text
                'rowITNIn("COAID") = lCOAID
                rowITNIn("AccountCode") = lblAccCode.Text.ToString()
                rowITNIn("AccountDesc") = lblAccountDesc.Text.ToString()
                rowITNIn("TransferINQty") = txtTransferQty.Text.ToString()
                If txtTransferQty.Text.Trim <> String.Empty And txtUnitPrice.Text.Trim <> String.Empty Then
                    rowITNIn("TransferINValue") = (CDbl(txtTransferQty.Text) * CDbl(txtUnitPrice.Text))
                End If

                rowITNIn("StockID") = lStockID
                rowITNIn("STInternalTransferInDetailsID") = lSTITNInDetID
                rowITNIn("StockCOAID") = lStockCOAID
                rowITNIn("VarianceCOAID") = lVarianceCOAID
                dtITNIn.Rows.InsertAt(rowITNIn, intRowcount)
                DTFlag = True
            Else
                rowITNIn("StockCode") = txtStockCode.Text.ToString()
                rowITNIn("StockDesc") = lblStockDesc.Text.ToString()
                rowITNIn("PartNo") = lblPartNo.Text.ToString()
                rowITNIn("AvailableQty") = lblAvailablevalue.Text.ToString()
                rowITNIn("Unit") = lblUnitValue.Text
                rowITNIn("UnitPrice") = txtUnitPrice.Text
                'rowITNIn("COAID") = lCOAID
                rowITNIn("AccountCode") = lblAccCode.Text
                rowITNIn("AccountDesc") = lblAccountDesc.Text
                If txtTransferQty.Text.Trim <> String.Empty Then
                    rowITNIn("TransferINQty") = CDbl(txtTransferQty.Text.Trim)
                End If
                If txtTransferQty.Text.Trim <> String.Empty And txtUnitPrice.Text.Trim <> String.Empty Then
                    rowITNIn("TransferINValue") = (CDbl(txtTransferQty.Text) * CDbl(txtUnitPrice.Text))
                End If

                rowITNIn("StockID") = lStockID ' Adding new Stock in Update mode so Stock ID will be null.
                rowITNIn("STInternalTransferInDetailsID") = lSTITNInDetID
                rowITNIn("StockCOAID") = lStockCOAID
                rowITNIn("VarianceCOAID") = lVarianceCOAID
                dtITNIn.Rows.InsertAt(rowITNIn, intRowcount)
            End If
            With dgvITNIn
                .AutoGenerateColumns = False
                .DataSource = dtITNIn
                clearMultiEntry()
            End With
            btnSaveAll.Focus()
        Else
            DisplayInfoMessage("Msg13")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Update_MultiEntry()
        Dim strStCode As String = txtStockCode.Text.ToString()
        For i As Integer = 0 To dgvITNIn.Rows.Count - 1
            If i <> dgvITNIn.CurrentRow.Index Then
                If strStCode = dgvITNIn.Rows(i).Cells("dgclStockCode").Value.ToString() Then
                    DisplayInfoMessage("Msg14")
                    'MessageBox.Show("Stock Code already exist in this ITN-IN Detail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clearMultiEntry()
                    txtStockCode.Focus()
                    Exit Sub
                End If
            Else
            End If
        Next
        If strStCode = dgvITNIn.CurrentRow.Cells("dgclStockCode").Value.ToString() Then
        End If

        Dim dgvrow As Integer
        If Not IsGridValidAdd() Then Exit Sub
        Dim Str As String = dgvITNIn.Columns.Item(1).Name
        If AddFlag = False And dgvITNIn.Rows.Count > 0 Then
            dgvrow = dgvITNIn.CurrentRow.Index
            dtITNIn.Rows.RemoveAt(dgvrow)
            rowITNIn = dtITNIn.NewRow()
            rowITNIn("StockCode") = txtStockCode.Text.ToString()
            rowITNIn("StockDesc") = lblStockDesc.Text.ToString()
            rowITNIn("PartNo") = lblPartNo.Text.ToString()
            rowITNIn("AvailableQty") = lblAvailablevalue.Text.ToString()
            rowITNIn("Unit") = lblUnitValue.Text
            rowITNIn("UnitPrice") = txtUnitPrice.Text
            'rowITNIn("COAID") = lCOAID
            rowITNIn("AccountCode") = lblAccCode.Text
            rowITNIn("AccountDesc") = lblAccountDesc.Text
            If txtTransferQty.Text.Trim <> String.Empty Then
                rowITNIn("TransferINQty") = CDbl(txtTransferQty.Text.Trim)
            End If
            If txtTransferQty.Text.Trim <> String.Empty And txtUnitPrice.Text.Trim <> String.Empty Then
                rowITNIn("TransferINValue") = (CDbl(txtTransferQty.Text) * CDbl(txtUnitPrice.Text))
            End If

            rowITNIn("StockID") = lStockID
            rowITNIn("STInternalTransferInDetailsID") = lSTITNInDetID
            rowITNIn("StockCOAID") = lStockCOAID
            rowITNIn("VarianceCOAID") = lVarianceCOAID
            dtITNIn.Rows.InsertAt(rowITNIn, dgvrow)
            dgvITNIn.DataSource = dtITNIn
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            clearMultiEntry()
            AddFlag = True
            btnSaveAll.Focus()
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

    'Private Sub dgvITNIn_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNIn.CellContentDoubleClick
    '    Edit_SingleEntry()
    '    MultiEntryvisible_True()
    'End Sub

    Private Sub dgvITNIn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNIn.CellDoubleClick


        'If dgvITNIn.SelectedRows(dgvITNIn.Rows(0).Index).Index >= 0 Then

        'End If
        
        Edit_SingleEntry()
        MultiEntryvisible_True()

    End Sub

    Private Sub Edit_SingleEntry()
        If dgvITNIn.Rows.Count > 0 Then
            txtStockCode.Text = dgvITNIn.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            lblStockDesc.Text = dgvITNIn.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
            lblPartNo.Text = dgvITNIn.SelectedRows(0).Cells("dgclPartNo").Value.ToString()
            lblAvailablevalue.Text = dgvITNIn.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
            lblUnitValue.Text = dgvITNIn.SelectedRows(0).Cells("dgclUnit").Value.ToString()
            txtUnitPrice.Text = dgvITNIn.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
            lStockCOAID = dgvITNIn.SelectedRows(0).Cells("dgclStockCOAID").Value.ToString()
            lblAccCode.Text = dgvITNIn.SelectedRows(0).Cells("dgclAccountCode").Value.ToString()
            lblAccountDesc.Text = dgvITNIn.SelectedRows(0).Cells("dgclAccountDesc").Value.ToString()
            txtTransferQty.Text = dgvITNIn.SelectedRows(0).Cells("dgclTransferInQty").Value.ToString()
            lStockID = dgvITNIn.SelectedRows(0).Cells("dgclStockID").Value.ToString()
            lSTITNInDetID = dgvITNIn.SelectedRows(0).Cells("dgclSTInternalTransferInDetailsID").Value.ToString()
            AddFlag = False
            'btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
        End If
    End Sub

    Private Sub dgvITNIn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvITNIn.KeyDown
        If e.KeyCode = Keys.Return Then
            Edit_SingleEntry()
            e.Handled = True
        End If
    End Sub

    Private Sub SaveAll()

        Dim rowsAffected As Integer = 0
        If Not IsFormValid() Then Exit Sub
        Dim ITNInNoCount As Integer
        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        With objITNINPPT
            .ITNDate = dtpITNDate.Value
            '            .ITNDate = Format(dtpITNDate.Value, "MM/dd/yyyy")
            .ItnInNo = txtITNINNo.Text
            .Status = "OPEN"
            .Remarks = txtRemarks.Text
            .RejectedReason = ""
            .SendersLocation = lSenderLocationID
            .STInternalTransferInID = lSTITNIn 'to differentiate for update
            .OperatorName = txtOperatorName.Text
            .TransportDate = dtpTransportDate.Value
            .VehicleNo = txtVehicleNo.Text
            .MRCNo = txtMRCNo.Text
        End With
        If lSTITNIn = "" Then
            dt = objITNINBOL.ITInNo_isExist(objITNINPPT) 'for Validation process DN No. and GRN No. is exists
            If dt.Rows.Count <> 0 Then
                ITNInNoCount = dt.Rows(0).Item("ITNInNoCount")
                If ITNInNoCount > 0 Then
                    DisplayInfoMessage("Msg15")
                    'MessageBox.Show("ITN IN No. already exist, Please check")
                    Exit Sub
                Else
                    dt = objITNINBOL.Save_STInternalTransferIn(objITNINPPT)
                    If dt.Rows.Count > 0 Then
                        lSTITNIn = dt.Rows(0).Item("STInternalTransferInID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
                    Else
                        DisplayInfoMessage("Msg16")
                        'MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        rowsAffected = objITNINBOL.Delete_STInternalTransferIn(objITNINPPT)
                        Exit Sub
                    End If
                End If
            End If
        Else
            DeleteMultiEntryRecords()
            rowsAffected = objITNINBOL.Update_STInternalTransferIn(objITNINPPT)
            If rowsAffected = 1 Then
            Else
                DisplayInfoMessage("Msg17")
                'MessageBox.Show("Failed to update Records", "Error occured in updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim DataGridViewRow As DataGridViewRow
        For Each DataGridViewRow In dgvITNIn.Rows

            With objITNINPPT

                .StockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
                .PartNo = DataGridViewRow.Cells("dgclPartNo").Value.ToString()
                .UnitPrice = CDbl(DataGridViewRow.Cells("dgclUnitPrice").Value.ToString())
                .AvailQty = DataGridViewRow.Cells("dgclAvailableQty").Value.ToString()
                .COAID = DataGridViewRow.Cells("dgclStockCOAID").Value.ToString()
                .TransferInQty = CDbl(DataGridViewRow.Cells("dgclTransferInQty").Value.ToString())
                .TransferInValue = CDbl(DataGridViewRow.Cells("dgclTransferInValue").Value.ToString())
                .STInternalTransferInDetailsID = DataGridViewRow.Cells("dgclSTInternalTransferInDetailsID").Value.ToString() 'gvlSTIPRDetID to differentiate for update
                .STInternalTransferInID = lSTITNIn
            End With
            If objITNINPPT.STInternalTransferInDetailsID = "" Then
                rowsAffected = objITNINBOL.Save_STITNInDetailsInsert(objITNINPPT)
            Else
                rowsAffected = objITNINBOL.Update_STITNInDetailsUpdate(objITNINPPT)
            End If
        Next
        If rowsAffected = 1 Then
            If objITNINPPT.STInternalTransferInDetailsID = "" Then
                DisplayInfoMessage("Msg18")
                'MessageBox.Show("Records inserted Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DisplayInfoMessage("Msg19")
                'MessageBox.Show("Records updated Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("Msg20")
            'MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rowsAffected = objITNINBOL.Delete_STInternalTransferIn(objITNINPPT)
            Exit Sub
        End If
        ClearGridView(dgvITNIn)
        'btnSaveAll.Text = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        clearSingleEntry()
        clearMultiEntry()
        'BindITNINViewgrid()

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub BindITNINViewgrid()
        dgvITNIn.DataSource = Nothing

        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        With objITNINPPT
            If chkITNDate.Checked = True Then
                .ITNDate = dtpviewITNDate.Value
                '.ITNDate = Format(dtpviewITNDate.Value, "MM/dd/yyyy")
            Else
                .ITNDate = Nothing
            End If
            .ItnInNo = txtviewITNInNo.Text.Trim
            .Status = cbStatus.SelectedItem
            .SendersLocation = txtviewSendLoc.Text.Trim
        End With
        dt = objITNINBOL.STInternalTransferInSelect(objITNINPPT)
        'If dt.Rows.Count > 0 Then
        dgvITNInView.AutoGenerateColumns = False
        dgvITNInView.DataSource = dt
        'Else
        'ClearGridView(dgvITNInView)
        'End If
        'txtviewITNInNo.Text = String.Empty
        'txtviewSendLoc.Text = String.Empty

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        BindITNINViewgrid()

    End Sub

    Private Sub dgvITNInView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNInView.CellDoubleClick

        EditViewGridRecord()
    End Sub

    Private Sub ITNInView_Edit()
        dgvITNIn.DataSource = Nothing
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        If dgvITNInView.Rows.Count > 0 Then
            txtITNINNo.Text = dgvITNInView.SelectedRows(0).Cells("dgclITNInNo").Value.ToString()
            lblStatusDesc.Text = dgvITNInView.SelectedRows(0).Cells("dgclStatus").Value.ToString()
            Dim str As String = dgvITNInView.SelectedRows(0).Cells("dgclITNDate").Value.ToString()
            dtpITNDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            txtRemarks.Text = dgvITNInView.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            lSTITNIn = dgvITNInView.SelectedRows(0).Cells("dgclSTITNInID").Value.ToString()
            lSenderLocationID = dgvITNInView.SelectedRows(0).Cells("dgclSupplierID").Value.ToString()
            txtSendersLocation.Text = dgvITNInView.SelectedRows(0).Cells("dgclSendersLocation").Value.ToString()
            If Not dgvITNInView.SelectedRows(0).Cells("dgclRejectedReason").Value Is DBNull.Value Then
                lblRejectreasondesc.Text = dgvITNInView.SelectedRows(0).Cells("dgclRejectedReason").Value.ToString()
                lblRejectReason.Visible = True
                lblcolon21.Visible = True
                lblRejectreasondesc.Visible = True
            Else
                lblRejectReason.Visible = False
                lblcolon21.Visible = False
                lblRejectreasondesc.Text = String.Empty
            End If
            DTFlag = True
            With objITNINPPT
                .STInternalTransferInID = lSTITNIn
            End With

            dtITNIn = objITNINBOL.ITNInDetails_Select(objITNINPPT)
            If dtITNIn.Rows.Count > 0 Then
                dgvITNIn.AutoGenerateColumns = False
                dgvITNIn.DataSource = dtITNIn
                gvSTITNInDetID = dtITNIn.Rows(0).Item("STInternalTransferInDetailsID").ToString()
                'lSTEstMillDelivID = dt.Rows(0).Item("STEstMillDeliveryID").ToString()
            Else
                DisplayInfoMessage("Msg21")
                'MessageBox.Show("No Records to Select", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            txtITNINNo.ReadOnly = True
            tcITNIN.SelectedTab = tbpgITNInAdd
        Else
            DisplayInfoMessage("Msg22")
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgvITNInView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvITNInView.KeyDown

        If e.KeyCode = Keys.Return Then
        EditViewGridRecord
            e.Handled = True
        End If

    End Sub

    Private Sub DelateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelateToolStripMenuItem.Click
        DeleteITNInView()
    End Sub


    Private Sub DeleteITNInView()
        Dim rowsAffected As Integer = 0
        cmsITNIn.Visible = False
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        Dim dt As New DataTable
        If dgvITNInView.Rows.Count > 0 Then
            If dgvITNInView.SelectedRows(0).Cells("dgclStatus").Value = "OPEN" Then
                If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    lSTITNInID = dgvITNInView.SelectedRows(0).Cells("dgclSTITNInID").Value.ToString()
                    With objITNINPPT
                        .STInternalTransferInID = lSTITNInID
                    End With
                    rowsAffected = objITNINBOL.Delete_STInternalTransferIn(objITNINPPT)
                    If rowsAffected > 0 Then
                        DisplayInfoMessage("Msg24")
                        'MessageBox.Show(" Records Deleted Successfully", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        BindITNINViewgrid()
                    Else
                        DisplayInfoMessage("Msg25")
                        'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                DisplayInfoMessage("Msg26")
                'MessageBox.Show("Not a valid record to delete, status must be OPEN ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("Msg27")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Dim rowsAffected As Integer = 0
        Dim dtStockDetail As New DataTable
        Dim LedgerID As String = String.Empty
        Dim dtAveragePrice As DataTable = Nothing

        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL

        ' step : 1 to update the status and rejected reason in STInternalTransferIn 

        If cbApprovalStatus.SelectedItem = String.Empty Then
            DisplayInfoMessage("Msg28")
            'MessageBox.Show("Please select status to Approve")
            Exit Sub
        Else
            If cbApprovalStatus.SelectedItem = "REJECTED" And txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg29")
                'MessageBox.Show("Please enter valid Rejected reason")
                Exit Sub
            Else

                With objITNINPPT
                    .STInternalTransferInID = lSTITNInID
                    .Status = cbApprovalStatus.SelectedItem.ToString()
                    .RejectedReason = txtRejectedReason.Text.Trim()
                End With
                rowsAffected = objITNINBOL.Update_STInternalTransferInApproval(objITNINPPT)
                If rowsAffected > 0 Then
                Else
                    DisplayInfoMessage("Msg30")
                    'MessageBox.Show("Confirmation Failed in Status update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If

        ' step : 2 to find Average Price & insert in Accouns.LedgerALL table & to Insert journal Detail

        'Dim dtSupplierCOAID As New DataTable 'to Get SupplierCOAID
        'objITNINPPT.SendersLocation = txtSendersLocation.Text
        'dtSupplierCOAID = objITNINBOL.STITNInSendLocGet(objITNINPPT)
        Dim dtLedgerModule As New DataTable

        'to insert in Accouns.LedgerALL table

        With objITNINPPT
            If txtRemarks.Text <> String.Empty Then
                .Remarks = txtITNINNo.Text.Trim & "-" & txtRemarks.Text.Trim
            Else
                .Remarks = txtITNINNo.Text.Trim
            End If
            .ITNDate = dtpITNDate.Value
            .TransferInValue = Nothing 'Passing Batch Amount Value to LedgerAllModule as NULL
        End With
        dtLedgerModule = objITNINBOL.Save_LedgerAllModule(objITNINPPT)
        If dtLedgerModule.Rows.Count > 0 Then
            LedgerID = dtLedgerModule.Rows(0).Item("LedgerID").ToString() 'LedgerAllModule Function returns LedgerID 
            objITNINPPT.LedgerID = LedgerID
        Else
            DisplayInfoMessage("Msg31")
            'MessageBox.Show("Error in Inserting Ledger All Module", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim strArray As String()
        Dim strLoginMonthName As String
        strArray = GlobalPPT.strLoginMonth.Split("-")
        strLoginMonthName = strArray(1)


        For Each DataGridViewRow In dgvITNIn.Rows
            If DataGridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                ' to find Average Price and update in Store.StockDetail Table
                With objITNINPPT
                    .STInternalTransferInID = lSTITNInID
                    .StockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
                    .TransferInQty = CDbl(DataGridViewRow.Cells("dgclTransferInQty").Value.ToString())
                    .TransferInValue = CDbl(DataGridViewRow.Cells("dgclTransferInValue").Value.ToString())

                    dtAveragePrice = objITNINBOL.ITNIn_Averageprice(objITNINPPT)
                    objITNINPPT.TransferInValue = Nothing
                    If dtAveragePrice.Rows.Count > 0 Then 'For Jounal Insert Process
                        AppSTDPrice = dtAveragePrice.Rows(0).Item("STDPrice").ToString()
                        AppStockCOAID = dtAveragePrice.Rows(0).Item("StockCOAID").ToString()
                        AppVarianceCOAID = dtAveragePrice.Rows(0).Item("VarianceCOAID").ToString()
                    End If

                    'to Insert in journal Detail
                    'For SenderPrice
                    .DC = "D"
                    .COAID = dtAveragePrice.Rows(0).Item("StockCOAID").ToString() 'StockCOAID for Debit 
                    .value = CDbl(DataGridViewRow.Cells("dgclTransferInValue").Value.ToString())

                    '.T0 = String.Empty
                    '.T1 = String.Empty
                    '.T2 = String.Empty
                    '.T3 = String.Empty
                    '.T4 = String.Empty

                    If dtAveragePrice.Rows(0).Item("T0").ToString() <> String.Empty Then
                        .T0 = dtAveragePrice.Rows(0).Item("T0").ToString()
                    Else
                        .T0 = String.Empty
                    End If
                    If dtAveragePrice.Rows(0).Item("T1").ToString() <> String.Empty Then
                        .T1 = dtAveragePrice.Rows(0).Item("T1").ToString()
                    Else
                        .T1 = String.Empty
                    End If

                    If dtAveragePrice.Rows(0).Item("T2").ToString() <> String.Empty Then
                        .T2 = dtAveragePrice.Rows(0).Item("T2").ToString()
                    Else
                        .T2 = String.Empty
                    End If

                    If dtAveragePrice.Rows(0).Item("T3").ToString() <> String.Empty Then
                        .T3 = dtAveragePrice.Rows(0).Item("T3").ToString()
                    Else
                        .T3 = String.Empty
                    End If

                    If dtAveragePrice.Rows(0).Item("T4").ToString() <> String.Empty Then
                        .T4 = dtAveragePrice.Rows(0).Item("T4").ToString()
                    Else
                        .T4 = String.Empty
                    End If

                    .StationID = String.Empty

                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString() 'Stock Name of corresponding stockid
                    .JournalDetDescp = txtITNINNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-IN No.> -<” StockCode--Stock Description” as selected in the TransferNote-IN>
                    .Flag = "ITNINPRICE"
                    rowsAffected = objITNINBOL.AC_JournalDetailInsert(objITNINPPT)

                    .DC = "C"
                    .COAID = lSupplierCOAID  'Supplier COAID  - this is from General.GeneralDistributionsetup Table
                    .value = CDbl(DataGridViewRow.Cells("dgclTransferInValue").Value.ToString())
                    .T0 = lT0
                    .T1 = lT1
                    .T2 = lT2
                    .T3 = lT3
                    .T4 = lT4
                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                    .JournalDetDescp = txtITNINNo.Text.Trim + "-" + txtSendersLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' <ITN-IN No.> -<Senders Location Name> <loginMonth&Year>
                    .Flag = "ITNINPRICE"
                    rowsAffected = objITNINBOL.AC_JournalDetailInsert(objITNINPPT)

                    ''For STDPrice
                    'AppSTDPriceValue = (DataGridViewRow.Cells("dgclTransferInQty").Value * AppSTDPrice)
                    'If AppSTDPriceValue <> 0 And AppStockCOAID <> String.Empty Then

                    '    .DC = "D"
                    '    .COAID = dtAveragePrice.Rows(0).Item("StockCOAID").ToString()  'StockCOAID for debit
                    '    .value = AppSTDPriceValue ' Qty * STDPrice
                    '    .T0 = String.Empty
                    '    .StationID = String.Empty
                    '    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString() 'Stock Name of corresponding stockid
                    '    .JournalDetDescp = txtITNINNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-IN No.> -<” StockCode--Stock Description” as selected in the TransferNote-IN>
                    '    .Flag = "ITNINSTDPRICE"
                    '    rowsAffected = objITNINBOL.AC_JournalDetailInsert(objITNINPPT)

                    '    .DC = "C"
                    '    .COAID = dtSupplierCOAID.Rows(0).Item("SupplierCOAID").ToString()  'Supplier COAID for credit - this is from General.GeneralDistributionsetup Table
                    '    .value = AppSTDPriceValue ' Qty * STDPrice
                    '    .T0 = String.Empty
                    '    .StationID = String.Empty
                    '    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString() 'Stock Name of corresponding stockid
                    '    .JournalDetDescp = txtITNINNo.Text.Trim + "-" + txtSendersLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' <ITN-IN No.> -<Senders Location Name> <loginMonth&Year>
                    '    .Flag = "ITNINSTDPRICE"
                    '    rowsAffected = objITNINBOL.AC_JournalDetailInsert(objITNINPPT)
                    'End If

                    ''For VariancePrice

                    'AppVariancePrice = Abs(CDbl(DataGridViewRow.Cells("dgclTransferInValue").Value.ToString()) - AppSTDPriceValue)
                    'If AppSTDPriceValue <> 0 And AppVariancePrice <> 0 And AppVarianceCOAID <> String.Empty Then

                    '    .DC = "D"
                    '    .COAID = dtAveragePrice.Rows(0).Item("VarianceCOAID").ToString()  'Variance COAID  - this is from Store.STCategory Table
                    '    .value = AppVariancePrice
                    '    .T0 = String.Empty
                    '    .StationID = String.Empty
                    '    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                    '    .JournalDetDescp = txtITNINNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-IN No.> -<” StockCode--Stock Description” as selected in the TransferNote-IN>
                    '    .Flag = "ITNINVARIANCEPRICE"
                    '    rowsAffected = objITNINBOL.AC_JournalDetailInsert(objITNINPPT)

                    '    .DC = "C"
                    '    .COAID = dtAveragePrice.Rows(0).Item("StockCOAID").ToString()
                    '    .value = AppVariancePrice
                    '    .T0 = String.Empty
                    '    .StationID = String.Empty
                    '    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                    '    .JournalDetDescp = txtITNINNo.Text.Trim + "-" + txtSendersLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' <ITN-IN No.> -<Senders Location Name> <loginMonth&Year>
                    '    .Flag = "ITNINVARIANCEPRICE"
                    '    rowsAffected = objITNINBOL.AC_JournalDetailInsert(objITNINPPT)

                    'End If
                End With
            End If
        Next
        rowsAffected = objITNINBOL.Update_LedgerAllModule(objITNINPPT)
        If rowsAffected > 0 Then

            'Call TaskMonitor Update after successful approval -Start

            Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
            Dim dsTaskMonitorUPDATE As New DataSet
            objStoreMonthEndClosingPPT.ModID = 2
            objStoreMonthEndClosingPPT.Task = "Internal Transfer Note IN approval"
            objStoreMonthEndClosingPPT.Complete = "Y"
            dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)

            'Call TaskMonitor Update after successful approval -End

        Else
            DisplayInfoMessage("Msg32")
            'MessageBox.Show("Error in Journal Debit Insert", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        MessageBox.Show("Confirmation Success", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        GlobalPPT.IsButtonClose = True
        Me.Close()

    End Sub

    Private Sub dgvITNInView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvITNInView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgvITNInView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgvITNInView.ClearSelection()
                    dgvITNInView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        EditViewGridRecord()

    End Sub

    Private Sub EditViewGridRecord()

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
            If EditUpdateToolStripMenuItem.Enabled = True Then
                If dgvITNInView.RowCount > 0 Then
                    If dgvITNInView.CurrentRow.Cells("dgclStatus").Value <> "OPEN" And dgvITNInView.CurrentRow.Cells("dgclStatus").Value <> "REJECTED" Then
                        ITNInView_Edit()
                        Disable_basedOnstatus()
                    Else 'If dgvITNInView.RowCount > 0 And dgvITNInView.CurrentRow.Cells("dgclStatus").Value <> "OPEN" And dgvITNInView.CurrentRow.Cells("dgclStatus").Value <> "REJECTED" Then
                        ITNInView_Edit()
                        Enable_basedOnstatus()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        clearSingleEntry()
        clearMultiEntry()
        ClearGridView(dgvITNIn)
        tcITNIN.SelectedTab = tbpgITNInAdd
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
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearMultiEntry()
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ResetAll()
    End Sub

    Private Sub ResetAll()
        'Dim dt As New DataTable
        clearSingleEntry()
        clearMultiEntry()
        ClearGridView(dgvITNIn)
        'dgvITNIn.DataSource = dt
        'btnSaveAll.Text = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        AddFlag = True

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub txtTransferQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransferQty.KeyDown

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

        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{Tab}")
        End If

    End Sub

    Private Sub txtTransferQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransferQty.KeyPress

        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub btnviewSendLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewSendLoc.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lSenderLocation = SenderReceiverLocLookup._lSenderLocation
            txtviewSendLoc.Text = lSenderLocation
        End If
    End Sub

    Private Sub txtSendersLocation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSendersLocation.Leave
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        Dim dt As New DataTable
        If txtSendersLocation.Text <> String.Empty Then
            objITNINPPT.SendersLocation = txtSendersLocation.Text
            dt = objITNINBOL.STITNInSendLocGet(objITNINPPT)
            If dt.Rows.Count <> 0 Then

                If Not dt.Rows(0).Item("DistributionDescp") Is DBNull.Value Then
                    Me.txtSendersLocation.Text = dt.Rows(0).Item("DistributionDescp").ToString()
                Else
                    Me.txtSendersLocation.Text = String.Empty
                End If

                lSenderLocationID = dt.Rows(0).Item("DistributionSetupID").ToString()

                If Not dt.Rows(0).Item("T0") Is DBNull.Value Then
                    lT0 = dt.Rows(0).Item("T0")
                Else
                    lT0 = String.Empty
                End If
                If Not dt.Rows(0).Item("T1") Is DBNull.Value Then
                    lT1 = dt.Rows(0).Item("T1")
                Else
                    lT1 = String.Empty
                End If
                If Not dt.Rows(0).Item("T2") Is DBNull.Value Then
                    lT2 = dt.Rows(0).Item("T2")
                Else
                    lT2 = String.Empty
                End If
                If Not dt.Rows(0).Item("T3") Is DBNull.Value Then
                    lT3 = dt.Rows(0).Item("T3")
                Else
                    lT3 = String.Empty
                End If
                If Not dt.Rows(0).Item("T4") Is DBNull.Value Then
                    lT4 = dt.Rows(0).Item("T4")
                Else
                    lT4 = String.Empty
                End If

                
            Else
                DisplayInfoMessage("Msg33")
                'MessageBox.Show("Invalid Location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSendersLocation.Text = String.Empty
                txtSendersLocation.Focus()
            End If
        End If

    End Sub
    Private Sub ResetAllOnTabClick()
        clearSingleEntry()
        clearMultiEntry()
        ClearGridView(dgvITNIn)
        dtITNIn.Rows.Clear()
        dtpITNDate.Focus()
        'btnSaveAll.Text = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        AddFlag = True
        Enable_basedOnstatus()
        lblStatusDesc.Text = "OPEN"
        txtITNINNo.ReadOnly = False
    End Sub
    Private Sub tcITNIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcITNIN.Click

        If tcITNIN.SelectedTab Is tbpgITNInAdd = True Then
            If tcITNIN.TabPages.Count = 2 Then '--if transaction screen--'

                If btnSaveAll.Enabled = True Then
                    If dgvITNIn.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

        ElseIf tcITNIN.SelectedTab Is tbpgView = True Then

            If (dgvITNIn.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And btnSaveAll.Enabled = True) Then

                chkITNDate.Focus()
                If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ClearGridView(dgvITNIn)
                    GlobalPPT.IsRetainFocus = False
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    txtviewITNInNo.Text = String.Empty
                    txtviewSendLoc.Text = String.Empty
                    chkITNDate.Checked = False
                    cbStatus.SelectedItem = "OPEN"
                    BindITNINViewgrid()
                Else
                    tcITNIN.SelectedTab = tbpgITNInAdd
                End If

            Else

                txtviewITNInNo.Text = String.Empty
                txtviewSendLoc.Text = String.Empty
                chkITNDate.Checked = False
                cbStatus.SelectedItem = "OPEN"
                BindITNINViewgrid()

            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DelateToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
      

    End Sub

    Private Sub Disable_basedOnstatus()
        'lblRejectedReason.Visible = False
        'txtRejectedReason.Visible = False
        'lblColon15.Visible = False
        lblStockDesc.Text = String.Empty
        lblUnitValue.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        lblUnitValue.Text = String.Empty
        lblAvailablevalue.Text = String.Empty
        btnSaveAll.Enabled = False
        ' btnResetAll.Enabled = False
        ' btnSearchStockCode.Enabled = False
        lblAccountDesc.Text = String.Empty
        lblPartNo.Text = String.Empty
        txtITNINNo.ReadOnly = True
        txtSendersLocation.ReadOnly = True
        dtpITNDate.Enabled = False
        'dgvITNIn.Enabled = False
        txtStockCode.ReadOnly = True
        'txtAccountCode.ReadOnly = True
        txtTransferQty.ReadOnly = True
        btnSearchAccCode.Enabled = False
        btnSearchStockCode.Enabled = False
        btnSearchSendersLocation.Enabled = False
        BtnVehicle.Enabled = False
        txtRemarks.Enabled = False
        gbsave.Enabled = False
    End Sub

    Private Sub Enable_basedOnstatus()
        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        'txtITNINNo.ReadOnly = False
        txtSendersLocation.ReadOnly = False
        dtpITNDate.Enabled = True
        txtStockCode.ReadOnly = False
        'txtAccountCode.ReadOnly = False
        txtTransferQty.ReadOnly = False
        btnSearchAccCode.Enabled = True
        btnSearchStockCode.Enabled = True
        btnSearchSendersLocation.Enabled = True
        gbsave.Enabled = True
        txtRemarks.Enabled = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If AddFlag = True Then
            Insert_MultiEntry()

        Else
            Update_MultiEntry()
        End If

        'GlobalPPT.IsRetainFocus = True

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteINFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

        If mdiparent.strMenuID = "M8" Then
            tcITNIN.TabPages("tbpgITNInAdd").Text = rm.GetString("tcIPR.TabPages(tbpgITNInAdd).Text")
            tcITNIN.TabPages("tbpgView").Text = rm.GetString("tcIPR.TabPages(tbpgView).Text")
        Else
            tcITNIN.TabPages("tbpgITNInAdd").Text = rm.GetString("tcIPR.TabPages(tbpgITNInAdd).Text")
            gbITNInApproval.Text = rm.GetString("gbITNInApproval.Text")
            btnConfirm.Text = rm.GetString("btnConfirm.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
        End If

        lblITNINDate.Text = rm.GetString("lblITNINDate.Text")
        lblITNInNo.Text = rm.GetString("lblITNInNo.Text")
        lblSendersLocation.Text = rm.GetString("lblSendersLocation.Text")
        lblRemarks.Text = rm.GetString("lblRemarks.Text")
        lblStatus.Text = rm.GetString("lblStatus.Text")
        lblStockCode.Text = rm.GetString("lblStockCode.Text")
        lblUnitPrice.Text = rm.GetString("lblUnitPrice.Text")
        lblUnit.Text = rm.GetString("lblUnit.Text")
        lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
        lblTransferInQty.Text = rm.GetString("lblTransferInQty.Text")
        lblStockDes.Text = rm.GetString("lblStockDes.Text")
        lblPart.Text = rm.GetString("lblPart.Text")
        lblAvailableQty.Text = rm.GetString("lblAvailableQty.Text")
        lblAccDes.Text = rm.GetString("lblAccDes.Text")
        btnAdd.Text = rm.GetString("btnAdd.Text")
        btnReset.Text = rm.GetString("btnReset.Text")
        btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
        btnResetAll.Text = rm.GetString("btnResetAll.Text")
        btnClose.Text = rm.GetString("btnClose.Text")
        gbsingleEntry.Text = rm.GetString("gbsingleEntry.Text")
        gbMultiEntry.Text = rm.GetString("gbMultiEntry.Text")
        gbITNINDetail.Text = rm.GetString("gbITNINDetail.Text")


        dgvITNIn.Columns("dgclStockCode").HeaderText = rm.GetString("dgvITNIn.Columns(dgclStockCode).HeaderText")
        dgvITNIn.Columns("dgclStockDesc").HeaderText = rm.GetString("dgvITNIn.Columns(dgclStockDesc).HeaderText")
        dgvITNIn.Columns("dgclPartNo").HeaderText = rm.GetString("dgvITNIn.Columns(dgclPartNo).HeaderText")
        dgvITNIn.Columns("dgclAccountCode").HeaderText = rm.GetString("dgvITNIn.Columns(dgclAccountCode).HeaderText")
        dgvITNIn.Columns("dgclAccountDesc").HeaderText = rm.GetString("dgvITNIn.Columns(dgclAccountDesc).HeaderText")
        dgvITNIn.Columns("dgclAvailableQty").HeaderText = rm.GetString("dgvITNIn.Columns(dgclAvailableQty).HeaderText")
        dgvITNIn.Columns("dgclUnitPrice").HeaderText = rm.GetString("dgvITNIn.Columns(dgclUnitPrice).HeaderText")
        dgvITNIn.Columns("dgclUnit").HeaderText = rm.GetString("dgvITNIn.Columns(dgclUnit).HeaderText")
        dgvITNIn.Columns("dgclTransferInQty").HeaderText = rm.GetString("dgvITNIn.Columns(dgclTransferInQty).HeaderText")
        dgvITNIn.Columns("dgclTransferInValue").HeaderText = rm.GetString("dgvITNIn.Columns(dgclTransferInValue).HeaderText")

        lblviewITNDate.Text = rm.GetString("lblviewITNDate.Text")
        lblviewITNIntNo.Text = rm.GetString("lblviewITNIntNo.Text")
        lblviewSendersLoc.Text = rm.GetString("lblviewSendersLoc.Text")
        lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
        plITNInSearch.Text = rm.GetString("plITNInSearch.Text")
        lblsearchBy.Text = rm.GetString("lblsearchBy.Text")

        dgvITNInView.Columns("dgclITNDate").HeaderText = rm.GetString("dgvITNInView.Columns(dgclITNDate).HeaderText")
        dgvITNInView.Columns("dgclITNInNo").HeaderText = rm.GetString("dgvITNInView.Columns(dgclITNInNo).HeaderText")
        dgvITNInView.Columns("dgclSendersLocation").HeaderText = rm.GetString("dgvITNInView.Columns(dgclSendersLocation).HeaderText")
        dgvITNInView.Columns("dgclStatus").HeaderText = rm.GetString("dgvITNInView.Columns(dgclStatus).HeaderText")
       


        'display a message if the culture is not supported
        'try passing bn (Bengali) for testing
        'MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ObjRecordExist As New Object
        Dim ObjITNIn As New InternalTransferNoteINPPT
        Dim ObjITNBOL As New InternalTransferNoteINBOL
        ObjRecordExist = ObjITNBOL.ITNInRecordIsExisT(ObjITNIn)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg34")
            'MsgBox("No Records Available!")
            Me.Cursor = Cursors.Arrow
        Else
            StrFrmName = "ITNIn"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    'Private Sub dgvITNIn_RowDividerDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowDividerDoubleClickEventArgs) Handles dgvITNIn.RowDividerDoubleClick
    '    btnAddGridHeaderClick = True
    '    MessageBox.Show("Select the row to update the data: divider")
    'End Sub

    'Private Sub dgvITNIn_ColumnHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvITNIn.ColumnHeaderMouseDoubleClick
    '    btnAddGridHeaderClick = True
    '    MessageBox.Show("Select the row to update the data: header")
    'End Sub

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
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{Tab}")
        End If

    End Sub

    Private Sub txtUnitPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitPrice.KeyPress

        'If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
        '    e.Handled = True
        '    MsgBox("Please enter Adjustment Value ")
        'End If
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

        'If Char.IsDigit(e.KeyChar) Then Exit Sub
        'If Char.IsControl(e.KeyChar) Then Exit Sub

        'If e.KeyChar = "." Then
        '    Dim txt As TextBox = CType(sender, TextBox)
        '    If txt.Text.IndexOf(".") < 0 Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'Else
        '    e.Handled = True
        'End If

    End Sub

    Private Sub DeleteToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem3.Click

        If dgvITNIn.RowCount = 0 Then
            Exit Sub
        ElseIf dgvITNIn.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else

            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                DeleteMultientrydatagrid()
            Else
                Exit Sub
            End If

        End If


    End Sub

    Private Sub DeleteMultientrydatagrid()



        lsSTInternalTransferInDetailsID = dgvITNIn.SelectedRows(0).Cells("dgclSTInternalTransferInDetailsID").Value.ToString

        lDelete = 0
        If lsSTInternalTransferInDetailsID <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lsSTInternalTransferInDetailsID)


        End If
        Dim Dr As DataRow
        Dr = dtITNIn.Rows.Item(dgvITNIn.CurrentRow.Index)
        Dr.Delete()
        dtITNIn.AcceptChanges()
        lsSTInternalTransferInDetailsID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objITNINPPT As New InternalTransferNoteINPPT

        lDelete = DeleteMultientry.Count
        'objSIVPPT.STIssueID = psSIVSTIssueId
        While (lDelete > 0)

            With objITNINPPT

                .STInternalTransferInDetailsID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntIPRDetailDelete As New Integer
            IntIPRDetailDelete = InternalTransferNoteINBOL.STInternalTransferInDetailsDelete(objITNINPPT)

            lDelete = lDelete - 1

        End While


    End Sub


    Private Sub InternalTransferNoteINFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'If dgvITNIn.RowCount > 0 Then

        '    If MsgBox(rm.GetString("Msg36"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

        '    End If

        'End If


    End Sub

    Private Sub gbsingleEntry_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbsingleEntry.Enter

    End Sub

    'Private Sub txtTransferQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransferQty.TextChanged

    '    If Val(txtTransferQty.Text) <= 0 Then
    '        txtTransferQty.Text = 0
    '    End If

    'End Sub


    Private Sub txtTransferQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferQty.TextChanged

        'comment as INTOUT - fix (txtUnitPrice_KeyDown)

        'If Val(txtTransferQty.Text) >= 0 Then
        '    txtTransferQty.Text = Format(Val(txtTransferQty.Text), "")
        'End If

        '   If Val(txtTransferQty.Text) > 0 Then
        '      txtTransferQty.Text = Val(txtTransferQty.Text), 
        '      End If

    End Sub

    Private Sub lblAvailablevalue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAvailablevalue.TextChanged
        If lblAvailablevalue.Text <> String.Empty Then
            lblAvailablevalue.Text = Format(Val(lblAvailablevalue.Text), "0")
        End If
    End Sub

    Private Sub EditToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem2.Click

        Edit_SingleEntry()
        MultiEntryvisible_True()
    End Sub

    Private Sub chkITNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkITNDate.CheckedChanged


        If chkITNDate.Checked = True Then
            dtpviewITNDate.Enabled = True
        Else
            dtpviewITNDate.Enabled = False
        End If

    End Sub

    Private Sub InternalTransferNoteINFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (dgvITNIn.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M8"
                'mdiparent.lblMenuName.Text = "IPR"
            End If

        End If

    End Sub

    Private Sub btnConfirm_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.ClientSizeChanged

    End Sub

    Private Sub txtUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrice.TextChanged

    End Sub

    Private Sub BtnVehicle_Click(sender As System.Object, e As System.EventArgs) Handles BtnVehicle.Click
        Dim objIPRNo As New VHNoLookup()
        Dim result As DialogResult = objIPRNo.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            txtVehicleNo.Text = objIPRNo.psVHWSCode
        End If
    End Sub
End Class