Imports System.Data.SqlClient
Imports Common_PPT

Public Class LoginDAL

    Public Function getLogin(ByVal objUser As UserMasterPPT) As UserMasterPPT
        Dim objdb As New SQLHelp
        objUser.TmpPass = EncryptionDAL.Encrypt(objUser.TmpPass)
        objUser.Pass = ConvertStringToByteArray(objUser.TmpPass)
        'Dim objEnc As New EncryptDAL
        'objUser.Pass = objEnc.Encrypt(objUser.TmpPass)
        ''Dim sqlcon As New SqlConnection
        'Dim sqlcmd As New SqlCommand
        'sqlcon = New SqlConnection("Data Source=RAJALT\MSSQL2008;Initial Catalog=Temp;Persist Security Info=False;User ID=sa;Password=sql2008")
        'sqlcmd = New SqlCommand("INSERT INTO temp(pass) VALUES (@binaryValue)", sqlcon)
        'sqlcmd.Parameters.Add("@binaryValue", SqlDbType.VarBinary, 8000).Value = objUser.Pass
        'sqlcon.Open()
        'sqlcmd.ExecuteNonQuery()
        'sqlcon.Close()
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@UName", objUser.UserName)
        Parms(1) = New SqlParameter("@Pass", objUser.Pass)
        ds = objdb.ExecQuery("UserMasterGETLogin", Parms)
        Dim clsUser As UserMasterPPT = New UserMasterPPT
        Dim intcount As Integer = ds.Tables(0).Rows.Count
        For Each dr As DataRow In ds.Tables(0).Rows
            clsUser.UserID = IIf(IsDBNull(dr("UserID")), "", dr("UserID"))
            clsUser.UserName = IIf(IsDBNull(dr("UserName")), "", dr("UserName"))
            clsUser.DesgID = IIf(IsDBNull(dr("DesgID")), "", dr("DesgID"))
            clsUser.Desg = IIf(IsDBNull(dr("Desg")), "", dr("Desg"))
            clsUser.DLevel = IIf(IsDBNull(dr("DLevel")), 0, dr("DLevel"))
            clsUser.DispName = IIf(IsDBNull(dr("DispName")), "", dr("DispName"))
            UserMasterPPT.RoleID = IIf(IsDBNull(dr("RoleID")), "", dr("RoleID"))
        Next
        Return clsUser
    End Function

    Public Function FiscalYearDate(ByVal objUser As UserMasterPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@FMonth", objUser.FiscalMonth)
        Parms(1) = New SqlParameter("@Fyear", objUser.FiscalYear)
        dt = objdb.ExecQuery("[FiscalMonYrGET]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function ConvertStringToByteArray(ByVal StringToConvert) As Byte()
        Return (New System.Text.UnicodeEncoding).GetBytes(StringToConvert)
    End Function

    ' For Privilege
    Public Function UserLogin(ByVal objRolePrivilegePPT As Common_PPT.RolePrivilegePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@MenuID", objRolePrivilegePPT.MID)
        Parms(1) = New SqlParameter("@RoleID", objRolePrivilegePPT.RID)
        ds = objdb.ExecQuery("[dbo].[SelectRoleTable]", Parms)
        Return ds
    End Function

    'For Fiscal Year Login
    Public Function FiscalYearAllRecordsIsExist(ByVal objFyear As Common_PPT.EstatePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@Fyear", objFyear.Ayear)
        ds = objdb.ExecQuery("[General].[FiscalYearAllRecordsIsExist]", Parms)
        'dt = objdb.ExecQuery("[FiscalYearAllRecordsIsExist]", Parms).Tables(0)
        Return ds
    End Function

    'Retrieves Db version from database
    Public Function GetDbVersion() As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        ds = objdb.ExecQuery("General.GetDbVersion")
        'dt = objdb.ExecQuery("[FiscalYearAllRecordsIsExist]", Parms).Tables(0)
        Return ds
    End Function
End Class
