'/**************************
'
' By Dadang Adi H
' Rabu, 23 Sep 2009, 20:52
'
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT

Imports CheckRoll_DAL

Public Class TeamLookUps
    Public DailyTeamActivityID = String.Empty
    Public Activity As String = String.Empty

    Public GangName As String = String.Empty
    Public GangMasterID As String = String.Empty
    Public Category As String = String.Empty

    ' Jum'at, 16 Oct 2009, 14:48
    Public MandorID As String = String.Empty
    Public KraniID As String = String.Empty

    Public MandorEmpCode As String = String.Empty
    Public KraniEmpCode As String = String.Empty

    Public MandorEmpName As String = String.Empty
    Public KraniEmpName As String = String.Empty


    Public DDate As Date = Now
    Private DT_Team As DataTable

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub TeamLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""

        DT_Team = DailyAttendanceWithTeam_DAL.CRGangMasterSelect("", _
                                                                 txtMandorNameView.Text, _
                                                                 "", _
                                                                 DDate, GlobalPPT.strCategoryField)
        dgvTeam.DataSource = DT_Team
        ManageGridColumn()
        dgvTeam.Focus()

        ' Saturday, 24 Oct 2009, 14:26
        If DT_Team.Rows.Count = 0 Then
            lblMsg.Text = "There is no team, you must registered the team in Daily Team Activity"
        Else
            lblMsg.Text = String.Empty
        End If
        dgvTeam.DefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub ManageGridColumn()
        ' Kamis, 08 Oct 2009, 05:51
        'Modified : Ahad, 18 Oct 2009, 17:13
        dgvTeam.RowHeadersWidth = 10

        dgvTeam.Columns("DailyTeamActivityID").Visible = False
        dgvTeam.Columns("MandoreID").Visible = False
        dgvTeam.Columns("KraniID").Visible = False

        dgvTeam.Columns("MandorEmpCode").HeaderText = "Mandor Nik"
        dgvTeam.Columns("KraniEmpCode").HeaderText = "Krani Nik"

        dgvTeam.Columns("MandorEmpName").DisplayIndex = 1
        dgvTeam.Columns("MandorEmpName").HeaderText = "Mandor Name"

        dgvTeam.Columns("KraniEmpName").DisplayIndex = 2
        dgvTeam.Columns("KraniEmpName").HeaderText = "Krani Name"


    End Sub
    Private Sub dgvTeam_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTeam.KeyDown
        If e.KeyCode = Keys.Enter Then

            If dgvTeam.Rows.Count > 0 Then
                If dgvTeam.CurrentCell IsNot Nothing Then

                    Dim rowIndex As Integer = dgvTeam.CurrentCell.RowIndex

                    ' Rabu, 21 Oct 2009, 15:03

                    ' Rabu, 21 Oct 2009, 15:03
                    DailyTeamActivityID = dgvTeam.Rows(rowIndex).Cells("DailyTeamActivityID").Value.ToString()
                    Activity = dgvTeam.Rows(rowIndex).Cells("Activity").Value.ToString()

                    GangName = dgvTeam.Rows(rowIndex).Cells("GangNameColumn").Value.ToString()
                    GangMasterID = dgvTeam.Rows(rowIndex).Cells("GangMasterIDColumn").Value.ToString()
                    'Category = dgvTeam.Rows(rowIndex).Cells("Category").Value.ToString()

                    ' Jum'at, 16 Oct 2009, 14:52
                    MandorID = dgvTeam.Rows(rowIndex).Cells("MandoreID").Value.ToString()
                    KraniID = dgvTeam.Rows(rowIndex).Cells("KraniID").Value.ToString()

                    MandorEmpName = dgvTeam.Rows(rowIndex).Cells("MandorEmpName").Value.ToString()
                    KraniEmpName = dgvTeam.Rows(rowIndex).Cells("KraniEmpName").Value.ToString()

                    MandorEmpCode = dgvTeam.Rows(rowIndex).Cells("MandorEmpCode").Value.ToString()
                    KraniEmpCode = dgvTeam.Rows(rowIndex).Cells("KraniEmpCode").Value.ToString()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Close()
                End If
            End If

        End If
    End Sub

    Private Sub dgvTeam_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTeam.DataError
        MessageBox.Show(e.Exception.Message())
    End Sub

    Private Sub dgvTeam_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTeam.CellDoubleClick
        ' Rabu, 16 Sep 2009, 13:50
        If dgvTeam.Rows.Count > 0 Then
            If dgvTeam.CurrentCell IsNot Nothing Then

                Dim rowIndex As Integer = dgvTeam.CurrentCell.RowIndex

                ' Rabu, 21 Oct 2009, 15:03
                DailyTeamActivityID = dgvTeam.Rows(rowIndex).Cells("DailyTeamActivityID").Value.ToString()
                Activity = dgvTeam.Rows(rowIndex).Cells("Activity").Value.ToString()

                GangName = dgvTeam.Rows(rowIndex).Cells("GangNameColumn").Value.ToString()
                GangMasterID = dgvTeam.Rows(rowIndex).Cells("GangMasterIDColumn").Value.ToString()
                'Category = dgvTeam.Rows(rowIndex).Cells("Category").Value.ToString()

                ' Jum'at, 16 Oct 2009, 14:52
                MandorID = dgvTeam.Rows(rowIndex).Cells("MandoreID").Value.ToString()
                KraniID = dgvTeam.Rows(rowIndex).Cells("KraniID").Value.ToString()

                MandorEmpName = dgvTeam.Rows(rowIndex).Cells("MandorEmpName").Value.ToString()
                KraniEmpName = dgvTeam.Rows(rowIndex).Cells("KraniEmpName").Value.ToString()

                MandorEmpCode = dgvTeam.Rows(rowIndex).Cells("MandorEmpCode").Value.ToString()
                KraniEmpCode = dgvTeam.Rows(rowIndex).Cells("KraniEmpCode").Value.ToString()
                Category = dgvTeam.Rows(rowIndex).Cells("Category").Value.ToString()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ' Sabtu, 24  Oct 2009, 10:35
        'If DT_Team.Rows.Count = 0 Then
        '    Return
        'End If

        ' Selasa, 27 Oct 2009, 11:32
        DT_Team = DailyAttendanceWithTeam_DAL.CRGangMasterSelect(txtTeamNameView.Text, _
                                                                 txtMandorNameView.Text, _
                                                                 "", _
                                                                 DDate, GlobalPPT.strCategoryField)
        dgvTeam.DataSource = DT_Team
        ManageGridColumn()
        dgvTeam.Focus()

        ' Saturday, 24 Oct 2009, 14:26
        If DT_Team.Rows.Count = 0 Then
            lblMsg.Text = "There is no team, you must registered the team in Daily Team Activity"
        Else
            lblMsg.Text = String.Empty
        End If

        'Dim dv As DataView
        'Dim rowIndex As Integer

        'dv = New DataView(DT_Team, "", "GangName", DataViewRowState.CurrentRows)
        'dv.ApplyDefaultSort = True

        'rowIndex = dv.Find(txtTeamName.Text)
        'If rowIndex = -1 Then
        '    MessageBox.Show("No Team Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    'DT_Team.DefaultView.
        '    dgvTeam.CurrentCell = dgvTeam.Rows(rowIndex).Cells("GangNameColumn")
        'End If

    End Sub

    Private Sub dgvTeam_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTeam.CellContentClick

    End Sub
End Class