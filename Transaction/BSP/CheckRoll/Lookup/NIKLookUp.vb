Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports System.Linq
Imports Common_PPT
Imports BSP.CheckRoll.Import

Public Class NIKLookUp
    Public _lNIK As String = String.Empty
    Public _lEmpName As String = String.Empty
    Public _lEmpid As String = String.Empty
    Public _lTLocation As String = String.Empty
    Public _BasicRate As String = String.Empty
    Public _OTdivider As String = String.Empty
    Public _Mandor As String = String.Empty
    Public _Restday As String = String.Empty
    Public _Category As String = String.Empty
    Public AttDate As String = String.Empty
    Public Activity As String = String.Empty

    Public Sub ShowForm(jobdesc As String)
        Dim dtJobDes As New DataTable
        dtJobDes = CheckRoll_DAL.Lookup_DAL.EmpJobDescriptionSelect()
        With cmbMandorKrani
            .DataSource = dtJobDes
            .ValueMember = "Id"
            .DisplayMember = "Description"
        End With
        cmbMandorKrani.SelectedValue = jobdesc

        Dim dt As New DataTable
        dt = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelectNoTeam(txtNik.Text, txtName.Text, cmbMandorKrani.SelectedValue, "Active", DateTime.Now)
        dgvEmp.DataSource = dt
        ShowDialog()
    End Sub

    Private Sub NIKLookUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Public JobsDesc As String
    Private Sub NIKLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtMandor.Text = Me._Mandor

        If AllowanceDeduction.AttDate <> "12:00:00 AM" Then
            AttDate = AllowanceDeduction.AttDate
        ElseIf DailyAttendanceNoTeam.AttDate <> "12:00:00 AM" Then
            AttDate = DailyAttendanceNoTeam.AttDate
        ElseIf DailyTeamActivity.AttDate <> "12:00:00 AM" Then
            AttDate = DailyTeamActivity.AttDate
            'stanley@29-11-2011
        Else
            AttDate = GlobalPPT.FiscalYearToDate
        End If

        'cmbMandorKrani.SelectedIndex = 0
        txtNik.Text = ""
        txtName.Text = ""
        If txtMandor.Text = "M" Then
            cmbMandorKrani.Text = "Mandor"
        ElseIf txtMandor.Text = "K" Then
            cmbMandorKrani.Text = "Krani"
        ElseIf txtMandor.Text = "D" Then
            cmbMandorKrani.Text = "Driver"
        ElseIf txtMandor.Text = "N" Then
            cmbMandorKrani.Text = "N"
        ElseIf txtMandor.Text = String.Empty Then
            cmbMandorKrani.Text = "All"
            txtMandor.Text = "N"
        End If

        'If cmbMandorKrani.Text = "" Then
        '    txtMandor.Text = "N"
        'End If

        Dim dtJobDes As New DataTable
        dtJobDes = CheckRoll_DAL.Lookup_DAL.EmpJobDescriptionSelect()
        With cmbMandorKrani
            .DataSource = dtJobDes
            .ValueMember = "Id"
            .DisplayMember = "Description"
        End With

        If Activity <> String.Empty Then
            Dim Dt As New DataTable
            If Activity = "Panen" Then
                Dt = CheckRoll_DAL.Lookup_DAL.DailyAttendanceNikSelectByJobsID("C")
            ElseIf Activity = "Deres" Then
                Dt = CheckRoll_DAL.Lookup_DAL.DailyAttendanceNikSelectByJobsID("B")
            ElseIf Activity = "Lain" Then
                Dt = CheckRoll_DAL.Lookup_DAL.DailyAttendanceNikSelectByJobsID("D")
            End If
            dgvEmp.DataSource = Dt
        Else
            If Me.Parameter.Text = "NoTeam" Then
                Dim DTNIKSelect As DataTable = New DataTable
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelectNoTeam(txtNik.Text, txtName.Text, "", "Active", AttDate)
                dgvEmp.DataSource = DTNIKSelect
            Else
                Dim DTNIKSelect As DataTable = New DataTable
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, "", "Active", AttDate)
                dgvEmp.DataSource = DTNIKSelect
            End If

        End If

        If JobsDesc IsNot Nothing Then
            Dim DTNIKSelect As DataTable
            If JobsDesc = "Mandor" Then
                Dim dtTempEmploye As New DataTable
                dtTempEmploye = CheckRoll_DAL.Lookup_DAL.EmpJobDescriptionSelectLike(JobsDesc)
                With cmbMandorKrani
                    .DataSource = dtTempEmploye
                    .ValueMember = "Id"
                    .DisplayMember = "Description"
                End With
                cmbMandorKrani.Enabled = True
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, cmbMandorKrani.SelectedValue, "Active", AttDate)
            Else
                If (JobsDesc <> "") Then
                    cmbMandorKrani.SelectedValue = JobsDesc
                End If
                cmbMandorKrani.Enabled = True
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, cmbMandorKrani.SelectedValue, "Active", AttDate)
            End If

            dgvEmp.DataSource = DTNIKSelect
        End If


        dgvEmp.Focus()
        '=========================================================================
        dgvEmp.Columns.Item("Employee ID").Visible = False
        dgvEmp.Columns.Item("Transfer Location").Visible = False
        dgvEmp.Columns.Item("Basic Rate").Visible = False
        dgvEmp.Columns.Item("OTDivider").Visible = False
        dgvEmp.Columns.Item("Mandor").Visible = False
        dgvEmp.Columns.Item("Krani").Visible = False
        dgvEmp.Columns.Item("Status").Visible = False
        dgvEmp.Columns.Item("GangEmployeeID").Visible = False
        'dgvEmp.Columns.Item("EmpJobDescriptionId").Visible = False
        dgvEmp.DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        If Parameter.Text = "NoTeam" Then
            Dim DTNIKSelect As DataTable = New DataTable
            'DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelectNoTeam(txtNik.Text, txtName.Text, txtMandor.Text, "Active", AttDate)
            If cmbMandorKrani.Text = "--Select All--" Then
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelectNoTeam(txtNik.Text, txtName.Text, "", "Active", AttDate)
            Else
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelectNoTeam(txtNik.Text, txtName.Text, cmbMandorKrani.SelectedValue, "Active", AttDate)
            End If

            dgvEmp.DataSource = DTNIKSelect
            If DTNIKSelect.Rows.Count = 0 Then
                MsgBox("Your data can not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                txtNik.Focus()
                txtNik.Text = ""
            ElseIf DTNIKSelect.Rows.Count > 0 Then
                dgvEmp.Focus()
            End If
        ElseIf Parameter.Text = Nothing Then
            Dim DTNIKSelect As DataTable = New DataTable
            'DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, txtMandor.Text, "Active", AttDate)
            If cmbMandorKrani.Text = "--Select All--" Then
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, "", "Active", AttDate)
            Else
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, cmbMandorKrani.SelectedValue, "Active", AttDate)
            End If

            dgvEmp.DataSource = DTNIKSelect
            If DTNIKSelect.Rows.Count = 0 Then
                MsgBox("Your data can not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                txtNik.Focus()
                txtNik.Text = ""
            ElseIf DTNIKSelect.Rows.Count > 0 Then
                dgvEmp.Focus()
            End If
        End If

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub txtNik_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNik.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")

            Try
                Dim DTNIKSelect As DataTable = New DataTable
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtNik.Text, txtName.Text, txtMandor.Text, "Active", AttDate)
                dgvEmp.DataSource = DTNIKSelect
                dgvEmp.Focus()
                If DTNIKSelect.Rows.Count = 1 Then
                    txtNik.Text = DTNIKSelect.Rows(0).Item("NIK").ToString()
                    txtName.Text = DTNIKSelect.Rows(0).Item("Name").ToString()
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If


    End Sub

    Private Sub dgvEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEmp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.DialogResult = DialogResult.OK

                Me.DialogResult = DialogResult.OK
                Me._lNIK = dgvEmp.SelectedRows(0).Cells("NIK").Value
                Me._lEmpName = dgvEmp.SelectedRows(0).Cells("Name").Value
                Me._lEmpid = dgvEmp.SelectedRows(0).Cells("Employee ID").Value

                If dgvEmp.SelectedRows(0).Cells("Basic Rate").Value.ToString <> Nothing Then
                    Me._BasicRate = dgvEmp.SelectedRows(0).Cells("Basic Rate").Value
                End If
                If dgvEmp.SelectedRows(0).Cells("Mandor").Value.ToString <> Nothing Then
                    Me._Mandor = dgvEmp.SelectedRows(0).Cells("Mandor").Value
                End If

                If dgvEmp.SelectedRows(0).Cells("OTDivider").Value.ToString <> Nothing Then
                    Me._OTdivider = dgvEmp.SelectedRows(0).Cells("OTDivider").Value
                End If

                If dgvEmp.SelectedRows(0).Cells("Transfer Location").Value.ToString <> Nothing Then
                    Me._lTLocation = dgvEmp.SelectedRows(0).Cells("Transfer Location").Value.ToString
                End If

                If dgvEmp.SelectedRows(0).Cells("RestDay").Value.ToString <> Nothing Then
                    Me._Restday = dgvEmp.SelectedRows(0).Cells("RestDay").Value.ToString
                End If
                Me.Close()

            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If

            Return
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dgvEmp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEmp.DoubleClick
        Try

            Me.DialogResult = DialogResult.OK
            Me._lNIK = dgvEmp.SelectedRows(0).Cells("NIK").Value
            Me._lEmpName = dgvEmp.SelectedRows(0).Cells("Name").Value
            Me._lEmpid = dgvEmp.SelectedRows(0).Cells("Employee ID").Value

            If dgvEmp.SelectedRows(0).Cells("Basic Rate").Value.ToString <> Nothing Then
                Me._BasicRate = dgvEmp.SelectedRows(0).Cells("Basic Rate").Value
            End If
            If dgvEmp.SelectedRows(0).Cells("Mandor").Value.ToString <> Nothing Then
                Me._Mandor = dgvEmp.SelectedRows(0).Cells("Mandor").Value
            End If

            If dgvEmp.SelectedRows(0).Cells("OTDivider").Value.ToString <> Nothing Then
                Me._OTdivider = dgvEmp.SelectedRows(0).Cells("OTDivider").Value
            End If

            If dgvEmp.SelectedRows(0).Cells("Transfer Location").Value.ToString <> Nothing Then
                Me._lTLocation = dgvEmp.SelectedRows(0).Cells("Transfer Location").Value.ToString
            End If

            If dgvEmp.SelectedRows(0).Cells("RestDay").Value.ToString <> Nothing Then
                Me._Restday = dgvEmp.SelectedRows(0).Cells("RestDay").Value.ToString
            End If

            If dgvEmp.SelectedRows(0).Cells("Category").Value.ToString <> Nothing Then
                Me._Category = dgvEmp.SelectedRows(0).Cells("Category").Value.ToString
            End If


            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvEmp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmp.CellContentClick

    End Sub

    Private Sub cmbMandorKrani_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMandorKrani.SelectedIndexChanged
        If cmbMandorKrani.Text = "Mandor" Then
            txtMandor.Text = "M"
        ElseIf cmbMandorKrani.Text = "Krani" Then
            txtMandor.Text = "K"
        ElseIf cmbMandorKrani.Text = "All" Then
            txtMandor.Text = "N"
        ElseIf cmbMandorKrani.Text = "Driver" Then
            txtMandor.Text = "D"
        ElseIf cmbMandorKrani.Text = "" Then
            txtMandor.Text = "N"
        End If
    End Sub

End Class