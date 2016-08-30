Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Budget_BOL
Imports Budget_PPT

Public Class ExpenditureBudgetByAgeOfPlantingFrm

    Public strCOAID As String = String.Empty
    Public _strStandardPriceListID As String = String.Empty
    Public StrOtherStdPriceListID As String = String.Empty
    Public psCalcUOMID As String = String.Empty
    Public psQtyUOMID As String = String.Empty
    Public psOtherUOMID As String = String.Empty

    Public strGridTotal As String = String.Empty
    Dim lDelete As Integer
    Dim DeleteMultientry As New ArrayList
    Public Shared IsDirect As String = String.Empty

    Public strEBBAOPID As String = String.Empty
    Public strEBBAOPMaterialID As String = String.Empty
    Public strEBBAOPOtherID As String = String.Empty

    ''For Material add
    Public dtAddFlag As Boolean = False
    Public AddFlag As Boolean = True
    Public OtherAddFlag As Boolean = True

    Dim dtMaterial As New DataTable("dgMaterial")
    Dim columnMaterial As DataColumn
    Dim rowMaterial As DataRow


    ''For Other add
    Public dtOtherAddFlag As Boolean = False
    Public AddOtherFlag As Boolean = True

    Dim dtOther As New DataTable("dgOther")
    Dim columnOther As DataColumn
    Dim rowOther As DataRow


    ''For SaveAll 
    Public dtSaveAllAddFlag As Boolean = False

    Dim dtSaveAll As New DataTable("dgView")
    Dim columnSaveAll As DataColumn
    Dim rowSaveAll As DataRow

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")

    Dim is3Decimal As Boolean
    Dim re3DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,3})?$")




    Private Sub ExpenditureBudgetByAgeOfPlantingFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ExpenditureBudgetByAgeOfPlantingFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        tbExpenditureBudgetByAgeOfPlanting.SelectedTab = tbView
        lblBudgetYear.Text = GlobalPPT.intLoginYear
        lblBudgetYearView.Text = GlobalPPT.intLoginYear
        btnviewReport.Visible = False
        grpMainGrid.Visible = False
        FillViewGrid()
    End Sub

    Private Sub btnSearchAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccountCode.Click
        Me.Cursor = Cursors.WaitCursor
        ' Dim frmAcctcodeLookup As New Accountlookup
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtCOACode.Text = frmAcctcodeLookup.strAcctcode
            strCOAID = frmAcctcodeLookup.strAcctId
            lblAccountDescp.Text = frmAcctcodeLookup.strAcctDescp
            GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            'lsVDExpenditureAG = frmAcctcodeLookup.strAcctExpenditureAG
            ''GlobalPPT.psAcctExpenditureType = GlobalPPT.psAcctExpenditureType
            ''lsVDExpenditureAG = GlobalPPT.psAcctExpenditureType
            'lblOldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode
            'ClearSubBlock()
            'If txtContractNo.Text.Trim() = String.Empty Then
            '    btnSearchAccountCode.Enabled = True
            '    txtAccountCode.Enabled = True
            'End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

    Private Sub btnSearchMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchMaterial.Click
        Me.Cursor = Cursors.WaitCursor

        IsDirect = "YES"
        Dim StockCodeLookUp As New StandardPriceListStockLookUp
        Dim result As DialogResult = StockCodeLookUp.ShowDialog()
        _strStandardPriceListID = StockCodeLookUp.StrStockID
        txtMaterial.Text = StockCodeLookUp.StrStockCode
        txtRpPerUnit.Text = StockCodeLookUp.deciTotalCost
        lblMaterialName.Text = StockCodeLookUp.strDescp
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnStockCodeLookupOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockCodeLookupOther.Click
        Me.Cursor = Cursors.WaitCursor

        IsDirect = "NO"
        Dim StockCodeLookUp As New StandardPriceListStockLookUp
        Dim result As DialogResult = StockCodeLookUp.ShowDialog()
        StrOtherStdPriceListID = StockCodeLookUp.StrStockID
        If StockCodeLookUp.StrStockCode <> "" Then
            txtOthermaterial.Text = StockCodeLookUp.StrStockCode
        Else
            txtOthermaterial.Text = StockCodeLookUp.strDescp
        End If

        lblOtherRpPerUnit.Text = StockCodeLookUp.deciTotalCost
        lblOtherMaterialName.Text = StockCodeLookUp.strDescp
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub txtQuan_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuan.Leave, txtQuan.TextChanged
        lblCost.Text = Math.Round(Val(txtQuan.Text) * Val(txtRpPerUnit.Text), 2)
    End Sub
    Private Sub txtQuanOther_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuanOther.Leave, txtQuanOther.TextChanged
        lblOtherCost.Text = Math.Round(Val(txtQuanOther.Text) * Val(lblOtherRpPerUnit.Text), 2)
    End Sub

    Private Sub txtRpPerUnit_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRpPerUnit.Leave, txtRpPerUnit.TextChanged
        lblCost.Text = Math.Round(Val(txtQuan.Text) * Val(txtRpPerUnit.Text), 2)
    End Sub

    Private Sub txtMdayRate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMdayRate.Leave, txtMdayRate.TextChanged
        Dim dt As New DataTable
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        dt = ExpenditureBudgetByAgeOfPlantingBOL.RoundedUpValueGET(oExpenditureBudgetByAgeOfPlantingPPT)

        Dim intRoundedUp As Integer
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("RoundedUp").ToString.Trim <> "" Then
                intRoundedUp = dt.Rows(0).Item("RoundedUp").ToString.Trim
            End If
        End If

        txtLabour.Text = Math.Round(Val(intRoundedUp) * Val(txtMdayRate.Text), 2)

    End Sub
    Private Sub txtCostOther_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostOther.Leave

        lblCostTotal.Text = (Val(txtLabour.Text) + Val(txtCostMaterial.Text) + Val(txtCostOther.Text))
        lblCostRupiah.Text = (Val(lblCostTotal.Text) * Val(txtCostRound.Text) / 1000)
    End Sub
    Private Sub TotalCalculation()

        Dim objDataGridViewRow As New DataGridViewRow
        txtCostMaterial.Text = ""
        For Each objDataGridViewRow In dgMaterial.Rows
            If objDataGridViewRow.Cells("Cost").Value.ToString <> "" Then
                strGridTotal = strGridTotal
                Dim Cost As String
                Cost = objDataGridViewRow.Cells("Cost").Value.ToString()
                strGridTotal = (Val(strGridTotal) + Val(Cost))
            End If
            
        Next

        If strGridTotal <> "" Then
            txtCostMaterial.Text = strGridTotal
        End If
        strGridTotal = ""
        lblCostTotal.Text = (Val(txtLabour.Text) + Val(txtCostMaterial.Text) + Val(txtCostOther.Text))
    End Sub
    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        Clearmaterial()
        ClearOther()
        ClearGridView(dgMaterial)
        ClearGridView(dgOther)
        ClearGridView(dgView)
        btnSaveAll.Text = "Save All"
        Clearmain()
    End Sub
    Private Sub Clearmain()
        txtCOACode.Text = ""
        strCOAID = ""
        lblYearofPlanting.Text = ""
        lblAccountDescp.Text = ""
        txtMdayRate.Text = ""
        txtCOACode.Enabled = True
        btnSearchAccountCode.Enabled = True
        txtMdayRate.Enabled = True
        txtLabour.Text = ""
        txtMaterial.Text = ""
        txtCostMaterial.Text = ""
        txtCostOther.Text = ""
        lblCostTotal.Text = ""
        txtCostRound.Text = ""
        lblCostRupiah.Text = ""


    End Sub

    Private Sub ClearMaterial()
        txtMaterial.Text = ""
        txtCalcu.Text = ""
        txtUnitCalc.Text = ""
        txtQuan.Text = ""
        txtUnitQuan.Text = ""
        txtRpPerUnit.Text = ""
        lblCost.Text = ""
        _strStandardPriceListID = ""
        psCalcUOMID = ""
        psQtyUOMID = ""
        btnAddMaterial.Text = "Add"
    End Sub


    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
        End If
    End Sub

    Private Sub btnResetMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMaterial.Click
        ClearMaterial()

    End Sub
    Private Sub cmbAgeOfPlanting_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgeOfPlanting.TextChanged

        If cmbAgeOfPlanting.SelectedIndex = 4 Then
            lblYearofPlantingL.Visible = False
            lblYearofPlanting.Visible = False
            Label31.Visible = False
        Else
            lblYearofPlantingL.Visible = True
            lblYearofPlanting.Visible = True
            Label31.Visible = True
            lblYearofPlanting.Text = Val(lblBudgetYear.Text) - Val(cmbAgeOfPlanting.SelectedIndex)
        End If
    End Sub
    Private Sub btnSearchUnitCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUnitCalc.Click
        Cursor = Cursors.WaitCursor
        Dim frmUOMLookup As New UOMLookup
        frmUOMLookup.ShowDialog()
        If frmUOMLookup._lUOMID <> String.Empty Then
            Me.txtUnitCalc.Text = frmUOMLookup._lUOM
            'Me.lblUOMDescp.Text = frmUOMLookup._lDescp
            psCalcUOMID = frmUOMLookup._lUOMID
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchUnitQuan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUnitQuan.Click
        Cursor = Cursors.WaitCursor
        Dim frmUOMLookup As New UOMLookup
        frmUOMLookup.ShowDialog()
        If frmUOMLookup._lUOMID <> String.Empty Then
            Me.txtUnitQuan.Text = frmUOMLookup._lUOM
            'Me.lblUOMDescp.Text = frmUOMLookup._lDescp
            psQtyUOMID = frmUOMLookup._lUOMID
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnSearchUnitOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchUnitOther.Click
        Cursor = Cursors.WaitCursor
        Dim frmUOMLookup As New UOMLookup
        frmUOMLookup.ShowDialog()
        If frmUOMLookup._lUOMID <> String.Empty Then
            Me.txtUnitOther.Text = frmUOMLookup._lUOM
            'Me.lblUOMDescp.Text = frmUOMLookup._lDescp
            psOtherUOMID = frmUOMLookup._lUOMID
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub btnAddMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMaterial.Click

        If AddFlag = True Then
            If IsValidation() = True Then
                'dgRice.AutoGenerateColumns = False

                AddMaterial()
            Else
                Exit Sub
            End If
        ElseIf AddFlag = False Then
            If IsValidation() = True Then

                UpdateMaterial_record()
                btnAddMaterial.Text = "Add"
            Else
                Exit Sub
            End If
        End If
        TotalCalculation()
    End Sub

    Private Function IsValidation() As Boolean
        If cmbAgeOfPlanting.Text = "" Then
            MessageBox.Show("This field is required", "Age of planting")
            cmbAgeOfPlanting.Focus()
            Return False
        ElseIf txtCOACode.Text = "" Then
            MessageBox.Show("This field is required", "Acc Code")
            txtCOACode.Focus()
            Return False
        ElseIf txtMaterial.Text = "" Then
            MessageBox.Show("This field is required", "Material")
            txtMaterial.Focus()
            Return False
        ElseIf lblCost.Text = Nothing Or lblCost.Text = "0" Then
            MessageBox.Show("Please key in Quan", "BSP")
            txtQuan.Focus()
            Return False
        ElseIf txtUnitCalc.Text = Nothing Then
            MessageBox.Show("Please key in Unit", "BSP")
            txtQuan.Focus()
            Return False
        ElseIf txtUnitQuan.Text = Nothing Then
            MessageBox.Show("Please key in Quan", "BSP")
            txtQuan.Focus()
            Return False
        Else
            Return True
        End If


    End Function
    Private Function IsValidationOther() As Boolean
      
        If txtUnitOther.Text = Nothing Then
            MessageBox.Show("Please key in Unit", "BSP")
            txtUnitOther.Focus()
            Return False
        ElseIf txtOthermaterial.Text = Nothing Then
            MessageBox.Show("Please key in material", "BSP")
            txtQuan.Focus()
            Return False
        Else
            Return True
        End If


    End Function

    Private Function AccCodeAndMaterialExist(ByVal AgeOfPlanting As String, ByVal COAID As String, ByVal StandardPriceListID As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgMaterial.Rows
                'If MS <> String.Empty Then
                If AgeOfPlanting = objDataGridViewRow.Cells("dgclAgeOfPlanting").Value.ToString() And COAID = objDataGridViewRow.Cells("COAID").Value.ToString() And StandardPriceListID = objDataGridViewRow.Cells("StandardPriceListID").Value.ToString() Then
                    txtMaterial.Text = ""
                    txtMaterial.Focus()
                    Return True
                End If
                'If (COAID = objDataGridViewRow.Cells("dgclCOAID").Value.ToString() And StandardPriceListID = objDataGridViewRow.Cells("StandardPriceListID").Value.ToString()) Then
                '    txtMaterial.Text = ""
                '    txtMaterial.Focus()
                '    Return True
                'End If

            Next

            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function
    Private Function StandardPriceListExist(ByVal StandardPriceListID As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgOther.Rows
                'If MS <> String.Empty Then
                If (StandardPriceListID = objDataGridViewRow.Cells("OtherStandardPriceListID").Value.ToString()) Then
                    txtOthermaterial.Text = ""
                    txtOthermaterial.Focus()
                    Return True
                End If
                'If (COAID = objDataGridViewRow.Cells("dgclCOAID").Value.ToString() And StandardPriceListID = objDataGridViewRow.Cells("StandardPriceListID").Value.ToString()) Then
                '    txtMaterial.Text = ""
                '    txtMaterial.Focus()
                '    Return True
                'End If

            Next

            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMaterial()
        Dim intRowcount As Integer = dtMaterial.Rows.Count
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT



            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = lblBudgetYear.Text.Trim()
            oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = cmbAgeOfPlanting.SelectedIndex.ToString
            oExpenditureBudgetByAgeOfPlantingPPT.COAID = strCOAID
            oExpenditureBudgetByAgeOfPlantingPPT.StockCode = txtMaterial.Text
            oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID = _strStandardPriceListID
            If AccCodeAndMaterialExist(oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting, oExpenditureBudgetByAgeOfPlantingPPT.COAID, oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID) Then
                Exit Sub
            End If

            rowMaterial = dtMaterial.NewRow()

            If intRowcount = 0 And dtAddFlag = False Then


                columnMaterial = New DataColumn("dgclAgeOfPlanting", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)

                columnMaterial = New DataColumn("BudgetYear", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("EstateID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("EBBAOPID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("EBBAOPMaterialID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("StandardPriceListID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("StockDescp", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("Calc", System.Type.[GetType]("System.Decimal"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("CalcUOMID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("Qty", System.Type.[GetType]("System.Decimal"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("QtyUOMID", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("UnitPrice", System.Type.[GetType]("System.Decimal"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("Cost", System.Type.[GetType]("System.Decimal"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("CalcUOM", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)
                columnMaterial = New DataColumn("QtyUOM", System.Type.[GetType]("System.String"))
                dtMaterial.Columns.Add(columnMaterial)

                rowMaterial("dgclAgeOfPlanting") = cmbAgeOfPlanting.SelectedIndex
                rowMaterial("COAID") = strCOAID

                rowMaterial("BudgetYear") = lblBudgetYear.Text
                rowMaterial("EBBAOPID") = strEBBAOPID
                rowMaterial("EBBAOPMaterialID") = strEBBAOPMaterialID
                rowMaterial("StandardPriceListID") = _strStandardPriceListID
                rowMaterial("StockDescp") = txtMaterial.Text
                rowMaterial("Calc") = txtCalcu.Text
                rowMaterial("CalcUOMID") = psCalcUOMID
                rowMaterial("Qty") = txtQuan.Text
                rowMaterial("QtyUOMID") = psQtyUOMID
                rowMaterial("UnitPrice") = txtRpPerUnit.Text
                rowMaterial("Cost") = lblCost.Text
                rowMaterial("CalcUOM") = txtUnitCalc.Text
                rowMaterial("QtyUOM") = txtUnitQuan.Text

                dtMaterial.Rows.InsertAt(rowMaterial, intRowcount)
                dtAddFlag = True

            Else
                rowMaterial("dgclAgeOfPlanting") = cmbAgeOfPlanting.SelectedIndex
                rowMaterial("COAID") = strCOAID

                rowMaterial("BudgetYear") = lblBudgetYear.Text
                rowMaterial("EBBAOPID") = strEBBAOPID
                rowMaterial("EBBAOPMaterialID") = strEBBAOPMaterialID
                rowMaterial("StandardPriceListID") = _strStandardPriceListID
                rowMaterial("StockDescp") = txtMaterial.Text
                rowMaterial("Calc") = txtCalcu.Text
                rowMaterial("CalcUOMID") = psCalcUOMID
                rowMaterial("Qty") = txtQuan.Text
                rowMaterial("QtyUOMID") = psQtyUOMID
                rowMaterial("UnitPrice") = txtRpPerUnit.Text
                rowMaterial("Cost") = lblCost.Text
                rowMaterial("CalcUOM") = txtUnitCalc.Text
                rowMaterial("QtyUOM") = txtUnitQuan.Text

                dtMaterial.Rows.InsertAt(rowMaterial, intRowcount)

            End If
            dgMaterial.DataSource = dtMaterial
            dgMaterial.AutoGenerateColumns = False

       

        txtCOACode.Enabled = False
        btnSearchAccountCode.Enabled = False
        txtMdayRate.Enabled = False

        Clearmaterial()

    End Sub
    Private Sub UpdateMaterial_record()
        Dim intCount As Integer = dgMaterial.CurrentRow.Index

        dgMaterial.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text
        'dgMaterial.Rows(intCount).Cells("AgeOfPlanting").Value = cmbAgeOfPlanting.SelectedIndex.ToString
        'dgMaterial.Rows(intCount).Cells("Yearofplanting").Value = lblYearofPlanting.Text
        'dgMaterial.Rows(intCount).Cells("COAID").Value = strCOAID
        'dgMaterial.Rows(intCount).Cells("COACode").Value = txtCOACode.Text
        'dgMaterial.Rows(intCount).Cells("MDaysRound").Value = txtMdayRate.Text
        dgMaterial.Rows(intCount).Cells("StandardPriceListID").Value = _strStandardPriceListID
        dgMaterial.Rows(intCount).Cells("StockDescp").Value = txtMaterial.Text
        dgMaterial.Rows(intCount).Cells("Calc").Value = txtCalcu.Text
        dgMaterial.Rows(intCount).Cells("CalcUOMID").Value = psCalcUOMID
        dgMaterial.Rows(intCount).Cells("Qty").Value = txtQuan.Text
        dgMaterial.Rows(intCount).Cells("QtyUOMID").Value = psQtyUOMID
        dgMaterial.Rows(intCount).Cells("UnitPrice").Value = txtRpPerUnit.Text
        dgMaterial.Rows(intCount).Cells("Cost").Value = lblCost.Text
        dgMaterial.Rows(intCount).Cells("CalcUOM").Value = txtUnitCalc.Text
        dgMaterial.Rows(intCount).Cells("QtyUOM").Value = txtUnitQuan.Text

        btnAddMaterial.Text = "Add"
        AddFlag = True
        'If btnSaveAll.Text = "Save All" Then
        '    AddFlag = True
        'Else
        '    AddFlag = False
        'End If
        Clearmaterial()
    End Sub
    Private Sub dgMaterial_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgMaterial.DoubleClick
        Edit_Material()

    End Sub
    Private Sub Edit_Material()
        If dgMaterial.RowCount > 0 Then
            AddFlag = False
            btnAddMaterial.Text = "Update"

            'cmbAgeOfPlanting.SelectedIndex = dgMaterial.SelectedRows(0).Cells("AgeOfPlanting").Value.ToString
            'lblYearofPlanting.Text = dgMaterial.SelectedRows(0).Cells("Yearofplanting").Value.ToString
            'strCOAID = dgMaterial.SelectedRows(0).Cells("COAID").Value.ToString
            'txtCOACode.Text = dgMaterial.SelectedRows(0).Cells("COACode").Value.ToString
            'txtMdayRate.Text = dgMaterial.SelectedRows(0).Cells("MDaysRound").Value.ToString
            _strStandardPriceListID = dgMaterial.SelectedRows(0).Cells("StandardPriceListID").Value.ToString
            txtMaterial.Text = dgMaterial.SelectedRows(0).Cells("StockDescp").Value.ToString
            txtCalcu.Text = dgMaterial.SelectedRows(0).Cells("Calc").Value.ToString
            psCalcUOMID = dgMaterial.SelectedRows(0).Cells("CalcUOMID").Value.ToString
            txtQuan.Text = dgMaterial.SelectedRows(0).Cells("Qty").Value.ToString
            psQtyUOMID = dgMaterial.SelectedRows(0).Cells("QtyUOMID").Value.ToString
            txtRpPerUnit.Text = dgMaterial.SelectedRows(0).Cells("UnitPrice").Value.ToString
            lblCost.Text = dgMaterial.SelectedRows(0).Cells("Cost").Value.ToString
            txtUnitCalc.Text = dgMaterial.SelectedRows(0).Cells("CalcUOM").Value.ToString
            txtUnitQuan.Text = dgMaterial.SelectedRows(0).Cells("QtyUOM").Value.ToString
            strEBBAOPMaterialID = dgMaterial.SelectedRows(0).Cells("EBBAOPMaterialID").Value.ToString
        End If
        'AddFlag = True
    End Sub

    Private Sub btnOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOther.Click


        If OtherAddFlag = True Then
            If IsValidationOther() = True Then
                'dgRice.AutoGenerateColumns = False
                AddOther()
            Else
                Exit Sub
            End If
        ElseIf OtherAddFlag = False Then
            If IsValidationOther() = True Then

                UpdateCost_record()
                ' '' ''btnAddCost.Text = "Add"
            Else
                Exit Sub
            End If
            End If
    End Sub

    Private Sub AddOther()

      


        Dim intRowcount As Integer = dtOther.Rows.Count

        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT


        Try

            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = lblBudgetYear.Text.Trim()
            oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID = StrOtherStdPriceListID
            If StandardPriceListExist(oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID) Then
                Exit Sub
            End If

            rowOther = dtOther.NewRow()

            If intRowcount = 0 And dtOtherAddFlag = False Then
                columnOther = New DataColumn("OtherEstateID", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherBudgetYear", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("EBBAOPOtherID", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherEBBAOPID", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherActivity", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherUOMID", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherUOM", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherQty", System.Type.[GetType]("System.Decimal"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherStandardPriceListID", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherCost", System.Type.[GetType]("System.Decimal"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherMaterialDesc", System.Type.[GetType]("System.String"))
                dtOther.Columns.Add(columnOther)
                columnOther = New DataColumn("OtherRpPerUnit", System.Type.[GetType]("System.Decimal"))
                dtOther.Columns.Add(columnOther)




                If txtOther.Text = "" Then
                Else
                    rowOther("OtherActivity") = txtOther.Text
                End If
                rowOther("OtherUOMID") = psOtherUOMID
                rowOther("EBBAOPOtherID") = strEBBAOPOtherID
                rowOther("OtherEBBAOPID") = strEBBAOPID
                If txtUnitOther.Text = "" Then
                Else
                    rowOther("OtherUOM") = txtUnitOther.Text
                End If
                If txtQuanOther.Text = "" Then
                Else
                    rowOther("OtherQty") = txtQuanOther.Text
                End If
                If StrOtherStdPriceListID = "" Then
                Else
                    rowOther("OtherStandardPriceListID") = StrOtherStdPriceListID
                End If
                If txtOthermaterial.Text = "" Then
                Else
                    rowOther("OtherMaterialDesc") = txtOthermaterial.Text
                End If
                If lblOtherCost.Text = "" Then
                    rowOther("OtherCost") = 0.0
                Else
                    rowOther("OtherCost") = lblOtherCost.Text
                End If
                If lblOtherRpPerUnit.Text = Nothing Then
                    rowOther("OtherRpPerUnit") = 0.0
                Else
                    rowOther("OtherRpPerUnit") = lblOtherRpPerUnit.Text
                End If



                dtOther.Rows.InsertAt(rowOther, intRowcount)
                dtOtherAddFlag = True

            Else
                If txtOther.Text = "" Then
                Else
                    rowOther("OtherActivity") = txtOther.Text
                End If
                rowOther("OtherUOMID") = psOtherUOMID
                rowOther("EBBAOPOtherID") = strEBBAOPOtherID
                rowOther("OtherEBBAOPID") = strEBBAOPID
                If txtUnitOther.Text = "" Then
                Else
                    rowOther("OtherUOM") = txtUnitOther.Text
                End If
                If txtQuanOther.Text = "" Then
                Else
                    rowOther("OtherQty") = txtQuanOther.Text
                End If
                If StrOtherStdPriceListID = "" Then
                Else
                    rowOther("OtherStandardPriceListID") = StrOtherStdPriceListID
                End If
                If txtOthermaterial.Text = "" Then
                Else
                    rowOther("OtherMaterialDesc") = txtOthermaterial.Text
                End If
                If lblOtherCost.Text = "" Then
                    rowOther("OtherCost") = 0.0
                Else
                    rowOther("OtherCost") = lblOtherCost.Text
                End If
                If lblOtherRpPerUnit.Text = Nothing Then
                    rowOther("OtherRpPerUnit") = 0.0
                Else
                    rowOther("OtherRpPerUnit") = lblOtherRpPerUnit.Text
                End If

                dtOther.Rows.InsertAt(rowOther, intRowcount)

            End If
            dgOther.DataSource = dtOther
            dgOther.AutoGenerateColumns = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ClearOther()


    End Sub
    Private Sub UpdateCost_record()
        If dgOther.Rows.Count > 0 Then


            Dim intCount As Integer = dgOther.CurrentRow.Index

            dgOther.Rows(intCount).Cells("OtherActivity").Value = txtOther.Text
            dgOther.Rows(intCount).Cells("OtherUOMID").Value = psOtherUOMID
            dgOther.Rows(intCount).Cells("EBBAOPOtherID").Value = strEBBAOPOtherID
            dgOther.Rows(intCount).Cells("OtherEBBAOPID").Value = strEBBAOPID
            dgOther.Rows(intCount).Cells("OtherUOM").Value = txtUnitOther.Text
            dgOther.Rows(intCount).Cells("OtherQty").Value = txtQuanOther.Text
            dgOther.Rows(intCount).Cells("OtherStandardPriceListID").Value = StrOtherStdPriceListID
            dgOther.Rows(intCount).Cells("OtherRpPerUnit").Value = lblOtherRpPerUnit.Text
            dgOther.Rows(intCount).Cells("OtherCost").Value = lblOtherCost.Text


            'dgOther.Rows(intCount).Cells("Labour").Value = txtLabour.Text
            'dgOther.Rows(intCount).Cells("Material").Value = txtCostMaterial.Text
            'dgOther.Rows(intCount).Cells("Other").Value = txtCostOther.Text
            'dgOther.Rows(intCount).Cells("Total").Value = lblCostTotal.Text
            'dgOther.Rows(intCount).Cells("Rounds").Value = txtCostRound.Text
            'dgOther.Rows(intCount).Cells("RpPerHect").Value = lblCostRupiah.Text
        Else
            Exit Sub
        End If

        btnOther.Text = "Add"
        If btnSaveAll.Text = "Save All" Then
            OtherAddFlag = True
        Else
            OtherAddFlag = False
        End If
        ClearOther()
    End Sub
    Private Sub dgOther_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOther.DoubleClick
        Edit_Other()

    End Sub
    Private Sub Edit_Other()

        If dgOther.RowCount > 0 Then
            OtherAddFlag = False


            txtOther.Text = dgOther.SelectedRows(0).Cells("OtherActivity").Value.ToString
            psOtherUOMID = dgOther.SelectedRows(0).Cells("OtherUOMID").Value.ToString
            strEBBAOPOtherID = dgOther.SelectedRows(0).Cells("EBBAOPOtherID").Value.ToString
            strEBBAOPID = dgOther.SelectedRows(0).Cells("OtherEBBAOPID").Value.ToString
            txtUnitOther.Text = dgOther.SelectedRows(0).Cells("OtherUOM").Value.ToString
            txtQuanOther.Text = dgOther.SelectedRows(0).Cells("OtherQty").Value.ToString
            StrOtherStdPriceListID = dgOther.SelectedRows(0).Cells("OtherStandardPriceListID").Value.ToString
            txtOthermaterial.Text = dgOther.SelectedRows(0).Cells("OtherMaterialDesc").Value.ToString
            'txtLabour.Text = dgOther.SelectedRows(0).Cells("Labour").Value.ToString
            'txtCostMaterial.Text = dgOther.SelectedRows(0).Cells("Material").Value.ToString
            'txtCostOther.Text = dgOther.SelectedRows(0).Cells("Other").Value.ToString
            'lblCostTotal.Text = dgOther.SelectedRows(0).Cells("Total").Value.ToString
            'txtCostRound.Text = dgOther.SelectedRows(0).Cells("Rounds").Value.ToString
            'lblCostRupiah.Text = dgOther.SelectedRows(0).Cells("RpPerHect").Value.ToString

        End If
        btnOther.Text = "Update"
        OtherAddFlag = False
    End Sub
    Private Sub txtCOACode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOACode.Leave
        If txtCOACode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            oExpenditureBudgetByAgeOfPlantingPPT.COACode = txtCOACode.Text.Trim()
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            ds = ExpenditureBudgetByAgeOfPlantingBOL.AcctlookupSearch(oExpenditureBudgetByAgeOfPlantingPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Invalid Account code,Please Choose it from look up")
                txtCOACode.Text = String.Empty
                lblAccountDescp.Text = String.Empty
                'lblOldCOACode.Text = String.Empty
                strCOAID = String.Empty
                txtCOACode.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
                    txtCOACode.Text = ds.Tables(0).Rows(0).Item("COACode")
                End If
                If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
                    lblAccountDescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
                End If
                If ds.Tables(0).Rows(0).Item("COAID").ToString() <> String.Empty Then
                    strCOAID = ds.Tables(0).Rows(0).Item("COAID")
                End If
                'If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
                '    lblOldCOACode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                'End If
            End If

        Else
            txtCOACode.Text = String.Empty
            lblAccountDescp.Text = String.Empty
            'lblOldCOACode.Text = String.Empty
            strCOAID = String.Empty
        End If
    End Sub
    Private Sub txtUnitCalc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCalc.Leave
        If txtUnitCalc.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            oExpenditureBudgetByAgeOfPlantingPPT.CalcUOM = txtUnitCalc.Text
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            ds = oExpenditureBudgetByAgeOfPlantingBOL.UOMLookupSearch(oExpenditureBudgetByAgeOfPlantingPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'DisplayInfoMessage("Msg38")
                MessageBox.Show("Invalid UOM,Please Choose it from look up")
                'Me.lblUOMDescp.Text = String.Empty
                Me.txtUnitCalc.Text = String.Empty
                psCalcUOMID = String.Empty
                txtUnitCalc.Focus()
                Exit Sub
            Else
                'If ds.Tables(0).Rows(0).Item("Description").ToString() <> String.Empty Then
                '    Me.lblUOMDescp.Text = ds.Tables(0).Rows(0).Item("Description").ToString()
                'End If
                If ds.Tables(0).Rows(0).Item("UOM").ToString() <> String.Empty Then
                    Me.txtUnitCalc.Text = ds.Tables(0).Rows(0).Item("UOM").ToString()
                End If
                psCalcUOMID = ds.Tables(0).Rows(0).Item("UOMID").ToString()
            End If
        Else
            'Me.lblUOMDescp.Text = String.Empty
            Me.txtUnitCalc.Text = String.Empty
            psCalcUOMID = String.Empty
        End If
    End Sub
    Private Sub txtUnitQuan_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitQuan.Leave
        If txtUnitQuan.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            oExpenditureBudgetByAgeOfPlantingPPT.QtyUOM = txtUnitQuan.Text
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            ds = oExpenditureBudgetByAgeOfPlantingBOL.UOMLookupSearch1(oExpenditureBudgetByAgeOfPlantingPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'DisplayInfoMessage("Msg38")
                MessageBox.Show("Invalid UOM,Please Choose it from look up")
                'Me.lblUOMDescp.Text = String.Empty
                Me.txtUnitQuan.Text = String.Empty
                psQtyUOMID = String.Empty
                txtUnitQuan.Focus()
                Exit Sub
            Else
                'If ds.Tables(0).Rows(0).Item("Description").ToString() <> String.Empty Then
                '    Me.lblUOMDescp.Text = ds.Tables(0).Rows(0).Item("Description").ToString()
                'End If
                If ds.Tables(0).Rows(0).Item("UOM").ToString() <> String.Empty Then
                    Me.txtUnitQuan.Text = ds.Tables(0).Rows(0).Item("UOM").ToString()
                End If
                psQtyUOMID = ds.Tables(0).Rows(0).Item("UOMID").ToString()
            End If
        Else
            'Me.lblUOMDescp.Text = String.Empty
            Me.txtUnitQuan.Text = String.Empty
            psQtyUOMID = String.Empty
        End If
    End Sub
    Private Sub txtUnitOther_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitOther.Leave
        If txtUnitOther.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            oExpenditureBudgetByAgeOfPlantingPPT.QtyUOM = txtUnitOther.Text
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            ds = oExpenditureBudgetByAgeOfPlantingBOL.UOMLookupSearch2(oExpenditureBudgetByAgeOfPlantingPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'DisplayInfoMessage("Msg38")
                MessageBox.Show("Invalid UOM,Please Choose it from look up")
                'Me.lblUOMDescp.Text = String.Empty
                Me.txtUnitOther.Text = String.Empty
                psOtherUOMID = String.Empty
                txtUnitOther.Focus()
                Exit Sub
            Else
                'If ds.Tables(0).Rows(0).Item("Description").ToString() <> String.Empty Then
                '    Me.lblUOMDescp.Text = ds.Tables(0).Rows(0).Item("Description").ToString()
                'End If
                If ds.Tables(0).Rows(0).Item("UOM").ToString() <> String.Empty Then
                    Me.txtUnitOther.Text = ds.Tables(0).Rows(0).Item("UOM").ToString()
                End If
                psOtherUOMID = ds.Tables(0).Rows(0).Item("UOMID").ToString()
            End If
        Else
            'Me.lblUOMDescp.Text = String.Empty
            Me.txtUnitOther.Text = String.Empty
            psOtherUOMID = String.Empty
        End If
    End Sub
    Private Sub txtMaterial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaterial.Leave
        If txtMaterial.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            oExpenditureBudgetByAgeOfPlantingPPT.StockCode = txtMaterial.Text
            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = lblBudgetYear.Text
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            ds = oExpenditureBudgetByAgeOfPlantingBOL.MaterialCheck(oExpenditureBudgetByAgeOfPlantingPPT)
            If ds.Tables(0).Rows.Count = 0 Then
                'DisplayInfoMessage("Msg38")
                MessageBox.Show("Invalid Material,Please Choose it from look up")
                Me.lblMaterialName.Text = String.Empty
                Me.txtMaterial.Text = String.Empty
                _strStandardPriceListID = String.Empty
                txtRpPerUnit.Text = String.Empty
                txtMaterial.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("Descp").ToString() <> String.Empty Then
                    Me.lblMaterialName.Text = ds.Tables(0).Rows(0).Item("Descp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("StockCode").ToString() <> String.Empty Then
                    Me.txtMaterial.Text = ds.Tables(0).Rows(0).Item("StockCode").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TotalCost").ToString() <> String.Empty Then
                    Me.txtRpPerUnit.Text = ds.Tables(0).Rows(0).Item("TotalCost").ToString()
                End If
                _strStandardPriceListID = ds.Tables(0).Rows(0).Item("StandardPriceListID").ToString()
            End If
        Else
            Me.lblMaterialName.Text = String.Empty
            Me.txtMaterial.Text = String.Empty
            _strStandardPriceListID = String.Empty
        End If
    End Sub
    Private Sub txtOthermaterial_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOthermaterial.Leave
        If txtOthermaterial.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            oExpenditureBudgetByAgeOfPlantingPPT.StockCode = txtOthermaterial.Text
            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = lblBudgetYear.Text
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            ds = oExpenditureBudgetByAgeOfPlantingBOL.MaterialCheck(oExpenditureBudgetByAgeOfPlantingPPT)
            If ds.Tables(0).Rows.Count = 0 Then
                'DisplayInfoMessage("Msg38")
                MessageBox.Show("Invalid Material,Please Choose it from look up")
                Me.lblOtherMaterialName.Text = String.Empty
                Me.txtOthermaterial.Text = String.Empty
                StrOtherStdPriceListID = String.Empty
                lblOtherRpPerUnit.Text = String.Empty
                txtOthermaterial.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("Descp").ToString() <> String.Empty Then
                    Me.lblOtherMaterialName.Text = ds.Tables(0).Rows(0).Item("Descp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("StockCode").ToString() <> String.Empty Then
                    Me.txtOthermaterial.Text = ds.Tables(0).Rows(0).Item("StockCode").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TotalCost").ToString() <> String.Empty Then
                    Me.lblOtherRpPerUnit.Text = ds.Tables(0).Rows(0).Item("TotalCost").ToString()
                End If
                StrOtherStdPriceListID = ds.Tables(0).Rows(0).Item("StandardPriceListID").ToString()
            End If
        Else
            Me.lblOtherMaterialName.Text = String.Empty
            Me.txtOthermaterial.Text = String.Empty
            StrOtherStdPriceListID = String.Empty
            _strStandardPriceListID = String.Empty
            lblOtherRpPerUnit.Text = String.Empty
        End If
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        SaveFunction()
        FillViewGrid()
        ClearMaterial()
        ClearOther()
        Clearmain()
        ClearGridView(dgMaterial)
        ClearGridView(dgOther)
        ClearGridView(dgView)
        btnSaveAll.Text = "Save All"
    End Sub

    Private Sub SaveFunction()
        If dgMaterial.Rows.Count > 0 And dgOther.Rows.Count > 0 Then


            Dim ds As New DataSet
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
            'SaveAll()

            oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID = strEBBAOPID
            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = Val(lblBudgetYear.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = cmbAgeOfPlanting.SelectedIndex
            oExpenditureBudgetByAgeOfPlantingPPT.Yearofplanting = lblYearofPlanting.Text
            oExpenditureBudgetByAgeOfPlantingPPT.COAID = strCOAID
            'oExpenditureBudgetByAgeOfPlantingPPT.COACode = 
            oExpenditureBudgetByAgeOfPlantingPPT.MDaysRound = txtMdayRate.Text
            oExpenditureBudgetByAgeOfPlantingPPT.Labour = Val(txtLabour.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.Material = Val(txtCostMaterial.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.Other = Val(txtCostOther.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.Total = Val(lblCostTotal.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.Rounds = Val(txtCostRound.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.RpPerHect = Val(lblCostRupiah.Text)

            For Each DataGridViewRow1 In dgMaterial.Rows
                oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = DataGridViewRow1.Cells("dgclAgeOfPlanting").Value.ToString()
                oExpenditureBudgetByAgeOfPlantingPPT.COAID = DataGridViewRow1.Cells("COAID").Value.ToString()
                oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID = DataGridViewRow1.Cells("StandardPriceListID").Value.ToString()
                ds = ExpenditureBudgetByAgeOfPlantingBOL.ExpenditureBudgetByAgeOfPlantingIsExist(oExpenditureBudgetByAgeOfPlantingPPT)
            Next
            If ds.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("Record already exists", "BSP")
                Exit Sub
            End If

            If strEBBAOPID = "" Then
                ds = oExpenditureBudgetByAgeOfPlantingBOL.ExpenditureBudgetByAgeOfPlantingMainInsert(oExpenditureBudgetByAgeOfPlantingPPT)
                If ds Is Nothing Then
                    MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    strEBBAOPID = ds.Tables(0).Rows(0).Item("EBBAOPID").ToString()
                    oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID = strEBBAOPID
                End If
            Else
                ds = oExpenditureBudgetByAgeOfPlantingBOL.ExpenditureBudgetByAgeOfPlantingMainUpdate(oExpenditureBudgetByAgeOfPlantingPPT)

            End If
            For Each DataGridViewRow In dgMaterial.Rows
                With oExpenditureBudgetByAgeOfPlantingPPT
                    .EBBAOPID = strEBBAOPID
                    .EBBAOPMaterialID = DataGridViewRow.Cells("EBBAOPMaterialID").Value.ToString()
                    .StandardPriceListID = DataGridViewRow.Cells("StandardPriceListID").Value.ToString()
                    .Calc = DataGridViewRow.Cells("Calc").Value.ToString()
                    .CalcUOMID = DataGridViewRow.Cells("CalcUOMID").Value.ToString()
                    .Qty = DataGridViewRow.Cells("Qty").Value.ToString()
                    .QtyUOMID = DataGridViewRow.Cells("QtyUOMID").Value.ToString()
                    .UnitPrice = DataGridViewRow.Cells("UnitPrice").Value.ToString()
                    .Cost = DataGridViewRow.Cells("Cost").Value.ToString()
                End With

                If oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPMaterialID = "" Then
                    ds = oExpenditureBudgetByAgeOfPlantingBOL.EBBAOPMaterialInsert(oExpenditureBudgetByAgeOfPlantingPPT)
                Else
                    DeleteMultiEntryRecordsMaterial()
                    ds = oExpenditureBudgetByAgeOfPlantingBOL.EBBAOPMaterialUpdate(oExpenditureBudgetByAgeOfPlantingPPT)
                End If
            Next



            For Each DataGridViewRow In dgOther.Rows


                With oExpenditureBudgetByAgeOfPlantingPPT
                    'other
                    .EBBAOPID = strEBBAOPID
                    .OtherActivity = DataGridViewRow.Cells("OtherActivity").Value.ToString()
                    .OtherUOMID = DataGridViewRow.Cells("OtherUOMID").Value.ToString()
                    .EBBAOPOtherID = DataGridViewRow.Cells("EBBAOPOtherID").Value.ToString()
                    '.OtherUOM = DataGridViewRow.Cells("ViewOtherUOM").Value.ToString()
                    .OtherQty = DataGridViewRow.Cells("OtherQty").Value.ToString()
                    .OtherStandardPriceListID = DataGridViewRow.Cells("OtherStandardPriceListID").Value.ToString()
                    .UnitPrice = DataGridViewRow.Cells("OtherRpPerUnit").Value
                    .Cost = DataGridViewRow.Cells("OtherCost").Value.ToString()
                End With
                If oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPOtherID = "" Then
                    ds = oExpenditureBudgetByAgeOfPlantingBOL.EBBAOPOtherInsert(oExpenditureBudgetByAgeOfPlantingPPT)
                Else
                    DeleteMultiEntryRecordsOther()
                    ds = oExpenditureBudgetByAgeOfPlantingBOL.EBBAOPOtherUpdate(oExpenditureBudgetByAgeOfPlantingPPT)

                End If
            Next

            If ds Is Nothing Then
                MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                MessageBox.Show("Data successfully saved", "BSP")
            End If
        Else
            MessageBox.Show("Add record for Other Tab.", "BSP")
        End If
        ClearMaterial()
        ClearOther()
        ClearGridView(dgMaterial)
        ClearGridView(dgOther)
        ClearGridView(dgView)
        btnSaveAll.Text = "Save All"
        Clearmain()
    End Sub


    'Private Sub SaveAll()

    '    Dim intRowcount As Integer = dtSaveAll.Rows.Count
    '    Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
    '    Try
    '        rowSaveAll = dtSaveAll.NewRow()
    '        If intRowcount = 0 And dtSaveAllAddFlag = False Then
    '            columnSaveAll = New DataColumn("ViewBudgetYear", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewEstateID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewAgeOfPlanting", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewYearofplanting", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewCOAID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            'columnSaveAll = New DataColumn("COACode", System.Type.[GetType]("System.String"))
    '            'dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewMDaysRound", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)

    '            columnSaveAll = New DataColumn("ViewEBBAOPID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)


    '            columnSaveAll = New DataColumn("ViewEBBAOPMaterialID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewMaterialStandardPriceListID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            'columnSaveAll = New DataColumn("StockDescp", System.Type.[GetType]("System.String"))
    '            'dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewCalc", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewCalcUOMID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewQty", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewQtyUOMID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewUnitPrice", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewCost", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)

    '            columnSaveAll = New DataColumn("ViewCalcUOM", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewQtyUOM", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)

    '            'cost
    '            columnSaveAll = New DataColumn("EBBAOPOtherIDView", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewOtherActivity", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewOtherUOMID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            'columnSaveAll = New DataColumn("ViewOtherUOM", System.Type.[GetType]("System.String"))
    '            'dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewOtherQty", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)

    '            columnSaveAll = New DataColumn("ViewOtherStandardPriceListID", System.Type.[GetType]("System.String"))
    '            dtSaveAll.Columns.Add(columnSaveAll)

    '            columnSaveAll = New DataColumn("ViewLabour", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewMaterial", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewOther", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewTotal", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewRounds", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)
    '            columnSaveAll = New DataColumn("ViewRpPerHect", System.Type.[GetType]("System.Decimal"))
    '            dtSaveAll.Columns.Add(columnSaveAll)


    '            For Each DataGridViewRow In dgMaterial.Rows

    '                'rowSaveAll("ViewBudgetYear") = DataGridViewRow.Cells("BudgetYear").Value.ToString()
    '                rowSaveAll("ViewEBBAOPID") = DataGridViewRow.Cells("MaterialEBBAOPID").Value.ToString()
    '                rowSaveAll("ViewEBBAOPMaterialID") = DataGridViewRow.Cells("EBBAOPMaterialID").Value.ToString()
    '                rowSaveAll("ViewMaterialStandardPriceListID") = DataGridViewRow.Cells("StandardPriceListID").Value.ToString()
    '                rowSaveAll("ViewCalc") = DataGridViewRow.Cells("Calc").Value.ToString()
    '                rowSaveAll("ViewCalcUOMID") = DataGridViewRow.Cells("CalcUOMID").Value.ToString()
    '                rowSaveAll("ViewQty") = DataGridViewRow.Cells("Qty").Value.ToString()
    '                rowSaveAll("ViewQtyUOMID") = DataGridViewRow.Cells("QtyUOMID").Value.ToString()
    '                rowSaveAll("ViewUnitPrice") = DataGridViewRow.Cells("UnitPrice").Value.ToString()
    '                rowSaveAll("ViewCost") = DataGridViewRow.Cells("Cost").Value.ToString()
    '                rowSaveAll("ViewCalcUOM") = DataGridViewRow.Cells("CalcUOM").Value.ToString()
    '                rowSaveAll("ViewQtyUOM") = DataGridViewRow.Cells("QtyUOM").Value.ToString()
    '            Next

    '            For Each DataGridViewRow1 In dgOther.Rows

    '                rowSaveAll("ViewOtherActivity") = DataGridViewRow1.Cells("OtherActivity").Value.ToString()
    '                rowSaveAll("ViewOtherUOMID") = DataGridViewRow1.Cells("OtherUOMID").Value.ToString()
    '                rowSaveAll("EBBAOPOtherIDView") = DataGridViewRow1.Cells("EBBAOPOtherID").Value.ToString()
    '                'rowSaveAll("ViewOtherUOM") = DataGridViewRow1.Cells("OtherUOM").Value.ToString()
    '                rowSaveAll("ViewOtherQty") = DataGridViewRow1.Cells("OtherQty").Value.ToString()
    '                rowSaveAll("ViewOtherStandardPriceListID") = DataGridViewRow1.Cells("OtherStandardPriceListID").Value.ToString()


    '            Next

    '            'rowSaveAll("AgeOfPlantingView") = cmbAgeOfPlanting.SelectedIndex
    '            'rowSaveAll("YearofplantingView") = lblYearofPlanting.Text
    '            'rowSaveAll("COAIDView") = strCOAID
    '            ''rowSaveAll("COACodeView") = DataGridViewRow.Cells("COACode").Value.ToString()
    '            'rowSaveAll("MDaysRoundView") = txtMdayRate.Text
    '            'rowSaveAll("LabourView") = txtLabour.Text
    '            'rowSaveAll("MaterialView") = txtMaterial.Text
    '            'rowSaveAll("OtherView") = txtOther.Text
    '            'rowSaveAll("TotalView") = lblCostTotal.Text
    '            'rowSaveAll("RoundsView") = txtCostRound.Text
    '            'rowSaveAll("RpPerHectView") = lblCostRupiah.Text


    '            dtSaveAll.Rows.InsertAt(rowSaveAll, intRowcount)
    '            dtSaveAllAddFlag = True

    '        Else
    '            For Each DataGridViewRow In dgMaterial.Rows

    '                rowSaveAll("BudgetYearView") = DataGridViewRow.Cells("BudgetYear").Value.ToString()
    '                'rowSaveAll("AgeOfPlantingView") = DataGridViewRow.Cells("AgeOfPlanting").Value.ToString()
    '                'rowSaveAll("YearofplantingView") = DataGridViewRow.Cells("Yearofplanting").Value.ToString()
    '                'rowSaveAll("COAIDView") = DataGridViewRow.Cells("COAID").Value.ToString()
    '                'rowSaveAll("COACodeView") = DataGridViewRow.Cells("COACode").Value.ToString()
    '                'rowSaveAll("MDaysRoundView") = DataGridViewRow.Cells("MDaysRound").Value.ToString()
    '                rowSaveAll("ViewEBBAOPID") = DataGridViewRow.Cells("MaterialEBBAOPID").Value.ToString()
    '                rowSaveAll("ViewEBBAOPMaterialID") = DataGridViewRow.Cells("EBBAOPMaterialID").Value.ToString()
    '                rowSaveAll("ViewMaterialStandardPriceListID") = DataGridViewRow.Cells("StandardPriceListID").Value.ToString()
    '                'rowSaveAll("ViewStockDescpView") = DataGridViewRow.Cells("StockDescp").Value.ToString()
    '                rowSaveAll("ViewCalc") = DataGridViewRow.Cells("Calc").Value.ToString()
    '                rowSaveAll("ViewCalcUOMID") = DataGridViewRow.Cells("CalcUOMID").Value.ToString()
    '                rowSaveAll("ViewQty") = DataGridViewRow.Cells("Qty").Value.ToString()
    '                rowSaveAll("ViewQtyUOMID") = DataGridViewRow.Cells("QtyUOMID").Value.ToString()
    '                rowSaveAll("ViewUnitPrice") = DataGridViewRow.Cells("UnitPrice").Value.ToString()
    '                rowSaveAll("ViewCost") = DataGridViewRow.Cells("Cost").Value.ToString()
    '                rowSaveAll("ViewCalcUOM") = DataGridViewRow.Cells("CalcUOM").Value.ToString()
    '                rowSaveAll("ViewQtyUOM") = DataGridViewRow.Cells("QtyUOM").Value.ToString()
    '            Next

    '            For Each DataGridViewRow1 In dgOther.Rows

    '                rowSaveAll("ViewOtherActivity") = DataGridViewRow1.Cells("OtherActivity").Value.ToString()
    '                rowSaveAll("ViewOtherUOMID") = DataGridViewRow1.Cells("OtherUOMID").Value.ToString()
    '                rowSaveAll("EBBAOPOtherIDView") = DataGridViewRow1.Cells("EBBAOPOtherID").Value.ToString()
    '                'rowSaveAll("ViewOtherUOM") = DataGridViewRow1.Cells("OtherUOM").Value.ToString()
    '                rowSaveAll("ViewOtherQty") = DataGridViewRow1.Cells("OtherQty").Value.ToString()
    '                rowSaveAll("ViewOtherStandardPriceListID") = DataGridViewRow1.Cells("OtherStandardPriceListID").Value.ToString()
    '                'rowSaveAll("LabourView") = DataGridViewRow1.Cells("Labour").Value.ToString()
    '                'rowSaveAll("MaterialView") = DataGridViewRow1.Cells("Material").Value.ToString()
    '                'rowSaveAll("OtherView") = DataGridViewRow1.Cells("Other").Value.ToString()
    '                'rowSaveAll("TotalView") = DataGridViewRow1.Cells("Total").Value.ToString()
    '                'rowSaveAll("RoundsView") = DataGridViewRow1.Cells("Rounds").Value.ToString()
    '                'rowSaveAll("RpPerHectView") = DataGridViewRow1.Cells("RpPerHect").Value.ToString()

    '            Next
    '            dtSaveAll.Rows.InsertAt(rowSaveAll, intRowcount)
    '        End If
    '        dgView.DataSource = dtSaveAll
    '        dgView.AutoGenerateColumns = False

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub


    Private Sub FillViewGrid()
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        Dim dt As New DataTable
        oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = GlobalPPT.intLoginYear
        If cmbAgeOfPlantingView.SelectedIndex <> -1 Then
            oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = cmbAgeOfPlantingView.SelectedIndex
        End If
        dt = ExpenditureBudgetByAgeOfPlantingBOL.FillViewGrid(oExpenditureBudgetByAgeOfPlantingPPT)
        If dt.Rows.Count > 0 Then
            dgmain.DataSource = dt
            dgmain.AutoGenerateColumns = False
        Else
            MsgBox("No record(s) found matching your search criteria.")
            dgmain.DataSource = dt
            dgmain.AutoGenerateColumns = False
        End If
    End Sub
    Private Sub dgmain_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgmain.DoubleClick
        dgmainEdit()
        'If dgmain.Rows.Count > 0 Then
        '    Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        '    Dim dt As New DataTable
        '    oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = dgmain.SelectedRows(0).Cells("BudgetYear").Value.ToString()
        '    oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = dgmain.SelectedRows(0).Cells("AgeOfPlanting").Value.ToString()

        '    dt = ExpenditureBudgetByAgeOfPlantingBOL.FillMainGrid(oExpenditureBudgetByAgeOfPlantingPPT)
        '    If dt.Rows.Count > 0 Then
        '        dgView.DataSource = dt
        '        dgView.AutoGenerateColumns = False
        '    Else
        '        dgView.DataSource = dt
        '        dgView.AutoGenerateColumns = False
        '    End If
        '    tbExpenditureBudgetByAgeOfPlanting.SelectedTab = tbAgeofPlanting
        '    grpMainGrid.Visible = True
        'Else
        '    MsgBox("No record(s) found matching .")
        'End If

       
    End Sub
    Private Sub dgmainEdit()
        If dgmain.Rows.Count > 0 Then
            Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
            Dim dt As New DataTable
            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = dgmain.SelectedRows(0).Cells("BudgetYear").Value.ToString()
            oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = dgmain.SelectedRows(0).Cells("AgeOfPlanting").Value.ToString()

            dt = ExpenditureBudgetByAgeOfPlantingBOL.FillMainGrid(oExpenditureBudgetByAgeOfPlantingPPT)
            If dt.Rows.Count > 0 Then
                dgView.DataSource = dt
                dgView.AutoGenerateColumns = False
            Else
                dgView.DataSource = dt
                dgView.AutoGenerateColumns = False
            End If
            tbExpenditureBudgetByAgeOfPlanting.SelectedTab = tbAgeofPlanting
            grpMainGrid.Visible = True
        Else
            MsgBox("No record(s) found matching .")
        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillViewGrid()
    End Sub


    Private Sub btnResetOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetOther.Click
        ClearOther()

    End Sub
    Private Sub ClearOther()
        txtOther.Text = ""
        txtOthermaterial.Text = ""
        txtUnitOther.Text = ""
        txtQuanOther.Text = ""
        lblOtherRpPerUnit.Text = ""
        lblOtherCost.Text = ""
        lblOtherMaterialName.Text = ""
        psOtherUOMID = ""
        StrOtherStdPriceListID = ""
        btnOther.Text = "Add"
        OtherAddFlag =True 
    End Sub

    Private Sub dgView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgView.DoubleClick
        dgViewEdit()
    End Sub
    Private Sub dgViewEdit()
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        Dim dt As New DataTable
        If dgView.Rows.Count > 0 Then
            cmbAgeOfPlanting.SelectedIndex = dgView.SelectedRows(0).Cells("ViewAgeOfPlanting").Value.ToString()
            lblYearofPlanting.Text = dgView.SelectedRows(0).Cells("ViewYearofplanting").Value.ToString()
            txtCOACode.Text = dgView.SelectedRows(0).Cells("ViewCOACode").Value.ToString()
            lblAccountDescp.Text = dgView.SelectedRows(0).Cells("ViewCOADescp").Value.ToString()
            txtMdayRate.Text = dgView.SelectedRows(0).Cells("ViewMDaysRound").Value.ToString()
            strEBBAOPID = dgView.SelectedRows(0).Cells("ViewEBBAOPID").Value.ToString()
            strCOAID = dgView.SelectedRows(0).Cells("ViewCOAID").Value.ToString()

            txtLabour.Text = dgView.SelectedRows(0).Cells("ViewLabour").Value.ToString()
            txtCostMaterial.Text = dgView.SelectedRows(0).Cells("ViewMaterial").Value.ToString()
            txtCostOther.Text = dgView.SelectedRows(0).Cells("ViewOther").Value.ToString()
            lblCostTotal.Text = dgView.SelectedRows(0).Cells("ViewTotal").Value.ToString()
            txtCostRound.Text = dgView.SelectedRows(0).Cells("ViewRounds").Value.ToString()
            lblCostRupiah.Text = dgView.SelectedRows(0).Cells("ViewRpPerHect").Value.ToString()

            oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID = dgView.SelectedRows(0).Cells("ViewEBBAOPID").Value.ToString()
            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = dgView.SelectedRows(0).Cells("ViewBudgetYear").Value.ToString()
            dtMaterial = ExpenditureBudgetByAgeOfPlantingBOL.MaterialGridFill(oExpenditureBudgetByAgeOfPlantingPPT)
            If dtMaterial.Rows.Count > 0 Then
                dgMaterial.DataSource = dtMaterial
                dgMaterial.AutoGenerateColumns = False
            Else
                dgMaterial.DataSource = dtMaterial
                dgMaterial.AutoGenerateColumns = False
            End If

            dtOther = ExpenditureBudgetByAgeOfPlantingBOL.OtherGridFill(oExpenditureBudgetByAgeOfPlantingPPT)
            If dtOther.Rows.Count > 0 Then
                dgOther.DataSource = dtOther
                dgOther.AutoGenerateColumns = False
            Else
                dgOther.DataSource = dtOther
                dgOther.AutoGenerateColumns = False
            End If
            dtOtherAddFlag = True
            dtAddFlag = True
        End If
        btnSaveAll.Text = "Update All"

    End Sub
    Private Sub tbExpenditureBudgetByAgeOfPlanting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbExpenditureBudgetByAgeOfPlanting.Click

        If dgView.RowCount > 0 Or txtCOACode.Text <> "" Or txtMaterial.Text <> "" Or txtOthermaterial.Text <> "" Or dgMaterial.RowCount > 0 Or dgOther.RowCount > 0 Then
            If tbExpenditureBudgetByAgeOfPlanting.SelectedIndex = 2 Then
                If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                    If txtCOACode.Text <> "" Or txtMaterial.Text <> "" Then
                        tbExpenditureBudgetByAgeOfPlanting.SelectedIndex = 0
                    Else
                    End If
                    If txtOthermaterial.Text <> "" Then
                        tbExpenditureBudgetByAgeOfPlanting.SelectedIndex = 1
                    Else
                    End If
                Else
                    Clearmain()
                    ClearMaterial()
                    ClearOther()
                    ClearGridView(dgMaterial)
                    ClearGridView(dgOther)
                    ClearGridView(dgView)
                    btnSaveAll.Text = "Save All"
                End If
            End If
        Else
            'ClearMaterial()
            'ClearOther()
            'ClearGridView(dgMaterial)
            'ClearGridView(dgOther)
            'ClearGridView(dgView)
            'btnSaveAll.Text = "Save All"
        End If
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)
    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tbExpenditureBudgetByAgeOfPlanting.SelectedTab = tbAgeofPlanting
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        dgmainEdit()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT

        Dim dt As New DataTable
        If dgmain.Rows.Count > 0 Then

            If MsgBox("You are about to Delete the selected record for the whole Age of Planting . Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = Me.dgmain.SelectedRows(0).Cells("BudgetYear").Value.ToString()
                'oMonthlyWorkingDaysPPT.Month = Me.dgMonthlyWorkingDays.SelectedRows(0).Cells("Month").Value.ToString()

                ExpenditureBudgetByAgeOfPlantingBOL.EBBAOPViewDelete(oExpenditureBudgetByAgeOfPlantingPPT)

                MessageBox.Show("Record deleted successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FillViewGrid()
            Else
                MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub EditMaterialToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMaterialToolStripMenu.Click
        Edit_Material()
    End Sub

    Private Sub DeleteMaterialToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMaterialToolStripMenu.Click
        If dgView.RowCount = 0 Then
            Exit Sub
        Else
            DeleteMaterialdatagrid()
        End If

    End Sub

    Private Sub EditOtherToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditOtherToolStripMenu.Click
        Edit_Other()
    End Sub

    Private Sub DeleteOtherToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteOtherToolStripMenu.Click
        If dgView.RowCount = 0 Then
            Exit Sub
        Else
            DeleteOtherdatagrid()
        End If
    End Sub
    Private Sub DeleteOtherdatagrid()

        If Not dgOther.SelectedRows(0).Cells("EBBAOPOtherID").Value Is Nothing Then
            strEBBAOPOtherID = dgOther.SelectedRows(0).Cells("EBBAOPOtherID").Value.ToString
        Else
            strEBBAOPOtherID = String.Empty
        End If

        lDelete = 0
        If strEBBAOPOtherID <> "" Then
            'kumar anothertry
            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, strEBBAOPOtherID)

            lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtOther.Rows.Item(dgOther.CurrentRow.Index)
        Dr.Delete()
        dtOther.AcceptChanges()
        strEBBAOPOtherID = ""
    End Sub
    Private Sub DeleteMaterialdatagrid()

        If Not dgMaterial.SelectedRows(0).Cells("EBBAOPMaterialID").Value Is Nothing Then
            strEBBAOPMaterialID = dgMaterial.SelectedRows(0).Cells("EBBAOPMaterialID").Value.ToString
        Else
            strEBBAOPMaterialID = String.Empty
        End If



        lDelete = 0
        If strEBBAOPMaterialID <> "" Then
            'kumar anothertry
            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, strEBBAOPMaterialID)

            lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtMaterial.Rows.Item(dgMaterial.CurrentRow.Index)
        Dr.Delete()
        dtMaterial.AcceptChanges()
        strEBBAOPMaterialID = ""
    End Sub
    Private Sub DeleteMultiEntryRecordsOther()
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL

        lDelete = DeleteMultientry.Count

        While (lDelete > 0)
            ' If GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString() <> String.Empty Then
            With oExpenditureBudgetByAgeOfPlantingPPT
                .EBBAOPOtherID = DeleteMultientry(lDelete - 1)
                .EBBAOPID = strEBBAOPID
                .BudgetYear = lblBudgetYear.Text
            End With
            Dim IntOtherDelete As New Integer
            IntOtherDelete = ExpenditureBudgetByAgeOfPlantingBOL.EBBAOPOtherDelete(oExpenditureBudgetByAgeOfPlantingPPT)
            ' End If
            lDelete = lDelete - 1

        End While


    End Sub

    Private Sub DeleteMultiEntryRecordsMaterial()
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL

        lDelete = DeleteMultientry.Count

        While (lDelete > 0)
            ' If GridViewRowMEJournal.Cells("DeletedgAccJournalID").Value.ToString() <> String.Empty Then
            With oExpenditureBudgetByAgeOfPlantingPPT
                .EBBAOPMaterialID = DeleteMultientry(lDelete - 1)
                .EBBAOPID = strEBBAOPID
                .BudgetYear = lblBudgetYear.Text
            End With
            Dim IntOtherDelete As New Integer
            IntOtherDelete = ExpenditureBudgetByAgeOfPlantingBOL.EBBAOPMaterialDelete(oExpenditureBudgetByAgeOfPlantingPPT)
            ' End If
            lDelete = lDelete - 1

        End While


    End Sub

   
    Private Sub MyTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuan.KeyDown, txtQuanOther.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            isDecimal = False
                            Return
                        End If

                        is3Decimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        is3Decimal = re3DecimalPlaces.IsMatch(text)

                End Select
            Else
                is3Decimal = False
                Return
            End If

        Else
            is3Decimal = True
        End If
    End Sub
    Private Sub MyTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuan.KeyPress, txtQuanOther.KeyPress

        If is3Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub

    Private Sub MyTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lblOtherRpPerUnit.KeyDown, lblOtherCost.KeyDown, txtCalcu.KeyDown, txtRpPerUnit.KeyDown, lblCost.KeyDown, txtLabour.KeyDown, txtCostMaterial.KeyDown, txtCostOther.KeyDown, lblCostTotal.KeyDown, txtCostRound.KeyDown, lblCostRupiah.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            isDecimal = False
                            Return
                        End If

                        isDecimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        isDecimal = reDecimalPlaces.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If
    End Sub
    Private Sub MyTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lblOtherRpPerUnit.KeyPress, lblOtherCost.KeyPress, txtCalcu.KeyPress, txtRpPerUnit.KeyPress, lblCost.KeyPress, txtLabour.KeyPress, txtCostMaterial.KeyPress, txtCostOther.KeyPress, lblCostTotal.KeyPress, txtCostRound.KeyPress, lblCostRupiah.KeyPress

        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub
End Class
