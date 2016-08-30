Imports Vehicle_BOL
Imports Vehicle_PPT
Imports Common_PPT
Imports Common_BOL
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports Store_PPT
Imports Store_BOL

Public Class WorkShopLogFrm

    Dim _Validator As Validator
    Dim _WorkshopLogPPT As WorkshopLogPPT
    Dim _WorkshopLogBOL As WorkshopLogBOL

    Dim dsWorkshopCode As DataSet
    Dim dsWorkshopDetails As DataSet

    Private _lookupCode As String = String.Empty
    Private _lookupId As String = String.Empty
    Private _lookupDesc As String = String.Empty
    Private _lookupValue As String = String.Empty

    'Dim psWLVHID As String = String.Empty
    Dim psWLAccountID As String = String.Empty
    Dim psWLOperatorID As String = String.Empty
    Dim psWLBlockID As String = String.Empty
    Dim psWLDivID As String = String.Empty
    Dim psWLYopID As String = String.Empty
    Dim psWLT0analysisID As String = String.Empty
    Dim psWLT1analysisID As String = String.Empty
    Dim psWLT2analysisID As String = String.Empty
    Dim psWLT3analysisID As String = String.Empty
    Dim psWLT4analysisID As String = String.Empty

    Dim lbConcurrencyID As Byte() = New Byte(7) {}

    Dim lsErrorMessage As String
    Dim liIdForRecordEdit As Integer
    Private dateIsChangedByUser As Boolean = False
    Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
    Dim Expression As New System.Text.RegularExpressions.Regex("^(0[1-9]|1[0-2])(:[0-5]\d){1,2}\s{0}[ap/AP][m/M]$")
    Dim lsVDExpenditureAG As String = String.Empty

    Private Shared lsStartTime As String
    Private Shared lsEndTime As String

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

#Region "Events"

#Region "Common"

    Private Sub WorkshopLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture
        Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("en-US")

        ibtnLookUpDIV.Visible = False

        'ClearDisplayRefText()

        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M70" Then

            SetUICulture(GlobalPPT.strLang)
            'dtpSearchBydate.MinDate = GlobalPPT.FiscalYearFromDate
            'dtpSearchBydate.MaxDate = GlobalPPT.FiscalYearToDate

            'dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
            'dtpDate.MaxDate = GlobalPPT.FiscalYearToDate

            'Me.dtpSearchBydate.Text = dtpSearchBydate.MinDate
            'Me.dtpDate.Text = dtpDate.MinDate

            'General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "WorkshopLog", "LogDate")
            'General.SetVehicleDateTimePicker(dtpSearchBydate, "Vehicle", "WorkshopLog", "LogDate")

            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSearchBydate)

            BindWorkshopCodeInComboBox()
            BindWorkshopCode(String.Empty, String.Empty)

            dgWorkshopRunningLog.Columns("LogDate").DefaultCellStyle.Format = "dd/MM/yyyy"
            dgWorkshop.Columns("WDate").DefaultCellStyle.Format = "dd/MM/yyyy"
            dgWorkshopRunningLog.Columns("StartTime").DefaultCellStyle.Format = "t"
            dgWorkshopRunningLog.Columns("EndTime").DefaultCellStyle.Format = "t"

            tbcWorkshop.SelectedIndex = 1

            dtpSearchBydate.Enabled = False

            chkDate.Focus()

        End If

    End Sub

    Private Sub WorkShopLogFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub tbcWorkshop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcWorkshop.SelectedIndexChanged

        Select Case tbcWorkshop.SelectedIndex
            Case 0
                cmbWorkshopCode.SelectedIndex = 0
                Reset()
                dtpDate.Focus()
                Me.ResetViewArea()
                EnableAllControls()

                'ClearDisplayRefText()
                'Me.BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("01/01/1753"))
                If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If
            Case 1
                Me.ResetViewArea()
                Me.BindWorkshopCode(String.Empty, String.Empty)
                'Me.BindWorkshopCode(String.Empty, "Go")
                EnableAllControls()

                chkDate.Focus()
                If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If
        End Select

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgWorkshop.DataBindingComplete, dgWorkshopRunningLog.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

#End Region

