Imports Budget_PPT
Imports Budget_DAL
Public Class StandardPriceListBOL
    Public Shared Function InsertStandardPriceList(ByVal objPPT As StandardPriceListPPT) As StandardPriceListPPT
        Return StandardPriceListDAL.InsertStandardPriceList(objPPT)
    End Function
    Public Shared Function SelectExchangeRateStandardPriceList() As DataTable
        Return StandardPriceListDAL.SelectExchangeRateStandardPriceList()
    End Function
    Public Shared Function SelectUOMStandardPriceList() As DataTable
        Return StandardPriceListDAL.SelectUOMStandardPriceList()
    End Function
    Public Shared Function SelectDescStandardPriceList() As DataTable
        Return StandardPriceListDAL.SelectDescStandardPriceList()
    End Function
    Public Shared Function SelectAllStandardPriceList() As DataTable
        Return StandardPriceListDAL.SelectAllStandardPriceList()
    End Function
    Public Shared Function UpdateStandardPriceList(ByVal objPPT As StandardPriceListPPT) As StandardPriceListPPT
        Return StandardPriceListDAL.UpdateStandardPriceList(objPPT)
    End Function
End Class

