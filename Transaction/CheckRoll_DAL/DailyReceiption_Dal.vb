'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Minggu, 13 Sep 2009, 13:20
' Place     : Kuala Lumpur  
'
Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT

Public Class DailyReceiption_Dal

    Private Shared _selectCommand As SqlCommand = Nothing
    Private Shared _insertCommand As SqlCommand = Nothing
    Private Shared _updateCommand As SqlCommand = Nothing
    Private Shared _deleteCommand As SqlCommand = Nothing

    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = New SqlConnection()
    Private Shared connString As String
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
        'Set(ByVal value As SqlDataAdapter)

        'End Set
    End Property

    Private Sub InitAdapter()


        ' ''---------
        ' ''Insert(Command)

        Me._adapter = New SqlDataAdapter()
        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyAttendReceiptionInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure




        'Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Daily Receiption Det ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Daily Receiption ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate Code", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTHours", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OT Hours", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Station ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Div ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOP ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Block ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IsDrivePremi", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Is Drive Premi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Tonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Tonnage", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Created By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Created On", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''---------
        'Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyAttendReceiptionUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure


        'Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Daily Receiption Det ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTHours", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OT Hours", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Station ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Div ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOP ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Block ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsDrivePremi", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Is Drive Premi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyAttendReceiptionDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Daily Receiption Det ID", DataRowVersion.Current, False, Nothing, "", "", ""))


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
    Private Sub InitSelectCommand()
        _selectCommand = New SqlCommand()
        _selectCommand.Connection = Me.Connection()
        _selectCommand.CommandText = "Checkroll.CR_SelectCensusByDate"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter = New SqlParameter()

        param = _selectCommand.Parameters.Add("@CensusStartDate", SqlDbType.Date, 3)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@CensusEndDate", SqlDbType.Date, 3)
        param.Direction = ParameterDirection.Input

    End Sub
    Private ReadOnly Property SelectCommand() As SqlCommand
        Get
            If _selectCommand Is Nothing Then
                InitSelectCommand()
            End If

            Return _selectCommand
        End Get
    End Property
    Public Overridable Overloads Function Update(ByVal dataTable As Global.System.Data.DataTable) As Integer
        Return Me.Adapter.Update(dataTable)
    End Function
    Public Shared Function getSubBlock(ByVal BlockName As String) As DataTable
        Dim DT_SUBBLOCK As DataTable = New DataTable

        Dim connString As String = _
                    Common_PPT.GlobalPPT.ConnectionString

        Dim conn As SqlConnection = New SqlConnection(connString)

        Dim param As SqlParameter = New SqlParameter()
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()

        conn.Open()

        selectCommand.Connection = conn
        selectCommand.CommandType = CommandType.StoredProcedure
        selectCommand.CommandText = "Checkroll.CRDailyAttendance_SelectSUBBLOCK"

        selectCommand.Parameters.Add("@BlockName", SqlDbType.NVarChar).Value = BlockName
        ' ini akan mengembalikan fields:
        ' BlockID, BlockName,
        ' YOPID, YOP,
        ' EstateID, EstateName,
        ' DivID, DivName

        adapter.SelectCommand = selectCommand
        adapter.Fill(DT_SUBBLOCK)

        Return DT_SUBBLOCK
    End Function
End Class

