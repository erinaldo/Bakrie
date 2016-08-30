Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient


Public Class InternalServiceRequisitionFrm

    Dim isDecimal, isModifierKey As Boolean ''Declaration for to allow double only
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")   ''Declaration for to allow double only
    Dim reDecimalPlaces3 As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim strCurrencyID As String

    Public Shared psSTISRID As String = String.Empty
    Public psSTISRDetID As String = String.Empty
    Public strStockID As String = String.Empty
    Public Shared strISRStockCategoryIDForStock As String = String.Empty
    Public strStockCategoryCode As String = String.Empty

    Public strStockCategoryID As String = String.Empty
    Public psISRStockCode As String = String.Empty
    Public psISRStockDesc As String = String.Empty
    Public psISRStockID As String = String.Empty
    Public strISRAccountID As String = String.Empty
    Public strISRT0analysisID As String = String.Empty
    Public strISRT1analysisID As String = String.Empty
    Public strISRT2analysisID As String = String.Empty
    Public strISRT3analysisID As String = String.Empty
    Public strISRT4analysisID As String = String.Empty
    Public Shared StrFrmName As String = String.Empty
    Public btnAddFlag As Boolean = True
    Public btsaveallFlag As Boolean = True
    Dim rowISRAdd As DataRow
    Dim dtISR As New DataTable
    Public dtAddFlag As Boolean = False
    Dim columnISRAdd As DataColumn


    Public lSTISRID As String = String.Empty
    Public gvlSTISRID As String = String.Empty
    Public gvlSTISRDetID As String = String.Empty
    'Public lSTISRDetID As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalServiceRequisitionFrm))

    'Dim lSTISRDetID As String
    Dim lSTISRDetID As String = String.Empty

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Shadows mdiparent As New MDIParent

    Private Sub InternalServiceRequisitionFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        ''dtpISRDate.Value = Date.Today
        dtpISRDate.Format = DateTimePickerFormat.Custom
        dtpISRDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(dtpISRDate)
        GlobalBOL.SetDateTimePicker(dtpviewISRDate)

        ''dtpviewISRDate.Value = Date.Today
        dtpviewISRDate.Format = DateTimePickerFormat.Custom
        dtpviewISRDate.CustomFormat = "dd/MM/yyyy"

        GridISRViewBind()
        tcISRView.SelectedTab = tbpgView

        txtTotalPrice.Text = "0"
        Currencytypeget()
        toGetISRNo()


    End Sub

    Private Sub toGetISRNo()

        Dim objStorePPT As New InternalServiceRequisitionPPT
        Dim objStoreBOL As New InternalServiceRequisitionBOL

        objStorePPT = objStoreBOL.GetISRNo(objStorePPT)
        With objStorePPT
            If .ISRNo <> "" Then
                Me.txtISRNo.Text = .ISRNo
            Else
                'MessageBox.Show("No records for ISR ")
                DisplayInfoMessage("msg01")
            End If
        End With

    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub Clear()

        DeleteMultientry.Clear()

        dtpISRDate.Format = DateTimePickerFormat.Custom
        ''dtpISRDate.Value = Date.Today

        dtpISRDate.CustomFormat = "dd/MM/yyyy"
        txtSuggestedSupplier.Text = String.Empty
        txtRequiredFor.Text = String.Empty
        txtMakeandModel.Text = String.Empty
        txtEngine.Text = String.Empty
        txtChassisSerialNo.Text = String.Empty
        txtFixedAssetNo.Text = String.Empty
        reset()

        If dgvISRDetails.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvISRDetails.Rows

                dgvISRDetails.Rows.RemoveAt(dgvISRDetails.Rows.Count - 1)
            Next
            i = dgvISRDetails.Rows.Count
            For J = 0 To i - 1
                dgvISRDetails.Rows.RemoveAt(dgvISRDetails.Rows.Count - 1)
            Next
        End If
        toGetISRNo()
        txtSuggestedSupplier.Focus()
        GBISR.Enabled = True

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

    Private Sub btnSearchAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccountCode.Click

        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            lblAcCodeDesc.Text = frmAcctcodeLookup.strAcctDescp
            lblOldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode
            strISRAccountID = frmAcctcodeLookup.strAcctId
        End If

    End Sub

    Private Sub btnSearchTAnalysisT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTAnalysisT0.Click

        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T0"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtTAnalysisT0.Text = frmTLookup.strTValue
            Me.lblISRT0Name.Text = frmTLookup.strTDesc
            strISRT0analysisID = frmTLookup.strTId
        End If
    End Sub

    Private Sub btnSearchTAnalysisT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTAnalysisT1.Click


        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T1"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtTAnalysisT1.Text = frmTLookup.strTValue
            Me.lblISRT1Name.Text = frmTLookup.strTDesc
            strISRT1analysisID = frmTLookup.strTId
        End If
    End Sub

    Private Sub btnSearchTAnalysisT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTAnalysisT2.Click


        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T2"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtTAnalysisT2.Text = frmTLookup.strTValue
            Me.lblISRT2Name.Text = frmTLookup.strTDesc
            strISRT2analysisID = frmTLookup.strTId
        End If
    End Sub

    Private Sub btnSearchTAnalysisT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTAnalysisT3.Click

        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T3"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtTAnalysisT3.Text = frmTLookup.strTValue
            Me.lblISRT3Name.Text = frmTLookup.strTDesc
            strISRT3analysisID = frmTLookup.strTId
        End If
    End Sub

    Private Sub btnSearchTAnalysisT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchTAnalysisT4.Click

        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T4"
        frmTLookup.ShowDialog()
        If frmTLookup.strTValue <> String.Empty Then
            Me.txtTAnalysisT4.Text = frmTLookup.strTValue
            Me.lblISRT4Name.Text = frmTLookup.strTDesc
            strISRT4analysisID = frmTLookup.strTId
        End If

    End Sub

    Private Sub txtTAnalysisT0_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAnalysisT0.Leave

        If txtTAnalysisT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T0Value = txtTAnalysisT0.Text.Trim()
            objSIV.TDecide = "T0"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                DisplayInfoMessage("msg02")
                Me.lblISRT0Name.Text = String.Empty
                Me.txtTAnalysisT0.Text = String.Empty
                strISRT0analysisID = String.Empty
                txtTAnalysisT0.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblISRT0Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtTAnalysisT0.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                strISRT0analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblISRT0Name.Text = String.Empty
            Me.txtTAnalysisT0.Text = String.Empty
            strISRT0analysisID = String.Empty
        End If

    End Sub

    Private Sub txtTAnalysisT1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAnalysisT1.Leave

        If txtTAnalysisT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T1Value = txtTAnalysisT1.Text.Trim()
            objSIV.TDecide = "T1"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
                DisplayInfoMessage("msg03")
                Me.lblISRT1Name.Text = String.Empty
                Me.txtTAnalysisT1.Text = String.Empty
                strISRT1analysisID = String.Empty
                txtTAnalysisT1.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblISRT1Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtTAnalysisT1.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                strISRT1analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblISRT1Name.Text = String.Empty
            Me.txtTAnalysisT1.Text = String.Empty
            strISRT1analysisID = String.Empty
        End If

    End Sub

    Private Sub txtTAnalysisT2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAnalysisT2.Leave

        If txtTAnalysisT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T2Value = txtTAnalysisT2.Text.Trim()
            objSIV.TDecide = "T2"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
                DisplayInfoMessage("msg04")
                Me.lblISRT2Name.Text = String.Empty
                Me.txtTAnalysisT2.Text = String.Empty
                strISRT2analysisID = String.Empty
                txtTAnalysisT2.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblISRT2Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtTAnalysisT2.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                strISRT2analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblISRT2Name.Text = String.Empty
            Me.txtTAnalysisT2.Text = String.Empty
            strISRT2analysisID = String.Empty
        End If

    End Sub

    Private Sub txtTAnalysisT3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAnalysisT3.Leave

        If txtTAnalysisT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T3Value = txtTAnalysisT3.Text.Trim()
            objSIV.TDecide = "T3"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid T3   Value,Please Choose it from look up")
                DisplayInfoMessage("msg05")
                Me.lblISRT3Name.Text = String.Empty
                Me.txtTAnalysisT3.Text = String.Empty
                strISRT3analysisID = String.Empty
                txtTAnalysisT3.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblISRT3Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtTAnalysisT3.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                strISRT3analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblISRT3Name.Text = String.Empty
            Me.txtTAnalysisT3.Text = String.Empty
            strISRT3analysisID = String.Empty
        End If

    End Sub

    Private Sub txtTAnalysisT4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAnalysisT4.Leave

        If txtTAnalysisT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T4Value = txtTAnalysisT4.Text.Trim()
            objSIV.TDecide = "T4"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
                DisplayInfoMessage("msg06")
                Me.lblISRT4Name.Text = String.Empty
                Me.txtTAnalysisT4.Text = String.Empty
                strISRT4analysisID = String.Empty
                txtTAnalysisT4.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblISRT4Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtTAnalysisT4.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                strISRT4analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblISRT4Name.Text = String.Empty
            Me.txtTAnalysisT4.Text = String.Empty
            strISRT4analysisID = String.Empty
        End If

    End Sub

    Private Sub txtTAnalysisT0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTAnalysisT0.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtTAnalysisT0.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                txtTAnalysisT1.Focus()
            End If
        End If
    End Sub
    Private Sub txtTAnalysisT1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTAnalysisT1.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtTAnalysisT1.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                txtTAnalysisT2.Focus()
            End If
        End If
    End Sub
    Private Sub txtTAnalysisT2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTAnalysisT2.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtTAnalysisT2.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                txtTAnalysisT3.Focus()
            End If
        End If
    End Sub
    Private Sub txtTAnalysisT3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTAnalysisT3.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtTAnalysisT3.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                txtTAnalysisT4.Focus()
            End If
        End If
    End Sub
    Private Sub txtTAnalysisT4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTAnalysisT4.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtTAnalysisT4.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                btnAdd.Focus()
            End If
        End If
    End Sub


    'Private Sub txtServiceDetails_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServiceDetails.Leave

    '    If txtServiceDetails.Text.Trim = String.Empty Then
    '        txtServiceDetails.Text = String.Empty
    '        Exit Sub
    '    End If

    'End Sub

    Private Sub txtRequiredFor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequiredFor.Leave
        If txtRequiredFor.Text.Trim = String.Empty Then
            txtRequiredFor.Text = String.Empty
            Exit Sub
        End If
    End Sub

    Private Sub txtChassisSerialNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChassisSerialNo.Leave
        If txtChassisSerialNo.Text.Trim = String.Empty Then
            txtChassisSerialNo.Text = String.Empty
        End If
    End Sub

    Private Sub txtEngine_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEngine.Leave
        If txtEngine.Text.Trim = String.Empty Then
            txtEngine.Text = String.Empty
        End If
    End Sub

    Private Sub txtUnit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnit.Leave
        If txtUnit.Text.Trim = String.Empty Then
            txtUnit.Text = String.Empty
        End If
    End Sub

    Private Sub txtFixedAssetNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFixedAssetNo.Leave
        If txtFixedAssetNo.Text.Trim = String.Empty Then
            txtFixedAssetNo.Text = String.Empty
        End If
    End Sub

    Private Sub txtUnitPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnitPrice.Leave
        If txtQty.Text.Trim <> String.Empty And txtUnitPrice.Text.Trim <> String.Empty Then
            If txtQty.Text.Trim() <> String.Empty And txtUnitPrice.Text.Trim() <> String.Empty Then
                txtTotalPrice.Text = Math.Round(Val(txtQty.Text) * Val(txtUnitPrice.Text), 2).ToString()
                txtTotalPrice.Text = Format(Val(txtTotalPrice.Text.Trim), "0")
            End If
        Else
            txtTotalPrice.Text = String.Empty
        End If
    End Sub

    Private Sub txtQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.Leave
        If txtQty.Text.Trim <> String.Empty And txtUnitPrice.Text.Trim <> String.Empty Then
            If txtQty.Text.Trim() <> String.Empty And txtUnitPrice.Text.Trim() <> String.Empty Then
                txtTotalPrice.Text = Math.Round(Val(txtQty.Text) * Val(txtUnitPrice.Text), 2).ToString()
                txtTotalPrice.Text = Format(Val(txtTotalPrice.Text.Trim), "0")
            End If
        Else
            txtTotalPrice.Text = String.Empty
        End If
        'If txtQty.Text.Trim <> String.Empty And txtUnitPriceC.Text.Trim <> String.Empty Then
        '    txtTotalPriceC.Text = Math.Round((Val(txtQty.Text) * Val(txtUnitPriceC.Text)), 2)
        'Else
        '    txtTotalPriceC.Text = String.Empty
        'End If
    End Sub

    Private Sub txtSuggestedSupplier_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSuggestedSupplier.Leave
        If txtSuggestedSupplier.Text.Trim = String.Empty Then
            txtSuggestedSupplier.Text = String.Empty
            Exit Sub
        End If
    End Sub

    Private Sub txtMakeandModel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMakeandModel.Leave
        If txtMakeandModel.Text.Trim = String.Empty Then
            txtMakeandModel.Text = String.Empty
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim mdiparent As New MDIParent

        If (dgvISRDetails.RowCount > 0 And mdiparent.strMenuID = "M3" And btnSaveAll.Enabled = True) Then
            If MsgBox(rm.GetString("msg36"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

    Private Sub SaveAll()

        ''If txtSuggestedSupplier.Text.Trim = String.Empty Then
        ''    MessageBox.Show("Suggested supplier field is mandatory")
        ''    txtSuggestedSupplier.Focus()
        ''    Exit Sub
        ''End If
        If dgvISRDetails.Rows.Count = 0 Then
            'MessageBox.Show(" Please Add ISR Details", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisplayInfoMessage("msg07")
            Exit Sub
        End If
        If btsaveallFlag = True Then
            ISRSave()
            ISRDetailSave()
            GBISR.Enabled = True
        ElseIf btsaveallFlag = False Then
            UpdateISR()
            UpdateAllISR()
            btnAddFlag = True
            btsaveallFlag = True
            GBISR.Enabled = True
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()
        txtSuggestedSupplier.Focus()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub ISRSave()
        Dim objsave As New Store_PPT.InternalServiceRequisitionPPT
        objsave.ISRDate = dtpISRDate.Value
        objsave.ISRNo = txtISRNo.Text.Trim
        objsave.Supplier = txtSuggestedSupplier.Text.Trim
        objsave.RequiredFor = txtRequiredFor.Text.Trim
        objsave.MakeModel = txtMakeandModel.Text.Trim
        objsave.Engine = txtEngine.Text.Trim
        objsave.ChassisNo = txtChassisSerialNo.Text.Trim
        objsave.fixedAssetNo = txtFixedAssetNo.Text.Trim
        Dim dtHeaderInsert As New DataSet
        dtHeaderInsert = InternalServiceRequisitionBOL.Save_ISR(objsave)
        psSTISRID = dtHeaderInsert.Tables(0).Rows(0).Item("STISRID").ToString()
        objsave.STISRID = psSTISRID
        GridISRViewBind()
    End Sub

    Private Sub ISRDetailSave()
        Dim dsDetails As New DataSet
        If psSTISRID <> String.Empty Then '' If Me.btnSaveAll.Text = "Save All"
            ''If Validation() = True Then
            If dgvISRDetails.Rows.Count <> 0 Then
                For Each DataGridViewRow In dgvISRDetails.Rows
                    Dim objISRPPT As New InternalServiceRequisitionPPT
                    With objISRPPT
                        .STISRID = psSTISRID
                        .COAID = DataGridViewRow.Cells("COAID").Value.ToString()
                        .CurrencyID = DataGridViewRow.Cells("CurrencyID").Value.ToString()
                        If Not DataGridViewRow.Cells("ServiceType").Value Is DBNull.Value Then
                            .ServiceType = DataGridViewRow.Cells("ServiceType").Value.ToString()
                        End If
                        If Not DataGridViewRow.Cells("NonStockID").Value Is DBNull.Value Then
                            .NonStockID = DataGridViewRow.Cells("NonStockID").Value.ToString()
                        End If
                        'If Not DataGridViewRow.Cells("StockID").Value Is DBNull.Value Then
                        '    .StockID = DataGridViewRow.Cells("StockID").Value.ToString()
                        'End If
                        If Not DataGridViewRow.Cells("ServiceDetail").Value Is DBNull.Value Then
                            .ServiceDetail = DataGridViewRow.Cells("ServiceDetail").Value.ToString()
                        End If
                        If Not DataGridViewRow.Cells("Qty").Value Is DBNull.Value Then
                            .Qty = CDbl(DataGridViewRow.Cells("Qty").Value)
                        End If
                        If Not DataGridViewRow.Cells("Unit").Value Is DBNull.Value Then
                            .Unit = DataGridViewRow.Cells("Unit").Value
                        End If
                        If Not DataGridViewRow.Cells("UnitPrice").Value Is DBNull.Value Then
                            .UnitPrice = CDbl(DataGridViewRow.Cells("UnitPrice").Value)
                        End If
                        If Not DataGridViewRow.Cells("Value").Value Is DBNull.Value Then
                            .Valu = CDbl(DataGridViewRow.Cells("Value").Value)
                        End If
                        If Not DataGridViewRow.Cells("UnitPrice_Currency").Value Is DBNull.Value Then
                            .UnitPriceC = CDbl(DataGridViewRow.Cells("UnitPrice_Currency").Value)
                        End If
                        If Not DataGridViewRow.Cells("TotalPrice_Currency").Value Is DBNull.Value Then
                            .ValueC = CDbl(DataGridViewRow.Cells("TotalPrice_Currency").Value)
                        End If
                        If Not DataGridViewRow.Cells("T0").Value Is DBNull.Value Then
                            .T0 = DataGridViewRow.Cells("T0").Value
                        End If
                        If Not DataGridViewRow.Cells("T1").Value Is DBNull.Value Then
                            .T1 = DataGridViewRow.Cells("T1").Value
                        End If
                        If Not DataGridViewRow.Cells("T2").Value Is DBNull.Value Then
                            .T2 = DataGridViewRow.Cells("T2").Value
                        End If
                        If Not DataGridViewRow.Cells("T3").Value Is DBNull.Value Then
                            .T3 = DataGridViewRow.Cells("T3").Value
                        End If
                        If Not DataGridViewRow.Cells("T4").Value Is DBNull.Value Then
                            .T4 = DataGridViewRow.Cells("T4").Value
                        End If
                    End With
                    dsDetails = InternalServiceRequisitionBOL.Save_ISRDetail(objISRPPT)
                Next
                ' ''If dsDetails Is Nothing Then
                ' ''    MsgBox("Failed to save details in database")
                ' ''    'delete heder table query
                ' ''    InternalServiceRequisitionBOL.ISRViewDelete(objISRPPT)
                ' ''Else
                'MessageBox.Show("Data Saved Successfully")
                DisplayInfoMessage("msg08")
                Clear()
                ' ''End If
            Else
                Exit Sub
            End If
        Else
            'MessageBox.Show(" Please Add ISR Details", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisplayInfoMessage("msg09")
            Exit Sub
        End If
    End Sub

    Private Sub ISRUpdate()
        Dim objUpdate As New Store_PPT.InternalServiceRequisitionPPT
        objUpdate.ISRDate = dtpISRDate.Value
        objUpdate.STISRID = psSTISRID
        objUpdate.ISRDetID = psSTISRDetID
        objUpdate.ISRNo = txtISRNo.Text
        objUpdate.Supplier = txtSuggestedSupplier.Text
        objUpdate.RequiredFor = txtRequiredFor.Text
        objUpdate.MakeModel = txtMakeandModel.Text
        objUpdate.Engine = txtEngine.Text
        objUpdate.ChassisNo = txtChassisSerialNo.Text
        objUpdate.fixedAssetNo = txtFixedAssetNo.Text
        objUpdate.COAID = strISRAccountID
        objUpdate.Qty = CDbl(txtQty.Text)
        objUpdate.Unit = txtUnit.Text
        objUpdate.UnitPrice = Convert.ToDouble(txtUnitPrice.Text)
        objUpdate.Valu = (IIf(txtTotalPrice.Text <> "", CDbl(txtTotalPrice.Text), 0.0))
        objUpdate.ServiceDetail = txtServiceDetails.Text
        objUpdate.T0 = strISRT0analysisID
        objUpdate.T1 = strISRT1analysisID
        objUpdate.T2 = strISRT2analysisID
        objUpdate.T3 = strISRT3analysisID
        objUpdate.T4 = strISRT4analysisID
        Dim dtHeaderUpdate As New DataSet
        InternalServiceRequisitionBOL.Update_ISR(objUpdate)
        InternalServiceRequisitionBOL.Update_ISRDetail(objUpdate)
        'MessageBox.Show("Data was Updated sucessfully")
        DisplayInfoMessage("msg10")
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        Clear()
        GridISRViewBind()
    End Sub

    Private Sub UpdateISR()
        Dim objISRPPT As New InternalServiceRequisitionPPT
        objISRPPT.ISRNo = txtISRNo.Text.Trim()
        objISRPPT.ISRDate = dtpISRDate.Value
        objISRPPT.STISRID = psSTISRID
        objISRPPT.Supplier = txtSuggestedSupplier.Text.Trim
        objISRPPT.RequiredFor = txtRequiredFor.Text.Trim
        objISRPPT.MakeModel = txtMakeandModel.Text.Trim
        objISRPPT.ChassisNo = txtChassisSerialNo.Text.Trim
        objISRPPT.Engine = txtEngine.Text.Trim
        objISRPPT.fixedAssetNo = txtFixedAssetNo.Text.Trim
        DeleteMultiEntryRecords()
        Dim ds As New DataSet
        ds = InternalServiceRequisitionBOL.Update_ISR(objISRPPT)
    End Sub

    Private Sub UpdateAllISR()


        If btnSaveAll.Text.Trim = "Update All" Or btnSaveAll.Text.Trim = "Update Semua" Then
            ''If txtSuggestedSupplier.Text.Trim = String.Empty Then
            ''    MessageBox.Show("Suggested supplier field is mandatory")
            ''    Exit Sub
            ''End If
            Dim dsDetails As New DataSet
            Dim dtDetails As New DataTable
            For Each DataGridViewRow In dgvISRDetails.Rows
                Dim objISR As New InternalServiceRequisitionPPT
                With objISR
                    .STISRID = psSTISRID
                    .ISRDetID = DataGridViewRow.Cells("ISRDetID").Value.ToString()
                    .COAID = DataGridViewRow.Cells("COAID").Value.ToString()
                    .CurrencyID = DataGridViewRow.Cells("CurrencyID").Value.ToString()

                    If Not DataGridViewRow.Cells("ServiceType").Value Is DBNull.Value Then
                        .ServiceType = DataGridViewRow.Cells("ServiceType").Value.ToString()
                    End If
                    If Not DataGridViewRow.Cells("NonStockID").Value Is DBNull.Value Then
                        .NonStockID = DataGridViewRow.Cells("NonStockID").Value.ToString()
                    Else
                        .NonStockID = String.Empty
                    End If
                    'If Not DataGridViewRow.Cells("StockID").Value Is DBNull.Value Then
                    '    .StockID = DataGridViewRow.Cells("StockID").Value.ToString()
                    'Else
                    '    .StockID = String.Empty
                    'End If
                    If Not DataGridViewRow.Cells("ServiceDetail").Value Is DBNull.Value Then
                        .ServiceDetail = DataGridViewRow.Cells("ServiceDetail").Value.ToString()
                    End If
                    If Not DataGridViewRow.Cells("Qty").Value Is DBNull.Value Then
                        .Qty = CDbl(DataGridViewRow.Cells("Qty").Value)
                    End If
                    If Not DataGridViewRow.Cells("Unit").Value Is DBNull.Value Then
                        .Unit = DataGridViewRow.Cells("Unit").Value
                    End If
                    If Not DataGridViewRow.Cells("T0").Value Is DBNull.Value Then
                        .T0 = DataGridViewRow.Cells("T0").Value
                    End If
                    If Not DataGridViewRow.Cells("T1").Value Is DBNull.Value Then
                        .T1 = DataGridViewRow.Cells("T1").Value
                    End If
                    If Not DataGridViewRow.Cells("T2").Value Is DBNull.Value Then
                        .T2 = DataGridViewRow.Cells("T2").Value
                    End If
                    If Not DataGridViewRow.Cells("T3").Value Is DBNull.Value Then
                        .T3 = DataGridViewRow.Cells("T3").Value
                    End If
                    If Not DataGridViewRow.Cells("T4").Value Is DBNull.Value Then
                        .T4 = DataGridViewRow.Cells("T4").Value
                    End If
                    If Not DataGridViewRow.Cells("UnitPrice").Value Is DBNull.Value Then
                        .UnitPrice = CDbl(DataGridViewRow.Cells("UnitPrice").Value)
                    End If
                    If Not DataGridViewRow.Cells("Value").Value Is DBNull.Value Then
                        .Valu = (CDbl(DataGridViewRow.Cells("Value").Value))
                    End If
                    If Not DataGridViewRow.Cells("UnitPrice_Currency").Value Is DBNull.Value Then
                        .UnitPriceC = CDbl(DataGridViewRow.Cells("UnitPrice_Currency").Value)
                    End If
                    If Not DataGridViewRow.Cells("TotalPrice_Currency").Value Is DBNull.Value Then
                        .ValueC = CDbl(DataGridViewRow.Cells("TotalPrice_Currency").Value)
                    End If

                End With
                If DataGridViewRow.Cells("ISRDetID").Value Is DBNull.Value Then
                    dsDetails = InternalServiceRequisitionBOL.Save_ISRDetail(objISR)
                Else
                    dtDetails = InternalServiceRequisitionBOL.Update_ISRDetail(objISR)
                End If
            Next
            'MessageBox.Show("Data Updated Successfully")
            DisplayInfoMessage("msg11")
            ''bIsDetailsFromUpdateMode = False
            ' ''txtStockCode.Text = String.Empty
        Else
            Exit Sub
        End If
        '' End If
        ''txtStockCode.Text = String.Empty
        Clear()
        ''btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If


    End Sub

    Private Function Validation() As Boolean
        If txtISRNo.Text.Trim = "" Then
            'MessageBox.Show("ISRNo required")
            DisplayInfoMessage("msg12")
            Return False
        End If
        If txtISRNo.Text.Trim = "" Then
            'MessageBox.Show("ISR Date Field is mandatory")
            DisplayInfoMessage("msg13")
            txtISRNo.Focus()
            Return False
        End If
        ''If txtSuggestedSupplier.Text.Trim = String.Empty Then
        ''    MessageBox.Show("ISR Suggested supplier Field is mandatory")
        ''    txtSuggestedSupplier.Text = String.Empty
        ''    txtSuggestedSupplier.Focus()
        ''    Return False
        ''End If
        If cmbServicetype.Text.Trim = String.Empty Then
            'MessageBox.Show("Service Type Field is mandatory")
            DisplayInfoMessage("msg31")
            cmbServicetype.Focus()
            Return False
        End If
        If cmbServicetype.Text.Trim = "Other" Then
            If txtServiceDetails.Text = "" Then
                'MessageBox.Show("ServiceDetails Field is mandatory")
                DisplayInfoMessage("msg14")
                txtServiceDetails.Focus()
                Return False
            End If
        End If
        If cmbServicetype.Text.Trim = "5SERV" Then
            If txtServiceDetails.Text.Trim = "" Then
                'MessageBox.Show("ServiceDetails Field is mandatory")
                DisplayInfoMessage("msg14")
                txtServiceDetails.Focus()
                Return False
            End If
            If txtStockcode.Text.Trim = "" Then
                'MessageBox.Show("Stock Code Field is mandatory")
                DisplayInfoMessage("msg15")
                txtStockcode.Focus()
                Return False
            End If
        End If
        If txtAccountCode.Text.Trim = "" Then
            'MessageBox.Show("Account Field is mandatory")
            DisplayInfoMessage("msg16")
            txtAccountCode.Focus()
            Return False
        End If
        If txtQty.Text.Trim = "" Then
            'MessageBox.Show("Quantity Field is mandatory")
            DisplayInfoMessage("msg17")
            txtQty.Focus()
            Return False
        End If
        If txtUnit.Text.Trim = "" Then
            'MessageBox.Show("Unit Field is mandatory")
            DisplayInfoMessage("msg18")
            txtUnit.Focus()
            Return False
        End If
        If txtUnitPrice.Text.Trim = "" Then
            'MessageBox.Show("UnitPrice Field is mandatory")
            DisplayInfoMessage("msg19")
            txtUnitPrice.Focus()
            Return False
        End If
        If txtTAnalysisT0.Text.Trim = "" Then
            ''MessageBox.Show("T0 Feld is mandatory")
            DisplayInfoMessage("msg34")
            txtTAnalysisT0.Focus()
            Return False
        End If

        If cmbCurrencyType.Text = String.Empty Then
            DisplayInfoMessage("msg38")
            txtTAnalysisT0.Focus()
            Return False
        End If


        Return True
    End Function

    Private Sub txtQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
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

                        isDecimal = reDecimalPlaces3.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If

    End Sub


    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress, txtUnitPrice.KeyPress, txtTotalPrice.KeyPress

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
    Private Sub txtUnitPrice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnitPrice.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

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


    Private Sub btnviewISRSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewISRSearch.Click

        Dim objISR As New InternalServiceRequisitionPPT
        Dim objISRPPT As New InternalServiceRequisitionPPT
        GridISRViewBind()

    End Sub
    Private Sub GridISRViewBind()

        Dim objISRPPT As New InternalServiceRequisitionPPT
        Dim objISRBOL As New InternalServiceRequisitionBOL
        Dim dt As New DataTable
        lblRecordNotFound.Visible = False
        With objISRPPT

            If chkviewISRDate.Checked = True Then
                .BViewISRDate = True
            Else
                .BViewISRDate = False
            End If
            .ISRDateSearch = dtpviewISRDate.Value 'Format(Me.dtpviewISRDate.Value, "yyyy/MM/dd") 
            .ISRNOSearch = txtviewISRNo.Text.Trim()

        End With

        dt = objISRBOL.GetISRDetails(objISRPPT)
        If dt.Rows.Count = 0 Then

            txtviewISRNo.Text = String.Empty
            lblRecordNotFound.Visible = True
        Else
            lblRecordNotFound.Visible = False

        End If
        dgvviewISR.AutoGenerateColumns = False
        Me.dgvviewISR.DataSource = dt
        dgvviewISR.AutoGenerateColumns = False
        'Else
        '    ClearGridView(dgvviewISR) '''''clear the records from grid view
        Exit Sub
        'End If

    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        Me.tcISRView.SelectedTab = tbpgISR
        Clear()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        ISRViewDelete()
        GridISRViewBind()

    End Sub

    Private Sub ISRViewDelete()
        Dim strSTISRDetDel As String
        Me.cmsISR.Visible = False
        Dim objISR As New InternalServiceRequisitionPPT
        Dim ds As New DataSet
        If dgvviewISR.Rows.Count > 0 Then
            'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            If MsgBox(rm.GetString("msg20"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                strSTISRDetDel = dgvviewISR.SelectedRows(0).Cells("STISRID").Value.ToString()
                objISR.STISRID = strSTISRDetDel
                InternalServiceRequisitionBOL.ISRViewDelete(objISR)
                ''BindViewIssueVoucher()
            Else
                'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DisplayInfoMessage("msg21")
            End If
        Else
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisplayInfoMessage("msg22")
        End If

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        EditViewGridRecord()

    End Sub

    Private Sub ISRViewUpdate()

        Dim objISR As New InternalServiceRequisitionPPT
        Dim objisrBOL As New InternalServiceRequisitionBOL
        Dim dt As New DataTable

        If dgvviewISR.RowCount > 0 Then
            objISR.STISRID = dgvviewISR.SelectedRows(0).Cells("STISRID").Value


            psSTISRID = objISR.STISRID
            ''psSTISRDetID = objISR.ISRDetID

            dt = objisrBOL.ISRDetailsGet(objISR)

            If dt.Rows.Count > 0 Then
                txtISRNo.Text = dgvviewISR.SelectedRows(0).Cells("ISRNo").Value
                txtSuggestedSupplier.Text = dgvviewISR.SelectedRows(0).Cells("Supplier").Value
                Dim str As String = Me.dgvviewISR.SelectedRows(0).Cells("ISRDate").Value.ToString()
                Me.dtpISRDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                'dtpISRDate.Text = dgvviewISR.SelectedRows(0).Cells("ISRDate").Value
                txtRequiredFor.Text = dgvviewISR.SelectedRows(0).Cells("Requiredfor").Value
                txtMakeandModel.Text = dgvviewISR.SelectedRows(0).Cells("MakeModel").Value
                txtChassisSerialNo.Text = dgvviewISR.SelectedRows(0).Cells("ChassisNo").Value
                txtFixedAssetNo.Text = dgvviewISR.SelectedRows(0).Cells("FixedAssetNo").Value
                txtEngine.Text = dgvviewISR.SelectedRows(0).Cells("Engine").Value

                ''btnSaveAll.Text = "Update All"
                If GlobalPPT.strLang = "en" Then
                    btnSaveAll.Text = "Update All"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveAll.Text = "Update Semua"
                End If

                dtISR = dt
                dgvISRDetails.AutoGenerateColumns = False
                dgvISRDetails.DataSource = dtISR
                dtAddFlag = True

            End If

            tcISRView.SelectedTab = tbpgISR
            GBISR.Enabled = False
            btsaveallFlag = False

        Else
            'MessageBox.Show("There is no record to select")
            'DisplayInfoMessage("msg23")
            Exit Sub
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub


    Private Sub dgvviewISR_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvviewISR.CellDoubleClick

        EditViewGridRecord()

    End Sub

    Private Sub EditViewGridRecord()

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                ISRViewUpdate()
                'tcISRView.SelectedTab = tbpgISR
                'GBISR.Enabled = False
                'btsaveallFlag = False

            End If
        End If

    End Sub

    Private Sub tcISRView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcISRView.Click

        If tcISRView.SelectedTab Is tbpgISR = True Then
            If dgvISRDetails.RowCount > 0 Then
                If MsgBox(rm.GetString("msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ClearGridView(dgvISRDetails)
                    Clear()
                    dtpISRDate.Focus()
                    GBISR.Enabled = True
                    btsaveallFlag = True
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                Else
                    Exit Sub
                End If
            End If
        ElseIf tcISRView.SelectedTab Is tbpgView = True Then

            chkviewISRDate.Focus()

            If dgvISRDetails.RowCount > 0 And btnSaveAll.Enabled = True Then


                If MsgBox(rm.GetString("msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    ClearGridView(dgvISRDetails)
                    Clear()
                    dtpISRDate.Focus()
                    GBISR.Enabled = True
                    btsaveallFlag = True
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If

                    GlobalPPT.IsRetainFocus = False
                    GridISRViewBind()
                    If chkviewISRDate.Checked = True Then
                        chkviewISRDate.Checked = False
                    End If
                    If txtviewISRNo.Text <> String.Empty Then
                        txtviewISRNo.Text = String.Empty
                    End If

                Else

                    tcISRView.SelectedTab = tbpgISR

                End If

            End If

        End If

        '------------------------------------------------------------
        'If chkviewISRDate.Checked = True Then
        '    chkviewISRDate.Checked = False
        'End If
        'If txtviewISRNo.Text <> String.Empty Then
        '    txtviewISRNo.Text = String.Empty
        'End If
        'GridISRViewBind()
        'Clear()
        'GBISR.Enabled = True
        'btsaveallFlag = True
        'If GlobalPPT.strLang = "en" Then
        '    btnSaveAll.Text = "Save All"
        'ElseIf GlobalPPT.strLang = "ms" Then
        '    btnSaveAll.Text = "Simpan Semua"
        'End If
        ' ''btnSaveAll.Text = "Save All"
        '------------------------------------------------------------

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub txtviewISRNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtviewISRNo.Leave

        If txtviewISRNo.Text.Trim = String.Empty Then
            txtviewISRNo.Text = String.Empty
        End If

    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave

        If txtAccountCode.Text.Trim() <> String.Empty Then

            If txtAccountCode.Text.Trim.ToString.Length <> 13 Then
                'MessageBox.Show("Please enter 13 digit Account code")
                DisplayInfoMessage("msg24")
                txtAccountCode.Text = String.Empty
                lblAcCodeDesc.Text = String.Empty
                Exit Sub
            End If

            Dim ds As New DataSet
            Dim objISR As New InternalServiceRequisitionPPT
            objISR.COAID = txtAccountCode.Text.Trim()
            'Dim ObjISRBOL As New InternalServiceRequisitionBOL
            ds = InternalServiceRequisitionBOL.AcctlookupSearch(objISR, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid Account code,Please Choose it from look up")
                DisplayInfoMessage("msg25")
                txtAccountCode.Text = String.Empty
                lblAcCodeDesc.Text = String.Empty
                lblOldAccountCode.Text = String.Empty
                strISRAccountID = String.Empty
                'lCOAID = String.Empty
                txtAccountCode.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("COACode") Is DBNull.Value Then
                    Me.txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                Else
                    Me.txtAccountCode.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("COAID") Is DBNull.Value Then
                    strISRAccountID = ds.Tables(0).Rows(0).Item("COAID")
                Else
                    strISRAccountID = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("COADescp") Is DBNull.Value Then
                    lblAcCodeDesc.Text = ds.Tables(0).Rows(0).Item("COADescp")
                Else
                    lblAcCodeDesc.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("OldCOACode") Is DBNull.Value Then
                    lblOldAccountCode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                Else
                    lblOldAccountCode.Text = String.Empty
                End If
                ''lCOAID = ds.Tables(0).Rows(0).Item("COAID")
            End If
        Else
            txtAccountCode.Text = String.Empty
            lblAcCodeDesc.Text = String.Empty
            lblOldAccountCode.Text = String.Empty
            strISRAccountID = String.Empty
            ''lCOAID = String.Empty
        End If
    End Sub
    Private Sub dtpISRDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpISRDate.KeyDown, txtSuggestedSupplier.KeyDown, txtRequiredFor.KeyDown, txtMakeandModel.KeyDown, txtEngine.KeyDown, txtChassisSerialNo.KeyDown, txtFixedAssetNo.KeyDown, btnSearchAccountCode.KeyDown, txtQty.KeyDown, txtUnit.KeyDown, btnSearchTAnalysisT0.KeyDown, btnSearchTAnalysisT1.KeyDown, btnSearchTAnalysisT2.KeyDown, btnSearchTAnalysisT3.KeyDown, btnSearchTAnalysisT4.KeyDown, dtpviewISRDate.KeyDown, txtviewISRNo.KeyDown, btnviewISRSearch.KeyDown, btnviewISRReport.KeyDown, cmbServicetype.KeyDown, txtStockcode.KeyDown, txtServiceDetails.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub dgvviewISR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvviewISR.KeyDown

        ''ISRViewUpdate()
        ''e.Handled = True
        ''tcISRView.SelectedTab = tbpgISR

        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If


        If e.KeyValue = 40 Then
            If dgvviewISR.SelectedRows.Count = 0 Then
                dgvviewISR.Rows(0).Selected = True
            Else
                If dgvviewISR.SelectedRows(0).Index < (dgvviewISR.Rows.Count - 1) Then
                    Dim intSelectedIndex As Integer = dgvviewISR.SelectedRows(0).Index

                    dgvviewISR.ClearSelection()
                    dgvviewISR.Rows(intSelectedIndex + 1).Selected = True
                End If
            End If
        End If




    End Sub

    Private Sub txtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If btnAddFlag = True Then
            If Validation() = True Then
                dgvISRDetails.AutoGenerateColumns = False
                AddISRDetail()
                GBISR.Enabled = False

            Else
                Exit Sub
            End If
        ElseIf btnAddFlag = False Then
            If Validation() = True Then
                dgvISRDetails.AutoGenerateColumns = False
                UpdateISRDetail()
                btnAddFlag = True

            Else
                Exit Sub
            End If
        End If
        btnSaveAll.Focus()

        'GlobalPPT.IsRetainFocus = True

    End Sub
    Private Sub AddISRDetail()
        Dim intRowcount As Integer = dgvISRDetails.Rows.Count
        Dim objISRPPT As New InternalServiceRequisitionPPT
        objISRPPT.COAID = strISRAccountID

        strCurrencyID = cmbCurrencyType.SelectedItem("CurrencyID").ToString

        Try
            If Not AccountcodeExist(objISRPPT.COAID) Then 'AccountCode Validation,if already added in grid
                rowISRAdd = dtISR.NewRow()
                If intRowcount = 0 And dtAddFlag = False Then
                    'Add the Data column to the datatable first time 
                    columnISRAdd = New DataColumn("STISRID", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)

                    columnISRAdd = New DataColumn("ServiceType", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("StockID", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)

                    columnISRAdd = New DataColumn("COACode", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("Qty", System.Type.[GetType]("System.Decimal"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("Unit", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("UnitPrice", System.Type.[GetType]("System.Decimal"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("Value", System.Type.[GetType]("System.Decimal"))
                    dtISR.Columns.Add(columnISRAdd)

                    columnISRAdd = New DataColumn("ServiceDetail", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("CurrencyID", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("CurrencyType", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    ''columnISRAdd = New DataColumn("UnitPriceC", System.Type.[GetType]("System.Decimal"))
                    ''dtISR.Columns.Add(columnISRAdd)
                    ''columnISRAdd = New DataColumn("ValueC", System.Type.[GetType]("System.Decimal"))
                    ''dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T0Value", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T0Desc", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T0", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T1Value", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T1", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T1Desc", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T2Value", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T2", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T2Desc", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T3", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T3Desc", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T3Value", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T4", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T4Value", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("T4Desc", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)
                    columnISRAdd = New DataColumn("NonStockID", System.Type.[GetType]("System.String"))
                    dtISR.Columns.Add(columnISRAdd)

                    rowISRAdd("COACode") = txtAccountCode.Text.Trim()
                    rowISRAdd("COAID") = strISRAccountID
                    rowISRAdd("CurrencyID") = strCurrencyID
                    rowISRAdd("STISRID") = psSTISRID

                    rowISRAdd("ServiceType") = cmbServicetype.Text.Trim
                    'rowISRAdd("StockID") = psISRStockID
                    rowISRAdd("NonStockID") = psISRStockID
                    rowISRAdd("StockCode") = psISRStockCode
                    rowISRAdd("StockDesc") = psISRStockDesc

                    If lblAcCodeDesc.Text <> String.Empty Then
                        rowISRAdd("COADescp") = lblAcCodeDesc.Text.Trim()
                    End If

                    If lblOldAccountCode.Text <> String.Empty Then
                        rowISRAdd("OldCOACode") = lblOldAccountCode.Text.Trim()
                    End If

                    If txtQty.Text <> String.Empty Then
                        rowISRAdd("Qty") = txtQty.Text.Trim()
                    End If

                    If txtUnit.Text <> String.Empty Then
                        rowISRAdd("Unit") = txtUnit.Text.Trim()
                    End If

                    If txtUnitPrice.Text <> String.Empty Then
                        rowISRAdd("UnitPrice") = txtUnitPrice.Text.Trim()
                    End If

                    If txtTotalPrice.Text <> String.Empty Then
                        rowISRAdd("Value") = txtTotalPrice.Text.Trim()
                    End If

                    If txtServiceDetails.Text <> String.Empty Then
                        rowISRAdd("ServiceDetail") = txtServiceDetails.Text.Trim()
                    End If

                    If cmbCurrencyType.Text <> String.Empty Then
                        rowISRAdd("CurrencyType") = cmbCurrencyType.Text.Trim()
                    End If

                    'If txtUnitPriceC.Text <> String.Empty Then
                    '    rowISRAdd("UnitPriceC") = CDbl(txtUnitPriceC.Text.Trim())
                    'Else
                    '    rowISRAdd("UnitPriceC") = 0.0
                    'End If

                    'If txtTotalPriceC.Text <> String.Empty Then
                    '    rowISRAdd("ValueC") = txtTotalPriceC.Text.Trim()
                    'Else
                    '    rowISRAdd("ValueC") = 0.0
                    'End If

                    If txtTAnalysisT0.Text <> String.Empty Then
                        rowISRAdd("T0Value") = txtTAnalysisT0.Text.Trim()
                    End If
                    If lblISRT0Name.Text <> String.Empty Then
                        rowISRAdd("T0Desc") = lblISRT0Name.Text.Trim
                    End If
                    rowISRAdd("T0") = strISRT0analysisID

                    If txtTAnalysisT1.Text <> String.Empty Then
                        rowISRAdd("T1Value") = txtTAnalysisT1.Text.Trim()
                    End If
                    If lblISRT1Name.Text <> String.Empty Then
                        rowISRAdd("T1Desc") = lblISRT1Name.Text.Trim()
                    End If
                    rowISRAdd("T1") = strISRT1analysisID

                    If txtTAnalysisT2.Text <> String.Empty Then
                        rowISRAdd("T2Value") = txtTAnalysisT2.Text.Trim()
                    End If
                    rowISRAdd("T2") = strISRT2analysisID
                    If lblISRT2Name.Text <> String.Empty Then
                        rowISRAdd("T2Desc") = lblISRT2Name.Text.Trim()
                    End If

                    If txtTAnalysisT3.Text <> String.Empty Then
                        rowISRAdd("T3Value") = txtTAnalysisT3.Text.Trim()
                    End If
                    rowISRAdd("T3") = strISRT3analysisID

                    If lblISRT3Name.Text <> String.Empty Then
                        rowISRAdd("T3Desc") = lblISRT3Name.Text.Trim()
                    End If

                    If txtTAnalysisT4.Text <> String.Empty Then
                        rowISRAdd("T4Value") = txtTAnalysisT4.Text.Trim()
                    End If
                    rowISRAdd("T4") = strISRT4analysisID
                    If lblISRT4Name.Text <> String.Empty Then
                        rowISRAdd("T4Desc") = lblISRT4Name.Text.Trim()
                    End If

                    dtISR.Rows.InsertAt(rowISRAdd, intRowcount)
                    dtAddFlag = True
                    dgvISRDetails.DataSource = dtISR

                Else

                    rowISRAdd("COACode") = txtAccountCode.Text.Trim()
                    rowISRAdd("COAID") = strISRAccountID
                    rowISRAdd("CurrencyID") = strCurrencyID
                    rowISRAdd("STISRID") = psSTISRID


                    If psISRStockID <> String.Empty Then
                        rowISRAdd("NonStockID") = psISRStockID
                    Else
                        rowISRAdd("NonStockID") = String.Empty
                    End If
                    'If psISRStockID <> String.Empty Then
                    '    rowISRAdd("StockID") = psISRStockID
                    'Else
                    '    rowISRAdd("StockID") = String.Empty
                    'End If

                    If psISRStockCode <> String.Empty Then
                        rowISRAdd("StockCode") = psISRStockCode
                    Else
                        rowISRAdd("StockCode") = String.Empty
                    End If
                    If psISRStockDesc <> String.Empty Then
                        rowISRAdd("StockDesc") = psISRStockDesc
                    Else
                        rowISRAdd("StockDesc") = String.Empty
                    End If
                    If cmbServicetype.Text <> String.Empty Then
                        rowISRAdd("ServiceType") = cmbServicetype.Text.Trim
                    Else
                        rowISRAdd("ServiceType") = String.Empty
                    End If




                    If lblAcCodeDesc.Text <> String.Empty Then
                        rowISRAdd("COADescp") = lblAcCodeDesc.Text.Trim()
                    End If

                    If lblOldAccountCode.Text <> String.Empty Then
                        rowISRAdd("OldCOACode") = lblOldAccountCode.Text.Trim()
                    End If

                    If txtQty.Text <> String.Empty Then
                        rowISRAdd("Qty") = txtQty.Text.Trim()
                    End If

                    If txtUnit.Text <> String.Empty Then
                        rowISRAdd("Unit") = txtUnit.Text.Trim()
                    End If

                    If txtUnitPrice.Text <> String.Empty Then
                        rowISRAdd("UnitPrice") = txtUnitPrice.Text.Trim()
                    End If

                    If txtTotalPrice.Text <> String.Empty Then
                        rowISRAdd("Value") = txtTotalPrice.Text.Trim()
                    End If

                    If txtServiceDetails.Text <> String.Empty Then
                        rowISRAdd("ServiceDetail") = txtServiceDetails.Text.Trim()
                    End If

                    If cmbCurrencyType.Text <> String.Empty Then
                        rowISRAdd("CurrencyType") = cmbCurrencyType.Text.Trim
                    End If

                    'If txtUnitPriceC.Text <> String.Empty Then
                    '    rowISRAdd("UnitPriceC") = txtUnitPriceC.Text.Trim()
                    'End If

                    'If txtTotalPriceC.Text <> String.Empty Then
                    '    rowISRAdd("ValueC") = txtTotalPriceC.Text.Trim()
                    'End If
                    If txtTAnalysisT0.Text <> String.Empty Then
                        rowISRAdd("T0Value") = txtTAnalysisT0.Text.Trim()
                    End If
                    rowISRAdd("T0") = strISRT0analysisID
                    If lblISRT0Name.Text <> String.Empty Then
                        rowISRAdd("T0Desc") = lblISRT0Name.Text.Trim
                    End If


                    If txtTAnalysisT1.Text <> String.Empty Then
                        rowISRAdd("T1Value") = txtTAnalysisT1.Text.Trim()
                    End If
                    If lblISRT1Name.Text <> String.Empty Then
                        rowISRAdd("T1Desc") = lblISRT1Name.Text.Trim()
                    End If
                    rowISRAdd("T1") = strISRT1analysisID

                    If txtTAnalysisT2.Text <> String.Empty Then
                        rowISRAdd("T2Value") = txtTAnalysisT2.Text.Trim()
                    End If
                    If lblISRT2Name.Text <> String.Empty Then
                        rowISRAdd("T2Desc") = lblISRT2Name.Text.Trim()
                    End If
                    rowISRAdd("T2") = strISRT2analysisID

                    If txtTAnalysisT3.Text <> String.Empty Then
                        rowISRAdd("T3Value") = txtTAnalysisT3.Text.Trim()
                    End If
                    If lblISRT3Name.Text <> String.Empty Then
                        rowISRAdd("T3Desc") = lblISRT3Name.Text.Trim()
                    End If
                    rowISRAdd("T3") = strISRT3analysisID

                    If txtTAnalysisT4.Text <> String.Empty Then
                        rowISRAdd("T4Value") = txtTAnalysisT4.Text.Trim()
                    End If
                    If lblISRT4Name.Text <> String.Empty Then
                        rowISRAdd("T4Desc") = lblISRT4Name.Text.Trim()
                    End If
                    rowISRAdd("T4") = strISRT4analysisID

                    ''rowISRAdd("T4Desc") = If(lblISRT4Name.Text <> String.Empty, Nothing, lblISRT4Name.Text.Trim())

                    dtISR.Rows.InsertAt(rowISRAdd, intRowcount)
                    dtAddFlag = True
                    dgvISRDetails.DataSource = dtISR

                End If
                reset()
            Else
                'MsgBox("Sorry, the Account Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
                DisplayInfoMessage("msg26")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub UpdateISRDetail()
        Dim strACCode As String = txtAccountCode.Text.Trim()
        strCurrencyID = cmbCurrencyType.SelectedItem("CurrencyID").ToString
        For i As Integer = 0 To dgvISRDetails.Rows.Count - 1
            If i <> dgvISRDetails.CurrentRow.Index Then
                If strACCode = dgvISRDetails.Rows(i).Cells("COACode").Value.ToString() Then
                    'MsgBox("Account Code already exist in this ITN-IN Details")
                    DisplayInfoMessage("msg27")
                    reset()
                    txtAccountCode.Focus()
                    Exit Sub
                End If
            Else
            End If
        Next
        ''Dim intCount As Integer
        Dim intCount As New Integer
        ''Dim intCount As Integer = dgvISRDetails.CurrentRow.Index
        intCount = dgvISRDetails.CurrentRow.Index
        If txtAccountCode.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("COACode").Value = txtAccountCode.Text.Trim
        End If
        dgvISRDetails.Rows(intCount).Cells("COAID").Value = strISRAccountID
        dgvISRDetails.Rows(intCount).Cells("CurrencyID").Value = strCurrencyID

        If psISRStockID <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("NonStockID").Value = psISRStockID
        Else
            dgvISRDetails.Rows(intCount).Cells("NonStockID").Value = String.Empty
        End If
        'If psISRStockID <> String.Empty Then
        '    dgvISRDetails.Rows(intCount).Cells("StockID").Value = psISRStockID
        'Else
        '    dgvISRDetails.Rows(intCount).Cells("StockID").Value = String.Empty
        'End If

        If lblAcCodeDesc.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("COADescp").Value = lblAcCodeDesc.Text.Trim()
        Else
            dgvISRDetails.Rows(intCount).Cells("COADescp").Value = String.Empty
        End If
        If txtQty.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("Qty").Value = txtQty.Text.Trim
        End If
        If txtUnit.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("Unit").Value = txtUnit.Text.Trim
        End If
        If txtUnitPrice.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("UnitPrice").Value = txtUnitPrice.Text.Trim
        End If
        If txtTotalPrice.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("Value").Value = txtTotalPrice.Text.Trim
        End If

        If cmbServicetype.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("ServiceType").Value = cmbServicetype.Text.Trim
        End If
        If txtStockcode.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("StockCode").Value = txtStockcode.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("StockCode").Value = String.Empty

        End If
        If lblStockcodedesc.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("StockDesc").Value = lblStockcodedesc.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("StockDesc").Value = String.Empty
        End If

        If txtServiceDetails.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("ServiceDetail").Value = txtServiceDetails.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("ServiceDetail").Value = String.Empty
        End If
        If cmbCurrencyType.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("CurrencyType").Value = cmbCurrencyType.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("CurrencyType").Value = String.Empty
        End If
        'If txtUnitPriceC.Text.Trim <> String.Empty Then
        '    dgvISRDetails.Rows(intCount).Cells("UnitPrice_Currency").Value = txtUnitPriceC.Text
        'Else
        '    dgvISRDetails.Rows(intCount).Cells("UnitPrice_Currency").Value = 0.0
        'End If
        'If txtTotalPriceC.Text.Trim <> String.Empty Then
        '    dgvISRDetails.Rows(intCount).Cells("TotalPrice_Currency").Value = txtTotalPriceC.Text
        'Else
        'dgvISRDetails.Rows(intCount).Cells("TotalPrice_Currency").Value = 0.0
        'End If

        If txtTAnalysisT0.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T0Value").Value = txtTAnalysisT0.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T0Value").Value = String.Empty
        End If
        dgvISRDetails.Rows(intCount).Cells("T0").Value = strISRT0analysisID
        If lblISRT0Name.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T0Desc").Value = lblISRT0Name.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T0Desc").Value = String.Empty
        End If
        If txtTAnalysisT1.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T1Value").Value = txtTAnalysisT1.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T1Value").Value = String.Empty
        End If
        dgvISRDetails.Rows(intCount).Cells("T1").Value = strISRT1analysisID
        If lblISRT1Name.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T1Desc").Value = lblISRT1Name.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T1Desc").Value = String.Empty
        End If
        If txtTAnalysisT2.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T2Value").Value = txtTAnalysisT2.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T2Value").Value = String.Empty
        End If
        dgvISRDetails.Rows(intCount).Cells("T2").Value = strISRT2analysisID
        If lblISRT2Name.Text.Trim Is DBNull.Value Then
            dgvISRDetails.Rows(intCount).Cells("T2Desc").Value = lblISRT2Name.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T2Desc").Value = String.Empty
        End If
        If txtTAnalysisT3.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T3Value").Value = txtTAnalysisT3.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T3Value").Value = String.Empty
        End If
        dgvISRDetails.Rows(intCount).Cells("T3").Value = strISRT3analysisID
        If lblISRT3Name.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T3Desc").Value = lblISRT3Name.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T3Desc").Value = String.Empty
        End If
        If txtTAnalysisT4.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T4Value").Value = txtTAnalysisT4.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T4Value").Value = String.Empty
        End If
        dgvISRDetails.Rows(intCount).Cells("T4").Value = strISRT4analysisID
        If lblISRT4Name.Text.Trim <> String.Empty Then
            dgvISRDetails.Rows(intCount).Cells("T4Desc").Value = lblISRT4Name.Text.Trim
        Else
            dgvISRDetails.Rows(intCount).Cells("T4Desc").Value = String.Empty
        End If
        reset()
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
    End Sub

    Private Function AccountcodeExist(ByVal AccountCode As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvISRDetails.Rows
                If AccountCode = objDataGridViewRow.Cells("COAID").Value.ToString() Then
                    txtAccountCode.Text = String.Empty
                    'txtRequestedQty.Text = string.empty 
                    txtAccountCode.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub Currencytypeget()
        Dim objISRPPT As New InternalServiceRequisitionPPT
        ''Dim objISRBOL As New InternalServiceRequisitionBOL
        Dim dt As New DataTable
        dt = InternalServiceRequisitionBOL.CURRENCYTYPEGET(objISRPPT)
        If dt.Rows.Count <> 0 Then
            cmbCurrencyType.DataSource = dt
            cmbCurrencyType.DisplayMember = "CurrencyType"
            cmbCurrencyType.ValueMember = "CurrencyID"
        End If
    End Sub

    Private Sub cmbCurrencyType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cmbCurrencyType.Text <> String.Empty Then
            lblUnitPricedesc.Text = cmbCurrencyType.Text
            lblTotalPricedesc.Text = cmbCurrencyType.Text
        End If
    End Sub

    Private Sub reset()

        btnAddFlag = True
        Currencytypeget()
        txtAccountCode.Text = String.Empty
        lblAcCodeDesc.Text = String.Empty
        lblOldAccountCode.Text = String.Empty
        txtQty.Text = String.Empty
        txtUnit.Text = String.Empty
        txtUnitPrice.Text = String.Empty
        txtTotalPrice.Text = "0"
        txtServiceDetails.Text = String.Empty
        txtTAnalysisT0.Text = String.Empty
        strISRT0analysisID = String.Empty
        txtTAnalysisT1.Text = String.Empty
        strISRT1analysisID = String.Empty
        txtTAnalysisT2.Text = String.Empty
        strISRT2analysisID = String.Empty
        txtTAnalysisT3.Text = String.Empty
        strISRT3analysisID = String.Empty
        txtTAnalysisT4.Text = String.Empty
        strISRT4analysisID = String.Empty
        lblISRT0Name.Text = String.Empty
        lblISRT1Name.Text = String.Empty
        lblISRT2Name.Text = String.Empty
        lblISRT3Name.Text = String.Empty
        lblISRT4Name.Text = String.Empty
        'txtUnitPriceC.Text = String.Empty
        'txtTotalPriceC.Text = String.Empty
        strCurrencyID = String.Empty
        lblStockCode.Enabled = True
        txtStockcode.Text = String.Empty
        lblStockcodedesc.Text = String.Empty


        txtServiceDetails.Text = String.Empty
        If cmbServicetype.Text = "5SERV" Then
            lblStockCode.Enabled = True
            txtStockcode.Enabled = True
        Else
            lblServiceDetails.Enabled = True
            txtServiceDetails.Enabled = True
            lblStockCode.Enabled = False
            txtStockcode.Enabled = False
        End If
        psISRStockID = String.Empty
        psISRStockDesc = String.Empty
        psISRStockCode = String.Empty
        ''btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        If cmbCurrencyType.Text <> String.Empty Then
            lblUnitPricedesc.Text = cmbCurrencyType.Text
            lblTotalPricedesc.Text = cmbCurrencyType.Text
        End If
        txtAccountCode.Focus()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dgvISRDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvISRDetails.CellDoubleClick
        ISRGrid_Edit()
        btnAddFlag = False
    End Sub

    Private Sub ISRGrid_Edit()
        If dgvISRDetails.Rows.Count > 0 Then

            If Not dgvISRDetails.SelectedRows(0).Cells("ServiceType").Value Is DBNull.Value Then
                cmbServicetype.Text = dgvISRDetails.SelectedRows(0).Cells("ServiceType").Value.ToString()
                If cmbServicetype.Text = "5SERV" Then
                    txtServiceDetails.Text = String.Empty
                    lblStockcodedesc.Text = String.Empty
                    ''strStockID = String.Empty
                    lblStockCode.Enabled = True
                    txtStockcode.Enabled = True
                    btnstockcodelookup.Enabled = True
                Else
                    lblStockCode.Enabled = False
                    txtStockcode.Text = String.Empty
                    lblStockcodedesc.Text = String.Empty
                    ''strStockID = String.Empty
                    lblServiceDetails.Enabled = True
                    txtServiceDetails.Enabled = True
                    txtServiceDetails.Text = String.Empty
                End If
            Else
                cmbServicetype.Text = String.Empty
            End If

            If Not dgvISRDetails.SelectedRows(0).Cells("StockCode").Value Is DBNull.Value Then
                txtStockcode.Text = dgvISRDetails.SelectedRows(0).Cells("StockCode").Value.ToString()
            Else
                txtStockcode.Text = String.Empty
            End If

            If Not dgvISRDetails.SelectedRows(0).Cells("StockDesc").Value Is DBNull.Value Then
                lblStockcodedesc.Text = dgvISRDetails.SelectedRows(0).Cells("StockDesc").Value.ToString()
            Else
                lblStockcodedesc.Text = String.Empty
            End If

            If Not dgvISRDetails.SelectedRows(0).Cells("NonStockID").Value Is DBNull.Value Then
                psISRStockID = dgvISRDetails.SelectedRows(0).Cells("NonStockID").Value.ToString()
            Else
                psISRStockID = String.Empty
            End If
            ''  psISRStockID = dgvISRDetails.SelectedRows(0).Cells("StockID").Value


            'If Not dgvISRDetails.SelectedRows(0).Cells("StockID").Value Is DBNull.Value Then
            '    psISRStockID = dgvISRDetails.SelectedRows(0).Cells("StockID").Value.ToString()
            'Else
            '    psISRStockID = String.Empty
            'End If
            ' ''  psISRStockID = dgvISRDetails.SelectedRows(0).Cells("StockID").Value


            txtAccountCode.Text = dgvISRDetails.SelectedRows(0).Cells("COACode").Value.ToString()
            strISRAccountID = dgvISRDetails.SelectedRows(0).Cells("COAID").Value
            If Not dgvISRDetails.SelectedRows(0).Cells("COADescp").Value Is DBNull.Value Then
                lblAcCodeDesc.Text = dgvISRDetails.SelectedRows(0).Cells("COADescp").Value.ToString()
            Else
                lblAcCodeDesc.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("OldCOACode").Value Is Nothing Then
                lblOldAccountCode.Text = dgvISRDetails.SelectedRows(0).Cells("OldCOACode").Value.ToString()
            Else
                lblOldAccountCode.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("Qty").Value Is DBNull.Value Then
                txtQty.Text = dgvISRDetails.SelectedRows(0).Cells("Qty").Value
            Else
                txtQty.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("Unit").Value Is DBNull.Value Then
                txtUnit.Text = dgvISRDetails.SelectedRows(0).Cells("Unit").Value
            Else
                txtUnit.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("UnitPrice").Value Is DBNull.Value Then
                txtUnitPrice.Text = dgvISRDetails.SelectedRows(0).Cells("UnitPrice").Value
            Else
                txtUnitPrice.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("Value").Value Is DBNull.Value Then
                'txtTotalPrice.Text = dgvISRDetails.SelectedRows(0).Cells("Value").Value
                txtTotalPrice.Text = Format(Val(dgvISRDetails.SelectedRows(0).Cells("Value").Value), "0")
            Else
                txtTotalPrice.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("ServiceDetail").Value Is DBNull.Value Then
                txtServiceDetails.Text = dgvISRDetails.SelectedRows(0).Cells("ServiceDetail").Value
            Else
                txtServiceDetails.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T0Value").Value Is DBNull.Value Then
                txtTAnalysisT0.Text = dgvISRDetails.SelectedRows(0).Cells("T0Value").Value
            Else
                txtTAnalysisT0.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T0Desc").Value Is DBNull.Value Then
                lblISRT0Name.Text = dgvISRDetails.SelectedRows(0).Cells("T0Desc").Value
            Else
                lblISRT0Name.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T0").Value Is DBNull.Value Then
                strISRT0analysisID = dgvISRDetails.SelectedRows(0).Cells("T0").Value
            Else
                strISRT0analysisID = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T1Value").Value Is DBNull.Value Then
                txtTAnalysisT1.Text = dgvISRDetails.SelectedRows(0).Cells("T1Value").Value
            Else
                txtTAnalysisT1.Text = String.Empty
            End If

            If Not dgvISRDetails.SelectedRows(0).Cells("T1Desc").Value Is DBNull.Value Then
                lblISRT1Name.Text = dgvISRDetails.SelectedRows(0).Cells("T1Desc").Value
            Else
                lblISRT1Name.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T1").Value Is DBNull.Value Then
                strISRT1analysisID = dgvISRDetails.SelectedRows(0).Cells("T1").Value
            Else
                strISRT1analysisID = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T2Value").Value Is DBNull.Value Then
                txtTAnalysisT2.Text = dgvISRDetails.SelectedRows(0).Cells("T2Value").Value
            Else
                txtTAnalysisT2.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T2Desc").Value Is DBNull.Value Then
                lblISRT2Name.Text = dgvISRDetails.SelectedRows(0).Cells("T2Desc").Value
            Else
                lblISRT2Name.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T2").Value Is DBNull.Value Then
                strISRT2analysisID = dgvISRDetails.SelectedRows(0).Cells("T2").Value
            Else
                strISRT2analysisID = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T3Value").Value Is DBNull.Value Then
                txtTAnalysisT3.Text = dgvISRDetails.SelectedRows(0).Cells("T3Value").Value
            Else
                txtTAnalysisT3.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T3Desc").Value Is DBNull.Value Then
                lblISRT3Name.Text = dgvISRDetails.SelectedRows(0).Cells("T3Desc").Value
            Else
                lblISRT3Name.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T3").Value Is DBNull.Value Then
                strISRT3analysisID = dgvISRDetails.SelectedRows(0).Cells("T3").Value
            Else
                strISRT3analysisID = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T4Value").Value Is DBNull.Value Then
                txtTAnalysisT4.Text = dgvISRDetails.SelectedRows(0).Cells("T4Value").Value
            Else
                txtTAnalysisT4.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T4Desc").Value Is DBNull.Value Then
                lblISRT4Name.Text = dgvISRDetails.SelectedRows(0).Cells("T4Desc").Value
            Else
                lblISRT4Name.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("T4").Value Is DBNull.Value Then
                strISRT4analysisID = dgvISRDetails.SelectedRows(0).Cells("T4").Value
            Else
                strISRT4analysisID = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("CurrencyType").Value Is DBNull.Value Then
                cmbCurrencyType.Text = dgvISRDetails.SelectedRows(0).Cells("CurrencyType").Value
            Else
                cmbCurrencyType.Text = String.Empty
            End If
            If Not dgvISRDetails.SelectedRows(0).Cells("CurrencyID").Value Is DBNull.Value Then
                strCurrencyID = dgvISRDetails.SelectedRows(0).Cells("CurrencyID").Value
            Else
                strCurrencyID = String.Empty
            End If
            ''If Not dgvISRDetails.SelectedRows(0).Cells("UnitPrice_Currency").Value Is DBNull.Value Then
            ''    txtUnitPriceC.Text = dgvISRDetails.SelectedRows(0).Cells("UnitPrice_Currency").Value
            ''Else
            ''    txtUnitPriceC.Text = String.Empty
            ''End If
            ''If Not dgvISRDetails.SelectedRows(0).Cells("TotalPrice_Currency").Value Is DBNull.Value Then
            ''    txtTotalPriceC.Text = dgvISRDetails.SelectedRows(0).Cells("TotalPrice_Currency").Value
            ''Else
            ''    txtTotalPriceC.Text = String.Empty
            ''End If
            ''btnAdd.Text = "Update"

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
        End If

    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click

        ResetAll()

    End Sub

    Private Sub ResetAll()

        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        Clear()
        'Currencytypeget()
        btnAddFlag = True
        btsaveallFlag = True

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        reset()
        btnAddFlag = True
    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        reset()
        btnAddFlag = True
    End Sub

    Private Sub UpdateToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem2.Click
        ISRGrid_Edit()
        btnAddFlag = False
    End Sub

    'Private Sub txtUnitPriceC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtQty.Text.Trim() <> String.Empty And txtUnitPriceC.Text.Trim() <> String.Empty Then
    '        txtTotalPriceC.Text = Math.Round((Val(txtQty.Text) * Val(txtUnitPriceC.Text)), 2)
    '    Else
    '        txtTotalPriceC.Text = String.Empty
    '    End If
    'End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalServiceRequisitionFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tcISRView.TabPages("tbpgISR").Text = rm.GetString("tcISRView.TabPages(tbpgISR).Text")
            tcISRView.TabPages("tbpgView").Text = rm.GetString("tcISRView.TabPages(tbpgView).Text")
            'Add Tab Controls
            lblISRDate.Text = rm.GetString("lblISRDate.Text")
            lblISRNo.Text = rm.GetString("lblISRNo.Text")
            lblSuggestedSupplier.Text = rm.GetString("lblSuggestedSupplier.Text")
            lblRequiredFor.Text = rm.GetString("lblRequiredFor.Text")
            gbEnquipmentData.Text = rm.GetString("gbEnquipmentData.Text")
            lblMakeandModel.Text = rm.GetString("lblMakeandModel.Text")
            lblEngine.Text = rm.GetString("lblEngine.Text")
            lblChassisSerialNo.Text = rm.GetString("lblChassisSerialNo.Text")
            lblFixedAssetNo.Text = rm.GetString("lblFixedAssetNo.Text")
            GroupBox2.Text = rm.GetString("gbISRDetails.Text")
            lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
            lblOldAcctCode.Text = rm.GetString("lblOldAcctCode.Text")

            lblQty.Text = rm.GetString("lblQty.Text")
            lblUnit.Text = rm.GetString("lblUnit.Text")
            lblUnitPrice.Text = rm.GetString("lblUnitPrice.Text")
            ''lblUnitPriceC.Text = rm.GetString("lblUnitPriceC.Text")
            ''lblTotalPriceC.Text = rm.GetString("lblTotalPriceC.Text")
            lblCurrencyType.Text = rm.GetString("lblCurrencyType.Text")

            lblServicetype.Text = rm.GetString("lblServicetype.Text")
            lblStockCode.Text = rm.GetString("lblStockCode.Text")

            lblTotalPrice.Text = rm.GetString("lblTotalPrice.Text")
            lblServiceDetails.Text = rm.GetString("lblServiceDetails.Text")
            lblTAnalysisT0.Text = rm.GetString("lblTAnalysisT0.Text")
            lblTAnalysisT1.Text = rm.GetString("lblTAnalysisT1.Text")
            lblTAnalysisT2.Text = rm.GetString("lblTAnalysisT2.Text")
            lblTAnalysisT3.Text = rm.GetString("lblTAnalysisT3.Text")
            lblTAnalysisT4.Text = rm.GetString("lblTAnalysisT4.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")

            dgvISRDetails.Columns("ServiceType").HeaderText = rm.GetString("dgvISRDetails.Columns(ServiceType).HeaderText")
            dgvISRDetails.Columns("StockCode").HeaderText = rm.GetString("dgvISRDetails.Columns(StockCode).HeaderText")
            dgvISRDetails.Columns("StockDesc").HeaderText = rm.GetString("dgvISRDetails.Columns(StockDesc).HeaderText")

            dgvISRDetails.Columns("COACode").HeaderText = rm.GetString("dgvISRDetails.Columns(COACode).HeaderText")
            dgvISRDetails.Columns("COADescp").HeaderText = rm.GetString("dgvISRDetails.Columns(COADescp).HeaderText")
            dgvISRDetails.Columns("OldCOACode").HeaderText = rm.GetString("dgvISRDetails.Columns(OldCOACode).HeaderText")
            dgvISRDetails.Columns("Qty").HeaderText = rm.GetString("dgvISRDetails.Columns(Qty).HeaderText")
            dgvISRDetails.Columns("Unit").HeaderText = rm.GetString("dgvISRDetails.Columns(Unit).HeaderText")
            dgvISRDetails.Columns("UnitPrice").HeaderText = rm.GetString("dgvISRDetails.Columns(UnitPrice).HeaderText")
            dgvISRDetails.Columns("Value").HeaderText = rm.GetString("dgvISRDetails.Columns(Value).HeaderText")
            dgvISRDetails.Columns("CurrencyType").HeaderText = rm.GetString("dgvISRDetails.Columns(CurrencyType).HeaderText")
            dgvISRDetails.Columns("ServiceDetail").HeaderText = rm.GetString("dgvISRDetails.Columns(ServiceDetail).HeaderText")
            dgvISRDetails.Columns("UnitPrice_Currency").HeaderText = rm.GetString("dgvISRDetails.Columns(UnitPrice_Currency).HeaderText")
            dgvISRDetails.Columns("TotalPrice_Currency").HeaderText = rm.GetString("dgvISRDetails.Columns(TotalPrice_Currency).HeaderText")
            dgvISRDetails.Columns("T0Value").HeaderText = rm.GetString("dgvISRDetails.Columns(T0Value).HeaderText")
            dgvISRDetails.Columns("T1Value").HeaderText = rm.GetString("dgvISRDetails.Columns(T1Value).HeaderText")
            dgvISRDetails.Columns("T2Value").HeaderText = rm.GetString("dgvISRDetails.Columns(T2Value).HeaderText")
            dgvISRDetails.Columns("T3Value").HeaderText = rm.GetString("dgvISRDetails.Columns(T3Value).HeaderText")
            dgvISRDetails.Columns("T4Value").HeaderText = rm.GetString("dgvISRDetails.Columns(T4Value).HeaderText")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            'View Tab Controls
            pnlISRSearch.CaptionText = rm.GetString("pnlISRSearch.CaptionText")
            lblviewISRDate.Text = rm.GetString("lblviewISRDate.Text")
            lblviewISRno.Text = rm.GetString("lblviewISRno.Text")
            btnviewISRSearch.Text = rm.GetString("btnviewISRSearch.Text")
            btnviewISRReport.Text = rm.GetString("btnviewISRReport.Text")
            btnviewISRReport.Text = rm.GetString("btnviewISRReport.Text")
            lblviewISRSearchBy.Text = rm.GetString("lblviewISRSearchBy.Text")
            dgvviewISR.Columns("ISRDate").HeaderText = rm.GetString("dgvviewISR.Columns(ISRDate).HeaderText")
            dgvviewISR.Columns("ISRNo").HeaderText = rm.GetString("dgvviewISR.Columns(ISRNo).HeaderText")
            dgvviewISR.Columns("Supplier").HeaderText = rm.GetString("dgvviewISR.Columns(Supplier).HeaderText")
            dgvviewISR.Columns("MakeModel").HeaderText = rm.GetString("dgvviewISR.Columns(MakeModel).HeaderText")
            dgvviewISR.Columns("Engine").HeaderText = rm.GetString("dgvviewISR.Columns(Engine).HeaderText")
            dgvviewISR.Columns("ChassisNo").HeaderText = rm.GetString("dgvviewISR.Columns(ChassisNo).HeaderText")
            dgvviewISR.Columns("FixedAssetNo").HeaderText = rm.GetString("dgvviewISR.Columns(FixedAssetNo).HeaderText")
        Catch
            ''display a message if the culture is not supported
            ''try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnviewISRReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewISRReport.Click

        Dim ObjRecordExist As New Object
        Dim ObjISR As New InternalServiceRequisitionPPT
        Dim ObjISRBOL As New InternalServiceRequisitionBOL
        ObjRecordExist = ObjISRBOL.ISRRecordIsExisT(ObjISR)

        If ObjRecordExist = 0 Then
            'MsgBox("No Records Available!")
            DisplayInfoMessage("msg28")
        Else
            StrFrmName = "ISR"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub

    Private Sub txtAccountCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountCode.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtAccountCode.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                txtQty.Focus()
            End If
        End If
    End Sub

    ''Private Sub cmbServicetype_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicetype.SelectedValueChanged

    ''    ''If cmbServicetype.Text = "5SERV" Then

    ''    ''    txtServiceDetails.Text = String.Empty
    ''    ''    txtStockcode.Text = String.Empty
    ''    ''    lblStockcodedesc.Text = String.Empty
    ''    ''    ''strStockID = String.Empty
    ''    ''    lblStockCode.Enabled = True
    ''    ''    txtStockcode.Enabled = True
    ''    ''    btnstockcodelookup.Enabled = True

    ''    ''    If cmbServicetype.Text.Trim() <> String.Empty Then
    ''    ''        Dim dt As New DataTable
    ''    ''        Dim CategoryDesc As String
    ''    ''        Dim objIPRPPT As New StoreIssueVoucherPPT
    ''    ''        Dim objIPRData As New StoreIssueVoucherBOL
    ''    ''        CategoryDesc = cmbServicetype.Text
    ''    ''        dt = objIPRData.StockCategorySearch(CategoryDesc)
    ''    ''        If dt.Rows.Count > 0 Then
    ''    ''            strStockCategoryCode = dt.Rows(0).Item("STCategoryDescp").ToString()
    ''    ''            strStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()
    ''    ''            strISRStockCategoryIDForStock = dt.Rows(0).Item("STCategoryID").ToString()
    ''    ''            IPRPPT.strGlobalCategoryID = strISRStockCategoryIDForStock
    ''    ''        Else
    ''    ''            lblStockCode.Enabled = False
    ''    ''            txtStockcode.Enabled = False
    ''    ''            btnstockcodelookup.Enabled = False
    ''    ''            DisplayInfoMessage("msg32")
    ''    ''        End If
    ''    ''    End If

    ''    ''Else
    ''    ''    IPRPPT.strGlobalCategoryID = String.Empty
    ''    ''    txtStockcode.Text = String.Empty
    ''    ''    lblStockcodedesc.Text = String.Empty
    ''    ''    strStockID = String.Empty
    ''    ''    lblStockCode.Enabled = False
    ''    ''    txtStockcode.Enabled = False
    ''    ''    btnstockcodelookup.Enabled = False
    ''    ''    lblServiceDetails.Enabled = True
    ''    ''    txtServiceDetails.Enabled = True
    ''    ''    psISRStockID = String.Empty
    ''    ''End If


    ''    If cmbServicetype.Text = "5SERV" Then

    ''        txtServiceDetails.Text = String.Empty
    ''        txtStockcode.Text = String.Empty
    ''        lblStockcodedesc.Text = String.Empty
    ''        ''strstockid = string.empty
    ''        lblStockCode.Enabled = True
    ''        txtStockcode.Enabled = True
    ''        btnstockcodelookup.Enabled = True

    ''        StrFrmName = "NonStockIPR"

    ''        Dim dt As New DataTable
    ''        Dim objStkCategoryPPT As New NonStockIPRPPT
    ''        Dim objStkCategoryBOL As New NonStockIPRBOL

    ''        objStkCategoryPPT.STCategory = cmbServicetype.Text.Trim
    ''        dt = objStkCategoryBOL.GetNonStockCategory(objStkCategoryPPT, "YES")

    ''        If dt.Rows.Count > 0 Then

    ''            strStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()
    ''            strISRStockCategoryIDForStock = strStockCategoryID
    ''            NonStockIPRFrm.lStockCategoryID = strStockCategoryID
    ''        Else

    ''            lblStockCode.Enabled = False
    ''            txtStockcode.Enabled = False
    ''            btnstockcodelookup.Enabled = False
    ''            DisplayInfoMessage("msg32")
    ''        End If
    ''    Else
    ''        IPRPPT.strGlobalCategoryID = String.Empty
    ''        txtStockcode.Text = String.Empty
    ''        lblStockcodedesc.Text = String.Empty
    ''        strStockID = String.Empty
    ''        lblStockCode.Enabled = False
    ''        txtStockcode.Enabled = False
    ''        btnstockcodelookup.Enabled = False
    ''        lblServiceDetails.Enabled = True
    ''        txtServiceDetails.Enabled = True
    ''        psISRStockID = String.Empty
    ''        'End If
    ''    End If

    ''    StrFrmName = String.Empty

    ''End Sub

    Private Sub btnstockcodelookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnstockcodelookup.Click


        ''Me.Cursor = Cursors.WaitCursor
        ''GlobalPPT.IsStockCategory = False
        ''If cmbServicetype.Text = String.Empty Then
        ''    'MessageBox.Show("Please Select Service Type")
        ''    DisplayInfoMessage("msg29")
        ''Else
        ''    ''''
        ''    Dim ObjStockCode As New IPRPPT
        ''    Dim ObjStockBOL As New IPRBOL
        ''    Dim stockDt As New DataTable
        ''    Dim StockCategory As New StockCodeLookUp()
        ''    Dim result As DialogResult = StockCodeLookUp.ShowDialog()
        ''    If StockCodeLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
        ''        psISRStockCode = StockCodeLookUp._lStockCode
        ''        psISRStockDesc = StockCodeLookUp._lStockDesc
        ''        psISRStockID = StockCodeLookUp._lStockID 'Getting Stock ID From Stock Master
        ''        ObjStockCode.stockID = StockCodeLookUp._lStockID
        ''        Me.txtStockcode.Text = psISRStockCode
        ''        Me.lblStockcodedesc.Text = psISRStockDesc
        ''    End If
        ''End If
        ''Me.Cursor = Cursors.Arrow

        'Me.Cursor = Cursors.WaitCursor
        GlobalPPT.IsStockCategory = True
        If cmbServicetype.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg29")
            ''    'MessageBox.Show("Please Select Service Type")
            cmbServicetype.Focus()
        Else
            Dim stockDt As New DataTable
            Dim ObjNonStockIPRBOL As New NonStockIPRBOL
            Dim ObjNonStockIPRPPT As New NonStockIPRPPT
            Dim StockCode As New NonStockCodeLookup()
            Dim result As DialogResult = NonStockCodeLookup.ShowDialog()

            If NonStockCodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then

                psISRStockCode = NonStockCodeLookup._lStockCode.Trim
                txtStockcode.Text = psISRStockCode
                psISRStockDesc = NonStockCodeLookup._lStockDesc.Trim
                Me.lblStockcodedesc.Text = psISRStockDesc
                psISRStockID = NonStockCodeLookup._lStockID

            End If
        End If
        'Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub txtStockcode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockcode.Leave

        ''If txtStockcode.Text.Trim() <> String.Empty Then
        ''    Dim dt As New DataTable
        ''    Dim dtStock As New DataTable
        ''    Dim objIPRPPT As New IPRPPT
        ''    Dim objIPRBOL As New IPRBOL
        ''    objIPRPPT.STCategoryCode = strStockCategoryCode
        ''    objIPRPPT.STCategory = cmbServicetype.Text
        ''    objIPRPPT.STCategoryID = strISRStockCategoryIDForStock
        ''    objIPRPPT.StockCode = Me.txtStockcode.Text
        ''    dt = objIPRBOL.StockCodeSearch(objIPRPPT)
        ''    If dt.Rows.Count <> 0 Then
        ''        If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then
        ''            psISRStockID = dt.Rows(0).Item("StockId").ToString()
        ''        Else
        ''            psISRStockID = String.Empty
        ''        End If
        ''        If Not dt.Rows(0).Item("StockCode") Is DBNull.Value Then
        ''            Me.txtStockcode.Text = dt.Rows(0).Item("StockCode").ToString()
        ''        Else
        ''            Me.txtStockcode.Text = String.Empty
        ''        End If

        ''        If Not dt.Rows(0).Item("StockDesc") Is DBNull.Value Then
        ''            lblStockcodedesc.Text = dt.Rows(0).Item("StockDesc").ToString()
        ''        Else
        ''            lblStockcodedesc.Text = String.Empty
        ''        End If
        ''    Else
        ''        'MessageBox.Show("Invalid Stock Code,Please Choose it from look up")
        ''        DisplayInfoMessage("msg30")
        ''        txtStockcode.Text = String.Empty
        ''        lblStockcodedesc.Text = String.Empty
        ''        psISRStockID = String.Empty
        ''        txtStockcode.Focus()
        ''    End If

        ''Else
        ''    Me.txtStockcode.Text = String.Empty
        ''    psISRStockID = String.Empty
        ''    lblStockcodedesc.Text = String.Empty
        ''End If


        If txtStockcode.Text.Trim() <> String.Empty Then

            Dim dt As New DataTable
            Dim dtStock As New DataTable
            Dim objNonStockIPRPPT As New NonStockIPRPPT
            Dim objNonStockIPRBOL As New NonStockIPRBOL
            objNonStockIPRPPT.STCategoryCode = strStockCategoryCode
            objNonStockIPRPPT.STCategory = cmbServicetype.Text.Trim
            objNonStockIPRPPT.STCategoryID = strISRStockCategoryIDForStock
            objNonStockIPRPPT.StockCode = Me.txtStockcode.Text.Trim
            dt = objNonStockIPRBOL.StockCodeSearch(objNonStockIPRPPT)

            If dt.Rows.Count <> 0 Then
                psISRStockID = dt.Rows(0).Item("NonStockID").ToString()
                Me.txtStockcode.Text = dt.Rows(0).Item("StockCode").ToString()
                Me.lblStockcodedesc.Text = dt.Rows(0).Item("StockDesc").ToString()

            Else
                'MessageBox.Show("Invalid Stock Code,Please Choose it from look up")
                DisplayInfoMessage("msg30")
                txtStockcode.Text = String.Empty
                lblStockcodedesc.Text = String.Empty
                txtStockcode.Focus()
            End If
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem2.Click

        If dgvISRDetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvISRDetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else
            DeleteMultientrydatagrid()
        End If

    End Sub

    Private Sub DeleteMultientrydatagrid()


        If Not dgvISRDetails.SelectedRows(0).Cells("ISRDetID").Value Is Nothing Then
            lSTISRDetID = dgvISRDetails.SelectedRows(0).Cells("ISRDetID").Value.ToString
        Else
            lSTISRDetID = String.Empty
        End If


        lDelete = 0
        If lSTISRDetID <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lSTISRDetID)

        End If
        Dim Dr As DataRow
        Dr = dtISR.Rows.Item(dgvISRDetails.CurrentRow.Index)
        Dr.Delete()
        dtISR.AcceptChanges()
        lSTISRDetID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objISRPPT As New InternalServiceRequisitionPPT
        Dim objISRBOL As New InternalServiceRequisitionBOL


        lDelete = DeleteMultientry.Count

        While (lDelete > 0)

            With objISRPPT
                .ISRDetID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntISRDetailDelete As New Integer
            IntISRDetailDelete = objISRBOL.DeleteMultiEntryISR(objISRPPT)

            lDelete = lDelete - 1

        End While


    End Sub

    Private Sub cmbCurrencyType_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCurrencyType.SelectedIndexChanged

        If cmbCurrencyType.Text <> String.Empty Then
            lblUnitPricedesc.Text = cmbCurrencyType.Text
            lblTotalPricedesc.Text = cmbCurrencyType.Text
        End If

    End Sub


    Private Sub dgvviewISR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvviewISR.CellContentClick

        If e.ColumnIndex = 11 Then

            Dim ObjRecordExist As New Object
            Dim ObjISR As New InternalServiceRequisitionPPT
            Dim ObjISRBOL As New InternalServiceRequisitionBOL
            ObjRecordExist = ObjISRBOL.ISRRecordIsExisT(ObjISR)

            If ObjRecordExist = 0 Then
                'MsgBox("No Records Available!")
                DisplayInfoMessage("msg28")
            Else

                psSTISRID = dgvviewISR.SelectedRows(0).Cells("STISRID").Value.ToString
                StrFrmName = "ISR"
                ReportODBCMethod.ShowDialog()
                StrFrmName = ""
                psSTISRID = ""

            End If

        End If

    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

        If Val(txtQty.Text) > 0 Then
            txtQty.Text = Format(Val(txtQty.Text), "0")
        End If


    End Sub

    Private Sub cmbCurrencyType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCurrencyType.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub chkviewISRDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkviewISRDate.CheckedChanged

        If chkviewISRDate.Checked = True Then
            dtpviewISRDate.Enabled = True
        Else
            dtpviewISRDate.Enabled = False
        End If

    End Sub


    Private Sub txtServiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub cmbServicetype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicetype.SelectedIndexChanged


        If cmbServicetype.Text = "5SERV" Then

            txtServiceDetails.Text = String.Empty
            txtStockcode.Text = String.Empty
            lblStockcodedesc.Text = String.Empty
            ''strstockid = string.empty
            lblStockCode.Enabled = True
            txtStockcode.Enabled = True
            btnstockcodelookup.Enabled = True

            StrFrmName = "NonStockIPR"

            Dim dt As New DataTable
            Dim objStkCategoryPPT As New NonStockIPRPPT
            Dim objStkCategoryBOL As New NonStockIPRBOL

            objStkCategoryPPT.STCategory = cmbServicetype.Text.Trim
            dt = objStkCategoryBOL.GetNonStockCategory(objStkCategoryPPT, "YES")

            If dt.Rows.Count > 0 Then

                strStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()
                strISRStockCategoryIDForStock = strStockCategoryID
                NonStockIPRFrm.lStockCategoryID = strStockCategoryID
            Else

                lblStockCode.Enabled = False
                txtStockcode.Enabled = False
                btnstockcodelookup.Enabled = False
                DisplayInfoMessage("msg32")
            End If
        Else
            IPRPPT.strGlobalCategoryID = String.Empty
            txtStockcode.Text = String.Empty
            lblStockcodedesc.Text = String.Empty
            strStockID = String.Empty
            lblStockCode.Enabled = False
            txtStockcode.Enabled = False
            btnstockcodelookup.Enabled = False
            lblServiceDetails.Enabled = True
            txtServiceDetails.Enabled = True
            psISRStockID = String.Empty
            'End If
        End If

        StrFrmName = String.Empty


    End Sub


    'Private Sub InternalServiceRequisitionFrm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave

    '    MenuChange()

    'End Sub


    'Private Sub InternalServiceRequisitionFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    '    MenuChange()

    'End Sub

    'Private Sub MenuChange()

    '    If (mdiparent.strMenuID = "M3" And dgvISRDetails.RowCount > 0) Then

    '        If MsgBox(rm.GetString("msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

    '            GridISRViewBind()
    '            If chkviewISRDate.Checked = True Then
    '                chkviewISRDate.Checked = False
    '            End If
    '            If txtviewISRNo.Text <> String.Empty Then
    '                txtviewISRNo.Text = String.Empty
    '            End If
    '            mdiparent.strIsMenuChange = "OK"
    '        Else

    '            tcISRView.SelectedTab = tbpgISR
    '            mdiparent.strIsMenuChange = "Cancel"
    '            'Exit Sub 
    '        End If
    '    Else
    '        GridISRViewBind()
    '    End If


    'End Sub

    Private Sub InternalServiceRequisitionFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (mdiparent.strMenuID = "M3" And dgvISRDetails.RowCount > 0 And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M3"
                'mdiparent.lblMenuName.Text = "ISR"
            End If

        End If

    End Sub


End Class
