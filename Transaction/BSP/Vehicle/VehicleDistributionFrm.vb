Imports Vehicle_BOL
Imports Vehicle_PPT
Imports Common_PPT
Imports Common_BOL
Imports Accounts_BOL
Imports Accounts_PPT
Imports Store_PPT
Imports Store_BOL

Public Class VehicleDistributionFrm

    Dim ObjValidator As Validator
    'Dim _VehicleRunningBatchPPT As VehicleRunningBatchPPT
    'Dim _SearchVehicleCode As SearchVehicleCode
    Dim ObjVehicleDistributionPPT As VehicleDistributionPPT
    Dim ObjVehicleDistributionBOL As VehicleDistributionBOL
    Dim ObjWorkshopLogPPT As WorkshopLogPPT
    Dim ObjWorkshopLogBOL As WorkshopLogBOL
    Public lBlockID As String = String.Empty

    Private lsVHDisID As String = String.Empty
    Private lsVHID As String = String.Empty
    Private lsVDAccountID As String = String.Empty
    Private lsVDExpenditureAG As String = String.Empty
    Private lsVDDivID As String = String.Empty
    Private lsVDYopID As String = String.Empty
    Private lsVDBlockID As String = String.Empty
    Private lsVDT0analysisID As String = String.Empty
    Private lsVDT1analysisID As String = String.Empty
    Private lsVDT2analysisID As String = String.Empty
    Private lsVDT3analysisID As String = String.Empty
    Private lsVDT4analysisID As String = String.Empty
    Private lsUOM As String = String.Empty
    Private Shared lsStartTime As String
    Private saveBool As Boolean = False

    Private lsTotalRunningKmHours As Decimal = 0
    Private lsTotalKmHoursDistributed As Decimal = 0
    Private lsBalanceToDistribute As Decimal = 0

    Private liIsTableAltered As Boolean = False
    Private liOperationFlag As Integer = 0 ' 0=No, 1= Add, 2=Update, 3=Delete
    Private lbAdd As Boolean = True
    Private lbIsUpdating As Boolean = False


    Private liId As Integer
    Dim lbConcurrencyID As Byte() = New Byte(7) {}

    Private lslookupCode As String = String.Empty
    Private lslookupId As String = String.Empty
    Private lslookupDesc As String = String.Empty
    Private lslookupValue As String = String.Empty
    Private lbIsDecimal As Boolean
    Private lreDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,2})?$")
    Private lreTimePlaces As New System.Text.RegularExpressions.Regex("^\d{0,16}(\:\d{0,2})?$")
    Dim lreValidateTime As New System.Text.RegularExpressions.Regex("^(([0-1][0-9])|([2][0-3]))[:]([0-5][0-9])$")

    Dim lsErrorMessage As String
    'A local variable "liIdForRecordEdit" declared to refer the record by its id while updating as well as deleting
    Dim liIdForRecordEdit As Integer
    Dim liIdForRecordDelete As Integer
    Dim lsGUIDForRecordEdit As String
    Dim ldCurrentTotalKmDistributed As Decimal
    Dim ldCurrentBalanceToDistribute As Decimal
    Private dateIsChangedByUser As Boolean = False

    Dim dtVDTempDataTable As New DataTable
    'Dim dtVDTempDataTable2 As New DataTable

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

#Region "Events"

