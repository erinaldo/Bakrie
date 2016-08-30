Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports BSP.CheckRoll.Report.Domain

Public Class THREmployeeReport

    Private Sub THREmployeeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartDate.Value = GlobalPPT.FiscalYearFromDate
        EndDate.Value = GlobalPPT.FiscalYearToDate
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click

        Dim totalPendapatan As Integer = 0
        Dim totalPotongan As Integer = 0
        Dim gajiBersih As Integer = 0
        Dim pembulatan As Integer = 0
        Dim gajiDiBayar As Integer = 0
        Dim listSalary As New List(Of SalaryEmployee_PPT)
        Dim dtEmployee As New DataTable

        dtEmployee = SalaryEmployee_DAL.GetTHREmployee(StartDate.Value, EndDate.Value)
        For Each employee As DataRow In dtEmployee.Rows

            Dim gajiPokok As New SalaryEmployee_PPT
            With gajiPokok

                .ID = employee("EmpCode")
                .Nama = employee("EmpName")
                If Not IsDBNull(employee("OEEmpLocation")) Then
                    .Dept = employee("OEEmpLocation")
                End If
                .JenisKaryawan = employee("Category")
                .DedSPSI = 0
                .DedSPSB = 0
                .BerasNatura = employee("BerasNatura")
                .DagingNatura = employee("DagingNatura")
                .TotalPendapatan = employee("Bruto")
                If Not IsDBNull(employee("BankId")) Then .BankId = employee("BankID") Else .BankId = ""

            End With
            listSalary.Add(gajiPokok)

        Next

        Dim crReport As New CRTHRSlip

        crReport.SetDataSource(listSalary)
        Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
        txtMonthYear = CType(crReport.ReportDefinition.ReportObjects.Item("text57"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtMonthYear.Text = "SLIP THR PERIODE " & MonthName(Month(StartDate.Value), True) & " " & Year(StartDate.Value)

        Dim report As New ViewReport
        report.CRV.ReportSource = crReport
        report.CRV.RefreshReport()
        report.ShowDialog()
    End Sub


    Private Sub cmdPrintReport_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintReport.Click

        Dim totalPendapatan As Integer = 0
        Dim totalPotongan As Integer = 0
        Dim gajiBersih As Integer = 0
        Dim pembulatan As Integer = 0
        Dim gajiDiBayar As Integer = 0
        Dim listSalary As New List(Of SalaryEmployee_PPT)
        Dim dtEmployee As New DataTable

        dtEmployee = SalaryEmployee_DAL.GetTHREmployee(StartDate.Value, EndDate.Value)
        For Each employee As DataRow In dtEmployee.Rows

            Dim gajiPokok As New SalaryEmployee_PPT
            With gajiPokok

                .ID = employee("EmpCode")
                .Nama = employee("EmpName")
                If Not IsDBNull(employee("OEEmpLocation")) Then
                    .Dept = employee("OEEmpLocation")
                End If
                .JenisKaryawan = employee("Category")
                .DedSPSI = 0
                .DedSPSB = 0
                .BerasNatura = employee("BerasNatura")
                .DagingNatura = employee("DagingNatura")
                .TotalPendapatan = employee("Bruto")
                If Not IsDBNull(employee("BankId")) Then .BankId = employee("BankID") Else .BankId = ""

            End With
            listSalary.Add(gajiPokok)

        Next

        Dim crReport As New CRTHRSlip

        crReport.SetDataSource(listSalary)
        Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
        txtMonthYear = CType(crReport.ReportDefinition.ReportObjects.Item("text57"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtMonthYear.Text = "SLIP THR PERIODE " & MonthName(Month(StartDate.Value), True) & " " & Year(StartDate.Value)

        Dim myExport As New ExportReportToText
        myExport.TryTextFilePrinting(crReport, Nothing, Nothing)
    End Sub
End Class