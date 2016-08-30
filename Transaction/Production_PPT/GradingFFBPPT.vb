Public Class GradingFFBPPT

#Region "Private Properties"

    Private _GradingID As String = String.Empty
    Private _CountReaderRows As Integer = 0
    Private _WBTicketNo As String = String.Empty
    Private _SupplierName As String = String.Empty
    Private _NetWeight As Decimal
    Private _FFBDeliveryOrderNo As Decimal
    Private _ArrivedDate As Date
    Private _ArrivedTime As Date
    Private _Yop As String = String.Empty
    Private _Div As String = String.Empty
    Private _Driver As String = String.Empty
    Private _Block As String = String.Empty
    Private _NoOfTrip As Integer
    Private _Vehicle As String = String.Empty
    Private _TotalBunches As Decimal
    Private _BatuKerikil As Decimal
#End Region


#Region "Public Properties"
    Public Property GradingID() As String
        Get
            Return _GradingID
        End Get
        Set(ByVal value As String)
            _GradingID = value
        End Set
    End Property

    Public Property WBTicketNo() As String
        Get
            Return _WBTicketNo
        End Get
        Set(ByVal value As String)
            _WBTicketNo = value
        End Set
    End Property

    Public Property SupplierName() As String
        Get
            Return _SupplierName
        End Get
        Set(ByVal value As String)
            _SupplierName = value
        End Set
    End Property
    Public Property NetWeight() As Decimal
        Get
            Return _NetWeight
        End Get
        Set(ByVal value As Decimal)
            _NetWeight = value
        End Set
    End Property

    Public Property FFBDeliveryOrderNo() As Decimal
        Get
            Return _FFBDeliveryOrderNo
        End Get
        Set(ByVal value As Decimal)
            _FFBDeliveryOrderNo = value
        End Set
    End Property

    Public Property ArrivedDate() As Date
        Get
            Return _ArrivedDate
        End Get
        Set(ByVal value As Date)
            _ArrivedDate = value
        End Set
    End Property

    Public Property ArrivedTime() As Date
        Get
            Return _ArrivedTime
        End Get
        Set(ByVal value As Date)
            _ArrivedTime = value
        End Set
    End Property

    Public Property Div() As String
        Get
            Return _Div
        End Get
        Set(ByVal value As String)
            _Div = value
        End Set
    End Property

    Public Property Yop() As String
        Get
            Return _Yop
        End Get
        Set(ByVal value As String)
            _Yop = value
        End Set
    End Property

    Public Property Block() As String
        Get
            Return _Block
        End Get
        Set(ByVal value As String)
            _Block = value
        End Set
    End Property

    Public Property Driver() As String
        Get
            Return _Driver
        End Get
        Set(ByVal value As String)
            _Driver = value
        End Set
    End Property

    Public Property Vehicle() As String
        Get
            Return _Vehicle
        End Get
        Set(ByVal value As String)
            _Vehicle = value
        End Set
    End Property

    Public Property NoOfTrip() As Integer
        Get
            Return _NoOfTrip
        End Get
        Set(ByVal value As Integer)
            _NoOfTrip = value
        End Set
    End Property

    Public Property TotalBunches() As Decimal
        Get
            Return _TotalBunches
        End Get
        Set(ByVal value As Decimal)
            _TotalBunches = value
        End Set
    End Property

    Public Property CountReaderRows() As Integer
        Get
            Return _CountReaderRows
        End Get
        Set(ByVal value As Integer)
            _CountReaderRows = value
        End Set
    End Property
    Public Property BatuKerikil() As Decimal
        Get
            Return _BatuKerikil
        End Get
        Set(ByVal value As Decimal)
            _BatuKerikil = value
        End Set
    End Property
#End Region

