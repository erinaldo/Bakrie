Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_DAL

Public Class TAnalysisLookUp
    Public _TACode As String = String.Empty
    Public _TADesc As String = String.Empty
    Public _TAID As String = String.Empty

    Private Sub TAnalysisLookUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TAnalysisLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTTACODE As DataTable
            DTTACODE = Lookup_DAL.CRTAnalisysCodeSelect(Me.txtAttDesc.Text, txtattCode.Text, _TACode)
            dgvTA.DataSource = DTTACODE
            dgvTA.Focus()
            dgvTA.Columns.Item("TAnalysisID").Visible = False

        Catch ex As Exception

        End Try
        dgvTA.DefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub dgvTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvTA.Rows.Count > 0 Then

                Me._TACode = dgvTA.SelectedRows(0).Cells("T Analysis Value").Value
                Me._TADesc = dgvTA.SelectedRows(0).Cells("T Analysis Descp").Value
                Me._TAID = dgvTA.SelectedRows(0).Cells("TAnalysisID").Value
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Else
                MessageBox.Show("No Record", "TAnalysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        Return
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        Dim DTTACODE As DataTable
        DTTACODE = Lookup_DAL.CRTAnalisysCodeSelect(txtAttDesc.Text, txtattCode.Text, _TACode)
        dgvTA.DataSource = DTTACODE
        If DTTACODE.Rows.Count = 0 Then
            MsgBox("Your data can not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
        ElseIf DTTACODE.Rows.Count > 0 Then
            dgvTA.Focus()
        End If

    End Sub

    Private Sub txtattCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtattCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim DTTACODE As DataTable
            DTTACODE = Lookup_DAL.CRTAnalisysCodeSelect(txtAttDesc.Text, txtattCode.Text, _TACode)
            dgvTA.DataSource = DTTACODE
            If DTTACODE.Rows.Count = 0 Then
                MsgBox("Your data can not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            ElseIf DTTACODE.Rows.Count > 0 Then
                dgvTA.Focus()
            End If
        End If
    End Sub

    Private Sub dgvTA_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTA.CellDoubleClick
        ' Senin, 16 Nov 2009, Handles for no record by Dadang
        If dgvTA.Rows.Count > 0 AndAlso Not dgvTA.CurrentCell Is Nothing Then

            Me._TACode = dgvTA.SelectedRows(0).Cells("T Analysis Value").Value
            Me._TADesc = dgvTA.SelectedRows(0).Cells("T Analysis Descp").Value
            Me._TAID = dgvTA.SelectedRows(0).Cells("TAnalysisID").Value
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Else
            MessageBox.Show("No Record", "TAnalysis", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class