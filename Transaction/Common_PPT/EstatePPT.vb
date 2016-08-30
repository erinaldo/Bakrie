Public Class EstatePPT
    Private _EstateID As String
    Private _EstateCode As String
    Private _EstateName As String
    Private _Address As String
    Private _TelephoneNumber As String
    Private _Type As String
    Private _ConcurrencyID As Long
    Private _TotalArea As Decimal
    Private _PlantedArea As Decimal
    Private _Descp As String
    Private _CreatedBy As String
    Private _CreatedOn As Date
    Private _ModifiedBy As String
    Private _ModifiedOn As Date
    Private _Ayear As Integer
    Private _Amonth As Integer
    Private _EstateIDCode As String
    Private _EstatecodeName As String
    Private _EstateAbbreviation As String



    Public Property EstateID() As String
        Get
            Return _EstateID
        End Get
        Set(ByVal value As String)
            _EstateID = value
        End Set
    End Property

    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
        End Set
    End Property

    Public Property EstateName() As String
        Get
            Return _EstateName
        End Get
        Set(ByVal value As String)
            _EstateName = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Public Property TelephoneNumber() As String
        Get
            Return _TelephoneNumber
        End Get
        Set(ByVal value As String)
            _TelephoneNumber = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property


    Public Property ConcurrencyID() As Long
        Get
            Return _ConcurrencyID
        End Get
        Set(ByVal value As Long)
            _ConcurrencyID = value
        End Set
    End Property

    Public Property TotalArea() As Decimal
        Get
            Return _TotalArea
        End Get
        Set(ByVal value As Decimal)
            _TotalArea = value
        End Set
    End Property

    Public Property PlantedArea() As Decimal
        Get
            Return _PlantedArea
        End Get
        Set(ByVal value As Decimal)
            _PlantedArea = value
        End Set
    End Property
    Public Property Descp() As String
        Get
            Return _Descp
        End Get
        Set(ByVal value As String)
            _Descp = value
        End Set
    End Property
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property
    Public Property CreatedOn() As Date
        Get
            Return _CreatedOn
        End Get
        Set(ByVal value As Date)
            _CreatedOn = value
        End Set
    End Property
    Public Property ModifiedBy() As String
        Get
            Return _ModifiedBy
        End Get
        Set(ByVal value As String)
            _ModifiedBy = value
        End Set
    End Property
    Public Property ModifiedOn() As Date
        Get
            Return _ModifiedOn
        End Get
        Set(ByVal value As Date)
            _ModifiedOn = value
        End Set
    End Property
    Public Property Ayear() As Integer
        Get
            Return _Ayear
        End Get
        Set(ByVal value As Integer)
            _Ayear = value
        End Set
    End Property
    Public Property AMonth() As Integer
        Get
            Return _AMonth
        End Get
        Set(ByVal value As Integer)
            _AMonth = value
        End Set
    End Property

    Public Property EstateIDCode() As String
        Get
            Return _EstateIDCode
        End Get
        Set(ByVal value As String)
            _EstateIDCode = value
        End Set
    End Property
    Public Property EstatecodeName() As String
        Get
            Return _EstatecodeName
        End Get
        Set(ByVal value As String)
            _EstatecodeName = value
        End Set
    End Property

    Public Property EstateAbbreviation() As String
        Get
            Return _EstateAbbreviation
        End Get
        Set(ByVal value As String)
            _EstateAbbreviation = value
        End Set
    End Property


End Class
