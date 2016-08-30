Public Class DispatchPPT

#Region "Private Properties"

    Private _DispatchID As String = String.Empty
    Private _ProductID As String = String.Empty
    Private _DispatchDate As Date
    Private _lDispatchDate As String
    Private _BAPNo As String = String.Empty
    Private _ShipPontoon As String = String.Empty
    Private _DOA As Date
    Private _DOAtime As String
    Private _DOL As Date
    Private _DOLtime As String
    Private _DCL As Date
    Private _DCLtime As String
    Private _DepatureDate As Date
    Private _DepatureTime As String
    Private _MillWeight As Decimal
    Private _LoadingLocationID As String = String.Empty
    Private _DispatchDetailID As String = String.Empty
    Private _Position As Integer
    Private _FFAP As Decimal
    Private _MoistureP As Decimal
    Private _DirtP As Decimal
    Private _BrokenKernel As Decimal
    Private _Temp As Decimal
    Private _BuyerName As String
    Private _KontrakNo As String
    Private _NoPenyerahan As String
    Private _NoInstruksi As String
    Private _JumlahKontrak As Double
    Private _NoSim As String
    Private _NoTruk As String
    Private _SealNo As String
    Private _DriverName As String
    Private _TransporterNo As String
    Private _SPBNo As String
    Private _TermofSales As String

#End Region

#Region "Public Properties"





    Public Property DispatchID() As String
        Get
            Return _DispatchID
        End Get
        Set(ByVal value As String)
            _DispatchID = value
        End Set
    End Property

    Public Property ProductID() As String
        Get
            Return _ProductID
        End Get
        Set(ByVal value As String)
            _ProductID = value
        End Set
    End Property

    Public Property DispatchDate() As Date
        Get
            Return _DispatchDate
        End Get
        Set(ByVal value As Date)
            _DispatchDate = value
        End Set
    End Property
    Public Property lDispatchDate() As String
        Get
            Return _lDispatchDate
        End Get
        Set(ByVal value As String)
            _lDispatchDate = value
        End Set
    End Property
    Public Property BAPNo() As String
        Get
            Return _BAPNo
        End Get
        Set(ByVal value As String)
            _BAPNo = value
        End Set
    End Property

    Public Property ShipPontoon() As String
        Get
            Return _ShipPontoon
        End Get
        Set(ByVal value As String)
            _ShipPontoon = value
        End Set
    End Property

    Public Property DOA() As Date
        Get
            Return _DOA
        End Get
        Set(ByVal value As Date)
            _DOA = value
        End Set
    End Property
    Public Property DOATime() As String
        Get
            Return _DOAtime
        End Get
        Set(ByVal value As String)
            _DOAtime = value
        End Set
    End Property

    Public Property DOL() As Date
        Get
            Return _DOL
        End Get
        Set(ByVal value As Date)
            _DOL = value
        End Set
    End Property
    Public Property DOLTime() As String
        Get
            Return _DOLtime
        End Get
        Set(ByVal value As String)
            _DOLtime = value
        End Set
    End Property

    Public Property DCL() As Date
        Get
            Return _DCL
        End Get
        Set(ByVal value As Date)
            _DCL = value
        End Set
    End Property
    Public Property DCLTime() As String
        Get
            Return _DCLtime
        End Get
        Set(ByVal value As String)
            _DCLtime = value
        End Set
    End Property
    Public Property DepatureDate() As Date
        Get
            Return _DepatureDate
        End Get
        Set(ByVal value As Date)
            _DepatureDate = value
        End Set
    End Property
    Public Property Depaturetime() As String
        Get
            Return _DepatureTime
        End Get
        Set(ByVal value As String)
            _DepatureTime = value
        End Set
    End Property
    Public Property LoadingLocationID() As String
        Get
            Return _LoadingLocationID
        End Get
        Set(ByVal value As String)
            _LoadingLocationID = value
        End Set
    End Property

    Public Property DispatchDetailID() As String
        Get
            Return _DispatchDetailID
        End Get
        Set(ByVal value As String)
            _DispatchDetailID = value
        End Set
    End Property

    Public Property Position() As Decimal
        Get
            Return _Position
        End Get
        Set(ByVal value As Decimal)
            _Position = value
        End Set
    End Property

    Public Property MillWeight() As Decimal
        Get
            Return _MillWeight
        End Get
        Set(ByVal value As Decimal)
            _MillWeight = value
        End Set
    End Property
    Public Property FFAP() As Decimal
        Get
            Return _FFAP
        End Get
        Set(ByVal value As Decimal)
            _FFAP = value
        End Set
    End Property
    Public Property MoistureP() As Decimal
        Get
            Return _MoistureP
        End Get
        Set(ByVal value As Decimal)
            _MoistureP = value
        End Set
    End Property
    Public Property DirtP() As Decimal
        Get
            Return _DirtP
        End Get
        Set(ByVal value As Decimal)
            _DirtP = value
        End Set
    End Property
    Public Property BrokenKernel() As Decimal
        Get
            Return _BrokenKernel
        End Get
        Set(ByVal value As Decimal)
            _BrokenKernel = value
        End Set
    End Property
    Public Property Temp() As Decimal
        Get
            Return _Temp
        End Get
        Set(ByVal value As Decimal)
            _Temp = value
        End Set
    End Property

    Public Property BuyerName() As String
        Get
            Return _BuyerName
        End Get
        Set(ByVal value As String)
            _BuyerName = value
        End Set
    End Property

    Public Property KontrakNo() As String
        Get
            Return _KontrakNo
        End Get
        Set(ByVal value As String)
            _KontrakNo = value
        End Set
    End Property
    Public Property NoPenyerahan() As String
        Get
            Return _NoPenyerahan
        End Get
        Set(ByVal value As String)
            _NoPenyerahan = value
        End Set
    End Property

    Public Property NoInstruksi() As String
        Get
            Return _NoInstruksi
        End Get
        Set(ByVal value As String)
            _NoInstruksi = value
        End Set
    End Property

    Public Property JumlahKontrak() As Double
        Get
            Return _JumlahKontrak
        End Get
        Set(ByVal value As Double)
            _JumlahKontrak = value
        End Set
    End Property

    Public Property NoSim() As String
        Get
            Return _NoSim
        End Get
        Set(ByVal value As String)
            _NoSim = value
        End Set
    End Property
    Public Property NoTruk() As String
        Get
            Return _NoTruk
        End Get
        Set(ByVal value As String)
            _NoTruk = value
        End Set
    End Property

    Public Property SealNo() As String
        Get
            Return _SealNo
        End Get
        Set(ByVal value As String)
            _SealNo = value
        End Set
    End Property

    Public Property DriverName() As String
        Get
            Return _DriverName
        End Get
        Set(ByVal value As String)
            _DriverName = value
        End Set
    End Property
    Public Property TransporterNo() As String
        Get
            Return _TransporterNo
        End Get
        Set(ByVal value As String)
            _TransporterNo = value

        End Set
    End Property
    Public Property SPBNo() As String
        Get
            Return _SPBNo
        End Get
        Set(ByVal value As String)
            _SPBNo = value
        End Set
    End Property
    Public Property TermofSales() As String
        Get
            Return _TermofSales
        End Get
        Set(ByVal value As String)
            _TermofSales = value
        End Set
    End Property

#End Region
End Class
