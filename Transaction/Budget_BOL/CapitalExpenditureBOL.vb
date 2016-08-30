Imports Budget_PPT
Imports Budget_DAL

Public Class CapitalExpenditureBOL
    Public Shared Function CapitalExpendCOACodeIsvalid(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Return CapitalExpenditureDAL.CapitalExpendCOACodeIsvalid(oCapitalExpenditurePPT)
    End Function
    Public Shared Function AcctlookupSearch(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT, ByVal IsDirect As String) As DataSet
        Return CapitalExpenditureDAL.AcctlookupSearch(oCapitalExpenditurePPT, IsDirect)
    End Function
    Public Shared Function CapitalExpendInsert(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Return CapitalExpenditureDAL.CapitalExpenditureInsert(oCapitalExpenditurePPT)
    End Function
    Public Shared Function CapitalExpendUpdate(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Return CapitalExpenditureDAL.CapitalExpendUpdate(oCapitalExpenditurePPT)
    End Function
    Public Shared Function CapitalExpendSelect(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataTable
        Return CapitalExpenditureDAL.CapitalExpendSelect(oCapitalExpenditurePPT)
    End Function
    Public Shared Function CapitalExpenditureSelect_Multi(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataTable
        Return CapitalExpenditureDAL.CapitalExpenditureSelect_Multi(oCapitalExpenditurePPT)
    End Function
    Public Shared Function CapitalExpendDelete(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Return CapitalExpenditureDAL.CapitalExpendDelete(oCapitalExpenditurePPT)
    End Function
End Class
