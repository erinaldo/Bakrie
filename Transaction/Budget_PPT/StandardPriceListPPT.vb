Public Class StandardPriceListPPT
#Region "Private Member Declarations"
    Private _StandardPriceListID As String
    Private _EstateID As String
    Private _BudgetYear As Integer
    Private _Type As String
    Private _StockID As String
    Private _COAID As String
    Private _Descp As String
    Private _UOMId As String
    Private _Remarks As String
    Private _UOM As String
    Private _PrimeCost As Double = 0.0
    Private _OnCost As Double = 0.0
    Private _TotalCost As Double = 0.0
    Private _DisplayInUSD As Double = 0.0
    Private _LastYearCostIDR As Double = 0.0
    Private _LastYearCostUSD As String
    Private _PercentDiffUSD As Double = 0.0

#End Region
#Region "Public Properties"
    Public Property StandardPriceListID() As String
        Get
            Return _StandardPriceListID
        End Get
        Set(ByVal value As String)
            _StandardPriceListID = value
        End Set
    End Property
    Public Property EstateID() As String
        Get
            Return _EstateID
        End Get
        Set(ByVal value As String)
            _EstateID = value
        End Set
    End Property
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
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
    Public Property StockID() As String
        Get
            Return _StockID
        End Get
        Set(ByVal value As String)
            _StockID = value
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
    Public Property Descp() As String
        Get
            Return _Descp
        End Get
        Set(ByVal value As String)
            _Descp = value
        End Set
    End Property
    Public Property UOMId() As String
        Get
            Return _UOMId
        End Get
        Set(ByVal value As String)
            _UOMId = value
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
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property PrimeCost() As Double
        Get
            Return _PrimeCost
        End Get
        Set(ByVal value As Double)
            _PrimeCost = value
        End Set
    End Property
    Public Property OnCost() As Double
        Get
            Return _OnCost
        End Get
        Set(ByVal value As Double)
            _OnCost = value
        End Set
    End Property
    Public Property TotalCost() As Double
        Get
            Return _TotalCost
        End Get
        Set(ByVal value As Double)
            _TotalCost = value
        End Set
    End Property
    Public Property DisplayInUSD() As Double
        Get
            Return _DisplayInUSD
        End Get
        Set(ByVal value As Double)
            _DisplayInUSD = value
        End Set
    End Property
    Public Property LastYearCostIDR() As Double
        Get
            Return _LastYearCostIDR
        End Get
        Set(ByVal value As Double)
            _LastYearCostIDR = value
        End Set
    End Property
    Public Property LastYearCostUSD() As String
        Get
            Return _LastYearCostUSD
        End Get
        Set(ByVal value As String)
            _LastYearCostUSD = value
        End Set
    End Property
    Public Property PercentDiffUSD() As Double
        Get
            Return _PercentDiffUSD
        End Get
        Set(ByVal value As Double)
            _PercentDiffUSD = value
        End Set
    End Property
   
#End Region
End Class
