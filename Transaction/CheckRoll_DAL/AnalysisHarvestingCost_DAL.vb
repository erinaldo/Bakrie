
Imports CheckRoll_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class AnalysisHarvestingCost_DAL
    Public Function GetTaskComplete(ByVal objHarvesterPPT As AnalysisHarvestingCost_PPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(2) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(3) = New SqlParameter("@Task", objHarvesterPPT.Task)
        Parms(4) = New SqlParameter("@ModID", 1)

        ds = objdb.ExecQuery("[General].[TaskMonitorStatusGet]", Parms)
        Return ds
    End Function
End Class
