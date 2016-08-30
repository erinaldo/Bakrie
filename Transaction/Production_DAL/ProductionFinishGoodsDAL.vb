Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionFinishGoodsDAL
    Public Shared Function SaveProductionFinishGoods(ByVal objFinishGoodsPPT As ProductionFinishGoodsPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objFinishGoodsPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionFinishGoodsSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objFinishGoodsPPT As ProductionFinishGoodsPPT) As SqlParameter()

        Dim Parms(12) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objFinishGoodsPPT.ID Is Nothing OrElse objFinishGoodsPPT.ID = 0, DBNull.Value, objFinishGoodsPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objFinishGoodsPPT.DocDate)
        Parms(1) = New SqlParameter("@Station", objFinishGoodsPPT.Station)
        Parms(2) = New SqlParameter("@Product", objFinishGoodsPPT.Product)
        Parms(3) = New SqlParameter("@Storage", objFinishGoodsPPT.Storage)
        Parms(4) = New SqlParameter("@Location", objFinishGoodsPPT.Location)
        Parms(5) = New SqlParameter("@Remarks", objFinishGoodsPPT.Remarks)
        Parms(6) = New SqlParameter("@QtyDry", objFinishGoodsPPT.QtyDry)
        Parms(7) = New SqlParameter("@QtyWet", objFinishGoodsPPT.QtyWet)
        Parms(8) = New SqlParameter("@DRC", objFinishGoodsPPT.DRC)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objFinishGoodsPPT.EstateID
        Parms(12) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objFinishGoodsPPT As ProductionFinishGoodsPPT) As List(Of ProductionFinishGoodsPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objFinishGoodsPPT.DocDate Is Nothing, DBNull.Value, objFinishGoodsPPT.DocDate))
        params(1) = New SqlParameter("@Storage", If(objFinishGoodsPPT.Storage Is Nothing, DBNull.Value, objFinishGoodsPPT.Storage))
        params(2) = New SqlParameter("@Product", If(objFinishGoodsPPT.Product Is Nothing, DBNull.Value, objFinishGoodsPPT.Product))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[ProductionFinishGoodsGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionFinishGoodsPPT)(dt)
    End Function

    Public Shared Function DeleteLastFinishGoods(ByVal objFinishGoodsPPT As ProductionFinishGoodsPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objFinishGoodsPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        'Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        'Parms(3).Value = If(objFinishGoodsPPT.Tstamp Is Nothing, DBNull.Value, objFinishGoodsPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionFinishGoodsDelete]", Parms, False)
        Return ds

    End Function
End Class
