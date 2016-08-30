Imports System.Data.SqlClient
Imports Common_PPT
Public Class UserMasterDAL

    Public Shared Function InsertDesignation(ByVal objDesigPPT As UserMasterPPT) As UserMasterPPT
        Dim objdb As New SQLHelp
        Try
            Dim Parms(5) As SqlParameter
            Parms(0) = New SqlParameter("@Desg", objDesigPPT.Desg)
            Parms(1) = New SqlParameter("@DLevel", objDesigPPT.DLevel)
            Parms(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(3) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today)

            Dim intResult As Integer = objdb.ExecNonQuery("[General].[DesignationInsert]", Parms)
        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "InsertDesignation")
        End Try
        Return objDesigPPT
    End Function

    Public Shared Function UpdateDesignation(ByVal objDesigPPT As UserMasterPPT) As UserMasterPPT
        Dim objdb As New SQLHelp
        Try
            Dim Parms(4) As SqlParameter
            Parms(0) = New SqlParameter("@DesgID", objDesigPPT.DesgID)
            Parms(1) = New SqlParameter("@Desg", objDesigPPT.Desg)
            Parms(2) = New SqlParameter("@DLevel", objDesigPPT.DLevel)
            Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@ModifiedOn", Date.Today)

            Dim intResult As Integer = objdb.ExecNonQuery("[General].[DesignationUpdate]", Parms)
        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "InsertDesignation")
        End Try
        Return objDesigPPT
    End Function

    Public Shared Function DeleteDesignation(ByVal objDesigPPT As UserMasterPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intResult As Integer
        Try
            Dim Parms(0) As SqlParameter
            Parms(0) = New SqlParameter("@DesgID", objDesigPPT.DesgID)
            intResult = objdb.DeleteRecord("[General].[DesignationDelete]", Parms)

        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "InsertDesignation")
        End Try
        Return intResult
    End Function

    Public Shared Function SelectAllUserName() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        'Dim dataset As New DataSet
        Try
            datatable = objdb.ExecQuery("[General].[UsermasterSelectAll]").Tables(0)

        Catch ex As Exception
            ManageException(ex, "UserMasterDAL", "UsermasterSelectAll")
        End Try
        Return datatable
    End Function
    Public Shared Function SelectAllDesignations() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        'Dim dataset As New DataSet
        Try
            datatable = objdb.ExecQuery("[General].[SelectAllDesignations]").Tables(0)

        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "SelectAllDesignations")
        End Try
        Return datatable

    End Function
    Public Shared Function SelectDesgName(ByVal objUserPPT As UserMasterPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@Desg", objUserPPT.Desg)
        'Parms(1) = New SqlParameter("DesgID", objUserPPT.DesgID)
        Try
            datatable = objdb.ExecQuery("[General].[DesignationNameValidate]", Parms).Tables(0)

        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "SelectDesgName")
        End Try
        Return datatable

    End Function

    Public Shared Function InsertUserMaster(ByVal objUserPPT As UserMasterPPT) As UserMasterPPT
        Dim objdb As New SQLHelp

        Try
            Dim Parms(9) As SqlParameter
            Dim pwd As Byte()
            objUserPPT.MSPwd = EncryptionDAL.Encrypt(objUserPPT.MSPwd)
            pwd = ConvertStringToByteArray(objUserPPT.MSPwd)
            Parms(0) = New SqlParameter("@UserName", objUserPPT.MSUserName)
            Parms(1) = New SqlParameter("@DispName", objUserPPT.MSDispName)
            Parms(2) = New SqlParameter("@Pwd", pwd)
            Parms(3) = New SqlParameter("@DesgID", objUserPPT.MSDesgID)
            Parms(4) = New SqlParameter("@RoleID", objUserPPT.MSRoleID)
            Parms(5) = New SqlParameter("@Estatecode", "01") 'GlobalPPT.strEstateCode)
            Parms(6) = New SqlParameter("@CreatedBy", "System") 'GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(8) = New SqlParameter("@ModifiedBy", "System")
            Parms(9) = New SqlParameter("@ModifiedOn", Date.Today)

            
            Dim intResult As Integer = objdb.ExecNonQuery("[General].[UserMasterInsert]", Parms)
        Catch ex As Exception
            ManageException(ex, "UserMasterDAL", "InsertUserMaster")
        End Try
        Return objUserPPT
    End Function

    Public Shared Function SelectAllUserMaster() As DataTable
        Dim objdb As New SQLHelp
        ' Dim objEncrypt As New EncryptDAL()
        Dim datatable As New DataTable()
        Dim UserTable As New DataTable
        Dim objUserMasterPPT As New UserMasterPPT()
        'Try
        datatable = objdb.ExecQuery("[General].[UserMasterSelectAll]").Tables(0)
        ' Dim str As String = datatable.Rows(0).Item("Pwd").ToString()
        If datatable.Rows.Count <> 0 Then

            'UserTable = UserMasterBOL.selectAllUserMaster()
            Dim dc1 As DataColumn
            Dim dc2 As DataColumn
            Dim dc3 As DataColumn
            Dim dc4 As DataColumn
            Dim dc5 As DataColumn
            Dim dc6 As DataColumn
            Dim dc7 As DataColumn
            Dim dc8 As DataColumn
            Dim dr As DataRow
            Dim intCount As Integer = datatable.Rows.Count
            dc1 = New DataColumn("UserID")
            UserTable.Columns.Add(dc1)
            dc2 = New DataColumn("UserName")
            UserTable.Columns.Add(dc2)
            dc3 = New DataColumn("DispName")
            UserTable.Columns.Add(dc3)
            dc4 = New DataColumn("DesgID")
            UserTable.Columns.Add(dc4)
            dc5 = New DataColumn("RoleID")
            UserTable.Columns.Add(dc5)
            dc6 = New DataColumn("RoleName")
            UserTable.Columns.Add(dc6)
            dc7 = New DataColumn("Desg")
            UserTable.Columns.Add(dc7)
            dc8 = New DataColumn("Pwd")
            UserTable.Columns.Add(dc8)
            For i As Integer = 0 To intCount - 1

                dr = UserTable.NewRow()

                dr("UserID") = datatable.Rows(i).Item("UserID").ToString()
                dr("UserName") = datatable.Rows(i).Item("UserName").ToString()
                dr("DispName") = datatable.Rows(i).Item("DispName").ToString()
                dr("DesgID") = datatable.Rows(i).Item("DesgID").ToString()
                dr("RoleID") = datatable.Rows(i).Item("RoleID").ToString()
                dr("RoleName") = datatable.Rows(i).Item("RoleName").ToString()
                dr("Desg") = datatable.Rows(i).Item("Desg").ToString()
                Dim stPwd As String
                stPwd = datatable.Rows(i).Item("Pwd").ToString()
                Dim enc As System.Text.Encoding = System.Text.Encoding.Unicode
                Dim bytArray() As Byte = enc.GetBytes(stPwd)
                stPwd = enc.GetString(datatable.Rows(i).Item("Pwd"))
                dr("Pwd") = EncryptionDAL.Decrypt(stPwd.Trim())
                UserTable.Rows.InsertAt(dr, i)

            Next
        End If
        'Catch ex As Exception
        'ManageException(ex, "UserMasterDAL", "SelectAllUserMaster")
        ' End Try
        Return UserTable

    End Function
    Public Shared Function ConvertStringToByteArray(ByVal StringToConvert) As Byte()
        Return (New System.Text.UnicodeEncoding).GetBytes(StringToConvert)
    End Function

    Public Shared Function SelectUserName(ByVal objUserPPT As UserMasterPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@UserName", objUserPPT.MSUserName)
        ' Parms(1) = New SqlParameter("@UserID", objUserPPT.MSUserID)
        Try
            datatable = objdb.ExecQuery("[General].[UserNameValidate]", Parms).Tables(0)

        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "SelectUserName")
        End Try
        Return datatable

    End Function
    Public Shared Function DeleteUserMaster(ByVal objUserPPT As UserMasterPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intResult As Integer
        Try
            Dim Parms(0) As SqlParameter
            Parms(0) = New SqlParameter("@UserID", objUserPPT.UserID)
            'Parms(1) = New SqlParameter("@UserName", objUserPPT.MSUserName)
            'Parms(2) = New SqlParameter("@DisplayName", objUserPPT.MSDispName)
            'Parms(3) = New SqlParameter("@DesgID", objUserPPT.MSDesgID)
            'Parms(4) = New SqlParameter("@RoleID", objUserPPT.MSRoleID)
            'Parms(5) = New SqlParameter("@Password", objUserPPT.MSPwd)
            
            intResult = objdb.DeleteRecord("[General].[UserMasterDelete]", Parms)

        Catch ex As Exception
            ManageException(ex, "UserMasterDAL", "DeleteUserMaster")
        End Try
        Return intResult
    End Function
    Public Shared Function UpdateUserMaster(ByVal objUserPPT As UserMasterPPT) As UserMasterPPT
        Dim objdb As New SQLHelp
        Try
            Dim pwd As Byte()
            objUserPPT.MSPwd = EncryptionDAL.Encrypt(objUserPPT.MSPwd.Trim())
            pwd = ConvertStringToByteArray(objUserPPT.MSPwd)
            Dim Parms(7) As SqlParameter
            Parms(0) = New SqlParameter("@UserID", objUserPPT.MSUserID)
            Parms(1) = New SqlParameter("@UserName", objUserPPT.MSUserName)
            Parms(2) = New SqlParameter("@DispName", objUserPPT.MSDispName)
            Parms(3) = New SqlParameter("@DesgID", objUserPPT.MSDesgID)
            Parms(4) = New SqlParameter("@RoleID", objUserPPT.MSRoleID)
            Parms(5) = New SqlParameter("@Pwd", pwd)
            Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@ModifiedOn", Date.Today)
            Dim intResult As Integer = objdb.ExecNonQuery("[General].[UserMasterUpdate]", Parms)
        Catch ex As Exception
            ManageException(ex, "UserMasterDal", "UpdateUserMaster")
        End Try
        Return objUserPPT
    End Function

    Public Shared Function ChangePasswordDesgName(ByVal objUserPPT As UserMasterPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@UserID", UserMasterPPT.CPUserID)
        If UserMasterPPT.CPUserID <> Nothing Then
            Try
                datatable = objdb.ExecQuery("[General].[ChangePasswordSelectAll]", Parms).Tables(0)

            Catch ex As Exception
                ManageException(ex, "UserMasterDal", "ChangePasswordSelectAll")
            End Try
        End If
        Return datatable

    End Function

    Public Shared Function UpdateChangePassword(ByVal objUserPPT As UserMasterPPT) As UserMasterPPT
        Dim objdb As New SQLHelp
        Try
            Dim pwd As Byte()
            objUserPPT.MSPwd = EncryptionDAL.Encrypt(objUserPPT.MSPwd)
            pwd = ConvertStringToByteArray(objUserPPT.MSPwd)
            Dim Parms(3) As SqlParameter
            Parms(0) = New SqlParameter("@UserID", UserMasterPPT.CPUserID)
            Parms(1) = New SqlParameter("@Pwd", pwd)
            Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(3) = New SqlParameter("@ModifiedOn", Date.Today)

            Dim intResult As Integer = objdb.ExecNonQuery("[General].[ChangePasswordUpdate]", Parms)
        Catch ex As Exception
            ManageException(ex, "RoleMasterDal", "ChangePasswordUpdate")
        End Try
        Return objUserPPT
    End Function
End Class
