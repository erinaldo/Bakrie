Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class ProductionMonthEndClosingDAL

    Public Shared Function TaskConfigTaskCheckGet() As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        ds = objdb.ExecQuery("[Store].[TaskConfigTaskCheckGet]", Parms)
        Return ds

    End Function

    Public Shared Function TaskMonitorGet() As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", "4")
        ds = objdb.ExecQuery("[General].[TaskMonitorGet]", Parms)

        Return ds
    End Function



    Public Shared Function ProductionTaskMonitorINSERT() As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", "4")
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(3) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(4) = New SqlParameter("@ALTERdBy", GlobalPPT.strUserName)
        Parms(5) = New SqlParameter("@ALTERdOn", Date.Today)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ActivemonthyearID", GlobalPPT.strActMthYearID)
        Parms(9) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Production].[ProductionMonthEndClosing]", Parms)

        Return ds
    End Function


    Public Shared Function ProductionMonthlyReport(ByVal suplierName As String, ByVal WeighingDate As Date) As DataSet
        'Dim ProductionMonthEndClosingPPT As New PMEClosePPT
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@suplierName", suplierName)
        Parms(4) = New SqlParameter("@WeighingDate", WeighingDate)
        ds = objdb.ExecQuery("[Production].[ProductionMonthlyReport]", Parms)
        Return ds

    End Function
End Class
