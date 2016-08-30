Imports Vehicle_BOL
Imports Vehicle_PPT
Imports Common_PPT

Public Class VehicleMonthlyProcessingFrm

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

    Private Sub VehicleMonthlyProcessingFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'LoadGridTaskStatus()

        'Dim response = MsgBox("You are about to perform monthly processing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel"".", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical, "BSP")


        'If response = MsgBoxResult.Yes Then

        'Added by sangar d on 28-Aug-12
        MonthlyProcess(0)

        'LoadGridTaskStatus()

    End Sub
    ''' <summary>
    '''this method perform the monthly process 'Added by sangar d on 28-Aug-12 to implement the monthly process in the month end closing process also.
    ''' </summary>
    ''' <param name="isOwnForm">if the param is 1 then this method is called from the same form. if the param value is 0 then this method is calling from the other form</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MonthlyProcess(ByVal isOwnForm As Integer)
        Dim intProcessStoped As Integer = 0
        Dim intProcessCompleted As Integer = 1
        Dim PCircle As New SpinningProgressFrm

        Try

            PCircle.TopMost = True
            PCircle.Show()
            PCircle.SpinningProgressBar.Refresh()



            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleMonthlyProcessingFrm))

            If MsgBox(rm.GetString("BeginVWProcess"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to perform monthly processing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim lsComplete As String = String.Empty

                Dim dsLoadGridTaskStatus As New DataSet
                dsLoadGridTaskStatus = VehicleMonthlyProcessingBOL.TaskMonitorGet()

                For Each objDataGridViewRow In dsLoadGridTaskStatus.Tables(0).Rows
                    If objDataGridViewRow("Complete").ToString() = "N" Then
                        If objDataGridViewRow("Task").ToString() <> "Store month end closing" Then
                            lsComplete = "N"
                        End If
                    End If
                Next

                If lsComplete = "N" Then
                    If MsgBox(rm.GetString("OtherModsNotComplete"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                        '                If MsgBox("Store/Accounts module month end closing not completed. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel"".", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                        MonthlyProcess = intProcessStoped
                        Exit Function
                    End If

                    'MessageBox.Show("Still Some of the tasks of other modules haven't completed!")

                End If


                'Me.Hide()

                'System.Threading.Thread.Sleep(1000)

                Windows.Forms.Cursor.Current = Cursors.WaitCursor    'display a waiting cursor to show that the application is working on something

                Dim fMsg As New ProgressingFrm            'create a new object for the message form
                fMsg.TopMost = True                'this is to make sure that the message form is displayed at the top of your windows and the users cannot do anything to it except waiting
                'fMsg.RightToLeftLayout.
                fMsg.Show()                'use Show() instead of ShowDialog()

                'fMsg.lblMessage.Text = "Processing Database Backup..."
                'fMsg.lblMessage.Refresh()

                'LblStatus.Text = "Process Salary Premi.."
                'LblStatus.Refresh()

                fMsg.pbWait.Minimum = 0
                fMsg.pbWait.Maximum = 100
                fMsg.pbWait.Value = 0
                fMsg.lblTitle.Text = "Progress"
                fMsg.lblTitle.Refresh()

                _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL


                'Dim liResult As Integer

                'liResult = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()

                'If liResult = 1 Then
                GetWorkshop()
                fMsg.lblMessage.Text = "Processing Workshop Records..."
                fMsg.lblMessage.Refresh()
                SaveWorkshopLogProcessing()
                fMsg.pbWait.Value += 35
                'System.Threading.Thread.Sleep(2000)

                GetVehicle()
                fMsg.lblMessage.Text = "Processing Vehicle Records..."
                fMsg.lblMessage.Refresh()
                SaveVehicleProcessing()
                fMsg.pbWait.Value += 35
                'System.Threading.Thread.Sleep(2000)

                fMsg.lblMessage.Text = "Performing Vehicle/Workshop Processing..."
                fMsg.lblMessage.Refresh()
                _VehicleMonthlyProcessingPPT = New VehicleMonthlyProcessingPPT
                _VehicleMonthlyProcessingBOL = New VehicleMonthlyProcessingBOL

                _VehicleMonthlyProcessingPPT.piId = 3
                _VehicleMonthlyProcessingPPT.psTask = "Vehicle monthly processing"
                _VehicleMonthlyProcessingPPT.pcComplete = "Y"

                _VehicleMonthlyProcessingBOL.SaveTaskMonitor(_VehicleMonthlyProcessingPPT)

                fMsg.pbWait.Value += 30
                'System.Threading.Thread.Sleep(2000)

                'obj.Sleep(5000)

                fMsg.Close()                'close the message form because the processing is done

                'Me.Show()
                MsgBox(rm.GetString("ProcessEnd"), MsgBoxStyle.OkOnly, "Information")
                'MsgBox("Monthly Processing has successfully completed", MsgBoxStyle.OkOnly, "Information")
                'ElseIf liResult = 2 Then
                '    MsgBox("Please approve the records in vehicle module to begin month end closing", MsgBoxStyle.OkOnly, "Information")
                'ElseIf liResult = 0 Then
                '    MsgBox("Vehicle processing of this month has been closed already!", MsgBoxStyle.OkOnly, "Information")
                'End If

            Else
                MonthlyProcess = intProcessStoped
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            PCircle.Close()

        Finally
            PCircle.Close()
        End Try
        MonthlyProcess = intProcessCompleted
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

#End Region

#Region "Functions"

    'Private Sub LoadGridTaskStatus()

    '    Dim dsLoadGridTaskStatus As New DataSet
    '    dsLoadGridTaskStatus = VehicleMonthlyProcessingBOL.TaskMonitorGet()
    '    If dsLoadGridTaskStatus.Tables(0).Rows.Count > 0 Then
    '        gvTaskStatus.AutoGenerateColumns = False
    '        gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
    '    Else
    '        gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
    '    End If

    'End Sub

#Region "WorkshopLog"

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
                If Not IsDBNull(drTotalExpenditureByDCCandVHWSCode("TotalExp")) Then
                    _VehicleMonthlyProcessingPPT1.pdTotalExpenditure = Convert.ToDecimal(drTotalExpenditureByDCCandVHWSCode("TotalExp"))
                Else
                    _VehicleMonthlyProcessingPPT1.pdTotalExpenditure = 0
                End If

                _VehicleMonthlyProcessingBOL1.SaveVHRunningCostSummary(_VehicleMonthlyProcessingPPT1)

            Next

            _VehicleMonthlyProcessingBOL.SaveVehicleVHRunningDetail(_VehicleMonthlyProcessingPPT)

            _VehicleMonthlyProcessingBOL.SaveVehicleProcessing(_VehicleMonthlyProcessingPPT)

        Next

    End Sub

#End Region


#End Region

    
End Class