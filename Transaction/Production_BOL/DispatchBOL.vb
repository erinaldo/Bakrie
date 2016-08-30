Imports Production_DAL
Imports Production_PPT

Public Class DispatchBOL

    Public Shared Function SaveDispatch(ByVal objDispatchPPT As DispatchPPT, Optional isKernel As Boolean = False) As DataSet
        Return DispatchDAL.SaveDispatch(objDispatchPPT, isKernel)
    End Function
    Public Shared Function UpdateDispatch(ByVal objDispatchPPT As DispatchPPT, Optional isKernel As Boolean = False) As DataSet
        Return DispatchDAL.UpdateDispatch(objDispatchPPT, isKernel)
    End Function

    Public Shared Function UpDateDispatchDetail(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Return DispatchDAL.UpDateDispatchDetail(objDispatchPPT)
    End Function
    Public Shared Function SaveDispatchDetail(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Return DispatchDAL.SaveDispatchDetail(objDispatchPPT)
    End Function

    Public Shared Function GetTankMaster() As DataTable
        Dim objDispatchDal As New DispatchDAL
        Return objDispatchDal.GetTankMaster()
    End Function

    Public Shared Function GetKernelStorage() As DataTable
        Dim objDispatchDal As New DispatchDAL
        Return objDispatchDal.GetKernelStorage()
    End Function

    Public Shared Function GetLocationValues(ByVal objDispatchPPT As DispatchPPT) As DataTable
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.GetLocationValues(objDispatchPPT)
    End Function
    Public Shared Function GetProductIDValues(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.GetProductIDValues(objDispatchPPT)
    End Function

    Public Function DuplicateDateCheck(ByVal objDispatchPPT As DispatchPPT) As Object
        Dim objDispatchDAL As New DispatchDAL
        Return objDispatchDAL.DuplicateDateCheck(objDispatchPPT)
    End Function

    Public Shared Function GetDispatchValues(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.GetDispatchValues(objDispatchPPT)
    End Function

    Public Shared Function GetDispatchDetailValues(ByVal objDispatchPPT As DispatchPPT) As DataTable
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.GetDispatchDetailValues(objDispatchPPT)
    End Function

    Public Function DeleteDispatch(ByVal objDispatchPPT As DispatchPPT, Optional isKernel As Boolean = False) As Integer
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.DeleteDispatch(objDispatchPPT, isKernel)
    End Function

    Public Function DispatchRecordIsExist(ByVal objDispatchPPT As DispatchPPT) As Object
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.DispatchRecordIsExist(objDispatchPPT)
    End Function

    Public Shared Function GetCPOLoading(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.GetCPOLoading(objDispatchPPT)
    End Function
    Public Shared Function CPOLoading_Reporting(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.CPOLoading_Reporting(objDispatchPPT)
    End Function

    Public Shared Function GetPKOLoading(ByVal objDispatchPPT As DispatchPPT) As DataSet
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.GetPKOLoading(objDispatchPPT)
    End Function

    Public Shared Function DeleteMultiEntryCPOPKOKernel(ByVal objDispatchPPT As DispatchPPT) As Integer
        Dim ObjDispatchDAL As New DispatchDAL
        Return ObjDispatchDAL.DeleteMultiEntryCPOPKOKernel(objDispatchPPT)
    End Function
End Class
