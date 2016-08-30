Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionTransferDAL
    Public Shared Function SaveProductionTransfer(ByVal objTransferPPT As ProductionTransferPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objTransferPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionTransferSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objTransferPPT As ProductionTransferPPT) As SqlParameter()

        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@DocDate", objTransferPPT.DocDate)
        Parms(1) = New SqlParameter("@ProductFrom", objTransferPPT.ProductFrom)
        Parms(2) = New SqlParameter("@StorageFrom", objTransferPPT.StorageFrom)
        Parms(3) = New SqlParameter("@ProductTo", objTransferPPT.ProductTo)
        Parms(4) = New SqlParameter("@StorageTo", objTransferPPT.StorageTo)
        Parms(5) = New SqlParameter("@Remarks", objTransferPPT.Remarks)
        Parms(6) = New SqlParameter("@QtyFromWet", objTransferPPT.QtyFromWet)
        Parms(7) = New SqlParameter("@QtyFromDry", objTransferPPT.QtyFromDry)
        Parms(8) = New SqlParameter("@QtyToWet", objTransferPPT.QtyToWet)
        Parms(9) = New SqlParameter("@QtyToDry", objTransferPPT.QtyToDry)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(13) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objTransferPPT As ProductionTransferPPT) As List(Of ProductionTransferPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objTransferPPT.DocDate Is Nothing, DBNull.Value, objTransferPPT.DocDate))
        params(1) = New SqlParameter("@ProductTo", If(objTransferPPT.ProductTo Is Nothing, DBNull.Value, objTransferPPT.ProductTo))
        params(2) = New SqlParameter("@StorageTo", If(objTransferPPT.StorageTo Is Nothing, DBNull.Value, objTransferPPT.StorageTo))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[ProductionTransferGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionTransferPPT)(dt)
    End Function

    Public Shared Function DeleteLastTransfer(ByVal objTransferPPT As ProductionTransferPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objTransferPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(3).Value = If(objTransferPPT.Tstamp Is Nothing, DBNull.Value, objTransferPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionTransferDelete]", Parms, False)
        Return ds

    End Function
End Class
