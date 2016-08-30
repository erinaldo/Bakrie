Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Public Class EstateLookup
    Public _LEstateCode As String = String.Empty
    Public _LEstateName As String = String.Empty
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEstateView.CellContentClick

    End Sub

    Private Sub EstateLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTAttEstSelect As DataTable = New DataTable
        'DTAttEstSelect = CheckRoll_BOL.LookUpBOL.CRDailyAttendanceEstateSelect(txtestateName.Text)
        DTAttEstSelect = CheckRoll_BOL.LookUpBOL.GeneralEstateSelect()
        dgvEstateView.DataSource = DTAttEstSelect
        dgvEstateView.Focus()
    End Sub

    Private Sub dgvEstateView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEstateView.CellDoubleClick
        Me._LEstateName = dgvEstateView.SelectedRows(0).Cells("dgcEstateName").Value
        _LEstateCode = dgvEstateView.SelectedRows(0).Cells("dgcEstateCode").Value
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvEstateView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEstateView.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me._LEstateName = dgvEstateView.SelectedRows(0).Cells("dgcEstateName").Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click

    End Sub
End Class