Imports Budget_PPT
Imports Budget_DAL
Public Class AdministrationExpenditureBOL
    Public Shared Function AdminExpendInsert(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Return AdministrationExpenditureDAL.AdminExpendInsert(oAdministrationExpenditurePPT)
    End Function

    Public Shared Function ExpBudAdminExpendSelect(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataTable
        Return AdministrationExpenditureDAL.ExpBudAdminExpendSelect(oAdministrationExpenditurePPT)

    End Function

    Public Shared Function AcctlookupSearch(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT, ByVal IsDirect As String) As DataSet
        Return AdministrationExpenditureDAL.AcctlookupSearch(oAdministrationExpenditurePPT, IsDirect)
    End Function
    Public Shared Function AdminExpendCOACodeIsvalid(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Return AdministrationExpenditureDAL.AdminExpendCOACodeIsvalid(oAdministrationExpenditurePPT)
    End Function

    Public Shared Function ExpBudAdminExpendUpdate(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Return AdministrationExpenditureDAL.ExpBudAdminExpendUpdate(oAdministrationExpenditurePPT)
    End Function

    Public Shared Function AdminExpendDelete(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Return AdministrationExpenditureDAL.AdminExpendDelete(oAdministrationExpenditurePPT)

    End Function

    Public Shared Function AdminExpendCOACodeSearch(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Return AdministrationExpenditureDAL.AdminExpendCOACodeSearch(oAdministrationExpenditurePPT)
    End Function
End Class