Imports Production_DAL
Imports Production_PPT

Public Class DailyProductionKCPBOL

    Public Shared Function DailyProductionKCPDateSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT, ByVal LoadorSearch As String) As DataSet
        Return DailProductionKCPDAL.DailyProductionKCPDateSelect(ObjDailProductionKCPPT, LoadorSearch)
    End Function

    Public Shared Function DailyProductionKCPBFQtySelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailyProductionKCPBFQtySelect(ObjDailProductionKCPPT)
    End Function
    Public Shared Function DailyProductionKCPCPKOCFSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailyProductionKCPCPKOCFSelect(ObjDailProductionKCPPT)
    End Function

    Public Shared Function DailyProductionKCPKernelBalanceCFSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailyProductionKCPKernelBalanceCFSelect(ObjDailProductionKCPPT)
    End Function

    Public Shared Function DailyProductionKCPKernelIntakeSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailyProductionKCPKernelIntakeSelect(ObjDailProductionKCPPT)
    End Function

    Public Shared Function DailyProductionLoadingCPKOSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT, ByVal LoadDescp As String) As DataSet
        Return DailProductionKCPDAL.DailyProductionLoadingCPKOSelect(ObjDailProductionKCPPT, LoadDescp)
    End Function
    Public Shared Function DailProductionSartStopHrsSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailProductionSartStopHrsSelect(ObjDailProductionKCPPT)
    End Function

    Public Shared Function DailProductionBDSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailProductionBDSelect(ObjDailProductionKCPPT)
    End Function
    Public Shared Function DailProductionPressInfoSelect(ByVal ObjDailProductionKCPPT As DailyProductionKCPPPT) As DataSet
        Return DailProductionKCPDAL.DailProductionPressInfoSelect(ObjDailProductionKCPPT)
    End Function
End Class
