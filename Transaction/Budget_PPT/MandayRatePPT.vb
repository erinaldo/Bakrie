Public Class MandayRatePPT
#Region "Private Member Declarations"
    Private _MandayRateID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _BudgetYear As Integer
    Private _PlantationCurrentUMPS As Decimal
    Private _LocalWageCurrentUMPS As Decimal
    Private _Percentage As Decimal
    Private _PlantationAssGovtIncrease As Decimal
    Private _LocalAssGovtIncrease As Decimal
    Private _PlantationNetCash As Decimal
    Private _LocalNetCash As Decimal
    Private _PlantationDifferential As Decimal
    Private _LocalDifferential As Decimal
    Private _PlantationIncreasePerDec As Decimal
    Private _LocalIncreasePerDec As Decimal

#End Region

#Region "Public Member Declarations"
    Public Property MandayRateID() As String
        Get
            Return _MandayRateID
        End Get
        Set(ByVal value As String)
            _MandayRateID = value
        End Set
    End Property

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
    Public Property PlantationCurrentUMPS() As Decimal
        Get
            Return _PlantationCurrentUMPS
        End Get
        Set(ByVal value As Decimal)
            _PlantationCurrentUMPS = value
        End Set
    End Property
    Public Property LocalWageCurrentUMPS() As Decimal
        Get
            Return _LocalWageCurrentUMPS
        End Get
        Set(ByVal value As Decimal)
            _LocalWageCurrentUMPS = value

        End Set
    End Property
    Public Property Percentage() As Decimal
        Get
            Return _Percentage
        End Get
        Set(ByVal value As Decimal)
            _Percentage = value
        End Set
    End Property
    Public Property PlantationAssGovtIncrease() As Decimal
        Get
            Return _PlantationAssGovtIncrease
        End Get
        Set(ByVal value As Decimal)
            _PlantationAssGovtIncrease = value
        End Set
    End Property
    Public Property LocalAssGovtIncrease() As Decimal
        Get
            Return _LocalAssGovtIncrease
        End Get
        Set(ByVal value As Decimal)
            _LocalAssGovtIncrease = value
        End Set
    End Property
    Public Property PlantationNetCash() As Decimal
        Get
            Return _PlantationNetCash
        End Get
        Set(ByVal value As Decimal)
            _PlantationNetCash = value
        End Set
    End Property
    Public Property LocalNetCash() As Decimal
        Get
            Return _LocalNetCash
        End Get
        Set(ByVal value As Decimal)
            _LocalNetCash = value
        End Set
    End Property
    Public Property PlantationDifferential() As Decimal
        Get
            Return _PlantationDifferential
        End Get
        Set(ByVal value As Decimal)
            _PlantationDifferential = value
        End Set
    End Property
    Public Property LocalDifferential() As Decimal
        Get
            Return _LocalDifferential
        End Get
        Set(ByVal value As Decimal)
            _LocalDifferential = value
        End Set
    End Property
    Public Property PlantationIncreasePerDec() As Decimal
        Get
            Return _PlantationIncreasePerDec
        End Get
        Set(ByVal value As Decimal)
            _PlantationIncreasePerDec = value
        End Set
    End Property
    Public Property LocalIncreasePerDec() As Decimal
        Get
            Return _LocalIncreasePerDec
        End Get
        Set(ByVal value As Decimal)
            _LocalIncreasePerDec = value
        End Set
    End Property
#End Region

End Class
