Imports Accounts_PPT
Imports Accounts_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class PettyCashReceiptFrm
    Public lACCReceiptID As String = String.Empty
    Public isDecimal As Boolean
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Public lReceiptSave As String
    '' Approval 

    Public psLedgerID As String = String.Empty
    Public Shared StrFrmName As String = String.Empty

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim isModifierKey As Boolean
    Shadows mdiparent As New MDIParent

    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashReceiptFrm))


    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashReceiptFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
        pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

        tbPCR.TabPages("tbAdd").Text = rm.GetString("tbPCR.TabPages(tbAdd).Text")
        tbPCR.TabPages("tbView").Text = rm.GetString("tbPCR.TabPages(tbView).Text")
        lblReceiptDt.Text = rm.GetString("lblReceiptDt.Text")
        lblReceiptNumber.Text = rm.GetString("lblReceiptNumber.Text")
        lblReceiptDesc.Text = rm.GetString("lblReceiptDesc.Text")
        lblReconcilationDt.Text = rm.GetString("lblReconcilationDt.Text")
        lblAmount.Text = rm.GetString("lblAmount.Text")
        lblStatus.Text = rm.GetString("lblStatus.Text")
        lblSearchStatus.Text = rm.GetString("lblSearchStatus.Text")
        lblReceivedFrom.Text = rm.GetString("lblReceivedFrom.Text")

        btnReceiptSave.Text = rm.GetString("btnReceiptSave.Text")
        btnReceiptReset.Text = rm.GetString("btnReceiptReset.Text")
        btnReceiptClose.Text = rm.GetString("btnReceiptClose.Text")

        ''''''''''''''''Petty Cash View '''''''''''''''''''''''
        pnlCategorySearch.Text = rm.GetString("pnlCategorySearch.Text")
        'Search By
        lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
        lblviewReceiptNo.Text = rm.GetString("lblviewReceiptNo.Text")
        lblviewReceiptDate.Text = rm.GetString("lblviewReceiptDate.Text")
        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
        btnConform.Text = rm.GetString("btnConform.Text")

        cmsPCR.Items.Item(0).Text = rm.GetString("cmsPCR.Items.Item(0).Text")
        cmsPCR.Items.Item(1).Text = rm.GetString("cmsPCR.Items.Item(1).Text")
        cmsPCR.Items.Item(2).Text = rm.GetString("cmsPCR.Items.Item(2).Text")


        dgvReceiptView.Columns("dgclReceiptDate").HeaderText = rm.GetString("dgvReceiptView.Columns(dgclReceiptDate).HeaderText")
        dgvReceiptView.Columns("dgclReceiptNo").HeaderText = rm.GetString("dgvReceiptView.Columns(dgclReceiptNo).HeaderText")
        dgvReceiptView.Columns("dgclReceiptDesc").HeaderText = rm.GetString("dgvReceiptView.Columns(dgclReceiptDesc).HeaderText")
        dgvReceiptView.Columns("dgclReconcilationDate").HeaderText = rm.GetString("dgvReceiptView.Columns(dgclReconcilationDate).HeaderText")
        dgvReceiptView.Columns("dgclAmount").HeaderText = rm.GetString("dgvReceiptView.Columns(dgclAmount).HeaderText")
        dgvReceiptView.Columns("dgPRStatus").HeaderText = rm.GetString("dgvReceiptView.Columns(dgPRStatus).HeaderText")
        dgvReceiptView.Columns("dgclReceivedFrom").HeaderText = rm.GetString("dgvReceiptView.Columns(dgclReceivedFrom).HeaderText")

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashReceiptFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub GridPettyCashReceiptView()
        'ClearGridView(dgAdjustment)
        Dim mdiparent As New MDIParent
        Dim objPettyCashPPT As New PettyCashReceiptPPT
        Dim objPettyCashBOL As New PettyCashReceiptBOL
        Dim dt As New DataTable
        With objPettyCashPPT
            If mdiparent.strMenuID = "M110" Then
                .ReceiptDate = Nothing
                .ReceiptNo = AccountApprovalFrm.ApprovalReceiptNo
                .Approved = "N"
            Else
                If chkReceiptdate.Checked = True Then
                    .ReceiptDate = dtpviewReceiptDate.Value
                Else
                    dtpviewReceiptDate.Enabled = False
                    .ReceiptDate = Nothing
                End If
                If cmbSearchStatus.Text = "Select All" Then
                    .Approved = "S"
                ElseIf cmbSearchStatus.Text = "OPEN" Then
                    .Approved = "N"
                Else
                    .Approved = "Y"
                End If
                .ReceiptNo = txtReceiptViewNo.Text.Trim

            End If

        End With

        dt = objPettyCashBOL.GetPettyCashDetails(objPettyCashPPT)
        If dt.Rows.Count <> 0 Then

            If MdiParent.strMenuID = "M110" Then

                lACCReceiptID = dt.Rows(0).Item("ReceiptID")
                ' dtpReceiptDate.Text = dt.Rows(0).Item("ReceiptDate")
                Me.txtReceiptNo.Text = dt.Rows(0).Item("ReceiptNo")
                Me.txtDesc.Text = dt.Rows(0).Item("ReceiptDescp")
                Dim strReconDate As String = dt.Rows(0).Item("CashReconcilationDate")
                Me.dtpReconDate.Text = New Date(strReconDate.Substring(6, 4), strReconDate.Substring(3, 2), strReconDate.Substring(0, 2))
                ' dtpReconDate.Value = dt.Rows(0).Item("CashReconcilationDate")
                Me.txtReceivedFrom.Text = dt.Rows(0).Item("ReceivedFrom")
                txtAmount.Text = dt.Rows(0).Item("Amount")
                Dim strReceiptDate As String = dt.Rows(0).Item("ReceiptDate")
                Me.dtpReceiptDate.Text = New Date(strReceiptDate.Substring(6, 4), strReceiptDate.Substring(3, 2), strReceiptDate.Substring(0, 2))

            Else

                Me.dgvReceiptView.DataSource = dt
                dgvReceiptView.AutoGenerateColumns = False
                lblView.Visible = False
            End If

        Else
            ClearGridView(dgvReceiptView) '''''clear the records from grid view
            ' lblView.Visible = True
            Exit Sub
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
    Private Sub clear()
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpReceiptDate)
        FormatDateTimePicker(dtpReceiptDate)
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpReconDate)
        FormatDateTimePicker(dtpReconDate)
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpviewReceiptDate)
        FormatDateTimePicker(dtpviewReceiptDate)

        If GlobalPPT.strLang = "en" Then
            btnReceiptSave.Text = "Save"
        Else
            btnReceiptSave.Text = "Simpan"
        End If
        lReceiptSave = "Save"
        txtReceiptNo.Text = ""
        txtAmount.Text = ""
        txtDesc.Text = ""
        txtReceivedFrom.Text = ""
        txtReceiptNo.Enabled = True
        dtpReceiptDate.Enabled = True
        chkReceiptdate.Checked = False
        btnReceiptSave.Enabled = True
        cmbSearchStatus.Text = "open"
        lblStatusValue.Text = "OPEN"
        btnReceiptSave.Visible = True
        lblRecjectedReason.Visible = False
        lblColon.Visible = False
        lblRejectedReasonValue.Visible = False
        If Not objUserLoginBOl.Privilege(btnReceiptSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Private Sub btnReceiptSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptSave.Click
        Dim objPettyCashPPT As New PettyCashReceiptPPT
        Dim objPettyCashBOL As New PettyCashReceiptBOL
        Dim objCheckReceiptNo As Object = 0

        Dim dt As New DataTable
        Dim ObjPCR As New AccountsApprovalPPT
        Dim ObjPCRBOLApp As New AccountsApprovalBOL
        dt = ObjPCRBOLApp.GetPettyCashReceiptCOAID(ObjPCR)

        If dt.Rows.Count = 0 Then
            MsgBox("There is no COA code for Petty Cash or Due to HO, please include the records in General Distribution Setup screen with description Petty Cash and Due to HO  ")
            Exit Sub
        End If

        If Me.txtReceiptNo.Text.Trim = "" Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("This Field is Required", "Receipt Number")
            txtReceiptNo.Focus()
            Exit Sub
        End If
        If Me.txtReceivedFrom.Text.Trim = "" Then
            DisplayInfoMessage("Msg19")
            ''MessageBox.Show("This Field is Required", "Receipt Number")
            txtReceivedFrom.Focus()
            Exit Sub
        End If
        If Me.txtDesc.Text.Trim = "" Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("This Field is Required", "Description")
            txtDesc.Focus()
            Exit Sub
        End If
        If Val(txtAmount.Text.Trim) = 0 Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This Field is Required", "Amount")
            txtAmount.Focus()
            Exit Sub
        End If

        'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If

        If lReceiptSave = "Save" Then

            Dim objCheckDuplicateRecord As Object = 0

            objPettyCashPPT.ReceiptNo = Me.txtReceiptNo.Text

            objCheckDuplicateRecord = objPettyCashBOL.DuplicatePettycashReceiptCheck(objPettyCashPPT)
            If (objCheckDuplicateRecord = 0) Then
                DisplayInfoMessage("Msg4")
                ''MessageBox.Show("Receipt No Already Exists ! Please enter different receipt no")
                txtReceiptNo.Focus()
                Exit Sub
            End If


            With objPettyCashPPT
                .ReceiptDate = dtpReceiptDate.Value
                .ReceiptNo = Me.txtReceiptNo.Text.Trim
                .ReconcilationDate = dtpReconDate.Value
                .ReceiptDesc = Me.txtDesc.Text.Trim
                .Amount = txtAmount.Text
                .ModifiedOn = Date.Today
                .Approved = "N"
                .RejectedReason = ""
                .ReceivedFrom = txtReceivedFrom.Text.Trim
            End With

            Dim ds As New DataSet
            ds = PettyCashReceiptBOL.savePettyCashReceipt(objPettyCashPPT)
            DisplayInfoMessage("Msg5")
            '' MsgBox("Data Successfully Saved")
            clear()


        Else

            With objPettyCashPPT

                .AccReceiptID = Me.lACCReceiptID
                .ReceiptDate = dtpReceiptDate.Value
                .ReceiptNo = Me.txtReceiptNo.Text.Trim
                .ReconcilationDate = dtpReconDate.Value
                .ReceiptDesc = Me.txtDesc.Text.Trim
                .Amount = txtAmount.Text
                .ModifiedOn = Date.Today
                .Approved = "N"
                .RejectedReason = ""
                .ReceivedFrom = txtReceivedFrom.Text.Trim
            End With

            objPettyCashBOL.UpdateReceipt(objPettyCashPPT, "NO")
            DisplayInfoMessage("Msg6")
            ''MsgBox("Data Successfully Updated")
            clear()

        End If
        GlobalPPT.IsRetainFocus = False
    End Sub
    Private Sub UpdatePettyCashView()

        Dim objPettyCashPPT As New PettyCashReceiptPPT
        Dim objPettyCashBOL As New PettyCashReceiptBOL
        Dim dt As New DataTable
        If dgvReceiptView.Rows.Count > 0 Then
            If objUserLoginBOl.Privilege(btnReceiptSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnReceiptSave.Enabled = True
                End If
            End If


            Me.lACCReceiptID = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceiptID").Value
            Me.txtReceiptNo.Text = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceiptNo").Value
            Me.txtReceiptNo.Enabled = False
            Dim strReceiptDate As String = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceiptDate").Value.ToString()
            Me.dtpReceiptDate.Text = New Date(strReceiptDate.Substring(6, 4), strReceiptDate.Substring(3, 2), strReceiptDate.Substring(0, 2))
            Me.txtDesc.Text = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceiptDesc").Value.ToString()
            Me.txtAmount.Text = dgvReceiptView.SelectedRows(0).Cells("dgclAmount").Value.ToString()
            Dim strReconDate As String = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReconcilationDate").Value.ToString()
            Me.dtpReconDate.Text = New Date(strReconDate.Substring(6, 4), strReconDate.Substring(3, 2), strReconDate.Substring(0, 2))
            Me.txtReceivedFrom.Text = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceivedFrom").Value

            If GlobalPPT.strLang = "en" Then
                btnReceiptSave.Text = "Update"
            Else
                btnReceiptSave.Text = "Memperbarui"
            End If



            lReceiptSave = "Update"
            Me.lACCReceiptID = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceiptID").Value.ToString()
            dtpReceiptDate.Enabled = False
            Me.tbPCR.SelectedTab = tbAdd

            lblStatusValue.Text = Me.dgvReceiptView.SelectedRows(0).Cells("dgPRStatus").Value.ToString()
            If Me.dgvReceiptView.SelectedRows(0).Cells("dgPRStatus").Value.ToString() = "APPROVED" Then
                btnReceiptSave.Visible = False
            Else
                btnReceiptSave.Visible = True
            End If
            lblRejectedReasonValue.Text = Me.dgvReceiptView.SelectedRows(0).Cells("dgclRejectedReason").Value.ToString
            If lblRejectedReasonValue.Text <> String.Empty Then
                lblRecjectedReason.Visible = True
                lblColon.Visible = True
                lblRejectedReasonValue.Visible = True
            End If

        Else
            DisplayInfoMessage("Msg7")
            '' MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'If Not objUserLoginBOl.Privilege(btnReceiptSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptClose.Click
        If btnReceiptSave.Enabled = False Then
            Me.Close()
        Else
            If txtReceiptNo.Text.Trim <> "" And txtReceivedFrom.Text.Trim <> "" And txtDesc.Text.Trim <> "" And btnReceiptSave.Enabled = True And btnReceiptSave.Visible = True Then
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
           

        End If

    End Sub
    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub PettyCashReceiptFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (txtReceiptNo.Text.Trim <> "" And txtReceivedFrom.Text.Trim <> "" And txtDesc.Text.Trim <> "" And btnReceiptSave.Enabled = True And btnReceiptSave.Visible = True And GlobalPPT.IsButtonClose = False) Then
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

    Private Sub PettyCashReceiptFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PettyCashReceiptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        SetUICulture(GlobalPPT.strLang)
        Dim mdiparent As New MDIParent

        If mdiparent.strMenuID = "M110" Then
            tbPCR.TabPages.Remove(tbView)
            clear()
            btnReceiptSave.Enabled = False
            btnReceiptReset.Enabled = False
            GridPettyCashReceiptView()
            grpApproval.Visible = True
            cmbStatus.SelectedIndex = 0

        Else
            clear()
            Dim dt As New DataTable
            Dim ObjPCR As New AccountsApprovalPPT
            Dim ObjPCRBOLApp As New AccountsApprovalBOL
            dt = ObjPCRBOLApp.GetPettyCashReceiptCOAID(ObjPCR)

            If dt.Rows.Count = 0 Then
                MsgBox("There is no COA code for Petty Cash or Due to HO, please include the records in General Distribution Setup screen with description Petty Cash and Due to HO  ")
            End If


            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpReceiptDate)
            FormatDateTimePicker(dtpReceiptDate)
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpReconDate)
            FormatDateTimePicker(dtpReconDate)
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpviewReceiptDate)
            FormatDateTimePicker(dtpviewReceiptDate)
            Me.tbPCR.SelectedTab = tbView
            Me.dtpReceiptDate.Format = DateTimePickerFormat.Custom
            Me.dtpReceiptDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpReconDate.Format = DateTimePickerFormat.Custom
            Me.dtpReconDate.CustomFormat = "dd/MM/yyyy"
            lReceiptSave = "Save"
            GridPettyCashReceiptView()
            grpApproval.Visible = False
        End If



    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click


        If txtReceiptViewNo.Text.Trim = String.Empty And chkReceiptdate.Checked = False And cmbSearchStatus.Text = "OPEN" Then
            DisplayInfoMessage("Msg8")
            ''MsgBox("Please Enter Criteria to Search!")
            GridPettyCashReceiptView()
            Exit Sub
        Else
            GridPettyCashReceiptView()
            If dgvReceiptView.RowCount = 0 Then
                DisplayInfoMessage("Msg9")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub
    Private Sub chkReceiptdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReceiptdate.CheckedChanged
        If chkReceiptdate.Checked = True Then
            dtpviewReceiptDate.Enabled = True
        Else
            dtpviewReceiptDate.Enabled = False
        End If
    End Sub
    Private Sub dgvReceiptView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceiptView.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                 UpdatePettyCashView()
            End If
        End If



        If GlobalPPT.strLang = "en" Then
            btnReceiptSave.Text = "Update"
        Else
            btnReceiptSave.Text = "Memperbarui"
        End If
    End Sub
    Private Sub dgvReceiptView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvReceiptView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdatePettyCashView()
            e.Handled = True
        End If
    End Sub
    Private Sub dgvReceiptView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvReceiptView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvReceiptView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvReceiptView.ClearSelection()
                    Me.dgvReceiptView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub
  
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        UpdatePettyCashView()
        If GlobalPPT.strLang = "en" Then
            btnReceiptSave.Text = "Update"
        Else
            btnReceiptSave.Text = "Memperbarui"
        End If
    End Sub
    Private Sub DeletePettyCashVIew()
        Me.cmsPCR.Visible = False

        Dim objPettyCashPPT As New PettyCashReceiptPPT
        Dim objPettyCashBOL As New PettyCashReceiptBOL
        Dim dt As New DataTable
        If dgvReceiptView.Rows.Count > 0 Then
            If Me.dgvReceiptView.SelectedRows(0).Cells("dgPRStatus").Value.ToString() = "APPROVED" Then
                DisplayInfoMessage("Msg10")
                ''MessageBox.Show("User cannot Delete Approved Record", "BSP")
                Exit Sub
            End If

            '   Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PettyCashReceiptFrm))
            If MsgBox(rm.GetString("Msg11"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Me.lACCReceiptID = Me.dgvReceiptView.SelectedRows(0).Cells("dgclReceiptID").Value.ToString()
                With objPettyCashPPT
                    .AccReceiptID = Me.lACCReceiptID
                End With
                objPettyCashBOL.DeletePettyCashDetail(objPettyCashPPT)
                GridPettyCashReceiptView()
            End If
        Else
            DisplayInfoMessage("Msg12")
            '' MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub AddAdjustment()
        'If Not objUserLoginBOl.Privilege(btnReceiptSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        clear()
        Me.tbPCR.SelectedTab = tbAdd

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeletePettyCashVIew()
    End Sub
    Private Sub tbPCR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAdd.Click, tbPCR.Click
        If txtReceiptNo.Text.Trim <> "" And txtReceivedFrom.Text.Trim <> "" And txtDesc.Text.Trim <> "" And btnReceiptSave.Enabled = True And btnReceiptSave.Visible = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tbPCR.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                GridPettyCashReceiptView()
                chkReceiptdate.Focus()
                clear()
            End If
        Else
            chkReceiptdate.Focus()
            GridPettyCashReceiptView()
            clear()
        End If

      

    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        AddAdjustment()
    End Sub
    Private Sub tbPCR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPCR.SelectedIndexChanged
        'If tbPCR.SelectedIndex = 1 Then
        '    GridPettyCashReceiptView()
        'End If
        'clear()
        'cmbSearchStatus.SelectedIndex = 0
    End Sub
    Private Sub tbPCR_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPCR.TabIndexChanged
        'If tbPCR.TabIndex = 1 Then
        '    GridPettyCashReceiptView()
        'End If
        'clear()
        ''cmbSearchStatus.SelectedIndex = 0
    End Sub
    Private Sub btnReceiptReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptReset.Click
        clear()
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
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

  
    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
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

   
    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click


        If MsgBox(rm.GetString("Msg13"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

            ''If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            If cmbStatus.Text = "APPROVED" Then
                ApprovalDetails()

            ElseIf cmbStatus.Text = "REJECTED" Then
                If txtRejectedReason.Text.Trim = String.Empty Then
                    DisplayInfoMessage("Msg14")
                    ''MsgBox("Please keen the Rejected Reason!")
                    txtRejectedReason.Focus()
                    Exit Sub
                End If

                Dim objPettyCashPPT As New PettyCashReceiptPPT
                Dim objpettyCashBOL As New PettyCashReceiptBOL

                With objPettyCashPPT
                    .AccReceiptID = Me.lACCReceiptID
                    .Approved = "N"
                    .RejectedReason = txtRejectedReason.Text.Trim
                    .ReceiptDate = dtpReceiptDate.Value
                    .ReconcilationDate = dtpReconDate.Value
                End With
                objpettyCashBOL.UpdateReceipt(objPettyCashPPT, "YES")
                DisplayInfoMessage("Msg15")
                ''MsgBox("Record Rejected Successfully")
                Close()
                Exit Sub
            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub ApprovalDetails()
        Try

       
            'Update PCR Table Status

            Dim ObjPettyCashReceiptPPT As New PettyCashReceiptPPT
            Dim ObjPettyCashReceiptBOL As New PettyCashReceiptBOL
            Dim ds As New Integer
            With ObjPettyCashReceiptPPT
                .AccReceiptID = lACCReceiptID
                .Approved = "Y"
            End With
            ds = ObjPettyCashReceiptBOL.UpdateReceipt(ObjPettyCashReceiptPPT, "YES")
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("Approved Successfully", "BSP")
            Close()
        Catch ex As Exception
            DisplayInfoMessage("Msg17")
            ''MsgBox("Transaction  Failed")
            Exit Sub
        End Try


        Try

            ''Step 2 Accounts.Ledgerallmodule insert 
            Dim ObjPCRPPT As New AccountsApprovalPPT
            Dim ObjPCRBOL As New AccountsApprovalBOL


            ObjPCRPPT.AYear = GlobalPPT.intActiveYear
            ObjPCRPPT.Amonth = GlobalPPT.IntActiveMonth
            ObjPCRPPT.LedgerDate = dtpReceiptDate.Value
            ObjPCRPPT.LedgerType = "PCR"
            ObjPCRPPT.JournalDescp = txtDesc.Text.Trim
            ObjPCRPPT.BatchTotal = txtAmount.Text
            ObjPCRPPT.LedgerNo = txtReceiptNo.Text

            Dim dsRowsAffectedLedgerAllModule As New DataSet
            dsRowsAffectedLedgerAllModule = ObjPCRBOL.JournalLedgerAllModuleInsert(ObjPCRPPT)
            psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
            ObjPCRPPT.LedgerID = psLedgerID
            ' MessageBox.Show("Approved Successfully")
        Catch ex As Exception
            DisplayInfoMessage("Msg17")
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

            If dt.Rows.Count <> 0 And dt IsNot Nothing And dt.Rows(0).Item("PettyCashCOAID").ToString <> String.Empty Then
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
                        .Value = txtAmount.Text
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

            If dt.Rows.Count <> 0 And dt IsNot Nothing And dt.Rows(0).Item("SamarindaCOAID").ToString <> String.Empty Then
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
                        .Value = txtAmount.Text
                        .Flag = "PCR Price"
                        .COADescp = txtDesc.Text.Trim
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
            DisplayInfoMessage("Msg18")
            ''MsgBox("Transaction Completed Successfully")

        Catch ex As Exception
            DisplayInfoMessage("Msg17")
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

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        StrFrmName = "PCR"
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        If Val(txtAmount.Text) > 0 Then
            txtAmount.Text = Format(Val(txtAmount.Text), "0")
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click

    End Sub
End Class