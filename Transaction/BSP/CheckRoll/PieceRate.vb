Imports CheckRoll_PPT
Imports CheckRoll_BOL

Public Class PieceRate

    Private Sub btnPieceRateRefLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnPieceRateRefLookup.Click
        'Dim pieceRateLookup As New PieceRateActivityLookup
        PieceRateActivityLookup._Date = dtpDate.Value
        PieceRateActivityLookup.ShowDialog()

        If PieceRateActivityLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            ClearAll()

            txtActivityId.Text = PieceRateActivityLookup._PieceRateActivity_PPT.Id
            txtJobDescription.Text = PieceRateActivityLookup._PieceRateActivity_PPT.Description
            txtUnit.Text = PieceRateActivityLookup._PieceRateActivity_PPT.Unit
            txtBlockName.Text = PieceRateActivityLookup._PieceRateActivity_PPT.BlockName
            txtTotalUnit.Text = PieceRateActivityLookup._PieceRateActivity_PPT.TotalUnit
            txtMandorRate.Text = PieceRateActivityLookup._PieceRateActivity_PPT.MandoreRate
            txtJobRate.Text = PieceRateActivityLookup._PieceRateActivity_PPT.JobRate
            txtPieceRateRefNo.Text = PieceRateActivityLookup._PieceRateActivity_PPT.ReferenceNo
            txtStation.Text = PieceRateActivityLookup._PieceRateActivity_PPT.StationDesc

            If PieceRateActivityLookup._PieceRateActivity_PPT.ActivityBy = "O" Then
                LoadEmployeesContractors(True, PieceRateActivityLookup._PieceRateActivity_PPT.Id)
            Else
                'load contractors
                LoadEmployeesContractors(False, PieceRateActivityLookup._PieceRateActivity_PPT.Id)
            End If

            CalculateBlanceUnits(PieceRateActivityLookup._PieceRateActivity_PPT.Id, True)

        End If
    End Sub


    Sub CalculateBlanceUnits(ByVal ActivityId As Integer, ByVal ShowData As Boolean)
        'get existing transaction for the selected activity
        Dim paBOL As PieceRateTransaction_BOL = New PieceRateTransaction_BOL
        Dim dtTransaction As DataTable = paBOL.PieceRateTransaction_Select(Nothing, ActivityId)

        If ShowData Then
            dgvPRTransactions.DataSource = dtTransaction
        End If
        If dtTransaction.Rows.Count > 0 Then
            Dim unitCompleted As Object = dtTransaction.Compute("Sum(UnitCompleted)", "PieceRateActivityId=" + ActivityId.ToString() + "")
            If IsNumeric(unitCompleted) Then
                txtBalanceUnit.Text = (PieceRateActivityLookup._PieceRateActivity_PPT.TotalUnit - Convert.ToDouble(unitCompleted)).ToString()
            End If

        Else
            'no work has been completed
            txtBalanceUnit.Text = txtTotalUnit.Text
        End If
    End Sub

    Sub LoadEmployeesContractors(ByVal IsEmployee As Boolean, ByVal Id As Integer)
        Dim paBOL As PieceRateTransaction_BOL = New PieceRateTransaction_BOL
        If IsEmployee Then
            gbEmployee.Enabled = True
            gbContractor.Enabled = False

            'load empoyees
            Dim dtEmp As DataTable = paBOL.PieceRateEmployee_Select(Id)
            cmbEmployee.DataSource = dtEmp
            cmbEmployee.DisplayMember = "EmpName"
            cmbEmployee.ValueMember = "EmpID"

            Dim dtMandor As DataTable = dtEmp.Copy()
            cmbMandor.DataSource = dtMandor
            cmbMandor.DisplayMember = "EmpName"
            cmbMandor.ValueMember = "EmpID"
        Else
            gbEmployee.Enabled = False
            gbContractor.Enabled = True

            'load contractors
            Dim dtCont As DataTable = paBOL.PieceRateContractor_Select(Id)
            cmbContractor.DataSource = dtCont
            cmbContractor.DisplayMember = "ContractName"
            cmbContractor.ValueMember = "ContractID"
        End If
    End Sub

    Sub ClearAll()
        lblTransactionId.Text = "0"
        'txtActivityId.Text = "0"
        txtJobDescription.Text = ""
        txtUnit.Text = ""
        txtBlockName.Text = ""
        txtTotalUnit.Text = ""
        txtMandorRate.Text = ""
        txtJobRate.Text = ""
        txtPieceRateRefNo.Text = ""
        gbEmployee.Enabled = False
        gbContractor.Enabled = False
        txtVehicleNo.Text = ""
        txtSubStationID.Text = ""
        txtUnitCompleted.Text = ""
        cmbContractor.DataSource = Nothing
        cmbEmployee.DataSource = Nothing
        cmbMandor.DataSource = Nothing
        cmbContractor.Items.Clear()
        cmbEmployee.Items.Clear()
        cmbMandor.Items.Clear()
        txtRemarks.Text = ""
        txtBalanceUnit.Text = ""
        btnSave.Text = "Save"
        btnDelete.Enabled = False
    End Sub


    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ClearAll()
    End Sub

    Private Sub btnVehicleLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnVehicleLookup.Click
        'VehicleLookup.ShowDialog()

        'If VehicleLookup.DialogResult = Windows.Forms.DialogResult.OK Then
        '    txtVehicleNo.Text = VehicleLookup._VehicleCode
        '    lblVHID.Text = VehicleLookup._VehicleID
        'End If
        Dim objIPRNo As New VHNoLookup()
        Dim result As DialogResult = objIPRNo.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            txtVehicleNo.Text = objIPRNo.psVHWSCode
            lblVHID.Text = objIPRNo.psVHID
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        'save or update transactions
        If IsValidateTransaction() Then

            Dim prt_PPT As New PieceRateTransaction_PPT
            If Not lblTransactionId.Text = "0" Then
                prt_PPT.Id = lblTransactionId.Text
            End If
            prt_PPT.PieceRateActivityId = txtActivityId.Text
            prt_PPT.ActivityDate = dtpDate.Value
            prt_PPT.VHID = lblVHID.Text
            prt_PPT.SubStationID = txtSubStationID.Text
            prt_PPT.UnitCompleted = txtUnitCompleted.Text
            prt_PPT.Remarks = txtRemarks.Text
            prt_PPT.Production = txtProduction.Text

            If gbEmployee.Enabled = True Then
                prt_PPT.EmpID = cmbEmployee.SelectedValue
            ElseIf gbContractor.Enabled = True Then
                prt_PPT.ContractID = cmbContractor.SelectedValue
            End If

            Dim prt_BOL As New PieceRateTransaction_BOL
            prt_BOL.PieceRateTransaction_Update(prt_PPT)

            ShowTransactions()
            ClearAll()
        End If
    End Sub

    Sub ShowTransactions()
        If Not txtActivityId.Text = "0" Then
            Dim prt_BOL As New PieceRateTransaction_BOL
            Dim dt As DataTable = prt_BOL.PieceRateTransaction_Select(Nothing, txtActivityId.Text)
            dgvPRTransactions.DataSource = dt
        End If
    End Sub

    Function IsValidateTransaction() As Boolean
        Dim msg As String = String.Empty
        If gbEmployee.Enabled = True Then
            If cmbEmployee.SelectedValue = Nothing Then
                msg = "Choose an Employee"
            End If
        ElseIf gbContractor.Enabled = True Then
            If cmbContractor.SelectedValue = Nothing Then
                msg = "Choose a Contractor"
            End If
        End If

        If IsNumeric(txtUnitCompleted.Text) Then
            Dim completed As Double = Convert.ToDouble(txtUnitCompleted.Text)
            Dim balance As Double = Convert.ToDouble(txtBalanceUnit.Text)
            If completed > balance Then
                msg = "Total Completed units cannot be greater than balance unit"
            End If
        Else
            'not numeric
            msg = "Total Completed units should be numeric"
        End If

        If Not IsNumeric(txtProduction.Text) Then
            msg = "Production should be numeric"
        End If

        If msg = String.Empty Then
            Return True
        Else
            MessageBox.Show(msg, "Information is incompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

    Private Sub dgvPRTransactions_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dgvPRTransactions.DoubleClick
        If dgvPRTransactions.SelectedRows.Count > 0 Then
            Dim PieceRateActivityId As String = dgvPRTransactions.SelectedRows(0).Cells("PieceRateActivityId").Value()
            Dim TransactionId As String = dgvPRTransactions.SelectedRows(0).Cells("colId").Value()
            Dim prt_BOL As New PieceRateTransaction_BOL
            Dim pra_PPT As New PieceRateActivity_PPT
            pra_PPT.Id = PieceRateActivityId
            Dim drPieceRateActivity As DataTableReader = New DataTableReader(prt_BOL.PieceRateActivity_Select(pra_PPT))
            lblTransactionId.Text = TransactionId ' Transaction ID
            If drPieceRateActivity.Read() Then

                txtActivityId.Text = drPieceRateActivity("Id") ' ActivityID
                txtJobDescription.Text = drPieceRateActivity("Description")
                txtUnit.Text = drPieceRateActivity("Unit")
                txtBlockName.Text = drPieceRateActivity("BlockName")
                txtTotalUnit.Text = drPieceRateActivity("TotalUnit")
                txtMandorRate.Text = drPieceRateActivity("MandoreRate")
                txtJobRate.Text = drPieceRateActivity("JobRate")
                txtPieceRateRefNo.Text = drPieceRateActivity("ReferenceNo")

                With dgvPRTransactions.SelectedRows(0)
                    dtpDate.Value = .Cells("colDate").Value()
                    txtUnitCompleted.Text = .Cells("UnitCompleted").Value()
                    If Not .Cells("VHID").Value() Is DBNull.Value Then
                        txtVehicleNo.Text = .Cells("VHWSCode").Value()
                        lblVHID.Text = .Cells("VHID").Value()
                    End If
                    If Not .Cells("Remarks").Value() Is DBNull.Value Then
                        txtRemarks.Text = .Cells("Remarks").Value()
                    End If
                End With

                'update completed units
                CalculateBlanceUnits(Convert.ToInt32(drPieceRateActivity("Id")), False)
                Dim completedUnits As Double = Convert.ToDouble(txtUnitCompleted.Text)
                Dim balanceUnits As Double = Convert.ToDouble(txtBalanceUnit.Text)
                txtBalanceUnit.Text = (balanceUnits - completedUnits).ToString()

                btnSave.Text = "Update"


                If drPieceRateActivity("ActivityBy") = "O" Then
                    LoadEmployeesContractors(True, txtActivityId.Text)
                    cmbEmployee.SelectedValue = dgvPRTransactions.SelectedRows(0).Cells("EmpID").Value()
                Else
                    LoadEmployeesContractors(False, txtActivityId.Text)
                    cmbContractor.SelectedValue = dgvPRTransactions.SelectedRows(0).Cells("ContractID").Value()
                End If

            End If
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub Delete()
        If MessageBox.Show("Are you sure you want to delete the selected transaction?", "Delete the transaction?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim prt_BOL As New PieceRateTransaction_BOL
            prt_BOL.PieceRateTransaction_Delete(lblTransactionId.Text)

            ShowTransactions()
            ClearAll()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        'delete transaction
        Delete()
    End Sub

    Private Sub MSDelete_Click(sender As System.Object, e As System.EventArgs) Handles MSDelete.Click
        Delete()
    End Sub

    Private Sub dgvPRTransactions_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvPRTransactions.MouseClick
        If e.Button = MouseButtons.Right Then
            If dgvPRTransactions.SelectedRows.Count > 0 Then
                dgvPRTransactions.ContextMenuStrip = CMDelete
            Else
                dgvPRTransactions.ContextMenuStrip = Nothing
            End If
        End If

        If dgvPRTransactions.SelectedRows.Count > 0 Then
            If Not IsDBNull(dgvPRTransactions.SelectedRows(0).Cells("colId")) Then
                Dim TransactionId As String = dgvPRTransactions.SelectedRows(0).Cells("colId").Value()
                lblTransactionId.Text = TransactionId
            End If
        End If
            
    End Sub
End Class