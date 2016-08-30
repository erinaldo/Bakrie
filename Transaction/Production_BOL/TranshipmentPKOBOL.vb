Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
'Imports System.Data.SqlClient
Public Class TranshipmentPKOBOL

    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return TranshipmentPKODAL.loadCmbStorage(CropYieldCode)
    End Function

    Public Shared Function GetTankID(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.GetTankID(objPKOPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objPKOPPT As TranshipmentPKOPPT) As Object
        Dim objPKODAL As New TranshipmentPKODAL
        Return objPKODAL.DuplicateDateCheck(objPKOPPT)
    End Function

    Public Function CompareCPOPTransDateIsExist(ByVal objPKOPPT As TranshipmentPKOPPT) As Object
        Dim objPKODAL As New TranshipmentPKODAL
        Return objPKODAL.CompareCPOPTransDateIsExist(objPKOPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.GetLocationID(objPKOPPT)
    End Function

    Public Shared Function loadCmbLocation() As DataSet
        Return TranshipmentPKODAL.loadCmbLocation()
    End Function

    Public Shared Function loadCmbLocationPKO() As DataSet
        Return TranshipmentPKODAL.loadCmbLocationPKO()
    End Function

    Public Shared Function GetCropYield(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.GetCropYield(objPKOPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.GetCropYieldID(objPKOPPT)
    End Function

    Public Shared Function GetPKOAddTransInfo(ByVal objPKOPPT As TranshipmentPKOPPT) As DataTable
        Return TranshipmentPKODAL.GetPKOAddTransInfo(objPKOPPT)
    End Function
    Public Function EditDateCheck(ByVal objPKOPPT As TranshipmentPKOPPT) As Object
        Dim objPKODAL As New TranshipmentPKODAL
        Return objPKODAL.EditDateCheck(objPKOPPT)
    End Function

    Public Function TransSearchDateCheck(ByVal objPKOPPT As TranshipmentPKOPPT) As Object
        Dim objPKODAL As New TranshipmentPKODAL
        Return objPKODAL.TransSearchDateCheck(objPKOPPT)
    End Function
    Public Shared Function savePKOTransProduction(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.savePKOTransProduction(objPKOPPT)
    End Function
    Public Shared Function savePKOProduction(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.savePKOProduction(objPKOPPT)
    End Function
    Public Shared Function UpdatePKOTransProduction(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.UpdatePKOTransProduction(objPKOPPT)
    End Function
    Public Shared Function GetPKODetails(ByVal objPKOPPT As TranshipmentPKOPPT) As DataTable
        Dim objPKODAL As New TranshipmentPKODAL
        Return objPKODAL.GetPKODetails(objPKOPPT)
    End Function
    Public Function Delete_PKODetail(ByVal objPKOPPT As TranshipmentPKOPPT) As Integer
        Dim objPKODAL As New TranshipmentPKODAL
        Return objPKODAL.Delete_PKODetail(objPKOPPT)
    End Function

    Public Shared Function PKOGetLoadTransMonthQty(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.PKOGetLoadTransMonthQty(objPKOPPT)
    End Function
    Public Shared Function PKOGetTranshipPKOMonthtodate(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.PKOGetTranshipPKOMonthtodate(objPKOPPT)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Return TranshipmentPKODAL.ProductionCropYieldIDSelect(objPKOPPT)
    End Function
    Public Shared Function DeleteMultiEntryProdTranship(ByVal objPKOPPT As TranshipmentPKOPPT) As Integer
        Dim ObjPKOProductionDAL As New TranshipmentPKODAL
        Return ObjPKOProductionDAL.DeleteMultiEntryProdTranship(objPKOPPT)
    End Function

End Class
