Public Class ProductionCrumbRubberPPT
    Private _Id As Decimal
    Public Property Id() As Decimal
        Get
            Return _Id
        End Get
        Set(ByVal value As Decimal)
            _Id = value
        End Set
    End Property

    Private _DocDate As DateTime?
    Public Property DocDate() As DateTime?
        Get
            Return _DocDate
        End Get
        Set(ByVal value As DateTime?)
            _DocDate = value
        End Set
    End Property

    Private _Assistant As String
    Public Property Assistant() As String
        Get
            Return _Assistant
        End Get
        Set(ByVal value As String)
            _Assistant = value
        End Set
    End Property


    Private _StartTime As String
    Public Property StartTime() As String
        Get
            Return _StartTime
        End Get
        Set(ByVal value As String)
            _StartTime = value
        End Set
    End Property


    Private _EndTime As String
    Public Property EndTime() As String
        Get
            Return _EndTime
        End Get
        Set(ByVal value As String)
            _EndTime = value
        End Set
    End Property

    Private _BreakdownTime As String
    Public Property BreakdownTime() As String
        Get
            Return _BreakdownTime
        End Get
        Set(ByVal value As String)
            _BreakdownTime = value
        End Set
    End Property

    Private _ShiftHours As String
    Public Property ShiftHours() As String
        Get
            Return _ShiftHours
        End Get
        Set(ByVal value As String)
            _ShiftHours = value
        End Set
    End Property

    Private _ProductType As String
    Public Property ProductType() As String
        Get
            Return _ProductType
        End Get
        Set(ByVal value As String)
            _ProductType = value
        End Set
    End Property

    Private _Storage As String
    Public Property Storage() As String
        Get
            Return _Storage
        End Get
        Set(ByVal value As String)
            _Storage = value
        End Set
    End Property

    Private _ReceivedWet As Decimal
    Public Property ReceivedWet() As Decimal
        Get
            Return _ReceivedWet
        End Get
        Set(ByVal value As Decimal)
            _ReceivedWet = value
        End Set
    End Property

    Private _ReceivedDry As Decimal
    Public Property ReceivedDry() As Decimal
        Get
            Return _ReceivedDry
        End Get
        Set(ByVal value As Decimal)
            _ReceivedDry = value
        End Set
    End Property

    Private _RProduct As String
    Public Property RProduct() As String
        Get
            Return _RProduct
        End Get
        Set(ByVal value As String)
            _RProduct = value
        End Set
    End Property

    Private _RStorage As String
    Public Property RStorage() As String
        Get
            Return _RStorage
        End Get
        Set(ByVal value As String)
            _RStorage = value
        End Set
    End Property

    Private _StockAwalDry As Decimal
    Public Property StockAwalDry() As Decimal
        Get
            Return _StockAwalDry
        End Get
        Set(ByVal value As Decimal)
            _StockAwalDry = value
        End Set
    End Property

    Private _IntakeDry As Decimal
    Public Property IntakeDry() As Decimal
        Get
            Return _IntakeDry
        End Get
        Set(ByVal value As Decimal)
            _IntakeDry = value
        End Set
    End Property

    Private _LatexPrcoess As Decimal
    Public Property LatexProcess() As Decimal
        Get
            Return _LatexPrcoess
        End Get
        Set(ByVal value As Decimal)
            _LatexPrcoess = value
        End Set
    End Property

    Private _AdjustmentDry As Decimal
    Public Property AdjustmentDry() As Decimal
        Get
            Return _AdjustmentDry
        End Get
        Set(ByVal value As Decimal)
            _AdjustmentDry = value
        End Set
    End Property

    Private _StockAkhirDry As Decimal
    Public Property StockAkhirDry() As Decimal
        Get
            Return _StockAkhirDry
        End Get
        Set(ByVal value As Decimal)
            _StockAkhirDry = value
        End Set
    End Property

    Private _tstamp As Byte()
    Public Property Tstamp() As Byte()
        Get
            Return _tstamp
        End Get
        Set(ByVal value As Byte())
            _tstamp = value
        End Set
    End Property

End Class
