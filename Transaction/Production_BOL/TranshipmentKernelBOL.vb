Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
'Imports System.Data.SqlClient

Public Class TranshipmentKernelBOL

    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return TranshipmentKernelDAL.loadCmbStorage(CropYieldCode)
    End Function
    Public Shared Function DeleteMultiEntryProdTranship(ByVal objCPOPPT As TranshipmentKernelPPT) As Integer
        Dim ObjCPOProductionDAL As New TranshipmentKernelDAL
        Return ObjCPOProductionDAL.DeleteMultiEntryProdTranship(objCPOPPT)
    End Function
    Public Shared Function GetTankID(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.GetTankID(objKernelPPT)
    End Function

    Public Function EditDateCheck(ByVal objKernelPPT As TranshipmentKernelPPT) As Object
        Dim objKernelDAL As New TranshipmentKernelDAL
        Return objKernelDAL.EditDateCheck(objKernelPPT)
    End Function
    Public Function TransSearchDateCheck(ByVal objKernelPPT As TranshipmentKernelPPT) As Object
        Dim objKernelDAL As New TranshipmentKernelDAL
        Return objKernelDAL.TransSearchDateCheck(objKernelPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objKernelPPT As TranshipmentKernelPPT) As Object
        Dim objKernelDAL As New TranshipmentKernelDAL
        Return objKernelDAL.DuplicateDateCheck(objKernelPPT)
    End Function
    Public Function CompareCPOPTransDateIsExist(ByVal objKernelPPT As TranshipmentKernelPPT) As Object
        Dim objKernelDAL As New TranshipmentKernelDAL
        Return objKernelDAL.CompareCPOPTransDateIsExist(objKernelPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.GetLocationID(objKernelPPT)
    End Function

    Public Shared Function loadCmbLocation() As DataSet
        Return TranshipmentKernelDAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.GetCropYield(objKernelPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.GetCropYieldID(objKernelPPT)
    End Function

    Public Shared Function GetKernelAddTransInfo(ByVal objKernelPPT As TranshipmentKernelPPT) As DataTable
        Return TranshipmentKernelDAL.GetKernelAddTransInfo(objKernelPPT)
    End Function

    Public Shared Function saveKernelTransProduction(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.saveKernelTransProduction(objKernelPPT)
    End Function
    Public Shared Function saveKernelProduction(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.saveKernelProduction(objKernelPPT)
    End Function
    Public Shared Function UpdateKernelTransProduction(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.UpdateKernelTransProduction(objKernelPPT)
    End Function
    Public Shared Function GetKernelDetails(ByVal objKernelPPT As TranshipmentKernelPPT) As DataTable
        Dim objKernelDAL As New TranshipmentKernelDAL
        Return objKernelDAL.GetKernelDetails(objKernelPPT)
    End Function
    Public Function Delete_KernelDetail(ByVal objKernelPPT As TranshipmentKernelPPT) As Integer
        Dim objKernelDAL As New TranshipmentKernelDAL
        Return objKernelDAL.Delete_KernelDetail(objKernelPPT)
    End Function

    Public Shared Function KernelGetLoadTransMonthQty(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.KernelGetLoadTransMonthQty(objKernelPPT)
    End Function
    Public Shared Function KernelGetTranshipKernelMonthtodate(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.KernelGetTranshipKernelMonthtodate(objKernelPPT)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Return TranshipmentKernelDAL.ProductionCropYieldIDSelect(objKernelPPT)
    End Function

End Class
