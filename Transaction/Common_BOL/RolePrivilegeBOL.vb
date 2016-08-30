Imports Common_PPT
Imports Common_DAL
Public Class RolePrivilegeBOL
    Public Shared Function SelectAllRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As DataTable
        Return RolePrivilegeDAL.SelectAllRolePrivilege(objRolePPT)
    End Function
    Public Shared Function SelectAllModule() As DataTable
        Return RolePrivilegeDAL.SelectAllModule()
    End Function
    Public Shared Function SelectAllMenuGroup(ByVal objRolePPT As RolePrivilegePPT) As DataTable
        Return RolePrivilegeDAL.SelectAllMenuGroup(objRolePPT)
    End Function
    Public Shared Function SelectAllMenu(ByVal objRolePPT As RolePrivilegePPT) As DataTable
        Return RolePrivilegeDAL.SelectAllMenu(objRolePPT)
    End Function
    Public Shared Function InsertRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As Integer
        Return RolePrivilegeDAL.InsertRolePrivilege(objRolePPT)
    End Function
    Public Shared Function UpdateRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As Integer  'RolePrivilegePPT
        Return RolePrivilegeDAL.UpdateRolePrivilege(objRolePPT)
    End Function
    Public Shared Function DeleteRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As Integer
        Return RolePrivilegeDAL.DeleteRolePrivilege(objRolePPT)
    End Function
End Class
