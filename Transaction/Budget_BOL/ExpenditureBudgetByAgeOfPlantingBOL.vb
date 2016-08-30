Imports Budget_DAL
Imports Budget_PPT

Public Class ExpenditureBudgetByAgeOfPlantingBOL
    Public Shared Function RoundedUpValueGET(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Return ExpenditureBudgetByAgeOfPlantingDAL.RoundedUpValueGET(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function

    Public Shared Function AcctlookupSearch(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.AcctlookupSearch(oExpenditureBudgetByAgeOfPlantingPPT, IsDirect)
    End Function

    Public Function UOMLookupSearch(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.UOMLookupSearch(oExpenditureBudgetByAgeOfPlantingPPT, IsDirect)
    End Function
    Public Function UOMLookupSearch1(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.UOMLookupSearch1(oExpenditureBudgetByAgeOfPlantingPPT, IsDirect)
    End Function
    Public Function UOMLookupSearch2(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.UOMLookupSearch2(oExpenditureBudgetByAgeOfPlantingPPT, IsDirect)
    End Function
    Public Function MaterialCheck(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.MaterialCheck(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function ExpenditureBudgetByAgeOfPlantingMainInsert(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.ExpenditureBudgetByAgeOfPlantingMainInsert(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function EBBAOPMaterialInsert(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPMaterialInsert(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function EBBAOPOtherInsert(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPOtherInsert(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function ExpenditureBudgetByAgeOfPlantingMainUpdate(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.ExpenditureBudgetByAgeOfPlantingMainUpdate(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function EBBAOPMaterialUpdate(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPMaterialUpdate(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function EBBAOPOtherUpdate(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPOtherUpdate(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Function StandardPriceListStockLoopUPSelect(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.StandardPriceListStockLoopUPSelect(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function FillViewGrid(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Return ExpenditureBudgetByAgeOfPlantingDAL.FillViewGrid(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function FillMainGrid(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Return ExpenditureBudgetByAgeOfPlantingDAL.FillMainGrid(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function MaterialGridFill(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Return ExpenditureBudgetByAgeOfPlantingDAL.MaterialGridFill(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function OtherGridFill(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Return ExpenditureBudgetByAgeOfPlantingDAL.OtherGridFill(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function EBBAOPViewDelete(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPViewDelete(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function EBBAOPOtherDelete(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As Integer
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPOtherDelete(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function EBBAOPMaterialDelete(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As Integer
        Return ExpenditureBudgetByAgeOfPlantingDAL.EBBAOPMaterialDelete(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
    Public Shared Function ExpenditureBudgetByAgeOfPlantingIsExist(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Return ExpenditureBudgetByAgeOfPlantingDAL.ExpenditureBudgetByAgeOfPlantingIsExist(oExpenditureBudgetByAgeOfPlantingPPT)
    End Function
End Class
