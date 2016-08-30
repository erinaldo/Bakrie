Imports System.Data.SqlClient
Imports Store_DAL
Imports Store_PPT


Public Class InternalServiceRequisitionBOL
    Public Function GetISRNo(ByVal objISRNo As InternalServiceRequisitionPPT) As InternalServiceRequisitionPPT
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.GetISRNo(objISRNo)
    End Function

    Public Shared Function Save_ISRDetail(ByVal objISRSave As InternalServiceRequisitionPPT) As DataSet
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.Save_ISRDetail(objISRSave)
    End Function

    Public Shared Function Save_ISR(ByVal objISRSaveDetail As InternalServiceRequisitionPPT) As DataSet
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.Save_ISR(objISRSaveDetail)
    End Function

    Public Shared Function Update_ISR(ByVal objISRUpdate As InternalServiceRequisitionPPT) As DataSet
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.Update_ISR(objISRUpdate)
    End Function
    Public Shared Function Update_ISRDetail(ByVal objISRUpdateDetail As InternalServiceRequisitionPPT) As DataTable
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.Update_ISRDetail(objISRUpdateDetail)
    End Function

    Public Function GetISRDetails(ByVal objISRPPT As InternalServiceRequisitionPPT) As DataTable
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.GetISRDetails(objISRPPT)
    End Function
    Public Function ISRDetailsGet(ByVal objISRPPT As InternalServiceRequisitionPPT) As DataTable
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.ISRDetailsGet(objISRPPT)
    End Function

    Public Shared Function AcctlookupSearch(ByVal objISRPPT As InternalServiceRequisitionPPT, ByVal IsDirect As String) As DataSet

        Return InternalServiceRequisitionDAL.AcctlookupSearch(objISRPPT, IsDirect)

    End Function

    Public Shared Function ISRViewDelete(ByVal objISRViewDel As InternalServiceRequisitionPPT) As DataSet
        Return InternalServiceRequisitionDAL.ISRViewDelete(objISRViewDel)
    End Function

    Public Shared Function CURRENCYTYPEGET(ByVal objISRPPT As InternalServiceRequisitionPPT) As DataTable

        Return InternalServiceRequisitionDAL.CURRENCYTYPEGET(objISRPPT)
    End Function

    Public Function ISRRecordIsExisT(ByVal objISRPPT As InternalServiceRequisitionPPT) As Object
        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.ISRRecordIsExist(objISRPPT)
    End Function

    Public Function DeleteMultiEntryISR(ByVal ObjISRPPT As InternalServiceRequisitionPPT) As Integer

        Dim objISRData As New InternalServiceRequisitionDAL
        Return objISRData.DeleteMultiEntryISR(ObjISRPPT)

    End Function

End Class
