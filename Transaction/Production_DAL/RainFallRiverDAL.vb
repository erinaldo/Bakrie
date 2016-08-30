Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class RainFallRiverDAL
    Public Shared Function saveRainFallRiverDetails(ByVal objRFRPPT As RainFallRiverPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@RDate", objRFRPPT.RDate)
        Parms(4) = New SqlParameter("@RTime", objRFRPPT.RTime)
        Parms(5) = New SqlParameter("@Rain", objRFRPPT.Rain)
        Parms(6) = New SqlParameter("@RiverLevel", objRFRPPT.RiverLevel)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Return objdb.ExecQuery("[Production].[RainFallRiverDetailsInsert]", Parms)
    End Function
    Public Function GetRainFallDetails(ByVal objRFRPPT As RainFallRiverPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@RDate", IIf(objRFRPPT.RDate <> Nothing, objRFRPPT.RDate, DBNull.Value))
        ' params(1) = New SqlParameter("@ProdStockID", IIf(objCPOPPT.ProdStockID <> "", objCPOPPT.ProdStockID, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Production].[RainFallRiverSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_RainFallDetail(ByVal objRFRPPT As RainFallRiverPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@RainRiverId", objRFRPPT.RainRiverId)

        rowsAffected = objdb.ExecNonQuery("[Production].[RainFallDetailDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Shared Function UpdateRainFallRiverDetails(ByVal objRFRPPT As RainFallRiverPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@RainRiverID", IIf(objRFRPPT.RainRiverId <> String.Empty, objRFRPPT.RainRiverId, DBNull.Value))
        Parms(3) = New SqlParameter("@RDate", objRFRPPT.RDate)
        Parms(4) = New SqlParameter("@RTime", objRFRPPT.RTime)
        Parms(5) = New SqlParameter("@Rain", objRFRPPT.Rain)
        Parms(6) = New SqlParameter("@RiverLevel", objRFRPPT.RiverLevel)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())

        Return objdb.ExecQuery("[Production].[RainFallRiverDetailsUpdate]", Parms)
    End Function
    Public Function DuplicateDateCheck(ByVal objRFRPPT As RainFallRiverPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ProductID", objCPOPPT.ProductID)
        Parms(1) = New SqlParameter("@RDate", objRFRPPT.RDate)
        objExists = objdb.ExecuteScalar("[Production].[RainFallDateIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateTimeCheck(ByVal objRFRPPT As RainFallRiverPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ProductID", objCPOPPT.ProductID)
        Parms(1) = New SqlParameter("@RTime", objRFRPPT.RTime)
        objExists = objdb.ExecuteScalar("[Production].[RainFallTimeIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

End Class
