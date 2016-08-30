
Public Class MDIParentPPT

#Region "Private Member Declarations"
    Private _IsIPROpen As Boolean = False
    Private _IsWBTicketOpen As Boolean = False
    Private _IsWBInOut As Boolean = False
    Private _MenuID As String = String.Empty
    Private _ModID As Integer = 0
    Private _MenuGroupID As String = String.Empty
    Private _ModName As String = String.Empty
    Private _MenuName As String = String.Empty
    Private _MenuGroup As String = String.Empty
    Private _RowCount As Integer = 0
#End Region

#Region "Public Properties"
    Public Shared intCount As Integer
    Public Shared arrListMenu(150, 2) As String
    Public arrMenuGroupList As New ArrayList()
    Public Property IsIPROpen() As Boolean
        Get
            Return _IsIPROpen
        End Get
        Set(ByVal value As Boolean)
            _IsIPROpen = value
        End Set
    End Property

    Public Property IsWBTicketOpen() As Boolean
        Get
            Return _IsWBTicketOpen
        End Get
        Set(ByVal value As Boolean)
            _IsWBTicketOpen = value
        End Set
    End Property

    Public Property IsWBInOut() As Boolean
        Get
            Return _IsWBInOut
        End Get
        Set(ByVal value As Boolean)
            _IsWBInOut = value
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

    Public Property ModID() As Integer
        Get
            Return _ModID
        End Get
        Set(ByVal value As Integer)
            _ModID = value
        End Set
    End Property
    Public Property ModName() As String
        Get
            Return _ModName
        End Get
        Set(ByVal value As String)
            _ModName = value
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
    Public Property MenuGroupID() As String
        Get
            Return _MenuGroupID
        End Get
        Set(ByVal value As String)
            _MenuGroupID = value
        End Set
    End Property
    Public Property MenuGroup() As String
        Get
            Return _MenuGroup
        End Get
        Set(ByVal value As String)
            _MenuGroup = value
        End Set
    End Property

    Public Property RowCount() As Integer
        Get
            Return _RowCount
        End Get
        Set(ByVal value As Integer)
            _RowCount = value
        End Set
    End Property
#End Region
End Class
