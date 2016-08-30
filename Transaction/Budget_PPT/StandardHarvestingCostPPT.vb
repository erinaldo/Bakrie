Public Class StandardHarvestingCostPPT
#Region "Private Member Declarations"
    Private _StandardHarvestingID As String
    Private _EstateID As String
    Private _EstateCode As String
    Private _BudgetYear As Integer
    Private _Period As String
    Private _YOPID As String
    Private _YOP As String
    Private _NoofBunches As Double
    Private _NoOfHarvesterDays As Double
    Private _CropInTon As Double
    Private _LooseFruitPercent As Double
    Private _LooseFruitTon As Double
    Private _NoOfHarvester As Double
    Private _HavesterPerHectrage As Double
    Private _AvgNoBunchesPerDay As Double
    Private _Hectarage As Double
    Private _AvgBunchWeight As Double
    Private _BunchWeight As Double
    Private _NormalDaysBase As Double
    Private _NormalDaysPremi As Double
    Private _PremiumDaysPremi As Double
    Private _LooseFruitKg As Double
    Private _LooseFruitPremiIDR As Double
    Private _TotalPay As Double
#End Region
#Region "Public Member Declarations"
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property

    Public Property StandardHarvestingID() As String
        Get
            Return _StandardHarvestingID
        End Get
        Set(ByVal value As String)
            _StandardHarvestingID = value
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
    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
        End Set
    End Property


    Public Property Period() As String
        Get
            Return _Period
        End Get
        Set(ByVal value As String)
            _Period = value
        End Set
    End Property
    Public Property YOPID() As String
        Get
            Return _YOPID
        End Get
        Set(ByVal value As String)
            _YOPID = value
        End Set
    End Property
    Public Property YOP() As String
        Get
            Return _YOP
        End Get
        Set(ByVal value As String)
            _YOP = value
        End Set
    End Property
    Public Property NoofBunches() As Double
        Get
            Return _NoofBunches
        End Get
        Set(ByVal value As Double)
            _NoofBunches = value
        End Set
    End Property

    Public Property NoOfHarvesterDays() As Double
        Get
            Return _NoOfHarvesterDays
        End Get
        Set(ByVal value As Double)
            _NoOfHarvesterDays = value
        End Set
    End Property
    Public Property CropInTon() As Double
        Get
            Return _CropInTon
        End Get
        Set(ByVal value As Double)
            _CropInTon = value
        End Set
    End Property
    Public Property LooseFruitPercent() As Double
        Get
            Return _LooseFruitPercent
        End Get
        Set(ByVal value As Double)
            _LooseFruitPercent = value
        End Set
    End Property
    Public Property LooseFruitTon() As Double
        Get
            Return _LooseFruitTon
        End Get
        Set(ByVal value As Double)
            _LooseFruitTon = value
        End Set
    End Property
    Public Property NoOfHarvester() As Double
        Get
            Return _NoOfHarvester
        End Get
        Set(ByVal value As Double)
            _NoOfHarvester = value
        End Set
    End Property
    Public Property HavesterPerHectrage() As Double
        Get
            Return _HavesterPerHectrage
        End Get
        Set(ByVal value As Double)
            _HavesterPerHectrage = value
        End Set
    End Property
    Public Property AvgNoBunchesPerDay() As Double
        Get
            Return _AvgNoBunchesPerDay
        End Get
        Set(ByVal value As Double)
            _AvgNoBunchesPerDay = value
        End Set
    End Property
    Public Property Hectarage() As Double
        Get
            Return _Hectarage
        End Get
        Set(ByVal value As Double)
            _Hectarage = value
        End Set
    End Property
    Public Property AvgBunchWeight() As Double
        Get
            Return _AvgBunchWeight
        End Get
        Set(ByVal value As Double)
            _AvgBunchWeight = value
        End Set
    End Property
   
    Public Property BunchWeight() As Double
        Get
            Return _BunchWeight
        End Get
        Set(ByVal value As Double)
            _BunchWeight = value
        End Set
    End Property
    Public Property NormalDaysBase() As Double
        Get
            Return _NormalDaysBase
        End Get
        Set(ByVal value As Double)
            _NormalDaysBase = value
        End Set
    End Property
    Public Property NormalDaysPremi() As Double
        Get
            Return _NormalDaysPremi
        End Get
        Set(ByVal value As Double)
            _NormalDaysPremi = value
        End Set
    End Property
    Public Property PremiumDaysPremi() As Double
        Get
            Return _PremiumDaysPremi
        End Get
        Set(ByVal value As Double)
            _PremiumDaysPremi = value
        End Set
    End Property
    Public Property LooseFruitKg() As Double
        Get
            Return _LooseFruitKg
        End Get
        Set(ByVal value As Double)
            _LooseFruitKg = value
        End Set
    End Property
    Public Property LooseFruitPremiIDR() As Double
        Get
            Return _LooseFruitPremiIDR
        End Get
        Set(ByVal value As Double)
            _LooseFruitPremiIDR = value
        End Set
    End Property
    Public Property TotalPay() As Double
        Get
            Return _TotalPay
        End Get
        Set(ByVal value As Double)
            _TotalPay = value
        End Set
    End Property







#End Region
End Class
