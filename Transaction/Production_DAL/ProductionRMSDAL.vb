Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class ProductionRMSDAL
    Public Shared Function SaveRMS(ByVal objRMSPPT As ProductionRMSPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objRMSPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[RMSSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objRMSPPT As ProductionRMSPPT) As SqlParameter()
        Dim Parms(9) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objRMSPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objWIORubberPPT.EstateID
        Parms(3) = New SqlParameter("@Storage", objRMSPPT.RMSStorage)
        Parms(4) = New SqlParameter("@Product", objRMSPPT.RMSProduct)
        Parms(5) = New SqlParameter("@WetQty", objRMSPPT.RMSTodayWet)
        Parms(6) = New SqlParameter("@DryQTY", objRMSPPT.RMSTodayDry)
        Parms(7) = New SqlParameter("@LocId", objRMSPPT.RMSLoc)
        'Parms(8) = New SqlParameter("@LocDesc", objRMSPPT.RMSLocDesc)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objLPOPPT As ProductionRMSPPT) As List(Of ProductionRMSPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Source", If(objLPOPPT.RMSStorage Is Nothing, DBNull.Value, objLPOPPT.RMSStorage))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Product", If(objLPOPPT.RMSProduct Is Nothing, DBNull.Value, objLPOPPT.RMSProduct))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[RMSGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionRMSPPT)(dt)
    End Function

    Public Function FillTotalWetDry()
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[RMSFillTotalWetDry]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function DeleteLastRMS(ByVal objRMSPPT As ProductionRMSPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objRMSPPT.ID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        'Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        'Parms(3).Value = If(objRMSPPT.Tstamp Is Nothing, DBNull.Value, objRMSPPT.Tstamp)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[RMSDelete]", Parms, False)
        Return ds

    End Function
End Class
