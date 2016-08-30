Imports System.Data.SqlClient
Imports Store_PPT
Imports Common_DAL
Imports Common_PPT

Public Class LocalPurchaseOrderDAL

    Public Function GetLPONo(ByVal objLPONo As LocalPurchaseOrderPPT) As LocalPurchaseOrderPPT
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[STLPONoAuto]", Parms)
        Dim clsUser As LocalPurchaseOrderPPT = New LocalPurchaseOrderPPT
        For Each dr As DataRow In ds.Tables(0).Rows
            clsUser.LPONo = IIf(IsDBNull(dr("NewLPONo")), "", dr("NewLPONo"))
            'clsUser.STLPOID = dr("STLPOID")
            'clsUser.STLPODetID = dr("STLPODetID")
        Next
        Return clsUser
    End Function

    Public Function GetPOAutoNo() As String
        Dim obj As New SQLHelp
        Dim param() As SqlParameter
        Dim ds As New DataSet
        ds = obj.ExecQuery("[Store].[POAutoNo]", param)
        For Each dr As DataRow In ds.Tables(0).Rows
            Return dr("PONo").ToString()
        Next
    End Function

    Public Function Update_LPOApproval(ByVal objLPOPPT As LocalPurchaseOrderPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Try

            Parms(0) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@LPOdate", objLPOPPT.LPODate)
            Parms(4) = New SqlParameter("@MainStatus", objLPOPPT.Status)
            Parms(5) = New SqlParameter("@Remarks", IIf(objLPOPPT.Remarks <> String.Empty, objLPOPPT.Remarks, DBNull.Value))
            Parms(6) = New SqlParameter("@RejectedReason", IIf(objLPOPPT.RejectedReason <> String.Empty, objLPOPPT.RejectedReason, DBNull.Value))
            Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(8) = New SqlParameter("@CreatedOn ", Date.Today)
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)

            rowsAffected = objdb.ExecNonQuery("[Store].[STLPOApproval]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function SearchSupplier(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        If objLPOPPT.SupplierID = String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@Supplier", DBNull.Value) 'Textbox value
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@Supplier", objLPOPPT.SupplierID) 'Textbox value
        End If
        dt = objdb.ExecQuery("[Store].[SupplierGETLPO]", Parms).Tables(0)
        Return dt
    End Function

    Public Function GetLPODetailsInfo(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
        dt = objdb.ExecQuery("[Store].[STLPODetailGet]", params).Tables(0)
        Return dt
    End Function

    Public Function GetLPODetailsView(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        dt = objdb.ExecQuery("[Store].[LPODetailsView]", params).Tables(0)
        Return dt
    End Function

    Public Function GetLPOID(ByVal objLPOPPT As LocalPurchaseOrderPPT) As LocalPurchaseOrderPPT
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim ds As New DataSet
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@LPONO", objLPOPPT.LPONo)
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Store].[LPOGetID]", params)
        Dim getID As LocalPurchaseOrderPPT = New LocalPurchaseOrderPPT
        For Each dr As DataRow In ds.Tables(0).Rows
            getID.LPONo = dr("LPONO")
            getID.STLPOID = dr("STLPOID")
            getID.STLPODetID = dr("STLPODetID")
        Next
        Return getID
    End Function

    Public Function GetStockCode(ByVal objIPRPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        dt = objdb.ExecQuery("[Store].[LPOStockCode]", Parms).Tables(0)
        Return dt
    End Function

    Public Function DeleteLPODetail(ByVal objLPOPPT As LocalPurchaseOrderPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(11) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())

        rowsAffected = objdb.ExecNonQuery("[Store].[STLPODelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    Public Shared Function SaveSTLPO(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(20) As SqlParameter

        'Parms(0) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LPODate", objLPOPPT.LPODate)
        Parms(3) = New SqlParameter("@LPONo", IIf(objLPOPPT.LPONo <> String.Empty, objLPOPPT.LPONo, DBNull.Value))
        Parms(4) = New SqlParameter("@ContractID", IIf(objLPOPPT.ContractID <> String.Empty, objLPOPPT.ContractID, DBNull.Value))
        Parms(5) = New SqlParameter("@Remarks", IIf(objLPOPPT.Remarks <> String.Empty, objLPOPPT.Remarks, DBNull.Value))
        Parms(6) = New SqlParameter("@MainStatus", objLPOPPT.MainStatus)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@SupplierID", objLPOPPT.SupplierID)
        Parms(12) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(13) = New SqlParameter("@STCategoryID", IIf(objLPOPPT.STCategoryID <> String.Empty, objLPOPPT.STCategoryID, DBNull.Value))
        'Parms(14) = New SqlParameter("@VAT", IIf(objLPOPPT.VAT <> String.Empty, objLPOPPT.VAT, DBNull.Value))

        Parms(14) = New SqlParameter("@UOM", objLPOPPT.UOM)
        Parms(15) = New SqlParameter("@VAT", objLPOPPT.VAT)
        Parms(16) = New SqlParameter("@MRCNo", objLPOPPT.MRCNo)
        Parms(17) = New SqlParameter("@TransportationCost", objLPOPPT.TransportationCost)
        Parms(18) = New SqlParameter("@VATPercent", objLPOPPT.VATPercent)
        Parms(19) = New SqlParameter("@TotalPurchase", objLPOPPT.TOTAL)
        Parms(20) = New SqlParameter("@TotalAll", objLPOPPT.TotalAll)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STLPOInsert]", Parms)
        Return ds

    End Function

    Public Shared Function UpdateSTLPODetails(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(16) As SqlParameter

        Parms(0) = New SqlParameter("@STLPODetID", objLPOPPT.STLPODetID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
        Parms(3) = New SqlParameter("@StockID", objLPOPPT.StockID)
        Parms(4) = New SqlParameter("@OrderQty", objLPOPPT.OrderQty)
        Parms(5) = New SqlParameter("@UnitPrice", objLPOPPT.UnitPrice)
        Parms(6) = New SqlParameter("@Status", objLPOPPT.MainStatus)
        Parms(7) = New SqlParameter("@RejectedReason", IIf(objLPOPPT.RejectedReason <> String.Empty, objLPOPPT.RejectedReason, DBNull.Value))
        Parms(8) = New SqlParameter("@T0", IIf(objLPOPPT.T0 <> String.Empty, objLPOPPT.T0, DBNull.Value))
        Parms(9) = New SqlParameter("@T1", IIf(objLPOPPT.T1 <> String.Empty, objLPOPPT.T1, DBNull.Value))
        Parms(10) = New SqlParameter("@T2", IIf(objLPOPPT.T2 <> String.Empty, objLPOPPT.T2, DBNull.Value))
        Parms(11) = New SqlParameter("@T3", IIf(objLPOPPT.T3 <> String.Empty, objLPOPPT.T3, DBNull.Value))
        Parms(12) = New SqlParameter("@T4", IIf(objLPOPPT.T4 <> String.Empty, objLPOPPT.T4, DBNull.Value))
        Parms(13) = New SqlParameter("@Value", objLPOPPT.Value)
        Parms(14) = New SqlParameter("@PendingQty", objLPOPPT.PendingQty)
        Parms(15) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(16) = New SqlParameter("@ModifiedOn", Date.Today())

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STLPODetailUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function SaveSTLPODetails(ByVal objLpoPpt As LocalPurchaseOrderPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(18) As SqlParameter

        'Parms(0) = New SqlParameter("@STLPODetID", objLpoPpt.STLPODetID)
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        'Parms(2) = New SqlParameter("@STLPOID", objLpoPpt.STLPOID)
        Parms(2) = New SqlParameter("@StockID", objLpoPpt.StockID)
        Parms(3) = New SqlParameter("@OrderQty", objLpoPpt.OrderQty)
        Parms(4) = New SqlParameter("@UnitPrice", objLpoPpt.UnitPrice)
        Parms(5) = New SqlParameter("@Status", objLpoPpt.MainStatus)
        Parms(6) = New SqlParameter("@RejectedReason", IIf(objLpoPpt.RejectedReason <> String.Empty, objLpoPpt.RejectedReason, DBNull.Value))
        Parms(7) = New SqlParameter("@T0", IIf(objLpoPpt.T0 <> String.Empty, objLpoPpt.T0, DBNull.Value))
        Parms(8) = New SqlParameter("@T1", IIf(objLpoPpt.T1 <> String.Empty, objLpoPpt.T1, DBNull.Value))
        Parms(9) = New SqlParameter("@T2", IIf(objLpoPpt.T2 <> String.Empty, objLpoPpt.T2, DBNull.Value))
        Parms(10) = New SqlParameter("@T3", IIf(objLpoPpt.T3 <> String.Empty, objLpoPpt.T3, DBNull.Value))
        Parms(11) = New SqlParameter("@T4", IIf(objLpoPpt.T4 <> String.Empty, objLpoPpt.T4, DBNull.Value))
        Parms(12) = New SqlParameter("@Value", objLpoPpt.Value)
        Parms(13) = New SqlParameter("@PendingQty", objLpoPpt.PendingQty)
        Parms(14) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(15) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(16) = New SqlParameter("@ModifiedOn", Date.Today())
        ' Parms(19) = New SqlParameter("@StockCode", Date.Today())
        Parms(17) = New SqlParameter("@STLPOID", objLpoPpt.STLPOID)
        Parms(18) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STLPODetailInsert]", Parms)
        Return ds

    End Function

    Public Shared Function UpdateSTLPO(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(11) As SqlParameter

        Parms(0) = New SqlParameter("@STLPOID", objLPOPPT.STLPOID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LPODate", objLPOPPT.LPODate)
        Parms(4) = New SqlParameter("@LPONo", IIf(objLPOPPT.LPONo <> String.Empty, objLPOPPT.LPONo, DBNull.Value))
        Parms(5) = New SqlParameter("@ContractID", IIf(objLPOPPT.ContractID <> String.Empty, objLPOPPT.ContractID, DBNull.Value))
        Parms(6) = New SqlParameter("@Remarks", IIf(objLPOPPT.Remarks <> String.Empty, objLPOPPT.Remarks, DBNull.Value))
        Parms(7) = New SqlParameter("@MainStatus", objLPOPPT.MainStatus)
        Parms(8) = New SqlParameter("@SupplierID", IIf(objLPOPPT.SupplierID <> String.Empty, objLPOPPT.SupplierID, DBNull.Value))
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@UsageCOAID", IIf(objLPOPPT.COAID <> String.Empty, objLPOPPT.COAID, DBNull.Value))


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STLPOUpdate]", Parms)
        Return ds

    End Function

    Public Function GetLPODetails(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim params(6) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@LPOdate", IIf(objLPOPPT.LPODate <> Nothing, objLPOPPT.LPODate, DBNull.Value)) 'objIPRPPT.IPRdate)
        params(2) = New SqlParameter("@LPONo", IIf(objLPOPPT.LPONo <> "", objLPOPPT.LPONo, DBNull.Value))
        params(3) = New SqlParameter("@StockCode", IIf(objLPOPPT.StockCode <> "", objLPOPPT.StockCode, DBNull.Value))
        params(4) = New SqlParameter("@StockID", IIf(objLPOPPT.StockID <> "", objLPOPPT.StockID, DBNull.Value))

        If objLPOPPT.MainStatus = "SELECT ALL" Then
            params(5) = New SqlParameter("@Status", DBNull.Value)
        Else
            params(5) = New SqlParameter("@Status", objLPOPPT.MainStatus)
        End If
        params(6) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Store].[LPOViewSearch]", params).Tables(0)
        Return dt


    End Function

    Public Shared Function SearchDgvLpoView(ByVal objLpoPpt As LocalPurchaseOrderPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@LPONO", IIf(objLpoPpt.LPONo <> String.Empty, objLpoPpt.LPONo, DBNull.Value))
        Parms(1) = New SqlParameter("@ContractNo", IIf(objLpoPpt.ContractID <> String.Empty, objLpoPpt.ContractID, DBNull.Value))
        Parms(2) = New SqlParameter("@LPODate", objLpoPpt.LPODate)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If objLpoPpt.Status <> "SELECT ALL" Then
            Parms(4) = New SqlParameter("@Status", objLpoPpt.Status)
        Else
            Parms(4) = New SqlParameter("@Status", System.DBNull.Value)
        End If
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Store].[STLPOViewGridDisp]", Parms)
        Return ds

    End Function

    Public Function LPORecordIsExist(ByVal objLPOPPT As LocalPurchaseOrderPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STLPORecordIsExist]", Parms)
        Return objExists
    End Function

    Public Shared Function AcctlookupSearch(ByVal objLPOPPT As LocalPurchaseOrderPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objLPOPPT.COACode <> "" And objLPOPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objLPOPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objLPOPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objLPOPPT.COACode <> "" And objLPOPPT.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objLPOPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objLPOPPT.COACode = "" And objLPOPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objLPOPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)
    End Function
    Public Function GetLPODetailsForReport(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(6) As SqlParameter
        Dim dt As New DataTable
        'If objIPRPPT.IPRNo <> "" Then
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@LPOdate", IIf(objLPOPPT.LPODate <> Nothing, objLPOPPT.LPODate, DBNull.Value)) 'objIPRPPT.IPRdate)
        params(2) = New SqlParameter("@LPONo", IIf(objLPOPPT.LPONo <> "", objLPOPPT.LPONo, DBNull.Value))
        params(3) = New SqlParameter("@StockCode", IIf(objLPOPPT.StockCode <> "", objLPOPPT.StockCode, DBNull.Value))
        params(4) = New SqlParameter("@StockID", IIf(objLPOPPT.StockID <> "", objLPOPPT.StockID, DBNull.Value))
        params(5) = New SqlParameter("@Status", IIf(objLPOPPT.Status <> "", objLPOPPT.Status, DBNull.Value))
        params(6) = New SqlParameter("@ActiveMonthYearID", IIf(GlobalPPT.strActMthYearID <> "", GlobalPPT.strActMthYearID, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[LPOViewSearchForReport]", params).Tables(0)
        Return dt
    End Function

    Public Function DeleteMultiEntryLPO(ByVal ObjLPOPPT As LocalPurchaseOrderPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter

        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STLPODetID", ObjLPOPPT.STLPODetID)

        rowsAffected = objdb.ExecNonQuery("[Store].[STLPODetailDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function

    Public Shared Function StockCategorySearch(ByVal CategorySearch As String) As DataTable

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STCategoryDescp", CategorySearch)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[STCategorySearchAndSelectForSIV]", Parms).Tables(0)

        Return dt

    End Function



End Class
