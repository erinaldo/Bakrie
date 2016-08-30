Imports Common_BOL
Imports Common_PPT
Imports Budget_BOL
Imports Budget_PPT
Public Class OperatingBudgetHourFrm
    Public strOperatingBudgetByHoursID As String = String.Empty
    Public strCOAID As String = String.Empty
    Public strVHID As String = String.Empty
    Public strVHType As String = String.Empty
    Public strVHNo As String = String.Empty

    Private AddFlag As Boolean = True

    Dim dtOperatingHour As New DataTable("dgOperatingCost")
    Dim columnOperatingHour As DataColumn
    Dim rowOperatingHour As DataRow
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")


    Private Sub OperatingBudgetHourFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub OperatingBudgetByHour_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblBudgetYear.Text = GlobalPPT.intLoginYear
        tbOperatingBudgetByHour.SelectedTab = tbView

        lblVersionNo.Visible = False
        lblVersionNoL.Visible = False
        lblStatus.Visible = False
        lblStatusL.Visible = False
        'GridOperatingHourViewbind()

    End Sub
    Private Sub btnSearchVHNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHNo.Click

        lblDriverName.Text = ""
        Dim frmVHNoLookup As New VHNoLookup
        Dim result As DialogResult = frmVHNoLookup.ShowDialog()
        If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            strVHID = frmVHNoLookup.psVHID
            Me.txtVHNo.Text = frmVHNoLookup.psVHWSCode
            Me.lblVHDescp.Text = frmVHNoLookup.psVHDesc
            'psSIVVHCategoryID = frmVHNoLookup.psVHCategoryID
            '' psSIVVHType = frmVHNoLookup.psVHCategoryType
            If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
                If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
                    strVHType = "V"
                End If
                If frmVHNoLookup.psVHCategoryType = "Workshop" Then
                    strVHType = "W"
                End If
                If frmVHNoLookup.psVHCategoryType = "Others" Then
                    strVHType = "O"
                End If
            End If
        End If
        If strVHID <> "" Then
            Dim oOperatingBudgetCostPPT As New OperatingBudgetCostPPT
            oOperatingBudgetCostPPT.VHID = strVHID
            Dim ds As DataSet
            ds = OperatingBudgetCostBOL.OperatingBudgetByCostDriverFill(oOperatingBudgetCostPPT)
            If ds.Tables(0).Rows.Count > 0 Then
                lblDriverName.Text = ds.Tables(0).Rows(0).Item("EmpName")
                'End If
                'lblDriverName.Text = ds.Tables(0).Rows(0).Item("EmpName")
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnSearchVHGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHGroup.Click
        'Dim frmVHGroupLookUp As New VHGroupLookUp
        'frmVHGroupLookUp.BindGrid()
        'Dim results As DialogResult = frmVHGroupLookUp.ShowDialog()
        'If frmVHGroupLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
        '    Me.txtVHGroup.Text = frmVHGroupLookUp.strCOAGroup
        '    strCOAID = frmVHGroupLookUp.strgCOAID
        '    lblCOADescp.Text = frmVHGroupLookUp.strCOADescp

        Cursor = Cursors.WaitCursor
        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtVHGroup.Text = frmAcctcodeLookup.strAcctcode
            strCOAID = frmAcctcodeLookup.strAcctId
            lblCOADescp.Text = frmAcctcodeLookup.strAcctDescp
            'lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
        End If
        Cursor = Cursors.Arrow


        'End If
    End Sub

    Private Sub lblDistribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDistribute.Click
        Dim numval As Double

        If Val(txtNoOfHours.Text) <> 0 Then
            numval = Math.Round((Val(txtNoOfHours.Text) / 12), 0)
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
    Private Sub txtBudgetDec_KeyUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBudgetDec.KeyUp
        CalcBudgetTotal()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If AddFlag = True Then
            If IsValidFunction() Then
                Add_record()
                dgOperatingHours.AutoGenerateColumns = False
            Else
                Exit Sub
            End If
        ElseIf AddFlag = False Then
            If IsValidFunction() Then
                Update_record()
                dgOperatingHours.AutoGenerateColumns = False
            Else
                Exit Sub
            End If
        End If
        Clear()
       
    End Sub
    Public Function IsValidFunction()
        If (txtVHNo.Text.Trim() = String.Empty) Then
            MessageBox.Show("Please key in VHNo", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVHNo.Focus()
            Return False
        End If
        If (txtVHGroup.Text.Trim() = String.Empty) Then
            MessageBox.Show("Please key in VHGroup", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVHGroup.Focus()
            Return False
        End If
        If (txtNoOfHours.Text.Trim() = String.Empty) Then
            MessageBox.Show("Please key in No Of Hours", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfHours.Focus()
            Return False
        End If
        If Val(lblBudgetTotal.Text) <> Val(txtNoOfHours.Text) Then
            MessageBox.Show("Distriduted Value is not equal", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBudgetDec.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub Add_record()
        Dim intRowCount As Integer = dtOperatingHour.Rows.Count
        Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
        oOperatingBudgetHourPPT.VHNO = txtVHNo.Text.Trim
        Try
            If Not VHNoExist(oOperatingBudgetHourPPT.VHNO) Then
                rowOperatingHour = dtOperatingHour.NewRow()
                If intRowCount = 0 And AddFlag = True Then
                    Try
                        columnOperatingHour = New DataColumn("BudgetYear", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("VHID", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("VHNo", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("VHDescp", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("COAGroup", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("EmpName", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("NoOfHours", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)

                        columnOperatingHour = New DataColumn("BudgetJan", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetFeb", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetMar", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetApr", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetMay", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetJun", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetJul", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetAug", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetSep", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetOct", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetNov", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BudgetDec", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)

                        columnOperatingHour = New DataColumn("RevJan", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevFeb", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevMar", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevApr", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevMay", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevJun", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevJul", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevAug", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        'MessageBox.Show(9)
                        columnOperatingHour = New DataColumn("RevSep", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevOct", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevNov", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("RevDec", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("BalanceTotal", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("VersionNo", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("Status", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)
                        columnOperatingHour = New DataColumn("OperatingBudgetByHoursID", System.Type.[GetType]("System.String"))
                        dtOperatingHour.Columns.Add(columnOperatingHour)

                        rowOperatingHour("BudgetYear") = lblBudgetYear.Text.ToString()
                        rowOperatingHour("EmpName") = lblDriverName.Text.ToString()
                        rowOperatingHour("VHID") = strVHID.ToString()
                        rowOperatingHour("VHDescp") = lblVHDescp.Text.ToString()
                        rowOperatingHour("COAID") = strCOAID.ToString()
                        rowOperatingHour("COAGroup") = txtVHGroup.Text.ToString()
                        rowOperatingHour("COADescp") = lblCOADescp.Text.ToString()
                        rowOperatingHour("VHNo") = txtVHNo.Text.ToString()
                        rowOperatingHour("NoOfHours") = txtNoOfHours.Text.ToString()

                        rowOperatingHour("BudgetJan") = txtBudgetJan.Text.ToString()
                        rowOperatingHour("BudgetFeb") = txtBudgetFeb.Text.ToString()
                        rowOperatingHour("BudgetMar") = txtBudgetMar.Text.ToString()
                        rowOperatingHour("BudgetApr") = txtBudgetApr.Text.ToString()
                        rowOperatingHour("BudgetMay") = txtBudgetMay.Text.ToString()
                        rowOperatingHour("BudgetJun") = txtBudgetJun.Text.ToString()
                        rowOperatingHour("BudgetJul") = txtBudgetJul.Text.ToString()
                        rowOperatingHour("BudgetAug") = txtBudgetAug.Text.ToString()
                        rowOperatingHour("BudgetSep") = txtBudgetSep.Text.ToString()
                        rowOperatingHour("BudgetOct") = txtBudgetOct.Text.ToString()
                        rowOperatingHour("BudgetNov") = txtBudgetNov.Text.ToString()
                        rowOperatingHour("BudgetDec") = txtBudgetDec.Text.ToString()

                        rowOperatingHour("RevJan") = txtRevJan.Text.ToString()
                        rowOperatingHour("RevFeb") = txtRevFeb.Text.ToString()
                        rowOperatingHour("RevMar") = txtRevMar.Text.ToString()
                        rowOperatingHour("RevApr") = txtRevApr.Text.ToString()
                        rowOperatingHour("RevMay") = txtRevMay.Text.ToString()
                        rowOperatingHour("RevJun") = txtRevJun.Text.ToString()
                        rowOperatingHour("RevJul") = txtRevJul.Text.ToString()
                        rowOperatingHour("RevAug") = txtRevAug.Text.ToString()
                        rowOperatingHour("RevSep") = txtRevSep.Text.ToString()
                        rowOperatingHour("RevOct") = txtRevOct.Text.ToString()
                        rowOperatingHour("RevNov") = txtRevNov.Text.ToString()
                        rowOperatingHour("RevDec") = txtRevDec.Text.ToString()

                        rowOperatingHour("BalanceTotal") = lblBudgetTotal.Text.ToString()
                        rowOperatingHour("VersionNo") = lblVersionNo.Text.ToString()
                        rowOperatingHour("Status") = lblStatus.Text.ToString()
                        rowOperatingHour("OperatingBudgetByHoursID") = strOperatingBudgetByHoursID.ToString()

                        dtOperatingHour.Rows.InsertAt(rowOperatingHour, intRowCount)
                        dgOperatingHours.AutoGenerateColumns = False
                        AddFlag = True

                    Catch ex As Exception
                        rowOperatingHour("BudgetYear") = lblBudgetYear.Text.ToString()
                        rowOperatingHour("EmpName") = lblDriverName.Text.ToString()
                        rowOperatingHour("VHID") = strVHID.ToString()
                        rowOperatingHour("VHDescp") = lblVHDescp.Text.ToString()
                        rowOperatingHour("COAID") = strCOAID.ToString()
                        rowOperatingHour("COAGroup") = txtVHGroup.Text.ToString()
                        rowOperatingHour("COADescp") = lblCOADescp.Text.ToString()
                        rowOperatingHour("VHNo") = txtVHNo.Text.ToString()
                        rowOperatingHour("NoOfHours") = txtNoOfHours.Text.ToString()

                        rowOperatingHour("BudgetJan") = txtBudgetJan.Text.ToString()
                        rowOperatingHour("BudgetFeb") = txtBudgetFeb.Text.ToString()
                        rowOperatingHour("BudgetMar") = txtBudgetMar.Text.ToString()
                        rowOperatingHour("BudgetApr") = txtBudgetApr.Text.ToString()
                        rowOperatingHour("BudgetMay") = txtBudgetMay.Text.ToString()
                        rowOperatingHour("BudgetJun") = txtBudgetJun.Text.ToString()
                        rowOperatingHour("BudgetJul") = txtBudgetJul.Text.ToString()
                        rowOperatingHour("BudgetAug") = txtBudgetAug.Text.ToString()
                        rowOperatingHour("BudgetSep") = txtBudgetSep.Text.ToString()
                        rowOperatingHour("BudgetOct") = txtBudgetOct.Text.ToString()
                        rowOperatingHour("BudgetNov") = txtBudgetNov.Text.ToString()
                        rowOperatingHour("BudgetDec") = txtBudgetDec.Text.ToString()

                        rowOperatingHour("RevJan") = txtRevJan.Text.ToString()
                        rowOperatingHour("RevFeb") = txtRevFeb.Text.ToString()
                        rowOperatingHour("RevMar") = txtRevMar.Text.ToString()
                        rowOperatingHour("RevApr") = txtRevApr.Text.ToString()
                        rowOperatingHour("RevMay") = txtRevMay.Text.ToString()
                        rowOperatingHour("RevJun") = txtRevJun.Text.ToString()
                        rowOperatingHour("RevJul") = txtRevJul.Text.ToString()
                        rowOperatingHour("RevAug") = txtRevAug.Text.ToString()
                        rowOperatingHour("RevSep") = txtRevSep.Text.ToString()
                        rowOperatingHour("RevOct") = txtRevOct.Text.ToString()
                        rowOperatingHour("RevNov") = txtRevNov.Text.ToString()
                        rowOperatingHour("RevDec") = txtRevDec.Text.ToString()

                        rowOperatingHour("BalanceTotal") = lblBudgetTotal.Text.ToString()
                        rowOperatingHour("VersionNo") = lblVersionNo.Text.ToString()
                        rowOperatingHour("Status") = lblStatus.Text.ToString()
                        rowOperatingHour("OperatingBudgetByHoursID") = strOperatingBudgetByHoursID.ToString()

                        dtOperatingHour.Rows.InsertAt(rowOperatingHour, intRowCount)
                        dgOperatingHours.AutoGenerateColumns = False
                        AddFlag = True
                    End Try
                Else
                    rowOperatingHour("BudgetYear") = lblBudgetYear.Text.ToString()
                    rowOperatingHour("EmpName") = lblDriverName.Text.ToString()
                    rowOperatingHour("VHID") = strVHID.ToString()
                    rowOperatingHour("VHDescp") = lblVHDescp.Text.ToString()
                    rowOperatingHour("COAID") = strCOAID.ToString()
                    rowOperatingHour("COAGroup") = txtVHGroup.Text.ToString()
                    rowOperatingHour("COADescp") = lblCOADescp.Text.ToString()
                    rowOperatingHour("VHNo") = txtVHNo.Text.ToString()
                    rowOperatingHour("NoOfHours") = txtNoOfHours.Text.ToString()

                    rowOperatingHour("BudgetJan") = txtBudgetJan.Text.ToString()
                    rowOperatingHour("BudgetFeb") = txtBudgetFeb.Text.ToString()
                    rowOperatingHour("BudgetMar") = txtBudgetMar.Text.ToString()
                    rowOperatingHour("BudgetApr") = txtBudgetApr.Text.ToString()
                    rowOperatingHour("BudgetMay") = txtBudgetMay.Text.ToString()
                    rowOperatingHour("BudgetJun") = txtBudgetJun.Text.ToString()
                    rowOperatingHour("BudgetJul") = txtBudgetJul.Text.ToString()
                    rowOperatingHour("BudgetAug") = txtBudgetAug.Text.ToString()
                    rowOperatingHour("BudgetSep") = txtBudgetSep.Text.ToString()
                    rowOperatingHour("BudgetOct") = txtBudgetOct.Text.ToString()
                    rowOperatingHour("BudgetNov") = txtBudgetNov.Text.ToString()
                    rowOperatingHour("BudgetDec") = txtBudgetDec.Text.ToString()

                    rowOperatingHour("RevJan") = txtRevJan.Text.ToString()
                    rowOperatingHour("RevFeb") = txtRevFeb.Text.ToString()
                    rowOperatingHour("RevMar") = txtRevMar.Text.ToString()
                    rowOperatingHour("RevApr") = txtRevApr.Text.ToString()
                    rowOperatingHour("RevMay") = txtRevMay.Text.ToString()
                    rowOperatingHour("RevJun") = txtRevJun.Text.ToString()
                    rowOperatingHour("RevJul") = txtRevJul.Text.ToString()
                    rowOperatingHour("RevAug") = txtRevAug.Text.ToString()
                    rowOperatingHour("RevSep") = txtRevSep.Text.ToString()
                    rowOperatingHour("RevOct") = txtRevOct.Text.ToString()
                    rowOperatingHour("RevNov") = txtRevNov.Text.ToString()
                    rowOperatingHour("RevDec") = txtRevDec.Text.ToString()

                    rowOperatingHour("BalanceTotal") = lblBudgetTotal.Text.ToString()
                    rowOperatingHour("VersionNo") = lblVersionNo.Text.ToString()
                    rowOperatingHour("Status") = lblStatus.Text.ToString()
                    rowOperatingHour("OperatingBudgetByHoursID") = strOperatingBudgetByHoursID.ToString()

                    dtOperatingHour.Rows.InsertAt(rowOperatingHour, intRowCount)
                    dgOperatingHours.AutoGenerateColumns = False
                    AddFlag = True
                End If
                dgOperatingHours.AutoGenerateColumns = False
                dgOperatingHours.DataSource = dtOperatingHour
                btnAdd.Text = "Add"
            Else
                MsgBox("Sorry, the VHNo already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Update_record()

        Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT

        If strVHNo = txtVHNo.Text.Trim() Then
            Dim intCount As Integer = dgOperatingHours.CurrentRow.Index

            dgOperatingHours.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("OperatingBudgetByHoursID").Value = strOperatingBudgetByHoursID.ToString()
            dgOperatingHours.Rows(intCount).Cells("EmpName").Value = lblDriverName.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("VHID").Value = strVHID.ToString()
            dgOperatingHours.Rows(intCount).Cells("VHNo").Value = txtVHNo.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("VHDescp").Value = lblVHDescp.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("COAID").Value = strCOAID.ToString()
            dgOperatingHours.Rows(intCount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("COAGroup").Value = txtVHGroup.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("NoOfHours").Value = txtNoOfHours.Text.ToString()

            dgOperatingHours.Rows(intCount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

            dgOperatingHours.Rows(intCount).Cells("RevJan").Value = txtRevJan.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevMar").Value = txtRevMar.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevApr").Value = txtRevApr.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevMay").Value = txtRevMay.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevJun").Value = txtRevJun.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevJul").Value = txtRevJul.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevAug").Value = txtRevAug.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevSep").Value = txtRevSep.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevOct").Value = txtRevOct.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevNov").Value = txtRevNov.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevDec").Value = txtRevDec.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetTotal").Value = lblBudgetTotal.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("Status").Value = lblStatus.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("VersionNo").Value = lblVersionNo.Text.ToString()

            btnAdd.Text = "Add"
            txtVHNo.Text = String.Empty
            btnSaveAll.Text = "Update All"
            dgOperatingHours.AutoGenerateColumns = False
            AddFlag = False
        ElseIf Not VHNoExist(oOperatingBudgetHourPPT.VHNO) Then
            Dim intCount As Integer = dgOperatingHours.CurrentRow.Index

            dgOperatingHours.Rows(intCount).Cells("BudgetYear").Value = lblBudgetYear.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("OperatingBudgetByHoursID").Value = strOperatingBudgetByHoursID.ToString()
            dgOperatingHours.Rows(intCount).Cells("EmpName").Value = lblDriverName.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("VHID").Value = strVHID.ToString()
            dgOperatingHours.Rows(intCount).Cells("VHNo").Value = txtVHNo.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("VHDescp").Value = lblVHDescp.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("COAID").Value = strCOAID.ToString()
            dgOperatingHours.Rows(intCount).Cells("COADescp").Value = lblCOADescp.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("COAGroup").Value = txtVHGroup.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("NoOfHours").Value = txtNoOfHours.Text.ToString()

            dgOperatingHours.Rows(intCount).Cells("BudgetJan").Value = txtBudgetJan.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetFeb").Value = txtBudgetFeb.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetMar").Value = txtBudgetMar.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetApr").Value = txtBudgetApr.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetMay").Value = txtBudgetMay.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetJun").Value = txtBudgetJun.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetJul").Value = txtBudgetJul.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetAug").Value = txtBudgetAug.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetSep").Value = txtBudgetSep.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetOct").Value = txtBudgetOct.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetNov").Value = txtBudgetNov.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("BudgetDec").Value = txtBudgetDec.Text.ToString()

            dgOperatingHours.Rows(intCount).Cells("RevJan").Value = txtRevJan.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevFeb").Value = txtRevFeb.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevMar").Value = txtRevMar.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevApr").Value = txtRevApr.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevMay").Value = txtRevMay.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevJun").Value = txtRevJun.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevJul").Value = txtRevJul.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevAug").Value = txtRevAug.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevSep").Value = txtRevSep.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevOct").Value = txtRevOct.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevNov").Value = txtRevNov.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("RevDec").Value = txtRevDec.Text.ToString()

            dgOperatingHours.Rows(intCount).Cells("BalanceTotal").Value = lblBudgetTotal.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("Status").Value = lblStatus.Text.ToString()
            dgOperatingHours.Rows(intCount).Cells("VersionNo").Value = lblVersionNo.Text.ToString()

            btnAdd.Text = "Add"
            txtVHNo.Text = String.Empty
            btnSaveAll.Text = "Update All"
            dgOperatingHours.AutoGenerateColumns = False
            AddFlag = False
        Else
            MsgBox("The VHNo already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
        End If
        AddFlag = False
    End Sub
    Private Function VHNoExist(ByVal VHNo As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgOperatingHours.Rows
                If VHNo = objDataGridViewRow.Cells("VHNo").Value.ToString() Then
                    txtVHNo.Text = String.Empty
                    'txtRequestedQty.Text = string.empty 
                    txtVHNo.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub btnResetGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetGeneral.Click
        Clear()
    End Sub
    Private Sub Clear()
        strOperatingBudgetByHoursID = ""
        strCOAID = ""
        strVHID = ""
        txtVHNo.Text = ""
        txtVHGroup.Text = ""
        lblVHDescp.Text = ""
        lblCOADescp.Text = ""
        lblDriverName.Text = ""
        txtNoOfHours.Text = ""

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
        lblBudgetTotal.Text = ""

        lblVersionNo.Text = ""
        lblStatus.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        If AddFlag = True Then
            SaveFunction()
            Clear()
            btnAdd.Text = "Add"
            btnSaveAll.Text = "Save"
        ElseIf AddFlag = False Then
            UpdateFunction()
            Clear()
            btnAdd.Text = "Add"
            btnSaveAll.Text = "Save"
        End If
        AddFlag = True
        ClearGridView(dgOperatingHours)
        GridOperatingHourViewbind()
        tbOperatingBudgetByHour.SelectedTab = tbView
    End Sub
    Private Sub SaveFunction()
        Dim ds As New DataSet


        For Each DataGridView In dgOperatingHours.Rows
            Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT

            oOperatingBudgetHourPPT.BudgetYear = DataGridView.Cells("BudgetYear").Value.ToString()
            oOperatingBudgetHourPPT.VHID = DataGridView.Cells("VHID").Value.ToString()
            oOperatingBudgetHourPPT.COAID = DataGridView.Cells("COAID").Value.ToString()
            oOperatingBudgetHourPPT.NoOfHours = DataGridView.Cells("NoOfHours").Value.ToString()

            oOperatingBudgetHourPPT.BudgetJan = DataGridView.Cells("BudgetJan").Value.ToString()
            oOperatingBudgetHourPPT.BudgetFeb = DataGridView.Cells("BudgetFeb").Value.ToString()
            oOperatingBudgetHourPPT.BudgetMar = DataGridView.Cells("BudgetMar").Value.ToString()
            oOperatingBudgetHourPPT.BudgetApr = DataGridView.Cells("BudgetApr").Value.ToString()
            oOperatingBudgetHourPPT.BudgetMay = DataGridView.Cells("BudgetMay").Value.ToString()
            oOperatingBudgetHourPPT.BudgetJun = DataGridView.Cells("BudgetJun").Value.ToString()
            oOperatingBudgetHourPPT.BudgetJul = DataGridView.Cells("BudgetJul").Value.ToString()
            oOperatingBudgetHourPPT.BudgetAug = DataGridView.Cells("BudgetAug").Value.ToString()
            oOperatingBudgetHourPPT.BudgetSep = DataGridView.Cells("BudgetSep").Value.ToString()
            oOperatingBudgetHourPPT.BudgetOct = DataGridView.Cells("BudgetOct").Value.ToString()
            oOperatingBudgetHourPPT.BudgetNov = DataGridView.Cells("BudgetNov").Value.ToString()
            oOperatingBudgetHourPPT.BudgetDec = DataGridView.Cells("BudgetDec").Value.ToString()

            If DataGridView.Cells("RevJan").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevJan = DataGridView.Cells("RevJan").Value.ToString()
            End If
            If DataGridView.Cells("RevFeb").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevFeb = DataGridView.Cells("RevFeb").Value.ToString()
            End If
            If DataGridView.Cells("RevMar").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevMar = DataGridView.Cells("RevMar").Value.ToString()
            End If
            If DataGridView.Cells("RevApr").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevApr = DataGridView.Cells("RevApr").Value.ToString()
            End If
            If DataGridView.Cells("RevMay").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevMay = DataGridView.Cells("RevMay").Value.ToString()
            End If
            If DataGridView.Cells("RevJun").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevJun = DataGridView.Cells("RevJun").Value.ToString()
            End If
            If DataGridView.Cells("RevJul").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevJul = DataGridView.Cells("RevJul").Value.ToString()
            End If
            If DataGridView.Cells("RevAug").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevAug = DataGridView.Cells("RevAug").Value.ToString()
            End If
            If DataGridView.Cells("RevSep").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevSep = DataGridView.Cells("RevSep").Value.ToString()
            End If
            If DataGridView.Cells("RevOct").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevOct = DataGridView.Cells("RevOct").Value.ToString()
            End If
            If DataGridView.Cells("RevNov").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevNov = DataGridView.Cells("RevNov").Value.ToString()
            End If
            If DataGridView.Cells("RevDec").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevDec = DataGridView.Cells("RevDec").Value.ToString()
            End If

            If DataGridView.Cells("Status").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.Status = DataGridView.Cells("Status").Value.ToString()
            End If


            If DataGridView.Cells("VersionNo").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.VersionNo = DataGridView.Cells("VersionNo").Value.ToString()
            End If
            oOperatingBudgetHourPPT.BudgetTotal = DataGridView.Cells("BalanceTotal").Value.ToString()

            ds = OperatingBudgetHourBOL.OperatingBudgetByHoursInsert(oOperatingBudgetHourPPT)
        Next
        If ds Is Nothing Then
            MessageBox.Show("Failed to save database", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub
    Private Sub UpdateFunction()
        Dim ds As New DataSet
        For Each DataGridView In dgOperatingHours.Rows
            Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
            oOperatingBudgetHourPPT.BudgetYear = DataGridView.Cells("BudgetYear").Value.ToString()
            oOperatingBudgetHourPPT.VHID = DataGridView.Cells("VHID").Value.ToString()
            oOperatingBudgetHourPPT.COAID = DataGridView.Cells("COAID").Value.ToString()
            oOperatingBudgetHourPPT.NoOfHours = DataGridView.Cells("NoOfHours").Value.ToString()
            oOperatingBudgetHourPPT.OperatingBudgetByHoursID = DataGridView.Cells("OperatingBudgetByHoursID").Value.ToString()
            oOperatingBudgetHourPPT.BudgetJan = DataGridView.Cells("BudgetJan").Value.ToString()
            oOperatingBudgetHourPPT.BudgetFeb = DataGridView.Cells("BudgetFeb").Value.ToString()
            oOperatingBudgetHourPPT.BudgetMar = DataGridView.Cells("BudgetMar").Value.ToString()
            oOperatingBudgetHourPPT.BudgetApr = DataGridView.Cells("BudgetApr").Value.ToString()
            oOperatingBudgetHourPPT.BudgetMay = DataGridView.Cells("BudgetMay").Value.ToString()
            oOperatingBudgetHourPPT.BudgetJun = DataGridView.Cells("BudgetJun").Value.ToString()
            oOperatingBudgetHourPPT.BudgetJul = DataGridView.Cells("BudgetJul").Value.ToString()
            oOperatingBudgetHourPPT.BudgetAug = DataGridView.Cells("BudgetAug").Value.ToString()
            oOperatingBudgetHourPPT.BudgetSep = DataGridView.Cells("BudgetSep").Value.ToString()
            oOperatingBudgetHourPPT.BudgetOct = DataGridView.Cells("BudgetOct").Value.ToString()
            oOperatingBudgetHourPPT.BudgetNov = DataGridView.Cells("BudgetNov").Value.ToString()
            oOperatingBudgetHourPPT.BudgetDec = DataGridView.Cells("BudgetDec").Value.ToString()

            If DataGridView.Cells("RevJan").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevJan = DataGridView.Cells("RevJan").Value.ToString()
            End If
            If DataGridView.Cells("RevFeb").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevFeb = DataGridView.Cells("RevFeb").Value.ToString()
            End If
            If DataGridView.Cells("RevMar").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevMar = DataGridView.Cells("RevMar").Value.ToString()
            End If
            If DataGridView.Cells("RevApr").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevApr = DataGridView.Cells("RevApr").Value.ToString()
            End If
            If DataGridView.Cells("RevMay").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevMay = DataGridView.Cells("RevMay").Value.ToString()
            End If
            If DataGridView.Cells("RevJun").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevJun = DataGridView.Cells("RevJun").Value.ToString()
            End If
            If DataGridView.Cells("RevJul").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevJul = DataGridView.Cells("RevJul").Value.ToString()
            End If
            If DataGridView.Cells("RevAug").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevAug = DataGridView.Cells("RevAug").Value.ToString()
            End If
            If DataGridView.Cells("RevSep").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevSep = DataGridView.Cells("RevSep").Value.ToString()
            End If
            If DataGridView.Cells("RevOct").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevOct = DataGridView.Cells("RevOct").Value.ToString()
            End If
            If DataGridView.Cells("RevNov").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevNov = DataGridView.Cells("RevNov").Value.ToString()
            End If
            If DataGridView.Cells("RevDec").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.RevDec = DataGridView.Cells("RevDec").Value.ToString()
            End If

            If DataGridView.Cells("Status").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.Status = DataGridView.Cells("Status").Value.ToString()
            End If


            If DataGridView.Cells("VersionNo").Value.ToString() <> "" Then
                oOperatingBudgetHourPPT.VersionNo = DataGridView.Cells("VersionNo").Value.ToString()
            End If
            oOperatingBudgetHourPPT.BudgetTotal = DataGridView.Cells("BalanceTotal").Value.ToString()

            ds = OperatingBudgetHourBOL.OperatingBudgetByHoursUpdate(oOperatingBudgetHourPPT)
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
    Private Sub GridOperatingHourViewbind()
        Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
        Dim dt As New DataTable
        dt = OperatingBudgetHourBOL.OperatingBudgetByHoursSelect()
        If dt.Rows.Count <> 0 Then
            dgOperatingHourView.DataSource = dt
            dgOperatingHourView.AutoGenerateColumns = False
        End If
    End Sub

    Private Sub btnSearchVHGroupView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHGroupView.Click
        'Dim frmVHGroupLookUp As New VHGroupLookUp
        'frmVHGroupLookUp.BindGrid()
        'Dim results As DialogResult = frmVHGroupLookUp.ShowDialog()
        'If frmVHGroupLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
        '    Me.txtCOAGroupView.Text = frmVHGroupLookUp.strCOAGroup
        '    strCOAID = frmVHGroupLookUp.strgCOAID
        '    lblCOADescpView.Text = frmVHGroupLookUp.strCOADescp

        Cursor = Cursors.WaitCursor
        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtCOAGroupView.Text = frmAcctcodeLookup.strAcctcode
            strCOAID = frmAcctcodeLookup.strAcctId
            lblCOADescpView.Text = frmAcctcodeLookup.strAcctDescp
            'lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
        End If
        Cursor = Cursors.Arrow
        'End If
    End Sub

    Private Sub btnSearchVHNoView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHNoView.Click
        Dim frmVHNoLookup As New VHNoLookup
        Dim result As DialogResult = frmVHNoLookup.ShowDialog()
        If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            strVHID = frmVHNoLookup.psVHID
            Me.txtVHNoView.Text = frmVHNoLookup.psVHWSCode
            Me.lblVHDescpView.Text = frmVHNoLookup.psVHDesc
            'psSIVVHCategoryID = frmVHNoLookup.psVHCategoryID
            '' psSIVVHType = frmVHNoLookup.psVHCategoryType
            If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
                If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
                    strVHType = "V"
                End If
                If frmVHNoLookup.psVHCategoryType = "Workshop" Then
                    strVHType = "W"
                End If
                If frmVHNoLookup.psVHCategoryType = "Others" Then
                    strVHType = "O"
                End If
            End If
        End If
    End Sub
    Private Sub tbOperatingBudgetByHour_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbOperatingBudgetByHour.Click
        Clear()
        ClearGridView(dgOperatingHours)
        lblVersionNo.Visible = False
        lblVersionNoL.Visible = False
        lblStatus.Visible = False
        lblStatusL.Visible = False
        txtCOAGroupView.Text = ""
        lblCOADescpView.Text = ""
        txtVHNoView.Text = ""
        lblVHNoView.Text = ""
        btnAdd.Text = "Add"
        btnSaveAll.Text = "Save"
    End Sub
    Private Sub dgOperatingHourView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOperatingHourView.DoubleClick
        dgOperatingHourViewEdit()

        tbOperatingBudgetByHour.SelectedTab = tbOperatingBudget
        lblVersionNo.Visible = True
        lblVersionNoL.Visible = True
        lblStatus.Visible = True
        lblStatusL.Visible = True

    End Sub
    Private Sub dgOperatingHourViewEdit()
        Dim ds As New DataSet
        If dgOperatingHourView.RowCount > 0 Then
            strOperatingBudgetByHoursID = dgOperatingHourView.SelectedRows(0).Cells("OperatingBudgetByHoursIDView").Value.ToString()
            strCOAID = dgOperatingHourView.SelectedRows(0).Cells("COAIDView").Value.ToString()
            strVHID = dgOperatingHourView.SelectedRows(0).Cells("VHIDView").Value.ToString()
            lblBudgetYear.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetYearView").Value.ToString()
            txtVHNo.Text = dgOperatingHourView.SelectedRows(0).Cells("VHNoView").Value.ToString()
            lblVHDescp.Text = dgOperatingHourView.SelectedRows(0).Cells("VHDescpView").Value.ToString()
            txtVHGroup.Text = dgOperatingHourView.SelectedRows(0).Cells("COAGroupView").Value.ToString()
            lblCOADescp.Text = dgOperatingHourView.SelectedRows(0).Cells("COADescpView").Value.ToString()
            lblDriverName.Text = dgOperatingHourView.SelectedRows(0).Cells("EmpNameView").Value.ToString()
            txtNoOfHours.Text = dgOperatingHourView.SelectedRows(0).Cells("NoOfHoursView").Value.ToString()
            lblVersionNo.Text = dgOperatingHourView.SelectedRows(0).Cells("VersionNoView").Value.ToString()
            lblStatus.Text = dgOperatingHourView.SelectedRows(0).Cells("StatusView").Value.ToString()

            txtBudgetJan.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetJanView").Value.ToString()
            txtBudgetFeb.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetFebView").Value.ToString()
            txtBudgetMar.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetMarView").Value.ToString()
            txtBudgetApr.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetAprView").Value.ToString()
            txtBudgetMay.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetMayView").Value.ToString()
            txtBudgetJun.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetJunView").Value.ToString()
            txtBudgetJul.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetJulView").Value.ToString()
            txtBudgetAug.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetAugView").Value.ToString()
            txtBudgetSep.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetSepView").Value.ToString()
            txtBudgetOct.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetOctView").Value.ToString()
            txtBudgetNov.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetNovView").Value.ToString()
            txtBudgetDec.Text = dgOperatingHourView.SelectedRows(0).Cells("BudgetDecView").Value.ToString()

            txtRevJan.Text = dgOperatingHourView.SelectedRows(0).Cells("RevJanView").Value.ToString()
            txtRevFeb.Text = dgOperatingHourView.SelectedRows(0).Cells("RevFebView").Value.ToString()
            txtRevMar.Text = dgOperatingHourView.SelectedRows(0).Cells("RevMarView").Value.ToString()
            txtRevApr.Text = dgOperatingHourView.SelectedRows(0).Cells("RevAprView").Value.ToString()
            txtRevMay.Text = dgOperatingHourView.SelectedRows(0).Cells("RevMayView").Value.ToString()
            txtRevJun.Text = dgOperatingHourView.SelectedRows(0).Cells("RevJunView").Value.ToString()
            txtRevJul.Text = dgOperatingHourView.SelectedRows(0).Cells("RevJulView").Value.ToString()
            txtRevAug.Text = dgOperatingHourView.SelectedRows(0).Cells("RevAugView").Value.ToString()
            txtRevSep.Text = dgOperatingHourView.SelectedRows(0).Cells("RevSepView").Value.ToString()
            txtRevOct.Text = dgOperatingHourView.SelectedRows(0).Cells("RevOctView").Value.ToString()
            txtRevNov.Text = dgOperatingHourView.SelectedRows(0).Cells("RevNovView").Value.ToString()
            txtRevDec.Text = dgOperatingHourView.SelectedRows(0).Cells("RevDecView").Value.ToString()

            lblBudgetTotal.Text = dgOperatingHourView.SelectedRows(0).Cells("BalanceTotalView").Value.ToString()
        End If
        'btnAdd.Text = "Update"
        btnSaveAll.Text = "Update All"
        'AddFlag = False
        BinddgOperatingHoursDataGrid()
        Clear()

    End Sub

    Private Sub dgOperatingHours_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOperatingHours.DoubleClick
        Dim ds As New DataSet
        If dgOperatingHours.RowCount > 0 Then
            strOperatingBudgetByHoursID = dgOperatingHours.SelectedRows(0).Cells("OperatingBudgetByHoursID").Value.ToString()
            strCOAID = dgOperatingHours.SelectedRows(0).Cells("COAID").Value.ToString()
            strVHID = dgOperatingHours.SelectedRows(0).Cells("VHID").Value.ToString()
            lblBudgetYear.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetYear").Value.ToString()
            txtVHNo.Text = dgOperatingHours.SelectedRows(0).Cells("VHNo").Value.ToString()
            lblVHDescp.Text = dgOperatingHours.SelectedRows(0).Cells("VHDescp").Value.ToString()
            txtVHGroup.Text = dgOperatingHours.SelectedRows(0).Cells("COAGroup").Value.ToString()
            lblCOADescp.Text = dgOperatingHours.SelectedRows(0).Cells("COADescp").Value.ToString()
            lblDriverName.Text = dgOperatingHours.SelectedRows(0).Cells("EmpName").Value.ToString()
            txtNoOfHours.Text = dgOperatingHours.SelectedRows(0).Cells("NoOfHours").Value.ToString()
            lblVersionNo.Text = dgOperatingHours.SelectedRows(0).Cells("VersionNo").Value.ToString()
            lblStatus.Text = dgOperatingHours.SelectedRows(0).Cells("Status").Value.ToString()

            txtBudgetJan.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetJan").Value.ToString()
            txtBudgetFeb.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetFeb").Value.ToString()
            txtBudgetMar.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetMar").Value.ToString()
            txtBudgetApr.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetApr").Value.ToString()
            txtBudgetMay.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetMay").Value.ToString()
            txtBudgetJun.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetJun").Value.ToString()
            txtBudgetJul.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetJul").Value.ToString()
            txtBudgetAug.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetAug").Value.ToString()
            txtBudgetSep.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetSep").Value.ToString()
            txtBudgetOct.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetOct").Value.ToString()
            txtBudgetNov.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetNov").Value.ToString()
            txtBudgetDec.Text = dgOperatingHours.SelectedRows(0).Cells("BudgetDec").Value.ToString()

            txtRevJan.Text = dgOperatingHours.SelectedRows(0).Cells("RevJan").Value.ToString()
            txtRevFeb.Text = dgOperatingHours.SelectedRows(0).Cells("RevFeb").Value.ToString()
            txtRevMar.Text = dgOperatingHours.SelectedRows(0).Cells("RevMar").Value.ToString()
            txtRevApr.Text = dgOperatingHours.SelectedRows(0).Cells("RevApr").Value.ToString()
            txtRevMay.Text = dgOperatingHours.SelectedRows(0).Cells("RevMay").Value.ToString()
            txtRevJun.Text = dgOperatingHours.SelectedRows(0).Cells("RevJun").Value.ToString()
            txtRevJul.Text = dgOperatingHours.SelectedRows(0).Cells("RevJul").Value.ToString()
            txtRevAug.Text = dgOperatingHours.SelectedRows(0).Cells("RevAug").Value.ToString()
            txtRevSep.Text = dgOperatingHours.SelectedRows(0).Cells("RevSep").Value.ToString()
            txtRevOct.Text = dgOperatingHours.SelectedRows(0).Cells("RevOct").Value.ToString()
            txtRevNov.Text = dgOperatingHours.SelectedRows(0).Cells("RevNov").Value.ToString()
            txtRevDec.Text = dgOperatingHours.SelectedRows(0).Cells("RevDec").Value.ToString()
            lblBudgetTotal.Text = dgOperatingHours.SelectedRows(0).Cells("BalanceTotal").Value.ToString()
        End If
        btnAdd.Text = "Update"
        btnSaveAll.Text = "Update All"
        AddFlag = False

    End Sub
    Private Sub BinddgOperatingHoursDataGrid()
        Try
            Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
            Dim oOperatingBudgetHourBOL As New OperatingBudgetHourBOL

            With oOperatingBudgetHourPPT
                .VHNO = Me.txtVHNo.Text
            End With

            dtOperatingHour = OperatingBudgetHourBOL.OperatingBudgetByHoursSelect_MultipleEntry(oOperatingBudgetHourPPT)
            If dtOperatingHour.Rows.Count <> 0 Then
                'dtOperatingCost.AutoGenerateColumns = False
                Me.dgOperatingHours.DataSource = dtOperatingHour
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
        oOperatingBudgetHourPPT.VHNO = txtVHNoView.Text.ToString()
        oOperatingBudgetHourPPT.COACode = txtCOAGroupView.Text.ToString()

        Dim ds As New DataSet
        ds = OperatingBudgetHourBOL.OperatingHoursViewSearch(oOperatingBudgetHourPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            dgOperatingHourView.Visible = True
            dgOperatingHourView.DataSource = ds.Tables(0)
        Else
            MessageBox.Show("No Record Found!,Please Enter Search Criteria", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            GridOperatingHourViewbind()
        End If

    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        Clear()
        btnAdd.Text = "Add"
        btnSaveAll.Text = "SaveAll"
        ClearGridView(dgOperatingHours)
        AddFlag = True
    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Clear()
        btnAdd.Text = "Add"
        btnSaveAll.Text = "Save All"
        tbOperatingBudgetByHour.SelectedTab = tbOperatingBudget
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        dgOperatingHourViewEdit()
        tbOperatingBudgetByHour.SelectedTab = tbOperatingBudget
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete()
        GridOperatingHourViewbind()
        tbOperatingBudgetByHour.SelectedTab = tbView
    End Sub
    Private Sub Delete()
        Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
        Dim oOperatingBudgetHourBOL As New OperatingBudgetHourBOL
        If dgOperatingHourView.Rows.Count > 0 Then
            If Me.btnSaveAll.Text = "Update All" Then
                MessageBox.Show("Record in edit mode, please update first", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                oOperatingBudgetHourPPT.OperatingBudgetByHoursID = dgOperatingHourView.SelectedRows(0).Cells("OperatingBudgetByHoursIDView").Value.ToString
                oOperatingBudgetHourPPT.COAID = dgOperatingHourView.SelectedRows(0).Cells("COAIDView").Value.ToString()
                OperatingBudgetHourBOL.OperatingBudgetByHoursDelete(oOperatingBudgetHourPPT)
                GridOperatingHourViewbind()
                MessageBox.Show("Record deleted successfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub txtVHGroup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVHGroup.Leave
        If txtVHGroup.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim oOperatingBudgetHourPPT As New OperatingBudgetHourPPT
            oOperatingBudgetHourPPT.COACode = txtVHGroup.Text.Trim()
            Dim oOperatingBudgetHourtBOL As New OperatingBudgetHourBOL
            ds = OperatingBudgetHourBOL.AcctlookupSearch(oOperatingBudgetHourPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Invalid Account code,Please Choose it from look up")
                txtVHGroup.Text = String.Empty
                lblCOADescp.Text = String.Empty
                'lblOldCOACode.Text = String.Empty
                strCOAID = String.Empty
                txtVHGroup.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
                    txtVHGroup.Text = ds.Tables(0).Rows(0).Item("COACode")
                End If
                If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
                    lblCOADescp.Text = ds.Tables(0).Rows(0).Item("COADescp")
                End If
                If ds.Tables(0).Rows(0).Item("COAID").ToString() <> String.Empty Then
                    strCOAID = ds.Tables(0).Rows(0).Item("COAID")
                End If
                'If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
                '    lblOldCOACode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                'End If
            End If
            'BudgetTotalGET()
            'ActualAmountGET()
        Else
            txtVHGroup.Text = String.Empty
            lblCOADescp.Text = String.Empty
            'lblOldCOACode.Text = String.Empty
            strCOAID = String.Empty
        End If
    End Sub

    Private Sub MyTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoOfHours.KeyDown, txtBudgetJan.KeyDown, txtBudgetFeb.KeyDown, txtBudgetMar.KeyDown, txtBudgetApr.KeyDown, txtBudgetMay.KeyDown, txtBudgetJun.KeyDown, txtBudgetJul.KeyDown, txtBudgetAug.KeyDown, txtBudgetSep.KeyDown, txtBudgetOct.KeyDown, txtBudgetNov.KeyDown, txtBudgetDec.KeyDown, txtRevJan.KeyDown, txtRevFeb.KeyDown, txtRevMar.KeyDown, txtRevApr.KeyDown, txtRevMay.KeyDown, txtRevJun.KeyDown, txtRevJul.KeyDown, txtRevAug.KeyDown, txtRevSep.KeyDown, txtRevOct.KeyDown, txtRevNov.KeyDown, txtRevDec.KeyDown
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
    Private Sub MyTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfHours.KeyPress, txtBudgetJan.KeyPress, txtBudgetFeb.KeyPress, txtBudgetMar.KeyPress, txtBudgetApr.KeyPress, txtBudgetMay.KeyPress, txtBudgetJun.KeyPress, txtBudgetJul.KeyPress, txtBudgetAug.KeyPress, txtBudgetSep.KeyPress, txtBudgetOct.KeyPress, txtBudgetNov.KeyPress, txtBudgetDec.KeyPress, txtRevJan.KeyPress, txtRevFeb.KeyPress, txtRevMar.KeyPress, txtRevApr.KeyPress, txtRevMay.KeyPress, txtRevJun.KeyPress, txtRevJul.KeyPress, txtRevAug.KeyPress, txtRevSep.KeyPress, txtRevOct.KeyPress, txtRevNov.KeyPress, txtRevDec.KeyPress
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub
  
   
  
End Class