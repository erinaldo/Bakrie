Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionRSSDAL
    Public Shared Function SaveProductionRSS(ByVal objRSSPPT As ProductionRSSPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objRSSPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionRSSSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objRSSPPT As ProductionRSSPPT) As SqlParameter()

        Dim Parms(12) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objRSSPPT.ID Is Nothing OrElse objRSSPPT.ID = 0, DBNull.Value, objRSSPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objRSSPPT.DocDate)
        Parms(1) = New SqlParameter("@Assistant", objRSSPPT.Assistant)
        Parms(2) = New SqlParameter("@StartTime", objRSSPPT.StartTime)
        Parms(3) = New SqlParameter("@EndTime", objRSSPPT.EndTime)
        Parms(4) = New SqlParameter("@BreakdownTime", objRSSPPT.BreakdownTime)
        Parms(5) = New SqlParameter("@ShiftHours", objRSSPPT.ShiftHours)
        Parms(6) = New SqlParameter("@Product", objRSSPPT.ProductType)
        Parms(7) = New SqlParameter("@Storage", objRSSPPT.Storage)
        Parms(8) = New SqlParameter("@LatexProcess", objRSSPPT.LatexProcess)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objWIORubberPPT.EstateID
        Parms(12) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objRSSPPT As ProductionRSSPPT) As List(Of ProductionRSSPPT)
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objRSSPPT.DocDate Is Nothing, DBNull.Value, objRSSPPT.DocDate))
        params(1) = New SqlParameter("@Assistant", If(objRSSPPT.Assistant Is Nothing, DBNull.Value, objRSSPPT.Assistant))
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[ProductionRSSGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionRSSPPT)(dt)
    End Function

    Public Shared Function DeleteLastRSS(ByVal objRSSPPT As ProductionRSSPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objRSSPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(3).Value = If(objRSSPPT.Tstamp Is Nothing, DBNull.Value, objRSSPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionRSSDelete]", Parms, False)
        Return ds

    End Function
End Class
