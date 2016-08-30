'created: Jum'at, 28 Aug 2009, 23:27

Public Class AdvancePayment_PPT
#Region "Private Members Declarations"
    'Private _Id As Double '[numeric](18, 0) IDENTITY(1,1) NOT NULL,
    Private _AdvancePaymentID As String '[nvarchar](50) NOT NULL,
    Private _EstateID As String  '[nvarchar](50) NOT NULL,
    Private _ActiveMonthYearID As String '[nvarchar](50) NOT NULL,
    Private _AdvProcessingDate As Date '[date] NOT NULL,
    Private _Category As String '[nvarchar](50) NOT NULL,
    Private _AdvancePremium As Double '[numeric](18, 2) NOT NULL,
    Private _ConcurrencyId As Date '[timestamp] NOT NULL,
    Private _CreatedBy As String '[nvarchar](50) NULL,
    Private _CreatedOn As Date '[datetime] NULL,
    Private _ModifiedBy As String '[nvarchar](50) NULL,
    Private _ModifiedOn As Date '[datetime] NULL,

    Private _rowcount As Integer ' Sunday, 30 Aug 2009, 22:13

#End Region


#Region "Public Member Declarations"

    Public Property AdvancePaymentID() As String
        Get
            Return _AdvancePaymentID
        End Get
        Set(ByVal value As String)
            _AdvancePaymentID = value
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

    Public Property AdvProcessingDate() As Date
        Get
            Return _AdvProcessingDate
        End Get
        Set(ByVal value As Date)
            _AdvProcessingDate = value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property

    Public Property AdvancePremium() As Double
        Get
            Return _AdvancePremium
        End Get
        Set(ByVal value As Double)
            _AdvancePremium = value
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
