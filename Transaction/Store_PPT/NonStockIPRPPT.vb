Public Class NonStockIPRPPT
#Region "Private Member Declarations"
    Private _STNonStockIPRID As String = String.Empty
    Private _IPRdate As Date
    Private _DeliveredTo As String = String.Empty
    Private _IPRNo As String = String.Empty
    Private _Classification As String = String.Empty
    Private _STCategoryID As String = String.Empty
    Private _STCategory As String = String.Empty
    Private _STCategoryCode As String = String.Empty
    Private _RequiredFor As String = String.Empty
    Private _Mainstatus As String = String.Empty
    Private _MakeModel As String = String.Empty
    Private _Engine As String = String.Empty
    Private _ChassisSerielNo As String = String.Empty
    Private _FixedAssetNo As String = String.Empty
    Private _Remarks As String = String.Empty
    Private _STNonStockIPRDetID As String = String.Empty
    Private _stockID As String = String.Empty
    Private _RequestedQty As Double = 0.0
    Private _UnitPrice As Double = 0.0
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _value As Double = 0.0
    Private _PendingQty As Double = 0.0
    Private _IPRStatusID As String = String.Empty
    Private _StatusDate As Date
    Private _PersonName As String = String.Empty
    Private _Unit As String = String.Empty
    Private _AvailableQty As Double = 0.0
    Private _TotalPrice As Double = 0.0
    Private _EstateCode As String = String.Empty
    Private _StockCode As String = String.Empty
    Private _StockDesc As String = String.Empty
    Private _RequiredDate As Date
    Private _D As String = String.Empty
    Private _PartNo As String = String.Empty
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty

#End Region

#Region "Public Properties"
    Public Shared strGlobalCategoryID As String = String.Empty
    Public Shared strGlobalCategoryDesc As String = String.Empty
    Public Shared strGlobalCategoryCode As String = String.Empty

    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
        End Set
    End Property
    Public Property STNonStockIPRID() As String
        Get
            Return _STNonStockIPRID
        End Get
        Set(ByVal value As String)
            _STNonStockIPRID = value
        End Set
    End Property
    Public Property IPRdate() As Date
        Get
            Return _IPRdate
        End Get
        Set(ByVal value As Date)
            _IPRdate = value
        End Set
    End Property

    Public Property RequiredDate() As Date
        Get
            Return _RequiredDate
        End Get
        Set(ByVal value As Date)
            _RequiredDate = value
        End Set
    End Property

    Public Property D() As String
        Get
            Return _D
        End Get
        Set(ByVal value As String)
            _D = value
        End Set
    End Property

    Public Property DeliveredTo() As String
        Get
            Return _DeliveredTo
        End Get
        Set(ByVal value As String)
            _DeliveredTo = value
        End Set
    End Property
    Public Property IPRNo() As String
        Get
            Return _IPRNo
        End Get
        Set(ByVal value As String)
            _IPRNo = value
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
    Public Property Classification() As String
        Get
            Return _Classification
        End Get
        Set(ByVal value As String)
            _Classification = value
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

    Public Property RequiredFor() As String
        Get
            Return _RequiredFor
        End Get
        Set(ByVal value As String)
            _RequiredFor = value
        End Set
    End Property
    Public Property MainStatus() As String
        Get
            Return _Mainstatus
        End Get
        Set(ByVal value As String)
            _Mainstatus = value
        End Set
    End Property
    Public Property MakeModel() As String
        Get
            Return _MakeModel
        End Get
        Set(ByVal value As String)
            _MakeModel = value
        End Set
    End Property
    Public Property Engine() As String
        Get
            Return _Engine
        End Get
        Set(ByVal value As String)
            _Engine = value
        End Set
    End Property
    Public Property ChassisSerialNo() As String
        Get
            Return _ChassisSerielNo
        End Get
        Set(ByVal value As String)
            _ChassisSerielNo = value
        End Set
    End Property
    Public Property FixedAssetNo() As String
        Get
            Return _FixedAssetNo

        End Get
        Set(ByVal value As String)
            _FixedAssetNo = value
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
    Public Property STNonStockIPRDetID() As String
        Get
            Return _STNonStockIPRDetID
        End Get
        Set(ByVal value As String)
            _STNonStockIPRDetID = value
        End Set
    End Property
    Public Property stockID() As String
        Get
            Return _stockID
        End Get
        Set(ByVal value As String)
            _stockID = value
        End Set
    End Property
    Public Property RequestedQty() As Double
        Get
            Return _RequestedQty
        End Get
        Set(ByVal value As Double)
            _RequestedQty = value
        End Set
    End Property
    Public Property UnitPrice() As Double
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Double)
            _UnitPrice = value
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
    Public Property value() As Double
        Get
            Return _value
        End Get
        Set(ByVal value As Double)
            _value = value
        End Set
    End Property
    Public Property PendingQty() As Double
        Get
            Return _PendingQty
        End Get
        Set(ByVal value As Double)
            _PendingQty = value
        End Set
    End Property
    Public Property IPRStatusID() As String
        Get
            Return _IPRStatusID
        End Get
        Set(ByVal value As String)
            _IPRStatusID = value
        End Set
    End Property
    Public Property StatusDate() As Date
        Get
            Return _StatusDate
        End Get
        Set(ByVal value As Date)
            _StatusDate = value
        End Set
    End Property
    Public Property PersonName() As String
        Get
            Return _PersonName
        End Get
        Set(ByVal value As String)
            _PersonName = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return _Unit
        End Get
        Set(ByVal value As String)
            _Unit = value
        End Set
    End Property



    Public Property AvailableQty() As Double
        Get
            Return _AvailableQty
        End Get
        Set(ByVal value As Double)
            _AvailableQty = value
        End Set
    End Property

    Public Property TotalPrice() As Double
        Get
            Return _TotalPrice
        End Get
        Set(ByVal value As Double)
            _TotalPrice = value
        End Set
    End Property
    Public Property PartNo() As String
        Get
            Return _PartNo
        End Get
        Set(ByVal value As String)
            _PartNo = value
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

#End Region
End Class
