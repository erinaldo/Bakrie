Imports Budget_PPT
Imports Budget_DAL

Public Class WorkshopExpenditureBOL
    Public Shared Function WorkshopExpendCOACodeIsvalid(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Return WorkshopExpenditureDAL.WorkshopExpendCOACodeIsvalid(oWorkshopExpenditurePPT)
    End Function
    Public Shared Function AcctlookupSearch(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT, ByVal IsDirect As String) As DataSet
        Return WorkshopExpenditureDAL.AcctlookupSearch(oWorkshopExpenditurePPT, IsDirect)
    End Function
    Public Shared Function WorkshopExpendInsert(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Return WorkshopExpenditureDAL.WorkshopExpenditureInsert(oWorkshopExpenditurePPT)
    End Function
    Public Shared Function WorkshopExpendUpdate(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Return WorkshopExpenditureDAL.WorkshopExpendUpdate(oWorkshopExpenditurePPT)
    End Function
    Public Shared Function WorkshopExpendSelect(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataTable
        Return WorkshopExpenditureDAL.WorkshopExpendSelect(oWorkshopExpenditurePPT)
    End Function

    Public Shared Function WorkshopExpendDelete(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Return WorkshopExpenditureDAL.WorkshopExpendDelete(oWorkshopExpenditurePPT)
    End Function
End Class
