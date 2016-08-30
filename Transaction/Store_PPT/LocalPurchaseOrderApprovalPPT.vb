Public Class LocalPurchaseOrderApprovalPPT
#Region "Private Member Declarations"
    Private _STLPOID As String = String.Empty
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



#End Region
End Class
