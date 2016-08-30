' Created   : Jumat, 25 Sep 2009, 20:01
' Place     : Balikpapan
'

Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_DAL
Imports Common_BOL
Imports Common_DAL

Public Class NIKByTeamCategoryLookUp

    Public EmpCode As String = String.Empty
    Public EmpName As String = String.Empty
    Public EmpID As String = String.Empty
    Public Category As String = String.Empty
    Public TransferLocation As String = String.Empty

    Private Function NikNameByCategorySelect( _
        ByVal EmpCode As String, _
        ByVal EmpName As String, _
        ByVal Category As String) As DataTable

        'Dim conn As SqlConnection = DailyReceiptionWithTeam_DAL.getConnection()

        'Dim selectCommand As SqlCommand = New SqlCommand()
        'Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        Dim adapter As New SQLHelp
        Dim DT As DataTable = Nothing
        Dim params(3) As SqlParameter


        'conn.Open()
        'selectCommand.Connection = conn
        'selectCommand.CommandType = CommandType.StoredProcedure
        'selectCommand.CommandText = "Checkroll.CRNIKNameByCategorySelect"

        'selectCommand.Parameters.Add("@EmpCode", SqlDbType.NVarChar, 50).Value = param_EmpCode
        'selectCommand.Parameters.Add("@EmpName", SqlDbType.NVarChar, 50).Value = param_EmpName
        'selectCommand.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = param_Category
        'selectCommand.Parameters.Add("@EstateId", SqlDbType.NVarChar, 50).Value = GlobalPPT.strEstateID

        'adapter.SelectCommand = selectCommand
        'Try
        '    DT = New DataTable("EMP")
        '    adapter.Fill(DT)
        'Catch ex As Exception

        'End Try

        'conn.Close()

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar, 50)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@EmpCode", SqlDbType.NVarChar, 50)
        params(1).Value = EmpCode

        params(2) = New SqlParameter("@EmpName", SqlDbType.NVarChar, 50)
        params(2).Value = EmpName

        params(3) = New SqlParameter("@Category", SqlDbType.NVarChar, 50)
        params(3).Value = Category

        DT = adapter.ExecQuery("[Checkroll].CRNIKNameByCategorySelect", params).Tables(0)
        Return DT
    End Function

    Private Sub NIKLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Jumat, 25 Sep 2009, 20:05
        Dim DT As DataTable

        DT = NikNameByCategorySelect(EmpCode, EmpName, Category)
        dgvEmp.DataSource = DT
        ManageGridColumn()
        dgvEmp.Focus()

    End Sub

    Private Sub ManageGridColumn()
        ' Ahad, 15 Nov 2009, 22:56
        dgvEmp.Columns("EmpCode").HeaderText = "Nik"
        dgvEmp.Columns("EmpName").HeaderText = "Name"
        dgvEmp.Columns("EmpID").Visible = False
    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim DT As DataTable

        DT = NikNameByCategorySelect(txtNik.Text, txtName.Text, Category)
        dgvEmp.DataSource = DT
        dgvEmp.Focus()
        If DT.Rows.Count = 0 Then
            MsgBox("Your data can not be found", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtNik_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNik.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")

            Dim DT As DataTable

            DT = NikNameByCategorySelect(txtNik.Text, "", Category)
            dgvEmp.DataSource = DT
            dgvEmp.Focus()

            If DT.Rows.Count = 1 Then
                txtNik.Text = DT.Rows(0).Item("EmpCode").ToString()
                txtName.Text = DT.Rows(0).Item("EmpName").ToString()
            End If

        End If


    End Sub

    Private Sub getGridValue()
        ' Jum'at, 25 Sep 2009, 21:09
        If dgvEmp.Rows.Count > 0 Then
            If dgvEmp.CurrentCell IsNot Nothing Then

                Try
                    Dim rowIndex As Integer = dgvEmp.CurrentCell.RowIndex

                    If dgvEmp.Rows(rowIndex).Cells("EmpCode").Value IsNot System.DBNull.Value Then
                        Me.EmpCode = dgvEmp.Rows(rowIndex).Cells("EmpCode").Value.ToString()
                    End If

                    If dgvEmp.Rows(rowIndex).Cells("EmpName").Value IsNot System.DBNull.Value Then
                        Me.EmpName = dgvEmp.Rows(rowIndex).Cells("EmpName").Value.ToString()
                    End If

                    If dgvEmp.Rows(rowIndex).Cells("EmpID").Value IsNot System.DBNull.Value Then
                        Me.EmpID = dgvEmp.Rows(rowIndex).Cells("EmpID").Value.ToString()
                    End If

                    If dgvEmp.Rows(rowIndex).Cells("TransferLocation").Value IsNot System.DBNull.Value Then
                        Me.TransferLocation = dgvEmp.Rows(rowIndex).Cells("TransferLocation").Value.ToString()
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If

    End Sub

    Private Sub dgvEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEmp.KeyDown

        If e.KeyCode = Keys.Enter Then

            getGridValue()

            Me.DialogResult = DialogResult.OK
            Me.Close()

        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub dgvEmp_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmp.CellDoubleClick

        getGridValue()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvEmp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmp.CellContentClick

    End Sub
End Class