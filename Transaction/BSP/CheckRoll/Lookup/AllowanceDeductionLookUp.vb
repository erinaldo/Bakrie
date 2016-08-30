Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_BOL

Public Class AllowanceDeductionLookUp
    Public _LADCode As String = String.Empty
    Public _LADDescp As String = String.Empty
    Public _LAllDedID As String = String.Empty
    Public _LType As String = String.Empty
    Public _LADCoaID As String = String.Empty

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        Try
            Dim DTADIsExist As DataTable = New DataTable
            DTADIsExist = CheckRoll_BOL.LookUpBOL.CRAllowanceDeductionSetupIsExist(txtallCode.Text)
            dgvADCode.DataSource = DTADIsExist

            If DTADIsExist.Rows.Count > 0 Then
                txtallCode.Text = DTADIsExist.Rows(0).Item("AllowDedCode").ToString()
            ElseIf DTADIsExist.Rows.Count = 0 Then
                MsgBox(" Your data can not be found, Allowance & Deduction code is not valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtallCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtallCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim DTADIsExist As DataTable = New DataTable
                DTADIsExist = CheckRoll_BOL.LookUpBOL.CRAllowanceDeductionSetupIsExist(txtallCode.Text)
                dgvADCode.DataSource = DTADIsExist

                If DTADIsExist.Rows.Count > 0 Then
                    txtallCode.Text = DTADIsExist.Rows(0).Item("AllowDedCode").ToString()
                ElseIf DTADIsExist.Rows.Count = 0 Then
                    MsgBox(" Your data can not be found, Allowance & Deduction code is not valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvADCode_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvADCode.DoubleClick
        Me.DialogResult = DialogResult.OK
        _LADCode = dgvADCode.SelectedRows(0).Cells("AllowDedCode").Value()
        _LADDescp = dgvADCode.SelectedRows(0).Cells("Remarks").Value()
        _LAllDedID = dgvADCode.SelectedRows(0).Cells("AllowDedID").Value()
        _LType = dgvADCode.SelectedRows(0).Cells("Type").Value()
        _LADCoaID = dgvADCode.SelectedRows(0).Cells("CoaID").Value()
        txtallCode.Text = dgvADCode.SelectedRows(0).Cells("AllowDedCode").Value()
        lblRemarks.Text = dgvADCode.SelectedRows(0).Cells("Remarks").Value()

        Me.Close()
    End Sub

    Private Sub dgvADCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvADCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = DialogResult.OK
            _LADCode = dgvADCode.SelectedRows(0).Cells("AllowDedCode").Value()
            _LADDescp = dgvADCode.SelectedRows(0).Cells("Remarks").Value()
            _LAllDedID = dgvADCode.SelectedRows(0).Cells("AllowDedID").Value()
            txtallCode.Text = dgvADCode.SelectedRows(0).Cells("AllowDedCode").Value()
            lblRemarks.Text = dgvADCode.SelectedRows(0).Cells("Remarks").Value()
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub AllowanceDeductionLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTADIsExist As DataTable = New DataTable
        'DTADIsExist = CheckRoll_BOL.LookUpBOL.CRAllowanceDeductionSetupIsExist("XXX")
        DTADIsExist = CheckRoll_BOL.LookUpBOL.CRAllowanceDeductionSetupIsExist("")
        dgvADCode.DataSource = DTADIsExist
        dgvADCode.Columns.Item("AllowDedID").Visible = False
        dgvADCode.Columns.Item("EstateID").Visible = False
        dgvADCode.Columns.Item("COAID").Visible = False
    End Sub
End Class