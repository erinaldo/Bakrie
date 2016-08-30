Imports CheckRoll_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class DailyReceptionForRubberDAL
    Public Function Save_Rubber(ByVal objRubberPPT As DailyReceptionForRubberPPT) As Integer
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer
        Try
            Dim Param(20) As SqlParameter
            Param(0) = New SqlParameter("@DateRubber", objRubberPPT.DateRubber)
            Param(1) = New SqlParameter("@NIK", objRubberPPT.NIK)
            Param(2) = New SqlParameter("@Name", objRubberPPT.Name)
            Param(3) = New SqlParameter("@AttCode", objRubberPPT.AttCode)
            Param(4) = New SqlParameter("@Location", objRubberPPT.Location)
            Param(5) = New SqlParameter("@OTHour", objRubberPPT.OTHour)
            Param(6) = New SqlParameter("@Afdeling", objRubberPPT.Afdeling)
            Param(7) = New SqlParameter("@YOP", objRubberPPT.YOP)
            Param(8) = New SqlParameter("@FieldNo", objRubberPPT.Block)
            Param(9) = New SqlParameter("@TPH", objRubberPPT.TPH)
            Param(10) = New SqlParameter("@Latex", objRubberPPT.Latex)
            Param(11) = New SqlParameter("@CupLamp", objRubberPPT.CupLamp)
            Param(12) = New SqlParameter("@TreeLace", objRubberPPT.TreeLace)
            Param(13) = New SqlParameter("@Coaglum", objRubberPPT.Coaglum)
            Param(14) = New SqlParameter("@DRC", objRubberPPT.DRC)
            Param(15) = New SqlParameter("@DRCCupLump", objRubberPPT.DRCCuplump)
            Param(16) = New SqlParameter("@DRCTreeLace", objRubberPPT.DRCTreelace)
            Param(17) = New SqlParameter("@DRCCoaglum", objRubberPPT.DRCCoaglum)
            Param(18) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Param(19) = New SqlParameter("@DailyReceiptionID", objRubberPPT.DailyReceiptionID)
            Param(20) = New SqlParameter("@TeamId", objRubberPPT.TeamId)
            objdb.ExecNonQuery("[Checkroll].[DailyReceptionForRubberInsert]", Param)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Sub DeleteRubber(DailyReceiptionID As String)
        Dim objdb As New SQLHelp
        Try
            Dim Param(0) As SqlParameter
            Param(0) = New SqlParameter("@DailyReceiptionID", DailyReceiptionID)
            
            objdb.ExecNonQuery("[Checkroll].[DailyReceptionForRubberCheck]", Param)
        Catch ex As Exception
        End Try
    End Sub

    Public Function DailyRubberSelect(ByVal DailyReceiptionID As String) As DataTable
        Dim DT As DataTable = New DataTable
        Dim adapter As New Global.Common_DAL.SQLHelp
        Dim params(0) As SqlParameter

        params(0) = New SqlParameter("@DailyReceiptionID", DailyReceiptionID)

        DT = adapter.ExecQuery("[Checkroll].[DailyReceptionForRubberSelect]", params).Tables(0)
        Return DT
    End Function
End Class