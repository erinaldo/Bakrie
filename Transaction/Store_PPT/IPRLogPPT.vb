Public Class IPRLogPPT
   
#Region "Private Member Declarations"
    Private _STIPRID As String = String.Empty
    Private _IPRdate As Date
    Private _IPRNo As String = String.Empty
    Private _STIPRDetID As String = String.Empty
    Private _Status As String = String.Empty
    Private _IPRStatusID As String = String.Empty
    Private _StatusDate As Date
    Private _PersonName As String = String.Empty
    Private _EstateCode As String = String.Empty

#End Region
#Region "Public Properties"
    Public Property IPRNo() As String
        Get
            Return _IPRNo
        End Get
        Set(ByVal value As String)
            _IPRNo = value
        End Set
    End Property

    Public Property IPRdate() As Date
        Get
            Return _IPRdate
        End Get
        Set(ByVal value As Date)
            _IPRdate = value
        End Set
    End Property
    Public Property StatusDate() As Date
        Get
            Return _StatusDate
        End Get
        Set(ByVal value As Date)
            _StatusDate = value
        End Set
    End Property
    Public Property PersonName() As String
        Get
            Return _PersonName
        End Get
        Set(ByVal value As String)
            _PersonName = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
#End Region
End Class
