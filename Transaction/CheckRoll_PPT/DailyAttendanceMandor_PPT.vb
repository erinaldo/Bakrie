Public Class DailyAttendanceMandor_PPT
    Private _RDate As DateTime
    Private _NIK As String = String.Empty
    Private _AttID As String = String.Empty
    Private _DailyOT As Double = 0
    Private _KraniPremiKg As Double = 0
    Private _FieldNo As String = String.Empty
    Private _TPHNo As String = String.Empty

    Public Property RDate() As DateTime
        Get
            Return _RDate
        End Get
        Set(value As DateTime)
            _RDate = value
        End Set
    End Property

    Public Property NIK() As String
        Get
            Return _NIK
        End Get
        Set(value As String)
            _NIK = value
        End Set
    End Property

    Public Property AttID() As String
        Get
            Return _AttID
        End Get
        Set(value As String)
            _AttID = value
        End Set
    End Property

    Public Property DailyOT() As Double
        Get
            Return _DailyOT
        End Get
        Set(value As Double)
            _DailyOT = value
        End Set
    End Property


    Public Property KraniPremiKg() As Double
        Get
            Return _KraniPremiKg
        End Get
        Set(value As Double)
            _KraniPremiKg = value
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

    Public Property TPHNo() As String
        Get
            Return _TPHNo
        End Get
        Set(value As String)
            _TPHNo = value
        End Set
    End Property
End Class
