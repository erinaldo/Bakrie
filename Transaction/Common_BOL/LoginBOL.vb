Imports Common_DAL
Imports Common_PPT
Public Class LoginBOL
    Public Function LoginUser(ByVal objUser As UserMasterPPT) As UserMasterPPT
        Dim objLoginDAL As New LoginDAL
        Return objLoginDAL.getLogin(objUser)
    End Function
    Public Function FiscalYearDate(ByVal objUser As UserMasterPPT) As DataTable
        Dim objLoginDAL As New LoginDAL
        Return objLoginDAL.FiscalYearDate(objUser)
    End Function

    ' For Privilege
    Public Function UserLogin(ByVal objRolePrivilegePPT As Common_PPT.RolePrivilegePPT) As DataSet
        Dim objLoginDAL As New LoginDAL
        Return objLoginDAL.UserLogin(objRolePrivilegePPT)
    End Function
    'For Fiscalyear Login
    Public Function FiscalYearAllRecordsIsExist(ByVal objFyear As Common_PPT.EstatePPT) As DataSet
        Dim objLoginDAL As New LoginDAL
        Return objLoginDAL.FiscalYearAllRecordsIsExist(objFyear)
    End Function

    ' Get Db version
    Public Function GetDbVersion() As DataSet
        Dim objLoginDAL As New LoginDAL
        Return objLoginDAL.GetDbVersion()
    End Function
End Class
