Imports Vehicle_BOL
Imports Vehicle_PPT
Imports Common_PPT

Public Class VehicleMonthEndClosingFrm

#Region "WorkshopLog"

    Dim _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT
    Dim _VehicleMonthlyProcessingBOL As VehicleMonthlyProcessingBOL
    Dim dsVehicleMonthlyProcessing As DataSet
    Dim dsWorkshopCode As DataSet
    Dim dsTotalExpenditureByDCCandVHWSCode As DataSet

#End Region

#Region "VehicleDistribution"

    Dim dsVehicleCode As DataSet

#End Region

#Region "Events"

    Private Sub VehicleMonthEndClosingFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        LblStatus.Text = String.Empty
        LblStatus.Refresh()
        LoadGridTaskStatus()
    End Sub
    Dim intMonthlyProcessCompleted As Integer = 1 'Calling monthly process from different class
    Private Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click
        If (VehicleMonthlyProcessingFrm.MonthlyProcess(0) = intMonthlyProcessCompleted) Then


            Dim lsComplete As String = String.Empty
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleMonthEndClosingFrm))

            If MsgBox(rm.GetString("BeginMEC"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to perform month end closing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                '_VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL


                'Dim liResult As Integer

                'liResult = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()

                'If liResult = 1 Then
                '_VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

                '_VehicleMonthlyProcessingBOL.VehicleApprovalUpdate()

                For Each objDataGridViewRow In gvTaskStatus.Rows
                    If objDataGridViewRow.Cells("Complete").Value.ToString() = "N" Then
                        If objDataGridViewRow.Cells("Task").Value.ToString() <> "Vehicle month end closing" And objDataGridViewRow.Cells("Task").Value.ToString() <> "Accounts month end closing" Then
                            lsComplete = "N"
                        End If
                    End If
                Next

                If lsComplete = "N" Then

                    MsgBox(rm.GetString("ITasksMEC"), MsgBoxStyle.OkOnly, "Information")
                    'MessageBox.Show("Could not proceed with month end closing. Some of the tasks not completed!")

                ElseIf gvTaskStatus.Rows.Count = 0 Then

                    MsgBox(rm.GetString("ITasksMEC"), MsgBoxStyle.OkOnly, "Information")
                    '                MessageBox.Show("Could not proceed with month end closing. Some of the tasks not completed!")

                Else

                    'btnProc.Enabled = False
                    'btnClose.Enabled = False 'disable the button so the user won't be able to click it again during the data processing time
                    Windows.Forms.Cursor.Current = Cursors.WaitCursor    'display a waiting cursor to show that the application is working on something

                    Dim fMsg As New ProgressingFrm            'create a new object for the message form
                    fMsg.TopMost = True                'this is to make sure that the message form is displayed at the top of your windows and the users cannot do anything to it except waiting
                    'fMsg.RightToLeftLayout.
                    fMsg.Show()                'use Show() instead of ShowDialog()

                    'LblStatus.Text = "Processing Database Backup..."
                    'LblStatus.Refresh()

                    fMsg.pbWait.Minimum = 0
                    fMsg.pbWait.Maximum = 100
                    fMsg.pbWait.Value = 0
                    fMsg.lblTitle.Text = "Progress"
                    fMsg.lblTitle.Refresh()

                    'Commented by sangar D on 28-Aug-2012 - Advised by ran team to imporove the application performance
                    'BeginBackupBSPDB("Before")
                    'fMsg.lblMessage.Text = "Performing Database Backup Before Month End Closing..."
                    'fMsg.lblMessage.Refresh()
                    'fMsg.pbWait.Refresh()
                    ''Common_BOL.GlobalBOL.AutoBSPBackup("Before", 3)
                    'fMsg.pbWait.Value += 20


                    'LblStatus.Text = "Processing Workshop Records..."
                    'LblStatus.Refresh()
                    GetWorkshop()
                    fMsg.lblMessage.Text = "Processing Workshop Records..."
                    fMsg.lblMessage.Refresh()
                    fMsg.pbWait.Refresh()
                    SaveWorkshopLogProcessing()
                    fMsg.pbWait.Value += 40

                    'LblStatus.Text = "Processing Vehicle Records..."
                    'LblStatus.Refresh()
                    GetVehicle()
                    fMsg.lblMessage.Text = "Processing Vehicle Records..."
                    fMsg.lblMessage.Refresh()
                    fMsg.pbWait.Refresh()
                    SaveVehicleProcessing()
                    fMsg.pbWait.Value += 20
                    'LblStatus.Text = "Performing Month End Closing..."
                    'LblStatus.Refresh()

                    fMsg.lblMessage.Text = "Performing Vehicle/Workshop Month End Closing..."
                    fMsg.lblMessage.Refresh()
                    fMsg.pbWait.Refresh()
                    _VehicleMonthlyProcessingPPT = New VehicleMonthlyProcessingPPT
                    _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

                    _VehicleMonthlyProcessingBOL.MonthEndClosing()

                    fMsg.pbWait.Value += 20

                    'LblStatus.Text = "Processing Database Backup..."
                    'LblStatus.Refresh()

                    'BeginBackupBSPDB("After")
                    'Commented on 14-June-2011 - Only to backup db before month-end closing
                    'fMsg.lblMessage.Text = "Performing Database Backup After Month End Closing..."
                    fMsg.lblMessage.Refresh()
                    fMsg.pbWait.Refresh()
                    'Common_BOL.GlobalBOL.AutoBSPBackup("After", 3)
                    fMsg.pbWait.Value += 20

                    'LblStatus.Text = String.Empty
                    'LblStatus.Refresh()
                    fMsg.pbWait.Refresh()
                    fMsg.Close()                'close the message form because the processing is done

                    'btnProc.Enabled = True
                    'btnClose.Enabled = True            'enable the button
                    MsgBox(rm.GetString("MECEnd"), MsgBoxStyle.OkOnly, "Information")
                    '                MsgBox("Month End Closing Completed.", MsgBoxStyle.OkOnly, "Information")
                    MdiParent.Close()
                    LoginFrm.Show()
                    'ElseIf liResult = 2 Then
                    '        MsgBox("Please approve the records in vehicle module to begin processing", MsgBoxStyle.OkOnly, "Information")
                    'ElseIf liResult = 0 Then
                    '        MsgBox("Vehicle processing of this month has been closed already!", MsgBoxStyle.OkOnly, "Information")
                End If


                'For Each objDataGridViewRow In gvTaskStatus.Rows
                '    If objDataGridViewRow.Cells("Complete").Value.ToString() = "N" Then
                '        If objDataGridViewRow.Cells("Task").Value.ToString() <> "Store month end closing" Then
                '            lsComplete = "N"
                '        End If
                '    End If
                'Next
                'If lsComplete = "N" Then

                '    MessageBox.Show("Could not proceed Month End Closing ...Some of the status not completed.")

                'Else

                '    Dim objVehicleMonthlyProcessingPPT As New VehicleMonthlyProcessingPPT

                '    VehicleMonthlyProcessingBOL.DoStoreMonthEndClosing(objVehicleMonthlyProcessingPPT)

                '    ''VehicleMonthlyProcessingBOL.TaskMonitorUpdate(objVehicleMonthlyProcessingPPT)

                '    ''VehicleMonthlyProcessingBOL.TaskMonitorInsert(objVehicleMonthlyProcessingPPT)

                '    MessageBox.Show("Month End Closing Completed.")

                '    MdiParent.Close()
                '    LoginFrm.Show()

                'End If
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleMonthEndClosingFrm))
        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub LoadGridTaskStatus()

        Dim dsLoadGridTaskStatus As New DataSet
        dsLoadGridTaskStatus = VehicleMonthlyProcessingBOL.TaskMonitorGet()
        If dsLoadGridTaskStatus.Tables(0).Rows.Count > 0 Then
            gvTaskStatus.AutoGenerateColumns = False
            gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
        Else
            gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
        End If

    End Sub

