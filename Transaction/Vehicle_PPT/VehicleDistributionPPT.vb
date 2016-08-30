Public Class VehicleDistributionPPT
#Region "Private Varibles"

    Private _ParentId As String = String.Empty
    Private _AccountType As String = String.Empty
    Private _OldCOACode As String = String.Empty
#End Region

#Region "Public Member Declarations"

    Public Property ParentId() As String
        Get
            Return _ParentId
        End Get
        Set(ByVal value As String)
            _ParentId = value
        End Set
    End Property

    Public Property AccountType() As String
        Get
            Return _AccountType
        End Get
        Set(ByVal value As String)
            _AccountType = value
        End Set
    End Property

    Public Property OldCOACode() As String
        Get
            Return _OldCOACode
        End Get
        Set(ByVal value As String)
            _OldCOACode = value
        End Set
    End Property

#End Region

#Region "Properties"

    'Related to db table column name: VHDistributionID
    Private lsDistributionId As String
    Public Property psVHDistributionID() As String
        Get
            Return lsDistributionId
        End Get
        Set(ByVal value As String)
            lsDistributionId = value
        End Set
    End Property

    'Related to db table column name: EstateID
    'Private lsEstateId As String
    'Public Property psEstateID() As String
    '    Get
    '        Return lsEstateId
    '    End Get
    '    Set(ByVal value As String)
    '        lsEstateId = value
    '    End Set
    'End Property

    'Related to db table column name: ActiveMonthYearID
    'Private lsActiveMonthYearId As String
    'Public Property psActiveMonthYearID() As String
    '    Get
    '        Return lsActiveMonthYearId
    '    End Get
    '    Set(ByVal value As String)
    '        lsActiveMonthYearId = value
    '    End Set
    'End Property

    'Related to db table column name: DistributionDT
    Private ldDistributionDT As DateTime
    Public Property pdDistributionDT() As DateTime
        Get
            Return ldDistributionDT
        End Get
        Set(ByVal value As DateTime)
            ldDistributionDT = value
        End Set
    End Property

    'Related to db table column name: VHID
    Private lsVehicleId As String
    Public Property psVHID() As String
        Get
            Return lsVehicleId
        End Get
        Set(ByVal value As String)
            lsVehicleId = value
        End Set
    End Property

    'Related to db table column name: VHID
    Private lsVehicleName As String
    Public Property psVehicleName() As String
        Get
            Return lsVehicleName
        End Get
        Set(ByVal value As String)
            lsVehicleName = value
        End Set
    End Property

    'Related to db table column name: TotalRunningKmHours
    Private ldTotalRunningKmHours As Decimal
    Public Property pdTotalRunningKmHours() As Decimal
        Get
            Return ldTotalRunningKmHours
        End Get
        Set(ByVal value As Decimal)
            ldTotalRunningKmHours = value
        End Set
    End Property

    'Related to db table column name: TotalKmHoursDistributed
    Private ldTotalKmHoursDistributed As Decimal
    Public Property pdTotalKmHoursDistributed() As Decimal
        Get
            Return ldTotalKmHoursDistributed
        End Get
        Set(ByVal value As Decimal)
            ldTotalKmHoursDistributed = value
        End Set
    End Property

    'Related to db table column name: COAID
    Private lsAccountCode As String
    Public Property psCOAID() As String
        Get
            Return lsAccountCode
        End Get
        Set(ByVal value As String)
            lsAccountCode = value
        End Set
    End Property

    'Related to db table column name: KmHours
    Private ldKmHours As Decimal
    Public Property pdKmHours() As Decimal
        Get
            Return ldKmHours
        End Get
        Set(ByVal value As Decimal)
            ldKmHours = value
        End Set
    End Property

    'Related to db table column name: BalanceToDistribute
    Private ldBalanceToDistribue As Decimal
    Public Property pdBalanceToDistribute() As Decimal
        Get
            Return ldBalanceToDistribue
        End Get
        Set(ByVal value As Decimal)
            ldBalanceToDistribue = value
        End Set
    End Property

    'Related to db table column name: PrestasiTonBunchesKm
    Private ldPrestasiTonBunchesKm As Decimal
    Public Property pdPrestasiTonBunchesKm() As Decimal
        Get
            Return ldPrestasiTonBunchesKm
        End Get
        Set(ByVal value As Decimal)
            ldPrestasiTonBunchesKm = value
        End Set
    End Property

    'Related to db table column name: T0
    Private lsTAnalysis0 As String
    Public Property psT0() As String
        Get
            Return lsTAnalysis0
        End Get
        Set(ByVal value As String)
            lsTAnalysis0 = value
        End Set
    End Property

    'Related to db table column name: T1
    Private lsTAnalysis1 As String
    Public Property psT1() As String
        Get
            Return lsTAnalysis1
        End Get
        Set(ByVal value As String)
            lsTAnalysis1 = value
        End Set
    End Property

    'Related to db table column name: T2
    Private lsTAnalysis2 As String
    Public Property psT2() As String
        Get
            Return lsTAnalysis2
        End Get
        Set(ByVal value As String)
            lsTAnalysis2 = value
        End Set
    End Property

    'Related to db table column name: T3
    Private lsTAnalysis3 As String
    Public Property psT3() As String
        Get
            Return lsTAnalysis3
        End Get
        Set(ByVal value As String)
            lsTAnalysis3 = value
        End Set
    End Property

    'Related to db table column name: T4
    Private lsTAnalysis4 As String
    Public Property psT4() As String
        Get
            Return lsTAnalysis4
        End Get
        Set(ByVal value As String)
            lsTAnalysis4 = value
        End Set
    End Property

    'Related to db table column name: DivID
    Private lsDivisionId As String
    Public Property psDivID() As String
        Get
            Return lsDivisionId
        End Get
        Set(ByVal value As String)
            lsDivisionId = value
        End Set
    End Property

    'Related to db table column name: YOPID
    Private lsYOPId As String
    Public Property psYOPID() As String
        Get
            Return lsYOPId
        End Get
        Set(ByVal value As String)
            lsYOPId = value
        End Set
    End Property

    'Related to db table column name: BlockID
    Private lsBlockId As String
    Public Property psBlockID() As String
        Get
            Return lsBlockId
        End Get
        Set(ByVal value As String)
            lsBlockId = value
        End Set
    End Property

    'Related to db table column name: Remarks
    Private lsRemarks As String
    Public Property psRemarks() As String
        Get
            Return lsRemarks
        End Get
        Set(ByVal value As String)
            lsRemarks = value
        End Set
    End Property

    'Related to db table column name: CreatedBy
    'Private lsCreatedBy As String
    'Public Property psCreatedBy() As String
    '    Get
    '        Return lsCreatedBy
    '    End Get
    '    Set(ByVal value As String)
    '        lsCreatedBy = value
    '    End Set
    'End Property

    'Related to db table column name: ModifiedBy
    'Private lsModifiedBy As String
    'Public Property psModifiedBy() As String
    '    Get
    '        Return lsModifiedBy
    '    End Get
    '    Set(ByVal value As String)
    '        lsModifiedBy = value
    '    End Set
    'End Property

    Private liId As Integer
    Public Property piId() As Integer
        Get
            Return liId
        End Get
        Set(ByVal value As Integer)
            liId = value
        End Set
    End Property

    Private lsSearchBy As String
    Public Property psSearchBy() As String
        Get
            Return lsSearchBy
        End Get
        Set(ByVal value As String)
            lsSearchBy = value
        End Set
    End Property

    Private lsSearchTerm As String
    Public Property psSearchTerm() As String
        Get
            Return lsSearchTerm
        End Get
        Set(ByVal value As String)
            lsSearchTerm = value
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

    Private lsCOADesc As String
    Public Property psCOADesc() As String
        Get
            Return lsCOADesc
        End Get
        Set(ByVal value As String)
            lsCOADesc = value
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

    Private lsCategory As String
    Public Property psCategory() As String
        Get
            Return lsCategory
        End Get
        Set(ByVal value As String)
            lsCategory = value
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

    Private lsRegNo As String
    Public Property psRegNo() As String
        Get
            Return lsRegNo
        End Get
        Set(ByVal value As String)
            lsRegNo = value
        End Set
    End Property

    Private ldTotalKms As Decimal
    Public Property pdTotalKms() As Decimal
        Get
            Return ldTotalKms
        End Get
        Set(ByVal value As Decimal)
            ldTotalKms = value
        End Set
    End Property

    Private ldTotalHrsDT As TimeSpan
    Public Property pdTotalHrsDT() As TimeSpan
        Get
            Return ldTotalHrsDT
        End Get
        Set(ByVal value As TimeSpan)
            ldTotalHrsDT = value
        End Set
    End Property

    Private lsTotalKmHoursDistributedKms As String
    Public Property psTotalKmHoursDistributedKms() As String
        Get
            Return lsTotalKmHoursDistributedKms
        End Get
        Set(ByVal value As String)
            lsTotalKmHoursDistributedKms = value
        End Set
    End Property

    Private lsTotalKmHoursDistributedHrs As String
    Public Property psTotalKmHoursDistributedHrs() As String
        Get
            Return lsTotalKmHoursDistributedHrs
        End Get
        Set(ByVal value As String)
            lsTotalKmHoursDistributedHrs = value
        End Set
    End Property

    Dim lbConcurrencyID As Byte() = New Byte(7) {}
    Public Property pbConcurrencyId() As Byte() 'Related to db procedure parameter : @ConcurrencyId
        Get
            Return lbConcurrencyID
        End Get
        Set(ByVal value As Byte())
            lbConcurrencyID = value
        End Set
    End Property

