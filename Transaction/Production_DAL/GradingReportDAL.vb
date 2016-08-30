Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class GradingReportDAL

    Public Shared Function GetInterfaceYear(ByVal objGradingReportPPT As GradingReportPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Production].[GradingFFBMonthYearGET]", Parms)
        Return ds
    End Function


    Public Shared Function GetWBTicketNo(ByVal objGradingReportPPT As GradingReportPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As DataTable
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Amonth", objGradingReportPPT.AMonth)
        Parms(2) = New SqlParameter("@AYear", objGradingReportPPT.AYear)
 
        Parms(3) = New SqlParameter("@GradingDate", IIf(objGradingReportPPT .BGradingDate =True, objGradingReportPPT.GradingDate, DBNull.Value))

        Parms(4) = New SqlParameter("@WBTicketNo", IIf(objGradingReportPPT.WBTicketNo <> String.Empty, objGradingReportPPT.WBTicketNo, DBNull.Value))
 
        dt = objdb.ExecQuery("[Production].[GradingReportSearch]", Parms).Tables(0)
        Return dt
    End Function
End Class
