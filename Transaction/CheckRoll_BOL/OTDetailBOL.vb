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
Public Class OTDetailBOL
    Public Shared Function OTDetailView(ByVal MandoreID As String, ByVal KraniID As String, ByVal EmpID As String, ByVal Adate As Date) As DataTable
        Dim dt As New DataTable
        dt = OTDetailDAL.OTDetailView(MandoreID, KraniID, EmpID, Adate)
        Return dt
    End Function
    Public Shared Function OTDetailViewTeam(ByVal MandoreID As String, ByVal KraniID As String, ByVal Adate As Date) As DataTable
        Dim dt As New DataTable
        dt = OTDetailDAL.OTDetailViewTeam(MandoreID, KraniID, Adate)
        Return dt
    End Function
End Class
