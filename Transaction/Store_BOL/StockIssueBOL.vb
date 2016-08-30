Imports Store_DAL
Imports Store_PPT
Public Class StockIssueBOL
    Public Function GetInterfaceYear(ByVal objStockIssuePPT As StockIssuePPT) As DataSet
        Dim objStockIssueDAL As New StockIssueDAL
        Return objStockIssueDAL.GetInterfaceYear(objStockIssuePPT)
    End Function
    Public Function GetTaskComplete(ByVal objStockIssuePPT As StockIssuePPT) As DataSet
        Dim objStockIssueDAL As New StockIssueDAL
        Return objStockIssueDAL.GetTaskComplete(objStockIssuePPT)
    End Function
    Public Function GetFYearDate(ByVal objStockIssuePPT As StockIssuePPT) As DataSet
        Dim objStockIssueDAL As New StockIssueDAL
        Return objStockIssueDAL.GetFYearDate(objStockIssuePPT)
    End Function
End Class
