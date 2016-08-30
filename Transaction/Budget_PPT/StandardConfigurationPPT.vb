Public Class StandardConfigurationPPT
#Region "Private Member Declarations"
    Private _StandardConfigID As String
    Private _EstateID As String
    Private _BudgetYear As Integer
    Private _ExcRateUStoRP As Double = 0.0
    'Private _MandayRateforKHP As Double = 0.0
    Private _PlantingPalmPerHa As Double = 0.0
    'Private _MandayRateforBHL As Double = 0.0
    Private _ManuringPerHa As Double = 0.0
    Private _YearBaseRate As Double = 0.0
    Private _PinkSlipPrefix As String
    Private _PinkSlipCommencingNo As Double = 0.0
    'Private _CreatedBy As String
    'Private _CreatedOn As Date
    'Private _ModifiedBy As String
    'Private _ModifiedOn As Date
    'Private _ConcurrencyId As Long

    'Private _HarvestingQuarterID As String
    'Private _BDGYear As Double = 0.0
    'Private _Period As String
    'Private _Astek As Double = 0.0
    'Private _AstekP As Double = 0.0
    'Private _Sundays As Integer
    'Private _SundaysUnit As String
    'Private _SundaysRp As Double = 0.0
    'Private _OtherDays As Double = 0.0
    'Private _OtherDaysUnit As String
    'Private _OtherDaysRp As Double = 0.0
    'Private _LeaveCost As Double = 0.0
    'Private _LeaveCostUnit As String
    'Private _LeaveCostRp As Double = 0.0
    'Private _Rice As Double = 0.0
    'Private _RiceUnit As String
    'Private _RiceRp As Double = 0.0
    'Private _THR As Double = 0.0
    'Private _THRUnit As String
    'Private _THRRp As Double = 0.0

#End Region


