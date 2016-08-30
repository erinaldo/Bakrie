Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient

Public Class ITNOUTReportInterfacefrm
    Public Shared stroutID As String = String.Empty
    Public Shared strFrmName As String = String.Empty
    Private lReceivedLocation As String = String.Empty
    Private lReceivedLocationID As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNOUTReportInterfacefrm))
    Private Sub dgvITNOutView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvITNOut.CellContentClick
        If e.ColumnIndex = 8 Then

            stroutID = dgvITNOut.SelectedRows(0).Cells("dgclSTITNOutID").Value
            strFrmName = "ITNOUT"
            ReportODBCMethod.ShowDialog()

        End If
    End Sub

    Private Sub ITNOUTReportInterfacefrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        dtpviewITNDate.Format = DateTimePickerFormat.Custom
        dtpviewITNDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(dtpviewITNDate)
        BindITNOUTgrid()
    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNOUTReportInterfacefrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlITNoutRpt.CaptionText = rm.GetString("pnlITNoutRpt.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            lblNoRecord.Text = rm.GetString("lblNoRecord.Text")

            dgvITNOut.Columns("dgclITNOutDate").HeaderText = rm.GetString("dgvITNOut.Columns(dgclITNOutDate).HeaderText")
            dgvITNOut.Columns("dgclITNOutNo").HeaderText = rm.GetString("dgvITNOut.Columns(dgclITNOutNo).HeaderText")
            dgvITNOut.Columns("dgclReceivedLocation").HeaderText = rm.GetString("dgvITNOut.Columns(dgclReceivedLocation).HeaderText")
            dgvITNOut.Columns("ViewReport").HeaderText = rm.GetString("dgvITNOut.Columns(ViewReport).HeaderText")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITNOUTReportInterfacefrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub BindITNOUTgrid()
        dgvITNOut.DataSource = Nothing

        Dim dt As New DataTable
        Dim objITNOutPPT As New InternalTransferNoteOUTPPT
        Dim objITNOutBOL As New InternalTransferNoteOUTBOL
        With objITNOutPPT
            If chkITNDate.Checked = True Then
                .ITNDate = dtpviewITNDate.Value 'Format(dtpviewITNDate.Value, "MM/dd/yyyy")
            Else
                .ITNDate = Nothing
            End If
            .ItnOutNo = txtviewITNOUTNo.Text
            .Status = "APPROVED"

            .ReceivedLocation = txtviewReceLoc.Text
        End With
        dt = objITNOutBOL.STInternalTransferOutSelect(objITNOutPPT)

        If dt.Rows.Count > 0 Then
            lblNoRecord.Visible = False
            dgvITNOut.Visible = True
            dgvITNOut.AutoGenerateColumns = False
            dgvITNOut.DataSource = dt
        Else
            lblNoRecord.Visible = True
            dgvITNOut.Visible = False
            '' DisplayInfoMessage("msg01")

            ''MessageBox.Show("There is no Record found for your search criteria")
        End If

        
    End Sub



    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim ObjRecordExist As New Object
        Dim ObjITNOUT As New InternalTransferNoteOUTPPT
        Dim ObjITNOutBOL As New InternalTransferNoteOUTBOL
        ObjRecordExist = ObjITNOutBOL.ITNOutRecordIsExisT(ObjITNOUT)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("msg02")
            ''MsgBox("No Records Available!")
        Else
            strFrmName = "ITNOUTALL"
            ReportODBCMethod.ShowDialog()
            strFrmName = ""
        End If
    End Sub

   
    Private Sub btnviewRecLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewRecLoc.Click
        Dim objLoc As New SenderReceiverLocLookup()
        Dim result As DialogResult = SenderReceiverLocLookup.ShowDialog()
        If SenderReceiverLocLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lReceivedLocation = SenderReceiverLocLookup._lSenderLocation
            lReceivedLocationID = SenderReceiverLocLookup._lSenderLocationID
            txtviewReceLoc.Text = lReceivedLocation
        End If
    End Sub


    Private Sub txtviewReceLoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtviewReceLoc.Leave
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL
        Dim dt As New DataTable
        If txtviewReceLoc.Text <> String.Empty Then
            objITNOUTPPT.ReceivedLocation = txtviewReceLoc.Text
            dt = objITNOUTBOL.STITNOutRecLocGet(objITNOUTPPT)
            If dt.Rows.Count <> 0 Then

                If Not dt.Rows(0).Item("DistributionDescp") Is DBNull.Value Then
                    Me.txtviewReceLoc.Text = dt.Rows(0).Item("DistributionDescp").ToString()
                Else
                    Me.txtviewReceLoc.Text = String.Empty
                End If

                lReceivedLocationID = dt.Rows(0).Item("DistributionSetupID").ToString()

            Else
                DisplayInfoMessage("msg03")
                ''MessageBox.Show("Invalid Location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtviewReceLoc.Text = String.Empty
                txtviewReceLoc.Focus()
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindITNOUTgrid()
        'If dgvITNOut.Rows.Count < 1 Then
        '    DisplayInfoMessage("msg02")
        '    ''MessageBox.Show("There is no record found")
        'End If
    End Sub

    Private Sub ITNOUTReportInterfacefrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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