Imports System.Data.SqlClient
Imports Common_PPT
Public Class RolePrivilegeDAL
    Public Shared Function SelectAllRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@RoleID", objRolePPT.RoleID)
        Try
            datatable = objdb.ExecQuery("[General].[RolePrivilegeSelectAll]", Parms).Tables(0)

        Catch ex As Exception
            ManageException(ex, "RolePrivilegeDAL", "[RolePrivilegeSelectAll]")
        End Try
        Return datatable

    End Function
    Public Shared Function SelectAllModule() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Try
            datatable = objdb.ExecQuery("[General].[ModuleSelectAll]").Tables(0)

        Catch ex As Exception
            ManageException(ex, "RolePrivilegeDAL", "[ModuleSelectAll]")
        End Try
        Return datatable

    End Function
    Public Shared Function SelectAllMenuGroup(ByVal objRolePPT As RolePrivilegePPT) As DataTable

        Dim objdb As New SQLHelp
        ' Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", objRolePPT.ModID)
        'Parms(1) = New SqlParameter("@MenuID", objRolePPT.MenuID)
        'Parms(1) = New SqlParameter("DesgID", objUserPPT.DesgID)
        Try
            RolePrivilegePPT.dtMenuGroup = objdb.ExecQuery("[General].[MenuGroupSelectByModule]", Parms).Tables(0)

        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "MenuGroupSelectByModule")
        End Try
        'Dim i As Integer = datatable.Rows.Count
        Return RolePrivilegePPT.dtMenuGroup

    End Function

    Public Shared Function SelectAllMenu(ByVal objRolePPT As RolePrivilegePPT) As DataTable

        Dim objdb As New SQLHelp
        '  Dim datatable As New DataTable()
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", objRolePPT.ModID)
        Parms(1) = New SqlParameter("@MenuGroupID", objRolePPT.MenuGroupID)
        Parms(2) = New SqlParameter("@IncludeAll", objRolePPT.IncludeAll)
        'Parms(1) = New SqlParameter("@MenuID", objRolePPT.MenuID)
        'Parms(1) = New SqlParameter("DesgID", objUserPPT.DesgID)
        Try
            RolePrivilegePPT.dtMenu = objdb.ExecQuery("[General].[MenuSelect]", Parms).Tables(0)

        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "MenuSelect")
        End Try
        Return RolePrivilegePPT.dtMenu

    End Function

    Public Shared Function InsertRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As Integer
        Dim objdb As New SQLHelp
        'Dim datatable As New DataTable()
        Dim intReturn As Integer = 0
        Try
            Dim Parms(11) As SqlParameter
            Parms(0) = New SqlParameter("@RoleID", objRolePPT.RoleID)
            Parms(1) = New SqlParameter("@ModID", objRolePPT.ModID)
            Parms(2) = New SqlParameter("@MenuGroupID", objRolePPT.MenuGroupID)
            Parms(3) = New SqlParameter("@MenuID", objRolePPT.MenuID)
            Parms(4) = New SqlParameter("@Visible", objRolePPT.Visible)
            Parms(5) = New SqlParameter("@RAdd", objRolePPT.RAdd)
            Parms(6) = New SqlParameter("@RUpdate", objRolePPT.RUpdate)
            Parms(7) = New SqlParameter("@RDelete", objRolePPT.RDelete)
            Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(9) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(11) = New SqlParameter("@ModifiedOn", Date.Today)

            'Dim intResult As Integer = objdb.ExecNonQuery("[General].[RolePrivilegeInsert]", Parms)
            intReturn = objdb.ExecNonQuery("[General].[RolePrivilegeInsert]", Parms)
            Return intReturn
        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "RolePrivilegeInsert")
        End Try

    End Function
    Public Shared Function UpdateRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As Integer
        Dim objdb As New SQLHelp
        Dim intResult As Integer = 0
        Try
            Dim Parms(10) As SqlParameter
            Parms(0) = New SqlParameter("@RolePrivilegeID", objRolePPT.RolePrivilegeID)
            Parms(1) = New SqlParameter("@RoleID", objRolePPT.RoleID)
            Parms(2) = New SqlParameter("@ModID", objRolePPT.ModID)
            Parms(3) = New SqlParameter("@MenuGroupID", objRolePPT.MenuGroupID)
            Parms(4) = New SqlParameter("@MenuID", objRolePPT.MenuID)
            Parms(5) = New SqlParameter("@Visible", objRolePPT.Visible)
            Parms(6) = New SqlParameter("@RAdd", objRolePPT.RAdd)
            Parms(7) = New SqlParameter("@RUpdate", objRolePPT.RUpdate)
            Parms(8) = New SqlParameter("@RDelete", objRolePPT.RDelete)
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)

            intResult = objdb.ExecNonQuery("[General].[RolePrivilegeUpdate]", Parms)
        Catch ex As Exception
            ManageException(ex, "RolePrivilegeDal", "RolePrivilegeUpdate")
        End Try
        Return intResult
    End Function
    Public Shared Function DeleteRolePrivilege(ByVal objRolePPT As RolePrivilegePPT) As Integer
        Dim objdb As New SQLHelp
        Dim intResult As Integer
        Try
            Dim Parms(0) As SqlParameter
            Parms(0) = New SqlParameter("@RolePrivilegeID", objRolePPT.RolePrivilegeID)

            intResult = objdb.DeleteRecord("[General].[RolePrivilegeDelete]", Parms)

        Catch ex As Exception
            ManageException(ex, "RolePrivilegeDAL", "RolePrivilegeDelete")
        End Try
        Return intResult
    End Function
End Class
