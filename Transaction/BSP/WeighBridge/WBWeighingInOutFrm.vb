Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Production_BOL
Imports Production_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Math
Imports System.IO.Ports
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.IO
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports System.Configuration
Imports Common_DAL

Public Class WBWeighingInOutFrm
    'For DataImport
    Private strQry As String
    Private dsMain As DataSet
    Private dblRwCntr As Integer
    'Private intCntr As Integer
    Private sr As StreamWriter
    Private IsError As Boolean
    Private fname As String
    Private TimeTaken As DateTime
    Private TimeTakenStr As String

    Private comm As New CommManager()

    Private lVehicleCode As String = String.Empty
    Private lSupplier As String = String.Empty
    Private lProductCode As String = String.Empty
    Private lSupplietDetID As String = String.Empty
    Private lSupplierCustID As String = String.Empty
    Private lProductID As String = String.Empty
    Private lProductDesc As String = String.Empty
    Private lWBTicketNo As String = String.Empty
    Private lWeighingID As String = String.Empty
    Private lOthers As Integer = Nothing
    Private lManualWeight As Integer = Nothing
    Private lDivision As String = String.Empty
    Private lYop As String = String.Empty
    Private lNetWeight As String = String.Empty
    Private lWBWeighingBlockID As String = String.Empty
    Private ltotal As Integer = 0
    Private lcount As Integer = Nothing
    Private lNoofrows As Integer = Nothing
    Private DTFlag As Boolean = False
    Public Shared PrintFlag As Boolean = False
    Private AddFlag As Boolean = True
    Private DataTableBind As Boolean = False
    Private GradingFFBFlag As Boolean = False
    Private IIWeight As Boolean = False
    Private IWeight As Boolean = False
    'Private lWeight As String = String.Empty



    Dim myDataTable As New DataTable("FieldBlockSetup")
    Dim myDataColumn As DataColumn
    Dim myDataRow As DataRow
    Dim total As Integer = 0
    Dim intRowcount As Integer = myDataTable.Rows.Count
    Dim isDecimal, isModifierKey As Boolean 'Declaration for to allow double only
    Dim reDecimalPlaces3 As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")

    Public Shared WBRicketNo As String = String.Empty
    Public Shared StrFrmName As String = String.Empty
    Public Shared Others As String = String.Empty
    Public Shared lWeight As String = String.Empty

    Dim strDiv, strYOP, strBlock As String
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    'Portal 
#Region "Region Weibride"
    ' Dim WithEvents WBPort As SerialPort = _
    '             New SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)
    Private WBOCP As New Rs232()

