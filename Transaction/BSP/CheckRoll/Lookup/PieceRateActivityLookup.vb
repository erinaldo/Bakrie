Imports CheckRoll_BOL
Imports CheckRoll_PPT

Public Class PieceRateActivityLookup

    Public _PieceRateActivity_PPT As New PieceRateActivity_PPT
    Public _Date As Date

    Private Sub PieceRateActivityLookup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not _Date = Nothing Then
            dtpDate.Value = _Date
            dtpDate.Enabled = False
        End If

        LoadPieceRate()
    End Sub

    Sub LoadPieceRate()
        Dim pieceRateActBOL As New PieceRateTransaction_BOL
        Dim dtPieceRate As DataTable = pieceRateActBOL.PieceRate_Select(Nothing)
        cmbActivityRefNo.DataSource = dtPieceRate
        cmbActivityRefNo.DisplayMember = "ReferenceNo"
        cmbActivityRefNo.ValueMember = "ReferenceNo"
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub PieceRateActivityLookup_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim pieceRateAct As New PieceRateActivity_PPT
        If txtActivityDescription.Text.Length > 0 Then
            pieceRateAct.Description = txtActivityDescription.Text
            pieceRateAct.StartDate = dtpDate.Value
        ElseIf cmbActivityRefNo.SelectedValue <> Nothing Then
            pieceRateAct.ReferenceNo = cmbActivityRefNo.SelectedValue
        Else
            MessageBox.Show("Please enter value to search", "Missing Search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim pieceRateActBOL As New PieceRateTransaction_BOL
        Dim dtPieceRate As DataTable = pieceRateActBOL.PieceRateActivity_Select(pieceRateAct)
        dgvPieceRate.DataSource = dtPieceRate


    End Sub

    Private Sub dgvPieceRate_DoubleClick(sender As System.Object, e As System.EventArgs) Handles dgvPieceRate.DoubleClick
        If dgvPieceRate.SelectedRows.Count > 0 Then
            GetSelectedRecord()
        End If
    End Sub

    Private Sub dgvPieceRate_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvPieceRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvPieceRate.SelectedRows.Count > 0 Then
                GetSelectedRecord()
            End If
        End If
    End Sub

    Sub GetSelectedRecord()
        _PieceRateActivity_PPT.Id = dgvPieceRate.SelectedRows(0).Cells("colId").Value
        _PieceRateActivity_PPT.ReferenceNo = dgvPieceRate.SelectedRows(0).Cells("colRefNo").Value
        _PieceRateActivity_PPT.Description = dgvPieceRate.SelectedRows(0).Cells("colDescription").Value
        If Not IsDBNull(dgvPieceRate.SelectedRows(0).Cells("colBlockName").Value) Then
            _PieceRateActivity_PPT.BlockName = dgvPieceRate.SelectedRows(0).Cells("colBlockName").Value
        End If
        If Not IsDBNull(dgvPieceRate.SelectedRows(0).Cells("StationDescp").Value) Then
            _PieceRateActivity_PPT.StationDesc = dgvPieceRate.SelectedRows(0).Cells("StationDescp").Value
        End If
        _PieceRateActivity_PPT.Unit = dgvPieceRate.SelectedRows(0).Cells("UOM").Value
        '_PieceRateActivity_PPT.Unit = dgvPieceRate.SelectedRows(0).Cells("colUnit").Value
        _PieceRateActivity_PPT.TotalUnit = dgvPieceRate.SelectedRows(0).Cells("colTotalUnit").Value
        _PieceRateActivity_PPT.MandoreRate = dgvPieceRate.SelectedRows(0).Cells("colMandorRate").Value
        _PieceRateActivity_PPT.JobRate = dgvPieceRate.SelectedRows(0).Cells("colJobRate").Value
        _PieceRateActivity_PPT.ActivityBy = dgvPieceRate.SelectedRows(0).Cells("colActivityBy").Value


        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    
End Class