Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Public Class ReturnGoodsNoteApprovalFrm
    Public STRGNID As String = String.Empty
    Public SIVNO As String = String.Empty
    Public RGNNo As String = String.Empty
    Public RGNDate As String = String.Empty
    Public ViewSTIssueID As String = String.Empty
    Public Remarks As String = String.Empty
    Public Status As String = String.Empty
    Public RejectedStatus As String = String.Empty
    Private Sub ReturnGoodsNoteApprovalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        BindViewRGN()
    End Sub

    Private Sub BindViewRGN()
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDateSearch)
        Dim objRGNPPT As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        ds = ReturnGoodsNoteBOL.STRGNSearch(objRGNPPT, "YES")
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                lblNoRecord.Visible = False
                dgViewRGN.DataSource = ds.Tables(0)
            Else
                lblNoRecord.Visible = True
                dgViewRGN.DataSource = ds.Tables(0)
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objRGNPPT As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        If chkViewRGNDate.Checked = True Then
            objRGNPPT.RGNDateIsChecked = True
        Else
            objRGNPPT.RGNDateIsChecked = False
        End If
        objRGNPPT.RGNDate = Format(Me.dtpRGNDateSearch.Value, "MM/dd/yyyy")
        objRGNPPT.RGNNo = txtRGNNoSearch.Text.Trim()
        ds = ReturnGoodsNoteBOL.STRGNSearch(objRGNPPT, "YES")
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgViewRGN.AutoGenerateColumns = False
                dgViewRGN.DataSource = ds.Tables(0)
                lblNoRecord.Visible = False
            Else
                dgViewRGN.AutoGenerateColumns = False
                lblNoRecord.Visible = True
                dgViewRGN.DataSource = ds.Tables(0)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgViewRGN_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewRGN.CellContentClick
        If e.ColumnIndex = 8 Then
            Dim frmRGN As New ReturnGoodsNoteFrm()
            frmRGN.tbRGN.SelectedTab = frmRGN.tbpgRGN
            STRGNID = dgViewRGN.CurrentRow.Cells("dgclSTRGNID").Value
            If Not dgViewRGN.CurrentRow.Cells("dgclSIVNO").Value Is DBNull.Value Then
                SIVNO = dgViewRGN.CurrentRow.Cells("dgclSIVNO").Value
            End If
            RGNNo = dgViewRGN.CurrentRow.Cells("dgclRGNNo").Value
            RGNDate = dgViewRGN.CurrentRow.Cells("dgclRGNDate").Value
            ViewSTIssueID = dgViewRGN.CurrentRow.Cells("dgclViewSTIssueID").Value
            If Not dgViewRGN.CurrentRow.Cells("dgclRemarks").Value Is DBNull.Value Then
                Remarks = dgViewRGN.CurrentRow.Cells("dgclRemarks").Value
            End If
            Status = dgViewRGN.CurrentRow.Cells("dgclStatus").Value
            If Not dgViewRGN.CurrentRow.Cells("dgclRejectedStatus").Value Is DBNull.Value Then
                RejectedStatus = dgViewRGN.CurrentRow.Cells("dgclRejectedStatus").Value.ToString()
            End If
            frmRGN.BindDGRGNApprovalMode(STRGNID, SIVNO, RGNNo, RGNDate, ViewSTIssueID, Remarks, Status, RejectedStatus) '
            frmRGN.txtRGNNo.Enabled = False
            frmRGN.txtRemarks.Enabled = False
            frmRGN.txtSIVNo.Enabled = False
            frmRGN.dtpRGNDate.Enabled = False
            frmRGN.grpRGNStockDetails.Enabled = False

            frmRGN.tbRGN.TabStop = False
            frmRGN.cmbStatus.Focus()

           
            frmRGN.ShowDialog()
            BindViewRGN()
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReturnGoodsNoteApprovalFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText") 'lblSearchBy
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")
            chkViewRGNDate.Text = rm.GetString("chkViewRGNDate.Text")
            lblRGNNoSerach.Text = rm.GetString("lblRGNNoSerach.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")

            dgViewRGN.Columns("dgclSIVNO").HeaderText = rm.GetString("dgViewRGN.Columns(dgclSIVNO).HeaderText")
            dgViewRGN.Columns("dgclRGNDate").HeaderText = rm.GetString("dgViewRGN.Columns(dgclRGNDate).HeaderText")
            dgViewRGN.Columns("dgclRGNNo").HeaderText = rm.GetString("dgViewRGN.Columns(dgclRGNNo).HeaderText")
            dgViewRGN.Columns("dgclStatus").HeaderText = rm.GetString("dgViewRGN.Columns(dgclStatus).HeaderText")
            dgViewRGN.Columns("dgclRemarks").HeaderText = rm.GetString("dgViewRGN.Columns(dgclRemarks).HeaderText")
            dgViewRGN.Columns("dgclViewDetails").HeaderText = rm.GetString("dgViewRGN.Columns(dgclViewDetails).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  
    Private Sub ReturnGoodsNoteApprovalFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    
    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Me.Cursor = Cursors.WaitCursor
        'code here
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chkViewRGNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewRGNDate.CheckedChanged

        If chkViewRGNDate.Checked = True Then
            dtpRGNDateSearch.Enabled = True
        Else
            dtpRGNDateSearch.Enabled = False
        End If

    End Sub
End Class
