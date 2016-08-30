Public Class VehicleRunningLogPPT

    Private lsVHDescp As String
    Public Property psVHDescp() As String
        Get
            Return lsVHDescp
        End Get
        Set(ByVal value As String)
            lsVHDescp = value
        End Set
    End Property

    Private lsVHModel As String
    Public Property psVHModel() As String
        Get
            Return lsVHModel
        End Get
        Set(ByVal value As String)
            lsVHModel = value
        End Set
    End Property


    Private lsEmpName As String
    Public Property psEmpName() As String
        Get
            Return lsEmpName
        End Get
        Set(ByVal value As String)
            lsEmpName = value
        End Set
    End Property

    Private _NIK As String
    Public Property NIK() As String
        Get
            Return _NIK
        End Get
        Set(ByVal value As String)
            _NIK = value
        End Set
    End Property

    Private _DriverName As String
    Public Property DriverName() As String
        Get
            Return _DriverName
        End Get
        Set(ByVal value As String)
            _DriverName = value
        End Set
    End Property

    Private lsRegNo As String
    Public Property psRegNo() As String
        Get
            Return lsRegNo
        End Get
        Set(ByVal value As String)
            lsRegNo = value
        End Set
    End Property


    Private lsUOM As String
    Public Property psUOM() As String
        Get
            Return lsUOM
        End Get
        Set(ByVal value As String)
            lsUOM = value
        End Set
    End Property


    Dim liID As Integer

    Public Property piID() As Integer 'Related to db table column name: ID
        Get
            Return liID
        End Get
        Set(ByVal value As Integer)
            liID = value
        End Set
    End Property

    Dim ldLogDate As Date

    Public Property pdLogDate() As Date 'Related to db table column name: LogDate
        Get
            Return IIf(ldLogDate = Date.MinValue, CDate("1/1/1753"), ldLogDate)
        End Get
        Set(ByVal value As Date)
            ldLogDate = value
        End Set
    End Property

    Dim lsVHWSCode As String

    Public Property psVHWSCode() As String 'Related to db table column name: VHWSCode
        Get
            Return lsVHWSCode
        End Get
        Set(ByVal value As String)
            lsVHWSCode = value
        End Set
    End Property

    'Dim lsEstateID As String

    'Public Property psEstateID() As String  'Related to db table column name: EstateID
    '    Get
    '        Return lsEstateID
    '    End Get
    '    Set(ByVal value As String)
    '        lsEstateID = value
    '    End Set
    'End Property

    'Dim lsActiveMonthYearID As String

    'Public Property psActiveMonthYearID() As String 'Related to db table column name: ActiveMonthYearID
    '    Get
    '        Return lsActiveMonthYearID
    '    End Get
    '    Set(ByVal value As String)
    '        lsActiveMonthYearID = value
    '    End Set
    'End Property

    Dim liBatchValue As Decimal

    Public Property piBatchValue() As Decimal 'Related to db table column name: BatchValue
        Get
            Return liBatchValue
        End Get
        Set(ByVal value As Decimal)
            liBatchValue = value
        End Set
    End Property

    Dim lsContractNo As String

    Public Property psContractNo() As String 'Related to db table column name: ContractNo
        Get
            Return lsContractNo
        End Get
        Set(ByVal value As String)
            lsContractNo = value
        End Set
    End Property

    Dim lsSearchBy As String

    Public Property psSearchBy() As String
        Get
            Return lsSearchBy
        End Get
        Set(ByVal value As String)
            lsSearchBy = value
        End Set
    End Property

    Dim lsDistributionSetupID As String

    Public Property psDistributionSetupID() As String 'Related to db table column name: DistributionSetupID
        Get
            Return lsDistributionSetupID
        End Get
        Set(ByVal value As String)
            lsDistributionSetupID = value
        End Set
    End Property

    Dim lsDistributionDescp As String

    Public Property psDistributionDescp() As String 'Related to db table column name: DistributionDescp
        Get
            Return lsDistributionDescp
        End Get
        Set(ByVal value As String)
            lsDistributionDescp = value
        End Set
    End Property


    Dim liStartKms As Decimal

    Public Property piStartKms() As Decimal 'Related to db table column name: StartKms
        Get
            Return liStartKms
        End Get
        Set(ByVal value As Decimal)
            liStartKms = value
        End Set
    End Property

    Dim liEndKms As Decimal

    Public Property piEndKms() As Decimal 'Related to db table column name: EndKms
        Get
            Return liEndKms
        End Get
        Set(ByVal value As Decimal)
            liEndKms = value
        End Set
    End Property

    Dim liTotalKm As Decimal

    Public Property piTotalKm() As Decimal 'Related to db table column name: TotalKm
        Get
            Return liTotalKm
        End Get
        Set(ByVal value As Decimal)
            liTotalKm = value
        End Set
    End Property

    Dim ldStartTimeDT As TimeSpan

    Public Property pdStartTimeDT() As TimeSpan 'Related to db table column name: StartTime
        Get
            Return ldStartTimeDT
        End Get
        Set(ByVal value As TimeSpan)
            ldStartTimeDT = value
        End Set
    End Property

    Dim ldEndTimeDT As TimeSpan

    Public Property pdEndTimeDT() As TimeSpan 'Related to db table column name: EndTime
        Get
            Return ldEndTimeDT
        End Get
        Set(ByVal value As TimeSpan)
            ldEndTimeDT = value
        End Set
    End Property

    'For formating time to HH:mm tt
    Dim lsStartTime As String

    Public Property psStartTime() As String 'Related to db table column name: StartTime
        Get
            Return lsStartTime
        End Get
        Set(ByVal value As String)
            lsStartTime = value
        End Set
    End Property

    'For formating time to HH:mm tt
    Dim lsEndTime As String

    Public Property psEndTime() As String 'Related to db table column name: StartTime
        Get
            Return lsEndTime
        End Get
        Set(ByVal value As String)
            lsEndTime = value
        End Set
    End Property

    Dim ldTotalHoursDT As TimeSpan

    Public Property pdTotalHrsDT() As TimeSpan 'Related to db table column name: TotalHrs
        Get
            Return ldTotalHoursDT
        End Get
        Set(ByVal value As TimeSpan)
            ldTotalHoursDT = value
        End Set
    End Property

    'For formating time to HH:mm tt
    Dim lsTotalHrs As String

    Public Property psTotalHrs() As String 'Related to db table column name: TotalHrs
        Get
            Return lsTotalHrs
        End Get
        Set(ByVal value As String)
            lsTotalHrs = value
        End Set
    End Property

    Dim lcShift As Char
    Public Property pcShift() As Char 'Related to db table column name: Shift
        Get
            Return lcShift
        End Get
        Set(ByVal value As Char)
            lcShift = value
        End Set
    End Property

    Dim lsDivID As String
    Public Property psDivID() As String 'Related to db table column name: DivID
        Get
            Return lsDivID
        End Get
        Set(ByVal value As String)
            lsDivID = value
        End Set
    End Property

    Dim lsYopID As String
    Public Property psYOPID() As String 'Related to db table column name: YOPID
        Get
            Return lsYopID
        End Get
        Set(ByVal value As String)
            lsYopID = value
        End Set
    End Property

    Dim lsBlockID As String
    Public Property psBlockID() As String 'Related to db table column name: BlockID
        Get
            Return lsBlockID
        End Get
        Set(ByVal value As String)
            lsBlockID = value
        End Set
    End Property

    Dim lsActivity As String
    Public Property psActivity() As String 'Related to db table column name: Activity
        Get
            Return lsActivity
        End Get
        Set(ByVal value As String)
            lsActivity = value
        End Set
    End Property

    Dim lcStatus As Char
    Public Property pcStatus() As Char 'Related to db table column name: Status
        Get
            Return lcStatus
        End Get
        Set(ByVal value As Char)
            lcStatus = value
        End Set
    End Property

    Dim lsFFBDeliveryOrderNo As String
    Public Property psFFBDeliveryOrderNo() As String 'Related to db table column name: FFBDeliveryOrderNo
        Get
            Return lsFFBDeliveryOrderNo
        End Get
        Set(ByVal value As String)
            lsFFBDeliveryOrderNo = value
        End Set
    End Property

    Dim liBunches As Decimal
    Public Property piBunches() As Decimal 'Related to db table column name: Bunches
        Get
            Return liBunches
        End Get
        Set(ByVal value As Decimal)
            liBunches = value
        End Set
    End Property

    Dim liActualBunchesMill As Decimal
    Public Property piActualBunchesMill() As Decimal 'Related to db table column name: ActualBunchesMill
        Get
            Return liActualBunchesMill
        End Get
        Set(ByVal value As Decimal)
            liActualBunchesMill = value
        End Set
    End Property

    Dim lsCollectionPoint As String
    Public Property psCollectionPoint() As String 'Related to db table column name: CollectionPoint
        Get
            Return lsCollectionPoint
        End Get
        Set(ByVal value As String)
            lsCollectionPoint = value
        End Set
    End Property

    Dim liMillWeight As Decimal
    Public Property piMillWeight() As Decimal 'Related to db table column name: MillWeight
        Get
            Return liMillWeight
        End Get
        Set(ByVal value As Decimal)
            liMillWeight = value
        End Set
    End Property

    Dim ldDateHarvestedDT As Date
    Public Property pdDateHarvestedDT() As Date 'Related to db table column name: DateHarvested
        Get
            Return IIf(ldDateHarvestedDT = Date.MinValue, CDate("1/1/1753"), ldDateHarvestedDT)
        End Get
        Set(ByVal value As Date)
            ldDateHarvestedDT = value
        End Set
    End Property

    Dim ldDateCollectedDT As Date
    Public Property pdDateCollectedDT() As Date 'Related to db table column name: DateCollected
        Get
            Return IIf(ldDateCollectedDT = Date.MinValue, CDate("1/1/1753"), ldDateCollectedDT)
        End Get
        Set(ByVal value As Date)
            ldDateCollectedDT = value
        End Set
    End Property

    Dim lsDoubleHandledFFB As String
    Public Property psDoubleHandledFFB() As String 'Related to db table column name: DoubleHandledFFB
        Get
            Return lsDoubleHandledFFB
        End Get
        Set(ByVal value As String)
            lsDoubleHandledFFB = value
        End Set
    End Property

    Dim lsWeightedBy As String
    Public Property psWeightedBy() As String 'Related to db table column name: WeightedBy
        Get
            Return lsWeightedBy
        End Get
        Set(ByVal value As String)
            lsWeightedBy = value
        End Set
    End Property

    Dim lsDispatchedBy As String
    Public Property psDispatchedBy() As String 'Related to db table column name: DispatchedBy
        Get
            Return lsDispatchedBy
        End Get
        Set(ByVal value As String)
            lsDispatchedBy = value
        End Set
    End Property

    Dim lsRemarks As String
    Public Property psVHRLRemarks() As String 'Related to db table column name: VHRLRemarks
        Get
            Return lsRemarks
        End Get
        Set(ByVal value As String)
            lsRemarks = value
        End Set
    End Property

    'Dim lsCreatedBy As String
    'Public Property psCreatedBy() As String 'Related to db table column name: CreatedBy
    '    Get
    '        Return lsCreatedBy
    '    End Get
    '    Set(ByVal value As String)
    '        lsCreatedBy = value
    '    End Set
    'End Property

    'Dim lsModifiedBy As String
    'Public Property psModifiedBy() As String 'Related to db table column name: ModifiedBy
    '    Get
    '        Return lsModifiedBy
    '    End Get
    '    Set(ByVal value As String)
    '        lsModifiedBy = value
    '    End Set
    'End Property

    Dim lsConcurrencyID As Byte() = New Byte(7) {}
    Public Property piConcurrencyId() As Byte() 'Related to db procedure parameter : @ConcurrencyId
        Get
            Return lsConcurrencyID
        End Get
        Set(ByVal value As Byte())
            lsConcurrencyID = value
        End Set
    End Property


    Private ldOutStandingHrs As TimeSpan
    Public Property pdOutStandingHrs() As TimeSpan
        Get
            Return ldOutStandingHrs
        End Get
        Set(ByVal value As TimeSpan)
            ldOutStandingHrs = value
        End Set
    End Property


    Private ldOutStandingKms As Decimal
    Public Property pdOutStandingKms() As Decimal
        Get
            Return ldOutStandingKms
        End Get
        Set(ByVal value As Decimal)
            ldOutStandingKms = value
        End Set
    End Property


    Private lcPosted As Char
    Public Property pcPosted() As Char
        Get
            Return lcPosted
        End Get
        Set(ByVal value As Char)
            lcPosted = value
        End Set
    End Property


End Class
