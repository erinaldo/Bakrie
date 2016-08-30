'
' Programmer: Dadang Adi Hendradi
' Created   : Kamis, 3 Sep 2009, 13:20
' Modified  : Kamis, 15 Oct 2009, 19:10
'

Imports System.Data.SqlClient
Imports System.Configuration

Imports CheckRoll_PPT
Imports Common_PPT
Imports Common_DAL
Imports System.Windows.Forms

Public Class Census_DAL

    Private Shared _selectCommand As SqlCommand = Nothing
    Private Shared _insertCommand As SqlCommand = Nothing
    Private Shared _updateCommand As SqlCommand = Nothing
    Private Shared _deleteCommand As SqlCommand = Nothing

    Private _adapter As SqlDataAdapter
    Private _conn As SqlConnection = Nothing
    Private Shared connString As String

    Public Sub New()
        'connString = EncryptDAL.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings("BSP").ConnectionString())
        '_conn.ConnectionString = connString

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
        'Set(ByVal value As SqlDataAdapter)

        'End Set
    End Property

    Private Sub InitAdapter()
        Me._adapter = New SqlDataAdapter()

        Me._adapter.InsertCommand = New SqlCommand()
        Me._adapter.InsertCommand.Connection = Me.Connection
        Me._adapter.InsertCommand.CommandText = "Checkroll.CensusInsert"
        Me._adapter.InsertCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CensusID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "CensusID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstateCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateCode", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CensusDate", SqlDbType.Date, 3, ParameterDirection.Input, 0, 0, "CensusDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AreaPlanted", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "AreaPlanted", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PlantdensityRequired", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "PlantdensityRequired", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PlantDensityActual", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "PlantDensityActual", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PorosinArea", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "PorosinArea", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MainRoadInArea", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "MainRoadInArea", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CollectionRoadInArea", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "CollectionRoadInArea", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@NoOfBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "NoOfBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalFFB", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "TotalFFB", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CreatedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "CreatedOn", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))


        '---------
        ' Update Command
        Me._adapter.UpdateCommand = New SqlCommand()
        Me._adapter.UpdateCommand.Connection = Connection
        Me._adapter.UpdateCommand.CommandText = "Checkroll.CensusUpdate"
        Me._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CensusID", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, 0, 0, "CensusID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstateID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "EstateID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActiveMonthYearID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ActiveMonthYearID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CensusDate", SqlDbType.Date, 3, ParameterDirection.Input, 0, 0, "CensusDate", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DivID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "DivID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@YOPID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "YOPID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BlockID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "BlockID", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AreaPlanted", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "AreaPlanted", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PlantdensityRequired", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "PlantdensityRequired", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PlantDensityActual", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "PlantDensityActual", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PorosinArea", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "PorosinArea", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MainRoadInArea", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "MainRoadInArea", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CollectionRoadInArea", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "CollectionRoadInArea", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@NoOfBunches", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 0, "NoOfBunches", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalFFB", SqlDbType.Decimal, 9, ParameterDirection.Input, 18, 3, "TotalFFB", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ConcurrencyId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, 0, 0, "ConcurrencyId", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ModifiedBy", DataRowVersion.Current, False, Nothing, "", "", ""))
        Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ModifiedOn", SqlDbType.DateTime, 8, ParameterDirection.Input, 23, 3, "ModifiedOn", DataRowVersion.Current, False, Nothing, "", "", ""))

        '------
        ' Delete Command
        Me._adapter.DeleteCommand = New SqlCommand()
        Me._adapter.DeleteCommand.Connection = Connection
        Me._adapter.DeleteCommand.CommandText = "Checkroll.CensusDelete"
        Me._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure

        Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@CensusID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CensusID", DataRowVersion.Current, False, Nothing, "", "", ""))

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
        _selectCommand.CommandText = "Checkroll.[CRCensusByDateSelect]"
        _selectCommand.CommandType = CommandType.StoredProcedure

        Dim param As SqlParameter = New SqlParameter()

        param = _selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@CensusStartDate", SqlDbType.Date, 3)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@CensusEndDate", SqlDbType.Date, 3)
        param.Direction = ParameterDirection.Input

        param = _selectCommand.Parameters.Add("@ActiveMonthYearID", SqlDbType.NVarChar, 50)
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

    'Private Sub InitCommand()
    '    ' Ahad, 06 Sep 2009, 02:58
    '    If selectCommand Is Nothing Then

    '    End If
    'End Sub

    Public Function CensusSelectByDate( _
            ByVal CensusStartDate As System.Nullable(Of Date), _
            ByVal CensusEndDate As System.Nullable(Of Date)) As DataTable

        ' Jum'at, 4 Sep 2009, 21:13
        Dim DT_CENSUS As DataTable = New DataTable("DT_CENSUS")

        Adapter.SelectCommand = SelectCommand

        Adapter.SelectCommand.Parameters("@EstateID").Value = GlobalPPT.strEstateID

        If (CensusStartDate.HasValue) Then
            Adapter.SelectCommand.Parameters("@CensusStartDate").Value = CensusStartDate
        Else
            Adapter.SelectCommand.Parameters("@CensusStartDate").Value = System.DBNull.Value
        End If

        If CensusEndDate.HasValue Then
            Adapter.SelectCommand.Parameters("@CensusEndDate").Value = CensusEndDate
        Else
            Adapter.SelectCommand.Parameters("@CensusEndDate").Value = System.DBNull.Value
        End If
        Adapter.SelectCommand.Parameters("@ActiveMonthYearID").Value = GlobalPPT.strActMthYearID


        DT_CENSUS.Clear()
        Adapter.Fill(DT_CENSUS)

        Return DT_CENSUS
    End Function

    Public Overridable Overloads Function Update(ByVal dataTable As Global.System.Data.DataTable) As Integer
        ' update: Saturday, 24 Oct 2009, 19:12
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

    Public Shared Function UpdateCensus(ByVal objCensus As Census_DAL, ByRef DT As System.Data.DataTable) As Integer
        ' Jum'at, 16 Oct 2009, 15:15
        Return objCensus.Update(DT)
    End Function


    Public Shared Function CRCensusByDateSelect( _
        ByVal CensusStartDate As System.Nullable(Of Date), _
        ByVal CensusEndDate As System.Nullable(Of Date)) As DataTable


        ' Kamis, 15 Oct 2009, 19:12
        Dim adapter As New SQLHelp
        Dim param(3) As SqlParameter
        Dim dt As DataTable

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'If CensusStartDate = "01/01/1900" Then
        '    CensusStartDate = ""
        'End If
        'If CensusEndDate = "01/01/1900" Then
        '    CensusEndDate = ""
        'End If


        param(1) = New SqlParameter("@CensusStartDate", CensusStartDate)
        param(2) = New SqlParameter("@CensusEndDate", CensusEndDate)
        param(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)


        dt = adapter.ExecQuery("Checkroll.[CRCensusByDateSelect]", param).Tables(0)

        Return dt
    End Function

    Public Shared Function CRSubBlockSelect(ByVal BlockName As String) As DataTable

        Dim DT As DataTable
        Dim params(1) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@BlockName", SqlDbType.NVarChar, 50)
        params(1).Value = BlockName

        DT = adapter.ExecQuery("Checkroll.[CRBlockSelect]", params).Tables(0)

        Return DT
        ' ini akan mengembalikan fields:
        ' BlockID, BlockName,
        ' YOPID, YOP,
        ' EstateID, EstateName,
        ' DivID, DivName

    End Function


    Public Sub AddToGrid(ByRef dt As DataTable, ByVal objPPT As Census_PPT)
        ' Kamis, 15 Oct 2009, 22:38
        Dim newDataRow As System.Data.DataRow = dt.NewRow()

        newDataRow.Item("CensusDate") = objPPT.CensusDate
        newDataRow.Item("DivName") = objPPT.DivName
        newDataRow.Item("YOP") = objPPT.YOP
        newDataRow.Item("BlockName") = objPPT.BlockName
        newDataRow.Item("AreaPlanted") = objPPT.AreaPlanted
        newDataRow.Item("PlantDensityRequired") = objPPT.PlantdensityRequired
        newDataRow.Item("PlantDensityActual") = objPPT.PlantDensityActual
        newDataRow.Item("PorosInArea") = objPPT.PorosinArea
        newDataRow.Item("MainRoadInArea") = objPPT.MainRoadInArea
        newDataRow.Item("CollectionRoadInArea") = objPPT.CollectionRoadInArea
        newDataRow.Item("NoOfBunches") = objPPT.NoOfBunches
        newDataRow.Item("TotalFFB") = objPPT.TotalFFB
        newDataRow.Item("BlockID") = objPPT.BlockID
        newDataRow.Item("DivID") = objPPT.DivID
        newDataRow.Item("YOPID") = objPPT.YOPID
        newDataRow.Item("CensusID") = String.Empty
        newDataRow.Item("EstateID") = GlobalPPT.strEstateID
        newDataRow.Item("EstateCode") = GlobalPPT.strEstateCode
        newDataRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        newDataRow.Item("CreatedBy") = GlobalPPT.strUserName
        newDataRow.Item("CreatedOn") = Date.Now
        newDataRow.Item("ModifiedBy") = GlobalPPT.strUserName
        newDataRow.Item("ModifiedOn") = Date.Now

        dt.Rows.Add(newDataRow)

    End Sub

End Class