#Region "Entry Tab"

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged

        'If Me.cmbWorkshopCode.Text <> String.Empty And Me.dateIsChangedByUser Then

        '    Me.cmbWorkshopCode.Text = String.Empty
        '    Me.btnSaveOrUpdate.Text = "Save"
        '    Me.cmbWorkshopCode.Text = String.Empty
        '    ResetControls()

        '    ResetRequiredControls()

        '    lblT0Name.Text = String.Empty
        '    lblT1Name.Text = String.Empty
        '    lblT2Name.Text = String.Empty
        '    lblT3Name.Text = String.Empty
        '    lblT4Name.Text = String.Empty

        '    BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))

        '    txtAccountCode.Text = String.Empty
        '    lblShowAccountCodeDesc.Text = String.Empty
        'End If

        Me.Reset()

    End Sub

    Private Sub dtpDate_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.DropDown
        Me.dateIsChangedByUser = True
    End Sub

    Private Sub dtpDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.CloseUp
        Me.dateIsChangedByUser = False
    End Sub

    Private Sub cmbWorkshopCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkshopCode.SelectedIndexChanged

        If cmbWorkshopCode.SelectedIndex > 0 Then
            lblShowWorkshopDesc.Text = cmbWorkshopCode.SelectedValue

            'Me.btnSaveOrUpdate.Text = "Save"
            'Me.Reset()

            'This is added to reset
            'Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.SelectedText.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))

        Else
            lblShowWorkshopDesc.Text = String.Empty
        End If

        'Me.btnSaveOrUpdate.Text = "Save"


        If GlobalPPT.strLang = "en" Then
            btnSaveOrUpdate.Text = "Save "
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveOrUpdate.Text = "Simpan "
        End If
        Me.Reset()

    End Sub

    Private Sub ibtnSearchVehicle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchVehicle.Click

        Dim _VHCodeLookup As New WSVehicleLookupfrm()
        Dim result As DialogResult = _VHCodeLookup.ShowDialog()

        If (result = DialogResult.OK) Then

            '_lookupCode = _VHCodeLookup.lVHCode
            txtVehicleCode.Text = _VHCodeLookup.lVHCode '_lookupCode
            lblShowVehicleDesc.Text = _VHCodeLookup.lVHDescp
            'psWLVHID = _VHCodeLookup.lVHID
            'Dim lsCode = _lookupCode
            'Me.btnSaveOrUpdate.Text = "Save"
            'Me.ResetRequiredMainControls()
            'Me.ResetRequiredControls()
            'Me.ResetControls()

            'BindWorkshopLogDetailsByWorkshopCode(txtVehicleCode.Text, CDate(Me.dtpDate.Value))

        End If
    End Sub

    Private Sub ibtnSearchOperatorCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchOperatorCode.Click
        Dim _OperatorLookup As New OperatorLookup()
        Dim result As DialogResult = _OperatorLookup.ShowDialog()

        If (result = DialogResult.OK) Then

            '_lookupCode = _OperatorLookup.lEmpCode
            '_lookupId = _OperatorLookup.lEmpId
            '_lookupDesc = _OperatorLookup.lEmpName

            txtOperatorCode.Text = _OperatorLookup.lEmpCode '_lookupCode
            lblShowOperatorName.Text = _OperatorLookup.lEmpName '_lookupDesc
            psWLOperatorID = _OperatorLookup.lEmpId
        End If
    End Sub

    Private Sub ibtnSearchAccountCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchAccountCode.Click

        Dim frmAcctcodeLookup As New COALookup
        frmAcctcodeLookup.ShowDialog()
        If frmAcctcodeLookup.strAcctId <> String.Empty Then
            Me.txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            psWLAccountID = frmAcctcodeLookup.strAcctId
            lblShowAccountCodeDesc.Text = frmAcctcodeLookup.strAcctDescp
            txtAccountCode.Text = frmAcctcodeLookup.strAcctcode
            GlobalPPT.psAcctExpenditureType = frmAcctcodeLookup.strAcctExpenditureAG
            lsVDExpenditureAG = frmAcctcodeLookup.strAcctExpenditureAG
            lblShowOldAccountCode.Text = frmAcctcodeLookup.strOldAccountCode

        End If


        ' ''Dim result As DialogResult = COALookup.ShowDialog()
        ' ''If COALookup.DialogResult = Windows.Forms.DialogResult.OK Then
        ' ''    _lookupId = COALookup.strAcctId
        ' ''    _lookupCode = COALookup.strAcctcode
        ' ''    _lookupDesc = COALookup.strAcctDescp
        ' ''    '_lookupOldCode = COALookup.strOldAccountCode
        ' ''    txtAccountCode.Text = _lookupCode
        ' ''    lblShowAccountCodeDesc.Text = _lookupDesc
        ' ''    lblOldAccountCode.Text = COALookup.strOldAccountCode
        ' ''End If

        'Dim _AccountLookup As New AccountLookup()
        'Dim result As DialogResult = _AccountLookup.ShowDialog()

        'If (result = DialogResult.OK) Then

        '    _lookupCode = _AccountLookup.strAcctcode ' _lcoaCode
        '    _lookupId = _AccountLookup.strAcctId ' _lcoaId
        '    _lookupDesc = _AccountLookup.strAcctDescp ' _lcoaDescription

        '    txtAccountCode.Text = _lookupCode
        '    lblShowAccountCodeDesc.Text = _lookupDesc
        'End If

    End Sub

    Private Sub ibtnSearchBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLookUpSubBlock.Click

        Dim frmSubBlock As New VHDistributionSubBlockLookup
        Dim result As DialogResult = frmSubBlock.ShowDialog()
        If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
            txtSubBlock.Text = frmSubBlock.psBlockName
            psWLBlockID = frmSubBlock.psBlockId
            'lblSubBlockStatus.Text = frmSubBlock.psBlockStatus
            Me.txtDIV.Text = frmSubBlock.psDIV
            psWLDivID = frmSubBlock.psDIVID
            Me.txtYOP.Text = frmSubBlock.psYop
            psWLYopID = frmSubBlock.psYopID
            '  txtSubBlock.Text = frmSubBlock.psBlockName
        End If

    End Sub

    Private Sub TAnalysis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT0.Leave, txtT1.Leave, txtT2.Leave, txtT3.Leave, txtT4.Leave

        Dim _txtTAnalysis As TextBox = DirectCast(sender, TextBox)
        Dim _Tlookup As New WSTlookup

        If _txtTAnalysis.Text.Trim() <> String.Empty Then

            Dim ds As New DataSet
            Dim objWL As New VehicleDistributionPPT

            Select Case _txtTAnalysis.AccessibleName
                Case "T0"
                    objWL.TDecide = "T0"
                    objWL.T0Value = _txtTAnalysis.Text.Trim()
                Case "T1"
                    objWL.TDecide = "T1"
                    objWL.T1Value = _txtTAnalysis.Text.Trim()
                Case "T2"
                    objWL.TDecide = "T2"
                    objWL.T2Value = _txtTAnalysis.Text.Trim()
                Case "T3"
                    objWL.TDecide = "T3"
                    objWL.T3Value = _txtTAnalysis.Text.Trim()
                Case "T4"
                    objWL.TDecide = "T4"
                    objWL.T4Value = _txtTAnalysis.Text.Trim()
                    'Case Else
                    '    objWL.TDecide = "T0"
                    '    objWL.T0Value = _txtTAnalysis.Text.Trim()
            End Select

            ds = VehicleDistributionBOL.TlookupSearch(objWL, "YES")

            If ds.Tables(0).Rows.Count = 0 Then

                'MessageBox.Show("Invalid, Please Choose it from look up", _txtTAnalysis.AccessibleName)

                Select Case _txtTAnalysis.AccessibleName
                    Case "T0"
                        DisplayInfoMessage("IT0")
                        'MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                        'Me.lblT0Name.Text = String.Empty
                        Me.txtT0.Text = String.Empty
                        txtT0.Focus()
                        psWLT0analysisID = String.Empty
                    Case "T1"
                        'MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
                        'Me.lblT1Name.Text = String.Empty
                        DisplayInfoMessage("IT1")
                        Me.txtT1.Text = String.Empty
                        txtT1.Focus()
                        psWLT1analysisID = String.Empty
                    Case "T2"
                        'MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
                        'Me.lblT2Name.Text = String.Empty
                        Me.txtT2.Text = String.Empty
                        DisplayInfoMessage("IT2")
                        txtT2.Focus()
                        psWLT2analysisID = String.Empty
                    Case "T3"
                        'MessageBox.Show("Invalid T3 Value,Please Choose it from look up")
                        'Me.lblT3Name.Text = String.Empty
                        DisplayInfoMessage("IT3")
                        Me.txtT3.Text = String.Empty
                        txtT3.Focus()
                        psWLT3analysisID = String.Empty
                    Case "T4"
                        'MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
                        'Me.lblT4Name.Text = String.Empty
                        DisplayInfoMessage("IT4")
                        Me.txtT4.Text = String.Empty
                        txtT4.Focus()
                        psWLT4analysisID = String.Empty
                        'Case Else
                        '    'MessageBox.Show("Invalid T0 Value,Please Choose it from look up")
                        '    'Me.lblT0Name.Text = String.Empty
                        '    DisplayInfoMessage("IT0")
                        '    Me.txtT0.Text = String.Empty
                        '    txtT0.Focus()
                End Select

            Else
                Dim lsTId As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TAnalysisId")), String.Empty, ds.Tables(0).Rows(0).Item("TAnalysisId"))
                Dim lsTName As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TAnalysisDescp")), String.Empty, ds.Tables(0).Rows(0).Item("TAnalysisDescp"))
                Dim lsTValue As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TValue")), String.Empty, ds.Tables(0).Rows(0).Item("TValue"))

                Select Case _txtTAnalysis.AccessibleName
                    Case "T0"
                        psWLT0analysisID = lsTId
                        Me.lblT0Name.Text = lsTName
                        Me.txtT0.Text = lsTValue
                    Case "T1"
                        psWLT1analysisID = lsTId
                        Me.lblT1Name.Text = lsTName
                        Me.txtT1.Text = lsTValue
                    Case "T2"
                        psWLT2analysisID = lsTId
                        Me.lblT2Name.Text = lsTName
                        Me.txtT2.Text = lsTValue
                    Case "T3"
                        psWLT3analysisID = lsTId
                        Me.lblT3Name.Text = lsTName
                        Me.txtT3.Text = lsTValue
                    Case "T4"
                        psWLT4analysisID = lsTId
                        Me.lblT4Name.Text = lsTName
                        Me.txtT4.Text = lsTValue
                        'Case Else
                        '    Me.lblT0Name.Text = lsTName
                        '    Me.txtT0.Text = lsTValue
                End Select

            End If
        Else
            Select Case _txtTAnalysis.AccessibleName
                Case "T0"
                    Me.lblT0Name.Text = String.Empty
                    psWLT0analysisID = String.Empty
                Case "T1"
                    Me.lblT1Name.Text = String.Empty
                    psWLT1analysisID = String.Empty
                Case "T2"
                    Me.lblT2Name.Text = String.Empty
                    psWLT2analysisID = String.Empty
                Case "T3"
                    Me.lblT3Name.Text = String.Empty
                    psWLT3analysisID = String.Empty
                Case "T4"
                    Me.lblT4Name.Text = String.Empty
                    psWLT4analysisID = String.Empty
                    'Case Else
                    '    Me.lblT0Name.Text = String.Empty
            End Select
        End If

    End Sub

    Private Sub ibtnSearchTAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchTAnalysisT0.Click, ibtnSearchTAnalysisT1.Click, ibtnSearchTAnalysisT2.Click, ibtnSearchTAnalysisT3.Click, ibtnSearchTAnalysisT4.Click

        Dim _BtnTAnalysis As Button = sender
        Dim _Tlookup As New WSTlookup

        ''Create an _ect for the class and pass the constructor value to the form
        Select Case _BtnTAnalysis.AccessibleName
            Case "T0"
                WSTlookup.strTcodeDecide = "T0"
            Case "T1"
                WSTlookup.strTcodeDecide = "T1"
            Case "T2"
                WSTlookup.strTcodeDecide = "T2"
            Case "T3"
                WSTlookup.strTcodeDecide = "T3"
            Case "T4"
                WSTlookup.strTcodeDecide = "T4"
        End Select

        Dim result As DialogResult = _Tlookup.ShowDialog()

        If (result = DialogResult.OK) Then
            _lookupCode = _Tlookup.strTCode
            _lookupId = _Tlookup.strTId
            _lookupValue = _Tlookup.strTValue
            _lookupDesc = _Tlookup.strTDesc
            'Else
            '    _lookupCode = String.Empty
            '    _lookupId = String.Empty
            '    _lookupValue = String.Empty
            '    _lookupDesc = String.Empty
            Select Case _BtnTAnalysis.AccessibleName
                Case "T0"
                    psWLT0analysisID = _lookupId
                    txtT0.Text = _lookupValue
                    lblT0Name.Text = _lookupDesc
                Case "T1"
                    psWLT1analysisID = _lookupId
                    txtT1.Text = _lookupValue
                    lblT1Name.Text = _lookupDesc
                Case "T2"
                    psWLT2analysisID = _lookupId
                    txtT2.Text = _lookupValue
                    lblT2Name.Text = _lookupDesc
                Case "T3"
                    psWLT3analysisID = _lookupId
                    txtT3.Text = _lookupValue
                    lblT3Name.Text = _lookupDesc
                Case "T4"
                    psWLT4analysisID = _lookupId
                    txtT4.Text = _lookupValue
                    lblT4Name.Text = _lookupDesc
            End Select
        End If

    End Sub

    Private Sub btnSaveOrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveOrUpdate.Click

        If (CheckRequiredFields()) Then
            If IsValidTime(lsStartTime.Trim, lsEndTime.Trim, String.Empty) Then
                If IsForeignKeyValueExist() Then

                    If Not IsValidAccountAndBlockCodeCombination() Then
                        Return
                    End If

                    'If Not IsVehicleCodeAlreadyExists() Then

                    _WorkshopLogPPT = New WorkshopLogPPT
                    _WorkshopLogBOL = New WorkshopLogBOL

                    '_WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
                    '_WorkshopLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
                    _WorkshopLogPPT.psWorkVHID = Me.cmbWorkshopCode.Text
                    _WorkshopLogPPT.pdLogDateDT = New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day)
                    _WorkshopLogPPT.psVHID = Me.txtVehicleCode.Text.Trim()

                    Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
                    Dim ldReturnIn24HrsTimeFormat As DateTime

                    If lsStartTime.Trim <> String.Empty Then
                        ldReturnIn24HrsTimeFormat = DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
                        _WorkshopLogPPT.pdStartTimeDT = New TimeSpan(ldReturnIn24HrsTimeFormat.Hour, ldReturnIn24HrsTimeFormat.Minute, ldReturnIn24HrsTimeFormat.Second) 'TimeSpan.Parse(lsStartTime.Trim)
                    End If

                    If lsEndTime.Trim <> String.Empty Then
                        ldReturnIn24HrsTimeFormat = DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
                        _WorkshopLogPPT.pdEndTimeDT = New TimeSpan(ldReturnIn24HrsTimeFormat.Hour, ldReturnIn24HrsTimeFormat.Minute, ldReturnIn24HrsTimeFormat.Second) 'TimeSpan.Parse(txtEndTime.Text.Trim)
                    End If

                    If txtTotalHrs.Text.Trim <> String.Empty Then
                        'ldReturnIn24HrsTimeFormat = DateTime.Parse(txtTotalHrs.Text.Trim + ":00", culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
                        '_WorkshopLogPPT.pdTotalHrsDT = New TimeSpan(ldReturnIn24HrsTimeFormat.Hour, ldReturnIn24HrsTimeFormat.Minute, ldReturnIn24HrsTimeFormat.Second) 'TimeSpan.Parse(txtTotalHrs.Text.Trim)

                        _WorkshopLogPPT.pdTotalHrsDT = txtTotalHrs.Text.Trim
                        '_WorkshopLogPPT.pdTotalHrsDT = txtTotalHrs.Text.Trim
                    End If

                    _WorkshopLogPPT.psActivity = Me.txtActivity.Text.Trim()
                    _WorkshopLogPPT.psEmpID = psWLOperatorID 'Me.txtOperatorCode.Text.Trim()
                    _WorkshopLogPPT.psCOAID = psWLAccountID  'Me.txtAccountCode.Text.Trim()
                    _WorkshopLogPPT.psDivID = psWLDivID  'Me.txtDIV.Text.Trim()
                    _WorkshopLogPPT.psYOPID = psWLYopID  'Me.txtYOP.Text.Trim()
                    _WorkshopLogPPT.psBlockID = psWLBlockID 'Me.txtSubBlock.Text.Trim()

                    If txtSubBlock.Text <> "" Then
                        _WorkshopLogPPT.psDivID = psWLDivID  'Me.txtDIV.Text.Trim()
                        _WorkshopLogPPT.psYOPID = psWLYopID  'Me.txtYOP.Text.Trim()
                        _WorkshopLogPPT.psBlockID = psWLBlockID 'Me.txtSubBlock.Text.Trim()
                    Else
                        _WorkshopLogPPT.psDivID = ""
                        _WorkshopLogPPT.psYOPID = ""
                        _WorkshopLogPPT.psBlockID = ""

                    End If

                    _WorkshopLogPPT.psT0 = psWLT0analysisID 'Me.txtT0.Text.Trim()
                    _WorkshopLogPPT.psT1 = psWLT1analysisID 'Me.txtT1.Text.Trim()
                    _WorkshopLogPPT.psT2 = psWLT2analysisID 'Me.txtT2.Text.Trim()
                    _WorkshopLogPPT.psT3 = psWLT3analysisID 'Me.txtT3.Text.Trim()
                    _WorkshopLogPPT.psT4 = psWLT4analysisID 'Me.txtT4.Text.Trim()

                    '_WorkshopLogPPT.psTDescp0 = Me.lblT0Name.Text.Trim()
                    '_WorkshopLogPPT.psTDescp1 = Me.lblT1Name.Text.Trim()
                    '_WorkshopLogPPT.psTDescp2 = Me.lblT2Name.Text.Trim()
                    '_WorkshopLogPPT.psTDescp3 = Me.lblT3Name.Text.Trim()
                    '_WorkshopLogPPT.psTDescp4 = Me.lblT4Name.Text.Trim()

                    Dim liMsg As Integer

                    If btnSaveOrUpdate.Text.Trim = "Save" Then

                        '_WorkshopLogPPT.psCreatedBy = GlobalPPT.strUserName
                        'General.ShowMessageFromDataBase(_WorkshopLogBOL.SaveWorkshopLog(_WorkshopLogPPT))

                        liMsg = _WorkshopLogBOL.SaveWorkshopLog(_WorkshopLogPPT)
                        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                            MsgBox(PrivilegeError)
                        End If
                    ElseIf btnSaveOrUpdate.Text.Trim = "Update" Then

                        '_WorkshopLogPPT.psModifiedBy = GlobalPPT.strUserName
                        _WorkshopLogPPT.piId = liIdForRecordEdit
                        _WorkshopLogPPT.pbConcurrencyId = lbConcurrencyID


                        liMsg = _WorkshopLogBOL.UpdateWorkshopLog(_WorkshopLogPPT)

                        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                            MsgBox(PrivilegeError)
                        End If
                    End If

                    txtStartHr.Enabled = True
                    txtStartMin.Enabled = True
                    txtEndHr.Enabled = True
                    txtEndMin.Enabled = True

                    'cmbStartHrs.Enabled = True
                    'cmbStartMin.Enabled = True
                    'cmbEndHrs.Enabled = True
                    'cmbEndMin.Enabled = True



                    If liMsg = 11 Then ''Code 4 - Unable to save/update the record.
                        'MsgBox("Vehicle already in use for the specified time. Refer vehicle running log screen.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                        DisplayInfoMessage("UsedVehicleSomeWhere")
                        Return
                        'ElseIf liMsg = 6 Then
                        '    'MsgBox("Current data conflicts with existing data in the database. Please modify start time and/or end time.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                        '    DisplayInfoMessage("StartEndTimeExist")
                        '    Return
                    ElseIf liMsg = 10 Then
                        General.ShowMessageFromDataBase(liMsg)
                        Return
                        'ElseIf liMsg = 11 Then
                        '    DisplayInfoMessage("UsedVehicleSomeWhere")
                        '    Return
                    Else
                        General.ShowMessageFromDataBase(liMsg)
                        'btnSaveOrUpdate.Text = "Save"
                        If GlobalPPT.strLang = "en" Then
                            btnSaveOrUpdate.Text = "Save"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveOrUpdate.Text = "Simpan"
                        End If
                    End If

                    If liMsg <> 12 Then
                        'Me.ResetRequiredMainControls()
                        'ResetRequiredControls()
                        'ResetControls()

                        'BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))

                        'BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))
                        ' Me.tbcWorkshop.SelectedIndex = 1
                        Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.Text.Trim, dtpDate.Value)
                        ResetControls()
                        ResetRequiredControls()


                    Else
                        Return
                    End If

                End If
                'End If
            End If
        End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        cmbWorkshopCode.SelectedIndex = 0
        Reset()
        EnableAllControls()

        'ClearDisplayRefText()


        '   dtpDate.Focus()

    End Sub

    Private Sub dgWorkshopRunningLog_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWorkshopRunningLog.MouseClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgWorkshopRunningLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgWorkshopRunningLog.CurrentRow IsNot Nothing And dgWorkshopRunningLog.CurrentRow.Selected Then
            If dgWorkshopRunningLog.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then
                Me.cmsAddEditDelete.Show(Me.dgWorkshopRunningLog, e.Location)
            End If
        End If

        'End If
    End Sub

    Private Sub dgWorkshopRunningLog_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWorkshopRunningLog.MouseDoubleClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgWorkshopRunningLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgWorkshopRunningLog.CurrentRow IsNot Nothing And dgWorkshopRunningLog.CurrentRow.Selected Then

            If dgWorkshopRunningLog.CurrentRow.Index >= 0 And dgWorkshopRunningLog.CurrentCell.ColumnIndex >= 0 Then

                If Convert.ToString(dgWorkshopRunningLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

                    Dim liID As Integer = DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer)
                    Dim lsWorkshopCode As String = dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value
                    Dim ldLogDate As Date = dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value

                    '                    BindWorkshopLogDetailsByWorkshopCode(dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value, dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value)
                    'BindWorkshopLogDetailsByWorkshopCode(dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value, dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value)
                    ShowWorkshopDetailsByID(liID)
                    'btnSaveOrUpdate.Text = "Update"
                    If GlobalPPT.strLang = "en" Then
                        btnSaveOrUpdate.Text = "Update"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveOrUpdate.Text = "Memperbarui"
                    End If
                    'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
                    'ResetControls("EnableControls")
                    DisableControls()
                    DisableAllControls()
                    DisplayInfoMessage("MsgPosted")
                    Return
                    'BindWorkshopLogDetailsByWorkshopCode(lsWorkshopCode, ldLogDate)
                    'cmsDelete.Visible = False

                Else

                    ' Load context menu on right mouse click

                    If e.Button = MouseButtons.Left Then

                        liIdForRecordEdit = DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer)

                        Dim lsWorkshopCode As String = dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value
                        Dim ldLogDate As Date = dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value

                        '   BindWorkshopLogDetailsByWorkshopCode(dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value, dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value)
                        ShowWorkshopDetailsByID(liIdForRecordEdit)

                        'btnSaveOrUpdate.Text = "Update"
                        If GlobalPPT.strLang = "en" Then
                            btnSaveOrUpdate.Text = "Update"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveOrUpdate.Text = "Memperbarui"
                        End If

                        EnableControls()

                        cmbWorkshopCode.Enabled = False
                        dtpDate.Enabled = False

                        BindWorkshopLogDetailsByWorkshopCode(lsWorkshopCode, ldLogDate)

                    End If
                End If

            End If
        End If
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dgWorkshopRunningLog_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgWorkshopRunningLog.KeyDown
        If e.KeyCode <> 13 Then
            Return
        End If
        If dgWorkshopRunningLog.CurrentRow IsNot Nothing And dgWorkshopRunningLog.CurrentRow.Selected Then
            If Convert.ToString(dgWorkshopRunningLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

                ShowWorkshopDetailsByID(DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer))
                'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
                DisableAllControls()
                DisableControls()
                DisplayInfoMessage("MsgPosted")
                btnSaveOrUpdate.Enabled = False
                Return
            Else
                If dgWorkshopRunningLog.CurrentRow.Index >= 0 And dgWorkshopRunningLog.CurrentCell.ColumnIndex >= 0 Then
                    If e.KeyCode = 13 Then
                        e.Handled = True

                        ShowWorkshopDetailsByID(DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer))
                        'btnSaveOrUpdate.Text = "Update"
                        If GlobalPPT.strLang = "en" Then
                            btnSaveOrUpdate.Text = "Update"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveOrUpdate.Text = "Memperbarui"
                        End If
                        btnSaveOrUpdate.Enabled = True

                        liIdForRecordEdit = DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer)

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmsAddEditDelete_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cmsAddEditDelete.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then 'If e.KeyCode = 46 Or e.KeyCode = 110 Then
            DeleteWorkshopLog()
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        ResetFromCMS(dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value, CDate(dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value))

        If Convert.ToString(dgWorkshopRunningLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")

            DisableControls()
            DisableAllControls()
            DisplayInfoMessage("MsgPosted")
            Return
        Else
            EnableControls()
        End If

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
       
        If Convert.ToString(dgWorkshopRunningLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

            ShowWorkshopDetailsByID(DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer))
            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            DisableControls()
            DisableAllControls()
            DisplayInfoMessage("MsgPosted")
            Return
        Else
            ShowWorkshopDetailsByID(DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer))

            'btnSaveOrUpdate.Text = "Update"
            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Memperbarui"
            End If
            liIdForRecordEdit = DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("ID").Value, Integer)

            EnableControls()
            If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteWorkshopLog()
    End Sub

    Private Sub txtStartHr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartHr.Leave
        If txtStartHr.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([01]\d|2[0123])$")
            If Not rtime.IsMatch(txtStartHr.Text.Trim) Then
                DisplayInfoMessage("IStartHrs")
                txtStartHr.Focus()
            End If
        End If
        If txtStartHr.Text.Trim <> String.Empty And txtStartMin.Text.Trim <> String.Empty Then
            lsStartTime = String.Format("{0:00}", Convert.ToInt32(txtStartHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtStartMin.Text.Trim))
            CalculateTotalHrs()
        Else
            lsStartTime = String.Empty
            txtTotalHrs.Text = String.Empty
        End If
    End Sub

    Private Sub txtStartMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartMin.Leave
        If txtStartMin.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([0-5][0-9])$")
            If Not rtime.IsMatch(txtStartMin.Text.Trim) Then
                DisplayInfoMessage("IStartMin")
                txtStartMin.Focus()
            End If
        End If
        If txtStartHr.Text.Trim <> String.Empty And txtStartMin.Text.Trim <> String.Empty Then
            lsStartTime = String.Format("{0:00}", Convert.ToInt32(txtStartHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtStartMin.Text.Trim))
            CalculateTotalHrs()
        Else
            lsStartTime = String.Empty
            txtTotalHrs.Text = String.Empty
        End If
    End Sub

    Private Sub txtEndHr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndHr.Leave
        If txtEndHr.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([01]\d|2[0123])$")
            If Not rtime.IsMatch(txtEndHr.Text.Trim) Then
                DisplayInfoMessage("IEndHrs")
                txtEndHr.Focus()
            End If
        End If

        If txtEndHr.Text.Trim <> String.Empty And txtEndMin.Text.Trim <> String.Empty Then
            lsEndTime = String.Format("{0:00}", Convert.ToInt32(txtEndHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtEndMin.Text.Trim))
            CalculateTotalHrs()

        Else
            lsEndTime = String.Empty
            txtTotalHrs.Text = String.Empty
        End If
    End Sub

    Private Sub txtEndMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndMin.Leave
        If txtEndMin.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([0-5][0-9])$")
            If Not rtime.IsMatch(txtEndMin.Text.Trim) Then
                DisplayInfoMessage("IEndMin")
                txtEndMin.Focus()
            End If
        End If

        If txtEndHr.Text.Trim <> String.Empty And txtEndMin.Text.Trim <> String.Empty Then
            lsEndTime = String.Format("{0:00}", Convert.ToInt32(txtEndHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtEndMin.Text.Trim))
            CalculateTotalHrs()
        Else
            lsEndTime = String.Empty
            txtTotalHrs.Text = String.Empty
        End If
    End Sub

    'Private Sub cmbStartHrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbStartHrs.SelectedIndex >= 0 And cmbStartMin.SelectedIndex >= 0 Then
    '        lsStartTime = String.Format("{0:00}", Convert.ToInt32(cmbStartHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbStartMin.Text))

    '        CalculateTotalHrs()
    '    Else
    '        lsStartTime = String.Empty
    '    End If

    'End Sub

    'Private Sub cmbStartMin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbStartHrs.SelectedIndex >= 0 And cmbStartMin.SelectedIndex >= 0 Then
    '        lsStartTime = String.Format("{0:00}", Convert.ToInt32(cmbStartHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbStartMin.Text))
    '        CalculateTotalHrs()
    '    Else
    '        lsStartTime = String.Empty
    '    End If
    'End Sub

    'Private Sub cmbEndHrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbEndHrs.SelectedIndex >= 0 And cmbEndMin.SelectedIndex >= 0 Then
    '        lsEndTime = String.Format("{0:00}", Convert.ToInt32(cmbEndHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbEndMin.Text))
    '        CalculateTotalHrs()
    '    Else
    '        lsEndTime = String.Empty
    '    End If
    'End Sub

    'Private Sub cmbEndMin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbEndHrs.SelectedIndex >= 0 And cmbEndMin.SelectedIndex >= 0 Then
    '        lsEndTime = String.Format("{0:00}", Convert.ToInt32(cmbEndHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbEndMin.Text))
    '        CalculateTotalHrs()
    '    Else
    '        lsEndTime = String.Empty
    '    End If
    'End Sub

