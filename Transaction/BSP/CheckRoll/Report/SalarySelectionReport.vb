'/*********************
'
' By Dadang Adi Hendradi
' Created : Kamis, 15 Oct 2009, 15:19
'
'/*********
Imports Common_PPT
Imports Common_DAL

Public Class SalarySelectionReport

    Private reportName As String = "CheckrollSalaryReport.rpt"
    'Private reportName As String = "DailyAttendanceViewReport.rpt"
    Private EmpCategory As String = "KHT"
    Private SelectFormula As String = String.Empty

    Private Sub ShowReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'reportPath = Application.StartupPath & "\Checkroll\Report\CheckrollSalaryReport.rpt"
        'reportPath = "CheckrollSalaryReport.rpt"

    End Sub

    Private Sub FillcboCategory()
        'Dim adapter As New Common_DAL.SQLHelp
        'Dim DT As DataTable

        'DT = adapter.ExecQuery()
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkProcessingDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProcessingDate.CheckedChanged
        dtpProcessingDate.Enabled = chkProcessingDate.Checked
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim report As New ViewReport()

        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Fill select category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        ViewReport._Source = reportName

        EmpCategory = CboCategory.SelectedItem.ToString()

        Dim SalaryProcDate As Date = dtpProcessingDate.Value

        If EmpCategory <> "ALL CATEGORY" Then

            SelectFormula = _
                "{CREmployee.Category} = '" + EmpCategory + "'"

            If chkProcessingDate.Checked Then
                SelectFormula = SelectFormula + " AND " + _
                    "{Salary.SalaryProcDate} = '" + _
                    SalaryProcDate.Year.ToString() + "-" + _
                    SalaryProcDate.Month.ToString() + "-" + _
                    SalaryProcDate.Day.ToString() + "'"

            End If

            ViewReport._Formula = SelectFormula

        End If

        'ViewReport._Source = reportName

        Cursor = Cursors.WaitCursor
        ViewReport.Show()
        Cursor = Cursors.Default
    End Sub
End Class