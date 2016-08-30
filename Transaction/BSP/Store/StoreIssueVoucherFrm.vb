Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Math

Public Class StoreIssueVoucherFrm

    'Public psSIVStockID As String = String.Empty
    Public psExistingStockCode As String = String.Empty
    Public psExistingAccountCode As String = String.Empty
    Public psExistingBlockName As String = String.Empty
    Public psExistingDiv As String = String.Empty
    Public psExistingVHNo As String = String.Empty
    Public psExistingVHDetailsCostCode As String = String.Empty
    Public psExistingStationCode As String = String.Empty

    Public psLedgerID As String = String.Empty
    Public psLedgerNo As String = String.Empty
    Public psLedgerType As String = String.Empty
    Public psSIVIssueBatchID As String = String.Empty
    Public Shared psSIVSTIssueId As String = String.Empty
    Public psSIVSTIssueDetailsId As String = String.Empty
    Public psSIVAccountID As String = String.Empty
    Public psSIVOldAccountID As String = String.Empty
    Public psSIVContractNo As String = String.Empty
    Public psSIVContractId As String = String.Empty
    Public psSIVStockCategory As String = String.Empty
    Public psSIVStockCategoryID As String = String.Empty
    Public Shared psSIVStockCategoryIDForStock As String = String.Empty
    Public psSIVStockCategoryCode As String = String.Empty
    Public Shared psSIVStockCOAID As String = String.Empty
    Public Shared psSIVVarianceCOAID As String = String.Empty
    Public psSIVStockCode As String = String.Empty
    Public psSIVStockID As String = String.Empty
    Public psSIVStockDesc As String = String.Empty
    Public psSIVUnitprice As String = String.Empty
    Public psSIVUnit As String = String.Empty
    Public psSIVDivID As String = String.Empty
    Public psSIVYopID As String = String.Empty
    Public psSIVBlockID As String = String.Empty
    Public psSIVPlantedHect As String = String.Empty
    Public psSIVT0analysisID As String = String.Empty
    Public psSIVT1analysisID As String = String.Empty
    Public psSIVT2analysisID As String = String.Empty
    Public psSIVT3analysisID As String = String.Empty
    Public psSIVT4analysisID As String = String.Empty
    Public psSIVStationID As String = String.Empty

    Public psSIVVHID As String = String.Empty
    Public psSIVVHCategoryID As String = String.Empty
    Public psSIVVHType As String = String.Empty

    Public psSIVVHDetailsCostCodeId As String = String.Empty
    'Public psSIVVHDetCostCodType As String = String.Empty

    'Public Shared GlobalPPT.psEstateType As String = String.Empty
    Public psStockCOAID As String = String.Empty
    Public psVarianceCOAID As String = String.Empty

    Dim dtSIVAdd As New DataTable("todgvSIVAdd")
    Dim columnSIVAdd As DataColumn
    Dim rowSIVAdd As DataRow
    Public dtAddFlag As Boolean = False
    Public btnAddFlag As Boolean = True

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim oneDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")

    Public psIssueIDVal As String = String.Empty
    Public psContractidVal As String = String.Empty
    Public psRemarksVal As String = String.Empty
    Public dateVal As DateTime
    Public psSivnumberVal As String = String.Empty
    Public psStatusVal As String = String.Empty
    Public psMenuID As String = String.Empty
    Public Shared StrFrmName As String = String.Empty
    Dim lsVDExpenditureAG As String = String.Empty
    Shadows mdiparent As New MDIParent
    Dim bDelAllFlag As Boolean = False

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreIssueVoucherFrm))

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Public lSTIssueDetailsId As String = String.Empty


    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreIssueVoucherFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub StoreIssueVoucher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        Dim frm As New StoreIssueVoucherApprovalFrm
        'Dim mdiparent As New MDIParent
        psMenuID = mdiparent.strMenuID
        If psMenuID = "M6" Then
            'fillComboSIVNo()
            'cmbSIVNO.Text = "--Select SIV No--"
            Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.dtpSIVDate)
            FormatDateTimePicker(dtpSIVDate)
            StationEnableAndDisable() 'Enable Station text Box and Look up if Estate type is Mill
            cmbStatusSearch.Text = cmbStatusSearch.Items(1) 'For Default OPEN
            tbStoreIssueVoucher.SelectedTab = tbpgViewSIV '' For selecting the view tab default
            BindViewIssueVoucher()
        ElseIf psMenuID = "M15" Then
            tbStoreIssueVoucher.SelectedTab = tbpgAdd
            tbStoreIssueVoucher.TabPages.Remove(tbpgViewSIV)
            txtSIVNo.Text = psSivnumberVal
            fillIssueBtachTotalValueDs(psSivnumberVal)
            DisableFieldsOnApproved()
            ''//Remove tab page
            ''tabControl1.TabPages.Remove(tabPage2);
            ''//Insert at index 1
            ''tabControl1.TabPages.Insert(1, tabPage2);
        End If
        txtT0.Text = Helper.T0Default(0)
        lblT0Name.Text = Helper.T0Default(1)
        psSIVT0analysisID = GetTAnalysisID(txtT0.Text)
    End Sub
    Private Function GetTAnalysisID(ByVal TName As String)
        ' Selasa, 17 Nov 2009, 17:37
        Dim DT As DataTable

        ' Set default value utk TAnalysis 0 yaitu EstateCode nya
        DT = Store_DAL.StoreIssueVoucherDAL.TAnalysis_CRTAnalisysSelect(
             "", "T0", GlobalPPT.strEstateCode)

        If DT.Rows.Count <> 0 Then
            'txtT0.Text = DT.Rows(0).Item("TValue").ToString()
            GetTAnalysisID = DT.Rows(0).Item("TAnalysisID").ToString()
            'lblTAnalysisDescp_T0.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()
        Else
            GetTAnalysisID = ""
        End If

    End Function
    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreIssueVoucherFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tbStoreIssueVoucher.TabPages("tbpgAdd").Text = rm.GetString("tbStoreIssueVoucher.TabPages(tbpgAdd).Text")
            tbStoreIssueVoucher.TabPages("tbpgViewSIV").Text = rm.GetString("tbStoreIssueVoucher.TabPages(tbpgViewSIV).Text")

            'Add Tab Controls
            grpSIV.Text = rm.GetString("grpSIV.Text")
            grpStoreIssueVoucher.Text = rm.GetString("grpStoreIssueVoucher.Text")

            lblSIVNO.Text = rm.GetString("llblSIVNO.Text")
            lblSIVDate.Text = rm.GetString("lblSIVDate.Text")
            lblContractor.Text = rm.GetString("lblContractor.Text")
            lblIssueBatchTotal.Text = rm.GetString("lblIssueBatchTotal.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblStoreIssueStatus.Text = rm.GetString("lblStoreIssueStatus.Text")
            lblStockCategory.Text = rm.GetString("lblStockCategory.Text")
            lblStockCode.Text = rm.GetString("lblStockCode.Text")
            lblDescription.Text = rm.GetString("lblStockDescription.Text")
            lblUOM.Text = rm.GetString("lblUOM.Text")
            lblAvailQty.Text = rm.GetString("lblAvailQty.Text")
            lblQuantityIssued.Text = rm.GetString("lblQuantityIssued.Text")
            lblUsedFor.Text = rm.GetString("lblUsedFor.Text")
            lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
            lblOldAcctCode.Text = rm.GetString("lblOldAcctCode.Text")
            lblT0.Text = rm.GetString("lblT0.Text")
            lblT1.Text = rm.GetString("lblT1.Text")
            lblT2.Text = rm.GetString("lblT2.Text")
            lblT3.Text = rm.GetString("lblT3.Text")
            lblT4.Text = rm.GetString("lblT4.Text")
            lblDiv.Text = rm.GetString("lblDiv.Text")
            lblYOP.Text = rm.GetString("lblYOP.Text")
            lblsubBlock.Text = rm.GetString("lblsubBlock.Text")
            lblStation.Text = rm.GetString("lblStation.Text")
            lblVHNo.Text = rm.GetString("lblVHNo.Text")
            lblOdoReading.Text = rm.GetString("lblOdoReading.Text")
            lblVHDetailsCostCode.Text = rm.GetString("lblVHDetailsCostCode.Text")
            LblQtyIssue.Text = rm.GetString("LblQtyIssue.Text")
            lblRejectedReason1.Text = rm.GetString("lblRejectedReason1.Text")
            dgIssueVoucher.Columns("dgclStockCode").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclStockCode).HeaderText")
            dgIssueVoucher.Columns("dgclDesc").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclDesc).HeaderText")
            dgIssueVoucher.Columns("dgclUnit").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclUnit).HeaderText")
            dgIssueVoucher.Columns("dgclAvailQty").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclAvailQty).HeaderText")
            dgIssueVoucher.Columns("dgclMinQty").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclMinQty).HeaderText")
            dgIssueVoucher.Columns("dgclIssuedQty").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclIssuedQty).HeaderText")
            dgIssueVoucher.Columns("dgclUsedFor").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclUsedFor).HeaderText")
            dgIssueVoucher.Columns("dgclAccountCode").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclAccountCode).HeaderText")
            dgIssueVoucher.Columns("dgclT0").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclT0).HeaderText")
            dgIssueVoucher.Columns("dgclT1").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclT1).HeaderText")
            dgIssueVoucher.Columns("dgclT2").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclT2).HeaderText")
            dgIssueVoucher.Columns("dgclT3").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclT3).HeaderText")
            dgIssueVoucher.Columns("dgclT4").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclT4).HeaderText")
            dgIssueVoucher.Columns("dgclDiv").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclDiv).HeaderText")
            dgIssueVoucher.Columns("dgclYOP").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclYOP).HeaderText")
            dgIssueVoucher.Columns("dgclSubBlock").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclSubBlock).HeaderText")
            dgIssueVoucher.Columns("dgclStation").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclStation).HeaderText")
            dgIssueVoucher.Columns("dgclVHNo").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclVHNo).HeaderText")
            dgIssueVoucher.Columns("dgclOdoReading").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclOdoReading).HeaderText")
            dgIssueVoucher.Columns("dgclVHDetailCostCode").HeaderText = rm.GetString("dgIssueVoucher.Columns(dgclVHDetailCostCode).HeaderText")

            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnPrint.Text = rm.GetString("btnPrint.Text")

            'View Tab Controls
            PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText") 'lblSearchBy
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")
            chkViewSIVDate.Text = rm.GetString("chkViewSIVDate.Text")
            lblSIVNoSerach.Text = rm.GetString("lblSIVNoSerach.Text")
            lblContractNoSearch.Text = rm.GetString("lblContractNoSearch.Text")
            'lblRemarksSearch.Text = rm.GetString("lblRemarksSearch.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")

            dgViewIssueVoucher.Columns("SIVNO").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(SIVNO).HeaderText")
            dgViewIssueVoucher.Columns("SIVDate").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(SIVDate).HeaderText")
            dgViewIssueVoucher.Columns("Status").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(Status).HeaderText")
            dgViewIssueVoucher.Columns("ContractNo").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(ContractNo).HeaderText")
            dgViewIssueVoucher.Columns("Remarks").HeaderText = rm.GetString("dgViewIssueVoucher.Columns(Remarks).HeaderText")

            lblStatusApproval.Text = rm.GetString("lblStatusApproval.text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
            grpApproval.Text = rm.GetString("grpApproval.Text")
            btnConform.Text = rm.GetString("btnConform.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub StationEnableAndDisable()

        'Dim GlobalPPT.psEstateType As String
        ''GlobalPPT.psEstateType = GlobalBOL.EstateTypeSelect()
        'If GlobalPPT.psEstateType .psEstateType = "M" Then
        '    txtStation.Enabled = True
        '    lblStation.Enabled = True
        '    btnSearchStation.Enabled = True
        '    txtSubBlock.Enabled = False
        '    lblSubBlockName.Enabled = False
        '    btnSearchSubBlock.Enabled = False
        '    txtDiv.Enabled = False
        '    lblDivName.Enabled = False
        '    txtYOP.Enabled = False
        '    lblYOPName.Enabled = False
        'End If

        If GlobalPPT.psEstateType = "M" Then
            txtStation.Enabled = True
            btnSearchStation.Enabled = True
            txtSubBlock.Enabled = False
            btnSearchSubBlock.Enabled = False
            txtDiv.Enabled = False
            btnSearchDiv.Enabled = False
            'txtYOP.Enabled = False
            txtSubBlock.Text = String.Empty
            lblSubBlockName.Text = String.Empty
            txtDiv.Text = String.Empty
            lblDivName.Text = String.Empty
            txtYOP.Text = String.Empty
            lblYOPName.Text = String.Empty
        Else
            txtStation.Enabled = False
            btnSearchStation.Enabled = False
            txtSubBlock.Enabled = True
            btnSearchSubBlock.Enabled = True
            txtDiv.Enabled = True
            btnSearchDiv.Enabled = True
            'txtYOP.Enabled = True
            txtStation.Text = String.Empty
            lblStationDesc.Text = String.Empty
        End If

    End Sub

    '------------ SIV COMBO REMOVED --------------
    ''Private Sub fillComboSIVNo()
    ''    Try
    ''        'cmbSIVNO.Items.Clear()
    ''        cmbSIVNO.DataSource = Nothing
    ''        Dim dsSIVNo As DataSet
    ''        dsSIVNo = StoreIssueVoucherBOL.fillSIVNo()
    ''        cmbSIVNO.DataSource = dsSIVNo.Tables(0)
    ''        cmbSIVNO.DisplayMember = "SIVNo"
    ''        cmbSIVNO.ValueMember = "SIVNo"

    ''    Catch ex As Exception
    ''        MessageBox.Show(ex.Message)
    ''    End Try

    ''End Sub

    ''Public Sub ComboSelectedFunction()
    ''    Try
    ''        Dim ds As New DataSet
    ''        Dim objStoreIssueVoucher As New StoreIssueVoucherPPT
    ''        objStoreIssueVoucher.SIVNO = cmbSIVNO.SelectedValue
    ''        If objStoreIssueVoucher.SIVNO <> String.Empty Then
    ''            fillIssueBtachTotalValueDs(objStoreIssueVoucher.SIVNO)
    ''        End If
    ''    Catch ex As Exception
    ''    End Try
    ''End Sub

    Public Sub fillIssueBtachTotalValueDs(ByVal SIVNumber As String)

        Try
            Dim ds As New DataSet
            Dim objStoreIssueVoucher As New StoreIssueVoucherPPT
            objStoreIssueVoucher.SIVNO = SIVNumber
            ds = StoreIssueVoucherBOL.fillIssueBatchTotalDs(objStoreIssueVoucher)
            If ds.Tables(0).Rows.Count <> 0 Then
                txtIssueBatchTotal.Text = ds.Tables(0).Rows(0).Item("BatchValue")
                psSIVIssueBatchID = ds.Tables(0).Rows(0).Item("STIssueBatchID")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub ComboSelectedFunction1()

        'Dim objobjStoreIssueVoucher As New StoreIssueVoucherPPT
        'txtIssueBatchTotal.Text.Trim() = string.empty 
        'If cmbSIVNO.SelectedIndex <> -1 Then

        '    objobjStoreIssueVoucher.SIVNO = cmbSIVNO.SelectedValue.ToString()
        '    fillIssueBtachTotalValueDs()
        'Else
        '    Dim mdiparent As New MDIParent
        'If psMenuID = "M15" Then
        '        objobjStoreIssueVoucher.SIVNO = psSivnumberVal
        '        fillIssueBtachTotalValueDs()
        '    End If
        'End If

    End Sub

    'Public Sub fillIssueBtachTotalValueDs1(ByVal SIVNumber As String)
    '    Try
    '        Dim ds As New DataSet
    '        Dim objStoreIssueVoucher As New StoreIssueVoucherPPT
    '        If psMenuID = "M15" Then
    '            objStoreIssueVoucher.SIVNO = psSivnumberVal
    '        Else
    '            objStoreIssueVoucher.SIVNO = txtSIVNo.Text
    '        End If
    '        ds = StoreIssueVoucherBOL.fillIssueBatchTotalDs(objStoreIssueVoucher)
    '        If ds.Tables(0).Rows.Count <> 0 Then
    '            txtIssueBatchTotal.Text = ds.Tables(0).Rows(0).Item("BatchValue")
    '            psSIVIssueBatchID = ds.Tables(0).Rows(0).Item("STIssueBatchID")
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub CalculateQtyIssued()

        Dim ldQtyIssued As Double
        Dim GridViewRow As DataGridViewRow
        For Each GridViewRow In dgIssueVoucher.Rows
            If GridViewRow.Cells("dgclIssuedQty").Value.ToString() <> String.Empty Then
                ldQtyIssued += CDbl(GridViewRow.Cells("dgclIssuedQty").Value)
            End If
        Next
        lblQtyIssued.Text = ldQtyIssued

    End Sub

    Private Function SIVNOIsExist(ByVal SIVNO) As Boolean

        Dim ds As New DataSet
        Dim objStorePPT As New StoreIssueVoucherPPT
        objStorePPT.SIVNO = SIVNO
        ds = StoreIssueVoucherBOL.STIssueIsSIVNoExist(objStorePPT)
        If ds.Tables(0).Rows.Count > 0 Then
            Return False
            Exit Function
        Else
            Return True
        End If

    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Add_Clicked()

        'GlobalPPT.IsRetainFocus = True

    End Sub

    Private Sub Add_Clicked()

        ' If btnAdd.Text.Trim() = "Add" Then 
        If btnAddFlag = True Then
            If (IsValidFields() = False) Then
                Exit Sub
            Else

                If psIssueIDVal = String.Empty Then
                    If SIVNOIsExist(txtSIVNo.Text.Trim()) = False Then
                        'MessageBox.Show("SIV No already exists,Please choose some other SIV No")
                        DisplayInfoMessage("Msg01")
                        txtSIVNo.Focus()
                        Exit Sub
                    End If
                End If
                'If SIVNOIsExist(txtSIVNo.Text.Trim()) = False Then
                '    ''MessageBox.Show("SIV No already exists,Please choose some other SIV No")
                '    ''txtSIVNo.Focus()
                '    ''Exit Sub
                '    'Else
                SaveSIVDetail()
                CalculateQtyIssued()
                lblStatus.Text = "OPEN"
                'txtStockCategory.Enabled = True
                'btnSearchStockCategory.Enabled = True
                'txtStockCode.Enabled = True
                'btnSearchStockCode.Enabled = True
                'End If
            End If
        ElseIf btnAddFlag = False Then
            If (IsValidFields() = False) Then
                Exit Sub
            Else
                UpdateSIVDetail()
                CalculateQtyIssued()
                lblStatus.Text = "OPEN"
                'txtStockCategory.Enabled = False
                'btnSearchStockCategory.Enabled = False
                'txtStockCode.Enabled = False
                'btnSearchStockCode.Enabled = False
            End If
        End If

    End Sub

    Private Sub SaveSIVDetail()

        Dim intRowcount As Integer = dtSIVAdd.Rows.Count

        Dim objSIVPPT As New StoreIssueVoucherPPT
        With objSIVPPT
            .StockCode = Me.txtStockCode.Text.Trim()
            .STCategory = txtStockCategory.Text.Trim()
        End With
        If StockCodeExist(objSIVPPT.StockCode.Trim, txtAccountCode.Text.Trim, txtSubBlock.Text.Trim, txtDiv.Text.Trim, txtVHNo.Text.Trim, txtVHDetailsCostCode.Text.Trim, txtStation.Text.Trim) Then 'StockCode Validation,if already added in grid
            Exit Sub
        End If
        rowSIVAdd = dtSIVAdd.NewRow()
        'MessageBox.Show(dtSIVAdd.Rows.Count)
        If intRowcount = 0 And dtAddFlag = False Then 'And dtSIVAdd.Columns(1).ColumnName = "StockCategory" Then
            'Add the Data column to the datatable first time 
            columnSIVAdd = New DataColumn("StockCategory", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StockCategoryId", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StockCategoryCode", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StockCOAID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VarianceCOAID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StockId", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("UOM", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("AvailableQty", System.Type.[GetType]("System.Decimal"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("MinQty", System.Type.[GetType]("System.Decimal"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("IssuedQty", System.Type.[GetType]("System.Decimal"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("UsedFor", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("COACode", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("COAID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("COADescp", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("ExpenditureAG", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("T0Value", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T0Id", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T0Desc", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("T1Value", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T1Id", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T1Desc", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("T2Value", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T2Id", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T2Desc", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("T3Value", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T3Id", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T3Desc", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("T4Value", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T4Id", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("T4Desc", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)


            columnSIVAdd = New DataColumn("BlockId", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("BlockName", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("PlantedHect", System.Type.[GetType]("System.Decimal"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("BlockStatus", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("Div", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("DivId", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("DivName", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("YOP", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("YOPID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("Name", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("StationID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StationCode", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("StationDescp", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("VHNo", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VHDescp", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VHID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VHCategoryID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("Type", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("ODOReading", System.Type.[GetType]("System.Decimal"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("VHDetailCostCodeID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VHDetailCostCode", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VHDetailCostCodeType", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("VHDetailDescp", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            columnSIVAdd = New DataColumn("STIssueId", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)
            columnSIVAdd = New DataColumn("STIssueDetailsID", System.Type.[GetType]("System.String"))
            dtSIVAdd.Columns.Add(columnSIVAdd)

            'Assign the data row value from text box 

            If txtStockCategory.Text.Trim <> String.Empty Then
                rowSIVAdd("StockCategory") = txtStockCategory.Text.Trim()
            Else
                rowSIVAdd("StockCategory") = String.Empty
            End If
            If psSIVStockCategoryID <> String.Empty Then
                rowSIVAdd("StockCategoryId") = psSIVStockCategoryID
            Else
                rowSIVAdd("StockCategoryId") = String.Empty
            End If
            If psSIVStockCategoryCode <> String.Empty Then
                rowSIVAdd("StockCategoryCode") = psSIVStockCategoryCode
            Else
                rowSIVAdd("StockCategoryCode") = String.Empty
            End If
            If psSIVStockCOAID <> String.Empty Then
                rowSIVAdd("StockCOAID") = psSIVStockCOAID
            Else
                rowSIVAdd("StockCOAID") = String.Empty
            End If
            If psSIVVarianceCOAID <> String.Empty Then
                rowSIVAdd("VarianceCOAID") = psSIVVarianceCOAID
            Else
                rowSIVAdd("VarianceCOAID") = String.Empty
            End If

            If txtStockCode.Text.Trim <> String.Empty Then
                rowSIVAdd("StockCode") = txtStockCode.Text.ToString()
            Else
                rowSIVAdd("StockCode") = String.Empty
            End If
            If psSIVStockID <> String.Empty Then
                rowSIVAdd("StockId") = psSIVStockID
            Else
                rowSIVAdd("StockId") = String.Empty
            End If
            If lblDescription.Text.Trim <> String.Empty Then
                rowSIVAdd("StockDesc") = lblDescription.Text.Trim()
            Else
                rowSIVAdd("StockDesc") = String.Empty
            End If
            If lblUnit.Text.Trim <> String.Empty Then
                rowSIVAdd("UOM") = lblUnit.Text
            Else
                rowSIVAdd("UOM") = String.Empty
            End If
            If lblAvailableQty.Text.Trim() <> String.Empty Then
                rowSIVAdd("AvailableQty") = CDbl(lblAvailableQty.Text.Trim())
            Else
                rowSIVAdd("AvailableQty") = 0
            End If
            If lblMinQty.Text.Trim() <> String.Empty Then
                rowSIVAdd("MinQty") = CDbl(lblMinQty.Text.Trim())
            Else
                rowSIVAdd("MinQty") = 0
            End If
            If txtQtyIssued.Text.Trim() <> String.Empty Then
                rowSIVAdd("IssuedQty") = CDbl(txtQtyIssued.Text.Trim())
            Else
                rowSIVAdd("IssuedQty") = 0
            End If

            If txtUsedFor.Text.Trim() <> String.Empty Then
                rowSIVAdd("UsedFor") = txtUsedFor.Text.Trim()
            Else
                rowSIVAdd("UsedFor") = String.Empty
            End If

            If txtAccountCode.Text.Trim() <> String.Empty Then
                rowSIVAdd("COACode") = txtAccountCode.Text.Trim()
            Else
                rowSIVAdd("COACode") = String.Empty
            End If
            If psSIVAccountID <> String.Empty Then
                rowSIVAdd("COAID") = psSIVAccountID
            Else
                rowSIVAdd("COAID") = String.Empty
            End If
            If lblAccountDesc.Text.Trim <> String.Empty Then
                rowSIVAdd("COADescp") = lblAccountDesc.Text
            Else
                rowSIVAdd("COADescp") = String.Empty
            End If
            If lblOldAccountCode.Text.Trim <> String.Empty Then
                rowSIVAdd("OldCOACode") = lblOldAccountCode.Text
            Else
                rowSIVAdd("OldCOACode") = String.Empty
            End If
            If lsVDExpenditureAG.Trim <> String.Empty Then
                rowSIVAdd("ExpenditureAG") = lsVDExpenditureAG
            Else
                rowSIVAdd("ExpenditureAG") = String.Empty
            End If

            If txtT0.Text.Trim() <> String.Empty Then
                rowSIVAdd("T0Value") = txtT0.Text.Trim()
            Else
                rowSIVAdd("T0Value") = String.Empty
            End If
            If psSIVT0analysisID <> String.Empty Then
                rowSIVAdd("T0Id") = psSIVT0analysisID
            Else
                rowSIVAdd("T0Id") = String.Empty
            End If
            If lblT0Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T0Desc") = lblT0Name.Text.Trim()
            Else
                rowSIVAdd("T0Desc") = String.Empty
            End If

            If txtT1.Text.Trim() <> String.Empty Then
                rowSIVAdd("T1Value") = txtT1.Text.Trim()
            Else
                rowSIVAdd("T1Value") = String.Empty
            End If
            If psSIVT1analysisID <> String.Empty Then
                rowSIVAdd("T1Id") = psSIVT1analysisID
            Else
                rowSIVAdd("T1Id") = String.Empty
            End If
            If lblT1Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T1Desc") = lblT1Name.Text.Trim()
            Else
                rowSIVAdd("T1Desc") = String.Empty
            End If


            If txtT2.Text.Trim() <> String.Empty Then
                rowSIVAdd("T2Value") = txtT2.Text.Trim()
            Else
                rowSIVAdd("T2Value") = String.Empty
            End If
            If psSIVT2analysisID <> String.Empty Then
                rowSIVAdd("T2Id") = psSIVT2analysisID
            Else
                rowSIVAdd("T2Id") = String.Empty
            End If
            If lblT2Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T2Desc") = lblT2Name.Text.Trim()
            Else
                rowSIVAdd("T2Desc") = String.Empty
            End If

            If txtT3.Text.Trim() <> String.Empty Then
                rowSIVAdd("T3Value") = txtT3.Text.Trim()
            Else
                rowSIVAdd("T3Value") = String.Empty
            End If
            If psSIVT3analysisID <> String.Empty Then
                rowSIVAdd("T3Id") = psSIVT3analysisID
            Else
                rowSIVAdd("T3Id") = String.Empty
            End If
            If lblT3Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T3Desc") = lblT3Name.Text.Trim()
            Else
                rowSIVAdd("T3Desc") = String.Empty
            End If

            If txtT4.Text.Trim() <> String.Empty Then
                rowSIVAdd("T4Value") = txtT4.Text.Trim()
            Else
                rowSIVAdd("T4Value") = String.Empty
            End If
            If psSIVT4analysisID <> String.Empty Then
                rowSIVAdd("T4Id") = psSIVT4analysisID
            Else
                rowSIVAdd("T4Id") = String.Empty
            End If
            If lblT4Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T4Desc") = lblT4Name.Text.Trim()
            Else
                rowSIVAdd("T4Desc") = String.Empty
            End If

            If psSIVBlockID <> String.Empty Then
                rowSIVAdd("BlockId") = psSIVBlockID
            Else
                rowSIVAdd("BlockId") = String.Empty
            End If
            If txtSubBlock.Text.Trim() <> String.Empty Then
                rowSIVAdd("BlockName") = txtSubBlock.Text.Trim()
            Else
                rowSIVAdd("BlockName") = String.Empty
            End If

            If psSIVPlantedHect <> String.Empty Then
                rowSIVAdd("PlantedHect") = CDbl(psSIVPlantedHect)
            Else
                rowSIVAdd("PlantedHect") = 0
            End If
            If lblSubBlockName.Text.Trim() <> String.Empty Then
                rowSIVAdd("BlockStatus") = lblSubBlockName.Text.Trim()
            Else
                rowSIVAdd("BlockStatus") = String.Empty
            End If

            If txtDiv.Text.Trim() <> String.Empty Then
                rowSIVAdd("Div") = txtDiv.Text.Trim()
            Else
                rowSIVAdd("Div") = String.Empty
            End If
            If lblDivName.Text.Trim() <> String.Empty Then
                rowSIVAdd("DivName") = lblDivName.Text.Trim()
            Else
                rowSIVAdd("DivName") = String.Empty
            End If
            If psSIVDivID <> String.Empty Then
                rowSIVAdd("DivId") = psSIVDivID
            Else
                rowSIVAdd("DivId") = String.Empty
            End If

            If txtYOP.Text.Trim() <> String.Empty Then
                rowSIVAdd("YOP") = txtYOP.Text.Trim()
            Else
                rowSIVAdd("YOP") = String.Empty
            End If
            If psSIVYopID <> String.Empty Then
                rowSIVAdd("YOPID") = psSIVYopID
            Else
                rowSIVAdd("YOPID") = String.Empty
            End If
            If lblYOPName.Text.Trim() <> String.Empty Then
                rowSIVAdd("Name") = lblYOPName.Text.Trim()
            Else
                rowSIVAdd("Name") = String.Empty
            End If

            If psSIVStationID <> String.Empty Then
                rowSIVAdd("StationID") = psSIVStationID
            Else
                rowSIVAdd("StationID") = String.Empty
            End If
            If txtStation.Text.Trim() <> String.Empty Then
                rowSIVAdd("StationCode") = txtStation.Text.Trim()
            Else
                rowSIVAdd("StationCode") = String.Empty
            End If
            If lblStationDesc.Text.Trim() <> String.Empty Then
                rowSIVAdd("StationDescp") = lblStationDesc.Text.Trim()
            Else
                rowSIVAdd("StationDescp") = lblStationDesc.Text.Trim()
            End If

            If txtVHNo.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHNo") = txtVHNo.Text.Trim()
            Else
                rowSIVAdd("VHNo") = String.Empty
            End If
            If lblVHDescp.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHDescp") = lblVHDescp.Text.Trim()
            Else
                rowSIVAdd("VHDescp") = String.Empty
            End If
            If psSIVVHID <> String.Empty Then
                rowSIVAdd("VHID") = psSIVVHID
            Else
                rowSIVAdd("VHID") = String.Empty
            End If
            If psSIVVHCategoryID <> String.Empty Then
                rowSIVAdd("VHCategoryID") = psSIVVHCategoryID
            Else
                rowSIVAdd("VHCategoryID") = String.Empty
            End If
            If psSIVVHType <> String.Empty Then
                rowSIVAdd("Type") = psSIVVHType
            Else
                rowSIVAdd("Type") = String.Empty
            End If

            If txtODOReading.Text.Trim() <> String.Empty Then
                rowSIVAdd("ODOReading") = CDbl(txtODOReading.Text)
            Else
                rowSIVAdd("ODOReading") = 0
            End If

            If psSIVVHDetailsCostCodeId <> String.Empty Then
                rowSIVAdd("VHDetailCostCodeID") = psSIVVHDetailsCostCodeId
            Else
                rowSIVAdd("VHDetailCostCodeID") = String.Empty
            End If
            If txtVHDetailsCostCode.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHDetailCostCode") = txtVHDetailsCostCode.Text.Trim()
            Else
                rowSIVAdd("VHDetailCostCode") = String.Empty
            End If
            If lblVHDescp.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHDetailDescp") = lblVHDescp.Text.Trim()
            Else
                rowSIVAdd("VHDetailDescp") = String.Empty
            End If
            'If psSIVVHDetCostCodType <> String.Empty Then
            'rowSIVAdd("VHDetailCostCodeType") = psSIVVHDetCostCodType
            'Else
            'rowSIVAdd("VHDetailCostCodeType") = String.Empty
            'End If

            dtSIVAdd.Rows.InsertAt(rowSIVAdd, intRowcount)
            dtAddFlag = True
        Else
            'Append values to the Dt from second time
            'columnSIVAdd = New DataColumn("StockCategory", System.Type.[GetType]("System.String"))
            'dtSIVAdd.Columns.Add(columnSIVAdd)

            If txtStockCategory.Text.Trim <> String.Empty Then
                rowSIVAdd("StockCategory") = txtStockCategory.Text.Trim()
            Else
                rowSIVAdd("StockCategory") = String.Empty
            End If
            If psSIVStockCategoryID <> String.Empty Then
                rowSIVAdd("StockCategoryId") = psSIVStockCategoryID
            Else
                rowSIVAdd("StockCategoryId") = String.Empty
            End If
            If psSIVStockCategoryCode <> String.Empty Then
                rowSIVAdd("StockCategoryCode") = psSIVStockCategoryCode
            Else
                rowSIVAdd("StockCategoryCode") = String.Empty
            End If
            If psSIVStockCOAID <> String.Empty Then
                rowSIVAdd("StockCOAID") = psSIVStockCOAID
            Else
                rowSIVAdd("StockCOAID") = String.Empty
            End If
            If psSIVVarianceCOAID <> String.Empty Then
                rowSIVAdd("VarianceCOAID") = psSIVVarianceCOAID
            Else
                rowSIVAdd("VarianceCOAID") = String.Empty
            End If

            If txtStockCode.Text.Trim <> String.Empty Then
                rowSIVAdd("StockCode") = txtStockCode.Text.ToString()
            Else
                rowSIVAdd("StockCode") = String.Empty
            End If
            If psSIVStockID <> String.Empty Then
                rowSIVAdd("StockId") = psSIVStockID
            Else
                rowSIVAdd("StockId") = String.Empty
            End If
            If lblDescription.Text.Trim <> String.Empty Then
                rowSIVAdd("StockDesc") = lblDescription.Text.Trim()
            Else
                rowSIVAdd("StockDesc") = String.Empty
            End If
            If lblUnit.Text.Trim <> String.Empty Then
                rowSIVAdd("UOM") = lblUnit.Text
            Else
                rowSIVAdd("UOM") = String.Empty
            End If
            If lblAvailableQty.Text.Trim() <> String.Empty Then
                rowSIVAdd("AvailableQty") = CDbl(lblAvailableQty.Text.Trim())
            Else
                rowSIVAdd("AvailableQty") = 0
            End If
            If lblMinQty.Text.Trim() <> String.Empty Then
                rowSIVAdd("MinQty") = CDbl(lblMinQty.Text.Trim())
            Else
                rowSIVAdd("MinQty") = 0
            End If
            If txtQtyIssued.Text.Trim() <> String.Empty Then
                rowSIVAdd("IssuedQty") = CDbl(txtQtyIssued.Text.Trim())
            Else
                rowSIVAdd("IssuedQty") = 0
            End If

            If txtUsedFor.Text.Trim() <> String.Empty Then
                rowSIVAdd("UsedFor") = txtUsedFor.Text.Trim()
            Else
                rowSIVAdd("UsedFor") = String.Empty
            End If

            If txtAccountCode.Text.Trim() <> String.Empty Then
                rowSIVAdd("COACode") = txtAccountCode.Text.Trim()
            Else
                rowSIVAdd("COACode") = String.Empty
            End If
            If psSIVAccountID <> String.Empty Then
                rowSIVAdd("COAID") = psSIVAccountID
            Else
                rowSIVAdd("COAID") = String.Empty
            End If
            If lblAccountDesc.Text.Trim <> String.Empty Then
                rowSIVAdd("COADescp") = lblAccountDesc.Text
            Else
                rowSIVAdd("COADescp") = String.Empty
            End If
            If lblOldAccountCode.Text.Trim <> String.Empty Then
                rowSIVAdd("OldCOACode") = lblOldAccountCode.Text
            Else
                rowSIVAdd("OldCOACode") = String.Empty
            End If
            If lsVDExpenditureAG.Trim <> String.Empty Then
                rowSIVAdd("ExpenditureAG") = lsVDExpenditureAG
            Else
                rowSIVAdd("ExpenditureAG") = String.Empty
            End If

            If txtT0.Text.Trim() <> String.Empty Then
                rowSIVAdd("T0Value") = txtT0.Text.Trim()
            Else
                rowSIVAdd("T0Value") = String.Empty
            End If
            If psSIVT0analysisID <> String.Empty Then
                rowSIVAdd("T0Id") = psSIVT0analysisID
            Else
                rowSIVAdd("T0Id") = String.Empty
            End If
            If lblT0Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T0Desc") = lblT0Name.Text.Trim()
            Else
                rowSIVAdd("T0Desc") = String.Empty
            End If

            If txtT1.Text.Trim() <> String.Empty Then
                rowSIVAdd("T1Value") = txtT1.Text.Trim()
            Else
                rowSIVAdd("T1Value") = String.Empty
            End If
            If psSIVT1analysisID <> String.Empty Then
                rowSIVAdd("T1Id") = psSIVT1analysisID
            Else
                rowSIVAdd("T1Id") = String.Empty
            End If
            If lblT1Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T1Desc") = lblT1Name.Text.Trim()
            Else
                rowSIVAdd("T1Desc") = String.Empty
            End If


            If txtT2.Text.Trim() <> String.Empty Then
                rowSIVAdd("T2Value") = txtT2.Text.Trim()
            Else
                rowSIVAdd("T2Value") = String.Empty
            End If
            If psSIVT2analysisID <> String.Empty Then
                rowSIVAdd("T2Id") = psSIVT2analysisID
            Else
                rowSIVAdd("T2Id") = String.Empty
            End If
            If lblT2Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T2Desc") = lblT2Name.Text.Trim()
            Else
                rowSIVAdd("T2Desc") = String.Empty
            End If

            If txtT3.Text.Trim() <> String.Empty Then
                rowSIVAdd("T3Value") = txtT3.Text.Trim()
            Else
                rowSIVAdd("T3Value") = String.Empty
            End If
            If psSIVT3analysisID <> String.Empty Then
                rowSIVAdd("T3Id") = psSIVT3analysisID
            Else
                rowSIVAdd("T3Id") = String.Empty
            End If
            If lblT3Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T3Desc") = lblT3Name.Text.Trim()
            Else
                rowSIVAdd("T3Desc") = String.Empty
            End If

            If txtT4.Text.Trim() <> String.Empty Then
                rowSIVAdd("T4Value") = txtT4.Text.Trim()
            Else
                rowSIVAdd("T4Value") = String.Empty
            End If
            If psSIVT4analysisID <> String.Empty Then
                rowSIVAdd("T4Id") = psSIVT4analysisID
            Else
                rowSIVAdd("T4Id") = String.Empty
            End If
            If lblT4Name.Text.Trim() <> String.Empty Then
                rowSIVAdd("T4Desc") = lblT4Name.Text.Trim()
            Else
                rowSIVAdd("T4Desc") = String.Empty
            End If

            If psSIVBlockID <> String.Empty Then
                rowSIVAdd("BlockId") = psSIVBlockID
            Else
                rowSIVAdd("BlockId") = String.Empty
            End If
            If txtSubBlock.Text.Trim() <> String.Empty Then
                rowSIVAdd("BlockName") = txtSubBlock.Text.Trim()
            Else
                rowSIVAdd("BlockName") = String.Empty
            End If

            If psSIVPlantedHect <> String.Empty Then
                rowSIVAdd("PlantedHect") = CDbl(psSIVPlantedHect)
            Else
                rowSIVAdd("PlantedHect") = 0
            End If
            If lblSubBlockName.Text.Trim() <> String.Empty Then
                rowSIVAdd("BlockStatus") = lblSubBlockName.Text.Trim()
            Else
                rowSIVAdd("BlockStatus") = String.Empty
            End If

            If txtDiv.Text.Trim() <> String.Empty Then
                rowSIVAdd("Div") = txtDiv.Text.Trim()
            Else
                rowSIVAdd("Div") = String.Empty
            End If
            If lblDivName.Text.Trim() <> String.Empty Then
                rowSIVAdd("DivName") = lblDivName.Text.Trim()
            Else
                rowSIVAdd("DivName") = String.Empty
            End If
            If psSIVDivID <> String.Empty Then
                rowSIVAdd("DivId") = psSIVDivID
            Else
                rowSIVAdd("DivId") = String.Empty
            End If

            If txtYOP.Text.Trim() <> String.Empty Then
                rowSIVAdd("YOP") = txtYOP.Text.Trim()
            Else
                rowSIVAdd("YOP") = String.Empty
            End If
            If psSIVYopID <> String.Empty Then
                rowSIVAdd("YOPID") = psSIVYopID
            Else
                rowSIVAdd("YOPID") = String.Empty
            End If
            If lblYOPName.Text.Trim() <> String.Empty Then
                rowSIVAdd("Name") = lblYOPName.Text.Trim()
            Else
                rowSIVAdd("Name") = String.Empty
            End If

            If psSIVStationID <> String.Empty Then
                rowSIVAdd("StationID") = psSIVStationID
            Else
                rowSIVAdd("StationID") = String.Empty
            End If
            If txtStation.Text.Trim() <> String.Empty Then
                rowSIVAdd("StationCode") = txtStation.Text.Trim()
            Else
                rowSIVAdd("StationCode") = String.Empty
            End If
            If lblStationDesc.Text.Trim() <> String.Empty Then
                rowSIVAdd("StationDescp") = lblStationDesc.Text.Trim()
            Else
                rowSIVAdd("StationDescp") = lblStationDesc.Text.Trim()
            End If

            If txtVHNo.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHNo") = txtVHNo.Text.Trim()
            Else
                rowSIVAdd("VHNo") = String.Empty
            End If
            If lblVHDescp.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHDescp") = lblVHDescp.Text.Trim()
            Else
                rowSIVAdd("VHDescp") = String.Empty
            End If
            If psSIVVHID <> String.Empty Then
                rowSIVAdd("VHID") = psSIVVHID
            Else
                rowSIVAdd("VHID") = String.Empty
            End If
            If psSIVVHCategoryID <> String.Empty Then
                rowSIVAdd("VHCategoryID") = psSIVVHCategoryID
            Else
                rowSIVAdd("VHCategoryID") = String.Empty
            End If
            If psSIVVHType <> String.Empty Then
                rowSIVAdd("Type") = psSIVVHType
            Else
                rowSIVAdd("Type") = String.Empty
            End If

            If txtODOReading.Text.Trim() <> String.Empty Then
                rowSIVAdd("ODOReading") = CDbl(txtODOReading.Text)
            Else
                rowSIVAdd("ODOReading") = 0
            End If

            If psSIVVHDetailsCostCodeId <> String.Empty Then
                rowSIVAdd("VHDetailCostCodeID") = psSIVVHDetailsCostCodeId
            Else
                rowSIVAdd("VHDetailCostCodeID") = String.Empty
            End If
            If txtVHDetailsCostCode.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHDetailCostCode") = txtVHDetailsCostCode.Text.Trim()
            Else
                rowSIVAdd("VHDetailCostCode") = String.Empty
            End If
            If lblVHDescp.Text.Trim() <> String.Empty Then
                rowSIVAdd("VHDetailDescp") = lblVHDescp.Text.Trim()
            Else
                rowSIVAdd("VHDetailDescp") = String.Empty
            End If
            'If psSIVVHDetCostCodType <> String.Empty Then
            'rowSIVAdd("VHDetailCostCodeType") = psSIVVHDetCostCodType
            'Else
            'rowSIVAdd("VHDetailCostCodeType") = String.Empty
            'End If

            dtSIVAdd.Rows.InsertAt(rowSIVAdd, intRowcount)
        End If
        With dgIssueVoucher
            .DataSource = dtSIVAdd
            .AutoGenerateColumns = False
        End With
        btnSaveAll.Focus()
        '' ''txtStockCategory.Enabled = False
        '' ''btnSearchStockCategory.Enabled = False
        clear()

        'Else
        'MsgBox("Sorry, the Stock Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
        'End If


    End Sub

    Private Sub UpdateSIVDetail()

        Dim intCount As Integer = dgIssueVoucher.CurrentRow.Index
        Dim objSIVPPT As New StoreIssueVoucherPPT
        With objSIVPPT
            .StockCode = txtStockCode.Text.Trim()
        End With
        If StockCodeExistUpdateMode(objSIVPPT.StockCode.Trim, txtAccountCode.Text.Trim, txtSubBlock.Text.Trim, txtDiv.Text.Trim, txtVHNo.Text.Trim, txtVHDetailsCostCode.Text.Trim, txtStation.Text.Trim) Then
            'If StockCodeExistUpdateMode(objSIVPPT.StockCode, txtSubBlock.Text, txtDiv.Text, txtVHNo.Text, txtStation.Text) Then
            'MsgBox("Sorry, the Stock Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            Exit Sub
        End If

        If txtStockCategory.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCategory").Value = Me.txtStockCategory.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCategory").Value = String.Empty
        End If
        If psSIVStockCategoryID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCategoryId").Value = Me.psSIVStockCategoryID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCategoryId").Value = String.Empty
        End If
        If psSIVStockCategoryCode <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCategoryCode").Value = Me.psSIVStockCategoryCode
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCategoryCode").Value = String.Empty
        End If
        If psSIVStockCOAID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCOAID").Value = psSIVStockCOAID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCOAID").Value = String.Empty
        End If
        If psSIVVarianceCOAID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVarianceCOAID").Value = psSIVVarianceCOAID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVarianceCOAID").Value = String.Empty
        End If
        If txtStockCode.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCode").Value = Me.txtStockCode.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStockCode").Value = String.Empty
        End If

        If psSIVStockID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStockId").Value = Me.psSIVStockID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStockId").Value = String.Empty
        End If
        If lblDescription.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclDesc").Value = Me.lblDescription.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclDesc").Value = String.Empty
        End If
        If lblUnit.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclUnit").Value = Me.lblUnit.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclUnit").Value = String.Empty
        End If
        If lblAvailableQty.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclAvailQty").Value = Me.lblAvailableQty.Text.Trim()
        End If
        If lblMinQty.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclMinQty").Value = Me.lblMinQty.Text.Trim()
        End If
        If txtQtyIssued.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclIssuedQty").Value = Me.txtQtyIssued.Text.Trim()
        End If
        If txtUsedFor.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclUsedFor").Value = Me.txtUsedFor.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclUsedFor").Value = String.Empty
        End If
        If txtAccountCode.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclAccountCode").Value = Me.txtAccountCode.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclAccountCode").Value = String.Empty
        End If
        If psSIVAccountID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclAccountId").Value = Me.psSIVAccountID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclAccountId").Value = String.Empty
        End If
        If lblAccountDesc.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclAccountDesc").Value = Me.lblAccountDesc.Text
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclAccountDesc").Value = String.Empty
        End If
        If lblOldAccountCode.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclOldAccountCode").Value = Me.lblOldAccountCode.Text
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclOldAccountCode").Value = String.Empty
        End If
        If txtT0.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT0").Value = Me.txtT0.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT0").Value = String.Empty
        End If
        If Me.psSIVT0analysisID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT0Id").Value = Me.psSIVT0analysisID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT0Id").Value = String.Empty
        End If
        If lblT0Name.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT0Desc").Value = Me.lblT0Name.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT0Desc").Value = String.Empty
        End If

        If txtT1.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT1").Value = Me.txtT1.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT1").Value = String.Empty
        End If

        If Me.psSIVT1analysisID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT1Id").Value = Me.psSIVT1analysisID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT1Id").Value = String.Empty
        End If
        'dgIssueVoucher.Rows(intCount).Cells("dgclT1Id").Value = Me.psSIVT1analysisID
        If lblT1Name.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT1Desc").Value = Me.lblT1Name.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT1Desc").Value = String.Empty
        End If

        If txtT2.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT2").Value = Me.txtT2.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT2").Value = String.Empty
        End If
        If psSIVT2analysisID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT2Id").Value = Me.psSIVT2analysisID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT2Id").Value = String.Empty
        End If
        If lblT2Name.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT2Desc").Value = Me.lblT2Name.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT2Desc").Value = String.Empty
        End If

        If txtT3.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT3").Value = Me.txtT3.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT3").Value = String.Empty
        End If
        If psSIVT3analysisID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT3Id").Value = Me.psSIVT3analysisID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT3Id").Value = String.Empty
        End If
        If lblT3Name.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT3Desc").Value = Me.lblT3Name.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT3Desc").Value = String.Empty
        End If
        If txtT4.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT4").Value = Me.txtT4.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT4").Value = String.Empty
        End If
        If psSIVT4analysisID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT4Id").Value = Me.psSIVT4analysisID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT4Id").Value = String.Empty
        End If
        If lblT4Name.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclT4Desc").Value = Me.lblT4Name.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclT4Desc").Value = String.Empty
        End If

        If psSIVBlockID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclSubBlock").Value = psSIVBlockID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclSubBlock").Value = String.Empty
        End If
        If txtSubBlock.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclBlockName").Value = Me.txtSubBlock.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclBlockName").Value = String.Empty
        End If
        If psSIVPlantedHect <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclPlantedHect").Value = CDbl(psSIVPlantedHect)
        End If
        If lblSubBlockName.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclBlockStatus").Value = Me.lblSubBlockName.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclBlockStatus").Value = String.Empty
        End If

        If txtDiv.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclDiv").Value = Me.txtDiv.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclDiv").Value = String.Empty
        End If
        If psSIVDivID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclDivId").Value = Me.psSIVDivID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclDivId").Value = String.Empty
        End If
        If lblDivName.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclDivName").Value = Me.lblDivName.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclDivName").Value = String.Empty
        End If
        If txtYOP.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclYOP").Value = Me.txtYOP.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclYOP").Value = String.Empty
        End If
        If psSIVYopID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclYOPID").Value = Me.psSIVYopID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclYOPID").Value = String.Empty
        End If
        If lblYOPName.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclName").Value = Me.lblYOPName.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclName").Value = String.Empty
        End If
        If txtStation.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStation").Value = Me.txtStation.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStation").Value = String.Empty
        End If
        If psSIVStationID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStationID").Value = Me.psSIVStationID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStationID").Value = String.Empty
        End If
        If lblStationDesc.Text <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclStationDescp").Value = lblStationDesc.Text
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclStationDescp").Value = String.Empty
        End If
        If txtVHNo.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVHNo").Value = Me.txtVHNo.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVHNo").Value = String.Empty
        End If
        If lblVHDescp.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVHDesc").Value = Me.lblVHDescp.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVHDesc").Value = String.Empty
        End If
        If psSIVVHID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVHID").Value = psSIVVHID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVHID").Value = String.Empty
        End If
        If psSIVVHCategoryID <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVHCategoryID").Value = psSIVVHCategoryID
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVHCategoryID").Value = String.Empty
        End If
        If psSIVVHType <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclType").Value = psSIVVHType
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclType").Value = String.Empty
        End If
        If txtODOReading.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclOdoReading").Value = Me.txtODOReading.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclOdoReading").Value = DBNull.Value
        End If
        If txtVHDetailsCostCode.Text.Trim() <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVHDetailCostCode").Value = Me.txtVHDetailsCostCode.Text.Trim()
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVHDetailCostCode").Value = String.Empty
        End If
        If psSIVVHDetailsCostCodeId <> String.Empty Then
            dgIssueVoucher.Rows(intCount).Cells("dgclVHDetailCostCodeID").Value = Me.psSIVVHDetailsCostCodeId
        Else
            dgIssueVoucher.Rows(intCount).Cells("dgclVHDetailCostCodeID").Value = String.Empty
        End If
        'dgIssueVoucher.Rows(intCount).Cells("dgclVHDetailCostCodeType").Value = psSIVVHDetCostCodType
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        clear()
        btnAddFlag = True
        btnSaveAll.Focus()
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub clear()

        ''''txtStockCategory.Enabled = False
        txtStockCategory.Text = String.Empty
        lblStockCategoryCode.Text = String.Empty
        txtStockCode.Text = String.Empty
        lblDescription.Text = String.Empty
        lblUnit.Text = String.Empty
        lblAvailableQty.Text = String.Empty
        lblMinQty.Text = String.Empty
        txtQtyIssued.Text = String.Empty
        txtUsedFor.Text = String.Empty
        'txtAccountCode.Text = String.Empty
        If txtContractNo.Text.Trim() = String.Empty Then
            txtAccountCode.Text = String.Empty
            Me.psSIVAccountID = String.Empty
            psSIVOldAccountID = String.Empty
            GlobalPPT.psAcctExpenditureType = String.Empty
            Me.lblAccountDesc.Text = String.Empty
            Me.lblOldAccountCode.Text = String.Empty
        Else

        End If

        '        txtT0.Text = String.Empty
        '       lblT0Name.Text = String.Empty
        'psSIVT0analysisID = String.Empty
        txtT1.Text = String.Empty
        lblT1Name.Text = String.Empty
        psSIVT1analysisID = String.Empty
        txtT2.Text = String.Empty
        lblT2Name.Text = String.Empty
        psSIVT2analysisID = String.Empty
        txtT3.Text = String.Empty
        lblT3Name.Text = String.Empty
        psSIVT3analysisID = String.Empty
        txtT4.Text = String.Empty
        lblT4Name.Text = String.Empty
        psSIVT4analysisID = String.Empty
        txtDiv.Text = String.Empty
        lblDivName.Text = String.Empty
        psSIVDivID = String.Empty
        txtYOP.Text = String.Empty
        lblYOPName.Text = String.Empty
        psSIVYopID = String.Empty
        txtSubBlock.Text = String.Empty
        psSIVBlockID = String.Empty
        lblSubBlockName.Text = String.Empty
        txtStation.Text = String.Empty
        lblStationDesc.Text = String.Empty
        psSIVStationID = String.Empty
        txtVHNo.Text = String.Empty
        txtVHNo.Enabled = True
        btnSearchVHNo.Enabled = True
        lblVHDescp.Text = String.Empty
        psSIVVHID = String.Empty
        psSIVVHCategoryID = String.Empty
        psSIVVHType = String.Empty
        txtODOReading.Text = String.Empty
        txtODOReading.Enabled = True
        txtVHDetailsCostCode.Text = String.Empty
        txtVHDetailsCostCode.Enabled = True
        btnSearchVHcostCode.Enabled = True
        lblVHDetailDescp.Text = String.Empty
        '        psSIVVHDetCostCodType = String.Empty
        psSIVVHDetailsCostCodeId = String.Empty

        btnAddFlag = True
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub FormatDateTimePicker(ByVal dtpName)

        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
        'edit by suraya 14092012
        txtSIVDateSearch.Format = DateTimePickerFormat.Custom '
        txtSIVDateSearch.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.txtSIVDateSearch)
    End Sub

    Private Sub ClearAll()

        DeleteMultientry.Clear()
        txtSIVNo.Enabled = True
        txtSIVNo.Text = String.Empty
        lblQtyIssued.Text = String.Empty
        txtIssueBatchTotal.Text = String.Empty
        'dtpSIVDate.Value = Date.Today
        Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.dtpSIVDate)
        FormatDateTimePicker(dtpSIVDate)
        txtContractNo.Text = String.Empty
        lblContractorValue.Text = String.Empty
        txtRemarks.Text = String.Empty
        clear()
        ''''txtStockCategory.Enabled = True
        txtStockCategory.Text = String.Empty
        lblStockCategoryCode.Text = String.Empty
        btnSearchStockCategory.Enabled = True
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        'lblStoreIssueStatus.Text=""
        lblStatus.Text = "OPEN"
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub dgIssueVoucher_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgIssueVoucher.CellDoubleClick

        SIVGrid_Edit()

    End Sub

    Private Sub ClearFieldsOnGridClick()

        psSIVStockCOAID = String.Empty
        psSIVVarianceCOAID = String.Empty
        txtStockCode.Text = String.Empty
        lblDescription.Text = String.Empty
        lblUnit.Text = String.Empty
        psExistingStockCode = String.Empty
        psExistingBlockName = String.Empty
        psExistingDiv = String.Empty
        psExistingVHNo = String.Empty
        psExistingStationCode = String.Empty

        psSIVStockID = String.Empty
        lblAvailableQty.Text = String.Empty
        lblMinQty.Text = String.Empty
        txtQtyIssued.Text = String.Empty
        txtUsedFor.Text = String.Empty
        txtAccountCode.Text = String.Empty
        lblAccountDesc.Text = String.Empty
        psSIVAccountID = String.Empty
        txtT0.Text = String.Empty
        lblT0Name.Text = String.Empty
        psSIVT0analysisID = String.Empty
        txtT1.Text = String.Empty
        lblT1Name.Text = String.Empty
        psSIVT1analysisID = String.Empty
        txtT2.Text = String.Empty
        lblT2Name.Text = String.Empty
        psSIVT2analysisID = String.Empty
        txtT3.Text = String.Empty
        lblT3Name.Text = String.Empty
        psSIVT3analysisID = String.Empty
        txtT4.Text = String.Empty
        lblT4Name.Text = String.Empty
        psSIVT4analysisID = String.Empty
        txtSubBlock.Text = String.Empty
        lblSubBlockName.Text = String.Empty
        psSIVBlockID = String.Empty
        psSIVPlantedHect = String.Empty
        psSIVDivID = String.Empty
        txtDiv.Text = String.Empty
        lblDivName.Text = String.Empty
        txtYOP.Text = String.Empty
        psSIVYopID = String.Empty
        lblYOPName.Text = String.Empty
        txtStation.Text = String.Empty
        psSIVStationID = String.Empty
        lblStationDesc.Text = String.Empty
        txtVHNo.Text = String.Empty
        lblVHDescp.Text = String.Empty
        psSIVVHID = String.Empty
        psSIVVHCategoryID = String.Empty
        psSIVVHType = String.Empty
        txtODOReading.Text = String.Empty
        txtVHDetailsCostCode.Text = String.Empty
        lblVHDetailDescp.Text = String.Empty
        psSIVVHDetailsCostCodeId = String.Empty
        psSIVSTIssueId = String.Empty
        psSIVSTIssueDetailsId = String.Empty
        psSIVStockID = String.Empty

    End Sub

    Private Sub SIVGrid_Edit()

        'Dim dtStock As DataTable
        Dim objIPRBOL As New IPRBOL
        Dim objPPT As New IPRPPT
        If dgIssueVoucher.Rows.Count > 0 Then
            'btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategoryId").Value <> String.Empty Then
                ClearFieldsOnGridClick()
                If dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategory").Value.ToString() <> String.Empty Then
                    txtStockCategory.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategory").Value.ToString()
                Else
                    txtStockCategory.Text = String.Empty
                End If
                psSIVStockCategoryID = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategoryId").Value.ToString()
                If dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategoryCode").Value.ToString() <> String.Empty Then
                    psSIVStockCategoryCode = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategoryCode").Value.ToString()
                    lblStockCategoryCode.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCategoryCode").Value.ToString()
                Else
                    psSIVStockCategoryCode = String.Empty
                    lblStockCategoryCode.Text = String.Empty
                End If
                Dim objSIVPPT As New StoreIssueVoucherPPT
                objSIVPPT.STCategoryID = psSIVStockCategoryID
                psSIVStockCOAID = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCOAID").Value.ToString()
                psSIVVarianceCOAID = dgIssueVoucher.SelectedRows(0).Cells("dgclVarianceCOAID").Value.ToString()
                ' '' ''Get Stock Category 
                '' ''Dim ds As New DataSet
                '' ''ds = StoreIssueVoucherBOL.fillCategoryDesc(objSIVPPT)
                '' ''If ds.Tables(0).Rows.Count > 0 Then
                '' ''    txtStockCategory.Text = ds.Tables(0).Rows(0).Item("STCategoryDescp")
                '' ''End If
            End If
            If Not dgIssueVoucher.SelectedRows(0).Cells("dgclStockCode").Value Is DBNull.Value Then
                txtStockCode.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
                psExistingStockCode = dgIssueVoucher.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            Else
                txtStockCode.Text = String.Empty
                psExistingStockCode = String.Empty
            End If
            If Not dgIssueVoucher.SelectedRows(0).Cells("dgclStockId").Value Is DBNull.Value Then
                Me.psSIVStockID = dgIssueVoucher.SelectedRows(0).Cells("dgclStockId").Value
            Else
                Me.psSIVStockID = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclDesc").Value.ToString() <> String.Empty Then
                lblDescription.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclDesc").Value.ToString()
            Else
                lblDescription.Text = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclUnit").Value.ToString() <> String.Empty Then
                lblUnit.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclUnit").Value.ToString()
            Else
                lblUnit.Text = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclAvailQty").Value.ToString() <> String.Empty Then
                lblAvailableQty.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclAvailQty").Value
            Else
                lblAvailableQty.Text = String.Empty
            End If
            If Not dgIssueVoucher.SelectedRows(0).Cells("dgclMinQty").Value Is DBNull.Value Then
                lblMinQty.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclMinQty").Value
            Else
                lblMinQty.Text = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclIssuedQty").Value.ToString() <> String.Empty Then
                'txtQtyIssued.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclIssuedQty").Value
                txtQtyIssued.Text = Format(dgIssueVoucher.SelectedRows(0).Cells("dgclIssuedQty").Value, "0.00")
            Else
                txtQtyIssued.Text = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclUsedFor").Value.ToString() <> String.Empty Then
                txtUsedFor.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclUsedFor").Value.ToString()
            Else
                txtUsedFor.Text = String.Empty
            End If
            If txtContractNo.Text.Trim() = String.Empty Then
                If Not dgIssueVoucher.SelectedRows(0).Cells("dgclAccountCode").Value Is DBNull.Value Then
                    txtAccountCode.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclAccountCode").Value.ToString()
                    psExistingAccountCode = dgIssueVoucher.SelectedRows(0).Cells("dgclAccountCode").Value.ToString()
                Else
                    txtAccountCode.Text = String.Empty
                    psExistingAccountCode = String.Empty
                End If
                If Not dgIssueVoucher.SelectedRows(0).Cells("dgclAccountId").Value Is DBNull.Value Then
                    psSIVAccountID = dgIssueVoucher.SelectedRows(0).Cells("dgclAccountId").Value.ToString()
                Else
                    psSIVAccountID = String.Empty
                End If
                If Not dgIssueVoucher.SelectedRows(0).Cells("dgclAccountDesc").Value Is DBNull.Value Then
                    lblAccountDesc.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclAccountDesc").Value.ToString()
                Else
                    lblAccountDesc.Text = String.Empty
                End If
                If Not dgIssueVoucher.SelectedRows(0).Cells("dgclOldAccountCode").Value Is DBNull.Value Then
                    lblOldAccountCode.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclOldAccountCode").Value.ToString()
                Else
                    lblOldAccountCode.Text = String.Empty
                End If
                If Not (dgIssueVoucher.SelectedRows(0).Cells("dgclExpenditureAG").Value Is DBNull.Value Or dgIssueVoucher.SelectedRows(0).Cells("dgclExpenditureAG").Value Is Nothing) Then
                    lsVDExpenditureAG = dgIssueVoucher.SelectedRows(0).Cells("dgclExpenditureAG").Value.ToString()
                    GlobalPPT.psAcctExpenditureType = dgIssueVoucher.SelectedRows(0).Cells("dgclExpenditureAG").Value.ToString()
                Else
                    lsVDExpenditureAG = String.Empty
                    GlobalPPT.psAcctExpenditureType = String.Empty
                End If

            End If

            If dgIssueVoucher.SelectedRows(0).Cells("dgclT0").Value.ToString() <> String.Empty Then
                txtT0.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT0").Value.ToString()
            End If
            Me.psSIVT0analysisID = dgIssueVoucher.SelectedRows(0).Cells("dgclT0Id").Value.ToString()
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT0Desc").Value.ToString() <> String.Empty Then
                Me.lblT0Name.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT0Desc").Value.ToString()
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT1").Value.ToString() <> String.Empty Then
                txtT1.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT1").Value.ToString()
            End If
            Me.psSIVT1analysisID = dgIssueVoucher.SelectedRows(0).Cells("dgclT1Id").Value.ToString()
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT1Desc").Value.ToString() <> String.Empty Then
                Me.lblT1Name.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT1Desc").Value.ToString()
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT2").Value.ToString() <> String.Empty Then
                txtT2.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT2").Value.ToString()
            End If
            Me.psSIVT2analysisID = dgIssueVoucher.SelectedRows(0).Cells("dgclT2Id").Value.ToString()
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT2Desc").Value.ToString() <> String.Empty Then
                Me.lblT2Name.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT2Desc").Value.ToString()
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT3").Value.ToString() <> String.Empty Then
                txtT3.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT3").Value.ToString()
            End If
            Me.psSIVT3analysisID = dgIssueVoucher.SelectedRows(0).Cells("dgclT3Id").Value.ToString()
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT3Desc").Value.ToString() <> String.Empty Then
                Me.lblT3Name.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT3Desc").Value.ToString()
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT4").Value.ToString() <> String.Empty Then
                txtT4.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT4").Value.ToString()
            End If
            Me.psSIVT4analysisID = dgIssueVoucher.SelectedRows(0).Cells("dgclT4Id").Value.ToString()
            If dgIssueVoucher.SelectedRows(0).Cells("dgclT4Desc").Value.ToString() <> String.Empty Then
                Me.lblT4Name.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclT4Desc").Value.ToString()
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclSubBlock").Value.ToString() <> String.Empty Then
                psSIVBlockID = dgIssueVoucher.SelectedRows(0).Cells("dgclSubBlock").Value.ToString()
                txtVHNo.Enabled = False
                btnSearchVHNo.Enabled = False
                txtVHDetailsCostCode.Enabled = False
                btnSearchVHcostCode.Enabled = False
                txtODOReading.Enabled = False
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclBlockName").Value.ToString() <> String.Empty Then
                txtSubBlock.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclBlockName").Value.ToString().Trim
                psExistingBlockName = dgIssueVoucher.SelectedRows(0).Cells("dgclBlockName").Value.ToString().Trim
            Else
                txtSubBlock.Text = String.Empty
                psExistingBlockName = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclPlantedHect").Value.ToString() <> String.Empty Then
                psSIVPlantedHect = dgIssueVoucher.SelectedRows(0).Cells("dgclPlantedHect").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclBlockStatus").Value.ToString() <> String.Empty Then
                lblSubBlockName.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclBlockStatus").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclDiv").Value.ToString() <> String.Empty Then
                txtDiv.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclDiv").Value.ToString().Trim
                psExistingDiv = dgIssueVoucher.SelectedRows(0).Cells("dgclDiv").Value.ToString().Trim
            Else
                txtDiv.Text = String.Empty
                psExistingDiv = String.Empty
            End If
            psSIVDivID = dgIssueVoucher.SelectedRows(0).Cells("dgclDivId").Value.ToString().Trim
            If dgIssueVoucher.SelectedRows(0).Cells("dgclDivName").Value.ToString() <> String.Empty Then
                lblDivName.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclDivName").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclYOP").Value.ToString() <> String.Empty Then
                txtYOP.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclYOP").Value.ToString().Trim
            End If
            Me.psSIVYopID = dgIssueVoucher.SelectedRows(0).Cells("dgclYOPID").Value.ToString().Trim
            If dgIssueVoucher.SelectedRows(0).Cells("dgclName").Value.ToString() <> String.Empty Then
                lblYOPName.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclName").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclStation").Value.ToString() <> String.Empty Then
                txtStation.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclStation").Value.ToString().Trim
                psExistingStationCode = dgIssueVoucher.SelectedRows(0).Cells("dgclStation").Value.ToString().Trim
            Else
                txtStation.Text = String.Empty
                psExistingStationCode = String.Empty
            End If
            Me.psSIVStationID = dgIssueVoucher.SelectedRows(0).Cells("dgclStationID").Value.ToString().Trim
            If dgIssueVoucher.SelectedRows(0).Cells("dgclStationDescp").Value.ToString() <> String.Empty Then
                Me.lblStationDesc.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclStationDescp").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclVHNo").Value.ToString() <> String.Empty Then
                txtVHNo.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclVHNo").Value.ToString().Trim
                psExistingVHNo = dgIssueVoucher.SelectedRows(0).Cells("dgclVHNo").Value.ToString().Trim
            Else
                txtVHNo.Text = String.Empty
                psExistingVHNo = String.Empty
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclVHDesc").Value.ToString() <> String.Empty Then
                lblVHDescp.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclVHDesc").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclVHID").Value.ToString() <> String.Empty Then
                psSIVVHID = dgIssueVoucher.SelectedRows(0).Cells("dgclVHID").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclVHCategoryID").Value.ToString() <> String.Empty Then
                psSIVVHCategoryID = dgIssueVoucher.SelectedRows(0).Cells("dgclVHCategoryID").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclType").Value.ToString() <> String.Empty Then
                psSIVVHType = dgIssueVoucher.SelectedRows(0).Cells("dgclType").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclOdoReading").Value.ToString() <> String.Empty Then
                txtODOReading.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclOdoReading").Value
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailDescp").Value.ToString() <> String.Empty Then
                lblVHDetailDescp.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailDescp").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailCostCode").Value.ToString() <> String.Empty Then
                txtVHDetailsCostCode.Text = dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailCostCode").Value.ToString().Trim
                psExistingVHDetailsCostCode = dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailCostCode").Value.ToString().Trim
            Else
                txtVHDetailsCostCode.Text = String.Empty
                psExistingVHDetailsCostCode = String.Empty
            End If
            Me.psSIVVHDetailsCostCodeId = dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailCostCodeID").Value.ToString().Trim
            'If dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailCostCodeType").Value.ToString() <> String.Empty Then
            '    psSIVVHDetCostCodType = dgIssueVoucher.SelectedRows(0).Cells("dgclVHDetailCostCodeType").Value.ToString()
            'End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueId").Value.ToString() <> String.Empty Then
                psSIVSTIssueId = dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueId").Value.ToString().Trim
            End If
            If dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString() <> String.Empty Then
                psSIVSTIssueDetailsId = dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString().Trim
            End If
            psSIVStockID = dgIssueVoucher.SelectedRows(0).Cells("dgclStockId").Value.ToString().Trim
            ''If psSIVStockID <> Nothing Then
            ''    objPPT.stockID = psSIVStockID
            ''    dtStock = objIPRBOL.GetAvailableQTy(objPPT)
            ''    If dtStock.Rows.Count <> 0 Then
            ''        'Me.lblUnitPriceValue.Text = dtStock.Rows(0).Item("UnitPrice").ToString
            ''        If dtStock.Rows(0).Item("AvailableQty").ToString <> String.Empty Then
            ''            Me.lblAvailableQty.Text = dtStock.Rows(0).Item("AvailableQty").ToString
            ''        End If
            ''        'Me.lblUnitPriceValue.Visible = True
            ''        'lblAvailableValue.Visible = True
            ''    End If
            ''End If
            'txtStockCategory.Enabled = False
        End If
        btnAddFlag = False
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub ClearStockCodeRelatedFields()

        Me.txtStockCode.Text = String.Empty
        psSIVStockID = String.Empty
        Me.lblUnit.Text = String.Empty
        Me.lblAvailableQty.Text = String.Empty
        Me.lblMinQty.Text = String.Empty
        Me.lblDescription.Text = String.Empty

    End Sub

    Private Function StockCodeExist(ByVal StockCode As String, ByVal AccounttCode As String, ByVal BlockName As String, ByVal Div As String, ByVal VHNo As String, ByVal VHDetailsCostCode As String, ByVal StationCode As String) As Boolean

        Try
            Dim objDataGridViewRow As New DataGridViewRow

            For Each objDataGridViewRow In dgIssueVoucher.Rows

                If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim Then
                    If AccounttCode = objDataGridViewRow.Cells("dgclAccountCode").Value.ToString().Trim Then
                        If StationCode = objDataGridViewRow.Cells("dgclStation").Value.ToString().Trim Then
                            If BlockName = objDataGridViewRow.Cells("dgclBlockName").Value.ToString().Trim Then
                                If Div = objDataGridViewRow.Cells("dgclDiv").Value.ToString().Trim Then
                                    If VHNo = objDataGridViewRow.Cells("dgclVHNo").Value.ToString().Trim Then
                                        If VHDetailsCostCode = objDataGridViewRow.Cells("dgclVHDetailCostCode").Value.ToString().Trim Then

                                            txtStockCode.Focus()
                                            DisplayInfoMessage("Msg06")
                                            'MessageBox.Show("This Stock Code already exists")
                                            Return True

                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Next

            Return False

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Function

    Private Function StockCodeExistUpdateMode(ByVal StockCode As String, ByVal AccounttCode As String, ByVal BlockName As String, ByVal Div As String, ByVal VHNo As String, ByVal VHDetailsCostCode As String, ByVal StationCode As String) As Boolean

        Try
            Dim objDataGridViewRow As New DataGridViewRow

            For i As Integer = 0 To dgIssueVoucher.Rows.Count - 1
                If i <> dgIssueVoucher.CurrentRow.Index Then
                    If StockCode = dgIssueVoucher.Rows(i).Cells("dgclStockCode").Value.ToString().Trim Then
                        If AccounttCode = dgIssueVoucher.Rows(i).Cells("dgclAccountCode").Value.ToString().Trim Then
                            If StationCode = dgIssueVoucher.Rows(i).Cells("dgclStation").Value.ToString().Trim Then
                                If BlockName = dgIssueVoucher.Rows(i).Cells("dgclBlockName").Value.ToString().Trim Then
                                    If Div = dgIssueVoucher.Rows(i).Cells("dgclDiv").Value.ToString().Trim Then
                                        If VHNo = dgIssueVoucher.Rows(i).Cells("dgclVHNo").Value.ToString().Trim Then
                                            If VHDetailsCostCode = dgIssueVoucher.Rows(i).Cells("dgclVHDetailCostCode").Value.ToString().Trim Then

                                                txtStockCode.Focus()
                                                DisplayInfoMessage("Msg06")
                                                'MessageBox.Show("This Stock Code already exists")
                                                Return True

                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                End If
            Next

            Return False

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Function

    Private Function StockCodeExistold(ByVal StockCode As String, ByVal AccounttCode As String, ByVal BlockName As String, ByVal Div As String, ByVal VHNo As String, ByVal VHDetailsCostCode As String, ByVal StationCode As String) As Boolean

        Try
            Dim objDataGridViewRow As New DataGridViewRow

            For Each objDataGridViewRow In dgIssueVoucher.Rows

                'If AccounttCode <> String.Empty Then
                '    If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() And AccounttCode = objDataGridViewRow.Cells("dgclAccountCode").Value.ToString() Then
                '        'ClearStockCodeRelatedFields()
                '        txtStockCode.Focus()
                '        DisplayInfoMessage("Msg02")
                '        'MessageBox.Show("This Stock Code already exists for this block")
                '        Return True
                '    End If
                'End If

                If BlockName <> String.Empty Then
                    If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() And BlockName = objDataGridViewRow.Cells("dgclBlockName").Value.ToString() Then
                        'ClearStockCodeRelatedFields()
                        txtStockCode.Focus()
                        DisplayInfoMessage("Msg02")
                        'MessageBox.Show("This Stock Code already exists for this block")
                        Return True
                    End If
                End If

                If Div <> String.Empty Then
                    If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() And Div = objDataGridViewRow.Cells("dgclDiv").Value.ToString() And BlockName = objDataGridViewRow.Cells("dgclBlockName").Value.ToString() Then
                        'ClearStockCodeRelatedFields()
                        txtStockCode.Focus()
                        DisplayInfoMessage("Msg03")
                        'MessageBox.Show("This Stock Code already exists for this DIV")
                        Return True
                    End If
                End If

                If VHNo <> String.Empty Then
                    If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() And VHNo = objDataGridViewRow.Cells("dgclVHNo").Value.ToString() Then
                        'ClearStockCodeRelatedFields()
                        txtStockCode.Focus()
                        DisplayInfoMessage("Msg04")
                        'MessageBox.Show("This Stock Code already exists for this Vehicle No")
                        Return True
                    End If
                End If

                If VHDetailsCostCode <> String.Empty Then
                    If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() And VHDetailsCostCode = objDataGridViewRow.Cells("dgclVHDetailCostCode").Value.ToString() Then
                        'ClearStockCodeRelatedFields()
                        txtStockCode.Focus()
                        DisplayInfoMessage("Msg04")
                        'MessageBox.Show("This Stock Code already exists for this Vehicle No")
                        Return True
                    End If
                End If

                If StationCode <> String.Empty Then
                    If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() And StationCode = objDataGridViewRow.Cells("dgclStation").Value.ToString() Then
                        'ClearStockCodeRelatedFields()
                        txtStockCode.Focus()
                        DisplayInfoMessage("Msg05")
                        'MessageBox.Show("This Stock Code already exists for this Station")
                        Return True
                    End If
                End If

                'If ((StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString()) And (txtDiv.Text = objDataGridViewRow.Cells("dgclDiv").Value.ToString() And txtVHNo.Text = objDataGridViewRow.Cells("dgclVHNo").Value.ToString() And (txtSubBlock.Text = objDataGridViewRow.Cells("dgclBlockName").Value.ToString() Or txtStation.Text = objDataGridViewRow.Cells("dgclStation").Value.ToString()))) Then
                '    'ClearStockCodeRelatedFields()
                '    txtStockCode.Focus()
                '    MessageBox.Show("This Stock Code already exists")
                '    Return True
                'End If

                'If ((StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString()) And (objDataGridViewRow.Cells("dgclDiv").Value.ToString() = String.Empty Or objDataGridViewRow.Cells("dgclVHNo").Value.ToString() = String.Empty Or (objDataGridViewRow.Cells("dgclBlockName").Value.ToString() = String.Empty Or objDataGridViewRow.Cells("dgclStation").Value.ToString() = String.Empty))) Then
                '    'ClearStockCodeRelatedFields()
                '    txtStockCode.Focus()
                '    DisplayInfoMessage("Msg06")
                '    'MessageBox.Show("This Stock Code already exists")
                '    Return True
                'End If


                If objDataGridViewRow.Cells("dgclStation").Value.ToString().Trim = String.Empty And txtStation.Text.Trim = String.Empty Then
                    If objDataGridViewRow.Cells("dgclBlockName").Value.ToString().Trim = String.Empty And txtSubBlock.Text.Trim = String.Empty Then
                        If objDataGridViewRow.Cells("dgclDiv").Value.ToString().Trim = String.Empty And txtDiv.Text.Trim = String.Empty Then
                            If objDataGridViewRow.Cells("dgclVHNo").Value.ToString().Trim = String.Empty And txtVHNo.Text.Trim = String.Empty Then
                                If objDataGridViewRow.Cells("dgclVHDetailCostCode").Value.ToString().Trim = String.Empty And txtVHDetailsCostCode.Text.Trim = String.Empty Then
                                    If objDataGridViewRow.Cells("dgclAccountCode").Value.ToString().Trim = String.Empty And txtAccountCode.Text.Trim = String.Empty Then
                                        If StockCode.Trim = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim Then
                                            txtStockCode.Focus()
                                            DisplayInfoMessage("Msg06")
                                            'MessageBox.Show("This Stock Code already exists")
                                            Return True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Next

            Return False

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Function

    Private Function StockCodeExistUpdateModeold(ByVal StockCode As String, ByVal BlockName As String, ByVal Div As String, ByVal VHNo As String, ByVal StationCode As String) As Boolean

        Try

            If psExistingBlockName.Trim <> String.Empty Then
                If psExistingStockCode.Trim = txtStockCode.Text.Trim() And psExistingBlockName.Trim = txtSubBlock.Text.Trim() Then
                    Return False
                End If
            End If

            If psExistingDiv.Trim <> String.Empty Then
                If psExistingStockCode.Trim = txtStockCode.Text.Trim() And psExistingDiv.Trim = txtDiv.Text.Trim() And psExistingBlockName.Trim = txtSubBlock.Text.Trim() Then
                    Return False
                End If
            End If

            If psExistingVHNo.Trim <> String.Empty Then
                If psExistingStockCode.Trim = txtStockCode.Text.Trim() And psExistingVHNo.Trim = txtVHNo.Text.Trim() Then
                    Return False
                End If

            ElseIf psExistingStationCode.Trim <> String.Empty Then
                If psExistingStockCode.Trim = txtStockCode.Text.Trim() And psExistingStationCode.Trim = txtStation.Text.Trim() Then
                    Return False
                End If

                'ElseIf ((psExistingStockCode <> String.Empty) And (psExistingDiv = String.Empty And psExistingVHNo = String.Empty And (psExistingStationCode = String.Empty Or psExistingStationCode = String.Empty))) Then
                '    If psExistingStockCode = txtStockCode.Text.Trim() Then
                '        Return False
                '    End If


            Else

                Dim objDataGridViewRow As New DataGridViewRow
                For Each objDataGridViewRow In dgIssueVoucher.Rows
                    If BlockName.Trim <> String.Empty Then
                        If StockCode.Trim = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim And BlockName.Trim = objDataGridViewRow.Cells("dgclBlockName").Value.ToString().Trim Then
                            'ClearStockCodeRelatedFields()
                            txtStockCode.Focus()
                            DisplayInfoMessage("Msg07")
                            'MessageBox.Show("This Stock Code already exists for this block")
                            Return True
                        End If
                    End If

                    If Div <> String.Empty Then
                        If StockCode.Trim = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim And Div.Trim = objDataGridViewRow.Cells("dgclDiv").Value.ToString().Trim And BlockName.Trim = objDataGridViewRow.Cells("dgclBlockName").Value.ToString().Trim Then
                            'ClearStockCodeRelatedFields()
                            txtStockCode.Focus()
                            DisplayInfoMessage("Msg08")
                            'MessageBox.Show("This Stock Code already exists for this DIV")
                            Return True
                        End If
                    End If

                    If VHNo.Trim <> String.Empty Then
                        If StockCode.Trim = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim And VHNo.Trim = objDataGridViewRow.Cells("dgclVHNo").Value.ToString().Trim Then
                            'ClearStockCodeRelatedFields()
                            txtStockCode.Focus()
                            DisplayInfoMessage("Msg09")
                            'MessageBox.Show("This Stock Code already exists for this Vehicle No")
                            Return True
                        End If
                    End If

                    If StationCode.Trim <> String.Empty Then
                        If StockCode.Trim = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim And StationCode.Trim = objDataGridViewRow.Cells("dgclStation").Value.ToString().Trim Then
                            'ClearStockCodeRelatedFields()
                            txtStockCode.Focus()
                            DisplayInfoMessage("Msg10")
                            'MessageBox.Show("This Stock Code already exists for this Station")
                            Return True
                        End If
                    End If

                    'If dgIssueVoucher.RowCount > 1 Then
                    If ((psExistingStockCode.Trim <> String.Empty) And (psExistingDiv.Trim = String.Empty And psExistingVHNo.Trim = String.Empty And (psExistingStationCode.Trim = String.Empty Or psExistingStationCode.Trim = String.Empty))) Then
                        If psExistingStockCode.Trim = txtStockCode.Text.Trim() Then
                            Return False
                        End If
                        If StockCode.Trim = objDataGridViewRow.Cells("dgclStockCode").Value.ToString().Trim Then
                            'ClearStockCodeRelatedFields()
                            txtStockCode.Focus()
                            DisplayInfoMessage("Msg11")
                            'MessageBox.Show("This Stock Code already exists")
                            Return True
                        End If
                    End If
                    ' End If

                Next

                Return False

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message())

        End Try

    End Function


    'Private Function StockCodeExist(ByVal StockCode As String) As Boolean

    '    Try
    '        Dim objDataGridViewRow As New DataGridViewRow
    '        For Each objDataGridViewRow In dgIssueVoucher.Rows
    '            If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
    '                txtStockCode.Text = String.Empty
    '                'txtRequestedQty.Text = string.empty 
    '                txtStockCode.Focus()
    '                Return True
    '            End If
    '        Next
    '        Return False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message())
    '    End Try

    'End Function

    'Private Function StockCodeExistUpdateMode(ByVal StockCode As String) As Boolean

    '    Try
    '        If psExistingStockCode = txtStockCode.Text.Trim() Then
    '            Return False
    '        Else
    '            Dim objDataGridViewRow As New DataGridViewRow
    '            For Each objDataGridViewRow In dgIssueVoucher.Rows
    '                If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
    '                    txtStockCode.Text = String.Empty
    '                    'txtRequestedQty.Text = string.empty 
    '                    txtStockCode.Focus()
    '                    Return True
    '                End If
    '            Next
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message())
    '    End Try

    'End Function

    Private Function ContractNoExist() As String

        Dim strContractNo As String = String.Empty
        Dim ds As New DataSet
        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        objStoreIssueVoucherPPT.ContractNo = txtContractNo.Text.Trim()
        ds = StoreIssueVoucherBOL.IsContractNoExist(objStoreIssueVoucherPPT)
        If ds.Tables(0).Rows.Count <> 0 Then
            If ds.Tables(0).Rows(0).Item("ContractNo") <> String.Empty Then
                strContractNo = ds.Tables(0).Rows(0).Item("ContractNo")
            End If
        Else
            strContractNo = "NotExist"
            Return strContractNo
        End If

        Return strContractNo

    End Function

    Private Function IsValidFields() As Boolean
        Dim objBOL As New GlobalBOL
        Dim RequiredField As String
        'Added by Stanley@25-07-2011
        Dim OpenIssuedSIVQty, AvailQty As Double

        If (txtSIVNo.Text.Trim() = "") Then
            DisplayInfoMessage("Msg12")
            'MessageBox.Show("SIV Number not entered", "Please enter SIV Number ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSIVNo.Focus()
            Return False
        End If

        If (txtStockCategory.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg13")
            'MessageBox.Show("Stock Category not Selected", "Please select Stock Category ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCategory.Focus()
            Return False
        End If
        If (txtStockCode.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg14")
            'MessageBox.Show("Stock Code not Selected", "Please select Stock Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCode.Focus()
            Return False
        End If
        If (txtQtyIssued.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg15")
            'MessageBox.Show("Quantity Issued is Empty", "Please give Quantity Issued", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQtyIssued.Focus()
            Return False
        End If
        If txtQtyIssued.Text.Trim() <> String.Empty Then
            If (CDbl(txtQtyIssued.Text.Trim()) <= 0) Then
                DisplayInfoMessage("Msg16")
                'MessageBox.Show("Quantity Issued should be greater than zero", "Please give Quantity Issued", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQtyIssued.Text = String.Empty
                txtQtyIssued.Focus()
                Return False
            End If
        End If

        ''If (lblAvailableQty.Text.Trim() = String.Empty) Then
        ''    MessageBox.Show("Available quantity should be greater than zero")
        ''    Return False
        ''End If
        If (lblAvailableQty.Text.Trim() <> String.Empty) Then
            If (CDbl(lblAvailableQty.Text.Trim()) <= 0) Then
                DisplayInfoMessage("Msg17")
                'MessageBox.Show("Available quantity should be greater than zero")
                Return False
            End If

        End If

        If lblAvailableQty.Text.Trim() <> String.Empty And txtQtyIssued.Text.Trim() <> String.Empty Then
            OpenIssuedSIVQty = StoreIssueVoucherBOL.STIssueDetailsOpenQtyCheck(psSIVStockID, txtSIVNo.Text.Trim())
            If lblAvailableQty.Text.Trim() <= OpenIssuedSIVQty Then
                AvailQty = 0
            Else
                AvailQty = CDbl(lblAvailableQty.Text.Trim()) - OpenIssuedSIVQty
            End If

            'Commented by Stanley @25-07-2011 If CDbl(txtQtyIssued.Text) > CDbl(lblAvailableQty.Text.Trim()) Then
            If CDbl(txtQtyIssued.Text) > AvailQty Then
                'Commented by Stanley@25-07-2011 DisplayInfoMessage("Msg18")
                'MessageBox.Show("Quantity issued should not be more than available quantity")
                MessageBox.Show("There is not enough stock available for the stock item " + psSIVStockCode + ", there are issued quantities of " + CStr(OpenIssuedSIVQty) + " pending approval. Actual Available stock is " + CStr(AvailQty) + ".")
                txtQtyIssued.Focus()
                Return False
            End If
        End If
        If txtContractNo.Text.Trim() = String.Empty Then

            If (txtAccountCode.Text.Trim() = String.Empty) Then
                DisplayInfoMessage("Msg19")
                'MessageBox.Show("AccountCode is Empty", "Please give AccountCode ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAccountCode.Focus()
                Return False
            End If
        End If
        If (txtT0.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg20")
            'MessageBox.Show("T0 is Empty", "Please give T0 value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtT0.Focus()
            Return False
        End If

        ''If GlobalPPT.psEstateType = "M" Then
        ''    If (txtStation.Text.Trim() = String.Empty) Then
        ''        MessageBox.Show("Station is Empty", "Please give Station value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ''        txtStation.Focus()
        ''        Return False
        ''    End If
        ''End If

        If txtODOReading.Text <> String.Empty Then
            If (txtODOReading.Text <> "0.00") Then
                If (txtODOReading.Text <> "0") Then
                    If txtVHNo.Text = String.Empty Then
                        DisplayInfoMessage("Msg21")
                        'MessageBox.Show("VHNo/WorkshopNo is empty")
                        txtVHNo.Focus()
                        Return False
                    End If
                    If txtVHDetailsCostCode.Text = String.Empty Then
                        DisplayInfoMessage("Msg22")
                        'MessageBox.Show("VH Details Cost Code is empty")
                        txtVHDetailsCostCode.Focus()
                        Return False
                    End If
                End If
            End If
        End If

        If txtVHNo.Text <> String.Empty Then
            If txtVHDetailsCostCode.Text = String.Empty Then
                DisplayInfoMessage("Msg23")
                'MessageBox.Show("VH Details Cost Code is empty")
                txtVHDetailsCostCode.Focus()
                Return False
            End If
        End If
        If txtVHDetailsCostCode.Text <> String.Empty Then
            If txtVHNo.Text = String.Empty Then
                DisplayInfoMessage("Msg24")
                'MessageBox.Show("VHNo/WorkshopNo is empty")
                txtVHNo.Focus()
                Return False
            End If
        End If
        'START---AN06042010 ---To be called from all transaction screen, wherever the combination of Account Code, Sub Block, _
        'Vehicle code input fields exist.
        If txtAccountCode.Text <> String.Empty Then
            RequiredField = String.Empty

            If objBOL.IsSetMandatoryInCOA(psSIVAccountID, "AccountControl", "STORE", RequiredField) Then
                If RequiredField <> String.Empty Then
                    'DisplayInfoMessage("Msg25")
                    MsgBox(rm.GetString("Msg25") & RequiredField)
                    'MessageBox.Show("This Account Code is allowed only for " & RequiredField)
                    Return False
                End If
            End If
        End If

        If txtAccountCode.Text <> String.Empty And txtSubBlock.Text.Trim = String.Empty Then
            RequiredField = String.Empty
            If objBOL.IsSetMandatoryInCOA(psSIVAccountID, "SubType", "STORE", RequiredField) Then
                If RequiredField = "Sub Block Code" Then
                    'DisplayInfoMessage("Msg26")
                    MsgBox(rm.GetString("Msg26") & RequiredField)
                    'MessageBox.Show("This Account Code required a " & RequiredField)
                    Return False
                End If
            End If
        End If

        If txtAccountCode.Text <> String.Empty And txtVHNo.Text.Trim = String.Empty Then
            RequiredField = String.Empty
            If objBOL.IsSetMandatoryInCOA(psSIVAccountID, "SubType", "STORE", RequiredField) Then
                If RequiredField = "Vehicle Code" Then
                    MsgBox(rm.GetString("Msg27") & RequiredField)
                    'DisplayInfoMessage("Msg27")
                    'MessageBox.Show("This Account Code required a " & RequiredField)
                    Return False
                End If
            End If
        End If
        'END -- AN06042010 --To be called from all transaction screen, whereever the combination of Account Code, Sub Block, Vehicle code exist.

        If txtAccountCode.Text <> String.Empty And txtSubBlock.Text <> String.Empty Then

            If Not objBOL.PbIsSameMaturityStatus(lsVDExpenditureAG, lblSubBlockName.Text) Then
                DisplayInfoMessage("Msg28")
                'MessageBox.Show("Invalid Combination of Account Code and Sub Block")
                Return False
            End If
        End If



        'If (txtContractNo.Text.Trim() = String.Empty) Then
        '    MessageBox.Show("Contract No Empty", "Please give Contract no", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtContractNo.Focus()
        '    Return False
        'Else If 
        '    If ContractNoExist() = "NotExist" Then
        '        MessageBox.Show("Contract No not exist,Please select it from lookup")
        '        Return False
        '    End If
        'End If

        'Commented by Sanley @25-07-2011
        'If lblAvailableQty.Text.Trim <> String.Empty Then
        '    If CDbl(lblAvailableQty.Text.Trim) < StoreIssueVoucherBOL.STIssueDetailsIssuedQtyCheck(psSIVStockID, txtQtyIssued.Text.Trim) Then
        '        DisplayInfoMessage("Msg83")
        '        'MessageBox.Show("There is no enough stock available for the stock item " + psSIVStockCode)
        '        Return False
        '    End If
        'End If

        Return True

    End Function


    'Private Function IsValidFields() As Boolean

    '    If (txtSIVNo.Text.Trim() = "") Then
    '        MessageBox.Show("SIV Number not entered", "Please enter SIV Number ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtSIVNo.Focus()
    '        Return False
    '    End If

    '    If (txtStockCategory.Text.Trim() = String.Empty) Then
    '        MessageBox.Show("Stock Category not Selected", "Please select Stock Category ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtStockCategory.Focus()
    '        Return False
    '    End If
    '    If (txtStockCode.Text.Trim() = String.Empty) Then
    '        MessageBox.Show("Stock Code not Selected", "Please select Stock Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtStockCode.Focus()
    '        Return False
    '    End If
    '    If (txtQtyIssued.Text.Trim() = String.Empty) Then
    '        MessageBox.Show("Quantity Issued is Empty", "Please give Quantity Issued", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtQtyIssued.Focus()
    '        Return False
    '    End If
    '    If txtQtyIssued.Text.Trim() <> String.Empty Then
    '        If (CDbl(txtQtyIssued.Text.Trim()) <= 0) Then
    '            MessageBox.Show("Quantity Issued should be greater than zero", "Please give Quantity Issued", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtQtyIssued.Text = String.Empty
    '            txtQtyIssued.Focus()
    '            Return False
    '        End If
    '    End If

    '    ''If (lblAvailableQty.Text.Trim() = String.Empty) Then
    '    ''    MessageBox.Show("Available quantity should be greater than zero")
    '    ''    Return False
    '    ''End If
    '    If (lblAvailableQty.Text.Trim() <> String.Empty) Then
    '        If (CDbl(lblAvailableQty.Text.Trim()) <= 0) Then
    '            MessageBox.Show("Available quantity should be greater than zero")
    '            Return False
    '        End If

    '    End If
    '    If lblAvailableQty.Text.Trim() <> String.Empty And txtQtyIssued.Text.Trim() <> String.Empty Then
    '        If CDbl(txtQtyIssued.Text) > CDbl(lblAvailableQty.Text) Then
    '            MessageBox.Show("Quantity issued should not be more than available quantity")
    '            txtQtyIssued.Focus()
    '            Return False
    '        End If
    '    End If
    '    If txtContractNo.Text.Trim() = String.Empty Then

    '        If (txtAccountCode.Text.Trim() = String.Empty) Then
    '            MessageBox.Show("AccountCode is Empty", "Please give AccountCode ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtAccountCode.Focus()
    '            Return False
    '        End If
    '    End If
    '    If (txtT0.Text.Trim() = String.Empty) Then
    '        MessageBox.Show("T0 is Empty", "Please give T0 value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtT0.Focus()
    '        Return False
    '    End If

    '    ''If GlobalPPT.psEstateType = "M" Then
    '    ''    If (txtStation.Text.Trim() = String.Empty) Then
    '    ''        MessageBox.Show("Station is Empty", "Please give Station value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    ''        txtStation.Focus()
    '    ''        Return False
    '    ''    End If
    '    ''End If

    '    If txtODOReading.Text <> String.Empty Then
    '        If txtODOReading.Text <> "0.00" Then
    '            If txtVHNo.Text = String.Empty Then
    '                MessageBox.Show("VHNo is empty")
    '                txtVHNo.Focus()
    '                Return False
    '            End If
    '            If txtVHDetailsCostCode.Text = String.Empty Then
    '                MessageBox.Show("VH Details Cost Code is empty")
    '                txtVHDetailsCostCode.Focus()
    '                Return False
    '            End If
    '        End If

    '    End If

    '    If txtAccountCode.Text <> String.Empty And txtSubBlock.Text <> String.Empty Then
    '        Dim objBOL As New GlobalBOL
    '        If Not objBOL.PbIsSameMaturityStatus(lsVDExpenditureAG, lblSubBlockName.Text) Then
    '            MessageBox.Show("Invalid Combination of Account Code and Sub Block")
    '            Return False
    '        End If
    '    End If
    '    'If (txtContractNo.Text.Trim() = String.Empty) Then
    '    '    MessageBox.Show("Contract No Empty", "Please give Contract no", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    '    txtContractNo.Focus()
    '    '    Return False
    '    'Else If 
    '    '    If ContractNoExist() = "NotExist" Then
    '    '        MessageBox.Show("Contract No not exist,Please select it from lookup")
    '    '        Return False
    '    '    End If
    '    'End If
    '    Return True

    'End Function


    Private Function ValidQtyIssued() As Boolean

        Dim ldQtyIssued As Double
        Dim GridViewRow As DataGridViewRow
        For Each GridViewRow In dgIssueVoucher.Rows
            If GridViewRow.Cells("dgclIssuedQty").Value.ToString() <> String.Empty Then
                ldQtyIssued += CDbl(GridViewRow.Cells("dgclIssuedQty").Value)
            End If
        Next
        If txtIssueBatchTotal.Text.Trim() <> String.Empty Then
            If ldQtyIssued > CDbl(txtIssueBatchTotal.Text) Then
                Return False
            Else
                Return True
            End If
        End If

    End Function

    Private Sub SaveAll()

        Dim rowaffected As Integer = 0
        If IsValidSaveAll() = False Then
            Exit Sub
        End If

        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        Dim intResult As Integer = 0
        objStoreIssueVoucherPPT.SIVNO = txtSIVNo.Text.Trim()
        objStoreIssueVoucherPPT.SIVDate = dtpSIVDate.Value 'Format(dtpSIVDate.Value, "MM/dd/yyyy")
        objStoreIssueVoucherPPT.ContractID = psSIVContractId
        'objStoreIssueVoucherPPT.Status = lblStatus.Text
        objStoreIssueVoucherPPT.Status = "OPEN"
        If txtIssueBatchTotal.Text.Trim() <> String.Empty Then
            objStoreIssueVoucherPPT.IssueBatchTotal = CDbl(txtIssueBatchTotal.Text)
        End If
        objStoreIssueVoucherPPT.Remarks = txtRemarks.Text.Trim()
        objStoreIssueVoucherPPT.RejectedReason = txtRejectedReason.Text.Trim()
        objStoreIssueVoucherPPT.STIssueBatchID = psSIVIssueBatchID
        Dim dsSTIssueInsert, dsSTIssueUpdate As New DataSet

        'If btnSaveAll.Text.Trim() = "Save All" Then 
        If psIssueIDVal = String.Empty Then
            'If ValidQtyIssued() = False Then
            '    'MessageBox.Show("Quantity Issued is more than the SIV Batch total value")
            '    'Exit Sub
            'Else
            dsSTIssueInsert = StoreIssueVoucherBOL.saveStoreIssueVoucher(objStoreIssueVoucherPPT)
            If dsSTIssueInsert Is Nothing Then
                DisplayInfoMessage("Msg29")
                'MsgBox("Failed to save database")
                Exit Sub
            Else
                If dsSTIssueInsert.Tables(0).Rows.Count > 0 Then
                    psSIVSTIssueId = dsSTIssueInsert.Tables(0).Rows(0).Item("STIssueID").ToString()
                    objStoreIssueVoucherPPT.STIssueID = psSIVSTIssueId
                Else
                    DisplayInfoMessage("Msg30")
                    'MessageBox.Show("Failed to save database")
                    Exit Sub
                End If
                'End If

            End If
            'ElseIf btnSaveAll.Text.Trim() = "Update All" Then
        ElseIf psIssueIDVal <> String.Empty Then
            DeleteMultiEntryRecords()
            objStoreIssueVoucherPPT.STIssueID = dgIssueVoucher.CurrentRow.Cells("dgclSTIssueId").Value.ToString()
            dsSTIssueUpdate = StoreIssueVoucherBOL.updateStoreIssueVoucher(objStoreIssueVoucherPPT, "NO")

            'MsgBox("Data Successfully Updated")
        End If

        Dim DataGridViewRow As DataGridViewRow

        If psIssueIDVal = String.Empty Then
            If IsValidSaveAll() = False Then
                Exit Sub
            End If
            'If ValidQtyIssued() = False Then
            '    MessageBox.Show("Quantity Issued is more than the SIV Batch total value")
            '    Exit Sub
            'End If
            Dim dsSTIssueDetailsInsert As New DataSet
            For Each DataGridViewRow In dgIssueVoucher.Rows

                With objStoreIssueVoucherPPT
                    '.STIssueID = DataGridViewRow.Cells("dgclSTIssueId").Value.ToString()
                    .STIssueID = psSIVSTIssueId 'dgclSTIssueId
                    .StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
                    If DataGridViewRow.Cells("dgclIssuedQty").Value.ToString() <> String.Empty Then
                        .IssuedQty = CDbl(DataGridViewRow.Cells("dgclIssuedQty").Value)
                    End If
                    If DataGridViewRow.Cells("dgclAvailQty").Value.ToString() <> String.Empty Then
                        .AvailQty = CDbl(DataGridViewRow.Cells("dgclAvailQty").Value)
                    End If
                    .usedFor = DataGridViewRow.Cells("dgclUsedFor").Value.ToString()
                    If txtContractNo.Text.Trim() = String.Empty Then
                        .COAID = DataGridViewRow.Cells("dgclAccountId").Value.ToString()
                    Else
                        .COAID = psSIVAccountID
                    End If
                    '.usedFor = DataGridViewRow.Cells("dgclUsedFor").Value.ToString()
                    .T0 = DataGridViewRow.Cells("dgclT0Id").Value.ToString() 'dgclT0Id
                    .T1 = DataGridViewRow.Cells("dgclT1Id").Value.ToString()
                    .T2 = DataGridViewRow.Cells("dgclT2Id").Value.ToString()
                    .T3 = DataGridViewRow.Cells("dgclT3Id").Value.ToString()
                    .T4 = DataGridViewRow.Cells("dgclT4Id").Value.ToString()
                    .DivID = DataGridViewRow.Cells("dgclDivId").Value.ToString()
                    .YOPID = DataGridViewRow.Cells("dgclYOPID").Value.ToString()
                    .BlockID = DataGridViewRow.Cells("dgclSubBlock").Value.ToString()
                    .StationID = DataGridViewRow.Cells("dgclStationID").Value.ToString()
                    .VHID = DataGridViewRow.Cells("dgclVHID").Value.ToString()
                    .VHDetailCostCodeID = DataGridViewRow.Cells("dgclVHDetailCostCodeID").Value.ToString()
                    If DataGridViewRow.Cells("dgclOdoReading").Value.ToString <> String.Empty Then
                        .ODOReading = DataGridViewRow.Cells("dgclOdoReading").Value
                    End If
                    ''Dim dsIssue As New DataSet
                    ''dsIssue = StoreIssueVoucherBOL.STIssueAvgPriceGet(objStoreIssueVoucherPPT)
                    ''If dsIssue.Tables(0).Rows.Count > 0 Then
                    ''    .IssueUnitPrice = dsIssue.Tables(0).Rows(0).Item("AvgPrice")
                    ''End If
                    ''If .IssueUnitPrice <> 0 Then
                    ''    .IssuedValue = .IssueUnitPrice * .IssuedQty
                    ''End If

                    objStoreIssueVoucherPPT.IssueUnitPrice = 0
                    objStoreIssueVoucherPPT.IssuedValue = 0
                End With
                dsSTIssueDetailsInsert = StoreIssueVoucherBOL.saveStoreIssueVoucherDetails(objStoreIssueVoucherPPT)
            Next
            If dsSTIssueDetailsInsert Is Nothing Then
                DisplayInfoMessage("Msg31")
                'MsgBox("Failed to save details in database")
                'delete heder table query
                StoreIssueVoucherBOL.DeleteStoreIssueVoucher(objStoreIssueVoucherPPT)
            Else
                DisplayInfoMessage("Msg32")
                'MsgBox("Data Successfully Saved")
                'fillComboSIVNo()
                txtStockCode.Enabled = True
                btnSearchStockCode.Enabled = True
                'btnSaveAll.Text = "Save All"
                If GlobalPPT.strLang = "en" Then
                    btnSaveAll.Text = "Save All"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveAll.Text = "Simpan Semua"
                End If
                StoreIssueVoucherBOL.ClearGridView(dgIssueVoucher)
                ClearAll()
                'cmbSIVNO.Text = "--Select SIV No--"
                lblStatus.Text = "OPEN"
                ''''txtStockCategory.Enabled = True
                txtStockCategory.Text = String.Empty
                ''''btnSearchStockCategory.Enabled = True
            End If



        ElseIf psIssueIDVal <> String.Empty Then
            If IsValidSaveAll() = False Then
                Exit Sub
            End If
            ''If ValidQtyIssued() = False Then
            ''    MessageBox.Show("Quantity Issued is more than the SIV Batch total value")
            ''    Exit Sub
            ''End If
            Dim dsSTIssueDetailsUpdate As New DataSet
            For Each DataGridViewRow In dgIssueVoucher.Rows

                With objStoreIssueVoucherPPT
                    'check for empty stissueid
                    .STIssueID = psSIVSTIssueId 'DataGridViewRow.Cells("dgclSTIssueId").Value.ToString()
                    objStoreIssueVoucherPPT.STIssueDetailsID = DataGridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString()

                    .StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
                    If (DataGridViewRow.Cells("dgclIssuedQty").Value.ToString() <> String.Empty) Then
                        .IssuedQty = CDbl(DataGridViewRow.Cells("dgclIssuedQty").Value)
                    End If
                    If DataGridViewRow.Cells("dgclAvailQty").Value.ToString() <> String.Empty Then
                        .AvailQty = CDbl(DataGridViewRow.Cells("dgclAvailQty").Value)
                    End If
                    .usedFor = DataGridViewRow.Cells("dgclUsedFor").Value.ToString()
                    '.COAID = psSIVAccountID
                    If txtContractNo.Text.Trim() = String.Empty Then
                        .COAID = DataGridViewRow.Cells("dgclAccountId").Value.ToString()
                    Else
                        .COAID = psSIVAccountID
                    End If
                    .T0 = DataGridViewRow.Cells("dgclT0Id").Value.ToString() 'dgclT0Id
                    .T1 = DataGridViewRow.Cells("dgclT1Id").Value.ToString()
                    .T2 = DataGridViewRow.Cells("dgclT2Id").Value.ToString()
                    .T3 = DataGridViewRow.Cells("dgclT3Id").Value.ToString()
                    .T4 = DataGridViewRow.Cells("dgclT4Id").Value.ToString()
                    .DivID = DataGridViewRow.Cells("dgclDivId").Value.ToString()
                    .YOPID = DataGridViewRow.Cells("dgclYOPID").Value.ToString()
                    .BlockID = DataGridViewRow.Cells("dgclSubBlock").Value.ToString()
                    .StationID = DataGridViewRow.Cells("dgclStationID").Value.ToString()
                    '.StationID = "1"
                    .VHID = DataGridViewRow.Cells("dgclVHID").Value.ToString()
                    .VHDetailCostCodeID = DataGridViewRow.Cells("dgclVHDetailCostCodeID").Value.ToString()
                    If DataGridViewRow.Cells("dgclOdoReading").Value.ToString() <> String.Empty Then
                        .ODOReading = DataGridViewRow.Cells("dgclOdoReading").Value
                    End If
                    ''Dim dsIssue As New DataSet
                    ''dsIssue = StoreIssueVoucherBOL.STIssueAvgPriceGet(objStoreIssueVoucherPPT)
                    ''If dsIssue.Tables(0).Rows.Count > 0 Then
                    ''    .IssueUnitPrice = dsIssue.Tables(0).Rows(0).Item("AvgPrice")
                    ''End If
                    ''If .IssueUnitPrice <> 0 Then
                    ''    .IssuedValue = .IssueUnitPrice * .IssuedQty
                    ''End If
                    objStoreIssueVoucherPPT.IssueUnitPrice = 0
                    objStoreIssueVoucherPPT.IssuedValue = 0

                End With
                If DataGridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString <> String.Empty Then
                    dsSTIssueDetailsUpdate = StoreIssueVoucherBOL.updateStoreIssueVoucherDetails(objStoreIssueVoucherPPT)
                Else
                    dsSTIssueDetailsUpdate = StoreIssueVoucherBOL.saveStoreIssueVoucherDetails(objStoreIssueVoucherPPT)
                End If
            Next
            If dsSTIssueDetailsUpdate Is Nothing Then
                DisplayInfoMessage("Msg33")
                'MsgBox("Failed to update details in database")
            Else
                DisplayInfoMessage("Msg34")
                'MsgBox("Data Successfully Updated")
                'fillComboSIVNo()
                ''''txtStockCategory.Enabled = True
                txtStockCategory.Text = String.Empty
                ''''btnSearchStockCategory.Enabled = True
                txtStockCode.Enabled = True
                btnSearchStockCode.Enabled = True
                'btnSaveAll.Text = "Save All"
                If GlobalPPT.strLang = "en" Then
                    btnSaveAll.Text = "Save All"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveAll.Text = "Simpan Semua"
                End If
                lblStatus.Text = "OPEN"
                '
                lblRejectedReasonValue.Visible = False
                lblRejectedReason1.Visible = False
                lblRejReasonColon.Visible = False
                '
                'btnAdd.Text = "Add"
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                psIssueIDVal = String.Empty
                ''lblQtyIssued.Text = string.empty 

                ' ''STIssueBtachValueUpdate'
                ''Dim intQtyIssued As Integer
                ''Dim GridViewRow As DataGridViewRow
                ''For Each GridViewRow In dgIssueVoucher.Rows
                ''    If GridViewRow.Cells("dgclIssuedQty").Value.ToString() <> string.empty  Then
                ''        intQtyIssued += cdbl(GridViewRow.Cells("dgclIssuedQty").Value)
                ''    End If
                ''Next
                ''objStoreIssueVoucherPPT.IssuedQty = intQtyIssued
                ''StoreIssueVoucherBOL.STIssueBtachValueUpdate(objStoreIssueVoucherPPT)
            End If
            ClearAll()
            'txtStockCategory.Text = string.empty 
            'cmbSIVNO.Text = "--Select SIV No--"
            'ComboSelectedFunction()
            txtIssueBatchTotal.Text = String.Empty
            txtSIVNo.Focus()
            StoreIssueVoucherBOL.ClearGridView(dgIssueVoucher)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    'Private Sub SaveFunction()

    'End Sub

    'Private Sub SaveAllFunction()

    'End Sub

    'Private Sub UpdateFunction()

    'End Sub

    'Private Sub UpdateAllFunction()

    'End Sub

    Private Function IsValidSaveAll() As Boolean

        'If (cmbSIVNO.SelectedIndex = -1) Then
        '    MessageBox.Show("SIV Number not Selected", "Please select SIV Number ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cmbSIVNO.Focus()
        '    Return False
        'End If

        '' If btnSaveAll.Text = "Save All" Or btnSaveAll.Text = "Simpan" Then
        If dgIssueVoucher.Rows.Count = 0 Then
            DisplayInfoMessage("Msg35")
            'MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStockCategory.Focus()
            Return False
        End If
        ''End If
        ''If btnSaveAll.Text = "Update All" Then ' in and condtition add indonesia word for update all and validate
        ''    If dgIssueVoucher.Rows.Count = 0 Then
        ''        MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''        txtStockCategory.Focus()
        ''        Return False
        ''    End If
        ''End If
        'If txtODOReading.Text <> string.empty  Then
        '    If txtVHNo.Text = string.empty  Then
        '        MessageBox.Show("VHNo is empty")
        '        txtVHNo.Focus()
        '        Return False
        '    End If
        '    If txtVHDetailsCostCode.Text = string.empty  Then
        '        MessageBox.Show("VH Details Cost Code is empty")
        '        txtVHDetailsCostCode.Focus()
        '        Return False
        '    End If
        'End If
        Return True

    End Function

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged

        If cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            lblRejectedReason.Visible = True
            lblRejectedColon.Visible = True
            txtRejectedReason.Visible = True
        Else
            lblRejectedReason.Visible = False
            lblRejectedColon.Visible = False
            txtRejectedReason.Visible = False
        End If

    End Sub

    Private Sub txtContractNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractNo.Leave

        If txtContractNo.Text.Trim() <> String.Empty Then
            Try
                Dim ds As New DataSet
                Dim objContractId As New StoreIssueVoucherPPT
                objContractId.ContractNo = txtContractNo.Text.Trim()
                ds = StoreIssueVoucherBOL.ContractIDSearch(objContractId, "YES")
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("ContractName") <> String.Empty Then
                        lblContractorValue.Text = ds.Tables(0).Rows(0).Item("ContractName")
                    End If
                    psSIVContractId = ds.Tables(0).Rows(0).Item("ContractID")
                    If ds.Tables(0).Rows(0).Item("COAID") <> String.Empty Then
                        psSIVAccountID = ds.Tables(0).Rows(0).Item("COAID")
                    End If
                    If ds.Tables(0).Rows(0).Item("COACode") <> String.Empty Then
                        Me.txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                    End If
                    If ds.Tables(0).Rows(0).Item("COADescp") <> String.Empty Then
                        Me.lblAccountDesc.Text = ds.Tables(0).Rows(0).Item("COADescp")
                    End If
                    If ds.Tables(0).Rows(0).Item("OldCOACode") <> String.Empty Then
                        Me.lblOldAccountCode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                    End If

                    DisableFieldsOnLeaveIFContractor()
                Else
                    DisplayInfoMessage("Msg36")
                    'MessageBox.Show("Invalid Contract No,Please Choose it from look up")
                    txtContractNo.Text = String.Empty
                    EnableFieldsOnLeaveIFContractor()
                    txtContractNo.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            EnableFieldsOnLeaveIFContractor()
        End If

    End Sub

    Private Sub DisableFieldsOnLeaveIFContractor()

        btnSearchAccountCode.Enabled = False
        txtAccountCode.Enabled = False
        'disable
        txtSubBlock.Enabled = False
        btnSearchSubBlock.Enabled = False

        txtStation.Text = String.Empty
        lblStationDesc.Text = String.Empty
        psSIVStationID = String.Empty
        txtStation.Enabled = False
        txtStation.Enabled = False
        btnSearchStation.Enabled = False

        txtODOReading.Enabled = False
        txtVHNo.Enabled = False
        btnSearchVHNo.Enabled = False
        txtVHDetailsCostCode.Enabled = False
        btnSearchVHcostCode.Enabled = False
        'disable

        'clear
        txtSubBlock.Text = String.Empty
        psSIVBlockID = String.Empty
        lblSubBlockName.Text = String.Empty
        txtDiv.Text = String.Empty
        psSIVDivID = String.Empty
        lblDivName.Text = String.Empty
        txtYOP.Text = String.Empty
        lblYOPName.Text = String.Empty
        psSIVYopID = String.Empty
        txtODOReading.Text = String.Empty
        txtVHNo.Text = String.Empty
        lblVHDescp.Text = String.Empty
        psSIVVHID = String.Empty
        psSIVVHCategoryID = String.Empty
        psSIVVHType = String.Empty
        txtVHDetailsCostCode.Text = String.Empty
        lblVHDetailDescp.Text = String.Empty
        '        psSIVVHDetCostCodType = String.Empty
        psSIVVHDetailsCostCodeId = String.Empty
        'clear

    End Sub

    Private Sub EnableFieldsOnLeaveIFContractor()

        txtContractNo.Text = String.Empty
        lblContractorValue.Text = String.Empty
        psSIVContractId = String.Empty
        psSIVContractNo = String.Empty
        btnSearchAccountCode.Enabled = True
        txtAccountCode.Enabled = True
        txtAccountCode.Text = String.Empty
        lblAccountDesc.Text = String.Empty
        lblOldAccountCode.Text = String.Empty
        psSIVAccountID = String.Empty
        psSIVOldAccountID = String.Empty
        GlobalPPT.psAcctExpenditureType = String.Empty
        'enable
        'If GlobalPPT.psEstateType = "M" Then
        '    txtStation.Text = String.Empty
        '    lblStationDesc.Text = String.Empty
        '    psSIVStationID = String.Empty
        '    txtStation.Enabled = True
        '    btnSearchStation.Enabled = True
        '    txtSubBlock.Enabled = False
        '    btnSearchSubBlock.Enabled = False
        'Else
        '    txtStation.Text = String.Empty
        '    lblStationDesc.Text = String.Empty
        '    psSIVStationID = String.Empty
        '    txtStation.Enabled = False
        '    txtStation.Enabled = False
        '    btnSearchStation.Enabled = False
        '    txtSubBlock.Enabled = True
        '    btnSearchSubBlock.Enabled = True
        'End If
        StationEnableAndDisable()
        txtODOReading.Text = String.Empty
        txtODOReading.Enabled = True

        txtVHNo.Text = String.Empty
        txtVHNo.Enabled = True
        lblVHDescp.Text = String.Empty
        psSIVVHID = String.Empty
        psSIVVHCategoryID = String.Empty
        psSIVVHType = String.Empty

        txtVHDetailsCostCode.Text = String.Empty
        lblVHDetailDescp.Text = String.Empty
        psSIVVHDetailsCostCodeId = String.Empty
        '        psSIVVHDetCostCodType = String.Empty
        txtVHDetailsCostCode.Enabled = True

        btnSearchVHNo.Enabled = True
        btnSearchVHcostCode.Enabled = True
        'enable

    End Sub

    Private Sub btnSearchContractNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchContractNo.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmContratNoLookup As New ContractNoLookup
        frmContratNoLookup.ShowDialog()
        If frmContratNoLookup.strContractId <> String.Empty Then
            Me.txtContractNo.Text = frmContratNoLookup.strContractNo
            psSIVContractId = frmContratNoLookup.strContractId
            Me.lblContractorValue.Text = frmContratNoLookup.strContractName
            psSIVAccountID = frmContratNoLookup.strContractCOAID
            Me.txtAccountCode.Text = frmContratNoLookup.strContractCOACode
            Me.lblAccountDesc.Text = frmContratNoLookup.strContractCOADescp
            Me.lblOldAccountCode.Text = frmContratNoLookup.strContractOldCOACode
            If txtContractNo.Text.Trim() <> String.Empty Then
                DisableFieldsOnClickIFContractor()
            Else
                EnableFieldsOnClickIFContractor()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EnableFieldsOnClickIFContractor()

        btnSearchAccountCode.Enabled = True
        txtAccountCode.Enabled = True
        txtSubBlock.Enabled = True
        btnSearchSubBlock.Enabled = True

        'If GlobalPPT.psEstateType = "M" Then
        '    txtStation.Text = String.Empty
        '    lblStationDesc.Text = String.Empty
        '    psSIVStationID = String.Empty
        '    txtStation.Enabled = True
        '    btnSearchStation.Enabled = True
        'Else
        '    txtStation.Text = String.Empty
        '    lblStationDesc.Text = String.Empty
        '    psSIVStationID = String.Empty
        '    txtStation.Enabled = False
        '    txtStation.Enabled = False
        '    btnSearchStation.Enabled = False
        'End If
        StationEnableAndDisable()
        txtVHNo.Enabled = True
        txtVHDetailsCostCode.Enabled = True
        txtODOReading.Enabled = True
        btnSearchVHNo.Enabled = True
        btnSearchVHcostCode.Enabled = True

    End Sub

    Private Sub DisableFieldsOnClickIFContractor()

        'disable
        btnSearchAccountCode.Enabled = False
        txtAccountCode.Enabled = False

        txtSubBlock.Text = String.Empty
        psSIVBlockID = String.Empty
        lblSubBlockName.Text = String.Empty
        txtSubBlock.Enabled = False
        btnSearchSubBlock.Enabled = False

        Me.txtYOP.Text = String.Empty
        Me.lblYOPName.Text = String.Empty
        psSIVYopID = String.Empty
        txtYOP.Enabled = False

        Me.txtDiv.Text = String.Empty
        Me.lblDivName.Text = String.Empty
        psSIVDivID = String.Empty
        txtDiv.Enabled = False
        btnSearchDiv.Enabled = False

        txtStation.Text = String.Empty
        lblStationDesc.Text = String.Empty
        psSIVStationID = String.Empty
        txtStation.Enabled = False
        txtStation.Enabled = False
        btnSearchStation.Enabled = False

        txtVHNo.Text = String.Empty
        lblVHDescp.Text = String.Empty
        txtVHNo.Enabled = False
        psSIVVHID = String.Empty
        psSIVVHCategoryID = String.Empty
        psSIVVHType = String.Empty

        txtVHDetailsCostCode.Enabled = False
        txtVHDetailsCostCode.Text = String.Empty
        lblVHDetailDescp.Text = String.Empty
        psSIVVHDetailsCostCodeId = String.Empty
        '        psSIVVHDetCostCodType = String.Empty

        txtODOReading.Text = String.Empty
        txtODOReading.Enabled = False
        btnSearchVHNo.Enabled = False
        btnSearchVHcostCode.Enabled = False
        'disable

    End Sub

    Private Sub txtStockCategory_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCategory.Leave

        NonStockIPRFrm.StrFrmName = "SIV"
        If txtStockCategory.Text.Trim() <> String.Empty Then

            Dim dt As New DataTable
            Dim CategoryDesc As String
            Dim objIPRPPT As New StoreIssueVoucherPPT
            Dim objIPRData As New StoreIssueVoucherBOL
            CategoryDesc = Me.txtStockCategory.Text.Trim
            dt = objIPRData.StockCategorySearch(CategoryDesc)

            If dt.Rows.Count > 0 Then

                'If dt.Rows(0).Item("STCategoryID").ToString() = string.empty  Then
                '    MessageBox.Show("Invalid Stock Category , Please choose correct category")
                '    btnSearchStockCategory.Focus()
                '    Exit Sub
                'End If
                'Me.lblCategoryCode.Visible = True

                ''''
                txtStockCode.Text = String.Empty
                lblDescription.Text = String.Empty
                lblUnit.Text = String.Empty
                lblAvailableQty.Text = String.Empty
                lblMinQty.Text = String.Empty
                txtQtyIssued.Text = String.Empty
                ''''
                psSIVStockCategoryCode = dt.Rows(0).Item("STCategoryDescp").ToString().Trim
                lblStockCategoryCode.Text = dt.Rows(0).Item("STCategoryDescp").ToString().Trim

                psSIVStockCategoryID = dt.Rows(0).Item("STCategoryID").ToString()
                psSIVStockCategoryIDForStock = dt.Rows(0).Item("STCategoryID").ToString()
                IPRPPT.strGlobalCategoryID = dt.Rows(0).Item("STCategoryID").ToString()

                If dt.Rows(0).Item("StockCOAID").ToString() <> String.Empty Then
                    psSIVStockCOAID = dt.Rows(0).Item("StockCOAID").ToString()
                End If
                If dt.Rows(0).Item("VarianceCOAID").ToString() <> String.Empty Then
                    psSIVVarianceCOAID = dt.Rows(0).Item("VarianceCOAID").ToString()
                End If

            Else

                DisplayInfoMessage("Msg37")
                'MessageBox.Show("Invalid Stock Category , Please choose correct category from lookup")

                txtStockCategory.Text = String.Empty
                lblStockCategoryCode.Text = String.Empty
                psSIVStockCategoryCode = String.Empty
                psSIVStockCategoryID = String.Empty
                psSIVStockCOAID = String.Empty
                psSIVVarianceCOAID = String.Empty
                btnSearchStockCategory.Focus()
                Exit Sub

            End If

        Else

            txtStockCategory.Text = String.Empty
            lblStockCategoryCode.Text = String.Empty
            psSIVStockCategoryCode = String.Empty
            psSIVStockCategoryID = String.Empty
            psSIVStockCOAID = String.Empty
            psSIVVarianceCOAID = String.Empty

        End If

    End Sub

    Private Sub btnSearchStockCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCategory.Click

        NonStockIPRFrm.StrFrmName = "SIV"

        Me.Cursor = Cursors.WaitCursor

        txtStockCode.Text = String.Empty
        lblDescription.Text = String.Empty
        lblUnit.Text = String.Empty
        lblAvailableQty.Text = String.Empty
        lblMinQty.Text = String.Empty
        txtQtyIssued.Text = String.Empty

        Dim frmStockCategoryLookup As New CategoryLookup
        frmStockCategoryLookup.ShowDialog()

        If frmStockCategoryLookup._lStockCategoryID <> String.Empty Then

            txtStockCategory.Text = frmStockCategoryLookup._lStockCategoryCode.Trim
            psSIVStockCategory = frmStockCategoryLookup._lStockCategoryCode
            psSIVStockCategoryCode = frmStockCategoryLookup._lStockCategory.Trim
            lblStockCategoryCode.Text = frmStockCategoryLookup._lStockCategory.Trim
            psSIVStockCategoryID = frmStockCategoryLookup._lStockCategoryID
            psSIVStockCategoryIDForStock = frmStockCategoryLookup._lStockCategoryID
            psSIVStockCOAID = frmStockCategoryLookup._lStockCOAID
            psSIVVarianceCOAID = frmStockCategoryLookup._lVarianceCOAID

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub txtStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave

        If txtStockCode.Text.Trim() <> String.Empty Then

            Dim dt As New DataTable
            Dim dtStock As New DataTable
            Dim objIPRPPT As New IPRPPT
            Dim objIPRBOL As New IPRBOL

            objIPRPPT.STCategoryCode = psSIVStockCategoryCode 'Me.lblCategoryCode.Text
            objIPRPPT.STCategory = Me.txtStockCategory.Text
            objIPRPPT.STCategoryID = psSIVStockCategoryID
            objIPRPPT.StockCode = Me.txtStockCode.Text
            dt = objIPRBOL.StockCodeSearch(objIPRPPT)

            If dt.Rows.Count <> 0 Then

                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then
                    psSIVStockID = dt.Rows(0).Item("StockId").ToString()
                Else
                    psSIVStockID = String.Empty
                End If
                If Not dt.Rows(0).Item("StockCode") Is DBNull.Value Then
                    Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString().Trim
                    psSIVStockCode = dt.Rows(0).Item("StockCode").ToString().Trim
                Else
                    Me.txtStockCode.Text = String.Empty
                End If

                If Not dt.Rows(0).Item("StockDesc") Is DBNull.Value Then
                    lblDescription.Text = dt.Rows(0).Item("StockDesc").ToString()
                Else
                    lblDescription.Text = String.Empty
                End If
                'Me.lblUnitPriceValue.Text = dt.Rows(0).Item("UnitPrice").ToString()
                If Not dt.Rows(0).Item("UOM") Is DBNull.Value Then
                    Me.lblUnit.Text = dt.Rows(0).Item("UOM").ToString()
                Else
                    Me.lblUnit.Text = String.Empty
                End If

                'objIPRPPT.stockID = dt.Rows(0).Item("StockID").ToString()
                ' psSIVStockID = dt.Rows(0).Item("StockID").ToString()
                If Not dt.Rows(0).Item("AvailableQty") Is DBNull.Value Then
                    Me.lblAvailableQty.Text = dt.Rows(0).Item("AvailableQty")
                Else
                    Me.lblAvailableQty.Text = 0
                End If
                If Not dt.Rows(0).Item("MinQty").ToString() Is DBNull.Value Then
                    Me.lblMinQty.Text = dt.Rows(0).Item("MinQty")
                Else
                    Me.lblMinQty.Text = 0
                End If
                Me.lblUnit.Visible = True
                Me.lblDescription.Visible = True
                'Me.lblUnitPriceValue.Visible = True
                'Me.lblTotalValue.Visible = True
            Else
                DisplayInfoMessage("Msg38")
                'MessageBox.Show("Invalid Stock Code,Please Choose it from look up")
                ClearStockCodeRelatedFields()
                txtStockCode.Focus()
            End If
            'If objIPRPPT.stockID <> String.Empty Then
            '    dtStock = objIPRBOL.GetAvailableQTy(objIPRPPT)
            '    If dtStock.Rows.Count <> 0 Then
            '        'Me.lblUnitPriceValue.Text = dtStock.Rows(0).Item("UnitPrice").ToString
            '        If dtStock.Rows(0).Item("AvailableQty").ToString <> String.Empty Then
            '            Me.lblAvailableQty.Text = dtStock.Rows(0).Item("AvailableQty").ToString
            '        End If
            '    End If
            'End If
        Else
            ClearStockCodeRelatedFields()
        End If

    End Sub

    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click

        Me.Cursor = Cursors.WaitCursor
        GlobalPPT.IsStockCategory = False

        If txtStockCategory.Text.Trim() = String.Empty Then

            DisplayInfoMessage("Msg39")
            'MessageBox.Show("Please Enter Stock Category")
            txtStockCategory.Focus()

        Else

            ''''
            Dim ObjStockCode As New IPRPPT
            Dim ObjStockBOL As New IPRBOL
            Dim stockDt As New DataTable
            Dim StockCategory As New StockCodeLookUp()
            Dim result As DialogResult = StockCodeLookUp.ShowDialog()

            If StockCodeLookUp.DialogResult = Windows.Forms.DialogResult.OK Then

                Me.psSIVStockCode = StockCodeLookUp._lStockCode.Trim
                Me.psSIVStockDesc = StockCodeLookUp._lStockDesc
                Me.psSIVUnitprice = StockCodeLookUp._lStockUnitprice
                Me.psSIVUnit = StockCodeLookUp._lUnit
                lblUnit.Text = Me.psSIVUnit
                Me.psSIVStockID = StockCodeLookUp._lStockID 'Getting Stock ID From Stock Master
                ObjStockCode.stockID = StockCodeLookUp._lStockID
                lblAvailableQty.Text = StockCodeLookUp._lAvailableQty
                lblMinQty.Text = StockCodeLookUp._lMinQty
                'If Me.psSIVStockID <> String.Empty Then
                '    stockDt = ObjStockBOL.GetAvailableQTy(ObjStockCode)
                '    If stockDt.Rows.Count <> 0 Then
                '        'Me.lblUnitPriceValue.Text = stockDt.Rows(0).Item("UnitPrice").ToString()
                '        Me.lblAvailableQty.Text = stockDt.Rows(0).Item("AvailableQty").ToString()
                '    End If
                'End If
                Me.lblDescription.Visible = True
                'Me.lblUnitPriceValue.Visible = True
                'Me.lblUnitValue.Visible = True

                Me.txtStockCode.Text = psSIVStockCode
                Me.lblDescription.Text = psSIVStockDesc
                'Me.lblUnitPriceValue.Text = psSIVUnitprice
                'Me.lblAvailableQty.Text 
                'Me.lblUnitValue.Text = psSIVUnit
                'Me.txtRequestedQty.Focus()
                ''''
            End If

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub txtUsedFor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsedFor.Leave

        If txtUsedFor.Text.Trim = String.Empty Then
            txtUsedFor.Text = String.Empty
        End If

    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave

        If txtAccountCode.Text.Trim() <> String.Empty Then
            'If txtAccountCode.Text.Trim.ToString.Length <> 13 Then
            '    DisplayInfoMessage("Msg40")
            '    'MessageBox.Show("Please enter 13 digit Account code")
            '    Exit Sub
            'End If

            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.COACode = txtAccountCode.Text.Trim()
            ds = StoreIssueVoucherBOL.AcctlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg41")
                'MessageBox.Show("Invalid Account code,Please Choose it from look up")
                ClearAccountCodeRelatedfields()
                txtAccountCode.Focus()
                'ClearSubBlock()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("COACode") Is DBNull.Value Then
                    txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                Else
                    txtAccountCode.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("COADescp") Is DBNull.Value Then
                    lblAccountDesc.Text = ds.Tables(0).Rows(0).Item("COADescp")
                Else
                    txtAccountCode.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("COAID") Is DBNull.Value Then
                    psSIVAccountID = ds.Tables(0).Rows(0).Item("COAID")
                Else
                    psSIVAccountID = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("ExpenditureAG") Is DBNull.Value Then
                    GlobalPPT.psAcctExpenditureType = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                    lsVDExpenditureAG = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                Else
                    GlobalPPT.psAcctExpenditureType = String.Empty
                    lsVDExpenditureAG = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("OldCOACode") Is DBNull.Value Then
                    lblOldAccountCode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                    psSIVOldAccountID = ds.Tables(0).Rows(0).Item("OldCOACode")
                Else
                    lblOldAccountCode.Text = String.Empty
                    psSIVOldAccountID = String.Empty
                End If
                ' ClearSubBlock()
            End If
        Else
            ClearAccountCodeRelatedfields()
            'ClearSubBlock()
        End If

    End Sub

    Private Sub ClearAccountCodeRelatedfields()

        txtAccountCode.Text = String.Empty
        lblAccountDesc.Text = String.Empty
        lblOldAccountCode.Text = String.Empty
        psSIVAccountID = String.Empty
        psSIVOldAccountID = String.Empty
        GlobalPPT.psAcctExpenditureType = String.Empty
        lsVDExpenditureAG = String.Empty

    End Sub

    Private Sub btnSearchAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccountCode.Click
        Me.Cursor = Cursors.WaitCursor
        ' Dim frmAcctcodeLookup As New Accountlookup
        Dim frmAcctcodeLookup As New COALookup
        Dim result As DialogResult = frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            psSIVAccountID = frmAcctcodeLookup.strAcctId
            lblAccountDesc.Text = frmAcctcodeLookup.strAcctDescp
            GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            lsVDExpenditureAG = frmAcctcodeLookup.strAcctExpenditureAG
            ''GlobalPPT.psAcctExpenditureType = GlobalPPT.psAcctExpenditureType
            ''lsVDExpenditureAG = GlobalPPT.psAcctExpenditureType
            lblOldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode
            'ClearSubBlock()
            If txtContractNo.Text.Trim() = String.Empty Then
                btnSearchAccountCode.Enabled = True
                txtAccountCode.Enabled = True
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub txtAccountCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.TextChanged

    '    If txtAccountCode.Text.Trim() <> String.Empty Then
    '        'ClearSubBlock()
    '    End If

    ' End Sub

    Private Sub txtT0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT0.Leave

        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T0Value = txtT0.Text.Trim()
            objSIV.TDecide = "T0"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg42")
                'MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                Me.lblT0Name.Text = String.Empty
                Me.txtT0.Text = String.Empty
                psSIVT0analysisID = String.Empty
                txtT0.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("TAnalysisDescp") Is DBNull.Value Then
                    Me.lblT0Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                Else
                    Me.lblT0Name.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TValue") Is DBNull.Value Then
                    Me.txtT0.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                Else
                    Me.txtT0.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TAnalysisId") Is DBNull.Value Then
                    psSIVT0analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
                Else
                    psSIVT0analysisID = String.Empty
                End If
            End If
        Else
            Me.lblT0Name.Text = String.Empty
            Me.txtT0.Text = String.Empty
            psSIVT0analysisID = String.Empty
        End If

    End Sub

    Private Sub btnSearchT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT0.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T0"
        Dim result As DialogResult = frmTLookup.ShowDialog()
        If frmTLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtT0.Text = frmTLookup.strTValue
            Me.lblT0Name.Text = frmTLookup.strTDesc
            psSIVT0analysisID = frmTLookup.strTId
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtT1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1.Leave

        If txtT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T1Value = txtT1.Text.Trim()
            objSIV.TDecide = "T1"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg43")
                'MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
                Me.lblT1Name.Text = String.Empty
                Me.txtT1.Text = String.Empty
                psSIVT1analysisID = String.Empty
                txtT1.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("TAnalysisDescp") Is DBNull.Value Then
                    Me.lblT1Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                Else
                    Me.lblT1Name.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TValue") Is DBNull.Value Then
                    Me.txtT1.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                Else
                    Me.txtT1.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TAnalysisId") Is DBNull.Value Then
                    psSIVT1analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
                Else
                    psSIVT1analysisID = String.Empty
                End If
            End If
        Else
            Me.lblT1Name.Text = String.Empty
            Me.txtT1.Text = String.Empty
            psSIVT1analysisID = String.Empty
        End If

    End Sub

    Private Sub btnSearchT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T1"
        Dim result As DialogResult = frmTLookup.ShowDialog()
        If frmTLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtT1.Text = frmTLookup.strTValue
            Me.lblT1Name.Text = frmTLookup.strTDesc
            psSIVT1analysisID = frmTLookup.strTId
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtT2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT2.Leave

        If txtT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T2Value = txtT2.Text.Trim()
            objSIV.TDecide = "T2"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg44")
                'MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
                Me.lblT2Name.Text = String.Empty
                Me.txtT2.Text = String.Empty
                psSIVT2analysisID = String.Empty
                txtT2.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("TAnalysisDescp") Is DBNull.Value Then
                    Me.lblT2Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                Else
                    Me.lblT2Name.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TValue") Is DBNull.Value Then
                    Me.txtT2.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                Else
                    Me.txtT2.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TAnalysisId") Is DBNull.Value Then
                    psSIVT2analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
                Else
                    psSIVT2analysisID = String.Empty
                End If
            End If
        Else
            Me.lblT2Name.Text = String.Empty
            Me.txtT2.Text = String.Empty
            psSIVT2analysisID = String.Empty
        End If

    End Sub

    Private Sub btnSearchT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T2"
        Dim result As DialogResult = frmTLookup.ShowDialog()
        If frmTLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtT2.Text = frmTLookup.strTValue
            Me.lblT2Name.Text = frmTLookup.strTDesc
            psSIVT2analysisID = frmTLookup.strTId
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtT3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT3.Leave

        If txtT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T3Value = txtT3.Text.Trim()
            objSIV.TDecide = "T3"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg45")
                'MessageBox.Show("Invalid T3 Value,Please Choose it from look up")
                Me.lblT3Name.Text = String.Empty
                Me.txtT3.Text = String.Empty
                psSIVT3analysisID = String.Empty
                txtT3.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("TAnalysisDescp") Is DBNull.Value Then
                    Me.lblT3Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                Else
                    Me.lblT3Name.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TValue") Is DBNull.Value Then
                    Me.txtT3.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                Else
                    Me.txtT3.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TAnalysisId") Is DBNull.Value Then
                    psSIVT3analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
                Else
                    psSIVT3analysisID = String.Empty
                End If
            End If
        Else
            Me.lblT3Name.Text = String.Empty
            Me.txtT3.Text = String.Empty
            psSIVT3analysisID = String.Empty
        End If

    End Sub

    Private Sub btnSearchT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T3"
        Dim result As DialogResult = frmTLookup.ShowDialog()
        If frmTLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtT3.Text = frmTLookup.strTValue
            Me.lblT3Name.Text = frmTLookup.strTDesc
            psSIVT3analysisID = frmTLookup.strTId
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtT4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4.Leave

        If txtT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T4Value = txtT4.Text.Trim()
            objSIV.TDecide = "T4"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg46")
                'MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
                Me.lblT4Name.Text = String.Empty
                Me.txtT4.Text = String.Empty
                psSIVT4analysisID = String.Empty
                txtT4.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("TAnalysisDescp") Is DBNull.Value Then
                    Me.lblT4Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                Else
                    Me.lblT4Name.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TValue") Is DBNull.Value Then
                    Me.txtT4.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                Else
                    Me.txtT4.Text = String.Empty
                End If
                If Not ds.Tables(0).Rows(0).Item("TAnalysisId") Is DBNull.Value Then
                    psSIVT4analysisID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
                Else
                    psSIVT4analysisID = String.Empty
                End If
            End If
        Else
            Me.lblT4Name.Text = String.Empty
            Me.txtT4.Text = String.Empty
            psSIVT4analysisID = String.Empty
        End If

    End Sub

    Private Sub btnSearchT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T4"
        Dim result As DialogResult = frmTLookup.ShowDialog()
        If frmTLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtT4.Text = frmTLookup.strTValue
            Me.lblT4Name.Text = frmTLookup.strTDesc
            psSIVT4analysisID = frmTLookup.strTId
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave

        If txtSubBlock.Text.Trim() <> String.Empty And txtSubBlock.Enabled = True Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.BlockName = txtSubBlock.Text.Trim()
            objSIV.BlockStatus = GlobalPPT.psAcctExpenditureType
            ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg47")
                'MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
                txtSubBlock.Text = String.Empty
                psSIVBlockID = String.Empty
                lblSubBlockName.Text = String.Empty
                Me.txtDiv.Text = String.Empty
                psSIVDivID = String.Empty
                Me.lblDivName.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                Me.lblYOPName.Text = String.Empty
                psSIVYopID = String.Empty
                txtSubBlock.Focus()
                Exit Sub
            Else
                If Not ds.Tables(0).Rows(0).Item("BlockName") Is DBNull.Value Then
                    txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
                End If
                psSIVBlockID = ds.Tables(0).Rows(0).Item("BlockID")
                If Not ds.Tables(0).Rows(0).Item("BlockStatus") Is DBNull.Value Then
                    lblSubBlockName.Text = ds.Tables(0).Rows(0).Item("BlockStatus")
                End If
                If Not ds.Tables(0).Rows(0).Item("Div") Is DBNull.Value Then
                    Me.txtDiv.Text = ds.Tables(0).Rows(0).Item("Div")
                End If
                psSIVDivID = ds.Tables(0).Rows(0).Item("DivID")
                If Not ds.Tables(0).Rows(0).Item("DivName") Is DBNull.Value Then
                    Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
                End If
                If Not ds.Tables(0).Rows(0).Item("YOP") Is DBNull.Value Then
                    Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
                End If
                If Not ds.Tables(0).Rows(0).Item("Name") Is DBNull.Value Then
                    Me.lblYOPName.Text = ds.Tables(0).Rows(0).Item("Name")
                End If
                psSIVYopID = ds.Tables(0).Rows(0).Item("YOPID")

                'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
                txtODOReading.Text = String.Empty
                txtODOReading.Enabled = False
                txtVHNo.Text = String.Empty
                txtVHNo.Enabled = False
                lblVHDescp.Text = String.Empty
                psSIVVHID = String.Empty
                psSIVVHType = String.Empty
                psSIVVHCategoryID = String.Empty
                btnSearchVHNo.Enabled = False
                txtVHDetailsCostCode.Text = String.Empty
                lblVHDetailDescp.Text = String.Empty
                psSIVVHDetailsCostCodeId = String.Empty
                '                psSIVVHDetCostCodType = String.Empty

                txtVHDetailsCostCode.Enabled = False
                btnSearchVHcostCode.Enabled = False
                'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
            End If
        ElseIf txtSubBlock.Text.Trim() = String.Empty And txtSubBlock.Enabled = True Then
            ClearSubBlock()
        End If

    End Sub

    Private Sub ClearSubBlock()

        txtSubBlock.Text = String.Empty
        psSIVBlockID = String.Empty
        lblSubBlockName.Text = String.Empty
        Me.txtDiv.Text = String.Empty
        psSIVDivID = String.Empty
        Me.lblDivName.Text = String.Empty
        Me.txtYOP.Text = String.Empty
        Me.lblYOPName.Text = String.Empty
        psSIVYopID = String.Empty
        txtODOReading.Text = String.Empty
        txtVHNo.Text = String.Empty
        lblVHDescp.Text = String.Empty
        psSIVVHID = String.Empty
        psSIVVHType = String.Empty
        psSIVVHCategoryID = String.Empty
        txtVHDetailsCostCode.Text = String.Empty
        lblVHDetailDescp.Text = String.Empty
        psSIVVHDetailsCostCodeId = String.Empty
        '            psSIVVHDetCostCodType = String.Empty

        'Enable vhno,vhdetailscostcode and odo reading if sub block left empty
        txtODOReading.Enabled = True
        txtVHNo.Enabled = True
        btnSearchVHNo.Enabled = True
        txtVHDetailsCostCode.Enabled = True
        btnSearchVHcostCode.Enabled = True
        'Enable vhno,vhdetailscostcode and odo reading if sub block left empty

    End Sub

    Private Sub btnSearchSubBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSubBlock.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmSubBlock As New SubBlockLookup
        Dim result As DialogResult = frmSubBlock.ShowDialog()
        If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtSubBlock.Text = frmSubBlock.psBlockName
            psSIVBlockID = frmSubBlock.psBlockId
            Me.lblSubBlockName.Text = frmSubBlock.psBlockStatus
            Me.txtDiv.Text = frmSubBlock.psDIV
            psSIVDivID = frmSubBlock.psDIVID
            Me.lblDivName.Text = frmSubBlock.psDIVName
            Me.txtYOP.Text = frmSubBlock.psYop
            Me.lblYOPName.Text = frmSubBlock.psYopName
            psSIVYopID = frmSubBlock.psYopID

            'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
            txtODOReading.Text = String.Empty
            txtODOReading.Enabled = False
            txtVHNo.Text = String.Empty
            txtVHNo.Enabled = False
            lblVHDescp.Text = String.Empty
            psSIVVHID = String.Empty
            psSIVVHType = String.Empty
            psSIVVHCategoryID = String.Empty
            btnSearchVHNo.Enabled = False
            txtVHDetailsCostCode.Text = String.Empty
            lblVHDetailDescp.Text = String.Empty
            psSIVVHDetailsCostCodeId = String.Empty
            '            psSIVVHDetCostCodType = String.Empty

            txtVHDetailsCostCode.Enabled = False
            btnSearchVHcostCode.Enabled = False
            'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtDiv_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiv.Leave

        If txtDiv.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.Div = txtDiv.Text.Trim()
            objSIV.BlockID = psSIVBlockID
            ds = StoreIssueVoucherBOL.GetDIV(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg48")
                'MessageBox.Show("This block does not belongs to selected division,Please Choose it from look up")
                txtDiv.Text = String.Empty
                lblDivName.Text = String.Empty
                psSIVDivID = String.Empty
                txtDiv.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDiv.Text = ds.Tables(0).Rows(0).Item("Div")
                End If
                If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
                    Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
                End If
                psSIVDivID = ds.Tables(0).Rows(0).Item("DivID")
            End If
        Else
            txtDiv.Text = String.Empty
            lblDivName.Text = String.Empty
            psSIVDivID = String.Empty
        End If

    End Sub

    Private Sub btnSearchDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchDiv.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmDivLookup As New DivLookup
        frmDivLookup.BindDIV(psSIVBlockID)
        Dim result As DialogResult = frmDivLookup.ShowDialog()
        If frmDivLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtDiv.Text = frmDivLookup.psDIV
            Me.lblDivName.Text = frmDivLookup.psDIVName
            psSIVDivID = frmDivLookup.psDIVID
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtStation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStation.Leave

        If txtStation.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.Stationcode = txtStation.Text.Trim()
            ds = StoreIssueVoucherBOL.GetStation(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg49")
                'MessageBox.Show("Invalid Station,Please Choose it from look up")
                txtStation.Text = String.Empty
                lblStationDesc.Text = String.Empty
                psSIVStationID = String.Empty
                txtStation.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("StationCode") <> String.Empty Then
                    Me.txtStation.Text = ds.Tables(0).Rows(0).Item("StationCode")
                End If
                If ds.Tables(0).Rows(0).Item("StationDescp") <> String.Empty Then
                    Me.lblStationDesc.Text = ds.Tables(0).Rows(0).Item("StationDescp")
                End If
                psSIVStationID = ds.Tables(0).Rows(0).Item("StationID")
            End If
        Else
            txtStation.Text = String.Empty
            lblStationDesc.Text = String.Empty
            psSIVStationID = String.Empty
        End If

    End Sub

    Private Sub btnSearchStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStation.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmStationLookup As New StationLookup
        Dim result As DialogResult = frmStationLookup.ShowDialog()
        If frmStationLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtStation.Text = frmStationLookup.psStationCode
            Me.lblStationDesc.Text = frmStationLookup.psStationDesc
            psSIVStationID = frmStationLookup.psStationId
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtVHNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVHNo.Leave

        If txtVHNo.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.VHWSCode = txtVHNo.Text.Trim()
            ds = StoreIssueVoucherBOL.GetVHNo(objSIV, "YES")
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count = 0 Then
                    DisplayInfoMessage("Msg50")
                    'MessageBox.Show("Invalid VHNo,Please Choose it from look up")
                    txtVHNo.Text = String.Empty
                    lblVHDescp.Text = String.Empty
                    psSIVVHID = String.Empty
                    psSIVVHCategoryID = String.Empty
                    psSIVVHType = String.Empty
                    txtVHNo.Focus()
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0).Item("VHNo").ToString() <> String.Empty Then
                        txtVHNo.Text = ds.Tables(0).Rows(0).Item("VHNo").ToString()
                    End If
                    If ds.Tables(0).Rows(0).Item("VHDescp").ToString() <> String.Empty Then
                        lblVHDescp.Text = ds.Tables(0).Rows(0).Item("VHDescp").ToString()
                    End If
                    psSIVVHID = ds.Tables(0).Rows(0).Item("VHID").ToString()
                    If ds.Tables(0).Rows(0).Item("VHCategoryID").ToString() <> String.Empty Then
                        psSIVVHCategoryID = ds.Tables(0).Rows(0).Item("VHCategoryID").ToString()
                    End If
                    If Not ds.Tables(0).Rows(0).Item("Type") Is DBNull.Value Then
                        'psSIVVHType = ds.Tables(0).Rows(0).Item("Type").ToString()
                        If ds.Tables(0).Rows(0).Item("Type").ToString() = "Vehicle" Then
                            psSIVVHType = "V"
                        End If
                        If ds.Tables(0).Rows(0).Item("Type").ToString() = "Workshop" Then
                            psSIVVHType = "W"
                        End If
                        If ds.Tables(0).Rows(0).Item("Type").ToString() = "Others" Then
                            psSIVVHType = "O"
                        End If
                    End If
                End If
            End If
        Else
            txtVHNo.Text = String.Empty
            lblVHDescp.Text = String.Empty
            psSIVVHID = String.Empty
            psSIVVHCategoryID = String.Empty
            psSIVVHType = String.Empty
        End If

    End Sub

    Private Sub btnSearchVHNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHNo.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmVHNoLookup As New VHNoLookup
        Dim result As DialogResult = frmVHNoLookup.ShowDialog()
        If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            psSIVVHID = frmVHNoLookup.psVHID
            Me.txtVHNo.Text = frmVHNoLookup.psVHWSCode
            Me.lblVHDescp.Text = frmVHNoLookup.psVHDesc
            psSIVVHCategoryID = frmVHNoLookup.psVHCategoryID
            ' psSIVVHType = frmVHNoLookup.psVHCategoryType
            If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
                If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
                    psSIVVHType = "V"
                End If
                If frmVHNoLookup.psVHCategoryType = "Workshop" Then
                    psSIVVHType = "W"
                End If
                If frmVHNoLookup.psVHCategoryType = "Others" Then
                    psSIVVHType = "O"
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtVHDetailsCostCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVHDetailsCostCode.Leave

        If txtVHDetailsCostCode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.VHDetailCostCode = txtVHDetailsCostCode.Text.Trim()
            objSIV.Type = psSIVVHType
            ds = StoreIssueVoucherBOL.GetVHDetailsCostCode(objSIV, "YES")
            If ds.Tables.Count <> 0 Then
                If ds.Tables(0).Rows.Count = 0 Then
                    DisplayInfoMessage("Msg51")
                    'MessageBox.Show("Invalid VHDetail Cost code,Please Choose it from look up")
                    txtVHDetailsCostCode.Text = String.Empty
                    lblVHDetailDescp.Text = String.Empty
                    psSIVVHDetailsCostCodeId = String.Empty
                    ''psSIVVHDetCostCodType = String.Empty
                    txtVHDetailsCostCode.Focus()
                    Exit Sub
                Else
                    If ds.Tables(0).Rows(0).Item("VHDetailCostCode").ToString() <> String.Empty Then
                        txtVHDetailsCostCode.Text = ds.Tables(0).Rows(0).Item("VHDetailCostCode").ToString()
                    End If
                    psSIVVHDetailsCostCodeId = ds.Tables(0).Rows(0).Item("VHDetailCostCodeID").ToString()
                    lblVHDetailDescp.Text = ds.Tables(0).Rows(0).Item("VHDescp")
                    ''If ds.Tables(0).Rows(0).Item("Type").ToString() <> String.Empty Then
                    ''    psSIVVHDetCostCodType = ds.Tables(0).Rows(0).Item("Type").ToString()
                    ''End If
                End If
            End If
        Else
            txtVHDetailsCostCode.Text = String.Empty
            psSIVVHDetailsCostCodeId = String.Empty
            lblVHDetailDescp.Text = String.Empty
            ''psSIVVHDetCostCodType = String.Empty
        End If

    End Sub

    Private Sub btnSearchVHcostCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVHcostCode.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmVHDetailsCostCodeLookup As New VHDetailsCostCodeLookup
        frmVHDetailsCostCodeLookup.BindGrid(psSIVVHType)
        Dim result As DialogResult = frmVHDetailsCostCodeLookup.ShowDialog()
        If frmVHDetailsCostCodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtVHDetailsCostCode.Text = frmVHDetailsCostCodeLookup.psVHDetailsCostCode
            psSIVVHDetailsCostCodeId = frmVHDetailsCostCodeLookup.psVHDetailsCostCodeID
            lblVHDetailDescp.Text = frmVHDetailsCostCodeLookup.psVHDetailsDesc
            ''psSIVVHDetCostCodType = frmVHDetailsCostCodeLookup.psType
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If (dgIssueVoucher.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED")) And btnSaveAll.Enabled = True And psMenuID = "M6" Then
            If MsgBox(rm.GetString("Msg85"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsRetainFocus = True
                GlobalPPT.IsButtonClose = False
                Exit Sub
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        '
    End Sub

    Private Sub txtQtyIssued_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQtyIssued.KeyDown

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

                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then

                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        isDecimal = oneDecimalPlaces.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{Tab}")
        End If

    End Sub

    Private Sub txtQtyIssued_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyIssued.KeyPress

        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

        'If Char.IsDigit(e.KeyChar) Then Exit Sub
        'If Char.IsControl(e.KeyChar) Then Exit Sub

        'If e.KeyChar = "." Then
        '    Dim txt As TextBox = CType(sender, TextBox)
        '    If txt.Text.IndexOf(".") < 0 Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'Else
        '    e.Handled = True
        'End If

    End Sub

    Private Sub txtODOReading_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtODOReading.KeyPress

        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

        'If Char.IsDigit(e.KeyChar) Then Exit Sub
        'If Char.IsControl(e.KeyChar) Then Exit Sub

        'If e.KeyChar = "." Then
        '    Dim txt As TextBox = CType(sender, TextBox)
        '    If txt.Text.IndexOf(".") < 0 Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'Else
        '    e.Handled = True
        'End If

    End Sub

    Private Sub txtODOReading_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtODOReading.KeyDown

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

    'Private Sub tbStoreIssueVoucher_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tbStoreIssueVoucher.Selected

    '    Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.dtpSIVDate)
    '    Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.txtSIVDateSearch)
    '    BindViewIssueVoucher()
    '    'fillComboSIVNo()

    'End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        clear()
        btnPrint.Enabled = False
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click

        ResetAll()
        dtAddFlag = True

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub ResetAll()

        ClearAll()

        lblRejectedReasonValue.Visible = False
        lblRejectedReason1.Visible = False
        lblRejReasonColon.Visible = False

        psIssueIDVal = String.Empty
        EnableFieldsOnResetAll()
        StoreIssueVoucherBOL.ClearGridView(dgIssueVoucher)
        btnPrint.Enabled = False
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        SearchSIV()

        'Me.Cursor = Cursors.WaitCursor
        'Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        'If chkViewSIVDate.Checked = True Then
        '    objStoreIssueVoucherPPT.BViewSIVDate = True
        'Else
        '    objStoreIssueVoucherPPT.BViewSIVDate = False
        'End If
        'objStoreIssueVoucherPPT.SIVDateSearch = Format(Me.txtSIVDateSearch.Value, "yyyy/MM/dd") '"MM/dd/yyyy")
        ''objStoreIssueVoucherPPT.SIVDateSearch = txtSIVDateSearch.Value.ToString("yyyy/MM/dd")
        'objStoreIssueVoucherPPT.SIVNOSearch = txtSIVNoSearch.Text.Trim()
        'objStoreIssueVoucherPPT.ConttractNoSearch = txtContractNoSearch.Text.Trim()
        ''objStoreIssueVoucherPPT.RemarksSearch = txtRemarksSearch.Text.Trim()

        'objStoreIssueVoucherPPT.StatusSearch = cmbStatusSearch.SelectedItem.ToString()

        'Dim ds As New DataSet
        'ds = StoreIssueVoucherBOL.SIVSearch(objStoreIssueVoucherPPT, "NO")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    lblNoRecord.Visible = False
        '    dgViewIssueVoucher.AutoGenerateColumns = False
        '    dgViewIssueVoucher.DataSource = ds.Tables(0)
        'Else
        '    dgViewIssueVoucher.DataSource = ds.Tables(0)
        '    lblNoRecord.Visible = True
        'End If
        'Me.Cursor = Cursors.Arrow

      

    End Sub

    Private Sub SearchSIV()

        Me.Cursor = Cursors.WaitCursor
        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        If chkViewSIVDate.Checked = True Then
            objStoreIssueVoucherPPT.BViewSIVDate = True
        Else
            objStoreIssueVoucherPPT.BViewSIVDate = False
        End If
        'objStoreIssueVoucherPPT.SIVDateSearch = Format(Me.txtSIVDateSearch.Value, "yyyy/MM/dd") '"MM/dd/yyyy")
        'objStoreIssueVoucherPPT.SIVDateSearch = txtSIVDateSearch.Value.ToString("yyyy/MM/dd")
        'edit by suraya 14092012

        objStoreIssueVoucherPPT.SIVNOSearch = txtSIVNoSearch.Text.Trim()
        objStoreIssueVoucherPPT.ConttractNoSearch = txtContractNoSearch.Text.Trim()
        'objStoreIssueVoucherPPT.RemarksSearch = txtRemarksSearch.Text.Trim()

        objStoreIssueVoucherPPT.StatusSearch = cmbStatusSearch.SelectedItem.ToString()

        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.SIVSearch(objStoreIssueVoucherPPT, "NO")
        If ds.Tables(0).Rows.Count > 0 Then
            lblNoRecord.Visible = False
            dgViewIssueVoucher.AutoGenerateColumns = False
            dgViewIssueVoucher.DataSource = ds.Tables(0)
        Else
            dgViewIssueVoucher.DataSource = ds.Tables(0)
            lblNoRecord.Visible = True
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click

        Me.Cursor = Cursors.WaitCursor
        Dim ObjRecordExist As New Object
        Dim ObjSIV As New StoreIssueVoucherPPT
        Dim ObjSIVBOL As New StoreIssueVoucherBOL
        ObjRecordExist = ObjSIVBOL.SIVRecordIsExisT(ObjSIV)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg52")
            'MsgBox("No Records Available!")
        Else
            StrFrmName = "SIV"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BindViewIssueVoucher()

        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objStoreIssueVoucherPPT.Status = "OPEN"
        ds = StoreIssueVoucherBOL.SIVSearch(objStoreIssueVoucherPPT, "NO") 'RejectedReason
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                lblNoRecord.Visible = False
                dgViewIssueVoucher.AutoGenerateColumns = False
                dgViewIssueVoucher.DataSource = ds.Tables(0)
                'dgViewIssueVoucher.Columns("ViewDetails").Visible = False
            Else
                lblNoRecord.Visible = True
                dgViewIssueVoucher.AutoGenerateColumns = False
                dgViewIssueVoucher.DataSource = ds.Tables(0)
            End If
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dgViewIssueVoucher_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewIssueVoucher.CellDoubleClick

        EditViewGridRecord()

    End Sub
    Private Sub EditViewGridRecord()

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        'SIVView_Edit()

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                SIVView_Edit()
            End If
        End If
    End Sub
    Private Sub SIVView_Edit()

        If dgViewIssueVoucher.RowCount > 0 Then
            Dim strSSTIssueID As String = dgViewIssueVoucher.SelectedRows(0).Cells("STIssueID").Value
            Dim strSContractID As String = dgViewIssueVoucher.SelectedRows(0).Cells("ContractID").Value.ToString()
            Dim strSRemarks As String = dgViewIssueVoucher.SelectedRows(0).Cells("Remarks").Value.ToString()
            Dim strSSIVDate As Date = dgViewIssueVoucher.SelectedRows(0).Cells("SIVDate").Value
            Dim strSSIVNO As String = dgViewIssueVoucher.SelectedRows(0).Cells("SIVNO").Value.ToString()
            Dim strSStatus As String = dgViewIssueVoucher.SelectedRows(0).Cells("Status").Value.ToString()
            ResetAll()
            BindIssueVoucherDetails(strSSTIssueID, strSContractID, strSRemarks, strSSIVDate, strSSIVNO, strSStatus)
            If strSStatus = "REJECTED" Then
                lblRejectedReasonValue.Visible = True
                lblRejectedReason1.Visible = True
                lblRejReasonColon.Visible = True
            Else
                lblRejectedReasonValue.Visible = False
                lblRejectedReason1.Visible = False
                lblRejReasonColon.Visible = False
            End If
        Else
            DisplayInfoMessage("Msg53")
            'MessageBox.Show("There is no record to select")
            Exit Sub
        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub ClearSIVEntryScreen()

    End Sub

    Public Sub BindIssueVoucherDetails(ByVal dgpsIssueIDVal As String, ByVal dgpsContractidVal As String, ByVal dgpsRemarksVal As String, ByVal dgdateVal As DateTime, ByVal dgpsSivnumberVal As String, ByVal dgpsStatusVal As String)

        Dim objSIV As New StoreIssueVoucherPPT
        Dim ds1 As New DataSet
        Dim ds As New DataSet
        'Dim mdiparent As New MDIParent
        psMenuID = mdiparent.strMenuID
        Try
            If psMenuID = "M6" Then
                objSIV.STIssueID = dgpsIssueIDVal
                psIssueIDVal = dgpsIssueIDVal
            ElseIf psMenuID = "M15" Then
                objSIV.STIssueID = dgpsIssueIDVal
                psIssueIDVal = dgpsIssueIDVal
                cmbStatus.Text = "--Select Status--"
            End If
            ds = StoreIssueVoucherBOL.GetSIVDetails(objSIV)
            If ds.Tables(0).Rows.Count > 0 Then
                psSIVContractId = dgpsContractidVal
                psContractidVal = dgpsContractidVal
                objSIV.ContractID = psSIVContractId
                If objSIV.ContractID <> String.Empty Then
                    ds1 = StoreIssueVoucherBOL.IsContractNoExist(objSIV)
                    txtContractNo.Text = ds1.Tables(0).Rows(0).Item("ContractNo").ToString()
                End If
                If txtContractNo.Text.Trim() <> String.Empty Then
                    Dim dsCont As New DataSet
                    Dim objContractId As New StoreIssueVoucherPPT
                    objContractId.ContractNo = txtContractNo.Text.Trim()
                    dsCont = StoreIssueVoucherBOL.ContractIDSearch(objContractId, "YES")
                    If dsCont.Tables(0).Rows.Count > 0 Then
                        lblContractorValue.Text = dsCont.Tables(0).Rows(0).Item("ContractName")
                        psSIVContractId = dsCont.Tables(0).Rows(0).Item("ContractID")
                        psSIVAccountID = dsCont.Tables(0).Rows(0).Item("COAID")
                        Me.txtAccountCode.Text = dsCont.Tables(0).Rows(0).Item("COACode")
                        txtAccountCode.Enabled = False
                        btnSearchAccountCode.Enabled = False
                        'disable
                        txtSubBlock.Enabled = False
                        txtStation.Enabled = False
                        txtVHNo.Enabled = False
                        txtVHDetailsCostCode.Enabled = False
                        txtODOReading.Enabled = False
                        btnSearchSubBlock.Enabled = False
                        btnSearchStation.Enabled = False
                        btnSearchVHNo.Enabled = False
                        btnSearchVHcostCode.Enabled = False
                        'disable
                        'clear
                        txtSubBlock.Text = String.Empty
                        psSIVBlockID = String.Empty
                        lblSubBlockName.Text = String.Empty
                        Me.txtDiv.Text = String.Empty
                        psSIVDivID = String.Empty
                        Me.lblDivName.Text = String.Empty
                        Me.txtYOP.Text = String.Empty
                        Me.lblYOPName.Text = String.Empty
                        psSIVYopID = String.Empty
                        'clear
                    Else
                    End If
                End If

                psRemarksVal = dgpsRemarksVal
                txtRemarks.Text = dgpsRemarksVal 'SIVDate
                dtpSIVDate.Value = dgdateVal
                dateVal = dgdateVal
                FormatDateTimePicker(dtpSIVDate)
                txtSIVNo.Text = dgpsSivnumberVal
                psSivnumberVal = dgpsSivnumberVal
                lblStatus.Text = dgpsStatusVal
                psStatusVal = dgpsStatusVal

                'btnSaveAll.Text = "Update All"
                If GlobalPPT.strLang = "en" Then
                    btnSaveAll.Text = "Update All"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveAll.Text = "Update Semua"
                End If

                If psStatusVal = "APPROVED" Then
                    DisableFieldsOnApproved()
                Else
                    EnableFieldsOnResetAll()
                    txtSIVNo.Enabled = False
                    btnAdd.Enabled = True
                    btnSaveAll.Enabled = True
                    btnReset.Enabled = True
                End If



                dtSIVAdd = ds.Tables(0)
                psSIVSTIssueId = ds.Tables(0).Rows(0).Item("STIssueId")

                If Not ds.Tables(0).Rows(0).Item("RejectedReason") Is DBNull.Value Then
                    lblRejectedReasonValue.Text = ds.Tables(0).Rows(0).Item("RejectedReason")
                End If


                '' ''txtStockCategory.Text = ds.Tables(0).Rows(0).Item("StockCategory")
                '' ''psSIVStockCategoryCode = ds.Tables(0).Rows(0).Item("StockCategoryCode")
                '' ''lblStockCategoryCode.Text = ds.Tables(0).Rows(0).Item("StockCategoryCode")
                '' ''psSIVStockCategoryID = ds.Tables(0).Rows(0).Item("StockCategoryId")
                psSIVStockCategoryIDForStock = ds.Tables(0).Rows(0).Item("StockCategoryId")
                IPRPPT.strGlobalCategoryID = psSIVStockCategoryIDForStock
                psSIVStockCOAID = ds.Tables(0).Rows(0).Item("StockCOAID")
                If Not ds.Tables(0).Rows(0).Item("VarianceCOAID") Is DBNull.Value Then
                    psSIVVarianceCOAID = ds.Tables(0).Rows(0).Item("VarianceCOAID")
                End If

                dgIssueVoucher.DataSource = dtSIVAdd
                dgIssueVoucher.AutoGenerateColumns = False
                dtAddFlag = True
                tbStoreIssueVoucher.SelectedTab = tbpgAdd
                dtpSIVDate.Value = dgdateVal
                'ComboSelectedFunction()
                fillIssueBtachTotalValueDs(psSivnumberVal)
            End If
            'dgIssueVoucher.Columns("UOM").Visible = False
            dgIssueVoucher.Columns("dgclIssueUnitPrice").Visible = False
            dgIssueVoucher.Columns("dgclIssuedValue").Visible = False
            ''''txtStockCategory.Enabled = False
            ''''btnSearchStockCategory.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        btnAddFlag = True
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click


        DeleteViewSIV()
        BindViewIssueVoucher()

    End Sub

    Private Sub DeleteViewSIV()

        Dim psSIVSTIssueIdDel As String
        Me.cmsSIV.Visible = False
        Dim objSIV As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        If dgViewIssueVoucher.Rows.Count > 0 Then
            If dgViewIssueVoucher.SelectedRows(0).Cells("Status").Value.ToString() = "OPEN" Or dgViewIssueVoucher.SelectedRows(0).Cells("Status").Value.ToString() = "REJECTED" Then
                If MsgBox(rm.GetString("Msg54"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    psSIVSTIssueIdDel = dgViewIssueVoucher.SelectedRows(0).Cells("STIssueID").Value.ToString()
                    objSIV.STIssueID = psSIVSTIssueIdDel
                    StoreIssueVoucherBOL.DeleteStoreIssueVoucher(objSIV)
                    DisplayInfoMessage("Msg55")
                    'MessageBox.Show("Data Deleted Successfully")
                    bDelAllFlag = True
                    'BindViewIssueVoucher()
                Else
                    bDelAllFlag = False
                    'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                DisplayInfoMessage("Msg56")
                cmbStatusSearch.Text = "OPEN" 'For Default OPEN
                'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            DisplayInfoMessage("Msg57")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        btnAddFlag = True
    End Sub

    Private Sub dgViewIssueVoucher_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgViewIssueVoucher.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgViewIssueVoucher.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgViewIssueVoucher.ClearSelection()
                    Me.dgViewIssueVoucher.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If

    End Sub

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click

        ConfirmApproval()

    End Sub

    Private Function IsValidComboSelect() As Boolean

        If cmbStatus.SelectedIndex = -1 Then
            DisplayInfoMessage("Msg58")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        If (cmbStatus.Text = "--Select Status--") Then
            DisplayInfoMessage("Msg59")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        Return True

    End Function

    Private Sub ConfirmApproval()

        If IsValidComboSelect() = False Then
            Exit Sub
        End If
        Dim objStoreIssueVoucherPPT As New StoreIssueVoucherPPT
        Dim objStockIssueVoucherApprovalPPT As New StockIssueVoucherApprovalPPT
        objStoreIssueVoucherPPT.STIssueID = psIssueIDVal

        'objStoreIssueVoucherPPT.STIssueBatchID = "01R15"

        objStoreIssueVoucherPPT.SIVNO = psSivnumberVal
        objStoreIssueVoucherPPT.SIVDate = dateVal 'Format(dateVal, "MM/dd/yyyy")
        objStoreIssueVoucherPPT.ContractID = psContractidVal

        'If txtIssueBatchTotal.Text.Trim() <> string.empty  Then
        '    objStoreIssueVoucherPPT.IssueBatchTotal = cdbl(txtIssueBatchTotal.Text)
        'End If
        'objStoreIssueVoucherPPT.Remarks = psRemarksVal

        If cmbStatus.SelectedItem.ToString() = "APPROVED" Then
            txtRejectedReason.Text = String.Empty
            If MsgBox(rm.GetString("Msg60"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                '1st Step-Updadte the status in Store.STIssue Table

                Dim dsUpdateSIV As New DataSet
                objStoreIssueVoucherPPT.Status = "APPROVED"
                dsUpdateSIV = StoreIssueVoucherBOL.updateStoreIssueVoucher(objStoreIssueVoucherPPT, "YES")
                DisplayInfoMessage("Msg61")
                'MessageBox.Show("Approved Successfully")

                '2nd Step-Calculate the average price and update the stockdetail table(stockdetail.avgprice=avgprice)
                'and update the same in stissuedetail table (stissuedetail.issueunitprice=avgprice)

                Dim dsUpdateStockDetailandSIVDetail As New DataSet
                'Dim ldIssuedValue As Double
                'Dim ldIssueUnitPrice As Double
                For Each GridViewRow In dgIssueVoucher.Rows
                    If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                        objStoreIssueVoucherPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                        objStoreIssueVoucherPPT.IssuedQty = CDbl(GridViewRow.Cells("dgclIssuedQty").Value.ToString())
                        objStoreIssueVoucherPPT.STIssueDetailsID = GridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString()

                        dsUpdateStockDetailandSIVDetail = StoreIssueVoucherBOL.STStockDetailAvgPriceApproval(objStoreIssueVoucherPPT)
                        ''If Not dsUpdateStockDetailandSIVDetail.Tables(0).Rows(0).Item("IssueUnitPrice") Is DBNull.Value Then
                        ''    ldIssueUnitPrice += CDbl(dsUpdateStockDetailandSIVDetail.Tables(0).Rows(0).Item("IssueUnitPrice"))
                        ''End If
                        ''If Not dsUpdateStockDetailandSIVDetail.Tables(0).Rows(0).Item("IssuedValue") Is Nothing Then
                        ''    ldIssuedValue += dsUpdateStockDetailandSIVDetail.Tables(0).Rows(0).Item("IssuedValue")
                        ''End If
                    End If
                Next

                ''3rd step-Accounts.Ledgerallmodule insert start

                objStockIssueVoucherApprovalPPT.AYear = GlobalPPT.intActiveYear
                objStockIssueVoucherApprovalPPT.AMonth = GlobalPPT.IntActiveMonth
                objStockIssueVoucherApprovalPPT.LedgerDate = dateVal 'Format(dateVal, "MM/dd/yyyy") 'Format(dtpSIVDate.Value, "MM/dd/yyyy")
                objStockIssueVoucherApprovalPPT.LedgerType = "STORE-SIV"
                If psRemarksVal <> String.Empty Then
                    'objStockIssueVoucherApprovalPPT.Descp = "SIV" + psSivnumberVal + "-" + psRemarksVal  'txtRemarks.Text.Trim()
                    objStockIssueVoucherApprovalPPT.Descp = psSivnumberVal + "-" + psRemarksVal  'txtRemarks.Text.Trim()
                Else
                    objStockIssueVoucherApprovalPPT.Descp = psSivnumberVal
                End If
                'objStockIssueVoucherApprovalPPT.BatchAmount = ldIssuedValue
                Dim dsRowsAffectedLedgerAllModule As New DataSet
                dsRowsAffectedLedgerAllModule = StoreIssueVoucherBOL.STIssueLedgerAllModuleInsert(objStockIssueVoucherApprovalPPT)
                psLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                psLedgerNo = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerNo")
                psLedgerType = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerType")
                objStockIssueVoucherApprovalPPT.LedgerID = psLedgerID
                'Accounts.Ledgerallmodule insert end

                '4th step-Accounts.JournalDetail.Insert start.

                Dim intJournalRowsAffected As Integer = 0
                Dim lStockCOAID As String, lVarianceCOAID As String = String.Empty
                Dim lSIVPrice As Double, lSTDPrice As Double, lVariancePrice As Double

                For Each GridViewRow In dgIssueVoucher.Rows
                    If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                        objStoreIssueVoucherPPT.STIssueDetailsID = GridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString()
                        objStoreIssueVoucherPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                        objStoreIssueVoucherPPT.IssuedQty = GridViewRow.Cells("dgclIssuedQty").Value.ToString()
                        Dim dsSTIssueStockIDDetailSelect As New DataSet
                        dsSTIssueStockIDDetailSelect = StoreIssueVoucherBOL.STIssueStockIDDetailSelect(objStoreIssueVoucherPPT)
                        If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("IssuedValue").ToString <> String.Empty Then
                            lSIVPrice = CDbl(dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("IssuedValue").ToString())
                        Else
                            lSIVPrice = 0
                        End If
                        If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice").ToString <> String.Empty Then
                            lSTDPrice = CDbl(dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice").ToString())
                        Else
                            lSTDPrice = 0
                        End If
                        If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StockCOAID").ToString <> String.Empty Then
                            lStockCOAID = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StockCOAID")
                        Else
                            lStockCOAID = String.Empty
                        End If
                        If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID").ToString <> String.Empty Then
                            lVarianceCOAID = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID")
                        Else
                            lVarianceCOAID = String.Empty
                        End If
                        'lVariancePrice = lSTDPrice - lSIVPrice
                        lVariancePrice = lSIVPrice - lSTDPrice
                        ''If Not GridViewRow.Cells("dgclDesc").Value.ToString() Is DBNull.Value Then
                        ''    objStockIssueVoucherApprovalPPT.JournalDetDescp = GridViewRow.Cells("dgclDesc").Value ' descp=stock name
                        ''Else
                        ''    objStockIssueVoucherApprovalPPT.JournalDetDescp = String.Empty
                        ''End If

                        Dim strArray As String()
                        Dim strLoginMonthName As String
                        strArray = GlobalPPT.strLoginMonth.Split("-")
                        strLoginMonthName = strArray(1)

                        'SIV Price Start
                        If lSTDPrice = 0 Then

                            objStockIssueVoucherApprovalPPT.DC = "D"

                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value ' < SIV No.>-< StockCode-Stock Description 

                            objStockIssueVoucherApprovalPPT.COAID = GridViewRow.Cells("dgclAccountId").Value.ToString()
                            objStockIssueVoucherApprovalPPT.Value = lSIVPrice
                            objStockIssueVoucherApprovalPPT.DivID = GridViewRow.Cells("dgclDivId").Value.ToString()
                            objStockIssueVoucherApprovalPPT.YopID = GridViewRow.Cells("dgclYOPID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.BlockID = GridViewRow.Cells("dgclSubBlock").Value.ToString()
                            'objStockIssueVoucherApprovalPPT.VHID = GridViewRow.Cells("dgclVHNo").Value.ToString() dgclVHID
                            objStockIssueVoucherApprovalPPT.VHID = GridViewRow.Cells("dgclVHID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = GridViewRow.Cells("dgclVHDetailCostCodeID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T0 = GridViewRow.Cells("dgclT0Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T1 = GridViewRow.Cells("dgclT1Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T2 = GridViewRow.Cells("dgclT2Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T3 = GridViewRow.Cells("dgclT3Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T4 = GridViewRow.Cells("dgclT4Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.StationID = GridViewRow.Cells("dgclStationID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.Flag = "SIVPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)



                            'Dim strloginMonthYear As String = GlobalPPT.strLoginMonth.ToString() + GlobalPPT.intLoginYear.ToString()

                            objStockIssueVoucherApprovalPPT.DC = "C"
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + "Stock Issue" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString()  ' < SIV No.> “Stock Issue” <Login monthnameyear>
                            'objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value ' < SIV No.>-< StockCode-Stock Description 
                            objStockIssueVoucherApprovalPPT.COAID = lStockCOAID
                            objStockIssueVoucherApprovalPPT.Value = lSIVPrice
                            objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty

                            'objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T4 = String.Empty

                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T0").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T0 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T0").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T1").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T1 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T1").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T2").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T2 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T2").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T3").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T3 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T3").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T4").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T4 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T4").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            End If

                            objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)
                        End If

                        'SIV Price End

                        'SIVSTDPRICE Start
                        If lSTDPrice <> 0 And lStockCOAID <> String.Empty Then
                            objStockIssueVoucherApprovalPPT.DC = "D"
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value ' < SIV No.>-< StockCode-Stock Description 
                            objStockIssueVoucherApprovalPPT.COAID = GridViewRow.Cells("dgclAccountId").Value.ToString()
                            objStockIssueVoucherApprovalPPT.Value = lSTDPrice
                            objStockIssueVoucherApprovalPPT.DivID = GridViewRow.Cells("dgclDivId").Value.ToString()
                            objStockIssueVoucherApprovalPPT.YopID = GridViewRow.Cells("dgclYOPID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.BlockID = GridViewRow.Cells("dgclSubBlock").Value.ToString()
                            'objStockIssueVoucherApprovalPPT.VHID = GridViewRow.Cells("dgclVHNo").Value.ToString() dgclVHID
                            objStockIssueVoucherApprovalPPT.VHID = GridViewRow.Cells("dgclVHID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = GridViewRow.Cells("dgclVHDetailCostCodeID").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T0 = GridViewRow.Cells("dgclT0Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T1 = GridViewRow.Cells("dgclT1Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T2 = GridViewRow.Cells("dgclT2Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T3 = GridViewRow.Cells("dgclT3Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.T4 = GridViewRow.Cells("dgclT4Id").Value.ToString()
                            objStockIssueVoucherApprovalPPT.StationID = GridViewRow.Cells("dgclStationID").Value.ToString()

                            'objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            'objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            'objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            'objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            'objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty
                            'objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            'objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVSTDPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)

                            objStockIssueVoucherApprovalPPT.DC = "C"
                            'objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value ' < SIV No.>-< StockCode-Stock Description 
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + "Stock Issue" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' < SIV No.> “Stock Issue” <Login monthnameyear>
                            objStockIssueVoucherApprovalPPT.COAID = lStockCOAID
                            objStockIssueVoucherApprovalPPT.Value = lSTDPrice
                            objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty

                            'objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            'objStockIssueVoucherApprovalPPT.T4 = String.Empty

                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T0").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T0 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T0").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T1").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T1 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T1").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T2").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T2 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T2").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T3").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T3 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T3").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            End If
                            If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T4").ToString <> String.Empty Then
                                objStockIssueVoucherApprovalPPT.T4 = dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("T4").ToString
                            Else
                                objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            End If

                            objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVSTDPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)
                        End If
                        'SIVSTDPRICE End
                        'SIVVARIANCEPRICE Price Start
                        'if VariancePrice is -ve start
                        If lSTDPrice <> 0 And lVariancePrice < 0 And lVarianceCOAID <> String.Empty Then
                            objStockIssueVoucherApprovalPPT.DC = "D"
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value + "-Variance" ' < SIV No.>-< StockCode-Stock Description 

                            objStockIssueVoucherApprovalPPT.COAID = lStockCOAID
                            objStockIssueVoucherApprovalPPT.Value = Abs(lVariancePrice)
                            objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty
                            objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVVARIANCEPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)

                            objStockIssueVoucherApprovalPPT.DC = "C"
                            'objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value ' < SIV No.>-< StockCode-Stock Description 
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + "Stock Issue" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() + "-Variance"  ' < SIV No.> “Stock Issue” <Login monthnameyear>
                            objStockIssueVoucherApprovalPPT.COAID = lVarianceCOAID
                            objStockIssueVoucherApprovalPPT.Value = Abs(lVariancePrice)
                            objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty
                            objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVVARIANCEPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)
                        End If
                        'if VariancePrice is -ve end
                        'if VariancePrice is +ve start
                        If lSTDPrice <> 0 And lVariancePrice > 0 And lVarianceCOAID <> String.Empty Then
                            objStockIssueVoucherApprovalPPT.DC = "D"
                            'objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value + "-Variance" ' < SIV No.>-< StockCode-Stock Description 
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + "Stock Issue" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() + "-Variance"  ' < SIV No.> “Stock Issue” <Login monthnameyear>
                            objStockIssueVoucherApprovalPPT.COAID = lVarianceCOAID
                            objStockIssueVoucherApprovalPPT.Value = Abs(lVariancePrice)
                            objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty
                            objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVVARIANCEPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)

                            objStockIssueVoucherApprovalPPT.DC = "C"
                            'objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + "Stock Issue" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString()  ' < SIV No.> “Stock Issue” <Login monthnameyear>
                            objStockIssueVoucherApprovalPPT.JournalDetDescp = psSivnumberVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclDesc").Value + "-Variance" ' < SIV No.>-< StockCode-Stock Description 
                            objStockIssueVoucherApprovalPPT.COAID = lStockCOAID
                            objStockIssueVoucherApprovalPPT.Value = Abs(lVariancePrice)
                            objStockIssueVoucherApprovalPPT.DivID = String.Empty
                            objStockIssueVoucherApprovalPPT.YopID = String.Empty
                            objStockIssueVoucherApprovalPPT.BlockID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHID = String.Empty
                            objStockIssueVoucherApprovalPPT.VHDetailCostCodeID = String.Empty
                            objStockIssueVoucherApprovalPPT.T0 = String.Empty
                            objStockIssueVoucherApprovalPPT.T1 = String.Empty
                            objStockIssueVoucherApprovalPPT.T2 = String.Empty
                            objStockIssueVoucherApprovalPPT.T3 = String.Empty
                            objStockIssueVoucherApprovalPPT.T4 = String.Empty
                            objStockIssueVoucherApprovalPPT.StationID = String.Empty
                            objStockIssueVoucherApprovalPPT.Flag = "SIVVARIANCEPRICE"
                            intJournalRowsAffected = StoreIssueVoucherBOL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)
                        End If
                        'if VariancePrice is +ve end
                        'SIVVARIANCEPRICE Price End
                        If intJournalRowsAffected = 0 Then
                            DisplayInfoMessage("Msg62")
                            'MessageBox.Show("Failed to Insert Journa Details Standard price Debit transaction")
                            Exit Sub
                        End If
                    End If
                    ''''---
                    '5th step-vehicle.vhchargedetailinsert start
                    Dim vhchargedetailinsert As Integer = 0
                    If Not (GridViewRow.cells("dgclvhid").value Is DBNull.Value Or GridViewRow.cells("dgclvhid").value Is Nothing) Then
                        '
                        Dim osivppt As New StoreIssueVoucherPPT
                        Dim dsvhdetails As New DataSet
                        osivppt.VHWSCode = GridViewRow.cells("dgclvhno").value.ToString()
                        osivppt.VHDesc = String.Empty
                        osivppt.VHCategoryID = String.Empty
                        osivppt.Type = String.Empty
                        dsvhdetails = StoreIssueVoucherBOL.GetVHNo(osivppt, "yes")
                        '
                        Dim dsSTIssueStockIDDetailSelect As New DataSet
                        dsSTIssueStockIDDetailSelect = StoreIssueVoucherBOL.STIssueStockIDDetailSelect(objStoreIssueVoucherPPT)

                        If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("IssuedValue").ToString <> String.Empty Then
                            lSIVPrice = CDbl(dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("IssuedValue").ToString())
                        Else
                            lSIVPrice = 0
                        End If
                        If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice").ToString <> String.Empty Then
                            lSTDPrice = CDbl(dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice").ToString())
                        Else
                            lSTDPrice = 0
                        End If

                        objStockIssueVoucherApprovalPPT.EstateCodeL = dsvhdetails.Tables(0).Rows(0).Item("locationid") ' should pass the actual value after discussion with anand
                        objStockIssueVoucherApprovalPPT.VHWSCode = GridViewRow.cells("dgclvhno").value.ToString()
                        objStockIssueVoucherApprovalPPT.VHDetailCostCode = GridViewRow.cells("dgclvhdetailcostcode").value.ToString()

                        If Not (dsvhdetails.Tables(0).Rows(0).Item("Type") Is String.Empty Or dsvhdetails.Tables(0).Rows(0).Item("Type") Is DBNull.Value) Then

                            If dsvhdetails.Tables(0).Rows(0).Item("Type").ToString.ToUpper = "VEHICLE" Then
                                objStockIssueVoucherApprovalPPT.Type = "V"
                            ElseIf dsvhdetails.Tables(0).Rows(0).Item("Type").ToString.ToUpper = "WORKSHOP" Then
                                objStockIssueVoucherApprovalPPT.Type = "W"
                            ElseIf dsvhdetails.Tables(0).Rows(0).Item("Type").ToString.ToUpper = "OTHERS" Then
                                objStockIssueVoucherApprovalPPT.Type = "O"
                            End If
                        End If

                        'objstockissuevoucherapprovalppt.type = gridviewrow.cells("dgcltype").value.tostring()
                        objStockIssueVoucherApprovalPPT.AYear = GlobalPPT.intActiveYear
                        objStockIssueVoucherApprovalPPT.AMonth = GlobalPPT.IntLoginMonth
                        objStockIssueVoucherApprovalPPT.LedgerNo = psLedgerNo
                        objStockIssueVoucherApprovalPPT.LedgerType = psLedgerType

                        If lSIVPrice > 0 Then
                            objStockIssueVoucherApprovalPPT.Value = lSIVPrice
                        Else
                            objStockIssueVoucherApprovalPPT.Value = lSTDPrice
                        End If

                        If Not GridViewRow.cells("dgclvhdesc").value Is DBNull.Value Then
                            objStockIssueVoucherApprovalPPT.Descp = GridViewRow.cells("dgclvhdesc").value.ToString() ' should pass the actual value after discussion with anand
                        Else
                            objStockIssueVoucherApprovalPPT.Descp = String.Empty
                        End If
                        objStockIssueVoucherApprovalPPT.UOMID = GridViewRow.cells("dgclUnit").value.ToString
                        objStockIssueVoucherApprovalPPT.RefNo = Me.txtSIVNo.Text
                        objStockIssueVoucherApprovalPPT.Qty = GridViewRow.cells("dgclIssuedQty").value.ToString
                        vhchargedetailinsert = StoreIssueVoucherBOL.VHChargeDetailInsert(objStockIssueVoucherApprovalPPT)

                        If vhchargedetailinsert = 0 Then
                            DisplayInfoMessage("Msg63")
                            'MessageBox.Show("failed to insert vhchargedetail")
                            Exit Sub
                        End If
                    End If
                    'vehicle.vhchargedetailinsert end
                    ''''---
                Next
                'update LedgerAllModule BatchAmount Value
                Dim intUpdateLegerAllModuleBatchAmount As Integer = 0
                objStockIssueVoucherApprovalPPT.DC = "D"
                objStockIssueVoucherApprovalPPT.LedgerID = psLedgerID
                intUpdateLegerAllModuleBatchAmount = StoreIssueVoucherBOL.STIssueLedgerAllModuleUpdate(objStockIssueVoucherApprovalPPT)
                If intUpdateLegerAllModuleBatchAmount = 0 Then
                    DisplayInfoMessage("Msg64")
                    'MessageBox.Show("Failed to Update LedgerAllModule BatchAmount")
                    Exit Sub
                Else
                    'Call TaskMonitor Update after successful approval -Start
                    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    Dim dsTaskMonitorUPDATE As New DataSet
                    objStoreMonthEndClosingPPT.ModID = 2
                    objStoreMonthEndClosingPPT.Task = "SIV approval"
                    objStoreMonthEndClosingPPT.Complete = "Y"
                    dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)
                    'Call TaskMonitor Update after successful approval -End
                End If

                DisplayInfoMessage("Msg65")
                'MessageBox.Show("Transaction Completed")

                GlobalPPT.IsButtonClose = True
                Me.Close()

            End If
        ElseIf cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            If txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg66")
                'MessageBox.Show("Please enter the rejected reason")
                txtRejectedReason.Focus()
                Exit Sub
            Else
                If MsgBox(rm.GetString("Msg67"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Reject the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Dim ds As New DataSet
                    objStoreIssueVoucherPPT.Status = "REJECTED"
                    objStoreIssueVoucherPPT.RejectedReason = txtRejectedReason.Text.Trim()
                    ds = StoreIssueVoucherBOL.updateStoreIssueVoucher(objStoreIssueVoucherPPT, "YES")
                    DisplayInfoMessage("Msg68")
                    'MessageBox.Show("Rejected Successfully")
                    txtRejectedReason.Text = String.Empty

                    GlobalPPT.IsButtonClose = True
                    Me.Close()

                End If
            End If
        End If

    End Sub

    Private Sub DisableFieldsOnApproved()

        dtpSIVDate.Enabled = False
        txtSIVNo.Enabled = False
        txtContractNo.Enabled = False
        btnSearchContractNo.Enabled = False
        txtRemarks.Enabled = False
        txtStockCategory.Enabled = False
        btnSearchStockCategory.Enabled = False
        txtStockCode.Enabled = False
        btnSearchStockCode.Enabled = False
        txtQtyIssued.Enabled = False
        txtUsedFor.Enabled = False
        txtAccountCode.Enabled = False
        btnSearchAccountCode.Enabled = False
        txtT0.Enabled = False
        btnSearchT0.Enabled = False
        txtT1.Enabled = False
        btnSearchT1.Enabled = False
        txtT2.Enabled = False
        btnSearchT2.Enabled = False
        txtT3.Enabled = False
        btnSearchT3.Enabled = False
        txtT4.Enabled = False
        btnSearchT4.Enabled = False
        txtSubBlock.Enabled = False
        btnSearchSubBlock.Enabled = False
        txtDiv.Enabled = False
        btnSearchDiv.Enabled = False
        txtYOP.Enabled = False
        txtStation.Enabled = False
        btnSearchStation.Enabled = False
        txtVHNo.Enabled = False
        btnSearchVHNo.Enabled = False
        txtODOReading.Enabled = False
        txtVHDetailsCostCode.Enabled = False
        btnSearchVHcostCode.Enabled = False
        btnAdd.Enabled = False
        btnSaveAll.Enabled = False
        btnReset.Enabled = False

    End Sub

    Private Sub EnableFieldsOnResetAll()

        dtpSIVDate.Enabled = True
        txtSIVNo.Enabled = True
        'txtContractNo.Enabled = True
        btnSearchContractNo.Enabled = True
        txtRemarks.Enabled = True
        txtStockCategory.Enabled = True
        btnSearchStockCategory.Enabled = True
        txtStockCode.Enabled = True
        btnSearchStockCode.Enabled = True
        txtQtyIssued.Enabled = True
        txtUsedFor.Enabled = True
        txtAccountCode.Enabled = True
        btnSearchAccountCode.Enabled = True
        txtT0.Enabled = True
        btnSearchT0.Enabled = True
        txtT1.Enabled = True
        btnSearchT1.Enabled = True
        txtT2.Enabled = True
        btnSearchT2.Enabled = True
        txtT3.Enabled = True
        btnSearchT3.Enabled = True
        txtT4.Enabled = True
        btnSearchT4.Enabled = True
        'txtDiv.Enabled = True
        'txtYOP.Enabled = True
        txtSubBlock.Enabled = True
        btnSearchSubBlock.Enabled = True
        'If GlobalPPT.psEstateType = "M" Then
        '    txtStation.Enabled = True
        '    btnSearchStation.Enabled = True
        'Else
        '    txtStation.Enabled = False
        '    btnSearchStation.Enabled = False
        'End If
        StationEnableAndDisable()
        txtVHNo.Enabled = True
        btnSearchVHNo.Enabled = True
        txtODOReading.Enabled = True
        txtVHDetailsCostCode.Enabled = True
        btnSearchVHcostCode.Enabled = True
        btnAdd.Enabled = True
        btnSaveAll.Enabled = True
        btnReset.Enabled = True

    End Sub

    Private Sub tbStoreIssueVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbStoreIssueVoucher.Click

        If tbStoreIssueVoucher.SelectedTab Is tbStoreIssueVoucher.TabPages("tbpgViewSIV") Then
            chkViewSIVDate.Focus()

            If (dgIssueVoucher.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And btnSaveAll.Enabled = True) Then
                If MsgBox(rm.GetString("Msg69"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    StoreIssueVoucherBOL.ClearGridView(dgIssueVoucher)
                    GlobalPPT.IsRetainFocus = False
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ShowViewTab()
                Else
                    tbStoreIssueVoucher.SelectedTab = tbpgAdd
                End If
            Else
                ResetAll()
                ShowViewTab()
            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        ElseIf tbStoreIssueVoucher.SelectedTab Is tbStoreIssueVoucher.TabPages("tbpgAdd") Then

            If tbStoreIssueVoucher.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgIssueVoucher.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg69"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ShowAddTab()
                            txtSIVNo.Focus()
                        Else
                            Exit Sub
                        End If
                    End If

                End If
            Else
                Exit Sub '--if approval screen--'
            End If
        End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub ShowAddTab()

        ResetAll()
        txtSIVNo.Focus()
        dtSIVAdd.Rows.Clear()

    End Sub

    Private Sub ShowViewTab()

        BindViewIssueVoucher()
        Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.dtpSIVDate)
        Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.txtSIVDateSearch)
        chkViewSIVDate.Focus()
        ClearViewTabFields()

    End Sub

    Private Sub ClearViewTabFields()

        txtContractNoSearch.Text = String.Empty
        txtSIVNoSearch.Text = String.Empty
        chkViewSIVDate.Checked = False
        cmbStatusSearch.Text = cmbStatusSearch.Items(1) 'For Default OPEN

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        EditViewGridRecord()

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        ShowAddTab()
        tbStoreIssueVoucher.SelectedTab = tbpgAdd

    End Sub

    Private Sub dgIssueVoucher_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgIssueVoucher.KeyDown

        If e.KeyCode = Keys.Return Then
            SIVGrid_Edit()
            e.Handled = True
        End If
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgIssueVoucher, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgIssueVoucher, e)
        'End If

    End Sub

    Private Sub StoreIssueVoucherFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgViewIssueVoucher_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgViewIssueVoucher.KeyDown

        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgViewIssueVoucher, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgViewIssueVoucher, e)
        'End If
    End Sub

    Private Sub EditStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditStripMenuItem3.Click

        SIVGrid_Edit()

    End Sub

    Private Sub DeleteStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteStripMenuItem2.Click


        'If mdiparent.strMenuID = "M6" Then 'if SIV Form
        '    DeleteSIVAddEdit()
        '    'ClearViewTabFields()
        '    'SearchSIV()
        'ElseIf mdiparent.strMenuID = "M15" Then 'if SIV Approval Form
        '    DisplayInfoMessage("Msg70")
        '    'MessageBox.Show(" Record can not be Deleted in approval screen", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

        If dgIssueVoucher.RowCount = 0 Then
            Exit Sub
        ElseIf dgIssueVoucher.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else
            DeleteMultientrydatagrid()
        End If

    End Sub


    Private Sub DeleteMultientrydatagrid()



        lSTIssueDetailsId = dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString

        lDelete = 0
        If lSTIssueDetailsId <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lSTIssueDetailsId)


        End If
        Dim Dr As DataRow
        Dr = dtSIVAdd.Rows.Item(dgIssueVoucher.CurrentRow.Index)
        Dr.Delete()
        dtSIVAdd.AcceptChanges()
        lSTIssueDetailsId = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objSIVPPT As New StoreIssueVoucherPPT

        lDelete = DeleteMultientry.Count
        objSIVPPT.STIssueID = psSIVSTIssueId
        While (lDelete > 0)

            With objSIVPPT

                .STIssueDetailsID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntIPRDetailDelete As New Integer
            IntIPRDetailDelete = StoreIssueVoucherBOL.STIssueDetailDelete(objSIVPPT)

            lDelete = lDelete - 1

        End While


    End Sub


    'Private Sub DeleteSIVAddEdit()

    '    Dim psSIVSTIssueIdDel, psSTIssueDetailsIDDel As String
    '    Me.cmsSIVAddEdit.Visible = False
    '    Dim objSIV As New StoreIssueVoucherPPT
    '    Dim ds As New DataSet

    '    If dgIssueVoucher.Rows.Count > 0 Then
    '        If lblStatus.Text.ToUpper = "OPEN" Or lblStatus.Text.ToUpper = "REJECTED" Then
    '            If MsgBox(rm.GetString("Msg71"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                'If MsgBox("you are about to delete the selected record. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                If dgIssueVoucher.RowCount = 1 Then
    '                    DisplayInfoMessage("Msg72")
    '                    'MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
    '                    Exit Sub
    '                End If
    '                psSIVSTIssueIdDel = dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueId").Value.ToString()
    '                psSTIssueDetailsIDDel = dgIssueVoucher.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString()
    '                objSIV.STIssueID = psSIVSTIssueIdDel
    '                objSIV.STIssueDetailsID = psSTIssueDetailsIDDel


    '                Dim Dr As DataRow
    '                Dr = dtSIVAdd.Rows.Item(dgIssueVoucher.CurrentRow.Index)
    '                Dr.Delete()
    '                dtSIVAdd.AcceptChanges()


    '                If objSIV.STIssueDetailsID <> String.Empty Then

    '                    If StoreIssueVoucherBOL.STIssueDetailDelete(objSIV) = 1 Then
    '                        DisplayInfoMessage("Msg73")
    '                        'MessageBox.Show("Data deleted successfully")
    '                    Else
    '                        DisplayInfoMessage("Msg74")
    '                        'MessageBox.Show("Data operation failed")
    '                    End If

    '                Else
    '                    DisplayInfoMessage("Msg75")
    '                    'MessageBox.Show("Data deleted successfully")
    '                End If

    '            Else
    '                Exit Sub
    '            End If
    '        Else
    '            DisplayInfoMessage("Msg76")
    '            'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Else
    '        DisplayInfoMessage("Msg77")
    '        'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If

    'End Sub


    'Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click

    '    If mdiparent.strMenuID = "M6" Then 'if SIV Form

    '        DeleteAllSIV()

    '        If bDelAllFlag = True Then

    '            txtStockCategory.Text = String.Empty
    '            txtStockCode.Enabled = True
    '            btnSearchStockCode.Enabled = True
    '            'btnSaveAll.Text = "Save All"
    '            If GlobalPPT.strLang = "en" Then
    '                btnSaveAll.Text = "Save All"
    '            ElseIf GlobalPPT.strLang = "ms" Then
    '                btnSaveAll.Text = "Simpan Semua"
    '            End If
    '            lblStatus.Text = "OPEN"
    '            lblRejectedReasonValue.Visible = False
    '            lblRejectedReason1.Visible = False
    '            lblRejReasonColon.Visible = False

    '            'btnAdd.Text = "Add"
    '            If GlobalPPT.strLang = "en" Then
    '                btnAdd.Text = "Add"
    '            ElseIf GlobalPPT.strLang = "ms" Then
    '                btnAdd.Text = "Menambahkan"
    '            End If
    '            psIssueIDVal = String.Empty

    '            ClearAll()

    '            txtIssueBatchTotal.Text = String.Empty
    '            txtSIVNo.Focus()
    '            StoreIssueVoucherBOL.ClearGridView(dgIssueVoucher)

    '        End If
    '    ElseIf mdiparent.strMenuID = "M15" Then 'if SIV Approval Form
    '        DisplayInfoMessage("Msg78")
    '        'MessageBox.Show(" Record can not be Deleted in approval screen", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If


    'End Sub

    'Private Sub DeleteAllSIV()

    '    Me.cmsSIVAddEdit.Visible = False
    '    Dim objSIV As New StoreIssueVoucherPPT
    '    Dim ds As New DataSet
    '    If dgIssueVoucher.Rows.Count > 0 Then
    '        If lblStatus.Text.ToUpper = "OPEN" Or lblStatus.Text.ToUpper = "REJECTED" Then
    '            If MsgBox(rm.GetString("Msg79"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                objSIV.STIssueID = psIssueIDVal
    '                StoreIssueVoucherBOL.DeleteStoreIssueVoucher(objSIV)
    '                DisplayInfoMessage("Msg80")
    '                'MessageBox.Show("Data Deleted Successfully")
    '                bDelAllFlag = True
    '                'BindViewIssueVoucher()
    '            Else
    '                bDelAllFlag = False
    '                'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        Else
    '            DisplayInfoMessage("Msg81")
    '            'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Else
    '        DisplayInfoMessage("Msg82")
    '        'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    '    btnAddFlag = True

    'End Sub


    
    Private Sub StoreIssueVoucherFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'If dgIssueVoucher.RowCount > 0 Then

        '    '

        '    '

        'End If


    End Sub

    Private Sub dgViewIssueVoucher_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewIssueVoucher.CellContentClick

        If e.ColumnIndex = 8 Then

            Me.Cursor = Cursors.WaitCursor
            Dim ObjRecordExist As New Object
            Dim ObjSIV As New StoreIssueVoucherPPT
            Dim ObjSIVBOL As New StoreIssueVoucherBOL
            ObjRecordExist = ObjSIVBOL.SIVRecordIsExisT(ObjSIV)

            If ObjRecordExist = 0 Then
                DisplayInfoMessage("Msg52")
                'MsgBox("No Records Available!")
            Else
                psSIVSTIssueId = dgViewIssueVoucher.SelectedRows(0).Cells("STIssueID").Value.ToString
                StrFrmName = "SIV"
                ReportODBCMethod.ShowDialog()
                StrFrmName = ""
                psSIVSTIssueId = ""
            End If
            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub txtQtyIssued_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyIssued.TextChanged
        'If Val(txtQtyIssued.Text) > 0 Then
        '    txtQtyIssued.Text = Format(Val(txtQtyIssued.Text), "0")
        'End If

    End Sub

    Private Sub lblAvailableQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAvailableQty.TextChanged

        'Commented by Stanley on 25-07-2011
        'If lblAvailableQty.Text <> String.Empty Then
        '    lblAvailableQty.Text = Format(Val(lblAvailableQty.Text), "0")
        'End If

    End Sub

    Private Sub lblMinQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMinQty.TextChanged

        If lblMinQty.Text <> String.Empty Then
            lblMinQty.Text = Format(Val(lblMinQty.Text), "0")
        End If

    End Sub

    Private Sub chkViewSIVDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewSIVDate.CheckedChanged

        If chkViewSIVDate.Checked = True Then
            txtSIVDateSearch.Enabled = True
        Else
            txtSIVDateSearch.Enabled = False
        End If

    End Sub

    Private Sub StoreIssueVoucherFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (dgIssueVoucher.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False) Then

            If MsgBox(rm.GetString("Msg69"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False

            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M6"
                'mdiparent.lblMenuName.Text = "IPR"

            End If

        End If

    End Sub

    Private Sub dgIssueVoucher_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgIssueVoucher.CellContentClick

    End Sub
End Class