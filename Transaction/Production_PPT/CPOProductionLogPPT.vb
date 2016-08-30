Public Class CPOProductionLogPPT
#Region "Private Member Declarations"
    Private _ProductionLogDate As DateTime
    Private _CropYieldID As String

    ''For Shift1
    Private _StartTime1 As String
    Private _StopTime1 As String
    Private _TotalBreakdown1 As String
    Private _AssistantEmpID1 As String
    Private _MandoreEmpID1 As String
    Private _Shift1 As String
    Private _FFBProcessedEST1 As Decimal
    Private _LorryProcessedEST1 As Decimal

    ''For Shift2

    Private _StartTime2 As String
    Private _StopTime2 As String
    Private _TotalBreakdown2 As String
    Private _AssistantEmpID2 As String
    Private _MandoreEmpID2 As String
    Private _Shift2 As String
    Private _FFBProcessedEST2 As Decimal
    Private _LorryProcessedEST2 As Decimal

    ''For Shift3

    Private _StartTime3 As String
    Private _StopTime3 As String
    Private _TotalBreakdown3 As String
    Private _AssistantEmpID3 As String
    Private _MandoreEmpID3 As String
    Private _Shift3 As String
    Private _FFBProcessedEST3 As Decimal
    Private _LorryProcessedEST3 As Decimal

    Private _TotalHours As String
    Private _MonthToDateHrs As String
    Private _YeartoDateHrs As String
    Private _BalanceFFBBFQty As Decimal
    Private _BalanceFFBBFNoLorry As Decimal
    Private _FFBReceived As Decimal
    Private _FFBReceivedLorry As Decimal

    Private _FFBReceivedMTD As Decimal
    Private _FFBReceivedYTD As Decimal
    Private _FFBProcessedACT As Decimal
    Private _LorryProcessedACT As Decimal
    Private _BalanceFFBCFQty As Decimal
    Private _BalanceFFBCFNoLorry As Decimal
    Private _KernelProduction As Decimal
    Private _LossOfKernel As Decimal
    Private _AvgLorryWeight As Decimal
    Private _MechanicalBD As String
    Private _ElectricalBD As String
    Private _ProcessingBD As String
    Private _TotalBD As String
    Private _EffectiveProcessingHours As String
    Private _Throughput As Decimal
    Private _OER As Decimal
    Private _KER As Decimal
    Private _Remarks As String
    Private _CPOProductionLogID As String

    ''' CPO Production Log press Field

    Private _ProductionLogPressID As String = String.Empty
    Private _StagePress As String = String.Empty
    Private _ScrewAge As Decimal
    Private _MachineID As String = String.Empty
    Private _PressNo As String = String.Empty
    Private _MeterFrom As String
    Private _MeterTo As String
    Private _OPHrs As String
    Private _ScrewStatus As String = String.Empty
    Private _PCage As String = String.Empty

    ''' CPO Production Log press Field Summary
    Private _PressSummaryID As String = String.Empty
    Private _TotalPressHrsToday As String
    Private _TotalPressHrsMTD As String
    Private _TotalPressHrsYTD As String
    Private _AvgPressThrToday As String
    Private _AvgPressThrMTD As String
    Private _AvgPressThrYTD As String
    Private _UtilizationToday As String
    Private _UtilizationMTD As String
    Private _UtilizationYTD As String

    '' newly added on may 13
    Private _FFBProcessedMTD As Decimal
    Private _LorryProcessedMTD As Integer
    Private _LossOfKernelMTD As Decimal
    Private _MechanicalBDMTD As String
    Private _ElectricalBDMTD As String
    Private _ProcessingBDMTD As String

    Private _FFBProcessedYTD As Decimal
    Private _LorryProcessedYTD As Integer
    Private _LossOfKernelYTD As Decimal
    Private _MechanicalBDYTD As String
    Private _ElectricalBDYTD As String
    Private _ProcessingBDYTD As String


