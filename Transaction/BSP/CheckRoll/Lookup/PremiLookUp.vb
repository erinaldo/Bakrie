Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports CheckRoll_PPT
Imports Common_PPT
Public Class PremiLookUp
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub PremiLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim DTAttSetSelect As DataTable = New DataTable
        DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttendanceCode.Text, "")
        If DTAttSetSelect.Rows.Count > 0 Then
            lblAttID.Text = DTAttSetSelect.Rows(0).Item("AttendanceSetupID").ToString()
        End If

        Dim DTPremiSetup As DataTable = New DataTable
        DTPremiSetup = CheckRoll_BOL.LookUpBOL.CRPremiSetup(lblAttID.Text, txtBlockID.Text)
        If DTPremiSetup.Rows.Count > 0 Then
            lblAttID.Text = DTPremiSetup.Rows(0).Item("AttendanceSetupID").ToString()
        End If


        dgpremi.DataSource = DTPremiSetup

        dgpremi.Columns.Item("DivID").Visible = False
        dgpremi.Columns.Item("YopID").Visible = False
        dgpremi.Columns.Item("BlockID").Visible = False
        dgpremi.Columns.Item("AttendanceSetupID").Visible = False
        dgpremi.DefaultCellStyle.BackColor = Color.White
    End Sub
End Class