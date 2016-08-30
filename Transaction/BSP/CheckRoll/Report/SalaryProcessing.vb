Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports Common_DAL
Imports CheckRoll_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Public Class SalaryProcessing
    Private Sub SalaryProcessing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvEmployee.DataSource = CheckRoll_BOL.SalaryBOL.SalaryNikSelect("M1", "Active")
        Dim dt As DataTable
        dt = Salary_DAL.CRSalaryFiscalYearSelect(GlobalPPT.strLoginMonth.ToString)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class