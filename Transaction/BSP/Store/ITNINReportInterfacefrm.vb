Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient

Public Class ITNINReportInterfacefrm


    Public Shared strINID As String = String.Empty
    Public Shared strFrmName As String = String.Empty
    Private lSenderLocation As String = String.Empty
    Private lSenderLocationID As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNINReportInterfacefrm))


    Private Sub dgvITNInView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNInReport.CellContentClick
        If e.ColumnIndex = 8 Then

            ''strINID = dgvITNInReport.SelectedRows.Item("dgclSTITNInID").value

            strINID = dgvITNInReport.SelectedRows(0).Cells("dgclSTITNInID").Value
            strFrmName = "ITNIN"
            ReportODBCMethod.ShowDialog()

        End If
    End Sub

    Private Sub ITNINReportInterfacefrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        dtpviewITNDate.Format = DateTimePickerFormat.Custom
        dtpviewITNDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(dtpviewITNDate)
        BindITNINViewgrid()
    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNINReportInterfacefrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlITNINRpt.CaptionText = rm.GetString("pnlITNINRpt.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")

            dgvITNInReport.Columns("dgclITNDate").HeaderText = rm.GetString("dgvITNInReport.Columns(dgclITNDate).HeaderText")
            dgvITNInReport.Columns("dgclITNInNo").HeaderText = rm.GetString("dgvITNInReport.Columns(dgclITNInNo).HeaderText")
            dgvITNInReport.Columns("dgclSendersLocation").HeaderText = rm.GetString("dgvITNInReport.Columns(dgclSendersLocation).HeaderText")
            dgvITNInReport.Columns("ViewReport").HeaderText = rm.GetString("dgvITNInReport.Columns(ViewReport).HeaderText")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNINReportInterfacefrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub BindITNINViewgrid()
        dgvITNInReport.DataSource = Nothing
        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        With objITNINPPT
            If chkITNDate.Checked = True Then
                .ITNDate = dtpviewITNDate.Value
            Else
                .ITNDate = Nothing
            End If
            .ItnInNo = txtviewITNInNo.Text.Trim
            .Status = "Approved"
            .SendersLocation = txtviewSendLoc.Text.Trim
        End With
        dt = objITNINBOL.STInternalTransferInSelect(objITNINPPT)
        dgvITNInReport.AutoGenerateColumns = False
        dgvITNInReport.DataSource = dt
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindITNINViewgrid()
        If dgvITNInReport.Rows.Count < 1 Then
            DisplayInfoMessage("msg02")
            ''MsgBox("No Records Available!")
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

    Private Sub txtviewSendLoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtviewSendLoc.Leave
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        Dim dt As New DataTable
        If txtviewSendLoc.Text <> String.Empty Then
            objITNINPPT.SendersLocation = txtviewSendLoc.Text
            dt = objITNINBOL.STITNInSendLocGet(objITNINPPT)
            If dt.Rows.Count <> 0 Then

                If Not dt.Rows(0).Item("DistributionDescp") Is DBNull.Value Then
                    Me.txtviewSendLoc.Text = dt.Rows(0).Item("DistributionDescp").ToString()
                Else
                    Me.txtviewSendLoc.Text = String.Empty
                End If

                lSenderLocationID = dt.Rows(0).Item("DistributionSetupID").ToString()
 

            Else
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("Invalid Location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtviewSendLoc.Text = String.Empty
                txtviewSendLoc.Focus()
            End If
        End If

    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        strFrmName = "ITNINALL"
        ReportODBCMethod.ShowDialog()
    End Sub

    Private Sub ITNINReportInterfacefrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkITNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkITNDate.CheckedChanged

        If chkITNDate.Checked = True Then
            dtpviewITNDate.Enabled = True
        Else
            dtpviewITNDate.Enabled = False
        End If

    End Sub

End Class