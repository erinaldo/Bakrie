Public Class DailyRateStandardPPT
#Region "Private Member Declaration"
    Private _EstateID As String = String.Empty
    Private _BudgetYear As Integer

    Private _PlantationCurrentUMPS As Decimal
    Private _PlantationIncreasePerDec As Decimal

    Private _DailyWage As Decimal
    Private _IncreaseP As Decimal
    Private _YearlyWage As Decimal
    Private _MonthlyWage As Decimal
    Private _OTP As Decimal
    Private _OTPWage As Decimal
    Private _TotalCash As Decimal

    Private _AstekP As Decimal
    Private _AstekCash As Decimal
    Private _THRP As Decimal
    Private _THRCash As Decimal

    Private _RiceKgs As Decimal
    Private _RiceValue As Decimal
    Private _RiceCash As Decimal
    Private _OverallCost As Decimal
    Private _WorkingDays As Decimal
    Private _Costperday As Decimal
    Private _RoundedUp As Decimal
    Private _RoundedUSD As Decimal

    Private _PrevYearBudget As Decimal
    Private _PrevYearBudgetUSD As Decimal


    Private _IncDecBudget As Decimal
    Private _IncDecBudgetRpP As Decimal
    Private _IncDecBudgetuSD As Decimal


    Private _KeyValuePairs As Decimal
    Private _RiceCount As Decimal
    Private _ExcRateUStoRP As Decimal







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




    Public Property PlantationCurrentUMPS() As Decimal
        Get
            Return _PlantationCurrentUMPS
        End Get
        Set(ByVal value As Decimal)
            _PlantationCurrentUMPS = value
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






    Public Property DailyWage() As Decimal
        Get
            Return _DailyWage
        End Get
        Set(ByVal value As Decimal)
            _DailyWage = value
        End Set
    End Property


    Public Property IncreaseP() As Decimal
        Get
            Return _IncreaseP
        End Get
        Set(ByVal value As Decimal)
            _IncreaseP = value
        End Set
    End Property

    Public Property YearlyWage() As Decimal
        Get
            Return _YearlyWage
        End Get
        Set(ByVal value As Decimal)
            _YearlyWage = value
        End Set
    End Property

    Public Property MonthlyWage() As Decimal
        Get
            Return _MonthlyWage
        End Get
        Set(ByVal value As Decimal)
            _MonthlyWage = value
        End Set
    End Property

    Public Property OTP() As Decimal
        Get
            Return _OTP
        End Get
        Set(ByVal value As Decimal)
            _OTP = value
        End Set
    End Property

    Public Property OTPWage() As Decimal
        Get
            Return _OTPWage
        End Get
        Set(ByVal value As Decimal)
            _OTPWage = value
        End Set
    End Property

    Public Property TotalCash() As Decimal
        Get
            Return _TotalCash
        End Get
        Set(ByVal value As Decimal)
            _TotalCash = value
        End Set
    End Property

    Public Property AstekP() As Decimal
        Get
            Return _AstekP
        End Get
        Set(ByVal value As Decimal)
            _AstekP = value
        End Set
    End Property


    Public Property AstekCash() As Decimal
        Get
            Return _AstekCash
        End Get
        Set(ByVal value As Decimal)
            _AstekCash = value
        End Set
    End Property

    Public Property THRP() As Decimal
        Get
            Return _THRP
        End Get
        Set(ByVal value As Decimal)
            _THRP = value
        End Set
    End Property

    Public Property THRCash() As Decimal
        Get
            Return _THRCash
        End Get
        Set(ByVal value As Decimal)
            _THRCash = value
        End Set
    End Property


    Public Property RiceKgs() As Decimal
        Get
            Return _RiceKgs
        End Get
        Set(ByVal value As Decimal)
            _RiceKgs = value
        End Set
    End Property
    Public Property RiceValue() As Decimal
        Get
            Return _RiceValue
        End Get
        Set(ByVal value As Decimal)
            _RiceValue = value
        End Set
    End Property
    Public Property RiceCash() As Decimal
        Get
            Return _RiceCash
        End Get
        Set(ByVal value As Decimal)
            _RiceCash = value
        End Set
    End Property

    Public Property OverallCost() As Decimal
        Get
            Return _OverallCost
        End Get
        Set(ByVal value As Decimal)
            _OverallCost = value
        End Set
    End Property
    Public Property WorkingDays() As Decimal
        Get
            Return _WorkingDays
        End Get
        Set(ByVal value As Decimal)
            _WorkingDays = value
        End Set
    End Property
    Public Property Costperday() As Decimal
        Get
            Return _Costperday
        End Get
        Set(ByVal value As Decimal)
            _Costperday = value
        End Set
    End Property
    Public Property RoundedUp() As Decimal
        Get
            Return _RoundedUp
        End Get
        Set(ByVal value As Decimal)
            _RoundedUp = value
        End Set
    End Property
    Public Property RoundedUSD() As Decimal
        Get
            Return _RoundedUSD
        End Get
        Set(ByVal value As Decimal)
            _RoundedUSD = value
        End Set
    End Property
    Public Property PrevYearBudget() As Decimal
        Get
            Return _PrevYearBudget
        End Get
        Set(ByVal value As Decimal)
            _PrevYearBudget = value
        End Set
    End Property
    Public Property PrevYearBudgetUSD() As Decimal
        Get
            Return _PrevYearBudgetUSD
        End Get
        Set(ByVal value As Decimal)
            _PrevYearBudgetUSD = value
        End Set
    End Property
    Public Property IncDecBudget() As Decimal
        Get
            Return _IncDecBudget
        End Get
        Set(ByVal value As Decimal)
            _IncDecBudget = value
        End Set
    End Property

    Public Property IncDecBudgetRpP() As Decimal
        Get
            Return _IncDecBudgetRpP
        End Get
        Set(ByVal value As Decimal)
            _IncDecBudgetRpP = value
        End Set
    End Property

    Public Property IncDecBudgetuSD() As Decimal
        Get
            Return _IncDecBudgetuSD
        End Get
        Set(ByVal value As Decimal)
            _IncDecBudgetuSD = value
        End Set
    End Property

    Public Property KeyValuePairs() As Decimal
        Get
            Return _KeyValuePairs
        End Get
        Set(ByVal value As Decimal)
            _KeyValuePairs = value
        End Set
    End Property

    Public Property RiceCount() As Decimal
        Get
            Return _RiceCount
        End Get
        Set(ByVal value As Decimal)
            _RiceCount = value
        End Set
    End Property



    Public Property ExcRateUStoRP() As Decimal
        Get
            Return _ExcRateUStoRP
        End Get
        Set(ByVal value As Decimal)
            _ExcRateUStoRP = value
        End Set
    End Property

#End Region

End Class
