Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
'Imports Common_DAL
Imports System.Data.SqlClient
Imports System.Math

Public Class EstateMillDeliveryNoteFrm

    'For Approval By Arulprakasan
    Public pdIDNDateVal As Date
    Public pdTransportDateVal As Date
    Public psAccountID As String = String.Empty
    Public psSupplierCOAID As String = String.Empty
    'For Approval By Arulprakasan
    Public lIPRNo As String = String.Empty
    Public lLPONo As String = String.Empty
    Public lSTIPRID As String = String.Empty
    Public lSTLPOID As String = String.Empty
    Public lSTIPRDetID As String = String.Empty
    Public lSTLPODetID As String = String.Empty
    Public lSupplierID As String = String.Empty
    Public lLPOSupplierID As String = String.Empty
    Public lLPOSupplierName As String = String.Empty
    Public lSupplierDesc As String = String.Empty
    '
    Public lT0ID As String = String.Empty
    Public lT1ID As String = String.Empty
    Public lT2ID As String = String.Empty
    Public lT3ID As String = String.Empty
    Public lT4ID As String = String.Empty

    Public lT0IDDesc As String = String.Empty
    '
    Public lSTEstMillDeliveryID As String = String.Empty
    Public lSTEstMillDeliveryIDMax As String = String.Empty
    Public lSTEstMillDeliveryDetID As String = String.Empty


    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim reDecimalPrice As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")
    Shadows mdiparent As New MDIParent
    Public Shared StrFrmName As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EstateMillDeliveryNoteFrm))
    Public Shared psSTEstMillDeliveryID As String = String.Empty
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty


    Private Sub EstateMillDeliveryNoteFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub EstateMillDeliveryNoteFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'For Approval By Arulprakasan

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem1, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        If mdiparent.strMenuID = "M14" Then
            DisbleFieldsInApprovalMode()
            'For Approval By Arulprakasan
            tcEMDN.SelectedTab = tbpgEMDNAdd
            tcEMDN.TabPages.Remove(tbpgEMDNView)

            SetUICulture(GlobalPPT.strLang)
        Else
            dtpIDNDate.Format = DateTimePickerFormat.Custom
            dtpIDNDate.CustomFormat = "dd/MM/yyyy"
            dtpTransportDate.Format = DateTimePickerFormat.Custom
            dtpTransportDate.CustomFormat = "dd/MM/yyyy"
            dtpviewIDNDate.Format = DateTimePickerFormat.Custom
            dtpviewIDNDate.CustomFormat = "dd/MM/yyyy"
            If lblStatusDesc.Text = "Rejected" Then
                lblRejectedReason.Visible = True
                txtRejectedReason.Visible = True
                'lblColon19.Visible = True
            Else
                lblRejectedReason.Visible = False
                txtRejectedReason.Visible = False
                ' lblColon19.Visible = False
            End If
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpIDNDate)
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpTransportDate)
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpviewIDNDate)
            btnAdd.Visible = False
            btnReset.Visible = False
            cbTransType.Text = cbTransType.Items(0)
            TransType_Change()
            cbviewStatus.Text = "OPEN"
            cbDeliveySource.Text = "OPEN"
            tcEMDN.SelectedTab = tbpgEMDNView
            'Me.tcIPR.SelectedTab = tabView
            rbtnIPR.Checked = True
            If rbtnLPONo.Checked = True Then
                Load_LPONo()
                'rbtnIPR.Checked = False
                cbviewIPRNo.DataSource = Nothing
            End If

            BindIDNViewDetails()
            SetUICulture(GlobalPPT.strLang)

            'ChkIPR.Checked = True
            'Load_IPRNo()
            'If ChkLPO.Checked = True Then
            '    Load_LPONo()
            '    ChkIPR.Checked = False
            '    cbviewIPRNo.DataSource = Nothing
            'End If
            'ElseIf ChkIPR.Checked = True Then
            '    Load_IPRNo()
            '    ChkLPO.Checked = False
            '    cbviewLPONo.DataSource = Nothing
            'End If
            'Load_PONo()
            lSTEstMillDeliveryID = String.Empty
            txtT0.Text = Helper.T0Default(0)
        End If
    End Sub

    Private Sub BindIDNViewDetails()

        dgvIDNView.DataSource = Nothing
        Dim dt As New DataTable
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL

        With objEMDNPPT
            If chkIDNDate.Checked = True Then
                ' .IDNDate = Format(Me.dtpviewIDNDate.Value, "MM/dd/yyyy")
                .IDNDate = dtpviewIDNDate.Value
            Else
                .IDNDate = Nothing
            End If

            If cbviewLPONo.Text = "--SELECT--" Then
                .LPONo = String.Empty
            Else
                .LPONo = cbviewLPONo.Text
            End If

            If cbviewIPRNo.Text = "--SELECT--" Then
                .IPRNo = String.Empty
            Else
                .IPRNo = cbviewIPRNo.Text
            End If

            .LPOorIPR = cbviewTransType.Text.Trim
            .IDNNO = txtviewIDNNo.Text.Trim
            .GRNNo = txtviewGRNNo.Text.Trim
            .PONo = txtviewPONo.Text.Trim
            If cbviewDeliverySource.Text = "SELECT ALL" Then
                .DeliverySource = ""
            Else
                .DeliverySource = cbviewDeliverySource.Text.Trim
            End If
            .SupplierID = txtviewSupplier.Text.Trim
            .Status = cbviewStatus.SelectedItem.ToString()

            If rbtnLPONo.Checked = True Then
                .Flag = "PO"
            Else
                .Flag = "PR"
            End If

        End With

        dt = objEMDNBOL.IDNView_Select(objEMDNPPT)

        If dt.Rows.Count > 0 Then
            dgvIDNView.AutoGenerateColumns = False
            dgvIDNView.DataSource = dt
        Else
            ClearGridView(dgvIDNView)
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        BindIDNViewDetails()

        If rbtnIPR.Checked = True Then
            cbviewIPRNo.Text = "--SELECT--"
        ElseIf rbtnLPONo.Checked = True Then
            cbviewLPONo.Text = "--SELECT--"
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EstateMillDeliveryNoteFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub btnSearchIPRNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchIPRNo.Click

        If cbTransType.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg01")
            'MessageBox.Show(" Please select Trans. Type ", " Trans. Type is empty ", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            Dim objIPRNo As New IPRNoLookup()
            objIPRNo.BindIPRNo()
            Dim result As DialogResult = IPRNoLookup.ShowDialog()
            If IPRNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
                lIPRNo = IPRNoLookup._lIPRNo.Trim
                lSTIPRID = IPRNoLookup._lSTIPRID
                lSTIPRDetID = IPRNoLookup._lSTIPRDetID
                txtIPRNo.Text = lIPRNo.Trim
                AddinDetails() ' To display IPR Details in IDN Detail Grid
                lSTLPOID = String.Empty ' to Clear STLPOID, to insert IPRNo
            End If
            'GlobalPPT.IsRetainFocus = True
        End If

    End Sub

    Private Sub txtIPRNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIPRNo.Leave
        If cbTransType.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg02")
            'MessageBox.Show(" Please select Trans. Type ", " Trans. Type is empty ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dt As New DataTable
            Dim objEMDNPPT As New EstateMillDeliveryNotePPT
            Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
            If txtIPRNo.Text <> String.Empty Then
                objEMDNPPT.IPRNo = txtIPRNo.Text.Trim
                dt = objEMDNBOL.SearchIPRNo(objEMDNPPT)
                If dt.Rows.Count <> 0 Then
                    lSTIPRID = dt.Rows(0).Item("STIPRID").ToString()
                    AddinDetails()
                Else
                    DisplayInfoMessage("Msg03")
                    'MessageBox.Show(" Invaild IPRNo.", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtIPRNo.Text = String.Empty
                    txtIPRNo.Focus()
                    ClearGridView(dgvDetails)
                End If
            End If
        End If
    End Sub

    Private Sub txtLPONo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLPONo.Leave

        If cbTransType.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg04")
            'MessageBox.Show(" Please select Trans. Type ", " Trans. Type is empty ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dt As New DataTable
            Dim objEMDNPPT As New EstateMillDeliveryNotePPT
            Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
            If txtLPONo.Text <> String.Empty Then
                objEMDNPPT.LPONo = txtLPONo.Text.Trim
                dt = objEMDNBOL.SearchLPONo(objEMDNPPT)
                If dt.Rows.Count <> 0 Then
                    lSTLPOID = dt.Rows(0).Item("STLPOID").ToString()
                    'lLPOSupplierName = dt.Rows(0).Item("SupplierName")
                    AddLPOinIDNDetails()
                Else
                    DisplayInfoMessage("Msg05")
                    'MessageBox.Show(" Invaild LPONo.", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtLPONo.Text = String.Empty
                    txtLPONo.Focus()
                    ClearGridView(dgvDetails)
                End If
                GlobalPPT.IsRetainFocus = True
            End If

        End If

    End Sub

    Private Sub btnSearchLPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLPONo.Click

        Dim objLPONo As New LPONoLookup()
        objLPONo.BindLPONo()
        Dim result As DialogResult = LPONoLookup.ShowDialog()
        If LPONoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lLPONo = LPONoLookup._lLPONo.Trim
            lSTLPOID = LPONoLookup._lSTLPOID
            lSTLPODetID = LPONoLookup._lSTLPODetID
            lLPOSupplierID = LPONoLookup._lSTLPOSupplierID
            txtSupplier.Text = LPONoLookup._lSTLPOSupplierName
            'lLPOSupplierName = LPONoLookup._lSTLPOSupplierName
            txtLPONo.Text = lLPONo.Trim
            AddLPOinIDNDetails()
            lSTIPRID = String.Empty 'to clear STIPRID  

            'GlobalPPT.IsRetainFocus = True
        End If

    End Sub

    Public Sub AddLPOinIDNDetails()
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        With objEMDNPPT
            .LPONo = LPONoLookup._lLPONo.Trim
            .STLPOID = lSTLPOID 'LPONoLookup._lSTLPOID
        End With
        dt = objEMDNBOL.GetIDNDetails_IPR(objEMDNPPT)
        If dt.Rows.Count <> 0 Then
            dgvDetails.AutoGenerateColumns = False
            dgvDetails.DataSource = dt

        Else
            dgvDetails.DataSource = Nothing
        End If
    End Sub

    Public Sub AddinDetails()
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        With objEMDNPPT
            .IPRNo = IPRNoLookup._lIPRNo.Trim
            .STIPRID = lSTIPRID 'IPRNoLookup._lSTIPRID 
        End With
        dt = objEMDNBOL.GetIDNDetails_IPR(objEMDNPPT)
        If dt.Rows.Count <> 0 Then
            dgvDetails.AutoGenerateColumns = False
            dgvDetails.DataSource = dt

        Else
            dgvDetails.DataSource = Nothing
        End If
    End Sub

    Public Function valid()

        If txtT0.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg64")
            'MessageBox.Show(" Please enter T0 ", " T0 is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtT0.Focus()
            txtT0.Text = String.Empty
            Return False
        End If

        If txtReceivedQty.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg06")
            'MessageBox.Show(" Please enter Received Qty ", " Receiv. Qty is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReceivedQty.Focus()
            txtReceivedQty.Text = "0"
            Return False
        End If

        If txtReceivedQty.Text.Trim() <> String.Empty And txtPendingQty.Text.Trim() <> String.Empty Then
            If CDbl(txtReceivedQty.Text.Trim()) > CDbl(txtPendingQty.Text.Trim()) Then
                DisplayInfoMessage("Msg07")
                'MessageBox.Show(" Please check Receiv. Qty greater than Pending Qty", " Receiv. Qty greater than Pending Qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtReceivedQty.Focus()
                Return False
            End If
        End If

        If txtUnit.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg08")
            'MessageBox.Show(" Please enter Unit value ", " Unit is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUnit.Focus()
            Return False
        End If

        If txtReceivedPrice.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg09")
            'MessageBox.Show(" Please enter Received price ", " Received price is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtReceivedPrice.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click


        If Not valid() Then Exit Sub

        dgvDetails.SelectedRows(0).Cells("dgclT0").Value = txtT0.Text.Trim

        If txtT0.Text.Trim <> String.Empty Then
            dgvDetails.SelectedRows(0).Cells("dgclTAnalysisID").Value = lT0ID
        Else
            lT0ID = String.Empty
            dgvDetails.SelectedRows(0).Cells("dgclTAnalysisID").Value = String.Empty
        End If

        'dgvDetails.SelectedRows(0).Cells("dgclUnit").Value = txtUnit.Text


        If txtUnit.Text.Trim = String.Empty Then
            MessageBox.Show("Unit should not be empty")
            Exit Sub
        Else
            dgvDetails.SelectedRows(0).Cells("dgclUnit").Value = txtUnit.Text.Trim
        End If

        'dgvDetails.SelectedRows(0).Cells("dgclReceivedPrice").Value = txtReceivedPrice.Text

        If txtReceivedPrice.Text.Trim <> String.Empty Then
            If CDbl(txtReceivedPrice.Text.Trim = 0.0) Then
                MessageBox.Show("Unit Price should be greater than zero")
                Exit Sub
            Else
                dgvDetails.SelectedRows(0).Cells("dgclReceivedPrice").Value = txtReceivedPrice.Text.Trim
            End If

            If txtReceivedQty.Text.Trim <> String.Empty Then
                'If CDbl(txtReceivedQty.Text.Trim = 0.0) Then
                '    MessageBox.Show("Quantity Should be greater than zero")
                '    Exit Sub
                'Else
                dgvDetails.SelectedRows(0).Cells("dgclReceivedQty").Value = txtReceivedQty.Text.Trim
            End If
        End If

            Dim TotalPrice, DifferenceQty As Double
            TotalPrice = (CDbl(txtReceivedQty.Text.Trim)) * (CDbl(txtReceivedPrice.Text.Trim))
            DifferenceQty = (CDbl(txtPendingQty.Text.Trim)) - (CDbl(txtReceivedQty.Text.Trim))
            'Dim str As String = DifferenceQty.ToString()
            dgvDetails.SelectedRows(0).Cells("dgclTotalPrice").Value = TotalPrice
            dgvDetails.SelectedRows(0).Cells("dgclDifferenceQty").Value = DifferenceQty
            btnAdd.Visible = False
            btnReset.Visible = False
            Reset()
            'GlobalPPT.IsRetainFocus = True

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If (dgvDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED") And mdiparent.strMenuID = "M4" And btnSaveAll.Enabled = True) Then
            If MsgBox(rm.GetString("Msg66"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

    Private Function ISFormValid()

        If cbTransType.Text.Trim = "PO" Then

            If txtLPONo.Text.Trim = String.Empty Then
                ' If txtSupplier.Text = String.Empty Then
                DisplayInfoMessage("Msg10")
                'MessageBox.Show(" Please enter LPO ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtLPONo.Focus()
                Return False
                'End If
            End If

        ElseIf cbTransType.Text.Trim = "PR" Then

            If txtIDNNo.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg11")
                'MessageBox.Show(" Please enter IDNNo.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIDNNo.Focus()
                Return False
            End If

            If txtSupplier.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg12")
                'MessageBox.Show(" Please enter Supplier ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSupplier.Focus()
                Return False
            End If

        End If

        'If dtpIDNDate.Value.Month.ToString() <> Format(System.DateTime.Today.Month).ToString() Then
        '    MessageBox.Show(" Please Select IPRDate in Current Month", " IPRDate not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        'If dtpTransportDate.Value.Month.ToString() <> Format(System.DateTime.Today.Month).ToString() Then
        '    MessageBox.Show(" Please Select TransportDate in Current Month", " TransportDate not Correct", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        ''If txtGRNNo.Text.Trim = String.Empty Then
        ''    MessageBox.Show(" Please enter GRN No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    txtGRNNo.Focus()
        ''    Return False
        ''End If

        If txtIPRNo.Text.Trim = String.Empty Then

            If txtLPONo.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg13")
                'MessageBox.Show(" Please select either IPR No. or LPO No.", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIPRNo.Focus()
                Return False
            End If

        End If

        'If cbTransType.Text.Trim = "PR" Then

        '    If cbDeliveySource.SelectedItem = String.Empty Then
        '        DisplayInfoMessage("Msg14")
        '        'MessageBox.Show(" Please select Delivery Source", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return False
        '    End If

        'End If

        If dgvDetails.Rows.Count < 1 Then
            DisplayInfoMessage("Msg15")
            'MessageBox.Show(" Please fill details for IPRNo. or LPO No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        For Each DataGridViewRow In dgvDetails.Rows

            If DataGridViewRow.Cells("dgclTAnalysisID").Value Is Nothing Then
                DisplayInfoMessage("Msg64")
                Return False
            End If

            If DataGridViewRow.Cells("dgclUnit").Value Is Nothing Then
                DisplayInfoMessage("Msg08")
                Return False
            End If

            'If DataGridViewRow.Cells("dgclReceivedQty").Value = 0 Then
            '    DisplayInfoMessage("Msg06")
            '    Return False
            'End If

            If DataGridViewRow.Cells("dgclReceivedPrice").Value = 0 Then
                DisplayInfoMessage("Msg09")
                Return False
            End If

        Next

        'If txtReceivedQty.Text = String.Empty Then
        '    DisplayInfoMessage("Msg06")
        '    'MessageBox.Show(" Please enter Received Qty ", " Receiv. Qty is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtReceivedQty.Focus()
        '    txtReceivedQty.Text = String.Empty
        '    Return False
        'End If

        'If txtReceivedQty.Text.Trim() <> String.Empty And txtPendingQty.Text.Trim() <> String.Empty Then
        '    If CDbl(txtReceivedQty.Text.Trim()) > CDbl(txtPendingQty.Text.Trim()) Then
        '        DisplayInfoMessage("Msg07")
        '        'MessageBox.Show(" Please check Receiv. Qty greater than Pending Qty", " Receiv. Qty greater than Pending Qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtReceivedQty.Focus()
        '        Return False
        '    End If
        'End If

        'If txtUnit.Text = String.Empty Then
        '    DisplayInfoMessage("Msg08")
        '    'MessageBox.Show(" Please enter Unit value ", " Unit is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtUnit.Focus()
        '    Return False
        'End If

        'If txtReceivedPrice.Text = String.Empty Then
        '    DisplayInfoMessage("Msg09")
        '    'MessageBox.Show(" Please enter Received price ", " Received price is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtReceivedPrice.Focus()
        '    Return False
        'End If

        'If txtT0.Text.Trim = String.Empty Then
        '    DisplayInfoMessage("Msg06")
        '    'MessageBox.Show(" Please enter T0 ", "T0 is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtT0.Focus()
        '    txtT0.Text = String.Empty
        '    Return False
        'End If


        Return True

    End Function

    Private Function StockDetailConsignmentQtyCheck()

        Dim objEMDNPPT As New EstateMillDeliveryNotePPT


        Dim liStockDetailCongignmentBalQty As Double = 0.0
        Dim liEMDNReceivedQty As Double = 0.0

        For Each DataGridViewRow In dgvDetails.Rows

            objEMDNPPT.StockID = DataGridViewRow.Cells("dgclStockID").Value 'dgclStockCode
            objEMDNPPT.StockCode = DataGridViewRow.Cells("dgclStockCode").Value '
            If DataGridViewRow.Cells("dgclReceivedQty").Value.ToString <> String.Empty Then
                liEMDNReceivedQty = DataGridViewRow.Cells("dgclReceivedQty").Value
            Else
                liEMDNReceivedQty = 0.0

            End If


            liStockDetailCongignmentBalQty = EstateMillDeliverNoteApprovalBOL.StockDetailConsignmentQtyCheck(objEMDNPPT)

            If Not liEMDNReceivedQty <= liStockDetailCongignmentBalQty Then
                MessageBox.Show("There is no enough stock items in stock consignment for this stock code " + objEMDNPPT.StockCode)
                Return False
            End If
        Next

        Return True

    End Function

    Private Sub SaveAll()

        If Not ISFormValid() Then Exit Sub

        If cbTransType.Text.Trim = "PR" And cbDeliveySource.Text.Trim = "Consignment" Then

            If StockDetailConsignmentQtyCheck() = False Then
                Exit Sub
            End If
        End If


        Dim rowsAffected As Integer = 0
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim DataGridViewRow As New DataGridViewRow
        Dim dt As DataTable
        Dim IDNCount As Integer
        Dim stock As Integer
        Dim str As String
        With objEMDNPPT
            'If txtIPRNo.Text = String.Empty Then
            If cbTransType.Text = "PO" Then
                str = txtLPONo.Text.Trim
                .LPONo = cbTransType.Text.Trim  'Commented for transaction Type error"str.Substring(0, 3)" on 13/1/10 by Dharshini &Co


                If lLPOSupplierID.Trim <> String.Empty Then
                    .SupplierID = String.Empty 'LPOSupplierID issue in this
                Else
                    'MessageBox.Show("LPO SupplierID Missing")
                    'Exit Sub
                End If
            Else
                str = txtIPRNo.Text.Trim
                .IPRNo = cbTransType.Text.Trim  'Commented for transaction Type error"str.Substring(0, 3)" on 13/1/10 by Dharshini &Co
                If lSupplierID.Trim <> String.Empty Then
                    .SupplierID = lSupplierID.Trim  'IPRSupplierID
                Else
                    'MessageBox.Show("IPR SupplierID Missing")
                    DisplayInfoMessage("Msg62")
                    Exit Sub
                End If
            End If
            .IDNNO = txtIDNNo.Text.Trim
            .STIPRID = lSTIPRID.Trim
            .STLPOID = lSTLPOID.Trim
            '.IDNDate = Format(dtpIDNDate.Value, "MM/dd/yyyy")
            .IDNDate = dtpIDNDate.Value
            .GRNNo = txtGRNNo.Text.Trim
            .PONo = txtPONo.Text.Trim
            'If cbDeliveySource.Enabled = True Then
            '    .DeliverySource = cbDeliveySource.SelectedItem.ToString()
            'Else
            '    .DeliverySource = String.Empty
            'End If
            .Status = "OPEN"
            .Remarks = txtRemarks.Text.Trim
            .RejectedReason = txtRejectedReason.Text.Trim
            .OperatorName = txtOperatorName.Text.Trim
            .VehicleNo = txtVehicleNo.Text.Trim
            ' .TransportDate = Format(dtpTransportDate.Value, "MM/dd/yyyy")
            .TransportDate = dtpTransportDate.Value
            .STEstMillDeliveryID = lSTEstMillDeliveryID.Trim
        End With

        If lSTEstMillDeliveryID = "" Then
            If txtIDNNo.Text.Trim <> String.Empty Then
                dt = objEMDNBOL.IDN_isExist(objEMDNPPT) 'for Validation process IDN No. and GRN No. is exists
                If dt.Rows.Count <> 0 Then
                    IDNCount = dt.Rows(0).Item("IDNCount")
                    If IDNCount > 0 Then
                        DisplayInfoMessage("Msg16")
                        'MessageBox.Show("IDN No. or GRN No. already exist, Please check")
                        Exit Sub
                    Else
                        dt = objEMDNBOL.Save_STMillDelivery(objEMDNPPT) 'Saving Prosses
                        If dt.Rows.Count <> 0 Then
                            lSTEstMillDeliveryID = dt.Rows(0).Item("STEstMillDeliveryID").ToString()
                        Else
                            DisplayInfoMessage("Msg17")
                            'MessageBox.Show("Failed, to insert Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            objEMDNBOL.Delete_STMillDeliveryDelete(objEMDNPPT)
                            Exit Sub
                        End If
                    End If
                End If
            Else
                dt = objEMDNBOL.Save_STMillDelivery(objEMDNPPT) 'Saving Prosses
                If dt.Rows.Count <> 0 Then
                    lSTEstMillDeliveryID = dt.Rows(0).Item("STEstMillDeliveryID").ToString()
                Else
                    DisplayInfoMessage("Msg18")
                    'MessageBox.Show("Failed, to insert Records", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    objEMDNBOL.Delete_STMillDeliveryDelete(objEMDNPPT)
                    Exit Sub
                End If
            End If
        Else
            rowsAffected = objEMDNBOL.Update_STMillDelivery(objEMDNPPT) 'Update Prosses
            If rowsAffected = 1 Then
            Else
                DisplayInfoMessage("Msg19")
                'MessageBox.Show("Failed to update Records", "Error occured in updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        For Each DataGridViewRow In dgvDetails.Rows
            With objEMDNPPT
                If cbTransType.Text.Trim = "PR" Then
                    .STIPRDetID = DataGridViewRow.Cells("dgclSTIPRDetID").Value.ToString()  'lSTIPRDetID
                Else
                    .STLPODetID = DataGridViewRow.Cells("dgclSTLPODetID").Value.ToString() 'lSTLPODetID
                End If
                .StockID = DataGridViewRow.Cells("dgclStockID").Value.Trim
                .PartNo = IIf(DataGridViewRow.Cells("dgclPartNo").Value Is DBNull.Value, String.Empty, DataGridViewRow.Cells("dgclPartNo").Value)
                .COAID = DataGridViewRow.Cells("dgclCOAID").Value
                .AvailQty = DataGridViewRow.Cells("dgclAvailableQty").Value
                .UnitPrice = DataGridViewRow.Cells("dgclUnitPrice").Value
                If Not DataGridViewRow.Cells("dgclTAnalysisID").Value Is Nothing Then
                    .T0 = DataGridViewRow.Cells("dgclTAnalysisID").Value.ToString()
                Else
                    .T0 = String.Empty
                End If
                .RequestedQty = DataGridViewRow.Cells("dgclRequestedQty").Value
                .PendingQty = DataGridViewRow.Cells("dgclPendingQty").Value
                .ReceivedQty = DataGridViewRow.Cells("dgclReceivedQty").Value
                .ReceivedPrice = DataGridViewRow.Cells("dgclReceivedPrice").Value
                .TotalPrice = DataGridViewRow.Cells("dgclTotalPrice").Value
                .STEstMillDeliveryID = lSTEstMillDeliveryID ' to check stockcode isexists or not in STEstMillDeliveryDet
                .STEstMillDeliveryDetID = DataGridViewRow.Cells("dgclSTEstMillDelivDetID").Value
            End With

            dt = objEMDNBOL.Stock_isExist(objEMDNPPT)
            If dt.Rows.Count <> 0 Then
                stock = dt.Rows(0).Item("Count")
                If stock > 0 And objEMDNPPT.STEstMillDeliveryDetID = "" Then
                    DisplayInfoMessage("Msg20")
                    'MessageBox.Show("Stock Code Already Exist, Please check")
                    Exit Sub
                Else
                    If objEMDNPPT.STEstMillDeliveryDetID = "" Then
                        rowsAffected = objEMDNBOL.Save_EstMillDeliveryDet(objEMDNPPT)
                        'MessageBox.Show("Records inserted succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        rowsAffected = objEMDNBOL.Update_EstMillDeliveryDet(objEMDNPPT)
                        'MessageBox.Show("Records updated succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Next
        If rowsAffected = 1 Then
            If objEMDNPPT.STEstMillDeliveryDetID = "" Then
                DisplayInfoMessage("Msg21")
                'MessageBox.Show("Records inserted Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DisplayInfoMessage("Msg22")
                'MessageBox.Show("Records updated Succesfully", " Information ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("Msg23")
            'MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            objEMDNBOL.Delete_STMillDeliveryDelete(objEMDNPPT)
            Exit Sub
        End If
        ResetAll()
        BindIDNViewDetails()

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveAll()

    End Sub

    Private Sub ResetAll()

        Reset()
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If

        lSTEstMillDeliveryID = ""
        dtpIDNDate.Format = DateTimePickerFormat.Custom
        dtpIDNDate.CustomFormat = "dd/MM/yyyy"
        dtpTransportDate.Format = DateTimePickerFormat.Custom
        dtpTransportDate.CustomFormat = "dd/MM/yyyy"
        ClearGridView(dgvDetails)
        txtIDNNo.Text = String.Empty
        txtGRNNo.Text = String.Empty
        txtIPRNo.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtPONo.Text = String.Empty
        txtLPONo.Text = String.Empty
        cbDeliveySource.Text = String.Empty
        txtSupplier.Text = String.Empty
        txtRejectedReason.Text = String.Empty
        txtOperatorName.Text = String.Empty
        txtVehicleNo.Text = String.Empty
        btnAdd.Visible = False
        btnReset.Visible = False
        lblStatusDesc.Text = "OPEN"
        lSTIPRID = String.Empty
        lSTLPOID = String.Empty
        lSupplierID = String.Empty
        lLPOSupplierID = String.Empty
    End Sub

    Private Sub Edit_Details()
        If dgvDetails.Rows.Count > 0 Then
            txtStockCode.Text = dgvDetails.SelectedRows(0).Cells("dgclStockCode").Value.ToString()
            txtStockDesc.Text = dgvDetails.SelectedRows(0).Cells("dgclStockDesc").Value.ToString()
            txtPendingQty.Text = dgvDetails.SelectedRows(0).Cells("dgclPendingQty").Value.ToString()
            If Not dgvDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString() Is DBNull.Value Then
                txtAvailableQty.Text = dgvDetails.SelectedRows(0).Cells("dgclAvailableQty").Value.ToString()
            End If
            txtReceivedQty.Text = dgvDetails.SelectedRows(0).Cells("dgclReceivedQty").Value.ToString()
            txtUnit.Text = dgvDetails.SelectedRows(0).Cells("dgclUnit").Value.ToString()
            txtReceivedPrice.Text = dgvDetails.SelectedRows(0).Cells("dgclReceivedPrice").Value.ToString()
            If Not dgvDetails.SelectedRows(0).Cells("dgclT0").Value Is Nothing Then
                If dgvDetails.SelectedRows(0).Cells("dgclT0").Value.ToString() <> "" Then
                    txtT0.Text = dgvDetails.SelectedRows(0).Cells("dgclT0").Value.ToString()
                End If
            End If
            If Not dgvDetails.SelectedRows(0).Cells("dgclTAnalysisID").Value Is Nothing Then
                lT0ID = dgvDetails.SelectedRows(0).Cells("dgclTAnalysisID").Value.ToString()
            End If
            'btnAdd.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
            txtReceivedQty.Focus()
        Else
            DisplayInfoMessage("Msg24")
            'MessageBox.Show(" Please check no rows selected", "  ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgvDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellDoubleClick
        Edit_Details()
        txtT0.Focus()
        btnAdd.Visible = True
        btnReset.Visible = True
    End Sub

    Private Sub dgvDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetails.KeyDown
        If e.KeyCode = Keys.Return Then
            Edit_Details()
            txtT0.Focus()
            btnAdd.Visible = True
            btnReset.Visible = True
            e.Handled = True
        End If
    End Sub

    'Private Sub cbTransType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTransType.SelectedIndexChanged
    '    TransType_Change()
    '    ClearGridView(dgvDetails)
    'End Sub

    Private Sub cbTransType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTransType.SelectedIndexChanged

        TransType_Change()
        ClearGridView(dgvDetails)

    End Sub

    Private Sub TransType_Change()

        If cbTransType.SelectedItem = "PR" Then


            txtIDNNo.ReadOnly = False
            txtGRNNo.ReadOnly = False

            txtLPONo.Enabled = False
            btnSearchLPONo.Enabled = False
            txtIPRNo.Enabled = True
            btnSearchIPRNo.Enabled = True
            cbDeliveySource.Enabled = True
            txtSupplier.Enabled = True
            btnSearchSupplier.Enabled = True
            lblIDNNo.ForeColor = Color.Red

        Else

            txtIDNNo.Text = String.Empty
            txtGRNNo.Text = String.Empty

            txtIDNNo.ReadOnly = False
            txtGRNNo.ReadOnly = True
            lblIDNNo.ForeColor = Color.Red
            txtLPONo.Enabled = True
            btnSearchLPONo.Enabled = True
            txtIPRNo.Enabled = False
            btnSearchIPRNo.Enabled = False
            cbDeliveySource.Enabled = False
            txtSupplier.Enabled = False
            btnSearchSupplier.Enabled = False
            txtIPRNo.Text = String.Empty
            cbDeliveySource.Text = String.Empty
            txtSupplier.Text = String.Empty
            'lblIDNNo.ForeColor = Color.Black

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
                'If grdname.Rows.Count - 1 Then
                '    grdname.Rows.RemoveAt(0)
                'End If
            Next
        End If

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EstateMillDeliveryNoteFrm))

        'set the culture as per the selection and 
        'load the appropriate strings for button, label, etc.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

        If mdiparent.strMenuID = "M14" Then
            tcEMDN.TabPages("tbpgEMDNAdd").Text = rm.GetString("tcIPR.TabPages(tbpgEMDNAdd).Text")
        Else
            tcEMDN.TabPages("tbpgEMDNAdd").Text = rm.GetString("tcIPR.TabPages(tbpgEMDNAdd).Text")
            tcEMDN.TabPages("tbpgEMDNView").Text = rm.GetString("tcIPR.TabPages(tbpgEMDNView).Text")
        End If

        lblTransType.Text = rm.GetString("lblTransType.Text")
        lblIDNNo.Text = rm.GetString("lblIDNNo.Text")
        lblGRNNo.Text = rm.GetString("lblGRNNo.Text")
        lblIPRNo.Text = rm.GetString("lblIPRNo.Text")
        lblIDNDate.Text = rm.GetString("lblIDNDate.Text")
        lblPONo.Text = rm.GetString("lblPONo.Text")
        lblLPONo.Text = rm.GetString("lblLPONo.Text")
        lblDeliverySource.Text = rm.GetString("lblDeliverySource.Text")
        lblSupplier.Text = rm.GetString("lblSupplier.Text")
        lblStatus.Text = rm.GetString("lblStatus.Text")
        lblRemarks.Text = rm.GetString("lblRemarks.Text")
        lblOperatorName.Text = rm.GetString("lblOperatorName.Text")
        lblTransportDate.Text = rm.GetString("lblTransportDate.Text")
        lblVehicleNo.Text = rm.GetString("lblVehicleNo.Text")
        btnAdd.Text = rm.GetString("btnAdd.Text")
        btnReset.Text = rm.GetString("btnReset.Text")
        btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
        btnResetAll.Text = rm.GetString("btnResetAll.Text")
        btnClose.Text = rm.GetString("btnClose.Text")
        gbMain.Text = rm.GetString("gbMain.Text")
        gbEdit.Text = rm.GetString("gbEdit.Text")
        gbDetails.Text = rm.GetString("gbDetails.Text")


        lblStockCode.Text = rm.GetString("lblStockCode.Text")
        lblStockDesc.Text = rm.GetString("lblStockDesc.Text")
        lblPendingQty.Text = rm.GetString("lblPendingQty.Text")
        lblAvailableQty.Text = rm.GetString("lblAvailableQty.Text")
        lblT0.Text = rm.GetString("lblT0.Text")
        lblReceivedQty.Text = rm.GetString("lblReceivedQty.Text")
        lblUnit.Text = rm.GetString("lblUnit.Text")
        lblReceivedPrice.Text = rm.GetString("lblReceivedPrice.Text")

        dgvDetails.Columns("dgclStockCode").HeaderText = rm.GetString("dgvDetails.Columns(dgclStockCode).HeaderText")
        dgvDetails.Columns("dgclStockDesc").HeaderText = rm.GetString("dgvDetails.Columns(dgclStockDesc).HeaderText")
        dgvDetails.Columns("dgclPartNo").HeaderText = rm.GetString("dgvDetails.Columns(dgclPartNo).HeaderText")
        dgvDetails.Columns("dgclAccountCode").HeaderText = rm.GetString("dgvDetails.Columns(dgclAccountCode).HeaderText")
        dgvDetails.Columns("dgclAccountDesc").HeaderText = rm.GetString("dgvDetails.Columns(dgclAccountDesc).HeaderText")
        dgvDetails.Columns("dgclRequestedQty").HeaderText = rm.GetString("dgvDetails.Columns(dgclRequestedQty).HeaderText")
        dgvDetails.Columns("dgclAvailableQty").HeaderText = rm.GetString("dgvDetails.Columns(dgclAvailableQty).HeaderText")
        dgvDetails.Columns("dgclUnitPrice").HeaderText = rm.GetString("dgvDetails.Columns(dgclUnitPrice).HeaderText")
        dgvDetails.Columns("dgclPendingQty").HeaderText = rm.GetString("dgvDetails.Columns(dgclPendingQty).HeaderText")
        dgvDetails.Columns("dgclReceivedQty").HeaderText = rm.GetString("dgvDetails.Columns(dgclReceivedQty).HeaderText")
        dgvDetails.Columns("dgclT0").HeaderText = rm.GetString("dgvDetails.Columns(dgclT0).HeaderText")
        dgvDetails.Columns("dgclUnit").HeaderText = rm.GetString("dgvDetails.Columns(dgclUnit).HeaderText")
        dgvDetails.Columns("dgclReceivedPrice").HeaderText = rm.GetString("dgvDetails.Columns(dgclReceivedPrice).HeaderText")
        dgvDetails.Columns("dgclTotalPrice").HeaderText = rm.GetString("dgvDetails.Columns(dgclTotalPrice).HeaderText")
        dgvDetails.Columns("dgclDifferenceQty").HeaderText = rm.GetString("dgvDetails.Columns(dgclDifferenceQty).HeaderText")

        lblviewTransType.Text = rm.GetString("lblviewTransType.Text")
        lblviewIDNNo.Text = rm.GetString("lblviewIDNNo.Text")
        lblviewGRNNo.Text = rm.GetString("lblviewGRNNo.Text")
        rbtnIPR.Text = rm.GetString("rbtnIPR.Text")
        lblviewIDNDate.Text = rm.GetString("lblviewIDNDate.Text")
        lblviewPONo.Text = rm.GetString("lblviewPONo.Text")
        rbtnLPONo.Text = rm.GetString("rbtnLPONo.Text")
        lblviewDeliverySource.Text = rm.GetString("lblviewDeliverySource.Text")
        lblviewSupplier.Text = rm.GetString("lblviewSupplier.Text")
        lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
        btnSearch.Text = rm.GetString("btnSearch.Text")
        btnviewReport.Text = rm.GetString("btnviewReport.Text")
        plEMDNSearch.Text = rm.GetString("plEMDNSearch.Text")
        lblsearchBy.Text = rm.GetString("lblsearchBy.Text")

        dgvIDNView.Columns("dgclIDNDate").HeaderText = rm.GetString("dgvIDNView.Columns(dgclIDNDate).HeaderText")
        dgvIDNView.Columns("dgclTransType").HeaderText = rm.GetString("dgvIDNView.Columns(dgclTransType).HeaderText")
        dgvIDNView.Columns("dgclIDNNo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclIDNNo).HeaderText")
        dgvIDNView.Columns("dgclGRNNo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclGRNNo).HeaderText")
        dgvIDNView.Columns("dgclIPRNo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclIPRNo).HeaderText")
        dgvIDNView.Columns("dgclLPONo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclLPONo).HeaderText")
        dgvIDNView.Columns("dgclPONo").HeaderText = rm.GetString("dgvIDNView.Columns(dgclPONo).HeaderText")
        dgvIDNView.Columns("dgclDeliverySource").HeaderText = rm.GetString("dgvIDNView.Columns(dgclDeliverySource).HeaderText")
        dgvIDNView.Columns("dgclSupplier").HeaderText = rm.GetString("dgvIDNView.Columns(dgclSupplier).HeaderText")
        dgvIDNView.Columns("dgclStatus").HeaderText = rm.GetString("dgvIDNView.Columns(dgclStatus).HeaderText")



        'display a message if the culture is not supported
        'try passing bn (Bengali) for testing
        'MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnSearchSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSupplier.Click
        If cbTransType.Text = String.Empty Then
            DisplayInfoMessage("Msg25")
            'MessageBox.Show(" Please select Trans. Type ", " Trans. Type is empty ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim objIPRNo As New SupplierLookup()
            objIPRNo.BindSupplier()
            Dim result As DialogResult = SupplierLookup.ShowDialog()
            If SupplierLookup.DialogResult = Windows.Forms.DialogResult.OK Then
                lSupplierID = SupplierLookup._lSupplierID
                lSupplierDesc = SupplierLookup._lSupplierDesc.Trim
                txtSupplier.Text = lSupplierDesc
            End If
        End If
    End Sub

    Private Sub btnT0Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnT0Search.Click
        Dim T0 As New Tlookup()
        Tlookup.strTcodeDecide = "T0"
        T0.BindTLookup()
        Dim Result As DialogResult = Tlookup.ShowDialog()
        If Tlookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lT0ID = Tlookup.strTId
            lT0IDDesc = Tlookup.strTValue.Trim
            txtT0.Text = lT0IDDesc.Trim
        End If
    End Sub

    Private Sub Reset()
        txtStockCode.Text = String.Empty
        txtStockDesc.Text = String.Empty
        txtPendingQty.Text = String.Empty
        'txtReceivedQty.Text = String.Empty
        txtAvailableQty.Text = String.Empty
        txtReceivedPrice.Text = String.Empty
        txtUnit.Text = String.Empty
        'txtT0.Text = String.Empty
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click

        Edit_Details()
        txtT0.Focus()
        btnAdd.Visible = True
        btnReset.Visible = True

    End Sub

    Private Sub dgvDetails_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvDetails.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvDetails.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvDetails.ClearSelection()
                    Me.dgvDetails.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvIDNView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIDNView.CellDoubleClick

        EditViewGridRecord()

    End Sub
    Private Sub EditViewGridRecord()

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem1, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditUpdateToolStripMenuItem1.Enabled = True Then
                '
                'If dgvIDNView.RowCount > 0 And dgvIDNView.SelectedRows(0).Cells("dgclStatus").Value <> "OPEN" And dgvIDNView.SelectedRows(0).Cells("dgclStatus").Value <> "REJECTED" Then
                If dgvIDNView.RowCount > 0 Then
                    If dgvIDNView.SelectedRows(0).Cells("dgclStatus").Value <> "OPEN" Then 'And dgvIDNView.SelectedRows(0).Cells("dgclStatus").Value <> "REJECTED" Then
                        Reset()
                        EMDNView_Edit()
                        DisbleFieldsInEntry()
                        grpApproval.Visible = False
                    Else
                        Reset()
                        EMDNView_Edit()
                        EnableFieldsInEntry()
                        'TransType_Change()
                    End If
                End If
                '
            End If
        End If
    End Sub
    Private Sub DisbleFieldsInEntry()
        cbTransType.Enabled = False
        txtIDNNo.ReadOnly = True
        txtGRNNo.ReadOnly = True
        txtIPRNo.ReadOnly = True
        btnSearchIPRNo.Enabled = False
        txtRemarks.ReadOnly = True
        txtOperatorName.ReadOnly = True
        dtpTransportDate.Enabled = False
        txtVehicleNo.ReadOnly = True
        dtpIDNDate.Enabled = False
        txtPONo.ReadOnly = True
        txtLPONo.ReadOnly = True
        btnSearchLPONo.Enabled = False
        BtnVehicle.Enabled = False
        cbDeliveySource.Enabled = False
        txtSupplier.ReadOnly = True
        btnSearchSupplier.Enabled = False
        txtStockCode.ReadOnly = True
        txtStockDesc.ReadOnly = True
        txtPendingQty.ReadOnly = True
        txtAvailableQty.ReadOnly = True
        txtT0.ReadOnly = True
        btnT0Search.Enabled = False
        txtReceivedQty.ReadOnly = True
        txtUnit.ReadOnly = True
        txtReceivedPrice.ReadOnly = True
        btnAdd.Enabled = False
        btnReset.Enabled = False
        btnSaveAll.Enabled = False
        ' btnResetAll.Enabled = False
    End Sub

    Private Sub EnableFieldsInEntry()
        'cbTransType.Enabled = True
        txtIDNNo.ReadOnly = False
        txtGRNNo.ReadOnly = False
        ' txtIPRNo.ReadOnly = False
        'btnSearchIPRNo.Enabled = True
        txtRemarks.ReadOnly = False
        txtOperatorName.ReadOnly = False
        dtpTransportDate.Enabled = True
        txtVehicleNo.ReadOnly = False
        dtpIDNDate.Enabled = True
        txtPONo.ReadOnly = False
        'txtLPONo.ReadOnly = False
        'btnSearchLPONo.Enabled = True
        'cbDeliveySource.Enabled = True
        'txtSupplier.ReadOnly = False
        'btnSearchSupplier.Enabled = True
        'txtStockCode.ReadOnly = False
        'txtStockDesc.ReadOnly = False
        'txtPendingQty.ReadOnly = False
        'txtAvailableQty.ReadOnly = False
        txtT0.ReadOnly = False
        btnT0Search.Enabled = True
        txtReceivedQty.ReadOnly = False
        txtUnit.ReadOnly = False
        txtReceivedPrice.ReadOnly = False
        btnAdd.Enabled = True
        btnReset.Enabled = True
        btnSaveAll.Enabled = True
        ' btnResetAll.Enabled = False
    End Sub

    Private Sub dgvIDNView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvIDNView.KeyDown
        If e.KeyCode = Keys.Return Then
            EditViewGridRecord()
            e.Handled = True
        End If
    End Sub

    Private Sub EMDNView_Edit()
        Dim dt As New DataTable
        Dim str As String
        Dim Trnsdate As String
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim oBjEMDNBOL As New EstateMillDeliveryNoteBOL
        If dgvIDNView.Rows.Count > 0 Then
            If Not dgvIDNView.SelectedRows(0).Cells("dgclIPRNo").Value Is Nothing Then
                txtIPRNo.Text = dgvIDNView.SelectedRows(0).Cells("dgclIPRNo").Value.ToString()
            End If
            ' txtIPRNo.Text = dgvIDNView.SelectedRows(0).Cells("dgclIPRNo").Value.ToString()
            txtIDNNo.Text = dgvIDNView.SelectedRows(0).Cells("dgclIDNNo").Value.ToString()
            str = dgvIDNView.SelectedRows(0).Cells("dgclIDNDate").Value.ToString()
            dtpIDNDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            txtGRNNo.Text = dgvIDNView.SelectedRows(0).Cells("dgclGRNNo").Value.ToString()
            txtLPONo.Text = dgvIDNView.SelectedRows(0).Cells("dgclLPONo").Value.ToString()
            txtPONo.Text = dgvIDNView.SelectedRows(0).Cells("dgclPONo").Value.ToString()
            cbTransType.Text = dgvIDNView.SelectedRows(0).Cells("dgclTransType").Value.ToString()
            cbDeliveySource.Text = dgvIDNView.SelectedRows(0).Cells("dgclDeliverySource").Value.ToString()
            If Not dgvIDNView.SelectedRows(0).Cells("dgclSupplier").Value Is Nothing Then
                txtSupplier.Text = dgvIDNView.SelectedRows(0).Cells("dgclSupplier").Value.ToString()
            End If
            If Not dgvIDNView.SelectedRows(0).Cells("dgclSupplierID").Value Is Nothing Then
                lSupplierID = dgvIDNView.SelectedRows(0).Cells("dgclSupplierID").Value.ToString()
            End If
            'txtSupplier.Text = dgvIDNView.SelectedRows(0).Cells("dgclSupplier").Value.ToString()
            'lSupplierID = dgvIDNView.SelectedRows(0).Cells("dgclSupplierID").Value.ToString()
            lblStatusDesc.Text = dgvIDNView.SelectedRows(0).Cells("dgclStatus").Value.ToString()
            lSTEstMillDeliveryID = dgvIDNView.SelectedRows(0).Cells("dgclSTEstMillDeliveryID").Value.ToString()
            Trnsdate = dgvIDNView.SelectedRows(0).Cells("dgclTransportDate").Value.ToString()
            dtpTransportDate.Text = New Date(Trnsdate.Substring(6, 4), Trnsdate.Substring(3, 2), Trnsdate.Substring(0, 2))
            txtOperatorName.Text = dgvIDNView.SelectedRows(0).Cells("dgclOperatorName").Value.ToString()
            txtVehicleNo.Text = dgvIDNView.SelectedRows(0).Cells("dgclVehicleNo").Value.ToString()
            txtRemarks.Text = dgvIDNView.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            txtRejectedReason.Text = dgvIDNView.SelectedRows(0).Cells("dgclRejectedReason").Value.ToString()
            lSTIPRID = dgvIDNView.SelectedRows(0).Cells("dgclSTPRID").Value.ToString()
            lSTLPOID = dgvIDNView.SelectedRows(0).Cells("dgclSTLPOID").Value.ToString()
            With objEMDNPPT
                .STEstMillDeliveryID = lSTEstMillDeliveryID
            End With

            dt = oBjEMDNBOL.IDNDetails_Select(objEMDNPPT)
            If dt.Rows.Count > 0 Then
                dgvDetails.AutoGenerateColumns = False
                dgvDetails.DataSource = dt

                For i As Integer = 0 To dt.Rows.Count - 1
                    If Not dgvDetails.Rows(i).Cells("dgclPendingQty").Value Is Nothing And Not dgvDetails.Rows(i).Cells("dgclReceivedQty").Value Is Nothing Then
                        dgvDetails.Rows(i).Cells("dgclDifferenceQty").Value = CDbl(dgvDetails.Rows(i).Cells("dgclPendingQty").Value) - CDbl(dgvDetails.Rows(i).Cells("dgclReceivedQty").Value)
                    End If
                Next
                
                lSTEstMillDeliveryDetID = dt.Rows(0).Item("STEstMillDeliveryDetID").ToString()
                lSTIPRDetID = dt.Rows(0).Item("STIPRDetID").ToString()
                lSTLPODetID = dt.Rows(0).Item("STLPODetID").ToString()
                'lSTEstMillDelivID = dt.Rows(0).Item("STEstMillDeliveryID").ToString()
            Else
                DisplayInfoMessage("Msg26")
                'MessageBox.Show("No Records to Select", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'btnSaveAll.Text = "Update All"
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            cbTransType.Enabled = False
            If cbTransType.Text = "PR" Then
                txtIPRNo.Enabled = False
                btnSearchIPRNo.Enabled = False
                txtLPONo.Enabled = False
                btnSearchLPONo.Enabled = False
                cbDeliveySource.Enabled = True
                txtSupplier.Enabled = True
                btnSearchSupplier.Enabled = True
            Else
                txtLPONo.Enabled = False
                btnSearchLPONo.Enabled = False
                txtIPRNo.Enabled = False
                btnSearchIPRNo.Enabled = False
                cbDeliveySource.Enabled = False
                txtSupplier.Enabled = False
                btnSearchSupplier.Enabled = False
            End If
            tcEMDN.SelectedTab = tbpgEMDNAdd
        Else
            DisplayInfoMessage("Msg27")
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditUpdateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem1.Click
        EditViewGridRecord()
    End Sub

    Private Sub dgvIDNView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvIDNView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvIDNView.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    Me.dgvIDNView.ClearSelection()
                    Me.dgvIDNView.Rows(hti.RowIndex).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        ResetAll()
        tcEMDN.SelectedTab = tbpgEMDNAdd
    End Sub

    Private Sub DeleteEMDNView()
        Me.cmsEMDNView.Visible = False
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        If dgvIDNView.Rows.Count > 0 Then
            If dgvIDNView.SelectedRows(0).Cells("dgclStatus").Value = "OPEN" Then
                If MsgBox(rm.GetString("Msg28"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Me.lSTEstMillDeliveryID = Me.dgvIDNView.SelectedRows(0).Cells("dgclSTEstMillDeliveryID").Value.ToString()
                    With objEMDNPPT
                        .STEstMillDeliveryID = Me.lSTEstMillDeliveryID
                    End With
                    objEMDNBOL.Delete_STMillDeliveryDelete(objEMDNPPT)
                    BindIDNViewDetails()
                End If
            Else
                DisplayInfoMessage("Msg29")
                'MessageBox.Show("Not valid record to delete, status must be OPEN ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            DisplayInfoMessage("Msg30")
            'MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteEMDNView()
    End Sub

    Private Sub txtReceivedQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceivedQty.KeyDown
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

    Private Sub txtReceivedQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceivedQty.KeyPress
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub

    Private Sub txtReceivedPrice_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReceivedPrice.KeyDown
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

    Private Sub txtReceivedPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceivedPrice.KeyPress
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub tcEMDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcEMDN.Click

        If tcEMDN.SelectedTab Is tcEMDN.TabPages("tbpgEMDNView") Then

            rbtnIPR.Checked = True
            Load_IPRNo()
            chkIDNDate.Focus()
            If (dgvDetails.RowCount > 0 And (lblStatusDesc.Text.Trim = "OPEN" Or lblStatusDesc.Text.Trim = "REJECTED") And btnSaveAll.Enabled = True) Then
                If MsgBox(rm.GetString("Msg65"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ClearGridView(dgvDetails)
                    GlobalPPT.IsRetainFocus = False
                    'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    chkIDNDate.Focus()
                    BindIDNViewDetails()
                Else
                    tcEMDN.SelectedTab = tbpgEMDNAdd
                End If
            Else
                ResetAllOnTabClick()
                chkIDNDate.Focus()
                BindIDNViewDetails()
            End If

            If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem1, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If


        ElseIf tcEMDN.SelectedTab Is tcEMDN.TabPages("tbpgEMDNAdd") Then

            'chkIDNDate.Focus()
            'BindIDNViewDetails()
            If tcEMDN.TabPages.Count = 2 Then '--if transaction screen--'
                If btnSaveAll.Enabled = True Then
                    If dgvDetails.RowCount > 0 Then
                        If MsgBox(rm.GetString("Msg65"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                            ResetAllOnTabClick()
                        Else
                            Exit Sub
                        End If
                    Else
                        ResetAllOnTabClick()
                    End If
                End If
            Else
                Exit Sub '--if approval screen--'
            End If
        End If


        'If tcEMDN.SelectedTab Is tbpgEMDNView = True Then

        '    Reset()
        '    lSTEstMillDeliveryID = ""
        '    ClearGridView(dgvDetails)
        '    ResetAll()
        '    EnableFieldsInEntry()

        '    cbTransType.Focus()
        '    'btnSaveAll.Text = "Save All"
        '    If GlobalPPT.strLang = "en" Then
        '        btnSaveAll.Text = "Save All"
        '    ElseIf GlobalPPT.strLang = "ms" Then
        '        btnSaveAll.Text = "Simpan Semua"
        '    End If
        '    btnSaveAll.Enabled = True
        '    cbTransType.Enabled = True
        '    TransType_Change()


        'ElseIf tcEMDN.SelectedTab Is tbpgEMDNAdd = True Then

        '    chkIDNDate.Focus()
        '    BindIDNViewDetails()

        'End If

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem1, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If



    End Sub
    Private Sub ResetAllOnTabClick()
        Reset()
        lSTEstMillDeliveryID = ""
        ClearGridView(dgvDetails)
        ResetAll()
        EnableFieldsInEntry()

        cbTransType.Focus()
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        btnSaveAll.Enabled = True
        cbTransType.Enabled = True
        TransType_Change()
    End Sub
    ''commented start

    'If tcEMDN.SelectedTab Is tcEMDN.TabPages("tbpgEMDNView") Then

    '        chkIDNDate.Focus()
    '        If (dgvDetails.RowCount > 0 And (lblStatusDesc.Text = "OPEN" Or lblStatusDesc.Text = "REJECTED")) Then
    '            If MsgBox(rm.GetString("Msg65"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    ''If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                BindIDNViewDetails()
    '            Else
    '                tcEMDN.SelectedTab = tbpgEMDNAdd
    '            End If
    '        End If

    '        If tcEMDN.SelectedTab Is tbpgEMDNView = True Then

    '            Reset()
    '            lSTEstMillDeliveryID = ""
    '            ClearGridView(dgvDetails)
    '            ResetAll()
    '            EnableFieldsInEntry()

    '            cbTransType.Focus()
    ''btnSaveAll.Text = "Save All"
    '            If GlobalPPT.strLang = "en" Then
    '                btnSaveAll.Text = "Save All"
    '            ElseIf GlobalPPT.strLang = "ms" Then
    '                btnSaveAll.Text = "Simpan Semua"
    '            End If
    '            btnSaveAll.Enabled = True
    '            cbTransType.Enabled = True
    '            TransType_Change()


    '        ElseIf tcEMDN.SelectedTab Is tbpgEMDNAdd = True Then

    '            chkIDNDate.Focus()
    '            BindIDNViewDetails()

    '        End If

    '    End If
    ''commented end

    Private Sub Load_IPRNo()

        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        dt = objEMDNBOL.STMillDeliveryIPRNoGet(objEMDNPPT)

        If dt.Rows.Count <> 0 Then

            cbviewIPRNo.DataSource = dt
            cbviewIPRNo.DisplayMember = "IPRNo"
            cbviewIPRNo.ValueMember = "IPRNo"

            Dim intRowCount As Integer
            intRowCount = cbviewIPRNo.SelectedIndex

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "--SELECT--"
            dr(1) = "--SELECT--"
            dt.Rows.InsertAt(dr, 0)

            cbviewIPRNo.SelectedIndex = 0

        Else

            Dim intRowCount As Integer
            intRowCount = cbviewIPRNo.SelectedIndex

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "--SELECT--"
            dr(1) = "--SELECT--"
            dt.Rows.InsertAt(dr, 0)

            cbviewIPRNo.SelectedIndex = -1
            cbviewIPRNo.Text = "--SELECT--"

        End If



    End Sub

    Private Sub Load_LPONo()

        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        dt = objEMDNBOL.STMillDeliveryLPONoGet(objEMDNPPT)

        If dt.Rows.Count <> 0 Then

            cbviewLPONo.DataSource = dt
            cbviewLPONo.DisplayMember = "LPONo"
            cbviewLPONo.ValueMember = "LPONo"

            Dim intRowCount As Integer
            intRowCount = cbviewLPONo.SelectedIndex

            Dim dr As DataRow = dt.NewRow()
            dr(0) = "--SELECT--"
            dr(1) = "--SELECT--"
            dt.Rows.InsertAt(dr, 0)

            cbviewLPONo.SelectedIndex = 0

        Else

            cbviewLPONo.Text = "--SELECT--"

        End If


    End Sub

    'Private Sub Load_PONo()
    '    Dim objEMDNPPT As New EstateMillDeliveryNotePPT
    '    Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
    '    Dim dt As New DataTable
    '    dt = objEMDNBOL.STMillDeliveryPONoGet(objEMDNPPT)
    '    If dt.Rows.Count <> 0 Then
    '        cbviewPONo.DataSource = dt
    '        cbviewPONo.DisplayMember = "SELECT ALL"
    '        cbviewPONo.ValueMember = "PONo"
    '    End If
    'End Sub

    Private Sub txtSupplier_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplier.Leave
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNBOL As New EstateMillDeliveryNoteBOL
        Dim dt As New DataTable
        If txtSupplier.Text <> String.Empty Then
            objEMDNPPT.SendersLocation = txtSupplier.Text.Trim
            dt = objEMDNBOL.SearchSupplier(objEMDNPPT)
            If dt.Rows.Count <> 0 Then
                Me.txtSupplier.Text = dt.Rows(0).Item("DistributionDescp").ToString()
                txtOperatorName.Focus()
            Else
                DisplayInfoMessage("Msg31")
                'MessageBox.Show("Invalid Supplier", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSupplier.Text = String.Empty
                txtSupplier.Focus()
            End If
        End If
    End Sub

    'For Approval By Arulprakasan

    Private Sub btnConform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConform.Click

        ConfirmApproval()

    End Sub

    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Public Sub EMDNView_EditApprovalMode(ByVal dgclIPRNoVal, ByVal dgclIDNNoVal, ByVal dgclIDNDateVal, ByVal dgclGRNNoVal, ByVal dgclLPONoVal, ByVal dgclPONoVal, ByVal dgclTransTypeVal, ByVal dgclDeliverySourceVal, ByVal dgclSupplierVal, ByVal dgclSupplierIDVal, ByVal dgclStatusVal, ByVal dgclSTEstMillDeliveryIDVal, ByVal dgclTransportDateVal, ByVal dgclOperatorNameVal, ByVal dgclVehicleNoVal, ByVal dgclRemarksVal, ByVal dgclRejectedReasonVal, ByVal dgclSTIPRIDVal, ByVal dgclSTLPOIDVal, ByVal dgclSupplierCOAID, ByVal dgclT0Val, ByVal dgclT1Val, ByVal dgclT2Val, ByVal dgclT3Val, ByVal dgclT4Val)
        Dim dt As New DataTable

        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim oBjEMDNBOL As New EstateMillDeliveryNoteBOL

        If dgclTransTypeVal.ToString.Trim = "PR" Then
            cbTransType.SelectedIndex = 0
        Else
            cbTransType.SelectedIndex = 1
        End If

        'cbTransType.Text = dgclTransTypeVal
        txtIPRNo.Text = dgclIPRNoVal
        txtIDNNo.Text = dgclIDNNoVal
        Dim STR As String = String.Empty
        STR = dgclIDNDateVal
        pdIDNDateVal = New Date(STR.Substring(6, 4), STR.Substring(3, 2), STR.Substring(0, 2))
        dtpIDNDate.Value = pdIDNDateVal
        FormatDateTimePicker(dtpIDNDate)
        txtGRNNo.Text = dgclGRNNoVal
        txtLPONo.Text = dgclLPONoVal
        lLPONo = dgclLPONoVal

        ''To get LPOSupplier name for journalization-Start ---- remove this if supplier name and t0-t4 value comes from approval screen later
        'If dgclLPONoVal <> String.Empty Then
        '    objEMDNPPT.LPONo = dgclLPONoVal
        '    Dim dtLPOAPSupplierName As DataTable
        '    dtLPOAPSupplierName = oBjEMDNBOL.SearchLPONo(objEMDNPPT)
        '    If dtLPOAPSupplierName.Rows.Count > 0 Then
        '        lLPOSupplierName = dtLPOAPSupplierName.Rows(0).Item("SupplierName")
        '    Else
        '        lLPOSupplierName = ""
        '    End If

        'End If

        'To get LPOSupplier name for journalization-Start

        txtPONo.Text = dgclPONoVal
        'cbTransType.Enabled = True
        'cbTransType.Items.Add(dgclTransTypeVal)        
        cbDeliveySource.Text = dgclDeliverySourceVal
        txtSupplier.Text = dgclSupplierVal
        lSupplierID = dgclSupplierIDVal

        lT0ID = dgclT0Val
        lT1ID = dgclT1Val
        lT2ID = dgclT2Val
        lT3ID = dgclT3Val
        lT4ID = dgclT4Val
        '
        lblStatusDesc.Text = dgclStatusVal
        lSTEstMillDeliveryID = dgclSTEstMillDeliveryIDVal
        'pdTransportDateVal = dgclTransportDateVal
        STR = String.Empty
        STR = dgclTransportDateVal
        pdTransportDateVal = New Date(STR.Substring(6, 4), STR.Substring(3, 2), STR.Substring(0, 2))
        dtpTransportDate.Value = pdTransportDateVal
        FormatDateTimePicker(dtpTransportDate)

        txtOperatorName.Text = dgclOperatorNameVal
        txtVehicleNo.Text = dgclVehicleNoVal
        txtRemarks.Text = dgclRemarksVal
        txtRejectedReason.Text = dgclRejectedReasonVal
        lSTIPRID = dgclSTIPRIDVal
        lSTLPOID = dgclSTLPOIDVal
        psSupplierCOAID = dgclSupplierCOAID
        With objEMDNPPT
            .STEstMillDeliveryID = lSTEstMillDeliveryID
        End With

        'To get LPOSupplier name for journalization-Start ---- remove this if supplier name and t0-t4 value comes from approval screen later
        If dgclLPONoVal <> String.Empty Then
            objEMDNPPT.LPONo = dgclLPONoVal
            Dim dtLPOAPSupplierName As DataTable
            dtLPOAPSupplierName = EstateMillDeliverNoteApprovalBOL.LPOSupplierNameGet(objEMDNPPT).Tables(0)
            If dtLPOAPSupplierName.Rows.Count > 0 Then
                lLPOSupplierName = dtLPOAPSupplierName.Rows(0).Item("SupplierName")
                txtSupplier.Text = dtLPOAPSupplierName.Rows(0).Item("SupplierName")
                lSupplierID = dtLPOAPSupplierName.Rows(0).Item("APSupplierID")
                psSupplierCOAID = dtLPOAPSupplierName.Rows(0).Item("SupplierCOAID")
            Else
                lLPOSupplierName = ""
                txtSupplier.Text = ""
                lSupplierID = ""
                psSupplierCOAID = ""
            End If

        End If

        dt = oBjEMDNBOL.IDNDetails_Select(objEMDNPPT)
        If dt.Rows.Count > 0 Then
            dgvDetails.AutoGenerateColumns = False
            dgvDetails.DataSource = dt
            '
            'If Not dgvDetails.SelectedRows(0).Cells("dgclPendingQty").Value Is Nothing And Not dgvDetails.SelectedRows(0).Cells("dgclReceivedQty").Value Is Nothing Then
            '    dgvDetails.SelectedRows(0).Cells("dgclDifferenceQty").Value = CDbl(dgvDetails.SelectedRows(0).Cells("dgclPendingQty").Value) - CDbl(dgvDetails.SelectedRows(0).Cells("dgclReceivedQty").Value)
            'End If
            '
            lSTEstMillDeliveryDetID = dt.Rows(0).Item("STEstMillDeliveryDetID").ToString()
            lSTIPRDetID = dt.Rows(0).Item("STIPRDetID").ToString()
            lSTLPODetID = dt.Rows(0).Item("STLPODetID").ToString()
            'lSTEstMillDelivID = dt.Rows(0).Item("STEstMillDeliveryID").ToString()
            tcEMDN.SelectedTab = tbpgEMDNAdd
            dgvDetails.Columns("dgclPendingQty").Visible = False

            Dim intdgvDetailsCount As Integer
            intdgvDetailsCount = dgvDetails.RowCount
            Dim intRow As Integer = 0
            Dim intIncrementRow As Integer = 0




            'For Each GridViewRow In dgvDetails.Rows

            'While intdgvDetailsCount <> intIncrementRow - 1

            '    dgvDetails.Rows(intRow).Selected = True
            '    If dgvDetails.SelectedRows(intRow).Cells("dgclPendingQty").Value <> 0 And dgvDetails.SelectedRows(intRow).Cells("dgclReceivedQty").Value <> 0 Then
            '        dgvDetails.SelectedRows(intRow).Cells("dgclDifferenceQty").Value = CDbl(dgvDetails.SelectedRows(intRow).Cells("dgclPendingQty").Value) - CDbl(dgvDetails.SelectedRows(intRow).Cells("dgclReceivedQty").Value)
            '    End If
            '    intRow = intRow + 1
            '    intIncrementRow = intIncrementRow + 1
            '    intdgvDetailsCount = intdgvDetailsCount - 1

            'End While

            'For intRow = 0 To intdgvDetailsCount

            '    dgvDetails.Rows(intRow).Selected = True
            '    If dgvDetails.SelectedRows(intRow).Cells("dgclPendingQty").Value <> 0 And dgvDetails.SelectedRows(intRow).Cells("dgclReceivedQty").Value <> 0 Then
            '        dgvDetails.SelectedRows(intRow).Cells("dgclDifferenceQty").Value = CDbl(dgvDetails.SelectedRows(intRow).Cells("dgclPendingQty").Value) - CDbl(dgvDetails.SelectedRows(intRow).Cells("dgclReceivedQty").Value)
            '    End If


            'Next


        Else
            'MessageBox.Show("No Records to Select", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisplayInfoMessage("Msg32")
            'MessageBox.Show(" No Records")
        End If
    End Sub

    Private Function IsValidComboSelect() As Boolean
        If cmbStatus.SelectedIndex = -1 Then
            DisplayInfoMessage("Msg33")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        If (cmbStatus.Text = "--Select Status--") Then
            DisplayInfoMessage("Msg34")
            'MessageBox.Show("Status  not Selected", "Please select Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
            Exit Function
        End If
        Return True
    End Function

    Private Sub DisbleFieldsInApprovalMode()

        cbTransType.Enabled = False
        txtIDNNo.Enabled = False
        txtGRNNo.Enabled = False
        txtIPRNo.Enabled = False
        btnSearchIPRNo.Visible = False
        txtRemarks.Enabled = False
        txtOperatorName.Enabled = False
        dtpTransportDate.Enabled = False
        txtVehicleNo.Enabled = False
        grpApproval.Visible = True
        txtPONo.Enabled = False
        txtLPONo.Enabled = False
        btnSearchLPONo.Enabled = False
        cbDeliveySource.Enabled = False
        txtSupplier.Enabled = False
        btnSearchSupplier.Enabled = False
        txtStockCode.Enabled = False
        txtStockDesc.Enabled = False
        txtPendingQty.Enabled = False
        txtAvailableQty.Enabled = False
        txtT0.Enabled = False
        btnT0Search.Enabled = False
        txtReceivedQty.Enabled = False
        txtUnit.Enabled = False
        txtReceivedPrice.Enabled = False
        btnAdd.Enabled = False
        btnReset.Enabled = False
        btnSaveAll.Enabled = False
        btnResetAll.Enabled = False
        dtpIDNDate.Enabled = False

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

    Private Sub ConfirmApproval()

        Dim objIPRPPT As New InternalPurchaseRequisitionApprovalPPT
        Dim objEMDNPPT As New EstateMillDeliveryNotePPT
        Dim objEMDNApprovalPPT As New EstMillDeliveryNoteApprovalPPT
        Dim liUpdateEMDN As Integer
        objEMDNPPT.STEstMillDeliveryID = lSTEstMillDeliveryID
        If IsValidComboSelect() = False Then
            Exit Sub
        End If
        If cmbStatus.SelectedItem.ToString() = "APPROVED" Then
            txtRejectedReason.Text = String.Empty
            If MsgBox(rm.GetString("Msg35"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to Confirm the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                ' ''1st Step-Updadte the status in Store.Store.STMillDelivery Table

                ''objEMDNPPT.Status = "APPROVED"
                ''liUpdateEMDN = EstateMillDeliverNoteApprovalBOL.STMillDeliveryUpdateApproval(objEMDNPPT)
                ''If liUpdateEMDN = 1 Then
                ''    MessageBox.Show("Approved Successfully")
                ''ElseIf liUpdateEMDN = 0 Then
                ''    MessageBox.Show("Approval Failed")
                ''    Exit Sub
                ''End If

                Dim strArray As String()
                Dim strLoginMonthName As String
                strArray = GlobalPPT.strLoginMonth.Split("-")
                strLoginMonthName = strArray(1)

                'FLOW I : IF IPR + Samarinda

                If txtIPRNo.Text.Trim <> String.Empty Then

                    '1st Step-Updadte the status in Store.Store.STMillDelivery Table

                    objEMDNPPT.Status = "APPROVED"
                    liUpdateEMDN = EstateMillDeliverNoteApprovalBOL.STMillDeliveryUpdateApproval(objEMDNPPT)
                    If liUpdateEMDN = 1 Then
                        DisplayInfoMessage("Msg36")
                        'MessageBox.Show("Approved Successfully")
                    ElseIf liUpdateEMDN = 0 Then
                        DisplayInfoMessage("Msg37")
                        'MessageBox.Show("Approval Failed")
                        Exit Sub
                    End If


                    'Calculate and update Store.STIPRDetail.PendingQty=Store.STIPRDetail.PendingQty-Store.STEstMillDeliveryDet.ReceivedQty 
                    Dim dsSTIPRDetailUpdateForEMDNApproval As New DataSet
                    Dim lsSTIPRDetailStatus As String = String.Empty

                    objEMDNPPT.STIPRID = lSTIPRID
                    objEMDNPPT.STIPRDetID = lSTIPRDetID
                    objEMDNPPT.STEstMillDeliveryID = lSTEstMillDeliveryID
                    objEMDNPPT.STEstMillDeliveryDetID = lSTEstMillDeliveryDetID
                    Dim intSTIPRDetailUpdateForEMDNApproval As Integer
                    intSTIPRDetailUpdateForEMDNApproval = EstateMillDeliverNoteApprovalBOL.STIPRDetailUpdateForEMDNApproval(objEMDNPPT)
                    If intSTIPRDetailUpdateForEMDNApproval = 0 Then
                        DisplayInfoMessage("Msg38")
                        'MessageBox.Show("Failed to update IPR")
                    End If

                    'Update StockDetail and calculate AvgPrice Start
                    'Increase Stock Detail : Store.StockDetail.IDNqty=Store.StockDetail.IDNqty+IDNDetail.ReceivedQty
                    'Store.StockDetail.IDNValue=Store.StockDetail.IDNValue+IDNDetail.TotalPrice
                    'Calculate Avg Price and update it in stock detail
                    'Update StockDetail and calculate AvgPrice End

                    'Accounts.Ledgerallmodule insert start
                    Dim dsUpdateStockDetail As New DataSet
                    'Dim ldTotalPriceSum As Double
                    For Each GridViewRow In dgvDetails.Rows
                        If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                            objEMDNPPT.TotalPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                            'ldTotalPriceSum += CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                        End If
                    Next
                    objEMDNApprovalPPT.AYear = GlobalPPT.intActiveYear
                    objEMDNApprovalPPT.AMonth = GlobalPPT.IntActiveMonth
                    objEMDNApprovalPPT.LedgerDate = dtpIDNDate.Value 'Format(dtpIDNDate.Value, "MM/dd/yyyy") 'IDNDate
                    objEMDNApprovalPPT.LedgerType = "STORE-IDN"
                    If txtRemarks.Text.Trim() <> String.Empty Then
                        objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtRemarks.Text.Trim() 'IDNRemarks
                    Else
                        objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim()
                    End If

                    'objEMDNApprovalPPT.BatchAmount = ldTotalPriceSum
                    Dim dsRowsAffectedLedgerAllModule As New DataSet
                    Dim strLedgerID As String
                    dsRowsAffectedLedgerAllModule = EstateMillDeliverNoteApprovalBOL.STIDNLedgerAllModuleInsert(objEMDNApprovalPPT)
                    strLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                    objEMDNApprovalPPT.LedgerID = strLedgerID
                    'Accounts.Ledgerallmodule insert end

                    'Accounts.JournalDetail.Insert start.
                    Dim lStockCOAID As String, lVarianceCOAID As String = String.Empty
                    'Dim lIDNPrice As Double, lSTDPrice As Double, lVariancePrice As Double, lValue As Double
                    Dim lSTDPrice As Double, lVariancePrice As Double
                    'Dim lReceivedQty As Double, lTotalPrice As Double
                    Dim intJournalRowsAffected As Integer = 0
                    For Each GridViewRow In dgvDetails.Rows
                        If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then

                            objEMDNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                            If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                                objEMDNPPT.ReceivedQty = CDbl(GridViewRow.Cells("dgclReceivedQty").Value)
                            Else
                                objEMDNPPT.ReceivedQty = 0
                            End If
                            If Not GridViewRow.Cells("dgclTotalPrice").Value Is DBNull.Value Then
                                objEMDNPPT.TotalPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value)
                            Else
                                objEMDNPPT.TotalPrice = 0
                            End If

                            If Not GridViewRow.Cells("dgclReceivedPrice").Value Is DBNull.Value Then
                                objEMDNPPT.ReceivedPrice = CDbl(GridViewRow.Cells("dgclReceivedPrice").Value)
                            Else
                                objEMDNPPT.ReceivedPrice = 0
                            End If


                            'ldTotalPriceSum += CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                            dsUpdateStockDetail = EstateMillDeliverNoteApprovalBOL.STStockDetailAvgPriceApproval(objEMDNPPT)
                            If dsUpdateStockDetail Is Nothing Then
                                DisplayInfoMessage("Msg39")
                                'MessageBox.Show("Failed to update stock detail")
                                'put delete code for the previous steps
                                Exit Sub
                            End If
                            If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("StockCOAID") Is DBNull.Value Then
                                lStockCOAID = dsUpdateStockDetail.Tables(0).Rows(0).Item("StockCOAID")
                            Else
                                lStockCOAID = String.Empty
                            End If
                            If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("VarianceCOAID") Is DBNull.Value Then
                                lVarianceCOAID = dsUpdateStockDetail.Tables(0).Rows(0).Item("VarianceCOAID")
                            Else
                                lVarianceCOAID = String.Empty
                            End If
                            If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("StdPrice") Is DBNull.Value Then
                                lSTDPrice = dsUpdateStockDetail.Tables(0).Rows(0).Item("StdPrice")
                            Else
                                lSTDPrice = String.Empty
                            End If
                            'If Not GridViewRow.Cells("dgclStockDesc").Value Is DBNull.Value Then
                            '    objEMDNApprovalPPT.Descp = GridViewRow.Cells("dgclStockDesc").Value.ToString()  ' descp=stock name
                            'Else
                            '    objEMDNApprovalPPT.Descp = String.Empty
                            'End If



                            'IDNPRICE Start
                            objEMDNApprovalPPT.DC = "D"
                            objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            objEMDNApprovalPPT.COAID = lStockCOAID 'Debit Store COA
                            objEMDNApprovalPPT.Value = GridViewRow.Cells("dgclTotalPrice").Value.ToString()
                            objEMDNApprovalPPT.T0 = GridViewRow.Cells("dgclTAnalysisID").Value.ToString()
                            objEMDNApprovalPPT.T1 = String.Empty
                            objEMDNApprovalPPT.T2 = String.Empty
                            objEMDNApprovalPPT.T3 = String.Empty
                            objEMDNApprovalPPT.T4 = String.Empty

                            objEMDNApprovalPPT.StationID = String.Empty
                            objEMDNApprovalPPT.Flag = "IDNPRICE"
                            intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                            objEMDNApprovalPPT.T0 = String.Empty
                            objEMDNApprovalPPT.T1 = String.Empty
                            objEMDNApprovalPPT.T2 = String.Empty
                            objEMDNApprovalPPT.T3 = String.Empty
                            objEMDNApprovalPPT.T4 = String.Empty


                            objEMDNApprovalPPT.DC = "C"
                            objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtSupplier.Text.Trim() + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            objEMDNApprovalPPT.COAID = psSupplierCOAID 'Credit Supplier COA
                            objEMDNApprovalPPT.Value = GridViewRow.Cells("dgclTotalPrice").Value.ToString()
                            objEMDNApprovalPPT.T0 = lT0ID
                            objEMDNApprovalPPT.T1 = lT1ID
                            objEMDNApprovalPPT.T2 = lT2ID
                            objEMDNApprovalPPT.T3 = lT3ID
                            objEMDNApprovalPPT.T4 = lT4ID
                            objEMDNApprovalPPT.StationID = String.Empty
                            objEMDNApprovalPPT.Flag = "IDNPRICE"
                            intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                            objEMDNApprovalPPT.T0 = String.Empty
                            objEMDNApprovalPPT.T1 = String.Empty
                            objEMDNApprovalPPT.T2 = String.Empty
                            objEMDNApprovalPPT.T3 = String.Empty
                            objEMDNApprovalPPT.T4 = String.Empty
                            'IDNPRICE End

                            ''IDNSTDPRICE Start
                            'If lSTDPrice <> 0 And lStockCOAID <> String.Empty Then
                            '    objEMDNApprovalPPT.DC = "D"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            '    objEMDNApprovalPPT.COAID = lStockCOAID 'Debit Store COA
                            '    If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                            '        lValue = CDbl(GridViewRow.Cells("dgclReceivedQty").Value) * lSTDPrice
                            '    Else
                            '        lValue = lSTDPrice
                            '    End If
                            '    objEMDNApprovalPPT.Value = lValue
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "IDNSTDPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                            '    objEMDNApprovalPPT.DC = "C"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtSupplier.Text.Trim() + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            '    objEMDNApprovalPPT.COAID = psSupplierCOAID 'Credit Supplier COA
                            '    If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                            '        lValue = CDbl(GridViewRow.Cells("dgclReceivedQty").Value) * lSTDPrice
                            '    Else
                            '        lValue = lSTDPrice
                            '    End If
                            '    objEMDNApprovalPPT.Value = lValue
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "IDNSTDPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                            'End If
                            ''IDNSTDPRICE End

                            ''IDNVARIANCEPRICE Start
                            'If Not GridViewRow.Cells("dgclTotalPrice").Value Is DBNull.Value Then
                            '    lIDNPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value)
                            'End If
                            'lVariancePrice = Abs(lValue - lIDNPrice)
                            'If lSTDPrice <> 0 And lVariancePrice <> 0 And lVarianceCOAID <> String.Empty Then
                            '    objEMDNApprovalPPT.DC = "D"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            '    objEMDNApprovalPPT.COAID = lVarianceCOAID  'Debit Variance COA
                            '    objEMDNApprovalPPT.Value = lVariancePrice
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "IDNVARIANCEPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                            '    objEMDNApprovalPPT.DC = "C"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtSupplier.Text.Trim() + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            '    objEMDNApprovalPPT.COAID = lStockCOAID 'Credit Store COA
                            '    objEMDNApprovalPPT.Value = lVariancePrice
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "IDNVARIANCEPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                            'End If
                            ''IDNVARIANCEPRICE End
                            If intJournalRowsAffected = 0 Then
                                DisplayInfoMessage("Msg40")
                                'MessageBox.Show("Failed to Insert Journal Details transaction")
                                Exit Sub
                            End If
                        End If
                        lSTDPrice = 0
                        lVariancePrice = 0
                        'lIDNPrice = 0
                    Next
                    'Accounts.JournalDetail.Insert end.
                    'update LedgerAllModule BatchAmount Value
                    Dim intUpdateLegerAllModuleBatchAmount As Integer = 0
                    objEMDNApprovalPPT.DC = "D"
                    objEMDNApprovalPPT.LedgerID = strLedgerID
                    intUpdateLegerAllModuleBatchAmount = EstateMillDeliverNoteApprovalBOL.STIDNLedgerAllModuleUpdate(objEMDNApprovalPPT)
                    If intUpdateLegerAllModuleBatchAmount = 0 Then
                        DisplayInfoMessage("Msg41")
                        MessageBox.Show("Failed to Update LedgerAllModule BatchAmount")
                        Exit Sub
                    Else
                        'Call TaskMonitor Update after successful approval -Start

                        Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                        Dim dsTaskMonitorUPDATE As New DataSet
                        objStoreMonthEndClosingPPT.ModID = 2
                        objStoreMonthEndClosingPPT.Task = "Estate/Mill Delivery note approval"
                        objStoreMonthEndClosingPPT.Complete = "Y"
                        dsTaskMonitorUPDATE = StoreMonthEndClosingBOL.Taskmonitorupdate(objStoreMonthEndClosingPPT)

                        'Call TaskMonitor Update after successful approval -End
                    End If
                End If

                'FLOW II : IF IPR + Consignment

                If cbDeliveySource.Text.Trim = "Consignment" And txtIPRNo.Text.Trim <> String.Empty Then
                    ''''
                    Dim dsStockDetailConsignmentAvailCheck As New DataSet
                    Dim liCongignmentStockCount, liStockCount As Integer
                    Dim lsMatchCount As String = String.Empty
                    dsStockDetailConsignmentAvailCheck = EstateMillDeliverNoteApprovalBOL.StockDetailConsignmentAvailCheck(objEMDNPPT)
                    If Not dsStockDetailConsignmentAvailCheck.Tables(0).Rows(0).Item("CongignmentStockCount") Is DBNull.Value Then
                        liCongignmentStockCount = dsStockDetailConsignmentAvailCheck.Tables(0).Rows(0).Item("CongignmentStockCount")
                    Else
                        liCongignmentStockCount = 0
                    End If
                    If Not dsStockDetailConsignmentAvailCheck.Tables(0).Rows(0).Item("StockCount") Is DBNull.Value Then
                        liStockCount = dsStockDetailConsignmentAvailCheck.Tables(0).Rows(0).Item("StockCount")
                    Else
                        liStockCount = 0
                    End If
                    If liStockCount = 0 And liCongignmentStockCount = 0 Then
                        lsMatchCount = "NotMatch"
                    Else
                        If liStockCount <> liCongignmentStockCount Then
                            lsMatchCount = "NotMatch"
                        ElseIf liStockCount = liCongignmentStockCount Then
                            lsMatchCount = "Match"
                        End If
                    End If
                    ''''
                    If lsMatchCount = "Match" Then
                        '1st Step-Updadte the status in Store.Store.STMillDelivery Table

                        objEMDNPPT.Status = "APPROVED"
                        liUpdateEMDN = EstateMillDeliverNoteApprovalBOL.STMillDeliveryUpdateApproval(objEMDNPPT)
                        If liUpdateEMDN = 1 Then
                            DisplayInfoMessage("Msg42")
                            'MessageBox.Show("Approved Successfully")
                        ElseIf liUpdateEMDN = 0 Then
                            DisplayInfoMessage("Msg43")
                            'MessageBox.Show("Approval Failed")
                            Exit Sub
                        End If

                        Dim dsSTIPRDetailUpdateForEMDNApproval As New DataSet
                        Dim lsSTIPRDetailStatus As String = String.Empty

                        objEMDNPPT.STIPRID = lSTIPRID
                        objEMDNPPT.STIPRDetID = lSTIPRDetID
                        objEMDNPPT.STEstMillDeliveryID = lSTEstMillDeliveryID
                        objEMDNPPT.STEstMillDeliveryDetID = lSTEstMillDeliveryDetID
                        Dim intSTIPRDetailUpdateForEMDNApproval As Integer
                        intSTIPRDetailUpdateForEMDNApproval = EstateMillDeliverNoteApprovalBOL.STIPRDetailUpdateForEMDNApproval(objEMDNPPT)
                        If intSTIPRDetailUpdateForEMDNApproval = 0 Then
                            DisplayInfoMessage("Msg44")
                            'MessageBox.Show("Failed to update IPR")
                        End If

                        'Update StockDetail and calculate AvgPrice Start
                        'Increase Stock Detail : Store.StockDetail.IDNqty=Store.StockDetail.IDNqty+IDNDetail.ReceivedQty
                        'Store.StockDetail.IDNValue=Store.StockDetail.IDNValue+IDNDetail.TotalPrice
                        'Calculate Avg Price and update it in stock detail
                        'Update StockDetail and calculate AvgPrice End

                        'Accounts.Ledgerallmodule insert start
                        Dim dsUpdateStockDetail As New DataSet
                        'Dim ldTotalPriceSum As Double
                        For Each GridViewRow In dgvDetails.Rows
                            If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                                objEMDNPPT.TotalPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                                'ldTotalPriceSum += CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                            End If
                        Next
                        objEMDNApprovalPPT.AYear = GlobalPPT.intActiveYear
                        objEMDNApprovalPPT.AMonth = GlobalPPT.IntActiveMonth
                        objEMDNApprovalPPT.LedgerDate = dtpIDNDate.Value 'Format(dtpIDNDate.Value, "MM/dd/yyyy") 'IDNDate
                        objEMDNApprovalPPT.LedgerType = "STORE-IDN"
                        If txtRemarks.Text.Trim() <> String.Empty Then
                            objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtRemarks.Text.Trim() 'IDNRemarks
                        Else
                            objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim()
                        End If

                        'objEMDNApprovalPPT.BatchAmount = ldTotalPriceSum
                        Dim dsRowsAffectedLedgerAllModule As New DataSet
                        Dim strLedgerID As String
                        dsRowsAffectedLedgerAllModule = EstateMillDeliverNoteApprovalBOL.STIDNLedgerAllModuleInsert(objEMDNApprovalPPT)
                        strLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                        objEMDNApprovalPPT.LedgerID = strLedgerID
                        'Accounts.Ledgerallmodule insert end

                        'Accounts.JournalDetail.Insert start.
                        Dim lStockCOAID As String, lVarianceCOAID As String = String.Empty
                        Dim lIDNPrice As Double, lSTDPrice As Double, lVariancePrice As Double ', lValue As Double
                        'Dim lReceivedQty As Double, lTotalPrice As Double
                        Dim intJournalRowsAffected As Integer = 0
                        For Each GridViewRow In dgvDetails.Rows
                            If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then

                                objEMDNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                                If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                                    objEMDNPPT.ReceivedQty = CDbl(GridViewRow.Cells("dgclReceivedQty").Value)
                                Else
                                    objEMDNPPT.ReceivedQty = 0
                                End If
                                If Not GridViewRow.Cells("dgclTotalPrice").Value Is DBNull.Value Then
                                    objEMDNPPT.TotalPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value)
                                Else
                                    objEMDNPPT.TotalPrice = 0
                                End If

                                If Not GridViewRow.Cells("dgclReceivedPrice").Value Is DBNull.Value Then
                                    objEMDNPPT.ReceivedPrice = CDbl(GridViewRow.Cells("dgclReceivedPrice").Value)
                                Else
                                    objEMDNPPT.ReceivedPrice = 0
                                End If

                                If Not GridViewRow.Cells("dgclStockCode").Value Is DBNull.Value Then
                                    objEMDNPPT.StockCode = GridViewRow.Cells("dgclStockCode").Value
                                Else
                                    objEMDNPPT.StockCode = String.Empty
                                End If

                                'StockDetailConsignment update
                                'if the same stockcode available in the stockdetail and StockDetailConsignment proceed this step else skip this step
                                'If lsMatchCount = "Match" Then
                                Dim dsStockDetailConsignmentUpdateforEMDNApproval As New DataSet
                                dsStockDetailConsignmentUpdateforEMDNApproval = EstateMillDeliverNoteApprovalBOL.StockDetailConsignmentUpdateforEMDNApproval(objEMDNPPT)
                                If dsStockDetailConsignmentUpdateforEMDNApproval Is Nothing Then
                                    DisplayInfoMessage("Msg45")
                                    'MessageBox.Show("Failed to update StockDetailConsignment")
                                    'put delete code for the previous steps
                                    Exit Sub
                                End If
                                'End If


                                'ldTotalPriceSum += CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                                dsUpdateStockDetail = EstateMillDeliverNoteApprovalBOL.STStockDetailAvgPriceApproval(objEMDNPPT)
                                If dsUpdateStockDetail Is Nothing Then
                                    DisplayInfoMessage("Msg46")
                                    'MessageBox.Show("Failed to update stock detail")
                                    'put delete code for the previous steps
                                    Exit Sub
                                End If
                                If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("StockCOAID") Is DBNull.Value Then
                                    lStockCOAID = dsUpdateStockDetail.Tables(0).Rows(0).Item("StockCOAID")
                                Else
                                    lStockCOAID = String.Empty
                                End If
                                If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("VarianceCOAID") Is DBNull.Value Then
                                    lVarianceCOAID = dsUpdateStockDetail.Tables(0).Rows(0).Item("VarianceCOAID")
                                Else
                                    lVarianceCOAID = String.Empty
                                End If
                                If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("StdPrice") Is DBNull.Value Then
                                    lSTDPrice = dsUpdateStockDetail.Tables(0).Rows(0).Item("StdPrice")
                                Else
                                    lSTDPrice = String.Empty
                                End If
                                If Not GridViewRow.Cells("dgclStockDesc").Value Is DBNull.Value Then
                                    objEMDNApprovalPPT.Descp = GridViewRow.Cells("dgclStockDesc").Value.ToString()  ' descp=stock name
                                Else
                                    objEMDNApprovalPPT.Descp = String.Empty
                                End If



                                'IDNPRICE Start
                                objEMDNApprovalPPT.DC = "D"
                                objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                                objEMDNApprovalPPT.COAID = lStockCOAID 'Debit Store COA
                                objEMDNApprovalPPT.Value = GridViewRow.Cells("dgclTotalPrice").Value.ToString()
                                objEMDNApprovalPPT.T0 = GridViewRow.Cells("dgclTAnalysisID").Value.ToString()
                                objEMDNApprovalPPT.T1 = String.Empty
                                objEMDNApprovalPPT.T2 = String.Empty
                                objEMDNApprovalPPT.T3 = String.Empty
                                objEMDNApprovalPPT.T4 = String.Empty
                                objEMDNApprovalPPT.StationID = String.Empty
                                objEMDNApprovalPPT.Flag = "IDNPRICE"
                                intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                                objEMDNApprovalPPT.DC = "C"
                                objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtSupplier.Text.Trim() + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                                objEMDNApprovalPPT.COAID = psSupplierCOAID 'Credit Supplier COA
                                objEMDNApprovalPPT.Value = GridViewRow.Cells("dgclTotalPrice").Value.ToString()
                                objEMDNApprovalPPT.T0 = lT0ID
                                objEMDNApprovalPPT.T1 = lT1ID
                                objEMDNApprovalPPT.T2 = lT2ID
                                objEMDNApprovalPPT.T3 = lT3ID
                                objEMDNApprovalPPT.T4 = lT4ID
                                objEMDNApprovalPPT.StationID = String.Empty
                                objEMDNApprovalPPT.Flag = "IDNPRICE"
                                intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                                objEMDNApprovalPPT.T0 = String.Empty
                                objEMDNApprovalPPT.T1 = String.Empty
                                objEMDNApprovalPPT.T2 = String.Empty
                                objEMDNApprovalPPT.T3 = String.Empty
                                objEMDNApprovalPPT.T4 = String.Empty

                                'IDNPRICE End

                                ''IDNSTDPRICE Start
                                'If lSTDPrice <> 0 And lStockCOAID <> String.Empty Then
                                '    objEMDNApprovalPPT.DC = "D"
                                '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                                '    objEMDNApprovalPPT.COAID = lStockCOAID 'Debit Store COA
                                '    If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                                '        lValue = CDbl(GridViewRow.Cells("dgclReceivedQty").Value) * lSTDPrice
                                '    Else
                                '        lValue = lSTDPrice
                                '    End If
                                '    objEMDNApprovalPPT.Value = lValue
                                '    objEMDNApprovalPPT.T0 = String.Empty
                                '    objEMDNApprovalPPT.StationID = String.Empty
                                '    objEMDNApprovalPPT.Flag = "IDNSTDPRICE"
                                '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                                '    objEMDNApprovalPPT.DC = "C"
                                '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtSupplier.Text.Trim() + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                                '    objEMDNApprovalPPT.COAID = psSupplierCOAID 'Credit Supplier COA
                                '    If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                                '        lValue = CDbl(GridViewRow.Cells("dgclReceivedQty").Value) * lSTDPrice
                                '    Else
                                '        lValue = lSTDPrice
                                '    End If
                                '    objEMDNApprovalPPT.Value = lValue
                                '    objEMDNApprovalPPT.T0 = String.Empty
                                '    objEMDNApprovalPPT.StationID = String.Empty
                                '    objEMDNApprovalPPT.Flag = "IDNSTDPRICE"
                                '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                                'End If
                                ''IDNSTDPRICE End

                                ''IDNVARIANCEPRICE Start
                                'If Not GridViewRow.Cells("dgclTotalPrice").Value Is DBNull.Value Then
                                '    lIDNPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value)
                                'End If
                                'lVariancePrice = Abs(lValue - lIDNPrice)
                                'If lVariancePrice <> 0 And lVarianceCOAID <> String.Empty Then
                                '    objEMDNApprovalPPT.DC = "D"
                                '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                                '    objEMDNApprovalPPT.COAID = lVarianceCOAID  'Debit Variance COA
                                '    objEMDNApprovalPPT.Value = lVariancePrice
                                '    objEMDNApprovalPPT.T0 = String.Empty
                                '    objEMDNApprovalPPT.StationID = String.Empty
                                '    objEMDNApprovalPPT.Flag = "IDNVARIANCEPRICE"
                                '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                                '    objEMDNApprovalPPT.DC = "C"
                                '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtSupplier.Text.Trim() + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                                '    objEMDNApprovalPPT.COAID = lStockCOAID 'Credit Store COA
                                '    objEMDNApprovalPPT.Value = lVariancePrice
                                '    objEMDNApprovalPPT.T0 = String.Empty
                                '    objEMDNApprovalPPT.StationID = String.Empty
                                '    objEMDNApprovalPPT.Flag = "IDNVARIANCEPRICE"
                                '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                                'End If
                                ''IDNVARIANCEPRICE End
                                If intJournalRowsAffected = 0 Then
                                    DisplayInfoMessage("Msg47")
                                    'MessageBox.Show("Failed to Insert Journal Details transaction")
                                    Exit Sub
                                End If
                            End If
                            'lSTDPrice = 0
                            lVariancePrice = 0
                            lIDNPrice = 0
                        Next
                        'Accounts.JournalDetail.Insert end.
                        'update LedgerAllModule BatchAmount Value
                        Dim intUpdateLegerAllModuleBatchAmount As Integer = 0
                        objEMDNApprovalPPT.DC = "D"
                        objEMDNApprovalPPT.LedgerID = strLedgerID
                        intUpdateLegerAllModuleBatchAmount = EstateMillDeliverNoteApprovalBOL.STIDNLedgerAllModuleUpdate(objEMDNApprovalPPT)
                        If intUpdateLegerAllModuleBatchAmount = 0 Then
                            DisplayInfoMessage("Msg48")
                            'MessageBox.Show("Failed to Update LedgerAllModule BatchAmount")
                            Exit Sub
                        Else
                            'Call TaskMonitor Update after successful approval -Start
                            Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                            Dim dsApprovalCheck As New DataSet
                            dsApprovalCheck = StoreMonthEndClosingBOL.ApprovalCheck(objStoreMonthEndClosingPPT)
                            'Call TaskMonitor Update after successful approval -End
                        End If
                    Else
                        DisplayInfoMessage("Msg49")
                        'MessageBox.Show("Approval can not proceed.For this IDN , there is no stock code available in consignment...")
                    End If
                End If

                'FLOW III : IF LPO

                If txtLPONo.Text.Trim() <> String.Empty Then

                    '1st Step-Updadte the status in Store.Store.STMillDelivery Table

                    objEMDNPPT.Status = "APPROVED"
                    liUpdateEMDN = EstateMillDeliverNoteApprovalBOL.STMillDeliveryUpdateApproval(objEMDNPPT)
                    If liUpdateEMDN = 1 Then
                        DisplayInfoMessage("Msg50")
                        'MessageBox.Show("Approved Successfully")
                    ElseIf liUpdateEMDN = 0 Then
                        DisplayInfoMessage("Msg51")
                        'MessageBox.Show("Approval Failed")
                        Exit Sub
                    End If

                    Dim objLPOPPT As New LocalPurchaseOrderPPT
                    'Calculate and update Store.STLPODetail.PendingQty=Store.STLPODetail.PendingQty-Store.STEstMillDeliveryDet.ReceivedQty 
                    objEMDNPPT.STLPOID = lSTLPOID '"R51" 'lSTLPOID
                    objEMDNPPT.STLPODetID = lSTLPODetID
                    objEMDNPPT.STEstMillDeliveryID = lSTEstMillDeliveryID '"S28" 'lSTEstMillDeliveryID
                    objEMDNPPT.STEstMillDeliveryDetID = lSTEstMillDeliveryDetID
                    Dim intSTLPODetailUpdateForEMDNApproval As Integer
                    intSTLPODetailUpdateForEMDNApproval = EstateMillDeliverNoteApprovalBOL.STLPODetailUpdateForEMDNApproval(objEMDNPPT)
                    If intSTLPODetailUpdateForEMDNApproval = 0 Then
                        DisplayInfoMessage("Msg52")
                        'MessageBox.Show("Failed to update LPO")
                    End If
                    '-------
                    'Accounts.Ledgerallmodule insert start
                    Dim dsUpdateStockDetail As New DataSet
                    'Dim ldTotalPriceSum As Double
                    For Each GridViewRow In dgvDetails.Rows
                        If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then
                            objEMDNPPT.TotalPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                            'ldTotalPriceSum += CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())
                        End If
                    Next
                    objEMDNApprovalPPT.AYear = GlobalPPT.intActiveYear
                    objEMDNApprovalPPT.AMonth = GlobalPPT.IntActiveMonth
                    objEMDNApprovalPPT.LedgerDate = dtpIDNDate.Value 'IDNDate
                    objEMDNApprovalPPT.LedgerType = "STORE-IDN"

                    'If txtRemarks.Text.Trim() <> String.Empty Then
                    '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + txtRemarks.Text.Trim() 'IDNRemarks
                    'Else
                    '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim()
                    'End If

                    If txtRemarks.Text.Trim() <> String.Empty Then
                        objEMDNApprovalPPT.Descp = lLPONo + "-" + txtRemarks.Text.Trim() 'IDNRemarks
                    Else
                        objEMDNApprovalPPT.Descp = lLPONo
                    End If
                    'objEMDNApprovalPPT.BatchAmount = ldTotalPriceSum
                    Dim dsRowsAffectedLedgerAllModule As New DataSet
                    Dim strLedgerID As String
                    dsRowsAffectedLedgerAllModule = EstateMillDeliverNoteApprovalBOL.STIDNLedgerAllModuleInsert(objEMDNApprovalPPT)
                    strLedgerID = dsRowsAffectedLedgerAllModule.Tables(0).Rows(0).Item("LedgerID")
                    objEMDNApprovalPPT.LedgerID = strLedgerID
                    'Accounts.Ledgerallmodule insert end

                    'Accounts.JournalDetail.Insert start.
                    Dim lStockCOAID As String, lVarianceCOAID As String = String.Empty
                    Dim lIDNPrice As Double, lSTDPrice As Double ', lVariancePrice As Double, lValue As Double
                    Dim intJournalRowsAffected As Integer = 0
                    For Each GridViewRow In dgvDetails.Rows
                        If GridViewRow.Cells("dgclStockId").Value.ToString() <> String.Empty Then

                            objEMDNPPT.StockID = GridViewRow.Cells("dgclStockId").Value.ToString()
                            If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                                objEMDNPPT.ReceivedQty = CDbl(GridViewRow.Cells("dgclReceivedQty").Value)
                            Else
                                objEMDNPPT.ReceivedQty = 0
                            End If
                            If Not GridViewRow.Cells("dgclTotalPrice").Value Is DBNull.Value Then
                                objEMDNPPT.TotalPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value)
                            Else
                                objEMDNPPT.TotalPrice = 0
                            End If

                            If Not GridViewRow.Cells("dgclReceivedPrice").Value Is DBNull.Value Then
                                objEMDNPPT.ReceivedPrice = CDbl(GridViewRow.Cells("dgclReceivedPrice").Value)
                            Else
                                objEMDNPPT.ReceivedPrice = 0
                            End If

                            'ldTotalPriceSum += CDbl(GridViewRow.Cells("dgclTotalPrice").Value.ToString())

                            dsUpdateStockDetail = EstateMillDeliverNoteApprovalBOL.STStockDetailAvgPriceApproval(objEMDNPPT)
                            If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("StockCOAID") Is DBNull.Value Then
                                lStockCOAID = dsUpdateStockDetail.Tables(0).Rows(0).Item("StockCOAID")
                            Else
                                lStockCOAID = String.Empty
                            End If
                            If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("VarianceCOAID") Is DBNull.Value Then
                                lVarianceCOAID = dsUpdateStockDetail.Tables(0).Rows(0).Item("VarianceCOAID")
                            Else
                                lVarianceCOAID = String.Empty
                            End If
                            If Not dsUpdateStockDetail.Tables(0).Rows(0).Item("StdPrice") Is DBNull.Value Then
                                lSTDPrice = lSTDPrice = dsUpdateStockDetail.Tables(0).Rows(0).Item("StdPrice")
                            Else
                                lSTDPrice = 0
                            End If
                            If Not GridViewRow.Cells("dgclStockDesc").Value.ToString() Is DBNull.Value Then
                                objEMDNApprovalPPT.Descp = GridViewRow.Cells("dgclStockDesc").Value.ToString()  ' descp=stock name
                            Else
                                objEMDNApprovalPPT.Descp = String.Empty
                            End If

                            If dsUpdateStockDetail Is Nothing Then
                                DisplayInfoMessage("Msg53")
                                'MessageBox.Show("Failed to update stock detail")
                                'put delete code for the previous steps
                                Exit Sub
                            End If

                            'IDNPRICE Start
                            objEMDNApprovalPPT.DC = "D"
                            'objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            objEMDNApprovalPPT.Descp = lLPONo + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            objEMDNApprovalPPT.COAID = lStockCOAID 'Debit Store COA
                            objEMDNApprovalPPT.Value = GridViewRow.Cells("dgclTotalPrice").Value.ToString()
                            objEMDNApprovalPPT.T0 = GridViewRow.Cells("dgclTAnalysisID").Value.ToString()

                            objEMDNApprovalPPT.T1 = String.Empty
                            objEMDNApprovalPPT.T2 = String.Empty
                            objEMDNApprovalPPT.T3 = String.Empty
                            objEMDNApprovalPPT.T4 = String.Empty
                            objEMDNApprovalPPT.StationID = String.Empty
                            objEMDNApprovalPPT.Flag = "IDNPRICE"
                            intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                            objEMDNApprovalPPT.DC = "C"
                            'objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + lLPOSupplierName.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            objEMDNApprovalPPT.Descp = lLPONo + "-" + lLPOSupplierName.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            objEMDNApprovalPPT.COAID = psSupplierCOAID 'Credit Supplier COA
                            objEMDNApprovalPPT.Value = GridViewRow.Cells("dgclTotalPrice").Value.ToString()

                            'objEMDNApprovalPPT.T0 = String.Empty

                            'Temoprarily Anand request to include estatecode until client confirm on Dec 01 2010 in finding nov 29 doc Start
                            Dim dtT0 As DataTable
                            dtT0 = EstateMillDeliverNoteApprovalBOL.IDNLPOT0Select()
                            objEMDNApprovalPPT.T0 = dtT0.Rows(0).Item("TAnalysisID")
                            'Temoprarily Anand request to include estatecode until client confirm on Dec 01 2010 in finding nov 29 doc End

                            objEMDNApprovalPPT.T1 = String.Empty
                            objEMDNApprovalPPT.T2 = String.Empty
                            objEMDNApprovalPPT.T3 = String.Empty
                            objEMDNApprovalPPT.T4 = String.Empty
                            objEMDNApprovalPPT.StationID = String.Empty

                            objEMDNApprovalPPT.Flag = "IDNPRICE"
                            intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                            'IDNPRICE End

                            ''STDPRICE Start
                            'If lSTDPrice <> 0 Then
                            '    objEMDNApprovalPPT.DC = "D"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            '    objEMDNApprovalPPT.COAID = lStockCOAID 'Debit Store COA
                            '    If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                            '        lValue = CDbl(GridViewRow.Cells("dgclReceivedQty").Value) * lSTDPrice
                            '    Else
                            '        lValue = lSTDPrice
                            '    End If
                            '    objEMDNApprovalPPT.Value = lValue
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "STDPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                            '    objEMDNApprovalPPT.DC = "C"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + lLPOSupplierName.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            '    objEMDNApprovalPPT.COAID = psSupplierCOAID 'Credit Supplier COA
                            '    If Not GridViewRow.Cells("dgclReceivedQty").Value Is DBNull.Value Then
                            '        lValue = CDbl(GridViewRow.Cells("dgclReceivedQty").Value) * lSTDPrice
                            '    Else
                            '        lValue = lSTDPrice
                            '    End If
                            '    objEMDNApprovalPPT.Value = lValue
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "STDPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                            'End If
                            ''STDPRICE End

                            ''VARIANCEPRICE Start
                            'If Not GridViewRow.Cells("dgclTotalPrice").Value Is DBNull.Value Then
                            '    lIDNPrice = CDbl(GridViewRow.Cells("dgclTotalPrice").Value)
                            'End If
                            'lVariancePrice = Abs(lValue - lIDNPrice)
                            'If lVariancePrice <> 0 Then
                            '    objEMDNApprovalPPT.DC = "D"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + GridViewRow.Cells("dgclStockCode").Value.ToString() + "-" + GridViewRow.Cells("dgclStockDesc").Value.ToString() '“<IDN  No”>- as in IDN screen<”StockCode - Stock Description” as selected in the IDN>
                            '    objEMDNApprovalPPT.COAID = lVarianceCOAID  'Debit Variance COA
                            '    objEMDNApprovalPPT.Value = lVariancePrice
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "VARIANCEPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

                            '    objEMDNApprovalPPT.DC = "C"
                            '    objEMDNApprovalPPT.Descp = txtIDNNo.Text.Trim() + "-" + lLPOSupplierName.Trim + " " + strLoginMonthName + GlobalPPT.intLoginYear.ToString() '“<IDN  No”>- as in IDN screen-SupplierName Nov2009
                            '    objEMDNApprovalPPT.COAID = lStockCOAID 'Credit Store COA
                            '    objEMDNApprovalPPT.Value = lVariancePrice
                            '    objEMDNApprovalPPT.T0 = String.Empty
                            '    objEMDNApprovalPPT.StationID = String.Empty
                            '    objEMDNApprovalPPT.Flag = "VARIANCEPRICE"
                            '    intJournalRowsAffected = EstateMillDeliverNoteApprovalBOL.STIDNJournalDetailInsert(objEMDNApprovalPPT)
                            'End If
                            ''VARIANCEPRICE End
                            If intJournalRowsAffected = 0 Then
                                DisplayInfoMessage("Msg54")
                                'MessageBox.Show("Failed to Insert Journal Details transaction")
                                Exit Sub
                            End If
                        End If
                        lSTDPrice = 0
                        'lVariancePrice = 0
                        lIDNPrice = 0
                    Next
                    'Accounts.JournalDetail.Insert end.
                    '-------
                    'update LedgerAllModule BatchAmount Value
                    Dim intUpdateLegerAllModuleBatchAmount As Integer = 0
                    objEMDNApprovalPPT.DC = "D"
                    objEMDNApprovalPPT.LedgerID = strLedgerID
                    intUpdateLegerAllModuleBatchAmount = EstateMillDeliverNoteApprovalBOL.STIDNLedgerAllModuleUpdate(objEMDNApprovalPPT)
                    If intUpdateLegerAllModuleBatchAmount = 0 Then
                        DisplayInfoMessage("Msg55")
                        'MessageBox.Show("Failed to Update LedgerAllModule BatchAmount")
                        Exit Sub
                    Else
                        'Call TaskMonitor Update after successful approval -Start
                        Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                        Dim dsApprovalCheck As New DataSet
                        dsApprovalCheck = StoreMonthEndClosingBOL.ApprovalCheck(objStoreMonthEndClosingPPT)
                        'Call TaskMonitor Update after successful approval -End
                    End If
                End If

                GlobalPPT.IsButtonClose = True
                Me.Close()

            End If
        ElseIf cmbStatus.SelectedItem.ToString() = "REJECTED" Then
            If txtRejectedReason.Text.Trim() = String.Empty Then
                DisplayInfoMessage("Msg56")
                'MessageBox.Show("Please enter the rejected reason")
                txtRejectedReason.Focus()
                Exit Sub
            ElseIf MsgBox(rm.GetString("Msg57"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'ElseIf MsgBox("You are about to Reject the  record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                objEMDNPPT.Status = "REJECTED"
                objEMDNPPT.RejectedReason = txtRejectedReason.Text.Trim()
                liUpdateEMDN = EstateMillDeliverNoteApprovalBOL.STMillDeliveryUpdateApproval(objEMDNPPT)
                If liUpdateEMDN = 1 Then
                    DisplayInfoMessage("Msg58")
                    'MessageBox.Show("Rejected Successfully")
                    txtRejectedReason.Text = String.Empty
                ElseIf liUpdateEMDN = 0 Then
                    DisplayInfoMessage("Msg59")
                    'MessageBox.Show("Approval Failed")
                    Exit Sub
                End If

                GlobalPPT.IsButtonClose = True
                Me.Close()

            End If
        End If
        DialogResult = DialogResult.OK

    End Sub

    'For Approval By Arulprakasan



    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click

        ResetAll()
        EnableFieldsInEntry()
        'btnSaveAll.Text = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        btnSaveAll.Enabled = True
        cbTransType.Enabled = True
        txtIPRNo.ReadOnly = False
        txtSupplier.ReadOnly = False
        txtLPONo.ReadOnly = False
        TransType_Change()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditUpdateToolStripMenuItem1, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub ChkLPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''If ChkLPO.Checked = True Then
        ''    Load_LPONo()
        ''    cbviewLPONo.Text = "Select All"
        ''End If
        'Load_LPONo()
        'If ChkLPO.Checked = False Then
        '    cbviewLPONo.Text = String.Empty
        'End If
        'ChkIPR.Checked = False
        'cbviewIPRNo.DataSource = Nothing
    End Sub

    Private Sub ChkIPR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Load_IPRNo()
        'If ChkIPR.Checked = False Then
        '    cbviewIPRNo.Text = String.Empty
        'End If
        'ChkLPO.Checked = False
        'cbviewLPONo.DataSource = Nothing
    End Sub

    Private Sub txtT0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT0.Leave
        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.T0Value = txtT0.Text.Trim()
            objSIV.TDecide = "T0"
            ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg60")
                'MessageBox.Show(" Invalid T0 Value ", "T0 value can select from look up", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.lblT0Name.Text = String.Empty
                Me.txtT0.Text = String.Empty
                'psSIVT0analysisID = String.Empty
                txtT0.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
                    lT0IDDesc = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()

                End If
                If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
                    txtT0.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
                End If
                lT0ID = ds.Tables(0).Rows(0).Item("TAnalysisId").ToString()
            End If
        Else
            'Me.lblT0Name.Text = String.Empty
            Me.txtT0.Text = String.Empty
            'psSIVT0analysisID = String.Empty
        End If
    End Sub

    Private Sub rbtnIPR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnIPR.CheckedChanged
        Load_IPRNo()
        'cbviewIPRNo.Text = "--SELECT--"
        If rbtnIPR.Checked = False Then
            cbviewIPRNo.Text = String.Empty
        End If
        'rbtnLPONo.Checked = False
        cbviewLPONo.DataSource = Nothing
    End Sub

    Private Sub rbtnLPONo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnLPONo.CheckedChanged
        'If ChkLPO.Checked = True Then
        '    Load_LPONo()
        '    cbviewLPONo.Text = "Select All"
        'End If
        Load_LPONo()
        'cbviewLPONo.Text = "--SELECT--"
        If rbtnLPONo.Checked = False Then
            cbviewLPONo.Text = String.Empty
        End If
        'rbtnIPR.Checked = False
        cbviewIPRNo.DataSource = Nothing
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click

        Dim ObjRecordExist As New Object
        Dim ObjEMDN As New EstateMillDeliveryNotePPT
        Dim ObjEMDNBOL As New EstateMillDeliveryNoteBOL
        ObjRecordExist = ObjEMDNBOL.EMDNRecordIsExisT(ObjEMDN)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg61")
            'MsgBox("No Records Available!")
        Else

            StrFrmName = "EstMillDelivery"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        Dim intRowcount As Integer = dgvDetails.CurrentRow.Index
        dgvDetails.Rows.RemoveAt(intRowcount)
    End Sub

    Private Sub cbviewDeliverySource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbviewDeliverySource.SelectedIndexChanged
        'cbDeliveySource.Text = cbDeliveySource.SelectedText
        'Load_PONo()
    End Sub


    Private Sub dgvIDNView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIDNView.CellContentClick

        If e.ColumnIndex = 19 Then

            Dim ObjRecordExist As New Object
            Dim ObjEMDN As New EstateMillDeliveryNotePPT
            Dim ObjEMDNBOL As New EstateMillDeliveryNoteBOL
            ObjRecordExist = ObjEMDNBOL.EMDNRecordIsExisT(ObjEMDN)

            If ObjRecordExist = 0 Then
                DisplayInfoMessage("Msg61")
                'MsgBox("No Records Available!")
            Else
                psSTEstMillDeliveryID = dgvIDNView.SelectedRows(0).Cells("dgclSTEstMillDeliveryID").Value.ToString
                StrFrmName = "EstMillDelivery"
                ReportODBCMethod.ShowDialog()
                StrFrmName = ""
                psSTEstMillDeliveryID = ""
            End If

        End If

    End Sub



    Private Sub chkIDNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIDNDate.CheckedChanged

        If chkIDNDate.Checked = True Then
            dtpviewIDNDate.Enabled = True
        Else
            dtpviewIDNDate.Enabled = False
        End If

    End Sub

    Private Sub EstateMillDeliveryNoteFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If (dgvDetails.RowCount > 0 And (lblStatusDesc.Text.Trim = "OPEN" Or lblStatusDesc.Text.Trim = "REJECTED") And GlobalPPT.IsButtonClose = False And btnSaveAll.Enabled = True) Then
            If MsgBox(rm.GetString("Msg65"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M4"
                'mdiparent.lblMenuName.Text = "IPR"
            End If

        End If

    End Sub

    Private Sub BtnVehicle_Click(sender As System.Object, e As System.EventArgs) Handles BtnVehicle.Click
        Dim objIPRNo As New VHNoLookup()
        Dim result As DialogResult = objIPRNo.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            txtVehicleNo.Text = objIPRNo.psVHWSCode
        End If
    End Sub

    Private Sub txtReceivedQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReceivedQty.TextChanged
        If Me.txtReceivedQty.Text <> "" Then
            If Me.txtReceivedQty.Text < 0 Then
                Me.txtReceivedQty.Text = "0"
            End If
        End If


    End Sub
End Class