Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class ConsignmentReceivedDAL

    Public Function ConsignmentSave(ByVal objConsignmentSave As ConsignmentReceivedPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Dim datetime As Date = System.DateTime.Today

        Parms(0) = New SqlParameter("@StConsignmentID", objConsignmentSave.StConsignmentID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ReceivedDate", objConsignmentSave.ReceivedDate)
        Parms(4) = New SqlParameter("@ReferenceNo", objConsignmentSave.ReferenceNo)
        Parms(5) = New SqlParameter("@STConsignmentMasterID", objConsignmentSave.STConsignmentMasterID)
        Parms(6) = New SqlParameter("@ReceivedQty", objConsignmentSave.ReceivedQty)
        Parms(7) = New SqlParameter("@Remarks", objConsignmentSave.Remarks)
        Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", datetime)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", datetime)
        Parms(13) = New SqlParameter("@Status", objConsignmentSave.Status)
        If objConsignmentSave.RejectedReason <> String.Empty Then
            Parms(14) = New SqlParameter("@RejectedReason", objConsignmentSave.RejectedReason)
        Else
            Parms(14) = New SqlParameter("@RejectedReason", DBNull.Value)
        End If

        ds = objdb.ExecQuery("[Store].[StConsignmentInsert]", Parms)

        Return ds
    End Function



    Public Function ConsignmentUpdate(ByVal objConsignmentUpdate As ConsignmentReceivedPPT, ByVal IsStatusFromApproval As String) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Dim datetime As Date = System.DateTime.Today

        Parms(0) = New SqlParameter("@StConsignmentID", objConsignmentUpdate.StConsignmentID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ReceivedDate", objConsignmentUpdate.ReceivedDate)
        Parms(4) = New SqlParameter("@ReferenceNo", objConsignmentUpdate.ReferenceNo)
        Parms(5) = New SqlParameter("@STConsignmentMasterID", objConsignmentUpdate.STConsignmentMasterID)
        Parms(6) = New SqlParameter("@ReceivedQty", objConsignmentUpdate.ReceivedQty)
        Parms(7) = New SqlParameter("@Remarks", objConsignmentUpdate.Remarks)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", datetime)
        Parms(10) = New SqlParameter("@Status", objConsignmentUpdate.Status)
        If objConsignmentUpdate.RejectedReason <> String.Empty Then
            Parms(11) = New SqlParameter("@RejectedReason", objConsignmentUpdate.RejectedReason)
        Else
            Parms(11) = New SqlParameter("@RejectedReason", DBNull.Value)
        End If
        Parms(12) = New SqlParameter("@IsStatusFromApproval", IsStatusFromApproval)

        ds = objdb.ExecQuery("[Store].[StConsignmentUpdate]", Parms)

        Return ds

    End Function



    Public Function ConsignmentDelete(ByVal objConsignmentDelete As ConsignmentReceivedPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@StConsignmentID", objConsignmentDelete.StConsignmentID)
        ds = objdb.ExecQuery("[Store].[StConsignmentDelete]", Parms)
        Return ds
    End Function

    Public Function ConsignmentStockCodeGet(ByVal ObjConsignmentStockCodeGet As ConsignmentReceivedPPT, ByVal IsDirect As String) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@STConsignmentMasterID", ObjConsignmentStockCodeGet.STConsignmentMasterID)
        Parms(1) = New SqlParameter("@STCode", ObjConsignmentStockCodeGet.STCode)
        Parms(2) = New SqlParameter("@STDesc", ObjConsignmentStockCodeGet.STDesc)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(5) = New SqlParameter("@IsDirect", IsDirect)

        ds = objdb.ExecQuery("[Store].[STRCRStockDetailsGet]", Parms)
        Return ds

    End Function

    Public Function GetConsignmentReceivedDetails(ByVal ConsignmentReceived As ConsignmentReceivedPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        If ConsignmentReceived.blReceivedDate = True Then
            params(0) = New SqlParameter("@ReceivedDate", ConsignmentReceived.ReceivedDate)
        Else
            params(0) = New SqlParameter("@ReceivedDate", DBNull.Value)
        End If
        'params(0) = New SqlParameter("@ReceivedDate", ConsignmentReceived.ReceivedDate)
        params(1) = New SqlParameter("@ReferenceNo", ConsignmentReceived.ReferenceNo)
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@STCode", ConsignmentReceived.STCode)
        params(5) = New SqlParameter("@Status", ConsignmentReceived.Status)

        dt = objdb.ExecQuery("[Store].[ConsignmentReceivedSearch]", params).Tables(0)
        Return dt

    End Function

    Public Function ReferenceNoIsExist(ByVal ObjRefNoisexist As ConsignmentReceivedPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@ReferenceNo", ObjRefNoisexist.ReferenceNo)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If ObjRefNoisexist.StConsignmentID = String.Empty Then
            params(2) = New SqlParameter("@StConsignmentID", DBNull.Value)
        Else
            params(2) = New SqlParameter("@StConsignmentID", ObjRefNoisexist.StConsignmentID)
        End If

        dt = objdb.ExecQuery("[Store].[ReferenceNoIsExist]", params).Tables(0)

        Return dt

    End Function

    Public Function Bind_cmbYearandMonth(ByVal ConsignmentReceived As ConsignmentReceivedPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", 2)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[StockDetailConsignmentMonthYearGET]", Parms)
        Return ds

    End Function

    Public Function STConsignmentApproval(ByVal objConsignmentUpdate As ConsignmentReceivedPPT) As Integer

        'Dim ds As New DataSet
        Dim intjournalRowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Dim datetime As Date = System.DateTime.Today
        Try
            Parms(0) = New SqlParameter("@STConsignmentMasterID", objConsignmentUpdate.STConsignmentMasterID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@StConsignmentID", objConsignmentUpdate.StConsignmentID)
            Parms(4) = New SqlParameter("@ReceivedQty", objConsignmentUpdate.ReceivedQty)
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", datetime)

            intjournalRowsAffected = objdb.ExecNonQuery("[Store].[StockDetailConsignmentUpdate]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected

    End Function


End Class