#End Region

#Region "ViewTab"

    Private Sub tsmiViewAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiViewAdd.Click
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        tbcWorkshop.SelectedIndex = 0

        ResetFromCMS(dgWorkshop.CurrentRow.Cells("WorkshopCode").Value, CDate(dgWorkshop.CurrentRow.Cells("WDate").Value))
        ' txtVehicleCode.Text = dgWorkshop.CurrentRow.Cells("WorkshopCode").Value
        dtpDate.Value = CDate(dgWorkshop.CurrentRow.Cells("WDate").Value)

        If Convert.ToString(dgWorkshop.CurrentRow.Cells("WPosted").Value).Equals("Y") Then

            DisableControls()
            DisableAllControls()
            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")

            Return
        Else
            'btnSaveOrUpdate.Enabled = False
            EnableControls()
        End If
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub tsmiViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiViewEdit.Click
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        tbcWorkshop.SelectedIndex = 0

        ResetFromCMS(dgWorkshop.CurrentRow.Cells("WorkshopCode").Value, CDate(dgWorkshop.CurrentRow.Cells("WDate").Value))

        If Convert.ToString(dgWorkshop.CurrentRow.Cells("WPosted").Value).Equals("Y") Then

            DisableControls()
            DisableAllControls()
            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")

            Return
        Else
            EnableControls()
        End If
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
       
    End Sub

    Private Sub tsmiViewDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiViewDelete.Click
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        cmsView.Visible = False
        If Convert.ToString(dgWorkshop.CurrentRow.Cells("WPosted").Value).Equals("Y") Then
            'MsgBox("This record was posted. Hence cannot be deleted.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")
            Return
        Else
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogFrm))
            If MsgBox(rm.GetString("DeleteMorePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("This operation might delete more than one record for the selected date and workshop code. Are you sure? If yes please click " & Chr(34) & "OK " & Chr(34) & " or click " & Chr(34) & "Cancel" & Chr(34) & "", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                _WorkshopLogPPT = New WorkshopLogPPT
                _WorkshopLogBOL = New WorkshopLogBOL
                '_WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
                '_WorkshopLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
                _WorkshopLogPPT.pdLogDateDT = DirectCast(dgWorkshop.CurrentRow.Cells("WDate").Value, Date)
                _WorkshopLogPPT.psWorkVHID = dgWorkshop.CurrentRow.Cells("WorkshopCode").Value

                Dim liMsg As Integer = _WorkshopLogBOL.DeleteWorkshopLogFromView(_WorkshopLogPPT)

                If liMsg = 3 Then
                    General.ShowMessageFromDataBase(14)
                Else
                    General.ShowMessageFromDataBase(liMsg)
                End If

                'General.ShowMessageFromDataBase(_WorkshopLogBOL.DeleteWorkshopLogFromView(_WorkshopLogPPT))

                BindWorkshopCode(String.Empty, String.Empty)
                dgWorkshop.ClearSelection()

            End If
        End If
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        If chkDate.Checked Then
            dtpSearchBydate.Enabled = True
        Else
            dtpSearchBydate.Enabled = False
            'General.SetVehicleDateTimePicker(dtpSearchBydate, "Vehicle", "WorkshopLog", "LogDate")
            Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSearchBydate)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If (Not chkDate.Checked) And txtWorkshopSearch.Text.Trim = String.Empty Then 'Show this message when Vehicle code textbox is empty and chkDate is not checked
            'MsgBox("Please enter search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("MsgSearch")
            txtWorkshopSearch.Focus()
            '  Return
        End If

        BindWorkshopCode(Me.txtWorkshopSearch.Text.Trim, "Go")

    End Sub

    'Private Sub dgWorkshop_CellValueNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgWorkshop.CellValueNeeded
    '    If e.RowIndex >= 0 AndAlso e.ColumnIndex = Me.SNo.Index Then
    '        e.Value = e.RowIndex + 1
    '    End If
    'End Sub

    Private Sub dgWorkshop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgWorkshop.KeyDown

        If dgWorkshop.CurrentRow IsNot Nothing And dgWorkshop.CurrentRow.Selected Then

            If dgWorkshop.CurrentRow.Index >= 0 And dgWorkshop.CurrentCell.ColumnIndex >= 0 Then
                If e.KeyCode = 13 Then
                    e.Handled = True

                    Me.btnSaveOrUpdate.Text = "Save"
                    Me.ResetRequiredMainControls()
                    Me.ResetRequiredControls()
                    Me.ResetControls()
                    'Me.dtpDate.Text = dtpDate.MinDate
                    General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "WorkshopLog", "LogDate")

                    'Me.cmbWorkshopCode.Text = dgWorkshop.CurrentRow.Cells("WorkshopCode").Value
                    Me.cmbWorkshopCode.SelectedIndex = cmbWorkshopCode.FindString(dgWorkshop.CurrentRow.Cells("WorkshopCode").Value)
                    Me.dtpDate.Text = dgWorkshop.CurrentRow.Cells("WDate").Value
                    Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                    Me.tbcWorkshop.SelectedIndex = 0

                End If
            End If

        End If

    End Sub

    Private Sub dgWorkshop_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWorkshop.MouseClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgWorkshop.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgWorkshop.CurrentRow IsNot Nothing And dgWorkshop.CurrentRow.Selected Then
            If dgWorkshop.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then
                Me.cmsView.Show(Me.dgWorkshop, e.Location)
            End If
        End If
    End Sub

    Private Sub dgWorkshop_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWorkshop.MouseDoubleClick

        If dgWorkshop.CurrentRow IsNot Nothing Then
            Me.btnSaveOrUpdate.Text = "Save"
            Me.ResetRequiredMainControls()
            Me.ResetRequiredControls()
            Me.ResetControls()
            'Me.dtpDate.Text = dtpDate.MinDate

            General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "WorkshopLog", "LogDate")

            'BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))
            'BindWorkshopLogDetailsByWorkshopCode(dgWorkshop.CurrentRow.Cells("WorkshopCode").Value, CDate("1/1/1753"))

            If dgWorkshop.CurrentRow.Index >= 0 And dgWorkshop.CurrentCell.ColumnIndex >= 0 And dgWorkshop.CurrentRow.Selected Then
                Me.tbcWorkshop.SelectedIndex = 0
                'Me.cmbWorkshopCode.SelectedText = dgWorkshop.CurrentRow.Cells("WorkshopCode").Value
                cmbWorkshopCode.SelectedIndex = cmbWorkshopCode.FindString(dgWorkshop.CurrentRow.Cells("WorkshopCode").Value)
                Me.dtpDate.Text = dgWorkshop.CurrentRow.Cells("WDate").Value
                Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.Text, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
            End If

            If Convert.ToString(dgWorkshop.CurrentRow.Cells("WPosted").Value).Equals("Y") Then

                DisableControls()
                DisableAllControls()
                'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
                DisplayInfoMessage("MsgPosted")
                'DisableControls()
                'If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If
                Return
            Else
                EnableControls()
            End If
            If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If
        End If
        
    End Sub

    Private Sub dgWorkshop_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgWorkshop.CellFormatting

        If e.ColumnIndex = dgWorkshop.Columns("WPosted").Index Then
            e.FormattingApplied = True
            Dim row As DataGridViewRow = dgWorkshop.Rows(e.RowIndex)
            Select Case (e.Value.ToString().Trim())
                Case "Y"
                    e.Value = "Yes"
                Case "N"
                    e.Value = "No"
            End Select

        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogFrm))
        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        'Dim ObjRecordExist As New Object
        'Dim ObjWorkshopLogPPT As New WorkshopLogPPT
        'Dim ObjWorkshopLogBOL As New WorkshopLogBOL
        'ObjRecordExist = ObjWorkshopLogBOL.WorkshopLogRecordIsExist(ObjWorkshopLogPPT)

        'If ObjRecordExist = 0 Then
        '    MsgBox("No Records Available!")
        'Else

        Dim childCR As New VehicleProofListReport
        childCR.strReportName = "WorkshopLogRpt"
        childCR.ShowDialog()

        'WorkshopLogRpt.ShowDialog()

        'End If
    End Sub


#End Region

#End Region