#End Region


    Private Sub WBWeighingInOutFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub WBWeighingInOutFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If


        Common_BOL.GlobalBOL.SetDateTimePickerSTORE(Me.dtpviewIIWeighingDate)


        Dim MdiParent As New MDIParent
        If MdiParent.strMenuID = "M84" Then

            Dim dt As DataTable
            Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
            Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

            dt = objWBTicketInOutBOL.WBTicketNoRecord_isExist(objWBTicketInOutPPT)

            StrFrmName = "WBWeighingInOutRpt"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        Else
            Datefunction()
            Select_WbTicketNo()
            cmbYOP.DataSource = Nothing
            Me.txtFirstWeight.ReadOnly = True
            Me.txtSecondWeight.ReadOnly = True
            ReadonlyFalse(txtFirstWeight)
            ReadonlyTrue(txtSecondWeightManual)
            ReadonlyTrue(txtFirstWeightManual)
            ReadonlyTrue(txtSecondWeight)
            Me.txtNetWeightManual.ReadOnly = True
            Me.txtNetWeight.ReadOnly = True
            Me.txtSection.ReadOnly = True
            Me.txtWBTicketNo.ReadOnly = True
            Me.txtTime.ReadOnly = True
            Me.txtNoTrip.ReadOnly = True
            Me.txtTotalBunches.ReadOnly = True
            Me.txtTotalLooseFruit.ReadOnly = True
            Me.txtTotalKetek.ReadOnly = True
            Me.btnSave.Enabled = True
            Me.btnUpdate.Enabled = False
            Me.txtTotalBunches.Text = 0
            Me.txtTotalLooseFruit.Text = 0
            Me.txtTotalKetek.Text = 0
            dtpviewWeighingDate.Format = DateTimePickerFormat.Custom
            dtpviewWeighingDate.CustomFormat = "dd/MM/yyyy"
            dtpviewWeighingDate.Enabled = False
            dtpviewIIWeighingDate.Format = DateTimePickerFormat.Custom
            dtpviewIIWeighingDate.CustomFormat = "dd/MM/yyyy"
            dtpviewIIWeighingDate.Enabled = False
            SetUICulture(GlobalPPT.strLang)
            'tcWeighingInOut.SelectedTab = tpView
            tcWeighingInOut.SelectedTab = tpImport

            WBViewIIWeight_Bind()

            WBView_Bind()
            gbSave.Visible = False
            lblTextmsg.Visible = False
            lblcolon21.Visible = False
            lblTimeOut.Visible = False
            txtTimeOut.Visible = False

            lblFieldBlockSetupID.Visible = False
            cmbDivision.Enabled = False
            cmbYOP.Enabled = False
            cmbTPH.Enabled = False
            'Port 
            '"COM1", 9600, Parity.None, 8, StopBits.One
            'WBOCP.Open("COM1", 9600, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096)
            WBTimer.Enabled = False
        End If
    End Sub

    Private Sub Datefunction()
        If txtDate.Text = String.Empty Then
            txtDate.Text = Format(System.DateTime.Now, "dd/MM/yyyy")
        End If
        txtTime.Text = Convert.ToDateTime(System.DateTime.Now).ToShortTimeString
        txtSection.Text = IIf(Mid(txtTime.Text, Len(txtTime.Text) - 1, Len(txtTime.Text)) = "AM", "Morning", "Evening")
        txtTime.Text = System.DateTime.Now.ToString("HH:mm")
    End Sub

    Private Function IsFormValid()
        If Me.chkOthers.Checked = False Then
            If Me.txtWBTicketNo.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("WBTicketNo Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtWBTicketNo.Focus()
                Return False
            End If
            If Me.txtVehicleCode.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg2")
                ''MessageBox.Show("Vehicle Code Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tcWeighingInOut.SelectedIndex = 0
                Me.txtVehicleCode.Focus()
                Return False
            End If
            If Me.txtProductCode.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg3")
                ''MessageBox.Show("Product Code Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tcWeighingInOut.SelectedIndex = 0
                Me.txtProductCode.Focus()
                Return False
            End If
            If Me.txtSupplier.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg44")
                'MessageBox.Show("Supplier Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                tcWeighingInOut.SelectedIndex = 0
                Me.txtSupplier.Focus()
                Return False
            End If
            If Me.txtNoTrip.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg4")
                ''MessageBox.Show("No.of Trip Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNoTrip.Focus()
                Return False
            End If
        Else
            If Me.txtWBTicketNo.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg5")
                ''MessageBox.Show("WBTicketNo Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtWBTicketNo.Focus()
                Return False
            End If
            If Me.txtRemarks.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg6")
                ''MessageBox.Show("Remarks Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRemarks.Focus()
                Return False
            End If
        End If

        If chkManualWeight.Checked = True And txtFirstWeightManual.Text = String.Empty Then
            DisplayInfoMessage("Msg7")
            '' MessageBox.Show("Manual First Weight Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tcWeighingInOut.SelectedIndex = 0
            txtFirstWeightManual.Focus()
            Return False
        ElseIf chkManualWeight.Checked = False And txtFirstWeight.Text = String.Empty Then
            DisplayInfoMessage("Msg8")
            'MessageBox.Show("First Weight Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFirstWeight.Focus()
            Return False
        End If

        If lblProductDesc.Text <> "FFB" And dgvFieldBlockSetup.Rows.Count > 0 Then
            MessageBox.Show("Delete all Field Block details and proceed", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Return True
    End Function

    Private Function IsGridValid()


        If cmbBlock.Text.Trim = String.Empty Or cmbBlock.Text.Trim = "-Select-" Then
            DisplayInfoMessage("Msg11")
            '' MessageBox.Show("Block Field Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbBlock.Focus()
            Return False
        End If
        If cmbYOP.Text.Trim = String.Empty Or cmbYOP.Text.Trim = "-Select-" Then
            DisplayInfoMessage("Msg10")
            ''MessageBox.Show("YOP Field Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbYOP.Focus()
            Return False
        End If
        If cmbDivision.Text.Trim = String.Empty Or cmbDivision.Text.Trim = "-Select-" Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("Division Field Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbDivision.Focus()
            Return False
        End If
        If cmbTPH.SelectedValue.ToString().Length = 0 Then
            MessageBox.Show("TPH Field Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbTPH.Focus()
            Return False
        End If

        If txtQtyFFB.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show("QtyFFB Field Required", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQtyFFB.Focus()
            Return False
        End If
        If txtQtyFFB.Text.Trim < 0 Then
            DisplayInfoMessage("Msg13")
            ''MessageBox.Show("FFB Bunches cannot be less than Zero", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQtyFFB.Focus()
            Return False
        End If

        If txtQtyFFB.Text = 0 And txtLooseFruit.Text = 0 Then
            DisplayInfoMessage("Msg46")
            txtQtyFFB.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not IsFormValid() Then Exit Sub
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        Dim dt As New DataTable
        Dim rowsaffected As Integer = 0
        Dim WBTicketNoCount As Integer = 0

        If Me.chkOthers.Checked = True Then
            Me.lOthers = 1
        Else
            Me.lOthers = 0
        End If

        If Me.chkManualWeight.Checked = True Then
            Me.lManualWeight = 1
        Else
            Me.lManualWeight = 0
        End If

        With objWBTicketInOutPPT
            .WeighingID = lWeighingID
            Dim str As String = txtDate.Text.Trim
            .WeighingDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            .WeighingTime = txtTime.Text.ToString
            .Section = txtSection.Text.Trim
            .Others = lOthers
            .WBTicketNo = txtWBTicketNo.Text.Trim
            .FFBDeliveryOrderNo = txtFFBDeliveryOrderNoFB.Text.Trim
            .SupplierDetID = lSupplietDetID   'txtVehicleCode.Text
            .SupplierCustID = lSupplierCustID 'txtSupplier.Text
            .ProductID = lProductID           'txtProductCode.Text
            .DriverName = txtDriver.Text.Trim
            .NoTrip = IIf(txtNoTrip.Text.Trim <> Nothing, txtNoTrip.Text.Trim, Nothing)
            If chkManualWeight.Checked = True Then
                .FirstWeight = Convert.ToDecimal(txtFirstWeightManual.Text.Trim)
            Else
                .FirstWeight = Convert.ToDecimal(txtFirstWeight.Text.Trim)
            End If
            .ManualWeight = lManualWeight
            .Remarks = txtRemarks.Text.Trim
        End With

        'If lWeighingID = "" Then
        dt = objWBTicketInOutBOL.WBTicketNo_isExist(objWBTicketInOutPPT) 'for Validation process IDN No. and GRN No. is exists
        If dt.Rows.Count <> 0 Then
            WBTicketNoCount = dt.Rows(0).Item("WBTicketNoCount")
            If WBTicketNoCount > 0 Then
                DisplayInfoMessage("Msg14")
                ''MessageBox.Show("WB Ticket No.  already exist", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                dt = objWBTicketInOutBOL.Save_WBWeighingInOut(objWBTicketInOutPPT) 'Saving Prosses
                If dt.Rows.Count <> 0 Then
                    lWeighingID = dt.Rows(0).Item("WeighingID").ToString()
                Else
                    DisplayInfoMessage("Msg15")
                    ''MessageBox.Show("Failed, to insert Records", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        End If

        Dim DataGridViewRow As DataGridViewRow
        For Each DataGridViewRow In dgvFieldBlockSetup.Rows
            With objWBTicketInOutPPT
                objWBTicketInOutPPT.WeighingID = lWeighingID
                objWBTicketInOutPPT.Division = DataGridViewRow.Cells("gvDivision").Value
                objWBTicketInOutPPT.YOP = DataGridViewRow.Cells("gvYOP").Value
                objWBTicketInOutPPT.Block = DataGridViewRow.Cells("gvBlock").Value
                objWBTicketInOutPPT.QtyFFB = DataGridViewRow.Cells("gvQuality").Value
                objWBTicketInOutPPT.FieldBlockSetupID = DataGridViewRow.Cells("gvFieldBlockSetupID").Value
                If Not String.IsNullOrEmpty(objWBTicketInOutPPT.Division) Then
                    dt = objWBTicketInOutBOL.Save_WBWeighingBlockDetail(objWBTicketInOutPPT)
                Else
                    DisplayInfoMessage("Msg15")
                    '' MessageBox.Show("Failed, to insert Records", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End With
        Next
        objWBTicketInOutBOL.UpdateAllocatedWeightBlock(lWeighingID)
        DisplayInfoMessage("Msg16")
        ClearEntryForm()
        SingleEntry()
        Select_WbTicketNo()
        Datefunction()
        'ClearGridView(dgvFieldBlockSetup)
        dgvFieldBlockSetup.DataSource = Nothing
        Clear_MultiEntry()
        cmbDivision.Text = "-SELECT-"
        PrintFlag = False
        WBRicketNo = objWBTicketInOutPPT.WBTicketNo

        StrFrmName = "WBTicketNORpt"
        'ReportODBCMethod.CrystalReportViewer1.Visible = False
        'ReportODBCMethod.ShowDialog()
        'ReportODBCMethod.CrystalReportViewer1.PrintReport()
        'StrFrmName = ""
        'ReportODBCMethod.Close()
        'ReportODBCMethod.ShowDialog()

        'WBTicketNoReport.ShowDialog()
        'txtFirstWeight.ReadOnly = False
        'txtFirstWeightManual.ReadOnly = False
        'ReadonlyFalse(txtFirstWeight)
        'chkManualWeight.Checked = True
        chkOthers.Checked = False
        DTFlag = True
        txtVehicleCode.Focus()
        tcWeighingInOut.SelectedIndex = 0
    End Sub

    Private Sub Select_WbTicketNo()
        Dim dt As New DataTable
        Dim objWBTicketNoPPT As New WBWeighingInOutPPT
        Dim objWBTicketNoBOL As New WBWeighingInOutBOL
        If Me.chkOthers.Checked = False Then
            Me.lOthers = 0
        Else
            Me.lOthers = 1
        End If
        objWBTicketNoPPT.Others = lOthers
        dt = objWBTicketNoBOL.WBTicketNo_Select(objWBTicketNoPPT)
        If dt.Rows.Count > 0 Then
            objWBTicketNoPPT.WBTicketNo = dt.Rows(0).Item("WBTicketNo").ToString()
            If objWBTicketNoPPT.WBTicketNo <> String.Empty Then
                txtWBTicketNo.Text = objWBTicketNoPPT.WBTicketNo
            Else
                DisplayInfoMessage("Msg17")
                ''MessageBox.Show("Please enter Serial No in WBTicket No Configuration", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub tofindNoofTrip()
        ' To bind NoofTrip

        Dim test As String = String.Empty
        Dim dt As New DataTable
        Dim objWBTicketNoPPT As New WBWeighingInOutPPT
        Dim objWBTicketNoBOL As New WBWeighingInOutBOL
        Dim str As String = Me.txtDate.Text.Trim
        With objWBTicketNoPPT
            .VehicleCode = txtVehicleCode.Text
            .WeighingDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
        End With
        dt = objWBTicketNoBOL.NoofTrip_Get(objWBTicketNoPPT)
        If dt.Rows.Count > 0 Then
            txtNoTrip.Text = dt.Rows(0).Item("NoofTrip").ToString()
            'Else
            '    MessageBox.Show("Please enter Serial No in WBTicket No Configuration", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnSearchVehicleCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchVehicleCode.Click
        Dim Vehiclecode As New VehicleCodeLookUp()
        Dim result As DialogResult = VehicleCodeLookUp.ShowDialog()

        If VehicleCodeLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            txtVehicleCode.Text = VehicleCodeLookUp._lVehicleCode
            lSupplietDetID = VehicleCodeLookUp._lSupplierDetID
            tofindNoofTrip()
            If txtVehicleCode.Text <> String.Empty Then
                txtVehicleCode.Focus()
            Else
                txtNoTrip.Text = String.Empty
            End If
        Else
            txtVehicleCode.Focus()
        End If
    End Sub

    Private Sub btnSearchProductCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchProductCode.Click
        Dim ProductCode As New WBProductCodeLookUp()
        Dim result As DialogResult = WBProductCodeLookUp.ShowDialog()

        If WBProductCodeLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            txtProductCode.Text = WBProductCodeLookUp._lProductCode
            lblProductDesc.Text = WBProductCodeLookUp._lProductDesc
            lProductID = WBProductCodeLookUp._lProductID
            txtProductCode.Focus()
        Else
            txtProductCode.Focus()
        End If
    End Sub

    Private Sub btnSearchSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSupplier.Click
        Dim Supplier As New WBSupplierLookUp()
        Dim result As DialogResult = WBSupplierLookUp.ShowDialog()
        If WBSupplierLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            txtSupplier.Text = WBSupplierLookUp._lSupplierCode
            txtProductCode.Text = WBSupplierLookUp._lProductCode
            lSupplierCustID = WBSupplierLookUp._lSupplierCustID
            lProductID = WBSupplierLookUp._lProductID
            lblProductDesc.Text = WBSupplierLookUp._lProductDesc
            txtSupplier.Focus()
        Else
            txtSupplier.Focus()
        End If
    End Sub

    Private Sub chkOthers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOthers.CheckedChanged
        Dim dt As New DataTable
        Dim objWBTicketNoPPT As New WBWeighingInOutPPT
        Dim objWBTicketNoBOL As New WBWeighingInOutBOL
        If Me.chkOthers.Checked = True Then
            txtProductCode.ReadOnly = True
            txtProductCode.TabStop = False
            txtVehicleCode.ReadOnly = True
            txtVehicleCode.TabStop = False
            txtSupplier.ReadOnly = True
            txtSupplier.TabStop = False
            txtDriver.ReadOnly = True
            txtDriver.TabStop = False
            txtNoTrip.ReadOnly = True
            txtTotalBunches.ReadOnly = True
            txtTotalLooseFruit.ReadOnly = True
            txtTotalBunches.Text = String.Empty
            txtTotalLooseFruit.Text = String.Empty
            txtTotalKetek.Text = String.Empty
            txtQtyFFB.ReadOnly = True
            txtQtyFFB.TabStop = False
            txtDate.Text = String.Empty

            txtSection.Text = String.Empty
            txtTime.Text = String.Empty
            cmbDivision.Enabled = False
            cmbYOP.Enabled = False
            cmbBlock.Enabled = False
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            btnSearchVehicleCode.Enabled = False
            btnSearchSupplier.Enabled = False
            btnSearchProductCode.Enabled = False
            dgvFieldBlockSetup.Enabled = False
            lblRemarks.ForeColor = Color.Red
            ClearEntryForm()
            Datefunction()
            lblFFBDeleiveryOrderNo.ForeColor = Color.Black
            txtFFBDeliveryOrderNo.Text = String.Empty
            txtFFBDeliveryOrderNo.Enabled = False
            lblProductCode.ForeColor = Color.Black
            lblVehicleCode.ForeColor = Color.Black
            lblSupplier.ForeColor = Color.Black
            lblDriver.ForeColor = Color.Black
            lblNoTrip.ForeColor = Color.Black
            'ClearGridView(dgvFieldBlockSetup)
            dgvFieldBlockSetup.DataSource = Nothing
        Else
            txtProductCode.ReadOnly = False
            txtProductCode.TabStop = True
            txtVehicleCode.ReadOnly = False
            txtVehicleCode.TabStop = True
            txtSupplier.ReadOnly = False
            txtSupplier.TabStop = True
            txtDriver.ReadOnly = False
            txtDriver.TabStop = True
            txtDate.Text = String.Empty

            txtSection.Text = String.Empty
            txtTime.Text = String.Empty
            txtTotalBunches.ReadOnly = True
            txtTotalLooseFruit.ReadOnly = True
            txtQtyFFB.ReadOnly = False
            txtQtyFFB.TabStop = True
            cmbDivision.Enabled = True
            cmbYOP.Enabled = True
            cmbBlock.Enabled = True
            btnAdd.Enabled = True
            btnDelete.Enabled = True
            btnSearchVehicleCode.Enabled = True
            btnSearchSupplier.Enabled = True
            btnSearchProductCode.Enabled = True
            dgvFieldBlockSetup.Enabled = True
            lblRemarks.ForeColor = Color.Black
            ClearEntryForm()
            Datefunction()
            txtFFBDeliveryOrderNo.Enabled = True
            lblProductCode.ForeColor = Color.Red
            lblVehicleCode.ForeColor = Color.Red
            lblSupplier.ForeColor = Color.Red
            lblNoTrip.ForeColor = Color.Red
        End If

        If Me.chkOthers.Checked = True Then
            Me.lOthers = 1
        Else
            Me.lOthers = 0
        End If
        objWBTicketNoPPT.Others = lOthers
        dt = objWBTicketNoBOL.WBTicketNo_Select(objWBTicketNoPPT)
        If dt.Rows.Count > 0 Then
            txtWBTicketNo.Text = dt.Rows(0).Item("WBTicketNo").ToString()
        Else
            DisplayInfoMessage("Msg18")
            ''MessageBox.Show("Please enter Serial No in WBTicket No Configuration", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtSecondWeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecondWeight.Leave
        If chkOthers.Checked = True Then
            If txtSecondWeight.ReadOnly = False And txtSecondWeight.Text <> String.Empty Then
                If CDec(Convert.ToDecimal(txtFirstWeight.Text) > Convert.ToDecimal(txtSecondWeight.Text)) Then
                    txtNetWeight.Text = CDec(Convert.ToDecimal(txtFirstWeight.Text) - Convert.ToDecimal(txtSecondWeight.Text))
                    txtNetWeight.Text = Abs(Decimal.Round(CDec(txtNetWeight.Text), 3))
                    TimeOut()
                Else
                    DisplayInfoMessage("Msg19")
                    ''MessageBox.Show("Second Weight must be less than First Weight", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSecondWeight.Text = String.Empty
                    txtSecondWeight.Focus()
                End If
            Else
                txtNetWeight.Text = String.Empty
                TimeOut()
            End If
        ElseIf txtSecondWeight.ReadOnly = False And txtSecondWeight.Text <> String.Empty Then
            If CDec(Convert.ToDecimal(txtFirstWeight.Text) > Convert.ToDecimal(txtSecondWeight.Text)) Then
                txtNetWeight.Text = CDec(Convert.ToDecimal(txtFirstWeight.Text) - Convert.ToDecimal(txtSecondWeight.Text))
                txtNetWeight.Text = Decimal.Round(CDec(txtNetWeight.Text), 3)
                TimeOut()
            Else
                DisplayInfoMessage("Msg19")
                ''MessageBox.Show("Second Weight must be less than First Weight", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSecondWeight.Text = String.Empty
                txtSecondWeight.Focus()
            End If
        Else
            If txtSecondWeight.Text = String.Empty Then
                txtNetWeight.Text = String.Empty
                TimeOut()
            End If
        End If
    End Sub

    Private Sub txtSecondWeightManual_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSecondWeightManual.Leave
        If chkOthers.Checked = True Then
            If txtSecondWeightManual.ReadOnly = False And txtSecondWeightManual.Text <> String.Empty Then
                If CDec(Convert.ToDecimal(txtFirstWeightManual.Text) > Convert.ToDecimal(txtSecondWeightManual.Text)) Then
                    txtNetWeightManual.Text = CDec(Convert.ToDecimal(txtFirstWeightManual.Text) - Convert.ToDecimal(txtSecondWeightManual.Text))
                    txtNetWeightManual.Text = Abs(Decimal.Round(CDec(txtNetWeightManual.Text), 3))
                    TimeOut()
                Else
                    DisplayInfoMessage("Msg20")
                    ''MessageBox.Show("Second Weight must be less than First Weight", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSecondWeightManual.Text = String.Empty
                    txtSecondWeightManual.Focus()
                End If
            Else
                txtNetWeightManual.Text = String.Empty
                TimeOut()
            End If
        ElseIf Me.txtSecondWeightManual.ReadOnly = False And Me.txtSecondWeightManual.Text <> String.Empty Then
            If CDec(Convert.ToDecimal(txtFirstWeightManual.Text) > Convert.ToDecimal(txtSecondWeightManual.Text)) Then
                Me.txtNetWeightManual.Text = CDec(Convert.ToDecimal(txtFirstWeightManual.Text) - Convert.ToDecimal(txtSecondWeightManual.Text))
                txtNetWeightManual.Text = Decimal.Round(CDec(txtNetWeightManual.Text), 3)
                TimeOut()
            Else
                DisplayInfoMessage("Msg20")
                ''MessageBox.Show("Second Weight must be less than First Weight", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSecondWeightManual.Text = String.Empty
                txtSecondWeightManual.Focus()
            End If
        Else
            If txtSecondWeightManual.Text = String.Empty Then
                txtNetWeightManual.Text = String.Empty
                TimeOut()
            End If
        End If

        'If chkOthers.Checked = True Then
        '    If Me.txtSecondWeightManual.ReadOnly = False And Me.txtSecondWeightManual.Text <> String.Empty Then
        '        Me.txtNetWeightManual.Text = CDec(Convert.ToDecimal(txtFirstWeightManual.Text) - Convert.ToDecimal(txtSecondWeightManual.Text))
        '        txtNetWeightManual.Text = Abs(Decimal.Round(CDec(txtNetWeightManual.Text), 3))
        '    End If
        'Else
        '    If Me.txtSecondWeightManual.ReadOnly = False And Me.txtSecondWeightManual.Text <> String.Empty Then
        '        If CDec(Convert.ToDecimal(txtFirstWeightManual.Text) > Convert.ToDecimal(txtSecondWeightManual.Text)) Then
        '            Me.txtNetWeightManual.Text = CDec(Convert.ToDecimal(txtFirstWeightManual.Text) - Convert.ToDecimal(txtSecondWeightManual.Text))
        '            txtNetWeightManual.Text = Decimal.Round(CDec(txtNetWeightManual.Text), 3)
        '        Else
        '            DisplayInfoMessage("Msg20")
        '            ''MessageBox.Show("Second Weight must be less than First Weight", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            txtSecondWeightManual.Text = String.Empty
        '            txtSecondWeightManual.Focus()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub chkManualWeight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualWeight.CheckedChanged
        If tcWeighingInOut.SelectedTab Is tpWeighingInOut = True Then
            txtFirstWeightManual.Text = String.Empty
            If txtFirstWeightManual.Text = String.Empty Then
                If chkManualWeight.Checked = True Then
                    txtFirstWeight.Text = String.Empty
                    ManualWeight_Changeevent()
                Else
                    ReadonlyFalse(txtFirstWeight)
                    ReadonlyTrue(txtSecondWeight)
                    ReadonlyTrue(txtFirstWeightManual)
                    ReadonlyTrue(txtSecondWeightManual)
                    txtNetWeightManual.ReadOnly = True
                    txtNetWeight.ReadOnly = True
                    txtFirstWeight.Focus()
                    Exit Sub
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ManualWeight_Changeevent()
        Dim WBTicket As New WBTicketLoginFrm()
        Dim result As DialogResult = WBTicketLoginFrm.ShowDialog()

        If (result = DialogResult.OK) Then
            ReadonlyFalse(txtFirstWeightManual)
            Me.txtFirstWeightManual.Text = String.Empty
            ReadonlyTrue(txtFirstWeight)
            Me.txtFirstWeight.Text = String.Empty
            ReadonlyTrue(txtSecondWeight)
            Me.txtSecondWeight.Text = String.Empty
            Me.txtNetWeight.ReadOnly = True
            Me.txtNetWeight.Text = String.Empty
            Me.chkManualWeight.Checked = True
            Me.txtFirstWeightManual.Focus()
        Else
            ReadonlyTrue(txtFirstWeightManual)
            Me.txtFirstWeightManual.Text = String.Empty
            ReadonlyTrue(txtSecondWeightManual)
            Me.txtSecondWeightManual.Text = String.Empty
            Me.txtNetWeightManual.ReadOnly = True
            Me.txtNetWeightManual.Text = String.Empty
            ReadonlyFalse(txtFirstWeight)
            Me.txtFirstWeight.Text = String.Empty
            ReadonlyFalse(txtSecondWeight)
            Me.txtSecondWeight.Text = String.Empty
            Me.txtNetWeight.ReadOnly = False
            Me.txtNetWeight.Text = String.Empty
            Me.chkManualWeight.Checked = False
        End If
    End Sub

    Private Sub tcWeighingInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcWeighingInOut.Click
        If tcWeighingInOut.SelectedTab Is tpView = True Then
            lWeight = "First"
            txtViewWBTicketNo.Text = String.Empty
            txtViewVehicleCode.Text = String.Empty
            txtViewProductCode.Text = String.Empty
            WBView_Bind()
            gbSave.Visible = False
            Reset()
            IIWeight = False
            IWeight = True

        ElseIf tcWeighingInOut.SelectedIndex = 3 Then
            lWeight = "Second"
            txtViewIIWBTicketNo.Text = String.Empty
            txtViewIIVehicleCode.Text = String.Empty
            txtViewIIProductDesc.Text = String.Empty
            WBViewIIWeight_Bind()
            gbSave.Visible = False
            Reset()
            IIWeight = True
            IWeight = False

        ElseIf tcWeighingInOut.SelectedTab Is tpWeighingInOut = True Then

            txtVehicleCode.Focus()
            If gbSingleEntry.Enabled = False Then
                btnUpdate.Enabled = False
            End If
            gbSave.Visible = True

            If chkManualWeight.Checked = False Then
                If txtFirstWeight.ReadOnly = False Then
                    btnSave.Enabled = True
                Else
                    btnSave.Enabled = False
                End If
            Else
                If txtFirstWeightManual.ReadOnly = False Then
                    btnSave.Enabled = True
                Else
                    btnSave.Enabled = False
                End If
            End If

        ElseIf tcWeighingInOut.SelectedIndex = 1 Then
            FieldBlockDetails()
        ElseIf tcWeighingInOut.SelectedIndex = 4 Then
            gbSave.Visible = False
        End If
    End Sub

    Private Sub FieldBlockDetails()
        gbSave.Visible = True
        If chkOthers.Checked = False Then
            'Isvalid()

            If txtSecondWeight.Text = String.Empty And txtSecondWeightManual.Text = String.Empty Then
                ' btnUpdate.Enabled = False
            Else
                If GradingFFBFlag = False Then
                    btnUpdate.Enabled = True
                Else
                    btnUpdate.Enabled = False
                End If
            End If
        Else
            DisplayInfoMessage("Msg21")
            tcWeighingInOut.SelectedTab = tpWeighingInOut

        End If

        If chkManualWeight.Checked = False Then
            If txtFirstWeight.ReadOnly = False Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        Else
            If txtFirstWeightManual.ReadOnly = False Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        End If
        cmbBlock.DataSource = Nothing
        cmbBlock.Items.Clear()
        WBBlockFieldSetupBind()
        txtVehicleCode.Focus()
        
        cmbYOP.DataSource = Nothing
        cmbYOP.Items.Clear()
        cmbDivision.DataSource = Nothing
        cmbDivision.Items.Clear()
    End Sub
    Private Sub Isvalid()
        If Me.txtWBTicketNo.Text.Trim = String.Empty Or Me.txtVehicleCode.Text.Trim = String.Empty Or Me.txtProductCode.Text.Trim = String.Empty Or Me.txtNoTrip.Text.Trim = String.Empty Or (Me.txtFirstWeightManual.Text = String.Empty And txtFirstWeight.Text = String.Empty) Then
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show("Weighing In/Out Screen Incomplete, proceed after completion", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tcWeighingInOut.SelectedTab = tpWeighingInOut
        End If
    End Sub


    Private Sub WBView_Bind()
        Dim dt As DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        With objWBTicketInOutPPT
            If chkWbDate.Checked = True Then
                .WeighingDate = dtpviewWeighingDate.Value.Date
            Else
                .WeighingDate = Nothing
            End If

            .WBTicketNo = txtViewWBTicketNo.Text.Trim
            .VehicleCode = txtViewVehicleCode.Text.Trim
            .ProductCode = txtViewProductCode.Text.Trim

            .Weight = "First"

        End With

        dt = objWBTicketInOutBOL.WBWeighingInOut_Select(objWBTicketInOutPPT)

        Dim i As Integer = 0
        Dim J As Integer = 0
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i).Item("Others") = 1 Then
                dt.Rows(i).Item("Others") = True
            Else
                dt.Rows(i).Item("Others") = False
            End If
        Next

        If dt.Rows.Count > 0 Then
            dgvWBWeighingInOut.AutoGenerateColumns = False
            dgvWBWeighingInOut.DataSource = dt
            lblTextmsg.Visible = False
        Else
            'ClearGridView(dgvWBWeighingInOut)
            dgvWBWeighingInOut.DataSource = Nothing
            lblTextmsg.Visible = True
        End If
    End Sub

    Private Sub WBViewIIWeight_Bind()
        Try
            Cursor = Cursors.WaitCursor

            Dim dt As DataTable
            Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
            Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

            With objWBTicketInOutPPT
                If ChkIIDate.Checked = True Then
                    .WeighingDate = dtpviewIIWeighingDate.Value.Date
                Else
                    .WeighingDate = Nothing
                End If

                .WBTicketNo = txtViewIIWBTicketNo.Text.Trim
                .VehicleCode = txtViewIIVehicleCode.Text.Trim
                '.ProductCode = txtViewIIProductDesc.Text.Trim
                .ProductDescSearch = txtViewIIProductDesc.Text.Trim

                .Weight = "Second"

                .NOTFBDetails = chkNOTFBDetails.Checked

            End With

            dt = objWBTicketInOutBOL.WBWeighingInOut_Select(objWBTicketInOutPPT)

            'Dim i As Integer = 0
            'Dim J As Integer = 0
            'For i = 0 To dt.Rows.Count - 1
            '    If dt.Rows(i).Item("Others") = 1 Then
            '        dt.Rows(i).Item("Others") = True
            '    Else
            '        dt.Rows(i).Item("Others") = False
            '    End If
            'Next

            If dt.Rows.Count > 0 Then
                dgvWeighingInOutIIWeight.AutoGenerateColumns = False
                dgvWeighingInOutIIWeight.DataSource = dt

                lblTextmsg.Visible = False
            Else
                'ClearGridView(dgvWeighingInOutIIWeight)
                'dgvWeighingInOutIIWeight.Rows.Clear()
                dgvWeighingInOutIIWeight.DataSource = Nothing
                lblTextmsg.Visible = True
            End If

            If dt.Rows.Count > 0 Then
                lblNoOfRecs.Text = "No Of Records : " + dt.Rows.Count.ToString() + " "
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Change_Color()
        Dim colIndex As Integer = dgvWBWeighingInOut.Rows.Count
        Dim rowIndex As Integer

        For rowIndex = 0 To colIndex - 1
            Dim theRow As DataGridViewRow = dgvWBWeighingInOut.Rows(rowIndex)
            If theRow.Cells("dgclSecondWeight").Value.ToString() = "" Then
                theRow.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub WBBlockFieldSetupBind()
        Dim dtBlockGet As New DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        objWBTicketInOutPPT.SupplierCustID = lSupplierCustID
        objWBTicketInOutPPT.ProductID = lProductID
        objWBTicketInOutPPT.EstateID = GlobalPPT.strEstateID
        cmbDivision.DataSource = Nothing
        dtBlockGet = objWBTicketInOutBOL.WBWeighingInOut_BlockGetII(objWBTicketInOutPPT)
        If dtBlockGet.Rows.Count > 0 Then
            cmbBlock.DisplayMember = "Block"
            cmbBlock.ValueMember = "FieldBlockSetupID"
            cmbBlock.DataSource = dtBlockGet
            cmbBlock.SelectedIndex = -1
        End If
        cmbBlock.Text = "-SELECT-"
    End Sub

    Private Sub cmbDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDivision.SelectedIndexChanged
        'Dim dtYOPGet As New DataTable
        'Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        'Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        'If Not cmbDivision Is Nothing Then
        '    If (cmbDivision.SelectedIndex >= 0) Then
        '        lDivision = cmbDivision.SelectedValue.ToString()
        '        objWBTicketInOutPPT.Division = lDivision
        '        dtYOPGet = objWBTicketInOutBOL.WBWeighingInOut_YOPGet(objWBTicketInOutPPT)
        '        If dtYOPGet.Rows.Count > 0 Then
        '            cmbYOP.DataSource = dtYOPGet
        '            cmbYOP.DisplayMember = "YOP"
        '            cmbYOP.ValueMember = "YOP"
        '            cmbYOP.SelectedIndex = -1
        '            cmbYOP.Text = "-Select-"
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub cmbYOP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYOP.SelectedIndexChanged
        'Dim dtBlockGet As New DataTable
        'Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        'Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        ''If cmbDivision.Text <> String.Empty Then
        'If Not cmbBlock Is Nothing Then
        '    If (cmbBlock.SelectedIndex >= 0) Then
        '        'objWBTicketInOutPPT.Division = cmbBlock.SelectedValue.ToString()
        '        'objWBTicketInOutPPT.YOP = cmbYOP.SelectedValue.ToString()
        '        dtBlockGet = objWBTicketInOutBOL.WBWeighingInOut_BlockGet(objWBTicketInOutPPT)
        '        If dtBlockGet.Rows.Count > 0 Then
        '            cmbBlock.DataSource = dtBlockGet
        '            cmbBlock.DisplayMember = "Block"
        '            cmbBlock.ValueMember = "Block"
        '            cmbBlock.SelectedIndex = -1
        '            cmbBlock.Text = "-Select-"
        '        End If
        '    End If
        'End If

        'If Not cmbBlock Is Nothing Then
        '    If (cmbBlock.SelectedIndex >= 0) Then
        '        lDivision = cmbBlock.SelectedValue.ToString()
        '        objWBTicketInOutPPT.Division = lDivision
        '        dtYOPGet = objWBTicketInOutBOL.WBWeighingInOut_YOPGet(objWBTicketInOutPPT)
        '        If dtYOPGet.Rows.Count > 0 Then
        '            cmbYOP.DataSource = dtYOPGet
        '            cmbYOP.DisplayMember = "YOP"
        '            cmbYOP.ValueMember = "YOP"
        '            cmbYOP.SelectedIndex = -1
        '            cmbYOP.Text = "-Select-"
        '        End If
        '    End If
        'End If
        'End If
    End Sub

    Private Sub cmbBlock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBlock.SelectedIndexChanged
        Dim dtBlockGet As New DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        'If cmbDivision.Text <> String.Empty Then
        If Not cmbBlock Is Nothing Then
            If (cmbBlock.SelectedIndex >= 0) Then
                objWBTicketInOutPPT.SupplierCustID = lSupplierCustID
                objWBTicketInOutPPT.Block = cmbBlock.Text

                'load TPH values based on EstateID and Block
                LoadWBTPH(cmbBlock.SelectedValue)

                dtBlockGet = objWBTicketInOutBOL.WBWeighingInOut_YOPGet(objWBTicketInOutPPT)
                If dtBlockGet.Rows.Count > 0 Then
                    cmbYOP.DisplayMember = "YOP"
                    cmbYOP.ValueMember = "YOP"
                    cmbYOP.DataSource = dtBlockGet

                    cmbDivision.DisplayMember = "Div"
                    cmbDivision.ValueMember = "Div"
                    cmbDivision.DataSource = dtBlockGet
                    'cmbBlock.SelectedIndex = -1
                    'cmbBlock.Text = "-Select-"
                    lblFieldBlockSetupID.Text = dtBlockGet.Rows(0).Item("FieldBlockSetupID").ToString()
                End If
            End If
        End If
    End Sub

    Sub LoadWBTPH(ByVal FieldBlockSetupID As String)
        cmbTPH.Enabled = True
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        cmbTPH.DisplayMember = "TPH"
        cmbTPH.ValueMember = "TPH"
        cmbTPH.DataSource = objWBTicketInOutBOL.WBTPH_Select(FieldBlockSetupID)
    End Sub

    Private Sub btnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If Not IsGridValid() Then Exit Sub
        If AddFlag = True Then
            SaveWeighingBlockDetail()
        ElseIf AddFlag = False Then
            UpdateWeighingBlockDetail()
        End If
        'cmbDivision.DataSource = Nothing
        'WBBlockFieldSetupBind()
        'cmbYOP.DataSource = Nothing
        'cmbDivision.DataSource = Nothing

        txtQtyFFB.Text = "0"
        txtKetek.Text = "0"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        Else
            btnAdd.Text = "Menambahkan"
        End If
        ''btnAdd.Text = "Add"
        AddFlag = True
    End Sub

    Private Function IsValidAdd()
        'Dim i As Integer = dgvFieldBlockSetup.Rows.Count
        'Dim j As Integer = 0
        'If dgvFieldBlockSetup.Rows.Count > 0 Then
        '    For j = 0 To i - 1
        '        If (cmbDivision.Text = dgvFieldBlockSetup.Rows(j).Cells("gvDivision").Value.ToString()) Then
        '            If (cmbYOP.Text = dgvFieldBlockSetup.Rows(j).Cells("gvYOP").Value.ToString()) Then
        '                If (cmbBlock.Text = dgvFieldBlockSetup.Rows(j).Cells("gvBlock").Value.ToString()) Then
        '                    DisplayInfoMessage("Msg23")
        '                    ''MessageBox.Show("Record already Exists", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    Return False
        '                End If
        '            End If
        '        End If
        '    Next
        'End If
        ' ---------------------------------------------------------------------------------
        ' removed all validations, records can exist multiple times (edited on 25 Sep 2013)
        Return True
    End Function

    Private Function IsValidUpdate()
        'Dim i As Integer = dgvFieldBlockSetup.RowCount
        'Dim j As Integer = 0
        'If strDiv = cmbDivision.Text And strYOP = cmbYOP.Text And strBlock = cmbBlock.Text Then
        '    Return True
        'Else
        '    For j = 0 To i - 1
        '        If (cmbDivision.Text = dgvFieldBlockSetup.Rows(j).Cells("gvDivision").Value.ToString()) Then
        '            If (cmbYOP.Text = dgvFieldBlockSetup.Rows(j).Cells("gvYOP").Value.ToString()) Then
        '                If (cmbBlock.Text = dgvFieldBlockSetup.Rows(j).Cells("gvBlock").Value.ToString()) Then
        '                    DisplayInfoMessage("Msg24")
        '                    ''MessageBox.Show("Record already Exists", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    Return False
        '                End If
        '            End If
        '        End If
        '    Next
        'End If
        ' ---------------------------------------------------------------------------------
        ' removed all validations, records can exist multiple times (edited on 25 Sep 2013)
        Return True
    End Function

    Private Sub SaveWeighingBlockDetail()
        Dim total As Decimal = 0.0
        Dim intRowcount As Integer = myDataTable.Rows.Count

        If dgvFieldBlockSetup.Rows.Count > 200 Then
            dgvFieldBlockSetup.AllowUserToAddRows = False
            DisplayInfoMessage("Msg25")
            ''MessageBox.Show("Sorry you can't add more than Ten records", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            myDataRow = myDataTable.NewRow()
            AddFlag = True
            If Not IsValidAdd() Then Exit Sub
            'str = dgvFieldBlockSetup.Columns.Item(0).Name
            If intRowcount = 0 And DTFlag = False Then
                myDataColumn = New DataColumn("FieldBlockSetupID", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("Division", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("YOP", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("Block", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("TPH", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("Ketek", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("Qty", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("LooseFruit", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataColumn = New DataColumn("WeighingBlockID", System.Type.[GetType]("System.String"))
                myDataTable.Columns.Add(myDataColumn)
                myDataRow("FieldBlockSetupID") = lblFieldBlockSetupID.Text
                myDataRow("Division") = cmbDivision.SelectedValue.ToString()
                myDataRow("YOP") = cmbYOP.SelectedValue.ToString()
                myDataRow("Block") = cmbBlock.Text.ToString()
                myDataRow("TPH") = cmbTPH.SelectedValue.ToString()
                myDataRow("Ketek") = IIf(txtKetek.Text.Trim.Length > 0, txtKetek.Text.Trim, 0)
                myDataRow("Qty") = txtQtyFFB.Text.Trim
                myDataRow("LooseFruit") = txtLooseFruit.Text.Trim

                myDataRow("WeighingBlockID") = lWBWeighingBlockID
                myDataTable.Rows.InsertAt(myDataRow, intRowcount)
                DataTableBind = True
            Else
                myDataRow("FieldBlockSetupID") = lblFieldBlockSetupID.Text
                myDataRow("Division") = cmbDivision.SelectedValue.ToString()
                myDataRow("YOP") = cmbYOP.SelectedValue.ToString()
                myDataRow("Block") = cmbBlock.Text.ToString()
                myDataRow("TPH") = cmbTPH.SelectedValue.ToString()
                myDataRow("Ketek") = IIf(txtKetek.Text.Trim.Length > 0, txtKetek.Text.Trim, 0)
                myDataRow("Qty") = txtQtyFFB.Text.Trim
                myDataRow("LooseFruit") = txtLooseFruit.Text.Trim
                myDataRow("WeighingBlockID") = lWBWeighingBlockID
                myDataTable.Rows.InsertAt(myDataRow, intRowcount)
                DTFlag = True
            End If
            With dgvFieldBlockSetup
                .AutoGenerateColumns = False
                .DataSource = myDataTable
            End With

        End If
        txtTotalBunches.Text = 0
        txtTotalLooseFruit.Text = 0
        txtTotalKetek.Text = 0
        lNoofrows = dgvFieldBlockSetup.Rows.Count
        If dgvFieldBlockSetup.Rows.Count > 0 Then
            For Me.lcount = 0 To lNoofrows - 1
                If Not dgvFieldBlockSetup.Rows(lcount).Cells("gvQuality").Value Is Nothing Then
                    total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("gvQuality").Value)
                    txtTotalBunches.Text = CType(total + Convert.ToDecimal(txtTotalBunches.Text), String)
                End If

                If Not dgvFieldBlockSetup.Rows(lcount).Cells("DRLooseFruit").Value Is Nothing Then
                    total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("DRLooseFruit").Value)
                    'txtTotalBunches.Text = CType(total + Convert.ToDecimal(txtTotalBunches.Text), String)
                    txtTotalLooseFruit.Text = CType(total + Convert.ToDecimal(txtTotalLooseFruit.Text), String)
                End If

                If Not dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value Is Nothing Then
                    total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value)
                    txtTotalKetek.Text = CType(total + Convert.ToDecimal(txtTotalKetek.Text), String)
                End If

            Next
        End If
        Clear_MultiEntry()
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub UpdateWeighingBlockDetail()
        Dim i As Integer = dgvFieldBlockSetup.SelectedRows(0).Index
        If Not IsValidUpdate() Then Exit Sub
        Dim intdgrow As Integer
        If AddFlag = False And dgvFieldBlockSetup.Rows.Count > 0 Then
            intdgrow = dgvFieldBlockSetup.CurrentRow.Index
            myDataTable.Rows.RemoveAt(intdgrow)
            myDataRow = myDataTable.NewRow()
            myDataRow("FieldBlockSetupID") = lblFieldBlockSetupID.Text
            myDataRow("Division") = cmbDivision.SelectedValue.ToString()
            myDataRow("YOP") = cmbYOP.SelectedValue.ToString()
            myDataRow("Block") = cmbBlock.Text.ToString()
            myDataRow("TPH") = cmbTPH.SelectedValue.ToString()
            myDataRow("Ketek") = IIf(txtKetek.Text.Trim.Length > 0, txtKetek.Text.Trim, 0)
            myDataRow("Qty") = Me.txtQtyFFB.Text.Trim
            myDataRow("LooseFruit") = txtLooseFruit.Text.Trim
            'myDataRow("Qty") = Me.txtDeduction.Text.Trim
            myDataRow("WeighingBlockID") = IIf(lWBWeighingBlockID <> String.Empty, lWBWeighingBlockID, String.Empty)
            myDataTable.Rows.InsertAt(myDataRow, intdgrow)
            dgvFieldBlockSetup.DataSource = myDataTable
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Save"
            Else
                btnAdd.Text = "Menyimpan"
            End If
            ''btnAdd.Text = "Save"
            AddFlag = True
            dgvFieldBlockSetup.Rows(i).Selected = True
            dgvFieldBlockSetup.CurrentRow.Selected = False
        End If
        Me.txtTotalBunches.Text = 0
        Me.txtTotalKetek.Text = 0
        Me.txtTotalLooseFruit.Text = 0

        Me.lNoofrows = Me.dgvFieldBlockSetup.Rows.Count
        If dgvFieldBlockSetup.Rows.Count > 0 Then
            For Me.lcount = 0 To lNoofrows - 1
                If Not dgvFieldBlockSetup.Rows(lcount).Cells("gvQuality").Value Is Nothing Then
                    total = CDbl(dgvFieldBlockSetup.Rows(lcount).Cells("gvQuality").Value)
                    txtTotalBunches.Text = CType(total + Convert.ToInt32(txtTotalBunches.Text), String)
                End If

                If Not dgvFieldBlockSetup.Rows(lcount).Cells("DRLooseFruit").Value Is Nothing Then
                    total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("DRLooseFruit").Value)
                    'txtTotalBunches.Text = CType(total + Convert.ToDecimal(txtTotalBunches.Text), String)
                    txtTotalLooseFruit.Text = CType(total + Convert.ToDecimal(txtTotalLooseFruit.Text), String)
                End If

                If Not dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value Is Nothing Then
                    total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value)
                    txtTotalKetek.Text = CType(total + Convert.ToDecimal(txtTotalKetek.Text), String)
                End If
            Next
        End If
        Clear_MultiEntry()
        lWBWeighingBlockID = String.Empty
        DisplayInfoMessage("Msg26")
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        ''MessageBox.Show("Data successfully updated", "BSP", MessageBoxButtons.OK)
    End Sub

    Private Sub dgvFieldBlockSetup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFieldBlockSetup.CellDoubleClick
        If dgvFieldBlockSetup.Rows.Count > 0 Then
            lblFieldBlockSetupID.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvFieldBlockSetupID").Value
            cmbDivision.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvDivision").Value
            cmbYOP.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvYOP").Value
            cmbBlock.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvBlock").Value
            If Not dgvFieldBlockSetup.CurrentRow.Cells("colTPH").Value Is DBNull.Value Then
                cmbTPH.Text = dgvFieldBlockSetup.CurrentRow.Cells("colTPH").Value
            End If
            If Not dgvFieldBlockSetup.CurrentRow.Cells("colKetek").Value Is DBNull.Value Then
                txtKetek.Text = dgvFieldBlockSetup.CurrentRow.Cells("colKetek").Value
            End If

            txtQtyFFB.Text = Me.dgvFieldBlockSetup.CurrentRow.Cells("gvQuality").Value
            txtLooseFruit.Text = dgvFieldBlockSetup.CurrentRow.Cells("DRLooseFruit").Value
            'txtDeduction.Text = Me.dgvFieldBlockSetup.CurrentRow.Cells("gvFFBDeduction").Value
            If Not dgvFieldBlockSetup.Rows(0).Cells("gvWeighingBlockID").Value Is DBNull.Value Then
                lWBWeighingBlockID = dgvFieldBlockSetup.CurrentRow.Cells("gvWeighingBlockID").Value
            End If
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            Else
                btnAdd.Text = "Memperbarui"
            End If
            ''btnAdd.Text = "Update"
            AddFlag = False

            strDiv = dgvFieldBlockSetup.CurrentRow.Cells("gvDivision").Value.ToString()
            strYOP = dgvFieldBlockSetup.CurrentRow.Cells("gvYOP").Value.ToString()
            strBlock = dgvFieldBlockSetup.CurrentRow.Cells("gvBlock").Value.ToString()

        End If
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgvFieldBlockSetup.RowCount > 0 Then
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingInOutFrm))
            If MsgBox(rm.GetString("Msg27"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                For Each row As DataGridViewRow In dgvFieldBlockSetup.SelectedRows
                    dgvFieldBlockSetup.Rows.Remove(row)
                Next
                Me.txtTotalBunches.Text = 0
                Me.txtTotalLooseFruit.Text = 0
                Me.txtTotalKetek.Text = 0
                Me.lNoofrows = Me.dgvFieldBlockSetup.Rows.Count
                If dgvFieldBlockSetup.Rows.Count > 0 Then
                    For Me.lcount = 0 To Me.lNoofrows - 1
                        total = CType(dgvFieldBlockSetup.Rows(lcount).Cells("gvQuality").Value, Integer)
                        txtTotalBunches.Text = CType(total + Convert.ToInt32(txtTotalBunches.Text), String)

                        total = CType(dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value, Integer)
                        txtTotalKetek.Text = CType(total + Convert.ToInt32(txtTotalKetek.Text), String)
                    Next
                End If
                DTFlag = True
                cmbDivision.DataSource = Nothing
                WBBlockFieldSetupBind()
                cmbYOP.DataSource = Nothing
                cmbDivision.DataSource = Nothing
                txtQtyFFB.Text = "0"
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                Else
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                AddFlag = True
            End If
        Else
            DisplayInfoMessage("Msg28")
            '' MessageBox.Show("No Records to Delete", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TimeOut()
        If txtNetWeight.Text <> String.Empty Or txtNetWeightManual.Text <> String.Empty Then
            'to make visible TimeOut text box
            lblcolon21.Visible = True
            lblTimeOut.Visible = True
            txtTimeOut.Visible = True
            txtTimeOut.Text = Convert.ToDateTime(System.DateTime.Now).ToShortTimeString
            txtTimeOut.Text = System.DateTime.Now.ToString("HH:mm")
        Else
            txtTimeOut.Text = String.Empty
            lblcolon21.Visible = False
            lblTimeOut.Visible = False
            txtTimeOut.Visible = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'For the deduction
        If OutsideSupplier.Checked Then
            Dim objWBWeighingOutPPT As New WBWeighingInOutPPT
            Dim objWBWeighingOutBOL As New WBWeighingInOutBOL

            With objWBWeighingOutPPT
                .WeighingID = Me.lWeighingID
                Dim str As String = Me.txtDate.Text.Trim
                .WeighingDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                .WeighingTime = Me.txtTime.Text.ToString
                .Section = Me.txtSection.Text.Trim
                .Others = Me.lOthers
                .WBTicketNo = Me.txtWBTicketNo.Text.Trim
                .FFBDeliveryOrderNo = Me.txtFFBDeliveryOrderNoFB.Text.Trim
                .SupplierDetID = lSupplietDetID
                .SupplierCustID = lSupplierCustID
                .ProductID = lProductID
                .DriverName = Me.txtDriver.Text.Trim
                .NoTrip = Me.txtNoTrip.Text.Trim
                .TimeOut = txtTimeOut.Text.Trim
                If Me.chkManualWeight.Checked = True And txtSecondWeightManual.Text <> String.Empty Then
                    .SecondWeight = Convert.ToDouble(Me.txtSecondWeightManual.Text.Trim)
                    .NetWeight = Convert.ToDouble(Me.txtNetWeightManual.Text.Trim)
                ElseIf txtSecondWeight.Text <> String.Empty Then
                    .SecondWeight = Convert.ToDouble(Me.txtSecondWeight.Text.Trim)
                    .NetWeight = Convert.ToDouble(Me.txtNetWeight.Text.Trim)
                End If
                .ManualWeight = Me.lManualWeight
                .Remarks = Me.txtRemarks.Text.Trim
                .FFBDeduction = Convert.ToDouble(Me.txtDeduction.Text.Trim)
            End With
            objWBWeighingOutBOL.Update_WBWeighingInOut(objWBWeighingOutPPT)
            DisplayInfoMessage("Msg32")
            Reset()
            Exit Sub
        End If
        If Not IsFormValid() Then Exit Sub
        ' check validation for 2nd weight and net weight
        Dim dt As New DataTable
        Dim WBTicketNoCount As Integer = 0
        Dim rowsaffected As Integer = 0
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        If Me.chkOthers.Checked = True Then
            Me.lOthers = 1
        Else
            Me.lOthers = 0
        End If

        If Me.chkManualWeight.Checked = True Then
            Me.lManualWeight = 1
        Else
            Me.lManualWeight = 0
        End If


        With objWBTicketInOutPPT
            .WeighingID = Me.lWeighingID
            Dim str As String = Me.txtDate.Text.Trim
            .WeighingDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            .WeighingTime = Me.txtTime.Text.ToString
            .Section = Me.txtSection.Text.Trim
            .Others = Me.lOthers
            .WBTicketNo = Me.txtWBTicketNo.Text.Trim
            .FFBDeliveryOrderNo = Me.txtFFBDeliveryOrderNoFB.Text.Trim
            .SupplierDetID = lSupplietDetID
            .SupplierCustID = lSupplierCustID
            .ProductID = lProductID
            .DriverName = Me.txtDriver.Text.Trim
            .NoTrip = Me.txtNoTrip.Text.Trim
            .TimeOut = txtTimeOut.Text.Trim
            If Me.chkManualWeight.Checked = True And txtSecondWeightManual.Text <> String.Empty Then
                .SecondWeight = Convert.ToDouble(Me.txtSecondWeightManual.Text.Trim)
                .NetWeight = Convert.ToDouble(Me.txtNetWeightManual.Text.Trim)
            ElseIf txtSecondWeight.Text <> String.Empty Then
                .SecondWeight = Convert.ToDouble(Me.txtSecondWeight.Text.Trim)
                .NetWeight = Convert.ToDouble(Me.txtNetWeight.Text.Trim)
            End If
            .ManualWeight = Me.lManualWeight
            .Remarks = Me.txtRemarks.Text.Trim
        End With

        If lWeighingID = "" Then
            dt = objWBTicketInOutBOL.WBTicketNo_isExist(objWBTicketInOutPPT) 'for Validation process IDN No. and GRN No. is exists
            If dt.Rows.Count <> 0 Then
                WBTicketNoCount = dt.Rows(0).Item("WBTicketNoCount")
                If WBTicketNoCount > 0 Then
                    DisplayInfoMessage("Msg29")
                    ''MessageBox.Show("WB Ticket No.  already exist", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    rowsaffected = objWBTicketInOutBOL.Update_WBWeighingInOut(objWBTicketInOutPPT) ' Prosses
                    If dt.Rows.Count <> 0 Then
                        lWeighingID = dt.Rows(0).Item("WeighingID").ToString()
                    Else
                        DisplayInfoMessage("Msg30")
                        '' MessageBox.Show("Failed, to insert Records", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If
            End If
        Else
            rowsaffected = objWBTicketInOutBOL.Update_WBWeighingInOut(objWBTicketInOutPPT) 'Update Prosses
            If rowsaffected = 1 Then
            Else
                DisplayInfoMessage("Msg31")
                ''MessageBox.Show("Failed to update Records", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim DataGridViewRow As DataGridViewRow
        If dgvFieldBlockSetup.RowCount > 0 Then
            rowsaffected = objWBTicketInOutBOL.Delete_WBWeighingBlockDetail(objWBTicketInOutPPT)
            For Each DataGridViewRow In dgvFieldBlockSetup.Rows
                With objWBTicketInOutPPT
                    .FieldBlockSetupID = DataGridViewRow.Cells("gvFieldBlockSetupID").Value.ToString()
                    .Division = DataGridViewRow.Cells("gvDivision").Value.ToString()
                    .YOP = DataGridViewRow.Cells("gvYOP").Value.ToString()
                    .Block = DataGridViewRow.Cells("gvBlock").Value.ToString()
                    .TPH = DataGridViewRow.Cells("colTPH").Value.ToString()
                    .Ketek = DataGridViewRow.Cells("colKetek").Value.ToString()
                    .QtyFFB = DataGridViewRow.Cells("gvQuality").Value.ToString()

                    If DataGridViewRow.Cells("DRLooseFruit").Value Is DBNull.Value Then
                        DataGridViewRow.Cells("DRLooseFruit").Value = 0
                        .Loosefruit = DataGridViewRow.Cells("DRLooseFruit").Value
                    Else
                        .Loosefruit = DataGridViewRow.Cells("DRLooseFruit").Value
                    End If


                    '.Loosefruit = DataGridViewRow.Cells("DRLooseFruit").Value = 0


                    '.FFBDeduction = DataGridViewRow.Cells("gvFFBDeduction").Value.ToString()
                    .WeighingBlockID = DataGridViewRow.Cells("gvWeighingBlockID").Value.ToString()
                    If Not String.IsNullOrEmpty(objWBTicketInOutPPT.Division) Then
                        '    If .WeighingBlockID = String.Empty Then
                        dt = objWBTicketInOutBOL.Save_WBWeighingBlockDetail(objWBTicketInOutPPT)
                        '    Else
                        'rowsaffected = objWBTicketInOutBOL.Update_WBWeighingBlockDetail(objWBTicketInOutPPT)
                        '    End If
                    End If
                End With
            Next
        Else
            With objWBTicketInOutPPT
                .FieldBlockSetupID = lblFieldBlockSetupID.Text
                '.Division = String.Empty
                '.YOP = String.Empty
                '.Block = String.Empty
                '.QtyFFB = 0.0
                '.WeighingBlockID = String.Empty
                .FFBDeduction = Convert.ToDouble(Me.txtDeduction.Text.Trim)
                .WeighingID = lWeighingID
            End With
            dt = objWBTicketInOutBOL.Save_WBWeighingBlockDetail(objWBTicketInOutPPT)
        End If
        objWBTicketInOutBOL.UpdateAllocatedWeightBlock(lWeighingID)
        DisplayInfoMessage("Msg32")
        ''MessageBox.Show("Records updated Succesfully", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ClearEntryForm()
        SingleEntry()
        Select_WbTicketNo()
        Datefunction()
        'ClearGridView(dgvFieldBlockSetup)
        dgvFieldBlockSetup.DataSource = Nothing
        Clear_MultiEntry()
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        'PrintFlag = False
        ''PrintFlag = False
        'WBRicketNo = objWBTicketInOutPPT.WBTicketNo
        'Others = lOthers
        'StrFrmName = "WBTicketNORpt"
        ''ReportODBCMethod.CrystalReportViewer1.Visible = False
        'ReportODBCMethod.ShowDialog()
        'txtFirstWeight.ReadOnly = False
        ReadonlyFalse(txtFirstWeight)
        'txtSecondWeight.ReadOnly = True
        ReadonlyTrue(txtSecondWeight)
        chkOthers.Enabled = True
        chkManualWeight.Enabled = True
        ' txtFirstWeight.ReadOnly = False
        'txtFirstWeightManual.ReadOnly = False
        ReadonlyTrue(txtFirstWeightManual)
        'txtSecondWeightManual.ReadOnly = True
        ReadonlyTrue(txtSecondWeightManual)
        chkManualWeight.Checked = False
        chkOthers.Checked = False
        'WBRicketNo = objWBTicketInOutPPT.WBTicketNo

        'Palani
        'tcWeighingInOut.SelectedIndex = 0
        tcWeighingInOut.SelectedIndex = 1
        WBViewIIWeight_Bind()

        'Reset()
        gbSingleEntry.Enabled = True
        gbMutiEntry.Enabled = True
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        lblcolon21.Visible = False
        lblTimeOut.Visible = False
        txtTimeOut.Visible = False
        txtVehicleCode.Focus()
    End Sub

    Private Sub Reset()
        ClearEntryForm()
        SingleEntry()
        Clear_MultiEntry()
        OutsideSupplier.Checked = False
        If dgvFieldBlockSetup.RowCount > 0 Then
            'ClearGridView(dgvFieldBlockSetup)
            dgvFieldBlockSetup.DataSource = Nothing
            DTFlag = True
        End If
        Me.txtDate.Text = String.Empty

        Me.txtTime.Text = String.Empty
        Me.txtSection.Text = String.Empty
        ReadonlyTrue(txtFirstWeightManual)
        Me.chkManualWeight.Checked = False
        ReadonlyFalse(txtFirstWeight)
        ReadonlyTrue(txtSecondWeight)
        ReadonlyTrue(txtSecondWeightManual)
        txtNetWeightManual.ReadOnly = True
        Datefunction()
        Select_WbTicketNo()
        txtNoTrip.ReadOnly = True
        myDataTable.Clear()
        AddFlag = True
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        chkOthers.Enabled = True
        chkOthers.Checked = False
        chkManualWeight.Enabled = True
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        Else
            btnAdd.Text = "Menambahkan"
        End If
        ''btnAdd.Text = "Add"
        cmbDivision.DataSource = Nothing
        WBBlockFieldSetupBind()
        cmbYOP.DataSource = Nothing
        cmbBlock.DataSource = Nothing
        txtVehicleCode.Focus()
        gbSingleEntry.Enabled = True
        gbMutiEntry.Enabled = True
        'tcWeighingInOut.SelectedIndex = 0
        txtTimeOut.Text = String.Empty
        lblcolon21.Visible = False
        lblTimeOut.Visible = False
        txtTimeOut.Visible = False
        GradingFFBFlag = False
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        tcWeighingInOut.SelectedIndex = 0
    End Sub

    Private Sub SingleEntry()
        Me.txtFFBDeliveryOrderNo.Text = String.Empty
        Me.txtFirstWeight.Text = String.Empty
        Me.txtSecondWeight.Text = String.Empty
        Me.txtNetWeight.Text = String.Empty
        Me.txtFirstWeightManual.Text = String.Empty
        Me.txtSecondWeightManual.Text = String.Empty
        Me.txtNetWeightManual.Text = String.Empty
        Me.txtRemarks.Text = String.Empty
    End Sub

    Private Sub ClearEntryForm()
        Me.txtProductCode.Text = String.Empty
        Me.txtVehicleCode.Text = String.Empty
        Me.txtDriver.Text = String.Empty
        Me.txtNoTrip.Text = String.Empty
        Me.txtSupplier.Text = String.Empty
        Me.txtTotalBunches.Text = String.Empty
        Me.txtTotalLooseFruit.Text = 0
        Me.txtTotalKetek.Text = 0
        Me.txtKetek.Text = "0"
        Me.chkLooseFruit.Checked = False
        Me.cmbDivision.Text = "-Select-"
        Me.cmbYOP.Text = String.Empty
        Me.cmbBlock.Text = String.Empty
        lSupplierCustID = String.Empty
        lSupplietDetID = String.Empty
        lProductID = String.Empty
        lblProductDesc.Text = String.Empty
    End Sub

    Private Sub Clear_MultiEntry()
        cmbDivision.Text = String.Empty
        cmbYOP.Text = String.Empty
        cmbBlock.Text = String.Empty
        txtQtyFFB.Text = "0"
        txtLooseFruit.Text = 0
        txtDeduction.Text = String.Empty
        btnAdd.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtViewWBTicketNo.Text = String.Empty And txtViewVehicleCode.Text = String.Empty And txtViewProductCode.Text = String.Empty And chkWbDate.Checked = False Then
            WBView_Bind()
            DisplayInfoMessage("Msg33")
            ''MessageBox.Show("Please enter search criteria", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            WBView_Bind()
        End If
    End Sub

    Private Sub txtFirstWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstWeight.KeyPress, txtSecondWeight.KeyPress, txtFirstWeightManual.KeyPress, txtSecondWeightManual.KeyPress
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingInOutFrm))
        If MsgBox(rm.GetString("Msg34"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Clear_Weight()
        txtFirstWeight.Text = String.Empty
        txtSecondWeight.Text = String.Empty
        txtNetWeight.Text = String.Empty
        txtFirstWeightManual.Text = String.Empty
        txtSecondWeightManual.Text = String.Empty
        txtNetWeightManual.Text = String.Empty
    End Sub

    Private Sub dgvWBWeighingInOut_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWBWeighingInOut.CellDoubleClick
        chkLooseFruit.Checked = False
        WBView_DoubleClick()
    End Sub

    Private Sub WBView_DoubleClick()
        Dim MdiParent As New MDIParent


        If MdiParent.strMenuID <> "M84" Then
            Clear_Weight()
            If dgvWBWeighingInOut.RowCount > 0 Then
                lNetWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclNetWeight").Value.ToString()
                If lNetWeight = "" Then
                    BindWBWeighingInOutView()
                    tcWeighingInOut.SelectedTab = tpWeighingInOut
                    btnAdd.Enabled = True
                    btnDelete.Enabled = True
                    gbSave.Visible = True
                    gbSingleEntry.Enabled = True
                    gbMutiEntry.Enabled = False
                    'btnUpdate.Enabled = True
                    If txtFirstWeight.Text <> String.Empty Then
                        txtSecondWeight.Focus()
                    Else
                        txtSecondWeightManual.Focus()
                    End If
                Else
                    BindWBWeighingInOutView()
                    btnSave.Enabled = False
                    btnUpdate.Enabled = False
                    tcWeighingInOut.SelectedTab = tpWeighingInOut
                    gbSingleEntry.Enabled = False
                    gbMutiEntry.Enabled = False
                    gbSave.Visible = True

                End If
            End If
        End If
    End Sub

    Private Sub WBViewII_DoubleClick()
        Dim MdiParent As New MDIParent
        If MdiParent.strMenuID <> "M84" Then
            Clear_Weight()

            If dgvWeighingInOutIIWeight.RowCount > 0 Then

                Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
                Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
                Dim dtTemp As DataTable
                objWBTicketInOutPPT.WeighingID = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclWeighingIDII").Value.ToString()
                dtTemp = objWBTicketInOutBOL.WBWeighingInOutDetail_GetRecord(objWBTicketInOutPPT)

                lNetWeight = dtTemp.Rows(0).Item("NetWeight")

                If lNetWeight = "" Then
                    BindWBWeighingInOutIIWeightView(dtTemp)
                    'tcWeighingInOut.SelectedTab = tpWeighingInOut
                    tcWeighingInOut.SelectedTab = tpFieldBlockDetails
                    btnAdd.Enabled = True
                    btnDelete.Enabled = True
                    gbSave.Visible = True
                    gbSingleEntry.Enabled = True
                    gbMutiEntry.Enabled = False
                    'btnUpdate.Enabled = True
                    If txtFirstWeight.Text <> String.Empty Then
                        txtSecondWeight.Focus()
                    Else
                        txtSecondWeightManual.Focus()
                    End If
                Else
                    BindWBWeighingInOutIIWeightView(dtTemp)
                    btnSave.Enabled = False
                    btnUpdate.Enabled = False
                    'tcWeighingInOut.SelectedTab = tpWeighingInOut
                    tcWeighingInOut.SelectedTab = tpFieldBlockDetails
                    gbSingleEntry.Enabled = False
                    gbMutiEntry.Enabled = False
                    gbSave.Visible = True
                End If

                Dim noOfRows As Integer = dgvFieldBlockSetup.Rows.Count
                txtTotalLooseFruit.Text = "0"
                txtTotalKetek.Text = "0"

                If noOfRows > 0 Then
                    For Me.lcount = 0 To noOfRows - 1

                        If Not dgvFieldBlockSetup.Rows(lcount).Cells("DRLooseFruit").Value Is Nothing Then
                            total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("DRLooseFruit").Value)
                            txtTotalLooseFruit.Text = CType(total + Convert.ToDecimal(txtTotalLooseFruit.Text), String)
                        End If

                        If Not dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value Is Nothing Then
                            total = Convert.ToDecimal(dgvFieldBlockSetup.Rows(lcount).Cells("colKetek").Value)
                            txtTotalKetek.Text = CType(total + Convert.ToDecimal(txtTotalKetek.Text), String)
                        End If

                    Next
                End If

                FieldBlockDetails()
            End If
        End If
    End Sub

    Private Sub BindWBWeighingInOutView()
        Dim dtable As DataTable
        Dim rndWeight As Integer = 0
        If dgvWBWeighingInOut.Rows.Count > 0 Then
            If dgvWBWeighingInOut.SelectedRows(0).Cells("dgclOthers").Value = True Then
                chkOthers.Checked = True
            Else
                chkOthers.Checked = False
            End If
            chkOthers.Enabled = False
            lWeighingID = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclWeighingID").Value.ToString()
            txtDate.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclDate").Value.ToString()

            txtDateFB.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclDate").Value.ToString()
            txtTime.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclTime").Value.ToString()
            txtSection.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSession").Value.ToString()
            txtWBTicketNo.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclWBTicketNo").Value.ToString()

            txtWBTicketNoFB.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclWBTicketNo").Value.ToString()
            txtFFBDeliveryOrderNo.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclFFBDeliveryOrderNo").Value.ToString()

            txtFFBDeliveryOrderNoFB.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclFFBDeliveryOrderNo").Value.ToString()
            txtVehicleCode.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclVehicleCode").Value.ToString()
            txtSupplier.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSupplier").Value.ToString()

            ''Palani
            'txtProductCode.Tag = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclProductIDII").Value.ToString()

            txtProductCode.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclProductCode").Value.ToString()
            txtDriver.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclDriverName").Value.ToString()
            txtNoTrip.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclNoofTrip").Value.ToString()
            txtRemarks.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
            lSupplietDetID = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSupplierDetID").Value.ToString()
            lSupplierCustID = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSupplierCustID").Value.ToString()
            lProductID = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclProductID").Value.ToString()
            lblProductDesc.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclProductDesc").Value.ToString()
            If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclTimeOut").Value Is DBNull.Value Then
                txtTimeOut.Text = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclTimeOut").Value.ToString()
            Else
                txtTimeOut.Text = String.Empty
            End If

            'Getting Manual Weight based on Check box value: 1 for Manual Weight, 0 for Machine Weight:
            Dim lmanualWeight As Integer
            lmanualWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclManualWeight").Value.ToString()

            'if value greater than 0 mean Manual Weight else Machine Weight 
            If lmanualWeight > 0 Then
                If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclFirstWeight").Value Is DBNull.Value Then
                    rndWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclFirstWeight").Value
                    txtFirstWeightManual.Text = Math.Round(rndWeight, 1)
                End If

                If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSecondWeight").Value Is DBNull.Value Then
                    rndWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSecondWeight").Value
                    txtSecondWeightManual.Text = Math.Round(rndWeight, 1)
                    ReadonlyTrue(txtSecondWeightManual)
                    ReadonlyTrue(txtSecondWeight)
                Else
                    txtSecondWeightManual.Text = String.Empty
                    ReadonlyFalse(txtSecondWeightManual)
                    ReadonlyTrue(txtSecondWeight)
                End If

                If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclNetWeight").Value Is DBNull.Value Then
                    rndWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclNetWeight").Value
                    txtNetWeightManual.Text = rndWeight
                    txtNetWeightManual.ReadOnly = True
                    txtNetWeight.ReadOnly = True
                    'to make visible TimeOut text box
                    lblcolon21.Visible = True
                    lblTimeOut.Visible = True
                    txtTimeOut.Visible = True
                Else
                    txtNetWeightManual.Text = String.Empty
                    ReadonlyFalse(txtSecondWeight)
                    txtNetWeight.ReadOnly = True
                    lblcolon21.Visible = False
                    lblTimeOut.Visible = False
                    txtTimeOut.Visible = False
                End If
            Else
                If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclFirstWeight").Value Is DBNull.Value Then
                    rndWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclFirstWeight").Value
                    txtFirstWeight.Text = Math.Round(rndWeight, 1)
                End If

                If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSecondWeight").Value Is DBNull.Value Then
                    rndWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclSecondWeight").Value
                    txtSecondWeight.Text = Math.Round(rndWeight, 1)
                    ReadonlyTrue(txtSecondWeight)
                Else
                    txtSecondWeight.Text = String.Empty
                    ReadonlyFalse(txtSecondWeight)
                End If

                If Not dgvWBWeighingInOut.SelectedRows(0).Cells("dgclNetWeight").Value Is DBNull.Value Then
                    rndWeight = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclNetWeight").Value
                    txtNetWeight.Text = Math.Round(rndWeight, 1)
                    txtNetWeight.ReadOnly = True
                    'to make visible TimeOut text box
                    lblcolon21.Visible = True
                    lblTimeOut.Visible = True
                    txtTimeOut.Visible = True
                Else
                    txtNetWeight.Text = String.Empty
                    lblcolon21.Visible = False
                    lblTimeOut.Visible = False
                    txtTimeOut.Visible = False
                End If

            End If

            If dgvWBWeighingInOut.SelectedRows(0).Cells("dgclManualWeight").Value = "0" Then
                chkManualWeight.Checked = False
                ReadonlyTrue(txtFirstWeightManual)
                ReadonlyTrue(txtSecondWeightManual)
                txtNetWeightManual.ReadOnly = True
                ReadonlyTrue(txtFirstWeight)
            Else
                ReadonlyTrue(txtFirstWeight)
                ReadonlyTrue(txtFirstWeightManual)
                ReadonlyTrue(txtSecondWeight)
                txtNetWeight.ReadOnly = True
                chkManualWeight.Checked = True
            End If
            chkManualWeight.Enabled = False
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            DTFlag = True
        Else
            Exit Sub
        End If

        ' To update FBSUpdate
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        objWBTicketInOutPPT.WeighingID = lWeighingID
        myDataTable = objWBTicketInOutBOL.WBWeighingInOutDetail_Select(objWBTicketInOutPPT)

        If myDataTable.Rows.Count > 0 Then
            dgvFieldBlockSetup.AutoGenerateColumns = False
            dgvFieldBlockSetup.DataSource = myDataTable
        Else
            'ClearGridView(dgvFieldBlockSetup)
            dgvFieldBlockSetup.DataSource = Nothing
        End If
        ltotal = 0
        Dim ltotalKetek As Integer = 0
        Dim DataGridviewRow As DataGridViewRow
        For Each DataGridviewRow In dgvFieldBlockSetup.Rows
            ltotal = DataGridviewRow.Cells("gvQuality").Value + ltotal
            ltotalKetek = DataGridviewRow.Cells("colKetek").Value + ltotalKetek
        Next
        Me.txtTotalBunches.Text = Me.ltotal
        Me.txtTotalKetek.Text = ltotalKetek

        dtable = objWBTicketInOutBOL.WeighingID_isExistInGradingFFB(objWBTicketInOutPPT)
        If dtable.Rows(0).Item("WeighingID") > 0 Then
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            DisplayInfoMessage("Msg35")
            'MessageBox.Show("Record already using in Grading FFB", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GradingFFBFlag = True
        Else
            btnAdd.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    'Private Sub BindWBWeighingInOutIIWeightView(ByVal DtTemp As DataTable)
    '    Dim dtable As DataTable
    '    Dim rndweightll As Integer = 0
    '    If dgvWeighingInOutIIWeight.Rows.Count > 0 Then
    '        'If dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclOthersII").Value = True Then
    '        '    chkOthers.Checked = True
    '        'Else
    '        '    chkOthers.Checked = False
    '        'End If
    '        chkOthers.Enabled = False

    '        lWeighingID = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclWeighingIDII").Value.ToString()
    '        txtDate.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclDateII").Value.ToString()

    '        txtDateFB.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclDateII").Value.ToString()
    '        txtTime.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclTimeII").Value.ToString()
    '        txtSection.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSessionII").Value.ToString()
    '        txtWBTicketNo.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclWBTicketNoII").Value.ToString()

    '        txtWBTicketNoFB.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclWBTicketNoII").Value.ToString()
    '        txtFFBDeliveryOrderNo.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclFFBDeliveryOrderNoII").Value.ToString()

    '        txtFFBDeliveryOrderNoFB.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclFFBDeliveryOrderNoII").Value.ToString()
    '        txtVehicleCode.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclVehicleCodeII").Value.ToString()
    '        txtSupplier.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSupplierII").Value.ToString()

    '        'Palani
    '        txtProductCode.Tag = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclProductIDII").Value.ToString()

    '        txtProductCode.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclProductCodeII").Value.ToString()


    '        txtDriver.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclDriverNameII").Value.ToString()
    '        txtNoTrip.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclNoofTripII").Value.ToString()
    '        txtRemarks.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclRemarksII").Value.ToString()
    '        lSupplietDetID = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSupplierDetIDII").Value.ToString()
    '        lSupplierCustID = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSupplierCustIDII").Value.ToString()
    '        lProductID = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclProductIDII").Value.ToString()
    '        lblProductDesc.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclProductDescII").Value.ToString()
    '        If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclTimeOutII").Value Is DBNull.Value Then
    '            txtTimeOut.Text = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclTimeOutII").Value.ToString()
    '        Else
    '            txtTimeOut.Text = String.Empty
    '        End If

    '        'Getting Manual Weight based on Check box value: 1 for Manual Weight, 0 for Machine Weight:
    '        Dim lmanualWeight As Integer
    '        lmanualWeight = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclManualWeightII").Value.ToString()

    '        'if value greater than 0 mean Manual Weight else Machine Weight 
    '        If lmanualWeight > 0 Then
    '            If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclFirstWeightII").Value Is DBNull.Value Then
    '                rndweightll = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclFirstWeightII").Value
    '                txtFirstWeightManual.Text = Math.Round(rndweightll, 1)
    '            End If

    '            If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSecondWeightII").Value Is DBNull.Value Then
    '                rndweightll = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSecondWeightII").Value
    '                txtSecondWeightManual.Text = Math.Round(rndweightll, 1)
    '                ReadonlyTrue(txtSecondWeightManual)
    '                ReadonlyTrue(txtSecondWeight)
    '            Else
    '                txtSecondWeightManual.Text = String.Empty
    '                ReadonlyFalse(txtSecondWeightManual)
    '                ReadonlyTrue(txtSecondWeight)
    '            End If

    '            If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclNetWeightII").Value Is DBNull.Value Then
    '                rndweightll = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclNetWeightII").Value
    '                txtNetWeightManual.Text = Math.Round(rndweightll, 1)
    '                txtNetWeightManual.ReadOnly = True
    '                txtNetWeight.ReadOnly = True
    '                'to make visible TimeOut text box
    '                lblcolon21.Visible = True
    '                lblTimeOut.Visible = True
    '                txtTimeOut.Visible = True
    '            Else
    '                txtNetWeightManual.Text = String.Empty
    '                ReadonlyFalse(txtSecondWeight)
    '                txtNetWeight.ReadOnly = True
    '                lblcolon21.Visible = False
    '                lblTimeOut.Visible = False
    '                txtTimeOut.Visible = False
    '            End If
    '        Else
    '            If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclFirstWeightII").Value Is DBNull.Value Then
    '                rndweightll = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclFirstWeightII").Value
    '                txtFirstWeight.Text = Math.Round(rndweightll, 1)
    '            End If

    '            If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSecondWeightII").Value Is DBNull.Value Then
    '                rndweightll = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclSecondWeightII").Value
    '                txtSecondWeight.Text = Math.Round(rndweightll, 1)
    '                ReadonlyTrue(txtSecondWeight)
    '            Else
    '                txtSecondWeight.Text = String.Empty
    '                ReadonlyFalse(txtSecondWeight)
    '            End If

    '            If Not dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclNetWeightII").Value Is DBNull.Value Then
    '                rndweightll = dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclNetWeightII").Value
    '                txtNetWeight.Text = Math.Round(rndweightll, 1)
    '                txtNetWeight.ReadOnly = True
    '                'to make visible TimeOut text box
    '                lblcolon21.Visible = True
    '                lblTimeOut.Visible = True
    '                txtTimeOut.Visible = True
    '            Else
    '                txtNetWeight.Text = String.Empty
    '                lblcolon21.Visible = False
    '                lblTimeOut.Visible = False
    '                txtTimeOut.Visible = False
    '            End If

    '        End If

    '        If dgvWeighingInOutIIWeight.SelectedRows(0).Cells("dgclManualWeightII").Value = "0" Then
    '            chkManualWeight.Checked = False
    '            ReadonlyTrue(txtFirstWeightManual)
    '            ReadonlyTrue(txtSecondWeightManual)
    '            txtNetWeightManual.ReadOnly = True
    '            ReadonlyTrue(txtFirstWeight)
    '        Else
    '            ReadonlyTrue(txtFirstWeight)
    '            ReadonlyTrue(txtFirstWeightManual)
    '            ReadonlyTrue(txtSecondWeight)
    '            txtNetWeight.ReadOnly = True
    '            chkManualWeight.Checked = True
    '        End If
    '        chkManualWeight.Enabled = False
    '        btnSave.Enabled = False
    '        btnUpdate.Enabled = False
    '        DTFlag = True
    '    Else
    '        Exit Sub
    '    End If

    '    ' To update FBSUpdate
    '    Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
    '    Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
    '    objWBTicketInOutPPT.WeighingID = lWeighingID
    '    myDataTable = objWBTicketInOutBOL.WBWeighingInOutDetail_Select(objWBTicketInOutPPT)

    '    If myDataTable.Rows.Count > 0 Then
    '        dgvFieldBlockSetup.AutoGenerateColumns = False
    '        dgvFieldBlockSetup.DataSource = myDataTable
    '    Else
    '        'ClearGridView(dgvFieldBlockSetup)
    '        dgvFieldBlockSetup.DataSource = Nothing
    '    End If
    '    ltotal = 0
    '    Dim DataGridviewRow As DataGridViewRow
    '    For Each DataGridviewRow In dgvFieldBlockSetup.Rows
    '        ltotal = DataGridviewRow.Cells("gvQuality").Value + ltotal
    '    Next
    '    Me.txtTotalBunches.Text = Me.ltotal

    '    dtable = objWBTicketInOutBOL.WeighingID_isExistInGradingFFB(objWBTicketInOutPPT)
    '    If dtable.Rows(0).Item("WeighingID") > 0 Then
    '        btnAdd.Enabled = False
    '        btnDelete.Enabled = False
    '        DisplayInfoMessage("Msg35")
    '        'MessageBox.Show("Record already using in Grading FFB", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        GradingFFBFlag = True
    '    Else
    '        btnAdd.Enabled = True
    '        btnDelete.Enabled = True
    '    End If
    'End Sub


    Private Sub BindWBWeighingInOutIIWeightView(ByVal DtTemp As DataTable)
        Dim dtable As DataTable
        Dim rndweightll As Integer = 0
        'If dgvWeighingInOutIIWeight.Rows.Count > 0 Then
        If DtTemp.Rows.Count > 0 Then
            'If DtTemp.Rows(0).Item("OthersII").Value = True Then
            '    chkOthers.Checked = True
            'Else
            '    chkOthers.Checked = False
            'End If
            chkOthers.Enabled = False

            lWeighingID = DtTemp.Rows(0).Item("WeighingID").ToString()
            txtDate.Text = DtTemp.Rows(0).Item("WeighingDate").ToString()

            txtDateFB.Text = DtTemp.Rows(0).Item("WeighingDate").ToString()
            txtTime.Text = DtTemp.Rows(0).Item("WeighingTime").ToString()
            txtSection.Text = DtTemp.Rows(0).Item("Section").ToString()
            txtWBTicketNo.Text = DtTemp.Rows(0).Item("WBTicketNo").ToString()

            txtWBTicketNoFB.Text = DtTemp.Rows(0).Item("WBTicketNo").ToString()
            txtFFBDeliveryOrderNo.Text = DtTemp.Rows(0).Item("FFBDeliveryOrderNo").ToString()

            txtFFBDeliveryOrderNoFB.Text = DtTemp.Rows(0).Item("FFBDeliveryOrderNo").ToString()
            txtVehicleCode.Text = DtTemp.Rows(0).Item("VehicleCode").ToString()
            txtSupplier.Text = DtTemp.Rows(0).Item("Supplier").ToString()

            'Palani
            txtProductCode.Tag = DtTemp.Rows(0).Item("ProductID").ToString()

            txtProductCode.Text = DtTemp.Rows(0).Item("ProductCode").ToString()


            txtDriver.Text = DtTemp.Rows(0).Item("DriverName").ToString()
            txtNoTrip.Text = DtTemp.Rows(0).Item("NoTrip").ToString()
            txtRemarks.Text = DtTemp.Rows(0).Item("Remarks").ToString()
            lSupplietDetID = DtTemp.Rows(0).Item("WBVehicleID").ToString()
            lSupplierCustID = DtTemp.Rows(0).Item("SupplierCustID").ToString()
            lProductID = DtTemp.Rows(0).Item("ProductID").ToString()
            lblProductDesc.Text = DtTemp.Rows(0).Item("ProductDescp").ToString()
            If Not DtTemp.Rows(0).Item("TimeOut").ToString() Is DBNull.Value Then
                txtTimeOut.Text = DtTemp.Rows(0).Item("TimeOut").ToString()
            Else
                txtTimeOut.Text = String.Empty
            End If

            'Getting Manual Weight based on Check box value: 1 for Manual Weight, 0 for Machine Weight:
            Dim lmanualWeight As Integer
            lmanualWeight = DtTemp.Rows(0).Item("ManualWeight").ToString()

            'if value greater than 0 mean Manual Weight else Machine Weight 
            If lmanualWeight > 0 Then
                If Not DtTemp.Rows(0).Item("FirstWeight").ToString() Is DBNull.Value Then
                    rndweightll = DtTemp.Rows(0).Item("FirstWeight").ToString()
                    txtFirstWeightManual.Text = Math.Round(rndweightll, 1)
                End If

                If Not DtTemp.Rows(0).Item("SecondWeight").ToString() Is DBNull.Value Then
                    rndweightll = DtTemp.Rows(0).Item("SecondWeight").ToString()
                    txtSecondWeightManual.Text = Math.Round(rndweightll, 1)
                    ReadonlyTrue(txtSecondWeightManual)
                    ReadonlyTrue(txtSecondWeight)
                Else
                    txtSecondWeightManual.Text = String.Empty
                    ReadonlyFalse(txtSecondWeightManual)
                    ReadonlyTrue(txtSecondWeight)
                End If

                If Not DtTemp.Rows(0).Item("NetWeight").ToString() Is DBNull.Value Then
                    rndweightll = DtTemp.Rows(0).Item("NetWeight").ToString()
                    txtNetWeightManual.Text = Math.Round(rndweightll, 1)
                    txtNetWeightManual.ReadOnly = True
                    txtNetWeight.ReadOnly = True
                    'to make visible TimeOut text box
                    lblcolon21.Visible = True
                    lblTimeOut.Visible = True
                    txtTimeOut.Visible = True
                Else
                    txtNetWeightManual.Text = String.Empty
                    ReadonlyFalse(txtSecondWeight)
                    txtNetWeight.ReadOnly = True
                    lblcolon21.Visible = False
                    lblTimeOut.Visible = False
                    txtTimeOut.Visible = False
                End If
            Else
                If Not DtTemp.Rows(0).Item("FirstWeight").ToString() Is DBNull.Value Then
                    rndweightll = DtTemp.Rows(0).Item("FirstWeight").ToString()
                    txtFirstWeight.Text = Math.Round(rndweightll, 1)
                End If

                If Not DtTemp.Rows(0).Item("SecondWeight").ToString() Is DBNull.Value Then
                    rndweightll = DtTemp.Rows(0).Item("SecondWeight").ToString()
                    txtSecondWeight.Text = Math.Round(rndweightll, 1)
                    ReadonlyTrue(txtSecondWeight)
                Else
                    txtSecondWeight.Text = String.Empty
                    ReadonlyFalse(txtSecondWeight)
                End If

                If Not DtTemp.Rows(0).Item("NetWeight").ToString() Is DBNull.Value Then
                    rndweightll = DtTemp.Rows(0).Item("NetWeight").ToString()
                    txtNetWeight.Text = Math.Round(rndweightll, 1)
                    txtNetWeight.ReadOnly = True
                    'to make visible TimeOut text box
                    lblcolon21.Visible = True
                    lblTimeOut.Visible = True
                    txtTimeOut.Visible = True
                Else
                    txtNetWeight.Text = String.Empty
                    lblcolon21.Visible = False
                    lblTimeOut.Visible = False
                    txtTimeOut.Visible = False
                End If

            End If

            If DtTemp.Rows(0).Item("ManualWeight").ToString() = "0" Then
                chkManualWeight.Checked = False
                ReadonlyTrue(txtFirstWeightManual)
                ReadonlyTrue(txtSecondWeightManual)
                txtNetWeightManual.ReadOnly = True
                ReadonlyTrue(txtFirstWeight)
            Else
                ReadonlyTrue(txtFirstWeight)
                ReadonlyTrue(txtFirstWeightManual)
                ReadonlyTrue(txtSecondWeight)
                txtNetWeight.ReadOnly = True
                chkManualWeight.Checked = True
            End If
            chkManualWeight.Enabled = False
            btnSave.Enabled = False
            btnUpdate.Enabled = False
            DTFlag = True
        Else
            Exit Sub
        End If

        ' To update FBSUpdate
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL
        objWBTicketInOutPPT.WeighingID = lWeighingID
        myDataTable = objWBTicketInOutBOL.WBWeighingInOutDetail_Select(objWBTicketInOutPPT)

        If myDataTable.Rows.Count > 0 Then
            dgvFieldBlockSetup.AutoGenerateColumns = False
            dgvFieldBlockSetup.DataSource = myDataTable
        Else
            'ClearGridView(dgvFieldBlockSetup)
            dgvFieldBlockSetup.DataSource = Nothing
        End If
        ltotal = 0
        Dim DataGridviewRow As DataGridViewRow
        Dim ltotalKetek As Integer = 0
        For Each DataGridviewRow In dgvFieldBlockSetup.Rows
            ltotal = DataGridviewRow.Cells("gvQuality").Value + ltotal
            ltotalKetek = DataGridviewRow.Cells("colKetek").Value + ltotalKetek
        Next
        Me.txtTotalBunches.Text = Me.ltotal
        Me.txtTotalKetek.Text = ltotalKetek

        dtable = objWBTicketInOutBOL.WeighingID_isExistInGradingFFB(objWBTicketInOutPPT)
        If dtable.Rows(0).Item("WeighingID") > 0 Then
            btnAdd.Enabled = False
            btnDelete.Enabled = False
            DisplayInfoMessage("Msg35")
            'MessageBox.Show("Record already using in Grading FFB", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GradingFFBFlag = True
        Else
            btnAdd.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

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

    Private Sub txtFirstWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFirstWeight.KeyDown, txtSecondWeight.KeyDown, txtFirstWeightManual.KeyDown, txtSecondWeightManual.KeyDown
        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If
        isModifierKey = False
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

                        isDecimal = reDecimalPlaces3.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim dt As DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        dt = objWBTicketInOutBOL.WBTicketNoRecord_isExist(objWBTicketInOutPPT)

        PrintFlag = True
        StrFrmName = "WBWeighingInOutRpt"
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
    End Sub

    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        WBView_DoubleClick()
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        ClearEntryForm()
        SingleEntry()
        Clear_MultiEntry()
        If dgvFieldBlockSetup.RowCount > 0 Then
            'ClearGridView(dgvFieldBlockSetup)
            dgvFieldBlockSetup.DataSource = Nothing
            DTFlag = True
        End If
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        Else
            btnAdd.Text = "Menambahkan"
        End If
        ''btnAdd.Text = "Add"
        AddFlag = True
        Datefunction()
        Select_WbTicketNo()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        chkManualWeight.Enabled = False
        chkManualWeight.Checked = True
        chkOthers.Checked = False
        chkOthers.Enabled = True

        ReadonlyTrue(txtFirstWeight)
        ReadonlyFalse(txtFirstWeightManual)
        ReadonlyTrue(txtSecondWeightManual)
        WBBlockFieldSetupBind()
        tcWeighingInOut.SelectedTab = tpWeighingInOut
        txtFFBDeliveryOrderNo.Focus()
        gbSave.Visible = True
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete_WBWeighingInOutView()
    End Sub

    Private Sub Delete_WBWeighingInOutView()
        Dim rowsAffected As Integer = 0
        cmsWBWeighing.Visible = False
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL
        Dim dt As New DataTable
        If dgvWBWeighingInOut.Rows.Count > 0 Then

            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingInOutFrm))
            If MsgBox(rm.GetString("Msg36"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                lWeighingID = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclWeighingID").Value.ToString()
                With objWBWeighingInOutPPT
                    .WeighingID = lWeighingID
                    .WBTicketNo = dgvWBWeighingInOut.SelectedRows(0).Cells("dgclWBTicketNo").Value.ToString()
                End With
                dt = objWBWeighingInOutBOL.WeighingID_isExistInGradingFFB(objWBWeighingInOutPPT)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("WeighingID") > 0 Then
                        DisplayInfoMessage("Msg37")
                        ''MessageBox.Show("Record Already In Use", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        rowsAffected = objWBWeighingInOutBOL.Delete_WBWeighingInOut(objWBWeighingInOutPPT)
                        If rowsAffected > 0 Then
                            DisplayInfoMessage("Msg38")
                            ''MessageBox.Show("Data Successfully Deleted", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            WBView_Bind()
                            Reset()
                            tcWeighingInOut.SelectedIndex = 2
                        Else
                            DisplayInfoMessage("Msg39")
                            ''MessageBox.Show(" No Record to Delete", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            End If
        Else
            DisplayInfoMessage("Msg40")
            ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgvWBWeighingInOut_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmsWBWeighing.MouseDown, dgvWBWeighingInOut.MouseDown
        Dim MdiParent As New MDIParent
        If MdiParent.strMenuID <> "M84" Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
                If hti.Type = DataGridViewHitTestType.Cell Then
                    If Not dgvWBWeighingInOut.Rows(hti.RowIndex).Selected Then
                        ' User right clicked a row that is not selected, so throw away all other selections and select this row
                        dgvWBWeighingInOut.ClearSelection()
                        dgvWBWeighingInOut.Rows(hti.RowIndex).Selected = True
                    End If
                End If
            End If
        Else
            cmsWBWeighing.Enabled = False
        End If
    End Sub

    Private Sub dgvWBWeighingInOut_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvWBWeighingInOut.KeyDown
        If e.KeyCode = Keys.Return Then
            WBView_DoubleClick()
            e.Handled = True
        End If
    End Sub

    Private Sub dgvFieldBlockSetup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            If dgvFieldBlockSetup.Rows.Count > 0 Then
                cmbDivision.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvDivision").Value
                cmbYOP.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvYOP").Value
                cmbBlock.Text = dgvFieldBlockSetup.CurrentRow.Cells("gvBlock").Value
                txtQtyFFB.Text = Me.dgvFieldBlockSetup.CurrentRow.Cells("gvQuality").Value
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Update"
                Else
                    btnAdd.Text = "Menambahkan"
                End If

                ''btnAdd.Text = "Update"
                AddFlag = False
            End If
            e.Handled = True
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingInOutFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'If MdiParent.strMenuID = "M1" Then
            ' tcWeighingInOut.TabPages("tpWeighingInOut").Text = rm.GetString("tcWeighingInOut.TabPages(tpWeighingInOut).Text")
            ' tcWeighingInOut.TabPages("tpView").Text = rm.GetString("tcWeighingInOut.TabPages(tpView).Text")


            tcWeighingInOut.TabPages("tpviewsecweight").Text = rm.GetString("tcWeighingInOut.TabPages(tpviewsecweight).Text")
            tcWeighingInOut.TabPages("tpFieldBlockDetails").Text = rm.GetString("tcWeighingInOut.TabPages(tpFieldBlockDetails).Text")






            gbFieldBlockDetails.Text = rm.GetString("gbFieldBlockDetails.Text")
            gbSingleEntry.Text = rm.GetString("gbSingleEntry.Text")
            gbMutiEntry.Text = rm.GetString("gbMutiEntry.Text")
            lblDate.Text = rm.GetString("lblDate.Text")
            chkOthers.Text = rm.GetString("chkOthers.Text")
            lblFFBDeleiveryOrderNo.Text = rm.GetString("lblFFBDeleiveryOrderNo.Text")
            lblSection.Text = rm.GetString("lblSection.Text")
            lblTime.Text = rm.GetString("lblTime.Text")
            lblWBTicketNo.Text = rm.GetString("lblWBTicketNo.Text")
            lblVehicleCode.Text = rm.GetString("lblVehicleCode.Text")
            lblProductCode.Text = rm.GetString("lblProductCode.Text")
            lblSupplier.Text = rm.GetString("lblSupplier.Text")
            lblDriver.Text = rm.GetString("lblDriver.Text")
            lblNoTrip.Text = rm.GetString("lblNoTrip.Text")
            lblDivision.Text = rm.GetString("lblDivision.Text")
            lblYOP.Text = rm.GetString("lblYOP.Text")
            lblBlock.Text = rm.GetString("lblBlock.Text")
            lblQtyFFB.Text = rm.GetString("lblQtyFFB.Text")
            lblTotalBunches.Text = rm.GetString("lblTotalBunches.Text")
            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnDelete.Text = rm.GetString("btnDelete.Text")
            lblFirstWeight.Text = rm.GetString("lblFirstWeight.Text")
            lblSecondWeight.Text = rm.GetString("lblSecondWeight.Text")
            lblNetWeight.Text = rm.GetString("lblNetWeight.Text")
            btnGetWeight.Text = rm.GetString("btnGetWeight.Text")
            chkManualWeight.Text = rm.GetString("chkManualWeight.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")
            btnSave.Text = rm.GetString("btnSave.Text")
            btnUpdate.Text = rm.GetString("btnUpdate.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            lblsearchby.Text = rm.GetString("lblsearchby.Text")

            lblviewDate.Text = rm.GetString("lblviewDate.Text")
            lblviewWBTicketNo.Text = rm.GetString("lblviewWBTicketNo.Text")
            lblviewVehicleNo.Text = rm.GetString("lblviewVehicleNo.Text")
            lblviewProductCode.Text = rm.GetString("lblviewProductCode.Text")



            ''for view II weight

            plWeighingInOutSearchIIWeight.CaptionText = rm.GetString("plWeighingInOutSearch.CaptionText")
            lblsearchbyIIWeight.Text = rm.GetString("lblsearchby.Text")
            lblviewDateIIWeight.Text = rm.GetString("lblviewDate.Text")
            lblviewWBTicketNoIIWeight.Text = rm.GetString("lblviewWBTicketNo.Text")
            lblviewVehicleNoIIWeight.Text = rm.GetString("lblviewVehicleNo.Text")
            'lblviewProductDescIIWeight.Text = rm.GetString("lblviewProductCode.Text")
            BtnViewReportIIWeight.Text = rm.GetString("btnviewReport.Text")
            btnSearchIIWeight.Text = rm.GetString("btnSearch.Text")
            lblTextmsg.Text = rm.GetString("lblTextmsg.Text")





            'chkViewOthers.Text = rm.GetString("chkViewOthers.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")
            plWeighingInOutSearch.CaptionText = rm.GetString("plWeighingInOutSearch.CaptionText")
            ' lblsearchby.Text = rm.GetString("lblsearchby.text")

            'gbEnquipmentData.Text = rm.GetString("gbEnquipmentData.Text")
            'gbIPRAdd.Text	Detail IPR
            dgvFieldBlockSetup.Columns("gvDivision").HeaderText = rm.GetString("dgvFieldBlockSetup.Columns(gvDivision).HeaderText")
            dgvFieldBlockSetup.Columns("gvYOP").HeaderText = rm.GetString("dgvFieldBlockSetup.Columns(gvYOP).HeaderText")
            dgvFieldBlockSetup.Columns("gvBlock").HeaderText = rm.GetString("dgvFieldBlockSetup.Columns(gvBlock).HeaderText")
            dgvFieldBlockSetup.Columns("gvQuality").HeaderText = rm.GetString("dgvFieldBlockSetup.Columns(gvQuality).HeaderText")




            'dgvWBWeighingInOut.Columns("dgclOthers").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclOthers).HeaderText")
            dgvWBWeighingInOut.Columns("dgclDate").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclDate).HeaderText")
            dgvWBWeighingInOut.Columns("dgclTime").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclTime).HeaderText")
            dgvWBWeighingInOut.Columns("dgclTimeOut").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclTimeOut).HeaderText")
            dgvWBWeighingInOut.Columns("dgclSession").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclSession).HeaderText")
            dgvWBWeighingInOut.Columns("dgclWBTicketNo").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclWBTicketNo).HeaderText")
            dgvWBWeighingInOut.Columns("dgclVehicleCode").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclVehicleCode).HeaderText")
            dgvWBWeighingInOut.Columns("dgclProductCode").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclProductCode).HeaderText")
            dgvWBWeighingInOut.Columns("dgclNoofTrip").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclNoofTrip).HeaderText")
            dgvWBWeighingInOut.Columns("dgclRemarks").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclRemarks).HeaderText")
            dgvWBWeighingInOut.Columns("dgclFirstWeight").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclFirstWeight).HeaderText")
            dgvWBWeighingInOut.Columns("dgclSecondWeight").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclSecondWeight).HeaderText")
            dgvWBWeighingInOut.Columns("dgclNetWeight").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclNetWeight).HeaderText")


            ''for view II weight

            'dgvWeighingInOutIIWeight.Columns("dgclOthersII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclOthers).HeaderText")
            dgvWeighingInOutIIWeight.Columns("dgclDateII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclDate).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclTimeII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclTime).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclTimeOutII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclTimeOut).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclSessionII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclSession).HeaderText")
            dgvWeighingInOutIIWeight.Columns("dgclWBTicketNoII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclWBTicketNo).HeaderText")
            dgvWeighingInOutIIWeight.Columns("dgclVehicleCodeII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclVehicleCode).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclProductCodeII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclProductCode).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclNoofTripII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclNoofTrip).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclRemarksII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclRemarks).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclFirstWeightII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclFirstWeight).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclSecondWeightII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclSecondWeight).HeaderText")
            'dgvWeighingInOutIIWeight.Columns("dgclNetWeightII").HeaderText = rm.GetString("dgvWBWeighingInOut.Columns(dgclNetWeight).HeaderText")





            AddToolStripMenuItem.Text = rm.GetString("AddToolStripMenuItem.Text")
            EditUpdateToolStripMenuItem.Text = rm.GetString("EditUpdateToolStripMenuItem.Text")
            DeleteToolStripMenuItem.Text = rm.GetString("DeleteToolStripMenuItem.Text")



        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingInOutFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub txtVehicleCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave
        Dim dt As New DataTable
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL

        objWBWeighingInOutPPT.VehicleCode = txtVehicleCode.Text
        If txtVehicleCode.Text.Trim <> String.Empty Then
            dt = objWBWeighingInOutBOL.WBVehicleCode_Select(objWBWeighingInOutPPT)
            If dt.Rows.Count > 0 Then
                lSupplietDetID = dt.Rows(0).Item("WBVehicleID").ToString()
                ' To bind NoofTrip
                tofindNoofTrip()
            Else
                DisplayInfoMessage("Msg41")
                ''MessageBox.Show("Invalid Vehicle Code", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtVehicleCode.Text = String.Empty
                txtNoTrip.Text = String.Empty
                txtVehicleCode.Focus()
            End If
        Else
            txtNoTrip.Text = String.Empty
        End If
    End Sub

    Private Sub txtSupplier_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplier.Leave
        Dim dt As New DataTable
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL

        objWBWeighingInOutPPT.Supplier = txtSupplier.Text
        If txtSupplier.Text.Trim <> String.Empty Then
            dt = objWBWeighingInOutBOL.WBSupplier_Select(objWBWeighingInOutPPT)
            If dt.Rows.Count > 0 Then
                txtSupplier.Text = dt.Rows(0).Item("SupplierCode").ToString()
                txtProductCode.Text = dt.Rows(0).Item("ProductCode").ToString()
                lSupplierCustID = dt.Rows(0).Item("SupplierCustID").ToString()
                lProductID = dt.Rows(0).Item("ProductID").ToString()
                lblProductDesc.Text = dt.Rows(0).Item("ProductDescp").ToString()
            Else
                DisplayInfoMessage("Msg42")
                ''MessageBox.Show("Invalid Supplier Code", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSupplier.Text = String.Empty
                txtProductCode.Text = String.Empty
                lblProductDesc.Text = String.Empty
                txtSupplier.Focus()
            End If
        Else
            txtProductCode.Text = String.Empty
            lblProductDesc.Text = String.Empty
        End If
    End Sub

    Private Sub txtProductCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductCode.Leave
        Dim dt As New DataTable
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL

        objWBWeighingInOutPPT.ProductCode = txtProductCode.Text
        If txtProductCode.Text.Trim <> String.Empty Then
            dt = objWBWeighingInOutBOL.WBProductCode_Select(objWBWeighingInOutPPT)
            If dt.Rows.Count > 0 Then
                txtProductCode.Text = dt.Rows(0).Item("ProductCode").ToString()
                lblProductDesc.Text = dt.Rows(0).Item("Productdescp").ToString()
                lProductID = dt.Rows(0).Item("ProductID").ToString()
            Else
                DisplayInfoMessage("Msg43")
                ''MessageBox.Show("Invalid ProductCode ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtProductCode.Text = String.Empty
                txtProductCode.Focus()
            End If
        End If
        If txtProductCode.Text = String.Empty Then
            lblProductDesc.Text = String.Empty
        End If
    End Sub

    Private Sub chkITNDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWbDate.CheckedChanged
        If chkWbDate.Checked = True Then
            dtpviewWeighingDate.Enabled = True
            dtpviewWeighingDate.Focus()
        Else
            dtpviewWeighingDate.Enabled = False
        End If
    End Sub

    Public Shared Sub DisableField(ByVal txtboxname1 As TextBox, ByVal txtboxname2 As TextBox, ByVal txtboxname3 As TextBox, ByVal txtboxname4 As TextBox, ByVal txtboxname5 As TextBox, ByVal txtboxname6 As TextBox)
        txtboxname1.BackColor = Color.White
        txtboxname1.ForeColor = Color.Black
        txtboxname1.Enabled = False

        txtboxname2.BackColor = SystemColors.Control
        txtboxname2.ForeColor = Color.Black
        txtboxname2.Enabled = False

        txtboxname3.BackColor = SystemColors.Control
        txtboxname3.ForeColor = Color.Black
        txtboxname3.Enabled = False

        txtboxname4.BackColor = SystemColors.Control
        txtboxname4.ForeColor = Color.Black
        txtboxname4.Enabled = False

        txtboxname5.BackColor = SystemColors.Control
        txtboxname5.ForeColor = Color.Black
        txtboxname5.Enabled = False

        txtboxname6.BackColor = SystemColors.Control
        txtboxname6.ForeColor = Color.Black
        txtboxname6.Enabled = False
    End Sub

    Public Shared Sub ReadonlyTrue(ByVal txtboxname1 As TextBox)
        txtboxname1.ReadOnly = True
        txtboxname1.TabStop = False
    End Sub

    Public Shared Sub ReadonlyFalse(ByVal txtboxname1 As TextBox)
        txtboxname1.ReadOnly = False
        txtboxname1.TabStop = True
    End Sub

    Private Sub dgvWBWeighingInOut_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvWBWeighingInOut.RowPrePaint
        'For Each row As DataGridViewRow In Me.dgvWBWeighingInOut.Rows
        '    If Not row.IsNewRow Then
        '        If row.Cells("dgclSecondWeight").Value.ToString().Trim() = "" Then
        '            row.DefaultCellStyle.BackColor = Color.LightSkyBlue
        '        End If
        '    End If
        'Next
        'If Not objUserLoginBOl.Privilege(btnUpdate, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub txtQtyFFB_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyFFB.KeyPress
        If Char.IsDigit(e.KeyChar) Then Exit Sub
        If Char.IsControl(e.KeyChar) Then Exit Sub

        If e.KeyChar = "" Then
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.IndexOf("") < 0 Then
                e.Handled = False
                e.Handled = True
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.Leave
        If txtDate.Text.Length = 10 Then
            Dim Str As String = txtDate.Text.Trim
            Dim y As String = Str.Substring(6, 4)
            Dim b As String = Str.Substring(3, 2)
            Dim d As String = Str.Substring(0, 2)
            CheckDate(d, b, y)
        Else
            MessageBox.Show("Inavlid Date format", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDate.Text = String.Empty
            txtDate.Text = Format(System.DateTime.Now, "dd/MM/yyyy")
            txtDate.Focus()
        End If
    End Sub
    Private Sub CheckDate(ByVal d As String, ByVal m As String, ByVal y As String)
        Try
            Dim mydate As Date
            mydate = New DateTime(y, m, d)
        Catch obj As Exception
            MessageBox.Show(obj.Message)
            txtDate.Text = String.Empty
            txtDate.Text = Format(System.DateTime.Now, "dd/MM/yyyy")

            txtDateFB.Text = Format(System.DateTime.Now, "dd/MM/yyyy")
            txtDate.Focus()
        End Try
    End Sub

    Private Sub btnGetWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetWeight.Click
        'old code
        'Try
        '    If chkGetWeight.Checked = False Then Exit Sub
        '    CheckForIllegalCrossThreadCalls = False
        '    If Not IsPortAvailable(1) Then   '1- COM1
        '        MessageBox.Show("Port Not Available")
        '        Exit Sub
        '    End If
        '    WBOCP.Open(1, 9600, 8, Rs232.DataParity.Parity_None, Rs232.DataStopBit.StopBit_1, 4096)
        '    If WBOCP.IsOpen = False Then WBOCP.Open()
        '    WBTimer.Enabled = True


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Try
            If chkGetWeight.Checked = False Then Exit Sub

            Port_Open()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Port_Open()
        comm.Parity = "None"
        comm.StopBits = "One"
        comm.DataBits = 8
        comm.BaudRate = 9600
        'comm.DisplayWindow = rtbDisplay
        comm.OpenPort()

        'cmdOpen.Enabled = False
        'cmdClose.Enabled = True
        'cmdSend.Enabled = True
    End Sub

    Private Sub WBTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBTimer.Tick
        Try
            While (WBOCP.Read(1) <> -1)
                If txtFirstWeight.Text = String.Empty And txtFirstWeightManual.Text = String.Empty And txtSecondWeightManual.Text = String.Empty Then
                    txtFirstWeight.Text = Chr(WBOCP.InputStream(0))
                ElseIf txtFirstWeight.Text <> String.Empty And txtFirstWeightManual.Text = String.Empty And txtSecondWeightManual.Text = String.Empty Then
                    txtSecondWeight.Text = Chr(WBOCP.InputStream(0))
                Else
                    MessageBox.Show("Please, clear Manual Weight If Exists", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'txtFirstWeight.Text = Chr(WBOCP.InputStream(0))

            End While
            WBOCP.ClearInputBuffer()
            WBOCP.Close()

            WBTimer.Enabled = False
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Function IsPortAvailable(ByVal ComPort As Integer) As Boolean
        Try
            '"COM1", 9600, Parity.None, 8, StopBits.One
            WBOCP.Open(ComPort, 9600, 8, Rs232.DataParity.Parity_None, _
                Rs232.DataStopBit.StopBit_1, 4096)
            ' If it makes it to here, then the Comm Port is available.
            WBOCP.Close()
            Return True
        Catch
            ' If it gets here, then the attempt to open the Comm Port
            '   was unsuccessful.
            Return False
        End Try
    End Function

    Private Sub BtnViewReportIIWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewReportIIWeight.Click
        Dim dt As DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        dt = objWBTicketInOutBOL.WBTicketNoRecord_isExist(objWBTicketInOutPPT)

        PrintFlag = True
        StrFrmName = "WBWeighingInOutRpt"
        lWeight = "Second"
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
    End Sub

    Private Sub btnSearchIIWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchIIWeight.Click
        If txtViewIIWBTicketNo.Text = String.Empty And txtViewIIVehicleCode.Text = String.Empty And txtViewIIProductDesc.Text = String.Empty And ChkIIDate.Checked = False And chkNOTFBDetails.Checked = False Then
            WBViewIIWeight_Bind()
            DisplayInfoMessage("Msg33")
            ''MessageBox.Show("Please enter search criteria", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            WBViewIIWeight_Bind()
        End If
    End Sub

    Private Sub dgvWeighingInOutIIWeight_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWeighingInOutIIWeight.CellDoubleClick
        WBViewII_DoubleClick()
    End Sub

    Private Sub ChkIIDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIIDate.CheckedChanged
        If ChkIIDate.Checked = True Then
            dtpviewIIWeighingDate.Enabled = True
            dtpviewIIWeighingDate.Focus()
        Else
            dtpviewIIWeighingDate.Enabled = False
        End If
    End Sub

    Private Sub btnCloseImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseImport.Click
        btnClose_Click(sender, e)
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        'TRY CATCH HANDLED BELOW

        'For Record Count
        Dim intRecCount As Int64

        'SQL Server Information
        Dim ConStr As String = Common_PPT.GlobalPPT.ConnectionString
        Dim SQLConn As SqlConnection
        SQLConn = New SqlConnection(ConStr)
        SQLConn.Open()

        Dim Transaction As SqlTransaction
        Transaction = SQLConn.BeginTransaction()

        Dim SQLCmd As New SqlCommand()
        SQLCmd.Connection = SQLConn

        Try
            Cursor = Cursors.WaitCursor
            TimeTaken = DateTime.Now
            IsError = False
            fname = System.Windows.Forms.Application.StartupPath + "\\ImportLog\\ImportLog_WeightBridgeModule_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".txt"
            llErrorLogFilePath.Text = fname
            lblErrLog.Visible = True
            If (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\ImportLog") = False) Then
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\ImportLog")
            End If
            sr = File.CreateText(fname)

            sr.WriteLine("###### WEIGHBRIDGE MODULE DATA IMPORT ######")
            txtLog.Text = ""
            UpdText("DATA IMPORT FOR WEIGHBRIDGE MODULE STARTED .... PLEASE WAIT")
            UpdText("###########################################################")
            UpdateStatusBar("WEIGHBRIDGE MODULE - DATA IMPORT STARTED")
            sr.WriteLine("###########################################################")

            'NOTE: OLD Codes which handle WeighBridge.Customer import etc are removed from this procedure, if you need please refer to the old backup 

            Dim intAccessMaxNo As Int64
            Dim dbAccess As Database = DatabaseFactory.CreateDatabase("CSWeightBridge")
            Dim IR As IDataReader
            Dim intSQLMaxNo As Int64
            Dim strWhereCondition As String = ""
            Dim NewID As String = ""

            'Access(Information)
            '' tblCustomers to Weighbridge.WBSupplier
            UpdateStatusBar("CUSTOMER MASTER")
            sr.WriteLine()
            sr.WriteLine("CUSTOMER MASTER")
            sr.WriteLine("---------------")
            dbAccess = DatabaseFactory.CreateDatabase("CSWeightBridge")

            strQry = "select iif(max(ID) is null,0,max(ID)) as RecCnt from tblCustomers"
            intAccessMaxNo = dbAccess.ExecuteScalar(CommandType.Text, strQry)

            'x            strQry = "select isnull(max(convert(bigint,Code)),0) from Weighbridge.WBSupplier"
            strQry = "select * from Weighbridge.WBSupplier"
            SQLCmd.CommandText = strQry
            SQLCmd.Transaction = Transaction
            intSQLMaxNo = SQLCmd.ExecuteScalar()

            strWhereCondition = ""
            intRecCount = 0

            'x            If (intAccessMaxNo > intSQLMaxNo) Then
            'x            strWhereCondition = " where ID >" & intSQLMaxNo

            strQry = "select "
            strQry += "ID, Code, Name "
            'x            strQry += "from tblCustomers" & strWhereCondition
            strQry += "from tblCustomers"
            IR = dbAccess.ExecuteReader(CommandType.Text, strQry)

            'strQry = "delete from Weighbridge.WBSupplier"
            'SQLCmd.CommandText = strQry
            'SQLCmd.Transaction = Transaction
            'SQLCmd.ExecuteNonQuery()

            While IR.Read()
                strQry = "select Count(*) from Weighbridge.WBSupplier where SupplierCustID = '" + GetCustCode(IR("Code").ToString()) + "'"
                SQLCmd.CommandText = strQry
                SQLCmd.Transaction = Transaction
                intSQLMaxNo = SQLCmd.ExecuteScalar()

                'If GetCustCode(IR("Code").ToString()) = String.Empty Or GetCustCode(IR("Code").ToString()) = "ERR" Then
                If (intSQLMaxNo = 0) And (GetCustCode(IR("Code").ToString()) <> String.Empty Or GetCustCode(IR("Code").ToString()) <> "ERR") Then

                    'strQry = "select CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR) from Weighbridge.WBSupplier"
                    'SQLCmd.CommandText = strQry
                    'SQLCmd.Transaction = Transaction
                    'NewID = GlobalPPT.strEstateID + "R" + SQLCmd.ExecuteScalar()

                    'strQry = "insert into Weighbridge.WBSupplier "
                    'strQry += "(SupplierCustID,EstateID,Code,NAme"
                    'strQry += ",CreatedBy,CreatedOn,ModifiedBy,ModifiedOn "
                    'strQry += ") values ('"

                    'strQry += NewID + "','"
                    'strQry += GlobalPPT.strEstateID + "','"
                    'strQry += IR("Code").ToString() + "','"
                    'strQry += IR("Name").ToString() + "','"
                    'strQry += GlobalPPT.strUserName + "',"
                    'strQry += "getdate()" + ",'"
                    'strQry += GlobalPPT.strUserName + "',"
                    'strQry += "getdate()" + ")"

                    strQry = "insert into Weighbridge.WBSupplier "
                    strQry += "(SupplierCustID,EstateID,Code,NAme"
                    strQry += ",CreatedBy,CreatedOn,ModifiedBy,ModifiedOn "
                    strQry += ") values ('"

                    'strQry += IR("Code").ToString() + "','"
                    strQry += GetCustCode(IR("Code").ToString()) + "','"
                    strQry += GlobalPPT.strEstateID + "','"
                    strQry += IR("ID").ToString() + "','"
                    strQry += IR("Name").ToString() + "','"
                    strQry += GlobalPPT.strUserName + "',"
                    strQry += "getdate()" + ",'"
                    strQry += GlobalPPT.strUserName + "',"
                    strQry += "getdate()" + ")"


                    intRecCount += 1

                    Try
                        SQLCmd.CommandText = strQry
                        SQLCmd.Transaction = Transaction
                        SQLCmd.ExecuteNonQuery()
                    Catch SqEx As SqlException
                        IsError = True
                        sr.WriteLine(SqEx.Message)
                        sr.WriteLine("Record No" + +intRecCount.ToString())
                        intRecCount -= 1
                        sr.WriteLine(strQry)
                    End Try
                End If
            End While
            IR.Close()
            'x            End If
            sr.WriteLine("Total No Of Records Imported : " + intRecCount.ToString())
            UpdText("CUSTOMER MASTER")
            UpdText("Total No Of Records Imported : " + intRecCount.ToString())



            'tblproducts to Weighbridge.WBProductMaster 
            UpdateStatusBar("PRODUCT MASTER")
            sr.WriteLine()
            sr.WriteLine("PRODUCT MASTER")
            sr.WriteLine("---------------")


            strQry = "select iif(max(ID) is null,0,max(ID)) as RecCnt from tblproducts"
            intAccessMaxNo = dbAccess.ExecuteScalar(CommandType.Text, strQry)

            'x strQry = "select isnull(max(convert(bigint,ProductCode)),0) from Weighbridge.WBProductMaster"
            'x SQLCmd.CommandText = strQry
            'x SQLCmd.Transaction = Transaction
            'x intSQLMaxNo = SQLCmd.ExecuteScalar()

            strWhereCondition = ""
            intRecCount = 0

            'x If (intAccessMaxNo > intSQLMaxNo) Then
            'x strWhereCondition = " where ID >" & intSQLMaxNo

            strQry = "select "
            strQry += "Code, ID, Name "
            strQry += "from tblproducts" & strWhereCondition
            IR = dbAccess.ExecuteReader(CommandType.Text, strQry)

            'strQry = "delete from Weighbridge.WBProductMaster"
            'SQLCmd.CommandText = strQry
            'SQLCmd.Transaction = Transaction
            'SQLCmd.ExecuteNonQuery()

            While IR.Read()
                strQry = "select count(*) from Weighbridge.WBProductMaster"
                strQry += " where ProductId = '" + IR("Code").ToString() + "'"
                SQLCmd.CommandText = strQry
                SQLCmd.Transaction = Transaction
                intSQLMaxNo = SQLCmd.ExecuteScalar()


                If intSQLMaxNo = 0 Then
                    strQry = "insert into Weighbridge.WBProductMaster "
                    strQry += "(ProductID,EstateID,ProductCode,ProductDescp,Type"
                    strQry += ",CreatedBy,CreatedOn,ModifiedBy,ModifiedOn "
                    strQry += ") values ('"
                    strQry += IR("Code").ToString() + "','"
                    strQry += GlobalPPT.strEstateID + "','"
                    strQry += IR("ID").ToString() + "','"
                    strQry += IR("Name").ToString() + "','"
                    strQry += "I" + "','"
                    strQry += GlobalPPT.strUserName + "',"
                    strQry += "getdate()" + ",'"
                    strQry += GlobalPPT.strUserName + "',"
                    strQry += "getdate()" + ")"

                    intRecCount += 1

                    Try
                        SQLCmd.CommandText = strQry
                        SQLCmd.Transaction = Transaction
                        SQLCmd.ExecuteNonQuery()
                    Catch SqEx As SqlException
                        IsError = True
                        sr.WriteLine(SqEx.Message)
                        sr.WriteLine("Record No" + +intRecCount.ToString())
                        intRecCount -= 1
                        sr.WriteLine(strQry)
                    End Try
                End If

            End While
            IR.Close()
            'x End If
            sr.WriteLine("Total No Of Records Imported : " + intRecCount.ToString())
            UpdText("PRODUCT MASTER")
            UpdText("Total No Of Records Imported : " + intRecCount.ToString())


            'tblVehicles to Weighbridge.WBVehicle 
            UpdateStatusBar("VEHICLE MASTER")
            sr.WriteLine()
            sr.WriteLine("VEHICLE MASTER")
            sr.WriteLine("---------------")

            strQry = "select iif(max(ID) is null,0,max(ID)) as RecCnt from tblVehicles"
            intAccessMaxNo = dbAccess.ExecuteScalar(CommandType.Text, strQry)

            '11-11-11 strQry = "select isnull(max(convert(bigint,VHNO)),0) from Weighbridge.WBVehicle"
            '11-11-11 SQLCmd.CommandText = strQry
            '11-11-11 SQLCmd.Transaction = Transaction
            '11-11-11 intSQLMaxNo = SQLCmd.ExecuteScalar()

            strWhereCondition = ""
            intRecCount = 0

            '11-11-11 If (intAccessMaxNo > intSQLMaxNo) Then
            '11-11-11 strWhereCondition = " where ID >" & intSQLMaxNo

            strQry = "select "
            strQry += "ID, Number "
            strQry += "from tblVehicles" & strWhereCondition
            IR = dbAccess.ExecuteReader(CommandType.Text, strQry)

            'strQry = "delete from Weighbridge.WBVehicle"
            'SQLCmd.CommandText = strQry
            'SQLCmd.Transaction = Transaction
            'SQLCmd.ExecuteNonQuery()

            While IR.Read()

                strQry = "select count(*) from Weighbridge.WBVehicle"
                strQry += " where WBVEhicleID = '" + IR("Number").ToString() + "'"
                SQLCmd.CommandText = strQry
                SQLCmd.Transaction = Transaction
                intSQLMaxNo = SQLCmd.ExecuteScalar()

                If IR("Number").ToString <> "" Then
                    If intSQLMaxNo = 0 Then
                        strQry = "insert into Weighbridge.WBVehicle "
                        strQry += "(WBVEhicleID,EstateID,VHNO,VHDescp, VHRegNo"
                        strQry += ",CreatedBy,CreatedOn,ModifiedBy,ModifiedOn "
                        strQry += ") values ('"

                        strQry += IR("Number").ToString() + "','" 'WBVEhicleID
                        strQry += GlobalPPT.strEstateID + "','" 'EstateID
                        strQry += IR("ID").ToString() + "','" 'VHNO
                        strQry += IR("Number").ToString() + "','" 'VHDescp
                        strQry += IR("ID").ToString() + "','" 'VHRegNo
                        strQry += GlobalPPT.strUserName + "',"
                        strQry += "getdate()" + ",'"
                        strQry += GlobalPPT.strUserName + "',"
                        strQry += "getdate()" + ")"

                        intRecCount += 1

                        Try
                            SQLCmd.CommandText = strQry
                            SQLCmd.Transaction = Transaction
                            SQLCmd.ExecuteNonQuery()
                        Catch SqEx As SqlException
                            IsError = True
                            sr.WriteLine(SqEx.Message)
                            sr.WriteLine("Record No" + +intRecCount.ToString())
                            intRecCount -= 1
                            sr.WriteLine(strQry)
                        End Try
                    End If
                End If

            End While
            IR.Close()

            '11-11-11 End If
            UpdText("VEHICLE MASTER")
            UpdText("Total No Of Records Imported : " + intRecCount.ToString())
            sr.WriteLine("Total No Of Records Imported : " + intRecCount.ToString())

            'Changes Done On 29-Mar-2011
            'tblTransactions to Weighbridge.WBWeighingInOut
            UpdateStatusBar("Weighing In Out")
            sr.WriteLine()
            sr.WriteLine("Weighing In Out")
            sr.WriteLine("---------------")

            'SQL SERVER >> Following select statement is used to form the "Where Condition (WeighingID)" whose secondweight =0 
            strQry = "select WeighingID from Weighbridge.WBWeighingInOut where SecondWeight =0"
            SQLCmd.CommandText = strQry
            SQLCmd.Transaction = Transaction
            Dim DR As DbDataReader
            DR = SQLCmd.ExecuteReader()

            strWhereCondition = ""
            While DR.Read()
                If strWhereCondition.Equals("") Then
                    strWhereCondition = " where ID in (" + DR("WeighingID").ToString()
                Else
                    strWhereCondition += "," + DR("WeighingID").ToString()
                End If
            End While
            If strWhereCondition <> "" Then strWhereCondition += ")"
            DR.Close()

            strQry = "select ID, iif(Weigh1 is null,0,Weigh1) as Wt1, iif(Weigh2 is null,0,Weigh2) as Wt2, "
            strQry += "iif(Wt1 >0 and wt2 >0,Abs(Wt1-Wt2),0) as NetWeight "
            strQry += "from tblTransactions" & strWhereCondition
            IR = dbAccess.ExecuteReader(CommandType.Text, strQry)
            While IR.Read()
                strQry = "update Weighbridge.WBWeighingInOut "
                strQry += " set SecondWeight =" + Convert.ToDecimal(IR("Wt2").ToString()).ToString()
                strQry += ",NetWeight =" + Convert.ToDecimal(IR("NetWeight").ToString()).ToString()
                strQry += ",ModifiedBy ='" + GlobalPPT.strUserName + "',ModifiedOn =getdate()"
                strQry += " where WeighingID ='" + IR("ID").ToString() + "'"
                Try
                    SQLCmd.CommandText = strQry
                    SQLCmd.Transaction = Transaction
                    SQLCmd.ExecuteNonQuery()
                Catch SqEx As SqlException
                    IsError = True
                    sr.WriteLine(SqEx.Message)
                    sr.WriteLine("Record No" + intRecCount.ToString())
                    intRecCount -= 1
                    sr.WriteLine(strQry)
                End Try
            End While
            IR.Close()

            strQry = "select iif(max(ID) is null,0,max(ID)) as RecCnt from tblTransactions where year(datetime1) >= 2013" ' and month(datetime1) >= 8" changed for 2013
            intAccessMaxNo = dbAccess.ExecuteScalar(CommandType.Text, strQry)

            strQry = "select isnull(max(convert(bigint,WeighingID)),0) from Weighbridge.WBWeighingInOut"
            SQLCmd.CommandText = strQry
            SQLCmd.Transaction = Transaction
            intSQLMaxNo = SQLCmd.ExecuteScalar()

            strWhereCondition = " where year(datetime1) >= 2013" ' and month(datetime1) >= 8 " changed for 2013
            intRecCount = 0

            If (intAccessMaxNo > intSQLMaxNo) Then
                strWhereCondition += " and ID >" & intSQLMaxNo

                strQry = "select ID,Format(DateTime1, 'yyyy/mm/dd') as TrxnDate, Format (DateTime1, 'short time') as TrxnTime,"
                strQry += "Format (DateTime1, 'medium time') as ForSection,"
                strQry += "RecNo,DoNo,VehNo,CustCode,ProductCode,DriverName,iif(Weigh1 is null,0,Weigh1) as Wt1,"
                strQry += "iif(Weigh2 is null,0,Weigh2) as Wt2,"
                strQry += "iif(Wt1 >0 and wt2 >0,Abs(Wt1-Wt2),0) as NetWeight "
                strQry += "from tblTransactions" & strWhereCondition

                IR = dbAccess.ExecuteReader(CommandType.Text, strQry)

                'strQry = "delete from Weighbridge.WBWeighingInOut"
                'SQLCmd.CommandText = strQry
                'SQLCmd.Transaction = Transaction
                'SQLCmd.ExecuteNonQuery()

                While IR.Read()

                    'Dim strCustCode As String
                    'strCustCode = GetCustCode(IR("CustCode").ToString())

                    'If strCustCode <> "" And strCustCode <> "ERR" Then

                    strQry = "INSERT INTO Weighbridge.WBWeighingInOut "
                    strQry += "(WeighingID,EstateID,ActiveMonthYearID,WeighingDate,WeighingTime,Section,Others,WBTicketNo,FFBDeliveryOrderNo,"
                    strQry += "WBVehicleID,SupplierCustID,ProductID,DriverName,NoTrip,FirstWeight,SecondWeight,NetWeight,ManualWeight,Remarks,"
                    strQry += "CreatedBy,CreatedOn,ModifiedBy,ModifiedOn) values ('"
                    strQry += IR("ID").ToString() + "','"
                    strQry += GlobalPPT.strEstateID + "','"
                    strQry += GlobalPPT.strActMthYearID + "','"
                    strQry += IR("TrxnDate").ToString() + "','"
                    strQry += IR("TrxnTime").ToString() + "','"
                    strQry += IIf(Mid(IR("ForSection").ToString(), Len(IR("ForSection").ToString()) - 1, Len(IR("ForSection").ToString())) = "AM", "Morning", "Evening") + "','"
                    strQry += "0" + "','" 'Others
                    strQry += IR("RecNo").ToString() + "','"  'TicketNO
                    strQry += IR("DoNo").ToString() + "','"  'Delivery Order No
                    'strQry += IR("VehNo").ToString() + "','"
                    strQry += IR("VehNo").ToString() + "','"
                    'strQry += IR("CustCode").ToString() + "','" ' strCustCode 
                    strQry += GetCustCode(IR("CustCode").ToString()) + "','" ' strCustCode 
                    strQry += GetProductCode(IR("ProductCode").ToString()) + "','" 'strProductCode
                    strQry += IR("DriverName").ToString().Replace("'", "''") + "',"
                    'Can get No Of Trips - from GetNoofTrip (below) - including this line, getting hanged bcas different connection, now 
                    'hardcoded to 1, later take care of this issue
                    'strQry += GetNoofTrip(IR("VehNo").ToString(), IR("TrxnDate").ToString()) + "','"
                    strQry += "1" + "," 'NO OF TRIP
                    strQry += Convert.ToDecimal(IR("Wt1").ToString()).ToString() + ","
                    strQry += Convert.ToDecimal(IR("Wt2").ToString()).ToString() + ","
                    strQry += Convert.ToDecimal(IR("NetWeight").ToString()).ToString() + ","
                    strQry += "0" + ",'" 'manual wt
                    strQry += "" + "','" 'REmarks
                    strQry += GlobalPPT.strUserName + "',"
                    strQry += "getdate()" + ",'"
                    strQry += GlobalPPT.strUserName + "',"
                    strQry += "getdate()" + ")"

                    intRecCount += 1

                    Try
                        SQLCmd.CommandText = strQry
                        SQLCmd.Transaction = Transaction
                        SQLCmd.ExecuteNonQuery()
                    Catch SqEx As SqlException
                        IsError = True
                        sr.WriteLine(SqEx.Message)
                        sr.WriteLine("Record No" + intRecCount.ToString())
                        intRecCount -= 1
                        sr.WriteLine(strQry)
                    End Try

                    'End If
                End While
                IR.Close()

                strQry = "update WIO set WIO.ActiveMonthYearID = Temp.ActiveMonthYearID "
                strQry += "from Weighbridge.WBWeighingInOut WIO,"
                strQry += "(select WIO.Id,FY.FiscalYearID, AMY.ActiveMonthYearID from Weighbridge.WBWeighingInOut WIO "
                strQry += "left outer join General.FiscalYear FY on (WIO.WeighingDate between FY.FromDT and FY.ToDT) "
                strQry += "left outer join General.ActiveMonthYear AMY on (AMY.AYear = FY.FYear and AMY.AMonth = FY.Period) "
                strQry += "where Convert(bigint, WeighingID) > " & intSQLMaxNo
                strQry += " and AMY.ModID = '4' and AMY.EstateID = '" + GlobalPPT.strEstateID + "') temp "
                strQry += "where WIO.Id = temp.Id and Convert(bigint, WeighingID) > " & intSQLMaxNo
                SQLCmd.CommandText = strQry
                SQLCmd.CommandTimeout = 0
                SQLCmd.Transaction = Transaction
                SQLCmd.ExecuteNonQuery()

                UpdateCPOProductionLogReceivedDate()

            End If

            sr.WriteLine("Total No Of Records Imported : " + intRecCount.ToString())
            UpdText("Weighing In Out")
            UpdText("Total No Of Records Imported : " + intRecCount.ToString())


            Transaction.Commit()

            SQLConn.Close()

            sr.WriteLine()

            UpdateStatusBar("WEIGHBRIDGE MODULE - DATA IMPORT COMPLETED")
            TimeTakenStr = "Time Taken - No Of Seconds : " + TimeTaken.Subtract(DateTime.Now).ToString().Replace("-", "")

            If (IsError = False) Then
                UpdText("Data Imported Successfully - Please refer the Log : ")
                UpdText(fname)
                UpdText(Chr(13) + Chr(10))
                UpdText(TimeTakenStr)
                UpdText("###########################################################")
                MsgBox("Data Imported Successfully - Please refer the Log : " + fname)
                sr.WriteLine("Data Imported Successfully")
            Else
                UpdText("Data Imported with Error - Please refer the Log : ")
                UpdText(fname)
                UpdText(Chr(13) + Chr(10))
                UpdText(TimeTakenStr)
                UpdText("###########################################################")
                MsgBox("Data Imported with Error - Please refer the Log : " + fname)
                sr.WriteLine("Data Imported with Error")
            End If

        Catch SqEx As SqlException
            Transaction.Rollback()
            sr.WriteLine(SqEx.Message)
            MsgBox(SqEx.Message)
        Catch ex As Exception
            Transaction.Rollback()
            sr.WriteLine(ex.Message)
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
            sr.WriteLine()
            sr.WriteLine(TimeTakenStr)
            sr.WriteLine()
            sr.WriteLine("* * * DATA IMPORT COMPLETED * * * ")
            sr.WriteLine()
            sr.WriteLine("###########################################################")
            sr.Close()
        End Try
    End Sub

    Private Sub UpdateCPOProductionLogReceivedDate()
        Production_BOL.CPOProductionLogBOL.UpdateCPOProductionLogReceivedDate()
    End Sub
    Private Function GetProductCode(ByVal strProductCode As String) As String
        If GlobalPPT.strEstateID = "M9" Then
            If IsNumeric(strProductCode) = False Then
                If strProductCode = "001A" Or strProductCode = "001B" Then 'FFB
                    Return "001"
                Else
                    Return "ERRProduct"
                End If
            End If

            Dim intProdCode As Int16
            intProdCode = Val(strProductCode)
            If intProdCode = 1 Then  'JAMJANG KOSONG
                Return "001"
            ElseIf intProdCode = 5 Then  'JAMJANG KOSONG
                Return "002"
            ElseIf intProdCode = 113 Then  'BUAH REJECT
                Return "003"
            ElseIf intProdCode = 2 Then  'CPO
                Return "004"
            ElseIf intProdCode = 3 Then  'CPKO
                Return "005"
            ElseIf intProdCode = 9 Then   'FIBER
                Return "007"
            ElseIf intProdCode = 111 Then   'KERNEL MEAL
                Return "008"
            ElseIf intProdCode = 4 Or intProdCode = 112 Then   'KERNEL
                Return "006"
            ElseIf intProdCode = 115 Then  'CANGKANG
                Return "010"
            ElseIf intProdCode = 10 Then  'PUPUK
                Return "011"
            ElseIf intProdCode = 114 Then  'COMPOST
                Return "012"
            ElseIf intProdCode = 6 Then  'SOLAR
                Return "013"
            ElseIf intProdCode = 7 Then  'BESI TUA
                Return "014"
            ElseIf intProdCode = 8 Then  'LAIN2
                Return "015"

            Else

                Return "ProdERR1"
            End If
        ElseIf GlobalPPT.strEstateID = "M8" Then
            If strProductCode = "001" Then
                Return "010"
            ElseIf strProductCode = "01" Then
                Return "011"
            ElseIf strProductCode = "02" Then
                Return "011"
            ElseIf strProductCode = "03" Then
                Return "011"
            ElseIf strProductCode = "04" Then
                Return "011"
            ElseIf strProductCode = "05" Then
                Return "011"
            ElseIf strProductCode = "06" Then
                Return "011"
            ElseIf strProductCode = "07" Then
                Return "011"
            ElseIf strProductCode = "08" Then
                Return "011"
            ElseIf strProductCode = "09" Then
                Return "011"
            End If
            If IsNumeric(strProductCode) = False Then
                If strProductCode = "7A" Or strProductCode = "7B" Then 'FFB
                    Return "001"
                ElseIf strProductCode = "JJG" Then
                    Return "003"
                ElseIf strProductCode = "SAMPAH" Then
                    Return "015"
                Else
                    Return "ERRProduct"
                End If
            End If
            Dim intProdCode As Int16
            intProdCode = Val(strProductCode)
            If intProdCode = 7 Then
                Return "001"
            ElseIf intProdCode >= 11 And intProdCode <= 24 Then
                Return "001"
            ElseIf intProdCode = 5 Then
                Return "002"
            ElseIf intProdCode = 2 Then
                Return "004"
            ElseIf intProdCode = 1 Then
                Return "005"
            ElseIf intProdCode = 10 Then
                Return "007"
            ElseIf intProdCode = 3 Then
                Return "006"
            ElseIf intProdCode = 9 Then
                Return "012"
            ElseIf intProdCode = 4 Then
                Return "013"
            ElseIf intProdCode = 6 Then
                Return "014"
            Else
                Return "Err"

            End If
        ElseIf GlobalPPT.strEstateID = "M36" Then
            If IsNumeric(strProductCode) = False Then
                If strProductCode = "001A" Or strProductCode = "001B" Then 'FFB
                    Return "001" 'FFB
                Else
                    Return "ERRProduct"
                End If
            End If

            Dim intProdCode As Int16
            intProdCode = Val(strProductCode)
            If intProdCode = 1 Then  'FFB
                Return "001"
            ElseIf intProdCode = 5 Then  'JAMJANG KOSONG
                Return "002"
            ElseIf intProdCode = 222 Then  'BUAH REJECT
                Return "003"
            ElseIf intProdCode = 2 Then  'CPO
                Return "004"
            ElseIf intProdCode = 3 Then  'CPKO
                Return "005"
            ElseIf intProdCode = 9 Then   'FIBER
                Return "007"
            ElseIf intProdCode = 111 Then   'KERNEL MEAL
                Return "008"
            ElseIf intProdCode = 4 Or intProdCode = 112 Or intProdCode = 113 Then   'KERNEL
                Return "006"
            ElseIf intProdCode = 115 Then  'CANGKANG
                Return "010"
            ElseIf intProdCode = 10 Then  'PUPUK
                Return "011"
            ElseIf intProdCode = 114 Then  'COMPOST
                Return "012"
            ElseIf intProdCode = 6 Then  'SOLAR
                Return "013"
            ElseIf intProdCode = 7 Then  'BESI TUA
                Return "014"
            ElseIf intProdCode = 8 Then  'LAIN2
                Return "015"

            Else

                Return "ProdERR1"
            End If
        End If
        Return "ProdERR2"
    End Function

    Private Function GetCustCode(ByVal strCustCode As String) As String
        ' For NON Numeric Values
        If GlobalPPT.strEstateID = "M8" Then
            If IsNumeric(strCustCode) = False Then
                If strCustCode = "27 CA 08" Then 'Cakra Estate
                    Return "21R3"
                ElseIf strCustCode = "BAR" Then 'PT BARFORMULA
                    Return "22R31"
                ElseIf strCustCode = "C" Then 'PT BARFORMULA
                    Return "22R31"
                ElseIf strCustCode = "CMPS" Then 'PT BARFORMULA
                    Return "22R31"
                ElseIf strCustCode = "CPMC" Then 'PT BARFORMULA
                    Return "22R31"
                ElseIf strCustCode = "LE" Then 'Lestari Estate
                    Return "21R1"
                ElseIf strCustCode = "MAJ" Then 'JANJANGAN KOSONG KE MAJ
                    Return "21R56"
                ElseIf strCustCode = "PD" Then 'Perdana Estate
                    Return "21R6"
                ElseIf strCustCode = "POM" Then 'Perdana Oil Mill (POM)
                    Return "21R57"
                ElseIf strCustCode = "REA" Then 'PT. REA KALTIM PLANTATIONS
                    Return "22R24"
                ElseIf strCustCode = "SN" Then 'Sentekan Estate
                    Return "22R7"
                ElseIf strCustCode = "ST" Then 'Satria Estate
                    Return "21R5"
                ElseIf strCustCode = "SYB" Then 'TEPIAN ESTATE
                    Return "21R8"
                Else
                    Return ""
                End If

            End If

            If strCustCode = "001" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "002" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "003" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "004" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "005" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "006" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "007" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "008" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "009" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "010" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "011" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "012" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "013" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "014" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "015" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "016" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "017" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "018" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "019" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "020" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "021" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "022" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "023" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "024" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "025" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "026" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "027" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "028" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "029" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "030" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "031" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "032" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "033" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "034" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "035" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "036" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "037" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "038" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "039" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "040" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "041" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "042" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "043" Then 'Perdana Estate
                Return "21R6"
            ElseIf strCustCode = "02" Then 'Sentekan Estate
                Return "22R7"
            ElseIf strCustCode = "03" Then 'TEPIAN ESTATE
                Return "21R8"
            ElseIf strCustCode = "06" Then 'Lestari Estate
                Return "21R1"
            ElseIf strCustCode = "07" Then 'Cakra Estate
                Return "21R3"
            ElseIf strCustCode = "08" Then 'Berkat Estate
                Return "21R53"
            ElseIf strCustCode = "09" Then 'Damai Estate
                Return "21R52"
            End If

            Dim intCustCode As Int16
            intCustCode = Val(strCustCode)

            If intCustCode = 1 Then 'FFB Grading Di Kembalikan
                Return "21R58"
            ElseIf intCustCode = 4 Then 'COMPOS LESTARI
                Return "21R54"
            ElseIf intCustCode = 10 Then 'Satria Estate
                Return "21R5"
            ElseIf intCustCode = 51 Then 'Berkat Estate
                Return "21R53"
            ElseIf intCustCode >= 101 And intCustCode <= 149 Then 'Lestari Estate
                Return "21R1"
            ElseIf intCustCode >= 201 And intCustCode <= 258 Then 'Sentekan Estate
                Return "22R7"
            ElseIf intCustCode >= 300 And intCustCode <= 405 Then 'Cakra Estate
                Return "21R3"
            ElseIf intCustCode >= 413 And intCustCode <= 467 Then 'TEPIAN ESTATE
                Return "21R8"
            ElseIf intCustCode = 500 Then 'PT. MANUNGGAL ADI JAYA
                Return "21R33"
            ElseIf intCustCode >= 501 And intCustCode <= 550 Then 'Berkat Estate
                Return "21R53"
            ElseIf intCustCode = 600 Then 'KOP. SENTEKAN PERMAI
                Return "21R30"
            ElseIf intCustCode = 601 Then 'KOP. BINA WARGA SEJAHTERA
                Return "21R11"
            ElseIf intCustCode = 602 Then 'KOP.BINTANG SURYA
                Return "21R34"
            ElseIf intCustCode = 603 Then 'KOP. BANGUN SARI
                Return "21R13"
            ElseIf intCustCode = 604 Then 'KOP. PINANG BERJAYA
                Return "21R35"
            ElseIf intCustCode = 605 Then 'KOP. SUMBER BUMI JAYA
                Return "21R15"
            ElseIf intCustCode = 606 Then 'KOP. BINA WANA SEJAHTERA
                Return "21R16"
            ElseIf intCustCode = 607 Then 'KOP. GOTONG ROYONG Kbg Jgt
                Return "21R17"
            ElseIf intCustCode = 608 Then 'KOP. SERBA USAHA PEKALAI MURIP
                Return "21R18"
            ElseIf intCustCode = 609 Then 'KOP. RIMBA JAYA MULIA SAWIT
                Return "21R19"
            ElseIf intCustCode = 610 Then 'KOP. ETAM SEJAHTERA
                Return "21R20"
            ElseIf intCustCode = 611 Then 'TEPIAN ESTATE
                Return "21R8"
            ElseIf intCustCode = 612 Then 'KOP. PERKEBUNAN DWI KARYA
                Return "21R21"
            ElseIf intCustCode = 613 Then 'KOP. SUMBER MAKMUR PERDANA
                Return "21R22"
            ElseIf intCustCode = 614 Then 'KOP KARYA PENOON
                Return "21R37"
            ElseIf intCustCode = 616 Then 'KOP. SUMBER MAKMUR LOA SAKOH
                Return "21R39"
            ElseIf intCustCode = 617 Then 'KOP. NIRUQ LESTARI
                Return "21R23"
            ElseIf intCustCode = 618 Then 'ERA CIPTA MANDIRI
                Return "21R10"
            ElseIf intCustCode = 619 Then 'Kop. Blayan Sjt, Kbg Jgt
                Return "21R29"
            ElseIf intCustCode = 620 Then 'Kop. Harapan Masa, Kbg Jgt
                Return "21R25"
            ElseIf intCustCode = 621 Then 'PT. TUNAS PRIMA SEJAHTERA
                Return "21R41"
            ElseIf intCustCode = 622 Then 'PLASMA KAHAD BERSATU
                Return "21R42"
            ElseIf intCustCode = 623 Then 'PLASMA ETAM BERSATU
                Return "21R43"
            ElseIf intCustCode = 624 Or intCustCode = 615 Then 'KOP. KARYA MAKMUR
                Return "21R38"
            ElseIf intCustCode = 625 Then 'KOP. MODANG BERSATU
                Return "21R55"
            ElseIf intCustCode = 626 Then 'Plasma Bangun Sari
                Return "21R47"
            ElseIf intCustCode = 627 Then 'PT. Kedap Sayaaq Dua
                Return "21R48"
            ElseIf intCustCode = 628 Then 'Kop. Maju Jaya/Maju Bersama
                Return "21R49"
            ElseIf intCustCode = 629 Then 'Kop. Sari Belayan
                Return "21R50"
            ElseIf intCustCode = 630 Then 'Kop. Benua Etam Jaya
                Return "21R51"
            ElseIf intCustCode >= 711 And intCustCode <= 724 Then 'Damai Estate
                Return "21R52"
            Else
                Return "ERR"
            End If


        ElseIf GlobalPPT.strEstateID = "M36" Then

            If strCustCode = "0011" Then 'Lestari Estate
                Return "22R1"
            ElseIf strCustCode = "001" Then 'Lestari Estate
                Return "22R1 "
            ElseIf strCustCode = "018" Then 'KOP.ERA CIPTA MANDIRI, KBG JGT
                Return "22R10"
            ElseIf strCustCode = "019" Then 'KOP. BANGUN SARI
                Return "22R13"
            ElseIf strCustCode = "055" Then 'KOP.KEBUN PINANG BERJAYA             
                Return "22R14"
            ElseIf strCustCode = "016" Then 'Berkat Estate
                Return "22R2"
            ElseIf strCustCode = "017" Then 'Berkat Estate
                Return "22R2"
            ElseIf strCustCode = "004" Then 'KOP. HARAPAN MASA, KBG JGT
                Return "22R25"
            ElseIf strCustCode = "005" Then 'KOP. KRYA USAHA LSTRI, KBG JGT
                Return "22R26"
            ElseIf strCustCode = "008" Then 'KOP BLAYAN SJT, KBG JGT
                Return "22R29"
            ElseIf strCustCode = "0021" Then 'Cakra Estate
                Return "22R3"
            ElseIf strCustCode = "002" Then 'Cakra Estate
                Return "22R3"
            ElseIf strCustCode = "020" Then 'KOP. SERBA USAHA PEKALAI MURIP
                Return "22R36"
            ElseIf strCustCode = "006" Then 'KOP. KARYA PENOON
                Return "22R37"
            ElseIf strCustCode = "003" Then 'Damai Estate
                Return "22R4"
            ElseIf strCustCode = "054" Then 'PT.TUNAS PRIMA SEJAHTERA (TPS)
                Return "22R41"
            ElseIf strCustCode = "021" Then 'Kop. Karya Makmur
                Return "22R44"
            ElseIf strCustCode = "011" Then 'Satria Estate
                Return "22R5"
            ElseIf strCustCode = "030" Then 'Perdana Estate
                Return "22R6"
            ElseIf strCustCode = "031" Then 'Perdana Estate
                Return "22R6"
            ElseIf strCustCode = "040" Then 'Sentekan Estate
                Return "22R7"
            ElseIf strCustCode = "041" Then 'Sentekan Estate
                Return "22R7"
            ElseIf strCustCode = "050" Then 'Tepian Estate
                Return "22R8"
            ElseIf strCustCode = "333" Then 'POM
                Return "74R51"
            ElseIf strCustCode = "222" Then 'COM
                Return "74R52"
            ElseIf strCustCode = "022" Then 'Plasma Etam Bersatu
                Return "74R53"
            ElseIf strCustCode = "033" Then 'Kop. Sumber Bumi Jaya
                Return "74R54"
            ElseIf strCustCode = "051" Then 'Plasma Kahad Bersatu
                Return "74R55"
            ElseIf strCustCode = "052" Then 'Plasma Sekila Dema
                Return "74R56"
            ElseIf strCustCode = "053" Then 'Plasma Anugerah Sejahtera
                Return "74R57"
            Else
                Return "ERR"
            End If

        ElseIf GlobalPPT.strEstateID = "M9" Then

            If strCustCode = "0011" Then 'Lestari Estate
                Return "22R1"
            ElseIf strCustCode = "001" Then 'Lestari Estate
                Return "22R1 "
            ElseIf strCustCode = "018" Then 'KOP.ERA CIPTA MANDIRI, KBG JGT
                Return "22R10"
            ElseIf strCustCode = "019" Then 'KOP.BINA WARGA SEJAHTERA
                Return "22R11"
            ElseIf strCustCode = "020" Then 'KOP.KARYA USAHA LB SENTEKAN
                Return "22R12"
            ElseIf strCustCode = "021" Then 'KOP.BANGUN SARI
                Return "22R13"
            ElseIf strCustCode = "022" Then 'KOP.KEBUN PINANG BERJAYA             
                Return "22R14"
            ElseIf strCustCode = "023" Then 'KOP.SUMBER BUMI JAYA
                Return "22R15"
            ElseIf strCustCode = "024" Then 'KOP.BINA WANA SEJAHTERA
                Return "22R16"
            ElseIf strCustCode = "025" Then 'KOP.GTNG ROYONG, KBG JGT
                Return "22R17"
            ElseIf strCustCode = "026" Then 'KOP.SERBA USAHA PEKALAI MURIP
                Return "22R18"
            ElseIf strCustCode = "027" Then 'KOP.RIMBA JAYA MULIA SAWIT
                Return "22R19"
            ElseIf strCustCode = "015" Then 'Berkat Estate
                Return "22R2"
            ElseIf strCustCode = "016" Then 'Berkat Estate
                Return "22R2"
            ElseIf strCustCode = "028" Then 'KOP.ETAM SEJAHTERA            
                Return "22R20"
            ElseIf strCustCode = "029" Then 'KOP.PERKEBUNAN DWI KARYA
                Return "22R21"
            ElseIf strCustCode = "030" Then 'KOP.SUMBER MAKMUR PERDANA
                Return "22R22"
            ElseIf strCustCode = "031" Then 'KOP.NIRUQ LESTARI
                Return "22R23"
            ElseIf strCustCode = "R" Then 'PT. REA KALTIM PLANTATIONS
                Return "22R24"
            ElseIf strCustCode = "4" Then 'KOP. HARAPAN MASA, KBG JGT
                Return "22R25"
            ElseIf strCustCode = "5" Then 'KOP. KRYA USAHA LSTRI, KBG JGT
                Return "22R26"
            ElseIf strCustCode = "017" Then 'PT SAWIT SUKSES SEJAHTERA
                Return "22R27"
            ElseIf strCustCode = "006" Then 'KOP. PENOON, KBG JGT
                Return "22R28"
            ElseIf strCustCode = "008" Then 'KOP BLAYAN SJT, KBG JGT
                Return "22R29"
            ElseIf strCustCode = "002" Then 'CAKRA ESTATE
                Return "22R3"
            ElseIf strCustCode = "0021" Then 'CAKRA ESTATE
                Return "22R3"
            ElseIf strCustCode = "012" Then 'KOP.SENTEKAN PERMAI
                Return "22R30"
            ElseIf strCustCode = "035" Then 'PT. Manunggal Adi Jaya
                Return "22R33"
            ElseIf strCustCode = "037" Then 'KOP.KARYA MAKMUR
                Return "22R38"
            ElseIf strCustCode = "013" Then 'KOP.SUMBER MAKMUR LOA SAKOH
                Return "22R39"
            ElseIf strCustCode = "003" Then 'DAMAI ESTATE
                Return "22R4"
            ElseIf strCustCode = "036" Then 'PT. Tunas Prima Sejahtera
                Return "22R41"
            ElseIf strCustCode = "040" Then 'PLASMA KAHAD BERSATU
                Return "22R42"
            ElseIf strCustCode = "034" Then 'PLASMA ETAM BERSATU
                Return "22R43"
            ElseIf strCustCode = "011" Then 'SATRIA ESTATE
                Return "22R5"
            ElseIf strCustCode = "042" Then 'PT KEDAP SAYAAQ DUA
                Return "22R52"
            ElseIf strCustCode = "033" Then 'TEPIAN ESTATE
                Return "22R8"
            ElseIf strCustCode = "039" Then 'SENTEKAN ESTATE
                Return "22R7"
            ElseIf strCustCode = "0391" Then 'SENTEKAN ESTATE
                Return "22R7"
            ElseIf strCustCode = "038" Then 'PERDANA ESTATE   
                Return "22R6"
            ElseIf strCustCode = "0381" Then 'PERDANA ESTATE   
                Return "22R6"
            ElseIf strCustCode = "004" Then 'KOP. MODANG BERSATU, KBG JGT
                Return "22R57"
            ElseIf strCustCode = "005" Then 'KOP. TUNAS HARAPAN, KBG JGT
                Return "22R62"
            ElseIf strCustCode = "041" Then 'PLASMA GUNUNG SARI
                Return "22R63"
            ElseIf strCustCode = "043" Then 'KOP SERBA USAHA TABANG
                Return "22R64"
            ElseIf strCustCode = "044" Then 'SATRIA OIL MILL
                Return "22R65"
            ElseIf strCustCode = "045" Then 'PT.CDM
                Return "22R66"
            ElseIf strCustCode = "046" Then 'KOP.BINTANG SURYA
                Return "22R67"
            ElseIf strCustCode = "B" Then 'BERKAT
                Return "22R68"
            ElseIf strCustCode = "COM" Then 'CAKRA OIL MILL
                Return "22R69"
            ElseIf strCustCode = "R" Then 'REA KALTIM PLANTATIONS
                Return "22R70"
            ElseIf strCustCode = "RB" Then 'KOMPOS BERKAT
                Return "22R71"
            ElseIf strCustCode = "RC" Then 'KOMPOS CAKRA
                Return "22R72"
            ElseIf strCustCode = "RD" Then 'KOMPOS DAMAI
                Return "22R73"
            ElseIf strCustCode = "RL" Then 'KOMPOS LESTARI
                Return "22R74"
            Else
                Return "ERR"
            End If
        End If


        Return "ERR"
    End Function


    Private Function GetNoofTrip(ByVal strVehicleCode As String, ByVal strDate As String) As String
        Dim strNoOfTrip As String = "0"

        Dim dt As New DataTable
        Dim objWBTicketNoPPT As New WBWeighingInOutPPT
        Dim objWBTicketNoBOL As New WBWeighingInOutBOL

        With objWBTicketNoPPT
            .VehicleCode = strVehicleCode
            .WeighingDate = New Date(strDate.Substring(0, 4), strDate.Substring(5, 2), strDate.Substring(8, 2))
        End With

        dt = objWBTicketNoBOL.NoofTrip_Get(objWBTicketNoPPT)
        If dt.Rows.Count > 0 Then
            strNoOfTrip = dt.Rows(0).Item("NoofTrip").ToString()
        End If

        GetNoofTrip = strNoOfTrip
    End Function

    Private Sub UpdText(ByVal ParString As String)
        txtLog.Text += ParString
        txtLog.Text += Chr(13) + Chr(10)
        txtLog.Refresh()
    End Sub

    Private Sub UpdateStatusBar(ByVal StatusBarString As String)
        ts_ProcessingTable.Text = StatusBarString
        ss.Refresh()
    End Sub

    Private Sub llErrorLogFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llErrorLogFilePath.LinkClicked
        System.Diagnostics.Process.Start("notepad", llErrorLogFilePath.Text)
    End Sub

    Private Sub OutsideSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutsideSupplier.CheckedChanged
        txtDeduction.Visible = OutsideSupplier.CheckState
        Label8.Visible = OutsideSupplier.CheckState
        Label9.Visible = OutsideSupplier.CheckState

        If txtDeduction.Visible = True Then
            gbFieldBlockDetails.Visible = False
        Else
            gbFieldBlockDetails.Visible = True
        End If
    End Sub

    Private Sub dgvWeighingInOutIIWeight_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWeighingInOutIIWeight.CellContentClick

    End Sub

    Private Sub chkLooseFruit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLooseFruit.Click
        If dgvFieldBlockSetup.Rows.Count > 0 Then
            If dgvFieldBlockSetup.CurrentRow.Cells("DRLooseFruit").Value = 0 Then
                MessageBox.Show("Please delete all records in the grid", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                chkLooseFruit.Checked = False
            Else
                chkLooseFruit.Checked = True
            End If
        End If

        '    If chkLooseFruit.Checked Then
        '        chkLooseFruit.Checked = False
        '    Else
        '        chkLooseFruit.Checked = True
        '    End If
        'ElseIf chkLooseFruit.Checked Then
        '    'dgvFieldBlockSetup.Columns("DRLooseFruit").Visible = True
        '    'dgvFieldBlockSetup.Columns("gvQuality").Visible = False
        '    txtQtyFFB.Enabled = False
        '    txtLooseFruit.Enabled = True

        '    lblLooseFruit.Visible = True
        '    Label11.Visible = True
        '    txtLooseFruit.Visible = True

        'Else
        '    'dgvFieldBlockSetup.Columns("DRLooseFruit").Visible = False
        '    'dgvFieldBlockSetup.Columns("gvQuality").Visible = True
        '    txtQtyFFB.Enabled = True
        '    txtLooseFruit.Enabled = False

        '    lblLooseFruit.Visible = False
        '    Label11.Visible = False
        '    txtLooseFruit.Visible = False

        'End If

    End Sub

   
    
    Private Sub chkLooseFruit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLooseFruit.CheckedChanged
        If chkLooseFruit.Checked Then
            'lblLooseFruit.Visible = True
            'Label11.Visible = True
            'txtLooseFruit.Visible = True
            'txtLooseFruit.Enabled = True
            txtQtyFFB.Enabled = False
            txtKetek.Enabled = False
        Else
            'lblLooseFruit.Visible = False
            'Label11.Visible = False
            'txtLooseFruit.Visible = False
            'txtLooseFruit.Enabled = False
            txtQtyFFB.Enabled = True
            txtKetek.Enabled = True
        End If
    End Sub
End Class

