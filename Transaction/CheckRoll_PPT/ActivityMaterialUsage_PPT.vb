Imports System

Public Class ActivityMaterialUsage_PPT
#Region "Private Members Declarations"
    Private _MaterialUsageID As String
    Private _EstateID As String
    Private _ActiveMonthYearID As String
    Private _DailyDistributionID As String
    Private _STIssueID As String
    Private _StockID As String
    Private _UsageQty As Double
    Private _ConcurrencyId As Date
    Private _CreatedBy As String
    Private _CreatedOn As Date
    Private _ModifiedBy As String
    Private _ModifiedOn As Date

    Private _rowcount As Integer ' Sunday, 30 Aug 2009, 22:13
#End Region

#Region "Public Member Declarations"
    Public Property MaterialUsageID() As String
        Get
            Return _MaterialUsageID
        End Get
        Set(ByVal value As String)
            _MaterialUsageID = value
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

    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property

    Public Property DailyDistributionID() As String
        Get
            Return _DailyDistributionID
        End Get
        Set(ByVal value As String)
            _DailyDistributionID = value
        End Set
    End Property

    Public Property STIssueID() As String
        Get
            Return _STIssueID
        End Get
        Set(ByVal value As String)
            _STIssueID = value
        End Set
    End Property

    Public Property StockID() As String
        Get
            Return _StockID
        End Get
        Set(ByVal value As String)
            _StockID = value
        End Set
    End Property

    Public Property UsageQty() As Double
        Get
            Return _UsageQty
        End Get
        Set(ByVal value As Double)
            _UsageQty = value
        End Set
    End Property

    Public Property ConcurrencyId() As Date
        Get
            Return _ConcurrencyId
        End Get
        Set(ByVal value As Date)
            _ConcurrencyId = value
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

#End Region
End Class
