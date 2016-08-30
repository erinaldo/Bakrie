' Created   : Senin, 7 Sep 2009, 01:09 dinihari

'
Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT

Public Class ActivityDistribution_DAL
    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = New SqlConnection()
    Private Shared connString As String

    Public Sub New()
        connString = Common_PPT.GlobalPPT.ConnectionString
        _conn.ConnectionString = connString

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

            If Not Me._adapter.SelectCommand Is Nothing Then
                Me.Adapter.SelectCommand.Connection = value
            End If
        End Set
    End Property

    Private Sub InitAdapter()
        Me._adapter = New SqlDataAdapter()

        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Connection
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure
        Me._adapter.InsertCommand.CommandText = "[Checkroll].[DailyActivityDistributionInsert]"

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DistbDate", SqlDbType.Date, 3, ParameterDirection.Input, 0, 0, "DistbDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContractID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ContractID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActivityID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActivityID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StationID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T0", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T0", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T1", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T2", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T3", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T4", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Mandays", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "HK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Ha", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Prestasi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@VHID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "VHID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Round", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "Round", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
        Me._adapter.UpdateCommand.CommandText = "[Checkroll].[DailyActivityDistributionUpdate]"

        'Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DistbDate", SqlDbType.Date, 3, ParameterDirection.Input, 0, 0, "DistbDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContractID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ContractID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@COAID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "COA ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StationID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T0", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T0", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T1", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T2", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T3", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T4", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Mandays", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "HK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Ha", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Prestasi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VHID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "VHID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Round", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "Round", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

    End Sub

    Private ReadOnly Property Adapter() As SqlDataAdapter
        Get
            If Me._adapter Is Nothing Then
                InitAdapter()
            End If
            Return Me._adapter
        End Get
    End Property
End Class
