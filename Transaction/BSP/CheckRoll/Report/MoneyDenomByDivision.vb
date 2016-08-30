Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports BSP.CheckRoll.Report.Domain


Public Class MoneyDenomByDivision

    Private Sub SalaryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
        LoadMandorBesar()
    End Sub

    Private Sub LoadMandorBesar()
        Dim dtEmployee As New DataTable

        dtEmployee = SalaryEmployee_DAL.GetMandorBesar()
        Me.cboMandorBesar.DataSource = dtEmployee
        Me.cboMandorBesar.ValueMember = "EmpID"
        Me.cboMandorBesar.DisplayMember = "EmpName"
        dtEmployee = Nothing

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click

        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        report.tmpMandorBesarID = Me.cboMandorBesar.SelectedValue
        Dim ReportName As String

        ReportName = "MoneyDenomByDivision"
        report._Source = ReportName

        report.ShowDialog()

        Cursor = Cursors.Default

    End Sub





End Class