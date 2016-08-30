'created: Saturday, 29 Aug 2009, 01:00

Public Class RiceAdvance_PPT

#Region "Private Members Declarations"
    ' this field came from [Checkroll].[RiceDetails]

    'Private [Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
    Private _RiceDetID As String '[nvarchar](50) NOT NULL,
    Private _EstateID As String '[nvarchar](50) NULL,
    Private _RiceID As String           '[nvarchar](50) NULL,
    Private _EmpID As String            '[nvarchar](50) NULL,
    Private _Mandays As Double          '[numeric](18, 2) NULL,
    Private _RiceMax As Double          '[numeric](18, 3) NULL,
    Private _RiceIssueQty As Double     '[numeric](18, 3) NULL,
    Private _ConcurrencyId As Date      '[timestamp] NOT NULL,
    Private _CreatedBy As String        '[nvarchar](50) NULL,
    Private _CreatedOn As Date          '[datetime] NULL,
    Private _ModifiedBy As String       '[nvarchar](50) NULL,
    Private _ModifiedOn As Date         '[datetime] NULL,

    Private _rowcount As Integer ' Sunday, 30 Aug 2009, 22:14
#End Region

#Region "Public Member Declarations"

    Public Property RiceDetID() As String
        Get
            Return _RiceDetID
        End Get
        Set(ByVal value As String)
            _RiceDetID = value
        End Set
    End Property

    Public Property EmpID() As String
        Get
            Return _EmpID
        End Get
        Set(ByVal value As String)
            _EmpID = value
        End Set
    End Property

    Public Property Mandays() As Double
        Get
            Return _Mandays
        End Get
        Set(ByVal value As Double)
            _Mandays = value
        End Set
    End Property

    Public Property RiceMax() As Double
        Get
            Return _RiceMax
        End Get
        Set(ByVal value As Double)
            _RiceMax = value
        End Set
    End Property

    Public Property RiceIssueQty() As Double
        Get
            Return _RiceIssueQty
        End Get
        Set(ByVal value As Double)
            _RiceIssueQty = value
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
