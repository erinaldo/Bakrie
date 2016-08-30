Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports System.Configuration

Public Class StoreISRReportFrm
    Public Shared strSTISRNo As String = String.Empty
    Public Shared strUsageCOAID As String = String.Empty


    Private Sub StoreISRReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpviewISRDate.Format = DateTimePickerFormat.Custom
        dtpviewISRDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(dtpviewISRDate)
        GridISRViewBind()
    End Sub

    Private Sub GridISRViewBind()

        Dim objISRPPT As New InternalServiceRequisitionPPT
        Dim objISRBOL As New InternalServiceRequisitionBOL
        Dim dt As New DataTable
        lblRecordNotFound.Visible = False
        With objISRPPT

            If chkviewISRDate.Checked = True Then
                .BViewISRDate = True
            Else
                .BViewISRDate = False
            End If
            .ISRDateSearch = dtpviewISRDate.Value 'Format(Me.dtpviewISRDate.Value, "yyyy/MM/dd") 
            .ISRNOSearch = txtviewISRNo.Text.Trim()

        End With

        dt = objISRBOL.GetISRDetails(objISRPPT)
        If dt.Rows.Count = 0 Then

            txtviewISRNo.Text = String.Empty
            lblRecordNotFound.Visible = True
        Else
            lblRecordNotFound.Visible = False

        End If

        Me.dgvviewISR.DataSource = dt
        dgvviewISR.AutoGenerateColumns = False
        'Else
        '    ClearGridView(dgvviewISR) '''''clear the records from grid view
        Exit Sub
        'End If

    End Sub
    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnviewISRSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewISRSearch.Click
        GridISRViewBind()
    End Sub

    Private Sub dgvviewISR_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvviewISR.CellContentClick
        Dim objISR As New InternalServiceRequisitionPPT
        Dim objisrBOL As New InternalServiceRequisitionBOL

        Dim dt As New DataTable
        Dim strSTISRID As String = String.Empty
        If e.ColumnIndex = 2 Then
            With objISR
                strSTISRNo = dgvviewISR.SelectedRows(0).Cells("ISRNo").Value.ToString()
                strSTISRID = dgvviewISR.SelectedRows(0).Cells("STISRID").Value.ToString()
                objISR.STISRID = strSTISRID
                dt = objisrBOL.ISRDetailsGet(objISR)
                If dt.Rows.Count > 0 Then
                    strUsageCOAID = dt.Rows(0).Item("COAID")
                    StoreISRReportView.ShowDialog()
                End If
            End With
        End If

    End Sub

        Private Sub StoreISRReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkviewISRDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkviewISRDate.CheckedChanged

        If chkviewISRDate.Checked = True Then
            dtpviewISRDate.Enabled = True
        Else
            dtpviewISRDate.Enabled = False
        End If

    End Sub

End Class