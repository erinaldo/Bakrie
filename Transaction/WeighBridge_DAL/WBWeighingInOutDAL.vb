Imports WeighBridge_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class WBWeighingInOutDAL

    Public Function WBTicketNo_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If objWBWeighingInOutPPT.Others = True Then
            Parms(1) = New SqlParameter("@Others", 1)
        Else
            Parms(1) = New SqlParameter("@Others", 0)
        End If

        dt = objdb.ExecQuery("[Weighbridge].[WBTicketNoSelect_N]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBTicketNo_isExist(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@WBTicketNo", objWBWeighingInOutPPT.WBTicketNo)
        Parms(3) = New SqlParameter("@Others", objWBWeighingInOutPPT.Others)
        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBTicketNoRecord_isExist(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", objWBWeighingInOutPPT.WeighingID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutRecordIsExist]", Parms)
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                End If
            End If
        End If
        Return dt
    End Function

    Public Function Save_WBWeighingInOut(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(22) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@WeighingDate", objWBWeighingInOutPPT.WeighingDate)
        Parms(4) = New SqlParameter("@WeighingTime", objWBWeighingInOutPPT.WeighingTime)
        Parms(5) = New SqlParameter("@Section", objWBWeighingInOutPPT.Section)
        Parms(6) = New SqlParameter("@Others", objWBWeighingInOutPPT.Others)
        Parms(7) = New SqlParameter("@WBTicketNo", objWBWeighingInOutPPT.WBTicketNo)
        Parms(8) = New SqlParameter("@FFBDeliveryOrderNo", objWBWeighingInOutPPT.FFBDeliveryOrderNo)
        Parms(9) = New SqlParameter("@SupplierDetID", IIf(objWBWeighingInOutPPT.SupplierDetID <> String.Empty, objWBWeighingInOutPPT.SupplierDetID, DBNull.Value))
        Parms(10) = New SqlParameter("@SupplierCustID", IIf(objWBWeighingInOutPPT.SupplierCustID <> String.Empty, objWBWeighingInOutPPT.SupplierCustID, DBNull.Value))
        Parms(11) = New SqlParameter("@ProductID", IIf(objWBWeighingInOutPPT.ProductID <> String.Empty, objWBWeighingInOutPPT.ProductID, DBNull.Value))
        'Parms(12) = New SqlParameter("@VehicleCode", objWBWeighingInOutPPT.VehicleCode)
        'Parms(13) = New SqlParameter("@ProductCode", objWBWeighingInOutPPT.ProductCode)
        Parms(12) = New SqlParameter("@DriverName", objWBWeighingInOutPPT.DriverName)
        Parms(13) = New SqlParameter("@NoTrip", objWBWeighingInOutPPT.NoTrip)
        Parms(14) = New SqlParameter("@FirstWeight", IIf(objWBWeighingInOutPPT.FirstWeight <> Nothing, objWBWeighingInOutPPT.FirstWeight, DBNull.Value))
        Parms(15) = New SqlParameter("@SecondWeight", IIf(objWBWeighingInOutPPT.SecondWeight <> Nothing, objWBWeighingInOutPPT.SecondWeight, DBNull.Value))
        Parms(16) = New SqlParameter("@NetWeight", IIf(objWBWeighingInOutPPT.NetWeight <> Nothing, objWBWeighingInOutPPT.NetWeight, DBNull.Value))
        Parms(17) = New SqlParameter("@ManualWeight", objWBWeighingInOutPPT.ManualWeight)
        Parms(18) = New SqlParameter("@Remarks", objWBWeighingInOutPPT.Remarks)
        Parms(19) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(20) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(21) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(22) = New SqlParameter("@ModifiedOn", DateTime.Now)

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutInsert]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Update_WBWeighingInOut(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim rowsaffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(25) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(4) = New SqlParameter("@WeighingDate", objWBWeighingInOutPPT.WeighingDate)
            Parms(5) = New SqlParameter("@WeighingTime", objWBWeighingInOutPPT.WeighingTime)
            Parms(6) = New SqlParameter("@Section", objWBWeighingInOutPPT.Section)
            Parms(7) = New SqlParameter("@Others", objWBWeighingInOutPPT.Others)
            Parms(8) = New SqlParameter("@WBTicketNo", objWBWeighingInOutPPT.WBTicketNo)
            Parms(9) = New SqlParameter("@FFBDeliveryOrderNo", objWBWeighingInOutPPT.FFBDeliveryOrderNo)
            Parms(10) = New SqlParameter("@SupplierDetID", IIf(objWBWeighingInOutPPT.SupplierDetID <> String.Empty, objWBWeighingInOutPPT.SupplierDetID, DBNull.Value))
            Parms(11) = New SqlParameter("@SupplierCustID", IIf(objWBWeighingInOutPPT.SupplierCustID <> String.Empty, objWBWeighingInOutPPT.SupplierCustID, DBNull.Value))
            Parms(12) = New SqlParameter("@ProductID", IIf(objWBWeighingInOutPPT.ProductID <> String.Empty, objWBWeighingInOutPPT.ProductID, DBNull.Value))
            Parms(13) = New SqlParameter("@VehicleCode", objWBWeighingInOutPPT.VehicleCode)
            Parms(14) = New SqlParameter("@ProductCode", objWBWeighingInOutPPT.ProductCode)
            Parms(15) = New SqlParameter("@DriverName", objWBWeighingInOutPPT.DriverName)
            Parms(16) = New SqlParameter("@NoTrip", objWBWeighingInOutPPT.NoTrip)
            Parms(17) = New SqlParameter("@FirstWeight", IIf(objWBWeighingInOutPPT.FirstWeight <> Nothing, objWBWeighingInOutPPT.FirstWeight, DBNull.Value))
            Parms(18) = New SqlParameter("@SecondWeight", IIf(objWBWeighingInOutPPT.SecondWeight <> Nothing, objWBWeighingInOutPPT.SecondWeight, DBNull.Value))
            Parms(19) = New SqlParameter("@NetWeight", IIf(objWBWeighingInOutPPT.NetWeight <> Nothing, objWBWeighingInOutPPT.NetWeight, DBNull.Value))
            Parms(20) = New SqlParameter("@ManualWeight", objWBWeighingInOutPPT.ManualWeight)
            Parms(21) = New SqlParameter("@Remarks", objWBWeighingInOutPPT.Remarks)
            Parms(22) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(23) = New SqlParameter("@ModifiedOn", DateTime.Now)
            Parms(24) = New SqlParameter("@TimeOut", objWBWeighingInOutPPT.TimeOut)
            Parms(25) = New SqlParameter("@FFBDeduction", objWBWeighingInOutPPT.FFBDeduction)


            objdb.ExecNonQuery("[Weighbridge].[WBWeighingInOutUpdate]", Parms)
            rowsaffected = 1
        Catch ex As Exception
            rowsaffected = 0
        End Try
        Return rowsaffected
    End Function

    Public Function WeighingID_isExistInGradingFFB(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutIsExistInGradingFFB]", Parms).Tables(0)
        Return dt
    End Function


    Public Function Delete_WBWeighingInOut(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim objdb As New SQLHelp
        Dim rowaffected As Integer = 0
        Dim Parms(3) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@WBTicketNo", objWBWeighingInOutPPT.WBTicketNo)

            objdb.ExecQuery("[Weighbridge].[WBWeighingInOutDelete]", Parms)
            rowaffected = 1
        Catch ex As Exception
            rowaffected = 0
        End Try
        Return rowaffected
    End Function

    Public Function Save_WBWeighingBlockDetail(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        'Dim rowsaffected As Integer = 0
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@Division", objWBWeighingInOutPPT.Division)
        Parms(4) = New SqlParameter("@YOP", objWBWeighingInOutPPT.YOP)
        Parms(5) = New SqlParameter("@Block", objWBWeighingInOutPPT.Block)
        Parms(6) = New SqlParameter("@Qty", objWBWeighingInOutPPT.QtyFFB)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", DateTime.Now)
        Parms(11) = New SqlParameter("@FieldBlockSetupID", objWBWeighingInOutPPT.FieldBlockSetupID)
        Parms(12) = New SqlParameter("@LooseFruit", objWBWeighingInOutPPT.Loosefruit)
        Parms(13) = New SqlParameter("@TPH", objWBWeighingInOutPPT.TPH)
        Parms(14) = New SqlParameter("@Ketek", objWBWeighingInOutPPT.Ketek)


        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingBlockDetailInsert]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Update_WBWeighingBlockDetail(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim rowsaffected As Integer = 0
        'Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@WeighingBlockID", objWBWeighingInOutPPT.WeighingBlockID)
            Parms(1) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@Division", IIf(objWBWeighingInOutPPT.Division <> String.Empty, objWBWeighingInOutPPT.Division, DBNull.Value))
            Parms(4) = New SqlParameter("@YOP", objWBWeighingInOutPPT.YOP)
            Parms(5) = New SqlParameter("@Block", objWBWeighingInOutPPT.Block)
            Parms(6) = New SqlParameter("@Qty", objWBWeighingInOutPPT.QtyFFB)
            Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(8) = New SqlParameter("@ModifiedOn", DateTime.Now)
            Parms(9) = New SqlParameter("@LooseFruit", objWBWeighingInOutPPT.Loosefruit)
            Parms(10) = New SqlParameter("@TPH", objWBWeighingInOutPPT.TPH)
            Parms(11) = New SqlParameter("@Ketek", objWBWeighingInOutPPT.Ketek)

            objdb.ExecQuery("[Weighbridge].[WBWeighingBlockDetailUpdate]", Parms)
            rowsaffected = 1
        Catch ex As Exception
            rowsaffected = 0
        End Try

        Return rowsaffected
    End Function

    Public Function Delete_WBWeighingBlockDetail(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As Integer
        Dim rowsaffected As Integer = 0
        'Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            objdb.ExecQuery("[Weighbridge].[WBWeighingBlockDetailDelete]", Parms)
            rowsaffected = 1
        Catch ex As Exception
            rowsaffected = 0
        End Try
        Return rowsaffected
    End Function

    Public Function NoofTrip_Get(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VHNo", objWBWeighingInOutPPT.VehicleCode)
        Parms(2) = New SqlParameter("@WeighingDate", objWBWeighingInOutPPT.WeighingDate)

        dt = objdb.ExecQuery("[Weighbridge].[WBNoofTrip]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBSupplier_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@SupplierCode", IIf(objWBWeighingInOutPPT.Supplier <> String.Empty, objWBWeighingInOutPPT.Supplier, DBNull.Value))
        Parms(2) = New SqlParameter("@SupplierCodeSearch", IIf(objWBWeighingInOutPPT.SupplierCodeSearch <> String.Empty, objWBWeighingInOutPPT.SupplierCodeSearch, DBNull.Value))
        Parms(3) = New SqlParameter("@SupplierNameSearch", IIf(objWBWeighingInOutPPT.SupplierNameSearch <> String.Empty, objWBWeighingInOutPPT.SupplierNameSearch, DBNull.Value))
        Parms(4) = New SqlParameter("@Company", IIf(objWBWeighingInOutPPT.Company <> String.Empty, objWBWeighingInOutPPT.Company, DBNull.Value))

        'If objWBWeighingInOutPPT.Supplier <> String.Empty Then
        '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        '    Parms(1) = New SqlParameter("@Supplier", objWBWeighingInOutPPT.Supplier)
        '    Parms(2) = New SqlParameter("@SupplierSearch", DBNull.Value)
        '    Parms(3) = New SqlParameter("@VehicleCode", DBNull.Value)
        '    Parms(4) = New SqlParameter("@VehicleCodeSearch", DBNull.Value)
        '    Parms(5) = New SqlParameter("@ProductCode", DBNull.Value)
        '    Parms(6) = New SqlParameter("@ProductCodeSearch", DBNull.Value)

        'ElseIf objWBWeighingInOutPPT.SupplierCodeSearch <> String.Empty Then
        '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        '    Parms(1) = New SqlParameter("@Supplier", DBNull.Value)
        '    Parms(2) = New SqlParameter("@SupplierSearch", objWBWeighingInOutPPT.SupplierCodeSearch) 'Textbox value
        '    Parms(3) = New SqlParameter("@VehicleCode", DBNull.Value)
        '    Parms(4) = New SqlParameter("@VehicleCodeSearch", DBNull.Value)
        '    Parms(5) = New SqlParameter("@ProductCode", DBNull.Value)
        '    Parms(6) = New SqlParameter("@ProductCodeSearch", DBNull.Value)
        'Else
        '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        '    Parms(1) = New SqlParameter("@Supplier", DBNull.Value)
        '    Parms(2) = New SqlParameter("@SupplierSearch", DBNull.Value)
        '    Parms(3) = New SqlParameter("@VehicleCode", DBNull.Value)
        '    Parms(4) = New SqlParameter("@VehicleCodeSearch", DBNull.Value)
        '    Parms(5) = New SqlParameter("@ProductCode", DBNull.Value)
        '    Parms(6) = New SqlParameter("@ProductCodeSearch", DBNull.Value)
        'End If

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutSupplierCodeGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBVehicleCode_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VehicleCode", IIf(objWBWeighingInOutPPT.VehicleCode <> String.Empty, objWBWeighingInOutPPT.VehicleCode, DBNull.Value))
        Parms(2) = New SqlParameter("@VehicleCodeSearch", IIf(objWBWeighingInOutPPT.VehicleCodeSearch <> String.Empty, objWBWeighingInOutPPT.VehicleCodeSearch, DBNull.Value))
        Parms(3) = New SqlParameter("@VehicleDescSearch", IIf(objWBWeighingInOutPPT.VehicleDescSearch <> String.Empty, objWBWeighingInOutPPT.VehicleDescSearch, DBNull.Value))

        'If objWBWeighingInOutPPT.VehicleCode <> String.Empty Then
        '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        '    Parms(1) = New SqlParameter("@Supplier", DBNull.Value)
        '    Parms(2) = New SqlParameter("@SupplierSearch", DBNull.Value)
        '    Parms(3) = New SqlParameter("@VehicleCode", objWBWeighingInOutPPT.VehicleCode)
        '    Parms(4) = New SqlParameter("@VehicleCodeSearch", DBNull.Value)
        '    Parms(5) = New SqlParameter("@ProductCode", DBNull.Value)
        '    Parms(6) = New SqlParameter("@ProductCodeSearch", DBNull.Value)

        'ElseIf objWBWeighingInOutPPT.VehicleCodeSearch <> String.Empty Then
        '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        '    Parms(1) = New SqlParameter("@Supplier", DBNull.Value)
        '    Parms(2) = New SqlParameter("@SupplierSearch", DBNull.Value)
        '    Parms(3) = New SqlParameter("@VehicleCode", DBNull.Value)
        '    Parms(4) = New SqlParameter("@VehicleCodeSearch", objWBWeighingInOutPPT.VehicleCodeSearch)'Textbox value
        '    Parms(5) = New SqlParameter("@ProductCode", DBNull.Value)
        '    Parms(6) = New SqlParameter("@ProductCodeSearch", DBNull.Value)
        'Else
        '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        '    Parms(1) = New SqlParameter("@Supplier", DBNull.Value)
        '    Parms(2) = New SqlParameter("@SupplierSearch", DBNull.Value)
        '    Parms(3) = New SqlParameter("@VehicleCode", DBNull.Value)
        '    Parms(4) = New SqlParameter("@VehicleCodeSearch", DBNull.Value)
        '    Parms(5) = New SqlParameter("@ProductCode", DBNull.Value)
        '    Parms(6) = New SqlParameter("@ProductCodeSearch", DBNull.Value)
        'End If
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutVehicleCodeGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBProductCode_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter
        'If objWBWeighingInOutPPT.ProductCode <> String.Empty Then
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductCode", IIf(objWBWeighingInOutPPT.ProductCode <> String.Empty, objWBWeighingInOutPPT.ProductCode, DBNull.Value))
        Parms(2) = New SqlParameter("@ProductCodeSearch", IIf(objWBWeighingInOutPPT.ProductCodeSearch <> String.Empty, objWBWeighingInOutPPT.ProductCodeSearch, DBNull.Value))
        Parms(3) = New SqlParameter("@ProductDescSearch", IIf(objWBWeighingInOutPPT.ProductDescSearch <> String.Empty, objWBWeighingInOutPPT.ProductDescSearch, DBNull.Value))

        'ElseIf objWBWeighingInOutPPT.ProductCodeSearch <> String.Empty Then
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ProductCode", DBNull.Value)
        'Parms(2) = New SqlParameter("@ProductCodeSearch", objWBWeighingInOutPPT.ProductCodeSearch) 'Textbox value
        'Parms(3) = New SqlParameter("@ProductDescSearch", DBNull.Value)
        'ElseIf objWBWeighingInOutPPT.ProductDescSearch <> String.Empty Then
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ''Parms(1) = New SqlParameter("@Supplier", DBNull.Value)
        ''Parms(2) = New SqlParameter("@SupplierSearch", DBNull.Value)
        ''Parms(3) = New SqlParameter("@VehicleCode", DBNull.Value)
        ''Parms(4) = New SqlParameter("@VehicleCodeSearch", DBNull.Value)
        'Parms(1) = New SqlParameter("@ProductCode", DBNull.Value)
        'Parms(2) = New SqlParameter("@ProductCodeSearch", DBNull.Value)
        ' End If

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutProductCodeGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOut_DivisionGet(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@SupplierCustID", objWBWeighingInOutPPT.SupplierCustID)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutDivisionGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOut_YOPGet(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Block", objWBWeighingInOutPPT.Block)
        Parms(2) = New SqlParameter("@SupplierCustID", objWBWeighingInOutPPT.SupplierCustID)

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutYOPGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOut_BlockGet(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@SupplierCustID", objWBWeighingInOutPPT.SupplierCustID)

        'Parms(1) = New SqlParameter("@Division", objWBWeighingInOutPPT.Division)
        'Parms(2) = New SqlParameter("@YOP", objWBWeighingInOutPPT.YOP)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutBlockGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOut_BlockGetII(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@SupplierCustID", objWBWeighingInOutPPT.SupplierCustID)
        Parms(2) = New SqlParameter("@ProductID", objWBWeighingInOutPPT.ProductID)

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutBlockGetII]", Parms).Tables(0)
        Return dt
    End Function

     Public Function WBWeighingInOut_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@WeighingDate", IIf(objWBWeighingInOutPPT.WeighingDate <> Nothing, objWBWeighingInOutPPT.WeighingDate, DBNull.Value))
        Parms(3) = New SqlParameter("@WBTicketNo", IIf(objWBWeighingInOutPPT.WBTicketNo <> String.Empty, objWBWeighingInOutPPT.WBTicketNo, DBNull.Value))
        Parms(4) = New SqlParameter("@VHNo", IIf(objWBWeighingInOutPPT.VehicleCode <> String.Empty, objWBWeighingInOutPPT.VehicleCode, DBNull.Value))
        'Parms(5) = New SqlParameter("@ProductCode", IIf(objWBWeighingInOutPPT.ProductCode <> String.Empty, objWBWeighingInOutPPT.ProductCode, DBNull.Value))
        Parms(5) = New SqlParameter("@ProductDescp", IIf(objWBWeighingInOutPPT.ProductDescSearch <> String.Empty, objWBWeighingInOutPPT.ProductDescSearch, DBNull.Value))
        Parms(6) = New SqlParameter("@Weight", objWBWeighingInOutPPT.Weight)
        Parms(7) = New SqlParameter("@NOTFBDetails", objWBWeighingInOutPPT.NOTFBDetails)
        'If objWBWeighingInOutPPT.Others = True Then
        '    Parms(6) = New SqlParameter("@Others", 1)
        'Else
        '    Parms(6) = New SqlParameter("@Others", 0)
        'End If

        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOutDetail_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutFBSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOutSecurity_Select(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@Usercode", objWBWeighingInOutPPT.Usercode)
        Parms(1) = New SqlParameter("@Password", objWBWeighingInOutPPT.Password)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingLogin]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBWeighingInOut_Reporting(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@WBTicketNo", objWBWeighingInOutPPT.WBTicketNo)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutReport]", Parms).Tables(0)
        Return dt
    End Function

    Public Function FiscalYearDate_Get(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@FYear", objWBWeighingInOutPPT.FYear)
        Parms(1) = New SqlParameter("@Period", objWBWeighingInOutPPT.Period)
        dt = objdb.ExecQuery("[Weighbridge].[RecapitulationFFBReportFiscalDate]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBTicket_Report(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingTicketReport]", Parms).Tables(0)
        Return dt
    End Function


    Public Function WBWeighingInOutDetail_GetRecord(ByVal objWBWeighingInOutPPT As WBWeighingInOutPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@WeighingID", objWBWeighingInOutPPT.WeighingID)
        dt = objdb.ExecQuery("[Weighbridge].[WBWeighingInOutDetail_GetRecord]", Parms).Tables(0)
        Return dt
    End Function

    Public Function WBTPH_Select(ByVal FieldBlockSetupID As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@FieldBlockSetupID", FieldBlockSetupID)
        dt = objdb.ExecQuery("[Weighbridge].[WBTPHSelect]", Parms).Tables(0)
        Return dt
    End Function


    Public Sub UpdateAllocatedWeightBlock(ByVal WeighingID As String)
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@WeighingID", WeighingID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objdb.ExecQuery("[Weighbridge].[UpdateAllocatedWeightBlock]", Parms)
    End Sub

End Class
