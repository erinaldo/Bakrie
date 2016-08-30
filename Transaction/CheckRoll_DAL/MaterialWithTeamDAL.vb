'////////////
'
'
' Programmer: Dadang Adi Hendradi
' Created   : Selasa, 27 Oct 2009, 14:42
' Place     : Kebun
'
'////////////

Imports CheckRoll_PPT
Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT
Imports System.Windows.Forms

Public Class MaterialWithTeamDAL

    Private Shared _selectCommand As SqlCommand = Nothing
    Private Shared _insertCommand As SqlCommand = Nothing
    Private Shared _updateCommand As SqlCommand = Nothing
    Private Shared _deleteCommand As SqlCommand = Nothing
    Private Shared objdb As New SQLHelp
    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection
    Private Shared connString As String
    Private _trans As SqlTransaction
    Private _isTran As Boolean

    'Public Sub New()
    '    connString = EncryptDAL.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings("BSP").ConnectionString())
    '    _conn.ConnectionString = connString


    'End Sub

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
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyMaterialInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MaterialUsageID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "MaterialUsageID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@STIssueID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "STIssueID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SivNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "SivNo", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IssuedQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "IssuedQty", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UsageQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "UsageQty", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------
        ''Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyMaterialUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        ''Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MaterialUsageID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "MaterialUsageID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@STIssueID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "STIssueID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SivNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "SivNo", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IssuedQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "IssuedQty", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UsageQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "UsageQty", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------
        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyMaterialDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@MaterialUsageID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MaterialUsageID", DataRowVersion.Current, False, Nothing, "", "", ""))


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
        Dim returnValue As Integer
        Dim connState As ConnectionState
        Dim trans As SqlTransaction

        connState = Me.Connection.State
        If connState = ConnectionState.Closed Then
            Me.Connection.Open()
        End If

        trans = Me.Connection.BeginTransaction()

        Try
            Me.Adapter.InsertCommand.Transaction = trans
            Me.Adapter.UpdateCommand.Transaction = trans
            Me.Adapter.DeleteCommand.Transaction = trans

            returnValue = Me.Adapter.Update(dataTable)

            trans.Commit()

            Me.Connection.Close()
            trans = Nothing

        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show(ex.Message())

        End Try

        Return returnValue
    End Function

    Public Shared Function DailyMaterialView(ByVal DailyDistributionID As String, ByVal Estateid As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@DailyDistributionID", DailyDistributionID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyMaterialView]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyMaterialIsSelect(ByVal MaterialUsageID As String, ByVal StockID As String, ByVal Estateid As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@MaterialUsageID", MaterialUsageID)
        params(1) = New SqlParameter("@StockID", StockID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyMaterialView]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CRActivityMaterialUsageWithTeamView( _
        ByVal DailyDistributionID As String) As DataTable
        ' Selasa, 27 Oct 2009, 15:26

        Dim DT
        Dim adapter As New SQLHelp()
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID
        params(1) = New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar)
        params(1).Value = DailyDistributionID

        DT = adapter.ExecQuery("[Checkroll].[CRActivityMaterialUsageWithTeamView]", params).Tables(0)

        Return DT
    End Function
End Class
