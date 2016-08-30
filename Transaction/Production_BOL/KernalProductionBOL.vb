Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
Public Class KernalProductionBOL
    Public Shared Function loadCmbKernalStorage() As DataSet
        Return KernalProductionDAL.loadCmbKernalStorage()
    End Function
    Public Shared Function loadCmbKernalCodeDesc() As DataSet
        Return KernalProductionDAL.loadCmbKernalCodeDesc()
    End Function
    Public Shared Function GetTankID(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.GetTankID(objKernalPPT)
    End Function
    Public Shared Function GetKernalID(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.GetKernalID(objKernalPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.GetLocationID(objKernalPPT)
    End Function
    Public Shared Function tankDetailSelect(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.tankDetailSelect(objKernalPPT)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Return KernalProductionDAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.GetCropYield(objKernalPPT)
    End Function
    Public Shared Function GetKernelTransAddInfo(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Return KernalProductionDAL.GetKernelTransAddInfo(objKernalPPT)
    End Function
    Public Shared Function GetKernelLoadAddInfo(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Return KernalProductionDAL.GetKernelLoadAddInfo(objKernalPPT)
    End Function
    Public Shared Function GetKernalAddInfo(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Return KernalProductionDAL.GetKernalAddInfo(objKernalPPT)
    End Function
    Public Shared Function saveKernalProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.saveKernalProduction(objKernalPPT)
    End Function
    Public Shared Function saveKernalStockProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.saveKernalStockProduction(objKernalPPT)
    End Function
    Public Shared Function saveKernalLoadProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.saveKernalLoadProduction(objKernalPPT)
    End Function
    Public Shared Function saveKernalTransProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.saveKernalTransProduction(objKernalPPT)
    End Function
    Public Shared Function UpdateKernalProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.UpdateKernalProduction(objKernalPPT)
    End Function
    Public Shared Function UpdateKernalStockProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.UpdateKernalStockProduction(objKernalPPT)
    End Function
    Public Shared Function UpdateKernalLoadProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.UpdateKernalLoadProduction(objKernalPPT)
    End Function
    Public Shared Function UpdateKernalTransProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.UpdateKernalTransProduction(objKernalPPT)
    End Function
    Public Shared Function GetKernalDetails(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Dim objKernalDAL As New KernalProductionDAL
        Return objKernalDAL.GetKernalDetails(objKernalPPT)
    End Function
    Public Function Delete_KernalDetail(ByVal objKernalPPT As KernalProductionPPT) As Integer
        Dim objKernalDAL As New KernalProductionDAL
        Return objKernalDAL.Delete_KernalDetail(objKernalPPT)
    End Function
    Public Shared Function KernalDetailSelect(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.KernalDetailSelect(objKernalPPT)
    End Function
    Public Shared Function UpdateTankMasterBFQty(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.UpdateTankMasterBFQty(objKernalPPT)
    End Function
    Public Shared Function KernelGetLoadVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return KernalProductionDAL.KernelGetLoadVsLocMonthQty(objCPOPPT)
    End Function
    Public Shared Function KernelGetTransVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return KernalProductionDAL.KernelGetTransVsLocMonthQty(objCPOPPT)
    End Function

    ''Changed by kumar
    Public Shared Function loadCmbStorageBalanceBF(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.loadCmbStorageBalanceBF(objCPOPPT)
    End Function

    ''Changed by kumar
    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.CPOGetLoadingCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.CPOGetTranshipCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function CPOProductionMonthYeartodate(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.CPOProductionMonthYeartodate(objCPOPPT)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Return KernalProductionDAL.ProductionCropYieldIDSelect(objCPOPPT)
    End Function

    Public Function DuplicateDateCheck(ByVal objCPOPPT As KernalProductionPPT) As Object
        Dim objCPODAL As New KernalProductionDAL
        Return objCPODAL.DuplicateDateCheck(objCPOPPT)
    End Function
End Class

