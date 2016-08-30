Public Class DailyReceptionForRubberPPT
    Private _NIK As String = String.Empty
    Private _DailyReceiptionID As String = String.Empty
    Private _Name As String = String.Empty
    Private _AttCode As String = String.Empty
    Private _Location As String = String.Empty
    Private _OTHour As String = String.Empty
    Private _Afdeling As String = String.Empty
    Private _YOP As String = String.Empty
    Private _Block As String = String.Empty
    Private _TPH As String = String.Empty
    Private _Latex As String = String.Empty
    Private _CupLamp As String = String.Empty
    Private _TreeLace As String = String.Empty
    Private _Coaglum As String = String.Empty
    Private _DRC As String = String.Empty
    Private _DRCCuplump As String = String.Empty
    Private _DRCTreelace As String = String.Empty
    Private _DRCCoaglum As String = String.Empty
    Private _Date As DateTime = DateTime.Now()

    Public Property DailyReceiptionID() As String
        Get
            Return _DailyReceiptionID
        End Get
        Set(value As String)
            _DailyReceiptionID = value
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

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property OTHour() As String
        Get
            Return _OTHour
        End Get
        Set(value As String)
            _OTHour = value
        End Set
    End Property

    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(value As String)
            _Location = value
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

    Public Property YOP() As String
        Get
            Return _YOP
        End Get
        Set(value As String)
            _YOP = value
        End Set
    End Property

    Public Property Block() As String
        Get
            Return _Block
        End Get
        Set(value As String)
            _Block = value
        End Set
    End Property

    Public Property TPH() As String
        Get
            Return _TPH
        End Get
        Set(value As String)
            _TPH = value
        End Set
    End Property

    Public Property Latex() As String
        Get
            Return _Latex
        End Get
        Set(value As String)
            _Latex = value
        End Set
    End Property

    Public Property CupLamp() As String
        Get
            Return _CupLamp
        End Get
        Set(value As String)
            _CupLamp = value
        End Set
    End Property

    Public Property TreeLace() As String
        Get
            Return _TreeLace
        End Get
        Set(value As String)
            _TreeLace = value
        End Set
    End Property

    Public Property Coaglum() As String
        Get
            Return _Coaglum
        End Get
        Set(value As String)
            _Coaglum = value
        End Set
    End Property

    Public Property DRC() As String
        Get
            Return _DRC
        End Get
        Set(value As String)
            _DRC = value
        End Set
    End Property

    Public Property DRCCuplump() As String
        Get
            Return _DRCCuplump
        End Get
        Set(value As String)
            _DRCCuplump = value
        End Set
    End Property

    Public Property DRCTreelace() As String
        Get
            Return _DRCTreelace
        End Get
        Set(value As String)
            _DRCTreelace = value
        End Set
    End Property

    Public Property DRCCoaglum() As String
        Get
            Return _DRCCoaglum
        End Get
        Set(value As String)
            _DRCCoaglum = value
        End Set
    End Property

    Public Property AttCode() As String
        Get
            Return _AttCode
        End Get
        Set(value As String)
            _AttCode = value
        End Set
    End Property

    Public Property DateRubber() As DateTime
        Get
            Return _Date
        End Get
        Set(value As DateTime)
            _Date = value
        End Set
    End Property

    Public Property TeamId() As String

End Class
