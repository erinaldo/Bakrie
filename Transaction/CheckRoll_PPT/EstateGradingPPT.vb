Public Class EstateGradingPPT
    Private _Month As DateTime = DateTime.Now
    Private _Estate As String = String.Empty
    Private _Afdeling As String = String.Empty
    Private _Mandor As String = String.Empty
    Private _GangTeam As String = String.Empty
    Private _FieldNo As String = String.Empty
    Private _Gred As String = String.Empty
    Public Property Month() As DateTime
        Get
            Return _Month
        End Get
        Set(value As DateTime)
            _Month = value
        End Set
    End Property
    Public Property Estate() As String
        Get
            Return _Estate
        End Get
        Set(value As String)
            _Estate = value
        End Set
    End Property
    Public Property Afdeling() As String
        Get
            Return _Afdeling
        End Get
        Set(value As String)
            _Afdeling = value
        End Set
    End Property
    Public Property Mandor() As String
        Get
            Return _Mandor
        End Get
        Set(value As String)
            _Mandor = value
        End Set
    End Property
    Public Property GangTeam() As String
        Get
            Return _GangTeam
        End Get
        Set(value As String)
            _GangTeam = value
        End Set
    End Property
    Public Property FieldNo() As String
        Get
            Return _FieldNo
        End Get
        Set(value As String)
            _FieldNo = value
        End Set
    End Property
    Public Property Gred() As String
        Get
            Return _Gred
        End Get
        Set(value As String)
            _Gred = value
        End Set
    End Property
End Class
