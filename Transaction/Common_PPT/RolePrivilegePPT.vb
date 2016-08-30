Public Class RolePrivilegePPT
#Region "Private Member Declarations"
    Private _RolePrivilegeID As String
    Private _MenuID As String
    Private _Menu As String
    Private _RoleID As String
    Private _MenuGroupID As String
    Private _Visible As Integer
    Private _RAdd As Integer
    Private _RUpdate As Integer
    Private _RDelete As Integer
    Private _CreatedOn As Date
    Private _ModifiedBy As String
    Private _ModifiedOn As Date
    Private _EstateCode As String
    Private _RoleName As String
    Private _ConcurrencyId As Long
    Private _ModID As Integer
    'Private _MenuGroupID As String
    Private _IncludeAll As Integer
    Public Shared dtMenuGroup As DataTable
    Public Shared dtMenu As DataTable
    Public Shared dtModule As DataTable
#End Region

#Region "Public Properties"
    Public Property RolePrivilegeID() As String
        Get
            Return _RolePrivilegeID
        End Get
        Set(ByVal value As String)
            _RolePrivilegeID = value
        End Set
    End Property
    Public Property RoleID() As String
        Get
            Return _RoleID
        End Get
        Set(ByVal value As String)
            _RoleID = value
        End Set
    End Property
    Public Property Menu() As String
        Get
            Return _Menu
        End Get
        Set(ByVal value As String)
            _Menu = value
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
    Public Property MenuGroupID() As String
        Get
            Return _MenuGroupID
        End Get
        Set(ByVal value As String)
            _MenuGroupID = value
        End Set
    End Property
    Public Property Visible() As Integer
        Get
            Return _Visible
        End Get
        Set(ByVal value As Integer)
            _Visible = value
        End Set
    End Property
    Public Property RAdd() As Integer
        Get
            Return _RAdd
        End Get
        Set(ByVal value As Integer)
            _RAdd = value
        End Set
    End Property

    Public Property RUpdate() As Integer
        Get
            Return _RUpdate
        End Get
        Set(ByVal value As Integer)
            _RUpdate = value
        End Set
    End Property
    Public Property RDelete() As Integer
        Get
            Return _RDelete
        End Get
        Set(ByVal value As Integer)
            _RDelete = value
        End Set
    End Property
    Public Property ModID() As Integer
        Get
            Return _ModID
        End Get
        Set(ByVal value As Integer)
            _ModID = value
        End Set
    End Property
    Public Property IncludeAll() As Integer
        Get
            Return _IncludeAll
        End Get
        Set(ByVal value As Integer)
            _IncludeAll = value
        End Set
    End Property
#End Region

    Public Shared _View As Boolean

    Public Property View() As Boolean
        Get
            Return _View
        End Get
        Set(ByVal value As Boolean)
            _View = value
        End Set
    End Property


    Public Shared _Add As Boolean

    Public Property Add() As Boolean
        Get
            Return _Add
        End Get
        Set(ByVal value As Boolean)
            _Add = value
        End Set
    End Property

    Public Shared _Delete As Boolean

    Public Property Delete() As Boolean
        Get
            Return _Delete
        End Get
        Set(ByVal value As Boolean)
            _Delete = value
        End Set
    End Property

    Public Shared _Update As Boolean

    Public Property Update() As Boolean
        Get
            Return _Update
        End Get
        Set(ByVal value As Boolean)
            _Update = value
        End Set
    End Property

    Public Shared _MID As String

    Public Property MID() As String
        Get
            Return _MID
        End Get
        Set(ByVal value As String)
            _MID = value
        End Set
    End Property

    Public Shared _RID As String

    Public Property RID() As String
        Get
            Return _RID
        End Get
        Set(ByVal value As String)
            _RID = value
        End Set
    End Property



End Class
