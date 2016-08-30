Public Class RainFallRiverPPT
#Region "Private Member Declarations"
    Private _RDate As Date
    Private _RTime As String
    Private _Rain As Double = 0.0
    Private _RiverLevel As Double = 0.0
    Private _RainRiverId As String = String.Empty
#End Region
#Region "Public Member Declarations"
   
    Public Property RDate() As Date
        Get
            Return _RDate
        End Get
        Set(ByVal value As Date)
            _RDate = value
        End Set
    End Property
    Public Property Rain() As Double
        Get
            Return _Rain
        End Get
        Set(ByVal value As Double)
            _Rain = value
        End Set
    End Property
    Public Property RainRiverId() As String
        Get
            Return _RainRiverId
        End Get
        Set(ByVal value As String)
            _RainRiverId = value
        End Set
    End Property
    Public Property RTime() As String
        Get
            Return _RTime
        End Get
        Set(ByVal value As String)
            _RTime = value
        End Set
    End Property
    Public Property RiverLevel() As Double
        Get
            Return _RiverLevel
        End Get
        Set(ByVal value As Double)
            _RiverLevel = value
        End Set
    End Property
#End Region

End Class
