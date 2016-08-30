'
' Created By: Dadang Adi Hendradi
' Created   : Senin, 28 Sep 2009, 16:23

'
Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data
Imports Common_PPT
Imports System.Windows.Forms

Public Class RicePayment_DAL
    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection
    Private _selectCommand As SqlCommand

    Private Sub InitConnection()
        Me._conn = DailyReceiptionWithTeam_DAL.getConnection()
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
        Me._adapter.InsertCommand.CommandText = "Checkroll.[RiceInsert]"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RiceID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "RiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RiceProcessingDate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "RiceProcessingDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Category", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.[RiceUpdate]"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RiceID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "RiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RiceProcessingDate", SqlDbType.Date, 8, ParameterDirection.Input, 23, 3, "RiceProcessingDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Category", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.[RiceDelete]"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@RiceID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "RiceID", DataRowVersion.Current, False, Nothing, "", "", ""))

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
        _selectCommand.CommandText = "Checkroll.[CRRicePaymentSelect]"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter '= New SqlParameter()

        param = _selectCommand.Parameters.Add("@RiceProcessingDate", SqlDbType.Date)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@Category", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@RiceDate", SqlDbType.Int, 2)
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

    Public Function CRRicePaymentSelect( _
    ByVal RiceProcessingDate As Date, _
    ByVal Category As String, _
    ByVal EstateID As String, ByVal RiceDate As Integer) As DataTable

        ' Sabtu, 26 Sep 2009, 19:08
        Dim DT As DataTable = New DataTable

        Me.Adapter.SelectCommand = SelectCommand
        Me.Adapter.SelectCommand.Parameters("@RiceProcessingDate").Value = RiceProcessingDate
        Me.Adapter.SelectCommand.Parameters("@Category").Value = Category
        Me.Adapter.SelectCommand.Parameters("@EstateID").Value = EstateID
        Me.Adapter.SelectCommand.Parameters("@RiceDate").Value = RiceDate

        DT.Clear()
        Try
            Me.Adapter.Fill(DT)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return DT
    End Function

    Public Shared Function TaxAndRiceSetupSelect() As DataTable
        Dim DT As DataTable
        Dim params(0) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        DT = adapter.ExecQuery("Checkroll.TaxAndRiceSetupSelect", params).Tables(0)
        Return DT
    End Function

    Public Shared Sub CRRiceAdvanceLog(ByVal Category As String)
        ' Selasa, 22 Dec 2009, 16:16
        ' Place : Kuala Lumpur
        ' Jum'at, 19 Mar 2010, 13:58
        ' Tambah category parameter
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50)
        params(1).Value = GlobalPPT.strActMthYearID

        params(2) = New SqlParameter("@Category", SqlDbType.NVarChar, 50)
        params(2).Value = Category

        params(3) = New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50)
        params(3).Value = GlobalPPT.strUserName

        Try
            adapter.ExecNonQuery("[Checkroll].[CRRiceAdvanceLog]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Function CRGetWorkingDays() As Integer
        ' Jum'at, 19 Mar 2010, 08:53
        ' Place : Kebun
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp
        Dim workingDays As Integer

        workingDays = 0



        Try
            params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
            params(0).Value = GlobalPPT.strEstateID

            params(1) = New SqlParameter("@AMonth", SqlDbType.Int)
            params(1).Value = GlobalPPT.IntActiveMonth

            params(2) = New SqlParameter("@AYear", SqlDbType.Int)
            params(2).Value = GlobalPPT.intActiveYear

            params(3) = New SqlParameter("@WorkingDays", SqlDbType.Int)
            params(3).Direction = ParameterDirection.Output

            adapter.ExecNonQuery("[Checkroll].[CRGetWorkingDays]", params)

            workingDays = params(3).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return workingDays
    End Function

    Public Shared Function CRGetTotalAttendanceForRice( _
        ByVal FromDT As Date, _
        ByVal ToDT As Date, _
        ByVal EmpID As String, _
        ByVal EmpCode As String) As DataTable

        ' By Dadang Adi Hendradi
        ' Kamis, 25 Mar 2010, 23:37
        Dim DT As DataTable = Nothing
        Dim params(4) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@FromDT", SqlDbType.Date)
        params(1).Value = FromDT

        params(2) = New SqlParameter("@ToDT", SqlDbType.Date)
        params(2).Value = ToDT

        params(3) = New SqlParameter("@EmpID", SqlDbType.NVarChar, 50)
        params(3).Value = EmpID

        params(4) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        params(4).Value = EmpCode

        Try
            DT = adapter.ExecQuery("[Checkroll].[CRGetTotalAttendanceForRice]", params).Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try

        Return DT
    End Function

    Public Shared Function CRGetTotalAttendanceForRiceAdvance( _
        ByVal FromDT As Date, _
        ByVal ToDT As Date, _
        ByVal EmpID As String, _
        ByVal EmpCode As String) As DataTable

        ' By Naxim
        ' On 03 June 2013
        ' To got total attendance, including HK, sick leave, rain etc...
        Dim DT As DataTable = Nothing
        Dim params(4) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@FromDT", SqlDbType.Date)
        params(1).Value = FromDT

        params(2) = New SqlParameter("@ToDT", SqlDbType.Date)
        params(2).Value = ToDT

        params(3) = New SqlParameter("@EmpID", SqlDbType.NVarChar, 50)
        params(3).Value = EmpID

        params(4) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        params(4).Value = EmpCode

        Try
            DT = adapter.ExecQuery("[Checkroll].[CRGetTotalAttendanceForRiceAdvance]", params).Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try

        Return DT
    End Function


    Public Shared Function CRRiceDelete() As Integer

        Dim adapter As New Common_DAL.SQLHelp
        '  Dim DT As Integer
        Dim params(0) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        adapter.ExecNonQuery("[Checkroll].CRRiceDelete", params)

    End Function
End Class
