'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 3 Sep 2009, 13:20
' Place     : Kuala Lumpur  
'
'Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT
Public Class OTDetailDAL
    Private Shared _selectCommand As SqlCommand = Nothing
    Private Shared _insertCommand As SqlCommand = Nothing
    Private Shared _updateCommand As SqlCommand = Nothing
    Private Shared _deleteCommand As SqlCommand = Nothing
    Private Shared objdb As New SQLHelp
    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = New SqlConnection()
    Private _trans As SqlTransaction
    Private _isTran As Boolean
    Private Shared connString As String

    Public Sub New()
        connString = Common_PPT.GlobalPPT.ConnectionString
        _conn.ConnectionString = connString

        'adapter.SelectCommand = selectCommand
        'adapter.InsertCommand = insertCommand
        'adapter.UpdateCommand = updateCommand
        'adapter.DeleteCommand = deleteCommand

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
        'Insert(Command)
        Me._adapter = New SqlDataAdapter()
        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.OTDetailInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTSummaryID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "OTSummaryID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "GangMasterID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Activity", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Activity", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MandoreID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@KraniID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "KraniID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ADate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "ADate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OT1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OT2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OT3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OT4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        '---------
        'Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.OTDetailUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTSummaryID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "OTSummaryID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "GangMasterID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Activity", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Activity", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MandoreID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@KraniID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "KraniID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ADate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "ADate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OT1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTValue1", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OT2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTValue2", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OT3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTValue3", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OT4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTValue4", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTValue4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.OTDetailDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure
        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@OTSummaryID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OTSummaryID", DataRowVersion.Current, False, Nothing, "", "", ""))
        
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
        Dim nilai As Integer
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
        Return nilai
    End Function
    Public Shared Function OTDetailView(ByVal MandoreID As String, ByVal KraniID As String, ByVal EmpID As String, ByVal Adate As Date) As DataTable
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@MandoreID", MandoreID)
        params(1) = New SqlParameter("@KraniID", KraniID)
        params(2) = New SqlParameter("@EmpID", EmpID)
        params(3) = New SqlParameter("@Adate", Adate)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[OTDetailView]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function OTDetailViewTeam(ByVal MandoreID As String, ByVal KraniID As String, ByVal Adate As Date) As DataTable
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@MandoreID", MandoreID)
        params(1) = New SqlParameter("@KraniID", KraniID)
        params(2) = New SqlParameter("@Adate", Adate)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[OTDetailViewTeam]", params).Tables(0)
        Return dt
    End Function


    Public Shared Sub OTDetailInsertProcess(OTSummaryID As String, GangMasterID As String, Activity As String, MandoreID As String, KraniID As String, ADate As Date, _
                             EmpID As String, OT1 As Double, OTValue1 As Double, OT2 As Double, OTValue2 As Double, _
                             OT3 As Double, OTValue3 As Double, OT4 As Double, OTValue4 As Double, ActiveMonthYearId As String)
        Dim params(21) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@OTSummaryID", OTSummaryID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@ActiveMonthYearID", ActiveMonthYearId)
        params(4) = New SqlParameter("@GangMasterID", GangMasterID)
        params(5) = New SqlParameter("@Activity", Activity)
        params(6) = New SqlParameter("@MandoreID", MandoreID)
        params(7) = New SqlParameter("@KraniID", KraniID)
        params(8) = New SqlParameter("@ADate", ADate)
        params(9) = New SqlParameter("@EmpID", EmpID)
        params(10) = New SqlParameter("@OT1", OT1)
        params(11) = New SqlParameter("@OTValue1", OTValue1)
        params(12) = New SqlParameter("@OT2", OT2)
        params(13) = New SqlParameter("@OTValue2", OTValue2)
        params(14) = New SqlParameter("@OT3", OT3)
        params(15) = New SqlParameter("@OTValue3", OTValue3)
        params(16) = New SqlParameter("@OT4", OT4)
        params(17) = New SqlParameter("@OTValue4", OTValue4)
        params(18) = New SqlParameter("@CreatedOn", DateAndTime.Now)
        params(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        params(20) = New SqlParameter("@ModifiedOn", DateAndTime.Now)
        params(21) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        objdb.ExecQuery("[Checkroll].[OTDetailInsert]", params)
        'Return dt

    End Sub



    Public Shared Function GetOTRicePrice() As DataTable

        Dim adapter As New SQLHelp
        Dim DT As DataTable
        Dim params(0) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        DT = adapter.ExecQuery("[Checkroll].[GETOTRicePrice]", params).Tables(0)
        Return DT
    End Function
End Class
