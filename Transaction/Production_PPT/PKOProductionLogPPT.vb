
Public Class PKOProductionLogPPT

#Region "Private Member Declarations"
    ''' PKO Production Log Field

    Private _PKOProductionLogID As String = String.Empty
    Private _CropYieldID As String = String.Empty
    Private _ProductionLogDate As Date
    Private _lProductionLogDate As String
    Private _TotalHours As String = String.Empty
    Private _MonthToDateHrs As String = String.Empty
    Private _YeartoDateHrs As String = String.Empty
    Private _BalanceKERBFQty As Decimal
    Private _KernelProcessedACT As Decimal
    Private _KernelProcessedACTMTD As Decimal
    Private _KernelProcessedACTYT As Decimal
    Private _LossOfKernel As Decimal
    Private _MechanicalBD As String = String.Empty
    Private _ElectricalBD As String = String.Empty
    Private _ProcessingBD As String = String.Empty
    Private _TotalBD As String = String.Empty
    Private _EffectiveProcessingHours As String = String.Empty
    Private _Throughput As Decimal
    Private _OER As Decimal
    Private _Remarks As String = String.Empty

    '' PKO Production Shift
    Private _AssistantEmpID1 As String = String.Empty
    Private _MandoreEmpID1 As String = String.Empty
    Private _Shift1 As Integer
    Private _StartTime1 As String
    Private _StopTime1 As String
    Private _KernelProcessedEST1 As Decimal
    Private _AssistantEmpID2 As String = String.Empty
    Private _MandoreEmpID2 As String = String.Empty
    Private _Shift2 As Integer
    Private _StartTime2 As String
    Private _StopTime2 As String
    Private _KernelProcessedEST2 As Decimal
    Private _AssistantEmpID3 As String = String.Empty
    Private _MandoreEmpID3 As String = String.Empty
    Private _Shift3 As Integer
    Private _StartTime3 As String
    Private _StopTime3 As String
    Private _KernelProcessedEST3 As Decimal

    ''' PKO Production Kernel Field

    Private _PKOKERReceivedID As String = String.Empty
    Private _LoadingLocationID As String = String.Empty
    Private _KernelReceivedQty As String = String.Empty
    Private _KernelReceivedQtyTodate As String = String.Empty
    Private _KernelReceivedQtyYearTodate As String = String.Empty

    ''' PKO Production Log press Field

    Private _ProductionLogPressID As String = String.Empty
    Private _StagePress As String = String.Empty
    Private _ScrewAge As Decimal
    Private _MachineID As String = String.Empty
    Private _PressNo As String = String.Empty
    Private _MeterFrom As String = String.Empty
    Private _MeterTo As String = String.Empty
    Private _OPHrs As String = String.Empty
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
    Private _LossOfKernelMTD As Double
    Private _MechanicalBDMTD As String
    Private _ElectricalBDMTD As String
    Private _ProcessingBDMTD As String

    Private _LossOfKernelYTD As Double
    Private _MechanicalBDYTD As String
    Private _ElectricalBDYTD As String
    Private _ProcessingBDYTD As String


#End Region


#Region "Public Member Declarations"
    ''' PKO Production Log Field

    Public Property PKOProductionLogID() As String
        Get
            Return _PKOProductionLogID
        End Get
        Set(ByVal value As String)
            _PKOProductionLogID = value
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
    
    Public Property ProductionLogDate() As Date
        Get
            Return _ProductionLogDate
        End Get
        Set(ByVal value As Date)
            _ProductionLogDate = value
        End Set
    End Property
    Public Property lProductionLogDate() As String
        Get
            Return _ProductionLogDate
        End Get
        Set(ByVal value As String)
            _ProductionLogDate = value
        End Set
    End Property
   
    Public Property TotalHours() As String
        Get
            Return _TotalHours
        End Get
        Set(ByVal value As String)
            _TotalHours = value
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


    Public Property BalanceKERBFQty() As Decimal
        Get
            Return _BalanceKERBFQty
        End Get
        Set(ByVal value As Decimal)
            _BalanceKERBFQty = value
        End Set
    End Property


    Public Property KernelProcessedACT() As Decimal
        Get
            Return _KernelProcessedACT
        End Get
        Set(ByVal value As Decimal)
            _KernelProcessedACT = value
        End Set
    End Property


    Public Property KernelProcessedACTMTD() As Decimal
        Get
            Return _KernelProcessedACTMTD
        End Get
        Set(ByVal value As Decimal)
            _KernelProcessedACTMTD = value
        End Set
    End Property

    Public Property KernelProcessedACTYT() As Decimal
        Get
            Return _KernelProcessedACTYT
        End Get
        Set(ByVal value As Decimal)
            _KernelProcessedACTYT = value
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
    '' PKO ProductionLog Shift

    Public Property AssistantEmpID1() As String
        Get
            Return _AssistantEmpID1
        End Get
        Set(ByVal value As String)
            _AssistantEmpID1 = value
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

    Public Property Shift1() As String
        Get
            Return _Shift1
        End Get
        Set(ByVal value As String)
            _Shift1 = value
        End Set
    End Property


    Public Property Starttime1() As String
        Get
            Return _StartTime1
        End Get
        Set(ByVal value As String)
            _StartTime1 = value
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


    Public Property KernelProcessedEST1() As Decimal
        Get
            Return _KernelProcessedEST1
        End Get
        Set(ByVal value As Decimal)
            _KernelProcessedEST1 = value
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

    Public Property MandoreEmpID2() As String
        Get
            Return _MandoreEmpID2
        End Get
        Set(ByVal value As String)
            _MandoreEmpID2 = value
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


    Public Property Starttime2() As String
        Get
            Return _StartTime2
        End Get
        Set(ByVal value As String)
            _StartTime2 = value
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


    Public Property KernelProcessedEST2() As Decimal
        Get
            Return _KernelProcessedEST2
        End Get
        Set(ByVal value As Decimal)
            _KernelProcessedEST2 = value
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

    Public Property MandoreEmpID3() As String
        Get
            Return _MandoreEmpID3
        End Get
        Set(ByVal value As String)
            _MandoreEmpID3 = value
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


    Public Property Starttime3() As String
        Get
            Return _StartTime3
        End Get
        Set(ByVal value As String)
            _StartTime3 = value
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


    Public Property KernelProcessedEST3() As Decimal
        Get
            Return _KernelProcessedEST3
        End Get
        Set(ByVal value As Decimal)
            _KernelProcessedEST3 = value
        End Set
    End Property
    ''' PKO Production Kernel Received Field

    Public Property PKOKERReceivedID() As String
        Get
            Return _PKOKERReceivedID
        End Get
        Set(ByVal value As String)
            _PKOKERReceivedID = value
        End Set
    End Property

    Public Property LoadingLocationID() As String
        Get
            Return _LoadingLocationID
        End Get
        Set(ByVal value As String)
            _LoadingLocationID = value
        End Set
    End Property

    Public Property KernelReceivedQty() As String
        Get
            Return _KernelReceivedQty
        End Get
        Set(ByVal value As String)
            _KernelReceivedQty = value
        End Set
    End Property

    Public Property KernelReceivedQtyTodate() As String
        Get
            Return _KernelReceivedQtyTodate
        End Get
        Set(ByVal value As String)
            _KernelReceivedQtyTodate = value
        End Set
    End Property

    Public Property KernelReceivedQtyYearTodate() As String
        Get
            Return _KernelReceivedQtyYearTodate
        End Get
        Set(ByVal value As String)
            _KernelReceivedQtyYearTodate = value
        End Set
    End Property


    ''' PKO Production Log press Field

   

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
    '' newly added 

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
