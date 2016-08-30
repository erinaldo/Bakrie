Imports Budget_DAL
Imports Budget_PPT

Public Class StandardPinkSlipBOL
    Public Shared Function PinkSlipInsert(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Return StandardPinkSlipDAL.PinkSlipInsert(oStandardPinkSlipPPT)
    End Function
    Public Shared Function PinkSlipDetailInsert(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Return StandardPinkSlipDAL.PinkSlipDetailInsert(oStandardPinkSlipPPT)
    End Function
    Public Shared Function PinkSlipSelect(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Return StandardPinkSlipDAL.PinkSlipSelect(oStandardPinkSlipPPT)
    End Function

    Public Shared Function PinkSlipUpdate(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Return StandardPinkSlipDAL.PinkSlipUpdate(oStandardPinkSlipPPT)
    End Function

    Public Shared Function PinkSlipDetailUpdate(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Return StandardPinkSlipDAL.PinkSlipDetailUpdate(oStandardPinkSlipPPT)
    End Function
    Public Shared Function AcctlookupSearch(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT, ByVal IsDirect As String) As DataSet
        Return StandardPinkSlipDAL.AcctlookupSearch(oStandardPinkSlipPPT, IsDirect)
    End Function

    Public Function GetPinkslipRefNo(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As StandardPinkSlipPPT
        Dim oStandardPinkSlipDAL As New StandardPinkSlipDAL
        Return oStandardPinkSlipDAL.GetPinkslipRefNo(oStandardPinkSlipPPT)
    End Function

    Public Shared Function PinkSlipDelete(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As Integer
        Return StandardPinkSlipDAL.PinkSlipDelete(oStandardPinkSlipPPT)
    End Function
    Public Shared Function PinkSlipDetailDelete(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As Integer
        Return StandardPinkSlipDAL.PinkSlipDetailDelete(oStandardPinkSlipPPT)
    End Function
    Public Shared Function PinkSlipSearch(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT, ByVal IsApproval As String) As DataSet
        Return StandardPinkSlipDAL.PinkSlipSearch(oStandardPinkSlipPPT, "NO")
    End Function
    Public Shared Function PinkSlipCOACodeIsvalid(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Return StandardPinkSlipDAL.PinkSlipCOACodeIsvalid(oStandardPinkSlipPPT)
    End Function
    Public Shared Function GetValueMultipleEntry(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Dim oStandardPinkSlipDAL As New StandardPinkSlipDAL
        Return oStandardPinkSlipDAL.GetValueMultipleEntry(oStandardPinkSlipPPT)
    End Function
    Public Shared Function PinkSlipBudgetedAmountGET(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Return StandardPinkSlipDAL.PinkSlipBudgetedAmountGET(oStandardPinkSlipPPT)
    End Function
    Public Shared Function PinkSlipActualAmountGET(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Return StandardPinkSlipDAL.PinkSlipActualAmountGET(oStandardPinkSlipPPT)
    End Function
    Public Function Update_PinkSlipApproval(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As Integer
        Dim oStandardPinkSlipDAL As New StandardPinkSlipDAL
        Return oStandardPinkSlipDAL.Update_PinkSlipApproval(oStandardPinkSlipPPT)
    End Function
End Class
