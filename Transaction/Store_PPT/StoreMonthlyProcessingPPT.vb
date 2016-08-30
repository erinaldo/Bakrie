Public Class StoreMonthlyProcessingPPT

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
