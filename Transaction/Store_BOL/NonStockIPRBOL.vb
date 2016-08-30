Imports System.Data.SqlClient
Imports Store_DAL
Imports Store_PPT

Public Class NonStockIPRBOL
    Public Function GetIPRNo(ByVal objIPRNo As IPRPPT) As IPRPPT
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetIPRNo(objIPRNo)
    End Function

    Public Function GetStockCategory(ByVal obStkCategory As NonStockIPRPPT) As DataTable
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.GetStockCategory(obStkCategory)
    End Function

    Public Function GetStockCode(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.GetStockCode(objNonStockIPRPPT)
    End Function

    Public Function StockCodeSearch(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.StockCodeSearch(objNonStockIPRPPT)
    End Function

    Public Function IPRViewSearch(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.IPRViewSearch(objIPRPPT)
    End Function

    Public Function STNonStockIPRNo_isExist(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.STNonStockIPRNo_isExist(objNonStockIPRPPT)
    End Function

    Public Function Save_STNonStockIPR(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        'IPRNo_isExist(objIPRSave)
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.Save_STNonStockIPR(objNonStockIPRPPT)
    End Function

    Public Function Update_STNonStockIPR(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.Update_STNonStockIPR(objNonStockIPRPPT)
    End Function

    Public Function Save_STNonStockIPRDetail(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.Save_STNonStockIPRDetail(objNonStockIPRPPT)
    End Function

    Public Function Update_STNonStockIPRDetail(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.Update_STNonStockIPRDetail(objNonStockIPRPPT)
    End Function

    Public Function Delete_STNonStockIPRDetail(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.Delete_STNonStockIPRDetail(objNonStockIPRPPT)
    End Function

    Public Function Update_STNonStockIPRApproval(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.Update_STNonStockIPRApproval(objNonStockIPRPPT)
    End Function
   
    Public Function GetNonStockIPRSearch_Details(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.GetNonStockIPRSearch_Details(objNonStockIPRPPT)
    End Function

    Public Function GetNonStockIPRDetails(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.GetNonStockIPRDetails(objNonStockIPRPPT)
    End Function
    Public Function StockCategorySearch(ByVal CategorySearch As String) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.StockCategorySearch(CategorySearch)
    End Function
    Public Function GetAvailableQTy(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetAvailableQTy(objIPRPPT)
    End Function
    Public Function STNonStockIPRRecordIsExist(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Object
        Dim objNonStockIPRData As New NonStockIPRDAL
        Return objNonStockIPRData.STNonStockIPRRecordIsExist(objNonStockIPRPPT)
    End Function

    Public Function AcctlookupSearch(ByVal objIPRPPT As IPRPPT, ByVal IsDirect As String) As DataSet
        Dim objIPRData As New IPRDAL
        Return objIPRData.AcctlookupSearch(objIPRPPT, IsDirect)
    End Function

    Public Function DeleteMultiEntryNonIPR(ByVal ObjNonIPRPPT As NonStockIPRPPT) As Integer

        Dim objNonIPRData As New NonStockIPRDAL
        Return objNonIPRData.DeleteMultiEntryNonIPR(ObjNonIPRPPT)

    End Function


    Public Function GetNonStockCategory(ByVal obStkCategory As NonStockIPRPPT, ByVal IsDirect As String) As DataTable

        Dim objNonIPRData As New NonStockIPRDAL
        Return objNonIPRData.GetNonStockCategory(obStkCategory, IsDirect)

    End Function




End Class