#Region "WorkshopLog"

    'Private Sub BeginBackupBSPDB(ByVal lsBeforeorAfter As String)
    '_VehicleMonthlyProcessingPPT = New VehicleMonthlyProcessingPPT
    '_VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL
    '_VehicleMonthlyProcessingPPT.psTask = lsBeforeorAfter '"Before"
    '_VehicleMonthlyProcessingBOL.BeginBackupBSPDB(_VehicleMonthlyProcessingPPT)
    'End Sub

    Private Sub GetWorkshop()

        _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

        dsWorkshopCode = New DataSet
        dsWorkshopCode = _VehicleMonthlyProcessingBOL.GetWorkshopCode()

    End Sub

    Private Sub SaveWorkshopLogProcessing()

        For Each drWorkshopCode As DataRow In dsWorkshopCode.Tables(0).Rows

            _VehicleMonthlyProcessingPPT = New VehicleMonthlyProcessingPPT
            _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

            _VehicleMonthlyProcessingPPT.psWorkVHID = drWorkshopCode("VHWSCode").ToString()

            dsTotalExpenditureByDCCandVHWSCode = New DataSet

            dsTotalExpenditureByDCCandVHWSCode = _VehicleMonthlyProcessingBOL.GetTotalExpenditure(_VehicleMonthlyProcessingPPT)

            Dim _VehicleMonthlyProcessingPPT1 As New VehicleMonthlyProcessingPPT
            Dim _VehicleMonthlyProcessingBOL1 As New VehicleMonthlyProcessingBOL


            For Each drTotalExpenditureByDCCandVHWSCode As DataRow In dsTotalExpenditureByDCCandVHWSCode.Tables(0).Rows


                _VehicleMonthlyProcessingPPT1.psWorkVHID = drTotalExpenditureByDCCandVHWSCode("VHWSCode").ToString()
                _VehicleMonthlyProcessingPPT1.psVHDetailCostCode = drTotalExpenditureByDCCandVHWSCode("VHDetailCostCode").ToString()
                _VehicleMonthlyProcessingPPT1.pdTotalExpenditure = Convert.ToDecimal(drTotalExpenditureByDCCandVHWSCode("TotalExp"))

                _VehicleMonthlyProcessingBOL1.SaveVHRunningCostSummary(_VehicleMonthlyProcessingPPT1)

            Next

            _VehicleMonthlyProcessingBOL.SaveWorkshopVHRunningDetail(_VehicleMonthlyProcessingPPT)

            _VehicleMonthlyProcessingBOL.SaveWorkshopLogProcessing(_VehicleMonthlyProcessingPPT)

        Next

    End Sub


