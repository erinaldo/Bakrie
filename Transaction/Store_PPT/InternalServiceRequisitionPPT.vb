Public Class InternalServiceRequisitionPPT
#Region "Private Member Declarations"
    Private _STISRID As String = String.Empty
    Private _ISRNo As String = String.Empty
    Private _ISRDate As Date = Date.Now
    Private _Supplier As String = String.Empty
    Private _RequiredFor As String = String.Empty
    Private _MakeModel As String = String.Empty
    Private _Engine As String = String.Empty
    Private _ChassisNo As String = String.Empty
    Private _FixedAssetNo As String = String.Empty
    Private _ISRDetID As String = String.Empty
    Private _ServiceType As String = String.Empty
    Private _StockID As String = String.Empty
    Private _ServiceDetail As String = String.Empty
    Private _Qty As Double = 0.0
    Private _Unit As String = String.Empty
    Private _COAID As String = String.Empty
    Private _COAIDDesc As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _UnitPrice As Double = 0.0
    Private _Valu As Double = 0.0
    Private _UnitPriceC As Double = 0.0
    Private _ValueC As Double = 0.0
    Private _CurrencyID As String = String.Empty



    'Private _ISRNOSearch As String = String.Empty

    Private _ISRNOSearch As String = String.Empty
    Private _ISRDateSearch As Date
    Private _BViewISRDate As Boolean = False
    Private _NonStockID As String = String.Empty

#End Region


#Region "Public Member Declarations"
    Public Property STISRID() As String
        Get
            Return _STISRID
        End Get
        Set(ByVal value As String)
            _STISRID = value
        End Set
    End Property
    Public Property ISRNo() As String
        Get
            Return _ISRNo
        End Get
        Set(ByVal value As String)
            _ISRNo = value
        End Set
    End Property
    Public Property ISRDate() As Date
        Get
            Return _ISRDate
        End Get
        Set(ByVal value As Date)
            _ISRDate = value
        End Set
    End Property
    Public Property Supplier() As String
        Get
            Return _Supplier
        End Get
        Set(ByVal value As String)
            _Supplier = value
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
    Public Property ChassisNo() As String
        Get
            Return _ChassisNo
        End Get
        Set(ByVal value As String)
            _ChassisNo = value
        End Set
    End Property
    Public Property fixedAssetNo() As String
        Get
            Return _FixedAssetNo
        End Get
        Set(ByVal value As String)
            _FixedAssetNo = value
        End Set
    End Property

    Public Property ISRDetID() As String
        Get
            Return _ISRDetID
        End Get
        Set(ByVal value As String)
            _ISRDetID = value
        End Set
    End Property

    Public Property ServiceType() As String
        Get
            Return _ServiceType
        End Get
        Set(ByVal value As String)
            _ServiceType = value
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

    Public Property ServiceDetail() As String
        Get
            Return _ServiceDetail
        End Get
        Set(ByVal value As String)
            _ServiceDetail = value
        End Set
    End Property
    Public Property Qty() As Double
        Get
            Return _Qty
        End Get
        Set(ByVal value As Double)
            _Qty = value
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
    Public Property COAID() As String
        Get
            Return _COAID
        End Get
        Set(ByVal value As String)
            _COAID = value
        End Set
    End Property
    Public Property COAIDDesc() As String
        Get
            Return _COAIDDesc
        End Get
        Set(ByVal value As String)
            _COAIDDesc = value
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
    Public Property T1() As String
        Get
            Return _T1
        End Get
        Set(ByVal value As String)
            _T1 = value
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
    Public Property T3() As String
        Get
            Return _T3
        End Get
        Set(ByVal value As String)
            _T3 = value
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
    Public Property UnitPrice() As Double
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Double)
            _UnitPrice = value
        End Set
    End Property
    Public Property Valu() As Double
        Get
            Return _Valu
        End Get
        Set(ByVal value As Double)
            _Valu = value
        End Set
    End Property


    Public Property BViewISRDate() As Boolean
        Get
            Return _BViewISRDate
        End Get
        Set(ByVal value As Boolean)
            _BViewISRDate = value
        End Set
    End Property


    Public Property ISRDateSearch() As Date
        Get
            Return _ISRDateSearch
        End Get
        Set(ByVal value As Date)
            _ISRDateSearch = value
        End Set
    End Property


    Public Property ISRNOSearch() As String
        Get
            Return _ISRNOSearch
        End Get
        Set(ByVal value As String)
            _ISRNOSearch = value
        End Set
    End Property

    Public Property UnitPriceC() As Double
        Get
            Return _UnitPriceC
        End Get
        Set(ByVal value As Double)
            _UnitPriceC = value
        End Set
    End Property
    Public Property ValueC() As Double
        Get
            Return _ValueC
        End Get
        Set(ByVal value As Double)
            _ValueC = value
        End Set
    End Property

    Public Property CurrencyID() As String
        Get
            Return _CurrencyID
        End Get
        Set(ByVal value As String)
            _CurrencyID = value
        End Set
    End Property

    Public Property NonStockID() As String
        Get
            Return _NonStockID
        End Get
        Set(ByVal value As String)
            _NonStockID = value
        End Set
    End Property



#End Region
End Class