#Region "Common"

    Private Sub VehicleDistributionFrm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If saveBool Then
            Dim msg As New DialogResult
            msg = MsgBox("Don't forget to save data!" & vbNewLine & "Save new data now?", MessageBoxButtons.YesNo)
            If (msg = Windows.Forms.DialogResult.Yes) Then
                SaveAllData()
            End If
        End If        
    End Sub

    'Private Sub VehicleDistributionFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    'If btnSaveAll.Enabled = True Then
    '    '    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
    '    '    If MsgBox(rm.GetString("UnSavedAlert"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
    '    '        e.Cancel = True
    '    '        Return
    '    '    End If
    '    'End If
    'End Sub

    Private Sub VehicleDistribution_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub VehicleDistribution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSearchBydate)
        VDTempDataTable1()

        BindVehicleCode(String.Empty, String.Empty)

        '        Me.tbcVehicleDistribution.SelectTab(1)


        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        txtStartHrs.Visible = False
        txtStartMin.Visible = False

        'cmbStartHrs.Visible = False
        'cmbStartMin.Visible = False
        Label2.Visible = False
        Label35.Visible = False
        txtShift.Visible = False
        txtVehicleCode.Enabled = False
        txtT0.Text = Helper.T0Default(0)
        lsVDT0analysisID = Helper.T0Default(0)
        lblT0Desc.Text = Helper.T0Default(1)
    End Sub

    Private Sub tbcVehicleDistribution_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcVehicleDistribution.SelectedIndexChanged
        If Me.tbcVehicleDistribution.SelectedIndex = 0 Then
            Me.ResetViewArea()
            chkVDDate.Focus()
        Else
            If btnSaveAll.Enabled = False And liIsTableAltered = False Then
                BindVehicleCode(String.Empty, String.Empty)
                dtpDate.Focus()
                ResetTop()
                ResetMainControls()
                ResetRequiredControls()
                ResetControls()
                'btnSaveAll.Enabled = False
                If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If

            Else
                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                If MsgBox(rm.GetString("UnSavedAlert"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                    'MsgBox(rm.GetString("UnSavedAlert"), MsgBoxStyle.OkOnly, "Information")
                    Me.tbcVehicleDistribution.SelectTab(0)
                Else
                    BindVehicleCode(String.Empty, String.Empty)
                    dtpDate.Focus()
                    ResetTop()
                    ResetMainControls()
                    ResetRequiredControls()
                    ResetControls()
                    btnSaveAll.Enabled = False
                    liIsTableAltered = False
                End If
            End If
        End If
    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgVehicle.DataBindingComplete, dgVehicleLog.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

#End Region

#Region "Entry Tab"

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        If Me.txtVehicleCode.Text <> String.Empty And Me.dateIsChangedByUser Then
            'Me.btnAdd.Text = "Add"
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            btnAdd.Enabled = True
            btnResetMultipleEntryGrp.Enabled = True
            Me.ResetControls()
            ResetMainControls()
            ResetRequiredControls()
            'ResetControls()

            Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
            Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
            txtKm.Focus()
        Else
            ResetControls()
            Me.BindVehicleDistributionByVehicleCode(String.Empty, New DateTime(1900, 1, 1))
        End If

        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dtpDate_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.DropDown
        Me.dateIsChangedByUser = True
    End Sub

    Private Sub dtpDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.CloseUp
        Me.dateIsChangedByUser = False
    End Sub

    Private Sub ibtnSearchVehicleCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchVehicleCode.Click
        Dim ObjVehicleLookup As New VHDistributionVehicleLookup()
        ObjVehicleLookup.pdtLogDate = Me.dtpDate.Value
        Dim result As DialogResult = ObjVehicleLookup.ShowDialog()

        If (result = DialogResult.OK) Then

            ResetMainControls()
            ResetRequiredControls()
            ResetControls()

            lsVHID = ObjVehicleLookup.psVHID
            txtVehicleCode.Text = ObjVehicleLookup.psVHWSCode
            lsUOM = ObjVehicleLookup.psUOM

            Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
            Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))

            Select Case (lsUOM)
                Case "Hrs"
                    txtStartHrs.Focus()
                    'cmbStartHrs.Focus()
                Case "Kms"
                    txtKm.Focus()
            End Select


        End If

        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub ibtnSearchAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchAccount.Click

        Dim ObjCOALookup As New COALookup
        ObjCOALookup.ShowDialog()
        If ObjCOALookup.strAcctId <> String.Empty Then
            Me.txtAccountCode.Text = ObjCOALookup.strAcctcode
            lsVDAccountID = ObjCOALookup.strAcctId
            lblAccountDescription.Text = ObjCOALookup.strAcctDescp
            lblOldAccountValue.Text = ObjCOALookup.strOldAccountCode
            GlobalPPT.psAcctExpenditureType = ObjCOALookup.strAcctExpenditureAG
            lsVDExpenditureAG = ObjCOALookup.strAcctExpenditureAG
        End If

    End Sub

    'For accept only Decimal Numbers
    Private Sub lbIsDecimalOrientedKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKm.KeyDown, txtPrestasiTonnageBuncheskm.KeyDown  'txtPrestasiTonnageBunchesKm.KeyDown,
        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty

            Select Case (lsUOM)
                Case "Hrs"
                    If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.Shift Or e.KeyCode = Keys.OemPeriod) Then
                        Select Case e.KeyCode
                            Case Keys.Shift, Keys.OemPeriod

                                If txtBox.Text.Trim.Contains(":") Then
                                    lbIsDecimal = False
                                    Return
                                End If

                                lbIsDecimal = True
                                Return

                            Case Else

                                If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                                    text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                                End If

                                If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                                    text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                                End If

                                lbIsDecimal = lreTimePlaces.IsMatch(text)

                        End Select
                    Else
                        lbIsDecimal = False
                        Return
                    End If
                Case "Kms"
                    If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                        Select Case e.KeyCode
                            Case Keys.[Decimal], Keys.OemPeriod

                                If txtBox.Text.Trim.Contains(".") Then
                                    lbIsDecimal = False
                                    Return
                                End If

                                lbIsDecimal = True
                                Return

                            Case Else

                                If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                                    text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                                End If

                                If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                                    text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                                End If

                                lbIsDecimal = lreDecimalPlaces.IsMatch(text)

                        End Select
                    Else
                        lbIsDecimal = False
                        Return
                    End If
            End Select




        Else
            lbIsDecimal = True
        End If

    End Sub

    'For accept only Decimal Numbers
    Private Sub lbIsDecimalOrientedKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKm.KeyPress, txtPrestasiTonnageBuncheskm.KeyPress  'txtPrestasiTonnageBunchesKm.KeyDown,'txtPrestasiTonnageBunchesKm.KeyPress,
        If lbIsDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub ibtnSearchBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchBlock.Click
        Dim frmSubBlock As New VHDistributionSubBlockLookup
        Dim result As DialogResult = frmSubBlock.ShowDialog()
        If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtBlock.Text = frmSubBlock.psBlockName
            lsVDBlockID = frmSubBlock.psBlockId
            lblSubBlockStatus.Text = frmSubBlock.psBlockStatus
            Me.txtDIV.Text = frmSubBlock.psDIV
            lsVDDivID = frmSubBlock.psDIVID
            Me.txtYOP.Text = frmSubBlock.psYop
            lsVDYopID = frmSubBlock.psYopID
        End If
    End Sub

    Private Sub ibtnSearchTAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchTAnalysisT0.Click, ibtnSearchTAnalysisT1.Click, ibtnSearchTAnalysisT2.Click, ibtnSearchTAnalysisT3.Click, ibtnSearchTAnalysisT4.Click
        Dim lBtnTAnalysis As Button = sender
        Dim ObjVHDistributionTlookup As New VHDistributionTlookup

        ''Create an _ect for the class and pass the constructor value to the form
        Select Case lBtnTAnalysis.AccessibleName
            Case "T0"
                VHDistributionTlookup.strTcodeDecide = "T0"
            Case "T1"
                VHDistributionTlookup.strTcodeDecide = "T1"
            Case "T2"
                VHDistributionTlookup.strTcodeDecide = "T2"
            Case "T3"
                VHDistributionTlookup.strTcodeDecide = "T3"
            Case "T4"
                VHDistributionTlookup.strTcodeDecide = "T4"
        End Select

        Dim result As DialogResult = ObjVHDistributionTlookup.ShowDialog()

        If (result = DialogResult.OK) Then
            lslookupCode = ObjVHDistributionTlookup.strTCode
            lslookupId = ObjVHDistributionTlookup.strTId
            lslookupValue = ObjVHDistributionTlookup.strTValue
            lslookupDesc = ObjVHDistributionTlookup.strTDesc

            Select Case lBtnTAnalysis.AccessibleName
                Case "T0"
                    lsVDT0analysisID = lslookupId
                    txtT0.Text = lslookupValue
                    lblT0Desc.Text = lslookupDesc
                Case "T1"
                    lsVDT1analysisID = lslookupId
                    txtT1.Text = lslookupValue
                    lblT1Desc.Text = lslookupDesc
                Case "T2"
                    lsVDT2analysisID = lslookupId
                    txtT2.Text = lslookupValue
                    lblT2Desc.Text = lslookupDesc
                Case "T3"
                    lsVDT3analysisID = lslookupId
                    txtT3.Text = lslookupValue
                    lblT3Desc.Text = lslookupDesc
                Case "T4"
                    lsVDT4analysisID = lslookupId
                    txtT4.Text = lslookupValue
                    lblT4Desc.Text = lslookupDesc
            End Select

        End If

        

        'lslookupCode = String.Empty
        'lslookupId = String.Empty
        'lslookupValue = String.Empty
        'lslookupDesc = String.Empty

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (CheckRequiredFields()) Then
            If CheckKmOrHrs() Then
                If Not IsValidTimeOrKms() Then
                    Return
                End If
                If IsForeignKeyExist() Then

                    If Not IsValidAccountAndBlockCodeCombination() Then
                        Return
                    End If

                    If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If
                    saveBool = True
                    If lbAdd Then
                        If IsDuplicateAccountCodeAdd() Then
                            SaveTemp()
                            ResetRequiredControls()
                            ResetControls()
                            btnSaveAll.Enabled = True
                            liIsTableAltered = True
                            If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                                MsgBox(PrivilegeError)
                            End If
                        Else
                            'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                            'MsgBox(rm.GetString("Msg10"), MsgBoxStyle.OkOnly, "Information")
                            DisplayInfoMessage("Msg10")
                        End If
                        
                    Else
                        If IsDuplicateAccountCodeUpdate() Then
                            UpdateTemp(lsGUIDForRecordEdit)
                            ResetRequiredControls()
                            ResetControls()
                            btnSaveAll.Enabled = True
                            liIsTableAltered = True
                            If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                                MsgBox(PrivilegeError)
                            End If
                        Else
                            'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                            'MsgBox(rm.GetString("Msg10"), MsgBoxStyle.OkOnly, "Information")
                            DisplayInfoMessage("Msg10")
                        End If

                    End If

                End If
            End If
        End If
        
    End Sub

    Private Sub btnResetMultipleEntryGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMultipleEntryGrp.Click
        CalculateTotalKmsDistributedNBalance()
        If lsUOM = "Kms" Then
            txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed
            txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
        ElseIf lsUOM = "Hrs" Then
            'Dim ldTotalHrsValueDT As TimeSpan '= GetInTimeValue(ldCurrentTotalKmDistributed)
            txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed

            If txtTotalRunningKm.Text <> "" Then


                Dim diffSec As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim.Replace(":", "."))) - Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed))
                Dim ldTotalHrsValueDT As String = SecToTime(diffSec)
                Me.txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                '  ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))
                ' ldTotalHrsValueDT = GetInTimeValue(Convert.ToDecimal(txtTotalRunningKm.Text.Trim.Replace(":", "."))) - GetInTimeValue(Convert.ToDecimal(ldCurrentTotalKmDistributed))
                ' txtBalanceToDistribute.Text = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", ".")) 'Convert.ToDecimal(ldTotalHrsValueDT)

            End If

        End If
        ResetRequiredControls()
        ResetControls()

        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub SaveAllData()
        ObjVehicleDistributionPPT = New VehicleDistributionPPT
        ObjVehicleDistributionBOL = New VehicleDistributionBOL

        'ObjVehicleDistributionPPT.psEstateID = GlobalPPT.strEstateID
        'ObjVehicleDistributionPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
        ObjVehicleDistributionPPT.pdDistributionDT = New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day)
        ObjVehicleDistributionPPT.psVHID = lsVHID
        'ObjVehicleDistributionPPT.psVHID = lsVHDisID

        If dtVDTempDataTable.Rows.Count > 0 Then

            Dim rowsAffected As Integer = 0
            Dim dta As New DataTable
            dta = dtVDTempDataTable
            For Each objDR In dtVDTempDataTable.Rows

                If (objDR("TotalRunningKmHours")) Is DBNull.Value Then
                    ObjVehicleDistributionPPT.pdTotalRunningKmHours = Nothing
                Else
                    ObjVehicleDistributionPPT.pdTotalRunningKmHours = objDR("TotalRunningKmHours")
                End If

                If (objDR("TotalKmHoursDistributed")) Is DBNull.Value Then
                    ObjVehicleDistributionPPT.pdTotalKmHoursDistributed = Nothing
                Else
                    Select Case (txtUOM.Text.Trim)
                        Case "Hrs"
                            'Dim ldTotalHrsValueDT As TimeSpan = GetInTimeValue(objDR("TotalKmHoursDistributed")) + GetInTimeValue(objDR("KmHours"))
                            ObjVehicleDistributionPPT.pdTotalKmHoursDistributed = objDR("TotalKmHoursDistributed") 'Convert.ToDecimal((ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", ".")).TrimEnd("."))
                        Case "Kms"
                            ObjVehicleDistributionPPT.pdTotalKmHoursDistributed = objDR("TotalKmHoursDistributed") 'Convert.ToDecimal(objDR("TotalKmHoursDistributed")) + Convert.ToDecimal(objDR("KmHours"))
                    End Select
                End If


                'If ObjVehicleDistributionPPT.pdTotalRunningKmHours <> ObjVehicleDistributionPPT.pdTotalKmHoursDistributed Then
                '    MessageBox.Show("Data Cannot be saved. VH not distributed completely.")
                '    Return
                'End If
                ObjVehicleDistributionPPT.psCOAID = objDR("COAKey")

                Select Case (txtUOM.Text.Trim)
                    Case "Hrs"
                        ObjVehicleDistributionPPT.pdKmHours = objDR("KmHours")
                    Case "Kms"
                        ObjVehicleDistributionPPT.pdKmHours = objDR("KmHours")
                End Select

                If (objDR("BalanceToDistribute")) Is DBNull.Value Then
                    ObjVehicleDistributionPPT.pdBalanceToDistribute = Nothing
                Else

                    ObjVehicleDistributionPPT.pdBalanceToDistribute = objDR("BalanceToDistribute")

                End If

                If objDR("PrestasiTonBunchesKm") Is DBNull.Value Then
                    ObjVehicleDistributionPPT.pdPrestasiTonBunchesKm = 0D
                Else
                    ObjVehicleDistributionPPT.pdPrestasiTonBunchesKm = Convert.ToDecimal(objDR("PrestasiTonBunchesKm"))
                End If

                ObjVehicleDistributionPPT.psDivID = GetDataValue(objDR("DivKey"))
                ObjVehicleDistributionPPT.psBlockID = GetDataValue(objDR("BlockKey"))
                ObjVehicleDistributionPPT.psYOPID = GetDataValue(objDR("YOPKey"))
                ObjVehicleDistributionPPT.psT0 = GetDataValue(objDR("T0"))
                ObjVehicleDistributionPPT.psT1 = GetDataValue(objDR("T1"))
                ObjVehicleDistributionPPT.psT2 = GetDataValue(objDR("T2"))
                ObjVehicleDistributionPPT.psT3 = GetDataValue(objDR("T3"))
                ObjVehicleDistributionPPT.psT4 = GetDataValue(objDR("T4"))
                ObjVehicleDistributionPPT.psRemarks = GetDataValue(objDR("Remarks"))

                ObjVehicleDistributionPPT.psVHDistributionID = GetDataValue(objDR("VHDistributionID"))

                'ObjVehicleDistributionPPT.psCreatedBy = GlobalPPT.strUserName

                '0=No, 1= Add, 2=Update, 3=Delete

                liOperationFlag = IIf(objDR("Action") Is DBNull.Value, 0, objDR("Action"))

                If liOperationFlag = 1 Then
                    rowsAffected = ObjVehicleDistributionBOL.SaveVehicleDistribution(ObjVehicleDistributionPPT)
                ElseIf liOperationFlag = 2 And objDR("Id") IsNot DBNull.Value Then
                    ObjVehicleDistributionPPT.piId = Convert.ToInt32(objDR("Id"))
                    rowsAffected = ObjVehicleDistributionBOL.UpdateVehicleDistribution(ObjVehicleDistributionPPT)
                ElseIf liOperationFlag = 3 And objDR("Id") IsNot DBNull.Value Then
                    ObjVehicleDistributionPPT.piId = Convert.ToInt32(objDR("Id"))
                    rowsAffected = ObjVehicleDistributionBOL.DeleteVehicleDistribution(ObjVehicleDistributionPPT)

                    'General.ShowMessageFromDataBase(ObjVehicleDistributionBOL.DeleteVehicleDistribution(ObjVehicleDistributionPPT))
                End If
            Next

            If rowsAffected <> 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                If rowsAffected = 1 Then
                    'MsgBox(rm.GetString("SaveMsg"), MsgBoxStyle.OkOnly, "Information")
                    DisplayInfoMessage("SaveMsg")
                ElseIf rowsAffected = 2 Then
                    DisplayInfoMessage("UpdateMsg")
                    'MsgBox(rm.GetString("UpdateMsg"), MsgBoxStyle.OkOnly, "Information")
                ElseIf rowsAffected = 3 Then
                    DisplayInfoMessage("DeleteMsg")
                End If

                ResetTop()
                ResetMainControls()
                ResetRequiredControls()
                ResetControls()
                saveBool = False
                btnSaveAll.Enabled = False
                liIsTableAltered = False
            Else
                MessageBox.Show("Process failed", " Error in process ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return

            End If

        End If
        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        Me.Close()
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        SaveAllData()
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ResetTop()
        ResetMainControls()
        ResetRequiredControls()
        ResetControls()
        btnSaveAll.Enabled = False
        liIsTableAltered = False

        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dgVehicleLog_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgVehicleLog.CellFormatting
        'If e.ColumnIndex = dgVehicleLog.Columns("Action").Index Then

        '    Dim row As DataGridViewRow = dgVehicleLog.Rows(e.RowIndex)

        '    If Convert.ToString(row.Cells("Action").Value).Trim = "3" And Convert.ToString(row.Cells("Id").Value).Trim() <> String.Empty Then
        '        dgVehicleLog.Rows(e.RowIndex).Visible = False
        '    End If

        'End If

        If e.ColumnIndex = dgVehicleLog.Columns("KmHours").Index Then
            e.FormattingApplied = True
            Dim row As DataGridViewRow = dgVehicleLog.Rows(e.RowIndex)
            Select Case (lsUOM)
                Case "Hrs"
                    e.Value = row.Cells("KmHours").Value.ToString.Replace(".", ":")
                Case "Kms"
                    e.Value = row.Cells("KmHours").Value.ToString
            End Select

        End If

    End Sub

    Private Sub dgVehicleLog_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVehicleLog.KeyDown

        If dgVehicleLog.RowCount > 0 Then
            If dgVehicleLog.CurrentRow.Index >= 0 And dgVehicleLog.CurrentCell.ColumnIndex >= 0 And dgVehicleLog.CurrentRow.Selected Then
                If e.KeyCode = 13 Then
                    e.Handled = True
                    If dgVehicleLog.CurrentRow.Cells("ID").Value Is DBNull.Value Then
                        lsGUIDForRecordEdit = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DTId")
                        liIdForRecordEdit = 0
                    Else
                        liIdForRecordEdit = DirectCast(dgVehicleLog.CurrentRow.Cells("ID").Value, Integer)
                    End If

                    If Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Then

                        ShowVehicleDistributionDetailsByID()

                        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                        'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                        DisplayInfoMessage("MsgPosted")

                        'btnAdd.Enabled = False
                        ''pnlEntry.Enabled = False
                        ''btnAdd.Enabled = False
                        'btnResetMultipleEntryGrp.Enabled = False
                        'btnSaveAll.Enabled = False

                        Return
                    Else

                        ResetRequiredControls()
                        ResetControls()

                        ShowVehicleDistributionDetailsByID()

                        'btnAdd.Text = "Update"
                        If GlobalPPT.strLang = "en" Then
                            btnAdd.Text = "Update"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnAdd.Text = "Memperbarui"
                        End If
                        btnAdd.Enabled = True
                        btnResetMultipleEntryGrp.Enabled = True
                        btnSaveAll.Enabled = False
                        dtpDate.Enabled = False
                        txtVehicleCode.Enabled = False
                        ibtnSearchVehicleCode.Enabled = False

                    End If

                    'If tbcVehicleDistribution.TabPages.Contains(tbpgViewVRB) = False Then
                    '    pnlEntry.Enabled = False
                    '    Me.txtVehicleCode.Text = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("VHWSCode")
                    'End If

                    If liIsTableAltered = True Then
                        btnSaveAll.Enabled = True
                    End If

                    If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub dgVehicleLog_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVehicleLog.MouseClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgVehicleLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgVehicleLog.RowCount > 0 Then

            If e.Button = MouseButtons.Right Then

                ' Load context menu on right mouse click
                If dgVehicleLog.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then

                    'tspDelete.Visible = False
                    'tspAdd.Visible = False
                    'tspEdit.Visible = True

                    Dim ldRect As Rectangle
                    Dim lpPosCell As Point

                    ldRect = dgVehicleLog.GetCellDisplayRectangle(dgVehicleLog.CurrentCell.ColumnIndex, dgVehicleLog.CurrentRow.Index, True)
                    lpPosCell = CType(ldRect.Location, Point)
                    Me.cmsEntry.Show(dgVehicleLog, lpPosCell)

                End If
            End If
        Else
            tspEditEntry.Visible = True
            tsmAddEntry.Visible = False
            tspDeleteEntry.Visible = False
            cmsEntry.Hide()
        End If

    End Sub

    Private Sub dgVehicleLog_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVehicleLog.MouseDoubleClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgVehicleLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgVehicleLog.CurrentRow.Index >= 0 And dgVehicleLog.CurrentCell.ColumnIndex >= 0 Then
            If e.Button = MouseButtons.Left Then

                If Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Then ' Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False) Then 'pnlEntry.Enabled = False Then

                    ShowVehicleDistributionDetailsByID()

                    'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                    'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                    DisplayInfoMessage("MsgPosted")

                    'btnAdd.Enabled = False
                    'pnlEntry.Enabled = False

                    Return
                End If

                ResetRequiredControls()
                ResetControls()

                If dgVehicleLog.CurrentRow.Cells("ID").Value Is DBNull.Value Then
                    lsGUIDForRecordEdit = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DTId")
                    liIdForRecordEdit = 0
                Else
                    liIdForRecordEdit = DirectCast(dgVehicleLog.CurrentRow.Cells("ID").Value, Integer)
                End If


                If Not (Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False)) Then ' pnlEntry.Enabled = False) Then
                    'CalculateTotalKmsDistributedNBalance()
                    'ShowVehicleDistributionDetailsByID()

                    'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                    'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")

                    'btnAdd.Enabled = False
                    'pnlEntry.Enabled = False
                    'MsgBox("This record was posted. Hence cannot be edited.", MsgBoxStyle.OkOnly, "Information")

                    '    Return
                    'Else
                    ldCurrentBalanceToDistribute = 0
                    ldCurrentTotalKmDistributed = 0
                    ShowVehicleDistributionDetailsByID()

                    '
                    btnAdd.Text = "Update"
                    If GlobalPPT.strLang = "en" Then
                        btnAdd.Text = "Update"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnAdd.Text = "Memperbarui"
                    End If
                    btnAdd.Enabled = True
                    btnResetMultipleEntryGrp.Enabled = True
                    btnSaveAll.Enabled = False
                    btnAdd.Enabled = True

                    dtpDate.Enabled = False
                    txtVehicleCode.Enabled = False
                    ibtnSearchVehicleCode.Enabled = False
                End If

                'If tbcVehicleDistribution.TabPages.Contains(tbpgViewVRB) = False Then
                '    pnlEntry.Enabled = False
                'End If

                If liIsTableAltered = True Then
                    btnSaveAll.Enabled = True
                End If



                If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If

                Dim mdiparent As New MDIParent
                If mdiparent.strMenuID = "M74" Then
                    btnAdd.Enabled = False
                    btnResetAll.Enabled = False
                    btnResetMultipleEntryGrp.Enabled = False

                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

