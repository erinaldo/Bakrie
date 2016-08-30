Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionSIRDAL
    Public Shared Function SaveProductionSIR(ByVal objSIRPPT As ProductionSIRPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objSIRPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionSIRSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objSIRPPT As ProductionSIRPPT) As SqlParameter()

        Dim Parms(23) As SqlParameter
        Parms(0) = New SqlParameter("@DocDate", objSIRPPT.DocDate)
        Parms(1) = New SqlParameter("@Assistant", objSIRPPT.Assistant)
        Parms(2) = New SqlParameter("@StartTime", objSIRPPT.StartTime)
        Parms(3) = New SqlParameter("@EndTime", objSIRPPT.EndTime)
        Parms(4) = New SqlParameter("@BreakdownTime", objSIRPPT.BreakdownTime)
        Parms(5) = New SqlParameter("@ShiftHours", objSIRPPT.ShiftHours)
        Parms(6) = New SqlParameter("@Product", objSIRPPT.ProductType)
        Parms(7) = New SqlParameter("@Storage", objSIRPPT.Storage)
        Parms(8) = New SqlParameter("@ReceivedWet", objSIRPPT.ReceivedWet)
        Parms(9) = New SqlParameter("@ReceivedDry", objSIRPPT.ReceivedDry)
        Parms(10) = New SqlParameter("@RProduct", objSIRPPT.RProduct)
        Parms(11) = New SqlParameter("@RStorage", objSIRPPT.RStorage)
        Parms(12) = New SqlParameter("@StockAwalUnPDry", objSIRPPT.StockAwalUnPDry)
        Parms(13) = New SqlParameter("@MaturasiDry", objSIRPPT.MaturasiDry)
        Parms(14) = New SqlParameter("@OGPDry", objSIRPPT.OGPDry)
        Parms(15) = New SqlParameter("@StockAwalInPDry", objSIRPPT.StockAwalInPDry)
        Parms(16) = New SqlParameter("@IntakeInPDry", objSIRPPT.IntakeInPDry)
        Parms(17) = New SqlParameter("@AdjustmentDry", objSIRPPT.AdjustmentDry)
        Parms(18) = New SqlParameter("@StockAkhirInPDry", objSIRPPT.StockAkhirInPDry)
        Parms(19) = New SqlParameter("@StockAkhirUnPDry", objSIRPPT.StockAkhirUnPDry)
        Parms(20) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(21) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(22) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(23) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objSIRPPT As ProductionSIRPPT) As List(Of ProductionSIRPPT)
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objSIRPPT.DocDate Is Nothing, DBNull.Value, objSIRPPT.DocDate))
        params(1) = New SqlParameter("@Assistant", If(objSIRPPT.Assistant Is Nothing, DBNull.Value, objSIRPPT.Assistant))
        params(2) = New SqlParameter("@Product", If(objSIRPPT.ProductType Is Nothing, DBNull.Value, objSIRPPT.ProductType))
        params(3) = New SqlParameter("@Storage", If(objSIRPPT.Storage Is Nothing, DBNull.Value, objSIRPPT.Storage))
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[ProductionSIRGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionSIRPPT)(dt)
    End Function

    Public Shared Function DeleteLastSIR(ByVal objSIRPPT As ProductionSIRPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objSIRPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(3).Value = If(objSIRPPT.Tstamp Is Nothing, DBNull.Value, objSIRPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionSIRDelete]", Parms, False)
        Return ds

    End Function
End Class
