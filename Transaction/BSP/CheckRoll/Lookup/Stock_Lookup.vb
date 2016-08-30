Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT

Public Class Stock_Lookup
    Public _GlobatPtt As New GlobalPPT
    Public _StockCode As String = String.Empty
    Public _StockId As String = String.Empty
    Public _StockDescp As String = String.Empty
    Public _UOM As String = String.Empty
    Public _PartNo As String = String.Empty

    Private Sub Stock_Lookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Ahad, 29 Nov 2009, 05:35
        ' By Dadang Adi H
        ' Ini gua non-aktifkan, soalnya cmbCategory.DataSource nya gua isi
        ' maka g perlu lg manggil Items.Clear()
        'cmbCategory.Items.Clear()
        ' END Ahad, 29 Nov 2009, 05:35

        cmbCategory.Text = ""
        txtStockCode.Text = ""
        txtStockDesc.Text = ""
        lblCategoryId.Text = ""
        dgvStock.DataSource = Nothing

        Dim DTStCatExist As DataTable

        DTStCatExist = CheckRoll_BOL.LookUpBOL.CRSTCategoryIsExist(lblCategoryId.Text)

        ' Modified by Dadang Adi Hendradi
        ' Senin, 23 Nov 2009, 01:24
        ' Adding StockDescp in parameters and where clause
        'For i = 0 To DTStCatExist.Rows.Count - 1
        '    Dim desc As String
        '    desc = DTStCatExist.Rows(i).Item("STCategoryDescp").ToString()
        '    cmbCategory.Items.Add(desc)
        'Next i
        cmbCategory.DataSource = DTStCatExist
        cmbCategory.DisplayMember = "STCategoryDescp"
        cmbCategory.ValueMember = "STCategoryID"

        dgvStock.DefaultCellStyle.BackColor = Color.White
        'dgvStock.Columns.Item("STCategoryID").Visible = False
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedIndexChanged

        'Dim DTStCatExist As DataTable = New DataTable
        'DTStCatExist = CheckRoll_BOL.LookUpBOL.CRSTCategoryIsSelect(cmbCategory.Text)
        'If DTStCatExist.Rows.Count > 0 Then
        '    lblCategoryId.Text = DTStCatExist.Rows(0).Item("STCategoryID").ToString()
        'End If
        txtStockCode.Focus()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvStock_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvStock.DoubleClick
        ' by Dadang Adi H
        ' Ahad, 29 Nov 2009, 05:38
        ' Adding condition If Record count > 0 And CurrentCell is not nothing

        If dgvStock.Rows.Count > 0 Then
            If dgvStock.CurrentCell IsNot Nothing Then

                Me.DialogResult = DialogResult.OK
                Me._StockId = dgvStock.SelectedRows(0).Cells("StockID").Value
                If dgvStock.SelectedRows(0).Cells("StockCode").Value.ToString <> Nothing Then
                    Me._StockCode = dgvStock.SelectedRows(0).Cells("StockCode").Value
                End If

                If dgvStock.SelectedRows(0).Cells("StockDesc").Value.ToString <> Nothing Then
                    Me._StockDescp = dgvStock.SelectedRows(0).Cells("StockDesc").Value
                End If

                If dgvStock.SelectedRows(0).Cells("PartNo").Value.ToString <> Nothing Then
                    Me._PartNo = dgvStock.SelectedRows(0).Cells("PartNo").Value
                End If
                If dgvStock.SelectedRows(0).Cells("UOM").Value.ToString <> Nothing Then
                    Me._UOM = dgvStock.SelectedRows(0).Cells("UOM").Value
                End If

                Me.Close()

            End If
        End If
        ' END Ahad, 29 Nov 2009, 05:38

    End Sub

    Private Sub dgvStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = DialogResult.OK
            Me._StockId = dgvStock.SelectedRows(0).Cells("StockID").Value
            Me._StockCode = dgvStock.SelectedRows(0).Cells("StockCode").Value
            Me._StockDescp = dgvStock.SelectedRows(0).Cells("StockDesc").Value
            Me.Close()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockCode.KeyDown
        If e.KeyCode = Keys.Enter Then

            ' Modified by Dadang Adi Hendradi
            ' Senin, 23 Nov 2009, 01:03
            ' Adding StockDescp in parameters and where clause
            Dim DTSTMasterExist As DataTable

            If cmbCategory.SelectedValue Is Nothing Then
                Return
            End If

            Dim categoryID As String = cmbCategory.SelectedValue.ToString()

            DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist( _
                                                    categoryID, _
                                                    txtStockCode.Text, _
                                                    txtStockDesc.Text)

            If DTSTMasterExist.Rows.Count = 0 Then
                MsgBox("Stock Code is not valid", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")

            ElseIf DTSTMasterExist.Rows.Count > 0 Then
                dgvStock.DataSource = DTSTMasterExist
            End If

        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'If String.IsNullOrEmpty(cmbCategory.Text) Or String.IsNullOrEmpty(lblCategoryId.Text) Then
        If cmbCategory.SelectedValue Is Nothing Then

            MsgBox("Please select Category Stock ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")

            'ElseIf cmbCategory.Text <> Nothing And lblCategoryId.Text <> Nothing Then

        Else

            Dim DTSTMasterExist As DataTable
            Dim CategoryID As String = cmbCategory.SelectedValue.ToString()

            DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist( _
                                                    CategoryID, _
                                                    txtStockCode.Text, _
                                                    txtStockDesc.Text)
            dgvStock.DataSource = DTSTMasterExist
            dgvStock.Columns.Item("StockID").Visible = False
            dgvStock.Columns.Item("EstateID").Visible = False
            dgvStock.Focus()
        End If

    End Sub
End Class