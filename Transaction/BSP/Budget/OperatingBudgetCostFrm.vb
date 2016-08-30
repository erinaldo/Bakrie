Imports Common_PPT
Imports Common_BOL
Imports Budget_PPT
Imports Budget_BOL
Imports System.Data.SqlClient
Public Class OperatingBudgetCostFrm

    'Public strOperatingBudgetByCostID As String = String.Empty
    'Public strCOAID As String = String.Empty
    'Public strVHDetailCostCodeID As String = String.Empty
    'Public strVHID As String = String.Empty
    'Public strVHType As String = String.Empty
    'Public strVHNo As String = String.Empty

    'Private AddFlag As Boolean = True

    'Dim dtOperatingCost As New DataTable("dgOperatingCost")
    'Dim columnOperatingCost As DataColumn
    'Dim rowOperatingCost As DataRow
    'Dim isDecimal As Boolean
    'Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")


    'Private Sub OperatingBudgetCostFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub
    'Private Sub OperatingBudgetCostFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    tbOperatingBDGCost.SelectedTab = tbView
    '    lblBudgetYear.Text = GlobalPPT.intLoginYear
    '    'GridOperatingCostViewbind()
    '    lblVersionNo.Visible = False
    '    lblVersionNoL.Visible = False
    '    lblStatus.Visible = False
    '    lblStatusL.Visible = False
    '    lblCOADescpView.Text = ""
    'End Sub
    'Private Sub btnSearchVHNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHNo.Click

    '    lblDriverName.Text = ""
    '    Dim frmVHNoLookup As New VHNoLookup
    '    Dim result As DialogResult = frmVHNoLookup.ShowDialog()
    '    If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
    '        strVHID = frmVHNoLookup.psVHID
    '        Me.txtVHNo.Text = frmVHNoLookup.psVHWSCode
    '        Me.lblVHDescp.Text = frmVHNoLookup.psVHDesc
    '        'psSIVVHCategoryID = frmVHNoLookup.psVHCategoryID
    '        '' psSIVVHType = frmVHNoLookup.psVHCategoryType
    '        If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
    '            If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
    '                strVHType = "V"
    '            End If
    '            If frmVHNoLookup.psVHCategoryType = "Workshop" Then
    '                strVHType = "W"
    '            End If
    '            If frmVHNoLookup.psVHCategoryType = "Others" Then
    '                strVHType = "O"
    '            End If
    '        End If
    '    End If

    '    'If strVHID <> "" Then
    '    '    Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '    '    oOperatingBudgetCostPPT.VHID = strVHID
    '    '    Dim ds As DataSet
    '    '    ds = OperatingBudgetCostBOL.OperatingBudgetByCostDriverFill(oOperatingBudgetCostPPT)
    '    '    lblDriverName.Text = ds.Tables(0).Rows(0).Item("EmpName")
    '    'Else
    '    '    Exit Sub
    '    'End If

    '    If strVHID <> "" Then
    '        Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '        oOperatingBudgetCostPPT.VHID = strVHID
    '        Dim ds As DataSet
    '        ds = OperatingBudgetCostBOL.OperatingBudgetByCostDriverFill(oOperatingBudgetCostPPT)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            lblDriverName.Text = ds.Tables(0).Rows(0).Item("EmpName")
    '            'End If
    '            'lblDriverName.Text = ds.Tables(0).Rows(0).Item("EmpName")
    '        Else
    '            Exit Sub
    '        End If
    '    End If
    'End Sub
    'Private Sub btnSearchVHcostCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHcostCode.Click
    '    Dim frmVHDetailsCostCodeLookup As New VHDetailsCostCodeLookup
    '    frmVHDetailsCostCodeLookup.BindGrid(strVHType)
    '    Dim result As DialogResult = frmVHDetailsCostCodeLookup.ShowDialog()
    '    If frmVHDetailsCostCodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.txtVHDetailCostCode.Text = frmVHDetailsCostCodeLookup.psVHDetailsCostCode
    '        strVHDetailCostCodeID = frmVHDetailsCostCodeLookup.psVHDetailsCostCodeID
    '        ''psSIVVHDetCostCodType = frmVHDetailsCostCodeLookup.psType
    '    End If
    'End Sub
    'Private Sub CalcBudgetTotal()
    '    lblBudgetTotal.Text = Math.Round(Val(txtBudgetJan.Text) + Val(txtBudgetFeb.Text) + Val(txtBudgetMar.Text) + Val(txtBudgetApr.Text) + Val(txtBudgetMay.Text) + Val(txtBudgetJun.Text) + Val(txtBudgetJul.Text) + Val(txtBudgetAug.Text) + Val(txtBudgetSep.Text) + Val(txtBudgetOct.Text) + Val(txtBudgetNov.Text) + Val(txtBudgetDec.Text), 0)

    'End Sub
    'Private Sub txtBudgetJan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetJan.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetFeb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetFeb.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetMar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetMar.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetApr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetApr.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetMay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetMay.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetjun_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetJun.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetJul_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetJul.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetAug_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetAug.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetSep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetSep.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetOct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetOct.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetNov_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetNov.LostFocus
    '    CalcBudgetTotal()
    'End Sub
    'Private Sub txtBudgetDec_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetDec.LostFocus
    '    CalcBudgetTotal()
    'End Sub

    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    Me.Close()
    'End Sub
    'Private Sub Clear()
    '    strVHDetailCostCodeID = String.Empty
    '    strVHID = String.Empty
    '    strCOAID = String.Empty
    '    txtVHDetailCostCode.Text = ""
    '    txtVHNo.Text = ""
    '    lblVHDescp.Text = ""
    '    txtSubDescp.Text = ""
    '    txtUnit.Text = ""
    '    txtQty.Text = ""
    '    txtDay.Text = ""
    '    txtMonth.Text = ""
    '    txtIDR.Text = ""
    '    txtPercentage.Text = ""
    '    txtVHGroup.Text = ""
    '    lblCOADescp.Text = ""


    '    txtBudgetJan.Text = ""
    '    txtBudgetFeb.Text = ""
    '    txtBudgetMar.Text = ""
    '    txtBudgetApr.Text = ""
    '    txtBudgetMay.Text = ""
    '    txtBudgetJun.Text = ""
    '    txtBudgetJul.Text = ""
    '    txtBudgetAug.Text = ""
    '    txtBudgetSep.Text = ""
    '    txtBudgetOct.Text = ""
    '    txtBudgetNov.Text = ""
    '    txtBudgetDec.Text = ""

    '    txtRevJan.Text = ""
    '    txtRevFeb.Text = ""
    '    txtRevMar.Text = ""
    '    txtRevApr.Text = ""
    '    txtRevMay.Text = ""
    '    txtRevJun.Text = ""
    '    txtRevJul.Text = ""
    '    txtRevAug.Text = ""
    '    txtRevSep.Text = ""
    '    txtRevOct.Text = ""
    '    txtRevNov.Text = ""
    '    txtRevDec.Text = ""
    '    lblStatus.Text = ""
    '    lblVersionNo.Text = ""
    '    lblBudgetTotal.Text = ""
    '    lblDriverName.Text = ""
    'End Sub
    'Private Sub btnResetGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetGeneral.Click
    '    Clear()

    '    grpOperatingCost.Enabled = True
    '    lblVersionNo.Visible = False
    '    lblVersionNoL.Visible = False
    '    lblStatus.Visible = False
    '    lblStatusL.Visible = False
    'End Sub

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    If AddFlag = True Then
    '        If isValidSaveAll() Then
    '            Add_Record()
    '            dgOperatingCost.AutoGenerateColumns = False
    '        Else
    '            Exit Sub
    '        End If
    '    ElseIf AddFlag = False Then
    '        If isValidSaveAll() Then
    '            Update_Record()
    '            dgOperatingCost.AutoGenerateColumns = False
    '        Else
    '            Exit Sub
    '        End If
    '    End If
    '    Clear()
    'End Sub

    'Private Function isValidSaveAll() As Boolean

    '    If (txtVHGroup.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in VHDetailCostCode ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtVHGroup.Focus()
    '        Return False
    '    End If
    '    If (txtVHNo.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in VHNo ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtVHNo.Focus()
    '        Return False
    '    End If
    '    If (txtVHDetailCostCode.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in VHDetailCostCode ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtVHDetailCostCode.Focus()
    '        Return False
    '    End If
    '    If (txtSubDescp.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in SubDescp ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtSubDescp.Focus()
    '        Return False
    '    End If
    '    If (txtUnit.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in Unit ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtUnit.Focus()
    '        Return False
    '    End If
    '    If (txtQty.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in Qty ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtQty.Focus()
    '        Return False
    '    End If

    '    If (txtIDR.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in IDR ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtIDR.Focus()
    '        Return False
    '    End If
    '    If (txtDay.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in Day ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtDay.Focus()
    '        Return False
    '    End If

    '    If (txtMonth.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in Month ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtMonth.Focus()
    '        Return False
    '    End If

    '    If (txtPercentage.Text.Trim() = String.Empty) Then
    '        MessageBox.Show(" Please Key in Percentage ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtPercentage.Focus()
    '        Return False
    '    End If
    '    Return True
    'End Function

    'Private Sub Add_Record()

    '    Dim intRowcount As Integer = dtOperatingCost.Rows.Count
    '    Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '    oOperatingBudgetCostPPT.VHNo = txtVHNo.Text.Trim

    '    Try
    '        If Not VHNoExist(oOperatingBudgetCostPPT.VHNo) Then
    '            rowOperatingCost = dtOperatingCost.NewRow()
    '            If intRowcount = 0 And AddFlag = True Then
    '                Try
    '                    columnOperatingCost = New DataColumn("OperatingBudgetByCostID", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetYear", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("VHID", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("VHDescp", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("VHDetailCostCodeID", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("COAID", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("COAGroup", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("SubDesc", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("VHNo", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("VHDetailCostCode", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("IDR", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("Percentage", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("Unit", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("Day", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("Qty", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("Month", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetJan", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetFeb", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetMar", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetApr", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetMay", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetJun", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetJul", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetAug", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetSep", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetOct", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetNov", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetDec", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevJan", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevFeb", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevMar", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevApr", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevMay", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevJun", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevJul", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevAug", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevSep", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevOct", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevNov", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("RevDec", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("BudgetTotal", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("VersionNo", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("Status", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)
    '                    columnOperatingCost = New DataColumn("EmpName", System.Type.[GetType]("System.String"))
    '                    dtOperatingCost.Columns.Add(columnOperatingCost)


    '                    rowOperatingCost("BudgetYear") = lblBudgetYear.Text.ToString()
    '                    rowOperatingCost("EmpName") = lblDriverName.Text.ToString()
    '                    rowOperatingCost("VHID") = strVHID.ToString()
    '                    rowOperatingCost("VHDescp") = lblVHDescp.Text.ToString()
    '                    rowOperatingCost("VHDetailCostCodeID") = strVHDetailCostCodeID.ToString()
    '                    rowOperatingCost("COAID") = strCOAID.ToString()
    '                    rowOperatingCost("COAGroup") = txtVHGroup.Text.ToString()
    '                    rowOperatingCost("COADescp") = lblCOADescp.Text.ToString()
    '                    rowOperatingCost("SubDesc") = txtSubDescp.Text.ToString()
    '                    rowOperatingCost("VHNo") = txtVHNo.Text.ToString()
    '                    rowOperatingCost("VHDetailCostCode") = txtVHDetailCostCode.Text.ToString()
    '                    rowOperatingCost("IDR") = txtIDR.Text.ToString()
    '                    rowOperatingCost("Percentage") = txtPercentage.Text.ToString()
    '                    rowOperatingCost("Unit") = txtUnit.Text.ToString()
    '                    rowOperatingCost("Day") = txtDay.Text.ToString()
    '                    rowOperatingCost("Qty") = txtQty.Text.ToString()
    '                    rowOperatingCost("Month") = txtMonth.Text.ToString()

    '                    rowOperatingCost("BudgetJan") = txtBudgetJan.Text.ToString()
    '                    rowOperatingCost("BudgetFeb") = txtBudgetFeb.Text.ToString()
    '                    rowOperatingCost("BudgetMar") = txtBudgetMar.Text.ToString()
    '                    rowOperatingCost("BudgetApr") = txtBudgetApr.Text.ToString()
    '                    rowOperatingCost("BudgetMay") = txtBudgetMay.Text.ToString()
    '                    rowOperatingCost("BudgetJun") = txtBudgetJun.Text.ToString()
    '                    rowOperatingCost("BudgetJul") = txtBudgetJul.Text.ToString()
    '                    rowOperatingCost("BudgetAug") = txtBudgetAug.Text.ToString()
    '                    rowOperatingCost("BudgetSep") = txtBudgetSep.Text.ToString()
    '                    rowOperatingCost("BudgetOct") = txtBudgetOct.Text.ToString()
    '                    rowOperatingCost("BudgetNov") = txtBudgetNov.Text.ToString()
    '                    rowOperatingCost("BudgetDec") = txtBudgetDec.Text.ToString()

    '                    rowOperatingCost("RevJan") = txtRevJan.Text.ToString()
    '                    rowOperatingCost("RevFeb") = txtRevFeb.Text.ToString()
    '                    rowOperatingCost("RevMar") = txtRevMar.Text.ToString()
    '                    rowOperatingCost("RevApr") = txtRevApr.Text.ToString()
    '                    rowOperatingCost("RevMay") = txtRevMay.Text.ToString()
    '                    rowOperatingCost("RevJun") = txtRevJun.Text.ToString()
    '                    rowOperatingCost("RevJul") = txtRevJul.Text.ToString()
    '                    rowOperatingCost("RevAug") = txtRevAug.Text.ToString()
    '                    rowOperatingCost("RevSep") = txtRevSep.Text.ToString()
    '                    rowOperatingCost("RevOct") = txtRevOct.Text.ToString()
    '                    rowOperatingCost("RevNov") = txtRevNov.Text.ToString()
    '                    rowOperatingCost("RevDec") = txtRevDec.Text.ToString()

    '                    rowOperatingCost("BudgetTotal") = lblBudgetTotal.Text.ToString()
    '                    rowOperatingCost("VersionNo") = lblVersionNo.Text.ToString()
    '                    rowOperatingCost("Status") = lblStatus.Text.ToString()
    '                    rowOperatingCost("OperatingBudgetByCostID") = strOperatingBudgetByCostID.ToString()

    '                    dtOperatingCost.Rows.InsertAt(rowOperatingCost, intRowcount)
    '                    dgOperatingCost.AutoGenerateColumns = False
    '                    AddFlag = True
    '                Catch ex As Exception
    '                    rowOperatingCost("OperatingBudgetByCostID") = strOperatingBudgetByCostID.ToString()
    '                    rowOperatingCost("BudgetYear") = lblBudgetYear.Text.ToString()
    '                    rowOperatingCost("EmpName") = lblDriverName.Text.ToString()
    '                    rowOperatingCost("VHID") = strVHID.ToString()
    '                    rowOperatingCost("VHDescp") = lblVHDescp.Text.ToString()
    '                    rowOperatingCost("VHDetailCostCodeID") = strVHDetailCostCodeID.ToString()
    '                    rowOperatingCost("COAID") = strCOAID.ToString()
    '                    rowOperatingCost("COAGroup") = txtVHGroup.Text.ToString()
    '                    rowOperatingCost("COADescp") = lblCOADescp.Text.ToString()
    '                    rowOperatingCost("SubDesc") = txtSubDescp.Text.ToString()
    '                    rowOperatingCost("VHNo") = txtVHNo.Text.ToString()
    '                    rowOperatingCost("VHDetailCostCode") = txtVHDetailCostCode.Text.ToString()
    '                    rowOperatingCost("IDR") = txtIDR.Text.ToString()
    '                    rowOperatingCost("Percentage") = txtPercentage.Text.ToString()
    '                    rowOperatingCost("Unit") = txtUnit.Text.ToString()
    '                    rowOperatingCost("Day") = txtDay.Text.ToString()
    '                    rowOperatingCost("Qty") = txtQty.Text.ToString()
    '                    rowOperatingCost("Month") = txtMonth.Text.ToString()

    '                    rowOperatingCost("BudgetJan") = txtBudgetJan.Text.ToString()
    '                    rowOperatingCost("BudgetFeb") = txtBudgetFeb.Text.ToString()
    '                    rowOperatingCost("BudgetMar") = txtBudgetMar.Text.ToString()
    '                    rowOperatingCost("BudgetApr") = txtBudgetApr.Text.ToString()
    '                    rowOperatingCost("BudgetMay") = txtBudgetMay.Text.ToString()
    '                    rowOperatingCost("BudgetJun") = txtBudgetJun.Text.ToString()
    '                    rowOperatingCost("BudgetJul") = txtBudgetJul.Text.ToString()
    '                    rowOperatingCost("BudgetAug") = txtBudgetAug.Text.ToString()
    '                    rowOperatingCost("BudgetSep") = txtBudgetSep.Text.ToString()
    '                    rowOperatingCost("BudgetOct") = txtBudgetOct.Text.ToString()
    '                    rowOperatingCost("BudgetNov") = txtBudgetNov.Text.ToString()
    '                    rowOperatingCost("BudgetDec") = txtBudgetDec.Text.ToString()

    '                    rowOperatingCost("RevJan") = txtRevJan.Text.ToString()
    '                    rowOperatingCost("RevFeb") = txtRevFeb.Text.ToString()
    '                    rowOperatingCost("RevMar") = txtRevMar.Text.ToString()
    '                    rowOperatingCost("RevApr") = txtRevApr.Text.ToString()
    '                    rowOperatingCost("RevMay") = txtRevMay.Text.ToString()
    '                    rowOperatingCost("RevJun") = txtRevJun.Text.ToString()
    '                    rowOperatingCost("RevJul") = txtRevJul.Text.ToString()
    '                    rowOperatingCost("RevAug") = txtRevAug.Text.ToString()
    '                    rowOperatingCost("RevSep") = txtRevSep.Text.ToString()
    '                    rowOperatingCost("RevOct") = txtRevOct.Text.ToString()
    '                    rowOperatingCost("RevNov") = txtRevNov.Text.ToString()
    '                    rowOperatingCost("RevDec") = txtRevDec.Text.ToString()

    '                    rowOperatingCost("BudgetTotal") = lblBudgetTotal.Text.ToString()
    '                    rowOperatingCost("VersionNo") = lblVersionNo.Text.ToString()
    '                    rowOperatingCost("Status") = lblStatus.Text.ToString()
    '                    rowOperatingCost("OperatingBudgetByCostID") = strOperatingBudgetByCostID.ToString()

    '                    dtOperatingCost.Rows.InsertAt(rowOperatingCost, intRowcount)
    '                    dgOperatingCost.AutoGenerateColumns = False
    '                    AddFlag = True
    '                End Try
    '            Else
    '                rowOperatingCost("OperatingBudgetByCostID") = strOperatingBudgetByCostID
    '                rowOperatingCost("BudgetYear") = lblBudgetYear.Text.ToString()
    '                rowOperatingCost("EmpName") = lblDriverName.Text.ToString()
    '                rowOperatingCost("VHID") = strVHID.ToString()
    '                rowOperatingCost("VHDescp") = lblVHDescp.Text.ToString()
    '                rowOperatingCost("VHDetailCostCodeID") = strVHDetailCostCodeID.ToString()
    '                rowOperatingCost("COAID") = strCOAID.ToString()
    '                rowOperatingCost("COAGroup") = txtVHGroup.Text.ToString()
    '                rowOperatingCost("COADescp") = lblCOADescp.Text.ToString()
    '                rowOperatingCost("SubDesc") = txtSubDescp.Text.ToString()
    '                rowOperatingCost("VHNo") = txtVHNo.Text.ToString()
    '                rowOperatingCost("VHDetailCostCode") = txtVHDetailCostCode.Text.ToString()
    '                rowOperatingCost("IDR") = txtIDR.Text.ToString()
    '                rowOperatingCost("Percentage") = txtPercentage.Text.ToString()
    '                rowOperatingCost("Unit") = txtUnit.Text.ToString()
    '                rowOperatingCost("Day") = txtDay.Text.ToString()
    '                rowOperatingCost("Qty") = txtQty.Text.ToString()
    '                rowOperatingCost("Month") = txtMonth.Text.ToString()

    '                rowOperatingCost("BudgetJan") = txtBudgetJan.Text.ToString()
    '                rowOperatingCost("BudgetFeb") = txtBudgetFeb.Text.ToString()
    '                rowOperatingCost("BudgetMar") = txtBudgetMar.Text.ToString()
    '                rowOperatingCost("BudgetApr") = txtBudgetApr.Text.ToString()
    '                rowOperatingCost("BudgetMay") = txtBudgetMay.Text.ToString()
    '                rowOperatingCost("BudgetJun") = txtBudgetJun.Text.ToString()
    '                rowOperatingCost("BudgetJul") = txtBudgetJul.Text.ToString()
    '                rowOperatingCost("BudgetAug") = txtBudgetAug.Text.ToString()
    '                rowOperatingCost("BudgetSep") = txtBudgetSep.Text.ToString()
    '                rowOperatingCost("BudgetOct") = txtBudgetOct.Text.ToString()
    '                rowOperatingCost("BudgetNov") = txtBudgetNov.Text.ToString()
    '                rowOperatingCost("BudgetDec") = txtBudgetDec.Text.ToString()

    '                rowOperatingCost("RevJan") = txtRevJan.Text.ToString()
    '                rowOperatingCost("RevFeb") = txtRevFeb.Text.ToString()
    '                rowOperatingCost("RevMar") = txtRevMar.Text.ToString()
    '                rowOperatingCost("RevApr") = txtRevApr.Text.ToString()
    '                rowOperatingCost("RevMay") = txtRevMay.Text.ToString()
    '                rowOperatingCost("RevJun") = txtRevJun.Text.ToString()
    '                rowOperatingCost("RevJul") = txtRevJul.Text.ToString()
    '                rowOperatingCost("RevAug") = txtRevAug.Text.ToString()
    '                rowOperatingCost("RevSep") = txtRevSep.Text.ToString()
    '                rowOperatingCost("RevOct") = txtRevOct.Text.ToString()
    '                rowOperatingCost("RevNov") = txtRevNov.Text.ToString()
    '                rowOperatingCost("RevDec") = txtRevDec.Text.ToString()

    '                rowOperatingCost("BudgetTotal") = lblBudgetTotal.Text.ToString()
    '                rowOperatingCost("VersionNo") = lblVersionNo.Text.ToString()
    '                rowOperatingCost("Status") = lblStatus.Text.ToString()
    '                rowOperatingCost("OperatingBudgetByCostID") = strOperatingBudgetByCostID.ToString()

    '                dtOperatingCost.Rows.InsertAt(rowOperatingCost, intRowcount)
    '                dgOperatingCost.AutoGenerateColumns = False
    '                AddFlag = True
    '            End If
    '            dgOperatingCost.AutoGenerateColumns = False
    '            dgOperatingCost.DataSource = dtOperatingCost
    '            btnAdd.Text = "Add"
    '        Else
    '            MsgBox("Sorry, the VHNo already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub Update_Record()
    '    Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT

    '    oOperatingBudgetCostPPT.VHNo = txtVHNo.Text.Trim
    '    If strVHNo = txtVHNo.Text.Trim Then
    '        Dim intcount As Integer = dgOperatingCost.CurrentRow.Index
    '        dgOperatingCost.Rows(intcount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("OperatingBudgetByCostID").Value = strOperatingBudgetByCostID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("EmpName").Value = lblDriverName.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHID").Value = strVHID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHDescp").Value = lblVHDescp.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("COAID").Value = strCOAID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("COAGroup").Value = txtVHGroup.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHDetailCostCodeID").Value = strVHDetailCostCodeID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("SubDesc").Value = txtSubDescp.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHNo").Value = txtVHNo.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHDetailCostCode").Value = txtVHDetailCostCode.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("IDR").Value = txtIDR.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Percentage").Value = txtPercentage.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Unit").Value = txtUnit.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Day").Value = txtDay.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Qty").Value = txtQty.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Month").Value = txtMonth.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

    '        dgOperatingCost.Rows(intcount).Cells("RevJan").Value = txtRevJan.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevMar").Value = txtRevMar.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevApr").Value = txtRevApr.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevMay").Value = txtRevMay.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevJun").Value = txtRevJun.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevJul").Value = txtRevJul.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevAug").Value = txtRevAug.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevSep").Value = txtRevSep.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevOct").Value = txtRevOct.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevNov").Value = txtRevNov.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevDec").Value = txtRevDec.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetTotal").Value = lblBudgetTotal.Text.ToString()

    '        btnAdd.Text = "Add"
    '        txtVHNo.Text = String.Empty
    '        'btnSaveAll.Text = "Update All"
    '        dgOperatingCost.AutoGenerateColumns = False
    '        AddFlag = False
    '    ElseIf Not VHNoExist(oOperatingBudgetCostPPT.VHNo) Then
    '        Dim intcount As Integer = dgOperatingCost.CurrentRow.Index
    '        dgOperatingCost.Rows(intcount).Cells("BudgetYear").Value = lblBudgetYear.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("OperatingBudgetByCostID").Value = strOperatingBudgetByCostID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("EmpName").Value = lblDriverName.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHID").Value = strVHID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHDescp").Value = lblVHDescp.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("COAID").Value = strCOAID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("COAGroup").Value = txtVHGroup.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHDetailCostCodeID").Value = strVHDetailCostCodeID.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("SubDesc").Value = txtSubDescp.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHNo").Value = txtVHNo.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("VHDetailCostCode").Value = txtVHDetailCostCode.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("IDR").Value = txtIDR.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Percentage").Value = txtPercentage.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Unit").Value = txtUnit.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Day").Value = txtDay.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Qty").Value = txtQty.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("Month").Value = txtMonth.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

    '        dgOperatingCost.Rows(intcount).Cells("RevJan").Value = txtRevJan.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevMar").Value = txtRevMar.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevApr").Value = txtRevApr.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevMay").Value = txtRevMay.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevJun").Value = txtRevJun.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevJul").Value = txtRevJul.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevAug").Value = txtRevAug.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevSep").Value = txtRevSep.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevOct").Value = txtRevOct.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevNov").Value = txtRevNov.Text.ToString()
    '        dgOperatingCost.Rows(intcount).Cells("RevDec").Value = txtRevDec.Text.ToString()

    '        btnAdd.Text = "Add"
    '        txtVHNo.Text = String.Empty
    '        'btnSaveAll.Text = "Update All"
    '        dgOperatingCost.AutoGenerateColumns = False
    '        AddFlag = False
    '    Else
    '        MsgBox("The VHNo already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
    '    End If
    '    'AddFlag = False
    '    If btnSaveAll.Text = "Save" Then
    '        AddFlag = True
    '    Else
    '        AddFlag = False
    '    End If
    'End Sub

    'Private Function VHNoExist(ByVal VHNo As String) As Boolean
    '    Try
    '        Dim objDataGridViewRow As New DataGridViewRow
    '        For Each objDataGridViewRow In dgOperatingCost.Rows
    '            If VHNo = objDataGridViewRow.Cells("VHNo").Value.ToString() Then
    '                txtVHNo.Text = String.Empty
    '                'txtRequestedQty.Text = string.empty 
    '                txtVHNo.Focus()
    '                Return True
    '            End If
    '        Next
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message())
    '    End Try
    'End Function
    'Private Sub dgOperatingCost_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOperatingCost.DoubleClick
    '    If btnSaveAll.Text = "Save" Then
    '        If dgOperatingCost.Rows.Count > 0 Then
    '            btnAdd.Text = "Update"

    '            strVHDetailCostCodeID = dgOperatingCost.SelectedRows(0).Cells("VHDetailCostCodeID").Value.ToString()
    '            strOperatingBudgetByCostID = dgOperatingCost.SelectedRows(0).Cells("OperatingBudgetByCostID").Value.ToString()
    '            lblDriverName.Text = dgOperatingCost.SelectedRows(0).Cells("EmpName").Value.ToString()
    '            strVHID = dgOperatingCost.SelectedRows(0).Cells("VHID").Value.ToString()
    '            txtVHNo.Text = dgOperatingCost.SelectedRows(0).Cells("VHNo").Value.ToString()
    '            strVHNo = dgOperatingCost.SelectedRows(0).Cells("VHNo").Value.ToString()
    '            strCOAID = dgOperatingCost.SelectedRows(0).Cells("COAID").Value.ToString()
    '            txtVHDetailCostCode.Text = dgOperatingCost.SelectedRows(0).Cells("VHDetailCostCode").Value.ToString()
    '            lblVHDescp.Text = dgOperatingCost.SelectedRows(0).Cells("VHDescp").Value.ToString()
    '            lblCOADescp.Text = dgOperatingCost.SelectedRows(0).Cells("COADescp").Value.ToString()

    '            txtVHGroup.Text = dgOperatingCost.SelectedRows(0).Cells("COAGroup").Value.ToString()
    '            txtSubDescp.Text = dgOperatingCost.SelectedRows(0).Cells("SubDesc").Value.ToString()
    '            txtUnit.Text = dgOperatingCost.SelectedRows(0).Cells("Unit").Value.ToString()
    '            txtQty.Text = dgOperatingCost.SelectedRows(0).Cells("Qty").Value.ToString()
    '            txtIDR.Text = dgOperatingCost.SelectedRows(0).Cells("IDR").Value.ToString()
    '            txtDay.Text = dgOperatingCost.SelectedRows(0).Cells("Day").Value.ToString()
    '            txtMonth.Text = dgOperatingCost.SelectedRows(0).Cells("Month").Value.ToString()
    '            txtPercentage.Text = dgOperatingCost.SelectedRows(0).Cells("Percentage").Value.ToString()

    '            txtBudgetJan.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetJan").Value.ToString()
    '            txtBudgetFeb.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetFeb").Value.ToString()
    '            txtBudgetMar.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetMar").Value.ToString()
    '            txtBudgetApr.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetApr").Value.ToString()
    '            txtBudgetMay.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetMay").Value.ToString()
    '            txtBudgetJun.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetJun").Value.ToString()
    '            txtBudgetJul.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetJul").Value.ToString()
    '            txtBudgetAug.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetAug").Value.ToString()
    '            txtBudgetSep.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetSep").Value.ToString()
    '            txtBudgetOct.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetOct").Value.ToString()
    '            txtBudgetNov.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetNov").Value.ToString()
    '            txtBudgetDec.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetDec").Value.ToString()

    '            txtRevJan.Text = dgOperatingCost.SelectedRows(0).Cells("RevJan").Value.ToString()
    '            txtRevFeb.Text = dgOperatingCost.SelectedRows(0).Cells("RevFeb").Value.ToString()
    '            txtRevMar.Text = dgOperatingCost.SelectedRows(0).Cells("RevMar").Value.ToString()
    '            txtRevApr.Text = dgOperatingCost.SelectedRows(0).Cells("RevApr").Value.ToString()
    '            txtRevMay.Text = dgOperatingCost.SelectedRows(0).Cells("RevMay").Value.ToString()
    '            txtRevJun.Text = dgOperatingCost.SelectedRows(0).Cells("RevJun").Value.ToString()
    '            txtRevJul.Text = dgOperatingCost.SelectedRows(0).Cells("RevJul").Value.ToString()
    '            txtRevAug.Text = dgOperatingCost.SelectedRows(0).Cells("RevAug").Value.ToString()
    '            txtRevSep.Text = dgOperatingCost.SelectedRows(0).Cells("RevSep").Value.ToString()
    '            txtRevOct.Text = dgOperatingCost.SelectedRows(0).Cells("RevOct").Value.ToString()
    '            txtRevNov.Text = dgOperatingCost.SelectedRows(0).Cells("RevNov").Value.ToString()
    '            txtRevDec.Text = dgOperatingCost.SelectedRows(0).Cells("RevDec").Value.ToString()

    '            lblBudgetTotal.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetTotal").Value.ToString()
    '            'lblVersionNo.Text = dgOperatingCost.SelectedRows(0).Cells("VersionNo").Value.ToString()
    '            'lblStatus.Text = dgOperatingCost.SelectedRows(0).Cells("Status").Value.ToString()
    '            AddFlag = False
    '        End If
    '    Else
    '        If dgOperatingCost.Rows.Count > 0 Then
    '            btnAdd.Text = "Update"

    '            strVHDetailCostCodeID = dgOperatingCost.SelectedRows(0).Cells("VHDetailCostCodeID").Value.ToString()
    '            strOperatingBudgetByCostID = dgOperatingCost.SelectedRows(0).Cells("OperatingBudgetByCostID").Value.ToString()
    '            lblDriverName.Text = dgOperatingCost.SelectedRows(0).Cells("EmpName").Value.ToString()
    '            strVHID = dgOperatingCost.SelectedRows(0).Cells("VHID").Value.ToString()
    '            txtVHNo.Text = dgOperatingCost.SelectedRows(0).Cells("VHNo").Value.ToString()
    '            strVHNo = dgOperatingCost.SelectedRows(0).Cells("VHNo").Value.ToString()
    '            strCOAID = dgOperatingCost.SelectedRows(0).Cells("COAID").Value.ToString()
    '            txtVHDetailCostCode.Text = dgOperatingCost.SelectedRows(0).Cells("VHDetailCostCode").Value.ToString()
    '            lblVHDescp.Text = dgOperatingCost.SelectedRows(0).Cells("VHDescp").Value.ToString()
    '            lblCOADescp.Text = dgOperatingCost.SelectedRows(0).Cells("COADescp").Value.ToString()

    '            txtVHGroup.Text = dgOperatingCost.SelectedRows(0).Cells("COAGroup").Value.ToString()
    '            txtSubDescp.Text = dgOperatingCost.SelectedRows(0).Cells("SubDesc").Value.ToString()
    '            txtUnit.Text = dgOperatingCost.SelectedRows(0).Cells("Unit").Value.ToString()
    '            txtQty.Text = dgOperatingCost.SelectedRows(0).Cells("Qty").Value.ToString()
    '            txtIDR.Text = dgOperatingCost.SelectedRows(0).Cells("IDR").Value.ToString()
    '            txtDay.Text = dgOperatingCost.SelectedRows(0).Cells("Day").Value.ToString()
    '            txtMonth.Text = dgOperatingCost.SelectedRows(0).Cells("Month").Value.ToString()
    '            txtPercentage.Text = dgOperatingCost.SelectedRows(0).Cells("Percentage").Value.ToString()

    '            txtBudgetJan.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetJan").Value.ToString()
    '            txtBudgetFeb.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetFeb").Value.ToString()
    '            txtBudgetMar.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetMar").Value.ToString()
    '            txtBudgetApr.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetApr").Value.ToString()
    '            txtBudgetMay.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetMay").Value.ToString()
    '            txtBudgetJun.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetJun").Value.ToString()
    '            txtBudgetJul.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetJul").Value.ToString()
    '            txtBudgetAug.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetAug").Value.ToString()
    '            txtBudgetSep.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetSep").Value.ToString()
    '            txtBudgetOct.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetOct").Value.ToString()
    '            txtBudgetNov.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetNov").Value.ToString()
    '            txtBudgetDec.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetDec").Value.ToString()

    '            txtRevJan.Text = dgOperatingCost.SelectedRows(0).Cells("RevJan").Value.ToString()
    '            txtRevFeb.Text = dgOperatingCost.SelectedRows(0).Cells("RevFeb").Value.ToString()
    '            txtRevMar.Text = dgOperatingCost.SelectedRows(0).Cells("RevMar").Value.ToString()
    '            txtRevApr.Text = dgOperatingCost.SelectedRows(0).Cells("RevApr").Value.ToString()
    '            txtRevMay.Text = dgOperatingCost.SelectedRows(0).Cells("RevMay").Value.ToString()
    '            txtRevJun.Text = dgOperatingCost.SelectedRows(0).Cells("RevJun").Value.ToString()
    '            txtRevJul.Text = dgOperatingCost.SelectedRows(0).Cells("RevJul").Value.ToString()
    '            txtRevAug.Text = dgOperatingCost.SelectedRows(0).Cells("RevAug").Value.ToString()
    '            txtRevSep.Text = dgOperatingCost.SelectedRows(0).Cells("RevSep").Value.ToString()
    '            txtRevOct.Text = dgOperatingCost.SelectedRows(0).Cells("RevOct").Value.ToString()
    '            txtRevNov.Text = dgOperatingCost.SelectedRows(0).Cells("RevNov").Value.ToString()
    '            txtRevDec.Text = dgOperatingCost.SelectedRows(0).Cells("RevDec").Value.ToString()

    '            lblBudgetTotal.Text = dgOperatingCost.SelectedRows(0).Cells("BudgetTotal").Value.ToString()
    '            lblVersionNo.Text = dgOperatingCost.SelectedRows(0).Cells("VersionNo").Value.ToString()
    '            lblStatus.Text = dgOperatingCost.SelectedRows(0).Cells("Status").Value.ToString()
    '            lblVersionNo.Visible = True
    '            lblVersionNoL.Visible = True
    '            lblStatus.Visible = True
    '            lblStatusL.Visible = True
    '            grpOperatingCost.Enabled = False

    '            AddFlag = False
    '        End If
    '    End If

    'End Sub

    'Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
    '    Clear()
    '    btnAdd.Text = "Add"
    '    btnSaveAll.Text = "Save"
    '    ClearGridView(dgOperatingCost)
    '    lblVersionNo.Visible = False
    '    lblVersionNoL.Visible = False
    '    lblStatus.Visible = False
    '    lblStatusL.Visible = False
    '    grpOperatingCost.Enabled = True
    'End Sub
    'Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
    '    If grdname.Rows.Count <> 0 Then
    '        Dim i As Integer = 0
    '        Dim J As Integer = 0
    '        Dim objDataGridViewRow As New DataGridViewRow
    '        For Each objDataGridViewRow In grdname.Rows

    '            grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
    '        Next
    '        i = grdname.Rows.Count
    '        For J = 0 To i - 1
    '            grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
    '        Next
    '    End If
    'End Sub
    'Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
    '    If AddFlag = True Then
    '        SaveFunction()
    '        Clear()
    '        btnAdd.Text = "Add"
    '        btnSaveAll.Text = "Save"
    '    ElseIf AddFlag = False Then
    '        UpdateFunction()
    '        Clear()
    '        btnAdd.Text = "Add"
    '        btnSaveAll.Text = "Save"
    '    End If
    '    AddFlag = True
    '    ClearGridView(dgOperatingCost)
    '    GridOperatingCostViewbind()
    '    tbOperatingBDGCost.SelectedTab = tbView
    'End Sub
    'Private Sub SaveFunction()
    '    Dim ds As New DataSet
    '    For Each DataGridView In dgOperatingCost.Rows
    '        Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '        oOperatingBudgetCostPPT.BudgetYear = DataGridView.Cells("BudgetYear").Value.ToString()
    '        oOperatingBudgetCostPPT.VHDetailCostCodeID = DataGridView.Cells("VHDetailCostCodeID").Value.ToString()
    '        oOperatingBudgetCostPPT.VHID = DataGridView.Cells("VHID").Value.ToString()
    '        oOperatingBudgetCostPPT.COAID = DataGridView.Cells("COAID").Value.ToString()
    '        oOperatingBudgetCostPPT.OperatingBudgetByCostID = DataGridView.Cells("OperatingBudgetByCostID").Value.ToString()
    '        oOperatingBudgetCostPPT.SubDesc = DataGridView.Cells("SubDesc").Value.ToString()
    '        oOperatingBudgetCostPPT.Unit = DataGridView.cells("unit").Value.ToString()
    '        oOperatingBudgetCostPPT.Qty = DataGridView.Cells("Qty").value.ToString()
    '        oOperatingBudgetCostPPT.IDR = DataGridView.Cells("IDR").Value.ToString()
    '        oOperatingBudgetCostPPT.Month = DataGridView.Cells("Month").Value.ToString()
    '        oOperatingBudgetCostPPT.Day = DataGridView.Cells("Day").Value.ToString()
    '        oOperatingBudgetCostPPT.Percentage = DataGridView.Cells("Percentage").Value.ToString()

    '        oOperatingBudgetCostPPT.BudgetJan = DataGridView.Cells("BudgetJan").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetFeb = DataGridView.Cells("BudgetFeb").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetMar = DataGridView.Cells("BudgetMar").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetApr = DataGridView.Cells("BudgetApr").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetMay = DataGridView.Cells("BudgetMay").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetJun = DataGridView.Cells("BudgetJun").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetJul = DataGridView.Cells("BudgetJul").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetAug = DataGridView.Cells("BudgetAug").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetSep = DataGridView.Cells("BudgetSep").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetOct = DataGridView.Cells("BudgetOct").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetNov = DataGridView.Cells("BudgetNov").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetDec = DataGridView.Cells("BudgetDec").Value.ToString()

    '        If DataGridView.Cells("RevJan").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevJan = DataGridView.Cells("RevJan").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevFeb").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevFeb = DataGridView.Cells("RevFeb").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevMar").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevMar = DataGridView.Cells("RevMar").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevApr").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevApr = DataGridView.Cells("RevApr").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevMay").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevMay = DataGridView.Cells("RevMay").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevJun").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevJun = DataGridView.Cells("RevJun").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevJul").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevJul = DataGridView.Cells("RevJul").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevAug").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevAug = DataGridView.Cells("RevAug").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevSep").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevSep = DataGridView.Cells("RevSep").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevOct").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevOct = DataGridView.Cells("RevOct").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevNov").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevNov = DataGridView.Cells("RevNov").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevDec").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevDec = DataGridView.Cells("RevDec").Value.ToString()
    '        End If
    '        If DataGridView.Cells("Status").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.Status = DataGridView.Cells("Status").Value.ToString()
    '        End If
    '        If DataGridView.Cells("VersionNo").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.VersionNo = DataGridView.Cells("VersionNo").Value.ToString()
    '        End If
    '        oOperatingBudgetCostPPT.BudgetTotal = DataGridView.Cells("BudgetTotal").Value.ToString()

    '        ds = OperatingBudgetCostBOL.OperatingBudgetByCostInsert(oOperatingBudgetCostPPT)
    '    Next
    '    If ds Is Nothing Then
    '        MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If
    '    grpOperatingCost.Enabled = True
    'End Sub
    'Private Sub UpdateFunction()
    '    Dim ds As New DataSet
    '    For Each DataGridView In dgOperatingCost.Rows
    '        Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '        oOperatingBudgetCostPPT.BudgetYear = DataGridView.Cells("BudgetYear").Value.ToString()
    '        oOperatingBudgetCostPPT.VHDetailCostCodeID = DataGridView.Cells("VHDetailCostCodeID").Value.ToString()
    '        oOperatingBudgetCostPPT.VHID = DataGridView.Cells("VHID").Value.ToString()
    '        oOperatingBudgetCostPPT.COAID = DataGridView.Cells("COAID").Value.ToString()
    '        oOperatingBudgetCostPPT.OperatingBudgetByCostID = DataGridView.Cells("OperatingBudgetByCostID").Value.ToString()
    '        oOperatingBudgetCostPPT.SubDesc = DataGridView.Cells("SubDesc").Value.ToString()
    '        oOperatingBudgetCostPPT.Unit = DataGridView.cells("unit").Value.ToString()
    '        oOperatingBudgetCostPPT.Qty = DataGridView.Cells("Qty").value.ToString()
    '        oOperatingBudgetCostPPT.IDR = DataGridView.Cells("IDR").Value.ToString()
    '        oOperatingBudgetCostPPT.Month = DataGridView.Cells("Month").Value.ToString()
    '        oOperatingBudgetCostPPT.Day = DataGridView.Cells("Day").Value.ToString()
    '        oOperatingBudgetCostPPT.Percentage = DataGridView.Cells("Percentage").Value.ToString()

    '        oOperatingBudgetCostPPT.BudgetJan = DataGridView.Cells("BudgetJan").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetFeb = DataGridView.Cells("BudgetFeb").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetMar = DataGridView.Cells("BudgetMar").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetApr = DataGridView.Cells("BudgetApr").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetMay = DataGridView.Cells("BudgetMay").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetJun = DataGridView.Cells("BudgetJun").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetJul = DataGridView.Cells("BudgetJul").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetAug = DataGridView.Cells("BudgetAug").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetSep = DataGridView.Cells("BudgetSep").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetOct = DataGridView.Cells("BudgetOct").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetNov = DataGridView.Cells("BudgetNov").Value.ToString()
    '        oOperatingBudgetCostPPT.BudgetDec = DataGridView.Cells("BudgetDec").Value.ToString()

    '        If DataGridView.Cells("RevJan").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevJan = DataGridView.Cells("RevJan").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevFeb").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevFeb = DataGridView.Cells("RevFeb").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevMar").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevMar = DataGridView.Cells("RevMar").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevApr").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevApr = DataGridView.Cells("RevApr").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevMay").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevMay = DataGridView.Cells("RevMay").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevJun").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevJun = DataGridView.Cells("RevJun").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevJul").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevJul = DataGridView.Cells("RevJul").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevAug").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevAug = DataGridView.Cells("RevAug").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevSep").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevSep = DataGridView.Cells("RevSep").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevOct").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevOct = DataGridView.Cells("RevOct").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevNov").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevNov = DataGridView.Cells("RevNov").Value.ToString()
    '        End If
    '        If DataGridView.Cells("RevDec").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.RevDec = DataGridView.Cells("RevDec").Value.ToString()
    '        End If

    '        oOperatingBudgetCostPPT.Status = DataGridView.Cells("Status").Value.ToString()
    '        If DataGridView.Cells("VersionNo").Value.ToString() <> "" Then
    '            oOperatingBudgetCostPPT.VersionNo = DataGridView.Cells("VersionNo").Value.ToString()
    '        End If
    '        oOperatingBudgetCostPPT.BudgetTotal = DataGridView.Cells("BudgetTotal").Value.ToString()
    '        oOperatingBudgetCostPPT.OperatingBudgetByCostID = DataGridView.Cells("OperatingBudgetByCostID").Value.ToString()
    '        ds = OperatingBudgetCostBOL.OperatingBudgetByCostUpdate(oOperatingBudgetCostPPT)
    '    Next
    '    If ds Is Nothing Then
    '        MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If
    '    btnAdd.Text = "Add"
    '    btnSaveAll.Text = "Save All"
    'End Sub

    'Private Sub btnSearchVHGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHGroup.Click
    '    'Dim frmVHGroupLookUp As New VHGroupLookUp
    '    'frmVHGroupLookUp.BindGrid()
    '    'Dim results As DialogResult = frmVHGroupLookUp.ShowDialog()
    '    'If frmVHGroupLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
    '    '    Me.txtVHGroup.Text = frmVHGroupLookUp.strCOAGroup
    '    '    strCOAID = frmVHGroupLookUp.strgCOAID
    '    '    lblCOADescp.Text = frmVHGroupLookUp.strCOADescp
    '    'End If
    '    Cursor = Cursors.WaitCursor
    '    Dim frmAcctcodeLookup As New COALookup
    '    frmAcctcodeLookup.ShowDialog()
    '    If frmAcctcodeLookup.strAcctId <> String.Empty Then
    '        Me.txtVHGroup.Text = frmAcctcodeLookup.strAcctcode
    '        strCOAID = frmAcctcodeLookup.strAcctId
    '        lblCOADescp.Text = frmAcctcodeLookup.strAcctDescp
    '        'lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
    '    End If
    '    Cursor = Cursors.Arrow

    'End Sub

    'Private Sub GridOperatingCostViewbind()
    '    Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '    Dim dt As New DataTable
    '    dt = OperatingBudgetCostBOL.OperatingBudgetByCostSelect()
    '    If dt.Rows.Count <> 0 Then
    '        dgOperatingCostView.DataSource = dt
    '        dgOperatingCostView.AutoGenerateColumns = False
    '    End If
    'End Sub
    'Private Sub dgOperatingCostView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOperatingCostView.DoubleClick
    '    dgOperatingCostViewEdit()
    '    tbOperatingBDGCost.SelectedTab = tbOperatingCost
    'End Sub
    'Private Sub dgOperatingCostViewEdit()

    '    Dim ds As New DataSet
    '    If dgOperatingCostView.RowCount > 0 Then
    '        strCOAID = dgOperatingCostView.SelectedRows(0).Cells("COAIDView").Value.ToString()
    '        strVHDetailCostCodeID = dgOperatingCostView.SelectedRows(0).Cells("VHDetailCostCodeIDView").Value.ToString()
    '        strVHID = dgOperatingCostView.SelectedRows(0).Cells("VHIDView").Value.ToString()
    '        strOperatingBudgetByCostID = dgOperatingCostView.SelectedRows(0).Cells("OperatingBudgetByCostIDView").Value.ToString()
    '        txtVHDetailCostCode.Text = dgOperatingCostView.SelectedRows(0).Cells("VHDetailCostCodeView").Value.ToString()
    '        txtVHGroup.Text = dgOperatingCostView.SelectedRows(0).Cells("COAGroupView").Value.ToString()
    '        lblVHDescp.Text = dgOperatingCostView.SelectedRows(0).Cells("VHDescpView").Value.ToString()
    '        txtVHNo.Text = dgOperatingCostView.SelectedRows(0).Cells("VHNoView").Value.ToString()
    '        lblDriverName.Text = dgOperatingCostView.SelectedRows(0).Cells("EmpNameView").Value.ToString()
    '        lblCOADescp.Text = dgOperatingCostView.SelectedRows(0).Cells("COADescpView").Value.ToString()
    '        txtSubDescp.Text = dgOperatingCostView.SelectedRows(0).Cells("SubDescView").Value.ToString()
    '        txtUnit.Text = dgOperatingCostView.SelectedRows(0).Cells("UnitView").Value.ToString()
    '        txtQty.Text = dgOperatingCostView.SelectedRows(0).Cells("QTYView").Value.ToString()
    '        txtIDR.Text = dgOperatingCostView.SelectedRows(0).Cells("IDRView").Value.ToString()
    '        txtDay.Text = dgOperatingCostView.SelectedRows(0).Cells("DayView").Value.ToString()
    '        txtMonth.Text = dgOperatingCostView.SelectedRows(0).Cells("MonthView").Value.ToString()
    '        txtPercentage.Text = dgOperatingCostView.SelectedRows(0).Cells("PercentageView").Value.ToString()

    '        txtBudgetJan.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetJanView").Value.ToString()
    '        txtBudgetFeb.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetFebView").Value.ToString()
    '        txtBudgetMar.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetMarView").Value.ToString()
    '        txtBudgetApr.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetAprView").Value.ToString()
    '        txtBudgetMay.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetMayView").Value.ToString()
    '        txtBudgetJun.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetJunView").Value.ToString()
    '        txtBudgetJul.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetJulView").Value.ToString()
    '        txtBudgetAug.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetAugView").Value.ToString()
    '        txtBudgetSep.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetSepView").Value.ToString()
    '        txtBudgetOct.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetOctView").Value.ToString()
    '        txtBudgetNov.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetNovView").Value.ToString()
    '        txtBudgetDec.Text = dgOperatingCostView.SelectedRows(0).Cells("BudgetDecView").Value.ToString()

    '        txtRevJan.Text = dgOperatingCostView.SelectedRows(0).Cells("RevJanView").Value.ToString()
    '        txtRevFeb.Text = dgOperatingCostView.SelectedRows(0).Cells("RevFebView").Value.ToString()
    '        txtRevMar.Text = dgOperatingCostView.SelectedRows(0).Cells("RevMarView").Value.ToString()
    '        txtRevApr.Text = dgOperatingCostView.SelectedRows(0).Cells("RevAprView").Value.ToString()
    '        txtRevMay.Text = dgOperatingCostView.SelectedRows(0).Cells("RevMayView").Value.ToString()
    '        txtRevJun.Text = dgOperatingCostView.SelectedRows(0).Cells("RevJunView").Value.ToString()
    '        txtRevJul.Text = dgOperatingCostView.SelectedRows(0).Cells("RevJulView").Value.ToString()
    '        txtRevAug.Text = dgOperatingCostView.SelectedRows(0).Cells("RevAugView").Value.ToString()
    '        txtRevSep.Text = dgOperatingCostView.SelectedRows(0).Cells("RevSepView").Value.ToString()
    '        txtRevOct.Text = dgOperatingCostView.SelectedRows(0).Cells("RevOctView").Value.ToString()
    '        txtRevNov.Text = dgOperatingCostView.SelectedRows(0).Cells("RevNovView").Value.ToString()
    '        txtRevDec.Text = dgOperatingCostView.SelectedRows(0).Cells("RevDecView").Value.ToString()

    '        lblVersionNo.Text = dgOperatingCostView.SelectedRows(0).Cells("VersionNoView").Value.ToString()
    '        lblStatus.Text = dgOperatingCostView.SelectedRows(0).Cells("StatusView").Value.ToString()
    '    End If
    '    btnAdd.Text = "Update"
    '    btnSaveAll.Text = "Update All"
    '    AddFlag = False
    '    BinddgOperatingCostDataGrid()
    '    Clear()
    '    grpOperatingCost.Enabled = False
    'End Sub
    'Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
    '    Clear()
    '    btnAdd.Text = "Add"
    '    btnSaveAll.Text = "Save All"
    '    tbOperatingBDGCost.SelectedTab = tbOperatingCost
    'End Sub
    'Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
    '    dgOperatingCostViewEdit()
    '    tbOperatingBDGCost.SelectedTab = tbOperatingCost
    'End Sub
    'Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
    '    Delete()
    '    GridOperatingCostViewbind()
    '    tbOperatingBDGCost.SelectedTab = tbView
    'End Sub
    'Private Sub Delete()
    '    Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '    Dim oOperatingBudgetCostBOL As New OperatingBudgetCostBOL
    '    If dgOperatingCostView.Rows.Count > 0 Then
    '        If Me.btnSaveAll.Text = "Update All" Then
    '            MessageBox.Show("Record in edit mode, please update first", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If

    '        If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            oOperatingBudgetCostPPT.OperatingBudgetByCostID = dgOperatingCostView.SelectedRows(0).Cells("OperatingBudgetByCostIDView").Value.ToString

    '            OperatingBudgetCostBOL.OperatingBudgetByCostDelete(oOperatingBudgetCostPPT)
    '            GridOperatingCostViewbind()
    '            MessageBox.Show("Record deleted successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    End If
    'End Sub

    'Private Sub btnSearchVHGroupView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHGroupView.Click
    '    'Dim frmVHGroupLookUp As New VHGroupLookUp
    '    'frmVHGroupLookUp.BindGrid()
    '    'Dim results As DialogResult = frmVHGroupLookUp.ShowDialog()
    '    'If frmVHGroupLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
    '    '    Me.txtCOAGroupView.Text = frmVHGroupLookUp.strCOAGroup
    '    '    strCOAID = frmVHGroupLookUp.strgCOAID
    '    '    lblCOADescpView.Text = frmVHGroupLookUp.strCOADescp
    '    'End If
    'End Sub
    'Private Sub btnSearchVHNoView_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHNoView.Click
    '    Dim frmVHNoLookup As New VHNoLookup
    '    Dim result As DialogResult = frmVHNoLookup.ShowDialog()
    '    If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
    '        strVHID = frmVHNoLookup.psVHID
    '        Me.txtVHNoView.Text = frmVHNoLookup.psVHWSCode
    '        Me.lblVHDescpView.Text = frmVHNoLookup.psVHDesc
    '        'psSIVVHCategoryID = frmVHNoLookup.psVHCategoryID
    '        '' psSIVVHType = frmVHNoLookup.psVHCategoryType
    '        If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
    '            If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
    '                strVHType = "V"
    '            End If
    '            If frmVHNoLookup.psVHCategoryType = "Workshop" Then
    '                strVHType = "W"
    '            End If
    '            If frmVHNoLookup.psVHCategoryType = "Others" Then
    '                strVHType = "O"
    '            End If
    '        End If
    '    End If
    'End Sub
    'Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    '    Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT

    '    oOperatingBudgetCostPPT.COACode = txtCOAGroupView.Text.Trim
    '    oOperatingBudgetCostPPT.VHNo = txtVHNoView.Text.Trim

    '    Dim ds As New DataSet
    '    ds = OperatingBudgetCostBOL.OperatingCostViewSearch(oOperatingBudgetCostPPT)
    '    If ds.Tables(0).Rows.Count <> 0 Then
    '        lblNoRecord.Visible = False
    '        dgOperatingCostView.AutoGenerateColumns = False
    '        dgOperatingCostView.DataSource = ds.Tables(0)
    '        dgOperatingCostView.Visible = True
    '    Else
    '        MessageBox.Show("No Record Found!,Please Select Search criteria", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        GridOperatingCostViewbind()
    '    End If
    '    'txtVHNoView.Text = ""
    '    'txtCOAGroupView.Text = ""
    '    'lblVHDescpView.Text = ""
    '    'lblCOADescpView.Text = ""
    'End Sub

    'Private Sub BinddgOperatingCostDataGrid()
    '    Try
    '        Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '        Dim oOperatingBudgetCostBOL As New OperatingBudgetCostBOL

    '        With oOperatingBudgetCostPPT
    '            .VHNo = Me.txtVHNo.Text
    '        End With

    '        dtOperatingCost = OperatingBudgetCostBOL.OperatingBudgetByCostSelect_MultipleEntry(oOperatingBudgetCostPPT)
    '        If dtOperatingCost.Rows.Count <> 0 Then

    '            'dtOperatingCost.AutoGenerateColumns = False
    '            Me.dgOperatingCost.DataSource = dtOperatingCost
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    'Private Sub tbOperatingBDGCost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbOperatingBDGCost.Click
    '    Clear()
    '    ClearGridView(dgOperatingCost)
    '    grpOperatingCost.Enabled = True
    '    lblVersionNo.Visible = False
    '    lblVersionNoL.Visible = False
    '    lblStatus.Visible = False
    '    lblStatusL.Visible = False
    '    btnAdd.Text = "Add"
    '    btnSaveAll.Text = "Save"
    'End Sub
    'Private Sub txtVHGroup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVHGroup.Leave
    '    If txtVHGroup.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
    '        oOperatingBudgetCostPPT.COACode = txtVHGroup.Text.Trim()
    '        Dim oOperatingBudgetCostBOL As New OperatingBudgetCostBOL
    '        ds = OperatingBudgetCostBOL.AcctlookupSearch(oOperatingBudgetCostPPT, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("Invalid Account code,Please Choose it from look up")
    '            txtVHGroup.Text = String.Empty
    '            lblCOADescp.Text = String.Empty
    '            'lblOldCOACode.Text = String.Empty
    '            strCOAID = String.Empty
    '            txtVHGroup.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
    '                txtVHGroup.Text = ds.Tables(0).Rows(0).Item("COACode")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
    '                lblCOADescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("COAID").ToString() <> String.Empty Then
    '                strCOAID = ds.Tables(0).Rows(0).Item("COAID")
    '            End If
    '            'If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
    '            '    lblOldCOACode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
    '            'End If
    '        End If
    '        'BudgetTotalGET()
    '        'ActualAmountGET()
    '    Else
    '        txtVHGroup.Text = String.Empty
    '        lblCOADescp.Text = String.Empty
    '        'lblOldCOACode.Text = String.Empty
    '        strCOAID = String.Empty
    '    End If
    'End Sub
    ''Private Sub txtVHNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVHNo.Leave

    ''    If txtVHNo.Text.Trim() <> String.Empty Then
    ''        Dim ds As New DataSet
    ''        Dim objSIV As New 
    ''        objSIV.VHWSCode = txtVHNo.Text.Trim()
    ''        ds = StoreIssueVoucherBOL.GetVHNo(objSIV, "YES")
    ''        If ds.Tables.Count > 0 Then
    ''            If ds.Tables(0).Rows.Count = 0 Then
    ''                MessageBox.Show("Invalid VHNo,Please Choose it from look up")
    ''                txtVHNo.Text = String.Empty
    ''                lblVHDescp.Text = String.Empty
    ''                psSIVVHID = String.Empty
    ''                psSIVVHCategoryID = String.Empty
    ''                psSIVVHType = String.Empty
    ''                txtVHNo.Focus()
    ''                Exit Sub
    ''            Else
    ''                If ds.Tables(0).Rows(0).Item("VHNo").ToString() <> String.Empty Then
    ''                    txtVHNo.Text = ds.Tables(0).Rows(0).Item("VHNo").ToString()
    ''                End If
    ''                If ds.Tables(0).Rows(0).Item("VHDescp").ToString() <> String.Empty Then
    ''                    lblVHDescp.Text = ds.Tables(0).Rows(0).Item("VHDescp").ToString()
    ''                End If
    ''                psSIVVHID = ds.Tables(0).Rows(0).Item("VHID").ToString()
    ''                If ds.Tables(0).Rows(0).Item("VHCategoryID").ToString() <> String.Empty Then
    ''                    psSIVVHCategoryID = ds.Tables(0).Rows(0).Item("VHCategoryID").ToString()
    ''                End If
    ''                If Not ds.Tables(0).Rows(0).Item("Type") Is DBNull.Value Then
    ''                    'psSIVVHType = ds.Tables(0).Rows(0).Item("Type").ToString()
    ''                    If ds.Tables(0).Rows(0).Item("Type").ToString() = "Vehicle" Then
    ''                        psSIVVHType = "V"
    ''                    End If
    ''                    If ds.Tables(0).Rows(0).Item("Type").ToString() = "Workshop" Then
    ''                        psSIVVHType = "W"
    ''                    End If
    ''                    If ds.Tables(0).Rows(0).Item("Type").ToString() = "Others" Then
    ''                        psSIVVHType = "O"
    ''                    End If
    ''                End If
    ''            End If
    ''        End If
    ''    Else
    ''        txtVHNo.Text = String.Empty
    ''        lblVHDescp.Text = String.Empty
    ''        psSIVVHID = String.Empty
    ''        psSIVVHCategoryID = String.Empty
    ''        psSIVVHType = String.Empty
    ''    End If

    ''End Sub

    'Private Sub MyTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay.KeyDown, txtIDR.KeyDown, txtMonth.KeyDown, txtPercentage.KeyDown, txtQty.KeyDown, txtUnit.KeyDown, txtBudgetJan.KeyDown, txtBudgetFeb.KeyDown, txtBudgetMar.KeyDown, txtBudgetApr.KeyDown, txtBudgetMay.KeyDown, txtBudgetJun.KeyDown, txtBudgetJul.KeyDown, txtBudgetAug.KeyDown, txtBudgetSep.KeyDown, txtBudgetOct.KeyDown, txtBudgetNov.KeyDown, txtBudgetDec.KeyDown, txtRevJan.KeyDown, txtRevFeb.KeyDown, txtRevMar.KeyDown, txtRevApr.KeyDown, txtRevMay.KeyDown, txtRevJun.KeyDown, txtRevJul.KeyDown, txtRevAug.KeyDown, txtRevSep.KeyDown, txtRevOct.KeyDown, txtRevNov.KeyDown, txtRevDec.KeyDown
    '    If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
    '        Return
    '    End If

    '    If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

    '        Dim txtBox As TextBox = DirectCast(sender, TextBox)
    '        Dim text As String = String.Empty


    '        If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
    '            Select Case e.KeyCode
    '                'Case Keys.OemPeriod
    '                '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

    '                Case Keys.[Decimal], Keys.OemPeriod
    '                    'digit from keypad? --> Keys.[Decimal]
    '                    'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

    '                    If txtBox.Text.Trim.Contains(".") Then
    '                        isDecimal = False
    '                        Return
    '                    End If

    '                    isDecimal = True
    '                    Return
    '                Case Else

    '                    If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
    '                        'digit from top of keyboard?
    '                        'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
    '                        'If we insert a number between two numbers
    '                        text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
    '                    End If

    '                    If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
    '                        'digit from keypad?
    '                        'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
    '                        'If we insert a number between two numbers
    '                        text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
    '                    End If

    '                    isDecimal = reDecimalPlaces.IsMatch(text)

    '            End Select
    '        Else
    '            isDecimal = False
    '            Return
    '        End If

    '    Else
    '        isDecimal = True
    '    End If
    'End Sub
    'Private Sub MyTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDay.KeyPress, txtIDR.KeyPress, txtMonth.KeyPress, txtPercentage.KeyPress, txtQty.KeyPress, txtUnit.KeyPress, txtBudgetJan.KeyPress, txtBudgetFeb.KeyPress, txtBudgetMar.KeyPress, txtBudgetApr.KeyPress, txtBudgetMay.KeyPress, txtBudgetJun.KeyPress, txtBudgetJul.KeyPress, txtBudgetAug.KeyPress, txtBudgetSep.KeyPress, txtBudgetOct.KeyPress, txtBudgetNov.KeyPress, txtBudgetDec.KeyPress, txtRevJan.KeyPress, txtRevFeb.KeyPress, txtRevMar.KeyPress, txtRevApr.KeyPress, txtRevMay.KeyPress, txtRevJun.KeyPress, txtRevJul.KeyPress, txtRevAug.KeyPress, txtRevSep.KeyPress, txtRevOct.KeyPress, txtRevNov.KeyPress, txtRevDec.KeyPress
    '    'if the decimal digits reaches more than 2 digits then stop entering
    '    If isDecimal = False Then
    '        ' Stop the character from being entered into the control since it is non-numerical.
    '        e.Handled = True
    '    Else
    '        e.Handled = False

    '    End If
    'End Sub
End Class