#End Region

#Region "Private Member Declarations"
    Private _STIssueID As String = String.Empty
    Private _STIssueBatchID As String = String.Empty
    Private _SIVNO As String = String.Empty
    Private _SIVDate As Date = Date.Today
    Private _ContractID As String = String.Empty
    Private _ContractNo As String = String.Empty
    Private _ContractName As String = String.Empty
    Private _Status As String = String.Empty
    Private _Remarks As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _STIssueDetailsID As String = String.Empty
    Private _IssueBatchTotal As Double
    Private _STCategoryID As String = String.Empty
    Private _STCategory As String = String.Empty
    Private _STCategoryCode As String = String.Empty
    Private _StockID As String = String.Empty
    Private _StockCode As String = String.Empty
    Private _StockDesc As String = String.Empty
    Private _IssuedQty As Double
    Private _AvailQty As Double
    Private _usedFor As String = String.Empty
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _T0Value As String = String.Empty
    Private _T1Value As String = String.Empty
    Private _T2Value As String = String.Empty
    Private _T3Value As String = String.Empty
    Private _T4Value As String = String.Empty
    Private _T0Desc As String = String.Empty
    Private _T1Desc As String = String.Empty
    Private _T2Desc As String = String.Empty
    Private _T3Desc As String = String.Empty
    Private _T4Desc As String = String.Empty
    Private _TDecide As String = String.Empty
    Private _DivID As String = String.Empty
    Private _Div As String = String.Empty
    Private _DivName As String = String.Empty
    Private _YOPID As String = String.Empty
    Private _YOP As String = String.Empty
    Private _YOPName As String = String.Empty
    Private _BlockID As String = String.Empty
    Private _BlockName As String = String.Empty
    Private _BlockStatus As String = String.Empty
    Private _StationID As String = String.Empty
    Private _StationCode As String = String.Empty
    Private _StationDesc As String = String.Empty
    Private _VHID As String = String.Empty
    Private _VHWSCode As String = String.Empty
    Private _VHDesc As String = String.Empty
    Private _ODOReading As Double
    Private _VHDetailCostCode As String = String.Empty
    Private _VHDetailCostCodeID As String = String.Empty
    Private _VHDetailCostDesc As String = String.Empty
    Private _IssueUnitPrice As Double
    Private _IssuedValue As Double
    Private _SIVDateSearch As Date
    Private _SIVNOSearch As String = String.Empty
    Private _ConttractNoSearch As String = String.Empty
    Private _RemarksSearch As String = String.Empty
    Private _StatusSearch As String = String.Empty
    Private _BViewSIVDate As Boolean = False
    Private _VHCategoryID As String = String.Empty
    Private _Type As String = String.Empty
