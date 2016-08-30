Imports Common_PPT
Imports Common_BOL
Imports Budget_PPT
Imports Budget_BOL
Imports System.Data.SqlClient
Imports System.Math
Public Class AdministrationExpenditureFrm
    Public strBudgetID As String = String.Empty
    Public strBudgetYear As String = String.Empty
    Public strCOAId As String = String.Empty
    Public strOldCOAID As String = String.Empty
    'Private AddFlag As Boolean = True
    'Private dtAddFlag As Boolean = True


    Public dtAddFlag As Boolean = False
    Public AddFlag As Boolean = True
    'Public OtherAddFlag As Boolean = True

    Dim dtAdminExpand As New DataTable("dgAdminExpand")
    Dim columnAdminExpand As DataColumn
    Dim rowAdminExpand As DataRow

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")

    Dim isDecimal1 As Boolean
    Dim reDecimalPlaces0 As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,0})?$")

    Private Sub btnSearchAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccountCode.Click
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtCOACode.Text = frmAcctcodeLookup.strAcctcode
            strCOAId = frmAcctcodeLookup.strAcctId
            lblCOADescp.Text = frmAcctcodeLookup.strAcctDescp
            lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
            GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            'strOldCOAID = frmAcctcodeLookup.strOldAccountCode
        End If

    End Sub
    Private Sub AdministrationExpenditureFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub AdministrationExpenditureFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        tbAdminExpend.SelectedTab = tbView
        Me.lblBudgetYear.Text = GlobalPPT.intLoginYear
        lblBudgetYearView.Text = GlobalPPT.intLoginYear
        lblVersionNoL.Visible = False
        Label17.Visible = False
        lblVersionNo.Visible = False
        lblStatusL.Visible = False
        Label18.Visible = False
        lblStatus.Visible = False
        lblCOADescp.Text = ""
        lblCOADescpView.Text = ""
        GridAdmExpViewbind()
        'Dim dsDet As New DataSet
        'dsDet = AdministrationExpenditureBOL.AdminExpendSelect()

        'If dsDet.Tables(0).Rows.Count <> 0 Then
        '    dgAdmExpView.DataSource = dsDet.Tables(0)
        '    dgAdmExpView.AutoGenerateColumns = False
        'End If
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
    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        'If AddFlag = True Then
        '    'If IsValidSaveAll() = True Then
        '    dgAdminExpand.AutoGenerateColumns = False
        SaveFunction()
        '    btnSaveAll.Text = "Save"s
        '    'Else
        '    '    Exit Sub
        '    'End If

        'ElseIf AddFlag = False Then
        '    'If IsValidSaveAll() = True Then
        '    dgAdminExpand.AutoGenerateColumns = False
        '    UpdateFunction()
        '    btnSaveAll.Text = "Save"
        '    'Else
        '    '    Exit Sub
        '    'End If
        'End If

        'Dim dsDet As New DataSet
        'dsDet = AdministrationExpenditureBOL.AdminExpendSelect()

        'If dsDet.Tables(0).Rows.Count <> 0 Then
        '    dgAdminExpand.DataSource = dsDet.Tables(0)
        '    dgAdminExpand.AutoGenerateColumns = False
        'End If
       
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        Clear()
        lblVersionNoL.Visible = False
        lblVersionNo.Visible = False
        lblStatusL.Visible = False
        lblStatus.Visible = False
        ClearGridView(dgAdminExpand)
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

        'btnSaveAll.Text = "Save"


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub
    Private Function IsValidSaveAll() As Boolean
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        Dim ds As New DataSet

        If (txtCOACode.Text.Trim() = String.Empty) Then
            MessageBox.Show(" Please Key in COA ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCOACode.Focus()
            Return False

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

    Private Sub btnSearchCOACode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCOACode.Click
        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtCOACodeView.Text = frmAcctcodeLookup.strAcctcode
            strCOAId = frmAcctcodeLookup.strAcctId
            lblCOADescpView.Text = frmAcctcodeLookup.strAcctDescp

        End If
    End Sub
   

    Private Sub GridEdit()
        If dgAdminExpand.Rows.Count > 0 Then
            btnAdd.Text = "Update"

            lblVersionNo.Visible = True
            lblVersionNoL.Visible = True
            lblStatusL.Visible = True
            lblStatus.Visible = True

            txtCOACode.Text = dgAdminExpand.CurrentRow.Cells("COACode").Value.ToString()
            lblCOADescp.Text = dgAdminExpand.CurrentRow.Cells("COADescp").Value.ToString()
            lblOldCOACode.Text = dgAdminExpand.CurrentRow.Cells("OldCOACode").Value.ToString()
            txtAmount.Text = dgAdminExpand.CurrentRow.Cells("Price").Value.ToString.Trim
            txtSubDesc.Text = dgAdminExpand.CurrentRow.Cells("SubDesc").Value.ToString()
            txtQty.Text = dgAdminExpand.CurrentRow.Cells("Qty").Value.ToString()
            txtCost.Text = dgAdminExpand.CurrentRow.Cells("Cost").Value.ToString()
            txtDay.Text = dgAdminExpand.CurrentRow.Cells("Day").Value.ToString()
            txtMonth.Text = dgAdminExpand.CurrentRow.Cells("Month").Value.ToString()
            txtPercentage.Text = dgAdminExpand.CurrentRow.Cells("Percentage").Value.ToString()
            txtRemarks.Text = dgAdminExpand.CurrentRow.Cells("Remarks").Value.ToString()
            lblBudgetTotal.Text = dgAdminExpand.CurrentRow.Cells("BudgetTotal").Value.ToString()
            strCOAId = dgAdminExpand.CurrentRow.Cells("COAId").Value.ToString()

            txtBudgetJan.Text = dgAdminExpand.CurrentRow.Cells("BudgetJan").Value.ToString()
            txtBudgetFeb.Text = dgAdminExpand.CurrentRow.Cells("BudgetFeb").Value.ToString()
            txtBudgetMar.Text = dgAdminExpand.CurrentRow.Cells("BudgetMar").Value.ToString()
            txtBudgetApr.Text = dgAdminExpand.CurrentRow.Cells("BudgetApr").Value.ToString()
            txtBudgetMay.Text = dgAdminExpand.CurrentRow.Cells("BudgetMay").Value.ToString()
            txtBudgetJun.Text = dgAdminExpand.CurrentRow.Cells("BudgetJun").Value.ToString()
            txtBudgetJul.Text = dgAdminExpand.CurrentRow.Cells("BudgetJul").Value.ToString()
            txtBudgetAug.Text = dgAdminExpand.CurrentRow.Cells("BudgetAug").Value.ToString()
            txtBudgetSep.Text = dgAdminExpand.CurrentRow.Cells("BudgetSep").Value.ToString()
            txtBudgetOct.Text = dgAdminExpand.CurrentRow.Cells("BudgetOct").Value.ToString()
            txtBudgetNov.Text = dgAdminExpand.CurrentRow.Cells("BudgetNov").Value.ToString()
            txtBudgetDec.Text = dgAdminExpand.CurrentRow.Cells("BudgetDec").Value.ToString()
            lblVersionNo.Text = dgAdminExpand.CurrentRow.Cells("VersionNo").Value.ToString()
            lblStatus.Text = dgAdminExpand.CurrentRow.Cells("Status").Value.ToString()


            txtRevJan.Text = dgAdminExpand.CurrentRow.Cells("RevJan").Value.ToString()
            txtRevFeb.Text = dgAdminExpand.CurrentRow.Cells("RevFeb").Value.ToString()
            txtRevMar.Text = dgAdminExpand.CurrentRow.Cells("RevMar").Value.ToString()
            txtRevApr.Text = dgAdminExpand.CurrentRow.Cells("RevApr").Value.ToString()
            txtRevMay.Text = dgAdminExpand.CurrentRow.Cells("RevMay").Value.ToString()
            txtRevJun.Text = dgAdminExpand.CurrentRow.Cells("RevJun").Value.ToString()
            txtRevJul.Text = dgAdminExpand.CurrentRow.Cells("RevJul").Value.ToString()
            txtRevAug.Text = dgAdminExpand.CurrentRow.Cells("RevAug").Value.ToString()
            txtRevSep.Text = dgAdminExpand.CurrentRow.Cells("RevSep").Value.ToString()
            txtRevOct.Text = dgAdminExpand.CurrentRow.Cells("RevOct").Value.ToString()
            txtRevNov.Text = dgAdminExpand.CurrentRow.Cells("RevNov").Value.ToString()
            txtRevDec.Text = dgAdminExpand.CurrentRow.Cells("RevDec").Value.ToString()

            lblPinkJan.Text = dgAdminExpand.CurrentRow.Cells("PinkJan").Value.ToString()
            lblPinkFeb.Text = dgAdminExpand.CurrentRow.Cells("PinkFeb").Value.ToString()
            lblPinkMar.Text = dgAdminExpand.CurrentRow.Cells("PinkMar").Value.ToString()
            lblPinkApr.Text = dgAdminExpand.CurrentRow.Cells("PinkApr").Value.ToString()
            lblPinkMay.Text = dgAdminExpand.CurrentRow.Cells("PinkMay").Value.ToString()
            lblPinkJun.Text = dgAdminExpand.CurrentRow.Cells("PinkJun").Value.ToString()
            lblPinkJul.Text = dgAdminExpand.CurrentRow.Cells("PinkJul").Value.ToString()
            lblPinkAug.Text = dgAdminExpand.CurrentRow.Cells("PinkAug").Value.ToString()
            lblPinkSep.Text = dgAdminExpand.CurrentRow.Cells("PinkSep").Value.ToString()
            lblPinkOct.Text = dgAdminExpand.CurrentRow.Cells("PinkOct").Value.ToString()
            lblPinkNov.Text = dgAdminExpand.CurrentRow.Cells("PinkNov").Value.ToString()
            lblPinkDec.Text = dgAdminExpand.CurrentRow.Cells("PinkDec").Value.ToString()

            strBudgetID = dgAdminExpand.CurrentRow.Cells("BudgetID").Value.ToString()
            lblVersionNo.Text = dgAdminExpand.CurrentRow.Cells("VersionNo").Value.ToString()
            lblStatus.Text = dgAdminExpand.CurrentRow.Cells("Status").Value.ToString()

            AddFlag = False

        End If
    End Sub
    Private Sub dgAdminExpand_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAdminExpand.DoubleClick
        GridEdit()
    End Sub
    Private Sub SaveFunction()
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        Dim ds As New DataSet
        Dim dsupdate As New DataSet
        If dgAdminExpand.Rows.Count > 0 Then


            For Each DataGridViewRow In dgAdminExpand.Rows

                oAdministrationExpenditurePPT.BudgetYear = DataGridViewRow.Cells("BudgetYear").Value.ToString()

                oAdministrationExpenditurePPT.COAId = DataGridViewRow.Cells("COAId").Value.ToString()

                If DataGridViewRow.Cells("SubDesc").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.SubDesc = DataGridViewRow.Cells("SubDesc").Value.ToString()
                End If
                If DataGridViewRow.Cells("Qty").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Qty = DataGridViewRow.Cells("Qty").Value.ToString()
                End If
                If DataGridViewRow.Cells("Cost").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Cost = DataGridViewRow.Cells("Cost").Value.ToString()
                End If
                If DataGridViewRow.Cells("Price").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Price = DataGridViewRow.Cells("Price").Value.ToString()
                End If
                If DataGridViewRow.Cells("Day").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Day = DataGridViewRow.Cells("Day").Value.ToString()
                End If
                If DataGridViewRow.Cells("Month").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Month = DataGridViewRow.Cells("Month").Value.ToString()
                End If
                If DataGridViewRow.Cells("Percentage").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Percentage = DataGridViewRow.Cells("Percentage").Value.ToString()
                End If
                If DataGridViewRow.Cells("Remarks").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Remarks = DataGridViewRow.Cells("Remarks").Value.ToString()
                End If





                oAdministrationExpenditurePPT.BudgetJan = (DataGridViewRow.Cells("BudgetJan").Value.ToString())
                oAdministrationExpenditurePPT.BudgetFeb = DataGridViewRow.Cells("BudgetFeb").Value.ToString()
                oAdministrationExpenditurePPT.BudgetMar = DataGridViewRow.Cells("BudgetMar").Value.ToString()
                oAdministrationExpenditurePPT.BudgetApr = DataGridViewRow.Cells("BudgetApr").Value.ToString()
                oAdministrationExpenditurePPT.BudgetMay = DataGridViewRow.Cells("BudgetMay").Value.ToString()
                oAdministrationExpenditurePPT.BudgetJun = DataGridViewRow.Cells("BudgetJun").Value.ToString()
                oAdministrationExpenditurePPT.BudgetJul = DataGridViewRow.Cells("BudgetJul").Value.ToString()
                oAdministrationExpenditurePPT.BudgetAug = DataGridViewRow.Cells("BudgetAug").Value.ToString()
                oAdministrationExpenditurePPT.BudgetSep = DataGridViewRow.Cells("BudgetSep").Value.ToString()
                oAdministrationExpenditurePPT.BudgetOct = DataGridViewRow.Cells("BudgetOct").Value.ToString()
                oAdministrationExpenditurePPT.BudgetNov = DataGridViewRow.Cells("BudgetNov").Value.ToString()
                oAdministrationExpenditurePPT.BudgetDec = DataGridViewRow.Cells("BudgetDec").Value.ToString()

                If DataGridViewRow.Cells("RevJan").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevJan = DataGridViewRow.Cells("RevJan").Value.ToString()
                End If

                If DataGridViewRow.Cells("RevFeb").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevFeb = DataGridViewRow.Cells("RevFeb").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevMar").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevMar = DataGridViewRow.Cells("RevMar").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevApr").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevApr = DataGridViewRow.Cells("RevApr").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevMay").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevMay = DataGridViewRow.Cells("RevMay").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevJun").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevJun = DataGridViewRow.Cells("RevJun").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevJul").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevJul = DataGridViewRow.Cells("RevJul").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevAug").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevAug = DataGridViewRow.Cells("RevAug").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevSep").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevSep = DataGridViewRow.Cells("RevSep").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevOct").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevOct = DataGridViewRow.Cells("RevOct").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevNov").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevNov = DataGridViewRow.Cells("RevNov").Value.ToString()
                End If
                If DataGridViewRow.Cells("RevDec").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.RevDec = DataGridViewRow.Cells("RevDec").Value.ToString()
                End If


                If DataGridViewRow.Cells("PinkJan").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkJan = DataGridViewRow.Cells("PinkJan").Value.ToString()
                End If

                If DataGridViewRow.Cells("PinkFeb").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkFeb = DataGridViewRow.Cells("PinkFeb").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkMar").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkMar = DataGridViewRow.Cells("PinkMar").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkApr").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkApr = DataGridViewRow.Cells("PinkApr").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkMay").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkMay = DataGridViewRow.Cells("PinkMay").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkJun").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkJun = DataGridViewRow.Cells("PinkJun").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkJul").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkJul = DataGridViewRow.Cells("PinkJul").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkAug").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkAug = DataGridViewRow.Cells("PinkAug").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkSep").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkSep = DataGridViewRow.Cells("PinkSep").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkOct").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkOct = DataGridViewRow.Cells("PinkOct").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkNov").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkNov = DataGridViewRow.Cells("PinkNov").Value.ToString()
                End If
                If DataGridViewRow.Cells("PinkDec").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.PinkDec = DataGridViewRow.Cells("PinkDec").Value.ToString()
                End If


                If DataGridViewRow.Cells("Status").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.Status = DataGridViewRow.Cells("Status").Value.ToString()
                End If

                If DataGridViewRow.Cells("VersionNo").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.VersionNo = DataGridViewRow.Cells("VersionNo").Value.ToString()
                End If
                If DataGridViewRow.Cells("BudgetID").Value.ToString() <> "" Then
                    oAdministrationExpenditurePPT.BudgetID = DataGridViewRow.Cells("BudgetID").Value.ToString()
                End If


                oAdministrationExpenditurePPT.BudgetTotal = DataGridViewRow.Cells("BudgetTotal").Value.ToString()

                'If strBudgetID = "" Then
                ds = AdministrationExpenditureBOL.AdminExpendInsert(oAdministrationExpenditurePPT)
                'Else
                'dsupdate = AdministrationExpenditureBOL.ExpBudAdminExpendUpdate(oAdministrationExpenditurePPT)
                'End If
                strBudgetID = ""
            Next


            If ds Is Nothing Then
                MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
                AddFlag = True
            Else
                MessageBox.Show("Saved Successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            btnSaveAll.Text = "Save"
            Clear()
            ClearGridView(dgAdminExpand)
            AddFlag = True
            lblVersionNoL.Visible = False
            lblVersionNo.Visible = False
            lblStatusL.Visible = False
            lblStatus.Visible = False
            Clear()
            ClearGridView(dgAdminExpand)
            GridAdmExpViewbind()

        Else
            MessageBox.Show("Please Add record to save", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

      
        'tbAdminExpend.SelectedTab = tbView
        'If dsupdate Is Nothing Then
        '    MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub

        'Else
        '    MessageBox.Show("Updated Successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

    End Sub


    Private Sub UpdateFunction()
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        Dim ds As New DataSet

        For Each DataGridViewRow In dgAdminExpand.Rows

            oAdministrationExpenditurePPT.BudgetYear = DataGridViewRow.Cells("BudgetYear").Value.ToString()

            oAdministrationExpenditurePPT.COAId = DataGridViewRow.Cells("COAId").Value.ToString()
            oAdministrationExpenditurePPT.SubDesc = DataGridViewRow.Cells("SubDesc").Value.ToString()
            oAdministrationExpenditurePPT.Qty = DataGridViewRow.Cells("Qty").Value.ToString()
            oAdministrationExpenditurePPT.Cost = DataGridViewRow.Cells("Cost").Value.ToString()
            oAdministrationExpenditurePPT.Price = DataGridViewRow.Cells("Price").Value.ToString()
            oAdministrationExpenditurePPT.Day = DataGridViewRow.Cells("Day").Value.ToString()
            oAdministrationExpenditurePPT.Month = DataGridViewRow.Cells("Month").Value.ToString()
            oAdministrationExpenditurePPT.Percentage = DataGridViewRow.Cells("Percentage").Value.ToString()


            oAdministrationExpenditurePPT.Remarks = DataGridViewRow.Cells("Remarks").Value.ToString()
            oAdministrationExpenditurePPT.BudgetJan = (DataGridViewRow.Cells("BudgetJan").Value.ToString())
            oAdministrationExpenditurePPT.BudgetFeb = DataGridViewRow.Cells("BudgetFeb").Value.ToString()
            oAdministrationExpenditurePPT.BudgetMar = DataGridViewRow.Cells("BudgetMar").Value.ToString()
            oAdministrationExpenditurePPT.BudgetApr = DataGridViewRow.Cells("BudgetApr").Value.ToString()
            oAdministrationExpenditurePPT.BudgetMay = DataGridViewRow.Cells("BudgetMay").Value.ToString()
            oAdministrationExpenditurePPT.BudgetJun = DataGridViewRow.Cells("BudgetJun").Value.ToString()
            oAdministrationExpenditurePPT.BudgetJul = DataGridViewRow.Cells("BudgetJul").Value.ToString()
            oAdministrationExpenditurePPT.BudgetAug = DataGridViewRow.Cells("BudgetAug").Value.ToString()
            oAdministrationExpenditurePPT.BudgetSep = DataGridViewRow.Cells("BudgetSep").Value.ToString()
            oAdministrationExpenditurePPT.BudgetOct = DataGridViewRow.Cells("BudgetOct").Value.ToString()
            oAdministrationExpenditurePPT.BudgetNov = DataGridViewRow.Cells("BudgetNov").Value.ToString()
            oAdministrationExpenditurePPT.BudgetDec = DataGridViewRow.Cells("BudgetDec").Value.ToString()

            If DataGridViewRow.Cells("RevJan").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevJan = DataGridViewRow.Cells("RevJan").Value.ToString()
            End If

            If DataGridViewRow.Cells("RevFeb").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevFeb = DataGridViewRow.Cells("RevFeb").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevMar").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevMar = DataGridViewRow.Cells("RevMar").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevApr").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevApr = DataGridViewRow.Cells("RevApr").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevMay").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevMay = DataGridViewRow.Cells("RevMay").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevJun").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevJun = DataGridViewRow.Cells("RevJun").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevJul").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevJul = DataGridViewRow.Cells("RevJul").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevAug").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevAug = DataGridViewRow.Cells("RevAug").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevSep").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevSep = DataGridViewRow.Cells("RevSep").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevOct").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevOct = DataGridViewRow.Cells("RevOct").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevNov").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevNov = DataGridViewRow.Cells("RevNov").Value.ToString()
            End If
            If DataGridViewRow.Cells("RevDec").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevDec = DataGridViewRow.Cells("RevDec").Value.ToString()
            End If


            If DataGridViewRow.Cells("PinkJan").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevJan = DataGridViewRow.Cells("PinkJan").Value.ToString()
            End If

            If DataGridViewRow.Cells("PinkFeb").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevFeb = DataGridViewRow.Cells("PinkFeb").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkMar").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevMar = DataGridViewRow.Cells("PinkMar").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkApr").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevApr = DataGridViewRow.Cells("PinkApr").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkMay").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevMay = DataGridViewRow.Cells("PinkMay").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkJun").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevJun = DataGridViewRow.Cells("PinkJun").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkJul").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevJul = DataGridViewRow.Cells("PinkJul").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkAug").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevAug = DataGridViewRow.Cells("PinkAug").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkSep").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevSep = DataGridViewRow.Cells("PinkSep").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkOct").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevOct = DataGridViewRow.Cells("PinkOct").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkNov").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevNov = DataGridViewRow.Cells("PinkNov").Value.ToString()
            End If
            If DataGridViewRow.Cells("PinkDec").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.RevDec = DataGridViewRow.Cells("PinkDec").Value.ToString()
            End If


            If DataGridViewRow.Cells("Status").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.Status = DataGridViewRow.Cells("Status").Value.ToString()
            End If

            If DataGridViewRow.Cells("VersionNo").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.VersionNo = DataGridViewRow.Cells("VersionNo").Value.ToString()
            End If
            If DataGridViewRow.Cells("BudgetTotal").Value.ToString() <> "" Then
                oAdministrationExpenditurePPT.BudgetTotal = DataGridViewRow.Cells("BudgetTotal").Value.ToString()
            End If
            'oAdministrationExpenditurePPT.BudgetTotal = Me.lblBudgetTotal.Text

            ds = AdministrationExpenditureBOL.ExpBudAdminExpendUpdate(oAdministrationExpenditurePPT)
        Next
        'oAdministrationExpenditurePPT.BudgetYear = Me.lblBudgetYear.Text
        'oAdministrationExpenditurePPT.Price = Me.txtAmount.Text
        'oAdministrationExpenditurePPT.COAId = strCOAId.ToString()
        'oAdministrationExpenditurePPT.COACode = txtCOACode.Text
        'oAdministrationExpenditurePPT.COADescp = lblCOADescp.Text
        'oAdministrationExpenditurePPT.Remarks = Me.txtRemarks.Text
        'oAdministrationExpenditurePPT.BudgetJan = Me.txtBudgetJan.Text
        'oAdministrationExpenditurePPT.BudgetFeb = Me.txtBudgetFeb.Text
        'oAdministrationExpenditurePPT.BudgetMar = Me.txtBudgetMar.Text
        'oAdministrationExpenditurePPT.BudgetApr = Me.txtBudgetApr.Text
        'oAdministrationExpenditurePPT.BudgetMay = Me.txtBudgetMay.Text
        'oAdministrationExpenditurePPT.BudgetJun = Me.txtBudgetJun.Text
        'oAdministrationExpenditurePPT.BudgetJul = Me.txtBudgetJul.Text
        'oAdministrationExpenditurePPT.BudgetAug = Me.txtBudgetAug.Text
        'oAdministrationExpenditurePPT.BudgetSep = Me.txtBudgetSep.Text
        'oAdministrationExpenditurePPT.BudgetOct = Me.txtBudgetOct.Text
        'oAdministrationExpenditurePPT.BudgetNov = Me.txtBudgetNov.Text
        'oAdministrationExpenditurePPT.BudgetDec = Me.txtBudgetDec.Text

        'If txtRevJan.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevJan = Me.txtRevJan.Text.ToString()
        'End If

        'If txtRevFeb.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevFeb = Me.txtRevFeb.Text.ToString()
        'End If
        'If txtRevMar.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevMar = Me.txtRevMar.Text.ToString()
        'End If
        'If txtRevApr.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevApr = Me.txtRevApr.Text.ToString()
        'End If
        'If txtRevMay.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevMay = Me.txtRevMay.Text.ToString()
        'End If
        'If txtRevJun.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevJun = Me.txtRevJun.Text.ToString()
        'End If
        'If txtRevJul.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevJul = Me.txtRevJul.Text.ToString()
        'End If
        'If txtRevAug.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevAug = Me.txtRevAug.Text.ToString()
        'End If
        'If txtRevSep.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevSep = Me.txtRevSep.Text.ToString()
        'End If
        'If txtRevOct.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevOct = Me.txtRevOct.Text.ToString()
        'End If
        'If txtRevNov.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevNov = Me.txtRevNov.Text.ToString()
        'End If
        'If txtRevDec.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.RevDec = Me.txtRevDec.Text.ToString()
        'End If
        'oAdministrationExpenditurePPT.BudgetTotal = Me.lblBudgetTotal.Text

        'oAdministrationExpenditurePPT.Status = Me.lblStatus.Text
        'If lblVersionNo.Text.ToString() <> "" Then
        '    oAdministrationExpenditurePPT.VersionNo = Me.lblVersionNo.Text.ToString()
        'End If
        'oAdministrationExpenditurePPT.BudgetID = Me.strBudgetID.ToString()

        If ds Is Nothing Then
            MessageBox.Show("Failed to Update database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            MessageBox.Show("Updated Successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        AddFlag = True
    End Sub
    Private Sub GridEditView()
        If dgAdmExpView.Rows.Count > 0 Then
            btnSaveAll.Text = "Update"

            Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
            Dim oAdministrationExpenditureBOL As New AdministrationExpenditureBOL
            Dim ds As New DataTable
            'lblVersionNo.Visible = True
            'lblVersionNoL.Visible = True
            'lblStatusL.Visible = True
            'lblStatus.Visible = True

            oAdministrationExpenditurePPT.COACode = dgAdmExpView.CurrentRow.Cells("COACodeView").Value.ToString()
            dtAdminExpand = AdministrationExpenditureBOL.ExpBudAdminExpendSelect(oAdministrationExpenditurePPT)

            If dtAdminExpand.Rows.Count > 0 Then
                dgAdminExpand.DataSource = dtAdminExpand
                dgAdminExpand.AutoGenerateColumns = False
            Else
                dgAdminExpand.DataSource = dtAdminExpand
                dgAdminExpand.AutoGenerateColumns = False
            End If
            'lblCOADescp.Text = dgAdmExpView.CurrentRow.Cells("COADescpView").Value.ToString()
            'txtAmount.Text = dgAdmExpView.CurrentRow.Cells("AmountView").Value.ToString()
            'txtRemarks.Text = dgAdmExpView.CurrentRow.Cells("RemarksView").Value.ToString()
            'lblBudgetTotal.Text = dgAdmExpView.CurrentRow.Cells("BudgetTotalView").Value.ToString()
            ''strCOAId = dgAdmExpView.CurrentRow.Cells("ViewCOAId").Value.ToString()
            'strCOAId = dgAdmExpView.CurrentRow.Cells("ViewCOAId").Value.ToString()

            'txtBudgetJan.Text = dgAdmExpView.CurrentRow.Cells("BudgetJanView").Value.ToString()
            'txtBudgetFeb.Text = dgAdmExpView.CurrentRow.Cells("BudgetFebView").Value.ToString()
            'txtBudgetMar.Text = dgAdmExpView.CurrentRow.Cells("BudgetMarView").Value.ToString()
            'txtBudgetApr.Text = dgAdmExpView.CurrentRow.Cells("BudgetAprView").Value.ToString()
            'txtBudgetMay.Text = dgAdmExpView.CurrentRow.Cells("BudgetMayView").Value.ToString()
            'txtBudgetJun.Text = dgAdmExpView.CurrentRow.Cells("BudgetJunView").Value.ToString()
            'txtBudgetJul.Text = dgAdmExpView.CurrentRow.Cells("BudgetJulView").Value.ToString()
            'txtBudgetAug.Text = dgAdmExpView.CurrentRow.Cells("BudgetAugView").Value.ToString()
            'txtBudgetSep.Text = dgAdmExpView.CurrentRow.Cells("BudgetSepView").Value.ToString()
            'txtBudgetOct.Text = dgAdmExpView.CurrentRow.Cells("BudgetOctView").Value.ToString()
            'txtBudgetNov.Text = dgAdmExpView.CurrentRow.Cells("BudgetNovView").Value.ToString()
            'txtBudgetDec.Text = dgAdmExpView.CurrentRow.Cells("BudgetDecView").Value.ToString()
            'lblVersionNo.Text = dgAdmExpView.CurrentRow.Cells("VersionNoView").Value.ToString()
            'lblStatus.Text = dgAdmExpView.CurrentRow.Cells("StatusView").Value.ToString()

            'If dgAdmExpView.CurrentRow.Cells("RevJanView").Value <> "" Then
            '    txtRevJan.Text = dgAdmExpView.CurrentRow.Cells("RevJanView").Value.ToString()
            'Else
            'End If

            'If dgAdmExpView.CurrentRow.Cells("RevFebView").Value <> "" Then
            '    txtRevFeb.Text = dgAdmExpView.CurrentRow.Cells("RevFebView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevMarView").Value <> "" Then
            '    txtRevMar.Text = dgAdmExpView.CurrentRow.Cells("RevMarView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevAprView").Value <> "" Then
            '    txtRevApr.Text = dgAdmExpView.CurrentRow.Cells("RevAprView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevMayView").Value <> "" Then
            '    txtRevMay.Text = dgAdmExpView.CurrentRow.Cells("RevMayView").Value.ToString()
            'Else
            'End If

            'If dgAdmExpView.CurrentRow.Cells("RevJunView").Value <> "" Then
            '    txtRevJun.Text = dgAdmExpView.CurrentRow.Cells("RevJunView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevJulView").Value <> "" Then
            '    txtRevJul.Text = dgAdmExpView.CurrentRow.Cells("RevJulView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevAugView").Value <> "" Then
            '    txtRevAug.Text = dgAdmExpView.CurrentRow.Cells("RevAugView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevSepView").Value <> "" Then
            '    txtRevSep.Text = dgAdmExpView.CurrentRow.Cells("RevSepView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevOctView").Value <> "" Then
            '    txtRevOct.Text = dgAdmExpView.CurrentRow.Cells("RevOctView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevNovView").Value <> "" Then
            '    txtRevNov.Text = dgAdmExpView.CurrentRow.Cells("RevNovView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("RevDecView").Value <> "" Then
            '    txtRevDec.Text = dgAdmExpView.CurrentRow.Cells("RevDecView").Value.ToString()
            'Else
            'End If

            ''txtRevFeb.Text = dgAdmExpView.CurrentRow.Cells("RevFebView").Value.ToString()
            ''txtRevMar.Text = dgAdmExpView.CurrentRow.Cells("RevMarView").Value.ToString()
            ''txtRevApr.Text = dgAdmExpView.CurrentRow.Cells("RevAprView").Value.ToString()
            ''txtRevMay.Text = dgAdmExpView.CurrentRow.Cells("RevMayView").Value.ToString()
            ''txtRevJun.Text = dgAdmExpView.CurrentRow.Cells("RevJunView").Value.ToString()
            ''txtRevJul.Text = dgAdmExpView.CurrentRow.Cells("RevJulView").Value.ToString()
            ''txtRevAug.Text = dgAdmExpView.CurrentRow.Cells("RevAugView").Value.ToString()
            ''txtRevSep.Text = dgAdmExpView.CurrentRow.Cells("RevSepView").Value.ToString()
            ''txtRevOct.Text = dgAdmExpView.CurrentRow.Cells("RevOctView").Value.ToString()
            ''txtRevNov.Text = dgAdmExpView.CurrentRow.Cells("RevNovView").Value.ToString()
            ''txtRevDec.Text = dgAdmExpView.CurrentRow.Cells("RevDecView").Value.ToString()
            'If dgAdmExpView.CurrentRow.Cells("PinkJanView").Value <> "" Then
            '    lblPinkJan.Text = dgAdmExpView.CurrentRow.Cells("PinkJanView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkFebView").Value <> "" Then
            '    lblPinkFeb.Text = dgAdmExpView.CurrentRow.Cells("PinkFebView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkMarView").Value <> "" Then
            '    lblPinkMar.Text = dgAdmExpView.CurrentRow.Cells("PinkMarView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkAprView").Value <> "" Then
            '    lblPinkApr.Text = dgAdmExpView.CurrentRow.Cells("PinkAprView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkMayView").Value <> "" Then
            '    lblPinkMay.Text = dgAdmExpView.CurrentRow.Cells("PinkMayView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkJunView").Value <> "" Then
            '    lblPinkJun.Text = dgAdmExpView.CurrentRow.Cells("PinkJunView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkJulView").Value <> "" Then
            '    lblPinkJul.Text = dgAdmExpView.CurrentRow.Cells("PinkJulView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkAugView").Value <> "" Then
            '    lblPinkAug.Text = dgAdmExpView.CurrentRow.Cells("PinkAugView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkSepView").Value <> "" Then
            '    lblPinkSep.Text = dgAdmExpView.CurrentRow.Cells("PinkSepView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkOctView").Value <> "" Then
            '    lblPinkOct.Text = dgAdmExpView.CurrentRow.Cells("PinkOctView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkNovView").Value <> "" Then
            '    lblPinkNov.Text = dgAdmExpView.CurrentRow.Cells("PinkNovView").Value.ToString()
            'Else
            'End If
            'If dgAdmExpView.CurrentRow.Cells("PinkDecView").Value <> "" Then
            '    lblPinkDec.Text = dgAdmExpView.CurrentRow.Cells("PinkDecView").Value.ToString()
            'Else
            'End If

            'strBudgetID = dgAdmExpView.CurrentRow.Cells("AdminExpendIDView").Value.ToString()
            'AddFlag = False
        End If

        tbAdminExpend.SelectedTab = tbAdminExpendi
    End Sub

    Private Sub dgAdmExpView_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAdmExpView.DoubleClick
        GridEditView()
    End Sub

    Private Sub Delete()
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        Dim DsDelete As New DataSet
        'If e.KeyCode = Keys.Delete Then
        If dgAdmExpView.Rows.Count > 0 Then
            If Me.btnSaveAll.Text = "Update" Then
                MessageBox.Show("Record in edit mode, please update first", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            oAdministrationExpenditurePPT.BudgetID = dgAdmExpView.SelectedRows(0).Cells("BudgetIDView").Value.ToString
            oAdministrationExpenditurePPT.BudgetYear = dgAdmExpView.SelectedRows(0).Cells("BudgetYearView").Value.ToString
            oAdministrationExpenditurePPT.COAId = dgAdmExpView.SelectedRows(0).Cells("ViewCOAId").Value.ToString
            oAdministrationExpenditurePPT.VersionNo = dgAdmExpView.SelectedRows(0).Cells("VersionNoView").Value.ToString

            DsDelete = AdministrationExpenditureBOL.AdminExpendDelete(oAdministrationExpenditurePPT)
            GridAdmExpViewbind()
            MessageBox.Show("Record deleted successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    Exit Sub
            'End If

        End If
    End Sub
    Private Sub dgAdminExpand_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgAdminExpand.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgAdminExpand.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgAdminExpand.ClearSelection()
                    dgAdminExpand.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub
    Private Sub dgAdmExpView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgAdmExpView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgAdmExpView.ClearSelection()
                    dgAdmExpView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete()
        GridAdmExpViewbind()
        'tbAdminExpend.SelectedTab = tbAdminExpendi
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        GridEditView()
        tbAdminExpend.SelectedTab = tbAdminExpendi
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Clear()
        tbAdminExpend.SelectedTab = tbAdminExpendi
    End Sub
    Private Sub GridAdmExpViewbind()
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        Dim dtdetail As New DataTable

        'Dim oAdministrationExpenditureBOL As AdministrationExpenditureBOL
        oAdministrationExpenditurePPT.COACode = txtCOACodeView.Text

        dtdetail = AdministrationExpenditureBOL.ExpBudAdminExpendSelect(oAdministrationExpenditurePPT)
        If dtdetail.Rows.Count <> 0 Then
            dgAdmExpView.DataSource = dtdetail
            dgAdmExpView.AutoGenerateColumns = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        oAdministrationExpenditurePPT.COACode = txtCOACodeView.Text
        Dim dt As New DataTable
        dt = AdministrationExpenditureBOL.ExpBudAdminExpendSelect(oAdministrationExpenditurePPT)
        If dt.Rows.Count <> 0 Then
            dgAdmExpView.Visible = True
            lblNoRecordFound.Visible = False
            dgAdmExpView.DataSource = dt

        Else
            dgAdmExpView.Visible = False
            lblNoRecordFound.Visible = True
            dgAdmExpView.DataSource = dt
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

    Private Sub dgAdminExpand_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgAdminExpand.KeyDown
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT
        Dim DsDelete As New DataSet

        If e.KeyCode = Keys.Delete Then
            If dgAdminExpand.Rows.Count > 0 Then

                If Me.btnSaveAll.Text = "Update" Then
                    MsgBox("Record in edit mode, please update first", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                oAdministrationExpenditurePPT.BudgetID = dgAdminExpand.SelectedRows(0).Cells("AdminExpendID").Value.ToString
                If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    DsDelete = AdministrationExpenditureBOL.AdminExpendDelete(oAdministrationExpenditurePPT)
                    Dim dtdetail As New DataTable
                    dtdetail = AdministrationExpenditureBOL.ExpBudAdminExpendSelect(oAdministrationExpenditurePPT)

                    dgAdminExpand.DataSource = dtdetail
                    dgAdminExpand.AutoGenerateColumns = False
                    GridAdmExpViewbind()

                    MsgBox("Record deleted successfully", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdministrationExpenditureFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tbAdminExpend.TabPages("tbAdminExpendi").Text = rm.GetString("tbAdminExpend.TabPages(tbAdminExpendi).Text")
            tbAdminExpend.TabPages("tbView").Text = rm.GetString("tbAdminExpend.TabPages(tbView).Text")

            lblBudgetyearL.Text = rm.GetString("lblBudgetyearL.Text")
            lblCOA.Text = rm.GetString("lblCOA.Text")
            lblCOADescp.Text = rm.GetString("lblCOADescp.Text")
            lblAmount.Text = rm.GetString("lblAmount.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblVersionNoL.Text = rm.GetString("lblVersionNoL.Text")
            lblStatusL.Text = rm.GetString("lblStatusL.Text")
            btnDistribute.Text = rm.GetString("btnDistribute.Text")

            lblBudget.Text = rm.GetString("lblBudget.Text")
            lblBudgetL.Text = rm.GetString("lblBudgetL.Text")
            lblBudgets.Text = rm.GetString("lblBudgets.Text")
            lblRevision.Text = rm.GetString("lblRevision.Text")
            lblRevisionL.Text = rm.GetString("lblRevisionL.Text")
            lblRevisions.Text = rm.GetString("lblRevisions.Text")
            lblPinkSlip.Text = rm.GetString("lblPinkSlip.Text")
            lblPinkSlipL.Text = rm.GetString("lblPinkSlipL.Text")
            lblPinks.Text = rm.GetString("lblPinks.Text")

            lblBudgetTotalL.Text = rm.GetString("lblBudgetTotalL.Text")

            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")


            dgAdmExpView.Columns("BudgetYearView").HeaderText = rm.GetString("dgAdmExpView.Columns(BudgetYearView).HeaderText")
            dgAdmExpView.Columns("COACodeView").HeaderText = rm.GetString("dgAdmExpView.Columns(COACodeView).HeaderText")
            dgAdmExpView.Columns("COADescpView").HeaderText = rm.GetString("dgAdmExpView.Columns(COADescpView).HeaderText")
            dgAdmExpView.Columns("AmountView").HeaderText = rm.GetString("dgAdmExpView.Columns(AmountView).HeaderText")
            dgAdmExpView.Columns("RemarksView").HeaderText = rm.GetString("dgAdmExpView.Columns(RemarksView).HeaderText")
            dgAdmExpView.Columns("StatusView").HeaderText = rm.GetString("dgAdmExpView.Columns(StatusView).HeaderText")
            dgAdmExpView.Columns("BudgetTotalView").HeaderText = rm.GetString("dgAdmExpView.Columns(BudgetTotalView).HeaderText")

            pnlAdmEXpSearch.CaptionText = rm.GetString("pnlAdmEXpSearch.Caption.Text")
            lblBudgetYearV.Text = rm.GetString("lblBudgetYearV.Text")
            lblCOADescpView.Text = rm.GetString("lbCOADescpView.Text")
            lblCoaCodeV.Text = rm.GetString("lblCoaCodeV.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")

            dgAdminExpand.Columns("BudgetYear").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetYear).HeaderText")
            dgAdminExpand.Columns("COACode").HeaderText = rm.GetString("dgAdminExpand.Columns(COACode).HeaderText")
            dgAdminExpand.Columns("COADescp").HeaderText = rm.GetString("dgAdminExpand.Columns(COADescp).HeaderText")
            dgAdminExpand.Columns("BudgetJan").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetJan).HeaderText")
            dgAdminExpand.Columns("BudgetFeb").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetFeb).HeaderText")
            dgAdminExpand.Columns("BudgetMar").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetMar).HeaderText")
            dgAdminExpand.Columns("BudgetApr").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetApr).HeaderText")
            dgAdminExpand.Columns("BudgetMay").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetMay).HeaderText")
            dgAdminExpand.Columns("BudgetJun").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetJun).HeaderText")
            dgAdminExpand.Columns("BudgetJul").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetJul).HeaderText")
            dgAdminExpand.Columns("BudgetAug").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetAug).HeaderText")
            dgAdminExpand.Columns("BudgetSep").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetSep).HeaderText")
            dgAdminExpand.Columns("BudgetOct").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetOct).HeaderText")
            dgAdminExpand.Columns("BudgetNov").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetNov).HeaderText")
            dgAdminExpand.Columns("BudgetDec").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetDec).HeaderText")
            dgAdminExpand.Columns("Price").HeaderText = rm.GetString("dgAdminExpand.Columns(Price).HeaderText")
            dgAdminExpand.Columns("Remarks").HeaderText = rm.GetString("dgAdminExpand.Columns(Remarks).HeaderText")
            dgAdminExpand.Columns("BudgetTotal").HeaderText = rm.GetString("dgAdminExpand.Columns(BudgetTotal).HeaderText")
            dgAdminExpand.Columns("Status").HeaderText = rm.GetString("dgAdminExpand.Columns(Status).HeaderText")
            dgAdminExpand.Columns("VersionNo").HeaderText = rm.GetString("dgAdminExpand.Columns(VersionNo).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbAdminExpend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAdminExpend.Click

        If dgAdminExpand.RowCount > 0 Or txtCOACode.Text <> "" Or txtAmount.Text <> "" Then
            If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tbAdminExpend.SelectedIndex = 0
            Else

                Clear()
                ClearGridView(dgAdminExpand)
                GridAdmExpViewbind()
                btnSaveAll.Text = "Save"

            End If
        Else
            Clear()
            ClearGridView(dgAdminExpand)
            GridAdmExpViewbind()
            btnSaveAll.Text = "Save"


        End If

        txtCOACodeView.Text = ""
        lblCOADescpView.Text = ""
        GridAdmExpViewbind()
        'Clear()
        'lblVersionNoL.Visible = False
        'lblVersionNo.Visible = False
        'lblStatusL.Visible = False
        'lblStatus.Visible = False
        'btnSaveAll.Text = "Save"

    End Sub

    Private Sub txtCOACode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOACode.Leave
        If txtCOACode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oStandardPinkSlipPPT As New StandardPinkSlipPPT
            oStandardPinkSlipPPT.COACode = txtCOACode.Text.Trim()
            Dim oStandardPinkSlipBOL As New StandardPinkSlipBOL
            ds = StandardPinkSlipBOL.AcctlookupSearch(oStandardPinkSlipPPT, "YES")
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
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If AddFlag = True Then
            If IsValidSaveAll() = True Then
                'dgRice.AutoGenerateColumns = False

                AddAdminExpand()
            Else
                Exit Sub
            End If
        ElseIf AddFlag = False Then
            If IsValidSaveAll() = True Then

                UpdateAdminExpand()
                btnAdd.Text = "Add"
            Else
                Exit Sub
            End If
        End If

    End Sub
    Private Function AccCodeExist(ByVal COAID As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgAdminExpand.Rows
                'If MS <> String.Empty Then
                If COAID = objDataGridViewRow.Cells("COAID").Value.ToString() Then
                    txtCOACode.Text = ""
                    txtCOACode.Focus()
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
    Private Sub AddAdminExpand()
        Dim intRowcount As Integer = dtAdminExpand.Rows.Count
        Dim oAdministrationExpenditurePPT As New AdministrationExpenditurePPT




        oAdministrationExpenditurePPT.BudgetYear = lblBudgetYear.Text.Trim()
        oAdministrationExpenditurePPT.COAId = strCOAId


        If AccCodeExist(oAdministrationExpenditurePPT.COAId) Then
            Exit Sub
        End If

        rowAdminExpand = dtAdminExpand.NewRow()

        If intRowcount = 0 And dtAddFlag = False Then


            columnAdminExpand = New DataColumn("BudgetYear", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            columnAdminExpand = New DataColumn("COAID", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            columnAdminExpand = New DataColumn("COACode", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("SubDesc", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Qty", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Cost", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Price", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Day", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Month", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Percentage", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            columnAdminExpand = New DataColumn("BudgetJan", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetFeb", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetMar", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetApr", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetMay", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetJun", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetJul", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetAug", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetSep", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetOct", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetNov", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetDec", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            columnAdminExpand = New DataColumn("RevJan", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevFeb", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevMar", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevApr", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevMay", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevJun", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevJul", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevAug", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevSep", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevOct", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevNov", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("RevDec", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            columnAdminExpand = New DataColumn("PinkJan", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkFeb", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkMar", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkApr", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkMay", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkJun", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkJul", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkAug", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkSep", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkOct", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkNov", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("PinkDec", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            columnAdminExpand = New DataColumn("Remarks", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetTotal", System.Type.[GetType]("System.Decimal"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("VersionNo", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("Status", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)
            columnAdminExpand = New DataColumn("BudgetID", System.Type.[GetType]("System.String"))
            dtAdminExpand.Columns.Add(columnAdminExpand)

            rowAdminExpand("BudgetYear") = lblBudgetYear.Text.ToString()

            rowAdminExpand("COAID") = strCOAId.ToString()
            rowAdminExpand("COACode") = txtCOACode.Text.ToString()
            rowAdminExpand("COADescp") = lblCOADescp.Text.ToString()
            rowAdminExpand("OldCOACode") = lblOldCOACode.Text.ToString()
            If txtSubDesc.Text <> "" Then
                rowAdminExpand("SubDesc") = txtSubDesc.Text.ToString()
            End If
            If txtQty.Text <> "" Then
                rowAdminExpand("Qty") = txtQty.Text.ToString()
            End If
            If txtCost.Text <> "" Then
                rowAdminExpand("Cost") = txtCost.Text.ToString()
            End If

            rowAdminExpand("Price") = txtAmount.Text.ToString()
            If txtDay.Text <> "" Then
                rowAdminExpand("Day") = txtDay.Text.ToString()
            End If
            If txtMonth.Text <> "" Then
                rowAdminExpand("Month") = txtMonth.Text.ToString()
            End If
            If txtPercentage.Text <> "" Then
                rowAdminExpand("Percentage") = txtPercentage.Text.ToString()
            End If


            rowAdminExpand("BudgetJan") = txtBudgetJan.Text.ToString()
            rowAdminExpand("BudgetFeb") = txtBudgetFeb.Text.ToString()
            rowAdminExpand("BudgetMar") = txtBudgetMar.Text.ToString()
            rowAdminExpand("BudgetApr") = txtBudgetApr.Text.ToString()
            rowAdminExpand("BudgetMay") = txtBudgetMay.Text.ToString()
            rowAdminExpand("BudgetJun") = txtBudgetJun.Text.ToString()
            rowAdminExpand("BudgetJul") = txtBudgetJul.Text.ToString()
            rowAdminExpand("BudgetAug") = txtBudgetAug.Text.ToString()
            rowAdminExpand("BudgetSep") = txtBudgetSep.Text.ToString()
            rowAdminExpand("BudgetOct") = txtBudgetOct.Text.ToString()
            rowAdminExpand("BudgetNov") = txtBudgetNov.Text.ToString()
            rowAdminExpand("BudgetDec") = txtBudgetDec.Text.ToString()

            If txtRevJan.Text <> "" Then
                rowAdminExpand("RevJan") = txtRevJan.Text.ToString()
            End If
            If txtRevFeb.Text <> "" Then
                rowAdminExpand("RevFeb") = txtRevFeb.Text.ToString()
            End If
            If txtRevMar.Text <> "" Then
                rowAdminExpand("RevMar") = txtRevMar.Text.ToString()
            End If
            If txtRevApr.Text <> "" Then
                rowAdminExpand("RevApr") = txtRevApr.Text.ToString()
            End If
            If txtRevMay.Text <> "" Then
                rowAdminExpand("RevMay") = txtRevMay.Text.ToString()
            End If
            If txtRevJun.Text <> "" Then
                rowAdminExpand("RevJun") = txtRevJun.Text.ToString()
            End If
            If txtRevJul.Text <> "" Then
                rowAdminExpand("RevJul") = txtRevJul.Text.ToString()
            End If
            If txtRevAug.Text <> "" Then
                rowAdminExpand("RevAug") = txtRevAug.Text.ToString()
            End If
            If txtRevSep.Text <> "" Then
                rowAdminExpand("RevSep") = txtRevSep.Text.ToString()
            End If
            If txtRevOct.Text <> "" Then
                rowAdminExpand("RevOct") = txtRevOct.Text.ToString()
            End If
            If txtRevNov.Text <> "" Then
                rowAdminExpand("RevNov") = txtRevNov.Text.ToString()
            End If
            If txtRevDec.Text <> "" Then
                rowAdminExpand("RevDec") = txtRevDec.Text.ToString()
            End If



            If lblPinkJan.Text <> "" Then
                rowAdminExpand("PinkJan") = lblPinkJan.Text.ToString()
            End If
            If lblPinkFeb.Text <> "" Then
                rowAdminExpand("PinkFeb") = lblPinkFeb.Text.ToString()
            End If
            If lblPinkMar.Text <> "" Then
                rowAdminExpand("PinkMar") = lblPinkMar.Text.ToString()
            End If
            If lblPinkApr.Text <> "" Then
                rowAdminExpand("PinkApr") = lblPinkApr.Text.ToString()
            End If
            If lblPinkMay.Text <> "" Then
                rowAdminExpand("PinkMay") = lblPinkMay.Text.ToString()
            End If
            If lblPinkJun.Text <> "" Then
                rowAdminExpand("PinkJun") = lblPinkJun.Text.ToString()
            End If
            If lblPinkJul.Text <> "" Then
                rowAdminExpand("PinkJul") = lblPinkJul.Text.ToString()
            End If
            If lblPinkAug.Text <> "" Then
                rowAdminExpand("PinkAug") = lblPinkAug.Text.ToString()
            End If
            If lblPinkSep.Text <> "" Then
                rowAdminExpand("PinkSep") = lblPinkSep.Text.ToString()
            End If
            If lblPinkOct.Text <> "" Then
                rowAdminExpand("PinkOct") = lblPinkOct.Text.ToString()
            End If
            If lblPinkNov.Text <> "" Then
                rowAdminExpand("PinkNov") = lblPinkNov.Text.ToString()
            End If
            If lblPinkDec.Text <> "" Then
                rowAdminExpand("PinkDec") = lblPinkDec.Text.ToString()
            End If










            rowAdminExpand("Remarks") = txtRemarks.Text.ToString()
            rowAdminExpand("BudgetTotal") = lblBudgetTotal.Text.ToString()
            If lblVersionNo.Text <> "" Then
                rowAdminExpand("VersionNo") = lblVersionNo.Text.ToString()
            End If
            If lblStatus.Text <> "" Then
                rowAdminExpand("Status") = lblStatus.Text.ToString()
            End If

            rowAdminExpand("BudgetID") = strBudgetID.ToString()


            dtAdminExpand.Rows.InsertAt(rowAdminExpand, intRowcount)
            dgAdminExpand.AutoGenerateColumns = False
            dtAddFlag = True

        Else
            rowAdminExpand("BudgetYear") = lblBudgetYear.Text.ToString()

            rowAdminExpand("COAID") = strCOAId.ToString()
            rowAdminExpand("COACode") = txtCOACode.Text.ToString()
            rowAdminExpand("COADescp") = lblCOADescp.Text.ToString()
            rowAdminExpand("OldCOACode") = lblOldCOACode.Text.ToString()

            If txtSubDesc.Text <> "" Then
                rowAdminExpand("SubDesc") = txtSubDesc.Text.ToString()
            End If
            If txtQty.Text <> "" Then
                rowAdminExpand("Qty") = txtQty.Text.ToString()
            End If
            If txtCost.Text <> "" Then
                rowAdminExpand("Cost") = txtCost.Text.ToString()
            End If

            rowAdminExpand("Price") = txtAmount.Text.ToString()
            If txtDay.Text <> "" Then
                rowAdminExpand("Day") = txtDay.Text.ToString()
            End If
            If txtMonth.Text <> "" Then
                rowAdminExpand("Month") = txtMonth.Text.ToString()
            End If
            If txtPercentage.Text <> "" Then
                rowAdminExpand("Percentage") = txtPercentage.Text.ToString()
            End If

            rowAdminExpand("BudgetJan") = txtBudgetJan.Text.ToString()
            rowAdminExpand("BudgetFeb") = txtBudgetFeb.Text.ToString()
            rowAdminExpand("BudgetMar") = txtBudgetMar.Text.ToString()
            rowAdminExpand("BudgetApr") = txtBudgetApr.Text.ToString()
            rowAdminExpand("BudgetMay") = txtBudgetMay.Text.ToString()
            rowAdminExpand("BudgetJun") = txtBudgetJun.Text.ToString()
            rowAdminExpand("BudgetJul") = txtBudgetJul.Text.ToString()
            rowAdminExpand("BudgetAug") = txtBudgetAug.Text.ToString()
            rowAdminExpand("BudgetSep") = txtBudgetSep.Text.ToString()
            rowAdminExpand("BudgetOct") = txtBudgetOct.Text.ToString()
            rowAdminExpand("BudgetNov") = txtBudgetNov.Text.ToString()
            rowAdminExpand("BudgetDec") = txtBudgetDec.Text.ToString()

            If txtRevJan.Text <> "" Then
                rowAdminExpand("RevJan") = txtRevJan.Text.ToString()
            End If
            If txtRevFeb.Text <> "" Then
                rowAdminExpand("RevFeb") = txtRevFeb.Text.ToString()
            End If
            If txtRevMar.Text <> "" Then
                rowAdminExpand("RevMar") = txtRevMar.Text.ToString()
            End If
            If txtRevApr.Text <> "" Then
                rowAdminExpand("RevApr") = txtRevApr.Text.ToString()
            End If
            If txtRevMay.Text <> "" Then
                rowAdminExpand("RevMay") = txtRevMay.Text.ToString()
            End If
            If txtRevJun.Text <> "" Then
                rowAdminExpand("RevJun") = txtRevJun.Text.ToString()
            End If
            If txtRevJul.Text <> "" Then
                rowAdminExpand("RevJul") = txtRevJul.Text.ToString()
            End If
            If txtRevAug.Text <> "" Then
                rowAdminExpand("RevAug") = txtRevAug.Text.ToString()
            End If
            If txtRevSep.Text <> "" Then
                rowAdminExpand("RevSep") = txtRevSep.Text.ToString()
            End If
            If txtRevOct.Text <> "" Then
                rowAdminExpand("RevOct") = txtRevOct.Text.ToString()
            End If
            If txtRevNov.Text <> "" Then
                rowAdminExpand("RevNov") = txtRevNov.Text.ToString()
            End If
            If txtRevDec.Text <> "" Then
                rowAdminExpand("RevDec") = txtRevDec.Text.ToString()
            End If


            If lblPinkJan.Text <> "" Then
                rowAdminExpand("PinkJan") = lblPinkJan.Text.ToString()
            End If
            If lblPinkFeb.Text <> "" Then
                rowAdminExpand("PinkFeb") = lblPinkFeb.Text.ToString()
            End If
            If lblPinkMar.Text <> "" Then
                rowAdminExpand("PinkMar") = lblPinkMar.Text.ToString()
            End If
            If lblPinkApr.Text <> "" Then
                rowAdminExpand("PinkApr") = lblPinkApr.Text.ToString()
            End If
            If lblPinkMay.Text <> "" Then
                rowAdminExpand("PinkMay") = lblPinkMay.Text.ToString()
            End If
            If lblPinkJun.Text <> "" Then
                rowAdminExpand("PinkJun") = lblPinkJun.Text.ToString()
            End If
            If lblPinkJul.Text <> "" Then
                rowAdminExpand("PinkJul") = lblPinkJul.Text.ToString()
            End If
            If lblPinkAug.Text <> "" Then
                rowAdminExpand("PinkAug") = lblPinkAug.Text.ToString()
            End If
            If lblPinkSep.Text <> "" Then
                rowAdminExpand("PinkSep") = lblPinkSep.Text.ToString()
            End If
            If lblPinkOct.Text <> "" Then
                rowAdminExpand("PinkOct") = lblPinkOct.Text.ToString()
            End If
            If lblPinkNov.Text <> "" Then
                rowAdminExpand("PinkNov") = lblPinkNov.Text.ToString()
            End If
            If lblPinkDec.Text <> "" Then
                rowAdminExpand("PinkDec") = lblPinkDec.Text.ToString()
            End If

            rowAdminExpand("Remarks") = txtRemarks.Text.ToString()

            rowAdminExpand("BudgetTotal") = lblBudgetTotal.Text.ToString()
            If lblVersionNo.Text <> "" Then
                rowAdminExpand("VersionNo") = lblVersionNo.Text.ToString()
            End If
            If lblStatus.Text <> "" Then
                rowAdminExpand("Status") = lblStatus.Text.ToString()
            End If

            rowAdminExpand("BudgetID") = strBudgetID.ToString()

            dtAdminExpand.Rows.InsertAt(rowAdminExpand, intRowcount)
            dgAdminExpand.AutoGenerateColumns = False
            AddFlag = True
        End If
        dgAdminExpand.AutoGenerateColumns = False
        dgAdminExpand.DataSource = dtAdminExpand
        btnAdd.Text = "Add"
        Clear()
       



    End Sub

    Private Sub UpdateAdminExpand()
        Dim intCount As Integer = dgAdminExpand.CurrentRow.Index


       

        dgAdminExpand.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()

        dgAdminExpand.Rows(intCount).Cells("COAID").Value = strCOAId.ToString()
        dgAdminExpand.Rows(intCount).Cells("COACode").Value = txtCOACode.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("OldCOACode").Value = lblOldCOACode.Text.ToString()

        If txtSubDesc.Text = "" Then
            dgAdminExpand.Rows(intCount).Cells("SubDesc").Value = txtSubDesc.Text.ToString()
        End If
        If txtQty.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("Qty").Value = txtQty.Text.ToString()
        End If
        If txtCost.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("Cost").Value = txtCost.Text.ToString()
        End If
        If txtAmount.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("Price").Value = txtAmount.Text.ToString()
        End If
        If txtDay.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("Day").Value = txtDay.Text.ToString()
        End If
        If txtMonth.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("Month").Value = txtMonth.Text.ToString()
        End If
        If txtPercentage.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("Percentage").Value = txtPercentage.Text.ToString()
        End If

        dgAdminExpand.Rows(intCount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

        If txtRevJan.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevJan").Value = txtRevJan.Text.ToString()
        End If
        If txtRevFeb.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
        End If
        If txtRevMar.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevMar").Value = txtRevMar.Text.ToString()
        End If
        If txtRevApr.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevApr").Value = txtRevApr.Text.ToString()
        End If
        If txtRevMay.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevMay").Value = txtRevMay.Text.ToString()
        End If
        If txtRevJun.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevJun").Value = txtRevJun.Text.ToString()
        End If
        If txtRevJul.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevJul").Value = txtRevJul.Text.ToString()
        End If
        If txtRevAug.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevAug").Value = txtRevAug.Text.ToString()
        End If
        If txtRevSep.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevSep").Value = txtRevSep.Text.ToString()
        End If
        If txtRevOct.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevOct").Value = txtRevOct.Text.ToString()
        End If
        If txtRevNov.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevNov").Value = txtRevNov.Text.ToString()
        End If
        If txtRevDec.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("RevDec").Value = txtRevDec.Text.ToString()
        End If

        If lblPinkJan.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkJan").Value = lblPinkJan.Text.ToString()
        End If
        If lblPinkFeb.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkFeb").Value = lblPinkFeb.Text.ToString()
        End If
        If lblPinkMar.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkMar").Value = lblPinkMar.Text.ToString()
        End If
        If lblPinkApr.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkApr").Value = lblPinkApr.Text.ToString()
        End If
        If lblPinkMay.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkMay").Value = lblPinkMay.Text.ToString()
        End If
        If lblPinkJun.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkJun").Value = lblPinkJun.Text.ToString()
        End If
        If lblPinkJul.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkJul").Value = lblPinkJul.Text.ToString()
        End If
        If lblPinkAug.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkAug").Value = lblPinkAug.Text.ToString()
        End If
        If lblPinkSep.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkSep").Value = lblPinkSep.Text.ToString()
        End If
        If lblPinkOct.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkOct").Value = lblPinkOct.Text.ToString()
        End If
        If lblPinkNov.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkNov").Value = lblPinkNov.Text.ToString()
        End If
        If lblPinkDec.Text <> Nothing Then
            dgAdminExpand.Rows(intCount).Cells("PinkDec").Value = lblPinkDec.Text.ToString()
        End If

        dgAdminExpand.Rows(intCount).Cells("Remarks").Value = txtRemarks.Text.ToString()
        dgAdminExpand.Rows(intCount).Cells("BudgetTotal").Value = lblBudgetTotal.Text.ToString()
        'If lblVersionNo.Text <> "" Then
        '    rowAdminExpand("VersionNo") = lblVersionNo.Text.ToString()
        'End If
        'If lblStatus.Text <> "" Then
        '    rowAdminExpand("Status") = lblStatus.Text.ToString()
        'End If


        btnAdd.Text = "Add"
        'AddFlag = True
        If btnSaveAll.Text = "Save All" Then
            AddFlag = True
        Else
            AddFlag = False
        End If
        Clear()
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
    Private Sub MyTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown, txtBudgetJan.KeyDown, txtBudgetFeb.KeyDown, txtBudgetMar.KeyDown, txtBudgetApr.KeyDown, txtBudgetMay.KeyDown, txtBudgetJun.KeyDown, txtBudgetJul.KeyDown, txtBudgetAug.KeyDown, txtBudgetSep.KeyDown, txtBudgetOct.KeyDown, txtBudgetNov.KeyDown, txtBudgetDec.KeyDown, txtRevJan.KeyDown, txtRevFeb.KeyDown, txtRevMar.KeyDown, txtRevApr.KeyDown, txtRevMay.KeyDown, txtRevJun.KeyDown, txtRevJul.KeyDown, txtRevAug.KeyDown, txtRevSep.KeyDown, txtRevOct.KeyDown, txtRevNov.KeyDown, txtRevDec.KeyDown
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

                        isDecimal1 = reDecimalPlaces0.IsMatch(text)

                End Select
            Else
                isDecimal1 = False
                Return
            End If

        Else
            isDecimal1 = True
        End If
    End Sub
    Private Sub MyTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress, txtBudgetJan.KeyPress, txtBudgetFeb.KeyPress, txtBudgetMar.KeyPress, txtBudgetApr.KeyPress, txtBudgetMay.KeyPress, txtBudgetJun.KeyPress, txtBudgetJul.KeyPress, txtBudgetAug.KeyPress, txtBudgetSep.KeyPress, txtBudgetOct.KeyPress, txtBudgetNov.KeyPress, txtBudgetDec.KeyPress, txtRevJan.KeyPress, txtRevFeb.KeyPress, txtRevMar.KeyPress, txtRevApr.KeyPress, txtRevMay.KeyPress, txtRevJun.KeyPress, txtRevJul.KeyPress, txtRevAug.KeyPress, txtRevSep.KeyPress, txtRevOct.KeyPress, txtRevNov.KeyPress, txtRevDec.KeyPress
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal1 = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
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
        'lblVersionNo.Text = ""
        'lblStatus.Text = ""
    End Sub
End Class