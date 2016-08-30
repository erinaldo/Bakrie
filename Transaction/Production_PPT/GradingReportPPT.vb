Public Class GradingReportPPT
#Region "Private Member Declarations"

 
    Private _AYear As Integer
    Private _AMonth As Integer
    Private _GradingDate As Date
    Private _WBTicketNo As String = String.Empty
    Private _BGradingDate As Boolean = False
    Private _WeighingID As String = String.Empty
    Private _AMYID As String = String.Empty


#End Region

#Region "Public Member Declarations"


    Public Property AYear() As Integer
        Get
            Return _AYear
        End Get
        Set(ByVal value As Integer)
            _AYear = value
        End Set
    End Property
    Public Property AMonth() As Integer
        Get
            Return _AMonth
        End Get
        Set(ByVal value As Integer)
            _AMonth = value
        End Set
    End Property
    Public Property GradingDate() As Date
        Get
            Return _GradingDate
        End Get
        Set(ByVal value As Date)
            _GradingDate = value
        End Set
    End Property
    Public Property WBTicketNo() As String
        Get
            Return _WBTicketNo
        End Get
        Set(ByVal value As String)
            _WBTicketNo = value
        End Set
    End Property
    Public Property BGradingDate() As Boolean
        Get
            Return _BGradingDate
        End Get
        Set(ByVal value As Boolean)
            _BGradingDate = value
        End Set
    End Property
    Public Property WeighingID() As String
        Get
            Return _WeighingID
        End Get
        Set(ByVal value As String)
            _WeighingID = value
        End Set
    End Property

    Public Property AMYID() As String
        Get
            Return _AMYID
        End Get
        Set(ByVal value As String)
            _AMYID = value
        End Set
    End Property

#End Region
End Class
