Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionLogBSRDAL
    Public Shared Function SaveBSR(ByVal objLBSRPPT As ProductionLogBSRPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objLBSRPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[BSRSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objLBSRPPT As ProductionLogBSRPPT) As SqlParameter()
        Dim Parms(17) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objLBSRPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@Assistant", objLBSRPPT.BSRAssistant)
        Parms(4) = New SqlParameter("@StartTime", objLBSRPPT.BSRStartTime)
        Parms(5) = New SqlParameter("@StopTime", objLBSRPPT.BSRStopTime)
        Parms(6) = New SqlParameter("@BreakTime", objLBSRPPT.BSRBdTime)
        Parms(7) = New SqlParameter("@ShiftHours", objLBSRPPT.BSRSHrs)
        Parms(8) = New SqlParameter("@Product", objLBSRPPT.BSRProduct)
        Parms(9) = New SqlParameter("@Storage", objLBSRPPT.BSRStorage)
        Parms(10) = New SqlParameter("@TL", objLBSRPPT.BSRTL)
        Parms(11) = New SqlParameter("@Washing", objLBSRPPT.BSRWS)
        Parms(12) = New SqlParameter("@SLDry", objLBSRPPT.BSRSLDry)
        Parms(13) = New SqlParameter("@Sludge", objLBSRPPT.BSRSL)
        Parms(14) = New SqlParameter("@Butiran", objLBSRPPT.BSRBT)
        Parms(15) = New SqlParameter("@Creep", objLBSRPPT.BSRCP)
        Parms(16) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(17) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionLogBSRPPT) As List(Of ProductionLogBSRPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Source", If(objLPOPPT.BSRStorage Is Nothing, DBNull.Value, objLPOPPT.BSRStorage))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Product", If(objLPOPPT.BSRProduct Is Nothing, DBNull.Value, objLPOPPT.BSRProduct))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[BSRGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionLogBSRPPT)(dt)
    End Function

    Public Shared Function DeleteLastBSR(ByVal objLPOPPT As ProductionLogBSRPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objLPOPPT.TransId)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[BSRDelete]", Parms, False)
        Return ds

    End Function
End Class
