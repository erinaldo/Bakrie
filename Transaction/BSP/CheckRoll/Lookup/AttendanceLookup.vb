Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT

Public Class AttendanceLookup
    Public _AttCode As String = String.Empty
    Public _AttDesc As String = String.Empty
    Public _AttSetupId As String = String.Empty
    Public _LTimeBasic As String = String.Empty
    Public _BasicPay As String = String.Empty
    Public _OT1 As String = String.Empty
    Public _MaxOT1 As String = String.Empty
    Public _OT2 As String = String.Empty
    Public _MaxOT2 As String = String.Empty
    Public _OT3 As String = String.Empty
    Public _MaxOT3 As String = String.Empty
    Public _OT4 As String = String.Empty
    Public _MaxOT4 As String = String.Empty
    Public dtAttSetup As DataTable = Nothing

    Public a, b As Integer
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub AttendanceLookup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub AttendanceLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtattCode.Text = ""
        txtAttDesc.Text = ""
        Dim DTAttSetSelect As DataTable = New DataTable
        DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtattCode.Text, txtAttDesc.Text)
        dgvAttCode.DataSource = DTAttSetSelect

        dgvAttCode.Focus()
        dgvAttCode.Columns.Item("AttendanceSetupID").Visible = False
        dgvAttCode.Columns.Item("OvertimeTimes1").Visible = False
        dgvAttCode.Columns.Item("OvertimeMaxOTHours1").Visible = False
        dgvAttCode.Columns.Item("OvertimeTimes2").Visible = False
        dgvAttCode.Columns.Item("OvertimeMaxOTHours2").Visible = False
        dgvAttCode.Columns.Item("OvertimeTimes3").Visible = False
        dgvAttCode.Columns.Item("OvertimeMaxOTHours3").Visible = False
        dgvAttCode.Columns.Item("OvertimeTimes4").Visible = False
        dgvAttCode.Columns.Item("OvertimeMaxOTHours4").Visible = False
        dgvAttCode.DefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub dgvAttCode_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAttCode.DoubleClick
        Try
            dtAttSetup = dgvAttCode.DataSource
            Me._AttCode = dgvAttCode.SelectedRows(0).Cells("Att Code").Value

            If dgvAttCode.SelectedRows(0).Cells("Att Descp").Value Is System.DBNull.Value Then
                Me._AttDesc = ""
            Else
                Me._AttDesc = dgvAttCode.SelectedRows(0).Cells("Att Descp").Value
            End If
            If dgvAttCode.SelectedRows(0).Cells("AttendanceSetupID").Value.ToString <> Nothing Then
                Me._AttSetupId = dgvAttCode.SelectedRows(0).Cells("AttendanceSetupID").Value
            End If

            If dgvAttCode.SelectedRows(0).Cells("TimesBasic").Value.ToString <> Nothing Then
                Me._LTimeBasic = dgvAttCode.SelectedRows(0).Cells("TimesBasic").Value.ToString()
            End If

            If dgvAttCode.SelectedRows(0).Cells("Att Code").Value.ToString <> Nothing Then
                Me.txtattCode.Text = dgvAttCode.SelectedRows(0).Cells("Att Code").Value
            End If

            If dgvAttCode.SelectedRows(0).Cells("Att Descp").Value IsNot DBNull.Value Then
                Me.txtAttDesc.Text = dgvAttCode.SelectedRows(0).Cells("Att Descp").Value
            End If

            '=======================================================

            If dgvAttCode.Rows.Count > 0 Then

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes1").ToString = Nothing Then
                    Me._OT1 = 0
                Else
                    Me._OT1 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes1").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours1").ToString = Nothing Then
                    Me._MaxOT1 = 0
                Else
                    Me._MaxOT1 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours1").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes2").ToString = Nothing Then
                    Me._OT2 = 0
                Else
                    Me._OT2 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes2").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours2").ToString = Nothing Then
                    Me._MaxOT2 = 0
                Else
                    Me._MaxOT2 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours2").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes3").ToString = Nothing Then
                    Me._OT3 = 0
                Else
                    Me._OT3 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes3").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours3").ToString = Nothing Then
                    Me._MaxOT3 = 0
                Else
                    Me._MaxOT3 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours3").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes4").ToString = Nothing Then
                    Me._OT4 = 0
                Else
                    Me._OT4 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeTimes4").ToString
                End If

                If dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours4").ToString = Nothing Then
                    Me._MaxOT4 = 0
                Else
                    Me._MaxOT4 = dtAttSetup.Rows(dgvAttCode.CurrentCell.RowIndex).Item("OvertimeMaxOTHours4").ToString
                End If

            End If

            '==========================================================

            Me._BasicPay = dgvAttCode.SelectedRows(0).Cells("BasicPay").Value
        Catch ex As Exception

        End Try

        Me.DialogResult = DialogResult.OK
        Me.Close()


    End Sub
    Private Sub dgvAttCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAttCode.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me._AttCode = dgvAttCode.SelectedRows(0).Cells("AttendanceCode").Value
            If dgvAttCode.SelectedRows(0).Cells("AttendType").Value.ToString <> Nothing Then
                Me._AttDesc = dgvAttCode.SelectedRows(0).Cells("AttendType").Value
            End If

            If Me._AttSetupId = dgvAttCode.SelectedRows(0).Cells("AttendanceSetupID").ToString <> Nothing Then
                Me._AttSetupId = dgvAttCode.SelectedRows(0).Cells("AttendanceSetupID").Value
            End If

            If Me.txtattCode.Text = dgvAttCode.SelectedRows(0).Cells("AttendanceCode").ToString <> Nothing Then
                Me.txtattCode.Text = dgvAttCode.SelectedRows(0).Cells("AttendanceCode").Value
            End If

            If dgvAttCode.SelectedRows(0).Cells("AttendType").Value IsNot System.DBNull.Value Then
                Me.txtAttDesc.Text = dgvAttCode.SelectedRows(0).Cells("AttendType").Value
            End If

            '=======================================================

            If dgvAttCode.SelectedRows(0).Cells("OvertimeTimes1").Value IsNot System.DBNull.Value Then
                Me._OT1 = dgvAttCode.SelectedRows(0).Cells("OvertimeTimes1").Value
            End If
            If dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours1").Value IsNot System.DBNull.Value Then
                Me._MaxOT1 = dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours1").Value
            End If


            If dgvAttCode.SelectedRows(0).Cells("OvertimeTimes2").Value IsNot System.DBNull.Value Then
                Me._OT2 = dgvAttCode.SelectedRows(0).Cells("OvertimeTimes2").Value
            End If
            If dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours2").Value IsNot System.DBNull.Value Then
                Me._MaxOT2 = dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours2").Value
            End If


            If dgvAttCode.SelectedRows(0).Cells("OvertimeTimes3").Value IsNot System.DBNull.Value Then
                Me._OT3 = dgvAttCode.SelectedRows(0).Cells("OvertimeTimes3").Value
            End If
            If dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours3").Value IsNot System.DBNull.Value Then
                Me._MaxOT3 = dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours3").Value
            End If


            If dgvAttCode.SelectedRows(0).Cells("OvertimeTimes4").Value IsNot System.DBNull.Value Then
                Me._OT4 = dgvAttCode.SelectedRows(0).Cells("OvertimeTimes4").Value
            End If
            If dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours4").Value IsNot System.DBNull.Value Then
                Me._MaxOT4 = dgvAttCode.SelectedRows(0).Cells("OvertimeMaxOTHours4").Value
            End If

            '==========================================================

            Me._BasicPay = dgvAttCode.SelectedRows(0).Cells("BasicPay").Value

            Me.DialogResult = DialogResult.OK
            Me.Close()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        Return
    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        Dim DTAttSetSelect As DataTable = New DataTable
        DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtattCode.Text, txtAttDesc.Text)
        dgvAttCode.DataSource = DTAttSetSelect
        If DTAttSetSelect.Rows.Count = 0 Then
            MsgBox(" Attendance Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        End If
    End Sub



    Private Sub txtattCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtattCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim DTAttSetSelect As DataTable = New DataTable
            DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtattCode.Text, txtAttDesc.Text)
            dgvAttCode.DataSource = DTAttSetSelect
            If DTAttSetSelect.Rows.Count = 0 Then
                MsgBox(" Attendance Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtAttDesc.Text = ""
            Else
                txtAttDesc.Text = DTAttSetSelect.Rows(0).Item("AttendType").ToString()
                txtattCode.Text = DTAttSetSelect.Rows(0).Item("AttendanceCode").ToString()
            End If
        End If

    End Sub

End Class