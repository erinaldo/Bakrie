Imports Accounts_BOL
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports CheckRoll_PPT
Imports Common_PPT
Imports Accounts_PPT
Imports Common_BOL

Namespace CheckRoll.LookupEdit
    Public Class TeamEmployeeSetup
        Private _gangMasterID As String
        Private _dailyActivityTeamID As String
        Private _dailyDate As String
        Private _TeamEmployee As DataTable
        Public dtaForm As DailyTeamActivity
        Private tglDate As Date
        Public Sub ShowForm(gangMasterID As String, dailyActivityTeamID As String, dailyDate As String, tgl As Date, ByRef dtForm As DailyTeamActivity)
            ResetAll()
            tglDate = tgl
            _gangMasterID = gangMasterID
            _dailyActivityTeamID = dailyActivityTeamID
            _dailyDate = dailyDate
            dgvTeamEmployee.Rows.Clear()
            Dim dt As New DataTable
            dt = DailyActivityTeam_DAL.DailyTeamActivityEditTeam(gangMasterID, dailyActivityTeamID, dailyDate)
            For Each rows As DataRow In dt.Rows
                dgvTeamEmployee.Rows.Add(rows("GangName").ToString(), rows("Category").ToString(), rows("Descp").ToString(), rows("MandorBesar").ToString(), rows("MandorBesarID").ToString(), rows("Mandor").ToString(), rows("MandoreID").ToString(), rows("Krani").ToString(), rows("KraniID").ToString(), rows("EmpName").ToString(), rows("EmpID").ToString(), rows("EmpCode").ToString(), rows("MandorBesarCode").ToString(), rows("MandorCode").ToString(), rows("KraniCode").ToString())
            Next

            Dim dtCategory As New DataTable
            dtCategory = DailyActivityTeam_DAL.GetKeyValuePair()
            With cmbCategory
                .DataSource = dtCategory
                .ValueMember = "ValueName"
                .DisplayMember = "ValueName"
            End With

            _TeamEmployee = New DataTable()
            With _TeamEmployee
                .Columns.Add("TeamName")
                .Columns.Add("Category")
                .Columns.Add("Description")
                .Columns.Add("MandorBesarID")
                .Columns.Add("MandorID")
                .Columns.Add("KraniID")
                .Columns.Add("EmployeeID")
                .Columns.Add("EmpCode")
                .Columns.Add("MandorBesarCode")
                .Columns.Add("MandorCode")
                .Columns.Add("KraniCode")
            End With

            btnAdd.Enabled = False

            SelectOneRows()
            dtaForm = dtForm
            Me.ShowDialog()
        End Sub

        Private Sub SelectOneRows()
            If dgvTeamEmployee.Rows.Count > 0 Then
                With dgvTeamEmployee
                    txtTeamName.Text = .Rows(0).Cells("dgcTeamName").Value
                    cmbCategory.Text = .Rows(0).Cells("dgcCategory").Value
                    txtDescription.Text = .Rows(0).Cells("dgcDescription").Value
                    txtMandorBesar.Text = .Rows(0).Cells("dgcMandorBesarID").Value
                    lblMandorBesar.Text = .Rows(0).Cells("dgcMandorBesar").Value
                    txtMandor.Text = .Rows(0).Cells("dgcMandorID").Value
                    lblMandor.Text = .Rows(0).Cells("dgcMandor").Value
                    txtKrani.Text = .Rows(0).Cells("dgcKraniID").Value
                    lblKrani.Text = .Rows(0).Cells("dgcKrani").Value
                    txtMandorBesarNIK.Text = .Rows(0).Cells("dgcMandorBesarCode").Value
                    txtMandorNik.Text = .Rows(0).Cells("dgcMandorCode").Value
                    txtKeraniNik.Text = .Rows(0).Cells("dgcKraniCode").Value
                End With
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            dtaForm.RefreshAfterModify(tglDate)
            Close()
        End Sub

        Private Sub dgvTeamEmployee_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTeamEmployee.CellDoubleClick
            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcTeamName").Value) Then
                txtTeamName.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcTeamName").Value
            Else
                txtTeamName.Clear()
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcDescription").Value) Then
                txtDescription.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcDescription").Value
            Else
                txtDescription.Clear()
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcCategory").Value) Then
                cmbCategory.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcCategory").Value
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorBesarID").Value) Then
                txtMandorBesar.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorBesarID").Value
                txtMandorBesarNIK.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorBesarCode").Value
            Else
                txtMandorBesar.Clear()
                txtMandorBesarNIK.Clear()
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorBesar").Value) Then
                lblMandorBesar.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorBesar").Value
            Else
                lblMandor.Text = String.Empty
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorID").Value) Then
                txtMandor.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorID").Value
                txtMandorNik.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcMandorCode").Value
            Else
                txtMandor.Clear()
                txtMandorNik.Clear()
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcMandor").Value) Then
                lblMandor.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcMandor").Value
            Else
                lblMandor.Text = String.Empty
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcKraniID").Value) Then
                txtKrani.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcKraniID").Value
                txtKeraniNik.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcKraniCode").Value
            Else
                txtKrani.Clear()
                txtKeraniNik.Clear()
            End If

            If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcKrani").Value) Then
                lblKrani.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcKrani").Value
            Else
                lblKrani.Text = String.Empty
            End If

            'If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcEmployeeID").Value) Then
            '    txtEmployee.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcEmployeeID").Value
            'Else
            '    txtEmployee.Clear()
            'End If

            'If Not IsDBNull(dgvTeamEmployee.SelectedRows(0).Cells("dgcEmployee").Value) Then
            '    lblEmployee.Text = dgvTeamEmployee.SelectedRows(0).Cells("dgcEmployee").Value
            'Else
            '    lblEmployee.Text = String.Empty
            'End If

            BtnDelete.Enabled = True

        End Sub

        Private Sub BtnMandorBesar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMandorBesar.Click
            Dim NIKEmployee As New NIKLookUp
            NIKEmployee.JobsDesc = 2
            NIKEmployee.AttDate = DateTime.Now
            NIKEmployee.ShowDialog()
            If NIKEmployee.DialogResult = Windows.Forms.DialogResult.OK Then
                txtMandorBesar.Text = NIKEmployee._lEmpid
                lblMandorBesar.Text = NIKEmployee._lEmpName
                txtMandorBesarNIK.Text = NIKEmployee._lNIK
            End If
        End Sub

        Private Sub BtnMandor_Click(sender As Object, e As System.EventArgs) Handles BtnMandor.Click
            Dim NIKEmployee As New NIKLookUp
            NIKEmployee.JobsDesc = 3
            NIKEmployee.AttDate = DateTime.Now
            NIKEmployee.ShowDialog()
            If NIKEmployee.DialogResult = Windows.Forms.DialogResult.OK Then
                txtMandor.Text = NIKEmployee._lEmpid
                lblMandor.Text = NIKEmployee._lEmpName
                txtMandorNik.Text = NIKEmployee._lNIK

            End If
        End Sub

        Private Sub BtnKrani_Click(sender As Object, e As System.EventArgs) Handles BtnKrani.Click
            Dim NIKEmployee As New NIKLookUp
            NIKEmployee.JobsDesc = 7
            NIKEmployee.AttDate = DateTime.Now
            NIKEmployee.ShowDialog()
            If NIKEmployee.DialogResult = Windows.Forms.DialogResult.OK Then
                txtKrani.Text = NIKEmployee._lEmpid
                lblKrani.Text = NIKEmployee._lEmpName
                txtKeraniNik.Text = NIKEmployee._lNIK
            End If
        End Sub

        Private Sub BtnEmployee_Click(sender As Object, e As System.EventArgs) Handles BtnEmployee.Click
            Dim NIKEmployee As New NIKLookUp
            NIKEmployee.JobsDesc = String.Empty
            NIKEmployee.AttDate = DateTime.Now
            NIKEmployee.ShowDialog()
            If NIKEmployee.DialogResult = Windows.Forms.DialogResult.OK Then
                txtEmployee.Text = NIKEmployee._lEmpid
                lblEmployee.Text = NIKEmployee._lEmpName
                txtEmployeeCode.Text = NIKEmployee._lNIK
                If Not String.IsNullOrEmpty(txtEmployee.Text) Then
                    btnAdd.Enabled = True
                End If
            End If
        End Sub


        Private Sub ResetAll()
            BtnDelete.Enabled = False
            txtTeamName.Clear()
            txtDescription.Clear()
            txtMandorBesar.Clear()
            lblMandorBesar.Text = String.Empty
            txtMandor.Clear()
            lblMandor.Text = String.Empty
            txtKrani.Clear()
            lblKrani.Text = String.Empty
            txtEmployee.Clear()
            lblEmployee.Text = String.Empty
            txtEmployeeCode.Clear()
            txtMandorBesarNIK.Clear()
            txtMandorNik.Clear()
            txtKeraniNik.Clear()
            SelectOneRows()
        End Sub

        Private Sub BtnReset_Click(sender As System.Object, e As System.EventArgs) Handles BtnReset.Click
            ResetAll()
        End Sub

        Private Sub BtnUpdateHeader_Click(sender As System.Object, e As System.EventArgs) Handles BtnUpdateHeader.Click
            Dim objBOL As New TeamEmployeeSetup_BOL
            Dim objPPT As New TeamEmployeeSetup_PPT
            With objPPT
                .MandorBesarID = txtMandorBesar.Text
                .MandorID = txtMandor.Text
                .KraniID = txtKrani.Text
                .DailyDate = _dailyDate
                .GangMasterID = _gangMasterID
            End With

            If objBOL.TeamHeaderUpdate(objPPT) Then
                MsgBox("Team Succesfull Saved !", MsgBoxStyle.Information, "Information")
            End If

            _TeamEmployee.Rows.Clear()
            dgvTeamEmployee.Rows.Clear()
            Dim dt As New DataTable
            dt = DailyActivityTeam_DAL.DailyTeamActivityEditTeam(_gangMasterID, _dailyActivityTeamID, _dailyDate)
            For Each rows As DataRow In dt.Rows
                dgvTeamEmployee.Rows.Add(rows("GangName").ToString(), rows("Category").ToString(), rows("Descp").ToString(), rows("MandorBesar").ToString(), rows("MandorBesarID").ToString(), rows("Mandor").ToString(), rows("MandoreID").ToString(), rows("Krani").ToString(), rows("KraniID").ToString(), rows("EmpName").ToString(), rows("EmpID").ToString(), rows("EmpCode").ToString(), rows("MandorBesarCode").ToString(), rows("MandorCode").ToString(), rows("KraniCode").ToString())
            Next
        End Sub

        Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
            If Not String.IsNullOrEmpty(txtEmployee.Text) Then
                If CheckExistEmployee() = False Then
                    Dim NewRow As DataRow
                    NewRow = _TeamEmployee.NewRow()
                    With NewRow
                        .Item("TeamName") = txtTeamName.Text
                        .Item("Category") = cmbCategory.Text
                        .Item("Description") = txtDescription.Text
                        .Item("MandorBesarID") = txtMandorBesar.Text
                        .Item("MandorID") = txtMandor.Text
                        .Item("KraniID") = txtKrani.Text
                        .Item("EmployeeID") = txtEmployee.Text
                        .Item("EmpCode") = txtEmployeeCode.Text
                        .Item("MandorBesarCode") = txtMandorBesarNIK.Text
                        .Item("MandorCode") = txtMandorNik.Text
                        .Item("KraniCode") = txtKeraniNik.Text
                    End With
                    _TeamEmployee.Rows.Add(NewRow)
                    dgvTeamEmployee.Rows.Add(txtTeamName.Text, cmbCategory.Text, txtDescription.Text, lblMandorBesar.Text, txtMandorBesar.Text, lblMandor.Text, txtMandor.Text, lblKrani.Text, txtKrani.Text, lblEmployee.Text, txtEmployee.Text, txtEmployeeCode.Text, txtMandorBesarNIK.Text, txtMandorNik.Text, txtKeraniNik.Text)
                    txtEmployee.Clear()
                    txtEmployeeCode.Clear()
                    lblEmployee.Text = "."
                End If
            Else
                MsgBox("Choose One Employee!")
            End If
        End Sub

        Private Function CheckExistEmployee() As Boolean

            Dim objBOL As New TeamEmployeeSetup_BOL
            Dim dt As New DataTable

            dt = objBOL.EmployeeIsExistDailyAttendance(txtEmployee.Text)
            If (dt.Rows.Count > 0) Then
                MsgBox("Current Employee already exist in Daily Attendance!", MsgBoxStyle.Information, "Information")
                Return True
            End If

            For i As Integer = 0 To dgvTeamEmployee.RowCount - 1
                With dgvTeamEmployee
                    If .Rows(i).Cells("dgcEmployeeID").Value = txtEmployee.Text Then
                        MsgBox("Current Employee already exist in this Team!", MsgBoxStyle.Information, "Information")
                        Return True
                    End If
                End With
            Next
            Return False
        End Function


        Private Sub BtnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles BtnSaveAll.Click
            Dim objBOL As New TeamEmployeeSetup_BOL
            Dim result As Boolean
            For i As Integer = 0 To _TeamEmployee.Rows.Count - 1
                Dim objPPT As New TeamEmployeeSetup_PPT
                With objPPT
                    .DailyDate = _dailyDate
                    .DailyTeamActivityID = _dailyActivityTeamID
                    .EmpID = _TeamEmployee.Rows(i).Item("EmployeeID").ToString()
                    .GangMasterID = _gangMasterID
                    .KraniID = _TeamEmployee.Rows(i).Item("KraniID").ToString()
                    .MandorBesarID = _TeamEmployee.Rows(i).Item("MandorBesarID").ToString()
                    .MandorID = _TeamEmployee.Rows(i).Item("MandorID").ToString()
                End With
                result = objBOL.TeamEmployeeModifySave(objPPT)
            Next
            If result Then
                MsgBox("Team Succesfull Saved !", MsgBoxStyle.Information, "Information")
            End If

            'Update daily Team Activity Form
            dtaForm.lblMandorId.Text = txtMandor.Text
            dtaForm.lblKraniId.Text = txtKrani.Text
            dtaForm.txtMandorNik.Text = txtMandorNik.Text
            dtaForm.txtKraniNik.Text = txtKeraniNik.Text
            dtaForm.lblMandorName.Text = lblMandor.Text
            dtaForm.lblKraniName.Text = lblKrani.Text

            ResetAll()
            _TeamEmployee.Rows.Clear()
        End Sub

        Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click

        End Sub
    End Class
End Namespace