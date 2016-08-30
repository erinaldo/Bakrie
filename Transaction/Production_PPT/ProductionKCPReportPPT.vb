
Public Class ProductionKCPReportPPT

#Region "Private Member Declarations"


    Private _PKOProductionLogID As String = String.Empty
   
#End Region


#Region "Public Member Declarations"

    Public Property PKOProductionLogID() As String
        Get
            Return _PKOProductionLogID
        End Get
        Set(ByVal value As String)
            _PKOProductionLogID = value
        End Set
    End Property

#End Region

End Class
