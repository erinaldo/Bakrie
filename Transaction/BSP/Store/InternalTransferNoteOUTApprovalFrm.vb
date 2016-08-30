Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class InternalTransferNoteOUTApprovalFrm
    Public strSTITNOutID As String = String.Empty
    Public strITNOutNo As String = String.Empty
    Public strITNOutDate As Date = Nothing

    Public strOperatorName As String = String.Empty
    Public strTransportDate As DateTime = DateTime.Now
    Public strVehicleNo As String = String.Empty
    Public strMRCNo As String = String.Empty

    Public strReceivedLocation As String = String.Empty
    Public strReceivedLocationID As String = String.Empty
    Public strSupplierCOAID As String = String.Empty


    Public strStatus As String = String.Empty
    Public strRemarks As String = String.Empty
    Public lReceivedLocation As String = String.Empty

    Public strT0 As String = String.Empty
    Public strT1 As String = String.Empty
    Public strT2 As String = String.Empty
    Public strT3 As String = String.Empty
    Public strT4 As String = String.Empty

    Private Sub InternalTransferNoteOUTApprovalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpviewITNDate.Format = DateTimePickerFormat.Custom
        dtpviewITNDate.CustomFormat = "dd/MM/yyyy"
        BindITNOutDetails()
        SetUICulture(GlobalPPT.strLang)
    End Sub

    Private Sub InternalTransferNoteOUTApprovalFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BindITNOutDetails()
        dgvITNOutApproval.DataSource = Nothing
        Dim objITNOutApprovalPPT As New InternalTransferNoteOUTApprovalPPT
        Dim objITNOutApprovalBOL As New InternalTransferNoteOUTApprovalBOL
        Dim dt As New DataTable
        With objITNOutApprovalPPT
            If chkITNOutdate.Checked = True Then
                .ITNDate = Format(Me.dtpviewITNDate.Value, "MM/dd/yyyy")
            Else
                .ITNDate = Nothing
            End If
            .ItnOutNo = txtviewITNOutNo.Text
            .ReceiverLocation = txtviewRecLoc.Text
            .Status = "OPEN"
        End With

        dt = objITNOutApprovalBOL.ITNOutApprovalGet(objITNOutApprovalPPT)
        If dt.Rows.Count <> 0 Then
            lblNoRecord.Visible = False
            dgvITNOutApproval.AutoGenerateColumns = False
            dgvITNOutApproval.DataSource = dt
            'Exit Sub
        Else
            lblNoRecord.Visible = True
        End If

    End Sub

    Private Sub btnviewRecLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewRecLoc.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lReceivedLocation = SenderReceiverLocLookup._lSenderLocation
            txtviewRecLoc.Text = lReceivedLocation
        End If
    End Sub

    Private Sub dgvITNOutApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNOutApproval.CellContentClick
        Dim ItnDate As String
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        If e.ColumnIndex = 5 Then
            With objIPRPPT
                strSTITNOutID = dgvITNOutApproval.SelectedRows(0).Cells("dgclSTITNOutID").Value.ToString()
                strITNOutNo = dgvITNOutApproval.SelectedRows(0).Cells("dgclITNOutNo").Value.ToString()
                ItnDate = dgvITNOutApproval.SelectedRows(0).Cells("dgclITNOutDate").Value.ToString()
                strITNOutDate = New Date(ItnDate.Substring(6, 4), ItnDate.Substring(3, 2), ItnDate.Substring(0, 2))

                strReceivedLocation = dgvITNOutApproval.SelectedRows(0).Cells("dgclReceivedLocation").Value
                strReceivedLocationID = dgvITNOutApproval.SelectedRows(0).Cells("dgclSupplierID").Value
                strSupplierCOAID = dgvITNOutApproval.SelectedRows(0).Cells("dgclSupplierCOAID").Value

                strOperatorName = dgvITNOutApproval.SelectedRows(0).Cells("dgcOperatorName").Value
                If dgvITNOutApproval.SelectedRows(0).Cells("dgcTransportDate").Value IsNot Nothing Then
                    strTransportDate = dgvITNOutApproval.SelectedRows(0).Cells("dgcTransportDate").Value
                End If

                strVehicleNo = dgvITNOutApproval.SelectedRows(0).Cells("dgcVehicleNo").Value
                strMRCNo = dgvITNOutApproval.SelectedRows(0).Cells("dgcMRCNo").Value

                If Not dgvITNOutApproval.SelectedRows(0).Cells("dgclT0").Value Is DBNull.Value Then
                    strT0 = dgvITNOutApproval.SelectedRows(0).Cells("dgclT0").Value
                Else
                    strT0 = String.Empty
                End If
                If Not dgvITNOutApproval.SelectedRows(0).Cells("dgclT1").Value Is DBNull.Value Then
                    strT1 = dgvITNOutApproval.SelectedRows(0).Cells("dgclT1").Value
                Else
                    strT1 = String.Empty
                End If
                If Not dgvITNOutApproval.SelectedRows(0).Cells("dgclT2").Value Is DBNull.Value Then
                    strT2 = dgvITNOutApproval.SelectedRows(0).Cells("dgclT2").Value
                Else
                    strT2 = String.Empty
                End If
                If Not dgvITNOutApproval.SelectedRows(0).Cells("dgclT3").Value Is DBNull.Value Then
                    strT3 = dgvITNOutApproval.SelectedRows(0).Cells("dgclT3").Value
                Else
                    strT3 = String.Empty
                End If
                If Not dgvITNOutApproval.SelectedRows(0).Cells("dgclT4").Value Is DBNull.Value Then
                    strT4 = dgvITNOutApproval.SelectedRows(0).Cells("dgclT4").Value
                Else
                    strT4 = String.Empty
                End If


                strStatus = dgvITNOutApproval.SelectedRows(0).Cells("dgclStatus").Value.ToString()
                strRemarks = dgvITNOutApproval.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            End With
            InternalTransferNoteOUTFrm.BindITNOutDet_inApproval(strSTITNOutID)
            InternalTransferNoteOUTFrm.BindITNOutMast_inApproval(strSTITNOutID, strITNOutNo, strITNOutDate, strReceivedLocation, strStatus, strRemarks, strT0, strT1, strT2, strT3, strT4, strReceivedLocationID, strSupplierCOAID, strOperatorName, strTransportDate, strVehicleNo, strMRCNo)

            InternalTransferNoteOUTFrm.dtpITNDate.Enabled = False
            InternalTransferNoteOUTFrm.txtITNOUTNo.Enabled = False
            InternalTransferNoteOUTFrm.txtReceivedLocation.Enabled = False
            InternalTransferNoteOUTFrm.txtRemarks.Enabled = False
            InternalTransferNoteOUTFrm.txtStockCode.Enabled = False
            InternalTransferNoteOUTFrm.txtTransferoutQty.Enabled = False
            InternalTransferNoteOUTFrm.txtUnitPrice.Enabled = False
            InternalTransferNoteOUTFrm.cbApprovalStatus.Focus()
            InternalTransferNoteOUTFrm.tcITNOut.TabStop = False
            InternalTransferNoteOUTFrm.txtOperatorName.Enabled = False
            InternalTransferNoteOUTFrm.dtpTransportDate.Enabled = False
            InternalTransferNoteOUTFrm.txtVehicleNo.Enabled = False
            InternalTransferNoteOUTFrm.txtMRCNo.Enabled = False

            InternalTransferNoteOUTFrm.ShowDialog()
            BindITNOutDetails()
            'InternalTransferNoteOUTFrm.StartPosition = FormStartPosition.CenterScreen
            'InternalTransferNoteINFrm.BindITNInDet_inApproval(strSTITNInID)
            'InternalTransferNoteINFrm.BindITNInMast_inApproval(strSTITNInID, strITNInNo, strITNInDate, strSendersLocation, strStatus, strModifiedOn)
            'InternalTransferNoteINFrm.Show()
            'InternalTransferNoteINFrm.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindITNOutDetails()
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalTransferNoteOUTApprovalFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)


        lblviewITNDate.Text = rm.GetString("lblviewITNDate.Text")
        lblviewITNOutNo.Text = rm.GetString("lblviewITNOutNo.Text")
        lblviewReceivedLoc.Text = rm.GetString("lblviewReceivedLoc.Text")
        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
        plITNOutApproval.Text = rm.GetString("plITNOutApproval.Text")
        lblsearchby.Text = rm.GetString("lblsearchBy.Text")
        lblNoRecord.Text = rm.GetString("lblNoRecord.Text")

        dgvITNOutApproval.Columns("dgclITNOutDate").HeaderText = rm.GetString("dgvITNOutApproval.Columns(dgclITNOutDate).HeaderText")
        dgvITNOutApproval.Columns("dgclITNOutNo").HeaderText = rm.GetString("dgvITNOutApproval.Columns(dgclITNOutNo).HeaderText")
        dgvITNOutApproval.Columns("dgclReceivedLocation").HeaderText = rm.GetString("dgvITNOutApproval.Columns(dgclReceivedLocation).HeaderText")
        dgvITNOutApproval.Columns("dgclStatus").HeaderText = rm.GetString("dgvITNOutApproval.Columns(dgclStatus).HeaderText")
        dgvITNOutApproval.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvITNOutApproval.Columns(dgclViewDetails).HeaderText")



        'display a message if the culture is not supported
        'try passing bn (Bengali) for testing
        'MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub chkITNOutdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkITNOutdate.CheckedChanged


        If chkITNOutdate.Checked = True Then
            dtpviewITNDate.Enabled = True
        Else
            dtpviewITNDate.Enabled = False
        End If

    End Sub

End Class