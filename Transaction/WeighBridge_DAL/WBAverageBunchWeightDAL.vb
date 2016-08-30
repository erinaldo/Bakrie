Imports WeighBridge_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class WBAverageBunchWeightDAL
    Public Function WBAverageBunchWeightCalculate(ByVal NumberOfMonths As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@NumberOfMonths", NumberOfMonths)
        Parms(3) = New SqlParameter("@CalculateOnly", 1)
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        ds = objdb.ExecQuery("[Weighbridge].[WBAverageBunchWeightProcess]", Parms)
        Return ds
    End Function

    Public Function WBAverageBunchWeightProcess(ByVal NumberOfMonths As Integer) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Try
            Dim Parms(4) As SqlParameter
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@NumberOfMonths", NumberOfMonths)
            Parms(3) = New SqlParameter("@CalculateOnly", 0)
            Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

            dt = objdb.ExecQuery("[Weighbridge].[WBAverageBunchWeightProcess]", Parms).Tables(0)
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Public Function WBAverageBunchWeightSelect(ByVal ActiveMonthYearID As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", ActiveMonthYearID)

        dt = objdb.ExecQuery("[Weighbridge].[WBAverageBunchWeightSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function GetActiveMonthYearID(ByVal Year As Integer, ByVal Month As Integer) As DataTable
        
        Dim adapter As New SQLHelp
        Dim params(3) As SqlParameter

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ModID", 4) ' Weighbridge
        params(2) = New SqlParameter("@AYear", Year)
        params(3) = New SqlParameter("@AMonth", Month)

        Return adapter.ExecQuery("[General].[ActiveMonthYearIDGET]", params).Tables(0)
        
    End Function

End Class