#Region "ContextMenuStripEntry"

    Private Sub tsmEntryAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAddEntry.Click
        'If Not objUserLoginBOl.Privilege(btnAdd, tsmAddEntry, tspEditEntry, tspDeleteEntry, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        If dgVehicleLog.CurrentRow.Index >= 0 And dgVehicleLog.CurrentCell.ColumnIndex >= 0 Then
            If Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Then 'Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False) Then ' pnlEntry.Enabled = False Then
                'ShowVehicleDistributionDetailsByID()
                btnAdd.Enabled = False
                DisplayInfoMessage("MsgPosted")
                Return
            Else
                Me.ResetRequiredControls()
                Me.ResetControls()

                If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If
            End If
        End If


        'If dgVehicleLog.CurrentRow IsNot Nothing Then
        '    If dgVehicleLog.CurrentRow.Index >= 0 And dgVehicleLog.CurrentCell.ColumnIndex >= 0 And dgVehicleLog.CurrentRow.Selected Then

        '        If (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False) Or pnlEntry.Enabled = False Then
        '            Return
        '        End If

        '        Me.ResetRequiredControls()
        '        Me.ResetControls()

        '        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
        '            MsgBox(PrivilegeError)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspEditEntry.Click


        If dgVehicleLog.CurrentRow.Index >= 0 And dgVehicleLog.CurrentCell.ColumnIndex >= 0 Then

            'If pnlEntry.Enabled = False Then
            '    Return
            'End If

            If Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Then 'Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False) Then ' pnlEntry.Enabled = False Then

                ShowVehicleDistributionDetailsByID()

                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                DisplayInfoMessage("MsgPosted")

                'btnAdd.Enabled = False
                'pnlEntry.Enabled = False

                Return
            End If

            ResetRequiredControls()
            ResetControls()

            If dgVehicleLog.CurrentRow.Cells("ID").Value Is DBNull.Value Then
                lsGUIDForRecordEdit = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DTId")
                liIdForRecordEdit = 0
            Else
                liIdForRecordEdit = DirectCast(dgVehicleLog.CurrentRow.Cells("ID").Value, Integer)
            End If


            If Not (Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False)) Then 'pnlEntry.Enabled = False) Then
                'CalculateTotalKmsDistributedNBalance()
                '    ShowVehicleDistributionDetailsByID()

                '    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                '    MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")

                '    btnAdd.Enabled = False
                '    pnlEntry.Enabled = False
                '    'MsgBox("This record was posted. Hence cannot be edited.", MsgBoxStyle.OkOnly, "Information")

                '    Return
                'Else
                ldCurrentBalanceToDistribute = 0
                ldCurrentTotalKmDistributed = 0
                ShowVehicleDistributionDetailsByID()

                btnAdd.Text = "Update"
                btnAdd.Enabled = True
                btnResetMultipleEntryGrp.Enabled = True
                btnAdd.Enabled = True
                btnSaveAll.Enabled = False

                dtpDate.Enabled = False
                txtVehicleCode.Enabled = False
                ibtnSearchVehicleCode.Enabled = False
            End If

            'If tbcVehicleDistribution.TabPages.Contains(tbpgViewVRB) = False Then
            '    pnlEntry.Enabled = False
            'End If

            If liIsTableAltered = True Then
                btnSaveAll.Enabled = True
            End If

            If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        End If
    End Sub

    Private Sub tspDeleteEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspDeleteEntry.Click

        If dgVehicleLog.CurrentRow.Index >= 0 And dgVehicleLog.CurrentCell.ColumnIndex >= 0 Then

            'If pnlEntry.Enabled = False Then
            '    Return
            'End If

            If Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Then 'Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False) Then ' pnlEntry.Enabled = False Then
                'ShowVehicleDistributionDetailsByID()
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                DisplayInfoMessage("MsgPosted")
                'btnAdd.Enabled = False
                'pnlEntry.Enabled = False
                Return
            End If
            ResetRequiredControls()
            ResetControls()

            liIdForRecordEdit = 0

            If dgVehicleLog.CurrentRow.Cells("ID").Value Is DBNull.Value Then
                lsGUIDForRecordEdit = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DTId")
                liIdForRecordDelete = 0
            Else
                liIdForRecordDelete = DirectCast(dgVehicleLog.CurrentRow.Cells("ID").Value, Integer)
            End If



            If Not (Convert.ToString(dgVehicleLog.CurrentRow.Cells("Posted").Value).Trim().Equals("Y") Or (btnAdd.Enabled = False And btnResetMultipleEntryGrp.Enabled = False)) Then 'pnlEntry.Enabled = False) Then
                'CalculateTotalKmsDistributedNBalance()
                '    ShowVehicleDistributionDetailsByID()

                '    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                '    MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")

                '    btnAdd.Enabled = False
                '    pnlEntry.Enabled = False
                '    'MsgBox("This record was posted. Hence cannot be edited.", MsgBoxStyle.OkOnly, "Information")

                '    Return
                'Else
                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                If MsgBox(rm.GetString("lblDeletePrompt"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If

                If liIdForRecordDelete = 0 Then
                    DeleteTemp(lsGUIDForRecordEdit)
                Else
                    UpdateTemp(String.Empty)
                    Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                End If


                'If dtVDTempDataTable.Rows.Count > 0 Then
                '    'Dim UpdateRow As DataRow()
                '    'Dim lsRowGuid As Integer
                '    'lsRowGuid = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DTId")
                '    'If lsRowGuid <> String.Empty Then
                '    '    UpdateRow = dtVDTempDataTable.Select("DTId = '" & lsRowGuid & "'")
                '    '    If UpdateRow.Count > 0 Then
                '    '    Else
                '    '        Return
                '    '    End If

                '    'End If
                '    If dgVehicleLog.Rows(dgVehicleLog.CurrentCell.RowIndex).Cells("ID").Value Is System.DBNull.Value Then
                '        dgVehicleLog.Rows.RemoveAt(dgVehicleLog.CurrentCell.RowIndex)
                '    Else

                '        dtVDTempDataTable.Rows(dgVehicleLog.CurrentCell.RowIndex).Delete()
                '        dtVDTempDataTable.AcceptChanges()

                '    End If
                'End If



                'If liIdForRecordDelete = 0 Then
                '    'DeleteTemp(lsGUIDForRecordEdit)
                'Else
                '    UpdateTemp(String.Empty)
                '    Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                'End If

                CalculateTotalKmsDistributedNBalance()

                Dim lsKmHrs As String = "0.00"

                Select Case (txtUOM.Text.Trim)
                    Case "Hrs"
                        Dim ldTimeDt As DateTime = General.GetTimeFormation(lsKmHrs.Replace(".", ":")) 'DateTime.ParseExact(Me.dsVehicleLogDetails.Tables(0).Rows(0)(0).ToString().Substring(0, 5), "HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("HH:mm")
                        lsKmHrs = ldTimeDt.ToString("HH:mm") 'ldTimeDt.Hour.ToString("00") + "." + ldTimeDt.Minute.ToString("00")




                        Dim diffSec As Integer = Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed)) - Convert.ToDecimal(StringToSec(lsKmHrs.Trim.Replace(":", ".")))
                        Dim ldTotalHrsDistributedDT As String = SecToTime(diffSec)
                        Me.txtTotalKmDistributed.Text = ldTotalHrsDistributedDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))

                        Dim diffSec1 As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim.Replace(":", "."))) - Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed))
                        Dim ldBalanceToDistributeDT As String = SecToTime(diffSec1)

                        If ldBalanceToDistributeDT.StartsWith("-") Then
                            Me.txtBalanceToDistribute.Text = "00:00"
                        Else
                            Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString
                        End If

                        'Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Replace(":", "."))


                        'Dim ldTotalHrsDistributedDT As TimeSpan = GetInTimeValue(ldCurrentTotalKmDistributed) - GetInTimeValue(lsKmHrs.Trim.Replace(":", ".")) 'GetInTimeValue(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem)
                        ' Me.txtTotalKmDistributed.Text = ldTotalHrsDistributedDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsDistributedDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) - Convert.ToDecimal(Me.lsKmHrs.Trim)
                        ' ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")) 'Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) - Convert.ToDecimal(Me.lsKmHrs.Trim)

                        'Dim ldBalanceToDistributeDT As TimeSpan = GetInTimeValue(txtTotalRunningKm.Text.Trim.Replace(":", ".")) - GetInTimeValue(ldCurrentTotalKmDistributed) 'GetInTimeValue(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem)
                        'Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldBalanceToDistributeDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim) + Convert.ToDecimal(Me.lsKmHrs.Trim)

                        'ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Replace(":", ".")) 'Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim) + Convert.ToDecimal(Me.lsKmHrs.Trim)
                        ''lblHrsFormat.Visible = True
                    Case "Kms"
                        lsKmHrs = lsKmHrs.ToString 'Me.dsVehicleLogDetails.Tables(0).Rows(0)(0).ToString
                        Me.txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed - Convert.ToDecimal(lsKmHrs)
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text)
                        Me.txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text)
                        'lblHrsFormat.Visible = False
                End Select

                'ldCurrentBalanceToDistribute = 0
                'ldCurrentTotalKmDistributed = 0
                'ShowVehicleDistributionDetailsByID()

                btnAdd.Text = "Add"
                btnAdd.Enabled = True
                btnResetMultipleEntryGrp.Enabled = True
                btnSaveAll.Enabled = True

                dtpDate.Enabled = False
                txtVehicleCode.Enabled = False
                ibtnSearchVehicleCode.Enabled = False
            End If

            'If tbcVehicleDistribution.TabPages.Contains(tbpgViewVRB) = False Then
            '    pnlEntry.Enabled = False
            'End If

            If liIsTableAltered = True Then
                btnSaveAll.Enabled = True
            End If

        End If
    End Sub

#End Region

#End Region

