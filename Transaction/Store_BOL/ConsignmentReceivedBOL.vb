Imports System.Data.SqlClient
Imports Store_DAL
Imports Store_PPT


Public Class ConsignmentReceivedBOL

    Public Function ConsignmentSave(ByVal objConsignmentSave As ConsignmentReceivedPPT) As DataSet

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.ConsignmentSave(objConsignmentSave)

    End Function

    Public Function ConsignmentUpdate(ByVal objConsignmentUpdate As ConsignmentReceivedPPT, ByVal IsStatusFromApproval As String) As DataSet

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.ConsignmentUpdate(objConsignmentUpdate, IsStatusFromApproval)

    End Function

    Public Shared Function ConsignmentDelete(ByVal objConsignmentDelete As ConsignmentReceivedPPT) As DataSet

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.ConsignmentDelete(objConsignmentDelete)

    End Function

    Public Function ConsignmentStockCodeGet(ByVal ObjConsignmentStockCodeGet As ConsignmentReceivedPPT, ByVal IsDirect As String) As DataSet

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.ConsignmentStockCodeGet(ObjConsignmentStockCodeGet, IsDirect)

    End Function

    Public Function GetConsignmentReceivedDetails(ByVal ConsignmentReceived As ConsignmentReceivedPPT) As DataTable

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.GetConsignmentReceivedDetails(ConsignmentReceived)

    End Function

    Public Function ReferenceNoIsExist(ByVal ObjRefNoisexist As ConsignmentReceivedPPT) As DataTable

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.ReferenceNoIsExist(ObjRefNoisexist)

    End Function

    Public Function Bind_cmbYearandMonth(ByVal objConsignmentReceived As ConsignmentReceivedPPT) As DataSet

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.Bind_cmbYearandMonth(objConsignmentReceived)

    End Function

    Public Function STConsignmentApproval(ByVal objConsignmentReceived As ConsignmentReceivedPPT) As Integer

        Dim objCRData As New ConsignmentReceivedDAL
        Return objCRData.STConsignmentApproval(objConsignmentReceived)

    End Function

End Class
