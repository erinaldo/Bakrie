Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class WipDAL
    Public Shared Function SaveWIP(ByVal objLWipPPT As WipPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objLWipPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[WIPSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objLWipPPT As WipPPT) As SqlParameter()
        Dim Parms(12) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objLWipPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@Station", objLWipPPT.WIPStation)
        Parms(4) = New SqlParameter("@Storage", objLWipPPT.WIPStorage)
        Parms(5) = New SqlParameter("@Product", objLWipPPT.WIPProduct)
        Parms(6) = New SqlParameter("@Class", objLWipPPT.WIPClass)
        Parms(7) = New SqlParameter("@CenexWet", objLWipPPT.WIPCenexWet)
        Parms(8) = New SqlParameter("@CenexDry", objLWipPPT.WIPCenexDry)
        Parms(9) = New SqlParameter("@QtyDry", objLWipPPT.WIPQtyDry)
        Parms(10) = New SqlParameter("@Drc", objLWipPPT.WIPDrc)
        Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As WipPPT) As List(Of WipPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Storage", If(objLPOPPT.WIPStorage Is Nothing, DBNull.Value, objLPOPPT.WIPStorage))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Product", If(objLPOPPT.WIPProduct Is Nothing, DBNull.Value, objLPOPPT.WIPProduct))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[WIPGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of WipPPT)(dt)
    End Function
    Public Shared Function DeleteLastWIP(ByVal objLPOPPT As WipPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objLPOPPT.ID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        'Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        'Parms(3).Value = If(objRMSPPT.Tstamp Is Nothing, DBNull.Value, objRMSPPT.Tstamp)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[WIPDelete]", Parms, False)
        Return ds

    End Function
End Class
