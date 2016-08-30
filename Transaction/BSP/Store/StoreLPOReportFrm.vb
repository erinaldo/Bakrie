Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient
Public Class StoreLPOReportFrm
    Public Shared strSTLPONo As String = String.Empty
    Public Shared strUsageCOAID As String = String.Empty
    Public Shared strUsageCOACode As String = String.Empty
    Public Shared strSTCategoryID As String = String.Empty

    Private Sub StoreLPOReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL

        dtpLPOViewDate.Format = DateTimePickerFormat.Custom
        dtpLPOViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(dtpLPOViewDate)

        'dtpLPOViewDate.Enabled = True

       
        BindLPOView()

        chkLPOViewDate.Focus()

    End Sub


    Private Sub btnLPOViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLPOViewSearch.Click

        BindLPOView()
    End Sub

    Public Sub BindLPOView()
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable

        With objLPOPPT

            If chkLPOViewDate.Checked = True Then
                dtpLPOViewDate.Enabled = True
                .LPODate = dtpLPOViewDate.Value 'Format(Me.dtpLPOViewDate.Value, "MM/dd/yyyy")
            Else
                'dtpLPOViewDate.Enabled = False
                .LPODate = Nothing
            End If
            .LPONo = String.Empty

            If chkLPOViewDate.Checked = True Then
                .LPODate = dtpLPOViewDate.Value 'Format(Me.dtpLPOViewDate.Value, "MM/dd/yyyy")
            Else
                .LPODate = Nothing
            End If

            .LPONo = Trim(Me.txtLPOViewNo.Text)
            .Status = ""

        End With

        ''dt = objLPOBOL.GetLPODetailsForReport(objLPOPPT)
        ''If dt.Rows.Count <> 0 Then
        ''    dgvLPOView.AutoGenerateColumns = False
        ''    Me.dgvLPOView.DataSource = dt
        ''    lblView.Visible = False
        ''    'Else
        ''    'ClearGridView(dgvLPOView) '''''clear the records from grid view
        ''    'lblView.Visible = True
        ''    Exit Sub
        ''End If

        dt = objLPOBOL.GetLPODetailsForReport(objLPOPPT)
        If dt.Rows.Count = 0 Then
            txtLPOViewNo.Text = String.Empty
            lblView.Visible = True
        Else
            lblView.Visible = False
        End If

        dgvLPOView.AutoGenerateColumns = False
        Me.dgvLPOView.DataSource = dt


        Exit Sub
        chkLPOViewDate.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvLPOView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLPOView.CellContentClick
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        Dim dt As New DataTable

        If e.ColumnIndex = 22 Then
            With objLPOPPT
                strSTLPONo = dgvLPOView.SelectedRows(0).Cells("dgclLPONo").Value.ToString()
                strSTCategoryID = dgvLPOView.SelectedRows(0).Cells("dgclSTCategoryID").Value.ToString()
                'strUsageCOAID = dgvLPOView.SelectedRows(0).Cells("dgclUsageCOAID").Value.ToString()
                ''strUsageCOACode = dgvLPOView.SelectedRows(0).Cells("dgclUsageCOACode").Value.ToString()
                StoreLPOReportView.Show()
            End With

        End If

    End Sub

    Private Sub StoreLPOReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkLPOViewDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLPOViewDate.CheckedChanged

        If chkLPOViewDate.Checked = True Then
            dtpLPOViewDate.Enabled = True
        Else
            dtpLPOViewDate.Enabled = False
        End If

    End Sub

End Class