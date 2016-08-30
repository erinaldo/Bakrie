Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class StockAdjustmentApprovalFrm

    Public strSTAdjustmentID As String = String.Empty
    Public strAdjustmentNo As String = String.Empty
    Public strBeritaAcaraAudit As String = String.Empty
    Public strStockId As String
    Public strAdjustmentDate As String = String.Empty
    Public strStkCode As String = Nothing
    Public strStatus As String = String.Empty
    Public strRejectedReason As String = String.Empty
    Public strAdjQty As Double
    Public strAdjValue As Double
    Public strCOAID As String = String.Empty
    Public strDIVID As String = String.Empty
    Public strYopID As String = String.Empty
    Public strBlockID As String = String.Empty
    Public strT0 As String = String.Empty
    Public strT1 As String = String.Empty
    Public strT2 As String = String.Empty
    Public strT3 As String = String.Empty
    Public strT4 As String = String.Empty
    Public strRemarks As String = String.Empty
    Public strModifiedOn As String = String.Empty
    Public strID As Integer
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindAdjustmentDetails()
    End Sub
    Public Sub BindAdjustmentDetails()
        dgvAdjustmentApproval.DataSource = Nothing
        Dim objStkAdjustApprovalPPT As New StockAdjustmentApprovalPPT
        Dim objStkAdjustApprovalBOL As New StockAdjustmentApprovalBOL
        Dim dt As New DataTable
        If chkAdjustDate.Checked = True Then
            dtpAdjustmentViewDate.Enabled = True
            objStkAdjustApprovalPPT.AdjustmentDate = Format(Me.dtpAdjustmentViewDate.Value, "MM/dd/yyyy") 'Me.dtpLPOViewDate.Value 
        Else
            dtpAdjustmentViewDate.Enabled = False
            objStkAdjustApprovalPPT.AdjustmentDate = Nothing
        End If
        With objStkAdjustApprovalPPT
            .AdjustmentNo = txtAdjustNoSearch.Text
            .Status = "OPEN"
        End With
        If chkAdjustDate.Checked = True Then
            objStkAdjustApprovalPPT.AdjustmentDate = Format(Me.dtpAdjustmentViewDate.Value, "MM/dd/yyyy") 'Me.dtpLPOViewDate.Value
        Else
            objStkAdjustApprovalPPT.AdjustmentDate = Nothing
        End If
        dt = objStkAdjustApprovalBOL.StkAdjustApprovalGet(objStkAdjustApprovalPPT)
        If dt.Rows.Count <> 0 Then
            dgvAdjustmentApproval.AutoGenerateColumns = False
            dgvAdjustmentApproval.DataSource = dt
            Exit Sub
        End If
    End Sub
    Private Sub dgvAdjustmentApproval_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdjustmentApproval.CellContentClick
        'Dim StkAdjustDate As String
        Dim objStkAdjustPPT As New StockAdjustmentPPT
        Dim objStkAdjustBOL As New StockAdjustmentBOL
        Dim dt As New DataTable
        If e.ColumnIndex = 5 Then

            Dim frmSTA As New StockAdjustmentFrm()
            frmSTA.cmbStatus.Text = "Select Status"
           
            With objStkAdjustPPT

                strAdjustmentNo = dgvAdjustmentApproval.SelectedRows(0).Cells("dgclAdjustmentNo").Value.ToString()
                strAdjustmentDate = dgvAdjustmentApproval.SelectedRows(0).Cells("dgclAdjustmentDate").Value.ToString()
                strBeritaAcaraAudit = dgvAdjustmentApproval.SelectedRows(0).Cells("dgcBeritaAcaraAudit").Value.ToString()
                strStatus = dgvAdjustmentApproval.SelectedRows(0).Cells("dgclStatus").Value.ToString()
                strRemarks = dgvAdjustmentApproval.SelectedRows(0).Cells("dgclRemarks").Value.ToString()

            End With
            StockAdjustmentFrm.BindAdjustMast_inApproval(strSTAdjustmentID, strStockId, strAdjustmentNo, strAdjustmentDate, strStatus, strRejectedReason, strAdjQty, strAdjValue, strCOAID, strDIVID, strYopID, strBlockID, strT0, strT1, strT2, strT3, strT4, strRemarks, strModifiedOn, strID, strStkCode, strBeritaAcaraAudit)
            StockAdjustmentFrm.grpRGN.Enabled = False
            StockAdjustmentFrm.GroupBox2.Enabled = False
            StockAdjustmentFrm.GroupBox4.Enabled = False
            StockAdjustmentFrm.cmbStatus.Focus()
            StockAdjustmentFrm.tbStockAdjustment.TabStop = False
            StockAdjustmentFrm.txtBeritaAcaraAudit.Enabled = False
            StockAdjustmentFrm.cmbStatus.Focus()
            StockAdjustmentFrm.ShowDialog()
            StockAdjustmentFrm.StartPosition = FormStartPosition.CenterScreen
            BindAdjustmentDetails()
        End If
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StockAdjustmentApprovalFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblAdjustmentNoSerach.Text = rm.GetString("lblAdjustmentNoSerach.Text")

            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")

            '''''''''''''GRID CAPTIONS'''''''''''''''''''''''''''''
           
            dgvAdjustmentApproval.Columns("dgclAdjustmentNo").HeaderText = rm.GetString("dgvAdjustmentApproval.Columns(dgclAdjustmentNo).HeaderText")
            dgvAdjustmentApproval.Columns("dgclAdjustmentDate").HeaderText = rm.GetString("dgvAdjustmentApproval.Columns(dgclAdjustmentDate).HeaderText")
            dgvAdjustmentApproval.Columns("dgclStatus").HeaderText = rm.GetString("dgvAdjustmentApproval.Columns(dgclStatus).HeaderText")
            dgvAdjustmentApproval.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvAdjustmentApproval.Columns(dgclViewDetails).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StockAdjustmentApprovalFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        BindAdjustmentDetails()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

 
    Private Sub chkAdjustDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustDate.CheckedChanged
        If chkAdjustDate.Checked = True Then
            dtpAdjustmentViewDate.Enabled = True
        Else
            dtpAdjustmentViewDate.Enabled = False
        End If
    End Sub

    Private Sub StockAdjustmentApprovalFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class