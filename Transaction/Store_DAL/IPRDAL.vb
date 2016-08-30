Imports System.Data.SqlClient
Imports Store_PPT
Imports Common_DAL
Imports Common_PPT

Public Class IPRDAL

    Public Function GenerateIPRXML(id As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        If id Is Nothing Or String.IsNullOrEmpty(id) Then
            Parms(0) = New SqlParameter("@ID", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@ID", id)
        End If
        dt = objdb.ExecQuery("[Store].[STIPRXML]", Parms).Tables(0)
        Return dt
    End Function

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

    Public Function GetPRAutoNo() As String
        Dim obj As New SQLHelp
        Dim ds As New DataSet
        Dim param() As SqlParameter
        ds = obj.ExecQuery("[Store].[PRAutoNo]", param)
        For Each dr As DataRow In ds.Tables(0).Rows
            Return dr("PRNo").ToString()
        Next
    End Function

    'Public Function GetStockCategory(ByVal obStkCategory As IPRPPT) As DataTable
    '    Dim objdb As New SQLHelp
    '    Dim dt As New DataTable
    '    Dim Parms(4) As SqlParameter

    '    If IPRPPT.strGlobalCategoryID = "" Then
    '        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '        Parms(2) = New SqlParameter("@STCategoryID", DBNull.Value)

    '        If obStkCategory.StockCode = String.Empty Then
    '            Parms(3) = New SqlParameter("@STCategCode", DBNull.Value)
    '        Else
    '            Parms(3) = New SqlParameter("@STCategCode", obStkCategory.StockCode) 'Textbox Value
    '        End If
    '        If obStkCategory.StockDesc = String.Empty Then
    '            Parms(4) = New SqlParameter("@STCategDesc", DBNull.Value)
    '        Else
    '            Parms(4) = New SqlParameter("@STCategDesc", obStkCategory.StockDesc) 'Textbox Value
    '        End If
    '    Else
    '        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '        Parms(2) = New SqlParameter("@STCategoryID", IPRPPT.strGlobalCategoryID)
    '        If obStkCategory.StockCode = String.Empty Then
    '            Parms(3) = New SqlParameter("@STCategCode", DBNull.Value)
    '        Else
    '            Parms(3) = New SqlParameter("@STCategCode", obStkCategory.StockCode) 'Textbox Value
    '        End If
    '        If obStkCategory.StockDesc = String.Empty Then
    '            Parms(4) = New SqlParameter("@STCategDesc", DBNull.Value)
    '        Else
    '            Parms(4) = New SqlParameter("@STCategDesc", obStkCategory.StockDesc) 'Textbox Value
    '        End If

    '    End If
    '    dt = objdb.ExecQuery("[Store].[GetStockCategory]", Parms).Tables(0)
    '    Return dt
    'End Function

    Public Function GetStockCategory(ByVal obStkCategory As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(7) As SqlParameter

        If IPRPPT.strGlobalCategoryID = String.Empty Then 'To search for Category Lookup
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@STCategoryID", DBNull.Value)
            Parms(3) = New SqlParameter("@STCategCode", IIf(obStkCategory.STCategoryCode <> String.Empty, obStkCategory.STCategoryCode, DBNull.Value))
            Parms(4) = New SqlParameter("@STCategDesc", IIf(obStkCategory.STCategory <> String.Empty, obStkCategory.STCategory, DBNull.Value))
            Parms(5) = New SqlParameter("@PartNo", DBNull.Value)

            Parms(6) = New SqlParameter("@StockCode", DBNull.Value)
            Parms(7) = New SqlParameter("@StockDesc", DBNull.Value)
            ''Parms(6) = New SqlParameter("@StockCode", IIf(obStkCategory.StockCode <> String.Empty, obStkCategory.StockCode, DBNull.Value))
            ''Parms(7) = New SqlParameter("@StockDesc", IIf(obStkCategory.StockDesc <> String.Empty, obStkCategory.StockDesc, DBNull.Value))
        Else 'To search for Stock Code Lookup
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@STCategoryID", IPRPPT.strGlobalCategoryID)
            Parms(3) = New SqlParameter("@StockCode", IIf(obStkCategory.StockCode <> String.Empty, obStkCategory.StockCode, DBNull.Value))
            Parms(4) = New SqlParameter("@StockDesc", IIf(obStkCategory.StockDesc <> String.Empty, obStkCategory.StockDesc, DBNull.Value))
            Parms(5) = New SqlParameter("@PartNo", IIf(obStkCategory.PartNo <> String.Empty, obStkCategory.PartNo, DBNull.Value))

            Parms(6) = New SqlParameter("@STCategCode", DBNull.Value) '
            Parms(7) = New SqlParameter("@STCategDesc", DBNull.Value)
            ''Parms(6) = New SqlParameter("@STCategCode", IIf(obStkCategory.STCategoryCode <> String.Empty, obStkCategory.STCategoryCode, DBNull.Value)) '
            ''Parms(7) = New SqlParameter("@STCategDesc", IIf(obStkCategory.STCategory <> String.Empty, obStkCategory.STCategory, DBNull.Value))
        End If
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[GetStockCategory]", Parms)
        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

        End If
        Return dt

        ''Dim dt As New DataTable
        'dt = objdb.ExecQueryDataTable("[Store].[GetStockCategory]", Parms)
        'If dt.Rows.Count > 0 Then
        '    '   dt = dt.Tables(0)

        'End If
        'Return dt
    End Function

    Public Function StockCodeSearch(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@STCategoryID", IPRPPT.strGlobalCategoryID)
        Parms(3) = New SqlParameter("@Stockcode", objIPRPPT.StockCode)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[StockCodeSearchAndSelect]", Parms).Tables(0)
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

    Public Function bind_cmbClassification(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Store].[IPRClassificationGET]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Classification_DaysGet(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Classification", objIPRPPT.Classification)

        dt = objdb.ExecQuery("[Store].[IPRClassificationGETDays]", Parms).Tables(0)
        Return dt
    End Function

    Public Function IPRNo_isExist(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        If objIPRPPT.STIPRID = "" Then
            Parms(0) = New SqlParameter("@IPRNo", objIPRPPT.IPRNo)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STIPRID", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@IPRNo", objIPRPPT.IPRNo)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STIPRID", objIPRPPT.STIPRID)
        End If
        dt = objdb.ExecQuery("[Store].[STIPRIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Save_IPR(ByVal objIPRSave As IPRPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(22) As SqlParameter
        Dim datetime As Date = System.DateTime.Today
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@IPRdate", objIPRSave.IPRdate)
        Parms(3) = New SqlParameter("@DeliveredTo", objIPRSave.DeliveredTo)
        Parms(4) = New SqlParameter("@IPRNo", objIPRSave.IPRNo)
        Parms(5) = New SqlParameter("@ClassificationID", IIf(objIPRSave.Classification <> String.Empty, objIPRSave.Classification, DBNull.Value))
        Parms(6) = New SqlParameter("@STCategoryID", IPRPPT.strGlobalCategoryID)
        Parms(7) = New SqlParameter("@RequiredFor", objIPRSave.RequiredFor)
        Parms(8) = New SqlParameter("@RequiredDate", IIf(objIPRSave.RequiredDate <> Nothing, objIPRSave.RequiredDate, DBNull.Value))
        Parms(9) = New SqlParameter("@D", IIf(objIPRSave.D <> String.Empty, objIPRSave.D, DBNull.Value))
        Parms(10) = New SqlParameter("@MainStatus", objIPRSave.MainStatus)
        Parms(11) = New SqlParameter("@MakeModel", objIPRSave.MakeModel)
        Parms(12) = New SqlParameter("@Engine", objIPRSave.Engine)
        Parms(13) = New SqlParameter("@ChassisSerialNo", objIPRSave.ChassisSerialNo)
        Parms(14) = New SqlParameter("@FixedAssetNo", objIPRSave.FixedAssetNo)
        Parms(15) = New SqlParameter("@Remarks", objIPRSave.Remarks)
        Parms(16) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(17) = New SqlParameter("@CreatedOn", datetime)
        Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@ModifiedOn", datetime)
        Parms(20) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Parms(21) = New SqlParameter("@UsageCOAID", IIf(objIPRSave.COAID <> String.Empty, objIPRSave.COAID, DBNull.Value))

        Parms(22) = New SqlParameter("@MRCNo", objIPRSave.MRCNo)

        dt = objdb.ExecQuery("[Store].[STIPRInsert_N]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Update_IPR(ByVal objIPRSave As IPRPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim datetime As Date = System.DateTime.Today
        Try
            Dim Parms(20) As SqlParameter
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@IPRdate", objIPRSave.IPRdate)
            Parms(3) = New SqlParameter("@DeliveredTo", objIPRSave.DeliveredTo)
            Parms(4) = New SqlParameter("@IPRNo", objIPRSave.IPRNo)
            Parms(5) = New SqlParameter("@ClassificationID", IIf(objIPRSave.Classification <> String.Empty, objIPRSave.Classification, DBNull.Value))
            Parms(6) = New SqlParameter("@STCategoryID", IPRPPT.strGlobalCategoryID)
            Parms(7) = New SqlParameter("@RequiredFor", objIPRSave.RequiredFor)
            Parms(8) = New SqlParameter("@RequiredDate", IIf(objIPRSave.RequiredDate <> Nothing, objIPRSave.RequiredDate, DBNull.Value))
            Parms(9) = New SqlParameter("@D", IIf(objIPRSave.D <> String.Empty, objIPRSave.D, DBNull.Value))
            Parms(10) = New SqlParameter("@MainStatus", objIPRSave.MainStatus)
            Parms(11) = New SqlParameter("@MakeModel", objIPRSave.MakeModel)
            Parms(12) = New SqlParameter("@Engine", objIPRSave.Engine)
            Parms(13) = New SqlParameter("@ChassisSerialNo", objIPRSave.ChassisSerialNo)
            Parms(14) = New SqlParameter("@FixedAssetNo", objIPRSave.FixedAssetNo)
            Parms(15) = New SqlParameter("@Remarks", objIPRSave.Remarks)
            Parms(16) = New SqlParameter("@STIPRID", objIPRSave.STIPRID)
            Parms(17) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(19) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
            Parms(20) = New SqlParameter("@UsageCOAID", IIf(objIPRSave.COAID <> String.Empty, objIPRSave.COAID, DBNull.Value))
            objdb.ExecNonQuery("[Store].[STIPRUpdate]", Parms)
            rowsAffected = 1
        Catch exx As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Save_IPRDetail(ByVal objIPRPPT As IPRPPT) As Integer
        Dim dt As New DataTable
        Dim rowsAffected As Integer
        Dim objdb As New SQLHelp
        Try
            Dim Parms(14) As SqlParameter
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@StockID", objIPRPPT.stockID)
            Parms(2) = New SqlParameter("@STIPRID", objIPRPPT.STIPRID)
            Parms(3) = New SqlParameter("@RequestedQty", objIPRPPT.RequestedQty)
            Parms(4) = New SqlParameter("@UnitPrice", objIPRPPT.UnitPrice)
            Parms(5) = New SqlParameter("@Status", objIPRPPT.Status)
            Parms(6) = New SqlParameter("@RejectedReason", IIf(objIPRPPT.RejectedReason <> "", objIPRPPT.RejectedReason, DBNull.Value))
            Parms(7) = New SqlParameter("@Value", objIPRPPT.value)
            Parms(8) = New SqlParameter("@PendingQty", objIPRPPT.PendingQty)
            Parms(9) = New SqlParameter("@AvailableQty", objIPRPPT.AvailableQty)
            Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(11) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(13) = New SqlParameter("@ModifiedOn", Date.Today)
            Parms(14) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

            objdb.ExecNonQuery("[Store].[STIPRDetailInsert]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Function Update_IPRDetail(ByVal objIPRPPT As IPRPPT) As Integer
        Dim rowsAffected As Integer
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Try
            Dim updateParms(12) As SqlParameter
            updateParms(0) = New SqlParameter("@STIPRDetID", objIPRPPT.STIPRDetID)
            updateParms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            updateParms(2) = New SqlParameter("@STIPRID", objIPRPPT.STIPRID)
            updateParms(3) = New SqlParameter("@StockID", objIPRPPT.stockID)
            updateParms(4) = New SqlParameter("@RequestedQty", objIPRPPT.RequestedQty)
            updateParms(5) = New SqlParameter("@UnitPrice", objIPRPPT.UnitPrice)
            updateParms(6) = New SqlParameter("@Status", objIPRPPT.Status)
            updateParms(7) = New SqlParameter("@RejectedReason", IIf(objIPRPPT.RejectedReason <> "", objIPRPPT.RejectedReason, DBNull.Value))
            updateParms(8) = New SqlParameter("@Value", objIPRPPT.value)
            updateParms(9) = New SqlParameter("@PendingQty", objIPRPPT.PendingQty)
            updateParms(10) = New SqlParameter("@AvailableQty", objIPRPPT.AvailableQty)
            updateParms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            updateParms(12) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STIPRDetailUpdate]", updateParms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Function Update_IPRApproval(ByVal objIPRPPT As IPRPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Try

            Parms(0) = New SqlParameter("@STIPRID", objIPRPPT.STIPRID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            ' Parms(3) = New SqlParameter("@IPRdate", objIPRPPT.IPRdate)
            Parms(3) = New SqlParameter("@MainStatus", objIPRPPT.Status)
            Parms(4) = New SqlParameter("@Remarks", objIPRPPT.Remarks)
            Parms(5) = New SqlParameter("@RejectedReason", objIPRPPT.RejectedReason)
            Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@CreatedOn ", Date.Today)
            Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(9) = New SqlParameter("@ModifiedOn", Date.Today)

            rowsAffected = objdb.ExecNonQuery("[Store].[STIPRApproval]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Delete_IPRDetail(ByVal objIPRPPT As IPRPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STIPRID", objIPRPPT.STIPRID)
            Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(3) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[IPRViewDelete]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function GetIPRDetails(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(8) As SqlParameter
        Dim dt As New DataTable
        'If objIPRPPT.IPRNo <> "" Then
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@IPRdate", IIf(objIPRPPT.IPRdate <> Nothing, objIPRPPT.IPRdate, DBNull.Value)) 'objIPRPPT.IPRdate)
        params(2) = New SqlParameter("@IPRNo", IIf(objIPRPPT.IPRNo <> "", objIPRPPT.IPRNo, DBNull.Value))
        params(3) = New SqlParameter("@DeliveredTo", IIf(objIPRPPT.DeliveredTo <> "", objIPRPPT.DeliveredTo, DBNull.Value))
        params(4) = New SqlParameter("@Classification", IIf(objIPRPPT.Classification <> "", objIPRPPT.Classification, DBNull.Value))
        params(5) = New SqlParameter("@RequiredFor", IIf(objIPRPPT.RequiredFor <> "", objIPRPPT.RequiredFor, DBNull.Value))
        params(6) = New SqlParameter("@STCategory", IIf(objIPRPPT.STCategory <> "", objIPRPPT.STCategory, DBNull.Value))
        If objIPRPPT.MainStatus = "SELECT ALL" Then
            params(7) = New SqlParameter("@MainStatus", DBNull.Value)
        Else
            params(7) = New SqlParameter("@MainStatus", objIPRPPT.MainStatus)
        End If
        params(8) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ' params(7) = New SqlParameter("@MainStatus", IIf(objIPRPPT.MainStatus <> "", objIPRPPT.MainStatus, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[IPRViewSearch]", params).Tables(0)
        Return dt
    End Function

    Public Function GetIPRDetailsInfo(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@STIPRID", objIPRPPT.STIPRID)

        dt = objdb.ExecQuery("[Store].[STIPRDetailGet]", params).Tables(0)
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
    Public Function GetAvailableQTy(ByVal objIPRPPT As IPRPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", objIPRPPT.stockID)
        Parms(3) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[CalculateAvailableQty]", Parms).Tables(0)
        Return dt
    End Function
    Public Function IPRRecordIsExist(ByVal objIPRPPT As IPRPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STIPRRecordIsExist]", Parms)
        Return objExists
    End Function

    Public Function AcctlookupSearch(ByVal objIPRPPT As IPRPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objIPRPPT.COACode <> "" And objIPRPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objIPRPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objIPRPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objIPRPPT.COACode <> "" And objIPRPPT.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objIPRPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objIPRPPT.COACode = "" And objIPRPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objIPRPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)
    End Function


    Public Function DeleteMultiEntryIPR(ByVal ObjIPRPPT As IPRPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter

        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STIPRDetID", ObjIPRPPT.STIPRDetID)

        rowsAffected = objdb.ExecNonQuery("[Store].[STIPRDetailDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function


End Class
