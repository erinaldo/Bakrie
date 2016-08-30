Public Class DailyCostingRptByYop

    Public Shared startDate As Date
    Public Shared EndDate As Date

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If dtStartDate.Value > dtEndDate.Value Then
            MsgBox("Start date cannot be greater than End date")
            dtStartDate.Focus()
            Exit Sub
        Else
            startDate = dtStartDate.Value
            EndDate = dtEndDate.Value


            DailyCostingReportView.Tag = "YOP"
            DailyCostingReportView.Yop = cboYop.Text
            DailyCostingReportView.FieldNo = Me.txtblock.Text
            DailyCostingReportView.Show()
        End If
    End Sub

    Private Sub DailyCostingRpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtStartDate.MaxDate = Date.Today
        dtEndDate.MaxDate = Date.Today
        dtStartDate.Enabled = True
        dtEndDate.Enabled = True
        Dim i As Integer
        Me.cboYop.Items.Clear()
        i = Year(Today()) - 25
        While i < Year(Today())
            Me.cboYop.Items.Add(i)
            i = i + 1
        End While
    End Sub

    Private Sub btnblocklookup_Click(sender As System.Object, e As System.EventArgs) Handles btnblocklookup.Click
        Dim SubBlockLookup_Form As SubBlockLookups
        Dim retValue As Windows.Forms.DialogResult
        SubBlockLookup_Form = New SubBlockLookups("")

        retValue = SubBlockLookup_Form.ShowDialog()

        If retValue = Windows.Forms.DialogResult.OK Then
            txtblock.Text = SubBlockLookup_Form.SubBlockName
            cboYop.Text = SubBlockLookup_Form.YOP
        End If
    End Sub
End Class