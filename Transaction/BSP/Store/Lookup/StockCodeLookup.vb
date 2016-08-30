Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient

Public Class StockCodeLookUp

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
    Public _UOM As String = String.Empty


    Private Sub BindStockCode()

        Dim dt As New DataTable
        Dim objStkCategoryPPT As New IPRPPT
        Dim objStkCategoryBOL As New IPRBOL
        Dim objStkAdjustPPT As New StockAdjustmentPPT
        Dim objStkAdjustBOL As New StockAdjustmentBOL
        Dim objStkLocalPPT As New LocalPurchaseOrderPPT
        Dim objStkLPOBOL As New LocalPurchaseOrderBOL
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL
        Dim objITNOUTPPT As New InternalTransferNoteOUTPPT
        Dim objITNOUTBOL As New InternalTransferNoteOUTBOL

        objITNINPPT.StockCode = Me.txtStockCodesearch.Text
        objITNINPPT.StockDesc = Me.txtStockDescsearch.Text
        objITNINPPT.PartNo = Me.txtPartNosearch.Text

        objITNOUTPPT.StockCode = Me.txtStockCodesearch.Text
        objITNOUTPPT.StockDesc = Me.txtStockDescsearch.Text
        objITNOUTPPT.PartNo = Me.txtPartNosearch.Text

        Dim ds As New DataSet
        objStkCategoryPPT.StockCode = Me.txtStockCodesearch.Text
        objStkCategoryPPT.StockDesc = Me.txtStockDescsearch.Text
        objStkCategoryPPT.PartNo = Me.txtPartNosearch.Text

        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M1" Then
            objStkCategoryPPT.STCategory = InternalPurchaseRequisitionFrm.lStockCategoryID
            dt = objStkCategoryBOL.GetStockCategory(objStkCategoryPPT)
            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

            ''ElseIf mdiparent.strMenuID = "M2" Then  'LPO Form
            ''    'objStkCategoryPPT.STCategory = LocalPuchaseOrderFrm.lStockCategoryID
            ''    'dt = objStkLPOBOL.GetStockCode(objStkLocalPPT)
            ''    'Me.dgvStockCode.AutoGenerateColumns = False
            ''    'Me.dgvStockCode.DataSource = dt
            ''    dt = objITNINBOL.STITNInStockCodeGet(objITNINPPT)

            ''    Me.dgvStockCode.AutoGenerateColumns = False
            ''    If dt.Rows.Count > 0 Then
            ''        lblNoRecord.Visible = False
            ''        Me.dgvStockCode.DataSource = dt
            ''    Else
            ''        Me.dgvStockCode.DataSource = dt
            ''        lblNoRecord.Visible = True
            ''    End If

        ElseIf mdiparent.strMenuID = "M2" Then 'LPO Form
            'IPRPPT.strGlobalCategoryID = StoreIssueVoucherFrm.psSIVStockCategoryIDForStock
            dt = objStkCategoryBOL.GetStockCategory(objStkCategoryPPT)

            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If


        ElseIf mdiparent.strMenuID = "M3" Then 'ISR Form
            dt = objStkCategoryBOL.GetStockCategory(objStkCategoryPPT)
            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

        ElseIf mdiparent.strMenuID = "M6" Then 'SIV Form
            'IPRPPT.strGlobalCategoryID = StoreIssueVoucherFrm.psSIVStockCategoryIDForStock
            dt = objStkCategoryBOL.GetStockCategory(objStkCategoryPPT)

            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

        ElseIf mdiparent.strMenuID = "M8" Then
            'objStkCategoryPPT.STCategory = StoreIssueVoucherFrm.lSIVStockCategoryID
            dgvStockCode.DataSource = Nothing
            dt = objITNINBOL.STITNInStockCodeGet(objITNINPPT)

            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

        ElseIf mdiparent.strMenuID = "M9" Then
            'objStkCategoryPPT.STCategory = StoreIssueVoucherFrm.lSIVStockCategoryID
            dt = objITNOUTBOL.STITNOutStockCodeGet(objITNOUTPPT)

            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

        ElseIf mdiparent.strMenuID = "M10" Then  'STA Form
            ' objStkAdjustPPT.stockID = StockAdjustmentFrm.lStockId
            dt = objITNINBOL.STITNInStockCodeGet(objITNINPPT)

            Me.dgvStockCode.AutoGenerateColumns = False
            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

            'ds = objStkAdjustBOL.GetStockCode(objStkAdjustPPT)
            '' Me.dgvStockCode.AutoGenerateColumns = False
            'Me.dgvStockCode.DataSource = ds.Tables(0)
            'Me.dgvStockCode.AutoGenerateColumns = False
        End If

        Me.txtStockCodesearch.Focus()

    End Sub

    Private Sub btnStcokCodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStcokCodeSearch.Click

        BindStockCode()
        'ClearAfterSearch()

    End Sub

    Private Sub ClearAfterSearch()

        txtStockDescsearch.Text = String.Empty
        txtStockCodesearch.Text = String.Empty
        txtPartNosearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub dgvStockCode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStockCode.CellDoubleClick

        StockCodeGrid_Click()
        ClearAfterSearch()

    End Sub

    Private Sub StockCodeLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ClearAfterSearch()
        BindStockCode()
        Me.txtStockCodesearch.Focus()

    End Sub

    Private Sub dgvStockCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Then
            StockCodeGrid_Click()
        End If
        e.Handled = True

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvStockCode, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvStockCode, e)
        'End If

    End Sub

    Private Sub StockCodeGrid_Click()

        If dgvStockCode.Rows.Count > 0 Then
            Me._lStockCode = Me.dgvStockCode.SelectedRows(0).Cells("gvStockCode").Value
            If Not Me.dgvStockCode.SelectedRows(0).Cells("gvStockDesc").Value.ToString() Is DBNull.Value Then
                Me._lStockDesc = Me.dgvStockCode.SelectedRows(0).Cells("gvStockDesc").Value
            Else
                Me._lStockDesc = String.Empty
            End If

            If dgvStockCode.SelectedRows(0).Cells("gvUnitPrice").Value.ToString() <> String.Empty Then
                Me._lStockUnitprice = Me.dgvStockCode.SelectedRows(0).Cells("gvUnitPrice").Value
            Else
                Me._lStockUnitprice = String.Empty
            End If

            If dgvStockCode.SelectedRows(0).Cells("gvLastPurchasePrice").Value.ToString() <> String.Empty Then
                Me._lStockLastPurchasePrice = Me.dgvStockCode.SelectedRows(0).Cells("gvLastPurchasePrice").Value
            Else
                Me._lStockLastPurchasePrice = String.Empty
            End If

            If Me.dgvStockCode.SelectedRows(0).Cells("gvUnit").Value.ToString() <> String.Empty Then
                Me._lUnit = Me.dgvStockCode.SelectedRows(0).Cells("gvUnit").Value
            Else
                Me._lUnit = String.Empty
            End If

            If Me.dgvStockCode.SelectedRows(0).Cells("gvUom").Value.ToString() <> String.Empty Then
                Me._UOM = Me.dgvStockCode.SelectedRows(0).Cells("gvUom").Value
            Else
                Me._UOM = String.Empty
            End If

            Me._lStockID = Me.dgvStockCode.SelectedRows(0).Cells("gvStockID").Value

            If Me.dgvStockCode.SelectedRows(0).Cells("gvPartNo").Value.ToString() <> String.Empty Then
                Me._lPartNo = Me.dgvStockCode.SelectedRows(0).Cells("gvPartNo").Value
            Else
                Me._lPartNo = String.Empty
            End If

            _lAvailableQty = Me.dgvStockCode.SelectedRows(0).Cells("gvAvailableQty").Value

            If Me.dgvStockCode.SelectedRows(0).Cells("gvMinQty").Value.ToString() <> String.Empty Then
                _lMinQty = Me.dgvStockCode.SelectedRows(0).Cells("gvMinQty").Value
            End If

            If Me.dgvStockCode.SelectedRows(0).Cells("gvAccountCode").Value IsNot DBNull.Value Then
                _lAccountCode = Me.dgvStockCode.SelectedRows(0).Cells("gvAccountCode").Value
            Else
                _lAccountCode = String.Empty
            End If

            If Not Me.dgvStockCode.SelectedRows(0).Cells("gvAccountDesc").Value Is DBNull.Value Then
                _lAccountDesc = Me.dgvStockCode.SelectedRows(0).Cells("gvAccountDesc").Value
            Else
                _lAccountDesc = String.Empty
            End If

            Me._lCOAID = Me.dgvStockCode.SelectedRows(0).Cells("gvStockCOAID").Value
            Me._lVarianceCOAID = Me.dgvStockCode.SelectedRows(0).Cells("gvVarianceCOAID").Value
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub StockCodeLookUp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgvStockCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgvStockCode, e)
        End If
    End Sub

End Class