#Region "Functions"

    Private Sub CalculateTotalHrs()
        If lsStartTime <> String.Empty And lsEndTime <> String.Empty Then
            Dim h() As String = lsStartTime.Split(":")
            Dim ts As New TimeSpan(h(0), h(1), 0)

            Dim tsStart As New TimeSpan(h(0), h(1), 0)

            h = lsEndTime.Split(":")

            Dim tsEnd As New TimeSpan(h(0), h(1), 0)

            Dim lsTempTotTime = tsEnd.Subtract(tsStart).ToString()
            txtTotalHrs.Text = lsTempTotTime.Substring(0, lsTempTotTime.LastIndexOf(":"))

        End If
    End Sub

    'Private Sub ClearDisplayRefText()

    '    lblShowAccountCodeDesc.Text = String.Empty
    '    lblShowOldAccountCode.Text = String.Empty
    '    lblShowOperatorName.Text = String.Empty
    '    lblShowVehicleDesc.Text = String.Empty
    '    lblShowWorkshopDesc.Text = String.Empty

    'End Sub

    Private Sub ResetRequiredMainControls()
        Me.cmbWorkshopCode.Text = String.Empty
        'Me.dtpDate.Text = dtpDate.MinDate
        General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "WorkshopLog", "LogDate")
    End Sub

    Private Sub ResetRequiredControls()
        Me.txtVehicleCode.Text = String.Empty

        lsStartTime = String.Empty
        txtStartHr.Text = String.Empty
        txtStartMin.Text = String.Empty

        txtEndHr.Text = String.Empty
        txtEndMin.Text = String.Empty

        'cmbStartHrs.SelectedIndex = -1
        'cmbStartMin.SelectedIndex = -1

        lsEndTime = String.Empty

        'cmbEndHrs.SelectedIndex = -1
        'cmbEndMin.SelectedIndex = -1
        Me.txtTotalHrs.Text = String.Empty
        Me.txtActivity.Text = String.Empty
        Me.txtAccountCode.Text = String.Empty
        psWLAccountID = String.Empty
        Me.lblShowAccountCodeDesc.Text = String.Empty
        lblShowOldAccountCode.Text = String.Empty
        btnSaveOrUpdate.Enabled = True

        _lookupCode = String.Empty
        _lookupId = String.Empty
        _lookupDesc = String.Empty
        _lookupValue = String.Empty
        '_lookupOldCode = String.Empty
    End Sub

    Private Sub ResetControls()

        Me.txtOperatorCode.Text = String.Empty
        Me.lblShowOperatorName.Text = String.Empty
        psWLOperatorID = String.Empty

        Me.txtDIV.Text = String.Empty
        psWLDivID = String.Empty

        Me.txtYOP.Text = String.Empty
        psWLYopID = String.Empty

        Me.txtSubBlock.Text = String.Empty
        psWLBlockID = String.Empty

        Me.txtT0.Text = String.Empty
        psWLT0analysisID = String.Empty
        Me.txtT1.Text = String.Empty
        psWLT1analysisID = String.Empty
        Me.txtT2.Text = String.Empty
        psWLT2analysisID = String.Empty
        Me.txtT3.Text = String.Empty
        psWLT3analysisID = String.Empty
        Me.txtT4.Text = String.Empty
        psWLT4analysisID = String.Empty

        Me.lblT0Name.Text = String.Empty
        Me.lblT1Name.Text = String.Empty
        Me.lblT2Name.Text = String.Empty
        Me.lblT3Name.Text = String.Empty
        Me.lblT4Name.Text = String.Empty

        dtpDate.Enabled = True
        cmbWorkshopCode.Enabled = True
        Me.lblShowVehicleDesc.Text = String.Empty
        'ibtnSearchWorkshopLogNo.Enabled = True
    End Sub

    Private Sub DisableAllControls()
        Me.txtVehicleCode.Enabled = False
        txtStartHr.Enabled = False
        txtStartMin.Enabled = False
        txtEndHr.Enabled = False
        txtEndMin.Enabled = False
        'cmbStartHrs.Enabled = False
        'cmbStartMin.Enabled = False
        'cmbEndHrs.Enabled = False
        'cmbEndMin.Enabled = False
        Me.txtTotalHrs.Enabled = False
        Me.txtActivity.Enabled = False
        Me.txtAccountCode.Enabled = False
         Me.txtOperatorCode.Enabled = False
        Me.txtDIV.Enabled = False
        Me.txtYOP.Enabled = False
        Me.txtSubBlock.Enabled = False
        Me.txtT0.Enabled = False
        Me.txtT1.Enabled = False
        Me.txtT2.Enabled = False
        Me.txtT3.Enabled = False
        Me.txtT4.Enabled = False

        dtpDate.Enabled = False
        cmbWorkshopCode.Enabled = False

        'ibtnSearchWorkshopLogNo.Enabled = True
    End Sub

    Private Sub EnableAllControls()
        Me.txtVehicleCode.Enabled = True
        'cmbStartHrs.Enabled = True
        'cmbStartMin.Enabled = True
        'cmbEndHrs.Enabled = True
        'cmbEndMin.Enabled = True
        txtStartHr.Enabled = True
        txtStartMin.Enabled = True
        txtEndHr.Enabled = True
        txtEndMin.Enabled = True
        Me.txtTotalHrs.Enabled = True
        Me.txtActivity.Enabled = True
        Me.txtAccountCode.Enabled = True
        Me.txtOperatorCode.Enabled = True
        Me.txtDIV.Enabled = True
        Me.txtYOP.Enabled = True
        Me.txtSubBlock.Enabled = True
        Me.txtT0.Enabled = True
        Me.txtT1.Enabled = True
        Me.txtT2.Enabled = True
        Me.txtT3.Enabled = True
        Me.txtT4.Enabled = True

        dtpDate.Enabled = True
        cmbWorkshopCode.Enabled = True

        'ibtnSearchWorkshopLogNo.Enabled = True
    End Sub

    Private Sub ResetViewArea()

        Me.txtWorkshopSearch.Text = String.Empty
        Me.chkDate.Checked = False
        '     Me.dtpSearchBydate.Text = dtpSearchBydate.MinDate.ToString
        'General.SetVehicleDateTimePicker(dtpSearchBydate, "Vehicle", "WorkshopLog", "LogDate")
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSearchBydate)
        dtpSearchBydate.Enabled = False
        chkDate.Focus()
        'Me.txtWorkshopSearch.Text = String.Empty
        'Me.rbDate.Checked = False
        'Me.dtpSearchBydate.Text = dtpSearchBydate.MinDate.ToString
        'Me.rbWorkshopCode.Checked = True
    End Sub

    Private Sub BindWorkshopCodeInComboBox()
        _WorkshopLogPPT = New WorkshopLogPPT
        _WorkshopLogBOL = New WorkshopLogBOL
        '_WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
        Dim dtWorshopCode As DataTable = _WorkshopLogBOL.GetWorkshopCodeForComboBox(_WorkshopLogPPT)

        Dim dr As DataRow = dtWorshopCode.NewRow
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        dtWorshopCode.Rows.InsertAt(dr, 0)

        With cmbWorkshopCode
            .DataSource = dtWorshopCode
            .DisplayMember = "VHWSCode"
            .ValueMember = "VHDescp"
        End With

    End Sub

    Private Sub BindWorkshopCode(ByVal lsWorkshopCode As String, ByVal lsSender As String)

        If Me.tbcWorkshop.SelectedIndex = 1 Then
            _WorkshopLogPPT = New WorkshopLogPPT()
            _WorkshopLogBOL = New WorkshopLogBOL

            'dsWorkshopCode = New DataSet()

            'If rbWorkshopCode.Checked And txtWorkshopSearch.Text <> String.Empty Then
            '    _WorkshopLogPPT.psSearchBy = "Workshop No"
            '    _WorkshopLogPPT.psWorkVHID = lsWorkshopCode
            '    _WorkshopLogPPT.pdLogDateDT = CDate("1/1/1753")
            'ElseIf rbDate.Checked Then
            '    _WorkshopLogPPT.psSearchBy = "Date"
            '    _WorkshopLogPPT.psWorkVHID = Nothing
            '    _WorkshopLogPPT.pdLogDateDT = New Date(Me.dtpSearchBydate.Value.Year, Me.dtpSearchBydate.Value.Month, Me.dtpSearchBydate.Value.Day) 'Convert.ToDateTime(lsWorkshopCode)
            'Else
            '    _WorkshopLogPPT.psSearchBy = ""
            '    _WorkshopLogPPT.psWorkVHID = Nothing
            '    _WorkshopLogPPT.pdLogDateDT = CDate("1/1/1753")
            'End If

            If chkDate.Checked Then
                _WorkshopLogPPT.psSearchBy = "Date"
                _WorkshopLogPPT.pdLogDateDT = New Date(dtpSearchBydate.Value.Year, dtpSearchBydate.Value.Month, dtpSearchBydate.Value.Day) 'DateTime.Parse(txtVehicleCodeView.Text.Trim, culture, DateTimeStyles.NoCurrentDateDefault)
            Else

                _WorkshopLogPPT.pdLogDateDT = CDate("1/1/1753")
            End If

            _WorkshopLogPPT.psWorkVHID = IIf(lsWorkshopCode Is String.Empty, Nothing, lsWorkshopCode)
            '_WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
            '_WorkshopLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

            Dim dWorkshopLog As DataTable = _WorkshopLogBOL.GetWorkshopCode(_WorkshopLogPPT)
            With Me.dgWorkshop
                .AutoGenerateColumns = False
                .DataSource = dWorkshopLog
                '.DataSource = General.AutoNumberedTable(dsWorkshopCode.Tables(0))
                '.ClearSelection()
            End With

            If (dWorkshopLog Is Nothing Or dWorkshopLog.Rows.Count <= 0) And lsSender <> String.Empty Then

                If chkDate.Checked Then
                    ' MsgBox("Sorry, no data available for the selected date.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    'MsgBox("No record(s) found matching your search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("MsgNoRecords")
                ElseIf lsWorkshopCode <> String.Empty Then
                    'MsgBox("No record(s) found matching your search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("MsgNoRecords")
                    'MsgBox("Sorry, no such workshop code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    'ElseIf rbWorkshopCode.Checked And lsWorkshopCode = String.Empty Then
                    '    MsgBox("Sorry, no workshop code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                End If

                'If Then
                ' ''If rbDate.Checked Then
                ' ''    MsgBox("Sorry, no data available for the selected date.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                ' ''ElseIf rbWorkshopCode.Checked And lsWorkshopCode <> String.Empty Then
                ' ''    MsgBox("Sorry, no such workshop code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                ' ''ElseIf rbWorkshopCode.Checked And lsWorkshopCode = String.Empty Then
                ' ''    MsgBox("Sorry, no workshop code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                ' ''End If
                'MsgBox("No record found", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
                'End If
                'ResetViewArea()

                'Me.txtWorkshopSearch.Text = String.Empty

            End If
        End If

    End Sub

    Public Sub BindWorkshopLogDetailsByWorkshopCode(ByVal lsWorkshopCode As String, ByVal ldLogDateDT As DateTime)
        _WorkshopLogPPT = New WorkshopLogPPT()
        _WorkshopLogBOL = New WorkshopLogBOL

        _WorkshopLogPPT.psWorkVHID = IIf(String.IsNullOrEmpty(lsWorkshopCode), Nothing, lsWorkshopCode)
        '_WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
        '_WorkshopLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
        _WorkshopLogPPT.pdLogDateDT = ldLogDateDT

        Dim dsWorkshopLog As DataSet = _WorkshopLogBOL.GetWorkshopLog(_WorkshopLogPPT)
        With dgWorkshopRunningLog
            .AutoGenerateColumns = False
            .DataSource = dsWorkshopLog.Tables(0)
            .ClearSelection()
        End With

        dgWorkshopRunningLog.Columns("StartTime").DefaultCellStyle.Format = "hh:mm t"
        dgWorkshopRunningLog.Columns("EndTime").DefaultCellStyle.Format = "hh:mm t"

    End Sub

    Function CheckRequiredFields() As Boolean
        lsErrorMessage = String.Empty
        _Validator = New Validator

        If ((cmbWorkshopCode.SelectedIndex = 0) Or (Not _Validator.RequiredFieldValidator(txtVehicleCode.Text.Trim)) Or (Not _Validator.RequiredFieldValidator(txtTotalHrs.Text.Trim)) Or (Not _Validator.RequiredFieldValidator(txtActivity.Text.Trim)) Or (Not _Validator.RequiredFieldValidator(txtT0.Text.Trim)) Or (Not _Validator.RequiredFieldValidator(txtAccountCode.Text.Trim))) Then ' _



            Select Case String.Empty
                'Case cmbWorkshopCode.SelectedIndex = 0
                '    cmbWorkshopCode.Focus()
                '    MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblWorkshopLogNo.Text)
                Case txtVehicleCode.Text
                    txtVehicleCode.Focus()
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblVehicleCode.Text)
                    DisplayInfoMessage("RField")
                    Return False
                    'Case txtTotalHrs.Text
                    '    txtTotalHrs.Focus()
                    '    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblVehicleCode.Text)
                    '    DisplayInfoMessage("RField")
                    '    Return False
                Case txtT0.Text
                    txtT0.Focus()
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblVehicleCode.Text)
                    DisplayInfoMessage("RField")
                    Return False
            End Select

            If cmbWorkshopCode.SelectedIndex = 0 Then
                cmbWorkshopCode.Focus()
                'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblWorkshopLogNo.Text)
                DisplayInfoMessage("RField")
                Return False
            End If

            Select Case String.Empty
                Case lsStartTime
                    ''txtStartTime.Focus()
                    'cmbStartHrs.Focus()
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblStartTime.Text)
                Case lsEndTime
                    If txtStartHr.Text.Trim = String.Empty Then
                        If txtStartHr.Text.Trim = String.Empty Then
                            DisplayInfoMessage("RField")
                            txtStartHr.Focus()
                            Return False
                        End If

                        If txtStartMin.Text.Trim = String.Empty Then
                            DisplayInfoMessage("RField")
                            txtStartMin.Focus()
                            Return False
                        End If
                    End If


                    If txtStartMin.Text.Trim = String.Empty Then
                        DisplayInfoMessage("RField")
                        txtEndMin.Focus()
                        Return False
                    End If

                    'If cmbStartHrs.SelectedIndex = -1 Then
                    '    'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                    '    If cmbStartHrs.SelectedIndex = -1 Then
                    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '        DisplayInfoMessage("RField")
                    '        'txtStartTime.Focus()
                    '        cmbStartHrs.Focus()
                    '        Return False
                    '    End If

                    '    If cmbStartMin.SelectedIndex = -1 Then
                    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '        DisplayInfoMessage("RField")
                    '        'txtStartTime.Focus()
                    '        cmbStartMin.Focus()
                    '        Return False
                    '    End If

                    '    'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '    ''txtStartTime.Focus()
                    '    'cmbEndHrs.Focus()
                    '    'Return False
                    'End If

                    'If cmbStartMin.SelectedIndex = -1 Then
                    '    'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                    '    'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '    DisplayInfoMessage("RField")
                    '    'txtStartTime.Focus()
                    '    cmbEndMin.Focus()
                    '    Return False
                    'End If

                    ''txtEndTime.Focus()
                    'cmbEndHrs.Focus()
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblEndTime.Text)
                Case txtActivity.Text
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblActivity.Text)
                    DisplayInfoMessage("RField")

                    txtActivity.Focus()
                    Return False
                Case txtAccountCode.Text
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblAccountCode.Text)
                    DisplayInfoMessage("RField")

                    txtAccountCode.Focus()
                    Return False
            End Select

            If txtStartMin.Text.Trim <> String.Empty And txtStartHr.Text.Trim = String.Empty Then
                DisplayInfoMessage("RStartMts")
                txtStartHr.Focus()
                Return False
            End If

            If txtStartMin.Text.Trim = String.Empty And txtStartHr.Text.Trim <> String.Empty Then
                DisplayInfoMessage("RStartHrs")
                txtStartMin.Focus()
                Return False
            End If

            If txtEndMin.Text.Trim <> String.Empty And txtEndHr.Text.Trim = String.Empty Then
                DisplayInfoMessage("RStartHrs")
                txtEndHr.Focus()
                Return False
            End If

            If txtEndMin.Text.Trim = String.Empty And txtEndHr.Text.Trim <> String.Empty Then
                DisplayInfoMessage("REndMts")
                txtEndMin.Focus()
                Return False
            End If

            'If cmbStartMin.SelectedIndex > -1 And cmbStartHrs.SelectedIndex = -1 Then
            '    'MessageBox.Show("This field is required when Start Minutes selected.", cmbStartMin.Text, MessageBoxButtons.OK)
            '    DisplayInfoMessage("RStartMts")
            '    cmbStartHrs.Focus()
            '    Return False
            'End If

            'If cmbStartHrs.SelectedIndex > -1 And cmbStartMin.SelectedIndex = -1 Then
            '    'MessageBox.Show("This field is required when Starting Hrs selected.", cmbStartHrs.Text, MessageBoxButtons.OK)
            '    DisplayInfoMessage("RStartHrs")
            '    cmbStartMin.Focus()
            '    Return False
            'End If

            'If cmbEndMin.SelectedIndex > -1 And cmbEndHrs.SelectedIndex = -1 Then
            '    'MessageBox.Show("This field is required when End Minutes selected.", cmbEndMin.Text, MessageBoxButtons.OK)
            '    DisplayInfoMessage("REndMts")
            '    cmbEndHrs.Focus()
            '    Return False
            'End If

            'If cmbEndHrs.SelectedIndex > -1 And cmbEndMin.SelectedIndex = -1 Then
            '    'MessageBox.Show("This field is required when End Hrs selected.", cmbEndHrs.Text, MessageBoxButtons.OK)
            '    DisplayInfoMessage("REndHrs")
            '    cmbEndMin.Focus()
            '    Return False
            'End If

            If txtStartMin.Text.Trim <> String.Empty Then
                If txtStartHr.Text.Trim = String.Empty Then
                    DisplayInfoMessage("RStartTime")
                    txtEndHr.Focus()
                    Return False
                End If

                If txtStartMin.Text.Trim = String.Empty Then
                    DisplayInfoMessage("RStartTime")
                    txtEndMin.Focus()
                    Return False
                End If
            End If

            'If cmbStartMin.SelectedIndex > -1 Then
            '    If cmbStartHrs.SelectedIndex = -1 Then
            '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

            '        'MessageBox.Show("This field is required when End time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
            '        DisplayInfoMessage("RStartTime")
            '        'txtStartTime.Focus()
            '        cmbEndHrs.Focus()
            '        Return False
            '    End If

            '    If cmbStartMin.SelectedIndex = -1 Then
            '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

            '        'MessageBox.Show("This field is required when End time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
            '        DisplayInfoMessage("RStartTime")
            '        'txtStartTime.Focus()
            '        cmbEndMin.Focus()
            '        Return False
            '    End If
            'End If



            If txtStartMin.Text.Trim <> String.Empty Then
                If txtStartHr.Text.Trim = String.Empty Then
                    DisplayInfoMessage("REndTime")
                    txtStartHr.Focus()
                    Return False
                End If

                If txtStartMin.Text.Trim = String.Empty Then
                    DisplayInfoMessage("REndTime")
                    txtStartMin.Focus()
                    Return False
                End If
            End If

            Select Case String.Empty
                        Case txtTotalHrs.Text
                    txtTotalHrs.Focus()
                    'MsgBox("This field is required", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblVehicleCode.Text)
                    DisplayInfoMessage("RField")
                    Return False
                      End Select

            'If cmbStartMin.SelectedIndex > -1 Then
            '    If cmbStartHrs.SelectedIndex = -1 Then
            '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

            '        'MessageBox.Show("This field is required when Start time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
            '        DisplayInfoMessage("REndTime")
            '        'txtStartTime.Focus()
            '        cmbStartHrs.Focus()
            '        Return False
            '    End If

            '    If cmbStartMin.SelectedIndex = -1 Then
            '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

            '        'MessageBox.Show("This field is required when Start time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
            '        DisplayInfoMessage("REndTime")
            '        'txtStartTime.Focus()
            '        cmbStartMin.Focus()
            '        Return False
            '    End If
            'End If

            Return True

        Else

            Return True

        End If

    End Function

    Function CheckRequiredFieldsOfWorkshopSearch() As Boolean
        lsErrorMessage = String.Empty
        'Dim lreValidateDate As New System.Text.RegularExpressions.Regex("^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$")
        _Validator = New Validator

        If Not _Validator.RequiredFieldValidator(Me.txtWorkshopSearch.Text.Trim) And chkDate.Checked Then
            lsErrorMessage += _Validator.Required(Me.txtWorkshopSearch.Text.Trim, "TextBox", "Workshop code field is required. Please input workshop code. " & vbCrLf & "")
            MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            Return False
            'ElseIf _Validator.RequiredFieldValidator(Me.txtWorkshopSearch.Text.Trim) And rbDate.Checked And (Not lreValidateDate.IsMatch(txtWorkshopSearch.Text.Trim)) Then
            '    MsgBox("Please Give Valid Date in the format of DD/MM/YYYY")
            '    Return False
        Else
            Return True
        End If
    End Function

    Function GetKeyResult(ByVal lsFieldName As String, ByVal lsFieldValue As String) As Integer
        _WorkshopLogPPT = New WorkshopLogPPT
        _WorkshopLogBOL = New WorkshopLogBOL

        '_WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
        _WorkshopLogPPT.psFieldName = lsFieldName
        _WorkshopLogPPT.psFieldValue = lsFieldValue

        Return _WorkshopLogBOL.GetIsValidKey(_WorkshopLogPPT)
    End Function

    Private Sub DeleteWorkshopLog()
        cmsAddEditDelete.Visible = False
        If Convert.ToString(dgWorkshopRunningLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then
            'MsgBox("This record was posted. Hence cannot be deleted.", MsgBoxStyle.OkOnly, "Information")
            DisableAllControls()
            DisableControls()

            DisplayInfoMessage("MsgPosted")

            Return
        Else
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogFrm))
            If MsgBox(rm.GetString("DeletePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to delete the selected record. Are you sure? If yes please click " & Chr(34) & "OK " & Chr(34) & " or click " & Chr(34) & "Cancel" & Chr(34) & "", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                _WorkshopLogPPT = New WorkshopLogPPT
                _WorkshopLogBOL = New WorkshopLogBOL
                _WorkshopLogPPT.piId = DirectCast(dgWorkshopRunningLog.CurrentRow.Cells("Id").Value, Integer)

                General.ShowMessageFromDataBase(_WorkshopLogBOL.DeleteWorkshopLog(_WorkshopLogPPT))

                BindWorkshopLogDetailsByWorkshopCode(dgWorkshopRunningLog.CurrentRow.Cells("Workshop").Value, dgWorkshopRunningLog.CurrentRow.Cells("LogDate").Value)
                dgWorkshopRunningLog.ClearSelection()
                ResetControls()
                ResetRequiredControls()
                'btnSaveOrUpdate.Text = "Save"
                If GlobalPPT.strLang = "en" Then
                    btnSaveOrUpdate.Text = "Save"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveOrUpdate.Text = "Simpan"
                End If
            End If
        End If

        'cmsDelete.Visible = False
    End Sub

    Public Sub ShowWorkshopDetailsByID(ByVal lsId As Integer)
        _WorkshopLogPPT = New WorkshopLogPPT()
        _WorkshopLogBOL = New WorkshopLogBOL
        _WorkshopLogPPT.piId = lsId

        Dim dsWorkShopLog As DataSet = _WorkshopLogBOL.GetWorkshopLogDetails(_WorkshopLogPPT)

        'Me.cmbWorkshopCode.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("WorkshopCode") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("WorkshopCode")) ' .Tables(0).Rows(0)(0).ToString

        cmbWorkshopCode.SelectedIndex = cmbWorkshopCode.FindString(IIf(dsWorkShopLog.Tables(0).Rows(0)("WorkshopCode") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("WorkshopCode")))

        Me.lblShowWorkshopDesc.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("WorkshopDescp") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("WorkshopDescp"))
        Me.txtVehicleCode.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("VehicleCode") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("VehicleCode"))
        Me.lblShowVehicleDesc.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("VehicleDescp") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("VehicleDescp"))
        Me.dtpDate.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("LogDate") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("LogDate").ToString)
        'Me.txtStartTime.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("StartTime") Is DBNull.Value, String.Empty, New DateTime(dsWorkShopLog.Tables(0).Rows(0)("StartTime").Ticks).ToString("hh:mmtt"))
        'Me.txtEndTime.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("EndTime") Is DBNull.Value, String.Empty, New DateTime(dsWorkShopLog.Tables(0).Rows(0)("EndTime").Ticks).ToString("hh:mmtt"))
       
        Dim lsStartTempTime As String = dsWorkShopLog.Tables(0).Rows(0)("StartTime").ToString()
        'Dim lsStartTempTime As String = New DateTime(dsWorkShopLog.Tables(0).Rows(0)("StartTime").Ticks).ToString("HH:mm")
        Dim splitStartTime() As String = lsStartTempTime.Split(":")
        txtStartHr.Text = splitStartTime(0)
        txtStartMin.Text = splitStartTime(1)

        'cmbStartHrs.SelectedIndex = Convert.ToInt32(splitStartTime(0))

        'If splitStartTime(1).StartsWith(0) Then
        '    cmbStartMin.SelectedIndex = cmbStartMin.FindString(splitStartTime(1))
        'Else
        '    cmbStartMin.SelectedIndex = cmbStartMin.FindString(Convert.ToInt32(splitStartTime(1)))
        'End If

        'cmbStartMin.SelectedIndex = cmbStartMin.FindString(Convert.ToInt32(splitStartTime(1)))
        Dim lsEndTempTime As String = dsWorkShopLog.Tables(0).Rows(0)("EndTime").ToString()
        Dim splitEndTime() As String = lsEndTempTime.Split(":")
        txtEndHr.Text = splitEndTime(0)
        txtEndMin.Text = splitEndTime(1)

        'Dim lsEndTempTime As String = New DateTime(dsWorkShopLog.Tables(0).Rows(0)("EndTime").Ticks).ToString("HH:mm")
        'Dim splitEndTime() As String = lsEndTempTime.Split(":")

        'cmbEndHrs.SelectedIndex = Convert.ToInt32(splitEndTime(0))
        'If splitEndTime(1).StartsWith(0) Then
        '    cmbEndMin.SelectedIndex = cmbEndMin.FindString(splitEndTime(1))
        'Else
        '    cmbEndMin.SelectedIndex = cmbEndMin.FindString(Convert.ToInt32(splitEndTime(1)))
        'End If
        ' cmbEndMin.SelectedIndex = cmbEndMin.FindString(Convert.ToInt32(splitEndTime(1)))
        lsStartTime = dsWorkShopLog.Tables(0).Rows(0)("StartTime").ToString()
        lsEndTime = dsWorkShopLog.Tables(0).Rows(0)("EndTime").ToString()

        'lsStartTime = New DateTime(dsWorkShopLog.Tables(0).Rows(0)("StartTime").Ticks).ToString("HH:mm")
        'lsEndTime = New DateTime(dsWorkShopLog.Tables(0).Rows(0)("EndTime").Ticks).ToString("HH:mm")

        'Me.txtStartTime.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("StartTime") Is DBNull.Value, String.Empty, New DateTime(dsWorkShopLog.Tables(0).Rows(0)("StartTime").Ticks).ToString("hh:mmtt"))
        'Me.txtEndTime.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("EndTime") Is DBNull.Value, String.Empty, New DateTime(dsWorkShopLog.Tables(0).Rows(0)("EndTime").Ticks).ToString("hh:mmtt"))

        If lsStartTempTime = "00:00:00" And lsEndTempTime = "00:00:00" Then


            txtStartHr.Text = String.Empty
            txtStartMin.Text = String.Empty
            txtEndHr.Text = String.Empty
            txtEndMin.Text = String.Empty

            'cmbStartHrs.Enabled = False
            'cmbStartMin.Enabled = False
            'cmbEndHrs.Enabled = False
            'cmbEndMin.Enabled = False
            'cmbStartHrs.SelectedIndex = -1
            'cmbStartMin.SelectedIndex = -1
            'cmbEndHrs.SelectedIndex = -1
            'cmbEndMin.SelectedIndex = -1
            lsStartTime = String.Empty
            lsEndTime = String.Empty
        End If

        Me.txtTotalHrs.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TotalHrs") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TotalHrs"))
        Me.txtActivity.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("Activity") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("Activity"))
        Me.txtAccountCode.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("COACode") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("COACode"))
        psWLAccountID = IIf(dsWorkShopLog.Tables(0).Rows(0)("COAID") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("COAID"))
        Me.lblShowAccountCodeDesc.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("AccountDesc") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("AccountDesc"))
        Me.lblShowOldAccountCode.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("OldCOACode") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("OldCOACode"))
        Me.txtOperatorCode.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("EmpCode") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("EmpCode"))
        psWLOperatorID = IIf(dsWorkShopLog.Tables(0).Rows(0)("EmpID") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("EmpID"))
        Me.lblShowOperatorName.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("OperatorDesc") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("OperatorDesc"))

        Me.txtDIV.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("Div") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("Div"))
        psWLDivID = IIf(dsWorkShopLog.Tables(0).Rows(0)("DivID") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("DivID"))
        Me.txtYOP.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("YOP") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("YOP"))
        psWLYopID = IIf(dsWorkShopLog.Tables(0).Rows(0)("YOPID") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("YOPID"))
        Me.txtSubBlock.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("BlockName") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("BlockName"))
        psWLBlockID = IIf(dsWorkShopLog.Tables(0).Rows(0)("BlockID") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("BlockID"))

        Me.txtT0.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TValue0") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TValue0"))
        Me.txtT1.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TValue1") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TValue1"))
        Me.txtT2.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TValue2") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TValue2"))
        Me.txtT3.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TValue3") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TValue3"))
        Me.txtT4.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TValue4") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TValue4"))
        psWLT0analysisID = IIf(dsWorkShopLog.Tables(0).Rows(0)("T0") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("T0"))
        psWLT1analysisID = IIf(dsWorkShopLog.Tables(0).Rows(0)("T1") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("T1"))
        psWLT2analysisID = IIf(dsWorkShopLog.Tables(0).Rows(0)("T2") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("T2"))
        psWLT3analysisID = IIf(dsWorkShopLog.Tables(0).Rows(0)("T3") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("T3"))
        psWLT4analysisID = IIf(dsWorkShopLog.Tables(0).Rows(0)("T4") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("T4"))
        Me.lblT0Name.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TDescp0") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TDescp0"))
        Me.lblT1Name.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TDescp1") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TDescp1"))
        Me.lblT2Name.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TDescp2") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TDescp2"))
        Me.lblT3Name.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TDescp3") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TDescp3"))
        Me.lblT4Name.Text = IIf(dsWorkShopLog.Tables(0).Rows(0)("TDescp4") Is DBNull.Value, String.Empty, dsWorkShopLog.Tables(0).Rows(0)("TDescp4"))

        dtpDate.Enabled = False
        cmbWorkshopCode.Enabled = False
        'ibtnSearchWorkshopLogNo.Enabled = False
    End Sub

    Private Sub ClearSubBlock()
        txtSubBlock.Text = String.Empty
        psWLBlockID = String.Empty
        'lblSubBlockName.Text = String.Empty
        Me.txtDIV.Text = String.Empty
        psWLDivID = String.Empty
        'Me.lblDivName.Text = String.Empty
        Me.txtYOP.Text = String.Empty
        'Me.lblYOPName.Text = String.Empty
        psWLYopID = String.Empty
        ''
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tab
            tbcWorkshop.TabPages("tbpgAdd").Text = rm.GetString("tbVehicleRunningLog.TabPages(tbpgAdd).Text")
            tbcWorkshop.TabPages("tpViewVRL").Text = rm.GetString("tbVehicleRunningLog.TabPages(tpViewVRL).Text")

            'Button
            btnReset.Text = rm.GetString("btnReset.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSaveOrUpdate.Text = rm.GetString("btnSaveOrUpdate.Text")
            btnPrint.Text = rm.GetString("btnPrint.Text")
            'label
            lblDate.Text = rm.GetString("lblDate.Text")
            lblVehicleCode.Text = rm.GetString("lblVehicleCode.Text")
            lblWorkshopLogNo.Text = rm.GetString("dgWorkshop.Columns(WorkshopCode).HeaderText")
            lblStartTime.Text = rm.GetString("lblStartTime.Text")
            lblEndTime.Text = rm.GetString("lblEndTime.Text")

            lblTotalHrs.Text = rm.GetString("lblTotalHrs.Text")
            lblActivity.Text = rm.GetString("lblActivity.Text")
            lblShowOperatorName.Text = rm.GetString("lblOperatorName.Text")
            lblOperatorCode.Text = rm.GetString("lblOperatorCode.Text")
            lblShowAccountCodeDesc.Text = rm.GetString("lblAccountCodeDesc.Text")
            lblShowOldAccountCode.Text = rm.GetString("lblOldAccountCode.Text")
            'lblShowOldAccountCode.Text = rm.GetString("lblOldAccountCode.Text")
            lblAccountCode.Text = rm.GetString("lblAccountCode.Text")
            lblTAnalysisT0.Text = rm.GetString("lblTAnalysisT0.Text")
            lblDIV.Text = rm.GetString("lblDIV.Text")
            lblTAnalysisT1.Text = rm.GetString("lblTAnalysisT1.Text")
            lblYOP.Text = rm.GetString("lblYOP.Text")
            lblTAnalysisT2.Text = rm.GetString("lblTAnalysisT2.Text")
            lblBlock.Text = rm.GetString("lblBlock.Text")
            lblTAnalysisT3.Text = rm.GetString("lblTAnalysisT3.Text")
            lblTAnalysisT4.Text = rm.GetString("lblTAnalysisT4.Text")
            gbListOfWorkshopLog.Text = rm.GetString("gbListOfWorkshopLog.Text")

            'GridView
            dgWorkshopRunningLog.Columns("LogDate").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(LogDate).HeaderText")
            dgWorkshopRunningLog.Columns("Workshop").HeaderText = rm.GetString("dgWorkshop.Columns(WorkshopCode).HeaderText")
            dgWorkshopRunningLog.Columns("Vehicle").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(Vehicle).HeaderText")
            dgWorkshopRunningLog.Columns("StartTime").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(StartTime).HeaderText")
            dgWorkshopRunningLog.Columns("EndTime").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(EndTime).HeaderText")
            dgWorkshopRunningLog.Columns("TotalHrs").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(TotalHrs).HeaderText")
            dgWorkshopRunningLog.Columns("Activity").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(Activity).HeaderText")
            dgWorkshopRunningLog.Columns("AccountCode").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(AccountCode).HeaderText")
            dgWorkshopRunningLog.Columns("AccountCodeDescp").HeaderText = rm.GetString("dgWorkshopRunningLog.Columns(AccountCodeDescp).HeaderText")
            'dgWorkshopRunningLog.Rows(0).Cells.Item("Approvel").Value= ""
            '  For Each DataGridViewRow In dgvPostingNonPostedVehicleDistribution.Rows
            'DataGridViewRow.Cells("Approvel").Value.ToString()
            'Next
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value = rm.GetString("dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item(Approvel).Value")

            PnlSearch.CaptionText = rm.GetString("pnlSearch")
            lblSearchby.Text = rm.GetString("lblSearchby.Text")
            chkDate.Text = rm.GetString("chkDate.Text")
            lblViewVehicleCode.Text = rm.GetString("dgWorkshop.Columns(WorkshopCode).HeaderText")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            'dgWorkshop.Columns("SNo").HeaderText = rm.GetString("dgWorkshop.Columns(SNo).HeaderText")
            dgWorkshop.Columns("WDate").HeaderText = rm.GetString("dgWorkshop.Columns(WDate).HeaderText")
            dgWorkshop.Columns("WorkshopCode").HeaderText = rm.GetString("dgWorkshop.Columns(WorkshopCode).HeaderText")
            dgWorkshop.Columns("WPosted").HeaderText = rm.GetString("txtPosted")
            btnViewReport.Text = rm.GetString("Report")

            cmsAddEditDelete.Items.Item(0).Text = rm.GetString("cmsAddEditDelete.Items.Item(0).Text")
            cmsAddEditDelete.Items.Item(1).Text = rm.GetString("cmsAddEditDelete.Items.Item(1).Text")
            cmsAddEditDelete.Items.Item(2).Text = rm.GetString("cmsAddEditDelete.Items.Item(2).Text")
            cmsView.Items.Item(0).Text = rm.GetString("cmsAddEditDelete.Items.Item(0).Text")
            cmsView.Items.Item(1).Text = rm.GetString("cmsAddEditDelete.Items.Item(1).Text")
            cmsView.Items.Item(2).Text = rm.GetString("cmsAddEditDelete.Items.Item(2).Text")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsVehicleCodeAlreadyExists() As Boolean

        If btnSaveOrUpdate.Text <> "Update" Then
            Dim dtVehicleCode As DataTable = dgWorkshopRunningLog.DataSource

            Try
                Dim dr() As DataRow = dtVehicleCode.Select("VHID = '" + txtVehicleCode.Text.Trim + "' AND LogDate = '#" + dtpDate.Value + "# '")

                If dr.Length > 0 Then
                    'MsgBox("Record already exists.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
                    DisplayInfoMessage("Msg10")
                    Return True
                End If

            Catch ex As Exception

            End Try

            Return False
        Else
            Return False
        End If

    End Function

    Private Sub EnableControls()
        btnSaveOrUpdate.Enabled = True
        dtpDate.Enabled = True
        cmbWorkshopCode.Enabled = True
        'ibtnSearchWorkshopLogNo.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub DisableControls()
        btnSaveOrUpdate.Enabled = False
        dtpDate.Enabled = False
        cmbWorkshopCode.Enabled = False
        'ibtnSearchWorkshopLogNo.Enabled = False
        'If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub Reset()
        Me.cmbWorkshopCode.Text = String.Empty

        If GlobalPPT.strLang = "en" Then
            btnSaveOrUpdate.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveOrUpdate.Text = "Simpan"
        End If
        ''Me.btnSaveOrUpdate.Text = "Save"
        ResetControls()
        'Me.ResetRequiredMainControls()
        Me.cmbWorkshopCode.Text = String.Empty
        ResetRequiredControls()

        lblT0Name.Text = String.Empty
        lblT1Name.Text = String.Empty
        lblT2Name.Text = String.Empty
        lblT3Name.Text = String.Empty
        lblT4Name.Text = String.Empty

        'Me.dtpDate.Text = dtpDate.MinDate
        'General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "WorkshopLog", "LogDate")
        If cmbWorkshopCode.SelectedIndex = 0 Then
            BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))
        Else
            Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.Text, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
        End If

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub ResetFromCMS(ByVal lsWorkshopCode As String, ByVal ldDate As Date)
        Me.cmbWorkshopCode.Text = String.Empty
        Me.btnSaveOrUpdate.Text = "Save"
        ResetControls()
        Me.ResetRequiredMainControls()
        ResetRequiredControls()
        'Me.dtpDate.Text = dtpDate.MinDate
        'cmbWorkshopCode.SelectedValue = lsWorkshopCode

        cmbWorkshopCode.SelectedIndex = cmbWorkshopCode.FindString(lsWorkshopCode)

        General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "WorkshopLog", "LogDate")
        BindWorkshopLogDetailsByWorkshopCode(lsWorkshopCode, ldDate)
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