#Region "SAVE PROPERTIES"

    Private _ActiveMonthYearID As String = String.Empty
    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property
    Private _WeighingID As String = String.Empty
    Public Property WeighingID() As String
        Get
            Return _WeighingID
        End Get
        Set(ByVal value As String)
            _WeighingID = value
        End Set
    End Property
    Private _GradingDate As Date
    Public Property GradingDate() As Date
        Get
            Return _GradingDate
        End Get
        Set(ByVal value As Date)
            _GradingDate = value
        End Set
    End Property
    Private _lGradingDate As String
    Public Property lGradingDate() As String
        Get
            Return _lGradingDate
        End Get
        Set(ByVal value As String)
            _lGradingDate = value
        End Set
    End Property
    Private _GradingTime As String
    Public Property GradingTime() As String
        Get
            Return _GradingTime
        End Get
        Set(ByVal value As String)
            _GradingTime = value
        End Set
    End Property

    Private _MinMaturity As Decimal = 0
    Public Property MinMaturity() As Decimal
        Get
            Return _MinMaturity
        End Get
        Set(ByVal value As Decimal)
            _MinMaturity = value
        End Set
    End Property
    Private _LosseFruitPerBunche As Integer = 0
    Public Property LosseFruitPerBunche() As Integer
        Get
            Return _LosseFruitPerBunche
        End Get
        Set(ByVal value As Integer)
            _LosseFruitPerBunche = value
        End Set
    End Property
    Private _UnripeFruitJ As Integer = 0
    Public Property UnripeFruitJ() As Integer
        Get
            Return _UnripeFruitJ
        End Get
        Set(ByVal value As Integer)
            _UnripeFruitJ = value
        End Set
    End Property
    Private _UnripeFruitP As Decimal = 0
    Public Property UnripeFruitP() As Decimal
        Get
            Return _UnripeFruitP
        End Get
        Set(ByVal value As Decimal)
            _UnripeFruitP = value
        End Set
    End Property
    Private _UnripeFruitT As String = String.Empty
    Public Property UnripeFruitT() As String
        Get
            Return _UnripeFruitT
        End Get
        Set(ByVal value As String)
            _UnripeFruitT = value
        End Set
    End Property
    Private _UnderripeJ As Integer = 0
    Public Property UnderripeJ() As Integer
        Get
            Return _UnderripeJ
        End Get
        Set(ByVal value As Integer)
            _UnderripeJ = value
        End Set
    End Property
    Private _UnderripeP As Decimal = 0
    Public Property UnderripeP() As Decimal
        Get
            Return _UnderripeP
        End Get
        Set(ByVal value As Decimal)
            _UnderripeP = value
        End Set
    End Property
    Private _UnderripeT As String = String.Empty
    Public Property UnderripeT() As String
        Get
            Return _UnderripeT
        End Get
        Set(ByVal value As String)
            _UnderripeT = value
        End Set
    End Property
    Private _RipeFruitJ As Integer = 0
    Public Property RipeFruitJ() As Integer
        Get
            Return _RipeFruitJ
        End Get
        Set(ByVal value As Integer)
            _RipeFruitJ = value
        End Set
    End Property
    Private _RipeFruitP As Decimal = 0
    Public Property RipeFruitP() As Decimal
        Get
            Return _RipeFruitP
        End Get
        Set(ByVal value As Decimal)
            _RipeFruitP = value
        End Set
    End Property
    Private _RipeFruitT As String = String.Empty
    Public Property RipeFruitT() As String
        Get
            Return _RipeFruitT
        End Get
        Set(ByVal value As String)
            _RipeFruitT = value
        End Set
    End Property
    Private _OverRipeFruitJ As Integer = 0
    Public Property OverRipeFruitJ() As Integer
        Get
            Return _OverRipeFruitJ
        End Get
        Set(ByVal value As Integer)
            _OverRipeFruitJ = value
        End Set
    End Property
    Private _OverRipeFruitP As Decimal = 0
    Public Property OverRipeFruitP() As Decimal
        Get
            Return _OverRipeFruitP
        End Get
        Set(ByVal value As Decimal)
            _OverRipeFruitP = value
        End Set
    End Property
    Private _OverRipeFruitT As String = String.Empty
    Public Property OverRipeFruitT() As String
        Get
            Return _OverRipeFruitT
        End Get
        Set(ByVal value As String)
            _OverRipeFruitT = value
        End Set
    End Property
    Private _EmptyBunchFruitJ As Integer = 0
    Public Property EmptyBunchFruitJ() As Integer
        Get
            Return _EmptyBunchFruitJ
        End Get
        Set(ByVal value As Integer)
            _EmptyBunchFruitJ = value
        End Set
    End Property
    Private _EmptyBunchFruitT As String = String.Empty
    Public Property EmptyBunchFruitT() As String
        Get
            Return _EmptyBunchFruitT
        End Get
        Set(ByVal value As String)
            _EmptyBunchFruitT = value
        End Set
    End Property
    Private _EmptyBunchFruitP As Decimal = 0
    Public Property EmptyBunchFruitP() As Decimal
        Get
            Return _EmptyBunchFruitP
        End Get
        Set(ByVal value As Decimal)
            _EmptyBunchFruitP = value
        End Set
    End Property
    Private _TotalNormalFruitsJ As Integer = 0
    Public Property TotalNormalFruitsJ() As Integer
        Get
            Return _TotalNormalFruitsJ
        End Get
        Set(ByVal value As Integer)
            _TotalNormalFruitsJ = value
        End Set
    End Property
    Private _TotalNormalFruitsP As Decimal = 0
    Public Property TotalNormalFruitsP() As Decimal
        Get
            Return _TotalNormalFruitsP
        End Get
        Set(ByVal value As Decimal)
            _TotalNormalFruitsP = value
        End Set
    End Property
    Private _TotalNormalFruitsT As String = String.Empty
    Public Property TotalNormalFruitsT() As String
        Get
            Return _TotalNormalFruitsT
        End Get
        Set(ByVal value As String)
            _TotalNormalFruitsT = value
        End Set
    End Property
    Private _PartheJ As Decimal = 0
    Public Property PartheJ() As Decimal
        Get
            Return _PartheJ
        End Get
        Set(ByVal value As Decimal)
            _PartheJ = value
        End Set
    End Property
    Private _PartheP As Decimal = 0
    Public Property PartheP() As Decimal
        Get
            Return _PartheP
        End Get
        Set(ByVal value As Decimal)
            _PartheP = value
        End Set
    End Property
    Private _PartheT As String = String.Empty
    Public Property PartheT() As String
        Get
            Return _PartheT
        End Get
        Set(ByVal value As String)
            _PartheT = value
        End Set
    End Property
    Private _HardBunchJ As Integer = 0
    Public Property HardBunchJ() As Integer
        Get
            Return _HardBunchJ
        End Get
        Set(ByVal value As Integer)
            _HardBunchJ = value
        End Set
    End Property
    Private _HardBunchP As Decimal = 0
    Public Property HardBunchP() As Decimal
        Get
            Return _HardBunchP
        End Get
        Set(ByVal value As Decimal)
            _HardBunchP = value
        End Set
    End Property
    Private _HardBunchT As String = String.Empty
    Public Property HardBunchT() As String
        Get
            Return _HardBunchT
        End Get
        Set(ByVal value As String)
            _HardBunchT = value
        End Set
    End Property
    Private _TotalAbnormalFruitsJ As Integer = 0
    Public Property TotalAbnormalFruitsJ() As Integer
        Get
            Return _TotalAbnormalFruitsJ
        End Get
        Set(ByVal value As Integer)
            _TotalAbnormalFruitsJ = value
        End Set
    End Property
    Private _TotalAbnormalFruitsP As Decimal = 0
    Public Property TotalAbnormalFruitsP() As Decimal
        Get
            Return _TotalAbnormalFruitsP
        End Get
        Set(ByVal value As Decimal)
            _TotalAbnormalFruitsP = value
        End Set
    End Property
    Private _TotalAbnormalFruitsT As String = String.Empty
    Public Property TotalAbnormalFruitsT() As String
        Get
            Return _TotalAbnormalFruitsT
        End Get
        Set(ByVal value As String)
            _TotalAbnormalFruitsT = value
        End Set
    End Property
    Private _GTActualBunchesJ As Integer = 0
    Public Property GTActualBunchesJ() As Integer
        Get
            Return _GTActualBunchesJ
        End Get
        Set(ByVal value As Integer)
            _GTActualBunchesJ = value
        End Set
    End Property
    Private _GTActualBunchesP As Decimal = 0
    Public Property GTActualBunchesP() As Decimal
        Get
            Return _GTActualBunchesP
        End Get
        Set(ByVal value As Decimal)
            _GTActualBunchesP = value
        End Set
    End Property
    Private _GTActualBunchesT As String = String.Empty
    Public Property GTActualBunchesT() As String
        Get
            Return _GTActualBunchesT
        End Get
        Set(ByVal value As String)
            _GTActualBunchesT = value
        End Set
    End Property
    Private _LooseFruitsP As Decimal = 0
    Public Property LooseFruitsP() As Decimal
        Get
            Return _LooseFruitsP
        End Get
        Set(ByVal value As Decimal)
            _LooseFruitsP = value
        End Set
    End Property
    Private _KgOfLooseFruit As Decimal = 0
    Public Property KgOfLooseFruit() As Decimal
        Get
            Return _KgOfLooseFruit
        End Get
        Set(ByVal value As Decimal)
            _KgOfLooseFruit = value
        End Set
    End Property
   
    'Private _UnDamageJ As Integer = 0
    'Public Property UnDamageJ() As Integer
    '    Get
    '        Return _UnDamageJ
    '    End Get
    '    Set(ByVal value As Integer)
    '        _UnDamageJ = value
    '    End Set
    'End Property
    'Private _UnDamageP As Decimal = 0
    'Public Property UnDamageP() As Decimal
    '    Get
    '        Return _UnDamageP
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _UnDamageP = value
    '    End Set
    'End Property
    'Private _UnDamageT As String = String.Empty
    'Public Property UnDamageT() As String
    '    Get
    '        Return _UnDamageT
    '    End Get
    '    Set(ByVal value As String)
    '        _UnDamageT = value
    '    End Set
    'End Property
    Private _LightDamageJ As Integer = 0
    Public Property LightDamageJ() As Integer
        Get
            Return _LightDamageJ
        End Get
        Set(ByVal value As Integer)
            _LightDamageJ = value
        End Set
    End Property
    Private _LightDamageP As Decimal = 0
    Public Property LightDamageP() As Decimal
        Get
            Return _LightDamageP
        End Get
        Set(ByVal value As Decimal)
            _LightDamageP = value
        End Set
    End Property
    Private _LightDamageT As String = String.Empty
    Public Property LightDamageT() As String
        Get
            Return _LightDamageT
        End Get
        Set(ByVal value As String)
            _LightDamageT = value
        End Set
    End Property
    'Private _DamageJ As Integer = 0
    'Public Property DamageJ() As Integer
    '    Get
    '        Return _DamageJ
    '    End Get
    '    Set(ByVal value As Integer)
    '        _DamageJ = value
    '    End Set
    'End Property
    'Private _DamageP As Decimal = 0
    'Public Property DamageP() As Decimal
    '    Get
    '        Return _DamageP
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _DamageP = value
    '    End Set
    'End Property
    'Private _DamageT As String = String.Empty
    'Public Property DamageT() As String
    '    Get
    '        Return _DamageT
    '    End Get
    '    Set(ByVal value As String)
    '        _DamageT = value
    '    End Set
    'End Property
    Private _TotalJ As Integer = 0
    Public Property TotalJ() As Integer
        Get
            Return _TotalJ
        End Get
        Set(ByVal value As Integer)
            _TotalJ = value
        End Set
    End Property
    Private _TotalP As Decimal = 0
    Public Property TotalP() As Decimal
        Get
            Return _TotalP
        End Get
        Set(ByVal value As Decimal)
            _TotalP = value
        End Set
    End Property
    Private _TotalT As String = String.Empty
    Public Property TotalT() As String
        Get
            Return _TotalT
        End Get
        Set(ByVal value As String)
            _TotalT = value
        End Set
    End Property
    Private _Comment As String = String.Empty
    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal value As String)
            _Comment = value
        End Set
    End Property

    'added by naxim on 23 Oct 2013
    Public Property DocumentNumber As String

    Public Property LongStalksJ As Decimal
    Public Property DirtAndStonesJ As Decimal
    Public Property SmallBunchesJ As Decimal
    Public Property BuahRestanJ As Decimal
    Public Property MediumDamageJ As Decimal

    Public Property BunchStalkNotCutJ As Decimal
    Public Property RottenBunchJ As Decimal
    Public Property BuahRestan1to2J As Decimal
    Public Property Abnormal As Decimal

    Public Property UnripeFruitComment As String
    Public Property UnderRipeComment As String
    Public Property AbnormalComment As String
    Public Property OverRipeFruitComment As String
    Public Property EmptyBunchFruitComment As String
    Public Property LongStalksComment As String
    Public Property LooseFruitsComment As String
    Public Property DirtAndStonesComment As String
    Public Property SmallBunchesComment As String
    Public Property BuahRestanComment As String
    Public Property HardBunchComment As String
    Public Property PartheComment As String
    Public Property LightDamageComment As String
    'Public Property MediumDamageComment As String
    'Public Property DamageComment As String

    Public Property RipeComment As String
    Public Property BunchStalkNotCutComment As String
    Public Property RottenBunchComment As String
    Public Property BuahRestan1to2Comment As String

    Public Property UnripeFruitGraded As Decimal
    Public Property UnderRipeGraded As Decimal
    Public Property OverRipeFruitGraded As Decimal
    Public Property EmptyBunchFruitGraded As Decimal
    Public Property LongStalksGraded As Decimal
    Public Property LooseFruitsGraded As Decimal
    Public Property DirtAndStonesGraded As Decimal
    Public Property SmallBunchesGraded As Decimal
    Public Property BuahRestanGraded As Decimal
    Public Property IncentiveGraded As Decimal

    Public Property BinNumber As String

    Public Property TotalGradedBunches As Decimal

#End Region
End Class
