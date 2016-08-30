Public Class YearlyWorkingDaysPPT
#Region "Private Member Declarations"
    Private _EstateID As String = String.Empty
    Private _BudgetYear As Integer
    Private _Days As Integer
    Private _Sundays As Integer
    Private _PH As Integer
    Private _AL As Integer
    Private _SaL As Integer
    Private _SL As Integer
    Private _Month As Integer
    Private _RaindaysPerMonth As Integer
    Private _RainDays As Integer
    Private _TotalDays As Integer
#End Region

#Region "Public Member Declaration"
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
    Public Property Days() As Integer
        Get
            Return _Days
        End Get
        Set(ByVal value As Integer)
            _Days = value
        End Set
    End Property
    Public Property Sundays() As Integer
        Get
            Return _Sundays

        End Get
        Set(ByVal value As Integer)
            _Sundays = value
        End Set
    End Property
    Public Property PH() As Integer
        Get
            Return _PH
        End Get
        Set(ByVal value As Integer)
            _PH = value
        End Set
    End Property
    Public Property AL() As Integer
        Get
            Return _AL
        End Get
        Set(ByVal value As Integer)
            _AL = value
        End Set
    End Property
    Public Property SaL() As Integer
        Get
            Return _SaL
        End Get
        Set(ByVal value As Integer)
            _SaL = value
        End Set
    End Property
    Public Property SL() As Integer
        Get
            Return _SL
        End Get
        Set(ByVal value As Integer)
            _SL = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return _Month
        End Get
        Set(ByVal value As String)
            _Month = value
        End Set
    End Property

    Public Property RaindaysPerMonth() As Integer
        Get
            Return _RaindaysPerMonth
        End Get
        Set(ByVal value As Integer)
            _RaindaysPerMonth = value
        End Set
    End Property

    Public Property RainDays() As Integer
        Get
            Return _RainDays
        End Get
        Set(ByVal value As Integer)
            _RainDays = value
        End Set
    End Property
    Public Property TotalDays() As Integer
        Get
            Return _TotalDays
        End Get
        Set(ByVal value As Integer)
            _TotalDays = value
        End Set
    End Property
#End Region
End Class
