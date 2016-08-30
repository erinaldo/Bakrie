Imports Common_PPT
Imports Common_DAL
Public Class RoleMasterBOL
    Public Shared Function InsertRoleMaster(ByVal objRolePPT As RoleMasterPPT) As RoleMasterPPT
        Return RoleMasterDAL.InsertRoleMaster(objRolePPT)
    End Function
    Public Shared Function SelectAllRoleMaster() As DataTable
        Return RoleMasterDAL.SelectAllRoleMaster()
    End Function
    Public Shared Function UpdateRoleMaster(ByVal objRolePPT As RoleMasterPPT) As RoleMasterPPT
        Return RoleMasterDAL.UpdateRoleMaster(objRolePPT)
    End Function
    Public Shared Function DeleteRoleMaster(ByVal objRolePPT As RoleMasterPPT) As Integer
        Return RoleMasterDAL.DeleteRoleMaster(objRolePPT)
    End Function
    'Public Shared Function insertRoleMaster1(ByVal objRollPPT As RoleMasterPPT) As RoleMasterPPT
    '    Return RoleMasterDAL.InsertRoleMaster(objRollPPT)
    'End Function
    Public Shared Function SelectRoleName(ByVal objRolePPT As RoleMasterPPT) As DataTable
        Return RoleMasterDAL.SelectRoleName(objRolePPT)
    End Function
End Class

