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

Public Class AllowanceDeduction_Dal
    Private Shared _selectCommand As SqlCommand = Nothing
    Private Shared _insertCommand As SqlCommand = Nothing
    Private Shared _updateCommand As SqlCommand = Nothing
    Private Shared _deleteCommand As SqlCommand = Nothing
    Private Shared objdb As New SQLHelp
    Private _adapter As SqlDataAdapter
    Private _trans As SqlTransaction
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
        
    End Property
    Private Sub InitAdapter()

        '---------
        'Insert(Command)

        Me._adapter = New SqlDataAdapter()
        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.EmpAllowanceDeductionInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure
        '
        'Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpAllowDedID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Emp Allow Ded ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate Code", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Employee ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AllowDedID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Allow Ded ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Type", SqlDbType.Char, 1, ParameterDirection.Input, 0, 0, "Type", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StartDate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "Start Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EndDates", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "End Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Created By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Created On", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''---------
        ' ''Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.EmpAllowanceDeductionUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        ' ''Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpAllowDedID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Emp Allow Ded ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Employee ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AllowDedID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Allow Ded ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Type", SqlDbType.Char, 1, ParameterDirection.Input, 0, 0, "Type", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StartDate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "Start Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EndDates", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "End Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        '------------------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.EmpAllowanceDeductionDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@EmpAllowDedID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Emp Allow Ded ID", DataRowVersion.Current, False, Nothing, "", "", ""))


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
    Public Shared Function EmpAllowanceDeductionisSelect(ByVal EmpAllowDedID As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EmpAllowDedID", EmpAllowDedID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[EmpAllowanceDeductionisSelect]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function EmpAllowanceDeductionisView(ByVal StartDate As String, ByVal EndDate As String, ByVal EmpId As String, ByVal AllowDedID As String) As DataTable
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@StartDate", Convert.ToDateTime(StartDate).ToString("yyyyMMdd"))
        params(1) = New SqlParameter("@EndDate", Convert.ToDateTime(EndDate).ToString("yyyyMMdd"))
        params(2) = New SqlParameter("@EmpId", EmpId)
        params(3) = New SqlParameter("@AllowDedID", AllowDedID)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Checkroll].[EmpAllowanceDeductionisView]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function EmpAllowanceDeductionisExist(ByVal StartDate As String, ByVal EndDate As String, ByVal EmpId As String, ByVal Type As String) As DataTable
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@StartDate", StartDate)
        params(1) = New SqlParameter("@EndDate", EndDate)
        params(2) = New SqlParameter("@EmpId", EmpId)
        params(3) = New SqlParameter("@Type", Type)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[EmpAllowanceDeductionisExist]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRAllowanceDeductionSetupIsExist(ByVal AllowDedCode As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@AllowDedCode", AllowDedCode)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRAllowanceDeductionSetupIsExist]", params).Tables(0)
        Return dt
    End Function


    Public Shared Function RateSetupAddConfigurable(ByVal AllowDedCode As String) As Boolean
          Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@AllowDedCode", AllowDedCode)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[RateSetupAddConfigurableIsExist]", params).Tables(0)
        Return dt.Rows.Count <> 0
    End Function
End Class
