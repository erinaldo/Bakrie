'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Minggu, 13 Sep 2009, 13:20
' Place     : Kuala Lumpur  




Imports CheckRoll_PPT
Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT
Public Class PremiTargetDAL
    Private Shared _selectCommand As SqlCommand = Nothing
    Private Shared _insertCommand As SqlCommand = Nothing
    Private Shared _updateCommand As SqlCommand = Nothing
    Private Shared _deleteCommand As SqlCommand = Nothing
    Private Shared objdb As New SQLHelp
    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = New SqlConnection()
    Private Shared connString As String
    Private _trans As SqlTransaction
    Private _isTran As Boolean

    Public Sub New()
        connString = Common_PPT.GlobalPPT.ConnectionString
        _conn.ConnectionString = connString


    End Sub
    Private ReadOnly Property Adapter() As SqlDataAdapter
        Get
            If (Me._adapter Is Nothing) Then
                InitAdapter()
            End If
            Return Me._adapter
        End Get

    End Property
    Private Sub InitAdapter()


        ' ''---------
        ' ''Insert(Command)
        Me._adapter = New SqlDataAdapter()
        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.TargetDetailInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReceptionTargetSumryID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "ReceptionTargetSumryID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionDetID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "GangMasterID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MandoreID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@KraniID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "KraniID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Activity", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Activity", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RDate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "RDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalLooseFruits", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalLooseFruits", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalTonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalTonnage", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Kamis, 11 Mar 2010, 16:33
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "TotalBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Kamis, 11 Mar 2010, 16:33
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalBoronganValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalBoronganValue", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches6", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches6", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue6", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue6", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches7", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches7", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue7", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue7", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches8", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches8", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue8", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue8", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches9", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches9", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue9", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue9", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TBunches10", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches10", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TValue10", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue10", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruit1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruit2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruit3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruit4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruit5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnage1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnageValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnage2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnageValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnage3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnageValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnage4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnageValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnage5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TTonnageValue5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------
        ''Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.TargetDetailUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        ''Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReceptionTargetSumryID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "ReceptionTargetSumryID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "GangMasterID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MandoreID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@KraniID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "KraniID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Activity", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Activity", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RDate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "RDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalLooseFruits", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalLooseFruits", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalTonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalTonnage", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Kamis, 11 Mar 2010, 16:33
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "TotalBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Kamis, 11 Mar 2010, 16:33
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalBoronganValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalBoronganValue", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches6", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches6", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue6", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue6", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches7", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches7", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue7", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue7", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches8", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches8", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue8", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue8", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches9", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches9", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue9", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue9", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TBunches10", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TBunches10", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TValue10", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TValue10", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruit1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruit2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruit3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruit4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruit5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruit5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLooseFruitValue5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TLooseFruitValue5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnage1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnageValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnage2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnageValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnage3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnageValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnage4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnageValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnage5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnage5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TTonnageValue5", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TTonnageValue5", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Dim sqlparm As New SqlParameter
        'sqlparm = Adapter.UpdateCommand.Parameters.Add("@TLooseFruit5", SqlDbType.NChar, 50)
        'sqlparm.SourceColumn = "TLooseFruit5"
        'sqlparm.SourceVersion = DataRowVersion.Current
        'sqlparm.Value = 666

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.TargetDetailDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure
        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@ReceptionTargetSumryID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ReceptionTargetSumryID", DataRowVersion.Current, False, DataRowVersion.Current, "", "", ""))

    End Sub
    Private Sub InitConnection()
        Me._conn = New SqlConnection()
        Me._conn.ConnectionString = GlobalPPT.ConnectionString
    End Sub
    Private Property Connection() As SqlConnection
        Get
            If Me._conn Is Nothing Then
                InitConnection()
            End If
            Return _conn
        End Get

        Set(ByVal value As SqlConnection)
            Me._conn = value

            If Not Me.Adapter.SelectCommand Is Nothing Then
                Me.Adapter.SelectCommand.Connection = value
            End If

            If Not Me.Adapter.InsertCommand Is Nothing Then
                Me.Adapter.InsertCommand.Connection = value
            End If

            If Not Me.Adapter.UpdateCommand Is Nothing Then
                Me.Adapter.UpdateCommand.Connection = value
            End If

        End Set
    End Property
    Public Overridable Overloads Function Update(ByVal dataTable As Global.System.Data.DataTable) As Integer
        Try
            If _conn.State = ConnectionState.Closed Then
                _conn.Open()
                _trans = _conn.BeginTransaction
                Me.Adapter.InsertCommand.Transaction = _trans
                Me.Adapter.UpdateCommand.Transaction = _trans
                Me.Adapter.DeleteCommand.Transaction = _trans
                Me.Adapter.Update(dataTable)
                _trans.Commit()
            End If
        Catch ex As Exception
            _trans.Rollback()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
        End Try
        _conn.Close()

    End Function
    Public Shared Function TargetDetailView(ByVal GangMasterID As String, ByVal MandoreID As String, _
                                            ByVal KraniID As String, ByVal BlockId As String, _
                                            ByVal Empid As String, ByVal RDate As Date) As DataTable
        Dim params(6) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@GangMasterID", GangMasterID)
        params(1) = New SqlParameter("@MandoreID", MandoreID)
        params(2) = New SqlParameter("@KraniID", KraniID)
        params(3) = New SqlParameter("@BlockId", BlockId)
        params(4) = New SqlParameter("@Empid", Empid)
        params(5) = New SqlParameter("@RDate", RDate)
        params(6) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[TargetDetailView]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function TargetDetailDelete(ByVal ReceptionTargetSumryID As String) As Integer
        Dim params(0) As SqlParameter
        Dim dt As New Integer
        params(0) = New SqlParameter("@ReceptionTargetSumryID", ReceptionTargetSumryID)
        dt = objdb.ExecNonQuery("[Checkroll].[TargetDetailDelete]", params)
        Return dt
    End Function

    Public Shared Function DailyReceiptionDetIDDelete(ByVal DailyReceiptionDetID As String) As Integer
        Dim params(0) As SqlParameter
        Dim dt As New Integer
        params(0) = New SqlParameter("@DailyReceiptionDetID", DailyReceiptionDetID)
        dt = objdb.ExecNonQuery("[Checkroll].[CRDailyReceptionDelete]", params)
        Return dt
    End Function


End Class
