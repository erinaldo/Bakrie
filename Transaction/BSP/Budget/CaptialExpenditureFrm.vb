Imports Common_PPT
Imports Common_BOL
Imports Budget_PPT
Imports Budget_BOL
Imports System.Data.SqlClient
Imports System.Math

Public Class CaptialExpenditureFrm
    Public strBudgetID As String = String.Empty
    Public strBudgetYear As String = String.Empty
    Public strCOAId As String = String.Empty
    Public strCOACode As String = String.Empty
    Public strOldCOAID As String = String.Empty
    Private AddFlag As Boolean = True
    Private dtAddFlag As Boolean = True

    Dim dtCapitalExpend As New DataTable("dgCapitalExpend")
    Dim columnCapitalExpand As DataColumn
    Dim rowCapitalExpand As DataRow
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Private Sub btnSearchAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccountCode.Click
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtCOACode.Text = frmAcctcodeLookup.strAcctcode
            strCOAId = frmAcctcodeLookup.strAcctId
            lblCOADescp.Text = frmAcctcodeLookup.strAcctDescp
            lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
            'GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            'strOldCOAID = frmAcctcodeLookup.strOldAccountCode
        End If
    End Sub
    Private Sub CaptialExpenditureFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CaptialExpenditureFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbCapitalExpenditure.SelectedTab = tbView
        Me.lblBudgetYear.Text = GlobalPPT.intLoginYear
        lblBudgetYearView.Text = GlobalPPT.intLoginYear
        griddgCapitalExpViewBind()
        lblVersionNoL.Visible = False
        lblVersionNo.Visible = False
        lblStatusL.Visible = False
        lblStatus.Visible = False
        lblCOADescp.Text = ""
        lblCOADescpView.Text = ""
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearchCOACode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCOACode.Click
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtCOACodeView.Text = frmAcctcodeLookup.strAcctcode
            strCOAId = frmAcctcodeLookup.strAcctId
            lblCOADescpView.Text = frmAcctcodeLookup.strAcctDescp
            lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
            'GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            'strOldCOAID = frmAcctcodeLookup.strOldAccountCode
        End If
    End Sub
    Private Sub btnDistribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDistribute.Click
        Dim numval As Double

        If Val(txtAmount.Text) <> 0 Then
            numval = Math.Round((Val(txtAmount.Text) / 12), 0)
            txtBudgetJan.Text = numval
            txtBudgetFeb.Text = numval
            txtBudgetMar.Text = numval
            txtBudgetApr.Text = numval
            txtBudgetMay.Text = numval
            txtBudgetJun.Text = numval
            txtBudgetJul.Text = numval
            txtBudgetAug.Text = numval
            txtBudgetSep.Text = numval
            txtBudgetOct.Text = numval
            txtBudgetNov.Text = numval
            txtBudgetDec.Text = numval
            CalcBudgetTotal()
        End If

    End Sub

    Private Sub CalcBudgetTotal()
        lblBudgetTotal.Text = Math.Round(Val(txtBudgetJan.Text) + Val(txtBudgetFeb.Text) + Val(txtBudgetMar.Text) + Val(txtBudgetApr.Text) + Val(txtBudgetMay.Text) + Val(txtBudgetJun.Text) + Val(txtBudgetJul.Text) + Val(txtBudgetAug.Text) + Val(txtBudgetSep.Text) + Val(txtBudgetOct.Text) + Val(txtBudgetNov.Text) + Val(txtBudgetDec.Text), 0)
    End Sub
    Private Sub txtBudgetJan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetJan.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetFeb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetFeb.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetMar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetMar.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetApr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetApr.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetMay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetMay.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetjun_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetJun.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetJul_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetJul.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetAug_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetAug.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetSep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetSep.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetOct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetOct.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetNov_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetNov.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtBudgetDec_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetDec.LostFocus
        CalcBudgetTotal()
    End Sub
    Private Sub txtCost_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCost.Leave
        txtAmount.Text = Val(txtQty.Text) * Val(txtCost.Text)
    End Sub

    Private Sub btnResetGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clear()
        lblVersionNoL.Visible = False
        lblVersionNo.Visible = False
        lblStatusL.Visible = False
        lblStatus.Visible = False
    End Sub
    Private Sub tbCapitalExpenditure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCapitalExpenditure.Click
        If dgCapitalExpend.RowCount > 0 Or txtCOACode.Text <> "" Or txtAmount.Text <> "" Then
            If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tbCapitalExpenditure.SelectedIndex = 0
            Else

                Clear()
                ClearGridView(dgCapitalExpend)
                griddgCapitalExpViewBind()
                btnSaveAll.Text = "Save"

            End If
        Else
            Clear()
            ClearGridView(dgCapitalExpend)
            btnSaveAll.Text = "Save"


        End If

        txtCOACodeView.Text = ""
        lblCOADescpView.Text = ""


        'Clear()
        'ClearGridView(dgCapitalExpend)
        'lblCOADescpView.Text = ""
        lblVersionNoL.Visible = False
        lblVersionNo.Visible = False
        lblStatusL.Visible = False
        lblStatus.Visible = False
        'btnAdd.Text = "Add"
        'btnSaveAll.Text = "Save All"
    End Sub
    Private Sub Clear()

        txtSubDesc.Text = ""
        txtQty.Text = ""
        txtCost.Text = ""
        txtMonth.Text = ""
        txtDay.Text = ""
        txtPercentage.Text = ""

        txtAmount.Text = ""
        txtRemarks.Text = ""
        txtBudgetJan.Text = ""
        txtBudgetFeb.Text = ""
        txtBudgetMar.Text = ""
        txtBudgetApr.Text = ""
        txtBudgetMay.Text = ""
        txtBudgetJun.Text = ""
        txtBudgetJul.Text = ""
        txtBudgetAug.Text = ""
        txtBudgetSep.Text = ""
        txtBudgetOct.Text = ""
        txtBudgetNov.Text = ""
        txtBudgetDec.Text = ""

        txtRevJan.Text = ""
        txtRevFeb.Text = ""
        txtRevMar.Text = ""
        txtRevApr.Text = ""
        txtRevMay.Text = ""
        txtRevJun.Text = ""
        txtRevJul.Text = ""
        txtRevAug.Text = ""
        txtRevSep.Text = ""
        txtRevOct.Text = ""
        txtRevNov.Text = ""
        txtRevDec.Text = ""

        lblPinkJan.Text = ""
        lblPinkFeb.Text = ""
        lblPinkMar.Text = ""
        lblPinkApr.Text = ""
        lblPinkMay.Text = ""
        lblPinkJun.Text = ""
        lblPinkJul.Text = ""
        lblPinkAug.Text = ""
        lblPinkSep.Text = ""
        lblPinkOct.Text = ""
        lblPinkNov.Text = ""
        lblPinkDec.Text = ""
        lblVersionNo.Text = ""
        lblStatus.Text = ""

        lblBudgetTotal.Text = ""
        txtCOACode.Text = ""
        strCOAId = ""
        lblCOADescp.Text = ""
        lblOldCOACode.Text = ""
        'btnAdd.Text = "Add"
        'btnSaveAll.Text = "Save All"


    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If AddFlag = True Then
            If IsValidSaveAll() = True Then
                Add_record()
            Else
                Exit Sub
            End If

        ElseIf AddFlag = False Then
            If IsValidSaveAll() = True Then
                Update_record()
            Else
                Exit Sub
            End If
        End If
        Clear()
    End Sub

    Private Function IsValidSaveAll() As Boolean
        Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT

        Dim ds As New DataSet

        If (txtCOACode.Text.Trim() = String.Empty) Then
            MessageBox.Show(" Please Key in COA ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCOACode.Focus()
            Return False
        ElseIf (txtCOACode.Text.Trim() <> String.Empty) Then
            oCapitalExpenditurePPT.COACode = txtCOACode.Text.Trim
            ds = CapitalExpenditureBOL.CapitalExpendCOACodeIsvalid(oCapitalExpenditurePPT)

            If ds.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Not A Valid COA Code,Please Key in Valid COA Code", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCOACode.Focus()
                Return False
            End If
        End If
        If (txtAmount.Text.Trim() = Nothing) Or txtAmount.Text = "0" Then
            MessageBox.Show(" Please Key in Amount  ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Return False
        End If
        If (txtRemarks.Text.Trim() = String.Empty) Then
            MessageBox.Show(" Please Key in Remarks ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRemarks.Focus()
            Return False
        End If
        If Val(lblBudgetTotal.Text) <> Val(txtAmount.Text) Then
            MessageBox.Show("Distributed value is not equal", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBudgetDec.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub txtCOACode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOACode.Leave
        If txtCOACode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
            oCapitalExpenditurePPT.COACode = txtCOACode.Text.Trim()
            Dim oCapitalExpenditureBOL As New CapitalExpenditureBOL
            ds = CapitalExpenditureBOL.AcctlookupSearch(oCapitalExpenditurePPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Invalid Account code,Please Choose it from look up")
                txtCOACode.Text = String.Empty
                lblCOADescp.Text = String.Empty
                lblOldCOACode.Text = String.Empty
                strCOAId = String.Empty
                txtCOACode.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
                    txtCOACode.Text = ds.Tables(0).Rows(0).Item("COACode")
                End If
                If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
                    lblCOADescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
                End If
                If ds.Tables(0).Rows(0).Item("COAID").ToString() <> String.Empty Then
                    strCOAId = ds.Tables(0).Rows(0).Item("COAID")
                End If
                If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
                    lblOldCOACode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                End If
            End If

        Else
            txtCOACode.Text = String.Empty
            lblCOADescp.Text = String.Empty
            lblOldCOACode.Text = String.Empty
            strCOAId = String.Empty
        End If
    End Sub
    Private Sub Add_record()
        Dim intRowCount As Integer = dtCapitalExpend.Rows.Count
        Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
        oCapitalExpenditurePPT.COACode = txtCOACode.Text.Trim

        If Not COACodeExist(oCapitalExpenditurePPT.COACode) Then
            rowCapitalExpand = dtCapitalExpend.NewRow()
            If intRowCount = 0 And AddFlag = True Then

                columnCapitalExpand = New DataColumn("BudgetYear", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                columnCapitalExpand = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                columnCapitalExpand = New DataColumn("COACode", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("SubDesc", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Qty", System.Type.[GetType]("System.Decimal"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Cost", System.Type.[GetType]("System.Decimal"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Price", System.Type.[GetType]("System.Decimal"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Day", System.Type.[GetType]("System.Decimal"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Month", System.Type.[GetType]("System.Decimal"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Percentage", System.Type.[GetType]("System.Decimal"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                columnCapitalExpand = New DataColumn("BudgetJan", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetFeb", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetMar", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetApr", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetMay", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetJun", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetJul", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetAug", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetSep", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetOct", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetNov", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetDec", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                columnCapitalExpand = New DataColumn("RevJan", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevFeb", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevMar", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevApr", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevMay", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevJun", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevJul", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevAug", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevSep", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevOct", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevNov", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("RevDec", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                columnCapitalExpand = New DataColumn("PinkJan", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkFeb", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkMar", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkApr", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkMay", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkJun", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkJul", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkAug", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkSep", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkOct", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkNov", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("PinkDec", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                columnCapitalExpand = New DataColumn("Remarks", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetTotal", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("VersionNo", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("Status", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)
                columnCapitalExpand = New DataColumn("BudgetID", System.Type.[GetType]("System.String"))
                dtCapitalExpend.Columns.Add(columnCapitalExpand)

                rowCapitalExpand("BudgetYear") = lblBudgetYear.Text.ToString()
                'rowCapitalExpand("EmpName") = lblDriverName.Text.ToString()
                'rowCapitalExpand("VHID") = strVHID.ToString()
                'rowCapitalExpand("VHDescp") = lblVHDescp.Text.ToString()
                rowCapitalExpand("COAID") = strCOAId.ToString()
                rowCapitalExpand("COACode") = txtCOACode.Text.ToString()
                rowCapitalExpand("COADescp") = lblCOADescp.Text.ToString()
                rowCapitalExpand("OldCOACode") = lblOldCOACode.Text.ToString()

                If txtSubDesc.Text <> "" Then
                    rowCapitalExpand("SubDesc") = txtSubDesc.Text.ToString()
                End If
                If txtQty.Text <> "" Then
                    rowCapitalExpand("Qty") = txtQty.Text.ToString()
                End If
                If txtCost.Text <> "" Then
                    rowCapitalExpand("Cost") = txtCost.Text.ToString()
                End If

                rowCapitalExpand("Price") = txtAmount.Text.ToString()
                If txtDay.Text <> "" Then
                    rowCapitalExpand("Day") = txtDay.Text.ToString()
                End If
                If txtMonth.Text <> "" Then
                    rowCapitalExpand("Month") = txtMonth.Text.ToString()
                End If
                If txtPercentage.Text <> "" Then
                    rowCapitalExpand("Percentage") = txtPercentage.Text.ToString()
                End If


                rowCapitalExpand("BudgetJan") = txtBudgetJan.Text.ToString()
                rowCapitalExpand("BudgetFeb") = txtBudgetFeb.Text.ToString()
                rowCapitalExpand("BudgetMar") = txtBudgetMar.Text.ToString()
                rowCapitalExpand("BudgetApr") = txtBudgetApr.Text.ToString()
                rowCapitalExpand("BudgetMay") = txtBudgetMay.Text.ToString()
                rowCapitalExpand("BudgetJun") = txtBudgetJun.Text.ToString()
                rowCapitalExpand("BudgetJul") = txtBudgetJul.Text.ToString()
                rowCapitalExpand("BudgetAug") = txtBudgetAug.Text.ToString()
                rowCapitalExpand("BudgetSep") = txtBudgetSep.Text.ToString()
                rowCapitalExpand("BudgetOct") = txtBudgetOct.Text.ToString()
                rowCapitalExpand("BudgetNov") = txtBudgetNov.Text.ToString()
                rowCapitalExpand("BudgetDec") = txtBudgetDec.Text.ToString()

                If txtRevJan.Text <> "" Then
                    rowCapitalExpand("RevJan") = txtRevJan.Text.ToString()
                End If
                If txtRevFeb.Text <> "" Then
                    rowCapitalExpand("RevFeb") = txtRevFeb.Text.ToString()
                End If
                If txtRevMar.Text <> "" Then
                    rowCapitalExpand("RevMar") = txtRevMar.Text.ToString()
                End If
                If txtRevApr.Text <> "" Then
                    rowCapitalExpand("RevApr") = txtRevApr.Text.ToString()
                End If
                If txtRevMay.Text <> "" Then
                    rowCapitalExpand("RevMay") = txtRevMay.Text.ToString()
                End If
                If txtRevJun.Text <> "" Then
                    rowCapitalExpand("RevJun") = txtRevJun.Text.ToString()
                End If
                If txtRevJul.Text <> "" Then
                    rowCapitalExpand("RevJul") = txtRevJul.Text.ToString()
                End If
                If txtRevAug.Text <> "" Then
                    rowCapitalExpand("RevAug") = txtRevAug.Text.ToString()
                End If
                If txtRevSep.Text <> "" Then
                    rowCapitalExpand("RevSep") = txtRevSep.Text.ToString()
                End If
                If txtRevOct.Text <> "" Then
                    rowCapitalExpand("RevOct") = txtRevOct.Text.ToString()
                End If
                If txtRevNov.Text <> "" Then
                    rowCapitalExpand("RevNov") = txtRevNov.Text.ToString()
                End If
                If txtRevDec.Text <> "" Then
                    rowCapitalExpand("RevDec") = txtRevDec.Text.ToString()
                End If



                If lblPinkJan.Text <> "" Then
                    rowCapitalExpand("PinkJan") = lblPinkJan.Text.ToString()
                End If
                If lblPinkFeb.Text <> "" Then
                    rowCapitalExpand("PinkFeb") = lblPinkFeb.Text.ToString()
                End If
                If lblPinkMar.Text <> "" Then
                    rowCapitalExpand("PinkMar") = lblPinkMar.Text.ToString()
                End If
                If lblPinkApr.Text <> "" Then
                    rowCapitalExpand("PinkApr") = lblPinkApr.Text.ToString()
                End If
                If lblPinkMay.Text <> "" Then
                    rowCapitalExpand("PinkMay") = lblPinkMay.Text.ToString()
                End If
                If lblPinkJun.Text <> "" Then
                    rowCapitalExpand("PinkJun") = lblPinkJun.Text.ToString()
                End If
                If lblPinkJul.Text <> "" Then
                    rowCapitalExpand("PinkJul") = lblPinkJul.Text.ToString()
                End If
                If lblPinkAug.Text <> "" Then
                    rowCapitalExpand("PinkAug") = lblPinkAug.Text.ToString()
                End If
                If lblPinkSep.Text <> "" Then
                    rowCapitalExpand("PinkSep") = lblPinkSep.Text.ToString()
                End If
                If lblPinkOct.Text <> "" Then
                    rowCapitalExpand("PinkOct") = lblPinkOct.Text.ToString()
                End If
                If lblPinkNov.Text <> "" Then
                    rowCapitalExpand("PinkNov") = lblPinkNov.Text.ToString()
                End If
                If lblPinkDec.Text <> "" Then
                    rowCapitalExpand("PinkDec") = lblPinkDec.Text.ToString()
                End If


                If txtRemarks.Text <> "" Then
                    rowCapitalExpand("Remarks") = txtRemarks.Text.ToString()
                End If
                rowCapitalExpand("BudgetTotal") = lblBudgetTotal.Text.ToString()
                If lblVersionNo.Text <> "" Then
                    rowCapitalExpand("VersionNo") = lblVersionNo.Text.ToString()
                End If
                If lblStatus.Text <> "" Then
                    rowCapitalExpand("Status") = lblStatus.Text.ToString()
                End If

                rowCapitalExpand("BudgetID") = strBudgetID.ToString()

                dtCapitalExpend.Rows.InsertAt(rowCapitalExpand, intRowCount)
                dgCapitalExpend.AutoGenerateColumns = False
                AddFlag = True


            Else
                rowCapitalExpand("BudgetYear") = lblBudgetYear.Text.ToString()
                'rowCapitalExpand("EmpName") = lblDriverName.Text.ToString()
                'rowCapitalExpand("VHID") = strVHID.ToString()
                'rowCapitalExpand("VHDescp") = lblVHDescp.Text.ToString()
                rowCapitalExpand("COAID") = strCOAId.ToString()
                rowCapitalExpand("COACode") = txtCOACode.Text.ToString()
                rowCapitalExpand("COADescp") = lblCOADescp.Text.ToString()
                rowCapitalExpand("OldCOACode") = lblOldCOACode.Text.ToString()

                If txtSubDesc.Text <> "" Then
                    rowCapitalExpand("SubDesc") = txtSubDesc.Text.ToString()
                End If
                If txtQty.Text <> "" Then
                    rowCapitalExpand("Qty") = txtQty.Text.ToString()
                End If
                If txtCost.Text <> "" Then
                    rowCapitalExpand("Cost") = txtCost.Text.ToString()
                End If

                rowCapitalExpand("Price") = txtAmount.Text.ToString()
                If txtDay.Text <> "" Then
                    rowCapitalExpand("Day") = txtDay.Text.ToString()
                End If
                If txtMonth.Text <> "" Then
                    rowCapitalExpand("Month") = txtMonth.Text.ToString()
                End If
                If txtPercentage.Text <> "" Then
                    rowCapitalExpand("Percentage") = txtPercentage.Text.ToString()
                End If
                rowCapitalExpand("BudgetJan") = txtBudgetJan.Text.ToString()
                rowCapitalExpand("BudgetFeb") = txtBudgetFeb.Text.ToString()
                rowCapitalExpand("BudgetMar") = txtBudgetMar.Text.ToString()
                rowCapitalExpand("BudgetApr") = txtBudgetApr.Text.ToString()
                rowCapitalExpand("BudgetMay") = txtBudgetMay.Text.ToString()
                rowCapitalExpand("BudgetJun") = txtBudgetJun.Text.ToString()
                rowCapitalExpand("BudgetJul") = txtBudgetJul.Text.ToString()
                rowCapitalExpand("BudgetAug") = txtBudgetAug.Text.ToString()
                rowCapitalExpand("BudgetSep") = txtBudgetSep.Text.ToString()
                rowCapitalExpand("BudgetOct") = txtBudgetOct.Text.ToString()
                rowCapitalExpand("BudgetNov") = txtBudgetNov.Text.ToString()
                rowCapitalExpand("BudgetDec") = txtBudgetDec.Text.ToString()

                If txtRevJan.Text <> "" Then
                    rowCapitalExpand("RevJan") = txtRevJan.Text.ToString()
                End If
                If txtRevFeb.Text <> "" Then
                    rowCapitalExpand("RevFeb") = txtRevFeb.Text.ToString()
                End If
                If txtRevMar.Text <> "" Then
                    rowCapitalExpand("RevMar") = txtRevMar.Text.ToString()
                End If
                If txtRevApr.Text <> "" Then
                    rowCapitalExpand("RevApr") = txtRevApr.Text.ToString()
                End If
                If txtRevMay.Text <> "" Then
                    rowCapitalExpand("RevMay") = txtRevMay.Text.ToString()
                End If
                If txtRevJun.Text <> "" Then
                    rowCapitalExpand("RevJun") = txtRevJun.Text.ToString()
                End If
                If txtRevJul.Text <> "" Then
                    rowCapitalExpand("RevJul") = txtRevJul.Text.ToString()
                End If
                If txtRevAug.Text <> "" Then
                    rowCapitalExpand("RevAug") = txtRevAug.Text.ToString()
                End If
                If txtRevSep.Text <> "" Then
                    rowCapitalExpand("RevSep") = txtRevSep.Text.ToString()
                End If
                If txtRevOct.Text <> "" Then
                    rowCapitalExpand("RevOct") = txtRevOct.Text.ToString()
                End If
                If txtRevNov.Text <> "" Then
                    rowCapitalExpand("RevNov") = txtRevNov.Text.ToString()
                End If
                If txtRevDec.Text <> "" Then
                    rowCapitalExpand("RevDec") = txtRevDec.Text.ToString()
                End If



                If lblPinkJan.Text <> "" Then
                    rowCapitalExpand("PinkJan") = lblPinkJan.Text.ToString()
                End If
                If lblPinkFeb.Text <> "" Then
                    rowCapitalExpand("PinkFeb") = lblPinkFeb.Text.ToString()
                End If
                If lblPinkMar.Text <> "" Then
                    rowCapitalExpand("PinkMar") = lblPinkMar.Text.ToString()
                End If
                If lblPinkApr.Text <> "" Then
                    rowCapitalExpand("PinkApr") = lblPinkApr.Text.ToString()
                End If
                If lblPinkMay.Text <> "" Then
                    rowCapitalExpand("PinkMay") = lblPinkMay.Text.ToString()
                End If
                If lblPinkJun.Text <> "" Then
                    rowCapitalExpand("PinkJun") = lblPinkJun.Text.ToString()
                End If
                If lblPinkJul.Text <> "" Then
                    rowCapitalExpand("PinkJul") = lblPinkJul.Text.ToString()
                End If
                If lblPinkAug.Text <> "" Then
                    rowCapitalExpand("PinkAug") = lblPinkAug.Text.ToString()
                End If
                If lblPinkSep.Text <> "" Then
                    rowCapitalExpand("PinkSep") = lblPinkSep.Text.ToString()
                End If
                If lblPinkOct.Text <> "" Then
                    rowCapitalExpand("PinkOct") = lblPinkOct.Text.ToString()
                End If
                If lblPinkNov.Text <> "" Then
                    rowCapitalExpand("PinkNov") = lblPinkNov.Text.ToString()
                End If
                If lblPinkDec.Text <> "" Then
                    rowCapitalExpand("PinkDec") = lblPinkDec.Text.ToString()
                End If

                If txtRemarks.Text <> "" Then
                    rowCapitalExpand("Remarks") = txtRemarks.Text.ToString()
                End If

                rowCapitalExpand("BudgetTotal") = lblBudgetTotal.Text.ToString()
                If lblVersionNo.Text <> "" Then
                    rowCapitalExpand("VersionNo") = lblVersionNo.Text.ToString()
                End If
                If lblStatus.Text <> "" Then
                    rowCapitalExpand("Status") = lblStatus.Text.ToString()
                End If
                rowCapitalExpand("BudgetID") = strBudgetID.ToString()

                dtCapitalExpend.Rows.InsertAt(rowCapitalExpand, intRowCount)
                dgCapitalExpend.AutoGenerateColumns = False
                AddFlag = True
            End If
            dgCapitalExpend.AutoGenerateColumns = False
            dgCapitalExpend.DataSource = dtCapitalExpend
            btnAdd.Text = "Add"
        Else
            MsgBox("Sorry, the COACode already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
        End If

    End Sub
    Private Sub Update_record()

        Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
        Dim intCount As Integer = dgCapitalExpend.CurrentRow.Index




        dgCapitalExpend.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()

        dgCapitalExpend.Rows(intCount).Cells("COAID").Value = strCOAId.ToString()
        dgCapitalExpend.Rows(intCount).Cells("COACode").Value = txtCOACode.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("OldCOACode").Value = lblOldCOACode.Text.ToString()
       






        If txtSubDesc.Text = "" Then
            dgCapitalExpend.Rows(intCount).Cells("SubDesc").Value = txtSubDesc.Text.ToString()
        End If
        If txtQty.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("Qty").Value = txtQty.Text.ToString()
        End If
        If txtCost.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("Cost").Value = txtCost.Text.ToString()
        End If
        If txtAmount.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("Price").Value = txtAmount.Text.ToString()
        End If
        If txtDay.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("Day").Value = txtDay.Text.ToString()
        End If
        If txtMonth.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("Month").Value = txtMonth.Text.ToString()
        End If
        If txtPercentage.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("Percentage").Value = txtPercentage.Text.ToString()
        End If

        dgCapitalExpend.Rows(intCount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

        If txtRevJan.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevJan").Value = txtRevJan.Text.ToString()
        End If
        If txtRevFeb.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
        End If
        If txtRevMar.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevMar").Value = txtRevMar.Text.ToString()
        End If
        If txtRevApr.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevApr").Value = txtRevApr.Text.ToString()
        End If
        If txtRevMay.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevMay").Value = txtRevMay.Text.ToString()
        End If
        If txtRevJun.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevJun").Value = txtRevJun.Text.ToString()
        End If
        If txtRevJul.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevJul").Value = txtRevJul.Text.ToString()
        End If
        If txtRevAug.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevAug").Value = txtRevAug.Text.ToString()
        End If
        If txtRevSep.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevSep").Value = txtRevSep.Text.ToString()
        End If
        If txtRevOct.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevOct").Value = txtRevOct.Text.ToString()
        End If
        If txtRevNov.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevNov").Value = txtRevNov.Text.ToString()
        End If
        If txtRevDec.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("RevDec").Value = txtRevDec.Text.ToString()
        End If

        If lblPinkJan.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkJan").Value = lblPinkJan.Text.ToString()
        End If
        If lblPinkFeb.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkFeb").Value = lblPinkFeb.Text.ToString()
        End If
        If lblPinkMar.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkMar").Value = lblPinkMar.Text.ToString()
        End If
        If lblPinkApr.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkApr").Value = lblPinkApr.Text.ToString()
        End If
        If lblPinkMay.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkMay").Value = lblPinkMay.Text.ToString()
        End If
        If lblPinkJun.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkJun").Value = lblPinkJun.Text.ToString()
        End If
        If lblPinkJul.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkJul").Value = lblPinkJul.Text.ToString()
        End If
        If lblPinkAug.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkAug").Value = lblPinkAug.Text.ToString()
        End If
        If lblPinkSep.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkSep").Value = lblPinkSep.Text.ToString()
        End If
        If lblPinkOct.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkOct").Value = lblPinkOct.Text.ToString()
        End If
        If lblPinkNov.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkNov").Value = lblPinkNov.Text.ToString()
        End If
        If lblPinkDec.Text <> Nothing Then
            dgCapitalExpend.Rows(intCount).Cells("PinkDec").Value = lblPinkDec.Text.ToString()
        End If

        dgCapitalExpend.Rows(intCount).Cells("Remarks").Value = txtRemarks.Text.ToString()
        dgCapitalExpend.Rows(intCount).Cells("BudgetTotal").Value = lblBudgetTotal.Text.ToString()
        'If lblVersionNo.Text <> "" Then
        '    rowAdminExpand("VersionNo") = lblVersionNo.Text.ToString()
        'End If
        'If lblStatus.Text <> "" Then
        '    rowAdminExpand("Status") = lblStatus.Text.ToString()
        'End If


        btnAdd.Text = "Add"
        AddFlag = True
        'If btnSaveAll.Text = "Save All" Then
        '    AddFlag = True
        'Else
        '    AddFlag = False
        'End If

        'If strCOACode = txtCOACode.Text.Trim() Then
        '    Dim intCount As Integer = dgCapitalExpend.CurrentRow.Index
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetID").Value = strBudgetID.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("EmpName").Value = lblDriverName.Text.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("VHID").Value = strVHID.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("VHNo").Value = txtVHNo.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Remarks").Value = txtRemarks.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("COAID").Value = strCOAId.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("COACode").Value = txtCOACode.Text.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("OldCOACode").Value = lblOldCOACode.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("SubDesc").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Qty").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Cost").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Day").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Month").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Percentage").Value = txtAmount.Text.ToString()

        '    'dgCapitalExpend.Rows(intCount).Cells("Price").Value = txtAmount.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("RevJan").Value = txtRevJan.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevMar").Value = txtRevMar.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevApr").Value = txtRevApr.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevMay").Value = txtRevMay.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevJun").Value = txtRevJun.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevJul").Value = txtRevJul.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevAug").Value = txtRevAug.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevSep").Value = txtRevSep.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevOct").Value = txtRevOct.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevNov").Value = txtRevNov.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevDec").Value = txtRevDec.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("PinkJan").Value = txtRevJan.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkFeb").Value = txtRevFeb.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkMar").Value = txtRevMar.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkApr").Value = txtRevApr.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkMay").Value = txtRevMay.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkJun").Value = txtRevJun.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkJul").Value = txtRevJul.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkAug").Value = txtRevAug.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSep").Value = txtRevSep.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkOct").Value = txtRevOct.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkNov").Value = txtRevNov.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkDec").Value = txtRevDec.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("BudgetTotal").Value = lblBudgetTotal.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Status").Value = lblStatus.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("VersionNo").Value = lblVersionNo.Text.ToString()

        '    btnAdd.Text = "Add"
        '    txtCOACode.Text = String.Empty
        '    btnSaveAll.Text = "Update All"
        '    dgCapitalExpend.AutoGenerateColumns = False
        '    AddFlag = False
        'ElseIf Not COACodeExist(oCapitalExpenditurePPT.COACode) Then
        '    Dim intCount As Integer = dgCapitalExpend.CurrentRow.Index

        '    dgCapitalExpend.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetID").Value = strBudgetID.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("EmpName").Value = lblDriverName.Text.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("VHID").Value = strVHID.ToString()
        '    'dgCapitalExpend.Rows(intCount).Cells("VHNo").Value = txtVHNo.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Remarks").Value = txtRemarks.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("COAID").Value = strCOAId.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("COACode").Value = txtCOACode.Text.ToString()


        '    dgCapitalExpend.Rows(intCount).Cells("SubDesc").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Qty").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Cost").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Day").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Month").Value = txtAmount.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Percentage").Value = txtAmount.Text.ToString()


        '    dgCapitalExpend.Rows(intCount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("RevJan").Value = txtRevJan.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevMar").Value = txtRevMar.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevApr").Value = txtRevApr.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevMay").Value = txtRevMay.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevJun").Value = txtRevJun.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevJul").Value = txtRevJul.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevAug").Value = txtRevAug.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevSep").Value = txtRevSep.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevOct").Value = txtRevOct.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevNov").Value = txtRevNov.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("RevDec").Value = txtRevDec.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("PinkJan").Value = txtRevJan.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkFeb").Value = txtRevFeb.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipMar").Value = txtRevMar.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipApr").Value = txtRevApr.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipMay").Value = txtRevMay.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipJun").Value = txtRevJun.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipJul").Value = txtRevJul.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipAug").Value = txtRevAug.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipSep").Value = txtRevSep.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipOct").Value = txtRevOct.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipNov").Value = txtRevNov.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("PinkSlipDec").Value = txtRevDec.Text.ToString()

        '    dgCapitalExpend.Rows(intCount).Cells("BudgetTotal").Value = lblBudgetTotal.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("Status").Value = lblStatus.Text.ToString()
        '    dgCapitalExpend.Rows(intCount).Cells("VersionNo").Value = lblVersionNo.Text.ToString()

        '    btnAdd.Text = "Add"
        '    txtCOACode.Text = String.Empty
        '    btnSaveAll.Text = "Update All"
        '    dgCapitalExpend.AutoGenerateColumns = False
        '    AddFlag = False
        'Else
        '    MsgBox("The COACode is already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
        'End If
        'AddFlag = False
    End Sub


    Private Function COACodeExist(ByVal COACode As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgCapitalExpend.Rows
                If COACode = objDataGridViewRow.Cells("COACode").Value.ToString() Then
                    txtCOACode.Text = String.Empty
                    'txtRequestedQty.Text = string.empty 
                    txtCOACode.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        'If AddFlag = True Then
        SaveFunction()
        '    Clear()
        '    btnAdd.Text = "Add"
        '    btnSaveAll.Text = "Save All"

        'ElseIf AddFlag = False Then
        '    UpdateFunction()
        '    Clear()
        '    btnAdd.Text = "Add"
        '    btnSaveAll.Text = "Save All"
        'End If
       
    End Sub

    Private Sub SaveFunction()
        Dim ds As New DataSet

        If dgCapitalExpend.Rows.Count > 0 Then
            For Each DataGridView In dgCapitalExpend.Rows
                Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT

                oCapitalExpenditurePPT.BudgetYear = DataGridView.Cells("BudgetYear").Value.ToString()

                oCapitalExpenditurePPT.COAId = DataGridView.Cells("COAID").Value.ToString()
                oCapitalExpenditurePPT.COACode = DataGridView.Cells("COACode").Value.ToString()


                If DataGridView.Cells("SubDesc").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.SubDesc = DataGridView.Cells("SubDesc").Value.ToString()
                End If
                If DataGridView.Cells("Qty").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Qty = DataGridView.Cells("Qty").Value.ToString()
                End If
                If DataGridView.Cells("Cost").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Cost = DataGridView.Cells("Cost").Value.ToString()
                End If
                If DataGridView.Cells("Price").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Price = DataGridView.Cells("Price").Value.ToString()
                End If
                If DataGridView.Cells("Day").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Day = DataGridView.Cells("Day").Value.ToString()
                End If
                If DataGridView.Cells("Month").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Month = DataGridView.Cells("Month").Value.ToString()
                End If
                If DataGridView.Cells("Percentage").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Percentage = DataGridView.Cells("Percentage").Value.ToString()
                End If
                If DataGridView.Cells("Remarks").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Remarks = DataGridView.Cells("Remarks").Value.ToString()
                End If


                oCapitalExpenditurePPT.BudgetJan = DataGridView.Cells("BudgetJan").Value.ToString()
                oCapitalExpenditurePPT.BudgetFeb = DataGridView.Cells("BudgetFeb").Value.ToString()
                oCapitalExpenditurePPT.BudgetMar = DataGridView.Cells("BudgetMar").Value.ToString()
                oCapitalExpenditurePPT.BudgetApr = DataGridView.Cells("BudgetApr").Value.ToString()
                oCapitalExpenditurePPT.BudgetMay = DataGridView.Cells("BudgetMay").Value.ToString()
                oCapitalExpenditurePPT.BudgetJun = DataGridView.Cells("BudgetJun").Value.ToString()
                oCapitalExpenditurePPT.BudgetJul = DataGridView.Cells("BudgetJul").Value.ToString()
                oCapitalExpenditurePPT.BudgetAug = DataGridView.Cells("BudgetAug").Value.ToString()
                oCapitalExpenditurePPT.BudgetSep = DataGridView.Cells("BudgetSep").Value.ToString()
                oCapitalExpenditurePPT.BudgetOct = DataGridView.Cells("BudgetOct").Value.ToString()
                oCapitalExpenditurePPT.BudgetNov = DataGridView.Cells("BudgetNov").Value.ToString()
                oCapitalExpenditurePPT.BudgetDec = DataGridView.Cells("BudgetDec").Value.ToString()

                If DataGridView.Cells("RevJan").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevJan = DataGridView.Cells("RevJan").Value.ToString()
                End If
                If DataGridView.Cells("RevFeb").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevFeb = DataGridView.Cells("RevFeb").Value.ToString()
                End If
                If DataGridView.Cells("RevMar").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevMar = DataGridView.Cells("RevMar").Value.ToString()
                End If
                If DataGridView.Cells("RevApr").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevApr = DataGridView.Cells("RevApr").Value.ToString()
                End If
                If DataGridView.Cells("RevMay").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevMay = DataGridView.Cells("RevMay").Value.ToString()
                End If
                If DataGridView.Cells("RevJun").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevJun = DataGridView.Cells("RevJun").Value.ToString()
                End If
                If DataGridView.Cells("RevJul").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevJul = DataGridView.Cells("RevJul").Value.ToString()
                End If
                If DataGridView.Cells("RevAug").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevAug = DataGridView.Cells("RevAug").Value.ToString()
                End If
                If DataGridView.Cells("RevSep").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevSep = DataGridView.Cells("RevSep").Value.ToString()
                End If
                If DataGridView.Cells("RevOct").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevOct = DataGridView.Cells("RevOct").Value.ToString()
                End If
                If DataGridView.Cells("RevNov").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevNov = DataGridView.Cells("RevNov").Value.ToString()
                End If
                If DataGridView.Cells("RevDec").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.RevDec = DataGridView.Cells("RevDec").Value.ToString()
                End If


                If DataGridView.Cells("PinkJan").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipJan = DataGridView.Cells("PinkJan").Value.ToString()
                End If
                If DataGridView.Cells("PinkFeb").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipFeb = DataGridView.Cells("PinkFeb").Value.ToString()
                End If
                If DataGridView.Cells("PinkMar").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipMar = DataGridView.Cells("PinkMar").Value.ToString()
                End If
                If DataGridView.Cells("PinkApr").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipApr = DataGridView.Cells("PinkApr").Value.ToString()
                End If
                If DataGridView.Cells("PinkMay").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipMay = DataGridView.Cells("PinkMay").Value.ToString()
                End If
                If DataGridView.Cells("PinkJun").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipJun = DataGridView.Cells("PinkJun").Value.ToString()
                End If
                If DataGridView.Cells("PinkJul").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipJul = DataGridView.Cells("PinkJul").Value.ToString()
                End If
                If DataGridView.Cells("PinkAug").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipAug = DataGridView.Cells("PinkAug").Value.ToString()
                End If
                If DataGridView.Cells("PinkSep").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipSep = DataGridView.Cells("PinkSep").Value.ToString()
                End If
                If DataGridView.Cells("PinkOct").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipOct = DataGridView.Cells("PinkOct").Value.ToString()
                End If
                If DataGridView.Cells("PinkNov").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipNov = DataGridView.Cells("PinkNov").Value.ToString()
                End If
                If DataGridView.Cells("PinkDec").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.PinkSlipDec = DataGridView.Cells("PinkDec").Value.ToString()
                End If

                If DataGridView.Cells("Status").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.Status = DataGridView.Cells("Status").Value.ToString()
                End If


                If DataGridView.Cells("VersionNo").Value.ToString() <> "" Then
                    oCapitalExpenditurePPT.VersionNo = DataGridView.Cells("VersionNo").Value.ToString()
                End If
                oCapitalExpenditurePPT.BudgetTotal = DataGridView.Cells("BudgetTotal").Value.ToString()

                ds = CapitalExpenditureBOL.CapitalExpendInsert(oCapitalExpenditurePPT)

                strBudgetID = ""
            Next


            If ds Is Nothing Then
                MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                MessageBox.Show("Data successfully saved", "BSP")

            End If

            AddFlag = True
            ClearGridView(dgCapitalExpend)
            griddgCapitalExpViewBind()
            tbCapitalExpenditure.SelectedTab = tbView


        Else
            MessageBox.Show("Please Add record to save", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    Private Sub UpdateFunction()
        Dim ds As New DataSet
        For Each DataGridView In dgCapitalExpend.Rows
            Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT

            oCapitalExpenditurePPT.BudgetYear = DataGridView.Cells("BudgetYear").Value.ToString()
            oCapitalExpenditurePPT.BudgetID = DataGridView.Cells("BudgetID").Value.ToString()
            oCapitalExpenditurePPT.COAId = DataGridView.Cells("COAID").Value.ToString()
            oCapitalExpenditurePPT.COACode = DataGridView.Cells("COACode").Value.ToString()

            oCapitalExpenditurePPT.SubDesc = DataGridView.Cells("SubDesc").Value.ToString()
            oCapitalExpenditurePPT.Qty = DataGridView.Cells("Qty").Value.ToString()
            oCapitalExpenditurePPT.Cost = DataGridView.Cells("Cost").Value.ToString()
            oCapitalExpenditurePPT.Price = DataGridView.Cells("Price").Value.ToString()
            oCapitalExpenditurePPT.Day = DataGridView.Cells("Day").Value.ToString()
            oCapitalExpenditurePPT.Month = DataGridView.Cells("Month").Value.ToString()
            oCapitalExpenditurePPT.Percentage = DataGridView.Cells("Percentage").Value.ToString()


            oCapitalExpenditurePPT.Remarks = DataGridView.Cells("Remarks").Value.ToString()
            oCapitalExpenditurePPT.BudgetJan = DataGridView.Cells("BudgetJan").Value.ToString()
            oCapitalExpenditurePPT.BudgetFeb = DataGridView.Cells("BudgetFeb").Value.ToString()
            oCapitalExpenditurePPT.BudgetMar = DataGridView.Cells("BudgetMar").Value.ToString()
            oCapitalExpenditurePPT.BudgetApr = DataGridView.Cells("BudgetApr").Value.ToString()
            oCapitalExpenditurePPT.BudgetMay = DataGridView.Cells("BudgetMay").Value.ToString()
            oCapitalExpenditurePPT.BudgetJun = DataGridView.Cells("BudgetJun").Value.ToString()
            oCapitalExpenditurePPT.BudgetJul = DataGridView.Cells("BudgetJul").Value.ToString()
            oCapitalExpenditurePPT.BudgetAug = DataGridView.Cells("BudgetAug").Value.ToString()
            oCapitalExpenditurePPT.BudgetSep = DataGridView.Cells("BudgetSep").Value.ToString()
            oCapitalExpenditurePPT.BudgetOct = DataGridView.Cells("BudgetOct").Value.ToString()
            oCapitalExpenditurePPT.BudgetNov = DataGridView.Cells("BudgetNov").Value.ToString()
            oCapitalExpenditurePPT.BudgetDec = DataGridView.Cells("BudgetDec").Value.ToString()

            If DataGridView.Cells("RevJan").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevJan = DataGridView.Cells("RevJan").Value.ToString()
            End If
            If DataGridView.Cells("RevFeb").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevFeb = DataGridView.Cells("RevFeb").Value.ToString()
            End If
            If DataGridView.Cells("RevMar").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevMar = DataGridView.Cells("RevMar").Value.ToString()
            End If
            If DataGridView.Cells("RevApr").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevApr = DataGridView.Cells("RevApr").Value.ToString()
            End If
            If DataGridView.Cells("RevMay").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevMay = DataGridView.Cells("RevMay").Value.ToString()
            End If
            If DataGridView.Cells("RevJun").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevJun = DataGridView.Cells("RevJun").Value.ToString()
            End If
            If DataGridView.Cells("RevJul").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevJul = DataGridView.Cells("RevJul").Value.ToString()
            End If
            If DataGridView.Cells("RevAug").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevAug = DataGridView.Cells("RevAug").Value.ToString()
            End If
            If DataGridView.Cells("RevSep").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevSep = DataGridView.Cells("RevSep").Value.ToString()
            End If
            If DataGridView.Cells("RevOct").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevOct = DataGridView.Cells("RevOct").Value.ToString()
            End If
            If DataGridView.Cells("RevNov").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevNov = DataGridView.Cells("RevNov").Value.ToString()
            End If
            If DataGridView.Cells("RevDec").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevDec = DataGridView.Cells("RevDec").Value.ToString()
            End If


            If DataGridView.Cells("PinkSlipJan").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.PinkSlipJan = DataGridView.Cells("PinkSlipJan").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipFeb").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevFeb = DataGridView.Cells("PinkSlipFeb").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipMar").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevMar = DataGridView.Cells("PinkSlipMar").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipApr").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevApr = DataGridView.Cells("PinkSlipApr").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipMay").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevMay = DataGridView.Cells("PinkSlipMay").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipJun").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevJun = DataGridView.Cells("PinkSlipJun").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipJul").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevJul = DataGridView.Cells("PinkSlipJul").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipAug").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevAug = DataGridView.Cells("PinkSlipAug").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipSep").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevSep = DataGridView.Cells("PinkSlipSep").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipOct").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevOct = DataGridView.Cells("PinkSlipOct").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipNov").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevNov = DataGridView.Cells("PinkSlipNov").Value.ToString()
            End If
            If DataGridView.Cells("PinkSlipDec").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.RevDec = DataGridView.Cells("PinkSlipDec").Value.ToString()
            End If


            If DataGridView.Cells("Status").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.Status = DataGridView.Cells("Status").Value.ToString()
            End If


            If DataGridView.Cells("VersionNo").Value.ToString() <> "" Then
                oCapitalExpenditurePPT.VersionNo = DataGridView.Cells("VersionNo").Value.ToString()
            End If
            oCapitalExpenditurePPT.BudgetTotal = DataGridView.Cells("BudgetTotal").Value.ToString()

            ds = CapitalExpenditureBOL.CapitalExpendUpdate(oCapitalExpenditurePPT)
        Next
        If ds Is Nothing Then
            MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

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
    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        Clear()
        ClearGridView(dgCapitalExpend)
        btnAdd.Text = "Add"
        btnSaveAll.Text = "Save All"
        AddFlag = True
    End Sub
    Private Sub griddgCapitalExpViewBind()
        Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
        oCapitalExpenditurePPT.BudgetYear = lblBudgetYearView.Text.Trim
        oCapitalExpenditurePPT.COACode = txtCOACodeView.Text.Trim
        Dim dt As New DataTable
        dt = CapitalExpenditureBOL.CapitalExpendSelect(oCapitalExpenditurePPT)
        If dt.Rows.Count <> 0 Then
            lblNoRecordFound.Visible = False
            dgCapitalExpView.DataSource = dt
            dgCapitalExpView.AutoGenerateColumns = False
        Else
            lblNoRecordFound.Visible = True
            dgCapitalExpView.DataSource = dt
            dgCapitalExpView.AutoGenerateColumns = False
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete()
        griddgCapitalExpViewBind()
        tbCapitalExpenditure.SelectedTab = tbView
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Clear()
        btnAdd.Text = "Add"
        btnSaveAll.Text = "Save All"
        tbCapitalExpenditure.SelectedTab = tbCapitalExpend
    End Sub
    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        dgCapitalExpViewEdit()
    End Sub


    Private Sub Delete()
      
        'If dgCapitalExpView.Rows.Count > 0 Then
        '    If Me.btnSaveAll.Text = "Update All" Then
        '        MessageBox.Show("Record in edit mode, please update first", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Sub
        '    End If
        '    If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        oCapitalExpenditurePPT.BudgetID = dgCapitalExpView.SelectedRows(0).Cells("BudgetIDView").Value.ToString

        '        CapitalExpenditureBOL.CapitalExpendDelete(oCapitalExpenditurePPT)
        '        griddgCapitalExpViewBind()
        '        MessageBox.Show("Record deleted successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'End If


        Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
        Dim oCapitalExpenditureBOL As New CapitalExpenditureBOL
        Dim DsDelete As New DataSet
        'If e.KeyCode = Keys.Delete Then
        If dgCapitalExpView.Rows.Count > 0 Then
            If Me.btnSaveAll.Text = "Update" Then
                MessageBox.Show("Record in edit mode, please update first", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            oCapitalExpenditurePPT.BudgetID = dgCapitalExpView.SelectedRows(0).Cells("BudgetIDView").Value.ToString
            oCapitalExpenditurePPT.BudgetYear = dgCapitalExpView.SelectedRows(0).Cells("BudgetYearView").Value.ToString
            oCapitalExpenditurePPT.COAId = dgCapitalExpView.SelectedRows(0).Cells("ViewCOAId").Value.ToString
            oCapitalExpenditurePPT.VersionNo = dgCapitalExpView.SelectedRows(0).Cells("VersionNoView").Value.ToString
            'If oCapitalExpenditurePPT.VersionNo > 1 Then
            DsDelete = CapitalExpenditureBOL.CapitalExpendDelete(oCapitalExpenditurePPT)
            griddgCapitalExpViewBind()
            MessageBox.Show("Record deleted successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Exit Sub
            'End If

        End If

    End Sub

    Private Sub MyTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown, txtBudgetJan.KeyDown, txtBudgetFeb.KeyDown, txtBudgetMar.KeyDown, txtBudgetApr.KeyDown, txtBudgetMay.KeyDown, txtBudgetJun.KeyDown, txtBudgetJul.KeyDown, txtBudgetAug.KeyDown, txtBudgetSep.KeyDown, txtBudgetOct.KeyDown, txtBudgetNov.KeyDown, txtBudgetDec.KeyDown, txtRevJan.KeyDown, txtRevFeb.KeyDown, txtRevMar.KeyDown, txtRevApr.KeyDown, txtRevMay.KeyDown, txtRevJun.KeyDown, txtRevJul.KeyDown, txtRevAug.KeyDown, txtRevSep.KeyDown, txtRevOct.KeyDown, txtRevNov.KeyDown, txtRevDec.KeyDown, txtQty.KeyDown, txtCost.KeyDown, txtDay.KeyDown, txtMonth.KeyDown, txtPercentage.KeyDown
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
    Private Sub MyTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress, txtBudgetJan.KeyPress, txtBudgetFeb.KeyPress, txtBudgetMar.KeyPress, txtBudgetApr.KeyPress, txtBudgetMay.KeyPress, txtBudgetJun.KeyPress, txtBudgetJul.KeyPress, txtBudgetAug.KeyPress, txtBudgetSep.KeyPress, txtBudgetOct.KeyPress, txtBudgetNov.KeyPress, txtBudgetDec.KeyPress, txtRevJan.KeyPress, txtRevFeb.KeyPress, txtRevMar.KeyPress, txtRevApr.KeyPress, txtRevMay.KeyPress, txtRevJun.KeyPress, txtRevJul.KeyPress, txtRevAug.KeyPress, txtRevSep.KeyPress, txtRevOct.KeyPress, txtRevNov.KeyPress, txtRevDec.KeyPress, txtQty.KeyPress, txtCost.KeyPress, txtDay.KeyPress, txtMonth.KeyPress, txtPercentage.KeyPress
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub dgCapitalExpViewEdit()
        Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
        Dim oCapitalExpenditureBOL As New CapitalExpenditureBOL
        Dim dt As New DataTable


        oCapitalExpenditurePPT.COACode = dgCapitalExpView.CurrentRow.Cells("COACodeView").Value.ToString()
        oCapitalExpenditurePPT.BudgetYear = dgCapitalExpView.CurrentRow.Cells("BudgetYearView").Value.ToString()
        dtCapitalExpend = CapitalExpenditureBOL.CapitalExpendSelect(oCapitalExpenditurePPT)
        'dtCapitalExpend = CapitalExpenditureBOL.CapitalExpendSelect(oCapitalExpenditurePPT)

        If dtCapitalExpend.Rows.Count > 0 Then
            dgCapitalExpend.DataSource = dtCapitalExpend
            dgCapitalExpend.AutoGenerateColumns = False
        Else
            dgCapitalExpend.DataSource = dtCapitalExpend
            dgCapitalExpend.AutoGenerateColumns = False
        End If

        'If dgCapitalExpView.Rows.Count > 0 Then
        '    strCapitalExpendID = dgCapitalExpView.SelectedRows(0).Cells("BudgetIDView").Value.ToString()
        '    strCOAId = dgCapitalExpView.SelectedRows(0).Cells("ViewCOAId").Value.ToString()
        '    'strVHID = dgCapitalExpView.SelectedRows(0).Cells("VHIDView").Value.ToString()
        '    lblBudgetYear.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetYearView").Value.ToString()
        '    'txtVHNo.Text = dgCapitalExpView.SelectedRows(0).Cells("VHNoView").Value.ToString()
        '    'lblVHDescp.Text = dgCapitalExpView.SelectedRows(0).Cells("VHDescpView").Value.ToString()
        '    txtCOACode.Text = dgCapitalExpView.SelectedRows(0).Cells("COACodeView").Value.ToString()
        '    lblCOADescp.Text = dgCapitalExpView.SelectedRows(0).Cells("COADescpView").Value.ToString()
        '    'lblDriverName.Text = dgCapitalExpView.SelectedRows(0).Cells("EmpNameView").Value.ToString()
        '    'txtNoOfHours.Text = dgCapitalExpView.SelectedRows(0).Cells("NoOfHoursView").Value.ToString()
        '    lblVersionNo.Text = dgCapitalExpView.SelectedRows(0).Cells("VersionNoView").Value.ToString()
        '    lblStatus.Text = dgCapitalExpView.SelectedRows(0).Cells("StatusView").Value.ToString()
        '    txtAmount.Text = dgCapitalExpView.SelectedRows(0).Cells("PriceView").Value.ToString()

        '    txtBudgetJan.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetJanView").Value.ToString()
        '    txtBudgetFeb.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetFebView").Value.ToString()
        '    txtBudgetMar.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetMarView").Value.ToString()
        '    txtBudgetApr.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetAprView").Value.ToString()
        '    txtBudgetMay.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetMayView").Value.ToString()
        '    txtBudgetJun.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetJunView").Value.ToString()
        '    txtBudgetJul.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetJulView").Value.ToString()
        '    txtBudgetAug.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetAugView").Value.ToString()
        '    txtBudgetSep.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetSepView").Value.ToString()
        '    txtBudgetOct.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetOctView").Value.ToString()
        '    txtBudgetNov.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetNovView").Value.ToString()
        '    txtBudgetDec.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetDecView").Value.ToString()

        '    txtRevJan.Text = dgCapitalExpView.SelectedRows(0).Cells("RevJanView").Value.ToString()
        '    txtRevFeb.Text = dgCapitalExpView.SelectedRows(0).Cells("RevFebView").Value.ToString()
        '    txtRevMar.Text = dgCapitalExpView.SelectedRows(0).Cells("RevMarView").Value.ToString()
        '    txtRevApr.Text = dgCapitalExpView.SelectedRows(0).Cells("RevAprView").Value.ToString()
        '    txtRevMay.Text = dgCapitalExpView.SelectedRows(0).Cells("RevMayView").Value.ToString()
        '    txtRevJun.Text = dgCapitalExpView.SelectedRows(0).Cells("RevJunView").Value.ToString()
        '    txtRevJul.Text = dgCapitalExpView.SelectedRows(0).Cells("RevJulView").Value.ToString()
        '    txtRevAug.Text = dgCapitalExpView.SelectedRows(0).Cells("RevAugView").Value.ToString()
        '    txtRevSep.Text = dgCapitalExpView.SelectedRows(0).Cells("RevSepView").Value.ToString()
        '    txtRevOct.Text = dgCapitalExpView.SelectedRows(0).Cells("RevOctView").Value.ToString()
        '    txtRevNov.Text = dgCapitalExpView.SelectedRows(0).Cells("RevNovView").Value.ToString()
        '    txtRevDec.Text = dgCapitalExpView.SelectedRows(0).Cells("RevDecView").Value.ToString()

        '    lblPinkJan.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkJanView").Value.ToString()
        '    lblPinkFeb.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkFebView").Value.ToString()
        '    lblPinkMar.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkMarView").Value.ToString()
        '    lblPinkApr.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkAprView").Value.ToString()

        '    lblPinkMay.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkMayView").Value.ToString()
        '    lblPinkJun.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkJunView").Value.ToString()
        '    lblPinkJul.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkJulView").Value.ToString()
        '    lblPinkAug.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkAugView").Value.ToString()

        '    lblPinkSep.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkSepView").Value.ToString()
        '    lblPinkOct.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkOctView").Value.ToString()
        '    lblPinkNov.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkNovView").Value.ToString()
        '    lblPinkDec.Text = dgCapitalExpView.SelectedRows(0).Cells("PinkDecView").Value.ToString()

        '    lblBudgetTotal.Text = dgCapitalExpView.SelectedRows(0).Cells("BudgetTotalView").Value.ToString()
        'End If
        ''btnAdd.Text = "Update"
        'btnSaveAll.Text = "Update All"
        'AddFlag = False
        'dgCapitalExpendBind()
        'Clear()
        tbCapitalExpenditure.SelectedTab = tbCapitalExpend
    End Sub
    Private Sub dgCapitalExpendBind()
        Try
            Dim oCapitalExpenditurePPT As New CapitalExpenditurePPT
            Dim oCapitalExpenditureBOL As New CapitalExpenditureBOL

            With oCapitalExpenditurePPT
                .BudgetID = strBudgetID
                .COAId = strCOAId
                .COACode = txtCOACode.Text
            End With
            dtCapitalExpend = CapitalExpenditureBOL.CapitalExpenditureSelect_Multi(oCapitalExpenditurePPT)
            If dtCapitalExpend.Rows.Count <> 0 Then
                dgCapitalExpend.DataSource = dtCapitalExpend
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgCapitalExpView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCapitalExpView.DoubleClick
        dgCapitalExpViewEdit()
        tbCapitalExpenditure.SelectedTab = tbCapitalExpend
        lblVersionNo.Visible = True
        lblVersionNoL.Visible = True
        lblStatus.Visible = True
        lblStatusL.Visible = True
        'btnAdd.Text = "Update"
        btnSaveAll.Text = "Update All"
    End Sub
    Private Sub dgCapitalExpend_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCapitalExpend.DoubleClick
        Dim ds As New DataSet
        If dgCapitalExpend.RowCount > 0 Then
            strBudgetID = dgCapitalExpend.SelectedRows(0).Cells("BudgetID").Value.ToString()
            strCOAId = dgCapitalExpend.SelectedRows(0).Cells("COAID").Value.ToString()
            'strVHID = dgCapitalExpend.SelectedRows(0).Cells("VHID").Value.ToString()
            lblBudgetYear.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetYear").Value.ToString()
            txtRemarks.Text = dgCapitalExpend.SelectedRows(0).Cells("Remarks").Value.ToString()
            'lblVHDescp.Text = dgCapitalExpend.SelectedRows(0).Cells("VHDescp").Value.ToString()
            txtCOACode.Text = dgCapitalExpend.SelectedRows(0).Cells("COACode").Value.ToString()
            lblCOADescp.Text = dgCapitalExpend.SelectedRows(0).Cells("COADescp").Value.ToString()
            'lblDriverName.Text = dgCapitalExpend.SelectedRows(0).Cells("EmpName").Value.ToString()
            txtAmount.Text = dgCapitalExpend.SelectedRows(0).Cells("Price").Value.ToString()
            lblVersionNo.Text = dgCapitalExpend.SelectedRows(0).Cells("VersionNo").Value.ToString()
            lblStatus.Text = dgCapitalExpend.SelectedRows(0).Cells("Status").Value.ToString()

            txtBudgetJan.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetJan").Value.ToString()
            txtBudgetFeb.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetFeb").Value.ToString()
            txtBudgetMar.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetMar").Value.ToString()
            txtBudgetApr.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetApr").Value.ToString()
            txtBudgetMay.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetMay").Value.ToString()
            txtBudgetJun.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetJun").Value.ToString()
            txtBudgetJul.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetJul").Value.ToString()
            txtBudgetAug.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetAug").Value.ToString()
            txtBudgetSep.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetSep").Value.ToString()
            txtBudgetOct.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetOct").Value.ToString()
            txtBudgetNov.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetNov").Value.ToString()
            txtBudgetDec.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetDec").Value.ToString()

            txtRevJan.Text = dgCapitalExpend.SelectedRows(0).Cells("RevJan").Value.ToString()
            txtRevFeb.Text = dgCapitalExpend.SelectedRows(0).Cells("RevFeb").Value.ToString()
            txtRevMar.Text = dgCapitalExpend.SelectedRows(0).Cells("RevMar").Value.ToString()
            txtRevApr.Text = dgCapitalExpend.SelectedRows(0).Cells("RevApr").Value.ToString()
            txtRevMay.Text = dgCapitalExpend.SelectedRows(0).Cells("RevMay").Value.ToString()
            txtRevJun.Text = dgCapitalExpend.SelectedRows(0).Cells("RevJun").Value.ToString()
            txtRevJul.Text = dgCapitalExpend.SelectedRows(0).Cells("RevJul").Value.ToString()
            txtRevAug.Text = dgCapitalExpend.SelectedRows(0).Cells("RevAug").Value.ToString()
            txtRevSep.Text = dgCapitalExpend.SelectedRows(0).Cells("RevSep").Value.ToString()
            txtRevOct.Text = dgCapitalExpend.SelectedRows(0).Cells("RevOct").Value.ToString()
            txtRevNov.Text = dgCapitalExpend.SelectedRows(0).Cells("RevNov").Value.ToString()
            txtRevDec.Text = dgCapitalExpend.SelectedRows(0).Cells("RevDec").Value.ToString()

            lblPinkJan.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkJan").Value.ToString()
            lblPinkFeb.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkFeb").Value.ToString()
            lblPinkMar.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkMar").Value.ToString()
            lblPinkApr.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkApr").Value.ToString()
            lblPinkMay.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkMay").Value.ToString()
            lblPinkJun.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkJun").Value.ToString()
            lblPinkJul.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkJul").Value.ToString()
            lblPinkAug.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkAug").Value.ToString()
            lblPinkSep.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkSep").Value.ToString()
            lblPinkOct.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkOct").Value.ToString()
            lblPinkNov.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkNov").Value.ToString()
            lblPinkDec.Text = dgCapitalExpend.SelectedRows(0).Cells("PinkDec").Value.ToString()

            lblOldCOACode.Text = dgCapitalExpend.CurrentRow.Cells("OldCOACode").Value.ToString()
            'txtAmount.Text = dgAdminExpand.CurrentRow.Cells("Price").Value.ToString()
            txtSubDesc.Text = dgCapitalExpend.CurrentRow.Cells("SubDesc").Value.ToString()
            txtQty.Text = dgCapitalExpend.CurrentRow.Cells("Qty").Value.ToString()
            txtCost.Text = dgCapitalExpend.CurrentRow.Cells("Cost").Value.ToString()
            txtDay.Text = dgCapitalExpend.CurrentRow.Cells("Day").Value.ToString()
            txtMonth.Text = dgCapitalExpend.CurrentRow.Cells("Month").Value.ToString()
            txtPercentage.Text = dgCapitalExpend.CurrentRow.Cells("Percentage").Value.ToString()

            lblBudgetTotal.Text = dgCapitalExpend.SelectedRows(0).Cells("BudgetTotal").Value.ToString()
        End If
        btnAdd.Text = "Update"
        btnSaveAll.Text = "Update All"
        AddFlag = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtCOACodeView.Text.Trim = String.Empty Then
            MsgBox("Please Enter Criteria to Search!")
            griddgCapitalExpViewBind()
            lblCOADescpView.Text = ""
            txtCOACodeView.Text = ""
            Exit Sub
        Else
            griddgCapitalExpViewBind()
            If dgCapitalExpView.RowCount = 0 Then
                MsgBox("No record(s) found matching your search criteria.")
            End If
            lblCOADescpView.Text = ""
            txtCOACodeView.Text = ""
        End If
    End Sub

  
    Private Sub btnResetGeneral_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetGeneral.Click
        txtSubDesc.Text = ""
        txtQty.Text = ""
        txtCost.Text = ""
        txtMonth.Text = ""
        txtDay.Text = ""
        txtPercentage.Text = ""

        txtAmount.Text = ""
        txtRemarks.Text = ""
        txtBudgetJan.Text = ""
        txtBudgetFeb.Text = ""
        txtBudgetMar.Text = ""
        txtBudgetApr.Text = ""
        txtBudgetMay.Text = ""
        txtBudgetJun.Text = ""
        txtBudgetJul.Text = ""
        txtBudgetAug.Text = ""
        txtBudgetSep.Text = ""
        txtBudgetOct.Text = ""
        txtBudgetNov.Text = ""
        txtBudgetDec.Text = ""

        txtRevJan.Text = ""
        txtRevFeb.Text = ""
        txtRevMar.Text = ""
        txtRevApr.Text = ""
        txtRevMay.Text = ""
        txtRevJun.Text = ""
        txtRevJul.Text = ""
        txtRevAug.Text = ""
        txtRevSep.Text = ""
        txtRevOct.Text = ""
        txtRevNov.Text = ""
        txtRevDec.Text = ""

        lblPinkJan.Text = ""
        lblPinkFeb.Text = ""
        lblPinkMar.Text = ""
        lblPinkApr.Text = ""
        lblPinkMay.Text = ""
        lblPinkJun.Text = ""
        lblPinkJul.Text = ""
        lblPinkAug.Text = ""
        lblPinkSep.Text = ""
        lblPinkOct.Text = ""
        lblPinkNov.Text = ""
        lblPinkDec.Text = ""
    End Sub
End Class