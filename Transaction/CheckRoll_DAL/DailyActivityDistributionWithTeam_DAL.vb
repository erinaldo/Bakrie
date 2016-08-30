'----------------------------------------
'
' Programmer: Dadang Adi Hendradi
' Created   : Senin, 14 Sep 2009, 22:21
' Modified  : Selasa, 20 Oct 2009, 10:27 
' Modified  : Selasa, 27 Oct 2009, 10:10
'----------------------------------------

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Imports CheckRoll_PPT
Imports Common_PPT
Imports Common_DAL
Imports System.Windows.Forms

Public Class DailyActivityDistributionWithTeam_DAL

    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection
    Private Shared connString As String
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
        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyActivityDistributionWithTeamInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DistbDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "DistbDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "GangMasterID", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmpID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EmpID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContractID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ContractID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@COAID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "COAID", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Jum'at, 20 Nov 2009, 14:06
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OvertimeCOAID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OvertimeCOAID", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' END Jum'at, 20 Nov 2009, 14:06
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StationID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T0", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T0", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T1", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T2", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T3", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T4", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Mandays", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Mandays", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Ha", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Ha", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UOMID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "UOMID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Brondolan", SqlDbType.Decimal, 8, ParameterDirection.Input, 18, 0, "Brondolan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MachineID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MachineID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@VhID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "VehicleId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@VHDetailCostCodeID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DetailCostId", DataRowVersion.Current, False, Nothing, "", "", ""))
        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyActivityDistributionWithTeamUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DistbDate", SqlDbType.Date, 8, ParameterDirection.Input, 0, 0, "DistbDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GangMasterID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "GangMasterID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalOT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "TotalOT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContractID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ContractID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@COAID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "COAID", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Jum'at, 20 Nov 2009, 14:40
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OvertimeCOAID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "OvertimeCOAID", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Jum'at, 20 Nov 2009, 14:40
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StationID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T0", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T0", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T1", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T2", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T3", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T4", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Mandays", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Mandays", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Ha", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "Ha", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UOMID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "UOMID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OT", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OT", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Brondolan", SqlDbType.Decimal, 8, ParameterDirection.Input, 18, 0, "Brondolan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MachineID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "MachineID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VhID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "VehicleID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VHDetailCostCodeID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DetailCostId", DataRowVersion.Current, False, Nothing, "", "", ""))
        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyActivityDistributionWithTeamDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@DailyDistributionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyDistributionID", DataRowVersion.Current, False, Nothing, "", "", ""))

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
        _selectCommand.CommandText = "Checkroll.DailyActivityDistributionWithTeamSelect"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter '= New SqlParameter()

        param = _selectCommand.Parameters.Add("@TeamName", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@DistbDate", SqlDbType.Date, 8)
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

    Public Shared Function DailyActivityDistributionWithTeamSelect( _
        ByVal TeamName As String, _
        ByVal DistbDate As String) As DataTable

        ' Thursday, 10 SEP 2009, 11:06
        ' Selasa, 20 Oct 2009, 12:54 -> use SQLHelp
        Dim DT As DataTable = New DataTable
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@TeamName", SqlDbType.NVarChar)
        params(1).Value = TeamName

        params(2) = New SqlParameter("@DistbDate", SqlDbType.Date)
        params(2).Value = DistbDate

        DT = adapter.ExecQuery("Checkroll.DailyActivityDistributionWithTeamSelect", params).Tables(0)

        Return DT

    End Function

    Public Shared Function CRDailyActivityDistributionWithTeamView( _
        ByVal UseMonthYearLogin As String, _
        ByVal TeamName As String, _
        ByVal MandorName As String, _
        ByVal Activity As String, _
        ByVal DistbDate As Date) As DataTable

        ' Senin, 14 Sep 2009, 13:19

        Dim DT As DataTable
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

        params(5) = New SqlParameter("@DistbDate", SqlDbType.Date)
        params(5).Value = DistbDate

        params(6) = New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar)
        params(6).Value = GlobalPPT.strActMthYearID

        DT = AdvancePayment_DAL.ExecuteQuery("Checkroll.[CRDailyActivityDistributionWithTeamView]", params)
        Return DT

    End Function

    Public Shared Function getConnection() As System.Data.SqlClient.SqlConnection
        ' Selasa, 22 Sep 2009, 02:51
        Dim conn As SqlConnection = New SqlConnection()

        Dim connString As String = _
                    Common_PPT.GlobalPPT.ConnectionString

        conn.ConnectionString = connString

        Return conn
    End Function

    Public Shared Function Checkroll_UOMSelect() As DataTable

        ' Selasa, 22 Sep 2009, 02:48
        ' Selasa, 20 Oct 2009, 12:54 -> use SQLHelp
        Dim DT As DataTable = New DataTable
        Dim adapter As New Common_DAL.SQLHelp

        DT = adapter.ExecQuery("Checkroll.CRUOMSelect").Tables(0)

        Return DT
    End Function

    Public Shared Function Checkroll_CRTAnalisysSelect( _
        ByVal TAnalisysID As String, _
        ByVal TAnalisysCode As String, _
        ByVal TValue As String) As DataTable

        ' Selasa, 22 Sep 2009, 06:21
        ' Selasa, 20 Oct 2009, 12:51 -> use SQLHelp
        Dim DT As DataTable
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@TAnalisysID", SqlDbType.NVarChar)
        params(1).Value = TAnalisysID

        params(2) = New SqlParameter("@TAnalisysCode", SqlDbType.NVarChar)
        params(2).Value = TAnalisysCode

        params(3) = New SqlParameter("@TValue", SqlDbType.NVarChar)
        params(3).Value = TValue


        DT = adapter.ExecQuery("Checkroll.CRTAnalysisSelect", params).Tables(0)

        Return DT
    End Function

    Public Shared Function CRDailyActivityDistributionIsExist( _
        ByVal GangMasterID As String, _
        ByVal DistbDate As Date) As Global.System.Data.DataTable

        ' Selasa, 20 Oct 2009, 11:02
        Dim DT As DataTable
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@GangMasterID", SqlDbType.NVarChar)
        params(1).Value = GangMasterID

        params(2) = New SqlParameter("@DistbDate", SqlDbType.Date)
        params(2).Value = DistbDate

        DT = adapter.ExecQuery("Checkroll.CRDailyActivityDistributionIsExist", params).Tables(0)

        Return DT
    End Function

    Public Shared Function CRMaterialForDailyActivityDistributionIsExist( _
    ByVal GangMasterID As String, _
    ByVal DistbDate As Date) As Global.System.Data.DataTable

        ' Selasa, 20 Oct 2009, 11:02
        Dim DT As DataTable
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@GangMasterID", SqlDbType.NVarChar)
        params(1).Value = GangMasterID

        params(2) = New SqlParameter("@DistbDate", SqlDbType.Date)
        params(2).Value = DistbDate

        DT = adapter.ExecQuery("Checkroll.CRMaterialForDailyActivityDistributionIsExist", params).Tables(0)

        Return DT
    End Function

    Public Shared Sub CRDistributionSummary()
        ' Selasa, 29 Dec 2009, 18:08
        ' Place: Kuala Lumpur
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
 
        Try
            adapter.ExecNonQuery("[Checkroll].[CRDistributionSummary]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Shared Sub CRDistributionActivitySummary()
        ' Selasa, 29 Dec 2009, 18:12
        ' Place: Kuala Lumpur
        Dim params(2) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)

        Try
            adapter.ExecNonQuery("[Checkroll].[CRDistributionActivitySummary]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Shared Sub CRDistributionSummary_Daily(ByVal strDistDate As String)
        ' Place: Kuala Lumpur
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        params(3) = New SqlParameter("@DistDate", strDistDate)

        Try
            adapter.ExecNonQuery("[Checkroll].[CRDistributionSummaryDaily]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Shared Sub CRDistributionActivitySummary_Daily(ByVal strDistDate As String)
        ' Selasa, 29 Dec 2009, 18:12
        ' Place: Kuala Lumpur
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        params(3) = New SqlParameter("@DistDate", strDistDate)

        Try
            adapter.ExecNonQuery("[Checkroll].[CRDistributionActivitySummaryDaily]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
