Public Class UserMasterPPT
#Region "Private Member Declarations"
    Private _UserID As String
    Private _UserName As String
    Private _Pass() As Byte
    Private _TmpPass As String
    Private _DispName As String
    Private _DesgID As String
    Private _Desg As String
    Private _DLevel As Integer
    Private _ConcurrencyId As Long
    Private _CreatedBy As String
    Private _CreatedOn As Date
    Private _ModifiedBy As String
    Private _ModifiedOn As Date
    Private _EstateCode As String
    Public Shared _RoleID As String
#End Region

#Region "UserMaster Settings"
    Private _MSUserID As String
    Private _MSUserName As String
    Private _MSDispName As String
    Private _MSPwd As String
    Private _MSDesgID As String
    Private _MSRoleID As String
    Private _MSPwdByte As Byte
    Private Shared _CPUserID As String
    Private _FiscalMonth As Integer
    Private _FiscalYear As Integer
#End Region

#Region "Public Properties for UserMaster"
    Public Property MSUserID() As String
        Get
            Return _MSUserID
        End Get
        Set(ByVal value As String)
            _MSUserID = value
        End Set
    End Property
    Public Property MSUserName() As String
        Get
            Return _MSUserName
        End Get
        Set(ByVal value As String)
            _MSUserName = value
        End Set
    End Property
    Public Property MSDispName() As String
        Get
            Return _MSDispName
        End Get
        Set(ByVal value As String)
            _MSDispName = value
        End Set
    End Property
    Public Property MSPwd() As String
        Get
            Return _MSPwd
        End Get
        Set(ByVal value As String)
            _MSPwd = value
        End Set
    End Property
    Public Property MSDesgID() As String
        Get
            Return _MSDesgID
        End Get
        Set(ByVal value As String)
            _MSDesgID = value
        End Set
    End Property
    Public Property MSRoleID() As String
        Get
            Return _MSRoleID
        End Get
        Set(ByVal value As String)
            _MSRoleID = value
        End Set
    End Property
    Public Property MSPwdByte() As Byte
        Get
            Return _MSPwdByte
        End Get
        Set(ByVal value As Byte)
            _MSPwdByte = value
        End Set
    End Property
    Public Property FiscalMonth() As Integer
        Get
            Return _FiscalMonth
        End Get
        Set(ByVal value As Integer)
            _FiscalMonth = value
        End Set
    End Property
    Public Property FiscalYear() As Integer
        Get
            Return _FiscalYear
        End Get
        Set(ByVal value As Integer)
            _FiscalYear = value
        End Set
    End Property
#End Region

#Region "Public Properties"
    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal value As String)
            _UserID = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property Pass() As Byte()
        Get
            Return _Pass
        End Get
        Set(ByVal value() As Byte)
            _Pass = value
        End Set
    End Property

    Public Property TmpPass() As String
        Get
            Return _TmpPass
        End Get
        Set(ByVal value As String)
            _TmpPass = value
        End Set
    End Property

    Public Property DispName() As String
        Get
            Return _DispName
        End Get
        Set(ByVal value As String)
            _DispName = value
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
    
    Public Property Desg() As String
        Get
            Return _Desg
        End Get
        Set(ByVal value As String)
            _Desg = value
        End Set
    End Property

    Public Property DLevel() As Integer
        Get
            Return _DLevel
        End Get
        Set(ByVal value As Integer)
            _DLevel = value
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

    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
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

    Public Shared Property CPUserID() As String
        Get
            Return _CPUserID
        End Get
        Set(ByVal value As String)
            _CPUserID = value
        End Set
    End Property

    Public Shared Property RoleID() As String
        Get
            Return _RoleID
        End Get
        Set(ByVal value As String)
            _RoleID = value
        End Set
    End Property

#End Region
End Class
