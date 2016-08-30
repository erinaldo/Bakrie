Imports Common_PPT
Imports Common_BOL
Imports Store_PPT
Imports Store_BOL

Imports System.Data.SqlClient
Public Class IssueBatchFrm
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Private Sub IssueBatchFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
        Datebind()
        dgIssueBatchDetailsBind()
        dgIssueBatchDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Private Sub dgIssueBatchDetailsBind()
        Dim objStorePPT As New IssueBatchPPT()
        dgIssueBatchDetails.AutoGenerateColumns = False
        dgIssueBatchDetails.DataSource = IssueBatchBOL.LoaddgIssueBatch(objStorePPT)
    End Sub
    Private Sub Datebind()
        Dim dt As Date = dtpDate.Value.ToString()
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim objStorePPT As New IssueBatchPPT()
        objStorePPT.BatchDate = Format(Me.dtpDate.Value, "MM/dd/yyyy")

        If btnSave.Text = "Add" Then

            If txtSIVNO.Text.Trim() <> "" Then
                objStorePPT.SIVNo = txtSIVNO.Text.Trim()
                If objStorePPT.SIVNo.Length > 50 Then
                    MessageBox.Show("SIV No length Should not Exceed 50 Characters")
                    txtSIVNO.Focus()
                    Exit Sub
                End If
                If txtSIVNO.Enabled = True Then

                    Dim ds As New DataSet
                    ds = IssueBatchBOL.IssueBatchSIVNOIsExist(objStorePPT)
                    If ds.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("Record already exists")
                        txtSIVNO.Focus()
                        Exit Sub
                    End If
                End If
            Else
                MessageBox.Show("The SIV NO. should not be Empty..")
                txtSIVNO.Focus()
                Exit Sub
            End If

            If txtTotal.Text <> "" Then
                If txtTotal.Text.Length > 18 Then
                    MessageBox.Show("The Total Value Should not Exceed 18 digits")
                    txtTotal.Focus()
                    Exit Sub
                Else
                    objStorePPT.BatchValue = CDbl(txtTotal.Text)
                End If


            Else
                MessageBox.Show("The Total Value should not be Empty..")
                txtTotal.Focus()
                Exit Sub
            End If

            Dim lngResult As Double = IssueBatchBOL.saveIssueBatch(objStorePPT)
            MessageBox.Show("Data successfully saved")
            'dtpDate.Value = Date.Today
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
            Datebind()
            txtSIVNO.Text = ""
            txtTotal.Text = ""

        ElseIf btnSave.Text = "Update" Then
            If txtTotal.Text <> "" Then
                If txtTotal.Text.Length > 18 Then
                    MessageBox.Show("The Total Value Should not Exceed 18 digits")
                    txtTotal.Focus()
                    Exit Sub
                Else
                    objStorePPT.BatchValue = CDbl(txtTotal.Text)
                End If
            Else
                MessageBox.Show("The Total Value should not be Empty..")
                txtTotal.Focus()
                Exit Sub
            End If
            objStorePPT.BatchDate = Format(Me.dtpDate.Value, "MM/dd/yyyy")
            objStorePPT.BatchValue = txtTotal.Text
            objStorePPT.SIVNo = txtSIVNO.Text
            objStorePPT.STIssueBatchID = dgIssueBatchDetails.CurrentRow.Cells("dgclBatchID").Value.ToString()
            Dim lngResult As Double = IssueBatchBOL.UpdateIssueBatch(objStorePPT)
            MessageBox.Show("Data successfully updated")
            Datebind()
            txtSIVNO.Text = ""
            txtTotal.Text = ""
            btnSave.Text = "Add"
        End If
        dgIssueBatchDetailsBind()
    End Sub
    Private Sub dgIssueBatchDetails_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgIssueBatchDetails.CellClick
        Dim dt As Date
        dt = dgIssueBatchDetails.CurrentRow.Cells("dgclDate").Value.ToString()
        dtpDate.Value = dt
        txtSIVNO.Text = dgIssueBatchDetails.CurrentRow.Cells("dgclSIVNO").Value.ToString()
        Dim lngTotalVal As Double

        lngTotalVal = dgIssueBatchDetails.CurrentRow.Cells("dgclTotal").Value
        txtTotal.Text = lngTotalVal.ToString()
        Dim strBatchID As String = dgIssueBatchDetails.CurrentRow.Cells("dgclBatchID").Value
        Dim objIssueBatchPPT As New IssueBatchPPT()
        objIssueBatchPPT.STIssueBatchID = strBatchID
        btnSave.Text = "Update"
    End Sub
    Private Sub btnSave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.TextChanged
        If btnSave.Text = "Add" Then
            txtSIVNO.Enabled = True

        ElseIf btnSave.Text = "Update" Then
            txtSIVNO.Enabled = False
        End If
    End Sub
    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
        'dtpDate.Value = Date.Today
        'dtpDate.Value = Date.Today()
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.CustomFormat = "dd/MM/yyyy"
        txtSIVNO.Text = ""
        txtTotal.Text = ""
        btnSave.Text = "Add"
        'StoreIssueVoucherBOL.ClearGridView(dgIssueBatchDetails)
        
    End Sub

    'Private Sub ClearGridView(ByVal grdname As DataGridView)
    '    If grdname.Rows.Count <> 0 Then

    '        Dim objDataGridViewRow As New DataGridViewRow
    '        For Each objDataGridViewRow In grdname.Rows

    '            grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
    '        Next
    '        grdname.Rows.RemoveAt(0)
    '    End If
    'End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub txtTotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        '' ''Dim allowedChars As String = "0123456789$,"

        '' ''If allowedChars.IndexOf(e.KeyChar) = -1 Then
        '' ''    MessageBox.Show("Invalid Numeric Data Entered,Please Enter numeric only")
        '' ''    e.Handled = True
        '' ''End If
        'if the decimal digits reaches more than 2 digits then stop entering
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

    Private Sub txtTotal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotal.KeyDown
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
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(IssueBatchFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDate.Text = rm.GetString("lblDate.Text")
            lblSIVNO.Text = rm.GetString("lblSIVNO.Text")
            lblTotal.Text = rm.GetString("lblTotal.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnResetIB.Text = rm.GetString("btnResetIB.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            dgIssueBatchDetails.Columns("dgclDate").HeaderText = rm.GetString("dgIssueBatchDetails.Columns(dgclDate).HeaderText")
            dgIssueBatchDetails.Columns("dgclSIVNo").HeaderText = rm.GetString("dgIssueBatchDetails.Columns(dgclSIVNo).HeaderText")
            dgIssueBatchDetails.Columns("dgclTotal").HeaderText = rm.GetString("dgIssueBatchDetails.Columns(dgclTotal).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class