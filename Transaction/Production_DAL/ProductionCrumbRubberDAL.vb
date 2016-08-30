Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionCrumbRubberDAL
    Public Shared Function SaveProductionCrumbRubber(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objCrumbRubberPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionCrumbRubberSIRSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As SqlParameter()

        Dim Parms(20) As SqlParameter
        Parms(0) = New SqlParameter("@DocDate", objCrumbRubberPPT.DocDate)
        Parms(1) = New SqlParameter("@Assistant", objCrumbRubberPPT.Assistant)
        Parms(2) = New SqlParameter("@StartTime", objCrumbRubberPPT.StartTime)
        Parms(3) = New SqlParameter("@EndTime", objCrumbRubberPPT.EndTime)
        Parms(4) = New SqlParameter("@BreakdownTime", objCrumbRubberPPT.BreakdownTime)
        Parms(5) = New SqlParameter("@ShiftHours", objCrumbRubberPPT.ShiftHours)
        Parms(6) = New SqlParameter("@Product", objCrumbRubberPPT.ProductType)
        Parms(7) = New SqlParameter("@Storage", objCrumbRubberPPT.Storage)
        Parms(8) = New SqlParameter("@ReceivedWet", objCrumbRubberPPT.ReceivedWet)
        Parms(9) = New SqlParameter("@ReceivedDry", objCrumbRubberPPT.ReceivedDry)
        Parms(10) = New SqlParameter("@RProduct", objCrumbRubberPPT.RProduct)
        Parms(11) = New SqlParameter("@RStorage", objCrumbRubberPPT.RStorage)
        Parms(12) = New SqlParameter("@StockAwalDry", objCrumbRubberPPT.StockAwalDry)
        Parms(13) = New SqlParameter("@IntakeDry", objCrumbRubberPPT.IntakeDry)
        Parms(14) = New SqlParameter("@LatexProcess", objCrumbRubberPPT.LatexProcess)
        Parms(15) = New SqlParameter("@AdjustmentDry", objCrumbRubberPPT.AdjustmentDry)
        Parms(16) = New SqlParameter("@StockAkhirDry", objCrumbRubberPPT.StockAkhirDry)
        Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(20) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As List(Of ProductionCrumbRubberPPT)
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objCrumbRubberPPT.DocDate Is Nothing, DBNull.Value, objCrumbRubberPPT.DocDate))
        params(1) = New SqlParameter("@Assistant", If(objCrumbRubberPPT.Assistant Is Nothing, DBNull.Value, objCrumbRubberPPT.Assistant))
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[ProductionCrumbRubberSIRGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionCrumbRubberPPT)(dt)
    End Function

    Public Shared Function DeleteLastCrumbRubber(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objCrumbRubberPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(3).Value = If(objCrumbRubberPPT.Tstamp Is Nothing, DBNull.Value, objCrumbRubberPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionCrumbRubberSIRDelete]", Parms, False)
        Return ds

    End Function
End Class
