Imports Budget_DAL
Imports Budget_PPT
Public Class RiceBOL
    Public Shared Function RiceMaritalStatusGet() As DataSet
        Return RiceDAL.RiceMaritalStatusGet()
    End Function
    Public Shared Function RiceSelect(ByVal oRicePPT As RicePPT) As DataTable
        Return RiceDAL.RiceSelect(oRicePPT)
    End Function
    Public Shared Function RiceViewSelect(ByVal oRicePPT As RicePPT) As DataTable
        Return RiceDAL.RiceViewSelect(oRicePPT)
    End Function
    Public Shared Function RiceMainInsert(ByVal oRicePPT As RicePPT) As DataSet
        Return RiceDAL.RiceMainInsert(oRicePPT)
    End Function
    Public Shared Function RiceInsert(ByVal oRicePPT As RicePPT) As DataSet
        Return RiceDAL.RiceInsert(oRicePPT)
    End Function

    Public Shared Function RiceExist(ByVal oRicePPT As RicePPT) As DataTable
        Return RiceDAL.RiceExist(oRicePPT)
    End Function
    Public Shared Function RiceMainUpdate(ByVal oRicePPT As RicePPT) As DataSet
        Return RiceDAL.RiceMainUpdate(oRicePPT)
    End Function
    Public Shared Function RiceUpdate(ByVal oRicePPT As RicePPT) As DataSet
        Return RiceDAL.RiceUpdate(oRicePPT)
    End Function
    Public Shared Function RiceMainDelete(ByVal oRicePPT As RicePPT) As DataSet
        Return RiceDAL.RiceMainDelete(oRicePPT)
    End Function
    Public Shared Function RiceDelete(ByVal oRicePPT As RicePPT) As DataSet
        Return RiceDAL.RiceDelete(oRicePPT)
    End Function
End Class


