Public Class AnalyHarvestingCostPPT
#Region "Private Member Declarations"

    Private _WBFruitWtID As String

    Private _MonthYear As String

    Private _YOPID As String = ""
    Private _YOP As String = ""

    Private _FFBWt As Double = 0
    Private _FFBBunches As Double = 0

    Private _OthersWt As Double = 0
    Private _HarvestersWt As Double = 0

#End Region

#Region "Public Member Declarations"

    Public Property WBFruitWtID() As String
        Get
            Return _WBFruitWtID
        End Get
        Set(ByVal value As String)
            _WBFruitWtID = value
        End Set
    End Property


    Public Property MonthYear() As String
        Get
            Return _MonthYear
        End Get
        Set(ByVal value As String)
            _MonthYear = value
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

    Public Property FFBWt() As Double
        Get
            Return _FFBWt
        End Get
        Set(ByVal value As Double)
            _FFBWt = value
        End Set
    End Property

    Public Property FFBBunches() As Double
        Get
            Return _FFBBunches
        End Get
        Set(ByVal value As Double)
            _FFBBunches = value
        End Set
    End Property

    Public Property OthersWt() As Double
        Get
            Return _OthersWt
        End Get
        Set(ByVal value As Double)
            _OthersWt = value
        End Set
    End Property

    Public Property HarvestersWt() As String
        Get
            Return _HarvestersWt
        End Get
        Set(ByVal value As String)
            _HarvestersWt = value
        End Set
    End Property

#End Region
End Class
