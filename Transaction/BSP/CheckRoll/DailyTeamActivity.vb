Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports System.Windows.Forms
Imports Common_PPT
Imports Common_DAL
Imports CheckRoll_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Imports BSP.CheckRoll.LookupEdit

Public Class DailyTeamActivity
    Private DailyActivityTeamAdapter As New DailyActivityTeam_DAL
    Public DTDailyTeamActivity As DataTable = New DataTable
    Public CDEL As DataTable = New DataTable
    'Public Sum As DataTable = New DataTable
    Public DT As DataTable = New DataTable
    Private DTA_PANEN As String = String.Empty
    Private DTA_Activity As String = String.Empty
    Private DTA_PANENIKrani As String = String.Empty
    Public Shared AttDate As Date
    Private bindingSource1 As New BindingSource()

    Public Sub RefreshAfterModify(tglDate As Date)
        ' Me.dgvDailyTeamActivity.DataSource = Nothing

        GenerateTeam()
        Reset()
    End Sub

    Private Sub btnEditOrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrUpdate.Click

        If UpdateDailyTeamActivity() = True Then

            btnSaveAll.Enabled = True
            lblInfo.Visible = False
            btnModifyTeam.Enabled = True
            dgvDailyTeamActivity.Enabled = True
            btnEditOrUpdate.Enabled = False
            btnReset.Enabled = False

            dtpRDate.Enabled = True
            btnGenerateTeam.Enabled = True
            btnSaveAll.Enabled = True
            btnClose.Enabled = True

            Reset()
            MessageBox.Show("Data updated, Please Save all to confirm", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvDailyTeamActivity.Focus()
        End If

        btnSaveAll.Focus()

    End Sub

    Private Function UpdateDailyTeamActivity() As Boolean

        Dim Hasil As Boolean = True

        If String.IsNullOrEmpty(lblMandorId.Text) Then
            MessageBox.Show("Mandor NIK not valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Hasil = False
            Return Hasil
        End If

        Dim TeamActivity As String = String.Empty
        Dim MandorName As String = String.Empty
        If DTA_Activity = cmbActivity.Text Then
            If DTA_PANEN <> lblMandorId.Text.Trim Then
                If IsMandorAlreadyInGrid(TeamActivity, MandorName) <> -1 Then
                    If TeamActivity <> cmbActivity.Text Then
                        MessageBox.Show(lblMandorName.Text + " is already Mandor for " + cmbActivity.Text + " TEAM, " + _
                                       " cannot be Mandor for another" + cmbActivity.Text + " TEAM", "Information", _
                                       MessageBoxButtons.OK, _
                                       MessageBoxIcon.Information)
                        Hasil = False
                    End If
                End If
            End If
        Else

            Dim intcountLAIN As Integer = 0
            Dim intcountPANEN As Integer = 0
            If DTA_PANEN <> lblMandorId.Text.Trim Then
                If dgvDailyTeamActivity.Rows.Count > 0 Then
                    Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyTeamActivity.DataSource, dgvDailyTeamActivity.DataMember), CurrencyManager)
                    Dim dv As DataView = CType(cm.List, DataView)
                    Dim MandoreID As String
                    For i As Int32 = 0 To dv.Count - 1
                        Dim row As DataRow = dv.Item(i).Row
                        If row.RowState <> DataRowState.Deleted Then
                            MandoreID = row.Item("Mandore ID").ToString()
                            If MandoreID = lblMandorId.Text Then
                                If row.Item("Activity").ToString() = "LAIN" Then
                                    intcountLAIN = intcountLAIN + 1
                                End If
                                If row.Item("Activity").ToString() = "PANEN" Then
                                    intcountPANEN = intcountPANEN + 1
                                End If
                            End If
                        End If
                    Next
                End If
                If intcountLAIN > 1 Or (intcountPANEN > 0 And cmbActivity.Text = "LAIN") Then
                    MessageBox.Show(lblMandorName.Text + " is already Mandor for " + cmbActivity.Text + " TEAM, " + _
                                    " cannot be Mandor for another" + cmbActivity.Text + " TEAM", "Information", _
                                        MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                    Hasil = False
                Else
                    Hasil = True
                End If
            Else
                Hasil = True
            End If
        End If

        If txtKraniNik.Text.Trim <> "" Then
            If DTA_Activity = cmbActivity.Text Then
                If DTA_PANENIKrani <> lblKraniId.Text.Trim Then
                    If IsKraniAlreadyInGrid() <> -1 Then
                        'If TeamActivity <> cmbActivity.Text Then
                        MessageBox.Show(lblKraniName.Text + " is already Krani for " + cmbActivity.Text + " TEAM, " + _
                                       " cannot be Krani for another " + cmbActivity.Text + " TEAM", "Information", _
                                       MessageBoxButtons.OK, _
                                       MessageBoxIcon.Information)
                        Hasil = False
                        'End If
                    End If
                End If
            Else
                If DTA_PANENIKrani <> lblKraniId.Text.Trim Then


                    Dim intcountLAIN As Integer = 0
                    Dim intcountPANEN As Integer = 0
                    If dgvDailyTeamActivity.Rows.Count > 0 Then
                        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyTeamActivity.DataSource, dgvDailyTeamActivity.DataMember), CurrencyManager)
                        Dim dv As DataView = CType(cm.List, DataView)
                        Dim MandoreID As String
                        For i As Int32 = 0 To dv.Count - 1
                            Dim row As DataRow = dv.Item(i).Row
                            If row.RowState <> DataRowState.Deleted Then
                                MandoreID = row.Item("Mandore ID").ToString()
                                If MandoreID = lblMandorId.Text Then
                                    If row.Item("Activity").ToString() = "LAIN" Then
                                        intcountLAIN = intcountLAIN + 1
                                    End If
                                    If row.Item("Activity").ToString() = "PANEN" Then
                                        intcountPANEN = intcountPANEN + 1
                                    End If
                                End If
                            End If
                        Next
                    End If
                    If intcountLAIN > 1 Or (intcountPANEN > 1 And cmbActivity.Text = "LAIN") Then

                        MessageBox.Show(lblKraniName.Text + " is already Krani for " + TeamActivity + " TEAM, " + _
                                               " cannot Krani for another " + cmbActivity.Text + " TEAM", "Information", _
                                               MessageBoxButtons.OK, _
                                               MessageBoxIcon.Information)
                        Hasil = False
                    Else
                        Hasil = True

                    End If
                End If
            End If
        End If

        If Hasil = True Then
            Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyTeamActivity.DataSource, dgvDailyTeamActivity.DataMember), CurrencyManager)
            Dim dv As DataView = CType(cm.List, DataView)
            Dim dr As DataRow

            dr = dv.Item(cm.Position).Row

            dr.Item("Activity") = cmbActivity.Text
            dr.Item("Mandore ID") = lblMandorId.Text
            dr.Item("Mandor") = lblMandorName.Text
            dr.Item("Mandor Nik") = txtMandorNik.Text

            dr.Item("Krani ID") = lblKraniId.Text
            dr.Item("Krani") = lblKraniName.Text
            dr.Item("Krani Nik") = txtKraniNik.Text
        End If

        Return Hasil
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If (MessageBox.Show("Are you sure, you want to delete!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Dim fMsg As New ProgressingFrm
            fMsg.TopMost = True
            fMsg.Show()
            ' fMsg.lblMessage.Refresh()
            fMsg.lblTitle.Refresh()
            fMsg.lblTitle.Text = "Deletion Processing . . ."
            fMsg.lblTitle.Refresh()

            Delete()
            LoadDailyTeamActivity()
            HideColumnDailyTeamActivity()
            Reset()
            btnSaveAll.Enabled = True
            lblInfo.Visible = False
            btnModifyTeam.Enabled = True
            dgvDailyTeamActivity.Enabled = True
            dgvDailyTeamActivity.Focus()
            btnEditOrUpdate.Enabled = False
            btnReset.Enabled = False
            dtpRDate.Enabled = True
            btnGenerateTeam.Enabled = True
            btnSaveAll.Enabled = True
            btnClose.Enabled = True
            'btnDelete.Enabled = False
            fMsg.Close()

        End If
    End Sub

    Private Sub Delete()

        Dim OutputType As String = String.Empty

        CDEL = CheckRoll_BOL.DailyActivityTeamBOL.DailyTeamActivityDelete(dgvDailyTeamActivity.SelectedRows(0).Cells("Daily Team Activity ID").Value(), dgvDailyTeamActivity.SelectedRows(0).Cells("Activity").Value(), dtpRDate.Value, OutputType)
        Me.dgvDailyTeamActivity.DataSource = CDEL

        AttSummReport()
        UploadSalary()

        If dgvDailyTeamActivity.Rows.Count > 0 Then

            If OutputType = "1" Then
                MessageBox.Show("This record should not be deleted, there are activity  present on the day for the team", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvDailyTeamActivity.Focus()

            ElseIf OutputType = "2" Then
                MessageBox.Show("This record should not be deleted, there are activity present on the day for the team", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvDailyTeamActivity.Focus()


            ElseIf OutputType = "3" Then
                MessageBox.Show("This record should not be deleted, there are team members  present on the day for the team", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvDailyTeamActivity.Focus()

            Else
                MessageBox.Show("Deleted Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvDailyTeamActivity.Focus()
            End If

        Else
            MessageBox.Show("Deleted Succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvDailyTeamActivity.Focus()
        End If

    End Sub

    Private Sub AttSummReport()
        CheckRoll_BOL.DailyActivityTeamBOL.AttSummaryWithTeamProcess()
    End Sub

    Private Sub UploadSalary()
        ' Dim SalaryProcDate As Date

        CheckRoll_BOL.DailyActivityTeamBOL.UploadSalary(dtpRDate.Value)
    End Sub

    Private Function IsMandorAlreadyInGrid(ByRef TeamActivity As String, ByRef MandorName As String) As Integer

        Dim rowIndex As Integer = -1

        Dim intcountPANEN As Integer = 0
        Dim intcountLAIN As Integer = 0
        If dgvDailyTeamActivity.Rows.Count > 0 Then


            Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyTeamActivity.DataSource, dgvDailyTeamActivity.DataMember), CurrencyManager)
            Dim dv As DataView = CType(cm.List, DataView)

            Dim MandoreID As String

            For i As Int32 = 0 To dv.Count - 1
                Dim row As DataRow = dv.Item(i).Row
                If row.RowState <> DataRowState.Deleted Then
                    MandoreID = row.Item("Mandore ID").ToString()

                    If MandoreID = lblMandorId.Text Then
                        '  intcountmandore = intcountmandore + 1
                        If row.Item("Activity").ToString() = "PANEN" Then
                            intcountPANEN = intcountPANEN + 1
                        End If
                        If row.Item("Activity").ToString() = "LAIN" Then
                            intcountLAIN = intcountLAIN + 1
                        End If
                    End If


                End If
            Next

        End If
        If (intcountPANEN > 0) Or (intcountLAIN > 1) Or (intcountLAIN > 0 And cmbActivity.Text = "PANEN") Then
            Return 1
        Else
            Return -1
        End If

    End Function

    Private Function IsKraniAlreadyInGrid() As Integer
        ' By Dadang
        ' Senin, 16 Nov 2009, 01:35
        ' Jum'at, 11 Des 2009, 14:50 add TeamActivity and MandorName parameter
        Dim rowIndex As Integer = -1

        Dim intcountPANEN As Integer = 0
        Dim intcountLAIN As Integer = 0
        If dgvDailyTeamActivity.Rows.Count > 0 Then


            Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyTeamActivity.DataSource, dgvDailyTeamActivity.DataMember), CurrencyManager)
            Dim dv As DataView = CType(cm.List, DataView)

            Dim KraniID As String

            For i As Int32 = 0 To dv.Count - 1
                Dim row As DataRow = dv.Item(i).Row
                If row.RowState <> DataRowState.Deleted Then
                    KraniID = row.Item("Krani ID").ToString()
                    If KraniID = lblKraniId.Text Then
                        If row.Item("Activity").ToString() = "PANEN" Then
                            intcountPANEN = intcountPANEN + 1
                        End If
                        If row.Item("Activity").ToString() = "LAIN" Then
                            intcountLAIN = intcountLAIN + 1
                        End If
                    End If
                End If
            Next

        End If

        If (intcountPANEN > 0) Or (intcountLAIN > 1) Or (intcountLAIN > 0 And cmbActivity.Text = "PANEN") Then
            Return 1
        Else
            Return -1
        End If

    End Function

    Private Sub DailyTeamActivity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim ModifiedRow As DataRow() = DTDailyTeamActivity.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DTDailyTeamActivity.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DTDailyTeamActivity.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False


        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        If Modified Then
            If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                            "Do you want to save this data..", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                CheckRoll_BOL.DailyActivityTeamBOL.Save(DailyActivityTeamAdapter, DTDailyTeamActivity)
            End If
        End If

    End Sub

    Private Sub DailyTeamActivity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If dgvDailyTeamActivity.Rows.Count > 0 Then
            For i = 0 To dgvDailyTeamActivity.Rows.Count - 1
                If dgvDailyTeamActivity.Rows(i).Cells("Daily Team Activity ID").Value.ToString = Nothing Then
                    dgvDailyTeamActivity.Rows(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                End If
            Next i
        End If

    End Sub

    Private Sub DailyTeamActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpRDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpRDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpRDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpRDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpRDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If
        LoadDailyTeamActivity()
        HideColumnDailyTeamActivity()
        dgvDailyTeamActivity.DefaultCellStyle.BackColor = Color.White

        lblMandorId.Text = String.Empty
        lblKraniId.Text = String.Empty
        Reset()
        dtpRDate.Focus()
        Dim dt As DataTable = KeyValuePair.GetKeyValuePair("TeamActivity")
        cmbActivity.DataSource = dt
        cmbActivity.DisplayMember = "ValueName"
        cmbActivity.ValueMember = "ValueName"

    End Sub
    Dim valueNIK As String

    Private Sub LoadDailyTeamActivity()
        DTDailyTeamActivity = CheckRoll_BOL.DailyActivityTeamBOL.DailyTeamActivityisExist(dtpRDate.Value)
        dgvDailyTeamActivity.DataSource = DTDailyTeamActivity
    End Sub

    Private Sub arrangeview()
        dgvDailyTeamActivity.Columns.Item("Daily Team Activity ID1").Visible = False
        dgvDailyTeamActivity.Columns.Item("Daily Team Activity ID").Visible = False
        dgvDailyTeamActivity.Columns.Item("Date").Visible = False
        dgvDailyTeamActivity.Columns.Item("Gang Master id").Visible = False
        dgvDailyTeamActivity.Columns.Item("Estate id").Visible = False
        dgvDailyTeamActivity.Columns.Item("Estate Code").Visible = False
        dgvDailyTeamActivity.Columns.Item("Mandore ID").Visible = False
        dgvDailyTeamActivity.Columns.Item("Emp Code Mandor").Visible = False
        dgvDailyTeamActivity.Columns.Item("Krani ID").Visible = False
        dgvDailyTeamActivity.Columns.Item("Emp Code Krani").Visible = False

    End Sub

    Private Sub HideColumnDailyTeamActivity()
        dgvDailyTeamActivity.Columns.Item("Date").Visible = True
        dgvDailyTeamActivity.Columns.Item("Daily Team Activity ID").Visible = False
        dgvDailyTeamActivity.Columns.Item("Gang Master id").Visible = False
        dgvDailyTeamActivity.Columns.Item("Estate id").Visible = False
        dgvDailyTeamActivity.Columns.Item("Estate Code").Visible = False

        dgvDailyTeamActivity.Columns.Item("Mandore ID").Visible = False
        dgvDailyTeamActivity.Columns.Item("Emp ID Mandor").Visible = False

        dgvDailyTeamActivity.Columns.Item("Krani ID").Visible = False
        dgvDailyTeamActivity.Columns.Item("Emp ID Krani").Visible = False

        If dgvDailyTeamActivity.Columns.Item("Mandor Besar ID") IsNot Nothing Then
            dgvDailyTeamActivity.Columns.Item("Mandor Besar ID").Visible = False
        End If

        If dgvDailyTeamActivity.Columns.Item("Emp ID Mandor Besar") IsNot Nothing Then
            dgvDailyTeamActivity.Columns.Item("Emp ID Mandor Besar").Visible = False
        End If

        dgvDailyTeamActivity.Columns.Item("Created By").Visible = False
        dgvDailyTeamActivity.Columns.Item("Created On").Visible = False
        dgvDailyTeamActivity.Columns.Item("Modified By").Visible = False
        dgvDailyTeamActivity.Columns.Item("Modified On").Visible = False
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub EditDailyTeamActivity()
        ' by Dadang Adi H
        ' Kamis, 10 Des 2009, 14:17
        Tgl = dtpRDate.Value
        If dgvDailyTeamActivity.Rows.Count > 0 Then
            DT = CheckRoll_BOL.DailyActivityTeamBOL.DailyTeamActivityIsSelected(dgvDailyTeamActivity.SelectedRows(0).Cells("Daily Team Activity ID").Value(), dtpRDate.Value)
            Dim dtIsExistDailyGangEmployeeSetup As New DataTable
            dtIsExistDailyGangEmployeeSetup = DailyActivityTeamBOL.DailyGangEmployeeSetupSelect(dgvDailyTeamActivity.SelectedRows(0).Cells("Gang Master id").Value)

            If DT.Rows.Count > 0 Then
                lblInfo.Visible = True
                btnModifyTeam.Enabled = False
                MessageBox.Show("Team cannot be modified at this time as it's been refered in Daily Attendance", _
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'btnEditOrUpdate.Enabled = False
                Return
            ElseIf dtIsExistDailyGangEmployeeSetup.Rows.Count = 0 Then
                lblInfo.Visible = True
                btnModifyTeam.Enabled = False
                MessageBox.Show("Team isn't Exist at DailyGangEmployeeSetup", _
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            ElseIf DT.Rows.Count = 0 Then
                lblInfo.Visible = False
                btnModifyTeam.Enabled = True
                'btnEditOrUpdate.Enabled = True
            End If

            ' Jum'at, 11 Des 2009, 13:50
            ' Use currency Manager
            Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyTeamActivity.DataSource, dgvDailyTeamActivity.DataMember), CurrencyManager)
            Dim dv As DataView = CType(cm.List, DataView)
            Dim dr As DataRow

            dr = dv.Item(cm.Position).Row

            Dim Activity As String = String.Empty
            Activity = dr.Item("Activity").ToString()

            txtMandorNik.Enabled = True
            btnmandorView.Enabled = True

            If Activity = "LAIN" Then
                cmbActivity.Enabled = True
                'cmbActivity.Enabled = False

                txtKraniNik.Enabled = True
                btnKraniView.Enabled = True

            ElseIf Activity = "PANEN" Then
                cmbActivity.Enabled = True

                txtKraniNik.Enabled = True
                btnKraniView.Enabled = True
            End If

            Try

                txtTeam.Text = dr.Item("Team Name").ToString()
                cmbActivity.Text = dr.Item("Activity").ToString()
                txtMandorNik.Text = dr.Item("Mandor Nik").ToString()
                lblMandorName.Text = dr.Item("Mandor").ToString()
                lblMandorId.Text = dr.Item("Mandore ID").ToString()
                DTA_PANEN = dr.Item("Mandore ID").ToString()

                DTA_Activity = dr.Item("Activity").ToString()
                If Not dr.IsNull("Krani NIK") Then
                    txtKraniNik.Text = dr.Item("Krani NIK").ToString()
                    lblKraniName.Text = dr.Item("Krani").ToString()
                    lblKraniId.Text = dr.Item("Krani ID").ToString()
                    DTA_PANENIKrani = dr.Item("Krani ID").ToString()
                Else
                    txtKraniNik.Text = String.Empty
                    lblKraniName.Text = String.Empty
                    lblKraniId.Text = String.Empty
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

            dgvDailyTeamActivity.Enabled = False
            btnEditOrUpdate.Enabled = True
            btnReset.Enabled = True
            btnDelete.Enabled = True
            dtpRDate.Enabled = False
            btnGenerateTeam.Enabled = False
            btnSaveAll.Enabled = False
            btnClose.Enabled = False

        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        dgvDailyTeamActivity.Focus()
    End Sub

    Public Sub Reset()
        ' Jum'at, 11 Des 2009, 13:45
        txtTeam.Text = ""
        cmbActivity.Text = ""
        txtMandorNik.Text = ""
        txtKraniNik.Text = ""
        lblMandorName.Text = ""
        lblKraniName.Text = ""
        lblMandorId.Text = ""
        lblKraniId.Text = ""

        dgvDailyTeamActivity.Enabled = True
        btnModifyTeam.Enabled = False
        'dgvDailyTeamActivity.DefaultCellStyle.BackColor = Color.White
        btnEditOrUpdate.Enabled = False
        'cmbActivity.Enabled = False
        btnReset.Enabled = False

        txtMandorNik.Enabled = False
        btnmandorView.Enabled = False

        txtKraniNik.Enabled = False
        btnKraniView.Enabled = False

        dtpRDate.Enabled = True
        btnGenerateTeam.Enabled = True
        btnSaveAll.Enabled = True
        btnClose.Enabled = True

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        Try
            CheckRoll_BOL.DailyActivityTeamBOL.Save(DailyActivityTeamAdapter, DTDailyTeamActivity) 'To save Data

            MsgBox("Data has saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtTeam.Text = ""
            cmbActivity.Text = ""
            txtMandorNik.Text = ""
            txtKraniNik.Text = ""
            dgvDailyTeamActivity.Enabled = True
            btnEditOrUpdate.Enabled = False
            'arrangeview()
            '=========================================
            Dim childCR As New DailyAttendanceWithTeam() 'Jum'at, 18 Sep 2009, 09:39 malam
            childCR.MdiParent = MdiParent
            childCR.Dock = DockStyle.Fill
            childCR.Show()
            Me.Close()
            '========================================
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Data could not be saved, error ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
        End Try

    End Sub

    Private Sub btnmandorView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmandorView.Click
        AttDate = dtpRDate.Value
        'NIKLookUp._Mandor = "M"
        'NIKLookUp.cmbMandorKrani.Text = "Mandor"
        NIKLookUp.Activity = cmbActivity.Text
        NIKLookUp.cmbMandorKrani.Enabled = False
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then

            Me.txtMandorNik.Text = NIKLookUp._lNIK
            Me.lblMandorName.Text = NIKLookUp._lEmpName
            Me.lblMandorId.Text = NIKLookUp._lEmpid
        End If
        AttDate = "12:00:00 AM"
    End Sub

    Private Sub btnKraniView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKraniView.Click
        AttDate = dtpRDate.Value
        NIKLookUp._Mandor = "K"
        NIKLookUp.cmbMandorKrani.Enabled = False
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtKraniNik.Text = NIKLookUp._lNIK
            Me.lblKraniName.Text = NIKLookUp._lEmpName
            Me.lblKraniId.Text = NIKLookUp._lEmpid
        End If
        AttDate = "12:00:00 AM"
    End Sub

    Private Sub dtpRDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRDate.ValueChanged
        DT = CheckRoll_BOL.DailyActivityTeamBOL.DailyAttendanceWithTeamSelect(txtTeam.Text, dtpRDate.Value)
        If DT.Rows.Count > 0 Then
            btnSaveAll.Enabled = False
            lblInfo.Visible = True
            btnModifyTeam.Enabled = False
        ElseIf DT.Rows.Count = 0 Then
            btnSaveAll.Enabled = True
            lblInfo.Visible = False
            btnModifyTeam.Enabled = True
        End If
    End Sub

    Private Sub txtMandor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMandorNik.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtMandorNik.Text = "" Then
                txtMandorNik.Focus()
            ElseIf txtMandorNik.Text <> "" Then
                Dim dt1 As DataTable
                'dt1 = CheckRoll_BOL.DailyActivityTeamBOL.CRDailyAttendanceNikSelect(txtMandorNik.Text, "Y", "Active")

                ' Jum'at, 11 Des 2009, 17:05
                ' soalnya procedure diatas error kurang EmpName nya
                AttDate = dtpRDate.Value
                dt1 = Lookup_DAL.DailyAttendanceNikSelect(txtMandorNik.Text, "", "M", "Active", AttDate)
                ' END Jum'at, 11 Des 2009, 17:05
                If dt1.Rows.Count = 1 Then
                    txtMandorNik.Text = dt1.Rows(0).Item("NIK").ToString() 'dt1.Rows(0).Item("employee code").ToString()
                    lblMandorName.Text = dt1.Rows(0).Item("Name").ToString() 'dt1.Rows(0).Item("Employee name").ToString()
                    lblMandorId.Text = dt1.Rows(0).Item("Employee ID").ToString()
                    txtKraniNik.Focus()
                ElseIf dt1.Rows.Count = 0 Then
                    MsgBox(" Employee Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtMandorNik.Text = ""
                    lblMandorName.Text = ""
                    lblMandorId.Text = ""
                    txtMandorNik.Focus()
                End If

            End If
        End If
        AttDate = "12:00:00 AM"
    End Sub

    Private Sub txtKrani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKraniNik.KeyDown
        If e.KeyCode = Keys.Enter Then
            AttDate = dtpRDate.Value
            If txtKraniNik.Text = "" Then
                txtKraniNik.Focus()
            ElseIf txtKraniNik.Text <> "" Then
                Dim dt1 As DataTable
                dt1 = CheckRoll_BOL.DailyActivityTeamBOL.CRDailyAttendanceNikSelect(txtKraniNik.Text, "K", "Active", "", AttDate)
                If dt1.Rows.Count = 1 Then
                    txtKraniNik.Text = dt1.Rows(0).Item("NIK").ToString()
                    lblKraniName.Text = dt1.Rows(0).Item("Name").ToString()
                    lblKraniId.Text = dt1.Rows(0).Item("Employee ID").ToString()
                    btnEditOrUpdate.Focus()
                ElseIf dt1.Rows.Count = 0 Then
                    MsgBox(" Employee Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtKraniNik.Text = ""
                    lblKraniName.Text = ""
                    lblKraniId.Text = ""
                    txtKraniNik.Focus()
                End If
            End If
            btnEditOrUpdate.Focus()

        End If
        AttDate = "12:00:00 AM"
    End Sub

    Private _Tgl As Date
    Public Property Tgl() As Date
        Get
            Return _Tgl
        End Get
        Set(value As Date)
            _Tgl = value
        End Set
    End Property

    Private Sub btnGenerateTeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateTeam.Click
        GenerateTeam()

        btnSaveAll.Focus()

    End Sub

    Public Sub GenerateTeam()
        Cursor = Cursors.WaitCursor
        Dim DTEMP As DataTable

        DTEMP = CheckRoll_BOL.DailyActivityTeamBOL.DailyTeamActivityAutoInsert(dtpRDate.Value)
        dgvDailyTeamActivity.DataSource = DTEMP
        DTDailyTeamActivity = CheckRoll_BOL.DailyActivityTeamBOL.DailyTeamActivityisExist(dtpRDate.Value)
        dgvDailyTeamActivity.DataSource = DTDailyTeamActivity
        HideColumnDailyTeamActivity()
        Cursor = Cursors.Default
    End Sub


    Private Sub dgvDailyTeamActivity_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyTeamActivity.CellDoubleClick
        If dgvDailyTeamActivity.Rows.Count > 0 Then
            ' By Dadang Adi H
            ' START Jum'at, 11 Des 2009, 13:57
            EditDailyTeamActivity()
            cmbActivity.Focus()
            'btnModifyTeam.Enabled = True
        End If
    End Sub

    Private Sub txtMandorNik_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMandorNik.Leave
        If txtMandorNik.Text.Trim = String.Empty Then
            lblMandorId.Text = String.Empty
            lblMandorName.Text = String.Empty
        Else
            'Jum'at, 11 Des 2009, 17:21        
            Dim DT As DataTable
            'Check Mandor NIK
            AttDate = dtpRDate.Value
            DT = Lookup_DAL.DailyAttendanceNikSelect(txtMandorNik.Text, "", "M", "Active", AttDate)
            If DT.Rows.Count = 1 Then
                lblMandorName.Text = DT.Rows(0).Item("Name").ToString()
                lblMandorId.Text = DT.Rows(0).Item("Employee ID").ToString()

            ElseIf DT.Rows.Count = 0 Then
                lblMandorName.Text = "NIK not valid!"
                lblMandorId.Text = String.Empty
                lblMandorName.Text = String.Empty

            End If
        End If
        AttDate = "12:00:00 AM"

    End Sub

    Private Sub DailyTeamActivity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKraniNik_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKraniNik.Leave
        If txtKraniNik.Text.Trim = String.Empty Then
            lblKraniId.Text = String.Empty
            lblKraniName.Text = String.Empty
        Else
            AttDate = dtpRDate.Value
            Dim DT As DataTable
            ' Check Mandor NIK
            DT = CheckRoll_BOL.DailyActivityTeamBOL.CRDailyAttendanceNikSelect(txtKraniNik.Text, "K", "Active", "", AttDate)
            If DT.Rows.Count = 1 Then
                lblKraniName.Text = DT.Rows(0).Item("Name").ToString()
                lblKraniId.Text = DT.Rows(0).Item("Employee ID").ToString()

            ElseIf DT.Rows.Count = 0 Then
                lblKraniName.Text = "NIK not valid!"
                lblKraniId.Text = String.Empty
                lblKraniName.Text = String.Empty

            End If
        End If

        AttDate = "12:00:00 AM"
    End Sub

    Private Sub btnModifyTeam_Click(sender As System.Object, e As System.EventArgs) Handles btnModifyTeam.Click
        Dim GangMasterID As String = ""
        Dim DailyActivityTeam As String = ""

        If Me.txtTeam.Text = "" Then
            MsgBox("Please, select a record in the Grid!", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        If Not IsDBNull(dgvDailyTeamActivity.SelectedRows(0).Cells("Gang Master Id").Value) Then
            GangMasterID = dgvDailyTeamActivity.SelectedRows(0).Cells("Gang Master Id").Value
        End If
        If Not IsDBNull(dgvDailyTeamActivity.SelectedRows(0).Cells("Daily Team Activity ID").Value) Then
            DailyActivityTeam = dgvDailyTeamActivity.SelectedRows(0).Cells("Daily Team Activity ID").Value
        End If

        If GangMasterID IsNot Nothing And DailyActivityTeam IsNot Nothing Then
            TeamEmployeeSetup.ShowForm(GangMasterID, DailyActivityTeam, dgvDailyTeamActivity.SelectedRows(0).Cells("Date").Value, Tgl, Me)
        Else
            MsgBox("Please, select a record in the Grid!", MsgBoxStyle.Information, "Information")
        End If
    End Sub


    Private Sub cmdPrintPanen_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintPanen.Click
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String

        ReportName = "PrintPanenReport"
        report._Source = ReportName

        report.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrintLain_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintLain.Click
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String

        ReportName = "PrintLainReport"
        report._Source = ReportName

        report.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub cmdPrintDeres_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrintDeres.Click
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String

        ReportName = "PrintDeresReport"
        report._Source = ReportName

        report.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class