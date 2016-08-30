Imports CheckRoll_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class AnalyHarvestingCostDAL

    Public Shared Function GetActiveMonthYear(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Dim dt As New DataTable
        dt = objdb.ExecQuery("[Checkroll].[GetMonthYear]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function loadCmbYOP() As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Return objdb.ExecQuery("[Checkroll].[GetYOP]", Parms)
        Dim dt As New DataTable
        dt = objdb.ExecQuery("[Checkroll].[GetYOP]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function saveWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@MonthYear", objWBFruitWtDetailsPPT.MonthYear)
        Parms(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(5) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecQuery("[Checkroll].[WBFruitWtInsert]", Parms)
    End Function

    Public Shared Function saveWBFruitWtDetails(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@WBFruitWtID", objWBFruitWtDetailsPPT.WBFruitWtID)
        Parms(1) = New SqlParameter("@YOPID", objWBFruitWtDetailsPPT.YOPID)
        Parms(2) = New SqlParameter("@FFBWt", objWBFruitWtDetailsPPT.FFBWt)
        Parms(3) = New SqlParameter("@FFBBunches", objWBFruitWtDetailsPPT.FFBBunches)
        Parms(4) = New SqlParameter("@OthersWt", objWBFruitWtDetailsPPT.OthersWt)
        Parms(5) = New SqlParameter("@HarvestersWt", objWBFruitWtDetailsPPT.HarvestersWt)

        Return objdb.ExecQuery("[Checkroll].[WBFruitWtDetailsInsert]", Parms)
    End Function

    Public Shared Function UpdateWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataSet
        'Details update not required, Delete & Insert the child records
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@MonthYear", objWBFruitWtDetailsPPT.MonthYear)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecQuery("[Checkroll].[WBFruitWtDetailsUpdate]", Parms)
    End Function

    Public Shared Function DeleteWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@MonthYear", objWBFruitWtDetailsPPT.MonthYear)

        rowsAffected = objdb.ExecNonQuery("[Checkroll].[WBFruitWtDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    Public Shared Function GetWBFruitWtRecs(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@MonthYear", objWBFruitWtDetailsPPT.MonthYear)

        Dim dt As New DataTable
        dt = objdb.ExecQuery("[Checkroll].[GetWBFruitWtRecs]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function GetWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@WBFruitWtID", objWBFruitWtDetailsPPT.WBFruitWtID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@MonthYear", objWBFruitWtDetailsPPT.MonthYear)

        Dim dt As New DataTable
        dt = objdb.ExecQuery("[Checkroll].[GetWBFruitWt]", Parms).Tables(0)
        Return dt
    End Function
    Public Shared Function GetDADLooseFruitsOther(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@YOPid", objWBFruitWtDetailsPPT.YOPID)

        Dim dt As New DataTable
        dt = objdb.ExecQuery("[Checkroll].[GetDADLooseFruitsOther]", Parms).Tables(0)
        Return dt
    End Function
End Class
