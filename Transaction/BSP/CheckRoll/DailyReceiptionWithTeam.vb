'latest

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports System.Windows.Forms.DataGridView

Imports CheckRoll_PPT
Imports Common_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Imports Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation


Public Class DailyReceiptionWithTeam
    Public blNormal As Boolean = True
    Private DailyReceiptionTableAdapter As DailyReceiptionWithTeam_DAL = New DailyReceiptionWithTeam_DAL() ' Senin, 29 Sep 2009, 12:57
    'Private KraniPanenTableAdapter As 
    Private DT_DailyReceiption As System.Data.DataTable = Nothing ' Senin, 29 Sep 2009, 12:49

    ' Private DT_DailyReceiptionWithTeam As System.Data.DataTable = Nothing '28/8/2012

    Dim cmd As SqlCommand
    Private dTotalOT As Decimal = 0
    Private dSumOTHoursGrid As Decimal = 0

    Private rowIndex_dgvDailyReceiption As Integer
    Dim lDeleteCheck As Boolean = False
    Public BlockIDInfo As String = String.Empty
    Private lDelChk As Boolean = False
    ' Selasa, 20 Oct 2009, 17:19
    ' Utk keyboard handling
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False
    Private Deletemodified As Boolean = False
    Private YOPAdd As Boolean = True

    'utk harvested, deducted and paid
    Dim Deducted As Decimal = 0
    Dim Harvested As Decimal = 0
    Dim Paid As Decimal = 0

    'add code by Agung
    '---------------------
    Private DailyDetailPremiAdapter As PremiTargetDAL
    Public DTPremi_Detail As DataTable = New DataTable
    Public Lempid As String = String.Empty

    'Saturday, 25 Oct 2009, 17:20
    Private IsCallingFromDailyAttendanceForm As Boolean = False

    ' Rabu, 24 Mar 2010, 18:29
    ' Tambah Category di parameter
    ' Karena Category dipake diperhitungan MandorPremi dan Krani Premi
    ' yg nilai MandorPremium dan KraniPremium nya diambil dari RateSetup
    Private MandorPremium As Decimal = 0
    Private KraniPremium As Decimal = 0

    Private strPremiHK As Decimal = 0

    Dim DeleteMultientry, DeleteMultientryDailyReception As New ArrayList
    Dim lDelete As Integer
    Dim lReceptionTargetSummaryID As String = String.Empty
    Dim lDailyReceiptionDetID As String = String.Empty
    Dim lDailyReceiptionWithTeamID As String = String.Empty

    Private Sub ApplyLocale(ByVal locale_name As String)

        Dim culture_info As New CultureInfo(locale_name)
        Dim component_resource_manager As New ComponentResourceManager(Me.GetType)

        Thread.CurrentThread.CurrentUICulture = culture_info
        Thread.CurrentThread.CurrentCulture = culture_info


        component_resource_manager.ApplyResources(Me, "$this", culture_info)


        For Each ctl As Control In Me.Controls
            ApplyLocaleToControl(ctl, component_resource_manager, culture_info)
        Next ctl


        Dim resource_manager As New ResourceManager("Localized.Form1", Me.GetType.Assembly)
    End Sub

    Private Sub ApplyLocaleToControl(ByVal ctl As Control, ByVal component_resource_manager As ComponentResourceManager, ByVal culture_info As CultureInfo)

        component_resource_manager.ApplyResources(ctl, ctl.Name, culture_info)


        For Each child As Control In ctl.Controls
            ApplyLocaleToControl(child, component_resource_manager, culture_info)
        Next child

    End Sub


    Private Sub DailyReceiptionWithTeam_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Kamis, 01 Oct 2009, 02:12
        Dim ModifiedRow As DataRow() = DT_DailyReceiption.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_DailyReceiption.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_DailyReceiption.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False
        'Hide because not used in BSP
        'dSumOTHoursGrid = SumOTHoursGrid()

        'If dTotalOT > 0 Then

        '    If dgvDailyReceiption.Rows.Count > 0 Then

        '        If dSumOTHoursGrid < dTotalOT Then
        '            MessageBox.Show("Sum of OT Hour in grid not same with Daily OT" + vbCrLf + _
        '                            "you can not save this data", "Warning", _
        '                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '            Return
        '        End If

        '    End If

        'End If

        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        If Modified Or Deletemodified Then
            If MessageBox.Show("The data has changed," + vbCrLf + _
                            "Do you want to save this data..", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                SaveDailyReceiptionWithTeam()
            End If
        End If

        Me.showDailyAttendance()

    End Sub
    Private Sub showDailyAttendance()
        Try
            Dim DailyAttendanceWithTeamForm As DailyAttendanceWithTeam = New DailyAttendanceWithTeam()
            '  DailyAttendanceWithTeamForm.ShowDialog()
            'DailyAttendanceWithTeamForm.Dock = DockStyle.Fill
            'DailyAttendanceWithTeamForm.Show()

            'Dim childStore As New DailyAttendanceWithTeam()
            'childStore.MdiParent = Me
            'childStore.Dock = DockStyle.Fill
            'childStore.Show()


            ' objMdiForm.ShowDialog()
            ' DailyAttendanceWithTeamForm.Show()


            Dim dtpRDate As DateTime = Me.dtpRDate.Value
            Dim TeamName As String = Me.txtGangName.Text
            Dim EmpID As String = Me.lblEmpID.Text
            Dim NIK As String = Me.txtEmpCode.Text
            Dim EmpName As String = Me.lblEmpName.Text
            Dim AttendanceCode As String = Me.txtAttendanceCode.Text
            Dim AttendanceSetupID As String = Me.lblAttendanceSetupID.Text
            Dim TotalOT As String = Me.txtTotalOT.Text
            Dim DailyReceiptionID As String = Me.lblDailyReceiptionID.Text
            Dim DailyTeamActivityID As String = Me.lblDailyTeamActivityID.Text
            Dim Activity As String = Me.lblActivity.Text
            Dim GangMasterID As String = Me.lblGangMasterID.Text
            Dim MandoreID As String = Me.lblMandoreID.Text
            Dim KraniID As String = Me.lblKraniID.Text
            Dim MandorName As String = Me.lblMandorEmpName.Text
            Dim KraniName As String = Me.lblKraniEmpName.Text
            Dim Category As String = Me.lblEmpCategory.Text
            Dim Location As String = Me.txtLocation.Text

            DailyAttendanceWithTeamForm.Show( _
           dtpRDate, _
           TeamName, _
           EmpID, _
           NIK, _
           EmpName, _
           AttendanceCode, _
           AttendanceSetupID, _
           TotalOT, _
           DailyReceiptionID, _
           DailyTeamActivityID, _
           Activity, _
          GangMasterID, _
          MandoreID, _
          KraniID, _
          MandorName, _
          KraniName, _
          Category, _
         Location, _
         Me.MdiParent)

            DailyAttendanceWithTeamForm.dtpRDate.Enabled = False

            DailyAttendanceWithTeamForm.dgvDailyAttendance.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DailyReceiptionWithTeam_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    End Sub

    'Private Sub DailyReceiptionWithTeam_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Sub DailyReceiptionWithTeam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Senin, 29 Sep 2009, 12:55

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()


        ' bindData()

        ' lblStationID.Text = String.Empty
        lblBlockID.Text = String.Empty
        txtOT.Text = 0
        SuspendLayout()

        DT_DailyReceiption = DailyReceiptionTableAdapter.DailyReceiptionWithTeamSelect(lblDailyReceiptionID.Text)
        'DT_DailyReceiption.Columns("DailyReceiptionDetID").Unique = True
        'DT_DailyReceiption.Columns("DailyReceiptionID").AutoIncrement = True
        'DT_DailyReceiption.Columns("DailyReceiptionDetID").AutoIncrementSeed = 1
        'DT_DailyReceiption.Columns("DailyReceiptionDetID").AutoIncrementStep = 1

        dgvDailyReceiption.DataSource = DT_DailyReceiption
        'dgvDailyReceiption.DataSource = DT_DailyReceiptionWithTeam

        dgvDailyReceiption.Columns("BlockID").Visible = False
        dgvDailyReceiption.Columns("DivID").Visible = False
        dgvDailyReceiption.Columns("YOPID").Visible = False
        'If dgvDailyReceiption.Columns.Contains("DailyReceiptionWithTeamID") Then
        dgvDailyReceiption.Columns("DailyReceiptionWithTeamID").Visible = False
        dgvDailyReceiption.Columns("DailyReceiptionID").Visible = False
        dgvDailyReceiption.Columns("DailyReceiptionDetID").Visible = False
        '   dgvDailyReceiption.Columns("StationID").Visible = False
        dgvDailyReceiption.Columns("DRConcurrencyIDColumn").Visible = False

        dgvDailyReceiption.Columns("IsDrivePremi").Visible = False
        'dgvDailyReceiption.Columns("Id").Visible = False
        dgvDailyReceiption.Columns("EstateID").Visible = False
        dgvDailyReceiption.Columns("EstateCode").Visible = False
        dgvDailyReceiption.Columns("Tonnage").Visible = False
        dgvDailyReceiption.Columns("CreatedOn").Visible = False
        dgvDailyReceiption.Columns("CreatedBy").Visible = False
        dgvDailyReceiption.Columns("ModifiedOn").Visible = False
        dgvDailyReceiption.Columns("ModifiedBy").Visible = False
        dgvDailyReceiption.Columns("Normal").Visible = False

        'dgvDailyReceiption.Columns("PremiHK").Visible = False
        dgvDailyReceiption.Columns("BlkHK").Visible = False

        ' Kamis, 1 Oct 2009, 12:10
        ' base on request CheckrollTransactionDiscusionScreen
        dgvDailyReceiption.Columns("DailyTeamActivityID").Visible = False
        dgvDailyReceiption.Columns("GangName").Visible = False
        'End If


        Dim DT As DataTable
        DT = DailyAttendanceWithTeam_DAL.EstateSelect()
        If (DT.Rows.Count > 0) Then
            Dim TypeEstate As String = ""

            TypeEstate = DT.Rows(0).Item("Type")

            If TypeEstate = "Estate" Then
                ' berarti ini typenya Estate bukan MILL (Perdana Estate atau Cakra Estate)
                txtBlock.Enabled = True
                btnBlockLookup.Enabled = True

                txtStation.Enabled = True
                btnStationLookup.Enabled = True
                GroupBoxEstateInput.Enabled = True

                lblBlock.ForeColor = Color.Red
                lblStation.ForeColor = Color.Black

            ElseIf TypeEstate = "Mill" Then
                ' berarti ini typenya MILL bukan Estate (Cakra Oil Mill)
                txtBlock.Enabled = False
                btnBlockLookup.Enabled = False

                txtStation.Enabled = False
                btnStationLookup.Enabled = False
                GroupBoxEstateInput.Enabled = False

                lblBlock.ForeColor = Color.Black
                lblStation.ForeColor = Color.Red
            End If
        End If

        ResumeLayout()

        '  txtOT.Focus()

        If dgvDailyReceiption.Rows.Count > 0 Then
            btnReceiptionReport.Enabled = True
        Else
            btnReceiptionReport.Enabled = False
        End If

        ' Monday, 19 Oct 2009, 12:50
        Dim DT_AttCode As DataTable
        DT_AttCode = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect(txtAttendanceCode.Text, "")

        If DT_AttCode.Rows.Count > 0 Then
            If DT_AttCode.Rows(0).IsNull("Att Descp") Then
                lblAttendType.Text = ""
            Else
                lblAttendType.Text = DT_AttCode.Rows(0).Item("Att Descp")
            End If

            If txtAttendanceCode.Text = "11" Or txtAttendanceCode.Text = "51" Or txtAttendanceCode.Text = "J1" Then
                strPremiHK = DT_AttCode.Rows(0).Item("TimesBasic")
            Else
                strPremiHK = 0
            End If

        Else
            lblAttendType.Text = ""
            strPremiHK = 0
        End If

        '------------------
        'Add Code by Agung
        '---------------
        ' By Dadang Adi
        'Jum'at, 12 Mar 2010, 02:16
        'The code below is commented by Dadang
        'Dim DTNIKSelect As DataTable = New DataTable
        'DTNIKSelect = CheckRoll_BOL.LookUpBOL.CRDaNikSelectOnTeam(txtEmpCode.Text, "", "N", "Active")
        'If DTNIKSelect.Rows.Count = 1 Then
        '    lblEmpID.Text = DTNIKSelect.Rows(0).Item("Employee ID").ToString()
        'End If


        DailyDetailPremiAdapter = New PremiTargetDAL
        DTPremi_Detail = PremiTargetBOL.TargetDetailView(lblDailyTeamActivityID.Text, lblMandoreID.Text, lblKraniID.Text, "", lblEmpID.Text, dtpRDate.Value)
        DgvTargetDetail.DataSource = DTPremi_Detail

        '-----------------

        If IsCallingFromDailyAttendanceForm = False Then
            ClearDailyAttendanInfo()
        Else
            btnResetAll.Enabled = False
        End If
        dgvDailyReceiption.DefaultCellStyle.BackColor = Color.White

        ' Rabu, 24 Mar 2010, 18:34
        ' Tambah Category di parameter
        ' Karena Category dipake diperhitungan MandorPremi dan Krani Premi
        ' yg nilai MandorPremium dan KraniPremium nya diambil dari RateSetup
        ' DT_RateSetup As DataTable
        'DT_RateSetup = AdvancePayment_DAL.CRRateSetupSelect(lblEmpCategory.Text)

        'Sai revisit

        'If DT_RateSetup.Rows.Count = 0 Then
        '    MessageBox.Show("Rate setup has not yet been setup," + vbCrLf + _
        '                    "Mandor Premi and Krani Premi Value will be wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Else
        '    If DT_RateSetup.Rows(0).IsNull("MandorPremium") Or DT_RateSetup.Rows(0).IsNull("KraniPremium") Then
        '        MessageBox.Show("Rate setup has not yet been setup," + vbCrLf + _
        '                        "Mandor Premi and Krani Premi Value will be wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Else
        '        MandorPremium = DT_RateSetup.Rows(0).Item("MandorPremium")
        '        KraniPremium = DT_RateSetup.Rows(0).Item("KraniPremium")
        '    End If
        'End If
        MandorPremium = 0
        KraniPremium = 0
        txtBlock.Focus()

        'Commented by Andhu - The radio buttons get enabled regardless which attendance code it is
        'rbNormal.Enabled = True
        'rbBorongan.Enabled = True
    End Sub


    Private Sub ClearDailyAttendanInfo()
        ' Saturday, 25 Oct 2009, 17:16
        txtGangName.Text = String.Empty
        lblActivity.Text = String.Empty
        lblDailyTeamActivityID.Text = String.Empty
        lblDailyReceiptionID.Text = String.Empty
        lblGangMasterID.Text = String.Empty
        lblMandoreID.Text = String.Empty
        lblKraniID.Text = String.Empty
        lblMandorEmpName.Text = String.Empty
        lblKraniEmpName.Text = String.Empty

        txtTotalOT.Text = "0"
        txtEmpCode.Text = String.Empty
        lblEmpName.Text = String.Empty

        txtAttendanceCode.Text = String.Empty
        lblAttendanceSetupID.Text = String.Empty
        lblAttendType.Text = String.Empty
    End Sub

    Private Sub btnSearchblock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlockLookup.Click

        ' Senin, 21 Sep 2009, 12:02
        Dim SubBlockLookupForm As VHMasterSubBlockLookup = New VHMasterSubBlockLookup()
        SubBlockLookupForm.cropID = "CropIDOilPalm"
        SubBlockLookupForm.ShowDialog()

        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            'If SubBlockLookupForm.psCropID = SubBlockLookupForm.psCropIDValue Then
            '    Dim DailyRubber As DailyReceptionForRubber = New DailyReceptionForRubber()
            '    DailyRubber.Show(dtpRDate.Value, txtEmpCode.Text, lblEmpName.Text, txtAttendanceCode.Text, txtLocation.Text, txtOT.Text, SubBlockLookupForm.psDIVName, SubBlockLookupForm.psYopName, SubBlockLookupForm.psBlockName, MdiParent)
            'Else
            Me.txtBlock.Text = SubBlockLookupForm.psBlockName
            Me.txtdiv.Text = SubBlockLookupForm.psDIVName
            Me.txtYOP.Text = SubBlockLookupForm.psYopName

            Me.lblBlockID.Text = SubBlockLookupForm.psBlockId
            Me.lblDivID.Text = SubBlockLookupForm.psDIVID
            Me.lblYOPID.Text = SubBlockLookupForm.psYopID
            Me.lblBlockStatus.Text = SubBlockLookupForm.psBlockStatus

            'If rbNormal.Checked = True Then
            '    txtTPHNormal.Focus()
            'Else
            '    txtTPHBorongan.Focus()
            'End If
            loadTPH()
            Dim DT_PremiSetup As DataTable

            DT_PremiSetup = DailyReceiptionWithTeam_DAL.CRPremiSetupSelect(lblBlockID.Text, lblAttendanceSetupID.Text)
            dgPremi.DataSource = DT_PremiSetup

            If DT_PremiSetup.Rows.Count = 0 Then
                MessageBox.Show("Premi Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnAdd.Enabled = False
            Else
                btnAdd.Enabled = True
            End If
            ' Selasa, 20 Oct 2009, 18:18
            'Dapatkan(PremiSpecialRateSetup)
            Dim DT_PremiSpecialRateSetup As DataTable ' ini untuk Borongan
            DT_PremiSpecialRateSetup = DailyReceiptionWithTeam_DAL.CRPremiSpecialRateSetupSelect(lblBlockID.Text)

            If DT_PremiSpecialRateSetup.Rows.Count > 0 Then
                If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerBunch") Then
                    txtRatePerBunch.Text = "0"
                Else
                    txtRatePerBunch.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerBunch").ToString()
                End If

                If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerLooseFruit") Then
                    txtRatePerLooseFruit.Text = "0"
                Else
                    txtRatePerLooseFruit.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerLooseFruit").ToString()
                End If

            Else
                MessageBox.Show("Premi Special Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            'End If
        End If

    End Sub

    'Private Sub btnSearchNIK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim childCR As New NIKLookUp()
    '    childCR.MdiParent = MdiParent
    '    childCR.Dock = DockStyle.Fill
    '    childCR.Show()
    '    txtNIK.Focus()

    'End Sub
    'Private Sub btnvehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    VehicleLookup.Show()
    'End Sub

    'Private Sub btnSearchOtherEstateNIK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    NIKLookUp.Show()
    'End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ApplyLocale("de-De")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ApplyLocale("en-Us")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim lg As String
        'If cmbLanguange.Text = "Indonesia" Then
        '    ApplyLocale("de-De")
        '    lg = cmbLanguange.Text
        'ElseIf cmbLanguange.Text = "English" Then
        '    ApplyLocale("en-Us")
        '    lg = cmbLanguange.Text
        'End If

    End Sub

    Private Sub txtOT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalOT.KeyDown, txtOT.KeyDown
        ' Selasa, 20 Oct 2009, 17:21
        ' By Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

        'If e.KeyCode = Keys.Enter Then
        '    If IsNumeric(txtOT.Text) = False Then
        '        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        '        txtOT.Text = ""
        '        txtOT.Focus()
        '        Return
        '    ElseIf IsNumeric(txtOT.Text) = True Then
        '        txtBlock.Focus()
        '    End If
        'ElseIf e.KeyCode = Keys.Escape Then
        '    txtBlock.Focus()
        'End If
    End Sub

    Private Sub txtLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtblock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBlock.KeyDown
        If e.KeyCode = Keys.Enter Then

            If txtBlock.Text <> "" Then
                Dim DT As DataTable

                DT = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(txtBlock.Text)

                If DT.Rows.Count = 0 Then

                    txtdiv.Text = String.Empty
                    txtYOP.Text = String.Empty
                    lblBlockID.Text = String.Empty
                    lblYOPID.Text = String.Empty
                    lblDivID.Text = String.Empty
                    lblBlockStatus.Text = String.Empty

                    MessageBox.Show("Field No not found.", "Information", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
                    txtBlock.Focus()

                ElseIf DT.Rows.Count >= 1 Then
                    txtBlock.Text = DT.Rows(0).Item("BlockName").ToString()
                    lblBlockID.Text = DT.Rows(0).Item("BlockID").ToString()
                    lblBlockStatus.Text = DT.Rows(0).Item("BlockStatus").ToString()

                    txtdiv.Text = DT.Rows(0).Item("DIVName").ToString()
                    lblDivID.Text = DT.Rows(0).Item("DivID").ToString()

                    txtYOP.Text = DT.Rows(0).Item("YOP").ToString()
                    lblYOPID.Text = DT.Rows(0).Item("YOPID").ToString()



                    Dim DT_PremiSetup As DataTable

                    DT_PremiSetup = DailyReceiptionWithTeam_DAL.CRPremiSetupSelect(lblBlockID.Text, lblAttendanceSetupID.Text)
                    dgPremi.DataSource = DT_PremiSetup

                    If DT_PremiSetup.Rows.Count = 0 Then
                        MessageBox.Show("Premi Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    loadTPH()
                    ' Rabu, 21 Oct 2009, 01:14
                    ' Dapatkan PremiSpecialRateSetup
                    Dim DT_PremiSpecialRateSetup As DataTable ' ini untuk Borongan
                    DT_PremiSpecialRateSetup = DailyReceiptionWithTeam_DAL.CRPremiSpecialRateSetupSelect(lblBlockID.Text)

                    If DT_PremiSpecialRateSetup.Rows.Count > 0 Then
                        If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerBunch") Then
                            txtRatePerBunch.Text = "0"
                        Else
                            txtRatePerBunch.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerBunch").ToString()
                        End If

                        If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerLooseFruit") Then
                            txtRatePerLooseFruit.Text = "0"
                        Else
                            txtRatePerLooseFruit.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerLooseFruit").ToString()
                        End If

                    Else
                        MessageBox.Show("Premi Special Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If
                txtStation.Focus()

            ElseIf txtBlock.Text = "" Then
                ' txtBlock.Focus()
            End If

        End If

    End Sub

    'Private Sub txtStation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStation.KeyDown
    '    If e.KeyCode = Keys.Enter Then

    '        If txtStation.Text <> "" Then
    '            Dim DT As DataTable

    '            DT = DailyAttendanceWithTeam_DAL.CRStationSelect(txtStation.Text)

    '            If DT.Rows.Count = 0 Then

    '                txtStation.Text = String.Empty
    '                lblStationID.Text = String.Empty

    '                MessageBox.Show("Station not found.", "Information", MessageBoxButtons.OK, _
    '                    MessageBoxIcon.Information)
    '                txtStation.Focus()

    '            ElseIf DT.Rows.Count >= 1 Then
    '                txtStation.Text = DT.Rows(0).Item("StationDescp").ToString()
    '                lblStationID.Text = DT.Rows(0).Item("StationID").ToString()

    '                txtTPHNormal.Focus()

    '            End If

    '        ElseIf txtStation.Text = "" Then
    '            ' txtBlock.Focus()
    '        End If

    '    End If

    'End Sub

    Private Sub txtTonnage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' Saturday, 25 Oct 2009, 15:17

        If txtBlock.Text.Trim = String.Empty And txtBlock.Enabled = True Then
            MsgBox("Field No is Required ")
            txtBlock.Focus()
            Exit Sub
            'ElseIf txtFKPSerialNo.Text.Trim = String.Empty Then
            '    MsgBox("FKP Serial Number is Required")
            '    txtFKPSerialNo.Focus()
            '    Exit Sub
        ElseIf rbNormal.Checked And cmbTphNormal.Text = "- Select TPH -" Then
            MsgBox("TPH Number is Required")
            cmbTphNormal.Focus()
            Exit Sub
        ElseIf rbBorongan.Checked And cmbTPHBorongan.Text = "- Select TPH -" Then
            MsgBox("TPH Number is Required")
            cmbTPHBorongan.Focus()
            Exit Sub
        End If

        'If txtStation.Text.Trim = String.Empty And txtStation.Enabled = True Then
        '    MsgBox("Station is Required ")
        '    txtStation.Focus()
        '    Exit Sub
        'End If

        If rbNormal.Checked = True Then
            If (cmbTphNormal.Text.Trim = String.Empty _
                And txtUnripeNormal.Text.Trim = String.Empty _
                And txtUnderRipeNormal.Text.Trim = String.Empty _
                And txtOverRipeNormal.Text.Trim = String.Empty _
                And txtRipeNormal.Text.Trim = String.Empty _
                And txtLooseFruitNormal.Text.Trim = String.Empty _
                And txtNDiscardedCrop.Text.Trim = String.Empty) Then
                MsgBox("Normal values are required ")
                cmbTphNormal.Focus()
                Exit Sub
            Else

                If btnAdd.Text = "&Add" Then
                    DoAdd()
                    'btnAdd.Text = "&Update"

                    lDeleteCheck = False
                ElseIf btnAdd.Text = "&Update" Then

                    rowIndex_dgvDailyReceiption = dgvDailyReceiption.CurrentCell.RowIndex

                    If UpdateDailyReceiptionWithTeam() = True Then

                        btnAdd.Text = "&Add"

                        btnReset.Enabled = False

                        If IsCallingFromDailyAttendanceForm = True Then
                            btnResetAll.Enabled = False
                        Else
                            btnResetAll.Enabled = True
                        End If

                        btnSaveAll.Enabled = True
                        btnClose.Enabled = True

                        dgvDailyReceiption.Enabled = True

                        clearInputText()

                    End If
                    lDeleteCheck = False
                End If
            End If
        End If


        If rbBorongan.Checked = True Then
            If (cmbTPHBorongan.Text.Trim = String.Empty _
                And txtUnripeBorongan.Text.Trim = String.Empty _
                And txtUnderRipeBorongan.Text.Trim = String.Empty _
                And txtOverRipeBorongan.Text.Trim = String.Empty _
                And txtRipeBorongan.Text.Trim = String.Empty _
                And txtLooseFruitBorongan.Text.Trim = String.Empty _
                And txtBDiscardedCrop.Text.Trim = String.Empty) Then
                MsgBox("Borongan values are required ")
                cmbTPHBorongan.Focus()
                Exit Sub
            Else
                If btnAdd.Text = "&Add" Then
                    DoAdd()
                    'btnAdd.Text = "&Update"

                    lDeleteCheck = False
                ElseIf btnAdd.Text = "&Update" Then

                    rowIndex_dgvDailyReceiption = dgvDailyReceiption.CurrentCell.RowIndex

                    If UpdateDailyReceiptionWithTeam() = True Then

                        btnAdd.Text = "&Add"

                        btnReset.Enabled = False

                        If IsCallingFromDailyAttendanceForm = True Then
                            btnResetAll.Enabled = False
                        Else
                            btnResetAll.Enabled = True
                        End If

                        btnSaveAll.Enabled = True
                        btnClose.Enabled = True

                        dgvDailyReceiption.Enabled = True

                        clearInputText()

                    End If
                    lDeleteCheck = False
                End If
            End If
        End If


    End Sub

    Private Sub DoAdd()
        ' Senin, 21 Sep 2009, 13:29
        If txtBlock.Enabled = True Then

            If lblBlockID.Text = String.Empty Then
                MessageBox.Show("You must select the Field No", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        If IsSubBlockAlreadyInGread() <> -1 Then
            'If YOPAdd = False Then
            '    MessageBox.Show("YOP be same as all Sub Block(s) in grid" + vbCrLf + _
            '    "", _
            '    "Information", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Return
            'End If


            MessageBox.Show("Field No Already in grid" + vbCrLf + _
                "example: You can not add the similar Field No", _
                "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim dOTHour As Decimal = 0
        Dim dBalance As Decimal = 0

        If txtOT.Text = "" Then
            txtOT.Text = 0
        End If

        Try
            dOTHour = Convert.ToDecimal(txtOT.Text)
        Catch ex As Exception

        End Try

        dSumOTHoursGrid = SumOTHoursGrid()
        dBalance = dTotalOT - dSumOTHoursGrid


        If dSumOTHoursGrid + dOTHour > dTotalOT Then
            MessageBox.Show("You cannot input OT Hour more than Total OT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtOT.Focus()
            Return
        End If

        'Dim dNTPH As Double = 0
        Dim dNTPH As String = "0"
        Dim dNUnripe As Double = 0
        Dim dNUnderRipe As Double = 0
        Dim dNOverRipe As Double = 0
        Dim dNRipe As Double = 0
        Dim dNLooseFruit As Double = 0
        Dim dNHarvested As Double = 0
        Dim dNDeducted As Double = 0
        Dim dNPaid As Double = 0
        Dim dNDiscarded As Double = 0
        Dim dNDendaLain As Double = 0

        Dim dBTPH As String = "0"
        Dim dBUnripe As Double = 0
        Dim dBUnderRipe As Double = 0
        Dim dBOverRipe As Double = 0
        Dim dBRipe As Double = 0
        Dim dBLooseFruit As Double = 0
        Dim dBHarvested As Double = 0
        Dim dBDeducted As Double = 0
        Dim dBPaid As Double = 0
        Dim dBDiscarded As Double = 0
        Dim dBDendaLain As Double = 0
        Dim dHa As Double = 0

        'dNTPH = Convert.ToDouble(txtTPHNormal.Text)
        If cmbTphNormal.Text <> "- Select TPH -" Then
            dNTPH = cmbTphNormal.Text
        End If
        dNUnripe = Convert.ToDouble(txtUnripeNormal.Text)
        dNUnderRipe = Convert.ToDouble(txtUnderRipeNormal.Text)
        dNOverRipe = Convert.ToDouble(txtOverRipeNormal.Text)
        dNRipe = Convert.ToDouble(txtRipeNormal.Text)
        dNLooseFruit = Convert.ToDouble(txtLooseFruitNormal.Text)
        dNDiscarded = Convert.ToDouble(txtNDiscardedCrop.Text)
        dNHarvested = Convert.ToDouble(txtHarvestedNormal.Text)
        dNDeducted = Convert.ToDouble(txtDeductedNormal.Text)
        dNPaid = Convert.ToDouble(txtPaidNormal.Text)
        dNDendaLain = Convert.ToDecimal(txtNDendaLain.Text)
        If cmbTPHBorongan.Text <> "- Select TPH -" Then
            dBTPH = cmbTPHBorongan.Text
        End If
        dBUnripe = Convert.ToDouble(txtUnripeBorongan.Text)
        dBUnderRipe = Convert.ToDouble(txtUnderRipeBorongan.Text)
        dBOverRipe = Convert.ToDouble(txtOverRipeBorongan.Text)
        dBRipe = Convert.ToDouble(txtRipeBorongan.Text)
        dBLooseFruit = Convert.ToDouble(txtLooseFruitBorongan.Text)
        dBDiscarded = Convert.ToDouble(txtBDiscardedCrop.Text)
        dBHarvested = Convert.ToDouble(txtHarvestedBorongan.Text)
        dBDeducted = Convert.ToDouble(txtDeductedBorongan.Text)
        dBPaid = Convert.ToDouble(txtPaidBorongan.Text)

        dHa = Convert.ToDouble(txtHa.Text)


        If rbNormal.Checked = True Then
            'If (dNUnripe = 0) And (dNUnderRipe = 0) And (dNOverRipe = 0) And (dNRipe = 0) And (dNDeducted = 0) Then
            'MessageBox.Show("Normal values are required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If (dBPaid >= 0) Then
                formulaHarvested(Harvested)
                formulaDeducted(Deducted)
                formulaPaid(Paid)

                Harvested = txtHarvestedNormal.Text
                Deducted = txtDeductedNormal.Text
                Paid = txtPaidNormal.Text

                If (Paid < 0) Then
                    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
                    txtUnripeNormal.Focus()
                    Exit Sub
                Else
                    Paid = txtPaidNormal.Text

                    formulaJanjang()
                    formulabrondolan()

                    'Rabu, 21 Oct 2009, 01:27
                    If rbNormal.Checked = False Then
                        FormulaBorongan()
                    End If

                    AddToGridDailyReceiption()
                    clearInputText()
                End If
            End If

        Else

            'If (dBUnripe = 0) And (dBUnderRipe = 0) And (dBOverRipe = 0) And (dBRipe = 0) And (dBDiscarded = 0) Then 'And (txtAttendanceCode.Text <> "H1")
            'MessageBox.Show("Borongan values are required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If (dBPaid >= 0) Then

                formulaHarvested(Harvested)
                formulaDeducted(Deducted)
                formulaPaid(Paid)

                Harvested = txtHarvestedBorongan.Text
                Deducted = txtDeductedBorongan.Text
                Paid = txtPaidBorongan.Text

                If (Paid < 0) Then
                    MsgBox("Paid value cannot be negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
                    txtUnripeBorongan.Focus()
                    Exit Sub
                Else
                    Paid = txtPaidBorongan.Text

                    formulaJanjang()
                    formulabrondolan()

                    'Rabu, 21 Oct 2009, 01:27
                    If rbNormal.Checked = False Then
                        FormulaBorongan()
                    End If

                    AddToGridDailyReceiption()
                    clearInputText()
                End If
                '    Exit Sub

            End If
            Return
        End If

    End Sub

    Private Function formulaHarvested(ByVal Harvested As Decimal) 'formula utk harvested

        Dim UnRipe As Decimal = 0
        Dim UnderRipe As Decimal = 0
        Dim Ripe As Decimal = 0
        Dim OverRipe As Decimal = 0
        Dim Discarded As Decimal = 0

        'Dim NHarvested As Decimal = 0
        'Dim BHarvested As Decimal = 0

        Try
            If rbNormal.Checked = True Then
                UnRipe = Convert.ToDecimal(txtUnripeNormal.Text)
                UnderRipe = Convert.ToDecimal(txtUnderRipeNormal.Text)
                Ripe = Convert.ToDecimal(txtRipeNormal.Text)
                OverRipe = Convert.ToDecimal(txtOverRipeNormal.Text)
                Discarded = Convert.ToDecimal(txtNDiscardedCrop.Text)

                Harvested = (UnRipe + UnderRipe + Ripe + OverRipe + Discarded)
                txtHarvestedNormal.Text = Harvested
            Else
                UnRipe = Convert.ToDecimal(txtUnripeBorongan.Text)
                UnderRipe = Convert.ToDecimal(txtUnderRipeBorongan.Text)
                Ripe = Convert.ToDecimal(txtRipeBorongan.Text)
                OverRipe = Convert.ToDecimal(txtOverRipeBorongan.Text)
                Discarded = Convert.ToDecimal(txtBDiscardedCrop.Text)

                Harvested = (UnRipe + UnderRipe + Ripe + OverRipe + Discarded)
                txtHarvestedBorongan.Text = Harvested
            End If

        Catch ex As Exception

        End Try
        Return Harvested
    End Function

    Private Function formulaDeducted(ByVal Deducted As Decimal)  'formula Deducted

        Dim UnRipe As Decimal = 0
        Dim UnderRipe As Decimal = 0

        'Dim Deducted As Decimal = 0
        'Dim NDeducted As Decimal = 0

        Try
            If rbNormal.Checked = True Then
                UnRipe = Convert.ToDecimal(txtUnripeNormal.Text)
                UnderRipe = Convert.ToDecimal(txtUnderRipeNormal.Text)

                'Deducted = (UnRipe + (UnRipe * 2) + UnderRipe)
                Deducted = (UnRipe + (UnRipe * 3))
                'Deducted = Deducted + Convert.ToDecimal(txtNDendaLain.Text)
                txtDeductedNormal.Text = Deducted
            Else
                UnRipe = Convert.ToDecimal(txtUnripeBorongan.Text)
                UnderRipe = Convert.ToDecimal(txtUnderRipeBorongan.Text)

                Deducted = (UnRipe + (UnRipe * 3))
                'Deducted = Deducted + Convert.ToDecimal(txtBDendaLain.Text)
                txtDeductedBorongan.Text = Deducted
            End If

        Catch ex As Exception

        End Try

        Return Deducted

        'Dim j As Integer = 0

        If btnAdd.Text = "&Add" Then
            '  AddPremiDetailGrid()
            'j = DT_DailyReceiption.Rows.Count - 1
            'DT_DailyReceiption.Rows(j).Item("GangMasterID") = lblDailyTeamActivityID.Text
            ''END

            '' DTPremi_Detail.Rows(j).Item("TotalBunches") = FormatNumber(Val(txtTPHNormal.Text) + Val(txtTPHBorongan.Text), 2)
            'If rbNormal.Checked = True Then
            '    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtUnderRipeNormal.Text), 2)
            'Else
            '    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtUnderRipeBorongan.Text), 2)
            '    DTPremi_Detail.Rows(j).Item("TotalBorongan") = FormatNumber(Val(txtTPHBorongan.Text), 2)
            '    'DTPremi_Detail.Rows(j).Item("TotalBoronganValue") = FormatNumber(ColectedBunch * RatePerBunch, 2)

            '    'DTPremi_Detail.Rows(j).Item("TLooseFruit1") = ColectedLooseFruit
            '    'DTPremi_Detail.Rows(j).Item("TLooseFruitValue1") = FormatNumber(ColectedLooseFruit * RatePerLooseFruit, 2)

            '    DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
            '    DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
            '    DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text
            'End If
            'FormatNumber(Val(txtNLooseFruits.Text), 2)



            'Else
            '    AddPremiDetailGrid()
            '    j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index
        Else
            ''  j = CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)

            ' j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index
            'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("GangMasterID") = lblDailyTeamActivityID.Text
            'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("MandoreID") = lblMandoreID.Text
            'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("KraniID") = lblKraniID.Text
            '  DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("Activity") = lblActivity.Text
            'DTPremi_Detail.Rows(j).Item("TotalBunches") = FormatNumber(Val(txtTPHNormal.Text) + Val(txtTPHBorongan.Text), 2)

            'If rbNormal.Checked = True Then
            '    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtUnderRipeNormal.Text), 2)
            'Else
            '    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtUnderRipeBorongan.Text), 2)
            '    DTPremi_Detail.Rows(j).Item("TotalBorongan") = FormatNumber(Val(txtTPHBorongan.Text), 2)
            '    'DTPremi_Detail.Rows(j).Item("TotalBoronganValue") = FormatNumber(ColectedBunch * RatePerBunch, 2)

            '    'DTPremi_Detail.Rows(j).Item("TLooseFruit1") = ColectedLooseFruit
            '    'DTPremi_Detail.Rows(j).Item("TLooseFruitValue1") = FormatNumber(ColectedLooseFruit * RatePerLooseFruit, 2)


            '    DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
            '    DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
            '    DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text

        End If


        ' End If
    End Function

    Private Function formulaPaid(ByVal Paid As Decimal)
        Harvested = formulaHarvested(Harvested)
        Deducted = formulaDeducted(Deducted)

        'Dim paid As Decimal = 0
        Try
            Paid = (Harvested - Deducted)
            If rbNormal.Checked = True Then
                txtPaidNormal.Text = Paid - Convert.ToDecimal(txtNDendaLain.Text)
            Else
                txtPaidBorongan.Text = Paid - Convert.ToDecimal(txtBDendaLain.Text)
            End If


        Catch ex As Exception

        End Try
        Return Paid

    End Function

    'formula utk screen lama
    Private Sub FormulaBorongan() 'old version - deducted
        ' Rabu, 21 Oct 2009, 01:22
        Dim FBorongan As Decimal = 0
        Dim RatePerBunch As Decimal = 0
        Dim RatePerLooseFruit As Decimal = 0

        Dim ColectedBunch As Decimal = 0 ' Janjang
        Dim ColectedLooseFruit As Decimal = 0 ' Brondolan

        Try
            ColectedBunch = Convert.ToDecimal(txtHarvestedBorongan.Text)
            ColectedLooseFruit = Convert.ToDecimal(txtLooseFruitBorongan.Text)

            RatePerBunch = Convert.ToDecimal(txtRatePerBunch.Text)
            RatePerLooseFruit = Convert.ToDecimal(txtRatePerLooseFruit.Text)
        Catch ex As Exception

        End Try

        FBorongan = (ColectedBunch * RatePerBunch) + (ColectedLooseFruit * RatePerLooseFruit)
        txtPremiValueBorongan.Text = FBorongan.ToString("#,##0.00")

        Dim j As Integer = 0

        If btnAdd.Text = "&Add" Then
            '  AddPremiDetailGrid()
            j = DTPremi_Detail.Rows.Count - 1
            DTPremi_Detail.Rows(j).Item("GangMasterID") = lblDailyTeamActivityID

            DTPremi_Detail.Rows(j).Item("TotalBunches") = FormatNumber(Val(txtHarvestedNormal.Text) + Val(txtHarvestedBorongan.Text), 2)
            If rbNormal.Checked = True Then
                DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtUnderRipeNormal.Text), 2)
            Else
                DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtLooseFruitNormal.Text), 2)
                DTPremi_Detail.Rows(j).Item("TotalBorongan") = FormatNumber(Val(txtHarvestedBorongan.Text), 2)
                DTPremi_Detail.Rows(j).Item("TotalBoronganValue") = FormatNumber(ColectedBunch * RatePerBunch, 2)

                DTPremi_Detail.Rows(j).Item("TLooseFruit1") = ColectedLooseFruit
                DTPremi_Detail.Rows(j).Item("TLooseFruitValue1") = FormatNumber(ColectedLooseFruit * RatePerLooseFruit, 2)

                DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
                DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
                DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text
            End If
            'FormatNumber(Val(txtNLooseFruits.Text), 2)



            'Else
            '    AddPremiDetailGrid()
            '    j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index
        Else
            j = CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)

            ' j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index
            'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("GangMasterID") = lblDailyTeamActivityID.Text
            'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("MandoreID") = lblMandoreID.Text
            'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("KraniID") = lblKraniID.Text
            '  DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("Activity") = lblActivity.Text

            If DTPremi_Detail.Rows.Count > 0 Then


                DTPremi_Detail.Rows(j).Item("TotalBunches") = FormatNumber(Val(txtHarvestedNormal.Text) + Val(txtHarvestedBorongan.Text), 2)

                If rbNormal.Checked = True Then
                    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtLooseFruitNormal.Text), 2)
                Else
                    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber(Val(txtLooseFruitBorongan.Text), 2)
                    DTPremi_Detail.Rows(j).Item("TotalBorongan") = FormatNumber(Val(txtHarvestedBorongan.Text), 2)
                    DTPremi_Detail.Rows(j).Item("TotalBoronganValue") = FormatNumber(ColectedBunch * RatePerBunch, 2)

                    DTPremi_Detail.Rows(j).Item("TLooseFruit1") = ColectedLooseFruit
                    DTPremi_Detail.Rows(j).Item("TLooseFruitValue1") = FormatNumber(ColectedLooseFruit * RatePerLooseFruit, 2)


                    DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
                    DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
                    DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text

                End If

            End If
        End If

        'End If

        'If DTPremi_Detail.Rows.Count = 0 Then
        '    AddPremiDetailGrid()
        'End If
        'UPDATE DETAIL TARGET PREMI BUNCHES
        '==============================
        ' by Dadang Adi
        ' Kamis, 11 Mar 2010, 14:47
        ' - Field GangMasterID diisi label lblDailyTeamActivityID.Text
        '  diganti jadi diisi dgn lblGangMasterID.Text        
        ' - TotalLooseFruits diambil dari BLoosefruits yg sebelumnya diambil dari NLooseFruits
        'COMMENTED BY NELSON JUN24-2010
        'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("GangMasterID") = lblGangMasterID.Text 'lblDailyTeamActivityID.Text
        'END
        'ADDED BY NELSON JUN24-2010


    End Sub

    Private Function IsSubBlockAlreadyInGread() As Integer
        ' Kamis, 01 oct 2009, 15:44
        Dim rowIndex = -1

        Dim BlockNameInput As String = String.Empty
        Dim StationDescpInput As String = String.Empty
        ' Ahad, 15 Nov 2009, 20:27'
        Dim BlockNameInGrid As String = String.Empty
        Dim StationDescpInGrid As String = String.Empty

        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty
        Dim blNormalInGrid As String = String.Empty

        ''modified by kumar to control validation Of Sub Block

        'Dim JigActualNormInGrid As String = String.Empty
        'Dim JigDibyaarNormInGrid As String = String.Empty
        'Dim BrdNormInGrid As String = String.Empty

        Dim TphNormInGrid As String = String.Empty
        Dim UnripeNormInGrid As String = String.Empty
        Dim UnderRipeNormInGrid As String = String.Empty
        Dim OverRipeNormInGrid As String = String.Empty
        Dim RipeNormInGrid As String = String.Empty
        Dim LooseFruitNormInGrid As String = String.Empty
        Dim DiscardedNormInGrid As String = String.Empty
        Dim HarvestedNormInGrid As String = String.Empty
        Dim DeductedNormInGrid As String = String.Empty
        Dim PaidNormInGrid As String = String.Empty
        Dim DeductedLainNInGrid As String = String.Empty

        'Dim JigActualBoronInGrid As String = String.Empty
        'Dim JigDibyaarBoronInGrid As String = String.Empty
        'Dim BrdBoronInGrid As String = String.Empty

        Dim TphBoronInGrid As String = String.Empty
        Dim UnripeBoronInGrid As String = String.Empty
        Dim UnderRipeBoronInGrid As String = String.Empty
        Dim OverRipeBoronInGrid As String = String.Empty
        Dim RipeBoronInGrid As String = String.Empty
        Dim LooseFruitBoronInGrid As String = String.Empty
        Dim DiscardedBoronInGrid As String = String.Empty
        Dim HarvestedBoronInGrid As String = String.Empty
        Dim DeductedBoronInGrid As String = String.Empty
        Dim PaidBoronInGrid As String = String.Empty
        Dim DeductedLainBInGrid As String = String.Empty

        Dim HainGrid As String = String.Empty

        Dim BorgonNormalcheck As String = String.Empty
        Dim BorgonNormalFromScreen As String = String.Empty

        If txtBlock.Text = "" Then
            Return rowIndex
        End If

        If txtStation.Text = "" Then
            Return rowIndex
        End If

        'BlockNameInput = txtBlock.Text.Substring(txtBlock.Text.Length - 1, 1)
        'BlockNameInput
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)

        Dim dv As DataView = CType(cm.List, DataView)
        ' Dim dv1 As DataView = CType(cm.List, DataView)
        'Dim dr As DataRow = dv.Item(cm.Position).Row

        Dim dta As New DataTable
        ' Dim dtb As New DataTable

        'dta.Columns.Add("Normal")
        'dta.AcceptChanges()
        dta = DT_DailyReceiption
        ' dtb = DT_DailyReceiptionWithTeam

        For i As Int32 = 0 To DT_DailyReceiption.Rows.Count - 1
            Dim row As DataRow = DT_DailyReceiption.Rows(i)

            If row.RowState <> DataRowState.Deleted Then
                '   StationDescpInGrid = row.Item("StationDescp")
                BlockNameInGrid = row.Item("BlockName")
                DivisionInGrid = row.Item("DivName")
                YOPInGrid = row.Item("YOP")
                blNormalInGrid = row.Item("blNormal")

                'JigActualNormInGrid = row.Item("NActualBunches")
                'JigDibyaarNormInGrid = row.Item("NPayedBunches")
                'BrdNormInGrid = row.Item("NLooseFruits")

                'JigActualBoronInGrid = row.Item("BActualBunches")
                'JigDibyaarBoronInGrid = row.Item("BPayedBunches")
                'BrdBoronInGrid = row.Item("BLooseFruits")

                TphNormInGrid = row.Item("TphNormal")
                UnripeNormInGrid = row.Item("UnripeNormal")
                UnderRipeNormInGrid = row.Item("UnderRipeNormal")
                OverRipeNormInGrid = row.Item("OverRipeNormal")
                RipeNormInGrid = row.Item("RipeNormal")
                LooseFruitNormInGrid = row.Item("LooseFruitNormal")
                DiscardedNormInGrid = row.Item("DiscardedNormal")
                HarvestedNormInGrid = row.Item("HarvestedNormal")
                DeductedNormInGrid = row.Item("DeductedNormal")
                PaidNormInGrid = row.Item("PaidNormal")
                DeductedLainNInGrid = row.Item("DeductionLainNormal")


                TphBoronInGrid = row.Item("TphBorongan")
                UnripeBoronInGrid = row.Item("UnripeBorongan")
                UnderRipeBoronInGrid = row.Item("UnderRipeBorongan")
                OverRipeBoronInGrid = row.Item("OverRipeBorongan")
                RipeBoronInGrid = row.Item("RipeBorongan")
                LooseFruitBoronInGrid = row.Item("LooseFruitBorongan")
                DiscardedBoronInGrid = row.Item("DiscardedBorongan")
                HarvestedBoronInGrid = row.Item("HarvestedBorongan")
                DeductedBoronInGrid = row.Item("DeductedBorongan")
                PaidBoronInGrid = row.Item("PaidBorongan")

                DeductedLainBInGrid = row.Item("DeductionLainBorongan")

                HainGrid = row.Item("Ha")

                If rbBorongan.Checked Then
                    blNormal = False
                End If
                If rbNormal.Checked Then
                    blNormal = True
                End If

                'If rbNormal.Checked = True Then
                '    BorgonNormalFromScreen = "Normal"
                'Else
                '    BorgonNormalFromScreen = "Borgon"
                'End If

                'If YOPInGrid.Trim <> txtYOP.Text.Trim Then
                '    rowIndex = i
                '    YOPAdd = False
                '    Exit For
                'Else
                '    YOPAdd = True
                'End If

                'If BlockNameInGrid = txtBlock.Text AndAlso DivisionInGrid = txtdiv.Text AndAlso YOPInGrid = txtYOP.Text And BorgonNormalcheck = BorgonNormalFromScreen Then
                If BlockNameInGrid = txtBlock.Text AndAlso DivisionInGrid = txtdiv.Text AndAlso YOPInGrid = txtYOP.Text And blNormal = blNormalInGrid Then
                    rowIndex = i
                    Exit For
                End If

                If rbBorongan.Checked Then
                End If
            End If
            'BlockNameInGrid = 
        Next
        'For i As Integer = 0 To dgvDailyReceiption.Rows.Count - 1
        '    'BlockNameInGrid = dgvDailyReceiption.Rows(i).Cells("DRBlockNameColumn").Value.ToString()
        '    'BlockNameInGrid = BlockNameInGrid.Substring(BlockNameInGrid.Length - 1, 1)


        '    If BlockNameInGrid = BlockNameInput Then
        '        rowIndex = i
        '        Exit For
        '    End If
        'Next

        Return rowIndex
    End Function

    Private Function IsSubBlockAlreadyInGreadWithOutCurrentEdit() As Integer
        Dim rowIndex = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty

        'Dim StationDescpInGrid As String = String.Empty
        'Dim StationDespInput As String = String.Empty

        ' Ahad, 15 Nov 2009, 20:27
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty


        ''modified by kumar to control validation Of Sub Block

        'Dim JigActualNormInGrid As String = String.Empty
        'Dim JigDibyaarNormInGrid As String = String.Empty
        'Dim BrdNormInGrid As String = String.Empty

        'Dim JigActualBoronInGrid As String = String.Empty
        'Dim JigDibyaarBoronInGrid As String = String.Empty
        'Dim BrdBoronInGrid As String = String.Empty

        Dim TphNormInGrid As String = String.Empty
        Dim UnripeNormInGrid As String = String.Empty
        Dim UnderRipeNormInGrid As String = String.Empty
        Dim OverRipeNormInGrid As String = String.Empty
        Dim RipeNormInGrid As String = String.Empty
        Dim LooseFruitNormInGrid As String = String.Empty
        Dim DiscardedNormInGrid As String = String.Empty
        Dim HarvestedNormInGrid As String = String.Empty
        Dim DeductedNormInGrid As String = String.Empty
        Dim PaidNormInGrid As String = String.Empty
        Dim DeductedLainNInGrid As String = String.Empty

        Dim TphBoronInGrid As String = String.Empty
        Dim UnripeBoronInGrid As String = String.Empty
        Dim UnderRipeBoronInGrid As String = String.Empty
        Dim OverRipeBoronInGrid As String = String.Empty
        Dim RipeBoronInGrid As String = String.Empty
        Dim LooseFruitBoronInGrid As String = String.Empty
        Dim DiscardedBoronInGrid As String = String.Empty
        Dim HarvestedBoronInGrid As String = String.Empty
        Dim DeductedBoronInGrid As String = String.Empty
        Dim PaidBoronInGrid As String = String.Empty
        Dim DeductedLainBInGrid As String = String.Empty

        Dim HaInGrid As String = String.Empty

        Dim BorgonNormalcheck As String = String.Empty
        Dim BorgonNormalFromScreen As String = String.Empty

        If txtBlock.Text = "" Then
            Return rowIndex
        End If

        'If txtStation.Text = "" Then
        '    Return rowIndex
        'End If

        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        For i As Int32 = 0 To DT_DailyReceiption.Rows.Count - 1
            Dim row As DataRow = DT_DailyReceiption.Rows(i)

            '   If i <> dgvDailyReceiption.CurrentCell.RowIndex Then
            If i <> CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row) Then

                If row.RowState <> DataRowState.Deleted Then
                    BlockNameInGrid = row.Item("BlockName")
                    DivisionInGrid = row.Item("DivName")
                    YOPInGrid = row.Item("YOP")

                    ' StationDescpInGrid = row.Item("StationDescp")

                    ''modified by kumar to control validation Of Sub Block

                    'JigActualNormInGrid = row.Item("NActualBunches")
                    'JigDibyaarNormInGrid = row.Item("NPayedBunches")
                    'BrdNormInGrid = row.Item("NLooseFruits")

                    'JigActualBoronInGrid = row.Item("BActualBunches")
                    'JigDibyaarBoronInGrid = row.Item("BPayedBunches")
                    'BrdBoronInGrid = row.Item("BLooseFruits")

                    TphNormInGrid = row.Item("TphNormal")
                    UnripeNormInGrid = row.Item("UnripeNormal")
                    UnderRipeNormInGrid = row.Item("UnderRipeNormal")
                    OverRipeNormInGrid = row.Item("OverRipeNormal")
                    RipeNormInGrid = row.Item("RipeNormal")
                    LooseFruitNormInGrid = row.Item("LooseFruitNormal")
                    DiscardedNormInGrid = row.Item("DiscardedNormal")
                    HarvestedNormInGrid = row.Item("HarvestedNormal")
                    DeductedNormInGrid = row.Item("DeductedNormal")
                    PaidNormInGrid = row.Item("PaidNormal")
                    DeductedLainNInGrid = row.Item("DeductionLainNormal")
                    

                    TphBoronInGrid = row.Item("TphBorongan")
                    UnripeBoronInGrid = row.Item("UnripeBorongan")
                    UnderRipeBoronInGrid = row.Item("UnderRipeBorongan")
                    OverRipeBoronInGrid = row.Item("OverRipeBorongan")
                    RipeBoronInGrid = row.Item("RipeBorongan")
                    LooseFruitBoronInGrid = row.Item("LooseFruitBorongan")
                    DiscardedBoronInGrid = row.Item("DiscardedBorongan")
                    HarvestedBoronInGrid = row.Item("HarvestedBorongan")
                    DeductedBoronInGrid = row.Item("DeductedBorongan")
                    PaidBoronInGrid = row.Item("PaidBorongan")
                    DeductedLainBInGrid = row.Item("DeductionLainBorongan")
                 

                    HaInGrid = row.Item("Ha")
                    'comment by Suhaibah (yg bawah)

                    'If Val(TphBoronInGrid) = 0 And Val(UnripeBoronInGrid) = 0 And Val(UnderRipeBoronInGrid) = 0 
                    'And Val(OverRipeBoronInGrid) = 0 And Val(RipeBoronInGrid) = 0 And Val(LooseFruitBoronInGrid)=0
                    ' Then
                    '    BorgonNormalcheck = "Normal"
                    'Else
                    '    BorgonNormalcheck = "Borgon"
                    'End If

                    If rbNormal.Checked = True Then
                        BorgonNormalFromScreen = "Normal"
                    Else
                        BorgonNormalFromScreen = "Borgon"
                    End If

                    'If YOPInGrid.Trim <> txtYOP.Text.Trim Then
                    '    rowIndex = i
                    '    YOPAdd = False
                    '    Exit For
                    'Else
                    '    YOPAdd = True
                    'End If


                    If BlockNameInGrid = txtBlock.Text AndAlso DivisionInGrid = txtdiv.Text AndAlso YOPInGrid = txtYOP.Text And BorgonNormalcheck = BorgonNormalFromScreen Then
                        rowIndex = i
                        Exit For
                    End If
                End If

            End If
        Next

        Return rowIndex
    End Function

    Private Function SumOTHoursGrid() As Decimal
        ' Senin, 21 Sep 2009, 15:04
        Dim dSum As Decimal = 0

        For Each DR As DataGridViewRow In dgvDailyReceiption.Rows
            dSum = dSum + FormatNumber(Val(DR.Cells.Item("DROTHoursColumn").Value.ToString()), 2)
        Next

        Return dSum
    End Function

    Private Function SumOTHoursGridMinusCurrentEdit() As Decimal
        ' Senin, 21 Sep 2009, 15:04
        Dim dSum As Decimal = 0

        Dim i As Integer

        For i = 0 To dgvDailyReceiption.Rows.Count - 1
            If i <> rowIndex_dgvDailyReceiption Then
                dSum = dSum + FormatNumber(Val(dgvDailyReceiption.Rows(i).Cells("DROTHoursColumn").Value.ToString()), 2)
            End If
        Next

        Return dSum
    End Function

    Private Sub AddToGridDailyReceiption()
        ' Senin, 21 Sep 2009, 12:45
        Dim NewRow As System.Data.DataRow
        NewRow = DT_DailyReceiption.NewRow()

        'Dim DT_DailyReceiptionWithTeam
        'Dim NewRow As New DataTable
        'NewRow = DT_DailyReceiptionWithTeam.

        'NewRow = DTDailyReceiptionWithTeam_Detail.NewRow()
        'If DT_DailyReceiption.Columns.Contains("DailyReceiptionWithTeamID") Then
        'NewRow.Item("DailyReceiptionWithTeamID") = lDailyReceiptionWithTeamID
        NewRow.Item("DailyReceiptionDetID") = lDailyReceiptionDetID
        NewRow.Item("ConcurrencyId") = 0


        NewRow.Item("DailyReceiptionID") = lblDailyReceiptionID.Text
        NewRow.Item("EstateID") = Global.Common_PPT.GlobalPPT.strEstateID
        NewRow.Item("EstateCode") = Global.Common_PPT.GlobalPPT.strEstateCode
        ' Saturday, 25 oct 2009, 18:04
        NewRow.Item("EmpCode") = txtEmpCode.Text
        NewRow.Item("EmpName") = lblEmpName.Text
        NewRow.Item("OTHours") = txtOT.Text
        NewRow.Item("blNormal") = blNormal.ToString()

        NewRow.Item("FKPSerialNo") = txtFKPSerialNo.Text
        'End If


        If txtBlock.Enabled = True And lblBlockID.Text <> "" Then
            NewRow.Item("BlockName") = txtBlock.Text
            NewRow.Item("BlockID") = lblBlockID.Text
        Else
            NewRow.Item("BlockID") = System.DBNull.Value
        End If

        'If txtStation.Enabled = True And lblStationID.Text <> "" Then
        '    NewRow.Item("StationDescp") = txtStation.Text
        '    NewRow.Item("StationID") = lblStationID.Text
        'Else
        '    NewRow.Item("StationID") = System.DBNull.Value
        'End If

        If txtBlock.Enabled = True And lblBlockID.Text <> "" Then
            NewRow.Item("BlockName") = txtBlock.Text
            '  NewRow.Item("StationDescp") = txtStation.Text
            NewRow.Item("DivName") = txtdiv.Text
            NewRow.Item("YOP") = txtYOP.Text

            NewRow.Item("DivID") = lblDivID.Text
            NewRow.Item("YOPID") = lblYOPID.Text
            NewRow.Item("BlockID") = lblBlockID.Text
            ' NewRow.Item("StationID") = lblStationID.Text


            Dim tphNormal As String = "0"
            If cmbTphNormal.Text.ToString() <> "- Select TPH -" Then
                tphNormal = cmbTphNormal.Text.ToString()
            End If

            NewRow.Item("TphNormal") = tphNormal
            NewRow.Item("UnripeNormal") = txtUnripeNormal.Text
            NewRow.Item("UnderRipeNormal") = txtUnderRipeNormal.Text
            NewRow.Item("OverRipeNormal") = txtOverRipeNormal.Text
            NewRow.Item("RipeNormal") = txtRipeNormal.Text
            NewRow.Item("LooseFruitNormal") = txtLooseFruitNormal.Text
            NewRow.Item("DiscardedNormal") = txtNDiscardedCrop.Text
            NewRow.Item("HarvestedNormal") = txtHarvestedNormal.Text
            NewRow.Item("DeductedNormal") = txtDeductedNormal.Text
            NewRow.Item("PaidNormal") = txtPaidNormal.Text


            Dim tphBorongan As String = "0"
            If cmbTPHBorongan.Text.ToString() <> "- Select TPH -" Then
                tphBorongan = cmbTPHBorongan.Text.ToString()
            End If
            NewRow.Item("TphBorongan") = tphBorongan
            NewRow.Item("UnripeBorongan") = txtUnripeBorongan.Text
            NewRow.Item("UnderRipeBorongan") = txtUnderRipeBorongan.Text
            NewRow.Item("OverRipeBorongan") = txtOverRipeBorongan.Text
            NewRow.Item("RipeBorongan") = txtRipeBorongan.Text
            NewRow.Item("LooseFruitBorongan") = txtLooseFruitBorongan.Text
            NewRow.Item("DiscardedBorongan") = txtBDiscardedCrop.Text
            NewRow.Item("HarvestedBorongan") = txtHarvestedBorongan.Text
            NewRow.Item("DeductedBorongan") = txtDeductedBorongan.Text
            NewRow.Item("PaidBorongan") = txtPaidBorongan.Text

            NewRow.Item("Ha") = txtHa.Text

            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
            ' Rabu, 21 Oct 2009, 01:30
            ' PremiValue utk Normal dan Borongan berbeda
            ' Normal diambil dari PremiRateSetup
            ' Borongan diambil dari PremiSpecialRateSetup
            If rbNormal.Checked = True Then
                NewRow.Item("PremiValue") = FormatNumber(txtPremiValueNormal.Text, 2)
            Else
                NewRow.Item("PremiValue") = FormatNumber(txtPremiValueBorongan.Text, 2)
            End If

        End If

        NewRow.Item("PremiHK") = strPremiHK
        NewRow.Item("BlkHK") = 0

        NewRow.Item("CreatedBy") = GlobalPPT.strUserName
        NewRow.Item("CreatedOn") = Now
        NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
        NewRow.Item("ModifiedOn") = Now

        NewRow.Item("DeductionLainNormal") = Me.txtNDendaLain.Text
        NewRow.Item("DeductionLainBorongan") = Me.txtBDendaLain.Text
        'End If

        DT_DailyReceiption.Rows.Add(NewRow)
        ' DT_DailyReceiptionWithTeam.Rows.Add(NewRow)
        'MessageBox.Show(NewRow.RowState.GetNames(NewRow.RowState)
    End Sub

    Private Sub rbBorongan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBorongan.CheckedChanged
        ' Sabtu, 19 Sep 2009, 14:37
        If rbBorongan.Checked Then
            'txtTPHBorongan.Enabled = True
            cmbTPHBorongan.Enabled = True
            txtUnripeBorongan.Enabled = True
            txtUnderRipeBorongan.Enabled = True
            txtOverRipeBorongan.Enabled = True
            txtRipeBorongan.Enabled = True
            txtBDiscardedCrop.Enabled = True
            txtLooseFruitBorongan.Enabled = True
            txtHarvestedBorongan.Enabled = True
            txtDeductedBorongan.Enabled = True
            txtPaidBorongan.Enabled = True
            txtBDendaLain.Enabled = True

            'txtTPHNormal.Enabled = False
            cmbTphNormal.SelectedIndex = 0
            cmbTphNormal.Enabled = False
            txtUnripeNormal.Enabled = False
            txtUnderRipeNormal.Enabled = False
            txtOverRipeNormal.Enabled = False
            txtRipeNormal.Enabled = False
            txtNDiscardedCrop.Enabled = False
            txtLooseFruitNormal.Enabled = False
            txtHarvestedNormal.Enabled = False
            txtDeductedNormal.Enabled = False
            txtPaidNormal.Enabled = False
            txtNDendaLain.Enabled = False
        Else
            'txtTPHNormal.Enabled = True
            cmbTphNormal.Enabled = True
            txtUnripeNormal.Enabled = True
            txtUnderRipeNormal.Enabled = True
            txtOverRipeNormal.Enabled = True
            txtRipeNormal.Enabled = True
            txtLooseFruitNormal.Enabled = True
            txtNDiscardedCrop.Enabled = True
            txtHarvestedNormal.Enabled = True
            txtDeductedNormal.Enabled = True
            txtPaidNormal.Enabled = True
            txtNDendaLain.Enabled = True

            'txtTPHBorongan.Enabled = False
            cmbTPHBorongan.SelectedIndex = 0
            cmbTPHBorongan.Enabled = False
            txtUnripeBorongan.Enabled = False
            txtUnderRipeBorongan.Enabled = False
            txtOverRipeBorongan.Enabled = False
            txtRipeBorongan.Enabled = False
            txtLooseFruitBorongan.Enabled = False
            txtBDiscardedCrop.Enabled = False
            txtHarvestedBorongan.Enabled = False
            txtDeductedBorongan.Enabled = False
            txtPaidBorongan.Enabled = False
            txtBDendaLain.Enabled = False
        End If
        clearJjgInput()
        loadTPH()
    End Sub

    Private Sub rbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
        ' Sabtu, 19 Sep 2009, 14:38

        If rbNormal.Checked Then
            'txtTPHNormal.Enabled = True
            cmbTphNormal.Enabled = True
            txtUnripeNormal.Enabled = True
            txtUnderRipeNormal.Enabled = True
            txtOverRipeNormal.Enabled = True
            txtRipeNormal.Enabled = True
            txtLooseFruitNormal.Enabled = True
            txtNDiscardedCrop.Enabled = True
            txtHarvestedNormal.Enabled = True
            txtDeductedNormal.Enabled = True
            txtPaidNormal.Enabled = True
            txtNDendaLain.Enabled = True

            'txtTPHBorongan.Enabled = False
            cmbTPHBorongan.Enabled = False
            txtUnripeBorongan.Enabled = False
            txtUnderRipeBorongan.Enabled = False
            txtOverRipeBorongan.Enabled = False
            txtRipeBorongan.Enabled = False
            txtLooseFruitBorongan.Enabled = False
            txtBDiscardedCrop.Enabled = False
            txtHarvestedBorongan.Enabled = False
            txtDeductedBorongan.Enabled = False
            txtPaidBorongan.Enabled = False
            txtBDendaLain.Enabled = False
        Else
            'txtTPHBorongan.Enabled = True
            cmbTPHBorongan.Enabled = True
            txtUnripeBorongan.Enabled = True
            txtUnderRipeBorongan.Enabled = True
            txtOverRipeBorongan.Enabled = True
            txtRipeBorongan.Enabled = True
            txtLooseFruitBorongan.Enabled = True
            txtBDiscardedCrop.Enabled = True
            txtHarvestedBorongan.Enabled = True
            txtDeductedBorongan.Enabled = True
            txtPaidBorongan.Enabled = True
            txtBDendaLain.Enabled = True
            'txtTPHNormal.Enabled = False
            cmbTphNormal.Enabled = False
            txtUnripeNormal.Enabled = False
            txtUnderRipeNormal.Enabled = False
            txtOverRipeNormal.Enabled = False
            txtRipeNormal.Enabled = False
            txtLooseFruitNormal.Enabled = False
            txtNDiscardedCrop.Enabled = False
            txtHarvestedNormal.Enabled = False
            txtDeductedNormal.Enabled = False
            txtPaidNormal.Enabled = False
            txtNDendaLain.Enabled = False
        End If
        clearJjgInput()
        loadTPH()
    End Sub

    Private Sub clearJjgInput()
        ' Sabtu, 19 Sep 2009, 14:43
        'txtTPHNormal.Text = "0"
        If txtBlock.Text.Length = 0 Then
            cmbTphNormal.DataSource = Nothing
            cmbTphNormal.Items.Clear()
            cmbTphNormal.Items.Insert(0, "- Select TPH -")
            cmbTphNormal.SelectedIndex = 0
        End If

        txtUnripeNormal.Text = "0"
        txtUnderRipeNormal.Text = "0"
        txtOverRipeNormal.Text = "0"
        txtRipeNormal.Text = "0"
        txtLooseFruitNormal.Text = "0"
        txtNDiscardedCrop.Text = "0"
        txtHarvestedNormal.Text = "0"
        txtDeductedNormal.Text = "0"
        txtPaidNormal.Text = "0"
        txtNDendaLain.Text = "0"
        'txtTPHBorongan.Text = "0"
        If txtBlock.Text.Length = 0 Then
            cmbTPHBorongan.DataSource = Nothing
            cmbTPHBorongan.Items.Clear()
            cmbTPHBorongan.Items.Insert(0, "- Select TPH -")
            cmbTPHBorongan.SelectedIndex = 0
        End If
        txtUnripeBorongan.Text = "0"
        txtUnderRipeBorongan.Text = "0"
        txtOverRipeBorongan.Text = "0"
        txtRipeBorongan.Text = "0"
        txtLooseFruitBorongan.Text = "0"
        txtBDiscardedCrop.Text = "0"
        txtHarvestedBorongan.Text = "0"
        txtDeductedBorongan.Text = "0"
        txtPaidBorongan.Text = "0"
        txtBDendaLain.Text = "0"
        txtHa.Text = "0"

    End Sub

    Public Overloads Sub ShowDialog(ByVal RDate As Date, _
                                    ByVal TeamName As String, _
                                    ByVal Nik As String, _
                                    ByVal EmpName As String, _
                                    ByVal AttendanceCode As String, _
                                    ByVal AttendanceSetupID As String, _
                                    ByVal TotalOT As String, _
                                    ByVal DailyReceiptionID As String, _
                                    ByVal DailyTeamActivityID As String, _
                                    ByVal GangMasterID As String, _
                                    ByVal MandoreID As String, _
                                    ByVal KraniID As String, _
                                    ByVal Location As String, _
                                    ByVal parent As IWin32Window)
        ' Senin, 21 Sep 2009, 11:56
        Me.dtpRDate.Value = RDate
        Me.txtGangName.Text = TeamName
        Me.txtEmpCode.Text = Nik
        Me.lblEmpName.Text = EmpName
        Me.txtAttendanceCode.Text = AttendanceCode
        Me.lblAttendanceSetupID.Text = AttendanceSetupID
        Me.lblAttendType.Text = ""
        Me.txtTotalOT.Text = TotalOT
        Me.lblDailyReceiptionID.Text = DailyReceiptionID
        ' Selasa, 20 Oct 2009, 23:35
        Me.lblDailyTeamActivityID.Text = DailyTeamActivityID
        Me.lblGangMasterID.Text = GangMasterID
        Me.lblMandoreID.Text = MandoreID
        Me.lblKraniID.Text = KraniID
        Me.txtLocation.Text = Location

        If TotalOT = "" Then
            TotalOT = "0"
        End If
        dTotalOT = FormatNumber(Val(TotalOT), 2)

        Me.ShowDialog(parent)
    End Sub

    Public Overloads Sub Show(ByVal RDate As Date, _
                                    ByVal TeamName As String, _
                                    ByVal EmpID As String, _
                                    ByVal Nik As String, _
                                    ByVal EmpName As String, _
                                    ByVal AttendanceCode As String, _
                                    ByVal AttendanceSetupID As String, _
                                    ByVal TotalOT As String, _
                                    ByVal DailyReceiptionID As String, _
                                    ByVal DailyTeamActivityID As String, _
                                    ByVal Activity As String, _
                                    ByVal GangMasterID As String, _
                                    ByVal MandoreID As String, _
                                    ByVal KraniID As String, _
                                    ByVal MandorName As String, _
                                    ByVal KraniName As String, _
                                    ByVal Category As String, _
                                    ByVal Location As String, _
                                    ByVal OldNIK As String, _
                                    ByVal parent As IWin32Window)

        ' Rabu, 24 Mar 2010, 18:29
        ' Tambah Category di parameter
        ' Karena Category dipake diperhitungan MandorPremium dan KraniPremium

        ' Saturday, 25 Oct 2009, 15:59

        ' Senin, 21 Sep 2009, 11:56
        Me.dtpRDate.Value = RDate
        Me.txtGangName.Text = TeamName
        ' Jum'at, 12 Mar 2010, 02:08
        ' tambah EmpID
        lblOldNIK.Text = OldNIK
        Me.lblEmpID.Text = EmpID
        Me.txtEmpCode.Text = Nik
        Me.lblEmpName.Text = EmpName
        Me.txtAttendanceCode.Text = AttendanceCode
        Me.lblAttendanceSetupID.Text = AttendanceSetupID
        Me.lblAttendType.Text = ""
        Me.txtTotalOT.Text = TotalOT
        Me.lblDailyReceiptionID.Text = DailyReceiptionID
        ' Selasa, 20 Oct 2009, 23:35
        Me.lblDailyTeamActivityID.Text = DailyTeamActivityID
        Me.lblActivity.Text = Activity
        Me.lblGangMasterID.Text = GangMasterID
        Me.lblMandoreID.Text = MandoreID
        Me.lblKraniID.Text = KraniID
        Me.lblMandorEmpName.Text = MandorName
        Me.lblKraniEmpName.Text = KraniName
        Me.lblEmpCategory.Text = Category
        Me.txtLocation.Text = Location

        If TotalOT = "" Then
            TotalOT = "0"
        End If
        dTotalOT = FormatNumber(Val(TotalOT), 2)

        IsCallingFromDailyAttendanceForm = True

        txtGangName.Enabled = False
        btnTeamLookup.Enabled = False
        txtEmpCode.Enabled = False
        btnNikLookup.Enabled = False
        btnReset.Enabled = False

        'Andhu 3/3/2013 - Code modified to provide both options to enter data for both Normal and borongan
        If txtAttendanceCode.Text = "M1" Or txtAttendanceCode.Text = "L1" Then
            rbNormal.Enabled = True
            rbNormal.Checked = True
            rbBorongan.Checked = False
            rbBorongan.Enabled = True

            'ElseIf txtAttendanceCode.Text = "H1" Then
            '    rbBorongan.Checked = True
            '    rbBorongan.Enabled = True
            '    rbNormal.Checked = False
            '    rbNormal.Enabled = False

        End If



        'Commented by nelson jun21-2010
        '-----
        '' Selasa, 02 Feb 2010, 15:05
        '' AttendanceCode = 11 (HADIR) tidak bisa pilih borongan
        ''
        'If Me.txtAttendanceCode.Text = "11" Then
        '    rbBorongan.Enabled = False
        'End If
        '' END Selasa, 02 Feb 2010, 15:05

        Me.MdiParent = parent
        Me.Dock = DockStyle.Fill
        Me.Show()
        txtBlock.Focus()
    End Sub

    Private Sub EditDailyReceiptionWithTeam()
        ' Senin, 21 Sep 2009, 15:24
        ' Selasa, 20 Oct 2009
        ' Get the Currency Manager by using the BindingContext of the DataGrid
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        'txtOT.Text = dgvDailyReceiption.Rows(rowIndex_dgvDailyReceiption).Cells("DROTHoursColumn").Value

        txtOT.Text = CType(dr.Item("OTHours"), Double).ToString()

        If txtBlock.Enabled = True Then

            If dr.Item("BlockID") IsNot System.DBNull.Value Then
                '   lblStationID.Text = dr.Item("StationID").ToString()
                lblBlockID.Text = dr.Item("BlockID").ToString()
                lblDivID.Text = dr.Item("DivID").ToString()
                lblYOPID.Text = dr.Item("YOPID").ToString()

                '  txtStation.Text = dr.Item("StationDescp").ToString()
                txtBlock.Text = dr.Item("BlockName").ToString()
                txtdiv.Text = dr.Item("DivName").ToString()
                txtYOP.Text = dr.Item("YOP").ToString()
            End If


            'If (dr.Item("TphNormal") <> "0" AndAlso dr.Item("UnripeNormal") <> 0 AndAlso dr.Item("UnderRipeNormal") <> 0 AndAlso dr.Item("OverRipeNormal") <> 0 AndAlso dr.Item("RipeNormal") <> 0) AndAlso dr.Item("LooseFruitNormal") <> 0 AndAlso dr.Item("DiscardedNormal") <> 0 Then
            If (dr.Item("TphNormal") <> "0") Then
                rbNormal.Checked = True
                rbNormal.Enabled = True
                rbBorongan.Enabled = False
            ElseIf (dr.Item("TphBorongan") <> "0") Then
                rbBorongan.Checked = True
                rbBorongan.Enabled = True
                rbNormal.Enabled = False
            End If

            If dr.Item("TphNormal") <> "0" Then
                'txtTPHNormal.Text = dr.Item("TphNormal").ToString() 'CType(dr.Item("TphNormal"), Double).ToString()
                loadTPH()

                cmbTphNormal.Text = dr.Item("TphNormal").ToString()
            End If

            If dr.Item("UnripeNormal") <> 0 Then
                txtUnripeNormal.Text = CType(dr.Item("UnripeNormal"), Double).ToString()
            End If


            If dr.Item("UnderRipeNormal") <> 0 Then
                txtUnderRipeNormal.Text = CType(dr.Item("UnderRipeNormal"), Double).ToString()
            End If

            If dr.Item("OverRipeNormal") <> 0 Then
                txtOverRipeNormal.Text = CType(dr.Item("OverRipeNormal"), Double).ToString()
            End If

            If dr.Item("RipeNormal") <> 0 Then
                txtRipeNormal.Text = CType(dr.Item("RipeNormal"), Double).ToString()
            End If

            If dr.Item("LooseFruitNormal") <> 0 Then
                txtLooseFruitNormal.Text = CType(dr.Item("LooseFruitNormal"), Double).ToString()
            End If

            If dr.Item("DiscardedNormal") <> 0 Then
                txtNDiscardedCrop.Text = CType(dr.Item("DiscardedNormal"), Double).ToString()
            End If

            If dr.Item("HarvestedNormal") <> 0 Then
                txtHarvestedNormal.Text = CType(dr.Item("HarvestedNormal"), Double).ToString()
            End If

            If dr.Item("DeductedNormal") <> 0 Then
                txtDeductedNormal.Text = CType(dr.Item("DeductedNormal"), Double).ToString()
            End If

            If dr.Item("PaidNormal") <> 0 Then
                txtPaidNormal.Text = CType(dr.Item("PaidNormal"), Double).ToString()

            End If


            If dr.Item("TphBorongan") <> "0" Then
                'txtTPHBorongan.Text = dr.Item("TphBorongan").ToString() '(dr.Item("TphBorongan"), Double).ToString()
                loadTPH()
                cmbTPHBorongan.Text = dr.Item("TphBorongan").ToString()
            End If


            If dr.Item("UnripeBorongan") <> 0 Then
                txtUnripeBorongan.Text = CType(dr.Item("UnripeBorongan"), Double).ToString()
            End If


            If dr.Item("UnderRipeBorongan") <> 0 Then
                txtUnderRipeBorongan.Text = CType(dr.Item("UnderRipeBorongan"), Double).ToString()
            End If

            If dr.Item("OverRipeBorongan") <> 0 Then
                txtOverRipeBorongan.Text = CType(dr.Item("OverRipeBorongan"), Double).ToString()
            End If

            If dr.Item("RipeBorongan") <> 0 Then
                txtRipeBorongan.Text = CType(dr.Item("RipeBorongan"), Double).ToString()
            End If

            If dr.Item("LooseFruitBorongan") <> 0 Then
                txtLooseFruitBorongan.Text = CType(dr.Item("LooseFruitBorongan"), Double).ToString()
            End If

            If dr.Item("DiscardedBorongan") <> 0 Then
                txtBDiscardedCrop.Text = CType(dr.Item("DiscardedBorongan"), Double).ToString()
            End If

            If dr.Item("HarvestedBorongan") <> 0 Then
                txtHarvestedBorongan.Text = CType(dr.Item("HarvestedBorongan"), Double).ToString()
            End If

            If dr.Item("DeductedBorongan") <> 0 Then
                txtDeductedBorongan.Text = CType(dr.Item("DeductedBorongan"), Double).ToString()
            End If

            If dr.Item("PaidBorongan") <> 0 Then
                txtPaidBorongan.Text = CType(dr.Item("PaidBorongan"), Double).ToString()
            End If

            If dr.Item("Ha") <> 0 Then
                txtHa.Text = CType(dr.Item("Ha"), Double).ToString()
            End If
            If dr.Item("DeductionLainNormal") <> 0 Then
                Me.txtNDendaLain.Text = CType(dr.Item("DeductionLainNormal"), Double).ToString()

            End If
            If dr.Item("DeductionLainBorongan") <> 0 Then
                Me.txtBDendaLain.Text = CType(dr.Item("DeductionLainBorongan"), Double).ToString()

            End If

            'txtFKPSerialNo.Text = dr.Item("FKPSerialNo").ToString()

        End If

        Dim DT_PremiSetup As DataTable
        DT_PremiSetup = DailyReceiptionWithTeam_DAL.CRPremiSetupSelect(lblBlockID.Text, lblAttendanceSetupID.Text)
        dgPremi.DataSource = DT_PremiSetup

        If DT_PremiSetup.Rows.Count = 0 Then
            MessageBox.Show("Premi Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        ' Selasa, 20 Oct 2009, 18:18
        ' Dapatkan PremiSpecialRateSetup
        Dim DT_PremiSpecialRateSetup As DataTable ' ini untuk Borongan
        DT_PremiSpecialRateSetup = DailyReceiptionWithTeam_DAL.CRPremiSpecialRateSetupSelect(lblBlockID.Text)

        If DT_PremiSpecialRateSetup.Rows.Count > 0 Then
            If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerBunch") Then
                txtRatePerBunch.Text = "0"
            Else
                txtRatePerBunch.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerBunch").ToString()
            End If

            If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerLooseFruit") Then
                txtRatePerLooseFruit.Text = "0"
            Else
                txtRatePerLooseFruit.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerLooseFruit").ToString()
            End If

        Else
            MessageBox.Show("Premi Special Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub



    Private Function UpdateDailyReceiptionWithTeam() As Boolean
        ' Senin, 21 Sep 2009, 15:25
        Dim dOTHour As Decimal = 0
        Dim dSumOTWithoutCurrentEdit As Decimal = 0

        ' Ahad, 15 Nov 2009, 20:44
        If IsSubBlockAlreadyInGreadWithOutCurrentEdit() <> -1 Then
            'If YOPAdd = False Then
            '    MessageBox.Show("YOP be same as all Sub Block(s) in grid" + vbCrLf + _
            '    "", _
            '    "Information", _
            '                MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Return False
            'End If

            MessageBox.Show("Sub Block Already in grid" + vbCrLf + _
                "example: You can not add the similar sub block", _
                "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If txtOT.Text <> "" Then
            Try
                dOTHour = Convert.ToDecimal(txtOT.Text)
            Catch ex As Exception

            End Try

        End If

        If dOTHour > dTotalOT Then
            MessageBox.Show("You cannot input OT Hour more than Total OT", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        dSumOTWithoutCurrentEdit = SumOTHoursGridMinusCurrentEdit()


        If dSumOTWithoutCurrentEdit + dOTHour > dTotalOT Then
            MessageBox.Show("You cannot input OT Hour more than Total OT", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Monday, 26 Oct 2009, 10:34
        'Dim dNTPH As Double = 0
        Dim dNTPH As String = "0"
        Dim dNUnripe As Double = 0
        Dim dNUnderRipe As Double = 0
        Dim dNOverRipe As Double = 0
        Dim dNRipe As Double = 0
        Dim dNLooseFruit As Double = 0
        Dim dNDiscarded As Double = 0
        Dim dNHarvested As Double = 0
        Dim dNDeducted As Double = 0
        Dim dNPaid As Double = 0
        Dim dNDeductedLain As Double = 0
        'Dim dBTPH As Double = 0
        Dim dBTPH As String = "0"
        Dim dBUnripe As Double = 0
        Dim dBUnderRipe As Double = 0
        Dim dBOverRipe As Double = 0
        Dim dBRipe As Double = 0
        Dim dBLooseFruit As Double = 0
        Dim dBDiscarded As Double = 0
        Dim dBHarvested As Double = 0
        Dim dBDeducted As Double = 0
        Dim dBPaid As Double = 0
        Dim dBDeductedLain As Double = 0

        Dim dHa As Double = 0

        If cmbTphNormal.Text <> "- Select TPH -" Then
            dNTPH = cmbTphNormal.Text
        End If
        dNUnripe = Convert.ToDouble(txtUnripeNormal.Text)
        dNUnderRipe = Convert.ToDouble(txtUnderRipeNormal.Text)
        dNOverRipe = Convert.ToDouble(txtOverRipeNormal.Text)
        dNRipe = Convert.ToDouble(txtRipeNormal.Text)
        dNLooseFruit = Convert.ToDouble(txtLooseFruitNormal.Text)
        dNDiscarded = Convert.ToDouble(txtNDiscardedCrop.Text)
        dNHarvested = Convert.ToDouble(txtHarvestedNormal.Text)
        dNDeducted = Convert.ToDouble(txtDeductedNormal.Text)
        dNPaid = Convert.ToDouble(txtPaidNormal.Text)
        dNDeductedLain = Convert.ToDouble(txtNDendaLain.Text)

        If cmbTPHBorongan.Text <> "- Select TPH -" Then
            dBTPH = cmbTPHBorongan.Text
        End If
        dBUnripe = Convert.ToDouble(txtUnripeBorongan.Text)
        dBUnderRipe = Convert.ToDouble(txtUnderRipeBorongan.Text)
        dBOverRipe = Convert.ToDouble(txtOverRipeBorongan.Text)
        dBRipe = Convert.ToDouble(txtRipeBorongan.Text)
        dBLooseFruit = Convert.ToDouble(txtLooseFruitBorongan.Text)
        dBDiscarded = Convert.ToDouble(txtBDiscardedCrop.Text)
        dBHarvested = Convert.ToDouble(txtHarvestedBorongan.Text)
        dBDeducted = Convert.ToDouble(txtDeductedBorongan.Text)
        dBPaid = Convert.ToDouble(txtPaidBorongan.Text)
        dBDeductedLain = Convert.ToDouble(txtBDendaLain.Text)

        dHa = Convert.ToDouble(txtHa.Text)

        If (dNUnripe <> 0 Or dNUnderRipe <> 0 Or dNOverRipe <> 0 Or dNRipe <> 0 Or dNDiscarded <> 0) Then

            formulaHarvested(Harvested)
            formulaDeducted(Deducted)
            formulaPaid(Paid)

            Harvested = txtHarvestedNormal.Text
            Deducted = txtDeductedNormal.Text
            Paid = txtPaidNormal.Text

            If (Paid < 0) Then
                MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
                txtUnripeNormal.Focus()
                Exit Function
            Else
                Paid = txtPaidNormal.Text
                formulaJanjang()
                formulabrondolan()

                'Rabu, 21 Oct 2009, 01:27
                If rbNormal.Checked = False Then
                    FormulaBorongan()
                End If

                ' AddToGridDailyReceiption()
                clearInputText()

            End If


        End If

        If (dBUnripe <> 0 Or dBUnderRipe <> 0 Or dBOverRipe <> 0 Or dBRipe <> 0 Or dBDiscarded <> 0) Then

            formulaHarvested(Harvested)
            formulaDeducted(Deducted)
            formulaPaid(Paid)

            Harvested = txtHarvestedBorongan.Text
            Deducted = txtDeductedBorongan.Text
            Paid = txtPaidBorongan.Text

            If (Paid < 0) Then
                MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
                txtUnripeBorongan.Focus()
                Exit Function
            Else
                Paid = txtPaidBorongan.Text
                formulaJanjang()
                formulabrondolan()

                'Rabu, 21 Oct 2009, 01:27
                If rbNormal.Checked = False Then
                    FormulaBorongan()
                End If

                ' AddToGridDailyReceiption()
                clearInputText()
                ' rbNormal.Enabled = False
            End If
        End If

        'formulaJanjang()
        'formulabrondolan()
        'FormulaBorongan()
        '-------------
        '
        ' Get the Currency Manager by using the BindingContext of the DataGrid
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        dr.Item("OTHours") = dOTHour

        If lblBlockID.Text <> String.Empty Then
            dr.Item("BlockID") = lblBlockID.Text
            dr.Item("DivID") = lblDivID.Text
            dr.Item("YOPID") = lblYOPID.Text
            'dr.Item("StationDescp") = txtStation.Text.Trim
            'dr.Item("BlockName") = txtBlock.Text
            'dr.Item("DivName") = txtdiv.Text.Trim
            'dr.Item("YOP") = txtYOP.Text.Trim
        End If

        dr.Item("TphNormal") = dNTPH
        dr.Item("UnripeNormal") = dNUnripe
        dr.Item("UnderRipeNormal") = dNUnderRipe
        dr.Item("OverRipeNormal") = dNOverRipe
        dr.Item("RipeNormal") = dNRipe
        dr.Item("LooseFruitNormal") = dNLooseFruit
        dr.Item("DiscardedNormal") = dNDiscarded
        dr.Item("HarvestedNormal") = dNHarvested
        dr.Item("DeductedNormal") = dNDeducted
        dr.Item("PaidNormal") = dNPaid

        dr.Item("TphBorongan") = dBTPH
        dr.Item("UnripeBorongan") = dBUnripe
        dr.Item("UnderRipeBorongan") = dBUnderRipe
        dr.Item("OverRipeBorongan") = dBOverRipe
        dr.Item("RipeBorongan") = dBRipe
        dr.Item("LooseFruitBorongan") = dBLooseFruit
        dr.Item("DiscardedBorongan") = dBDiscarded
        dr.Item("HarvestedBorongan") = dBHarvested
        dr.Item("DeductedBorongan") = dBDeducted
        dr.Item("PaidBorongan") = dBPaid

        dr.Item("Ha") = dHa

        dr.Item("FKPSerialNo") = txtFKPSerialNo.Text

        If rbNormal.Checked Then
            dr.Item("PremiValue") = txtPremiValueNormal.Text
        Else
            dr.Item("PremiValue") = txtPremiValueBorongan.Text
        End If
        dr.Item("PremiHK") = strPremiHK
        dr.Item("BlkHK") = 0


        dr.Item("ModifiedBy") = GlobalPPT.strUserName
        dr.Item("ModifiedOn") = Now()
        dr.Item("DeductionLainNormal") = dNDeductedLain
        dr.Item("DeductionLainBorongan") = dBDeductedLain


        ' dgvDailyReceiption.DataSource = DTPremi_Detail
        MessageBox.Show("Data successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True


    End Function


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Senin, 21 Sep 2009, 15:42

        btnAdd.Text = "&Add"
        'btnAdd.Enabled = True
        btnReset.Enabled = False
        btnSaveAll.Enabled = True

        If IsCallingFromDailyAttendanceForm = True Then
            btnResetAll.Enabled = False
        Else
            btnResetAll.Enabled = True
        End If

        'btnResetAll.Enabled = True
        btnClose.Enabled = True

        dgvDailyReceiption.Enabled = True
        rbBorongan.Enabled = True
        rbNormal.Enabled = True
        'btnEditOrUpdate.Text = "&Edit"

        clearInputText()
    End Sub

    Private Sub clearInputText()
        txtOT.Text = 0
        'txtBlock.Text = String.Empty
        'lblBlockStatus.Text = String.Empty
        lblCategory.Text = String.Empty
        'txtdiv.Text = String.Empty
        'txtYOP.Text = String.Empty
        clearJjgInput()
        txtPremiValueBorongan.Text = "0"
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        ' Senin, 21 Sep 2009, 17:46
        'Removed because OT not entered at Reception

        'dSumOTHoursGrid = SumOTHoursGrid()

        'If dSumOTHoursGrid < dTotalOT Then
        '    MessageBox.Show("Sum of OT Hour in grid not same with Daily OT" + vbCrLf + _
        '                    "you can not save this data", "Warning", _
        '                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If

        SaveDailyReceiptionWithTeam()
        'Me.Close()

    End Sub

    Private Sub SaveDailyReceiptionWithTeam()


        ' Senin, 21 Sep 2009, 18:45
        Dim RecordAffected As Integer


        RecordAffected = DailyReceiptionTableAdapter.Update(DT_DailyReceiption)
        'RecordAffected = DailyReceiptionWithTeam_DAL.InsertReceptionTargeDetail(DT_DailyReceiption)

        For i = 0 To DTPremi_Detail.Rows.Count - 1
            If DT_DailyReceiption.Rows.Count > 0 Then
                DTPremi_Detail.Rows(i)("DailyReceiptionDetID") = DT_DailyReceiption.Rows(0)("DailyReceiptionDetID")
            End If
        Next
        'This updates the Checkroll.ReceptionTargeDetail table that is used in Premi Calculation

        DailyDetailPremiAdapter.Update(DTPremi_Detail)  '<====== Update Premi Detail


        MessageBox.Show("Data successfully save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)


        ' If RecordAffected > 0 Then

        '==============
        'Add Code By Agung
        '--------------


        'Dim dtdate As New DataTable
        'dtdate = DTPremi_Detail
        'DTPremi_Detail.Clear()
        'DTPremi_Detail = dtdate


        '   DailyDetailPremiAdapter.Update(DTPremi_Detail)


        'DailyDetailPremiAdapter.Update(DTPremi_Detail)  '<====== Update Premi Detail
        'DeleteMultiEntryRecords()

        DailyAttendanceBOL.ReceptionSummaryTeam(lblMandoreID.Text, lblKraniID.Text, lblEmpID.Text, lblBlockID.Text) '<=======Update Reception Summary 

        lblBlockID.Text = String.Empty
        txtPremiValueNormal.Text = "0"
        '--------------

        ' Sabtu, 17 Oct 2009, 03:00
        ' Selasa, 20 Oct 2009, 20:45
        ' Update MandorPremi dan KraniPremi di table DailyTeamActivity
        'Dim SumPremiValue As Decimal = DailyAttendanceWithTeam_DAL.CRDailyReceiptionSumPremiValue(dtpRDate.Value, lblGangMasterID.Text)
        'Dim MandorPremi As Decimal = 0
        'Dim KraniPremi As Decimal = 0

        '' Rabu, 24 Mar 2010, 18:34
        '' Tambah Category di parameter
        '' Karena Category dipake diperhitungan MandorPremi dan Krani Premi
        '' yg nilai MandorPremium dan KraniPremium nya diambil dari RateSetup
        'MandorPremi = (SumPremiValue / 16) * MandorPremium '1.5
        'KraniPremi = (SumPremiValue / 16) * KraniPremium '1.25

        'DailyAttendanceWithTeam_DAL.CRDailyTeamActivityUpdateMandorKraniPremi( _
        '    dtpRDate.Value, _
        '    lblDailyTeamActivityID.Text, _
        '    lblGangMasterID.Text, _
        '    lblMandoreID.Text, _
        '    lblKraniID.Text, _
        '    MandorPremi, _
        '    KraniPremi)

        'END Sabtu, 17 Oct 2009, 03:14

        ' Anand SP with 3 Cursors Inside
        DailyReceiptionWithTeam_DAL.DailyReceptionBlkHKPremiValueUpdateProcess( _
        lblEmpID.Text.Trim, _
            dtpRDate.Value)

        'Palani
        'Edit & Save -> Not Deleting from Checkroll.ReceptionTargeDetail table (dgvtargetdetail - Grid View)
        'MessageBox.Show(lblDailyReceiptionID.Text + " " + lblEmpID.Text + " " + GlobalPPT.strActMthYearID + " " + dtpRDate.Value.ToString())
        'commented by shankar. i dont know y they deleting here. previously they add. due to this i am not able to find the records for adding.
        ''DailyReceiptionWithTeam_DAL.DeleteReceptionTargeDetail(lblDailyReceiptionID.Text, lblEmpID.Text, dtpRDate.Value)

        ' Jum'at, 1 Jan 2010, 13:05
        CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
        ' END Jum'at, 1 Jan 2010, 13:05

        'Commented by Stanley 14-June-2011
        'MessageBox.Show("Reception saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' End If
        Deletemodified = False
        ' Me.Close()

    End Sub

    Private Sub EditMIDailyReceiption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMIDailyReceiption.Click
        ' Senin, 21 Sep 2009, 18:22
        'btnEditOrUpdate.Text = "&Update"

        btnAdd.Text = "&Update"

        btnReset.Enabled = True
        btnSaveAll.Enabled = False
        btnResetAll.Enabled = False
        btnClose.Enabled = False

        rowIndex_dgvDailyReceiption = dgvDailyReceiption.CurrentCell.RowIndex
        BlockIDInfo = dgvDailyReceiption.Rows(rowIndex_dgvDailyReceiption).Cells("DRBlockNameColumn").Value.ToString()
        EditDailyReceiptionWithTeam()
        dgvDailyReceiption.Enabled = False
    End Sub

    Private Sub cmsDailyReceiption_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDailyReceiption.Opening
        ' Senin, 21 Sep 2009, 18:22

        If dgvDailyReceiption.Rows.Count = 0 Then
            cmsDailyReceiption.Items(0).Enabled = False
            cmsDailyReceiption.Items(1).Enabled = False
        ElseIf dgvDailyReceiption.Rows.Count > 0 And dgvDailyReceiption.CurrentCell IsNot Nothing Then
            cmsDailyReceiption.Items(0).Enabled = True
            cmsDailyReceiption.Items(1).Enabled = True
        End If

    End Sub

    Private Sub DeleteMIDailyReceiption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMIDailyReceiption.Click
        ' Senin, 21 Sep 2009, 18:23
        If dgvDailyReceiption.Rows.Count = 0 Or dgvDailyReceiption.CurrentCell Is Nothing Then
            Return
        End If

        If MessageBox.Show("You are about to delete the selected record." + vbCrLf + _
                           "Are you sure?", "DELETE", MessageBoxButtons.OKCancel, _
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        '        Dim temp As Integer = dgvDailyReceiption.CurrentCell.RowIndex
        ' Dim temp As Integer = dgvDailyReceiption.BindingContextChanged
        'Me.dgvDailyReceiption.CurrentCell = Nothing
        'Me.dgvDailyReceiption.Rows(temp).Visible = True


        Dim j As Integer = 0
        j = dgvDailyReceiption.Rows.Count

        Dim dt, dt1 As DataTable
        dt = DT_DailyReceiption
        dt1 = DTPremi_Detail

        '   If dgvDailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Cells("DailyReceiptionDetID").Value Is System.DBNull.Value Then
        'Dim temp As New Integer
        'temp = CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)
        Me.dgvDailyReceiption.Rows.RemoveAt(dgvDailyReceiption.CurrentCell.RowIndex)

        If Not dgvDailyReceiption.CurrentCell Is Nothing Then
            Dim eIndex As Integer = dgvDailyReceiption.CurrentCell.RowIndex
            DTPremi_Detail.Rows(eIndex).Delete()

        End If


        'If (DTPremi_Detail.Rows.Count > 0) Then
        '    DTPremi_Detail.Rows(temp).Delete()

        'End If
        DTPremi_Detail.AcceptChanges()

        ' dgvDailyReceiption.Rows.RemoveAt(dgvDailyReceiption.CurrentCell.RowIndex)
        '  Else

        ' CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)
        'Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)
        dt = DT_DailyReceiption
        dt1 = DTPremi_Detail
        '' Use Currency Manager and DataView to retrieve the Current Row
        'Dim dr As DataRow
        'dr = dv.Item(cm.Position).Row

        'End If


        'Dim temp As New Integer

        'temp = CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)

        'dgvDailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Cells("DailyReceiptionDetID").Value
        'Dim temp As String
        'temp = dgvDailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Cells("DailyReceiptionDetID").Value
        'Dim i As Integer = 0
        'i = dgvDailyReceiption.Rows.Count

        'Me.dgvDailyReceiption.Rows.RemoveAt(temp)
        ''  DT_DailyReceiption.Rows(temp).Delete()
        'DTPremi_Detail.Rows(temp).Delete()
        'lDelChk = True


        '
        '       DT_DailyReceiption.Rows.Find(temp)


        'dgvDailyReceiption.Rows(dgvDailyReceiption.SelectedRows(0).Index).Cells("DailyReceiptionDetID").Value.ToString()


        'dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["CustomerCode"].Value.ToString(); 
        'DataGridView1.CurrentCell = DataGridView1.Item(column, row)


        'Me.dgvDailyReceiption.Rows.Remove(dgvDailyReceiption.CurrentRow)
        'DT_DailyReceiption.Rows(temp).Delete()
        'DTPremi_Detail.Rows(temp).Delete()


        'DeleteDailyReceiption()

        ''Dim RecordAffected As Integer

        '' RecordAffected = DailyReceiptionTableAdapter.Update(DT_DailyReceiption)

        ''If MessageBox.Show("You are about to delete the selected record." + vbCrLf + _
        ''                   "Are you sure?", "Delete", MessageBoxButtons.OKCancel, _
        ''    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
        ''    Return
        ''End If

        '' Dim RecordAffected As Integer
        ''  RecordAffected = DailyReceiptionTableAdapter.Update(DT_DailyReceiption)


        ''Dim dtTest1 As New DataTable
        ''dtTest1 = DTPremi_Detail
        'If dgvDailyReceiption.Rows.Count <> 0 Then
        '    DeleteMultientrydatagrid()
        'End If

        'DeleteDailyReceiption()
        '' RecordAffected = DailyReceiptionTableAdapter.Update(DT_DailyReceiption)

    End Sub
    Private Sub DeleteMultientrydatagrid()


        Dim DtTempPremi, DtTempDailyReception As New DataTable
        'DtTempPremi = DTPremi_Detail
        'DtTempDailyReception = DT_DailyReceiption
        lDeleteCheck = True
        ' Dim DtTempPremi, DtTempDailyReception As New DataTable
        'Dttable1 = DTPremi_Detail
        'Dttable = DT_DailyReceiption
        DtTempPremi = DTPremi_Detail.Clone
        For Each dr As DataRow In DTPremi_Detail.Rows
            DtTempPremi.ImportRow(dr)
        Next

        DtTempDailyReception = DT_DailyReceiption.Clone
        For Each dr As DataRow In DT_DailyReceiption.Rows
            DtTempDailyReception.ImportRow(dr)
        Next

        Dim Temprowindex As Integer

        Temprowindex = dgvDailyReceiption.CurrentCell.RowIndex

        If DtTempPremi.Rows(Temprowindex).Item("ReceptionTargetSumryID").ToString <> "" Then
            lReceptionTargetSummaryID = DtTempPremi.Rows(Temprowindex).Item("ReceptionTargetSumryID").ToString
        End If
        lDelete = 0
        If lReceptionTargetSummaryID <> "" Then
            'kumar anothertry
            lDelete = DeleteMultientry.Count
            DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
            DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        End If

        If DtTempPremi.Rows.Count <> 0 Then
            DtTempPremi.Rows(Temprowindex).Delete()
            ' DtTempPremi.AcceptChanges()

        End If

        If DtTempDailyReception.Rows.Count <> 0 Then
            DtTempDailyReception.Rows(Temprowindex).Delete()
            '  DtTempDailyReception.AcceptChanges()
            Deletemodified = True
        Else
            Deletemodified = False
        End If

        'DtTempPremi = DTPremi_Detail
        'DtTempDailyReception = DT_DailyReceiption
        'lDeleteCheck = True
        ' Dim DtTempPremi, DtTempDailyReception As New DataTable
        'Dttable1 = DTPremi_Detail
        'Dttable = DT_DailyReceiption

        Dim intPremi, intReception As New Integer
        intPremi = DTPremi_Detail.Rows.Count - 1
        intReception = DT_DailyReceiption.Rows.Count - 1
        DTPremi_Detail.Clear()
        DT_DailyReceiption.Clear()
        intPremi = 0
        For Each dr As DataRow In DtTempPremi.Rows
            If DtTempPremi.Rows(intPremi).RowState <> DataRowState.Deleted Then
                DTPremi_Detail.ImportRow(dr)
            End If
            intPremi = intPremi + 1
        Next
        intReception = 0
        For Each dr As DataRow In DtTempDailyReception.Rows
            If DtTempDailyReception.Rows(intReception).RowState <> DataRowState.Deleted Then
                DT_DailyReceiption.ImportRow(dr)
            End If
            intReception = intReception + 1

        Next

        Dim dt, dt1 As DataTable
        dt = DT_DailyReceiption
        dt1 = DTPremi_Detail

        'introwcount = DTPremi_Detail.Rows.Count

        'Temprowindex = dgvDailyReceiption.CurrentCell.RowIndex
        ''  Dim dtBool As Boolean = True
        'If DTPremi_Detail.Rows(Temprowindex).RowState <> DataRowState.Deleted Then
        '    If Not DTPremi_Detail.Rows(Temprowindex).Item("ReceptionTargetSumryID").ToString Is Nothing Then
        '        lReceptionTargetSummaryID = DTPremi_Detail.Rows(Temprowindex).Item("ReceptionTargetSumryID").ToString
        '    End If
        'End If
        'While introwcount > 0



        '    If lReceptionTargetSummaryID <> String.Empty Then
        '        If DTPremi_Detail.Rows(introwcount - 1).Item("ReceptionTargetSumryID") = lReceptionTargetSummaryID Then
        '            Temprowindex = introwcount - 1
        '        End If
        '        ' Else

        '    End If

        '    '   End If


        '    introwcount = introwcount - 1

        'End While
        'Dim DtTempPremi, DtTempDailyReception As New DataTable
        ' Temprowindex = dgvDailyReceiption.CurrentCell.RowIndex

        'If DTPremi_Detail.Rows(Temprowindex).RowState <> DataRowState.Deleted Then

        '    If DTPremi_Detail.Rows(Temprowindex).Item("ReceptionTargetSumryID").ToString <> "" Then
        '        lReceptionTargetSummaryID = DTPremi_Detail.Rows(Temprowindex).Item("ReceptionTargetSumryID").ToString
        '        'lDailyReceiptionDetID = DtTempDailyReception.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("DailyReceiptionDetID").ToString

        '    End If
        '    lDelete = 0
        '    If lReceptionTargetSummaryID <> "" Then
        '        'kumar anothertry
        '        lDelete = DeleteMultientry.Count
        '        DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        '        DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        '    End If

        '    If DTPremi_Detail.Rows.Count <> 0 Then
        '        DTPremi_Detail.Rows(Temprowindex).Delete()
        '        'DTPremi_Detail.AcceptChanges()

        '    End If

        '    If DT_DailyReceiption.Rows.Count <> 0 Then
        '        DT_DailyReceiption.Rows(Temprowindex).Delete()
        '        ' DT_DailyReceiption.AcceptChanges()
        '        Deletemodified = True
        '    Else
        '        Deletemodified = False
        '    End If
        'Else


        'End If
        'DtTempPremi = DTPremi_Detail
        'DtTempDailyReception = DT_DailyReceiption
        'lDeleteCheck = True
        '' Dim DtTempPremi, DtTempDailyReception As New DataTable
        ''Dttable1 = DTPremi_Detail
        ''Dttable = DT_DailyReceiption
        'For Each dr As DataRow In DtTempPremi.Rows
        '    DTPremi_Detail.ImportRow(dr)
        'Next

        'For Each dr As DataRow In DtTempDailyReception.Rows
        '    DtTempDailyReception.ImportRow(dr)
        'Next


        'DTPremi_Detail = DTPremi_Detail.Copy
        'DtTempDailyReception = DT_DailyReceiption.Copy

        'DTPremi_Detail = dgvDailyReceiption.DataSource

        'Dim intcheck As Integer
        'intcheck = 0
        'If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).RowState = DataRowState.Deleted Then
        '    intcheck = dgvDailyReceiption.CurrentCell.RowIndex + 1
        'Else
        '    intcheck = dgvDailyReceiption.CurrentCell.RowIndex
        'End If

        'If dgvDailyReceiption.Rows.Count = 1 Then
        '    intcheck = 0
        'End If


        'If DTPremi_Detail.Rows(intcheck).Item("ReceptionTargetSumryID").ToString <> "" Then
        '    lReceptionTargetSummaryID = DTPremi_Detail.Rows(intcheck).Item("ReceptionTargetSumryID").ToString
        'End If
        'lDelete = 0
        'If lReceptionTargetSummaryID <> "" Then
        '    'kumar anothertry
        '    lDelete = DeleteMultientry.Count
        '    DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        '    DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        'End If

        'If DTPremi_Detail.Rows.Count <> 0 Then
        '    DTPremi_Detail.Rows(intcheck).Delete()
        '    ' DTPremi_Detail.AcceptChanges()

        'End If

        'If DT_DailyReceiption.Rows.Count <> 0 Then
        '    DT_DailyReceiption.Rows(intcheck).Delete()
        '    '' DT_DailyReceiption.AcceptChanges()
        '    Deletemodified = True
        'Else
        '    Deletemodified = False
        'End If

        ''DTPremi_Detail = DTPremi_Detail.Copy
        ''DtTempDailyReception = DT_DailyReceiption.Copy

        'Dim intcheck As Integer
        'intcheck = 0
        'If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).RowState = DataRowState.Deleted Then
        '    intcheck = dgvDailyReceiption.CurrentCell.RowIndex + 1
        'Else
        '    intcheck = dgvDailyReceiption.CurrentCell.RowIndex
        'End If



        ' '' '' ''Dim DtTempPremi, DtTempDailyReception As New DataTable

        ' '' '' ''If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).RowState <> DataRowState.Deleted Then

        ' '' '' ''    If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString <> "" Then
        ' '' '' ''        lReceptionTargetSummaryID = DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString
        ' '' '' ''        'lDailyReceiptionDetID = DtTempDailyReception.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("DailyReceiptionDetID").ToString

        ' '' '' ''    End If
        ' '' '' ''    lDelete = 0
        ' '' '' ''    If lReceptionTargetSummaryID <> "" Then
        ' '' '' ''        'kumar anothertry
        ' '' '' ''        lDelete = DeleteMultientry.Count
        ' '' '' ''        DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        ' '' '' ''        DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        ' '' '' ''    End If

        ' '' '' ''    If DTPremi_Detail.Rows.Count <> 0 Then
        ' '' '' ''        DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        ' '' '' ''        'DTPremi_Detail.AcceptChanges()

        ' '' '' ''    End If

        ' '' '' ''    If DT_DailyReceiption.Rows.Count <> 0 Then
        ' '' '' ''        DT_DailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        ' '' '' ''        ' DT_DailyReceiption.AcceptChanges()
        ' '' '' ''        Deletemodified = True
        ' '' '' ''    Else
        ' '' '' ''        Deletemodified = False
        ' '' '' ''    End If
        ' '' '' ''Else


        ' '' '' ''End If
        ' '' '' ''DtTempPremi = DTPremi_Detail
        ' '' '' ''DtTempDailyReception = DT_DailyReceiption


        'dgvDailyReceiption.DataSource = DT_DailyReceiption

        'If dgvActivity.Rows(dgvActivity.CurrentCell.RowIndex).Cells("DailyDistributionID").Value Is System.DBNull.Value Then
        '    dgvActivity.Rows.RemoveAt(dgvActivity.CurrentCell.RowIndex)
        'Else
        '    '  DT_DailyActivityDistributionWithTeam.Rows(dgvActivity.CurrentCell.RowIndex).Delete()
        '    dgvActivity.Rows.RemoveAt(dgvActivity.CurrentCell.RowIndex)

        'End If


        'If DTPremi_Detail.Rows.Count <> 0 Then

        '    If DTPremi_Detail.Rows(0).RowState <> DataRowState.Delete Then
        '        If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString <> "" Then
        '            lReceptionTargetSummaryID = DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString
        '            ' lDailyReceiptionDetID = DT_DailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("DailyReceiptionDetID").ToString
        '            lDelete = 0
        '            If lReceptionTargetSummaryID <> "" Then
        '                'kumar anothertry
        '                lDelete = DeleteMultientry.Count
        '                DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        '                DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        '            End If
        '        End If
        '        If DTPremi_Detail.Rows.Count <> 0 Then
        '            DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        '        End If
        '        If DT_DailyReceiption.Rows.Count <> 0 Then

        '            DT_DailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        '            Deletemodified = True
        '        Else
        '            Deletemodified = False

        '        End If
        '    Else

        '        Dim intCheck As Integer = 0
        '        Dim intNo As Integer = 0
        '        intNo = DTPremi_Detail.Rows.Count - 1
        '        While intNo > 0

        '            If DTPremi_Detail.Rows(intNo).RowState <> DataRowState.Deleted Then
        '                intCheck = intCheck + 1
        '            End If
        '            intNo = intNo - 1

        '        End While


        '        'If DTPremi_Detail.Rows(0).RowState <> DataRowState.Deleted Then

        '        '    intCheck = DTPremi_Detail.Rows.Count
        '        If DTPremi_Detail.Rows.Count - intCheck = 1 Then
        '            If DTPremi_Detail.Rows(intCheck).Item("ReceptionTargetSumryID").ToString <> "" Then
        '                lReceptionTargetSummaryID = DTPremi_Detail.Rows(intCheck).Item("ReceptionTargetSumryID").ToString
        '                lDelete = 0
        '                If lReceptionTargetSummaryID <> "" Then
        '                    'kumar anothertry
        '                    lDelete = DeleteMultientry.Count
        '                    DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        '                    DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        '                End If
        '            End If
        '            If DTPremi_Detail.Rows.Count <> 0 Then
        '                DTPremi_Detail.Rows(intCheck).Delete()
        '            End If
        '            If DT_DailyReceiption.Rows.Count <> 0 Then
        '                DT_DailyReceiption.Rows(intCheck).Delete()
        '                Deletemodified = True
        '            Else
        '                Deletemodified = False
        '            End If
        '        Else
        '            If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).RowState <> DataRowState.Deleted Then

        '            End If

        '            If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString <> "" Then
        '                lReceptionTargetSummaryID = DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString
        '                lDelete = 0
        '                If lReceptionTargetSummaryID <> "" Then
        '                    'kumar anothertry
        '                    lDelete = DeleteMultientry.Count
        '                    DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        '                    DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        '                End If
        '            End If
        '            If DTPremi_Detail.Rows.Count <> 0 Then
        '                DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        '            End If
        '            If DT_DailyReceiption.Rows.Count <> 0 Then

        '                DT_DailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        '                Deletemodified = True
        '            Else
        '                Deletemodified = False

        '            End If


        '        End If



        '    End If





        'End If

        'If DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString <> "" Then
        '    lReceptionTargetSummaryID = DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Item("ReceptionTargetSumryID").ToString
        'End If
        'lDelete = 0
        'If lReceptionTargetSummaryID <> "" Then
        '    'kumar anothertry
        '    lDelete = DeleteMultientry.Count
        '    DeleteMultientry.Insert(lDelete, lReceptionTargetSummaryID)
        '    DeleteMultientryDailyReception.Insert(lDelete, lDailyReceiptionDetID)
        'End If

        'If DTPremi_Detail.Rows.Count <> 0 Then
        '    DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        'End If




        'If DT_DailyReceiption.Rows.Count <> 0 Then
        '    DT_DailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        '    Deletemodified = True
        'Else
        '    Deletemodified = False
        'End If

        'Dttable1 = DTPremi_Detail
        'Dttable = DT_DailyReceiption


        ' DgvTargetDetail.DataSource = DTPremi_Detail
    End Sub

    Private Sub DeleteMultiEntryRecords()

        lDelete = DeleteMultientry.Count

        While (lDelete > 0)

            lReceptionTargetSummaryID = DeleteMultientry(lDelete - 1)

            Dim IntJournalDetailDelete As New Integer
            IntJournalDetailDelete = PremiTargetBOL.TargetDetailDelete(lReceptionTargetSummaryID)
            lDelete = lDelete - 1

        End While

        lDelete = DeleteMultientryDailyReception.Count

        While (lDelete > 0)

            lDailyReceiptionDetID = DeleteMultientry(lDelete - 1)

            Dim IntJournalDetailDelete As New Integer
            IntJournalDetailDelete = PremiTargetBOL.DailyReceiptionDetIDDelete(lDailyReceiptionDetID)
            lDelete = lDelete - 1

        End While

    End Sub

    Private Sub DeleteDailyReceiption()

        Dim temp As Integer = dgvDailyReceiption.CurrentCell.RowIndex
        Me.dgvDailyReceiption.CurrentCell = Nothing
        Me.dgvDailyReceiption.Rows(temp).Visible = False
        DT_DailyReceiption.Rows(temp).Delete()
        DTPremi_Detail.Rows(temp).Delete()


        'Dim temp As Integer = dgvDailyReceiption.CurrentCell.RowIndex
        'Me.dgvDailyReceiption.CurrentCell = Nothing
        'Me.dgvDailyReceiption.Rows(temp).Visible = False
        'DT_DailyReceiption.Rows(temp).Delete()
        'DTPremi_Detail.Rows(temp).Delete()

        ' '' Senin, 21 Sep 2009, 18:24
        'If dgvDailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Cells("DailyReceiptionDetID").Value Is System.DBNull.Value Then
        '    dgvDailyReceiption.Rows.RemoveAt(dgvDailyReceiption.CurrentCell.RowIndex)
        'Else
        '    Dim temp As Integer = dgvDailyReceiption.CurrentCell.RowIndex
        '    Me.dgvDailyReceiption.CurrentCell = Nothing
        '    Me.dgvDailyReceiption.Rows(temp).Visible = False
        '    DT_DailyReceiption.Rows(temp).Delete()
        '    DTPremi_Detail.Rows(temp).Delete()



        '    'Me.dgvDailyReceiption.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Visible = False



        '    ' DTPremi_Detail.Rows(dgvDailyReceiption.CurrentCell.RowIndex).Delete()
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Senin, 21 Sep 2009, 18:45
        Me.Close()
    End Sub

    'Private Sub btnStationLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStationLookup.Click
    '    ' Senin, 21 Sep 2009, 19:23
    '    Dim SubStationLookupForm As StationLookup = New StationLookup()

    '    SubStationLookupForm.ShowDialog()

    '    If SubStationLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.txtStation.Text = SubStationLookupForm.psStationDesc
    '        Me.lblStationID.Text = SubStationLookupForm.psStationId
    '        '  SendKeys.Send("{TAB}")

    '        If rbNormal.Checked = True Then
    '            txtTPHNormal.Focus()
    '        Else
    '            txtTPHBorongan.Focus()
    '        End If
    '        'txtTPHNormal.Focus()
    '    End If
    'End Sub

    Private Sub txtNPayedBunches_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ' Selasa, 20 Oct 2009, 17:42
        '
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

        ' Rabu, 23 Sep 2009, 00:20
        'If e.KeyCode = Keys.Enter Then
        '    If IsNumeric(txtNPayedBunches.Text) = False Then
        '        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        '        txtNPayedBunches.Text = ""
        '        txtNPayedBunches.Focus()
        '        Return
        '    ElseIf IsNumeric(txtNPayedBunches.Text) = True Then

        '        txtNLooseFruits.Focus()
        '    End If
        'ElseIf e.KeyCode = Keys.Escape Then
        '    txtNLooseFruits.Focus()
        'End If

    End Sub

    Private Sub txtNLooseFruits_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        ' Selasa, 20 Oct 2009, 17:47
        '
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            btnAdd.Focus()
        End If

        '' Rabu, 23 Sep 2009, 00:20
        'If e.KeyCode = Keys.Enter Then
        '    If IsNumeric(txtNLooseFruits.Text) = False Then
        '        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        '        txtNLooseFruits.Text = ""
        '        txtNLooseFruits.Focus()
        '        Return
        '    ElseIf IsNumeric(txtNLooseFruits.Text) = True Then
        '        If btnAdd.Enabled Then
        '            btnAdd.Focus()
        '        ElseIf btnEditOrUpdate.Enabled Then
        '            btnEditOrUpdate.Focus()
        '        End If
        '    End If
        'ElseIf e.KeyCode = Keys.Escape Then
        '    If btnAdd.Enabled Then
        '        btnAdd.Focus()
        '    ElseIf btnEditOrUpdate.Enabled Then
        '        btnEditOrUpdate.Focus()
        '    End If
        'End If
    End Sub

    Private Sub btnMandorReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '' Rabu, 23 Sep 2009, 03:05
        MessageBox.Show("Under contraction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return

        'If lblDailyReceiptionID.Text <> "NOTVALID" Then
        '    Cursor = Cursors.WaitCursor

        '    Dim report As ViewReport = New ViewReport()
        '    Dim dEnd As Date = New Date(dtpRDate.Value.Year, dtpRDate.Value.Month, dtpRDate.Value.Day + 1)

        '    Dim reportPath As String
        '    reportPath = Application.StartupPath + "\Checkroll\Report\DailyReceiptionWithTeamReport.rpt"

        '    report._Source = reportPath
        '    report._Formula = _
        '    "{DailyReceiption.DailyReceiptionID} = '" + lblDailyReceiptionID.Text + "' AND " + _
        '    "{GangMaster.GangName} = '" + lblTeamName.Text + "'"

        '    report.Show()
        '    'Dim report As DailyReceiptionWithTeam_Report
        '    'report = New DailyReceiptionWithTeam_Report()

        '    'report.RDate = dtpRDate.Value
        '    'report.TeamName = lblTeamName.Text
        '    'report.Show()

        '    Cursor = Cursors.Default
        'Else

        '    MessageBox.Show("No data to show.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'End If

        ''Dim DS As DS_DailyReceiptionWithTeam_Report = _
        ''    New DS_DailyReceiptionWithTeam_Report(lblTeamName.Text, dtpRDate.Value)

        ''DS.WriteXmlSchema("DS_DailyReceiptionWithTeam.xml")

    End Sub

    Private Sub dgvDailyReceiption_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyReceiption.CellDoubleClick

        If dgvDailyReceiption.Rows.Count > 0 Then

            'btnEditOrUpdate.Text = "&Update"

            'btnAdd.Enabled = False

            btnAdd.Text = "&Update"

            btnReset.Enabled = True

            btnSaveAll.Enabled = False
            btnReset.Enabled = True
            btnResetAll.Enabled = False
            btnClose.Enabled = False

            rowIndex_dgvDailyReceiption = dgvDailyReceiption.CurrentCell.RowIndex
            BlockIDInfo = dgvDailyReceiption.Rows(rowIndex_dgvDailyReceiption).Cells("DRBlockNameColumn").Value.ToString()
            EditDailyReceiptionWithTeam()
            dgvDailyReceiption.Enabled = False

            DailyDetailPremiAdapter = New PremiTargetDAL
            ' Kamis, 11 Mar 2010, 15:21,
            ' Pemanggilan ke TargetDetailView utk parameter GangMasterID yg sebelumnya diisi lblDailyTeamActivityID
            ' diganti dgn lblGangMasterID
            'DTPremi_Detail = PremiTargetBOL.TargetDetailView(lblDailyTeamActivityID.Text, lblMandoreID.Text, lblKraniID.Text, lblBlockID.Text, lblempid.Text, dtpRDate.Value)


            'COMMENTED BY NELSON JUN24-2010
            'DTPremi_Detail = PremiTargetBOL.TargetDetailView(lblGangMasterID.Text, lblMandoreID.Text, lblKraniID.Text, lblBlockID.Text, lblEmpID.Text, dtpRDate.Value)
            'END
            'ADDED BY NELSON JUN24-2010
            'If btnSaveAll.Text = "" Then

            'End If
            Dim DtCheckdate As New DataTable
            DtCheckdate = PremiTargetBOL.TargetDetailView(lblDailyTeamActivityID.Text, lblMandoreID.Text, lblKraniID.Text, lblBlockID.Text, lblEmpID.Text, dtpRDate.Value)


            'END

            If DtCheckdate.Rows.Count <> 0 Then
                DgvTargetDetail.DataSource = DtCheckdate
            End If

        End If

    End Sub

    Private Sub AddPremiDetailGrid()
        Dim NewRow As System.Data.DataRow
        '   DTPremi_Detail = DTPremi_Detail
        NewRow = DTPremi_Detail.NewRow
        NewRow.Item("EstateID") = GlobalPPT.strEstateID
        NewRow.Item("Estatecode") = GlobalPPT.strEstateCode
        NewRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        NewRow.Item("GangMasterID") = lblDailyTeamActivityID.Text
        'lblDailyTeamActivityID.Text
        'NewRow.Item("Activity") = ""
        'NewRow.Item("MandoreID") = ""
        'NewRow.Item("KraniID") = ""
        If lblBlockID.Text <> "" Then
            NewRow.Item("DivID") = lblDivID.Text
            NewRow.Item("YOPID") = lblYOPID.Text
            NewRow.Item("BlockID") = lblBlockID.Text
        End If
        NewRow.Item("TotalBunches") = 0
        NewRow.Item("TotalLooseFruits") = 0
        NewRow.Item("TotalTonnage") = 0
        NewRow.Item("TotalBorongan") = 0
        NewRow.Item("TotalBoronganValue") = 0
        NewRow.Item("RDate") = dtpRDate.Value
        NewRow.Item("EmpID") = lblEmpID.Text
        NewRow.Item("TBunches1") = 0
        NewRow.Item("TValue1") = 0
        NewRow.Item("TBunches2") = 0
        NewRow.Item("TValue2") = 0
        NewRow.Item("TBunches3") = 0
        NewRow.Item("TValue3") = 0
        NewRow.Item("TBunches4") = 0
        NewRow.Item("TValue4") = 0
        NewRow.Item("TBunches5") = 0
        NewRow.Item("TValue5") = 0
        NewRow.Item("TBunches6") = 0
        NewRow.Item("TValue6") = 0
        NewRow.Item("TBunches7") = 0
        NewRow.Item("TValue7") = 0
        NewRow.Item("TBunches8") = 0
        NewRow.Item("TValue8") = 0
        NewRow.Item("TBunches9") = 0
        NewRow.Item("TValue9") = 0
        NewRow.Item("TBunches10") = 0
        NewRow.Item("TValue10") = 0
        NewRow.Item("TLooseFruit1") = 0
        NewRow.Item("TLooseFruitValue1") = 0
        NewRow.Item("TLooseFruit2") = 0
        NewRow.Item("TLooseFruitValue2") = 0
        NewRow.Item("TLooseFruit3") = 0
        NewRow.Item("TLooseFruitValue3") = 0
        NewRow.Item("TLooseFruit4") = 0
        NewRow.Item("TLooseFruitValue4") = 0
        NewRow.Item("TLooseFruit5") = 0
        NewRow.Item("TLooseFruitValue5") = 0
        NewRow.Item("TTonnage1") = 0
        NewRow.Item("TTonnageValue1") = 0
        NewRow.Item("TTonnage2") = 0
        NewRow.Item("TTonnageValue2") = 0
        NewRow.Item("TTonnage3") = 0
        NewRow.Item("TTonnageValue3") = 0
        NewRow.Item("TTonnage4") = 0
        NewRow.Item("TTonnageValue4") = 0
        NewRow.Item("TTonnage5") = 0
        NewRow.Item("TTonnageValue5") = 0
        NewRow.Item("CreatedBy") = GlobalPPT.strUserName
        NewRow.Item("CreatedOn") = dtpRDate.Value
        NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
        NewRow.Item("ModifiedOn") = dtpRDate.Value
        DTPremi_Detail.Rows.Add(NewRow)

    End Sub

    Private Sub formulaJanjang()
        Dim hjanjang As Integer
        Dim totPremi As Integer

        Dim target As Integer ' Rabu, 10 Feb 2010, 15:09
        Dim bMauSelesai As Boolean = False
        Dim bSelesai As Boolean = False
        Dim j As Integer = 0
        'Dim recordaddcheck As Boolean = False
        Dim TBunches1 As Decimal = 0
        Dim TValue1 As Decimal = 0
        Dim TBunches2 As Decimal = 0
        Dim TValue2 As Decimal = 0
        Dim TBunches3 As Decimal = 0
        Dim TValue3 As Decimal = 0
        Dim TBunches4 As Decimal = 0
        Dim TValue4 As Decimal = 0
        Dim TBunches5 As Decimal = 0
        Dim TValue5 As Decimal = 0
        Dim TBunches6 As Decimal = 0
        Dim TValue6 As Decimal = 0
        Dim TBunches7 As Decimal = 0
        Dim TValue7 As Decimal = 0
        Dim TBunches8 As Decimal = 0
        Dim TValue8 As Decimal = 0
        Dim TBunches9 As Decimal = 0
        Dim TValue9 As Decimal = 0
        Dim TBunches10 As Decimal = 0
        Dim TValue10 As Decimal = 0


        target = 0

        totPremi = 0
        txtPremiValueNormal.Text = 0

        'If rbNormal.Checked = True Then
        '    hjanjang = FormatNumber(Val(txtNPayedBunches.Text), 2)
        'ElseIf rbBorongan.Checked = True Then
        '    hjanjang = FormatNumber(Val(txtBPayedBunches.Text), 2)
        'End If


        If rbNormal.Checked = True Then
            hjanjang = FormatNumber(Val(txtHarvestedNormal.Text), 2)
        ElseIf rbBorongan.Checked = True Then
            hjanjang = FormatNumber(Val(txtHarvestedBorongan.Text), 2)
        End If

        '-----
        ' By Dadang Adi H
        ' Rabu, 10 Feb 2010
        '
        ' Perbaikan perhitungan Premi
        ' Jadi, kalo masuk target2 dan seterusnya,
        ' maka angkanya harus (MaxBunches - MinBunches) + 1

        'Dim dtTest As New DataTable
        'dtTest = DTPremi_Detail


        '-----
        'If DTPremi_Detail.Rows.Count > 0 Then
        '    ' Kamis, 11 Feb 2010, 09:05
        '    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches2") = 0
        '    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue2") = 0

        '    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches3") = 0
        '    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue3") = 0

        '    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches4") = 0
        '    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue4") = 0
        'End If

        If dgPremi.Rows.Count > 0 Then
            For i = 0 To dgPremi.Rows.Count - 1

                '-----
                ' Rabu, 10 Feb 2010, 15:23
                If dgPremi.Rows(i).Cells("MinBunches").Value = 0 Then
                    ' contoh 0 - 65
                    target = dgPremi.Rows(i).Cells("MaxBunches").Value - dgPremi.Rows(i).Cells("MinBunches").Value

                    If hjanjang > target Then
                        hjanjang = hjanjang - target
                        totPremi = target

                    ElseIf hjanjang <= target Then
                        totPremi = hjanjang
                        hjanjang = 0
                        bMauSelesai = True
                    End If

                Else
                    'contoh 66-85 -> Ini harusnya selisihnya 85-66 +1 = 20, bukan 19
                    target = dgPremi.Rows(i).Cells("MaxBunches").Value - dgPremi.Rows(i).Cells("MinBunches").Value + 1

                    If hjanjang > target Then
                        hjanjang = hjanjang - target
                        totPremi = target

                    ElseIf hjanjang <= target Then
                        totPremi = hjanjang
                        hjanjang = 0
                        bMauSelesai = True
                    End If
                End If


                If bSelesai = False Then
                    txtPremiValueNormal.Text = Val(txtPremiValueNormal.Text) + (FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value))

                    'If DTPremi_Detail.Rows.Count = 0 Then
                    '    AddPremiDetailGrid()
                    '    'ElseIf recordaddcheck = False Then
                    '    '    j = DTPremi_Detail.Rows.Count
                    '    '    recordaddcheck = True
                    'End If


                    'ADDED BY NELSON JUN24-2010


                    If i = 0 Then
                        TBunches1 = FormatNumber(Val(totPremi), 2)
                        TValue1 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 1 Then
                        TBunches2 = FormatNumber(Val(totPremi), 2)
                        TValue2 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 2 Then
                        TBunches3 = FormatNumber(Val(totPremi), 2)
                        TValue3 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 3 Then
                        TBunches4 = FormatNumber(Val(totPremi), 2)
                        TValue4 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 4 Then
                        TBunches5 = FormatNumber(Val(totPremi), 2)
                        TValue5 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 5 Then
                        TBunches6 = FormatNumber(Val(totPremi), 2)
                        TValue6 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 6 Then
                        TBunches7 = FormatNumber(Val(totPremi), 2)
                        TValue7 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 7 Then
                        TBunches8 = FormatNumber(Val(totPremi), 2)
                        TValue8 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 8 Then
                        TBunches9 = FormatNumber(Val(totPremi), 2)
                        TValue9 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If
                    If i = 9 Then
                        TBunches10 = FormatNumber(Val(totPremi), 2)
                        TValue10 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    End If



                    'UPDATE DETAIL TARGET PREMI BUNCHES
                    '==============================
                    ' by Dadang, Kamis, 11 Mar 2010, 01:48 kok GangMasterID diisi DailyTeamActivityID
                    ' by Dadang Adi

                    ' Kamis, 11 Mar 2010, 14:47
                    ' Field GangMasterID diisi label lblDailyTeamActivityID.Text
                    ' diganti jadi diisi dgn lblGangMasterID.Text
                    'COMMENTED BY NELSON JUN24-2010
                    'DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("GangMasterID") = lblGangMasterID.Text 'lblDailyTeamActivityID.Text
                    'END
                    '' ''ADDED BY NELSON JUN24-2010

                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("GangMasterID") = lblDailyTeamActivityID.Text
                    '' ''END

                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("MandoreID") = lblMandoreID.Text
                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("KraniID") = lblKraniID.Text
                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("Activity") = lblActivity.Text
                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalBunches") = FormatNumber(Val(txtNPayedBunches.Text), 2)
                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalLooseFruits") = FormatNumber(Val(txtNLooseFruits.Text), 2)
                    ' ''DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalBorongan") = FormatNumber(Val(txtBPayedBunches.Text), 2)
                    ' ''If i = 0 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches1") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue1") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 1 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches2") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue2") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 2 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches3") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue3") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 3 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches4") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue4") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 4 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches5") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue5") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 5 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches6") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue6") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 6 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches7") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue7") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 7 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches8") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue8") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 8 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches9") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue9") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                    ' ''If i = 9 Then
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TBunches10") = FormatNumber(Val(totPremi), 2)
                    ' ''    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TValue10") = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("BunchRate").Value)
                    ' ''End If
                End If
            Next i

            '  DailyDetailPremiAdapter = New PremiTargetDAL
            '  Dim objPettyCashPaymentPPT As New PettyCashPaymentPPT
            '   Dim objPremiTargetBOL As New PremiTargetBOL





            If btnAdd.Text = "&Add" Then
                AddPremiDetailGrid()
                j = DTPremi_Detail.Rows.Count - 1
                DTPremi_Detail.Rows(j).Item("GangMasterID") = lblDailyTeamActivityID.Text

                DTPremi_Detail.Rows(j).Item("MandoreID") = lblMandoreID.Text
                DTPremi_Detail.Rows(j).Item("KraniID") = lblKraniID.Text
                DTPremi_Detail.Rows(j).Item("Activity") = lblActivity.Text
                DTPremi_Detail.Rows(j).Item("TotalBunches") = FormatNumber((Val(txtHarvestedNormal.Text) + Val(txtHarvestedBorongan.Text)), 2)
                DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber((Val(txtLooseFruitNormal.Text) + Val(txtLooseFruitBorongan.Text)), 2)
                DTPremi_Detail.Rows(j).Item("TotalBorongan") = FormatNumber(Val(txtHarvestedBorongan.Text), 2)

                DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
                DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
                DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text



                If Val(txtHarvestedBorongan.Text) = 0 Then
                    DTPremi_Detail.Rows(j).Item("TBunches1") = TBunches1
                    DTPremi_Detail.Rows(j).Item("TValue1") = TValue1

                    DTPremi_Detail.Rows(j).Item("TBunches2") = TBunches2
                    DTPremi_Detail.Rows(j).Item("TValue2") = TValue2

                    DTPremi_Detail.Rows(j).Item("TBunches3") = TBunches3
                    DTPremi_Detail.Rows(j).Item("TValue3") = TValue3

                    DTPremi_Detail.Rows(j).Item("TBunches4") = TBunches4
                    DTPremi_Detail.Rows(j).Item("TValue4") = TValue4

                    DTPremi_Detail.Rows(j).Item("TBunches5") = TBunches5
                    DTPremi_Detail.Rows(j).Item("TValue5") = TValue5

                    DTPremi_Detail.Rows(j).Item("TBunches6") = TBunches6
                    DTPremi_Detail.Rows(j).Item("TValue6") = TValue6

                    DTPremi_Detail.Rows(j).Item("TBunches7") = TBunches7
                    DTPremi_Detail.Rows(j).Item("TValue7") = TValue7

                    DTPremi_Detail.Rows(j).Item("TBunches8") = TBunches8
                    DTPremi_Detail.Rows(j).Item("TValue8") = TValue8

                    DTPremi_Detail.Rows(j).Item("TBunches9") = TBunches9
                    DTPremi_Detail.Rows(j).Item("TValue9") = TValue9

                    DTPremi_Detail.Rows(j).Item("TBunches10") = TBunches10
                    DTPremi_Detail.Rows(j).Item("TValue10") = TValue10
                Else
                    DTPremi_Detail.Rows(j).Item("TBunches1") = 0
                    DTPremi_Detail.Rows(j).Item("TValue1") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches2") = 0
                    DTPremi_Detail.Rows(j).Item("TValue2") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches3") = 0
                    DTPremi_Detail.Rows(j).Item("TValue3") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches4") = 0
                    DTPremi_Detail.Rows(j).Item("TValue4") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches5") = 0
                    DTPremi_Detail.Rows(j).Item("TValue5") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches6") = 0
                    DTPremi_Detail.Rows(j).Item("TValue6") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches7") = 0
                    DTPremi_Detail.Rows(j).Item("TValue7") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches8") = 0
                    DTPremi_Detail.Rows(j).Item("TValue8") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches9") = 0
                    DTPremi_Detail.Rows(j).Item("TValue9") = 0

                    DTPremi_Detail.Rows(j).Item("TBunches10") = 0
                    DTPremi_Detail.Rows(j).Item("TValue10") = 0
                End If

                'Else
                '    AddPremiDetailGrid()
                '    j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index
            Else
                If DTPremi_Detail.Rows.Count = 0 Then
                    DTPremi_Detail = PremiTargetBOL.TargetDetailView(lblDailyTeamActivityID.Text, lblMandoreID.Text, lblKraniID.Text, "", lblEmpID.Text, dtpRDate.Value)
                End If
                If DTPremi_Detail.Rows.Count > 0 Then
                    Dim dtTest1 As New DataTable
                    dtTest1 = DTPremi_Detail
                    ' j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index
                    j = CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)

                    DTPremi_Detail.Rows(j).Item("GangMasterID") = lblDailyTeamActivityID
                    DTPremi_Detail.Rows(j).Item("MandoreID") = lblMandoreID.Text
                    DTPremi_Detail.Rows(j).Item("KraniID") = lblKraniID.Text
                    DTPremi_Detail.Rows(j).Item("Activity") = lblActivity.Text
                    DTPremi_Detail.Rows(j).Item("TotalBunches") = FormatNumber((Val(txtHarvestedNormal.Text) + Val(txtHarvestedBorongan.Text)), 2)
                    DTPremi_Detail.Rows(j).Item("TotalLooseFruits") = FormatNumber((Val(txtLooseFruitNormal.Text) + Val(txtLooseFruitBorongan.Text)), 2)
                    DTPremi_Detail.Rows(j).Item("TotalBorongan") = FormatNumber(Val(txtHarvestedBorongan.Text), 2)

                    DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
                    DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
                    DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text

                    If Val(txtPaidBorongan.Text) = 0 Then
                        DTPremi_Detail.Rows(j).Item("TBunches1") = TBunches1
                        DTPremi_Detail.Rows(j).Item("TValue1") = TValue1

                        DTPremi_Detail.Rows(j).Item("TBunches2") = TBunches2
                        DTPremi_Detail.Rows(j).Item("TValue2") = TValue2

                        DTPremi_Detail.Rows(j).Item("TBunches3") = TBunches3
                        DTPremi_Detail.Rows(j).Item("TValue3") = TValue3

                        DTPremi_Detail.Rows(j).Item("TBunches4") = TBunches4
                        DTPremi_Detail.Rows(j).Item("TValue4") = TValue4

                        DTPremi_Detail.Rows(j).Item("TBunches5") = TBunches5
                        DTPremi_Detail.Rows(j).Item("TValue5") = TValue5

                        DTPremi_Detail.Rows(j).Item("TBunches6") = TBunches6
                        DTPremi_Detail.Rows(j).Item("TValue6") = TValue6

                        DTPremi_Detail.Rows(j).Item("TBunches7") = TBunches7
                        DTPremi_Detail.Rows(j).Item("TValue7") = TValue7

                        DTPremi_Detail.Rows(j).Item("TBunches8") = TBunches8
                        DTPremi_Detail.Rows(j).Item("TValue8") = TValue8

                        DTPremi_Detail.Rows(j).Item("TBunches9") = TBunches9
                        DTPremi_Detail.Rows(j).Item("TValue9") = TValue9

                        DTPremi_Detail.Rows(j).Item("TBunches10") = TBunches10
                        DTPremi_Detail.Rows(j).Item("TValue10") = TValue10
                    Else
                        DTPremi_Detail.Rows(j).Item("TBunches1") = 0
                        DTPremi_Detail.Rows(j).Item("TValue1") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches2") = 0
                        DTPremi_Detail.Rows(j).Item("TValue2") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches3") = 0
                        DTPremi_Detail.Rows(j).Item("TValue3") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches4") = 0
                        DTPremi_Detail.Rows(j).Item("TValue4") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches5") = 0
                        DTPremi_Detail.Rows(j).Item("TValue5") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches6") = 0
                        DTPremi_Detail.Rows(j).Item("TValue6") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches7") = 0
                        DTPremi_Detail.Rows(j).Item("TValue7") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches8") = 0
                        DTPremi_Detail.Rows(j).Item("TValue8") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches9") = 0
                        DTPremi_Detail.Rows(j).Item("TValue9") = 0

                        DTPremi_Detail.Rows(j).Item("TBunches10") = 0
                        DTPremi_Detail.Rows(j).Item("TValue10") = 0
                    End If
                End If

            End If



            Dim dtTest As New DataTable
            dtTest = DTPremi_Detail
            ''dgvDailyReceiption.DataSource = DTPremi_Detail

        End If

    End Sub

    Private Sub formulabrondolan()
        Dim hBrd As Integer
        Dim totPremi As Integer
        totPremi = 0
        If rbNormal.Checked = True Then
            hBrd = FormatNumber(Val(txtLooseFruitNormal.Text), 2)
        ElseIf rbBorongan.Checked = True Then
            hBrd = FormatNumber(Val(txtLooseFruitBorongan.Text), 2)
        End If

        Dim TLooseFruit1 As Decimal = 0
        Dim TLooseFruitValue1 As Decimal = 0
        Dim TLooseFruit2 As Decimal = 0
        Dim TLooseFruitValue2 As Decimal = 0
        Dim TLooseFruit3 As Decimal = 0
        Dim TLooseFruitValue3 As Decimal = 0
        Dim TLooseFruit4 As Decimal = 0
        Dim TLooseFruitValue4 As Decimal = 0
        Dim TLooseFruit5 As Decimal = 0
        Dim TLooseFruitValue5 As Decimal = 0


        For i = 0 To dgPremi.Rows.Count - 1
            If hBrd > Val(dgPremi.Rows(i).Cells("MaxLooseFruits").Value) Then
                hBrd = hBrd - Val(dgPremi.Rows(i).Cells("MaxLooseFruits").Value)
                totPremi = Val(dgPremi.Rows(i).Cells("MaxLooseFruits").Value) - Val(dgPremi.Rows(i).Cells("MinLooseFruits").Value)
                txtPremiValueNormal.Text = Val(txtPremiValueNormal.Text) + (FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value))


                If i = 0 Then
                    TLooseFruit1 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue1 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                    Exit For
                End If
                If i = 1 Then
                    TLooseFruit2 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue2 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If
                If i = 2 Then
                    TLooseFruit3 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue3 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If
                If i = 3 Then
                    TLooseFruit4 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue4 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If
                If i = 4 Then
                    TLooseFruit5 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue5 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If


            ElseIf hBrd < Val(dgPremi.Rows(i).Cells("MaxLooseFruits").Value) Then
                totPremi = Val(hBrd)
                txtPremiValueNormal.Text = Val(txtPremiValueNormal.Text) + (FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value))


                If i = 0 Then
                    TLooseFruit1 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue1 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                    Exit For
                End If
                If i = 1 Then
                    TLooseFruit2 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue2 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If
                If i = 2 Then
                    TLooseFruit3 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue3 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If
                If i = 3 Then
                    TLooseFruit4 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue4 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If
                If i = 4 Then
                    TLooseFruit5 = FormatNumber(Val(totPremi), 2)
                    TLooseFruitValue5 = FormatNumber(Val(totPremi), 2) * Val(dgPremi.Rows(i).Cells("LooseFruitsRate").Value)
                End If


            End If
        Next i

        Dim dtTest As New DataTable
        ' dtTest = DTPremi_Detail
        Dim j As Integer = 0
        If btnAdd.Text = "&Add" Then
            '   AddPremiDetailGrid()
            j = DTPremi_Detail.Rows.Count - 1
            DTPremi_Detail.Rows(j).Item("TLooseFruit1") = TLooseFruit1
            DTPremi_Detail.Rows(j).Item("TLooseFruitValue1") = TLooseFruitValue1
            DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
            DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
            DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text
            DTPremi_Detail.Rows(j).Item("TLooseFruit2") = 0
            DTPremi_Detail.Rows(j).Item("TLooseFruitValue2") = 0
            DTPremi_Detail.Rows(j).Item("TLooseFruit3") = 0
            DTPremi_Detail.Rows(j).Item("TLooseFruitValue3") = 0
            DTPremi_Detail.Rows(j).Item("TLooseFruit4") = 0
            DTPremi_Detail.Rows(j).Item("TLooseFruitValue4") = 0

            DTPremi_Detail.Rows(j).Item("TLooseFruit5") = 0
            DTPremi_Detail.Rows(j).Item("TLooseFruitValue5") = 0

        Else

            If (DTPremi_Detail.Rows.Count > 0) Then


                j = CType(dgvDailyReceiption.DataSource, DataTable).Rows.IndexOf(CType(dgvDailyReceiption.CurrentRow.DataBoundItem, DataRowView).Row)

                ' j = dgvDailyReceiption.SelectedRows(dgvDailyReceiption.Rows(0).Index).Index

                DTPremi_Detail.Rows(j).Item("YOPID") = lblYOPID.Text
                DTPremi_Detail.Rows(j).Item("DIVID") = lblDivID.Text
                DTPremi_Detail.Rows(j).Item("BlockID") = lblBlockID.Text
                DTPremi_Detail.Rows(j).Item("TLooseFruit1") = TLooseFruit1
                DTPremi_Detail.Rows(j).Item("TLooseFruitValue1") = TLooseFruitValue1
                DTPremi_Detail.Rows(j).Item("TLooseFruit2") = 0
                DTPremi_Detail.Rows(j).Item("TLooseFruitValue2") = 0
                DTPremi_Detail.Rows(j).Item("TLooseFruit3") = 0
                DTPremi_Detail.Rows(j).Item("TLooseFruitValue3") = 0
                DTPremi_Detail.Rows(j).Item("TLooseFruit4") = 0
                DTPremi_Detail.Rows(j).Item("TLooseFruitValue4") = 0

                DTPremi_Detail.Rows(j).Item("TLooseFruit5") = 0
                DTPremi_Detail.Rows(j).Item("TLooseFruitValue5") = 0
            End If
        End If



        dtTest = DTPremi_Detail

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        formulaJanjang()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        formulabrondolan()

    End Sub

    Private Sub btnViewNik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtBlock.Text <> Nothing Then
            PremiLookUp.txtAttendanceCode.Text = Me.txtAttendanceCode.Text
            PremiLookUp.txtBlockID.Text = Me.lblBlockID.Text
            PremiLookUp.ShowDialog()
        ElseIf txtBlock.Text = Nothing Then
            MsgBox("Premi Information cannot be show, Please select the Field No", MsgBoxStyle.Critical + MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub txtOT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Selasa, 20 Oct 2009, 17:22
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtBlock.Focus()
            End If
        End If

    End Sub

    Private Sub txtOT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Selasa, 20 Oct 2009, 17:36
        If txtOT.Text = "" Or txtOT.Text = "." Then
            txtOT.Text = "0"
        End If

    End Sub

    'Normal (_Leave, _KeyPress, _KeyDown)
    '---------------------------------------------------------------

    'Private Sub txtTPHNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ' Selasa, 20 Oct 2009, 17:39
    '    If txtTPHNormal.Text = "" Or txtTPHNormal.Text = "." Then
    '        txtTPHNormal.Text = "0"
    '    End If

    '    ' Rabu, 18 Nov 2009, 09:10
    '    ' Kasih Nilai Default utk Jjg dibayar = Jjg Actual
    '    'txtUnripeNormal.Text = txtTPHNormal.Text
    'End Sub

    Private Sub txtTPHNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '' Selasa, 20 Oct 2009, 17:42
        ''
        '' Initialize the flag to false.
        'nonNumberEntered = False

        '' Determine whether the keystroke is a number from the top of the keyboard.
        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '    ' Determine whether the keystroke is a number from the keypad.
        '    If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '        ' Determine whether the keystroke is a backspace.
        '        If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
        '            ' A non-numerical keystroke was pressed. 
        '            ' Set the flag to true and evaluate in KeyPress event.
        '            nonNumberEntered = True
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub txtTPHNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' Selasa, 20 Oct 2009, 17:38
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        'If nonNumberEntered = True Then
        '    ' Stop the character from being entered into the control since it is non-numerical.
        '    e.Handled = True
        'Else
        If e.KeyChar = vbCr Then
            txtUnripeNormal.Focus()
        End If
        'End If

    End Sub

    Private Sub txtUnripeNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnripeNormal.Leave
        If txtUnripeNormal.Text = "" Or txtUnripeNormal.Text = "." Then
            txtUnripeNormal.Text = "0"
        End If

        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidNormal.Text
        'End If
    End Sub

    Private Sub txtUnripeNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnripeNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtUnripeNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnripeNormal.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtUnderRipeNormal.Focus()
            End If
        End If

    End Sub

    Private Sub txtUnderRipeNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnderRipeNormal.Leave
        If txtUnderRipeNormal.Text = "" Or txtUnderRipeNormal.Text = "." Then
            txtUnderRipeNormal.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidNormal.Text
        'End If
    End Sub

    Private Sub txtUnderRipeNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnderRipeNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtUnderRipeNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnderRipeNormal.KeyPress
        ' Selasa, 20 Oct 2009, 17:38
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtOverRipeNormal.Focus()
            End If
        End If
    End Sub

    Private Sub txtOverRipeNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOverRipeNormal.Leave
        If txtOverRipeNormal.Text = "" Or txtOverRipeNormal.Text = "." Then
            txtOverRipeNormal.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidNormal.Text
        'End If
    End Sub

    Private Sub txtOverRipeNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOverRipeNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtOverRipeNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOverRipeNormal.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtRipeNormal.Focus()
            End If
        End If

    End Sub

    Private Sub txtRipeNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRipeNormal.Leave
        If txtRipeNormal.Text = "" Or txtRipeNormal.Text = "." Then
            txtRipeNormal.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidNormal.Text
        'End If
    End Sub

    Private Sub txtRipeNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRipeNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtRipeNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRipeNormal.KeyPress
        ' Selasa, 20 Oct 2009, 17:38
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtLooseFruitNormal.Focus()
            End If
        End If

    End Sub

    Private Sub txtLooseFruitNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLooseFruitNormal.Leave
        If txtLooseFruitNormal.Text = "" Or txtLooseFruitNormal.Text = "." Then
            txtLooseFruitNormal.Text = "0"
        End If
    End Sub

    Private Sub txtLooseFruitNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLooseFruitNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtLooseFruitNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLooseFruitNormal.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtNDiscardedCrop.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub

    Private Sub txtHarvestedNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarvestedNormal.Leave
        If txtHarvestedNormal.Text = "" Or txtHarvestedNormal.Text = "." Then
            txtHarvestedNormal.Text = "0"
        End If
    End Sub

    Private Sub txtHarvestedNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHarvestedNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtHarvestedNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarvestedNormal.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtDeductedNormal.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub

    Private Sub txtDeductedNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeductedNormal.Leave
        If txtDeductedNormal.Text = "" Or txtDeductedNormal.Text = "." Then
            txtDeductedNormal.Text = "0"
        End If
    End Sub

    Private Sub txtDeductedNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeductedNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtDeductedNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeductedNormal.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtPaidNormal.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub

    Private Sub txtPaidNormal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaidNormal.Leave
        If txtPaidNormal.Text = "" Or txtPaidNormal.Text = "." Then
            txtPaidNormal.Text = "0"
        End If
    End Sub

    Private Sub txtPaidNormal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaidNormal.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtPaidNormal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaidNormal.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub
    'end Normal (_Leave, _KeyPress, _KeyDown)
    '---------------------------------------------------------------

    'Borongan (_Leave, _KeyPress, _KeyDown)
    '---------------------------------------------------------------

    'Private Sub txtTPHBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ' Selasa, 20 Oct 2009, 17:39
    '    If txtTPHBorongan.Text = "" Or txtTPHBorongan.Text = "." Then
    '        txtTPHBorongan.Text = "0"
    '    End If

    '    ' Rabu, 18 Nov 2009, 09:10
    '    ' Kasih Nilai Default utk Jjg dibayar = Jjg Actual
    '    'txtUnripeNormal.Text = txtTPHNormal.Text
    'End Sub

    Private Sub txtTPHBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '' Selasa, 20 Oct 2009, 17:42
        ''
        '' Initialize the flag to false.
        'nonNumberEntered = False

        '' Determine whether the keystroke is a number from the top of the keyboard.
        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '    ' Determine whether the keystroke is a number from the keypad.
        '    If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '        ' Determine whether the keystroke is a backspace.
        '        If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
        '            ' A non-numerical keystroke was pressed. 
        '            ' Set the flag to true and evaluate in KeyPress event.
        '            nonNumberEntered = True
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub txtTPHBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' Selasa, 20 Oct 2009, 17:38
        '' by Dadang Adi H
        '' Check for the flag being set in the KeyDown event.
        'If nonNumberEntered = True Then
        '    ' Stop the character from being entered into the control since it is non-numerical.
        '    e.Handled = True
        'Else

        If e.KeyChar = vbCr Then
            txtUnripeBorongan.Focus()
        End If
        'End If

    End Sub

    Private Sub txtUnripeBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnripeBorongan.Leave
        If txtUnripeBorongan.Text = "" Or txtUnripeBorongan.Text = "." Then
            txtUnripeBorongan.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidBorongan.Text
        'End If
    End Sub

    Private Sub txtUnripeBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnripeBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtUnripeBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnripeBorongan.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtUnderRipeBorongan.Focus()
            End If
        End If

    End Sub

    Private Sub txtUnderRipeBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnderRipeBorongan.Leave
        If txtUnderRipeBorongan.Text = "" Or txtUnderRipeBorongan.Text = "." Then
            txtUnderRipeBorongan.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidBorongan.Text
        'End If
    End Sub

    Private Sub txtUnderRipeBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnderRipeBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtUnderRipeBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnderRipeBorongan.KeyPress
        ' Selasa, 20 Oct 2009, 17:38
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtOverRipeBorongan.Focus()
            End If
        End If
    End Sub

    Private Sub txtOverRipeBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOverRipeBorongan.Leave
        If txtOverRipeBorongan.Text = "" Or txtOverRipeNormal.Text = "." Then
            txtOverRipeBorongan.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidBorongan.Text
        'End If
    End Sub

    Private Sub txtOverRipeBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOverRipeBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtOverRipeBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOverRipeBorongan.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtRipeBorongan.Focus()
            End If
        End If

    End Sub

    Private Sub txtRipeBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRipeBorongan.Leave
        If txtRipeBorongan.Text = "" Or txtRipeNormal.Text = "." Then
            txtRipeBorongan.Text = "0"
        End If

        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        'If (Paid < 0) Then
        '    MsgBox("Paid value cannot be zero or negative. Please check the value of Unripe, Under Ripe, Over Ripe and Ripe")
        '    Exit Sub
        'Else
        '    Paid = txtPaidBorongan.Text
        'End If
    End Sub

    Private Sub txtRipeBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRipeBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtRipeBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRipeBorongan.KeyPress
        ' Selasa, 20 Oct 2009, 17:38
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtLooseFruitBorongan.Focus()
            End If
        End If

    End Sub

    Private Sub txtLooseFruitBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLooseFruitBorongan.Leave
        If txtLooseFruitBorongan.Text = "" Or txtLooseFruitNormal.Text = "." Then
            txtLooseFruitBorongan.Text = "0"
        End If
    End Sub

    Private Sub txtLooseFruitBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLooseFruitBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            btnAdd.Focus()
            'call formula or not
        End If
    End Sub

    Private Sub txtLooseFruitBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLooseFruitBorongan.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub

    Private Sub txtHarvestedBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarvestedBorongan.Leave
        If txtHarvestedBorongan.Text = "" Or txtHarvestedBorongan.Text = "." Then
            txtHarvestedBorongan.Text = "0"
        End If
    End Sub

    Private Sub txtHarvestedBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHarvestedBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtHarvestedBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarvestedBorongan.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtDeductedBorongan.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub

    Private Sub txtDeductedBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeductedBorongan.Leave
        If txtDeductedBorongan.Text = "" Or txtDeductedBorongan.Text = "." Then
            txtDeductedBorongan.Text = "0"
        End If
    End Sub

    Private Sub txtDeductedBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeductedBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtDeductedBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeductedBorongan.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtPaidBorongan.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub

    Private Sub txtPaidBorongan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaidBorongan.Leave
        If txtPaidBorongan.Text = "" Or txtPaidNormal.Text = "." Then
            txtPaidBorongan.Text = "0"
        End If
    End Sub

    Private Sub txtPaidBorongan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaidBorongan.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtPaidBorongan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaidBorongan.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If

    End Sub
    'end Normal (_Leave, _KeyPress, _KeyDown)
    '----------------------------------------------------------------------

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        clearInputText()
    End Sub

    Private Sub btnTeamLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTeamLookup.Click

    End Sub

    'Private Sub txtStation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStation.Leave

    '    If txtStation.Text <> "" Then
    '        Dim DT As DataTable

    '        DT = DailyAttendanceWithTeam_DAL.CRStationSelect(txtStation.Text)

    '        If DT.Rows.Count = 0 Then

    '            txtStation.Text = String.Empty
    '            lblStationID.Text = String.Empty

    '            MessageBox.Show("Station not found.", "Information", MessageBoxButtons.OK, _
    '                MessageBoxIcon.Information)
    '            txtStation.Focus()

    '        ElseIf DT.Rows.Count >= 1 Then
    '            txtStation.Text = DT.Rows(0).Item("StationDescp").ToString()
    '            lblStationID.Text = DT.Rows(0).Item("StationID").ToString()

    '            txtTPHNormal.Focus()

    '        End If

    '    ElseIf txtStation.Text = "" Then
    '        txtStation.Text = String.Empty
    '        lblStationID.Text = String.Empty
    '        'txtBlock.Focus()
    '    End If

    'End Sub

    Private Sub txtBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBlock.Leave


        If txtBlock.Text <> "" Then
            Dim DT As DataTable

            DT = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(txtBlock.Text)

            If DT.Rows.Count = 0 Then

                txtdiv.Text = String.Empty
                txtYOP.Text = String.Empty
                lblBlockID.Text = String.Empty
                lblYOPID.Text = String.Empty
                lblDivID.Text = String.Empty
                lblBlockStatus.Text = String.Empty

                MessageBox.Show("Sub Block not found.", "Information", MessageBoxButtons.OK, _
                    MessageBoxIcon.Information)
                txtBlock.Focus()

            ElseIf DT.Rows.Count >= 1 Then
                txtBlock.Text = DT.Rows(0).Item("BlockName").ToString()
                lblBlockID.Text = DT.Rows(0).Item("BlockID").ToString()
                lblBlockStatus.Text = DT.Rows(0).Item("BlockStatus").ToString()

                txtdiv.Text = DT.Rows(0).Item("DIVName").ToString()
                lblDivID.Text = DT.Rows(0).Item("DivID").ToString()

                txtYOP.Text = DT.Rows(0).Item("YOP").ToString()
                lblYOPID.Text = DT.Rows(0).Item("YOPID").ToString()

                txtStation.Focus()

                Dim DT_PremiSetup As DataTable

                DT_PremiSetup = DailyReceiptionWithTeam_DAL.CRPremiSetupSelect(lblBlockID.Text, lblAttendanceSetupID.Text)
                dgPremi.DataSource = DT_PremiSetup

                If DT_PremiSetup.Rows.Count = 0 Then
                    MessageBox.Show("Premi Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btnAdd.Enabled = False
                Else
                    btnAdd.Enabled = True
                End If
                loadTPH()
                ' Rabu, 21 Oct 2009, 01:14
                ' Dapatkan PremiSpecialRateSetup
                Dim DT_PremiSpecialRateSetup As DataTable ' ini untuk Borongan
                DT_PremiSpecialRateSetup = DailyReceiptionWithTeam_DAL.CRPremiSpecialRateSetupSelect(lblBlockID.Text)

                If DT_PremiSpecialRateSetup.Rows.Count > 0 Then
                    If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerBunch") Then
                        txtRatePerBunch.Text = "0"
                    Else
                        txtRatePerBunch.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerBunch").ToString()
                    End If

                    If DT_PremiSpecialRateSetup.Rows(0).IsNull("RatePerLooseFruit") Then
                        txtRatePerLooseFruit.Text = "0"
                    Else
                        txtRatePerLooseFruit.Text = DT_PremiSpecialRateSetup.Rows(0).Item("RatePerLooseFruit").ToString()
                    End If

                Else
                    MessageBox.Show("Premi Special Rate has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        ElseIf txtBlock.Text = "" Then
            txtdiv.Text = String.Empty
            txtYOP.Text = String.Empty
            lblBlockID.Text = String.Empty
            lblYOPID.Text = String.Empty
            lblDivID.Text = String.Empty
            lblBlockStatus.Text = String.Empty
            'txtBlock.Focus()
        End If
    End Sub

    Private Sub txtNDiscardedCrop_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNDiscardedCrop.KeyDown
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtNDiscardedCrop_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtNDiscardedCrop.KeyPress
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                Me.txtNDendaLain.Focus()
                'btnAdd.Focus()

            End If
        End If
    End Sub

    Private Sub txtNDiscardedCrop_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtNDiscardedCrop.Leave
        If txtNDiscardedCrop.Text = "" Or txtNDiscardedCrop.Text = "." Then
            txtNDiscardedCrop.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text
    End Sub

    Private Sub txtBDiscardedCrop_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtBDiscardedCrop.KeyDown
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtBDiscardedCrop_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtBDiscardedCrop.KeyPress
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtBDendaLain.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If
    End Sub

    Private Sub txtBDiscardedCrop_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtBDiscardedCrop.Leave
        If txtBDiscardedCrop.Text = "" Or txtBDiscardedCrop.Text = "." Then
            txtBDiscardedCrop.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text
    End Sub

    Private Sub txtHa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHa.KeyDown
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtHa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHa.KeyPress
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If
    End Sub

    Private Sub txtHa_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHa.Leave
        If txtHa.Text = "" Or txtHa.Text = "." Then
            txtHa.Text = "0"
        End If
    End Sub

    Private Sub loadTPH()
        Dim dsLoadTPH As DataTable

        dsLoadTPH = DailyReceiptionWithTeam_DAL.loadTPH(lblBlockID.Text)
        Dim dr As DataRow
        dr = dsLoadTPH.NewRow()
        dr("id") = 0
        dr("TPH") = "- Select TPH -"
        dsLoadTPH.Rows.InsertAt(dr, 0)

        If lblBlockID.Text <> String.Empty Then
            If rbNormal.Checked Then

                cmbTphNormal.DataSource = dsLoadTPH
                cmbTphNormal.DisplayMember = "TPH"
                cmbTphNormal.ValueMember = "id"

                cmbTphNormal.SelectedIndex = 0
            Else
                cmbTPHBorongan.DataSource = dsLoadTPH
                cmbTPHBorongan.DisplayMember = "TPH"
                cmbTPHBorongan.ValueMember = "id"

                cmbTPHBorongan.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub loadHa()
        Dim dsLoadHa As DataTable
        If lblBlockID.Text <> String.Empty Then
            If rbNormal.Checked Then
                dsLoadHa = DailyReceiptionWithTeam_DAL.loadHa(lblBlockID.Text, cmbTphNormal.Text)
                If dsLoadHa.Rows.Count > 0 Then
                    txtHa.Text = dsLoadHa.Rows(0).Item("Ha").ToString()
                End If
            Else
                dsLoadHa = DailyReceiptionWithTeam_DAL.loadHa(lblBlockID.Text, cmbTPHBorongan.Text)
                If dsLoadHa.Rows.Count > 0 Then
                    txtHa.Text = dsLoadHa.Rows(0).Item("Ha").ToString()
                End If
            End If
        End If



    End Sub

    Private Sub cmbTph_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTphNormal.SelectedIndexChanged, cmbTPHBorongan.SelectedIndexChanged
        loadHa()
    End Sub

    Private Sub txtNDendaLain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNDendaLain.KeyDown
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtNDendaLain_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNDendaLain.KeyPress
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If
    End Sub

    Private Sub txtNDendaLain_Leave(sender As Object, e As System.EventArgs) Handles txtNDendaLain.Leave
        If txtNDiscardedCrop.Text = "" Or txtNDiscardedCrop.Text = "." Then
            txtNDiscardedCrop.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)

        Harvested = txtHarvestedNormal.Text
        Deducted = txtDeductedNormal.Text
        Paid = txtPaidNormal.Text
    End Sub


    Private Sub txtNDiscardedCrop_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNDiscardedCrop.TextChanged

    End Sub

    Private Sub txtBDendaLain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBDendaLain.KeyDown
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtBDendaLain_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBDendaLain.KeyPress
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
                'btnAdd.Focus()
                ' txtLooseFruitNormal.Focus()
                ' call function formulaHarvested(formulaJanjang), formulaDeducted(formulaBorongan) and formulaPaid(formulaBorongan)
            End If
        End If
    End Sub

    Private Sub txtBDendaLain_Leave(sender As Object, e As System.EventArgs) Handles txtBDendaLain.Leave
        If txtBDendaLain.Text = "" Or txtBDendaLain.Text = "." Then
            txtBDendaLain.Text = "0"
        End If
        formulaHarvested(Harvested)
        formulaDeducted(Deducted)
        formulaPaid(Paid)
    End Sub

    End Class