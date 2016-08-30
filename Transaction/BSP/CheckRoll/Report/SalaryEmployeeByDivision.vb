Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports BSP.CheckRoll.Report.Domain


Public Class SalaryEmployeeByDivision

    Private Sub SalaryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartDate.Value = GlobalPPT.FiscalYearFromDate
        EndDate.Value = GlobalPPT.FiscalYearToDate
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

        Dim totalPendapatan As Integer = 0
        Dim totalPotongan As Integer = 0
        Dim gajiBersih As Integer = 0
        Dim pembulatan As Integer = 0
        Dim gajiDiBayar As Integer = 0
        Dim listSalary As New List(Of SalaryEmployee_PPT)
        Dim dtEmployee As New DataTable

        dtEmployee = SalaryEmployee_DAL.GetSalaryEmployeeByMandorBesar(Me.cboMandorBesar.SelectedValue)
        For Each employee As DataRow In dtEmployee.Rows

            Dim dtDetail As New DataTable
            dtDetail = SalaryEmployee_DAL.GetSalaryEmployeeDetail(StartDate.Value, EndDate.Value, employee("EmpID"))

            'Inisialiasi Gaji Pokok Belum
            Dim gajiPokok As New SalaryEmployee_PPT
            With gajiPokok
                .TargetLatex = 0
                .TargetLump = 0
                .LatexPrograsive = 0
                .LumpPrograsive = 0
                .LatexBonus = 0
                .LumpBonus = 0
                .TL = 0

                .ID = employee("EmpCode")
                .Dept = Nothing
                If Not IsDBNull(employee("MStatus")) Then
                    .GTTBeras = employee("MStatus")
                    .STTPTKP = employee("MStatus")
                End If
                .Nama = employee("EmpName")
                If Not IsDBNull(employee("OEEmpLocation")) Then
                    .Dept = employee("OEEmpLocation")
                End If
                If Not IsDBNull(employee("Absent")) Then
                    .HkTdkDiByr = employee("Absent")
                End If
                If Not IsDBNull(employee("Hari")) Then
                    .JmlHariKerja = employee("Hari")
                End If
                If Not IsDBNull(employee("HariLain")) Then
                    .JmlHkTdkDibayar = employee("HariLain")
                End If
                .JenisKaryawan = employee("Category")
                If Not IsDBNull(employee("Grade")) And Not IsDBNull(employee("Level")) Then
                    If employee("Grade").ToString <> "" And employee("Level").ToString <> "" Then
                        .Golongan = employee("Grade") + employee("Level") + " / "
                    End If
                End If
                .Golongan = .Golongan + Format(employee("DailyRate"), "#,#")
                .STTJamsostek = Nothing
                If Not IsDBNull(employee("MandorBesarName")) Then .MandorBesar = employee("MandorBesarName") Else .MandorBesar = ""
                If Not IsDBNull(employee("Gangname")) Then .GangID = employee("Gangname")
                .IdPendapatan = "A01"
                .Pendapatan = "Gaji Pokok"
                .JmlPendapatan = employee("TotalBasic")
                .IdPotongan = Nothing
                .Potongan = Nothing
                .Jmlpotongan = Nothing
            End With
            listSalary.Add(gajiPokok)

            Dim cPendapatan As Integer = 0
            Dim CPotongan As Integer = 0
            Dim cCountItems As Integer = listSalary.Count
            Dim detailCount As Integer = 0
            Dim newSwitch As Boolean = False
            Dim salary As New SalaryEmployee_PPT

            For Each detail As DataRow In dtDetail.Rows
                newSwitch = False
                If detailCount = 0 Then
                    salary = New SalaryEmployee_PPT
                    newSwitch = True
                Else
                    If detail("TYPE") = "PENDAPATAN" Then
                        If cPendapatan = detailCount Then
                            salary = New SalaryEmployee_PPT
                            newSwitch = True
                        Else
                            salary = listSalary(cPendapatan + cCountItems)
                        End If
                    Else
                        If detail("TYPE") = "POTONGAN" Then
                            If CPotongan >= cPendapatan Then 'Because of the sorting, once Potongan is equivalent to pendapatan you have to add a new item to salary list
                                salary = New SalaryEmployee_PPT
                                newSwitch = True
                            Else
                                salary = listSalary(CPotongan + cCountItems)
                            End If
                        End If
                    End If

                End If

                With salary
                    .TargetLatex = 0
                    .TargetLump = 0
                    .LatexPrograsive = 0
                    .LumpPrograsive = 0
                    .LatexBonus = 0
                    .LumpBonus = 0
                    .TL = 0

                    .ID = detail("EmpCode")
                    .Dept = Nothing
                    .STTPTKP = Nothing
                    .Golongan = Nothing

                    .Nama = detail("EmpName")
                    '.LokasiClass = detail("OEEmpLocation")
                    .GTTBeras = Nothing
                    .HkTdkDiByr = Nothing
                    If Not IsDBNull(employee("Gangname")) Then .GangID = employee("Gangname")
                    .JenisKaryawan = Nothing
                    .JmlHariKerja = Nothing
                    .JmlHkTdkDibayar = Nothing
                    .STTJamsostek = Nothing
                    If Not IsDBNull(employee("MandorBesarName")) Then .MandorBesar = employee("MandorBesarName") Else .MandorBesar = ""
                    If Not IsDBNull(detail("BankId")) Then .BankId = detail("BankID") Else .BankId = ""
                    If Not IsDBNull(detail("TYPE")) Then
                        If (detail("TYPE") = "PENDAPATAN") Then
                            .IdPendapatan = detail("AllowDedCode")
                            .Pendapatan = detail("Remarks")
                            .JmlPendapatan = detail("Amount")
                            cPendapatan = cPendapatan + 1
                            'Sai Change Here
                            '   .IdPotongan = Nothing
                            ' .Potongan = Nothing
                            '.Jmlpotongan = Nothing
                        End If

                        If (detail("TYPE") = "POTONGAN") Then
                            .IdPotongan = detail("AllowDedCode")
                            .Potongan = detail("Remarks")
                            .Jmlpotongan = detail("Amount")
                            '.IdPendapatan = Nothing
                            '.Pendapatan = Nothing
                            '.JmlPendapatan = Nothing
                            CPotongan = CPotongan + 1
                        End If
                    End If
                    '  cCountItems = cCountItems + 1
                    detailCount = detailCount + 1
                    If newSwitch Then
                        listSalary.Add(salary)
                    Else
                        If detail("Type") = "POTONGAN" Then
                            listSalary(CPotongan + cCountItems - 1) = salary

                        Else
                            listSalary(cPendapatan + cCountItems - 1) = salary

                        End If
                    End If
                End With

            Next
        Next

        Dim crReport As New CRSalaryEmployeeReport

        crReport.SetDataSource(listSalary)
        Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
        txtMonthYear = CType(crReport.ReportDefinition.ReportObjects.Item("text57"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtMonthYear.Text = "SLIP GAJI PERIODE " & MonthName(Month(StartDate.Value), True) & " " & Year(StartDate.Value)

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

        dtEmployee = SalaryEmployee_DAL.GetSalaryEmployeeByMandorBesar(Me.cboMandorBesar.SelectedValue)
        For Each employee As DataRow In dtEmployee.Rows

            Dim dtDetail As New DataTable
            dtDetail = SalaryEmployee_DAL.GetSalaryEmployeeDetail(StartDate.Value, EndDate.Value, employee("EmpID"))

            'Inisialiasi Gaji Pokok Belum
            Dim gajiPokok As New SalaryEmployee_PPT
            With gajiPokok
                .TargetLatex = 0
                .TargetLump = 0
                .LatexPrograsive = 0
                .LumpPrograsive = 0
                .LatexBonus = 0
                .LumpBonus = 0
                .TL = 0

                .ID = employee("EmpCode")
                .Dept = Nothing
                If Not IsDBNull(employee("MStatus")) Then
                    .GTTBeras = employee("MStatus")
                    .STTPTKP = employee("MStatus")
                End If
                .Nama = employee("EmpName")
                If Not IsDBNull(employee("OEEmpLocation")) Then
                    .Dept = employee("OEEmpLocation")
                End If
                If Not IsDBNull(employee("Absent")) Then
                    .HkTdkDiByr = employee("Absent")
                End If
                If Not IsDBNull(employee("Hari")) Then
                    .JmlHariKerja = employee("Hari")
                End If
                If Not IsDBNull(employee("HariLain")) Then
                    .JmlHkTdkDibayar = employee("HariLain")
                End If
                .JenisKaryawan = employee("Category")
                If Not IsDBNull(employee("Grade")) And Not IsDBNull(employee("Level")) Then
                    If employee("Grade").ToString <> "" And employee("Level").ToString <> "" Then
                        .Golongan = employee("Grade") + employee("Level") + " / "
                    End If
                End If
                .Golongan = .Golongan + Format(employee("DailyRate"), "#,#")
                .STTJamsostek = Nothing
                If Not IsDBNull(employee("MandorBesarName")) Then .MandorBesar = employee("MandorBesarName") Else .MandorBesar = ""
                If Not IsDBNull(employee("Gangname")) Then .GangID = employee("Gangname")
                .IdPendapatan = Nothing
                .Pendapatan = "Gaji Pokok"
                .JmlPendapatan = employee("TotalBasic")
                .IdPotongan = Nothing
                .Potongan = Nothing
                .Jmlpotongan = Nothing
            End With
            listSalary.Add(gajiPokok)

            Dim cPendapatan As Integer = 0
            Dim CPotongan As Integer = 0
            Dim cCountItems As Integer = listSalary.Count
            Dim detailCount As Integer = 0
            Dim newSwitch As Boolean = False
            Dim salary As New SalaryEmployee_PPT

            For Each detail As DataRow In dtDetail.Rows
                newSwitch = False
                If detailCount = 0 Then
                    salary = New SalaryEmployee_PPT
                    newSwitch = True
                Else
                    If detail("TYPE") = "PENDAPATAN" Then
                        If cPendapatan = detailCount Then
                            salary = New SalaryEmployee_PPT
                            newSwitch = True
                        Else
                            salary = listSalary(cPendapatan + cCountItems)
                        End If
                    Else
                        If detail("TYPE") = "POTONGAN" Then
                            If CPotongan >= cPendapatan Then 'Because of the sorting, once Potongan is equivalent to pendapatan you have to add a new item to salary list
                                salary = New SalaryEmployee_PPT
                                newSwitch = True
                            Else
                                salary = listSalary(CPotongan + cCountItems)
                            End If
                        End If
                    End If

                End If

                With salary
                    .TargetLatex = 0
                    .TargetLump = 0
                    .LatexPrograsive = 0
                    .LumpPrograsive = 0
                    .LatexBonus = 0
                    .LumpBonus = 0
                    .TL = 0

                    .ID = detail("EmpCode")
                    .Dept = Nothing
                    .STTPTKP = Nothing
                    .Golongan = Nothing

                    .Nama = detail("EmpName")
                    '.LokasiClass = detail("OEEmpLocation")
                    .GTTBeras = Nothing
                    .HkTdkDiByr = Nothing
                    If Not IsDBNull(employee("Gangname")) Then .GangID = employee("Gangname")
                    .JenisKaryawan = Nothing
                    .JmlHariKerja = Nothing
                    .JmlHkTdkDibayar = Nothing
                    .STTJamsostek = Nothing
                    If Not IsDBNull(employee("MandorBesarName")) Then .MandorBesar = employee("MandorBesarName") Else .MandorBesar = ""
                    If Not IsDBNull(detail("BankId")) Then .BankId = detail("BankID") Else .BankId = ""
                    If Not IsDBNull(detail("TYPE")) Then
                        If (detail("TYPE") = "PENDAPATAN") Then
                            .IdPendapatan = detail("AllowDedCode")
                            .Pendapatan = detail("Remarks")
                            .JmlPendapatan = detail("Amount")
                            cPendapatan = cPendapatan + 1
                            'Sai Change Here
                            '   .IdPotongan = Nothing
                            ' .Potongan = Nothing
                            '.Jmlpotongan = Nothing
                        End If

                        If (detail("TYPE") = "POTONGAN") Then
                            .IdPotongan = detail("AllowDedCode")
                            .Potongan = detail("Remarks")
                            .Jmlpotongan = detail("Amount")
                            '.IdPendapatan = Nothing
                            '.Pendapatan = Nothing
                            '.JmlPendapatan = Nothing
                            CPotongan = CPotongan + 1
                        End If
                    End If
                    '  cCountItems = cCountItems + 1
                    detailCount = detailCount + 1
                    If newSwitch Then
                        listSalary.Add(salary)
                    Else
                        If detail("Type") = "POTONGAN" Then
                            listSalary(CPotongan + cCountItems - 1) = salary

                        Else
                            listSalary(cPendapatan + cCountItems - 1) = salary

                        End If
                    End If
                End With

            Next
        Next

        Dim crReport As New CRSalaryEmployeeReport

        crReport.SetDataSource(listSalary)
        Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
        txtMonthYear = CType(crReport.ReportDefinition.ReportObjects.Item("text57"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtMonthYear.Text = "SLIP GAJI PERIODE " & MonthName(Month(StartDate.Value), True) & " " & Year(StartDate.Value)

        'Dim report As New ViewReport
        'report.CRV.ReportSource = crReport
        'report.CRV.RefreshReport()
        'report.ShowDialog()
        Dim myExport As New ExportReportToText
        myExport.TryTextFilePrinting(crReport, Nothing, Nothing)
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class