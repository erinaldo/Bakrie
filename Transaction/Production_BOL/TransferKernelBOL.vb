Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
Public Class TransferKernelBOL

    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return TransferKernelDAL.loadCmbStorage(CropYieldCode)
    End Function
    Public Shared Function loadCmbKernalCodeDesc() As DataSet
        Return TransferKernelDAL.loadCmbKernalCodeDesc()
    End Function
    Public Shared Function GetTankID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.GetTankID(objKernelPPT)
    End Function
    Public Function EditDateCheck(ByVal objKernelPPT As TransferKernelPPT) As Object
        Dim objKernelDAL As New TransferKernelDAL
        Return objKernelDAL.EditDateCheck(objKernelPPT)
    End Function

    Public Function SearchDateCheck(ByVal objKernelPPT As TransferKernelPPT) As Object
        Dim objKernelDAL As New TransferKernelDAL
        Return objKernelDAL.SearchDateCheck(objKernelPPT)
    End Function
    Public Shared Function GetProductionID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.GetProductionID(objKernelPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objKernelPPT As TransferKernelPPT) As Object
        Dim objKernelDAL As New TransferKernelDAL
        Return objKernelDAL.DuplicateDateCheck(objKernelPPT)
    End Function

    Public Function CompareCPOPLoadingDateIsExist(ByVal objKernelPPT As TransferKernelPPT) As Object
        Dim objKernelDAL As New TransferKernelDAL
        Return objKernelDAL.CompareCPOPLoadingDateIsExist(objKernelPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.GetLocationID(objKernelPPT)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Return TransferKernelDAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.GetCropYield(objKernelPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.GetCropYieldID(objKernelPPT)
    End Function
    Public Shared Function GetKernelAddLoadInfo(ByVal objKernelPPT As TransferKernelPPT) As DataTable
        Return TransferKernelDAL.GetKernelAddLoadInfo(objKernelPPT)
    End Function
    Public Shared Function saveKernelLoadProduction(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.saveKernelLoadProduction(objKernelPPT)
    End Function

    Public Shared Function UpdateKernelLoadProduction(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.UpdateKernelLoadProduction(objKernelPPT)
    End Function

    Public Shared Function GetKernelDetails(ByVal objKernelPPT As TransferKernelPPT) As DataTable
        Dim objKernelDAL As New TransferKernelDAL
        Return objKernelDAL.GetKernelDetails(objKernelPPT)
    End Function
    Public Function Delete_KernelDetail(ByVal objKernelPPT As TransferKernelPPT) As Integer
        Dim objKernelDAL As New TransferKernelDAL
        Return objKernelDAL.Delete_KernelDetail(objKernelPPT)
    End Function

    Public Shared Function KernelGetLoadTransMonthQty(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.KernelGetLoadTransMonthQty(objKernelPPT)
    End Function

    Public Shared Function KernelGetLoadingKernelMonthtodate(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.KernelGetLoadingKernelMonthtodate(objKernelPPT)
    End Function
    Public Shared Function ProductionCropYieldIDSelect(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Return TransferKernelDAL.ProductionCropYieldIDSelect(objKernelPPT)
    End Function

    Public Shared Function DeleteMultiEntryProdLoading(ByVal objKernelPPT As TransferKernelPPT) As Integer
        Dim ObjKernelProductionDAL As New TransferKernelDAL
        Return ObjKernelProductionDAL.DeleteMultiEntryProdLoading(objKernelPPT)
    End Function


End Class
