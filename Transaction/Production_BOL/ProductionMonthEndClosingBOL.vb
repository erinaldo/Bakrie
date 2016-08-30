Imports Production_DAL
Imports Production_PPT

Public Class ProductionMonthEndClosingBOL

    Public Shared Function TaskConfigTaskCheckGet() As DataSet

        Return ProductionMonthEndClosingDAL.TaskConfigTaskCheckGet()

    End Function

    Public Shared Function TaskMonitorGet() As DataSet

        Return ProductionMonthEndClosingDAL.TaskMonitorGet()

    End Function

    Public Shared Function ProductionTaskMonitorINSERT() As DataSet

        Return ProductionMonthEndClosingDAL.ProductionTaskMonitorINSERT()

    End Function
    Public Shared Function ProductionMonthlyReport(ByVal suplierName As String, ByVal WeighingDate As Date) As DataSet

        Return ProductionMonthEndClosingDAL.ProductionMonthlyReport(suplierName, WeighingDate)

    End Function

End Class
