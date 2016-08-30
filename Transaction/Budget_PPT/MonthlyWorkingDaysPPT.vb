Public Class MonthlyWorkingDaysPPT
#Region "Private Member Declaration"
    Private _EstateID As String = String.Empty
    Private _BudgetYear As Integer
    Private _Month As Integer
    Private _Days As Integer
    Private _Sundays As Integer
    Private _PH As Integer
#End Region

#Region "Public Member Declaration"
    Public Property EstateId() As String
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
    Public Property Month() As String
        Get
            Return _Month
        End Get
        Set(ByVal value As String)
            _Month = value
        End Set
    End Property
    Public Property Days() As String
        Get
            Return _Days
        End Get
        Set(ByVal value As String)
            _Days = value
        End Set
    End Property
    Public Property Sundays() As String
        Get
            Return _Sundays
        End Get
        Set(ByVal value As String)
            _Sundays = value
        End Set
    End Property
    Public Property PH() As String
        Get
            Return _PH
        End Get
        Set(ByVal value As String)
            _PH = value
        End Set
    End Property
#End Region
End Class
