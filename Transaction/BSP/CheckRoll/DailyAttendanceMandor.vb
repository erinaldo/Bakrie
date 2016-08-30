Imports CheckRoll_BOL
Imports CheckRoll_PPT
Imports Common_PPT
Imports CheckRoll_DAL
Imports Store_PPT
Imports Store_BOL

Public Class DailyAttendanceMandor


    Private dtMandor As New DataTable
    Private dtAttCode As New DataTable
    Private dtView As New DataTable
    Private dtDetail As New DataTable

    Private Sub BtnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerate.Click
        Dim objMandorBOL As New DailyAttendanceMandor_BOL
        Dim attcode As String = ""
        Dim attID As String = ""

        dtMandor = objMandorBOL.DailyAttendanceMandorGenerate(Me.DtpRDate.Value)
        dtAttCode = objMandorBOL.AttendanceSetupSelect()

        For Each dtatt As DataRow In dtAttCode.Rows
            attcode = dtatt("AttendanceCode").ToString()
            attID = dtatt("AttendanceSetupID").ToString()
        Next

        If dtMandor.Rows.Count > 0 Then
            dgvDailyAttendanceMandor.Rows.Clear()
            If dtAttCode.Rows.Count > 0 Then
                For Each rowsEmp In dtMandor.Rows
                    dgvDailyAttendanceMandor.Rows.Add(DtpRDate.Value.ToString("MM/dd/yyy"), rowsEmp("EmpCode").ToString(), rowsEmp("EmpName").ToString(), rowsEmp("Description").ToString(), attcode, attID, 0, 0, rowsEmp("EmpId").ToString(), "", "", "")
                Next
            Else
                For Each rowsEmp In dtMandor.Rows
                    dgvDailyAttendanceMandor.Rows.Add(DtpRDate.Value.ToString("MM/dd/yyy"), rowsEmp("EmpCode").ToString(), rowsEmp("EmpName").ToString(), rowsEmp("Description").ToString(), "11", "02R94", 0, 0, rowsEmp("EmpId").ToString(), "", "", "")
                Next
            End If

        Else
            dgvDailyAttendanceMandor.Rows.Clear()
            MessageBox.Show("Employee does not exist!", "Warning", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub dgvDailyAttendanceMandor_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyAttendanceMandor.CellDoubleClick
        TxtNIK.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcNIK").Value
        TxtAttCode.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcAttCode").Value
        TxtNama.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcNama").Value
        lblAttendanceSetupID.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcAttendanceSetupID").Value
        txtDailyOt.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcDailyOT").Value
        LblDescription.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcDescription").Value
        txtProduksiPemanen.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcKraniPremiKg").Value
        If Not IsDBNull(dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcFieldNo").Value) And dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcFieldNo").Value <> "" Then
            txtBlock.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcFieldNo").Value
            GetTPHDetails()
            ' cmbTphNormal.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcTph").Value
            lblBlockValue.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcBlockId").Value
            cmbTphNormal.Text = dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcTph").Value
        Else
            txtBlock.Text = ""
            txtBlock.Text = ""
            cmbTphNormal.Text = ""
        End If
        btnAttendanceSetupLookup.Enabled = True
        btnEditOrUpdate.Enabled = True
    End Sub

    Private Sub btnAttendanceSetupLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnAttendanceSetupLookup.Click
        Dim AttendanceLookupForm As New AttendanceLookup()

        If AttendanceLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TxtAttCode.Text = AttendanceLookupForm._AttCode
            lblAttendanceSetupID.Text = AttendanceLookupForm._AttSetupId
        End If

    End Sub

    Private Sub btnEditOrUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnEditOrUpdate.Click
        If dgvDailyAttendanceMandor.SelectedRows IsNot Nothing And dgvDailyAttendanceMandor.Rows.Count <> 0 Then
            dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcAttCode").Value = TxtAttCode.Text
            dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcAttendanceSetupID").Value = lblAttendanceSetupID.Text
            dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcDailyOT").Value = txtDailyOt.Text
            dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcKraniPremiKg").Value = txtProduksiPemanen.Text
            If Me.lblBlockValue.Text <> "" Then
                dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcFieldNo").Value = txtBlock.Text
                dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcTph").Value = cmbTphNormal.Text
                dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcBlockId").Value = lblBlockValue.Text
            Else
                dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcFieldNo").Value = ""
                dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcTph").Value = ""
                dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcBlockId").Value = ""
            End If
            
            'dgvDailyAttendanceMandor.SelectedRows(0).Cells("dgcTphID").Value = cmbTphNormal.SelectedValue
        End If
        ClearDefault()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ClearDefault()
    End Sub

    Private Sub OnLoadForm()
        dtpFilterDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpFilterDate.MaxDate = GlobalPPT.FiscalYearToDate
        DtpRDate.MinDate = GlobalPPT.FiscalYearFromDate
        DtpRDate.MaxDate = GlobalPPT.FiscalYearToDate
        dgvDailyAttendanceMandor.Rows.Clear()
        TabContainer.SelectedTab = TabView
        MandorView(DtpRDate.Value)
    End Sub

    Private Sub MandorView(dates As String)
        Dim objMandorBOL As New DailyAttendanceMandor_BOL

        dtView = objMandorBOL.DailyAttendanceMandorViewSelect(dates)
        dgvDailyAttendenceMandorView.DataSource = dtView
    End Sub


    Sub ClearDefault()
        btnAttendanceSetupLookup.Enabled = False
        btnEditOrUpdate.Enabled = False
        TxtAttCode.Clear()
        TxtNIK.Clear()
        txtDailyOt.Clear()
        TxtNama.Clear()
        LblDescription.Text = "..."
        lblAttendanceSetupID.Text = String.Empty
        Me.txtProduksiPemanen.Text = "0"
        Me.txtBlock.Text = ""
        Me.lblBlockValue.Text = ""
        '  Me.cmbTphNormal.Text = ""
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        Dim objMandorBOL As New DailyAttendanceMandor_BOL
        Dim objMandorPPT As New DailyAttendanceMandor_PPT
        Dim result As Boolean
        objMandorBOL.DailyAttendanceMandorBeforeInsert(DtpRDate.Value.ToString("yyy-MM-dd"))
        For Each objDetail In dgvDailyAttendanceMandor.Rows
            With objMandorPPT
                .RDate = DtpRDate.Value
                .NIK = objDetail.Cells("dgcEmpId").value.ToString()
                .AttID = objDetail.Cells("dgcAttendanceSetupID").value.ToString()
                .DailyOT = objDetail.Cells("dgcDailyOT").value
                .KraniPremiKg = objDetail.Cells("dgcKraniPremiKg").value
                .FieldNo = objDetail.cells("dgcBlockId").value.ToString
                .TPHNo = objDetail.cells("dgcTPH").value.ToString
            End With

            result = objMandorBOL.DailyAttendanceMandorInsert(objMandorPPT)
        Next

        If result Then
            MessageBox.Show("Data Succesfully Saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Data Failed Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ClearDefault()
        OnLoadForm()
    End Sub

    Private Sub DailyAttendanceMandor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        OnLoadForm()
    End Sub

    Private Sub btnResetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnResetAll.Click
        dgvDailyAttendanceMandor.Rows.Clear()
        ClearDefault()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        MandorView(dtpFilterDate.Value.ToString("yyy-MM-dd"))
    End Sub

    Private Sub dgvDailyAttendenceMandorView_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyAttendenceMandorView.CellContentDoubleClick
        dgvDailyAttendanceMandor.Rows.Clear()
        If dgvDailyAttendenceMandorView.SelectedRows.Count > 0 Then
            Dim dailyAttendanceMandorBol As New DailyAttendanceMandor_BOL
            dtDetail = dailyAttendanceMandorBol.DailyAttendanceMandorDetailSelect(dgvDailyAttendenceMandorView.SelectedRows(0).Cells("dgcDate").Value)
            For Each rowsEmp In dtDetail.Rows
                Dim tgl As DateTime
                tgl = Convert.ToDateTime(rowsEmp("RDate").ToString())
                dgvDailyAttendanceMandor.Rows.Add(tgl.ToString("dd/MM/yyy"), rowsEmp("EmpCode").ToString(), rowsEmp("EmpName").ToString(), rowsEmp("Description").ToString(), rowsEmp("AttendanceCode").ToString(), rowsEmp("AttendanceSetupID").ToString(), rowsEmp("DailyOt").ToString(), rowsEmp("KraniPremiKg").ToString(), rowsEmp("EmpId").ToString(), rowsEmp("BlockName").ToString, rowsEmp("TPH").ToString, rowsEmp("BlockID").ToString)
            Next
            DtpRDate.Value = dgvDailyAttendenceMandorView.SelectedRows(0).Cells("dgcDate").Value
            TabContainer.SelectedTab = TabEntry
        End If
    End Sub

    Private Sub TabView_Click(sender As Object, e As System.EventArgs) Handles TabView.Click
        MandorView(Nothing)
    End Sub

    Private Sub btnNikLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnNikLookup.Click
        Dim SubBlockLookupForm As VHMasterSubBlockLookup = New VHMasterSubBlockLookup()
        SubBlockLookupForm.cropID = "CropIDRubber"
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtBlock.Text = SubBlockLookupForm.psBlockId
            lblBlockValue.Text = SubBlockLookupForm.psBlockName
            'txtAfdeling.Text = SubBlockLookupForm.psDIVID
            'lblAfdeling.Text = SubBlockLookupForm.psDIVName
            'txtYOP.Text = SubBlockLookupForm.psYopID
            'lblYOP.Text = SubBlockLookupForm.psYopName

        End If
    End Sub

    Private Sub cmbTphNormal_Click(sender As System.Object, e As System.EventArgs) Handles cmbTphNormal.Click


        If txtBlock.Text <> String.Empty Then
            GetTPHDetails()
        Else
            MsgBox("Please select Field No first")
        End If
    End Sub
    Private Sub GetTPHDetails()
        Dim dsLoadTPH As DataTable
        dsLoadTPH = DailyReceiptionWithTeam_DAL.loadTPH(txtBlock.Text)
        Dim dr As DataRow
        dr = dsLoadTPH.NewRow()
        dr("id") = 0
        dr("TPH") = "- Select TPH -"
        dsLoadTPH.Rows.InsertAt(dr, 0)

        cmbTphNormal.DataSource = dsLoadTPH
        cmbTphNormal.DisplayMember = "TPH"
        cmbTphNormal.ValueMember = "id"
        cmbTphNormal.SelectedIndex = 0
    End Sub
    Private Sub GetFieldNo()
        Dim objBlockPPt As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objBlockPPt.Div = ""
        objBlockPPt.YOP = ""
        objBlockPPt.BlockName = txtBlock.Text.Trim()
        ds = StoreIssueVoucherBOL.GetSubBlock(objBlockPPt, "YES")
        If ds.Tables(0).Rows.Count > 0 Then
            lblBlockValue.Text = ds.Tables(0).Rows(0).Item("BlockName").ToString()
            Me.cmbTphNormal.Text = ""
            'txtAfdeling.Text = ds.Tables(0).Rows(0).Item("DivID").ToString()
            'lblAfdeling.Text = ds.Tables(0).Rows(0).Item("DivName").ToString()
            'txtYOP.Text = ds.Tables(0).Rows(0).Item("YOPID").ToString()
            'lblYOP.Text = ds.Tables(0).Rows(0).Item("Name").ToString()
        Else
            MsgBox("No Records Found")
            lblBlockValue.Text = ""
            Me.cmbTphNormal.Text = ""
            'txtAfdeling.Clear()
            'lblAfdeling.Text = ""
            'txtYOP.Clear()
            'lblYOP.Text = ""
        End If
    End Sub

    Private Sub txtBlock_Validated(sender As System.Object, e As System.EventArgs) Handles txtBlock.Validated

        If Me.txtBlock.Text <> "" Then
            GetFieldNo()
        Else
            Me.lblBlockValue.Text = ""
            Me.cmbTphNormal.Text = ""
        End If
        cmbTphNormal.Focus()

    End Sub
End Class