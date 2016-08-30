Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL



Public Class InternalServiceRequisitionDAL
    Public Function GetISRNo(ByVal objISRNo As InternalServiceRequisitionPPT) As InternalServiceRequisitionPPT
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[STISRNoGet]", Parms)
        Dim clsUser As InternalServiceRequisitionPPT = New InternalServiceRequisitionPPT
        For Each dr As DataRow In ds.Tables(0).Rows
            clsUser.ISRNo = IIf(IsDBNull(dr("NewISRNo")), "", dr("NewISRNo"))
        Next
        Return clsUser
    End Function
    Public Shared Function CURRENCYTYPEGET(ByVal objISRPPT As InternalServiceRequisitionPPT) As DataTable

        'Dim dt As DataTable
        'Dim objdb As New SQLHelp
        'Dim Parms(1) As SqlParameter
        'Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'dt = objdb.ExecQuery("[Store].[CURRENCYTYPEGET]").Tables(0)

        'Return dt

        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Store].[CURRENCYTYPEGET]", params).Tables(0)
        Return dt


    End Function


    Public Function Save_ISR(ByVal objISRSave As InternalServiceRequisitionPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Dim datetime As Date = System.DateTime.Today
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ISRNo", objISRSave.ISRNo)
        Parms(3) = New SqlParameter("@ISRDate", objISRSave.ISRDate)
        Parms(4) = New SqlParameter("@Supplier", objISRSave.Supplier)
        Parms(5) = New SqlParameter("@RequiredFor", objISRSave.RequiredFor)
        Parms(6) = New SqlParameter("@MakeModel", objISRSave.MakeModel)
        Parms(7) = New SqlParameter("@Engine", objISRSave.Engine)
        Parms(8) = New SqlParameter("@ChassisNo", objISRSave.ChassisNo)
        Parms(9) = New SqlParameter("@FixedAssetNo", objISRSave.fixedAssetNo)
        Parms(10) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@CreatedOn", datetime)
        Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(14) = New SqlParameter("@ModifiedOn", datetime)

        'dt = objdb.ExecQuery("[Store].[STISRInsert]", Parms).Tables(0)
        ds = objdb.ExecQuery("[Store].[STISRInsert]", Parms)

        Return ds

    End Function

    Public Function Save_ISRDetail(ByVal objISRSaveDetail As InternalServiceRequisitionPPT) As DataSet

        Dim dt As New DataTable
        Dim ds As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(22) As SqlParameter
        Dim datetime As Date = System.DateTime.Today
        'Parms(1) = New SqlParameter("@ISRDetID", objISRSaveDetail.ISRDetID)
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(2) = New SqlParameter("@CreatedOn", datetime)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", datetime)
        Parms(5) = New SqlParameter("@STISRID", objISRSaveDetail.STISRID)
        Parms(6) = New SqlParameter("@ServiceType", objISRSaveDetail.ServiceType)

        If objISRSaveDetail.StockID <> String.Empty Then

            Parms(7) = New SqlParameter("@StockID", objISRSaveDetail.StockID)
        Else
            Parms(7) = New SqlParameter("@StockID", System.DBNull.Value)
        End If

        ''Parms(7) = New SqlParameter("@StockID", objISRSaveDetail.StockID)

        Parms(8) = New SqlParameter("@ServiceDetail", objISRSaveDetail.ServiceDetail)
        Parms(9) = New SqlParameter("@Qty", objISRSaveDetail.Qty)
        Parms(10) = New SqlParameter("@Unit", objISRSaveDetail.Unit)
        Parms(11) = New SqlParameter("@COAID", objISRSaveDetail.COAID)

        If objISRSaveDetail.T0 <> String.Empty Then
            Parms(12) = New SqlParameter("@T0 ", objISRSaveDetail.T0)
        Else
            Parms(12) = New SqlParameter("@T0", System.DBNull.Value)
        End If

        If objISRSaveDetail.T1 <> String.Empty Then
            Parms(13) = New SqlParameter("@T1 ", objISRSaveDetail.T1)
        Else
            Parms(13) = New SqlParameter("@T1", System.DBNull.Value)
        End If

        If objISRSaveDetail.T2 <> String.Empty Then
            Parms(14) = New SqlParameter("@T2 ", objISRSaveDetail.T2)
        Else
            Parms(14) = New SqlParameter("@T2", System.DBNull.Value)
        End If

        If objISRSaveDetail.T3 <> String.Empty Then
            Parms(15) = New SqlParameter("@T3 ", objISRSaveDetail.T3)
        Else
            Parms(15) = New SqlParameter("@T3", System.DBNull.Value)
        End If

        If objISRSaveDetail.T4 <> String.Empty Then
            Parms(16) = New SqlParameter("@T4 ", objISRSaveDetail.T4)
        Else
            Parms(16) = New SqlParameter("@T4", System.DBNull.Value)
        End If

        Parms(17) = New SqlParameter("@UnitPrice", objISRSaveDetail.UnitPrice)
        Parms(18) = New SqlParameter("@Value", objISRSaveDetail.Valu)
        Parms(19) = New SqlParameter("@UnitPriceC", objISRSaveDetail.UnitPriceC)
        Parms(20) = New SqlParameter("@ValueC", objISRSaveDetail.ValueC)
        Parms(21) = New SqlParameter("@CurrencyID", objISRSaveDetail.CurrencyID)

        If objISRSaveDetail.NonStockID <> String.Empty Then

            Parms(22) = New SqlParameter("@NonStockID", objISRSaveDetail.NonStockID)
        Else
            Parms(22) = New SqlParameter("@NonStockID", System.DBNull.Value)
        End If

        ''Dim dt1 As Integer = objdb.ExecNonQuery("[Store].[STISRDetailInsert]", Parms)
        'dt = objdb.ExecQuery("[Store].[STISRInsert]", Parms).Tables(0)
        ds = objdb.ExecQuery("[Store].[STISRDetailInsert]", Parms)

        Return ds

    End Function

    ''Update

    Public Function Update_ISR(ByVal objISRUpdate As InternalServiceRequisitionPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Dim datetime As Date = System.DateTime.Today

        Parms(0) = New SqlParameter("@STISRID", objISRUpdate.STISRID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ISRNo", objISRUpdate.ISRNo)
        Parms(4) = New SqlParameter("@ISRDate", objISRUpdate.ISRDate)
        Parms(5) = New SqlParameter("@Supplier", objISRUpdate.Supplier)
        Parms(6) = New SqlParameter("@RequiredFor", objISRUpdate.RequiredFor)
        Parms(7) = New SqlParameter("@MakeModel", objISRUpdate.MakeModel)
        Parms(8) = New SqlParameter("@Engine", objISRUpdate.Engine)
        Parms(9) = New SqlParameter("@ChassisNo", objISRUpdate.ChassisNo)
        Parms(10) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", datetime)

        ''dt = objdb.ExecQuery("[Store].[STISRUpdate]", Parms).Tables(0)
        ds = objdb.ExecQuery("[Store].[STISRUpdate]", Parms)
        Return ds

    End Function
    

    Public Function Update_ISRDetail(ByVal objISRUpdateDetail As InternalServiceRequisitionPPT) As DataTable

        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(21) As SqlParameter
        Dim datetime As Date = System.DateTime.Today
        Parms(0) = New SqlParameter("@ISRDetID", objISRUpdateDetail.ISRDetID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(3) = New SqlParameter("@ModifiedOn", datetime)
        Parms(4) = New SqlParameter("@STISRID", objISRUpdateDetail.STISRID)
        Parms(5) = New SqlParameter("@ServiceDetail", objISRUpdateDetail.ServiceDetail)
        Parms(6) = New SqlParameter("@ServiceType", objISRUpdateDetail.ServiceType)

        If objISRUpdateDetail.StockID <> String.Empty Then

            Parms(7) = New SqlParameter("@StockID", objISRUpdateDetail.StockID)
        Else
            Parms(7) = New SqlParameter("@StockID", System.DBNull.Value)
        End If
        ''Parms(7) = New SqlParameter("@StockID", objISRUpdateDetail.StockID)

        Parms(8) = New SqlParameter("@Qty", objISRUpdateDetail.Qty)
        Parms(9) = New SqlParameter("@Unit", objISRUpdateDetail.Unit)
        Parms(10) = New SqlParameter("@COAID", objISRUpdateDetail.COAID)
        If objISRUpdateDetail.T0 <> String.Empty Then

            Parms(11) = New SqlParameter("@T0 ", objISRUpdateDetail.T0)
        Else
            Parms(11) = New SqlParameter("@T0", System.DBNull.Value)
        End If

        If objISRUpdateDetail.T1 <> String.Empty Then
            Parms(12) = New SqlParameter("@T1 ", objISRUpdateDetail.T1)
        Else
            Parms(12) = New SqlParameter("@T1", System.DBNull.Value)
        End If

        If objISRUpdateDetail.T2 <> String.Empty Then
            Parms(13) = New SqlParameter("@T2 ", objISRUpdateDetail.T2)
        Else
            Parms(13) = New SqlParameter("@T2", System.DBNull.Value)
        End If

        If objISRUpdateDetail.T3 <> String.Empty Then
            Parms(14) = New SqlParameter("@T3 ", objISRUpdateDetail.T3)
        Else
            Parms(14) = New SqlParameter("@T3", System.DBNull.Value)
        End If

        If objISRUpdateDetail.T4 <> String.Empty Then
            Parms(15) = New SqlParameter("@T4 ", objISRUpdateDetail.T4)
        Else
            Parms(15) = New SqlParameter("@T4", System.DBNull.Value)
        End If


        Parms(16) = New SqlParameter("@UnitPrice", objISRUpdateDetail.UnitPrice)
        Parms(17) = New SqlParameter("@Value", objISRUpdateDetail.valu)
        Parms(18) = New SqlParameter("@UnitPriceC", objISRUpdateDetail.UnitPriceC)
        Parms(19) = New SqlParameter("@ValueC", objISRUpdateDetail.ValueC)
        Parms(20) = New SqlParameter("@CurrencyID", objISRUpdateDetail.CurrencyID)

        If objISRUpdateDetail.NonStockID <> String.Empty Then

            Parms(21) = New SqlParameter("@NonStockID", objISRUpdateDetail.NonStockID)
        Else
            Parms(21) = New SqlParameter("@NonStockID", System.DBNull.Value)
        End If

        Dim dt1 As Integer = objdb.ExecNonQuery("[Store].[STISRDetailUpdate]", Parms)
        Return dt

    End Function
    


    Public Function GetISRDetails(ByVal objISRPPT As InternalServiceRequisitionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        'params(0) = New SqlParameter("@ISRdate", IIf(objISRPPT.ISRDate <> Nothing, CType(objISRPPT.ISRDate, String), DBNull.Value))
        If objISRPPT.BViewISRDate = True Then
            'Parms(0) = New SqlParameter("@ISRDate", IIf(objISR.ISRDateSearch <> Nothing, objISR.ISRDateSearch, DBNull.Value))
            params(0) = New SqlParameter("@ISRDate", objISRPPT.ISRDateSearch)
        Else
            params(0) = New SqlParameter("@ISRDate", DBNull.Value)
        End If
        params(1) = New SqlParameter("@ISRNo", IIf(objISRPPT.ISRNOSearch <> "", objISRPPT.ISRNOSearch, DBNull.Value))
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Store].[ISRSearch]", params).Tables(0)
        Return dt
    End Function

    Public Function ISRDetailsGet(ByVal objISRPPT As InternalServiceRequisitionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@STISRID", objISRPPT.STISRID)


        dt = objdb.ExecQuery("[Store].[ISRDetailSearch]", params).Tables(0)
        Return dt

    End Function


    Public Shared Function ISRViewDelete(ByVal objISRViewDel As InternalServiceRequisitionPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@STISRID", objISRViewDel.STISRID)
        ds = objdb.ExecQuery("[Store].[STISRDelete]", Parms)
        Return ds

    End Function



    Public Shared Function AcctlookupSearch(ByVal objISRPPT As InternalServiceRequisitionPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objISRPPT.COAID <> "" And objISRPPT.COAIDDesc <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objISRPPT.COAID)
            Parms(1) = New SqlParameter("@AccountDesc", objISRPPT.COAIDDesc)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objISRPPT.COAID <> "" And objISRPPT.COAIDDesc = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objISRPPT.COAID)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objISRPPT.COAID = "" And objISRPPT.COAIDDesc <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objISRPPT.COAID)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)
    End Function



    Public Function ISRRecordIsExist(ByVal objISRPPT As InternalServiceRequisitionPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STISRRecordIsExist]", Parms)
        Return objExists
    End Function

    Public Function DeleteMultiEntryISR(ByVal ObjISRPPT As InternalServiceRequisitionPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter

        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ISRDetID", ObjISRPPT.ISRDetID)

        rowsAffected = objdb.ExecNonQuery("[Store].[STISRDetailDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function



End Class
