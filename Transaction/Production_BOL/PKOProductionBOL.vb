Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
'Imports System.Data.SqlClient
Public Class PKOProductionBOL
    Public Shared Function loadCmbStorage() As DataSet
        Return PKOProductionDAL.loadCmbStorage()
    End Function
    Public Shared Function GetTankID(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.GetTankID(objPKOPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.GetLocationID(objPKOPPT)
    End Function
    Public Shared Function tankDetailSelect(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.tankDetailSelect(objPKOPPT)
    End Function
    Public Shared Function UpdateTankMasterBFQty(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.UpdateTankMasterBFQty(objPKOPPT)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Return PKOProductionDAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.GetCropYield(objPKOPPT)
    End Function
    Public Shared Function GetPKOAddInfo(ByVal objPKOPPT As PKOProductionPPT) As DataTable
        Return PKOProductionDAL.GetPKOAddInfo(objPKOPPT)
    End Function
    Public Shared Function savePKOProduction(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.savePKOProduction(objPKOPPT)
    End Function
    Public Shared Function UpdatePKOProduction(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.UpdatePKOProduction(objPKOPPT)
    End Function
    Public Shared Function GetPKODetails(ByVal objPKOPPT As PKOProductionPPT) As DataTable
        Dim objPKODAL As New PKOProductionDAL
        Return objPKODAL.GetPKODetails(objPKOPPT)
    End Function
    Public Function Delete_PKODetail(ByVal objPKOPPT As PKOProductionPPT) As Integer
        Dim objPKODAL As New PKOProductionDAL
        Return objPKODAL.Delete_PKODetail(objPKOPPT)
    End Function

    ''Changed by kumar
    Public Shared Function loadCmbStorageBalanceBF(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.loadCmbStorageBalanceBF(objCPOPPT)
    End Function

    ''Changed by kumar
    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.CPOGetLoadingCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.CPOGetTranshipCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function CPOProductionMonthYeartodate(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.CPOProductionMonthYeartodate(objCPOPPT)
    End Function
    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Return PKOProductionDAL.ProductionCropYieldIDSelect(objCPOPPT)
    End Function

    Public Function DuplicateDateCheck(ByVal objCPOPPT As PKOProductionPPT) As Object
        Dim objCPODAL As New PKOProductionDAL
        Return objCPODAL.DuplicateDateCheck(objCPOPPT)
    End Function
End Class
