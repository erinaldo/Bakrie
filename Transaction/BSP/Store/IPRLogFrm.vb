Imports Store_BOL
Imports Common_BOL '09-11-2012
Imports Common_PPT
Imports Store_PPT
Public Class IPRLogFrm
    Private Sub IPRLogFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, chkIPRdate.Enter
        SetUICulture(GlobalPPT.strLang)


        'add by suraya 09112012
        dtpIPRDate.Format = DateTimePickerFormat.Custom 'edit
        dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpIPRDate)

      

        'Me.dtpIPRDate.Format = DateTimePickerFormat.Custom
        'Me.dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        'Me.dtpIPRDate.Format = DateTimePickerFormat.Custom
        'Me.dtpIPRDate.CustomFormat = "dd/MM/yyyy"
        'toGetIPRNo()

        Me.cmbStatus.Text = Me.cmbStatus.Items(5)
        GridIPRViewBind()
        chkIPRdate.Focus()


    End Sub
    Private Sub GridIPRViewBind()
        ClearGridView(dgvIRPView)

        Dim objIPRPPT As New IPRLogPPT
        Dim objIPRBOL As New IPRLogBOL
        Dim dt As New DataTable
        With objIPRPPT
            Dim str As String = cmbStatus.SelectedItem.ToString()

            If cmbStatus.SelectedItem.ToString() = "SELECT ALL" Then
                If chkIPRdate.Checked = True Then
                    dtpIPRDate.Enabled = True
                    ''.IPRdate = Format(Me.dtpIPRDate.Value, "MM/dd/yyyy")
                    .IPRdate = dtpIPRDate.Value
                Else
                    dtpIPRDate.Enabled = False
                    .IPRdate = Nothing
                End If
                .IPRNo = String.Empty
            Else

                If chkIPRdate.Checked = True Then
                    ''.IPRdate = Format(Me.dtpIPRDate.Value, "MM/dd/yyyy")
                    .IPRdate = dtpIPRDate.Value

                Else
                    .IPRdate = Nothing
                End If
                '.IPRNo = Me.txtviewIPRNo.Text
                '.Status = cmbStatus.SelectedItem.ToString()
            End If
            .IPRNo = Trim(Me.txtviewIPRNo.Text)
            .Status = cmbStatus.SelectedItem.ToString()
            If .Status = "SELECT ALL" Then
                .Status = ""
            Else
                .Status = cmbStatus.SelectedItem.ToString()
            End If

        End With

        dt = objIPRBOL.GetIPRDetails(objIPRPPT)
        If dt.Rows.Count <> 0 Then

            Me.dgvIRPView.DataSource = dt
            dgvIRPView.AutoGenerateColumns = False
            lblView.Visible = False
        Else
            ClearGridView(dgvIRPView) '''''clear the records from grid view
            lblView.Visible = True
            Exit Sub
        End If
    End Sub
    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then

            Dim objDataGridViewRow As New DataGridViewRow

            For iCount As Integer = 1 To grdname.Rows.Count
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            If grdname.Rows.Count = 1 Then
                grdname.Rows.RemoveAt(0)
            End If
        End If
       
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblView.Visible = False
        GridIPRViewBind()
    End Sub
    Private Sub chkIPRdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIPRdate.CheckedChanged
        If chkIPRdate.Checked = True Then
            dtpIPRDate.Enabled = True
        Else
            dtpIPRDate.Enabled = False
        End If
    End Sub
    Private Sub txtviewIPRNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtviewIPRNo.KeyDown
        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


   


    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(IPRLogFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblviewIPRno.Text = rm.GetString("lblviewIPRno.Text")
            lblviewIPRDate.Text = rm.GetString("lblviewIPRDate.Text")
            lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
            lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")

            '''''''''''''GRID CAPTIONS'''''''''''''''''''''''''''''
            dgvIRPView.Columns("IPRDate").HeaderText = rm.GetString("dgvIRPView.Columns(IPRDate).HeaderText")
            dgvIRPView.Columns("IPRNo").HeaderText = rm.GetString("dgvAdjustDetails.Columns(IPRNo).HeaderText")
            dgvIRPView.Columns("Estate").HeaderText = rm.GetString("dgvAdjustDetails.Columns(Estate).HeaderText")
            dgvIRPView.Columns("Status").HeaderText = rm.GetString("dgvAdjustDetails.Columns(Status).HeaderText")
            dgvIRPView.Columns("Person").HeaderText = rm.GetString("dgvAdjustDetails.Columns(Person).HeaderText")
            dgvIRPView.Columns("StatusDate").HeaderText = rm.GetString("dgvAdjustDetails.Columns(StatusDate).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub chkIPRdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkIPRdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub dtpIPRDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpIPRDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IPRLogFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtpIPRDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpIPRDate.ValueChanged

    End Sub
End Class