Public Class AccountBatchPPT

#Region "Private Varibles"

    Private _AccBatchID As String = String.Empty
    Private _LedgerTypeDescp As String = String.Empty
    Private _ActiveMonthYearID As String = String.Empty
    Private _LedgerNo As String = String.Empty
    Private _LedgerDescription As String = String.Empty
    Private _AccBatchTotal As Double = 0.0
    Private _RecurringJournal As String = String.Empty
    Private _Approved As String = String.Empty
    Private _LedgerSetUpId As String = String.Empty
    Private _LedgerType As String = String.Empty



#End Region

#Region "Public Member Declarations"
    Public Property AccBatchID() As String
        Get
            Return _AccBatchID
        End Get
        Set(ByVal value As String)
            _AccBatchID = value
        End Set
    End Property
    Public Property LedgerType() As String
        Get
            Return _LedgerType
        End Get
        Set(ByVal value As String)
            _LedgerType = value
        End Set
    End Property
    Public Property LedgerSetUpId() As String
        Get
            Return _LedgerSetUpId
        End Get
        Set(ByVal value As String)
            _LedgerSetUpId = value
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

    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property
    Public Property LedgerNo() As String
        Get
            Return _LedgerNo
        End Get
        Set(ByVal value As String)
            _LedgerNo = value
        End Set
    End Property
    Public Property LedgerDescription() As String
        Get
            Return _LedgerDescription
        End Get
        Set(ByVal value As String)
            _LedgerDescription = value
        End Set
    End Property
    Public Property AccBatchTotal() As Double
        Get
            Return _AccBatchTotal
        End Get
        Set(ByVal value As Double)
            _AccBatchTotal = value
        End Set
    End Property
    Public Property RecurringJournal() As String
        Get
            Return _RecurringJournal
        End Get
        Set(ByVal value As String)
            _RecurringJournal = value
        End Set
    End Property
    Public Property Approved() As String
        Get
            Return _Approved
        End Get
        Set(ByVal value As String)
            _Approved = value
        End Set
    End Property
#End Region

End Class
