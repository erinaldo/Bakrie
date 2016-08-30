Public Class ProductionBrownCreepPPT
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

    Private _Assistant As String
    Public Property Assistant() As String
        Get
            Return _Assistant
        End Get
        Set(ByVal value As String)
            _Assistant = value
        End Set
    End Property


    Private _StartTime As String
    Public Property StartTime() As String
        Get
            Return _StartTime
        End Get
        Set(ByVal value As String)
            _StartTime = value
        End Set
    End Property


    Private _EndTime As String
    Public Property EndTime() As String
        Get
            Return _EndTime
        End Get
        Set(ByVal value As String)
            _EndTime = value
        End Set
    End Property

    Private _BreakdownTime As String
    Public Property BreakdownTime() As String
        Get
            Return _BreakdownTime
        End Get
        Set(ByVal value As String)
            _BreakdownTime = value
        End Set
    End Property

    Private _ShiftHours As String
    Public Property ShiftHours() As String
        Get
            Return _ShiftHours
        End Get
        Set(ByVal value As String)
            _ShiftHours = value
        End Set
    End Property

    Private _ProductType As String
    Public Property ProductType() As String
        Get
            Return _ProductType
        End Get
        Set(ByVal value As String)
            _ProductType = value
        End Set
    End Property

    Private _SkimLatex As Decimal
    Public Property SkimLatex() As Decimal
        Get
            Return _SkimLatex
        End Get
        Set(ByVal value As Decimal)
            _SkimLatex = value
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

    Private _Storage As String
    Public Property Storage() As String
        Get
            Return _Storage
        End Get
        Set(ByVal value As String)
            _Storage = value
        End Set
    End Property

    Private _Washing As Decimal
    Public Property Washing() As Decimal
        Get
            Return _Washing
        End Get
        Set(ByVal value As Decimal)
            _Washing = value
        End Set
    End Property

End Class
