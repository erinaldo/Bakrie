Imports Accounts_BOL
Imports Common_PPT
Imports Accounts_PPT
Imports Common_BOL
Public Class COALookup
    Dim dtChildCOA As New DataTable()
    Dim strChildCOA As String = Nothing
    Dim strCOAID As String = String.Empty
    Public strAcctcode As String = String.Empty
    Public strAcctId As String = String.Empty ''COAID
    Public strAcctDescp As String = String.Empty
    Public strAcctExpenditureAG As String = String.Empty
    Public strOldAccountCode As String = String.Empty


    Private Sub COALookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        strCOAID = String.Empty
        LoadMainActivityCombo()
        ''dgvCOA.UseWaitCursor = True
        'LoadCOAGrid()
        ''dgvCOA.UseWaitCursor = False
        txtOldAccountCode.Focus()
        ' MessageBox.Show("")
    End Sub

    Private Sub LoadMainActivityCombo()
        Dim dtCOA As New DataTable()
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG
        dtCOA = Accounts_BOL.COALookupBOL.SelectAllParentCOA(objCOAPPT)
        If dtCOA.Rows.Count <> 0 Then

            cmbMainActivity.DataSource = dtCOA
            cmbMainActivity.DisplayMember = "COADescp"
            cmbMainActivity.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbMainActivity.SelectedIndex
            'If cmbMainActivity.Text <> String.Empty Then
            '    lblMainActivityCode.Text = dtCOA.Rows(intRowCount).Item("COACode").ToString()
            'Else
            '    lblMainActivityCode.Text = String.Empty
            'End If
            cmbMainActivity.SelectedIndex = -1

            cmbMainActivity.Text = "--Select--"
        End If
        lblMainActivityCode.Text = String.Empty
    End Sub

    Private Sub LoadCOAGrid()
        Dim dtCOA As New DataTable()
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG
        dtCOA = Accounts_BOL.COALookupBOL.LoadCOAGrid(objCOAPPT)
        If dtCOA.Rows.Count <> 0 Then
            lblNoRecord.Visible = False
            dgvCOA.AutoGenerateColumns = False
            dgvCOA.DataSource = dtCOA
        Else
            dgvCOA.AutoGenerateColumns = False
            lblNoRecord.Visible = True
            dgvCOA.DataSource = Nothing
        End If
    End Sub

    Private Sub LoadCOAGridByCOAID(ByVal COAID As String)
        Dim dtCOA As New DataTable()
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.COACode = COAID
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG
        dtCOA = Accounts_BOL.COALookupBOL.LoadCOAGridByCOAID(objCOAPPT)
        If dtCOA.Rows.Count <> 0 Then
            dgvCOA.AutoGenerateColumns = False
            lblNoRecord.Visible = False
            dgvCOA.DataSource = dtCOA
        Else
            dgvCOA.AutoGenerateColumns = False
            lblNoRecord.Visible = True
            dgvCOA.DataSource = Nothing
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ComboClear()
        If cmbActCategory.DataBindings.Count <> 0 Then
            ' cmbActCategory.DataSource = d
        End If
        If cmbActCategory.Items.Count <> 0 Then
            cmbActCategory.Items.Remove(cmbActCategory.Items.Item(0))
        End If
        If cmbSubactivity.Items.Count <> 0 Then
            cmbSubactivity.Items.Remove(cmbSubactivity.Items.Item(0))
        End If
    End Sub

    Private Sub cmbMainActivity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMainActivity.SelectedIndexChanged    
        Me.Cursor = Cursors.WaitCursor
        Threading.Thread.Sleep(100)
        If cmbMainActivity.SelectedIndex <> -1 Then
            If cmbMainActivity.Text <> "--Select--" Then
                MainActivity_SelectedIndexChanged()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub MainActivity_SelectedIndexChanged()
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG
        '  dtChildCOA.Clear()
        If cmbMainActivity.Items.Count <> 0 Then
            objCOAPPT.ParentId = cmbMainActivity.SelectedValue.ToString()
        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Then
            dtChildCOA = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If

        If dtChildCOA.Rows.Count <> 0 Then
            cmbActCategory.DataSource = dtChildCOA
            cmbActCategory.DisplayMember = "COADescp"
            cmbActCategory.ValueMember = "COAID"

          

            Dim intRowCount As Integer
            intRowCount = cmbActCategory.SelectedIndex
            cmbActCategory.SelectedIndex = -1

            Dim dt1 As New DataTable
            If cmbMainActivity.Items.Count <> 0 Then
                objCOAPPT.COAID = cmbMainActivity.SelectedValue.ToString()
            End If
            If objCOAPPT.COAID <> "System.Data.DataRowView" Then
                If objCOAPPT.COAID <> "" Then
                    dt1 = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                    strCOAID = dt1.Rows(0).Item("COACode").ToString()
                    LoadCOAGridByCOAID(strCOAID)
                    txtOldAccountCode.Text = String.Empty
                End If

            End If


            'If intRowCount >= 0 Then
            '    ''If cmbActCategory.Text <> String.Empty Then
            '    ''    lblCategoryAct.Text = dtChildCOA.Rows(intRowCount).Item("COACode").ToString()
            '    ''Else
            '    ''    lblCategoryAct.Text = String.Empty
            '    ''End If

            '    strCOAID = dtChildCOA.Rows(intRowCount).Item("COACode").ToString()
            '    LoadCOAGridByCOAID(strCOAID)
            '    txtOldAccountCode.Text = String.Empty
            'End If
            'cmbActCategory.Text = "--Select--"

            cmbActCategory.SelectedIndex = -1
            cmbSubactivity.SelectedIndex = -1
            cmbCostType.SelectedIndex = -1
            cmbCostCategory.SelectedIndex = -1
            cmbDetailCost.SelectedIndex = -1

            cmbActCategory.Text = "--Select--"
            cmbSubactivity.Text = "--Select--"
            cmbCostType.Text = "--Select--"
            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"
        Else
            If objCOAPPT.ParentId = "System.Data.DataRowView" Then

            Else
                cmbActCategory.DataSource = Nothing
                cmbSubactivity.DataSource = Nothing
                cmbCostType.DataSource = Nothing
                cmbCostCategory.DataSource = Nothing
                cmbDetailCost.DataSource = Nothing
                dgvCOA.DataSource = Nothing
                cmbMainActivity.DataSource = Nothing
            End If
           
        End If

        ''''
        Dim dt As New DataTable
        If cmbMainActivity.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbMainActivity.SelectedValue.ToString()
        End If
        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ParentCodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbMainActivity.Text <> "System.Data.DataRowView" Then
                        If cmbMainActivity.Text <> "" Then
                            If cmbMainActivity.Text <> "--Select--" Then
                                lblMainActivityCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblMainActivityCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        lblCategoryAct.Text = String.Empty
        lblSubActivityCode.Text = String.Empty
        lblCostTypeCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty
        lblMainActivityCode.Text = String.Empty
        ''''

    End Sub

    Private Sub cmbMainActivity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMainActivity.Leave
        ''MainActivity_Leave()
    End Sub

    Private Sub MainActivity_Leave()
        Dim COAId As String = String.Empty
        Dim objCOAPPT As New COALookupPPT()
        Dim dtParentId As New DataTable
        '  dtChildCOA.Clear()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG
        If cmbMainActivity.Items.Count <> 0 Then
            'objCOAPPT.ParentId = cmbMainActivity.SelectedText.ToString()
            objCOAPPT.COADescp = cmbMainActivity.Text
            dtParentId = COALookupBOL.ParentIdGet(objCOAPPT)
            If dtParentId.Rows.Count > 0 Then
                objCOAPPT.ParentId = dtParentId.Rows(0).Item("COAID")
                COAId = dtParentId.Rows(0).Item("COAID")
            End If

        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Then
            dtChildCOA = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If

        If dtChildCOA.Rows.Count <> 0 Then
            cmbActCategory.DataSource = dtChildCOA
            cmbActCategory.DisplayMember = "COADescp"
            cmbActCategory.ValueMember = "COAID"

            Dim intRowCount As Integer
            intRowCount = cmbActCategory.SelectedIndex
            If intRowCount >= 0 Then
                ''If cmbActCategory.Text <> String.Empty Then
                ''    lblCategoryAct.Text = dtChildCOA.Rows(intRowCount).Item("COACode").ToString()
                ''Else
                ''    lblCategoryAct.Text = String.Empty
                ''End If

                strCOAID = dtChildCOA.Rows(intRowCount).Item("COACode").ToString()
                LoadCOAGridByCOAID(strCOAID)
            End If
            cmbActCategory.Text = "--Select--"
            cmbSubactivity.Text = "--Select--"
            cmbCostType.Text = "--Select--"
            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"
        End If

        ''''
        Dim dt As New DataTable
        If cmbMainActivity.Items.Count <> 0 Then
            'objCOAPPT.COAID = cmbMainActivity.SelectedValue.ToString() 
            objCOAPPT.COAID = COAId
        End If
        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ParentCodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbMainActivity.Text <> "System.Data.DataRowView" Then
                        If cmbMainActivity.Text <> "" Then
                            If cmbMainActivity.Text <> "--Select--" Then
                                lblMainActivityCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblMainActivityCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        lblCategoryAct.Text = String.Empty
        lblSubActivityCode.Text = String.Empty
        lblCostTypeCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''

    End Sub

    Private Sub cmbActCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbActCategory.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbActCategory.SelectedIndex <> -1 Then


            If cmbActCategory.Text <> "--Select--" Then
                cmbActCategory_SelectedIndexChanged()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmbActCategory_SelectedIndexChanged()
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()

        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbActCategory.Items.Count <> 0 Then
            objCOAPPT.ParentId = cmbActCategory.SelectedValue.ToString()

        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbSubactivity.DataSource = dtActCategory
            cmbSubactivity.DisplayMember = "COADescp"
            cmbSubactivity.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbSubactivity.SelectedIndex
            cmbSubactivity.SelectedIndex = -1

            Dim dt1 As New DataTable
            If cmbActCategory.Items.Count <> 0 Then
                objCOAPPT.COAID = cmbActCategory.SelectedValue.ToString()
            End If
            If objCOAPPT.COAID <> "System.Data.DataRowView" Then
                If objCOAPPT.COAID <> "" Then
                    dt1 = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                    strCOAID = dt1.Rows(0).Item("COACode").ToString()
                    LoadCOAGridByCOAID(strCOAID)
                    txtOldAccountCode.Text = String.Empty
                End If

            End If

            'If intRowCount >= 0 Then
            '    ''If cmbSubactivity.Text <> String.Empty Then
            '    ''    lblSubActivityCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
            '    ''Else
            '    ''    lblSubActivityCode.Text = String.Empty
            '    ''End If

            '    strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
            '    LoadCOAGridByCOAID(strCOAID)
            'End If
            cmbSubactivity.SelectedIndex = -1
            cmbCostType.SelectedIndex = -1
            cmbCostCategory.SelectedIndex = -1
            cmbDetailCost.SelectedIndex = -1

            cmbSubactivity.Text = "--Select--"
            cmbCostType.Text = "--Select--"
            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"
        Else
            cmbSubactivity.DataSource = Nothing
            cmbCostType.DataSource = Nothing
            cmbCostCategory.DataSource = Nothing
            cmbDetailCost.DataSource = Nothing
            dgvCOA.DataSource = Nothing
        End If

        ''''
        Dim dt As New DataTable
        If cmbActCategory.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbActCategory.SelectedValue.ToString()
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbActCategory.Text <> "System.Data.DataRowView" Then
                        If cmbActCategory.Text <> "" Then
                            If cmbActCategory.Text <> "--Select--" Then
                                lblCategoryAct.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblCategoryAct.Text = String.Empty
                    End If
                End If
            End If


        End If

        lblCostTypeCode.Text = String.Empty
        lblSubActivityCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbActCategory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbActCategory.Leave
        ''cmbActCategory_Leave()
    End Sub

    Private Sub cmbActCategory_Leave()
        Dim COAId As String = String.Empty
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.COADescp = cmbActCategory.Text
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        dtActCategory = COALookupBOL.ChildCOAIDGet(objCOAPPT)
        If cmbActCategory.Items.Count <> 0 Then
            If dtActCategory.Rows.Count <> 0 Then
                objCOAPPT.ParentId = dtActCategory.Rows(0).Item("COAID")
                COAId = dtActCategory.Rows(0).Item("COAID")
            End If
        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbSubactivity.DataSource = dtActCategory
            cmbSubactivity.DisplayMember = "COADescp"
            cmbSubactivity.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbSubactivity.SelectedIndex

            If intRowCount >= 0 Then
                ''If cmbSubactivity.Text <> String.Empty Then
                ''    lblSubActivityCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                ''Else
                ''    lblSubActivityCode.Text = String.Empty
                ''End If

                strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                LoadCOAGridByCOAID(strCOAID)
            End If

            cmbSubactivity.Text = "--Select--"
            cmbCostType.Text = "--Select--"
            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"

        Else
            dgvCOA.DataSource = Nothing
        End If

        ''''
        Dim dt As New DataTable
        If cmbActCategory.Items.Count <> 0 Then
            objCOAPPT.COAID = COAId
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbActCategory.Text <> "System.Data.DataRowView" Then
                        If cmbActCategory.Text <> "" Then
                            If cmbActCategory.Text <> "--Select--" Then
                                lblCategoryAct.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblCategoryAct.Text = String.Empty
                    End If
                End If
            End If
        End If

        lblCostTypeCode.Text = String.Empty
        lblSubActivityCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbSubactivity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubactivity.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbSubactivity.SelectedIndex <> -1 Then


            If cmbSubactivity.Text <> "--Select--" Then
                cmbSubactivity_SelectedIndexChanged()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmbSubactivity_SelectedIndexChanged()
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG
        If cmbSubactivity.Items.Count <> 0 Then
            objCOAPPT.ParentId = cmbSubactivity.SelectedValue.ToString()
        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbCostType.DataSource = dtActCategory
            cmbCostType.DisplayMember = "COADescp"
            cmbCostType.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbCostType.SelectedIndex
            cmbCostType.SelectedIndex = -1


            Dim dt1 As New DataTable
            If cmbSubactivity.Items.Count <> 0 Then
                objCOAPPT.COAID = cmbSubactivity.SelectedValue.ToString()
            End If
            If objCOAPPT.COAID <> "System.Data.DataRowView" Then
                If objCOAPPT.COAID <> "" Then
                    dt1 = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                    strCOAID = dt1.Rows(0).Item("COACode").ToString()
                    LoadCOAGridByCOAID(strCOAID)
                    txtOldAccountCode.Text = String.Empty
                End If

            End If



            If intRowCount >= 0 Then
                'If cmbCostType.Text <> String.Empty Then
                '    lblCostTypeCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                'Else
                '    lblCostTypeCode.Text = String.Empty
                'End If

                'strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                'LoadCOAGridByCOAID(strCOAID)
            End If
            cmbCostType.SelectedIndex = -1
            cmbCostCategory.SelectedIndex = -1
            cmbDetailCost.SelectedIndex = -1

            cmbCostType.Text = "--Select--"
            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"
        Else
            cmbCostType.DataSource = Nothing
            cmbCostCategory.DataSource = Nothing
            cmbDetailCost.DataSource = Nothing
            dgvCOA.DataSource = Nothing
        End If
        ''''
        Dim dt As New DataTable
        If cmbSubactivity.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbSubactivity.SelectedValue.ToString()
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbSubactivity.Text <> "System.Data.DataRowView" Then
                        If cmbSubactivity.Text <> "" Then
                            If cmbSubactivity.Text <> "--Select--" Then
                                lblSubActivityCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblSubActivityCode.Text = String.Empty
                    End If
                End If
            End If

        End If

        lblCostTypeCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbSubactivity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubactivity.Leave
        ''cmbSubactivity_Leave()
    End Sub

    Private Sub cmbSubactivity_Leave()
        Dim COAId As String = String.Empty
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbSubactivity.Items.Count <> 0 Then
            objCOAPPT.COADescp = cmbSubactivity.Text
        End If
        dtActCategory = COALookupBOL.ChildCOAIDGet(objCOAPPT)
        If cmbSubactivity.Items.Count <> 0 Then
            If dtActCategory.Rows.Count > 0 Then
                If Not dtActCategory.Rows(0).Item("COAID") Is DBNull.Value Then
                    objCOAPPT.ParentId = dtActCategory.Rows(0).Item("COAID")
                    COAId = dtActCategory.Rows(0).Item("COAID")
                End If
            End If
        End If

        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbCostType.DataSource = dtActCategory
            cmbCostType.DisplayMember = "COADescp"
            cmbCostType.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbCostType.SelectedIndex
            If intRowCount >= 0 Then
                If cmbCostType.Text <> String.Empty Then
                    lblCostTypeCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                Else
                    lblCostTypeCode.Text = String.Empty
                End If

                strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                LoadCOAGridByCOAID(strCOAID)
            End If

            cmbCostType.Text = "--Select--"
            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"
        Else
            dgvCOA.DataSource = Nothing
        End If
        ''''
        Dim dt As New DataTable
        If cmbSubactivity.Items.Count <> 0 Then
            objCOAPPT.COAID = COAId
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbSubactivity.Text <> "System.Data.DataRowView" Then
                        If cmbSubactivity.Text <> "" Then
                            If cmbSubactivity.Text <> "--Select--" Then
                                lblSubActivityCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblSubActivityCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        lblCostTypeCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbCostType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostType.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbCostType.SelectedIndex <> -1 Then


            If cmbCostType.Text <> "--Select--" Then
                cmbCostType_SelectedIndexChanged()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmbCostType_SelectedIndexChanged()
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbCostType.Items.Count <> 0 Then
            objCOAPPT.ParentId = cmbCostType.SelectedValue.ToString()
        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbCostCategory.DataSource = dtActCategory
            cmbCostCategory.DisplayMember = "COADescp"
            cmbCostCategory.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbCostCategory.SelectedIndex
            cmbCostCategory.SelectedIndex = -1

            Dim dt1 As New DataTable
            If cmbCostType.Items.Count <> 0 Then
                objCOAPPT.COAID = cmbCostType.SelectedValue.ToString()
            End If
            If objCOAPPT.COAID <> "System.Data.DataRowView" Then
                If objCOAPPT.COAID <> "" Then
                    dt1 = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                    strCOAID = dt1.Rows(0).Item("COACode").ToString()
                    LoadCOAGridByCOAID(strCOAID)
                    txtOldAccountCode.Text = String.Empty
                End If

            End If

            'If intRowCount >= 0 Then
            '    ''If cmbCostCategory.Text <> String.Empty Then
            '    ''    lblCostcategoryCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
            '    ''Else
            '    ''    lblCostcategoryCode.Text = String.Empty
            '    ''End If

            '    strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
            '    LoadCOAGridByCOAID(strCOAID)

            'End If

            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"

         
            cmbCostCategory.SelectedIndex = -1
            cmbDetailCost.SelectedIndex = -1

        Else
            cmbCostCategory.DataSource = Nothing
            cmbDetailCost.DataSource = Nothing
            dgvCOA.DataSource = Nothing
        End If

        ''''
        Dim dt As New DataTable
        If cmbCostType.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbCostType.SelectedValue.ToString()
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbCostType.Text <> "System.Data.DataRowView" Then
                        If cmbCostType.Text <> "" Then
                            If cmbCostType.Text <> "--Select--" Then
                                lblCostTypeCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblCostTypeCode.Text = String.Empty
                    End If
                End If
            End If


        End If

        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbCostType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostType.Leave
        ''cmbCostType_Leave()
    End Sub

    Private Sub cmbCostType_Leave()
        Dim COAId As String = String.Empty
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbCostType.Items.Count <> 0 Then
            objCOAPPT.COADescp = cmbCostType.Text
        End If
        dtActCategory = COALookupBOL.ChildCOAIDGet(objCOAPPT)
        If cmbCostType.Items.Count <> 0 Then
            If dtActCategory.Rows.Count > 0 Then
                If Not dtActCategory.Rows(0).Item("COAID") Is DBNull.Value Then
                    objCOAPPT.ParentId = dtActCategory.Rows(0).Item("COAID")
                    COAId = dtActCategory.Rows(0).Item("COAID")
                End If
            End If

        End If

        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbCostCategory.DataSource = dtActCategory
            cmbCostCategory.DisplayMember = "COADescp"
            cmbCostCategory.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbCostCategory.SelectedIndex
            If intRowCount >= 0 Then
                ''If cmbCostCategory.Text <> String.Empty Then
                ''    lblCostcategoryCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                ''Else
                ''    lblCostcategoryCode.Text = String.Empty
                ''End If

                strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                LoadCOAGridByCOAID(strCOAID)

            End If

            cmbCostCategory.Text = "--Select--"
            cmbDetailCost.Text = "--Select--"
        Else
            dgvCOA.DataSource = Nothing
        End If

        ''''
        Dim dt As New DataTable
        If cmbCostType.Items.Count <> 0 Then
            objCOAPPT.COAID = COAId
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbCostType.Text <> "System.Data.DataRowView" Then
                        If cmbCostType.Text <> "" Then
                            If cmbCostType.Text <> "--Select--" Then
                                lblCostTypeCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblCostTypeCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbCostCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostCategory.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbCostCategory.SelectedIndex <> -1 Then


            If cmbCostCategory.Text <> "--Select--" Then
                cmbCostCategory_SelectedIndexChanged()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmbCostCategory_SelectedIndexChanged()
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbCostCategory.Items.Count <> 0 Then
            objCOAPPT.ParentId = cmbCostCategory.SelectedValue.ToString()
        End If
        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbDetailCost.DataSource = dtActCategory
            cmbDetailCost.DisplayMember = "COADescp"
            cmbDetailCost.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbDetailCost.SelectedIndex
            cmbDetailCost.SelectedIndex = -1


            Dim dt1 As New DataTable
            If cmbCostCategory.Items.Count <> 0 Then
                objCOAPPT.COAID = cmbCostCategory.SelectedValue.ToString()
            End If
            If objCOAPPT.COAID <> "System.Data.DataRowView" Then
                If objCOAPPT.COAID <> "" Then
                    dt1 = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                    strCOAID = dt1.Rows(0).Item("COACode").ToString()
                    LoadCOAGridByCOAID(strCOAID)
                    txtOldAccountCode.Text = String.Empty
                End If

            End If

            'If intRowCount >= 0 Then
            '    If cmbDetailCost.Text <> String.Empty Then
            '        lblDetailCostCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
            '    Else
            '        lblDetailCostCode.Text = String.Empty
            '    End If

            '    strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
            '    LoadCOAGridByCOAID(strCOAID)

            'End If
          
            cmbDetailCost.SelectedIndex = -1
            cmbDetailCost.Text = "--Select--"
        Else
            cmbDetailCost.DataSource = Nothing
            dgvCOA.DataSource = Nothing
        End If

        ''''
        Dim dt As New DataTable
        If cmbCostCategory.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbCostCategory.SelectedValue.ToString()
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbCostCategory.Text <> "System.Data.DataRowView" Then
                        If cmbCostCategory.Text <> "" Then
                            If cmbCostCategory.Text <> "--Select--" Then
                                lblCostcategoryCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblCostcategoryCode.Text = String.Empty
                    End If
                End If
            End If


        End If

        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbCostCategory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostCategory.Leave
        ''cmbCostCategory_Leave()
    End Sub

    Private Sub cmbCostCategory_Leave()
        Dim COAID As String = String.Empty
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbCostCategory.Items.Count <> 0 Then
            objCOAPPT.COADescp = cmbCostCategory.Text
        End If
        dtActCategory = COALookupBOL.ChildCOAIDGet(objCOAPPT)
        If cmbCostCategory.Items.Count <> 0 Then
            If dtActCategory.Rows.Count > 0 Then
                If Not dtActCategory.Rows(0).Item("COAID") Is DBNull.Value Then
                    objCOAPPT.ParentId = dtActCategory.Rows(0).Item("COAID")
                    COAID = dtActCategory.Rows(0).Item("COAID")
                End If
            End If

        End If

        If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
            dtActCategory = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        End If
        If dtActCategory.Rows.Count <> 0 Then
            cmbDetailCost.DataSource = dtActCategory
            cmbDetailCost.DisplayMember = "COADescp"
            cmbDetailCost.ValueMember = "COAID"
            Dim intRowCount As Integer
            intRowCount = cmbDetailCost.SelectedIndex
            If intRowCount >= 0 Then
                If cmbDetailCost.Text <> String.Empty Then
                    lblDetailCostCode.Text = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                Else
                    lblDetailCostCode.Text = String.Empty
                End If

                strCOAID = dtActCategory.Rows(intRowCount).Item("COACode").ToString()
                LoadCOAGridByCOAID(strCOAID)

            End If
            cmbDetailCost.Text = "--Select--"
        Else
            dgvCOA.DataSource = Nothing
        End If

        ''''
        Dim dt As New DataTable
        If cmbCostCategory.Items.Count <> 0 Then
            objCOAPPT.COAID = COAID
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbCostCategory.Text <> "System.Data.DataRowView" Then
                        If cmbCostCategory.Text <> "" Then
                            If cmbCostCategory.Text <> "--Select--" Then
                                lblCostcategoryCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblCostcategoryCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        lblDetailCostCode.Text = String.Empty

        ''''
    End Sub

    Private Sub cmbDetailCost_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetailCost.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        If cmbDetailCost.SelectedIndex <> -1 Then

            If cmbDetailCost.Text <> "--Select--" Then
                cmbDetailCost_SelectedIndexChanged()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmbDetailCost_SelectedIndexChanged()
        'FYI: cmbDetailCost Dropdown changed by Siva.S
        Dim dtDetailCost As New DataTable
        Dim objCOAPPT As New COALookupPPT()
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        'If cmbDetailCost.Items.Count <> 0 Then
        '    objCOAPPT.ParentId = cmbDetailCost.SelectedValue.ToString()
        'End If
        'If objCOAPPT.ParentId <> "System.Data.DataRowView" Or objCOAPPT.ParentId <> "" Then
        '    dtDetailCost = Accounts_BOL.COALookupBOL.SelectAllChildCOA(objCOAPPT)
        'End If
        'If dtDetailCost.Rows.Count <> 0 Then

        '    Dim intRowCount As Integer
        '    intRowCount = cmbDetailCost.SelectedIndex
        '    If intRowCount >= 0 Then
        '        If cmbDetailCost.Text <> String.Empty Then
        '            lblDetailCostCode.Text = dtDetailCost.Rows(intRowCount).Item("COACode").ToString()
        '        Else
        '            lblDetailCostCode.Text = String.Empty
        '        End If

        '        strCOAID = dtDetailCost.Rows(intRowCount).Item("COACode").ToString()
        '        LoadCOAGridByCOAID(strCOAID)

        '    End If
        'Else
        '    dgvCOA.DataSource = Nothing
        'End If


        ''''

        'Dim dt As New DataTable
        'If cmbCostCategory.Items.Count <> 0 Then
        '    objCOAPPT.COAID = cmbDetailCost.SelectedValue.ToString()
        'End If



        Dim dt1 As New DataTable
        If cmbDetailCost.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbDetailCost.SelectedValue.ToString()
        End If
        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt1 = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                strCOAID = dt1.Rows(0).Item("COACode").ToString()
                LoadCOAGridByCOAID(strCOAID)
                txtOldAccountCode.Text = String.Empty
            End If

        End If



        Dim dt As New DataTable
        If cmbCostCategory.Items.Count <> 0 Then
            objCOAPPT.COAID = cmbDetailCost.SelectedValue.ToString()
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbDetailCost.Text <> "System.Data.DataRowView" Then
                        If cmbDetailCost.Text <> "" Then
                            If cmbDetailCost.Text <> "--Select--" Then
                                lblDetailCostCode.Text = dt.Rows(0).Item("COACode").ToString()
                                'strCOAID = dt.Rows(0).Item("COACode").ToString()
                                'LoadCOAGridByCOAID(strCOAID)
                            End If
                        End If
                    Else
                        lblDetailCostCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        ''''
    End Sub

    Private Sub cmbDetailCost_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetailCost.Leave
        ''cmbDetailCost_Leave()
    End Sub


    Private Sub cmbDetailCost_Leave()
        Dim COAID As String = String.Empty
        Dim dtActCategory As New DataTable
        Dim objCOAPPT As New COALookupPPT()

        ''''
        Dim dt As New DataTable
        objCOAPPT.ExpenditureAG = strAcctExpenditureAG

        If cmbCostCategory.Items.Count <> 0 Then
            objCOAPPT.COADescp = cmbCostCategory.Text
        End If
        dtActCategory = COALookupBOL.ChildCOAIDGet(objCOAPPT)
        If cmbCostCategory.Items.Count <> 0 Then
            If dtActCategory.Rows.Count > 0 Then
                If Not dtActCategory.Rows(0).Item("COAID") Is DBNull.Value Then
                    objCOAPPT.ParentId = dtActCategory.Rows(0).Item("COAID")
                    COAID = dtActCategory.Rows(0).Item("COAID")
                    objCOAPPT.COAID = COAID
                End If
            End If
        End If

        If objCOAPPT.COAID <> "System.Data.DataRowView" Then
            If objCOAPPT.COAID <> "" Then
                dt = Accounts_BOL.COALookupBOL.ChildCOACodeGet(objCOAPPT)
                If dt.Rows.Count > 0 Then
                    If cmbDetailCost.Text <> "System.Data.DataRowView" Then
                        If cmbDetailCost.Text <> "" Then
                            If cmbDetailCost.Text <> "--Select--" Then
                                lblDetailCostCode.Text = dt.Rows(0).Item("COACode").ToString()
                            End If
                        End If
                    Else
                        lblDetailCostCode.Text = String.Empty
                    End If
                End If
            End If
        End If

        ''''
    End Sub

    Private Sub dgvCOA_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCOA.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub Grid_Click()

        If Not dgvCOA.CurrentRow.Cells("COACode").Value Is DBNull.Value Then
            strAcctcode = dgvCOA.CurrentRow.Cells("COACode").Value.ToString()
        Else
            strAcctcode = String.Empty
        End If
        If Not dgvCOA.CurrentRow.Cells("COADescp").Value Is DBNull.Value Then
            strAcctDescp = dgvCOA.CurrentRow.Cells("COADescp").Value.ToString()
        Else
            strAcctDescp = String.Empty
        End If

        If Not dgvCOA.CurrentRow.Cells("COAID").Value Is DBNull.Value Then
            strAcctId = dgvCOA.CurrentRow.Cells("COAID").Value.ToString()
        Else
            strAcctId = String.Empty
        End If
        If Not dgvCOA.CurrentRow.Cells("ExpenditureAG").Value Is DBNull.Value Then
            strAcctExpenditureAG = dgvCOA.CurrentRow.Cells("ExpenditureAG").Value.ToString()
        Else
            strAcctExpenditureAG = String.Empty
        End If
        If Not dgvCOA.CurrentRow.Cells("OldCOACode").Value Is DBNull.Value Then
            strOldAccountCode = dgvCOA.CurrentRow.Cells("OldCOACode").Value.ToString()
        Else
            strOldAccountCode = String.Empty
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub ClearCombo()

        lblMainActivityCode.Text = String.Empty
        lblCategoryAct.Text = String.Empty
        lblSubActivityCode.Text = String.Empty
        lblCostTypeCode.Text = String.Empty
        lblCostcategoryCode.Text = String.Empty
        lblDetailCostCode.Text = String.Empty
        cmbMainActivity.Text = "--Select--"
        cmbActCategory.Text = "--Select--"
        cmbSubactivity.Text = "--Select--"
        cmbCostType.Text = "--Select--"
        cmbCostCategory.Text = "--Select--"
        cmbDetailCost.Text = "--Select--"

    End Sub

    Private Sub btnCOASearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCOASearch.Click
        Me.Cursor = Cursors.WaitCursor
        If txtOldAccountCode.Text.Trim() <> String.Empty Then

            ClearCombo()
            LoadCOAGridByOldCOACode()

        ElseIf strCOAID = "" Or strCOAID = String.Empty Then

            LoadCOAGrid()

        ElseIf cmbMainActivity.Text = "--Select--" Or cmbMainActivity.Text = String.Empty Then

            ClearCombo()
            LoadCOAGrid()

        Else

            LoadCOAGridByCOAID(strCOAID)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCOA_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCOA.CellClick

        Try
            If dgvCOA.SelectedRows(0).Cells("COADescp").Value.ToString() <> String.Empty Then
                cmbDetailCost.Text = dgvCOA.SelectedRows(0).Cells("COADescp").Value.ToString()
                txtOldAccountCode.Text = dgvCOA.SelectedRows(0).Cells("OldCOACode").Value.ToString()
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(COALookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
            lblMainActivity.Text = rm.GetString("lblMainActivity.Text")
            lblMainActivityCode.Text = rm.GetString("lblMainActivityCode.Text")
            lblActivityCategory.Text = rm.GetString("lblActivityCategory.Text")
            lblCategoryAct.Text = rm.GetString("lblCategoryAct.Text")
            lblSubActivity.Text = rm.GetString("lblSubActivity.Text")
            lblSubActivityCode.Text = rm.GetString("lblSubActivityCode.Text")
            lblCostType.Text = rm.GetString("lblCostType.Text")
            lblCostTypeCode.Text = rm.GetString("lblCostTypeCode.Text")
            lblCostCategory.Text = rm.GetString("lblCostCategory.Text")
            lblCostcategoryCode.Text = rm.GetString("lblCostcategoryCode.Text")
            lblDetailCost.Text = rm.GetString("lblDetailCost.Text")
            lblDetailCostCode.Text = rm.GetString("lblDetailCostCode.Text")

            dgvCOA.Columns("COACode").HeaderText = rm.GetString("dgIssueVoucher.Columns(COACode).HeaderText")
            dgvCOA.Columns("COADescp").HeaderText = rm.GetString("dgIssueVoucher.Columns(COADescp).HeaderText")
            dgvCOA.Columns("AccountType").HeaderText = rm.GetString("dgIssueVoucher.Columns(AccountType).HeaderText")
            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtOldAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOldAccountCode.Leave

        If txtOldAccountCode.Text.Trim() <> String.Empty Then
            LoadCOAGridByOldCOACode()
        End If

    End Sub

    Private Sub LoadCOAGridByOldCOACode()

        If txtOldAccountCode.Text.Trim() <> String.Empty Then

            strOldAccountCode = txtOldAccountCode.Text.Trim()
            Dim dtCOA As New DataTable()
            Dim objCOAPPT As New COALookupPPT()
            objCOAPPT.ExpenditureAG = strAcctExpenditureAG

            objCOAPPT.OldCOACode = strOldAccountCode
            dtCOA = Accounts_BOL.COALookupBOL.COALookUpGridFillByOLDCOACode(objCOAPPT)
            If dtCOA.Rows.Count <> 0 Then
                dgvCOA.AutoGenerateColumns = False
                lblNoRecord.Visible = False
                dgvCOA.DataSource = dtCOA
            Else
                dgvCOA.AutoGenerateColumns = False
                lblNoRecord.Visible = True
                dgvCOA.DataSource = dtCOA
            End If

        End If

    End Sub

    Private Sub COALookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    ''Private Sub dgvCOA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCOA.KeyDown

    ''    If e.KeyCode = Keys.Return Then
    ''        Grid_Click()
    ''        e.Handled = True
    ''    End If



    ''    If e.KeyValue = 40 Then
    ''        GlobalBOL.KeyDownEvent(dgvCOA, e)
    ''    End If
    ''    'If e.KeyValue = 38 Then
    ''    '    GlobalBOL.KeyDownEvent(dgvCOA, e)
    ''    'End If
    ''End Sub

    ''Private Sub dgvCOA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCOA.KeyUp

    ''    ''If e.KeyValue = 38 Then
    ''    ''    GlobalBOL.KeyUpEvent(dgvCOA, e)
    ''    ''End If
    ''    If e.KeyValue = 38 Then
    ''        If dgvCOA.SelectedRows.Count = 0 Then
    ''            dgvCOA.Rows(0).Selected = True
    ''        Else
    ''            If dgvCOA.SelectedRows(0).Index < (dgvCOA.Rows.Count + 1) Then
    ''                Dim intSelectedIndex As Integer = dgvCOA.SelectedRows(0).Index
    ''                dgvCOA.ClearSelection()

    ''                If intSelectedIndex > 0 Then
    ''                    dgvCOA.Rows(intSelectedIndex - 1).Selected = True
    ''                End If
    ''            End If
    ''        End If
    ''    End If

    ''End Sub

    Private Sub dgvCOA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCOA.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
            e.Handled = True
        End If


    End Sub
End Class