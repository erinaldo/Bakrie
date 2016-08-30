Imports System.Data.SqlClient
Imports Store_DAL
Imports Store_PPT

Public Class IPRBOL

    Public Function GenerateIPRXML(id As String) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.GenerateIPRXML(id)
    End Function

    Public Function GetIPRNo(ByVal objIPRNo As IPRPPT) As IPRPPT
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetIPRNo(objIPRNo)
    End Function

    Public Function GetPRAutoNo() As String
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetPRAutoNo()
    End Function

    Public Function GetStockCategory(ByVal obStkCategory As IPRPPT) As DataTable
        Dim objStkCategory As New IPRDAL
        Return objStkCategory.GetStockCategory(obStkCategory)
    End Function

    'Public Function StockCategorySearch(ByVal CategorySearch As String) As String
    '    Dim objIPRData As New IPRDAL
    '    Return objIPRData.StockCategorySearch(CategorySearch)
    'End Function
    Public Function StockCodeSearch(ByVal objStockCodeSearch As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.StockCodeSearch(objStockCodeSearch)
    End Function

    Public Function Classification_DaysGet(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.Classification_DaysGet(objIPRPPT)
    End Function

    Public Function bind_cmbClassification(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.bind_cmbClassification(objIPRPPT)
    End Function

    Public Function IPRViewSearch(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.IPRViewSearch(objIPRPPT)
    End Function


    Public Function IPRNo_isExist(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.IPRNo_isExist(objIPRPPT)
    End Function

    Public Function Save_IPR(ByVal objIPRSave As IPRPPT) As DataTable
        'IPRNo_isExist(objIPRSave)
        Dim objIPRData As New IPRDAL
        Return objIPRData.Save_IPR(objIPRSave)
    End Function

    Public Function Update_IPR(ByVal objIPRUpdate As IPRPPT) As Integer
        Dim objIPRData As New IPRDAL
        Return objIPRData.Update_IPR(objIPRUpdate)
    End Function

    Public Function Save_IPRDetail(ByVal objIPRPPT As IPRPPT) As Integer
        Dim objIPRData As New IPRDAL
        Return objIPRData.Save_IPRDetail(objIPRPPT)
    End Function

    Public Function Update_IPRApproval(ByVal objIPRPPT As IPRPPT) As Integer
        Dim objIPRData As New IPRDAL
        Return objIPRData.Update_IPRApproval(objIPRPPT)
    End Function
    Public Function Update_IPRDetail(ByVal objIPRPPT As IPRPPT) As Integer
        Dim objIPRData As New IPRDAL
        Return objIPRData.Update_IPRDetail(objIPRPPT)
    End Function
    Public Function Delete_IPRDetail(ByVal objIPRPPT As IPRPPT) As Integer
        Dim objIPRData As New IPRDAL
        Return objIPRData.Delete_IPRDetail(objIPRPPT)
    End Function
    Public Function GetIPRDetails(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetIPRDetails(objIPRPPT)
    End Function

    Public Function GetIPRDetailsInfo(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetIPRDetailsInfo(objIPRPPT)
    End Function
    Public Function StockCategorySearch(ByVal CategorySearch As String) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.StockCategorySearch(CategorySearch)
    End Function
    Public Function GetAvailableQTy(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objIPRData As New IPRDAL
        Return objIPRData.GetAvailableQTy(objIPRPPT)
    End Function
    Public Function IPRRecordIsExisT(ByVal objIPRPPT As IPRPPT) As Object
        Dim objIPRData As New IPRDAL
        Return objIPRData.IPRRecordIsExist(objIPRPPT)
    End Function

    Public Function AcctlookupSearch(ByVal objIPRPPT As IPRPPT, ByVal IsDirect As String) As DataSet
        Dim objIPRData As New IPRDAL
        Return objIPRData.AcctlookupSearch(objIPRPPT, IsDirect)
    End Function

    Public Function DeleteMultiEntryIPR(ByVal ObjIPRPPT As IPRPPT) As Integer

        Dim objIPRData As New IPRDAL
        Return objIPRData.DeleteMultiEntryIPR(ObjIPRPPT)

    End Function

End Class

