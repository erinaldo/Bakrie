Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class SearchCodeDAL
    'Database used: BSP
    'Table used: [Vehicle].[VehicleWorkshopMaster]
    'Naming conventions used for keywords: l-local;p-public;s-string;d-double;i-integer;date-prefix:d,sufix:DT;dr-SqlDataReader;
    'Naming conventions used for variables: Pascal Case;Example: GetWindow
    'Naming conventions used for methods/functions: Prefix with access modifier and return type:l-local;p-public;s-string;d-double;i-integer;date-prefix:d,sufix:DT;
    'Followed by function/method name: Pascal Case;Example: psGetWindow()

#Region "Public Select Methods"

    Shared objdb As New SQLHelp

    Public Shared Function GetSearchWorkshop(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))
        Parms(1) = New SqlParameter("@VHWSCode", GetDataValue(_SearchCodePPT.psVHID))
        Parms(2) = New SqlParameter("@VHModel", GetDataValue(_SearchCodePPT.psModel))
        Parms(3) = New SqlParameter("@Category", GetDataValue(_SearchCodePPT.psCategory))

        Return objdb.ExecQuery("[Vehicle].WorkshopCodeSearchGET", Parms).Tables(0)
    End Function

    'Public Shared Function GetSearchVehicle(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

    '    Dim Parms(2) As SqlParameter
    '    Dim objdb As New SQLHelp

    '    Parms(0) = New SqlParameter("@SearchBy", GetDataValue(_SearchCodePPT.psSearchBy))
    '    Parms(1) = New SqlParameter("@Code", GetDataValue(_SearchCodePPT.psSearchTerm))
    '    Parms(2) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))
    '    'Parms(3) = New SqlParameter("@LoggedInYear", GetDataValue(_SearchCodePPT.pdLoggedInYear))

    '    Return objdb.ExecQuery("[Vehicle].[VehicleCodeSearchGET]", Parms).Tables(0)
    'End Function


    Public Shared Function GetSearchVehicle(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))
        Parms(1) = New SqlParameter("@VHWSCode", GetDataValue(_SearchCodePPT.psVHID))
        Parms(2) = New SqlParameter("@VHModel", GetDataValue(_SearchCodePPT.psModel))
        Parms(3) = New SqlParameter("@Category", GetDataValue(_SearchCodePPT.psCategory))
        Parms(4) = New SqlParameter("@Year", GetDataValue(_SearchCodePPT.pdLoggedInYear))

        Return objdb.ExecQuery("[Vehicle].[VehicleCodeSearchGET]", Parms).Tables(0)
    End Function

    Public Shared Function GetSearchWSVehicle(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))
        Parms(1) = New SqlParameter("@VHWSCode", GetDataValue(_SearchCodePPT.psVHID))
        Parms(2) = New SqlParameter("@VHModel", GetDataValue(_SearchCodePPT.psModel))
        Parms(3) = New SqlParameter("@Category", GetDataValue(_SearchCodePPT.psCategory))
        Parms(4) = New SqlParameter("@Year", GetDataValue(_SearchCodePPT.pdLoggedInYear))

        Return objdb.ExecQuery("[Vehicle].[WSVehicleCodeSearchGET]", Parms).Tables(0)
    End Function

    Public Shared Function GetSearchTAnalysis(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@SearchFor", GetDataValue(_SearchCodePPT.psSearchFor))
        Parms(1) = New SqlParameter("@SearchBy", GetDataValue(_SearchCodePPT.psSearchBy))
        Parms(2) = New SqlParameter("@SearchTerm", GetDataValue(_SearchCodePPT.psSearchTerm))
        Parms(3) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))

        Return objdb.ExecQuery("[Vehicle].TAnalysisCodeSearchGET", Parms).Tables(0)
    End Function

    Public Shared Function GetSearchAccount(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@SearchBy", GetDataValue(_SearchCodePPT.psSearchBy))
        Parms(1) = New SqlParameter("@SearchTerm", GetDataValue(_SearchCodePPT.psSearchTerm))
        Parms(2) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))

        Return objdb.ExecQuery("[Vehicle].[AccountCodeSearchGET]", Parms).Tables(0)
    End Function

    Public Shared Function GetSearchOperator(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(2) As SqlParameter

        'Parms(0) = New SqlParameter("@SearchBy", GetDataValue(_SearchCodePPT.psSearchBy))
        'Parms(1) = New SqlParameter("@SearchTerm", GetDataValue(_SearchCodePPT.psSearchTerm))
        Parms(0) = New SqlParameter("@EmpCode", GetDataValue(_SearchCodePPT.psEmpCode))
        Parms(1) = New SqlParameter("@EmpName", GetDataValue(_SearchCodePPT.psEmpName))
        Parms(2) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))

        Return objdb.ExecQuery("[Vehicle].[OperatorCodeSearchGET]", Parms).Tables(0)
    End Function

    Public Shared Function GetDivision(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@DivCode", GetDataValue(_SearchCodePPT.psDIVCode))
        Parms(1) = New SqlParameter("@DivName", GetDataValue(_SearchCodePPT.psDIVName))
        Parms(2) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))

        Return objdb.ExecQuery("[Vehicle].[DivisionGET]", Parms).Tables(0)

    End Function

    Public Shared Function GetSubBlock(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@DIVCode", GetDataValue(_SearchCodePPT.psDIVCode))
        Parms(1) = New SqlParameter("@YOPCode", GetDataValue(_SearchCodePPT.psYOPCode))
        Parms(2) = New SqlParameter("@SubBlockCode", GetDataValue(_SearchCodePPT.psSubBlockCode))
        Parms(3) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))
        Parms(4) = New SqlParameter("@SearchTerm", GetDataValue(_SearchCodePPT.psSearchTerm))

        Return objdb.ExecQuery("[Vehicle].[SubBlockGET]", Parms).Tables(0)
    End Function

    Public Shared Function GetYearOfPlanning(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@DIVCode", GetDataValue(_SearchCodePPT.psDIVCode))
        Parms(1) = New SqlParameter("@YOPCode", GetDataValue(_SearchCodePPT.psYOPCode))
        Parms(2) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))

        Return objdb.ExecQuery("[Vehicle].[YearOfPlanningGET]", Parms).Tables(0)

    End Function

    Public Shared Function GetContractNo(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@ContactNoOrName", GetDataValue(_SearchCodePPT.psContactNoOrName))
        Parms(1) = New SqlParameter("@SearchBy", GetDataValue(_SearchCodePPT.psSearchBy))
        Parms(2) = New SqlParameter("@EstateID", GetDataValue(_SearchCodePPT.psEstateID))

        Return objdb.ExecQuery("[Vehicle].[ContractNoGET]", Parms).Tables(0)

    End Function


    Public Shared Function VHNCategoryGet(ByVal _SearchCodePPT As SearchCodePPT) As DataTable

        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@Type", GetDataValue(_SearchCodePPT.pcType))

        Return objdb.ExecQuery("[Vehicle].[VehicleCategorySelect]", Parms).Tables(0)

    End Function

    Public Shared Function GetDataValue(ByVal o As Object) As Object
        If o Is Nothing OrElse [String].Empty.Equals(o) Then
            Return DBNull.Value
        Else
            Return o
        End If
    End Function

#End Region

End Class
