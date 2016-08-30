Imports WeighBridge_DAL
Imports WeighBridge_PPT
Imports System.Data.SqlClient
Public Class WBTicketNoConfigurationBOL

    Public Function WBTicketNoConfiguration_Select(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As DataTable
        Dim objWBTNCDAL As New WBTicketNoConfigurationDAL
        Return objWBTNCDAL.WBTicketNoConfiguration_Select(objWBTNCPPT)
    End Function

    Public Function WBTicketNoConfigurationID_isExist(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As DataTable
        Dim objWBTNCDAL As New WBTicketNoConfigurationDAL
        Return objWBTNCDAL.WBTicketNoConfigurationID_isExist(objWBTNCPPT)
    End Function

    Public Function Save_WBTicketNoConfiguration(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As DataTable
        Dim objWBTNCDAL As New WBTicketNoConfigurationDAL
        Return objWBTNCDAL.Save_WBTicketNoConfiguration(objWBTNCPPT)
    End Function

    Public Function UpdateWBTicketNo_Password(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As Integer
        Dim objWBTNCDAL As New WBTicketNoConfigurationDAL
        Return objWBTNCDAL.UpdateWBTicketNo_Password(objWBTNCPPT)
    End Function
End Class
