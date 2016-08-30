Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Math

Public Class ReturnGoodsNoteFrm

    Public psRGNSTIssueID As String = String.Empty
    Public psRGNSTIssueDetailsID As String = String.Empty
    Public psSTReturnGoodsNoteID As String = String.Empty
    Public psSTReturnGoodsDetailsID As String = String.Empty
    Public psRGNSTockId As String = String.Empty
    Public psRGNSIVCOAID As String = String.Empty
    Public psRGNSIVCOACODE As String = String.Empty
    Public psRGNSIVCOADESCP As String = String.Empty
    Public psRGNStockCOAID As String = String.Empty
    Public psRGNVarianceCOAID As String = String.Empty

    Public psRGNT0IdValue As String = String.Empty
    Public psRGNT1IdValue As String = String.Empty
    Public psRGNT2IdValue As String = String.Empty
    Public psRGNT3IdValue As String = String.Empty
    Public psRGNT4IdValue As String = String.Empty
    Public psRGNBlockIdValue As String = String.Empty
    Public psRGNDivIdValue As String = String.Empty
    Public psRGNYOPIdValue As String = String.Empty
    Public psRGNStationIdValue As String = String.Empty
    Public psRGNVHIdValue As String = String.Empty
    Public psRGNVHDetailCostCodeIdValue As String = String.Empty
    Public psRGNODOReading As Integer

    Public dtAddFlag As Boolean = False
    Public btnAddFlag As Boolean = True
    Public bIsDetailsFromUpdateMode As Boolean = False
    Public UpdateModeCount As Integer = -1

    Public dgclSTRGNIDVal As String = String.Empty
    Public dgclSIVNOVal As String = String.Empty
    Public dgclRGNNoVal As String = String.Empty
    Public dgclRGNDateVal As Date
    Public dgclViewSTIssueIDVal As String = String.Empty
    Public dgclRemarksVal As String = String.Empty
    Public dgclStatusVal As String = String.Empty
    Public dgclRejectedStatusVal As String = String.Empty


    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim reDecimalPrice As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")
    Dim dtRGN As New DataTable("todgRGN")
    Dim columnRGNAdd As DataColumn
    Dim rowRGNAdd As DataRow
    Public Shared StrFrmName As String = String.Empty
    Shadows mdiparent As New MDIParent
    'Dim arlSTReturnGoodsDetailsIDDel As New ArrayList
    Dim bDelAllFlag As Boolean = False
    Dim psExistingStockCode As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReturnGoodsNoteFrm))
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReturnGoodsNoteFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub



    Private Sub ReturnGoodsNoteFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDate)

        If mdiparent.strMenuID = "M7" Then 'Load if ReturnGoodsNote Form
            cmbStatusSearch.Text = cmbStatusSearch.Items(1) 'For Default OPEN
            tbRGN.SelectedTab = tbpgView
            BindViewRGN()
            toGetRGNNo()
            FormatDatePicker(dtpRGNDate)
        End If
        If mdiparent.strMenuID = "M16" Then 'Load if ReturnGoodsNoteApproval Form
            Dim frmRGNApproval As New ReturnGoodsNoteApprovalFrm
            tbRGN.SelectedTab = tbpgRGN
            tbRGN.TabPages.Remove(tbpgView)
            DisableRGNFromApprovalMode()
            grpApproval.Visible = True
        End If
        'SetUICulture(GlobalPPT.strLang)

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        lblSIVT0Value.Text = Helper.T0Default(0)
    End Sub

    Private Sub DisableRGNFromApprovalMode()

        txtSIVNo.Enabled = False
        dtpRGNDate.Enabled = False
        txtRemarks.Enabled = False
        lblStatus.Enabled = True
        txtStockCode.Enabled = False
        lblUnit.Enabled = True
        lblPartNo.Enabled = True
        lblDescription.Enabled = True
        txtIssueQty.Enabled = True
        txtIssueValue.Enabled = True
        txtReturnedQty.Enabled = False
        txtReturnedValue.Enabled = False
        btnSaveAll.Enabled = False
        'Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M16" Then
            btnResetAll.Enabled = False
        Else
            btnResetAll.Enabled = True
        End If
        btnAdd.Enabled = False
        btnReset.Enabled = False
        btnSearchSIVNo.Enabled = False
        btnSearchStockCode.Enabled = False
        btnDeleteAll.Enabled = False
    End Sub

    Private Sub EnableRGNIFNotApprovalMode()

        txtSIVNo.Enabled = True
        dtpRGNDate.Enabled = True
        txtRemarks.Enabled = True
        lblStatus.Enabled = True
        txtStockCode.Enabled = False
        lblUnit.Enabled = True
        lblPartNo.Enabled = True
        lblDescription.Enabled = True
        txtIssueQty.Enabled = True
        txtIssueValue.Enabled = True
        txtReturnedQty.Enabled = True
        txtReturnedValue.Enabled = True
        btnSaveAll.Enabled = True
        btnResetAll.Enabled = True
        btnAdd.Enabled = True
        btnReset.Enabled = True
        btnSearchSIVNo.Enabled = True
        btnSearchStockCode.Enabled = True

    End Sub

    Public Sub BindDGRGNApprovalMode(ByVal dgclSTRGNID, ByVal dgclSIVNO, ByVal dgclRGNNo, ByVal dgclRGNDate, ByVal dgclViewSTIssueID, ByVal dgclRemarks, ByVal dgclStatus, ByVal dgclRejectedStatus)

        Dim objRGN As New ReturnGoodsNotePPT
        Dim ds As New DataSet

        dgclSTRGNIDVal = dgclSTRGNID
        dgclSIVNOVal = dgclSIVNO
        dgclRGNNoVal = dgclRGNNo
        dgclRGNDateVal = dgclRGNDate
        dgclViewSTIssueIDVal = dgclViewSTIssueID
        dgclRemarksVal = dgclRemarks
        dgclStatusVal = dgclStatus
        dgclRejectedStatusVal = dgclRejectedStatus

        objRGN.STReturnGoodsNoteID = dgclSTRGNID
        psSTReturnGoodsNoteID = objRGN.STReturnGoodsNoteID

        ds = ReturnGoodsNoteBOL.STRGNDetailsGet(objRGN)
        If ds.Tables(0).Rows.Count > 0 Then
            txtSIVNo.Text = dgclSIVNOVal
            txtRGNNo.Text = dgclRGNNoVal
            dtpRGNDate.Text = dgclRGNDateVal
            'FormatDatePicker()
            psRGNSTIssueID = dgclViewSTIssueID
            If dgclRemarks <> String.Empty Then
                txtRemarks.Text = dgclRemarksVal
            End If
            lblStatus.Text = dgclStatusVal
            If dgclRejectedStatusVal <> String.Empty Then
                txtRejectedReason.Text = dgclRejectedStatusVal
            End If
            'btnSaveAll.Text = "Update All"
            dtRGN = ds.Tables(0)
            dgRGN.AutoGenerateColumns = False
            dgRGN.DataSource = dtRGN
            'dgRGN.Columns("dgclIssueValue").Visible = False
            dtAddFlag = True
        End If

    End Sub

    Private Sub toGetRGNNo()

        Dim objRGNPPT As New ReturnGoodsNotePPT
        objRGNPPT.RGNNo = ReturnGoodsNoteBOL.GetRGNNo(objRGNPPT)
        Dim RgsNo As String = ReturnGoodsNoteBOL.GetRGSAutoNo()
        txtRGNNo.Text = RgsNo
        If objRGNPPT.RGNNo <> "" Then
            'txtRGNNo.Text = objRGNPPT.RGNNo
        Else
            DisplayInfoMessage("Msg01")
            'MessageBox.Show("No records for RGN in Store Configuration")
        End If

    End Sub


    Private Sub FormatDatePicker(ByVal dtpName As DateTimePicker)

        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReturnGoodsNoteFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tbRGN.TabPages("tbpgRGN").Text = rm.GetString("tbRGN.TabPages(tbpgRGN).Text")
            tbRGN.TabPages("tbpgView").Text = rm.GetString("tbRGN.TabPages(tbpgView).Text")


            'Add Tab Controls
            grpRGN.Text = rm.GetString("grpRGN.Text")
            grpRGNStockDetails.Text = rm.GetString("grpRGNStockDetails.Text")


            lblRGNNo.Text = rm.GetString("lblRGNNo.Text")
            lblSIVNo.Text = rm.GetString("llblSIVNO.Text")
            lblRGNDate.Text = rm.GetString("lblRGNDate.Text")
            lblRGNStatus.Text = rm.GetString("lblRGNStatus.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            lblRejectedReason.Text = rm.GetString("lblRejectedReason.Text")
            lblStockCode.Text = rm.GetString("lblStockCode.Text")
            lblUOM.Text = rm.GetString("lblUOM.Text")
            lblPart.Text = rm.GetString("lblPart.Text")
            lblStockDescription.Text = rm.GetString("lblStockDescription.Text")
            lblIssueQty.Text = rm.GetString("lblIssueQty.Text")
            lblIssueValue.Text = rm.GetString("lblIssueValue.Text")
            lblReturnedQty.Text = rm.GetString("lblReturnedQty.Text")
            lblReturnedValue.Text = rm.GetString("lblReturnedValue.Text")

            dgRGN.Columns("dgclStockCode").HeaderText = rm.GetString("dgRGN.Columns(dgclStockCode).HeaderText")
            dgRGN.Columns("dgclStockDesc").HeaderText = rm.GetString("dgRGN.Columns(dgclStockDesc).HeaderText")
            dgRGN.Columns("dgclUnit").HeaderText = rm.GetString("dgRGN.Columns(dgclUnit).HeaderText")
            dgRGN.Columns("dgclPartNo").HeaderText = rm.GetString("dgRGN.Columns(dgclPartNo).HeaderText")
            dgRGN.Columns("dgclIssueQty").HeaderText = rm.GetString("dgRGN.Columns(dgclIssueQty).HeaderText")
            dgRGN.Columns("dgclReturnQty").HeaderText = rm.GetString("dgRGN.Columns(dgclReturnQty).HeaderText")




            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnResetAll.Text = rm.GetString("btnResetAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnPrint.Text = rm.GetString("btnPrint.Text")

            'View Tab Controls
            PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText") 'lblSearchBy
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")
            chkViewRGNDate.Text = rm.GetString("chkViewRGNDate.Text")
            lblSIVNoSerach.Text = rm.GetString("lblSIVNoSerach.Text")
            lblRGNNoSerach.Text = rm.GetString("lblRGNNoSerach.Text")
            lblStatusSearch.Text = rm.GetString("lblStatusSearch.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")

            dgViewRGN.Columns("dgclSIVNO").HeaderText = rm.GetString("dgViewRGN.Columns(dgclSIVNO).HeaderText")
            dgViewRGN.Columns("dgclRGNDate").HeaderText = rm.GetString("dgViewRGN.Columns(dgclRGNDate).HeaderText")
            dgViewRGN.Columns("dgclRGNNo").HeaderText = rm.GetString("dgViewRGN.Columns(dgclRGNNo).HeaderText")
            dgViewRGN.Columns("dgclStatus").HeaderText = rm.GetString("dgViewRGN.Columns(dgclStatus).HeaderText")
            dgViewRGN.Columns("dgclRemarks").HeaderText = rm.GetString("dgViewRGN.Columns(dgclRemarks).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtSIVNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSIVNo.Leave

        If txtSIVNo.Text.Trim() <> String.Empty Then

            BindSIVNo()
            txtStockCode.Text = String.Empty
            ClearRGNStockDetails()
            btnAddFlag = True
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If

            StoreIssueVoucherBOL.ClearGridView(dgRGN)

        Else
            txtSIVNo.Text = String.Empty
        End If

    End Sub

    Private Sub BindSIVNo()

        Dim objRGNPPt As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        objRGNPPt.SIVNO = txtSIVNo.Text.Trim()
        ds = ReturnGoodsNoteBOL.RGNSIVGet(objRGNPPt, "YES")
        If ds.Tables(0).Rows.Count > 0 Then
            objRGNPPt.STIssueID = ds.Tables(0).Rows(0).Item("STIssueID")
            psRGNSTIssueID = ds.Tables(0).Rows(0).Item("STIssueID")
        Else
            DisplayInfoMessage("Msg02")
            'MessageBox.Show("Record not exists")
            ClearRGNStockDetails()
            txtSIVNo.Text = String.Empty
            txtSIVNo.Focus()
        End If

    End Sub

    Private Sub btnSearchSIVNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSIVNo.Click

        Me.Cursor = Cursors.WaitCursor
        Dim frmRGNSIVLookup As New RGNSIVLookup
        'frmRGNSIVLookup.ShowDialog()
        Dim result As DialogResult = frmRGNSIVLookup.ShowDialog()
        If frmRGNSIVLookup.DialogResult = Windows.Forms.DialogResult.OK Then

            txtSIVNo.Text = frmRGNSIVLookup.strSIVNo
            psRGNSTIssueID = frmRGNSIVLookup.strSTIssueID
            txtStockCode.Text = String.Empty
            ClearRGNStockDetails()
            btnAddFlag = True
            'btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If

            StoreIssueVoucherBOL.ClearGridView(dgRGN)

        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Public Sub ClearRGNHeader()

        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDate)
        txtSIVNo.Text = String.Empty
        psRGNSTIssueID = String.Empty
        toGetRGNNo()
        txtRemarks.Text = String.Empty
        txtRejectedReason.Text = String.Empty
        'lblStatus.Text = String.Empty
        lblStatus.Text = "OPEN"

        lblRejectedReason1.Visible = False
        lblRejectedReasonValue.Visible = False
        lblRejReasonColon.Visible = False

        txtSIVNo.Enabled = True
        dtpRGNDate.Enabled = True
        txtRemarks.Enabled = True
        lblStatus.Enabled = True
        btnSearchSIVNo.Enabled = True

        StoreIssueVoucherBOL.ClearGridView(dgRGN)

    End Sub

    Public Sub ClearRGNStockDetails()

        lblUnit.Text = String.Empty
        lblPartNo.Text = String.Empty
        lblDescription.Text = String.Empty
        txtIssueQty.Text = String.Empty
        txtIssueValue.Text = String.Empty
        txtReturnedQty.Text = String.Empty
        txtReturnedValue.Text = String.Empty
        psRGNSTockId = String.Empty

        'psRGNSTIssueID = String.Empty
        psRGNSTIssueDetailsID = String.Empty

        lblSIVT0Value.Text = String.Empty
        lblSIVT1Value.Text = String.Empty
        lblSIVT2Value.Text = String.Empty
        lblSIVT3Value.Text = String.Empty
        lblSIVT4Value.Text = String.Empty

        lblSIVStation.Text = String.Empty
        lblSIVBlock.Text = String.Empty
        lblSIVYOP.Text = String.Empty
        lblSIVDiv.Text = String.Empty
        lblSIVODOReading.Text = String.Empty
        lblSIVVHNo.Text = String.Empty
        lblSIVVHDetailCostCode.Text = String.Empty

        lblUnit.Enabled = True
        lblDescription.Enabled = True
        txtIssueQty.Enabled = True
        txtIssueValue.Enabled = True
        txtReturnedQty.Enabled = True
        txtReturnedValue.Enabled = True

    End Sub

    'Commented by Arul on 20-jul-2010 , as per Anand's Suggestion start

    'Private Sub txtStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave
    'Commented by Arul on 20-jul-2010 , as per Anand's Suggestion start
    '    If txtStockCode.Text.Trim() <> String.Empty Then

    '        Dim ds As New DataSet
    '        Dim objRGNPPT As New ReturnGoodsNotePPT
    '        objRGNPPT.STIssueID = psRGNSTIssueID
    '        objRGNPPT.StockCode = txtStockCode.Text.Trim()
    '        ds = ReturnGoodsNoteBOL.RGNStockDetailsGet(objRGNPPT)

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            txtStockCode.Text = ds.Tables(0).Rows(0).Item("StockCode")
    '            psRGNSTockId = ds.Tables(0).Rows(0).Item("StockId")
    '            If Not ds.Tables(0).Rows(0).Item("Unit") Is DBNull.Value Then
    '                lblUnit.Text = ds.Tables(0).Rows(0).Item("Unit")
    '            Else
    '                lblUnit.Text = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("PartNo") Is DBNull.Value Then
    '                lblPartNo.Text = ds.Tables(0).Rows(0).Item("PartNo")
    '            Else
    '                lblPartNo.Text = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("StockDesc") Is DBNull.Value Then
    '                lblDescription.Text = ds.Tables(0).Rows(0).Item("StockDesc")
    '            Else
    '                lblDescription.Text = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("IssueQty") Is DBNull.Value Then
    '                txtIssueQty.Text = ds.Tables(0).Rows(0).Item("IssueQty")
    '            Else
    '                txtIssueQty.Text = String.Empty
    '            End If

    '            If Not ds.Tables(0).Rows(0).Item("IssueValue") Is DBNull.Value Then
    '                txtIssueValue.Text = ds.Tables(0).Rows(0).Item("IssueValue")
    '            Else
    '                txtIssueValue.Text = String.Empty
    '            End If

    '            psRGNSTIssueDetailsID = ds.Tables(0).Rows(0).Item("STIssueDetailsID")
    '            psRGNSTIssueID = ds.Tables(0).Rows(0).Item("STIssueId")
    '            If Not ds.Tables(0).Rows(0).Item("SIVCOAID") Is DBNull.Value Then
    '                psRGNSIVCOAID = ds.Tables(0).Rows(0).Item("SIVCOAID")
    '            Else
    '                psRGNSIVCOAID = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("SIVCOACODE") Is DBNull.Value Then
    '                psRGNSIVCOACODE = ds.Tables(0).Rows(0).Item("SIVCOACODE")
    '            Else
    '                psRGNSIVCOACODE = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("SIVCOADESCP") Is DBNull.Value Then
    '                psRGNSIVCOADESCP = ds.Tables(0).Rows(0).Item("SIVCOADESCP")
    '            Else
    '                psRGNSIVCOADESCP = String.Empty
    '            End If

    '            If Not ds.Tables(0).Rows(0).Item("StockCOAID") Is DBNull.Value Then
    '                psRGNStockCOAID = ds.Tables(0).Rows(0).Item("StockCOAID")
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("VarianceCOAID") Is DBNull.Value Then
    '                psRGNVarianceCOAID = ds.Tables(0).Rows(0).Item("VarianceCOAID")
    '            End If

    '            '

    '            If Not ds.Tables(0).Rows(0).Item("T0") Is DBNull.Value Then
    '                lblSIVT0Value.Text = ds.Tables(0).Rows(0).Item("T0")
    '                psRGNT0IdValue = ds.Tables(0).Rows(0).Item("T0Id")
    '            Else
    '                lblSIVT0Value.Text = String.Empty
    '                psRGNT0IdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("T1") Is DBNull.Value Then
    '                lblSIVT1Value.Text = ds.Tables(0).Rows(0).Item("T1")
    '                psRGNT1IdValue = ds.Tables(0).Rows(0).Item("T1Id")
    '            Else
    '                lblSIVT1Value.Text = String.Empty
    '                psRGNT1IdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("T2") Is DBNull.Value Then
    '                lblSIVT2Value.Text = ds.Tables(0).Rows(0).Item("T2")
    '                psRGNT2IdValue = ds.Tables(0).Rows(0).Item("T2Id")
    '            Else
    '                lblSIVT2Value.Text = String.Empty
    '                psRGNT2IdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("T3") Is DBNull.Value Then
    '                lblSIVT3Value.Text = ds.Tables(0).Rows(0).Item("T3")
    '                psRGNT3IdValue = ds.Tables(0).Rows(0).Item("T3Id")
    '            Else
    '                lblSIVT3Value.Text = String.Empty
    '                psRGNT3IdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("T4") Is DBNull.Value Then
    '                lblSIVT4Value.Text = ds.Tables(0).Rows(0).Item("T4")
    '                psRGNT4IdValue = ds.Tables(0).Rows(0).Item("T4Id")
    '            Else
    '                lblSIVT4Value.Text = String.Empty
    '                psRGNT4IdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("Block") Is DBNull.Value Then
    '                lblSIVBlock.Text = ds.Tables(0).Rows(0).Item("Block")
    '                psRGNBlockIdValue = ds.Tables(0).Rows(0).Item("BlockId")
    '            Else
    '                lblSIVBlock.Text = String.Empty
    '                psRGNBlockIdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("Div") Is DBNull.Value Then
    '                lblSIVDiv.Text = ds.Tables(0).Rows(0).Item("Div")
    '                psRGNDivIdValue = ds.Tables(0).Rows(0).Item("DivId")
    '            Else
    '                lblSIVDiv.Text = String.Empty
    '                'psRGNDivIdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("YOP") Is DBNull.Value Then
    '                lblSIVYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
    '                psRGNYOPIdValue = ds.Tables(0).Rows(0).Item("YOPId")
    '            Else
    '                lblSIVYOP.Text = String.Empty
    '                psRGNYOPIdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("Station") Is DBNull.Value Then
    '                lblSIVStation.Text = ds.Tables(0).Rows(0).Item("Station")
    '                psRGNStationIdValue = ds.Tables(0).Rows(0).Item("StationId")
    '            Else
    '                lblSIVStation.Text = String.Empty
    '                psRGNStationIdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("VHNo") Is DBNull.Value Then
    '                lblSIVVHNo.Text = ds.Tables(0).Rows(0).Item("VHNo")
    '                psRGNVHIdValue = ds.Tables(0).Rows(0).Item("VHId")
    '            Else
    '                lblSIVVHNo.Text = String.Empty
    '                psRGNVHIdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("VHDetailCostCode") Is DBNull.Value Then
    '                lblSIVVHDetailCostCode.Text = ds.Tables(0).Rows(0).Item("VHDetailCostCode")
    '                psRGNVHDetailCostCodeIdValue = ds.Tables(0).Rows(0).Item("VHDetailCostCodeId")
    '            Else
    '                lblSIVVHDetailCostCode.Text = String.Empty
    '                psRGNVHDetailCostCodeIdValue = String.Empty
    '            End If
    '            If Not ds.Tables(0).Rows(0).Item("ODOReading") Is DBNull.Value Then
    '                lblSIVODOReading.Text = ds.Tables(0).Rows(0).Item("ODOReading")
    '            Else
    '                lblSIVODOReading.Text = String.Empty
    '            End If
    '            '
    '        Else
    '            DisplayInfoMessage("Msg03")
    '            'MessageBox.Show("Record Not Exists")
    '            ClearRGNStockDetails()
    '            txtStockCode.Text = String.Empty
    '            txtStockCode.Focus()
    '        End If

    '    Else
    '        ClearRGNStockDetails()
    '    End If

    'End Sub

    'Commented by Arul on 20-jul-2010 , as per Anand's Suggestion start

    Private Sub btnSearchStockCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchStockCode.Click

        Me.Cursor = Cursors.WaitCursor

        If txtSIVNo.Text <> String.Empty Then

            Dim frmRGNStockCodeLookup As New RGNStockCodeLookup
            frmRGNStockCodeLookup.BindGrid(psRGNSTIssueID)
            Dim result As DialogResult = frmRGNStockCodeLookup.ShowDialog()

            If frmRGNStockCodeLookup.DialogResult = Windows.Forms.DialogResult.OK Then

                txtStockCode.Text = frmRGNStockCodeLookup.psRGNStockCode
                psRGNSTockId = frmRGNStockCodeLookup.psRGNStockIdValue
                lblUnit.Text = frmRGNStockCodeLookup.psRGNStockUnit
                lblPartNo.Text = frmRGNStockCodeLookup.psRGNStockPartNo
                lblDescription.Text = frmRGNStockCodeLookup.psRGNStockDesc
                txtIssueQty.Text = frmRGNStockCodeLookup.psRGNStockIssuedQty
                txtIssueValue.Text = frmRGNStockCodeLookup.psRGNStockIssuedValue
                psRGNSTIssueID = frmRGNStockCodeLookup.psRGNSTIssueIdValue
                psRGNStockCOAID = frmRGNStockCodeLookup.psRGNStockCOAIDValue
                psRGNSIVCOAID = frmRGNStockCodeLookup.psRGNSIVCOAIDValue
                psRGNSIVCOACODE = frmRGNStockCodeLookup.psRGNSIVCOACODEValue
                psRGNSIVCOADESCP = frmRGNStockCodeLookup.psRGNSIVCOADESCPValue
                psRGNVarianceCOAID = frmRGNStockCodeLookup.psRGNVarianceCOAIDValue
                psRGNSTIssueDetailsID = frmRGNStockCodeLookup.psRGNSTIssueDetailsIDValue


                lblSIVT0Value.Text = frmRGNStockCodeLookup.psRGNT0Value
                lblSIVT1Value.Text = frmRGNStockCodeLookup.psRGNT1Value
                lblSIVT2Value.Text = frmRGNStockCodeLookup.psRGNT2Value
                lblSIVT3Value.Text = frmRGNStockCodeLookup.psRGNT3Value
                lblSIVT4Value.Text = frmRGNStockCodeLookup.psRGNT4Value
                lblSIVBlock.Text = frmRGNStockCodeLookup.psRGNBlockValue
                lblSIVDiv.Text = frmRGNStockCodeLookup.psRGNDivValue
                lblSIVYOP.Text = frmRGNStockCodeLookup.psRGNYOPValue
                lblSIVStation.Text = frmRGNStockCodeLookup.psRGNStationValue
                lblSIVVHNo.Text = frmRGNStockCodeLookup.psRGNVHNoValue
                lblSIVVHDetailCostCode.Text = frmRGNStockCodeLookup.psRGNVHDetailCostCodeValue
                lblSIVODOReading.Text = frmRGNStockCodeLookup.psRGNODOReadingValue
                '
                psRGNT0IdValue = frmRGNStockCodeLookup.psRGNT0Id
                psRGNT1IdValue = frmRGNStockCodeLookup.psRGNT1Id
                psRGNT2IdValue = frmRGNStockCodeLookup.psRGNT2Id
                psRGNT3IdValue = frmRGNStockCodeLookup.psRGNT3Id
                psRGNT4IdValue = frmRGNStockCodeLookup.psRGNT4Id
                psRGNBlockIdValue = frmRGNStockCodeLookup.psRGNBlockId
                psRGNDivIdValue = frmRGNStockCodeLookup.psRGNDivId
                psRGNYOPIdValue = frmRGNStockCodeLookup.psRGNYOPId
                psRGNStationIdValue = frmRGNStockCodeLookup.psRGNStationId
                psRGNVHIdValue = frmRGNStockCodeLookup.psRGNVHNoId
                psRGNVHDetailCostCodeIdValue = frmRGNStockCodeLookup.psRGNVHDetailCostCodeId
                '

            End If

        Else

            DisplayInfoMessage("Msg04")
            'MessageBox.Show("Select SIV No")
            txtSIVNo.Focus()

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Function StockCodeExist(ByVal StockCode As String) As Boolean

        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgRGN.Rows
                'If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
                If StockCode = objDataGridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString() Then
                    '
                    txtStockCode.Text = String.Empty
                    'txtRequestedQty.Text = string.empty 
                    txtStockCode.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Function

    Private Function StockCodeExistUpdateMode(ByVal StockCode As String) As Boolean

        Try
            If psExistingStockCode <> String.Empty Then
                If psExistingStockCode = psRGNSTIssueDetailsID Then
                    Return False
                End If
            End If

            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgRGN.Rows
                'If StockCode = objDataGridViewRow.Cells("dgclStockCode").Value.ToString() Then
                If StockCode = objDataGridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString() Then
                    '
                    txtStockCode.Text = String.Empty
                    'txtRequestedQty.Text = string.empty 
                    txtStockCode.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Function

    Private Sub dgRGN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRGN.CellDoubleClick

        RGNGrid_Edit()

    End Sub

    Private Sub RGNGrid_Edit()

        If dgRGN.Rows.Count > 0 Then

            'btnAdd.Text = "Update"

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If

            txtStockCode.Text = dgRGN.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            psRGNSTockId = dgRGN.SelectedRows(0).Cells("dgclStockId").Value
            If Not dgRGN.SelectedRows(0).Cells("dgclUnit").Value Is DBNull.Value Then
                lblUnit.Text = dgRGN.SelectedRows(0).Cells("dgclUnit").Value
            Else
                lblUnit.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclPartNo").Value Is DBNull.Value Then
                lblPartNo.Text = dgRGN.SelectedRows(0).Cells("dgclPartNo").Value
            Else
                lblPartNo.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclStockDesc").Value Is DBNull.Value Then
                lblDescription.Text = dgRGN.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
            Else
                lblDescription.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclIssueQty").Value Is DBNull.Value Then
                txtIssueQty.Text = dgRGN.SelectedRows(0).Cells("dgclIssueQty").Value
            Else
                txtIssueQty.Text = 0
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclIssueValue").Value Is DBNull.Value Then
                txtIssueValue.Text = dgRGN.SelectedRows(0).Cells("dgclIssueValue").Value
            Else
                txtIssueValue.Text = 0
            End If

            If Not dgRGN.SelectedRows(0).Cells("dgclReturnQty").Value Is DBNull.Value Then
                txtReturnedQty.Text = dgRGN.SelectedRows(0).Cells("dgclReturnQty").Value
            Else
                txtReturnedQty.Text = 0
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclReturnedValue").Value Is DBNull.Value Then
                txtReturnedValue.Text = dgRGN.SelectedRows(0).Cells("dgclReturnedValue").Value
            Else
                txtReturnedValue.Text = 0
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclSTIssueId").Value Is DBNull.Value Then
                psRGNSTIssueID = dgRGN.SelectedRows(0).Cells("dgclSTIssueId").Value.ToString()
            Else
                psRGNSTIssueID = String.Empty
            End If
            If dgRGN.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value <> "" Then
                psRGNSTIssueDetailsID = dgRGN.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString()
                psExistingStockCode = dgRGN.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString()
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsNoteID").Value Is DBNull.Value Then
                psSTReturnGoodsNoteID = dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsNoteID").Value.ToString()
            Else
                psSTReturnGoodsNoteID = String.Empty
            End If

            If Not dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsDetailsID").Value Is DBNull.Value Then
                psSTReturnGoodsDetailsID = dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsDetailsID").Value.ToString()
            Else
                psSTReturnGoodsDetailsID = String.Empty
            End If

            If Not dgRGN.SelectedRows(0).Cells("dgclT0").Value Is DBNull.Value Then
                lblSIVT0Value.Text = dgRGN.SelectedRows(0).Cells("dgclT0").Value.ToString()
            Else
                lblSIVT0Value.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclT1").Value Is DBNull.Value Then
                lblSIVT1Value.Text = dgRGN.SelectedRows(0).Cells("dgclT1").Value.ToString()
            Else
                lblSIVT1Value.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclT2").Value Is DBNull.Value Then
                lblSIVT2Value.Text = dgRGN.SelectedRows(0).Cells("dgclT2").Value.ToString()
            Else
                lblSIVT2Value.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclT3").Value Is DBNull.Value Then
                lblSIVT3Value.Text = dgRGN.SelectedRows(0).Cells("dgclT3").Value.ToString()
            Else
                lblSIVT3Value.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclT4").Value Is DBNull.Value Then
                lblSIVT4Value.Text = dgRGN.SelectedRows(0).Cells("dgclT4").Value.ToString()
            Else
                lblSIVT4Value.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclYOP").Value Is DBNull.Value Then
                lblSIVYOP.Text = dgRGN.SelectedRows(0).Cells("dgclYOP").Value.ToString()
            Else
                lblSIVYOP.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclBlock").Value Is DBNull.Value Then
                lblSIVBlock.Text = dgRGN.SelectedRows(0).Cells("dgclBlock").Value.ToString()
            Else
                lblSIVBlock.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclStation").Value Is DBNull.Value Then
                lblSIVStation.Text = dgRGN.SelectedRows(0).Cells("dgclStation").Value.ToString()
            Else
                lblSIVStation.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclDiv").Value Is DBNull.Value Then
                lblSIVDiv.Text = dgRGN.SelectedRows(0).Cells("dgclDiv").Value.ToString()
            Else
                lblSIVDiv.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclVHNo").Value Is DBNull.Value Then
                lblSIVVHNo.Text = dgRGN.SelectedRows(0).Cells("dgclVHNo").Value.ToString()
            Else
                lblSIVVHNo.Text = String.Empty
            End If
            If Not dgRGN.SelectedRows(0).Cells("dgclVHDetailCostCode").Value Is DBNull.Value Then
                lblSIVVHDetailCostCode.Text = dgRGN.SelectedRows(0).Cells("dgclVHDetailCostCode").Value.ToString()
            Else
                lblSIVVHDetailCostCode.Text = String.Empty
            End If
            btnAddFlag = False
        End If

    End Sub


    'Private Sub RGNGrid_Edit()

    '    If dgRGN.Rows.Count > 0 Then

    '        btnAdd.Text = "Update"
    '        txtStockCode.Text = dgRGN.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
    '        psRGNSTockId = dgRGN.SelectedRows(0).Cells("dgclStockId").Value
    '        If Not dgRGN.SelectedRows(0).Cells("dgclUnit").Value Is DBNull.Value Then
    '            lblUnit.Text = dgRGN.SelectedRows(0).Cells("dgclUnit").Value
    '        Else
    '            lblUnit.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclPartNo").Value Is DBNull.Value Then
    '            lblPartNo.Text = dgRGN.SelectedRows(0).Cells("dgclPartNo").Value
    '        Else
    '            lblPartNo.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclStockDesc").Value Is DBNull.Value Then
    '            lblDescription.Text = dgRGN.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
    '        Else
    '            lblDescription.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclIssueQty").Value Is DBNull.Value Then
    '            txtIssueQty.Text = dgRGN.SelectedRows(0).Cells("dgclIssueQty").Value
    '        Else
    '            txtIssueQty.Text = 0
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclIssueValue").Value Is DBNull.Value Then
    '            txtIssueValue.Text = dgRGN.SelectedRows(0).Cells("dgclIssueValue").Value
    '        Else
    '            txtIssueValue.Text = 0
    '        End If

    '        If Not dgRGN.SelectedRows(0).Cells("dgclReturnQty").Value Is DBNull.Value Then
    '            txtReturnedQty.Text = dgRGN.SelectedRows(0).Cells("dgclReturnQty").Value
    '        Else
    '            txtReturnedQty.Text = 0
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclReturnedValue").Value Is DBNull.Value Then
    '            txtReturnedValue.Text = dgRGN.SelectedRows(0).Cells("dgclReturnedValue").Value
    '        Else
    '            txtReturnedValue.Text = 0
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclSTIssueId").Value Is DBNull.Value Then
    '            psRGNSTIssueID = dgRGN.SelectedRows(0).Cells("dgclSTIssueId").Value.ToString()
    '        Else
    '            psRGNSTIssueID = String.Empty
    '        End If
    '        If dgRGN.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value <> "" Then
    '            psRGNSTIssueDetailsID = dgRGN.SelectedRows(0).Cells("dgclSTIssueDetailsID").Value.ToString()
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsNoteID").Value Is DBNull.Value Then
    '            psSTReturnGoodsNoteID = dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsNoteID").Value.ToString()
    '        Else
    '            psSTReturnGoodsNoteID = String.Empty
    '        End If

    '        If Not dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsDetailsID").Value Is DBNull.Value Then
    '            psSTReturnGoodsDetailsID = dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsDetailsID").Value.ToString()
    '        Else
    '            psSTReturnGoodsDetailsID = String.Empty
    '        End If
    '        '
    '        If Not dgRGN.SelectedRows(0).Cells("dgclT0").Value Is DBNull.Value Then
    '            lblSIVT0Value.Text = dgRGN.SelectedRows(0).Cells("dgclT0").Value.ToString()
    '        Else
    '            lblSIVT0Value.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclT1").Value Is DBNull.Value Then
    '            lblSIVT1Value.Text = dgRGN.SelectedRows(0).Cells("dgclT1").Value.ToString()
    '        Else
    '            lblSIVT1Value.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclT2").Value Is DBNull.Value Then
    '            lblSIVT2Value.Text = dgRGN.SelectedRows(0).Cells("dgclT2").Value.ToString()
    '        Else
    '            lblSIVT2Value.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclT3").Value Is DBNull.Value Then
    '            lblSIVT3Value.Text = dgRGN.SelectedRows(0).Cells("dgclT3").Value.ToString()
    '        Else
    '            lblSIVT3Value.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclT4").Value Is DBNull.Value Then
    '            lblSIVT4Value.Text = dgRGN.SelectedRows(0).Cells("dgclT4").Value.ToString()
    '        Else
    '            lblSIVT4Value.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclBlock").Value Is DBNull.Value Then
    '            lblSIVBlock.Text = dgRGN.SelectedRows(0).Cells("dgclBlock").Value.ToString()
    '        Else
    '            lblSIVBlock.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclDiv").Value Is DBNull.Value Then
    '            lblSIVDiv.Text = dgRGN.SelectedRows(0).Cells("dgclDiv").Value.ToString()
    '        Else
    '            lblSIVDiv.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclYOP").Value Is DBNull.Value Then
    '            lblSIVYOP.Text = dgRGN.SelectedRows(0).Cells("dgclYOP").Value.ToString()
    '        Else
    '            lblSIVYOP.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclVHNo").Value Is DBNull.Value Then
    '            lblSIVVHNo.Text = dgRGN.SelectedRows(0).Cells("dgclVHNo").Value.ToString()
    '        Else
    '            lblSIVVHNo.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclVHDetailCostCode").Value Is DBNull.Value Then
    '            lblSIVVHDetailCostCode.Text = dgRGN.SelectedRows(0).Cells("dgclVHDetailCostCode").Value.ToString()
    '        Else
    '            lblSIVVHDetailCostCode.Text = String.Empty
    '        End If
    '        If Not dgRGN.SelectedRows(0).Cells("dgclODOReading").Value Is DBNull.Value Then
    '            lblSIVODOReading.Text = dgRGN.SelectedRows(0).Cells("dgclODOReading").Value.ToString()
    '        Else
    '            lblSIVODOReading.Text = String.Empty
    '        End If
    '        '
    '        btnAddFlag = False
    '    End If

    'End Sub

    Private Sub UpdateRGNDetail()

        If StockCodeExistUpdateMode(psRGNSTIssueDetailsID) Then 'StockCode Validation,if already added in grid
            MsgBox("Sorry, the Stock Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            Exit Sub
        End If

        Dim intCount As Integer = dgRGN.CurrentRow.Index
        dgRGN.Rows(intCount).Cells("dgclStockCode").Value = txtStockCode.Text
        dgRGN.Rows(intCount).Cells("dgclStockId").Value = psRGNSTockId
        If Not lblDescription.Text Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclStockDesc").Value = lblDescription.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclStockDesc").Value = String.Empty
        End If
        If Not lblUnit.Text Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclUnit").Value = lblUnit.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclUnit").Value = String.Empty
        End If
        If Not lblPartNo.Text Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclPartNo").Value = lblPartNo.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclPartNo").Value = String.Empty
        End If
        If Not txtIssueQty.Text Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclIssueQty").Value = txtIssueQty.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclIssueQty").Value = 0
        End If
        If Not txtIssueValue.Text Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclIssueValue").Value = txtIssueValue.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclIssueValue").Value = 0
        End If

        If Not txtReturnedQty.Text Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclReturnQty").Value = txtReturnedQty.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclReturnQty").Value = 0
        End If
        If txtReturnedValue.Text <> String.Empty Then
            dgRGN.Rows(intCount).Cells("dgclReturnedValue").Value = txtReturnedValue.Text
        Else
            dgRGN.Rows(intCount).Cells("dgclReturnedValue").Value = 0
        End If
        If Not psRGNSTIssueID Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclSTIssueId").Value = psRGNSTIssueID
        Else
            dgRGN.Rows(intCount).Cells("dgclSTIssueId").Value = String.Empty
        End If
        dgRGN.Rows(intCount).Cells("dgclSTIssueDetailsID").Value = psRGNSTIssueDetailsID
        If Not psSTReturnGoodsNoteID Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclSTReturnGoodsNoteID").Value = psSTReturnGoodsNoteID
        Else
            dgRGN.Rows(intCount).Cells("dgclSTReturnGoodsNoteID").Value = String.Empty
        End If
        If Not psSTReturnGoodsDetailsID Is DBNull.Value Then
            dgRGN.Rows(intCount).Cells("dgclSTReturnGoodsDetailsID").Value = psSTReturnGoodsDetailsID
        Else
            dgRGN.Rows(intCount).Cells("dgclSTReturnGoodsDetailsID").Value = String.Empty
        End If
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        txtStockCode.Text = String.Empty
        ClearRGNStockDetails()
        btnAddFlag = True
        btnSaveAll.Focus()

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        txtStockCode.Text = String.Empty
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        ClearRGNStockDetails()

    End Sub

    Private Function IsValidFields() As Boolean

        If (txtRGNNo.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg05")
            'MessageBox.Show("RGN No is Empty", "Please give RGN No", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRGNNo.Focus()
            Return False

        End If

        If (dtpRGNDate.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg06")
            'MessageBox.Show("RGN Date is Empty", "Please give RGN Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRGNDate.Focus()
            Return False
        End If
        If (txtSIVNo.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg07")
            'MessageBox.Show("SIV No is Empty", "Please select SIV No", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSIVNo.Focus()
            Return False
        End If
        If (txtStockCode.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg08")
            'MessageBox.Show("Stock Code not Selected", "Please select Stock Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCode.Focus()
            Return False
        End If
        If (lblUnit.Text.Trim = String.Empty) Then
            DisplayInfoMessage("Msg09")
            'MessageBox.Show("No Unit Found", "Please select Unit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lblUnit.Focus()
            Return False
        End If
        If (txtIssueQty.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg10")
            'MessageBox.Show("Issue quantity should not be empty", "Please Enter Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIssueQty.Focus()
            Return False
        End If
        If (txtReturnedQty.Text.Trim() = String.Empty) Then
            DisplayInfoMessage("Msg11")
            'MessageBox.Show("Returned quantity should not be empty", "Please Enter Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnedQty.Focus()
            Return False
        End If
        If (txtReturnedQty.Text.Trim() <> String.Empty) Then
            If (CDbl(txtReturnedQty.Text) <= 0) Then
                DisplayInfoMessage("Msg12")
                'MessageBox.Show("Returned quantity should be greater than zero", "Please Enter correct Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnedQty.Focus()
                Return False
            End If
        End If
        If (txtReturnedQty.Text.Trim() <> String.Empty And txtIssueQty.Text.Trim() <> String.Empty) Then
            If (CDbl(txtReturnedQty.Text) > CDbl(txtIssueQty.Text)) Then
                DisplayInfoMessage("Msg13")
                'MessageBox.Show("Returned quantity should not be more than Issue Quantity", "Please Enter correct Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnedQty.Focus()
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub txtIssueQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

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

                        If txtBox.Text.Trim.Contains("") Then
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

    Private Sub txtIssueQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    Private Sub txtReturnedQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReturnedQty.KeyPress

        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            '    ' Stop the character from being entered into the control since it is non-numerical.
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

    Private Sub txtReturnedQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnedQty.KeyDown

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

        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{Tab}")
        End If

    End Sub

    Private Sub txtReturnedValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnedValue.KeyDown

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

                        isDecimal = reDecimalPrice.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If

    End Sub

    Private Sub txtReturnedValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReturnedValue.KeyPress

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If (dgRGN.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED")) And mdiparent.strMenuID = "M7" And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg50"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        ''If btnAdd.Text = "Add" and btnAddFlag = True  Then
        If btnAddFlag = True Then
            If IsValidFields() = True Then
                dgRGN.AutoGenerateColumns = False
                AddRGNDetail()
            Else
                Exit Sub
            End If
        ElseIf btnAddFlag = False Then
            If IsValidFields() = True Then
                dgRGN.AutoGenerateColumns = False
                UpdateRGNDetail()
            Else
                Exit Sub
            End If
        End If

        'GlobalPPT.IsRetainFocus = True

    End Sub

    Private Sub AddRGNDetail()

        Dim intRowcount As Integer = dtRGN.Rows.Count
        Dim objSIVPPT As New StoreIssueVoucherPPT
        'objSIVPPT.StockCode = txtStockCode.Text.Trim()
        objSIVPPT.StockCode = psRGNSTIssueDetailsID

        'Dim intRowcount As Integer = dgRGN.Rows.Count
        Try
            If Not StockCodeExist(objSIVPPT.StockCode) Then 'StockCode Validation,if already added in grid
                rowRGNAdd = dtRGN.NewRow()
                If intRowcount = 0 And dtAddFlag = False Then
                    'Add the Data column to the datatable first time 
                    columnRGNAdd = New DataColumn("StockCode", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("StockId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("StockDesc", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("Unit", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("PartNo", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("IssueQty", System.Type.[GetType]("System.Decimal"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("IssueValue", System.Type.[GetType]("System.Decimal"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("ReturnQty", System.Type.[GetType]("System.Decimal"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("ReturnedValue", System.Type.[GetType]("System.Decimal"))
                    dtRGN.Columns.Add(columnRGNAdd)

                    columnRGNAdd = New DataColumn("SIVCOAID", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("SIVCOACODE", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("SIVCOADESCP", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)

                    columnRGNAdd = New DataColumn("STIssueId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("STIssueDetailsID", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)

                    columnRGNAdd = New DataColumn("STReturnGoodsNoteID", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("STReturnGoodsDetailsID", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)

                    columnRGNAdd = New DataColumn("T0", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T1", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T2", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T3", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T4", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("YOP", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("Station", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("Block", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("Div", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("VHNo", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("VHDetailCostCode", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)

                    columnRGNAdd = New DataColumn("T0Id", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T1Id", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T2Id", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T3Id", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("T4Id", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("YOPId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("StationId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("BlockId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("DivId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("VHId", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)
                    columnRGNAdd = New DataColumn("VHDetailCostCodeID", System.Type.[GetType]("System.String"))
                    dtRGN.Columns.Add(columnRGNAdd)

                    rowRGNAdd("StockCode") = txtStockCode.Text.Trim()
                    rowRGNAdd("StockId") = psRGNSTockId
                    If lblDescription.Text <> String.Empty Then
                        rowRGNAdd("StockDesc") = lblDescription.Text.Trim()
                    End If
                    If lblUnit.Text <> String.Empty Then
                        rowRGNAdd("Unit") = lblUnit.Text.Trim()
                    End If
                    If lblPartNo.Text <> String.Empty Then
                        rowRGNAdd("PartNo") = lblPartNo.Text.Trim()
                    End If

                    If txtIssueQty.Text <> String.Empty Then
                        rowRGNAdd("IssueQty") = CDbl(txtIssueQty.Text)
                    End If
                    If txtIssueValue.Text <> String.Empty Then
                        rowRGNAdd("IssueValue") = CDbl(txtIssueValue.Text)
                    End If
                    If txtReturnedQty.Text <> String.Empty Then
                        rowRGNAdd("ReturnQty") = CDbl(txtReturnedQty.Text)
                    End If
                    If psRGNSTIssueID <> String.Empty Then
                        rowRGNAdd("STIssueId") = psRGNSTIssueID
                    End If
                    rowRGNAdd("STIssueDetailsID") = psRGNSTIssueDetailsID

                    rowRGNAdd("SIVCOAID") = psRGNSIVCOAID
                    rowRGNAdd("SIVCOACODE") = psRGNSIVCOACODE
                    rowRGNAdd("SIVCOADESCP") = psRGNSIVCOADESCP

                    If lblSIVT0Value.Text <> String.Empty Then
                        rowRGNAdd("T0") = lblSIVT0Value.Text
                        rowRGNAdd("T0Id") = psRGNT0IdValue
                    End If
                    If lblSIVT1Value.Text <> String.Empty Then
                        rowRGNAdd("T1") = lblSIVT1Value.Text
                        rowRGNAdd("T1Id") = psRGNT1IdValue
                    End If
                    If lblSIVT2Value.Text <> String.Empty Then
                        rowRGNAdd("T2") = lblSIVT2Value.Text
                        rowRGNAdd("T2Id") = psRGNT2IdValue
                    End If
                    If lblSIVT3Value.Text <> String.Empty Then
                        rowRGNAdd("T3") = lblSIVT3Value.Text
                        rowRGNAdd("T3Id") = psRGNT3IdValue
                    End If
                    If lblSIVT4Value.Text <> String.Empty Then
                        rowRGNAdd("T4") = lblSIVT4Value.Text
                        rowRGNAdd("T4Id") = psRGNT4IdValue
                    End If
                    If lblSIVYOP.Text <> String.Empty Then
                        rowRGNAdd("YOP") = lblSIVYOP.Text
                        rowRGNAdd("YOPId") = psRGNYOPIdValue
                    End If
                    If lblSIVStation.Text <> String.Empty Then
                        rowRGNAdd("Station") = lblSIVStation.Text
                        rowRGNAdd("StationId") = psRGNStationIdValue
                    End If
                    If lblSIVBlock.Text <> String.Empty Then
                        rowRGNAdd("Block") = lblSIVBlock.Text
                        rowRGNAdd("BlockID") = psRGNBlockIdValue
                    End If
                    If lblSIVDiv.Text <> String.Empty Then
                        rowRGNAdd("Div") = lblSIVDiv.Text
                        rowRGNAdd("DivId") = psRGNDivIdValue
                    End If
                    If lblSIVVHNo.Text <> String.Empty Then
                        rowRGNAdd("VHNo") = lblSIVVHNo.Text
                        rowRGNAdd("VHId") = psRGNVHIdValue
                    End If
                    If lblSIVVHDetailCostCode.Text <> String.Empty Then
                        rowRGNAdd("VHDetailCostCode") = lblSIVVHDetailCostCode.Text
                        rowRGNAdd("VHDetailCostCodeID") = psRGNVHDetailCostCodeIdValue
                    End If

                    dtRGN.Rows.InsertAt(rowRGNAdd, intRowcount)
                    dtAddFlag = True
                Else
                    rowRGNAdd("StockCode") = txtStockCode.Text.Trim()
                    rowRGNAdd("StockId") = psRGNSTockId
                    If lblDescription.Text <> String.Empty Then
                        rowRGNAdd("StockDesc") = lblDescription.Text.Trim()
                    End If
                    If lblUnit.Text <> String.Empty Then
                        rowRGNAdd("Unit") = lblUnit.Text.Trim()
                    End If
                    If lblPartNo.Text <> String.Empty Then
                        rowRGNAdd("PartNo") = lblPartNo.Text.Trim()
                    End If

                    If txtIssueQty.Text <> String.Empty Then
                        rowRGNAdd("IssueQty") = CDbl(txtIssueQty.Text)
                    End If
                    If txtIssueValue.Text <> String.Empty Then
                        rowRGNAdd("IssueValue") = CDbl(txtIssueValue.Text)
                    End If
                    If txtReturnedQty.Text <> String.Empty Then
                        rowRGNAdd("ReturnQty") = CDbl(txtReturnedQty.Text)
                    End If
                    If psRGNSTIssueID <> String.Empty Then
                        rowRGNAdd("STIssueId") = psRGNSTIssueID
                    End If
                    rowRGNAdd("STIssueDetailsID") = psRGNSTIssueDetailsID

                    rowRGNAdd("SIVCOAID") = psRGNSIVCOAID
                    rowRGNAdd("SIVCOACODE") = psRGNSIVCOACODE
                    rowRGNAdd("SIVCOADESCP") = psRGNSIVCOADESCP

                    If lblSIVT0Value.Text <> String.Empty Then
                        rowRGNAdd("T0") = lblSIVT0Value.Text
                        rowRGNAdd("T0Id") = psRGNT0IdValue
                    End If
                    If lblSIVT1Value.Text <> String.Empty Then
                        rowRGNAdd("T1") = lblSIVT1Value.Text
                        rowRGNAdd("T1Id") = psRGNT1IdValue
                    End If
                    If lblSIVT2Value.Text <> String.Empty Then
                        rowRGNAdd("T2") = lblSIVT2Value.Text
                        rowRGNAdd("T2Id") = psRGNT2IdValue
                    End If
                    If lblSIVT3Value.Text <> String.Empty Then
                        rowRGNAdd("T3") = lblSIVT3Value.Text
                        rowRGNAdd("T3Id") = psRGNT3IdValue
                    End If
                    If lblSIVT4Value.Text <> String.Empty Then
                        rowRGNAdd("T4") = lblSIVT4Value.Text
                        rowRGNAdd("T4Id") = psRGNT4IdValue
                    End If
                    If lblSIVYOP.Text <> String.Empty Then
                        rowRGNAdd("YOP") = lblSIVYOP.Text
                        rowRGNAdd("YOPId") = psRGNYOPIdValue
                    End If
                    If lblSIVStation.Text <> String.Empty Then
                        rowRGNAdd("Station") = lblSIVStation.Text
                        rowRGNAdd("StationId") = psRGNStationIdValue
                    End If
                    If lblSIVBlock.Text <> String.Empty Then
                        rowRGNAdd("Block") = lblSIVBlock.Text
                        rowRGNAdd("BlockID") = psRGNBlockIdValue
                    End If
                    If lblSIVDiv.Text <> String.Empty Then
                        rowRGNAdd("Div") = lblSIVDiv.Text
                        rowRGNAdd("DivId") = psRGNDivIdValue
                    End If
                    If lblSIVVHNo.Text <> String.Empty Then
                        rowRGNAdd("VHNo") = lblSIVVHNo.Text
                        rowRGNAdd("VHId") = psRGNVHIdValue
                    End If
                    If lblSIVVHDetailCostCode.Text <> String.Empty Then
                        rowRGNAdd("VHDetailCostCode") = lblSIVVHDetailCostCode.Text
                        rowRGNAdd("VHDetailCostCodeID") = psRGNVHDetailCostCodeIdValue
                    End If

                    dtRGN.Rows.InsertAt(rowRGNAdd, intRowcount)
                End If
                dgRGN.DataSource = dtRGN
                dgRGN.AutoGenerateColumns = False
                txtStockCode.Text = String.Empty
                ClearRGNStockDetails()
                btnSaveAll.Focus()
            Else
                DisplayInfoMessage("Msg14")
                'MsgBox("Sorry, the Stock Code already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SaveAll()

        If IsValidSaveAll() = False Then
            Exit Sub
        End If

        If psSTReturnGoodsNoteID = String.Empty Then ' header id

            SaveFunction()
            SaveAllFunction()
            ClearRGNStockDetails()
            ClearRGNHeader()
            psRGNSTIssueID = String.Empty
            psSTReturnGoodsNoteID = String.Empty
            toGetRGNNo()
            dtAddFlag = True

        ElseIf psSTReturnGoodsNoteID <> String.Empty Then

            'If DeleteDetailRecords() = 0 Then

            '    SaveFunction()
            '    SaveAllFunction()
            '    ClearRGNStockDetails()
            '    ClearRGNHeader()
            '    psRGNSTIssueID = String.Empty
            '    psSTReturnGoodsNoteID = String.Empty
            '    toGetRGNNo()
            '    dtAddFlag = True

            'Else

            '    UpdateFunction()
            '    UpdateAllFunction()
            '    ClearRGNStockDetails()
            '    ClearRGNHeader()
            '    psRGNSTIssueID = String.Empty
            '    psSTReturnGoodsNoteID = String.Empty
            '    toGetRGNNo()
            '    dtAddFlag = True

            'End If

            UpdateFunction()
            UpdateAllFunction()
            ClearRGNStockDetails()
            ClearRGNHeader()
            psRGNSTIssueID = String.Empty
            psSTReturnGoodsNoteID = String.Empty
            toGetRGNNo()
            dtAddFlag = True

        End If

        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDate)

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub SaveFunction()

        Dim objRGNPPT As New ReturnGoodsNotePPT
        objRGNPPT.RGNNo = txtRGNNo.Text.Trim()
        objRGNPPT.RGNDate = dtpRGNDate.Value
        objRGNPPT.STIssueID = psRGNSTIssueID
        'objRGNPPT.Status = lblStatus.Text.Trim()
        objRGNPPT.Status = "OPEN"
        If txtRejectedReason.Text.Trim() <> String.Empty Then
            objRGNPPT.RejectedStatus = txtRejectedReason.Text.Trim()
        End If
        If txtRemarks.Text.Trim() <> String.Empty Then
            objRGNPPT.Remarks = txtRemarks.Text.Trim()
        End If
        Dim ds As New DataSet
        ds = ReturnGoodsNoteBOL.STReturnGoodsNoteInsert(objRGNPPT)
        If ds Is Nothing Then
            DisplayInfoMessage("Msg15")
            'MessageBox.Show("Failed to save database")
            Exit Sub
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            psSTReturnGoodsNoteID = ds.Tables(0).Rows(0).Item("STReturnGoodsNoteID")
        End If

    End Sub

    Private Sub SaveAllFunction()

        Dim objRGNPPT As New ReturnGoodsNotePPT
        Dim dsDetails As New DataSet

        If psSTReturnGoodsNoteID <> String.Empty Then '' If Me.btnSaveAll.Text = "Save All"

            If IsValidSaveAll() = True Then

                For Each DataGridViewRow In dgRGN.Rows

                    With objRGNPPT

                        .STReturnGoodsNoteID = psSTReturnGoodsNoteID
                        .StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
                        If Not DataGridViewRow.Cells("dgclUnit").Value Is DBNull.Value Then
                            .Unit = DataGridViewRow.Cells("dgclUnit").Value.ToString()
                            'Else
                            '    .Unit = String.Empty
                        End If
                        If Not DataGridViewRow.Cells("dgclIssueQty").Value Is DBNull.Value Then
                            .IssueQty = CDbl(DataGridViewRow.Cells("dgclIssueQty").Value)
                        Else
                            .IssueQty = 0
                        End If
                        If Not DataGridViewRow.Cells("dgclIssueValue").Value Is DBNull.Value Then
                            .IssueValue = CDbl(DataGridViewRow.Cells("dgclIssueValue").Value)
                        Else
                            .IssueValue = 0
                        End If
                        If Not DataGridViewRow.Cells("dgclReturnQty").Value Is DBNull.Value Then
                            .ReturnQty = CDbl(DataGridViewRow.Cells("dgclReturnQty").Value)
                        Else
                            .ReturnQty = 0
                        End If
                        If Not DataGridViewRow.Cells("dgclReturnedValue").Value Is DBNull.Value Then
                            .ReturnedValue = CDbl(DataGridViewRow.Cells("dgclReturnedValue").Value)
                        Else
                            .ReturnedValue = 0
                        End If
                        .STIssueDetailsID = DataGridViewRow.Cells("dgclSTIssueDetailsID").Value
                        'Dim a As String = DataGridViewRow.Cells("dgclVHNo").Value
                        'MessageBox.Show(a)
                        'Dim b As String = DataGridViewRow.Cells("dgclVHID").Value
                    End With

                    dsDetails = ReturnGoodsNoteBOL.STReturnGoodsDetailsInsert(objRGNPPT)

                Next

                If dsDetails Is Nothing Then

                    DisplayInfoMessage("Msg16")
                    'MsgBox("Failed to save details in database")
                    'delete heder table query
                    ReturnGoodsNoteBOL.STRGNDelete(objRGNPPT)

                Else

                    DisplayInfoMessage("Msg17")
                    'MessageBox.Show("Data Saved Successfully")
                    txtStockCode.Text = String.Empty
                    'arlSTReturnGoodsDetailsIDDel.Clear()
                End If

            Else

                Exit Sub

            End If

        End If

    End Sub

    Private Sub UpdateFunction()

        Dim objRGNPPT As New ReturnGoodsNotePPT
        objRGNPPT.RGNNo = txtRGNNo.Text.Trim()
        objRGNPPT.RGNDate = dtpRGNDate.Value 'Format(dtpRGNDate.Value, "MM/dd/yyyy")
        objRGNPPT.STIssueID = psRGNSTIssueID
        'objRGNPPT.Status = lblStatus.Text.Trim()
        objRGNPPT.Status = "OPEN"
        If txtRejectedReason.Text.Trim() <> String.Empty Then
            objRGNPPT.RejectedStatus = txtRejectedReason.Text.Trim()
        End If
        If txtRemarks.Text.Trim() <> String.Empty Then
            objRGNPPT.Remarks = txtRemarks.Text
        End If
        objRGNPPT.STReturnGoodsNoteID = psSTReturnGoodsNoteID
        Dim ds As New DataSet
        ds = ReturnGoodsNoteBOL.STReturnGoodsNoteUpdate(objRGNPPT, "NO")

        'If arlSTReturnGoodsDetailsIDDel.Count > 0 Then
        '    For Each arToDel In arlSTReturnGoodsDetailsIDDel
        '        objRGNPPT.STReturnGoodsDetailsID = arToDel
        '        ReturnGoodsNoteBOL.STRGNDetailDelete(objRGNPPT)
        '    Next
        'End If


    End Sub

    Private Sub UpdateAllFunction()

        Dim objRGNPPT As New ReturnGoodsNotePPT
        If Me.btnSaveAll.Text = "Update All" Or Me.btnSaveAll.Text = "Update Semua" Then

            If IsValidSaveAll() = True Then

                Dim dsDetails As New DataSet

                For Each DataGridViewRow In dgRGN.Rows

                    With objRGNPPT

                        .STReturnGoodsNoteID = psSTReturnGoodsNoteID
                        .STReturnGoodsDetailsID = DataGridViewRow.Cells("dgclSTReturnGoodsDetailsID").Value.ToString() 'psSTReturnGoodsDetailsID
                        .StockID = DataGridViewRow.Cells("dgclStockId").Value.ToString()
                        If Not DataGridViewRow.Cells("dgclUnit").Value Is DBNull.Value Then
                            .Unit = DataGridViewRow.Cells("dgclUnit").Value.ToString()
                        End If
                        If Not DataGridViewRow.Cells("dgclIssueQty").Value Is DBNull.Value Then
                            .IssueQty = CDbl(DataGridViewRow.Cells("dgclIssueQty").Value)
                        End If
                        If Not DataGridViewRow.Cells("dgclIssueValue").Value Is DBNull.Value Then
                            .IssueValue = CDbl(DataGridViewRow.Cells("dgclIssueValue").Value)
                        End If
                        If Not DataGridViewRow.Cells("dgclReturnQty").Value Is DBNull.Value Then
                            .ReturnQty = CDbl(DataGridViewRow.Cells("dgclReturnQty").Value)
                        End If
                        If Not DataGridViewRow.Cells("dgclReturnedValue").Value Is DBNull.Value Then
                            .ReturnedValue = CDbl(DataGridViewRow.Cells("dgclReturnedValue").Value)
                        End If
                        .STIssueDetailsID = DataGridViewRow.Cells("dgclSTIssueDetailsID").Value

                    End With

                    If DataGridViewRow.Cells("dgclSTReturnGoodsDetailsID").Value.ToString() = String.Empty Then
                        dsDetails = ReturnGoodsNoteBOL.STReturnGoodsDetailsInsert(objRGNPPT)
                    Else
                        dsDetails = ReturnGoodsNoteBOL.STReturnGoodsDetailsUpdate(objRGNPPT)
                    End If

                Next

                DisplayInfoMessage("Msg18")
                'MessageBox.Show("Data Updated Successfully")
                bIsDetailsFromUpdateMode = False
                txtStockCode.Text = String.Empty

            Else
                Exit Sub
            End If
        End If

        txtStockCode.Text = String.Empty
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        'arlSTReturnGoodsDetailsIDDel.Clear()
    End Sub

    Private Function IsValidSaveAll() As Boolean

        'If btnSaveAll.Text = "Save All" Then
        If dgRGN.Rows.Count = 0 Then
            DisplayInfoMessage("Msg19")
            'MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        'End If
        'If btnSaveAll.Text = "Update All" Then
        If dgRGN.Rows.Count = 0 Then
            DisplayInfoMessage("Msg20")
            'MessageBox.Show(" Please Add Stock Items", "Stock Items Required", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        'End If
        Return True

    End Function

    ' '' ''Private Sub tbRGN_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tbRGN.Selected
    ' '' ''    BindViewRGN()
    ' '' ''    'toGetRGNNo()

    ' '' ''    ''Dim objRGNPPT As New ReturnGoodsNotePPT
    ' '' ''    ''Dim ds As New DataSet
    ' '' ''    ''ds = ReturnGoodsNoteBOL.STRGNSearch(objRGNPPT, "NO")
    ' '' ''    ''dgViewRGN.DataSource = ds.Tables(0)

    ' '' ''End Sub

    Private Sub BindViewRGN()

        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDateSearch)
        Dim objRGNPPT As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        objRGNPPT.Status = "OPEN"
        ds = ReturnGoodsNoteBOL.STRGNSearch(objRGNPPT, "NO")
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgViewRGN.AutoGenerateColumns = False
                dgViewRGN.DataSource = ds.Tables(0)
                lblNoRecord.Visible = False
            Else
                dgViewRGN.AutoGenerateColumns = False
                dgViewRGN.DataSource = ds.Tables(0)
                lblNoRecord.Visible = True
            End If
        End If

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Me.Cursor = Cursors.WaitCursor
        Dim objRGNPPT As New ReturnGoodsNotePPT
        If chkViewRGNDate.Checked = True Then
            objRGNPPT.RGNDateIsChecked = True
        Else
            objRGNPPT.RGNDateIsChecked = False
        End If
        objRGNPPT.RGNDate = dtpRGNDateSearch.Value ' Format(Me.dtpRGNDateSearch.Value, "MM/dd/yyyy")
        objRGNPPT.SIVNO = txtSIVNoSearch.Text.Trim()
        objRGNPPT.RGNNo = txtRGNNoSearch.Text.Trim()
        objRGNPPT.Status = cmbStatusSearch.SelectedItem.ToString()
        Dim ds As New DataSet
        ds = ReturnGoodsNoteBOL.STRGNSearch(objRGNPPT, "NO")
        If ds.Tables(0).Rows.Count > 0 Then
            dgViewRGN.Visible = True
            lblNoRecord.Visible = False
            dgViewRGN.AutoGenerateColumns = False
            dgViewRGN.DataSource = ds.Tables(0)
        Else
            'dgViewRGN.Visible = False
            lblNoRecord.Visible = True
            dgViewRGN.AutoGenerateColumns = False
            dgViewRGN.DataSource = ds.Tables(0)
        End If
        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub dgViewRGN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewRGN.CellDoubleClick
        EditViewGridRecord()

    End Sub
    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                RGNView_Edit()
            End If
        End If

    End Sub
    Private Sub RGNView_Edit()

        Dim objRGN As New ReturnGoodsNotePPT
        Dim ds As New DataSet

        If dgViewRGN.RowCount > 0 Then
            objRGN.STReturnGoodsNoteID = dgViewRGN.SelectedRows(0).Cells("dgclSTRGNID").Value
            psSTReturnGoodsNoteID = objRGN.STReturnGoodsNoteID
            ds = ReturnGoodsNoteBOL.STRGNDetailsGet(objRGN)
            If ds.Tables(0).Rows.Count > 0 Then
                txtSIVNo.Text = dgViewRGN.SelectedRows(0).Cells("dgclSIVNO").Value
                txtRGNNo.Text = dgViewRGN.SelectedRows(0).Cells("dgclRGNNo").Value
                dtpRGNDate.Text = dgViewRGN.SelectedRows(0).Cells("dgclRGNDate").Value
                'FormatDatePicker()
                psRGNSTIssueID = dgViewRGN.SelectedRows(0).Cells("dgclViewSTIssueID").Value
                If dgViewRGN.SelectedRows(0).Cells("dgclRemarks").Value.ToString() <> String.Empty Then
                    txtRemarks.Text = dgViewRGN.SelectedRows(0).Cells("dgclRemarks").Value
                Else
                    txtRemarks.Text = String.Empty
                End If
                lblStatus.Text = dgViewRGN.SelectedRows(0).Cells("dgclStatus").Value
                dgclStatusVal = lblStatus.Text
                '
                If dgViewRGN.SelectedRows(0).Cells("dgclStatus").Value <> String.Empty Then
                    If dgViewRGN.SelectedRows(0).Cells("dgclStatus").Value.ToString().ToUpper = "REJECTED" Then
                        lblRejectedReasonValue.Visible = True
                        lblRejectedReason1.Visible = True
                        lblRejReasonColon.Visible = True
                        lblRejectedReasonValue.Text = dgViewRGN.SelectedRows(0).Cells("dgclRejectedStatus").Value
                    Else
                        lblRejectedReasonValue.Visible = False
                        lblRejectedReason1.Visible = False
                        lblRejReasonColon.Visible = False
                    End If
                End If

                '
                If dgViewRGN.SelectedRows(0).Cells("dgclRejectedStatus").Value.ToString() <> String.Empty Then
                    txtRejectedReason.Text = dgViewRGN.SelectedRows(0).Cells("dgclRejectedStatus").Value
                End If
                If dgViewRGN.SelectedRows(0).Cells("dgclStatus").Value = "APPROVED" Then
                    DisableRGNFromApprovalMode()
                Else
                    EnableRGNIFNotApprovalMode()
                    txtSIVNo.Enabled = False
                    btnSearchSIVNo.Enabled = False
                End If

                'btnSaveAll.Text = "Update All"

                If GlobalPPT.strLang = "en" Then
                    btnSaveAll.Text = "Update All"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveAll.Text = "Update Semua"
                End If

                dtRGN = Nothing
                dtRGN = ds.Tables(0)

                dgRGN.AutoGenerateColumns = False
                dgRGN.DataSource = dtRGN
                dtAddFlag = True
                tbRGN.SelectedTab = tbpgRGN
                txtStockCode.Text = String.Empty
                ClearRGNStockDetails()
            End If
            'dgRGN.Columns("dgclStockCOAID").Visible = False
            'dgRGN.Columns("dgclVarianceCOAID").Visible = False
            'dgRGN.Columns("dgclStockCategoryId").Visible = False
        Else
            DisplayInfoMessage("Msg21")
            'MessageBox.Show("There is no record to select")
            Exit Sub
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        DeleteRGN()
        BindViewRGN()

    End Sub

    Private Sub DeleteRGN()

        Dim strSTRGNGoodsNoteIdDel As String
        Me.cmsRGN.Visible = False
        Dim objRGN As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        If dgViewRGN.Rows.Count > 0 Then
            If dgViewRGN.SelectedRows(0).Cells("dgclStatus").Value.ToString() = "OPEN" Or dgViewRGN.SelectedRows(0).Cells("dgclStatus").Value.ToString() = "REJECTED" Then
                strSTRGNGoodsNoteIdDel = dgViewRGN.SelectedRows(0).Cells("dgclSTRGNID").Value.ToString()

                If MsgBox(rm.GetString("Msg22"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    objRGN.STReturnGoodsNoteID = strSTRGNGoodsNoteIdDel
                    ReturnGoodsNoteBOL.STRGNDelete(objRGN)
                    DisplayInfoMessage("Msg23")
                    'MessageBox.Show("Data Deleted Successfully")
                    bDelAllFlag = True
                    'BindViewRGN()
                Else
                    bDelAllFlag = False
                    'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                DisplayInfoMessage("Msg24")
                cmbStatusSearch.Text = cmbStatusSearch.Items(1) 'For Default OPEN
                'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            DisplayInfoMessage("Msg25")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub dgViewRGN_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgViewRGN.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgViewRGN.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgViewRGN.ClearSelection()
                    dgViewRGN.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If

    End Sub

    Private Sub txtIssueValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

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

    Private Sub txtIssueValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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

    Private Sub ResetAll()

        ClearRGNHeader()
        ClearRGNStockDetails()
        txtStockCode.Text = String.Empty
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


        btnPrint.Enabled = False
        'dtAddFlag = True
        psRGNSTIssueID = String.Empty
        psSTReturnGoodsNoteID = String.Empty

        txtStockCode.Enabled = False
        btnSearchStockCode.Enabled = True
        btnAdd.Enabled = True
        btnReset.Enabled = True
        btnSaveAll.Enabled = True
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
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

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click

        ConfirmApproval()

    End Sub

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

    Private Function IsValidComboSelect() As Boolean

        If cmbStatus.SelectedIndex = -1 Then
            DisplayInfoMessage("Msg26")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        If (cmbStatus.Text = "--Select Status--") Then
            DisplayInfoMessage("Msg27")
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

        Dim objRGNPPT As New ReturnGoodsNotePPT
        Dim objRGNApprovalPPT As New ReturnGoodsNoteApprovalPPT

        objRGNPPT.RGNNo = dgclRGNNoVal
        'objRGNPPT.RGNDate = Format(dgclRGNDateVal, "MM/dd/yyyy")
        'objRGNPPT.STIssueID = dgclViewSTIssueIDVal
        objRGNPPT.Status = dgclStatusVal
        objRGNPPT.RejectedStatus = dgclRejectedStatusVal
        objRGNPPT.STReturnGoodsNoteID = dgclSTRGNIDVal

        If cmbStatus.SelectedItem.ToString() = "APPROVED" Then
            txtRejectedReason.Text = String.Empty
            If MsgBox(rm.GetString("Msg28"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                '1st Step-Updadte the status in Store.STReturnGoodsNote Table
                Dim dsUpdateRGN As New DataSet
                objRGNPPT.Status = "APPROVED"
                dsUpdateRGN = ReturnGoodsNoteBOL.STReturnGoodsNoteUpdate(objRGNPPT, "YES")
                DisplayInfoMessage("Msg29")
                'MessageBox.Show("Approved Successfully")



                'Call TaskMonitor Update after successful approval -Start

                Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                Dim dsTaskMonitorUPDATE As New DataSet
                objStoreMonthEndClosingPPT.ModID = 2
                objStoreMonthEndClosingPPT.Task = "Return goods note approval"
                objStoreMonthEndClosingPPT.Complete = "Y"
                dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)
                If dsTaskMonitorUPDATE Is Nothing Then
                    DisplayInfoMessage("Msg30")
                    'MessageBox.Show("Failed to update Taskmonitor")
                    Exit Sub
                End If

                'Call TaskMonitor Update after successful approval -End


                '2nd Step-Calculate the average price and update the stockdetail table(stockdetail.avgprice=avgprice)
                'and update the same in STReturnGoodsDetails table (STReturnGoodsDetails.ReturnQty=ReturnQty*@AvgPrice)

                Dim dsUpdateStockDetailandRGNetail As New DataSet
                Dim ldReturnedValue As Double
                'Dim ldIssueUnitPrice As Double
                For Each GridViewRow In dgRGN.Rows
                    If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                        objRGNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                        objRGNPPT.ReturnQty = CDbl(GridViewRow.Cells("dgclReturnQty").Value.ToString())
                        dsUpdateStockDetailandRGNetail = ReturnGoodsNoteBOL.STStockDetailAvgPriceApproval(objRGNPPT)
                        If Not dsUpdateStockDetailandRGNetail.Tables(0).Rows(0).Item("ReturnedValue") Is Nothing Then
                            ldReturnedValue += dsUpdateStockDetailandRGNetail.Tables(0).Rows(0).Item("ReturnedValue")
                        End If
                    End If
                Next

                'Update Stissuedetails ReturnQty Start
                For Each GridViewRow In dgRGN.Rows

                    objRGNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                    objRGNPPT.STReturnGoodsDetailsID = GridViewRow.Cells("dgclSTReturnGoodsDetailsID").Value.ToString()


                    objRGNPPT.STIssueID = GridViewRow.Cells("dgclSTIssueId").Value.ToString() 'STIssueId
                    objRGNPPT.STIssueDetailsID = GridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString() 'STIssueDetailId
                    objRGNPPT.ReturnQty = CDbl(GridViewRow.Cells("dgclReturnQty").Value.ToString())
                    Dim intSTIssueDetailsReturnQtyUpdate As New Integer
                    intSTIssueDetailsReturnQtyUpdate = ReturnGoodsNoteBOL.STIssueDetailsReturnQtyUpdate(objRGNPPT)
                    If intSTIssueDetailsReturnQtyUpdate = 0 Then
                        DisplayInfoMessage("Msg31")
                        'MessageBox.Show("Failed to Update IssueDetails")
                        Exit Sub
                    End If

                Next

                'Update Stissuedetails ReturnQty End


                ''------------------------------------------------------RGN Obsolete START-----------------------------------------------------

                ' ''3rd step-Accounts.Ledgerallmodule insert start

                'objRGNApprovalPPT.AYear = GlobalPPT.intActiveYear
                'objRGNApprovalPPT.AMonth = GlobalPPT.IntActiveMonth
                'objRGNApprovalPPT.LedgerDate = dtpRGNDate.Value  'Format(dtpSIVDate.Value, "MM/dd/yyyy")
                'objRGNApprovalPPT.LedgerType = "STORE-RGN"
                'If dgclRemarksVal <> String.Empty Then
                '    objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + dgclRemarksVal  'txtRemarks.Text.Trim()
                'Else
                '    objRGNApprovalPPT.Descp = dgclRGNNoVal
                'End If

                ''objRGNApprovalPPT.BatchAmount = ldReturnedValue
                'Dim dsRowsAffectedLedgerAllModule As New DataSet
                'Dim strLedgerID, strLedgerNo, strLedgerType As String
                'dsRowsAffectedLedgerAllModule = ReturnGoodsNoteBOL.STRGNLedgerAllModuleInsert(objRGNApprovalPPT)
                'strLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                'strLedgerNo = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerNo")
                'strLedgerType = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerType")
                'objRGNApprovalPPT.LedgerID = strLedgerID
                ''Accounts.Ledgerallmodule insert end
                ''--------------
                'Dim intJournalRowsAffected As Integer = 0
                'Dim lStockCOAID As String, lVarianceCOAID As String = String.Empty
                'Dim lRGNPrice As Double, lSTDPrice As Double, lVariancePrice As Double

                'Dim strArray As String()
                'Dim strLoginMonthName As String
                'strArray = GlobalPPT.strLoginMonth.Split("-")
                'strLoginMonthName = strArray(1)

                'For Each GridViewRow In dgRGN.Rows
                '    If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                '        objRGNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                '        objRGNPPT.STReturnGoodsDetailsID = GridViewRow.Cells("dgclSTReturnGoodsDetailsID").Value.ToString()

                '        'Update Stissuedetails ReturnQty Start

                '        objRGNPPT.STIssueID = GridViewRow.Cells("dgclSTIssueId").Value.ToString() 'STIssueId
                '        objRGNPPT.STIssueDetailsID = GridViewRow.Cells("dgclSTIssueDetailsID").Value.ToString() 'STIssueDetailId
                '        Dim intSTIssueDetailsReturnQtyUpdate As New Integer
                '        intSTIssueDetailsReturnQtyUpdate = ReturnGoodsNoteBOL.STIssueDetailsReturnQtyUpdate(objRGNPPT)
                '        If intSTIssueDetailsReturnQtyUpdate = 0 Then
                '            MessageBox.Show("Failed to Update IssueDetails")
                '            Exit Sub
                '        End If
                '        'Update Stissuedetails ReturnQty End

                '        'Other Details like DIVId,yop etc get Start

                '        objRGNPPT.STIssueID = GridViewRow.Cells("dgclSTIssueId").Value.ToString() 'STIssueDetailId
                '        Dim dsOtherDetails As New DataSet
                '        dsOtherDetails = ReturnGoodsNoteBOL.STRGNOtherDetailsGet(objRGNPPT)

                '        'Other Details like DIVId,yop etc get End

                '        ''
                '        Dim dsSTRGNStockIDDetailSelect As New DataSet
                '        objRGNPPT.ReturnQty = GridViewRow.Cells("dgclReturnQty").Value()
                '        dsSTRGNStockIDDetailSelect = ReturnGoodsNoteBOL.STRGNStockIDDetailSelect(objRGNPPT)
                '        If Not dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("ReturnedValue") Is DBNull.Value Then
                '            lRGNPrice = CDbl(dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("ReturnedValue"))
                '        Else
                '            lRGNPrice = 0
                '        End If
                '        If Not dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice") Is DBNull.Value Then
                '            lSTDPrice = CDbl(dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice"))
                '        Else
                '            lSTDPrice = 0
                '        End If
                '        If Not dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StockCOAID") Is DBNull.Value Then
                '            lStockCOAID = dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StockCOAID")
                '        Else
                '            lStockCOAID = String.Empty
                '        End If
                '        If Not dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID") Is DBNull.Value Then
                '            lVarianceCOAID = dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("VarianceCOAID")
                '        Else
                '            lVarianceCOAID = String.Empty
                '        End If
                '        ''If Not GridViewRow.Cells("dgclStockDesc").Value Is DBNull.Value Then
                '        ''    objRGNApprovalPPT.Descp = GridViewRow.Cells("dgclStockDesc").Value.ToString()  ' descp=stock name
                '        ''Else
                '        ''    objRGNApprovalPPT.Descp = String.Empty
                '        ''End If



                '        ''
                '        '
                '        'RGNPRICE Start
                '        objRGNApprovalPPT.DC = "D"
                '        objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclStockDesc").Value ' <RGN No.> -<” StockCode-Stock Description” 
                '        objRGNApprovalPPT.COAID = GridViewRow.Cells("SIVCOAID").Value 'Debit siv COA
                '        objRGNApprovalPPT.Value = lRGNPrice
                '        '-----objRGNApprovalPPT.T0 = String.Empty

                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("DivID") Is DBNull.Value Then
                '            objRGNApprovalPPT.DivID = dsOtherDetails.Tables(0).Rows(0).Item("DivID")
                '        Else
                '            objRGNApprovalPPT.DivID = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("YOPid") Is DBNull.Value Then
                '            objRGNApprovalPPT.YopID = dsOtherDetails.Tables(0).Rows(0).Item("YOPid")
                '        Else
                '            objRGNApprovalPPT.YopID = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("BlockID") Is DBNull.Value Then
                '            objRGNApprovalPPT.BlockID = dsOtherDetails.Tables(0).Rows(0).Item("BlockID")
                '        Else
                '            objRGNApprovalPPT.BlockID = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("StationID") Is DBNull.Value Then
                '            objRGNApprovalPPT.StationID = dsOtherDetails.Tables(0).Rows(0).Item("StationID")
                '        Else
                '            objRGNApprovalPPT.StationID = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("VHID") Is DBNull.Value Then
                '            objRGNApprovalPPT.VHID = dsOtherDetails.Tables(0).Rows(0).Item("VHID")
                '        Else
                '            objRGNApprovalPPT.VHID = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("VHDetailCostCodeID") Is DBNull.Value Then
                '            objRGNApprovalPPT.VHDetailCostCodeID = dsOtherDetails.Tables(0).Rows(0).Item("VHDetailCostCodeID")
                '        Else
                '            objRGNApprovalPPT.VHDetailCostCodeID = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("T0") Is DBNull.Value Then
                '            objRGNApprovalPPT.T0 = dsOtherDetails.Tables(0).Rows(0).Item("T0")
                '        Else
                '            objRGNApprovalPPT.T0 = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("T1") Is DBNull.Value Then
                '            objRGNApprovalPPT.T1 = dsOtherDetails.Tables(0).Rows(0).Item("T1")
                '        Else
                '            objRGNApprovalPPT.T1 = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("T2") Is DBNull.Value Then
                '            objRGNApprovalPPT.T2 = dsOtherDetails.Tables(0).Rows(0).Item("T2")
                '        Else
                '            objRGNApprovalPPT.T2 = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("T3") Is DBNull.Value Then
                '            objRGNApprovalPPT.T3 = dsOtherDetails.Tables(0).Rows(0).Item("T3")
                '        Else
                '            objRGNApprovalPPT.T3 = String.Empty
                '        End If
                '        If Not dsOtherDetails.Tables(0).Rows(0).Item("T4") Is DBNull.Value Then
                '            objRGNApprovalPPT.T4 = dsOtherDetails.Tables(0).Rows(0).Item("T4")
                '        Else
                '            objRGNApprovalPPT.T4 = String.Empty
                '        End If

                '        objRGNApprovalPPT.Flag = "RGNPRICE"
                '        intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)

                '        objRGNApprovalPPT.DC = "C"
                '        objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + "Good Return" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' < RGN No.>.> “Good Return”> <loginMonth&Year>
                '        objRGNApprovalPPT.COAID = lStockCOAID 'Credit Store COA
                '        objRGNApprovalPPT.Value = lRGNPrice
                '        '-----objRGNApprovalPPT.T0 = String.Empty
                '        objRGNApprovalPPT.DivID = String.Empty
                '        objRGNApprovalPPT.YopID = String.Empty
                '        objRGNApprovalPPT.BlockID = String.Empty
                '        objRGNApprovalPPT.VHID = String.Empty
                '        objRGNApprovalPPT.VHDetailCostCodeID = String.Empty
                '        objRGNApprovalPPT.T0 = String.Empty
                '        objRGNApprovalPPT.T1 = String.Empty
                '        objRGNApprovalPPT.T2 = String.Empty
                '        objRGNApprovalPPT.T3 = String.Empty
                '        objRGNApprovalPPT.T4 = String.Empty
                '        objRGNApprovalPPT.StationID = String.Empty
                '        objRGNApprovalPPT.Flag = "RGNPRICE"
                '        intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                '        'RGNPRICE End
                '        '
                '        ''''
                '        'RGNSTDPRICE Start
                '        If lSTDPrice <> 0 And lStockCOAID <> String.Empty Then
                '            objRGNApprovalPPT.DC = "D"
                '            objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclStockDesc").Value ' <RGN No.> -<” StockCode-Stock Description” 
                '            objRGNApprovalPPT.COAID = GridViewRow.Cells("SIVCOAID").Value 'Debit siv COA
                '            objRGNApprovalPPT.Value = lSTDPrice
                '            '-----objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.DivID = String.Empty
                '            objRGNApprovalPPT.YopID = String.Empty
                '            objRGNApprovalPPT.BlockID = String.Empty
                '            objRGNApprovalPPT.VHID = String.Empty
                '            objRGNApprovalPPT.VHDetailCostCodeID = String.Empty
                '            objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.T1 = String.Empty
                '            objRGNApprovalPPT.T2 = String.Empty
                '            objRGNApprovalPPT.T3 = String.Empty
                '            objRGNApprovalPPT.T4 = String.Empty
                '            objRGNApprovalPPT.StationID = String.Empty
                '            objRGNApprovalPPT.Flag = "RGNSTDPRICE"
                '            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)

                '            objRGNApprovalPPT.DC = "C"
                '            objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + "Good Return" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' < RGN No.>.> “Good Return”> <loginMonth&Year>
                '            objRGNApprovalPPT.COAID = lStockCOAID 'Credit Store COA
                '            objRGNApprovalPPT.Value = lSTDPrice
                '            '-----objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.DivID = String.Empty
                '            objRGNApprovalPPT.YopID = String.Empty
                '            objRGNApprovalPPT.BlockID = String.Empty
                '            objRGNApprovalPPT.VHID = String.Empty
                '            objRGNApprovalPPT.VHDetailCostCodeID = String.Empty
                '            objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.T1 = String.Empty
                '            objRGNApprovalPPT.T2 = String.Empty
                '            objRGNApprovalPPT.T3 = String.Empty
                '            objRGNApprovalPPT.T4 = String.Empty
                '            objRGNApprovalPPT.StationID = String.Empty
                '            objRGNApprovalPPT.Flag = "RGNSTDPRICE"
                '            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                '        End If
                '        'STDPRICE End
                '        ''''
                '        '
                '        'RGNVARIANCEPRICE Start
                '        lVariancePrice = Abs(lSTDPrice - lRGNPrice)
                '        If lSTDPrice <> 0 And lVariancePrice <> 0 And lVarianceCOAID <> String.Empty Then
                '            objRGNApprovalPPT.DC = "D"
                '            objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + GridViewRow.Cells("dgclStockCode").Value + "-" + GridViewRow.Cells("dgclStockDesc").Value ' <RGN No.> -<” StockCode-Stock Description” 
                '            objRGNApprovalPPT.COAID = lVarianceCOAID  'Debit Variance COA
                '            objRGNApprovalPPT.Value = lVariancePrice
                '            '-----objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.DivID = String.Empty
                '            objRGNApprovalPPT.YopID = String.Empty
                '            objRGNApprovalPPT.BlockID = String.Empty
                '            objRGNApprovalPPT.VHID = String.Empty
                '            objRGNApprovalPPT.VHDetailCostCodeID = String.Empty
                '            objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.T1 = String.Empty
                '            objRGNApprovalPPT.T2 = String.Empty
                '            objRGNApprovalPPT.T3 = String.Empty
                '            objRGNApprovalPPT.T4 = String.Empty
                '            objRGNApprovalPPT.StationID = String.Empty
                '            objRGNApprovalPPT.Flag = "RGNVARIANCEPRICE"
                '            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)

                '            objRGNApprovalPPT.DC = "C"
                '            objRGNApprovalPPT.Descp = dgclRGNNoVal + "-" + "Good Return" + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() ' < RGN No.>.> “Good Return”> <loginMonth&Year>
                '            objRGNApprovalPPT.COAID = lStockCOAID 'Credit Store COA
                '            objRGNApprovalPPT.Value = lVariancePrice
                '            '-----objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.DivID = String.Empty
                '            objRGNApprovalPPT.YopID = String.Empty
                '            objRGNApprovalPPT.BlockID = String.Empty
                '            objRGNApprovalPPT.VHID = String.Empty
                '            objRGNApprovalPPT.VHDetailCostCodeID = String.Empty
                '            objRGNApprovalPPT.T0 = String.Empty
                '            objRGNApprovalPPT.T1 = String.Empty
                '            objRGNApprovalPPT.T2 = String.Empty
                '            objRGNApprovalPPT.T3 = String.Empty
                '            objRGNApprovalPPT.T4 = String.Empty
                '            objRGNApprovalPPT.StationID = String.Empty
                '            objRGNApprovalPPT.Flag = "RGNVARIANCEPRICE"
                '            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                '        End If
                '        'RGNVARIANCEPRICE End
                '        '
                '        If intJournalRowsAffected = 0 Then
                '            MessageBox.Show("Failed to Insert Journal Details Standard price Debit transaction")
                '            Exit Sub
                '        End If
                '    End If
                '    '--
                '------------------------------------------------------RGN Obsolete END-----------------------------------------------------


                '----------------------------------------------------------------------old code start--------------------------------

                ' '' ''5th step-Vehicle.VHChargeDetailInsert start
                '' ''Dim VHChargeDetailInsert As Integer = 0

                '' ''For Each GridViewRow In dgRGN.Rows

                '' ''    If Not (GridViewRow.Cells("dgclVHNo").Value Is Nothing Or GridViewRow.Cells("dgclVHNo").Value Is DBNull.Value) Then

                '' ''        Dim objSIVPPt As New StoreIssueVoucherPPT
                '' ''        Dim dsVHDetails As New DataSet
                '' ''        objSIVPPt.VHWSCode = GridViewRow.Cells("dgclVHNo").Value.ToString()
                '' ''        objSIVPPt.VHDesc = String.Empty
                '' ''        objSIVPPt.VHCategoryID = String.Empty
                '' ''        objSIVPPt.Type = String.Empty

                '' ''        dsVHDetails = StoreIssueVoucherBOL.GetVHNo(objSIVPPt, "YES")

                '' ''        objRGNApprovalPPT.EstateCodeL = dsVHDetails.Tables(0).Rows(0).Item("LocationID") ' should pass the actual value after discussion with anand
                '' ''        objRGNApprovalPPT.VHWSCode = GridViewRow.Cells("dgclVHNo").Value.ToString()
                '' ''        objRGNApprovalPPT.VHDetailCostCode = GridViewRow.Cells("dgclVHDetailCostCode").Value


                '' ''        If dsVHDetails.Tables(0).Rows(0).Item("Type") = "Vehicle" Then
                '' ''            objRGNApprovalPPT.Type = "V"
                '' ''        End If
                '' ''        If dsVHDetails.Tables(0).Rows(0).Item("Type") = "Workshop" Then
                '' ''            objRGNApprovalPPT.Type = "W"
                '' ''        End If
                '' ''        If dsVHDetails.Tables(0).Rows(0).Item("Type") = "Others" Then
                '' ''            objRGNApprovalPPT.Type = "O"
                '' ''        End If
                '' ''        'objStockIssueVoucherApprovalPPT.Type = GridViewRow.Cells("dgclType").Value.ToString()
                '' ''        objRGNApprovalPPT.AYear = GlobalPPT.intActiveYear
                '' ''        objRGNApprovalPPT.AMonth = GlobalPPT.IntLoginMonth
                '' ''        objRGNApprovalPPT.LedgerNo = strLedgerNo
                '' ''        objRGNApprovalPPT.LedgerType = strLedgerType
                '' ''        objRGNApprovalPPT.Value = lRGNPrice 'Return Value
                '' ''        If Not dsVHDetails.Tables(0).Rows(0).Item("VHDescp") Is DBNull.Value Then
                '' ''            objRGNApprovalPPT.Descp = dsVHDetails.Tables(0).Rows(0).Item("VHDescp") ' should pass the actual value after discussion with anand
                '' ''        Else
                '' ''            objRGNApprovalPPT.Descp = String.Empty
                '' ''        End If

                '' ''        VHChargeDetailInsert = ReturnGoodsNoteBOL.VHChargeDetailInsert(objRGNApprovalPPT)
                '' ''        If VHChargeDetailInsert = 0 Then
                '' ''            MessageBox.Show("Failed to Insert VHChargeDetail")
                '' ''            Exit Sub
                '' ''        End If
                '' ''    End If
                '' ''Next

                ' '' ''Vehicle.VHChargeDetailInsert end



                ' '' '' '' ''4th step-Accounts.JournalDetail.Insert start.

                '' '' '' ''For debit - STD PRICE
                ' '' '' ''Dim intJournalRowsAffected As Integer = 0
                ' '' '' ''For Each GridViewRow In dgRGN.Rows
                ' '' '' ''    If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                ' '' '' ''        objRGNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                ' '' '' ''        objRGNPPT.STReturnGoodsDetailsID = GridViewRow.Cells("dgclSTReturnGoodsDetailsID").Value.ToString()
                ' '' '' ''        objRGNPPT.ReturnQty = GridViewRow.Cells("dgclReturnQty").Value.ToString()
                ' '' '' ''        'objRGNApprovalPPT.COAID = GridViewRow.Cells("dgclStockCOAID").Value.ToString()
                ' '' '' ''        objRGNApprovalPPT.COAID = GridViewRow.Cells("dgclStockCOAID").Value.ToString()
                ' '' '' ''        objRGNApprovalPPT.DC = "D"
                ' '' '' ''        '
                ' '' '' ''        Dim dsSTRGNStockIDDetailSelect As New DataSet
                ' '' '' ''        dsSTRGNStockIDDetailSelect = ReturnGoodsNoteBOL.STRGNStockIDDetailSelect(objRGNPPT)
                ' '' '' ''        If dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("ReturnedValue").ToString <> String.Empty Then
                ' '' '' ''            objRGNApprovalPPT.Value = CDbl(dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("ReturnedValue").ToString())
                ' '' '' ''        End If

                ' '' '' ''        If dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StockDesc") <> String.Empty Then
                ' '' '' ''            objRGNApprovalPPT.Descp = dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StockDesc") ' descp=stock name
                ' '' '' ''        End If
                ' '' '' ''        objRGNApprovalPPT.Flag = "STD PRICE"
                ' '' '' ''        intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                ' '' '' ''        If intJournalRowsAffected = 0 Then
                ' '' '' ''            MessageBox.Show("Failed to Insert Journal Details Standard price Debit transaction")
                ' '' '' ''            Exit Sub
                ' '' '' ''        End If
                ' '' '' ''    End If
                ' '' '' ''Next
                '' '' '' ''For credit - STD PRICE
                ' '' '' ''objRGNApprovalPPT.COAID = psSIVAccountID ' credit supplier COAID
                '' '' '' ''objRGNApprovalPPT.COAID = psSIVAccountID
                ' '' '' ''objRGNApprovalPPT.Value = ldReturnedValue
                ' '' '' ''objRGNApprovalPPT.DC = "C"
                ' '' '' ''objRGNApprovalPPT.Flag = "STD PRICE"
                ' '' '' ''intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                ' '' '' ''If intJournalRowsAffected = 0 Then
                ' '' '' ''    MessageBox.Show("Failed to Insert Journal Details Standard price Credit transaction")
                ' '' '' ''    Exit Sub
                ' '' '' ''End If

                '' '' '' ''For debit and credit- Variance PRICE
                '' '' '' ''VariancePrice=StdPrice-TotalPrice
                ' '' '' ''For Each GridViewRow In dgRGN.Rows
                ' '' '' ''    If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                ' '' '' ''        objRGNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                ' '' '' ''        objRGNPPT.STReturnGoodsDetailsID = GridViewRow.Cells("dgclSTReturnGoodsDetailsID").Value.ToString()
                ' '' '' ''        objRGNPPT.ReturnQty = GridViewRow.Cells("dgclReturnQty").Value.ToString()
                ' '' '' ''        '
                ' '' '' ''        '
                ' '' '' ''        Dim dsSTRGNStockIDDetailSelect As New DataSet
                ' '' '' ''        dsSTRGNStockIDDetailSelect = ReturnGoodsNoteBOL.STRGNStockIDDetailSelect(objRGNPPT)
                ' '' '' ''        Dim ldStdPrice As Double
                ' '' '' ''        Dim ldVariancePrice As Double
                ' '' '' ''        Dim ldTotalPrice As Double 'IssuedValue
                ' '' '' ''        'If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice").ToString <> String.Empty Then
                ' '' '' ''        ldStdPrice = dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StdPrice").ToString()
                ' '' '' ''        'End If
                ' '' '' ''        'If dsSTIssueStockIDDetailSelect.Tables(0).Rows(0).Item("IssuedValue").ToString <> String.Empty Then
                ' '' '' ''        ldTotalPrice = dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("ReturnedValue").ToString()
                ' '' '' ''        'End If
                ' '' '' ''        ldVariancePrice = ldStdPrice - ldTotalPrice
                ' '' '' ''        objRGNApprovalPPT.Descp = dsSTRGNStockIDDetailSelect.Tables(0).Rows(0).Item("StockDesc") ' descp=stock name
                ' '' '' ''        objRGNApprovalPPT.Flag = "VARIANCE PRICE"

                ' '' '' ''        If ldVariancePrice > 0 Then 'If Variance price is +ve , debit the variance COAID and credit the supplier ID
                ' '' '' ''            objRGNApprovalPPT.Value = ldVariancePrice

                ' '' '' ''            objRGNApprovalPPT.DC = "D"
                ' '' '' ''            objRGNApprovalPPT.COAID = GridViewRow.Cells("dgclVarianceCOAID").Value.ToString()
                ' '' '' ''            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                ' '' '' ''            If intJournalRowsAffected = 0 Then
                ' '' '' ''                MessageBox.Show("Failed to Insert Journal Details Variance price Debit transaction")
                ' '' '' ''                Exit Sub
                ' '' '' ''            End If

                ' '' '' ''            objRGNApprovalPPT.DC = "C"
                ' '' '' ''            objRGNApprovalPPT.COAID = GridViewRow.Cells("dgclAccountId").Value.ToString() 'psSIVAccountID '
                ' '' '' ''            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                ' '' '' ''            If intJournalRowsAffected = 0 Then
                ' '' '' ''                MessageBox.Show("Failed to Insert Journal Details Variance price Credit transaction")
                ' '' '' ''                Exit Sub
                ' '' '' ''            End If

                ' '' '' ''        ElseIf ldVariancePrice < 0 Then 'If Variance price is -ve,Credit the variance COAID and debit the supplier ID
                ' '' '' ''            objRGNApprovalPPT.Value = ldVariancePrice

                ' '' '' ''            objRGNApprovalPPT.DC = "C"
                ' '' '' ''            objRGNApprovalPPT.COAID = GridViewRow.Cells("dgclVarianceCOAID").Value.ToString()
                ' '' '' ''            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                ' '' '' ''            If intJournalRowsAffected = 0 Then
                ' '' '' ''                MessageBox.Show("Failed to Insert Journal Details Variance price Credit transaction")
                ' '' '' ''                Exit Sub
                ' '' '' ''            End If

                ' '' '' ''            objRGNApprovalPPT.DC = "D"
                ' '' '' ''            objRGNApprovalPPT.COAID = GridViewRow.Cells("dgclAccountId").Value.ToString()
                ' '' '' ''            intJournalRowsAffected = ReturnGoodsNoteBOL.STRGNJournalDetailInsert(objRGNApprovalPPT)
                ' '' '' ''            If intJournalRowsAffected = 0 Then
                ' '' '' ''                MessageBox.Show("Failed to Insert Journal Details Variance price Debit transaction")
                ' '' '' ''                Exit Sub
                ' '' '' ''            End If
                ' '' '' ''        End If
                ' '' '' ''    End If
                ' '' '' ''Next
                '' '' '' ''Accounts.JournalDetail.Insert end
                '----------------------------------------------------------------------old code end--------------------------------


                GlobalPPT.IsButtonClose = True
                Me.Close()

            End If
        ElseIf cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            If txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg32")
                'MessageBox.Show("Please enter the rejected reason")
                txtRejectedReason.Focus()
                Exit Sub
            Else
                If MsgBox(rm.GetString("Msg33"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Reject the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    objRGNPPT.Status = "REJECTED"
                    objRGNPPT.RejectedStatus = txtRejectedReason.Text.Trim()
                    Dim ds As New DataSet
                    ds = ReturnGoodsNoteBOL.STReturnGoodsNoteUpdate(objRGNPPT, "YES")
                    DisplayInfoMessage("Msg34")
                    'MessageBox.Show("Rejected Successfully")
                    txtRejectedReason.Text = String.Empty

                    GlobalPPT.IsButtonClose = True
                    Me.Close()

                End If
            End If
        End If

    End Sub

    Private Sub tbRGN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRGN.Click

        If tbRGN.SelectedTab Is tbRGN.TabPages("tbpgView") Then

            chkViewRGNDate.Focus()
            If (dgRGN.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And btnSaveAll.Enabled = True) Then

                If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    StoreIssueVoucherBOL.ClearGridView(dgRGN)
                    GlobalPPT.IsRetainFocus = False
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    BindViewRGN()
                    Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDate)
                    Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDateSearch)
                Else
                    tbRGN.SelectedTab = tbpgRGN
                End If

            Else
                ResetAll()
                BindViewRGN()
                Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDate)
                Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDateSearch)

            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If


        ElseIf tbRGN.SelectedTab Is tbRGN.TabPages("tbpgRGN") Then
            If tbRGN.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgRGN.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ClearViewTabFields()
                            ResetAll()
                            EnableRGNIFNotApprovalMode()
                            btnAddFlag = True
                            dtpRGNDate.Focus()
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

    Private Sub ClearViewTabFields()

        txtRGNNoSearch.Text = String.Empty
        txtSIVNoSearch.Text = String.Empty
        chkViewRGNDate.Checked = False
        cmbStatusSearch.Text = cmbStatusSearch.Items(1) 'For Default OPEN

    End Sub

    Private Sub dgViewRGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgViewRGN.KeyDown

        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgRGN, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgRGN, e)
        'End If

    End Sub

    Private Sub dgRGN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgRGN.KeyDown

        If e.KeyCode = Keys.Return Then
            RGNGrid_Edit()
            e.Handled = True
        End If

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgRGN, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgRGN, e)
        'End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        ResetAll()
        btnAddFlag = True
        tbRGN.SelectedTab = tbpgRGN

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        EditViewGridRecord()

    End Sub

    Private Sub ReturnGoodsNoteFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click

        Me.Cursor = Cursors.WaitCursor
        'code here
        Dim ObjRecordExist As New Object
        Dim ObjRGNPPT As New ReturnGoodsNotePPT
        Dim ObjRGNBOL As New ReturnGoodsNoteBOL
        ObjRecordExist = ObjRGNBOL.RGNRecordIsExisT(ObjRGNPPT)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg48")
            'MsgBox("No Records Available!")
            Me.Cursor = Cursors.Arrow
        Else
            StrFrmName = "RGNReport"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
            Me.Cursor = Cursors.Arrow
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click

        If mdiparent.strMenuID = "M7" Then 'if ReturnGoodsNote Form
            DeleteRGNAddEdit()
        ElseIf mdiparent.strMenuID = "M16" Then 'if ReturnGoodsNote Approval Form
            DisplayInfoMessage("Msg36")
            'MessageBox.Show(" Record can not be Deleted in approval screen", " Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub DeleteRGNAddEdit()

        Dim strSTRGNGoodsNoteIdDel, STReturnGoodsDetailsIDDel As String
        Me.cmsRGNAddEdit.Visible = False
        Dim objRGN As New ReturnGoodsNotePPT
        Dim ds As New DataSet

        If dgRGN.Rows.Count > 0 Then
            If lblStatus.Text.ToUpper = "OPEN" Or lblStatus.Text.ToUpper = "REJECTED" Then
                If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("you are about to delete the selected record. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    If dgRGN.RowCount = 1 Then
                        DisplayInfoMessage("Msg38")
                        'MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
                        Exit Sub
                    End If
                    strSTRGNGoodsNoteIdDel = dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsNoteID").Value.ToString()
                    STReturnGoodsDetailsIDDel = dgRGN.SelectedRows(0).Cells("dgclSTReturnGoodsDetailsID").Value.ToString()
                    objRGN.STReturnGoodsNoteID = strSTRGNGoodsNoteIdDel
                    objRGN.STReturnGoodsDetailsID = STReturnGoodsDetailsIDDel

                    'If STReturnGoodsDetailsIDDel <> String.Empty Then
                    '    arlSTReturnGoodsDetailsIDDel.Add(STReturnGoodsDetailsIDDel)
                    'End If

                    'If STReturnGoodsDetailsIDDel <> String.Empty Then
                    '    If ReturnGoodsNoteBOL.STRGNDetailDelete(objRGN) = 1 Then
                    '        ' psSTReturnGoodsNoteID = objRGN.STReturnGoodsNoteID
                    '        ds = ReturnGoodsNoteBOL.STRGNDetailsGet(objRGN)
                    '        'If ds.Tables(0).Rows.Count > 0 Then
                    '        dtRGN = ds.Tables(0)
                    '        dgRGN.AutoGenerateColumns = False
                    '        dgRGN.DataSource = dtRGN
                    '        'End If

                    '        dgRGN.Refresh()
                    '        MessageBox.Show("Data deleted successfully")
                    '    Else
                    '        MessageBox.Show("Failed to delete data")
                    '    End If
                    'Else
                    '    dgRGN.Rows.Remove(dgRGN.CurrentRow)
                    '    MessageBox.Show("Data deleted successfully")
                    'End If

                    'bindviewrgn()
                    Dim Dr As DataRow
                    Dr = dtRGN.Rows.Item(dgRGN.CurrentRow.Index)
                    Dr.Delete()
                    dtRGN.AcceptChanges()

                    If objRGN.STReturnGoodsDetailsID <> String.Empty Then

                        If ReturnGoodsNoteBOL.STRGNDetailDelete(objRGN) = 1 Then
                            DisplayInfoMessage("Msg39")
                            'MessageBox.Show("Data deleted successfully")
                        Else
                            DisplayInfoMessage("Msg40")
                            'MessageBox.Show("Data operation failed")
                        End If

                    Else
                        DisplayInfoMessage("Msg41")
                        'MessageBox.Show("Data deleted successfully")
                    End If

                Else
                    Exit Sub
                End If
            Else
                DisplayInfoMessage("Msg42")
                'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            DisplayInfoMessage("Msg43")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub


    Private Sub ReturnGoodsNoteFrm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave

        'If arlSTReturnGoodsDetailsIDDel.Count > 0 Then
        '    If MsgBox("you are about to navigate away from the current page with out updating the record(s). are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        Exit Sub
        '        Me.Close()
        '    Else
        '        tbRGN.SelectedTab = tbpgRGN
        '        'DeleteDetailRecords()
        '    End If
        'End If

    End Sub


    'Private Function DeleteDetailRecords() As Integer
    '    Dim ds As New DataSet
    '    Dim dsRGNCount As Integer
    '    If arlSTReturnGoodsDetailsIDDel.Count > 0 Then
    '        Dim objRGNPPT As New ReturnGoodsNotePPT
    '        objRGNPPT.STReturnGoodsNoteID = psSTReturnGoodsNoteID
    '        For Each arToDel In arlSTReturnGoodsDetailsIDDel
    '            objRGNPPT.STReturnGoodsDetailsID = arToDel
    '            ds = ReturnGoodsNoteBOL.STRGNDetailDelete(objRGNPPT)
    '        Next
    '        dsRGNCount = ds.Tables(0).Rows(0).Item("Count")
    '    Else
    '        dsRGNCount = 1
    '    End If
    '    Return dsRGNCount
    'End Function

    'Private Sub tbRGN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRGN.SelectedIndexChanged

    '    If tbRGN.SelectedTab Is tbRGN.TabPages("tbpgView") Then

    '        If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '            BindViewRGN()
    '            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDate)
    '            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRGNDateSearch)
    '        Else
    '            tbRGN.SelectedTab = tbpgRGN
    '        End If

    '    ElseIf tbRGN.SelectedTab Is tbRGN.TabPages("tbpgRGN") Then

    '        ClearViewTabFields()
    '        ResetAll()
    '        EnableRGNIFNotApprovalMode()

    '    End If

    'End Sub

    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click

        RGNGrid_Edit()

    End Sub

    'Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click

    '    'If MsgBox("you are about to delete the whole record. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

    '    DeleteAllRGN()
    '    If bDelAllFlag = True Then
    '        ClearRGNStockDetails()
    '        ClearRGNHeader()
    '        psRGNSTIssueID = String.Empty
    '        psSTReturnGoodsNoteID = String.Empty
    '        toGetRGNNo()
    '        dtAddFlag = True
    '        '
    '        txtStockCode.Text = String.Empty
    '        'btnSaveAll.Text = "Save All"
    '        If GlobalPPT.strLang = "en" Then
    '            btnSaveAll.Text = "Save All"
    '        ElseIf GlobalPPT.strLang = "ms" Then
    '            btnSaveAll.Text = "Simpan Semua"
    '        End If

    '        'btnAdd.Text = "Add"
    '        If GlobalPPT.strLang = "en" Then
    '            btnAdd.Text = "Add"
    '        ElseIf GlobalPPT.strLang = "ms" Then
    '            btnAdd.Text = "Menambahkan"
    '        End If
    '        '
    '    End If

    'End Sub

    'Private Sub DeleteAllRGN()

    '    Me.cmsRGNAddEdit.Visible = False
    '    Dim objRGN As New ReturnGoodsNotePPT
    '    Dim ds As New DataSet
    '    If dgRGN.Rows.Count > 0 Then
    '        If lblStatus.Text.ToUpper = "OPEN" Or lblStatus.Text.ToUpper = "REJECTED" Then
    '            If MsgBox(rm.GetString("Msg44"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                'If MsgBox("You are about to Delete the whole record,this action can't be undone. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                objRGN.STReturnGoodsNoteID = psSTReturnGoodsNoteID
    '                ReturnGoodsNoteBOL.STRGNDelete(objRGN)
    '                DisplayInfoMessage("Msg45")
    '                'MessageBox.Show("Data Deleted Successfully")
    '                bDelAllFlag = True
    '            Else
    '                bDelAllFlag = False
    '            End If
    '        Else
    '            DisplayInfoMessage("Msg46")
    '            'MessageBox.Show("You can delete only OPEN/REJECTED Records ", " Record Can not be deleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Else
    '        DisplayInfoMessage("Msg47")
    '        'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If

    'End Sub



    'Private Sub ReturnGoodsNoteFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    '    If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '        Exit Sub
    '    Else

    '    End If

    'End Sub


    Private Sub ReturnGoodsNoteFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        'If dgRGN.RowCount > 0 Then

        '    If MsgBox(rm.GetString("Msg49"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '        SaveAll()
        '    End If

        'End If


    End Sub

    Private Sub txtReturnedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReturnedQty.TextChanged
        'If Val(txtReturnedQty.Text) > 0 Then
        '    txtReturnedQty.Text = Format(Val(txtReturnedQty.Text), "0")
        'End If

    End Sub

    Private Sub txtIssueQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssueQty.TextChanged
        If txtIssueQty.Text <> String.Empty Then
            txtIssueQty.Text = Format(Val(txtIssueQty.Text), "0")
        End If
    End Sub

    Private Sub chkViewRGNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewRGNDate.CheckedChanged

        If chkViewRGNDate.Checked = True Then
            dtpRGNDateSearch.Enabled = True
        Else
            dtpRGNDateSearch.Enabled = False
        End If
    End Sub

    Private Sub ReturnGoodsNoteFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If (dgRGN.RowCount > 0 And (lblStatus.Text = "OPEN" Or lblStatus.Text = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then

            If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False

            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M7"
                'mdiparent.lblMenuName.Text = "IPR"

            End If

        End If

    End Sub

End Class