#Region "View Tab"

    Private Sub chkVDDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVDDate.CheckedChanged
        If chkVDDate.Checked Then
            dtpSearchBydate.Enabled = True
        Else
            dtpSearchBydate.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If CheckRequiredFieldsOfVehicleSearch() Then
            BindVehicleCode(Me.txtVehicleSearch.Text.Trim, "Go")
        Else
            BindVehicleCode(String.Empty, String.Empty)
            Me.ResetViewArea()
        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        'Dim ObjRecordExist As New Object
        'Dim ObjVehicleDistributionPPT As New VehicleDistributionPPT
        'Dim ObjVehicleDistributionBOL As New VehicleDistributionBOL
        'ObjRecordExist = ObjVehicleDistributionBOL.VHDistributionRecordIsExist(ObjVehicleDistributionPPT)

        'If ObjRecordExist = 0 Then
        '    MsgBox("No Records Available!")
        'Else

        Dim childCR As New VehicleProofListReport
        childCR.strReportName = "VehicleDistributionRpt"
        childCR.ShowDialog()

        'VehicleDistributionRpt.ShowDialog()

        'End If
    End Sub

    Private Sub dgVehicle_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgVehicle.CellFormatting

        If e.ColumnIndex = dgVehicle.Columns("VDPosted").Index Then
            e.FormattingApplied = True
            Dim row As DataGridViewRow = dgVehicle.Rows(e.RowIndex)
            Select Case (e.Value.ToString().Trim())
                Case "Y"
                    e.Value = "Yes"
                Case "N"
                    e.Value = "No"
            End Select

        End If

    End Sub

    Private Sub dgVehicle_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVehicle.MouseClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgVehicle.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgVehicle.RowCount > 0 Then
            ' Load context menu on right mouse click
            If e.Button = MouseButtons.Right Then

                'tspEdit.Visible = False
                'tspAdd.Visible = True
                'tspDelete.Visible = True

                If dgVehicle.CurrentRow.Selected = True Then



                    Dim ldRect As Rectangle
                    Dim lpPosCell As Point

                    ldRect = dgVehicle.GetCellDisplayRectangle(dgVehicle.CurrentCell.ColumnIndex, dgVehicle.CurrentRow.Index, True)
                    lpPosCell = CType(ldRect.Location, Point)
                    Me.cmsView.Show(dgVehicle, lpPosCell)


                End If
            End If
        Else
            tspEditEntry.Visible = False
            tsmAddEntry.Visible = True
            tspDeleteEntry.Visible = True
            cmsEntry.Hide()
        End If
    End Sub

    Private Sub dgVehicle_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVehicle.MouseDoubleClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgVehicle.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgVehicle.CurrentRow IsNot Nothing Then
            If dgVehicle.CurrentRow.Index >= 0 And dgVehicle.CurrentCell.ColumnIndex >= 0 And dgVehicle.CurrentRow.Selected Then
                Me.ResetRequiredControls()
                Me.ResetControls()

                If Convert.ToString(dgVehicle.CurrentRow.Cells("VDPosted").Value).Trim().Equals("Y") Then
                    'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                    'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                    DisplayInfoMessage("MsgPosted")
                    'pnlEntry.Enabled = False
                    btnAdd.Enabled = False
                    'btnResetMultipleEntryGrp.Enabled = False
                Else
                    'pnlEntry.Enabled = True
                    btnAdd.Enabled = True
                    If Not objUserLoginBOl.Privilege(btnAdd, tsmAddEntry, tspEditEntry, tspDeleteEntry, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If

                    'btnResetMultipleEntryGrp.Enabled = True
                End If

                'Me.BindVehicleDistributionByVehicleCode(String.Empty, New DateTime(1900, 1, 1))
                Me.txtVehicleCode.Text = dgVehicle.CurrentRow.Cells("VHWSCode").Value
                Me.dtpDate.Text = dgVehicle.CurrentRow.Cells("VDDate").Value
                dtVDTempDataTable.Rows.Clear()
                Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                Me.tbcVehicleDistribution.SelectTab(0)


            End If
        End If
    End Sub

    Private Sub dgVehicle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVehicle.KeyDown
        If dgVehicle.RowCount > 0 Then
            If dgVehicle.CurrentRow IsNot Nothing And dgVehicle.CurrentRow.Selected Then
                If dgVehicle.CurrentRow.Index >= 0 And dgVehicle.CurrentCell.ColumnIndex >= 0 Then
                    If e.KeyCode = 13 Then
                        e.Handled = True

                        Me.ResetRequiredControls()
                        Me.ResetControls()

                        If Convert.ToString(dgVehicle.CurrentRow.Cells("VDPosted").Value).Trim().Equals("Y") Then
                            'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                            'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                            DisplayInfoMessage("MsgPosted")
                            'pnlEntry.Enabled = False
                            btnAdd.Enabled = False
                            'btnResetMultipleEntryGrp.Enabled = False
                        Else
                            'pnlEntry.Enabled = True
                            btnAdd.Enabled = True
                            ' btnResetMultipleEntryGrp.Enabled = True

                        End If

                        'Me.btnAdd.Text = "Add"

                        'Me.BindVehicleDistributionByVehicleCode(String.Empty, New DateTime(1900, 1, 1))

                        Me.txtVehicleCode.Text = dgVehicle.CurrentRow.Cells("VHWSCode").Value
                        Me.dtpDate.Text = dgVehicle.CurrentRow.Cells("VDDate").Value
                        dtVDTempDataTable.Rows.Clear()
                        Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                        Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                        Me.tbcVehicleDistribution.SelectTab(0)

                        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                            MsgBox(PrivilegeError)
                        End If

                    End If
                End If
            End If
        End If
    End Sub

#Region "ContextMenuStripView"

    Private Sub tmsViewAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tspAddView.Click
        If Not objUserLoginBOl.Privilege(btnAdd, tsmAddEntry, tspEditEntry, tspDeleteEntry, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        tbcVehicleDistribution.SelectedTab = tbpgAdd

        If dgVehicle.CurrentRow IsNot Nothing Then
            If dgVehicle.CurrentRow.Index >= 0 And dgVehicle.CurrentCell.ColumnIndex >= 0 And dgVehicle.CurrentRow.Selected Then
                Me.ResetRequiredControls()
                Me.ResetControls()
                Me.ResetMainControls()
                Me.tbcVehicleDistribution.SelectTab(0)
            End If
        End If

    End Sub

    Private Sub tmsViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsEditView.Click
        If Not objUserLoginBOl.Privilege(btnAdd, tsmAddEntry, tspEditEntry, tspDeleteEntry, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        If dgVehicle.CurrentRow IsNot Nothing Then
            If dgVehicle.CurrentRow.Index >= 0 And dgVehicle.CurrentCell.ColumnIndex >= 0 And dgVehicle.CurrentRow.Selected Then
                Me.ResetRequiredControls()
                Me.ResetControls()
                If Convert.ToString(dgVehicle.CurrentRow.Cells("VDPosted").Value).Trim().Equals("Y") Then
                    'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                    'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                    DisplayInfoMessage("MsgPosted")
                    'pnlEntry.Enabled = False
                    btnAdd.Enabled = False
                    'btnResetMultipleEntryGrp.Enabled = False
                Else
                    'pnlEntry.Enabled = True
                    btnAdd.Enabled = True
                    'btnResetMultipleEntryGrp.Enabled = True

                End If
                'Me.BindVehicleDistributionByVehicleCode(String.Empty, New DateTime(1900, 1, 1))
                Me.txtVehicleCode.Text = dgVehicle.CurrentRow.Cells("VHWSCode").Value
                Me.dtpDate.Text = dgVehicle.CurrentRow.Cells("VDDate").Value
                Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                Me.tbcVehicleDistribution.SelectTab(0)

                If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If

            End If
        End If
    End Sub

    Private Sub tmsDeleteView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsDeleteView.Click
        If Not objUserLoginBOl.Privilege(btnAdd, tsmAddEntry, tspEditEntry, tspDeleteEntry, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
        If dgVehicle.Rows.Count > 0 Then
            If Convert.ToString(dgVehicle.CurrentRow.Cells("VDPosted").Value).Trim().Equals("Y") Then
                'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
                DisplayInfoMessage("MsgPosted")
                Return
            Else
                If MsgBox(rm.GetString("lblDeletePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ObjVehicleDistributionPPT = New VehicleDistributionPPT
                    ObjVehicleDistributionBOL = New VehicleDistributionBOL

                    ObjVehicleDistributionPPT.psVHID = DirectCast(dgVehicle.CurrentRow.Cells("VHKey").Value, String)
                    ObjVehicleDistributionPPT.pdDistributionDT = DirectCast(dgVehicle.CurrentRow.Cells("VDDate").Value, DateTime)

                    General.ShowMessageFromDataBase(ObjVehicleDistributionBOL.DeleteVehicleDistributionFrmView(ObjVehicleDistributionPPT))

                    BindVehicleCode(String.Empty, String.Empty)
                    dgVehicle.ClearSelection()

                    'Me.txtVehicleCode.Text = dgVehicle.CurrentRow.Cells("VHWSCode").Value
                    'Me.dtpDate.Text = dgVehicle.CurrentRow.Cells("VDDate").Value
                    'Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                    'Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                    'Me.tbcVehicleDistribution.SelectTab(0)

                End If
            End If
        Else
            'MsgBox(rm.GetString("NoDelete"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            DisplayInfoMessage("NoDelete")
        End If
        'DefaultPopup()
        'DeleteVehicleDistribution()
    End Sub

    'Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
    '    If dgVehicle.Rows.Count > 0 Then
    '        If Convert.ToString(dgVehicle.CurrentRow.Cells("VDPosted").Value).Trim().Equals("Y") Then
    '            'MsgBox(rm.GetString("MsgPosted"), MsgBoxStyle.OkOnly, "Information")
    '            DisplayInfoMessage("MsgPosted")
    '            Return
    '        Else
    '            If MsgBox(rm.GetString("lblDeletePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '                'ObjVehicleDistributionPPT = New VehicleDistributionPPT
    '                'ObjVehicleDistributionBOL = New VehicleDistributionBOL

    '                'ObjVehicleDistributionPPT.psVHID = DirectCast(dgVehicle.CurrentRow.Cells("VHKey").Value, String)
    '                'ObjVehicleDistributionPPT.pdDistributionDT = DirectCast(dgVehicle.CurrentRow.Cells("VDDate").Value, DateTime)

    '                'General.ShowMessageFromDataBase(ObjVehicleDistributionBOL.DeleteVehicleDistribution(ObjVehicleDistributionPPT))

    '                'BindVehicleCode(String.Empty, String.Empty)
    '                'dgVehicle.ClearSelection()

    '                Me.txtVehicleCode.Text = dgVehicle.CurrentRow.Cells("VHWSCode").Value
    '                Me.dtpDate.Text = dgVehicle.CurrentRow.Cells("VDDate").Value
    '                Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
    '                Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
    '                Me.tbcVehicleDistribution.SelectTab(0)

    '            End If
    '        End If
    '    Else
    '        'MsgBox(rm.GetString("NoDelete"), MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        DisplayInfoMessage("NoDelete")
    '    End If
    '    'DefaultPopup()
    '    'DeleteVehicleDistribution()
    'End Sub

#End Region

#End Region

#End Region

#Region "Functions"

    Private Sub BindVehicleCode(ByVal lsVehicleCode As String, ByVal lsSender As String)
        ObjVehicleDistributionPPT = New VehicleDistributionPPT
        ObjVehicleDistributionBOL = New VehicleDistributionBOL

        If chkVDDate.Checked Then
            ObjVehicleDistributionPPT.psSearchBy = "SearchByDate"
            ObjVehicleDistributionPPT.pdDistributionDT = New Date(Me.dtpSearchBydate.Value.Year, Me.dtpSearchBydate.Value.Month, Me.dtpSearchBydate.Value.Day)
        Else
            ObjVehicleDistributionPPT.pdDistributionDT = New DateTime(1900, 1, 1) 'New DateTime(1900, 1, 1)
        End If


        ObjVehicleDistributionPPT.psVHID = txtVehicleSearch.Text.Trim
        ObjVehicleDistributionPPT.psVehicleName = txtSearchVehicleName.Text.Trim
        ObjVehicleDistributionPPT.psVHModel = txtSearchVehicleModel.Text.Trim

        Dim ObjVehicleDistributionCollection As New DataSet

        ObjVehicleDistributionCollection = ObjVehicleDistributionBOL.GetVehicleCode(ObjVehicleDistributionPPT)

        With Me.dgVehicle
            .AutoGenerateColumns = False
            .DataSource = ObjVehicleDistributionCollection.Tables(0)

            .ClearSelection()
        End With

        If (ObjVehicleDistributionCollection Is Nothing Or ObjVehicleDistributionCollection.Tables(0).Rows.Count = 0) And lsSender <> String.Empty Then

            'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

            'MsgBox(rm.GetString("MsgNoRecords"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgNoRecords")

            'Me.ResetViewArea()

        End If
    End Sub

    Public Sub BindVehicleDistributionByVehicleCode(ByVal lsVehicleCode As String, ByVal ldDistributionDT As DateTime)

        ObjVehicleDistributionPPT = New VehicleDistributionPPT()
        ObjVehicleDistributionBOL = New VehicleDistributionBOL
        'dsVehicleCode = New DataSet()

        ObjVehicleDistributionPPT.psVHID = lsVehicleCode
        'ObjVehicleDistributionPPT.psEstateID = GlobalPPT.strEstateID
        'ObjVehicleDistributionPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
        ObjVehicleDistributionPPT.pdDistributionDT = ldDistributionDT

        Dim ObjVehicleDistributionCollection As DataSet
        ObjVehicleDistributionCollection = ObjVehicleDistributionBOL.GetVehicleDistribution(ObjVehicleDistributionPPT)

        Dim ObjVehicleDistributionCollection0 As New DataTable
        ObjVehicleDistributionCollection0 = ObjVehicleDistributionCollection.Tables(0)

        'Dim ObjVehicleDistributionCollection1 As New DataTable
        'ObjVehicleDistributionCollection1 = ObjVehicleDistributionCollection.Tables(1)

        If ObjVehicleDistributionCollection0.Rows.Count > 0 Then
            txtUOM.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("UOM"))
            lsUOM = txtUOM.Text.Trim

            ConvertKmsToHrsText(Me.txtUOM.Text)
            Me.txtVehicleCode.Text = lsVehicleCode
            Me.txtVehicleName.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("Category"))
            Me.txtVehicleModel.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("VHModel"))
            Me.txtVehicleRegNo.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("RegNo"))
            lsVHID = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("VHID"))

        End If

        'For Each dr As DataRow In ObjVehicleDistributionCollection.Tables(1).Rows
        '    If dr("Posted").ToString.Trim = "Y" Then
        '        'pnlEntry.Enabled = False
        '        btnAdd.Enabled = False
        '        btnResetMultipleEntryGrp.Enabled = False
        '        'Return
        '    End If
        'Next
        'If ObjVehicleDistributionCollection1.Rows.Count > 0 Then
        '    lsVHDisID = Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("VHDistributionID"))
        'End If
        If dtVDTempDataTable.Rows.Count = 0 Then

            dtVDTempDataTable.Merge(ObjVehicleDistributionCollection.Tables(1))

            With Me.dgVehicleLog
                .AutoGenerateColumns = False
                Try
                    .DataSource = dtVDTempDataTable
                Catch ex As Exception

                End Try
                .ClearSelection()
            End With

        Else

            With Me.dgVehicleLog
                .AutoGenerateColumns = False
                .DataSource = dtVDTempDataTable
                .ClearSelection()
            End With

            'Dim cm As CurrencyManager = DirectCast(BindingContext(dgVehicleLog.DataSource), CurrencyManager)

            For Each dgvr As DataGridViewRow In dgVehicleLog.Rows
                If Convert.ToString(dgvr.Cells("Action").Value).Trim = "3" And Convert.ToString(dgvr.Cells("Id").Value).Trim() <> String.Empty Then
                    'cm.SuspendBinding()
                    'dgvr.Visible = False
                    'Dim band As DataGridViewBand = dgvr
                    'band.Visible = False

                    Me.dgVehicleLog.CurrentCell = Nothing

                    dgvr.Visible = False

                End If
            Next

            'Dim dv As New DataView(dtVDTempDataTable, "Action = 3", Nothing, DataViewRowState.CurrentRows)
            'With Me.dgVehicleLog
            '    .AutoGenerateColumns = False
            '    .DataSource = dv
            '    .ClearSelection()
            'End With

        End If


    End Sub
    Private Sub txtStartHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartHrs.Leave
        If txtStartHrs.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^[0-9]+$")
            If Not rtime.IsMatch(txtStartHrs.Text.Trim) Then
                DisplayInfoMessage("IStartHrs")
                txtStartHrs.Focus()
            End If
        End If


        If txtStartHrs.Text.Trim <> String.Empty And txtStartMin.Text.Trim <> String.Empty Then
            lsStartTime = String.Format("{0:00}", Convert.ToInt32(txtStartHrs.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtStartMin.Text.Trim))
            CalculateMeridianAndTotalHrs()
        Else
            lsStartTime = String.Empty
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

        If txtStartHrs.Text.Trim <> String.Empty And txtStartMin.Text.Trim <> String.Empty Then
            lsStartTime = String.Format("{0:00}", Convert.ToInt32(txtStartHrs.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtStartMin.Text.Trim))
            CalculateMeridianAndTotalHrs()
        Else
            lsStartTime = String.Empty
        End If
    End Sub
    'Private Sub cmbStartHrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbStartHrs.SelectedIndex >= 0 And cmbStartMin.SelectedIndex >= 0 Then
    '        lsStartTime = String.Format("{0:00}", Convert.ToInt32(cmbStartHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbStartMin.Text))
    '        CalculateMeridianAndTotalHrs()
    '    Else
    '        lsStartTime = String.Empty
    '    End If


    '    If lsStartTime <> String.Empty Then

    '    End If

    'End Sub

    'Private Sub cmbStartMin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbStartHrs.SelectedIndex >= 0 And cmbStartMin.SelectedIndex >= 0 Then
    '        lsStartTime = String.Format("{0:00}", Convert.ToInt32(cmbStartHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbStartMin.Text))
    '        CalculateMeridianAndTotalHrs()
    '    Else
    '        lsStartTime = String.Empty
    '    End If
    'End Sub

    Private Sub CalculateMeridianAndTotalHrs()
        If lsStartTime <> String.Empty Then
            Dim h() As String = lsStartTime.Split(":")
            Dim ts As New TimeSpan(h(0), h(1), 0)

            If Convert.ToInt32(h(0)) >= 12 Then
                txtShift.Text = "Afternoon"
            Else
                txtShift.Text = "Morning"
            End If

            txtKm.Text = lsStartTime.Trim
            'Dim tsStart As New TimeSpan(h(0), h(1), 0)

            ''h = lsEndTime.Split(":")

            'Dim tsEnd As New TimeSpan(h(0), h(1), 0)
            'Dim lsTempTotTime = tsEnd.Subtract(tsStart).ToString()


        End If
    End Sub

    Public Sub AssignDistributionValuesForVehicleCode(ByVal lsVehicleCode As String, ByVal ldDistributedDateDT As DateTime)

        ObjVehicleDistributionPPT = New VehicleDistributionPPT()
        ObjVehicleDistributionBOL = New VehicleDistributionBOL

        ObjVehicleDistributionPPT.psVHID = lsVehicleCode
        ObjVehicleDistributionPPT.pdDistributionDT = ldDistributedDateDT
        'ObjVehicleDistributionPPT.psEstateID = GlobalPPT.strEstateID
        'ObjVehicleDistributionPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        Dim ObjVehicleDistributionCollectionList As New DataSet ''List(Of VehicleDistributionCollection)

        ObjVehicleDistributionCollectionList = ObjVehicleDistributionBOL.GetDistributionValueForVehicleCode(ObjVehicleDistributionPPT)

        Dim ObjVehicleDistributionCollection1 As New DataTable
        ObjVehicleDistributionCollection1 = ObjVehicleDistributionCollectionList.Tables(0)

        If ObjVehicleDistributionCollection1.Rows.Count > 0 Then
            Select Case (lsUOM)
                Case "Hrs"
                    Me.txtTotalRunningKm.Text = ObjVehicleDistributionCollection1.Rows(0)("TotalHrs").ToString 'Convert.ToDecimal()'.Replace(":", "."))
                Case "Kms"
                    Me.txtTotalRunningKm.Text = GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalKms"))

            End Select
            If ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms").ToString <> String.Empty Or (ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedHrs").ToString <> String.Empty) Then 'Check Column TotalKmDistributed Not Null Then assign the value
                Select Case (lsUOM)
                    Case "Hrs"
                        Me.txtTotalKmDistributed.Text = GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedHrs").ToString())
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Replace(":", "."))
                    Case "Kms"
                        If ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms") Is DBNull.Value Then
                            Me.txtTotalKmDistributed.Text = "0.00"
                            ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text)
                        Else
                            Me.txtTotalKmDistributed.Text = GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms"))
                            ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text)
                        End If

                End Select

            ElseIf (ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms").ToString) = String.Empty Then 'Otherwise Check Column TotalRunningKm Not Null and TotalKmDistributed Null Then assign the value
                Select Case (lsUOM)
                    Case "Hrs"
                        Me.txtTotalKmDistributed.Text = "00:00"
                    Case "Kms"
                        Me.txtTotalKmDistributed.Text = "0.00"
                End Select
                ldCurrentTotalKmDistributed = 0
            End If
            If (Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("TotalKms")) <> String.Empty Or Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("TotalHrs")) <> String.Empty And (ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms").ToString) <> String.Empty) Then
                Select Case (lsUOM)
                    Case "Hrs"
                        Dim ldBalanceToDistributeDT As TimeSpan = GetInTimeValue(GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalHrs"))) - GetInTimeValue(GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedHrs")))
                        Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString.Substring(0, 5) 'Convert.ToDecimal() '.Replace(":", "."))
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Replace(":", "."))
                    Case "Kms"

                        Dim ldTotalKms, ldTotalKmsDistributed As Decimal

                        If Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("TotalKms")) <> String.Empty Then
                            ldTotalKms = Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKms"))
                        Else
                            ldTotalKms = 0
                        End If

                        If Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms")) <> String.Empty Then
                            ldTotalKmsDistributed = Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms"))
                        Else
                            ldTotalKmsDistributed = 0
                        End If

                        'Me.txtBalanceToDistribute.Text = Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKms")) - IIf((ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms").ToString) <> String.Empty, Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms")), 0) 'Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms"))
                        Me.txtBalanceToDistribute.Text = ldTotalKms - ldTotalKmsDistributed
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtTotalKmDistributed.Text)
                End Select
            ElseIf (Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("TotalKms")) <> String.Empty Or Convert.ToString(ObjVehicleDistributionCollection1.Rows(0)("TotalHrs")) <> String.Empty) Or (ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms").ToString) <> String.Empty Then
                Select Case (lsUOM)
                    Case "Hrs"

                        If ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedHrs").ToString IsNot DBNull.Value Then

                            Dim diffSec As Integer = Convert.ToDecimal(StringToSec(ObjVehicleDistributionCollection1.Rows(0)("TotalHrs"))) - Convert.ToDecimal(StringToSec(txtTotalKmDistributed.Text.Trim))
                            Dim ldBalanceToDistributeDT As String = SecToTime(diffSec)
                            'Dim ldBalanceToDistributeDT As TimeSpan = (ObjVehicleDistributionCollection1.Rows(0)("TotalHrs")) - GetInTimeValue(Me.txtTotalKmDistributed.Text.Trim.Replace(":", "."))
                            Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString 'Convert.ToDecimal() '.Replace(":", "."))
                            ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Replace(":", "."))
                        Else
                            'Dim ldBalanceToDistributeDT As TimeSpan = GetInTimeValue(0) - GetInTimeValue(Me.txtTotalKmDistributed.Text.Trim.Replace(":", "."))
                            'Me.txtBalanceToDistribute.Text = Convert.ToDecimal(ldBalanceToDistributeDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                            Dim diffSec As Integer = Convert.ToDecimal(StringToSec(0)) - Convert.ToDecimal(StringToSec(txtTotalKmDistributed.Text.Trim))
                            Dim ldBalanceToDistributeDT As String = SecToTime(diffSec)
                            Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString
                            ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Replace(":", "."))
                        End If


                    Case "Kms"
                        If ObjVehicleDistributionCollection1.Rows(0)("TotalKms").ToString <> String.Empty Then
                            Me.txtBalanceToDistribute.Text = (Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKms")) - Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim))
                            ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text)
                        Else
                            Me.txtBalanceToDistribute.Text = "0.00"
                            ldCurrentBalanceToDistribute = 0
                        End If


                End Select

            End If
        Else
            Select Case (lsUOM)
                Case "Hrs"
                    Me.txtTotalRunningKm.Text = "00:00"
                    Me.txtTotalKmDistributed.Text = "00:00"
                    Me.txtBalanceToDistribute.Text = "00:00"
                Case "Kms"
                    Me.txtTotalRunningKm.Text = "0.00"
                    Me.txtTotalKmDistributed.Text = "0.00"
                    Me.txtBalanceToDistribute.Text = "0.00"
            End Select

            ldCurrentTotalKmDistributed = 0
            ldCurrentBalanceToDistribute = 0

        End If

    End Sub
    Public Shared Function FormatTimeSpan(ByVal span As TimeSpan) As String
        Return String.Format("{0} {1} {2}", _
                             CInt(Math.Truncate(span.TotalHours)), _
                             span.Minutes, span.Seconds)
    End Function
    Public Shared Function StringToSec(ByVal strValue As String) As String
        If strValue = "0" Then
            strValue = "0:0"
        End If
        Dim sec As Integer = 0
        If strValue.Contains(".") Then
            Dim strArray() As String = strValue.Split(".")
            sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds
        ElseIf strValue.Contains(":") Then
            Dim strArray() As String = strValue.Split(":")
            sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds
        End If
        Return sec
    End Function
    Public Shared Function SecToTime(ByVal strdiff As String) As String
        Dim strTimeH, strTimeM As String
        Dim strTotal As String
        Dim t1 As TimeSpan = TimeSpan.FromSeconds(strdiff)
        strTimeH = CInt(Math.Truncate(t1.TotalHours))
        strTimeM = t1.Minutes


        If strTimeH.Length = 1 Then
            strTimeH = "0" + strTimeH
        End If
        If strTimeM.Length = 1 Then
            strTimeM = "0" + strTimeM
        End If
        strTotal = strTimeH + ":" + strTimeM
        ' strTotal = t1.ToString
        ' strTotal = strTotal.Substring(0, strTotal.LastIndexOf(":"))

        Return strTotal
    End Function
    Private Sub SaveTemp()
        Dim dr As DataRow

        If lbAdd Then

            dr = dtVDTempDataTable.NewRow()
            dr("DTId") = Guid.NewGuid().ToString()
            dr("DistributionDT") = dtpDate.Value
            dr("VHID") = lsVHID
            dr("VHWSCode") = txtVehicleCode.Text.Trim
            dr("COAKey") = lsVDAccountID
            dr("COAID") = txtAccountCode.Text.Trim
            dr("COADescp") = lblAccountDescription.Text
            dr("OldCOACode") = lblOldAccountValue.Text
            dr("ExpenditureAG") = lsVDExpenditureAG
            dr("TotalRunningKmHours") = Convert.ToDecimal(txtTotalRunningKm.Text.Trim().Replace(":", ".")) 'Convert.ToDecimal(txtTotalRunningKm.Text.Trim())
            'dr("TotalKmHoursDistributed") = IIf(txtTotalKmDistributed.Text.Trim IsNot String.Empty, Convert.ToDecimal(txtTotalKmDistributed.Text.Trim()), 0)
            If lsUOM = "Kms" Then
                dr("KmHours") = Convert.ToDecimal(txtKm.Text.Trim()) 'Convert.ToDecimal(txtKm.Text.Trim)
            Else
                dr("KmHours") = Convert.ToDecimal(txtKm.Text.Trim().Replace(":", "."))
            End If

            If txtPrestasiTonnageBuncheskm.Text.Trim = String.Empty Then
                dr("PrestasiTonBunchesKm") = 0
            Else
                dr("PrestasiTonBunchesKm") = Convert.ToDecimal(txtPrestasiTonnageBuncheskm.Text.Trim)

            End If

            'If ldCurrentTotalKmDistributed <> 0 Then

            If lsUOM = "Kms" Then
                dr("TotalKmHoursDistributed") = ldCurrentTotalKmDistributed + Convert.ToDecimal(Me.txtKm.Text.Trim())
                txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed + Convert.ToDecimal(Me.txtKm.Text.Trim())
                ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Trim)

                dr("BalanceToDistribute") = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Trim)

            ElseIf lsUOM = "Hrs" Then

                Dim diffSec As Integer = Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed)) + Convert.ToDecimal(StringToSec(txtKm.Text.Trim))
                Dim ldTotalHrsValueDT As String = SecToTime(diffSec)
                ' Dim ldTotalHrsValueDT As TimeSpan = GetInTimeValue(ldCurrentTotalKmDistributed) + GetInTimeValue(txtKm.Text.Trim.Replace(":", "."))
                dr("TotalKmHoursDistributed") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
                txtTotalKmDistributed.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))


                Dim diffSec1 As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed))
                ldTotalHrsValueDT = SecToTime(diffSec1)

                ' ldTotalHrsValueDT = GetInTimeValue(Convert.ToDecimal(txtTotalRunningKm.Text.Trim.Replace(":", "."))) - GetInTimeValue(Convert.ToDecimal(ldCurrentTotalKmDistributed))
                dr("BalanceToDistribute") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
                txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(ldTotalHrsValueDT)
                ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Replace(":", "."))
            End If


            dr("DivKey") = lsVDDivID
            dr("DivID") = txtDIV.Text.Trim
            dr("YOPKey") = lsVDYopID
            dr("YOPID") = txtYOP.Text.Trim
            dr("BlockKey") = lsVDBlockID
            dr("BlockID") = txtBlock.Text.Trim
            dr("BlockStatus") = lblSubBlockStatus.Text.Trim
            dr("T0") = lsVDT0analysisID
            dr("TValue0") = txtT0.Text.Trim
            dr("TDesc0") = lblT0Desc.Text
            dr("T1") = lsVDT1analysisID
            dr("TValue1") = txtT1.Text.Trim
            dr("TDesc1") = lblT1Desc.Text
            dr("T2") = lsVDT2analysisID
            dr("TValue2") = txtT2.Text.Trim
            dr("TDesc2") = lblT2Desc.Text
            dr("T3") = lsVDT3analysisID
            dr("TValue3") = txtT3.Text.Trim
            dr("TDesc3") = lblT3Desc.Text
            dr("T4") = lsVDT4analysisID
            dr("TValue4") = txtT4.Text.Trim
            dr("TDesc4") = lblT4Desc.Text
            dr("Remarks") = txtRemarks.Text.Trim
            dr("Action") = 1
            dr("UOM") = txtUOM.Text.Trim

            dtVDTempDataTable.Rows.Add(dr)
            dtVDTempDataTable.AcceptChanges()
            Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
            CalculateTotalKmsDistributedNBalance()
        End If


    End Sub

    Private Sub UpdateTemp(ByVal lsRowGuid As String)
        Dim liRowCount As Integer
        liRowCount = dtVDTempDataTable.Rows.Count
        'CalculateTotalKmsDistributedNBalance()

        If liRowCount > 0 Then

            Dim UpdateRow As DataRow() = Nothing
            Dim dt As New DataTable
            dt = dtVDTempDataTable
            If lsRowGuid <> String.Empty Then
                UpdateRow = dtVDTempDataTable.Select("DTId = '" & lsRowGuid & "'")
                If UpdateRow.Count > 0 Then
                Else
                    Return
                End If
                UpdateRow(0)("Action") = 1
            ElseIf liIdForRecordEdit <> 0 Then
                UpdateRow = dtVDTempDataTable.Select("Id = '" & liIdForRecordEdit & "'")
                UpdateRow(0)("Action") = 2
            ElseIf liIdForRecordDelete <> 0 Then
                UpdateRow = dtVDTempDataTable.Select("Id = '" & liIdForRecordDelete & "'")
                UpdateRow(0)("Action") = 3
                dtVDTempDataTable.AcceptChanges()
                Return
            Else

            End If

            If UpdateRow IsNot Nothing Then

                UpdateRow(0)("COAKey") = lsVDAccountID
                UpdateRow(0)("COAID") = txtAccountCode.Text.Trim
                UpdateRow(0)("COADescp") = lblAccountDescription.Text
                UpdateRow(0)("OldCOACode") = lblOldAccountValue.Text
                UpdateRow(0)("ExpenditureAG") = lsVDExpenditureAG
                'UpdateRow(0)("TotalRunningKmHours") = Convert.ToDecimal(txtTotalRunningKm.Text.Trim())



                'UpdateRow(0)("TotalKmHoursDistributed") = Convert.ToDecimal(txtTotalKmDistributed.Text.Trim())
                If lsUOM = "Kms" Then
                    UpdateRow(0)("KmHours") = Convert.ToDecimal(txtKm.Text.Trim)
                Else
                    UpdateRow(0)("KmHours") = Convert.ToDecimal(txtKm.Text.Trim().Replace(":", "."))
                End If


                If ldCurrentTotalKmDistributed <> 0 Then
                    If lsUOM = "Kms" Then
                        UpdateRow(0)("TotalKmHoursDistributed") = ldCurrentTotalKmDistributed + Convert.ToDecimal(Me.txtKm.Text.Trim())
                        txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed + Convert.ToDecimal(Me.txtKm.Text.Trim())
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Trim)

                        UpdateRow(0)("BalanceToDistribute") = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                        txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Trim)
                    ElseIf lsUOM = "Hrs" Then
                        Dim diffSec As Integer = Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed)) + Convert.ToDecimal(StringToSec(txtKm.Text.Trim))
                        Dim ldTotalHrsValueDT As String = SecToTime(diffSec)
                        UpdateRow(0)("TotalKmHoursDistributed") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
                        txtTotalKmDistributed.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))

                        Dim diffSec1 As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed))
                        ldTotalHrsValueDT = SecToTime(diffSec1)
                        UpdateRow(0)("BalanceToDistribute") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
                        txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Replace(":", "."))

                        'Dim ldTotalHrsValueDT As TimeSpan = GetInTimeValue(ldCurrentTotalKmDistributed) + GetInTimeValue(txtKm.Text.Trim.Replace(":", "."))
                        'UpdateRow(0)("TotalKmHoursDistributed") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", "."))
                        'txtTotalKmDistributed.Text = ldTotalHrsValueDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        'ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))

                        'ldTotalHrsValueDT = GetInTimeValue(Convert.ToDecimal(txtTotalRunningKm.Text.Trim.Replace(":", "."))) - GetInTimeValue(Convert.ToDecimal(ldCurrentTotalKmDistributed))
                        'UpdateRow(0)("BalanceToDistribute") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", ".")) 'Convert.ToDecimal(ldTotalHrsValueDT)
                        'txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(ldTotalHrsValueDT)
                        'ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Replace(":", "."))
                    End If
                Else
                    If lsUOM = "Kms" Then
                        UpdateRow(0)("TotalKmHoursDistributed") = Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim())
                        txtTotalKmDistributed.Text = Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim())
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text)

                        UpdateRow(0)("BalanceToDistribute") = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - Convert.ToDecimal(txtKm.Text.Trim)
                        txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - Convert.ToDecimal(txtKm.Text.Trim)
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text)
                    ElseIf lsUOM = "Hrs" Then

                        Dim diffSec As Integer = Convert.ToDecimal(StringToSec(txtTotalKmDistributed.Text.Trim)) + Convert.ToDecimal(StringToSec(txtKm.Text.Trim))
                        Dim ldTotalHrsValueDT As String = SecToTime(diffSec)
                        UpdateRow(0)("TotalKmHoursDistributed") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
                        txtTotalKmDistributed.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))

                        Dim diffSec1 As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - Convert.ToDecimal(StringToSec(txtKm.Text.Trim))
                        ldTotalHrsValueDT = SecToTime(diffSec1)
                        UpdateRow(0)("BalanceToDistribute") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
                        txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Replace(":", "."))

                        'Dim ldTotalHrsValueDT As TimeSpan = GetInTimeValue(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")) + GetInTimeValue(txtKm.Text.Trim.Replace(":", "."))
                        'UpdateRow(0)("TotalKmHoursDistributed") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", "."))
                        'txtTotalKmDistributed.Text = ldTotalHrsValueDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                        'ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))

                        'ldTotalHrsValueDT = GetInTimeValue(Convert.ToDecimal(txtTotalRunningKm.Text.Trim.Replace(":", "."))) - GetInTimeValue(Convert.ToDecimal(txtKm.Text.Trim.Replace(":", ".")))
                        'UpdateRow(0)("BalanceToDistribute") = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", ".")) 'Convert.ToDecimal(ldTotalHrsValueDT)
                        'txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(ldTotalHrsValueDT)
                        'ldCurrentBalanceToDistribute = Convert.ToDecimal(txtBalanceToDistribute.Text.Replace(":", "."))
                    End If
                End If

                UpdateRow(0)("PrestasiTonBunchesKm") = Convert.ToDecimal(txtPrestasiTonnageBuncheskm.Text.Trim)
                UpdateRow(0)("DivKey") = lsVDDivID
                UpdateRow(0)("DivID") = txtDIV.Text.Trim
                UpdateRow(0)("YOPKey") = lsVDYopID
                UpdateRow(0)("YOPID") = txtYOP.Text.Trim
                UpdateRow(0)("BlockKey") = lsVDBlockID
                UpdateRow(0)("BlockID") = txtBlock.Text.Trim
                UpdateRow(0)("BlockStatus") = lblSubBlockStatus.Text.Trim
                UpdateRow(0)("T0") = lsVDT0analysisID
                UpdateRow(0)("TValue0") = txtT0.Text.Trim
                UpdateRow(0)("TDesc0") = lblT0Desc.Text
                UpdateRow(0)("T1") = lsVDT1analysisID
                UpdateRow(0)("TValue1") = txtT1.Text.Trim
                UpdateRow(0)("TDesc1") = lblT1Desc.Text
                UpdateRow(0)("T2") = lsVDT2analysisID
                UpdateRow(0)("TValue2") = txtT2.Text.Trim
                UpdateRow(0)("TDesc2") = lblT2Desc.Text
                UpdateRow(0)("T3") = lsVDT3analysisID
                UpdateRow(0)("TValue3") = txtT3.Text.Trim
                UpdateRow(0)("TDesc3") = lblT3Desc.Text
                UpdateRow(0)("T4") = lsVDT4analysisID
                UpdateRow(0)("TValue4") = txtT4.Text.Trim
                UpdateRow(0)("TDesc4") = lblT4Desc.Text
                UpdateRow(0)("Remarks") = txtRemarks.Text.Trim

                dtVDTempDataTable.AcceptChanges()

                lsRowGuid = String.Empty
            End If

            lbIsUpdating = False

        End If


    End Sub

    Private Sub DeleteTemp(ByVal lsRowGuid As String)

        Dim liRowCount As Integer
        liRowCount = dtVDTempDataTable.Rows.Count
        'CalculateTotalKmsDistributedNBalance()

        If liRowCount > 0 Then
            For Each dr As DataRow In dtVDTempDataTable.Rows

                If Convert.ToString(dr("DTId")).Trim = lsRowGuid And Convert.ToString(dr("Id")).Trim = String.Empty Then
                    dr.Delete()
                End If

            Next

            dtVDTempDataTable.AcceptChanges()

        End If

    End Sub

    Function GetInTimeValue(ByVal lsFormValue As String) As TimeSpan
        Dim ldHrsDT As DateTime = DateTime.ParseExact(Format(Convert.ToDecimal(lsFormValue), "0,0.0,0"), "HH.mm", Nothing) '+ DateTime.ParseExact(Format(Convert.ToDecimal(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem), "0,0.0,0"), "HH.mm", Nothing)
        Dim ldHrsValueDT As TimeSpan = New TimeSpan(ldHrsDT.Hour, ldHrsDT.Minute, ldHrsDT.Second)
        Return ldHrsValueDT
    End Function

    Public Sub ConvertKmsToHrsText(ByVal lsFormat As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If (lsFormat = "Hrs") Then
            Me.lblTotalRunningKms.Text = rm.GetString("Total Running Hrs")
            Me.lblTotalKmsDistributed.Text = rm.GetString("Total Hrs Distributed")
            Me.lblKmsHrs.Text = "Hrs"
            Me.txtKm.Visible = False
            Me.lblHrsFormat.Visible = False
            txtStartHrs.Visible = True
            txtStartMin.Visible = True

            'cmbStartHrs.Visible = True
            'cmbStartMin.Visible = True
            Label2.Visible = True
            Label35.Visible = True
            txtShift.Visible = False


        ElseIf (lsFormat = "Kms") Then
            Me.lblTotalRunningKms.Text = rm.GetString("Total Running KM")
            Me.lblTotalKmsDistributed.Text = rm.GetString("Total KM Distributed")
            Me.lblKmsHrs.Text = "Kms"
            Me.lblHrsFormat.Visible = False
            txtStartHrs.Visible = False
            txtStartMin.Visible = False
            'cmbStartHrs.Visible = False
            'cmbStartMin.Visible = False
            txtShift.Visible = False
            Me.txtKm.Visible = True
            Label2.Visible = False
            Label35.Visible = False


        End If
    End Sub

    'Private Sub DeleteVehicleDistribution()

    'End Sub

    Public Sub ShowVehicleDistributionDetailsByID() 'ByVal lsId As Integer, ByVal lsGUID As String
        CalculateTotalKmsDistributedNBalance()

        If dtVDTempDataTable IsNot Nothing And dtVDTempDataTable.Rows.Count > 0 Then

            Me.txtVehicleCode.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("VHWSCode"))
            lsVDAccountID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("COAKey"))
            Me.txtAccountCode.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("COAID"))
            Me.lblAccountDescription.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("COADescp"))
            Me.lblOldAccountValue.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("OldCOACode"))
            lsVDExpenditureAG = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("ExpenditureAG"))

            Select Case (txtUOM.Text.Trim)
                Case "Hrs"
                    '  Dim ldTimeDt As DateTime = General.GetTimeFormation(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("KmHours").ToString.Replace(".", ":")) 'DateTime.ParseExact(Me.dsVehicleLogDetails.Tables(0).Rows(0)(0).ToString().Substring(0, 5), "HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("HH:mm")


                    Dim diffTimeDT As Integer = Convert.ToDecimal(StringToSec(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("KmHours").ToString.Replace(".", ":")))
                    Dim lsStartTempTime As String = SecToTime(diffTimeDT)

                    '  Dim lsStartTempTime As String = New DateTime(ldTimeDt.Ticks).ToString("HH:mm")
                    Dim splitStartTime() As String = lsStartTempTime.Split(":")
                    ' lsStartTime = New DateTime(ldTimeDt.Ticks).ToString("HH:mm")
                    'cmbStartHrs.SelectedIndex = Convert.ToInt32(splitStartTime(0)) ' - 1

                    txtStartHrs.Text = Convert.ToInt32(splitStartTime(0))
                    txtStartMin.Text = Convert.ToInt32(splitStartTime(1))
                    'If splitStartTime(1).StartsWith(0) Then
                    '    cmbStartMin.SelectedIndex = cmbStartMin.FindString(splitStartTime(1))
                    'Else
                    '    cmbStartMin.SelectedIndex = cmbStartMin.FindString(Convert.ToInt32(splitStartTime(1)))
                    'End If

                    ' cmbStartMin.SelectedIndex = cmbStartMin.FindString(Convert.ToInt32(splitStartTime(1)))
                    txtKm.Text = lsStartTempTime.ToString 'ldTimeDt.Hour.ToString("00") + "." + ldTimeDt.Minute.ToString("00")


                    Dim diffSec As Integer = Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed)) - Convert.ToDecimal(StringToSec(txtKm.Text.Trim))
                    Dim ldTotalHrsDistributedDT As String = SecToTime(diffSec)
                    Me.txtTotalKmDistributed.Text = ldTotalHrsDistributedDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5)) '.Replace(":", "."))
                    ldCurrentTotalKmDistributed = Convert.ToDecimal(txtTotalKmDistributed.Text.Replace(":", "."))

                    Dim diffSec1 As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - Convert.ToDecimal(StringToSec(ldCurrentTotalKmDistributed))
                    Dim ldBalanceToDistributeDT As String = SecToTime(diffSec1)
                    Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString

                    '  Dim ldTotalHrsDistributedDT As TimeSpan = GetInTimeValue(ldCurrentTotalKmDistributed) - GetInTimeValue(txtKm.Text.Trim.Replace(":", ".")) 'GetInTimeValue(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem)
                    'Me.txtTotalKmDistributed.Text = ldTotalHrsDistributedDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsDistributedDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) - Convert.ToDecimal(Me.txtKm.Text.Trim)
                    'ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")) 'Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) - Convert.ToDecimal(Me.txtKm.Text.Trim)

                    'Dim ldBalanceToDistributeDT As TimeSpan = GetInTimeValue(txtTotalRunningKm.Text.Trim.Replace(":", ".")) - GetInTimeValue(ldCurrentTotalKmDistributed) 'GetInTimeValue(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem)
                    'Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldBalanceToDistributeDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim)

                    ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Replace(":", ".")) 'Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim)
                    'lblHrsFormat.Visible = True
                Case "Kms"
                    Me.txtKm.Text = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("KmHours").ToString 'Me.dsVehicleLogDetails.Tables(0).Rows(0)(0).ToString
                    Me.txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed - Convert.ToDecimal(Me.txtKm.Text.Trim)
                    ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text)
                    Me.txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                    ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text)
                    'lblHrsFormat.Visible = False
            End Select

            Me.txtPrestasiTonnageBuncheskm.Text = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("PrestasiTonBunchesKm").ToString


            lsVDDivID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DivKey"))
            Me.txtDIV.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("DivID"))
            lsVDYopID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("YOPKey"))
            Me.txtYOP.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("YOPID"))
            lsVDBlockID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("BlockKey"))
            Me.txtBlock.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("BlockID"))
            Me.lblSubBlockStatus.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("BlockStatus"))

            txtT0.Text = Helper.T0Default(0)
            lsVDT0analysisID = Helper.T0Default(0)
            lblT0Desc.Text = Helper.T0Default(1)

            lsVDT0analysisID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("T0"))
            Me.txtT0.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("T0"))
            lblT0Desc.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TDesc0"))


            lsVDT1analysisID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("T1"))
            Me.txtT1.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TValue1"))
            lblT1Desc.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TDesc1"))
            lsVDT2analysisID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("T2"))
            Me.txtT2.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TValue2"))
            lblT2Desc.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TDesc2"))
            lsVDT3analysisID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("T3"))
            Me.txtT3.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TValue3"))
            lblT3Desc.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TDesc3"))
            lsVDT4analysisID = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("T4"))
            Me.txtT4.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TValue4"))
            lblT4Desc.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("TDesc4"))
            Me.txtRemarks.Text = GetDataValue(dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("Remarks"))
            If Not dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("Remarks") IsNot DBNull.Value Then
                lbConcurrencyID = dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("ConcurrencyId")
            End If



            If dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("Posted").ToString.Trim() = "N" Or dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("Posted").ToString.Trim() = "" Then
                btnAdd.Enabled = True
                'btnResetMultipleEntryGrp.Enabled = True
            Else
                btnAdd.Enabled = False
                'btnResetMultipleEntryGrp.Enabled = False
            End If

            If dtVDTempDataTable.Rows(dgVehicleLog.CurrentRow.Index)("Posted").ToString.Trim() = "N" Then
                btnAdd.Enabled = True
                'btnResetMultipleEntryGrp.Enabled = True
            Else
                btnAdd.Enabled = False
                'btnResetMultipleEntryGrp.Enabled = False
            End If

            'btnAdd.Text = "Update"
            lbAdd = False
            'btnAdd.Enabled = True
            'btnResetMultipleEntryGrp.Enabled = True
            Dim mdiparent As New MDIParent
            If mdiparent.strMenuID = "M74" Then
                btnAdd.Enabled = False
            End If

        End If
    End Sub

    Public Function GetDataValue(ByVal o As Object) As Object

        If o Is Nothing OrElse o Is DBNull.Value OrElse String.Empty.Equals(o) Then
            Return String.Empty
        Else
            Return o
        End If

    End Function

    Function CheckKmOrHrs() As Boolean
        Dim lbReturn As Boolean = True
        Dim lsErrorMessage As String = String.Empty
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If (txtKm.Text <> String.Empty Or IsNumeric(txtKm.Text)) Then
            Select Case (txtUOM.Text.Trim)
                Case "Hrs"
                    Dim rtime As New System.Text.RegularExpressions.Regex("[0-9]:[0-5][0-9]$")
                    If Not rtime.IsMatch(txtKm.Text.Trim) Then
                        lsErrorMessage = rm.GetString("ITimeFormat") & vbCrLf
                    End If

                    'Dim rtime As New System.Text.RegularExpressions.Regex("^[0-9][0-9]\:[0-5][0-9]$")
                    'If Not rtime.IsMatch(txtKm.Text.Trim) Then
                    '    lsErrorMessage = rm.GetString("IHrsFormat") & vbCrLf
                    '    'ElseIf General.GetInTimeFormat(txtKm.Text.Replace(".", ":").Trim) = General.GetInTimeFormat("00:00:00") Then
                    '    '    lsErrorMessage = rm.GetString("IGreaterMinute") & vbCrLf
                    'End If

                    Dim rtime1 As New System.Text.RegularExpressions.Regex("^[0-0][0-0]\:[0-0][0-0]$")
                    If rtime1.IsMatch(txtKm.Text.Trim) Then
                        lsErrorMessage = rm.GetString("IHrsZero") & vbCrLf
                    End If

                    'If Not lreValidateTime.IsMatch(txtKm.Text.Trim) Then
                    '    lsErrorMessage = rm.GetString("IHrsFormat") & vbCrLf
                    'ElseIf General.GetInTimeFormat(txtKm.Text.Replace(".", ":").Trim) = General.GetInTimeFormat("00:00:00") Then
                    '    lsErrorMessage = rm.GetString("IGreaterMinute") & vbCrLf
                    'End If
                Case "Kms"
                    Dim Expression As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,1})?[^\.]$") '("^\d{0,16}(\.\d{0,2})?$")
                    If Not Expression.IsMatch(txtKm.Text.Trim) Then
                        lsErrorMessage = rm.GetString("IKmsFormat") & vbCrLf
                    End If
            End Select
        Else
            lsErrorMessage = rm.GetString("INumeric")
        End If

        If lsErrorMessage <> String.Empty Then

            txtKm.Focus()

            MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
            lbReturn = False
        End If

        Return lbReturn

    End Function

    Function IsValidTimeOrKms() As Boolean
        Dim lbIsTrue As Boolean
        lbIsTrue = True
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If Me.txtUOM.Text.Trim = "Hrs" Then
            Dim ldTotalHrsValueDT As String

            ' Dim ldTotalHrsValueDT As TimeSpan
            If txtKm.Text <> String.Empty And Me.txtTotalKmDistributed.Text <> String.Empty And Me.txtTotalRunningKm.Text <> String.Empty Then


                Dim diffSec As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - (Convert.ToDecimal(StringToSec(txtTotalKmDistributed.Text.Trim)) + Convert.ToDecimal(StringToSec(txtKm.Text.Trim)))
                ldTotalHrsValueDT = SecToTime(diffSec)
                Me.txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal() '.Replace(":", "."))
                '   ldTotalHrsValueDT = GetInTimeValue(Me.txtTotalRunningKm.Text.Trim.Replace(":", ".")) - (GetInTimeValue(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")) + GetInTimeValue(txtKm.Text.Trim.Replace(":", ".")))
                ' txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", "."))
                lbIsTrue = True
                'Return True
            ElseIf txtKm.Text = String.Empty And Me.txtTotalKmDistributed.Text <> String.Empty And Me.txtTotalRunningKm.Text <> String.Empty Then
                Dim diffSec As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - Convert.ToDecimal(StringToSec(txtTotalKmDistributed.Text.Trim))
                ldTotalHrsValueDT = SecToTime(diffSec)
                ' ldTotalHrsValueDT = GetInTimeValue(Me.txtTotalRunningKm.Text.Trim.Replace(":", ".")) - (GetInTimeValue(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")))
                txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", "."))
                lbIsTrue = True
            End If
            'Dim secTimeSpan As TimeSpan = TimeSpan.Parse(StringToSec(ldTotalHrsValueDT))

            If Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim.Contains("-")) Then

                'If ldTotalHrsValueDT.Minutes < 0 Or ldTotalHrsValueDT.Seconds < 0 Or Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim.Replace(":", ".")) < 0 Then

                'If secTimeSpan.Minutes < 0 Or secTimeSpan.Seconds < 0 Or Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim.Replace(":", ".")) < 0 Then
                'If secTimeSpan.Minutes < 0 Or secTimeSpan.Seconds < 0 Or Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim.Contains("-")) Then
                Dim diffSec As Integer = Convert.ToDecimal(StringToSec(txtTotalRunningKm.Text.Trim)) - Convert.ToDecimal(StringToSec(txtTotalKmDistributed.Text.Trim))
                ldTotalHrsValueDT = SecToTime(diffSec)
                'ldTotalHrsValueDT = GetInTimeValue(Me.txtTotalRunningKm.Text.Trim.Replace(":", ".")) - (GetInTimeValue(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")))
                txtBalanceToDistribute.Text = ldTotalHrsValueDT.ToString 'Convert.ToDecimal(ldTotalHrsValueDT.ToString.Substring(0, 5).Replace(":", "."))
                lbIsTrue = False
                txtKm.Focus()
                'MsgBox(rm.GetString("IHrsGreaterThanBalance"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
                DisplayInfoMessage("IHrsGreaterThanBalance")
                txtKm.Text = String.Empty
            End If
        ElseIf Me.txtUOM.Text.Trim = "Kms" Then
            If ChecklbIsDecimalInFormat(txtKm) Then
                If Me.txtKm.Text <> String.Empty And Me.txtTotalKmDistributed.Text <> String.Empty And Me.txtTotalRunningKm.Text <> String.Empty Then
                    Me.txtBalanceToDistribute.Text = Convert.ToDecimal(Me.txtTotalRunningKm.Text.Trim) - (Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim))
                    lbIsTrue = True
                ElseIf Me.txtKm.Text = String.Empty And Me.txtTotalKmDistributed.Text <> String.Empty And Me.txtTotalRunningKm.Text <> String.Empty Then
                    Me.txtBalanceToDistribute.Text = (Convert.ToDecimal(Me.txtTotalRunningKm.Text.Trim) - Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim)) + (Convert.ToDecimal(0))
                    lbIsTrue = True
                End If
                If Me.txtBalanceToDistribute.Text <> String.Empty Then
                    If Convert.ToDecimal(Me.txtBalanceToDistribute.Text) < 0 Then
                        Me.txtBalanceToDistribute.Text = (Convert.ToDecimal(Me.txtTotalRunningKm.Text.Trim) - Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim)) + (Convert.ToDecimal(0))
                        Me.txtKm.Focus()
                        'MsgBox(rm.GetString("IKmsGreaterThanBalance"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
                        DisplayInfoMessage("IKmsGreaterThanBalance")

                        lbIsTrue = False
                    ElseIf Convert.ToDecimal(txtKm.Text.Trim) <= 0 Then
                        Me.txtKm.Focus()
                        'MsgBox(rm.GetString("IKmsZero"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
                        DisplayInfoMessage("IKmsZero")
                        lbIsTrue = False
                    End If
                End If
            Else
                lbIsTrue = False
            End If
        End If
        Return lbIsTrue
    End Function

    Private Sub ClearSubBlock()
        txtBlock.Text = String.Empty
        lsVDBlockID = String.Empty
        Me.txtDIV.Text = String.Empty
        lsVDDivID = String.Empty
        Me.txtYOP.Text = String.Empty
        lsVDYopID = String.Empty
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            tbpgAdd.Text = rm.GetString("Vehicle Distribution")

            lblDate.Text = rm.GetString("lblDate")
            lblVehicleCode.Text = rm.GetString("Vehicle Code")
            lblTotalRunningKms.Text = rm.GetString("Total Running KM")
            lblVehicleName.Text = rm.GetString("Vehicle Name")
            lblVehicleModel.Text = rm.GetString("Vehicle Model")
            lblVehicleRegNo.Text = rm.GetString("Vehicle Reg No")
            lblTotalKmsDistributed.Text = rm.GetString("Total KM Distributed")
            lblPrestasiTonnageBunchesKm.Text = rm.GetString("Prestasi/Tonage/Bunches/Km")
            gbDistribution.Text = rm.GetString("Distribution")
            lblAccountCode.Text = rm.GetString("Account Code")
            lblOldAccountCode.Text = rm.GetString("Old Account Code")
            lblKmsHrs.Text = rm.GetString("Km/Hrs")
            lblBalanceToDistribute.Text = rm.GetString("Balance To Distribute")
            lblYOP.Text = rm.GetString("YOP")
            lblBlock.Text = rm.GetString("Sub Block")

            btnAdd.Text = rm.GetString("btnAdd")
            btnClose.Text = rm.GetString("btnClose")
            btnSaveAll.Text = rm.GetString("btnSaveAll")
            btnResetAll.Text = rm.GetString("btnResetAll")
            btnResetMultipleEntryGrp.Text = rm.GetString("btnResetMultipleEntryGrp")

            dgVehicleLog.Columns("COAID").HeaderText = rm.GetString("Account Code")
            dgVehicleLog.Columns("OldCOACode").HeaderText = rm.GetString("Old Account Code")
            dgVehicleLog.Columns("KmHours").HeaderText = rm.GetString("Km/Hrs")
            dgVehicleLog.Columns("PrestasiTonBunchesKm").HeaderText = rm.GetString("Prestasi/Tonage/Bunches/Km")
            dgVehicleLog.Columns("YOP").HeaderText = rm.GetString("YOP")
            dgVehicleLog.Columns("Block").HeaderText = rm.GetString("Sub Block")

            PnlSearch.CaptionText = rm.GetString("pnlSearch")
            lblSearchBy.Text = rm.GetString("lblSearchby.Text")
            lblviewVDDate.Text = rm.GetString("lblDate")
            'lblSearchDate.Text = rm.GetString("lblDate")
            lblSearchVehicleCode.Text = rm.GetString("Vehicle Code")
            lblSearchVehicleName.Text = rm.GetString("Vehicle Name")
            lblSearchVehicleModel.Text = rm.GetString("Vehicle Model")
            gbGridAdd.Text = rm.GetString("gbGridAdd.Text")
            dgVehicle.Columns("VDDate").HeaderText = rm.GetString("lblDate")
            dgVehicle.Columns("VHWSCode").HeaderText = rm.GetString("Vehicle Code")
            dgVehicle.Columns("VHName").HeaderText = rm.GetString("Vehicle Name")
            dgVehicle.Columns("VHModel").HeaderText = rm.GetString("Vehicle Model")
            dgVehicle.Columns("VDPosted").HeaderText = rm.GetString("txtPosted")
            btnviewReport.Text = rm.GetString("Report")
            btnSearch.Text = rm.GetString("btnSearch")

            cmsEntry.Items.Item(0).Text = rm.GetString("cmsEntry.Items.Item(0).Text")
            cmsEntry.Items.Item(1).Text = rm.GetString("cmsEntry.Items.Item(1).Text")
            cmsEntry.Items.Item(2).Text = rm.GetString("cmsEntry.Items.Item(2).Text")
            cmsView.Items.Item(0).Text = rm.GetString("cmsEntry.Items.Item(0).Text")
            cmsView.Items.Item(1).Text = rm.GetString("cmsEntry.Items.Item(1).Text")
            cmsView.Items.Item(2).Text = rm.GetString("cmsEntry.Items.Item(2).Text")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalculateTotalKmsDistributedNBalance()
        Dim ldTKD As Decimal = 0
        Dim ldTotalHrsValueDT As String
        Dim diffSec As Decimal

        For index As Integer = 0 To dgVehicleLog.Rows.Count - 1
            If txtUOM.Text = "Kms" Then
                If dgVehicleLog.Rows(index).Cells("KmHours").Value IsNot DBNull.Value And Convert.ToString(dgVehicleLog.Rows(index).Cells("Action").Value) <> "3" Then

                    ldTKD += Convert.ToDecimal(dgVehicleLog.Rows(index).Cells("KmHours").Value)

                End If
            ElseIf txtUOM.Text = "Hrs" Then

                If dgVehicleLog.Rows(index).Cells("KmHours").Value IsNot DBNull.Value And Not Convert.ToString(dgVehicleLog.Rows(index).Cells("Action").Value).Trim().Equals("3") Then

                    diffSec += Convert.ToDecimal(StringToSec(dgVehicleLog.Rows(index).Cells("KmHours").Value))

                    '  ldTotalHrsValueDT += GetInTimeValue(dgVehicleLog.Rows(index).Cells("KmHours").Value)

                End If
            End If
        Next

        If txtUOM.Text = "Kms" Then
            ldCurrentTotalKmDistributed = ldTKD
            ldCurrentBalanceToDistribute = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
        ElseIf txtUOM.Text = "Hrs" Then
            ldTotalHrsValueDT = SecToTime(diffSec)
            ldCurrentTotalKmDistributed = Convert.ToDecimal(ldTotalHrsValueDT.ToString.Replace(":", "."))
            ldCurrentBalanceToDistribute = Convert.ToDecimal(txtTotalRunningKm.Text.Trim.Replace(":", ".")) - ldCurrentTotalKmDistributed
        End If

    End Sub

    Private Sub ResetViewArea()
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSearchBydate)
        Me.txtVehicleSearch.Text = String.Empty
        Me.txtSearchVehicleName.Text = String.Empty
        Me.txtSearchVehicleModel.Text = String.Empty
        chkVDDate.Checked = False
        dtpSearchBydate.Enabled = False
        chkVDDate.Focus()
    End Sub

    Private Sub ResetTop()
        Me.txtVehicleCode.Text = String.Empty
        Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
    End Sub

    Private Sub ResetMainControls()
        Me.txtUOM.Text = String.Empty
        Me.txtTotalRunningKm.Text = String.Empty
        Me.txtVehicleName.Text = String.Empty
        Me.txtVehicleModel.Text = String.Empty
        Me.txtVehicleRegNo.Text = String.Empty
        Me.txtTotalKmDistributed.Text = String.Empty
        Me.txtBalanceToDistribute.Text = String.Empty

        dtVDTempDataTable.Rows.Clear()
        ldCurrentBalanceToDistribute = 0
        ldCurrentTotalKmDistributed = 0

        Me.lblHrsFormat.Visible = False

    End Sub

    Private Sub ResetRequiredControls()
        Me.txtAccountCode.Text = String.Empty
        Me.txtKm.Text = String.Empty

        lbAdd = True
        btnAdd.Enabled = True
        pnlEntry.Enabled = True
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        lbAdd = True
        btnAdd.Enabled = True
        btnResetMultipleEntryGrp.Enabled = True

        lslookupCode = String.Empty
        lslookupId = String.Empty
        lslookupDesc = String.Empty
        lslookupValue = String.Empty

        dtpDate.Focus()

    End Sub

    Private Sub ResetControls()

        Me.lblAccountDescription.Text = String.Empty
        lblOldAccountValue.Text = String.Empty
        Me.txtPrestasiTonnageBuncheskm.Text = String.Empty
        'Me.txtT0.Text = String.Empty
        Me.txtT1.Text = String.Empty
        Me.txtT2.Text = String.Empty
        Me.txtT3.Text = String.Empty
        Me.txtT4.Text = String.Empty
        'Me.lblT0Desc.Text = String.Empty
        Me.lblT1Desc.Text = String.Empty
        Me.lblT2Desc.Text = String.Empty
        Me.lblT3Desc.Text = String.Empty
        Me.lblT4Desc.Text = String.Empty
        Me.txtDIV.Text = String.Empty
        Me.txtYOP.Text = String.Empty
        Me.txtBlock.Text = String.Empty
        Me.lblSubBlockStatus.Text = String.Empty

        txtStartHrs.Text = String.Empty
        txtStartMin.Text = String.Empty
        'cmbStartHrs.SelectedIndex = -1
        'cmbStartMin.SelectedIndex = -1
        txtShift.Text = String.Empty

        'lsVDT0analysisID = String.Empty
        lsVDT1analysisID = String.Empty
        lsVDT2analysisID = String.Empty
        lsVDT3analysisID = String.Empty
        lsVDT4analysisID = String.Empty
        lsVDDivID = String.Empty
        lsVDBlockID = String.Empty
        lsVDYopID = String.Empty

        Me.txtRemarks.Text = String.Empty

        btnAdd.Enabled = True
        'btnAdd.Text = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        lbAdd = True
        btnAdd.Enabled = True
        btnResetMultipleEntryGrp.Enabled = True

        dtpDate.Enabled = False
        txtVehicleCode.Enabled = False
        ibtnSearchVehicleCode.Enabled = False

        CalculateTotalKmsDistributedNBalance()

    End Sub

    Private Sub VDTempDataTable1()

        dtVDTempDataTable = New DataTable

        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("DTId", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("Id", Type.GetType("System.Int32")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("Id", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("DistributionDT", Type.GetType("System.DateTime")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("DistributionDT", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("VHID", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("VHWSCode", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("COAKey", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("COAID", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("COADescp", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("OldCOACode", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("ExpenditureAG", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TotalRunningKmHours", Type.GetType("System.Decimal")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TotalRunningKmHours", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TotalKmHoursDistributed", Type.GetType("System.Decimal")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TotalKmHoursDistributed", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("KmHours", Type.GetType("System.Decimal")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("KmHours", Type.GetType("System.String")))
        '        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("BalanceToDistribute", Type.GetType("System.Decimal")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("BalanceToDistribute", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("PrestasiTonBunchesKm", Type.GetType("System.Decimal")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("PrestasiTonBunchesKm", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("DivKey", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("DivID", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("YOPKey", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("YOPID", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("BlockKey", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("BlockID", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("BlockStatus", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("T0", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TValue0", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TDesc0", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("T1", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TValue1", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TDesc1", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("T2", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TValue2", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TDesc2", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("T3", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TValue3", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TDesc3", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("T4", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TValue4", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("TDesc4", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("Remarks", Type.GetType("System.String")))
        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("ConcurrencyId", GetType(System.Byte())))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("ConcurrencyId", Type.GetType("System.Byte[]")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("Posted", Type.GetType("System.String")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("Action", Type.GetType("System.Int32")))
        dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("UOM", Type.GetType("System.String")))

        'dtVDTempDataTable.Columns.Add(New System.Data.DataColumn("VHDistributionID", Type.GetType("System.String")))



        'dtVDTempDataTable2.Columns.Add(New System.Data.DataColumn("DTId", GetType([String])))
        'dtVDTempDataTable2.Columns.Add(New System.Data.DataColumn("Id", GetType(Integer)))
        'dtVDTempDataTable2.Columns.Add(New System.Data.DataColumn("TRKmHrs", GetType(Char)))
        'dtVDTempDataTable2.Columns.Add(New System.Data.DataColumn("TDKm", GetType(Char)))
        'dtVDTempDataTable2.Columns.Add(New System.Data.DataColumn("", GetType(Char)))


    End Sub

    Private Sub DefaultPopup()
        cmsEntry.Hide()
        tspEditEntry.Visible = True
        tspDeleteEntry.Visible = False
        tsmAddEntry.Visible = False
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    'Private Sub SetBlockEnabled(ByVal lbEnabled As Boolean)
    '    txtBlock.Enabled = lbEnabled
    '    ibtnSearchBlock.Enabled = lbEnabled
    'End Sub
#End Region

#Region "Validation"

    Private Sub txtVehicleCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave
        If txtVehicleCode.Enabled = True Then
            If Me.txtVehicleCode.Text <> String.Empty Then

                ResetMainControls()
                ResetRequiredControls()
                ResetControls()

                Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
                txtKm.Focus()
            Else
                ResetControls()
                ResetMainControls()
                Me.BindVehicleDistributionByVehicleCode(String.Empty, New DateTime(1900, 1, 1))
            End If

            If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        End If

    End Sub

    Private Sub txtAccountCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountCode.Leave

        If txtAccountCode.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.COACode = txtAccountCode.Text.Trim()
            ds = StoreIssueVoucherBOL.AcctlookupSearch(objSIV, "YES")

            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                'MsgBox(rm.GetString("IAccountCode"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IAccountCode")
                txtAccountCode.Text = String.Empty
                lblAccountDescription.Text = String.Empty
                lblOldAccountValue.Text = String.Empty
                GlobalPPT.psAcctExpenditureType = String.Empty
                lsVDAccountID = String.Empty
                lsVDExpenditureAG = String.Empty
                txtAccountCode.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("COACode").ToString() <> String.Empty Then
                    txtAccountCode.Text = ds.Tables(0).Rows(0).Item("COACode")
                End If
                If ds.Tables(0).Rows(0).Item("COADescp").ToString() <> String.Empty Then
                    lblAccountDescription.Text = ds.Tables(0).Rows(0).Item("COADescp")
                End If
                If ds.Tables(0).Rows(0).Item("ExpenditureAG").ToString() <> String.Empty Then
                    lsVDExpenditureAG = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                End If
                If ds.Tables(0).Rows(0).Item("COAID").ToString() <> String.Empty Then
                    lsVDAccountID = ds.Tables(0).Rows(0).Item("COAID")
                End If
                If ds.Tables(0).Rows(0).Item("OldCOACode").ToString() <> String.Empty Then
                    lblOldAccountValue.Text = ds.Tables(0).Rows(0).Item("OldCOACode")
                End If
                If Not ds.Tables(0).Rows(0).Item("ExpenditureAG").ToString() Is DBNull.Value Then
                    GlobalPPT.psAcctExpenditureType = ds.Tables(0).Rows(0).Item("ExpenditureAG")
                End If
            End If
        Else
            txtAccountCode.Text = String.Empty
            lblAccountDescription.Text = String.Empty
            lblOldAccountValue.Text = String.Empty
            lsVDAccountID = String.Empty
            GlobalPPT.psAcctExpenditureType = String.Empty
            lsVDExpenditureAG = String.Empty
        End If
    End Sub

    Private Sub txtBlock_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBlock.Leave

        If txtBlock.Text.Trim() <> String.Empty And txtBlock.Enabled = True Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.BlockName = txtBlock.Text.Trim()
            objSIV.BlockStatus = GlobalPPT.psAcctExpenditureType
            ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                'MsgBox(rm.GetString("ISubBlock"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("ISubBlock")
                'MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
                txtBlock.Text = String.Empty
                lsVDBlockID = String.Empty
                lblSubBlockStatus.Text = String.Empty
                Me.txtDIV.Text = String.Empty
                lsVDDivID = String.Empty

                Me.txtYOP.Text = String.Empty

                lsVDYopID = String.Empty
                txtBlock.Focus()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
                    txtBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
                End If
                If ds.Tables(0).Rows(0).Item("BlockStatus") <> String.Empty Then
                    lblSubBlockStatus.Text = ds.Tables(0).Rows(0).Item("BlockStatus")
                End If

                lsVDBlockID = ds.Tables(0).Rows(0).Item("BlockID")

                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
                End If
                lsVDDivID = ds.Tables(0).Rows(0).Item("DivID")
                'If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
                '    'Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
                'End If
                If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
                    Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
                End If
                'If ds.Tables(0).Rows(0).Item("Name") <> String.Empty Then
                '    'Me.lblYOPName.Text = ds.Tables(0).Rows(0).Item("Name")
                'End If
                lsVDYopID = ds.Tables(0).Rows(0).Item("YOPID")


                'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
            End If
        ElseIf txtBlock.Text.Trim() = String.Empty And txtBlock.Enabled = True Then
            txtBlock.Text = String.Empty
            lsVDBlockID = String.Empty
            lblSubBlockStatus.Text = String.Empty

            Me.txtDIV.Text = String.Empty
            lsVDDivID = String.Empty

            Me.txtYOP.Text = String.Empty
            lsVDYopID = String.Empty

            'Enable vhno,vhdetailscostcode and odo reading if sub block left empty
        End If
    End Sub

    Private Sub txtT0_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT0.Leave
        If txtT0.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New VehicleDistributionPPT
            objSIV.T0Value = txtT0.Text.Trim()
            objSIV.TDecide = "T0"
            ds = VehicleDistributionBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("IT0"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IT0")
                'Me.lblT0Desc.Text = String.Empty
                'Me.txtT0.Text = String.Empty
                'lsVDT0analysisID = String.Empty
                txtT0.Focus()
                Exit Sub
            Else
                Me.lblT0Desc.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisDescp"))
                Me.txtT0.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TValue"))
                lsVDT0analysisID = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisId"))
            End If
        Else
            'Me.lblT0Desc.Text = String.Empty
            'Me.txtT0.Text = String.Empty
            'lsVDT0analysisID = String.Empty
        End If
    End Sub

    Private Sub txtT1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT1.Leave
        If txtT1.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New VehicleDistributionPPT
            objSIV.T1Value = txtT1.Text.Trim()
            objSIV.TDecide = "T1"
            ds = VehicleDistributionBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("IT1"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IT1")
                Me.lblT1Desc.Text = String.Empty
                Me.txtT1.Text = String.Empty
                lsVDT1analysisID = String.Empty
                txtT1.Focus()
                Exit Sub
            Else
                Me.lblT1Desc.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisDescp"))
                Me.txtT1.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TValue"))
                lsVDT1analysisID = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisId"))
            End If
        Else
            Me.lblT1Desc.Text = String.Empty
            Me.txtT1.Text = String.Empty
            lsVDT1analysisID = String.Empty
        End If
    End Sub

    Private Sub txtT2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT2.Leave
        If txtT2.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New VehicleDistributionPPT
            objSIV.T2Value = txtT2.Text.Trim()
            objSIV.TDecide = "T2"
            ds = VehicleDistributionBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("IT2"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IT2")
                Me.lblT2Desc.Text = String.Empty
                Me.txtT2.Text = String.Empty
                lsVDT2analysisID = String.Empty
                txtT2.Focus()
                Exit Sub
            Else
                Me.lblT2Desc.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisDescp"))
                Me.txtT2.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TValue"))
                lsVDT2analysisID = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisId"))
            End If
        Else
            Me.lblT2Desc.Text = String.Empty
            Me.txtT2.Text = String.Empty
            lsVDT2analysisID = String.Empty
        End If
    End Sub

    Private Sub txtT3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT3.Leave
        If txtT3.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New VehicleDistributionPPT
            objSIV.T3Value = txtT3.Text.Trim()
            objSIV.TDecide = "T3"
            ds = VehicleDistributionBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("IT3"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IT3")
                Me.lblT3Desc.Text = String.Empty
                Me.txtT3.Text = String.Empty
                lsVDT3analysisID = String.Empty
                txtT3.Focus()
                Exit Sub
            Else
                Me.lblT3Desc.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisDescp"))
                Me.txtT3.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TValue"))
                lsVDT3analysisID = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisId"))
            End If
        Else
            Me.lblT3Desc.Text = String.Empty
            Me.txtT3.Text = String.Empty
            lsVDT3analysisID = String.Empty
        End If
    End Sub

    Private Sub txtT4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        If txtT4.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objSIV As New VehicleDistributionPPT
            objSIV.T4Value = txtT4.Text.Trim()
            objSIV.TDecide = "T4"
            ds = VehicleDistributionBOL.TlookupSearch(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))
                'MsgBox(rm.GetString("IT4"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IT4")
                Me.lblT4Desc.Text = String.Empty
                Me.txtT4.Text = String.Empty
                lsVDT4analysisID = String.Empty
                txtT4.Focus()
                Exit Sub
            Else
                Me.lblT4Desc.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisDescp"))
                Me.txtT4.Text = GetDataValue(ds.Tables(0).Rows(0).Item("TValue"))
                lsVDT4analysisID = GetDataValue(ds.Tables(0).Rows(0).Item("TAnalysisId"))
            End If
        Else
            Me.lblT4Desc.Text = String.Empty
            Me.txtT4.Text = String.Empty
            lsVDT4analysisID = String.Empty
        End If
        txtRemarks.Focus()

    End Sub

    Function IsForeignKeyExist() As Boolean
        Dim lsErrorMessage As String = String.Empty
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If lsVDAccountID = String.Empty And txtAccountCode.Text <> String.Empty Then
            lsErrorMessage += rm.GetString("IAccountCode") & vbCrLf
        End If

        If lsVDDivID = String.Empty And txtDIV.Text <> String.Empty Then
            lsErrorMessage += rm.GetString("IDiv") & vbCrLf
        End If

        If (lsVDDivID <> String.Empty And txtDIV.Text <> String.Empty) And (lsVDBlockID = String.Empty And txtBlock.Text <> String.Empty) Then
            lsErrorMessage += rm.GetString("ISubBlock") & vbCrLf
        End If

        'Sai : Hide this check for Matured vs Vehicle
        'If txtAccountCode.Text <> String.Empty And txtBlock.Text <> String.Empty Then
        '    Dim objBOL As New GlobalBOL

        '    If Not objBOL.PbIsSameMaturityStatus(lsVDExpenditureAG, lblSubBlockStatus.Text) Then
        '        lsErrorMessage += rm.GetString("IAccountBlock") & vbCrLf
        '    End If

        'End If

        'If lsVDT0analysisID = String.Empty And txtT0.Text <> String.Empty Then
        '    lsErrorMessage += rm.GetString("IT0") & vbCrLf
        'End If

        If lsVDT1analysisID = String.Empty And txtT1.Text <> String.Empty Then
            lsErrorMessage += rm.GetString("IT1") & vbCrLf
        End If

        If lsVDT2analysisID = String.Empty And txtT2.Text <> String.Empty Then
            lsErrorMessage += rm.GetString("IT2") & vbCrLf
        End If

        If lsVDT3analysisID = String.Empty And txtT3.Text <> String.Empty Then
            lsErrorMessage += rm.GetString("IT3") & vbCrLf
        End If

        If lsVDT4analysisID = String.Empty And txtT4.Text <> String.Empty Then
            lsErrorMessage += rm.GetString("IT4") & vbCrLf
        End If

        If lsErrorMessage = String.Empty Then
            Return True
        Else
            MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            Return False
        End If

    End Function

    Function IsValidAccountAndBlockCodeCombination() As Boolean
        Dim objBOL As New GlobalBOL
        Dim RequiredField As String
        'Dim lsErrorMessage As String = String.Empty
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If txtAccountCode.Text <> String.Empty Then
            RequiredField = String.Empty

            If objBOL.IsSetMandatoryInCOA(lsVDAccountID, "AccountControl", "VEHICLE", RequiredField) Then
                If RequiredField <> String.Empty Then
                    'MessageBox.Show("This Account Code is allowed only for " & RequiredField)
                    If GlobalPPT.strLang = "en" Then
                        MessageBox.Show("This Account Code is allowed only for" & RequiredField)

                    ElseIf GlobalPPT.strLang = "ms" Then

                        MessageBox.Show("Kode Rekening diperbolehkan hanya untuk" & RequiredField)
                    End If

                    ''DisplayInfoMessage("Msg01" & RequiredField)
                    'lsErrorMessage = "This Account Code is allowed only for " & RequiredField
                    Return False
                End If
            End If
        End If

        If txtAccountCode.Text <> String.Empty And txtBlock.Text.Trim = String.Empty Then
            RequiredField = String.Empty
            If objBOL.IsSetMandatoryInCOA(lsVDAccountID, "SubType", "VEHICLE", RequiredField) Then
                If RequiredField = "Sub Block Code" Then
                    'MessageBox.Show("This Account Code required a " & RequiredField)
                    If GlobalPPT.strLang = "en" Then
                        MessageBox.Show("This Account Code required a" & RequiredField)

                    ElseIf GlobalPPT.strLang = "ms" Then

                        MessageBox.Show("Kode ini membutuhkan Account" & RequiredField)
                    End If
                    ''DisplayInfoMessage("Msg02" & RequiredField)
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

    Function CheckRequiredFields() As Boolean
        lsErrorMessage = String.Empty
        ObjValidator = New Validator
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        If ((Not ObjValidator.RequiredFieldValidator(txtT0.Text.Trim)) Or (Not ObjValidator.RequiredFieldValidator(txtVehicleCode.Text.Trim)) Or (Not ObjValidator.RequiredFieldValidator(txtAccountCode.Text.Trim)) Or (Not ObjValidator.RequiredFieldValidator(txtKm.Text.Trim))) Then

            Select Case String.Empty
                Case txtVehicleCode.Text
                    txtVehicleCode.Focus()
                    'MsgBox(rm.GetString("RVehicleCode"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("RVehicleCode")
                Case txtKm.Text
                    txtKm.Focus()
                    If txtUOM.Text = "Kms" Then
                        'MsgBox(rm.GetString("RKms"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                        DisplayInfoMessage("RKms")
                    ElseIf txtUOM.Text = "Hrs" Then
                        'MsgBox(rm.GetString("RHrs"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                        DisplayInfoMessage("RHrs")
                    End If
                Case txtAccountCode.Text
                    txtAccountCode.Focus()
                    'MsgBox(rm.GetString("RAccountCode"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("RAccountCode")

                Case txtT0.Text
                    txtT0.Focus()
                    'MsgBox(rm.GetString("RAccountCode"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("RT0")

            End Select

            Return False

        ElseIf txtPrestasiTonnageBuncheskm.Text <> String.Empty And (Not ChecklbIsDecimalInFormat(txtPrestasiTonnageBuncheskm)) Then
            'MsgBox(rm.GetString("INumeric"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("INumeric")
            txtPrestasiTonnageBuncheskm.Focus()
            Return False
        Else

            Return True
        End If

    End Function

    Function ChecklbIsDecimalInFormat(ByVal txtNumeric As TextBox) As Boolean
        'lsErrorMessage = String.Empty
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        'If (txtNumeric.Text = String.Empty Or IsNumeric(txtNumeric.Text)) Then
        Dim Expression As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,2})?$")

        If Not Expression.IsMatch(txtNumeric.Text) Then
            'lsErrorMessage = rm.GetString("IKmsFormat")
            'MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Critical + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("IKmsFormat")
            txtNumeric.Focus()
            Return False
        Else
            Return True
        End If

        'Else
        'lsErrorMessage = rm.GetString("INumeric")
        'End If
        'If lsErrorMessage <> String.Empty Then
        '    MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Critical + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")

        '    txtNumeric.Focus()
        '    Return False
        'Else
        '    Return True
        'End If
    End Function

    Function CheckRequiredFieldsOfVehicleSearch() As Boolean
        lsErrorMessage = String.Empty
        ObjValidator = New Validator

        If (chkVDDate.Checked = False) And Me.txtVehicleSearch.Text.Trim = String.Empty And Me.txtSearchVehicleName.Text.Trim = String.Empty And Me.txtSearchVehicleModel.Text.Trim = String.Empty Then
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

            lsErrorMessage += ObjValidator.Required(Me.txtVehicleSearch.Text.Trim, "TextBox", rm.GetString("MsgSearch") & vbCrLf & "")

            MsgBox(lsErrorMessage, Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
            Return False
        Else
            Return True
        End If

    End Function

    Function IsDuplicateAccountCodeAdd() As Boolean
        'Overwrite this function to always display true
        IsDuplicateAccountCodeAdd = True
        'If dgVehicleLog.Rows.Count > 0 Then
        '    For index As Integer = 0 To dgVehicleLog.Rows.Count - 1
        '        If dgVehicleLog.Rows(index).Cells("COAID").Value IsNot DBNull.Value Then
        '            If dgVehicleLog.Rows(index).Cells("COAID").Value = txtAccountCode.Text.Trim Then
        '                Return False
        '                Exit For
        '            End If

        '        End If

        '        If index = (dgVehicleLog.Rows.Count - 1) Then
        '            Return True
        '        End If
        '    Next
        'Else
        '    Return True
        'End If

    End Function

    Function IsDuplicateAccountCodeUpdate() As Boolean
        Dim lbIsDeleted As Boolean = False

        If dgVehicleLog.Rows.Count > 0 Then
            For index As Integer = 0 To dgVehicleLog.Rows.Count - 1
                lbIsDeleted = False
                If dgVehicleLog.Rows(index).Cells("COAID").Value IsNot DBNull.Value Then
                    If dgVehicleLog.Rows(index).Cells("Action").Value IsNot DBNull.Value Then
                        If dgVehicleLog.Rows(index).Cells("Action").Value = 3 Then
                            lbIsDeleted = True
                        End If
                    End If
                    If lbIsDeleted = False And dgVehicleLog.Rows(index).Cells("COAID").Value = txtAccountCode.Text.Trim And dgVehicleLog.CurrentRow.Cells("COAID").Value <> txtAccountCode.Text.Trim Then
                        Return False
                        Exit For
                    End If
                End If
                If index = (dgVehicleLog.Rows.Count - 1) Then
                    Return True
                End If
            Next
        Else
            Return True
        End If

    End Function

#End Region


    Public Overloads Sub Show(ByVal dtpDateRun As Date, _
                              ByVal VHCode As String, _
                                 ByVal UOM As String, _
                                  ByVal VHID As String, _
                               ByVal parent As IWin32Window)



        Me.MdiParent = parent
        Me.Dock = DockStyle.Fill
        Me.Show()

        Me.dtpDate.Value = dtpDateRun
        Me.txtVehicleCode.Text = VHCode
        'Me.txtUOM.Text = UOM

        Me.dtpDate.Enabled = False
        Me.txtVehicleCode.Enabled = False
        Me.ibtnSearchVehicleCode.Enabled = False

        tbcVehicleDistribution.TabPages.Remove(tbpgViewVRB)

        ResetMainControls()
        ResetRequiredControls()
        ResetControls()

        lsVHID = VHID
        lsUOM = UOM

        Me.BindVehicleDistributionByVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))
        Me.AssignDistributionValuesForVehicleCode(Me.txtVehicleCode.Text.Trim, New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day))



        Select Case (lsUOM)
            Case "Hrs"
                txtStartHrs.Focus()
                'cmbStartHrs.Focus()
            Case "Kms"
                txtKm.Focus()
        End Select

        If Not objUserLoginBOl.Privilege(btnAdd, tspAddView, tmsEditView, tmsDeleteView, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        Me.dtpDate.Enabled = False
        Me.txtVehicleCode.Enabled = False
        Me.ibtnSearchVehicleCode.Enabled = False
        Me.btnResetAll.Enabled = False

        tbcVehicleDistribution.TabPages.Remove(tbpgViewVRB)
        ConvertKmsToHrsText(lsUOM)
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()

    End Sub

    Private Sub dgVehicleLog_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgVehicleLog.DataError
        Dim errorData As DataGridViewDataErrorEventArgs = e
    End Sub
End Class