#End Region
#Region "Public Member Declarations"

    Public Property TotalHours() As String
        Get
            Return _TotalHours
        End Get
        Set(ByVal value As String)
            _TotalHours = value
        End Set
    End Property

    Public Property CPOProductionLogID() As String
        Get
            Return _CPOProductionLogID
        End Get
        Set(ByVal value As String)
            _CPOProductionLogID = value
        End Set
    End Property
    Public Property FFBProcessedACT() As Decimal
        Get
            Return _FFBProcessedACT
        End Get
        Set(ByVal value As Decimal)
            _FFBProcessedACT = value
        End Set
    End Property
    Public Property FFBReceivedMTD() As Decimal
        Get
            Return _FFBReceivedMTD
        End Get
        Set(ByVal value As Decimal)
            _FFBReceivedMTD = value
        End Set
    End Property
    Public Property FFBReceivedYTD() As Decimal
        Get
            Return _FFBReceivedYTD
        End Get
        Set(ByVal value As Decimal)
            _FFBReceivedYTD = value
        End Set
    End Property
    Public Property FFBReceivedLorry() As Decimal
        Get
            Return _FFBReceivedLorry
        End Get
        Set(ByVal value As Decimal)
            _FFBReceivedLorry = value
        End Set
    End Property
    Public Property BalanceFFBBFNoLorry() As Decimal
        Get
            Return _BalanceFFBBFNoLorry
        End Get
        Set(ByVal value As Decimal)
            _BalanceFFBBFNoLorry = value
        End Set
    End Property
    Public Property FFBReceived() As Decimal
        Get
            Return _FFBReceived
        End Get
        Set(ByVal value As Decimal)
            _FFBReceived = value
        End Set
    End Property

    Public Property BalanceFFBBFQty() As Decimal
        Get
            Return _BalanceFFBBFQty
        End Get
        Set(ByVal value As Decimal)
            _BalanceFFBBFQty = value
        End Set
    End Property

    Public Property MonthToDateHrs() As String
        Get
            Return _MonthToDateHrs
        End Get
        Set(ByVal value As String)
            _MonthToDateHrs = value
        End Set
    End Property

    Public Property YeartoDateHrs() As String
        Get
            Return _YeartoDateHrs
        End Get
        Set(ByVal value As String)
            _YeartoDateHrs = value
        End Set
    End Property
    Public Property AssistantEmpID1() As String
        Get
            Return _AssistantEmpID1
        End Get
        Set(ByVal value As String)
            _AssistantEmpID1 = value
        End Set
    End Property
    Public Property AssistantEmpID2() As String
        Get
            Return _AssistantEmpID2
        End Get
        Set(ByVal value As String)
            _AssistantEmpID2 = value
        End Set
    End Property
    Public Property AssistantEmpID3() As String
        Get
            Return _AssistantEmpID3
        End Get
        Set(ByVal value As String)
            _AssistantEmpID3 = value
        End Set
    End Property
    Public Property MandoreEmpID1() As String
        Get
            Return _MandoreEmpID1
        End Get
        Set(ByVal value As String)
            _MandoreEmpID1 = value
        End Set
    End Property
    Public Property MandoreEmpID2() As String
        Get
            Return _MandoreEmpID2
        End Get
        Set(ByVal value As String)
            _MandoreEmpID2 = value
        End Set
    End Property
    Public Property MandoreEmpID3() As String
        Get
            Return _MandoreEmpID3
        End Get
        Set(ByVal value As String)
            _MandoreEmpID3 = value
        End Set
    End Property

    Public Property StartTime1() As String
        Get
            Return _StartTime1
        End Get
        Set(ByVal value As String)
            _StartTime1 = value
        End Set
    End Property
    Public Property StartTime2() As String
        Get
            Return _StartTime2
        End Get
        Set(ByVal value As String)
            _StartTime2 = value
        End Set
    End Property

    Public Property StartTime3() As String
        Get
            Return _StartTime3
        End Get
        Set(ByVal value As String)
            _StartTime3 = value
        End Set
    End Property
    Public Property TotalBreakdown1() As String
        Get
            Return _TotalBreakdown1
        End Get
        Set(ByVal value As String)
            _TotalBreakdown1 = value
        End Set
    End Property
    Public Property TotalBreakdown2() As String
        Get
            Return _TotalBreakdown2
        End Get
        Set(ByVal value As String)
            _TotalBreakdown2 = value
        End Set
    End Property
    Public Property TotalBreakdown3() As String
        Get
            Return _TotalBreakdown3
        End Get
        Set(ByVal value As String)
            _TotalBreakdown3 = value
        End Set
    End Property


    Public Property LorryProcessedEST1() As Decimal
        Get
            Return _LorryProcessedEST1
        End Get
        Set(ByVal value As Decimal)
            _LorryProcessedEST1 = value
        End Set
    End Property
    Public Property LorryProcessedEST2() As Decimal
        Get
            Return _LorryProcessedEST2
        End Get
        Set(ByVal value As Decimal)
            _LorryProcessedEST2 = value
        End Set
    End Property
    Public Property LorryProcessedEST3() As Decimal
        Get
            Return _LorryProcessedEST3
        End Get
        Set(ByVal value As Decimal)
            _LorryProcessedEST3 = value
        End Set
    End Property
    Public Property LorryProcessedACT() As Decimal
        Get
            Return _LorryProcessedACT
        End Get
        Set(ByVal value As Decimal)
            _LorryProcessedACT = value
        End Set
    End Property
    Public Property BalanceFFBCFQty() As Decimal
        Get
            Return _BalanceFFBCFQty
        End Get
        Set(ByVal value As Decimal)
            _BalanceFFBCFQty = value
        End Set
    End Property
    Public Property BalanceFFBCFNoLorry() As Decimal
        Get
            Return _BalanceFFBCFNoLorry
        End Get
        Set(ByVal value As Decimal)
            _BalanceFFBCFNoLorry = value
        End Set
    End Property
    Public Property KernelProduction() As Decimal
        Get
            Return _KernelProduction
        End Get
        Set(ByVal value As Decimal)
            _KernelProduction = value
        End Set
    End Property
    Public Property LossOfKernel() As Decimal
        Get
            Return _LossOfKernel
        End Get
        Set(ByVal value As Decimal)
            _LossOfKernel = value
        End Set
    End Property

    Public Property AvgLorryWeight() As Decimal
        Get
            Return _AvgLorryWeight
        End Get
        Set(ByVal value As Decimal)
            _AvgLorryWeight = value
        End Set
    End Property

    Public Property MechanicalBD() As String
        Get
            Return _MechanicalBD
        End Get
        Set(ByVal value As String)
            _MechanicalBD = value
        End Set
    End Property

    Public Property ElectricalBD() As String
        Get
            Return _ElectricalBD
        End Get
        Set(ByVal value As String)
            _ElectricalBD = value
        End Set
    End Property
    Public Property ProcessingBD() As String
        Get
            Return _ProcessingBD
        End Get
        Set(ByVal value As String)
            _ProcessingBD = value
        End Set
    End Property
    Public Property TotalBD() As String
        Get
            Return _TotalBD
        End Get
        Set(ByVal value As String)
            _TotalBD = value
        End Set
    End Property

    Public Property EffectiveProcessingHours() As String
        Get
            Return _EffectiveProcessingHours
        End Get
        Set(ByVal value As String)
            _EffectiveProcessingHours = value
        End Set
    End Property
    Public Property Throughput() As Decimal
        Get
            Return _Throughput
        End Get
        Set(ByVal value As Decimal)
            _Throughput = value
        End Set
    End Property
    Public Property OER() As Decimal
        Get
            Return _OER
        End Get
        Set(ByVal value As Decimal)
            _OER = value
        End Set
    End Property
    Public Property KER() As Decimal
        Get
            Return _KER
        End Get
        Set(ByVal value As Decimal)
            _KER = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Public Property FFBProcessedEST1() As Decimal
        Get
            Return _FFBProcessedEST1
        End Get
        Set(ByVal value As Decimal)
            _FFBProcessedEST1 = value
        End Set
    End Property
    Public Property FFBProcessedEST2() As Decimal
        Get
            Return _FFBProcessedEST2
        End Get
        Set(ByVal value As Decimal)
            _FFBProcessedEST2 = value
        End Set
    End Property
    Public Property FFBProcessedEST3() As Decimal
        Get
            Return _FFBProcessedEST3
        End Get
        Set(ByVal value As Decimal)
            _FFBProcessedEST3 = value
        End Set
    End Property
    Public Property Shift1() As String
        Get
            Return _Shift1
        End Get
        Set(ByVal value As String)
            _Shift1 = value
        End Set
    End Property
    Public Property Shift2() As String
        Get
            Return _Shift2
        End Get
        Set(ByVal value As String)
            _Shift2 = value
        End Set
    End Property
    Public Property Shift3() As String
        Get
            Return _Shift3
        End Get
        Set(ByVal value As String)
            _Shift3 = value
        End Set
    End Property

    Public Property CropYieldID() As String
        Get
            Return _CropYieldID
        End Get
        Set(ByVal value As String)
            _CropYieldID = value
        End Set
    End Property
    Public Property StopTime1() As String
        Get
            Return _StopTime1
        End Get
        Set(ByVal value As String)
            _StopTime1 = value
        End Set
    End Property
    Public Property StopTime2() As String
        Get
            Return _StopTime2
        End Get
        Set(ByVal value As String)
            _StopTime2 = value
        End Set
    End Property
    Public Property StopTime3() As String
        Get
            Return _StopTime3
        End Get
        Set(ByVal value As String)
            _StopTime3 = value
        End Set
    End Property

    Public Property ProductionLogDate() As DateTime
        Get
            Return _ProductionLogDate
        End Get
        Set(ByVal value As DateTime)
            _ProductionLogDate = value
        End Set
    End Property

    ''' CPO Production Log press Field



    Public Property ProductionLogPressID() As String
        Get
            Return _ProductionLogPressID
        End Get
        Set(ByVal value As String)
            _ProductionLogPressID = value
        End Set
    End Property


    Public Property ScrewAge() As Decimal
        Get
            Return _ScrewAge
        End Get
        Set(ByVal value As Decimal)
            _ScrewAge = value
        End Set
    End Property

    Public Property MachineID() As String
        Get
            Return _MachineID
        End Get
        Set(ByVal value As String)
            _MachineID = value
        End Set
    End Property
    Public Property PressNo() As String
        Get
            Return _PressNo
        End Get
        Set(ByVal value As String)
            _PressNo = value
        End Set
    End Property


    Public Property StagePress() As String
        Get
            Return _StagePress
        End Get
        Set(ByVal value As String)
            _StagePress = value
        End Set
    End Property

    Public Property MeterFrom() As String
        Get
            Return _MeterFrom
        End Get
        Set(ByVal value As String)
            _MeterFrom = value
        End Set
    End Property
    Public Property MeterTo() As String
        Get
            Return _MeterTo
        End Get
        Set(ByVal value As String)
            _MeterTo = value
        End Set
    End Property


    Public Property ScrewStatus() As String
        Get
            Return _ScrewStatus
        End Get
        Set(ByVal value As String)
            _ScrewStatus = value
        End Set
    End Property
    Public Property OPHrs() As String
        Get
            Return _OPHrs
        End Get
        Set(ByVal value As String)
            _OPHrs = value
        End Set
    End Property

    Public Property PCage() As String
        Get
            Return _PCage
        End Get
        Set(ByVal value As String)
            _PCage = value
        End Set
    End Property



    Public Property PressSummaryID() As String
        Get
            Return _PressSummaryID
        End Get
        Set(ByVal value As String)
            _PressSummaryID = value
        End Set
    End Property


    Public Property TotalPressHrsToday() As String
        Get
            Return _TotalPressHrsToday
        End Get
        Set(ByVal value As String)
            _TotalPressHrsToday = value
        End Set
    End Property

    Public Property TotalPressHrsMTD() As String
        Get
            Return _TotalPressHrsMTD
        End Get
        Set(ByVal value As String)
            _TotalPressHrsMTD = value
        End Set
    End Property
    Public Property TotalPressHrsYTD() As String
        Get
            Return _TotalPressHrsYTD
        End Get
        Set(ByVal value As String)
            _TotalPressHrsYTD = value
        End Set
    End Property


    Public Property AvgPressThrToday() As String
        Get
            Return _AvgPressThrToday
        End Get
        Set(ByVal value As String)
            _AvgPressThrToday = value
        End Set
    End Property

    Public Property AvgPressThrMTD() As String
        Get
            Return _AvgPressThrMTD
        End Get
        Set(ByVal value As String)
            _AvgPressThrMTD = value
        End Set
    End Property
    Public Property AvgPressThrYTD() As String
        Get
            Return _AvgPressThrYTD
        End Get
        Set(ByVal value As String)
            _AvgPressThrYTD = value
        End Set
    End Property


    Public Property UtilizationToday() As String
        Get
            Return _UtilizationToday
        End Get
        Set(ByVal value As String)
            _UtilizationToday = value
        End Set
    End Property
    Public Property UtilizationMTD() As String
        Get
            Return _UtilizationMTD
        End Get
        Set(ByVal value As String)
            _UtilizationMTD = value
        End Set
    End Property

    Public Property UtilizationYTD() As String
        Get
            Return _UtilizationYTD
        End Get
        Set(ByVal value As String)
            _UtilizationYTD = value
        End Set
    End Property


    Public Property FFBProcessedMTD() As Decimal
        Get
            Return _FFBProcessedMTD
        End Get
        Set(ByVal value As Decimal)
            _FFBProcessedMTD = value
        End Set
    End Property

    Public Property LorryProcessedMTD() As Integer
        Get
            Return _LorryProcessedMTD
        End Get
        Set(ByVal value As Integer)
            _LorryProcessedMTD = value
        End Set
    End Property

    Public Property LossOfKernelMTD() As Decimal
        Get
            Return _LossOfKernelMTD
        End Get
        Set(ByVal value As Decimal)
            _LossOfKernelMTD = value
        End Set
    End Property

    Public Property MechanicalBDMTD() As String
        Get
            Return _MechanicalBDMTD
        End Get
        Set(ByVal value As String)
            _MechanicalBDMTD = value
        End Set
    End Property

    Public Property ElectricalBDMTD() As String
        Get
            Return _ElectricalBDMTD
        End Get
        Set(ByVal value As String)
            _ElectricalBDMTD = value
        End Set
    End Property

    Public Property ProcessingBDMTD() As String
        Get
            Return _ProcessingBDMTD
        End Get
        Set(ByVal value As String)
            _ProcessingBDMTD = value
        End Set
    End Property


    Public Property FFBProcessedYTD() As Decimal
        Get
            Return _FFBProcessedYTD
        End Get
        Set(ByVal value As Decimal)
            _FFBProcessedYTD = value
        End Set
    End Property

    Public Property LorryProcessedYTD() As Integer
        Get
            Return _LorryProcessedYTD
        End Get
        Set(ByVal value As Integer)
            _LorryProcessedYTD = value
        End Set
    End Property

    Public Property LossOfKernelYTD() As Decimal
        Get
            Return _LossOfKernelYTD
        End Get
        Set(ByVal value As Decimal)
            _LossOfKernelYTD = value
        End Set
    End Property

    Public Property MechanicalBDYTD() As String
        Get
            Return _MechanicalBDYTD
        End Get
        Set(ByVal value As String)
            _MechanicalBDYTD = value
        End Set
    End Property

    Public Property ElectricalBDYTD() As String
        Get
            Return _ElectricalBDYTD
        End Get
        Set(ByVal value As String)
            _ElectricalBDYTD = value
        End Set
    End Property

    Public Property ProcessingBDYTD() As String
        Get
            Return _ProcessingBDYTD
        End Get
        Set(ByVal value As String)
            _ProcessingBDYTD = value
        End Set
    End Property

#End Region
End Class