#End Region

#Region "VehicleDistribution"

    Private Sub GetVehicle()

        _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

        dsVehicleCode = New DataSet
        dsVehicleCode = _VehicleMonthlyProcessingBOL.GetVehicleCode()

    End Sub

    Private Sub SaveVehicleProcessing()

        For Each drVehicleCode As DataRow In dsVehicleCode.Tables(0).Rows

            _VehicleMonthlyProcessingPPT = New VehicleMonthlyProcessingPPT
            _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

            _VehicleMonthlyProcessingPPT.psWorkVHID = drVehicleCode("VHWSCode").ToString()

            dsTotalExpenditureByDCCandVHWSCode = New DataSet

            dsTotalExpenditureByDCCandVHWSCode = _VehicleMonthlyProcessingBOL.GetTotalExpenditure(_VehicleMonthlyProcessingPPT)

            Dim _VehicleMonthlyProcessingPPT1 As New VehicleMonthlyProcessingPPT
            Dim _VehicleMonthlyProcessingBOL1 As New VehicleMonthlyProcessingBOL


            For Each drTotalExpenditureByDCCandVHWSCode As DataRow In dsTotalExpenditureByDCCandVHWSCode.Tables(0).Rows


                _VehicleMonthlyProcessingPPT1.psWorkVHID = drTotalExpenditureByDCCandVHWSCode("VHWSCode").ToString()
                _VehicleMonthlyProcessingPPT1.psVHDetailCostCode = drTotalExpenditureByDCCandVHWSCode("VHDetailCostCode").ToString()
                _VehicleMonthlyProcessingPPT1.pdTotalExpenditure = Convert.ToDecimal(drTotalExpenditureByDCCandVHWSCode("TotalExp"))

                _VehicleMonthlyProcessingBOL1.SaveVHRunningCostSummary(_VehicleMonthlyProcessingPPT1)

            Next

            _VehicleMonthlyProcessingBOL.SaveVehicleVHRunningDetail(_VehicleMonthlyProcessingPPT)

            _VehicleMonthlyProcessingBOL.SaveVehicleProcessing(_VehicleMonthlyProcessingPPT)

        Next

    End Sub


#End Region

    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleMonthEndClosingFrm))

        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            gvTaskStatus.Columns("TASK").HeaderText = rm.GetString("TASK")
            gvTaskStatus.Columns("Complete").HeaderText = rm.GetString("Complete")
            btnProc.Text = rm.GetString("btnProc")
            btnClose.Text = rm.GetString("btnClose")
            PnlSearch.CaptionText = rm.GetString("TaskStatus")


        Catch ex As Exception

        End Try

        'System.Threading.Thread.CurrentThread.CurrentUICulture=

    End Sub

#End Region

    'Private Function TaskConfigTaskCheck() As String

    '    Dim objVehicleMonthlyProcessingPPT As New VehicleMonthlyProcessingPPT
    '    Dim lsTaskCheck As String = "N"
    '    Dim dsTaskCheck As New DataSet
    '    dsTaskCheck = VehicleMonthlyProcessingBOL.TaskConfigTaskCheckGet(objVehicleMonthlyProcessingPPT)
    '    If dsTaskCheck.Tables(0).Rows.Count <> 0 Then
    '        lsTaskCheck = dsTaskCheck.Tables(0).Rows(0).Item("CValue")
    '    End If
    '    Return lsTaskCheck

    'End Function

End Class

