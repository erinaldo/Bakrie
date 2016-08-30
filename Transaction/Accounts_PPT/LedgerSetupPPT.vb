Public Class LedgerSetupPPT
#Region "Private Varibles"

    Private _LedgerType As String = String.Empty
    Private _LedgerTypeDescp As String = String.Empty
    Private _LedgerSetUpID As String = String.Empty
    Private _Condition As String = String.Empty
#End Region

#Region "Public Member Declarations"
    Public Property Ledgertype() As String
        Get
            Return _LedgerType
        End Get
        Set(ByVal value As String)
            _LedgerType = value
        End Set
    End Property

    Public Property LedgerTypeDescp() As String
        Get
            Return _LedgerTypeDescp
        End Get
        Set(ByVal value As String)
            _LedgerTypeDescp = value
        End Set
    End Property


    Public Property LedgerSetUpID() As String
        Get
            Return _LedgerSetUpID
        End Get
        Set(ByVal value As String)
            _LedgerSetUpID = value
        End Set
    End Property
    Public Property Condition() As String
        Get
            Return _Condition
        End Get
        Set(ByVal value As String)
            _Condition = value
        End Set
    End Property


    'Public Property ModifiedOn() As String
    '    Get
    '        Return _ModifiedOn
    '    End Get
    '    Set(ByVal value As String)
    '        _ModifiedOn = value
    '    End Set
    'End Property

    'Public Property ModifiedBy() As String
    '    Get
    '        Return _ModifiedBy
    '    End Get
    '    Set(ByVal value As String)
    '        _ModifiedBy = value
    '    End Set
    'End Property

    'Public Property CreatedOn() As String
    '    Get
    '        Return _CreatedOn
    '    End Get
    '    Set(ByVal value As String)
    '        _CreatedOn = value
    '    End Set
    'End Property

    'Public Property CreatedBy() As String
    '    Get
    '        Return _CreatedBy
    '    End Get
    '    Set(ByVal value As String)
    '        _CreatedBy = value
    '    End Set
    'End Property
#End Region

End Class
