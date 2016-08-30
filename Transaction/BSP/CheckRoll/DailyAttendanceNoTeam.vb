Imports CheckRoll_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT

Public Class DailyAttendanceNoTeam
    'Public ConnectionClass As New Connection
    Public LStringCtrl As String = String.Empty
    Public Ltanggal As String = String.Empty
    Public LDailyDistributionID As String = String.Empty
    Public memdailyot As String = String.Empty

    Public View As Boolean 'View Grid Premi

    Public LSource As String = String.Empty
    Public LFormula As String = String.Empty

    Public LUsername As String = String.Empty
    Public LEstateId As String = String.Empty
    Public LEstateName As String = String.Empty

    Public lNIK As String = String.Empty
    Public lEmpName As String = String.Empty
    Public lEmpId As String = String.Empty
    Public LEmpCode As String = String.Empty
    Public lTLocation As String = String.Empty
    Public LbasicRate As String = String.Empty
    Public Lcategory As String = String.Empty
    Private hasilot As Decimal
    Private MemHk As String = String.Empty

    Public lAttendanceCode As String = String.Empty
    Public LTimeBasic As String = String.Empty
    Public lActiveMonthYearID As String = String.Empty

    Public lAttSetupId As String = String.Empty
    Public LRemarks As String = String.Empty

    Public LDiv As String = String.Empty
    Public LYOP As String = String.Empty
    Public LBlockName As String = String.Empty
    Public LBlockId As String = String.Empty
    Public LStatusBlock As String = String.Empty

    Public LStation As String = String.Empty
    Public LVehicle As String = String.Empty


    Public LCOA As String = String.Empty
    Public LCOADesc As String = String.Empty
    Public LCOAID As String = String.Empty

    Public LEstateType As String = String.Empty


    Public LActivity As String = String.Empty

    Public LVehicleID As String = String.Empty
    Public LVehicleCode As String = String.Empty

    Public LT0 As String = String.Empty
    Public LT1 As String = String.Empty
    Public LT2 As String = String.Empty
    Public LT3 As String = String.Empty
    Public LT4 As String = String.Empty
    Public LT5 As String = String.Empty
    Public Hasil As Boolean

    Private DailyAttendanceAdapter As DailyAttendance_DAL
    Private DailyReceptionAdapter As DailyReceiption_Dal
    Private DailyDistributionAdapter As DailyActivityDistribution_DaL
    Private DailyOTDetailAdapter As OTDetailDAL
    Private DailyDetailPremiAdapter As PremiTargetDAL

    'Public _CensussPPT As New Census_PPT
    Public _GlobatPtt As New GlobalPPT

    Public DTDaily_Attendance As DataTable = New DataTable
    Public DTDaily_Reception As DataTable = New DataTable
    Public DTDaily_Distribution As DataTable = New DataTable
    Public DTOT_Detail As DataTable = New DataTable
    Public DTPremi_Detail As DataTable = New DataTable
    Public DTPREMIDRIVER As DataTable = New DataTable
    Public Shared AttDate As Date
    Private rowIndexGrid As Integer = -1

    Private Sub btnsearchNIK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearchNIK.Click
        NIKLookUp.txtMandor.Text = "N"
        AttDate = dtpRDate.Value
        NIKLookUp.Parameter.Text = "NoTeam"
        NIKLookUp._Mandor = ""
        NIKLookUp.cmbMandorKrani.Enabled = True
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            dtpRDate.Enabled = False
            lblEmpId.Text = ""
            ResetDailyDistribution()
            ResetDailyAttend()
            btnAdd.Enabled = True
            btnAdd.Visible = True
            btnUpdte.Visible = False
            lblDailDetId.Text = ""
            Me.lNIK = NIKLookUp._lNIK
            Me.lEmpName = NIKLookUp._lEmpName
            Me.lTLocation = NIKLookUp._lTLocation
            Me.txtNIK.Text = Me.lNIK
            Me.lblnameDisp.Text = Me.lEmpName
            Me.lblEmpId.Text = NIKLookUp._lEmpid
            Me.lblTLocation.Text = NIKLookUp._lTLocation
            Me.txtBasicRate.Text = NIKLookUp._BasicRate
            Me.txtOTDivider.Text = NIKLookUp._OTdivider
            Me.lblmandor.Text = NIKLookUp._Mandor
            Me.lblRestday.Text = NIKLookUp._Restday
            Me.lblCategory.Text = NIKLookUp._Category

            ' Jum'at, 20 Nov 2009, 17:09
            SetTAnalysisDefaultValue()
            ' END Jum'at, 20 Nov 2009, 17:09

            If lblCategory.Text = "KT" Then
                Dim DTKT As DataTable
                DTKT = CheckRoll_BOL.DailyAttendanceBOL.CRKTView(lblEmpId.Text)
                If DTKT.Rows.Count = 1 Then

                    ' Sabtu, 21 Nov 2009, 00:29
                    If DTKT.Rows(0).IsNull("HIPMonthlyRate") Then

                        txtBasicRate.Text = "0"
                        MessageBox.Show("Please setup Basic Rate for this Employee to calculate OT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                        txtBasicRate.Text = DTKT.Rows(0).Item("HIPMonthlyRate").ToString()
                        If txtOTDivider.Text = String.Empty Then
                            txtOTDivider.Text = "0"

                            ' Sabtu, 21  Nov 2009, 14:49
                            MessageBox.Show("Please setup Basic Rate /OT Divider for this Employee to calculate OT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            'txtBasicRate.Text = Val(txtBasicRate.Text) / 30
                            ' Sabtu, 21  Nov 2009, 14:49
                            txtBasicRate.Text = Convert.ToDecimal(txtBasicRate.Text) / Convert.ToDecimal(txtOTDivider.Text)
                        End If

                    End If

                ElseIf DTKT.Rows.Count = 0 Then
                    MsgBox("Please setup Basic Rate for this Employee to calculate OT", MsgBoxStyle.Critical + MsgBoxStyle.Information, "Information")
                End If
            End If

            ' Rabu, 18 Nov 2009, 10:26
            ' COAID untuk karyawan Category KT (HIP) langsung diambil dari CREmployeeHIP
            If lblCategory.Text = "KT" Then

                Dim dtHIP As DataTable
                dtHIP = DailyAttendance_DAL.CREmployeeHIPSelect(lblEmpId.Text)

                If dtHIP.Rows.Count > 0 Then
                    If dtHIP.Rows(0).IsNull("COAID") Then

                        MessageBox.Show("Activity for this KT Employee has not been setup yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        txtMainAct.Text = dtHIP.Rows(0).Item("COACode").ToString()
                        lblCOAID.Text = dtHIP.Rows(0).Item("COAID").ToString()
                        lblCoaDesc.Text = dtHIP.Rows(0).Item("COADescp").ToString()

                        ' Jum'at, 20 Nov 2009, 17:00
                        ' by GUE
                        ' tambah OvertimeCOA
                        Dim DTCOA As DataTable
                        Dim OvertimeCOACode As String

                        OvertimeCOACode = txtMainAct.Text.Substring(0, txtMainAct.Text.Length - 3)
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
                        ' END Jum'at, 20 Nov 2009, 17:00

                    End If

                Else
                    MessageBox.Show("Activity for this KT Employee has not been setup yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
            ' END Rabu, 18 Nov 2009, 10:26


            '===============
            'Cek For RestDay & Holiday
            '=================
            ' Rabu, 18 Nov 2009, 11:41
            ' Tambahan utk Jumaat Dibayar (J1)
            If dtpRDate.Value.DayOfWeek = DayOfWeek.Friday Then
                txtAttCode.Text = "J1"
            End If
            ' END Rabu, 18 Nov 2009, 11:41

            If lblRestday.Text.ToUpper.ToString.Trim = (dtpRDate.Value.DayOfWeek.ToString.Substring(0, 3)).ToUpper.ToString.Trim Then
                txtAttCode.Text = "M0"
            End If
            Dim DTPH As New DataTable
            DTPH = CheckRoll_BOL.DailyAttendanceBOL.CRPHoliday(dtpRDate.Value)
            If DTPH.Rows.Count = 1 Then
                txtAttCode.Text = "L0"
            End If
            '=============


            If lblmandor.Text <> "D" Then
                txtPremi.Enabled = False
                txtVehicleCode.Enabled = False
                LblPremiForDriver.ForeColor = Color.Black
                LblVehicleCode.ForeColor = Color.Black
                btnvehicle.Enabled = False
            ElseIf lblmandor.Text = "D" Then
                txtPremi.Enabled = True
                txtVehicleCode.Enabled = True
                LblPremiForDriver.ForeColor = Color.Red
                LblVehicleCode.ForeColor = Color.Red
                btnvehicle.Enabled = True
            End If

            '------------------------------------------------------
            'Select Attendance Code And Overtime Value
            '=======================================================
            DTDaily_Attendance.Clear()
            DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(dtpRDate.Value, lblEmpId.Text)
            dgvDailyAtt.DataSource = DTDaily_Attendance

            If DTDaily_Attendance.Rows.Count > 0 Then
                txtOT.Focus()
                btnAdd.Enabled = True
                btnupd.Visible = True
                btnAddA.Visible = False
                lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
                If DTDaily_Attendance.Rows(0).Item("Att Code").ToString <> Nothing Then
                    txtAttCode.Text = DTDaily_Attendance.Rows(0).Item("Att Code").ToString
                End If
                If DTDaily_Attendance.Rows(0).Item("Daily OT").ToString <> Nothing Then
                    txtDailyOT.Text = DTDaily_Attendance.Rows(0).Item("Daily OT").ToString
                End If

                txtOTvalue.Text = DTDaily_Attendance.Rows(0).Item("OT Value").ToString
                '===================

                Dim DtAtt As DataTable = New DataTable
                DtAtt = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
                If DtAtt.Rows.Count > 0 Then
                    lblTimeBasic.Text = DtAtt.Rows(0).Item("TimesBasic").ToString
                    lblBalHK.Text = DtAtt.Rows(0).Item("TimesBasic").ToString
                    If DTDaily_Attendance.Rows(0).Item("Distribution Setup ID").ToString <> Nothing Then
                        lblDistLocID.Text = DTDaily_Attendance.Rows(0).Item("Distribution Setup ID").ToString
                    Else
                        lblDistLocID.Text = ""
                    End If

                    '===============================
                    If DtAtt.Rows(0).Item("OvertimeTimes1").ToString <> Nothing Then
                        Me.txtOT1.Text = DtAtt.Rows(0).Item("OvertimeTimes1").ToString()
                    Else
                        txtOT1.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString <> Nothing Then
                        Me.txtmax1.Text = DtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString()
                    Else
                        txtmax1.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeTimes2").ToString <> Nothing Then
                        Me.TxtOT2.Text = DtAtt.Rows(0).Item("OvertimeTimes2").ToString()
                    Else
                        TxtOT2.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString <> Nothing Then
                        Me.txtmax2.Text = DtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString()
                    Else
                        txtmax2.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeTimes3").ToString <> Nothing Then
                        Me.TxtOT3.Text = DtAtt.Rows(0).Item("OvertimeTimes3").ToString()
                    Else
                        TxtOT3.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString <> Nothing Then
                        Me.txtmax3.Text = DtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString()
                    Else
                        txtmax3.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeTimes4").ToString <> Nothing Then
                        Me.TXTOT4.Text = DtAtt.Rows(0).Item("OvertimeTimes4").ToString()
                    Else
                        TXTOT4.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString <> Nothing Then
                        Me.txtmax4.Text = DtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString()
                        txtmax4.Text = 0
                    End If

                    If DtAtt.Rows(0).Item("TimesBasic").ToString <> Nothing Then
                        Me.lblTimeBasic.Text = DtAtt.Rows(0).Item("TimesBasic").ToString()
                    End If
                    '============================
                    If DtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                        txtDailyOT.Enabled = False
                        txtOT.Enabled = False
                        txtDailyOT.Text = 0
                        txtOT.Text = 0
                    ElseIf DtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                        txtDailyOT.Enabled = True
                        txtOT.Enabled = True
                        txtDailyOT.Text = 0
                        txtOT.Text = 0
                    End If

                End If


                If DTDaily_Attendance.Rows(0).Item("Tonnage").ToString <> Nothing Then
                    txtPremi.Text = DTDaily_Attendance.Rows(0).Item("Tonnage").ToString
                End If

                If DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString <> Nothing Then
                    lblVehicleID.Text = DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString
                End If
                '--------------------------
                'Select Vehilce'
                '=========================
                Dim DTVWSLOOK As DataTable = New DataTable
                DTVWSLOOK = CheckRoll_BOL.DailyAttendanceBOL.CRMVehicleSelect(lblVehicleID.Text)
                If DTVWSLOOK.Rows.Count = 1 Then
                    txtVehicleCode.Text = DTVWSLOOK.Rows(0).Item("VHWSCode").ToString
                ElseIf DTVWSLOOK.Rows.Count <> 1 Then
                    txtVehicleCode.Text = ""
                End If

                lblAttDesc.Text = DTDaily_Attendance.Rows(0).Item("Remarks").ToString
                lblAttSetupId.Text = DTDaily_Attendance.Rows(0).Item("Attendance Setup ID").ToString

                '==================================================
                'Distribution Location Display
                '==================================================
                Dim DTDISSelect As DataTable = New DataTable
                DTDISSelect = CheckRoll_BOL.DailyAttendanceBOL.CRDistributionSetupLookup(txtLocation.Text, lblDistLocID.Text)
                If DTDISSelect.Rows.Count > 0 Then
                    If DTDISSelect.Rows(0).Item("DistributionDescp").ToString <> Nothing Then
                        txtLocation.Text = DTDISSelect.Rows(0).Item("DistributionDescp").ToString
                        If lblDistLocID.Text = "" Then
                            txtLocation.Text = ""
                        End If
                    End If
                End If

                ''===========================================================================================
                ''Daily Activity Distribution Select
                ''===========================================================================================
                DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionID.Text)
                DgvDistribution.DataSource = DTDaily_Distribution
                If DTDaily_Distribution.Rows.Count = 0 Then
                    MsgBox("Distribution has not key in for this employee", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    txtblock.Focus()
                ElseIf DTDaily_Distribution.Rows.Count > 0 Then
                    GrpDAtt.Enabled = False
                    '===========================
                    'Hitung HK Dalam Grid
                    '===========================
                    If DTDaily_Distribution.Rows.Count > 0 Then
                        Dim tothk As String = String.Empty
                        For k = 0 To DgvDistribution.Rows.Count - 1
                            tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                        Next k
                        lblBalHK.Text = Val(lblTimeBasic.Text) - Val(tothk)
                    End If
                End If

                dtpRDate.Enabled = False

            ElseIf DTDaily_Attendance.Rows.Count = 0 Then
                Me.txtAttCode.Focus()
                btnAdd.Enabled = True
                btnAdd.Visible = True

                btnAddA.Enabled = True
                btnAddA.Visible = True

                btnupd.Visible = False
                btnUpdte.Visible = False

                txtDailyOT.Enabled = True
                gbIPRAdd.Enabled = True
                grpTA.Enabled = True
                grpDistribution.Enabled = True
                btnSaveAll.Enabled = True

                txtVehicleCode.Text = ""
                lblDailyReceptionID.Text = ""
                If txtAttCode.Text = Nothing Then
                    txtAttCode.Text = ""
                End If
                txtPremi.Text = 0
                lblVehicleID.Text = ""
                lblAttDesc.Text = ""
                txtLocation.Text = ""
                lblAttSetupId.Text = ""
                txtDailyOT.Text = 0
                txtOTvalue.Text = ""
                txtH1.Text = ""
                txtH2.Text = ""
                txtH3.Text = ""
                txtH4.Text = ""
                txtAttCode.Focus()
                DTDaily_Reception.Clear()
                DTDaily_Distribution.Clear()

            End If


            '========================================================
        ElseIf NIKLookUp.DialogResult = Windows.Forms.DialogResult.No Then
            txtNIK.Focus()
            dtpRDate.Enabled = True
        End If

    End Sub
    Private Sub btnSearchAttCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAttCode.Click
        txtOT1.Text = ""
        txtmax1.Text = ""
        TxtOT2.Text = ""
        txtmax2.Text = ""
        TxtOT3.Text = ""
        txtmax3.Text = ""
        TXTOT4.Text = ""
        txtmax4.Text = ""

        If txtNIK.Text = "" Or lblEmpId.Text = "" Then
            MsgBox("Data on NIK is not correct", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        ElseIf txtNIK.Text <> "" Then
            AttendanceLookup.ShowDialog()

            If AttendanceLookup.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.lAttendanceCode = AttendanceLookup._AttCode
                Me.LRemarks = AttendanceLookup._AttDesc
                Me.lAttSetupId = AttendanceLookup._AttSetupId
                Me.txtAttCode.Text = Me.lAttendanceCode
                Me.lblAttDesc.Text = Me.LRemarks
                Me.lblAttSetupId.Text = Me.lAttSetupId

                Me.txtOT1.Text = AttendanceLookup._OT1
                Me.txtmax1.Text = AttendanceLookup._MaxOT1

                Me.TxtOT2.Text = AttendanceLookup._OT2
                Me.txtmax2.Text = AttendanceLookup._MaxOT2

                Me.TxtOT3.Text = AttendanceLookup._OT3
                Me.txtmax3.Text = AttendanceLookup._MaxOT3

                Me.TXTOT4.Text = AttendanceLookup._OT4
                Me.txtmax4.Text = AttendanceLookup._MaxOT4

                Me.lblTimeBasic.Text = AttendanceLookup._LTimeBasic
                lblBalHK.Text = AttendanceLookup._LTimeBasic
                If txtPremi.Enabled = True Then
                    Me.txtPremi.Focus()
                ElseIf txtPremi.Enabled = False Then
                    txtDailyOT.Focus()
                End If

                If Val(lblTimeBasic.Text) = 0 Then
                    gbIPRAdd.Enabled = False
                    grpTA.Enabled = False
                    grpDistribution.Enabled = False
                ElseIf Val(lblTimeBasic.Text) > 0 Then
                    gbIPRAdd.Enabled = True
                    grpTA.Enabled = True
                    grpDistribution.Enabled = True
                End If

                '-----------------
                'CEK Overtime Setup
                '------------------
                Dim DTAttSetSelect As DataTable = New DataTable
                DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
                If DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString = Nothing And Val(lblTimeBasic.Text) <> 0 Then
                    MsgBox("Overtime rate setup missing", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    txtDailyOT.Enabled = False
                    txtDailyOT.Text = "0"
                    txtOT.Enabled = False
                    txtOT.Text = "0"
                ElseIf DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString <> Nothing And Val(lblTimeBasic.Text) <> 0 Then
                    txtDailyOT.Enabled = True
                    txtDailyOT.Text = "0"
                    txtOT.Enabled = True
                    txtOT.Text = "0"
                End If

                If lblmandor.Text = "D" Then
                    LblPremiForDriver.ForeColor = Color.Red
                    LblVehicleCode.ForeColor = Color.Red
                    txtPremi.Enabled = True
                    txtVehicleCode.Enabled = True
                    btnvehicle.Enabled = True
                ElseIf lblmandor.Text <> "D" Then
                    LblPremiForDriver.ForeColor = Color.Black
                    LblVehicleCode.ForeColor = Color.Black
                    txtPremi.Enabled = False
                    txtVehicleCode.Enabled = False
                    btnvehicle.Enabled = False
                End If
            End If
        End If



    End Sub
    Private Sub btnSearchLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchLocation.Click
        DistributionSetupLookup.ShowDialog()

        If DistributionSetupLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtLocation.Text = DistributionSetupLookup.DistributionDescp
            Me.lblDistLocID.Text = DistributionSetupLookup.DistributionSetupID
            Me.txtStation.Focus()
        End If



    End Sub

    Private Sub btnSearchblock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchblock.Click

        Dim SubBlockLookupForm As VHMasterSubBlockLookup = New VHMasterSubBlockLookup()
        SubBlockLookupForm.ShowDialog()

        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            'TANDAI
            '==============
            Me.txtblock.Text = SubBlockLookupForm.psBlockName
            Me.txtdiv.Text = SubBlockLookupForm.psDIVName
            Me.txtyop.Text = SubBlockLookupForm.psYopName
            Me.lblBlockID.Text = SubBlockLookupForm.psBlockId
            Me.lblDivId.Text = SubBlockLookupForm.psDIVID
            Me.lblYOPID.Text = SubBlockLookupForm.psYopID
            Me.lblStatusBlock.Text = SubBlockLookupForm.psBlockStatus

            '===============================
            'VIEW PREMI DRIVER

            Dim DTPREMIDRIVER As DataTable
            DTPREMIDRIVER = DailyAttendance_DAL.CRPremiDriver(lblBlockID.Text, lblAttSetupId.Text)
            DgDriverPremi.DataSource = DTPREMIDRIVER
            If DTPREMIDRIVER.Rows.Count > 0 Then
                btnViewPremi.Visible = True
            ElseIf DTPREMIDRIVER.Rows.Count = 0 Then
                btnViewPremi.Visible = False
            End If
            '===============================

            '===============================
            'Hitung Premi Driver
            '===============================
            Dim htonnage As Integer
            Dim totPremi As Integer
            totPremi = 0
            txtDriverPremi.Text = 0
            htonnage = FormatNumber(Val(txtPremi.Text), 2)


            If DgDriverPremi.Rows.Count > 0 And Val(txtPremi.Text) > 0 Then
                For i = 0 To DgDriverPremi.Rows.Count - 1
                    If htonnage >= Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                        htonnage = Val(htonnage) - Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value)
                        totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                        txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                        '-----------------------------
                        If DTPremi_Detail.Rows.Count = 0 Then
                            AddPremiDetailGrid()
                        End If
                        'UPDATE DETAIL TARGET TONNAGE
                        '==============================
                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalTonnage") = FormatNumber(Val(txtPremi.Text), 2)
                        If i = 0 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 1 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 2 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 3 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 4 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        '=====================
                    ElseIf htonnage < Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                        If Val(htonnage) <= (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
                            totPremi = Val(htonnage)
                            txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                            If DTPremi_Detail.Rows.Count = 0 Then
                                AddPremiDetailGrid()
                            End If
                            'UPDATE DETAIL TARGET TONNAGE
                            '==============================
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalTonnage") = FormatNumber(Val(txtPremi.Text), 2)
                            If i = 0 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 1 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 2 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 3 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 4 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            Return

                        ElseIf htonnage > (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
                            totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                            htonnage = Val(htonnage) - (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value))
                            txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))

                            If DTPremi_Detail.Rows.Count = 0 Then
                                AddPremiDetailGrid()
                            End If
                            'UPDATE DETAIL TARGET TONNAGE
                            '==============================
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalTonnage") = FormatNumber(Val(txtPremi.Text), 2)
                            If i = 0 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 1 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 2 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 3 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 4 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                        End If

                    End If
                Next i
            End If

            btnSearchMainAct.Focus()
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvehicle.Click
        If txtAttCode.Text = "" Then
            MsgBox("Please Select Attendance Code", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        ElseIf txtAttCode.Text <> "" Then
            LVehicle = txtVehicleCode.Text
            VehicleLookup._VehicleCode = LVehicle
            VehicleLookup.ShowDialog()

            If VehicleLookup.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.LVehicle = VehicleLookup._VehicleCode
                Me.LVehicleID = VehicleLookup._VehicleID
                Me.txtVehicleCode.Text = LVehicle
                Me.lblVehicleID.Text = VehicleLookup._VehicleID
                Me.lblVHDecsp.Text = VehicleLookup._VehicleDesc
                Me.txtblock.Focus()
            End If

        End If


    End Sub

    Private Sub txtAttCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAttCode.GotFocus
        If txtAttCode.Text = String.Empty Then
            lblAttDesc.Text = String.Empty
        End If
    End Sub
    Private Sub txtAttCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAttCode.KeyDown
        txtOT1.Text = ""
        txtmax1.Text = ""
        TxtOT2.Text = ""
        txtmax2.Text = ""
        TxtOT3.Text = ""
        txtmax3.Text = ""
        TXTOT4.Text = ""
        txtmax4.Text = ""
        If e.KeyCode = Keys.Enter Then
            If txtAttCode.Text = "" And txtNIK.Text <> "" Then
                ' btnSearchAttCode.Focus()
                txtAttCode.Focus()

            ElseIf txtAttCode.Text = "" And txtNIK.Text <> "" Then
                MsgBox("Please Key in NIK, mandatory Field", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                Return
            ElseIf e.KeyCode = Keys.Enter And txtAttCode.Text <> "" Then
                Dim DTAttSetSelect As DataTable = New DataTable
                DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, "")
                If DTAttSetSelect.Rows.Count > 0 Then
                    lblAttSetupId.Text = DTAttSetSelect.Rows(0).Item("AttendanceSetupID").ToString()
                    lblAttDesc.Text = DTAttSetSelect.Rows(0).Item("Att Descp").ToString()
                    txtAttCode.Text = DTAttSetSelect.Rows(0).Item("Att Code").ToString()

                    '==============================================================
                    If DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString <> Nothing Then
                        Me.txtOT1.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString()
                    Else
                        txtOT1.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours1").ToString <> Nothing Then
                        Me.txtmax1.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours1").ToString()
                    Else
                        txtmax1.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeTimes2").ToString <> Nothing Then
                        Me.TxtOT2.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes2").ToString()
                    Else
                        TxtOT2.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours2").ToString <> Nothing Then
                        Me.txtmax2.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours2").ToString()
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeTimes3").ToString <> Nothing Then
                        Me.TxtOT3.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes3").ToString()
                    Else
                        TxtOT3.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours3").ToString <> Nothing Then
                        Me.txtmax3.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours3").ToString()
                    Else
                        txtmax3.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeTimes4").ToString <> Nothing Then
                        Me.TXTOT4.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes4").ToString()
                    Else
                        TXTOT4.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours4").ToString <> Nothing Then
                        Me.txtmax4.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours4").ToString()
                    Else
                        txtmax4.Text = 0
                    End If

                    If DTAttSetSelect.Rows(0).Item("TimesBasic").ToString <> Nothing Then
                        Me.lblTimeBasic.Text = DTAttSetSelect.Rows(0).Item("TimesBasic").ToString()
                        lblBalHK.Text = DTAttSetSelect.Rows(0).Item("TimesBasic").ToString()
                    End If
                    '=======================================================================
                    If txtPremi.Enabled = True Then
                        Me.txtPremi.Focus()
                    ElseIf txtPremi.Enabled = False Then
                        txtDailyOT.Focus()
                    End If

                    If Val(lblTimeBasic.Text) = 0 Then
                        gbIPRAdd.Enabled = False
                        grpTA.Enabled = False
                        grpDistribution.Enabled = False
                    ElseIf Val(lblTimeBasic.Text) > 0 Then
                        gbIPRAdd.Enabled = True
                        grpTA.Enabled = True
                        grpDistribution.Enabled = True
                    End If




                    '-----------------
                    'CEK Overtime Setup
                    '------------------

                    'Dim DtOT As New DataTable()
                    'DtOT = DailyAttendanceWithTeam_DAL.GetAttCodeInReception()
                    'Dim DrOTAtt As DataRow
                    'For Each DrOTAtt In DtOT.Rows
                    '    ' For Each drOT In dgvDailyAttendance.Rows
                    '    If (DrOTAtt("AttendanceCode").ToString = txtAttendanceCode.Text.Trim) Then
                    '        txtOTHours.Enabled = True
                    '        Exit For
                    '    Else
                    '        txtOTHours.Enabled = False
                    '        txtOTHours.Text = "0"
                    '    End If
                    '    'Next
                    'Next


                    If DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString = Nothing And Val(lblTimeBasic.Text) <> 0 Then
                        MsgBox("Overtime rate setup missing", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        txtDailyOT.Enabled = False
                        txtDailyOT.Text = "0"
                        txtOT.Enabled = False
                        txtOT.Text = "0"

                        If txtblock.Enabled = True Then
                            txtblock.Focus()
                        ElseIf txtblock.Enabled = False Then
                            txtStation.Focus()
                        End If

                    ElseIf DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString <> Nothing And Val(lblTimeBasic.Text) <> 0 Then
                        txtDailyOT.Enabled = True
                        txtDailyOT.Text = "0"
                        txtOT.Enabled = True
                        txtOT.Text = "0"
                        If lblmandor.Text = "D" Then
                            LblPremiForDriver.ForeColor = Color.Red
                            LblVehicleCode.ForeColor = Color.Red
                            txtPremi.Enabled = True
                            txtVehicleCode.Enabled = True
                            btnvehicle.Enabled = True
                            txtDailyOT.Focus()
                        Else
                            LblPremiForDriver.ForeColor = Color.Black
                            LblVehicleCode.ForeColor = Color.Black
                            txtPremi.Enabled = False
                            txtVehicleCode.Enabled = False
                            btnvehicle.Enabled = False
                            txtDailyOT.Focus()
                        End If

                    End If

                ElseIf DTAttSetSelect.Rows.Count = 0 Then
                    MsgBox(" Attendance Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtAttCode.Text = ""
                    lblAttDesc.Text = ""
                    txtAttCode.Focus()

                End If


            End If
        End If

    End Sub
    Private Sub txtAttCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAttCode.LostFocus
        If txtAttCode.Text <> Nothing Then
            txtOT1.Text = ""
            txtmax1.Text = ""
            TxtOT2.Text = ""
            txtmax2.Text = ""
            TxtOT3.Text = ""
            txtmax3.Text = ""
            TXTOT4.Text = ""
            txtmax4.Text = ""

            Dim DTAttSetSelect As DataTable = New DataTable
            DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
            If DTAttSetSelect.Rows.Count > 0 Then
                lblAttSetupId.Text = DTAttSetSelect.Rows(0).Item("AttendanceSetupID").ToString()
                lblAttDesc.Text = DTAttSetSelect.Rows(0).Item("Att Descp").ToString()
                txtAttCode.Text = DTAttSetSelect.Rows(0).Item("Att Code").ToString()

                '==============================================================
                If DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString <> Nothing Then
                    Me.txtOT1.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString()
                Else
                    txtOT1.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours1").ToString <> Nothing Then
                    Me.txtmax1.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours1").ToString()
                Else
                    txtmax1.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeTimes2").ToString <> Nothing Then
                    Me.TxtOT2.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes2").ToString()
                Else
                    TxtOT2.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours2").ToString <> Nothing Then
                    Me.txtmax2.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours2").ToString()
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeTimes3").ToString <> Nothing Then
                    Me.TxtOT3.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes3").ToString()
                Else
                    TxtOT3.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours3").ToString <> Nothing Then
                    Me.txtmax3.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours3").ToString()
                Else
                    txtmax3.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeTimes4").ToString <> Nothing Then
                    Me.TXTOT4.Text = DTAttSetSelect.Rows(0).Item("OvertimeTimes4").ToString()
                Else
                    TXTOT4.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours4").ToString <> Nothing Then
                    Me.txtmax4.Text = DTAttSetSelect.Rows(0).Item("OvertimeMaxOTHours4").ToString()
                Else
                    txtmax4.Text = 0
                End If

                If DTAttSetSelect.Rows(0).Item("TimesBasic").ToString <> Nothing Then
                    Me.lblTimeBasic.Text = DTAttSetSelect.Rows(0).Item("TimesBasic").ToString()
                End If
                '=======================================================================

                If Val(lblTimeBasic.Text) = 0 Then
                    gbIPRAdd.Enabled = False
                    grpTA.Enabled = False
                    grpDistribution.Enabled = False
                ElseIf Val(lblTimeBasic.Text) > 0 Then
                    gbIPRAdd.Enabled = True
                    grpTA.Enabled = True
                    grpDistribution.Enabled = True
                End If
                '--------------------
                'CEK Overtime Setup
                '--------------------
                If DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString = Nothing And Val(lblTimeBasic.Text) <> 0 Then
                    txtDailyOT.Enabled = False
                    txtDailyOT.Text = "0"
                    txtOT.Enabled = False
                    txtOT.Text = "0"
                ElseIf DTAttSetSelect.Rows(0).Item("OvertimeTimes1").ToString <> Nothing And Val(lblTimeBasic.Text) <> 0 Then
                    txtDailyOT.Enabled = True
                    txtDailyOT.Text = "0"
                    txtOT.Enabled = True
                    txtOT.Text = "0"

                    If lblmandor.Text = "D" Then
                        LblPremiForDriver.ForeColor = Color.Red
                        LblVehicleCode.ForeColor = Color.Red
                        txtPremi.Enabled = True
                        txtVehicleCode.Enabled = True
                        btnvehicle.Enabled = True
                    Else
                        LblPremiForDriver.ForeColor = Color.Black
                        LblVehicleCode.ForeColor = Color.Black
                        txtPremi.Enabled = False
                        txtVehicleCode.Enabled = False
                        btnvehicle.Enabled = False
                    End If

                End If



            ElseIf DTAttSetSelect.Rows.Count = 0 Then
                txtAttCode.Text = ""
                lblAttDesc.Text = " Attendance Code Not Valid"
                txtAttCode.Focus()

            End If


        End If
    End Sub

    Private Sub txtNIK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNIK.GotFocus
        If txtNIK.Text = String.Empty Then
            lblEmpId.Text = String.Empty
            lblnameDisp.Text = String.Empty
        End If
    End Sub
    Private Sub txtNIK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIK.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblmandor.Text = ""
            lblnameDisp.Text = ""
            If txtNIK.Text = "" Then
                'btnsearchNIK.Focus()
                txtNIK.Focus()

            ElseIf txtNIK.Text <> "" Then
                txtAttCode.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            txtVehicleCode.Focus()
        End If

    End Sub
    Private Sub DailyAttendanceNoTeam_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '===============================================================
        'Update Premi Driver (Hanya Terjadi Jika telah ada Reception)
        If Val(txtDriverPremi.Text) > 0 And DTDaily_Reception.Rows.Count > 0 Then
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Driver Premi") = FormatNumber(Val(txtDriverPremi.Text), 2)
            DailyAttendanceAdapter.Update(DTDaily_Attendance)
            View = False
            DgDriverPremi.Visible = False
            btnViewPremi.Visible = False
        End If

        '===============================================================

        Dim ModifiedRowDaily As DataRow() = DTDaily_Attendance.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRowDaly As DataRow() = DTDaily_Attendance.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRowDaily As DataRow() = DTDaily_Attendance.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim ModifiedRowRecp As DataRow() = DTDaily_Reception.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRowRecp As DataRow() = DTDaily_Reception.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRowRecp As DataRow() = DTDaily_Reception.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim ModifiedRowDistb As DataRow() = DTDaily_Reception.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRowDistb As DataRow() = DTDaily_Reception.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRowDistb As DataRow() = DTDaily_Reception.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim ModifiedDaily As Boolean = False
        Dim ModifiedRecpt As Boolean = False
        Dim ModifiedDistb As Boolean = False


        If ModifiedRowDaily.Length > 0 Or AddedRowDaly.Length > 0 Or DeletedRowDaily.Length > 0 Then
            ModifiedDaily = True
        End If

        If ModifiedRowRecp.Length > 0 Or AddedRowRecp.Length > 0 Or DeletedRowRecp.Length > 0 Then
            ModifiedRecpt = True
        End If

        If ModifiedRowDistb.Length > 0 Or AddedRowDistb.Length > 0 Or DeletedRowDistb.Length > 0 Then
            ModifiedDistb = True
        End If

        If ModifiedDaily = True Or ModifiedRecpt = True Or ModifiedDistb = True Then
            Dim jwb As String
            jwb = MsgBox("Do you want to save your data?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If jwb = 6 Then
                DailyAttendanceAdapter.Update(DTDaily_Attendance)
                DailyReceptionAdapter.Update(DTDaily_Reception)
                DailyDistributionAdapter.Update(DTDaily_Distribution)
            End If
        End If
    End Sub

    Private Sub DailyAttendanceNoTeam_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpRDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpRDate.MaxDate = GlobalPPT.FiscalYearToDate
        DtDASearch.MinDate = GlobalPPT.FiscalYearFromDate
        DtDASearch.MaxDate = GlobalPPT.FiscalYearToDate

        If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
            dtpRDate.Value = Now
            DtDASearch.Value = Now
        End If


        txtOT.Text = 0
        txtHa.Text = 0
        txtDailyOT.Text = 0
        txtPremi.Text = 0
        View = False

        Dim DTEstate As DataTable = New DataTable
        DTEstate = CheckRoll_BOL.DailyAttendanceBOL.CREstateSelect("")
        LEstateType = DTEstate.Rows(0).Item("Type").ToString()

        If LEstateType = "Estate" Then
            txtblock.Enabled = True
            btnSearchblock.Enabled = True
            txtStation.Enabled = False
            btnStation.Enabled = False
        ElseIf LEstateType = "Mill" Then
            txtblock.Enabled = False
            btnSearchblock.Enabled = False
            txtStation.Enabled = True
            btnStation.Enabled = True
        End If



        hasilot = 0
        lblBlockID.Text = ""
        lblDailyReceptionID.Text = ""
        lblTimeBasic.Text = ""
        lblDailDetId.Text = ""
        lblDistLocID.Text = ""
        lblDistributionId.Text = ""
        lblActSelected.Text = ""
        lblStatusBlock.Text = String.Empty ' By Dadang, Ahad, 22 Nov 2009, 17:36

        'If Val((GlobalPPT.IntLoginMonth.ToString.Substring(0, Len(GlobalPPT.IntLoginMonth.ToString))).ToString()) > Val(GlobalPPT.IntActiveMonth.ToString) Then
        '    MsgBox("Your transaction has not been closed yet, In the future this screen will be disabled", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        'ElseIf Val((GlobalPPT.IntLoginMonth.ToString.Substring(0, Len(GlobalPPT.IntLoginMonth.ToString))).ToString()) < Val(GlobalPPT.IntActiveMonth.ToString) Then
        '    MsgBox("Your transaction has been closed, Only View Report Screen will be enabled in the future", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        'ElseIf Val((GlobalPPT.IntLoginMonth.ToString.Substring(0, Len(GlobalPPT.IntLoginMonth.ToString))).ToString()) = Val(GlobalPPT.IntActiveMonth.ToString) Then

        DailyAttendanceAdapter = New DailyAttendance_DAL
        DailyReceptionAdapter = New DailyReceiption_Dal
        DailyDistributionAdapter = New DailyActivityDistribution_DaL
        DailyOTDetailAdapter = New OTDetailDAL
        DailyDetailPremiAdapter = New PremiTargetDAL

        'txtNIK.Focus()
        lblUserName.Text = GlobalPPT.strUserName
        lblEstateCode.Text = GlobalPPT.strEstateCode.ToString
        lblEstateId.Text = GlobalPPT.strEstateID.ToString
        lblEstaeName.Text = GlobalPPT.strEstateName.ToString
        lActiveMonthYearID = GlobalPPT.strActMthYearID.ToString

        Me.tcDailyAttendance.SelectedTab = tabView

        Dim DTAttNoTeamView As DataTable = New DataTable
        DTAttNoTeamView = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(dtpRDate.Value, lblEmpId.Text)
        dgvDailyAtt.DataSource = DTAttNoTeamView


        'Dim DTAttNoTeamExist As DataTable = New DataTable
        'DTAttNoTeamExist = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamIsExist(lblDailyReceptionID.Text)
        'dgvDailyReception.DataSource = DTAttNoTeamExist

        DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionDetID.Text)
        DgvDistribution.DataSource = DTDaily_Distribution

        DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
        DgvOTDetail.DataSource = DTOT_Detail

        DTPremi_Detail = PremiTargetBOL.TargetDetailView("", "", "", lblBlockID.Text, lblEmpId.Text, dtpRDate.Value)
        DgvTargetDetail.DataSource = DTPremi_Detail

        '---------------------------
        'Refresh Data on Tab View Grid
        '---------------------------
        Dim DTDAViewAllND As DataTable = New DataTable
        DTDAViewAllND = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamViewAll("", txtNikview.Text, txtnameview.Text)
        dgvDailyAttView.DataSource = DTDAViewAllND
        dgvDailyAttView.Columns.Item("Date").DefaultCellStyle.Format = "dd/MM/yyyy"
        '-------------------------


        '===============================
        'VIEW PREMI DRIVER SEMENTARA
        DTPREMIDRIVER = DailyAttendance_DAL.CRPremiDriver(lblBlockID.Text, lblAttSetupId.Text)
        DgDriverPremi.DataSource = DTPREMIDRIVER

        '=================================
        arrangeview() '<========== Arrange all DatagridView
        '===============================

        SetUICulture(GlobalPPT.strLang)

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
        'End If
        dgvDailyAttView.DefaultCellStyle.BackColor = Color.White
        DgvDistribution.DefaultCellStyle.BackColor = Color.White

        ResetDailyDistribution()
        ' By Dadang Adi H
        ' Jum'at, 20 Nov 2009, 15:19
        txtOvertimeCOACode.Text = String.Empty
        lblOvertimeCOADescp.Text = String.Empty
        lblOvertimeCOAID.Text = String.Empty

        SetTAnalysisDefaultValue()
        txtnameview.Focus()

    End Sub

    Private Sub SetTAnalysisDefaultValue()
        ' Jum'at, 20 Nov 2009, 15:38
        Dim DT As DataTable

        ' Set default value utk TAnalysis 0 yaitu EstateCode nya
        DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
             "", "T0", GlobalPPT.strEstateCode)

        If DT.Rows.Count > 0 Then
            txtT0.Text = DT.Rows(0).Item("TValue").ToString()
            lblT0Id.Text = DT.Rows(0).Item("TAnalysisID").ToString()
            lblT0Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()
        End If


        ' Set default value utk TAnalysis 2 yaitu Type of work KHT-W01, KHL-W02
        'DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
        '     "", "T2", "W02")

        'txtT2.Text = DT.Rows(0).Item("TValue").ToString()
        'lblTAnalysisID_T2.Text = DT.Rows(0).Item("TAnalysisID").ToString()
        'lblTAnalysisDescp_T2.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DailyAttendanceNoTeam))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDate.Text = rm.GetString("lblDate.Text")
            lblNik.Text = rm.GetString("lblNik.Text")
            lblAttCode.Text = rm.GetString("lblAttCode.Text")
            lblOT.Text = rm.GetString("lblOT.Text")
            LblPremiForDriver.Text = rm.GetString("LblPremiForDriver.Text")
            lblName.Text = rm.GetString("lblName.Text")
            lblLocation.Text = rm.GetString("lblLocation.Text")
            LblStation.Text = rm.GetString("LblStation.Text")
            LblVehicleCode.Text = rm.GetString("LblVehicleCode.Text")
            LblActivityCode.Text = rm.GetString("LblActivityCode.Text")

            tcDailyAttendance.TabPages(0).Text = rm.GetString("tcDailyAttendance.TabPages(0).Text")
            tcDailyAttendance.TabPages(1).Text = rm.GetString("tcDailyAttendance.TabPages(1).Text")
            lblviewDate.Text = rm.GetString("lblviewDate.Text")
            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnResetAll.Text = rm.GetString("btnReset.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnAddA.Text = rm.GetString("BtnAddA.Text")
            BtnResetA.Text = rm.GetString("BtnResetA.Text")
            lblNameS.Text = rm.GetString("lblNames.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub
    Private Sub txtOT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOT.GotFocus
        memdailyot = txtOT.Text
    End Sub
    Private Sub txtOT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOT.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Hitung untuk Total OverTime
            '============================
            hasilot = 0
            For i = 0 To dgvDailyReception.Rows.Count - 1
                If DTDaily_Reception.Rows.Count > 0 Then
                    hasilot = hasilot + (dgvDailyReception.Rows(i).Cells("OT Hours").Value())
                End If

            Next i
            '===============================
            hasilot = hasilot + Val(txtOT.Text)
            If Val(hasilot) > Val(txtDailyOT.Text) Then
                MsgBox("Total Over Time more than daily Over Time", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtOT.Text = memdailyot
                Return
            End If


            If IsNumeric(txtOT.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtOT.Text = 0
                txtOT.Focus()
                Return
            ElseIf IsNumeric(txtOT.Text) = True Then
                txtT0.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            txtblock.Focus()
        End If


    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '============================
        'Hitung untuk Total OverTime
        '============================
        hasilot = 0
        If dgvDailyReception.Rows.Count > 0 Then
            For i = 0 To dgvDailyReception.Rows.Count - 1
                If DTDaily_Reception.Rows.Count > 0 Then
                    hasilot = hasilot + (dgvDailyReception.Rows(i).Cells("OT Hours").Value())
                End If
            Next i
            If Val(hasilot) < Val(txtDailyOT.Text) Or Val(hasilot) > Val(txtDailyOT.Text) Then
                '=======================================
                Dim jwb As String
                jwb = MsgBox("Overtime is not balance ,if you close then your data will be loose, Do you want to close?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Confirmation")
                If jwb = 6 Then
                    '=================================
                    Dim i, num As Integer
                    num = 0
                    For i = 0 To dgvDailyReception.Rows.Count - 1
                        num = Val(num) + 1
                        lblDailyReceptionDetID.Text = dgvDailyReception.Rows(i).Cells("Daily Receiption Det ID").Value.ToString
                        '====================
                        DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionDetID.Text)
                        DgvDistribution.DataSource = DTDaily_Distribution
                        For j = 0 To DgvDistribution.Rows.Count - 1
                            DgvDistribution.Rows.RemoveAt(DgvDistribution.CurrentRow.Index.ToString)
                        Next j
                        DailyDistributionAdapter.Update(DTDaily_Distribution)
                        '=====================
                    Next i

                    If i = Val(num) Then
                        If dgvDailyReception.Rows.Count > 0 Then
                            For k = 0 To dgvDailyReception.Rows.Count - 1
                                dgvDailyReception.Rows.RemoveAt(dgvDailyReception.CurrentRow.Index.ToString)
                            Next k
                            DailyReceptionAdapter.Update(DTDaily_Reception)
                        End If
                    End If
                    '==================================
                    Me.Close()
                End If

            ElseIf Val(hasilot) = Val(txtDailyOT.Text) Then
                Me.Close()
            End If
            '=======================================
        ElseIf dgvDailyReception.Rows.Count = 0 Then
            Me.Close()
        End If
    End Sub
    Private Sub txtStation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStation.KeyDown
        If e.KeyCode = Keys.Enter And txtStation.Text = "" Then
            btnStation.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtStation.Text <> "" Then
            Dim DTSTLOOK As DataTable = New DataTable
            DTSTLOOK = CheckRoll_BOL.LookUpBOL.CRStationSelect("", txtStation.Text)

            If DTSTLOOK.Rows.Count = 1 Then
                txtStation.Text = DTSTLOOK.Rows(0).Item("StationCode").ToString()
                lblStationDesc.Text = DTSTLOOK.Rows(0).Item("StationDescp").ToString()
                lblStationId.Text = DTSTLOOK.Rows(0).Item("StationID").ToString()
                txtMainAct.Focus()
            ElseIf DTSTLOOK.Rows.Count = 0 Then
                MsgBox(" Station Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtStation.Focus()
            End If

        End If

    End Sub
    Private Sub txtLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnAddA.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtLocation.Text = "" Then
            btnSearchLocation.Focus()

        ElseIf e.KeyCode = Keys.Escape And txtLocation.Text = "" Then
            btnAddA.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtLocation.Text <> "" Then
            Dim DTDISSelect As DataTable = New DataTable
            DTDISSelect = CheckRoll_BOL.DailyAttendanceBOL.CRDistributionSetupLookup(txtLocation.Text, lblLocation.Text)
            If DTDISSelect.Rows.Count = 1 Then
                txtLocation.Text = DTDISSelect.Rows(0).Item("DistributionDescp").ToString()
                lblDistLocID.Text = DTDISSelect.Rows(0).Item("DistributionSetupID").ToString()
                btnAddA.Focus()
            ElseIf DTDISSelect.Rows.Count = 0 Then
                MsgBox(" Distribution Location Description is Not valid, Please Select", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtLocation.Text = ""
                txtLocation.Focus()
            End If

        End If
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVehicleCode.KeyDown
       

        If e.KeyCode = Keys.Escape Then
            txtDailyOT.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtVehicleCode.Text = "" Then
            ' btnvehicle.Focus()
            txtblock.Focus()
        ElseIf e.KeyCode = Keys.Escape And txtVehicleCode.Text = "" Then
            txtOT.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtVehicleCode.Text <> "" Then
            Dim DTVWSLOOK As DataTable = New DataTable
            DTVWSLOOK = CheckRoll_BOL.LookUpBOL.CRSelectVehicle(txtVehicleCode.Text, "")
            If DTVWSLOOK.Rows.Count = 1 Then
                lblVHDecsp.Text = DTVWSLOOK.Rows(0).Item("VH Descp").ToString()
                txtVehicleCode.Text = DTVWSLOOK.Rows(0).Item("Vh Code").ToString()
                lblVehicleID.Text = DTVWSLOOK.Rows(0).Item("VHID").ToString()
                txtblock.Focus()
            ElseIf DTVWSLOOK.Rows.Count = 0 Then
                MsgBox(" Vehicle Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtVehicleCode.Focus()
                txtVehicleCode.Text = ""
            End If


        End If
       
    End Sub
    Private Sub txtblock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtblock.KeyDown
        If e.KeyCode = Keys.Escape Then
            ' btnSearchMainAct.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtblock.Text = "" Then
            'btnSearchblock.Focus()
            txtMainAct.Focus()

        ElseIf e.KeyCode = Keys.Escape And txtblock.Text = "" Then
            txtMainAct.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtblock.Text <> "" Then

            Dim DTSBSelect As DataTable = New DataTable
            DTSBSelect = CheckRoll_BOL.LookUpBOL.CRSubBlockSelect(txtblock.Text)
            If DTSBSelect.Rows.Count = 1 Then
                txtblock.Text = DTSBSelect.Rows(0).Item("BlockName").ToString()
                txtdiv.Text = DTSBSelect.Rows(0).Item("DivName").ToString()
                txtyop.Text = DTSBSelect.Rows(0).Item("YOP").ToString()
                lblBlockID.Text = DTSBSelect.Rows(0).Item("BlockID").ToString()
                lblYOPID.Text = DTSBSelect.Rows(0).Item("YOPID").ToString()
                lblDivId.Text = DTSBSelect.Rows(0).Item("DivID").ToString()
                lblStatusBlock.Text = DTSBSelect.Rows(0).Item("BlockStatus").ToString()
                txtMainAct.Focus()

                '===============================
                'VIEW PREMI DRIVER

                Dim DTPREMIDRIVER As DataTable
                DTPREMIDRIVER = DailyAttendance_DAL.CRPremiDriver(lblBlockID.Text, lblAttSetupId.Text)
                DgDriverPremi.DataSource = DTPREMIDRIVER
                If DTPREMIDRIVER.Rows.Count > 0 Then
                    btnViewPremi.Visible = True
                ElseIf DTPREMIDRIVER.Rows.Count = 0 Then
                    btnViewPremi.Visible = False
                    DTPremi_Detail.Clear()
                End If


                '===============================
                'Hitung Premi Driver
                '===============================
                Dim htonnage As Integer
                Dim totPremi As Integer
                totPremi = 0
                txtDriverPremi.Text = 0
                htonnage = FormatNumber(Val(txtPremi.Text), 2)


                If DgDriverPremi.Rows.Count > 0 Then
                    For i = 0 To DgDriverPremi.Rows.Count - 1
                        If htonnage >= Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                            htonnage = htonnage - Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value)
                            totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                            txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                            '-----------------------------
                            If DTPremi_Detail.Rows.Count = 0 Then
                                AddPremiDetailGrid()
                            End If
                            'UPDATE DETAIL TARGET TONNAGE
                            '==============================
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalTonnage") = FormatNumber(Val(txtPremi.Text), 2)
                            If i = 0 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 1 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 2 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 3 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 4 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            '=====================
                        ElseIf htonnage < Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                            If Val(htonnage) <= (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
                                totPremi = Val(htonnage)
                                txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                                If DTPremi_Detail.Rows.Count = 0 Then
                                    AddPremiDetailGrid()
                                End If
                                'UPDATE DETAIL TARGET TONNAGE
                                '==============================
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalTonnage") = FormatNumber(Val(txtPremi.Text), 2)
                                If i = 0 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 1 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 2 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 3 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 4 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                Return

                            ElseIf htonnage > (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
                                totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                                htonnage = Val(htonnage) - (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value))
                                txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))

                                If DTPremi_Detail.Rows.Count = 0 Then
                                    AddPremiDetailGrid()
                                End If
                                'UPDATE DETAIL TARGET TONNAGE
                                '==============================
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TotalTonnage") = FormatNumber(Val(txtPremi.Text), 2)
                                If i = 0 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 1 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 2 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 3 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                                If i = 4 Then
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                                End If
                            End If

                        End If
                    Next i
                End If


                '===============================


            ElseIf DTSBSelect.Rows.Count = 0 Then
                MsgBox(" Block Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                DTPREMIDRIVER.Clear()
                DTPremi_Detail.Clear()
                txtblock.Text = ""
                txtblock.Focus()
            End If

        ElseIf e.KeyCode = Keys.Escape Then
            txtMainAct.Focus()
        End If

    End Sub

    Private Sub btnSearchMainAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchMainAct.Click
        COALookup.strAcctExpenditureAG = lblStatusBlock.Text
        COALookup.ShowDialog()

        If COALookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblCoaDesc.Text = COALookup.strAcctDescp
            Me.txtMainAct.Text = COALookup.strAcctcode
            Me.lblCOAID.Text = COALookup.strAcctId
            Me.txtOldCoa.Text = COALookup.strOldAccountCode

            ' Jum'at, 20 Nov 2009, 15:24
            ' by GUE
            ' tambah OvertimeCOA
            'Dim DTCOA As DataTable
            'Dim OvertimeCOACode As String

            If Not String.IsNullOrEmpty(txtMainAct.Text) Then
                'Commented by Nelson jun 21-2010
                'OvertimeCOACode = txtMainAct.Text.Substring(0, txtMainAct.Text.Length - 3)
                'OvertimeCOACode = OvertimeCOACode + "002"

                'DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(OvertimeCOACode, lblStatusBlock.Text)

                'If DTCOA.Rows.Count > 0 Then
                '    txtOvertimeCOACode.Text = OvertimeCOACode
                '    lblOvertimeCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
                '    lblOvertimeCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()

                'Else
                '    txtOvertimeCOACode.Text = String.Empty
                '    lblOvertimeCOADescp.Text = String.Empty
                '    lblOvertimeCOAID.Text = String.Empty

                'End If
                'end
            End If
            ' END Jum'at, 20 Nov 2009, 15:24
            
            txtHa.Focus()
        End If

    End Sub

    Private Sub txtHa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHa.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtT0.Focus()
        ElseIf e.KeyCode = Keys.Enter And txtT0.Text = "" Then
            If IsNumeric(txtHa.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtHa.Text = ""
                txtHa.Focus()
                Return
            ElseIf IsNumeric(txtHa.Text) = True Then
                txtHK.Focus()
            End If

        ElseIf e.KeyCode = Keys.Enter And txtT0.Text <> "" Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub btnSearchT0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT0.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblT0.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT0Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT0.Text = _TAnalysisLookUp._TACode
            Me.lblT0Id.Text = _TAnalysisLookUp._TAID
            txtT1.Focus()
        End If
    End Sub

    Private Sub txtT0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT0.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' By Dadang
            If Not String.IsNullOrEmpty(txtT0.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T0", txtT0.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblT0Id.Text = String.Empty
                    lblT0Desc.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)

                    txtT0.Focus()
                    txtT0.Text = String.Empty

                ElseIf DT.Rows.Count = 1 Then
                    txtT0.Text = DT.Rows(0).Item("TValue").ToString()
                    lblT0Id.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblT0Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT1.Focus()
                End If

            ElseIf txtT0.Text = String.Empty Then
                'btnSearchT0.Focus()
                txtT0.Focus()
                lblT0Desc.Text = String.Empty
                lblT0Id.Text = String.Empty

                '
            End If

            'btnSearchT0.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtT1.Focus()
        End If


    End Sub

    Private Sub txtT1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' By Dadang
            If Not String.IsNullOrEmpty(txtT1.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T1", txtT1.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblT1ID.Text = String.Empty
                    lblT1Desc.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT1.Text = String.Empty
                    txtT2.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT1.Text = DT.Rows(0).Item("TValue").ToString()
                    lblT1ID.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblT1Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT2.Focus()
                End If

            ElseIf txtT1.Text = String.Empty Then
                'btnSearchT1.Focus()
                lblT1Desc.Text = String.Empty
                lblT1ID.Text = String.Empty
                txtT2.Focus()
                '
            End If

            'btnSearchT1.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtT2.Focus()
        End If


    End Sub

    Private Sub txtT2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' By Dadang
            If Not String.IsNullOrEmpty(txtT2.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T2", txtT2.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblT2Id.Text = String.Empty
                    lblT2Desc.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT2.Text = String.Empty
                    txtT3.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT2.Text = DT.Rows(0).Item("TValue").ToString()
                    lblT2Id.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblT2Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT3.Focus()
                End If

            ElseIf txtT2.Text = String.Empty Then
                ' btnSearchT2.Focus()
                lblT2Desc.Text = String.Empty
                lblT2Id.Text = String.Empty
                txtT3.Focus()
                '
            End If
            'btnSearchT2.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtT3.Focus()
        End If

    End Sub

    Private Sub txtT3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT3.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' BY Dadang
            If Not String.IsNullOrEmpty(txtT3.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T3", txtT3.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblT3Id.Text = String.Empty
                    lblT3Desc.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    txtT3.Text = String.Empty
                    txtT4.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT3.Text = DT.Rows(0).Item("TValue").ToString()
                    lblT3Id.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblT3Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()

                    txtT4.Focus()
                End If

            ElseIf txtT3.Text = String.Empty Then
                'btnSearchT3.Focus()
                lblT3Desc.Text = String.Empty
                lblT3Id.Text = String.Empty
                txtT4.Focus()
                '
            End If

            'btnSearchT3.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtT4.Focus()
        End If



    End Sub

    Private Sub txtT4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtT4.KeyDown
        If e.KeyCode = Keys.Enter Then
            'By Dadang
            If Not String.IsNullOrEmpty(txtT4.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T4", txtT4.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblT4Id.Text = String.Empty
                    lblT4Desc.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    'txtT5.Focus()
                    txtT4.Text = String.Empty
                    btnAdd.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT4.Text = DT.Rows(0).Item("TValue").ToString()
                    lblT4Id.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblT4Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()
                    btnAdd.Focus()
                    'txtT5.Focus()
                End If

            ElseIf txtT4.Text = String.Empty Then
                'btnSearchT4.Focus()
                'txtT5.Focus()
                '
                lblT4Desc.Text = String.Empty
                lblT4Id.Text = String.Empty

                btnAdd.Focus()
            End If

            'btnSearchT4.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            btnAdd.Focus()
        End If

    End Sub

    Private Sub btnSearchT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT1.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblT1.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT1Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT1.Text = _TAnalysisLookUp._TACode
            Me.lblT1ID.Text = _TAnalysisLookUp._TAID
            txtT2.Focus()
        End If
    End Sub
    Private Sub btnSearchT2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT2.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblt2.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT2Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT2.Text = _TAnalysisLookUp._TACode
            Me.lblT2Id.Text = _TAnalysisLookUp._TAID
            txtT3.Focus()
        End If
    End Sub

    Private Sub btnSearchT3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT3.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblT3.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT3Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT3.Text = _TAnalysisLookUp._TACode
            Me.lblT3Id.Text = _TAnalysisLookUp._TAID
            txtT4.Focus()
        End If
    End Sub
    Private Sub btnSearchT4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT4.Click

        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblT4.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT4Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT4.Text = _TAnalysisLookUp._TACode
            Me.lblT4Id.Text = _TAnalysisLookUp._TAID
            btnAdd.Focus()
        End If

    End Sub
    Private Sub txtMainAct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMainAct.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txtMainAct.Text = "" Then
                ' btnSearchMainAct.Focus()
                txtMainAct.Focus()

            ElseIf txtMainAct.Text <> "" Then
                txtHa.Focus()
            End If

        End If

    End Sub
    Private Sub formulaPremi()
        Dim hTonnage As Integer
        Dim totPremi As Integer
        totPremi = 0
        txtDriverPremi.Text = 0

        hTonnage = FormatNumber(Val(txtPremi.Text), 2)

        For i = 0 To DgDriverPremi.Rows.Count - 1
            If hTonnage > Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                hTonnage = hTonnage - Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value)
                totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
            ElseIf hTonnage < Val(DgDriverPremi.Rows(i).Cells("MaxBunches").Value) Then
                totPremi = Val(hTonnage)
                txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                Return
            End If
        Next i
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If lblEmpId.Text.Trim = String.Empty Then
            MsgBox("Employee is already in Team or not valid Employee", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            Return
        End If



        If txtT0.Text.Trim = String.Empty Then
            MsgBox("T0 is Mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            Return
        End If
        If Val(txtPremi.Text) > 0 And txtblock.Text = Nothing Then      '<=======================================================
            MsgBox("Field No is Mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            If txtblock.Enabled Then txtblock.Focus()
            Return
        ElseIf Val(txtOT.Text) > 0 And txtOvertimeCOACode.Text = "" Then
            MsgBox("OverTime COA is Mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtOvertimeCOACode.Focus()
            Return
        ElseIf Val(txtPremi.Text) = 0 And txtblock.Text <> String.Empty Then  '<========================================================
            If LEstateType = "Estate" Then

                If txtblock.Text <> Nothing And txtMainAct.Text <> String.Empty Then

                    ' Senin, 16 Nov 2009, 12:01

                    If IsSubBlockAlreadyInGread() <> -1 Then
                        MessageBox.Show("Field No Already in grid" + vbCrLf + _
                            "example: You can not add the similar Field No", _
                            "Information", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    'For i = 0 To DgvDistribution.Rows.Count - 1
                    '    If txtblock.Text.Substring(0, 2) = (DgvDistribution.Rows(i).Cells("Sub Block").Value.ToString.Substring(0, 2)) And txtMainAct.Text = DgvDistribution.Rows(i).Cells("Activity Code").Value.ToString Then
                    '        MsgBox("You can not add the similar sub block and Activity ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    '        If txtblock.Enabled Then txtblock.Focus()
                    '        Return
                    '        Exit For
                    '    End If
                    'Next i

                ElseIf txtMainAct.Text = String.Empty Or lblCOAID.Text = String.Empty Then
                    MsgBox("Main Activity is mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    If txtMainAct.Enabled Then txtMainAct.Focus()
                    Return
                End If
            End If

            If LEstateType = "Mill" Then
                If txtStation.Text = String.Empty Then
                    lblStationDesc.Text = ""
                    lblStationId.Text = ""
                End If

                If txtStation.Text <> Nothing Then
                    For i = 0 To dgvDailyReception.Rows.Count - 1
                        If txtStation.Text = dgvDailyReception.Rows(i).Cells("Station").Value.ToString And txtMainAct.Text = DgvDistribution.Rows(i).Cells("Activity Code").Value.ToString Then
                            MsgBox("You can not add the similar sub station and Main Activity", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                            If txtStation.Enabled Then txtStation.Focus()
                            Return
                            Exit For
                        End If
                    Next i
                ElseIf txtMainAct.Text.Trim = String.Empty Then
                    MsgBox("Main Activity is mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    If txtMainAct.Enabled Then txtMainAct.Focus()
                    Return
                ElseIf txtStation.Text.Trim <> String.Empty And lblStationId.Text = String.Empty Then
                    MsgBox("Please select the Station from lookup", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    If txtStation.Enabled Then
                        txtStation.Text = ""
                        txtStation.Focus()
                    End If

                    Return
                End If
            End If
        ElseIf Val(txtPremi.Text) = 0 And txtblock.Text = Nothing Then  '<==============================================
            If LEstateType = "Estate" Then
                If txtMainAct.Text <> String.Empty Then
                    For i = 0 To DgvDistribution.Rows.Count - 1
                        If txtMainAct.Text = DgvDistribution.Rows(i).Cells("Activity Code").Value.ToString Then
                            MsgBox("You can not add the similar Activity ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                            If txtMainAct.Enabled Then txtMainAct.Focus()
                            Return
                            Exit For
                        End If
                    Next i
                ElseIf txtMainAct.Text = String.Empty Or LblActivityCode.Text = String.Empty Then
                    MsgBox("Make sure Main Activity as mandatory field is key in correctly", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    If txtMainAct.Enabled Then txtMainAct.Focus()
                    Return
                End If
            End If

            If LEstateType = "Mill" Then
                If txtStation.Text <> Nothing Then
                    For i = 0 To dgvDailyReception.Rows.Count - 1
                        If txtStation.Text = dgvDailyReception.Rows(i).Cells("Station").Value.ToString And txtMainAct.Text = DgvDistribution.Rows(i).Cells("Activity Code").Value.ToString Then
                            MsgBox("You can not add the similar sub station and Main Activity", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                            If txtStation.Enabled Then txtStation.Focus()
                            Return
                            Exit For
                        End If
                    Next i
                ElseIf txtMainAct.Text.Trim = String.Empty Then
                    MsgBox("Main Activity must key in", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    If txtMainAct.Enabled Then txtMainAct.Focus()
                    Return
                End If
            End If
        End If


        If IsNumeric(txtOT.Text) = False Then
            MsgBox("Please key in numeric data on Daily OT", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            Return
        End If

        If IsNumeric(txtHK.Text) = False Then
            MsgBox("Please key in numeric data on HK", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            Return
        End If

        If txtHK.Text = 0 Then
            MsgBox("HK can not be (0), key in value ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            txtHK.Focus()
            Return
        End If


        '===========================
        'Hitung HK Dalam Grid
        '===========================
        MemHk = 0
        If DTDaily_Distribution.Rows.Count > 0 Then
            Dim tothk As String = String.Empty
            For k = 0 To DgvDistribution.Rows.Count - 1
                tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                MemHk = tothk
            Next k
        End If
        If Val(MemHk) + Val(txtHK.Text) > Val(lblTimeBasic.Text) Then
            MsgBox("HK Distribution is more than Total HK", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            txtHK.Text = 0
            txtHK.Focus()
            '====================
            'Hitung Balance HK
            '====================
            If DTDaily_Distribution.Rows.Count > 0 Then
                Dim tothk As String = String.Empty
                For k = 0 To DgvDistribution.Rows.Count - 1
                    tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                Next k
                lblBalHK.Text = Val(lblTimeBasic.Text) - Val(tothk)
            End If
            '=====================
            Return
        End If


        '============================
        'Hitung untuk Total OverTime
        '============================
        hasilot = 0

        If DTDaily_Distribution.Rows.Count > 0 Then
            For i = 0 To DgvDistribution.Rows.Count - 1
                hasilot = hasilot + (DgvDistribution.Rows(i).Cells("OT").Value())
            Next i
        End If

        If Val(hasilot) + Val(txtOT.Text) > Val(txtDailyOT.Text) Then
            MsgBox("Total Over Time more than daily Over Time", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            txtOT.Focus()
        ElseIf Val(hasilot) + Val(txtOT.Text) <= Val(txtDailyOT.Text) Then
            If txtAttCode.Text = "" Then
                MsgBox("Please Fill In Attendance Code", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtAttCode.Focus()
            ElseIf txtMainAct.Text = "" Then
                MsgBox("Please Fill In Activity Code", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtMainAct.Focus()
            ElseIf txtAttCode.Text = "" And txtMainAct.Text = "" Then
                MsgBox("Please key in Att.Code and Activity Code", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtAttCode.Focus()
            ElseIf txtAttCode.Text <> "" And txtMainAct.Text <> "" Then
                Try
                    adddgvDailyActivity()
                    MsgBox("Data has add, please save all", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    txtHK.Text = 0
                    txtOT.Text = 0
                    ResetDailyDistribution()

                    If txtblock.Enabled = True Then
                        txtblock.Focus()
                    ElseIf txtblock.Enabled = False Then
                        txtStation.Focus()
                    End If

                    txtChange.Text = "ADD"
                    If DgvDistribution.Rows.Count > 0 Then
                        GrpDAtt.Enabled = False
                    End If

                    '====================
                    'Hitung Balance HK
                    '====================
                    If DTDaily_Distribution.Rows.Count > 0 Then
                        Dim tothk As String = String.Empty
                        For k = 0 To DgvDistribution.Rows.Count - 1
                            tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                        Next k
                        lblBalHK.Text = Val(lblTimeBasic.Text) - Val(tothk)
                    End If
                    '=====================
                    txtOldCoa.Text = String.Empty
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If
        End If
        dtpRDate.Enabled = False
    End Sub

    Private Sub addDgvdailyatt()
        Dim newdatarow As System.Data.DataRow
        DTDaily_Attendance = dgvDailyAtt.DataSource
        newdatarow = DTDaily_Attendance.NewRow
        newdatarow.Item("Date") = dtpRDate.Value
        newdatarow.Item("Employee Name") = lblnameDisp.Text
        newdatarow.Item("Att Code") = txtAttCode.Text
        If lblVehicleID.Text <> Nothing Then
            newdatarow.Item("Vehicle ID") = lblVehicleID.Text
        End If
        newdatarow.Item("Employee Code") = txtNIK.Text
        newdatarow.Item("Employee ID") = lblEmpId.Text
        newdatarow.Item("Active Month Year Id") = lActiveMonthYearID.ToString
        newdatarow.Item("Estate Id") = lblEstateId.Text
        newdatarow.Item("Estate code") = lblEstateCode.Text
        newdatarow.Item("Tonnage") = FormatNumber(Val(txtPremi.Text), 2)
        newdatarow.Item("Daily OT") = FormatNumber(Val(txtDailyOT.Text), 2)
        newdatarow.Item("OT Value") = FormatNumber(Val(txtOTvalue.Text), 2)


        If lblVehicleID.Text <> "" Then
            newdatarow.Item("Vehicle ID") = lblVehicleID.Text
        End If

        newdatarow.Item("Attendance Setup ID") = lblAttSetupId.Text

        If lblDistLocID.Text <> "" Then
            newdatarow.Item("Distribution Setup ID") = lblDistLocID.Text
        End If

        newdatarow.Item("Other Estate Name") = txtLocation.Text
        newdatarow.Item("Created By") = lblUserName.Text
        newdatarow.Item("Created On") = dtpRDate.Value
        newdatarow.Item("Modified By") = lblUserName.Text
        newdatarow.Item("Modified On") = dtpRDate.Value
        DTDaily_Attendance.Rows.Add(newdatarow)
    End Sub

    Private Sub adddgvDailyActivity()
        Dim newdatarow As System.Data.DataRow
        DTDaily_Distribution = DgvDistribution.DataSource

        newdatarow = DTDaily_Distribution.NewRow
        newdatarow.Item("Daily Receiption ID") = lblDailyReceptionID.Text
        newdatarow.Item("Estate ID") = lblEstateId.Text
        newdatarow.Item("Estate code") = lblEstateCode.Text
        newdatarow.Item("Active Month Year ID") = lActiveMonthYearID.ToString
        newdatarow.Item("Distribution Date") = dtpRDate.Value
        newdatarow.Item("Employee ID") = lblEmpId.Text
        newdatarow.Item("COA ID") = lblCOAID.Text
        newdatarow.Item("Activity Code") = lblCOAID.Text
        newdatarow.Item("COA ID") = lblCOAID.Text

        ' Jum'at, 20 Nov 2009, 16:46
        If Not String.IsNullOrEmpty(lblOvertimeCOAID.Text) Then
            newdatarow.Item("OvertimeCOAID") = lblOvertimeCOAID.Text
            newdatarow.Item("OvertimeCOACode") = txtOvertimeCOACode.Text
            newdatarow.Item("OvertimeCOADescp") = lblOvertimeCOADescp.Text
        Else
            newdatarow.Item("OvertimeCOAID") = System.DBNull.Value
            newdatarow.Item("OvertimeCOACode") = System.DBNull.Value
            newdatarow.Item("OvertimeCOADescp") = System.DBNull.Value
        End If
        ' END Jum'at, 20 Nov 2009, 16:46

        newdatarow.Item("Activity Code") = txtMainAct.Text
        newdatarow.Item("Activity Descp") = lblCoaDesc.Text
        newdatarow.Item("HK") = FormatNumber(Val(txtHK.Text), 2)
        newdatarow.Item("Prestasi") = FormatNumber(Val(txtHa.Text), 2)

        If lblBlockID.Text <> "" Then
            newdatarow.Item("Block ID") = lblBlockID.Text
            newdatarow.Item("YOP ID") = lblYOPID.Text
            newdatarow.Item("DIV ID") = lblDivId.Text
            newdatarow.Item("Div") = txtdiv.Text
            newdatarow.Item("Yop") = txtyop.Text
            newdatarow.Item("Sub Block") = txtblock.Text
        End If

        If lblStationId.Text <> "" Then
            newdatarow.Item("Station ID") = lblStationId.Text
            newdatarow.Item("Station Code") = txtStation.Text
            newdatarow.Item("Station Descp") = lblStationDesc.Text
        End If

        If lblT0Id.Text <> "" Then
            newdatarow.Item("T0ID") = lblT0Id.Text
            newdatarow.Item("T0") = txtT0.Text
        End If
        If lblT1ID.Text <> "" Then
            newdatarow.Item("T1ID") = lblT1ID.Text
            newdatarow.Item("T1") = txtT1.Text
        End If
        If lblT2Id.Text <> "" Then
            newdatarow.Item("T2ID") = lblT2Id.Text
            newdatarow.Item("T2") = txtT2.Text
        End If
        If lblT3Id.Text <> "" Then
            newdatarow.Item("T3ID") = lblT3Id.Text
            newdatarow.Item("T3") = txtT3.Text
        End If
        If lblT4Id.Text <> "" Then
            newdatarow.Item("T4ID") = lblT4Id.Text
            newdatarow.Item("T4") = txtT4.Text
        End If
        newdatarow.Item("Total HK") = FormatNumber(Val(lblTimeBasic.Text), 2)
        newdatarow.Item("OT") = FormatNumber(Val(txtOT.Text), 2)
        newdatarow.Item("Created By") = lblUserName.Text
        newdatarow.Item("Created On") = dtpRDate.Value
        newdatarow.Item("Modified By") = lblUserName.Text
        newdatarow.Item("Modified On") = dtpRDate.Value
        DTDaily_Distribution.Rows.Add(newdatarow)
    End Sub

    Private Sub AddOTGrid()
        If Val(txtOTDivider.Text) > 0 Then
            Dim newdatarow As System.Data.DataRow
            DTOT_Detail = DgvOTDetail.DataSource
            newdatarow = DTOT_Detail.NewRow
            newdatarow.Item("EstateID") = lblEstateId.Text
            newdatarow.Item("Estatecode") = lblEstateCode.Text
            newdatarow.Item("ActiveMonthYearID") = lActiveMonthYearID.ToString
            'newdatarow.Item("GangMasterID") = ""
            'newdatarow.Item("Activity") = ""
            'newdatarow.Item("MandoreID") = ""
            'newdatarow.Item("KraniID") = ""
            newdatarow.Item("ADate") = dtpRDate.Value
            newdatarow.Item("EmpID") = lblEmpId.Text
            newdatarow.Item("OT1") = FormatNumber(Val(txtH1.Text), 2)
            newdatarow.Item("OTValue1") = FormatNumber((Val(txtH1.Text) * Val(txtOT1.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
            newdatarow.Item("OT2") = FormatNumber(Val(txtH2.Text), 2)
            newdatarow.Item("OTValue2") = FormatNumber((Val(txtH2.Text) * Val(TxtOT2.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
            newdatarow.Item("OT3") = FormatNumber(Val(txtH3.Text), 2)
            newdatarow.Item("OTValue3") = FormatNumber((Val(txtH3.Text) * Val(TxtOT3.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
            newdatarow.Item("OT4") = FormatNumber(Val(txtH4.Text), 2)
            newdatarow.Item("OTValue4") = FormatNumber((Val(txtH4.Text) * Val(TXTOT4.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
            newdatarow.Item("CreatedBy") = lblUserName.Text
            newdatarow.Item("CreatedOn") = dtpRDate.Value
            newdatarow.Item("ModifiedBy") = lblUserName.Text
            newdatarow.Item("ModifiedOn") = dtpRDate.Value
            DTOT_Detail.Rows.Add(newdatarow)
        End If
    End Sub
    Private Sub AddPremiDetailGrid()
        Dim newdatarow As System.Data.DataRow
        DTPremi_Detail = DgvTargetDetail.DataSource
        newdatarow = DTPremi_Detail.NewRow
        newdatarow.Item("EstateID") = lblEstateId.Text
        newdatarow.Item("Estatecode") = lblEstateCode.Text
        newdatarow.Item("ActiveMonthYearID") = lActiveMonthYearID.ToString
        'newdatarow.Item("GangMasterID") = ""
        'newdatarow.Item("Activity") = ""
        'newdatarow.Item("MandoreID") = ""
        'newdatarow.Item("KraniID") = ""
        If lblBlockID.Text <> "" Then
            newdatarow.Item("DivID") = lblDivId.Text
            newdatarow.Item("YOPID") = lblYOPID.Text
            newdatarow.Item("BlockID") = lblBlockID.Text
        End If
        newdatarow.Item("TotalBunches") = 0
        newdatarow.Item("TotalLooseFruits") = 0
        newdatarow.Item("TotalTonnage") = 0
        newdatarow.Item("TotalBorongan") = 0
        newdatarow.Item("TotalBoronganValue") = 0
        newdatarow.Item("RDate") = dtpRDate.Value
        newdatarow.Item("EmpID") = lblEmpId.Text
        newdatarow.Item("TBunches1") = 0
        newdatarow.Item("TValue1") = 0
        newdatarow.Item("TBunches2") = 0
        newdatarow.Item("TValue2") = 0
        newdatarow.Item("TBunches3") = 0
        newdatarow.Item("TValue3") = 0
        newdatarow.Item("TBunches4") = 0
        newdatarow.Item("TValue4") = 0
        newdatarow.Item("TBunches5") = 0
        newdatarow.Item("TValue5") = 0
        newdatarow.Item("TBunches6") = 0
        newdatarow.Item("TValue6") = 0
        newdatarow.Item("TBunches7") = 0
        newdatarow.Item("TValue7") = 0
        newdatarow.Item("TBunches8") = 0
        newdatarow.Item("TValue8") = 0
        newdatarow.Item("TBunches9") = 0
        newdatarow.Item("TValue9") = 0
        newdatarow.Item("TBunches10") = 0
        newdatarow.Item("TValue10") = 0
        newdatarow.Item("TLooseFruit1") = 0
        newdatarow.Item("TLooseFruitValue1") = 0
        newdatarow.Item("TLooseFruit2") = 0
        newdatarow.Item("TLooseFruitValue2") = 0
        newdatarow.Item("TLooseFruit3") = 0
        newdatarow.Item("TLooseFruitValue3") = 0
        newdatarow.Item("TLooseFruit4") = 0
        newdatarow.Item("TLooseFruitValue4") = 0
        newdatarow.Item("TLooseFruit5") = 0
        newdatarow.Item("TLooseFruitValue5") = 0
        newdatarow.Item("TTonnage1") = 0
        newdatarow.Item("TTonnageValue1") = 0
        newdatarow.Item("TTonnage2") = 0
        newdatarow.Item("TTonnageValue2") = 0
        newdatarow.Item("TTonnage3") = 0
        newdatarow.Item("TTonnageValue3") = 0
        newdatarow.Item("TTonnage4") = 0
        newdatarow.Item("TTonnageValue4") = 0
        newdatarow.Item("TTonnage5") = 0
        newdatarow.Item("TTonnageValue5") = 0
        newdatarow.Item("CreatedBy") = lblUserName.Text
        newdatarow.Item("CreatedOn") = dtpRDate.Value
        newdatarow.Item("ModifiedBy") = lblUserName.Text
        newdatarow.Item("ModifiedOn") = dtpRDate.Value
        DTPremi_Detail.Rows.Add(newdatarow)
    End Sub

    Private Sub getdatatext()
        ResetALL()

        Dim empid As String
        Dim tgl As Date
        Dim Row As Integer

        Row = dgvDailyAttView.CurrentCell.RowIndex
        empid = dgvDailyAttView.Rows(dgvDailyAttView.CurrentCell.RowIndex).Cells("Employee Id").Value
        tgl = dgvDailyAttView.Rows(dgvDailyAttView.CurrentCell.RowIndex).Cells("Date").Value

        DTDaily_Attendance.Clear()
        '=======================================
        DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(tgl, empid)
        dgvDailyAtt.DataSource = DTDaily_Attendance

        If DTDaily_Attendance.Rows.Count > 0 Then 'Jika Daily Attendance untuk Employee Ada
            txtOT.Focus()
            btnAdd.Enabled = True
            btnupd.Visible = True
            btnAddA.Visible = False
            GrpDAtt.Enabled = False

            txtNIK.Text = dgvDailyAttView.Item("Employee Code", Row).Value
            lblnameDisp.Text = dgvDailyAttView.Item("Employee Name", Row).Value
            lblEmpId.Text = dgvDailyAttView.Item("Employee ID", Row).Value
            dtpRDate.Text = dgvDailyAttView.Item("Date", Row).Value
            lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
            txtAttCode.Text = DTDaily_Attendance.Rows(0).Item("Att Code").ToString
            txtDailyOT.Text = DTDaily_Attendance.Rows(0).Item("Daily OT").ToString
            txtOTvalue.Text = DTDaily_Attendance.Rows(0).Item("OT Value").ToString

            '==============================
            'Cari Kode Attendance
            '===============================
            Dim dtAtt As DataTable = New DataTable
            dtAtt = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
            lblTimeBasic.Text = dtAtt.Rows(0).Item("TimesBasic").ToString
            '===============================
            If dtAtt.Rows(0).Item("OvertimeTimes1").ToString <> Nothing Then
                Me.txtOT1.Text = dtAtt.Rows(0).Item("OvertimeTimes1").ToString()
            Else
                txtOT1.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString <> Nothing Then
                Me.txtmax1.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString()
            Else
                txtmax1.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeTimes2").ToString <> Nothing Then
                Me.TxtOT2.Text = dtAtt.Rows(0).Item("OvertimeTimes2").ToString()
            Else
                TxtOT2.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString <> Nothing Then
                Me.txtmax2.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString()
            Else
                txtmax2.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeTimes3").ToString <> Nothing Then
                Me.TxtOT3.Text = dtAtt.Rows(0).Item("OvertimeTimes3").ToString()
            Else
                TxtOT3.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString <> Nothing Then
                Me.txtmax3.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString()
            Else
                txtmax3.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeTimes4").ToString <> Nothing Then
                Me.TXTOT4.Text = dtAtt.Rows(0).Item("OvertimeTimes4").ToString()
            Else
                TXTOT4.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString <> Nothing Then
                Me.txtmax4.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString()
            Else
                txtmax4.Text = ""
            End If

            If dtAtt.Rows(0).Item("TimesBasic").ToString <> Nothing Then
                Me.lblTimeBasic.Text = dtAtt.Rows(0).Item("TimesBasic").ToString()
                lblBalHK.Text = dtAtt.Rows(0).Item("TimesBasic").ToString()
            Else
                lblTimeBasic.Text = ""
            End If
            '============================
            If dtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                txtDailyOT.Enabled = False
                txtOT.Enabled = False
                txtDailyOT.Text = 0
                txtOT.Text = 0
            ElseIf dtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                txtDailyOT.Enabled = True
                txtOT.Enabled = True
                txtDailyOT.Text = 0
                txtOT.Text = 0
            End If


            If DTDaily_Attendance.Rows(0).Item("Tonnage").ToString <> Nothing Then
                txtPremi.Text = DTDaily_Attendance.Rows(0).Item("Tonnage").ToString
            End If
            If DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString <> Nothing Then
                lblVehicleID.Text = DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString
                txtVehicleCode.Enabled = True
                txtPremi.Enabled = True
                btnvehicle.Enabled = True
            Else
                lblVehicleID.Text = ""
                txtVehicleCode.Text = ""
                txtVehicleCode.Enabled = False
                txtPremi.Enabled = False
                btnvehicle.Enabled = False
            End If
            If DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString <> Nothing Then
                lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
            End If

            If DTDaily_Attendance.Rows(0).Item("Att Code").ToString <> Nothing Then
                txtAttCode.Text = DTDaily_Attendance.Rows(0).Item("Att Code").ToString
            End If

            '=================
            'Find Time Basic
            '=================
            Dim DTAttSetSelect As DataTable = New DataTable
            DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
            lblTimeBasic.Text = DTAttSetSelect.Rows(0).Item("TimesBasic").ToString
            '========================


            txtPremi.Text = DTDaily_Attendance.Rows(0).Item("Tonnage").ToString
            lblVehicleID.Text = DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString

            '=========================
            'View for Vehicle
            '=========================
            Dim DTVWSLOOK As DataTable = New DataTable
            DTVWSLOOK = CheckRoll_BOL.DailyAttendanceBOL.CRMVehicleSelect(lblVehicleID.Text)
            If DTVWSLOOK.Rows.Count > 0 Then
                txtVehicleCode.Text = DTVWSLOOK.Rows(0).Item("VHWSCode").ToString
            ElseIf DTVWSLOOK.Rows.Count = 0 Then
                txtVehicleCode.Text = ""
            End If
            '============================

            lblAttDesc.Text = DTDaily_Attendance.Rows(0).Item("Remarks").ToString
            txtLocation.Text = DTDaily_Attendance.Rows(0).Item("Distribution Setup ID").ToString
            lblAttSetupId.Text = DTDaily_Attendance.Rows(0).Item("Attendance Setup ID").ToString

            '======================
            'FIND DAILY OT DETAIL
            '======================
            DTOT_Detail.Clear()
            DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
            DgvOTDetail.DataSource = DTOT_Detail
            '======================

            ''===========================================================================================
            ''Daily Activity Distribution Select
            ''===========================================================================================
            DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionID.Text)
            DgvDistribution.DataSource = DTDaily_Distribution
            If DTDaily_Distribution.Rows.Count = 0 Then
                If txtblock.Enabled = True Then
                    txtblock.Focus()
                ElseIf txtStation.Enabled = True Then
                    txtStation.Focus()
                End If



            ElseIf DTDaily_Distribution.Rows.Count > 0 Then
                '===========================
                'Hitung HK Dalam Grid
                '===========================
                Dim tothk As String = String.Empty
                For k = 0 To DgvDistribution.Rows.Count - 1
                    tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                Next k
                lblBalHK.Text = Val(lblTimeBasic.Text) - Val(tothk)
            End If

            If dgvDailyAttView.SelectedRows(0).Cells("AttendType").Value.ToString <> Nothing Then
                lblAttDesc.Text = dgvDailyAttView.SelectedRows(0).Cells("AttendType").Value.ToString
            End If

            txtblock.Focus()
            btnAdd.Visible = True
            btnUpdte.Visible = False

            If Val(lblTimeBasic.Text) = 0 Then
                gbIPRAdd.Enabled = False
                grpTA.Enabled = False
                grpDistribution.Enabled = False
            ElseIf Val(lblTimeBasic.Text) > 0 Then
                gbIPRAdd.Enabled = True
                grpTA.Enabled = True
                grpDistribution.Enabled = True
            End If

            '=======================
            'FIND TARGET DETAIL
            '======================
            DTPremi_Detail = PremiTargetBOL.TargetDetailView("", "", "", lblBlockID.Text, lblEmpId.Text, dtpRDate.Value)
            DgvTargetDetail.DataSource = DTPremi_Detail
            '=======================

        ElseIf DTDaily_Attendance.Rows.Count = 0 Then
            MsgBox("View data Error", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            Me.tcDailyAttendance.SelectedTab = tabDailyAttendance
        End If
    End Sub
    Private Sub ResetALL()
        txtNIK.Text = ""
        txtAttCode.Text = ""
        txtOT.Text = 0
        txtPremi.Text = 0
        txtLocation.Text = ""
        txtStation.Text = ""
        txtblock.Text = ""
        txtdiv.Text = ""
        txtyop.Text = ""
        txtMainAct.Text = ""
        txtHa.Text = ""
        txtT0.Text = ""
        txtT1.Text = ""
        txtT2.Text = ""
        txtT3.Text = ""
        txtT4.Text = ""
        txtT5.Text = ""
        txtT6.Text = ""
        txtT7.Text = ""
        txtT8.Text = ""
        txtT9.Text = ""
        txtOldCoa.Text = ""
        lblT0Desc.Text = ""
        lblT1Desc.Text = ""
        lblT2Desc.Text = ""
        lblT3Desc.Text = ""
        lblT4Desc.Text = ""
        lblT5Desc.Text = ""
        lblT6Desc.Text = ""
        lblT7Desc.Text = ""
        lblT8Desc.Text = ""
        lblT9Desc.Text = ""

        txtHK.Text = 0
        lblAttDesc.Text = ""
        lblBlockID.Text = ""
        lblDivId.Text = ""
        lblYOPID.Text = ""
        lblDistLocID.Text = ""
        lblT0Desc.Text = ""
        lblT1Desc.Text = ""
        lblT2Desc.Text = ""
        lblT3Desc.Text = ""
        lblT4Desc.Text = ""
        lblT5Desc.Text = ""
        lblT6Desc.Text = ""
        lblT7Desc.Text = ""
        lblT8Desc.Text = ""
        lblT9Desc.Text = ""

        lblnameDisp.Text = ""
        lblStatusBlock.Text = ""
        lblRestday.Text = ""
        lblCoaDesc.Text = ""
        lblStatusBlock.Text = ""
        lblDailyReceptionID.Text = ""
        lblBalHK.Text = ""
        lblStationDesc.Text = ""
        lblStationId.Text = ""
        lblActSelected.Text = ""
        lblVehicleID.Text = ""
        lblVHDecsp.Text = ""
        txtVehicleCode.Text = ""
        txtPremi.Text = 0
        txtDriverPremi.Text = 0
        lblCategory.Text = ""
        lblInfoNIK.Text = ""

        ' By Dadang Adi H
        ' Jum'at, 20 Nov 2009, 15:19
        txtOvertimeCOACode.Text = String.Empty
        lblOvertimeCOADescp.Text = String.Empty
        lblOvertimeCOAID.Text = String.Empty
        LblOToldCOACode.Text = String.Empty
        ' END Jum'at, 20 Nov 2009, 15:19
        lblOTCOA.ForeColor = Color.Black
    End Sub

    Private Sub ResetDailyDistribution()
        txtOT.Text = 0
        txtHa.Text = ""
        txtblock.Text = ""
        txtdiv.Text = ""
        txtyop.Text = ""
        lblBlockID.Text = ""
        lblYOPID.Text = ""
        lblDivId.Text = ""

        txtMainAct.Text = ""
        lblCOAID.Text = ""
        lblCoaDesc.Text = ""
        lblStatusBlock.Text = String.Empty ' By Dadang, Ahad, 22 Nov 2009, 17:37

        ' By Dadang Adi H
        ' Jum'at, 20 Nov 2009, 15:19
        txtOvertimeCOACode.Text = String.Empty
        lblOvertimeCOADescp.Text = String.Empty
        lblOvertimeCOAID.Text = String.Empty
        ' END Jum'at, 20 Nov 2009, 15:19

        txtT0.Text = ""
        lblT0Desc.Text = ""
        lblT0Id.Text = ""
        lblStationDesc.Text = ""
        txtT1.Text = ""
        lblT1Desc.Text = ""
        lblT1ID.Text = ""

        txtT2.Text = ""
        lblT2Desc.Text = ""
        lblT2Id.Text = ""

        txtT3.Text = ""
        lblT3Desc.Text = ""
        lblT3Id.Text = ""

        txtT4.Text = ""
        lblT4Desc.Text = ""
        lblT4Id.Text = ""

        txtStation.Text = ""
        lblStationDesc.Text = ""
        lblStationId.Text = ""

        btnUpdte.Visible = False
        btnAdd.Visible = True
        btnSaveAll.Enabled = True
        dgvDailyReception.Enabled = True
        txtOT.Focus()
        txtOT.Text = 0
        txtHa.Text = 0
        txtT5.Text = ""
        txtT6.Text = ""
        txtT7.Text = ""
        txtT8.Text = ""
        txtT9.Text = ""

        lblStatusBlock.Text = ""
        lblDistributionId.Text = ""
        lblActSelected.Text = ""
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        ResetALL()
        ResetDailyAttend()
        GrpDAtt.Enabled = True
        DTDaily_Distribution.Clear()
        DTPremi_Detail.Clear()
        btnAdd.Visible = True
        btnUpdte.Visible = False
        lblTimeBasic.Text = 0
        txtDailyOT.Text = 0
        txtNIK.Focus()
        dtpRDate.Enabled = True

    End Sub
    Private Sub ContextMenuStrip1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click

        If ContextMenuStrip1.Items(0).Selected() Then
            getdatatext()
        ElseIf ContextMenuStrip1.Items(1).Selected() Then
            If dgvDailyAtt.Rows.Count = 0 Then
                MsgBox("Please select by Click edit", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            ElseIf dgvDailyAtt.Rows.Count > 0 Then
                If DgvDistribution.Rows.Count = 0 Then
                    Dim jwb As String
                    jwb = MsgBox("Do you want to delete this Data ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
                    If jwb = 6 Then
                        dgvDailyAtt.Rows.RemoveAt(dgvDailyAtt.CurrentRow.Index.ToString)
                        dgvDailyAttView.Rows.RemoveAt(dgvDailyAttView.CurrentRow.Index.ToString)

                        If DgvOTDetail.Rows.Count > 0 Then
                            DgvOTDetail.Rows.RemoveAt(DgvOTDetail.CurrentRow.Index.ToString) '<== Remove OTDETAIL
                        End If


                        If DgvTargetDetail.Rows.Count > 0 Then
                            DgvTargetDetail.Rows.RemoveAt(DgvTargetDetail.CurrentRow.Index.ToString) '<=== Remove Target Detail
                        End If

                        DailyAttendanceAdapter.Update(DTDaily_Attendance) '<===== Update Daily Attendance 
                        DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text) '<===== Update Daily Attendance Summary
                        DailyOTDetailAdapter.Update(DTOT_Detail) '<===== Update Daily OT Detail
                        DailyDetailPremiAdapter.Update(DTPremi_Detail) '<===== Update Premi Detail

                        MsgBox("Your data has been deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")

                        ResetALL()
                        ResetDailyAttend()
                        GrpDAtt.Enabled = True
                        DTDaily_Distribution.Clear()
                        btnAdd.Visible = True
                        btnUpdte.Visible = False
                        lblTimeBasic.Text = 0
                        txtDailyOT.Text = 0
                        txtNIK.Focus()
                        grpTA.Enabled = True
                        gbIPRAdd.Enabled = True
                    End If
                ElseIf DgvDistribution.Rows.Count > 0 Then
                    MsgBox("Data cannot be deleted, connect to Daily Activity Distribution ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                End If
                End If

        End If


    End Sub
    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        SaveDailyAttendance()
        'To check if Saving data for Daily Attendance success
        '---------------------------------------------------------
        If Hasil = False Then
            Return
        Else
            DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text)
            ' By Dadang Adi H
            ' Jum'at, 1 Jan 2010, 13:57
            CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
            ' END Jum'at, 1 Jan 2010, 13:57
        End If

        '===========================
        'Hitung HK Dalam Grid
        '===========================
        If DTDaily_Distribution.Rows.Count > 0 Then
            Dim tothk As String = String.Empty
            For k = 0 To DgvDistribution.Rows.Count - 1
                tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
            Next k
            lblBalHK.Text = Val(tothk)
            If Val(lblBalHK.Text) < Val(lblTimeBasic.Text) Then
                MsgBox("HK Distribution is less than Total HK, please distribute to save ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtHK.Text = MemHk
                txtblock.Focus()
                Return
            End If
        End If
        '================================
        'Hitung untuk Total OverTime
        '============================
        hasilot = 0
        For i = 0 To DgvDistribution.Rows.Count - 1
            If DTDaily_Distribution.Rows.Count > 0 Then
                hasilot = hasilot + (DgvDistribution.Rows(i).Cells("OT").Value())
            End If

        Next i
        '===============================
        If Val(hasilot) < Val(txtDailyOT.Text) Then
            MsgBox("Please distribute all Over Time employee first", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            txtblock.Focus()
            Return
        ElseIf Val(hasilot) > Val(txtDailyOT.Text) Then
            MsgBox("Total Over Time more than daily Over Time", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            txtblock.Focus()
            Return
        ElseIf Val(hasilot) = Val(txtDailyOT.Text) Then
            If lblDailyReceptionID.Text = "" And txtMainAct.Text = "" Then
                MsgBox("Please Complete Your Data, (Activity Code is Mandatory)", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) ',"Warning"
                txtMainAct.Focus()
                Return
            Else

                '===================================================================================================================
                Dim jwb As String
                jwb = MsgBox("Do you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
                If jwb = 6 Then
                    Try
                        '=============================================================
                        'Update Premi Driver (Hanya Terjadi Jika telah ada Reception)
                        '==============================================================
                        If DTDaily_Attendance.Rows.Count > 0 Then
                            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Driver Premi") = FormatNumber(Val(txtDriverPremi.Text), 2)
                            DailyAttendanceAdapter.Update(DTDaily_Attendance)
                            DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text) '<====== Update Summary Attendance
                            DailyAttendanceBOL.ReceptionSummaryNoTeam(lblEmpId.Text, lblBlockID.Text) '<=======Update Reception Summary 
                            DailyDetailPremiAdapter.Update(DTPremi_Detail) '<====== Update Premi Detail
                            View = False
                            DgDriverPremi.Visible = False
                            btnViewPremi.Visible = False
                        End If
                        '==============================================================
                        'Update DailyReceiptionID on Daily Activity Distribution
                        '==============================================================
                        For i = 0 To DgvDistribution.Rows.Count - 1
                            DTDaily_Distribution.Rows(i).Item("Daily Receiption ID") = lblDailyReceptionID.Text
                        Next
                        '=============================================================
                        DailyDistributionAdapter.Update(DTDaily_Distribution)

                        ' By Dadang Adi H
                        ' Selasa, 29 Dec 2009, 18:16
                        'stanley : 13-June-2011.b
                        'Blocked and added codes below with duplicated SP that use one additional input parameter                        
                        'DailyActivityDistributionWithTeam_DAL.CRDistributionSummary()
                        'DailyActivityDistributionWithTeam_DAL.CRDistributionActivitySummary()
                        ' END Selasa, 29 Dec 2009, 18:16

                        DailyActivityDistributionWithTeam_DAL.CRDistributionSummary_Daily(dtpRDate.Text)
                        DailyActivityDistributionWithTeam_DAL.CRDistributionActivitySummary_Daily(dtpRDate.Text)
                        'stanley : 13-June-2011.e

                        ' By Dadang Adi H
                        ' Jum'at, 1 Jan 2010, 13:52
                        CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                        ' END Jum'at, 1 Jan 2010, 13:52

                        MsgBox("Data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")

                        '------------------------
                        'Refresh Data View
                        '------------------------
                        Dim DTDAViewAllND As DataTable = New DataTable
                        DTDAViewAllND = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamViewAll("", txtNikview.Text, txtnameview.Text)
                        dgvDailyAttView.DataSource = DTDAViewAllND
                        dgvDailyAttView.Columns.Item("Date").DefaultCellStyle.Format = "dd/MM/yyyy"
                        '-------------------------
                        btnAdd.Visible = True
                        btnUpdte.Visible = False
                        txtChange.Text = ""
                        txtDailyOT.Text = 0
                        txtNIK.Focus()
                        GrpDAtt.Enabled = True
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox("Data cannot been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                    End Try

                End If
            End If
        End If
    End Sub
    Private Sub btnStation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStation.Click
        Dim stationlookupo As New StationLookup
        stationlookupo.ShowDialog()
        If stationlookupo.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblStationDesc.Text = stationlookupo.psStationDesc
            Me.txtStation.Text = stationlookupo.psStationCode
            Me.lblStationId.Text = stationlookupo.psStationId
            Me.txtMainAct.Focus()
        End If
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkDate.Checked = True Then
            Dim DTDAViewAllD As DataTable = New DataTable
            DTDAViewAllD = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamViewAll(DtDASearch.Value, txtNikview.Text, txtnameview.Text)
            dgvDailyAttView.DataSource = DTDAViewAllD
            dgvDailyAttView.Columns.Item("Date").DefaultCellStyle.Format = "dd/MM/yyyy"
            If DTDAViewAllD.Rows.Count = 0 Then
                MsgBox("Data not Found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            ElseIf DTDAViewAllD.Rows.Count > 0 Then
            End If
        End If

        If chkDate.Checked = False Then
            Dim DTDAViewAllND As DataTable = New DataTable
            DTDAViewAllND = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamViewAll("", txtNikview.Text, txtnameview.Text)
            dgvDailyAttView.DataSource = DTDAViewAllND
            dgvDailyAttView.Columns.Item("Date").DefaultCellStyle.Format = "dd/MM/yyyy"
            If DTDAViewAllND.Rows.Count = 0 Then
                MsgBox("Data not Found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                Return
            ElseIf DTDAViewAllND.Rows.Count > 0 Then
            End If
        End If
    End Sub
    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        arrangeview()
    End Sub

    Private Sub arrangeview()
        ' by Gue
        ' Ahad, 15 Nov 2009, 22:03
        'dgvDailyAtt.Columns.Item("Daily Distribution ID").Visible = False
        'dgvDailyAtt.Columns.Item("Estate ID").Visible = False
        'dgvDailyAtt.Columns.Item("Estate Code").Visible = False
        'dgvDailyAtt.Columns.Item("Daily Receiption ID").Visible = False
        'dgvDailyAtt.Columns.Item("Daily Receiption Det ID").Visible = False
        ' END Ahad, 15 Nov 2009, 22:03

        dgvDailyAtt.Columns.Item("Employee ID").Visible = False
        dgvDailyAtt.Columns.Item("Attendance Setup ID").Visible = False
        dgvDailyAtt.Columns.Item("Vehicle ID").Visible = False
        dgvDailyAtt.Columns.Item("Distribution Setup ID").Visible = False
        dgvDailyAtt.Columns.Item("Estate ID").Visible = False
        dgvDailyAtt.Columns.Item("Created By").Visible = False
        dgvDailyAtt.Columns.Item("Created On").Visible = False
        dgvDailyAtt.Columns.Item("Modified On").Visible = False
        dgvDailyAtt.Columns.Item("Modified By").Visible = False
        dgvDailyAtt.Columns.Item("Daily Receiption ID").Visible = False
        dgvDailyAtt.Columns.Item("Active Month Year ID").Visible = False
        dgvDailyAtt.Columns.Item("Daily Team Activity ID").Visible = False
        dgvDailyAtt.Columns.Item("Time Basic").Visible = False
        dgvDailyAtt.Columns.Item("COACode").Visible = False
        dgvDailyAtt.Columns.Item("Estate Code").Visible = False


        '=================================
        'Arrange For Daily Activity
        '================================

        DgvDistribution.Columns.Item("Daily Distribution ID").Visible = False
        DgvDistribution.Columns.Item("Estate Id").Visible = False
        DgvDistribution.Columns.Item("Estate Code").Visible = False
        DgvDistribution.Columns.Item("Daily Receiption Id").Visible = False
        DgvDistribution.Columns.Item("Daily Receiption Det Id").Visible = False
        DgvDistribution.Columns.Item("Active Month Year ID").Visible = False
        DgvDistribution.Columns.Item("Distribution Date").Visible = False
        DgvDistribution.Columns.Item("Gang Master ID").Visible = False
        DgvDistribution.Columns.Item("Employee ID").Visible = False
        DgvDistribution.Columns.Item("Total HK").Visible = False
        DgvDistribution.Columns.Item("Total OT").Visible = False
        DgvDistribution.Columns.Item("Contract ID").Visible = False
        DgvDistribution.Columns.Item("DIV ID").Visible = False
        DgvDistribution.Columns.Item("YOP ID").Visible = False
        DgvDistribution.Columns.Item("Block ID").Visible = False
        DgvDistribution.Columns.Item("COA ID").Visible = False

        ' Jum'at, 20 Nov 2009, 15:31
        ' By Dadang Adi H
        'DgvDistribution.Columns.Item("OvertimeCOAID").Visible = False
        DgvDistribution.Columns.Item("OvertimeCOACode").HeaderText = "Overtime Code"
        DgvDistribution.Columns.Item("OvertimeCOADescp").HeaderText = "Overtime Descp"
        DgvDistribution.Columns.Item("OvertimeCOAID").Visible = False
        ' END Jum'at, 20 Nov 2009, 15:31

        DgvDistribution.Columns.Item("T0").Visible = False
        DgvDistribution.Columns.Item("T0ID").Visible = False
        DgvDistribution.Columns.Item("T0 Descp").Visible = False
        DgvDistribution.Columns.Item("T1").Visible = False
        DgvDistribution.Columns.Item("T1ID").Visible = False
        DgvDistribution.Columns.Item("T1 Descp").Visible = False
        DgvDistribution.Columns.Item("T2").Visible = False
        DgvDistribution.Columns.Item("T2ID").Visible = False
        DgvDistribution.Columns.Item("T2 Descp").Visible = False
        DgvDistribution.Columns.Item("T3").Visible = False
        DgvDistribution.Columns.Item("T3ID").Visible = False
        DgvDistribution.Columns.Item("T3 Descp").Visible = False
        DgvDistribution.Columns.Item("T4").Visible = False
        DgvDistribution.Columns.Item("T4ID").Visible = False
        DgvDistribution.Columns.Item("T4 Descp").Visible = False
        DgvDistribution.Columns.Item("Round").Visible = False
        DgvDistribution.Columns.Item("VHID").Visible = False
        DgvDistribution.Columns.Item("Station ID").Visible = False
        DgvDistribution.Columns.Item("Created By").Visible = False
        DgvDistribution.Columns.Item("Created On").Visible = False
        DgvDistribution.Columns.Item("Modified By").Visible = False
        DgvDistribution.Columns.Item("Modified On").Visible = False


        '=================================
        'Arrange For Daily Attendance View All
        '================================
        dgvDailyAttView.Columns.Item("Attendance Id").Visible = False
        dgvDailyAttView.Columns.Item("Employee Id").Visible = False
        dgvDailyAttView.Columns.Item("Attendance Setup Id").Visible = False
        dgvDailyAttView.Columns.Item("Time Basic").Visible = False
        dgvDailyAttView.Columns.Item("AttendType").Visible = False


    End Sub
    Private Sub btnSearchLocation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSearchLocation.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnAddA.Focus()
        End If
    End Sub
    Private Sub btnvehicle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnvehicle.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtOT.Focus()
        End If
    End Sub
    Private Sub SaveDailyAttendance()

        Dim a, b, c, d, f, g, h, k As Object
        Dim nilaibalik As Integer
        a = txtNIK.Text
        b = txtAttCode.Text
        c = txtPremi.Text
        d = txtVehicleCode.Text
        f = txtOT1.Text
        g = TxtOT2.Text
        h = lblmandor.Text
        k = lblEmpId.Text

        If a = Nothing Or b = Nothing Or k = Nothing Then
            MsgBox("Please key in correct data on NIK & Att Code ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            Return
        End If

        If a <> Nothing And b <> Nothing And h = "D" Then
            If IsNumeric(c) = True And d = Nothing Then
                If Val(f) > 0 Or Val(g) > 0 Then
                    MsgBox("Please key in correct data on Premi & Select Vehicle", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    Return
                ElseIf Val(f) = 0 Or Val(g) = 0 Then
                    FormulaOTVALUE()
                    If dgvDailyAtt.Rows.Count = 0 Then
                        addDgvdailyatt()
                    ElseIf dgvDailyAtt.Rows.Count > 0 Then
                        '===========================
                        'Update Daily Attendance
                        '===========================
                        If dgvDailyReception.Rows.Count > 0 Then
                            MsgBox("Daily OT can not be updated, Connect with Data Reception", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "warning")
                            txtDailyOT.Text = memdailyot
                            Return
                        End If
                        btnsv.Visible = True
                        btnupd.Visible = False
                        UpdateDATT() '<======================================= Update Attendance
                        DailyOTDetailAdapter.Update(DTOT_Detail) '<=========== Update OTSummary
                        DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text) '<=======Update Summary Attendance
                        DailyAttendanceBOL.ReceptionSummaryNoTeam(lblEmpId.Text, lblBlockID.Text) '<=======Update Reception Summary 
                        Hasil = True
                        
                    End If
                    nilaibalik = DailyAttendanceAdapter.Update(DTDaily_Attendance)
                    If nilaibalik > 0 Then
                        lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
                        Hasil = True
                    End If
                    nilaibalik = 0
                End If
            ElseIf IsNumeric(c) = True And d <> Nothing Then
                Hasil = False
                FormulaOTVALUE()
                If dgvDailyAtt.Rows.Count = 0 Then
                    addDgvdailyatt()
                ElseIf dgvDailyAtt.Rows.Count > 0 Then
                    UpdateDATT()
                    Hasil = True
                End If
                nilaibalik = DailyAttendanceAdapter.Update(DTDaily_Attendance) '<======== Save data Daily Attendance
                DailyOTDetailAdapter.Update(DTOT_Detail) '<=========== Update OTSummary
                DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text) '<=======Update Summary Attendance
                DailyAttendanceBOL.ReceptionSummaryNoTeam(lblEmpId.Text, lblBlockID.Text) '<=======Update Reception Summary 
                If nilaibalik > 0 Then
                    lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
                    Hasil = True
                End If
                nilaibalik = 0
            End If
        End If

        If a <> Nothing And b <> Nothing And h <> "D" Then
            FormulaOTVALUE()
            Hasil = False
            If dgvDailyAtt.Rows.Count = 0 Then
                addDgvdailyatt()
                nilaibalik = DailyAttendanceAdapter.Update(DTDaily_Attendance) '<======== Save data Daily Attendance
                DailyOTDetailAdapter.Update(DTOT_Detail) '<=========== Update OTSummary
                DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text) '<=======Update Summary Attendance
                DailyAttendanceBOL.ReceptionSummaryNoTeam(lblEmpId.Text, lblBlockID.Text) '<=======Update Reception Summary 

            ElseIf dgvDailyAtt.Rows.Count > 0 Then
                UpdateDATT() '<================== Update Grid Attendance
                DailyAttendanceBOL.AttendSummaryNoTeam(lblEmpId.Text) 'UPDATE SUMMARY ATTENDANCE
                DailyAttendanceBOL.ReceptionSummaryNoTeam(lblEmpId.Text, lblBlockID.Text) '<=======Update Reception Summary 
                DailyOTDetailAdapter.Update(DTOT_Detail) '<=========== Update OTSummary
                Hasil = True
            End If



            If nilaibalik > 0 Then
                Hasil = True
                lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
            End If

        End If
        dtpRDate.Enabled = False
    End Sub
    Private Sub UpdateDATT()
        If DTDaily_Attendance.Rows.Count > 0 Then
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Att Code") = txtAttCode.Text
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Daily OT") = FormatNumber(Val(txtDailyOT.Text), 2)
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("OT Value") = FormatNumber(Val(txtOTvalue.Text), 2)
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Attendance Setup ID") = lblAttSetupId.Text
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Tonnage") = FormatNumber(Val(txtPremi.Text), 2)
            If lblVehicleID.Text <> "" Then
                DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Vehicle ID") = lblVehicleID.Text
            End If
            If lblDistLocID.Text <> "" Then
                DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Distribution Setup ID") = lblDistLocID.Text
            End If
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Other Estate Name") = txtLocation.Text
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Modified By") = GlobalPPT.strUserName
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Modified On") = dtpRDate.Value
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Estate Code") = GlobalPPT.strEstateCode.ToString
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Estate ID") = GlobalPPT.strEstateID.ToString
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Active Month Year ID") = GlobalPPT.strActMthYearID.ToString
        End If
    End Sub
    Private Sub UpdateOTSummary()
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("ADate") = dtpRDate.Value
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("EmpID") = lblEmpId.Text
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT1") = FormatNumber(Val(txtH1.Text), 2)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue1") = FormatNumber((Val(txtH1.Text) * Val(txtOT1.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT2") = FormatNumber(Val(txtH2.Text), 2)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue2") = FormatNumber((Val(txtH2.Text) * Val(TxtOT2.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT3") = FormatNumber(Val(txtH3.Text), 2)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue3") = FormatNumber((Val(txtH3.Text) * Val(TxtOT3.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OT4") = FormatNumber(Val(txtH4.Text), 2)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("OTValue4") = FormatNumber((Val(txtH4.Text) * Val(TXTOT4.Text) * (Val(txtBasicRate.Text) * 30) / 173), 3)
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("ModifiedBy") = lblUserName.Text
        DTOT_Detail.Rows(DgvOTDetail.CurrentCell.RowIndex).Item("ModifiedOn") = dtpRDate.Value

    End Sub
    Private Sub btnAddA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddA.Click
        'Dim a, b, c, d, f, g, h As Object
        'a = txtNIK.Text
        'b = txtAttCode.Text
        'c = txtPremi.Text
        'd = txtVehicleCode.Text
        'f = txtOT1.Text
        'g = TxtOT2.Text
        'h = lblmandor.Text

        'If a = Nothing Or b = Nothing Then
        '    MsgBox("Please complete data on NIK & Att Code", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        '    Return
        'End If

        'If a <> Nothing And b <> Nothing And h = "D" Then
        '    If IsNumeric(c) = True And d = Nothing Then
        '        If Val(f) > 0 Or Val(g) > 0 Then
        '            MsgBox("Please complete data on Premi & Select Vehicle", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        '            Return
        '        ElseIf Val(f) = 0 Or Val(g) = 0 Then
        '            FormulaOTVALUE()
        '            addDgvdailyatt()
        '            DailyAttendanceAdapter.Update(DTDaily_Attendance)
        '            'Refresh Data
        '            '==================
        '            DTDaily_Attendance.Clear()
        '            DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(dtpRDate.Value, lblEmpId.Text)
        '            dgvDailyAtt.DataSource = DTDaily_Attendance

        '            lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
        '            '===========================================
        '            If DTDaily_Attendance.Rows.Count > 0 Then
        '                btnAdd.Enabled = True
        '                btnAddA.Enabled = False
        '            ElseIf DTDaily_Attendance.Rows.Count = 0 Then
        '                btnAdd.Enabled = False
        '                btnAddA.Enabled = True
        '            End If
        '            txtOT.Focus()
        '        End If
        '    ElseIf IsNumeric(c) = True And d <> Nothing Then
        '        FormulaOTVALUE()
        '        addDgvdailyatt()
        '        DailyAttendanceAdapter.Update(DTDaily_Attendance)
        '        'Refresh Data
        '        '==================
        '        DTDaily_Attendance.Clear()
        '        DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(dtpRDate.Value, lblEmpId.Text)
        '        dgvDailyAtt.DataSource = DTDaily_Attendance
        '        lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
        '        '===========================================
        '        If DTDaily_Attendance.Rows.Count > 0 Then
        '            btnAdd.Enabled = True
        '            btnAddA.Enabled = False
        '        ElseIf DTDaily_Attendance.Rows.Count = 0 Then
        '            btnAdd.Enabled = False
        '            btnAddA.Enabled = True
        '        End If
        '        txtOT.Focus()
        '    End If
        'End If

        'If a <> Nothing And b <> Nothing And h <> "D" Then
        '    FormulaOTVALUE()
        '    addDgvdailyatt()
        '    DailyAttendanceAdapter.Update(DTDaily_Attendance)
        '    'Refresh Data
        '    '==================
        '    DTDaily_Attendance.Clear()
        '    DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(dtpRDate.Value, lblEmpId.Text)
        '    dgvDailyAtt.DataSource = DTDaily_Attendance
        '    If DTDaily_Attendance.Rows.Count > 0 Then
        '        lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
        '        '===========================================
        '        If DTDaily_Attendance.Rows.Count > 0 Then
        '            btnAdd.Enabled = True
        '            btnAddA.Enabled = False
        '        ElseIf DTDaily_Attendance.Rows.Count = 0 Then
        '            btnAdd.Enabled = False
        '            btnAddA.Enabled = True
        '        End If
        '        txtOT.Focus()
        '    End If

        'End If


    End Sub
    Private Sub dgvDailyAtt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        txtNIK.Text = dgvDailyAtt.SelectedRows(0).Cells("Employee Code").Value
        txtAttCode.Text = dgvDailyAtt.SelectedRows(0).Cells("Att Code").Value
    End Sub
    Private Sub Button1_Click_5(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupd.Click
        'If lblDailyReceptionID.Text = "" Then
        '    MsgBox("Please Select Data to Update", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
        'ElseIf lblDailyReceptionID.Text <> "" Then
        '    If dgvDailyReception.Rows.Count > 0 Then
        '        MsgBox("Daily OT can not be updated, Connect with Data Reception", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "warning")
        '        txtDailyOT.Text = memdailyot
        '        Return
        '    End If
        '    btnsv.Visible = True
        '    btnupd.Visible = False
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Att Code") = txtAttCode.Text
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Daily OT") = FormatNumber(Val(txtDailyOT.Text), 2)
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("OT Value") = FormatNumber(Val(txtOTvalue.Text), 2)
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Att Code") = txtAttCode.Text
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Attendance Setup ID") = lblAttSetupId.Text
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Tonnage") = FormatNumber(Val(txtPremi.Text), 2)

        '    If lblVehicleID.Text <> "" Then
        '        DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Vehicle ID") = lblVehicleID.Text
        '    End If

        '    If lblDistLocID.Text <> "" Then
        '        DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Distribution Setup ID") = lblDistLocID.Text
        '    End If
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Other Estate Name") = txtLocation.Text
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Modified By") = GlobalPPT.strUserName
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Modified On") = dtpRDate.Value
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Estate Code") = GlobalPPT.strEstateCode.ToString
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Estate ID") = GlobalPPT.strEstateID.ToString
        '    DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Active Month Year ID") = GlobalPPT.strActMthYearID.ToString
        '    MsgBox("Data successfully updated, click save all to confirm", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
        '    gbEnquipmentData.Enabled = False
        '    gbIPRAdd.Enabled = False
        '    grpTA.Enabled = False
        '    grpTA.Enabled = False
        '    btnSaveAll.Enabled = False
        '    btnClose.Enabled = False
        '    txtNIK.Enabled = False
        '    btnsearchNIK.Enabled = False
        '    txtAttCode.Enabled = False
        '    btnSearchAttCode.Enabled = False
        '    txtPremi.Enabled = False
        '    txtVehicleCode.Enabled = False
        '    btnvehicle.Enabled = False
        '    txtDailyOT.Enabled = False
        '    txtLocation.Enabled = False
        '    btnSearchLocation.Enabled = False
        '    btnSaveAll.Enabled = False
        'End If


    End Sub
    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DailyAttendanceAdapter.Update(DTDaily_Attendance)
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DailyAttendanceAdapter.Update(DTDaily_Attendance)
    End Sub
    Private Sub dgvDailyAtt_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDailyAtt.DoubleClick
        txtAttCode.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Att Code")
        txtAttCode.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Att Code")
        lblAttSetupId.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Attendance Setup ID")
        txtPremi.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Tonnage").ToString

        If DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Vehicle ID").ToString <> "" Then
            lblVehicleID.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Vehicle ID")

            Dim DTVWSLOOK As DataTable = New DataTable
            DTVWSLOOK = CheckRoll_BOL.DailyAttendanceBOL.CRMVehicleSelect(lblVehicleID.Text)
            If DTVWSLOOK.Rows.Count = 1 Then
                txtVehicleCode.Text = DTVWSLOOK.Rows(0).Item("VHWSCode").ToString
            ElseIf DTVWSLOOK.Rows.Count = 0 Then
                txtVehicleCode.Text = ""
            End If

        End If
        If DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Distribution Setup ID").ToString <> "" Then
            txtLocation.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Distribution Setup ID").ToString
        End If
        If DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Other Estate Name").ToString <> "" Then
            lblTLocation.Text = DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Other Estate Name")
        End If

        btnAddA.Visible = False
        btnupd.Visible = True

    End Sub
    Private Sub Button2_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsv.Click
        'Dim hasil As Integer
        'Try
        '    hasil = DailyAttendanceAdapter.Update(DTDaily_Attendance)
        '    If hasil > 1 Then
        '        MsgBox(" Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
        '    End If
        '    ResetDailyAttend()
        '    btnsv.Visible = False
        '    btnupd.Visible = False
        '    btnAddA.Enabled = True
        '    btnAddA.Visible = True
        '    btnAdd.Enabled = True
        '    txtDailyOT.Text = 0
        '    lblEmpId.Text = ""
        '    lblDistLocID.Text = ""
        '    DTDaily_Attendance.Clear()
        '    DTDaily_Reception.Clear()
        '    DTDaily_Distribution.Clear()

        '    gbEnquipmentData.Enabled = True
        '    gbIPRAdd.Enabled = True
        '    grpTA.Enabled = True
        '    grpTA.Enabled = True
        '    btnSaveAll.Enabled = True
        '    btnClose.Enabled = True
        '    txtNIK.Enabled = True
        '    btnsearchNIK.Enabled = True
        '    txtAttCode.Enabled = True
        '    btnSearchAttCode.Enabled = True
        '    txtPremi.Enabled = True
        '    txtVehicleCode.Enabled = True
        '    btnvehicle.Enabled = True
        '    txtDailyOT.Enabled = True
        '    txtLocation.Enabled = True
        '    btnSearchLocation.Enabled = True
        '    btnSaveAll.Enabled = True
        '    txtDailyOT.Enabled = True
        '    gbIPRAdd.Enabled = True
        '    grpTA.Enabled = True
        '    grpDistribution.Enabled = True
        '    btnSaveAll.Enabled = True
        '    txtNIK.Focus()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        '    MsgBox(" Your data could not be saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        'End Try
    End Sub
    Public Sub ResetDailyAttend()
        txtNIK.Text = ""
        txtAttCode.Text = ""
        txtPremi.Text = 0
        txtLocation.Text = ""
        txtVehicleCode.Text = ""
        lblAttSetupId.Text = ""
        lblDailyReceptionID.Text = ""
        lblVehicleID.Text = ""
        lblnameDisp.Text = ""
        lblAttDesc.Text = ""
        lblVehicleID.Text = ""
        lblVHDecsp.Text = ""
        lblTimeBasic.Text = 0
        lblBalHK.Text = 0
        txtDailyOT.Text = 0
        btnupd.Visible = False
        btnAddA.Visible = True
    End Sub
    Private Sub BtnResetA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnResetA.Click
        lblEmpId.Text = ""
        txtDailyOT.Text = 0
        btnAdd.Visible = True
        btnupd.Visible = False
        DTDaily_Attendance.Clear()
        DTDaily_Reception.Clear()
        DTDaily_Distribution.Clear()
        ResetDailyAttend()
        ResetALL()
        txtDailyOT.Enabled = True
        gbIPRAdd.Enabled = True
        grpTA.Enabled = True
        grpDistribution.Enabled = True
        btnSaveAll.Enabled = True
        txtPremi.Enabled = True
        txtVehicleCode.Enabled = True
        txtNIK.Focus()
    End Sub
    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DTDaily_Reception.Clear()
        DTDaily_Reception = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamIsExist(lblDailyReceptionID.Text)
        dgvDailyReception.DataSource = DTDaily_Reception
        dgvDailyReception.DataSource = DTDaily_Reception
    End Sub
    Private Sub dgvDailyReception_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDailyReception.DoubleClick
        lblDailDetId.Text = ""
        Try
            If dgvDailyReception.SelectedRows(0).Cells("Daily Receiption Det ID").Value IsNot DBNull.Value Then
                Me.lblDailDetId.Text = dgvDailyReception.SelectedRows(0).Cells("Daily Receiption Det ID").Value
            End If

            If dgvDailyReception.SelectedRows(0).Cells("OT Hours").Value IsNot DBNull.Value Then
                Me.txtOT.Text = dgvDailyReception.SelectedRows(0).Cells("OT Hours").Value
            End If

            If dgvDailyReception.SelectedRows(0).Cells("Block Name").Value IsNot DBNull.Value Then
                Me.txtblock.Text = dgvDailyReception.SelectedRows(0).Cells("Block Name").Value
            End If
            If dgvDailyReception.SelectedRows(0).Cells("Div Name").Value IsNot DBNull.Value Then
                Me.txtdiv.Text = dgvDailyReception.SelectedRows(0).Cells("Div Name").Value
            End If
            If dgvDailyReception.SelectedRows(0).Cells("YOP Name").Value IsNot DBNull.Value Then
                Me.txtyop.Text = dgvDailyReception.SelectedRows(0).Cells("YOP Name").Value
            End If
            If dgvDailyReception.SelectedRows(0).Cells("Block ID").Value IsNot DBNull.Value Then
                Me.lblBlockID.Text = dgvDailyReception.SelectedRows(0).Cells("Block ID").Value
            End If
            If dgvDailyReception.SelectedRows(0).Cells("Div ID").Value IsNot DBNull.Value Then
                Me.lblDivId.Text = dgvDailyReception.SelectedRows(0).Cells("Div ID").Value
            End If

            If dgvDailyReception.SelectedRows(0).Cells("YOP ID").Value IsNot DBNull.Value Then
                Me.lblYOPID.Text = dgvDailyReception.SelectedRows(0).Cells("YOP ID").Value
            End If
            'AN08082010- START -Added for station
            If dgvDailyReception.SelectedRows(0).Cells("Station ID").Value IsNot DBNull.Value Then
                Me.lblStationId.Text = dgvDailyReception.SelectedRows(0).Cells("Station ID").Value
            End If
            If dgvDailyReception.SelectedRows(0).Cells("Station Descp").Value IsNot DBNull.Value Then
                Me.lblStationDesc.Text = dgvDailyReception.SelectedRows(0).Cells("Station Descp").Value
            End If
            If dgvDailyReception.SelectedRows(0).Cells("Station Code").Value IsNot DBNull.Value Then
                Me.txtStation.Text = dgvDailyReception.SelectedRows(0).Cells("Station Code").Value
            End If
            'AN08082010- END-Added

            If dgvDailyReception.Rows(dgvDailyReception.CurrentCell.RowIndex).Cells("Daily Receiption Det ID").Value IsNot DBNull.Value Then
                DTDaily_Distribution.Clear()
                DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailDetId.Text)
                DgvDistribution.DataSource = DTDaily_Distribution
            End If


            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("COA Descp").Value.ToString <> Nothing Then
                txtMainAct.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("COA Descp").Value
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("COA Code").Value IsNot DBNull.Value Then
                lblCoaDesc.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("COA Code").Value
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("COA ID").Value IsNot DBNull.Value Then
                lblCOAID.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("COA ID").Value
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("Ha").Value IsNot DBNull.Value Then
                txtHa.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("Ha").Value
            End If


            '=========================================================================================

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T0").Value IsNot DBNull.Value Then
                lblT0Id.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T0").Value
            Else
                lblT0Id.Text = ""
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T1").Value IsNot DBNull.Value Then
                lblT1ID.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T1").Value
            Else
                lblT1ID.Text = ""
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T2").Value IsNot DBNull.Value Then
                lblT2Id.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T2").Value
            Else
                lblT2Id.Text = ""
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T3").Value IsNot DBNull.Value Then
                lblT3Id.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T3").Value
            Else
                lblT3Id.Text = ""
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T4").Value IsNot DBNull.Value Then
                lblT4Id.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("T4").Value
            Else
                lblT4Id.Text = ""
            End If

            If DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("Daily Distribution ID").Value IsNot DBNull.Value Then
                lblDistributionId.Text = DgvDistribution.Rows(DgvDistribution.CurrentCell.RowIndex).Cells("Daily Distribution ID").Value
            End If

            Dim DTTASelectT0 As DataTable = New DataTable
            DTTASelectT0 = CheckRoll_BOL.DailyAttendanceBOL.CRTAnalysisView(lblT0Id.Text)
            If DTTASelectT0.Rows.Count > 0 Then
                If DTTASelectT0.Rows(0).Item("TAnalysisCode").ToString() <> Nothing Then
                    txtT0.Text = DTTASelectT0.Rows(0).Item("TAnalysisCode").ToString()
                    lblT0Desc.Text = DTTASelectT0.Rows(0).Item("TAnalysisDescp").ToString()
                End If
            Else
                txtT0.Text = ""
                lblT0Desc.Text = ""
            End If

            Dim DTTASelectT1 As DataTable = New DataTable
            DTTASelectT1 = CheckRoll_BOL.DailyAttendanceBOL.CRTAnalysisView(lblT1ID.Text)
            If DTTASelectT1.Rows.Count > 0 Then
                If DTTASelectT1.Rows(0).Item("TAnalysisCode").ToString() <> Nothing Then
                    txtT1.Text = DTTASelectT1.Rows(0).Item("TAnalysisCode").ToString()
                    lblT1Desc.Text = DTTASelectT1.Rows(0).Item("TAnalysisDescp").ToString()
                End If
            Else
                txtT1.Text = ""
                lblT1Desc.Text = ""
            End If

            Dim DTTASelectT2 As DataTable = New DataTable
            DTTASelectT2 = CheckRoll_BOL.DailyAttendanceBOL.CRTAnalysisView(lblT2Id.Text)
            If DTTASelectT2.Rows.Count > 0 Then
                If DTTASelectT2.Rows(0).Item("TAnalysisCode").ToString() <> Nothing Then
                    txtT2.Text = DTTASelectT2.Rows(0).Item("TAnalysisCode").ToString()
                    lblT2Desc.Text = DTTASelectT2.Rows(0).Item("TAnalysisDescp").ToString()
                End If
            Else
                txtT2.Text = ""
                lblT2Desc.Text = ""
            End If

            Dim DTTASelectT3 As DataTable = New DataTable
            DTTASelectT3 = CheckRoll_BOL.DailyAttendanceBOL.CRTAnalysisView(lblT3Id.Text)
            If DTTASelectT3.Rows.Count > 0 Then
                If DTTASelectT3.Rows(0).Item("TAnalysisCode").ToString() <> Nothing Then
                    txtT3.Text = DTTASelectT3.Rows(0).Item("TAnalysisCode").ToString()
                    lblT3Desc.Text = DTTASelectT3.Rows(0).Item("TAnalysisDescp").ToString()
                End If
            Else
                txtT3.Text = ""
                lblT3Desc.Text = ""
            End If

            Dim DTTASelectT4 As DataTable = New DataTable
            DTTASelectT4 = CheckRoll_BOL.DailyAttendanceBOL.CRTAnalysisView(lblT4Id.Text)
            If DTTASelectT4.Rows.Count > 0 Then
                If DTTASelectT4.Rows(0).Item("TAnalysisCode").ToString() <> Nothing Then
                    txtT4.Text = DTTASelectT4.Rows(0).Item("TAnalysisCode").ToString()
                    lblT4Desc.Text = DTTASelectT4.Rows(0).Item("TAnalysisDescp").ToString()
                End If
            Else
                txtT4.Text = ""
                lblT4Desc.Text = ""
            End If

            '============================================================================================
            btnUpdte.Visible = True
            btnAdd.Visible = False
            btnSaveAll.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
            txtMainAct.Text = ""
            lblCoaDesc.Text = ""
            txtHa.Text = ""
        End Try
    End Sub
    Private Sub Button1_Click_6(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DTDaily_Distribution.Clear()
        DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionDetID.Text)
        DgvDistribution.DataSource = DTDaily_Distribution
    End Sub
    Private Sub ContextMenuStrip2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStrip2.Click
        If ContextMenuStrip2.Items(0).Selected() Then
            getdatatext()
            dgvDailyReception.Enabled = False
            btnSaveAll.Enabled = False
            btnAdd.Visible = False
            btnUpdte.Visible = True
        ElseIf ContextMenuStrip2.Items(1).Selected() Then

            If txtMainAct.Text = "" And lblDailDetId.Text = "" Then
                MsgBox("Please select data to Edit or Delete", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            ElseIf txtMainAct.Text <> "" And lblDailDetId.Text <> "" Then
                '======================
                'Cek Data for Material
                '======================
                Dim DTMATVIEW As DataTable = New DataTable
                DTMATVIEW = CheckRoll_BOL.MaterialBOL.DailyMaterialView(lblDistributionId.Text, lblCOAID.Text)
                If DTMATVIEW.Rows.Count > 0 Then
                    MsgBox("Data can not be deleted only can be updated, connect to data material", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                ElseIf DTMATVIEW.Rows.Count = 0 Then
                    Dim jwb As String
                    jwb = MsgBox("Do you want to delete this Data?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
                    If jwb = 6 Then
                        DgvDistribution.Rows.RemoveAt(DgvDistribution.CurrentRow.Index.ToString)
                        If DgvDistribution.Rows.Count > 0 Then
                            GrpDAtt.Enabled = False
                        ElseIf DgvDistribution.Rows.Count = 0 Then
                            GrpDAtt.Enabled = True
                        End If
                        txtChange.Text = "Delete"
                        MsgBox("Your data has been deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
                        DailyDistributionAdapter.Update(DTDaily_Distribution)
                        Reset()
                        btnUpdte.Visible = False
                        btnAdd.Visible = True
                        btnSaveAll.Enabled = True
                    End If
                End If

            ElseIf txtMainAct.Text <> "" And lblDailDetId.Text = "" Then
                btnUpdte.Visible = False
                btnAdd.Visible = True
                Dim jwb As String
                jwb = MsgBox("Do you want to delete this Data?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
                If jwb = 6 Then
                    DgvDistribution.Rows.RemoveAt(DgvDistribution.CurrentRow.Index.ToString)
                    DailyDistributionAdapter.Update(DTDaily_Distribution)
                    txtChange.Text = "Delete"
                    MsgBox("Your data has been deleted, please Save All to confirm", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
                    Reset()

                End If
            End If
        End If
    End Sub

    Private Function IsSubBlockAlreadyInGread() As Integer
        ' Kamis, 01 oct 2009, 15:44
        Dim rowIndex = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty
        ' Ahad, 15 Nov 2009, 20:27
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty
        Dim Activity As String = String.Empty

        If txtBlock.Text = "" Then
            Return rowIndex
        End If

        'Dim cm As CurrencyManager = CType(Me.BindingContext(dgvDailyReceiption.DataSource, dgvDailyReceiption.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)
        'Dim dr As DataRow = dv.Item(cm.Position).Row
        Dim DT_Distribution As DataTable

        DT_Distribution = DgvDistribution.DataSource

        For i As Int32 = 0 To DT_Distribution.Rows.Count - 1
            Dim row As DataRow = DT_Distribution.Rows(i)

            If row.RowState <> DataRowState.Deleted Then
                BlockNameInGrid = row.Item("Sub Block")
                DivisionInGrid = row.Item("Div")
                YOPInGrid = row.Item("YOP")
                Activity = row.Item("Activity Code")
                If BlockNameInGrid = txtblock.Text AndAlso DivisionInGrid = txtdiv.Text AndAlso YOPInGrid = txtyop.Text AndAlso Activity = txtMainAct.Text Then
                    rowIndex = i
                    Exit For
                End If
            End If
            'BlockNameInGrid = 
        Next

        Return rowIndex
    End Function

    Private Function IsSubBlockAlreadyInGreadWithOutCurrentEdit() As Integer
        ' Senin, 16 Nov 2009, 11:54
        Dim rowIndex As Integer = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty
        Dim Activity As String = String.Empty
        If txtBlock.Text = "" Then
            Return rowIndex
        End If

        'Dim cm As CurrencyManager = CType(Me.BindingContext(DgvDistribution.DataSource, DgvDistribution.DataMember), CurrencyManager)
        'Dim dv As DataView = CType(cm.List, DataView)

        Dim DT_Distribution As DataTable

        DT_Distribution = DgvDistribution.DataSource

        For i As Int32 = 0 To DT_Distribution.Rows.Count - 1
            Dim row As DataRow = DT_Distribution.Rows(i)

            If i <> DgvDistribution.CurrentCell.RowIndex Then

                If row.RowState <> DataRowState.Deleted Then
                    BlockNameInGrid = row.Item("Sub Block")
                    DivisionInGrid = row.Item("Div")
                    YOPInGrid = row.Item("YOP")
                    Activity = row.Item("Activity Code")
                    If BlockNameInGrid = txtblock.Text AndAlso DivisionInGrid = txtdiv.Text AndAlso YOPInGrid = txtyop.Text AndAlso Activity = txtMainAct.Text Then
                        rowIndex = i
                        Exit For
                    End If
                End If

            End If
        Next

        Return rowIndex
    End Function

    Private Sub btnUpdte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdte.Click
        If txtT0.Text.Trim = String.Empty Then
            MsgBox("T0 is Mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            Return
        End If

        If LEstateType = "Estate" Then

            If Not String.IsNullOrEmpty(txtblock.Text) AndAlso lblmandor.Text <> "D" Then

                ' Senin, 16 Nov 2009, 12:01

                If IsSubBlockAlreadyInGreadWithOutCurrentEdit() <> -1 Then
                    MessageBox.Show("Field No Already in grid" + vbCrLf + _
                        "example: You can not add the similar Field No", _
                        "Information", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                'For i = 0 To DgvDistribution.Rows.Count - 1
                '    If txtblock.Text.Substring(0, 2) = (DgvDistribution.Rows(i).Cells("Sub Block").Value.ToString.Substring(0, 2)) And txtMainAct.Text = DgvDistribution.Rows(i).Cells("Activity Code").Value.ToString And Val(lblROW.Text) <> Val(i) Then
                '        MsgBox("You can not add the similar sub block and Activity ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                '        txtblock.Focus()
                '        Return
                '    End If
                'Next i

                'ElseIf txtblock.Text = Nothing Or txtMainAct.Text = Nothing Then
                '    MsgBox("Sub block and Main Activity are mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                '    txtblock.Focus()
                '    Return
                'End If

                ' Ahad, 22 Nov 2009, 17:49,
                ' Sub Block g jadi mandatory lagi
            ElseIf txtMainAct.Text = Nothing Then
                MsgBox(" Main Activity are mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtMainAct.Focus()
                Return
            End If

        End If

        If LEstateType = "Mill" Then
            If txtStation.Text <> Nothing Then
                For i = 0 To dgvDailyReception.Rows.Count - 1
                    If txtStation.Text = dgvDailyReception.Rows(i).Cells("Station").Value.ToString And txtMainAct.Text = DgvDistribution.Rows(i).Cells("Activity Code").Value.ToString And Val(lblROW.Text) <> Val(i) Then
                        MsgBox("You can not add the similar sub station and Main Activity", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                        If txtStation.Enabled Then txtStation.Focus()
                        Return
                    End If
                Next i
            ElseIf txtMainAct.Text = Nothing Then
                MsgBox("Main Activity are mandatory", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                If txtMainAct.Enabled Then txtMainAct.Focus()
            ElseIf txtStation.Text <> String.Empty And lblStationId.Text = String.Empty Then
                MsgBox("Please select station from lookup", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                If txtStation.Enabled Then
                    txtStation.Text = ""
                    txtStation.Focus()
                End If

            End If
        End If

        If IsNumeric(txtOT.Text) = False Then
            MsgBox("Please key in numeric data on OT", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            txtOT.Focus()
            Return
        End If

        If IsNumeric(txtHa.Text) = False Then
            MsgBox("Please key in numeric data on Prestasi", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            txtHa.Focus()
            Return
        End If

        '===========================
        'Hitung HK Dalam Grid
        '===========================
        If DTDaily_Distribution.Rows.Count > 0 Then
            Dim tothk As String = String.Empty
            For k = 0 To DgvDistribution.Rows.Count - 1
                tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
            Next k
            lblBalHK.Text = (Val(tothk) - Val(MemHk)) + Val(txtHK.Text)
            If Val(lblBalHK.Text) > Val(lblTimeBasic.Text) Then
                MsgBox("HK Distribution is more than Total HK", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtHK.Text = MemHk
                txtHK.Focus()
                Return
            End If
        End If

        'Hitung untuk Total OverTime
        '============================
        hasilot = 0
        For i = 0 To dgvDailyReception.Rows.Count - 1
            If DTDaily_Reception.Rows.Count > 0 Then
                hasilot = hasilot + (dgvDailyReception.Rows(i).Cells("OT Hours").Value())
            End If

        Next i
        '===============================
        If Val(hasilot) - Val(memdailyot) + Val(txtOT.Text) > Val(txtDailyOT.Text) Then
            MsgBox("Total Over Time more than daily Over Time", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtOT.Text = memdailyot
            txtOT.Focus()
            Return
        End If

        Try


            If txtMainAct.Text = "" Then
                MsgBox("Please select data to update", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
                DgvDistribution.Focus()
                Return
            ElseIf txtMainAct.Text <> "" Then


                '===============================
                'VIEW PREMI DRIVER

                Dim DTPREMIDRIVER As DataTable
                DTPREMIDRIVER = DailyAttendance_DAL.CRPremiDriver(lblBlockID.Text, lblAttSetupId.Text)
                DgDriverPremi.DataSource = DTPREMIDRIVER
                If DTPREMIDRIVER.Rows.Count > 0 Then
                    btnViewPremi.Visible = True
                ElseIf DTPREMIDRIVER.Rows.Count = 0 Then
                    btnViewPremi.Visible = False
                    DTPremi_Detail.Clear()
                End If
                'End If

                If Val(txtPremi.Text) > 0 And DgDriverPremi.Rows.Count = 0 Then
                    MsgBox("Premi Rate has not been setup, Update cannot be proceed", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Information")
                    Return
                End If



                '=======================================================================================
                'Update Daily Activity Distribution
                '===================================
                DTDaily_Distribution = DgvDistribution.DataSource
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("COA ID") = lblCOAID.Text
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Activity Descp") = lblCoaDesc.Text

                ' Jum'at, 20 Nov 2009, 16:46
                ' By Dadang Adi
                If Not String.IsNullOrEmpty(lblOvertimeCOAID.Text) Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OvertimeCOAID") = lblOvertimeCOAID.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OvertimeCOACode") = txtOvertimeCOACode.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OvertimeCOADescp") = lblOvertimeCOADescp.Text
                Else
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OvertimeCOAID") = System.DBNull.Value
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OvertimeCOACode") = System.DBNull.Value
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OvertimeCOADescp") = System.DBNull.Value
                End If
                ' END Jum'at, 20 Nov 2009, 16:46

                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Prestasi") = txtHa.Text

                If lblBlockID.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Block ID") = lblBlockID.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("YOP ID") = lblYOPID.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("DIV ID") = lblDivId.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Sub Block") = txtblock.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Yop") = txtyop.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Div") = txtdiv.Text
                End If

                If lblStationId.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Station ID") = lblStationId.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Station Descp") = lblStationDesc.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Station Code") = txtStation.Text
                End If

                If lblT0Id.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T0ID") = lblT0Id.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T0") = txtT0.Text
                End If

                If lblT1ID.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T1ID") = lblT1ID.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T1") = txtT1.Text
                End If

                If lblT2Id.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T2ID") = lblT2Id.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T2") = txtT2.Text
                End If

                If lblT3Id.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T3ID") = lblT3Id.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T3") = txtT3.Text
                End If

                If lblT4Id.Text <> "" Then
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T4ID") = lblT4Id.Text
                    DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("T4") = txtT4.Text
                End If


                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Total HK") = FormatNumber(Val(lblTimeBasic.Text), 2)
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Total OT") = FormatNumber(Val(txtDailyOT.Text), 2)
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("HK") = FormatNumber(Val(txtHK.Text), 2)
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("OT") = FormatNumber(Val(txtOT.Text), 2)
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Modified By") = GlobalPPT.strUserName
                DTDaily_Distribution.Rows(DgvDistribution.CurrentCell.RowIndex).Item("Modified On") = Now
                btnUpdte.Visible = False
                btnAdd.Visible = True
                txtChange.Text = "Update"
                ResetDailyDistribution()
                txtHK.Text = 0
                MsgBox("Data successfully updated, click save all to confirm", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                btnSaveAll.Enabled = True
                dgvDailyReception.Enabled = True
                '====================
                'Hitung Balance HK
                '====================
                If DTDaily_Distribution.Rows.Count > 0 Then
                    Dim tothk As String = String.Empty
                    For k = 0 To DgvDistribution.Rows.Count - 1
                        tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                    Next k
                    lblBalHK.Text = Val(lblTimeBasic.Text) - Val(tothk)
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub RdName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNikview.Enabled = False
        txtnameview.Enabled = True

    End Sub
    Private Sub btnViewNik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NIKLookUp._Mandor = ""
        NIKLookUp.cmbMandorKrani.Enabled = True
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtNikview.Text = NIKLookUp._lNIK
            Me.txtnameview.Text = NIKLookUp._lEmpName
            Me.lblEmpidview.Text = NIKLookUp._lEmpid '<--- Untuk Melihat ID Employee di Screen View
            Me.lblEmpId.Text = NIKLookUp._lEmpid '<--- Untuk Melihat ID Employee di Screen Depan

        End If

    End Sub
    Private Sub btnViewName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NIKLookUp._Mandor = ""
        NIKLookUp.cmbMandorKrani.Enabled = True
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtNikview.Text = NIKLookUp._lNIK
            Me.txtnameview.Text = NIKLookUp._lEmpName
            Me.lblEmpidview.Text = NIKLookUp._lEmpid '<--- Untuk Melihat ID Employee di Screen View
            Me.lblEmpId.Text = NIKLookUp._lEmpid '<--- Untuk Melihat ID Employee di Screen Depan
        End If
    End Sub
    Private Sub btnmaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmaterial.Click
        If Me.btnUpdte.Visible = True Then
            MsgBox("Please update or Reset the selected Activity", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            btnUpdte.Focus()
            Return
        End If
        If Me.lblDistributionId.Text = "" Then
            MsgBox("Please select Activity from the above distributed activities for proceeding with material", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            Return
        ElseIf Me.lblDistributionId.Text <> "" Then

            lEmpId = lblEmpId.Text
            lEmpName = lblnameDisp.Text
            LEmpCode = txtNIK.Text
            LCOA = DgvDistribution.SelectedRows(0).Cells("Activity Code").Value.ToString
            LCOADesc = DgvDistribution.SelectedRows(0).Cells("Activity Descp").Value.ToString
            LCOAID = DgvDistribution.SelectedRows(0).Cells("COA ID").Value.ToString
            Ltanggal = dtpRDate.Value
            LDailyDistributionID = lblDistributionId.Text

            Materials.ldailydistributionId = LDailyDistributionID
            Materials.LEmpName = lEmpName
            Materials.LEmpId = lEmpId
            Materials.LempCode = LEmpCode
            Materials.lcoaid = LCOAID
            Materials.lcoaCode = LCOA
            Materials.lcoadescp = LCOADesc
            Materials.ltanggal = Ltanggal

            Materials.ShowDialog()
        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        ' By Dadang Adi Hendradi
        ' START Jum'at, 11 Des 2009, 01:48
        Cursor = Cursors.WaitCursor

        Dim report As ViewReport = New ViewReport()

        report._Source = "CRDANoTeamReport"
        report.Show()

        Cursor = Cursors.Default
        ' END Jum'at, 11 Des 2009, 01:48


        'LFormula = "{CRDANoTeamReport;1.EstateID}= '" & GlobalPPT.strEstateID & "' and ({CRDANoTeamReport;1.Rdate} >=#" & GlobalPPT.FiscalYearFromDate & "# And {CRDANoTeamReport;1.Rdate} <= #" & GlobalPPT.FiscalYearToDate & "#)"
        'LSource = "DailyAttendance"
        'ViewReport._Formula = LFormula
        'ViewReport._Source = LSource
        'ViewReport.ShowDialog()

        'LSource = CurDir() + "\Checkroll_Report\DailyAttendanceReport.Rpt"
        'ViewReport._Source = LSource

    End Sub

    Private Sub FormulaOTVALUE()

        Dim hasil As String = String.Empty
        Dim hasilOTRate As Decimal
        txtH1.Text = ""
        txtH2.Text = ""
        txtH3.Text = ""
        txtH4.Text = ""
        '=================================
        'Formula OT
        '=================================
        If Val(txtDailyOT.Text) > Val(txtmax1.Text) Then
            txtH1.Text = txtmax1.Text
            hasil = Val(txtDailyOT.Text) - Val(txtmax1.Text)
        ElseIf Val(txtDailyOT.Text) <= Val(txtmax1.Text) Then
            txtH1.Text = Val(txtDailyOT.Text)
            txtTotalHours.Text = (Val(txtH1.Text) * Val(txtOT1.Text)) + (Val(txtH2.Text) * Val(TxtOT2.Text)) + (Val(txtH3.Text) * Val(TxtOT3.Text)) + (Val(txtH4.Text) * Val(TXTOT4.Text))
            txtOTvalue.Text = (Val(txtBasicRate.Text) * 30) / Val(txtOTDivider.Text) * Val(txtTotalHours.Text)
            hasilOTRate = FormatNumber(Val(txtOTvalue.Text), 2)
            txtOTvalue.Text = hasilOTRate
            btnAddA.Focus()
            Return
        End If


        If Val(hasil) > Val(txtmax2.Text) Then
            txtH2.Text = txtmax2.Text
            hasil = Val(hasil) - Val(txtmax2.Text)
        ElseIf Val(hasil) <= Val(txtmax2.Text) Then
            txtH2.Text = hasil
            txtTotalHours.Text = (Val(txtH1.Text) * Val(txtOT1.Text)) + (Val(txtH2.Text) * Val(TxtOT2.Text)) + (Val(txtH3.Text) * Val(TxtOT3.Text)) + (Val(txtH4.Text) * Val(TXTOT4.Text))
            txtOTvalue.Text = (Val(txtBasicRate.Text) * 30) / Val(txtOTDivider.Text) * Val(txtTotalHours.Text)
            hasilOTRate = FormatNumber(Val(txtOTvalue.Text), 2)
            txtOTvalue.Text = hasilOTRate
            btnAddA.Focus()
            Return
        End If

        If Val(hasil) > Val(txtmax3.Text) Then
            txtH3.Text = txtmax3.Text
            hasil = Val(hasil) - Val(txtmax3.Text)
        ElseIf Val(hasil) <= Val(txtmax3.Text) Then
            txtH3.Text = hasil
            txtTotalHours.Text = (Val(txtH1.Text) * Val(txtOT1.Text)) + (Val(txtH2.Text) * Val(TxtOT2.Text)) + (Val(txtH3.Text) * Val(TxtOT3.Text)) + (Val(txtH4.Text) * Val(TXTOT4.Text))
            txtOTvalue.Text = (Val(txtBasicRate.Text) * 30) / Val(txtOTDivider.Text) * Val(txtTotalHours.Text)
            hasilOTRate = FormatNumber(Val(txtOTvalue.Text), 2)
            txtOTvalue.Text = hasilOTRate
            btnAddA.Focus()
            Return
        End If

        If Val(hasil) > Val(txtmax4.Text) Then
            txtH4.Text = txtmax4.Text
            hasil = Val(hasil) - Val(txtmax4.Text)
        ElseIf Val(hasil) <= Val(txtmax4.Text) Then
            txtH4.Text = hasil
            txtTotalHours.Text = (Val(txtH1.Text) * Val(txtOT1.Text)) + (Val(txtH2.Text) * Val(TxtOT2.Text)) + (Val(txtH3.Text) * Val(TxtOT3.Text)) + (Val(txtH4.Text) * Val(TXTOT4.Text))
            txtOTvalue.Text = (Val(txtBasicRate.Text) * 30) / Val(txtOTDivider.Text) * Val(txtTotalHours.Text)
            hasilOTRate = FormatNumber(Val(txtOTvalue.Text), 2)
            txtOTvalue.Text = hasilOTRate
            btnAddA.Focus()
            Return
        End If

    End Sub
    Private Sub txtDailyOT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDailyOT.GotFocus
        memdailyot = txtDailyOT.Text
    End Sub

    Private Sub txtDailyOT_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDailyOT.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtDailyOT.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtDailyOT.Text = 0
                '  txtDailyOT.Focus()
                ' Return
            ElseIf IsNumeric(txtDailyOT.Text) = True Then
                FormulaOTVALUE()
                DTOT_Detail.Clear()
                DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
                DgvOTDetail.DataSource = DTOT_Detail
                If DTOT_Detail.Rows.Count > 0 Then
                    UpdateOTSummary()
                ElseIf DTOT_Detail.Rows.Count = 0 Then
                    AddOTGrid()
                    If Val(txtOTDivider.Text) = 0 Then
                        MsgBox("OT divider is not setup ,Please Key in", MsgBoxStyle.Critical + MsgBoxStyle.Information, "Information")
                    End If
                End If

                If txtPremi.Enabled = True Then
                    txtPremi.Focus()
                ElseIf txtPremi.Enabled = False Then
                    txtblock.Focus()
                End If

                If txtPremi.Enabled = False And txtblock.Enabled = False Then
                    txtStation.Focus()
                End If

            End If
        End If

    End Sub
    Private Sub txtDailyOT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDailyOT.LostFocus
        FormulaOTVALUE()
        DTOT_Detail.Clear()
        DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
        DgvOTDetail.DataSource = DTOT_Detail
        If DTOT_Detail.Rows.Count > 0 Then
            UpdateOTSummary()
        ElseIf DTOT_Detail.Rows.Count = 0 Then
            AddOTGrid()
        End If
    End Sub
    Private Sub dgvDailyAttView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDailyAttView.DoubleClick
        ResetALL()

        Dim empid As String
        Dim tgl As Date
        Dim Row As Integer

        Row = dgvDailyAttView.CurrentCell.RowIndex
        empid = dgvDailyAttView.Rows(dgvDailyAttView.CurrentCell.RowIndex).Cells("Employee Id").Value
        tgl = dgvDailyAttView.Rows(dgvDailyAttView.CurrentCell.RowIndex).Cells("Date").Value

        DTDaily_Attendance.Clear()
        '=======================================
        DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(tgl, empid)
        dgvDailyAtt.DataSource = DTDaily_Attendance

        If DTDaily_Attendance.Rows.Count > 0 Then 'Jika Daily Attendance untuk Employee Ada
            txtOT.Focus()
            btnAdd.Enabled = True
            btnupd.Visible = True
            btnAddA.Visible = False
            GrpDAtt.Enabled = False

            txtNIK.Text = dgvDailyAttView.Item("Employee Code", Row).Value
            lblnameDisp.Text = dgvDailyAttView.Item("Employee Name", Row).Value
            lblEmpId.Text = dgvDailyAttView.Item("Employee ID", Row).Value
            dtpRDate.Text = dgvDailyAttView.Item("Date", Row).Value
            lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
            txtAttCode.Text = DTDaily_Attendance.Rows(0).Item("Att Code").ToString
            txtDailyOT.Text = DTDaily_Attendance.Rows(0).Item("Daily OT").ToString
            txtOTvalue.Text = DTDaily_Attendance.Rows(0).Item("OT Value").ToString

            '==============================
            'Cari Kode Attendance
            '===============================
            Dim dtAtt As DataTable = New DataTable
            dtAtt = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
            lblTimeBasic.Text = dtAtt.Rows(0).Item("TimesBasic").ToString
            '===============================
            If dtAtt.Rows(0).Item("OvertimeTimes1").ToString <> Nothing Then
                Me.txtOT1.Text = dtAtt.Rows(0).Item("OvertimeTimes1").ToString()
            Else
                txtOT1.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString <> Nothing Then
                Me.txtmax1.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString()
            Else
                txtmax1.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeTimes2").ToString <> Nothing Then
                Me.TxtOT2.Text = dtAtt.Rows(0).Item("OvertimeTimes2").ToString()
            Else
                TxtOT2.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString <> Nothing Then
                Me.txtmax2.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString()
            Else
                txtmax2.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeTimes3").ToString <> Nothing Then
                Me.TxtOT3.Text = dtAtt.Rows(0).Item("OvertimeTimes3").ToString()
            Else
                TxtOT3.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString <> Nothing Then
                Me.txtmax3.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString()
            Else
                txtmax3.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeTimes4").ToString <> Nothing Then
                Me.TXTOT4.Text = dtAtt.Rows(0).Item("OvertimeTimes4").ToString()
            Else
                TXTOT4.Text = ""
            End If

            If dtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString <> Nothing Then
                Me.txtmax4.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString()
            Else
                txtmax4.Text = ""
            End If

            If dtAtt.Rows(0).Item("TimesBasic").ToString <> Nothing Then
                Me.lblTimeBasic.Text = dtAtt.Rows(0).Item("TimesBasic").ToString()
                lblBalHK.Text = dtAtt.Rows(0).Item("TimesBasic").ToString()
            Else
                lblTimeBasic.Text = ""
            End If
            '============================
            If dtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                txtDailyOT.Enabled = False
                txtOT.Enabled = False
                txtDailyOT.Text = 0
                txtOT.Text = 0
            ElseIf dtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                txtDailyOT.Enabled = True
                txtOT.Enabled = True
                txtDailyOT.Text = 0
                txtOT.Text = 0
            End If


            If DTDaily_Attendance.Rows(0).Item("Tonnage").ToString <> Nothing Then
                txtPremi.Text = DTDaily_Attendance.Rows(0).Item("Tonnage").ToString
            End If
            If DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString <> Nothing Then
                lblVehicleID.Text = DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString
                txtVehicleCode.Enabled = True
                txtPremi.Enabled = True
                btnvehicle.Enabled = True
            Else
                lblVehicleID.Text = ""
                txtVehicleCode.Text = ""
                txtVehicleCode.Enabled = False
                txtPremi.Enabled = False
                btnvehicle.Enabled = False
            End If
            If DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString <> Nothing Then
                lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
            End If

            If DTDaily_Attendance.Rows(0).Item("Att Code").ToString <> Nothing Then
                txtAttCode.Text = DTDaily_Attendance.Rows(0).Item("Att Code").ToString
            End If

            '=================
            'Find Time Basic
            '=================
            Dim DTAttSetSelect As DataTable = New DataTable
            DTAttSetSelect = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
            lblTimeBasic.Text = DTAttSetSelect.Rows(0).Item("TimesBasic").ToString
            '========================


            txtPremi.Text = DTDaily_Attendance.Rows(0).Item("Tonnage").ToString
            lblVehicleID.Text = DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString

            '=========================
            'View for Vehicle
            '=========================
            Dim DTVWSLOOK As DataTable = New DataTable
            DTVWSLOOK = CheckRoll_BOL.DailyAttendanceBOL.CRMVehicleSelect(lblVehicleID.Text)
            If DTVWSLOOK.Rows.Count > 0 Then
                txtVehicleCode.Text = DTVWSLOOK.Rows(0).Item("VHWSCode").ToString
            ElseIf DTVWSLOOK.Rows.Count = 0 Then
                txtVehicleCode.Text = ""
            End If
            '============================

            lblAttDesc.Text = DTDaily_Attendance.Rows(0).Item("Remarks").ToString
            txtLocation.Text = DTDaily_Attendance.Rows(0).Item("Distribution Setup ID").ToString
            lblAttSetupId.Text = DTDaily_Attendance.Rows(0).Item("Attendance Setup ID").ToString

            ''===========================================================================================
            ''Daily Activity Distribution Select
            ''===========================================================================================
            DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionID.Text)
            DgvDistribution.DataSource = DTDaily_Distribution
            If DTDaily_Distribution.Rows.Count = 0 Then
                MsgBox("Distribution has not key in for this employee", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                If txtblock.Enabled = True Then
                    txtblock.Focus()
                ElseIf txtStation.Enabled = True Then
                    txtStation.Focus()
                End If

                

            ElseIf DTDaily_Distribution.Rows.Count > 0 Then
                '===========================
                'Hitung HK Dalam Grid
                '===========================
                Dim tothk As String = String.Empty
                For k = 0 To DgvDistribution.Rows.Count - 1
                    tothk = FormatNumber(Val(tothk), 2) + Val(DgvDistribution.Rows(k).Cells("HK").Value.ToString())
                Next k
                lblBalHK.Text = Val(lblTimeBasic.Text) - Val(tothk)
            End If

            If dgvDailyAttView.SelectedRows(0).Cells("AttendType").Value.ToString <> Nothing Then
                lblAttDesc.Text = dgvDailyAttView.SelectedRows(0).Cells("AttendType").Value.ToString
            End If

            '======================
            'FIND DAILY OT DETAIL
            '======================
            DTOT_Detail.Clear()
            DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
            DgvOTDetail.DataSource = DTOT_Detail
            '======================


            '=======================
            'FIND TARGET DETAIL
            '======================
            DTPremi_Detail = PremiTargetBOL.TargetDetailView("", "", "", lblBlockID.Text, lblEmpId.Text, dtpRDate.Value)
            DgvTargetDetail.DataSource = DTPremi_Detail
            '=======================

            Me.tcDailyAttendance.SelectedTab = tabDailyAttendance
            txtblock.Focus()
            btnAdd.Visible = True
            btnUpdte.Visible = False

            If Val(lblTimeBasic.Text) = 0 Then
                gbIPRAdd.Enabled = False
                grpTA.Enabled = False
                grpDistribution.Enabled = False
            ElseIf Val(lblTimeBasic.Text) > 0 Then
                gbIPRAdd.Enabled = True
                grpTA.Enabled = True
                grpDistribution.Enabled = True
            End If

        ElseIf DTDaily_Attendance.Rows.Count = 0 Then
            MsgBox("View data Error", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            Me.tcDailyAttendance.SelectedTab = tabDailyAttendance
        End If
        If dgvDailyAtt.Rows.Count > 0 Then
            dtpRDate.Enabled = False
        Else
            dtpRDate.Enabled = True
        End If

    End Sub
    Private Sub btnsearchNIK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnsearchNIK.KeyDown
        If e.KeyCode = Keys.Escape Then
            txtNIK.Focus()
        End If
    End Sub
    Private Sub Button2_Click_6(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i = 0 To dgvDailyReception.Rows.Count - 1
            If txtblock.Text = dgvDailyReception.Rows(i).Cells("Block Name").Value.ToString Then
                MsgBox("Can not add Field No with the same area", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                Return
            End If
        Next i
    End Sub
    Private Sub Button2_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As Object
        a = txtVehicleCode.Text
        If a = Nothing Then
        End If
    End Sub
    Private Sub Button2_Click_7(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '===============================
        'Hitung Premi Driver
        '===============================
        Dim htonnage As Integer
        Dim totPremi As Integer
        totPremi = 0
        txtDriverPremi.Text = 0
        htonnage = FormatNumber(Val(txtPremi.Text), 2)


        If DgDriverPremi.Rows.Count > 0 Then
            For i = 0 To DgDriverPremi.Rows.Count - 1
                If htonnage > Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                    htonnage = htonnage - Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value)
                    totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                    txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                ElseIf htonnage < Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                    totPremi = Val(htonnage)
                    txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                    Return
                End If
            Next i
        End If
        DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Driver Premi") = FormatNumber(Val(txtDriverPremi.Text), 2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Driver Premi") = FormatNumber(Val(txtDriverPremi.Text), 2)
    End Sub
    Private Sub btnViewPremi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewPremi.Click
        If View = False Then
            DgDriverPremi.Visible = True
            View = True
            DgDriverPremi.Columns.Item("AttendanceSetupId").Visible = False
            DgDriverPremi.Columns.Item("BlockId").Visible = False
            DgDriverPremi.Columns.Item("EstateID").Visible = False
        ElseIf View = True Then
            DgDriverPremi.Visible = False
            View = False
        End If
    End Sub
    Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.LostFocus
        '=============================================================
        'Update Premi Driver (Hanya Terjadi Jika telah ada Reception)
        '==============================================================
        If DTDaily_Attendance.Rows.Count > 0 Then
            DTDaily_Attendance.Rows(dgvDailyAtt.CurrentCell.RowIndex).Item("Driver Premi") = FormatNumber(Val(txtDriverPremi.Text), 2)
            DailyAttendanceAdapter.Update(DTDaily_Attendance)
            View = False
            DgDriverPremi.Visible = False
            btnViewPremi.Visible = False
        End If
        '==============================================================
    End Sub
    Private Sub Button2_Click_8(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT5.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblT5.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT5Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT5.Text = _TAnalysisLookUp._TACode
            Me.lblT5Id.Text = _TAnalysisLookUp._TAID
            btnAdd.Focus()
        End If
    End Sub
    Private Sub btnSearchT6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT6.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblt6.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT6Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT6.Text = _TAnalysisLookUp._TACode
            Me.lblt6Id.Text = _TAnalysisLookUp._TAID
            btnAdd.Focus()
        End If

    End Sub
    Private Sub btnSearchT7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT7.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblT7.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT7Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT7.Text = _TAnalysisLookUp._TACode
            Me.lblT7Id.Text = _TAnalysisLookUp._TAID
            btnAdd.Focus()
        End If
    End Sub
    Private Sub btnSearchT8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT8.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblt8.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT8Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT8.Text = _TAnalysisLookUp._TACode
            Me.lblT8Id.Text = _TAnalysisLookUp._TAID
            btnAdd.Focus()
        End If
    End Sub
    Private Sub btnSearchT9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchT9.Click
        Dim _TAnalysisLookUp As New TAnalysisLookUp
        _TAnalysisLookUp._TACode = lblt9.Text
        Dim result As DialogResult = _TAnalysisLookUp.ShowDialog()

        If _TAnalysisLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblT9Desc.Text = _TAnalysisLookUp._TADesc
            Me.txtT9.Text = _TAnalysisLookUp._TACode
            Me.lblT9Id.Text = _TAnalysisLookUp._TAID
            btnAdd.Focus()
        End If
    End Sub

    Private Sub txtHK_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHK.GotFocus
        MemHk = txtHK.Text
    End Sub

    Private Sub txtHK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHK.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtOT.Enabled = True Then
                txtOT.Focus()
            ElseIf txtOT.Enabled = False Then
                txtT0.Focus()
            End If
        End If

    End Sub
    Private Sub DgvDistribution_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvDistribution.CellMouseClick
        If DgvDistribution.Rows.Count > 0 Then
            If e.RowIndex >= 0 Then
                If DgvDistribution.SelectedRows(0).Cells("Daily Distribution ID").Value.ToString <> Nothing Then
                    lblDistributionId.Text = DgvDistribution.SelectedRows(0).Cells("Daily Distribution ID").Value.ToString
                    lblActSelected.Text = "Activity - " & DgvDistribution.SelectedRows(0).Cells("Activity Descp").Value.ToString & " is selected!"
                End If
            End If
        End If
    End Sub
    Private Sub DgvDistribution_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvDistribution.DoubleClick
        If DgvDistribution.Rows.Count > 0 Then
            txtHK.Focus()
            DTDaily_Distribution = DgvDistribution.DataSource
            lblROW.Text = DgvDistribution.CurrentCell.RowIndex.ToString
            btnUpdte.Visible = True
            btnAdd.Visible = False



            If DgvDistribution.SelectedRows(0).Cells("Daily Distribution ID").Value.ToString <> Nothing Then
                lblDistributionId.Text = DgvDistribution.SelectedRows(0).Cells("Daily Distribution ID").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Sub Block").Value.ToString <> Nothing Then
                txtblock.Text = DgvDistribution.SelectedRows(0).Cells("Sub Block").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Block ID").Value.ToString <> Nothing Then
                lblBlockID.Text = DgvDistribution.SelectedRows(0).Cells("Block ID").Value.ToString
                Dim DTSBSelect As DataTable = New DataTable
                DTSBSelect = CheckRoll_BOL.LookUpBOL.CRSubBlockSelect(txtblock.Text)
                lblStatusBlock.Text = DTSBSelect.Rows(0).Item("BlockStatus").ToString()
            End If

            If DgvDistribution.SelectedRows(0).Cells("YOP").Value.ToString <> Nothing Then
                txtyop.Text = DgvDistribution.SelectedRows(0).Cells("YOP").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("YOP ID").Value.ToString <> Nothing Then
                lblYOPID.Text = DgvDistribution.SelectedRows(0).Cells("YOP ID").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Div").Value.ToString <> Nothing Then
                txtdiv.Text = DgvDistribution.SelectedRows(0).Cells("Div").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Div ID").Value.ToString <> Nothing Then
                lblDivId.Text = DgvDistribution.SelectedRows(0).Cells("Div ID").Value.ToString
            End If

            'AN08082010- modified to display stationcode and stationdescp in proper field

            'If DgvDistribution.SelectedRows(0).Cells("Station").Value.ToString <> Nothing Then
            '    txtStation.Text = DgvDistribution.SelectedRows(0).Cells("Station").Value.ToString
            'End If
            If DgvDistribution.SelectedRows(0).Cells("Station Code").Value.ToString <> Nothing Then
                txtStation.Text = DgvDistribution.SelectedRows(0).Cells("Station Code").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("Station Descp").Value.ToString <> Nothing Then
                lblStationDesc.Text = DgvDistribution.SelectedRows(0).Cells("Station Descp").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Station ID").Value.ToString <> Nothing Then
                lblStationId.Text = DgvDistribution.SelectedRows(0).Cells("Station ID").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Activity Code").Value.ToString <> Nothing Then
                txtMainAct.Text = DgvDistribution.SelectedRows(0).Cells("Activity Code").Value.ToString
                Dim DTCOA As DataTable
                DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(txtMainAct.Text, "")
                txtOldCoa.Text = DTCOA.Rows(0).Item("OldCOACode").ToString()
            End If

            If DgvDistribution.SelectedRows(0).Cells("Activity Descp").Value.ToString <> Nothing Then
                lblCoaDesc.Text = DgvDistribution.SelectedRows(0).Cells("Activity Descp").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("Prestasi").Value.ToString <> Nothing Then
                txtHa.Text = DgvDistribution.SelectedRows(0).Cells("Prestasi").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("COA ID").Value.ToString <> Nothing Then
                lblCOAID.Text = DgvDistribution.SelectedRows(0).Cells("COA ID").Value.ToString
            End If

            ' by Dadang Adi H
            ' Jum'at, 20 Nov 2009, 16:53
            If Not DgvDistribution.SelectedRows(0).Cells("OvertimeCOAID").Value Is Nothing Then
                txtOvertimeCOACode.Text = DgvDistribution.SelectedRows(0).Cells("OvertimeCOACode").Value.ToString()
                lblOvertimeCOADescp.Text = DgvDistribution.SelectedRows(0).Cells("OvertimeCOADescp").Value.ToString()
                lblOvertimeCOAID.Text = DgvDistribution.SelectedRows(0).Cells("OvertimeCOAID").Value.ToString()
            End If
            ' END Jum'at, 20 Nov 2009, 16:53

            If DgvDistribution.SelectedRows(0).Cells("HK").Value.ToString <> Nothing Then
                txtHK.Text = DgvDistribution.SelectedRows(0).Cells("HK").Value.ToString
                MemHk = DgvDistribution.SelectedRows(0).Cells("HK").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("OT").Value.ToString <> Nothing Then
                txtOT.Text = DgvDistribution.SelectedRows(0).Cells("OT").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("T0ID").Value.ToString <> Nothing Then
                lblT0Id.Text = DgvDistribution.SelectedRows(0).Cells("T0ID").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T0").Value.ToString <> Nothing Then
                txtT0.Text = DgvDistribution.SelectedRows(0).Cells("T0").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T0 Descp").Value.ToString <> Nothing Then
                lblT0Desc.Text = DgvDistribution.SelectedRows(0).Cells("T0 Descp").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("T1ID").Value.ToString <> Nothing Then
                lblT1ID.Text = DgvDistribution.SelectedRows(0).Cells("T1ID").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T1").Value.ToString <> Nothing Then
                txtT1.Text = DgvDistribution.SelectedRows(0).Cells("T1").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T1 Descp").Value.ToString <> Nothing Then
                lblT1Desc.Text = DgvDistribution.SelectedRows(0).Cells("T1 Descp").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("T2ID").Value.ToString <> Nothing Then
                lblT2Id.Text = DgvDistribution.SelectedRows(0).Cells("T2ID").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T2").Value.ToString <> Nothing Then
                txtT2.Text = DgvDistribution.SelectedRows(0).Cells("T2").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T2 Descp").Value.ToString <> Nothing Then
                lblT2Desc.Text = DgvDistribution.SelectedRows(0).Cells("T2 Descp").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("T3ID").Value.ToString <> Nothing Then
                lblT3Id.Text = DgvDistribution.SelectedRows(0).Cells("T3ID").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T3").Value.ToString <> Nothing Then
                txtT3.Text = DgvDistribution.SelectedRows(0).Cells("T3").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T3 Descp").Value.ToString <> Nothing Then
                lblT3Desc.Text = DgvDistribution.SelectedRows(0).Cells("T3 Descp").Value.ToString
            End If

            If DgvDistribution.SelectedRows(0).Cells("T4ID").Value.ToString <> Nothing Then
                lblT4Id.Text = DgvDistribution.SelectedRows(0).Cells("T4ID").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T4").Value.ToString <> Nothing Then
                txtT4.Text = DgvDistribution.SelectedRows(0).Cells("T4").Value.ToString
            End If
            If DgvDistribution.SelectedRows(0).Cells("T4 Descp").Value.ToString <> Nothing Then
                lblT4Desc.Text = DgvDistribution.SelectedRows(0).Cells("T4 Descp").Value.ToString
            End If



            '===============================
            'VIEW PREMI DRIVER

            Dim DTPREMIDRIVER As DataTable
            DTPREMIDRIVER = DailyAttendance_DAL.CRPremiDriver(lblBlockID.Text, lblAttSetupId.Text)
            DgDriverPremi.DataSource = DTPREMIDRIVER
            If DTPREMIDRIVER.Rows.Count > 0 Then
                btnViewPremi.Visible = True
            ElseIf DTPREMIDRIVER.Rows.Count = 0 Then
                btnViewPremi.Visible = False
                DTPremi_Detail.Clear()
            End If


            '===============================
            'Hitung Premi Driver
            '===============================
            Dim htonnage As Integer
            Dim totPremi As Integer
            totPremi = 0
            txtDriverPremi.Text = 0
            htonnage = FormatNumber(Val(txtPremi.Text), 2)


            If DgDriverPremi.Rows.Count > 0 Then
                For i = 0 To DgDriverPremi.Rows.Count - 1
                    If htonnage >= Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                        htonnage = htonnage - Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value)
                        totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                        txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                        '-----------------------------
                        If DTPremi_Detail.Rows.Count = 0 Then
                            AddPremiDetailGrid()
                        End If
                        'UPDATE DETAIL TARGET TONNAGE
                        '==============================
                        If i = 0 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 1 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 2 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 3 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        If i = 4 Then
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                            DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                        End If
                        '=====================
                    ElseIf htonnage < Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
                        If Val(htonnage) <= (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
                            totPremi = Val(htonnage)
                            txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
                            If DTPremi_Detail.Rows.Count = 0 Then
                                AddPremiDetailGrid()
                            End If
                            'UPDATE DETAIL TARGET TONNAGE
                            '==============================
                            If i = 0 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 1 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 2 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 3 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 4 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            Return

                        ElseIf htonnage > (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
                            totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
                            htonnage = Val(htonnage) - (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value))
                            txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))

                            If DTPremi_Detail.Rows.Count = 0 Then
                                AddPremiDetailGrid()
                            End If
                            'UPDATE DETAIL TARGET TONNAGE
                            '==============================
                            If i = 0 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 1 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 2 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 3 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                            If i = 4 Then
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
                                DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
                            End If
                        End If

                    End If
                Next i
            End If


            '===============================


        End If


    End Sub
    Private Sub BtnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        '--------------------
        ResetDailyDistribution()
        btnUpdte.Visible = False
        btnAdd.Visible = True
        btnSaveAll.Enabled = True
        dgvDailyReception.Enabled = True
        txtOT.Focus()
        txtOT.Text = 0
        txtHa.Text = 0
        txtT0.Text = ""
        txtT1.Text = ""
        txtT2.Text = ""
        txtT3.Text = ""
        txtT4.Text = ""
        txtT5.Text = ""
        txtT6.Text = ""
        txtT7.Text = ""
        txtT8.Text = ""
        txtT9.Text = ""
        dtpRDate.Enabled = False
        txtHK.Text = 0
        txtblock.Focus()
        lblT0Desc.Text = ""
        lblT1Desc.Text = ""
        lblT2Desc.Text = ""
        lblT3Desc.Text = ""
        lblT4Desc.Text = ""
        lblT5Desc.Text = ""
        lblT6Desc.Text = ""
        lblT7Desc.Text = ""
        lblT8Desc.Text = ""
        lblT9Desc.Text = ""

    End Sub
    Private Sub Button2_Click_12(ByVal sender As System.Object, ByVal e As System.EventArgs)
        arrangeview()
    End Sub
    Private Sub DgvDistribution_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDistribution.CellContentClick
        If DgvDistribution.Rows.Count > 0 Then
            If e.RowIndex >= 0 Then
                If DgvDistribution.SelectedRows(0).Cells("Daily Distribution ID").Value.ToString <> Nothing Then
                    lblDistributionId.Text = DgvDistribution.SelectedRows(0).Cells("Daily Distribution ID").Value.ToString
                    lblActSelected.Text = "Activity - " & DgvDistribution.SelectedRows(0).Cells("Activity Descp").Value.ToString & " is selected!"
                End If
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtblock_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtblock.LostFocus
        'Dim DTSBSelect As DataTable = New DataTable
        'DTSBSelect = CheckRoll_BOL.LookUpBOL.CRSubBlockSelect(txtblock.Text)
        'If DTSBSelect.Rows.Count = 1 Then
        '    txtblock.Text = DTSBSelect.Rows(0).Item("BlockName").ToString()
        '    txtdiv.Text = DTSBSelect.Rows(0).Item("DivName").ToString()
        '    txtyop.Text = DTSBSelect.Rows(0).Item("YOP").ToString()
        '    lblBlockID.Text = DTSBSelect.Rows(0).Item("BlockID").ToString()
        '    lblYOPID.Text = DTSBSelect.Rows(0).Item("YOPID").ToString()
        '    lblDivId.Text = DTSBSelect.Rows(0).Item("DivID").ToString()
        '    lblStatusBlock.Text = DTSBSelect.Rows(0).Item("BlockStatus").ToString()
        '    txtMainAct.Focus()

        '    '===============================
        '    'VIEW PREMI DRIVER

        '    Dim DTPREMIDRIVER As DataTable
        '    DTPREMIDRIVER = DailyAttendance_DAL.CRPremiDriver(lblBlockID.Text, lblAttSetupId.Text)
        '    DgDriverPremi.DataSource = DTPREMIDRIVER
        '    If DTPREMIDRIVER.Rows.Count > 0 Then
        '        btnViewPremi.Visible = True
        '    ElseIf DTPREMIDRIVER.Rows.Count = 0 Then
        '        btnViewPremi.Visible = False
        '        MsgBox("Premi Diver has not been setup", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Information")
        '        DTPremi_Detail.Clear()
        '    End If


        '    '===============================
        '    'Hitung Premi Driver
        '    '===============================
        '    Dim htonnage As Integer
        '    Dim totPremi As Integer
        '    totPremi = 0
        '    txtDriverPremi.Text = 0
        '    htonnage = FormatNumber(Val(txtPremi.Text), 2)


        '    If DgDriverPremi.Rows.Count > 0 And Val(txtPremi.Text) > 0 Then
        '        For i = 0 To DgDriverPremi.Rows.Count - 1
        '            If htonnage >= Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
        '                htonnage = htonnage - Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value)
        '                totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
        '                txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
        '                '-----------------------------
        '                If DTPremi_Detail.Rows.Count = 0 Then
        '                    AddPremiDetailGrid()
        '                End If
        '                'UPDATE DETAIL TARGET TONNAGE
        '                '==============================
        '                If i = 0 Then
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                End If
        '                If i = 1 Then
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                End If
        '                If i = 2 Then
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                End If
        '                If i = 3 Then
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                End If
        '                If i = 4 Then
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
        '                    DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                End If
        '                '=====================
        '            ElseIf htonnage < Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) Then
        '                If Val(htonnage) <= (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
        '                    totPremi = Val(htonnage)
        '                    txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))
        '                    If DTPremi_Detail.Rows.Count = 0 Then
        '                        AddPremiDetailGrid()
        '                    End If
        '                    'UPDATE DETAIL TARGET TONNAGE
        '                    '==============================
        '                    If i = 0 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 1 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 2 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 3 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 4 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    Return

        '                ElseIf htonnage > (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)) Then
        '                    totPremi = Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value)
        '                    htonnage = Val(htonnage) - (Val(DgDriverPremi.Rows(i).Cells("MaxTonnage").Value) - Val(DgDriverPremi.Rows(i).Cells("MinTonnage").Value))
        '                    txtDriverPremi.Text = Val(txtDriverPremi.Text) + (FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value))

        '                    If DTPremi_Detail.Rows.Count = 0 Then
        '                        AddPremiDetailGrid()
        '                    End If
        '                    'UPDATE DETAIL TARGET TONNAGE
        '                    '==============================
        '                    If i = 0 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage1") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue1") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 1 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage2") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue2") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 2 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage3") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue3") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 3 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage4") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue4") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                    If i = 4 Then
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnage5") = FormatNumber(Val(totPremi), 2)
        '                        DTPremi_Detail.Rows(DgvTargetDetail.CurrentCell.RowIndex).Item("TTonnageValue5") = FormatNumber(Val(totPremi), 2) * Val(DgDriverPremi.Rows(i).Cells("RatePerTonnage").Value)
        '                    End If
        '                End If

        '            End If
        '        Next i
        '    End If


        '    '===============================
        'ElseIf DTSBSelect.Rows.Count = 0 Then
        '    MsgBox(" Block Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        '    DTPREMIDRIVER.Clear()
        '    DTPremi_Detail.Clear()
        '    txtblock.Text = ""
        '    txtblock.Focus()
        'End If
    End Sub

    

    Private Sub txtNIK_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNIK.LostFocus
        Try

       
            If txtNIK.Text <> "" Then
                Dim DTNIKSelect As DataTable
                AttDate = dtpRDate.Value
                DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelectNoTeam(txtNIK.Text, lblnameDisp.Text, "", "Active", AttDate)
                If DTNIKSelect.Rows.Count = 1 Then
                    lblInfoNIK.Text = ""
                    txtNIK.Text = DTNIKSelect.Rows(0).Item("NIK").ToString()
                    lblnameDisp.Text = DTNIKSelect.Rows(0).Item("Name").ToString()
                    lblEmpId.Text = DTNIKSelect.Rows(0).Item("Employee ID").ToString()
                    lblmandor.Text = DTNIKSelect.Rows(0).Item("mandor").ToString()
                    lblRestday.Text = DTNIKSelect.Rows(0).Item("RestDay").ToString()
                    txtOTDivider.Text = DTNIKSelect.Rows(0).Item("OTDivider").ToString()
                    lblCategory.Text = DTNIKSelect.Rows(0).Item("Category").ToString()

                    ' Jum'at, 20 Nov 2009, 23:32 - By Dadang
                    If DTNIKSelect.Rows(0).IsNull("Basic Rate") Then
                        txtBasicRate.Text = "0"
                        MessageBox.Show("Please setup Basic Rate for this Employee to calculate OT", _
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        txtBasicRate.Text = DTNIKSelect.Rows(0).Item("Basic Rate").ToString()
                    End If


                    If lblCategory.Text = "KT" Then
                        Dim DTKT As DataTable
                        DTKT = CheckRoll_BOL.DailyAttendanceBOL.CRKTView(lblEmpId.Text)
                        If DTKT.Rows.Count = 1 Then
                            ' Sabtu, 21 Nov 2009, 00:29 - By Dadang
                            If DTKT.Rows(0).IsNull("HIPMonthlyRate") Then
                                txtBasicRate.Text = "0"
                                MessageBox.Show("Please setup Basic Rate for this Employee to calculate OT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else

                                txtBasicRate.Text = DTKT.Rows(0).Item("HIPMonthlyRate").ToString()
                                txtBasicRate.Text = Val(txtBasicRate.Text) / 30
                            End If
                        ElseIf DTKT.Rows.Count = 0 Then
                            txtBasicRate.Text = "0"
                            MsgBox("Please setup Basic Rate for this Employee to calculate OT", MsgBoxStyle.Critical + MsgBoxStyle.Information, "Information")
                        End If
                    End If
                    ' END Jum'at, 20 Nov 2009, 23:32

                    ' Jum'at, 20 Nov 2009, 23:48
                    ' COAID untuk karyawan Category KT (HIP) langsung diambil dari CREmployeeHIP
                    If lblCategory.Text = "KT" Then

                        Dim dtHIP As DataTable
                        dtHIP = DailyAttendance_DAL.CREmployeeHIPSelect(lblEmpId.Text)

                        If dtHIP.Rows.Count > 0 Then
                            If dtHIP.Rows(0).IsNull("COAID") Then

                                MessageBox.Show("Activity for this KT Employee has not been setup yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                txtMainAct.Text = dtHIP.Rows(0).Item("COACode").ToString()
                                lblCOAID.Text = dtHIP.Rows(0).Item("COAID").ToString()
                                lblCoaDesc.Text = dtHIP.Rows(0).Item("COADescp").ToString()

                                ' Jum'at, 20 Nov 2009, 17:00
                                ' by GUE
                                ' tambah OvertimeCOA
                                Dim DTCOA As DataTable
                                Dim OvertimeCOACode As String

                                If Not String.IsNullOrEmpty(txtMainAct.Text) Then

                                    OvertimeCOACode = txtMainAct.Text.Substring(0, txtMainAct.Text.Length - 3)
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

                                End If
                                ' END Jum'at, 20 Nov 2009, 17:00

                            End If

                        Else
                            MessageBox.Show("Activity for this KT Employee has not been setup yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If
                    ' END Jum'at, 20 Nov 2009, 23:48

                    '===================================
                    'Cek For Restday and Public Holiday
                    '====================================
                    If lblRestday.Text.ToUpper.ToString.Trim = (dtpRDate.Value.DayOfWeek.ToString.Substring(0, 3)).ToUpper.ToString.Trim Then
                        txtAttCode.Text = "M0"
                    End If
                    Dim DTPH As New DataTable
                    DTPH = CheckRoll_BOL.DailyAttendanceBOL.CRPHoliday(dtpRDate.Value)
                    If DTPH.Rows.Count = 1 Then
                        txtAttCode.Text = "L0"
                    End If
                    '=====================================

                    If lblmandor.Text = "D" Then
                        LblPremiForDriver.ForeColor = Color.Red
                        LblVehicleCode.ForeColor = Color.Red
                    Else
                        LblPremiForDriver.ForeColor = Color.Black
                        LblVehicleCode.ForeColor = Color.Black
                    End If
                    dtpRDate.Enabled = False
                    txtAttCode.Focus()
                ElseIf DTNIKSelect.Rows.Count = 0 Or DTNIKSelect.Rows.Count > 1 Then
                    lblInfoNIK.Text = "Employee Code Not Valid"
                    lblEmpId.Text = ""
                    lblnameDisp.Text = ""
                    dtpRDate.Enabled = True
                    'txtNIK.Focus()


                End If

                DTDaily_Attendance.Clear()
                '=======================================
                DTDaily_Attendance = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamView(dtpRDate.Value, lblEmpId.Text)
                dgvDailyAtt.DataSource = DTDaily_Attendance


                If DTDaily_Attendance.Rows.Count > 0 Then
                    txtOT.Focus()
                    btnAdd.Enabled = True
                    btnupd.Visible = True
                    btnAddA.Visible = False
                    lblDailyReceptionID.Text = DTDaily_Attendance.Rows(0).Item("Daily Receiption ID").ToString
                    txtAttCode.Text = DTDaily_Attendance.Rows(0).Item("Att Code").ToString
                    txtDailyOT.Text = DTDaily_Attendance.Rows(0).Item("Daily OT").ToString
                    txtOTvalue.Text = DTDaily_Attendance.Rows(0).Item("OT Value").ToString
                    '===================

                    Dim dtAtt As DataTable = New DataTable
                    dtAtt = CheckRoll_BOL.LookUpBOL.CRAttendanceSetupSelect(txtAttCode.Text, lblAttDesc.Text)
                    lblTimeBasic.Text = dtAtt.Rows(0).Item("TimesBasic").ToString

                    '===============================
                    If dtAtt.Rows(0).Item("OvertimeTimes1").ToString <> Nothing Then
                        Me.txtOT1.Text = dtAtt.Rows(0).Item("OvertimeTimes1").ToString()
                    End If
                    If dtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString <> Nothing Then
                        Me.txtmax1.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours1").ToString()
                    End If
                    If dtAtt.Rows(0).Item("OvertimeTimes2").ToString <> Nothing Then
                        Me.TxtOT2.Text = dtAtt.Rows(0).Item("OvertimeTimes2").ToString()
                    End If
                    If dtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString <> Nothing Then
                        Me.txtmax2.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours2").ToString()
                    End If

                    If dtAtt.Rows(0).Item("OvertimeTimes3").ToString <> Nothing Then
                        Me.TxtOT3.Text = dtAtt.Rows(0).Item("OvertimeTimes3").ToString()
                    End If
                    If dtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString <> Nothing Then
                        Me.txtmax3.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours3").ToString()
                    End If
                    If dtAtt.Rows(0).Item("OvertimeTimes4").ToString <> Nothing Then
                        Me.TXTOT4.Text = dtAtt.Rows(0).Item("OvertimeTimes4").ToString()
                    End If

                    If dtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString <> Nothing Then
                        Me.txtmax4.Text = dtAtt.Rows(0).Item("OvertimeMaxOTHours4").ToString()
                    End If

                    If dtAtt.Rows(0).Item("TimesBasic").ToString <> Nothing Then
                        Me.lblTimeBasic.Text = dtAtt.Rows(0).Item("TimesBasic").ToString()
                    End If
                    '============================

                    If dtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                        txtDailyOT.Enabled = False
                        txtOT.Enabled = False
                        txtDailyOT.Text = 0
                        txtOT.Text = 0
                    ElseIf dtAtt.Rows(0).Item("OvertimeTimes1").ToString = Nothing Then
                        txtDailyOT.Enabled = True
                        txtOT.Enabled = True
                        txtDailyOT.Text = 0
                        txtOT.Text = 0
                    End If



                    txtPremi.Text = DTDaily_Attendance.Rows(0).Item("Tonnage").ToString
                    lblVehicleID.Text = DTDaily_Attendance.Rows(0).Item("Vehicle ID").ToString
                    '=========================
                    Dim DTVEHLOOK As DataTable = New DataTable
                    DTVEHLOOK = CheckRoll_BOL.DailyAttendanceBOL.CRMVehicleSelect(lblVehicleID.Text)
                    If DTVEHLOOK.Rows.Count > 0 Then
                        txtVehicleCode.Text = DTVEHLOOK.Rows(0).Item("VHWSCode").ToString
                    ElseIf DTVEHLOOK.Rows.Count = 0 Then
                        txtVehicleCode.Text = ""
                    End If

                    lblAttDesc.Text = DTDaily_Attendance.Rows(0).Item("Remarks").ToString
                    txtLocation.Text = "" '<============================================================= Will lookup on Distribution Location Display
                    lblAttSetupId.Text = DTDaily_Attendance.Rows(0).Item("Attendance Setup ID").ToString
                    lblDistLocID.Text = DTDaily_Attendance.Rows(0).Item("Distribution Setup ID").ToString

                    '==================================================
                    'Distribution Location Display
                    '==================================================
                    Dim DTDISSelect As DataTable = New DataTable
                    DTDISSelect = CheckRoll_BOL.DailyAttendanceBOL.CRDistributionSetupLookup(txtLocation.Text, lblDistLocID.Text)
                    If DTDISSelect.Rows.Count > 0 Then
                        If DTDISSelect.Rows(0).Item("DistributionDescp").ToString <> Nothing Then
                            txtLocation.Text = DTDISSelect.Rows(0).Item("DistributionDescp").ToString
                        Else
                            txtLocation.Text = ""
                        End If
                    End If



                    '===========================================================================================
                    'Daily Receiption & Daily Activity Distribution Select
                    '===========================================================================================
                    DTDaily_Distribution.Clear()
                    DTDaily_Distribution = CheckRoll_BOL.DailyAttendanceBOL.DailyActivityDistributionIsSelect(lblDailyReceptionID.Text)
                    DgvDistribution.DataSource = DTDaily_Distribution
                    If DTDaily_Distribution.Rows.Count = 0 Then
                        MsgBox("Distribution has not key in for this employee", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        If txtblock.Enabled = True Then
                            txtblock.Focus()
                        ElseIf txtblock.Enabled = False Then
                            txtStation.Focus()
                        End If
                        GrpDAtt.Enabled = True
                    ElseIf DTDaily_Distribution.Rows.Count > 0 Then
                        If txtblock.Enabled = True Then
                            txtblock.Focus()
                        ElseIf txtblock.Enabled = False Then
                            txtStation.Focus()
                        End If
                        GrpDAtt.Enabled = False
                    End If


                    dtpRDate.Enabled = False

                ElseIf DTDaily_Attendance.Rows.Count = 0 Then
                    Me.txtAttCode.Focus()
                    btnAdd.Enabled = True
                    btnAdd.Visible = True

                    btnAddA.Enabled = True
                    btnAddA.Visible = True

                    btnupd.Visible = False
                    btnUpdte.Visible = False

                    txtVehicleCode.Text = ""
                    lblDailyReceptionID.Text = ""
                    If txtAttCode.Text = Nothing Then
                        txtAttCode.Text = ""
                    ElseIf txtAttCode.Text <> Nothing Then
                        txtPremi.Text = 0
                    End If
                    lblVehicleID.Text = ""
                    lblAttDesc.Text = ""
                    txtLocation.Text = ""
                    lblAttSetupId.Text = ""
                    txtDailyOT.Text = 0
                    txtOTvalue.Text = ""
                    txtH1.Text = ""
                    txtH2.Text = ""
                    txtH3.Text = ""
                    txtH4.Text = ""
                    txtAttCode.Focus()
                    DTDaily_Reception.Clear()
                    DTDaily_Distribution.Clear()

                End If
            End If
        Catch ex As Exception
            MsgBox("Try to Click Button Reset All to refresh data", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
        End Try
    End Sub


    Private Sub txtMainAct_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMainAct.Leave
        Dim DTCOA As DataTable
        DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(txtMainAct.Text, lblStatusBlock.Text)
        If DTCOA.Rows.Count = 1 Then
            txtMainAct.Text = DTCOA.Rows(0).Item("COACode").ToString()
            lblCoaDesc.Text = DTCOA.Rows(0).Item("COADescp").ToString()
            lblCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()
            txtOldCoa.Text = DTCOA.Rows(0).Item("OldCOACode").ToString()
            ' Jum'at, 20 Nov 2009, 15:24
            ' by GUE
            ' tambah OvertimeCOA
            'Dim DTCOA As DataTable
            Dim OvertimeCOACode As String

            OvertimeCOACode = txtMainAct.Text.Substring(0, txtMainAct.Text.Length - 3)
            OvertimeCOACode = OvertimeCOACode + "002"

            DTCOA = CheckRoll_BOL.DailyAttendanceBOL.CRCOASelect(OvertimeCOACode, lblStatusBlock.Text)

            If DTCOA.Rows.Count > 0 Then
                txtOvertimeCOACode.Text = OvertimeCOACode
                lblOvertimeCOADescp.Text = DTCOA.Rows(0).Item("COADescp").ToString()
                lblOvertimeCOAID.Text = DTCOA.Rows(0).Item("COAID").ToString()
                txtOldCoa.Text = DTCOA.Rows(0).Item("OldCOACode").ToString()
            Else
                txtOvertimeCOACode.Text = String.Empty
                lblOvertimeCOADescp.Text = String.Empty
                lblOvertimeCOAID.Text = String.Empty
                txtOldCoa.Text = String.Empty
            End If
            ' END Jum'at, 20 Nov 2009, 15:24

            txtHa.Focus()
        ElseIf DTCOA.Rows.Count = 0 Or DTCOA.Rows.Count > 1 Then
            lblCoaDesc.Text = "Activity Code is not valid"
            lblCOAID.Text = ""
            txtOldCoa.Text = String.Empty


        End If

    End Sub

    Private Sub txtOvertimeCOACode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOvertimeCOACode.KeyDown
        ' Ahad, 22 Nov 2009, 22:26

        If e.KeyCode = Keys.Enter Then

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

        End If

    End Sub

    Private Sub txtOvertimeCOACode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOvertimeCOACode.Leave
        If txtOvertimeCOACode.Text.Trim <> "" Then


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
            txtT0.Focus()

        End If
    End Sub

    Private Sub btnSearchOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchOT.Click
        COALookup.strAcctExpenditureAG = lblStatusBlock.Text
        COALookup.ShowDialog()

        If COALookup.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lblOvertimeCOADescp.Text = COALookup.strAcctDescp
            Me.txtOvertimeCOACode.Text = COALookup.strAcctcode
            Me.lblOvertimeCOAID.Text = COALookup.strAcctId
            Me.LblOToldCOACode.Text = COALookup.strOldAccountCode
            ' Me.txtOldCoa.Text = COALookup.strOldAccountCode
            txtHa.Focus()
        End If

    End Sub

    Private Sub tcDailyAttendance_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcDailyAttendance.SelectedIndexChanged
        If tcDailyAttendance.SelectedIndex = 1 Then
            chkDate.Checked = False
            DtDASearch.Value = GlobalPPT.FiscalYearToDate
            txtNikview.Text = ""
            txtnameview.Text = ""
            Dim DTDAViewAllND As DataTable = New DataTable
            DTDAViewAllND = CheckRoll_BOL.DailyAttendanceBOL.DailyAttendanceNoTeamViewAll("", txtNikview.Text, txtnameview.Text)
            dgvDailyAttView.DataSource = DTDAViewAllND
            dgvDailyAttView.Columns.Item("Date").DefaultCellStyle.Format = "dd/MM/yyyy"
        ElseIf tcDailyAttendance.SelectedIndex = 0 Then

            If dgvDailyAtt.Rows.Count > 0 Then
                dtpRDate.Enabled = False
            Else
                dtpRDate.Enabled = True
            End If

            txtNIK.Focus()

        End If

    End Sub

    Private Sub txtStation_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStation.LostFocus
        If txtStation.Text = String.Empty Then
            lblStationDesc.Text = ""
            lblStationId.Text = ""
        End If
    End Sub

    Private Sub DailyAttendanceNoTeam_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub txtDailyOT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDailyOT.Leave

    '    If IsNumeric(txtDailyOT.Text) = False Then
    '        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
    '        txtDailyOT.Text = 0
    '        '  txtDailyOT.Focus()
    '        ' Return
    '    ElseIf IsNumeric(txtDailyOT.Text) = True Then
    '        FormulaOTVALUE()
    '        DTOT_Detail.Clear()
    '        DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
    '        DgvOTDetail.DataSource = DTOT_Detail
    '        If DTOT_Detail.Rows.Count > 0 Then
    '            UpdateOTSummary()
    '        ElseIf DTOT_Detail.Rows.Count = 0 Then
    '            AddOTGrid()
    '            'If Val(txtOTDivider.Text) = 0 Then
    '            '    MsgBox("OT divider is not setup ,Please Key in", MsgBoxStyle.Critical + MsgBoxStyle.Information, "Information")
    '            'End If
    '        End If

    '        If txtPremi.Enabled = True Then
    '            txtPremi.Focus()
    '        ElseIf txtPremi.Enabled = False Then
    '            txtblock.Focus()
    '        End If

    '        If txtPremi.Enabled = False And txtblock.Enabled = False Then
    '            txtStation.Focus()
    '        End If

    '    End If
    'End Sub

    Private Sub txtOT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOT.TextChanged
        If Val(txtOT.Text) > 0 Then
            lblOTCOA.ForeColor = Color.Red
        Else
            lblOTCOA.ForeColor = Color.Black
        End If
    End Sub

    
    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click

    End Sub

    Private Sub txtVehicleCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVehicleCode.KeyPress
        'If e.KeyChar = "9" Then
        '    txtblock.Focus()
        '    Exit Sub
        'End If
    End Sub

    Private Sub txtVehicleCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave
       
    End Sub

    Private Sub txtVehicleCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.TextChanged

    End Sub

    Private Sub txtDailyOT_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDailyOT.Leave
        If txtDailyOT.Text.Trim > 0 Then


            If IsNumeric(txtDailyOT.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtDailyOT.Text = 0
                '  txtDailyOT.Focus()
                ' Return
            ElseIf IsNumeric(txtDailyOT.Text) = True Then
                FormulaOTVALUE()
                DTOT_Detail.Clear()
                DTOT_Detail = OTDetailBOL.OTDetailView("", "", lblEmpId.Text, dtpRDate.Value)
                DgvOTDetail.DataSource = DTOT_Detail
                If DTOT_Detail.Rows.Count > 0 Then
                    UpdateOTSummary()
                ElseIf DTOT_Detail.Rows.Count = 0 Then
                    AddOTGrid()
                    If Val(txtOTDivider.Text) = 0 Then
                        MsgBox("OT divider is not setup ,Please Key in", MsgBoxStyle.Critical + MsgBoxStyle.Information, "Information")
                    End If
                End If

                If txtPremi.Enabled = True Then
                    txtPremi.Focus()
                ElseIf txtPremi.Enabled = False Then
                    txtblock.Focus()
                End If

                If txtPremi.Enabled = False And txtblock.Enabled = False Then
                    txtStation.Focus()
                End If

            End If
        Else
            txtblock.Focus()
        End If
    End Sub

    Private Sub txtT4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT4.Leave
        If txtT4.Text.Trim <> "" Then
            'By Dadang
            If Not String.IsNullOrEmpty(txtT4.Text) Then

                Dim DT As DataTable

                DT = DailyActivityDistributionWithTeam_DAL.Checkroll_CRTAnalisysSelect( _
                     "", "T4", txtT4.Text)

                If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                    lblT4Id.Text = String.Empty
                    lblT4Desc.Text = String.Empty

                    MessageBox.Show("TAnalysis Code not found.", "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    'txtT5.Focus()
                    txtT4.Text = String.Empty
                    btnAdd.Focus()

                ElseIf DT.Rows.Count = 1 Then
                    txtT4.Text = DT.Rows(0).Item("TValue").ToString()
                    lblT4Id.Text = DT.Rows(0).Item("TAnalysisID").ToString()
                    lblT4Desc.Text = DT.Rows(0).Item("TAnalysisDescp").ToString()
                    btnAdd.Focus()
                    'txtT5.Focus()
                End If

            ElseIf txtT4.Text = String.Empty Then
                'btnSearchT4.Focus()
                'txtT5.Focus()
                '
                lblT4Desc.Text = String.Empty
                lblT4Id.Text = String.Empty

                btnAdd.Focus()
            End If

            'btnSearchT4.Focus()
        Else
            btnAdd.Focus()
        End If
    End Sub
End Class