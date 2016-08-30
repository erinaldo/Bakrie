Public Class LaboratoryAnalysisPPT
#Region "Private Member Declarations"
    'Laboratory Analysis
    Private _LabAnalysisID As String = String.Empty
    Private _LabAnalysisDate As Date
    Private _lLabAnalysisDate As String
    Private _CPOProductionFFAP As Decimal = 0.0
    Private _CPOProductionFFAPMTD As Decimal = 0.0
    Private _CPOProductionFFAPYTD As Decimal = 0.0
    Private _CPOProductionMoistureP As Decimal = 0.0
    Private _CPOProductionDirtP As Decimal = 0.0
    Private _KERProductionMoistureP As Decimal = 0.0
    Private _KERProductionDirtP As Decimal = 0.0
    Private _KERProductionBrokenKernel As Decimal = 0.0
    Private _PKOProductionFFAP As Decimal = 0.0
    Private _PKOProductionFFAPMTD As Decimal = 0.0
    Private _PKOProductionFFAPYTD As Decimal = 0.0
    Private _PKOProductionMoistureP As Decimal = 0.0
    Private _PKOProductionDirtP As Decimal = 0.0

    'Oil Losses
    Private _OLLabOilLossesID As String = String.Empty
    Private _OLLabAnalysisID As String = String.Empty
    Private _OLStationID As String = String.Empty
    Private _OLNo As Integer = 0
    Private _OLStockKernalID As String = String.Empty
    Private _OLLine As String = String.Empty
    Private _OLType As String = String.Empty
    Private _OLActualP As Decimal = 0.0
    Private _OLSTD As Decimal = 0.0
    Private _OLKernalID As String = String.Empty

    'Kernel Losses
    Private _KLLabKernelLossesID As String = String.Empty
    Private _KLLabAnalysisID As String = String.Empty
    Private _KLStationID As String = String.Empty
    Private _KLNo As Integer = 0
    Private _KLLine As String = String.Empty
    Private _KLEfficiencyP As Decimal = 0.0
    Private _KLLossesP As Decimal = 0.0
    Private _KLDirtP As Decimal = 0.0

    'Kernel Losses PCF
    Private _KLPCFLabKernelLossesPCFID As String = String.Empty
    Private _KLPCFLabAnalysisID As String = String.Empty
    Private _KLPCFStationID As String = String.Empty
    Private _KLPCFLine As String = String.Empty
    Private _KLPCFNo As Integer = 0
    Private _KLPCFTotalNutP As Decimal = 0.0
    Private _KLPCFSampleP As Decimal = 0.0
    Private _KLPCFFibreP As Decimal = 0.0

    'Oil Losses FFB
    Private _OLFFBLabOilLossesFFBID As String = String.Empty
    Private _OLFFBLabAnalysisID As String = String.Empty
    Private _OLFFBEquipment As String = String.Empty
    Private _OLFFBNo As Integer = 0
    Private _OLFFBType As String = String.Empty
    Private _OLFFBActualP As Decimal = 0.0

    'Oil Losses BFFB
    Private _OLBFFBLabOilLossesBFFBID As String = String.Empty
    Private _OLBFFBLabAnalysisID As String = String.Empty
    Private _OLBFFBDescp As String = String.Empty
    Private _OLBFFBExpellerStageType As String = String.Empty
    Private _OLBFFBExpellerStageNumber As Integer = 0
    Private _OLBFFBAmount As Decimal = 0.0

    'Kernel Losses FFB
    Private _KLFFBLabKernelLossesFFBID As String = String.Empty
    Private _KLFFBLabAnalysisID As String = String.Empty
    Private _KLFFBLine As String = String.Empty
    Private _KLFFBLTDS1P As Decimal = 0.0
    Private _KLFFBLTDS2P As Decimal = 0.0
    Private _KLFFBLTDS3P As Decimal = 0.0
    Private _KLFFBLTDS4P As Decimal = 0.0
    Private _KLFFBFibreCycP As Decimal = 0.0
    Private _KLFFBHydroCycP As Decimal = 0.0
    Private _KLFFBFruitinEB As Decimal = 0.0

    'Kernel Intake
    Private _KILabKernelIntakeID As String = String.Empty
    Private _KILabAnalysisID As String = String.Empty
    Private _KISourceLocation As String = String.Empty
    Private _KIReceivedTon As Decimal = 0.0
    Private _KIMoistureP As Decimal = 0.0
    Private _KIDirtP As Decimal = 0.0
    Private _KIBrokenKernel As Decimal = 0.0

    'Efficiency Ripple Mill
    Private _ERPLabEffRippleMillID As String = String.Empty
    Private _ERPLabAnalysisID As String = String.Empty
    Private _ERPLine As String = String.Empty
    Private _ERPNo As Integer
    Private _ERPEfficiencyP As Decimal = 0.0
    Private _ERPEquipment As String = String.Empty

    'Kernel Quality Storage
    Private _KQSLabKERQualityID As String = String.Empty
    Private _KQSLabAnalysisID As String = String.Empty
    Private _KQSLine As String = String.Empty
    Private _KQSLocation As String = String.Empty
    Private _KQSMoistureP As Decimal = 0.0
    Private _KQSDirtP As Decimal = 0.0
    Private _KQSBrokenKernel As Decimal = 0.0

    'Oil Quality Storage
    Private _OQSLabOilQualityID As String = String.Empty
    Private _OQSLabAnalysisID As String = String.Empty
    Private _OQSProductType As String = String.Empty
    Private _OQSTankID As String = String.Empty
    Private _OQSFFAP As Decimal = 0.0
    Private _OQSMoistureP As Decimal = 0.0
    Private _OQSDirtP As Decimal = 0.0

    'Machinery Operation Hours
    Private _MOHMachinerOperationID As String = String.Empty
    Private _MOHLabAnalysisID As String = String.Empty
    Private _MOHMachineID As String = String.Empty
    Private _MOHMeterFrom As String = String.Empty
    Private _MOHMeterTo As String = String.Empty
    Private _MOHProcessHours As String = String.Empty
    Private _MOHNonProcessHours As String = String.Empty
    Private _MOHTotalHours As String = String.Empty
    Private _MOHMonthToDateHrs As String = String.Empty
    Private _MOHYeartoDateHrs As String = String.Empty

    'Boiler Water Analysis
    Private _BWALabBoilerWaterID As String = String.Empty
    Private _BWALabAnalysisID As String = String.Empty
    Private _BWADescp As String = String.Empty
    Private _BWAType As String = String.Empty
    Private _BWAValue As Decimal = 0.0

    'Softner
    Private _SLabSoftnerID As String = String.Empty
    Private _SLabAnalysisID As String = String.Empty
    Private _SDescp As String = String.Empty
    Private _SType As String = String.Empty
    Private _SDosage As Decimal = 0.0
    Private _SAnion As String = String.Empty





