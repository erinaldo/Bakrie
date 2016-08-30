Imports Accounts_BOL
Imports Accounts_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Math

Public Class JournalFrm

    Public lAccJournalID As String = String.Empty
    Public lCOAID As String = String.Empty
    Public psT0analysisID As String = String.Empty
    Public psT1analysisID As String = String.Empty
    Public psT2analysisID As String = String.Empty
    Public psT3analysisID As String = String.Empty
    Public psT4analysisID As String = String.Empty
    Public lBatchTypeID As String = String.Empty
    Public lLedgerTypeID As String = String.Empty
    Public psContractId As String = String.Empty
    Public psBlockID As String = String.Empty
    Public psDivID As String = String.Empty
    Public psYopID As String = String.Empty
    Public psStationID As String = String.Empty
    Public psVHID As String = String.Empty
    Public psCategoryID As String = String.Empty
    Public psVHCategoryType As String = String.Empty
    Public psVHDetailCostCodeID As String = String.Empty
    Public isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Public lDiff As Decimal
    Public lSumCreditDebit As Decimal
    Dim rowMultipleEntryAdd As DataRow
    Dim dtjournal As New DataTable("todgJournal")
    Dim dtDeleteMERecord As New DataTable("DeleteJornal")
    Dim columnJournalAdd As DataColumn
    Dim rowJournalAdd As DataRow

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Dim AddorSave As Boolean = True

    Dim DeletecolumnJournal As DataColumn
    Dim DeleterowJournal As DataRow
    Dim rowMultipleEntryDelete As DataRow
    'Public dtAddFlag As Boolean = False
    'Public btnAddFlag As Boolean = True
    Public psEstateType As String = String.Empty
    Public lbtnAdd As String = "Add"
    Public lbtnSave As String = "Save All"
    Public lAccountCode As String = String.Empty
    Dim isModifierKey As Boolean
    Dim addCreditAmount As Decimal
    Dim addDebitAmount As Decimal
    Dim lRecuuringJournal As Char
    Public Shared StrFrmName As String = String.Empty
    '''For approval
    Public psLedgerID As String = String.Empty

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalFrm))

    Public Sub ClearHeaderbox()
        'ddlLedgerType.SelectedIndex = 0
        LedgerType()
        txtLedgerNo.Text = String.Empty
        GlobalBOL.SetDateTimePicker(Me.dtpJournalDate)
        GlobalBOL.SetDateTimePicker(Me.dtpviewJournalDate)
        txtBatchTotal.Text = String.Empty
        txtContractNo.Text = String.Empty
        lblContractName.Text = String.Empty
        txtJournalDescp.Text = String.Empty
        lAccJournalID = String.Empty
        lBatchTypeID = String.Empty
        lLedgerTypeID = String.Empty
        psContractId = String.Empty
        chkJournalDate.Checked = False

        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save All"
        Else
            btnSave.Text = "Simpan Semua"
        End If

        lbtnSave = "Save All"
        DeleteMultientry.Clear()
        grpLedgerValues.Enabled = True
        chkJournalDate.Checked = False
        txtLedgerNoSearch.Text = String.Empty
        ddlLedgerTypeSearch.Text = String.Empty
        txtCredit.Text = String.Empty
        txtDebit.Text = String.Empty
        txtDiff.Text = String.Empty
        chkRecurringJournals.Checked = False
        txtJournalDescp.Enabled = True
        btnSave.Visible = True
        lblStatusValue.Text = "OPEN"
        lblRecjectedReason.Visible = False
        lblColon.Visible = False
        lblRejectedReasonValue.Visible = False



    End Sub


    Public Sub Clear()

        Me.txtAccountCode.Text = String.Empty
        lblAccountDescp.Text = String.Empty
        lblOldAccountCode.Text = String.Empty
        txtDiv.Text = String.Empty
        txtYOP.Text = String.Empty
        txtDescp.Text = String.Empty
        txtSubBlock.Text = String.Empty
        txtVehicleCode.Text = String.Empty
        txtDetailCostCode.Text = String.Empty
        txtStation.Text = String.Empty
        txtT0.Text = GlobalPPT.strEstateCode
        lblT0Name.Text = GlobalPPT.strEstateCode
        txtT1.Text = String.Empty
        lblT1Name.Text = String.Empty
        txtT2.Text = String.Empty
        lblT2Name.Text = String.Empty
        txtT3.Text = String.Empty
        lblT3Name.Text = String.Empty
        lblT4Name.Text = String.Empty
        txtT4.Text = String.Empty
        txtLedgerNoSearch.Text = String.Empty
        ddlLedgerTypeSearch.SelectedIndex = -1
        txtCreditKeenValue.Text = String.Empty
        txtDebitKeenValue.Text = String.Empty

        lblBlockStatus.Text = String.Empty
        lblDivName.Text = String.Empty
        lblYOPName.Text = String.Empty
        lblStationDescp.Text = String.Empty
        lblVehicleDescp.Text = String.Empty
        lblDetailCostDescp.Text = String.Empty
        lCOAID = String.Empty
        psT0analysisID = String.Empty
        psT1analysisID = String.Empty
        psT2analysisID = String.Empty
        psT3analysisID = String.Empty
        psT4analysisID = String.Empty
        psBlockID = String.Empty
        psDivID = String.Empty
        psYopID = String.Empty
        psStationID = String.Empty
        psVHID = String.Empty
        psVHDetailCostCodeID = String.Empty
        psVHCategoryType = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        Else
            btnAdd.Text = "Menambahkan"
        End If
        lbtnAdd = "Add"
        ddlLedgerType.Enabled = True
        dtpJournalDate.Enabled = True
        txtLedgerNo.Enabled = True




        cmbSearchStatus.Text = "open"
        ' ddlLedgerTypeSearch.SelectedIndex = 0
        Dim mdiparent As New MDIParent
        StationEnable()
        If mdiparent.strMenuID <> "M110" Then
            LedgerTypeSearch()
        End If
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


    End Sub
    Private Sub LedgerType()

        Dim dtLedgerType As New DataTable()
        Dim objLedgerType As New JournalPPT()
        Dim ObjLedgerTypeBOL As New JournalBOL()
        dtLedgerType = ObjLedgerTypeBOL.GetLedgerType(objLedgerType)

        If dtLedgerType.Rows.Count = 0 Then
            DisplayInfoMessage("Msg1")
            'MsgBox("No Records in Ledger Type,Please Add the Records in Accounts-LedgerSetup ")
            ' Exit Sub
        End If
        ddlLedgerType.DataSource = dtLedgerType
        ddlLedgerType.DisplayMember = "LedgerType"
        ddlLedgerType.ValueMember = "LedgerSetupID"
        Dim intRowCount As Integer
        intRowCount = ddlLedgerType.SelectedIndex

        'If dtLedgerType IsNot Nothing And dtLedgerType.Rows.Count > 0 Then
        Dim dr As DataRow = dtLedgerType.NewRow()
        dr(0) = "--Select--"
        'dr(1) = "--Select--"
        dtLedgerType.Rows.InsertAt(dr, 0)
        'End If

        ddlLedgerType.SelectedIndex = 0

    End Sub
    Private Sub LedgerTypeSearch()

        Dim dtLedgerType As New DataTable()
        Dim objLedgerType As New JournalPPT()
        Dim ObjLedgerTypeBOL As New JournalBOL()
        dtLedgerType = ObjLedgerTypeBOL.GetLedgerType(objLedgerType)


        If dtLedgerType.Rows.Count <> 0 Then

            ddlLedgerTypeSearch.DataSource = dtLedgerType
            ddlLedgerTypeSearch.DisplayMember = "LedgerType"
            ddlLedgerTypeSearch.ValueMember = "LedgerSetupID"

            Dim intRowCount As Integer
            intRowCount = ddlLedgerType.SelectedIndex

            If dtLedgerType IsNot Nothing And dtLedgerType.Rows.Count > 0 Then
                Dim dr As DataRow = dtLedgerType.NewRow()
                dr(0) = "--Select--"
                'dr(1) = "--Select--"
                dtLedgerType.Rows.InsertAt(dr, 0)
            End If

            ddlLedgerTypeSearch.SelectedIndex = 0
        End If

    End Sub
    Private Sub StationEnable()
        'Dim psEstateType As String
        psEstateType = JournalBOL.EstateTypeSelect()
        If psEstateType = "M" Then
            txtStation.Enabled = True
            lblStation.Enabled = True
            btnSearchStation.Enabled = True
            txtSubBlock.Enabled = False
            lblBlockStatus.Enabled = False
            btnSearchSubBlock.Enabled = False
            txtDiv.Enabled = False
            lblDivName.Enabled = False
            btnDivSearch.Enabled = False
            txtYOP.Enabled = False
            lblYOPName.Enabled = False
        End If
    End Sub
    Private Sub btnLedgerNoLookUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frmLedgerNO As New LedgerNoLookUp
        'frmLedgerNO.ShowDialog()
        'If frmLedgerNO.strAccBatchID <> String.Empty Then
        '    Me.txtLedgerNo.Text = frmLedgerNO.strLedgerNo
        '    lBatchTypeID = frmLedgerNO.strAccBatchID
        '    Me.txtBatchTotal.Text = frmLedgerNO.dblAccBatchTotal
        '    ' CreditDebitAmount()
        '    Dim ObjJournalPPT As New JournalPPT
        '    With ObjJournalPPT
        '        ObjJournalPPT.LedgerNo = Me.txtLedgerNo.Text
        '    End With
        '    '  LedgerNoExist(ObjJournalPPT.LedgerNo)
        'End If


    End Sub
    Private Sub btnSearchContractNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchContractNo.Click
        Cursor = Cursors.WaitCursor
        Dim frmContratNoLookup As New ContractNoLookup
        frmContratNoLookup.ShowDialog()
        If frmContratNoLookup.strContractId <> String.Empty Then
            Me.txtContractNo.Text = frmContratNoLookup.strContractNo
            lblContractName.Text = frmContratNoLookup.strContractName
            psContractId = frmContratNoLookup.strContractId
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnAccountCodeLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountCodeLookup.Click
        Cursor = Cursors.WaitCursor
        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            lCOAID = frmAcctcodeLookup.strAcctId
            lblAccountDescp.Text = frmAcctcodeLookup.strAcctDescp
            GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            lblOldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchSubBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSubBlock.Click
        Cursor = Cursors.WaitCursor
        Dim frmSubBlock As New SubBlockLookup
        Dim result As DialogResult = frmSubBlock.ShowDialog()
        If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtSubBlock.Text = frmSubBlock.psBlockName
            psBlockID = frmSubBlock.psBlockId
            Me.lblBlockStatus.Text = frmSubBlock.psBlockStatus
            Me.txtDiv.Text = frmSubBlock.psDIV
            psDivID = frmSubBlock.psDIVID
            Me.lblDivName.Text = frmSubBlock.psDIVName
            Me.txtYOP.Text = frmSubBlock.psYop
            Me.lblYOPName.Text = frmSubBlock.psYopName
            psYopID = frmSubBlock.psYopID

        End If
        Cursor = Cursors.Arrow

    End Sub

    Private Sub btnSearchVehicleCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVehicleCode.Click
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

    Private Sub btnSearchVehicleDetailCostCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVehicleDetailCostCode.Click
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

    Private Sub btnSearchStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStation.Click
        Cursor = Cursors.WaitCursor
        Dim frmStationLookup As New StationLookup
        frmStationLookup.ShowDialog()
        If frmStationLookup.psStationId <> String.Empty Then
            Me.txtStation.Text = frmStationLookup.psStationCode
            Me.lblStationDescp.Text = frmStationLookup.psStationDesc
            psStationID = frmStationLookup.psStationId
        End If
        Cursor = Cursors.Arrow
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

    Private Sub txtAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave
        If txtAccountCode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objJournal As New JournalPPT
            objJournal.COACode = txtAccountCode.Text.Trim()
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.AcctlookupSearch(objJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg2")
                ''MessageBox.Show("Invalid Account code,Please Choose it from look up")
                txtAccountCode.Text = String.Empty
                lblAccountDescp.Text = String.Empty
                lCOAID = String.Empty
                lblOldAccountCode.Text = String.Empty
                txtAccountCode.Focus()
                GlobalPPT.psAcctExpenditureType = ""
                Exit Sub
            Else
                lblAccountDescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
                lCOAID = ds.Tables(0).Rows(0).Item("COAID").ToString
                GlobalPPT.psAcctExpenditureType = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                lblOldAccountCode.Text = ds.Tables(0).Rows(0).Item("OldCOACode").ToString
            End If
        Else
            txtAccountCode.Text = String.Empty
            lblAccountDescp.Text = String.Empty
            lCOAID = String.Empty
            GlobalPPT.psAcctExpenditureType = ""
            lblOldAccountCode.Text = String.Empty
        End If
    End Sub

    Private Sub txtT0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT0.Leave
        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.T0Value = txtT0.Text.Trim()
            ObjJournal.TDecide = "T0"
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.TlookupSearch(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg3")
                '' MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
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

    Private Sub txtT1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1.Leave
        If txtT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.T1Value = txtT1.Text.Trim()
            ObjJournal.TDecide = "T1"
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.TlookupSearch(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg4")
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

    Private Sub txtT2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT2.Leave
        If txtT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.T2Value = txtT2.Text.Trim()
            ObjJournal.TDecide = "T2"
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.TlookupSearch(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg5")
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

    Private Sub txtT3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT3.Leave
        If txtT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.T3Value = txtT3.Text.Trim()
            ObjJournal.TDecide = "T3"
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.TlookupSearch(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg6")
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

    'Private Sub txtLedgerNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedgerNo.Leave
    '    'If txtLedgerNo.Text.Trim() <> String.Empty Then
    '    '    Dim ds As New DataSet
    '    '    Dim ObjJournal As New JournalPPT
    '    '    ObjJournal.LedgerNo = txtLedgerNo.Text.Trim()
    '    '    Dim ObjJournalBOL As New JournalBOL
    '    '    ds = ObjJournalBOL.LedgerNoSearch(ObjJournal, "YES")
    '    '    If ds.Tables(0).Rows.Count = 0 Then
    '    '        MessageBox.Show("Invalid Ledger No,Please Choose it from look up")
    '    '        Me.txtLedgerNo.Text = String.Empty
    '    '        lBatchTypeID = String.Empty
    '    '        Me.txtBatchTotal.Text = String.Empty
    '    '        txtLedgerNo.Focus()
    '    '        Exit Sub
    '    '    Else
    '    '        lBatchTypeID = ds.Tables(0).Rows(0).Item("AccBatchID").ToString()
    '    '        Me.txtBatchTotal.Text = ds.Tables(0).Rows(0).Item("AccBatchTotal").ToString()
    '    '        ' CreditDebitAmount()
    '    '        Dim ObjJournalPPT As New JournalPPT
    '    '        With ObjJournalPPT
    '    '            ObjJournalPPT.LedgerNo = Me.txtLedgerNo.Text
    '    '        End With
    '    '        LedgerNoExist(ObjJournalPPT.LedgerNo)
    '    '    End If
    '    'Else
    '    '    Me.txtBatchTotal.Text = String.Empty
    '    'End If
    'End Sub

    Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave
        If txtSubBlock.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            Dim ObjJournalBOL As New JournalBOL
            'Dim objSubBlock As New StoreIssueVoucherPPT
            ObjJournal.BlockStatus = GlobalPPT.psAcctExpenditureType
            ObjJournal.SubBlock = txtSubBlock.Text.Trim()

            ds = ObjJournalBOL.GetSubBlock(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg7")
                ''MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
                txtSubBlock.Text = String.Empty
                psBlockID = String.Empty
                lblBlockStatus.Text = String.Empty
                Me.txtDiv.Text = String.Empty
                psDivID = String.Empty
                Me.lblDivName.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                Me.lblYOPName.Text = String.Empty
                psYopID = String.Empty
                txtSubBlock.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
                    txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
                End If
                psBlockID = ds.Tables(0).Rows(0).Item("BlockID")
                If ds.Tables(0).Rows(0).Item("BlockStatus") <> String.Empty Then
                    lblBlockStatus.Text = ds.Tables(0).Rows(0).Item("BlockStatus")
                End If
                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDiv.Text = ds.Tables(0).Rows(0).Item("Div")
                End If
                psDivID = ds.Tables(0).Rows(0).Item("DivID")
                If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
                    Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
                End If
                If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
                    Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
                End If
                If ds.Tables(0).Rows(0).Item("Name") <> String.Empty Then
                    Me.lblYOPName.Text = ds.Tables(0).Rows(0).Item("Name")
                End If
                psYopID = ds.Tables(0).Rows(0).Item("YOPID")

            End If
        ElseIf txtSubBlock.Text.Trim() = String.Empty And txtSubBlock.Enabled = True Then
            txtSubBlock.Text = String.Empty
            psBlockID = String.Empty
            lblBlockStatus.Text = String.Empty
            Me.txtDiv.Text = String.Empty
            psDivID = String.Empty
            Me.lblDivName.Text = String.Empty
            Me.txtYOP.Text = String.Empty
            Me.lblYOPName.Text = String.Empty
            psYopID = String.Empty
        End If
    End Sub

    Private Sub txtVehicleCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave
        If txtVehicleCode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objJournalPPT As New JournalPPT
            Dim ObjJournalBOL As New JournalBOL
            objJournalPPT.VHWScode = txtVehicleCode.Text.Trim()
            ds = ObjJournalBOL.GetVHNo(objJournalPPT, "YES")
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count = 0 Then
                    DisplayInfoMessage("Msg8")
                    MessageBox.Show("Invalid VHNo,Please Choose it from look up")
                    txtVehicleCode.Text = String.Empty
                    lblVehicleDescp.Text = String.Empty
                    psVHID = String.Empty
                    psCategoryID = String.Empty
                    psVHCategoryType = String.Empty
                    txtVehicleCode.Focus()
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0).Item("VHNo").ToString() <> String.Empty Then
                        txtVehicleCode.Text = ds.Tables(0).Rows(0).Item("VHNo").ToString()
                    End If
                    If ds.Tables(0).Rows(0).Item("VHDescp").ToString() <> String.Empty Then
                        lblVehicleDescp.Text = ds.Tables(0).Rows(0).Item("VHDescp").ToString()
                    End If
                    psVHID = ds.Tables(0).Rows(0).Item("VHID").ToString()
                    If ds.Tables(0).Rows(0).Item("VHCategoryID").ToString() <> String.Empty Then
                        psCategoryID = ds.Tables(0).Rows(0).Item("VHCategoryID").ToString()
                    End If
                    If Not ds.Tables(0).Rows(0).Item("Type") Is DBNull.Value Then
                        'psSIVVHType = ds.Tables(0).Rows(0).Item("Type").ToString()
                        If ds.Tables(0).Rows(0).Item("Type").ToString() = "Vehicle" Then
                            psVHCategoryType = "V"
                        End If
                        If ds.Tables(0).Rows(0).Item("Type").ToString() = "Workshop" Then
                            psVHCategoryType = "W"
                        End If
                        If ds.Tables(0).Rows(0).Item("Type").ToString() = "Others" Then
                            psVHCategoryType = "O"
                        End If
                    End If
                End If
            End If
        Else
            txtVehicleCode.Text = String.Empty
            lblVehicleDescp.Text = String.Empty
            psVHID = String.Empty
            psCategoryID = String.Empty
            psVHCategoryType = String.Empty
        End If
    End Sub

    Private Sub txtDetailCostCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDetailCostCode.Leave
        If txtDetailCostCode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objJounalPPT As New JournalPPT
            Dim ObjJournalBOL As New JournalBOL
            objJounalPPT.VHDetailCostCode = txtDetailCostCode.Text.Trim()
            objJounalPPT.Type = psVHCategoryType
            ds = ObjJournalBOL.GetVHDetailsCostCode(objJounalPPT, "YES")
            If ds.Tables.Count <> 0 Then
                If ds.Tables(0).Rows.Count = 0 Then
                    DisplayInfoMessage("Msg9")
                    ''MessageBox.Show("Invalid VHDetail Cost code,Please Choose it from look up")
                    txtDetailCostCode.Text = String.Empty
                    psVHDetailCostCodeID = String.Empty
                    lblDetailCostDescp.Text = String.Empty
                    txtDetailCostCode.Focus()
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0).Item("VHDetailCostCode").ToString() <> String.Empty Then
                        txtDetailCostCode.Text = ds.Tables(0).Rows(0).Item("VHDetailCostCode").ToString()
                    End If
                    psVHDetailCostCodeID = ds.Tables(0).Rows(0).Item("VHDetailCostCodeID").ToString()
                    lblDetailCostDescp.Text = ds.Tables(0).Rows(0).Item("VHDescp").ToString()
                End If
            End If
        Else
            txtDetailCostCode.Text = String.Empty
            psVHDetailCostCodeID = String.Empty
            lblDetailCostDescp.Text = String.Empty

        End If
    End Sub

    Private Sub txtStation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStation.Leave
        If txtStation.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.StationCode = txtStation.Text.Trim()
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.GetStation(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg10")
                ''MessageBox.Show("Invalid Station Value,Please Choose it from look up")
                Me.txtStation.Text = String.Empty
                psStationID = String.Empty
                txtStation.Focus()
                Exit Sub
            Else
                psStationID = ds.Tables(0).Rows(0).Item("StationID").ToString()
                lblStationDescp.Text = ds.Tables(0).Rows(0).Item("StationDescp").ToString()
            End If
        Else
            Me.txtStation.Text = String.Empty
            psStationID = String.Empty
            lblStationDescp.Text = String.Empty
        End If
    End Sub
    Private Sub CreditDebitAmount()

        addCreditAmount = 0
        addDebitAmount = 0

        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvMultipleEntry.Rows
                addCreditAmount = addCreditAmount + Val(objDataGridViewRow.Cells("DgMeCredit").Value.ToString())
                addDebitAmount = addDebitAmount + Val(objDataGridViewRow.Cells("DgMeDebit").Value.ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try


        lDiff = addCreditAmount - addDebitAmount
        lSumCreditDebit = addCreditAmount + addDebitAmount

        If addCreditAmount <> 0 Then
            txtCredit.Text = addCreditAmount
        Else
            txtCredit.Text = ""
        End If
        If addDebitAmount <> 0 Then
            txtDebit.Text = addDebitAmount
            txtBatchTotal.Text = addDebitAmount
        Else
            txtDebit.Text = ""
        End If




        If Val(lDiff) > 0 Then
            Me.txtDiff.Text = Val(lDiff)
        ElseIf Val(lDiff) < 0 Then
            Me.txtDiff.Text = -(lDiff)
        Else
            Me.txtDiff.Text = 0
        End If

        'If txtBatchTotal.Text < addDebitAmount Then
        '    MessageBox.Show("The debit of journal entries should not exceed its batch total", "Debit")
        'End If


    End Sub


    Private Sub JournalFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub JournalFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        SetUICulture(GlobalPPT.strLang)
        Dim mdiparent As New MDIParent
        ' LedgerType()
        StationEnable()
        If mdiparent.strMenuID = "M110" Then
            tbJournal.TabPages.Remove(tbView)
            LedgerType()
            Clear()
            BindDataGrid()
            BindMultipleEntryDataGrid()
            btnAdd.Enabled = False
            btnSave.Enabled = False
            btnDeleteAll.Enabled = False
            btnResetIB.Enabled = False
            cmbStatus.SelectedIndex = 0
            grpApproval.Visible = True
            btnApprovalClose.Visible = True
            CMSMultipleentry.Enabled = False
            btnClose.Visible = False
        Else
            ClearHeaderbox()
            Clear()
            BindDataGrid()
            Me.tbJournal.SelectedTab = tbView
            grpApproval.Visible = False
            btnApprovalClose.Visible = False
            btnClose.Visible = True
        End If




    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tbJournal.TabPages("tbAdd").Text = rm.GetString("tbJournal.TabPages(tbAdd).Text")
            tbJournal.TabPages("tbView").Text = rm.GetString("tbJournal.TabPages(tbView).Text")

            'Add Lables
            lblledgerType.Text = rm.GetString("lblledgerType.Text")
            lblJournalDate.Text = rm.GetString("lblJournalDate.Text")
            lblledgerNo.Text = rm.GetString("lblledgerNo.Text")
            lblStatus.Text = rm.GetString("lblStatus.Text")
            lblSearchStatus.Text = rm.GetString("lblSearchStatus.Text")
            lblBatchTotal.Text = rm.GetString("lblBatchTotal.Text")
            lblContractNo.Text = rm.GetString("lblContractNo.Text")
            lblJournalDescp.Text = rm.GetString("lblJournalDescp.Text")
            lblDebit.Text = rm.GetString("lblDebit.Text")
            lblCredit.Text = rm.GetString("lblCredit.Text")
            lblDiff.Text = rm.GetString("lblDiff.Text")
            lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
            lblDiv.Text = rm.GetString("lblDiv.Text")
            lblYOP.Text = rm.GetString("lblYOP.Text")
            lblSubBlock.Text = rm.GetString("lblSubBlock.Text")
            lblVehicleCode.Text = rm.GetString("lblVehicleCode.Text")
            lblDetailCostCode.Text = rm.GetString("lblDetailCostCode.Text")
            lblStation.Text = rm.GetString("lblStation.Text")
            lblT0.Text = rm.GetString("lblT0.Text")
            lblT1.Text = rm.GetString("lblT1.Text")
            lblT2.Text = rm.GetString("lblT2.Text")
            lblT3.Text = rm.GetString("lblT3.Text")
            lblT4.Text = rm.GetString("lblT4.Text")
            lblCreditKeenValue.Text = rm.GetString("lblCreditKeenValue.Text")
            lblDebitKeenValue.Text = rm.GetString("lblDebitKeenValue.Text")
            lblLedgerNoSearch.Text = rm.GetString("lblLedgerNoSearch.Text")
            lblLedgerTypeSearch.Text = rm.GetString("lblLedgerTypeSearch.Text")
            lblDescp.Text = rm.GetString("lblDescp.Text")
            cmsJournal.Items.Item(0).Text = rm.GetString("cmsJournal.Items.Item(0).Text")
            cmsJournal.Items.Item(1).Text = rm.GetString("cmsJournal.Items.Item(1).Text")
            cmsJournal.Items.Item(2).Text = rm.GetString("cmsJournal.Items.Item(2).Text")

            CMSMultipleentry.Items.Item(0).Text = rm.GetString("cmsJournal.Items.Item(0).Text")
            CMSMultipleentry.Items.Item(1).Text = rm.GetString("cmsJournal.Items.Item(1).Text")
            CMSMultipleentry.Items.Item(2).Text = rm.GetString("cmsJournal.Items.Item(2).Text")

            'Add Datagrid Fields
            dgvJournalView.Columns("dgclLedgerType").HeaderText = rm.GetString("dgvJournalView.Columns(dgclLedgerType).HeaderText")
            dgvJournalView.Columns("dgclLedgerNo").HeaderText = rm.GetString("dgvJournalView.Columns(dgclLedgerNo).HeaderText")
            dgvJournalView.Columns("dgclJournalDate").HeaderText = rm.GetString("dgvJournalView.Columns(dgclJournalDate).HeaderText")
            dgvJournalView.Columns("dgclAccBatchTotal").HeaderText = rm.GetString("dgvJournalView.Columns(dgclAccBatchTotal).HeaderText")
            dgvJournalView.Columns("dgclContractNo").HeaderText = rm.GetString("dgvJournalView.Columns(dgclContractNo).HeaderText")
            dgvJournalView.Columns("dgclJournalDescp").HeaderText = rm.GetString("dgvJournalView.Columns(dgclJournalDescp).HeaderText")
            dgvJournalView.Columns("dgclStatus").HeaderText = rm.GetString("dgvJournalView.Columns(dgclStatus).HeaderText")

            'Multiple entry
            dgvMultipleEntry.Columns("DgMeCOACode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeCOACode).HeaderText")
            dgvMultipleEntry.Columns("dgMeOldCOACode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeOldCOACode).HeaderText")
            dgvMultipleEntry.Columns("DgMeCOADescp").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeCOADescp).HeaderText")
            dgvMultipleEntry.Columns("DgMeDescription").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeDescription).HeaderText")



            dgvMultipleEntry.Columns("DgMeDiv").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeDiv).HeaderText")
            dgvMultipleEntry.Columns("dgMeYOP").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeYOP).HeaderText")
            dgvMultipleEntry.Columns("DgMeSubBlock").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeSubBlock).HeaderText")
            dgvMultipleEntry.Columns("dgMeVHWSCode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeVHWSCode).HeaderText")
            dgvMultipleEntry.Columns("dgMeVHDetailCostCode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeVHDetailCostCode).HeaderText")
            dgvMultipleEntry.Columns("DgMeStationCode").HeaderText = rm.GetString("dgvMultipleEntry.Columns(DgMeStationCode).HeaderText")

            dgvMultipleEntry.Columns("dgMeTAnalysisCode0").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode0).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode1").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode1).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode2").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode2).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode3").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode3).HeaderText")
            dgvMultipleEntry.Columns("dgMeTAnalysisCode4").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeTAnalysisCode4).HeaderText")

            dgvMultipleEntry.Columns("dgMeDebit").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeDebit).HeaderText")
            dgvMultipleEntry.Columns("dgMeCredit").HeaderText = rm.GetString("dgvMultipleEntry.Columns(dgMeCredit).HeaderText")

            'Add Btn Fields
            btnSave.Text = rm.GetString("btnSave.Text")
            btnResetIB.Text = rm.GetString("btnResetIB.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnResetMultipleEntryGrp.Text = rm.GetString("btnResetMultipleEntryGrp.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")
            btnDeleteAll.Text = rm.GetString("btnDeleteAll.Text")
            btnConform.Text = rm.GetString("btnConform.Text")
            btnApprovalClose.Text = rm.GetString("btnClose.Text")
            'View Tab Controls
            PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText") 'lblSearchBy
            lblsearchBy.Text = rm.GetString("lblSearchBy.Text")
            chkJournalDate.Text = rm.GetString("chkJournalDate.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub txtContractNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractNo.Leave
        If txtContractNo.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.ContractNo = txtContractNo.Text.Trim()
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.ContractIDSearch(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg11")
                ''MessageBox.Show("Invalid Contract No ,Please Choose it from look up")
                Me.txtContractNo.Text = String.Empty
                psContractId = String.Empty
                lblContractName.Text = ""
                txtContractNo.Focus()
                Exit Sub
            Else
                psStationID = ds.Tables(0).Rows(0).Item("ContractID").ToString()
                lblContractName.Text = ds.Tables(0).Rows(0).Item("ContractName").ToString()
            End If
        Else
            Me.txtContractNo.Text = String.Empty
            psContractId = String.Empty
            lblContractName.Text = ""
        End If
    End Sub


    Private Sub txtDebitKeenValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebitKeenValue.TextChanged
        If txtDebitKeenValue.Text <> String.Empty Then
            Me.txtCreditKeenValue.Enabled = False
        Else
            Me.txtCreditKeenValue.Enabled = True
        End If
        If Val(txtDebitKeenValue.Text) > 0 Then
            txtDebitKeenValue.Text = Format(Val(txtDebitKeenValue.Text), "0")
        End If


    End Sub

    Private Sub txtCreditKeenValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditKeenValue.TextChanged
        If txtCreditKeenValue.Text <> String.Empty Then
            Me.txtDebitKeenValue.Enabled = False
        Else
            Me.txtDebitKeenValue.Enabled = True
        End If
        If Val(txtCreditKeenValue.Text) > 0 Then
            txtCreditKeenValue.Text = Format(Val(txtCreditKeenValue.Text), "0")
        End If

    End Sub
    Private Sub txtDebitKeenValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDebitKeenValue.KeyDown
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

    Private Sub txtDebitKeenValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDebitKeenValue.KeyPress

        If isModifierKey Then
            e.Handled = True
            Return
        End If

        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub

    Private Sub txtCreditKeenValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCreditKeenValue.KeyDown
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

    Private Sub txtCreditKeenValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCreditKeenValue.KeyPress
        If isModifierKey Then
            e.Handled = True
            Return
        End If

        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub
    Private Function IsSaveValid()
        Dim RequiredField As String

        If Me.ddlLedgerType.Text = "--Select--" Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show("This Field is Required", "Ledger Type")
            ddlLedgerType.Focus()
            Return True
        End If

        If Me.dtpJournalDate.Value = Nothing Then
            DisplayInfoMessage("Msg13")
            ''MessageBox.Show("This Field is Required", "Journal Date")
            dtpJournalDate.Focus()
            Return True
        End If
        If Me.txtLedgerNo.Text.Trim = "" Then
            DisplayInfoMessage("Msg14")
            ''MessageBox.Show("This Field is Required", "Ledger No")
            txtLedgerNo.Focus()
            Return True
        End If
        If Me.txtJournalDescp.Text.Trim = "" Then
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show("This Field is Required", "Journal Descp")
            txtJournalDescp.Focus()
            Return True
        End If


        If txtVehicleCode.Text.Trim <> String.Empty And txtDetailCostCode.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("Details Cost Code is empty, Please Keying the Detail Cost Code Value")
            Return True
        End If


        If AddorSave = False Then

            If dgvMultipleEntry.Rows.Count = 0 Then
                If Me.txtAccountCode.Text.Trim = "" Then
                    DisplayInfoMessage("Msg17")
                    'MessageBox.Show("This Field is Required", "Account Code")
                    txtAccountCode.Focus()
                    Return True
                End If
                If Me.txtDescp.Text.Trim = "" Then
                    DisplayInfoMessage("Msg60")
                    'MessageBox.Show("This Field is Required", "Account Code")
                    txtDescp.Focus()
                    Return True
                End If
         
                If Val(txtDebitKeenValue.Text.Trim) = 0 And Val(txtCreditKeenValue.Text.Trim) = 0 Then
                    DisplayInfoMessage("Msg18")
                    'MessageBox.Show("Either Debit or Credit Should be Keyed in", "Debit/Credit")
                    txtDebitKeenValue.Focus()
                    Return True
                End If
            End If
        Else
            If Me.txtAccountCode.Text.Trim = "" Then
                DisplayInfoMessage("Msg17")
                'MessageBox.Show("This Field is Required", "Account Code")
                txtAccountCode.Focus()
                Return True
            End If
            If Me.txtDescp.Text.Trim = "" Then
                DisplayInfoMessage("Msg60")
                'MessageBox.Show("This Field is Required", "Account Code")
                txtDescp.Focus()
                Return True
            End If
      
            If Val(txtDebitKeenValue.Text.Trim) = 0 And Val(txtCreditKeenValue.Text.Trim) = 0 Then
                DisplayInfoMessage("Msg18")
                'MessageBox.Show("Either Debit or Credit Should be Keyed in", "Debit/Credit")
                txtDebitKeenValue.Focus()
                Return True
            End If


        End If

        Dim objBOL As New GlobalBOL

        If txtAccountCode.Text <> String.Empty And txtSubBlock.Text.Trim = String.Empty Then
            RequiredField = String.Empty
            If objBOL.IsSetMandatoryInCOA(lCOAID, "SubType", "ACCOUNTS", RequiredField) Then
                If RequiredField = "Field No Code" Then
                    DisplayInfoMessage("Msg54")
                    ''MessageBox.Show("This Account Code required a " & RequiredField)
                    Return True
                End If
            End If
        End If

        If txtAccountCode.Text <> String.Empty And txtVehicleCode.Text.Trim = String.Empty Then
            RequiredField = String.Empty
            If objBOL.IsSetMandatoryInCOA(lCOAID, "SubType", "ACCOUNTS", RequiredField) Then
                If RequiredField = "Vehicle Code" Then
                    DisplayInfoMessage("Msg19")
                    ''MessageBox.Show("This Account Code required a " & RequiredField)
                    Return True
                End If
            End If
        End If

        Return False
    End Function
    Public Sub SaveDatas()


        CreditDebitAmount()
        If Me.txtDiff.Text <> 0 Then
            DisplayInfoMessage("Msg21")
            ''MessageBox.Show("Debit and Credit Should be Equal", "Debit/Credit")
            Exit Sub
        End If
        Dim ds As New DataSet
        Dim dsAccBatch As New Integer
        Dim dsAccBatchID As New DataSet
        Dim ObjAccBatchPPT As New JournalPPT
        Dim ObjAccBatchBOL As New JournalBOL
        With ObjAccBatchPPT
            .LedgerNo = txtLedgerNo.Text.Trim
            .JournalDate = Me.dtpJournalDate.Value
            .JournalDescp = Me.txtJournalDescp.Text.Trim
            .LedgerSetupID = ddlLedgerType.SelectedValue.ToString

            If chkRecurringJournals.Checked = True Then
                .RecurringJournal = "Y"
            Else
                .RecurringJournal = "N"
            End If
            .Status = "N"
            .BatchTotal = txtBatchTotal.Text
            .RejectedReason = ""
        End With
        dsAccBatch = JournalBOL.SaveAccountBatch(ObjAccBatchPPT)
        dsAccBatchID = ObjAccBatchBOL.LedgerNoSearch(ObjAccBatchPPT)
        lBatchTypeID = dsAccBatchID.Tables(0).Rows(0).Item("AccBatchID")


        For Each DataGridViewRow In dgvMultipleEntry.Rows
            Dim ObjJournalPPT As New JournalPPT
            Dim ObjJournalBOL As New JournalBOL
            With ObjJournalPPT
                .LedgerSetupID = ddlLedgerType.SelectedValue.ToString
                .JournalDate = Me.dtpJournalDate.Value
                .AccBatchID = lBatchTypeID
                .ContractID = psContractId
                .JournalDescp = Me.txtJournalDescp.Text.Trim
                .COAID = DataGridViewRow.Cells("dgmeCOAID").Value.ToString()
                .DivID = DataGridViewRow.Cells("dgmeDivID").Value.ToString()
                .YOPID = DataGridViewRow.Cells("dgmeYOPID").Value.ToString()
                .BlockID = DataGridViewRow.Cells("dgmeBlockID").Value.ToString()
                .VHID = DataGridViewRow.Cells("dgmeVHID").Value.ToString()
                .VHDetailcostCodeID = DataGridViewRow.Cells("dgmeVHDetailcostCodeID").Value.ToString()
                .StationID = DataGridViewRow.Cells("dgmeStationID").Value.ToString()
                .T0 = DataGridViewRow.Cells("dgmeT0").Value.ToString()
                .T1 = DataGridViewRow.Cells("dgmeT1").Value.ToString()
                .T2 = DataGridViewRow.Cells("dgmeT2").Value.ToString()
                .T3 = DataGridViewRow.Cells("dgmeT3").Value.ToString()
                .T4 = DataGridViewRow.Cells("dgmeT4").Value.ToString()
                .Description = DataGridViewRow.Cells("dgmeDescription").Value.ToString()
                If DataGridViewRow.Cells("dgmeCredit").Value.ToString() <> "" Then
                    .Credit = DataGridViewRow.Cells("dgmeCredit").Value.ToString()
                    '.Debit = DataGridViewRow.Cells("dgmeDebit").Value
                End If
                If DataGridViewRow.Cells("dgmeDebit").Value.ToString() <> "" Then
                    .Debit = DataGridViewRow.Cells("dgmeDebit").Value.ToString()
                    '.Credit = DataGridViewRow.Cells("dgmeCredit").Value.ToString()
                End If

            End With

            ds = JournalBOL.SaveJournal(ObjJournalPPT)

        Next

        If ds Is Nothing Then
            DisplayInfoMessage("Msg22")
            ''MsgBox("Failed to save database")
        Else
            Clear()
            ClearHeaderbox()
            BindDataGrid()
            ClearGridView(dgvMultipleEntry)
            DisplayInfoMessage("Msg23")
            ''MsgBox("Data(s) Successfully Saved!")
            lbtnAdd = "UpdatedtTable"
            lbtnSave = "Save All"
            GlobalPPT.IsRetainFocus = False
            'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If

    End Sub

    Public Sub UpdateRecords()

        CreditDebitAmount()
        If Me.txtDiff.Text <> 0 Then
            DisplayInfoMessage("Msg24")
            ''MessageBox.Show("Debit and Credit Should be Equal", "Debit/Credit")
            Exit Sub
        End If
        DeleteMultiEntryRecords()
        Dim dsAccBatch As New Integer
        Dim dsAccBatchID As New DataSet
        Dim ObjAccBatchPPT As New JournalPPT
        Dim ObjAccBatchBOL As New JournalBOL
        With ObjAccBatchPPT
            .AccBatchID = lBatchTypeID
            .LedgerNo = txtLedgerNo.Text.Trim
            .JournalDate = Me.dtpJournalDate.Value
            .JournalDescp = Me.txtJournalDescp.Text.Trim
            .LedgerSetupID = ddlLedgerType.SelectedValue.ToString

            If chkRecurringJournals.Checked = True Then
                .RecurringJournal = "Y"
            Else
                .RecurringJournal = "N"
            End If
            .Status = "N"
            .BatchTotal = txtBatchTotal.Text
            .RejectedReason = ""

        End With
        dsAccBatch = JournalBOL.UpdateAccountBatch(ObjAccBatchPPT, "NO")



        Dim ds As New DataSet

        For Each DataGridViewRow In dgvMultipleEntry.Rows
            Dim ObjJournalPPT As New JournalPPT
            Dim ObjJournalBOL As New JournalBOL
            With ObjJournalPPT
                .AccJournalID = DataGridViewRow.cells("dgmeAccJournalID").value.ToString()
                .LedgerSetupID = ddlLedgerType.SelectedValue.ToString
                .JournalDate = Me.dtpJournalDate.Value
                .AccBatchID = lBatchTypeID
                .ContractID = psContractId
                .JournalDescp = Me.txtJournalDescp.Text.Trim
                .COAID = DataGridViewRow.Cells("dgmeCOAID").Value.ToString()
                .DivID = DataGridViewRow.Cells("dgmeDivID").Value.ToString()
                .YOPID = DataGridViewRow.Cells("dgmeYOPID").Value.ToString()
                .BlockID = DataGridViewRow.Cells("dgmeBlockID").Value.ToString()
                .VHID = DataGridViewRow.Cells("dgmeVHID").Value.ToString()
                .VHDetailcostCodeID = DataGridViewRow.Cells("dgmeVHDetailcostCodeID").Value.ToString()
                .StationID = DataGridViewRow.Cells("dgmeStationID").Value.ToString()
                .T0 = DataGridViewRow.Cells("dgmeT0").Value.ToString()
                .T1 = DataGridViewRow.Cells("dgmeT1").Value.ToString()
                .T2 = DataGridViewRow.Cells("dgmeT2").Value.ToString()
                .T3 = DataGridViewRow.Cells("dgmeT3").Value.ToString()
                .T4 = DataGridViewRow.Cells("dgmeT4").Value.ToString()
                .Description = DataGridViewRow.Cells("dgmeDescription").Value.ToString()
                If DataGridViewRow.Cells("dgmeCredit").Value.ToString() <> "" Then
                    .Credit = DataGridViewRow.Cells("dgmeCredit").Value.ToString()
                End If
                If DataGridViewRow.Cells("dgmeDebit").Value.ToString() <> "" Then
                    .Debit = DataGridViewRow.Cells("dgmeDebit").Value.ToString()
                End If


                If DataGridViewRow.Cells("dgmeAccJournalID").Value.ToString() <> String.Empty Then
                    ds = JournalBOL.UpDateJournal(ObjJournalPPT)
                Else
                    ds = JournalBOL.SaveJournal(ObjJournalPPT)
                End If

            End With

        Next


        If ds Is Nothing Then
            DisplayInfoMessage("Msg25")
            ''MsgBox("Failed to save database")
        Else
            Clear()
            ClearHeaderbox()
            BindDataGrid()
            ClearGridView(dgvMultipleEntry)
            DisplayInfoMessage("Msg26")
            ''MsgBox("Data(s) Successfully Updated!")
            lbtnAdd = "UpdatedtTable"
            GlobalPPT.IsRetainFocus = False
            'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        AddorSave = False
       
        If lbtnSave = "Save All" Then
            If IsSaveValid() Then Exit Sub
            If dgvMultipleEntry.Rows.Count = 0 Then
                DisplayInfoMessage("Msg27")
                ''MessageBox.Show(" Please Add Account Code", "Account code Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf Me.lbtnSave = "Save All" Then

                SaveDatas()
            End If
        Else
            UpdateRecords()
        End If

    End Sub
    Private Sub BindDataGrid()
        Try
            Dim objJournalPPT As New JournalPPT
            Dim dt As New DataTable
            Dim mdiparent As New MDIParent
            With objJournalPPT


                If mdiparent.strMenuID = "M110" Then
                    .lJournalDate = "01/01/1900"
                    .LedgerNo = AccountApprovalFrm.ApprovalLedgerNo
                    .Status = "N"
                Else
                    If chkJournalDate.Checked = True Then
                        dtpviewJournalDate.Enabled = True
                        .lJournalDate = Format(Me.dtpviewJournalDate.Value, "yyyy/MM/dd")
                    Else
                        dtpviewJournalDate.Enabled = False
                        .lJournalDate = "01/01/1900"
                    End If

                    If Me.ddlLedgerTypeSearch.Text <> "--Select--" Then
                        .LedgerType = Me.ddlLedgerTypeSearch.Text.Trim
                    End If

                    .LedgerNo = Me.txtLedgerNoSearch.Text.Trim
                    If cmbSearchStatus.Text = "Select All" Then
                        .Status = "S"
                    ElseIf cmbSearchStatus.Text = "OPEN" Then
                        .Status = "N"
                    Else
                        .Status = "Y"
                    End If
                End If



            End With

            dt = JournalBOL.GetJournal(objJournalPPT)
            If dt.Rows.Count <> 0 Then
                If mdiparent.strMenuID = "M110" Then
                    grpLedgerValues.Enabled = False
                    Me.txtLedgerNo.Text = dt.Rows(0).Item("LedgerNo")
                    Me.dtpJournalDate.Value = dt.Rows(0).Item("JournalDate")
                    Me.ddlLedgerType.Text = dt.Rows(0).Item("LedgerType")
                    Me.txtBatchTotal.Text = dt.Rows(0).Item("AccBatchTotal")
                    If dt.Rows(0).Item("ContractNo").ToString <> String.Empty Then
                        Me.txtContractNo.Text = dt.Rows(0).Item("ContractNo")
                        lblContractName.Text = dt.Rows(0).Item("ContractName")
                    End If
                    Me.txtJournalDescp.Text = dt.Rows(0).Item("Description")
                    lBatchTypeID = dt.Rows(0).Item("AccBatchID")
                Else
                    dgvJournalView.AutoGenerateColumns = False
                    Me.dgvJournalView.DataSource = dt

                End If

            Else
                ClearGridView(dgvJournalView) '''''clear the records from grid view
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


    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
        Clear()
        ClearHeaderbox()
        ClearGridView(dgvMultipleEntry)
        ' ClearGridView(DgDeleteRecord)
        BindDataGrid()
        Me.ddlLedgerType.Focus()
        lbtnAdd = "UpdatedtTable"
        ddlLedgerType.Focus()
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If btnClose.Enabled = False Then
            Me.Close()
        ElseIf dgvMultipleEntry.RowCount > 0 And btnSave.Visible = True Then
            If MsgBox(rm.GetString("Msg28"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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


    End Sub


    Private Sub tbJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbJournal.Click

        If dgvMultipleEntry.RowCount > 0 And btnSave.Enabled = True And btnSave.Visible = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tbJournal.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                Clear()
                ClearHeaderbox()
                chkJournalDate.Focus()
                ClearGridView(dgvMultipleEntry)
                BindDataGrid()
            End If
        Else
            Clear()
            ClearHeaderbox()
            chkJournalDate.Focus()
            ClearGridView(dgvMultipleEntry)
            BindDataGrid()



        End If
    End Sub

    Private Sub chkJournalDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkJournalDate.CheckedChanged
        If chkJournalDate.Checked = True Then
            Me.dtpviewJournalDate.Enabled = True
        Else
            Me.dtpviewJournalDate.Enabled = False
        End If

    End Sub


    Private Sub UpdateJournalView()

        If dgvJournalView.Rows.Count <> 0 Then

            If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSave.Enabled = True
                End If
            End If


            If GlobalPPT.strLang = "en" Then
                Me.btnSave.Text = "Update All"
            Else
                btnSave.Text = "Update Semua"
            End If

            lbtnSave = "UpdatedtTable "
            Me.lLedgerTypeID = Me.dgvJournalView.SelectedRows(0).Cells("dgclLedgerSetupID").Value.ToString
            Me.ddlLedgerType.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclLedgerType").Value.ToString
            Me.lBatchTypeID = Me.dgvJournalView.SelectedRows(0).Cells("dgclAccBatchID").Value.ToString
            Me.txtLedgerNo.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclLedgerNo").Value.ToString
            Me.txtBatchTotal.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclAccBatchTotal").Value
            Me.dtpJournalDate.Value = Me.dgvJournalView.SelectedRows(0).Cells("dgclJournalDate").Value.ToString
            Me.txtJournalDescp.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclJournalDescp").Value.ToString
            Me.psContractId = Me.dgvJournalView.SelectedRows(0).Cells("dgclContractID").Value.ToString
            Me.txtContractNo.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclContractNo").Value.ToString
            lRecuuringJournal = Me.dgvJournalView.SelectedRows(0).Cells("dgclRecuuringJournal").Value.ToString
            If lRecuuringJournal = "Y" Then
                chkRecurringJournals.Checked = True
            Else
                chkRecurringJournals.Checked = False
            End If
            Me.tbJournal.SelectedTab = tbAdd

            BindMultipleEntryDataGrid()
            ddlLedgerType.Enabled = False
            dtpJournalDate.Enabled = False
            txtLedgerNo.Enabled = False
            txtJournalDescp.Enabled = False

            txtContractNo.Enabled = True
            btnSearchContractNo.Enabled = True
            Me.lblStatusValue.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclStatus").Value.ToString

            If Me.dgvJournalView.SelectedRows(0).Cells("dgclStatus").Value.ToString = "APPROVED" Then
                btnSave.Visible = False
            Else
                btnSave.Visible = True
            End If


            lblRejectedReasonValue.Text = Me.dgvJournalView.SelectedRows(0).Cells("dgclRejectedReason").Value.ToString
            If lblRejectedReasonValue.Text <> String.Empty Then
                lblRecjectedReason.Visible = True
                lblColon.Visible = True
                lblRejectedReasonValue.Visible = True
            End If




        Else
            DisplayInfoMessage("Msg29")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'If Not objUserLoginBOl.Privilege(btnSave, ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub


    Private Sub dgvJournalView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvJournalView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvJournalView.ClearSelection()
                    Me.dgvJournalView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
       
        UpdateJournalView()
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim objJournalPPT As New JournalPPT
        Dim dt As New DataTable
        If dgvJournalView.Rows.Count > 0 Then
            If Me.dgvJournalView.SelectedRows(0).Cells("dgclStatus").Value.ToString() = "APPROVED" Then
                DisplayInfoMessage("Msg30")
                '' MessageBox.Show("User cannot Delete Approved Record", "BSP")
                Exit Sub
            End If

            ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalFrm))
            If MsgBox(rm.GetString("Msg31"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Me.lBatchTypeID = Me.dgvJournalView.SelectedRows(0).Cells("dgclAccBatchID").Value.ToString()
                With objJournalPPT
                    .AccBatchID = lBatchTypeID
                End With
                JournalBOL.DeleteJournal(objJournalPPT)
                JournalBOL.DeleteAccountBatch(objJournalPPT)
                BindDataGrid()
                DisplayInfoMessage("Msg32")
                ''MsgBox("Data Successfully Deleted !")
            End If
        Else
            DisplayInfoMessage("Msg33")
            ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If txtLedgerNoSearch.Text.Trim = String.Empty And chkJournalDate.Checked = False And ddlLedgerTypeSearch.Text = "--Select--" And cmbSearchStatus.Text = "OPEN" Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("Please Enter Criteria to Search!")
            BindDataGrid()
            Exit Sub
        Else
            BindDataGrid()
            If dgvJournalView.RowCount = 0 Then
                DisplayInfoMessage("Msg35")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If

    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        'If Not objUserLoginBOl.Privilege(btnSave, ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        Clear()
        Me.tbJournal.SelectedTab = tbAdd

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtT0.Text = "" Then
            Me.txtT0.Text = GlobalPPT.strEstateCode
        End If


        AddorSave = True
        If Me.lbtnAdd = "Add" Or lbtnAdd = "UpdatedtTable" Then
            If IsSaveValid() = False Then
                AddMultipleEntryData()
                dgvMultipleEntry.AutoGenerateColumns = False
                CreditDebitAmount()
            Else
                Exit Sub
            End If
        Else
            If IsSaveValid() = False Then
                dgvMultipleEntry.AutoGenerateColumns = False
                UpdateMultipleDataEntryValue()
                CreditDebitAmount()
            Else
                Exit Sub
            End If
        End If

        AddorSave = False

    End Sub
    Private Sub MultipleDateEntryValues()

        If dgvMultipleEntry.Rows.Count > 0 Then
            grpLedgerValues.Enabled = False

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            Else
                btnAdd.Text = "Memperbarui"
            End If
            lbtnAdd = "Update"

            If Not lbtnSave = "Save All" Then
                If dgvMultipleEntry.SelectedRows(0).Cells("dgMeAccJournalID").Value IsNot Nothing Or dgvMultipleEntry.SelectedRows(0).Cells("dgMeAccJournalID").Value.ToString <> String.Empty Then
                    Me.lAccJournalID = dgvMultipleEntry.SelectedRows(0).Cells("dgMeAccJournalID").Value.ToString
                End If
            End If

            Me.lCOAID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeCOAID").Value.ToString
            Me.txtAccountCode.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeCOACode").Value.ToString
            lAccountCode = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeCOACode").Value.ToString
            Me.lblAccountDescp.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeCOADescp").Value.ToString
            Me.lblOldAccountCode.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeOldCOACode").Value.ToString
            Me.txtDescp.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeDescription").Value.ToString
            If Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeBlockID").Value.ToString <> String.Empty Then
                psBlockID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeBlockID").Value.ToString
                Me.txtSubBlock.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("DgMeSubBlock").Value.ToString
                Me.lblBlockStatus.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeBlockStatus").Value.ToString
                psYopID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeYOPID").Value.ToString
                Me.txtYOP.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("DgMeYOP").Value
                Me.lblYOPName.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeYOPName").Value.ToString
            End If
            If Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeDivID").Value.ToString <> String.Empty Then
                psDivID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeDivID").Value.ToString
                Me.txtDiv.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeDiv").Value.ToString
                Me.lblDivName.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeDivName").Value.ToString
            End If

            'If psStationID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMestationID").Value.ToString <> String.Empty Then
            psStationID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMestationID").Value.ToString
            Me.txtStation.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMestationCode").Value.ToString
            Me.lblStationDescp.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeStationDescp").Value.ToString
            ' End If

            If Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVHID").Value.ToString <> String.Empty Then
                psVHID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVHID").Value.ToString
                Me.txtVehicleCode.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVHWSCode").Value.ToString
                Me.lblVehicleDescp.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVehicleDescp").Value
            End If

            If Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVHDetailCostCodeID").Value.ToString <> String.Empty Then
                psVHDetailCostCodeID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVHDetailCostCodeID").Value.ToString
                Me.txtDetailCostCode.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeVhDetailCostCode").Value.ToString
                Me.lblDetailCostDescp.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgVHDetailCostDescp").Value.ToString
            End If


            Me.psT0analysisID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeT0").Value.ToString
            Me.psT1analysisID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeT1").Value.ToString
            Me.psT2analysisID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeT2").Value.ToString
            Me.psT3analysisID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeT3").Value.ToString
            Me.psT4analysisID = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeT4").Value.ToString

            Me.txtT0.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode0").Value.ToString
            Me.txtT1.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode1").Value.ToString
            Me.txtT2.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode2").Value.ToString
            Me.txtT3.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode3").Value.ToString
            Me.txtT4.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisCode4").Value.ToString

            Me.lblT0Name.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp0").Value.ToString
            Me.lblT1Name.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp1").Value.ToString
            Me.lblT2Name.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp2").Value.ToString
            Me.lblT3Name.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp3").Value.ToString
            Me.lblT4Name.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeTAnalysisDescp4").Value.ToString


            If Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeCredit").Value Is DBNull.Value Then
                Me.txtCreditKeenValue.Text = ""
                Me.txtDebitKeenValue.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeDebit").Value
            Else
                Me.txtCreditKeenValue.Text = Me.dgvMultipleEntry.SelectedRows(0).Cells("dgMeCredit").Value
                Me.txtDebitKeenValue.Text = ""
            End If



        Else
            DisplayInfoMessage("Msg36")
            '' MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'If Not objUserLoginBOl.Privilege(btnSave, ToolStripMenuItem1, ToolStripMenuItem2, ToolStripMenuItem3, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If


    End Sub

    Private Sub AddMultipleEntryData()

        Dim intRowcount As Integer = dtjournal.Rows.Count
        Dim objJournalPPT As New JournalPPT
        Dim ObjJournalBOL As New JournalBOL
        Dim objCheckDuplicateRecord As Object = 0
        objJournalPPT.COACode = Me.txtAccountCode.Text.Trim
        Try

            If Me.txtAccountCode.Text = "" Then
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Account Code Required", "Account Code")
                txtAccountCode.Focus()
                Exit Sub
            End If
            If txtDebitKeenValue.Text = "" And txtCreditKeenValue.Text = "" Then
                DisplayInfoMessage("Msg38")
                ''MessageBox.Show("Either Debit or Credit Should be Keyed in", "Debit/Credit")
                txtDebitKeenValue.Focus()
                Exit Sub
            End If

            If txtLedgerNo.Enabled = True Then

                With objJournalPPT
                    .LedgerNo = Me.txtLedgerNo.Text
                End With

                objCheckDuplicateRecord = ObjJournalBOL.DuplicateJournalCheck(objJournalPPT)
                If (objCheckDuplicateRecord = 0) Then
                    DisplayInfoMessage("Msg39")
                    ''MessageBox.Show("Ledger No Already Exists ! Please enter different Ledger No ")
                    txtLedgerNo.Focus()
                    Exit Sub
                End If
            End If
            If Not AccountCodeExist(objJournalPPT.COACode) Then
                rowMultipleEntryAdd = dtjournal.NewRow()
                If intRowcount = 0 And lbtnAdd = "Add" Then
                    Try
                        'Add the Data column to the datatable first time 
                        columnJournalAdd = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("COACode", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("Div", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("DivName", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("YOP", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("YOPName", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("BlockName", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("BlockStatus", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("DivID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("YOPID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("BlockID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("VHWSCode", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("VehicleDescp", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("VHDetailCostCode", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("VHDetailCostDescp", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("Stationcode", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("StationDescp", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("VHID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("VHDetailCostCodeID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("StationID", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisCode0", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisCode1", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisCode2", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisCode3", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisCode4", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("T0", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("T1", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("T2", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("T3", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("T4", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisDescp0", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisDescp1", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisDescp2", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisDescp3", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("TAnalysisDescp4", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("Debit", System.Type.[GetType]("System.Decimal"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("Credit", System.Type.[GetType]("System.Decimal"))
                        dtjournal.Columns.Add(columnJournalAdd)
                        columnJournalAdd = New DataColumn("Description", System.Type.[GetType]("System.String"))
                        dtjournal.Columns.Add(columnJournalAdd)



                        rowMultipleEntryAdd("COACode") = txtAccountCode.Text.Trim()
                        rowMultipleEntryAdd("COAID") = lCOAID
                        rowMultipleEntryAdd("COADescp") = lblAccountDescp.Text.Trim()
                        rowMultipleEntryAdd("Description") = txtDescp.Text.Trim()



                        rowMultipleEntryAdd("OldCOACode") = lblOldAccountCode.Text.Trim
                        rowMultipleEntryAdd("Div") = txtDiv.Text.Trim()
                        rowMultipleEntryAdd("YOP") = txtYOP.Text.Trim()
                        rowMultipleEntryAdd("BlockName") = txtSubBlock.Text.Trim()
                        rowMultipleEntryAdd("DivName") = lblDivName.Text
                        rowMultipleEntryAdd("YOPName") = lblYOPName.Text
                        rowMultipleEntryAdd("BlockStatus") = lblBlockStatus.Text
                        rowMultipleEntryAdd("DivID") = psDivID
                        rowMultipleEntryAdd("YOPID") = psYopID
                        rowMultipleEntryAdd("BlockID") = psBlockID
                        rowMultipleEntryAdd("VHWSCode") = txtVehicleCode.Text.Trim()
                        rowMultipleEntryAdd("VHDetailCostCode") = txtDetailCostCode.Text.Trim()
                        rowMultipleEntryAdd("StationCode") = txtStation.Text.Trim()
                        rowMultipleEntryAdd("VehicleDescp") = lblVehicleDescp.Text
                        rowMultipleEntryAdd("VHDetailCostDescp") = lblDetailCostDescp.Text
                        rowMultipleEntryAdd("StationDescp") = lblStationDescp.Text
                        rowMultipleEntryAdd("VHID") = psVHID
                        rowMultipleEntryAdd("VHDetailCostCodeID") = psVHDetailCostCodeID
                        rowMultipleEntryAdd("StationID") = psStationID
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


                        If txtCreditKeenValue.Text <> String.Empty Then
                            rowMultipleEntryAdd("Credit") = txtCreditKeenValue.Text.Trim()
                        Else
                            rowMultipleEntryAdd("Credit") = DBNull.Value

                        End If

                        If txtDebitKeenValue.Text <> String.Empty Then
                            rowMultipleEntryAdd("Debit") = txtDebitKeenValue.Text.Trim()
                        Else
                            rowMultipleEntryAdd("Debit") = DBNull.Value

                        End If


                        dtjournal.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                        lbtnAdd = "UpdatedtTable"
                        grpLedgerValues.Enabled = False
                        dgvMultipleEntry.AutoGenerateColumns = False
                    Catch
                        rowMultipleEntryAdd("COACode") = txtAccountCode.Text.Trim()
                        rowMultipleEntryAdd("COAID") = lCOAID
                        rowMultipleEntryAdd("COADescp") = lblAccountDescp.Text.Trim()
                        rowMultipleEntryAdd("OldCOACode") = lblOldAccountCode.Text.Trim
                        rowMultipleEntryAdd("Description") = txtDescp.Text.Trim()

                        rowMultipleEntryAdd("Div") = txtDiv.Text.Trim()
                        rowMultipleEntryAdd("YOP") = txtYOP.Text.Trim()
                        rowMultipleEntryAdd("BlockName") = txtSubBlock.Text.Trim()
                        rowMultipleEntryAdd("DivName") = lblDivName.Text
                        rowMultipleEntryAdd("YOPName") = lblYOPName.Text
                        rowMultipleEntryAdd("BlockStatus") = lblBlockStatus.Text
                        rowMultipleEntryAdd("DivID") = psDivID
                        rowMultipleEntryAdd("YOPID") = psYopID
                        rowMultipleEntryAdd("BlockID") = psBlockID
                        rowMultipleEntryAdd("VHWSCode") = txtVehicleCode.Text.Trim()
                        rowMultipleEntryAdd("VHDetailCostCode") = txtDetailCostCode.Text.Trim()
                        rowMultipleEntryAdd("StationCode") = txtStation.Text.Trim()
                        rowMultipleEntryAdd("VehicleDescp") = lblVehicleDescp.Text
                        rowMultipleEntryAdd("VHDetailCostDescp") = lblDetailCostDescp.Text
                        rowMultipleEntryAdd("StationDescp") = lblStationDescp.Text
                        rowMultipleEntryAdd("VHID") = psVHID
                        rowMultipleEntryAdd("VHDetailCostCodeID") = psVHDetailCostCodeID
                        rowMultipleEntryAdd("StationID") = psStationID
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


                        If txtCreditKeenValue.Text <> String.Empty Then
                            rowMultipleEntryAdd("Credit") = txtCreditKeenValue.Text.Trim()
                        Else
                            rowMultipleEntryAdd("Credit") = DBNull.Value

                        End If

                        If txtDebitKeenValue.Text <> String.Empty Then
                            rowMultipleEntryAdd("Debit") = txtDebitKeenValue.Text.Trim()
                        Else
                            rowMultipleEntryAdd("Debit") = DBNull.Value

                        End If

                        dtjournal.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                        lbtnAdd = "UpdatedtTable"
                        grpLedgerValues.Enabled = False
                        dgvMultipleEntry.AutoGenerateColumns = False
                    End Try
                Else

                    rowMultipleEntryAdd("COACode") = txtAccountCode.Text.Trim()
                    rowMultipleEntryAdd("COAID") = lCOAID
                    rowMultipleEntryAdd("COADescp") = lblAccountDescp.Text.Trim()
                    rowMultipleEntryAdd("OldCOACode") = lblOldAccountCode.Text.Trim
                    rowMultipleEntryAdd("Description") = txtDescp.Text.Trim()

                    rowMultipleEntryAdd("Div") = txtDiv.Text.Trim()
                    rowMultipleEntryAdd("YOP") = txtYOP.Text.Trim()
                    rowMultipleEntryAdd("BlockName") = txtSubBlock.Text.Trim()
                    rowMultipleEntryAdd("DivName") = lblDivName.Text
                    rowMultipleEntryAdd("YOPName") = lblYOPName.Text
                    rowMultipleEntryAdd("BlockStatus") = lblBlockStatus.Text
                    rowMultipleEntryAdd("DivID") = psDivID
                    rowMultipleEntryAdd("YOPID") = psYopID
                    rowMultipleEntryAdd("BlockID") = psBlockID
                    rowMultipleEntryAdd("VHWSCode") = txtVehicleCode.Text.Trim()
                    rowMultipleEntryAdd("VHDetailCostCode") = txtDetailCostCode.Text.Trim()
                    rowMultipleEntryAdd("StationCode") = txtStation.Text.Trim()
                    rowMultipleEntryAdd("VehicleDescp") = lblVehicleDescp.Text
                    rowMultipleEntryAdd("VHDetailCostDescp") = lblDetailCostDescp.Text
                    rowMultipleEntryAdd("StationDescp") = lblStationDescp.Text
                    rowMultipleEntryAdd("VHID") = psVHID
                    rowMultipleEntryAdd("VHDetailCostCodeID") = psVHDetailCostCodeID
                    rowMultipleEntryAdd("StationID") = psStationID
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

                    If txtCreditKeenValue.Text <> String.Empty Then
                        rowMultipleEntryAdd("Credit") = txtCreditKeenValue.Text.Trim()
                    Else
                        rowMultipleEntryAdd("Credit") = DBNull.Value

                    End If

                    If txtDebitKeenValue.Text <> String.Empty Then
                        rowMultipleEntryAdd("Debit") = txtDebitKeenValue.Text.Trim()
                    Else
                        rowMultipleEntryAdd("Debit") = DBNull.Value

                    End If

                    dtjournal.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                    grpLedgerValues.Enabled = False
                End If

                dgvMultipleEntry.DataSource = dtjournal
                dgvMultipleEntry.AutoGenerateColumns = False
                Clear()

            Else
                DisplayInfoMessage("Msg40")
                ''MsgBox("The Account Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub BindMultipleEntryDataGrid()
        Try
            Dim objJournalPPT As New JournalPPT
            Dim objJournalBOL As New JournalBOL


            With objJournalPPT
                .AccBatchID = lBatchTypeID
            End With

            dtjournal = JournalBOL.GetMultipleEntryValue(objJournalPPT)
            If dtjournal.Rows.Count <> 0 Then

                dgvMultipleEntry.AutoGenerateColumns = False
                Me.dgvMultipleEntry.DataSource = dtjournal
            End If
            CreditDebitAmount()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'Private Sub LedgerNoExist(ByVal LedgerNo As String)
    '    Try
    '        Dim objDataGridViewRow As New DataGridViewRow
    '        'For Each objDataGridViewRow In dgvJournalView.Rows
    '        '    If LedgerNo = objDataGridViewRow.Cells("DgclLedgerNo").Value.ToString() Then
    '        '        txtLedgerNo.Text = String.Empty
    '        '        txtLedgerNo.Focus()
    '        '        MsgBox("Ledger no already Exists !,Please enter Different Ledger No")
    '        '        Exit Sub
    '        '    End If
    '        'Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message())
    '    End Try
    'End Sub

    Private Function AccountCodeExist(ByVal AccountCode As String) As Boolean
        'Sai Overwrite
        'Try
        '    Dim objDataGridViewRow As New DataGridViewRow
        '    For Each objDataGridViewRow In dgvMultipleEntry.Rows
        '        If AccountCode = objDataGridViewRow.Cells("DgMeCOACode").Value.ToString() Then
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

    Private Sub UpdateMultipleDataEntryValue()

        Dim objJournalPPT As New JournalPPT
        Dim ObjJournalBOL As New JournalBOL
        objJournalPPT.COACode = Me.txtAccountCode.Text.Trim


        If Me.txtAccountCode.Text = "" Then
            DisplayInfoMessage("Msg41")
            ''MessageBox.Show("Account Code Required", "Account Code")
            txtAccountCode.Focus()
            Exit Sub
        End If
        If txtDebitKeenValue.Text = "" And txtCreditKeenValue.Text = "" Then
            DisplayInfoMessage("Msg42")
            ''MessageBox.Show("Either Debit or Credit Should be Keyed in", "Debit/Credit")
            txtDebitKeenValue.Focus()
            Exit Sub
        End If

        If lAccountCode = Me.txtAccountCode.Text.Trim Then
            Dim intCount As Integer = dgvMultipleEntry.CurrentRow.Index
            dgvMultipleEntry.Rows(intCount).Cells("dgMeAccJournalID").Value = lAccJournalID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeCOACode").Value = txtAccountCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeOldCOACode").Value = lblOldAccountCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgmeCOAID").Value = lCOAID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeCOADescp").Value = lblAccountDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDescription").Value = txtDescp.Text.Trim
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDivID").Value = psDivID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeYOPID").Value = psYopID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeBlockID").Value = psBlockID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDiv").Value = txtDiv.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeYOP").Value = txtYOP.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeSubBlock").Value = txtSubBlock.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDivName").Value = lblDivName.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeYOPName").Value = lblYOPName.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeBlockStatus").Value = lblBlockStatus.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVehicleDescp").Value = lblVehicleDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgVHDetailCostDescp").Value = lblDetailCostDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeStationDescp").Value = lblStationDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHID").Value = psVHID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHDetailCostCodeID").Value = psVHDetailCostCodeID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeStationID").Value = psStationID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHWSCode").Value = txtVehicleCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHDetailCostCode").Value = txtDetailCostCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeStationCode").Value = txtStation.Text

            dgvMultipleEntry.Rows(intCount).Cells("dgMeT0").Value = psT0analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT1").Value = psT1analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT2").Value = psT2analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT3").Value = psT3analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT4").Value = psT4analysisID

            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode0").Value = txtT0.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode1").Value = txtT1.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode2").Value = txtT2.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode3").Value = txtT3.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode4").Value = txtT4.Text

            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp0").Value = lblT0Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp1").Value = lblT1Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp2").Value = lblT2Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp3").Value = lblT3Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp4").Value = lblT4Name.Text


            If txtCreditKeenValue.Text <> String.Empty Then
                dgvMultipleEntry.Rows(intCount).Cells("DgMeCredit").Value = txtCreditKeenValue.Text
                dgvMultipleEntry.Rows(intCount).Cells("DgMeDebit").Value = DBNull.Value
            End If

            If txtDebitKeenValue.Text <> String.Empty Then
                dgvMultipleEntry.Rows(intCount).Cells("DgMeDebit").Value = txtDebitKeenValue.Text
                dgvMultipleEntry.Rows(intCount).Cells("DgMeCredit").Value = DBNull.Value
            End If

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            Else
                btnAdd.Text = "Menambahkan"
            End If
            lbtnAdd = "Add"
            Clear()

        ElseIf Not AccountCodeExist(objJournalPPT.COACode) Then

            Dim intCount As Integer = dgvMultipleEntry.CurrentRow.Index
            dgvMultipleEntry.Rows(intCount).Cells("dgMeAccJournalID").Value = lAccJournalID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeCOACode").Value = txtAccountCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeOldCOACode").Value = lblOldAccountCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgmeCOAID").Value = lCOAID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeCOADescp").Value = lblAccountDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDivID").Value = psDivID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeYOPID").Value = psYopID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeBlockID").Value = psBlockID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDiv").Value = txtDiv.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeYOP").Value = txtYOP.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeSubBlock").Value = txtSubBlock.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeDivName").Value = lblDivName.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeYOPName").Value = lblYOPName.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeBlockStatus").Value = lblBlockStatus.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVehicleDescp").Value = lblVehicleDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgVHDetailCostDescp").Value = lblDetailCostDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeStationDescp").Value = lblStationDescp.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHID").Value = psVHID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHDetailCostCodeID").Value = psVHDetailCostCodeID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeStationID").Value = psStationID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHWSCode").Value = txtVehicleCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeVHDetailCostCode").Value = txtDetailCostCode.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeStationCode").Value = txtStation.Text

            dgvMultipleEntry.Rows(intCount).Cells("dgMeT0").Value = psT0analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT1").Value = psT1analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT2").Value = psT2analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT3").Value = psT3analysisID
            dgvMultipleEntry.Rows(intCount).Cells("dgMeT4").Value = psT4analysisID

            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode0").Value = txtT0.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode1").Value = txtT1.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode2").Value = txtT2.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode3").Value = txtT3.Text
            dgvMultipleEntry.Rows(intCount).Cells("DgMeTAnalysisCode4").Value = txtT4.Text

            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp0").Value = lblT0Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp1").Value = lblT1Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp2").Value = lblT2Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp3").Value = lblT3Name.Text
            dgvMultipleEntry.Rows(intCount).Cells("dgMeTAnalysisDescp4").Value = lblT4Name.Text

            If txtCreditKeenValue.Text <> String.Empty Then
                dgvMultipleEntry.Rows(intCount).Cells("DgMeCredit").Value = txtCreditKeenValue.Text
                dgvMultipleEntry.Rows(intCount).Cells("DgMeDebit").Value = DBNull.Value
            End If

            If txtDebitKeenValue.Text <> String.Empty Then
                dgvMultipleEntry.Rows(intCount).Cells("DgMeDebit").Value = txtDebitKeenValue.Text
                dgvMultipleEntry.Rows(intCount).Cells("DgMeCredit").Value = DBNull.Value
            End If
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            Else
                btnAdd.Text = "Menambahkan"
            End If
            lbtnAdd = "Add"
            Clear()
        Else
            DisplayInfoMessage("Msg43")
            ''MsgBox("The Account Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
        End If


    End Sub

    Private Sub btnDivSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDivSearch.Click
        Cursor = Cursors.WaitCursor
        Dim frmDivLookup As New DivLookup
        frmDivLookup.BindDIV(psBlockID)
        Dim result As DialogResult = frmDivLookup.ShowDialog()
        If frmDivLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtDiv.Text = frmDivLookup.psDIV
            Me.lblDivName.Text = frmDivLookup.psDIVName
            psDivID = frmDivLookup.psDIVID
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtDiv_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiv.Leave
        If txtDiv.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objJournalPPT As New JournalPPT
            Dim ObjJournalBOL As New JournalBOL
            objJournalPPT.Div = txtDiv.Text.Trim()
            objJournalPPT.BlockID = psBlockID
            ds = ObjJournalBOL.GetDIV(objJournalPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg44")
                ''MessageBox.Show("This block does not belongs to selected division,Please Choose it from look up")
                txtDiv.Text = String.Empty
                lblDivName.Text = String.Empty
                psDivID = String.Empty
                txtDiv.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDiv.Text = ds.Tables(0).Rows(0).Item("Div")
                End If
                If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
                    Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
                End If
                psDivID = ds.Tables(0).Rows(0).Item("DivID")
            End If
        Else
            txtDiv.Text = String.Empty
            lblDivName.Text = String.Empty
            psDivID = String.Empty
        End If
    End Sub

    Private Sub txtVehicleCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.TextChanged
        If txtVehicleCode.Text <> String.Empty Then
            txtSubBlock.Text = String.Empty
            txtSubBlock.Enabled = False
            lblBlockStatus.Text = String.Empty
            txtYOP.Text = String.Empty
            txtDiv.Text = String.Empty
            txtDiv.Enabled = False
            lblDivName.Text = String.Empty
            btnSearchSubBlock.Enabled = False
            btnDivSearch.Enabled = False
        ElseIf txtStation.Enabled = False Then
            txtSubBlock.Enabled = True
            txtDiv.Enabled = True
            btnSearchSubBlock.Enabled = True
            btnDivSearch.Enabled = True
        End If

        If Me.txtVehicleCode.Text = String.Empty Then
            Me.txtDetailCostCode.Text = String.Empty
            Me.lblDetailCostDescp.Text = String.Empty
            Me.txtDetailCostCode.Enabled = False
            Me.btnSearchVehicleDetailCostCode.Enabled = False
        Else
            Me.txtDetailCostCode.Enabled = True
            Me.btnSearchVehicleDetailCostCode.Enabled = True
        End If
        Me.txtDetailCostCode.Text = String.Empty
        Me.lblDetailCostDescp.Text = String.Empty
        psVHDetailCostCodeID = String.Empty

    End Sub

    Private Sub btnResetMultipleEntryGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMultipleEntryGrp.Click
        Clear()

        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        Else
            btnAdd.Text = "Menambahkan"
        End If

        'lbtnAdd = "Add"
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MultipleDateEntryValues()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Clear()
        Me.txtAccountCode.Focus()
    End Sub


    Private Sub dgvMultipleEntry_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMultipleEntry.CellDoubleClick
        MultipleDateEntryValues()
    End Sub

    Private Sub dgvJournalView_CellDoubleClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        UpdateJournalView()
    End Sub

    Private Sub txtT4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        If txtT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim ObjJournal As New JournalPPT
            ObjJournal.T4Value = txtT4.Text.Trim()
            ObjJournal.TDecide = "T4"
            Dim ObjJournalBOL As New JournalBOL
            ds = ObjJournalBOL.TlookupSearch(ObjJournal, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg45")
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


    Private Sub txtSubBlock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.TextChanged
        If txtSubBlock.Text <> String.Empty Then
            txtVehicleCode.Text = String.Empty
            txtDetailCostCode.Text = String.Empty
            txtVehicleCode.Enabled = False
            txtDetailCostCode.Enabled = False
            btnSearchVehicleDetailCostCode.Enabled = False
            btnSearchVehicleCode.Enabled = False
        Else
            txtVehicleCode.Enabled = True
            txtDetailCostCode.Enabled = True
            btnSearchVehicleDetailCostCode.Enabled = True
            btnSearchVehicleCode.Enabled = True
        End If
    End Sub

    Private Sub txtAccountCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.TextChanged
        If txtAccountCode.Text <> String.Empty Then
            txtSubBlock.Text = String.Empty
            txtYOP.Text = String.Empty
            txtDiv.Text = String.Empty
            psBlockID = String.Empty
            psYopID = String.Empty
            psDivID = String.Empty
            lblBlockStatus.Text = String.Empty
            lblYOPName.Text = String.Empty
            lblDivName.Text = String.Empty
        End If
    End Sub

    Private Sub dgvJournalView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvJournalView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateJournalView()
            End If
        End If

    End Sub

    Private Sub dgvMultipleEntry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMultipleEntry.KeyDown
        If e.KeyCode = Keys.Return Then
            MultipleDateEntryValues()
            e.Handled = True
        End If
    End Sub


    Private Sub dgvJournalView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvJournalView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateJournalView()
            e.Handled = True
        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim ObjRecordExist As New DataTable
        Dim ObjjournalPPT As New JournalPPT
        ObjjournalPPT.lJournalDate = "01/01/1900"
        ObjjournalPPT.Status = "S"
        ObjRecordExist = JournalBOL.GetJournal(ObjjournalPPT)
        If ObjRecordExist.Rows.Count = 0 Then
            DisplayInfoMessage("Msg46")
            ''MsgBox("No Record(s) Available!")
        Else

            StrFrmName = "Journal"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If
    End Sub

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click

        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalFrm))
        If MsgBox(rm.GetString("Msg47"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            '' If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            If cmbStatus.Text = "APPROVED" Then
                ApprovalDetails()
                Close()
            ElseIf cmbStatus.Text = "REJECTED" Then
                If txtRejectedReason.Text.Trim = String.Empty Then
                    DisplayInfoMessage("Msg48")
                    ''MsgBox("Please Keying the Rejected Reason!")
                    Exit Sub
                End If

                Dim ObjjournalPPT As New JournalPPT
                Dim ObjjournalBOL As New JournalBOL

                With ObjjournalPPT
                    .AccBatchID = Me.lBatchTypeID
                    .Status = "N"
                    .RejectedReason = txtRejectedReason.Text.Trim
                    .JournalDate = dtpJournalDate.Value
                End With
                JournalBOL.UpdateAccountBatch(ObjjournalPPT, "YES")
                DisplayInfoMessage("Msg49")
                ''MsgBox("Record Rejected Successfully")
                Close()
                Exit Sub

            End If
        End If
    End Sub

    Private Sub ApprovalDetails()


        '1st Step Update AccountBatch Table Status
        Try
            Dim Int As New Integer
            ' For Each DataGridViewRow In dgvMultipleEntry.Rows
            Dim ObjjournalPPT As New JournalPPT
            Dim ObjjournalBOL As New JournalBOL
            With ObjjournalPPT
                .AccBatchID = lBatchTypeID
                .JournalDate = dtpJournalDate.Value
                .Status = "Y"
            End With
            Int = JournalBOL.UpdateAccountBatch(ObjjournalPPT, "YES")
            DisplayInfoMessage("Msg50")
            ''MessageBox.Show("Approved Successfully")

        Catch ex As Exception
            DisplayInfoMessage("Msg51")
            ''MsgBox("Transaction  Failed")
            Exit Sub

        End Try
        ' Next


        '  Close()

        Try
            Dim ObjjournalPPT As New JournalPPT
            Dim ObjjournalBOL As New JournalBOL
            ''Step 2 Accounts.Ledgerallmodule insert 

            ObjjournalPPT.AYear = GlobalPPT.intActiveYear
            ObjjournalPPT.Amonth = GlobalPPT.IntActiveMonth
            ObjjournalPPT.LedgerDate = dtpJournalDate.Value
            ObjjournalPPT.LedgerType = ddlLedgerType.Text
            ObjjournalPPT.JournalDescp = txtJournalDescp.Text
            ObjjournalPPT.BatchTotal = txtBatchTotal.Text
            ObjjournalPPT.LedgerNo = txtLedgerNo.Text

            Dim dsRowsAffectedLedgerAllModule As New DataSet
            dsRowsAffectedLedgerAllModule = ObjjournalBOL.JournalLedgerAllModuleInsert(ObjjournalPPT)
            psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
            ObjjournalPPT.LedgerID = psLedgerID

        Catch ex As Exception
            DisplayInfoMessage("Msg51")
            ''MsgBox("Transaction  Failed")
            Exit Sub
        End Try
        ''Step 3 Accounts JournalDetail Insert

        Try


            'Dim intJournalRowsAffected As Integer = 0
            For Each GridViewRow In dgvMultipleEntry.Rows
                If GridViewRow.Cells("dgMeCOAID").Value.ToString() <> String.Empty Then
                    Dim ObjjournalPPT As New JournalPPT
                    Dim ObjjournalBOL As New JournalBOL
                    With ObjjournalPPT
                        .AYear = GlobalPPT.intActiveYear
                        .Amonth = GlobalPPT.IntActiveMonth
                        .LedgerID = psLedgerID
                        .COAID = GridViewRow.Cells("dgMeCOAID").Value.ToString()
                        If GridViewRow.cells("DgMeCredit").value.ToString() <> String.Empty Then
                            .DC = "C"
                            .Value = GridViewRow.cells("DgMeCredit").value.ToString()
                        Else
                            .DC = "D"
                            .Value = GridViewRow.cells("DgMeDebit").value.ToString()
                        End If
                        .Flag = "AccJournal Price"
                        .COADescp = GridViewRow.Cells("dgMeDescription").Value.ToString()
                        .DivID = GridViewRow.Cells("dgMeDivId").Value.ToString()
                        .YOPID = GridViewRow.Cells("dgMeYOPID").Value.ToString()
                        .BlockID = GridViewRow.Cells("DgMeBlockID").Value.ToString()
                        .VHID = GridViewRow.Cells("dgMeVHID").Value.ToString()
                        .VHDetailcostCodeID = GridViewRow.Cells("dgMeVHDetailCostCodeID").Value.ToString()
                        .T0 = GridViewRow.Cells("dgMeT0").Value.ToString()
                        .T1 = GridViewRow.Cells("dgMeT1").Value.ToString()
                        .T2 = GridViewRow.Cells("dgMeT2").Value.ToString()
                        .T3 = GridViewRow.Cells("dgMeT3").Value.ToString()
                        .T4 = GridViewRow.Cells("dgMeT4").Value.ToString()
                        .StationID = GridViewRow.Cells("DgMeStationID").Value.ToString()
                    End With
                    Dim IntJournalDetail As New Integer
                    IntJournalDetail = JournalBOL.AccountsJournalDetailInsert(ObjjournalPPT)
                End If
            Next
        Catch ex As Exception
            DisplayInfoMessage("Msg52")
            ''MsgBox("Approved Failed")
            Exit Sub
        End Try
        ''Step 4 Accounts VHCharge Detail Insert
        Try


            For Each GridViewRow In dgvMultipleEntry.Rows
                If GridViewRow.Cells("dgMeVHWSCode").Value.ToString() <> String.Empty Then
                    Dim ObjjournalPPT As New JournalPPT
                    Dim ObjjournalBOL As New JournalBOL
                    With ObjjournalPPT

                        .VHWScode = GridViewRow.Cells("dgMeVHWSCode").Value.ToString()

                        Dim dsEstCode As New DataSet
                        dsEstCode = ObjjournalBOL.VHChargedetailLocationEstateCodeSelect(ObjjournalPPT)

                        If dsEstCode.Tables(0).Rows.Count = 0 Then
                            .EstateCodeL = GlobalPPT.strEstateIDCode
                        Else
                            .EstateCodeL = dsEstCode.Tables(0).Rows(0).Item("LocEstateCode").ToString
                        End If

                        .VHDetailCostCode = GridViewRow.Cells("dgMeVHDetailCostCode").Value.ToString()
                        .Type = GridViewRow.Cells("dgmeVHType").Value.ToString()
                        '.Type = "V"
                        .AYear = GlobalPPT.intActiveYear
                        .Amonth = GlobalPPT.IntActiveMonth
                        .LedgerType = ddlLedgerType.Text
                        .LedgerNo = txtLedgerNo.Text
                        .COAID = GridViewRow.Cells("dgMeCOAID").Value.ToString()
                        If GridViewRow.cells("DgMeCredit").value.ToString() <> String.Empty Then
                            .Value = -(GridViewRow.cells("DgMeCredit").value.ToString())
                        Else
                            .Value = GridViewRow.cells("DgMeDebit").value.ToString()
                        End If
                        .JournalDescp = GridViewRow.Cells("dgMeDescription").Value.ToString()
                        .Qty = 0
                        .UOMID = ""
                        .RefNo = .LedgerNo
                    End With
                    Dim IntVHChargeDetail As New Integer
                    IntVHChargeDetail = JournalBOL.AccountsVHChargeDetailInsert(ObjjournalPPT)
                End If
            Next
        Catch ex As Exception
            DisplayInfoMessage("Msg52")
            ''MsgBox("Approved Failed")
            Exit Sub
        End Try

        ''Step 5 Accounts GLLedger Update( Insert was done during the insertion of COAID Record in Accounts.COA) 
        Try


            For Each GridViewRow In dgvMultipleEntry.Rows
                If GridViewRow.Cells("dgMeCOAID").Value.ToString() <> String.Empty Then
                    Dim ObjjournalPPT As New JournalPPT
                    Dim ObjjournalBOL As New JournalBOL
                    With ObjjournalPPT
                        .AYear = GlobalPPT.intActiveYear
                        .Amonth = GlobalPPT.IntActiveMonth
                        .COAID = GridViewRow.Cells("dgMeCOAID").Value.ToString()
                        If GridViewRow.cells("DgMeCredit").value.ToString() <> String.Empty Then
                            .Credit = GridViewRow.cells("DgMeCredit").value.ToString()
                            .Debit = 0
                        Else
                            .Debit = GridViewRow.cells("DgMeDebit").value.ToString()
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
                        ' ObjjournalPPT.GLLedgerID = dtGLLedger.Rows(0).Item("GLLedgerID")
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
            DisplayInfoMessage("Msg52")
            ''MsgBox("Approved Failed")
            Exit Sub
        End Try

        Try


            ''Step 6 Accounts GLSub Insert
            For Each GridViewRow In dgvMultipleEntry.Rows
                If GridViewRow.Cells("dgMeBlockID").Value.ToString() <> String.Empty Then
                    Dim ObjjournalPPT As New JournalPPT
                    Dim ObjjournalBOL As New JournalBOL
                    With ObjjournalPPT
                        .AYear = GlobalPPT.intActiveYear
                        .Amonth = GlobalPPT.IntActiveMonth
                        .COAID = GridViewRow.Cells("dgMeCOAID").Value.ToString()
                        .DivID = GridViewRow.Cells("dgMeDivID").Value.ToString()
                        .YOPID = GridViewRow.Cells("dgMeYOPID").Value.ToString()
                        .BlockID = GridViewRow.Cells("dgMeBlockID").Value.ToString()
                        If GridViewRow.cells("DgMeCredit").value.ToString() <> String.Empty Then
                            .Credit = GridViewRow.cells("DgMeCredit").value.ToString()
                            .Debit = 0
                        Else
                            .Debit = GridViewRow.cells("DgMeDebit").value.ToString()
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
            DisplayInfoMessage("Msg52")
            '' MsgBox("Approved Failed")
            Exit Sub
        End Try
        DisplayInfoMessage("Msg53")
        ''MsgBox("Transaction completed Successfully")

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

  
    Private Sub btnApprovalClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprovalClose.Click
        'If MsgBox(rm.GetString("Msg28"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        Me.Close()
        ' End If

    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        If MsgBox(rm.GetString("Msg31"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Dim objJournalPPT As New JournalPPT
            Dim dt As New DataTable
            With objJournalPPT
                .AccBatchID = lBatchTypeID
            End With
            If lBatchTypeID <> "" Then
                JournalBOL.DeleteJournal(objJournalPPT)
                JournalBOL.DeleteAccountBatch(objJournalPPT)
            End If
            BindDataGrid()
            Clear()
            ClearHeaderbox()
            ClearGridView(dgvMultipleEntry)
            ' ClearGridView(DgDeleteRecord)
        End If


      

       
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If dgvMultipleEntry.RowCount = 0 Then

            Exit Sub
        ElseIf dgvMultipleEntry.RowCount = 1 Then
            MsgBox(rm.GetString("msg64"), MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            If MsgBox(rm.GetString("Msg31"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
                DeleteMultientrydatagrid()
            End If


            ' DeleteMultientrydatagrid()
        End If

    End Sub
    Private Sub DeleteMultientrydatagrid()

        If Not dgvMultipleEntry.SelectedRows(0).Cells("dgMeAccJournalID").Value Is Nothing Then
            lAccJournalID = dgvMultipleEntry.SelectedRows(0).Cells("dgMeAccJournalID").Value.ToString
        Else
            lAccJournalID = String.Empty
        End If



        lDelete = 0
        If lAccJournalID <> "" Then
            'kumar anothertry
            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lAccJournalID)

            lDelete = DeleteMultientry.Count
        End If
            Dim Dr As DataRow
            Dr = dtjournal.Rows.Item(dgvMultipleEntry.CurrentRow.Index)
            Dr.Delete()
            dtjournal.AcceptChanges()
        lAccJournalID = ""
        Clear()

    End Sub

    Private Sub DeleteMultiEntryRecords()
        Dim objJournalPPT As New JournalPPT
        Dim objJournalBOL As New JournalBOL

        lDelete = DeleteMultientry.Count

        While (lDelete > 0)
            ' If GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString() <> String.Empty Then
            With objJournalPPT
                .AccJournalID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntJournalDetailDelete As New Integer
            IntJournalDetailDelete = JournalBOL.DeleteMultiEntryJournal(objJournalPPT)
            ' End If
            lDelete = lDelete - 1

        End While


    End Sub

   

    Private Sub JournalFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
       
        If btnSave.Enabled = True And dgvMultipleEntry.RowCount > 0 And GlobalPPT.IsButtonClose = False And btnSave.Visible = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M103"

            End If
        End If
    End Sub


End Class