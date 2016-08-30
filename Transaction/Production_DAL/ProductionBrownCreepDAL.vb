Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionBrownCreepDAL
    Public Shared Function SaveProductionBrownCreep(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objBrownCreepPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionBrownCreepSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As SqlParameter()

        Dim Parms(13) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objRSSPPT.ID Is Nothing OrElse objRSSPPT.ID = 0, DBNull.Value, objRSSPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objBrownCreepPPT.DocDate)
        Parms(1) = New SqlParameter("@Assistant", objBrownCreepPPT.Assistant)
        Parms(2) = New SqlParameter("@StartTime", objBrownCreepPPT.StartTime)
        Parms(3) = New SqlParameter("@EndTime", objBrownCreepPPT.EndTime)
        Parms(4) = New SqlParameter("@BreakdownTime", objBrownCreepPPT.BreakdownTime)
        Parms(5) = New SqlParameter("@ShiftHours", objBrownCreepPPT.ShiftHours)
        Parms(6) = New SqlParameter("@Product", objBrownCreepPPT.ProductType)
        Parms(7) = New SqlParameter("@Storage", objBrownCreepPPT.Storage)
        Parms(8) = New SqlParameter("@SkimLatex", objBrownCreepPPT.SkimLatex)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objWIORubberPPT.EstateID
        Parms(12) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(13) = New SqlParameter("@Washing", objBrownCreepPPT.Washing)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As List(Of ProductionBrownCreepPPT)
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objBrownCreepPPT.DocDate Is Nothing, DBNull.Value, objBrownCreepPPT.DocDate))
        params(1) = New SqlParameter("@Assistant", If(objBrownCreepPPT.Assistant Is Nothing, DBNull.Value, objBrownCreepPPT.Assistant))
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[ProductionBrownCreepGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionBrownCreepPPT)(dt)

    End Function

    Public Shared Function DeleteLastBrownCreep(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objBrownCreepPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(3).Value = If(objBrownCreepPPT.Tstamp Is Nothing, DBNull.Value, objBrownCreepPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionBrownCreepDelete]", Parms, False)
        Return ds

    End Function
End Class
