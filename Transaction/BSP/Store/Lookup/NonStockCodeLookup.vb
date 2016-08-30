Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient

Public Class NonStockCodeLookup

    Public _lStockCode As String = String.Empty
    Public _lStockDesc As String = String.Empty
    Public _lStockUnitprice As String = String.Empty
    Public _lStockLastPurchasePrice As String = String.Empty
    Public _lUnit As String = String.Empty
    Public _lAvailableQty As Double = 0.0
    Public _lStockID As String = String.Empty
    Public _lPartNo As String = String.Empty
    Public _lCOAID As String = String.Empty
    Public _lVarianceCOAID As String = String.Empty
    Public _lMinQty As Double = 0.0
    Public _lAccountCode As String = String.Empty
    Public _lAccountDesc As String = String.Empty

    Private Sub BindStockCode()

        Dim dt As New DataTable
        Dim objNonStockIPRPPT As New NonStockIPRPPT
        Dim objNonStockIPRBOL As New NonStockIPRBOL

        objNonStockIPRPPT.StockCode = Me.txtStockCodesearch.Text
        objNonStockIPRPPT.StockDesc = Me.txtStockDescsearch.Text
        objNonStockIPRPPT.PartNo = Me.txtPartNosearch.Text

        Dim ds As New DataSet

        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M164" Or mdiparent.strMenuID = "M3" Then
            objNonStockIPRPPT.STCategory = NonStockIPRFrm.lStockCategoryID
            dt = objNonStockIPRBOL.GetStockCode(objNonStockIPRPPT)
            Me.dgvNonStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvNonStockCode.DataSource = dt
            Else
                Me.dgvNonStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If
        End If
    End Sub

    Private Sub ClearAfterSearch()

        txtStockDescsearch.Text = String.Empty
        txtStockCodesearch.Text = String.Empty
        txtPartNosearch.Text = String.Empty

    End Sub


    Private Sub btnStcokCodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStcokCodeSearch.Click

        BindStockCode()
        'ClearAfterSearch()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub dgvNonStockCode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNonStockCode.CellDoubleClick

        StockCodeGrid_Click()
        ClearAfterSearch()

    End Sub

    Private Sub NonStockCodeLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtStockCodesearch.Focus()
        BindStockCode()

    End Sub


    Private Sub StockCodeGrid_Click()

        If dgvNonStockCode.Rows.Count > 0 Then
            Me._lStockCode = Me.dgvNonStockCode.SelectedRows(0).Cells("gvStockCode").Value
            If Not Me.dgvNonStockCode.SelectedRows(0).Cells("gvStockDesc").Value.ToString() Is DBNull.Value Then
                Me._lStockDesc = Me.dgvNonStockCode.SelectedRows(0).Cells("gvStockDesc").Value
            Else
                Me._lStockDesc = String.Empty
            End If

            If dgvNonStockCode.SelectedRows(0).Cells("gvUnitPrice").Value.ToString() <> String.Empty Then
                Me._lStockUnitprice = Me.dgvNonStockCode.SelectedRows(0).Cells("gvUnitPrice").Value
            Else
                Me._lStockUnitprice = String.Empty
            End If

            'If dgvNonStockCode.SelectedRows(0).Cells("gvLastPurchasePrice").Value.ToString() <> String.Empty Then
            '    Me._lStockLastPurchasePrice = Me.dgvNonStockCode.SelectedRows(0).Cells("gvLastPurchasePrice").Value
            'Else
            '    Me._lStockLastPurchasePrice = String.Empty
            'End If

            If Me.dgvNonStockCode.SelectedRows(0).Cells("gvUnit").Value.ToString() <> String.Empty Then
                Me._lUnit = Me.dgvNonStockCode.SelectedRows(0).Cells("gvUnit").Value
            Else
                Me._lUnit = String.Empty
            End If

            Me._lStockID = Me.dgvNonStockCode.SelectedRows(0).Cells("gvStockID").Value

            If Me.dgvNonStockCode.SelectedRows(0).Cells("gvPartNo").Value.ToString() <> String.Empty Then
                Me._lPartNo = Me.dgvNonStockCode.SelectedRows(0).Cells("gvPartNo").Value
            Else
                Me._lPartNo = String.Empty
            End If

            '_lAvailableQty = Me.dgvNonStockCode.SelectedRows(0).Cells("gvAvailableQty").Value

            'If Me.dgvNonStockCode.SelectedRows(0).Cells("gvMinQty").Value.ToString() <> String.Empty Then
            '    _lMinQty = Me.dgvNonStockCode.SelectedRows(0).Cells("gvMinQty").Value
            'End If

            'If Me.dgvNonStockCode.SelectedRows(0).Cells("gvAccountCode").Value IsNot DBNull.Value Then
            '    _lAccountCode = Me.dgvNonStockCode.SelectedRows(0).Cells("gvAccountCode").Value
            'Else
            '    _lAccountCode = String.Empty
            'End If

            'If Not Me.dgvNonStockCode.SelectedRows(0).Cells("gvAccountDesc").Value Is DBNull.Value Then
            '    _lAccountDesc = Me.dgvNonStockCode.SelectedRows(0).Cells("gvAccountDesc").Value
            'Else
            '    _lAccountDesc = String.Empty
            'End If

            'Me._lCOAID = Me.dgvNonStockCode.SelectedRows(0).Cells("gvStockCOAID").Value
            'Me._lVarianceCOAID = Me.dgvNonStockCode.SelectedRows(0).Cells("gvVarianceCOAID").Value
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub NonStockCodeLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class