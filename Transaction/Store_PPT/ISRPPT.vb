Public Class ISRPPT
#Region "Private Member Declarations"
    Private _STISRID As String = String.Empty
    Private _ISRNo As String = String.Empty
    Private _ISRDate As Date = Date.Now
    Private _Supplier As String = String.Empty
    Private _RequiredFor As String = String.Empty
    Private _MakeModel As String = String.Empty
    Private _Engine As String = String.Empty
    Private _ChassisNo As String = String.Empty
    Private _ISRDetID As String = String.Empty
    Private _ServiceDetail As String = String.Empty
    Private _Qty As Integer
    Private _Unit As String = String.Empty
    Private _COAID As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _UnitPrice As Integer
    Private _Value As Integer

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
    Public Property ISRDetID() As String
        Get
            Return _ISRDetID
        End Get
        Set(ByVal value As String)
            _ISRDetID = value
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
    Public Property Qty() As Integer
        Get
            Return _Qty
        End Get
        Set(ByVal value As Integer)
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
    Public Property UnitPrice() As Integer
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Integer)
            _UnitPrice = value
        End Set
    End Property
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            _Value = value
        End Set
    End Property

#End Region
End Class
