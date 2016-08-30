'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 17 Nop 2009, 13:20
' Place     : Kebun
'
'Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL
Public Class PremiTargetBOL
    Public Shared Function TargetDetailView(ByVal GangMasterID As String, ByVal MandoreID As String, _
                                            ByVal KraniID As String, ByVal BlockId As String, _
                                            ByVal Empid As String, ByVal RDate As Date) As DataTable
        Dim dt As New DataTable
        dt = PremiTargetDAL.TargetDetailView(GangMasterID, MandoreID, KraniID, BlockId, Empid, RDate)
        Return dt
    End Function

    Public Shared Function TargetDetailDelete(ByVal ReceptionTargetSumryID As String) As Integer
        Dim dt As New Integer
        dt = PremiTargetDAL.TargetDetailDelete(ReceptionTargetSumryID)
        Return dt
    End Function

    Public Shared Function DailyReceiptionDetIDDelete(ByVal DailyReceiptionDetID As String) As Integer
        Dim dt As New Integer
        dt = PremiTargetDAL.DailyReceiptionDetIDDelete(DailyReceiptionDetID)
        Return dt
    End Function


End Class
