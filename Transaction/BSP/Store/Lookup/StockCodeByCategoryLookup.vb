Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class StockCodeByCategoryLookup

    Public _lStockCode As String = String.Empty
    Public _lStockDesc As String = String.Empty
    Public _lStockUnitprice As String = String.Empty
    Public _lUnit As String = String.Empty
    Public _lAvailableQty As Double = 0.0
    Public _lStockID As String = String.Empty
    Public _lPartNo As String = String.Empty
    Public _lCOAID As String = String.Empty
    Public _lVarianceCOAID As String = String.Empty
    Public _lMinQty As Double = 0.0
    Public _lAccountCode As String = String.Empty
    Public _lAccountDesc As String = String.Empty


    Private Sub StockCodeLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetCategory()
        ' cmbStockCategory.SelectedIndex = 0
        BindStockCode()
        Me.txtStockCodesearch.Focus()

    End Sub

    Private Sub GetCategory()

        Dim dtCategory As New DataTable
        Dim objStkCategoryPPT As New IPRPPT
        Dim objStkCategoryBOL As New IPRBOL

        objStkCategoryPPT.StockCode = String.Empty
        objStkCategoryPPT.StockDesc = String.Empty
        IPRPPT.strGlobalCategoryID = String.Empty
        'If dtCategory.Rows.Count > 0 Then
        dtCategory = objStkCategoryBOL.GetStockCategory(objStkCategoryPPT)
        'End If

        ''If dtCategory IsNot Nothing And dtCategory.Rows.Count > 0 Then

        ''    Dim dr As DataRow = dtCategory.NewRow()
        ''    dr(0) = "--Select Category--"
        ''    dr(1) = "--Select Category--"
        ''    dtCategory.Rows.InsertAt(dr, 0)
        ''    dtCategory.AcceptChanges()
        ''End If

        With cmbStockCategory
            .DataSource = dtCategory
            .DisplayMember = "STCategoryDescp"
            .ValueMember = "STCategoryID"
        End With

    End Sub

    Private Sub BindStockCode()
        Cursor = Cursors.WaitCursor
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

        objITNINPPT.StockCode = Me.txtStockCodesearch.Text.Trim
        objITNINPPT.StockDesc = Me.txtStockDescsearch.Text.Trim
        objITNOUTPPT.StockCode = Me.txtStockCodesearch.Text.Trim
        objITNOUTPPT.StockDesc = Me.txtStockDescsearch.Text.Trim

        If cmbStockCategory.Items.Count > 0 Then
            If cmbStockCategory.Text.Trim <> "--Select Category--" And cmbStockCategory.Enabled = True Then
                objITNINPPT.STCategoryID = cmbStockCategory.SelectedValue
            Else
                objITNINPPT.STCategoryID = String.Empty
            End If
        Else
            objITNINPPT.STCategoryID = String.Empty
        End If
        If txtPartNo.Text.Trim() <> String.Empty Then
            objITNINPPT.PartNo = txtPartNo.Text.Trim()
        Else
            objITNINPPT.PartNo = String.Empty
        End If


        Dim ds As New DataSet
        objStkCategoryPPT.StockCode = Me.txtStockCodesearch.Text.Trim
        objStkCategoryPPT.StockDesc = Me.txtStockDescsearch.Text.Trim
        Dim mdiparent As New MDIParent

        If mdiparent.strMenuID = "M1" Then 'IPR Form
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
        ElseIf mdiparent.strMenuID = "M2" Then  'LPO Form
            'objStkCategoryPPT.STCategory = LocalPuchaseOrderFrm.lStockCategoryID
            'dt = objStkLPOBOL.GetStockCode(objStkLocalPPT)
            'Me.dgvStockCode.AutoGenerateColumns = False
            'Me.dgvStockCode.DataSource = dt
            dt = objITNINBOL.STStockDetailsSelect(objITNINPPT, "NO")

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
        ElseIf mdiparent.strMenuID = "M8" Then 'InternalTransferNoteINFrm
            'objStkCategoryPPT.STCategory = StoreIssueVoucherFrm.lSIVStockCategoryID
            dgvStockCode.DataSource = Nothing
            dt = objITNINBOL.STStockDetailsSelect(objITNINPPT, "NO")
            Me.dgvStockCode.AutoGenerateColumns = False

            If dt.Rows.Count > 0 Then
                lblNoRecord.Visible = False
                Me.dgvStockCode.DataSource = dt
            Else
                Me.dgvStockCode.DataSource = dt
                lblNoRecord.Visible = True
            End If

        ElseIf mdiparent.strMenuID = "M9" Then 'InternalTransferNoteOUTFrm.vb
            'objStkCategoryPPT.STCategory = StoreIssueVoucherFrm.lSIVStockCategoryID
            ''dt = objITNOUTBOL.STITNOutStockCodeGet(objITNOUTPPT)
            dt = objITNINBOL.STStockDetailsSelect(objITNINPPT, "NO")

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
            dt = objITNINBOL.STStockDetailsSelect(objITNINPPT, "NO")

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
        Cursor = Cursors.Default

        Me.txtStockCodesearch.Focus()

    End Sub

    Private Sub btnStcokCodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStcokCodeSearch.Click


        BindStockCode()

    End Sub

    Private Sub dgvStockCode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStockCode.CellDoubleClick

        StockCodeGrid_Click()

    End Sub

    Private Sub StockCodeGrid_Click()

        If dgvStockCode.Rows.Count > 0 Then

            '
            Dim dtSTStockDetailsSelect As DataTable
            Dim objITNINPPT As New InternalTransferNoteINPPT
            Dim objITNINBOL As New InternalTransferNoteINBOL

            Me._lStockID = Me.dgvStockCode.SelectedRows(0).Cells("gvStockID").Value
            objITNINPPT.StockID = _lStockID
            dtSTStockDetailsSelect = objITNINBOL.STStockDetailsSelectDetails(objITNINPPT)

            If dtSTStockDetailsSelect.Rows(0).Item("UnitPrice") IsNot DBNull.Value Then
                _lStockUnitprice = dtSTStockDetailsSelect.Rows(0).Item("UnitPrice")
            Else
                _lStockUnitprice = 0
            End If
            If dtSTStockDetailsSelect.Rows(0).Item("UOM") IsNot DBNull.Value Then
                _lUnit = dtSTStockDetailsSelect.Rows(0).Item("UOM")
            Else
                _lUnit = 0
            End If
            If dtSTStockDetailsSelect.Rows(0).Item("AvailableQty") IsNot DBNull.Value Then
                _lAvailableQty = dtSTStockDetailsSelect.Rows(0).Item("AvailableQty")
            Else
                _lAvailableQty = 0
            End If
            If dtSTStockDetailsSelect.Rows(0).Item("MinQty") IsNot DBNull.Value Then
                _lMinQty = dtSTStockDetailsSelect.Rows(0).Item("MinQty")
            Else
                _lMinQty = 0
            End If
            If dtSTStockDetailsSelect.Rows(0).Item("AccountCode") IsNot DBNull.Value Then
                _lAccountCode = dtSTStockDetailsSelect.Rows(0).Item("AccountCode")
            Else
                _lAccountCode = 0
            End If
            If dtSTStockDetailsSelect.Rows(0).Item("AccountDesc") IsNot DBNull.Value Then
                _lAccountDesc = dtSTStockDetailsSelect.Rows(0).Item("AccountDesc")
            Else
                _lAccountDesc = 0
            End If
            '

            Me._lStockCode = Me.dgvStockCode.SelectedRows(0).Cells("gvStockCode").Value
            If Not Me.dgvStockCode.SelectedRows(0).Cells("gvStockDesc").Value.ToString() Is DBNull.Value Then
                Me._lStockDesc = Me.dgvStockCode.SelectedRows(0).Cells("gvStockDesc").Value
            Else
                Me._lStockDesc = String.Empty
            End If

            'If dgvStockCode.SelectedRows(0).Cells("gvUnitPrice").Value.ToString() <> String.Empty Then
            '    Me._lStockUnitprice = Me.dgvStockCode.SelectedRows(0).Cells("gvUnitPrice").Value
            'Else
            '    Me._lStockUnitprice = String.Empty
            'End If

            'If Me.dgvStockCode.SelectedRows(0).Cells("gvUnit").Value.ToString() <> String.Empty Then
            '    Me._lUnit = Me.dgvStockCode.SelectedRows(0).Cells("gvUnit").Value
            'Else
            '    Me._lUnit = String.Empty
            'End If

            'Me._lStockID = Me.dgvStockCode.SelectedRows(0).Cells("gvStockID").Value

            If Me.dgvStockCode.SelectedRows(0).Cells("gvPartNo").Value.ToString() <> String.Empty Then
                Me._lPartNo = Me.dgvStockCode.SelectedRows(0).Cells("gvPartNo").Value
            Else
                Me._lPartNo = String.Empty
            End If
            'If Not Me.dgvStockCode.SelectedRows(0).Cells("gvAvailableQty").Value Is DBNull.Value Then
            '    _lAvailableQty = Me.dgvStockCode.SelectedRows(0).Cells("gvAvailableQty").Value

            'Else
            '    _lAvailableQty = 0

            'End If

            'If Not Me.dgvStockCode.SelectedRows(0).Cells("gvMinQty").Value Is DBNull.Value Then
            '    _lMinQty = Me.dgvStockCode.SelectedRows(0).Cells("gvMinQty").Value
            'Else
            '    _lMinQty = 0
            'End If

            'If Me.dgvStockCode.SelectedRows(0).Cells("gvAccountCode").Value IsNot DBNull.Value Then
            '    _lAccountCode = Me.dgvStockCode.SelectedRows(0).Cells("gvAccountCode").Value
            'Else
            '    _lAccountCode = String.Empty
            'End If

            'If Not Me.dgvStockCode.SelectedRows(0).Cells("gvAccountDesc").Value Is DBNull.Value Then
            '    _lAccountDesc = Me.dgvStockCode.SelectedRows(0).Cells("gvAccountDesc").Value
            'Else
            '    _lAccountDesc = String.Empty
            'End If
            If Not Me.dgvStockCode.SelectedRows(0).Cells("gvStockCOAID").Value Is DBNull.Value Then
                Me._lCOAID = Me.dgvStockCode.SelectedRows(0).Cells("gvStockCOAID").Value
            Else
                Me._lCOAID = String.Empty
            End If
            If Not Me.dgvStockCode.SelectedRows(0).Cells("gvVarianceCOAID").Value Is DBNull.Value Then
                Me._lVarianceCOAID = Me.dgvStockCode.SelectedRows(0).Cells("gvVarianceCOAID").Value
            Else
                Me._lVarianceCOAID = String.Empty
            End If

            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub chkSelectAllCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAllCategory.CheckedChanged
        If chkSelectAllCategory.Checked = True Then
            cmbStockCategory.Enabled = False
        ElseIf chkSelectAllCategory.Checked = False Then
            cmbStockCategory.Enabled = True
        End If
    End Sub

    Private Sub StockCodeByCategoryLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgvStockCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvStockCode.KeyDown

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

    Private Sub dgvStockCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvStockCode.KeyUp
        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgvStockCode, e)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub ClearAfterSearch()

        txtStockDescsearch.Text = String.Empty
        txtStockCodesearch.Text = String.Empty
        txtPartNo.Text = String.Empty

    End Sub

End Class