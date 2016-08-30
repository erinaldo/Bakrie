Imports CheckRoll_PPT
Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT

Public Class CropStatement_DAL
    Public Shared Function GetCropYieldID(ByVal objCropStatementPPT As CropStatement_PPT) As DataTable
        Dim dt As New DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CropYield", objCropStatementPPT._CropYieldCode)

        dt = objSQLHelp.ExecQuery("[Checkroll].[GetCropYieldID]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function CropStatementInsert(ByVal objCropStatementPPT As CropStatement_PPT) As Integer
        Dim int As Integer = 0
        Dim objSQLHelp As New SQLHelp
        Dim parms(12) As SqlParameter
        parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        parms(2) = New SqlParameter("@CropYieldID", objCropStatementPPT._CropYieldID)
        parms(3) = New SqlParameter("@DivID", objCropStatementPPT._DivID)
        parms(4) = New SqlParameter("@YOPID", objCropStatementPPT._YOPID)
        parms(5) = New SqlParameter("@BlockID", objCropStatementPPT._BlockID)
        parms(6) = New SqlParameter("@MilWeight", objCropStatementPPT._MilWeight)
        parms(7) = New SqlParameter("@Bunches", objCropStatementPPT._Bunches)
        parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        parms(12) = New SqlParameter("@DDate", objCropStatementPPT._DDate)

        int = objSQLHelp.ExecuteScalar("[Checkroll].[CropStatementInsert]", parms)

        Return int

    End Function
    Public Shared Function CropStatementUpdate(ByVal objCropStatementPPT As CropStatement_PPT) As Integer
        Dim int As Integer = 0
        Dim objSQLHelp As New SQLHelp
        Dim parms(10) As SqlParameter
        parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(1) = New SqlParameter("@CropStatementID", objCropStatementPPT._CropStatementID)
        parms(2) = New SqlParameter("@CropYieldID", objCropStatementPPT._CropYieldID)
        parms(3) = New SqlParameter("@DivID", objCropStatementPPT._DivID)
        parms(4) = New SqlParameter("@YOPID", objCropStatementPPT._YOPID)
        parms(5) = New SqlParameter("@BlockID", objCropStatementPPT._BlockID)
        parms(6) = New SqlParameter("@MilWeight", objCropStatementPPT._MilWeight)
        parms(7) = New SqlParameter("@Bunches", objCropStatementPPT._Bunches)
        parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        parms(10) = New SqlParameter("@DDate", objCropStatementPPT._DDate)
        int = objSQLHelp.ExecuteScalar("[Checkroll].[CropStatementUpdate]", parms)

        Return int

    End Function
    Public Shared Function CropStatementDelete(ByVal objCropStatementPPT As CropStatement_PPT) As Integer
        Dim int As Integer = 0
        Dim objSQLHelp As New SQLHelp
        Dim parms(1) As SqlParameter
        parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(1) = New SqlParameter("@CropStatementID", objCropStatementPPT._CropStatementID)

        int = objSQLHelp.ExecuteScalar("[Checkroll].[CropStatementDelete]", parms)

        Return int

    End Function

    Public Shared Function CropStatementSearch(ByVal objCropStatementPPT As CropStatement_PPT) As DataTable

        Dim dt As New DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        If objCropStatementPPT._BlockID <> String.Empty Then
            Parms(1) = New SqlParameter("@BlockID", objCropStatementPPT._BlockID)
        Else
            Parms(1) = New SqlParameter("@BlockID", System.DBNull.Value)
        End If
        If objCropStatementPPT._CropYieldID <> String.Empty Then
            Parms(2) = New SqlParameter("@CropYieldID", objCropStatementPPT._CropYieldID)
        Else
            Parms(2) = New SqlParameter("@CropYieldID", System.DBNull.Value)
        End If

        dt = objSQLHelp.ExecQuery("[Checkroll].[CropStatementSearch]", Parms).Tables(0)
        Return dt

    End Function

End Class
