Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class TPHGrading_BOL

    Public Shared Function GetDivisions(ByVal strEtstae As String) As DataTable
        Return TPHGrading_DAL.GetDivisions(strEtstae)
    End Function

    Public Shared Function GetBlocks(ByVal strEtstae As String, ByVal DivisionID As String) As DataTable
        Return TPHGrading_DAL.GetBlocks(strEtstae, DivisionID)
    End Function

    Public Shared Function GetTPH(ByVal strEstate As String, ByVal BlockID As String) As DataTable
        Return TPHGrading_DAL.GetTPH(strEstate, BlockID)
    End Function

    Public Shared Function TPHGradingSelect(ByVal strEstate As String, ByVal TPHGradingID As String) As DataTable
        Return TPHGrading_DAL.TPHGradingSelect(strEstate, TPHGradingID)
    End Function

    Public Shared Function TPHGradingDetailSelect(ByVal TPHGradingID As String) As DataTable
        Return TPHGrading_DAL.TPHGradingDetailSelect(TPHGradingID)
    End Function

    Public Shared Function TPHGradingSelect() As DataTable
        Return TPHGrading_DAL.TPHGradingSelect()
    End Function

    Public Shared Function GetEmployeeName(ByVal EmpCode As String) As String
        Return TPHGrading_DAL.GetEmployeeName(EmpCode)
    End Function

    Public Shared Function TPHGradingCheckExist(ByVal ReceptionDate As Date, ByVal TPH As String) As Boolean
        Return TPHGrading_DAL.TPHGradingCheckExist(ReceptionDate, TPH)
    End Function

    Public Shared Function TPHGradingDocumentNoExist(ByVal DocumentNo As String) As Boolean
        Return TPHGrading_DAL.TPHGradingDocumentNoExist(DocumentNo)
    End Function

    Public Shared Function TPHGradingSave(ByVal objTPHGrading_PPT As TPHGrading_PPT) As String
        Return TPHGrading_DAL.TPHGradingSave(objTPHGrading_PPT)
    End Function

    Public Shared Function TPHGradingDetailSave(ByVal objTPHGrading_PPT As TPHGrading_PPT) As DataSet
        Return TPHGrading_DAL.TPHGradingDetailSave(objTPHGrading_PPT)
    End Function

    Public Shared Function TPHGradingDelete(ByVal TPHGradingID As String) As String
        Return TPHGrading_DAL.TPHGradingDelete(TPHGradingID)
    End Function

    Public Shared Function TPHGradingSelectByDate(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Return TPHGrading_DAL.TPHGradingSelectByDate(FromDate, ToDate)
    End Function
End Class
