''''
' Programmer: Dadang Adi Hendradi
' Created   : Kamis, 3 Sep 2009, 13:20
' Modify    : Saturday, 19 Sep 2009, 20:37 -> Addition TotalOT to parameters
'
'
Imports CheckRoll_PPT
Imports Common_PPT

Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms

Public Class DailyAttendanceWithTeam_DAL

    Private _selectCommand As SqlCommand = Nothing
    'Private _insertCommand As SqlCommand = Nothing
    'Private Shared _updateCommand As SqlCommand = Nothing
    'Private Shared _deleteCommand As SqlCommand = Nothing
    Private Shared objdb As New SQLHelp
    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = Nothing
    Private Shared connString As String

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

        Me._adapter = New SqlDataAdapter()

        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyAttendanceWithTeamInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyReceiptionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "RDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyTeamActivityID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OtherEstateEmpNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OtherEstateEmpNo", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OtherEstateName", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "OtherEstateName", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AttendanceSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "AttendanceSetupID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalOTValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOTValue", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DistributionSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DistributionSetupID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyAttendanceWithTeamUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionID", DataRowVersion.Original, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "RDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyTeamActivityID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OtherEstateEmpNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OtherEstateEmpNo", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OtherEstateName", SqlDbType.NVarChar, 80, ParameterDirection.Input, 0, 0, "OtherEstateName", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AttendanceSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "AttendanceSetupID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalOTValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOTValue", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DistributionSetupID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DistributionSetupID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))


        ' ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyAttendanceWithTeamDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionID", DataRowVersion.Current, False, Nothing, "", "", ""))


    End Sub

    Private Sub InitConnection()
        Dim ci As System.Globalization.CultureInfo
        ci = Globalization.CultureInfo.InstalledUICulture()
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
        'ci.DateTimeFormat().GetFormat()

        Me._conn = New SqlConnection()
        'Me._conn.ConnectionString = EncryptDAL.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings("BSP").ConnectionString())
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
        _selectCommand.CommandText = "Checkroll.DailyAttendanceWithTeamSelect"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter = New SqlParameter()

        param = _selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@TeamName", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@RDate", SqlDbType.Date)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@SaveUpDate", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

    End Sub

     Private Sub CalculatePremoiRubber(year)
        _selectCommand = New SqlCommand()
        _selectCommand.Connection = Me.Connection()
        _selectCommand.CommandText = "Checkroll.DailyAttendanceWithTeamSelect"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter = New SqlParameter()

        param = _selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@TeamName", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@RDate", SqlDbType.Date)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@SaveUpDate", SqlDbType.NVarChar, 50)
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
        Dim msg As String = String.Empty
        Dim command As SqlCommand = Me.Adapter.InsertCommand

        'For i = 0 To command.Parameters.Count - 1
        '    msg = msg + command.Parameters(i).ParameterName
        '    msg = msg + " "
        '    If command.Parameters(i).Value IsNot System.DBNull.Value Then
        '        msg = msg + command.Parameters(i).Value + vbCrLf
        '    Else
        '        msg = msg + "DBNull" + vbCrLf
        '    End If


        'Next
        'MessageBox.Show(command.Parameters.Item(0).Value)
        'MessageBox.Show(msg, "Parameters by Dadang [" + Now.ToString("dd/MM/yyyy HH:MM:si"))

        ' update: Saturday, 24 Oct 2009, 19:08
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
            'Me.Adapter.DeleteCommand.Transaction = trans

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

    Public Shared Function CRSubBlockSelect(ByVal BlockName As String) As DataTable

        Dim DT As DataTable
        Dim params(1) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@BlockName", SqlDbType.NVarChar, 50)
        params(1).Value = BlockName

        DT = adapter.ExecQuery("Checkroll.[CRSubBlockSelect]", params).Tables(0)

        Return DT
        ' ini akan mengembalikan fields:
        ' BlockID, BlockName,
        ' YOPID, YOP,
        ' EstateID, EstateName,
        ' DivID, DivName

    End Function

    'Public Shared Function CRStationSelect(ByVal StationID As String) As DataTable

    '    Dim DT As DataTable
    '    Dim params(1) As SqlParameter
    '    Dim adapter As New Common_DAL.SQLHelp

    '    params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
    '    params(0).Value = GlobalPPT.strEstateID

    '    params(1) = New SqlParameter("@StationID", SqlDbType.NVarChar, 50)
    '    params(1).Value = StationID

    '    DT = adapter.ExecQuery("Checkroll.[CRStationSelect]", params).Tables(0)

    '    Return DT
    '    ' ini akan mengembalikan fields:
    '    ' StationID, StationDescp

    'End Function

    Public Function DailyAttendanceWithTeamSelect(ByVal TeamName As String, ByVal RDate As Date, ByVal SaveUpdate As String) As DataTable
        ' Wednesday, 09 SEP 2009, 11:11
        Dim DT As DataTable = New DataTable



        Me.Adapter.SelectCommand = SelectCommand
        Me.Adapter.SelectCommand.CommandTimeout = 120
        Me.Adapter.SelectCommand.Parameters("@EstateID").Value = GlobalPPT.strEstateID
        Me.Adapter.SelectCommand.Parameters("@TeamName").Value = TeamName
        Me.Adapter.SelectCommand.Parameters("@RDate").Value = RDate
        Me.Adapter.SelectCommand.Parameters("@SaveUpdate").Value = SaveUpdate

        DT.Clear()
        Me.Adapter.Fill(DT)

        Return DT

    End Function

    Public Function DailyAttendanceTeamExist(ByVal DailyTeamActivityID As String) As DataTable
        ' Wednesday, 09 SEP 2009, 11:11
        Dim DT As DataTable = New DataTable
        Dim params(1) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50)
        params(1).Value = DailyTeamActivityID

        DT = adapter.ExecQuery("Checkroll.[DailyAttendanceTeamExist]", params).Tables(0)

        Return DT


    End Function



    Public Shared Function CRTeamMemberSelect(ByVal DDate As Date, ByVal TeamName As String) As DataTable
        ' Wednesday, 09 SEP 2009, 11:11
        ' Modified: Kamis, 22 Oct 2009, 10:39, add DDate
        Dim DT As DataTable = New DataTable
        Dim adapter As New Global.Common_DAL.SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@DDate", SqlDbType.Date)
        params(1).Value = DDate

        params(2) = New SqlParameter("@TeamName", SqlDbType.NVarChar, 50)
        params(2).Value = TeamName

        DT = adapter.ExecQuery("Checkroll.CRTeamMemberSelect", params).Tables(0)
        Return DT

    End Function

    Public Shared Function CRHABrondalanSelect(ByVal DDate As Date, ByVal GangMasterID As String) As DataTable
        ' Wednesday, 09 SEP 2009, 11:11
        ' Modified: Kamis, 22 Oct 2009, 10:39, add DDate
        Dim DT As DataTable = New DataTable
        Dim adapter As New Global.Common_DAL.SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@DDate", SqlDbType.Date)
        params(1).Value = DDate

        params(2) = New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50)
        params(2).Value = GangMasterID

        DT = adapter.ExecQuery("[Checkroll].[DailyAttendanceHaBrondalanSelect]", params).Tables(0)
        Return DT

    End Function


    Public Shared Function PremiAttCodeSelect() As DataTable
        ' Wednesday, 09 SEP 2009, 11:11
        ' Modified: Kamis, 22 Oct 2009, 10:39, add DDate
        Dim DT As DataTable = New DataTable
        Dim adapter As New Global.Common_DAL.SQLHelp
        Dim params(0) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID



        DT = adapter.ExecQuery("Checkroll.GetAttCodeInPremi", params).Tables(0)
        Return DT

    End Function


    Public Shared Function GetAttCodeInReception() As DataTable
        ' Wednesday, 09 SEP 2009, 11:11
        ' Modified: Kamis, 22 Oct 2009, 10:39, add DDate
        Dim DT As DataTable = New DataTable
        Dim adapter As New Global.Common_DAL.SQLHelp
        Dim params(0) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID



        DT = adapter.ExecQuery("Checkroll.GetAttCodeInReception", params).Tables(0)
        Return DT

    End Function


    Public Shared Function CRDailyAttendanceWithTeamEmpIsExist( _
        ByVal TeamName As String, _
        ByVal EmpID As String, _
        ByVal DDate As String) As DataTable

        ' Thursday, 10 SEP 2009, 11:06
        Dim DT As DataTable = New DataTable
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@TeamName", SqlDbType.NVarChar)
        params(1).Value = TeamName

        params(2) = New SqlParameter("@EmpID", SqlDbType.NVarChar)
        params(2).Value = EmpID

        params(3) = New SqlParameter("@DDate", SqlDbType.Date)
        params(3).Value = DDate

        DT = adapter.ExecQuery("Checkroll.CRDailyAttendanceWithTeamEmpIsExist", params).Tables(0)

        Return DT

    End Function


    Public Shared Function EstateSelect() As DataTable
        '
        ' ID    EstateID    EstateCode      EstateName
        ' 11    M01         01              Perdanan Estate
        ' 12    M02         02              Cakra Estate
        ' 13    M03         03              Cakra Oil Mill
        '
        Dim DT As DataTable
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50)
        params(1).Value = System.DBNull.Value

        params(2) = New SqlParameter("@EstateName", SqlDbType.Date)
        params(2).Value = System.DBNull.Value

        'DT = AdvancePayment_DAL.ExecuteQuery("General.[EstateSelect]", params)
        DT = adapter.ExecQuery("Checkroll.[CREstateSelect]", params).Tables(0)
        Return DT
    End Function
    Public Shared Function CRGangMasterSelect(ByVal GangName As String, ByVal MandorName As String, _
        ByVal KraniName As String, _
        ByVal DDate As Date, OilRubber As String) As DataTable

        ' Update, Selasa 20 Oct 2009, 03:03
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@GangName", GangName)
        params(1) = New SqlParameter("@MandorName", MandorName)
        params(2) = New SqlParameter("@KraniName", KraniName)
        params(3) = New SqlParameter("@DDate", DDate)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        If OilRubber = "OilPalm" Then
            dt = objdb.ExecQuery("[Checkroll].[CRGangMasterSelect]", params).Tables(0)
        ElseIf OilRubber = "Rubber" Then
            dt = objdb.ExecQuery("[Checkroll].[CRGangMasterSelectDeres]", params).Tables(0)
        ElseIf OilRubber = String.Empty Then
            dt = objdb.ExecQuery("[Checkroll].[CRGangMasterSelectAll]", params).Tables(0)
        End If


        Return dt


    End Function

    Public Shared Function CRGangMasterSelectAll(ByVal GangName As String, ByVal MandorName As String, _
        ByVal KraniName As String, _
        ByVal DDate As Date) As DataTable

        ' Update, Selasa 20 Oct 2009, 03:03
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@GangName", GangName)
        params(1) = New SqlParameter("@MandorName", MandorName)
        params(2) = New SqlParameter("@KraniName", KraniName)
        params(3) = New SqlParameter("@DDate", DDate)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Checkroll].[CRGangMasterSelectAll]", params).Tables(0)
        Return dt


    End Function

    Public Shared Function CRDailyAttendanceWithTeamSumHK( _
    ByVal TeamName As String, _
    ByVal RDate As Date) As Decimal

        ' Senin, 14 Sep 2009, 13:19
        Dim DT As DataTable = New DataTable
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim adapter As New Common_DAL.SQLHelp

        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@TeamName", SqlDbType.NVarChar)
        params(0).Value = TeamName

        params(1) = New SqlParameter("@RDate", SqlDbType.DateTime)
        params(1).Value = RDate

        Dim JmlHK As Nullable(Of Decimal) = 0
        Dim obj As Object

        Try
            obj = adapter.ExecuteScalar("[Checkroll].[CRDailyAttendanceWithTeamSumHK]", params)
            If obj IsNot System.DBNull.Value Then
                JmlHK = CType(obj, Decimal)
            End If
        Catch ex As Exception

        End Try

        Return JmlHK
    End Function

    Public Shared Function CRDailyAttendanceWithTeamSumOT( _
        ByVal EstateID As String, _
        ByVal TeamName As String, _
        ByVal RDate As Date) As Decimal

        ' 'Jum'at 2 Oct 2009, 02:20
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("TeamName", SqlDbType.NVarChar, 50)
        params(1).Value = TeamName

        params(2) = New SqlParameter("RDate", SqlDbType.Date)
        params(2).Value = RDate

        Dim SumTotalOT As Decimal = 0
        Dim obj As Object

        Try
            obj = adapter.ExecuteScalar("[Checkroll].[CRDailyAttendanceWithTeamSumOT]", params)
            If obj IsNot System.DBNull.Value Then
                SumTotalOT = CType(obj, Decimal)
            End If
        Catch ex As Exception

        End Try

        Return SumTotalOT
    End Function

    Public Shared Function CRAttendanceHK() As DataTable

        Dim DT As DataTable = New DataTable
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim adapter As New Common_DAL.SQLHelp

        Dim params(0) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        DT = objdb.ExecQuery("[Checkroll].[CRAttendanceHK]", params).Tables(0)
        Return DT

    End Function
    Public Shared Function CRDailyAttendanceWithTeamView( _
    ByVal UseMonthYearLogin As Boolean, _
    ByVal TeamName As String, _
    ByVal MandorName As String, _
    ByVal Activity As String, _
    ByVal RDate As Date, OilRubber As String) As DataTable

        ' Senin, 14 Sep 2009, 13:19
        Dim DT As DataTable = New DataTable
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(6) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@UseMonthYearLogin", SqlDbType.Bit)
        params(1).Value = UseMonthYearLogin

        params(2) = New SqlParameter("@TeamName", SqlDbType.NVarChar)
        params(2).Value = TeamName

        params(3) = New SqlParameter("@MandorName", SqlDbType.NVarChar)
        params(3).Value = MandorName

        params(4) = New SqlParameter("@Activity", SqlDbType.NVarChar)
        params(4).Value = Activity

        params(5) = New SqlParameter("@RDate", SqlDbType.Date)
        params(5).Value = RDate

        params(6) = New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar)
        params(6).Value = GlobalPPT.strActMthYearID

        If OilRubber = "OilPalm" Then
            DT = adapter.ExecQuery("Checkroll.[CRDailyAttendanceWithTeamView]", params).Tables(0)
        ElseIf OilRubber = "Rubber" Then
            DT = adapter.ExecQuery("[Checkroll].[CRDailyAttendanceWithTeamViewRubber]", params).Tables(0)
        End If

        Return DT
    End Function

    Public Shared Function CRAttendanceSetupSelect(ByVal AttendanceCode As String, ByVal AttendType As String) As DataTable
        'Senin, 14 Sep 2009, 13:19
        Dim DT As DataTable
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = Common_PPT.GlobalPPT.strEstateID

        params(1) = New SqlParameter("AttendType", SqlDbType.NVarChar, 50)
        params(1).Value = AttendType

        params(2) = New SqlParameter("@AttendanceCode", SqlDbType.NVarChar, 50)
        params(2).Value = AttendanceCode

        DT = adapter.ExecQuery("Checkroll.CRAttendanceSetupSelect", params).Tables(0)

        Return DT

    End Function


    Public Shared Function CRDailyTeamActivityGangMasterIDIsExist( _
        ByVal DDate As Date, _
        ByVal DailyTeamActivityID As String, _
        ByVal MandoreID As String, _
        ByVal KraniID As String) As DataTable

        'Jum'at, 16 Oct 2009, 16:45
        Dim DT As DataTable
        Dim params(4) As SqlParameter
        Dim adapter As New Global.Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@DDate", SqlDbType.Date)
        params(1).Value = DDate

        params(2) = New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50)
        params(2).Value = DailyTeamActivityID

        params(3) = New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50)
        params(3).Value = MandoreID

        params(4) = New SqlParameter("@KraniID", SqlDbType.NVarChar, 50)
        params(4).Value = KraniID

        DT = adapter.ExecQuery("Checkroll.CRDailyTeamActivityGangMasterIDIsExist", params).Tables(0)
        Return DT

    End Function

    Public Shared Function CRDailyTeamActivityUpdateMandorKraniPremi( _
        ByVal DDate As Date, _
        ByVal DailyTeamActivityID As String, _
        ByVal GangMasterID As String, _
        ByVal MandoreID As String, _
        ByVal KraniID As String, _
        ByVal MandorPremi As Double, _
        ByVal KraniPremi As Double) As Integer

        ' Sabtu, 17 Oct 2009, 01:31
        ' Place Kebun REA
        Dim params(6) As SqlParameter
        Dim adapter As New Global.Common_DAL.SQLHelp
        Dim rowAffected As Integer

        params(0) = New SqlParameter("@DDate", SqlDbType.Date)
        params(0).Value = DDate

        params(1) = New SqlParameter("@DailyTeamActivityID", SqlDbType.NVarChar, 50)
        params(1).Value = DailyTeamActivityID

        params(2) = New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50)
        params(2).Value = GangMasterID

        params(3) = New SqlParameter("@MandoreID", SqlDbType.NVarChar, 50)
        params(3).Value = MandoreID

        params(4) = New SqlParameter("@KraniID", SqlDbType.NVarChar, 50)
        params(4).Value = KraniID

        params(5) = New SqlParameter("@MandorPremi", SqlDbType.Decimal)
        params(5).Value = MandorPremi

        params(6) = New SqlParameter("@KraniPremi", SqlDbType.Decimal)
        params(6).Value = KraniPremi

        rowAffected = adapter.ExecNonQuery("Checkroll.CRDailyTeamActivityUpdateMandorKraniPremi", params)
        Return rowAffected

    End Function

    Public Shared Function CRDailyReceiptionSumPremiValue( _
    ByVal RDate As Date, _
    ByVal GangMasterID As String) As Decimal

        Dim SumPremiValue As Decimal = 0

        Dim params(1) As SqlParameter
        Dim adapter As New Global.Common_DAL.SQLHelp

        params(0) = New SqlParameter("@RDate", SqlDbType.Date)
        params(0).Value = RDate

        params(1) = New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50)
        params(1).Value = GangMasterID

        SumPremiValue = adapter.ExecuteScalar("Checkroll.CRDailyReceiptionSumPremiValue", params)

        Return SumPremiValue

    End Function

    Public Shared Function AttendSummaryWithTeam(ByVal Empid As String) As DataTable
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@Empid", Empid)
        dt = objdb.ExecQuery("[Checkroll].[AttendSummaryWithTeam]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function CRPHoliday(ByVal PHDate As Date) As DataTable
        Dim dt As DataTable
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar).Value = GlobalPPT.strEstateID
        params(1) = New SqlParameter("@PHDate", SqlDbType.DateTime).Value = PHDate

        dt = objdb.ExecQuery("[Checkroll].CRPHoliday", params).Tables(0)
        Return dt
    End Function

    Public Shared Function GetMaxOTHours(ByVal EmpCode As String, ByVal Rdate As Date) As DataTable
        Dim dt As New DataTable
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EmpCode", EmpCode)
        params(1) = New SqlParameter("@RDate", Rdate)

        dt = objdb.ExecQuery("Checkroll.GetMaxOTHours", params).Tables(0)
        Return dt
    End Function
End Class
