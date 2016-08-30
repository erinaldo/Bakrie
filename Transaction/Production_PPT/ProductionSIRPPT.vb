Public Class ProductionSIRPPT
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

    Private _StockAwalUnPDry As Decimal
    Public Property StockAwalUnPDry() As Decimal
        Get
            Return _StockAwalUnPDry
        End Get
        Set(ByVal value As Decimal)
            _StockAwalUnPDry = value
        End Set
    End Property

    Private _MaturasiDry As Decimal
    Public Property MaturasiDry() As Decimal
        Get
            Return _MaturasiDry
        End Get
        Set(ByVal value As Decimal)
            _MaturasiDry = value
        End Set
    End Property

    Private _OGPDry As Decimal
    Public Property OGPDry() As Decimal
        Get
            Return _OGPDry
        End Get
        Set(ByVal value As Decimal)
            _OGPDry = value
        End Set
    End Property

    Private _StockAwalInPDry As Decimal
    Public Property StockAwalInPDry() As Decimal
        Get
            Return _StockAwalInPDry
        End Get
        Set(ByVal value As Decimal)
            _StockAwalInPDry = value
        End Set
    End Property

    Private _IntakeInPDry As Decimal
    Public Property IntakeInPDry() As Decimal
        Get
            Return _IntakeInPDry
        End Get
        Set(ByVal value As Decimal)
            _IntakeInPDry = value
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

    Private _StockAkhirInPDry As Decimal
    Public Property StockAkhirInPDry() As Decimal
        Get
            Return _StockAkhirInPDry
        End Get
        Set(ByVal value As Decimal)
            _StockAkhirInPDry = value
        End Set
    End Property

    Private _StockAkhirUnPDry As Decimal
    Public Property StockAkhirUnPDry() As Decimal
        Get
            Return _StockAkhirUnPDry
        End Get
        Set(ByVal value As Decimal)
            _StockAkhirUnPDry = value
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
