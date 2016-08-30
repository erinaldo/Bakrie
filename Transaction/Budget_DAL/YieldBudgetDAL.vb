Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT

Public Class YieldBudgetDAL

    Public Shared Function YieldBudgetYieldGet() As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Return objdb.ExecQuery("[Budget].[YieldBudgetYieldGet]")
    End Function

    Public Shared Function YieldBudgetHectFill(ByVal oYieldBudgetPPT As YieldBudgetPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim param(3) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@YOPID", oYieldBudgetPPT.YOPID)
        param(2) = New SqlParameter("@BlockID", oYieldBudgetPPT.BlockID)
        param(3) = New SqlParameter("@DivID", oYieldBudgetPPT.DivID)

        ds = objdb.ExecQuery("[Budget].[YieldBudgetHectFill]", param)
        Return ds
    End Function
End Class
