'---------------------------------------
'
' Programmer: Dadang Adi Hendradi
'
' Created   : Senin, 14 Sep 2009, 20:33
'
'//
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports System.Text
Imports CheckRoll_DAL
Imports Common_PPT

Public Class DailyActivityDistributionWithTeam



    Private DT_DailyActivityDistributionWithTeam As DataTable

    Private DailyActivityDistributionWithTeamTableAdapter As DailyActivityDistributionWithTeam_DAL = _
        New DailyActivityDistributionWithTeam_DAL()

    Private dTotalHK As Decimal = 0
    Private dBalanceTotalHK As Decimal = 0
    Private dBalanceTotalOT As Decimal = 0
    Private dSumHK As Decimal = 0
    Private dSumOT As Decimal = 0
    Private dTotalOT As Decimal = 0

    Private DT_TEAMVIEW As DataTable

    ' Selasa, 22 Sep 2009, 00:04
    Private GangName As String = String.Empty
    Private GangMasterID As String = String.Empty
    Private strDailyTeamActivityID As String = String.Empty
    Private strEmpCategory As String = String.Empty

    Private rowIndex_dgvDailyActivity As Integer = 0

    Private DailyAttendanceWithTeamTableAdapter As New DailyAttendanceWithTeam_DAL()
    Private DT_DailyAttendanceWithTeam As DataTable

    Private FirstLoad As Boolean = True 'Jum'at, 2 Oct 2009, 13:19

    ' Selasa, 20 Oct 2009, 12:04
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False

    Private CallFromDailyAttendance As Boolean = False

    Private MandorEmpName As String
    Private KraniEmpName As String
    Private Activity As String
    Private ADADate As Date

    ' Selasa, 27 Oct 2009, 10:15
    Private ActiveMonthLogin As Integer
    Private ActiveYearLogin As Integer
    Public isDecimal As Boolean
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")

    Public psVHID As String = String.Empty
    Public psCategoryID As String = String.Empty
    Public psVHCategoryType As String = String.Empty
    Public psVHDetailCostCodeID As String = String.Empty


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

    Private Function IsDailyActivityDistributionWithTeamIsModified() As Boolean
        ' Ahad, 15 Nov 2009, 19:43
        Dim ModifiedRow As DataRow() = DT_DailyActivityDistributionWithTeam.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_DailyActivityDistributionWithTeam.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_DailyActivityDistributionWithTeam.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False

        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        Return Modified
    End Function

    Private Sub DailyActivityDistributionWithTeam_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Kamis, 01 Oct 2009, 14:15
        Dim ModifiedRow As DataRow() = DT_DailyActivityDistributionWithTeam.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_DailyActivityDistributionWithTeam.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_DailyActivityDistributionWithTeam.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False


        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        If Modified Then
            If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                            "Do you want to save data..", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                SaveDailyActivityDistributionWithTeam()
            End If
        End If

        txtContractNo.TabIndex = 0
        txtContractNo.Focus()
        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M244" Then
            Me.DailyAttendanceShow()
        End If






    End Sub
    Private Sub DailyAttendanceShow()
        Try
            Dim DailyAttendanceWithTeamForm As DailyAttendanceWithTeam = New DailyAttendanceWithTeam()

            Dim dtpRDate As DateTime = Me.dtpDADate.Value
            Dim TeamName As String = Me.txtTeam.Text
            Dim TotalOT As String = Me.txtTotalOT.Text
            Dim DailyTeamActivityID As String = strDailyTeamActivityID
            Dim EmpCategory As String = strEmpCategory
            Dim Activity As String = Me.lblActivity.Text
            Dim GangMasterID As String = Me.lblGangMasterID.Text
            Dim MandoreID As String = Me.lblMandoreID.Text
            Dim KraniID As String = Me.lblKraniID.Text
            Dim MandorName As String = Me.lblMandorEmpName.Text
            Dim KraniName As String = Me.lblKraniEmpName.Text
         
            DailyAttendanceWithTeamForm.ShowFromActivity( _
          dtpRDate, _
          TeamName, _
          TotalOT, _
          DailyTeamActivityID, _
          Activity, _
         GangMasterID, _
         MandoreID, _
         KraniID, _
         MandorName, _
         KraniName, _
           EmpCategory, _
         Me.MdiParent)

            DailyAttendanceWithTeamForm.dtpRDate.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ActivityDistribution_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.lblLanguange.Text = "Indonesia" Then
            ApplyLocale("de-De")
        ElseIf Me.lblLanguange.Text = "English" Then
            ApplyLocale("en-Us")
        End If

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()

        'Senin, 14 Sep 2009, 20:35
        Dim DT As DataTable
        DT = DailyAttendanceWithTeam_DAL.EstateSelect()

        If (DT.Rows.Count > 0) Then
            Dim TypeEstate As String = ""

            TypeEstate = DT.Rows(0).Item("Type")

            If TypeEstate = "Estate" Then
                ' berarti ini typenya Estate bukan MILL (Perdana Estate atau Cakra Estate)
                txtSubBlock.Enabled = True
                btnSubBlockLookup.Enabled = True

                txtStation.Enabled = False
                btnStationLookup.Enabled = False
                'GroupBoxEstateInput.Enabled = True

            ElseIf TypeEstate = "Mill" Then
                ' berarti ini typenya MILL bukan Estate (Cakra Oil Mill)
                txtSubBlock.Enabled = False
                btnSubBlockLookup.Enabled = False

                txtStation.Enabled = True
                btnStationLookup.Enabled = True
                'GroupBoxEstateInput.Enabled = False
            End If
        End If


        ' Senin, 26 Oct 2009, 15:49
        ' DT_UOM dimatikan, karena tdk jadi dipakai
        Dim DT_UOM As DataTable = DailyActivityDistributionWithTeam_DAL.Checkroll_UOMSelect()
        cboUOM.DataSource = DT_UOM
        cboUOM.DisplayMember = "UOM"
        cboUOM.ValueMember = "UOMID"
        cboUOM.SelectedIndex = -1
        lblUOMID.Text = ""


        ' Jum'at, 02 Oct 2009, 14:08
        lblMessage.Text = String.Empty

        ' Senin, 28 Sep 2009, 21:19
        'If (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth) Then
        '    MessageBox.Show("Your  transaction has been closed, only View Report screen will be enabled in the future", _
        '                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        'ElseIf GlobalPPT.IntLoginMonth > GlobalPPT.IntActiveMonth Then

        '    MessageBox.Show("Your Transaction has not been closed yet, in the future this screen will be disabled", _
        '                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        txtHK.Text = 0
        txtOT.Text = 0
        txtHa.Text = 0

        If CallFromDailyAttendance = False Then
            btnBack.Visible = False
            btnResetAll.Enabled = True
        ElseIf CallFromDailyAttendance = True Then

            'Dim ctrl As Control
            'ctrl = CType(tcAvtivity.TabPages(1), Control)
            'ctrl.Enabled = False
            'btnResetAll.Enabled = False
        End If

        clearInput()

        Me.lblActivity.Text = Me.Activity
        Me.lblMandorEmpName.Text = Me.MandorEmpName
        Me.lblKraniEmpName.Text = Me.KraniEmpName
        Me.lblGangMasterID.Text = Me.GangMasterID

        dtpDADate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDADate.MaxDate = GlobalPPT.FiscalYearToDate

        dtpDistbDateView.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDistbDateView.MaxDate = GlobalPPT.FiscalYearToDate

        If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
            If CallFromDailyAttendance = False Then
                dtpDADate.Value = Now()
            Else
                dtpDADate.Value = Me.ADADate 'Now()
            End If

            dtpDistbDateView.Value = Now()
        End If

        ' Selasa, 15 Sep 2009, 23:17
        ShowDailyActivityDistribution()

        ' Selasa, 27 Oct 2009, 10:28
        Dim d As Date
        ActiveMonthLogin = GlobalPPT.IntActiveMonth 'Convert.ToInt32(GlobalPPT.strLoginMonth.Substring(0, GlobalPPT.strLoginMonth.IndexOf("-")))
        ActiveYearLogin = GlobalPPT.intActiveYear

        d = New Date(ActiveYearLogin, ActiveMonthLogin, 1)

        DT_TEAMVIEW = DailyActivityDistributionWithTeam_DAL.CRDailyActivityDistributionWithTeamView( _
                    True, "", "", "", d)

        dgvDailyActivityDistributionView.DataSource = DT_TEAMVIEW
        'dgvDailyActivityDistributionView.Columns("ActiveMonthYearID").Visible = False
        'dgvDailyActivityDistributionView.Columns("GangMasterIDColumn").Visible = False

        If String.IsNullOrEmpty(GangName) Or String.IsNullOrEmpty(GangMasterID) Then
            tcAvtivity.SelectedTab = tabView
        Else
            tcAvtivity.SelectedTab = tabInput
            HitungTotalHK()
            HitungTotalOT() ' Jum'at, 02 Oct 2009, 02:47
        End If

        If DT_DailyActivityDistributionWithTeam.Rows.Count > 0 Then
            btnEditOrUpdate.Enabled = True
            btnReset.Enabled = True
            btnMaterial.Enabled = True
        Else
            btnEditOrUpdate.Enabled = False
            btnReset.Enabled = False
            btnMaterial.Enabled = False
        End If
        dgvActivity.DefaultCellStyle.BackColor = Color.White
        dgvDailyActivityDistributionView.DefaultCellStyle.BackColor = Color.White

        SetTAnalysisDefaultValue()
        txtTeamNameView.Focus()

    End Sub

    Private Sub SetTAnalysisDefaultValue()
        ' Selasa, 17 Nov 2009, 17:37
        Dim DT As DataTable

        ' Set default value utk TAnalysis 0 yaitu EstateCode nya
        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
             "", "T0", GlobalPPT.strEstateCode)

        txtT0.Text = DT.Rows(0).Item("TValue").ToString()
        lblTAnalysisID_TO.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        lblTAnalysisDescp_T0.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()


        ' Set default value utk TAnalysis 2 yaitu Type of work KHT-W01, KHL-W02
        'DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
        '     "", "T2", "W02")

        'txtT2.Text = DT.Rows(0).Item("TValue").ToString()
        'lblTAnalysisID_T2.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        'lblTAnalysisDescp_T2.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

    End Sub

    Private Sub ManagedgvActivityColumn()
        ' Sabtu, 03 Oct 2009, 01:08
        'dgvActivity.Columns("DistbDateColumn").DisplayIndex = 0
        'dgvActivity.Columns("TeamColumn").DisplayIndex = 1
        'dgvActivity.Columns("TotalHK").DisplayIndex = 2
        'dgvActivity.Columns("TotalOT").DisplayIndex = 3
        'dgvActivity.Columns("ContractNoColumn").DisplayIndex = 4

        'dgvActivity.Columns("COADescpColumn").DisplayIndex = 16
        'dgvActivity.Columns("DIVColumn").DisplayIndex = 6
        'dgvActivity.Columns("YOPColumn").DisplayIndex = 7
        'dgvActivity.Columns("SubBlockColumn").DisplayIndex = 8
        'dgvActivity.Columns("StationDescpColumn").DisplayIndex = 9

        'dgvActivity.Columns("DAMandaysColumn").DisplayIndex = 5
        'dgvActivity.Columns("DAOTColumn").DisplayIndex = 6

        'dgvActivity.Columns("TAnalysisCode_T0Column").DisplayIndex = 11
        'dgvActivity.Columns("TAnalysisCode_T1Column").DisplayIndex = 12
        'dgvActivity.Columns("TAnalysisCode_T2Column").DisplayIndex = 13
        'dgvActivity.Columns("TAnalysisCode_T3Column").DisplayIndex = 14
        'dgvActivity.Columns("TAnalysisCode_T4Column").DisplayIndex = 15

        dgvActivity.Columns("DailyDistributionID").Visible = False
        dgvActivity.Columns("DailyReceiptionID").Visible = False
        dgvActivity.Columns("ActiveMonthYearID").Visible = False
        dgvActivity.Columns("GangMasterID").Visible = False
        dgvActivity.Columns("COAID").Visible = False
        'Jum'at, 20 Nov 2009, 18:12
        dgvActivity.Columns("OvertimeCOAID").Visible = False
        'END Jum'at, 20 Nov 2009, 18:12

        dgvActivity.Columns("EstateID").Visible = False
        dgvActivity.Columns("EstateCode").Visible = False
        dgvActivity.Columns("DivID").Visible = False
        dgvActivity.Columns("YOPID").Visible = False
        dgvActivity.Columns("BlockID").Visible = False
        dgvActivity.Columns("CreatedBy").Visible = False
        dgvActivity.Columns("CreatedOn").Visible = False
        dgvActivity.Columns("ModifiedBy").Visible = False
        dgvActivity.Columns("ModifiedOn").Visible = False
        dgvActivity.Columns("ContractID").Visible = False
        dgvActivity.Columns("StationID").Visible = False

        dgvActivity.Columns("UOM").Visible = True
        dgvActivity.Columns("UOMID").Visible = False


        '' Senin, 26 Oct 2009, 21:11
        ''dgvActivity.Columns("COACode").Visible = False

        dgvActivity.Columns("T0").Visible = False ' Inilah Nilai2 yg dipake
        dgvActivity.Columns("T1").Visible = False
        dgvActivity.Columns("T2").Visible = False
        dgvActivity.Columns("T3").Visible = False
        dgvActivity.Columns("T4").Visible = False

        dgvActivity.Columns("TAnalysisDescp_T0").Visible = False
        dgvActivity.Columns("TAnalysisDescp_T1").Visible = False
        dgvActivity.Columns("TAnalysisDescp_T2").Visible = False
        dgvActivity.Columns("TAnalysisDescp_T3").Visible = False
        dgvActivity.Columns("TAnalysisDescp_T4").Visible = False
        dgvActivity.Columns("MachineID").Visible = False
 
    End Sub

    Public Overloads Sub Show(ByVal DADate As Date, ByVal TeamName As String, _
                              ByVal Activity As String, _
                              ByVal GangMasterID As String, _
                              ByVal MandorEmpName As String, _
                              ByVal KraniEmpName As String, _
                              ByVal DailyTeamActivityID As String, _
                              ByVal EmpCategory As String, _
                              ByVal MandoreID As String, _
                              ByVal KraniID As String, _
                              ByVal TOTALHK As String, _
                              ByVal parent As IWin32Window)

        Me.lblKraniID.Text = KraniID
        Me.lblMandoreID.Text = MandoreID
        strDailyTeamActivityID = DailyTeamActivityID
        strEmpCategory = EmpCategory

        Me.dtpDADate.Value = DADate
        Me.ADADate = DADate
        Me.GangName = TeamName
        Me.Activity = Activity
        Me.GangMasterID = GangMasterID
        ' Senin, 26 Oct 2009, 21:38
        Me.MandorEmpName = MandorEmpName
        Me.KraniEmpName = KraniEmpName

        txtTotalHK.Text = TOTALHK
        Me.lblMandorEmpName.Text = MandorEmpName
        Me.lblKraniEmpName.Text = KraniEmpName

        Me.txtTeam.Text = Me.GangName
        Me.lblActivity.Text = Activity
        Me.lblGangMasterID.Text = Me.GangMasterID

        Me.dtpDADate.Enabled = False
        Me.txtTeam.Enabled = False
        Me.BtnTeamLookup.Enabled = False
        'Me.lblGangMasterID.Enabled = False
        tcAvtivity.TabPages.Remove(tabView)
        CallFromDailyAttendance = True
        Me.MdiParent = parent
        Me.Dock = DockStyle.Fill
        Me.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim childCR As New MaterialsWithTeam()

        If dgvActivity.Rows.Count > 0 Then
            If dgvActivity.CurrentCell IsNot Nothing Then

                Dim rowIndex As Integer = dgvActivity.CurrentCell.RowIndex

                childCR.MdiParent = MdiParent
                childCR.Dock = DockStyle.Fill
                childCR.dtpDate.Value = Me.dtpDADate.Value

                childCR.lstringctrl = "1" 'untuk TEAM
                childCR.lcoaCode = dgvActivity.Rows(rowIndex).Cells("COACode").Value.ToString()
                childCR.lcoadescp = dgvActivity.Rows(rowIndex).Cells("COADescpColumn").Value.ToString()
                childCR.lcoaid = dgvActivity.Rows(rowIndex).Cells("COAID").Value.ToString()
                childCR.ltanggal = dtpDADate.Value

                childCR.DailyDistributionID = dgvActivity.Rows(rowIndex).Cells("DailyDistributionID").Value.ToString()

                childCR.LEmpName = dgvActivity.Rows(rowIndex).Cells("TeamColumn").Value.ToString()
                childCR.LEmpId = dgvActivity.Rows(rowIndex).Cells("GangMasterID").Value.ToString()
                childCR.Show()

            Else
                MessageBox.Show("No Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            MessageBox.Show("No Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub


    Private Sub mtnhCalDateSearch_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs)
        Dim _Date As String
        _Date = e.Start.ToShortDateString()

    End Sub

    Private Sub btnSearchActCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        COALookup.Show()
    End Sub

    Private Sub btnSearchSubAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        COALookup.Show()
    End Sub

    Private Sub btnSearchCostType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        COALookup.Show()
    End Sub

    Private Sub btnsearchCostCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        COALookup.Show()
    End Sub

    Private Sub btnSearchDetailCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        COALookup.Show()
    End Sub

    Private Sub btnSearchContractNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchContractNumber.Click

        ContractLookup.Show()
    End Sub

    Private Sub BtnTeamLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTeamLookup.Click
        ' Senin, 14 Sep 2008, 19:04
        Dim TeamLookupForm As TeamLookUps = New TeamLookUps()

        TeamLookupForm.DDate = dtpDADate.Value
        TeamLookupForm.ShowDialog()

        If TeamLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            dtpDADate.Enabled = False
            Me.txtTeam.Text = TeamLookupForm.GangName
            Me.lblGangMasterID.Text = TeamLookupForm.GangMasterID

            Me.lblMandorEmpName.Text = TeamLookupForm.MandorEmpName
            Me.lblKraniEmpName.Text = TeamLookupForm.KraniEmpName

            Me.lblMandoreID.Text = TeamLookupForm.MandorEmpCode
            Me.lblKraniID.Text = TeamLookupForm.KraniEmpCode

            Me.lblActivity.Text = TeamLookupForm.Activity
            If lblActivity.Text.Trim = "PANEN" Then
                MessageBox.Show("LAIN Activities only " + vbCrLf + _
                  "You can not distribute for PANEN Activities", _
                  "Information", _
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnAdd.Enabled = False
            Else
                btnAdd.Enabled = True
            End If
            ShowDailyActivityDistribution()
            HitungTotalHK()
            HitungTotalOT()
            If lblActivity.Text.Trim = "LAIN" Then
                If Val(txtBalanceTotalHK.Text) = 0 And Val(txtBalanceTotalOT.Text) = 0 Then
                    btnAdd.Enabled = False
                Else
                    btnAdd.Enabled = True
                End If
            End If

            txtSubBlock.Focus()
        Else
            dtpDADate.Enabled = True
        End If

    End Sub

    Private Sub ShowDailyActivityDistribution()
        ' Selasa, 15 Sep 2009, 04:05

        ' Jum'at, 02 oct 2009
        ' Check dulu di DailyAttendance
        ' pada saat form dibuka pertama kali FirstLoad = True

        Dim msg As String = String.Empty
        Dim lSaveUpDate As String = ""
        lSaveUpDate = DailyAttendanceWithTeam.lSaveUpdate

        If FirstLoad = False Then
            DT_DailyAttendanceWithTeam = DailyAttendanceWithTeamTableAdapter.DailyAttendanceWithTeamSelect( _
                Me.txtTeam.Text, dtpDADate.Value, lSaveUpDate)
            If DT_DailyAttendanceWithTeam.Rows.Count = 0 Then

                msg = "Your Team has not yet been registered in Daily Attendance, Please key in data on Daily Attendance Screen with Team " + _
                    "for date " + dtpDADate.Value().ToString("dd/MM/yyy") + vbCrLf + _
                    "So Daily Activity cannot be process"
            End If

        End If

        If FirstLoad Then
            FirstLoad = False
        End If

        lblMessage.Text = msg

        DT_DailyActivityDistributionWithTeam = _
        DailyActivityDistributionWithTeam_DAL.DailyActivityDistributionWithTeamSelect( _
            Me.txtTeam.Text, dtpDADate.Value)

        'Dim ds As New DataSet
        'ds = DT_DailyActivityDistributionWithTeam.DataSet

        dgvActivity.DataSource = DT_DailyActivityDistributionWithTeam
        'dgvActivity.DataSource = ds
        ManagedgvActivityColumn()


        If DT_DailyActivityDistributionWithTeam.Rows.Count > 0 Then
            btnEditOrUpdate.Enabled = True
            btnReset.Enabled = True
            btnMaterial.Enabled = True
        Else
            btnEditOrUpdate.Enabled = False
            btnReset.Enabled = False
            btnMaterial.Enabled = False
        End If

    End Sub

    Private Sub HitungTotalHK()
        ' Selasa, 15 Sep 2009, 03:49
        dTotalHK = 0
        dTotalHK = DailyAttendanceWithTeam_DAL.CRDailyAttendanceWithTeamSumHK( _
                Me.txtTeam.Text, dtpDADate.Value)

        txtTotalHK.Text = dTotalHK

        If DT_DailyActivityDistributionWithTeam.Rows.Count = 0 Then
            dBalanceTotalHK = dTotalHK
            txtBalanceTotalHK.Text = dTotalHK.ToString()
        ElseIf DT_DailyActivityDistributionWithTeam.Rows.Count > 0 Then
            dSumHK = SumHKGrid()
            dBalanceTotalHK = dTotalHK - dSumHK
            txtBalanceTotalHK.Text = dBalanceTotalHK.ToString()
        End If

    End Sub

    Private Sub HitungTotalOT()
        ' Jum'at, 02 Oct 2009, 02:29
        dTotalOT = 0
        dTotalOT = DailyAttendanceWithTeam_DAL.CRDailyAttendanceWithTeamSumOT( _
            GlobalPPT.strEstateID, txtTeam.Text, dtpDADate.Value)

        txtTotalOT.Text = dTotalOT.ToString()

        If DT_DailyActivityDistributionWithTeam.Rows.Count = 0 Then
            dBalanceTotalOT = dTotalOT
            txtBalanceTotalOT.Text = dTotalOT.ToString()
        Else
            dSumOT = SumOTGrid()
            dBalanceTotalOT = dTotalOT - dSumOT
            txtBalanceTotalOT.Text = dBalanceTotalOT.ToString()
        End If
    End Sub

    Private Function SumHKGrid() As Decimal
        ' Selasa, 22 Sep 2009, 05:06
        Dim dSum As Decimal = 0
        'Dim i As Integer
        Dim dr As DataRow

        ' Senin, 26 Oct 2009, 23:46
        'Dim cm As CurrencyManager = CType(Me.BindingContext(dgvActivity.DataSource, dgvActivity.DataMember), CurrencyManager)

        'For i = 0 To cm.Count - 1  'DT_DailyActivityDistributionWithTeam.Rows.Count - 1
        '    dr = DT_DailyActivityDistributionWithTeam.Rows(i)

        '    If dr.RowState <> DataRowState.Deleted Then

        '        If dr.Item("Mandays") IsNot System.DBNull.Value Then
        '            dSum = dSum + dr.Item("Mandays")
        '        Else
        '            dSum = dSum + 0
        '        End If
        '    End If

        'Next

        For Each dr In DT_DailyActivityDistributionWithTeam.Rows
            If dr.RowState <> DataRowState.Deleted Then

                If dr.Item("Mandays") IsNot System.DBNull.Value Then
                    dSum = dSum + dr.Item("Mandays")
                Else
                    dSum = dSum + 0
                End If
            End If

        Next

        Return dSum
    End Function

    Private Function SumOTGrid() As Decimal
        Dim dSum As Decimal = 0
        'Dim i As Integer
        Dim dr As DataRow

        ' Senin, 26 Oct 2009, 23:46
        'Dim cm As CurrencyManager = CType(Me.BindingContext(dgvActivity.DataSource, dgvActivity.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)

        'For i = 0 To dv.Count - 1 'DT_DailyActivityDistributionWithTeam.Rows.Count - 1
        '    dr = DT_DailyActivityDistributionWithTeam.Rows(i)

        '    If dr.RowState <> DataRowState.Deleted Then

        '        If dr.Item("OT") IsNot System.DBNull.Value Then
        '            dSum = dSum + dr.Item("OT")
        '        Else
        '            dSum = dSum + 0
        '        End If

        '    End If

        'Next

        For Each dr In DT_DailyActivityDistributionWithTeam.Rows
            If dr.RowState <> DataRowState.Deleted Then

                If dr.Item("OT") IsNot System.DBNull.Value Then
                    dSum = dSum + dr.Item("OT")
                Else
                    dSum = dSum + 0
                End If

            End If

        Next

        Return dSum
    End Function


    Private Function SumHKGridMinusCurrentEdit() As Decimal
        ' Selasa, 22 Sep 2009, 05:01
        Dim dSum As Decimal = 0

        Dim i As Integer
        Dim dr As DataRow
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvActivity.DataSource, dgvActivity.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)

        'For i = 0 To DT_DailyActivityDistributionWithTeam.Rows.Count - 1
        '    If i <> rowIndex_dgvDailyActivity Then

        '        If dgvActivity.Rows(i).Cells("DAMandaysColumn").Value IsNot System.DBNull.Value Then
        '            dSum = dSum + FormatNumber(Val(dgvActivity.Rows(i).Cells("DAMandaysColumn").Value.ToString()), 2)
        '        Else
        '            dSum = dSum + 0
        '        End If

        '    End If
        'Next

        For i = 0 To cm.Count - 1 'DT_DailyActivityDistributionWithTeam.Rows.Count - 1
            dr = DT_DailyActivityDistributionWithTeam.Rows(i)

            If i <> cm.Position AndAlso dr.RowState <> DataRowState.Deleted Then

                If DT_DailyActivityDistributionWithTeam.Rows(i).Item("Mandays") IsNot System.DBNull.Value Then
                    dSum = dSum + CType(DT_DailyActivityDistributionWithTeam.Rows(i).Item("Mandays"), Decimal)
                Else
                    dSum = dSum + 0
                End If

            End If
        Next

        Return dSum

    End Function

    Private Function SumOTGridMinusCurrentEdit() As Decimal
        ' Jum'at, 02 Oct 2009, 14:49
        Dim dSum As Decimal = 0

        Dim i As Integer
        Dim dr As DataRow
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvActivity.DataSource, dgvActivity.DataMember), CurrencyManager)

        'For i = 0 To dgvActivity.Rows.Count - 1

        '    If i <> rowIndex_dgvDailyActivity Then
        '        If dgvActivity.Rows(i).Cells("DAOTColumn").Value IsNot System.DBNull.Value Then
        '            dSum = dSum + FormatNumber(Val(dgvActivity.Rows(i).Cells("DAOTColumn").Value.ToString()), 2)
        '        Else
        '            dSum = dSum + 0
        '        End If
        '    End If

        'Next

        For i = 0 To cm.Count - 1 'DT_DailyActivityDistributionWithTeam.Rows.Count - 1
            dr = DT_DailyActivityDistributionWithTeam.Rows(i)

            If i <> cm.Position AndAlso dr.RowState <> DataRowState.Deleted Then
                If DT_DailyActivityDistributionWithTeam.Rows(i).Item("OT") IsNot System.DBNull.Value Then
                    dSum = dSum + CType(DT_DailyActivityDistributionWithTeam.Rows(i).Item("OT"), Decimal)
                Else
                    dSum = dSum + 0
                End If
            End If

        Next

        Return dSum
    End Function

    Private Sub btnSubBlockLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubBlockLookup.Click
        ' Senin, 14 Sep 2009, 20:28
        Dim SubBlockLookup_Form As SubBlockLookups
        Dim retValue As Windows.Forms.DialogResult
        SubBlockLookup_Form = New SubBlockLookups("")


        retValue = SubBlockLookup_Form.ShowDialog()

        If retValue = Windows.Forms.DialogResult.OK Then
            Me.txtSubBlock.Text = SubBlockLookup_Form.SubBlockName
            Me.lblBlockID.Text = SubBlockLookup_Form.SubBlockID

            Me.txtDIV.Text = SubBlockLookup_Form.DIV
            Me.lblDivID.Text = SubBlockLookup_Form.DivID

            Me.txtYOP.Text = SubBlockLookup_Form.YOP
            Me.lblYOPID.Text = SubBlockLookup_Form.YOPID

            Me.lblStatusBlock.Text = SubBlockLookup_Form.BlockStatus
            txtCOACode.Focus()

            ' Selasa, 17 Nov 2009, 18:09
            ' Set default value utk TAnalysis T1 yaitu YOP 
            Dim TValue As String
            Dim dtTA As DataTable
            'To be changed later

            'TValue = "F" + txtYOP.Text.Substring(txtYOP.Text.Length - 2, 2)
            TValue = "F95"
            Try

                dtTA = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T1", TValue)

                If dtTA.Rows.Count > 0 Then
                    txtT1.Text = dtTA.Rows(0).Item("TValue").ToString()
                    lblTAnalysisID_T1.Text = dtTA.Rows(0).Item("TAnalysisID").ToString()
                    lblTAnalysisDescp_T1.Text = dtTA.Rows(0).Item("TAnalysisDescp").ToString()
                Else
                    MessageBox.Show("No Record Fount at TAnalisis!")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Daily Activity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub btnStationLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStationLookup.Click
        ' Senin, 14 Sep 2009, 20:38
        Dim StationLookupForm As New StationLookup()

        If StationLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.lblStationDesc.Text = StationLookupForm.psStationDesc
            Me.txtStation.Text = StationLookupForm.psStationCode

            Me.lblStationID.Text = StationLookupForm.psStationId

        End If

    End Sub

    Private Sub txtHK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHK.KeyDown
        '' Selasa, 20 Oct 2009, 16:01
        ''
        '' Initialize the flag to false.
        'nonNumberEntered = False

        '' Determine whether the keystroke is a number from the top of the keyboard.
        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '    ' Determine whether the keystroke is a number from the keypad.
        '    If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '        ' Determine whether the keystroke is a backspace.
        '        If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
        '            ' A non-numerical keystroke was pressed. 
        '            ' Set the flag to true and evaluate in KeyPress event.
        '            nonNumberEntered = True
        '        End If
        '    End If
        'End If


        ' Senin, 14 Sep 2009, 20:41
        'If e.KeyCode = Keys.Enter Then
        '    If IsNumeric(txtHK.Text) = False Then
        '        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        '        txtHa.Text = ""
        '        txtHa.Focus()
        '    ElseIf IsNumeric(txtHK.Text) = True Then
        '        txtOT.Focus()
        '    End If
        'ElseIf e.KeyCode = Keys.Escape Then
        '    txtOT.Focus()
        'End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtCOACode.Text.Trim = String.Empty Or txtT0.Text.Trim = String.Empty Then
            MessageBox.Show("COA Code is required.")
            Return
        End If

        If txtOT.Text.Trim <> String.Empty Then
            If (Convert.ToDecimal(txtOT.Text.Trim)) > 0 Then
                If txtOvertimeCOACode.Text.Trim = String.Empty Then
                    MessageBox.Show("Overtime COA Code is required,when OT is Keyed in.")
                    Return
                End If
            End If
        End If

        If Me.txtVehicleCode.Text <> String.Empty Then
            If Me.txtDetailCostCode.Text = String.Empty Then
                MessageBox.Show("Detail Cost Code is required when Vehicle Code is Keyed in.")
                Return
            End If
        End If

        If (ConvertToDouble(txtBrondolan.Text) > 0 And txtSubBlock.Text.Trim = String.Empty) Then
            MessageBox.Show("Field No Selection is mandatory when Brondolan Value is Entered")
            Return
        End If


        If IsNumeric(txtOT.Text) And IsNumeric(txtHa.Text) And IsNumeric(txtHK.Text) And IsNumeric(txtBrondolan.Text) Then
        Else
            MessageBox.Show("Invalid Data in OverTime or Prestasi or HK or Brondolan")
            Return
        End If
        If btnAdd.Text = "&Add" Then

            'dtpDADate.Enabled = False
            'txtTeam.Enabled = False
            'BtnTeamLookup.Enabled = False

            'btnAdd.Enabled = False
            'btnReset.Enabled = True
            'btnSaveAll.Enabled = False
            'btnClose.Enabled = False
            'btnMaterial.Enabled = False

            'rowIndex_dgvDailyActivity = dgvActivity.CurrentCell.RowIndex
            'EditDailyActicityDistributionWithTeam()

            'dgvActivity.Enabled = False

            DoAdd()
            'btnAdd.Text = "&Update"

        ElseIf btnAdd.Text = "&Update" Then

            If UpdateDailyActicityDistributionWithTeam() = True Then

                If CallFromDailyAttendance = True Then
                    ' Kalo dipanggil dari Daily Attendance, maka lock semua
                    dtpDADate.Enabled = False
                    txtTeam.Enabled = False
                    BtnTeamLookup.Enabled = False
                    btnResetAll.Enabled = False

                Else
                    dtpDADate.Enabled = True
                    txtTeam.Enabled = True
                    BtnTeamLookup.Enabled = True
                    btnResetAll.Enabled = True

                End If

                btnReset.Enabled = False
                btnSaveAll.Enabled = True
                btnClose.Enabled = True
                btnMaterial.Enabled = True

                dgvActivity.Enabled = True

                clearInput()

                btnAdd.Text = "&Add"
            End If
        End If

        If Val(txtBalanceTotalHK.Text) = 0 And Val(txtBalanceTotalOT.Text) = 0.0 Then
            btnAdd.Enabled = False
            btnMaterial.Enabled = True
        Else
            btnAdd.Enabled = True
            btnMaterial.Enabled = False
        End If
        dtpDADate.Enabled = False
    End Sub
    'Added by nelson jun21-2010
    Private Function IsSubBlockAlreadyInGreadWithOutCurrentEdit() As Integer

        Dim rowIndex As Integer = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty
        Dim Activity As String = String.Empty
        If txtSubBlock.Text = "" Then
            Return rowIndex
        End If
        Dim DT_Distribution As DataTable

        DT_Distribution = dgvActivity.DataSource

        For i As Int32 = 0 To DT_Distribution.Rows.Count - 1
            Dim row As DataRow = DT_Distribution.Rows(i)

            If i <> dgvActivity.CurrentCell.RowIndex Then

                If row.RowState <> DataRowState.Deleted Then
                    'If Not row.Item("BlockName") Is Nothing Then
                    If row.Item("BlockName").ToString <> "" Then
                        BlockNameInGrid = row.Item("BlockName")
                        DivisionInGrid = row.Item("DivName")
                        YOPInGrid = row.Item("YOP")
                    End If


                    Activity = row.Item("COACode")
                    'End If

                    If BlockNameInGrid = txtSubBlock.Text AndAlso DivisionInGrid = txtDIV.Text AndAlso YOPInGrid = txtYOP.Text AndAlso Activity = txtCOACode.Text Then
                        rowIndex = i
                        Exit For
                    End If
                End If

            End If
        Next

        Return rowIndex
    End Function
    'end
    Private Function IsSubBlockAlreadyInGread() As Integer
        ' Kamis, 01 oct 2009, 15:44
        Dim rowIndex = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty
        ' Ahad, 15 Nov 2009, 20:27
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty
        Dim Activity As String = String.Empty

        If txtSubBlock.Text = "" Then
            Return rowIndex
        End If

        'Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)
        'Dim dr As DataRow = dv.Item(cm.Position).Row
        Dim DT_Distribution As DataTable

        DT_Distribution = dgvActivity.DataSource

        For i As Int32 = 0 To DT_Distribution.Rows.Count - 1
            Dim row As DataRow = DT_Distribution.Rows(i)

            If row.RowState <> DataRowState.Deleted Then

                If Not IsDBNull(row.Item("BlockName")) Then
                    BlockNameInGrid = row.Item("BlockName")
                Else
                    BlockNameInGrid = String.Empty
                End If

                If Not IsDBNull(row.Item("DivName")) Then
                    DivisionInGrid = row.Item("DivName")
                Else
                    DivisionInGrid = String.Empty
                End If

                If Not IsDBNull(row.Item("YOP")) Then
                    YOPInGrid = row.Item("YOP")
                Else
                    YOPInGrid = String.Empty
                End If

                If Not IsDBNull(row.Item("COACode")) Then
                    Activity = row.Item("COACode")
                Else
                    Activity = String.Empty
                End If




                If BlockNameInGrid = txtSubBlock.Text AndAlso DivisionInGrid = txtDIV.Text AndAlso YOPInGrid = txtYOP.Text AndAlso Activity = txtCOACode.Text Then
                    rowIndex = i
                    Exit For
                End If
            End If
            'BlockNameInGrid = 
        Next

        Return rowIndex
    End Function
    Private Function DoAdd() As Boolean
        ' Selasa, 15 Sep 2009, 00:0
        Dim newRow As System.Data.DataRow
        Dim dHK As Decimal = 0
        'Dim dSumHK As Decimal = 0

        Dim dOT As Decimal = 0

        'Selasa, 15 Sep 2009, 23:22
        If lblCOAID.Text = String.Empty Or txtCOACode.Text = String.Empty Then
            MessageBox.Show("Please select Activity, before you can save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If txtT0.Text.Trim = String.Empty Then
            MessageBox.Show("Please select T0, before you can save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        'Added by nelson jun 21-2010
        If txtSubBlock.Text <> Nothing And txtCOACode.Text <> String.Empty Then


            If IsSubBlockAlreadyInGread() <> -1 Then
                MessageBox.Show("Field No Already in grid" + vbCrLf + _
                    "example: You can not add the similar Field No", _
                    "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If



        ElseIf txtCOACode.Text = String.Empty Or lblCOAID.Text = String.Empty Then
            MsgBox("Main Activity is mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            If txtCOACode.Enabled Then txtCOACode.Focus()
            Return False
        End If
        'end
        'Selasa, 15 Sep 2009, 15:47
        If btnSubBlockLookup.Enabled = True Then
            '
            ' Selasa, 28 Oct 20009, 21:16
            ' COMMENT with anand to see, if driver premi > 0 then sub block harus diisi
            ' jika driver premi = 0, maka Sub block tdk perlu diisi
            '

            ' Selasa, 17 Nov 2009, 00:52
            ' Sub Block tidak Mandatory
            'If lblBlockID.Text = String.Empty OrElse lblBlockID.Text = String.Empty OrElse txtSubBlock.Text = String.Empty Then
            '    MessageBox.Show("Please select the Sub Block, before you can save data.", _
            '                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Return False
            'End If
            ' Selasa, 17 Nov 2009, 00:52

        ElseIf btnStationLookup.Enabled = True Then
            If (lblStationID.Text = "" Or lblStationID.Text = "NOTVALID") And txtStation.Text <> String.Empty Then
                MessageBox.Show("Please select the station", _
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        ' Kamis, 19 Nov 2009, 17:33
        ' dibawah ini dinonaktifkan, sekarang HK bisa nol,
        ' soalnya satu orang dalam satu hari bisa punya kegiatan weeding atau dgn kata lain 1 HK
        ' setelah itu malamnya dia bisa punya kegiatan angkat buah tapi dia tdk punya HK lagi,
        ' tapi dia punya overtime saja
        '
        'If dTotalHK > 0 Then
        '    If txtHK.Text = "" Or txtHK.Text = "0" Then
        '        MessageBox.Show("You must input HK", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Return False
        '    End If
        'End If
        ' END Kamis, 19 Nov 2009, 17:33


        If txtTotalOT.Text = "" Or txtTotalOT.Text = "0" Then
            If txtOT.Text <> "" And txtOT.Text <> "0" Then
                MessageBox.Show("You cannot input Overtime, because TotalOT is 0", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        If (txtHK.Text <> "") Then
            dHK = txtHK.Text
        End If

        If txtOT.Text <> "" Then
            dOT = txtOT.Text
        End If

        If dHK = 0 And dOT = 0 Then
            MessageBox.Show("HK and OT cannot be zero", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        ''
        ' HK
        dSumHK = SumHKGrid()

        'If dHK + dSumHK > dTotalHK Or (dBalanceTotalHK = 0 AndAlso dTotalHK > 0) Then
        '    MessageBox.Show("HK cannot more then the Balance Total HK", "Information", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        'End If

        If dHK + dSumHK > dTotalHK Then
            MessageBox.Show("HK cannot more then the Balance Total HK", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If


        ''
        ' Jum'at, 02 Oct 2009, 14:26
        'OT
        dSumOT = SumOTGrid()
        If dOT + dSumOT > dTotalOT OrElse (dBalanceTotalOT = 0 AndAlso dTotalOT > 0 AndAlso dOT > 0) Then
            MessageBox.Show("OT cannot more then the balance Total OT", "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        dBalanceTotalHK = dTotalHK - (dHK + dSumHK)
        txtBalanceTotalHK.Text = dBalanceTotalHK.ToString()

        dBalanceTotalOT = dTotalOT - (dOT + dSumOT)
        txtBalanceTotalOT.Text = dBalanceTotalOT.ToString()

        'btnEditOrUpdate.Enabled = True

        newRow = DT_DailyActivityDistributionWithTeam.NewRow()

        newRow.Item("EstateID") = Global.Common_PPT.GlobalPPT.strEstateID
        newRow.Item("EstateCode") = Global.Common_PPT.GlobalPPT.strEstateCode
        'DailyReceiptionID tidak dipake utk yg punya team
        newRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        newRow.Item("DistbDate") = dtpDADate.Value
        newRow.Item("GangMasterID") = lblGangMasterID.Text

        If txtTotalHK.Text = "" Or txtTotalHK.Text = "0" Then
            newRow.Item("TotalHK") = System.DBNull.Value
        Else
            newRow.Item("TotalHK") = txtTotalHK.Text
        End If

        newRow.Item("GangName") = txtTeam.Text
        newRow.Item("COAID") = lblCOAID.Text
        newRow.Item("COACode") = txtCOACode.Text
        newRow.Item("COADescp") = lblCOADescp.Text

        ' Kamis, 19 Nov 2009, 17:07
        If Not String.IsNullOrEmpty(lblOvertimeCOAID.Text) Then
            newRow.Item("OvertimeCOAID") = lblOvertimeCOAID.Text
            newRow.Item("OvertimeCOACode") = txtOvertimeCOACode.Text
            newRow.Item("OTOldCOACode") = LblOToldCOACode.Text
            newRow.Item("OvertimeCOADescp") = lblOvertimeCOADescp.Text
        Else
            newRow.Item("OvertimeCOAID") = System.DBNull.Value
            newRow.Item("OvertimeCOACode") = System.DBNull.Value
            newRow.Item("OTOldCOACode") = System.DBNull.Value
            newRow.Item("OvertimeCOADescp") = System.DBNull.Value
        End If
        ' END Kamis, 19 Nov 2009, 17:07

        If txtTotalOT.Text = "" Or txtTotalOT.Text = "0" Then
            newRow.Item("TotalOT") = System.DBNull.Value
        Else
            newRow.Item("TotalOT") = txtTotalOT.Text
        End If


        If lblContractID.Text = String.Empty Then
            newRow.Item("ContractID") = System.DBNull.Value
        Else
            newRow.Item("ContractID") = lblContractID.Text
        End If

        If btnStationLookup.Enabled = False Then
            newRow.Item("StationDescp") = System.DBNull.Value
            newRow.Item("StationCode") = System.DBNull.Value
            newRow.Item("StationID") = System.DBNull.Value
        ElseIf lblStationID.Text <> String.Empty Then
            newRow.Item("StationDescp") = lblStationDesc.Text
            newRow.Item("StationCode") = txtStation.Text
            newRow.Item("StationID") = lblStationID.Text
        End If

        If btnSubBlockLookup.Enabled = False Then
            newRow.Item("DivID") = System.DBNull.Value
            newRow.Item("DivName") = System.DBNull.Value
        Else

            ' Selasa, 17 Nov 2009, 12:55
            ' Sub Block tidak lagi Mandatory, berarti YOP tidak lg mandatory, Division tdk lg mandatory
            If String.IsNullOrEmpty(lblDivID.Text) Then
                newRow.Item("DivID") = System.DBNull.Value
            Else
                newRow.Item("DivID") = lblDivID.Text
                newRow.Item("DIVName") = txtDIV.Text
            End If

        End If

        If btnSubBlockLookup.Enabled = False Then
            newRow.Item("YOPID") = System.DBNull.Value
        Else
            ' Selasa, 17 Nov 2009, 12:55
            ' Sub Block tidak lagi Mandatory, berarti YOP tidak lg mandatory
            If String.IsNullOrEmpty(lblYOPID.Text) Then
                newRow.Item("YOPID") = System.DBNull.Value
                newRow.Item("YOP") = System.DBNull.Value
            Else
                newRow.Item("YOPID") = lblYOPID.Text
                newRow.Item("YOP") = txtYOP.Text
            End If

        End If
        'Added by nelson jun22-2010 for Brondolan (kg)
        If String.IsNullOrEmpty(txtBrondolan.Text) Then
            newRow.Item("Brondolan") = System.DBNull.Value
        Else
            newRow.Item("Brondolan") = txtBrondolan.Text
        End If
        'end
        If btnSubBlockLookup.Enabled = False Then
            newRow.Item("BlockID") = System.DBNull.Value
        Else
            ' Selasa, 17 Nov 2009, 12:52
            ' Sub Block tidak lagi Mandatory
            If String.IsNullOrEmpty(lblBlockID.Text) Then
                newRow.Item("BlockID") = System.DBNull.Value
                newRow.Item("BlockName") = System.DBNull.Value
            Else
                newRow.Item("BlockID") = lblBlockID.Text
                newRow.Item("BlockName") = txtSubBlock.Text
            End If

            If btnEquipmentLookup.Enabled = False Then
                newRow.Item("MachineName") = System.DBNull.Value
                newRow.Item("MachineCode") = System.DBNull.Value
                newRow.Item("MachineID") = System.DBNull.Value
            ElseIf lblStationID.Text <> String.Empty Then
                newRow.Item("MachineName") = lblEquipmentName.Text
                newRow.Item("MachineCode") = txtEquipment.Text
                newRow.Item("MachineID") = lblEquipmetID.Text
            End If
        End If

        If txtT0.Text = String.Empty Or lblTAnalysisID_TO.Text = String.Empty Then
            newRow.Item("T0") = System.DBNull.Value
            newRow.Item("TAnalysisCode_T0") = System.DBNull.Value
            newRow.Item("TAnalysisDescp_T0") = System.DBNull.Value
        Else
            newRow.Item("T0") = lblTAnalysisID_TO.Text
            newRow.Item("TAnalysisCode_T0") = txtT0.Text
            newRow.Item("TAnalysisDescp_T0") = lblTAnalysisDescp_T0.Text
        End If

        If txtT1.Text = String.Empty OrElse lblTAnalysisID_T1.Text = String.Empty Then
            newRow.Item("T1") = System.DBNull.Value
            newRow.Item("TAnalysisCode_T1") = System.DBNull.Value
            newRow.Item("TAnalysisDescp_T1") = System.DBNull.Value
        Else
            newRow.Item("T1") = lblTAnalysisID_T1.Text
            newRow.Item("TAnalysisCode_T1") = txtT1.Text
            newRow.Item("TAnalysisDescp_T1") = lblTAnalysisDescp_T1.Text
        End If

        If txtT2.Text = String.Empty OrElse lblTAnalysisID_T2.Text = String.Empty Then
            newRow.Item("T2") = System.DBNull.Value
            newRow.Item("TAnalysisCode_T2") = System.DBNull.Value
            newRow.Item("TAnalysisDescp_T2") = System.DBNull.Value
        Else
            newRow.Item("T2") = lblTAnalysisID_T2.Text
            newRow.Item("TAnalysisCode_T2") = txtT2.Text
            newRow.Item("TAnalysisDescp_T2") = lblTAnalysisDescp_T2.Text
        End If

        If txtT3.Text = String.Empty OrElse lblTAnalysisID_T3.Text = String.Empty Then
            newRow.Item("T3") = System.DBNull.Value
            newRow.Item("TAnalysisCode_T3") = System.DBNull.Value
            newRow.Item("TAnalysisDescp_T3") = System.DBNull.Value
        Else
            newRow.Item("T3") = lblTAnalysisID_T3.Text
            newRow.Item("TAnalysisCode_T3") = txtT3.Text
            newRow.Item("TAnalysisDescp_T3") = lblTAnalysisDescp_T3.Text
        End If

        If txtT4.Text = String.Empty Or lblTAnalysisID_T4.Text = String.Empty Then
            newRow.Item("T4") = System.DBNull.Value
            newRow.Item("TAnalysisCode_T4") = System.DBNull.Value
            newRow.Item("TAnalysisDescp_T4") = System.DBNull.Value
        Else
            newRow.Item("T4") = lblTAnalysisID_T4.Text
            newRow.Item("TAnalysisCode_T4") = txtT4.Text
            newRow.Item("TAnalysisDescp_T4") = lblTAnalysisDescp_T4.Text
        End If

        If txtHK.Text = "" Or txtHK.Text = "0" Then
            newRow.Item("Mandays") = System.DBNull.Value
        Else
            newRow.Item("Mandays") = txtHK.Text
        End If

        If txtOT.Text = "" Or txtOT.Text = "0" Then
            newRow.Item("OT") = "0"
        Else
            newRow.Item("OT") = txtOT.Text
        End If

        If txtHa.Text = "" Or txtHa.Text = "0" Then
            newRow.Item("Ha") = System.DBNull.Value
        Else
            newRow.Item("Ha") = txtHa.Text
        End If

        If lblUOMID.Text = String.Empty Then
            newRow.Item("UOM") = System.DBNull.Value
            newRow.Item("UOMID") = System.DBNull.Value
        Else
            newRow.Item("UOM") = Me.cboUOM.Text
            newRow.Item("UOMID") = Me.lblUOMID.Text
        End If

        newRow.Item("CreatedBy") = GlobalPPT.strUserName
        newRow.Item("CreatedOn") = Now
        newRow.Item("ModifiedBy") = GlobalPPT.strUserName
        newRow.Item("ModifiedOn") = Now

        If txtVehicleCode.Text <> String.Empty Then
            newRow.Item("VehicleID") = psVHID
            newRow.Item("VehicleCode") = txtVehicleCode.Text
            newRow.Item("VehicleDesc") = lblVehicleDescp.Text
            newRow.Item("DetailCostId") = psVHDetailCostCodeID
            newRow.Item("DetailCostCode") = txtDetailCostCode.Text
            newRow.Item("DetailCostDesc") = lblDetailCostDescp.Text
        End If

        DT_DailyActivityDistributionWithTeam.Rows.Add(newRow)
        clearInput()

        MessageBox.Show("Data successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Function


    Private Sub ClearInputAll()
        ' Selasa, 27 Oct 2009, 12:30

        ' Senin, 26 Oct 2009, 21:33
        txtTeam.Text = String.Empty
        lblGangMasterID.Text = String.Empty
        lblActivity.Text = String.Empty

        lblMandoreID.Text = String.Empty
        lblMandorEmpName.Text = String.Empty
        lblKraniID.Text = String.Empty
        lblKraniEmpName.Text = String.Empty
        txtTotalHK.Text = 0
        clearInput()

        If DT_DailyAttendanceWithTeam Is Nothing Then
        Else
            DT_DailyAttendanceWithTeam.Clear()
        End If

        If DT_DailyActivityDistributionWithTeam Is Nothing Then
        Else
            DT_DailyActivityDistributionWithTeam.Clear()
        End If


    End Sub

    Private Sub clearInput()

        lblMessage.Text = String.Empty

        ' Jum'at, 02 Oct 2009, 16:26
        txtContractNo.Text = String.Empty
        lblContractID.Text = String.Empty
        txtCOACode.Text = String.Empty
        lblCOAID.Text = String.Empty
        lblCOADescp.Text = String.Empty
        txtOldCOACode.Text = String.Empty

        ' Kamis, 19 Nov 2009, 11:22
        txtOvertimeCOACode.Text = String.Empty
        lblOvertimeCOADescp.Text = String.Empty
        lblOvertimeCOAID.Text = String.Empty
        ' END Kamis, 19 Nov 2009, 11:22

        txtSubBlock.Text = String.Empty
        lblBlockID.Text = String.Empty
        lblStatusBlock.Text = String.Empty

        txtDIV.Text = String.Empty
        lblDivID.Text = String.Empty

        txtYOP.Text = String.Empty
        lblYOPID.Text = String.Empty

        lblStationDesc.Text = String.Empty
        txtStation.Text = String.Empty
        lblStationID.Text = String.Empty

        txtStation.Text = String.Empty

        txtHK.Text = "0"
        txtOT.Text = "0"

        txtHa.Text = "0"

        ' Selasa, 17 Nov 2009, 17:58
        ' Utk TAnalysis T0 sampe T2 yg punya default value, tidak di clear, biarkan saja
        'txtT0.Text = String.Empty
        txtT1.Text = String.Empty
        txtT2.Text = String.Empty
        txtT3.Text = String.Empty
        txtT4.Text = String.Empty

        'lblTAnalysisID_TO.Text = String.Empty
        lblTAnalysisID_T1.Text = String.Empty
        lblTAnalysisID_T2.Text = String.Empty
        lblTAnalysisID_T3.Text = String.Empty
        lblTAnalysisID_T4.Text = String.Empty

        'lblTAnalysisDescp_T0.Text = String.Empty
        lblTAnalysisDescp_T1.Text = String.Empty
        lblTAnalysisDescp_T2.Text = String.Empty
        lblTAnalysisDescp_T3.Text = String.Empty
        lblTAnalysisDescp_T4.Text = String.Empty
        lblTAnalysisDescp_T5.Text = String.Empty
        lblTAnalysisDescp_T6.Text = String.Empty
        lblTAnalysisDescp_T7.Text = String.Empty
        lblTAnalysisDescp_T8.Text = String.Empty
        lblTAnalysisDescp_T9.Text = String.Empty

        LblOToldCOACode.Text = String.Empty
        lblSelectedActivity.Text = String.Empty
        txtBrondolan.Text = String.Empty
        txtBrondolan.Text = "0"

        txtEquipment.Text = String.Empty
        lblEquipmetID.Text = String.Empty
        lblEquipmentName.Text = String.Empty


        psVHID = String.Empty
        Me.txtVehicleCode.Text = String.Empty
        psVHDetailCostCodeID = String.Empty
        lblVehicleDescp.Text = String.Empty
        txtDetailCostCode.Text = String.Empty
        lblDetailCostDescp.Text = String.Empty

        Me.cboUOM.Text = String.Empty
        Me.lblUOMID.Text = String.Empty

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        ' Selasa, 22 Sep 2009, 10:39
        SaveDailyActivityDistributionWithTeam()
    End Sub

    Private Sub SaveDailyActivityDistributionWithTeam()
        ' Selasa, 22 Sep 2009, 10:39
        'Dim sumHK As Decimal = 0

        '''''
        ' Check jml grid HK
        dSumHK = SumHKGrid()

        If dSumHK < dTotalHK And dgvActivity.Rows.Count > 0 Then
            MessageBox.Show("HK not balance, data cannot be saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        '''''
        ' Check jml grid OT
        ' Jum'at, 02 Oct 2009, 15:01
        dSumOT = SumOTGrid()
        If dSumOT < dTotalOT And dgvActivity.Rows.Count > 0 Then
            MessageBox.Show("OT not balance, data cannot be saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Cursor = Cursors.WaitCursor

        Dim retValue As Integer

        retValue = DailyActivityDistributionWithTeamTableAdapter.Update( _
            DT_DailyActivityDistributionWithTeam)

        ' Selasa, 29 Dec 2009, 18:13
        ' Place : Kuala Lumpur
        'stanley : 10-June-2011.b
        'Blocked and added codes below with duplicated SP that use one additional input parameter
        'DailyActivityDistributionWithTeam_DAL.CRDistributionSummary()
        'DailyActivityDistributionWithTeam_DAL.CRDistributionActivitySummary()
        ' END Selasa, 29 Dec 2009, 18:13

        DailyActivityDistributionWithTeam_DAL.CRDistributionSummary_Daily(dtpDADate.Text)
        DailyActivityDistributionWithTeam_DAL.CRDistributionActivitySummary_Daily(dtpDADate.Text)
        'stanley : 10-June-2011.e

        ' Jum'at, 1 Jan 2010, 13:15
        CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
        ' END Jum'at, 1 Jan 2010, 13:15

        Cursor = Cursors.Default

        If retValue > 0 Then

            If dSumHK = dTotalHK Then
                btnMaterial.Enabled = True
            End If

            DoSearch()
            MessageBox.Show("Data Activity successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Private Sub SaveVehicleCharging()
        'Dim vhRow As DataGridViewRow
        'Dim vhchargedetailinsert As Integer = 0
        'For Each vhRow In dgvActivity.Rows
        '    If Not IsDBNull(vhRow.Cells("VehicleID").Value) And vhRow.Cells("VehicleID").Value <> "" Then
        '        MessageBox.Show(vhRow.Cells("VehicleID").Value)
        '        Dim osivppt As New Store_PPT.StoreIssueVoucherPPT
        '        Dim objStockIssueVoucherApprovalPPT As New Store_PPT.StockIssueVoucherApprovalPPT
        '        Dim dsvhdetails As New DataSet
        '        osivppt.VHWSCode = vhRow.Cells("VehicleCode").Value.ToString()
        '        osivppt.VHDesc = vhRow.Cells("VehicleDesc").Value.ToString()
        '        osivppt.VHCategoryID = String.Empty
        '        osivppt.Type = String.Empty
        '        dsvhdetails = Store_BOL.StoreIssueVoucherBOL.GetVHNo(osivppt, "yes")
        '        objStockIssueVoucherApprovalPPT.EstateCodeL = Me.txtT1.Text
        '        objStockIssueVoucherApprovalPPT.VHWSCode = vhRow.Cells("VehicleCode").Value.ToString()
        '        objStockIssueVoucherApprovalPPT.VHDetailCostCode = vhRow.Cells("DetailCostCode").Value.ToString()
        '        objStockIssueVoucherApprovalPPT.Type = "V"
        '        objStockIssueVoucherApprovalPPT.AYear = GlobalPPT.intActiveYear
        '        objStockIssueVoucherApprovalPPT.AMonth = GlobalPPT.IntLoginMonth
        '        objStockIssueVoucherApprovalPPT.LedgerNo = psLedgerNo
        '        objStockIssueVoucherApprovalPPT.LedgerType = psLedgerType
        '        objStockIssueVoucherApprovalPPT.Value = lSIVPrice
        '        objStockIssueVoucherApprovalPPT.Descp = vhRow.Cells("VehicleDesc").Value.ToString()
        '        vhchargedetailinsert = Store_BOL.StoreIssueVoucherBOL.VHChargeDetailInsert(objStockIssueVoucherApprovalPPT)
        '    End If
        'Next
    End Sub
    Private Sub cmsDailyActivityDistribution_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDailyActivityDistribution.Opening
        ' Selasa, 15 Sep 2009, 03:40

        If dgvActivity.Rows.Count = 0 Then
            cmsDailyActivityDistribution.Items(0).Enabled = False
            cmsDailyActivityDistribution.Items(1).Enabled = False
        ElseIf dgvActivity.Rows.Count > 0 And dgvActivity.CurrentCell IsNot Nothing Then
            cmsDailyActivityDistribution.Items(0).Enabled = True
            cmsDailyActivityDistribution.Items(1).Enabled = True
        End If

    End Sub

    Private Sub DeleteMIDAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMIDAD.Click
        ' Selasa, 15 Sep 2009, 03:41

        If dgvActivity.Rows.Count = 0 Or dgvActivity.CurrentCell Is Nothing Then
            Return
        End If

        ' Selasa, 20 Oct 2009, 14:32
        ' Check apakah DailyActivityDistribution ini sudah punya record di di table ActivityMaterialUsage
        ' jika sudah don't allow to delete
        Dim DT As DataTable
        DT = DailyActivityDistributionWithTeam_DAL.CRMaterialForDailyActivityDistributionIsExist( _
            lblGangMasterID.Text, dtpDADate.Value)

        If DT.Rows.Count > 0 Then
            MessageBox.Show("This activity already have Material, cannot delete this record", _
                            "Warning", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Warning)
            Return
        End If
        ' END Selasa, 20 Oct 2009, 14:32

        If MessageBox.Show("You are about to delete the selected record." + vbCrLf + _
                           "Are you sure?", "DELETE", MessageBoxButtons.OKCancel, _
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        DeleteDailyActivityDistribution()

    End Sub

    Private Sub DeleteDailyActivityDistribution()
        ' Selasa, 15 Sep 2009, 03:42
        If dgvActivity.Rows(dgvActivity.CurrentCell.RowIndex).Cells("DailyDistributionID").Value Is System.DBNull.Value Then
            dgvActivity.Rows.RemoveAt(dgvActivity.CurrentCell.RowIndex)
        Else
            '  DT_DailyActivityDistributionWithTeam.Rows(dgvActivity.CurrentCell.RowIndex).Delete()
            dgvActivity.Rows.RemoveAt(dgvActivity.CurrentCell.RowIndex)

        End If

        Cursor = Cursors.WaitCursor
        'HitungTotalHK()

        ' Selasa, 22 Sep 2009, 11:30
        Dim sumHK As Decimal = 0

        sumHK = SumHKGrid()
        dBalanceTotalHK = dTotalHK - sumHK
        txtBalanceTotalHK.Text = dBalanceTotalHK.ToString()

        ' Senin, 23 Nov 2009, 22:36
        Dim sumOT As Decimal = 0
        sumOT = SumOTGrid()
        dBalanceTotalOT = dTotalOT - sumOT
        txtBalanceTotalOT.Text = dBalanceTotalOT.ToString()
        ' END Senin, 23 Nov 2009, 22:36

        Cursor = Cursors.Default

        ' Selasa, 19 Oct 2009, 12:36
        If dTotalHK > 0 Then
            If dBalanceTotalHK = dTotalHK Then
                btnMaterial.Enabled = False

            End If
        End If
        ' END Selasa, 19 Oct 2009, 12:36

        ' Senin, 23 Nov 2009, 22:33
        If dgvActivity.Rows.Count = 0 Then
            btnMaterial.Enabled = False
        End If

        If dBalanceTotalOT > 0 Or dBalanceTotalHK > 0 Then
            btnMaterial.Enabled = False
            btnAdd.Enabled = True
        Else
            btnAdd.Enabled = False
            btnMaterial.Enabled = True
        End If
        ' END Senin, 23 Nov 2009, 22:33

        MessageBox.Show("Data successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub dtpDADate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDADate.ValueChanged
        ' Selasa, 15 Sep 2009, 03:55
        If lblGangMasterID.Text <> String.Empty Then
            Cursor = Cursors.WaitCursor

            'MessageBox.Show("TEST", "TEST")
            'ShowDailyActivityDistribution()
            'HitungTotalHK()
            'HitungTotalOT()

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EditMIDAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMIDAD.Click
        ' Selasa, 15 Sep 2009, 10:15
        If dgvActivity.CurrentCell Is Nothing Then
            MessageBox.Show("Please select the grid first, before editing", "Information", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
            Return
        End If

        dtpDADate.Enabled = False
        txtTeam.Enabled = False
        BtnTeamLookup.Enabled = False

        btnAdd.Enabled = False
        btnEditOrUpdate.Text = "&Update"
        btnReset.Enabled = True
        btnSaveAll.Enabled = False
        btnClose.Enabled = False
        btnMaterial.Enabled = False
        dgvActivity.Enabled = False
        EditDailyActicityDistributionWithTeam()
    End Sub

    Private Sub EditDailyActicityDistributionWithTeam()
        ' Rabu, 16 Sep 2009, 00:28

        Dim rowIndex As Integer = dgvActivity.CurrentCell.RowIndex
        ' Senin, 26 Oct 2009, 17:22
        ' Pake CurrencyManager
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvActivity.DataSource, dgvActivity.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        Dim dr As DataRow

        dr = dv.Item(cm.Position).Row

        txtCOACode.Text = dr.Item("COACode").ToString()
        If txtCOACode.Text <> Nothing Then
            Dim DTCOA As DataTable
            DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(txtCOACode.Text, "")
            txtOldCOACode.Text = DTCOA.Rows(0).Item("OldCOACode").ToString()
        End If

        lblCOADescp.Text = dr.Item("COADescp").ToString()
        lblCOAID.Text = dr.Item("COAID").ToString()

        ' Kamis, 19 Nov 2009, 17:42
        If Not dr.IsNull("OvertimeCOAID") Then
            txtOvertimeCOACode.Text = dr.Item("OvertimeCOACode").ToString()
            LblOToldCOACode.Text = dr.Item("OTOldCOACode").ToString()
            lblOvertimeCOADescp.Text = dr.Item("OvertimeCOADescp").ToString()
            lblOvertimeCOAID.Text = dr.Item("OvertimeCOAID").ToString()
        End If
        ' END Kamis, 19 Nov 2009, 17:42

        txtSubBlock.Text = dr.Item("BlockName").ToString()
        If Not String.IsNullOrEmpty(txtSubBlock.Text) Then
            Dim DTSBSelect As DataTable = New DataTable
            DTSBSelect = CheckRoll_BOL.LookUpBOL.CRSubBlockSelect(txtSubBlock.Text)
            lblStatusBlock.Text = DTSBSelect.Rows(0).Item("BlockStatus").ToString()
        End If

        lblBlockID.Text = dr.Item("BlockID").ToString()
        txtDIV.Text = dr.Item("DIVName").ToString()
        lblDivID.Text = dr.Item("DIVID").ToString()
        txtYOP.Text = dr.Item("YOP").ToString()
        lblYOPID.Text = dr.Item("YOPID").ToString()

        lblStationDesc.Text = dr.Item("StationDescp").ToString()
        txtStation.Text = dr.Item("StationCode").ToString()
        lblStationID.Text = dr.Item("StationID").ToString()

        If dr.Item("MachineID") IsNot System.DBNull.Value Then
            lblEquipmetID.Text = dr.Item("MachineID").ToString()
            txtEquipment.Text = dr.Item("MachineCode").ToString()
            lblEquipmentName.Text = dr.Item("MachineName").ToString()
        Else
            txtEquipment.Text = "0"
        End If

        If dr.Item("Mandays") IsNot System.DBNull.Value Then
            txtHK.Text = dr.Item("Mandays").ToString()
        Else
            txtHK.Text = "0"
        End If

        If dr.Item("OT") IsNot System.DBNull.Value Then
            txtOT.Text = dr.Item("OT").ToString()
        Else
            txtOT.Text = "0"
        End If

        If dr.Item("Ha") IsNot System.DBNull.Value Then
            txtHa.Text = dr.Item("Ha").ToString()
        Else
            txtHa.Text = "0"
        End If

        If dr.Item("Brondolan") IsNot System.DBNull.Value Then
            txtBrondolan.Text = dr.Item("Brondolan").ToString()
        Else
            txtBrondolan.Text = "0"
        End If
        ' Selasa, 22 Sep 2009, 06:27
        Dim DT As DataTable
        Dim T0ID As String = "xxx"
        Dim T1ID As String = "xxx"
        Dim T2ID As String = "xxx"
        Dim T3ID As String = "xxx"
        Dim T4ID As String = "xxx"

        'DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
        If dr.Item("T0") IsNot System.DBNull.Value Then
            T0ID = dr.Item("T0").ToString()
        End If

        If dr.Item("T1") IsNot System.DBNull.Value Then
            T1ID = dr.Item("T1").ToString()
        End If

        If dr.Item("T2") IsNot System.DBNull.Value Then
            T2ID = dr.Item("T2").ToString()
        End If

        If dr.Item("T3") IsNot System.DBNull.Value Then
            T3ID = dr.Item("T3").ToString()
        End If

        If dr.Item("T4") IsNot System.DBNull.Value Then
            T4ID = dr.Item("T4").ToString()
        End If

        If dr.Item("UOMID") IsNot System.DBNull.Value Then
            Me.lblUOMID.Text = dr.Item("UOMID").ToString()
            Me.cboUOM.SelectedValue = dr.Item("UOMID").ToString()
        Else
            Me.lblUOMID.Text = ""
            Me.cboUOM.Text = ""
        End If

        If Not IsDBNull(dr.Item("VehicleId")) Then
            psVHID = dr.Item("VehicleId")
            Me.txtVehicleCode.Text = dr.Item("VehicleCode")
            psVHDetailCostCodeID = dr.Item("DetailCostId")
            lblVehicleDescp.Text = dr.Item("VehicleDesc")
            txtDetailCostCode.Text = dr.Item("DetailCostCode")
            lblDetailCostDescp.Text = dr.Item("DetailCostDesc")
        End If

        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect(T0ID, "", "")
        If DT.Rows.Count > 0 Then
            txtT0.Text = DT.Rows(0).Item("TValue").ToString()
            lblTAnalysisID_TO.Text = DT.Rows(0).Item("TAnalysisID").ToString()
            'lblTAnalysisDescp_T0.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()
        Else
            txtT0.Text = String.Empty
            lblTAnalysisID_TO.Text = String.Empty
            lblTAnalysisDescp_T0.Text = String.Empty
        End If
        lblTAnalysisDescp_T0.Text = dr.Item("TAnalysisDescp_T0").ToString()

        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect(T1ID, "", "")
        If DT.Rows.Count > 0 Then
            txtT1.Text = DT.Rows(0).Item("TValue").ToString()
            lblTAnalysisID_T1.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        Else
            txtT1.Text = String.Empty
            lblTAnalysisID_T1.Text = String.Empty
            lblTAnalysisDescp_T1.Text = String.Empty
        End If
        lblTAnalysisDescp_T1.Text = dr.Item("TAnalysisDescp_T1").ToString()

        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect(T2ID, "", "")
        If DT.Rows.Count > 0 Then
            txtT2.Text = DT.Rows(0).Item("TValue").ToString()
            lblTAnalysisID_T2.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        Else
            txtT2.Text = String.Empty
            lblTAnalysisID_T2.Text = String.Empty
            lblTAnalysisDescp_T2.Text = String.Empty
        End If
        lblTAnalysisDescp_T2.Text = dr.Item("TAnalysisDescp_T2").ToString()

        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect(T3ID, "", "")
        If DT.Rows.Count > 0 Then
            txtT3.Text = DT.Rows(0).Item("TValue").ToString()
            lblTAnalysisID_T3.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        Else
            txtT3.Text = String.Empty
            lblTAnalysisID_T3.Text = String.Empty
            lblTAnalysisDescp_T3.Text = String.Empty
        End If
        lblTAnalysisDescp_T3.Text = dr.Item("TAnalysisDescp_T3").ToString()

        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect(T4ID, "", "")
        If DT.Rows.Count > 0 Then
            txtT4.Text = DT.Rows(0).Item("TValue").ToString()
            lblTAnalysisID_T4.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        Else
            txtT4.Text = String.Empty
            lblTAnalysisID_T4.Text = String.Empty
            lblTAnalysisDescp_T4.Text = String.Empty
        End If
        lblTAnalysisDescp_T4.Text = dr.Item("TAnalysisDescp_T4").ToString()
        
    End Sub

    Private Sub btnCOALookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCOALookup.Click
        ' Selasa, 15 Sep 2009, 22:49
        COALookup.strAcctExpenditureAG = lblStatusBlock.Text
        COALookup.ShowDialog()

        If COALookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtCOACode.Text = COALookup.strAcctcode
            Me.lblCOAID.Text = COALookup.strAcctId
            lblCOADescp.Text = COALookup.strAcctDescp
            txtOldCOACode.Text = COALookup.strOldAccountCode

            ' Kamis, 19 Nov 2009, 11:46
            ' by GUE
            ' tambah OvertimeCOA
            'Dim DTCOA As DataTable
            'Dim OvertimeCOACode As String
            'Commented by Nelson jun 21-2010
            'If Not String.IsNullOrEmpty(txtCOACode.Text) Then

            '    OvertimeCOACode = txtCOACode.Text.Substring(0, txtCOACode.Text.Length - 3)
            '    OvertimeCOACode = OvertimeCOACode + "002"

            '    DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(OvertimeCOACode, lblStatusBlock.Text)

            '    If DTCOA.Rows.Count > 0 Then
            '        txtOvertimeCOACode.Text = OvertimeCOACode
            '        lblOvertimeCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
            '        lblOvertimeCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()

            '    Else
            '        txtOvertimeCOACode.Text = String.Empty
            '        lblOvertimeCOADescp.Text = String.Empty
            '        lblOvertimeCOAID.Text = String.Empty

            '    End If

            'End If
            'end
            ' END Kamis, 19 Nov 2009, 11:46

            txtHK.Focus()
        End If

    End Sub

    Private Sub btnReset_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Rabu, 16 Sep 2009, 00:29
        ' Senin, 26 Oct 2009, 21:10
        btnAdd.Text = "&Add"

        If CallFromDailyAttendance = True Then
            ' Kalo dipanggil dari Daily Attendance, maka lock semua
            dtpDADate.Enabled = False
            txtTeam.Enabled = False
            BtnTeamLookup.Enabled = False
            btnResetAll.Enabled = False

        Else
            dtpDADate.Enabled = False
            txtTeam.Enabled = True
            BtnTeamLookup.Enabled = True
            btnResetAll.Enabled = True

        End If

        btnAdd.Enabled = True
        'btnEditOrUpdate.Enabled = True
        'btnEditOrUpdate.Text = "&Edit"

        btnReset.Enabled = False
        btnSaveAll.Enabled = True
        btnClose.Enabled = True

        If dgvActivity.Rows.Count > 0 Then
            btnMaterial.Enabled = True
        Else
            btnMaterial.Enabled = False
        End If
        dgvActivity.Enabled = True
        If Val(txtBalanceTotalHK.Text) = 0 And Val(txtBalanceTotalOT.Text) = 0.0 Then
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
        End If
        clearInput()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Rabu, 16 Sep 2009, 00:56
        btnAdd.Enabled = True
        btnEditOrUpdate.Enabled = False
        btnSaveAll.Enabled = True

        UpdateDailyActicityDistributionWithTeam()
    End Sub

    Private Function UpdateDailyActicityDistributionWithTeam() As Boolean
        ' Rabu, 16 Sep 2009, 00:57
        Dim rowIndex As Integer = dgvActivity.CurrentCell.RowIndex

        Dim dHK As Decimal = 0
        Dim dSumHK As Decimal = 0
        Dim dSumHKWithoutCurrentEdit As Decimal = 0


        ' Kamis, 19 Nov 2009, 17:46
        ' dibawah ini dinonaktifkan, sekarang HK bisa nol,
        ' soalnya satu orang dalam satu hari bisa punya kegiatan contoh weeding atau dgn kata lain 1 HK
        ' setelah itu malamnya dia bisa punya kegiatan angkat buah tapi dia tdk punya HK lagi,
        ' tapi dia punya overtime saja
        '
        'If txtHK.Text = "" Or txtHK.Text = "0" Then
        '    MessageBox.Show("You must input HK", "Information", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False

        'End If
        ' END Kamis, 19 Nov 2009, 17:46
        'Added by nelson jun 21-2010
        If txtSubBlock.Text <> Nothing And txtCOACode.Text <> String.Empty Then


            If IsSubBlockAlreadyInGreadWithOutCurrentEdit() <> -1 Then
                MessageBox.Show("Field No Already in grid" + vbCrLf + _
                    "example: You can not add the similar Field No", _
                    "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If



        ElseIf txtCOACode.Text = String.Empty Or lblCOAID.Text = String.Empty Then
            MsgBox("Main Activity is mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            If txtCOACode.Enabled Then txtCOACode.Focus()
            Return False
        End If
        'end
        If txtHK.Text <> "" Then
            'If Val(txtHK.Text) = 0 Then
            '    MessageBox.Show("Please key in numeric value for HK", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Return False
            'End If

            Try
                dHK = FormatNumber(Val(txtHK.Text), 2)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        dSumHKWithoutCurrentEdit = SumHKGridMinusCurrentEdit()

        If dHK + dSumHKWithoutCurrentEdit > dTotalHK Then
            MessageBox.Show("HK cannot more then the Balance Total HK", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If


        ''
        ' OT (Over Time)
        ' Jum'at, 2 Oct 2009, 14:53
        Dim dOT As Decimal = 0
        Dim dSumOTWithoutCurrentEdit As Decimal = 0

        Try
            dOT = FormatNumber(Val(txtOT.Text), 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        If dHK = 0 And dOT = 0 Then
            MessageBox.Show("HK and OT cannot be zero", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        dSumOTWithoutCurrentEdit = SumOTGridMinusCurrentEdit()
        If (dOT + dSumOTWithoutCurrentEdit > dTotalOT) Then
            MessageBox.Show("OT cannot more then the Balance Total OT", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        'If txtHa.Text <> "" Then
        '    If Val(txtHa.Text) = 0 Then
        '        MessageBox.Show("Please key in numeric value for Prestasi", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        Return
        '    End If
        'End If

        dBalanceTotalHK = dTotalHK - (dHK + dSumHKWithoutCurrentEdit)
        txtBalanceTotalHK.Text = dBalanceTotalHK.ToString()

        dBalanceTotalOT = dTotalOT - (dOT + dSumOTWithoutCurrentEdit)
        txtBalanceTotalOT.Text = dBalanceTotalOT.ToString()

        ' Selasa, 19 Oct 2009, 12:36
        If dTotalHK > 0 Then
            If dBalanceTotalHK = dTotalHK Then
                btnMaterial.Enabled = False
            End If
        End If
        ' END Selasa, 19 Oct 2009, 12:36

        ' Selasa, 27 Oct 2009, 00:48
        Dim cm As CurrencyManager = CType(Me.BindingContext(Me.dgvActivity.DataSource, Me.dgvActivity.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        Dim dr As DataRow = dv.Item(cm.Position).Row

        dr.Item("COAID") = lblCOAID.Text
        dr.Item("COACode") = txtCOACode.Text
        dr.Item("COADescp") = lblCOADescp.Text

        ' Jum'at, 20 Nov 2009, 11:39
        If Not String.IsNullOrEmpty(lblOvertimeCOAID.Text) Then
            dr.Item("OvertimeCOAID") = lblOvertimeCOAID.Text
            dr.Item("OvertimeCOACode") = txtOvertimeCOACode.Text
            dr.Item("OTOldCOACode") = LblOToldCOACode.Text
            dr.Item("OvertimeCOADescp") = lblOvertimeCOADescp.Text
        Else
            dr.Item("OvertimeCOAID") = System.DBNull.Value
            dr.Item("OvertimeCOACode") = System.DBNull.Value
            dr.Item("OTOldCOACode") = System.DBNull.Value
            dr.Item("OvertimeCOADescp") = System.DBNull.Value
        End If
        ' END Jum'at, 20 Nov 2009, 11:39

        ' Selasa, 17 Nov 2009, 01:55
        ' Sub Block tidak lagi Mandatory, berarti YOP tidak lg mandatory, Division tdk lg mandatory
        If String.IsNullOrEmpty(lblBlockID.Text) Then
            dr.Item("BlockID") = System.DBNull.Value
            dr.Item("BlockName") = System.DBNull.Value
        Else
            dr.Item("BlockID") = lblBlockID.Text
            dr.Item("BlockName") = txtSubBlock.Text
        End If

        If String.IsNullOrEmpty(lblYOPID.Text) Then
            dr.Item("YOPID") = System.DBNull.Value
            dr.Item("YOP") = System.DBNull.Value
        Else
            dr.Item("YOPID") = lblYOPID.Text
            dr.Item("YOP") = txtYOP.Text
        End If

        If String.IsNullOrEmpty(txtBrondolan.Text) Then
            dr.Item("Brondolan") = System.DBNull.Value

        Else
            dr.Item("Brondolan") = txtBrondolan.Text

        End If

        If String.IsNullOrEmpty(lblDivID.Text) Then
            dr.Item("DIVID") = System.DBNull.Value
            dr.Item("DIVName") = System.DBNull.Value
        Else
            dr.Item("DIVID") = lblDivID.Text
            dr.Item("DIVName") = txtDIV.Text
        End If

        If lblStationID.Text = String.Empty OrElse txtStation.Text = String.Empty Then
            dr.Item("StationDescp") = System.DBNull.Value
            dr.Item("StationCode") = System.DBNull.Value
            dr.Item("StationID") = System.DBNull.Value
        Else
            dr.Item("StationDescp") = lblStationDesc.Text
            dr.Item("StationCode") = txtStation.Text
            dr.Item("StationID") = lblStationID.Text
        End If

        If txtHK.Text = String.Empty OrElse txtHK.Text = "0" Then
            dr.Item("Mandays") = System.DBNull.Value
        Else
            dr.Item("Mandays") = txtHK.Text
        End If

        If txtOT.Text = String.Empty OrElse txtOT.Text = "0" Then
            dr.Item("OT") = System.DBNull.Value
        Else
            dr.Item("OT") = txtOT.Text
        End If

        If txtHa.Text = String.Empty OrElse txtHa.Text = "0" Then
            dr.Item("Ha") = System.DBNull.Value
        Else
            dr.Item("Ha") = txtHa.Text
        End If

        If lblUOMID.Text = String.Empty Then
            dr.Item("UOMID") = System.DBNull.Value
        Else
            dr.Item("UOMID") = lblUOMID.Text
        End If

        If cboUOM.SelectedValue Is Nothing Then
            dr.Item("UOM") = System.DBNull.Value
        Else
            Dim DRV As DataRowView
            DRV = cboUOM.SelectedItem
            dr.Item("UOM") = DRV.Item(1).ToString()
        End If

        If txtT0.Text = String.Empty OrElse lblTAnalysisID_TO.Text = String.Empty Then
            dr.Item("T0") = System.DBNull.Value
            dr.Item("TAnalysisCode_T0") = System.DBNull.Value
            dr.Item("TAnalysisDescp_T0") = System.DBNull.Value
        Else
            dr.Item("T0") = lblTAnalysisID_TO.Text
            dr.Item("TAnalysisCode_T0") = txtT0.Text
            dr.Item("TAnalysisDescp_T0") = lblTAnalysisDescp_T0.Text
        End If

        If txtT1.Text = String.Empty OrElse lblTAnalysisID_T1.Text = String.Empty Then
            dr.Item("T1") = System.DBNull.Value
            dr.Item("TAnalysisCode_T1") = System.DBNull.Value
            dr.Item("TAnalysisDescp_T1") = System.DBNull.Value
        Else
            dr.Item("T1") = lblTAnalysisID_T1.Text
            dr.Item("TAnalysisCode_T1") = txtT1.Text
            dr.Item("TAnalysisDescp_T1") = lblTAnalysisDescp_T1.Text
        End If

        If txtT2.Text = String.Empty OrElse lblTAnalysisID_T2.Text = String.Empty Then
            dr.Item("T2") = System.DBNull.Value
            dr.Item("TAnalysisCode_T2") = System.DBNull.Value
            dr.Item("TAnalysisDescp_T2") = System.DBNull.Value
        Else
            dr.Item("T2") = lblTAnalysisID_T2.Text
            dr.Item("TAnalysisCode_T2") = txtT2.Text
            dr.Item("TAnalysisDescp_T2") = lblTAnalysisDescp_T2.Text
        End If

        If txtT3.Text = String.Empty OrElse lblTAnalysisID_T3.Text = String.Empty Then
            dr.Item("T3") = System.DBNull.Value
            dr.Item("TAnalysisCode_T3") = System.DBNull.Value
            dr.Item("TAnalysisDescp_T3") = System.DBNull.Value
        Else
            dr.Item("T3") = lblTAnalysisID_T3.Text
            dr.Item("TAnalysisCode_T3") = txtT3.Text
            dr.Item("TAnalysisDescp_T3") = lblTAnalysisDescp_T3.Text
        End If

        If txtT4.Text = String.Empty OrElse lblTAnalysisID_T4.Text = String.Empty Then
            dr.Item("T4") = System.DBNull.Value
            dr.Item("TAnalysisCode_T4") = System.DBNull.Value
            dr.Item("TAnalysisDescp_T4") = System.DBNull.Value
        Else
            dr.Item("T4") = lblTAnalysisID_T4.Text
            dr.Item("TAnalysisCode_T4") = txtT4.Text
            dr.Item("TAnalysisDescp_T4") = lblTAnalysisDescp_T4.Text
        End If

        ' TotalHK

        ' TotalOT
        If txtTotalOT.Text = String.Empty OrElse txtTotalOT.Text = "0" Then
            dr.Item("TotalOT") = System.DBNull.Value
        Else
            dr.Item("TotalOT") = txtTotalOT.Text
        End If
        If lblEquipmetID.Text = String.Empty OrElse txtEquipment.Text = String.Empty Then
            dr.Item("MachineName") = System.DBNull.Value
            dr.Item("MachineCode") = System.DBNull.Value
            dr.Item("MachineID") = System.DBNull.Value
        Else
            dr.Item("MachineName") = lblEquipmentName.Text
            dr.Item("MachineCode") = txtEquipment.Text
            dr.Item("MachineID") = lblEquipmetID.Text
        End If
        If txtVehicleCode.Text <> String.Empty Then
            dr.Item("VehicleID") = psVHID
            dr.Item("VehicleCode") = txtVehicleCode.Text
            dr.Item("VehicleDesc") = lblVehicleDescp.Text
            dr.Item("DetailCostId") = psVHDetailCostCodeID
            dr.Item("DetailCostCode") = txtDetailCostCode.Text
            dr.Item("DetailCostDesc") = lblDetailCostDescp.Text
        Else
            dr.Item("VehicleID") = System.DBNull.Value
            dr.Item("VehicleCode") = System.DBNull.Value
            dr.Item("VehicleDesc") = System.DBNull.Value
            dr.Item("DetailCostId") = System.DBNull.Value
            dr.Item("DetailCostCode") = System.DBNull.Value
            dr.Item("DetailCostDesc") = System.DBNull.Value
        End If
        MessageBox.Show("Your data has been successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'HitungTotalHK()

        Return True
    End Function

    Private Sub btnSearchT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT0.Click
        ' Rabu, 16 Sep 2009, 02:42

        Dim TAnalysisLookupForm As TAnalysisLookUp = New TAnalysisLookUp()
        TAnalysisLookupForm._TACode = lblT0.Text

        If TAnalysisLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtT0.Text = TAnalysisLookupForm._TACode
            Me.lblTAnalysisID_TO.Text = TAnalysisLookupForm._TAID
            Me.lblTAnalysisDescp_T0.Text = TAnalysisLookupForm._TADesc
        End If

    End Sub

    Private Sub btnSearchT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT1.Click
        ' Rabu, 16 Sep 2009, 03:06

        Dim TAnalysisLookupForm As TAnalysisLookUp = New TAnalysisLookUp()
        TAnalysisLookupForm._TACode = lblT1.Text
        If TAnalysisLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtT1.Text = TAnalysisLookupForm._TACode
            Me.lblTAnalysisID_T1.Text = TAnalysisLookupForm._TAID
            Me.lblTAnalysisDescp_T1.Text = TAnalysisLookupForm._TADesc
        End If

    End Sub

    Private Sub btnSearchT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT2.Click
        ' Rabu, 16 Sep 2009, 03:07

        Dim TAnalysisLookupForm As TAnalysisLookUp = New TAnalysisLookUp()
        TAnalysisLookupForm._TACode = lblT2.Text
        If TAnalysisLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtT2.Text = TAnalysisLookupForm._TACode
            Me.lblTAnalysisID_T2.Text = TAnalysisLookupForm._TAID
            Me.lblTAnalysisDescp_T2.Text = TAnalysisLookupForm._TADesc
        End If

    End Sub

    Private Sub btnSearchT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT3.Click
        ' Rabu, 16 Sep 2009, 03:07

        Dim TAnalysisLookupForm As TAnalysisLookUp = New TAnalysisLookUp()
        TAnalysisLookupForm._TACode = lblT3.Text
        If TAnalysisLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtT3.Text = TAnalysisLookupForm._TACode
            Me.lblTAnalysisID_T3.Text = TAnalysisLookupForm._TAID
            Me.lblTAnalysisDescp_T3.Text = TAnalysisLookupForm._TADesc
        End If

    End Sub

    Private Sub btnSearchT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT4.Click
        ' Rabu, 16 Sep 2009, 03:07

        Dim TAnalysisLookupForm As TAnalysisLookUp = New TAnalysisLookUp()
        TAnalysisLookupForm._TACode = lblT4.Text

        If TAnalysisLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtT4.Text = TAnalysisLookupForm._TACode
            Me.lblTAnalysisID_T4.Text = TAnalysisLookupForm._TAID
            Me.lblTAnalysisDescp_T4.Text = TAnalysisLookupForm._TADesc
        End If

    End Sub

    Private Sub btnViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSearch.Click
        DoSearch()

        If dgvDailyActivityDistributionView.Rows.Count = 0 Then
            MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DoSearch()
        ' Selasa, 27 Oct 2009, 10:20
        Dim DT As DataTable
        Dim useMonthYearLogin As Boolean = True
        Dim dSearch As Date
        Dim Activity As String

        If chkDateView.Checked Then
            useMonthYearLogin = False
            dSearch = dtpDistbDateView.Value
        Else
            dSearch = New Date(ActiveYearLogin, ActiveMonthLogin, 1)
        End If

        If cboActivityView.SelectedIndex = -1 OrElse cboActivityView.SelectedIndex = 0 Then
            Activity = String.Empty
        Else
            Activity = cboActivityView.SelectedItem.ToString()
        End If

        DT = DailyActivityDistributionWithTeam_DAL.CRDailyActivityDistributionWithTeamView( _
        useMonthYearLogin, _
        txtTeamNameView.Text, _
        txtMandorNameView.Text, _
        Activity, _
        dtpDistbDateView.Value)

        dgvDailyActivityDistributionView.DataSource = DT


    End Sub

    Private Sub txtSubBlock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubBlock.KeyDown
        ' Rabu, 16 Sep 2009, 10:45
        If e.KeyCode = Keys.Enter Then
            If txtSubBlock.Text = "" Then
                'txtSubBlock.Focus()
                txtCOACode.Focus()
            ElseIf txtSubBlock.Text <> "" Then
                txtCOACode.Focus()
            ElseIf e.KeyCode = Keys.Escape Then

            End If
        End If

    End Sub

    Private Sub btnEditOrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrUpdate.Click
        ' Rabu, 16 Sep 2009, 00:56
        ' Selasa, 22 Sep 2009, 04:18

        If dgvActivity.Rows.Count > 0 Then
            If dgvActivity.CurrentCell IsNot Nothing Then

                If btnEditOrUpdate.Text = "&Edit" Then
                    btnEditOrUpdate.Text = "&Update"

                    dtpDADate.Enabled = False
                    txtTeam.Enabled = False
                    BtnTeamLookup.Enabled = False

                    btnAdd.Enabled = False
                    btnReset.Enabled = True
                    btnSaveAll.Enabled = False
                    btnClose.Enabled = False
                    btnMaterial.Enabled = False

                    rowIndex_dgvDailyActivity = dgvActivity.CurrentCell.RowIndex
                    EditDailyActicityDistributionWithTeam()

                    dgvActivity.Enabled = False

                ElseIf btnEditOrUpdate.Text = "&Update" Then
                    btnEditOrUpdate.Text = "&Edit"

                    dtpDADate.Enabled = True
                    txtTeam.Enabled = True
                    BtnTeamLookup.Enabled = True

                    btnAdd.Enabled = True
                    btnReset.Enabled = False
                    btnSaveAll.Enabled = True
                    btnClose.Enabled = True
                    btnMaterial.Enabled = True

                    UpdateDailyActicityDistributionWithTeam()

                    dgvActivity.Enabled = True

                    clearInput()
                End If

            End If
        End If


    End Sub

    Private Sub txtT0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT0.KeyDown
        ' Selasa, 22 Sep 2009, 11:49
        If e.KeyCode = Keys.Enter Then

            If Not String.IsNullOrEmpty(txtT0.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T0", txtT0.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblTAnalysisID_TO.Text = String.Empty
                    lblTAnalysisDescp_T0.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT0.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT0.Text = DT.Rows(0).Item("TValue").ToString()
                    lblTAnalysisID_TO.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblTAnalysisDescp_T0.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT1.Focus()
                End If

            ElseIf txtT0.Text = String.Empty Then
                ' btnSearchT0.Focus()
                txtT1.Focus()
                '
            End If
        End If
    End Sub

    Private Sub txtT1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT1.KeyDown
        ' Selasa, 22 Sep 2009, 19:05
        If e.KeyCode = Keys.Enter Then

            If Not String.IsNullOrEmpty(txtT1.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T1", txtT1.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblTAnalysisID_T1.Text = String.Empty
                    lblTAnalysisDescp_T1.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT1.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT1.Text = DT.Rows(0).Item("TValue").ToString()
                    lblTAnalysisID_T1.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblTAnalysisDescp_T1.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT2.Focus()
                End If

            ElseIf txtT1.Text = String.Empty Then
                'btnSearchT1.Focus()
                txtT2.Focus()

                '
            End If

        End If
    End Sub

    Private Sub txtT2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT2.KeyDown
        ' Selasa, 22 Sep 2009, 19:06
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(txtT2.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T2", txtT2.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblTAnalysisID_T2.Text = String.Empty
                    lblTAnalysisDescp_T2.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT2.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT2.Text = DT.Rows(0).Item("TValue").ToString()
                    lblTAnalysisID_T2.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblTAnalysisDescp_T2.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT2.Focus()
                End If

            ElseIf txtT2.Text = String.Empty Then
                'btnSearchT2.Focus()
                txtT3.Focus()
                '
            End If

        End If
    End Sub

    Private Sub txtT3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT3.KeyDown
        ' Selasa, 22 Sep 2009, 19:06
        If e.KeyCode = Keys.Enter Then
            ' Senin, 16 Nov 2009, 09:30
            If Not String.IsNullOrEmpty(txtT3.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T3", txtT3.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblTAnalysisID_T3.Text = String.Empty
                    lblTAnalysisDescp_T3.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT3.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT3.Text = DT.Rows(0).Item("TValue").ToString()
                    lblTAnalysisID_T3.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblTAnalysisDescp_T3.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT4.Focus()
                End If

            ElseIf txtT3.Text = String.Empty Then
                ' btnSearchT3.Focus()
                txtT4.Focus()
                '
            End If
        End If
    End Sub

    Private Sub txtT4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT4.KeyDown
        ' Selasa, 22 Sep 2009, 19:08
        If e.KeyCode = Keys.Enter Then

            If Not String.IsNullOrEmpty(txtT1.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T4", txtT4.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblTAnalysisID_T4.Text = String.Empty
                    lblTAnalysisDescp_T4.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT4.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT4.Text = DT.Rows(0).Item("TValue").ToString()
                    lblTAnalysisID_T4.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblTAnalysisDescp_T4.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    'txtT2.Focus()
                    btnAdd.Focus()
                End If

            ElseIf txtT4.Text = String.Empty Then
                ' btnSearchT4.Focus()
                btnAdd.Focus()
                '
            End If

        End If

    End Sub

    Private Sub txtTeam_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTeam.KeyDown
        ' Selasa, 22 Sep 2009, 17:55
        If e.KeyCode = Keys.Enter Then
            If txtTeam.Text = "" Then
                'BtnTeamLookup.Focus()
                txtTeam.Focus()

            ElseIf txtTeam.Text <> "" Then
                txtContractNo.Focus()

                ' txtSubBlock.Focus()
            End If
        End If

    End Sub

    Private Sub txtContractNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContractNo.KeyDown
        ' Selasa, 22 Sep 2009, 17:59
        If e.KeyCode = Keys.Enter Then
            If txtContractNo.Text = "" Then
                'btnSearchContractNumber.Focus()
                txtSubBlock.Focus()

            End If
        End If
    End Sub

    Private Sub txtCOACode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCOACode.KeyDown
        If e.KeyCode = Keys.Enter Then

            If txtCOACode.Text = "" Then

                lblCOADescp.Text = String.Empty
                lblCOAID.Text = String.Empty
                txtCOACode.Focus()

            ElseIf txtCOACode.Text <> "" Then

                Dim DTCOA As DataTable
                DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(txtCOACode.Text, lblStatusBlock.Text)

                If DTCOA.Rows.Count = 1 Then
                    txtCOACode.Text = DTCOA.Rows(0).Item("COACode").ToString()
                    lblCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
                    lblCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()
                    txtOldCOACode.Text = DTCOA.Rows(0).Item("OldCOACode").ToString()

                    ' Kamis, 19 Nov 2009, 11:46
                    ' by GUE
                    ' tambah OvertimeCOA
                    'Dim DTCOA As DataTable
                    Dim OvertimeCOACode As String

                    OvertimeCOACode = txtCOACode.Text.Substring(0, txtCOACode.Text.Length - 3)
                    OvertimeCOACode = OvertimeCOACode + "002"

                    DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(OvertimeCOACode, lblStatusBlock.Text)

                    If DTCOA.Rows.Count > 0 Then
                        txtOvertimeCOACode.Text = OvertimeCOACode
                        lblOvertimeCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
                        lblOvertimeCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()

                    Else
                        txtOvertimeCOACode.Text = String.Empty
                        lblOvertimeCOADescp.Text = String.Empty
                        lblOvertimeCOAID.Text = String.Empty

                    End If
                    ' END Kamis, 19 Nov 2009, 11:46

                    txtHK.Focus()

                ElseIf DTCOA.Rows.Count = 0 Or DTCOA.Rows.Count > 1 Then

                    MsgBox("Activity Code is not valid", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")

                    txtCOACode.Text = String.Empty
                    lblCOADescp.Text = String.Empty
                    lblCOAID.Text = String.Empty

                    txtOldCOACode.Text = String.Empty

                    txtCOACode.Focus()

                End If
            End If

        End If
    End Sub

    Private Sub txtStation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStation.KeyDown
        ' Selasa, 22 Sep 2009, 18:02
        If e.KeyCode = Keys.Enter Then
            If txtStation.Text = "" Then
                txtStation.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            txtHK.Focus()
        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click

        ' Selasa, 29 Dec 2009, 20:07
        ' Place Kuala Lumpur
        If dgvDailyActivityDistributionView.Rows.Count = 0 Then
            Exit Sub
        End If

        If dgvDailyActivityDistributionView.CurrentCell Is Nothing Then
            Exit Sub
        End If

        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyActivityDistributionView.DataSource, dgvDailyActivityDistributionView.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        Dim RDate As String
        Dim GangName As String

        RDate = CType(dr.Item("DistbDate"), Date).ToString("yyyy/MM/dd")
        GangName = dr.Item("GangName").ToString()

        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String

        ReportName = "CRDailyActivityDistributionWithTeamReport"
        report._Source = ReportName
        report._Formula = _
                "{CRDailyActivityDistributionWithTeamReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
                "{CRDailyActivityDistributionWithTeamReport;1.ActiveMonthYearId} ='" + GlobalPPT.strActMthYearID + "' AND " + _
                "{CRDailyActivityDistributionWithTeamReport;1.DistbDate} = #" + RDate + "# AND " + _
                "{CRDailyActivityDistributionWithTeamReport;1.GangName} = '" + GangName + "'"

        report.ShowDialog()

        Cursor = Cursors.Default

        '' Kamis, 24 Sep 2009, 02:13
        'MessageBox.Show("Under contraction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Return


        'If cboTeamView.Items.Count > 0 Then
        '    If cboTeamView.SelectedValue IsNot Nothing Then

        '        Dim report As ViewReport = New ViewReport()
        '        Dim dEnd As Date = New Date(dtpViewDistbDate.Value.Year, dtpViewDistbDate.Value.Month, dtpViewDistbDate.Value.Day + 1)

        '        Dim reportPath As String
        '        reportPath = Application.StartupPath + "\Checkroll\Report\DailyActivityDistributionWithTeamReport.rpt"

        '        report._Source = reportPath
        '        'report._Formula = _
        '        '"{DailyReceiption.DailyReceiptionID} = '" + lblDailyReceiptionID.Text + "' AND " + _
        '        '"{GangMaster.GangName} = '" + lblTeamName.Text + "'"

        '        report.Show()

        '        'Dim DS As DS_DailyActivityDistributionWithTeam_Report

        '        'DS = New DS_DailyActivityDistributionWithTeam_Report( _
        '        '    cboTeamView.SelectedValue.ToString(), dtpViewDistbDate.Value)

        '        'DS.WriteXmlSchema("DS_DailyActivityDistributionWithTeam.xml")

        '        'Dim report As DailyActivityDistributionWithTeam_Report

        '        'report = New DailyActivityDistributionWithTeam_Report

        '        'report.TeamName = cboTeamView.SelectedValue.ToString()
        '        'report.DistbDate = dtpViewDistbDate.Value
        '        'report.Show()
        '    End If
        'End If

    End Sub

    Private Sub dgvActivity_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvActivity.CellDoubleClick
        If dgvActivity.Rows.Count = 0 Then
            Return
        End If

        If dgvActivity.CurrentCell Is Nothing Then
            MessageBox.Show("Please select the grid first, before editing", "Information", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
            Return
        End If

        rowIndex_dgvDailyActivity = dgvActivity.CurrentCell.RowIndex

        dtpDADate.Enabled = False
        txtTeam.Enabled = False
        BtnTeamLookup.Enabled = False

        'btnAdd.Enabled = False
        btnAdd.Text = "&Update"
        'btnEditOrUpdate.Text = "&Update"
        btnReset.Enabled = True

        btnResetAll.Enabled = False
        btnSaveAll.Enabled = False
        btnClose.Enabled = False
        btnMaterial.Enabled = False
        EditDailyActicityDistributionWithTeam()
        dgvActivity.Enabled = False
        btnAdd.Enabled = True
        btnAdd.Focus()

    End Sub


    Private Sub dgvActivity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvActivity.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvActivity.Rows.Count = 0 Or dgvActivity.CurrentCell Is Nothing Then
                Return
            End If

            If MessageBox.Show("You are about to delete the selected record." + vbCrLf + _
                               "Are you sure", "DELETE", MessageBoxButtons.OKCancel, _
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
                Return
            End If

            DeleteDailyActivityDistribution()

        End If
    End Sub

    Private Sub cboUOM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUOM.SelectedIndexChanged
        If cboUOM.Items.Count > 0 Then
            If cboUOM.SelectedValue IsNot Nothing Then
                lblUOMID.Text = cboUOM.SelectedValue.ToString()
            Else
                lblUOMID.Text = ""
            End If
        End If
    End Sub

    Private Sub txtOT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOT.KeyDown
        '' Selasa, 20 Oct 2009, 16:01
        ''
        '' Initialize the flag to false.
        'nonNumberEntered = False

        '' Determine whether the keystroke is a number from the top of the keyboard.
        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '    ' Determine whether the keystroke is a number from the keypad.
        '    If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '        ' Determine whether the keystroke is a backspace.
        '        If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
        '            ' A non-numerical keystroke was pressed. 
        '            ' Set the flag to true and evaluate in KeyPress event.
        '            nonNumberEntered = True
        '        End If
        '    End If
        'End If

        ''If e.KeyCode = Keys.Enter Then
        ''    If Val(txtOT.Text) = 0 Then
        ''        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        ''        txtOT.Text = ""
        ''        txtOT.Focus()
        ''    ElseIf Val(txtOT.Text) > 0 Then
        ''        txtHa.Focus()
        ''    End If
        ''ElseIf e.KeyCode = Keys.Escape Then
        ''    txtHa.Focus()
        ''End If
    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim TeamLookupForm As TeamLookUps = New TeamLookUps()

    '    TeamLookupForm.ShowDialog()

    '    If TeamLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.cboTeamView.Text = TeamLookupForm.GangName
    '        Me.lblGangMasterID.Text = TeamLookupForm.GangMasterID
    '    End If
    'End Sub

    'Private Sub cboTeamView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        Dim DT As DataTable
    '        Dim TeamName As String
    '        TeamName = cboTeamView.Text
    '        DT = DailyActivityDistributionWithTeam_DAL.CRDailyActivityDistributionWithTeamView( _
    '        TeamName, dtpDistbDateView.Value)
    '        dgvDailyActivityDistributionView.DataSource = DT


    '        If dgvDailyActivityDistributionView.Rows.Count = 0 Then
    '            MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            dgvDailyActivityDistributionView.Focus()
    '        End If
    '    End If

    'End Sub

    Private Sub dgvDailyActivityDistributionView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDailyActivityDistributionView.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim rowIndex As Integer = dgvDailyActivityDistributionView.CurrentCell.RowIndex

            Me.txtTeam.Text = dgvDailyActivityDistributionView.Rows(rowIndex).Cells("GangNameColumn").Value.ToString()
            Me.lblGangMasterID.Text = dgvDailyActivityDistributionView.Rows(rowIndex).Cells("GangMasterIDColumn").Value.ToString()
            Me.dtpDADate.Value = dgvDailyActivityDistributionView.Rows(rowIndex).Cells("DistbDateViewColumn").Value

            ShowDailyActivityDistribution()
            HitungTotalHK()

            tcAvtivity.SelectedTab = tabInput
            If dgvActivity.Rows.Count > 0 Then
                dtpDADate.Enabled = False
            Else
                dtpDADate.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtHa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHa.KeyDown

        '' Selasa, 20 Oct 2009, 12:04
        ''
        '' Initialize the flag to false.
        'nonNumberEntered = False

        '' Determine whether the keystroke is a number from the top of the keyboard.
        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '    ' Determine whether the keystroke is a number from the keypad.
        '    If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '        ' Determine whether the keystroke is a backspace.
        '        If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
        '            ' A non-numerical keystroke was pressed. 
        '            ' Set the flag to true and evaluate in KeyPress event.
        '            nonNumberEntered = True
        '        End If
        '    End If
        'End If

        If e.KeyCode = Keys.Enter Then

            'If IsNumeric(txtHa.Text) = False Then
            '    MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            '    txtHa.Text = "'"
            '    txtHa.Focus()
            'ElseIf IsNumeric(txtHa.Text) = True Then
            '    txtT0.Focus()
            'End If
        ElseIf e.KeyCode = Keys.Escape Then
            txtBrondolan.Focus()
        End If

    End Sub

    Private Sub txtHa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHa.KeyPress
        '' Selasa, 20 Oct 2009, 12:07
        ' ''
        '' Check for the flag being set in the KeyDown event.
        'If nonNumberEntered = True Then
        '    ' Stop the character from being entered into the control since it is non-numerical.
        '    e.Handled = True
        'Else

        '    If e.KeyChar = vbCr Then
        '        If txtHa.Text = "" Then txtHa.Text = "0"
        '        txtBrondolan.Focus()
        '    End If
        'End If


        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) = 46 Then
            Else
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = vbCr Then
            If txtHa.Text = "" Then txtHa.Text = "0"
            txtBrondolan.Focus()
        End If
    End Sub

    Private Sub txtHa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHa.Leave
        ' Selasa, 20 Oct 2009, 15:07
        If txtHa.Text = "" Or txtHa.Text = "." Then
            txtHa.Text = "0"
        End If
    End Sub

    Private Sub dgvDailyActivityDistributionView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyActivityDistributionView.CellDoubleClick
        If dgvDailyActivityDistributionView.Rows.Count = 0 Then
            Return
        End If

        If dgvDailyActivityDistributionView.CurrentCell Is Nothing Then
            Return
        End If

        Dim rowIndex As Integer = dgvDailyActivityDistributionView.CurrentCell.RowIndex
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyActivityDistributionView.DataSource, dgvDailyActivityDistributionView.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        Dim dr As DataRow

        dr = dv.Item(cm.Position).Row

        Me.txtTeam.Text = dr.Item("GangName") 'dgvDailyActivityDistributionView.Rows(rowIndex).Cells("GangNameColumn").Value.ToString()
        Me.lblGangMasterID.Text = dr.Item("GangMasterID") 'dgvDailyActivityDistributionView.Rows(rowIndex).Cells("GangMasterIDColumn").Value.ToString()
        Me.dtpDADate.Value = dr.Item("DistbDate") 'dgvDailyActivityDistributionView.Rows(rowIndex).Cells("DistbDateViewColumn").Value
        ' Selasa, 27 Oct 2009, 09:49
        Me.lblMandorEmpName.Text = dr.Item("Mandor") 'dgvDailyActivityDistributionView.row
        If dr.Item("Krani").ToString <> Nothing Then
            Me.lblKraniEmpName.Text = dr.Item("Krani")
        End If
        Me.lblActivity.Text = dr.Item("Activity")
        ShowDailyActivityDistribution()
        HitungTotalHK()
        HitungTotalOT()
        If Val(txtBalanceTotalHK.Text) = 0 And Val(txtBalanceTotalOT.Text) = 0.0 Then
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
        End If

        tcAvtivity.SelectedTab = tabInput
        If dgvActivity.Rows.Count > 0 Then
            dtpDADate.Enabled = False
        Else
            dtpDADate.Enabled = True
        End If
    End Sub

    Private Sub txtHK_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHK.KeyPress
        ' Selasa, 20 Oct 2009, 16:02
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        'If nonNumberEntered = True Then
        '    ' Stop the character from being entered into the control since it is non-numerical.
        '    e.Handled = True
        'Else

        '    If e.KeyChar = vbCr Then
        '        txtOT.Focus()
        '    End If
        'End If


        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) = 46 Then
            Else
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = vbCr Then
            txtOT.Focus()
        End If
    End Sub

    Private Sub txtHK_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHK.Leave
        ' Selasa, 20 Oct 2009, 15:07
        If txtHK.Text = "" Or txtHK.Text = "." Then
            txtHK.Text = "0"
        End If

    End Sub

    Private Sub txtOT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOT.KeyPress
        ' Selasa, 20 Oct 2009, 16:08
        ' by Dadang Adi H
        '' Check for the flag being set in the KeyDown event.
        'If nonNumberEntered = True Then
        '    ' Stop the character from being entered into the control since it is non-numerical.
        '    e.Handled = True
        'Else


        ' End If

        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) = 46 Then
            Else
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = vbCr Then
            txtHa.Focus()
        End If
    End Sub

    Private Sub txtOT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOT.Leave
        ' Selasa, 20 Oct 2009, 16:10
        If txtOT.Text = "" Or txtOT.Text = "." Then
            txtOT.Text = "0"
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        Me.Close()
    End Sub

    Private Sub btnMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaterial.Click
        Dim childCR As New MaterialsWithTeam()

        ' Ahad, 15 Nov 2009, 19:45
        If IsDailyActivityDistributionWithTeamIsModified() Then

            If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                            "Do you want to save data..", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                SaveDailyActivityDistributionWithTeam()
            Else
                Return
            End If

        End If
        ' END Ahad, 15 Nov 2009, 19:45

        If dgvActivity.Rows.Count > 0 Then
            If dgvActivity.CurrentCell IsNot Nothing Then

                Dim rowIndex As Integer = dgvActivity.CurrentCell.RowIndex

                Dim cm As CurrencyManager = CType(Me.BindingContext(dgvActivity.DataSource, dgvActivity.DataMember), CurrencyManager)
                Dim dv As DataView = CType(cm.List, DataView)
                Dim dr As DataRow = dv.Item(cm.Position).Row

                ' Palani
                Dim strSubBlock As String

                If dr.Item("BlockID") IsNot System.DBNull.Value Then
                    strSubBlock = dr.Item("BlockID")
                Else
                    If dr.Item("StationId") IsNot System.DBNull.Value Then
                        strSubBlock = dr.Item("StationId")
                    Else
                        strSubBlock = ""
                    End If
                End If


                If strSubBlock.Trim().Equals("") Then
                    MessageBox.Show("Material cannot be issued without sub-block or station information", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Material tidak bisa di input tanpa sub block
                    Return
                End If






                childCR.MdiParent = MdiParent
                childCR.Dock = DockStyle.Fill
                'childCR.dtpDate.Value = Me.dtpDADate.Value

                'childCR.lstringctrl = "1" 'untuk TEAM
                childCR.lcoaCode = dr.Item("COACode") 'dgvActivity.Rows(rowIndex).Cells("COACodeColumn").Value.ToString()
                childCR.lcoadescp = dr.Item("COADescp") 'dgvActivity.Rows(rowIndex).Cells("COADescpColumn").Value.ToString()
                childCR.lcoaid = dr.Item("COAID") 'dgvActivity.Rows(rowIndex).Cells("COAID").Value.ToString()
                childCR.MaterialsDate = dtpDADate.Value

                childCR.DailyDistributionID = dr.Item("DailyDistributionID") 'dgvActivity.Rows(rowIndex).Cells("DailyDistributionID").Value.ToString()
                childCR.txtCOACode.Text = dr.Item("COADescp") 'dgvActivity.Rows(rowIndex).Cells("COADescpColumn").Value.ToString()
                childCR.lblCOADescp.Text = dr.Item("COACode") 'dgvActivity.Rows(rowIndex).Cells("COACode").Value.ToString()
                childCR.GangName = txtTeam.Text 'dr.Item("GangName") 'dgvActivity.Rows(rowIndex).Cells("TeamColumn").Value.ToString()
                childCR.GangMasterID = dr.Item("GangMasterID") 'dgvActivity.Rows(rowIndex).Cells("GangMasterID").Value.ToString()

                'Selasa, 27 Oct 2009, 21:59
                childCR.MandoEmprName = lblMandorEmpName.Text
                childCR.KraniEmpName = lblKraniEmpName.Text
                childCR.Show()

            Else
                MessageBox.Show("No Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else

            MessageBox.Show("No Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ' Selasa, 27 Oct 2009, 21:52
        If CallFromDailyAttendance Then
        Else
            ClearInputAll()
            If dgvActivity.Rows.Count > 0 Then
                dtpDADate.Enabled = False
            Else
                dtpDADate.Enabled = True
            End If
        End If

        'dtpDADate.Enabled = True
        If Val(txtBalanceTotalHK.Text) = 0 And Val(txtBalanceTotalOT.Text) = 0 Then
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub dgvActivity_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvActivity.SelectionChanged
        If dgvActivity.Rows.Count > 0 Then
            If dgvActivity.CurrentCell IsNot Nothing Then
                lblSelectedActivity.Text = "Activity- " & dgvActivity.Rows(dgvActivity.CurrentCell.RowIndex).Cells("COADescpColumn").Value.ToString() & " is selected!"
            End If
        End If
    End Sub

    Private Sub txtTeam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTeam.LostFocus
        If txtTeam.Text.Trim <> Nothing Then
            Dim DT As DataTable
            DT = DailyAttendanceWithTeam_DAL.CRGangMasterSelectAll(txtTeam.Text, _
                                                                "", _
                                                                "", _
                                                                dtpDADate.Value)

            If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                lblGangMasterID.Text = String.Empty
                Me.lblActivity.Text = String.Empty
                'DT_DailyAttendanceWithTeam.Clear()

                MessageBox.Show("Team not found.", "Information", MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)
                txtTeam.Text = ""
                txtTotalHK.Text = 0
                txtTotalOT.Text = 0
                txtBalanceTotalHK.Text = 0
                txtBalanceTotalOT.Text = 0
                txtContractNo.Focus()
                dtpDADate.Enabled = True

                ' txtSubBlock.Focus()

            ElseIf DT.Rows.Count = 1 Then

                txtTeam.Text = DT.Rows(0).Item("GangName").ToString()
                lblGangMasterID.Text = DT.Rows(0).Item("GangMasterID").ToString()
                'lblTeamCategory.Text = DT.Rows(0).Item("Category").ToString()
                Me.lblActivity.Text = DT.Rows(0).Item("Activity").ToString()
                If lblActivity.Text.Trim = "PANEN" Then
                    MessageBox.Show("LAIN Activities only " + vbCrLf + _
                      "You can not distribute for PANEN Activities", _
                      "Information", _
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnAdd.Enabled = False
                Else
                    btnAdd.Enabled = True
                End If

                ShowDailyActivityDistribution()
                HitungTotalHK()
                HitungTotalOT()
                txtContractNo.Focus()
                dtpDADate.Enabled = False
                ' txtSubBlock.Focus()
            End If
        End If


    End Sub

    Private Sub txtTeam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTeam.TextChanged

    End Sub

    Private Sub txtSubBlock_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubBlock.LostFocus
        'If txtSubBlock.Text <> Nothing Then

        '    Dim DT As DataTable

        '    DT = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(txtSubBlock.Text)

        '    If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
        '        txtDIV.Text = String.Empty
        '        txtYOP.Text = String.Empty
        '        lblBlockID.Text = String.Empty
        '        lblYOPID.Text = String.Empty
        '        lblDivID.Text = String.Empty

        '        lblStatusBlock.Text = String.Empty
        '        lblDiv.Text = String.Empty
        '        lblYOP.Text = String.Empty

        '        MessageBox.Show("Sub Block not found.", "Information", MessageBoxButtons.OK, _
        '                     MessageBoxIcon.Information)

        '        txtCOACode.Focus()

        '    ElseIf DT.Rows.Count = 1 Then
        '        txtSubBlock.Text = DT.Rows(0).Item("BlockName").ToString()
        '        lblBlockID.Text = DT.Rows(0).Item("BlockID").ToString()

        '        txtDIV.Text = DT.Rows(0).Item("DIVName").ToString()
        '        lblDivID.Text = DT.Rows(0).Item("DivID").ToString()

        '        txtYOP.Text = DT.Rows(0).Item("YOP").ToString()
        '        lblYOPID.Text = DT.Rows(0).Item("YOPID").ToString()
        '        lblStatusBlock.Text = DT.Rows(0).Item("BlockStatus").ToString()
        '        txtCOACode.Focus()


        '    End If
        'End If
    End Sub

    Private Sub chkDateView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateView.CheckedChanged
        dtpDistbDateView.Enabled = chkDateView.Checked
        dtpDistbDateView.Value = GlobalPPT.FiscalYearToDate
    End Sub

    Private Sub txtOvertimeCOACode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOvertimeCOACode.KeyDown
        ' Ahad, 22 Nov 2009, 22:38
        If e.KeyCode = Keys.Enter Then
            If Not txtOvertimeCOACode.Text = String.Empty Then

                Dim DTCOA As DataTable
                DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(txtOvertimeCOACode.Text, lblStatusBlock.Text)

                If DTCOA.Rows.Count = 1 Then

                    txtOvertimeCOACode.Text = DTCOA.Rows(0).Item("COACode").ToString()
                    lblOvertimeCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
                    lblOvertimeCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()
                    LblOToldCOACode.Text = DTCOA.Rows(0).Item("OldCOACode").ToString()
                    txtT0.Focus()

                ElseIf DTCOA.Rows.Count = 0 Or DTCOA.Rows.Count > 1 Then

                    lblOvertimeCOADescp.Text = "Activity Code is not valid"
                    lblOvertimeCOAID.Text = String.Empty
                    LblOToldCOACode.Text = String.Empty

                    txtOvertimeCOACode.Focus()
                End If
            Else
                lblOvertimeCOADescp.Text = String.Empty
                lblOvertimeCOAID.Text = String.Empty
                LblOToldCOACode.Text = String.Empty
                txtOvertimeCOACode.Focus()
            End If
        End If
    End Sub

    Private Sub txtOvertimeCOACode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOvertimeCOACode.Leave
        ' Ahad, 22 Nov 2009, 22:34

        ' Senin, 23 Nov 2009, 00:05 di nonactifkan lagi g jadi kate p Engersaaal
        'Dim DTCOA As DataTable
        'DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(txtOvertimeCOACode.Text, lblStatusBlock.Text)

        'If DTCOA.Rows.Count = 1 Then

        '    txtOvertimeCOACode.Text = DTCOA.Rows(0).Item("COACode").ToString()
        '    lblOvertimeCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
        '    lblOvertimeCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()


        'ElseIf DTCOA.Rows.Count = 0 Or DTCOA.Rows.Count > 1 Then

        '    lblCOADescp.Text = "Activity Code is not valid"
        '    lblCOAID.Text = String.Empty

        'End If

    End Sub



    Private Sub btnOTLookUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTLookUp.Click
        COALookup.strAcctExpenditureAG = lblStatusBlock.Text
        COALookup.ShowDialog()

        If COALookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblOvertimeCOADescp.Text = COALookup.strAcctDescp
            Me.txtOvertimeCOACode.Text = COALookup.strAcctcode
            Me.lblOvertimeCOAID.Text = COALookup.strAcctId
            Me.LblOToldCOACode.Text = COALookup.strOldAccountCode
            ' Me.txtOldCoa.Text = COALookup.strOldAccountCode
            txtHa.Focus()
            'txtHK.Focus()
        End If
    End Sub

    Private Sub txtBrondolan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBrondolan.KeyDown

        '' Selasa, 20 Oct 2009, 12:04
        ''
        '' Initialize the flag to false.
        'nonNumberEntered = False

        '' Determine whether the keystroke is a number from the top of the keyboard.
        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '    ' Determine whether the keystroke is a number from the keypad.
        '    If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '        ' Determine whether the keystroke is a backspace.
        '        If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
        '            ' A non-numerical keystroke was pressed. 
        '            ' Set the flag to true and evaluate in KeyPress event.
        '            nonNumberEntered = True
        '            If txtBrondolan.Text.Trim.Contains(".") Then
        '                isDecimal = False
        '                Return
        '            End If
        '            isDecimal = twoDecimalPlaces.IsMatch(Text)
        '        End If
        '    End If
        'End If

        'If e.KeyCode = Keys.Enter Then

        '    'If IsNumeric(txtHa.Text) = False Then
        '    '    MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        '    '    txtHa.Text = "'"
        '    '    txtHa.Focus()
        '    'ElseIf IsNumeric(txtHa.Text) = True Then
        '    '    txtT0.Focus()
        '    'End If
        'ElseIf e.KeyCode = Keys.Escape Then
        '    txtT0.Focus()
        'End If


        'If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
        '    nonNumberEntered = True
        '    Return
        'End If
        'nonNumberEntered = False
        'If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then
        '    Dim txtBox As TextBox = DirectCast(sender, TextBox)
        '    Dim text As String = String.Empty
        '    If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
        '        Select Case e.KeyCode
        '            Case Keys.[Decimal], Keys.OemPeriod
        '                If txtBox.Text.Trim.Contains(".") Then
        '                    isDecimal = False
        '                    Return
        '                End If
        '                isDecimal = True
        '                Return
        '            Case Else
        '                If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
        '                    text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
        '                End If
        '                If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
        '                    text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
        '                End If
        '                isDecimal = twoDecimalPlaces.IsMatch(text)
        '        End Select
        '    Else
        '        isDecimal = False
        '        Return
        '    End If
        'Else
        '    isDecimal = True
        'End If
    End Sub

    Private Sub txtBrondolan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrondolan.KeyPress
        '' Selasa, 20 Oct 2009, 12:07
        ' ''
        '' Check for the flag being set in the KeyDown event.
        'If nonNumberEntered = True Then
        '    ' Stop the character from being entered into the control since it is non-numerical.
        '    e.Handled = True
        'Else

        '    If e.KeyChar = vbCr Then
        '        If txtBrondolan.Text = "" Then txtBrondolan.Text = "0"
        '        txtT0.Focus()
        '    End If
        'End If

        'If nonNumberEntered Then
        '    e.Handled = True
        '    Return
        'End If
        'If isDecimal = False Then
        '    e.Handled = True
        'Else
        '    e.Handled = False

        'End If
        'If e.KeyChar = vbCr Then
        '    If txtBrondolan.Text = "" Then txtBrondolan.Text = "0"
        '    txtT0.Focus()
        'End If

        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) = 46 Then
            Else
                e.KeyChar = ""
            End If
        End If

        If e.KeyChar = vbCr Then
            If txtBrondolan.Text = "" Then txtBrondolan.Text = "0"
            txtT0.Focus()
        End If
    End Sub

    Private Sub txtBrondolan_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrondolan.Leave
        ' Selasa, 20 Oct 2009, 15:07
        If txtBrondolan.Text = "" Or txtBrondolan.Text = "." Then
            txtBrondolan.Text = "0"
        End If
    End Sub

    Private Sub tcAvtivity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcAvtivity.SelectedIndexChanged
        If tcAvtivity.SelectedIndex = 1 Then
            chkDateView.Checked = False
            dtpDistbDateView.Value = GlobalPPT.FiscalYearToDate
            txtTeamNameView.Text = ""
            txtMandorNameView.Text = ""
            cboActivityView.SelectedIndex = 0
            DoSearch()
        ElseIf tcAvtivity.SelectedIndex = 0 Then

            If dgvActivity.Rows.Count > 0 Then
                dtpDADate.Enabled = False
            Else
                dtpDADate.Enabled = True
            End If

            txtTeam.Focus()
        End If
    End Sub


    Private Sub DailyActivityDistributionWithTeam_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave

        If txtSubBlock.Text.Trim() <> String.Empty Then

            Dim DT As DataTable

            DT = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(txtSubBlock.Text)

            If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                txtDIV.Text = String.Empty
                txtYOP.Text = String.Empty
                lblBlockID.Text = String.Empty
                txtSubBlock.Text = String.Empty
                lblYOPID.Text = String.Empty
                lblDivID.Text = String.Empty

                lblStatusBlock.Text = String.Empty
                lblDiv.Text = String.Empty
                lblYOP.Text = String.Empty

                MessageBox.Show("Field No not found.", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)

                txtCOACode.Focus()

            ElseIf DT.Rows.Count = 1 Then
                txtSubBlock.Text = DT.Rows(0).Item("BlockName").ToString()
                lblBlockID.Text = DT.Rows(0).Item("BlockID").ToString()

                txtDIV.Text = DT.Rows(0).Item("DIVName").ToString()
                lblDivID.Text = DT.Rows(0).Item("DivID").ToString()

                txtYOP.Text = DT.Rows(0).Item("YOP").ToString()
                lblYOPID.Text = DT.Rows(0).Item("YOPID").ToString()
                lblStatusBlock.Text = DT.Rows(0).Item("BlockStatus").ToString()
                txtCOACode.Focus()


            End If
        Else
            txtDIV.Text = String.Empty
            txtYOP.Text = String.Empty
            lblBlockID.Text = String.Empty
            txtSubBlock.Text = String.Empty
            lblYOPID.Text = String.Empty
            lblDivID.Text = String.Empty

            lblStatusBlock.Text = String.Empty
            lblDiv.Text = String.Empty
            lblYOP.Text = String.Empty
        End If
    End Sub

    Private Sub txtOT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOT.TextChanged
        If Val(txtOT.Text) > 0 Then
            lblOTCOA.ForeColor = Color.Red
        Else
            lblOTCOA.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtT4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        btnAdd.Focus()
    End Sub


    Private Sub btnEquipmentLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquipmentLookup.Click
        Dim EquipLookupForm As New EquipmentLookup()

        If EquipLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.lblEquipmentName.Text = EquipLookupForm.psEquipmentName
            Me.txtEquipment.Text = EquipLookupForm.psEquipmentCode

            Me.lblEquipmetID.Text = EquipLookupForm.psEquipmentId

        End If
    End Sub


    Private Sub btnSearchVehicleCode_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVehicleCode.Click
        Cursor = Cursors.WaitCursor
        Dim frmVHNoLookup As New VHNoLookup
        Dim result As DialogResult = frmVHNoLookup.ShowDialog()
        If frmVHNoLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            psVHID = frmVHNoLookup.psVHID
            Me.txtVehicleCode.Text = frmVHNoLookup.psVHWSCode
            Me.lblVehicleDescp.Text = frmVHNoLookup.psVHDesc
            psCategoryID = frmVHNoLookup.psVHCategoryID

            If Not frmVHNoLookup.psVHCategoryType Is DBNull.Value Then
                If frmVHNoLookup.psVHCategoryType = "Vehicle" Then
                    psVHCategoryType = "V"
                End If
                If frmVHNoLookup.psVHCategoryType = "Workshop" Then
                    psVHCategoryType = "W"
                End If
                If frmVHNoLookup.psVHCategoryType = "Others" Then
                    psVHCategoryType = "O"
                End If
            End If
        End If
        Cursor = Cursors.Arrow

    End Sub

    Private Sub btnSearchVehicleDetailCostCode_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchVehicleDetailCostCode.Click
        Cursor = Cursors.WaitCursor
        Dim frmVHDetailsCostCodeLookup As New VHDetailsCostCodeLookup
        frmVHDetailsCostCodeLookup.BindGrid(psVHCategoryType)
        Dim result As DialogResult = frmVHDetailsCostCodeLookup.ShowDialog()
        If frmVHDetailsCostCodeLookup.psVHDetailsCostCodeID <> String.Empty Then
            Me.txtDetailCostCode.Text = frmVHDetailsCostCodeLookup.psVHDetailsCostCode
            psVHDetailCostCodeID = frmVHDetailsCostCodeLookup.psVHDetailsCostCodeID
            lblDetailCostDescp.Text = frmVHDetailsCostCodeLookup.psVHDetailsDesc
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtVehicleCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVehicleCode.TextChanged
        If txtVehicleCode.Text <> String.Empty Then
            txtSubBlock.Text = String.Empty
            txtSubBlock.Enabled = False
            lblStatusBlock.Text = String.Empty
            txtYOP.Text = String.Empty
            txtDIV.Text = String.Empty
            txtDIV.Enabled = False
            txtDIV.Text = String.Empty
            btnSubBlockLookup.Enabled = False
        ElseIf txtStation.Enabled = False Then
            txtSubBlock.Enabled = True
            txtDIV.Enabled = True
            btnSubBlockLookup.Enabled = True
        End If

        If Me.txtVehicleCode.Text = String.Empty Then
            Me.txtDetailCostCode.Text = String.Empty
            Me.lblDetailCostDescp.Text = String.Empty
            Me.txtDetailCostCode.Enabled = False
            Me.btnSearchVehicleDetailCostCode.Enabled = False
        Else
            Me.txtDetailCostCode.Enabled = True
            Me.btnSearchVehicleDetailCostCode.Enabled = True
        End If
        Me.txtDetailCostCode.Text = String.Empty
        Me.lblDetailCostDescp.Text = String.Empty
        psVHDetailCostCodeID = String.Empty

    End Sub


End Class