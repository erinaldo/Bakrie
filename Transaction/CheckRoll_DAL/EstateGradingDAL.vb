Imports CheckRoll_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class EstateGradingDAL
    Public Function Save_EstateGrading(ByVal objEGPPT As EstateGradingPPT) As Integer
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer
        Try
            Dim Param(7) As SqlParameter
            Param(0) = New SqlParameter("@Month", objEGPPT.Month)
            Param(1) = New SqlParameter("@EstateName", GlobalPPT.strEstateName)
            Param(2) = New SqlParameter("@Afdelling", objEGPPT.Afdeling)
            Param(3) = New SqlParameter("@Mandor", objEGPPT.Mandor)
            Param(4) = New SqlParameter("@GangTeam", objEGPPT.GangTeam)
            Param(5) = New SqlParameter("@FieldNo", objEGPPT.FieldNo)
            Param(6) = New SqlParameter("@Gred", objEGPPT.Gred)
            Param(7) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            objdb.ExecNonQuery("[Checkroll].[EstateGradingInsert]", Param)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function
End Class