Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports Common_DAL
Public Class DistributionSetupLookup
    Public _DistributionDescp As String = String.Empty
    Public _DistributionSetupID As String = String.Empty
    Public _COAID As String = String.Empty
    Private Sub dgvStockCategory_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Public Property DistributionDescp() As String
        Get
            Return _DistributionDescp
        End Get
        Set(ByVal value As String)
            _DistributionDescp = value
        End Set
    End Property

    Public Property DistributionSetupID() As String
        Get
            Return _DistributionSetupID
        End Get
        Set(ByVal value As String)
            _DistributionSetupID = value
        End Set
    End Property

    Public ReadOnly Property COAID() As String
        Get
            Return _COAID
        End Get
    End Property

    Private Sub dgvStockCategory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Ahad, 13 Sep 2009, 23:27
        If dgv.Rows.Count > 0 Then
            If dgv.CurrentCell IsNot Nothing Then

                DistributionDescp = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString()
                DistributionSetupID = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If
        End If
    End Sub

    Private Sub dgvStockCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            If dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString() <> Nothing Then
                DistributionDescp = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString()
            End If
            If dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString() <> Nothing Then
                DistributionSetupID = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString()
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub DistributionSetupLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Ahad, 13 Sep 2009, 23:08
        Dim DT As DataTable = New DataTable

        'Dim connString As String = EncryptDAL.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings("BSP").ConnectionString())
        Dim connString As String = Common_PPT.GlobalPPT.ConnectionString

        Dim conn As SqlConnection = New SqlConnection(connString)

        'Dim param As SqlParameter = New SqlParameter()
        Dim selectCommand As SqlCommand = New SqlCommand()
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()

        conn.Open()

        selectCommand.Connection = conn
        selectCommand.CommandType = CommandType.StoredProcedure
        selectCommand.CommandText = "Checkroll.CRDistributionSetupLookup"

        selectCommand.Parameters.Add("@DistributionDescp", SqlDbType.NVarChar).Value = DistributionDescp
        selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar).Value = GlobalPPT.strEstateID
        selectCommand.Parameters.Add("@DistributionSetupID", SqlDbType.NVarChar).Value = ""
        ' ini akan mengembalikan fields:
        ' DistributionSetupID, DistributionDescp, IsLocation, COAID

        adapter.SelectCommand = selectCommand
        Try
            adapter.Fill(DT)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        conn.Close()
        'Return DT_TEAM
        dgv.DataSource = DT
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.DoubleClick
        If dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString() <> Nothing Then
            DistributionDescp = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString()
        End If
        If dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString() <> Nothing Then
            DistributionSetupID = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString()
        End If


        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgv.Rows.Count > 0 Then
                If dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString() <> Nothing Then
                    DistributionDescp = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionDescp").Value.ToString()
                End If
                If dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString() <> Nothing Then
                    DistributionSetupID = dgv.Rows(dgv.CurrentCell.RowIndex).Cells("DistributionSetupID").Value.ToString()
                End If

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtStationName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStationName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim connString As String = _
            Common_PPT.GlobalPPT.ConnectionString

            Dim conn As SqlConnection = New SqlConnection(connString)
            Dim param As SqlParameter = New SqlParameter()
            Dim selectCommand As SqlCommand = New SqlCommand()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            Dim DT As DataTable = New DataTable
            conn.Open()

            selectCommand.Connection = conn
            selectCommand.CommandType = CommandType.StoredProcedure
            selectCommand.CommandText = "Checkroll.CRDistributionSetupLookup"

            selectCommand.Parameters.Add("@DistributionDescp", SqlDbType.NVarChar).Value = DistributionDescp
            selectCommand.Parameters.Add("@EstateID", SqlDbType.NVarChar).Value = GlobalPPT.strEstateID
            selectCommand.Parameters.Add("@DistributionSetupID", SqlDbType.NVarChar).Value = ""
            ' ini akan mengembalikan fields:
            ' DistributionSetupID, DistributionDescp, IsLocation, COAID

            adapter.SelectCommand = selectCommand
            Try
                adapter.Fill(DT)
                If DT.Rows.Count = 0 Then
                    MsgBox("Data could not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtStationName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStationName.TextChanged

    End Sub

    Private Sub txtStationCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStationCode.KeyDown

    End Sub

    Private Sub txtStationCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStationCode.TextChanged

    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click

    End Sub
End Class