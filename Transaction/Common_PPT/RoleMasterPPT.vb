Public Class RoleMasterPPT
#Region "Private Member Declarations"
    Private _RoleID As String
    Private _MenuID As String
    Private _DesgID As String
    Private _PrVisible As Boolean
    Private _PrAdd As Boolean
    Private _PrUpdate As Boolean
    Private _PrDelete As Boolean
    Private _CreatedBy As String
    Private _CreatedOn As Date
    Private _ModifiedBy As String
    Private _ModifiedOn As Date
    Private _MenuName As String
    Private _MenuBName As String
    Private _DesgDesc As String
    Private _EstateCode As String
    Private _RoleName As String
    Private _ConcurrencyId As Long
#End Region

#Region "Public Properties"
    Public Property RoleID() As String
        Get
            Return _RoleID
        End Get
        Set(ByVal value As String)
            _RoleID = value
        End Set
    End Property
    Public Property RoleName() As String
        Get
            Return _RoleName
        End Get
        Set(ByVal value As String)
            _RoleName = value
        End Set
    End Property
    Public Property MenuID() As String
        Get
            Return _MenuID
        End Get
        Set(ByVal value As String)
            _MenuID = value
        End Set
    End Property

    Public Property DesgID() As String
        Get
            Return _DesgID
        End Get
        Set(ByVal value As String)
            _DesgID = value
        End Set
    End Property

    Public Property MenuName() As String
        Get
            Return _MenuName
        End Get
        Set(ByVal value As String)
            _MenuName = value
        End Set
    End Property
    Public Property MenuBName() As String
        Get
            Return _MenuBName
        End Get
        Set(ByVal value As String)
            _MenuBName = value
        End Set
    End Property

    Public Property DesgDesc() As String
        Get
            Return _DesgDesc
        End Get
        Set(ByVal value As String)
            _DesgDesc = value
        End Set
    End Property


    Public Property PrVisible() As Boolean
        Get
            Return _PrVisible
        End Get
        Set(ByVal value As Boolean)
            _PrVisible = value
        End Set
    End Property

    Public Property PrAdd() As Boolean
        Get
            Return _PrAdd
        End Get
        Set(ByVal value As Boolean)
            _PrAdd = value
        End Set
    End Property

    Public Property PrUpdate() As Boolean
        Get
            Return _PrUpdate
        End Get
        Set(ByVal value As Boolean)
            _PrUpdate = value
        End Set
    End Property

    Public Property PrDelete() As Boolean
        Get
            Return _PrDelete
        End Get
        Set(ByVal value As Boolean)
            _PrDelete = value
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

    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
        End Set
    End Property
    Public Property ConcurrencyId() As Long
        Get
            Return _ConcurrencyId
        End Get
        Set(ByVal value As Long)
            _ConcurrencyId = value
        End Set
    End Property
#End Region


End Class
