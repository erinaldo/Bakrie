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
Public Class Salary_DAL
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

        '------------------
        'Insert(Command)
        '------------------
        'Me._adapter = New SqlDataAdapter()
        'Me._adapter.InsertCommand = New SqlCommand()
        'Me._adapter.InsertCommand.Connection = Me.Connection
        'Me._adapter.InsertCommand.CommandText = "Checkroll.DailyMaterialInsert"
        'Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        ''Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MaterialUsageID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Material Usage ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate Code", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Active Month Year ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Daily Distribution ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@STIssueID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "St Issue ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SivNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Siv No", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Stock Id", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IssuedQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Issued Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UsageQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Usage Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Created By", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Created On", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''-----------------
        ' ''Update(Command)
        '------------------
        'Me._adapter.UpdateCommand = New SqlCommand()
        'Me._adapter.UpdateCommand.Connection = Me.Connection
        'Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyMaterialUpdate"
        'Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        ' ''Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MaterialUsageID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Material Usage ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Active Month Year ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Daily Distribution ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@STIssueID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "St Issue ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SivNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Siv No", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Stock Id", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IssuedQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Issued Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UsageQty", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Usage Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------------
        'Delete(Command)
        '---------------
        'Me._adapter.DeleteCommand = New SqlCommand()
        'Me._adapter.DeleteCommand.Connection = Connection
        'Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyMaterialDelete"
        'Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@MaterialUsageID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Material Usage Id", DataRowVersion.Current, False, Nothing, "", "", ""))


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
    Public Shared Function SalaryNikSelect(ByVal EstateID As String, ByVal Status As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", EstateID)
        params(1) = New SqlParameter("@Status", Status)
        dt = objdb.ExecQuery("[Checkroll].[SalaryNikSelect]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRSalaryFiscalYearSelect(ByVal Period As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Period", Period)
        dt = objdb.ExecQuery("[Checkroll].[CRSalaryFiscalYearSelect]", params).Tables(0)
        Return dt
    End Function

End Class