#End Region

#Region "Validation"
    Public Shared Function IsVHWSCodeExist(ByVal lsFieldValue As String) As Integer

        Dim _WorkshopLogPPT As WorkshopLogPPT = New WorkshopLogPPT
        Dim _WorkshopLogBOL As WorkshopLogBOL = New WorkshopLogBOL
        _WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
        ' _WorkshopLogPPT.psFieldName = lsFileldName
        _WorkshopLogPPT.psFieldValue = lsFieldValue
        Return _WorkshopLogBOL.IsVHWSCodeExist(_WorkshopLogPPT)

    End Function


    Private Sub txtVehicleCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave


        If txtVehicleCode.Text.Trim <> String.Empty Then
            Select Case WorkShopLogFrm.IsVHWSCodeExist(txtVehicleCode.Text.Trim)
                Case 0
                    txtVehicleCode.Focus()
                    'MsgBox("Sorry, no such vehicle code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IVehicle")
                    lblShowVehicleDesc.Text = String.Empty
                    txtVehicleCode.Text = String.Empty
                    'psWLVHID = String.Empty
                    Return
                Case 1
                    txtVehicleCode.Focus()
                    'MsgBox("Sorry, this vehicle code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IVehicleEstate")
                    lblShowVehicleDesc.Text = String.Empty
                    txtVehicleCode.Text = String.Empty
                    'psWLVHID = String.Empty
                    Return
                Case Else
                    'The same vehicle code should not come for the same date
                    ' IsVehicleCodeAlreadyExists()
            End Select
        Else
            lblShowVehicleDesc.Text = String.Empty
            'psWLVHID = String.Empty
        End If

        If txtVehicleCode.Text.Trim <> String.Empty Then
            _WorkshopLogPPT = New WorkshopLogPPT
            _WorkshopLogBOL = New WorkshopLogBOL

            ' _WorkshopLogPPT.psWorkVHID = Me.cmbWorkshopCode.Text
            ' _WorkshopLogPPT.pdLogDateDT = New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day)
            _WorkshopLogPPT.psVHID = Me.txtVehicleCode.Text.Trim()
            Dim dt As New DataTable
            dt = _WorkshopLogBOL.GetVHCode(_WorkshopLogPPT)
            If dt.Rows.Count > 0 Then
                lblShowVehicleDesc.Text = dt.Rows(0).Item("VHDescp").ToString()
            Else
                lblShowVehicleDesc.Text = String.Empty
            End If

        End If

    End Sub

    Private Sub cmbWorkshopCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.cmbWorkshopCode.Text <> String.Empty Then

            Select Case General.IsVHWSCodeExist("W", cmbWorkshopCode.Text.Trim)
                Case 0
                    cmbWorkshopCode.Focus()
                    'MsgBox("Sorry, no such workshop code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IWorkshop")
                    Return
                Case 1
                    cmbWorkshopCode.Focus()
                    'MsgBox("Sorry, this workshop code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IWorkshopEstate")
                    Return
            End Select

            'Me.btnSaveOrUpdate.Text = "Save"
            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Save"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Simpan"
            End If
            Me.ResetControls()

            Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))

        Else
            Me.ResetControls()
            BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))
        End If

    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave

        If txtAccountCode.Text.Trim() <> String.Empty Then

            If txtAccountCode.Text.Trim.ToString.Length <> 13 Then
                DisplayInfoMessage("Msg03")
                'MessageBox.Show("Please enter 13 digit Account code")
                txtAccountCode.Focus()
                Exit Sub
            End If

            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.COACode = txtAccountCode.Text.Trim()
            ds = StoreIssueVoucherBOL.AcctlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'MessageBox.Show("Invalid Account code,Please Choose it from look up")
                'MsgBox("Sorry, no such account code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblAccountCode.Text)
                DisplayInfoMessage("IAccountCode")
                txtAccountCode.Text = String.Empty
                lblShowAccountCodeDesc.Text = String.Empty
                lblShowOldAccountCode.Text = String.Empty
                psWLAccountID = String.Empty
                GlobalPPT.psAcctExpenditureType = String.Empty
                txtAccountCode.Focus()
                'ClearSubBlock()
                Exit Sub
            Else
                psWLAccountID = ds.Tables(0).Rows(0).Item("COAID").ToString()
                'If Not ds.Tables(0).Rows(0).Item("COACode").ToString() Is DBNull.Value Then
                txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                'End If
                If Not ds.Tables(0).Rows(0).Item("COADescp").ToString() Is DBNull.Value Then
                    lblShowAccountCodeDesc.Text = ds.Tables(0).Rows(0).Item("COADescp")
                End If

                lblShowOldAccountCode.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("OldCOACode")), String.Empty, ds.Tables(0).Rows(0).Item("OldCOACode"))

                'If Not ds.Tables(0).Rows(0).Item("COAID").ToString() Is DBNull.Value Then
                '    psSIVAccountID = ds.Tables(0).Rows(0).Item("COAID")
                'End If

                If Not ds.Tables(0).Rows(0).Item("ExpenditureAG") Is DBNull.Value Then
                    GlobalPPT.psAcctExpenditureType = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                    lsVDExpenditureAG = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                Else
                    GlobalPPT.psAcctExpenditureType = String.Empty
                    lsVDExpenditureAG = String.Empty
                End If

                If Not ds.Tables(0).Rows(0).Item("OldCOACode") Is DBNull.Value Then
                    lblShowOldAccountCode.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                Else
                    lblShowOldAccountCode.Text = String.Empty
                End If

                ' ClearSubBlock()
            End If
        Else
            txtAccountCode.Text = String.Empty
            lblShowAccountCodeDesc.Text = String.Empty
            lblShowOldAccountCode.Text = String.Empty
            psWLAccountID = String.Empty
            GlobalPPT.psAcctExpenditureType = String.Empty
            'ClearSubBlock()
        End If


        'If txtAccountCode.Text.Trim <> String.Empty Then
        '    Select Case General.ValidateForeignKeyFields("Account", txtAccountCode.Text.Trim)
        '        Case 0
        '            txtAccountCode.Focus()
        '            lblShowAccountCodeDesc.Text = String.Empty
        '            MsgBox("Sorry, no such account code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            Return
        '        Case 1
        '            txtAccountCode.Focus()
        '            lblShowAccountCodeDesc.Text = String.Empty
        '            MsgBox("Sorry, this account code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            Return
        '    End Select
        'End If

        'If txtAccountCode.Text.Trim <> String.Empty Then
        '    _WorkshopLogPPT = New WorkshopLogPPT
        '    _WorkshopLogBOL = New WorkshopLogBOL

        '    _WorkshopLogPPT.psCOAID = txtAccountCode.Text.Trim
        '    _WorkshopLogPPT.psEstateID = GlobalPPT.strEstateID
        '    lblShowAccountCodeDesc.Text = _WorkshopLogBOL.GetAccountDescription(_WorkshopLogPPT)
        'Else
        '    lblShowAccountCodeDesc.Text = String.Empty
        'End If


    End Sub

    Private Sub txtOperatorCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperatorCode.Leave

        If txtOperatorCode.Text.Trim <> String.Empty Then

            Select Case General.ValidateForeignKeyFields("Operator", txtOperatorCode.Text.Trim)
                'Case False
                '    txtOperatorCode.Focus()
                '    MsgBox("Sorry, no such Opearator code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtOperatorCode.Focus()
                    'MsgBox("Sorry, no such operator code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IOperator")
                    lblShowOperatorName.Text = String.Empty
                    txtOperatorCode.Text = String.Empty
                    psWLOperatorID = String.Empty
                    Return
                Case 1
                    txtOperatorCode.Focus()
                    'MsgBox("Sorry, this operator code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IOperatorEstate")
                    lblShowOperatorName.Text = String.Empty
                    txtOperatorCode.Text = String.Empty
                    psWLOperatorID = String.Empty
                    Return
            End Select
        Else
            lblShowOperatorName.Text = String.Empty
            psWLOperatorID = String.Empty
        End If

        If txtOperatorCode.Text.Trim <> String.Empty Then
            _WorkshopLogPPT = New WorkshopLogPPT
            _WorkshopLogBOL = New WorkshopLogBOL

            _WorkshopLogPPT.psEmpCode = txtOperatorCode.Text.Trim

            'Dim dtOperatorDetails As New DataTable
            'dtOperatorDetails = _WorkshopLogBOL.GetOperatorName(_WorkshopLogPPT)

            'lblShowOperatorName.Text = Convert.ToString(dtOperatorDetails.Rows(0)("EmpName"))
            'psWLOperatorID = Convert.ToString(dtOperatorDetails.Rows(0)("EmpID"))

            _WorkshopLogBOL.GetOperatorName(_WorkshopLogPPT)

            lblShowOperatorName.Text = _WorkshopLogPPT.psEmpName
            psWLOperatorID = _WorkshopLogPPT.psEmpID
        Else
            lblShowOperatorName.Text = String.Empty
            psWLOperatorID = String.Empty
        End If

    End Sub

    Function IsValidTime(ByVal lsStartTime As String, ByVal lsEndTime As String, ByVal lsStartOrEndTime As String) As Boolean
        'Dim IsValidStartEndTime As Boolean
        'IsValidStartEndTime = False

        'If lsStartTime <> String.Empty Or lsEndTime <> String.Empty Then
        '    If Expression.IsMatch(lsStartTime) And Expression.IsMatch(lsEndTime) Then

        '        If lsStartTime <> String.Empty And lsEndTime <> String.Empty Then
        '            If DateTime.Parse(lsEndTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) <= DateTime.Parse(lsStartTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
        '                MsgBox("Start time has to be earlier than end time")
        '                txtTotalHrs.Text = String.Empty
        '                IsValidStartEndTime = False
        '                cmbStartHrs.Focus()
        '                'txtStartTime.Focus()
        '            Else
        '                txtTotalHrs.Text = Convert.ToString(DateTime.Parse(lsEndTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
        '                IsValidStartEndTime = True
        '            End If
        '        End If
        '    Else
        '        IsValidStartEndTime = False
        '    End If
        'End If

        'Return IsValidStartEndTime


        Dim rtime As New System.Text.RegularExpressions.Regex("[0-9]:[0-5][0-9]$")
        If Not rtime.IsMatch(txtTotalHrs.Text.Trim) Then
            DisplayInfoMessage("ITimeFormat")
            txtTotalHrs.Focus()
            Return False
        End If


        'Dim rtime As New System.Text.RegularExpressions.Regex("[0-9][0-9][0-9]\:[0-5][0-9]")
        'If Not rtime.IsMatch(txtTotalHrs.Text.Trim) Then
        '    Dim rtime1 As New System.Text.RegularExpressions.Regex("[0-9][0-9]\:[0-5][0-9]")
        '    If Not rtime1.IsMatch(txtTotalHrs.Text.Trim) Then
        '        ' MessageBox.Show("Please provide the time in hh:mm format", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '        DisplayInfoMessage("ITotalHrs")
        '        txtTotalHrs.Focus()
        '        Return False
        '    End If

        'End If

        If lsStartTime <> String.Empty Or lsEndTime <> String.Empty Then
            If lsStartTime = lsEndTime Then
                'MsgBox("Start time has to be earlier than end time")
                DisplayInfoMessage("IStartEndTime")
                txtTotalHrs.Text = String.Empty
                txtStartHr.Focus()

                '                cmbStartHrs.Focus()
                Return False
            End If

            If DateTime.Parse(lsEndTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) <= DateTime.Parse(lsStartTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
                'MsgBox("Start time has to be earlier than end time")
                DisplayInfoMessage("IStartEndTime")
                txtTotalHrs.Text = String.Empty
                txtStartHr.Focus()
                'cmbStartHrs.Focus()
                Return False
            Else
                txtTotalHrs.Text = Convert.ToString(DateTime.Parse(lsEndTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
                Return True
            End If

        End If


        '

        Return True

    End Function

    Private Sub ValidateTime(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim lSender As TextBox = DirectCast(sender, TextBox)

        ''''ValidDataType
        If Not Expression.IsMatch(lsStartTime.Trim) And lsStartTime.Trim <> String.Empty Then
            txtTotalHrs.Text = String.Empty

            'MsgBox("Invalid Start Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("IStartTime")

            lsStartTime = String.Empty
            txtStartHr.Focus()
            ' cmbStartHrs.Focus()
            'txtStartTime.Focus()

            Return
        End If

        If Not Expression.IsMatch(lsEndTime.Trim) And lsEndTime.Trim <> String.Empty Then
            txtTotalHrs.Text = String.Empty

            'MsgBox("Invalid End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("IEndTime")
            lsEndTime = String.Empty
            txtEndHr.Focus()
            ' cmbEndHrs.Focus()
            'txtEndTime.Focus()

            Return
        End If

        'If both are same time
        If lsStartTime.Trim <> String.Empty And lsEndTime.Trim <> String.Empty Then
            If lsStartTime.Trim = lsEndTime.Trim Then
                txtTotalHrs.Text = String.Empty

                Select Case DirectCast(sender, TextBox).Name
                    Case "txtStartTime"
                        '              txtStartTime.Focus()
                    Case "txtEndTime"
                        '              txtEndTime.Focus()
                End Select

                'MsgBox("Start Time should not be equal to End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IEqualTime")

                Return

            ElseIf Convert.ToDateTime(lsStartTime.Trim) > Convert.ToDateTime(lsEndTime.Trim) Then

                'MsgBox("Start Time should be less than End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("ILessTime")
                txtTotalHrs.Text = String.Empty

                Select Case DirectCast(sender, TextBox).Name
                    Case "txtStartTime"
                        '           txtStartTime.Focus()
                    Case "txtEndTime"
                        '             txtEndTime.Focus()
                End Select

                Return

            End If
        End If

        '''''Calculation
        If lsStartTime.Trim <> String.Empty And lsEndTime.Trim <> String.Empty Then
            If DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) < DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then

                txtTotalHrs.Text = Convert.ToString(DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)

            Else
                txtTotalHrs.Text = String.Empty
                Return
            End If
        End If

        'Dim txtTimeRaised As TextBox = sender

        'If txtStartTime.Text = String.Empty Or txtEndTime.Text = String.Empty Then
        '    txtTotalHrs.Text = String.Empty
        '    Return
        'End If

        'If Expression.IsMatch(txtStartTime.Text) And Expression.IsMatch(txtEndTime.Text) Then
        '    If DateTime.Parse(txtEndTime.Text, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) <= DateTime.Parse(txtStartTime.Text, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
        '        txtTotalHrs.Text = String.Empty
        '    Else
        '        txtTotalHrs.Text = Convert.ToString(DateTime.Parse(txtEndTime.Text, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(txtStartTime.Text, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
        '    End If
        'Else
        '    txtTotalHrs.Text = String.Empty
        'End If

    End Sub

    'Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave

    '    If txtSubBlock.Text.Trim() <> String.Empty And txtSubBlock.Enabled = True Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.BlockName = txtSubBlock.Text.Trim()
    '        objSIV.BlockStatus = GlobalPPT.psAcctExpenditureType
    '        ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
    '            txtSubBlock.Text = String.Empty
    '            psSIVBlockID = String.Empty
    '            'lblSubBlockName.Text = String.Empty
    '            Me.txtDIV.Text = String.Empty
    '            psSIVDivID = String.Empty
    '            'Me.lblDivName.Text = String.Empty
    '            Me.txtYOP.Text = String.Empty
    '            'Me.lblYOPName.Text = String.Empty
    '            psSIVYopID = String.Empty
    '            txtSubBlock.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
    '                txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
    '            End If
    '            psSIVBlockID = ds.Tables(0).Rows(0).Item("BlockID")
    '            If ds.Tables(0).Rows(0).Item("BlockStatus") <> String.Empty Then
    '                'lblSubBlockName.Text = ds.Tables(0).Rows(0).Item("BlockStatus")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
    '                Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
    '            End If
    '            psSIVDivID = ds.Tables(0).Rows(0).Item("DivID")
    '            If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
    '                'Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
    '                Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("Name") <> String.Empty Then
    '                'Me.lblYOPName.Text = ds.Tables(0).Rows(0).Item("Name")
    '            End If
    '            psSIVYopID = ds.Tables(0).Rows(0).Item("YOPID")
    '        End If
    '    ElseIf txtSubBlock.Text.Trim() = String.Empty And txtSubBlock.Enabled = True Then
    '        ClearSubBlock()
    '    End If

    'End Sub

    Private Sub txtSubBlock_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave

        If txtSubBlock.Text.Trim() <> String.Empty And txtSubBlock.Enabled = True Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.BlockName = txtSubBlock.Text.Trim()
            objSIV.BlockStatus = GlobalPPT.psAcctExpenditureType
            ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("ISubBlock"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblBlock.Text)
                DisplayInfoMessage("ISubBlock")
                'MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
                txtSubBlock.Text = String.Empty
                Me.txtDIV.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                Exit Sub

            Else
                If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
                    txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
                End If

                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
                End If

                If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
                    Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
                End If

                'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
            End If
        ElseIf txtSubBlock.Text.Trim() = String.Empty Then
            txtSubBlock.Text = String.Empty
            Me.txtDIV.Text = String.Empty
            Me.txtYOP.Text = String.Empty
        End If
    End Sub

    'Private Sub txtDiv_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDIV.Leave

    '    If txtDIV.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.Div = txtDIV.Text.Trim()
    '        objSIV.BlockID = psSIVBlockID
    '        ds = StoreIssueVoucherBOL.GetDIV(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("This block does not belongs to selected division,Please Choose it from look up")
    '            txtDIV.Text = String.Empty
    '            'lblDivName.Text = String.Empty
    '            psSIVDivID = String.Empty
    '            txtDIV.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
    '                Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
    '                'Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
    '            End If
    '            psSIVDivID = ds.Tables(0).Rows(0).Item("DivID")
    '        End If
    '    Else
    '        txtDIV.Text = String.Empty
    '        'lblDivName.Text = String.Empty
    '        psSIVDivID = String.Empty
    '    End If

    'End Sub





    'Private Sub txtT1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1.Leave
    '    If txtT1.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.T1Value = txtT1.Text.Trim()
    '        objSIV.TDecide = "T1"
    '        ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("Invalid T1 Value,Please Choose it from look up")
    '            Me.lblT1Name.Text = String.Empty
    '            Me.txtT1.Text = String.Empty
    '            txtT1.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
    '                Me.lblT1Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
    '            End If
    '            If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
    '                Me.txtT1.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
    '            End If
    '        End If
    '    Else
    '        Me.lblT1Name.Text = String.Empty
    '        Me.txtT1.Text = String.Empty
    '    End If
    'End Sub


    'Private Sub txtT2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT2.Leave
    '    If txtT2.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.T2Value = txtT2.Text.Trim()
    '        objSIV.TDecide = "T2"
    '        ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("Invalid T2 Value,Please Choose it from look up")
    '            Me.lblT2Name.Text = String.Empty
    '            Me.txtT2.Text = String.Empty
    '            txtT2.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
    '                Me.lblT2Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
    '            End If
    '            If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
    '                Me.txtT2.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
    '            End If
    '        End If
    '    Else
    '        Me.lblT2Name.Text = String.Empty
    '        Me.txtT2.Text = String.Empty
    '    End If

    'End Sub


    'Private Sub txtT3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT3.Leave
    '    If txtT3.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.T3Value = txtT3.Text.Trim()
    '        objSIV.TDecide = "T3"
    '        ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("Invalid T3 Value,Please Choose it from look up")
    '            Me.lblT3Name.Text = String.Empty
    '            Me.txtT3.Text = String.Empty
    '            txtT3.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
    '                Me.lblT3Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
    '            End If
    '            If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
    '                Me.txtT3.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
    '            End If
    '        End If
    '    Else
    '        Me.lblT3Name.Text = String.Empty
    '        Me.txtT3.Text = String.Empty
    '    End If

    'End Sub


    'Private Sub txtT4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4.Leave
    '    If txtT4.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.T4Value = txtT4.Text.Trim()
    '        objSIV.TDecide = "T4"
    '        ds = StoreIssueVoucherBOL.TlookupSearch(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            MessageBox.Show("Invalid T4 Value,Please Choose it from look up")
    '            Me.lblT4Name.Text = String.Empty
    '            Me.txtT4.Text = String.Empty
    '            txtT4.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString() <> String.Empty Then
    '                Me.lblT4Name.Text = ds.Tables(0).Rows(0).Item("TAnalysisDescp").ToString()
    '            End If
    '            If ds.Tables(0).Rows(0).Item("TValue").ToString() <> String.Empty Then
    '                Me.txtT4.Text = ds.Tables(0).Rows(0).Item("TValue").ToString()
    '            End If
    '        End If
    '    Else
    '        Me.lblT4Name.Text = String.Empty
    '        Me.txtT4.Text = String.Empty
    '    End If

    'End Sub


    'Private Sub txtT0_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT0.Leave

    '    If txtT0.Text.Trim <> String.Empty Then
    '        Select Case General.ValidateForeignKeyFields("TAnalysis0", txtT0.Text.Trim)
    '            Case 0
    '                txtT0.Focus()
    '                MsgBox("Sorry, no such T0 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '            Case 1
    '                txtT0.Focus()
    '                MsgBox("Sorry, this T0 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '        End Select
    '    End If

    'End Sub

    'Private Sub txtT1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1.Leave
    '    If txtT1.Text.Trim <> String.Empty Then
    '        Select Case General.ValidateForeignKeyFields("TAnalysis1", txtT1.Text.Trim)
    '            Case 0
    '                txtT1.Focus()
    '                MsgBox("Sorry, no such T1 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '            Case 1
    '                txtT1.Focus()
    '                MsgBox("Sorry, this T1 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '        End Select
    '    End If
    'End Sub

    'Private Sub txtT2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT2.Leave

    '    If txtT2.Text.Trim <> String.Empty Then
    '        Select Case General.ValidateForeignKeyFields("TAnalysis2", txtT2.Text.Trim)
    '            Case 0
    '                txtT2.Focus()
    '                MsgBox("Sorry, no such T2 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '            Case 1
    '                txtT2.Focus()
    '                MsgBox("Sorry, this T2 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '        End Select
    '    End If

    'End Sub

    'Private Sub txtT3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT3.Leave

    '    If txtT3.Text.Trim <> String.Empty Then
    '        Select Case General.ValidateForeignKeyFields("TAnalysis3", txtT3.Text.Trim)
    '            Case 0
    '                txtT3.Focus()
    '                MsgBox("Sorry, no such T3 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '            Case 1
    '                txtT3.Focus()
    '                MsgBox("Sorry, this T3 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '        End Select
    '    End If

    'End Sub

    'Private Sub txtT4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4.Leave
    '    If txtT4.Text.Trim <> String.Empty Then
    '        Select Case General.ValidateForeignKeyFields("TAnalysis4", txtT4.Text.Trim)
    '            Case 0
    '                txtT4.Focus()
    '                MsgBox("Sorry, no such T4 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '            Case 1
    '                txtT4.Focus()
    '                MsgBox("Sorry, this T4 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return
    '        End Select
    '    End If
    'End Sub

    Function IsForeignKeyValueExist() As Boolean
        lsErrorMessage = String.Empty

        If cmbWorkshopCode.Text.Trim <> String.Empty Then
            Select Case General.IsVHWSCodeExist("W", cmbWorkshopCode.Text.Trim)
                Case 0
                    cmbWorkshopCode.Focus()
                    'MsgBox("Sorry, no such workshop code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IWorkshop")
                    Return False
                Case 1
                    cmbWorkshopCode.Focus()
                    'MsgBox("Sorry, this workshop code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IWorkshopEstate")
                    Return False
            End Select
        End If

        If txtVehicleCode.Text.Trim <> String.Empty Then
            Select Case WorkShopLogFrm.IsVHWSCodeExist(txtVehicleCode.Text.Trim)
                Case 0
                    txtVehicleCode.Focus()
                    'MsgBox("Sorry, no such vehicle code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IVehicle")
                    Return False
                Case 1
                    txtVehicleCode.Focus()
                    'MsgBox("Sorry, this vehicle code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IVehicleEstate")
                    Return False
            End Select
        End If

        If txtOperatorCode.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("Operator", txtOperatorCode.Text.Trim)
                'Case False
                '    txtOperatorCode.Focus()
                '    MsgBox("Sorry, no such Opearator code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtOperatorCode.Focus()
                    'MsgBox("Sorry, no such operator code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IOperator")
                    Return False
                Case 1
                    txtOperatorCode.Focus()
                    'MsgBox("Sorry, this operator code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IOperatorEstate")
                    Return False
            End Select
        End If

        If txtAccountCode.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("Account", txtAccountCode.Text.Trim)
                'Case False
                '    txtAccountCode.Focus()
                '    MsgBox("Sorry, no such Account code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtAccountCode.Focus()
                    'MsgBox("Sorry, no such account code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IAccountCode")
                    Return False
                    'Case 1
                    '    txtAccountCode.Focus()
                    '    MsgBox("Sorry, this account code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    '    Return False
            End Select
        End If

        'If txtDIV.Text.Trim <> String.Empty Then
        '    Select Case General.ValidateForeignKeyFields("Division", txtDIV.Text.Trim)
        '        'Case False
        '        '    txtDIV.Focus()
        '        '    MsgBox("Sorry, no such DIV value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '        '    Return False
        '        Case 0
        '            txtDIV.Focus()
        '            MsgBox("Sorry, no such DIV value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            Return False
        '        Case 1
        '            txtDIV.Focus()
        '            MsgBox("Sorry, this DIV value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            Return False
        '    End Select
        'End If

        'If txtYOP.Text.Trim <> String.Empty Then
        '    Select Case General.ValidateForeignKeyFields("YOP", txtYOP.Text.Trim)
        '        'Case False
        '        '    txtYOP.Focus()
        '        '    MsgBox("Sorry, no such YOP value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '        '    Return False
        '        Case 0
        '            txtYOP.Focus()
        '            MsgBox("Sorry, no such YOP exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            Return False
        '        Case 1
        '            txtYOP.Focus()
        '            MsgBox("Sorry, this YOP does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            Return False
        '        Case 2

        '            Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
        '            Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL

        '            _SearchCodePPT.psSearchBy = "YOP"

        '            _SearchCodePPT.psYOPCode = txtYOP.Text.Trim

        '            If txtDIV.Text.Trim <> String.Empty Then
        '                _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
        '            End If

        '            _SearchCodePPT.psSearchTerm = "OnGo"
        '            _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        '            Dim dt As DataTable = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)

        '            If dt.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty Then
        '                txtYOP.Focus()
        '                MsgBox("Sorry, no such YOP value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '                Return False
        '            ElseIf dt.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty Then
        '                txtYOP.Focus()
        '                MsgBox("YOP value does not correspond with the DIV value. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '                Return False
        '            End If
        '            Exit Select

        '    End Select
        'End If

        If txtSubBlock.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("Sub-Block", txtSubBlock.Text.Trim)
                'Case False
                '    txtSubBlock.Focus()
                '    MsgBox("Sorry, no such Sub-Block value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtSubBlock.Focus()
                    'MsgBox("Sorry, no such sub-block value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("ISubBlock")
                    Return False
                Case 1
                    txtSubBlock.Focus()
                    'MsgBox("Sorry, this sub-block value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("ISubBlockEstate")
                    Return False
                    'Case 2

                    '    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
                    '    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL

                    '    If txtDIV.Text.Trim <> String.Empty Then
                    '        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
                    '    End If

                    '    If txtYOP.Text.Trim <> String.Empty Then
                    '        _SearchCodePPT.psYOPCode = txtYOP.Text.Trim
                    '    End If

                    '    _SearchCodePPT.psSubBlockCode = txtSubBlock.Text.Trim
                    '    _SearchCodePPT.psSearchTerm = "OnGo"
                    '    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

                    '    Dim dt As DataTable = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)

                    '    If dt.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim <> String.Empty Then
                    '        txtSubBlock.Focus()
                    '        MsgBox("Sorry, no such sub-block value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    '        Return False
                    '    ElseIf dt.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty And txtYOP.Text.Trim <> String.Empty Then
                    '        txtSubBlock.Focus()
                    '        MsgBox("Sub-block value does not correspond with the YOP and DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    '        Return False
                    '    ElseIf dt.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim = String.Empty Then
                    '        txtSubBlock.Focus()
                    '        MsgBox("Sub-block value does not correspond with the DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    '        Return False
                    '    End If
                    '    Exit Select

            End Select
        End If

        If txtT0.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("TAnalysis0", txtT0.Text.Trim)
                'Case False
                '    txtT0.Focus()
                '    MsgBox("Sorry, no such t0 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtT0.Focus()
                    'MsgBox("Sorry, no such T0 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT0")
                    Return False
                Case 1
                    txtT0.Focus()
                    'MsgBox("Sorry, this T0 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT0Estate")
                    Return False
            End Select
        End If

        If txtT1.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("TAnalysis1", txtT1.Text.Trim)
                'Case False
                '    txtT1.Focus()
                '    MsgBox("Sorry, no such t1 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtT1.Focus()
                    'MsgBox("Sorry, no such T1 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT1")
                    Return False
                Case 1
                    txtT1.Focus()
                    'MsgBox("Sorry, this T1 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT1Estate")
                    Return False
            End Select
        End If

        If txtT2.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("TAnalysis2", txtT2.Text.Trim)
                'Case False
                '    txtT2.Focus()
                '    MsgBox("Sorry, no such t2 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtT2.Focus()
                    'MsgBox("Sorry, no such T2 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT2")
                    Return False
                Case 1
                    txtT2.Focus()
                    'MsgBox("Sorry, this T2 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT2Estate")
                    Return False
            End Select
        End If

        If txtT3.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("TAnalysis3", txtT3.Text.Trim)
                'Case False
                '    txtT3.Focus()
                '    MsgBox("Sorry, no such t3 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtT3.Focus()
                    'MsgBox("Sorry, no such T3 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT3")
                    Return False
                Case 1
                    txtT3.Focus()
                    'MsgBox("Sorry, this T3 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT3Estate")
                    Return False
            End Select
        End If

        If txtT4.Text.Trim <> String.Empty Then
            Select Case General.ValidateForeignKeyFields("TAnalysis4", txtT4.Text.Trim)
                'Case False
                '    txtT4.Focus()
                '    MsgBox("Sorry, no such t4 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                '    Return False
                Case 0
                    txtT4.Focus()
                    'MsgBox("Sorry, no such T4 value exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT4")
                    Return False
                Case 1
                    txtT4.Focus()
                    'MsgBox("Sorry, this T4 value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("IT4Estate")
                    Return False
            End Select
        End If

        Return True
    End Function

    Function IsValidAccountAndBlockCodeCombination() As Boolean
        Dim objBOL As New GlobalBOL
        Dim RequiredField As String
        'Dim lsErrorMessage As String = String.Empty
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If txtAccountCode.Text <> String.Empty Then
            RequiredField = String.Empty

            If objBOL.IsSetMandatoryInCOA(psWLAccountID, "AccountControl", "VEHICLE", RequiredField) Then
                If RequiredField <> String.Empty Then
                    If GlobalPPT.strLang = "en" Then
                        MessageBox.Show("This Account Code is allowed only for" & RequiredField)

                    ElseIf GlobalPPT.strLang = "ms" Then

                        MessageBox.Show("Kode Rekening diperbolehkan hanya untuk" & RequiredField)
                    End If

                    ''DisplayInfoMessage("Msg01" & RequiredField)
                    '' MessageBox.Show("This Account Code is allowed only for " & RequiredField)
                    'lsErrorMessage = "This Account Code is allowed only for " & RequiredField
                    Return False
                End If
            End If
        End If

        If txtAccountCode.Text <> String.Empty And txtSubBlock.Text.Trim = String.Empty Then
            RequiredField = String.Empty
            If objBOL.IsSetMandatoryInCOA(psWLAccountID, "SubType", "VEHICLE", RequiredField) Then
                If RequiredField = "Sub Block Code" Then
                    If GlobalPPT.strLang = "en" Then
                        MessageBox.Show("This Account Code required a" & RequiredField)

                    ElseIf GlobalPPT.strLang = "ms" Then

                        MessageBox.Show("Kode ini membutuhkan Account" & RequiredField)
                    End If
                    ''DisplayInfoMessage("Msg02" & RequiredField)
                    'MessageBox.Show("This Account Code required a " & RequiredField)
                    'lsErrorMessage = "This Account Code required a " & RequiredField
                    Return False
                End If
            End If
        End If

        Return True

        'If lsErrorMessage = String.Empty Then
        '    Return True
        'Else
        '    MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    Return False
        'End If

    End Function

#End Region

    'Private Sub SearchByCodeOrDate_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)



    '    If rbDate.Checked Then
    '        dtpSearchBydate.Visible = True
    '        txtWorkshopSearch.Visible = False
    '    Else
    '        dtpSearchBydate.Visible = False
    '        txtWorkshopSearch.Visible = True
    '    End If
    '    txtWorkshopSearch.Text = String.Empty

    'End Sub



    'Private Sub ibtnSearchWorkshopLogNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim _WorkshopLookup As New WorkshopLookupfrm()
    '    Dim result As DialogResult = _WorkshopLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then

    '        _lookupCode = _WorkshopLookup.lWSCode
    '        _lookupId = _WorkshopLookup.lWSID

    '        cmbWorkshopCode.Text = _lookupCode

    '        'When we come from vehicle look up form
    '        Me.BindWorkshopLogDetailsByWorkshopCode(Me.cmbWorkshopCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))

    '    End If
    'End Sub



    'Private Sub ibtnSearchDIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLookUpDIV.Click

    '    'Dim _VHDIVLookup As New VHDIVLookup
    '    'Dim result As DialogResult = _VHDIVLookup.ShowDialog()
    '    'If (result = DialogResult.OK) Then
    '    '    txtYOP.Text = String.Empty
    '    '    txtSubBlock.Text = String.Empty
    '    '    txtDIV.Text = _VHDIVLookup.lDivCode
    '    'End If

    '    Dim _VHDIVLookup As New VHDIVLookup()
    '    Dim result As DialogResult = _VHDIVLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then
    '        txtDIV.Text = _VHDIVLookup.lDivCode
    '    End If

    '    If _VHDIVLookup.lDivCode.Trim <> String.Empty Then
    '        EnableDivYopBlock("YOP", True)
    '        txtYOP.Focus()
    '    End If

    'End Sub

    'Private Sub ibtnSearchYOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLookUpYOP.Click

    '    Dim _VHYOPLookup As New VHYOPLookup(txtDIV.Text.Trim)
    '    Dim result As DialogResult = _VHYOPLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then

    '        txtYOP.Text = _VHYOPLookup.lYOPCode
    '        If _VHYOPLookup.lYOPDiv <> String.Empty Then
    '            txtDIV.Text = _VHYOPLookup.lYOPDiv
    '        End If
    '    End If

    '    If _VHYOPLookup.lYOPDiv.Trim <> String.Empty Then
    '        EnableDivYopBlock("SubBlock", True)
    '        txtSubBlock.Focus()
    '    End If

    '    'Dim _VHYOPLookup As New VHYOPLookup(txtDIV.Text.Trim)
    '    'Dim result As DialogResult = _VHYOPLookup.ShowDialog()

    '    'If (result = DialogResult.OK) Then

    '    '    _lookupCode = _VHYOPLookup.lYOPCode ' _lcoaCode

    '    '    txtYOP.Text = _lookupCode
    '    '    If _VHYOPLookup.lYOPDiv <> String.Empty Then
    '    '        txtDIV.Text = _VHYOPLookup.lYOPDiv
    '    '    End If
    '    'End If
    'End Sub

    'Private Sub ibtnSearchBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLookUpSubBlock.Click

    '    Dim _VHSubBlockLookup As New VHSubBlockLookup(txtDIV.Text.Trim, txtYOP.Text.Trim)
    '    Dim result As DialogResult = _VHSubBlockLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then

    '        txtSubBlock.Text = _VHSubBlockLookup.lSBCode
    '        If _VHSubBlockLookup.lDivCode <> String.Empty Then
    '            txtDIV.Text = _VHSubBlockLookup.lDivCode
    '        End If
    '        If _VHSubBlockLookup.lYOPCode <> String.Empty Then
    '            txtYOP.Text = _VHSubBlockLookup.lYOPCode
    '        End If

    '    End If

    '    'Dim _VHSubBlockLookup As New VHSubBlockLookup(txtDIV.Text.Trim, txtYOP.Text.Trim)
    '    'Dim result As DialogResult = _VHSubBlockLookup.ShowDialog()

    '    'If (result = DialogResult.OK) Then

    '    '    _lookupCode = _VHSubBlockLookup.lSBCode ' _lcoaCode

    '    '    txtSubBlock.Text = _lookupCode

    '    '    If _VHSubBlockLookup.lDivCode <> String.Empty Then
    '    '        txtDIV.Text = _VHSubBlockLookup.lDivCode
    '    '    End If

    '    '    If _VHSubBlockLookup.lYOPCode <> String.Empty Then
    '    '        txtYOP.Text = _VHSubBlockLookup.lYOPCode
    '    '    End If

    '    'End If
    'End Sub

    'Private Sub ibtnSearchBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLookUpSubBlock.Click

    '    Dim frmSubBlock As New SubBlockLookup
    '    Dim result As DialogResult = frmSubBlock.ShowDialog()
    '    If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.txtSubBlock.Text = frmSubBlock.psBlockName
    '        psSIVBlockID = frmSubBlock.psBlockId
    '        ''Me.lblSubBlockName.Text = frmSubBlock.psBlockStatus
    '        Me.txtDIV.Text = frmSubBlock.psDIV
    '        psSIVDivID = frmSubBlock.psDIVID
    '        ''Me.lblDivName.Text = frmSubBlock.psDIVName
    '        Me.txtYOP.Text = frmSubBlock.psYop
    '        ''  Me.lblYOPName.Text = frmSubBlock.psYopName
    '        psSIVYopID = frmSubBlock.psYopID
    '    End If

    'End Sub



    'Private Sub btnLookUpDIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLookUpDIV.Click

    '    Dim frmDivLookup As New DivLookup
    '    frmDivLookup.BindDIV(psSIVBlockID)
    '    Dim result As DialogResult = frmDivLookup.ShowDialog()
    '    If frmDivLookup.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.txtDIV.Text = frmDivLookup.psDIV
    '        psSIVDivID = frmDivLookup.psDIVID
    '    End If

    'End Sub



    'Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
    '    Me.ResetRequiredMainControls()
    '    Me.ResetRequiredControls()
    '    Me.btnSaveOrUpdate.Text = "Save"
    '    ResetControls()
    '    Me.dtpDate.Text = dtpDate.MinDate
    '    BindWorkshopLogDetailsByWorkshopCode(String.Empty, CDate("1/1/1753"))
    '    Me.tbcWorkshop.SelectedIndex = 0
    'End Sub

    Private Sub txtAccountCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.TextChanged
        ClearSubBlock()
    End Sub

    Private Sub txtSubBlock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.TextChanged

    End Sub

    Private Sub txtTotalHrs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalHrs.KeyPress


        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 58 And Asc(e.KeyChar) <> 8 Then
            e.KeyChar = ""
        End If

        txtStartHr.Enabled = False
        txtStartMin.Enabled = False
        txtEndHr.Enabled = False
        txtEndMin.Enabled = False

        'cmbStartHrs.Enabled = False
        'cmbStartMin.Enabled = False
        'cmbEndHrs.Enabled = False
        'cmbEndMin.Enabled = False
        lsStartTime = String.Empty
        lsEndTime = String.Empty


        '    Dim rtime As New System.Text.RegularExpressions.Regex("[0-9][0-9][0-9]\:[0-6][0-9]")
        '    If Not rtime.IsMatch(txtTotalHrs.Text.Trim) Then
        '        MessageBox.Show("Please provide the time in hh:mm format", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '    End If
    End Sub

    Private Sub txtTotalHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalHrs.Leave
        If txtTotalHrs.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("[0-9]:[0-5][0-9]$")
            If Not rtime.IsMatch(txtTotalHrs.Text.Trim) Then
                DisplayInfoMessage("ITimeFormat")
                txtTotalHrs.Focus()
            End If

            txtStartHr.Enabled = True
            txtStartMin.Enabled = True
            txtEndHr.Enabled = True
            txtEndMin.Enabled = True

        End If

    End Sub
End Class