Imports Production_DAL
Imports Production_PPT
Public Class GradingFFBBOL

    Public Shared Function saveGradingFFB(ByVal objGradingFFBPPT As GradingFFBPPT) As DataSet
        Return GradingFFBDAL.SaveGradingFFB(objGradingFFBPPT)
    End Function

    Public Function UpdateGradingFFB(ByVal objGradingFFBPPT As GradingFFBPPT) As DataSet
        Return GradingFFBDAL.UpDateGradingFFB(objGradingFFBPPT)
    End Function

    Public Function DeleteGradingFFB(ByVal objGradingFFBPPT As GradingFFBPPT) As Integer
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.DeleteGradingFFP(objGradingFFBPPT)
    End Function
    Public Function GetGradingFFB(ByVal objGradingFFBPPT As GradingFFBPPT) As DataTable
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GetGradingFFB(objGradingFFBPPT)
    End Function

    Public Function GetGradingFFBTicket(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataTable
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GetGradingFFBTicket(ObjGradingFFBPPT)
    End Function
    Public Function DuplicateGradingFFBCheck(ByVal objGradingFFBPPT As GradingFFBPPT) As Object
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.DuplicateWBTicketCheck(objGradingFFBPPT)
    End Function

    Public Function WBTicketNoLookupSearch(ByVal objGradingFFBPPT As GradingFFBPPT, ByVal IsDirect As String) As DataSet
        Return GradingFFBDAL.WBTicketNoLookupSearch(objGradingFFBPPT, IsDirect)
    End Function

    Public Function GetGradeValues(ByVal objGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GetGradeValues(objGradingFFBPPT)
    End Function

    Public Function GetGradingDocumentNumber() As String
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GetGradingDocumentNumber()
    End Function

    Public Function GetBlockDetailValues(ByVal objGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GetBlockDetailValues(objGradingFFBPPT)
    End Function

    Public Function GradingFFBRecordIsExisT(ByVal objGradingFFBPPT As GradingFFBPPT) As Object
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GradingFFBRecordIsExist(objGradingFFBPPT)
    End Function
    Public Function GradingFFBMonthYearGet(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim objGradingFFBDAL As New GradingFFBDAL
        Return objGradingFFBDAL.GradingFFBMonthYearGet(ObjGradingFFBPPT)
    End Function

End Class
