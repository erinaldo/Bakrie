'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 3 Sep 2009, 13:20
' Place     : Kuala Lumpur  
'
'Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL
Public Class TAXBOL
    Public Shared Function CRTaxView(ByVal Empid As String) As DataTable
        Dim dt As New DataTable
        dt = Tax_DAL.CRTaxView(Empid)
        Return dt
    End Function
    Public Shared Function CRTAXSumOTPremi(ByVal Empid As String, ByVal StartDate As String, ByVal Enddate As String) As DataTable
        Dim dt As New DataTable
        dt = Tax_DAL.CRTAXSumOTPremi(Empid, StartDate, Enddate)
        Return dt
    End Function
    Public Shared Function CRTAXHADIRAB(ByVal Empid As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AttCode As String) As DataTable
        Dim dt As New DataTable
        dt = Tax_DAL.CRTAXHADIRAB(Empid, StartDate, EndDate, AttCode)
        Return dt
    End Function
    Public Shared Function CRTAXFiscalYear(ByVal Periode As String) As DataTable
        Dim dt As New DataTable
        dt = Tax_DAL.CRTAXFiscalYear(Periode)
        Return dt
    End Function
End Class
