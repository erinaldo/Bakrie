'
' Programmer: Dadang Adi Hendradi
'
' update: Thursday, 10 Sep 2009, 13:13
' update: Friday, 18 Sep 2009, 21:53
'

Imports CheckRoll_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT

Partial Public Class DailyAttendanceWithTeam

    'Public _GlobatPtt As New GlobalPPT
    'Public ConnectionClass As New Connection
    'Jum'at, 18 Sep 2009, 21:54

    Public Shared lSaveUpdate As String = "Save"

    Private DailyAttendanceTableAdapter As DailyAttendanceWithTeam_DAL = New DailyAttendanceWithTeam_DAL() ' Thursday, 10 SEP 2009, 14:19

    'CODE ADD by Agung
    '--------------------
    Private DailyOTDetailAdapter As OTDetailDAL
    Public DTOT_Detail As DataTable = New DataTable
    Public _Lempid As String = String.Empty
    '------------------------------------------------
    Public dateFromReception As Date
    Private DT_DailyAttendance As DataTable = Nothing
    Private DT_DailyReceiption As DataTable = Nothing

    Private DT_DailyAttendanceOriginal As DataTable = Nothing ' Sabtu, 19 Sep 2009, 01:03

    Private DT_DailyAttendanceWithTeamView As DataTable = Nothing
    Private rowIndex_dgvDailyAttendance As Integer

    Private dRateSetup_BasicRate As Decimal = 0
    Private iRateSetup_OTDivider As Integer = 173
    Private iRateSetup_RiceDividerDays As Integer = 30 ' Ahad, 22 Nov 2009, 21:12
    Private iRateSetup_RicePrice As Decimal = 135000 ' Stores RicePrice * Rice Employee, default to rp9000 * 15kg

    Private dOTResult As Decimal = 0
    Public Rowindex As Integer

    ' Selasa, 20 Oct 2009, 16:15
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False

    ' Saturday, 24 Oct 2009, 17:28
    Private ActiveMonthLogin As Integer
    Private ActiveYearLogin As Integer

    ' Minggu, 11 Nov 2009, 13:37
    Private boolBtnActivityMustTemporaryEnable As Boolean = False
    Private boolDateChk As Boolean = False


    ' Sabtu, 21 Nov 2009, 14:06
    Private MsgViewReceiptionBeforeSave As String = String.Empty

    'Private Sub WorkShopLogFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub


    Private Sub DailyAttendanceFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)

        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        '   dtpRDate.Value = Format(dtpRDate.Value, "dd/MM/yyyy")
        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
        Dim lSaveUpDate As String = ""
        lSaveUpDate = DailyAttendanceWithTeam.lSaveUpdate

        ' Jum'at, 18 Sep 2009, 22:21
        DT_DailyAttendance = DailyAttendanceTableAdapter.DailyAttendanceWithTeamSelect("", dtpRDate.Value, "Save")
        ' dgvDailyAttendance.AutoGenerateColumns = True
        dgvDailyAttendance.DataSource = DT_DailyAttendance
        LoadVisible()
        ManageDailyAttendanceGridColumn()

        lblDailyTeamActivityID.Text = String.Empty
        lblActivity.Text = String.Empty
        lblGangMasterID.Text = String.Empty
        lblMandorEmpName.Text = String.Empty
        lblKraniEmpName.Text = String.Empty

        lblEmpName.Text = String.Empty
        lblAttendanceSetupID.Text = String.Empty
        lblAttendType.Text = String.Empty
        LblBasicPay.Text = String.Empty
        lblEmpCategory.Text = String.Empty
        lblDistributionSetupID.Text = String.Empty

        ' Ahad, 18 Oct 2009, 22:56
        ' Sabtu, 24 Oct 2009, 17:30
        ActiveMonthLogin = GlobalPPT.IntActiveMonth 'Convert.ToInt32(GlobalPPT.strLoginMonth.Substring(0, GlobalPPT.strLoginMonth.IndexOf("-")))
        ActiveYearLogin = GlobalPPT.intActiveYear

        dgvDailyAWTView.AutoGenerateColumns = False
        Dim d As Date

        d = New Date(ActiveYearLogin, ActiveMonthLogin, 1)

        DT_DailyAttendanceWithTeamView = DailyAttendanceWithTeam_DAL.CRDailyAttendanceWithTeamView( _
        True, "", "", "", d, GlobalPPT.strCategoryField)        

        If GlobalPPT.strCategoryField = "OilPalm" Then
            cboActivityView.Items.Clear()
            cboActivityView.Items.Add("All")
            cboActivityView.Items.Add("PANEN")
            cboActivityView.Items.Add("LAIN")
        ElseIf GlobalPPT.strCategoryField = "Rubber" Then
            cboActivityView.Items.Clear()
            cboActivityView.Items.Add("All")
            cboActivityView.Items.Add("DERES")
        End If

        dgvDailyAWTView.DataSource = DT_DailyAttendanceWithTeamView
        'Dim category As String = DT_DailyAttendanceWithTeamView.Rows(0).Item("category").ToString()
        'ManageDailyAttendanceViewColumn()

        tcDailyAttendance.SelectedTab = tabView

        'MessageBox.Show("Login Month:  " + GlobalPPT.IntLoginMonth.ToString())
        'MessageBox.Show("Active Month: " + GlobalPPT.IntActiveMonth.ToString())

        'If (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth) Then
        '    MessageBox.Show("Your  transaction has been closed, only View Report screen will be enabled in the future", _
        '                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        'ElseIf GlobalPPT.IntLoginMonth > GlobalPPT.IntActiveMonth Then

        '    MessageBox.Show("Your Transaction has not been closed yet, in the future this screen will be disabled", _
        '                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        ' Saturday, 25 Oct 2009, 13:34
        dtpRDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpRDate.MaxDate = GlobalPPT.FiscalYearToDate

        dtpRDateView.MinDate = GlobalPPT.FiscalYearFromDate
        dtpRDateView.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpRDate.Value
        Dim NowDate As Date = Now

        If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
            dtpRDate.Value = Now()
            dtpRDateView.Value = Now()
        End If
        cboActivityView.SelectedIndex = 0 ' pilih All sebagai default
        dgvDailyAttendance.DefaultCellStyle.BackColor = Color.White
        dgvDailyAWTView.DefaultCellStyle.BackColor = Color.White

        'CODE ADD by Agung
        '--------------------

        DailyOTDetailAdapter = New OTDetailDAL
        Dim DTOT_Detail As DataTable = New DataTable
        DTOT_Detail = OTDetailBOL.OTDetailViewTeam(lblMandoreID.Text, lblKraniID.Text, dtpRDate.Value)
        DgvOTDetail.DataSource = DTOT_Detail

        txtTeamNameView.Focus()

        'TextBox1.Text = Now.DayOfWeek.ToString().ToUpper().Substring(0, 3)
    End Sub

    Private Sub LoadVisible()
        'dgvDailyAttendance.Columns("JjgActualNormal").Visible = False
        'dgvDailyAttendance.Columns("JjgActualBorongan").Visible = False
        'dgvDailyAttendance.Columns("BrdNormal").Visible = False
        'dgvDailyAttendance.Columns("BrdBorongan").Visible = False

        ' If dgvDailyAttendance.Columns.Contains("LooseFruitNormal") Then
        dgvDailyAttendance.Columns("LooseFruitNormal").Visible = False

        dgvDailyAttendance.Columns("LooseFruitBorongan").Visible = False
        dgvDailyAttendance.Columns("HarvestedNormal").Visible = False
        dgvDailyAttendance.Columns("HarvestedBorongan").Visible = False

        'dgvDailyAttendance.Columns("prestasi").Visible = False
        'dgvDailyAttendance.Columns("Brondolan").Visible = False

        dgvDailyAttendance.Columns("CreatedBy").Visible = False
        dgvDailyAttendance.Columns("CreatedOn").Visible = False
        dgvDailyAttendance.Columns("ModifiedBy").Visible = False
        dgvDailyAttendance.Columns("ModifiedOn").Visible = False
        dgvDailyAttendance.Columns("DAConcurrencyIdColumn").Visible = False
        dgvDailyAttendance.Columns("EstateCode").Visible = False

        dgvDailyAttendance.Columns("DADistributionSetupIDColumn").Visible = False

        dgvDailyAttendance.Columns("DailyReceiptionID").Visible = False

        dgvDailyAttendance.Columns("ActiveMonthYearID").Visible = False
        dgvDailyAttendance.Columns("EmpID").Visible = False
        dgvDailyAttendance.Columns("EstateID").Visible = False
        dgvDailyAttendance.Columns("DailyTeamActivityID").Visible = False

        dgvDailyAttendance.Columns("OtherEstateEmpNo").Visible = False
        dgvDailyAttendance.Columns("OtherEstateName").Visible = False
        dgvDailyAttendance.Columns("DAAttendanceSetupIDColumn").Visible = False

        dgvDailyAttendance.Columns("DATotalOTColumn").ValueType = GetType(Decimal)
        dgvDailyAttendance.Columns("dgcCategory").Visible = True
        dgvDailyAttendance.Columns("BasicPay").Visible = False

        dgvDailyAttendance.Columns("Latex").Visible = False
        dgvDailyAttendance.Columns("CupLump").Visible = False
        dgvDailyAttendance.Columns("TreeLace").Visible = False

        'End If
        lblBrondalan.Visible = False
        lblBrondalanValue.Visible = False
        lblHa.Visible = False
        lblHaValue.Visible = False

        lblTotalHK.Visible = False
        lblTotalOT.Visible = False
        lblLTotalHK.Visible = False
        lblLTotalOT.Visible = False


        lblBrdB.Visible = False
        lblBrdN.Visible = False
        lblJJGActB.Visible = False
        lblJJGActN.Visible = False
        lblJjgActualNormal.Visible = False
        lblJjgActualBorongan.Visible = False
        lblBrdNormal.Visible = False
        lblBrdBorongan.Visible = False

        'stanley@09-12-2011
        LblLTtlHK.Visible = False
        LblTtlHK.Visible = False

    End Sub


    Public Overloads Sub Show(ByVal dtpRDateFrmReception As DateTime, _
           ByVal TeamName As String, _
           ByVal EmpID As String, _
           ByVal NIK As String, _
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
        ByVal parent As IWin32Window, Optional dtRow As DataRow = Nothing)

        Me.MdiParent = parent
        Me.Dock = DockStyle.Fill
        Me.Show()
        drTemp = dtRow
        Me.dtpRDate.Value = dtpRDateFrmReception
        Me.lblDailyTeamActivityID.Text = DailyTeamActivityID
        Me.lblActivity.Text = Activity
        Me.txtTeam.Text = TeamName
        Me.lblGangMasterID.Text = GangMasterID
        Me.lblEmpCategory.Text = Category
        lblMandoreID.Text = MandoreID
        lblMandorEmpName.Text = MandorName
        lblKraniID.Text = KraniID
        lblKraniEmpName.Text = KraniName
        dateFromReception = dtpRDateFrmReception
        lSaveUpdate = "Update"
        DT_DailyAttendance = DailyAttendanceTableAdapter.DailyAttendanceWithTeamSelect("", dateFromReception, lSaveUpdate)
        dgvDailyAttendance.DataSource = DT_DailyAttendance

        '  dgvDailyAttendance.DataSource = DT_DailyAttendance


        dgvDailyAttendance.Columns("CreatedBy").Visible = False
        dgvDailyAttendance.Columns("CreatedOn").Visible = False
        dgvDailyAttendance.Columns("ModifiedBy").Visible = False
        dgvDailyAttendance.Columns("ModifiedOn").Visible = False
        dgvDailyAttendance.Columns("DAConcurrencyIdColumn").Visible = False
        dgvDailyAttendance.Columns("EstateCode").Visible = False

        dgvDailyAttendance.Columns("DADistributionSetupIDColumn").Visible = False
        dgvDailyAttendance.Columns("DailyReceiptionID").Visible = False
        dgvDailyAttendance.Columns("ActiveMonthYearID").Visible = False
        dgvDailyAttendance.Columns("EmpID").Visible = False
        dgvDailyAttendance.Columns("EstateID").Visible = False
        dgvDailyAttendance.Columns("DailyTeamActivityID").Visible = False

        dgvDailyAttendance.Columns("OtherEstateEmpNo").Visible = False
        dgvDailyAttendance.Columns("OtherEstateName").Visible = False
        dgvDailyAttendance.Columns("DAAttendanceSetupIDColumn").Visible = False

        dgvDailyAttendance.Columns("DATotalOTColumn").ValueType = GetType(Decimal)
        dgvDailyAttendance.Columns("dgcCategory").Visible = True
        dgvDailyAttendance.Columns("BasicPay").Visible = False
        ' Senin, 21 Sep 2009, 20:59
        If lblActivity.Text.ToUpper = "PANEN" Then
            ForPanenVisible()
            btnActivity.Enabled = False
            ' txtOTHours.Enabled = False
            txtOTHours.Text = "0"

        ElseIf lblActivity.Text.ToUpper = "LAIN" Then
            ForLainVisible()
        ElseIf lblActivity.Text.ToUpper = "DERES" Then
            ForDeresVisible()
            btnActivity.Enabled = False
        End If

        boolDateChk = True
        showAllTeamMember()
        boolDateChk = False
        ManageDailyAttendanceGridColumn()
        tcDailyAttendance.SelectedIndex = 0

        'DTOT_Detail = OTDetailBOL.OTDetailViewTeam(lblMandoreID.Text, lblKraniID.Text, dtpRDate.Value)
        'DgvOTDetail.DataSource = DTOT_Detail

    End Sub

    Public Overloads Sub ShowFromActivity(ByVal dtpRDateFrmActivity As Date, _
           ByVal TeamName As String, _
           ByVal TotalOT As String, _
           ByVal DailyTeamActivityID As String, _
           ByVal Activity As String, _
          ByVal GangMasterID As String, _
          ByVal MandoreID As String, _
          ByVal KraniID As String, _
          ByVal MandorName As String, _
          ByVal KraniName As String, _
           ByVal EmpCategory As String, _
          ByVal parent As IWin32Window)


        Me.MdiParent = parent
        Me.Dock = DockStyle.Fill
        Me.Show()
        Me.dtpRDate.Value = dtpRDateFrmActivity
        Me.lblDailyTeamActivityID.Text = DailyTeamActivityID
        Me.lblActivity.Text = Activity
        Me.txtTeam.Text = TeamName
        Me.lblGangMasterID.Text = GangMasterID
        Me.lblEmpCategory.Text = EmpCategory
        lblMandoreID.Text = MandoreID
        lblMandorEmpName.Text = MandorName
        lblKraniID.Text = KraniID
        lblKraniEmpName.Text = KraniName
        'dateFromReception = dtpRDateFrmActivity
        lSaveUpdate = "Update"
        DT_DailyAttendance = DailyAttendanceTableAdapter.DailyAttendanceWithTeamSelect("", dateFromReception, lSaveUpdate)
        dgvDailyAttendance.DataSource = DT_DailyAttendance


        dgvDailyAttendance.Columns("CreatedBy").Visible = False
        dgvDailyAttendance.Columns("CreatedOn").Visible = False
        dgvDailyAttendance.Columns("ModifiedBy").Visible = False
        dgvDailyAttendance.Columns("ModifiedOn").Visible = False
        dgvDailyAttendance.Columns("DAConcurrencyIdColumn").Visible = False
        dgvDailyAttendance.Columns("EstateCode").Visible = False

        dgvDailyAttendance.Columns("DADistributionSetupIDColumn").Visible = False
        dgvDailyAttendance.Columns("DailyReceiptionID").Visible = False
        dgvDailyAttendance.Columns("ActiveMonthYearID").Visible = False
        dgvDailyAttendance.Columns("EmpID").Visible = False
        dgvDailyAttendance.Columns("EstateID").Visible = False
        dgvDailyAttendance.Columns("DailyTeamActivityID").Visible = False

        dgvDailyAttendance.Columns("OtherEstateEmpNo").Visible = False
        dgvDailyAttendance.Columns("OtherEstateName").Visible = False
        dgvDailyAttendance.Columns("DAAttendanceSetupIDColumn").Visible = False

        dgvDailyAttendance.Columns("DATotalOTColumn").ValueType = GetType(Decimal)
        'dgvDailyAttendance.Columns("Category").Visible = False
        dgvDailyAttendance.Columns("BasicPay").Visible = False
        ' Senin, 21 Sep 2009, 20:59
        If lblActivity.Text.ToUpper = "PANEN" Then
            ForPanenVisible()
            btnActivity.Enabled = False
            'txtOTHours.Enabled = False
            txtOTHours.Text = "0"

        ElseIf lblActivity.Text.ToUpper = "LAIN" Then
            ForLainVisible()
        ElseIf lblActivity.Text.ToUpper = "DERES" Then
            ForDeresVisible()
            btnActivity.Enabled = False
        End If

        'boolDateChk = True
        showAllTeamMember()
        'boolDateChk = False
        ManageDailyAttendanceGridColumn()
        tcDailyAttendance.SelectedIndex = 0

    End Sub


    'Private Sub UpdateOTSummary()
    '    Try


    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT1") = FormatNumber(Val(txtH1.Text), 2)
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue1") = FormatNumber((Val(txtH1.Text) * Val(txtOT1.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT2") = FormatNumber(Val(txtH2.Text), 2)
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue2") = FormatNumber((Val(txtH2.Text) * Val(txtOT2.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT3") = FormatNumber(Val(txtH3.Text), 2)
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue3") = FormatNumber((Val(txtH3.Text) * Val(txtOT3.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT4") = FormatNumber(Val(txtH4.Text), 2)
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue4") = FormatNumber((Val(txtH4.Text) * Val(txtOT4.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("ModifiedBy") = GlobalPPT.strUserName
    '        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("ModifiedOn") = dtpRDate.Value
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub

    Private Sub AddOTGrid()
        Dim newdatarow As System.Data.DataRow
        ' By Dadang Adi H
        ' Jum'at, 12 Mar 2010, 15:18
        Dim dOT1 As Double
        Dim dOT1value As Double

        Dim dOT2 As Double
        Dim dOT2value As Double

        Dim dOT3 As Double
        Dim dOT3value As Double

        Dim dOT4 As Double
        Dim dOT4value As Double

        Dim BasicOT As Double ' Kamis, 18 Mar 2010, 15:36
        'DTOT_Detail = DgvOTDetail.DataSource
        'Sai Comment : Change Here
        ' By Dadang Adi H
        ' Kamis, 18 Mar 2010, 15:46

        If iRateSetup_OTDivider = 0 Then
            BasicOT = 0
        Else
            BasicOT = ((Convert.ToDouble(txtBasicRate.Text) * iRateSetup_RiceDividerDays) + iRateSetup_RicePrice) / iRateSetup_OTDivider
            'BasicOT = Math.Round(BasicOT, 0)
        End If

        'If BasicOT = -1.Then Then
        '    BasicOT = 0
        'End If

        If DTOT_Detail.Rows.Count = 0 Then
            DTOT_Detail = OTDetailBOL.OTDetailViewTeam("XXX", "XXX", dtpRDate.Value)
            ' DgvOTDetail.DataSource = DTOT_Detail
        End If

        newdatarow = DTOT_Detail.NewRow
        newdatarow.Item("EstateID") = GlobalPPT.strEstateID
        newdatarow.Item("Estatecode") = GlobalPPT.strEstateCode
        newdatarow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        newdatarow.Item("GangMasterID") = lblGangMasterID.Text
        newdatarow.Item("Activity") = lblActivity.Text
        newdatarow.Item("MandoreID") = lblMandoreID.Text

        If lblKraniID.Text <> Nothing Then
            newdatarow.Item("KraniID") = lblKraniID.Text
        End If

        newdatarow.Item("ADate") = dtpRDate.Value
        newdatarow.Item("EmpID") = lblEmpId.Text

        ' OT1
        dOT1 = Convert.ToDouble(txtH1.Text)
        dOT1value = dOT1 * Convert.ToDouble(txtOT1.Text) * BasicOT

        newdatarow.Item("OT1") = Math.Round(dOT1, 2)
        newdatarow.Item("OTValue1") = Math.Round(dOT1value, 2)

        ' OT2
        dOT2 = Convert.ToDouble(txtH2.Text)
        dOT2value = dOT2 * Convert.ToDouble(txtOT2.Text) * BasicOT

        newdatarow.Item("OT2") = Math.Round(dOT2, 2)
        newdatarow.Item("OTValue2") = Math.Round(dOT2value, 2)

        'OT3
        dOT3 = Convert.ToString(txtH3.Text)
        dOT3value = dOT3 * Convert.ToDouble(txtOT3.Text) * BasicOT

        newdatarow.Item("OT3") = Math.Round(dOT3, 2)
        newdatarow.Item("OTValue3") = Math.Round(dOT3value, 2)

        'OT4
        dOT4 = Convert.ToString(txtH4.Text)
        dOT4value = dOT4 * Convert.ToDouble(txtOT4.Text) * BasicOT

        newdatarow.Item("OT4") = Math.Round(dOT4, 2)
        newdatarow.Item("OTValue4") = Math.Round(dOT4value, 2)
        ' END Jum'at, 12 Mar 2010, 15:18

        'newdatarow.Item("OT1") = FormatNumber(Val(txtH1.Text), 3)
        'newdatarow.Item("OTValue1") = FormatNumber((Val(txtH1.Text) * Val(txtOT1.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
        'newdatarow.Item("OT2") = FormatNumber(Val(txtH2.Text), 3)
        'newdatarow.Item("OTValue2") = FormatNumber((Val(txtH2.Text) * Val(txtOT2.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
        'newdatarow.Item("OT3") = FormatNumber(Val(txtH3.Text), 3)
        'newdatarow.Item("OTValue3") = FormatNumber((Val(txtH3.Text) * Val(txtOT3.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
        'newdatarow.Item("OT4") = FormatNumber(Val(txtH4.Text), 3)
        'newdatarow.Item("OTValue4") = FormatNumber((Val(txtH4.Text) * Val(txtOT4.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3) * 1000
        newdatarow.Item("CreatedBy") = GlobalPPT.strUserName
        newdatarow.Item("CreatedOn") = dtpRDate.Value
        newdatarow.Item("ModifiedBy") = GlobalPPT.strUserName
        newdatarow.Item("ModifiedOn") = dtpRDate.Value

        DTOT_Detail.Rows.Add(newdatarow)

    End Sub

    Private Sub ManageDailyAttendanceViewColumn()
        ' Saturday, 24 Oct 2009, 19:27
        dgvDailyAWTView.Columns("MandoreIDViewColumn").Visible = False
        dgvDailyAWTView.Columns("KraniIDViewColumn").Visible = False
        dgvDailyAWTView.Columns("DailyTeamActivityIDViewColumn").Visible = False
        'dgvDailyAWTView.Columns("GangMasterID").Visible = False
        dgvDailyAWTView.Columns("RDateViewColumn").DisplayIndex = 0
        dgvDailyAWTView.Columns("GangNameViewColumn").DisplayIndex = 1
        dgvDailyAWTView.Columns("MandorViewColumn").DisplayIndex = 2
        dgvDailyAWTView.Columns("KraniViewColumn").DisplayIndex = 3
        dgvDailyAWTView.Columns("ActivityViewColumn").DisplayIndex = 4
        'dgvDailyAWTView.Columns("GangMasterID").DisplayIndex = 5
        dgvDailyAWTView.Columns("MandoreIDViewColumn").DisplayIndex = 5
        dgvDailyAWTView.Columns("KraniIDViewColumn").DisplayIndex = 6
    End Sub

    Private Sub DailyAttendanceWithTeam_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Kamis, 01 Oct 2009, 02:10
        If (IsNothing(DT_DailyAttendance)) Then Return
        Dim ModifiedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False


        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        If Modified Then
            If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                            "Do you want to save this data..", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                SaveDailyAttendance()

            End If
        End If

    End Sub

    Public Sub ManageDailyAttendanceGridColumn()
        ' Senin, 29 Sep 2009, 21:04
        'dgvDailyAttendance.Columns("DARDateColumn").DisplayIndex = 0
        'dgvDailyAttendance.Columns("DAGangNameColumn").DisplayIndex = 1
        'dgvDailyAttendance.Columns("DAEmpCodeColumn").DisplayIndex = 2
        'dgvDailyAttendance.Columns("DAEmpNameColumn").DisplayIndex = 3
        'dgvDailyAttendance.Columns("DAAttendanceCodeColumn").DisplayIndex = 7
        'dgvDailyAttendance.Columns("DADistributionSetupIDColumn").DisplayIndex = 5
        'dgvDailyAttendance.Columns("DADistributionColumn").DisplayIndex = 6
        'dgvDailyAttendance.Columns("dgcOldNIK").DisplayIndex = 4        
        'dgvDailyAttendance.Columns("DATotalOTColumn").DisplayIndex = 8
        'dgvDailyAttendance.Columns("DAColumnTotalOTValue").DisplayIndex = 10


        dgvDailyAttendance.Columns("DARDateColumn").DisplayIndex = 0
        dgvDailyAttendance.Columns("DAGangNameColumn").DisplayIndex = 1
        dgvDailyAttendance.Columns("DAEmpCodeColumn").DisplayIndex = 2
        dgvDailyAttendance.Columns("dgcOldNIK").DisplayIndex = 3
        dgvDailyAttendance.Columns("DAEmpNameColumn").DisplayIndex = 4
        dgvDailyAttendance.Columns("dgcCategory").DisplayIndex = 5
        dgvDailyAttendance.Columns("DAAttendanceCodeColumn").DisplayIndex = 8
        dgvDailyAttendance.Columns("DADistributionSetupIDColumn").DisplayIndex = 6
        dgvDailyAttendance.Columns("DADistributionColumn").DisplayIndex = 7
        dgvDailyAttendance.Columns("DATotalOTColumn").DisplayIndex = 9
        dgvDailyAttendance.Columns("DAColumnTotalOTValue").DisplayIndex = 10
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DailyAttendanceWithTeam))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDate.Text = rm.GetString("lblDate.Text")
            lblBNik.Text = rm.GetString("lblNik.Text")
            lblAttCode.Text = rm.GetString("lblAttCode.Text")
            lblName.Text = rm.GetString("lblName.Text")
            lblLocation.Text = rm.GetString("lblLocation.Text")
            'LblStation.Text = rm.GetString("LblStation.Text")
            'LblVehicleCode.Text = rm.GetString("LblVehicleCode.Text")
            'LblActivityCode.Text = rm.GetString("LblActivityCode.Text")

            tcDailyAttendance.TabPages(0).Text = rm.GetString("tcDailyAttendance.TabPages(0).Text")
            tcDailyAttendance.TabPages(1).Text = rm.GetString("tcDailyAttendance.TabPages(1).Text")
            lblviewDate.Text = rm.GetString("lblviewDate.Text")
            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")


            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")

            ' Sabtu, 21 Nov 2009, 14:49
            MsgViewReceiptionBeforeSave = rm.GetString("MsgViewReceiptionBeforeSave")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub

    Private Sub btnTeamLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTeamLookup.Click
        ' Jum'at, 18 Sep 2009, 21:44
        Dim TeamLookupForm As New TeamLookUps()

        TeamLookupForm.DDate = dtpRDate.Value
        TeamLookupForm.ShowDialog()

        If TeamLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            dtpRDate.Enabled = False
            ' Saturday, 25 Oct 2009, 12:26
            ' The date for RDate in DailyAttendance must be in range in FiscalFromDT dan FiscalToDate
            Dim FiscalFromDT As Date
            Dim FiscalToDate As Date

            FiscalFromDT = GlobalPPT.FiscalYearFromDate
            FiscalToDate = GlobalPPT.FiscalYearToDate

            'If dtpRDate.Value < FiscalFromDT Or dtpRDate.Value > FiscalToDate Then

            '    MessageBox.Show("Date is not between Fiscal Period / Active Month & Year", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    dtpRDate.Focus()
            '    Return
            'End If

            '===============================
            ' Pencegahan
            '==============================
            Dim ModifiedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
            Dim AddedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Added)
            Dim DeletedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

            Dim Modified As Boolean = False


            If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
                'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
                'didalam DT_DailyAttendance
                Modified = True
            End If

            If Modified Then
                If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                                "Do you want to save this data..", "Warning", _
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                              Windows.Forms.DialogResult.Yes Then
                    'save data
                    SaveDailyAttendance()
                End If
            End If
            ''''''
            ' End of Pencegahan


            Me.lblDailyTeamActivityID.Text = TeamLookupForm.DailyTeamActivityID
            Me.lblActivity.Text = TeamLookupForm.Activity
            Me.txtTeam.Text = TeamLookupForm.GangName
            Me.lblGangMasterID.Text = TeamLookupForm.GangMasterID
            Me.lblEmpCategory.Text = TeamLookupForm.Category


            lblMandoreID.Text = TeamLookupForm.MandorID
            lblMandorEmpName.Text = TeamLookupForm.MandorEmpName
            lblKraniID.Text = TeamLookupForm.KraniID
            lblKraniEmpName.Text = TeamLookupForm.KraniEmpName


            ' Senin, 21 Sep 2009, 20:59
            If lblActivity.Text.ToUpper = "PANEN" Then
                ForPanenVisible()
                btnActivity.Enabled = False
                'txtOTHours.Enabled = False
                txtOTHours.Text = "0"

            ElseIf lblActivity.Text.ToUpper = "LAIN" Then
                dgvDailyAttendance.Columns("DADistributionColumn").Visible = False
                ForLainVisible()
                ' Ahad, 15 Nov 2009, 10:35
                ' saya rubah btnActivity to false
                'btnActivity.Enabled = True
                'btnActivity.Enabled = False
                ' END Ahad, 15 Nov 2009, 10:35
            ElseIf lblActivity.Text.ToUpper = "DERES" Then
                ForDeresVisible()
                btnActivity.Enabled = False
            End If
            Dim dt As DataTable = DailyAttendanceTableAdapter.DailyAttendanceTeamExist(lblDailyTeamActivityID.Text)
            If dt.Rows.Count > 0 Then
                lSaveUpdate = "Update"
            Else
                lSaveUpdate = "Save"
            End If

            showAllTeamMember()


            'ManageDailyAttendanceGridColumn()
            DTOT_Detail = OTDetailBOL.OTDetailViewTeam(lblMandoreID.Text, lblKraniID.Text, dtpRDate.Value)
            DgvOTDetail.DataSource = DTOT_Detail
            btnSaveAll.Focus()

        End If

    End Sub

    Public Sub ForPanenVisible()
        'If dgvDailyAttendance.Columns.Contains("LooseFruitNormal") Then
        dgvDailyAttendance.Columns("DADistributionColumn").Visible = True

        'dgvDailyAttendance.Columns("JjgActualNormal").Visible = True
        'dgvDailyAttendance.Columns("JjgActualBorongan").Visible = True
        'dgvDailyAttendance.Columns("BrdNormal").Visible = True
        'dgvDailyAttendance.Columns("BrdBorongan").Visible = True

        dgvDailyAttendance.Columns("LooseFruitNormal").Visible = True
        dgvDailyAttendance.Columns("LooseFruitBorongan").Visible = True
        dgvDailyAttendance.Columns("HarvestedNormal").Visible = True
        dgvDailyAttendance.Columns("HarvestedBorongan").Visible = True

        dgvDailyAttendance.Columns("DATotalOTColumn").Visible = True

        dgvDailyAttendance.Columns("Latex").Visible = False
        dgvDailyAttendance.Columns("CupLump").Visible = False
        dgvDailyAttendance.Columns("TreeLace").Visible = False

        'End If


        'dgvDailyAttendance.Columns("prestasi").Visible = False
        'dgvDailyAttendance.Columns("Brondolan").Visible = False
        lblBrdB.Visible = True
        lblBrdN.Visible = True
        lblJJGActB.Visible = True
        lblJJGActN.Visible = True
        lblJjgActualNormal.Visible = True
        lblJjgActualBorongan.Visible = True
        lblBrdNormal.Visible = True
        lblBrdBorongan.Visible = True

        'stanley@09-12-2011
        LblLTtlHK.Visible = False
        LblTtlHK.Visible = False

        lblBrondalan.Visible = False
        lblBrondalanValue.Visible = False
        lblHa.Visible = False
        lblHaValue.Visible = False


        lblTotalHK.Visible = True
        lblTotalOT.Visible = True
        lblLTotalHK.Visible = True
        lblLTotalOT.Visible = True


        lblTotalLatex.Visible = False
        lblTotalCupLump.Visible = False
        lblTotalTreelace.Visible = False

        'If lblActivity.Text = "LAIN" Then
        '    txtOTHours.Enabled = True
        'ElseIf lblActivity.Text = "PANEN" Then
        '    txtOTHours.Enabled = False
        'End If
    End Sub

    Public Sub ForLainVisible()
        'If dgvDailyAttendance.Columns.Contains("LooseFruitNormal") Then
        dgvDailyAttendance.Columns("DADistributionColumn").Visible = False

        dgvDailyAttendance.Columns("LooseFruitNormal").Visible = False
        dgvDailyAttendance.Columns("LooseFruitBorongan").Visible = False
        dgvDailyAttendance.Columns("HarvestedNormal").Visible = False
        dgvDailyAttendance.Columns("HarvestedBorongan").Visible = False

        dgvDailyAttendance.Columns("DATotalOTColumn").Visible = True

        dgvDailyAttendance.Columns("Latex").Visible = False
        dgvDailyAttendance.Columns("CupLump").Visible = False
        dgvDailyAttendance.Columns("TreeLace").Visible = False
        'End If

        'dgvDailyAttendance.Columns("prestasi").Visible = True
        'dgvDailyAttendance.Columns("Brondolan").Visible = True
        lblBrdB.Visible = False
        lblBrdN.Visible = False
        lblJJGActB.Visible = False
        lblJJGActN.Visible = False
        lblJjgActualNormal.Visible = False
        lblJjgActualBorongan.Visible = False
        lblBrdNormal.Visible = False
        lblBrdBorongan.Visible = False

        'stanley@09-12-2011
        LblLTtlHK.Visible = False
        LblTtlHK.Visible = False

        lblBrondalan.Visible = True
        lblBrondalanValue.Visible = True
        lblHa.Visible = True
        lblHaValue.Visible = True

        lblTotalHK.Visible = True
        lblTotalOT.Visible = True
        lblLTotalHK.Visible = True
        lblLTotalOT.Visible = True


        lblTotalLatex.Visible = False
        lblTotalCupLump.Visible = False
        lblTotalTreelace.Visible = False
        'If lblActivity.Text = "LAIN" Then
        '    txtOTHours.Enabled = True
        'ElseIf lblActivity.Text = "PANEN" Then
        '    txtOTHours.Enabled = False
        'End If
    End Sub
    Public Sub ForDeresVisible()
        'If dgvDailyAttendance.Columns.Contains("LooseFruitNormal") Then
        dgvDailyAttendance.Columns("DADistributionColumn").Visible = True

        dgvDailyAttendance.Columns("LooseFruitNormal").Visible = False
        dgvDailyAttendance.Columns("LooseFruitBorongan").Visible = False
        dgvDailyAttendance.Columns("HarvestedNormal").Visible = False
        dgvDailyAttendance.Columns("HarvestedBorongan").Visible = False

        dgvDailyAttendance.Columns("DATotalOTColumn").Visible = True
        dgvDailyAttendance.Columns("Latex").Visible = True
        dgvDailyAttendance.Columns("CupLump").Visible = True
        dgvDailyAttendance.Columns("TreeLace").Visible = True
        'End If

        'dgvDailyAttendance.Columns("prestasi").Visible = True
        'dgvDailyAttendance.Columns("Brondolan").Visible = True
        lblBrdB.Visible = False
        lblBrdN.Visible = False
        lblJJGActB.Visible = False
        lblJJGActN.Visible = False
        lblJjgActualNormal.Visible = False
        lblJjgActualBorongan.Visible = False
        lblBrdNormal.Visible = False
        lblBrdBorongan.Visible = False

        'stanley@09-12-2011
        LblLTtlHK.Visible = False
        LblTtlHK.Visible = False

        lblBrondalan.Visible = False
        lblBrondalanValue.Visible = False
        lblHa.Visible = False
        lblHaValue.Visible = False

        lblTotalHK.Visible = True
        lblTotalOT.Visible = True
        lblLTotalHK.Visible = True
        lblLTotalOT.Visible = True

        lblTotalLatex.Visible = True
        lblTotalCupLump.Visible = True
        lblTotalTreelace.Visible = True

        'If lblActivity.Text = "LAIN" Then
        '    txtOTHours.Enabled = True
        'ElseIf lblActivity.Text = "PANEN" Then
        '    txtOTHours.Enabled = False
        'End If
    End Sub


    Public Sub getRateSetup()
        'Gets Rate By Employee

        If lblEmpId.Text = "" Then Exit Sub

        Dim EmpCategory As String = Me.lblEmpCategory.Text
        Dim DT_RateSetup As DataTable

        Cursor = Cursors.WaitCursor
        DT_RateSetup = AdvancePayment_DAL.CRRateSetupSelectEmp(lblEmpId.Text)
        Cursor = Cursors.Default

        dRateSetup_BasicRate = 0
        iRateSetup_OTDivider = 0
        iRateSetup_RicePrice = 0

        If DT_RateSetup.Rows.Count > 0 Then

            If DT_RateSetup.Rows(0).IsNull("BasicRate") Then
                dRateSetup_BasicRate = 0
                MessageBox.Show("Rate setup has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Else
                If DT_RateSetup.Rows(0).Item("BasicRate") = 0 Then
                    dRateSetup_BasicRate = 0
                    MessageBox.Show("Rate setup has not yet been setup", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    dRateSetup_BasicRate = DT_RateSetup.Rows(0).Item("BasicRate")
                End If

            End If

            If DT_RateSetup.Rows(0).IsNull("OTDivider") Then
                iRateSetup_OTDivider = 0
                MessageBox.Show("Rate setup has not yet been setup properly for OTDivider", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If DT_RateSetup.Rows(0).Item("OTDivider") = 0 Then
                    iRateSetup_OTDivider = 0
                    MessageBox.Show("Rate setup has not yet been setup properly for OTDivider", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    iRateSetup_OTDivider = DT_RateSetup.Rows(0).Item("OTDivider")
                End If

            End If

            If DT_RateSetup.Rows(0).IsNull("RiceDividerDays") Then
                iRateSetup_RiceDividerDays = 0
                MessageBox.Show("Rate setup has not yet been setup properly for RiceDividerDays", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If DT_RateSetup.Rows(0).Item("RiceDividerDays") = 0 Then
                    iRateSetup_RiceDividerDays = 0
                    MessageBox.Show("Rate setup has not yet been setup properly for RiceDividerDays", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    iRateSetup_RiceDividerDays = DT_RateSetup.Rows(0).Item("RiceDividerDays")
                End If
            End If

            If DT_RateSetup.Rows(0).IsNull("RicePayment") Then
                iRateSetup_RicePrice = 0
                MessageBox.Show("Rate setup has not yet been setup properly for RicePayment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If DT_RateSetup.Rows(0).Item("RicePayment") = 0 Then
                    iRateSetup_RicePrice = 0
                    '  MessageBox.Show("Rate setup has not yet been setup properly for RicePayment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    iRateSetup_RicePrice = DT_RateSetup.Rows(0).Item("RicePayment")
                End If
            End If

        End If
        
        txtBasicRate.Text = dRateSetup_BasicRate.ToString("#,##0")
    End Sub





    Public Sub showAllTeamMember()
        ' Kamis, 10 Sep 2009, 13:23
        If lblGangMasterID.Text = String.Empty Then
            MessageBox.Show("You Must select the TEAM", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If (txtTeam.Text <> String.Empty) Then

            DT_DailyAttendance = DailyAttendanceTableAdapter.DailyAttendanceWithTeamSelect(txtTeam.Text, dtpRDate.Value, lSaveUpdate)

            Dim DT1 As DataTable = DailyAttendanceWithTeam_DAL.CRHABrondalanSelect(dtpRDate.Value, lblGangMasterID.Text)
            If DT1.Rows.Count > 0 Then
                lblHaValue.Text = DT1.Rows(0).Item("Ha").ToString()
                lblBrondalanValue.Text = DT1.Rows(0).Item("Brondolan").ToString()
            Else
                lblHaValue.Text = String.Empty
                lblBrondalanValue.Text = String.Empty
            End If

            If lblActivity.Text.ToUpper = "PANEN" Then
                ForPanenVisible()
                btnActivity.Enabled = False
            ElseIf lblActivity.Text.ToUpper = "LAIN" Then
                ForLainVisible()

                btnActivity.Enabled = True
            ElseIf lblActivity.Text.ToUpper = "DERES" Then
                ForDeresVisible()
                btnActivity.Enabled = False
            End If

            dgvDailyAttendance.DataSource = DT_DailyAttendance

            If DT_DailyAttendance.Rows.Count > 0 And lblActivity.Text.ToUpper = "LAIN" Then
                boolBtnActivityMustTemporaryEnable = True
                btnActivity.Enabled = True
            Else
                btnActivity.Enabled = False
                boolBtnActivityMustTemporaryEnable = False
            End If

            Dim DT_AttSetup As DataTable
            Dim AttendanceSetupID_ForHadir As String
            Dim AttendanceSetupID_J1 As String
            Dim AttendanceSetupID_M0 As String
            Dim AttendanceSetupID_L0 As String

            Dim AttendanceSetupID_M1 As String
            Dim AttendanceSetupID_L1 As String
            Dim AttendanceSetupID_JL As String
            
            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("11", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            AttendanceSetupID_ForHadir = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()

            
            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("J1", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly for J1" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            AttendanceSetupID_J1 = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()


            
            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("JL", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly for JL" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            AttendanceSetupID_JL = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()




            ' M0
            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("M0", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly for M0" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            AttendanceSetupID_M0 = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()
            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("L0", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly for L0" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            AttendanceSetupID_L0 = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()

            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("M1", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly for M1" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            AttendanceSetupID_M1 = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()

            ' L1
            DT_AttSetup = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect("L1", "")

            If DT_AttSetup.Rows.Count = 0 Then
                MessageBox.Show("Attendance Setup has not been setuped properly for L1" + GlobalPPT.strEstateName, _
                                "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            AttendanceSetupID_L1 = DT_AttSetup.Rows(0).Item("AttendanceSetupID").ToString()




            Dim DT_TeamMember As DataTable
            Dim newRow As DataRow


            DT_TeamMember = DailyAttendanceWithTeam_DAL.CRTeamMemberSelect(dtpRDate.Value, txtTeam.Text)




            If (DT_TeamMember.Rows.Count > 0) Then

                For Each DR_Member As DataRow In DT_TeamMember.Rows

                    Dim DT_EmpDA As DataTable

                    DT_EmpDA = DailyAttendanceWithTeam_DAL.CRDailyAttendanceWithTeamEmpIsExist( _
                        txtTeam.Text, DR_Member.Item("EmpID"), dtpRDate.Value)

                    If (DT_EmpDA.Rows.Count = 0) Then
            
                        newRow = DT_DailyAttendance.NewRow()

                        newRow.Item("GangName") = txtTeam.Text
                        newRow.Item("EmpCode") = DR_Member.Item("EmpCode")
                        newRow.Item("EmpName") = DR_Member.Item("EmpName")
                        Dim DayName As String
                        Dim RestDay As String
                        Dim dtPH As DataTable


                


                        DayName = dtpRDate.Value.DayOfWeek.ToString().ToUpper().Substring(0, 3)
                        RestDay = DR_Member.Item("RestDay").ToString()
                        dtPH = DailyAttendance_DAL.CRPHoliday(dtpRDate.Value)

                        If lblEmpCategory.Text = "KHT" Then

                            If DayName.ToUpper = RestDay.ToUpper Then
                                newRow.Item("AttendanceCode") = "M1"
                                newRow.Item("AttendanceSetupID") = AttendanceSetupID_M1
                            Else
                                If dtPH.Rows.Count > 0 And DayName.ToUpper <> "FRI" Then
                                    newRow.Item("AttendanceCode") = "L1"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_L1
                                ElseIf DayName.ToUpper = "FRI" And dtPH.Rows.Count > 0 Then
                                    newRow.Item("AttendanceCode") = "JL"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_JL
                                ElseIf DayName.ToUpper = "FRI" And dtPH.Rows.Count = 0 Then
                                    newRow.Item("AttendanceCode") = "J1"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_J1
                                Else
                                    newRow.Item("AttendanceCode") = "11"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_ForHadir
                                End If
                            End If

                        ElseIf lblEmpCategory.Text = "KHL" Then

                            If DayName.ToUpper = RestDay.ToUpper Then
                                newRow.Item("AttendanceCode") = "M0"
                                newRow.Item("AttendanceSetupID") = AttendanceSetupID_M0
                            Else
                                If dtPH.Rows.Count > 0 And DayName.ToUpper <> "FRI" Then
                                    newRow.Item("AttendanceCode") = "L0"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_L0
                                ElseIf DayName.ToUpper = "FRI" And dtPH.Rows.Count > 0 Then
                                    newRow.Item("AttendanceCode") = "L0"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_L0
                                Else
                                    newRow.Item("AttendanceCode") = "11"
                                    newRow.Item("AttendanceSetupID") = AttendanceSetupID_ForHadir
                                End If
                            End If


                        Else
                            newRow.Item("AttendanceCode") = "11"
                            newRow.Item("AttendanceSetupID") = AttendanceSetupID_ForHadir
                        End If

            

                        newRow.Item("TotalOT") = 0

                        newRow.Item("EstateID") = Global.Common_PPT.GlobalPPT.strEstateID
                        newRow.Item("EstateCode") = Global.Common_PPT.GlobalPPT.strEstateCode
                        newRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
                        newRow.Item("RDate") = dtpRDate.Value
                        newRow.Item("DailyTeamActivityID") = lblDailyTeamActivityID.Text
                        newRow.Item("EmpID") = DR_Member.Item("EmpID")
                        If txtOTHours.Text <> "" Then
                            newRow.Item("TotalOT") = txtOTHours.Text
                        End If

            

                        If txtLocation.Text = "" Then
                            newRow.Item("DistributionSetupId") = System.DBNull.Value
                        Else
                            newRow.Item("DistributionSetupID") = System.DBNull.Value
                        End If

                        newRow.Item("BasicPay") = "Y"


                        newRow.Item("CreatedBy") = GlobalPPT.strUserName
                        newRow.Item("CreatedOn") = Now
                        newRow.Item("ModifiedBy") = GlobalPPT.strUserName
                        newRow.Item("ModifiedOn") = Now

                        DT_DailyAttendance.Rows.Add(newRow)

                    End If ' DT_EMPDAR.Rows.Count = 0

                Next

            
                If lblActivity.Text.ToUpper = "PANEN" Then
                    ForPanenVisible()
                    btnActivity.Enabled = False
                ElseIf lblActivity.Text.ToUpper = "LAIN" Then
                    ForLainVisible()
                    btnActivity.Enabled = True
                ElseIf lblActivity.Text.ToUpper = "DERES" Then
                    ForDeresVisible()
                    btnActivity.Enabled = False
                End If

                dgvDailyAttendance.DataSource = DT_DailyAttendance
            End If 'If (DT_MEMBERTEAM.Rows.Count > 0)

            'Calculate the Total values

            Dim ldLooseFruitNormal, ldLooseFruitBorongan, ldHarvestedNormal, ldHarvestedBorongan As Double
            Dim GridViewRow As DataGridViewRow
            For Each GridViewRow In dgvDailyAttendance.Rows
                'If dgvDailyAttendance.Columns.Contains("LooseFruitNormal") Then
                If GridViewRow.Cells("LooseFruitNormal").Value.ToString() <> String.Empty Then
                    ldLooseFruitNormal += CDbl(GridViewRow.Cells("LooseFruitNormal").Value)
                End If

                If GridViewRow.Cells("LooseFruitBorongan").Value.ToString() <> String.Empty Then
                    ldLooseFruitBorongan += CDbl(GridViewRow.Cells("LooseFruitBorongan").Value)
                End If

                If GridViewRow.Cells("HarvestedNormal").Value.ToString() <> String.Empty Then
                    ldHarvestedNormal += CDbl(GridViewRow.Cells("HarvestedNormal").Value)
                End If

                If GridViewRow.Cells("HarvestedBorongan").Value.ToString() <> String.Empty Then
                    ldHarvestedBorongan += CDbl(GridViewRow.Cells("HarvestedBorongan").Value)
                End If
                'End If

            Next
            lblJjgActualNormal.Text = ldHarvestedNormal
            lblJjgActualBorongan.Text = ldHarvestedBorongan
            lblBrdNormal.Text = ldLooseFruitNormal
            lblBrdBorongan.Text = ldLooseFruitBorongan

            '''''''''''''''''''''''''






            Dim DR As DataGridViewRow

            ' Sabtu, 17 Oct 2009, 00:35
            ' Sekarang jenis team bukan lagi dari TeamCategory di GangMaster
            ' Tapi diambil dari DailyTeamActivity.Activity ->isinya adalah [PANEN atau LAIN]
            If lblActivity.Text.ToUpper = "PANEN" Or lblActivity.Text.ToUpper = "DERES" Then

                'Added By nelson jun 23-2010
                Dim Dt As New DataTable()
                Dt = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
                Dim Datarow1 As DataRow
                For Each Datarow1 In Dt.Rows
                    For Each DR In dgvDailyAttendance.Rows

                        If DR.Cells.Item("BasicPay").Value = "Y" Then
                            If (DR.Cells.Item("DADistributionColumn").Value <> "Reception") Then


                                If (Datarow1("AttendanceSetupID").ToString = DR.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
                                    DR.Cells.Item("DADistributionColumn").Value = "Reception"
                                Else
                                    DR.Cells.Item("DADistributionColumn").Value = ""
                                End If
                            End If
                        End If
                    Next

                    'end

                    ' Sabtu, 21 Nov 2009, 15:09
                    ' Penambahan selain AB, juga utk CT (Cuti Tahunan), CB (Cuti Besar), CH (Cuti Hamil),
                    ' Cuti Haid (CD), I1 (Ijin Dibayar), I2 (Ijin Di bayar (Perkhawinan, Kematian….etc),
                    ' S1 (Sakit Dibayar ( 100 % )), S2 Sakit Dibayar ( 75 %),
                    ' S3 (Sakit Dibayar ( 50 % )), S4 (Sakit Dibayar ( 25 % )),
                    ' L0 (Libur Dibayar (Karyawan tidak Kerja))
                    ' M0 (Minggu Dibayar (Karyawan tidak Kerja))
                    ' daftar tambahan ini punya BasicPay = Y atau TimesBasic(1)
                    ' Tapi secara fisik mereka tidak datang kerja,
                    ' jadi tdk mungkin punya receiption,
                    ' Tapi utk mengonntrol ini, menunggu keputusan management
                Next

            End If

        End If

        lblTotalHK.Text = SumHKGrid()
        lblTotalOT.Text = SumOTGrid()
        SumRubberGrid()
       

    End Sub

    Private Function SumHKGrid() As Decimal

        Dim dSum As Decimal = 0
        Dim dTotalHK As DataTable
        Dim dr As DataRow
        Dim dta As DataTable = DT_DailyAttendance
        dTotalHK = DailyAttendanceWithTeam_DAL.CRAttendanceHK()
        Dim dtFromAttendance As DataRow

        For Each dr In DT_DailyAttendance.Rows
            If dr.RowState <> DataRowState.Deleted Then
                For Each dtFromAttendance In dTotalHK.Rows
                    If dr.Item("AttendanceSetupID") IsNot System.DBNull.Value Or dtFromAttendance.Item("AttendanceSetupID") IsNot System.DBNull.Value Then
                        If dtFromAttendance("AttendanceSetupID").ToString = dr("AttendanceSetupID").ToString Then
                            dSum = dSum + dtFromAttendance.Item("TimesBasic")
                        Else
                            dSum = dSum + 0
                        End If
                    End If
                Next
            End If
        Next


        'Dim Dt As New DataTable()
        'Dt = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
        'Dim Datarow1 As DataRow
        'For Each Datarow1 In Dt.Rows
        '    For Each dr In dgvDailyAttendance.Rows

        '        If dr.Cells.Item("BasicPay").Value = "Y" Then
        '            If (dr.Cells.Item("DADistributionColumn").Value <> "Reception") Then


        '                If (Datarow1("AttendanceSetupID").ToString = dr.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
        '                    dr.Cells.Item("DADistributionColumn").Value = "Reception"
        '                Else
        '                    dr.Cells.Item("DADistributionColumn").Value = ""
        '                End If
        '            End If
        '        End If
        '    Next



        Return dSum
    End Function

    Private Function SumOTGrid() As Decimal
        Dim dSum As Decimal = 0
        Dim dr As DataRow
        For Each dr In DT_DailyAttendance.Rows
            If dr.RowState <> DataRowState.Deleted Then
                If dr.Item("TotalOT") IsNot System.DBNull.Value Then
                    dSum = dSum + dr.Item("TotalOT")
                Else
                    dSum = dSum + 0
                End If

            End If

        Next

        Return dSum
    End Function

    Private Sub SumRubberGrid()
        Dim dSumLatex As Decimal = 0
        Dim dSumLump As Decimal = 0
        Dim dSumTreelace As Decimal = 0
        Dim dr As DataRow
        For Each dr In DT_DailyAttendance.Rows
            If dr.RowState <> DataRowState.Deleted Then
                If dr.Item("Latex") IsNot System.DBNull.Value Then
                    dSumLatex = dSumLatex + dr.Item("Latex")
                Else
                    dSumLatex = dSumLatex + 0
                End If
                If dr.Item("Cuplump") IsNot System.DBNull.Value Then
                    dSumLump = dSumLump + dr.Item("Cuplump")
                Else
                    dSumLump = dSumLump + 0
                End If
                If dr.Item("Treelace") IsNot System.DBNull.Value Then
                    dSumTreelace = dSumTreelace + dr.Item("Treelace")
                Else
                    dSumTreelace = dSumTreelace + 0
                End If
            End If

        Next
        Me.lblTotalLatex.Text = "Total Latex : " + dSumLatex.ToString
        Me.lblTotalCupLump.Text = "Total CupLump : " + dSumLump.ToString
        Me.lblTotalTreelace.Text = "Total Treelace : " + dSumTreelace.ToString
    End Sub

    Private Sub btnAttendanceSetupLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttendanceSetupLookup.Click
        ' Sabtu, 19 Sep 2009, 00:06
        Dim AttendanceLookupForm As New AttendanceLookup()

        If AttendanceLookupForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAttendanceCode.Text = AttendanceLookupForm._AttCode
            lblAttendanceSetupID.Text = AttendanceLookupForm._AttSetupId
            LblBasicPay.Text = AttendanceLookupForm._BasicPay
            lblAttendType.Text = AttendanceLookupForm._AttDesc

            '' Kamis, 01 Oct 2009, 01:37
            'If LblBasicPay.Text = "N" Then
            '    txtOTHours.Enabled = False
            'Else
            '    txtOTHours.Enabled = True
            'End If

            ' txtOTHours.Enabled = False
            txtOTHours.Focus()
            If Not txtOTHours.Focus Then
                txtOTHours.Text = 0
                btnEditOrUpdate.Focus()
            End If


            If lblActivity.Text.ToUpper = "LAIN" Then
                Dim DtOT As New DataTable()
                DtOT = DailyAttendanceWithTeam_DAL.GetAttCodeInReception()
                Dim DrOTAtt As DataRow
                For Each DrOTAtt In DtOT.Rows
                    ' For Each drOT In dgvDailyAttendance.Rows
                    If (DrOTAtt("AttendanceCode").ToString = txtAttendanceCode.Text.Trim) Then
                        'txtOTHours.Enabled = True
                        Exit For
                    Else
                        'txtOTHours.Enabled = False
                        txtOTHours.Text = "0"
                    End If
                    'Next
                Next
            ElseIf lblActivity.Text.ToUpper = "PANEN" Then
                'txtOTHours.Enabled = False
            End If

            'If lblActivity.Text = "LAIN" Then
            '    If txtAttendanceCode.Text.Trim = "11" Or txtAttendanceCode.Text.Trim = "J1" Or txtAttendanceCode.Text.Trim = "51" Or txtAttendanceCode.Text.Trim = "M1" Or txtAttendanceCode.Text.Trim = "L1" Then
            '        txtOTHours.Enabled = True
            '    Else
            '        txtOTHours.Enabled = False
            '        txtOTHours.Text = "0"
            '    End If
            'ElseIf lblActivity.Text = "PANEN" Then
            '    txtOTHours.Enabled = False
            'End If
            'Sabtu, 3 Oct 2009, 17:23
            txtOT1.Text = AttendanceLookupForm._OT1
            txtOT2.Text = AttendanceLookupForm._OT2
            txtOT3.Text = AttendanceLookupForm._OT3
            txtOT4.Text = AttendanceLookupForm._OT4

            txtMax1.Text = AttendanceLookupForm._MaxOT1
            txtMax2.Text = AttendanceLookupForm._MaxOT2
            txtMax3.Text = AttendanceLookupForm._MaxOT3
            txtMax4.Text = AttendanceLookupForm._MaxOT4

        Else
            txtAttendanceCode.Text = String.Empty
            lblAttendanceSetupID.Text = String.Empty
            LblBasicPay.Text = String.Empty
            lblAttendType.Text = String.Empty

            ' txtOTHours.Enabled = False

            'Sabtu, 3 Oct 2009, 17:23
            txtOT1.Text = "0"
            txtOT2.Text = "0"
            txtOT3.Text = "0"
            txtOT4.Text = "0"

            txtMax1.Text = "0"
            txtMax2.Text = "0"
            txtMax3.Text = "0"
            txtMax4.Text = "0"
        End If

    End Sub

    Private Sub EditDailyAttendance()
        ' Sabtu, 12 Sep 2009, 23:12
        Try
            '-------------
            ' Selasa, 20 Oct 2009, 11:54
            '
            ' Get the Currency Manager by using the BindingContext of the DataGrid
            Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAttendance.DataSource, dgvDailyAttendance.DataMember), CurrencyManager)
            Dim dv As DataView = CType(cm.List, DataView)

            ' Use Currency Manager and DataView to retrieve the Current Row
            Dim dr As DataRow
            dr = dv.Item(cm.Position).Row

            txtNIK.Text = dr.Item("EmpCode").ToString()
            lblEmpName.Text = dr.Item("EmpName").ToString()
            If Not IsDBNull(dr.Item("AccountNo")) Then
                lblOldNIK.Text = dr.Item("AccountNo").ToString()
            Else
                lblOldNIK.Text = ""
            End If

            If Not IsDBNull(dr.Item("Category")) Then
                lblEmpCategory.Text = dr.Item("Category").ToString()
            Else
                lblEmpCategory.Text = ""
            End If

            txtAttendanceCode.Text = dr.Item("AttendanceCode").ToString()
            'lblEmpCategory.Text = dr.Item("Category").ToString()
            lblEmpId.Text = dr.Item("EmpID").ToString()
            lblDailyReceiptionID.Text = dr.Item("DailyReceiptionID").ToString()

            If lblActivity.Text.ToUpper = "LAIN" Then
                Dim DtOT As New DataTable()
                DtOT = DailyAttendanceWithTeam_DAL.GetAttCodeInReception()
                Dim DrOTAtt As DataRow
                For Each DrOTAtt In DtOT.Rows
                    ' For Each drOT In dgvDailyAttendance.Rows
                    If (DrOTAtt("AttendanceCode").ToString = dr.Item("AttendanceCode").ToString()) Then
                        'txtOTHours.Enabled = True
                        Exit For
                    Else
                        'txtOTHours.Enabled = False
                        txtOTHours.Text = "0"
                    End If
                    'Next
                Next
            ElseIf lblActivity.Text.ToUpper = "PANEN" Then
                'txtOTHours.Enabled = False
            End If

            'If dr.Item("AttendanceCode").ToString() = "11" Or dr.Item("AttendanceCode").ToString() = "J1" Or dr.Item("AttendanceCode").ToString() = "51" Or dr.Item("AttendanceCode").ToString() = "M1" Or dr.Item("AttendanceCode").ToString() = "L1" Then
            '    txtOTHours.Enabled = True
            'Else
            '    txtOTHours.Enabled = False
            '    txtOTHours.Text = "0"
            'End If
            'ElseIf lblActivity.Text = "PANEN" Then
            'txtOTHours.Enabled = False
            'End If

            lblAttendanceSetupID.Text = String.Empty
            LblBasicPay.Text = String.Empty
            lblAttendType.Text = String.Empty

            If dr.IsNull("TotalOT") Then
                txtOTHours.Text = "0"
            Else
                txtOTHours.Text = CType(dr.Item("TotalOT"), Double).ToString()
            End If

            If dr.IsNull("TotalOTValue") Then
                txtTotalOTValue.Text = "0"
            Else
                txtTotalOTValue.Text = CType(dr.Item("TotalOTValue"), Double).ToString()
            End If

            'If lblActivity.Text = "LAIN" Then
            '    txtOTHours.Enabled = True
            'ElseIf lblActivity.Text = "PANEN" Then
            '    txtOTHours.Enabled = False
            'End If
            'btnEditOrUpdate.Focus()
            txtAttendanceCode.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Sabtu, 19 Sep 2009, 00:59
        Me.Close()
    End Sub

    Private Function SaveDailyAttendance() As Boolean
        ' Sabtu, 19 Sep 2009, 02:46
        Dim rowAffected As Integer
        ' Saturday, 25 Oct 2009, 12:26
        ' The date for RDate in DailyAttendance must be in range in FiscalFromDT dan FiscalToDate
        Dim FiscalFromDT As Date
        Dim FiscalToDate As Date

        FiscalFromDT = GlobalPPT.FiscalYearFromDate
        FiscalToDate = GlobalPPT.FiscalYearToDate

        If dtpRDate.Value < FiscalFromDT Or dtpRDate.Value > FiscalToDate Then

            MessageBox.Show("Date is not between Fiscal Period / Active Month & Year", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRDate.Focus()
            Return False
        End If

        'Cursor = Cursors.WaitCursor

        rowAffected = DailyAttendanceTableAdapter.Update(DT_DailyAttendance)

        If rowAffected > 0 Then
            If dgvDailyAttendance.Rows.Count > 0 Then
                ' Sabtu, 17 Oct 2009, 00:56
                ' Sekarang jenis team bukan lagi dari TeamCategory di GangMaster
                ' Tapi diambil dari DailyTeamActivity.Activity ->isinya adalah [PANEN atau LAIN]

                If lblActivity.Text.ToUpper = "PANEN" Then
                    'commented By nelson jun 23-2010
                    'For Each DR In dgvDailyAttendance.Rows

                    '    If DR.Cells.Item("BasicPay").Value = "Y" Then


                    '        DR.Cells.Item("DADistributionColumn").Value = "Receiption"
                    '    End If


                    'Next
                    'end
                    'Added By nelson jun 23-2010
                    Dim Dt As New DataTable()
                    Dt = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
                    Dim DrAtt As DataRow
                    For Each DrAtt In Dt.Rows
                        For Each DR In dgvDailyAttendance.Rows

                            If DR.Cells.Item("BasicPay").Value = "Y" Then
                                If (DR.Cells.Item("DADistributionColumn").Value <> "Reception") Then


                                    If (DrAtt("AttendanceSetupID").ToString = DR.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
                                        DR.Cells.Item("DADistributionColumn").Value = "Reception"
                                    Else
                                        DR.Cells.Item("DADistributionColumn").Value = ""
                                    End If
                                End If
                            End If
                        Next
                    Next
                    'end
                End If

            End If

            DailyOTDetailAdapter.Update(DTOT_Detail) '<=========== Update OTSummary




            ''Commented out by Stanley on 24-06-2011 and move to monthly processing
            'For i = 0 To dgvDailyAttendance.Rows.Count - 1

            '    If dgvDailyAttendance.Rows(i).Cells("EmpID").Value.ToString() <> String.Empty Then

            '        lblEmpId.Text = dgvDailyAttendance.Rows(i).Cells("EmpID").Value.ToString()
            '        DailyAttendanceWithTeamBOL.AttendSummaryWithTeam(lblEmpId.Text)
            '    End If
            '    ' Exit For
            'Next i



            ' Jum'at, 1 Jan 2010, 13:12
            CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
            ' END Jum'at, 1 Jan 2010, 13:12
            ' Cursor = Cursors.Default


            MessageBox.Show("Attendance Data saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            ' Cursor = Cursors.Default

            MessageBox.Show("Attendance Data saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        lSaveUpdate = "Save"
        Return True


    End Function

    Private Sub SaveAllData()
        ' Sabtu, 19 Sep 2009, 03:26
        If dgvDailyAttendance.Rows.Count = 0 Then
            MessageBox.Show("There is no data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If SaveDailyAttendance() Then

            If lblActivity.Text.ToUpper = "PANEN" Then
                ' Jika panen clear all input, jika LAIN ngga usah <====== Anand Command
                ' ClearAllInput() dinonaktifkan, Selasa, 17 Nov 2009, 12:24 agung dari user untuk clear
                ' ClearAllInput()
            Else
                ' Ahad, 15 Nov 2009, 13:39
                ' Mulai pake 
                'btnActivity.Enabled = True
                If lblActivity.Text.ToUpper = "LAIN" Then
                    boolBtnActivityMustTemporaryEnable = True
                    btnActivity.Enabled = True
                ElseIf lblActivity.Text.ToUpper = "PANEN" Then
                    boolBtnActivityMustTemporaryEnable = False
                    btnActivity.Enabled = False
                End If

            End If
            DoSearch()


        End If

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        SaveAllData()
    End Sub

    Private Sub ViewReceiption()
        ' Sabtu, 19 Sep 2009, 05:42
        Dim DailyReceiptionForm As DailyReceiptionWithTeam = New DailyReceiptionWithTeam()
        Dim EmpID As String ' Jum'at, 12 Mar 2010, 02:12
        Dim NIK As String
        Dim OldNIK As String
        Dim EmpName As String
        Dim AttendanceCode As String
        Dim TotalOT As String
        Dim DailyReceiptionID As String
        Dim AttendanceSetupID As String 'Senin, 19 Oct 2009, 12:21

        rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex

        Try
            NIK = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAEmpCodeColumn").Value.ToString()
            If Not IsDBNull(dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("dgcOldNIK").Value) Then
                OldNIK = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("dgcOldNIK").Value
            Else
                OldNIK = ""
            End If

            EmpName = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAEmpNameColumn").Value
            AttendanceCode = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAAttendanceCodeColumn").Value
            AttendanceSetupID = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAAttendanceSetupIDColumn").Value

            If dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DATotalOTColumn").Value Is System.DBNull.Value Then
                TotalOT = ""
            Else
                TotalOT = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DATotalOTColumn").Value
            End If

            DailyReceiptionID = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DailyReceiptionID").Value
            lblDailyTeamActivityID.Text = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DailyTeamActivityID").Value

            ' Update, Ahad, 25 Oct 2009, 19:58
            ' Jum'at, 12 Mar 2010, 02:08
            ' tambah EmpID
            EmpID = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("EmpID").Value

            DailyReceiptionForm.Show( _
            dtpRDate.Value, _
            txtTeam.Text, _
            EmpID, _
            NIK, _
            EmpName, _
            AttendanceCode, _
            AttendanceSetupID, _
            TotalOT, _
            DailyReceiptionID, _
            lblDailyTeamActivityID.Text, _
            lblActivity.Text, _
            lblGangMasterID.Text, _
            lblMandoreID.Text, _
            lblKraniID.Text, _
            lblMandorEmpName.Text, _
            lblKraniEmpName.Text, _
            lblEmpCategory.Text, _
            txtLocation.Text, _
            OldNIK, _
            Me.MdiParent)

            'Me.Close()
            'If dgvDailyAttendance.Rows.Count <> 0 Then
            '    Dim i As Integer = 0
            '    Dim J As Integer = 0
            '    Dim objDataGridViewRow As New DataGridViewRow
            '    For Each objDataGridViewRow In dgvDailyAttendance.Rows
            '        dgvDailyAttendance.Rows.RemoveAt(dgvDailyAttendance.Rows.Count - 1)
            '    Next
            '    i = dgvDailyAttendance.Rows.Count
            '    For J = 0 To i - 1
            '        dgvDailyAttendance.Rows.RemoveAt(dgvDailyAttendance.Rows.Count - 1)
            '    Next
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Receiption_Handler()
        ' Sabtu, 19 Sep 2009, 04:56
        Dim DailyReceiptionForm As DailyReceiptionWithTeam = New DailyReceiptionWithTeam()
        DailyReceiptionForm.ShowDialog()
    End Sub

    Private Sub dgvDailyAttendance_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyAttendance.CellContentClick
        ' Sabtu, 19 Sep 2009, 05:45
        If dgvDailyAttendance.Rows.Count = 0 Then
            Return
        End If

        If dgvDailyAttendance.CurrentCell Is Nothing Then
            Return
        End If

        '>>>>>
        ' Pencegahan
        '>>>>>
        Dim ModifiedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False


        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        'If Modified Then
        '    MessageBox.Show("Please Save All data before you can enter Daily Receiption", _
        '                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If

        If e.RowIndex <> -1 And TypeOf dgvDailyAttendance.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If dgvDailyAttendance.Rows(e.RowIndex).Cells("BasicPay").Value.ToString() = "Y" And _
                dgvDailyAttendance.Rows(e.RowIndex).Cells("DADistributionColumn").Value <> "" Then

                'rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex

                'Dim cm As CurrencyManager = CType(Me.BindingContext(Me.dgvDailyAttendance.DataSource, Me.dgvDailyAttendance.DataMember), CurrencyManager)
                'Dim dv As DataView
                'Dim dr As DataRow

                'dv = CType(cm.List, DataView)
                'dr = dv.Item(cm.Position).Row

                'If dr.IsNull("DailyReceiptionID") Then

                '    MessageBox.Show("You must save this daily attendance " + vbCrLf + _
                '                    "before you can Enter Daily receiption", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Return
                'End If

                ''''''''''''''''''''''''''''
                ' Sabtu, 21 Nov 2009, 14:35
                If Modified Then
                    'MessageBox.Show("You must save this daily attendance " + vbCrLf + _
                    '                "before you can Enter Daily receiption", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    If MessageBox.Show(MsgViewReceiptionBeforeSave + vbNewLine + "Save Now ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                        SaveAllData()
                    End If

                    'MessageBox.Show(MsgViewReceiptionBeforeSave, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return

                End If
                rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex

                If GlobalPPT.strCategoryField = "OilPalm" Then
                    Me.ViewReceiption()
                ElseIf GlobalPPT.strCategoryField = "Rubber" Then
                    Dim DailyRubber As DailyReceptionForRubber = New DailyReceptionForRubber()
                    Dim NIK As String = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAEmpCodeColumn").Value.ToString()
                    Dim OLDNIK As String
                    If Not IsDBNull(dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("dgcOldNIK").Value) Then
                        OLDNIK = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("dgcOldNIK").Value
                    Else
                        OLDNIK = ""
                    End If
                    Dim EmpName As String = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAEmpNameColumn").Value
                    Dim AttendanceCode As String = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DAAttendanceCodeColumn").Value
                    Dim TotalOT As String
                    If dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DATotalOTColumn").Value Is System.DBNull.Value Then
                        TotalOT = ""
                    Else
                        TotalOT = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DATotalOTColumn").Value
                    End If
                    Dim DailyReceiptionID As String
                    'DailyReceiptionID = dgvDailyAttendance.SelectedRows(rowIndex_dgvDailyAttendance).Cells("DailyReceiptionID").Value
                    DailyReceiptionID = dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells("DailyReceiptionID").Value
                    DailyRubber.TeamId = txtTeam.Text
                    DailyRubber.Show(DailyReceiptionID, dtpRDate.Value, NIK, EmpName, AttendanceCode, txtLocation.Text, TotalOT, "", "", "", MdiParent, txtTeam.Text, dtpRDate.Value, lSaveUpdate, drTemp, OLDNIK)
                End If
                Me.Hide()


            End If

        End If
        'If lblTeamCategory.Text = "KHT" Then


    End Sub

    'Private Sub CalculateQtyIssued()

    '    Dim ldQtyIssued As Double
    '    Dim GridViewRow As DataGridViewRow
    '    For Each GridViewRow In dgIssueVoucher.Rows
    '        If GridViewRow.Cells("dgclIssuedQty").Value.ToString() <> String.Empty Then
    '            ldQtyIssued += CDbl(GridViewRow.Cells("dgclIssuedQty").Value)
    '        End If
    '    Next
    '    lblQtyIssued.Text = ldQtyIssued

    'End Sub

    Private Sub dgvDailyAttendance_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyAttendance.CellDoubleClick
        ' Sabtu, 19 Sep 2009, 00:19
        If dgvDailyAttendance.Rows.Count > 0 Then
            If dgvDailyAttendance.CurrentCell IsNot Nothing Then

                'btnEditOrUpdate.Text = "&Update"

                btnEditOrUpdate.Enabled = True

                dtpRDate.Enabled = False

                btnReset.Enabled = True
                btnResetAll.Enabled = False
                btnSaveAll.Enabled = False
                btnClose.Enabled = False
                btnActivity.Enabled = False

                txtTeam.Enabled = False
                btnTeamLookup.Enabled = False

                txtAttendanceCode.Enabled = True
                btnAttendanceSetupLookup.Enabled = True

                'Monday, 26 Oct 2009, 12:01


                rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex
                EditDailyAttendance()

                dgvDailyAttendance.Enabled = False
                'txtOTHours.Enabled = False
                ' Jum'at, 20 Nov 2009, 19:00
                txtAttendanceCode.Focus()

                getRateSetup()
                ' END Jum'at, 20 Nov 2009, 19:00

            End If
        End If
    End Sub

    Private Sub btnEditOrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrUpdate.Click
        If (Val(txtOTHours.Text) > 24) Then
            MessageBox.Show("Maximum OT per day cannot exceed 24 Hours", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtOTHours.Focus()
            Return
        End If

        'Dim dt As New DataTable
        'dt = DailyAttendanceWithTeamBOL.GetMaxOTHours(txtNIK.Text, dtpRDate.Value.Date)

        'If dt.Rows.Count > 0 Then
        '    If dt.Rows(0).IsNull("AllowedOT") = False Then

        '        Dim intMaxOTDays As Integer
        '        intMaxOTDays = dt.Rows(0).Item("AllowedOT").ToString()

        '        If Val(txtOTHours.Text) > intMaxOTDays Then
        '            MessageBox.Show("Maximum OT per day cannot exceed " & intMaxOTDays.ToString() + " Hours, Please Refer OT Master", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            txtOTHours.Focus()
        '            Return
        '        End If
        '    Else
        '        MessageBox.Show("Please Save the records before proceeding with OT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtOTHours.Focus()
        '        Return
        '    End If
        'Else
        '    MessageBox.Show("Please Save the records before proceeding with OT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtOTHours.Focus()
        '    Return
        'End If

        ' Sabtu, 19 Sep 2009, 20:58
        If dgvDailyAttendance.Rows.Count > 0 Then
            If dgvDailyAttendance.CurrentCell IsNot Nothing Then

                If btnEditOrUpdate.Text = "&Edit" Then
                    'btnEditOrUpdate.Text = "&Update"

                    btnReset.Enabled = True
                    btnResetAll.Enabled = False
                    btnSaveAll.Enabled = False
                    btnClose.Enabled = False

                    ' Ahad, 15 Nov 2009, 13:42
                    'If lblActivity.Text = "LAIN" Then
                    '    btnActivity.Enabled = False
                    'End If
                    If boolBtnActivityMustTemporaryEnable = True Then
                        btnActivity.Enabled = False
                    End If
                    ' END Ahad, 15 Nov 2009, 13:42

                    txtTeam.Enabled = False
                    btnTeamLookup.Enabled = False

                    txtAttendanceCode.Enabled = True
                    btnAttendanceSetupLookup.Enabled = True

                    rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex
                    EditDailyAttendance()

                    dgvDailyAttendance.Enabled = False

                ElseIf btnEditOrUpdate.Text = "&Update" Then

                    'CountOverTime()
                    'getTotalOTValue()

                    If UpdateDailyAttendance() = False Then
                        Return

                    End If


                    dtpRDate.Enabled = True
                    txtTeam.Enabled = True
                    btnTeamLookup.Enabled = True

                    'Monday, 26 Oct 2009, 12:01
                    'If lblActivity.Text = "LAIN" Then
                    '    txtOTHours.Enabled = True
                    'ElseIf lblActivity.Text = "PANEN" Then
                    '    txtOTHours.Enabled = False
                    'End If

                    txtAttendanceCode.Enabled = False
                    btnAttendanceSetupLookup.Enabled = False

                    btnEditOrUpdate.Enabled = False
                    btnReset.Enabled = False
                    btnResetAll.Enabled = True
                    btnSaveAll.Enabled = True
                    btnClose.Enabled = True

                    txtOTHours.Text = ""
                    'txtOTHours.Enabled = False
                    dgvDailyAttendance.Enabled = True
                    dgvDailyAttendance.Focus()
                    ClearInput()

                    'Dim i As Integer
                    'For i = 0 To dgvDailyAttendance.Rows.Count - 1
                    '    dgvDailyAttendance.Rows.Item(i).Selected = True
                    '    If Val(dgvDailyAttendance.Item("DAColumnTotalOTValue", Rowindex).Value.ToString) = 0 Then
                    '        dgvDailyAttendance.Item("DADistributionColumn", Rowindex).Value = String.Empty
                    '    End If
                    'Next i
                    'dgvDailyAttendance.Rows.Item(Rowindex).Selected = True

                    ' Ahad, 15 Nov 2009, 13:42
                    If boolBtnActivityMustTemporaryEnable = True Then
                        btnActivity.Enabled = True
                    End If
                    ' END Ahad, 15 Nov 2009, 13:42

                End If

                'Dim Dt As New DataTable()
                'Dt = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
                'Dim DrAtt As DataRow
                'For Each DrAtt In Dt.Rows

                '    For Each DR In dgvDailyAttendance.Rows

                '        If DR.Cells.Item("BasicPay").Value = "Y" Then
                '            If (DR.Cells.Item("DADistributionColumn").Value <> "Reception") Then
                '                If (DrAtt("AttendanceSetupID").ToString = DR.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
                '                    DR.Cells.Item("DADistributionColumn").Value = "Reception"
                '                Else
                '                    DR.Cells.Item("DADistributionColumn").Value = ""
                '                End If
                '            End If
                '        End If
                '    Next
                'Next
            End If
            'txtOTHours.Enabled = False
            dtpRDate.Enabled = False
        Else
            ' No Data to save
            MessageBox.Show("There is no data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function IsTeamAlreadyHaveDailyActivityDistribution() As Boolean
        ' Jum'at, 20 Nov 2009, 01:56
        Dim retValue As Boolean = False

        Dim DT_dad As DataTable

        DT_dad = DailyActivityDistributionWithTeam_DAL.CRDailyActivityDistributionIsExist(lblGangMasterID.Text, dtpRDate.Value)

        If DT_dad.Rows.Count > 0 Then
            retValue = True
        End If

        Return retValue
    End Function

    Private Function UpdateDailyAttendance() As Boolean
        ' Sabtu, 19 Sep 2009, 20:58
        'If lblAttendanceSetupID.Text = "" Or lblAttendanceSetupID.Text = "NOTVALID" Then
        '    MessageBox.Show("Attendance Code Not Valid", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If



        ' Selasa, 20 Oct 2009, 11:06
        ' For for DailyActivityDistribution
        ' Jika sudah ada tidak boleh mengupdate

        If lblActivity.Text.ToUpper = "LAIN" Then
            Dim DT_dad As DataTable

            DT_dad = DailyActivityDistributionWithTeam_DAL.CRDailyActivityDistributionIsExist(lblGangMasterID.Text, dtpRDate.Value)
            If (DT_dad.Rows.Count > 0) Then
                MessageBox.Show("You cannot change Daily Attendance, " + vbCrLf + _
                                "because you already have Activity Distribution", "Information", MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)

                Me.txtAttendanceCode.Focus()

                Return False
            End If

        Else
            ' Rabu, 21 Oct 2009, 20:45 
            Dim DT_dr As DataTable
            DT_dr = DailyReceiptionWithTeam_DAL.CRDailyReceiptionIsExist(lblDailyReceiptionID.Text)

            If DT_dr.Rows.Count > 0 Then
                MessageBox.Show("You cannot change Daily Attendance, " + vbCrLf + _
                                "because you already have Daily Receiption", "Information", MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)
                Me.txtAttendanceCode.Focus()
                Return False

            End If
        End If
        ' END Selasa, 20 Oct 2009, 11:06


        Dim DT As DataTable
        DT = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect(txtAttendanceCode.Text, "")

        If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then

            lblAttendanceSetupID.Text = String.Empty
            LblBasicPay.Text = String.Empty
            lblAttendType.Text = String.Empty

            'txtOTHours.Enabled = False

            MessageBox.Show("Attendance Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.txtAttendanceCode.Focus()
            Return False

        ElseIf DT.Rows.Count = 1 Then
            ' Jum'at, 12 Mar 2010, 14:43
            If DT.Rows(0).IsNull("OvertimeTimes1") Then
                txtOT1.Text = "0"
            Else
                txtOT1.Text = DT.Rows(0).Item("OvertimeTimes1").ToString()
            End If

            If DT.Rows(0).IsNull("OvertimeTimes2") Then
                txtOT2.Text = "0"
            Else
                txtOT2.Text = DT.Rows(0).Item("OvertimeTimes2").ToString()
            End If

            If DT.Rows(0).IsNull("OvertimeTimes3") Then
                txtOT3.Text = "0"
            Else
                txtOT3.Text = DT.Rows(0).Item("OvertimeTimes3").ToString()
            End If

            If DT.Rows(0).IsNull("OvertimeTimes4") Then
                txtOT4.Text = "0"
            Else
                txtOT4.Text = DT.Rows(0).Item("OvertimeTimes4").ToString()
            End If


            If DT.Rows(0).IsNull("OvertimeMaxOTHours1") Then
                txtMax1.Text = "0"
            Else
                txtMax1.Text = DT.Rows(0).Item("OvertimeMaxOTHours1").ToString()
            End If

            If DT.Rows(0).IsNull("OvertimeMaxOTHours2") Then
                txtMax2.Text = "0"
            Else
                txtMax2.Text = DT.Rows(0).Item("OvertimeMaxOTHours2").ToString()
            End If

            If DT.Rows(0).IsNull("OvertimeMaxOTHours3") Then
                txtMax3.Text = "0"
            Else
                txtMax3.Text = DT.Rows(0).Item("OvertimeMaxOTHours3").ToString()
            End If

            If DT.Rows(0).IsNull("OvertimeMaxOTHours4") Then
                txtMax4.Text = "0"
            Else
                txtMax4.Text = DT.Rows(0).Item("OvertimeMaxOTHours4").ToString()
            End If
        End If

        '>>>>>>>>>>
        '
        ' Senin, 30 Nov 2009, 14:00
        ' Sekarang saya pake currencry manager utk meng-update record
        ' soalnya, terjadi bug, bila user meng-order grid by Nik,
        ' bila gua menggunakan code dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item()
        ' nilai rowIndex_dgvDailyAttendance ini akan tetap sesuai aslinya sebelum di order by Nik
        ' maka, diputuskan pake CurrencyManager
        '
        ' Get the Currency Manager by using the BindingContext of the DataGrid
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAttendance.DataSource, dgvDailyAttendance.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        If DT.Rows.Count = 1 Then

            txtAttendanceCode.Text = DT.Rows(0).Item("Att Code").ToString()
            lblAttendanceSetupID.Text = DT.Rows(0).Item("AttendanceSetupID").ToString()
            LblBasicPay.Text = DT.Rows(0).Item("BasicPay").ToString()
            lblAttendType.Text = DT.Rows(0).Item("Att Descp").ToString()

            If LblBasicPay.Text = "N" Then
                'txtOTHours.Text = "0"

                'dr.Item("DADistributionColumn") = String.Empty
                dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item("DADistributionColumn").Value = String.Empty
            Else
                'dr.Item("DADistributionColumn") = "Receiption"



                If lblActivity.Text.ToUpper = "PANEN" Or lblActivity.Text.ToUpper = "DERES" Then
                    Dim Dtp As New DataTable()
                    Dtp = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
                    Dim DatatRowParent As DataRow
                    For Each DatatRowParent In Dtp.Rows
                        'If dgvDailyAttendance.CurrentRow.Cells("BasicPay").Value = "Y" Then
                        If (DatatRowParent("AttendanceSetupID").ToString = lblAttendanceSetupID.Text.Trim) Then
                            dgvDailyAttendance.CurrentRow.Cells("DADistributionColumn").Value = "Reception"
                            Exit For
                        Else
                            dgvDailyAttendance.CurrentRow.Cells("DADistributionColumn").Value = ""
                        End If
                        'End If
                    Next
                End If


                'Dim Dt1 As New DataTable()
                'Dt1 = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
                'Dim Datarow1 As DataRow
                'For Each Datarow1 In Dt1.Rows
                '    For Each dr1 In dgvDailyAttendance.Rows
                '        dr1.Cells.Item("DADistributionColumn").Value = ""
                '        If dr1.Cells.Item("BasicPay").Value = "Y" Then
                '            If (dr1.Cells.Item("DADistributionColumn").Value <> "Reception") Then


                '                If (Datarow1("AttendanceSetupID").ToString = dr1.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
                '                    dr1.Cells.Item("DADistributionColumn").Value = "Reception"
                '                Else
                '                    dr1.Cells.Item("DADistributionColumn").Value = ""
                '                End If
                '            End If
                '        End If
                '    Next
                'Next








                'For Each drp In dgvDailyAttendance.Rows

                '    If drp.Cells.Item("BasicPay").Value = "Y" Then
                '        If (drp.Cells.Item("DADistributionColumn").Value <> "Reception") Then
                '            If (DatatRowParent("AttendanceSetupID").ToString = drp.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
                '                drp.Cells.Item("DADistributionColumn").Value = "Reception"
                '                Exit For
                '            Else
                '                drp.Cells.Item("DADistributionColumn").Value = ""
                '            End If

                '        End If
                '    End If

                'Next

                'Dim Dtp As New DataTable()
                'Dtp = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
                ' dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item("DADistributionColumn").Value = "Receiption"
            End If

        End If

        If IsNumeric(txtOTHours.Text) = False Then
            MessageBox.Show("Please key in numeric value for Daily OT", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        'If lblActivity.Text = "LAIN" Then
        '    txtOTHours.Enabled = True
        'ElseIf lblActivity.Text = "PANEN" Then
        '    txtOTHours.Enabled = False
        'End If

        'If lblActivity.Text.ToUpper = "PANEN" Then
        'Team PANEN punya premi maka dia tdk boleh punya OT (OverTime)
        'txtOTHours.Text = "0"

        'If lblActivity.Text.ToUpper = "LAIN" Then
        ' Hanya utk team LAIN yg boleh punya OT, soalnya dia activitas ngga punya premi
        CountOverTime()
        getTotalOTValue()

        ' Jum'at, 12 Mar 2010, 14:59
        Dim pencarian As Boolean

        ' By Dadang Adi H
        ' Kamis, 11 Feb 2010, 21:20
        Dim dOT1 As Double
        Dim dOT1value As Double

        Dim dOT2 As Double
        Dim dOT2value As Double

        Dim dOT3 As Double
        Dim dOT3value As Double

        Dim dOT4 As Double
        Dim dOT4value As Double

        Dim BasicOT As Double ' Kamis, 18 Mar 2010, 15:36

        'txtOT1.Text = Pengali Overtime pertama (biasanya nilainya 1)
        'txtOT2.Text = Pengali Overtime kedua (biasanya nilainya 2)
        ' END Kamis, 11 Feb 2010, 21:20

        ' Kamis, 18 Mar 2010, 15:32
        ' Ternyata Basic OT adalah dibulatkan alias g pake koma (desimal)
        ' contoh : UMSP = 1,011,000 -> 33,700 * 30
        ' maka OT Rate atau Basic OT = (33,700 * 30 )/ 173 = 5,843.93 dibulatkan jadi 5,844

        If iRateSetup_OTDivider = 0 Or iRateSetup_RiceDividerDays = 0 Then
            BasicOT = 0
        Else
            BasicOT = ((Convert.ToDouble(txtBasicRate.Text) * iRateSetup_RiceDividerDays) + iRateSetup_RicePrice) / iRateSetup_OTDivider
            '  BasicOT = Math.Round(BasicOT, 0)

        End If

        Try

            pencarian = False
            For i = 0 To DgvOTDetail.Rows.Count - 1
                If DgvOTDetail.Rows(i).Cells("MandoreID").Value <> Nothing Then
                    If lblMandoreID.Text = DgvOTDetail.Rows(i).Cells("MandoreID").Value.ToString() And _
                    lblEmpId.Text = DgvOTDetail.Rows(i).Cells("EmpID").Value.ToString() Then

                        ' OT1
                        dOT1 = Convert.ToDouble(txtH1.Text)
                        'dOT1value = dOT1 * Convert.ToDouble(txtOT1.Text) * (Convert.ToDouble(txtBasicRate.Text) * iRateSetup_RiceDividerDays / iRateSetup_OTDivider)
                        dOT1value = dOT1 * Convert.ToDouble(txtOT1.Text) * BasicOT

                        DTOT_Detail.Rows(i).Item("OT1") = Math.Round(dOT1, 2)
                        DTOT_Detail.Rows(i).Item("OTValue1") = Math.Round(dOT1value, 2)

                        ' OT2
                        dOT2 = Convert.ToDouble(txtH2.Text)
                        dOT2value = dOT2 * Convert.ToDouble(txtOT2.Text) * BasicOT

                        DTOT_Detail.Rows(i).Item("OT2") = Math.Round(dOT2, 2)
                        DTOT_Detail.Rows(i).Item("OTValue2") = Math.Round(dOT2value, 2)

                        'OT3
                        dOT3 = Convert.ToString(txtH3.Text)
                        dOT3value = dOT3 * Convert.ToDouble(txtOT3.Text) * BasicOT

                        DTOT_Detail.Rows(i).Item("OT3") = Math.Round(dOT3, 2)
                        DTOT_Detail.Rows(i).Item("OTValue3") = Math.Round(dOT3value, 2)

                        'OT4
                        dOT4 = Convert.ToString(txtH4.Text)
                        dOT4value = dOT4 * Convert.ToDouble(txtOT4.Text) * BasicOT

                        DTOT_Detail.Rows(i).Item("OT4") = Math.Round(dOT4, 2)
                        DTOT_Detail.Rows(i).Item("OTValue4") = Math.Round(dOT4value, 2)



                        DgvOTDetail.Rows(i).Cells("ModifiedBy").Value = GlobalPPT.strUserName
                        DgvOTDetail.Rows(i).Cells("ModifiedOn").Value = dtpRDate.Value
                        DgvOTDetail.Rows(i).Cells("MandoreID").Value = lblMandoreID.Text
                        pencarian = True


                        'Palani
                        txtH1.Text = ""
                        txtH2.Text = ""
                        txtH3.Text = ""
                        txtH4.Text = ""


                        Exit For
                    End If
                End If
            Next i


            'For i = 0 To DTOT_Detail.Rows.Count - 1
            '    If DTOT_Detail.Rows(i).Item("EmpID") = lblEmpId.Text Then

            '        dOT1 = Convert.ToDouble(txtH1.Text)
            '        dOT1value = dOT1 * Convert.ToDouble(txtOT1.Text) * BasicOT

            '        DTOT_Detail.Rows(i).Item("OT1") = Math.Round(dOT1, 2)
            '        DTOT_Detail.Rows(i).Item("OTValue1") = Math.Round(dOT1value, 2)

            '        ' OT2
            '        dOT2 = Convert.ToDouble(txtH2.Text)
            '        dOT2value = dOT2 * Convert.ToDouble(txtOT2.Text) * BasicOT

            '        DTOT_Detail.Rows(i).Item("OT2") = Math.Round(dOT2, 2)
            '        DTOT_Detail.Rows(i).Item("OTValue2") = Math.Round(dOT2value, 2)

            '        'OT3
            '        dOT3 = Convert.ToString(txtH3.Text)
            '        dOT3value = dOT3 * Convert.ToDouble(txtOT3.Text) * BasicOT

            '        DTOT_Detail.Rows(i).Item("OT3") = Math.Round(dOT3, 2)
            '        DTOT_Detail.Rows(i).Item("OTValue3") = Math.Round(dOT3value, 2)
            '        'OT4
            '        dOT4 = Convert.ToString(txtH4.Text)
            '        dOT4value = dOT4 * Convert.ToDouble(txtOT4.Text) * BasicOT

            '        DTOT_Detail.Rows(i).Item("OT4") = Math.Round(dOT4, 2)
            '        DTOT_Detail.Rows(i).Item("OTValue4") = Math.Round(dOT4value, 2)


            '        DgvOTDetail.Rows(i).Cells("ModifiedBy").Value = GlobalPPT.strUserName
            '        DgvOTDetail.Rows(i).Cells("ModifiedOn").Value = dtpRDate.Value
            '        DgvOTDetail.Rows(i).Cells("MandoreID").Value = lblMandoreID.Text
            '        pencarian = True
            '        Exit For



            '    End If
            'Next i


            If pencarian = False Then
                AddOTGrid()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        'End If

        Try

            dr.Item("AttendanceCode") = txtAttendanceCode.Text
            dr.Item("AttendanceSetupID") = lblAttendanceSetupID.Text
            dr.Item("BasicPay") = LblBasicPay.Text

            'If lblDistributionSetupID.Text <> "NOTVALID" And lblDistributionSetupID.Text <> String.Empty Then
            '    DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("DistributionSetupID") = lblDistributionSetupID.Text
            'End If


            If IsNumeric(txtOTHours.Text) = True Then
                Try
                    dr.Item("TotalOT") = txtOTHours.Text
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If


            If IsNumeric(txtTotalOTValue.Text) = True Then
                dr.Item("TotalOTValue") = txtTotalOTValue.Text
            End If

            If lblActivity.Text.ToUpper = "LAIN" Then
                lblTotalHK.Text = SumHKGrid()
                lblTotalOT.Text = SumOTGrid()
            End If

            MessageBox.Show("Data successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        ' END Senin, 30 Nov 2009, 14:00

        'Try


        '    DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("AttendanceCode") = txtAttendanceCode.Text
        '    DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("AttendanceSetupID") = lblAttendanceSetupID.Text
        '    DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("BasicPay") = LblBasicPay.Text

        '    If lblDistributionSetupID.Text <> "NOTVALID" And lblDistributionSetupID.Text <> String.Empty Then
        '        DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("DistributionSetupID") = lblDistributionSetupID.Text
        '    End If


        '    If IsNumeric(txtOTHours.Text) = True Then
        '        Try
        '            DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("TotalOT") = txtOTHours.Text
        '        Catch ex As Exception
        '            MessageBox.Show(ex.Message)
        '        End Try
        '    End If


        '    If IsNumeric(txtTotalOTValue.Text) = True Then
        '        DT_DailyAttendance.Rows(rowIndex_dgvDailyAttendance).Item("TotalOTValue") = txtTotalOTValue.Text
        '    End If



        '    MessageBox.Show("Data successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Function

    Private Function ValidAttendance() As Boolean
        Dim returnValue As Boolean = False
        'Dim restDay As String

        'Cek For RestDay & Holiday
        '=================

        'If lblRestday.Text.ToUpper.ToString.Trim = (dtpRDate.Value.DayOfWeek.ToString.Substring(0, 3)).ToUpper.ToString.Trim Then
        '    txtAttCode.Text = "M0"
        'End If
        'Dim DTPH As New DataTable
        'DTPH = CheckRoll_BOL.DailyAttendanceBOL.CRPHoliday(dtpRDate.Value)
        'If DTPH.Rows.Count = 1 Then
        '    txtAttCode.Text = "L0"
        'End If

        'If restDay = dtpRDate.Value.DayOfWeek.ToString().Substring(0, 3).ToUpper().Trim() Then
        '    txtAttendanceCode.Text = "M0"
        'End If

        Return returnValue
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Senin, 21 Sep 2009, 21:16

        'btnEditOrUpdate.Text = "&Edit"
        dtpRDate.Enabled = True
        btnEditOrUpdate.Enabled = False
        dtpRDate.Enabled = False
        btnReset.Enabled = False
        btnResetAll.Enabled = True
        btnSaveAll.Enabled = True
        btnClose.Enabled = True

        txtTeam.Enabled = True
        btnTeamLookup.Enabled = True

        txtAttendanceCode.Enabled = False
        btnAttendanceSetupLookup.Enabled = False
        '        txtOTHours.Enabled = False
        'If lblActivity.Text = "LAIN" Then
        '    txtOTHours.Enabled = True
        'ElseIf lblActivity.Text = "PANEN" Then
        '    txtOTHours.Enabled = False
        'End If
        txtOTHours.Text = ""
        'txtOTHours.Enabled = False

        If boolBtnActivityMustTemporaryEnable = True Then
            btnActivity.Enabled = True
        End If


        dgvDailyAttendance.Enabled = True
        ClearInput()
    End Sub

    Private Sub ClearInput()
        ' Sabtu, 03 Oct 2009, 00:40
        'txtTeam.Text = ""
        'lblGangMasterID.Text = ""
        'lblTeamCategory.Text = ""

        lSaveUpdate = "Save"

        txtNIK.Text = String.Empty
        lblEmpName.Text = String.Empty
        lblEmpId.Text = String.Empty
        'lblEmpCategory.Text = String.Empty

        txtAttendanceCode.Text = String.Empty
        lblAttendanceSetupID.Text = String.Empty
        lblAttendType.Text = String.Empty
        LblBasicPay.Text = String.Empty

        txtLocation.Text = ""
        lblDistributionSetupID.Text = String.Empty


        txtOTHours.Text = "0"
    End Sub

    Private Sub btnActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivity.Click
        ' Senin, 21 Sep 2009, 23:18
        If dgvDailyAttendance.Rows.Count = 0 Then
            Return
        End If

        If dgvDailyAttendance.CurrentCell Is Nothing Then
            Return
        End If

        ' Ahad, 15 Nov 2009, 10:39

        Dim ModifiedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False


        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        If Modified Then
            If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                            "Do you want to save data before entering Activity Distribution.", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                SaveDailyAttendance()
            Else
                Return
            End If
        End If
        ' END Ahad, 15 Nov 2009, 10:39

        ViewActivity()
        Me.Close()

    End Sub


    Private Sub ViewActivity()
        ' Senin, 21 Sep 2009, 23:19
        Dim DailyActivityWithTeamForm As DailyActivityDistributionWithTeam = New DailyActivityDistributionWithTeam

        DailyActivityWithTeamForm.MdiParent = Me.MdiParent()
        DailyActivityWithTeamForm.Dock = DockStyle.Fill
        ' Senin, 26 Oct 2009, 21:36
        ' Adding MandorEmpName and KraniEmpName in DailyActivityDistribution Form
        DailyActivityWithTeamForm.Show(dtpRDate.Value, _
                                       txtTeam.Text, _
                                       lblActivity.Text, _
                                       lblGangMasterID.Text, _
                                       lblMandorEmpName.Text, _
                                       lblKraniEmpName.Text, _
                                       lblDailyTeamActivityID.Text, _
                                       lblEmpCategory.Text, _
                                       lblMandoreID.Text, _
                                       lblKraniID.Text, _
                                       lblTotalHK.Text, _
                                        Me.MdiParent)

    End Sub

    Private Sub txtAttendanceCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ' Selasa, 22 Sep 2009, 21:38
        If e.KeyCode = Keys.Enter Then
            DisplaySelectedAttendance()
        End If
    End Sub

    Private Sub DisplaySelectedAttendance()
        ' Sabtu, 03 Oct 2009, 17:11
        If txtAttendanceCode.Text.Trim <> "" Then
            Dim DT As DataTable

            DT = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect(txtAttendanceCode.Text, "")

            If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then

                lblAttendanceSetupID.Text = String.Empty
                LblBasicPay.Text = String.Empty
                lblAttendType.Text = String.Empty

                'Sabtu, 3 Oct 2009, 17:23
                txtOT1.Text = "0"
                txtOT2.Text = "0"
                txtOT3.Text = "0"
                txtOT4.Text = "0"

                txtMax1.Text = "0"
                txtMax2.Text = "0"
                txtMax3.Text = "0"
                txtMax4.Text = "0"

                ' txtOTHours.Enabled = False

                MessageBox.Show("Attendance Code not found.", "Information", MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)

                txtAttendanceCode.Focus()

            ElseIf DT.Rows.Count = 1 Then

                txtAttendanceCode.Text = DT.Rows(0).Item("AttendanceCOde").ToString()
                lblAttendanceSetupID.Text = DT.Rows(0).Item("AttendanceSetupID").ToString()
                LblBasicPay.Text = DT.Rows(0).Item("BasicPay").ToString()
                lblAttendType.Text = DT.Rows(0).Item("Att Descp").ToString()


                If lblActivity.Text.ToUpper = "LAIN" Then
                    Dim DtOT As New DataTable()
                    DtOT = DailyAttendanceWithTeam_DAL.GetAttCodeInReception()
                    Dim DrOTAtt As DataRow
                    For Each DrOTAtt In DtOT.Rows
                        ' For Each drOT In dgvDailyAttendance.Rows
                        If (DrOTAtt("AttendanceCode").ToString = txtAttendanceCode.Text.Trim) Then
                            'txtOTHours.Enabled = True
                            Exit For
                        Else
                            'txtOTHours.Enabled = False
                            txtOTHours.Text = "0"
                        End If
                        'Next
                    Next
                ElseIf lblActivity.Text.ToUpper = "PANEN" Then
                    'txtOTHours.Enabled = False
                End If


                'If lblActivity.Text = "LAIN" Then
                '    If txtAttendanceCode.Text.Trim = "11" Or txtAttendanceCode.Text.Trim = "J1" Or txtAttendanceCode.Text.Trim = "51" Or txtAttendanceCode.Text.Trim = "M1" Or txtAttendanceCode.Text.Trim = "L1" Then
                '        txtOTHours.Enabled = True
                '    Else
                '        txtOTHours.Enabled = False
                '        txtOTHours.Text = "0"
                '    End If
                'ElseIf lblActivity.Text = "PANEN" Then
                '    txtOTHours.Enabled = False
                'End If
                'If Val(txtOT1.Text) <> 0 And Val(txtOT2.Text) <> 0 Then
                '    txtOTHours.Enabled = True
                'Else
                '    txtOTHours.Enabled = False
                'End If

                'Sabtu, 3 Oct 2009, 17:23
                If DT.Rows(0).IsNull("OvertimeTimes1") Then
                    txtOT1.Text = "0"
                Else
                    txtOT1.Text = DT.Rows(0).Item("OvertimeTimes1").ToString()
                End If

                If DT.Rows(0).IsNull("OvertimeTimes2") Then
                    txtOT2.Text = "0"
                Else
                    txtOT2.Text = DT.Rows(0).Item("OvertimeTimes2").ToString()
                End If

                If DT.Rows(0).IsNull("OvertimeTimes3") Then
                    txtOT3.Text = "0"
                Else
                    txtOT3.Text = DT.Rows(0).Item("OvertimeTimes3").ToString()
                End If

                If DT.Rows(0).IsNull("OvertimeTimes4") Then
                    txtOT4.Text = "0"
                Else
                    txtOT4.Text = DT.Rows(0).Item("OvertimeTimes4").ToString()
                End If


                If DT.Rows(0).IsNull("OvertimeMaxOTHours1") Then
                    txtMax1.Text = "0"
                Else
                    txtMax1.Text = DT.Rows(0).Item("OvertimeMaxOTHours1").ToString()
                End If

                If DT.Rows(0).IsNull("OvertimeMaxOTHours2") Then
                    txtMax2.Text = "0"
                Else
                    txtMax2.Text = DT.Rows(0).Item("OvertimeMaxOTHours2").ToString()
                End If

                If DT.Rows(0).IsNull("OvertimeMaxOTHours3") Then
                    txtMax3.Text = "0"
                Else
                    txtMax3.Text = DT.Rows(0).Item("OvertimeMaxOTHours3").ToString()
                End If

                If DT.Rows(0).IsNull("OvertimeMaxOTHours4") Then
                    txtMax4.Text = "0"
                Else
                    txtMax4.Text = DT.Rows(0).Item("OvertimeMaxOTHours4").ToString()
                End If

                'If LblBasicPay.Text = "Y" Then
                '    txtOTHours.Enabled = True
                '    txtOTHours.Focus()
                'End If
                ' txtOTHours.Enabled = False
            End If

        ElseIf txtAttendanceCode.Text.Trim = "" Then
            ' txtOTHours.Enabled = False
            ' btnAttendanceSetupLookup.Focus()
        End If

    End Sub

    Private Sub DisplayAttendanceValid()
        ' Sabtu, 03 Oct 2009, 19:20

    End Sub


    Private Sub btnSearchView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchView.Click
        ' Rabu, 23 Sep 2009, 04:31
        ' Update: Sabtu, 24 Oct 2009, 19:02
        DoSearch()
        btnAttendanceReport.Focus()

    End Sub

    Private Sub DoSearch()
        ' Update: Sabtu, 24 Oct 2009, 19:02
        Dim useMonthYearLogin As Boolean = True
        Dim dSearch As Date
        Dim Activity As String
        ActiveYearLogin = GlobalPPT.intActiveYear
        ActiveMonthLogin = GlobalPPT.IntActiveMonth
        If chkDateView.Checked = True Then
            useMonthYearLogin = False
            dSearch = dtpRDateView.Value
        Else
            dSearch = New Date(ActiveYearLogin, ActiveMonthLogin, 1)
        End If

        If cboActivityView.SelectedIndex = -1 OrElse cboActivityView.SelectedIndex = 0 Then
            Activity = String.Empty
        Else
            Activity = cboActivityView.SelectedItem.ToString()
        End If

        DT_DailyAttendanceWithTeamView = DailyAttendanceWithTeam_DAL.CRDailyAttendanceWithTeamView( _
            useMonthYearLogin, _
            txtTeamNameView.Text, _
            txtMandorNameView.Text, _
            Activity, _
            dSearch, GlobalPPT.strCategoryField)

        dgvDailyAWTView.DataSource = DT_DailyAttendanceWithTeamView


        'If dgvDailyAWTView.Rows.Count = 0 Then
        '    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

    End Sub

    Public drTemp As DataRow
    Private Sub dgvDailyAWTView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyAWTView.CellDoubleClick
        ' Rabu, 23 Sep 2009, 04:59
        If dgvDailyAWTView.Rows.Count > 0 Then

            lSaveUpdate = "UpDate"

            If dgvDailyAWTView.CurrentCell IsNot Nothing Then
                If (IsNothing(DT_DailyAttendance)) Then Return
                '===============================
                ' Pencegahan
                '==============================
                Dim ModifiedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
                Dim AddedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Added)
                Dim DeletedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

                Dim Modified As Boolean = False


                If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
                    'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
                    'didalam DT_DailyAttendance
                    Modified = True
                End If

                If Modified Then
                    If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                                    "Do you want to save this data..", "Warning", _
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                                  Windows.Forms.DialogResult.Yes Then
                        'save data
                        SaveDailyAttendance()
                    End If
                End If
                ''''''
                ' End of Pencegahan

                ' Senin, 16 Nov 2009, 19:34
                Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAWTView.DataSource, dgvDailyAWTView.DataMember), CurrencyManager)
                Dim dv As DataView = CType(cm.List, DataView)

                ' Use Currency Manager and DataView to retrieve the Current Row
                Dim dr As DataRow
                dr = dv.Item(cm.Position).Row
                drTemp = dr

                lblDailyTeamActivityID.Text = dr.Item("DailyTeamActivityID").ToString()
                dtpRDate.Value = dr.Item("RDate")
                txtTeam.Text = dr.Item("GangName").ToString()

                lblActivity.Text = dr.Item("Activity").ToString()

                lblMandoreID.Text = dr.Item("MandoreID").ToString()
                lblMandorEmpName.Text = dr.Item("Mandor").ToString()

                If dr.IsNull("KraniID") Then
                    lblKraniID.Text = String.Empty
                Else
                    lblKraniID.Text = dr.Item("KraniID").ToString()
                End If

                If dr.IsNull("Krani") Then
                    lblKraniEmpName.Text = String.Empty
                Else
                    lblKraniEmpName.Text = dr.Item("Krani")
                End If

                lblGangMasterID.Text = dr.Item("GangMasterID")
                ' END Senin, 16 Nov 2009, 19:34




                lblEmpCategory.Text = dr.Item("Category") 'Ahad, 22 Nov 2009, 23:42

                Dim rowIndex As Integer = dgvDailyAWTView.CurrentCell.RowIndex

                tcDailyAttendance.SelectedTab = tabInput
                txtTeam.Focus()

                '======================================
                ' Jum'at, 18 Sep 2009, 21:44

                ' Senin, 21 Sep 2009, 20:59
                ' Sabtu, 17 Oct 2009, 13:26
                ' Sekarang jenis team bukan lagi dari TeamCategory di GangMaster
                ' Tapi diambil dari DailyTeamActivity.Activity ->isinya adalah [PANEN atau LAIN]

                If lblActivity.Text.ToUpper = "PANEN" Then
                    ForPanenVisible()
                    btnActivity.Enabled = False
                ElseIf lblActivity.Text.ToUpper = "LAIN" Then
                    ForLainVisible()
                    btnActivity.Enabled = True
                ElseIf lblActivity.Text.ToUpper = "DERES" Then
                    ForDeresVisible()
                    btnActivity.Enabled = False
                End If

                showAllTeamMember()

                ManageDailyAttendanceGridColumn()

                getRateSetup()

                ' By Dadang
                ' Kamis, 11 Feb 2010, 23:27
                DTOT_Detail = OTDetailBOL.OTDetailViewTeam(lblMandoreID.Text, lblKraniID.Text, dtpRDate.Value)
                DgvOTDetail.DataSource = DTOT_Detail
                ' By Dadang
                ' Kamis, 11 Feb 2010, 23:27

            End If
            '==========================================
            If dgvDailyAttendance.Rows.Count > 0 Then
                dtpRDate.Enabled = False
            Else
                dtpRDate.Enabled = True
            End If

        End If

    End Sub

    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim DistributionSetupkLookup_Form As DistributionSetupLookup

        DistributionSetupkLookup_Form = New DistributionSetupLookup()

        If DistributionSetupkLookup_Form.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtLocation.Text = DistributionSetupkLookup_Form.DistributionDescp
            Me.lblDistributionSetupID.Text = DistributionSetupkLookup_Form.DistributionSetupID
            txtOTHours.Focus()
        End If

    End Sub

    Private Sub txtLocation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtOTHours_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOTHours.KeyDown
        ' Selasa, 20 Oct 2009, 16:15
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

        If nonNumberEntered = True Then
            btnEditOrUpdate.Focus()
        End If

    End Sub

    Private Sub CountOverTime()
        ' Sabtu, 03 Oct 2009, 16:19
        Dim DailyOT As Decimal = 0
        Dim HasilOT As Decimal = 0

        Dim dOT1 As Decimal = 0 'perkalian OT1
        Dim dMax1 As Decimal = 0

        Dim dOT2 As Decimal = 0 'perkalian OT2
        Dim dMax2 As Decimal = 0

        Dim dOT3 As Decimal = 0 'perkalian OT3
        Dim dMax3 As Decimal = 0

        Dim dOT4 As Decimal = 0 'perkalian OT4
        Dim dMax4 As Decimal = 0

        Dim dH1 As Decimal = 0
        Dim dH2 As Decimal = 0
        Dim dH3 As Decimal = 0
        Dim dH4 As Decimal = 0

        Dim bSelesai As Boolean = False

        If IsNumeric(txtOTHours.Text) = False Then
            MessageBox.Show("Please key in numeric data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                DailyOT = FormatNumber(Val(txtOTHours.Text), 2)
            Catch ex As Exception
                DailyOT = 0
            End Try
            'DailyOT = FormatNumber(Val(txtOTHours.Text), 2)

        End If

        HasilOT = DailyOT

        dMax1 = FormatNumber(Val(txtMax1.Text), 2)
        dOT1 = FormatNumber(Val(txtOT1.Text), 2)

        dMax2 = FormatNumber(Val(txtMax2.Text), 2)
        dOT2 = FormatNumber(Val(txtOT2.Text), 2)

        dMax3 = FormatNumber(Val(txtMax3.Text), 2)
        dOT3 = FormatNumber(Val(txtOT3.Text), 2)

        dMax4 = FormatNumber(Val(txtMax4.Text), 2)
        dOT4 = FormatNumber(Val(txtOT4.Text), 2)

        ' By Dadang
        ' Jum'at, 12 Feb 2010, 00:07
        'OT1
        'If HasilOT = 0 Then
        '    dH1 = 0
        'Else
        '    If HasilOT > dMax1 Then
        '        dH1 = dMax1
        '    Else
        '        dH1 = HasilOT
        '    End If
        'End If

        ''OT2
        'If HasilOT = 0 Then
        '    dH2 = 0
        'Else
        '    If HasilOT > dMax2 Then
        '        dH2 = dMax2
        '    Else
        '        dH2 = HasilOT - dMax1
        '    End If
        'End If

        ''OT3
        'If HasilOT = 0 Then
        '    dH3 = 0
        'Else
        '    If HasilOT - dMax1 - dMax2 <= 0 Then
        '        dH3 = 0
        '    ElseIf HasilOT - (dMax1 + dMax2) > dMax3 Then
        '        dH3 = dMax3
        '    Else
        '        dH3 = HasilOT - (dMax1 + dMax2)
        '    End If
        'End If

        ''OT4
        'If HasilOT = 0 Then
        '    dH4 = 0
        'Else
        '    If HasilOT - (dMax1 + dMax2 + dMax3) <= 0 Then
        '        dH4 = 0
        '    ElseIf HasilOT - (dMax1 + dMax2 + dMax3) > dMax4 Then
        '        dH4 = dMax4
        '    Else
        '        dH4 = HasilOT - (dMax1 + dMax2 + dMax3)
        '    End If
        'End If
        ' END Jum'at, 12 Feb 2010, 00:07


        Dim dblCarryForwardValue As Decimal
        dblCarryForwardValue = 0

        'Palani & Enger
        If HasilOT > dMax1 Then
            dH1 = dMax1
            dblCarryForwardValue = HasilOT - dH1
        Else
            dH1 = HasilOT
            dblCarryForwardValue = 0
        End If

        'OT2
        If dblCarryForwardValue > 0 Then
            If dblCarryForwardValue > dMax2 Then
                dH2 = dMax2
                dblCarryForwardValue -= dH2
            Else
                dH2 = dblCarryForwardValue
                dblCarryForwardValue = 0
            End If
        End If

        'OT3
        If dblCarryForwardValue > 0 Then
            If dblCarryForwardValue > dMax3 Then
                dH3 = dMax3
                dblCarryForwardValue -= dH3
            Else
                dH3 = dblCarryForwardValue
                dblCarryForwardValue = 0
            End If
        End If

        'OT4
        If dblCarryForwardValue > 0 Then
            If dblCarryForwardValue > dMax4 Then
                dH4 = dMax4
                dblCarryForwardValue -= dH4
            Else
                dH4 = dblCarryForwardValue
                dblCarryForwardValue = 0
            End If
        End If


        'If HasilOT > dMax1 Then
        '    dH1 = dMax1
        '    HasilOT = HasilOT - dMax1
        'ElseIf bSelesai = False Then
        '    dH1 = HasilOT
        '    bSelesai = True
        'End If

        'If HasilOT > dMax2 And bSelesai = False Then
        '    dH2 = dMax2
        '    HasilOT = HasilOT - dMax2
        'ElseIf bSelesai = False Then
        '    dH2 = HasilOT
        '    bSelesai = True
        'End If

        'If HasilOT > dMax3 And bSelesai = False Then
        '    dH3 = dMax3
        '    HasilOT = HasilOT - dMax3

        'ElseIf bSelesai = False Then
        '    dH3 = HasilOT
        '    bSelesai = True
        'End If

        'If HasilOT > dMax4 And bSelesai = False Then
        '    dH4 = dMax4
        '    HasilOT = HasilOT - dMax4
        'ElseIf bSelesai = False Then
        '    dH4 = HasilOT
        'End If


        txtH1.Text = dH1.ToString()
        txtH2.Text = dH2.ToString()
        txtH3.Text = dH3.ToString()
        txtH4.Text = dH4.ToString()

        dOTResult = (dOT1 * dH1) + (dOT2 * dH2) + (dOT3 * dH3) + (dOT4 * dH4)
        txtOTResult.Text = dOTResult.ToString("#,##0.00")




    End Sub

    Private Sub getTotalOTValue()
        Dim dTotalOTValue As Decimal = 0

        getRateSetup()

        ' Selasa, 17 Nov 2009, 00:02
        ' Sekarang utk KHT pake 30 hari sebagai default
        ' Sekarang utk KHL pake 25 hari sebagai default
        ' angka 173 langsung ambil dari OTDivider di RateSetup

        Dim BasicOT As Double ' Kamis, 18 Mar 2010, 15:36
        'DTOT_Detail = DgvOTDetail.DataSource

        ' By Dadang Adi H
        ' Kamis, 18 Mar 2010, 16:29

        If iRateSetup_RiceDividerDays = 0 Or iRateSetup_OTDivider = 0 Then
            BasicOT = 0
        Else
            BasicOT = ((Convert.ToDouble(txtBasicRate.Text) * iRateSetup_RiceDividerDays) + iRateSetup_RicePrice) / iRateSetup_OTDivider
            '   BasicOT = Math.Round(BasicOT, 0)

        End If



        If iRateSetup_OTDivider <> 0 Then
            dTotalOTValue = dOTResult * BasicOT
        End If



        ' Senin, 15 Feb 2010, 10:07
        'dTotalOTValue = Math.Round(dTotalOTValue) ' Kamis, 11 Feb 2010, 23:31 - Hasilnya diRound aja
        txtTotalOTValue.Text = dTotalOTValue.ToString("#,##0.00")
    End Sub

    Private Sub btnDailyAttendanceWithTeamReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MessageBox.Show("Under construction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return


    End Sub



    Private Sub EditMIDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMIDA.Click
        ' Senin, 05 Oct 2009, 13:41
        If dgvDailyAttendance.CurrentCell Is Nothing Then
            MessageBox.Show("Please select the grid first, before editing", "Information", MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
            Return
        End If

        dtpRDate.Enabled = False
        btnEditOrUpdate.Enabled = True

        btnReset.Enabled = True
        btnResetAll.Enabled = False
        btnSaveAll.Enabled = False
        btnClose.Enabled = False
        btnActivity.Enabled = False

        txtTeam.Enabled = False
        btnTeamLookup.Enabled = False

        txtAttendanceCode.Enabled = True
        btnAttendanceSetupLookup.Enabled = True

        rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex
        EditDailyAttendance()

        dgvDailyAttendance.Enabled = False

    End Sub

    Private Sub cmsDailyAttendance_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDailyAttendance.Opening
        ' Senin, 05 Oct 2009, 13:42
        If dgvDailyAttendance.Rows.Count = 0 Then
            cmsDailyAttendance.Items(0).Enabled = False
        ElseIf dgvDailyAttendance.Rows.Count > 0 And dgvDailyAttendance.CurrentCell IsNot Nothing Then
            cmsDailyAttendance.Items(0).Enabled = True
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TeamLookupForm As TeamLookUps = New TeamLookUps()

        ' Selasa, 20 Oct 2009, 03:07
        TeamLookupForm.DDate = dtpRDateView.Value

        TeamLookupForm.ShowDialog()

        If TeamLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtTeamNameView.Text = TeamLookupForm.GangName
            Me.lblGangMasterID.Text = TeamLookupForm.GangMasterID
            Me.txtTeam.Text = TeamLookupForm.GangName
            Me.lblGangMasterID.Text = TeamLookupForm.GangMasterID
            Me.lblEmpCategory.Text = TeamLookupForm.Category

        End If



    End Sub


    Private Sub dgvDailyAttendance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDailyAttendance.KeyDown

        If e.KeyCode = Keys.Enter Then
            'Rowindex = dgvDailyAttendance.CurrentCell.RowIndex
            'If dgvDailyAttendance.Rows.Count > 0 Then
            '    If dgvDailyAttendance.CurrentCell IsNot Nothing Then

            '        btnEditOrUpdate.Enabled = True

            '        dtpRDate.Enabled = False

            '        btnReset.Enabled = True
            '        btnResetAll.Enabled = False
            '        btnSaveAll.Enabled = False
            '        btnClose.Enabled = False
            '        btnActivity.Enabled = False

            '        txtTeam.Enabled = False
            '        btnTeamLookup.Enabled = False

            '        txtAttendanceCode.Enabled = True
            '        btnAttendanceSetupLookup.Enabled = True

            '        'Monday, 26 Oct 2009, 12:01
            '        If lblActivity.Text = "LAIN" Then
            '            txtOTHours.Enabled = True
            '        End If


            '        rowIndex_dgvDailyAttendance = dgvDailyAttendance.CurrentCell.RowIndex
            '        EditDailyAttendance()

            '        dgvDailyAttendance.Enabled = False
            '        txtOTHours.Enabled = False
            '        ' Jum'at, 20 Nov 2009, 19:00
            '        txtAttendanceCode.Focus()
            '        ' END Jum'at, 20 Nov 2009, 19:00
            '        e.Handled = True
            '    End If
            ' End If

        End If
    End Sub

    Private Sub dgvDailyAWTView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDailyAWTView.KeyDown
        If e.KeyCode = Keys.Enter Then

            If dgvDailyAWTView.Rows.Count > 0 Then
                If dgvDailyAWTView.CurrentCell IsNot Nothing Then


                    '===============================
                    ' Pencegahan
                    '==============================
                    Dim ModifiedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
                    Dim AddedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Added)
                    Dim DeletedRow As DataRow() = DT_DailyAttendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

                    Dim Modified As Boolean = False


                    If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
                        'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
                        'didalam DT_DailyAttendance
                        Modified = True
                    End If

                    If Modified Then
                        If MessageBox.Show("Your Data has not been saved yet," + vbCrLf + _
                                        "Do you want to save this data..", "Warning", _
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                                      Windows.Forms.DialogResult.Yes Then
                            'save data
                            SaveDailyAttendance()
                        End If
                    End If
                    ''''''
                    ' End of Pencegahan

                    ' Senin, 16 Nov 2009, 19:34
                    Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAWTView.DataSource, dgvDailyAWTView.DataMember), CurrencyManager)
                    Dim dv As DataView = CType(cm.List, DataView)

                    ' Use Currency Manager and DataView to retrieve the Current Row
                    Dim dr As DataRow
                    dr = dv.Item(cm.Position).Row

                    lblDailyTeamActivityID.Text = dr.Item("DailyTeamActivityID").ToString()
                    dtpRDate.Value = dr.Item("RDate")
                    txtTeam.Text = dr.Item("GangName").ToString()

                    lblActivity.Text = dr.Item("Activity").ToString()

                    lblMandoreID.Text = dr.Item("MandoreID").ToString()
                    lblMandorEmpName.Text = dr.Item("Mandor").ToString()

                    If dr.IsNull("KraniID") Then
                        lblKraniID.Text = String.Empty
                    Else
                        lblKraniID.Text = dr.Item("KraniID").ToString()
                    End If

                    If dr.IsNull("Krani") Then
                        lblKraniEmpName.Text = String.Empty
                    Else
                        lblKraniEmpName.Text = dr.Item("Krani")
                    End If

                    lblGangMasterID.Text = dr.Item("GangMasterID")
                    ' END Senin, 16 Nov 2009, 19:34

                    Dim rowIndex As Integer = dgvDailyAWTView.CurrentCell.RowIndex

                    tcDailyAttendance.SelectedTab = tabInput
                    txtTeam.Focus()

                    '======================================
                    ' Jum'at, 18 Sep 2009, 21:44

                    ' Senin, 21 Sep 2009, 20:59
                    ' Sabtu, 17 Oct 2009, 13:26
                    ' Sekarang jenis team bukan lagi dari TeamCategory di GangMaster
                    ' Tapi diambil dari DailyTeamActivity.Activity ->isinya adalah [PANEN atau LAIN]

                    If lblActivity.Text.ToUpper = "PANEN" Then
                        ForPanenVisible()
                        btnActivity.Enabled = False
                    ElseIf lblActivity.Text.ToUpper = "LAIN" Then
                        ForLainVisible()
                        btnActivity.Enabled = True
                    ElseIf lblActivity.Text.ToUpper = "DERES" Then
                        ForDeresVisible()
                        btnActivity.Enabled = False
                    End If


                    showAllTeamMember()

                    ManageDailyAttendanceGridColumn()

                    getRateSetup()
                End If
                '>>>>>>


            End If
        End If
        If dgvDailyAttendance.Rows.Count > 0 Then
            dtpRDate.Enabled = False
        Else
            dtpRDate.Enabled = True
        End If
    End Sub

    Private Sub txtOTHours_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOTHours.KeyPress
        ' Selasa, 20 Oct 2009, 16:18
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnEditOrUpdate.Focus()
            End If
        End If
    End Sub

    Private Sub txtOTHours_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Selasa, 20 Oct 2009, 16:18
        If txtOTHours.Text = "" Or txtOTHours.Text = "." Then
            txtOTHours.Text = "0"
        End If

    End Sub

    Private Sub txtTeam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTeam.KeyPress
        If e.KeyChar = vbCr Then
            If txtTeam.Text <> "" Then
                Dim DT As DataTable

                DT = DailyAttendanceWithTeam_DAL.CRGangMasterSelect(txtTeam.Text, _
                                                                    "", _
                                                                    "", _
                                                                    dtpRDate.Value, GlobalPPT.strCategoryField)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then

                    lblDailyTeamActivityID.Text = String.Empty
                    lblActivity.Text = String.Empty
                    lblGangMasterID.Text = String.Empty
                    lblEmpCategory.Text = String.Empty
                    lblActivity.Text = String.Empty
                    lblAttendType.Text = String.Empty

                    lblMandorEmpName.Text = String.Empty
                    lblKraniEmpName.Text = String.Empty
                    lblEmpName.Text = String.Empty


                    DT_DailyAttendance.Clear()

                    MessageBox.Show("Team not found.", "Information", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
                    txtTeam.Focus()
                    dtpRDate.Enabled = True

                ElseIf DT.Rows.Count = 1 Then

                    ' Update, Tuesday, 20 Oct 2009, 16:28
                    Me.lblDailyTeamActivityID.Text = DT.Rows(0).Item("DailyTeamActivityID").ToString()
                    Me.lblActivity.Text = DT.Rows(0).Item("Activity").ToString()
                    Me.txtTeam.Text = DT.Rows(0).Item("GangName").ToString()
                    Me.lblGangMasterID.Text = DT.Rows(0).Item("GangMasterID").ToString()
                    Me.lblEmpCategory.Text = DT.Rows(0).Item("Category").ToString()


                    lblMandoreID.Text = DT.Rows(0).Item("MandoreID").ToString()
                    lblMandorEmpName.Text = DT.Rows(0).Item("MandorEmpName").ToString()
                    lblKraniID.Text = DT.Rows(0).Item("KraniID").ToString()
                    lblKraniEmpName.Text = DT.Rows(0).Item("KraniEmpName").ToString()

                    DTOT_Detail = OTDetailBOL.OTDetailViewTeam(lblMandoreID.Text, lblKraniID.Text, dtpRDate.Value)
                    DgvOTDetail.DataSource = DTOT_Detail

                    dtpRDate.Enabled = False

                    'Dim dtDailyTeamActivity As DataTable
                    'dtDailyTeamActivity = DailyAttendanceWithTeam_DAL.CRDailyTeamActivityGangMasterIDIsExist( _
                    '    dtpRDate.Value, _
                    '    lblDailyTeamActivityID.Text, _
                    '    lblMandoreID.Text, _
                    '    lblKraniID.Text)

                    'If dtDailyTeamActivity.Rows.Count = 0 Then

                    '    lblActivity.Text = ""

                    '    MessageBox.Show("This team has not yet been registered with Daily Team Activity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    '    DT_DailyAttendance.Clear()

                    '    Return
                    'Else
                    '    Try
                    '        lblActivity.Text = dtDailyTeamActivity.Rows(0).Item("Activity").ToString()
                    '        lblDailyTeamActivityID.Text = dtDailyTeamActivity.Rows(0).Item("DailyTeamActivityID").ToString()

                    '    Catch ex As Exception
                    '        MessageBox.Show(ex.Message, "BSP")
                    '    End Try
                    'End If

                    If lblActivity.Text.ToUpper = "PANEN" Then
                        ForPanenVisible()
                        btnActivity.Enabled = False
                    ElseIf lblActivity.Text.ToUpper = "LAIN" Then
                        ForLainVisible()
                        btnActivity.Enabled = True
                    ElseIf lblActivity.Text.ToUpper = "DERES" Then
                        ForDeresVisible()
                        btnActivity.Enabled = False
                    End If

                    'If lblTeamCategory.Text = "KHT" Then
                    '    dgvDailyAttendance.Columns("DADistributionColumn").Visible = True
                    '    btnActivity.Enabled = False
                    'ElseIf lblTeamCategory.Text = "BHL" Then
                    '    dgvDailyAttendance.Columns("DADistributionColumn").Visible = False
                    '    btnActivity.Enabled = True
                    'End If

                    showAllTeamMember()

                    ManageDailyAttendanceGridColumn()
                    'dgvDailyAttendance.Focus()
                    btnSaveAll.Focus()



                End If
            ElseIf txtTeam.Text = "" Then
                btnSaveAll.Focus()
            End If

        End If
    End Sub

    Private Sub cboTeamView_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTeamNameView.KeyPress, txtMandorNameView.KeyPress
        ' Selasa, 20 Oct 2009, 16:50
        ' Update: Sabtu, 24 Oct 2009, 19:02
        'Dim useMonthYearLogin As Boolean = True

        'If chkDateView.Checked = True Then
        '    useMonthYearLogin = False
        'End If

        'If e.KeyChar = vbCr Then

        '    DT_DailyAttendanceWithTeamView = DailyAttendanceWithTeam_DAL.CRDailyAttendanceWithTeamView( _
        '    useMonthYearLogin, _
        '    txtTeamNameView.Text, _
        '    txtMandorNameView.Text, _
        '    txtKraniNameView.Text, _
        '    dtpRDateView.Value)

        '    dgvDailyAWTView.DataSource = DT_DailyAttendanceWithTeamView

        '    If dgvDailyAWTView.Rows.Count = 0 Then
        '        MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        dgvDailyAWTView.Focus()
        '    End If

        'End If
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ' Sabtu, 24 Oct 2009, 16:41
        ClearAllInput()
        DT_DailyAttendance.Clear()
        btnActivity.Enabled = False
        dtpRDate.Enabled = True

    End Sub

    Private Sub ClearAllInput()
        ' Sabtu, 24 Oct 2009, 16:41
        lblDailyTeamActivityID.Text = String.Empty
        lblDailyReceiptionID.Text = String.Empty
        lblMandoreID.Text = String.Empty
        lblKraniID.Text = String.Empty
        lblGangMasterID.Text = String.Empty
        lblMandorEmpName.Text = String.Empty
        lblKraniEmpName.Text = String.Empty
        lblActivity.Text = String.Empty

        lblAttendanceSetupID.Text = String.Empty
        lblAttendType.Text = String.Empty
        LblBasicPay.Text = String.Empty
        lblEmpCategory.Text = String.Empty

        txtTeam.Text = String.Empty
        'lblActivity.Text = String.Empty

        txtAttendanceCode.Text = String.Empty
        txtOTHours.Text = "0"
        Me.DT_DailyAttendance.Clear()
        'If lblActivity.Text = "LAIN" Then
        '    txtOTHours.Enabled = True
        'ElseIf lblActivity.Text = "PANEN" Then
        '    txtOTHours.Enabled = False
        'End If
        'txtOTHours.Enabled = False

    End Sub

    Private Sub txtAttendanceCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAttendanceCode.KeyPress
        If e.KeyChar = vbCr Then
            Dim DT As DataTable
            DT = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect(txtAttendanceCode.Text, "")

            If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then

                lblAttendanceSetupID.Text = String.Empty
                LblBasicPay.Text = String.Empty
                lblAttendType.Text = "Not Valid !"

                'txtOTHours.Enabled = False

            ElseIf DT.Rows.Count = 1 Then

                txtAttendanceCode.Text = DT.Rows(0).Item("Att Code").ToString()
                lblAttendanceSetupID.Text = DT.Rows(0).Item("AttendanceSetupID").ToString()
                LblBasicPay.Text = DT.Rows(0).Item("BasicPay").ToString()
                lblAttendType.Text = DT.Rows(0).Item("Att Descp").ToString()

                If lblActivity.Text.ToUpper = "LAIN" Then
                    Dim DtOT As New DataTable()
                    DtOT = DailyAttendanceWithTeam_DAL.GetAttCodeInReception()
                    Dim DrOTAtt As DataRow
                    For Each DrOTAtt In DtOT.Rows
                        ' For Each drOT In dgvDailyAttendance.Rows
                        If (DrOTAtt("AttendanceCode").ToString = txtAttendanceCode.Text.Trim) Then
                            'txtOTHours.Enabled = True
                            ' txtOTHours.Focus()
                            Exit For
                        Else
                            'txtOTHours.Enabled = False
                            txtOTHours.Text = "0"
                            btnEditOrUpdate.Focus()

                        End If
                        'Next
                    Next
                ElseIf lblActivity.Text.ToUpper = "PANEN" Then
                    'txtOTHours.Enabled = False
                End If


                'If lblActivity.Text = "LAIN" Then
                '    If txtAttendanceCode.Text.Trim = "11" Or txtAttendanceCode.Text.Trim = "J1" Or txtAttendanceCode.Text.Trim = "51" Or txtAttendanceCode.Text.Trim = "M1" Or txtAttendanceCode.Text.Trim = "L1" Then
                '        txtOTHours.Enabled = True
                '        txtOTHours.Focus()

                '    Else
                '        txtOTHours.Enabled = False
                '        txtOTHours.Text = "0"
                '    End If
                'ElseIf lblActivity.Text = "PANEN" Then
                '    txtOTHours.Enabled = False
                'End If

                If LblBasicPay.Text = "N" Then
                    txtOTHours.Text = "0"
                    'txtOTHours.Enabled = False <=== Tidak ada OT untuk harvester
                    dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item("DADistributionColumn").Value = String.Empty
                    'Sabtu, 13 Feb 2010, 11:23
                    txtOTHours.Focus()
                    'END Sabtu, 13 Feb 2010, 11:23
                Else
                    'txtOTHours.Enabled = True <=== Tidak ada OT untuk harvester
                    dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item("DADistributionColumn").Value = "Receiption"
                    txtOTHours.Focus()
                End If

            End If

        End If
    End Sub

    Private Sub txtAttendanceCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAttendanceCode.Leave
        '
        Dim DT As DataTable
        DT = DailyAttendanceWithTeam_DAL.CRAttendanceSetupSelect(txtAttendanceCode.Text, "")

        If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then

            lblAttendanceSetupID.Text = String.Empty
            LblBasicPay.Text = String.Empty
            lblAttendType.Text = "Not Valid !"

            'txtOTHours.Enabled = False

            'MessageBox.Show("Attendance Code not found.", "Information", MessageBoxButtons.OK, _
            '                MessageBoxIcon.Information)

        ElseIf DT.Rows.Count = 1 Then

            txtAttendanceCode.Text = DT.Rows(0).Item("Att Code").ToString()
            lblAttendanceSetupID.Text = DT.Rows(0).Item("AttendanceSetupID").ToString()
            LblBasicPay.Text = DT.Rows(0).Item("BasicPay").ToString()
            lblAttendType.Text = DT.Rows(0).Item("Att Descp").ToString()


            If lblActivity.Text.ToUpper = "LAIN" Then
                Dim DtOT As New DataTable()
                DtOT = DailyAttendanceWithTeam_DAL.GetAttCodeInReception()
                Dim DrOTAtt As DataRow
                For Each DrOTAtt In DtOT.Rows
                    ' For Each drOT In dgvDailyAttendance.Rows
                    If (DrOTAtt("AttendanceCode").ToString = txtAttendanceCode.Text.Trim) Then
                        'txtOTHours.Enabled = True
                        ' txtOTHours.Focus()
                        Exit For
                        'Following lines commented by Palani
                        'Else
                        '    txtOTHours.Enabled = False
                        '    txtOTHours.Text = "0"
                    End If
                    'Next
                Next
            ElseIf lblActivity.Text.ToUpper = "PANEN" Then
                'txtOTHours.Enabled = False
            End If


            'If lblActivity.Text = "LAIN" Then
            '    If txtAttendanceCode.Text.Trim = "11" Or txtAttendanceCode.Text.Trim = "J1" Or txtAttendanceCode.Text.Trim = "51" Or txtAttendanceCode.Text.Trim = "M1" Or txtAttendanceCode.Text.Trim = "L1" Then
            '        txtOTHours.Enabled = True
            '        txtOTHours.Focus()

            '    Else
            '        txtOTHours.Enabled = False
            '        txtOTHours.Text = "0"
            '    End If
            'ElseIf lblActivity.Text = "PANEN" Then
            '    txtOTHours.Enabled = False
            'End If
            'If LblBasicPay.Text = "N" Then
            '    txtOTHours.Text = "0"
            '    'txtOTHours.Enabled = False
            '    dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item("DADistributionColumn").Value = String.Empty
            'Else
            '    'txtOTHours.Enabled = True
            '    dgvDailyAttendance.Rows(rowIndex_dgvDailyAttendance).Cells.Item("DADistributionColumn").Value = "Receiption"
            'End If

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DailyReceiptionWithTeam.ShowDialog()

    End Sub

    Private Sub chkDateView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateView.CheckedChanged
        ' Minggu, 11 Nov 2009, 12:18
        dtpRDateView.Enabled = chkDateView.Checked
    End Sub

    Private Sub dgvDailyAttendance_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDailyAttendance.Sorted
        ' Sabtu, 21 Nov 2009, 13:55
        ' Sekarang jenis team bukan lagi dari TeamCategory di GangMaster
        ' Tapi diambil dari DailyTeamActivity.Activity ->isinya adalah [PANEN atau LAIN]

        ' Ini perlu dilakukan lagi, soalnya setelah user meng-click column header utk sorting,
        ' kalo kita tdk memasukan ini lagi di event sorted
        ' maka columnnya (column type button ini) akan hilang
        If lblActivity.Text.ToUpper = "PANEN" Or lblActivity.Text.ToUpper = "DERES" Then
            'commented by nelson jun23-2010
            'For Each DR In dgvDailyAttendance.Rows

            '    If DR.Cells.Item("BasicPay").Value = "Y" Then
            '        DR.Cells.Item("DADistributionColumn").Value = "Reception"
            '    End If
            'Next
            'end

            'Added By nelson jun 23-2010
            Dim Dt As New DataTable()
            Dt = DailyAttendanceWithTeam_DAL.PremiAttCodeSelect()
            Dim Datarow1 As DataRow
            For Each Datarow1 In Dt.Rows
                For Each DR In dgvDailyAttendance.Rows

                    If DR.Cells.Item("BasicPay").Value = "Y" Then
                        If (DR.Cells.Item("DADistributionColumn").Value <> "Reception") Then


                            If (Datarow1("AttendanceSetupID").ToString = DR.Cells.Item("DAAttendanceSetupIDColumn").Value) Then
                                DR.Cells.Item("DADistributionColumn").Value = "Reception"
                            Else
                                DR.Cells.Item("DADistributionColumn").Value = ""
                            End If
                        End If
                    End If
                Next
            Next
            'end
        End If

    End Sub

    Private Sub btnAttendanceReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttendanceReport.Click
        '' Selasa, 29 Dec 2009, 18:53
        '' Place Kuala Lumpur
        'If dgvDailyAWTView.Rows.Count = 0 Then
        '    Exit Sub
        'End If

        'If dgvDailyAWTView.CurrentCell Is Nothing Then
        '    Exit Sub
        'End If

        'Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAWTView.DataSource, dgvDailyAWTView.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)

        '' Use Currency Manager and DataView to retrieve the Current Row
        'Dim dr As DataRow
        'dr = dv.Item(cm.Position).Row

        'Dim RDate As String
        'Dim GangName As String

        'RDate = CType(dr.Item("RDate"), Date).ToString("yyyy/MM/dd")
        'GangName = dr.Item("GangName").ToString()

        'Cursor = Cursors.WaitCursor

        'Dim report As New ViewReport()
        'Dim ReportName As String

        'ReportName = "CRDailyAttendanceWithTeamReport"
        'report._Source = ReportName
        'report._Formula = _
        '        "{CRDailyAttendanceWithTeamReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
        '        "{CRDailyAttendanceWithTeamReport;1.ActiveMonthYearId} ='" + GlobalPPT.strActMthYearID + "' AND " + _
        '        "{CRDailyAttendanceWithTeamReport;1.RDate} = #" + RDate + "# AND " + _
        '        "{CRDailyAttendanceWithTeamReport;1.GangName} = '" + GangName + "'"

        'report.ShowDialog()

        '  Cursor = Cursors.Default

        'Modified by kumar

        '----------------------------------
        ' Rekap Laporan Mandor Team Panen
        '----------------------------------
        ' By Dadang
        ' Jum'at, 08 Jan 2010, 11:59
        ' Place: Kuala Lumpur


        'Palani
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAWTView.DataSource, dgvDailyAWTView.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        Dim RDate As String
        Dim GangName As String
        Dim Activity As String

        Activity = dr.Item("Activity").ToString()
        If Activity.ToUpper = "PANEN" Then
            MessageBox.Show("Activity must be LAIN, please select another TEAM", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        RDate = CType(dr.Item("RDate"), Date).ToString("yyyy/MM/dd")
        GangName = dr.Item("GangName").ToString()

        Dim report As New ViewReport()
        Dim ReportName As String

        'ReportName = "CRRekapLapMandorLainMasterReport"
        ' Kamis, 18 Mar 2010, 18:31
        ReportName = "CRRekapLapMandorLainReport"
        ' END Kamis, 18 Mar 2010, 18:31
        report._Source = ReportName

        report._Formula = _
        "{CRRekapLapMandorLainReport;1.RDate} = #" + RDate + "# AND " + _
        "{CRRekapLapMandorLainReport;1.GangName} = '" + GangName + "'"

        report.ShowDialog()

        Cursor = Cursors.Default
        btnReceiptionReport.Focus()

    End Sub

    Private Sub btnReceiptionReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptionReport.Click
        '' Selasa, 29 Dec 2009, 19:26
        '' Place Kuala Lumpur
        If dgvDailyAWTView.Rows.Count = 0 Then
            Exit Sub
        End If

        If dgvDailyAWTView.CurrentCell Is Nothing Then
            Exit Sub
        End If

        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyAWTView.DataSource, dgvDailyAWTView.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        Dim RDate As String
        Dim GangName As String
        Dim Activity As String

        Activity = dr.Item("Activity").ToString()
        If Activity.ToUpper = "LAIN" Then
            MessageBox.Show("Activity must be PANEN, please select another TEAM", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If

        RDate = CType(dr.Item("RDate"), Date).ToString("yyyy/MM/dd")
        GangName = dr.Item("GangName").ToString()

        Cursor = Cursors.WaitCursor


        'Dim reportData As New ReportData
        'reportData.ReportObject = New CRDailyReceptionWithTeamByGangeReport()
        'Dim par1 As New ReportData.ReportParameter
        'par1.Name = "@EstateID"
        'par1.Value = GlobalPPT.strEstateID

        'Dim par2 As New ReportData.ReportParameter
        'par2.Name = "@ActiveMonthYearID"
        'par2.Value = GlobalPPT.strActMthYearID

        'Dim par3 As New ReportData.ReportParameter
        'par3.Name = "@RDate"
        'par3.Value = RDate

        'Dim par4 As New ReportData.ReportParameter
        'par4.Name = "@Gang"
        'par4.Value = GangName

        'Dim par5 As New ReportData.ReportParameter
        'par5.Name = "@User"
        'par5.Value = GlobalPPT.strUserName

        'reportData.Parameters = New List(Of ReportData.ReportParameter)
        'reportData.Parameters.Add(par1)
        'reportData.Parameters.Add(par2)
        'reportData.Parameters.Add(par3)
        'reportData.Parameters.Add(par4)
        'reportData.Parameters.Add(par5)

        'Dim reportViewer As New CRViewer(reportData)
        'reportViewer.ShowDialog()


        Dim report As New ViewReport()
        Dim ReportName As String

        ReportName = "CRDailyReceptionWithTeamByGangReport"
        report._Source = ReportName
        report._Formula = "[Checkroll].[CRDailyReceiptionWithTeamByGangeReport] @EstateID = '" + GlobalPPT.strEstateID + "', @ActiveMonthYearID='" + GlobalPPT.strActMthYearID + "',@RDate='" + RDate + "',@Gang='" + GangName + "', @User='" + GlobalPPT.strUserName + "'"

        report.ShowDialog()

        Cursor = Cursors.Default




    End Sub

    Private Sub tcDailyAttendance_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcDailyAttendance.SelectedIndexChanged
        ' dtpRDateView.Enabled = False
        If tcDailyAttendance.SelectedIndex = 1 Then
            chkDateView.Checked = False
            dtpRDateView.Value = GlobalPPT.FiscalYearToDate
            txtTeamNameView.Text = ""
            txtMandorNameView.Text = ""
            cboActivityView.Text = "All"
            DoSearch()
            txtTeamNameView.Focus()
        ElseIf tcDailyAttendance.SelectedIndex = 0 Then

            If dgvDailyAttendance.Rows.Count > 0 Then
                dtpRDate.Enabled = False
            Else
                dtpRDate.Enabled = True
            End If

            txtTeam.Focus()

        End If
    End Sub

    Private Sub DailyAttendanceWithTeam_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnProcessPremi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessPremi.Click
        Dim winDetailPremi As New DetailPremiProcess()
        winDetailPremi.Show()
    End Sub

    Private Sub btnProcessOT_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessOT.Click
        Dim winDetailPremi As New DetailOTProcess()
        winDetailPremi.Show()
    End Sub

    Private Sub txtAttendanceCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAttendanceCode.TextChanged

    End Sub
End Class