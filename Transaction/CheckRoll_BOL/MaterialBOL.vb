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
Public Class MaterialBOL
    Public Shared Function DailyMaterialView(ByVal DailyDistributionID As String, ByVal COAID As String) As DataTable
        Dim dt As New DataTable
        dt = Material_Dal.DailyMaterialView(DailyDistributionID, COAID)
        Return dt
    End Function
    Public Shared Function DailyMaterialIsSelect(ByVal MaterialUsageID As String, ByVal StockID As String) As DataTable
        Dim dt As New DataTable
        dt = Material_Dal.DailyMaterialIsSelect(MaterialUsageID, StockID)
        Return dt
    End Function
End Class
