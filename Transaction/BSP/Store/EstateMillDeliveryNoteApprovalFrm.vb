Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
Imports Common_BOL

Imports System.Data.SqlClient
Imports System.Math
Public Class EstateMillDeliveryNoteApprovalFrm
    Private Sub EstateMillDeliveryNoteApprovalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        FormatDateTimePicker(dtpviewIDNDate)
        BindIDNViewDetails()
        Load_IPRNo()
        Load_LPONo()
        'Load_PONo()
        btnviewReport.Visible = False
    End Sub
    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        BindIDNViewDetails()

        If ChkIPR.Checked = True Then
            cbviewIPRNo.Text = "--SELECT--"
        ElseIf ChkLPO.Checked = True Then
            cbviewLPONo.Text = "--SELECT--"
        End If

    End Sub

    Private Sub BindIDNViewDetails()

        dgvIDNView.DataSource = Nothing
        Dim dt As New DataTable
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL

        With objEMDNPPT

            If chkIDNDate.Checked = True Then
                .IDNDate = Format(Me.dtpviewIDNDate.Value, "MM/dd/yyyy")
            Else
                .IDNDate = Nothing
            End If

            .LPOorIPR = cbviewTransType.Text
            .IDNNO = txtviewIDNNo.Text
            .GRNNo = txtviewGRNNo.Text

            '.IPRNo = cbviewIPRNo.Text
            '.LPONo = cbviewLPONo.Text

            If cbviewLPONo.Text = "--SELECT--" Then
                .LPONo = String.Empty
            Else
                .LPONo = cbviewLPONo.Text
            End If

            If cbviewIPRNo.Text = "--SELECT--" Then
                .IPRNo = String.Empty
            Else
                .IPRNo = cbviewIPRNo.Text
            End If

            .PONo = cbviewPONo.Text
            .DeliverySource = cbviewDeliverySource.Text
            .SupplierID = txtviewSupplier.Text
            '.Status = cbviewStatus.SelectedItem.ToString()
            .Status = "OPEN"
            If ChkLPO.Checked = True Then
                .Flag = "PO"
            Else
                .Flag = "PR"
            End If

        End With

        dt = objEMDNBOL.IDNView_Select(objEMDNPPT)

        If dt.Rows.Count > 0 Then
            lblNoRecordFound.Visible = False
            dgvIDNView.AutoGenerateColumns = False
            dgvIDNView.DataSource = dt
        Else
            lblNoRecordFound.Visible = True
            ClearGridView(dgvIDNView)
        End If
    End Sub
    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then

            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            If grdname.Rows.Count = 1 Then
                grdname.Rows.RemoveAt(0)
            End If
        End If
    End Sub
    Private Sub Load_IPRNo()

        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        dt = objEMDNBOL.STMillDeliveryIPRNoGet(objEMDNPPT)
        If dt.Rows.Count <> 0 Then

            cbviewIPRNo.DataSource = dt
            cbviewIPRNo.DisplayMember = "IPRNo"
            cbviewIPRNo.ValueMember = "IPRNo"

            Dim intRowCount As Integer
            intRowCount = cbviewIPRNo.SelectedIndex

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "--SELECT--"
            dr(1) = "--SELECT--"
            dt.Rows.InsertAt(dr, 0)

            cbviewIPRNo.SelectedIndex = 0
        Else
            cbviewIPRNo.Text = "--SELECT--"
        End If

    End Sub

    Private Sub Load_LPONo()

        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        dt = objEMDNBOL.STMillDeliveryLPONoGet(objEMDNPPT)

        If dt.Rows.Count <> 0 Then

            cbviewLPONo.DataSource = dt
            cbviewLPONo.DisplayMember = "LPONo"
            cbviewLPONo.ValueMember = "LPONo"

            Dim intRowCount As Integer
            intRowCount = cbviewLPONo.SelectedIndex

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "--SELECT--"
            dr(1) = "--SELECT--"
            dt.Rows.InsertAt(dr, 0)

            cbviewLPONo.SelectedIndex = 0
        Else

            cbviewLPONo.Text = "--SELECT--"

        End If

    End Sub

    'Private Sub Load_PONo()
    '    Dim objEMDNPPT As New EstateMillDeliveryNotePPT
    '    Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
    '    Dim dt As New DataTable
    '    dt = objEMDNBOL.STMillDeliveryPONoGet(objEMDNPPT)
    '    If dt.Rows.Count <> 0 Then
    '        cbviewPONo.DataSource = dt
    '        cbviewPONo.DisplayMember = "PONo"
    '        cbviewPONo.ValueMember = "PONo"

    '        'Dim intRowCount As Integer
    '        'intRowCount = cbviewPONo.SelectedIndex

    '        'Dim dr As DataRow = dt.NewRow()
    '        'dr(0) = "--SELECT--"
    '        'dr(1) = "--SELECT--"
    '        'dt.Rows.InsertAt(dr, 0)
    '        'cbviewLPONo.SelectedIndex = 0
    '        'Else
    '        '    cbviewLPONo.Text = "--SELECT--"
    '    End If

    'End Sub

    Private Sub dgvIDNView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIDNView.CellContentClick

        If e.ColumnIndex = 17 Then

            Dim frmEMDN As New EstateMillDeliveryNoteFrm
            frmEMDN.dtpIDNDate.Enabled = False
            frmEMDN.tcEMDN.TabStop = False
            frmEMDN.btnClose.TabIndex = 3000
            frmEMDN.grpApproval.Focus()
            frmEMDN.cmbStatus.Focus()


            frmEMDN.tcEMDN.SelectedTab = frmEMDN.tbpgEMDNAdd
            If dgvIDNView.Rows.Count > 0 Then
                EMDNView_EditApprovalMode()
            End If

        End If

    End Sub

    Private Sub EMDNView_EditApprovalMode()


        Dim frmEMDN As New EstateMillDeliveryNoteFrm

        frmEMDN.cmbStatus.Focus()
        frmEMDN.tcEMDN.TabStop = False

        Dim dt As New DataTable
        Dim txtIPRNoVal As String = String.Empty
        Dim txtIDNNoVal As String = String.Empty
        Dim dtpIDNDateVal As String = String.Empty
        Dim txtGRNNoVal As String = String.Empty
        Dim txtLPONoVal As String = String.Empty
        Dim txtPONoVal As String = String.Empty
        Dim cbTransTypeVal As String = String.Empty
        Dim cbDeliveySourceVal As String = String.Empty
        Dim txtSupplierVal As String = String.Empty
        Dim lSupplierIDVal As String = String.Empty
        Dim lblStatusDescVal As String = String.Empty
        Dim lSTEstMillDeliveryIDVal As String = String.Empty
        Dim dtpTransportDateVal As String = String.Empty
        Dim txtOperatorNameVal As String = String.Empty
        Dim txtVehicleNoVal As String = String.Empty
        Dim txtRemarksVal As String = String.Empty
        Dim txtRejectedReasonVal As String = String.Empty
        Dim lSTIPRIDVal As String = String.Empty
        Dim lSTLPOIDVal As String = String.Empty

        Dim lSupplierCOAIDVal As String = String.Empty
        Dim lT0Val As String = String.Empty
        Dim lT1Val As String = String.Empty
        Dim lT2Val As String = String.Empty
        Dim lT3Val As String = String.Empty
        Dim lT4Val As String = String.Empty


        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim oBjEMDNBOL As New EstateMillDeliveryNoteBOL

        If dgvIDNView.Rows.Count > 0 Then
            If Not dgvIDNView.CurrentRow.Cells("dgclIPRNo").Value Is Nothing Then
                txtIPRNoVal = dgvIDNView.CurrentRow.Cells("dgclIPRNo").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclIDNNo").Value Is Nothing Then
                txtIDNNoVal = dgvIDNView.CurrentRow.Cells("dgclIDNNo").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclIDNDate").Value Is Nothing Then
                dtpIDNDateVal = dgvIDNView.CurrentRow.Cells("dgclIDNDate").Value
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclGRNNo").Value Is Nothing Then
                txtGRNNoVal = dgvIDNView.CurrentRow.Cells("dgclGRNNo").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclLPONo").Value Is Nothing Then
                txtLPONoVal = dgvIDNView.CurrentRow.Cells("dgclLPONo").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclPONo").Value Is Nothing Then
                txtPONoVal = dgvIDNView.CurrentRow.Cells("dgclPONo").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclTransType").Value Is Nothing Then
                cbTransTypeVal = dgvIDNView.CurrentRow.Cells("dgclTransType").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclDeliverySource").Value Is Nothing Then
                cbDeliveySourceVal = dgvIDNView.CurrentRow.Cells("dgclDeliverySource").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclSupplier").Value Is Nothing Then
                txtSupplierVal = dgvIDNView.CurrentRow.Cells("dgclSupplier").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclSupplierID").Value Is Nothing Then
                lSupplierIDVal = dgvIDNView.CurrentRow.Cells("dgclSupplierID").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclStatus").Value Is Nothing Then
                lblStatusDescVal = dgvIDNView.CurrentRow.Cells("dgclStatus").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclSTEstMillDeliveryID").Value Is Nothing Then
                lSTEstMillDeliveryIDVal = dgvIDNView.CurrentRow.Cells("dgclSTEstMillDeliveryID").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclTransportDate").Value Is Nothing Then
                dtpTransportDateVal = dgvIDNView.CurrentRow.Cells("dgclTransportDate").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclOperatorName").Value Is Nothing Then
                txtOperatorNameVal = dgvIDNView.CurrentRow.Cells("dgclOperatorName").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclVehicleNo").Value Is Nothing Then
                txtVehicleNoVal = dgvIDNView.CurrentRow.Cells("dgclVehicleNo").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclRemarks").Value Is Nothing Then
                txtRemarksVal = dgvIDNView.CurrentRow.Cells("dgclRemarks").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclRejectedReason").Value Is Nothing Then
                txtRejectedReasonVal = dgvIDNView.CurrentRow.Cells("dgclRejectedReason").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclSTIPRID").Value Is Nothing Then
                lSTIPRIDVal = dgvIDNView.CurrentRow.Cells("dgclSTIPRID").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclSTLPOID").Value Is Nothing Then
                lSTLPOIDVal = dgvIDNView.CurrentRow.Cells("dgclSTLPOID").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclSupplierCOAID").Value Is Nothing Then
                lSupplierCOAIDVal = dgvIDNView.CurrentRow.Cells("dgclSupplierCOAID").Value.ToString()
            End If

            If Not dgvIDNView.CurrentRow.Cells("dgclT0").Value Is Nothing Then
                lT0Val = dgvIDNView.CurrentRow.Cells("dgclT0").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclT1").Value Is Nothing Then
                lT1Val = dgvIDNView.CurrentRow.Cells("dgclT1").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclT2").Value Is Nothing Then
                lT2Val = dgvIDNView.CurrentRow.Cells("dgclT2").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclT3").Value Is Nothing Then
                lT3Val = dgvIDNView.CurrentRow.Cells("dgclT3").Value.ToString()
            End If
            If Not dgvIDNView.CurrentRow.Cells("dgclT4").Value Is Nothing Then
                lT4Val = dgvIDNView.CurrentRow.Cells("dgclT4").Value.ToString()
            End If


            frmEMDN.EMDNView_EditApprovalMode(txtIPRNoVal, txtIDNNoVal, dtpIDNDateVal, txtGRNNoVal, txtLPONoVal, txtPONoVal, cbTransTypeVal, cbDeliveySourceVal, txtSupplierVal, lSupplierIDVal, lblStatusDescVal, lSTEstMillDeliveryIDVal, dtpTransportDateVal, txtOperatorNameVal, txtVehicleNoVal, txtRemarksVal, txtRejectedReasonVal, lSTIPRIDVal, lSTLPOIDVal, lSupplierCOAIDVal, lT0Val, lT1Val, lT2Val, lT3Val, lT4Val)
            Dim frmEMDNResult As DialogResult = frmEMDN.ShowDialog()
            If frmEMDN.DialogResult = Windows.Forms.DialogResult.OK Then
                BindIDNViewDetails()
            End If
        End If
    End Sub

    Private Sub ChkIPR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIPR.CheckedChanged
        Load_IPRNo()
        ChkLPO.Checked = False
        cbviewLPONo.DataSource = Nothing
    End Sub

    Private Sub ChkLPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkLPO.CheckedChanged
        Load_LPONo()
        ChkIPR.Checked = False
        cbviewIPRNo.DataSource = Nothing
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EstateMillDeliveryNoteApprovalFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

        plEMDNSearch.CaptionText = rm.GetString("plEMDNSearch.CaptionText")
        lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
        lblviewIDNDate.Text = rm.GetString("lblviewIDNDate.Text")
        lblviewIDNNo.Text = rm.GetString("lblviewIDNNo.Text")
        lblviewGRNNo.Text = rm.GetString("lblviewGRNNo.Text")
        lblviewTransType.Text = rm.GetString("lblviewTransType.Text")
        lblviewIPRNo.Text = rm.GetString("lblviewIPRNo.Text")
        lblviewLPONo.Text = rm.GetString("lblviewLPONo.Text")
        lblviewPONo.Text = rm.GetString("lblviewPONo.Text")
        lblviewDeliverySource.Text = rm.GetString("lblviewDeliverySource.Text")
        lblviewSupplier.Text = rm.GetString("lblviewSupplier.Text")
        lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
        lblNoRecordFound.Text = rm.GetString("lblNoRecordFound.Text")

        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
       
        dgvIDNView.Columns("dgclIDNDate").HeaderText = rm.GetString("dgvIDNView.Columns(dgclIDNDate).HeaderText")
        dgvIDNView.Columns("dgclTransType").HeaderText = rm.GetString("dgvIDNView.Columns(dgclTransType).HeaderText")
        dgvIDNView.Columns("dgclIDNNo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclIDNNo).HeaderText")
        dgvIDNView.Columns("dgclGRNNo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclGRNNo).HeaderText")
        dgvIDNView.Columns("dgclIPRNo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclIPRNo).HeaderText")
        dgvIDNView.Columns("dgclLPONo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclLPONo).HeaderText")
        dgvIDNView.Columns("dgclPONo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclPONo).HeaderText")
        dgvIDNView.Columns("dgclDeliverySource").HeaderText = rm.GetString("dgvIDNView.Columns(dgclDeliverySource).HeaderText")
        dgvIDNView.Columns("dgclSupplier").HeaderText = rm.GetString("dgvIDNView.Columns(dgclSupplier).HeaderText")
        dgvIDNView.Columns("dgclStatus").HeaderText = rm.GetString("dgvIDNView.Columns(dgclStatus).HeaderText")
        dgvIDNView.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvIDNView.Columns(dgclViewDetails).HeaderText")
        'dgIssueVoucher.Columns("dgclStockCode").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclStockCode).HeaderText")
        'display a message if the culture is not supported
        'try passing bn (Bengali) for testing
        'MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

   
    Private Sub EstateMillDeliveryNoteApprovalFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown


        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub chkIDNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDNDate.CheckedChanged

        If chkIDNDate.Checked = True Then
            dtpviewIDNDate.Enabled = True
        Else
            dtpviewIDNDate.Enabled = False
        End If

    End Sub
End Class