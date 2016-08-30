Imports CheckRoll_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class VehicleLookup
    Public _VehicleCode As String = String.Empty
    Public _VehicleDesc As String = String.Empty
    Public _VehicleID As String = String.Empty
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvVehicle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVehicle.CellContentClick

    End Sub

    Private Sub VehicleLookup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub VehicleLookup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub VehicleLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTVEHLOOK As DataTable = New DataTable
        DTVEHLOOK = CheckRoll_BOL.LookUpBOL.CRSelectVehicle(txtVhCode.Text, txtVHDesc.Text)
        dgvVehicle.DataSource = DTVEHLOOK
        dgvVehicle.Focus()
        'dgvVehicle.Columns.Item("VHID").Visible = False

        'ConnectionClass.connection.Open()
        'Dim Adapter1 As New SqlDataAdapter("[Checkroll].[CRSelectVehicle]@VHWSCode = '" & txtVhCode.Text & "',@EstateId = '" & GlobalPPT.strEstateID & "'", ConnectionClass.connection)
        'Dim dt1 As New DataTable("Vehicle.VHMaster")
        'Adapter1.Fill(dt1)

    End Sub

    Private Sub pnlCategorySearch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlCategorySearch.Paint

    End Sub

    Private Sub dgvVehicle_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVehicle.CellEnter

    End Sub

    Private Sub dgvVehicle_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvVehicle.DockChanged

    End Sub

    Private Sub dgvVehicle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvVehicle.DoubleClick
        Me._VehicleCode = dgvVehicle.SelectedRows(0).Cells("Vh Code").Value
        Me._VehicleDesc = dgvVehicle.SelectedRows(0).Cells("Vh Descp").Value
        Me._VehicleID = dgvVehicle.SelectedRows(0).Cells("VHID").Value
        Me.DialogResult = DialogResult.OK
        Me.Close()



    End Sub
    Private Sub dgvVehicle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVehicle.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me._VehicleCode = dgvVehicle.SelectedRows(0).Cells("Vh Code").Value
            Me._VehicleDesc = dgvVehicle.SelectedRows(0).Cells("Vh Descp").Value
            Me._VehicleID = dgvVehicle.SelectedRows(0).Cells("VHID").Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        Dim DTVEHLOOK As DataTable = New DataTable
        DTVEHLOOK = CheckRoll_BOL.LookUpBOL.CRSelectVehicle(txtVhCode.Text, txtVHDesc.Text)
        dgvVehicle.DataSource = DTVEHLOOK
        If DTVEHLOOK.Rows.Count = 0 Then
            MsgBox("Data not found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtVhCode.Text = ""
            txtVhCode.Focus()
        ElseIf DTVEHLOOK.Rows.Count > 0 Then
            dgvVehicle.DataSource = DTVEHLOOK
            dgvVehicle.Focus()
        End If
    End Sub

    Private Sub txtVhCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVhCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim DTVEHLOOK As DataTable = New DataTable
            DTVEHLOOK = CheckRoll_BOL.LookUpBOL.CRSelectVehicle(txtVhCode.Text, txtVHDesc.Text)
            dgvVehicle.DataSource = DTVEHLOOK
            If DTVEHLOOK.Rows.Count = 0 Then
                MsgBox("Your data can not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                txtVhCode.Text = ""
                txtVhCode.Focus()
            ElseIf DTVEHLOOK.Rows.Count > 0 Then
                dgvVehicle.DataSource = DTVEHLOOK
                dgvVehicle.Focus()
            End If
        End If
    End Sub

    Private Sub txtVhCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVhCode.TextChanged

    End Sub

    Private Sub lblVHDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVHDesc.Click

    End Sub
End Class