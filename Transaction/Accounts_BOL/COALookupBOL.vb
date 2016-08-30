Imports Accounts_DAL
Imports Accounts_PPT
Imports System.Data
Public Class COALookupBOL
    Public Shared Function SelectAllParentCOA(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.SelectAllParentCOA(objCOAPPT)
    End Function

    Public Shared Function SelectAllChildCOA(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.SelectAllChildCOA(objCOAPPT)
    End Function

    Public Shared Function LoadCOAGrid(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.LoadCOAGrid(objCOAPPT)
    End Function

    Public Shared Function LoadCOAGridByCOAID(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.LoadCOAGridByCOAID(objCOAPPT)
    End Function

    Public Shared Function ParentIdGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.ParentIdGet(objCOAPPT)
    End Function

    Public Shared Function ParentCodeGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.ParentCodeGet(objCOAPPT)
    End Function

    Public Shared Function ChildCOAIDGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.ChildCOAIDGet(objCOAPPT)
    End Function

    Public Shared Function ChildCOACodeGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.ChildCOACodeGet(objCOAPPT)
    End Function
    Public Shared Function COALookUpGridFillByOLDCOACode(ByVal objCOAPPT As COALookupPPT) As DataTable
        Return COALookupDAL.COALookUpGridFillByOLDCOACode(objCOAPPT)
    End Function

End Class
