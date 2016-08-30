Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class EstateMillDeliverNoteDAL
    Public Function SearchIPRNo(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter
        If objEMDNPPT.IPRNo <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@IPRNo", objEMDNPPT.IPRNo) 'Textbox value
            Parms(3) = New SqlParameter("@IPRNoSearch", DBNull.Value)
        ElseIf objEMDNPPT.IPRNoSearch <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@IPRNo", DBNull.Value)
            Parms(3) = New SqlParameter("@IPRNoSearch", objEMDNPPT.IPRNoSearch) 'SearchTextbox value
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@IPRNo", DBNull.Value)
            Parms(3) = New SqlParameter("@IPRNoSearch", DBNull.Value)
        End If
        dt = objdb.ExecQuery("[Store].[IPRNoGET]", Parms).Tables(0)
        Return dt
    End Function

    Public Function SearchLPONo(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter
        If objEMDNPPT.LPONo <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@LPONo", objEMDNPPT.LPONo) 'Textbox value
            Parms(3) = New SqlParameter("@LPONoSearch", DBNull.Value)
        ElseIf objEMDNPPT.LPONoSearch <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@LPONo", DBNull.Value)
            Parms(3) = New SqlParameter("@LPONoSearch", objEMDNPPT.LPONoSearch) 'SearchTextbox value
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@LPONo", DBNull.Value)
            Parms(3) = New SqlParameter("@LPONoSearch", DBNull.Value)
        End If
        dt = objdb.ExecQuery("[Store].[STLPONoGET]", Parms).Tables(0)
        Return dt
    End Function

    Public Function SearchSupplier(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        If objEMDNPPT.SendersLocation <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", objEMDNPPT.SendersLocation) 'searching in sender location text leave.
            Parms(2) = New SqlParameter("@SenderLocationSearch", DBNull.Value) 'lookup search
        ElseIf objEMDNPPT.SendersLocationSearch = String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", DBNull.Value)
            Parms(2) = New SqlParameter("@SenderLocationSearch", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", DBNull.Value)
            Parms(2) = New SqlParameter("@SenderLocationSearch", objEMDNPPT.SendersLocationSearch)
        End If
        dt = objdb.ExecQuery("[Store].[STMillDeliverySupplierGET]", Parms).Tables(0)
        Return dt
    End Function

    Public Function STMillDeliveryIPRNoGet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Store].[STMillDeliveryIPRNoGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function STMillDeliveryLPONoGet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Store].[STMillDeliveryLPONoGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function STMillDeliveryPONoGet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Store].[STMillDeliveryPONoGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function IDNView_Select(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(12) As SqlParameter
        
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@IDNdate", IIf(objEMDNPPT.IDNDate <> Nothing, objEMDNPPT.IDNDate, DBNull.Value))
        Parms(2) = New SqlParameter("@IDNNo", IIf(objEMDNPPT.IDNNO <> "", objEMDNPPT.IDNNO, DBNull.Value))
        Parms(3) = New SqlParameter("@IPRNo", IIf(objEMDNPPT.IPRNo <> "", objEMDNPPT.IPRNo, DBNull.Value))
        Parms(4) = New SqlParameter("@LPONo", IIf(objEMDNPPT.LPONo <> "", objEMDNPPT.LPONo, DBNull.Value))
        Parms(5) = New SqlParameter("@TransType", IIf(objEMDNPPT.LPOorIPR <> "", objEMDNPPT.LPOorIPR, DBNull.Value))
        Parms(6) = New SqlParameter("@GRNNo", IIf(objEMDNPPT.GRNNo <> "", objEMDNPPT.GRNNo, DBNull.Value))
        Parms(7) = New SqlParameter("@PONo", IIf(objEMDNPPT.PONo <> "", objEMDNPPT.PONo, DBNull.Value))
        Parms(8) = New SqlParameter("@DeliverySource", IIf(objEMDNPPT.DeliverySource <> "", objEMDNPPT.DeliverySource, DBNull.Value))
        Parms(9) = New SqlParameter("@Supplier", IIf(objEMDNPPT.SupplierID <> "", objEMDNPPT.SupplierID, DBNull.Value))
        If objEMDNPPT.Status = "SELECT ALL" Then
            Parms(10) = New SqlParameter("@Status", DBNull.Value)
        Else
            Parms(10) = New SqlParameter("@Status", objEMDNPPT.Status)
        End If
        Parms(11) = New SqlParameter("@Flag", objEMDNPPT.Flag)
        Parms(12) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Store].[STMillDeliveryViewSelect]", Parms).Tables(0)
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Public Function GetIDNDetails_IPR(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter

        If objEMDNPPT.STIPRID <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STIPRID", objEMDNPPT.STIPRID)
            Parms(2) = New SqlParameter("@STLPOID", DBNull.Value)
            Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ElseIf objEMDNPPT.STLPOID <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STIPRID", DBNull.Value)
            Parms(2) = New SqlParameter("@STLPOID", objEMDNPPT.STLPOID)
            Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        End If

        dt = objdb.ExecQuery("[Store].[STIDNDetailsGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function IDNDetails_Select(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)

        dt = objdb.ExecQuery("[Store].[STIDNDetailSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function IDN_isExist(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@IDNNo", objEMDNPPT.IDNNO)
        Parms(1) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)
        Parms(2) = New SqlParameter("@GRNNo", IIf(objEMDNPPT.GRNNo <> String.Empty, objEMDNPPT.GRNNo, DBNull.Value))


        dt = objdb.ExecQuery("[Store].[STMillDeliveryIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Stock_isExist(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@STEstMillDeliveryDetID", IIf(objEMDNPPT.STEstMillDeliveryDetID <> "", objEMDNPPT.STEstMillDeliveryDetID, DBNull.Value))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@STEstMillDeliveryID", IIf(objEMDNPPT.STEstMillDeliveryDetID <> "", objEMDNPPT.STEstMillDeliveryID, DBNull.Value))
        Parms(3) = New SqlParameter("@StockID", objEMDNPPT.StockID)
        Parms(4) = New SqlParameter("@STLPODetID", IIf(objEMDNPPT.STLPODetID <> "", objEMDNPPT.STLPODetID, DBNull.Value))
        Parms(5) = New SqlParameter("@STIPRDetID", IIf(objEMDNPPT.STIPRDetID <> "", objEMDNPPT.STIPRDetID, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STEstMillDeliveryDetIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Save_STMillDelivery(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(21) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LPOorIPR", IIf(objEMDNPPT.IPRNo <> "", objEMDNPPT.IPRNo, objEMDNPPT.LPONo))
        Parms(3) = New SqlParameter("@IDNNo", objEMDNPPT.IDNNO)
        Parms(4) = New SqlParameter("@IDNDate", objEMDNPPT.IDNDate)
        Parms(5) = New SqlParameter("@GRNNo", objEMDNPPT.GRNNo)
        Parms(6) = New SqlParameter("@PONo", objEMDNPPT.PONo)
        Parms(7) = New SqlParameter("@STLPOID", IIf(objEMDNPPT.STLPOID <> String.Empty, objEMDNPPT.STLPOID, DBNull.Value)) 'objEMDNPPT.STLPOID)
        Parms(8) = New SqlParameter("@STIPRID", IIf(objEMDNPPT.STIPRID <> String.Empty, objEMDNPPT.STIPRID, DBNull.Value))
        Parms(9) = New SqlParameter("@DeliverySource", IIf(objEMDNPPT.DeliverySource <> String.Empty, objEMDNPPT.DeliverySource, DBNull.Value))
        Parms(10) = New SqlParameter("@Remarks", objEMDNPPT.Remarks)
        Parms(11) = New SqlParameter("@SupplierID", IIf(objEMDNPPT.SupplierID <> String.Empty, objEMDNPPT.SupplierID, DBNull.Value))
        Parms(12) = New SqlParameter("@Status", objEMDNPPT.Status)
        Parms(13) = New SqlParameter("@RejectedReason", IIf(objEMDNPPT.RejectedReason <> "", objEMDNPPT.RejectedReason, DBNull.Value))
        Parms(14) = New SqlParameter("@OperatorName", objEMDNPPT.OperatorName)
        Parms(15) = New SqlParameter("@TransportDate", objEMDNPPT.TransportDate)
        Parms(16) = New SqlParameter("@VehicleNo", objEMDNPPT.VehicleNo)
        Parms(17) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(18) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(20) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(21) = New SqlParameter("@ModifiedOn", Date.Today)

        dt = objdb.ExecQuery("[Store].[STMillDeliveryInsert_N]", Parms).Tables(0)
        Return dt

    End Function

    Public Function Update_STMillDelivery(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(19) As SqlParameter
        Try 
            Parms(0) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@LPOorIPR", IIf(objEMDNPPT.IPRNo <> "", objEMDNPPT.IPRNo, objEMDNPPT.LPONo))
            Parms(4) = New SqlParameter("@IDNNo", objEMDNPPT.IDNNO)
            Parms(5) = New SqlParameter("@IDNDate", objEMDNPPT.IDNDate)
            Parms(6) = New SqlParameter("@GRNNo", objEMDNPPT.GRNNo)
            Parms(7) = New SqlParameter("@PONo", objEMDNPPT.PONo)
            Parms(8) = New SqlParameter("@STLPOID", IIf(objEMDNPPT.STLPOID <> "", objEMDNPPT.STLPOID, DBNull.Value)) 'objEMDNPPT.STLPOID)
            Parms(9) = New SqlParameter("@STIPRID", IIf(objEMDNPPT.STIPRID <> "", objEMDNPPT.STIPRID, DBNull.Value))
            Parms(10) = New SqlParameter("@DeliverySource", objEMDNPPT.DeliverySource)
            Parms(11) = New SqlParameter("@Remarks", objEMDNPPT.Remarks)
            Parms(12) = New SqlParameter("@SupplierID", IIf(objEMDNPPT.SupplierID <> "", objEMDNPPT.SupplierID, DBNull.Value))
            Parms(13) = New SqlParameter("@Status", objEMDNPPT.Status)
            Parms(14) = New SqlParameter("@RejectedReason", IIf(objEMDNPPT.RejectedReason <> "", objEMDNPPT.RejectedReason, DBNull.Value))
            Parms(15) = New SqlParameter("@OperatorName", objEMDNPPT.OperatorName)
            Parms(16) = New SqlParameter("@TransportDate", objEMDNPPT.TransportDate)
            Parms(17) = New SqlParameter("@VehicleNo", objEMDNPPT.VehicleNo)
            Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(19) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STMillDeliveryUpdate_N]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function
  
    'Public Function STMillDeleivID_GetMax(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataTable
    '    Dim objdb As New SQLHelp
    '    Dim dt As New DataTable
    '    Dim Parms(1) As SqlParameter

    '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

    '    dt = objdb.ExecQuery("[Store].[STMillDeliveryIDGet]", Parms).Tables(0)
    '    Return dt
    'End Function

    Public Function Save_EstMillDeliveryDet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(19) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)
            Parms(2) = New SqlParameter("@STLPODetID", IIf(objEMDNPPT.STLPODetID <> "", objEMDNPPT.STLPODetID, DBNull.Value))
            Parms(3) = New SqlParameter("@STIPRDetID", IIf(objEMDNPPT.STIPRDetID <> "", objEMDNPPT.STIPRDetID, DBNull.Value))
            Parms(4) = New SqlParameter("@StockID", objEMDNPPT.StockID)
            Parms(5) = New SqlParameter("@PartNo", objEMDNPPT.PartNo)
            Parms(6) = New SqlParameter("@COAID", objEMDNPPT.COAID)
            Parms(7) = New SqlParameter("@AvailQty", objEMDNPPT.AvailQty)
            Parms(8) = New SqlParameter("@UnitPrice", objEMDNPPT.UnitPrice)
            Parms(9) = New SqlParameter("@T0", IIf(objEMDNPPT.T0 <> "", objEMDNPPT.T0, DBNull.Value))
            Parms(10) = New SqlParameter("@RequestedQty", objEMDNPPT.RequestedQty)
            Parms(11) = New SqlParameter("@ReceivedQty", objEMDNPPT.ReceivedQty)
            Parms(12) = New SqlParameter("@PendingQty", objEMDNPPT.PendingQty)
            Parms(13) = New SqlParameter("@ReceivedPrice", objEMDNPPT.ReceivedPrice)
            Parms(14) = New SqlParameter("@TotalPrice", objEMDNPPT.TotalPrice)
            Parms(15) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(16) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(17) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(19) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STEstMillDeliveryDetInsert_N]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Update_EstMillDeliveryDet(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(17) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STEstMillDeliveryDetID", objEMDNPPT.STEstMillDeliveryDetID)
            Parms(1) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@STLPODetID", IIf(objEMDNPPT.STLPODetID <> "", objEMDNPPT.STLPODetID, DBNull.Value))
            Parms(4) = New SqlParameter("@STIPRDetID", IIf(objEMDNPPT.STIPRDetID <> "", objEMDNPPT.STIPRDetID, DBNull.Value))
            Parms(5) = New SqlParameter("@StockID", objEMDNPPT.StockID)
            Parms(6) = New SqlParameter("@PartNo", objEMDNPPT.PartNo)
            Parms(7) = New SqlParameter("@COAID", objEMDNPPT.COAID)
            Parms(8) = New SqlParameter("@AvailQty", objEMDNPPT.AvailQty)
            Parms(9) = New SqlParameter("@UnitPrice", objEMDNPPT.UnitPrice)
            Parms(10) = New SqlParameter("@T0", IIf(objEMDNPPT.T0 <> "", objEMDNPPT.T0, DBNull.Value))
            Parms(11) = New SqlParameter("@RequestedQty", objEMDNPPT.RequestedQty)
            Parms(12) = New SqlParameter("@ReceivedQty", objEMDNPPT.ReceivedQty)
            Parms(13) = New SqlParameter("@PendingQty", objEMDNPPT.PendingQty)
            Parms(14) = New SqlParameter("@ReceivedPrice", objEMDNPPT.ReceivedPrice)
            Parms(15) = New SqlParameter("@TotalPrice", objEMDNPPT.TotalPrice)
            Parms(16) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(17) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STEstMillDeliveryDetUpdate_N]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Delete_STMillDeliveryDelete(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())

            objdb.ExecNonQuery("[Store].[STMillDeliveryDelete]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function
    Public Function EstMillDeliveryRecordIsExist(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STMillDeliveryRecordIsExist]", Parms)
        Return objExists
    End Function

   

End Class
