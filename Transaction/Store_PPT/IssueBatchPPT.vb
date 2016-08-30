Public Class IssueBatchPPT
#Region "Private Member Declarations"
    Private _STIssueBatchID As String = String.Empty
    Private _BatchDate As Date = Date.Today
    Private _SIVNo As String = String.Empty
    Private _BatchValue As Double '= 0.0

#End Region
#Region "Public Member Declarations"
    Public Property STIssueBatchID() As String
        Get
            Return _STIssueBatchID
        End Get
        Set(ByVal value As String)
            _STIssueBatchID = value
        End Set
    End Property
    Public Property BatchDate() As Date
        Get
            Return _BatchDate
        End Get
        Set(ByVal value As Date)
            _BatchDate = value
        End Set
    End Property
    Public Property SIVNo() As String
        Get
            Return _SIVNo
        End Get
        Set(ByVal value As String)
            _SIVNo = value
        End Set
    End Property
    Public Property BatchValue() As Double
        Get
            Return _BatchValue
        End Get
        Set(ByVal value As Double)
            _BatchValue = value
        End Set
    End Property
#End Region

End Class
