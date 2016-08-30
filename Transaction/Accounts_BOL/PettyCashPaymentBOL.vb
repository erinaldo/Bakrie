Imports Accounts_PPT
Imports Accounts_DAL
Public Class PettyCashPaymentBOL
    Public Shared Function DeleteMultiEntryPettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As Integer
        Return PettyCashPaymentDAL.DeleteMultiEntryPettyCashPayment(ObjPettyCashPaymentPPT)
    End Function
    Public Shared Function savePettyCashPayment(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As DataSet
        Return PettyCashPaymentDAL.SavePettyCashPayment(objPettyPaymentPPT)
    End Function

    Public Function UpdatePettyCashPayment(ByVal objPettyPaymentPPT As PettyCashPaymentPPT, ByVal IsApproval As String) As DataSet
        Return Accounts_DAL.PettyCashPaymentDAL.UpdatePettyCashPayment(objPettyPaymentPPT, IsApproval)
    End Function

    Public Function DeletePettyCashPayment(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As Integer
        Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
        Return objPettyCashPaymentDAL.DeletePettyCashPayment(objPettyPaymentPPT)
    End Function


    Public Function GetPettyCashPayment(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As DataTable
        Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
        Return objPettyCashPaymentDAL.GetPettyCashPayment(objPettyPaymentPPT)
    End Function
    Public Function GetValueMultipleEntry(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As DataTable
        Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
        Return objPettyCashPaymentDAL.GetValueMultipleEntry(objPettyPaymentPPT)
    End Function


    Public Function DuplicatePettycashPaymentCheck(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As Object
        Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
        Return objPettyCashPaymentDAL.DuplicatePettycashPaymentCheck(objPettyPaymentPPT)
    End Function

    Public Function GetPayToValue(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As DataTable
        Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
        Return objPettyCashPaymentDAL.GetPayToValue(objPettyPaymentPPT)
    End Function

    Public Function AcctlookupSearch(ByVal objPettyPaymentPPT As PettyCashPaymentPPT, ByVal IsDirect As String) As DataSet
        Return PettyCashPaymentDAL.AcctlookupSearch(objPettyPaymentPPT, IsDirect)
    End Function

    Public Function TlookupSearch(ByVal objPettyPaymentPPT As PettyCashPaymentPPT, ByVal IsDirect As String) As DataSet
        Return PettyCashPaymentDAL.TlookupSearch(objPettyPaymentPPT, IsDirect)
    End Function

    Public Shared Function PCPLedgerAllModuleInsert(ByVal objPCPPPT As PettyCashPaymentPPT) As DataSet
        Return PettyCashPaymentDAL.PCPLedgerAllModuleInsert(objPCPPPT)
    End Function

    Public Function UOMLookupSearch(ByVal objPCPPPT As PettyCashPaymentPPT, ByVal IsDirect As String) As DataSet
        Return PettyCashPaymentDAL.UOMLookupSearch(objPCPPPT, IsDirect)
    End Function
    Public Function GetPettyCashPaymentForReport(ByVal objPettyPaymentPPT As PettyCashPaymentPPT) As DataTable
        Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
        Return objPettyCashPaymentDAL.GetPettyCashPaymentForReport(objPettyPaymentPPT)
    End Function

    Public Function PettyCashPaymentAmountCheck(ByVal objPCPPPT As PettyCashPaymentPPT) As DataSet
        Return PettyCashPaymentDAL.PettyCashPaymentAmountCheck(objPCPPPT)
    End Function


    '' Delete Multienty Journal Entry

    'Public Shared Function DeleteMultiEntryPettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As Integer
    '    'Dim objPettyCashPaymentDAL As New PettyCashPaymentDAL
    '    'Return PettyCashPaymentDAL.DeleteMultiEntryPettyCashPayment(ObjPettyCashPaymentPPT)
    'End Function

End Class
