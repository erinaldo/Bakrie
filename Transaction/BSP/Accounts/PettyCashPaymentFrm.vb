Imports Accounts_BOL
Imports Accounts_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class PettyCashPaymentFrm

    Public Shared StrFrmName As String = String.Empty
    Public lPaymentID As String = String.Empty
    ' Public lPayToID As String = String.Empty
    Public lCOAID As String = String.Empty
    Public lStatusValue As String = String.Empty
    'Public lApprovedStatus As String = String.Empty
    Public psT0analysisID As String = String.Empty
    Public psT1analysisID As String = String.Empty
    Public psT2analysisID As String = String.Empty
    Public psT3analysisID As String = String.Empty
    Public psT4analysisID As String = String.Empty
    Public psUOMID As String = String.Empty
    Public lVoucherNo As String = String.Empty
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim isDecimalQty As Boolean
    Dim reDecimalPlacesQty As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Public lAccountCode As String = String.Empty
    Dim rowMultipleEntryAdd As DataRow
    Dim dtPCP As New DataTable("todgPCP")
    Dim columnPCPAdd As DataColumn
    Dim rowPCPAdd As DataRow
    Public lbtnAdd As String = "Add"
    Public lbtnSave As String = "Save All"
    ''''For Approval
    Public psLedgerID As String = String.Empty
    Public psLedgerNo As String = String.Empty
    Public psLedgerType As String = String.Empty
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim dtPayTo As New DataTable()
    Dim isModifierKey As Boolean
    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashPaymentFrm))
    Public psVHID As String = String.Empty
    Public psCategoryID As String = String.Empty
    Public psVHCategoryType As String = String.Empty
    Public psVHDetailCostCodeID As String = String.Empty

    Private Sub Clear()

        ddlTranscationType.SelectedIndex = 0
        Me.txtAccountCode.Text = String.Empty
        Me.lblAccountDescp.Text = String.Empty
        lblOldAccountCode.Text = String.Empty
        lblUOMDescp.Text = String.Empty
        Me.txtT0.Text = GlobalPPT.strEstateCode
        Me.lblT0Name.Text = GlobalPPT.strEstateCode
        Me.txtT1.Text = String.Empty
        Me.lblT1Name.Text = String.Empty
        Me.txtT2.Text = String.Empty
        Me.lblT2Name.Text = String.Empty
        Me.txtT3.Text = String.Empty
        Me.lblT3Name.Text = String.Empty
        Me.txtT4.Text = String.Empty
        Me.lblT4Name.Text = String.Empty
        Me.txtAmount.Text = String.Empty
        Me.txtQty.Text = String.Empty
        Me.txtRemarks.Text = String.Empty
        lPaymentID = String.Empty
        lCOAID = String.Empty
        lStatusValue = String.Empty
        psT0analysisID = String.Empty
        psT1analysisID = String.Empty
        psT2analysisID = String.Empty
        psT3analysisID = String.Empty
        psT4analysisID = String.Empty
        psUOMID = String.Empty
        Me.txtVoucherNoSearch.Text = String.Empty
        GlobalBOL.SetDateTimePicker(Me.dtpviewVoucherDate)
        Me.chkVoucherDate.Checked = False
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        Else
            btnAdd.Text = "Menambahkan"
        End If

        lbtnAdd = "Add"
        lAccountCode = String.Empty
        lVoucherNo = String.Empty
        btnSave.Enabled = True
        btnDeleteAll.Enabled = True
        cmbSearchStatus.Text = "Open"
        lblRecjectedReason.Visible = False
        lblColon.Visible = False
        lblRejectedReasonValue.Visible = False
        psVHID = ""
        psVHCategoryType = ""
        psVHDetailCostCodeID = ""
        Me.txtDetailCostCode.Text = ""
        Me.txtVehicleCode.Text = ""
        Me.lblVehicleDescp.Text = ""
        Me.lblDetailCostDescp.Text = ""

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub clearVoucherNoGroupBox()
        Me.txtVoucherNo.Text = String.Empty
        '  CbPayTo.SelectedIndex = 0
        CbPayTo.Text = "Petty Cash"
        GlobalBOL.SetDateTimePicker(Me.dtpVoucherDate)
        '  Me.txtDescp.Text = String.Empty
        Me.cbDiscrepancytransaction.Checked = False
        Me.txtPaidTo.Text = String.Empty
        Me.lblStatusValue.Text = "OPEN"
        DeleteMultientry.Clear()

        If GlobalPPT.strLang = "en" Then
            Me.btnSave.Text = "Save All"
        Else
            Me.btnSave.Text = "Simpan Semua"
        End If
        lbtnSave = "Save All"
        btnSave.Visible = True
        btnAdd.Visible = True
        Me.grpVoucherNo.Enabled = True
    End Sub


    Private Function IsSaveValid()

        If dtPayTo.Rows.Count = 0 Then
            MsgBox("No COA with Description Petty Cash , Please insert the record in General Distribution Setup")
            Return True
        End If


        If Me.txtVoucherNo.Text.Trim = "" Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("Voucher No Required", "Voucher No")
            txtVoucherNo.Focus()
            Return True
        End If
        If Me.dtpVoucherDate.Value = Nothing Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("Voucher Date Required", "Voucher Date")
            dtpVoucherDate.Focus()
            Return True
        End If
        If Me.txtPaidTo.Text.Trim = "" Then
            DisplayInfoMessage("Msg3")
            '' MessageBox.Show("Pay To Required", "Pay to")
            txtPaidTo.Focus()
            Return True
        End If

      
        


        Return False
    End Function
    Private Function IsSaveValidMultiEntry()

        If Me.txtAccountCode.Text.Trim = "" Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("Account Code Required", "Account Code")
            txtAccountCode.Focus()
            Return True
        End If
        If Val(Me.txtAmount.Text.Trim) = 0 Then
            DisplayInfoMessage("Msg6")
            ''MessageBox.Show("Amount Required", "Amount")
            txtAmount.Focus()
            Return True
        End If

        If Me.txtVehicleCode.Text <> "" Then
            If Me.txtDetailCostCode.Text = "" Then
                DisplayInfoMessage("Msg7")
            End If
        End If
        If Me.txtRemarks.Text.Trim = "" Then
            DisplayInfoMessage("Msg4")
            ''MessageBox.Show("Description Required", "Description")
            txtRemarks.Focus()
            Return True
        End If

        Return False
    End Function

    Private Sub PaytoValue()


        Dim objPayTo As New PettyCashPaymentPPT()
        Dim ObjPaytoBOL As New PettyCashPaymentBOL()
        dtPayTo = ObjPaytoBOL.GetPayToValue(objPayTo)
        CbPayTo.DataSource = dtPayTo


        If dtPayTo.Rows.Count = 0 Then
            MsgBox("No COA with Description Petty Cash , Please insert the record in General Distribution Setup")
            Exit Sub
        End If

        'If dtPayTo.Rows.Count = 0 Then

        'End If

        '  Dim row As Integer = 0


        '  While (dtPayTo.Rows.Count > row)
        ' If dtPayTo.Rows(row).Item("DistributionDescp") = "Petty Cash" Then
        CbPayTo.DisplayMember = "DistributionDescp"
        CbPayTo.ValueMember = "DistributionSetupID"
        ' End If
        'row = row + 1
        'End While
        'CbPayTo.DisplayMember = "DistributionDescp"
        'CbPayTo.ValueMember = "DistributionSetupID"




        ' If dtPayTo IsNot Nothing And dtPayTo.Rows.Count > 0 Then
        'Dim dr As DataRow = dtPayTo.NewRow()
        'dr(1) = "--Select--"
        '' dr(2) = "--Select--"
        'dtPayTo.Rows.InsertAt(dr, 0)
        ' End If
        'CbPayTo.SelectedIndex = 0
        CbPayTo.Text = "Petty Cash"

    End Sub

    Private Sub PettyCashPaymentFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSave.Enabled = True And DgvMultipleEntry.RowCount > 0 And GlobalPPT.IsButtonClose = False And btnSave.Visible = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M101"

            End If
        End If
    End Sub

    Private Sub PettyCastPaymentFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        Me.lblVehicleDescp.Text = ""
        Me.lblDetailCostDescp.Text = ""

        SetUICulture(GlobalPPT.strLang)
        Dim mdiparent As New MDIParent
        PaytoValue()
        If mdiparent.strMenuID = "M110" Then
            Clear()
            BindDataGrid()
            BindMultipleEntryDataGrid()
            tbPCP.TabPages.Remove(tbView)
            grpApproval.Visible = True
            btnSave.Enabled = False
            btnResetIB.Enabled = False
            btnAdd.Enabled = False
            btnDeleteAll.Enabled = False
            cmbStatus.SelectedIndex = 0
            lblApprovalDate.Visible = True
            lblColon13.Visible = True
            dtpApprovalDate.Visible = True
            CMSMultipleentry.Enabled = False
        Else
            'Dim dt As New DataTable
            'Dim ObjPCR As New AccountsApprovalPPT
            'Dim ObjPCRBOLApp As New AccountsApprovalBOL
            'dt = ObjPCRBOLApp.GetPettyCashReceiptCOAID(ObjPCR)
            'If dt.Rows.Count = 0 Then
            '    MsgBox("There is no COA code for Petty Cash / Due to Samarinda, please include the reords general General Distribution Setup  screen with description Petty Cash and Due to Samarinda  ")
            'End If
            clearVoucherNoGroupBox()
            Clear()
            BindDataGrid()
            grpApproval.Visible = False
            Me.tbPCP.SelectedTab = tbView
            txtVoucherNoSearch.Focus()
            lblApprovalDate.Visible = False
            lblColon13.Visible = False
            dtpApprovalDate.Visible = False
        End If



    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tbPCP.TabPages("tbAdd").Text = rm.GetString("tbPCP.TabPages(tbAdd).Text")
            tbPCP.TabPages("tbView").Text = rm.GetString("tbPCP.TabPages(tbView).Text")

            'Add Tab Controls
            grpVoucherDetails.Text = rm.GetString("grpVoucherDetails.Text")

            'Add Lables
            lblVoucherNo.Text = rm.GetString("lblVoucherNo.Text")
            lblVoucherDate.Text = rm.GetString("lblVoucherDate.Text")
            lblPayto.Text = rm.GetString("lblPayto.Text")
            lblStatus.Text = rm.GetString("lblStatus.Text")
            lblSearchStatus.Text = rm.GetString("lblSearchStatus.Text")

            lblDescp.Text = rm.GetString("lblDescp.Text")
            lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
            lblT0.Text = rm.GetString("lblT0.Text")
            lblT1.Text = rm.GetString("lblT1.Text")
            lblT2.Text = rm.GetString("lblT2.Text")
            lblT3.Text = rm.GetString("lblT3.Text")
            lblT4.Text = rm.GetString("lblT4.Text")
            lblAmount.Text = rm.GetString("lblAmount.Text")
            lblQty.Text = rm.GetString("lblQty.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblUnit.Text = rm.GetString("lblUnit.Text")
            lblvoucherNoSearch.Text = rm.GetString("lblvoucherNoSearch.Text")
            cbDiscrepancytransaction.Text = rm.GetString("cbDiscrepancytransaction.Text")
            lblTrancactionType.Text = rm.GetString("lblTrancactionType.Text")

            'Add Datagrid Fields
            dgvPettyCashPaymentView.Columns("dgclVoucherNo").HeaderText = rm.GetString("dgvPettyCashPaymentView.Columns(dgclVoucherNo).HeaderText")
            dgvPettyCashPaymentView.Columns("dgclVoucherDate").HeaderText = rm.GetString("dgvPettyCashPaymentView.Columns(dgclVoucherDate).HeaderText")
            dgvPettyCashPaymentView.Columns("dgclDistributionDescp").HeaderText = rm.GetString("dgvPettyCashPaymentView.Columns(dgclDistributionDescp).HeaderText")
            dgvPettyCashPaymentView.Columns("dgclDescription").HeaderText = rm.GetString("dgvPettyCashPaymentView.Columns(dgclDescription).HeaderText")
            dgvPettyCashPaymentView.Columns("dgclApproved").HeaderText = rm.GetString("dgvPettyCashPaymentView.Columns(dgclApproved).HeaderText")



            DgvMultipleEntry.Columns("dgmeAccountCode").HeaderText = rm.GetString("DgvMultipleEntry.Columns(dgmeAccountCode).HeaderText")
            DgvMultipleEntry.Columns("dgmeOldCOACode").HeaderText = rm.GetString("DgvMultipleEntry.Columns(dgmeOldCOACode).HeaderText")
            DgvMultipleEntry.Columns("DgMeAccountDescp").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeAccountDescp).HeaderText")
            DgvMultipleEntry.Columns("DgMeTAnalysisCode0").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeTAnalysisCode0).HeaderText")
            DgvMultipleEntry.Columns("DgMeTAnalysisCode1").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeTAnalysisCode1).HeaderText")
            DgvMultipleEntry.Columns("DgMeTAnalysisCode2").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeTAnalysisCode2).HeaderText")
            DgvMultipleEntry.Columns("DgMeTAnalysisCode3").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeTAnalysisCode3).HeaderText")
            DgvMultipleEntry.Columns("DgMeTAnalysisCode4").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeTAnalysisCode4).HeaderText")
            DgvMultipleEntry.Columns("DgMeAmount").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeAmount).HeaderText")
            DgvMultipleEntry.Columns("DgMeQty").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeQty).HeaderText")
            DgvMultipleEntry.Columns("DgMeUOM").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeUOM).HeaderText")
            DgvMultipleEntry.Columns("DgMeRemarks").HeaderText = rm.GetString("DgvMultipleEntry.Columns(DgMeRemarks).HeaderText")

            cmsPCP.Items.Item(0).Text = rm.GetString("cmsPCP.Items.Item(0).Text")
            cmsPCP.Items.Item(1).Text = rm.GetString("cmsPCP.Items.Item(1).Text")
            cmsPCP.Items.Item(2).Text = rm.GetString("cmsPCP.Items.Item(2).Text")

            CMSMultipleentry.Items.Item(0).Text = rm.GetString("cmsPCP.Items.Item(0).Text")
            CMSMultipleentry.Items.Item(1).Text = rm.GetString("cmsPCP.Items.Item(1).Text")
            CMSMultipleentry.Items.Item(2).Text = rm.GetString("cmsPCP.Items.Item(2).Text")


            'Add Btn Fields
            btnSave.Text = rm.GetString("btnSave.Text")
            btnResetIB.Text = rm.GetString("btnResetIB.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnResetMultipleEntryGrp.Text = rm.GetString("btnResetMultipleEntryGrp.Text")
            btnConform.Text = rm.GetString("btnConform.Text")

            'View Tab Controls
            PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText") 'lblSearchBy
            lblsearchBy.Text = rm.GetString("lblSearchBy.Text")
            chkVoucherDate.Text = rm.GetString("chkVoucherDate.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashPaymentFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub btnAccountCodeLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountCodeLookup.Click

        Dim frmAcctcodeLookup As New COALookup
        Cursor = Cursors.WaitCursor
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            lCOAID = frmAcctcodeLookup.strAcctId
            lblAccountDescp.Text = frmAcctcodeLookup.strAcctDescp
            lblOldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave
        If txtAccountCode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objPettyCashPayment As New PettyCashPaymentPPT
            objPettyCashPayment.COACode = txtAccountCode.Text.Trim()
            Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashPaymentBOL.AcctlookupSearch(objPettyCashPayment, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg7")
                ''MessageBox.Show("Invalid Account code,Please Choose it from look up")
                txtAccountCode.Text = String.Empty
                lblAccountDescp.Text = String.Empty
                lblOldAccountCode.Text = String.Empty
                lCOAID = String.Empty
                txtAccountCode.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
                    txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                End If
                If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
                    lblAccountDescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
                End If
                If ds.Tables(0).Rows(0).Item("COAID").ToString() <> String.Empty Then
                    lCOAID = ds.Tables(0).Rows(0).Item("COAID")
                End If
                If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
                    lblOldAccountCode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                End If
            End If
        Else
            txtAccountCode.Text = String.Empty
            lblAccountDescp.Text = String.Empty
            lblOldAccountCode.Text = String.Empty
            lCOAID = String.Empty
        End If
    End Sub


    Private Sub btnSearchT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT0.Click
        Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T0"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtT0.Text = frmTLookup.strTValue
            Me.lblT0Name.Text = frmTLookup.strTDesc
            psT0analysisID = frmTLookup.strTId
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT1.Click
        Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T1"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtT1.Text = frmTLookup.strTValue
            Me.lblT1Name.Text = frmTLookup.strTDesc
            psT1analysisID = frmTLookup.strTId
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT2.Click
        Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T2"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtT2.Text = frmTLookup.strTValue
            Me.lblT2Name.Text = frmTLookup.strTDesc
            psT2analysisID = frmTLookup.strTId
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT3.Click
        Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T3"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtT3.Text = frmTLookup.strTValue
            Me.lblT3Name.Text = frmTLookup.strTDesc
            psT3analysisID = frmTLookup.strTId
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT4.Click
        Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T4"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtT4.Text = frmTLookup.strTValue
            Me.lblT4Name.Text = frmTLookup.strTDesc
            psT4analysisID = frmTLookup.strTId
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtT0_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT0.Leave
        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjPCP As New PettyCashPaymentPPT
            ObjPCP.T0Value = txtT0.Text.Trim()
            ObjPCP.TDecide = "T0"
            Dim ObjPettyCashBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashBOL.TlookupSearch(ObjPCP, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg8")
                ''MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                Me.lblT0Name.Text = String.Empty
                Me.txtT0.Text = String.Empty
                psT0analysisID = String.Empty
                txtT0.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT0Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT0.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                psT0analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT0Name.Text = String.Empty
            Me.txtT0.Text = String.Empty
            psT0analysisID = String.Empty
        End If
    End Sub

    Private Sub txtT1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT1.Leave
        If txtT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjPCP As New PettyCashPaymentPPT
            ObjPCP.T1Value = txtT1.Text.Trim()
            ObjPCP.TDecide = "T1"
            Dim ObjPettyCashBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashBOL.TlookupSearch(ObjPCP, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg9")
                ''MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
                Me.lblT1Name.Text = String.Empty
                Me.txtT1.Text = String.Empty
                psT1analysisID = String.Empty
                txtT1.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT1Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT1.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                psT1analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT1Name.Text = String.Empty
            Me.txtT1.Text = String.Empty
            psT1analysisID = String.Empty
        End If
    End Sub

    Private Sub txtT2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT2.Leave
        If txtT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjPCP As New PettyCashPaymentPPT
            ObjPCP.T2Value = txtT2.Text.Trim()
            ObjPCP.TDecide = "T2"
            Dim ObjPettyCashBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashBOL.TlookupSearch(ObjPCP, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg10")
                ''MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
                Me.lblT2Name.Text = String.Empty
                Me.txtT2.Text = String.Empty
                psT2analysisID = String.Empty
                txtT2.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT2Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT2.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                psT2analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT2Name.Text = String.Empty
            Me.txtT2.Text = String.Empty
            psT2analysisID = String.Empty
        End If

    End Sub

    Private Sub txtT3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT3.Leave
        If txtT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjPCP As New PettyCashPaymentPPT
            ObjPCP.T3Value = txtT3.Text.Trim()
            ObjPCP.TDecide = "T3"
            Dim ObjPettyCashBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashBOL.TlookupSearch(ObjPCP, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg11")
                ''MessageBox.Show("Invalid T3 Value,Please Choose it from look up")
                Me.lblT3Name.Text = String.Empty
                Me.txtT3.Text = String.Empty
                psT3analysisID = String.Empty
                txtT3.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT3Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT3.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                psT3analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT3Name.Text = String.Empty
            Me.txtT3.Text = String.Empty
            psT3analysisID = String.Empty
        End If

    End Sub

    Private Sub txtT4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        If txtT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjPCP As New PettyCashPaymentPPT
            ObjPCP.T4Value = txtT4.Text.Trim()
            ObjPCP.TDecide = "T4"
            Dim ObjPettyCashBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashBOL.TlookupSearch(ObjPCP, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg12")
                ''MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
                Me.lblT4Name.Text = String.Empty
                Me.txtT4.Text = String.Empty
                psT4analysisID = String.Empty
                txtT4.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT4Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT4.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                psT4analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT4Name.Text = String.Empty
            Me.txtT4.Text = String.Empty
            psT4analysisID = String.Empty
        End If
    End Sub

    Private Sub BindDataGrid()
        Try
            Dim mdiparent As New MDIParent

            Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
            Dim objPettyCashPaymentBOL As New PettyCashPaymentBOL
            Dim dt As New DataTable

            With objPettyCashPaymentPPT

                If mdiparent.strMenuID = "M110" Then
                    .VoucherNo = AccountApprovalFrm.ApprovalVoucherNo
                    .lVoucherDate = "01/01/1900"
                    .Approved = "N"
                Else
                    If chkVoucherDate.Checked = True Then
                        dtpviewVoucherDate.Enabled = True
                        .lVoucherDate = Format(Me.dtpviewVoucherDate.Value, "yyyy/MM/dd")
                    Else
                        dtpviewVoucherDate.Enabled = False
                        .lVoucherDate = "01/01/1900"
                    End If
                    If cmbSearchStatus.Text = "Select All" Then
                        .Approved = "S"
                    ElseIf cmbSearchStatus.Text = "OPEN" Then
                        .Approved = "N"
                    Else
                        .Approved = "Y"
                    End If
                    .VoucherNo = Me.txtVoucherNoSearch.Text.Trim

                End If
            End With

            dt = objPettyCashPaymentBOL.GetPettyCashPayment(objPettyCashPaymentPPT)
            If dt.Rows.Count <> 0 Then
                If mdiparent.strMenuID = "M110" Then

                    grpVoucherNo.Enabled = False
                    Me.txtVoucherNo.Text = dt.Rows(0).Item("VoucherNo")
                    Me.dtpVoucherDate.Value = dt.Rows(0).Item("VoucherDate")
                    Me.CbPayTo.Text = dt.Rows(0).Item("DistributionDescp")
                    Me.txtDescp.Text = dt.Rows(0).Item("PayDescp")
                    Me.lStatusValue = dt.Rows(0).Item("DiscrepancyTransaction")
                    If Me.lStatusValue = "N" Then
                        cbDiscrepancytransaction.Checked = False
                    Else
                        cbDiscrepancytransaction.Checked = True
                    End If
                    lblStatusValue.Text = "OPEN"
                Else
                    dgvPettyCashPaymentView.AutoGenerateColumns = False
                    Me.dgvPettyCashPaymentView.DataSource = dt

                End If




            Else
                ClearGridView(dgvPettyCashPaymentView) '''''clear the records from grid view
                'lblView.Visible = True
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
            Next
        End If
    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If txtVoucherNoSearch.Text.Trim = String.Empty And chkVoucherDate.Checked = False And cmbSearchStatus.Text = "OPEN" Then
            DisplayInfoMessage("Msg13")
            ''MsgBox("Please Enter Criteria to Search!")
            BindDataGrid()
            Exit Sub
        Else
            BindDataGrid()
            If dgvPettyCashPaymentView.RowCount = 0 Then
                DisplayInfoMessage("Msg14")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub
    Private Sub UpdatePettyCashPaymentView()

        If dgvPettyCashPaymentView.Rows.Count > 0 Then
            If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSave.Enabled = True
                End If
            End If


            grpVoucherNo.Enabled = False

            Me.txtVoucherNo.Text = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclVoucherNo").Value.ToString
            Me.dtpVoucherDate.Value = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclVoucherDate").Value.ToString
            Me.CbPayTo.Text = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclDistributionDescp").Value.ToString
            ' Me.lPayToID = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclPayToID").Value.ToString
            Me.txtPaidTo.Text = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclPaidTo").Value.ToString
            Me.txtDescp.Text = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclDescription").Value.ToString
            Me.lStatusValue = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclDiscrepancyTransaction").Value
            If Me.lStatusValue = "N" Then
                cbDiscrepancytransaction.Checked = False
            Else
                cbDiscrepancytransaction.Checked = True
            End If
            lblStatusValue.Text = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclApproved").Value.ToString
            If lblStatusValue.Text = "APPROVED" Then
                btnSave.Visible = False
                btnAdd.Visible = False
            Else
                btnSave.Visible = True
                btnAdd.Visible = True
            End If


            lblRejectedReasonValue.Text = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclRejectedReason").Value.ToString
            If lblRejectedReasonValue.Text <> String.Empty Then
                lblRecjectedReason.Visible = True
                lblColon.Visible = True
                lblRejectedReasonValue.Visible = True
            End If


            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update All"
            Else
                Me.btnSave.Text = "Update Semua"
            End If

            lbtnSave = "Update All"
            BindMultipleEntryDataGrid()
            'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If


            Me.tbPCP.SelectedTab = tbAdd
        Else
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub dgvPettyCashPaymentView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPettyCashPaymentView.DoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdatePettyCashPaymentView()
                Me.tbPCP.SelectedTab = tbAdd
            End If
        End If

      
    End Sub
    Private Sub txtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If

        isModifierKey = False

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode

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


    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If isModifierKey Then
            e.Handled = True
            Return
        End If

        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            isDecimalQty = False
                            Return
                        End If

                        isDecimalQty = True
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

                        isDecimalQty = reDecimalPlacesQty.IsMatch(text)

                End Select
            Else
                isDecimalQty = False
                Return
            End If

        Else
            isDecimalQty = True
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        'if the decimal digits reaches more than 3 digits then stop entering
        If isDecimalQty = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub dgvPettyCashPaymentView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPettyCashPaymentView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdatePettyCashPaymentView()
            e.Handled = True
        End If

    End Sub

    Private Sub dgvPettyCashPaymentView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPettyCashPaymentView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvPettyCashPaymentView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvPettyCashPaymentView.ClearSelection()
                    Me.dgvPettyCashPaymentView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub DeletePettyCashPaymentView()
        Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
        Dim objPettyCashPaymentBOL As New PettyCashPaymentBOL
        Dim dt As New DataTable
        If dgvPettyCashPaymentView.Rows.Count > 0 Then
            If Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclApproved").Value.ToString() = "APPROVED" Then
                DisplayInfoMessage("Msg16")
                ''MessageBox.Show("User cannot Delete Approved Record", "BSP")
                Exit Sub
            End If

            '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashPaymentFrm))
            If MsgBox(rm.GetString("Msg17"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                '    Me.Close()
                'End If
                '' If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                lVoucherNo = Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclVoucherNo").Value.ToString()
                With objPettyCashPaymentPPT
                    .VoucherNo = Me.lVoucherNo
                End With
                objPettyCashPaymentBOL.DeletePettyCashPayment(objPettyCashPaymentPPT)
                BindDataGrid()
                DisplayInfoMessage("Msg18")
                ''MsgBox("Data Successfully Deleted !")
            End If

        Else
            DisplayInfoMessage("Msg19")
            ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeletePettyCashPaymentView()
        Clear()
        clearVoucherNoGroupBox()
        BindDataGrid()
    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        'If Not objUserLoginBOl.Privilege(btnSave, ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        Clear()
        clearVoucherNoGroupBox()
        tbPCP.SelectedTab = tbAdd

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        'If Not objUserLoginBOl.Privilege(btnSave, ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        UpdatePettyCashPaymentView()
        Me.tbPCP.SelectedTab = tbAdd
    End Sub

    Private Sub chkVoucherDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVoucherDate.CheckedChanged
        If Me.chkVoucherDate.Checked = True Then
            Me.dtpviewVoucherDate.Enabled = True
        Else
            Me.dtpviewVoucherDate.Enabled = False
        End If
    End Sub

    Private Sub tbPCP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPCP.Click
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        If DgvMultipleEntry.RowCount > 0 And btnSave.Enabled = True And btnSave.Visible = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tbPCP.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                clearVoucherNoGroupBox()
                Clear()
                chkVoucherDate.Focus()
                BindDataGrid()
                ClearGridView(DgvMultipleEntry)
            End If
        Else
            clearVoucherNoGroupBox()
            Clear()
            chkVoucherDate.Focus()
            BindDataGrid()
            ClearGridView(DgvMultipleEntry)



        End If

       
    End Sub
    Private Sub SaveDatas()



        Dim ds As New DataSet

        For Each DataGridViewRow In DgvMultipleEntry.Rows
            Dim ObjPettyCashPaymentPPT As New PettyCashPaymentPPT
            Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
            With ObjPettyCashPaymentPPT
                .VoucherNo = Me.txtVoucherNo.Text.Trim
                .VoucherDate = Me.dtpVoucherDate.Value
                .PayToID = CbPayTo.SelectedValue.ToString()
                .PayDescp = Me.txtDescp.Text.Trim
                .PaidTo = Me.txtPaidTo.Text.Trim
                If cbDiscrepancytransaction.Checked = True Then
                    .DiscrepancyTransaction = "Y"
                Else
                    .DiscrepancyTransaction = "N"
                End If
                .COAID = DataGridViewRow.Cells("dgmeCOAID").Value.ToString()
                txtAccountCode.Text = DataGridViewRow.Cells("dgmeAccountCode").Value.ToString()
                txtAmount.Text = DataGridViewRow.Cells("dgmeAccountCode").Value.ToString()
                .T0 = DataGridViewRow.Cells("dgmeT0").Value.ToString()
                .T1 = DataGridViewRow.Cells("dgmeT1").Value.ToString()
                .T2 = DataGridViewRow.Cells("dgmeT2").Value.ToString()
                .T3 = DataGridViewRow.Cells("dgmeT3").Value.ToString()
                .T4 = DataGridViewRow.Cells("dgmeT4").Value.ToString()
                .Amount = DataGridViewRow.Cells("dgmeAmount").Value.ToString()
                .Remarks = DataGridViewRow.Cells("dgmeRemarks").Value.ToString()
                .UOMID = DataGridViewRow.Cells("dgmeUOMID").Value.ToString()
                If DataGridViewRow.Cells("dgmeQty").Value.ToString() <> "" Then
                    .Qty = DataGridViewRow.Cells("dgmeQty").Value.ToString()
                End If
                .Approved = "N"
                .RejectedReason = ""

                .DC = DataGridViewRow.Cells("DgMeTransactionType").Value.ToString()
                If Not IsDBNull(DataGridViewRow.Cells("VHID").Value) Then
                    .VHID = DataGridViewRow.Cells("VHID").Value
                    .VHDetailCostCodeID = DataGridViewRow.Cells("VHDetailCostCodeID").Value
                Else
                    .VHID = ""
                    .VHDetailCostCodeID = ""
                End If
            End With

            ds = PettyCashPaymentBOL.savePettyCashPayment(ObjPettyCashPaymentPPT)


        Next
        If ds Is Nothing Then
            DisplayInfoMessage("Msg20")
            '' MsgBox("Failed to save database")
        Else
            Clear()
            clearVoucherNoGroupBox()
            BindDataGrid()
            ClearGridView(DgvMultipleEntry)
            DisplayInfoMessage("Msg21")
            ''MsgBox("Data(s) Successfully Saved!")
            GlobalPPT.IsRetainFocus = False
        End If
    End Sub

    Private Sub UpdateRecords()


        Dim ds As New DataSet

        For Each DataGridViewRow In DgvMultipleEntry.Rows
            Dim ObjPettyCashPaymentPPT As New PettyCashPaymentPPT
            Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL

            With ObjPettyCashPaymentPPT
                .PaymentID = DataGridViewRow.Cells("dgmePaymentID").Value.ToString()
                .VoucherNo = Me.txtVoucherNo.Text.Trim
                .VoucherDate = Me.dtpVoucherDate.Value
                .PayToID = CbPayTo.SelectedValue.ToString()
                .PaidTo = Me.txtPaidTo.Text.Trim
                .PayDescp = Me.txtDescp.Text.Trim
                If cbDiscrepancytransaction.Checked = True Then
                    .DiscrepancyTransaction = "Y"
                Else
                    .DiscrepancyTransaction = "N"
                End If
                .COAID = DataGridViewRow.Cells("dgmeCOAID").Value.ToString()
                .T0 = DataGridViewRow.Cells("dgmeT0").Value.ToString()
                .T1 = DataGridViewRow.Cells("dgmeT1").Value.ToString()
                .T2 = DataGridViewRow.Cells("dgmeT2").Value.ToString()
                .T3 = DataGridViewRow.Cells("dgmeT3").Value.ToString()
                .T4 = DataGridViewRow.Cells("dgmeT4").Value.ToString()
                .Amount = DataGridViewRow.Cells("dgmeAmount").Value.ToString()
                .Remarks = DataGridViewRow.Cells("dgmeRemarks").Value.ToString()
                .UOMID = DataGridViewRow.Cells("dgmeUOMID").Value.ToString()
                If DataGridViewRow.Cells("dgmeQty").Value.ToString() <> "" Then
                    .Qty = DataGridViewRow.Cells("dgmeQty").Value.ToString()
                End If
                .Approved = "N"
                .RejectedReason = String.Empty
                .ApprovalDate = "1900/01/01"
                .DC = DataGridViewRow.Cells("DgMeTransactionType").Value.ToString()
                If Not IsDBNull(DataGridViewRow.Cells("VHID").Value) Then
                    .VHID = DataGridViewRow.Cells("VHID").Value.ToString()
                    .VHDetailCostCodeID = DataGridViewRow.Cells("VHDetailCostCodeID").Value.ToString()
                Else
                    .VHID = ""
                    .VHDetailCostCodeID = ""
                End If
            End With

            If DataGridViewRow.Cells("dgmePaymentID").Value.ToString() = String.Empty Then
                ds = PettyCashPaymentBOL.savePettyCashPayment(ObjPettyCashPaymentPPT)
            Else
                ds = ObjPettyCashPaymentBOL.UpdatePettyCashPayment(ObjPettyCashPaymentPPT, "NO")
            End If


        Next

        If ds Is Nothing Then
            DisplayInfoMessage("Msg22")
            ''MsgBox("Failed to save database")

        Else
            DeleteMultiEntryRecords()
            Clear()
            clearVoucherNoGroupBox()
            BindDataGrid()
            ClearGridView(DgvMultipleEntry)
            DisplayInfoMessage("Msg23")
            ''MsgBox("Data(s) Successfully Updated!")
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            Else
                btnAdd.Text = "Menambahkan"
            End If

            lbtnAdd = "Add"
            GlobalPPT.IsRetainFocus = False
            'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If

    End Sub

    Private Function AccountCodeExist(ByVal AccountCode As String) As Boolean
        'Sai Overide
        'Try
        '    Dim objDataGridViewRow As New DataGridViewRow
        '    For Each objDataGridViewRow In DgvMultipleEntry.Rows
        '        If AccountCode = objDataGridViewRow.Cells("DgMeAccountCode").Value.ToString() Then
        '            txtAccountCode.Text = String.Empty
        '            lblAccountDescp.Text = String.Empty
        '            lblOldAccountCode.Text = String.Empty
        '            txtAccountCode.Focus()
        '            Return True
        '        End If
        '    Next
        '    Return False
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message())
        'End Try
        Return False

    End Function

    Private Sub AddMultipleEntryData()

        Dim intRowcount As Integer = dtPCP.Rows.Count
        Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
        Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
        Dim objCheckDuplicateRecord As Object = 0
        objPettyCashPaymentPPT.COACode = Me.txtAccountCode.Text.Trim
        Try
            If grpVoucherNo.Enabled = True Then
                With objPettyCashPaymentPPT
                    .VoucherNo = Me.txtVoucherNo.Text
                End With

                objCheckDuplicateRecord = ObjPettyCashPaymentBOL.DuplicatePettycashPaymentCheck(objPettyCashPaymentPPT)
                If (objCheckDuplicateRecord = 0) Then
                    DisplayInfoMessage("Msg24")
                    ''MessageBox.Show("Voucher No Already Exists ! Please enter different voucher no")
                    Exit Sub
                End If
            End If


            If Me.txtAccountCode.Text = "" Then
                DisplayInfoMessage("Msg25")
                ''MessageBox.Show("Account Code Required", "Account Code")
                txtAccountCode.Focus()
                Exit Sub
            End If
            If Val(Me.txtAmount.Text) = 0 Then
                DisplayInfoMessage("Msg26")
                ''MessageBox.Show("Amount Required", "Amount")
                txtAmount.Focus()
                Exit Sub
            End If
            If txtQty.Text <> String.Empty And txtUOM.Text = String.Empty Then
                DisplayInfoMessage("Msg27")
                ''MsgBox("Unit Field is Required")
                txtUOM.Focus()
                Exit Sub
            End If


            If Not AccountCodeExist(objPettyCashPaymentPPT.COACode) Then
                rowMultipleEntryAdd = dtPCP.NewRow()
                If intRowcount = 0 And lbtnAdd = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnPCPAdd = New DataColumn("PaymentID", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("COACode", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisCode0", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisCode1", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisCode2", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisCode3", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisCode4", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("T0", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("T1", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("T2", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("T3", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("T4", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisDescp0", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisDescp1", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisDescp2", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisDescp3", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("TAnalysisDescp4", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("Amount", System.Type.[GetType]("System.Decimal"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("Qty", System.Type.[GetType]("System.Decimal"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("Remarks", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("UOM", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("UOMID", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("UOMDescp", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("Transactiontype", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("VHID", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("VHDetailCostCodeID", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("VHWSCode", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)
                        columnPCPAdd = New DataColumn("VHDetailCostCode", System.Type.[GetType]("System.String"))
                        dtPCP.Columns.Add(columnPCPAdd)

                        rowMultipleEntryAdd("PaymentID") = lPaymentID
                        rowMultipleEntryAdd("COACode") = txtAccountCode.Text.Trim()
                        rowMultipleEntryAdd("OldCOACode") = lblOldAccountCode.Text.Trim
                        rowMultipleEntryAdd("COAID") = lCOAID
                        rowMultipleEntryAdd("COADescp") = lblAccountDescp.Text.Trim()

                        rowMultipleEntryAdd("TAnalysisCode0") = txtT0.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode1") = txtT1.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode2") = txtT2.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode3") = txtT3.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode4") = txtT4.Text.Trim()


                        rowMultipleEntryAdd("T0") = psT0analysisID
                        rowMultipleEntryAdd("T1") = psT1analysisID
                        rowMultipleEntryAdd("T2") = psT2analysisID
                        rowMultipleEntryAdd("T3") = psT3analysisID
                        rowMultipleEntryAdd("T4") = psT4analysisID


                        rowMultipleEntryAdd("TAnalysisDescp0") = lblT0Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp1") = lblT1Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp2") = lblT2Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp3") = lblT3Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp4") = lblT4Name.Text.Trim()

                        rowMultipleEntryAdd("UOMID") = psUOMID
                        rowMultipleEntryAdd("UOMDescp") = lblUOMDescp.Text.Trim()
                        rowMultipleEntryAdd("UOM") = txtUOM.Text.Trim()

                        rowMultipleEntryAdd("Amount") = txtAmount.Text
                        If txtQty.Text <> String.Empty Then
                            rowMultipleEntryAdd("Qty") = txtQty.Text.Trim()
                        End If
                        rowMultipleEntryAdd("Remarks") = txtRemarks.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp4") = lblT4Name.Text.Trim()
                        If psVHID <> "" Then
                            rowMultipleEntryAdd("VHID") = psVHID
                            rowMultipleEntryAdd("VHDetailCostCodeID") = psVHDetailCostCodeID
                            rowMultipleEntryAdd("VHWSCode") = Me.txtVehicleCode.Text
                            rowMultipleEntryAdd("VHDetailCostCode") = Me.txtDetailCostCode.Text
                        End If
                        rowMultipleEntryAdd("Transactiontype") = ddlTranscationType.Text

                        dtPCP.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                        ' dtAddFlag = True
                        DgvMultipleEntry.AutoGenerateColumns = False
                        grpVoucherNo.Enabled = False
                    Catch ex As Exception
                        rowMultipleEntryAdd("PaymentID") = lPaymentID
                        rowMultipleEntryAdd("COACode") = txtAccountCode.Text.Trim()
                        rowMultipleEntryAdd("OldCOACode") = lblOldAccountCode.Text.Trim
                        rowMultipleEntryAdd("COAID") = lCOAID
                        rowMultipleEntryAdd("COADescp") = lblAccountDescp.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode0") = txtT0.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode1") = txtT1.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode2") = txtT2.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode3") = txtT3.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisCode4") = txtT4.Text.Trim()

                        rowMultipleEntryAdd("T0") = psT0analysisID
                        rowMultipleEntryAdd("T1") = psT1analysisID
                        rowMultipleEntryAdd("T2") = psT2analysisID
                        rowMultipleEntryAdd("T3") = psT3analysisID
                        rowMultipleEntryAdd("T4") = psT4analysisID

                        rowMultipleEntryAdd("TAnalysisDescp0") = lblT0Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp1") = lblT1Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp2") = lblT2Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp3") = lblT3Name.Text.Trim()
                        rowMultipleEntryAdd("TAnalysisDescp4") = lblT4Name.Text.Trim()

                        rowMultipleEntryAdd("UOMID") = psUOMID
                        rowMultipleEntryAdd("UOMDescp") = lblUOMDescp.Text.Trim()
                        rowMultipleEntryAdd("UOM") = txtUOM.Text.Trim()


                        rowMultipleEntryAdd("Amount") = txtAmount.Text
                        If txtQty.Text <> String.Empty Then
                            rowMultipleEntryAdd("Qty") = txtQty.Text.Trim()
                        End If
                        rowMultipleEntryAdd("Remarks") = txtRemarks.Text.Trim()
                        rowMultipleEntryAdd("Transactiontype") = ddlTranscationType.Text
                        If psVHID <> "" Then
                            rowMultipleEntryAdd("VHID") = psVHID
                            rowMultipleEntryAdd("VHDetailCostCodeID") = psVHDetailCostCodeID
                            rowMultipleEntryAdd("VHWSCode") = Me.txtVehicleCode.Text
                            rowMultipleEntryAdd("VHDetailCostCode") = Me.txtDetailCostCode.Text
                        End If
                        dtPCP.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                        ' dtAddFlag = True
                        grpVoucherNo.Enabled = False
                        DgvMultipleEntry.AutoGenerateColumns = False
                    End Try

                Else
                    rowMultipleEntryAdd("PaymentID") = lPaymentID
                    rowMultipleEntryAdd("COACode") = txtAccountCode.Text.Trim()
                    rowMultipleEntryAdd("OldCOACode") = lblOldAccountCode.Text.Trim
                    rowMultipleEntryAdd("COAID") = lCOAID
                    rowMultipleEntryAdd("COADescp") = lblAccountDescp.Text.Trim()

                    rowMultipleEntryAdd("TAnalysisCode0") = txtT0.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisCode1") = txtT1.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisCode2") = txtT2.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisCode3") = txtT3.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisCode4") = txtT4.Text.Trim()

                    rowMultipleEntryAdd("T0") = psT0analysisID
                    rowMultipleEntryAdd("T1") = psT1analysisID
                    rowMultipleEntryAdd("T2") = psT2analysisID
                    rowMultipleEntryAdd("T3") = psT3analysisID
                    rowMultipleEntryAdd("T4") = psT4analysisID

                    rowMultipleEntryAdd("TAnalysisDescp0") = lblT0Name.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisDescp1") = lblT1Name.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisDescp2") = lblT2Name.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisDescp3") = lblT3Name.Text.Trim()
                    rowMultipleEntryAdd("TAnalysisDescp4") = lblT4Name.Text.Trim()

                    rowMultipleEntryAdd("Amount") = txtAmount.Text

                    If txtQty.Text <> String.Empty Then
                        rowMultipleEntryAdd("Qty") = txtQty.Text.Trim()
                    End If
                    rowMultipleEntryAdd("UOMID") = psUOMID
                    rowMultipleEntryAdd("UOMDescp") = lblUOMDescp.Text.Trim()
                    rowMultipleEntryAdd("UOM") = txtUOM.Text.Trim()

                    rowMultipleEntryAdd("Remarks") = txtRemarks.Text.Trim()
                    rowMultipleEntryAdd("Transactiontype") = ddlTranscationType.Text
                    If psVHID <> "" Then
                        rowMultipleEntryAdd("VHID") = psVHID
                        rowMultipleEntryAdd("VHDetailCostCodeID") = psVHDetailCostCodeID
                        rowMultipleEntryAdd("VHWSCode") = Me.txtVehicleCode.Text
                        rowMultipleEntryAdd("VHDetailCostCode") = Me.txtDetailCostCode.Text
                    End If
                    dtPCP.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                    grpVoucherNo.Enabled = False
                    DgvMultipleEntry.AutoGenerateColumns = False

                End If

                DgvMultipleEntry.DataSource = dtPCP
                DgvMultipleEntry.AutoGenerateColumns = False
                Clear()
            Else
                DisplayInfoMessage("Msg28")
                ''MsgBox("The Account Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub UpdateMultipleDataEntryValue()

        Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
        Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
        objPettyCashPaymentPPT.COACode = Me.txtAccountCode.Text.Trim

        If Me.txtAccountCode.Text = "" Then
            DisplayInfoMessage("Msg25")
            ''MessageBox.Show("Account Code Required", "Account Code")
            txtAccountCode.Focus()
            Exit Sub
        End If
        If Me.txtAmount.Text = "" Then
            DisplayInfoMessage("Msg26")
            ''MessageBox.Show("Amount Required", "Amount")
            txtAmount.Focus()
            Exit Sub
        End If
        If txtQty.Text <> String.Empty And txtUOM.Text = String.Empty Then
            DisplayInfoMessage("Msg27")
            ''MsgBox("Unit Field is Required")
            txtUOM.Focus()
            Exit Sub
        End If

        If lAccountCode = Me.txtAccountCode.Text.Trim Then
            Dim intCount As Integer = DgvMultipleEntry.CurrentRow.Index
            DgvMultipleEntry.Rows(intCount).Cells("dgMePaymentID").Value = lPaymentID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeAccountCode").Value = txtAccountCode.Text
            DgvMultipleEntry.Rows(intCount).Cells("dgmeOldCOACode").Value = lblOldAccountCode.Text
            DgvMultipleEntry.Rows(intCount).Cells("dgmeCOAID").Value = lCOAID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeAccountDescp").Value = lblAccountDescp.Text

            DgvMultipleEntry.Rows(intCount).Cells("dgMeT0").Value = psT0analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT1").Value = psT1analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT2").Value = psT2analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT3").Value = psT3analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT4").Value = psT4analysisID

            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode0").Value = txtT0.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode1").Value = txtT1.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode2").Value = txtT2.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode3").Value = txtT3.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode4").Value = txtT4.Text

            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp0").Value = lblT0Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp1").Value = lblT1Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp2").Value = lblT2Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp3").Value = lblT3Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp4").Value = lblT4Name.Text


            DgvMultipleEntry.Rows(intCount).Cells("DgMeAmount").Value = txtAmount.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeUOMID").Value = psUOMID
            DgvMultipleEntry.Rows(intCount).Cells("DgMeUOMDescp").Value = lblUOMDescp.Text.Trim()
            DgvMultipleEntry.Rows(intCount).Cells("DgMeUOM").Value = txtUOM.Text.Trim()


            If txtQty.Text <> String.Empty Then
                DgvMultipleEntry.Rows(intCount).Cells("dgMeQty").Value = txtQty.Text
            Else
                DgvMultipleEntry.Rows(intCount).Cells("dgMeQty").Value = DBNull.Value
            End If
            DgvMultipleEntry.Rows(intCount).Cells("DgMeRemarks").Value = txtRemarks.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTransactionType").Value = ddlTranscationType.Text
            If psVHID <> "" Then
                DgvMultipleEntry.Rows(intCount).Cells("VHID").Value = psVHID
                DgvMultipleEntry.Rows(intCount).Cells("VHDetailCostCodeID").Value = psVHDetailCostCodeID
                DgvMultipleEntry.Rows(intCount).Cells("VHWSCode").Value = Me.txtVehicleCode.Text
                DgvMultipleEntry.Rows(intCount).Cells("VHDetailCostCode").Value = Me.txtDetailCostCode.Text
            End If

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            Else
                btnAdd.Text = "Menambahkan"
            End If


            lbtnAdd = "Add"
            txtAccountCode.Text = String.Empty
            Clear()

            'If GlobalPPT.strLang = "en" Then
            '    btnSave.Text = "Update All"
            'Else
            '    Me.btnSave.Text = "Update Semua"
            'End If

            'btnAddFlag = True
            DgvMultipleEntry.AutoGenerateColumns = False
        ElseIf Not AccountCodeExist(objPettyCashPaymentPPT.COACode) Then
            Dim intCount As Integer = DgvMultipleEntry.CurrentRow.Index
            DgvMultipleEntry.Rows(intCount).Cells("dgMePaymentID").Value = lPaymentID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeAccountCode").Value = txtAccountCode.Text
            DgvMultipleEntry.Rows(intCount).Cells("dgmeOldCOACode").Value = lblOldAccountCode.Text
            DgvMultipleEntry.Rows(intCount).Cells("dgmeCOAID").Value = lCOAID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeAccountDescp").Value = lblAccountDescp.Text

            DgvMultipleEntry.Rows(intCount).Cells("dgMeT0").Value = psT0analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT1").Value = psT1analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT2").Value = psT2analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT3").Value = psT3analysisID
            DgvMultipleEntry.Rows(intCount).Cells("dgMeT4").Value = psT4analysisID

            DgvMultipleEntry.Rows(intCount).Cells("DgMeUOMID").Value = psUOMID
            DgvMultipleEntry.Rows(intCount).Cells("DgMeUOMDescp").Value = lblUOMDescp.Text.Trim()
            DgvMultipleEntry.Rows(intCount).Cells("DgMeUOM").Value = txtUOM.Text.Trim()

            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode0").Value = txtT0.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode1").Value = txtT1.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode2").Value = txtT2.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode3").Value = txtT3.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode4").Value = txtT4.Text

            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp0").Value = lblT0Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp1").Value = lblT1Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp2").Value = lblT2Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp3").Value = lblT3Name.Text
            DgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisDescp4").Value = lblT4Name.Text


            DgvMultipleEntry.Rows(intCount).Cells("DgMeAmount").Value = txtAmount.Text
            If txtQty.Text <> String.Empty Then
                DgvMultipleEntry.Rows(intCount).Cells("dgMeQty").Value = txtQty.Text
            End If
            DgvMultipleEntry.Rows(intCount).Cells("DgMeRemarks").Value = txtRemarks.Text
            If psVHID <> "" Then
                DgvMultipleEntry.Rows(intCount).Cells("VHID").Value = psVHID
                DgvMultipleEntry.Rows(intCount).Cells("VHDetailCostCodeID").Value = psVHDetailCostCodeID
                DgvMultipleEntry.Rows(intCount).Cells("VHWSCode").Value = Me.txtVehicleCode.Text
                DgvMultipleEntry.Rows(intCount).Cells("VHDetailCostCode").Value = Me.txtDetailCostCode.Text
            End If

            'btnAdd.Text = "Add"
            lbtnAdd = "Add"
            txtAccountCode.Text = String.Empty
            Clear()
            'btnAddFlag = True
            DgvMultipleEntry.AutoGenerateColumns = False
        Else
            DisplayInfoMessage("Msg28")
            ''MsgBox("The Account Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
        End If
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If txtT0.Text = "" Then
            Me.txtT0.Text = GlobalPPT.strEstateCode
        End If

        If Me.lbtnAdd = "Add" Or lbtnAdd = "UpdatedtTable" Then
            If IsSaveValid() = False Then
                If IsSaveValidMultiEntry() = False Then
                    AddMultipleEntryData()
                    DgvMultipleEntry.AutoGenerateColumns = False
                End If
            Else
                Exit Sub
            End If
        Else
            If IsSaveValid() = False Then
                If IsSaveValidMultiEntry() = False Then
                    DgvMultipleEntry.AutoGenerateColumns = False
                    UpdateMultipleDataEntryValue()
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub MultipleDateEntryValues()
        If DgvMultipleEntry.Rows.Count = 1 Then


        End If


        If DgvMultipleEntry.Rows.Count > 0 Then
            grpVoucherNo.Enabled = False

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            Else
                btnAdd.Text = "Memperbarui"
            End If

            lbtnAdd = "Update"


            Me.lPaymentID = DgvMultipleEntry.SelectedRows(0).Cells("dgMePaymentID").Value.ToString

            Me.lCOAID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeCOAID").Value.ToString

            Me.txtAccountCode.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeAccountCode").Value.ToString
            lAccountCode = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeAccountCode").Value.ToString
            Me.lblAccountDescp.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeAccountDescp").Value.ToString
            Me.lblOldAccountCode.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeOldCOACode").Value.ToString
            Me.psT0analysisID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeT0").Value.ToString
            Me.psT1analysisID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeT1").Value.ToString
            Me.psT2analysisID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeT2").Value.ToString
            Me.psT3analysisID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeT3").Value.ToString
            Me.psT4analysisID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeT4").Value.ToString

            Me.txtT0.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode0").Value.ToString
            Me.txtT1.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode1").Value.ToString
            Me.txtT2.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode2").Value.ToString
            Me.txtT3.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode3").Value.ToString
            Me.txtT4.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode4").Value.ToString

            Me.lblT0Name.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp0").Value.ToString
            Me.lblT1Name.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp1").Value.ToString
            Me.lblT2Name.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp2").Value.ToString
            Me.lblT3Name.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp3").Value.ToString
            Me.lblT4Name.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp4").Value.ToString
            Me.txtAmount.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeAmount").Value
            Me.txtQty.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeQty").Value.ToString
            Me.txtRemarks.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeRemarks").Value.ToString

            Me.txtUOM.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeUOM").Value.ToString
            Me.lblUOMDescp.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeUOMDescp").Value.ToString
            psUOMID = Me.DgvMultipleEntry.SelectedRows(0).Cells("dgMeUOMID").Value.ToString
            Me.ddlTranscationType.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("DgMeTransactionType").Value.ToString

            If Me.DgvMultipleEntry.SelectedRows(0).Cells("VHID").Value.ToString <> "" And Not IsDBNull(Me.DgvMultipleEntry.SelectedRows(0).Cells("VHID").Value) Then
                psVHID = Me.DgvMultipleEntry.SelectedRows(0).Cells("VHID").Value
                psVHDetailCostCodeID = Me.DgvMultipleEntry.SelectedRows(0).Cells("VHDetailCostCodeID").Value
                Me.txtVehicleCode.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("VHWSCode").Value
                Me.txtDetailCostCode.Text = Me.DgvMultipleEntry.SelectedRows(0).Cells("VHDetailCostCode").Value
            Else
                psVHID = ""
                psVHDetailCostCodeID = ""
                Me.txtVehicleCode.Text = ""
                Me.txtDetailCostCode.Text = ""
            End If

            ' dtAddFlag = True
        Else
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub
    Private Sub btnResetMultipleEntryGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMultipleEntryGrp.Click
        Clear()
        '  BindMultipleEntryDataGrid()

    End Sub

    Private Sub BindMultipleEntryDataGrid()
        Try
            Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
            Dim objPettyCashPaymentBOL As New PettyCashPaymentBOL


            With objPettyCashPaymentPPT
                Dim mdiparent As New MDIParent

                If mdiparent.strMenuID = "M110" Then
                    .VoucherNo = AccountApprovalFrm.ApprovalVoucherNo
                Else
                    .VoucherNo = Me.txtVoucherNo.Text
                End If

            End With

            dtPCP = objPettyCashPaymentBOL.GetValueMultipleEntry(objPettyCashPaymentPPT)
            If dtPCP.Rows.Count <> 0 Then

                DgvMultipleEntry.AutoGenerateColumns = False
                Me.DgvMultipleEntry.DataSource = dtPCP
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If lbtnSave = "Save All" Then
    '        If IsSaveValid() Then Exit Sub
    '        If DgvMultipleEntry.Rows.Count = 0 Then
    '            MessageBox.Show(" Please Add Account Code", "Account code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Exit Sub
    '        ElseIf Me.lbtnSave = "Save All" Then
    '            SaveDatas()
    '        End If
    '    Else
    '        UpdateRecords()
    '    End If

    'End Sub

    'Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
    '    clearVoucherNoGroupBox()
    '    Clear()
    '    BindDataGrid()
    '    ClearGridView(DgvMultipleEntry)
    '    lbtnAdd = "UpdatedtTable"
    'End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Clear()
        txtAccountCode.Focus()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MultipleDateEntryValues()
    End Sub

    Private Sub DgvMultipleEntry_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMultipleEntry.CellDoubleClick
        MultipleDateEntryValues()

    End Sub

    Private Sub DgvMultipleEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvMultipleEntry.KeyDown
        If e.KeyCode = Keys.Return Then
            MultipleDateEntryValues()
            e.Handled = True
        End If
    End Sub


    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
    '        Me.Close()
    '    End If

    'End Sub

    Private Sub PettyCashPaymentFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim addCreditAmount, addDebitAmount As Decimal
        addCreditAmount = 0
        addDebitAmount = 0


        If lbtnSave = "Save All" Then
            If IsSaveValid() Then Exit Sub

            If DgvMultipleEntry.Rows.Count = 0 Then
                DisplayInfoMessage("Msg29")
                ''MessageBox.Show(" Please Add Account Code", "Account code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            ElseIf Me.lbtnSave = "Save All" Then
                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If
                Dim objDataGridViewRow As New DataGridViewRow
                For Each objDataGridViewRow In DgvMultipleEntry.Rows
                    If objDataGridViewRow.Cells("DgMeTransactionType").Value.ToString() = "Debit" Then
                        addDebitAmount = addDebitAmount + Val(objDataGridViewRow.Cells("DgMeAmount").Value.ToString())
                    End If


                    If objDataGridViewRow.Cells("DgMeTransactionType").Value.ToString() = "Credit" Then
                        addCreditAmount = addCreditAmount + Val(objDataGridViewRow.Cells("DgMeAmount").Value.ToString())
                    End If
                Next

                If addCreditAmount > addDebitAmount Or addCreditAmount = addDebitAmount Then
                    DisplayInfoMessage("Msg310")
                    Exit Sub
                End If
                
                SaveDatas()
            End If
        Else
            If IsSaveValid() Then Exit Sub
            If DgvMultipleEntry.Rows.Count = 0 Then
                DisplayInfoMessage("Msg29")
                Exit Sub
            Else
                Dim objDataGridViewRow As New DataGridViewRow
                For Each objDataGridViewRow In DgvMultipleEntry.Rows
                    If objDataGridViewRow.Cells("DgMeTransactionType").Value.ToString() = "Debit" Then
                        addDebitAmount = addDebitAmount + Val(objDataGridViewRow.Cells("DgMeAmount").Value.ToString())
                    End If
                    If objDataGridViewRow.Cells("DgMeTransactionType").Value.ToString() = "Credit" Then
                        addCreditAmount = addCreditAmount + Val(objDataGridViewRow.Cells("DgMeAmount").Value.ToString())
                    End If
                Next

                If addCreditAmount > addDebitAmount Then
                    DisplayInfoMessage("Msg310")
                    Exit Sub
                End If

                UpdateRecords()
            End If
        End If


    End Sub


    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
        clearVoucherNoGroupBox()
        Clear()
        BindDataGrid()
        ClearGridView(DgvMultipleEntry)
        lbtnAdd = "UpdatedtTable"

        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If btnSave.Visible = False Then
        '    Me.Close()
        '    'ElseIf MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '    Me.Close()



        If btnSave.Enabled = True And DgvMultipleEntry.RowCount > 0 And btnSave.Visible = True Then
            If MsgBox(rm.GetString("Msg30"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsRetainFocus = True
                GlobalPPT.IsButtonClose = False
            End If

        Else
            Me.Close()


        End If



        'End If










    End Sub


    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim ObjRecordExist As New DataTable
        Dim ObjPCPPPT As New PettyCashPaymentPPT
        Dim ObjPCPBOL As New PettyCashPaymentBOL
        ObjPCPPPT.lVoucherDate = "01/01/1900"
        ObjPCPPPT.Approved = "S"
        ObjRecordExist = ObjPCPBOL.GetPettyCashPayment(ObjPCPPPT)
        If ObjRecordExist.Rows.Count = 0 Then
            DisplayInfoMessage("Msg31")
            ''MsgBox("No Record(s) Available!")
        Else

            StrFrmName = "PCP"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If
    End Sub

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click

        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerSetupfrm))
        If MsgBox(rm.GetString("Msg39"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            ''If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            If cmbStatus.Text = "APPROVED" Then
                ApprovalDetails()
            ElseIf cmbStatus.Text = "REJECTED" Then
                If txtRejectedReason.Text.Trim = String.Empty Then
                    DisplayInfoMessage("Msg32")
                    ''MsgBox("Please Key in the Rejected Reason!")
                    txtRejectedReason.Focus()
                    Exit Sub
                End If

                Dim objPettyCashPPT As New PettyCashPaymentPPT
                Dim objpettyCashBOL As New PettyCashPaymentBOL

                With objPettyCashPPT
                    .VoucherNo = txtVoucherNo.Text
                    .Approved = "N"
                    .RejectedReason = txtRejectedReason.Text.Trim
                    .VoucherDate = dtpVoucherDate.Value
                    .ApprovalDate = dtpVoucherDate.Value
                End With
                objpettyCashBOL.UpdatePettyCashPayment(objPettyCashPPT, "YES")
                DisplayInfoMessage("Msg33")
                '' MsgBox("Record Rejected Successfully")



                Close()
                Exit Sub

            End If
        End If
    End Sub

    Private Sub ApprovalDetails()
        Dim addCreditAmount As Decimal = 0, addDebitAmount1 As Decimal = 0

        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In DgvMultipleEntry.Rows
                If objDataGridViewRow.Cells("DgMeTransactionType").Value.ToString() = "Debit" Then
                    addDebitAmount1 = addDebitAmount1 + Val(objDataGridViewRow.Cells("DgMeAmount").Value.ToString())
                Else
                    addCreditAmount = addCreditAmount + Val(objDataGridViewRow.Cells("DgMeAmount").Value.ToString())
                End If
            Next
            addDebitAmount1 = addDebitAmount1 - addCreditAmount
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

        Try
            'Update PCP Table Status
            Dim ObjPettyCashPaymentPPT As New PettyCashPaymentPPT
            Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
            Dim dsAmountcheck As New DataSet

            dsAmountcheck = ObjPettyCashPaymentBOL.PettyCashPaymentAmountCheck(ObjPettyCashPaymentPPT)

            Dim lCalculatedAmount As Integer

            lCalculatedAmount = dsAmountcheck.Tables(0).Rows(0).Item("CalculatedPCPAmount").ToString

            lCalculatedAmount = lCalculatedAmount - addDebitAmount1

            If lCalculatedAmount < 0 Then
                DisplayInfoMessage("Msg34")
                ''MessageBox.Show("Unable to approve,Petty cash Payment Amount is greater than available Petty Cash Amount")
                Exit Sub
            End If


            Dim ds As New DataSet
            'For Each DataGridViewRow In DgvMultipleEntry.Rows
            With ObjPettyCashPaymentPPT
                .VoucherDate = Me.dtpVoucherDate.Value
                .VoucherNo = Me.txtVoucherNo.Text
                .Approved = "Y"
                .ApprovalDate = dtpApprovalDate.Value
            End With
            ds = ObjPettyCashPaymentBOL.UpdatePettyCashPayment(ObjPettyCashPaymentPPT, "YES")
            ' Next
            DisplayInfoMessage("Msg35")
            ''MessageBox.Show("Approved Successfully")
            Close()

        Catch ex As Exception
            DisplayInfoMessage("Msg36")
            ''MsgBox("Transaction  Failed")
            Exit Sub
        End Try


        Try

            ''Step 2 Accounts.Ledgerallmodule insert 
            Dim ObjPCRPPT As New AccountsApprovalPPT
            Dim ObjPCRBOL As New AccountsApprovalBOL

            ObjPCRPPT.AYear = GlobalPPT.intActiveYear
            ObjPCRPPT.Amonth = GlobalPPT.IntActiveMonth
            ObjPCRPPT.LedgerDate = dtpVoucherDate.Value
            ObjPCRPPT.LedgerType = "PCP"
            ObjPCRPPT.JournalDescp = txtDescp.Text.Trim
            ObjPCRPPT.BatchTotal = "0.00"
            ObjPCRPPT.LedgerNo = txtVoucherNo.Text

            Dim dsRowsAffectedLedgerAllModule As New DataSet
            dsRowsAffectedLedgerAllModule = ObjPCRBOL.JournalLedgerAllModuleInsert(ObjPCRPPT)
            psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
            ObjPCRPPT.LedgerID = psLedgerID
            ' MessageBox.Show("Approved Successfully")
        Catch ex As Exception
            DisplayInfoMessage("Msg36")
            ''MsgBox("Transaction Failed")
            Exit Sub
        End Try

        ''Step 3 Accounts AccountsApprovalDetail Insert


        Dim AddDebitAmount As Decimal = 0

        Try
            addCreditAmount = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In DgvMultipleEntry.Rows

                If objDataGridViewRow.Cells("dgMeTransactionType").Value.ToString() = "Debit" Then
                    addCreditAmount = addCreditAmount + Val(objDataGridViewRow.Cells("dgMeAmount").Value.ToString())
                End If

                If objDataGridViewRow.Cells("dgMeTransactionType").Value.ToString() = "Credit" Then
                    AddDebitAmount = AddDebitAmount + Val(objDataGridViewRow.Cells("dgMeAmount").Value.ToString())
                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

        addCreditAmount = addCreditAmount - AddDebitAmount

        'Vehicle Charge Insert
        Try

            Dim GridViewRow As DataGridViewRow
            For Each GridViewRow In DgvMultipleEntry.Rows
                If GridViewRow.Cells("VHID").Value.ToString() <> String.Empty Then
                    Dim ObjjournalPPT As New JournalPPT
                    Dim ObjjournalBOL As New JournalBOL
                    With ObjjournalPPT

                        .VHWScode = GridViewRow.Cells("VHWSCode").Value.ToString()

                        Dim dsEstCode As New DataSet
                        dsEstCode = ObjjournalBOL.VHChargedetailLocationEstateCodeSelect(ObjjournalPPT)

                        If dsEstCode.Tables(0).Rows.Count = 0 Then
                            .EstateCodeL = GlobalPPT.strEstateIDCode
                        Else
                            .EstateCodeL = dsEstCode.Tables(0).Rows(0).Item("LocEstateCode").ToString
                        End If

                        .VHDetailCostCode = GridViewRow.Cells("VHDetailCostCode").Value.ToString()
                        '.Type = GridViewRow.Cells("dgmeVHType").Value.ToString()
                        .Type = "V"
                        .AYear = GlobalPPT.intActiveYear
                        .Amonth = GlobalPPT.IntActiveMonth
                        .LedgerType = "PETTYCASH"
                        .LedgerNo = "PC" & Format(Now, "MMddyyyyhhmmss")
                        .COAID = GridViewRow.Cells("DgMeCOAID").Value.ToString()
                        'If GridViewRow.Cells("DgMeTransactionType").Value.ToString() = "Credit" Then
                        '    .Value = -(GridViewRow.Cells("DgMeCredit").Value.ToString())
                        'Else
                        '    .Value = GridViewRow.Cells("DgMeDebit").Value.ToString()
                        'End If
                        .JournalDescp = GridViewRow.Cells("DgMeremarks").Value.ToString()
                        If Not IsDBNull(GridViewRow.Cells("DgMeAmount").Value) Then .Value = GridViewRow.Cells("DgMeAmount").Value.ToString() Else .Value = 0
                        If Not IsDBNull(GridViewRow.Cells("DgMeQty").Value) Then .Qty = GridViewRow.Cells("DgMeQty").Value.ToString()
                        If Not IsDBNull(GridViewRow.Cells("DgMeUOMDescp").Value) Then .UOMID = GridViewRow.Cells("DgMeUOMDescp").Value.ToString()
                        .RefNo = Me.txtVoucherNo.Text
                    End With
                    Dim IntVHChargeDetail As New Integer
                    IntVHChargeDetail = JournalBOL.AccountsVHChargeDetailInsert(ObjjournalPPT)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

        Try
            Dim dt As New DataTable
            Dim ObjPCR As New AccountsApprovalPPT
            Dim ObjPCRBOLApp As New AccountsApprovalBOL
            dt = ObjPCRBOLApp.GetPettyCashReceiptCOAID(ObjPCR)

            Dim PettyCashCOAID As String = String.Empty
            Dim SamarindaCOAID As String = String.Empty

            If dt.Rows.Count <> 0 And dt IsNot Nothing And dt.Rows(0).Item("PettyCashCOAID").ToString <> String.Empty Then

                PettyCashCOAID = dt.Rows(0).Item("PettyCashCOAID")
                ' SamarindaCOAID = dt.Rows(0).Item("SamarindaCOAID")

                Dim ObjAccountsApprovalPPT1 As New AccountsApprovalPPT
                Dim ObjAccountsApprovalBOL1 As New AccountsApprovalBOL
                With ObjAccountsApprovalPPT1
                    .AYear = GlobalPPT.intActiveYear
                    .Amonth = GlobalPPT.IntActiveMonth
                    .LedgerID = psLedgerID
                    .COAID = PettyCashCOAID
                    .DC = "C"
                    .Flag = "PCP Price"
                    .Value = addCreditAmount
                    .COADescp = "Petty Cash"
                    .DivID = ""
                    .YOPID = ""
                    .BlockID = ""
                    .VHID = ""
                    .VHDetailcostCodeID = ""
                    .T0 = dt.Rows(0).Item("T0PC")
                    .T1 = dt.Rows(0).Item("T1PC")
                    .T2 = dt.Rows(0).Item("T2PC")
                    .T3 = dt.Rows(0).Item("T3PC")
                    .T4 = dt.Rows(0).Item("T4PC")
                    .StationID = ""
                End With
                Dim IntAccountsApprovalDetail1 As New Integer
                IntAccountsApprovalDetail1 = AccountsApprovalBOL.AccountsJournalDetailInsert(ObjAccountsApprovalPPT1)

            End If

            Dim intAccountsApprovalRowsAffected As Integer = 0
            For Each GridViewRow In DgvMultipleEntry.Rows
                If GridViewRow.Cells("dgMeCOAID").Value.ToString() <> String.Empty Then
                    Dim ObjAccountsApprovalPPT As New AccountsApprovalPPT
                    Dim ObjAccountsApprovalBOL As New AccountsApprovalBOL
                    With ObjAccountsApprovalPPT
                        .AYear = GlobalPPT.intActiveYear
                        .Amonth = GlobalPPT.IntActiveMonth
                        .LedgerID = psLedgerID
                        .COAID = GridViewRow.Cells("dgMeCOAID").Value.ToString()
                        .DC = GridViewRow.Cells("dgMeTransactionType").Value.ToString()
                        .Value = GridViewRow.cells("DgMeAmount").value.ToString()
                        .Flag = "PCP Price"
                        .COADescp = GridViewRow.Cells("DgMeremarks").Value.ToString()
                        .DivID = ""
                        .YOPID = ""
                        .BlockID = ""
                        .VHID = ""
                        .VHDetailcostCodeID = ""
                        .T0 = GridViewRow.Cells("dgMeT0").Value.ToString()
                        .T1 = GridViewRow.Cells("dgMeT1").Value.ToString()
                        .T2 = GridViewRow.Cells("dgMeT2").Value.ToString()
                        .T3 = GridViewRow.Cells("dgMeT3").Value.ToString()
                        .T4 = GridViewRow.Cells("dgMeT4").Value.ToString()
                        .StationID = ""
                    End With
                    Dim IntAccountsApprovalDetail As New Integer
                    IntAccountsApprovalDetail = AccountsApprovalBOL.AccountsJournalDetailInsert(ObjAccountsApprovalPPT)
                End If
            Next

            
                DisplayInfoMessage("Msg37")
                '' MsgBox("Transaction Completed Successfully")

            Catch ex As Exception
                DisplayInfoMessage("Msg36")
                ''MsgBox("Transaction Failed")
                Exit Sub
            End Try


    End Sub


    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.Text = "APPROVED" Then
            lblRejReason.Visible = False
            lblRejColon.Visible = False
            txtRejectedReason.Visible = False
        Else
            lblRejReason.Visible = True
            lblRejColon.Visible = True
            txtRejectedReason.Visible = True
        End If
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        If txtQty.Text <> String.Empty Then
            txtUOM.Enabled = True
            btnUOM.Enabled = True
            lblUnit.ForeColor = Color.Red
        Else
            txtUOM.Enabled = False
            btnUOM.Enabled = False
            txtUOM.Text = ""
            lblUOMDescp.Text = ""
            lblUnit.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btnUOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUOM.Click
        Cursor = Cursors.WaitCursor
        Dim frmUOMLookup As New UOMLookup
        frmUOMLookup.ShowDialog()
        If frmUOMLookup._lUOMID <> String.Empty Then
            Me.txtUOM.Text = frmUOMLookup._lUOM
            Me.lblUOMDescp.Text = frmUOMLookup._lDescp
            psUOMID = frmUOMLookup._lUOMID
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtUOM_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUOM.Leave
        If txtUOM.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjPCP As New PettyCashPaymentPPT
            ObjPCP.UOM = txtUOM.Text.Trim()
            Dim ObjPettyCashBOL As New PettyCashPaymentBOL
            ds = ObjPettyCashBOL.UOMLookupSearch(ObjPCP, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg38")
                ''MessageBox.Show("Invalid UOM,Please Choose it from look up")
                Me.lblUOMDescp.Text = String.Empty
                Me.txtUOM.Text = String.Empty
                psUOMID = String.Empty
                txtUOM.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("Description").ToString() <> String.Empty Then
                    Me.lblUOMDescp.Text = ds.Tables(0).Rows(0).Item("Description").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("UOM").ToString() <> String.Empty Then
                    Me.txtUOM.Text = ds.Tables(0).Rows(0).Item("UOM").ToString()
                End If
                psUOMID = ds.Tables(0).Rows(0).Item("UOMID").ToString()
            End If
        Else
            Me.lblUOMDescp.Text = String.Empty
            Me.txtUOM.Text = String.Empty
            psUOMID = String.Empty
        End If
    End Sub


    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        If Val(txtAmount.Text) > 0 Then
            txtAmount.Text = Format(Val(txtAmount.Text), "0")
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If DgvMultipleEntry.RowCount = 0 Then
            Exit Sub
        ElseIf DgvMultipleEntry.RowCount = 1 Then
            MsgBox(rm.GetString("msg64"), MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            If MsgBox(rm.GetString("Msg17"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
                DeleteMultientrydatagrid()
            End If
        End If

    End Sub

    Private Sub DeleteMultientrydatagrid()

        If Not DgvMultipleEntry.SelectedRows(0).Cells("DgMePaymentID").Value Is Nothing Then
            lPaymentID = DgvMultipleEntry.SelectedRows(0).Cells("DgMePaymentID").Value.ToString
        Else
            lPaymentID = String.Empty
        End If

        lDelete = 0
        If lPaymentID <> "" Then
            lDelete = DeleteMultientry.Count
            DeleteMultientry.Insert(lDelete, lPaymentID)
            lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtPCP.Rows.Item(DgvMultipleEntry.CurrentRow.Index)
        Dr.Delete()
        dtPCP.AcceptChanges()
        lPaymentID = ""
        Clear()
    End Sub

    Private Sub DeleteMultiEntryRecords()
        Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
        Dim objPettyCashPaymentBOL As New PettyCashPaymentBOL

        lDelete = DeleteMultientry.Count

        While (lDelete > 0)
            ' If GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString() <> String.Empty Then
            With objPettyCashPaymentPPT
                .PaymentID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntPCPDetailDelete As New Integer
            IntPCPDetailDelete = PettyCashPaymentBOL.DeleteMultiEntryPettyCashPayment(objPettyCashPaymentPPT)
            ' End If
            lDelete = lDelete - 1

        End While
        'ClearGridView(DgDeleteRecord)


    End Sub

    
    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        If Me.dgvPettyCashPaymentView.SelectedRows(0).Cells("dgclApproved").Value.ToString() = "APPROVED" Then
            DisplayInfoMessage("Msg16")
            Exit Sub
        End If
        If MsgBox(rm.GetString("Msg17"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            If txtVoucherNo.Enabled = False Then
                Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
                Dim objPettyCashPaymentBOL As New PettyCashPaymentBOL

                lVoucherNo = txtVoucherNo.Text.Trim
                With objPettyCashPaymentPPT
                    .VoucherNo = Me.lVoucherNo
                End With
                objPettyCashPaymentBOL.DeletePettyCashPayment(objPettyCashPaymentPPT)
                BindDataGrid()
            End If

            clearVoucherNoGroupBox()
            Clear()
            ClearGridView(DgvMultipleEntry)

        End If
        


    End Sub

    Private Sub btnSearchVehicleCode_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVehicleCode.Click
        Cursor = Cursors.WaitCursor
        Dim frmVHNoLookup As New VHNoLookup
        Dim result As DialogResult = frmVHNoLookup.ShowDialog()
        If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            psVHID = frmVHNoLookup.psVHID
            Me.txtVehicleCode.Text = frmVHNoLookup.psVHWSCode
            Me.lblVehicleDescp.Text = frmVHNoLookup.psVHDesc
            psCategoryID = frmVHNoLookup.psVHCategoryID

            If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
                If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
                    psVHCategoryType = "V"
                End If
                If frmVHNoLookup.psVHCategoryType = "Workshop" Then
                    psVHCategoryType = "W"
                End If
                If frmVHNoLookup.psVHCategoryType = "Others" Then
                    psVHCategoryType = "O"
                End If
            End If
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchVehicleDetailCostCode_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVehicleDetailCostCode.Click
        Cursor = Cursors.WaitCursor
        Dim frmVHDetailsCostCodeLookup As New VHDetailsCostCodeLookup
        frmVHDetailsCostCodeLookup.BindGrid(psVHCategoryType)
        Dim result As DialogResult = frmVHDetailsCostCodeLookup.ShowDialog()
        If frmVHDetailsCostCodeLookup.psVHDetailsCostCodeID <> String.Empty Then
            Me.txtDetailCostCode.Text = frmVHDetailsCostCodeLookup.psVHDetailsCostCode
            psVHDetailCostCodeID = frmVHDetailsCostCodeLookup.psVHDetailsCostCodeID
            lblDetailCostDescp.Text = frmVHDetailsCostCodeLookup.psVHDetailsDesc
        End If
        Cursor = Cursors.Arrow
    End Sub
End Class