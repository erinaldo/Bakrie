Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class LocalPurchaseOrderApprovalFrm
    Public strLPOID As String = String.Empty
    Public strLPONo As String = String.Empty
    Public strStockId As String
    Public strLPODate As String = String.Empty
    'Public strLPODate As Date
    Public strUOM As String = String.Empty
    Public strMRCNo As String = String.Empty

    Public strStockCode As String = Nothing
    Public strStatus As String = String.Empty
    Public strRejectedReason As String = String.Empty
    Public strOrderQty As Double
    Public strValue As Double
    Public strT0 As String = String.Empty
    Public strT1 As String = String.Empty
    Public strT2 As String = String.Empty
    Public strT3 As String = String.Empty
    Public strT4 As String = String.Empty
    Public strRemarks As String = String.Empty
    Public strModifiedOn As Date
    Public strID As Integer
    Public strSTLPOID As String
    Public strMainStatus As String
    Public strSupplierName As String
    Public strSupplierID As String
    Public strContractNo As String
    Public strContractID As String

    Public strSTCategoryID As String = String.Empty
    Public strSTCategoryDescp As String = String.Empty
    Public strSTCategoryCode As String = String.Empty

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindLPODetails()
    End Sub
    Public Sub BindLPODetails()

        dgvLPOApproval.DataSource = Nothing
        Dim objLPOApprovalPPT As New LocalPurchaseOrderApprovalPPT
        Dim objLPOApprovalBOL As New LocalPurchaseOrderApprovalBOL
        Dim dt As New DataTable
        If chkLPOViewDate.Checked = True Then
            dtpLPOViewDate.Enabled = True
            objLPOApprovalPPT.LPODate = Me.dtpLPOViewDate.Value  'Format(Me.dtpLPOViewDate.Value, "MM/dd/yyyy") 
        Else
            dtpLPOViewDate.Enabled = False
            objLPOApprovalPPT.LPODate = Nothing
        End If
        With objLPOApprovalPPT
            .LPONo = txtLPONoSearch.Text
            .MainStatus = "OPEN"
        End With
        If chkLPOViewDate.Checked = True Then
            objLPOApprovalPPT.LPODate = Me.dtpLPOViewDate.Value ' Format(Me.dtpLPOViewDate.Value, "MM/dd/yyyy") 'Me.dtpLPOViewDate.Value
        Else
            objLPOApprovalPPT.LPODate = Nothing
        End If
        dt = objLPOApprovalBOL.LPOApprovalGet(objLPOApprovalPPT)
        If dt.Rows.Count <> 0 Then
            lblNoRecordFound.Visible = False
            dgvLPOApproval.AutoGenerateColumns = False
            dgvLPOApproval.DataSource = dt
            'Exit Sub
        Else
            lblNoRecordFound.Visible = True
            dgvLPOApproval.Visible = False
        End If
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPurchaseOrderApprovalFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblLPONoSerach.Text = rm.GetString("lblLPONoSerach.Text")

            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")
            lblNoRecordFound.Text = rm.GetString("lblNoRecordFound.Text")
            '''''''''''''GRID CAPTIONS'''''''''''''''''''''''''''''
            pnlLPOApproval.CaptionText = rm.GetString("pnlLPOApproval.CaptionText")
            dgvLPOApproval.Columns("dgclLPONo").HeaderText = rm.GetString("dgvLPOApproval.Columns(dgclLPONo).HeaderText")
            dgvLPOApproval.Columns("dgclLPODate").HeaderText = rm.GetString("dgvLPOApproval.Columns(dgclLPODate).HeaderText")
            dgvLPOApproval.Columns("dgclStatus").HeaderText = rm.GetString("dgvLPOApproval.Columns(dgclStatus).HeaderText")
            dgvLPOApproval.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvLPOApproval.Columns(dgclViewDetails).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub LocalPurchaseOrderApprovalFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindLPODetails()
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpLPOViewDate)
        FormatDateTimePicker(dtpLPOViewDate)
        SetUICulture(GlobalPPT.strLang)
    End Sub

    Private Sub dgvLPOApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLPOApproval.CellContentClick

        'Dim StkAdjustDate As String
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        'Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable
        If e.ColumnIndex = 12 Then

            With objLPOPPT
                strSTLPOID = dgvLPOApproval.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString()
                strLPONo = dgvLPOApproval.SelectedRows(0).Cells("dgclLPONo").Value.ToString()
                strLPODate = dgvLPOApproval.SelectedRows(0).Cells("dgclLPODate").Value
                strStatus = dgvLPOApproval.SelectedRows(0).Cells("dgclStatus").Value.ToString()
                strRemarks = dgvLPOApproval.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
                'strSupplierName = dgvLPOApproval.SelectedRows(0).Cells("dgclSupplierName").Value.ToString()
                strSupplierName = dgvLPOApproval.SelectedRows(0).Cells("dgclSupplierNameCode").Value.ToString()
                strSupplierID = dgvLPOApproval.SelectedRows(0).Cells("dgclSupplierID").Value.ToString()
                strContractNo = dgvLPOApproval.SelectedRows(0).Cells("dgclContractNo").Value.ToString()
                strContractID = dgvLPOApproval.SelectedRows(0).Cells("dgclContractID").Value.ToString()
                'strModifiedOn = dgvLPOApproval.SelectedRows(0).Cells("dgclModifiedOn").Value.ToString()
                If Not dgvLPOApproval.SelectedRows(0).Cells("dgclSTCategoryID").Value Is DBNull.Value Then
                    strSTCategoryID = Me.dgvLPOApproval.SelectedRows(0).Cells("dgclSTCategoryID").Value.ToString()
                Else
                    strSTCategoryID = String.Empty
                End If
                If Not dgvLPOApproval.SelectedRows(0).Cells("dgclSTCategoryCode").Value Is DBNull.Value Then
                    strSTCategoryCode = Me.dgvLPOApproval.SelectedRows(0).Cells("dgclSTCategoryCode").Value.ToString()
                Else
                    strSTCategoryCode = String.Empty
                End If
                If Not dgvLPOApproval.SelectedRows(0).Cells("dgclSTCategoryDescp").Value Is DBNull.Value Then
                    strSTCategoryDescp = Me.dgvLPOApproval.SelectedRows(0).Cells("dgclSTCategoryDescp").Value.ToString()
                Else
                    strSTCategoryDescp = String.Empty
                End If

            End With
            LocalPuchaseOrderFrm.BindLPOMast_inApproval(strSTLPOID, strLPONo, strLPODate, strStatus, strRemarks, strSupplierName, strSupplierID, strContractNo, strContractID, strSTCategoryID, strSTCategoryCode, strSTCategoryDescp)

            LocalPuchaseOrderFrm.txtAccountCode.Enabled = False
            LocalPuchaseOrderFrm.txtContractNo.Enabled = False
            LocalPuchaseOrderFrm.gbLPODetails.Enabled = False
            LocalPuchaseOrderFrm.txtLPORemarks.Enabled = False
            LocalPuchaseOrderFrm.dtpLPODate.Enabled = False
            LocalPuchaseOrderFrm.txtQty.Enabled = False
            LocalPuchaseOrderFrm.txtLPONo.Enabled = False
            LocalPuchaseOrderFrm.txtStockCategory.Enabled = False
            LocalPuchaseOrderFrm.txtSupplierCode.Enabled = False
            LocalPuchaseOrderFrm.tabLPOContainer.TabStop = False
            LocalPuchaseOrderFrm.txtVATPercent.Enabled = False
            LocalPuchaseOrderFrm.txtTransportationCost.Enabled = False
            LocalPuchaseOrderFrm.cmbLPOStatus.Focus()
            LocalPuchaseOrderFrm.ShowDialog()

            BindLPODetails()

        End If

    End Sub

    Private Sub chkLPOViewDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLPOViewDate.CheckedChanged
        If chkLPOViewDate.Checked = True Then
            dtpLPOViewDate.Enabled = True
        Else
            dtpLPOViewDate.Enabled = False
        End If
    End Sub

    Private Sub LocalPurchaseOrderApprovalFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class