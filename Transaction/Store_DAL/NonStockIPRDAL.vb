Imports System.Data.SqlClient
Imports Store_PPT
Imports Common_DAL
Imports Common_PPT

Public Class NonStockIPRDAL
    Public Function GetIPRNo(ByVal objIPRNo As IPRPPT) As IPRPPT
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[STIPRNoGet]", Parms)
        Dim clsUser As IPRPPT = New IPRPPT
        For Each dr As DataRow In ds.Tables(0).Rows
            clsUser.IPRNo = IIf(IsDBNull(dr("NewIPRNo")), "", dr("NewIPRNo"))
        Next
        Return clsUser
    End Function

    Public Function GetStockCategory(ByVal obStkCategory As NonStockIPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@STCategCode", IIf(obStkCategory.STCategoryCode <> String.Empty, obStkCategory.STCategoryCode, DBNull.Value))
        Parms(3) = New SqlParameter("@STCategDesc", IIf(obStkCategory.STCategory <> String.Empty, obStkCategory.STCategory, DBNull.Value))
        Parms(4) = New SqlParameter("@PartNo", DBNull.Value)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[GetCategoryforNonStock]", Parms)
        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
        End If
        Return dt
    End Function

    Public Function GetStockCode(ByVal obStkCategory As NonStockIPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@STCategoryID", obStkCategory.STCategory)
        Parms(3) = New SqlParameter("@StockCode", IIf(obStkCategory.StockCode <> String.Empty, obStkCategory.StockCode, DBNull.Value))
        Parms(4) = New SqlParameter("@StockDesc", IIf(obStkCategory.StockDesc <> String.Empty, obStkCategory.StockDesc, DBNull.Value))
        Parms(5) = New SqlParameter("@PartNo", IIf(obStkCategory.PartNo <> String.Empty, obStkCategory.PartNo, DBNull.Value))

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[GetStockCodeforNonStockIPR]", Parms)
        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
        End If
        Return dt
    End Function

    Public Function StockCodeSearch(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@STCategoryID", objNonStockIPRPPT.STCategoryID)
        Parms(3) = New SqlParameter("@Stockcode", objNonStockIPRPPT.StockCode)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[StockCodeSearchNonStockIPR]", Parms).Tables(0)
        Dim dtint As Integer = dt.Rows.Count
        Return dt
    End Function


    Public Function IPRViewSearch(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@SearchFeild", objIPRPPT.Status)
        Parms(2) = New SqlParameter("@Fieldname", "MainStatus") 'Textbox value

        dt = objdb.ExecQuery("[Store].[IPRViewSearch]", Parms).Tables(0)
        Return dt
    End Function

    Public Function STNonStockIPRNo_isExist(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter
        If objNonStockIPRPPT.STNonStockIPRID = "" Then
            Parms(0) = New SqlParameter("@IPRNo", objNonStockIPRPPT.IPRNo)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STNonStockIPRID", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@IPRNo", objNonStockIPRPPT.IPRNo)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)
        End If
        dt = objdb.ExecQuery("[Store].[STNonStockIPRIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Save_STNonStockIPR(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(21) As SqlParameter
        Dim datetime As Date = System.DateTime.Today
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@IPRdate", objNonStockIPRPPT.IPRdate)
        Parms(3) = New SqlParameter("@DeliveredTo", objNonStockIPRPPT.DeliveredTo)
        Parms(4) = New SqlParameter("@IPRNo", objNonStockIPRPPT.IPRNo)
        Parms(5) = New SqlParameter("@ClassificationID", IIf(objNonStockIPRPPT.Classification <> String.Empty, objNonStockIPRPPT.Classification, DBNull.Value))
        Parms(6) = New SqlParameter("@STCategoryID", objNonStockIPRPPT.STCategoryID)
        Parms(7) = New SqlParameter("@RequiredFor", objNonStockIPRPPT.RequiredFor)
        Parms(8) = New SqlParameter("@RequiredDate", objNonStockIPRPPT.RequiredDate)
        Parms(9) = New SqlParameter("@D", objNonStockIPRPPT.D)
        Parms(10) = New SqlParameter("@MainStatus", objNonStockIPRPPT.MainStatus)
        Parms(11) = New SqlParameter("@MakeModel", objNonStockIPRPPT.MakeModel)
        Parms(12) = New SqlParameter("@Engine", objNonStockIPRPPT.Engine)
        Parms(13) = New SqlParameter("@ChassisSerialNo", objNonStockIPRPPT.ChassisSerialNo)
        Parms(14) = New SqlParameter("@FixedAssetNo", objNonStockIPRPPT.FixedAssetNo)
        Parms(15) = New SqlParameter("@Remarks", objNonStockIPRPPT.Remarks)
        Parms(16) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(17) = New SqlParameter("@CreatedOn", datetime)
        Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@ModifiedOn", datetime)
        Parms(20) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Parms(21) = New SqlParameter("@UsageCOAID", IIf(objNonStockIPRPPT.COAID <> String.Empty, objNonStockIPRPPT.COAID, DBNull.Value))
        dt = objdb.ExecQuery("[Store].[STNonStockIPRInsert]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Update_STNonStockIPR(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim datetime As Date = System.DateTime.Today
        Try
            Dim Parms(20) As SqlParameter
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@IPRdate", objNonStockIPRPPT.IPRdate)
            Parms(3) = New SqlParameter("@DeliveredTo", objNonStockIPRPPT.DeliveredTo)
            Parms(4) = New SqlParameter("@IPRNo", objNonStockIPRPPT.IPRNo)
            Parms(5) = New SqlParameter("@ClassificationID", IIf(objNonStockIPRPPT.Classification <> String.Empty, objNonStockIPRPPT.Classification, DBNull.Value))
            Parms(6) = New SqlParameter("@STCategoryID", objNonStockIPRPPT.STCategoryID)
            Parms(7) = New SqlParameter("@RequiredFor", objNonStockIPRPPT.RequiredFor)
            Parms(8) = New SqlParameter("@RequiredDate", objNonStockIPRPPT.RequiredDate)
            Parms(9) = New SqlParameter("@D", objNonStockIPRPPT.D)
            Parms(10) = New SqlParameter("@MainStatus", objNonStockIPRPPT.MainStatus)
            Parms(11) = New SqlParameter("@MakeModel", objNonStockIPRPPT.MakeModel)
            Parms(12) = New SqlParameter("@Engine", objNonStockIPRPPT.Engine)
            Parms(13) = New SqlParameter("@ChassisSerialNo", objNonStockIPRPPT.ChassisSerialNo)
            Parms(14) = New SqlParameter("@FixedAssetNo", objNonStockIPRPPT.FixedAssetNo)
            Parms(15) = New SqlParameter("@Remarks", objNonStockIPRPPT.Remarks)
            Parms(16) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)
            Parms(17) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@ModifiedOn", datetime)
            Parms(19) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
            Parms(20) = New SqlParameter("@UsageCOAID", IIf(objNonStockIPRPPT.COAID <> String.Empty, objNonStockIPRPPT.COAID, DBNull.Value))
            objdb.ExecNonQuery("[Store].[STNonStockIPRUpdate]", Parms)
            rowsAffected = 1
        Catch exx As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Save_STNonStockIPRDetail(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim dt As New DataTable
        Dim rowsAffected As Integer
        Dim objdb As New SQLHelp
        Try
            Dim Parms(13) As SqlParameter
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@StockID", objNonStockIPRPPT.stockID)
            Parms(2) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)
            Parms(3) = New SqlParameter("@RequestedQty", objNonStockIPRPPT.RequestedQty)
            Parms(4) = New SqlParameter("@UnitPrice", objNonStockIPRPPT.UnitPrice)
            Parms(5) = New SqlParameter("@Status", objNonStockIPRPPT.Status)
            Parms(6) = New SqlParameter("@RejectedReason", IIf(objNonStockIPRPPT.RejectedReason <> "", objNonStockIPRPPT.RejectedReason, DBNull.Value))
            Parms(7) = New SqlParameter("@Value", objNonStockIPRPPT.value)
            Parms(8) = New SqlParameter("@PendingQty", objNonStockIPRPPT.PendingQty)
            Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(12) = New SqlParameter("@ModifiedOn", Date.Today)
            Parms(13) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

            objdb.ExecNonQuery("[Store].[STNonStockIPRDetailInsert]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Function Update_STNonStockIPRDetail(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim rowsAffected As Integer
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Try
            Dim updateParms(11) As SqlParameter
            updateParms(0) = New SqlParameter("@STNonStockIPRDetID", objNonStockIPRPPT.STNonStockIPRDetID)
            updateParms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            updateParms(2) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)
            updateParms(3) = New SqlParameter("@StockID", objNonStockIPRPPT.stockID)
            updateParms(4) = New SqlParameter("@RequestedQty", objNonStockIPRPPT.RequestedQty)
            updateParms(5) = New SqlParameter("@UnitPrice", objNonStockIPRPPT.UnitPrice)
            updateParms(6) = New SqlParameter("@Status", objNonStockIPRPPT.Status)
            updateParms(7) = New SqlParameter("@RejectedReason", IIf(objNonStockIPRPPT.RejectedReason <> "", objNonStockIPRPPT.RejectedReason, DBNull.Value))
            updateParms(8) = New SqlParameter("@Value", objNonStockIPRPPT.value)
            updateParms(9) = New SqlParameter("@PendingQty", objNonStockIPRPPT.PendingQty)
            updateParms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            updateParms(11) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STNonStockIPRDetailUpdate]", updateParms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Function Delete_STNonStockIPRDetail(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)
            Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(3) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STNonStockIPRDetailDelete]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Update_STNonStockIPRApproval(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Try

            Parms(0) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            ' Parms(3) = New SqlParameter("@IPRdate", objNonStockIPRPPT.IPRdate)
            Parms(3) = New SqlParameter("@MainStatus", objNonStockIPRPPT.Status)
            Parms(4) = New SqlParameter("@Remarks", objNonStockIPRPPT.Remarks)
            Parms(5) = New SqlParameter("@RejectedReason", objNonStockIPRPPT.RejectedReason)
            Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@CreatedOn ", Date.Today)
            Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(9) = New SqlParameter("@ModifiedOn", Date.Today)

            rowsAffected = objdb.ExecNonQuery("[Store].[STNonStockIPRApproval]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function GetNonStockIPRSearch_Details(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(8) As SqlParameter
        Dim dt As New DataTable
        'If objNonStockIPRPPT.IPRNo <> "" Then
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@IPRdate", IIf(objNonStockIPRPPT.IPRdate <> Nothing, objNonStockIPRPPT.IPRdate, DBNull.Value)) 'objNonStockIPRPPT.IPRdate)
        params(2) = New SqlParameter("@IPRNo", IIf(objNonStockIPRPPT.IPRNo <> "", objNonStockIPRPPT.IPRNo, DBNull.Value))
        params(3) = New SqlParameter("@DeliveredTo", IIf(objNonStockIPRPPT.DeliveredTo <> "", objNonStockIPRPPT.DeliveredTo, DBNull.Value))
        params(4) = New SqlParameter("@Classification", IIf(objNonStockIPRPPT.Classification <> "", objNonStockIPRPPT.Classification, DBNull.Value))
        params(5) = New SqlParameter("@RequiredFor", IIf(objNonStockIPRPPT.RequiredFor <> "", objNonStockIPRPPT.RequiredFor, DBNull.Value))
        params(6) = New SqlParameter("@STCategory", IIf(objNonStockIPRPPT.STCategory <> "", objNonStockIPRPPT.STCategory, DBNull.Value))
        If objNonStockIPRPPT.MainStatus = "SELECT ALL" Then
            params(7) = New SqlParameter("@MainStatus", DBNull.Value)
        Else
            params(7) = New SqlParameter("@MainStatus", objNonStockIPRPPT.MainStatus)
        End If
        params(8) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ' params(7) = New SqlParameter("@MainStatus", IIf(objNonStockIPRPPT.MainStatus <> "", objNonStockIPRPPT.MainStatus, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STNonStockIPRSearch]", params).Tables(0)
        Return dt
    End Function

    Public Function GetNonStockIPRDetails(ByVal objNonStockIPRPPT As NonStockIPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@STNonStockIPRID", objNonStockIPRPPT.STNonStockIPRID)

        dt = objdb.ExecQuery("[Store].[STNonStockIPRDetailGet]", params).Tables(0)
        Return dt
    End Function

    Public Function StockCategorySearch(ByVal CategorySearch As String) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STCategoryDescp", CategorySearch)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[STCategorySearchAndSelect]", Parms).Tables(0)
        'Dim strResult As String = dt.Rows(0).Item("STCategoryCode").ToString()
        'Dim strResult1 As String = dt.Rows(0).Item("STCategoryID").ToString()
        Return dt
    End Function

    Public Function GetAvailableQTy(ByVal objNonStockIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", objNonStockIPRPPT.stockID)
        Parms(3) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[CalculateAvailableQty]", Parms).Tables(0)
        Return dt
    End Function

    Public Function STNonStockIPRRecordIsExist(ByVal objNonStockIPRPPT As NonStockIPRPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STNonStockIPRRecordIsExist]", Parms)
        Return objExists
    End Function

    Public Function AcctlookupSearch(ByVal objNonStockIPRPPT As IPRPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objNonStockIPRPPT.COACode <> "" And objNonStockIPRPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objNonStockIPRPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objNonStockIPRPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objNonStockIPRPPT.COACode <> "" And objNonStockIPRPPT.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objNonStockIPRPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objNonStockIPRPPT.COACode = "" And objNonStockIPRPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objNonStockIPRPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)
    End Function

    Public Function DeleteMultiEntryNonIPR(ByVal ObjNonIPRPPT As NonStockIPRPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter

        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STNonStockIPRDetID", ObjNonIPRPPT.STNonStockIPRDetID)

        rowsAffected = objdb.ExecNonQuery("[Store].[STNonStockIPRDetailDelete_N]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function

    Public Function GetNonStockCategory(ByVal obStkCategory As NonStockIPRPPT, ByVal IsDirect As String) As DataTable

        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter

        If NonStockIPRPPT.strGlobalCategoryID = String.Empty Then 'To search for Category Lookup

            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@STCategCode", IIf(obStkCategory.STCategoryCode <> String.Empty, obStkCategory.STCategoryCode, DBNull.Value))
            Parms(3) = New SqlParameter("@STCategDesc", IIf(obStkCategory.STCategory <> String.Empty, obStkCategory.STCategory, DBNull.Value))
            Parms(4) = New SqlParameter("@IsDirect", IsDirect)

        End If

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[GetNonStockCategory]", Parms)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
        End If

        Return dt

    End Function


End Class
