Public Class DailyGangEmployeeSetupPPT
    Private _DDAte As DateTime
    Private _DailyTeamActivityID As String = String.Empty
    Private _GangEmployeeID As String = String.Empty
    Private _GangMasterID As String = String.Empty
    Private _EmpID As String = String.Empty

    Public Property DDate() As DateTime
        Get
            Return _DDAte
        End Get
        Set(value As DateTime)
            _DDAte = value
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
    Public Property GangEmployeeID() As String
        Get
            Return _GangEmployeeID
        End Get
        Set(value As String)
            _GangEmployeeID = value
        End Set
    End Property
    Public Property GangMasterID() As String
        Get
            Return _GangMasterID
        End Get
        Set(value As String)
            _GangMasterID = value
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

End Class
