'///////////////////////////////////
'
' Programmer:  Dadang Adi Hendradi
' Created on : Jum'at, 10 Sep 2009, 01:44
'

Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Configuration


Imports Common_PPT
Imports Common_DAL
Imports System.Windows.Forms

Public Class DailyReceiptionWithTeam_DAL

    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = Nothing
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
    Public Shared Function loadTPH(ByVal BlockID As String) As DataTable

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BlockID", BlockID)
        Return objdb.ExecQuery("[General].[TPHMasterSelect]", Parms).Tables(0)
    End Function

    Public Shared Function loadHa(ByVal BlockID As String, ByVal TPH As String) As DataTable

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BlockID", BlockID)
        Parms(2) = New SqlParameter("@TPH", TPH)
        Return objdb.ExecQuery("[General].[TPHHaSelect]", Parms).Tables(0)
    End Function
    Private Sub InitAdapter()

        Me._adapter = New SqlDataAdapter()

        '
        ' Insert Command
        Me._adapter.InsertCommand = New System.Data.SqlClient.SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.DailyReceiptionWithTeamInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionWithTeamID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionWithTeamID", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@FKPSerialNo", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "FKPSerialNo", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OTHours", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTHours", DataRowVersion.Current, False, Nothing, "", "", ""))
        ' Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StationID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IsDrivePremi", SqlDbType.Char, 1, ParameterDirection.Input, 0, 0, "IsDrivePremi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Tonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Tonnage", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PremiValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "PremiValue", DataRowVersion.Current, False, Nothing, "", "", ""))

        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@NActualBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "NActualBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@NPayedBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "NPayedBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@NLooseFruits", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "NLooseFruits", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BActualBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "BActualBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BPayedBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "BPayedBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BLooseFruits", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "BLooseFruits", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TphNormal", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "TphNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UnripeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "UnripeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UnderRipeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "UnderRipeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OverRipeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "OverRipeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RipeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "RipeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@LooseFruitNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "LooseFruitNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscardedNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "DiscardedNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@HarvestedNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "HarvestedNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DeductedNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "DeductedNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaidNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "PaidNormal", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TphBorongan", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "TphBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UnripeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "UnripeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UnderRipeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "UnderRipeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OverRipeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "OverRipeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RipeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "RipeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@LooseFruitBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "LooseFruitBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscardedBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "DiscardedBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@HarvestedBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "HarvestedBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DeductedBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "DeductedBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaidBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "PaidBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Ha", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "Ha", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PremiHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "PremiHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlkHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "BlkHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DeductionLainNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 8, 3, "DeductionLainNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DeductionLainBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 8, 3, "DeductionLainBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyReceiptionDetID", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New System.Data.SqlClient.SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.DailyReceiptionWithTeamUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OTHours", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "OTHours", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@FKPSerialNo", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "FKPSerialNo", DataRowVersion.Current, False, Nothing, "", "", ""))

        ' Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StationID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "StationID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsDrivePremi", SqlDbType.Char, 1, ParameterDirection.Input, 0, 0, "IsDrivePremi", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Tonnage", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "Tonnage", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PremiValue", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "PremiValue", DataRowVersion.Current, False, Nothing, "", "", ""))

        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@NActualBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "NActualBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@NPayedBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "NPayedBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@NLooseFruits", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "NLooseFruits", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BActualBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "BActualBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BPayedBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "BPayedBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        'Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BLooseFruits", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "BLooseFruits", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TphNormal", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "TphNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UnripeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "UnripeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UnderRipeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "UnderRipeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OverRipeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "OverRipeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RipeNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "RipeNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@LooseFruitNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "LooseFruitNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscardedNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "DiscardedNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@HarvestedNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "HarvestedNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DeductedNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "DeductedNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaidNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "PaidNormal", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TphBorongan", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "TphBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UnripeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "UnripeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UnderRipeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "UnderRipeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OverRipeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "OverRipeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RipeBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "RipeBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@LooseFruitBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "LooseFruitBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscardedBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "DiscardedBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@HarvestedBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "HarvestedBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DeductedBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "DeductedBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaidBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "PaidBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Ha", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "Ha", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))

        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PremiHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "PremiHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlkHK", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 2, "BlkHK", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DeductionLainNormal", SqlDbType.Decimal, 9, ParameterDirection.Input, 8, 3, "DeductionLainNormal", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DeductionLainBorongan", SqlDbType.Decimal, 9, ParameterDirection.Input, 8, 3, "DeductionLainBorongan", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "DailyReceiptionDetID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        ''------
        '' Delete Command
        Me._adapter.DeleteCommand = New System.Data.SqlClient.SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.DailyReceiptionWithTeamDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@DailyReceiptionDetID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DailyReceiptionDetID", DataRowVersion.Current, False, Nothing, "", "", ""))

    End Sub


    Public Shared Sub UpdateReceptionTargeDetail(ByVal strDailyReceiptionID As String, ByVal strEmpID As String, ByVal dtRDate As Date)
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        'Dim intLedgerAllModuleRowsAffected As Integer = 0
        Parms(0) = New SqlParameter("@strDailyReceiptionID", strDailyReceiptionID)
        Parms(1) = New SqlParameter("@strEmpID", strEmpID)
        Parms(2) = New SqlParameter("@strActMthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@dtRDate", dtRDate)
        'Dim ds As New DataSet
        objdb.ExecNonQuery("[Checkroll].[DeleteReceptionTargeDetail]", Parms)
    End Sub


    Public Shared Sub DeleteReceptionTargeDetail(ByVal strDailyReceiptionID As String, ByVal strEmpID As String, ByVal dtRDate As Date)
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        'Dim intLedgerAllModuleRowsAffected As Integer = 0
        Parms(0) = New SqlParameter("@strDailyReceiptionID", strDailyReceiptionID)
        Parms(1) = New SqlParameter("@strEmpID", strEmpID)
        Parms(2) = New SqlParameter("@strActMthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@dtRDate", dtRDate)

        'Dim ds As New DataSet
        objdb.ExecNonQuery("[Checkroll].[DeleteReceptionTargeDetail]", Parms)
    End Sub

    Private Sub InitSelectCommand()
        _selectCommand = New System.Data.SqlClient.SqlCommand()
        _selectCommand.Connection = Me.Connection()
        _selectCommand.CommandText = "Checkroll.DailyReceiptionWithTeamSelect"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter = New SqlParameter()

        param = _selectCommand.Parameters.Add("@DailyReceiptionID", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input
        'param = _selectCommand.Parameters.Add("@DailyReceiptionDetID", SqlDbType.NVarChar, 50)
        'param.Direction = ParameterDirection.Input


        'Me.Adapter.SelectCommand = _selectCommand
    End Sub

    'add by shankar
    'Public Function SelectDailyReceiptionDet(ByVal strDailyReceiptionID As String) As DataTable


    '    Dim objdb As New SQLHelp
    '    Dim Parms(0) As SqlParameter
    '    Parms(0) = New SqlParameter("@DailyReceiptionID", strDailyReceiptionID)
    '    'Dim ds As New DataSet
    '    Return objdb.ExecQueryDataTable("[Checkroll].[DailyReceiptionWithTeamSelect]", Parms)
    'End Function


    Public ReadOnly Property SelectCommand() As SqlCommand
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
        Dim returnValue As Integer
        ' update, Senin, 19 Oct 2009, 11:38
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

    Public Function DailyReceiptionWithTeamSelect(ByVal DailyReceiptionID As String) As DataTable
        'Wednesday, 09 SEP 2009, 11:11
        'Update: Saturday, 12 Sep 2009, 08:24

        Dim DT As DataTable = New DataTable

        Me.Adapter.SelectCommand = SelectCommand
        Me.Adapter.SelectCommand.Parameters("@DailyReceiptionID").Value = DailyReceiptionID
        'Me.Adapter.SelectCommand.Parameters("@DailyReceiptionDetID").Value = DailyReceiptionDetID


        DT.Clear()
        Try
            Me.Adapter.Fill(DT)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        Return DT


        'Added by shankar
        'Return SelectDailyReceiptionDet(DailyReceiptionID)

    End Function


    Public Shared Function getConnection() As SqlConnection
        ' Sabtu, 19 SEP 2009, 23:59
        Dim connString As String = _
            Common_PPT.GlobalPPT.ConnectionString

        Dim conn As SqlConnection = New SqlConnection(connString)

        Return conn
    End Function

    Public Function Fill(ByVal DT As DataTable, ByVal DailyReceiptionID As String) As Integer
        ' Ahad, 20 SEP 2009, 00:15

        Me.Adapter.SelectCommand.Parameters("@DailyReceiptionID").Value = DailyReceiptionID

        Dim returnValue As Integer = Me.Adapter.Fill(DT)
        Return returnValue

    End Function


    Public Shared Function DailyReceptionBlkHKPremiValueUpdateProcess(ByVal EmpID As String, _
          ByVal RDate As Date) As System.Data.DataTable

        ''''''''''''''''''''
        ' Monday, 19 Oct 2009, 12:00, Kebun
        Dim DT As New DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(5) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID


        params(1) = New SqlParameter("@EstateCode", SqlDbType.NVarChar)
        params(1).Value = GlobalPPT.strEstateCode

        params(2) = New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar)
        params(2).Value = GlobalPPT.strActMthYearID

        params(3) = New SqlParameter("@CreatedBy", SqlDbType.NVarChar)
        params(3).Value = GlobalPPT.strUserName

        params(4) = New SqlParameter("@EmpID", SqlDbType.NVarChar)
        params(4).Value = EmpID

        params(5) = New SqlParameter("@RDate", SqlDbType.Date)
        params(5).Value = RDate

        DT = adapter.ExecQuery("Checkroll.DailyReceptionBlkHKPremiValueUpdateProcess", params).Tables(0)
        Return DT
    End Function


    Public Shared Function CRPremiSetupSelect( _
        ByVal BlockID As String, _
        ByVal AttendanceSetupID As String) As System.Data.DataTable

        ''''''''''''''''''''
        ' Monday, 19 Oct 2009, 12:00, Kebun
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@BlockID", SqlDbType.NVarChar)
        params(1).Value = BlockID

        params(2) = New SqlParameter("@AttendanceSetupID", SqlDbType.NVarChar)
        params(2).Value = AttendanceSetupID

        DT = adapter.ExecQuery("Checkroll.CRPremiSetupSelect", params).Tables(0)
        Return DT
    End Function

    Public Shared Function CRPremiSpecialRateSetupSelect( _
    ByVal BlockID As String) As System.Data.DataTable

        ''''''''''''''''''''
        ' Monday, 19 Oct 2009, 12:00, Kebun
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@BlockID", SqlDbType.NVarChar)
        params(1).Value = BlockID

        DT = adapter.ExecQuery("Checkroll.CRPremiSpecialRateSetupSelect", params).Tables(0)
        Return DT
    End Function

    Public Shared Function CRDailyReceiptionIsExist( _
        ByVal DailyReceiptionID As String) As System.Data.DataTable

        ''''''''''''''''''''
        ' Monday, 19 Oct 2009, 12:00, Kebun
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@DailyReceiptionID", SqlDbType.NVarChar)
        params(1).Value = DailyReceiptionID

        DT = adapter.ExecQuery("Checkroll.CRDailyReceiptionIsExist", params).Tables(0)
        Return DT
    End Function

    Public Shared Function DailyReceiptionWithTeamReportByDate(ByVal ReceptionDate As DateTime) As System.Data.DataTable

        ''''''''''''''''''''
        ' 5 March 2013
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@Date", SqlDbType.SmallDateTime)
        params(1).Value = ReceptionDate

        DT = adapter.ExecQuery("[Checkroll].[DailyReceiptionWithTeamReportByDate]", params).Tables(0)
        Return DT
    End Function

    Public Shared Function DailyReceiptionWithTeamReportByBlock(ByVal BlockID As String) As System.Data.DataTable

        ''''''''''''''''''''
        ' 5 March 2013
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@BlockID", SqlDbType.NVarChar)
        params(1).Value = BlockID

        DT = adapter.ExecQuery("[Checkroll].[DailyReceiptionWithTeamReportByBlock]", params).Tables(0)
        Return DT
    End Function

    Public Shared Function GetEstateDivisions() As System.Data.DataTable

        ''''''''''''''''''''
        ' 5 March 2013
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.VarChar)
        params(0).Value = GlobalPPT.strEstateID
        params(1) = New SqlParameter("@DivCodeOrName", SqlDbType.VarChar)
        params(1).Value = DBNull.Value
        params(2) = New SqlParameter("@SearchBy", SqlDbType.VarChar)
        params(2).Value = DBNull.Value


        DT = adapter.ExecQuery("[General].[DivisionGET]", params).Tables(0)
        Return DT
    End Function

    Public Shared Function GetBlocksByDivision(ByVal DivID As String) As System.Data.DataTable

        ''''''''''''''''''''
        ' 5 March 2013
        Dim DT As DataTable
        Dim adapter As New Common_DAL.SQLHelp
        Dim params(1) As SqlParameter

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID
        params(1) = New SqlParameter("@DivisionID", SqlDbType.NVarChar)
        params(1).Value = DivID


        DT = adapter.ExecQuery("[General].[BlockSelectByDivision]", params).Tables(0)
        Return DT
    End Function


    'Private Function MergeDataTables(ByVal dtb1 As DataTable, ByVal dtb2 As DataTable, ByVal dtb1MatchField As String, ByVal dtb2MatchField As String) As DataTable
    '    Dim dtbOutput As DataTable = dtb1.Copy
    '    Dim lstSkipFields As New List(Of String)
    '    For Each dcl As DataColumn In dtb2.Columns
    '        Try
    '            dtbOutput.Columns.Add(dcl.ColumnName, dcl.DataType)
    '        Catch ex As DuplicateNameException
    '            lstSkipFields.Add(dcl.ColumnName)
    '        End Try
    '    Next dcl
    '    'Merge dtb2 records that match existing records in dtb1
    '    Dim dtb2Temp As DataTable = dtb2.Copy
    '    For int2 As Integer = dtb2Temp.Rows.Count - 1 To 0 Step -1
    '        Dim drw2 As DataRow = dtb2Temp.Rows(int2)
    '        Dim o2 As Object = drw2(dtb2MatchField)
    '        For Each drw1 As DataRow In dtbOutput.Rows
    '            Dim o1 As Object = drw1(dtb1MatchField)
    '            If o1.ToString = o2.ToString Then
    '                For Each dcl As DataColumn In dtb2Temp.Columns
    '                    If Not lstSkipFields.Contains(dcl.ColumnName) Then
    '                        drw1(dcl.ColumnName) = drw2(dcl.ColumnName)
    '                    End If
    '                Next dcl
    '                dtb2Temp.Rows.Remove(drw2)
    '            End If
    '        Next drw1
    '    Next int2
    '    'add rows that weren't in dtb1
    '    For Each drw2 As DataRow In dtb2Temp.Rows
    '        Dim drw1 As DataRow = dtbOutput.NewRow
    '        For Each dcl As DataColumn In dtb2Temp.Columns
    '            drw1(dcl.ColumnName) = drw2(dcl.ColumnName)
    '        Next dcl
    '        dtbOutput.Rows.Add(drw1)
    '    Next drw2
    '    Return dtbOutput
    'End Function

End Class
