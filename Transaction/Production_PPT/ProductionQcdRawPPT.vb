Public Class ProductionQcdRawPPT
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

    Private _TicketNo As String
    Public Property TicketNo() As String
        Get
            Return _TicketNo
        End Get
        Set(ByVal value As String)
            _TicketNo = value
        End Set
    End Property

    Private _Estate As String
    Public Property Estate() As String
        Get
            Return _Estate
        End Get
        Set(ByVal value As String)
            _Estate = value
        End Set
    End Property

    Private _CarNo As String
    Public Property CarNo() As String
        Get
            Return _CarNo
        End Get
        Set(ByVal value As String)
            _CarNo = value
        End Set
    End Property

    Private _Division As String
    Public Property Division() As String
        Get
            Return _Division
        End Get
        Set(ByVal value As String)
            _Division = value
        End Set
    End Property

    Private _RawMaterial As String
    Public Property RawMaterial() As String
        Get
            Return _RawMaterial
        End Get
        Set(ByVal value As String)
            _RawMaterial = value
        End Set
    End Property

    Private _QtyEstate As Decimal
    Public Property QtyEstate() As Decimal
        Get
            Return _QtyEstate
        End Get
        Set(ByVal value As Decimal)
            _QtyEstate = value
        End Set
    End Property

    Private _QtyFactory As Decimal
    Public Property QtyFactory() As Decimal
        Get
            Return _QtyFactory
        End Get
        Set(ByVal value As Decimal)
            _QtyFactory = value
        End Set
    End Property

    Private _Drc1 As Decimal
    Public Property Drc1() As Decimal
        Get
            Return _Drc1
        End Get
        Set(ByVal value As Decimal)
            _Drc1 = value
        End Set
    End Property

    Private _Drc2 As Decimal
    Public Property Drc2() As Decimal
        Get
            Return _Drc2
        End Get
        Set(ByVal value As Decimal)
            _Drc2 = value
        End Set
    End Property

    Private _Drc3 As Decimal
    Public Property Drc3() As Decimal
        Get
            Return _Drc3
        End Get
        Set(ByVal value As Decimal)
            _Drc3 = value
        End Set
    End Property

    Private _DrcCar As Decimal
    Public Property DrcCar() As Decimal
        Get
            Return _DrcCar
        End Get
        Set(ByVal value As Decimal)
            _DrcCar = value
        End Set
    End Property

    Private _Nh31 As Decimal
    Public Property Nh31() As Decimal
        Get
            Return _Nh31
        End Get
        Set(ByVal value As Decimal)
            _Nh31 = value
        End Set
    End Property

    Private _Nh32 As Decimal
    Public Property Nh32() As Decimal
        Get
            Return _Nh32
        End Get
        Set(ByVal value As Decimal)
            _Nh32 = value
        End Set
    End Property

    Private _Nh33 As Decimal
    Public Property Nh33() As Decimal
        Get
            Return _Nh33
        End Get
        Set(ByVal value As Decimal)
            _Nh33 = value
        End Set
    End Property

    Private _Nh3Car As Decimal
    Public Property Nh3Car() As Decimal
        Get
            Return _Nh3Car
        End Get
        Set(ByVal value As Decimal)
            _Nh3Car = value
        End Set
    End Property

    Private _Nh3Estate As Decimal
    Public Property Nh3Estate() As Decimal
        Get
            Return _Nh3Estate
        End Get
        Set(ByVal value As Decimal)
            _Nh3Estate = value
        End Set
    End Property

    Private _DrcEstate As Decimal
    Public Property DrcEstate() As Decimal
        Get
            Return _DrcEstate
        End Get
        Set(ByVal value As Decimal)
            _DrcEstate = value
        End Set
    End Property

    Private _VfaNo As Decimal
    Public Property VfaNo() As Decimal
        Get
            Return _VfaNo
        End Get
        Set(ByVal value As Decimal)
            _VfaNo = value
        End Set
    End Property

    Private _Dirt As Decimal
    Public Property Dirt() As Decimal
        Get
            Return _Dirt
        End Get
        Set(ByVal value As Decimal)
            _Dirt = value
        End Set
    End Property

    Private _Ash As Decimal
    Public Property Ash() As Decimal
        Get
            Return _Ash
        End Get
        Set(ByVal value As Decimal)
            _Ash = value
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
