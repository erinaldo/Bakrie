Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionLogCenexDAL
    Public Shared Function SaveLCNX(ByVal objLCenexPPT As ProductionLogCenexPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objLCenexPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LCNXSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objLCenexPPT As ProductionLogCenexPPT) As SqlParameter()
        Dim Parms(24) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objLCenexPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@Assistant", objLCenexPPT.LCNXAssistant)
        Parms(4) = New SqlParameter("@StartTime", objLCenexPPT.LCNXStartTime)
        Parms(5) = New SqlParameter("@StopTime", objLCenexPPT.LCNXStopTime)
        Parms(6) = New SqlParameter("@BreakTime", objLCenexPPT.LCNXBdTime)
        Parms(7) = New SqlParameter("@ShiftHours", objLCenexPPT.LCNXSHrs)
        Parms(8) = New SqlParameter("@Product", objLCenexPPT.LCNXProduct)
        Parms(9) = New SqlParameter("@Storage", objLCenexPPT.LCNXStorage)
        Parms(10) = New SqlParameter("@ReceivedWet", objLCenexPPT.LCNXWet)
        Parms(11) = New SqlParameter("@ReceivedDry", objLCenexPPT.LCNXDry)
        Parms(12) = New SqlParameter("@ReceivedProduct", objLCenexPPT.LCNXProductR)
        Parms(13) = New SqlParameter("@ReceivedStorage", objLCenexPPT.LCNXStorageR)
        Parms(14) = New SqlParameter("@LPWet", objLCenexPPT.LCNXLPWet)
        Parms(15) = New SqlParameter("@LPDry", objLCenexPPT.LCNXLPDry)
        Parms(16) = New SqlParameter("@SkimDry", objLCenexPPT.LCNXSKDry)
        Parms(17) = New SqlParameter("@Sludge", objLCenexPPT.LCNXSLDry)
        Parms(18) = New SqlParameter("@Limbah", objLCenexPPT.LCNXLM)
        Parms(19) = New SqlParameter("@Washing", objLCenexPPT.LCNXWS)
        Parms(20) = New SqlParameter("@ConcWet", objLCenexPPT.LCNXCNWet)
        Parms(21) = New SqlParameter("@ConcDry", objLCenexPPT.LCNXCNDry)
        Parms(22) = New SqlParameter("@LossNGain", objLCenexPPT.LCNXLG)
        Parms(23) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(24) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objLPOPPT As ProductionLogCenexPPT) As List(Of ProductionLogCenexPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Source", If(objLPOPPT.LCNXStorage Is Nothing, DBNull.Value, objLPOPPT.LCNXStorage))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Product", If(objLPOPPT.LCNXProduct Is Nothing, DBNull.Value, objLPOPPT.LCNXProduct))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[PLCNXGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionLogCenexPPT)(dt)
    End Function

    Public Shared Function DeleteLastPLCNX(ByVal objLPOPPT As ProductionLogCenexPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objLPOPPT.ID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PLCNXDelete]", Parms, False)
        Return ds

    End Function

End Class