#End Region

#Region "Public Member Declarations"
    Public Property STIssueID() As String
        Get
            Return _STIssueID
        End Get
        Set(ByVal value As String)
            _STIssueID = value
        End Set
    End Property

    Public Property STIssueBatchID() As String
        Get
            Return _STIssueBatchID
        End Get
        Set(ByVal value As String)
            _STIssueBatchID = value
        End Set
    End Property
    Public Property SIVNO() As String
        Get
            Return _SIVNO
        End Get
        Set(ByVal value As String)
            _SIVNO = value
        End Set
    End Property
    Public Property SIVDate() As Date
        Get
            Return _SIVDate
        End Get
        Set(ByVal value As Date)
            _SIVDate = value
        End Set
    End Property
    Public Property ContractID() As String
        Get
            Return _ContractID
        End Get
        Set(ByVal value As String)
            _ContractID = value
        End Set
    End Property
    Public Property ContractNo() As String
        Get
            Return _ContractNo
        End Get
        Set(ByVal value As String)
            _ContractNo = value
        End Set
    End Property
    Public Property ContractName() As String
        Get
            Return _ContractName
        End Get
        Set(ByVal value As String)
            _ContractName = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property RejectedReason() As String
        Get
            Return _RejectedReason
        End Get
        Set(ByVal value As String)
            _RejectedReason = value
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
    Public Property STIssueDetailsID() As String
        Get
            Return _STIssueDetailsID
        End Get
        Set(ByVal value As String)
            _STIssueDetailsID = value
        End Set
    End Property
    Public Property IssueBatchTotal() As Double
        Get
            Return _IssueBatchTotal
        End Get
        Set(ByVal value As Double)
            _IssueBatchTotal = value
        End Set
    End Property
    Public Property STCategoryID() As String
        Get
            Return _STCategoryID
        End Get
        Set(ByVal value As String)
            _STCategoryID = value
        End Set
    End Property
    Public Property STCategory() As String
        Get
            Return _STCategory
        End Get
        Set(ByVal value As String)
            _STCategory = value
        End Set
    End Property
    Public Property STCategoryCode() As String
        Get
            Return _STCategoryCode
        End Get
        Set(ByVal value As String)
            _STCategoryCode = value
        End Set
    End Property

    Public Property StockID() As String
        Get
            Return _StockID
        End Get
        Set(ByVal value As String)
            _StockID = value
        End Set
    End Property
    Public Property StockCode() As String
        Get
            Return _StockCode
        End Get
        Set(ByVal value As String)
            _StockCode = value
        End Set
    End Property
    Public Property StockDesc() As String
        Get
            Return _StockDesc
        End Get
        Set(ByVal value As String)
            _StockDesc = value
        End Set
    End Property
    Public Property IssuedQty() As Double
        Get
            Return _IssuedQty
        End Get
        Set(ByVal value As Double)
            _IssuedQty = value
        End Set
    End Property
    Public Property AvailQty() As Double
        Get
            Return _AvailQty
        End Get
        Set(ByVal value As Double)
            _AvailQty = value
        End Set
    End Property
    Public Property usedFor() As String
        Get
            Return _usedFor
        End Get
        Set(ByVal value As String)
            _usedFor = value
        End Set
    End Property
    Public Property COAID() As String
        Get
            Return _COAID
        End Get
        Set(ByVal value As String)
            _COAID = value
        End Set
    End Property
    Public Property COACode() As String
        Get
            Return _COACode
        End Get
        Set(ByVal value As String)
            _COACode = value
        End Set
    End Property
    Public Property COADescp() As String
        Get
            Return _COADescp
        End Get
        Set(ByVal value As String)
            _COADescp = value
        End Set
    End Property
    Public Property T0() As String
        Get
            Return _T0
        End Get
        Set(ByVal value As String)
            _T0 = value
        End Set
    End Property
    Public Property T0Value() As String
        Get
            Return _T0Value
        End Get
        Set(ByVal value As String)
            _T0Value = value
        End Set
    End Property
    Public Property T0Desc() As String
        Get
            Return _T0Desc
        End Get
        Set(ByVal value As String)
            _T0Desc = value
        End Set
    End Property
    Public Property T1() As String
        Get
            Return _T1
        End Get
        Set(ByVal value As String)
            _T1 = value
        End Set
    End Property
    Public Property T1Value() As String
        Get
            Return _T1Value
        End Get
        Set(ByVal value As String)
            _T1Value = value
        End Set
    End Property
    Public Property T1Desc() As String
        Get
            Return _T1Desc
        End Get
        Set(ByVal value As String)
            _T1Desc = value
        End Set
    End Property
    Public Property T2() As String
        Get
            Return _T2
        End Get
        Set(ByVal value As String)
            _T2 = value
        End Set
    End Property
    Public Property T2Value() As String
        Get
            Return _T2Value
        End Get
        Set(ByVal value As String)
            _T2Value = value
        End Set
    End Property
    Public Property T2Desc() As String
        Get
            Return _T2Desc
        End Get
        Set(ByVal value As String)
            _T2Desc = value
        End Set
    End Property
    Public Property T3() As String
        Get
            Return _T3
        End Get
        Set(ByVal value As String)
            _T3 = value
        End Set
    End Property
    Public Property T3Value() As String
        Get
            Return _T3Value
        End Get
        Set(ByVal value As String)
            _T3Value = value
        End Set
    End Property
    Public Property T3Desc() As String
        Get
            Return _T3Desc
        End Get
        Set(ByVal value As String)
            _T3Desc = value
        End Set
    End Property
    Public Property T4() As String
        Get
            Return _T4
        End Get
        Set(ByVal value As String)
            _T4 = value
        End Set
    End Property
    Public Property T4Value() As String
        Get
            Return _T4Value
        End Get
        Set(ByVal value As String)
            _T4Value = value
        End Set
    End Property
    Public Property T4Desc() As String
        Get
            Return _T4Desc
        End Get
        Set(ByVal value As String)
            _T4Desc = value
        End Set
    End Property
    Public Property TDecide() As String
        Get
            Return _TDecide
        End Get
        Set(ByVal value As String)
            _TDecide = value
        End Set
    End Property
    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property
    Public Property Div() As String
        Get
            Return _Div
        End Get
        Set(ByVal value As String)
            _Div = value
        End Set
    End Property
    Public Property DivName() As String
        Get
            Return _DivName
        End Get
        Set(ByVal value As String)
            _DivName = value
        End Set
    End Property

    Public Property YOPID() As String
        Get
            Return _YOPID
        End Get
        Set(ByVal value As String)
            _YOPID = value
        End Set
    End Property
    Public Property YOP() As String
        Get
            Return _YOP
        End Get
        Set(ByVal value As String)
            _YOP = value
        End Set
    End Property
    Public Property YOPName() As String
        Get
            Return _YOPName
        End Get
        Set(ByVal value As String)
            _YOPName = value
        End Set
    End Property

    Public Property BlockID() As String
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)
            _BlockID = value
        End Set
    End Property
    Public Property BlockName() As String
        Get
            Return _BlockName
        End Get
        Set(ByVal value As String)
            _BlockName = value
        End Set
    End Property

    Public Property BlockStatus() As String
        Get
            Return _BlockStatus
        End Get
        Set(ByVal value As String)
            _BlockStatus = value
        End Set
    End Property

    Public Property StationID() As String
        Get
            Return _StationID
        End Get
        Set(ByVal value As String)
            _StationID = value
        End Set
    End Property
    Public Property Stationcode() As String
        Get
            Return _StationCode
        End Get
        Set(ByVal value As String)
            _StationCode = value
        End Set
    End Property
    Public Property StationDesc() As String
        Get
            Return _StationDesc
        End Get
        Set(ByVal value As String)
            _StationDesc = value
        End Set
    End Property
    Public Property VHID() As String
        Get
            Return _VHID
        End Get
        Set(ByVal value As String)
            _VHID = value
        End Set
    End Property
    Public Property VHWSCode() As String
        Get
            Return _VHWSCode
        End Get
        Set(ByVal value As String)
            _VHWSCode = value
        End Set
    End Property
    Public Property VHDesc() As String
        Get
            Return _VHDesc
        End Get
        Set(ByVal value As String)
            _VHDesc = value
        End Set
    End Property
    Public Property ODOReading() As Double
        Get
            Return _ODOReading
        End Get
        Set(ByVal value As Double)
            _ODOReading = value
        End Set
    End Property

    Public Property VHDetailCostCode() As String
        Get
            Return _VHDetailCostCode
        End Get
        Set(ByVal value As String)
            _VHDetailCostCode = value
        End Set
    End Property
    Public Property VHDetailCostCodeID() As String
        Get
            Return _VHDetailCostCodeID
        End Get
        Set(ByVal value As String)
            _VHDetailCostCodeID = value
        End Set
    End Property
    Public Property VHDetailCostDesc() As String
        Get
            Return _VHDetailCostDesc
        End Get
        Set(ByVal value As String)
            _VHDetailCostDesc = value
        End Set
    End Property

    Public Property IssueUnitPrice() As Double
        Get
            Return _IssueUnitPrice
        End Get
        Set(ByVal value As Double)
            _IssueUnitPrice = value
        End Set
    End Property
    Public Property IssuedValue() As Double
        Get
            Return _IssuedValue
        End Get
        Set(ByVal value As Double)
            _IssuedValue = value
        End Set
    End Property
    Public Property SIVDateSearch() As Date
        Get
            Return _SIVDateSearch
        End Get
        Set(ByVal value As Date)
            _SIVDateSearch = value
        End Set
    End Property

    Public Property SIVNOSearch() As String
        Get
            Return _SIVNOSearch
        End Get
        Set(ByVal value As String)
            _SIVNOSearch = value
        End Set
    End Property
    Public Property ConttractNoSearch() As String
        Get
            Return _ConttractNoSearch
        End Get
        Set(ByVal value As String)
            _ConttractNoSearch = value
        End Set
    End Property
    Public Property RemarksSearch() As String
        Get
            Return _RemarksSearch
        End Get
        Set(ByVal value As String)
            _RemarksSearch = value
        End Set
    End Property
    Public Property StatusSearch() As String
        Get
            Return _StatusSearch
        End Get
        Set(ByVal value As String)
            _StatusSearch = value
        End Set
    End Property
    Public Property BViewSIVDate() As Boolean
        Get
            Return _BViewSIVDate
        End Get
        Set(ByVal value As Boolean)
            _BViewSIVDate = value
        End Set
    End Property

    Public Property VHCategoryID() As String
        Get
            Return _VHCategoryID
        End Get
        Set(ByVal value As String)
            _VHCategoryID = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

#End Region



End Class
