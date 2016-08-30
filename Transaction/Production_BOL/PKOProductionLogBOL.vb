Imports Production_DAL
Imports Production_PPT

Public Class PKOProductionLogBOL

    Public Shared Function SaveProductionPKOLog(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.SaveProductionPKOLog(objPKOProductionLogPPT)
    End Function
    Public Shared Function SaveProductionPKOLogShift(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.SaveProductionPKOLogShift(objPKOProductionLogPPT)
    End Function
    Public Shared Function SaveProductionPKOLogPress(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.SaveProductionPKOLogPress(objPKOProductionLogPPT)
    End Function
    Public Shared Function SaveProductionPKOKERReceived(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.SaveProductionPKOKERReceived(objPKOProductionLogPPT)
    End Function

    Public Function UpdateProductionPKOLog(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.UpDatePKOProductionLog(objPKOProductionLogPPT)
    End Function
    Public Function UpdateProductionPKOLogShift(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.UpdateProductionPKOLogShift(objPKOProductionLogPPT)
    End Function

    Public Function UpdateProductionPKOLogPress(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.UpdateProductionPKOLogPress(objPKOProductionLogPPT)
    End Function
    Public Function UpdateProductionPKOKERReceived(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.UpdateProductionPKOKERReceived(objPKOProductionLogPPT)
    End Function

    Public Function DeleteProductionPKOLog(ByVal objProductionPKOLogPPT As PKOProductionLogPPT) As Integer
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.DeletePKOProductionLog(objProductionPKOLogPPT)
    End Function
    Public Shared Function GetPKOProductionLogShiftSelect(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogShiftSelect(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetMonthValues(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetMonthValues(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetMonthYearValues(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetMonthYearValues(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetYearValues(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetYearValues(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetKernelProductionStorage(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetKernelProductionStorage(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProdLogLoadingLocation(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProdLogLoadingLocation(objPKOProductionLogPPT)
    End Function

    Public Shared Function DuplicatePKOProductionDate(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As Object
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.DuplicatePKOProductionDate(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetQuantityForCorrespondigLocation(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As Object
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetQuantityForCorrespondigLocation(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionLogPressMonthValue(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPressMonthValue(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetPKOProductionLogPressYearValue(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPressYearValue(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionLog(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLog(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetPKOProductionLogKerReceived(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogKerReceived(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetPKOProductionLogPress(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPress(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionLogPressOPHrsValue(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPressOPHrsValue(objPKOProductionLogPPT)
    End Function
    Public Shared Function PKOProductionlogPKOMonthYearValueSelect(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionlogPKOMonthYearValueSelect(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionlogPKOMonthYearValue(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionlogPKOMonthYearValue(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetPKOProductionlogPKOTodayValue(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionlogPKOTodayValue(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetProductionPKOlogPressNo(ByVal objPKOProductionLogPPT As PKOProductionLogPPT, ByVal IsDirect As String, ByVal Type As String) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetProductionPKOlogPressNo(objPKOProductionLogPPT, IsDirect, Type)
    End Function
    Public Shared Function GetPKOProductionlogCropYieldID(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionlogCropYieldID(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionLogKerRecdMonthValueSelect(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogKerRecdMonthValueSelect(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetPKOProductionLogKerRecdMonthValueCheckSelect(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogKerRecdMonthValueCheckSelect(objPKOProductionLogPPT)
    End Function
    Public Shared Function PKOGetMonthYearQty(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.PKOGetMonthYearQty(objPKOProductionLogPPT)
    End Function

    ''For Press Tab summary''''''

    Public Shared Function SavePKOProductionPressSummary(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.SavePKOProductionPressSummary(objPKOProductionLogPPT)
    End Function

    Public Function UpdatePKOProductionPressSummary(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.UpdatePKOProductionPressSummary(objPKOProductionLogPPT)
    End Function

    Public Shared Function PKOGetMonthYearQtySumm(ByVal objPKOLogPPT As PKOProductionLogPPT) As DataSet
        Return PKOProductionLogDAL.PKOGetMonthYearQtySumm(objPKOLogPPT)
    End Function

    Public Shared Function PKOProductionLogPressMultiEntryDelete(ByVal objPKOPPT As PKOProductionLogPPT) As Integer
        Dim ObjPKOProductionLogDAL As New PKOProductionLogDAL
        Return ObjPKOProductionLogDAL.PKOProductionLogPressMultiEntryDelete(objPKOPPT)
    End Function


    Public Shared Function PKOProductionKerRecdMultiEntryDelete(ByVal objPKOPPT As PKOProductionLogPPT) As Integer
        Dim ObjPKOProductionLogDAL As New PKOProductionLogDAL
        Return ObjPKOProductionLogDAL.PKOProductionKerRecdMultiEntryDelete(objPKOPPT)
    End Function


End Class
