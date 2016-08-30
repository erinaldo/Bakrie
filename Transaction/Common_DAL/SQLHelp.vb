Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports Common_BOL
Imports Common_PPT.DatabaseMasterPPT
Imports Common_DAL.DatabaseMasterDAL
Imports System.Reflection

Public Class SQLHelp

    'Since this class provides only static methods, make the default constructor private to prevent 
    'instances from being created with "new SqlHelper()".

    Dim _cnnMyConnection As SqlConnection
    Dim _cmdSqlCommand As SqlCommand
    Dim _adpAdapter As SqlDataAdapter
    Dim _isTran As Boolean
    Private _trans As SqlTransaction
    Dim _connStr As String

    Public Function ConvertToObjectList(Of T)(ByVal table As DataTable) As List(Of T)
        Dim items As New List(Of T)

        For Each row As DataRow In table.Rows
            Dim obj As T = Activator.CreateInstance(GetType(T))
            Dim fields() As PropertyInfo = GetType(T).GetProperties()
            For Each field As PropertyInfo In fields

                Dim val As Object = Nothing
                Try
                    Dim propertyType As Type = If(Nullable.GetUnderlyingType(field.PropertyType) Is Nothing, field.PropertyType, Nullable.GetUnderlyingType(field.PropertyType))

                    Dim vv As Object  = row.Item(field.Name)

                    val = Convert.ChangeType(vv, propertyType)
                Catch ex As Exception
                    val = Nothing
                End Try
                field.SetValue(obj, val, Nothing)
            Next
            items.Add(obj)
        Next
        Return items
    End Function


    Private Function Connect() As Boolean
        Dim bln As Boolean
        If _cnnMyConnection Is Nothing Then
            bln = ReadDatabseConfig()
            If bln = True Then
                _cnnMyConnection = New SqlConnection(_connStr)
            End If
        ElseIf _cnnMyConnection.Database <> Common_PPT.GlobalPPT.SelectedDB.DBName Then
            _cnnMyConnection.Close()
            bln = ReadDatabseConfig()
            If bln = True Then
                _cnnMyConnection = New SqlConnection(_connStr)
            End If
        End If
        If _cnnMyConnection.State = ConnectionState.Closed Then
            _cnnMyConnection.Open()
        End If

        Exit Function

    End Function

    Public Sub BeginTransaction()

        If _isTran Then Return
        If _cnnMyConnection.State = ConnectionState.Closed Then
            _cnnMyConnection.Open()
        End If
        _trans = _cnnMyConnection.BeginTransaction()
        _isTran = True
    End Sub

    Public Sub CommitTransaction()
        If Not _isTran Then Return
        _trans.Commit()
        '_cnnMyConnection.Close()
        CloseConn()
        _trans = Nothing
        _isTran = False
    End Sub

    Public Sub RollBackTransaction()
        If Not _isTran Then Return
        _trans.Rollback()
        '_cnnMyConnection.Close()
        CloseConn()
        _trans = Nothing
        _isTran = False
    End Sub

    Public Sub CloseConn()
        If Not _cnnMyConnection Is Nothing Then
            If Not _cnnMyConnection.State = ConnectionState.Closed Then
                _cnnMyConnection.Close()
            End If
        End If
    End Sub



    '****************************************************************************************
    ' ExecQuery
    ' ABSTRACT: Executes a stored procedure against the database and returns
    '   a NEW Dataset with the selected data.
    '
    ' INPUT PARMS:  ProcedureName   Name of Stored Procedure to execute
    '               Parms           Array of SqlParameter objects that will be passed into the
    '                               stored procedure.
    '
    ' RETURNS:      DataSet populated with results from stored procedure execution.
    '
    '****************************************************************************************
    Public Overloads Function ExecQuery(ByVal ProcedureName As String, ByVal Parms As SqlParameter(), Optional isErrorShow As Boolean = True) As DataSet

        Try
            If _cnnMyConnection.State = ConnectionState.Closed Then
                Connect()
            End If

            Dim dsDataSet As New DataSet
            _cmdSqlCommand = New SqlCommand
            With _cmdSqlCommand
                _cmdSqlCommand.Connection = _cnnMyConnection
                _cmdSqlCommand.CommandTimeout = 1800
                .CommandType = CommandType.StoredProcedure      'Set type to StoredProcedure
                .CommandText = ProcedureName

                'Specify stored procedure to run
                ' Clear any previous parameters from the Command object
                Call .Parameters.Clear()

                ' Loop through parmameter collection adding parameters to the command object
                If Not (Parms Is Nothing) Then
                    For Each sqlParm As SqlParameter In Parms
                        _cmdSqlCommand.Parameters.Add(sqlParm)
                    Next
                End If
            End With

            BeginTransaction()

            If _isTran Then
                _cmdSqlCommand.Transaction = _trans
            End If
            ' Configure Adapter to use newly created command object and fill the dataset.
            _adpAdapter = New SqlDataAdapter(_cmdSqlCommand)
            _adpAdapter.Fill(dsDataSet)

            CommitTransaction()

            Return dsDataSet
        Catch ex As Exception
            RollBackTransaction()
            If isErrorShow Then
                MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
            End If
            Throw New Exception(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Overloads Function ExecQueryDataTable(ByVal ProcedureName As String, ByVal Parms As SqlParameter()) As DataTable

5:      Try
            If _cnnMyConnection.State = ConnectionState.Closed Then
                Connect()
            End If

            Dim dtDataTable As New DataTable
            _cmdSqlCommand = New SqlCommand
            With _cmdSqlCommand
                _cmdSqlCommand.Connection = _cnnMyConnection
                _cmdSqlCommand.CommandTimeout = 1800
                .CommandType = CommandType.StoredProcedure      'Set type to StoredProcedure
                .CommandText = ProcedureName                    'Specify stored procedure to run
                ' Clear any previous parameters from the Command object
                Call .Parameters.Clear()

                ' Loop through parmameter collection adding parameters to the command object
                If Not (Parms Is Nothing) Then
                    For Each sqlParm As SqlParameter In Parms
                        _cmdSqlCommand.Parameters.Add(sqlParm)
                    Next
                End If
            End With

            BeginTransaction()

            If _isTran Then
                _cmdSqlCommand.Transaction = _trans
            End If
            ' Configure Adapter to use newly created command object and fill the dataset.
            'Dim dr As SqlDataReader
            'dr = _cmdSqlCommand.ExecuteReader()

            'While dr.Read()
            Dim obj As New Object
            obj = _cmdSqlCommand.ExecuteReader
            'dtDataTable.Load(dr)
            'End While
            '_adpAdapter = New SqlDataAdapter(_cmdSqlCommand)
            '_adpAdapter.Fill(dtDataTable)

            dtDataTable.Load(obj)
            CommitTransaction()

            Return dtDataTable
        Catch ex As Exception
            RollBackTransaction()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Overloads Function ExecQuery(ByVal ProcedureName As String) As DataSet
        Return ExecQuery(ProcedureName, Nothing)
    End Function


    '****************************************************************************************
    ' ExecNonQuery
    ' ABSTRACT: Executeds a non-query without any parameters.
    '
    ' INPUT PARMS: ProcedureName    stored procedure to execute.
    '
    ' RETURNS:  Integer indicating how many rows were affected by the non-query.
    '
    ' Copyright © 2005 by Corning, Inc.
    '****************************************************************************************
    Public Overloads Function ExecNonQuery(ByVal ProcedureName As String) As Integer
        Return ExecNonQuery(ProcedureName, Nothing)
    End Function


    '****************************************************************************************
    ' ExecNonQuery
    ' ABSTRACT: Executes a non-query stored procedure agains the Eisemann database.
    '
    ' INPUT PARMS:  ProcedureName   Name of stored procedure to execute
    '               Parms           Collection of SqlParameter objects used as arguments for
    '                               the stored procedure.
    '
    ' RETURNS:      An integer containing the number of rows affected by the Stored Procedure.
    '
    ' Copyright © 2005 by Corning, Inc.
    '****************************************************************************************
    Public Overloads Function ExecNonQuery(ByVal ProcedureName As String, ByVal Parms As SqlParameter()) As Integer
        Try
            If _cnnMyConnection.State = ConnectionState.Closed Then
                Connect()
            End If
            _cmdSqlCommand = New SqlCommand
            With _cmdSqlCommand
                _cmdSqlCommand.Connection = _cnnMyConnection
                _cmdSqlCommand.CommandTimeout = 1800
                .CommandType = CommandType.StoredProcedure  'Set type to Stored Procedure   
                .CommandText = ProcedureName                'Specify procedure to run
                ' Clear any previous parameters from the command object
                Call .Parameters.Clear()
                ' Loop through parmameter collection, if defined, adding parameters to the command object
                If Not (Parms Is Nothing) Then
                    For Each sqlParm As SqlParameter In Parms
                        _cmdSqlCommand.Parameters.Add(sqlParm)
                    Next
                End If
                Dim returnParam As SqlParameter = New SqlParameter("@myReturn", 0)
                returnParam.Direction = ParameterDirection.ReturnValue
                _cmdSqlCommand.Parameters.Add(returnParam)
            End With

            BeginTransaction()
            If _isTran Then
                _cmdSqlCommand.Transaction = _trans
            End If

            ' Execute the procedure
            _cmdSqlCommand.ExecuteNonQuery()
            CommitTransaction()
            Return _cmdSqlCommand.Parameters("@myReturn").Value()
        Catch ex As Exception
            RollBackTransaction()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
            Return 0
        End Try


    End Function

    Public Sub New()
        If Not Connect() Then
            Exit Sub
        End If
    End Sub

    Private Function ReadDatabseConfig() As Boolean

        '_connStr = EncryptDAL.Decrypt(ConfigurationManager.ConnectionStrings("BSP").ConnectionString)

        ' _connStr = ConfigurationManager.ConnectionStrings("BSP").ConnectionString

        'READ from XML file which has 1 or more databases, so read from the selected database which is stored in a global variable

        If Common_PPT.GlobalPPT.SelectedDB Is Nothing Then
            Common_PPT.GlobalPPT.SelectedDB = GetDatabaseFromID(Common_PPT.GlobalPPT.SelectedDatabaseID)
        Else
            If Common_PPT.GlobalPPT.SelectedDB.ID <> Common_PPT.GlobalPPT.SelectedDatabaseID Then
                Common_PPT.GlobalPPT.SelectedDB = GetDatabaseFromID(Common_PPT.GlobalPPT.SelectedDatabaseID)
            End If
        End If


        If Common_PPT.GlobalPPT.SelectedDB.DBName <> Nothing Then
            _connStr = "Data Source=" + Common_PPT.GlobalPPT.SelectedDB.Server + ";Initial Catalog=" + Common_PPT.GlobalPPT.SelectedDB.DBName + ";Persist Security Info=True;User ID=" + Common_PPT.GlobalPPT.SelectedDB.User + ";Password=" + Common_PPT.GlobalPPT.SelectedDB.Password
            'set global connection string also
            Common_PPT.GlobalPPT.ConnectionString = _connStr
            Return True
        End If

        Return False
    End Function
    'For getting Scalar value like to find a single record
    Public Overloads Function ExecuteScalar(ByVal ProcedureName As String, ByVal Parms As SqlParameter()) As Object

        Try
            If _cnnMyConnection.State = ConnectionState.Closed Then
                Connect()
            End If


            _cmdSqlCommand = New SqlCommand
            With _cmdSqlCommand
                _cmdSqlCommand.Connection = _cnnMyConnection
                _cmdSqlCommand.CommandTimeout = 1800
                .CommandType = CommandType.StoredProcedure      'Set type to StoredProcedure
                .CommandText = ProcedureName                    'Specify stored procedure to run
                ' Clear any previous parameters from the Command object
                Call .Parameters.Clear()

                ' Loop through parmameter collection adding parameters to the command object
                If Not (Parms Is Nothing) Then
                    For Each sqlParm As SqlParameter In Parms
                        _cmdSqlCommand.Parameters.Add(sqlParm)
                    Next
                End If
            End With

            BeginTransaction()

            If _isTran Then
                _cmdSqlCommand.Transaction = _trans
            End If
            Dim objRecord As Object
            'Configure Adapter to find record already exists to object
            objRecord = _cmdSqlCommand.ExecuteScalar()


            CommitTransaction()

            Return objRecord
        Catch ex As Exception
            RollBackTransaction()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function

    Public Overloads Function DeleteRecord(ByVal ProcedureName As String, ByVal Parms As SqlParameter()) As Integer
        Try
            If _cnnMyConnection.State = ConnectionState.Closed Then
                Connect()
            End If
            _cmdSqlCommand = New SqlCommand
            With _cmdSqlCommand
                _cmdSqlCommand.Connection = _cnnMyConnection
                _cmdSqlCommand.CommandTimeout = 1800
                .CommandType = CommandType.StoredProcedure  'Set type to Stored Procedure   
                .CommandText = ProcedureName                'Specify procedure to run
                ' Clear any previous parameters from the command object
                Call .Parameters.Clear()
                ' Loop through parmameter collection, if defined, adding parameters to the command object
                If Not (Parms Is Nothing) Then
                    For Each sqlParm As SqlParameter In Parms
                        _cmdSqlCommand.Parameters.Add(sqlParm)
                    Next
                End If

            End With

            BeginTransaction()
            If _isTran Then
                _cmdSqlCommand.Transaction = _trans
            End If

            ' Execute the procedure
            _cmdSqlCommand.ExecuteNonQuery()
            CommitTransaction()
            Return 1
        Catch ex As Exception
            RollBackTransaction()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
            Return 0
        End Try


    End Function



    '****************************************************************************************
    ' ExecQuery
    ' ABSTRACT: Executes a stored procedure against the database and returns
    '   a NEW Dataset with the selected data.
    '
    ' INPUT PARMS:  ProcedureName   Name of Stored Procedure to execute
    '               Parms           Array of SqlParameter objects that will be passed into the
    '                               stored procedure.
    '
    ' RETURNS:      DataSet populated with results from stored procedure execution.
    '
    '****************************************************************************************
    Public Overloads Function AutoBSPBackupExecQuery(ByVal ProcedureName As String, ByVal Parms As SqlParameter()) As DataSet

        Try
            If _cnnMyConnection.State = ConnectionState.Closed Then
                Connect()
            End If

            Dim dsDataSet As New DataSet
            _cmdSqlCommand = New SqlCommand
            With _cmdSqlCommand
                _cmdSqlCommand.Connection = _cnnMyConnection
                _cmdSqlCommand.CommandTimeout = 1800
                .CommandType = CommandType.StoredProcedure      'Set type to StoredProcedure
                .CommandText = ProcedureName

                'Specify stored procedure to run
                ' Clear any previous parameters from the Command object
                Call .Parameters.Clear()

                ' Loop through parmameter collection adding parameters to the command object
                If Not (Parms Is Nothing) Then
                    For Each sqlParm As SqlParameter In Parms
                        _cmdSqlCommand.Parameters.Add(sqlParm)
                    Next
                End If
            End With

            'BeginTransaction()

            If _isTran Then
                _cmdSqlCommand.Transaction = _trans
            End If
            ' Configure Adapter to use newly created command object and fill the dataset.
            _adpAdapter = New SqlDataAdapter(_cmdSqlCommand)
            _adpAdapter.Fill(dsDataSet)

            'CommitTransaction()

            Return dsDataSet
        Catch ex As Exception
            RollBackTransaction()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
            Return Nothing
        End Try

    End Function


End Class
