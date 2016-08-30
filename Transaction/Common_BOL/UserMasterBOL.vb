Imports Common_PPT
Imports Common_DAL
Public Class UserMasterBOL
    Public Shared Function InsertDesignation(ByVal objDesigPPT As UserMasterPPT) As UserMasterPPT
        Return UserMasterDAL.InsertDesignation(objDesigPPT)
    End Function
    Public Shared Function UpdateDesignation(ByVal objDesigPPT As UserMasterPPT) As UserMasterPPT
        Return UserMasterDAL.UpdateDesignation(objDesigPPT)
    End Function

    Public Shared Function DeleteDesignation(ByVal objDesigPPT As UserMasterPPT) As Integer
        Return UserMasterDAL.DeleteDesignation(objDesigPPT)
    End Function

    Public Shared Function SelectAllDesignations() As DataTable
        Return UserMasterDAL.SelectAllDesignations()
    End Function
    Public Shared Function SelectDesgName(ByVal objUserPPT As UserMasterPPT) As DataTable
        Return UserMasterDAL.SelectDesgName(objUserPPT)
    End Function
    Public Shared Function InsertUserMaster(ByVal objUserPPT As UserMasterPPT) As UserMasterPPT
        Return UserMasterDAL.InsertUserMaster(objUserPPT)
    End Function
    Public Shared Function selectAllUserMaster() As DataTable
        Return UserMasterDAL.SelectAllUserMaster()
    End Function
    Public Shared Function SelectUserName(ByVal objUserPPT As UserMasterPPT) As DataTable
        Return UserMasterDAL.SelectUserName(objUserPPT)
    End Function
    Public Shared Function DeleteUserMaster(ByVal objUserPPT As UserMasterPPT) As Integer
        Return UserMasterDAL.DeleteUserMaster(objUserPPT)
    End Function
    Public Shared Function UpdateUserMaster(ByVal objUserPPT As UserMasterPPT) As UserMasterPPT
        Return UserMasterDAL.UpdateUserMaster(objUserPPT)
    End Function
    Public Shared Function selectAllUserName() As DataTable
        Return UserMasterDAL.SelectAllUserName()
    End Function
    Public Shared Function ChangePasswordDesgName(ByVal objUserPPT As UserMasterPPT) As DataTable
        Return UserMasterDAL.ChangePasswordDesgName(objUserPPT)
    End Function
    Public Shared Function UpdateChangePassword(ByVal objUserPPT As UserMasterPPT) As UserMasterPPT
        Return UserMasterDAL.UpdateChangePassword(objUserPPT)
    End Function

End Class