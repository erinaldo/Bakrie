Public Class DistribusiBiayaBengkelReportPPT
#Region "Private Member Declarations"


    Private _Task As String = String.Empty
    Private _AYear As Integer
    Private _AMonth As String = String.Empty
    Private _strActMthYearID As String = String.Empty

#End Region


#Region "Public Member Declarations"

    Public Property Task() As String
        Get
            Return _Task
        End Get
        Set(ByVal value As String)
            _Task = value
        End Set
    End Property

    Public Property AYear() As Integer
        Get
            Return _AYear
        End Get
        Set(ByVal value As Integer)
            _AYear = value
        End Set
    End Property
    Public Property AMonth() As String
        Get
            Return _AMonth
        End Get
        Set(ByVal value As String)
            _AMonth = value
        End Set
    End Property
    Public Property strActMthYearID() As String
        Get
            Return _strActMthYearID
        End Get
        Set(ByVal value As String)
            _strActMthYearID = value
        End Set
    End Property
#End Region
End Class
