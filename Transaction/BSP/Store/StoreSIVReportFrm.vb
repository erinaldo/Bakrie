Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Public Class StoreSIVReportFrm
    Public Shared strSIVNO As String = String.Empty
    Private Sub StoreSIVReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        BindViewIssueVoucher()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Me.Cursor = Cursors.WaitCursor
        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        If chkViewSIVDate.Checked = True Then
            objStoreIssueVoucherPPT.BViewSIVDate = True
        Else
            objStoreIssueVoucherPPT.BViewSIVDate = False
        End If
        objStoreIssueVoucherPPT.SIVDateSearch = Format(Me.txtSIVDateSearch.Value, "yyyy/MM/dd") '"MM/dd/yyyy")
        objStoreIssueVoucherPPT.SIVDateSearch = txtSIVDateSearch.Value.ToString("yyyy/MM/dd")
        ' objStoreIssueVoucherPPT.SIVDate = CDate(txtSIVDateSearch.Value) ' Format(txtSIVDateSearch.Value, "MM/dd/yyyy")
        objStoreIssueVoucherPPT.SIVNOSearch = txtSIVNoSearch.Text


        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.SIVSearchForReport(objStoreIssueVoucherPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            lblNoRecord.Visible = False
            dgViewIssueVoucher.AutoGenerateColumns = False
            dgViewIssueVoucher.DataSource = ds.Tables(0)
        Else
            dgViewIssueVoucher.DataSource = ds.Tables(0)
            lblNoRecord.Visible = True
        End If
        Me.Cursor = Cursors.Arrow

    End Sub


    Private Sub BindViewIssueVoucher()

        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        'objStoreIssueVoucherPPT.StatusSearch = "APPROVED"
        ds = StoreIssueVoucherBOL.SIVSearchForReport(objStoreIssueVoucherPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            lblNoRecord.Visible = False
            dgViewIssueVoucher.AutoGenerateColumns = False
            dgViewIssueVoucher.DataSource = ds.Tables(0)
        Else
            dgViewIssueVoucher.DataSource = ds.Tables(0)
            lblNoRecord.Visible = True
        End If
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.txtSIVDateSearch)

    End Sub


    Private Sub dgViewIssueVoucher_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewIssueVoucher.CellContentClick

        If e.ColumnIndex = 3 Then
            Dim frmSIV As New StoreIssueVoucherFrm()
           
            strSIVNO = dgViewIssueVoucher.CurrentRow.Cells("SIVNO").Value.ToString()
            StoreSIVReportView.Show()
        End If

    End Sub


    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreSIVReportFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            pnlSIVApproval.CaptionText = rm.GetString("pnlSIVApproval.CaptionText") 'lblSearchBy
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")
            chkViewSIVDate.Text = rm.GetString("chkViewSIVDate.Text")
            lblSIVNoSerach.Text = rm.GetString("lblSIVNoSerach.Text")

            'lblRemarksSearch.Text = rm.GetString("lblRemarksSearch.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")

            dgViewIssueVoucher.Columns("SIVNO").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(SIVNO).HeaderText")
            dgViewIssueVoucher.Columns("SIVDate").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(SIVDate).HeaderText")
            dgViewIssueVoucher.Columns("Status").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(Status).HeaderText")
            dgViewIssueVoucher.Columns("ViewDetails").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(ViewDetails).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StoreSIVReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkViewSIVDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewSIVDate.CheckedChanged

        If chkViewSIVDate.Checked = True Then
            txtSIVDateSearch.Enabled = True
        Else
            txtSIVDateSearch.Enabled = False
        End If

    End Sub

End Class