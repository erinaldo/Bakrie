'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 22 Oct 2009, 13:20
' Place     : Kebun
'
Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT
Public Class Tax_DAL
    Public Shared Function CRTaxView(ByVal Empid As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Empid", Empid)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRTaxView]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRTAXSumOTPremi(ByVal Empid As String, ByVal StartDate As Date, ByVal Enddate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Empid", Empid)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@StartDate", StartDate)
        params(3) = New SqlParameter("@EndDate", Enddate)
        dt = objdb.ExecQuery("[Checkroll].[CRTAXSumOTPremi]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRTAXHADIRAB(ByVal Empid As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AttCode As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Empid", Empid)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@StartDate", StartDate)
        params(3) = New SqlParameter("@EndDate", EndDate)
        params(4) = New SqlParameter("@AttCode", AttCode)
        dt = objdb.ExecQuery("[Checkroll].[CRTAXHADIRAB]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRTAXFiscalYear(ByVal Periode As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Periode", Periode)
        dt = objdb.ExecQuery("[Checkroll].[CRTAXFiscalYear]", params).Tables(0)
        Return dt
    End Function
End Class
