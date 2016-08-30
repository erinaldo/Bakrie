Public Class RicePPT

#Region "Private Member Declaration"
    Private _EstateID As String = String.Empty
    Private _BudgetYear As Integer
    Private _RiceMainID As Double
    Private _RiceID As Double
    Private _MS As String = String.Empty
    Private _Kgs As Double
    Private _Percentage As Double
    Private _Total As Double

    'Rice Main Table
    Private _RiceAt As Double
    Private _RiceFinal As Double
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

    Public Property RiceMainID() As Double
        Get
            Return _RiceMainID
        End Get
        Set(ByVal value As Double)
            _RiceMainID = value
        End Set
    End Property
    Public Property RiceID() As Double
        Get
            Return _RiceID
        End Get
        Set(ByVal value As Double)
            _RiceID = value
        End Set
    End Property
    Public Property MS() As String
        Get
            Return _MS
        End Get
        Set(ByVal value As String)
            _MS = value
        End Set
    End Property
    Public Property Kgs() As Double
        Get
            Return _Kgs
        End Get
        Set(ByVal value As Double)
            _Kgs = value
        End Set
    End Property
    Public Property Percentage() As Double
        Get
            Return _Percentage

        End Get
        Set(ByVal value As Double)
            _Percentage = value
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property
    Public Property RiceAt() As Double
        Get
            Return _RiceAt
        End Get
        Set(ByVal value As Double)
            _RiceAt = value
        End Set
    End Property
    Public Property RiceFinal() As Double
        Get
            Return _RiceFinal
        End Get
        Set(ByVal value As Double)
            _RiceFinal = value
        End Set
    End Property
#End Region

End Class
