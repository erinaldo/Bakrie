Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class InternalTransferNoteINApprovalFrm

    Public strSTITNInID As String = String.Empty
    Public strOperatorName As String = String.Empty
    Public strTransportDate As DateTime = DateTime.Now
    Public strVehicleNo As String = String.Empty
    Public strMRCNo As String = String.Empty
    Public strITNInNo As String = String.Empty
    Public strITNInDate As Date = Nothing
    Public strSendersLocation As String = String.Empty
    Public strSendersLocationID As String = String.Empty
    Public strSupplierCOAID As String = String.Empty
    Public strT0 As String = String.Empty
    Public strT1 As String = String.Empty
    Public strT2 As String = String.Empty
    Public strT3 As String = String.Empty
    Public strT4 As String = String.Empty
    Public strStatus As String = String.Empty
    Public strRemarks As String = String.Empty
    Public lSenderLocation As String = String.Empty

    Private Sub InternalTransferNoteINApprovalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpviewITNDate.Format = DateTimePickerFormat.Custom
        dtpviewITNDate.CustomFormat = "dd/MM/yyyy"
        BindITNInDetails()
        SetUICulture(GlobalPPT.strLang)
    End Sub

    Private Sub InternalTransferNoteINApprovalFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BindITNInDetails()
        dgvITNInApproval.DataSource = Nothing
        Dim objITNInApprovalPPT As New InternalTransferNoteINApprovalPPT
        Dim objITNInApprovalBOL As New InternalTransferNoteINApprovalBOL
        Dim dt As New DataTable
        With objITNInApprovalPPT
            If chkITNDate.Checked = True Then
                .ITNDate = dtpviewITNDate.Value ' Format(Me.dtpviewITNDate.Value, "MM/dd/yyyy")
            Else
                .ITNDate = Nothing
            End If
            .ItnInNo = txtviewITNInNo.Text
            .SenderLocation = txtviewSendLoc.Text
            .Status = "OPEN"
        End With

        dt = objITNInApprovalBOL.ITNInApprovalGet(objITNInApprovalPPT)
        If dt.Rows.Count <> 0 Then
            lblNoRecord.Visible = False
            dgvITNInApproval.AutoGenerateColumns = False
            dgvITNInApproval.DataSource = dt
            'Exit Sub
        Else
            lblNoRecord.Visible = True
        End If
    End Sub

    Private Sub btnviewSendLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewSendLoc.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lSenderLocation = SenderReceiverLocLookup._lSenderLocation
            txtviewSendLoc.Text = lSenderLocation
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindITNInDetails()
    End Sub

    Private Sub dgvITNInApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNInApproval.CellContentClick
        Dim ItnDate As String
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        If e.ColumnIndex = 9 Then
            With objIPRPPT
                strSTITNInID = dgvITNInApproval.SelectedRows(0).Cells("dgclSTITNInID").Value.ToString()
                strITNInNo = dgvITNInApproval.SelectedRows(0).Cells("dgclITNInNo").Value.ToString()
                ItnDate = dgvITNInApproval.SelectedRows(0).Cells("dgclITNDate").Value.ToString()
                strITNInDate = New Date(ItnDate.Substring(6, 4), ItnDate.Substring(3, 2), ItnDate.Substring(0, 2))
                strSendersLocation = dgvITNInApproval.SelectedRows(0).Cells("dgclSendersLocation").Value
                strSendersLocationID = dgvITNInApproval.SelectedRows(0).Cells("dgclDistributionSetupID").Value
                strSupplierCOAID = dgvITNInApproval.SelectedRows(0).Cells("dgclSupplierCOAID").Value

                If dgvITNInApproval.SelectedRows(0).Cells("dgcOperatorName").Value IsNot Nothing Then
                    strOperatorName = dgvITNInApproval.SelectedRows(0).Cells("dgcOperatorName").Value
                End If

                strTransportDate = dgvITNInApproval.SelectedRows(0).Cells("dgcTransportDate").Value
                strVehicleNo = dgvITNInApproval.SelectedRows(0).Cells("dgcVehicleNo").Value
                strMRCNo = dgvITNInApproval.SelectedRows(0).Cells("dgcMRCNo").Value

                'SupplierCOAID

                If Not dgvITNInApproval.SelectedRows(0).Cells("dgclT0").Value Is DBNull.Value Then
                    strT0 = dgvITNInApproval.SelectedRows(0).Cells("dgclT0").Value
                Else
                    strT0 = String.Empty
                End If
                If Not dgvITNInApproval.SelectedRows(0).Cells("dgclT1").Value Is DBNull.Value Then
                    strT1 = dgvITNInApproval.SelectedRows(0).Cells("dgclT1").Value
                Else
                    strT1 = String.Empty
                End If
                If Not dgvITNInApproval.SelectedRows(0).Cells("dgclT2").Value Is DBNull.Value Then
                    strT2 = dgvITNInApproval.SelectedRows(0).Cells("dgclT2").Value
                Else
                    strT2 = String.Empty
                End If
                If Not dgvITNInApproval.SelectedRows(0).Cells("dgclT3").Value Is DBNull.Value Then
                    strT3 = dgvITNInApproval.SelectedRows(0).Cells("dgclT3").Value
                Else
                    strT3 = String.Empty
                End If
                If Not dgvITNInApproval.SelectedRows(0).Cells("dgclT4").Value Is DBNull.Value Then
                    strT4 = dgvITNInApproval.SelectedRows(0).Cells("dgclT4").Value
                Else
                    strT4 = String.Empty
                End If

                strStatus = dgvITNInApproval.SelectedRows(0).Cells("dgclStatus").Value.ToString()
                strRemarks = dgvITNInApproval.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            End With
            InternalTransferNoteINFrm.BindITNInDet_inApproval(strSTITNInID)
            InternalTransferNoteINFrm.BindITNInMast_inApproval(strSTITNInID, strITNInNo, strITNInDate, strSendersLocation, strStatus, strRemarks, strT0, strT1, strT2, strT3, strT4, strSendersLocationID, strSupplierCOAID, strOperatorName, strTransportDate, strVehicleNo, strMRCNo)

            InternalTransferNoteINFrm.dtpITNDate.Enabled = False
            InternalTransferNoteINFrm.txtITNINNo.Enabled = False
            InternalTransferNoteINFrm.txtRemarks.Enabled = False
            InternalTransferNoteINFrm.txtSendersLocation.Enabled = False
            InternalTransferNoteINFrm.txtStockCode.Enabled = False
            InternalTransferNoteINFrm.txtTransferQty.Enabled = False
            InternalTransferNoteINFrm.txtUnitPrice.Enabled = False
            InternalTransferNoteINFrm.tcITNIN.TabStop = False
            InternalTransferNoteINFrm.txtOperatorName.Enabled = False
            InternalTransferNoteINFrm.txtVehicleNo.Enabled = False
            InternalTransferNoteINFrm.dtpTransportDate.Enabled = False
            InternalTransferNoteINFrm.txtMRCNo.Enabled = False
            InternalTransferNoteINFrm.cbApprovalStatus.Focus()

            InternalTransferNoteINFrm.ShowDialog()
            'InternalTransferNoteINFrm.StartPosition = FormStartPosition.CenterScreen
            BindITNInDetails()
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteINApprovalFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)


        lblviewITNDate.Text = rm.GetString("lblviewITNDate.Text")
        lblviewITNIntNo.Text = rm.GetString("lblviewITNIntNo.Text")
        lblviewSendersLoc.Text = rm.GetString("lblviewSendersLoc.Text")
        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
        plITNInApprovalSearch.Text = rm.GetString("plITNInApprovalSearch.Text")
        lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
        lblNoRecord.Text = rm.GetString("lblNoRecord.Text")

        dgvITNInApproval.Columns("dgclITNDate").HeaderText = rm.GetString("dgvITNInApproval.Columns(dgclITNDate).HeaderText")
        dgvITNInApproval.Columns("dgclITNInNo").HeaderText = rm.GetString("dgvITNInApproval.Columns(dgclITNInNo).HeaderText")
        dgvITNInApproval.Columns("dgclSendersLocation").HeaderText = rm.GetString("dgvITNInApproval.Columns(dgclSendersLocation).HeaderText")
        dgvITNInApproval.Columns("dgclStatus").HeaderText = rm.GetString("dgvITNInApproval.Columns(dgclStatus).HeaderText")
        dgvITNInApproval.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvITNInApproval.Columns(dgclViewDetails).HeaderText")



        'display a message if the culture is not supported
        'try passing bn (Bengali) for testing
        'MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub chkITNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkITNDate.CheckedChanged

        If chkITNDate.Checked = True Then
            dtpviewITNDate.Enabled = True
        Else
            dtpviewITNDate.Enabled = False
        End If

    End Sub

End Class