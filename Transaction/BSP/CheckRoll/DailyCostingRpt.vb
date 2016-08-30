Public Class DailyCostingRpt

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

            If rdKHT.Checked = True Then
                DailyCostingReportView.Tag = "KHT"
            Else
                DailyCostingReportView.Tag = "KHL"
            End If

            DailyCostingReportView.Show()
        End If
    End Sub

    Private Sub DailyCostingRpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtStartDate.MaxDate = Date.Today
        dtEndDate.MaxDate = Date.Today
        dtStartDate.Enabled = True
        dtEndDate.Enabled = True

    End Sub
End Class