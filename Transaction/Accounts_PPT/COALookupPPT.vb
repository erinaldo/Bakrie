Public Class COALookupPPT
#Region "Private Varibles"
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _ParentId As String = String.Empty
    Private _COADescp As String = String.Empty
    Private _AccountType As String = String.Empty
    Private _OldCOACode As String = String.Empty
    Private _ExpenditureAG As String = String.Empty

#End Region

#Region "Public Member Declarations"
    Public Property COAID() As String
        Get
            Return _COAID
        End Get
        Set(ByVal value As String)
            _COAID = value
        End Set
    End Property

    Public Property COACode() As String
        Get
            Return _COACode
        End Get
        Set(ByVal value As String)
            _COACode = value
        End Set
    End Property

    Public Property ParentId() As String
        Get
            Return _ParentId
        End Get
        Set(ByVal value As String)
            _ParentId = value
        End Set
    End Property

    Public Property COADescp() As String
        Get
            Return _COADescp
        End Get
        Set(ByVal value As String)
            _COADescp = value
        End Set
    End Property

    Public Property AccountType() As String
        Get
            Return _AccountType
        End Get
        Set(ByVal value As String)
            _AccountType = value
        End Set
    End Property

    Public Property OldCOACode() As String
        Get
            Return _OldCOACode
        End Get
        Set(ByVal value As String)
            _OldCOACode = value
        End Set
    End Property


    Public Property ExpenditureAG() As String
        Get
            Return _ExpenditureAG
        End Get
        Set(ByVal value As String)
            _ExpenditureAG = value
        End Set
    End Property


#End Region

End Class
