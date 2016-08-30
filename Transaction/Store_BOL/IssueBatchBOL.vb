Imports Store_DAL
Imports Store_PPT
Public Class IssueBatchBOL
    Public Shared Function saveIssueBatch(ByVal objIssueBatch As IssueBatchPPT) As Double
        Return IssueBatchDAL.saveIssueBatch(objIssueBatch)
    End Function
    Public Shared Function UpdateIssueBatch(ByVal objIssueBatch As IssueBatchPPT) As Double
        Return IssueBatchDAL.UpdateIssueBatch(objIssueBatch)
    End Function
    Public Shared Function LoaddgIssueBatch(ByVal objIssueBatch As IssueBatchPPT) As DataTable
        Return IssueBatchDAL.LoaddgIssueBatch(objIssueBatch)
    End Function
    Public Shared Function IssueBatchSIVNOIsExist(ByVal objIssueBatch As IssueBatchPPT) As DataSet
        Return IssueBatchDAL.IssueBatchSIVNOIsExist(objIssueBatch)
    End Function
End Class
