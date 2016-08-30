Imports System.Data.SqlClient
Imports Common_PPT
Public Class RoleMasterDAL
    Public Shared Function InsertRoleMaster(ByVal objRolePPT As RoleMasterPPT) As RoleMasterPPT
        Dim objdb As New SQLHelp
        Try
            Dim Parms(5) As SqlParameter

            Parms(0) = New SqlParameter("@RoleName", objRolePPT.RoleName)
            Parms(1) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
            Parms(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(3) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today)


            Dim intResult As Integer = objdb.ExecNonQuery("[General].[RoleMasterInsert]", Parms)
        Catch ex As Exception
            ManageException(ex, "RoleMasterDAL", "RoleMasterInsert")
        End Try
        Return objRolePPT
    End Function
    Public Shared Function SelectAllRoleMaster() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Try
            datatable = objdb.ExecQuery("[General].[RoleMasterSelectAll]").Tables(0)

        Catch ex As Exception
            ManageException(ex, "RoleMasterDAL", "RoleMasterSelectAll")
        End Try
        Return datatable

    End Function


    Public Shared Function UpdateRoleMaster(ByVal objRolePPT As RoleMasterPPT) As RoleMasterPPT
        Dim objdb As New SQLHelp
        Try
            Dim Parms(3) As SqlParameter
            Parms(0) = New SqlParameter("@RoleID", objRolePPT.RoleID)
            Parms(1) = New SqlParameter("@RoleName", objRolePPT.RoleName)
            Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(3) = New SqlParameter("@ModifiedOn", Date.Today)

            Dim intResult As Integer = objdb.ExecNonQuery("[General].[RoleMasterUpdate]", Parms)
        Catch ex As Exception
            ManageException(ex, "RoleMasterDal", "UpdateRoleMaster")
        End Try
        Return objRolePPT
    End Function
    Public Shared Function DeleteRoleMaster(ByVal objRolePPT As RoleMasterPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intResult As Integer
        Try
            Dim Parms(0) As SqlParameter
            Parms(0) = New SqlParameter("@RoleID", objRolePPT.RoleID)
            intResult = objdb.DeleteRecord("[General].[RoleMasterDelete]", Parms)

        Catch ex As Exception
            ManageException(ex, "RoleMasterDAL", "DeleteRoleMaster")
        End Try
        Return intResult
    End Function
    Public Shared Function SelectRoleName(ByVal objRolePPT As RoleMasterPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@RoleName", objRolePPT.RoleName)
        Try
            datatable = objdb.ExecQuery("[General].[RoleNameValidate]", Parms).Tables(0)

        Catch ex As Exception
            ManageException(ex, "RoleMasterDal", "SelectRoleName")
        End Try
        Return datatable

    End Function
End Class
