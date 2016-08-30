Imports Production_DAL
Imports Production_PPT
Public Class CPOProductionLogBOL
    Public Shared Function CPOGetMonthYearQty(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearQty(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearQtyCheck(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearQtyCheck(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetFFBNetWeight(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetFFBNetWeight(objCPOLogPPT)
    End Function
    Public Shared Function CPOLogFFBLorryProcessed(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOLogFFBLorryProcessed(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetTodayQtyForOERCPO(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetTodayQtyForOERCPO(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetTodayQtyForOERKernel(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetTodayQtyForOERKernel(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearElectricalBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearElectricalBD(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearEPHours(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearEPHours(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearFFB(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearFFB(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearHrs(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearHrs(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearKER(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearKER(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearLorry(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearLorry(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearLorryWeight(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearLorryWeight(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearLossKernel(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearLossKernel(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearMechanicalBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearMechanicalBD(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearOER(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearOER(objCPOLogPPT)
    End Function

    Public Shared Function CPOGetMonthYearProcessingBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearProcessingBD(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearThroughput(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearThroughput(objCPOLogPPT)
    End Function
    Public Shared Function CPOGetMonthYearTotalBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearTotalBD(objCPOLogPPT)
    End Function
    Public Shared Function saveCPOLogProduction(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.saveCPOLogProduction(objCPOLogPPT)
    End Function
    Public Shared Function saveCPOLogShift(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.saveCPOLogShift(objCPOLogPPT)
    End Function
    Public Shared Function GetCPOLogDetails(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataTable
        Dim objCPOLogDAL As New CPOProductionLogDAL
        Return objCPOLogDAL.GetCPOLogDetails(objCPOLogPPT)
    End Function
    Public Shared Function UpdateCPOProductionLog(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.UpdateCPOProductionLog(objCPOLogPPT)
    End Function
    Public Shared Function UpdateCPOLogShift(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.UpdateCPOLogShift(objCPOLogPPT)
    End Function
    Public Shared Function GetCPOLogShiftInfo(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.GetCPOLogShiftInfo(objCPOLogPPT)
    End Function
    Public Function Delete_CPOLogDetail(ByVal objCPOLogPPT As CPOProductionLogPPT) As Integer
        Dim objCPOLogDAL As New CPOProductionLogDAL
        Return objCPOLogDAL.Delete_CPOLogDetail(objCPOLogPPT)
    End Function
    Public Shared Function DuplicateDateCheck(ByVal objCPOLogPPT As CPOProductionLogPPT) As Object
        Return CPOProductionLogDAL.DuplicateDateCheck(objCPOLogPPT)
    End Function
    'Public Function DuplicateShiftCheck(ByVal objCPOLogPPT As CPOProductionLogPPT) As Object
    '    Dim objCPOLogDAL As New CPOProductionLogDAL
    '    Return objCPOLogDAL.DuplicateShiftCheck(objCPOLogPPT)
    'End Function

    ''For Press Tab''''''

    Public Shared Function SaveProductionCPOLogPress(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.SaveProductionCPOLogPress(objCPOProductionLogPPT)
    End Function

    Public Function UpdateProductionCPOLogPress(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.UpdateProductionCPOLogPress(objCPOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionLogPressMonthValue(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPressMonthValue(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetCPOProductionLogPressYearValue(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objProductionCPOLogDAL As New CPOProductionLogDAL
        Return objProductionCPOLogDAL.GetCPOProductionLogPressYearValue(objCPOProductionLogPPT)
    End Function
    Public Shared Function GetPKOProductionLogPress(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPress(objPKOProductionLogPPT)
    End Function

    Public Shared Function GetPKOProductionLogPressOPHrsValue(ByVal objPKOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objProductionPKOLogDAL As New CPOProductionLogDAL
        Return objProductionPKOLogDAL.GetPKOProductionLogPressOPHrsValue(objPKOProductionLogPPT)
    End Function
    Public Shared Function GetProductionPKOlogPressNo(ByVal objPKOProductionLogPPT As PKOProductionLogPPT, ByVal IsDirect As String, ByVal Type As String) As DataSet
        Dim objProductionPKOLogDAL As New PKOProductionLogDAL
        Return objProductionPKOLogDAL.GetProductionPKOlogPressNo(objPKOProductionLogPPT, IsDirect, Type)
    End Function
    Public Shared Function GetCPOProductionlogCPOTodayValue(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objProductionCPOLogDAL As New CPOProductionLogDAL
        Return objProductionCPOLogDAL.GetCPOProductionlogCPOTodayValue(objCPOProductionLogPPT)
    End Function
    Public Shared Function GetCPOProductionLogPressMonthValue(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objProductionCPOLogDAL As New CPOProductionLogDAL
        Return objProductionCPOLogDAL.GetCPOProductionLogPressMonthValue(objCPOProductionLogPPT)
    End Function
    Public Shared Function GetCPOProductionLogPress(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataTable
        Dim objProductionCPOLogDAL As New CPOProductionLogDAL
        Return objProductionCPOLogDAL.GetCPOProductionLogPress(objCPOProductionLogPPT)
    End Function

    Public Shared Function CPOProductionLogBalanceBF(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objProductionCPOLogDAL As New CPOProductionLogDAL
        Return objProductionCPOLogDAL.CPOProductionLogBalanceBF(objCPOProductionLogPPT)
    End Function

    ''For Press Tab summary''''''

    Public Shared Function SaveCPOProductionPressSummary(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.SaveCPOProductionPressSummary(objCPOProductionLogPPT)
    End Function

    Public Function UpdateCPOProductionPressSummary(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.UpdateCPOProductionPressSummary(objCPOProductionLogPPT)
    End Function

    Public Shared Function CPOGetMonthYearQtySumm(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Return CPOProductionLogDAL.CPOGetMonthYearQtySumm(objCPOLogPPT)
    End Function

    Public Shared Function CPOProductionLogPressMultiEntryDelete(ByVal objCPOPPT As CPOProductionLogPPT) As Integer
        Dim ObjCPOProductionLogDAL As New CPOProductionLogDAL
        Return ObjCPOProductionLogDAL.CPOProductionLogPressMultiEntryDelete(objCPOPPT)
    End Function

    Public Shared Function UpdateCPOProductionLogReceivedDate() As Integer
        Dim ObjCPOProductionLogDAL As New CPOProductionLogDAL
        Return ObjCPOProductionLogDAL.UpdateCPOProductionLogReceivedDate()
    End Function

End Class
