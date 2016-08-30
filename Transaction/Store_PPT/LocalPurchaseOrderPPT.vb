Public Class LocalPurchaseOrderPPT

#Region "Private Member Declarations"
    Private _STLPOID As String = String.Empty
    Private _Total As String = String.Empty
    Private _VATPercent As String = String.Empty
    Private _TotalAll As String = String.Empty
    Private _MRCNo As String = String.Empty
    Private _UOM As String = String.Empty
    Private _VAT As String = String.Empty
    Private _TransportationCost As String = String.Empty
    Private _LPONo As String = String.Empty
    Private _LPODate As Date = Date.Today
    Private _ContractID As String = String.Empty
    Private _SupplierID As String = String.Empty
    Private _Remarks As String = String.Empty
    Private _MainStatus As String = String.Empty
    Private _STLPODetID As String = String.Empty
    Private _StockID As String = String.Empty
    Private _OrderQty As Double
    Private _UnitPrice As Double
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _Value As Double
    Private _PendingQty As Double
    Private _BViewSIVDate As Boolean = False
    Private _StockCode As String = String.Empty
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty

    Private _STCategoryID As String = String.Empty
    Private _STCategory As String = String.Empty
    Private _STCategoryCode As String = String.Empty
    Private _SupplierName As String = String.Empty

#End Region

#Region "Public Properties"

    'Public Property STLPOID() As String
    '    Get
    '        Return _STLPOID
    '    End Get
    '    Set(ByVal value As String)
    '        _STLPOID = value
    '    End Set
    'End Property

    Property TotalAll() As String
        Get
            Return _TotalAll
        End Get
        Set(ByVal value As String)
            _TotalAll = value
        End Set
    End Property
    Property VATPercent() As String
        Get
            Return _VATPercent
        End Get
        Set(ByVal value As String)
            _VATPercent = value
        End Set
    End Property
    Property TOTAL() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property
    Property VAT() As String
        Get
            Return _VAT
        End Get
        Set(ByVal value As String)
            _VAT = value
        End Set
    End Property
    Public Property MRCNo() As String
        Get
            Return _MRCNo
        End Get
        Set(ByVal value As String)
            _MRCNo = value
        End Set
    End Property
    Public Property STLPOID() As String
        Get
            Return _STLPOID
        End Get
        Set(ByVal value As String)
            _STLPOID = value
        End Set
    End Property

    Public Property SupplierID() As String
        Get
            Return _SupplierID
        End Get
        Set(ByVal value As String)
            _SupplierID = value
        End Set
    End Property
    Public Property LPONo() As String
        Get
            Return _LPONo
        End Get
        Set(ByVal value As String)
            _LPONo = value
        End Set
    End Property
    Public Property LPODate() As Date
        Get
            Return _LPODate
        End Get
        Set(ByVal value As Date)
            _LPODate = value
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
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property MainStatus() As String
        Get
            Return _MainStatus
        End Get
        Set(ByVal value As String)
            _MainStatus = value
        End Set
    End Property
    Public Property STLPODetID() As String
        Get
            Return _STLPODetID
        End Get
        Set(ByVal value As String)
            _STLPODetID = value
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
    Public Property OrderQty() As Double
        Get
            Return _OrderQty
        End Get
        Set(ByVal value As Double)
            _OrderQty = value
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
    Public Property Value() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
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

    Public Property BViewSIVDate() As Boolean
        Get
            Return _BViewSIVDate
        End Get
        Set(ByVal value As Boolean)
            _BViewSIVDate = value
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
    Public Property UOM() As String
        Get
            Return _UOM
        End Get
        Set(ByVal value As String)
            _UOM = value
        End Set
    End Property
    Public Property TransportationCost() As String
        Get
            Return _TransportationCost
        End Get
        Set(ByVal value As String)
            _TransportationCost = value
        End Set
    End Property


    Public Property SupplierName() As String
        Get
            Return _SupplierName
        End Get
        Set(ByVal value As String)
            _SupplierName = value
        End Set
    End Property
#End Region

End Class
