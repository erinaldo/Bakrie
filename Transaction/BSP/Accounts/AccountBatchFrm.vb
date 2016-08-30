Imports Accounts_BOL
Imports Accounts_PPT
Imports Common_BOL
Imports Common_PPT
Imports BSP.MDIParent
Imports System.Data.SqlClient
Imports System.Text

Public Class AccountBatchFrm
    Dim strAccountBatchID, strActiveMonthYearID As String
    Dim strLedgerSetUpID As String
    'Dim strAccountBatchForDelete As String
    Dim objCheckDuplicateRecord As Object = 0
    Dim isDecimal, isModifierKey As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ''Dim dt As DataTable
        Dim intReturnNo As Integer
        ''Dim ds As DataSet
        Dim dt As DataTable
        Dim objAccountBatch As New AccountBatchPPT
        If (txtLedgerType.Text = "") Then
            MessageBox.Show("Ledger Type Required", "Ledger Type")
            txtLedgerType.Focus()
            Exit Sub
        ElseIf (txtLedgerNumber.Text = "") Then
            MessageBox.Show("Ledger Number Required", "Ledger Number")
            txtLedgerNumber.Focus()
            Exit Sub
        ElseIf (txtDescription.Text = "") Then
            MessageBox.Show("Description Required", "Description")
            txtDescription.Focus()
            Exit Sub
        ElseIf (txtBatchTotal.Text = "") Then
            MessageBox.Show("Account Batch Total Required", "Batch Total")
            txtBatchTotal.Focus()
            Exit Sub
        End If
        If (btnSave.Text = "Update") Then
            objAccountBatch.LedgerType = txtLedgerType.Text.Trim()
            objAccountBatch.LedgerNo = txtLedgerNumber.Text.Trim()
            objAccountBatch.LedgerDescription = txtDescription.Text.Replace("'", "").Trim()
            objAccountBatch.AccBatchTotal = txtBatchTotal.Text
            If (chkRecurringJournals.Checked) Then
                objAccountBatch.RecurringJournal = "Y"
            Else
                objAccountBatch.RecurringJournal = "N"
            End If
            objAccountBatch.AccBatchID = strAccountBatchID.Trim
            objAccountBatch.ActiveMonthYearID = strActiveMonthYearID
            objAccountBatch.LedgerSetUpId = strLedgerSetUpID

            If (Accounts_BOL.AccountBatchBOL.UpdateAccountBatch(objAccountBatch) = 0) Then
                MessageBox.Show("Data Updated Successfully")
                btnLookUp.Enabled = True
                txtLedgerNumber.Enabled = True
                btnSave.Text = "Save"
                dgBatchDetails.AutoGenerateColumns = False
                GridAccBatchViewBind()
                '  dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
                Clear()
            Else
                MessageBox.Show("Some Problem in updating")
            End If
        Else
            objAccountBatch.LedgerNo = txtLedgerNumber.Text
            objAccountBatch.AccBatchID = String.Empty
            dt = Accounts_BOL.AccountBatchBOL.ChechDuplicateLedgerTypeExists(objAccountBatch)

            If dt.Rows.Count <> 0 Then
                intReturnNo = dt.Rows(0).Item("RefCount").ToString
            End If

            If intReturnNo = 1 Then
                MessageBox.Show("Ledger Number Already Exists For this Month ! Please choose different Ledger Number")
                txtLedgerNumber.Text = String.Empty
                txtLedgerNumber.Focus()
                Exit Sub
            ElseIf intReturnNo = 0 Then
                objAccountBatch.LedgerSetUpId = strLedgerSetUpID
                objAccountBatch.LedgerType = txtLedgerType.Text.Trim()
                objAccountBatch.LedgerNo = txtLedgerNumber.Text.Trim()
                objAccountBatch.LedgerDescription = txtDescription.Text.Replace("'", "").Trim()
                objAccountBatch.AccBatchTotal = txtBatchTotal.Text
                If (chkRecurringJournals.Checked) Then
                    objAccountBatch.RecurringJournal = "Y"
                Else
                    objAccountBatch.RecurringJournal = "N"
                End If
                If (Accounts_BOL.AccountBatchBOL.SaveAccountBatch(objAccountBatch) = 0) Then
                    dgBatchDetails.AutoGenerateColumns = False
                    ' dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables("Accounts.AccountBatch")
                    MessageBox.Show("Data Saved Successfully")
                    GridAccBatchViewBind()
                    ' dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
                    Clear()
                Else
                    MessageBox.Show("Some Problem in saving Data")
                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Clear()
    End Sub

    Private Sub Clear()
        SetUICulture(GlobalPPT.strLang)
        txtDescription.Text = ""
        txtLedgerType.Text = ""
        txtBatchTotal.Text = ""
        txtLedgerNumber.Text = ""
        chkRecurringJournals.Checked = False
        btnLookUp.Enabled = True
        txtLedgerNumber.Enabled = True
    End Sub

    Private Sub btnLookUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUp.Click
        Dim objAccountBatchTypeLookUp As New AccouontBatchLookup
        objAccountBatchTypeLookUp.ShowDialog()
        If objAccountBatchTypeLookUp.strLedgerType <> String.Empty Then
            txtLedgerType.Text = objAccountBatchTypeLookUp.strLedgerType
            strLedgerSetUpID = objAccountBatchTypeLookUp.strLedgerSetUpId
        End If
    End Sub

    Private Sub panAddLedgerBatch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim objAccountBatch As New AccountBatchPPT
        dgBatchDetails.AutoGenerateColumns = False
        dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
    End Sub

    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        updateAccountBatch()
        tcAccountBatchView.SelectedTab = tbAccountBatch
    End Sub

    Private Sub updateAccountBatch()
        strAccountBatchID = dgBatchDetails.SelectedRows.Item(0).Cells("AccBatchID").Value.ToString()
        If (strAccountBatchID = Nothing) Then
            MessageBox.Show("No record selected for Update")
            Exit Sub
        End If
        strLedgerSetUpID = dgBatchDetails.SelectedRows.Item(0).Cells("LedgerSetUpId").Value
        strActiveMonthYearID = dgBatchDetails.SelectedRows.Item(0).Cells("ActiveMonthYearId").Value
        strAccountBatchID = dgBatchDetails.SelectedRows.Item(0).Cells("AccBatchID").Value
        txtLedgerType.Text = dgBatchDetails.SelectedRows.Item(0).Cells("LedgerType").Value.ToString()
        txtLedgerNumber.Text = dgBatchDetails.SelectedRows.Item(0).Cells("LedgerNo").Value.ToString()
        txtDescription.Text = dgBatchDetails.SelectedRows.Item(0).Cells("Description").Value.ToString()
        txtBatchTotal.Text = dgBatchDetails.SelectedRows.Item(0).Cells("BatchTotal").Value.ToString()
        If (dgBatchDetails.SelectedRows.Item(0).Cells("RecuringJournal").Value.ToString() = "Y") Then
            chkRecurringJournals.Checked = True
        End If
        btnSave.Text = "Update"
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim objAccountBatch As New AccountBatchPPT
        Dim dt As DataTable
        Dim intReturnNo As Integer
        strAccountBatchID = dgBatchDetails.SelectedRows.Item(0).Cells("AccBatchID").Value.ToString()
        strLedgerSetUpID = dgBatchDetails.SelectedRows.Item(0).Cells("LedgerSetupID").Value.ToString
        objAccountBatch.AccBatchID = strAccountBatchID
        objAccountBatch.LedgerSetUpId = strLedgerSetUpID
        If (strAccountBatchID = String.Empty) Then
            MessageBox.Show("No Rows to delete")
            Exit Sub
        End If
        dt = Accounts_BOL.AccountBatchBOL.DeleteAccountBatch(objAccountBatch)
        If dt.Rows.Count <> 0 Then
            intReturnNo = dt.Rows(0).Item("RefCount").ToString
        End If
        If intReturnNo > 0 Then
            MessageBox.Show("You can't delete this record because this record already in use")
            Exit Sub
        ElseIf intReturnNo = 0 Then
            MessageBox.Show("Data Deleted Successfully")
        End If
        dgBatchDetails.AutoGenerateColumns = False
        dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
    End Sub
    Private Sub txtBatchTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBatchTotal.KeyDown
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

    Private Sub txtBatchTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBatchTotal.KeyPress
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

    Private Sub dgBatchDetails_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgBatchDetails.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgBatchDetails.ClearSelection()
                    dgBatchDetails.Rows(hti.RowIndex).Selected = True
                    If (dgBatchDetails.SelectedRows.Item(0).Cells("AccBatchID").Value.ToString() <> Nothing) Then
                        strAccountBatchID = dgBatchDetails.SelectedRows.Item(0).Cells("AccBatchID").Value.ToString()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub AccountBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        Dim objAccountBatch As New AccountBatchPPT
        GridAccBatchViewBind()
        tcAccountBatchView.SelectedTab = tbAccountBatchView
        dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountBatchFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tcAccountBatchView.TabPages("tbAccountBatch").Text = rm.GetString("tcISRView.TabPages(tbAccountBatch).Text")
            tcAccountBatchView.TabPages("tbAccountBatchView").Text = rm.GetString("tcISRView.TabPages(tbAccountBatchView).Text")
            'Add Tab Controls
            lblLedgerType.Text = rm.GetString("lblLedgerType.Text")
            lblLedgerNo.Text = rm.GetString("lblLedgerNo.Text")
            lblDescription.Text = rm.GetString("lblDescription.Text")
            lblBatchTotal.Text = rm.GetString("lblBatchTotal.Text")
            chkRecurringJournals.Text = rm.GetString("chkRecurringJournals.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            pnlSearch.CaptionText = rm.GetString("pnlSearch.CaptionText")
            lblviewAccBatchSearchBy.Text = rm.GetString("lblviewAccBatchSearchBy.Text")
            lblviewLedgerType.Text = rm.GetString("lblviewLedgerType.Text")
            lblviewLedgerno.Text = rm.GetString("lblviewLedgerNo.Text")
            btnviewAccountBatchSearch.Text = rm.GetString("btnviewAccountBatchSearch.Text")
            btnviewAccountBatchReport.Text = rm.GetString("btnviewAccountBatchReport.Text")

            
            dgBatchDetails.Columns("LedgerType").HeaderText = rm.GetString("dgBatchDetails.Columns(LedgerType).HeaderText")
            dgBatchDetails.Columns("LedgerNo").HeaderText = rm.GetString("dgBatchDetails.Columns(LedgerNo).HeaderText")
            dgBatchDetails.Columns("Description").HeaderText = rm.GetString("dgBatchDetails.Columns(Description).HeaderText")
            dgBatchDetails.Columns("BatchTotal").HeaderText = rm.GetString("dgBatchDetails.Columns(BatchTotal).HeaderText")
        Catch
            ''display a message if the culture is not supported
            ''try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Clear()
        tcAccountBatchView.SelectedTab = tbAccountBatch
    End Sub

    Private Sub dgBatchDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatchDetails.CellDoubleClick
        strLedgerSetUpID = dgBatchDetails.CurrentRow.Cells("LedgerSetUpID").Value
        strActiveMonthYearID = dgBatchDetails.CurrentRow.Cells("ActiveMonthYearId").Value
        strAccountBatchID = dgBatchDetails.CurrentRow.Cells("AccBatchID").Value
        txtLedgerType.Text = dgBatchDetails.CurrentRow.Cells("LedgerType").Value.ToString()
        txtLedgerNumber.Text = dgBatchDetails.CurrentRow.Cells("LedgerNo").Value.ToString()
        txtDescription.Text = dgBatchDetails.CurrentRow.Cells("Description").Value.ToString()
        txtBatchTotal.Text = dgBatchDetails.CurrentRow.Cells("BatchTotal").Value.ToString()
        If (dgBatchDetails.CurrentRow.Cells("RecuringJournal").Value.ToString() = "Y") Then
            chkRecurringJournals.Checked = True
        Else
            chkRecurringJournals.Checked = False
        End If
        btnLookUp.Enabled = False
        txtLedgerNumber.Enabled = False
        tcAccountBatchView.SelectedTab = tbAccountBatch
        btnSave.Text = "Update"
    End Sub

    Private Sub btnviewAccountBatchSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewAccountBatchSearch.Click
        If txtviewLedgerNo.Text.Trim = String.Empty Then
            txtviewLedgerNo.Text = String.Empty
        End If
        If txtviewLedgerType.Text.Trim = String.Empty Then
            txtviewLedgerType.Text = String.Empty
        End If
        GridAccBatchViewBind()
    End Sub

    Private Sub GridAccBatchViewBind()
        Dim objABatchppt As New AccountBatchPPT
        Dim dt As New DataTable
        With objABatchppt
            .LedgerNo = txtviewLedgerNo.Text.Trim()
            .LedgerType = txtviewLedgerType.Text
        End With
        dt = AccountBatchBOL.BindDataGridView(objABatchppt).Tables(0)
        If dt.Rows.Count = 0 Then
            txtviewLedgerNo.Text = String.Empty
            txtviewLedgerType.Text = String.Empty
            lblNoRecordFound.Visible = True
        Else
            lblNoRecordFound.Visible = False
        End If
        dgBatchDetails.DataSource = dt
        dgBatchDetails.AutoGenerateColumns = False
    End Sub

    Private Sub tcAccountBatchView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcAccountBatchView.Click

        txtviewLedgerNo.Text = String.Empty
        txtviewLedgerType.Text = String.Empty
        GridAccBatchViewBind()
        Clear()
    End Sub
End Class