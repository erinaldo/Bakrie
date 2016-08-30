Imports System.Data.SqlClient
Imports System.ComponentModel
Imports CheckRoll_DAL

Public Class DetailOTProcess

    Dim bw As BackgroundWorker = New BackgroundWorker
    Private dOTResult As Decimal = 0
    Private dRateSetup_BasicRate As Decimal = 0
    Private iRateSetup_OTDivider As Integer = 173
    Private iRateSetup_RiceDividerDays As Integer = 30 ' Ahad, 22 Nov 2009, 21:12
    Private iRateSetup_RicePrice As Decimal = 9000

    Private Sub DetailOTProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SQL Server Information
        Dim ConStr As String = Common_PPT.GlobalPPT.ConnectionString
        Dim SQLConn As SqlConnection
        SQLConn = New SqlConnection(ConStr)
        SQLConn.Open()

        Dim query As String = "SELECT FromDT, ToDT FROM General.FiscalYear WHERE FYear = " & Common_PPT.GlobalPPT.intActiveYear.ToString() & " AND Period = " + Common_PPT.GlobalPPT.IntActiveMonth.ToString()
        Dim cmd As New SqlCommand(query, SQLConn)
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        If dr.Read() Then
            dpFrom.Value = Convert.ToDateTime(dr("FromDT"))
            dpTo.Value = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(dr("ToDT")))
        End If

        dr.Close()

        query = "SELECT  RAPRice from Checkroll.TaxAndRiceSetup where  EstateID = '" & Common_PPT.GlobalPPT.strEstateID & "'"
        SQLConn.Open()
        cmd = New SqlCommand(query, SQLConn)
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        If dr.Read() Then
            Me.txtRicePrice.Text = dr("RAPrice")
        End If
        dr.Close()
        SQLConn.Close()


            ' background worker -----------------------------
            'bw.WorkerSupportsCancellation = True
            'bw.WorkerReportsProgress = True
            'AddHandler bw.DoWork, AddressOf bw_DoWork
            'AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
            'AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        PremiProcess(dpFrom.Value, dpTo.Value)
        'If Not bw.IsBusy = True Then
        '  bw.RunWorkerAsync()
        ' End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        ProgressBar1.Value = 0
        'PremiProcess(worker, e, dpFrom.Value, dpTo.Value)
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        lblProgress.Text = "Processing " + e.ProgressPercentage.ToString() + "%"
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            lblProgress.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            lblProgress.Text = "Error: " & e.Error.Message
        Else
            lblProgress.Text = "Done!"
        End If
    End Sub



    Sub PremiProcess(ByVal fromDT As DateTime, ByVal toDT As DateTime)

        Dim ActiveMonthYearID As String = Common_PPT.GlobalPPT.strActMthYearID
        Dim EstateID As String = Common_PPT.GlobalPPT.strEstateID
        Dim EstateCode As String = Common_PPT.GlobalPPT.strEstateCode
        Dim CreatedBy As String = Common_PPT.GlobalPPT.strUserName

        Dim ConStr As String = Common_PPT.GlobalPPT.ConnectionString

        Dim queryEMP As String = "select DA.Empid,DA.AttendanceSetupID,DA.TotalOT,OTS.OvertimeTimes1,OTS.OvertimeTimes2,OTS.OvertimeTimes3,OTS.OvertimeTimes4,ots.OvertimeMaxOTHours1,ots.OvertimeMaxOTHours2,ots.OvertimeMaxOTHours3,ots.OvertimeMaxOTHours4, " & _
        "DA.ActiveMonthYearID,DT.MandoreID,DT.KraniID,DT.GangMasterID,DT.DDate, DT.Activity, DA.ID,EMP.Category from Checkroll.DailyAttendance DA  " & _
        "inner join checkroll.CREmployee Emp on DA.Empid = EMP.EMPID " & _
        "inner join Checkroll.OverTimeSetup OTS on DA.AttendanceSetupID = OTS.AttendanceSetupID  and OTS.CropId = EMP.Category " & _
        "inner join Checkroll.DailyTeamActivity DT on DA.DailyTeamActivityID = DT.DailyTeamActivityID " & _
        " where DA.EstateID = '" & EstateID & _
        "' and  DA.RDate >= '" & fromDT.ToString("yyyy-MM-dd") & "'  and DA.RDate <= '" & toDT.ToString("yyyy-MM-dd") & "' AND DA.TotalOT > 0 "


        Dim SQLConnEmp As SqlConnection = New SqlConnection(ConStr)
        SQLConnEmp.Open()


        Dim cmdEmp As New SqlCommand(queryEMP, SQLConnEmp)


        Dim dt As New DataTable
        dt.Load(cmdEmp.ExecuteReader)

        Dim drEmp As DataTableReader = New DataTableReader(dt)

        Dim currentDay As DateTime = fromDT
        Dim i As Int32 = 0
        Dim total As Int32 = dt.Rows.Count
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = total

        While drEmp.Read()
            
                'lblProgress.Text = "Employee Number : " + i.ToString()
            '  bw.ReportProgress((i / total) * 100)

                txtOT1.Text = drEmp("OvertimeTimes1")
                txtOT2.Text = drEmp("OvertimeTimes2")
                txtOT3.Text = drEmp("OvertimeTimes3")
                txtOT4.Text = drEmp("OvertimeTimes4")

                txtMax1.Text = drEmp("OvertimeMaxOTHours1")
                txtMax2.Text = drEmp("OvertimeMaxOTHours2")
                txtMax3.Text = drEmp("OvertimeMaxOTHours3")
                txtMax4.Text = drEmp("OvertimeMaxOTHours4")

                getRateSetup(drEmp("EmpId"))
                CountOverTime(drEmp("TotalOT"))



                Dim dOT1 As Double
                Dim dOT1value As Double

                Dim dOT2 As Double
                Dim dOT2value As Double

                Dim dOT3 As Double
                Dim dOT3value As Double

                Dim dOT4 As Double
                Dim dOT4value As Double

                Dim BasicOT As Double
                Dim dTotalOTValue As Double

                If iRateSetup_OTDivider = 0 Then
                    BasicOT = 0
                Else
                BasicOT = ((Convert.ToDouble(txtBasicRate.Text) * iRateSetup_RiceDividerDays) + (iRateSetup_RicePrice * 15)) / iRateSetup_OTDivider
                    'BasicOT = Math.Round(BasicOT, 0)
                End If


                dOT1 = Convert.ToDouble(txtH1.Text)
                dOT1value = dOT1 * Convert.ToDouble(txtOT1.Text) * BasicOT
                dOT2 = Convert.ToDouble(txtH2.Text)
                dOT2value = dOT2 * Convert.ToDouble(txtOT2.Text) * BasicOT
                dOT3 = Convert.ToString(txtH3.Text)
                dOT3value = dOT3 * Convert.ToDouble(txtOT3.Text) * BasicOT
                dOT4 = Convert.ToString(txtH4.Text)
                dOT4value = dOT4 * Convert.ToDouble(txtOT4.Text) * BasicOT



                If iRateSetup_OTDivider <> 0 Then
                    dTotalOTValue = dOTResult * BasicOT
                End If

                txtTotalOTValue.Text = dTotalOTValue.ToString("#,##0.00")

            'Update DailyAttendance Total OT Value

            DailyAttendance_DAL.UpdateOTValue(drEmp("Id"), txtTotalOTValue.Text)

                'Update DAilyOT

            OTDetailDAL.OTDetailInsertProcess(drEmp("EmpID"), drEmp("GangMasterId"), drEmp("Activity"), _
                                              drEmp("MandoreID").ToString, drEmp("KraniId").ToString, drEmp("DDate"),
                                              drEmp("EmpId"), dOT1, dOT1value, dOT2, dOT2value, dOT3, dOT3value, dOT4, dOT4value, drEmp("ActiveMonthYearID"))


            
                'reset for the next employee
                i = i + 1
            lblProgress.Text = "Processing " & i.ToString & " Records"
            ProgressBar1.Value = i
        End While
        dt = Nothing
        'Loop for Mandor BEsar, Kerani and Mandor Records. 
        queryEMP = "Select DM.ID, DM.EmpID,DM.AttendanceSetupID,DM.DailyOt as TotalOT,DM.RDate, DM.ActiveMOnthYearID, " & _
                   "OTS.OvertimeTimes1, OTS.OvertimeTimes2, OTS.OvertimeTimes3, OTS.OvertimeTimes4, ots.OvertimeMaxOTHours1, ots.OvertimeMaxOTHours2, ots.OvertimeMaxOTHours3, ots.OvertimeMaxOTHours4 " & _
                  " from Checkroll.DailyAttendanceMandor DM " & _
                  "inner join Checkroll.CREmployee EMP on EMP.EmpID = DM.EmpID " & _
                  "inner join Checkroll.OverTimeSetup OTS on DM.AttendanceSetupID = OTS.AttendanceSetupID and EMP.Category = ots.CropId " & _
                  " where DM.DailyOt > 0 " & _
                  " and  DM.RDate >= '" & fromDT.ToString("yyyy-MM-dd") & "'  and DM.RDate <= '" & toDT.ToString("yyyy-MM-dd") & "' "
        '  AND DM.EMPID= 'C00203407'
   
        cmdEmp = New SqlCommand(queryEMP, SQLConnEmp)
        dt = New DataTable
        dt.Load(cmdEmp.ExecuteReader)

        drEmp = New DataTableReader(dt)
        i = 0
        total = dt.Rows.Count
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = total

        While drEmp.Read()

            lblProgress.Text = "Employee Number : " + i.ToString()
            '     '  bw.ReportProgress((i / total) * 100)

            txtOT1.Text = drEmp("OvertimeTimes1")
            txtOT2.Text = drEmp("OvertimeTimes2")
            txtOT3.Text = drEmp("OvertimeTimes3")
            txtOT4.Text = drEmp("OvertimeTimes4")

            txtMax1.Text = drEmp("OvertimeMaxOTHours1")
            txtMax2.Text = drEmp("OvertimeMaxOTHours2")
            txtMax3.Text = drEmp("OvertimeMaxOTHours3")
            txtMax4.Text = drEmp("OvertimeMaxOTHours4")

            getRateSetup(drEmp("EmpId"))
            CountOverTime(drEmp("TotalOT"))



            Dim dOT1 As Double
            Dim dOT1value As Double

            Dim dOT2 As Double
            Dim dOT2value As Double

            Dim dOT3 As Double
            Dim dOT3value As Double

            Dim dOT4 As Double
            Dim dOT4value As Double

            Dim BasicOT As Double
            Dim dTotalOTValue As Double

            If iRateSetup_OTDivider = 0 Then
                BasicOT = 0
            Else
                BasicOT = ((Convert.ToDouble(txtBasicRate.Text) * iRateSetup_RiceDividerDays) + (iRateSetup_RicePrice * 15)) / iRateSetup_OTDivider
                ' BasicOT = Math.Round(BasicOT, 0)
            End If


            dOT1 = Convert.ToDouble(txtH1.Text)
            dOT1value = dOT1 * Convert.ToDouble(txtOT1.Text) * BasicOT
            dOT2 = Convert.ToDouble(txtH2.Text)
            dOT2value = dOT2 * Convert.ToDouble(txtOT2.Text) * BasicOT
            dOT3 = Convert.ToString(txtH3.Text)
            dOT3value = dOT3 * Convert.ToDouble(txtOT3.Text) * BasicOT
            dOT4 = Convert.ToString(txtH4.Text)
            dOT4value = dOT4 * Convert.ToDouble(txtOT4.Text) * BasicOT



            If iRateSetup_OTDivider <> 0 Then
                dTotalOTValue = dOTResult * BasicOT
            End If

            txtTotalOTValue.Text = dTotalOTValue.ToString("#,##0.00")

            'Update DailyAttendance Mandor Total OT Value

            Dim drDTA As DataTable
            drDTA = DailyAttendanceMandor_DAL.GetGangDetailsByEmployee(drEmp("EmpId"), drEmp("RDate"))
            If drDTA.Rows.Count > 0 Then
                OTDetailDAL.OTDetailInsertProcess(drEmp("EmpID"), drDTA.Rows(0)("GangMasterId"), drDTA.Rows(0)("Activity"), _
                                                      drDTA.Rows(0)("MandoreID").ToString, drDTA.Rows(0)("KraniId").ToString, drDTA.Rows(0)("DDate"),
                                                       drEmp("EmpId"), dOT1, dOT1value, dOT2, dOT2value, dOT3, dOT3value, dOT4, dOT4value, drEmp("ActiveMonthYearID"))
            Else
                OTDetailDAL.OTDetailInsertProcess(drEmp("EmpID"), "", "", _
                                                  "", "", drEmp("RDate"),
                                                      drEmp("EmpId"), dOT1, dOT1value, dOT2, dOT2value, dOT3, dOT3value, dOT4, dOT4value, drEmp("ActiveMonthYearID"))

            End If
            drDTA = Nothing
            DailyAttendanceMandor_DAL.UpdateOTValue(drEmp("Id"), txtTotalOTValue.Text)

            'Update(DAilyOT)

            

            '     'reset for the next employee
            i = i + 1
            lblProgress.Text = "Processing " & i.ToString & " Records"
            ProgressBar1.Value = i
        End While

    End Sub

    Private Sub CountOverTime(txtOTHours As Double)
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

        DailyOT = FormatNumber(txtOTHours, 2)

        HasilOT = DailyOT

        dMax1 = FormatNumber(Val(txtMax1.Text), 2)
        dOT1 = FormatNumber(Val(txtOT1.Text), 2)

        dMax2 = FormatNumber(Val(txtMax2.Text), 2)
        dOT2 = FormatNumber(Val(txtOT2.Text), 2)

        dMax3 = FormatNumber(Val(txtMax3.Text), 2)
        dOT3 = FormatNumber(Val(txtOT3.Text), 2)

        dMax4 = FormatNumber(Val(txtMax4.Text), 2)
        dOT4 = FormatNumber(Val(txtOT4.Text), 2)

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




        txtH1.Text = dH1.ToString()
        txtH2.Text = dH2.ToString()
        txtH3.Text = dH3.ToString()
        txtH4.Text = dH4.ToString()

        dOTResult = (dOT1 * dH1) + (dOT2 * dH2) + (dOT3 * dH3) + (dOT4 * dH4)
        txtOTResult.Text = dOTResult.ToString("#,##0.00")
    End Sub

    Public Sub getRateSetup(EmpId As String)
        'Gets Rate By Employee


        Dim DT_RateSetup As DataTable

        Cursor = Cursors.WaitCursor
        DT_RateSetup = AdvancePayment_DAL.CRRateSetupSelectEmp(EmpId)
        Cursor = Cursors.Default

        dRateSetup_BasicRate = 0
        iRateSetup_OTDivider = 0
        iRateSetup_RicePrice = 0

        If DT_RateSetup.Rows.Count > 0 Then

            If DT_RateSetup.Rows(0).IsNull("BasicRate") Then
                dRateSetup_BasicRate = 0
            Else
                If DT_RateSetup.Rows(0).Item("BasicRate") = 0 Then
                    dRateSetup_BasicRate = 0
                Else
                    dRateSetup_BasicRate = DT_RateSetup.Rows(0).Item("BasicRate")
                End If
            End If

            If DT_RateSetup.Rows(0).IsNull("OTDivider") Then
                iRateSetup_OTDivider = 0
            Else
                If DT_RateSetup.Rows(0).Item("OTDivider") = 0 Then
                    iRateSetup_OTDivider = 0
                Else
                    iRateSetup_OTDivider = DT_RateSetup.Rows(0).Item("OTDivider")
                End If

            End If

            If DT_RateSetup.Rows(0).IsNull("RiceDividerDays") Then
                iRateSetup_RiceDividerDays = 0                
            Else
                If DT_RateSetup.Rows(0).Item("RiceDividerDays") = 0 Then
                    iRateSetup_RiceDividerDays = 0
                Else
                    iRateSetup_RiceDividerDays = DT_RateSetup.Rows(0).Item("RiceDividerDays")
                End If
            End If

            iRateSetup_RicePrice = Me.txtRicePrice.Text

            'If DT_RateSetup.Rows(0).IsNull("RicePayment") Then
            '    iRateSetup_RicePrice = 0
            'Else
            '    If DT_RateSetup.Rows(0).Item("RicePayment") = 0 Then
            '        iRateSetup_RicePrice = 0
            '    Else
            '        iRateSetup_RicePrice = DT_RateSetup.Rows(0).Item("RicePayment")
            '    End If
            'End If

        End If

        txtBasicRate.Text = dRateSetup_BasicRate
    End Sub


End Class