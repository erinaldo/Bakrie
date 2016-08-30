Public Class TeamEmployeeSetup_PPT
    
    Private _GangMasterID As String = String.Empty
    Private _EmpID As String = String.Empty
    Private _MandorBesarID As String = String.Empty
    Private _MandorID As String = String.Empty
    Private _KraniID As String = String.Empty
    Private _DailyDate As DateTime
    Private _DailyTeamActivityID As String = String.Empty

    Public Property GangMasterID() As String
        Get
            Return _GangMasterID
        End Get
        Set(value As String)
            _GangMasterID = value
        End Set
    End Property

    Public Property DailyTeamActivityID() As String
        Get
            Return _DailyTeamActivityID
        End Get
        Set(value As String)
            _DailyTeamActivityID = value
        End Set
    End Property

    Public Property EmpID() As String
        Get
            Return _EmpID
        End Get
        Set(value As String)
            _EmpID = value
        End Set
    End Property

    Public Property MandorBesarID() As String
        Get
            Return _MandorBesarID
        End Get
        Set(value As String)
            _MandorBesarID = value
        End Set
    End Property

    Public Property MandorID() As String
        Get
            Return _MandorID
        End Get
        Set(value As String)
            _MandorID = value
        End Set
    End Property

    Public Property KraniID() As String
        Get
            Return _KraniID
        End Get
        Set(value As String)
            _KraniID = value
        End Set
    End Property

    Public Property DailyDate() As DateTime
        Get
            Return _DailyDate
        End Get
        Set(value As DateTime)
            _DailyDate = value
        End Set
    End Property
End Class
