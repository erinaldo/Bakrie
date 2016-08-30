Imports Common_BOL
Imports Store_PPT
Imports Store_BOL
Imports System.Data.SqlClient

Public Class CategoryLookup

    Public _lStockCategory As String = String.Empty
    Public _lStockCategoryCode As String = String.Empty
    Public _lStockCategoryID As String = String.Empty
    Public _lStockCOAID As String = String.Empty
    Public _lVarianceCOAID As String = String.Empty
   


    Public Sub BindStockCategory()

        Dim dt As New DataTable
        Dim objStkCategoryPPT As New IPRPPT
        Dim objStkCategoryBOL As New IPRBOL
        objStkCategoryPPT.STCategoryCode = Me.txtCategoryCode.Text.Trim
        objStkCategoryPPT.STCategory = Me.txtCategoryDesc.Text.Trim
        dt = objStkCategoryBOL.GetStockCategory(objStkCategoryPPT)
        Me.dgvStockCategory.AutoGenerateColumns = False
        If dt.Rows.Count > 0 Then
            lblNoRecord.Visible = False
            Me.dgvStockCategory.DataSource = dt
        Else

            Me.dgvStockCategory.DataSource = dt
            lblNoRecord.Visible = True
        End If

    End Sub

    Public Sub BindNonStockCategory()

        Dim dt As New DataTable
        Dim objStkCategoryPPT As New NonStockIPRPPT
        Dim objStkCategoryBOL As New NonStockIPRBOL
        objStkCategoryPPT.STCategoryCode = Me.txtCategoryCode.Text.Trim
        objStkCategoryPPT.STCategory = Me.txtCategoryDesc.Text.Trim
        dt = objStkCategoryBOL.GetNonStockCategory(objStkCategoryPPT, "NO")
        Me.dgvStockCategory.AutoGenerateColumns = False

        If dt.Rows.Count > 0 Then
            lblNoRecord.Visible = False
            Me.dgvStockCategory.DataSource = dt
        Else

            Me.dgvStockCategory.DataSource = dt
            lblNoRecord.Visible = True
        End If

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CategoryLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        IPRPPT.strGlobalCategoryID = String.Empty
        IPRPPT.strGlobalCategoryDesc = String.Empty
        IPRPPT.strGlobalCategoryCode = String.Empty

        NonStockIPRPPT.strGlobalCategoryID = String.Empty
        NonStockIPRPPT.strGlobalCategoryDesc = String.Empty
        NonStockIPRPPT.strGlobalCategoryCode = String.Empty


        txtCategoryCode.Focus()
        If NonStockIPRFrm.StrFrmName = "NonStockIPR" Then
            BindNonStockCategory()
        Else
            BindStockCategory()
        End If


    End Sub

    Private Sub btnCategorySearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click

        If NonStockIPRFrm.StrFrmName = "NonStockIPR" Then
            BindNonStockCategory()
        Else
            BindStockCategory()
            'ClearAfterSearch()
        End If
    End Sub

    Private Sub ClearAfterSearch()

        txtCategoryCode.Text = String.Empty
        txtCategoryDesc.Text = String.Empty

    End Sub

    Private Sub dgvStockCategory_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStockCategory.CellDoubleClick

        If dgvStockCategory.RowCount > 0 Then

            If Not dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryDesc").Value Is DBNull.Value Then
                _lStockCategory = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryDesc").Value.ToString()
                IPRPPT.strGlobalCategoryDesc = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryDesc").Value.ToString()
            Else
                _lStockCategory = String.Empty
            End If
            _lStockCategoryCode = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryCode").Value
            IPRPPT.strGlobalCategoryCode = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryCode").Value
            _lStockCategoryID = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryID").Value
            IPRPPT.strGlobalCategoryID = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryID").Value
            If dgvStockCategory.SelectedRows(0).Cells("gvStockCOAID").Value.ToString() <> String.Empty Then
                _lStockCOAID = dgvStockCategory.SelectedRows(0).Cells("gvStockCOAID").Value

            End If
            If dgvStockCategory.SelectedRows(0).Cells("gvVarianceCOAID").Value.ToString() <> String.Empty Then
                _lVarianceCOAID = Me.dgvStockCategory.SelectedRows(0).Cells("gvVarianceCOAID").Value.ToString()
            End If
            ClearAfterSearch()
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

   
    Private Sub dgvStockCategory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Then

            If dgvStockCategory.RowCount > 0 Then

                If Not dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryDesc").Value Is DBNull.Value Then
                    _lStockCategory = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryDesc").Value.ToString()
                    IPRPPT.strGlobalCategoryDesc = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryDesc").Value.ToString()
                Else
                    _lStockCategory = String.Empty
                End If
                _lStockCategoryCode = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryCode").Value
                IPRPPT.strGlobalCategoryCode = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryCode").Value
                _lStockCategoryID = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryID").Value
                IPRPPT.strGlobalCategoryID = dgvStockCategory.SelectedRows(0).Cells("gvSTCategoryID").Value
                If dgvStockCategory.SelectedRows(0).Cells("gvStockCOAID").Value.ToString() <> String.Empty Then
                    _lStockCOAID = dgvStockCategory.SelectedRows(0).Cells("gvStockCOAID").Value

                End If
                If dgvStockCategory.SelectedRows(0).Cells("gvVarianceCOAID").Value.ToString() <> String.Empty Then
                    _lVarianceCOAID = Me.dgvStockCategory.SelectedRows(0).Cells("gvVarianceCOAID").Value.ToString()
                End If
                ClearAfterSearch()
                Me.DialogResult = DialogResult.OK
            End If
        End If
        e.Handled = True
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvStockCategory, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvStockCategory, e)
        'End If

    End Sub

    Private Sub CategoryLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgvStockCategory_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgvStockCategory, e)
        End If
    End Sub
End Class