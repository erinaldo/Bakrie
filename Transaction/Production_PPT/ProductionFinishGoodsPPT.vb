Public Class ProductionFinishGoodsPPT
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

    Private _Station As String
    Public Property Station() As String
        Get
            Return _Station
        End Get
        Set(ByVal value As String)
            _Station = value
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

    Private _Product As String
    Public Property Product() As String
        Get
            Return _Product
        End Get
        Set(ByVal value As String)
            _Product = value
        End Set
    End Property

    Private _Location As String
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property

    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Private _QtyCenexDry As Decimal
    Public Property QtyCenexDry() As Decimal
        Get
            Return _QtyCenexDry
        End Get
        Set(ByVal value As Decimal)
            _QtyCenexDry = value
        End Set
    End Property

    Private _QtyCenexWet As Decimal
    Public Property QtyCenexWet() As Decimal
        Get
            Return _QtyCenexWet
        End Get
        Set(ByVal value As Decimal)
            _QtyCenexWet = value
        End Set
    End Property

    Private _QtyDry As Decimal
    Public Property QtyDry() As Decimal
        Get
            Return _QtyDry
        End Get
        Set(ByVal value As Decimal)
            _QtyDry = value
        End Set
    End Property
    Private _QtyWet As Decimal
    Public Property QtyWet() As Decimal
        Get
            Return _QtyWet
        End Get
        Set(ByVal value As Decimal)
            _QtyWet = value
        End Set
    End Property

    Private _DRC As Decimal
    Public Property DRC() As Decimal
        Get
            Return _DRC
        End Get
        Set(ByVal value As Decimal)
            _DRC = value
        End Set
    End Property

    Private _QtyTodayWet As Decimal
    Public Property QtyTodayWet() As Decimal
        Get
            Return _QtyTodayWet
        End Get
        Set(ByVal value As Decimal)
            _QtyTodayWet = value
        End Set
    End Property

    Private _QtyTodayDry As Decimal
    Public Property QtyTodayDry() As Decimal
        Get
            Return _QtyTodayDry
        End Get
        Set(ByVal value As Decimal)
            _QtyTodayDry = value
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
