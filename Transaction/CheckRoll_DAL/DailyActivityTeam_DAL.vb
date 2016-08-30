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
Imports CheckRoll_PPT
Imports Common_DAL
Imports Common_PPT
Public Class DailyActivityTeam_DAL
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

        'adapter.SelectCommand = selectCommand
        'adapter.InsertCommand = insertCommand
        'adapter.UpdateCommand = updateCommand
        'adapter.DeleteCommand = deleteCommand

    End Sub
    Public ReadOnly Property Adapter() As SqlDataAdapter
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
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyActivityTeamInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Daily Team Activity ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate Code", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Gang Master ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GangName", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Gang Name", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Activity", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Activity", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Mandore ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@KraniID", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "Krani ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, GlobalPPT.strUserName, DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MandorBesarID", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "Mandor Besar ID", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''---------
        'Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyActivityTeamUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Daily Team Activity ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate Code", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Activity", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Activity", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Mandore ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@KraniID", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "Krani ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, GlobalPPT.strUserName, DataRowVersion.Current, False, Nothing, "", "", ""))

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyActivityTeamDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "@Daily Team Activity ID", DataRowVersion.Current, False, Nothing, "", "", ""))


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
        _selectCommand.CommandText = "Checkroll.CRCensusByDateSelect"
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
    Public Shared Function Save(ByVal obj As DailyActivityTeam_DAL, ByRef dt As DataTable) As Integer
        Return obj.Update(dt)
    End Function

    Public Shared Function DailyTeamActivitySelect() As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyTeamActivitySelect]", params).Tables(0)
        Return dt

    End Function

    Public Shared Function RefreshTeamAfterModify(ByVal ddate As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@DDate", Convert.ToDateTime(ddate).ToString("MM/dd/yyyy")) 'ddate
        dt = objdb.ExecQuery("[Checkroll].[DailyTeamActivityisExist]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyTeamActivityisExist(ByVal ddate As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@DDate", Convert.ToDateTime(ddate).ToString("MM/dd/yyyy")) 'ddate
        dt = objdb.ExecQuery("[Checkroll].[DailyTeamActivityisExist]", params).Tables(0)

        'Insert record to table DailyGangEmployeeSetup per employee in team
        If dt.Rows.Count > 0 Then
            For Each empMaster As DataRow In dt.Rows
                Dim dtEmployee = New DataTable
                dtEmployee = GetEmployee(empMaster.Item("Gang Master Id"))
                If dtEmployee.Rows.Count > 0 Then
                    For Each emp As DataRow In dtEmployee.Rows
                        Dim objPPT As New DailyGangEmployeeSetupPPT
                        With objPPT
                            If Not IsDBNull(empMaster.Item("Date")) Then
                                .DDate = empMaster.Item("Date")
                            End If
                            If Not IsDBNull(empMaster.Item("Daily Team Activity ID")) Then
                                .DailyTeamActivityID = empMaster.Item("Daily Team Activity ID")
                            End If
                            If Not IsDBNull(empMaster.Item("Gang Master Id")) Then
                                .GangMasterID = empMaster.Item("Gang Master Id")
                            End If
                            If Not IsDBNull(emp.Item("GangEmployeeId")) Then
                                .GangEmployeeID = emp.Item("GangEmployeeId")
                            End If
                            If Not IsDBNull(emp.Item("EmpID")) Then
                                .EmpID = emp.Item("EmpID")
                            End If
                        End With
                        DailyGangEmployeeSetupInsert(objPPT)
                    Next
                End If
            Next
        End If

        Return dt

    End Function

    Private Shared Function GetEmployee(gangmaster As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(9) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@GangEmployeeID", DBNull.Value)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@GangName", DBNull.Value)
        params(3) = New SqlParameter("@EmpCode", DBNull.Value)
        params(4) = New SqlParameter("@GangMasterID", gangmaster)
        params(5) = New SqlParameter("@EmpName", DBNull.Value)
        params(6) = New SqlParameter("@MandorName", DBNull.Value)
        params(7) = New SqlParameter("@MandorCode", DBNull.Value)
        params(8) = New SqlParameter("@KraniName", DBNull.Value)
        params(9) = New SqlParameter("@KraniCode", DBNull.Value)
        dt = objdb.ExecQuery("[Checkroll].[GangEmployeeSetupSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyAttendanceWithTeamSelect(ByVal TeamName As String, ByVal Rdate As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@TeamName", TeamName)
        params(1) = New SqlParameter("@RDate", Convert.ToDateTime(Rdate).ToString("MM/dd/yyyy")) 'Rdate
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@SaveUpDate", "Save")

        dt = objdb.ExecQuery("[Checkroll].[DailyAttendanceWithTeamSelect]", params).Tables(0)
        Return dt

    End Function
    Public Shared Function CRDailyAttendanceNikSelect(ByVal EmpCode As String, ByVal Mandor As String, ByVal Status As String, ByVal EmpName As String, ByVal AttDate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EmpCode", EmpCode)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@Mandor", Mandor)
        params(3) = New SqlParameter("@Status", Status)
        params(4) = New SqlParameter("@EmpName", EmpName)
        'params(5) = New SqlParameter("@AttDate", AttDate)
        params(5) = New SqlParameter("@AttDate", Convert.ToDateTime(AttDate).ToString("MM/dd/yyyy")) 'AttDate
        dt = objdb.ExecQuery("[Checkroll].[CRDailyAttendanceNikSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyTeamActivityIsSelected(ByVal DailyTeamActivityID As String, ByVal RDate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@DailyTeamActivityID", DailyTeamActivityID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'params(2) = New SqlParameter("@RDate", RDate)
        params(2) = New SqlParameter("@RDate", Convert.ToDateTime(RDate).ToString("MM/dd/yyyy")) 'Rdate
        dt = objdb.ExecQuery("[Checkroll].[DailyTeamActivityIsSelected]", params).Tables(0)
        Return dt
    End Function

    Public Function DailyGangEmployeeSetupSelect(gangMasterID As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@GangMasterID", gangMasterID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyGangEmployeeSetupSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyTeamActivityAutoInsert(ByVal DDate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'params(2) = New SqlParameter("@DDate", DDate)
        params(2) = New SqlParameter("@DDate", Convert.ToDateTime(DDate).ToString("MM/dd/yyyy")) 'Rdate
        params(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        dt = objdb.ExecQuery("[Checkroll].[DailyTeamActivityAutoInsert]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyGangEmployeeSetupInsert(objPPT As DailyGangEmployeeSetupPPT) As Boolean
        Try
            Dim objdb As New SQLHelp
            Dim params(7) As SqlParameter
            params(0) = New SqlParameter("@DDAte", objPPT.DDate)
            params(1) = New SqlParameter("@DailyTeamActivityID", objPPT.DailyTeamActivityID)
            params(2) = New SqlParameter("@GangEmployeeID", objPPT.GangEmployeeID)
            params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(4) = New SqlParameter("@GangMasterID", objPPT.GangMasterID)
            params(5) = New SqlParameter("@EmpID", objPPT.EmpID)
            params(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            params(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            objdb.ExecQuery("[Checkroll].[DailyGangEmployeeSetupInsert]", params)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Shared Function DailyTeamActivityDelete(ByVal DailyTeamActivityID As String, ByVal ActivityCode As String, ByVal dtRdate As Date, ByVal OutputType As String) As DataTable
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim dt As New DataTable

        'Dim strServerUserName As String = String.Empty
        'Dim strServerPassword As String = String.Empty
        'Dim strDSN As String = String.Empty
        'Dim StrInitialCatlog As String = String.Empty

        'strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDataSource").ToString) & ""
        'strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
        'strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""
        'StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""

        'Dim constr As String = " Data Source=" & strDSN & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"
        Dim conn As New SqlConnection
        conn = New SqlConnection(connString)

        conn.Open()
        cmd.Connection = conn
        cmd.CommandTimeout = 180
        cmd.CommandText = "Checkroll.DailyTeamActivityDelete"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@DailyTeamActivityID", DailyTeamActivityID)
        cmd.Parameters.AddWithValue("@ActivityCode", ActivityCode)
        cmd.Parameters.AddWithValue("@DDate", dtRdate)
        cmd.Parameters.AddWithValue("@OutputType", "@OutputReturn")
        da.SelectCommand = cmd
        da.Fill(ds, "Checkroll.DailyTeamActivityDelete")
        dt = ds.Tables("Checkroll.DailyTeamActivityDelete")
        Return dt
    End Function

    Public Shared Function AttSummaryWithTeamProcess()
        'by Stanley on 24-06-2011
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter

        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[AttendSummaryWithTeamProcess]", params)

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Message")
        End Try
        Return 0
    End Function

    Public Shared Function UploadSalary(ByVal SalaryProcDate As Date)
        ' by Dadang Adi
        ' Sabtu, 13 Mar 2010, 12:54
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter

        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
            params(4) = New SqlParameter("@SalaryProcDate", SalaryProcDate)
            objdb.ExecNonQuery("[Checkroll].[UpLoadSalary]", params)


        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Message")
        End Try
        Return 0

    End Function

    Public Shared Function DailyTeamActivityEditTeam(GangMasterID As String, DailyTeamActivityID As String, DDate As Date) As DataTable
        Try
            Dim dt As New DataTable
            Dim obj As New SQLHelp
            Dim param(3) As SqlParameter
            param(0) = New SqlParameter("@GangMasterID", GangMasterID)
            param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            param(2) = New SqlParameter("@DailyTeamActivityID", DailyTeamActivityID)
            param(3) = New SqlParameter("@DDate", Convert.ToDateTime(DDate))
            dt = obj.ExecQuery("[Checkroll].[DailyTeamActivityEditTeam]", param).Tables(0)
            Return dt
        Catch ex As Exception

        End Try
    End Function

    'TeamActivity
    Public Shared Function GetKeyValuePair() As DataTable
        Dim dt As New DataTable
        Dim obj As New SQLHelp
        Dim param(0) As SqlParameter
        param(0) = New SqlParameter("@KeyName", "TeamActivity")
        dt = obj.ExecQuery("[dbo].[GetKeyValuePairs]", param).Tables(0)
        Return dt

    End Function
End Class
