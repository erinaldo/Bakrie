Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class ConsignmentReceivedFrm

    Dim CRMasterID As String
    Dim CRID As String


    Dim btnAdd As Boolean = True
    Dim isDecimal, isModifierKey As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")   ''Declaration for to allow double only
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsignmentReceivedFrm))
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsignmentReceivedFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim mdiparent As New MDIParent

        If ((txtReferenceNo.Text.Trim <> String.Empty Or txtConsignmentStockCode.Text.Trim <> String.Empty) And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED")) And mdiparent.strMenuID = "M18" And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

        If Validation() = False Then
            Exit Sub
        End If
        If btnAdd = True Then
            ConsignmentReceivedSave()
        ElseIf btnAdd = False Then
            ConsignmentReceivedUpdate()
            btnAdd = True
        End If
        GridISRViewBind()

        GlobalPPT.IsRetainFocus = False

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        SaveAll()
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub ConsignmentReceivedSave()
        Dim ConsignmentReceivedBOL As New ConsignmentReceivedBOL
        Dim objsave As New ConsignmentReceivedPPT
        objsave.ReceivedDate = dtpReceivedDate.Value
        objsave.ReferenceNo = txtReferenceNo.Text.Trim
        objsave.ReceivedQty = Convert.ToDouble(txtReceivedQty.Text.Trim)
        objsave.Remarks = txtRemarks.Text.Trim
        objsave.STCode = txtConsignmentStockCode.Text.Trim
        objsave.StConsignmentID = String.Empty
        objsave.STConsignmentMasterID = CRMasterID
        objsave.Status = lblStatus.Text.Trim
        objsave.RejectedReason = String.Empty 'lblCRRejectedReasonValue .Text.Trim
        Dim dtRefNo As New DataTable
        Dim intReturnNo As Integer
        dtRefNo = ConsignmentReceivedBOL.ReferenceNoIsExist(objsave)
        If dtRefNo.Rows.Count <> 0 Then
            intReturnNo = dtRefNo.Rows(0).Item("RefCount").ToString()
        End If
        If intReturnNo = 1 Then
            DisplayInfoMessage("msg01")
            'MsgBox("Reference No already exist")
            txtReferenceNo.Text = ""
            txtReferenceNo.Focus()
            Exit Sub
        ElseIf intReturnNo = 0 Then
            Dim dtHeaderInsert As New DataSet
            dtHeaderInsert = ConsignmentReceivedBOL.ConsignmentSave(objsave)
            DisplayInfoMessage("msg02")
            'MessageBox.Show("Data added sucessfully")
            Clear()
        End If
    End Sub

    Private Function Validation() As Boolean
        If txtReferenceNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg03")
            'MessageBox.Show("ReferenceNo. field is mandatory")
            txtReferenceNo.Focus()
            Return False
        End If
        If txtConsignmentStockCode.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg04")
            'MessageBox.Show("Consignment StockCode Field is mandatory")
            txtConsignmentStockCode.Focus()
            Return False
        End If
        If txtReceivedQty.Text.Trim = String.Empty Then
            DisplayInfoMessage("msg05")
            'MessageBox.Show("Received Qty field is mandatory")
            txtReceivedQty.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub txtReferenceNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReferenceNo.Leave
        If txtReferenceNo.Text.Trim = String.Empty Then
            txtReferenceNo.Text = String.Empty
        Else
            txtReferenceNo.Text = txtReferenceNo.Text.Trim
        End If
    End Sub

    Private Sub txtReceivedQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtReceivedQty.Text.Trim = String.Empty Then
            txtReceivedQty.Text = String.Empty
        End If
    End Sub

    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click

        Dim frmStockcodeLookup As New ConsignmentStockLookUp
        frmStockcodeLookup.ShowDialog()
        If frmStockcodeLookup.strSTConsignmentMasterID <> String.Empty Then
            txtConsignmentStockCode.Text = frmStockcodeLookup.strStockCode.Trim
            lblConsignmentStockcodeDesc.Text = frmStockcodeLookup.strStockDescp.Trim
            lblUOMValue.Text = frmStockcodeLookup.strUOM.Trim
            lblPartNoValue.Text = frmStockcodeLookup.strPartNo.Trim
            lblStockBalanceValue.Text = frmStockcodeLookup.strQty
            CRMasterID = frmStockcodeLookup.strSTConsignmentMasterID
        End If

    End Sub

    Private Sub DisableCRFromApprovalMode()

        dtpReceivedDate.Enabled = False
        txtReferenceNo.Enabled = False
        txtConsignmentStockCode.Enabled = False
        txtReceivedQty.Enabled = False
        txtRemarks.Enabled = False
        btnSearchStockCode.Enabled = False
        btnSave.Visible = False
        btnSave.Enabled = False
        btnClose.Enabled = True
        btnReset.Visible = False

    End Sub


    Private Sub EnableCRFromApprovalMode()

        dtpReceivedDate.Enabled = True
        txtReferenceNo.Enabled = True
        txtConsignmentStockCode.Enabled = True
        txtReceivedQty.Enabled = True
        txtRemarks.Enabled = True
        btnSearchStockCode.Enabled = True
        btnSave.Visible = True
        btnClose.Enabled = True
        btnReset.Visible = True

    End Sub

    Private Sub ConsignmentReceivedFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        GlobalBOL.SetDateTimePicker(dtpReceivedDate)
        GlobalBOL.SetDateTimePicker(dtpviewCRDate)
        FormatDatePicker(dtpReceivedDate)
        FormatDatePicker(dtpviewCRDate)
        btnSave.Enabled = True
        If mdiparent.strMenuID = "M18" Then 'Load if Consignment Received Form

            GridISRViewBind()
            tcConsiognmentReceived.SelectedTab = tbpgView

        Else
            Dim frmCRApproval As New ConsignmentReceivedApprovalFrm
            tcConsiognmentReceived.SelectedTab = tbpgConsignmentReceived
            tcConsiognmentReceived.TabPages.Remove(tbpgView)
            DisableCRFromApprovalMode()
            grpApproval.Visible = True
            cmbStatus.Focus()
        End If



    End Sub

    Private Sub GridISRViewBind()

        Dim objCRPPT As New ConsignmentReceivedPPT
        Dim objCRBOL As New ConsignmentReceivedBOL
        Dim dt As New DataTable
        lblNoRecordFound.Visible = False
        With objCRPPT
            If chkviewCRDate.Checked = True Then
                .blReceivedDate = True
            Else
                .blReceivedDate = False
            End If
            .ReceivedDate = dtpviewCRDate.Value         'Format(Me.dtpviewISRDate.Value, "yyyy/MM/dd") 
            .STCode = txtviewStockCode.Text.Trim()
            .ReferenceNo = txtviewCRNo.Text

            If cmbStatusSearch.Text = "SELECT ALL" Then
                .Status = String.Empty
            Else
                .Status = cmbStatusSearch.Text
            End If


        End With
        dt = objCRBOL.GetConsignmentReceivedDetails(objCRPPT)
        If (dt.Rows.Count <> 0) Then
            CRMasterID = dt.Rows(0).Item("STConsignmentMasterID")
            CRID = dt.Rows(0).Item("StConsignmentID")
        Else
            lblNoRecordFound.Visible = True
            txtviewCRNo.Text = String.Empty
            txtviewStockCode.Text = String.Empty
        End If
        dgvviewCReceived.AutoGenerateColumns = False
        Me.dgvviewCReceived.DataSource = dt

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Public Sub GridISRViewBindApprovalMode(ByVal ReceivedDate, ByVal lsSTCode, ByVal lsRefNo, ByVal lsUOM, ByVal liStockBalance, ByVal lsPartNo, ByVal liReceivedQty, ByVal lsRemarks, ByVal lsSTDesc, ByVal lsStConsignmentID, ByVal lsSTConsignmentMasterID, ByVal lsUOMID)

        dtpReceivedDate.Value = ReceivedDate
        txtReferenceNo.Text = lsRefNo.trim
        txtConsignmentStockCode.Text = lsSTCode
        lblUOMValue.Text = lsUOM
        lblStockBalanceValue.Text = liStockBalance
        lblPartNoValue.Text = lsPartNo
        txtReceivedQty.Text = liReceivedQty
        txtRemarks.Text = lsRemarks
        lblConsignmentStockcodeDesc.Text = lsSTDesc
        CRID = lsStConsignmentID
        CRMasterID = lsSTConsignmentMasterID
        'UOMID = lsUOMID


    End Sub


    Private Sub FormatDatePicker(ByVal dtpName As DateTimePicker)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsignmentReceivedFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tcConsiognmentReceived.TabPages("tbpgConsignmentReceived").Text = rm.GetString("tcConsiognmentReceived.TabPages(tbpgConsignmentReceived).Text")
            tcConsiognmentReceived.TabPages("tbpgView").Text = rm.GetString("tcConsiognmentReceived.TabPages(tbpgView).Text")
            'Add Tab Controls
            lblReceivedDate.Text = rm.GetString("lblReceivedDate.Text")
            lblReferenceNo.Text = rm.GetString("lblReferenceNo.Text")
            lblConsignmentStockCode.Text = rm.GetString("lblConsignmentStockCode.Text")
            lblUOM.Text = rm.GetString("lblUOM.Text")
            lblStockBalance.Text = rm.GetString("lblStockBalance.Text")
            lblPartNo.Text = rm.GetString("lblPartNo.Text")
            lblReceivedQty.Text = rm.GetString("lblReceivedQty")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnviewCRSearch.Text = rm.GetString("btnviewCRSearch.Text")
            btnviewCRReport.Text = rm.GetString("btnviewCRReport.Text")
            pnlConsignmentReceived.CaptionText = rm.GetString("pnlConsignmentReceived.CaptionText")
            lblviewISRSearchBy.Text = rm.GetString("lblviewISRSearchBy.Text")
            chkviewCRDate.Text = rm.GetString("chkviewCRDate.Text")
            lblviewReferenceno.Text = rm.GetString("lblviewReferenceno.Text")
            lblviewStockCode.Text = rm.GetString("lblviewStockCode.Text")
            lblCRStatus.Text = rm.GetString("lblCRStatus.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
            btnConform.Text = rm.GetString("btnConform.Text")

            dgvviewCReceived.Columns("ReceivedDate").HeaderText = rm.GetString("dgvviewCReceived.Columns(ReceivedDate).HeaderText")
            dgvviewCReceived.Columns("ReferenceNo").HeaderText = rm.GetString("dgvviewCReceived.Columns(ReferenceNo).HeaderText")
            dgvviewCReceived.Columns("STCode").HeaderText = rm.GetString("dgvviewCReceived.Columns(STCode).HeaderText")
            dgvviewCReceived.Columns("UOM").HeaderText = rm.GetString("dgvviewCReceived.Columns(UOM).HeaderText")
            dgvviewCReceived.Columns("PartNo").HeaderText = rm.GetString("dgvviewCReceived.Columns(PartNo).HeaderText")
            dgvviewCReceived.Columns("StockBalance").HeaderText = rm.GetString("dgvviewCReceived.Columns(StockBalance).HeaderText")
            dgvviewCReceived.Columns("Remarks").HeaderText = rm.GetString("dgvviewCReceived.Columns(Remarks).HeaderText")
            dgvviewCReceived.Columns("Status").HeaderText = rm.GetString("dgvviewCReceived.Columns(Status).HeaderText")

            'dgvviewCReceived.Columns("RejectedReason").HeaderText = rm.GetString("dgvviewCReceived.Columns(RejectedReason).HeaderText")

        Catch
            ''display a message if the culture is not supported
            ''try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Clear()
    End Sub

    Private Sub Clear()

        FormatDatePicker(dtpReceivedDate)
        FormatDatePicker(dtpviewCRDate)
        txtReferenceNo.Text = String.Empty
        txtConsignmentStockCode.Text = String.Empty
        txtReceivedQty.Text = String.Empty
        txtRemarks.Text = String.Empty
        lblConsignmentStockcodeDesc.Text = String.Empty
        'btnSave.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSave.Text = "Save"
        End If
        btnSave.Enabled = True
        txtReferenceNo.Focus()
        lblUOMValue.Text = String.Empty
        lblPartNoValue.Text = String.Empty
        lblStockBalanceValue.Text = String.Empty
        lblStatus.Text = "OPEN"
        txtRejectedReason.Text = String.Empty
        lblCRRejectedReason.Visible = False
        lblCRRejectedReasonColon.Visible = False
        lblCRRejectedReasonValue.Visible = False
        btnAdd = True
        ''SetUICulture(GlobalPPT.strLang)

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub ConsignmentReceivedUpdate()
        Dim objCRBOL As New ConsignmentReceivedBOL
        Dim objupdate As New ConsignmentReceivedPPT
        objupdate.ReceivedDate = dtpReceivedDate.Value
        objupdate.ReferenceNo = txtReferenceNo.Text.Trim
        objupdate.ReceivedQty = Convert.ToDouble(txtReceivedQty.Text.Trim)
        objupdate.Remarks = txtRemarks.Text.Trim
        objupdate.STCode = txtConsignmentStockCode.Text.Trim
        objupdate.Status = "OPEN" 'lblStatus.Text.Trim
        ''CRMasterID = dgvviewCReceived.SelectedRows(0).Cells("STConsignmentMasterID").Value.ToString()
        CRID = dgvviewCReceived.SelectedRows(0).Cells("STConsignmentID").Value.ToString()
        objupdate.StConsignmentID = CRID
        objupdate.STConsignmentMasterID = CRMasterID
        objupdate.RejectedReason = String.Empty 'lblCRRejectedReasonValue .Text.Trim

        Dim dtRefNo As New DataTable
        Dim intReturnNo As Integer
        dtRefNo = objCRBOL.ReferenceNoIsExist(objupdate)
        If dtRefNo.Rows.Count <> 0 Then
            intReturnNo = dtRefNo.Rows(0).Item("RefCount").ToString()
        End If
        If intReturnNo = 1 Then
            DisplayInfoMessage("msg06")
            'MsgBox("Reference No already exist")
            txtReferenceNo.Text = ""
            txtReferenceNo.Focus()
            Exit Sub
        ElseIf intReturnNo = 0 Then
            Dim dtHeaderInsert As New DataSet
            dtHeaderInsert = objCRBOL.ConsignmentUpdate(objupdate, "NO")
            txtRejectedReason.Text = String.Empty
        End If
        DisplayInfoMessage("msg07")
        'MessageBox.Show("Data was Updated Sucessfully")
        Clear()
        GridISRViewBind()

    End Sub



    Private Sub btnviewCRSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCRSearch.Click
        GridISRViewBind()
    End Sub

    Private Sub CRUpdate()
        Dim objCRPPT As New ConsignmentReceivedPPT
        Dim objCRBOL As New ConsignmentReceivedBOL
        Dim dt As New DataTable
        Dim ReceivedDate As String
        Dim strReceivedDate As Date
        If dgvviewCReceived.Rows.Count > 0 Then
            txtReferenceNo.Text = dgvviewCReceived.SelectedRows(0).Cells("ReferenceNo").Value.ToString().Trim
            txtConsignmentStockCode.Text = dgvviewCReceived.SelectedRows(0).Cells("STCode").Value.ToString()
            txtReceivedQty.Text = dgvviewCReceived.SelectedRows(0).Cells("ReceivedQty").Value.ToString()
            txtRemarks.Text = dgvviewCReceived.SelectedRows(0).Cells("Remarks").Value.ToString()
            lblUOMValue.Text = dgvviewCReceived.SelectedRows(0).Cells("UOM").Value.ToString()
            lblPartNoValue.Text = dgvviewCReceived.SelectedRows(0).Cells("PartNo").Value.ToString
            lblStockBalanceValue.Text = dgvviewCReceived.SelectedRows(0).Cells("StockBalance").Value.ToString
            lblConsignmentStockcodeDesc.Text = dgvviewCReceived.SelectedRows(0).Cells("STDesc").Value.ToString()
            ReceivedDate = dgvviewCReceived.SelectedRows(0).Cells("ReceivedDate").Value.ToString()
            strReceivedDate = New Date(ReceivedDate.Substring(6, 4), ReceivedDate.Substring(3, 2), ReceivedDate.Substring(0, 2))
            dtpReceivedDate.Value = strReceivedDate
            btnAdd = False
            'Me.btnSave.Text = "Update"

            Dim status As String = String.Empty
            status = dgvviewCReceived.SelectedRows(0).Cells("Status").Value.ToString()

            If status = "APPROVED" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If

            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Update"
            End If

            lblStatus.Text = dgvviewCReceived.SelectedRows(0).Cells("Status").Value

            If dgvviewCReceived.SelectedRows(0).Cells("Status").Value <> String.Empty Then
                If dgvviewCReceived.SelectedRows(0).Cells("Status").Value.ToString().ToUpper = "REJECTED" Then
                    lblCRRejectedReason.Visible = True
                    lblCRRejectedReasonColon.Visible = True
                    lblCRRejectedReasonValue.Visible = True
                    If Not dgvviewCReceived.SelectedRows(0).Cells("RejectedReason").Value Is DBNull.Value Then
                        lblCRRejectedReasonValue.Text = dgvviewCReceived.SelectedRows(0).Cells("RejectedReason").Value
                    End If
                    'EnableCRFromApprovalMode()
                Else
                    lblCRRejectedReason.Visible = False
                    lblCRRejectedReasonColon.Visible = False
                    lblCRRejectedReasonValue.Visible = False
                    'DisableCRFromApprovalMode()
                End If
            End If


            tcConsiognmentReceived.SelectedTab = tbpgConsignmentReceived
            FormatDatePicker(dtpReceivedDate)
            FormatDatePicker(dtpviewCRDate)

        End If

    End Sub

    Private Sub CReceivedDelete()

        Dim strCReceived As String
        Dim objCReceived As New ConsignmentReceivedPPT
        Dim ds As New DataSet

        If dgvviewCReceived.Rows.Count > 0 Then
            If dgvviewCReceived.SelectedRows(0).Cells("Status").Value.ToString() = "OPEN" Or dgvviewCReceived.SelectedRows(0).Cells("Status").Value.ToString() = "REJECTED" Then
                If MsgBox(rm.GetString("msg08"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ' If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    strCReceived = dgvviewCReceived.SelectedRows(0).Cells("StConsignmentID").Value.ToString()
                    objCReceived.StConsignmentID = strCReceived
                    ConsignmentReceivedBOL.ConsignmentDelete(objCReceived)
                Else
                    Exit Sub
                    'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                DisplayInfoMessage("msg24")
            End If
        Else
            DisplayInfoMessage("msg10")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub dgvviewCReceived_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvviewCReceived.CellDoubleClick

        EditViewGridRecord()

    End Sub
    Private Sub EditViewGridRecord()

        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                CRUpdate()
            End If
        End If

    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        Me.tcConsiognmentReceived.SelectedTab = tbpgConsignmentReceived
        Clear()

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        CReceivedDelete()
        GridISRViewBind()
    End Sub

    Private Sub txtReceivedQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceivedQty.KeyDown
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
                        If txtBox.Text.Trim.Contains("") Then
                            isDecimal = False
                            Return
                        End If
                        isDecimal = True
                        Return
                    Case Else
                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If
                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
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

    Private Sub txtReceivedQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceivedQty.KeyPress
        If isModifierKey Then
            e.Handled = True
            Return
        End If
        If isDecimal = False Then
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub txtConsignmentStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsignmentStockCode.Leave
        Dim ds As New DataSet
        Dim objConsignmentStockCode As New ConsignmentReceivedPPT
        If txtConsignmentStockCode.Text.Trim() <> String.Empty Then
            objConsignmentStockCode.STCode = txtConsignmentStockCode.Text.Trim()
            Dim ConsignmentReceivedBOL As New ConsignmentReceivedBOL
            ds = ConsignmentReceivedBOL.ConsignmentStockCodeGet(objConsignmentStockCode, "Yes")
            If (ds.Tables(0).Rows.Count <= 0) Then
                DisplayInfoMessage("msg11")
                'MessageBox.Show("There is no valid consignment stock code was selected")

                txtConsignmentStockCode.Text = String.Empty
                lblConsignmentStockcodeDesc.Text = String.Empty
                lblUOMValue.Text = String.Empty
                lblStockBalanceValue.Text = String.Empty
                lblPartNoValue.Text = String.Empty
                CRMasterID = String.Empty
            End If
            If (ds.Tables(0).Rows.Count > 0) Then
                If Not ds.Tables(0).Rows(0).Item("STCode") Is DBNull.Value Then
                    txtConsignmentStockCode.Text = ds.Tables(0).Rows(0).Item("STCode").ToString().Trim
                Else
                    txtConsignmentStockCode.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("STDesc") Is DBNull.Value Then
                    lblConsignmentStockcodeDesc.Text = ds.Tables(0).Rows(0).Item("STDesc").ToString.Trim
                Else
                    lblConsignmentStockcodeDesc.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("UOM") Is DBNull.Value Then
                    lblUOMValue.Text = ds.Tables(0).Rows(0).Item("UOM").ToString.Trim
                Else
                    lblUOMValue.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("Qty") Is DBNull.Value Then
                    lblStockBalanceValue.Text = ds.Tables(0).Rows(0).Item("Qty").ToString
                Else
                    lblStockBalanceValue.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("PartNo") Is DBNull.Value Then
                    lblPartNoValue.Text = ds.Tables(0).Rows(0).Item("PartNo").ToString.Trim
                Else
                    lblPartNoValue.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("STConsignmentMasterID") Is DBNull.Value Then
                    CRMasterID = ds.Tables(0).Rows(0).Item("STConsignmentMasterID").ToString.Trim
                Else
                    CRMasterID = String.Empty
                End If

            End If
        Else
            txtConsignmentStockCode.Text = String.Empty
            lblConsignmentStockcodeDesc.Text = String.Empty
            lblUOMValue.Text = String.Empty
            lblStockBalanceValue.Text = String.Empty
            lblPartNoValue.Text = String.Empty
            CRMasterID = String.Empty
        End If
    End Sub

    Private Sub tcConsiognmentReceived_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcConsiognmentReceived.Click

        If tcConsiognmentReceived.SelectedTab Is tbpgView = True Then

            If ((txtReferenceNo.Text.Trim <> String.Empty Or txtConsignmentStockCode.Text.Trim <> String.Empty Or txtReceivedQty.Text.Trim <> String.Empty) And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And btnSave.Enabled = True) Then

                If MsgBox(rm.GetString("msg22"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Clear()
                    GlobalPPT.IsRetainFocus = False
                    If chkviewCRDate.Checked = True Then
                        chkviewCRDate.Checked = False
                    End If
                    If txtviewCRNo.Text.Trim <> String.Empty Then
                        txtviewCRNo.Text = String.Empty
                    End If
                    If txtviewStockCode.Text.Trim <> String.Empty Then
                        txtviewStockCode.Text = String.Empty
                    End If

                    GridISRViewBind()
                Else
                    tcConsiognmentReceived.SelectedTab = tbpgConsignmentReceived
                End If

            Else
                Clear()
                If chkviewCRDate.Checked = True Then
                    chkviewCRDate.Checked = False
                End If
                If txtviewCRNo.Text.Trim <> String.Empty Then
                    txtviewCRNo.Text = String.Empty
                End If
                If txtviewStockCode.Text.Trim <> String.Empty Then
                    txtviewStockCode.Text = String.Empty
                End If
                GridISRViewBind()
            End If

        ElseIf tcConsiognmentReceived.SelectedTab Is tbpgConsignmentReceived = True Then

            If tcConsiognmentReceived.TabPages.Count = 2 Then
                If btnSave.Enabled = True Then
                    If (txtReferenceNo.Text.Trim <> String.Empty Or txtConsignmentStockCode.Text.Trim <> String.Empty Or txtReceivedQty.Text.Trim <> String.Empty) Then
                        If MsgBox(rm.GetString("msg22"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            Clear()
                        Else
                            Exit Sub
                        End If
                    Else
                        Clear()
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

            End If

        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub txtviewCRNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtviewCRNo.Leave
        If txtviewCRNo.Text.Trim = String.Empty Then
            txtviewCRNo.Text = String.Empty
        End If
    End Sub

    Private Sub txtviewStockCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtviewStockCode.Leave
        If txtviewStockCode.Text.Trim = String.Empty Then
            txtviewStockCode.Text = String.Empty
        End If
    End Sub

    Private Sub dtpReceivedDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpReceivedDate.KeyDown, txtReferenceNo.KeyDown, txtReceivedQty.KeyDown, txtRemarks.KeyDown, dtpviewCRDate.KeyDown, txtviewCRNo.KeyDown, txtviewStockCode.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dgvviewCReceived_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvviewCReceived.KeyDown
        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
        If e.KeyValue = 40 Then
            If dgvviewCReceived.SelectedRows.Count = 0 Then
                dgvviewCReceived.Rows(0).Selected = True
            Else
                If dgvviewCReceived.SelectedRows(0).Index < (dgvviewCReceived.Rows.Count - 1) Then
                    Dim intSelectedIndex As Integer = dgvviewCReceived.SelectedRows(0).Index

                    dgvviewCReceived.ClearSelection()
                    dgvviewCReceived.Rows(intSelectedIndex + 1).Selected = True
                End If
            End If
        End If



    End Sub

    Private Sub txtConsignmentStockCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsignmentStockCode.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtConsignmentStockCode.Text = String.Empty Then
                SendKeys.Send("{TAB}")
            Else
                txtReceivedQty.Focus()
            End If
        End If
    End Sub

    Private Function IsValidComboSelect() As Boolean

        If cmbStatus.SelectedIndex = -1 Then
            DisplayInfoMessage("msg12")
            ' MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        If (cmbStatus.Text = "--Select Status--") Then
            DisplayInfoMessage("msg13")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        Return True

    End Function

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click

        ConfirmApproval()

    End Sub

    Private Sub ConfirmApproval()

        If IsValidComboSelect() = False Then
            Exit Sub
        End If

        Dim objCRPPT As New ConsignmentReceivedPPT
        Dim objCRBOL As New ConsignmentReceivedBOL
        objCRPPT.ReceivedDate = dtpReceivedDate.Value
        objCRPPT.ReferenceNo = txtReferenceNo.Text.Trim
        objCRPPT.STCode = txtConsignmentStockCode.Text.Trim
        objCRPPT.StConsignmentID = CRID
        objCRPPT.STConsignmentMasterID = CRMasterID
        objCRPPT.STDesc = lblConsignmentStockcodeDesc.Text
        If txtReceivedQty.Text <> String.Empty Then
            objCRPPT.ReceivedQty = CDbl(txtReceivedQty.Text.Trim)
        Else
            objCRPPT.ReceivedQty = 0
        End If
        objCRPPT.Remarks = txtRemarks.Text.Trim

        ''''''''

        If cmbStatus.SelectedItem.ToString() = "APPROVED" Then
            txtRejectedReason.Text = String.Empty
            If MsgBox(rm.GetString("msg14"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                '1st Step-Updadte the status in Store.STReturnGoodsNote Table
                Dim dsUpdateCR As New DataSet
                objCRPPT.Status = "APPROVED"
                dsUpdateCR = objCRBOL.ConsignmentUpdate(objCRPPT, "YES")
                DisplayInfoMessage("msg15")
                'MessageBox.Show("Approved Successfully")



                'Call TaskMonitor Update after successful approval -Start

                Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                Dim dsTaskMonitorUPDATE As New DataSet
                objStoreMonthEndClosingPPT.ModID = 2
                objStoreMonthEndClosingPPT.Task = "Consignment received approval"
                objStoreMonthEndClosingPPT.Complete = "Y"
                dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)
                If dsTaskMonitorUPDATE Is Nothing Then
                    DisplayInfoMessage("msg16")
                    'MessageBox.Show("Failed to update Taskmonitor")
                    Exit Sub
                End If

                'Call TaskMonitor Update after successful approval -End


                'Update Stockdetailconsignment BalQty Start


                objCRPPT.STConsignmentMasterID = CRMasterID
                If txtReceivedQty.Text.Trim <> String.Empty Then
                    objCRPPT.ReceivedQty = txtReceivedQty.Text.Trim
                Else
                    objCRPPT.ReceivedQty = 0
                End If

                Dim intStockDetConUpdate As New Integer
                intStockDetConUpdate = objCRBOL.STConsignmentApproval(objCRPPT)
                If intStockDetConUpdate = 0 Then
                    DisplayInfoMessage("msg17")
                    'MessageBox.Show("Failed to Update IssueDetails")
                    Exit Sub
                End If

                GlobalPPT.IsButtonClose = True
                Me.Close()

            End If
        ElseIf cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            If txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("msg18")
                'MessageBox.Show("Please enter the rejected reason")
                txtRejectedReason.Focus()
                Exit Sub
            Else
                If MsgBox(rm.GetString("msg19"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Reject the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    objCRPPT.Status = "REJECTED"
                    objCRPPT.RejectedReason = txtRejectedReason.Text.Trim()
                    Dim ds As New DataSet
                    ds = objCRBOL.ConsignmentUpdate(objCRPPT, "YES")
                    DisplayInfoMessage("msg20")
                    'MessageBox.Show("Rejected Successfully")
                    txtRejectedReason.Text = String.Empty

                    GlobalPPT.IsButtonClose = True
                    Me.Close()

                End If
            End If
        End If

        ''''''''

    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged

        If cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            lblRejectedReason.Visible = True
            lblRejectedColon.Visible = True
            txtRejectedReason.Visible = True
        Else
            lblRejectedReason.Visible = False
            lblRejectedColon.Visible = False
            txtRejectedReason.Visible = False
        End If

    End Sub


    Private Sub txtReceivedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedQty.TextChanged

        If txtReceivedQty.Text < 0 Then
            txtReceivedQty.Text = 0
        End If


    End Sub

    Private Sub lblStockBalanceValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStockBalanceValue.TextChanged

        If lblStockBalanceValue.Text <> String.Empty Then
            lblStockBalanceValue.Text = Format(Val(lblStockBalanceValue.Text), "0")
        End If

    End Sub

    Private Sub cmbStatusSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbStatusSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub chkviewCRDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkviewCRDate.CheckedChanged

        If chkviewCRDate.Checked = True Then
            dtpviewCRDate.Enabled = True
        Else
            dtpviewCRDate.Enabled = False
        End If

    End Sub

    'Private Sub DisableOnApproval()

    '    txtReferenceNo.Enabled = False
    '    txtConsignmentStockCode.Enabled = False
    '    txtReceivedQty.Enabled = False
    '    txtRemarks.Enabled = False
    '    btnSave.Enabled = False

    'End Sub


    'Private Sub EnableOnApproval()

    '    txtReferenceNo.Enabled = True
    '    txtConsignmentStockCode.Enabled = True
    '    txtReceivedQty.Enabled = True
    '    txtRemarks.Enabled = True
    '    btnSave.Enabled = True

    'End Sub




    Private Sub ConsignmentReceivedFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If ((txtReferenceNo.Text.Trim <> String.Empty Or txtConsignmentStockCode.Text.Trim <> String.Empty Or txtReceivedQty.Text.Trim <> String.Empty) And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSave.Enabled = True) Then

            If MsgBox(rm.GetString("msg22"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M18"
                'mdiparent.lblMenuName.Text = "Non-IPR"
            End If
        End If

    End Sub

End Class