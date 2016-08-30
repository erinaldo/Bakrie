'
'
' Created   : Jumat, 25 Sep 2009, 17:56
' Modified  : Monday, 16 Nov 2009, 00:09
'
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Imports Common_PPT
Imports Common_DAL
Imports System.Windows.Forms

Public Class AdvancePaymentDet_DAL

    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection
    Private _selectCommand As SqlCommand

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

    Private Sub InitAdapter()
        Me._adapter = New SqlDataAdapter()

        '// 
        ' InsertCommmand
        '
        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.[AdvancePaymentDetInsert]"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AdvPaymentDetID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "AdvPaymentDetID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AdvancePaymentID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "AdvancePaymentID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Mandays", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Mandays", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Sabtu, 13 Feb 2010, 22:11
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DedJamsostek", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "DedJamsostek", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Sabtu, 13 Feb 2010, 22:11

        ' Senin, 23 Nov 2009, 17:16
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaidAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "PaidAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Senin, 23 Nov 2009, 17:16
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.[AdvancePaymentDetUpdate]"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AdvPaymentDetID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "AdvPaymentDetID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AdvancePaymentID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "AdvancePaymentID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Mandays", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Mandays", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))

        ' Sabtu, 13 Feb 2010, 22:11
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DedJamsostek", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "DedJamsostek", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Sabtu, 13 Feb 2010, 22:11

        ' Senin, 23 Nov 2009, 17:16
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaidAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "PaidAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Senin, 23 Nov 2009, 17:16
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.[AdvancePaymentDetDelete]"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@AdvPaymentDetID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "AdvPaymentDetID", DataRowVersion.Current, False, Nothing, "", "", ""))

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

    Private Sub InitSelectCommand()
        _selectCommand = New SqlCommand()
        _selectCommand.Connection = Me.Connection()
        _selectCommand.CommandText = "Checkroll.[CRAdvancePaymentDetSelect]"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter '= New SqlParameter()

        param = _selectCommand.Parameters.Add("@AdvancePaymentID", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
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
        'For i = 0 To Me.Adapter.InsertCommand.Parameters.Count - 1
        '    MessageBox.Show(Me.Adapter.InsertCommand.Parameters(i).ParameterName + " " + _
        '                    Me.Adapter.InsertCommand.Parameters(i).Value)
        'Next
        ' update: Saturday, 24 Oct 2009, 19:10
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

    Public Function AdvancePaymentDetSelect( _
        ByVal AdvancePaymentID As String, _
        ByVal EstateID As String) As DataTable
        ' Sabtu, 26 Sep 2009, 22:51
        Dim DT As New DataTable()

        Me.Adapter.SelectCommand = SelectCommand
        Me.Adapter.SelectCommand.Parameters("@AdvancePaymentID").Value = AdvancePaymentID
        Me.Adapter.SelectCommand.Parameters("@EstateID").Value = EstateID

        DT.Clear()
        Try
            Me.Adapter.Fill(DT)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return DT
    End Function

    Public Function CRNikNameByCategorySelect( _
        ByVal EstateID As String, _
        ByVal EmpCode As String, _
        ByVal EmpName As String, _
        ByVal Category As String) As DataTable

        ' Ahad, 27 Sep 2009, 02:27
        Dim DT As DataTable
        Dim params(3) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = EstateID

        params(1) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        params(1).Value = EmpCode

        params(2) = New SqlParameter("@EmpName", SqlDbType.NVarChar, 50)
        params(2).Value = EmpName

        params(3) = New SqlParameter("@Category", SqlDbType.NVarChar, 50)
        params(3).Value = Category

        DT = AdvancePayment_DAL.ExecuteQuery("Checkroll.CRNIKNameByCategorySelect", params)

        Return DT
    End Function

    Public Shared Function CRAttendanceSummarySelect( _
        ByVal Category As String) As DataTable

        ' Monday, 16 Nov 2009, 00:11
        Dim DT As DataTable
        Dim adapter As New SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50)
        params(1).Value = GlobalPPT.strActMthYearID

        params(2) = New SqlParameter("@Category", SqlDbType.NVarChar, 50)
        params(2).Value = Category

        DT = adapter.ExecQuery("Checkroll.CRAttendanceSummarySelect", params).Tables(0)
        'DT = AdvancePayment_DAL.ExecuteQuery("Checkroll.CRAttendanceSummarySelect", params)

        Return DT
    End Function

End Class
