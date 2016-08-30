Public Class ClassPenderesPPT
    Private _ZYear As Integer
    Private _ZMonth As Integer
    Private _TotalBudget As Decimal

    Public Property ZYear() As Integer
        Get
            Return _ZYear
        End Get
        Set(value As Integer)
            _ZYear = value
        End Set
    End Property
    Public Property ZMonth() As Integer
        Get
            Return _ZMonth
        End Get
        Set(value As Integer)
            _ZMonth = value
        End Set
    End Property
    Public Property TotalBudget() As Decimal
        Get
            Return _TotalBudget
        End Get
        Set(value As Decimal)
            _TotalBudget = value
        End Set
    End Property
End Class