Imports WeighBridge_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class WBWeighingInOutRubberDAL

    Public Shared Function SaveWIORubber(ByVal objWIORubberPPT As WBWeighingInOutRubberPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(1) = New SqlParameter("@DocDate", objWIORubberPPT.DocDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@WBTicketNo", objWIORubberPPT.WBTicketNo)
        Parms(4) = New SqlParameter("@VehicleID", objWIORubberPPT.VehicleID)
        Parms(5) = New SqlParameter("@EstateID", objWIORubberPPT.EstateID) 'objWIORubberPPT.EstateID
        Parms(6) = New SqlParameter("@DivID", objWIORubberPPT.DivID)
        Parms(7) = New SqlParameter("@Wet", objWIORubberPPT.Wet)
        Parms(8) = New SqlParameter("@Dry", objWIORubberPPT.Dry)
        Parms(9) = New SqlParameter("@DRCPct", objWIORubberPPT.DRCPct)
        ' Parm(7) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        'Varbinary need to specifically mention
        Parms(12) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(12).Value = If(objWIORubberPPT.Tstamp Is Nothing, DBNull.Value, objWIORubberPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Weighbridge].[WIORubberSave]", Parms, False)
        Return ds

    End Function

    Public Function GetSearchResults(ByVal objLPOPPT As WBWeighingInOutRubberPPT) As List(Of WBWeighingInOutRubberPPT)
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@VehicleID", If(objLPOPPT.VehicleID Is Nothing, DBNull.Value, objLPOPPT.VehicleID))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@WBTicketNo", If(objLPOPPT.WBTicketNo Is Nothing, DBNull.Value, objLPOPPT.WBTicketNo))
        'params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Weighbridge].[WIORubberGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of WBWeighingInOutRubberPPT)(dt)
    End Function

    Public Shared Function DeleteLastWIORubber(ByVal objWIORubberPPT As WBWeighingInOutRubberPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objWIORubberPPT.EstateID

        'Varbinary need to specifically mention
        Parms(2) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        Parms(2).Value = If(objWIORubberPPT.Tstamp Is Nothing, DBNull.Value, objWIORubberPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Weighbridge].[WIORubberDelete]", Parms, False)
        Return ds

    End Function

End Class
