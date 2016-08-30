Imports Accounts_BOL
Imports Accounts_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Math

Public Class AccountApprovalFrm

    Public Shared ApprovalVoucherNo As String
    Public Shared ApprovalLedgerNo As String
    Public Shared ApprovalReceiptNo As String
    Public psLedgerID As String = String.Empty

        Private Sub AccountApprovalFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub AccountApprovalFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        ddlTransaction.SelectedIndex = 0
        ddlLedgerType.SelectedIndex = 0
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountApprovalFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            plAccountsApproval.CaptionText = rm.GetString("plAccountsApproval.CaptionText")

            'Add Lables
            lblSelectTransaction.Text = rm.GetString("lblSelectTransaction.Text")
            lblledgerType.Text = rm.GetString("lblledgerType.Text")
            lblledgerNo.Text = rm.GetString("lblledgerNo.Text")
            cbAllRecordsTransaction.Text = rm.GetString("cbAllRecordsTransaction.Text")
            cbLedgerType.Text = rm.GetString("cbLedgerType.Text")

            'Add Datagrid Fields


            dgvJournalApproval.Columns("dgclDate").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgclDate).HeaderText")
            dgvJournalApproval.Columns("dgclLedgerType").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgclLedgerType).HeaderText")
            dgvJournalApproval.Columns("dgclLedgerNo").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgclLedgerNo).HeaderText")
            dgvJournalApproval.Columns("dgclDescription").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgclDescription).HeaderText")
            dgvJournalApproval.Columns("dgVStatus").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgVStatus).HeaderText")
            dgvJournalApproval.Columns("dgclBatchTotal").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgclBatchTotal).HeaderText")
            dgvJournalApproval.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvJournalApproval.Columns(dgclViewDetails).HeaderText")


            dgvPettyCashPayment.Columns("dgPVoucherDate").HeaderText = rm.GetString("dgvPettyCashPayment.Columns(dgPVoucherDate).HeaderText")
            dgvPettyCashPayment.Columns("dgPVoucherNo").HeaderText = rm.GetString("dgvPettyCashPayment.Columns(dgPVoucherNo).HeaderText")
            dgvPettyCashPayment.Columns("dgPPayTo").HeaderText = rm.GetString("dgvPettyCashPayment.Columns(dgPPayTo).HeaderText")
            dgvPettyCashPayment.Columns("dgPPayDescp").HeaderText = rm.GetString("dgvPettyCashPayment.Columns(dgPPayDescp).HeaderText")
            dgvPettyCashPayment.Columns("dgPStatus").HeaderText = rm.GetString("dgvPettyCashPayment.Columns(dgPStatus).HeaderText")
            dgvPettyCashPayment.Columns("DgPViewDetails").HeaderText = rm.GetString("dgvPettyCashPayment.Columns(DgPViewDetails).HeaderText")


            dgPettyCashReciept.Columns("dgPRReceiptDate").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRReceiptDate).HeaderText")
            dgPettyCashReciept.Columns("dgPRReceiptNo").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRReceiptNo).HeaderText")
            dgPettyCashReciept.Columns("dgPRCashReconcilationDate").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRCashReconcilationDate).HeaderText")
            dgPettyCashReciept.Columns("dgPRReceiptDescp").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRReceiptDescp).HeaderText")
            dgPettyCashReciept.Columns("dgPRAmount").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRAmount).HeaderText")
            dgPettyCashReciept.Columns("dgPRStatus").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRStatus).HeaderText")
            dgPettyCashReciept.Columns("dgPRViewDetails").HeaderText = rm.GetString("dgPettyCashReciept.Columns(dgPRViewDetails).HeaderText")


            dgvMultipleEntry.Columns("DgMeCOACode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeCOACode).HeaderText")
            dgvMultipleEntry.Columns("dgMeOldCOACode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeOldCOACode).HeaderText")
            dgvMultipleEntry.Columns("DgMeCOADescp").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeCOADescp).HeaderText")
            dgvMultipleEntry.Columns("dgMeDebit").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeDebit).HeaderText")
            dgvMultipleEntry.Columns("dgMeCredit").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeCredit).HeaderText")
            dgvMultipleEntry.Columns("DgMeDiv").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeDiv).HeaderText")
            dgvMultipleEntry.Columns("dgMeYOP").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeYOP).HeaderText")
            dgvMultipleEntry.Columns("DgMeSubBlock").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeSubBlock).HeaderText")
            dgvMultipleEntry.Columns("DgMeStationCode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeStationCode).HeaderText")
            dgvMultipleEntry.Columns("dgMeVHWSCode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeVHWSCode).HeaderText")
            dgvMultipleEntry.Columns("dgMeVHDetailCostCode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeVHDetailCostCode).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode0").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode0).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode1").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode1).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode2").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode2).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode3").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode3).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode4").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode4).HeaderText")

            'Add Btn Fields
            btnApproval.Text = rm.GetString("btnApproval.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnResetIB.Text = rm.GetString("btnResetIB.Text")
            btnClos.Text = rm.GetString("btnClos.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountApprovalFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub ddlTransaction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTransaction.SelectedIndexChanged
        If ddlTransaction.Text = "Journal" Then
            BindJournalDataGrid()
            LedgerType()
            ddlLedgerType.SelectedIndex = 0
            dgvJournalApproval.Visible = True
            dgvPettyCashPayment.Visible = False
            dgPettyCashReciept.Visible = False
            txtLedgerNo.Enabled = True
            btnLedgerNoSearch.Enabled = True
            ddlLedgerType.Enabled = True
            cbLedgerType.Enabled = True
            txtLedgerNo.Text = String.Empty
        ElseIf ddlTransaction.Text = "Petty Cash Payment" Then
            BindPettyPaymentDataGrid()
            dgvPettyCashPayment.Visible = True
            dgvJournalApproval.Visible = False
            dgPettyCashReciept.Visible = False
            txtLedgerNo.Enabled = False
            btnLedgerNoSearch.Enabled = False
            ddlLedgerType.Enabled = False
            cbLedgerType.Enabled = False
            txtLedgerNo.Text = String.Empty
            ddlLedgerType.SelectedIndex = -1
        Else
            BindPettyReceiptDataGrid()
            dgPettyCashReciept.Visible = True
            dgvPettyCashPayment.Visible = False
            dgvJournalApproval.Visible = False
            txtLedgerNo.Enabled = False
            btnLedgerNoSearch.Enabled = False
            ddlLedgerType.Enabled = False
            cbLedgerType.Enabled = False
            txtLedgerNo.Text = String.Empty
            ddlLedgerType.SelectedIndex = -1
        End If

        cbAllRecordsTransaction.Checked = False
        cbLedgerType.Checked = False
    End Sub
    Private Sub BindJournalDataGrid()
        Try
            Dim objJournal As New AccountsApprovalPPT
            Dim ObjJournalBL As New AccountsApprovalBOL
            Dim dt As New DataTable

            With objJournal

                If ddlLedgerType.Text <> "--Select--" Then
                    .LedgerType = Me.ddlLedgerType.Text
                End If

                .LedgerNo = Me.txtLedgerNo.Text.Trim
            End With

            dt = ObjJournalBL.ApprovalGetJournal(objJournal)
            If dt.Rows.Count <> 0 Then

                dgvJournalApproval.AutoGenerateColumns = False
                Me.dgvJournalApproval.DataSource = dt

            Else
                ClearGridView(dgvJournalApproval)

                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub BindPettyPaymentDataGrid()
        Try
            Dim objPettyPayment As New AccountsApprovalPPT
            Dim ObjPettyPaymentBL As New AccountsApprovalBOL
            Dim dt As New DataTable

            dt = ObjPettyPaymentBL.ApprovalGetPettyCashPayment(objPettyPayment)
            If dt.Rows.Count <> 0 Then

                dgvPettyCashPayment.AutoGenerateColumns = False
                Me.dgvPettyCashPayment.DataSource = dt
            Else
                ClearGridView(dgvPettyCashPayment)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub BindPettyReceiptDataGrid()
        Try
            Dim objPettyReceipt As New AccountsApprovalPPT
            Dim ObjPettyReceiptBL As New AccountsApprovalBOL
            Dim dt As New DataTable

            dt = ObjPettyReceiptBL.ApprovalGetPettyCashReceipt(objPettyReceipt)
            If dt.Rows.Count <> 0 Then

                dgPettyCashReciept.AutoGenerateColumns = False
                Me.dgPettyCashReciept.DataSource = dt

            Else
                ClearGridView(dgPettyCashReciept)

                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    

    Private Sub btnLedgerNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLedgerNoSearch.Click
        Dim frmLedgerNo As New LedgerNoLookUp
        Dim result As DialogResult = frmLedgerNo.ShowDialog()

        If frmLedgerNo.strLedgerNo <> String.Empty Then
            Me.txtLedgerNo.Text = frmLedgerNo.strLedgerNo
        End If
    End Sub

    Private Sub txtLedgerNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedgerNo.Leave
        If txtLedgerNo.Text.Trim() <> String.Empty Then
            Dim dt As New DataTable
            Dim objJournal As New AccountsApprovalPPT
            objJournal.LedgerNo = txtLedgerNo.Text.Trim()
            Dim ObjJournalBOL As New AccountsApprovalBOL
            dt = ObjJournalBOL.LedgerNoSearch(objJournal, "YES")
            If dt.Rows.Count = 0 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("Invalid Ledger No,Please Choose it from look up")
                txtLedgerNo.Text = String.Empty
                txtLedgerNo.Focus()
                Exit Sub
            Else
                txtLedgerNo.Text = dt.Rows(0).Item("LedgerNo")
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ddlTransaction.Text = "Journal" Then
            'LedgerType()
            BindJournalDataGrid()
            dgvJournalApproval.Visible = True
            dgvPettyCashPayment.Visible = False
            dgPettyCashReciept.Visible = False
            txtLedgerNo.Enabled = True
            btnLedgerNoSearch.Enabled = True
            ddlLedgerType.Enabled = True
            txtLedgerNo.Text = String.Empty
            If dgvJournalApproval.RowCount = 0 Then
                DisplayInfoMessage("Msg2")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        ElseIf ddlTransaction.Text = "Petty Cash Payment" Then
            BindPettyPaymentDataGrid()
            dgvPettyCashPayment.Visible = True
            dgvJournalApproval.Visible = False
            dgPettyCashReciept.Visible = False
            txtLedgerNo.Enabled = False
            btnLedgerNoSearch.Enabled = False
            ddlLedgerType.Enabled = False
            txtLedgerNo.Text = String.Empty
        Else
            BindPettyReceiptDataGrid()
            dgPettyCashReciept.Visible = True
            dgvPettyCashPayment.Visible = False
            dgvJournalApproval.Visible = False
            txtLedgerNo.Enabled = False
            btnLedgerNoSearch.Enabled = False
            ddlLedgerType.Enabled = False
            txtLedgerNo.Text = String.Empty
        End If
    End Sub

    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
        ddlTransaction.SelectedIndex = 0
        ddlLedgerType.SelectedIndex = 0
        txtLedgerNo.Text = ""
        cbAllRecordsTransaction.Checked = False
        cbLedgerType.Checked = False
    End Sub

    ''Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
    ''        Me.Close()
    ''    End If
    ''End Sub
    Private Sub LedgerType()

        Dim dtLedgerType As New DataTable()
        Dim objLedgerType As New AccountsApprovalPPT()
        Dim ObjLedgerTypeBOL As New AccountsApprovalBOL()
        dtLedgerType = ObjLedgerTypeBOL.GetLedgerType(objLedgerType)

        'If dtLedgerType.Rows.Count <> 0 Then
        ddlLedgerType.DataSource = dtLedgerType
        ddlLedgerType.DisplayMember = "LedgerType"
        ddlLedgerType.ValueMember = "LedgerSetupID"

        Dim intRowCount As Integer
        intRowCount = ddlLedgerType.SelectedIndex

        'If dtLedgerType IsNot Nothing And dtLedgerType.Rows.Count > 0 Then
        Dim dr As DataRow = dtLedgerType.NewRow()
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        dtLedgerType.Rows.InsertAt(dr, 0)
        ' End If

        ddlLedgerType.SelectedIndex = 0

        ' End If

    End Sub

    Private Sub dgPettyCashReciept_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPettyCashReciept.CellContentClick
        If e.ColumnIndex = 7 Then
            Dim frmPCR As New PettyCashReceiptFrm()
            ApprovalReceiptNo = dgPettyCashReciept.SelectedRows(0).Cells("dgPRReceiptNO").Value.ToString
            frmPCR.ShowDialog()
            BindPettyReceiptDataGrid()
        End If
    End Sub

    Private Sub dgvPettyCashPayment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPettyCashPayment.CellContentClick
        If e.ColumnIndex = 5 Then
            Dim frmPCP As New PettyCashPaymentFrm()
            ApprovalVoucherNo = dgvPettyCashPayment.SelectedRows(0).Cells("dgPVoucherNo").Value.ToString
            frmPCP.ShowDialog()
            BindPettyPaymentDataGrid()
        End If
    End Sub

    Private Sub dgvJournalApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalApproval.CellContentClick
        If e.ColumnIndex = 7 Then
            Dim frmJournal As New JournalFrm()
            ApprovalLedgerNo = dgvJournalApproval.SelectedRows(0).Cells("dgclLedgerNo").Value.ToString
            frmJournal.ShowDialog()
            BindJournalDataGrid()
        End If
    End Sub

    Private Sub btnApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproval.Click

        If dgvJournalApproval.Rows.Count = 0 And ddlTransaction.Text = "Journal" Then
            DisplayInfoMessage("Msg3")
            ''MsgBox("No Records To Post in Journal!")
            Exit Sub
        End If

        If dgvPettyCashPayment.Rows.Count = 0 And ddlTransaction.Text = "Petty Cash Payment" Then
            DisplayInfoMessage("Msg4")
            ''MsgBox("No Records To Post in Petty Cash Payment !")
            Exit Sub
        End If

        If dgPettyCashReciept.Rows.Count = 0 And ddlTransaction.Text = "Petty Cash Receipt" Then
            DisplayInfoMessage("Msg5")
            ''MsgBox("No Records To Post in Petty Cash Receipt!")
            Exit Sub
        End If



        If cbAllRecordsTransaction.Checked = False Then
            DisplayInfoMessage("Msg6")
            ''MsgBox("Please select All Records")
            cbAllRecordsTransaction.Focus()
            Exit Sub
        Else
            If ddlTransaction.Text = "Journal" Then
                If cbLedgerType.Checked = False And ddlLedgerType.Text <> "--Select--" Then
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please select All Records Ledger Type")
                    cbLedgerType.Focus()
                    Exit Sub
                End If
                For Each GridViewRowJournal In dgvJournalApproval.Rows
                    '1st Step Update AccountBatch Table Status
                    Dim psAccBatchID As String = String.Empty
                    Dim psJournalDate As Date

                    Try
                        Dim int As Integer
                        Dim objJournalPPT As New JournalPPT
                        Dim dt As New DataTable
                        With objJournalPPT
                            .lJournalDate = "01/01/1900"
                            .LedgerNo = GridViewRowJournal.Cells("dgclLedgerNo").Value.ToString()
                            .Status = "N"
                            dt = JournalBOL.GetJournal(objJournalPPT)
                            .AccBatchID = dt.Rows(0).Item("AccBatchID")
                            psAccBatchID = dt.Rows(0).Item("AccBatchID")
                            .JournalDate = dt.Rows(0).Item("JournalDate")
                            psJournalDate = dt.Rows(0).Item("JournalDate")
                            .Status = "Y"
                        End With
                        int = JournalBOL.UpdateAccountBatch(objJournalPPT, "YES")
                        '  MessageBox.Show("Approved Successfully")

                    Catch ex As Exception
                        DisplayInfoMessage("Msg8")
                        ''MsgBox("Approve  Failed")
                        Exit Sub

                    End Try

                    '' Accounts Ledger All module Insert 

                    Try
                        Dim objJournalPPT As New JournalPPT
                        Dim objJournalBOL As New JournalBOL
                        GridViewRowJournal.Cells("dgclLedgerNo").Value.ToString()
                        objJournalPPT.AYear = GlobalPPT.intActiveYear
                        objJournalPPT.Amonth = GlobalPPT.IntActiveMonth
                        objJournalPPT.LedgerDate = GridViewRowJournal.Cells("dgclDate").Value.ToString()
                        objJournalPPT.LedgerType = GridViewRowJournal.Cells("dgclLedgerType").Value.ToString()
                        objJournalPPT.JournalDescp = GridViewRowJournal.Cells("dgclDescription").Value.ToString()
                        objJournalPPT.BatchTotal = GridViewRowJournal.Cells("dgclBatchTotal").Value.ToString()
                        objJournalPPT.LedgerNo = GridViewRowJournal.Cells("dgclLedgerNo").Value.ToString()
                        Dim dsRowsAffectedLedgerAllModule As New DataSet
                        dsRowsAffectedLedgerAllModule = objJournalBOL.JournalLedgerAllModuleInsert(objJournalPPT)
                        psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                        objJournalPPT.LedgerID = psLedgerID

                    Catch ex As Exception
                        DisplayInfoMessage("Msg9")
                        '' MsgBox("Transaction  Failed")
                        Exit Sub
                    End Try
                    ''Step 3 Accounts JournalDetail Insert

                    Try
                        Dim objJournalPPT As New JournalPPT
                        Dim objJournalBOL As New JournalBOL
                        Dim dtjournal As New DataTable

                        With objJournalPPT
                            .AccBatchID = GridViewRowJournal.Cells("dgclAccBatchID").Value.ToString()
                        End With

                        dtjournal = JournalBOL.GetMultipleEntryValue(objJournalPPT)
                        If dtjournal.Rows.Count <> 0 Then

                            dgvMultipleEntry.AutoGenerateColumns = False
                            Me.dgvMultipleEntry.DataSource = dtjournal
                        End If


                        'Dim intJournalRowsAffected As Integer = 0
                        For Each GridViewRowMEJournal In dgvMultipleEntry.Rows
                            If GridViewRowMEJournal.Cells("dgMeCOAID").Value.ToString() <> String.Empty Then
                                With objJournalPPT
                                    .AYear = GlobalPPT.intActiveYear
                                    .Amonth = GlobalPPT.IntActiveMonth
                                    .LedgerID = psLedgerID
                                    .COAID = GridViewRowMEJournal.Cells("dgMeCOAID").Value.ToString()
                                    If GridViewRowMEJournal.cells("DgMeCredit").value.ToString() <> String.Empty Then
                                        .DC = "C"
                                        .Value = GridViewRowMEJournal.cells("DgMeCredit").value.ToString()
                                    Else
                                        .DC = "D"
                                        .Value = GridViewRowMEJournal.cells("DgMeDebit").value.ToString()
                                    End If
                                    .Flag = "AccJournal Price"
                                    .COADescp = GridViewRowMEJournal.Cells("DgMeDescription").Value.ToString()
                                    .DivID = GridViewRowMEJournal.Cells("dgMeDivId").Value.ToString()
                                    .YOPID = GridViewRowMEJournal.Cells("dgMeYOPID").Value.ToString()
                                    .BlockID = GridViewRowMEJournal.Cells("DgMeBlockID").Value.ToString()
                                    .VHID = GridViewRowMEJournal.Cells("dgMeVHID").Value.ToString()
                                    .VHDetailcostCodeID = GridViewRowMEJournal.Cells("dgMeVHDetailCostCodeID").Value.ToString()
                                    .T0 = GridViewRowMEJournal.Cells("dgMeT0").Value.ToString()
                                    .T1 = GridViewRowMEJournal.Cells("dgMeT1").Value.ToString()
                                    .T2 = GridViewRowMEJournal.Cells("dgMeT2").Value.ToString()
                                    .T3 = GridViewRowMEJournal.Cells("dgMeT3").Value.ToString()
                                    .T4 = GridViewRowMEJournal.Cells("dgMeT4").Value.ToString()
                                    .StationID = GridViewRowMEJournal.Cells("DgMeStationID").Value.ToString()
                                End With
                                Dim IntJournalDetail As New Integer
                                IntJournalDetail = JournalBOL.AccountsJournalDetailInsert(objJournalPPT)
                            End If
                        Next
                    Catch ex As Exception
                        DisplayInfoMessage("Msg8")
                        ''MsgBox("Approved Failed")
                        Exit Sub
                    End Try

                    ''Step 4 Accounts VHCharge Detail Insert
                    Try


                        For Each GridViewRowVH In dgvMultipleEntry.Rows
                            If GridViewRowVH.Cells("dgMeVHWSCode").Value.ToString() <> String.Empty Then
                                Dim ObjjournalPPT As New JournalPPT
                                Dim ObjjournalBOL As New JournalBOL
                                With ObjjournalPPT
                                    .VHWScode = GridViewRowVH.Cells("dgMeVHWSCode").Value.ToString()
                                    Dim dsEstCode As New DataSet
                                    dsEstCode = ObjjournalBOL.VHChargedetailLocationEstateCodeSelect(ObjjournalPPT)

                                    If dsEstCode.Tables(0).Rows.Count = 0 Then
                                        .EstateCodeL = GlobalPPT.strEstateIDCode
                                    Else
                                        .EstateCodeL = dsEstCode.Tables(0).Rows(0).Item("LocEstateCode").ToString
                                    End If
                                    .VHDetailCostCode = GridViewRowVH.Cells("dgMeVHDetailCostCode").Value.ToString()
                                    .Type = GridViewRowVH.Cells("dgmeVHType").Value.ToString()
                                    '.Type = "V"
                                    .AYear = GlobalPPT.intActiveYear
                                    .Amonth = GlobalPPT.IntActiveMonth
                                    .LedgerType = GridViewRowJournal.Cells("dgclLedgerType").Value.ToString()
                                    .LedgerNo = GridViewRowJournal.Cells("dgclLedgerNo").Value.ToString()
                                    .COAID = GridViewRowVH.Cells("dgMeCOAID").Value.ToString()
                                    If GridViewRowVH.cells("DgMeCredit").value.ToString() <> String.Empty Then
                                        .Value = -(GridViewRowVH.cells("DgMeCredit").value.ToString())
                                    Else
                                        .Value = GridViewRowVH.cells("DgMeDebit").value.ToString()
                                    End If
                                    .JournalDescp = GridViewRowJournal.Cells("dgClDescription").Value.ToString()
                                    .RefNo = .LedgerNo
                                    .UOMID = ""
                                    .Qty = 0
                                End With
                                Dim IntVHChargeDetail As New Integer
                                IntVHChargeDetail = JournalBOL.AccountsVHChargeDetailInsert(ObjjournalPPT)
                            End If
                        Next
                    Catch ex As Exception
                        DisplayInfoMessage("Msg8")
                        '' MsgBox("Approved Failed")
                        Exit Sub
                    End Try

                    ''Step 5 Accounts GLLedger Update( Insert was done during the insertion of COAID Record in Accounts.COA) 
                    Try


                        For Each GridViewRowGLLedger In dgvMultipleEntry.Rows
                            If GridViewRowGLLedger.Cells("dgMeCOAID").Value.ToString() <> String.Empty Then
                                Dim ObjjournalPPT As New JournalPPT
                                Dim ObjjournalBOL As New JournalBOL
                                With ObjjournalPPT
                                    .AYear = GlobalPPT.intActiveYear
                                    .Amonth = GlobalPPT.IntActiveMonth
                                    .COAID = GridViewRowGLLedger.Cells("dgMeCOAID").Value.ToString()
                                    If GridViewRowGLLedger.cells("DgMeCredit").value.ToString() <> String.Empty Then
                                        .Credit = GridViewRowGLLedger.cells("DgMeCredit").value.ToString()
                                        .Debit = 0
                                    Else
                                        .Debit = GridViewRowGLLedger.cells("DgMeDebit").value.ToString()
                                        .Credit = 0
                                    End If

                                End With
                                Dim ObjGlLedger As Object
                                ObjGlLedger = ObjjournalBOL.GLLedgerCOAIDIsExist(ObjjournalPPT)
                                If ObjGlLedger <> 0 Then
                                    ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.Debit - ObjjournalPPT.Credit)
                                    Dim IntGLLedgerDetail As New Integer
                                    IntGLLedgerDetail = JournalBOL.AccountsGLLedgerInsert(ObjjournalPPT)
                                Else
                                    Dim dtGLLedger As DataTable
                                    Dim M1D, M1C, M2D, M2C, M3D, M3C, M4D, M4C, M5D, M5C, M6D, M6C, M7D, M7C, M8D, M8C, M9D, M9C, M10D, M10C, M11D, M11C, M12D, M12C As Decimal
                                    dtGLLedger = ObjjournalBOL.JournalGLLedgerSelect(ObjjournalPPT)
                                    '  ObjjournalPPT.GLLedgerID = dtGLLedger.Rows(0).Item("GLLedgerID")
                                    M1D = IIf(dtGLLedger.Rows(0).Item("M1D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M1D"))
                                    M1C = IIf(dtGLLedger.Rows(0).Item("M1C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M1C"))
                                    M2D = IIf(dtGLLedger.Rows(0).Item("M2D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M2D"))
                                    M2C = IIf(dtGLLedger.Rows(0).Item("M2C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M2C"))
                                    M3D = IIf(dtGLLedger.Rows(0).Item("M3D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M3D"))
                                    M3C = IIf(dtGLLedger.Rows(0).Item("M3C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M3C"))
                                    M4D = IIf(dtGLLedger.Rows(0).Item("M4D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M4D"))
                                    M4C = IIf(dtGLLedger.Rows(0).Item("M4C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M4C"))
                                    M5D = IIf(dtGLLedger.Rows(0).Item("M5D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M5D"))
                                    M5C = IIf(dtGLLedger.Rows(0).Item("M5C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M5C"))
                                    M6D = IIf(dtGLLedger.Rows(0).Item("M6D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M6D"))
                                    M6C = IIf(dtGLLedger.Rows(0).Item("M6C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M6C"))
                                    M7D = IIf(dtGLLedger.Rows(0).Item("M7D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M7D"))
                                    M7C = IIf(dtGLLedger.Rows(0).Item("M7C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M7C"))
                                    M8D = IIf(dtGLLedger.Rows(0).Item("M8D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M8D"))
                                    M8C = IIf(dtGLLedger.Rows(0).Item("M8C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M8C"))
                                    M9D = IIf(dtGLLedger.Rows(0).Item("M9D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M9D"))
                                    M9C = IIf(dtGLLedger.Rows(0).Item("M9C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M9C"))
                                    M10D = IIf(dtGLLedger.Rows(0).Item("M10D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M10D"))
                                    M10C = IIf(dtGLLedger.Rows(0).Item("M10C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M10C"))
                                    M11D = IIf(dtGLLedger.Rows(0).Item("M11D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M11D"))
                                    M11C = IIf(dtGLLedger.Rows(0).Item("M11C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M11C"))
                                    M12D = IIf(dtGLLedger.Rows(0).Item("M12D") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M12D"))
                                    M12C = IIf(dtGLLedger.Rows(0).Item("M12C") Is DBNull.Value, 0, dtGLLedger.Rows(0).Item("M12C"))

                                    If GlobalPPT.IntActiveMonth = 1 Then
                                        ObjjournalPPT.UpdateCreditCalc = M1C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M1D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 2 Then
                                        ObjjournalPPT.UpdateCreditCalc = M2C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M2D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 3 Then
                                        ObjjournalPPT.UpdateCreditCalc = M3C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M3D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 4 Then
                                        ObjjournalPPT.UpdateCreditCalc = M4C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M4D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 5 Then
                                        ObjjournalPPT.UpdateCreditCalc = M5C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M5D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 6 Then
                                        ObjjournalPPT.UpdateCreditCalc = M6C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M6D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 7 Then
                                        ObjjournalPPT.UpdateCreditCalc = M7C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M7D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 8 Then
                                        ObjjournalPPT.UpdateCreditCalc = M8C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M8D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 9 Then
                                        ObjjournalPPT.UpdateCreditCalc = M9C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M9D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 10 Then
                                        ObjjournalPPT.UpdateCreditCalc = M10C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M10D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 11 Then
                                        ObjjournalPPT.UpdateCreditCalc = M11C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M11D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 12 Then
                                        ObjjournalPPT.UpdateCreditCalc = M12C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M12D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLLedgerUpdate(ObjjournalPPT)
                                    End If
                                End If
                            End If

                        Next
                    Catch ex As Exception
                        DisplayInfoMessage("Msg8")
                        ''MsgBox("Approved Failed")
                        Exit Sub
                    End Try

                    Try


                        ''Step 6 Accounts GLSub Insert
                        For Each GridViewRowGLSub In dgvMultipleEntry.Rows
                            If GridViewRowGLSub.Cells("dgMeBlockID").Value.ToString() <> String.Empty Then
                                Dim ObjjournalPPT As New JournalPPT
                                Dim ObjjournalBOL As New JournalBOL
                                With ObjjournalPPT
                                    .AYear = GlobalPPT.intActiveYear
                                    .Amonth = GlobalPPT.IntActiveMonth
                                    .COAID = GridViewRowGLSub.Cells("dgMeCOAID").Value.ToString()
                                    .DivID = GridViewRowGLSub.Cells("dgMeDivID").Value.ToString()
                                    .YOPID = GridViewRowGLSub.Cells("dgMeYOPID").Value.ToString()
                                    .BlockID = GridViewRowGLSub.Cells("dgMeBlockID").Value.ToString()
                                    If GridViewRowGLSub.cells("DgMeCredit").value.ToString() <> String.Empty Then
                                        .Credit = GridViewRowGLSub.cells("DgMeCredit").value.ToString()
                                        .Debit = 0
                                    Else
                                        .Debit = GridViewRowGLSub.cells("DgMeDebit").value.ToString()
                                        .Credit = 0
                                    End If
                                End With
                                Dim ObjGlSub As Object
                                ObjGlSub = ObjjournalBOL.GLLedgerBlockIDIsExist(ObjjournalPPT)
                                If ObjGlSub <> 0 Then
                                    ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.Debit - ObjjournalPPT.Credit)
                                    Dim IntGLSubDetail As New Integer
                                    IntGLSubDetail = JournalBOL.AccountsGLSubInsert(ObjjournalPPT)
                                    'Dim IntGLLedgerDetail As New Integer
                                    'IntGLLedgerDetail = JournalBOL.AccountsBlockMasterHistoryInsert(ObjjournalPPT)
                                Else
                                    Dim dtGLSub As DataTable
                                    Dim M1D, M1C, M2D, M2C, M3D, M3C, M4D, M4C, M5D, M5C, M6D, M6C, M7D, M7C, M8D, M8C, M9D, M9C, M10D, M10C, M11D, M11C, M12D, M12C As Decimal
                                    dtGLSub = ObjjournalBOL.JournalGLSubSelect(ObjjournalPPT)
                                    ' ObjjournalPPT.GLSubID = dtGLSub.Rows(0).Item("GLSubID")
                                    M1D = IIf(dtGLSub.Rows(0).Item("M1D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M1D"))
                                    M1C = IIf(dtGLSub.Rows(0).Item("M1C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M1C"))
                                    M2D = IIf(dtGLSub.Rows(0).Item("M2D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M2D"))
                                    M2C = IIf(dtGLSub.Rows(0).Item("M2C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M2C"))
                                    M3D = IIf(dtGLSub.Rows(0).Item("M3D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M3D"))
                                    M3C = IIf(dtGLSub.Rows(0).Item("M3C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M3C"))
                                    M4D = IIf(dtGLSub.Rows(0).Item("M4D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M4D"))
                                    M4C = IIf(dtGLSub.Rows(0).Item("M4C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M4C"))
                                    M5D = IIf(dtGLSub.Rows(0).Item("M5D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M5D"))
                                    M5C = IIf(dtGLSub.Rows(0).Item("M5C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M5C"))
                                    M6D = IIf(dtGLSub.Rows(0).Item("M6D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M6D"))
                                    M6C = IIf(dtGLSub.Rows(0).Item("M6C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M6C"))
                                    M7D = IIf(dtGLSub.Rows(0).Item("M7D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M7D"))
                                    M7C = IIf(dtGLSub.Rows(0).Item("M7C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M7C"))
                                    M8D = IIf(dtGLSub.Rows(0).Item("M8D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M8D"))
                                    M8C = IIf(dtGLSub.Rows(0).Item("M8C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M8C"))
                                    M9D = IIf(dtGLSub.Rows(0).Item("M9D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M9D"))
                                    M9C = IIf(dtGLSub.Rows(0).Item("M9C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M9C"))
                                    M10D = IIf(dtGLSub.Rows(0).Item("M10D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M10D"))
                                    M10C = IIf(dtGLSub.Rows(0).Item("M10C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M10C"))
                                    M11D = IIf(dtGLSub.Rows(0).Item("M11D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M11D"))
                                    M11C = IIf(dtGLSub.Rows(0).Item("M11C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M11C"))
                                    M12D = IIf(dtGLSub.Rows(0).Item("M12D") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M12D"))
                                    M12C = IIf(dtGLSub.Rows(0).Item("M12C") Is DBNull.Value, 0, dtGLSub.Rows(0).Item("M12C"))

                                    If GlobalPPT.IntActiveMonth = 1 Then
                                        ObjjournalPPT.UpdateCreditCalc = M1C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M1D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 2 Then
                                        ObjjournalPPT.UpdateCreditCalc = M2C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M2D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 3 Then
                                        ObjjournalPPT.UpdateCreditCalc = M3C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M3D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 4 Then
                                        ObjjournalPPT.UpdateCreditCalc = M4C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M4D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 5 Then
                                        ObjjournalPPT.UpdateCreditCalc = M5C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M5D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 6 Then
                                        ObjjournalPPT.UpdateCreditCalc = M6C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M6D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 7 Then
                                        ObjjournalPPT.UpdateCreditCalc = M7C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M7D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 8 Then
                                        ObjjournalPPT.UpdateCreditCalc = M8C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M8D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 9 Then
                                        ObjjournalPPT.UpdateCreditCalc = M9C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M9D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 10 Then
                                        ObjjournalPPT.UpdateCreditCalc = M10C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M10D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 11 Then
                                        ObjjournalPPT.UpdateCreditCalc = M11C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M11D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    ElseIf GlobalPPT.IntActiveMonth = 12 Then
                                        ObjjournalPPT.UpdateCreditCalc = M12C + ObjjournalPPT.Credit
                                        ObjjournalPPT.UpdateDebitCalc = M12D + ObjjournalPPT.Debit
                                        ObjjournalPPT.MonthCalculation = Abs(ObjjournalPPT.UpdateDebitCalc - ObjjournalPPT.UpdateCreditCalc)
                                        JournalBOL.JournalGLSubUpdate(ObjjournalPPT)
                                    End If
                                End If
                            End If
                        Next
                    Catch ex As Exception
                        DisplayInfoMessage("Msg8")
                        ''MsgBox("Approved Failed")
                        Exit Sub
                    End Try
                    ClearGridView(dgvMultipleEntry)
                Next
                ClearGridView(dgvJournalApproval)
                DisplayInfoMessage("Msg10")
                ''MsgBox("Approved  Successfully")
                DisplayInfoMessage("Msg11")
                ''  MsgBox("Transaction completed Successfully")

            ElseIf ddlTransaction.Text = "Petty Cash Payment" Then

                Dim addCreditAmount As Decimal = 0

                'Try
                '    Dim objDataGridViewRow As New DataGridViewRow
                '    For Each objDataGridViewRow In dgvMultipleEntry.Rows
                '        addCreditAmount = addCreditAmount + Val(objDataGridViewRow.Cells("dgMeAmount").Value.ToString())
                '    Next
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message())
                'End Try

                'Update PCP Table Status
                Dim ObjPettyCashPaymentPPT As New PettyCashPaymentPPT
                Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
                Dim dsAmountcheck As New DataSet

                dsAmountcheck = ObjPettyCashPaymentBOL.PettyCashPaymentAmountCheck(ObjPettyCashPaymentPPT)

                Dim lCalculatedAmount, lUnApprovalAmount As Integer

                lCalculatedAmount = dsAmountcheck.Tables(0).Rows(0).Item("CalculatedPCPAmount").ToString
                lUnApprovalAmount = dsAmountcheck.Tables(1).Rows(0).Item("NotApprovedAmount").ToString

                lCalculatedAmount = lCalculatedAmount - lUnApprovalAmount

                If lCalculatedAmount < 0 Then
                    DisplayInfoMessage("Msg12")
                    '' MessageBox.Show("Unable to approve,Petty cash Payment Amount is greater than available Petty Cash Amount")
                    Exit Sub
                End If



                For Each GridViewRowPCP In dgvPettyCashPayment.Rows

                    GridViewRowPCP.Cells("dgPVoucherNo").Value.ToString()
                    'Update PCP Table Status
                    Dim ds As New DataSet

                    With ObjPettyCashPaymentPPT
                        .VoucherDate = GridViewRowPCP.Cells("dgPVoucherDate").Value.ToString()
                        .VoucherNo = GridViewRowPCP.Cells("dgPVoucherNo").Value.ToString()
                        .Approved = "Y"
                        .ApprovalDate = PettyCashPaymentFrm.dtpApprovalDate.Value
                    End With

                    ds = ObjPettyCashPaymentBOL.UpdatePettyCashPayment(ObjPettyCashPaymentPPT, "YES")

                    'MessageBox.Show("Approved Successfully")


                    Try

                        ''Step 2 Accounts.Ledgerallmodule insert 
                        Dim ObjPCRPPT As New AccountsApprovalPPT
                        Dim ObjPCRBOL As New AccountsApprovalBOL


                        ObjPCRPPT.AYear = GlobalPPT.intActiveYear
                        ObjPCRPPT.Amonth = GlobalPPT.IntActiveMonth
                        ObjPCRPPT.LedgerDate = GridViewRowPCP.Cells("dgPVoucherDate").Value.ToString()
                        ObjPCRPPT.LedgerType = "PCP"
                        ObjPCRPPT.JournalDescp = GridViewRowPCP.Cells("dgPPayDescp").Value.ToString()
                        ObjPCRPPT.BatchTotal = "0.00"
                        ObjPCRPPT.LedgerNo = GridViewRowPCP.Cells("dgPVoucherNo").Value.ToString()

                        Dim dsRowsAffectedLedgerAllModule As New DataSet
                        dsRowsAffectedLedgerAllModule = ObjPCRBOL.JournalLedgerAllModuleInsert(ObjPCRPPT)
                        psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                        ObjPCRPPT.LedgerID = psLedgerID

                    Catch ex As Exception
                        DisplayInfoMessage("Msg9")
                        ''MsgBox("Transaction Failed")
                        Exit Sub
                    End Try

                    ''Step 3 Accounts JournalDetail Insert
                    Dim objPCPPPT As New PettyCashPaymentPPT
                    Dim dtPCP As New DataTable

                    objPCPPPT.VoucherNo = GridViewRowPCP.Cells("dgPVoucherNo").Value.ToString()

                    dtPCP = ObjPettyCashPaymentBOL.GetValueMultipleEntry(objPCPPPT)
                    If dtPCP.Rows.Count <> 0 Then
                        dgvMultipleEntry.AutoGenerateColumns = False
                        Me.dgvMultipleEntry.DataSource = dtPCP
                    End If

                    '  Dim addCreditAmount As Decimal = 0
                    Dim AddDebitAmount As Decimal = 0

                    Try
                        addCreditAmount = 0
                        Dim objDataGridViewRow As New DataGridViewRow
                        For Each objDataGridViewRow In dgvMultipleEntry.Rows

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


                    Try
                        Dim dt As New DataTable
                        Dim ObjPCR As New AccountsApprovalPPT
                        Dim ObjPCRBOLApp As New AccountsApprovalBOL
                        dt = ObjPCRBOLApp.GetPettyCashReceiptCOAID(ObjPCR)



                        Dim PettyCashCOAID As String = String.Empty
                        Dim SamarindaCOAID As String = String.Empty

                        If dt.Rows.Count <> 0 Then
                            PettyCashCOAID = dt.Rows(0).Item("PettyCashCOAID")
                            Dim ObjAccountsApprovalPPT1 As New AccountsApprovalPPT
                            Dim ObjAccountsApprovalBOL1 As New AccountsApprovalBOL
                            With ObjAccountsApprovalPPT1
                                .AYear = GlobalPPT.intActiveYear
                                .Amonth = GlobalPPT.IntActiveMonth
                                .LedgerID = psLedgerID
                                .COAID = PettyCashCOAID
                                .DC = "C"
                                .Value = addCreditAmount
                                .Flag = "PCP Price"
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
                            End With
                            Dim IntAccountsApprovalDetail1 As New Integer
                            IntAccountsApprovalDetail1 = AccountsApprovalBOL.AccountsJournalDetailInsert(ObjAccountsApprovalPPT1)

                        End If



                        Dim intAccountsApprovalRowsAffected As Integer = 0
                        For Each GridViewRow In dgvMultipleEntry.Rows
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
                                    .COADescp = GridViewRow.Cells("DgMeRemarks").Value.ToString()
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
                                End With
                                Dim IntAccountsApprovalDetail As New Integer
                                IntAccountsApprovalDetail = AccountsApprovalBOL.AccountsJournalDetailInsert(ObjAccountsApprovalPPT)
                            End If
                        Next

                    Catch ex As Exception
                        DisplayInfoMessage("Msg9")
                        ''MsgBox("Transaction Failed")
                        Exit Sub
                    End Try
                    ClearGridView(dgvMultipleEntry)
                Next
                ClearGridView(dgvPettyCashPayment)
                DisplayInfoMessage("Msg10")
                DisplayInfoMessage("Msg11")
                ''MsgBox("Records Approved Successfully")
                ''MsgBox("Transaction Completed Successfully")

            Else
                For Each GridViewRowPCR In dgPettyCashReciept.Rows


                    Try

                        'Update PCR Table Status

                        Dim ObjPettyCashReceiptPPT As New PettyCashReceiptPPT
                        Dim ObjPettyCashReceiptBOL As New PettyCashReceiptBOL
                        Dim ds As New Integer
                        With ObjPettyCashReceiptPPT
                            .AccReceiptID = GridViewRowPCR.Cells("dbPRReceiptID").Value.ToString()
                            .Approved = "Y"
                        End With
                        ds = ObjPettyCashReceiptBOL.UpdateReceipt(ObjPettyCashReceiptPPT, "YES")
                    Catch ex As Exception
                        DisplayInfoMessage("Msg9")
                        ''MsgBox("Transaction  Failed")
                        Exit Sub
                    End Try


                    Try

                        ''Step 2 Accounts.Ledgerallmodule insert 
                        Dim ObjPCRPPT As New AccountsApprovalPPT
                        Dim ObjPCRBOL As New AccountsApprovalBOL


                        ObjPCRPPT.AYear = GlobalPPT.intActiveYear
                        ObjPCRPPT.Amonth = GlobalPPT.IntActiveMonth
                        ObjPCRPPT.LedgerDate = GridViewRowPCR.Cells("dgPRReceiptDate").Value.ToString()
                        ObjPCRPPT.LedgerType = "PCR"
                        ObjPCRPPT.JournalDescp = GridViewRowPCR.Cells("dgPRReceiptDescp").Value.ToString()
                        ObjPCRPPT.BatchTotal = GridViewRowPCR.Cells("dgPRAmount").Value.ToString()
                        ObjPCRPPT.LedgerNo = GridViewRowPCR.Cells("dgPRReceiptNo").Value.ToString()

                        Dim dsRowsAffectedLedgerAllModule As New DataSet
                        dsRowsAffectedLedgerAllModule = ObjPCRBOL.JournalLedgerAllModuleInsert(ObjPCRPPT)
                        psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                        ObjPCRPPT.LedgerID = psLedgerID
                        ' MessageBox.Show("Approved Successfully")
                    Catch ex As Exception
                        DisplayInfoMessage("Msg9")
                        '' MsgBox("Transaction  Failed")
                        Exit Sub
                    End Try


                    ''Step 3 Accounts JournalDetail Insert

                    Try

                        Dim dt As New DataTable
                        Dim ObjPCR As New AccountsApprovalPPT
                        Dim ObjPCRBOLApp As New AccountsApprovalBOL
                        dt = ObjPCRBOLApp.GetPettyCashReceiptCOAID(ObjPCR)

                        Dim PettyCashCOAID As String = String.Empty
                        Dim SamarindaCOAID As String = String.Empty
                        If dt.Rows.Count <> 0 Then
                            PettyCashCOAID = dt.Rows(0).Item("PettyCashCOAID")
                            If PettyCashCOAID <> String.Empty Then

                                Dim intJournalRowsAffected As Integer = 0
                                Dim ObjPCRPPT As New AccountsApprovalPPT
                                Dim ObjPCRBOL As New AccountsApprovalBOL
                                With ObjPCRPPT
                                    .AYear = GlobalPPT.intActiveYear
                                    .Amonth = GlobalPPT.IntActiveMonth
                                    .LedgerID = psLedgerID
                                    .COAID = PettyCashCOAID
                                    .DC = "D"
                                    .Value = GridViewRowPCR.Cells("dgPRAmount").Value.ToString()
                                    .Flag = "PCR Price"
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
                                End With
                                Dim IntJournalDetail As New Integer
                                IntJournalDetail = AccountsApprovalBOL.AccountsJournalDetailInsert(ObjPCRPPT)
                            End If
                        End If
                        If dt.Rows.Count <> 0 Then

                            SamarindaCOAID = dt.Rows(0).Item("SamarindaCOAID")
                            If SamarindaCOAID <> String.Empty Then

                                Dim intJournalRowsAffected As Integer = 0
                                Dim ObjPCRPPT As New AccountsApprovalPPT
                                Dim ObjPCRBOL As New AccountsApprovalBOL
                                With ObjPCRPPT
                                    .AYear = GlobalPPT.intActiveYear
                                    .Amonth = GlobalPPT.IntActiveMonth
                                    .LedgerID = psLedgerID
                                    .COAID = SamarindaCOAID
                                    .DC = "C"
                                    .Value = GridViewRowPCR.Cells("dgPRAmount").Value.ToString()
                                    .Flag = "PCR Price"
                                    .COADescp = GridViewRowPCR.Cells("dgPRReceiptDescp").Value.ToString()
                                    .DivID = ""
                                    .YOPID = ""
                                    .BlockID = ""
                                    .VHID = ""
                                    .VHDetailcostCodeID = ""
                                    .T0 = dt.Rows(0).Item("T0SAM")
                                    .T1 = dt.Rows(0).Item("T1SAM")
                                    .T2 = dt.Rows(0).Item("T2SAM")
                                    .T3 = dt.Rows(0).Item("T3SAM")
                                    .T4 = dt.Rows(0).Item("T4SAM")
                                End With
                                Dim IntJournalDetail As New Integer
                                IntJournalDetail = AccountsApprovalBOL.AccountsJournalDetailInsert(ObjPCRPPT)
                            End If

                        End If


                    Catch ex As Exception
                        DisplayInfoMessage("Msg9")
                        ''MsgBox("Transaction Failed")
                        Exit Sub
                    End Try

                Next
                ClearGridView(dgPettyCashReciept)
                BindPettyReceiptDataGrid()

                DisplayInfoMessage("Msg10")
                DisplayInfoMessage("Msg11")

                ''MsgBox("Records Approved Successfully")
                ''MsgBox("Transaction Completed Successfully")
            End If


            ClearGridView(dgvMultipleEntry)
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
            Next
        End If
    End Sub

    Private Sub ddlLedgerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLedgerType.SelectedIndexChanged
        BindJournalDataGrid()
    End Sub

    Private Sub btnClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClos.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountApprovalFrm))
        If MsgBox(rm.GetString("Msg13"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If

        'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        '    Me.Close()
        'End If

    End Sub
End Class