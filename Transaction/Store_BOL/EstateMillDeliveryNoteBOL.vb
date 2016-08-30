Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient

Public Class EstateMillDeliveryNoteBOL
    Public Function SearchIPRNo(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.SearchIPRNo(objEMDNPPT)
    End Function
    Public Function SearchLPONo(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.SearchLPONo(objEMDNPPT)
    End Function

    Public Function STMillDeliveryIPRNoGet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.STMillDeliveryIPRNoGet(objEMDNPPT)
    End Function

    Public Function STMillDeliveryLPONoGet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.STMillDeliveryLPONoGet(objEMDNPPT)
    End Function

    Public Function STMillDeliveryPONoGet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.STMillDeliveryPONoGet(objEMDNPPT)
    End Function

    Public Function SearchSupplier(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.SearchSupplier(objEMDNPPT)
    End Function

    Public Function GetIDNDetails_IPR(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.GetIDNDetails_IPR(objEMDNPPT)
    End Function

    Public Function IDNView_Select(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.IDNView_Select(objEMDNPPT)
    End Function

    Public Function IDN_isExist(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.IDN_isExist(objEMDNPPT)
    End Function

    Public Function Stock_isExist(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.Stock_isExist(objEMDNPPT)
    End Function

    Public Function Save_STMillDelivery(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.Save_STMillDelivery(objEMDNPPT)
    End Function

    Public Function Update_STMillDelivery(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.Update_STMillDelivery(objEMDNPPT)
    End Function


    'Public Function STMillDeleivID_GetMax(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
    '    Dim objEMDNDAL As New EstateMillDeliverNoteDAL
    '    Return objEMDNDAL.STMillDeleivID_GetMax(objEMDNPPT)
    'End Function

    Public Function Save_EstMillDeliveryDet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.Save_EstMillDeliveryDet(objEMDNPPT)
    End Function

    Public Function Update_EstMillDeliveryDet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.Update_EstMillDeliveryDet(objEMDNPPT)
    End Function

    Public Function IDNDetails_Select(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.IDNDetails_Select(objEMDNPPT)
    End Function

    Public Function Delete_STMillDeliveryDelete(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.Delete_STMillDeliveryDelete(objEMDNPPT)
    End Function

    Public Function EMDNRecordIsExisT(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Object
        Dim objEMDNDAL As New EstateMillDeliverNoteDAL
        Return objEMDNDAL.EstMillDeliveryRecordIsExist(objEMDNPPT)
    End Function

    

End Class
