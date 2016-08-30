Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
Imports Common_BOL
Imports System.Math

Public Class InternalTransferNoteOUTFrm

    Private lStockCode As String = String.Empty
    Private lStockDesc As String = String.Empty
    Private lUnitprice As String = String.Empty
    Private lUnit As String = String.Empty
    Private lStockID As String = String.Empty
    Private lCOAID As String = String.Empty
    Private lAccountCode As String = String.Empty
    Private lAccountDesc As String = String.Empty
    Private lReceivedLocation As String = String.Empty
    Private lReceivedLocationID As String = String.Empty
    Private lPartNo As String = String.Empty
    Private lSTITNIn As String = String.Empty
    Private lSTITNOutID As String = String.Empty
    Private lSTITNOutDetID As String = String.Empty
    Private gvSTITNIn As String = String.Empty
    Private gvSTITNOutDetID As String = String.Empty
    Private lModifiedOn As String = String.Empty
    Private strMenuID As String = String.Empty
    Private lStockCOAID As String = String.Empty
    Private lVarianceCOAID As String = String.Empty

    'For Approval Part 
    Private AppSTDPrice As Double = 0.0
    Private AppStockCOAID As String = String.Empty
    Private AppValue As Double = 0.0
    Private AppSTDPriceValue As Double = 0.0
    Private AppVariancePrice As Double = 0.0
    Private AppVarianceCOAID As String = String.Empty
    Private intTransferOutValue As Integer = 0.0

    Private DTFlag As Boolean = False
    Private AddFlag As Boolean = True

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim oneDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim dtITNOut As New DataTable("dgvITNOut")
    Dim columnITNOut As DataColumn
    Dim rowITNOut As DataRow
    Shadows mdiparent As New MDIParent
    Public Shared StrFrmName As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteOUTFrm))

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Public lsSTInternalTransferOutDetailsID As String = String.Empty

    Private lT0 As String = String.Empty
    Private lT1 As String = String.Empty
    Private lT2 As String = String.Empty
    Private lT3 As String = String.Empty
    Private lT4 As String = String.Empty

    Private lSenderLocationID As String = String.Empty
    Private lSupplierCOAID As String = String.Empty
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteOUTFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub InternalTransferNoteOUTFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub InternalTransferNoteOUTFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M9" Then 'Internal Transfer Out load() event               -- Raja on 24th sep 2009
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
            tcITNOut.SelectedTab = tbpgITNOutView
            btnSearchAccCode.Visible = False
            'BindITNINViewgrid()
            GetITNOUTNo()
            BindITNOutview()
            SetUICulture(GlobalPPT.strLang)
            If lblStatusDesc.Text = "REJECTED" Then
                lblRejectReason.Visible = True
                lblcolon21.Visible = True
                lblRejectreasondesc.Visible = True
            End If
        ElseIf strMenuID = "M120" Then       'Internal Transfer Out Approval part             -- Raja on 2nd oct 2009
            toloadITNOut_inApproval()
            Me.dtpITNDate.Format = DateTimePickerFormat.Custom
            Me.dtpITNDate.CustomFormat = "dd/MM/yyyy"
            'Me.dtpviewIPRDate.Format = DateTimePickerFormat.Custom
            'Me.dtpviewIPRDate.CustomFormat = "dd/MM/yyyy"
            gbITNOutApproval.Visible = True
            gbsave.Visible = False
            lblRejectedReason.Visible = False
            txtRejectedReason.Visible = False
            lblColon15.Visible = False
            Me.lblStockDesc.Visible = False
            Me.lblUnitValue.Visible = False
            'Me.lblUnitPriceValue.Visible = False
            Me.lblUnitValue.Visible = False
            lblAvailablevalue.Visible = False
            btnSaveAll.Enabled = False
            btnResetAll.Enabled = False
            ' btnSearchStockCode.Enabled = False
            lblAccountDesc.Visible = False
            lblPartNo.Visible = False
            txtITNOUTNo.ReadOnly = True
            txtReceivedLocation.ReadOnly = True
            dtpITNDate.Enabled = False
            'dgvITNOut.Enabled = False
            txtRemarks.ReadOnly = True
            txtUnitPrice.ReadOnly = True
            txtStockCode.ReadOnly = True
            'txtAccountCode.ReadOnly = True
            txtTransferoutQty.ReadOnly = True
            btnSearchAccCode.Enabled = False
            btnSearchStockCode.Enabled = False
            btnSearchReceivedLocation.Enabled = False
            Button1.Enabled = False
            txtStockCode.Text = String.Empty
            lblAccCode.Text = String.Empty
            txtTransferoutQty.Text = String.Empty
            txtUnitPrice.Text = String.Empty
            cbApprovalStatus.SelectedIndex = 0
            SetUICulture(GlobalPPT.strLang)
            txtRejectedReason.Text = String.Empty
        End If
    End Sub

    Private Sub toloadITNOut_inApproval()
        Dim MdiParent As New MDIParent

        If MdiParent.strMenuID = "M120" Then
            tcITNOut.SelectedTab = tbpgITNOutAdd
            tcITNOut.TabPages.Remove(tbpgITNOutView)

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

    Public Sub BindITNOutMast_inApproval(ByVal strSTITNOutID As String, ByVal strITNOutNo As String, ByVal strITNOutDate As Date, ByVal strReceivedLocation As String, ByVal strStatus As String, ByVal strRemarks As String, ByVal strT0 As String, ByVal strT1 As String, ByVal strT2 As String, ByVal strT3 As String, ByVal strT4 As String, ByVal strReceivedLocationID As String, ByVal strSupplierCOAID As String, strOperatorName As String, strTransportDate As DateTime, strVehicleNo As String, strMRCNo As String)

        lSTITNOutID = strSTITNOutID
        txtITNOUTNo.Text = strITNOutNo
        dtpITNDate.Value = strITNOutDate
        dtpITNDate.Format = DateTimePickerFormat.Custom
        dtpITNDate.CustomFormat = "dd/MM/yyyy"
        lblStatusDesc.Text = strStatus
        txtReceivedLocation.Text = strReceivedLocation
        '
        lSenderLocationID = strReceivedLocationID
        lT0 = strT0
        lT1 = strT1
        lT2 = strT2
        lT3 = strT3
        lT4 = strT4
        lSupplierCOAID = strSupplierCOAID
        '
        'lModifiedOn = strModifiedOn
        txtITNOUTNo.ReadOnly = True
        txtRemarks.Text = strRemarks
        txtOperatorName.Text = strOperatorName
        dtpTransportDate.Value = strTransportDate
        txtVehicleNo.Text = strVehicleNo
        txtMRCNo.Text = strMRCNo
    End Sub

    Public Sub BindITNOutDet_inApproval(ByVal strSTITNOutID As String)
        Dim objITNOutPPT As New InternalTransferNoteOUTPPT
        Dim objITNOutBOL As New InternalTransferNoteOUTBOL
        Dim dt As New DataTable
        With objITNOutPPT
            .STInternalTransferOutID = strSTITNOutID
        End With
        dt = objITNOutBOL.ITNOutDetails_Select(objITNOutPPT)
        Me.dgvITNOut.AutoGenerateColumns = False
        Me.dgvITNOut.DataSource = dt
        strMenuID = "M120"
    End Sub

    Private Sub BindITNOutview()

        dgvITNOut.DataSource = Nothing

        Dim dt As New DataTable
        Dim objITNOutPPT As New InternalTransferNoteOUTPPT
        Dim objITNOutBOL As New InternalTransferNoteOUTBOL
        With objITNOutPPT
            If chkITNOutdate.Checked = True Then
                .ITNDate = dtpviewITNDate.Value 'Format(dtpviewITNDate.Value, "MM/dd/yyyy")
            Else
                .ITNDate = Nothing
            End If
            .ItnOutNo = txtviewITNOutNo.Text
            If cbStatus.SelectedItem = "SELECT ALL" Then
                .Status = String.Empty
            Else
                .Status = cbStatus.SelectedItem
            End If

            .ReceivedLocation = txtviewRecLoc.Text
        End With
        dt = objITNOutBOL.STInternalTransferOutSelect(objITNOutPPT)
        'If dt.Rows.Count > 0 Then
        dgvITNOutView.AutoGenerateColumns = False
        dgvITNOutView.DataSource = dt
        'Else
        'ClearGridView(dgvITNOutView)
        'End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


    End Sub
    Private Sub GetITNOUTNo()
        Dim dt As New DataTable
        Dim objITNOutNoPPT As New InternalTransferNoteOUTPPT
        Dim objITNOutNoBOL As New InternalTransferNoteOUTBOL
        dt = objITNOutNoBOL.GetITNOutNo(objITNOutNoPPT)
        Dim TNOutNo As String = objITNOutNoBOL.GetTNOutAutoNo()
        txtITNOUTNo.Text = TNOutNo
        If dt.Rows.Count > 0 Then
            'txtITNOUTNo.Text = dt.Rows(0).Item("NewITNOUTNo").ToString()
        Else
            DisplayInfoMessage("Msg01")
            'MessageBox.Show("ITN Deatils Missing in STConfiguration Table", "Failed to generate ITNout No.", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            ObjStockCode.stockID = frmStockCodeLookup._lStockID
            lblAvailablevalue.Text = frmStockCodeLookup._lAvailableQty
            lblAccCode.Text = frmStockCodeLookup._lAccountCode
            lblAccountDesc.Text = frmStockCodeLookup._lAccountDesc
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
            ''txtUnitPrice.Visible = True
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

    Private Function IsGridValidAdd()
        If txtStockCode.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg02")
            'MessageBox.Show(" Please check StockCode", " StockCode Missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtStockCode.Focus()
            Return False
        End If
        If txtTransferoutQty.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg03")
            'MessageBox.Show(" Please enter Transfer Qty", " Transfer Qty not entered", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTransferoutQty.Focus()
            Return False
        ElseIf txtTransferoutQty.Text.Trim = 0 Then
            DisplayInfoMessage("Msg04")
            'MessageBox.Show("Please enter Transfer Qty ", " Transfer Qty quantity can not be zero ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTransferoutQty.Focus()
            Return False
        End If
        ''If txtAccountCode.Text.Trim = String.Empty Then
        ''    MessageBox.Show(" Please enter Account Code", " Account Code not entered", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    txtAccountCode.Focus()
        ''    Return False
        ''End If
        'If txtUnitPrice.Text.Trim = String.Empty Then
        '    DisplayInfoMessage("Msg05")
        '    'MessageBox.Show(" Please enter Unit Price", " Unit Price Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtUnitPrice.Focus()
        '    Return False
        'End If
        'If txtUnitPrice.Text.Trim <= 0 Then
        '    DisplayInfoMessage("Msg06")
        '    'MessageBox.Show("Unit Price should not be Zero ", " Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtUnitPrice.Focus()
        '    Return False
        'End If
        If (CDbl(txtTransferoutQty.Text.Trim) > CDbl(lblAvailablevalue.Text.Trim)) Then
            DisplayInfoMessage("Msg07")
            'MessageBox.Show(" Available Qty less than TransferOut Qty", "Invalid Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTransferoutQty.Focus()
            Return False
        End If
        If (txtReceivedLocation.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg08")
            'MessageBox.Show("Received Location is empty", "Invalid Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtReceivedLocation.Focus()
            Return False
        End If

        If lblAvailablevalue.Text.Trim <> String.Empty Then
            If CDbl(lblAvailablevalue.Text.Trim) < InternalTransferNoteOUTBOL.STInternalTransferOutDetailsTransferOutQtyCheck(lStockID, txtTransferoutQty.Text.Trim) Then
                DisplayInfoMessage("Msg38")
                'MessageBox.Show("There is no enough stockavailable for the stock item " + lStockID)
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If AddFlag = True Then
            Insert_MultiEntry()

        Else
            Update_MultiEntry()
        End If

        'GlobalPPT.IsRetainFocus = True

    End Sub

    Private Function StockCodeExist(ByVal StockCode As String) As Boolean
        Dim objDataGridViewRow As New DataGridViewRow
        If AddFlag = True Then
            For Each objDataGridViewRow In dgvITNOut.Rows
                If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
                    txtStockCode.Text = ""
                    txtTransferoutQty.Text = ""
                    txtStockCode.Focus()
                    Return True
                End If
            Next
            Return False
        End If
    End Function

    Private Sub Insert_MultiEntry()
        If Not IsGridValidAdd() Then Exit Sub
        Dim intRowcount As Integer = dtITNOut.Rows.Count
        Dim i As Integer = dgvITNOut.Rows.Count
        AddFlag = True
        If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 
            rowITNOut = dtITNOut.NewRow()
            If intRowcount = 0 And DTFlag = False Then
                columnITNOut = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("AvailableQty", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("Unit", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("UnitPrice", System.Type.[GetType]("System.Decimal"))
                dtITNOut.Columns.Add(columnITNOut)
                'columnITNOut = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                'dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("AccountCode", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("AccountDesc", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("TransferOUTQty", System.Type.[GetType]("System.Decimal"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("TransferOUTValue", System.Type.[GetType]("System.Decimal"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("StockID", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("STInternalTransferOutDetailsID", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("StockCOAID", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                columnITNOut = New DataColumn("VarianceCOAID", System.Type.[GetType]("System.String"))
                dtITNOut.Columns.Add(columnITNOut)
                rowITNOut("StockCode") = txtStockCode.Text.ToString()
                rowITNOut("StockDesc") = lblStockDesc.Text.ToString()
                rowITNOut("PartNo") = lblPartNo.Text.ToString()
                rowITNOut("AvailableQty") = lblAvailablevalue.Text.ToString()
                rowITNOut("Unit") = lblUnitValue.Text.ToString()
                rowITNOut("UnitPrice") = txtUnitPrice.Text.ToString()
                ' rowITNOut("COAID") = lCOAID
                rowITNOut("AccountCode") = lblAccCode.Text.ToString()
                rowITNOut("AccountDesc") = lblAccountDesc.Text.ToString()
                rowITNOut("TransferOUTQty") = txtTransferoutQty.Text.ToString()
                rowITNOut("TransferOUTValue") = (CDbl(txtTransferoutQty.Text) * CDbl(txtUnitPrice.Text))
                rowITNOut("StockID") = lStockID
                rowITNOut("STInternalTransferOutDetailsID") = lSTITNOutDetID
                rowITNOut("StockCOAID") = lStockCOAID
                rowITNOut("VarianceCOAID") = lVarianceCOAID
                dtITNOut.Rows.InsertAt(rowITNOut, intRowcount)
                DTFlag = True
            Else
                rowITNOut("StockCode") = txtStockCode.Text.ToString()
                rowITNOut("StockDesc") = lblStockDesc.Text.ToString()
                rowITNOut("PartNo") = lblPartNo.Text.ToString()
                rowITNOut("AvailableQty") = lblAvailablevalue.Text.ToString()
                rowITNOut("Unit") = lblUnitValue.Text
                rowITNOut("UnitPrice") = txtUnitPrice.Text
                ' rowITNOut("COAID") = lCOAID
                rowITNOut("AccountCode") = lblAccCode.Text
                rowITNOut("AccountDesc") = lblAccountDesc.Text
                rowITNOut("TransferOUTQty") = txtTransferoutQty.Text
                rowITNOut("TransferOUTValue") = (CDbl(txtTransferoutQty.Text) * CDbl(txtUnitPrice.Text))
                rowITNOut("StockID") = lStockID ' Adding new Stock in Update mode so Stock ID will be null.
                rowITNOut("STInternalTransferOutDetailsID") = lSTITNOutDetID
                rowITNOut("StockCOAID") = lStockCOAID
                rowITNOut("VarianceCOAID") = lVarianceCOAID
                dtITNOut.Rows.InsertAt(rowITNOut, intRowcount)
            End If
            With dgvITNOut
                .AutoGenerateColumns = False
                .DataSource = dtITNOut
                clearMultiEntry()
            End With
            btnSaveAll.Focus()
        Else
            DisplayInfoMessage("Msg09")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Update_MultiEntry()
        If Not IsGridValidAdd() Then Exit Sub
        Dim strStCode As String = txtStockCode.Text.ToString()
        For i As Integer = 0 To dgvITNOut.Rows.Count - 1
            If i <> dgvITNOut.CurrentRow.Index Then
                If strStCode = dgvITNOut.Rows(i).Cells("dgclStockCode").Value.ToString() Then
                    DisplayInfoMessage("Msg10")
                    'MsgBox("Stock Code already exist in this ITN-Out Details")
                    clearMultiEntry()
                    txtStockCode.Focus()
                    Exit Sub
                End If
            Else
            End If
        Next
        If strStCode = dgvITNOut.CurrentRow.Cells("dgclStockCode").Value.ToString() Then
        End If

        If (CDbl(txtTransferoutQty.Text.Trim) > CDbl(lblAvailablevalue.Text.Trim)) Then
            DisplayInfoMessage("Msg11")
            'MessageBox.Show(" Available Qty less than TransferOut Qty", "Invalid Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim dgvrow As Integer
        Dim Str As String = dgvITNOut.Columns.Item(1).Name
        If AddFlag = False And dgvITNOut.Rows.Count > 0 Then
            dgvrow = dgvITNOut.CurrentRow.Index
            dtITNOut.Rows.RemoveAt(dgvrow)
            rowITNOut = dtITNOut.NewRow()
            rowITNOut("StockCode") = txtStockCode.Text.ToString()
            rowITNOut("StockDesc") = lblStockDesc.Text.ToString()
            rowITNOut("PartNo") = lblPartNo.Text.ToString()
            rowITNOut("AvailableQty") = lblAvailablevalue.Text.ToString()
            rowITNOut("Unit") = lblUnitValue.Text
            rowITNOut("UnitPrice") = txtUnitPrice.Text
            'rowITNOut("COAID") = lCOAID
            rowITNOut("AccountCode") = lblAccCode.Text
            rowITNOut("AccountDesc") = lblAccountDesc.Text
            rowITNOut("TransferOUTQty") = txtTransferoutQty.Text
            rowITNOut("TransferOUTValue") = (CDbl(txtTransferoutQty.Text) * CDbl(txtUnitPrice.Text))
            rowITNOut("StockID") = lStockID
            rowITNOut("STInternalTransferOutDetailsID") = lSTITNOutDetID
            rowITNOut("StockCOAID") = lStockCOAID
            rowITNOut("VarianceCOAID") = lVarianceCOAID
            dtITNOut.Rows.InsertAt(rowITNOut, dgvrow)
            dgvITNOut.DataSource = dtITNOut
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

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearMultiEntry()
    End Sub
    Private Sub clearMultiEntry()
        txtStockCode.Text = String.Empty
        txtStockCode.ReadOnly = False
        btnSearchStockCode.Enabled = True
        lblStockDesc.Text = String.Empty
        lblPartNo.Text = String.Empty
        lblAvailablevalue.Text = String.Empty
        lblUnitValue.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        lblAccCode.Text = String.Empty
        '  txtAccountCode.ReadOnly = False
        btnSearchAccCode.Enabled = True
        lblAccountDesc.Text = String.Empty
        txtTransferoutQty.Text = String.Empty
        txtTransferoutQty.ReadOnly = False
        lStockID = String.Empty
        lCOAID = String.Empty
        lSTITNOutDetID = String.Empty
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        AddFlag = True
        gbsave.Enabled = True
    End Sub

    Private Sub clearSingleEntry()

        DeleteMultientry.Clear()

        'txtITNOUTNo.Text = String.Empty
        txtReceivedLocation.Text = String.Empty
        txtReceivedLocation.ReadOnly = False
        btnSearchReceivedLocation.Enabled = True
        txtRemarks.Text = String.Empty
        txtRemarks.ReadOnly = False
        lSTITNOutID = String.Empty
        lReceivedLocationID = String.Empty
        dtpITNDate.Enabled = True
        lblStatusDesc.Text = "OPEN"
        btnSaveAll.Enabled = True
        lblRejectReason.Visible = False
        lblcolon21.Visible = False
        lblRejectreasondesc.Text = String.Empty
        txtOperatorName.Clear()
        txtMRCNo.Clear()
        txtVehicleNo.Clear()
    End Sub

    Private Sub btnSearchReceivedLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchReceivedLocation.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lReceivedLocation = SenderReceiverLocLookup._lSenderLocation
            lReceivedLocationID = SenderReceiverLocLookup._lSenderLocationID
            txtReceivedLocation.Text = lReceivedLocation
            '
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

            '
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

    Private Sub dgvITNOut_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNOut.CellDoubleClick
        
        Edit_SingleEntry()
        MultiEntryvisible_True()

    End Sub
   
    Private Sub Edit_SingleEntry()
        If dgvITNOut.Rows.Count > 0 Then
            txtStockCode.Text = dgvITNOut.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            lblStockDesc.Text = dgvITNOut.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
            lblPartNo.Text = dgvITNOut.SelectedRows(0).Cells("dgclPartNo").Value.ToString()
            lblAvailablevalue.Text = dgvITNOut.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
            lblUnitValue.Text = dgvITNOut.SelectedRows(0).Cells("dgclUnit").Value.ToString()
            txtUnitPrice.Text = dgvITNOut.SelectedRows(0).Cells("dgclUnitPrice").Value.ToString()
            lStockCOAID = dgvITNOut.SelectedRows(0).Cells("dgclStockCOAID").Value.ToString()
            lblAccCode.Text = dgvITNOut.SelectedRows(0).Cells("dgclAccountCode").Value.ToString()
            lblAccountDesc.Text = dgvITNOut.SelectedRows(0).Cells("dgclAccountDesc").Value.ToString()
            'txtQtyIssued.Text = Format(Val(dgIssueVoucher.SelectedRows(0).Cells("dgclIssuedQty").Value), "0.0")
            txtTransferoutQty.Text = Format(Val(dgvITNOut.SelectedRows(0).Cells("dgclTransferOutQty").Value), "0.00")
            'txtTransferoutQty.Text = dgvITNOut.SelectedRows(0).Cells("dgclTransferOutQty").Value.ToString()
            lStockID = dgvITNOut.SelectedRows(0).Cells("dgclStockID").Value.ToString()
            lSTITNOutDetID = dgvITNOut.SelectedRows(0).Cells("dgclSTInternalTransferOutDetailsID").Value.ToString()
            AddFlag = False
            'btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If

        End If
    End Sub


    Private Sub MultiEntryvisible_True()
        lblStockDesc.Visible = True
        'lblUnitPriceValue.Visible = True
        lblUnitValue.Visible = True
        lblAvailablevalue.Visible = True
        lblAccountDesc.Visible = True
        lblPartNo.Visible = True
    End Sub

    Private Sub txtTransferoutQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransferoutQty.KeyDown

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

                        isDecimal = oneDecimalPlaces.IsMatch(text)

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

    Private Sub txtTransferoutQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransferoutQty.KeyPress

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
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ResetAll()
    End Sub
    Private Sub ResetAll()

        clearSingleEntry()
        clearMultiEntry()
        ClearGridView(dgvITNOut)
        DTFlag = True
        GetITNOUTNo()
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim mdiparent As New MDIParent

        If (dgvITNOut.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And mdiparent.strMenuID = "M9" And btnSaveAll.Enabled = True) Then
            If MsgBox(rm.GetString("Msg41"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

    Private Sub btnviewRecLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewRecLoc.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lReceivedLocation = SenderReceiverLocLookup._lSenderLocation
            lReceivedLocationID = SenderReceiverLocLookup._lSenderLocationID
            txtviewRecLoc.Text = lReceivedLocation
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindITNOutview()
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim ObjRecordExist As New Object
        Dim ObjITNOUT As New InternalTransferNoteOUTPPT
        Dim ObjITNOutBOL As New InternalTransferNoteOUTBOL
        ObjRecordExist = ObjITNOutBOL.ITNOutRecordIsExisT(ObjITNOUT)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg12")
            'MsgBox("No Records Available!")
        Else
            StrFrmName = "ITNOut"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub
    Private Function IsFormValid()
        If dtpITNDate.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg13")
            'MessageBox.Show(" Please check ITNDate", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        If txtITNOUTNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg14")
            'MessageBox.Show(" Please enter ITN No.", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtITNOUTNo.Focus()
            Return False
        End If
        If txtReceivedLocation.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg15")
            'MessageBox.Show(" Please enter Received Location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtReceivedLocation.Focus()
            Return False
        End If
        If dgvITNOut.RowCount = 0 Then
            DisplayInfoMessage("Msg16")
            'MessageBox.Show("ITN - OUT Details Required!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return True
    End Function

    Private Sub SaveAll()

        If Not IsFormValid() Then Exit Sub
        Dim rowsAffected As Integer = 0
        Dim dt As New DataTable
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL
        With objITNOUTPPT
            .ITNDate = dtpITNDate.Value 'Format(dtpITNDate.Value, "MM/dd/yyyy")
            .ItnOutNo = txtITNOUTNo.Text
            .Status = "OPEN" 'lblStatusDesc.Text
            .Remarks = txtRemarks.Text
            .RejectedReason = txtRejectedReason.Text
            .ReceivedLocation = lReceivedLocationID
            .STInternalTransferOutID = lSTITNOutID  'STITNInID to differentiate for update
            .OperatorName = txtOperatorName.Text
            .TransportDate = dtpTransportDate.Value
            .VehicleNo = txtVehicleNo.Text
            .MRCNo = txtMRCNo.Text
        End With
        If lSTITNOutID = "" Then
            dt = objITNOUTBOL.Save_STInternalTransferOut(objITNOUTPPT)
            If dt.Rows.Count > 0 Then
                lSTITNOutID = dt.Rows(0).Item("STInternalTransferOutID").ToString() 'newly generated STIPRID to as FK to insert STIPRDetID
            Else
                DisplayInfoMessage("Msg17")
                'MessageBox.Show("Failed to insert Records", "Error occured in insert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                rowsAffected = objITNOUTBOL.Delete_STInternalTransferOut(objITNOUTPPT)
                Exit Sub
            End If
        Else

            DeleteMultiEntryRecords()

            rowsAffected = objITNOUTBOL.Update_STInternalTransferOut(objITNOUTPPT)
            If rowsAffected = 1 Then
            Else
                DisplayInfoMessage("Msg18")
                'MessageBox.Show("Failed to update Records", "Error occured in updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim arrayListInfo As New ArrayList()
        Dim DataGridViewRow As DataGridViewRow
        For Each DataGridViewRow In dgvITNOut.Rows
            With objITNOUTPPT
                .StockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
                .PartNo = DataGridViewRow.Cells("dgclPartNo").Value.ToString()
                .UnitPrice = CDbl(DataGridViewRow.Cells("dgclUnitPrice").Value.ToString())
                .AvailQty = DataGridViewRow.Cells("dgclAvailableQty").Value.ToString()
                .COAID = DataGridViewRow.Cells("dgclStockCOAID").Value.ToString()
                .TransferOutQty = CDbl(DataGridViewRow.Cells("dgclTransferOutQty").Value.ToString())
                .TransferOutValue = DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString()
                .STInternalTransferOutID = lSTITNOutID
                .STInternalTransferOutDetailsID = DataGridViewRow.Cells("dgclSTInternalTransferOutDetailsID").Value.ToString()
            End With
            If objITNOUTPPT.STInternalTransferOutDetailsID = "" Then
                rowsAffected = objITNOUTBOL.Save_STITNOutDetailsInsert(objITNOUTPPT)
            Else
                rowsAffected = objITNOUTBOL.Update_STITNOutDetails(objITNOUTPPT)
            End If
        Next
        If rowsAffected = 1 Then
            If objITNOUTPPT.STInternalTransferOutDetailsID = "" Then
                DisplayInfoMessage("Msg19")
                'MessageBox.Show("Records inserted Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DisplayInfoMessage("Msg20")
                'MessageBox.Show("Records updated Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("Msg21")
            'MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rowsAffected = objITNOUTBOL.Delete_STInternalTransferOut(objITNOUTPPT)
        End If
        ClearGridView(dgvITNOut)
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        clearSingleEntry()
        clearMultiEntry()
        lSTITNOutID = String.Empty
        GetITNOUTNo()

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dgvITNOutView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNOutView.CellDoubleClick
        EditViewGridRecord()
    End Sub
    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditUpdateToolStripMenuItem.Enabled = True Then
                If dgvITNOutView.RowCount > 0 Then
                    If dgvITNOutView.SelectedRows(0).Cells("dgclStatus").Value <> "OPEN" And dgvITNOutView.SelectedRows(0).Cells("dgclStatus").Value <> "REJECTED" Then
                        clearMultiEntry()
                        ITNOut_Edit()
                        Disable_basedOnstatus()
                    Else
                        clearMultiEntry()
                        ITNOut_Edit()
                        Enable_basedOnstatus()
                    End If
                End If
            End If
        End If
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
        txtITNOUTNo.ReadOnly = True
        txtReceivedLocation.ReadOnly = True
        dtpITNDate.Enabled = False
        'dgvITNIn.Enabled = False
        txtStockCode.ReadOnly = True
        'txtAccountCode.ReadOnly = True
        txtTransferoutQty.ReadOnly = True
        btnSearchAccCode.Enabled = False
        btnSearchStockCode.Enabled = False
        btnSearchReceivedLocation.Enabled = False
        Button1.Enabled = False
        txtRemarks.ReadOnly = True
        gbsave.Enabled = False
    End Sub

    Private Sub Enable_basedOnstatus()
        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        ' txtITNOUTNo.ReadOnly = False
        txtReceivedLocation.ReadOnly = False
        dtpITNDate.Enabled = True
        txtStockCode.ReadOnly = False
        'txtAccountCode.ReadOnly = False
        txtTransferoutQty.ReadOnly = False
        btnSearchAccCode.Enabled = True
        btnSearchStockCode.Enabled = True
        btnSearchReceivedLocation.Enabled = True
        gbsave.Enabled = True
        txtRemarks.ReadOnly = False
    End Sub

    Private Sub ITNOut_Edit()
        dgvITNOut.DataSource = Nothing
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL
        If dgvITNOutView.Rows.Count > 0 Then
            txtITNOUTNo.Text = dgvITNOutView.SelectedRows(0).Cells("dgclITNOutNo").Value.ToString()
            lblStatusDesc.Text = dgvITNOutView.SelectedRows(0).Cells("dgclStatus").Value.ToString()
            Dim str As String = dgvITNOutView.SelectedRows(0).Cells("dgclITNOutDate").Value.ToString()
            dtpITNDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            txtReceivedLocation.Text = dgvITNOutView.SelectedRows(0).Cells("dgclReceivedLocation").Value.ToString()
            txtRemarks.Text = dgvITNOutView.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            lSTITNOutID = dgvITNOutView.SelectedRows(0).Cells("dgclSTITNOutID").Value.ToString()
            lReceivedLocationID = dgvITNOutView.SelectedRows(0).Cells("dgclReceivedLocationID").Value.ToString()
            If Not dgvITNOutView.SelectedRows(0).Cells("dgclRejectedReason").Value Is DBNull.Value Then
                lblRejectreasondesc.Text = dgvITNOutView.SelectedRows(0).Cells("dgclRejectedReason").Value.ToString()
                lblRejectReason.Visible = True
                lblcolon21.Visible = True
                lblRejectreasondesc.Visible = True
            Else
                lblRejectReason.Visible = False
                lblcolon21.Visible = False
                lblRejectreasondesc.Text = String.Empty
            End If
            DTFlag = True
            With objITNOUTPPT
                .STInternalTransferOutID = lSTITNOutID
            End With
            dtITNOut = objITNOUTBOL.ITNOutDetails_Select(objITNOUTPPT)
            If dtITNOut.Rows.Count > 0 Then
                dgvITNOut.AutoGenerateColumns = False
                dgvITNOut.DataSource = dtITNOut
                gvSTITNOutDetID = dtITNOut.Rows(0).Item("STInternalTransferOutDetailsID").ToString()
                'lSTEstMillDelivID = dt.Rows(0).Item("STEstMillDeliveryID").ToString()
            Else
                DisplayInfoMessage("Msg22")
                'MessageBox.Show("No Records to Select", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            tcITNOut.SelectedTab = tbpgITNOutAdd
            'btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

        Else
            DisplayInfoMessage("Msg23")
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        clearSingleEntry()
        clearMultiEntry()
        ClearGridView(dgvITNOut)
        tcITNOut.SelectedTab = tbpgITNOutAdd
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
        GetITNOUTNo()
    End Sub

    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
         EditViewGridRecord()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteITNInView()
    End Sub

    Private Sub DeleteITNInView()
        Dim rowsAffected As Integer = 0
        cmsITNOutView.Visible = False
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL
        Dim dt As New DataTable
        If dgvITNOutView.Rows.Count > 0 Then
            If dgvITNOutView.SelectedRows(0).Cells("dgclStatus").Value = "OPEN" Then
                If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    lSTITNOutID = dgvITNOutView.SelectedRows(0).Cells("dgclSTITNOutID").Value.ToString()
                    With objITNOUTPPT
                        .STInternalTransferOutID = lSTITNOutID
                    End With
                    rowsAffected = objITNOUTBOL.Delete_STInternalTransferOut(objITNOUTPPT)
                    If rowsAffected = 1 Then
                        DisplayInfoMessage("Msg25")
                        'MessageBox.Show("Records Deleted Successfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        BindITNOutview()
                    Else
                        DisplayInfoMessage("Msg26")
                        'MessageBox.Show("Sorry, Sleected Records not Deleted ", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                DisplayInfoMessage("Msg27")
                'MessageBox.Show("Not a valid record to delete, status must be OPEN ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("Msg28")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgvITNOutView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvITNOutView.KeyDown
        If e.KeyCode = Keys.Return Then
             EditViewGridRecord()
            e.Handled = True
        End If
    End Sub

    Private Sub dgvITNOutView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvITNOutView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgvITNOutView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgvITNOutView.ClearSelection()
                    dgvITNOutView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Dim rowsAffected As Integer = 0
        Dim dtStockDetail As New DataTable
        Dim LedgerID As String = String.Empty
        Dim dtLedgerModule As New DataTable
        Dim dtAveragePrice As DataTable = Nothing
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL
        ' step : 1 to update the status and rejected reason in STInternalTransferOut 
        If cbApprovalStatus.SelectedItem = String.Empty Then
            DisplayInfoMessage("Msg29")
            'MessageBox.Show("Please select status to Approve")
            Exit Sub
        Else
            If cbApprovalStatus.SelectedItem = "REJECTED" And txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg30")
                'MessageBox.Show("Please enter valid Rejected reason")
                Exit Sub
            Else
                With objITNOUTPPT
                    .STInternalTransferOutID = lSTITNOutID
                    .Status = cbApprovalStatus.SelectedItem.ToString()
                    .RejectedReason = txtRejectedReason.Text.Trim()
                End With
                rowsAffected = objITNOUTBOL.Update_STInternalTransferOutApproval(objITNOUTPPT)
                If rowsAffected > 0 Then
                Else
                    DisplayInfoMessage("Msg31")
                    'MessageBox.Show("Confirmation Failed in Status update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If

        'Dim dtSupplierCOAID As New DataTable
        'objITNOUTPPT.ReceivedLocation = txtReceivedLocation.Text
        'dtSupplierCOAID = objITNOUTBOL.STITNOutRecLocGet(objITNOUTPPT)


        ' step : 2 to insert in Accouns.LedgerALL table
        'For Each DataGridViewRow In dgvITNOut.Rows
        With objITNOUTPPT
            If txtRemarks.Text <> String.Empty Then
                .Remarks = txtITNOUTNo.Text.Trim & "-" & txtRemarks.Text.Trim
            Else
                .Remarks = txtITNOUTNo.Text.Trim
            End If

            '.Remarks = txtRemarks.Text
            .ITNDate = dtpITNDate.Value
            .TransferOutValue = Nothing '.TransferOutValue + CDbl(DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString()) 'BatchAmount
            '.STInternalTransferOutID = lSTITNOutID
        End With
        ' Next
        dtLedgerModule = objITNOUTBOL.Save_LedgerAllModule(objITNOUTPPT)
        If dtLedgerModule.Rows.Count > 0 Then
            LedgerID = dtLedgerModule.Rows(0).Item("LedgerID").ToString() 'LedgerAllModule Function returns LedgerID 
            objITNOUTPPT.LedgerID = LedgerID
        Else
            DisplayInfoMessage("Msg32")
            'MessageBox.Show("Error in Inserting Ledger All Module", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim strArray As String()
        Dim strLoginMonthName As String
        strArray = GlobalPPT.strLoginMonth.Split("-")
        strLoginMonthName = strArray(1)

        ' step : 2 to find Average Price &  to Insert journal Detail

        Dim DataGridViewRow As DataGridViewRow
        For Each DataGridViewRow In dgvITNOut.Rows

            With objITNOUTPPT
                .STInternalTransferOutID = lSTITNOutID
                .StockID = DataGridViewRow.Cells("dgclStockID").Value.ToString()
                .TransferOutQty = CDbl(DataGridViewRow.Cells("dgclTransferOutQty").Value.ToString())
                .TransferOutValue = CDbl(DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString())

                dtAveragePrice = objITNOUTBOL.ITNOut_Averageprice(objITNOUTPPT)
                ' objITNOUTPPT.TransferOutValue = Nothing

                objITNOUTPPT.STInternalTransferOutDetailsID = DataGridViewRow.Cells("dgclSTInternalTransferOutDetailsID").Value.ToString()
                objITNOUTPPT.StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
                'objITNOUTPPT.TransferOutQty = DataGridViewRow.Cells("dgclTransferOutQty").Value.ToString()

                Dim dsSTInternalTransferOutDetailSelect As New DataSet
                dsSTInternalTransferOutDetailSelect = objITNOUTBOL.STInternalTransferOutDetailSelect(objITNOUTPPT)
                If Not dsSTInternalTransferOutDetailSelect Is Nothing Then
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("STDPrice").ToString <> String.Empty Then
                        AppSTDPrice = CDbl(dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("STDPrice").ToString())
                    Else
                        AppSTDPrice = 0
                    End If
                    AppSTDPriceValue = (DataGridViewRow.Cells("dgclTransferOutQty").Value * AppSTDPrice)
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID").ToString <> String.Empty Then
                        AppStockCOAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID")
                    Else
                        AppStockCOAID = String.Empty
                    End If
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID").ToString <> String.Empty Then
                        AppVarianceCOAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID")
                    Else
                        AppVarianceCOAID = String.Empty
                    End If
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("TransferOutValue").ToString <> String.Empty Then
                        intTransferOutValue = CDbl(dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("TransferOutValue"))
                    Else
                        intTransferOutValue = 0
                    End If

                End If
                
                'If dtAveragePrice.Rows.Count > 0 Then 'For Jounal Insert Process
                '    AppSTDPrice = dtAveragePrice.Rows(0).Item("STDPrice").ToString()
                '    AppStockCOAID = dtAveragePrice.Rows(0).Item("StockCOAID").ToString()
                '    AppVarianceCOAID = dtAveragePrice.Rows(0).Item("VarianceCOAID").ToString()

                '    dtAveragePrice()
                'End If

                'to Insert in journal Detail

                'For SenderPrice Start
                If AppSTDPriceValue = 0 Then

                    If Not DataGridViewRow.Cells("dgclTransferOutValue").Value Is DBNull.Value And AppStockCOAID <> String.Empty Then
                        .DC = "D"
                        '.COAID = dtSupplierCOAID.Rows(0).Item("SupplierCOAID").ToString()  'Supplier COAID
                        .COAID = lSupplierCOAID
                        '.value = CDbl(DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString())
                        .value = intTransferOutValue
                        '.T0 = String.Empty
                        .T0 = lT0
                        .T1 = lT1
                        .T2 = lT2
                        .T3 = lT3
                        .T4 = lT4
                        .StationID = String.Empty
                        '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString() 'Stock Name of corresponding stockid
                        .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + txtReceivedLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' <ITN-OUT No.> -<Receiver Location Name> <loginMonth&Year>
                        .Flag = "ITNOUTPRICE"
                        rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

                        .DC = "C"
                        If Not dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID") Is DBNull.Value Then
                            .COAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID").ToString()
                        Else
                            .COAID = ""
                        End If

                        '.value = CDbl(DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString())
                        .value = intTransferOutValue
                        ''.T0 = String.Empty
                        '.T0 = String.Empty
                        '.T1 = String.Empty
                        '.T2 = String.Empty
                        '.T3 = String.Empty
                        '.T4 = String.Empty

                        If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T0").ToString <> String.Empty Then
                            .T0 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T0")
                        Else
                            .T0 = String.Empty
                        End If
                        If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T1").ToString <> String.Empty Then
                            .T1 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T1")
                        Else
                            .T1 = String.Empty
                        End If
                        If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T2").ToString <> String.Empty Then
                            .T2 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T2")
                        Else
                            .T2 = String.Empty
                        End If
                        If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T3").ToString <> String.Empty Then
                            .T3 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T3")
                        Else
                            .T3 = String.Empty
                        End If
                        If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T4").ToString <> String.Empty Then
                            .T4 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T4")
                        Else
                            .T4 = String.Empty
                        End If

                        .StationID = String.Empty
                        '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                        .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-OUT No.> -<” StockCode-Stock Description” as selected in the TransferNote-OUT>


                        .Flag = "ITNOUTPRICE"
                        rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

                    End If
                End If
                'For SenderPrice end

                'For STDPrice Start

                'AppSTDPriceValue = (DataGridViewRow.Cells("dgclTransferOutQty").Value * AppSTDPrice)

                If AppSTDPriceValue <> 0 And AppStockCOAID <> String.Empty Then

                    .DC = "D"
                    '.COAID = dtSupplierCOAID.Rows(0).Item("SupplierCOAID").ToString()
                    .COAID = lSupplierCOAID
                    'StockCOAID for debit
                    .value = AppSTDPriceValue ' Qty * STDPrice
                    '.T0 = String.Empty
                    .T0 = lT0
                    .T1 = lT1
                    .T2 = lT2
                    .T3 = lT3
                    .T4 = lT4
                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString() 'Stock Name of corresponding stockid

                    .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + txtReceivedLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' <ITN-OUT No.> -<Receiver Location Name> <loginMonth&Year>
                    .Flag = "ITNOUTSTDPRICE"
                    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

                    .DC = "C"
                    .COAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID").ToString()   'Supplier COAID for credit - this is from General.GeneralDistributionsetup Table
                    .value = AppSTDPriceValue ' Qty * STDPrice
                    '.T0 = String.Empty
                    '.T0 = String.Empty
                    '.T1 = String.Empty
                    '.T2 = String.Empty
                    '.T3 = String.Empty
                    '.T4 = String.Empty

                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T0").ToString <> String.Empty Then
                        .T0 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T0")
                    Else
                        .T0 = String.Empty
                    End If
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T1").ToString <> String.Empty Then
                        .T1 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T1")
                    Else
                        .T1 = String.Empty
                    End If
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T2").ToString <> String.Empty Then
                        .T2 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T2")
                    Else
                        .T2 = String.Empty
                    End If
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T3").ToString <> String.Empty Then
                        .T3 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T3")
                    Else
                        .T3 = String.Empty
                    End If
                    If dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T4").ToString <> String.Empty Then
                        .T4 = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("T4")
                    Else
                        .T4 = String.Empty
                    End If

                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString() 'Stock Name of corresponding stockid
                    .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-OUT No.> -<” StockCode-Stock Description” as selected in the TransferNote-OUT>
                    .Flag = "ITNOUTSTDPRICE"
                    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)
                End If
                'For STDPrice End

                'For VariancePrice if -ve Start 

                'AppVariancePrice = Abs(CDbl(DataGridViewRow.Cells("dgclTransferoutValue").Value.ToString()) - AppSTDPriceValue) 
                AppVariancePrice = intTransferOutValue - AppSTDPriceValue '.value = intTransferOutValue
                If AppSTDPriceValue <> 0 And AppVariancePrice < 0 And AppVarianceCOAID <> String.Empty Then
                    .DC = "D"
                    .COAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID").ToString()
                    .value = Abs(AppVariancePrice)
                    .T0 = String.Empty
                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                    .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-OUT No.> -<” StockCode-Stock Description” as selected in the TransferNote-OUT>
                    .Flag = "ITNOUTVARIANCEPRICE"
                    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

                    .DC = "C"
                    .COAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID").ToString()  'Variance COAID  - this is from Store.STCategory Table
                    .value = Abs(AppVariancePrice)
                    .T0 = String.Empty
                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                    .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + txtReceivedLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() + "-Variance" ' <ITN-OUT No.> -<Receiver Location Name> <loginMonth&Year>-Variance
                    .Flag = "ITNOUTVARIANCEPRICE"
                    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)
                End If

                'For VariancePrice if -ve End

                'For VariancePrice if +ve Start 

                'AppVariancePrice = Abs(CDbl(DataGridViewRow.Cells("dgclTransferoutValue").Value.ToString()) - AppSTDPriceValue) 
                AppVariancePrice = intTransferOutValue - AppSTDPriceValue '.value = intTransferOutValue
                If AppSTDPriceValue <> 0 And AppVariancePrice > 0 And AppVarianceCOAID <> String.Empty Then
                    .DC = "D"
                    .COAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID").ToString()
                    .value = Abs(AppVariancePrice)
                    .T0 = String.Empty
                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                    .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + txtReceivedLocation.Text.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() + "-Variance" ' <ITN-OUT No.> -<Receiver Location Name> <loginMonth&Year>-Variance

                       .Flag = "ITNOUTVARIANCEPRICE"
                    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

                    .DC = "C"
                    .COAID = dsSTInternalTransferOutDetailSelect.Tables(0).Rows(0).Item("StockCOAID").ToString()
                    .value = Abs(AppVariancePrice)
                    .T0 = String.Empty
                    .StationID = String.Empty
                    '.JournalDetDescp = DataGridViewRow.Cells("dgclStockDesc").Value.ToString()
                      .JournalDetDescp = txtITNOUTNo.Text.Trim + "-" + DataGridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + DataGridViewRow.Cells("dgclStockDesc").Value.ToString() '<ITN-OUT No.> -<” StockCode-Stock Description” as selected in the TransferNote-OUT>

                    .Flag = "ITNOUTVARIANCEPRICE"
                    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)
                End If

                'For VariancePrice if +ve End

            End With
        Next
        rowsAffected = objITNOUTBOL.Update_LedgerAllModule(objITNOUTPPT)
        If rowsAffected > 0 Then

            'Call TaskMonitor Update after successful approval -Start

            Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
            Dim dsTaskMonitorUPDATE As New DataSet
            objStoreMonthEndClosingPPT.ModID = 2
            objStoreMonthEndClosingPPT.Task = "Internal Transfer Note OUT approval"
            objStoreMonthEndClosingPPT.Complete = "Y"
            dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)

            'Call TaskMonitor Update after successful approval -End

        Else
            DisplayInfoMessage("Msg33")
            'MessageBox.Show("Error in Journal Debit Insert", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        DisplayInfoMessage("Msg34")
        'MessageBox.Show("Confirmation Success", " Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        GlobalPPT.IsButtonClose = True
        Me.Close()

        '' step : 4 journal Detail Insert  For debit - STD PRICE


        'Dim TotTrnsOutValue As Double = 0.0
        'For Each DataGridViewRow In dgvITNOut.Rows
        '    If DataGridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
        '        With objITNOUTPPT
        '            .StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
        '            .TransferOutQty = DataGridViewRow.Cells("dgclTransferOutQty").Value.ToString()
        '            .TransferOutValue = DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString()
        '            .COAID = DataGridViewRow.Cells("dgclStockCOAID").Value.ToString() 'StockCOAID for debit
        '            .DC = "D"
        '            .LedgerID = LedgerID 'LedgerID From LedgerAllModule
        '            dtStockDetail = objITNOUTBOL.ITNOut_StockDetailGet(objITNOUTPPT)
        '            .JournalDetDescp = dtStockDetail.Rows(0).Item("StockDesc").ToString() 'Stock Name of corresponding stockid
        '            .Flag = "STD PRICE"
        '            TotTrnsOutValue = TotTrnsOutValue + CDbl(DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString()) ' for following Credit function
        '        End With
        '    End If
        '    rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)
        '    If rowsAffected > 0 Then
        '    Else
        '        MessageBox.Show("Error in Journal Debit Insert", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If
        'Next

        ''For credit - STD PRICE

        'Dim dtSupplierCOAID As New DataTable
        'objITNOUTPPT.ReceivedLocation = txtReceivedLocation.Text
        'dtSupplierCOAID = objITNOUTBOL.STITNOutRecLocGet(objITNOUTPPT)
        'With objITNOUTPPT
        '    .COAID = dtSupplierCOAID.Rows(0).Item("SupplierCOAID").ToString()  'Supplier COAID for credit - this is from General.GeneralDistributionsetup Table
        '    .TransferOutValue = TotTrnsOutValue
        '    .DC = "C"
        '    .Flag = "STD PRICE"
        'End With
        'rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)
        'If rowsAffected > 0 Then
        'Else
        '    MessageBox.Show("Error in Journal Credit Insert ", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

        ''''''''''


        ''For debit and credit- Variance PRICE

        'Dim ldStdPrice As Double
        'Dim ldVariancePrice As Double
        'Dim ldTotalPrice As Double 'TransferInValue as Total Price.
        'For Each DataGridViewRow In dgvITNOut.Rows
        '    If DataGridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
        '        With objITNOUTPPT
        '            .StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
        '            .TransferOutQty = DataGridViewRow.Cells("dgclTransferoutQty").Value.ToString()
        '            dtStockDetail = objITNOUTBOL.ITNOut_StockDetailGet(objITNOUTPPT)
        '            If dtStockDetail.Rows(0).Item("StdPrice").ToString <> String.Empty Then
        '                ldStdPrice = dtStockDetail.Rows(0).Item("StdPrice").ToString() 'Standard Price from Stock Detail
        '            End If
        '            ldTotalPrice = DataGridViewRow.Cells("dgclTransferOutValue").Value.ToString()
        '            ldVariancePrice = ldStdPrice - ldTotalPrice
        '            .JournalDetDescp = dtStockDetail.Rows(0).Item("StockDesc") 'Stock Description
        '            .Flag = "VARIANCE PRICE"

        '            If ldVariancePrice > 0 Then 'If Variance price is +ve , debit the variance COAID and credit the supplier COAID
        '                .TransferOutValue = ldVariancePrice
        '                .DC = "D"
        '                .COAID = DataGridViewRow.Cells("dgclVarianceCOAID").Value.ToString() 'Variance COAID
        '                rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

        '                .DC = "C"
        '                .COAID = dtSupplierCOAID.Rows(0).Item("COAID").ToString() 'Supplier COAID 
        '                rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

        '            ElseIf ldVariancePrice < 0 Then 'If Variance price is -ve,Credit the variance COAID and debit the supplier COAID
        '                .TransferOutValue = ldVariancePrice
        '                .DC = "C"
        '                .COAID = DataGridViewRow.Cells("dgclVarianceCOAID").Value.ToString()
        '                rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

        '                .DC = "D"
        '                .COAID = dtSupplierCOAID.Rows(0).Item("SupplierCOAID").ToString()
        '                rowsAffected = objITNOUTBOL.AC_JournalDetailInsert(objITNOUTPPT)

        '            End If
        '        End With
        '    End If
        'Next
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
            End If

            lblPartNo.Text = dt.Rows(0).Item("PartNo")
            lblAccCode.Text = dt.Rows(0).Item("AccountCode").ToString()
            lblAccountDesc.Text = dt.Rows(0).Item("AccountDesc")
            lStockCOAID = dt.Rows(0).Item("StockCOAID")
            If Not IsDBNull(dt.Rows(0).Item("VarianceCOAID")) Then lVarianceCOAID = dt.Rows(0).Item("VarianceCOAID")
            lblAvailablevalue.Text = dt.Rows(0).Item("AvailableQty")
            lblAvailablevalue.Visible = True
            lblAccountDesc.Visible = True
            Me.lblUnitValue.Visible = True
            Me.lblStockDesc.Visible = True
            lblPartNo.Visible = True
        Else
            DisplayInfoMessage("Msg35")
            'MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtStockCode.Text = String.Empty
            Me.lblUnitValue.Text = String.Empty
            Me.lblStockDesc.Text = String.Empty
            Me.txtUnitPrice.Text = String.Empty
            Me.lblAvailablevalue.Text = String.Empty
            lblPartNo.Text = String.Empty
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

    Private Sub txtReceivedLocation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedLocation.Leave
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL
        Dim dt As New DataTable
        If txtReceivedLocation.Text <> String.Empty Then
            objITNOUTPPT.ReceivedLocation = txtReceivedLocation.Text
            dt = objITNOUTBOL.STITNOutRecLocGet(objITNOUTPPT)
            If dt.Rows.Count <> 0 Then

                If Not dt.Rows(0).Item("DistributionDescp") Is DBNull.Value Then
                    Me.txtReceivedLocation.Text = dt.Rows(0).Item("DistributionDescp").ToString()
                Else
                    Me.txtReceivedLocation.Text = String.Empty
                End If

                lSenderLocationID = dt.Rows(0).Item("DistributionSetupID").ToString()
                lReceivedLocationID = dt.Rows(0).Item("DistributionSetupID").ToString()

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
                DisplayInfoMessage("Msg36")
                'MessageBox.Show("Invalid Location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtReceivedLocation.Text = String.Empty
                txtReceivedLocation.Focus()
            End If
        End If
    End Sub

    Private Sub ResetAllOnTabClick()

        clearSingleEntry()
        clearMultiEntry()
        ClearGridView(dgvITNOut)
        'Dim i As Integer = dtITNOut.Rows.Count
        dtITNOut.Rows.Clear()
        'btnAdd.Text = "Add"
        dtpITNDate.Focus()
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

        AddFlag = True
        GetITNOUTNo()
        Enable_basedOnstatus()
        lblStatusDesc.Text = "OPEN"

    End Sub
    Private Sub tcITNOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcITNOut.Click

        If tcITNOut.SelectedTab Is tbpgITNOutAdd = True Then
            If tcITNOut.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgvITNOut.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg40"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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
        ElseIf tcITNOut.SelectedTab Is tbpgITNOutView = True Then

            chkITNOutdate.Focus()

            If (dgvITNOut.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And btnSaveAll.Enabled = True) Then

                If MsgBox(rm.GetString("Msg40"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    ClearGridView(dgvITNOut)
                    GlobalPPT.IsRetainFocus = False
                    txtviewITNOutNo.Text = String.Empty
                    txtviewITNOutNo.Text = String.Empty
                    chkITNOutdate.Checked = False
                    BindITNOutview()

                Else

                    tcITNOut.SelectedTab = tbpgITNOutAdd

                End If

            Else
                txtviewITNOutNo.Text = String.Empty
                txtviewITNOutNo.Text = String.Empty
                chkITNOutdate.Checked = False
                ResetAll()
                BindITNOutview()

            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        'If txtAccountCode.Text = String.Empty Then
        '    lblAccountDesc.Text = String.Empty
        '    'txtAccountCode.Focus()
        '    Exit Sub
        'End If
        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        objITNINPPT.COACode = lblAccCode.Text.Trim
        dt = objITNINBOL.AcctlookupSearch(objITNINPPT)
        If dt.Rows.Count <> 0 Then
            lblAccountDesc.Text = dt.Rows(0).Item("COADescp").ToString()
            lblAccountDesc.Visible = True
        Else
            DisplayInfoMessage("Msg37")
            'MessageBox.Show("Invalid Account code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblAccCode.Text = String.Empty
            lblAccountDesc.Text = String.Empty
            ' txtAccountCode.Focus()
        End If
    End Sub


    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteOUTFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

        If mdiparent.strMenuID = "M9" Then
            tcITNOut.TabPages("tbpgITNOutAdd").Text = rm.GetString("tcIPR.TabPages(tbpgITNOutAdd).Text")
            tcITNOut.TabPages("tbpgITNOutView").Text = rm.GetString("tcIPR.TabPages(tbpgITNOutView).Text")
        Else
            tcITNOut.TabPages("tbpgITNOutAdd").Text = rm.GetString("tcIPR.TabPages(tbpgITNOutAdd).Text")
            gbITNOutApproval.Text = rm.GetString("gbITNOutApproval.Text")
            btnConfirm.Text = rm.GetString("btnConfirm.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
        End If

        lblITNOUTDate.Text = rm.GetString("lblITNOUTDate.Text")
        lblITNOutNo.Text = rm.GetString("lblITNOutNo.Text")
        lblReceivedLocation.Text = rm.GetString("lblReceivedLocation.Text")
        lblRemarks.Text = rm.GetString("lblRemarks.Text")
        lblStatus.Text = rm.GetString("lblStatus.Text")
        lblStockCode.Text = rm.GetString("lblStockCode.Text")
        lblUnitPrice.Text = rm.GetString("lblUnitPrice.Text")
        lblUnit.Text = rm.GetString("lblUnit.Text")
        lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
        lblTransferOutQty.Text = rm.GetString("lblTransferOutQty.Text")
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
        gbITNOUTDetail.Text = rm.GetString("gbITNOUTDetail.Text")


        dgvITNOut.Columns("dgclStockCode").HeaderText = rm.GetString("dgvITNOut.Columns(dgclStockCode).HeaderText")
        dgvITNOut.Columns("dgclStockDesc").HeaderText = rm.GetString("dgvITNOut.Columns(dgclStockDesc).HeaderText")
        dgvITNOut.Columns("dgclPartNo").HeaderText = rm.GetString("dgvITNOut.Columns(dgclPartNo).HeaderText")
        dgvITNOut.Columns("dgclAccountCode").HeaderText = rm.GetString("dgvITNOut.Columns(dgclAccountCode).HeaderText")
        dgvITNOut.Columns("dgclAccountDesc").HeaderText = rm.GetString("dgvITNOut.Columns(dgclAccountDesc).HeaderText")
        dgvITNOut.Columns("dgclAvailableQty").HeaderText = rm.GetString("dgvITNOut.Columns(dgclAvailableQty).HeaderText")
        dgvITNOut.Columns("dgclUnitPrice").HeaderText = rm.GetString("dgvITNOut.Columns(dgclUnitPrice).HeaderText")
        dgvITNOut.Columns("dgclUnit").HeaderText = rm.GetString("dgvITNOut.Columns(dgclUnit).HeaderText")
        dgvITNOut.Columns("dgclTransferOutQty").HeaderText = rm.GetString("dgvITNOut.Columns(dgclTransferOutQty).HeaderText")
        dgvITNOut.Columns("dgclTransferOutValue").HeaderText = rm.GetString("dgvITNOut.Columns(dgclTransferOutValue).HeaderText")

        lblviewITNDate.Text = rm.GetString("lblviewITNDate.Text")
        lblviewITNOutNo.Text = rm.GetString("lblviewITNOutNo.Text")
        lblviewReceivedLoc.Text = rm.GetString("lblReceivedLocation.Text")
        lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
        plITNOutSearch.Text = rm.GetString("plITNOutSearch.Text")
        lblsearchBy.Text = rm.GetString("lblsearchBy.Text")

        dgvITNOutView.Columns("dgclITNOutDate").HeaderText = rm.GetString("dgvITNOutView.Columns(dgclITNOutDate).HeaderText")
        dgvITNOutView.Columns("dgclITNOutNo").HeaderText = rm.GetString("dgvITNOutView.Columns(dgclITNOutNo).HeaderText")
        dgvITNOutView.Columns("dgclReceivedLocation").HeaderText = rm.GetString("dgvITNOutView.Columns(dgclReceivedLocation).HeaderText")
        dgvITNOutView.Columns("dgclStatus").HeaderText = rm.GetString("dgvITNOutView.Columns(dgclStatus).HeaderText")



        'display a message if the culture is not supported
        'try passing bn (Bengali) for testing
        'MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    

    Private Sub DeleteToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem3.Click


        If dgvITNOut.RowCount = 0 Then
            Exit Sub
        ElseIf dgvITNOut.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else
            If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                DeleteMultientrydatagrid()
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub DeleteMultientrydatagrid()



        lsSTInternalTransferOutDetailsID = dgvITNOut.SelectedRows(0).Cells("dgclSTInternalTransferOutDetailsID").Value.ToString

        lDelete = 0
        If lsSTInternalTransferOutDetailsID <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lsSTInternalTransferOutDetailsID)


        End If
        Dim Dr As DataRow
        Dr = dtITNOut.Rows.Item(dgvITNOut.CurrentRow.Index)
        Dr.Delete()
        dtITNOut.AcceptChanges()
        lsSTInternalTransferOutDetailsID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objITNOutPPT As New InternalTransferNoteOUTPPT
        Dim objITNOutBOL As New InternalTransferNoteOUTBOL

        lDelete = DeleteMultientry.Count
        'objSIVPPT.STIssueID = psSIVSTIssueId
        While (lDelete > 0)

            With objITNOutPPT

                .STInternalTransferOutDetailsID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntITNOutDetailDelete As New Integer
            IntITNOutDetailDelete = objITNOutBOL.STInternalTransferOutDetailsDelete(objITNOutPPT)

            lDelete = lDelete - 1

        End While


    End Sub



    Private Sub InternalTransferNoteOUTFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'If dgvITNOut.RowCount > 0 Then

        '    If MsgBox(rm.GetString("Msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

        '    End If

        'End If


    End Sub

    Private Sub lblAvailablevalue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAvailablevalue.TextChanged

        If IsNumeric(lblAvailablevalue.Text) Then
            lblAvailablevalue.Text = Format(CDbl(lblAvailablevalue.Text), "##0.000")
        End If
    End Sub

    Private Sub txtTransferoutQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransferoutQty.TextChanged
        'If Val(txtTransferoutQty.Text) > 0 Then
        '    txtTransferoutQty.Text = Format(Val(txtTransferoutQty.Text), "0")
        'End If


    End Sub

    Private Sub EditToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem2.Click
        Edit_SingleEntry()
        MultiEntryvisible_True()
    End Sub

    Private Sub chkITNOutdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkITNOutdate.CheckedChanged


        If chkITNOutdate.Checked = True Then
            dtpviewITNDate.Enabled = True
        Else
            dtpviewITNDate.Enabled = False
        End If

    End Sub

    Private Sub InternalTransferNoteOUTFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (dgvITNOut.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("Msg40"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False

            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M9"
                'mdiparent.lblMenuName.Text = "IPR"

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim objIPRNo As New VHNoLookup()
        Dim result As DialogResult = objIPRNo.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            txtVehicleNo.Text = objIPRNo.psVHWSCode
        End If
    End Sub

    Private Sub dgvITNOut_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNOut.CellContentClick

    End Sub
End Class