#Region "Public Properties"
    Public Property StandardConfigID() As String
        Get
            Return _StandardConfigID
        End Get
        Set(ByVal value As String)
            _StandardConfigID = value
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
    Public Property PinkSlipPrefix() As String
        Get
            Return _PinkSlipPrefix
        End Get
        Set(ByVal value As String)
            _PinkSlipPrefix = value
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
    Public Property ExcRateUStoRP() As Double
        Get
            Return _ExcRateUStoRP
        End Get
        Set(ByVal value As Double)
            _ExcRateUStoRP = value
        End Set
    End Property
    'Public Property MandayRateforKHP() As Double
    '    Get
    '        Return _MandayRateforKHP
    '    End Get
    '    Set(ByVal value As Double)
    '        _MandayRateforKHP = value
    '    End Set
    'End Property
    Public Property PlantingPalmPerHa() As Double
        Get
            Return _PlantingPalmPerHa
        End Get
        Set(ByVal value As Double)
            _PlantingPalmPerHa = value
        End Set
    End Property
    'Public Property MandayRateforBHL() As Double
    '    Get
    '        Return _MandayRateforBHL
    '    End Get
    '    Set(ByVal value As Double)
    '        _MandayRateforBHL = value
    '    End Set
    'End Property
    Public Property ManuringPerHa() As Double
        Get
            Return _ManuringPerHa
        End Get
        Set(ByVal value As Double)
            _ManuringPerHa = value
        End Set
    End Property
    Public Property YearBaseRate() As Double
        Get
            Return _YearBaseRate
        End Get
        Set(ByVal value As Double)
            _YearBaseRate = value
        End Set
    End Property
    Public Property PinkSlipCommencingNo() As Double
        Get
            Return _PinkSlipCommencingNo
        End Get
        Set(ByVal value As Double)
            _PinkSlipCommencingNo = value
        End Set
    End Property

    'Public Property CreatedBy() As String
    '    Get
    '        Return _CreatedBy
    '    End Get
    '    Set(ByVal value As String)
    '        _CreatedBy = value
    '    End Set
    'End Property


    'Public Property CreatedOn() As Date
    '    Get
    '        Return _CreatedOn
    '    End Get
    '    Set(ByVal value As Date)
    '        _CreatedOn = value
    '    End Set
    'End Property

    'Public Property ModifiedBy() As String
    '    Get
    '        Return _ModifiedBy
    '    End Get
    '    Set(ByVal value As String)
    '        _ModifiedBy = value
    '    End Set
    'End Property


    'Public Property ModifiedOn() As Date
    '    Get
    '        Return _ModifiedOn
    '    End Get
    '    Set(ByVal value As Date)
    '        _ModifiedOn = value
    '    End Set
    'End Property
    'Public Property ConcurrencyId() As Long
    '    Get
    '        Return _ConcurrencyId
    '    End Get
    '    Set(ByVal value As Long)
    '        _ConcurrencyId = value
    '    End Set
    'End Property


    'Public Property HarvestingQuarterID() As String
    '    Get
    '        Return _HarvestingQuarterID
    '    End Get
    '    Set(ByVal value As String)
    '        _HarvestingQuarterID = value
    '    End Set
    'End Property
    'Public Property BDGYear() As Double
    '    Get
    '        Return _BDGYear
    '    End Get
    '    Set(ByVal value As Double)
    '        _BDGYear = value
    '    End Set
    'End Property
    'Public Property Period() As String
    '    Get
    '        Return _Period
    '    End Get
    '    Set(ByVal value As String)
    '        _Period = value
    '    End Set
    'End Property
    'Public Property Astek() As Double
    '    Get
    '        Return _Astek
    '    End Get
    '    Set(ByVal value As Double)
    '        _Astek = value
    '    End Set
    'End Property
    'Public Property AstekP() As Double
    '    Get
    '        Return _AstekP
    '    End Get
    '    Set(ByVal value As Double)
    '        _AstekP = value
    '    End Set
    'End Property
    'Public Property Sundays() As Integer
    '    Get
    '        Return _Sundays
    '    End Get
    '    Set(ByVal value As Integer)
    '        _Sundays = value
    '    End Set
    'End Property
    'Public Property SundaysUnit() As String
    '    Get
    '        Return _SundaysUnit
    '    End Get
    '    Set(ByVal value As String)
    '        _SundaysUnit = value
    '    End Set
    'End Property
    'Public Property SundaysRp() As Double
    '    Get
    '        Return _SundaysRp
    '    End Get
    '    Set(ByVal value As Double)
    '        _SundaysRp = value
    '    End Set
    'End Property
    'Public Property OtherDays() As Double
    '    Get
    '        Return _OtherDays
    '    End Get
    '    Set(ByVal value As Double)
    '        _OtherDays = value
    '    End Set
    'End Property
    'Public Property OtherDaysUnit() As String
    '    Get
    '        Return _OtherDaysUnit
    '    End Get
    '    Set(ByVal value As String)
    '        _OtherDaysUnit = value
    '    End Set
    'End Property
    'Public Property OtherDaysRp() As Double
    '    Get
    '        Return _OtherDaysRp
    '    End Get
    '    Set(ByVal value As Double)
    '        _OtherDaysRp = value
    '    End Set
    'End Property
    'Public Property LeaveCost() As Double
    '    Get
    '        Return _LeaveCost
    '    End Get
    '    Set(ByVal value As Double)
    '        _LeaveCost = value
    '    End Set
    'End Property
    'Public Property LeaveCostUnit() As String
    '    Get
    '        Return _LeaveCostUnit
    '    End Get
    '    Set(ByVal value As String)
    '        _LeaveCostUnit = value
    '    End Set
    'End Property
    'Public Property LeaveCostRp() As Double
    '    Get
    '        Return _LeaveCostRp
    '    End Get
    '    Set(ByVal value As Double)
    '        _LeaveCostRp = value
    '    End Set
    'End Property
    'Public Property Rice() As Double
    '    Get
    '        Return _Rice
    '    End Get
    '    Set(ByVal value As Double)
    '        _Rice = value
    '    End Set
    'End Property
    'Public Property RiceUnit() As String
    '    Get
    '        Return _RiceUnit
    '    End Get
    '    Set(ByVal value As String)
    '        _RiceUnit = value
    '    End Set
    'End Property
    'Public Property RiceRp() As Double
    '    Get
    '        Return _RiceRp
    '    End Get
    '    Set(ByVal value As Double)
    '        _RiceRp = value
    '    End Set
    'End Property
    'Public Property THR() As Double
    '    Get
    '        Return _THR
    '    End Get
    '    Set(ByVal value As Double)
    '        _THR = value
    '    End Set
    'End Property
    'Public Property THRUnit() As String
    '    Get
    '        Return _THRUnit
    '    End Get
    '    Set(ByVal value As String)
    '        _THRUnit = value
    '    End Set
    'End Property
    'Public Property THRRp() As Double
    '    Get
    '        Return _THRRp
    '    End Get
    '    Set(ByVal value As Double)
    '        _THRRp = value
    '    End Set
    'End Property

#End Region
End Class
