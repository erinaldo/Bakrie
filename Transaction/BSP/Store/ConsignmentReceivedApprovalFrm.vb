Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class ConsignmentReceivedApprovalFrm

    Dim CRMasterID As String
    Dim CRID As String
    Dim btnAdd As Boolean = True
    Dim isDecimal, isModifierKey As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")   ''Declaration for to allow double only

    Private Sub ConsignmentReceivedApprovalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpviewCRDate.Format = DateTimePickerFormat.Custom
        dtpviewCRDate.CustomFormat = "dd/MM/yyyy"
        GridISRViewBind()

    End Sub

    Private Sub btnviewCRSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCRSearch.Click

        GridISRViewBind()

    End Sub

    Private Sub GridISRViewBind()

        Dim objCRPPT As New ConsignmentReceivedPPT
        Dim objCRBOL As New ConsignmentReceivedBOL
        Dim dt As New DataTable
        lblNoRecordFound.Visible = False

        With objCRPPT
            If chkviewCRDate.Checked = True Then
                .blReceivedDate = True
            Else
                .blReceivedDate = False
            End If
            .ReceivedDate = Format(Me.dtpviewCRDate.Value, "yyyy/MM/dd") 'dtpviewCRDate.Value         'Format(Me.dtpviewISRDate.Value, "yyyy/MM/dd") 
            .STCode = txtviewStockCode.Text.Trim()
            .ReferenceNo = txtviewCRNo.Text
            .Status = "OPEN"

        End With
        dt = objCRBOL.GetConsignmentReceivedDetails(objCRPPT)
        If (dt.Rows.Count <> 0) Then
            CRMasterID = dt.Rows(0).Item("STConsignmentMasterID")
            CRID = dt.Rows(0).Item("StConsignmentID")
        Else
            lblNoRecordFound.Visible = True
            txtviewCRNo.Text = String.Empty
            txtviewStockCode.Text = String.Empty
        End If
        dgvviewCReceived.AutoGenerateColumns = False
        Me.dgvviewCReceived.DataSource = dt

    End Sub

   
    Private Sub dgvviewCReceived_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvviewCReceived.CellContentClick

        If e.ColumnIndex = 12 Then

            Dim frmCR As New ConsignmentReceivedFrm
            frmCR.tcConsiognmentReceived.SelectedTab = frmCR.tbpgConsignmentReceived


            Dim objCRPPT As New ConsignmentReceivedPPT
            Dim objCRBOL As New ConsignmentReceivedBOL

            Dim dt As New DataTable

            Dim lsReceivedDate As String
            Dim ReceivedDate As Date

            Dim lsRefNo As String = String.Empty
            Dim lsSTCode As String = String.Empty
            Dim lsStConsignmentID As String = String.Empty
            Dim lsSTConsignmentMasterID As String = String.Empty
            Dim liReceivedQty As Integer
            Dim liStockBalance As Integer
            Dim lsRemarks As String = String.Empty
            Dim lsUOM As String = String.Empty
            Dim lsUOMID As String = String.Empty
            Dim lsPartNo As String = String.Empty
            Dim lsSTDesc As String = String.Empty

            ''
            If dgvviewCReceived.Rows.Count > 0 Then

                lsRefNo = dgvviewCReceived.SelectedRows(0).Cells("ReferenceNo").Value.ToString()
                lsSTCode = dgvviewCReceived.SelectedRows(0).Cells("STCode").Value.ToString()
                lsStConsignmentID = dgvviewCReceived.SelectedRows(0).Cells("StConsignmentID").Value.ToString()
                lsSTConsignmentMasterID = dgvviewCReceived.SelectedRows(0).Cells("STConsignmentMasterID").Value.ToString()

                liReceivedQty = dgvviewCReceived.SelectedRows(0).Cells("ReceivedQty").Value.ToString()
                lsRemarks = dgvviewCReceived.SelectedRows(0).Cells("Remarks").Value.ToString()
                lsUOM = dgvviewCReceived.SelectedRows(0).Cells("UOM").Value.ToString()
                lsUOMID = dgvviewCReceived.SelectedRows(0).Cells("UOMID").Value.ToString()
                lsPartNo = dgvviewCReceived.SelectedRows(0).Cells("PartNo").Value.ToString
                liStockBalance = dgvviewCReceived.SelectedRows(0).Cells("StockBalance").Value.ToString
                lsSTDesc = dgvviewCReceived.SelectedRows(0).Cells("STDesc").Value.ToString()
                lsReceivedDate = dgvviewCReceived.SelectedRows(0).Cells("ReceivedDate").Value.ToString()
                ReceivedDate = New Date(lsReceivedDate.Substring(6, 4), lsReceivedDate.Substring(3, 2), lsReceivedDate.Substring(0, 2))
                btnAdd = False
                frmCR.GridISRViewBindApprovalMode(ReceivedDate, lsSTCode, lsRefNo, lsUOM, liStockBalance, lsPartNo, liReceivedQty, lsRemarks, lsSTDesc, lsStConsignmentID, lsSTConsignmentMasterID, lsUOMID)
                frmCR.ShowDialog()
                GridISRViewBind()
            End If

            ''''
        End If

    End Sub

    Private Sub ConsignmentReceivedApprovalFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub chkviewCRDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkviewCRDate.CheckedChanged

        If chkviewCRDate.Checked = True Then
            dtpviewCRDate.Enabled = True
        Else
            dtpviewCRDate.Enabled = False
        End If

    End Sub

End Class