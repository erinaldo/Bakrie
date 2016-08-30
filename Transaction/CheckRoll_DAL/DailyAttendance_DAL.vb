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

Public Class DailyAttendance_DAL

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
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyAttendanceNoTeamInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Daily Receiption ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate Code", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Active Month Year ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Employee ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Daily OT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "OT Value", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OtherEstateEmpNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Other Estate Employee No", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OtherEstateName", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "Other Estate Name", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AttendanceSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Attendance Setup ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DistributionSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Distribution Setup ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@VHID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Vehicle ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Tonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Tonnage", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DriverPremi", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Driver Premi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Created By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Created On", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''---------
        'Update(Command)
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Me.Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyAttendanceNoTeamUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        'Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "Daily Receiption ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Estate ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Active Month Year ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Employee ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Daily OT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "OT Value", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OtherEstateEmpNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Other Estate Employee No", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OtherEstateName", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "Other Estate Name", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AttendanceSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Attendance Setup ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DistributionSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Distribution Setup ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VHID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Vehicle ID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Tonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Tonnage", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DriverPremi", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Driver Premi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Modified By", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "Modified On", DataRowVersion.Current, False, Nothing, "", "", ""))

        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyAttendanceNoTeamDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Daily Receiption ID", DataRowVersion.Current, False, Nothing, "", "", ""))


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
                nilai = Me.Adapter.Update(dataTable)
                _trans.Commit()



            End If
        Catch ex As Exception
            _trans.Rollback()
            MsgBox("Error encountered during transaction. " + ex.Message, MsgBoxStyle.Critical)
        End Try
        _conn.Close()
        Return nilai
    End Function
    Public Shared Function CREstateSelect(ByVal EstateName As String) As DataTable
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateName", EstateName)
        params(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CREstateSelect]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNoTeamView(ByVal Rdate As String, ByVal EmpId As String) As DataTable
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Rdate", Convert.ToDateTime(Rdate).ToString("MM/dd/yyyy"))
        params(1) = New SqlParameter("@Empid", EmpId)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyAttendanceNoTeamView]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNoTeamIsExist(ByVal DailyReceptionID As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@DailyReceptionID", DailyReceptionID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyAttendanceNoTeamIsExist]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRKTView(ByVal EmpID As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EmpID", EmpID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRKTView]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function DailyActivityDistributionIsSelect(ByVal DailyReceptionDetID As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@DailyReceiptionID", DailyReceptionDetID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[DailyActivityDistributionIsSelect]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNoTeamViewAll(ByVal RDate As String, ByVal EmpNik As String, ByVal EmpName As String) As DataTable
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        Dim strRdateTemp As String
        If RDate.Trim().ToString() <> "" Then
            strRdateTemp = Convert.ToDateTime(RDate).ToString("MM/dd/yyyy")
        Else
            strRdateTemp = ""
        End If

            'params(0) = New SqlParameter("@RDate", Convert.ToDateTime(RDate).ToString("MM/dd/yyyy"))
        params(0) = New SqlParameter("@RDate", strRdateTemp)
            params(1) = New SqlParameter("@EmpNik", EmpNik)
            params(2) = New SqlParameter("@EmpName", EmpName)
            params(3) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            dt = objdb.ExecQuery("[Checkroll].[DailyAttendanceNoTeamViewAll]", params).Tables(0)
            Return dt
    End Function
    Public Shared Function CRTAnalysisView(ByVal TAnalysisID As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@TAnalysisID", TAnalysisID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRTAnalysisView]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function CRDistributionSetupLookup(ByVal DistributionDescp As String, ByVal DistributionSetupID As String) As DataTable
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@DistributionDescp", DistributionDescp)
        params(1) = New SqlParameter("@DistributionSetupID", DistributionSetupID)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRDistributionSetupLookup]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CRMVehicleSelect(ByVal VHID As String) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@VHID", VHID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRMVehicleSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CRPremiDriver(ByVal BlockID As String, ByVal AttendanceSetupID As String) As DataTable
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@BlockID", BlockID)
        params(1) = New SqlParameter("@AttendanceSetupID", AttendanceSetupID)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRPremiDriver]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CRCOASelect(ByVal COACODE As String, ByVal ExpenditureAg As String) As DataTable
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@COACODE", COACODE)
        params(1) = New SqlParameter("@ExpenditureAg", ExpenditureAg)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRCOASelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CRPHoliday(ByVal PHdate As Date) As DataTable
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@PHdate", Convert.ToDateTime(PHdate).ToString("MM/dd/yyyy"))
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRPHoliday]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function AttendSummaryNoTeam(ByVal Empid As String) As DataTable
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@Empid", Empid)
        dt = objdb.ExecQuery("[Checkroll].[AttendSummaryNoTeam]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function ReceptionSummaryNoTeam(ByVal Empid As String, ByVal Blockid As String) As Integer
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@Empid", Empid)
        params(5) = New SqlParameter("@Blockid", Blockid)

        'dt = objdb.ExecQuery("[Checkroll].[ReceptionSummaryNoTeam]", params).Tables(0)
        ' Ahad, 29 Nov 2009, 19:06
        ' By Dadang
        ' Function ini dirubah jadi Integer buka DataTable lagi
        Dim retValue As Integer
        retValue = objdb.ExecNonQuery("[Checkroll].[ReceptionSummaryNoTeam]", params)
        Return retValue
    End Function

    Public Shared Function ReceptionSummaryTeam(ByVal MandorID As String, ByVal KraniID As String, _
                                                ByVal Empid As String, _
                                                ByVal Blockid As String) As DataTable
        Dim params(7) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@MandoreID", MandorID)
        params(5) = New SqlParameter("@KraniID", KraniID)
        params(6) = New SqlParameter("@Empid", Empid)
        params(7) = New SqlParameter("@Blockid", Blockid)
        dt = objdb.ExecQuery("[Checkroll].[ReceptionSummaryTeam]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function GetTeamName(ByVal MandorID As String, ByVal KraniID As String) As DataTable
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@MandoreID", MandorID)
        params(5) = New SqlParameter("@KraniID", KraniID)
       
        dt = objdb.ExecQuery("[Checkroll].[GetTeamName]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CREmployeeHIPSelect(ByVal EmpID As String) As DataTable
        ' by Dadang Adi H
        ' Rabu, 18 Nov 2009, 10:13
        Dim dt As DataTable
        Dim params(1) As SqlParameter

        ' CREmployeeHIP adalah untuk karyawan Category KT

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@EmpID", SqlDbType.NVarChar)
        params(1).Value = EmpID

        dt = objdb.ExecQuery("[Checkroll].[CREmployeeHIPSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Sub UpdateOTValue(ByVal ID As String, ByVal TotalOTValue As Double)

        Dim params(1) As SqlParameter

        ' CREmployeeHIP adalah untuk karyawan Category KT

        params(0) = New SqlParameter("@ID", SqlDbType.Int)
        params(0).Value = ID


        params(1) = New SqlParameter("@TotalOT", SqlDbType.Decimal)
        params(1).Value = TotalOTValue

        objdb.ExecQuery("[Checkroll].[DailyAttendanceUpdateOTValue]", params)
    End Sub

End Class
