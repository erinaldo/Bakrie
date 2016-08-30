Imports WeighBridge_DAL
Imports WeighBridge_PPT
Imports System.Data.SqlClient
Public Class WBWeighingInOutBOL

    Public Function WBTicketNo_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBTicketNo_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBTicketNo_isExist(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBTicketNo_isExist(objWBWeighingInOutPPT)
    End Function

    Public Function Save_WBWeighingInOut(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.Save_WBWeighingInOut(objWBWeighingInOutPPT)
    End Function

    Public Function Update_WBWeighingInOut(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.Update_WBWeighingInOut(objWBWeighingInOutPPT)
    End Function

    Public Function Save_WBWeighingBlockDetail(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.Save_WBWeighingBlockDetail(objWBWeighingInOutPPT)
    End Function

    Public Function Delete_WBWeighingBlockDetail(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.Delete_WBWeighingBlockDetail(objWBWeighingInOutPPT)
    End Function

    Public Function Update_WBWeighingBlockDetail(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.Update_WBWeighingBlockDetail(objWBWeighingInOutPPT)
    End Function

    Public Function WeighingID_isExistInGradingFFB(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WeighingID_isExistInGradingFFB(objWBWeighingInOutPPT)
    End Function

    Public Function Delete_WBWeighingInOut(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.Delete_WBWeighingInOut(objWBWeighingInOutPPT)
    End Function

    Public Function NoofTrip_Get(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.NoofTrip_Get(objWBWeighingInOutPPT)
    End Function

    Public Function WBSupplier_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBSupplier_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBVehicleCode_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBVehicleCode_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBProductCode_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBProductCode_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOut_DivisionGet(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOut_DivisionGet(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOut_YOPGet(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOut_YOPGet(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOut_BlockGet(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOut_BlockGet(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOut_BlockGetII(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOut_BlockGetII(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOut_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOut_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOutDetail_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOutDetail_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOut_Reporting(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOut_Reporting(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOutSecurity_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOutSecurity_Select(objWBWeighingInOutPPT)
    End Function

    Public Function WBTicketNoRecord_isExist(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBTicketNoRecord_isExist(objWBWeighingInOutPPT)
    End Function

    Public Shared Function FiscalYearDate_Get(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.FiscalYearDate_Get(objWBWeighingInOutPPT)
    End Function

    Public Function WBTicket_Report(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBTicket_Report(objWBWeighingInOutPPT)
    End Function

    Public Function WBWeighingInOutDetail_GetRecord(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBWeighingInOutDetail_GetRecord(objWBWeighingInOutPPT)
    End Function

    Public Function WBTPH_Select(ByVal FieldBlockSetupID As String) As DataTable
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        Return objWBWeighingInOutDAL.WBTPH_Select(FieldBlockSetupID)
    End Function

    Public Sub UpdateAllocatedWeightBlock(ByVal WeighingID As String)
        Dim objWBWeighingInOutDAL As New WBWeighingInOutDAL
        objWBWeighingInOutDAL.UpdateAllocatedWeightBlock(WeighingID)
    End Sub
End Class
