Imports Accounts_BOL
Imports Accounts_PPT
Imports System.Data.SqlClient
Imports System.Text

Public Class AccountBatch
    Dim strAccountBatchID, strActiveMonthYearID As String
    Dim strLedgerSetUpID As String
    'Dim strAccountBatchForDelete As String
    Dim objCheckDuplicateRecord As Object = 0

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")
    Private Sub gbLedgerBatch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ''Dim dt As DataTable

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

            objAccountBatch.LedgerNo = txtLedgerType.Text
            objCheckDuplicateRecord = Accounts_BOL.AccountBatchBOL.ChechDuplicateLedgerTypeExists(objAccountBatch)

            If (objCheckDuplicateRecord = 0) Then
                MessageBox.Show("Ledger Number Already Exists For this Month ! Please choose different Ledger Number")
                Exit Sub
            End If
            objAccountBatch.LedgerSetUpId = strLedgerSetUpID
            objAccountBatch.LedgerType = txtLedgerType.Text.Trim()
            objAccountBatch.LedgerNo = txtLedgerNumber.Text.Trim()
            objAccountBatch.LedgerDescription = txtDescription.Text.Replace("'", "").Trim()
            objAccountBatch.AccBatchTotal = txtBatchTotal.Text
            ' ''dt = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
            ' ''strAccountBatchID = 


            ' ''objAccountBatch.AccBatchID = strAccountBatchID

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
        txtDescription.Text = ""
        txtLedgerType.Text = ""
        txtBatchTotal.Text = ""
        txtLedgerNumber.Text = ""
        chkRecurringJournals.Checked = False
        btnSave.Text = "Save"
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

    Private Sub chkRecurringJournals_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecurringJournals.Click

    End Sub

    Private Sub panAddLedgerBatch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim objAccountBatch As New AccountBatchPPT
        dgBatchDetails.AutoGenerateColumns = False
        dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
    End Sub

    ' ''Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' ''    txtLedgerType.Focus()
    ' ''End Sub


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

        strAccountBatchID = dgBatchDetails.SelectedRows.Item(0).Cells("AccBatchID").Value.ToString()
        objAccountBatch.AccBatchID = strAccountBatchID
        If (strAccountBatchID = String.Empty) Then
            MessageBox.Show("No Rows to delete")
            Exit Sub
        End If

        If (MessageBox.Show("You are about to delete the selected record. Are you sure? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            'If (Accounts_BOL.AccountBatchBOL.DeleteAccountBatch(objAccountBatch) = 0) Then
            '    MessageBox.Show("Message Deleted Successfully")
            'End If
        End If
        dgBatchDetails.AutoGenerateColumns = False
        dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)




    End Sub




    Private Sub txtBatchTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub txtBatchTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'if the decimal digits reaches more than 2 digits then stop entering
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

        Dim objAccountBatch As New AccountBatchPPT
        GridAccBatchViewBind()
        tcAccountBatchView.SelectedTab = tbAccountBatchView


        dgBatchDetails.DataSource = Accounts_BOL.AccountBatchBOL.BindDataGridView(objAccountBatch).Tables(0)
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

        ''If (dt.Rows.Count <> 0) Then
        ''    LedgerNo = dt.Rows(0).Item("LedgerNo")
        ''    LedgerType = dt.Rows(0).Item("LedgerType")
        ''    ''LedgerSetupID = dt.Rows(0).Item("LedgerSetUpID")
        ''    ''AccBatchID = dt.Rows(0).Item("AccBatchID")
        ''End If

        dgBatchDetails.DataSource = dt
        dgBatchDetails.AutoGenerateColumns = False


    End Sub


    Private Sub tcAccountBatchView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcAccountBatchView.Click
        txtviewLedgerNo.Text = String.Empty
        txtviewLedgerType.Text = String.Empty
        GridAccBatchViewBind()
    End Sub

    Private Sub AccountBatch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
End Class