Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
'Imports System.Data.SqlClient

Public Class TranshipmentCPOBOL


    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return TranshipmentCPODAL.loadCmbStorage(CropYieldCode)
    End Function
    Public Shared Function DeleteMultiEntryProdTranship(ByVal objCPOPPT As TranshipmentCPOPPT) As Integer
        Dim ObjCPOProductionDAL As New TranshipmentCPODAL
        Return ObjCPOProductionDAL.DeleteMultiEntryProdTranship(objCPOPPT)
    End Function
    Public Function EditDateCheck(ByVal objCPOPPT As TranshipmentCPOPPT) As Object
        Dim objCPODAL As New TranshipmentCPODAL
        Return objCPODAL.EditDateCheck(objCPOPPT)
    End Function

    Public Function TransSearchDateCheck(ByVal objCPOPPT As TranshipmentCPOPPT) As Object
        Dim objCPODAL As New TranshipmentCPODAL
        Return objCPODAL.TransSearchDateCheck(objCPOPPT)
    End Function

    Public Shared Function GetTankID(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.GetTankID(objCPOPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objCPOPPT As TranshipmentCPOPPT) As Object
        Dim objCPODAL As New TranshipmentCPODAL
        Return objCPODAL.DuplicateDateCheck(objCPOPPT)
    End Function
    Public Function CompareCPOPTransDateIsExist(ByVal objCPOPPT As TranshipmentCPOPPT) As Object
        Dim objCPODAL As New TranshipmentCPODAL
        Return objCPODAL.CompareCPOPTransDateIsExist(objCPOPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.GetLocationID(objCPOPPT)
    End Function
    
    Public Shared Function loadCmbLocation() As DataSet
        Return TranshipmentCPODAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.GetCropYield(objCPOPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.GetCropYieldID(objCPOPPT)
    End Function
    
    Public Shared Function GetCPOAddTransInfo(ByVal objCPOPPT As TranshipmentCPOPPT) As DataTable
        Return TranshipmentCPODAL.GetCPOAddTransInfo(objCPOPPT)
    End Function
   
    Public Shared Function saveCPOTransProduction(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.saveCPOTransProduction(objCPOPPT)
    End Function
    Public Shared Function saveCPOProduction(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.saveCPOProduction(objCPOPPT)
    End Function
    Public Shared Function UpdateCPOTransProduction(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.UpdateCPOTransProduction(objCPOPPT)
    End Function
    Public Shared Function GetCPODetails(ByVal objCPOPPT As TranshipmentCPOPPT) As DataTable
        Dim objCPODAL As New TranshipmentCPODAL
        Return objCPODAL.GetCPODetails(objCPOPPT)
    End Function
    Public Function Delete_CPODetail(ByVal objCPOPPT As TranshipmentCPOPPT) As Integer
        Dim objCPODAL As New TranshipmentCPODAL
        Return objCPODAL.Delete_CPODetail(objCPOPPT)
    End Function
    
    Public Shared Function CPOGetLoadTransMonthQty(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.CPOGetLoadTransMonthQty(objCPOPPT)
    End Function
    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.CPOGetTranshipCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Return TranshipmentCPODAL.ProductionCropYieldIDSelect(objCPOPPT)
    End Function
End Class
