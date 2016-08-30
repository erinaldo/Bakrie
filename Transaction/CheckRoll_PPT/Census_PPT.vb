'/******
'
'Programmer: Dadang Adi Hendradi
'created: Jum'at, 28 Aug 2009, 23:04
'Modify : Kamis, 15 Oct 2009, 18:53
'
'/******

Public Class Census_PPT

#Region "Private Members Declarations"
    Private _CensusID As String
    Private _EstateID As String
    Private _EstateCode As String
    Private _ActiveMonthYearID As String
    Private _CensusDate As Date
    Private _DivName As String
    Private _YOP As String
    Private _BlockName As String
    Private _DivID As String
    Private _YOPID As String
    Private _BlockID As String
    Private _Block As String
    Private _AreaPlanted As Double          '[numeric](18, 3) NULL,
    Private _PlantdensityRequired As Double '[numeric](18, 3) NULL,
    Private _PlantDensityActual As Double   '[numeric](18, 3) NULL,
    Private _PorosinArea As Double          '[numeric](18, 3) NULL,
    Private _MainRoadInArea As Double       '[numeric](18, 3) NULL,
    Private _CollectionRoadInArea As Double '[numeric](18, 3) NULL,
    Private _NoOfBunches As Double          '[numeric](18, 0) NULL,
    Private _TotalFFB As Double             '[numeric](18, 3) NULL,
    'Private _ConcurrencyId As Date          '[timestamp] NOT NULL,
    Private _CreatedBy As String
    Private _CreatedOn As Date              '[datetime] NULL,
    Private _ModifiedBy As String           '[nvarchar](50) NULL,
    Private _ModifiedOn As Date             '[datetime] NULL,

    Private _rowcount As Integer ' Sunday, 30 Aug 2009, 22:14
#End Region

#Region "Public Member Declarations"
    Public Property CensusID() As String
        Get
            Return _CensusID
        End Get
        Set(ByVal value As String)
            _CensusID = value
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

    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property

    Public Property CensusDate() As Date
        Get
            Return _CensusDate
        End Get
        Set(ByVal value As Date)
            _CensusDate = value
        End Set
    End Property

    Public Property DivName() As String
        Get
            Return _DivName
        End Get
        Set(ByVal value As String)
            _DivName = value
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

    Public Property BlockName() As String
        Get
            Return _BlockName
        End Get
        Set(ByVal value As String)
            _BlockName = value
        End Set
    End Property

    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
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


    Public Property BlockID() As String
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)
            _BlockID = value
        End Set
    End Property

    Public Property AreaPlanted() As Double
        Get
            Return _AreaPlanted
        End Get
        Set(ByVal value As Double)
            _AreaPlanted = value
        End Set
    End Property

    Public Property PlantdensityRequired() As Double
        Get
            Return _PlantdensityRequired
        End Get
        Set(ByVal value As Double)
            _PlantdensityRequired = value
        End Set
    End Property

    Public Property PlantDensityActual() As Double
        Get
            Return _PlantDensityActual
        End Get
        Set(ByVal value As Double)
            _PlantDensityActual = value
        End Set
    End Property

    Public Property PorosinArea() As Double
        Get
            Return _PorosinArea
        End Get
        Set(ByVal value As Double)
            _PorosinArea = value
        End Set
    End Property

    Public Property MainRoadInArea() As Double
        Get
            Return _MainRoadInArea
        End Get
        Set(ByVal value As Double)
            _MainRoadInArea = value
        End Set
    End Property

    Public Property CollectionRoadInArea() As Double
        Get
            Return _CollectionRoadInArea
        End Get
        Set(ByVal value As Double)
            _CollectionRoadInArea = value
        End Set
    End Property

    Public Property NoOfBunches() As Double
        Get
            Return _NoOfBunches
        End Get
        Set(ByVal value As Double)
            _NoOfBunches = value
        End Set
    End Property

    Public Property TotalFFB() As Double
        Get
            Return _TotalFFB
        End Get
        Set(ByVal value As Double)
            _TotalFFB = value
        End Set
    End Property

    'Public Property ConcurrencyId() As Date
    '    Get
    '        Return _ConcurrencyId
    '    End Get
    '    Set(ByVal value As Date)
    '        _ConcurrencyId = value
    '    End Set
    'End Property

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

#End Region
End Class
