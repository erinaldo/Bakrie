Imports Common_PPT
Imports Common_DAL

Public Class EstateBOL

    Public Function saveEstateMaster(ByVal objEstatePPT As EstatePPT) As Boolean
        Dim objEstateDAL As New EstateDAL
        Return objEstateDAL.saveEstateMaster(objEstatePPT)
    End Function
    Public Function getEstatemaster() As EstatePPT()
        Dim objEstateDAL As New EstateDAL
        Return objEstateDAL.getEstateMaster()
    End Function
    Public Function getEstateID() As DataSet
        Dim objEstateDAL As New EstateDAL
        Return objEstateDAL.getEstateID()
    End Function

    Public Function updateEstateMaster(ByVal objEstatePPT As EstatePPT) As Integer
        Dim intUpdateResult As Integer
        Dim objEstateCodeDAL As New EstateDAL
        intUpdateResult = objEstateCodeDAL.updateEstateMaster(objEstatePPT)
        Return intUpdateResult
    End Function

    Public Function getConcurrencyID(ByVal objEstatePPT As EstatePPT) As Integer
        Dim objEstateCodeDAL As New EstateDAL
        'Return objEstateCodeDAL.getConcurrencyID(objEstatePPT)
        Dim intCheckConcurrency As Integer
        intCheckConcurrency = objEstateCodeDAL.getConcurrencyID(objEstatePPT)
        Return intCheckConcurrency
    End Function
    Public Function deleteEstateMaster(ByVal objEstatePPT As EstatePPT) As Boolean
        Dim objEstateDAL As New EstateDAL
        Return objEstateDAL.deleteEstateMaster(objEstatePPT)
    End Function
    Public Function GetActiveYears(ByVal psEstateID As String, ByVal psEstateCode As String, ByVal piAyear As Integer, ByVal piAmonth As Integer, ByVal psCreatedBy As String, ByVal psModifiedBy As String) As DataTable
        Dim dtblYears As New DataTable
        Dim objEstateCodeDAL As New EstateDAL
        dtblYears = objEstateCodeDAL.GetActiveYears(psEstateID, psEstateCode, piAyear, piAmonth, psCreatedBy, psModifiedBy)

        Return dtblYears

    End Function
    Public Function GetYears(ByVal psEstateID As String, ByVal psEstateCode As String, ByVal piAyear As Integer, ByVal piAmonth As Integer, ByVal psCreatedBy As String) As DataTable
        Dim dtblYears As New DataTable
        Dim objEstateCodeDAL As New EstateDAL
        dtblYears = objEstateCodeDAL.GetYears(psEstateID, psEstateCode, piAyear, piAmonth, psCreatedBy)

        Return dtblYears

    End Function
    Public Function GetActiveYearMonth(ByVal psEstateID As String, ByVal ModID As Integer) As DataSet
        Dim objEstateCodeDAL As New EstateDAL
        Return objEstateCodeDAL.GetActiveYearMonth(psEstateID, ModID)

    End Function

    Public Function GetLoginActiveMonthYearID(ByVal psEstateID As String, ByVal ModID As Integer, ByVal aiYear As Integer, _
                                                ByVal aiMonth As Integer) As DataSet
        Dim objEstateCodeDAL As New EstateDAL
        Return objEstateCodeDAL.GetLoginActiveMonthYearID(psEstateID, ModID, aiYear, aiMonth)

    End Function

    Public Function getEstateCode(ByVal psEstateCode As String) As EstatePPT()
        Dim objEstateCodeDAL As New EstateDAL
        Return objEstateCodeDAL.getEstateCode(psEstateCode)
    End Function

    Public Function getEstateName(ByVal psEstateName As String) As EstatePPT()
        Dim objEstateCodeDAL As New EstateDAL
        Return objEstateCodeDAL.getEstateName(psEstateName)
    End Function
    Public Function checkExistEstate(ByVal objEstatePPT As EstatePPT) As Boolean
        Dim objEstateDAL As New EstateDAL
        Return objEstateDAL.checkExistEstate(objEstatePPT)
    End Function
    Public Function checkExistEstateupdate(ByVal objEstatePPT As EstatePPT) As Boolean
        Dim objEstateDAL As New EstateDAL
        Return objEstateDAL.checkExistEstateupdate(objEstatePPT)
    End Function
End Class