#End Region
#Region "Public Member Declarations"
    ''Laboratory Analysis

    Public Property LabAnalysisID() As String
        Get
            Return _LabAnalysisID
        End Get
        Set(ByVal value As String)
            _LabAnalysisID = value
        End Set
    End Property
    Public Property LabAnalysisDate() As Date
        Get
            Return _LabAnalysisDate
        End Get
        Set(ByVal value As Date)
            _LabAnalysisDate = value
        End Set
    End Property
    Public Property lLabAnalysisDate() As String
        Get
            Return _lLabAnalysisDate
        End Get
        Set(ByVal value As String)
            _lLabAnalysisDate = value
        End Set
    End Property

 
    Public Property CPOProductionFFAP() As Decimal
        Get
            Return _CPOProductionFFAP
        End Get
        Set(ByVal value As Decimal)
            _CPOProductionFFAP = value
        End Set
    End Property
    Public Property CPOProductionFFAPMTD() As Decimal
        Get
            Return _CPOProductionFFAPMTD
        End Get
        Set(ByVal value As Decimal)
            _CPOProductionFFAPMTD = value
        End Set
    End Property
    Public Property CPOProductionFFAPYTD() As Decimal
        Get
            Return _CPOProductionFFAPYTD
        End Get
        Set(ByVal value As Decimal)
            _CPOProductionFFAPYTD = value
        End Set
    End Property
    Public Property CPOProductionDirtP() As Decimal
        Get
            Return _CPOProductionDirtP
        End Get
        Set(ByVal value As Decimal)
            _CPOProductionDirtP = value
        End Set
    End Property
    Public Property CPOProductionMoistureP() As Decimal
        Get
            Return _CPOProductionMoistureP
        End Get
        Set(ByVal value As Decimal)
            _CPOProductionMoistureP = value
        End Set
    End Property
    Public Property KERProductionMoistureP() As Decimal
        Get
            Return _KERProductionMoistureP
        End Get
        Set(ByVal value As Decimal)
            _KERProductionMoistureP = value
        End Set
    End Property
    Public Property KERProductionDirtP() As Decimal
        Get
            Return _KERProductionDirtP
        End Get
        Set(ByVal value As Decimal)
            _KERProductionDirtP = value
        End Set
    End Property
    Public Property KERProductionBrokenKernel() As Decimal
        Get
            Return _KERProductionBrokenKernel
        End Get
        Set(ByVal value As Decimal)
            _KERProductionBrokenKernel = value
        End Set
    End Property
    Public Property PKOProductionFFAP() As Decimal
        Get
            Return _PKOProductionFFAP
        End Get
        Set(ByVal value As Decimal)
            _PKOProductionFFAP = value
        End Set
    End Property
    Public Property PKOProductionFFAPMTD() As Decimal
        Get
            Return _PKOProductionFFAPMTD
        End Get
        Set(ByVal value As Decimal)
            _PKOProductionFFAPMTD = value
        End Set
    End Property
    Public Property PKOProductionFFAPYTD() As Decimal
        Get
            Return _PKOProductionFFAPYTD
        End Get
        Set(ByVal value As Decimal)
            _PKOProductionFFAPYTD = value
        End Set
    End Property
    Public Property PKOProductionMoistureP() As Decimal
        Get
            Return _PKOProductionMoistureP
        End Get
        Set(ByVal value As Decimal)
            _PKOProductionMoistureP = value
        End Set
    End Property
    Public Property PKOProductionDirtP() As Decimal
        Get
            Return _PKOProductionDirtP
        End Get
        Set(ByVal value As Decimal)
            _PKOProductionDirtP = value
        End Set
    End Property

  
    'Oil Losses
    Public Property OLLabOilLossesID() As String
        Get
            Return _OLLabOilLossesID
        End Get
        Set(ByVal value As String)
            _OLLabOilLossesID = value
        End Set
    End Property
    Public Property OLLabAnalysisID() As String
        Get
            Return _OLLabAnalysisID
        End Get
        Set(ByVal value As String)
            _OLLabAnalysisID = value
        End Set
    End Property

    Public Property OLStationID() As String
        Get
            Return _OLStationID
        End Get
        Set(ByVal value As String)
            _OLStationID = value
        End Set
    End Property

    Public Property OLNo() As Integer
        Get
            Return _OLNo
        End Get
        Set(ByVal value As Integer)
            _OLNo = value
        End Set
    End Property
    Public Property OLStockKernalID() As String
        Get
            Return _OLStockKernalID
        End Get
        Set(ByVal value As String)
            _OLStockKernalID = value
        End Set
    End Property
    Public Property OLLine() As String
        Get
            Return _OLLine
        End Get
        Set(ByVal value As String)
            _OLLine = value
        End Set
    End Property
    Public Property OLType() As String
        Get
            Return _OLType
        End Get
        Set(ByVal value As String)
            _OLType = value
        End Set
    End Property
    Public Property OLActualP() As Decimal
        Get
            Return _OLActualP
        End Get
        Set(ByVal value As Decimal)
            _OLActualP = value
        End Set
    End Property
    Public Property OLSTD() As Decimal
        Get
            Return _OLSTD
        End Get
        Set(ByVal value As Decimal)
            _OLSTD = value
        End Set
    End Property
    Public Property OLKernalID() As String
        Get
            Return _OLKernalID
        End Get
        Set(ByVal value As String)
            _OLKernalID = value
        End Set
    End Property
    'Kernel Losses
    Public Property KLLabKernelLossesID() As String
        Get
            Return _KLLabKernelLossesID
        End Get
        Set(ByVal value As String)
            _KLLabKernelLossesID = value
        End Set
    End Property
    Public Property KLLabAnalysisID() As String
        Get
            Return _KLLabAnalysisID
        End Get
        Set(ByVal value As String)
            _KLLabAnalysisID = value
        End Set
    End Property

    Public Property KLStationID() As String
        Get
            Return _KLStationID
        End Get
        Set(ByVal value As String)
            _KLStationID = value
        End Set
    End Property

    Public Property KLNo() As Integer
        Get
            Return _KLNo
        End Get
        Set(ByVal value As Integer)
            _KLNo = value
        End Set
    End Property

    Public Property KLLine() As String
        Get
            Return _KLLine
        End Get
        Set(ByVal value As String)
            _KLLine = value
        End Set
    End Property

    Public Property KLEfficiencyP() As Decimal
        Get
            Return _KLEfficiencyP
        End Get
        Set(ByVal value As Decimal)
            _KLEfficiencyP = value
        End Set
    End Property
    Public Property KLLossesP() As Decimal
        Get
            Return _KLLossesP
        End Get
        Set(ByVal value As Decimal)
            _KLLossesP = value
        End Set
    End Property
    Public Property KLDirtP() As Decimal
        Get
            Return _KLDirtP
        End Get
        Set(ByVal value As Decimal)
            _KLDirtP = value
        End Set
    End Property
    'KL PCF

    Public Property KLPCFLabKernelLossesPCFID() As String
        Get
            Return _KLPCFLabKernelLossesPCFID
        End Get
        Set(ByVal value As String)
            _KLPCFLabKernelLossesPCFID = value
        End Set
    End Property
    Public Property KLPCFLabAnalysisID() As String
        Get
            Return _KLPCFLabAnalysisID
        End Get
        Set(ByVal value As String)
            _KLPCFLabAnalysisID = value
        End Set
    End Property

    Public Property KLPCFStationID() As String
        Get
            Return _KLPCFStationID
        End Get
        Set(ByVal value As String)
            _KLPCFStationID = value
        End Set
    End Property

    Public Property KLPCFLine() As String
        Get
            Return _KLPCFLine
        End Get
        Set(ByVal value As String)
            _KLPCFLine = value
        End Set
    End Property

    Public Property KLPCFNo() As Integer
        Get
            Return _KLPCFNo
        End Get
        Set(ByVal value As Integer)
            _KLPCFNo = value
        End Set
    End Property


    Public Property KLPCFSampleP() As Decimal
        Get
            Return _KLPCFSampleP
        End Get
        Set(ByVal value As Decimal)
            _KLPCFSampleP = value
        End Set
    End Property
    Public Property KLPCFFibreP() As Decimal
        Get
            Return _KLPCFFibreP
        End Get
        Set(ByVal value As Decimal)
            _KLPCFFibreP = value
        End Set
    End Property
    Public Property KLPCFTotalNutP() As Decimal
        Get
            Return _KLPCFTotalNutP
        End Get
        Set(ByVal value As Decimal)
            _KLPCFTotalNutP = value
        End Set
    End Property

    'Oil Losses FFB

    Public Property OLFFBLabOilLossesFFBID() As String
        Get
            Return _OLFFBLabOilLossesFFBID
        End Get
        Set(ByVal value As String)
            _OLFFBLabOilLossesFFBID = value
        End Set
    End Property
    Public Property OLFFBLabAnalysisID() As String
        Get
            Return _OLFFBLabAnalysisID
        End Get
        Set(ByVal value As String)
            _OLFFBLabAnalysisID = value
        End Set
    End Property

    Public Property OLFFBEquipment() As String
        Get
            Return _OLFFBEquipment
        End Get
        Set(ByVal value As String)
            _OLFFBEquipment = value
        End Set
    End Property

    Public Property OLFFBNo() As Integer
        Get
            Return _OLFFBNo
        End Get
        Set(ByVal value As Integer)
            _OLFFBNo = value
        End Set
    End Property


    Public Property OLFFBType() As String
        Get
            Return _OLFFBType
        End Get
        Set(ByVal value As String)
            _OLFFBType = value
        End Set
    End Property

    Public Property OLFFBActualP() As Decimal
        Get
            Return _OLFFBActualP
        End Get
        Set(ByVal value As Decimal)
            _OLFFBActualP = value
        End Set
    End Property

    'Oil Losses BFFB
    Public Property OLBFFBLabOilLossesBFFBID() As String
        Get
            Return _OLBFFBLabOilLossesBFFBID
        End Get
        Set(ByVal value As String)
            _OLBFFBLabOilLossesBFFBID = value
        End Set
    End Property
    Public Property OLBFFBLabAnalysisID() As String
        Get
            Return _OLBFFBLabAnalysisID
        End Get
        Set(ByVal value As String)
            _OLBFFBLabAnalysisID = value
        End Set
    End Property

    Public Property OLBFFBDescp() As String
        Get
            Return _OLBFFBDescp
        End Get
        Set(ByVal value As String)
            _OLBFFBDescp = value
        End Set
    End Property

    Public Property OLBFFBExpellerStageNumber() As Integer
        Get
            Return _OLBFFBExpellerStageNumber
        End Get
        Set(ByVal value As Integer)
            _OLBFFBExpellerStageNumber = value
        End Set
    End Property


    Public Property OLBFFBExpellerStageType() As String
        Get
            Return _OLBFFBExpellerStageType
        End Get
        Set(ByVal value As String)
            _OLBFFBExpellerStageType = value
        End Set
    End Property

    Public Property OLBFFBAmount() As Decimal
        Get
            Return _OLBFFBAmount
        End Get
        Set(ByVal value As Decimal)
            _OLBFFBAmount = value
        End Set
    End Property
    'Kernel Losses FFB

    Public Property KLFFBLabKernelLossesFFBID() As String
        Get
            Return _KLFFBLabKernelLossesFFBID
        End Get
        Set(ByVal value As String)
            _KLFFBLabKernelLossesFFBID = value
        End Set
    End Property
    Public Property KLFFBLabAnalysisID() As String
        Get
            Return _KLFFBLabAnalysisID
        End Get
        Set(ByVal value As String)
            _KLFFBLabAnalysisID = value
        End Set
    End Property

    Public Property KLFFBLine() As String
        Get
            Return _KLFFBLine
        End Get
        Set(ByVal value As String)
            _KLFFBLine = value
        End Set
    End Property


    Public Property KLFFBLTDS1P() As Decimal
        Get
            Return _KLFFBLTDS1P
        End Get
        Set(ByVal value As Decimal)
            _KLFFBLTDS1P = value
        End Set
    End Property
    Public Property KLFFBLTDS2P() As Decimal
        Get
            Return _KLFFBLTDS2P
        End Get
        Set(ByVal value As Decimal)
            _KLFFBLTDS2P = value
        End Set
    End Property
    Public Property KLFFBLTDS3P() As Decimal
        Get
            Return _KLFFBLTDS3P
        End Get
        Set(ByVal value As Decimal)
            _KLFFBLTDS3P = value
        End Set
    End Property
    Public Property KLFFBLTDS4P() As Decimal
        Get
            Return _KLFFBLTDS4P
        End Get
        Set(ByVal value As Decimal)
            _KLFFBLTDS4P = value
        End Set
    End Property
    Public Property KLFFBFibreCycP() As Decimal
        Get
            Return _KLFFBFibreCycP
        End Get
        Set(ByVal value As Decimal)
            _KLFFBFibreCycP = value
        End Set
    End Property
    Public Property KLFFBHydroCycP() As Decimal
        Get
            Return _KLFFBHydroCycP
        End Get
        Set(ByVal value As Decimal)
            _KLFFBHydroCycP = value
        End Set
    End Property
    Public Property KLFFBFruitinEB() As Decimal
        Get
            Return _KLFFBFruitinEB
        End Get
        Set(ByVal value As Decimal)
            _KLFFBFruitinEB = value
        End Set
    End Property

    'Kernel Intake
    Public Property KILabKernelIntakeID() As String
        Get
            Return _KILabKernelIntakeID
        End Get
        Set(ByVal value As String)
            _KILabKernelIntakeID = value
        End Set
    End Property
    Public Property KILabAnalysisID() As String
        Get
            Return _KILabAnalysisID
        End Get
        Set(ByVal value As String)
            _KILabAnalysisID = value
        End Set
    End Property

    Public Property KISourceLocation() As String
        Get
            Return _KISourceLocation
        End Get
        Set(ByVal value As String)
            _KISourceLocation = value
        End Set
    End Property


    Public Property KIReceivedTon() As Decimal
        Get
            Return _KIReceivedTon
        End Get
        Set(ByVal value As Decimal)
            _KIReceivedTon = value
        End Set
    End Property
    Public Property KIMoistureP() As Decimal
        Get
            Return _KIMoistureP
        End Get
        Set(ByVal value As Decimal)
            _KIMoistureP = value
        End Set
    End Property
    Public Property KIDirtP() As Decimal
        Get
            Return _KIDirtP
        End Get
        Set(ByVal value As Decimal)
            _KIDirtP = value
        End Set
    End Property
    Public Property KIBrokenKernel() As Decimal
        Get
            Return _KIBrokenKernel
        End Get
        Set(ByVal value As Decimal)
            _KIBrokenKernel = value
        End Set
    End Property

    'Efficiency Ripple Mill

    Public Property ERPLabEffRippleMillID() As String
        Get
            Return _ERPLabEffRippleMillID
        End Get
        Set(ByVal value As String)
            _ERPLabEffRippleMillID = value
        End Set
    End Property
    Public Property ERPLabAnalysisID() As String
        Get
            Return _ERPLabAnalysisID
        End Get
        Set(ByVal value As String)
            _ERPLabAnalysisID = value
        End Set
    End Property

    Public Property ERPLine() As String
        Get
            Return _ERPLine
        End Get
        Set(ByVal value As String)
            _ERPLine = value
        End Set
    End Property


    Public Property ERPNo() As Integer
        Get
            Return _ERPNo
        End Get
        Set(ByVal value As Integer)
            _ERPNo = value
        End Set
    End Property


    Public Property ERPEquipment() As String
        Get
            Return _ERPEquipment
        End Get
        Set(ByVal value As String)
            _ERPEquipment = value
        End Set
    End Property

    Public Property ERPEfficiencyP() As Decimal
        Get
            Return _ERPEfficiencyP
        End Get
        Set(ByVal value As Decimal)
            _ERPEfficiencyP = value
        End Set
    End Property

    'Kernel Quality Storage

    Public Property KQSLabKERQualityID() As String
        Get
            Return _KQSLabKERQualityID
        End Get
        Set(ByVal value As String)
            _KQSLabKERQualityID = value
        End Set
    End Property
    Public Property KQSLabAnalysisID() As String
        Get
            Return _KQSLabAnalysisID
        End Get
        Set(ByVal value As String)
            _KQSLabAnalysisID = value
        End Set
    End Property

    Public Property KQSLine() As String
        Get
            Return _KQSLine
        End Get
        Set(ByVal value As String)
            _KQSLine = value
        End Set
    End Property

    Public Property KQSLocation() As String
        Get
            Return _KQSLocation
        End Get
        Set(ByVal value As String)
            _KQSLocation = value
        End Set
    End Property


    Public Property KQSMoistureP() As Decimal
        Get
            Return _KQSMoistureP
        End Get
        Set(ByVal value As Decimal)
            _KQSMoistureP = value
        End Set
    End Property

    Public Property KQSDirtP() As Decimal
        Get
            Return _KQSDirtP
        End Get
        Set(ByVal value As Decimal)
            _KQSDirtP = value
        End Set
    End Property

    Public Property KQSBrokenKernel() As Decimal
        Get
            Return _KQSBrokenKernel
        End Get
        Set(ByVal value As Decimal)
            _KQSBrokenKernel = value
        End Set
    End Property

    'Oil Quality Storage

    Public Property OQSLabOilQualityID() As String
        Get
            Return _OQSLabOilQualityID
        End Get
        Set(ByVal value As String)
            _OQSLabOilQualityID = value
        End Set
    End Property
    Public Property OQSLabAnalysisID() As String
        Get
            Return _OQSLabAnalysisID
        End Get
        Set(ByVal value As String)
            _OQSLabAnalysisID = value
        End Set
    End Property

    Public Property OQSProductType() As String
        Get
            Return _OQSProductType
        End Get
        Set(ByVal value As String)
            _OQSProductType = value
        End Set
    End Property

    Public Property OQSTankID() As String
        Get
            Return _OQSTankID
        End Get
        Set(ByVal value As String)
            _OQSTankID = value
        End Set
    End Property


    Public Property OQSFFAP() As Decimal
        Get
            Return _OQSFFAP
        End Get
        Set(ByVal value As Decimal)
            _OQSFFAP = value
        End Set
    End Property

    Public Property OQSMoistureP() As Decimal
        Get
            Return _OQSMoistureP
        End Get
        Set(ByVal value As Decimal)
            _OQSMoistureP = value
        End Set
    End Property

    Public Property OQSDirtP() As Decimal
        Get
            Return _OQSDirtP
        End Get
        Set(ByVal value As Decimal)
            _OQSDirtP = value
        End Set
    End Property

    'Machinery Operation Hours

    Public Property MOHMachinerOperationID() As String
        Get
            Return _MOHMachinerOperationID
        End Get
        Set(ByVal value As String)
            _MOHMachinerOperationID = value
        End Set
    End Property
    Public Property MOHLabAnalysisID() As String
        Get
            Return _MOHLabAnalysisID
        End Get
        Set(ByVal value As String)
            _MOHLabAnalysisID = value
        End Set
    End Property

    Public Property MOHMachineID() As String
        Get
            Return _MOHMachineID
        End Get
        Set(ByVal value As String)
            _MOHMachineID = value
        End Set
    End Property


    Public Property MOHMeterFrom() As String
        Get
            Return _MOHMeterFrom
        End Get
        Set(ByVal value As String)
            _MOHMeterFrom = value
        End Set
    End Property

    Public Property MOHMeterTo() As String
        Get
            Return _MOHMeterTo
        End Get
        Set(ByVal value As String)
            _MOHMeterTo = value
        End Set
    End Property

    Public Property MOHProcessHours() As String
        Get
            Return _MOHProcessHours
        End Get
        Set(ByVal value As String)
            _MOHProcessHours = value
        End Set
    End Property
    Public Property MOHNonProcessHours() As String
        Get
            Return _MOHNonProcessHours
        End Get
        Set(ByVal value As String)
            _MOHNonProcessHours = value
        End Set
    End Property

    Public Property MOHTotalHours() As String
        Get
            Return _MOHTotalHours
        End Get
        Set(ByVal value As String)
            _MOHTotalHours = value
        End Set
    End Property

    Public Property MOHMonthToDateHrs() As String
        Get
            Return _MOHMonthToDateHrs
        End Get
        Set(ByVal value As String)
            _MOHMonthToDateHrs = value
        End Set
    End Property

    Public Property MOHYeartoDateHrs() As String
        Get
            Return _MOHYeartoDateHrs
        End Get
        Set(ByVal value As String)
            _MOHYeartoDateHrs = value
        End Set
    End Property

    'Boiler Water Analysis

    Public Property BWALabBoilerWaterID() As String
        Get
            Return _BWALabBoilerWaterID
        End Get
        Set(ByVal value As String)
            _BWALabBoilerWaterID = value
        End Set
    End Property
    Public Property BWALabAnalysisID() As String
        Get
            Return _BWALabAnalysisID
        End Get
        Set(ByVal value As String)
            _BWALabAnalysisID = value
        End Set
    End Property

    Public Property BWADescp() As String
        Get
            Return _BWADescp
        End Get
        Set(ByVal value As String)
            _BWADescp = value
        End Set
    End Property


    Public Property BWAType() As String
        Get
            Return _BWAType
        End Get
        Set(ByVal value As String)
            _BWAType = value
        End Set
    End Property

    Public Property BWAValue() As Decimal
        Get
            Return _BWAValue
        End Get
        Set(ByVal value As Decimal)
            _BWAValue = value
        End Set
    End Property

    'Softner

    Public Property SLabSoftnerID() As String
        Get
            Return _SLabSoftnerID
        End Get
        Set(ByVal value As String)
            _SLabSoftnerID = value
        End Set
    End Property
    Public Property SLabAnalysisID() As String
        Get
            Return _SLabAnalysisID
        End Get
        Set(ByVal value As String)
            _SLabAnalysisID = value
        End Set
    End Property

    Public Property SDescp() As String
        Get
            Return _SDescp
        End Get
        Set(ByVal value As String)
            _SDescp = value
        End Set
    End Property


    Public Property SType() As String
        Get
            Return _SType
        End Get
        Set(ByVal value As String)
            _SType = value
        End Set
    End Property

    Public Property SDosage() As Decimal
        Get
            Return _SDosage
        End Get
        Set(ByVal value As Decimal)
            _SDosage = value
        End Set
    End Property

    Public Property SAnion() As String
        Get
            Return _SAnion
        End Get
        Set(ByVal value As String)
            _SAnion = value
        End Set
    End Property
#End Region


End Class
