Imports Common_PPT
'Imports BSP
Imports System.Data.SqlClient

Public Class EstateDAL
    Public a As Byte()
    Public Function saveEstateMaster(ByVal objEstate As EstatePPT) As Boolean
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", objEstate.EstateID)
        Parms(1) = New SqlParameter("@EstateCode", objEstate.EstateCode)
        Parms(2) = New SqlParameter("@EstateName", objEstate.EstateName)
        Parms(3) = New SqlParameter("@Address", objEstate.Address)
        Parms(4) = New SqlParameter("@TelephoneNumber", objEstate.TelephoneNumber)
        Parms(5) = New SqlParameter("@Type", objEstate.Type)
        Parms(6) = New SqlParameter("@ConcurrencyID", objEstate.ConcurrencyID)
        Parms(7) = New SqlParameter("@TotalArea", objEstate.TotalArea)
        Parms(8) = New SqlParameter("@PlantedArea", objEstate.PlantedArea)
        Parms(9) = New SqlParameter("@Descp", objEstate.Descp)
        Parms(10) = New SqlParameter("@CreatedBy", objEstate.CreatedBy)
        Parms(11) = New SqlParameter("@CreatedOn", objEstate.CreatedOn)
        Parms(12) = New SqlParameter("@ModifiedBy", objEstate.ModifiedBy)
        Parms(13) = New SqlParameter("@ModifiedOn", objEstate.ModifiedOn)

        rowsAffected = objdb.ExecNonQuery("EstateINSERT", Parms)
        If rowsAffected = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getEstateMaster() As EstatePPT()

        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        ds = objdb.ExecQuery("[General].[EstateGet]")

        Dim arr As New ArrayList

        For Each dr As DataRow In ds.Tables(0).Rows

            Dim clsEstate As EstatePPT = New EstatePPT
            clsEstate.EstateID = IIf(IsDBNull(dr("EstateID")), "", dr("EstateID"))
            clsEstate.EstateCode = IIf(IsDBNull(dr("EstateCode")), "", dr("EstateCode"))
            clsEstate.EstateIDCode = IIf(IsDBNull(dr("EstateIDCode")), "", dr("EstateIDCode"))
            clsEstate.EstateName = IIf(IsDBNull(dr("EstateName")), "", dr("EstateName"))
            clsEstate.Address = IIf(IsDBNull(dr("Add1")), "", dr("Add1"))
            clsEstate.Type = IIf(IsDBNull(dr("Type")), "", dr("Type"))
            clsEstate.ConcurrencyID = IIf(IsDBNull(dr("ConcurrencyID")), 0, dr("ConcurrencyID"))
            clsEstate.EstatecodeName = IIf(IsDBNull(dr("EstatecodeName")), 0, dr("EstatecodeName"))
            If ds.Tables(0).Columns.Contains("Abbrevation") Then
                clsEstate.EstateAbbreviation = IIf(IsDBNull(dr("Abbrevation")), "", dr("Abbrevation"))
            End If
            arr.Add(clsEstate)

        Next

        Return CType(arr.ToArray(GetType(EstatePPT)), EstatePPT())

    End Function
   
    Public Function getEstateID() As DataSet

        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        ds = objdb.ExecQuery("EstateGET")
        Return ds

    End Function

    Public Function getConcurrencyID(ByVal objEstate As EstatePPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim intCheckConcurrency As Integer

        Parms(0) = New SqlParameter("@EstateID", objEstate.EstateID)
        Parms(1) = New SqlParameter("@ConcurrencyID", objEstate.ConcurrencyID)

        intCheckConcurrency = objdb.ExecNonQuery("EstateConcurrencyIDGET", Parms)
        Return intCheckConcurrency

    End Function
    Public Function updateEstateMaster(ByVal objEstate As EstatePPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(8) As SqlParameter
        Dim intUpdateResult As Integer

        Parms(0) = New SqlParameter("@EstateID", objEstate.EstateID)
        Parms(1) = New SqlParameter("@EstateCode", objEstate.EstateCode)
        Parms(2) = New SqlParameter("@EstateName", objEstate.EstateName)
        Parms(3) = New SqlParameter("@Descp", objEstate.Descp)
        Parms(4) = New SqlParameter("@Address", objEstate.Address)
        Parms(5) = New SqlParameter("@TelephoneNumber", objEstate.TelephoneNumber)
        Parms(6) = New SqlParameter("@TotalArea", objEstate.TotalArea)
        Parms(7) = New SqlParameter("@PlantedArea", objEstate.PlantedArea)
        Parms(8) = New SqlParameter("@Type", objEstate.Type)
        'Parms(9) = New SqlParameter("@ConcurrencyID", objEstate.ConcurrencyID)

        intUpdateResult = objdb.ExecNonQuery("EstateUPDATE", Parms)
        Return intUpdateResult

    End Function
    Public Function deleteEstateMaster(ByVal objEstate As EstatePPT) As Boolean
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Dim rowsAffected As Integer = 0
        Parms(0) = New SqlParameter("@EstateID", objEstate.EstateID)

        rowsAffected = objdb.ExecNonQuery("EstateDELETE", Parms)
        If rowsAffected > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function getEstateCode(ByVal psEstateCode As String) As EstatePPT()
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim objEstate As EstatePPT() = Nothing
        Dim Parms(0) As SqlParameter
        Dim arr As New ArrayList
        Parms(0) = New SqlParameter("@EstateCode", psEstateCode)
        ds = objdb.ExecQuery("EstateByEstateCodeGET", Parms)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim clsEstate As EstatePPT = New EstatePPT
            clsEstate.EstateID = IIf(IsDBNull(dr("EstateID")), 0, dr("EstateID"))
            clsEstate.EstateCode = IIf(IsDBNull(dr("EstateCode")), 0, dr("EstateCode"))
            clsEstate.EstateName = IIf(IsDBNull(dr("EstateName")), "", dr("EstateName"))
            clsEstate.Address = IIf(IsDBNull(dr("Address")), "", dr("Address"))
            clsEstate.TelephoneNumber = IIf(IsDBNull(dr("TelephoneNumber")), "", dr("TelephoneNumber"))
            clsEstate.TotalArea = IIf(IsDBNull(dr("TotalArea")), "", dr("TotalArea"))
            clsEstate.PlantedArea = IIf(IsDBNull(dr("PlantedArea")), 0, dr("PlantedArea"))

            'objEstate = clsEstate
            arr.Add(clsEstate)
        Next
        Return CType(arr.ToArray(GetType(EstatePPT)), EstatePPT())

        'Next
        'Return objEstate
    End Function
    Public Function GetYears(ByVal psEstateID As String, ByVal psEstateCode As String, ByVal piAyear As Integer, ByVal piAmonth As Integer, ByVal psCreatedBy As String) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", psEstateID)
        Parms(1) = New SqlParameter("@EstateCode", psEstateCode)
        Parms(2) = New SqlParameter("@AYear", piAyear)
        Parms(3) = New SqlParameter("@AMonth", piAmonth)
        Parms(4) = New SqlParameter("@CreatedBy", psCreatedBy)
        Parms(5) = New SqlParameter("@ModifiedBy", psCreatedBy)
        ds = objdb.ExecQuery("[General].[YearsGET]", Parms)

        Return ds.Tables(0)

    End Function
    Public Function GetActiveYears(ByVal psEstateID As String, ByVal psEstateCode As String, ByVal piAyear As Integer, ByVal piAmonth As Integer, ByVal psCreatedBy As String, ByVal psModifiedBy As String) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", psEstateID)
        Parms(1) = New SqlParameter("@EstateCode", psEstateCode)
        Parms(2) = New SqlParameter("@AYear", piAyear)
        Parms(3) = New SqlParameter("@AMonth", piAmonth)
        Parms(4) = New SqlParameter("@CreatedBy", psCreatedBy)
        Parms(5) = New SqlParameter("@ModifiedBy", psCreatedBy)
        'Changed the below SP from SADC bcz both have same Query
        'ds = objdb.ExecQuery("ActiveYearsGET", Parms)
        ds = objdb.ExecQuery("[General].[YearsGET]", Parms)
        Return ds.Tables(0)

    End Function
    Public Function GetActiveYearMonth(ByVal psEstateID As String, ByVal ModID As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        'Dim objEstate As EstatePPT() = Nothing
        Dim Parms(1) As SqlParameter
        Dim arr As New ArrayList
        Parms(0) = New SqlParameter("@EstateID", psEstateID)
        Parms(1) = New SqlParameter("@ModID", ModID)
        ds = objdb.ExecQuery("[General].[ActiveYearMonthGET]", Parms)
        Return ds
    End Function

    Public Function GetLoginActiveMonthYearID(ByVal psEstateID As String, ByVal ModID As Integer, ByVal aiYear As Integer, _
                                              ByVal aiMonth As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        'Dim objEstate As EstatePPT() = Nothing
        Dim Parms(3) As SqlParameter
        Dim arr As New ArrayList
        Parms(0) = New SqlParameter("@EstateID", psEstateID)
        Parms(1) = New SqlParameter("@ModID", ModID)
        Parms(2) = New SqlParameter("@AYear", aiYear)
        Parms(3) = New SqlParameter("@AMonth", aiMonth)
        ds = objdb.ExecQuery("[General].[ActiveMonthYearIDGET]", Parms)
        Return ds
    End Function


    
    Public Function getEstateName(ByVal psEstateName As String) As EstatePPT()
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        'Dim objEstate As EstatePPT() = Nothing
        Dim Parms(0) As SqlParameter
        Dim arr As New ArrayList
        Parms(0) = New SqlParameter("@EstateName", psEstateName)
        ds = objdb.ExecQuery("EstateByEstateNameGET", Parms)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim clsEstate As EstatePPT = New EstatePPT
            'lsEstate.EstateID = IIf(IsDBNull(dr("EstateID")), 0, dr("EstateID"))
            clsEstate.EstateCode = IIf(IsDBNull(dr("EstateCode")), 0, dr("EstateCode"))
            clsEstate.EstateName = IIf(IsDBNull(dr("EstateName")), "", dr("EstateName"))
            clsEstate.Address = IIf(IsDBNull(dr("Address")), "", dr("Address"))
            clsEstate.TelephoneNumber = IIf(IsDBNull(dr("TelephoneNumber")), "", dr("TelephoneNumber"))
            clsEstate.TotalArea = IIf(IsDBNull(dr("TotalArea")), "", dr("TotalArea"))
            clsEstate.PlantedArea = IIf(IsDBNull(dr("PlantedArea")), 0, dr("PlantedArea"))

            'objEstate = clsEstate
            arr.Add(clsEstate)
        Next
        Return CType(arr.ToArray(GetType(EstatePPT)), EstatePPT())

        'Next
        'Return objEstate
    End Function
    Public Function checkExistEstate(ByVal objEstate As EstatePPT) As Boolean
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Dim existVal As Boolean = False
        Parms(0) = New SqlParameter("@EstateCode", objEstate.EstateCode)
        Parms(1) = New SqlParameter("@EstateName", objEstate.EstateName)
        ds = objdb.ExecQuery("EstateEXIST", Parms)
        For Each dr As DataRow In ds.Tables(0).Rows
            existVal = True
        Next
        Return existVal
    End Function
    Public Function checkExistEstateupdate(ByVal objEstate As EstatePPT) As Boolean
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Dim existVal As Boolean = False
        Parms(0) = New SqlParameter("@EstateID", objEstate.EstateID)
        Parms(1) = New SqlParameter("@EstateCode", objEstate.EstateCode)
        Parms(2) = New SqlParameter("@EstateName", objEstate.EstateName)
        ds = objdb.ExecQuery("EstateEXISTUPDATE", Parms)
        For Each dr As DataRow In ds.Tables(0).Rows
            existVal = True
        Next
        Return existVal
    End Function
    
End Class
