Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class StockAdjustmentFrm
    Public strSIVT0analysisID As String = String.Empty
    Public strSIVT1analysisID As String = String.Empty
    Public strSIVT2analysisID As String = String.Empty
    Public strSIVT3analysisID As String = String.Empty
    Public strSIVT4analysisID As String = String.Empty
    Public strSIVAccountID As String = String.Empty
    Public lSTAdjustmentID As String = String.Empty
    Public lStockId As String = String.Empty
    Public lBlockID As String = String.Empty
    Public lT0Id As String = String.Empty
    Public lT1Id As String = String.Empty
    Public lT2Id As String = String.Empty
    Public lT3Id As String = String.Empty
    Public lT4Id As String = String.Empty
    Public lSTAdjustmentNo As String = String.Empty
    Public strStockCode As String
    Public lStockCode As String
    Public lStrAdjQty As String
    Public lSTID As Integer
    Public lStrAdjValue As String
    Public lDIVId As String = String.Empty
    Public lYopId As String = String.Empty
    Public lCOAId As String = String.Empty
    Public dtAddFlag As Boolean = False
    Public strAdjustmentDate As String = String.Empty

    Dim dtAdjustAdd As New DataTable("todgvAdjustAdd")
    Dim columnAdjustAdd As DataColumn
    Dim rowAdjustAdd As DataRow
    Public lSIVStockId As String = String.Empty
    Public strSIVBlockID As String = String.Empty
    Public strSIVDivID As String = String.Empty
    Public strSIVYopID As String = String.Empty
    Public strAdjustT0Val As String = String.Empty
    Public strAdjustT1Val As String = String.Empty
    Public strAdjustT2Val As String = String.Empty
    Public strAdjustT3Val As String = String.Empty
    Public strAdjustT4Val As String = String.Empty
    Public strAdjustStockID As String = String.Empty
    Public strAdjustAccDes As String = String.Empty
    Public strAdjustblockName As String = String.Empty
    Public strAdjustDIVName As String = String.Empty
    Public strAdjustYOPName As String = String.Empty
    Public strAdjustAccCode As String = String.Empty
    Dim isDecimal As Boolean
    Public dateVal As DateTime
    Public lModifiedOn As String = String.Empty
    Public remarksVal As String = String.Empty
    Public AddFlag As Boolean = True
    Public decAdjQty As Double
    Public strLedgerNo As String
    Public strLedgerType As String
    Public FlagInc As Boolean = False
    Public FlagDec As Boolean = False
    Public lVarianceID As String
    Public lStdPrice As Double
    Public StrAdjustDate As String
    Public strAdjustT0Desc As String
    Public strAdjustT1Desc As String
    Public strAdjustT2Desc As String
    Public strAdjustT3Desc As String
    Public strAdjustT4Desc As String
    Public strDivId As String
    Public strYopId As String
    Public strBlockId As String
    Public STAremarksVal As String
    Public STAMenuID As String
    Public lTempStockCode As String
    Public strOldCOACode As String
    Public strStkAdjustAccountID As String
    Public btnAddFlag As Boolean = True
    ' Public lOldCOACode As String

    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")

    Public Shared StrFrmName As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StockAdjustmentFrm))

    Dim DeleteMultientry As New ArrayList
    Dim lDelete As Integer
    Dim lsSTAdjustmentID As String = String.Empty
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StockAdjustmentFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub StockAdjustmentFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub StockAdjustmentFrm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    GridAdjustmentViewBind()
    'End Sub

    Private Sub StockAdjustmentFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        Dim mdiparent As New MDIParent
        STAMenuID = mdiparent.strMenuID
        If STAMenuID = "M10" Then
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpAdjustmentDate)
            FormatDateTimePicker(dtpAdjustmentDate)
            'Me.dtpAdjustmentDate.Format = DateTimePickerFormat.Custom
            'Me.dtpAdjustmentDate.CustomFormat = "dd/MM/yyyy"
            lblStockDescription.Text = "Stock Description"
            If Me.lblStatus.Text = "Rejected" Then
                Me.lblRejectedReason.Visible = True
                Me.txtRejectedReason.Visible = True
                ' Me.lblColon15.Visible = True
            Else
                Me.lblRejectedReason.Visible = False
                Me.txtRejectedReason.Visible = False
                'Me.lblColon15.Visible = False
            End If
            toGetAdjustmentNo()
            cmbAdjustViewStatus.SelectedIndex = 1
            '  Me.cmbStatus.Text = Me.cmbStatus.Items(5)
            GridAdjustmentViewBind()
            Me.tbStockAdjustment.SelectedTab = tbSAView

            'SetUICulture(GlobalPPT.strLang)
        ElseIf STAMenuID = "M17" Then
            toloadAdjust_inApproval()
            grpApproval.Visible = True

            'cmbStatus.Text = "--Select Status--"
            cmbStatus.SelectedIndex = 0

            Me.dtpAdjustmentDate.Format = DateTimePickerFormat.Custom
            Me.dtpAdjustmentDate.CustomFormat = "dd/MM/yyyy"
            Me.lblRejectedReason.Visible = False
            Me.txtRejectedReason.Visible = False
            DisableFieldsApprovalMode()

            

        End If
        SetUICulture(GlobalPPT.strLang)

        txtT0.Text = Helper.T0Default(0)
        lblT0Name.Text = Helper.T0Default(1)
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StockAdjustmentFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            tbStockAdjustment.TabPages("tbpgAdd").Text = rm.GetString("tbStockAdjustment.TabPages(tbpgAdd).Text")
            'tbStockAdjustment.TabPages("tbSAView").Text = rm.GetString("tbStockAdjustment.TabPages(tbSAView).Text")
            If STAMenuID = "M10" Then
                tbStockAdjustment.TabPages("tbSAView").Text = rm.GetString("tbStockAdjustment.TabPages(tbSAView).Text")
            End If
            lblAdjustmentNo.Text = rm.GetString("lblAdjustmentNo.Text")
            lblAdjustmentDate.Text = rm.GetString("lblAdjustmentDate.Text")
            lblStockCode.Text = rm.GetString("lblStockCode.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblAdjustmentUnit.Text = rm.GetString("lblAdjustmentUnit.Text")
            lblAdjustmentStatus.Text = rm.GetString("lblAdjustmentStatus.Text")
            lblPartNo.Text = rm.GetString("lblPartNo.Text")
            lblStockDescription.Text = rm.GetString("lblStockDescription.Text")
            lblAdjValue.Text = rm.GetString("lblAdjValue.Text")
            lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
            lblAvailableQty.Text = rm.GetString("lblAvailableQty.Text")
            rdbtnIncrease.Text = rm.GetString("rdbtnIncrease.Text")
            rdbtnDecrease.Text = rm.GetString("rdbtnDecrease.Text")
            lblAdjQty.Text = rm.GetString("lblAdjQty.Text")

            lblStatus.Text = rm.GetString("lblStatus.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            lblT0.Text = rm.GetString("lblT0.Text")
            lblT1.Text = rm.GetString("lblT1.Text")
            lblT2.Text = rm.GetString("lblT2.Text")
            lblT3.Text = rm.GetString("lblT3.Text")
            lblT4.Text = rm.GetString("lblT4.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnResetIB.Text = rm.GetString("btnResetIB.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnviewReport.Text")
            rdbtnIncrease.Text = rm.GetString("rdbtnIncrease.Text")
            rdbtnDecrease.Text = rm.GetString("rdbtnDecrease.Text")
            'txtRejectedReason.Text = rm.GetString("txtRejectedReason.Text")

            ''''''''''''View Page'''''''''''

            chkAdjustDate.Text = rm.GetString("chkAdjustDate.Text")
            lblAdjSearchNo.Text = rm.GetString("lblAdjSearchNo.Text")
            lblViewStatus.Text = rm.GetString("lblViewStatus.Text")
            btnAdjustSearch.Text = rm.GetString("btnAdjustSearch.Text")
            btnView.Text = rm.GetString("btnView.Text")
            lblSearch.Text = rm.GetString("lblSearch.Text")

            '''''''''''''GRID CAPTIONS'''''''''''''''''''''''''''''
            dgvAdjustDetails.Columns("STAStockCode").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAStockCode).HeaderText")
            dgvAdjustDetails.Columns("STAStockDesc").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAStockDesc).HeaderText")
            dgvAdjustDetails.Columns("STAAdjustmentNo").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAAvailableQty).HeaderText")
            dgvAdjustDetails.Columns("STAPartNo").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAPartNo).HeaderText")
            dgvAdjustDetails.Columns("STAAdjustmentDate").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAAdjustmentDate).HeaderText")
            dgvAdjustDetails.Columns("STAUnit").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAUnit).HeaderText")
            dgvAdjustDetails.Columns("STAAdjustVal").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAAdjustVal).HeaderText")
            dgvAdjustDetails.Columns("STAAdjQty").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAAdjQty).HeaderText")
            'dgvAdjustDetails.Columns("STASubBlock").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STASubBlock).HeaderText")
            dgvAdjustDetails.Columns("STARemarks").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STARemarks).HeaderText")
            'dgvAdjustDetails.Columns("STAAccountDesc").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAAccountDesc).HeaderText")
            dgvAdjustDetails.Columns("STAT0").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAT0).HeaderText")
            dgvAdjustDetails.Columns("STAT1").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAT1).HeaderText")
            dgvAdjustDetails.Columns("STAT2").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAT2).HeaderText")
            dgvAdjustDetails.Columns("STAT3").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAT3).HeaderText")
            dgvAdjustDetails.Columns("STAT4").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAT4).HeaderText")

            dgvAdjustDetails.Columns("STADIV").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STADIV).HeaderText")
            dgvAdjustDetails.Columns("STAYOP").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAYOP).HeaderText")
            dgvAdjustDetails.Columns("STAStatus").HeaderText = rm.GetString("dgvAdjustDetails.Columns(STAStatus).HeaderText")

            ''''''''''''View Grid ''''''''''''''''
            dgvAdjustmentView.Columns("gvAdjustmentNo").HeaderText = rm.GetString("dgvAdjustmentView.Columns(gvAdjustmentNo).HeaderText")
            dgvAdjustmentView.Columns("gvAdjustmentDate").HeaderText = rm.GetString("dgvAdjustmentView.Columns(gvAdjustmentDate).HeaderText")
            dgvAdjustmentView.Columns("gvStatus").HeaderText = rm.GetString("dgvAdjustmentView.Columns(gvStatus).HeaderText")
            dgvAdjustmentView.Columns("gvRemarks").HeaderText = rm.GetString("dgvAdjustmentView.Columns(gvRemarks).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EditAdjustViewApprovalMode(ByVal STAdjustmentNo As String)
        Me.cmsAdjust.Visible = False
        Dim objStkAdjustPPT As New StockAdjustmentPPT
        Dim objStkAdjustBOL As New StockAdjustmentBOL
        Dim dt As New DataTable
        'If dgvLPOView.Rows.Count > 0 Then
        ' Me.btnSaveAll.Text = "Update All"
        'lSTLPOID = Me.dgvLPOView.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString()
        btnSaveAll.Enabled = False
        dtpAdjustmentDate.Enabled = False

        With objStkAdjustPPT
            .AdjustmentNo = STAdjustmentNo
        End With
        dt = objStkAdjustBOL.GetAdjustDetailsInfo(objStkAdjustPPT)
        Me.dgvAdjustDetails.AutoGenerateColumns = False
        Me.dgvAdjustDetails.DataSource = dt

        'Else
        'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub
    Private Sub DisableFieldsApprovalMode()

        cmbStatus.Text = "--Select Status--"
        grpApproval.Visible = True
        txtRemarks.Enabled = False
        txtStockCode.Enabled = False
        txtAdjQty.Enabled = False
        txtAdjValue.Enabled = False
        rdbtnDecrease.Enabled = False
        rdbtnIncrease.Enabled = False
        btnResetAll.Visible = False
        txtRemarks.Enabled = False
        txtAccountCode.Enabled = False
        txtSubBlock.Enabled = False
        txtStockCode.Enabled = False
        txtDiv.Enabled = False
        txtYOP.Enabled = False
        txtT0.Enabled = False
        txtT1.Enabled = False
        txtT2.Enabled = False
        txtT0.Enabled = False
        txtT3.Enabled = False
        txtT4.Enabled = False
        btnResetIB.Visible = False
        btnAdd.Visible = False
        btnSaveAll.Visible = False
        btnSaveAll.Enabled = False
        btnSearchStockCode.Enabled = False
        btnSearchAcCode.Enabled = False
        btnSearchSubBlock.Enabled = False
        btnSearchT0.Enabled = False
        btnSearchT1.Enabled = False
        btnSearchT2.Enabled = False
        btnSearchT3.Enabled = False
        btnSearchT4.Enabled = False
        dtpAdjustmentDate.Enabled = False
    End Sub
    Private Function IsValidComboSelect() As Boolean
        If cmbStatus.SelectedIndex = -1 Then
            DisplayInfoMessage("Msg01")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        If (cmbStatus.Text = "--Select Status--") Then
            DisplayInfoMessage("Msg02")
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
        Dim strLedgerID As String
        Dim intAdjustValue As Double
        'Dim intStdValue As Double

        Dim objStkAdjustPPT As New StockAdjustmentPPT
        Dim objStkAdjustApprovalPPT As New StockAdjustmentApprovalPPT
        Dim objStkAdjustBOL As New StockAdjustmentBOL
        objStkAdjustPPT.STAdjustmentID = lSTAdjustmentID

        objStkAdjustPPT.stockID = lStockId
        objStkAdjustPPT.stockCode = lStockCode
        objStkAdjustPPT.BlockID = lBlockID
        objStkAdjustPPT.AdjQty = lStrAdjQty
        objStkAdjustPPT.AdjValue = lStrAdjValue
        objStkAdjustPPT.ID = lSTID
        objStkAdjustPPT.T0analysisID = lT0Id
        objStkAdjustPPT.T1analysisID = lT1Id
        objStkAdjustPPT.T2analysisID = lT2Id
        objStkAdjustPPT.T3analysisID = lT3Id
        objStkAdjustPPT.T4analysisID = lT4Id
        objStkAdjustPPT.DivID = lDIVId
        objStkAdjustPPT.YopID = lYopId
        objStkAdjustPPT.COAID = lCOAId
        objStkAdjustPPT.VarianceId = lVarianceID
        objStkAdjustPPT.AdjustmentNo = lSTAdjustmentNo

        'Dim frmStkAdjstApproval As StockAdjustmentApprovalFrm
        Dim dsUpdateAdjustDetail As New DataSet

        If cmbStatus.SelectedItem.ToString() = "MANAGER APPROVED" Then
            txtRejectedReason.Text = String.Empty
            If MsgBox(rm.GetString("Msg03"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                Dim dsStkAdjust As New DataSet
                objStkAdjustPPT.Status = "MANAGER APPROVED"

                For Each GridViewRow In dgvAdjustDetails.Rows
                    objStkAdjustPPT.stockCode = GridViewRow.cells("STAStockCode").value
                    objStkAdjustPPT.STAdjustmentID = GridViewRow.cells("STASTAdjustmentId").value
                    StockAdjustmentBOL.Update_AdjustApproval(objStkAdjustPPT)
                    'StockAdjustmentBOL.Update_Adjust(objStkAdjustPPT)
                Next

                DisplayInfoMessage("Msg04")
                'MessageBox.Show("APPROVED SUCESSFULLY")

             
                'INSERT VALUES INTO  LEDGER ALL MODULES WITHOUT BATCH VALUE

                objStkAdjustApprovalPPT.AYear = GlobalPPT.intActiveYear
                objStkAdjustApprovalPPT.AMonth = GlobalPPT.IntActiveMonth
                objStkAdjustApprovalPPT.LedgerDate = dtpAdjustmentDate.Value  'Format(dtpAdjustmentDate.Value, "MM/dd/yyyy")
                objStkAdjustApprovalPPT.LedgerType = "STORE-STA"
                If remarksVal <> String.Empty Then
                    STAremarksVal = txtAdjustmentNo.Text + " - " + remarksVal
                Else
                    STAremarksVal = txtAdjustmentNo.Text
                End If

                objStkAdjustApprovalPPT.Descp = STAremarksVal

                'objStkAdjustApprovalPPT.BatchAmount = intAdjustValue

                Dim dsRowsAffectedLedgerAllModule As New DataSet

                dsRowsAffectedLedgerAllModule = StockAdjustmentBOL.STALedgerAllModuleInsert(objStkAdjustApprovalPPT)
                strLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                objStkAdjustApprovalPPT.LedgerID = strLedgerID
                strLedgerNo = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerNo")
                strLedgerType = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerType")
                objStkAdjustApprovalPPT.LedgerID = strLedgerID

                Dim strArray As String()
                Dim strLoginMonthName As String
                strArray = GlobalPPT.strLoginMonth.Split("-")
                strLoginMonthName = strArray(1)

                'For Each GridViewRow In dgvAdjustDetails.Rows
                For Each GridViewRow In dgvAdjustDetails.Rows

                    '  If lStockId <> String.Empty Then
                    objStkAdjustPPT.stockID = GridViewRow.cells("STAStockID").value
                    objStkAdjustPPT.AdjQty = GridViewRow.cells("STAAdjQty").value
                    objStkAdjustPPT.AdjValue = GridViewRow.cells("STAAdjustVal").value

                    'AVERAGE PRICE CALCULATION

                    dsUpdateAdjustDetail = StockAdjustmentBOL.STAdjustAvgPriceCalculate(objStkAdjustPPT)

                    'Next
                    'FOR ADJUSTMENT PRICE Start

                    'intAdjustValue = Math.Abs(objStkAdjustPPT.AdjValue * objStkAdjustPPT.AdjQty)
                    '                    intAdjustValue = objStkAdjustPPT.AdjValue
                    intAdjustValue = CDbl(GridViewRow.Cells("STAAdjustVal").Value.ToString())
                    objStkAdjustApprovalPPT.Flag = "STA" + "ADJUSTMENT PRICE"
                    'If intAdjustValue > 0 Then
                    'If dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty") > 0 Then

                    If GridViewRow.Cells("STAAdjQty").Value.ToString() > 0 Then

                        'objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STACOAID").value 'Adjustment COAID
                        objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STAStockCOAID").value 'StockCOAID 
                        objStkAdjustApprovalPPT.DC = "D"
                        'objStkAdjustApprovalPPT.AdjValue = CDbl(GridViewRow.Cells("STAAdjustVal").Value.ToString())
                        objStkAdjustApprovalPPT.Value = Math.Abs(intAdjustValue)
                        objStkAdjustApprovalPPT.DivID = GridViewRow.Cells("STADIVID").Value.ToString()
                        objStkAdjustApprovalPPT.YopID = GridViewRow.Cells("STAYOPID").Value.ToString()
                        objStkAdjustApprovalPPT.BlockID = GridViewRow.Cells("STABLOCKID").Value.ToString()

                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T0").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T0analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T0").ToString()
                        Else
                            objStkAdjustApprovalPPT.T0analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T1").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T1analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T1").ToString()
                        Else
                            objStkAdjustApprovalPPT.T1analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T2").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T2analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T2").ToString()
                        Else
                            objStkAdjustApprovalPPT.T2analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T3").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T3analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T3").ToString()
                        Else
                            objStkAdjustApprovalPPT.T3analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T4").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T4analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T4").ToString()
                        Else
                            objStkAdjustApprovalPPT.T4analysisID = String.Empty
                        End If

                        objStkAdjustApprovalPPT.StationID = String.Empty
                        'objStkAdjustApprovalPPT.JournalDetDescp = GridViewRow.Cells("STAStockDesc").Value.ToString()
                        objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + GridViewRow.Cells("STAStockCode").Value.ToString() + "-" + GridViewRow.Cells("STAStockDesc").Value.ToString() '<ITN-ADJ No.> -<” StockCode-Stock Description” as selected in the Adjustment >
                        StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                        objStkAdjustApprovalPPT.T0analysisID = String.Empty
                        objStkAdjustApprovalPPT.T1analysisID = String.Empty
                        objStkAdjustApprovalPPT.T2analysisID = String.Empty
                        objStkAdjustApprovalPPT.T3analysisID = String.Empty
                        objStkAdjustApprovalPPT.T4analysisID = String.Empty

                        'objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STAStockCOAID").value 'StockCOAID 
                        objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STACOAID").value 'Adjustment COAID
                        objStkAdjustApprovalPPT.DC = "C"

                        objStkAdjustApprovalPPT.T0analysisID = GridViewRow.Cells("STAT0Id").Value.ToString()
                        objStkAdjustApprovalPPT.T1analysisID = GridViewRow.Cells("STAT1Id").Value.ToString()
                        objStkAdjustApprovalPPT.T2analysisID = GridViewRow.Cells("STAT2Id").Value.ToString()
                        objStkAdjustApprovalPPT.T3analysisID = GridViewRow.Cells("STAT3Id").Value.ToString()
                        objStkAdjustApprovalPPT.T4analysisID = GridViewRow.Cells("STAT4Id").Value.ToString()

                        objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + "Adjustment" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '<ITN-ADJ No.> “Adjustment”> <loginMonth&Year>
                        StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                        objStkAdjustApprovalPPT.T0analysisID = String.Empty
                        objStkAdjustApprovalPPT.T1analysisID = String.Empty
                        objStkAdjustApprovalPPT.T2analysisID = String.Empty
                        objStkAdjustApprovalPPT.T3analysisID = String.Empty
                        objStkAdjustApprovalPPT.T4analysisID = String.Empty

                    End If

                    If GridViewRow.Cells("STAAdjQty").Value.ToString() < 0 Then

                        'objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STAStockCOAID").value 'StockCOAID
                        objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STACOAID").value 'Adjustment COAID
                        objStkAdjustApprovalPPT.DC = "D"
                        'objStkAdjustApprovalPPT.AdjValue = CDbl(GridViewRow.Cells("STAAdjustVal").Value.ToString())
                        objStkAdjustApprovalPPT.Value = Math.Abs(intAdjustValue)
                        objStkAdjustApprovalPPT.DivID = GridViewRow.Cells("STADIVID").Value.ToString()
                        objStkAdjustApprovalPPT.YopID = GridViewRow.Cells("STAYOPID").Value.ToString()
                        objStkAdjustApprovalPPT.BlockID = GridViewRow.Cells("STABLOCKID").Value.ToString()

                        objStkAdjustApprovalPPT.T0analysisID = GridViewRow.Cells("STAT0Id").Value.ToString()
                        objStkAdjustApprovalPPT.T1analysisID = GridViewRow.Cells("STAT1Id").Value.ToString()
                        objStkAdjustApprovalPPT.T2analysisID = GridViewRow.Cells("STAT2Id").Value.ToString()
                        objStkAdjustApprovalPPT.T3analysisID = GridViewRow.Cells("STAT3Id").Value.ToString()
                        objStkAdjustApprovalPPT.T4analysisID = GridViewRow.Cells("STAT4Id").Value.ToString()

                        objStkAdjustApprovalPPT.StationID = String.Empty
                        objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + GridViewRow.Cells("STAStockCode").Value.ToString() + "-" + GridViewRow.Cells("STAStockDesc").Value.ToString() '<ITN-ADJ No.> -<” StockCode-Stock Description” as selected in the Adjustment >
                        StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                        'objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STACOAID").value 'Adjustment COAID 
                        objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STAStockCOAID").value 'StockCOAID
                        objStkAdjustApprovalPPT.DC = "C"

                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T0").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T0analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T0").ToString()
                        Else
                            objStkAdjustApprovalPPT.T0analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T1").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T1analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T1").ToString()
                        Else
                            objStkAdjustApprovalPPT.T1analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T2").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T2analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T2").ToString()
                        Else
                            objStkAdjustApprovalPPT.T2analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T3").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T3analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T3").ToString()
                        Else
                            objStkAdjustApprovalPPT.T3analysisID = String.Empty
                        End If
                        If dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T4").ToString <> String.Empty Then
                            objStkAdjustApprovalPPT.T4analysisID = dsUpdateAdjustDetail.Tables(1).Rows(0).Item("T4").ToString()
                        Else
                            objStkAdjustApprovalPPT.T4analysisID = String.Empty
                        End If
                        objStkAdjustApprovalPPT.StationID = String.Empty

                        objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + "Adjustment" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '<ITN-ADJ No.> “Adjustment”> <loginMonth&Year>
                        StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                        objStkAdjustApprovalPPT.T0analysisID = String.Empty
                        objStkAdjustApprovalPPT.T1analysisID = String.Empty
                        objStkAdjustApprovalPPT.T2analysisID = String.Empty
                        objStkAdjustApprovalPPT.T3analysisID = String.Empty
                        objStkAdjustApprovalPPT.T4analysisID = String.Empty

                    End If
                    'FOR ADJUSTMENT PRICE End

                    '''''''''For STATNDARD PRICE Start'''''''''''''''''''''

                    'If Not GridViewRow.cells("STASTDPRICE").value Is DBNull.Value Then
                    '    objStkAdjustApprovalPPT.Value = CDbl(GridViewRow.cells("STASTDPRICE").value)
                    'End If
                    'intStdValue = dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty") * objStkAdjustApprovalPPT.Value
                    '' objStkAdjustPPT.StdValue = objStkAdjustPPT.AdjQty * objStkAdjustApprovalPPT.Value
                    'objStkAdjustApprovalPPT.Flag = "STA" + "STANDARD PRICE"
                    'If dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty") > 0 Then
                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STACOAID").value 'Adjustment COAID
                    '    objStkAdjustApprovalPPT.DC = "D"
                    '    objStkAdjustApprovalPPT.Value = intStdValue
                    '    objStkAdjustApprovalPPT.DivID = GridViewRow.Cells("STADIVID").Value.ToString()
                    '    objStkAdjustApprovalPPT.YopID = GridViewRow.Cells("STAYOPID").Value.ToString()
                    '    objStkAdjustApprovalPPT.BlockID = GridViewRow.Cells("STABLOCKID").Value.ToString()
                    '    objStkAdjustApprovalPPT.T0analysisID = lT0Id
                    '    objStkAdjustApprovalPPT.T1analysisID = lT1Id
                    '    objStkAdjustApprovalPPT.T2analysisID = lT2Id
                    '    objStkAdjustApprovalPPT.T3analysisID = lT3Id
                    '    objStkAdjustApprovalPPT.T4analysisID = lT4Id
                    '    objStkAdjustApprovalPPT.StationID = String.Empty
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + GridViewRow.Cells("STAStockCode").Value.ToString() + "-" + GridViewRow.Cells("STAStockDesc").Value.ToString() '<ITN-ADJ No.> -<” StockCode-Stock Description” as selected in the Adjustment >
                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)
                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STAStockCOAID").value 'StockCOAID 
                    '    objStkAdjustApprovalPPT.DC = "C"
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + "Adjustment" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '<ITN-ADJ No.> “Adjustment”> <loginMonth&Year>
                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)
                    'End If
                    'If dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty") < 0 Then
                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STAStockCOAID").value 'StockCOAID
                    '    objStkAdjustApprovalPPT.DC = "D"
                    '    objStkAdjustApprovalPPT.Value = Math.Abs(intStdValue)
                    '    objStkAdjustApprovalPPT.DivID = GridViewRow.Cells("STADIVID").Value.ToString()
                    '    objStkAdjustApprovalPPT.YopID = GridViewRow.Cells("STAYOPID").Value.ToString()
                    '    objStkAdjustApprovalPPT.BlockID = GridViewRow.Cells("STABLOCKID").Value.ToString()

                    '    objStkAdjustApprovalPPT.T0analysisID = lT0Id
                    '    objStkAdjustApprovalPPT.T1analysisID = lT1Id
                    '    objStkAdjustApprovalPPT.T2analysisID = lT2Id
                    '    objStkAdjustApprovalPPT.T3analysisID = lT3Id
                    '    objStkAdjustApprovalPPT.T4analysisID = lT4Id
                    '    objStkAdjustApprovalPPT.StationID = String.Empty
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + GridViewRow.Cells("STAStockCode").Value.ToString() + "-" + GridViewRow.Cells("STAStockDesc").Value.ToString() '<ITN-ADJ No.> -<” StockCode-Stock Description” as selected in the Adjustment >
                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.cells("STACOAID").value 'Adjustment COAID 
                    '    objStkAdjustApprovalPPT.DC = "C"
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + "Adjustment" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '<ITN-ADJ No.> “Adjustment”> <loginMonth&Year>

                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)
                    'End If
                    '''''''''For STATNDARD PRICE End'''''''''''''''''''''

                    '''''''''For Variance  PRICE Start''''''''''''''''''''' 
                    ''Find the Variance price 
                    'Dim dsSTAdjustSelect As DataSet
                    'dsSTAdjustSelect = StockAdjustmentBOL.STAdjustStockIDDetailSelect(objStkAdjustPPT)
                    ''Dim ldStdPrice As Double
                    'Dim ldVariancePrice As Double
                    'Dim ldTotalPrice As Double 'AdjValue
                    'If dsSTAdjustSelect.Tables(0).Rows(0).Item("StdPrice").ToString <> String.Empty Then
                    '    lStdPrice = dsSTAdjustSelect.Tables(0).Rows(0).Item("StdPrice").ToString()
                    'End If
                    ''If dsSTAdjustSelect.Tables(0).Rows(0).Item("AdjValue").ToString <> String.Empty Then
                    ''ldTotalPrice += dsSTAdjustSelect.Tables(0).Rows(0).Item("AdjValue").ToString()
                    'If Not GridViewRow.cells("STAAdjustVal").value.ToString Is DBNull.Value Then
                    '    ldTotalPrice = GridViewRow.cells("STAAdjustVal").value
                    'End If
                    'ldVariancePrice = Math.Abs((lStdPrice * dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty"))) - Math.Abs(ldTotalPrice)

                    'objStkAdjustApprovalPPT.Flag = "STA" + "VARIANCE PRICE"

                    'If dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty") > 0 Then 'If Variance price is +ve , debit the variance COAID and credit the supplier ID
                    '    objStkAdjustApprovalPPT.Value = ldVariancePrice

                    '    objStkAdjustApprovalPPT.DC = "D"
                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.Cells("STAVarianceCOAID").Value.ToString()

                    '    objStkAdjustApprovalPPT.DivID = GridViewRow.Cells("STADIVID").Value.ToString()
                    '    objStkAdjustApprovalPPT.YopID = GridViewRow.Cells("STAYOPID").Value.ToString()
                    '    objStkAdjustApprovalPPT.BlockID = GridViewRow.Cells("STABLOCKID").Value.ToString()

                    '    objStkAdjustApprovalPPT.T0analysisID = lT0Id
                    '    objStkAdjustApprovalPPT.T1analysisID = lT1Id
                    '    objStkAdjustApprovalPPT.T2analysisID = lT2Id
                    '    objStkAdjustApprovalPPT.T3analysisID = lT3Id
                    '    objStkAdjustApprovalPPT.T4analysisID = lT4Id
                    '    objStkAdjustApprovalPPT.StationID = String.Empty
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + GridViewRow.Cells("STAStockCode").Value.ToString() + "-" + GridViewRow.Cells("STAStockDesc").Value.ToString() '<ITN-ADJ No.> -<” StockCode-Stock Description” as selected in the Adjustment >
                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.Cells("STACOAID").Value.ToString() 'psSIVAccountID '
                    '    objStkAdjustApprovalPPT.DC = "C"
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + "Adjustment" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '<ITN-ADJ No.> “Adjustment”> <loginMonth&Year>

                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                    'ElseIf dsUpdateAdjustDetail.Tables(0).Rows(0).Item("AdjQty") < 0 Then 'If Variance price is -ve,Credit the variance COAID and debit the supplier ID
                    '    objStkAdjustApprovalPPT.Value = ldVariancePrice

                    '    objStkAdjustApprovalPPT.DC = "D"
                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.Cells("STACOAID").Value.ToString()

                    '    objStkAdjustApprovalPPT.DivID = GridViewRow.Cells("STADIVID").Value.ToString()
                    '    objStkAdjustApprovalPPT.YopID = GridViewRow.Cells("STAYOPID").Value.ToString()
                    '    objStkAdjustApprovalPPT.BlockID = GridViewRow.Cells("STABLOCKID").Value.ToString()

                    '    objStkAdjustApprovalPPT.T0analysisID = lT0Id
                    '    objStkAdjustApprovalPPT.T1analysisID = lT1Id
                    '    objStkAdjustApprovalPPT.T2analysisID = lT2Id
                    '    objStkAdjustApprovalPPT.T3analysisID = lT3Id
                    '    objStkAdjustApprovalPPT.T4analysisID = lT4Id
                    '    objStkAdjustApprovalPPT.StationID = String.Empty
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + GridViewRow.Cells("STAStockCode").Value.ToString() + "-" + GridViewRow.Cells("STAStockDesc").Value.ToString() '<ITN-ADJ No.> -<” StockCode-Stock Description” as selected in the Adjustment >
                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)

                    '    objStkAdjustApprovalPPT.COAID = GridViewRow.Cells("STAVarianceCOAID").Value.ToString()
                    '    objStkAdjustApprovalPPT.DC = "C"
                    '    objStkAdjustApprovalPPT.JournalDetDescp = txtAdjustmentNo.Text.Trim() + "-" + "Adjustment" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '<ITN-ADJ No.> “Adjustment”> <loginMonth&Year>

                    '    StockAdjustmentBOL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)
                    'End If

                    '''''''''For Variance  PRICE End''''''''''''''''''''' 



                    '  StockAdjustmentBOL.STALedgerAllModuleUpdate(objStkAdjustApprovalPPT)

                    ' End If
                Next

                'UPDATE THE VALUES FOR BATCH VALUE IN LEDGERALL MODULE

                Dim intUpdateLegerAllModuleBatchAmount As Integer = 0
                objStkAdjustApprovalPPT.DC = "D"
                objStkAdjustApprovalPPT.LedgerID = strLedgerID
                intUpdateLegerAllModuleBatchAmount = StockAdjustmentBOL.STALedgerAllModuleUpdate(objStkAdjustApprovalPPT)
                DisplayInfoMessage("Msg05")
                'MessageBox.Show("Transaction Completed")

                GlobalPPT.IsButtonClose = True
                Me.Close()

                If intUpdateLegerAllModuleBatchAmount = 0 Then
                    DisplayInfoMessage("Msg06")
                    'MessageBox.Show("Failed to Update LedgerAllModule BatchAmount")
                    Exit Sub
                Else
                    'Call TaskMonitor Update after successful approval -Start

                    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    Dim dsTaskMonitorUPDATE As New DataSet
                    objStoreMonthEndClosingPPT.ModID = 2
                    objStoreMonthEndClosingPPT.Task = "Stock adjustment approval"
                    objStoreMonthEndClosingPPT.Complete = "Y"
                    dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)

                    'Call TaskMonitor Update after successful approval -End
                End If

            End If
        ElseIf cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            If txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg07")
                'MessageBox.Show("Please enter the rejected reason")
                txtRejectedReason.Focus()
                Exit Sub
            Else
                If MsgBox(rm.GetString("Msg08"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Reject the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Dim ds As New DataSet
                    objStkAdjustPPT.Status = "REJECTED"
                    For Each GridViewRow In dgvAdjustDetails.Rows

                        objStkAdjustPPT.STAdjustmentID = GridViewRow.cells("STASTAdjustmentId").value
                        objStkAdjustPPT.stockID = GridViewRow.cells("STAStockID").value
                        objStkAdjustPPT.AdjQty = GridViewRow.cells("STAAdjQty").value
                        objStkAdjustPPT.AdjValue = GridViewRow.cells("STAAdjustVal").value
                        objStkAdjustPPT.RejectedReason = txtRejectedReason.Text.Trim()
                        StockAdjustmentBOL.Update_AdjustApproval(objStkAdjustPPT)
                    Next
                    DisplayInfoMessage("Msg09")
                    'MessageBox.Show("Rejected Successfully")
                    txtRejectedReason.Text = String.Empty

                    GlobalPPT.IsButtonClose = True
                    Me.Close()

                End If
            End If
        End If



    End Sub
    Private Sub toloadAdjust_inApproval()
        Dim MdiParent As New MDIParent

        If MdiParent.strMenuID = "M17" Then
            tbStockAdjustment.SelectedTab = tbpgAdd
            tbStockAdjustment.TabPages.Remove(tbSAView)
        Else
            'tcIPR.SelectedTab = tbIPR
            'tcIPR.TabPages.Remove(tbView)
            'cmbSIVNO.Text = sivnumberVal
            'fillIssueBtachTotalValueDs(sivnumberVal)
            ''//Remove tab page
            ''tabControl1.TabPages.Remove(tabPage2);
            ''//Insert at index 1
            ''tabControl1.TabPages.Insert(1, tabPage2);
        End If
    End Sub
    'Sub SetUICulture(ByVal culture As String)
    '    ' get a reference to the ResourceManager for this form
    '    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionFrm))
    '    Try
    '        'set the culture as per the selection and 
    '        'load the appropriate strings for button, label, etc.
    '        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

    '        lblIPRDate.Text = rm.GetString("lblIPRDate.Text")
    '        lblCategory.Text = rm.GetString("lblCategory.Text")
    '        lblStockCode.Text = rm.GetString("lblStockCode.Text")
    '        lblRequestedQty.Text = rm.GetString("lblRequestedQty.Text")
    '        lblUnit.Text = rm.GetString("lblUnit.Text")
    '        lblIPRNo.Text = rm.GetString("lblIPRNo.Text")
    '        lblCategcode.Text = rm.GetString("lblCategcode.Text")
    '        lblStockDes.Text = rm.GetString("lblStockDes.Text")
    '        lblUnitPrice.Text = rm.GetString("lblUnitPrice.Text")
    '        lblTotalPrice.Text = rm.GetString("lblTotalPrice.Text")
    '        lblAvailableQty.Text = rm.GetString("lblAvailableQty.Text")
    '        lblDeliveredTo.Text = rm.GetString("lblDeliveredTo.Text")
    '        lblClassification.Text = rm.GetString("lblClassification.Text")
    '        lblRequiredFor.Text = rm.GetString("lblRequiredFor.Text")
    '        lblStatus.Text = rm.GetString("lblStatus.Text")
    '        lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
    '        btnAdd.Text = rm.GetString("btnAdd.Text")
    '        btnReset.Text = rm.GetString("btnReset.Text")
    '        gbIPRAdd.Text = rm.GetString("gbIPRAdd.Text")
    '        gbEnquipmentData.Text = rm.GetString("gbEnquipmentData.Text")
    '        lblMakeandModel.Text = rm.GetString("lblMakeandModel.Text")
    '        lblChassisSerialNo.Text = rm.GetString("lblChassisSerialNo.Text")
    '        lblEngine.Text = rm.GetString("lblEngine.Text")
    '        lblFixedAssetNo.Text = rm.GetString("lblFixedAssetNo.Text")
    '        btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
    '        btnClose.Text = rm.GetString("btnClose.Text")
    '        pnlCategorySearch.Text = rm.GetString("pnlCategorySearch.Text")
    '        lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
    '        lblviewIPRDate.Text = rm.GetString("lblviewIPRDate.Text")
    '        lblviewIPRno.Text = rm.GetString("lblviewIPRno.Text")
    '        lblviewCategory.Text = rm.GetString("lblviewCategory.Text")
    '        lblviewClassification.Text = rm.GetString("lblviewClassification.Text")
    '        lblviewRequiredfor.Text = rm.GetString("lblviewRequiredfor.Text")
    '        lblviewDeliveredto.Text = rm.GetString("lblviewDeliveredto.Text")
    '        lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
    '        btnSearch.Text = rm.GetString("btnSearch.Text")
    '        btnviewReport.Text = rm.GetString("btnviewReport.Text")

    '    Catch
    '        'display a message if the culture is not supported
    '        'try passing bn (Bengali) for testing
    '        MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub GridAdjustmentViewBind()
        'ClearGridView(dgAdjustment)

        Dim objAdjustmentPPT As New StockAdjustmentPPT
        Dim objAdjustmentBOL As New StockAdjustmentBOL
        Dim dt As New DataTable
        With objAdjustmentPPT
            'Dim str As String = cmbStatus.SelectedItem.ToString()
            Dim str As String = cmbAdjustViewStatus.SelectedItem.ToString()

            If cmbAdjustViewStatus.SelectedItem.ToString() = "SELECT ALL" Then
                If chkAdjustDate.Checked = True Then
                    dtpAdjustmentDate.Enabled = True
                    .AdjustmentDate = Me.dtpAdjustmentViewDate.Value 'Format(Me.dtpAdjustmentViewDate.Value, "MM/dd/yyyy")
                Else
                    dtpAdjustmentDate.Enabled = False
                    .AdjustmentDate = Nothing
                End If
                .AdjustmentNo = String.Empty
            Else

                If chkAdjustDate.Checked = True Then
                    .AdjustmentDate = Me.dtpAdjustmentViewDate.Value 'Format(Me.dtpAdjustmentViewDate.Value, "MM/dd/yyyy")
                Else
                    .AdjustmentDate = Nothing
                End If
                '.IPRNo = Me.txtviewIPRNo.Text
                '.Status = cmbStatus.SelectedItem.ToString()
            End If
            .AdjustmentNo = Trim(Me.txtAdjusViewtNo.Text)
            .Status = cmbAdjustViewStatus.SelectedItem.ToString()
            If .Status = "SELECT ALL" Then
                .Status = ""
            Else
                .Status = cmbAdjustViewStatus.SelectedItem.ToString()
            End If

        End With

        dt = objAdjustmentBOL.GetAdjustmentDetails(objAdjustmentPPT)
        If dt.Rows.Count <> 0 Then

            Me.dgvAdjustmentView.DataSource = dt
            dgvAdjustmentView.AutoGenerateColumns = False
            lblView.Visible = False
        Else
            Me.dgvAdjustmentView.DataSource = Nothing
            dgvAdjustmentView.AutoGenerateColumns = False
            ClearGridView(dgvAdjustmentView) '''''clear the records from grid view
            lblView.Visible = True
            txtAdjusViewtNo.Text = ""
            cmbAdjustViewStatus.Text = "OPEN"
            Exit Sub
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub
    Private Sub toGetAdjustmentNo()
        Dim objAdjustmentPPT As New StockAdjustmentPPT
        Dim objAdjustmentBOL As New StockAdjustmentBOL
        Dim SANo As String
        SANo = objAdjustmentBOL.GetSAAutoNo()
        txtAdjustmentNo.Text = SANo
        objAdjustmentPPT = objAdjustmentBOL.GetAdjustmentNo(objAdjustmentPPT)
        With objAdjustmentPPT
            If .AdjustmentNo <> "" Then
                'txtAdjustmentNo.Text = .AdjustmentNo
            Else
                DisplayInfoMessage("Msg10")
                'MessageBox.Show("No records for Adjustment in Store Configuration")
            End If
            'Me.txtAdjustmentNo.Text = .AdjustmentNo
        End With

    End Sub
    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click
        Dim frmStockCodeLookup As New StockCodeByCategoryLookup
        frmStockCodeLookup.ShowDialog()
        If frmStockCodeLookup._lStockCode <> String.Empty Then
            Me.strAdjustStockID = frmStockCodeLookup._lStockID
            Me.txtStockCode.Text = frmStockCodeLookup._lStockCode
            strStockCode = frmStockCodeLookup._lStockCode
            Me.lblDescription.Text = frmStockCodeLookup._lStockDesc
            Me.lblUnit.Text = frmStockCodeLookup._lUnit
            lblAvailableDesc.Text = frmStockCodeLookup._lAvailableQty
            '''''''''''lblPartNoDesc.Text = frmStockCodeLookup._lPartNo
        End If

    End Sub

    Private Sub BindStockCode()

        Dim ds As New DataSet
        Dim objStkAdjustmentPPT As New StockAdjustmentPPT
        Dim objStkAdjustmentBOL As New StockAdjustmentBOL

        ds = objStkAdjustmentBOL.GetStockCode(objStkAdjustmentPPT)

    End Sub

    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
        clear()
    End Sub
    Private Sub clear()
        'txtRemarks.Text = ""
        txtAdjQty.Text = ""
        txtAdjValue.Text = ""
        txtStockCode.Text = ""
        lblDescription.Text = ""
        lblUnit.Text = ""
        'lSTAdjustmentID = ""
        txtAccountCode.Text = ""
        lblAccountDesc.Text = String.Empty
        'txtT0.Text = ""
        'lblT0Name.Text = String.Empty
        txtT1.Text = ""
        lblT1Name.Text = String.Empty
        txtT2.Text = ""
        lblT2Name.Text = String.Empty
        txtT3.Text = ""
        lblT3Name.Text = String.Empty
        txtT4.Text = ""
        lblT4Name.Text = String.Empty
        lblAvailableDesc.Text = String.Empty
        lblPartNoDesc.Text = String.Empty
        txtDiv.Text = ""
        lblDivName.Text = ""
        txtYOP.Text = ""
        lblYOPName.Text = ""
        txtSubBlock.Text = ""
        lblOldCOACode.Text = ""

        Me.strSIVDivID = ""
        Me.strSIVYopID = ""
        Me.strSIVBlockID = ""
        Me.strAdjustT0Val = ""
        lT0Id = ""
        Me.strAdjustT1Val = ""
        lT1Id = ""
        Me.strAdjustT2Val = ""
        lT2Id = ""
        Me.strAdjustT3Val = ""
        lT3Id = ""
        Me.strAdjustT4Val = ""
        lT4Id = ""
        btnAddFlag = True
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
    End Sub
    Private Function StockCodeExist(ByVal StockCode As String) As Boolean
        Dim objDataGridViewRow As New DataGridViewRow
        'If AddFlag = True Then
        For Each objDataGridViewRow In dgvAdjustDetails.Rows
            If StockCode = objDataGridViewRow.Cells("STAStockCode").Value.ToString() Then
                txtStockCode.Text = ""
                'txtRequestedQty.Text = ""
                txtStockCode.Focus()
                Return True
            End If
        Next
        Return False
        'End If
    End Function

    Private Sub SaveAdjustmentDetail()

        Dim intRowcount As Integer = dtAdjustAdd.Rows.Count

        Dim objStkAdjustmentPPT As New StockAdjustmentPPT
        If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 

            rowAdjustAdd = dtAdjustAdd.NewRow()

            If intRowcount = 0 And dtAddFlag = False Then

                columnAdjustAdd = New DataColumn("AdjustmentDate", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("BlockName", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("AccountCode", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("AccountDesc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("AdjustmentNo", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("Status", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("Remarks", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("STAdjustmentID", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("UOM", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("AdjQty", System.Type.[GetType]("System.Decimal"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("AdjValue", System.Type.[GetType]("System.Decimal"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T0Value", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T1Value", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T2Value", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T3Value", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T4Value", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("COAID", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("DIVID", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("YOPID", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("BlockID", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("StockID", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("STDPrice", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)

                columnAdjustAdd = New DataColumn("AvailableQty", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)

                columnAdjustAdd = New DataColumn("T0Id", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T1Id", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T2Id", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T3Id", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T4Id", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)

                columnAdjustAdd = New DataColumn("T0Desc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T1Desc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T2Desc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T3Desc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("T4Desc", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)
                columnAdjustAdd = New DataColumn("OldCOACode", System.Type.[GetType]("System.String"))
                dtAdjustAdd.Columns.Add(columnAdjustAdd)


                rowAdjustAdd("AdjustmentDate") = Me.dtpAdjustmentDate.Value
                rowAdjustAdd("BlockName") = Me.txtSubBlock.Text
                rowAdjustAdd("AccountCode") = Me.txtAccountCode.Text
                rowAdjustAdd("AdjustmentNo") = Me.txtAdjustmentNo.Text
                rowAdjustAdd("Status") = Me.lblStatus.Text
                rowAdjustAdd("Remarks") = Me.txtRemarks.Text
                'rowAdjustAdd("STAdjustmentID") = Me.lSTAdjustmentID
                rowAdjustAdd("StockCode") = Me.txtStockCode.Text.ToString()
                rowAdjustAdd("StockDesc") = Me.lblDescription.Text
                rowAdjustAdd("AccountDesc") = Me.lblAccountDesc.Text
                rowAdjustAdd("UOM") = Me.lblUnit.Text
                If decAdjQty <> 0 Then
                    rowAdjustAdd("AdjQty") = CDbl(Me.decAdjQty)

                    If txtAdjValue.Text.Trim <> String.Empty Then
                        If decAdjQty < 0 Then
                            rowAdjustAdd("AdjValue") = -1 * CDbl(txtAdjValue.Text.Trim)
                        Else
                            rowAdjustAdd("AdjValue") = CDbl(txtAdjValue.Text.Trim)
                        End If

                    End If
                ElseIf decAdjQty = 0 Then
                    decAdjQty = Nothing
                End If
             

                rowAdjustAdd("StockID") = Me.strAdjustStockID
                'rowAdjustAdd("COAID") = Me.strSIVAccountID
                rowAdjustAdd("COAID") = Me.strStkAdjustAccountID
                rowAdjustAdd("DIVID") = Me.strSIVDivID
                rowAdjustAdd("YOPID") = Me.strSIVYopID
                rowAdjustAdd("BlockID") = Me.strSIVBlockID
                rowAdjustAdd("T0Value") = Me.strAdjustT0Val
                rowAdjustAdd("T1Value") = Me.strAdjustT1Val
                rowAdjustAdd("T2Value") = Me.strAdjustT2Val
                rowAdjustAdd("T3Value") = Me.strAdjustT3Val
                rowAdjustAdd("T4Value") = Me.strAdjustT4Val
                rowAdjustAdd("Remarks") = Me.txtRemarks.Text
                'rowAdjustAdd("StdPrice") = Me.txtRemarks.Text

                rowAdjustAdd("AvailableQty") = Me.lblAvailableDesc.Text
                rowAdjustAdd("PartNo") = Me.lblPartNoDesc.Text

                'rowAdjustAdd("T0Id") = Me.strSIVT0analysisID
                'rowAdjustAdd("T1Id") = Me.strSIVT1analysisID
                'rowAdjustAdd("T2Id") = Me.strSIVT2analysisID
                'rowAdjustAdd("T3Id") = Me.strSIVT3analysisID
                'rowAdjustAdd("T4Id") = Me.strSIVT4analysisID

                rowAdjustAdd("T0Id") = Me.lT0Id
                rowAdjustAdd("T1Id") = Me.lT1Id
                rowAdjustAdd("T2Id") = Me.lT2Id
                rowAdjustAdd("T3Id") = Me.lT3Id
                rowAdjustAdd("T4Id") = Me.lT4Id


                rowAdjustAdd("T0Desc") = Me.strAdjustT0Desc
                rowAdjustAdd("T1Desc") = Me.strAdjustT1Desc
                rowAdjustAdd("T2Desc") = Me.strAdjustT2Desc
                rowAdjustAdd("T3Desc") = Me.strAdjustT3Desc
                rowAdjustAdd("T4Desc") = Me.strAdjustT4Desc
                rowAdjustAdd("OldCOACode") = Me.strOldCOACode

                dtAdjustAdd.Rows.InsertAt(rowAdjustAdd, intRowcount)
                dtAddFlag = True

            Else

                rowAdjustAdd("AdjustmentDate") = Me.dtpAdjustmentDate.Value
                rowAdjustAdd("BlockName") = Me.txtSubBlock.Text
                rowAdjustAdd("AccountCode") = Me.txtAccountCode.Text
                rowAdjustAdd("AdjustmentNo") = Me.txtAdjustmentNo.Text
                rowAdjustAdd("Status") = Me.lblStatus.Text
                rowAdjustAdd("Remarks") = Me.txtRemarks.Text
                ' rowAdjustAdd("STAdjustmentID") = Me.lSTAdjustmentID
                rowAdjustAdd("StockCode") = Me.txtStockCode.Text.ToString()
                rowAdjustAdd("StockDesc") = Me.lblDescription.Text
                rowAdjustAdd("UOM") = Me.lblUnit.Text
                If decAdjQty <> 0 Then
                    rowAdjustAdd("AdjQty") = decAdjQty
                    If txtAdjValue.Text.Trim <> String.Empty Then
                        If decAdjQty < 0 Then
                            rowAdjustAdd("AdjValue") = -1 * CDbl(txtAdjValue.Text.Trim)
                        Else
                            rowAdjustAdd("AdjValue") = CDbl(txtAdjValue.Text.Trim)
                        End If

                    End If
                End If
                'If txtAdjValue.Text <> String.Empty Then
                '    rowAdjustAdd("AdjValue") = Me.txtAdjValue.Text
                'End If
                rowAdjustAdd("StockID") = Me.strAdjustStockID
                'rowAdjustAdd("COAID") = Me.strSIVAccountID
                rowAdjustAdd("COAID") = Me.strStkAdjustAccountID
                rowAdjustAdd("DIVID") = Me.strSIVDivID
                rowAdjustAdd("YOPID") = Me.strSIVYopID
                rowAdjustAdd("BlockID") = Me.strSIVBlockID
                rowAdjustAdd("T0Value") = Me.strAdjustT0Val
                rowAdjustAdd("T1Value") = Me.strAdjustT1Val
                rowAdjustAdd("T2Value") = Me.strAdjustT2Val
                rowAdjustAdd("T3Value") = Me.strAdjustT3Val
                rowAdjustAdd("T4Value") = Me.strAdjustT4Val
                rowAdjustAdd("Remarks") = Me.txtRemarks.Text
                rowAdjustAdd("AccountDesc") = Me.lblAccountDesc.Text

                'rowAdjustAdd("StdPrice") = Me.txtRemarks.Text

                rowAdjustAdd("AvailableQty") = Me.lblAvailableDesc.Text
                rowAdjustAdd("PartNo") = Me.lblPartNoDesc.Text

                'rowAdjustAdd("T0Id") = Me.strSIVT0analysisID
                'rowAdjustAdd("T1Id") = Me.strSIVT1analysisID
                'rowAdjustAdd("T2Id") = Me.strSIVT2analysisID
                'rowAdjustAdd("T3Id") = Me.strSIVT3analysisID
                'rowAdjustAdd("T4Id") = Me.strSIVT4analysisID

                rowAdjustAdd("T0Id") = Me.lT0Id
                rowAdjustAdd("T1Id") = Me.lT1Id
                rowAdjustAdd("T2Id") = Me.lT2Id
                rowAdjustAdd("T3Id") = Me.lT3Id
                rowAdjustAdd("T4Id") = Me.lT4Id

                rowAdjustAdd("T0Desc") = Me.strAdjustT0Desc
                rowAdjustAdd("T1Desc") = Me.strAdjustT1Desc
                rowAdjustAdd("T2Desc") = Me.strAdjustT2Desc
                rowAdjustAdd("T3Desc") = Me.strAdjustT3Desc
                rowAdjustAdd("T4Desc") = Me.strAdjustT4Desc
                rowAdjustAdd("OldCOACode") = Me.strOldCOACode
                dtAdjustAdd.Rows.InsertAt(rowAdjustAdd, intRowcount)

                End If
        Else
            DisplayInfoMessage("Msg11")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        With dgvAdjustDetails
            .DataSource = dtAdjustAdd
            .AutoGenerateColumns = False
        End With
        btnSaveAll.Focus()

    End Sub
    Private Sub UpdateAdjustDetails()
        Dim intCount As Integer = dgvAdjustDetails.CurrentRow.Index
        ' If Not StockCodeExist(txtStockCode.Text) Then 'StockCode Validation 
        If lTempStockCode = txtStockCode.Text Then
            dgvAdjustDetails.Rows(intCount).Cells("STAAdjustmentNo").Value = Me.txtAdjustmentNo.Text

            StrAdjustDate = Me.dtpAdjustmentDate.Text
            strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
            dgvAdjustDetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate
            ' If Not dgvAdjustDetails.Rows(intCount).Cells("STAAdjQty").Value Is Nothing Then
            If decAdjQty <> 0 Then
                dgvAdjustDetails.Rows(intCount).Cells("STAAdjQty").Value = CDbl(decAdjQty)
                If txtAdjValue.Text.Trim <> String.Empty Then
                    If decAdjQty < 0 Then
                        dgvAdjustDetails.Rows(intCount).Cells("STAAdjustVal").Value = -1 * CDbl(txtAdjValue.Text.Trim)
                    Else
                        dgvAdjustDetails.Rows(intCount).Cells("STAAdjustVal").Value = CDbl(txtAdjValue.Text.Trim)
                    End If

                End If
            Else
                dgvAdjustDetails.Rows(intCount).Cells("STAAdjQty").Value = 0
            End If
            'If Not dgvAdjustDetails.Rows(intCount).Cells("STAAdjustVal").Value Is Nothing Then
            
            dgvAdjustDetails.Rows(intCount).Cells("STAStockID").Value = strAdjustStockID
            dgvAdjustDetails.Rows(intCount).Cells("STARejectedReason").Value = Me.txtRejectedReason.Text
            dgvAdjustDetails.Rows(intCount).Cells("STAStatus").Value = Me.lblStatus.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAAccountCode").Value = txtAccountCode.Text
            dgvAdjustDetails.Rows(intCount).Cells("STAYOP").Value = txtYOP.Text
            dgvAdjustDetails.Rows(intCount).Cells("STADIV").Value = txtDiv.Text
            dgvAdjustDetails.Rows(intCount).Cells("STASubBlock").Value = txtSubBlock.Text

            'dgvAdjustDetails.Rows(intCount).Cells("STACOAID").Value = strSIVAccountID
            dgvAdjustDetails.Rows(intCount).Cells("STACOAID").Value = strStkAdjustAccountID
            dgvAdjustDetails.Rows(intCount).Cells("STAYOPID").Value = strSIVYopID
            dgvAdjustDetails.Rows(intCount).Cells("STADIVID").Value = strSIVDivID
            dgvAdjustDetails.Rows(intCount).Cells("STABlockID").Value = strSIVBlockID

            dgvAdjustDetails.Rows(intCount).Cells("STAT0").Value = Me.txtT0.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT0Id").Value = Me.strSIVT0analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT0Id").Value = Me.lT0Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT0Desc").Value = Me.lblT0Name.Text
            dgvAdjustDetails.Rows(intCount).Cells("STAStockCode").Value = Me.txtStockCode.Text
            dgvAdjustDetails.Rows(intCount).Cells("STASTAdjustmentId").Value = Me.lSTAdjustmentID


            dgvAdjustDetails.Rows(intCount).Cells("STAT1").Value = Me.txtT1.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT1Id").Value = Me.strSIVT1analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT1Id").Value = Me.lT1Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT1Desc").Value = Me.lblT1Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAT2").Value = Me.txtT2.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT2Id").Value = Me.strSIVT2analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT2Id").Value = Me.lT2Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT2Desc").Value = Me.lblT2Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAT3").Value = Me.txtT3.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT3Id").Value = Me.strSIVT3analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT3Id").Value = Me.lT3Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT3Desc").Value = Me.lblT3Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAT4").Value = Me.txtT4.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT4Id").Value = Me.strSIVT4analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT4Id").Value = Me.lT4Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT4Desc").Value = Me.lblT4Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STARemarks").Value = txtRemarks.Text
            dgvAdjustDetails.Rows(intCount).Cells("STASTAdjustmentID").Value = lSTAdjustmentID
            'dgvAdjustDetails.Rows(intCount).Cells("STAStockCode").Value = 
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            btnAddFlag = True
            clear()
            btnSaveAll.Focus()


            

        ElseIf Not StockCodeExist(txtStockCode.Text) Then
            dgvAdjustDetails.Rows(intCount).Cells("STAAdjustmentNo").Value = Me.txtAdjustmentNo.Text

            StrAdjustDate = Me.dtpAdjustmentDate.Text
            strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
            dgvAdjustDetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate
            If Not dgvAdjustDetails.Rows(intCount).Cells("STAAdjQty").Value Is Nothing Then
                dgvAdjustDetails.Rows(intCount).Cells("STAAdjQty").Value = CDbl(decAdjQty)

                If Not dgvAdjustDetails.Rows(intCount).Cells("STAAdjustVal").Value Is Nothing Then
                    If CDbl(decAdjQty) < 0 Then
                        dgvAdjustDetails.Rows(intCount).Cells("STAAdjustVal").Value = -1 * CDbl(Me.txtAdjValue.Text.Trim)
                    Else
                        dgvAdjustDetails.Rows(intCount).Cells("STAAdjustVal").Value = Me.txtAdjValue.Text.Trim
                    End If

                End If
            End If

            dgvAdjustDetails.Rows(intCount).Cells("STAStockID").Value = strAdjustStockID
            dgvAdjustDetails.Rows(intCount).Cells("STARejectedReason").Value = Me.txtRejectedReason.Text
            dgvAdjustDetails.Rows(intCount).Cells("STAStatus").Value = Me.lblStatus.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAAccountCode").Value = txtAccountCode.Text
            dgvAdjustDetails.Rows(intCount).Cells("STAYOP").Value = txtYOP.Text
            dgvAdjustDetails.Rows(intCount).Cells("STADIV").Value = txtDiv.Text
            dgvAdjustDetails.Rows(intCount).Cells("STASubBlock").Value = txtSubBlock.Text

            'dgvAdjustDetails.Rows(intCount).Cells("STACOAID").Value = strSIVAccountID
            dgvAdjustDetails.Rows(intCount).Cells("STACOAID").Value = strStkAdjustAccountID
            dgvAdjustDetails.Rows(intCount).Cells("STAYOPID").Value = strSIVYopID
            dgvAdjustDetails.Rows(intCount).Cells("STADIVID").Value = strSIVDivID
            dgvAdjustDetails.Rows(intCount).Cells("STABlockID").Value = strSIVBlockID

            dgvAdjustDetails.Rows(intCount).Cells("STAT0").Value = Me.txtT0.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT0Id").Value = Me.strSIVT0analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT0Id").Value = Me.lT0Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT0Desc").Value = Me.lblT0Name.Text
            dgvAdjustDetails.Rows(intCount).Cells("STAStockCode").Value = Me.txtStockCode.Text
            dgvAdjustDetails.Rows(intCount).Cells("STASTAdjustmentId").Value = Me.lSTAdjustmentID


            dgvAdjustDetails.Rows(intCount).Cells("STAT1").Value = Me.txtT1.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT1Id").Value = Me.strSIVT1analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT1Id").Value = Me.lT1Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT1Desc").Value = Me.lblT1Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAT2").Value = Me.txtT2.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT2Id").Value = Me.strSIVT2analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT2Id").Value = Me.lT2Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT2Desc").Value = Me.lblT2Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAT3").Value = Me.txtT3.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT3Id").Value = Me.strSIVT3analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT3Id").Value = Me.lT3Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT3Desc").Value = Me.lblT3Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STAT4").Value = Me.txtT4.Text
            'dgvAdjustDetails.Rows(intCount).Cells("STAT4Id").Value = Me.strSIVT4analysisID
            dgvAdjustDetails.Rows(intCount).Cells("STAT4Id").Value = Me.lT4Id
            dgvAdjustDetails.Rows(intCount).Cells("STAT4Desc").Value = Me.lblT4Name.Text

            dgvAdjustDetails.Rows(intCount).Cells("STARemarks").Value = txtRemarks.Text
            dgvAdjustDetails.Rows(intCount).Cells("STASTAdjustmentID").Value = lSTAdjustmentID
            'dgvAdjustDetails.Rows(intCount).Cells("STAStockCode").Value = 
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            btnAddFlag = True
            clear()
            btnSaveAll.Focus()
        Else
            DisplayInfoMessage("Msg12")
            'MessageBox.Show("Sorry this stock code already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Public Sub BindAdjustMast_inApproval(ByVal strSTAdjustmentID As String, ByVal strStockId As String, ByVal strAdjustmentNo As String, ByVal strAdjustmentDate As String, ByVal strStatus As String, ByVal strRejectedReason As String, ByVal strAdjQty As Double, ByVal strAdjValue As Double, ByVal strCOAID As String, ByVal strDIVID As String, ByVal strYopID As String, ByVal strBlockID As String, ByVal strT0 As String, ByVal strT1 As String, ByVal strT2 As String, ByVal strT3 As String, ByVal strT4 As String, ByVal strRemarks As String, ByVal strModifiedOn As String, ByVal strID As Integer, ByVal strStkCode As String, strdgcBeritaAcaraAudit As String)
        lSTAdjustmentID = strSTAdjustmentID
        txtAdjustmentNo.Text = strAdjustmentNo
        lSTAdjustmentNo = strAdjustmentNo

        lSTID = strID
        dtpAdjustmentDate.Value = New Date(strAdjustmentDate.Substring(6, 4), strAdjustmentDate.Substring(3, 2), strAdjustmentDate.Substring(0, 2))
        txtStockCode.Text = strStockId
        lStockId = strStockId
        'lStockCode = strStkCode

        lblStatus.Text = strStatus
        txtRejectedReason.Text = strRejectedReason
        txtAdjQty.Text = strAdjQty
        lStrAdjQty = strAdjQty
        txtAdjValue.Text = strAdjValue
        lStrAdjValue = strAdjValue

        lModifiedOn = strModifiedOn
        txtAccountCode.Text = strCOAID
        'lCOAId = strCOAID
        'txtDiv.Text = strDIVID
        'lDIVId = strDIVID
        'txtYOP.Text = strYopID
        'lYopId = strYopID
        'txtSubBlock.Text = strBlockID
        'lBlockID = strBlockID
        txtT0.Text = strT0
        lT0Id = strT0
        'txtT1.Text = strT1
        'lT1Id = strT1
        'txtT2.Text = strT2
        'lT2Id = strT2
        'txtT3.Text = strT3
        'lT3Id = strT3
        'txtT4.Text = strT4
        'lT4Id = strT4
        txtRemarks.Text = strRemarks
        txtBeritaAcaraAudit.Text = strdgcBeritaAcaraAudit
        remarksVal = strRemarks
        EditAdjustViewApprovalMode(lSTAdjustmentNo)

    End Sub
    Private Function IsCheckValidation()
        If txtAdjustmentNo.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg13")
            'MessageBox.Show(" Please check Adjustment No", " Adjustment Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        'If dtpAdjustmentDate.Value.Month.ToString() <> Format(System.DateTime.Today.Month).ToString() Then
        '    MessageBox.Show(" Please Select Adjustment in Current Month", " IPRDate not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        If txtRemarks.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg14")
            'MessageBox.Show(" Please enter Remarks", " Remarks not entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRemarks.Focus()
            Return False
        End If
        'If txtStockCode.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please enter Stock Code", " StockCode not entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtStockCode.Focus()
        '    Return False
        'End If
        If txtAdjValue.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg15")
            'MessageBox.Show(" Please enter Adjustment Value", "Adjustment Value not Entered ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAdjValue.Focus()
            Return False
        End If
        'If txtAccountCode.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please enter Account Code", " Account Code Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtAccountCode.Focus()
        '    Return False
        'End If
        'If txtSubBlock.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please enter Sub Block", " Sub Block not Entered ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtSubBlock.Focus()
        '    Return False
        'End If
        If txtAdjQty.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg16")
            'MessageBox.Show(" Please enter Adjustment Quantity", " Adjustment Quantity not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAdjQty.Focus()
            Return False
        End If
        'If txtDiv.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please enter Division", " Division not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtDiv.Focus()
        '    Return False
        'End If
        'If txtYOP.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please enter YOP", " YOP not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtYOP.Focus()
        '    Return False
        'End If
        'If txtT0.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please Select T0 Value from the TLookUp", " T0Value Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtT0.Focus()
        '    Return False
        'End If
        'If txtT1.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please Select T1 Value from the TLookUp", " T1Value Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtT1.Focus()
        '    Return False
        'End If
        'If txtT2.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please Select T2 Value from the TLookUp", " T2Value Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtT2.Focus()
        '    Return False
        'End If
        'If txtT3.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please Select T3 Value from the TLookUp", " T3Value Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtT3.Focus()
        '    Return False
        'End If
        'If txtT4.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please Select T4 Value from the TLookUp", " T4Value Not Entered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtT4.Focus()
        '    Return False
        'End If

        Return True
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'Dim objStkAdjustPPT As New StockAdjustmentPPT
        'Dim objStkAdjustBOL As New StockAdjustmentBOL

        ' If Not IsCheckValidation() Then Exit Sub
        Add_Clicked()

        'GlobalPPT.IsRetainFocus = True

    End Sub
    Private Sub Add_Clicked()
        If Me.txtT0.Text = "" Then
            txtT0.Text = Helper.T0Default(0)
            lblT0Name.Text = Helper.T0Default(1)
        End If
        If btnAddFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (checkValues() = False) Then
                Exit Sub
            Else
                'Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))
                SaveAdjustmentDetail()
                lblStatus.Text = "OPEN"
                clear()
            End If
        ElseIf btnAddFlag = False Then
            If (checkValues() = False) Then
                Exit Sub
            Else
                UpdateAdjustDetails()
                lblStatus.Text = "OPEN"
                clear()
            End If
        End If
    End Sub
    Private Function checkValues() As Boolean

        Dim objBOL As New GlobalBOL
        Dim RequiredField As String
        If (txtAdjQty.Text.Trim = "") Then
            DisplayInfoMessage("Msg17")
            'MessageBox.Show("Adjustment Qty must be entered  ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdjQty.Focus()
            Return False
        End If
        If (txtAdjQty.Text.Trim <> "" And rdbtnDecrease.Checked = True And lblAvailableDesc.Text <= 0) Then
            DisplayInfoMessage("Msg49")
            'MessageBox.Show("Available Qty must be greater than zero", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdjQty.Focus()
            Return False
        End If

        If txtAdjValue.Text.Trim = "" Then
            DisplayInfoMessage("Msg18")
            'MessageBox.Show("Adjustment Value must be entered  ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdjValue.Focus()
            Return False
        End If
        'If (txtAdjValue.Text = "") Then
        '    MessageBox.Show("Adjustment Value not Selected", "Please select Adjustment Value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtAdjValue.Focus()
        '    Return False
        'End If
        If (txtStockCode.Text.Trim = "") Then
            DisplayInfoMessage("Msg19")
            'MessageBox.Show("Stock Code not Selected", "Please select Stock Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCode.Focus()
            Return False
        End If

        If (txtT0.Text.Trim = "") Then
            DisplayInfoMessage("Msg20")
            'MessageBox.Show("T0 is Empty", "Please give T0 value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtT0.Focus()
            Return False
        End If

        If (txtAccountCode.Text.Trim = "") Then
            DisplayInfoMessage("Msg21")
            'MessageBox.Show("Account Code is Empty", "Please give Account Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtT0.Focus()
            Return False
        End If

        Dim AccountCodeLength As Integer = txtAccountCode.Text.Replace("-", "").Trim.ToString.Length
        If txtAccountCode.Text.Trim <> "" And AccountCodeLength <> 13 Then
            DisplayInfoMessage("Msg42")
            'MessageBox.Show("Please enter 13 digit Account code")
            txtAccountCode.Focus()
            Exit Function
        End If

        If txtAccountCode.Text <> String.Empty Then
            RequiredField = String.Empty

            If objBOL.IsSetMandatoryInCOA(strStkAdjustAccountID, "AccountControl", "STORE", RequiredField) Then
                If RequiredField <> String.Empty Then
                    DisplayInfoMessage("Msg22")
                    MessageBox.Show(rm.GetString("Msg22") & RequiredField)
                    'MessageBox.Show("This Account Code is allowed only for " & RequiredField)
                    Return False
                End If
            End If
        End If

        If (txtRemarks.Text.Trim = "") Then
            DisplayInfoMessage("Msg23")
            'MessageBox.Show("Remarks is Empty", "Please Enter Remarks", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRemarks.Focus()
            Return False
        End If

        Return True

    End Function

    

    Private Sub AddAdjustment()
        Me.tbStockAdjustment.SelectedTab = tbpgAdd
        toGetAdjustmentNo()
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        AddAdjustment()
        btnAddFlag = True
    End Sub
    Private Sub DeleteAdjustmentVIew()
        Me.cmsAdjust.Visible = False

        Dim objAdjustmentPPT As New StockAdjustmentPPT
        Dim objAdjustmentBOL As New StockAdjustmentBOL
        Dim dt As New DataTable
        If dgvAdjustmentView.Rows.Count > 0 Then
            If dgvAdjustmentView.SelectedRows(0).Cells("gvStatus").Value.ToString() = "OPEN" Or dgvAdjustmentView.SelectedRows(0).Cells("gvStatus").Value.ToString() = "REJECTED" Then
                If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    objAdjustmentPPT.AdjustmentNo = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentNo").Value.ToString()
                    'With objAdjustmentPPT
                    '    .STAdjustmentID = Me.lSTAdjustmentID
                    'End With
                    objAdjustmentBOL.Delete_AdjustDetail(objAdjustmentPPT)
                    GridAdjustmentViewBind()
                Else
                    Exit Sub
                    'DisplayInfoMessage("Msg25")
                    'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                DisplayInfoMessage("Msg26")
                'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Else
            DisplayInfoMessage("Msg27")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteAdjustmentVIew()
    End Sub
    Private Sub btnAdjustSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjustSearch.Click
        GridAdjustmentViewBind()
    End Sub

    Private Sub dgAdjustment_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        EditViewGridRecord()
    End Sub
    Private Sub EditAdjustView()
        Me.cmsAdjust.Visible = False
        Dim objStkAdjustPPT As New StockAdjustmentPPT
        Dim objStkAdjustBOL As New StockAdjustmentBOL
        
        If dgvAdjustmentView.Rows.Count > 0 Then
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpAdjustmentDate)
            FormatDateTimePicker(dtpAdjustmentDate)
            Me.txtAdjustmentNo.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentNo").Value
            objStkAdjustPPT.AdjustmentNo = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentNo").Value
            Dim str As String = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentDate").Value

            Me.dtpAdjustmentDate.Value = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            'Me.dtpAdjustmentDate.Value = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentDate").Value
            Me.txtRemarks.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvRemarks").Value.ToString()
            Me.lblStatus.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvStatus").Value.ToString()
            'Me.lblRejectedReasonValue.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvRejectedReason").Value.ToString()

            If dgvAdjustmentView.SelectedRows(0).Cells("gvStatus").Value <> String.Empty Then
                If dgvAdjustmentView.SelectedRows(0).Cells("gvStatus").Value.ToString().ToUpper = "REJECTED" Then
                    lblRejectedReasonValue.Visible = True
                    lblRejectedReason1.Visible = True
                    lblRejReasonColon.Visible = True
                    lblRejectedReasonValue.Text = dgvAdjustmentView.SelectedRows(0).Cells("gvRejectedReason").Value
                Else
                    lblRejectedReasonValue.Visible = False
                    lblRejectedReason1.Visible = False
                    lblRejReasonColon.Visible = False
                End If
            End If

            'Me.btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            ' Me.lSTAdjustmentID = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvSTAdjustmentID").Value.ToString()
            dtpAdjustmentDate.Enabled = False
            ' txtAdjustNo.ReadOnly = True
          
            dtAdjustAdd = objStkAdjustBOL.GetAdjustDetailsInfo(objStkAdjustPPT)
            Me.dgvAdjustDetails.AutoGenerateColumns = False
            Me.dgvAdjustDetails.DataSource = dtAdjustAdd

            With objStkAdjustPPT
                lSTAdjustmentID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STASTAdjustmentID").Value.ToString()
                .STAdjustmentID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STASTAdjustmentID").Value.ToString()
                .T0analysisID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STAT0Id").Value.ToString()
                .T1analysisID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STAT1Id").Value.ToString()
                .T2analysisID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STAT2Id").Value.ToString()
                .T3analysisID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STAT3Id").Value.ToString()
                .T4analysisID = Me.dgvAdjustDetails.SelectedRows(0).Cells("STAT4Id").Value.ToString()
            End With

            'Me.txtAdjustmentNo.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentNo").Value.ToString()
            'Dim strDate As String = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvAdjustmentDate").Value.ToString()
            ''Me.dtpAdjustmentDate.Text = New Date(strDate.Substring(6, 4), strDate.Substring(3, 2), strDate.Substring(0, 2))
            'Me.lblStatus.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvStatus").Value.ToString()
            'Me.txtRemarks.Text = Me.dgvAdjustmentView.SelectedRows(0).Cells("gvRemarks").Value.ToString()
            If FlagInc = True Then
                rdbtnIncrease.Checked = True
            Else
                rdbtnDecrease.Checked = True
            End If

            Me.tbStockAdjustment.SelectedTab = tbpgAdd
        Else
            DisplayInfoMessage("Msg28")
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub UpdateAdjustView()
        'If dgvAdjustmentView.SelectedRows(0).Cells("gvstatus").Value = "MANAGER APPROVED" Then
        If dgvAdjustmentView.SelectedRows(0).Cells("gvstatus").Value <> "OPEN" And dgvAdjustmentView.SelectedRows(0).Cells("gvstatus").Value <> "REJECTED" Then
            EditAdjustView()
            ' btnSaveAll.Text = "Update All"
            ' btnAdd.Text = "Update"
            btnSaveAll.Enabled = False
            btnResetAll.Enabled = True
            txtAdjQty.Enabled = False
            txtAdjValue.Enabled = False
            txtDiv.Enabled = False
            txtYOP.Enabled = False
            txtAccountCode.Enabled = False
            txtStockCode.Enabled = False
            txtRemarks.Enabled = False

            txtT0.Enabled = False
            txtT1.Enabled = False
            txtT2.Enabled = False
            txtT3.Enabled = False
            txtT4.Enabled = False
            btnSearchStockCode.Enabled = False
            btnSearchAcCode.Enabled = False
            btnSearchT0.Enabled = False
            btnSearchT1.Enabled = False
            btnSearchT2.Enabled = False
            btnSearchT3.Enabled = False
            btnSearchT4.Enabled = False
            btnAdd.Enabled = False
            'ClearAll()

            'dgvAdjustDetails.Enabled = False

        Else
            EditAdjustView()
            dtpAdjustmentDate.Enabled = False
            ' txtRemarks.Enabled = False
            'lblStatus.Enabled = False

            txtT0.Enabled = True
            txtT1.Enabled = True
            txtT2.Enabled = True
            txtT3.Enabled = True
            txtT4.Enabled = True
            'ClearAll()
        End If
    End Sub
    Private Sub dgAdjustment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
    End Sub
    Private Sub dgAdjustment_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvAdjustmentView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvAdjustmentView.ClearSelection()
                    Me.dgvAdjustmentView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvAdjustmentView_CellContextMenuStripNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvAdjustmentView.CellContextMenuStripNeeded

    End Sub
    Private Sub dgvAdjustmentView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdjustmentView.CellDoubleClick
        EditViewGridRecord()
    End Sub
    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvAdjustmentView.RowCount > 0 Then
                    UpdateAdjustView()
                End If
            End If
        End If
    End Sub
    Private Sub dgvAdjustmentView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAdjustmentView.KeyDown
        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
    End Sub
    Private Sub dgvAdjustmentView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvAdjustmentView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvAdjustmentView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvAdjustmentView.ClearSelection()
                    Me.dgvAdjustmentView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub tbStockAdjustment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbStockAdjustment.Click

        If tbStockAdjustment.SelectedTab Is tbStockAdjustment.TabPages("tbSAView") Then
            chkAdjustDate.Focus()
            If (dgvAdjustDetails.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And btnSaveAll.Enabled = True) Then
                If MsgBox(rm.GetString("Msg46"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    GlobalPPT.IsRetainFocus = False
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ResetAll()
                    ShowViewTab()
                Else
                    tbStockAdjustment.SelectedTab = tbpgAdd
                End If
            Else
                ResetAll()
                ShowViewTab()
            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        ElseIf tbStockAdjustment.SelectedTab Is tbStockAdjustment.TabPages("tbpgAdd") Then

            If tbStockAdjustment.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgvAdjustDetails.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg46"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ResetAll()
                            dtpAdjustmentDate.Focus()
                        Else
                            Exit Sub
                        End If
                    Else
                        ResetAll()
                    End If
                End If
            Else
                Exit Sub '--if approval screen--'
            End If
        End If
        'GridAdjustmentViewBind()
        'BindDgvAdjustmentDetails()

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub ShowViewTab()

        GridAdjustmentViewBind()

    End Sub

    'Private Sub txtAdjQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdjQty.KeyDown
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

    '                    If txtBox.Text.Trim.Contains("") Then
    '                        isDecimal = False
    '                        Return
    '                    End If

    '                    isDecimal = True
    '                    Return
    '                Case Else

    '                    If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then

    '                        'If we insert a number between two numbers
    '                        text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
    '                    End If

    '                    If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then

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
    '    If (e.KeyCode = Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub
    'Private Sub txtAdjQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdjQty.KeyPress
    '    If isDecimal = False Then
    '        ' Stop the character from being entered into the control since it is non-numerical.
    '        e.Handled = True
    '    Else
    '        e.Handled = False

    '    End If
    '    'If Char.IsDigit(e.KeyChar) Then Exit Sub
    '    'If Char.IsControl(e.KeyChar) Then Exit Sub

    '    'If e.KeyChar = "." Then
    '    '    Dim txt As TextBox = CType(sender, TextBox)
    '    '    If txt.Text.IndexOf(".") < 0 Then
    '    '        e.Handled = False
    '    '    Else
    '    '        e.Handled = True
    '    '    End If
    '    'Else
    '    '    e.Handled = True
    '    'End If
    'End Sub

    'Private Sub txtAdjValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdjValue.KeyPress
    '    'If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
    '    '    e.Handled = True
    '    '    MsgBox("Please enter Adjustment Value ")
    '    'End If
    '    If isDecimal = False Then
    '        ' Stop the character from being entered into the control since it is non-numerical.
    '        e.Handled = True
    '    Else
    '        e.Handled = False

    '    End If

    '    'If Char.IsDigit(e.KeyChar) Then Exit Sub
    '    'If Char.IsControl(e.KeyChar) Then Exit Sub

    '    'If e.KeyChar = "." Then
    '    '    Dim txt As TextBox = CType(sender, TextBox)
    '    '    If txt.Text.IndexOf(".") < 0 Then
    '    '        e.Handled = False
    '    '    Else
    '    '        e.Handled = True
    '    '    End If
    '    'Else
    '    '    e.Handled = True
    '    'End If
    'End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        ConfirmApproval()
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.SelectedItem = "REJECTED" Then
            lblRejectedReason.Visible = True
            txtRejectedReason.Visible = True
            'lblColon15.Visible = True
        Else
            lblRejectedReason.Visible = False
            txtRejectedReason.Visible = False
            'lblColon15.Visible = False
        End If
    End Sub
    Private Function IsValidSaveAll() As Boolean

        'If btnSaveAll.Text = "Save All" Or btnSaveAll.Text = "Simpan" Then
        If dgvAdjustDetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg29")
            'MessageBox.Show(" Please Add Stock ", "Stock  Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStockCode.Focus()
            Return False
        End If
        'End If
        If (txtRemarks.Text.Trim = "") Then
            DisplayInfoMessage("Msg30")
            'MessageBox.Show("Remarks is Empty", "Please Enter Remarks", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRemarks.Focus()
            Return False
        End If
        'If btnSaveAll.Text = "Update All" Then ' in and condtition add indonesia word for update all and validate
        If dgvAdjustDetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg31")
            'MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtStockCode.Focus()
            Return False
        End If
        'End If

        Return True
    End Function

    Private Sub SaveAll()

        Dim rowaffected As Integer = 0

        If IsValidSaveAll() = False Then
            Exit Sub
        End If

        Dim objStkAdjustPPT As New StockAdjustmentPPT
        Dim intResult As Integer = 0


        Dim objStkAdjustBOL As New StockAdjustmentBOL

        Dim DataGridViewRow As DataGridViewRow

        If lSTAdjustmentID = String.Empty Then
            'If Me.btnSaveAll.Text.Trim() = "Save All" Then
            'If IsValidSaveAll() = False Then
            '    Exit Sub
            'End If
            Dim StrAdjustDate As String
            Dim dsDetails As New DataSet
            For Each DataGridViewRow In dgvAdjustDetails.Rows

                With objStkAdjustPPT

                    objStkAdjustPPT.AdjustmentNo = txtAdjustmentNo.Text.Trim()
                    objStkAdjustPPT.STAdjustmentID = lSTAdjustmentID
                    objStkAdjustPPT.stockID = DataGridViewRow.Cells("STAStockID").Value
                    StrAdjustDate = DataGridViewRow.Cells("STAAdjustmentDate").Value.ToString
                    'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                    objStkAdjustPPT.AdjustmentDate = StrAdjustDate
                    objStkAdjustPPT.stockDescription = lblDescription.Text
                    If Not DataGridViewRow.Cells("STACOAID").Value Is DBNull.Value Then
                        objStkAdjustPPT.COAID = DataGridViewRow.Cells("STACOAID").Value
                    End If
                    'If Not DataGridViewRow.Cells("STAYOPID").Value Is DBNull.Value Then
                    '    objStkAdjustPPT.YopID = DataGridViewRow.Cells("STAYOPID").Value
                    'End If
                    'If Not DataGridViewRow.Cells("STADIVID").Value Is DBNull.Value Then
                    '    objStkAdjustPPT.DivID = DataGridViewRow.Cells("STADIVID").Value
                    'End If
                    'If Not DataGridViewRow.Cells("STABLOCKID").Value Is DBNull.Value Then
                    '    objStkAdjustPPT.BlockID = DataGridViewRow.Cells("STABLOCKID").Value
                    'End If

                    'If decAdjQty <> 0 Then
                    '    objStkAdjustPPT.AdjQty = decAdjQty
                    'End If
                    ''objStkAdjustPPT.AdjQty = decAdjQty
                    'If txtAdjValue.Text <> String.Empty Then
                    '    objStkAdjustPPT.AdjValue = CDbl(txtAdjValue.Text)
                    'End If
                    If Not DataGridViewRow.Cells("STAAdjQty").Value Is DBNull.Value Then
                        decAdjQty = DataGridViewRow.Cells("STAAdjQty").Value
                    End If
                    If decAdjQty <> 0 Then
                        .AdjQty = decAdjQty
                        If DataGridViewRow.Cells("STAAdjustVal").Value.ToString <> String.Empty Then

                            .AdjValue = DataGridViewRow.Cells("STAAdjustVal").Value.ToString


                        End If
                    Else
                        .AdjQty = Nothing
                    End If

                    .BeritaAcaraAudit = txtBeritaAcaraAudit.Text.Trim()
                    objStkAdjustPPT.Remarks = txtRemarks.Text.Trim()
                    objStkAdjustPPT.Status = lblStatus.Text
                    If Not DataGridViewRow.Cells("STAT0Id").Value Is DBNull.Value Then
                        .T0analysisID = DataGridViewRow.Cells("STAT0Id").Value
                    End If
                    If Not DataGridViewRow.Cells("STAT1Id").Value Is DBNull.Value Then
                        .T1analysisID = DataGridViewRow.Cells("STAT1Id").Value
                    End If
                    If Not DataGridViewRow.Cells("STAT2Id").Value Is DBNull.Value Then
                        .T2analysisID = DataGridViewRow.Cells("STAT2Id").Value
                    End If
                    If Not DataGridViewRow.Cells("STAT3Id").Value Is DBNull.Value Then
                        .T3analysisID = DataGridViewRow.Cells("STAT3Id").Value
                    End If
                    If Not DataGridViewRow.Cells("STAT4Id").Value Is DBNull.Value Then
                        .T4analysisID = DataGridViewRow.Cells("STAT4Id").Value
                    End If

                End With

                Dim ds As New DataSet

                'If (checkValues() = False) Then
                '    Exit Sub
                'Else

                If lSTAdjustmentID = String.Empty Then
                    'If btnSaveAll.Text.Trim() = "Save All" Then
                    ds = StockAdjustmentBOL.saveStockAdjustment(objStkAdjustPPT)
                    'dgvLPODetails.DataSource = ds.Tables(0)
                    GridAdjustmentViewBind()
                ElseIf lSTAdjustmentID <> String.Empty Then
                    'DeleteMultiEntryRecords()
                    'ElseIf btnSaveAll.Text.Trim() = "Update All" Then
                    StockAdjustmentBOL.Update_Adjust(objStkAdjustPPT)

                End If
                'End If

                ' dsDetails = StockAdjustmentBOL.SaveSTAdjustDetails(objStkAdjust)
            Next
            DisplayInfoMessage("Msg32")
            'MsgBox("Data Successfully Saved")
            'btnSaveAll.Text = "Save All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Save All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Simpan Semua"
            End If

            LocalPurchaseOrderBOL.ClearGridView(dgvAdjustDetails)

            ClearAll()
            EnableFieldsOnResetAll()
            lblStatus.Text = "OPEN"
            'btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

        ElseIf lSTAdjustmentID <> String.Empty Then
            'ElseIf btnSaveAll.Text = "Update All" Then
            DeleteMultiEntryRecords()
            If IsValidSaveAll() = False Then
                Exit Sub
            End If

            Dim dsDetails As New DataSet
            Dim strAdjustDate As String

            For Each DataGridViewRow In dgvAdjustDetails.Rows
                With objStkAdjustPPT

                    .STAdjustmentID = DataGridViewRow.Cells("STASTAdjustmentID").Value.ToString()
                    If Not DataGridViewRow.Cells("STACOAID").Value.ToString Is DBNull.Value Then
                        .COAID = DataGridViewRow.Cells("STACOAID").Value.ToString
                    End If
                    If Not DataGridViewRow.Cells("STAYOPID").Value.ToString Is DBNull.Value Then
                        .YopID = DataGridViewRow.Cells("STAYOPID").Value.ToString
                    End If
                    If Not DataGridViewRow.Cells("STADIVID").Value.ToString Is DBNull.Value Then
                        .DivID = DataGridViewRow.Cells("STADIVID").Value.ToString
                    End If

                    .AdjustmentNo = txtAdjustmentNo.Text.Trim()
                    '.STAdjustmentID = lSTAdjustmentID
                    .stockID = DataGridViewRow.Cells("STAStockId").Value.ToString
                    .stockCode = DataGridViewRow.Cells("STAStockCode").Value.ToString
                    strAdjustDate = DataGridViewRow.Cells("STAAdjustmentDate").Value.ToString
                    ' strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                    .AdjustmentDate = strAdjustDate
                    .stockDescription = lblDescription.Text

                    .BlockID = DataGridViewRow.Cells("STABlockId").Value.ToString
                    If Not DataGridViewRow.Cells("STAAdjQty").Value Is DBNull.Value Then
                        decAdjQty = DataGridViewRow.Cells("STAAdjQty").Value
                    End If
                    If decAdjQty <> 0 Then
                        .AdjQty = decAdjQty
                        If DataGridViewRow.Cells("STAAdjustVal").Value.ToString <> String.Empty Then

                            .AdjValue = DataGridViewRow.Cells("STAAdjustVal").Value.ToString

                        End If
                    Else
                        .AdjQty = Nothing
                    End If


                    .Remarks = txtRemarks.Text.Trim()
                    lblStatus.Text = "OPEN"
                    .Status = lblStatus.Text
                    If Not IsDBNull(DataGridViewRow.Cells("STAT0Id").Value) Then
                        .T0analysisID = DataGridViewRow.Cells("STAT0Id").Value.ToString
                    Else
                        .T0analysisID = Nothing
                    End If
                    If Not IsDBNull(DataGridViewRow.Cells("STAT1Id").Value) Then
                        .T1analysisID = DataGridViewRow.Cells("STAT1Id").Value.ToString
                    Else
                        .T1analysisID = Nothing
                    End If
                    If Not IsDBNull(DataGridViewRow.Cells("STAT2Id").Value) Then
                        .T2analysisID = DataGridViewRow.Cells("STAT2Id").Value.ToString
                    Else
                        .T2analysisID = Nothing
                    End If
                    If Not IsDBNull(DataGridViewRow.Cells("STAT3Id").Value) Then
                        .T3analysisID = DataGridViewRow.Cells("STAT3Id").Value.ToString
                    Else
                        .T3analysisID = Nothing
                    End If
                    If Not IsDBNull(DataGridViewRow.Cells("STAT4Id").Value) Then
                        .T4analysisID = DataGridViewRow.Cells("STAT4Id").Value.ToString
                    Else
                        .T4analysisID = Nothing
                    End If
                End With

                If DataGridViewRow.Cells("STASTAdjustmentID").Value.ToString = String.Empty Then
                    'If DataGridViewRow.Cells("STAAdjustmentNo").Value.ToString = String.Empty Then
                    dsDetails = StockAdjustmentBOL.saveStockAdjustment(objStkAdjustPPT)
                Else

                    StockAdjustmentBOL.Update_Adjust(objStkAdjustPPT)
                End If
            Next
            DisplayInfoMessage("Msg33")
            'MsgBox("Data Successfully Updated")
            'btnSaveAll.Text = "Save All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Save All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Simpan Semua"
            End If

            lblStatus.Text = "OPEN"
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            GridAdjustmentViewBind()
        End If
        ClearAll()
        EnableFieldsOnResetAll()
        ' ClearAllControls()

        ClearGridView(dgvAdjustDetails)

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Private Sub BindDgvAdjustmentDetails()
        Dim objStkAdjustBOL As New StockAdjustmentBOL
        Dim objStkAdjustPPT As New StockAdjustmentPPT
        If dgvAdjustDetails.Rows.Count > 0 Then
            'Me.btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
            'Me.btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            Me.lSTAdjustmentID = dgvAdjustDetails.SelectedRows(0).Cells("STASTAdjustmentId").Value.ToString()
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAStockCode").Value.ToString() Is DBNull.Value Then
                Me.txtStockCode.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAStockCode").Value.ToString()
                lTempStockCode = dgvAdjustDetails.SelectedRows(0).Cells("STAStockCode").Value.ToString()
            End If

            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAStockDesc").Value.ToString() Is DBNull.Value Then
                Me.lblDescription.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAStockDesc").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAAccountCode").Value.ToString() Is DBNull.Value Then
                Me.txtAccountCode.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAAccountCode").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAUnit").Value.ToString() Is DBNull.Value Then
                Me.lblUnit.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAUnit").Value.ToString()
            End If
            'If Not dgvAdjustDetails.SelectedRows(0).Cells("STADiv").Value.ToString() Is DBNull.Value Then
            '    Me.txtDiv.Text = dgvAdjustDetails.SelectedRows(0).Cells("STADiv").Value.ToString()
            'End If
            ' Me.txtStockCode.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAStockCode").Value.ToString()
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAAdjustval").Value.ToString() Is DBNull.Value Then
                Me.txtAdjValue.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAAdjustval").Value.ToString()
            End If
            Dim tempstr As String = String.Empty
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAAdjQty").Value.ToString() Is DBNull.Value Then
                tempstr = dgvAdjustDetails.SelectedRows(0).Cells("STAAdjQty").Value.ToString()
            End If
            If tempstr = "" Then
                tempstr = Nothing
            ElseIf tempstr.Substring(0, 1) = "-" Then
                tempstr = String.Empty
                tempstr = dgvAdjustDetails.SelectedRows(0).Cells("STAAdjQty").Value.ToString()
                txtAdjQty.Text = -1 * CDbl(tempstr)
                If Not dgvAdjustDetails.SelectedRows(0).Cells("STAAdjustval").Value.ToString() Is DBNull.Value Then
                    Me.txtAdjValue.Text = -1 * CDbl(dgvAdjustDetails.SelectedRows(0).Cells("STAAdjustval").Value.ToString())
                End If
                FlagDec = True
            Else
                Me.txtAdjQty.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAAdjQty").Value.ToString()
                If Not dgvAdjustDetails.SelectedRows(0).Cells("STAAdjustval").Value.ToString() Is DBNull.Value Then
                    Me.txtAdjValue.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAAdjustval").Value.ToString()
                End If
                FlagDec = False
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STASubBlock").Value.ToString() Is DBNull.Value Then
                Me.txtSubBlock.Text = dgvAdjustDetails.SelectedRows(0).Cells("STASubBlock").Value.ToString()
            End If
            'If Not dgvAdjustDetails.SelectedRows(0).Cells("STAYOP").Value.ToString() Is DBNull.Value Then
            '    Me.txtYOP.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAYOP").Value.ToString()
            'End If

            Me.lblDescription.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAStockDesc").Value.ToString()
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAPartNo").Value Is String.Empty Then
                Me.lblPartNoDesc.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAPartNo").Value.ToString()
            End If

            Me.lblAvailableDesc.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAAvailableQty").Value.ToString()
            Me.lblStatus.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAStatus").Value.ToString()

            lblAccountDesc.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAAccountDesc").Value.ToString()
           
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STACOAId").Value.ToString() Is DBNull.Value Then
                objStkAdjustPPT.COAID = dgvAdjustDetails.SelectedRows(0).Cells("STACOAId").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STACOAId").Value.ToString() Is DBNull.Value Then
                'Me.strSIVAccountID = dgvAdjustDetails.SelectedRows(0).Cells("STACOAId").Value.ToString()
                Me.strStkAdjustAccountID = dgvAdjustDetails.SelectedRows(0).Cells("STACOAId").Value.ToString()
            End If

            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT0Id").Value.ToString() Is DBNull.Value Then
                objStkAdjustPPT.T0analysisID = dgvAdjustDetails.SelectedRows(0).Cells("STAT0Id").Value.ToString()
                lT0Id = dgvAdjustDetails.SelectedRows(0).Cells("STAT0Id").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT1Id").Value.ToString() Is DBNull.Value Then
                objStkAdjustPPT.T1analysisID = dgvAdjustDetails.SelectedRows(0).Cells("STAT1Id").Value.ToString()
                lT1Id = dgvAdjustDetails.SelectedRows(0).Cells("STAT1Id").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT2Id").Value.ToString() Is DBNull.Value Then
                objStkAdjustPPT.T2analysisID = dgvAdjustDetails.SelectedRows(0).Cells("STAT2Id").Value.ToString()
                lT2Id = dgvAdjustDetails.SelectedRows(0).Cells("STAT2Id").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT3Id").Value.ToString() Is DBNull.Value Then
                objStkAdjustPPT.T3analysisID = dgvAdjustDetails.SelectedRows(0).Cells("STAT3Id").Value.ToString()
                lT3Id = dgvAdjustDetails.SelectedRows(0).Cells("STAT3Id").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT4Id").Value.ToString() Is DBNull.Value Then
                objStkAdjustPPT.T4analysisID = dgvAdjustDetails.SelectedRows(0).Cells("STAT4Id").Value.ToString()
                lT4Id = dgvAdjustDetails.SelectedRows(0).Cells("STAT4Id").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT0").Value.ToString() Is DBNull.Value Then
                Me.txtT0.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT0").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT1").Value.ToString() Is DBNull.Value Then
                Me.txtT1.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT1").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT2").Value.ToString() Is DBNull.Value Then
                Me.txtT2.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT2").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT3").Value.ToString() Is DBNull.Value Then
                Me.txtT3.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT3").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT4").Value.ToString() Is DBNull.Value Then
                Me.txtT4.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT4").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT0Desc").Value.ToString() Is DBNull.Value Then
                Me.lblT0Name.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT0Desc").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT1Desc").Value.ToString() Is DBNull.Value Then
                Me.lblT1Name.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT1Desc").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT2Desc").Value.ToString() Is DBNull.Value Then
                Me.lblT2Name.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT2Desc").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT3Desc").Value.ToString() Is DBNull.Value Then
                Me.lblT3Name.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT3Desc").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAT4Desc").Value.ToString() Is DBNull.Value Then
                Me.lblT4Name.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAT4Desc").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAStockID").Value.ToString() Is DBNull.Value Then
                strAdjustStockID = dgvAdjustDetails.SelectedRows(0).Cells("STAStockID").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STACOAID").Value.ToString() Is DBNull.Value Then
                lCOAId = dgvAdjustDetails.SelectedRows(0).Cells("STACOAID").Value.ToString()
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAVarianceCOAID").Value Is DBNull.Value Then
                lVarianceID = dgvAdjustDetails.SelectedRows(0).Cells("STAVarianceCOAID").Value
            Else
                lVarianceID = Nothing
            End If
            If Not dgvAdjustDetails.SelectedRows(0).Cells("STAOldCOACode").Value.ToString() Is DBNull.Value Then
                lblOldCOACode.Text = dgvAdjustDetails.SelectedRows(0).Cells("STAOldCOACode").Value.ToString()
            End If
            AddFlag = False
            btnAddFlag = False

        End If
            If FlagDec = False Then
                rdbtnIncrease.Checked = True
            Else
                rdbtnDecrease.Checked = True
            End If

    End Sub
    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        'If grdname.Rows.Count <> 0 Then

        '    Dim objDataGridViewRow As New DataGridViewRow
        '    For Each objDataGridViewRow In grdname.Rows

        '        grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
        '    Next
        '    If grdname.Rows.Count = 1 Then
        '        grdname.Rows.RemoveAt(0)
        '    End If
        'End If

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
                'If grdname.Rows.Count - 1 Then
                '    grdname.Rows.RemoveAt(0)
                'End If
            Next
        End If

    End Sub

    Private Sub dgvAdjustDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdjustDetails.CellContentClick

    End Sub

    Private Sub dgvAdjustDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdjustDetails.CellDoubleClick
        BindDgvAdjustmentDetails()
    End Sub


    Private Sub btnSearchT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT0.Click
        'Dim frmTLookup As New Tlookup
        Dim frmTlookup As New Tlookup
        Tlookup.strTcodeDecide = "T0"

        frmTlookup.ShowDialog()
        If frmTlookup.strTId <> String.Empty Then
            Me.txtT0.Text = frmTlookup.strTValue
            Me.lblT0Name.Text = frmTlookup.strTDesc
            strAdjustT0Desc = frmTlookup.strTDesc
            strAdjustT0Val = frmTlookup.strTValue
            ' strSIVT0analysisID = frmTlookup.strTId
            lT0Id = frmTlookup.strTId
        End If

    End Sub

    Private Sub btnSearchT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT1.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T1"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT1.Text = frmTLookup.strTValue
            Me.lblT1Name.Text = frmTLookup.strTDesc
            strAdjustT1Desc = frmTLookup.strTDesc
            strAdjustT1Val = frmTLookup.strTValue
            'strSIVT1analysisID = frmTLookup.strTId
            lT1Id = frmTLookup.strTId
        End If

    End Sub

    Private Sub btnSearchT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT2.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T2"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT2.Text = frmTLookup.strTValue
            Me.lblT2Name.Text = frmTLookup.strTDesc
            strAdjustT2Desc = frmTLookup.strTDesc
            strAdjustT2Val = frmTLookup.strTValue
            'strSIVT2analysisID = frmTLookup.strTId
            lT2Id = frmTLookup.strTId
        End If
    End Sub
    Private Sub btnSearchT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT3.Click
        Dim frmTLookup As New Tlookup
        Tlookup.strTcodeDecide = "T3"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT3.Text = frmTLookup.strTValue
            Me.lblT3Name.Text = frmTLookup.strTDesc
            strAdjustT2Desc = frmTLookup.strTDesc
            strAdjustT3Val = frmTLookup.strTValue
            'strSIVT3analysisID = frmTLookup.strTId
            lT3Id = frmTLookup.strTId
        End If

    End Sub
    Private Sub btnSearchT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT4.Click
        Dim frmTLookup As New Tlookup
        'frmTLookup.strTcodeDecide = "T4"
        Tlookup.strTcodeDecide = "T4"
        frmTLookup.ShowDialog()
        If frmTLookup.strTId <> String.Empty Then
            Me.txtT4.Text = frmTLookup.strTValue
            Me.lblT4Name.Text = frmTLookup.strTDesc
            strAdjustT3Desc = frmTLookup.strTDesc
            strAdjustT4Val = frmTLookup.strTValue
            'strSIVT4analysisID = frmTLookup.strTId
            lT4Id = frmTLookup.strTId
        End If
    End Sub
    Private Sub rdbtnDecrease_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnDecrease.CheckedChanged

        If txtAdjQty.Text.Trim <> "" Then

            If txtAdjQty.Text.Trim = 0 Then
                DisplayInfoMessage("Msg34")
                'MessageBox.Show("Adjustment Qty should not be zero ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            Else

                If rdbtnDecrease.Checked = True Then
                    decAdjQty = -1 * Val(txtAdjQty.Text)
                Else
                    decAdjQty = CDbl(txtAdjQty.Text.ToString)
                End If

            End If

        End If

    End Sub

    Private Sub rdbtnIncrease_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnIncrease.CheckedChanged

        If txtAdjQty.Text.Trim <> "" Then

            If txtAdjQty.Text.Trim = 0 Then
                DisplayInfoMessage("Msg35")
                'MessageBox.Show("Adjustment Qty should not be zero should not be zero", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else

                If rdbtnDecrease.Checked = True Then
                    decAdjQty = -1 * Val(txtAdjQty.Text)
                Else
                    decAdjQty = CDbl(txtAdjQty.Text)
                End If

            End If

        End If

    End Sub

    Private Sub txtAdjQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjQty.Leave
        If Not IsNumeric(txtAdjQty.Text) Then
            MsgBox("Invalid Number entered, please enter a valid number")
            Me.txtAdjQty.Text = ""
        End If
        If txtAdjQty.Text <> "" Then
            If rdbtnDecrease.Checked = True Then
                decAdjQty = Format(-1 * CDbl(txtAdjQty.Text), "##0.000")
            Else
                decAdjQty = Format(CDbl(txtAdjQty.Text), "##0.000")
            End If
        End If
    End Sub
    Private Sub btnAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAcCode.Click

        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            strAdjustAccDes = frmAcctcodeLookup.strAcctDescp
            strStkAdjustAccountID = frmAcctcodeLookup.strAcctId
            'strSIVAccountID = frmAcctcodeLookup.strAcctId
            lblAccountDesc.Text = frmAcctcodeLookup.strAcctDescp
            strAdjustAccCode = frmAcctcodeLookup.strAcctcode
            strOldCOACode = frmAcctcodeLookup.strOldAccountCode
            lblOldCOACode.Text = frmAcctcodeLookup.strOldAccountCode
        End If
    End Sub

    Private Sub btnSubBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmSubBlock As New SubBlockLookup
        frmSubBlock.ShowDialog()
        If frmSubBlock.psBlockId <> String.Empty Then
            Me.txtSubBlock.Text = frmSubBlock.psBlockName
            strSIVBlockID = frmSubBlock.psBlockId
            ' Me.lblSubBlockName.Text = frmSubBlock.psBlockStatus
            Me.txtDiv.Text = frmSubBlock.psDIV
            strSIVDivID = frmSubBlock.psDIVID
            Me.lblDivName.Text = frmSubBlock.psDIVName
            Me.txtYOP.Text = frmSubBlock.psYop
            Me.lblYOPName.Text = frmSubBlock.psYopName
            strSIVYopID = frmSubBlock.psYopID
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim mdiparent As New MDIParent

        If (dgvAdjustDetails.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED")) And mdiparent.strMenuID = "M10" And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg48"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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
    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub
    Private Sub ClearAll()

        DeleteMultientry.Clear()

        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpAdjustmentDate)
        FormatDateTimePicker(dtpAdjustmentDate)
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        txtRemarks.Text = String.Empty
        txtStockCode.Text = String.Empty
        txtAdjQty.Text = String.Empty
        txtAdjValue.Text = String.Empty
        txtAccountCode.Text = String.Empty
        txtSubBlock.Text = String.Empty
        lblDescription.Text = String.Empty
        lblAccountDesc.Text = String.Empty
        lblAvailableDesc.Text = String.Empty
        lblPartNoDesc.Text = String.Empty
        'txtT0.Text = String.Empty
        txtT1.Text = String.Empty
        txtT2.Text = String.Empty
        txtT3.Text = String.Empty
        txtT4.Text = String.Empty
        'lblT0Name.Text = String.Empty
        lblT1Name.Text = String.Empty
        lblT2Name.Text = String.Empty
        lblT3Name.Text = String.Empty
        lblT4Name.Text = String.Empty
        txtDiv.Text = String.Empty
        txtYOP.Text = String.Empty
        lblDivName.Text = String.Empty
        lblYOPName.Text = String.Empty
        rdbtnDecrease.Checked = False
        rdbtnIncrease.Checked = False
        ''lblUnit.Text = "Unit"
        ''lblDescription.Text = "Description"
        ''lblAvailableDesc.Text = "Available Qty"
        ''lblPartNoDesc.Text = "Part No"
        ''lblOldCOACode.Text = "Old COA Code"
        lblUnit.Text = String.Empty
        lblDescription.Text = String.Empty
        lblAvailableDesc.Text = String.Empty
        lblPartNoDesc.Text = String.Empty
        lblOldCOACode.Text = String.Empty

        lblRejectedReasonValue.Visible = False
        lblRejectedReason1.Visible = False
        lblRejReasonColon.Visible = False
        txtBeritaAcaraAudit.Clear()

    End Sub
    Private Sub EnableFieldsOnResetAll()
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        txtRemarks.Enabled = True
        txtStockCode.ReadOnly = False
        txtT0.Enabled = True
        txtT1.Enabled = True
        txtT2.Enabled = True
        txtT3.Enabled = True
        txtT4.Enabled = True
        btnSearchAcCode.Enabled = True
        btnSearchSubBlock.Enabled = True
        btnSearchStockCode.Enabled = True
        btnSearchT0.Enabled = True
        btnSearchT1.Enabled = True
        btnSearchT2.Enabled = True
        btnSearchT3.Enabled = True
        btnSearchT4.Enabled = True
        btnAdd.Enabled = True
        txtStockCode.Enabled = True
        txtAdjQty.Enabled = True
        txtAdjValue.Enabled = True
        txtAccountCode.Enabled = True
        dtpAdjustmentDate.Format = DateTimePickerFormat.Custom
        dtpAdjustmentDate.Enabled = True
        toGetAdjustmentNo()
        lblStatus.Text = "OPEN"
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        rdbtnIncrease.Checked = False
        rdbtnDecrease.Checked = False
        Dim ds As New DataSet
        ClearGridView(dgvAdjustDetails)

    End Sub
    Private Sub ResetAll()

        ClearAll()

        lSTAdjustmentID = String.Empty
        txtRemarks.Text = String.Empty
        EnableFieldsOnResetAll()
        ClearGridView(dgvAdjustDetails)
        txtAdjustmentNo.Focus()
        btnAddFlag = True
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
    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click

        ResetAll()
        btnAddFlag = True

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub txtT0_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT0.Leave
        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T0Value = txtT0.Text.Trim()
            objSIV.TDecide = "T0"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg36")
                'MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                Me.lblT0Name.Text = String.Empty
                Me.txtT0.Text = String.Empty
                lT0Id = String.Empty
                txtT0.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT0Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                    strAdjustT0Desc = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT0.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                    strAdjustT0Val = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT0Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
            
        Else
            'Me.lblT0Name.Text = String.Empty
            'Me.txtT0.Text = String.Empty
            lT0Id = String.Empty
        End If
    End Sub

    Private Sub txtT1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT1.Leave
        If txtT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T1Value = txtT1.Text.Trim()
            objSIV.TDecide = "T1"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg37")
                'MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
                Me.lblT1Name.Text = String.Empty
                Me.txtT1.Text = String.Empty
                lT1Id = String.Empty
                txtT1.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT1Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                    strAdjustT1Desc = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT1.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                    strAdjustT1Val = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT1Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT1Name.Text = String.Empty
            Me.txtT1.Text = String.Empty
            lT1Id = String.Empty
        End If
    End Sub

    Private Sub txtT2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT2.Leave
        If txtT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T2Value = txtT2.Text.Trim()
            objSIV.TDecide = "T2"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg38")
                'MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
                Me.lblT2Name.Text = String.Empty
                Me.txtT2.Text = String.Empty
                lT2Id = String.Empty
                txtT2.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT2Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                    strAdjustT2Desc = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT2.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                    strAdjustT2Val = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT2Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT2Name.Text = String.Empty
            Me.txtT2.Text = String.Empty
            lT2Id = String.Empty
        End If
    End Sub

    Private Sub txtT3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT3.Leave
        If txtT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T3Value = txtT3.Text.Trim()
            objSIV.TDecide = "T3"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg39")
                'MessageBox.Show("Invalid T3 Value,Please Choose it from look up")
                Me.lblT3Name.Text = String.Empty
                Me.txtT3.Text = String.Empty
                lT3Id = String.Empty
                txtT3.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT3Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                    strAdjustT3Desc = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT3.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                    strAdjustT3Val = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT3Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT3Name.Text = String.Empty
            Me.txtT3.Text = String.Empty
            lT3Id = String.Empty
        End If
    End Sub

    Private Sub txtT4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        If txtT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T4Value = txtT4.Text.Trim()
            objSIV.TDecide = "T4"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg40")
                'MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
                Me.lblT4Name.Text = String.Empty
                Me.txtT4.Text = String.Empty
                lT4Id = String.Empty
                txtT4.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    Me.lblT4Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                    strAdjustT4Desc = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    Me.txtT4.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                    strAdjustT4Val = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT4Id = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            Me.lblT4Name.Text = String.Empty
            Me.txtT4.Text = String.Empty
            lT4Id = String.Empty
        End If
    End Sub

    Private Sub txtSubBlock_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtSubBlock.Text.Trim() <> String.Empty And txtSubBlock.Enabled = True Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.BlockName = txtSubBlock.Text.Trim()
            ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg41")
                'MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
                txtSubBlock.Text = String.Empty
                strBlockId = String.Empty
                ' lblSubBlockName.Text = String.Empty
                Me.txtDiv.Text = String.Empty
                strDivId = String.Empty
                Me.lblDivName.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                Me.lblYOPName.Text = String.Empty
                strYopId = String.Empty
                txtSubBlock.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
                    txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
                End If
                strBlockId = ds.Tables(0).Rows(0).Item("BlockID")

                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDiv.Text = ds.Tables(0).Rows(0).Item("Div")
                End If
                strDivId = ds.Tables(0).Rows(0).Item("DivID")
                If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
                    Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
                End If
                If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
                    Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
                End If
                If ds.Tables(0).Rows(0).Item("Name") <> String.Empty Then
                    Me.lblYOPName.Text = ds.Tables(0).Rows(0).Item("Name")
                End If
                strYopId = ds.Tables(0).Rows(0).Item("YOPID")


                'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
            End If
        ElseIf txtSubBlock.Text.Trim() = String.Empty And txtSubBlock.Enabled = True Then
            txtSubBlock.Text = String.Empty
            strBlockId = String.Empty

            Me.txtDiv.Text = String.Empty
            strDivId = String.Empty
            Me.lblDivName.Text = String.Empty
            Me.txtYOP.Text = String.Empty
            Me.lblYOPName.Text = String.Empty
            strYopId = String.Empty

            'Enable vhno,vhdetailscostcode and odo reading if sub block left empty
        End If
    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave
        If txtAccountCode.Text.Trim() <> String.Empty Then

            If txtAccountCode.Text.Trim.ToString.Length <> 13 Then
                DisplayInfoMessage("Msg42")
                'MessageBox.Show("Please enter 13 digit Account code")
                txtAccountCode.Focus()
                Exit Sub
            End If

            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.COACode = txtAccountCode.Text.Trim()
            ds = StoreIssueVoucherBOL.AcctlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg43")
                'MessageBox.Show("Invalid Account code,Please Choose it from look up")
                txtAccountCode.Text = String.Empty
                lblAccountDesc.Text = String.Empty
                strStkAdjustAccountID = String.Empty
                lblOldCOACode.Text = String.Empty
                strOldCOACode = String.Empty
                'strSIVAccountID = String.Empty
                txtAccountCode.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
                    txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                End If
                If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
                    lblAccountDesc.Text = ds.Tables(0).Rows(0).Item("COADescp")
                Else
                    lblAccountDesc.Text = String.Empty
                End If
                strStkAdjustAccountID = ds.Tables(0).Rows(0).Item("COAID")
                If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
                    lblOldCOACode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                    strOldCOACode = ds.Tables(0).Rows(0).Item("OldCOACode")
                Else
                    lblOldCOACode.Text = String.Empty
                    strOldCOACode = String.Empty
                End If

                'strSIVAccountID = ds.Tables(0).Rows(0).Item("COAID")
            End If
        Else
            txtAccountCode.Text = String.Empty
            lblAccountDesc.Text = String.Empty
            'strSIVAccountID = String.Empty
            strStkAdjustAccountID = String.Empty
            lblOldCOACode.Text = String.Empty
            strOldCOACode = String.Empty
        End If
    End Sub
    Private Sub txtStockCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave


        '    Dim dt As New DataTable
        '    Dim dtStock As New DataTable
        '    Dim objIPRPPT As New IPRPPT
        '    Dim objIPRBOL As New IPRBOL
        '    Dim objITNINPPT As New InternalTransferNoteINPPT
        '    Dim objITNINBOL As New InternalTransferNoteINBOL

        '    objITNINPPT.StockCode = Me.txtStockCode.Text
        '    dt = objITNINBOL.STITNInStockCodeGet(objITNINPPT)
        '    If dt.Rows.Count <> 0 Then
        '        Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString()
        '        Me.lblDescription.Text = dt.Rows(0).Item("StockDesc").ToString()
        '        lblAvailableDesc.Text = CDbl(dt.Rows(0).Item("AvailableQty"))
        '        Me.lblUnit.Text = dt.Rows(0).Item("UOM").ToString()
        '        Me.lblPartNoDesc.Text = dt.Rows(0).Item("PartNo").ToString
        '        Me.strAdjustStockID = dt.Rows(0).Item("StockId").ToString
        '        lblAvailableDesc.Visible = True
        '        Me.lblUnit.Visible = True
        '        Me.lblStockDescription.Visible = True
        '    Else
        '        MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtStockCode.Text = String.Empty
        '        txtStockCode.Focus()
        '    End If
        If txtStockCode.Text.Trim() <> String.Empty Then
            Dim dt As New DataTable
            Dim dtStock As New DataTable
            Dim objIPRPPT As New IPRPPT
            Dim objIPRBOL As New IPRBOL
            Dim objITNINPPT As New InternalTransferNoteINPPT
            Dim objITNINBOL As New InternalTransferNoteINBOL
            objITNINPPT.StockCode = Me.txtStockCode.Text
            dt = objITNINBOL.STITNInStockCodeGetNew(objITNINPPT, "YES")
            If dt.Rows.Count <> 0 Then
                Me.txtStockCode.Text = dt.Rows(0).Item("StockCode").ToString()
                Me.lblDescription.Text = dt.Rows(0).Item("StockDesc").ToString()
                lblAvailableDesc.Text = CDbl(dt.Rows(0).Item("AvailableQty"))
                Me.lblUnit.Text = dt.Rows(0).Item("UOM").ToString()
                Me.lblPartNoDesc.Text = dt.Rows(0).Item("PartNo").ToString
                Me.strAdjustStockID = dt.Rows(0).Item("StockId").ToString
                lblAvailableDesc.Visible = True
                Me.lblUnit.Visible = True
                Me.lblStockDescription.Visible = True
            Else
                DisplayInfoMessage("Msg44")
                'MessageBox.Show("Invalid stock code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtStockCode.Text = String.Empty
                txtStockCode.Focus()
            End If

        Else
            lblUnit.Text = String.Empty
            lblDescription.Text = String.Empty
            lblAvailableDesc.Text = String.Empty
            lblPartNoDesc.Text = String.Empty

        End If

    End Sub

    Private Sub chkAdjustDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustDate.CheckedChanged
        If chkAdjustDate.Checked = True Then
            dtpAdjustmentViewDate.Enabled = True
        Else
            dtpAdjustmentViewDate.Enabled = False
        End If

        ' edit by suraya 14092012
        dtpAdjustmentViewDate.Format = DateTimePickerFormat.Custom '
        dtpAdjustmentViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpAdjustmentViewDate)

    End Sub
    Private Sub dgvAdjustDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAdjustDetails.KeyDown
        If e.KeyCode = Keys.Return Then
            BindDgvAdjustmentDetails()
            e.Handled = True
        End If
    End Sub
    Private Sub tbStockAdjustment_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tbStockAdjustment.Selected
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpAdjustmentDate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpAdjustmentViewDate)
    End Sub

    Private Sub txtAdjValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdjValue.KeyDown
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

                        isDecimal = twoDecimalPlaces.IsMatch(text)

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

   
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim ObjRecordExist As New Object
        Dim ObjAdjustmentPPT As New StockAdjustmentPPT
        Dim ObjStockAdjustmentBOL As New StockAdjustmentBOL
        ObjRecordExist = ObjStockAdjustmentBOL.STARecordIsExist(ObjAdjustmentPPT)

        If ObjRecordExist = 0 Then
            'MsgBox("No Record(s) Available!")
            DisplayInfoMessage("Msg45")
        Else

            StrFrmName = "STA"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub

    Private Sub DelToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelToolStripMenuItem3.Click

        If dgvAdjustDetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvAdjustDetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            MsgBox("Delete function cant be done for single record ")
            Exit Sub
        Else

            If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                DeleteMultientrydatagrid()
            Else
                Exit Sub
            End If

        End If

    End Sub




    Private Sub DeleteMultientrydatagrid()



        lsSTAdjustmentID = dgvAdjustDetails.SelectedRows(0).Cells("STASTAdjustmentID").Value.ToString

        lDelete = 0
        If lsSTAdjustmentID <> "" Then

            lDelete = DeleteMultientry.Count

            DeleteMultientry.Insert(lDelete, lsSTAdjustmentID)


        End If
        Dim Dr As DataRow
        Dr = dtAdjustAdd.Rows.Item(dgvAdjustDetails.CurrentRow.Index)
        Dr.Delete()
        dtAdjustAdd.AcceptChanges()
        lsSTAdjustmentID = ""

    End Sub

    Private Sub DeleteMultiEntryRecords()

        Dim objSTAPPT As New StockAdjustmentPPT

        lDelete = DeleteMultientry.Count
        'objSIVPPT.STIssueID = psSIVSTIssueId
        While (lDelete > 0)

            With objSTAPPT

                .STAdjustmentID = DeleteMultientry(lDelete - 1)
            End With
            Dim IntIPRDetailDelete As New Integer
            IntIPRDetailDelete = StockAdjustmentBOL.STAdjustmentDelete_N(objSTAPPT)

            lDelete = lDelete - 1

        End While


    End Sub



    Private Sub StockAdjustmentFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'If dgvAdjustDetails.RowCount > 0 Then

        '    If MsgBox(rm.GetString("Msg47"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

        '    End If

        'End If


    End Sub

    Private Sub EditToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem2.Click
        BindDgvAdjustmentDetails()
    End Sub

   
    Private Sub StockAdjustmentFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim mdiparent As New MDIParent
        If (dgvAdjustDetails.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("Msg46"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False

            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M10"
                'mdiparent.lblMenuName.Text = "IPR"

            End If
        End If
    End Sub

End Class