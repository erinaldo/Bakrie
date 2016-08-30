Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient

Public Class ConsignmentStockLookUp

    Public strStockCode As String = String.Empty
    Public strSTConsignmentMasterID As String = String.Empty
    Public strStockDescp As String = String.Empty
    Public strUOM As String = String.Empty
    Public strPartNo As String = String.Empty
    Public strQty As String = String.Empty



    Private Sub Consignmentlookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetUICulture(GlobalPPT.strLang)
        Dim objEstateID As New ConsignmentReceivedPPT
        Dim ds As New DataSet
        Dim objConsignmentReceivedBOL As New ConsignmentReceivedBOL
        ds = objConsignmentReceivedBOL.ConsignmentStockCodeGet(objEstateID, "NO")
        dgvConsignmentStockCode.DataSource = ds.Tables(0)
        If dgvConsignmentStockCode.RowCount <> 0 Then
            lblNoRecordFound.Visible = False
        Else
            lblNoRecordFound.Visible = True
        End If
        ''dgvConsignmentStockCode.Columns("EstateID").Visible = False

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsignmentStockLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            pnlStockCodeLookupSearch.CaptionText = rm.GetString("pnlStockCodeLookupSearch.Text")

            dgvConsignmentStockCode.Columns("STCode").HeaderText = rm.GetString("dgvConsignmentStockCode.Columns(STCode).HeaderText")
            dgvConsignmentStockCode.Columns("STDesc").HeaderText = rm.GetString("dgvConsignmentStockCode.Columns(STDesc).HeaderText")

            lblStockCode.Text = rm.GetString("lblStockCode.Text")

            lblStockDesc.Text = rm.GetString("lblStockDesc.Text")

            lblSearchby.Text = rm.GetString("lblSearchby.Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub dgvConsignmentStockCode_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsignmentStockCode.CellDoubleClick

        ConsignmentStockcodeSelect()

    End Sub

    Private Sub ConsignmentStockcodeSelect()

        If dgvConsignmentStockCode.RowCount <> 0 Then
            Dim objAcctID As New StoreIssueVoucherPPT
            strSTConsignmentMasterID = dgvConsignmentStockCode.CurrentRow.Cells("STConsignmentMasterID").Value.ToString() 'COAID
            strStockCode = dgvConsignmentStockCode.CurrentRow.Cells("STCode").Value.ToString()
            strStockDescp = dgvConsignmentStockCode.CurrentRow.Cells("STDesc").Value.ToString()
            strUOM = dgvConsignmentStockCode.CurrentRow.Cells("UOM").Value.ToString
            strPartNo = dgvConsignmentStockCode.CurrentRow.Cells("PartNo").Value.ToString
            strQty = dgvConsignmentStockCode.CurrentRow.Cells("Qty").Value.ToString
            DialogResult = DialogResult.OK
            Me.Close()
        Else
            lblNoRecordFound.Visible = True
        End If

    End Sub

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)

        If grdname.Rows.Count <> 0 Then
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            If grdname.Rows.Count = 1 Then
                grdname.Rows.RemoveAt(0)
            End If
        End If

    End Sub

    Private Sub btnStcokCodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStcokCodeSearch.Click

        Dim ds As New DataSet
        Dim objConsignmentStockCode As New ConsignmentReceivedPPT
        objConsignmentStockCode.STCode = txtConsignmentStockSearch.Text.Trim()
        objConsignmentStockCode.STDesc = txtConsignmentStockDescsearch.Text.Trim()
        Dim ConsignmentReceivedBOL As New ConsignmentReceivedBOL
        ds = ConsignmentReceivedBOL.ConsignmentStockCodeGet(objConsignmentStockCode, "NO")
        If (ds.Tables(0).Rows.Count <= 0) Then
            lblNoRecordFound.Visible = True
            dgvConsignmentStockCode.AutoGenerateColumns = False
            dgvConsignmentStockCode.DataSource = ds.Tables(0)


            'ClearGridView(dgvConsignmentStockCode)
            ''dgvConsignmentStockCode.Columns("EstateID").Visible = False
        Else
            dgvConsignmentStockCode.AutoGenerateColumns = False
            dgvConsignmentStockCode.DataSource = ds.Tables(0)
            lblNoRecordFound.Visible = False

            ''dgvConsignmentStockCode.Columns("EstateID").Visible = False
        End If

    End Sub

    Private Sub ClearAfterSearch()

        txtConsignmentStockSearch.Text = String.Empty
        txtConsignmentStockDescsearch.Text = String.Empty

    End Sub

    Private Sub dgvConsignmentStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Then
            ConsignmentStockcodeSelect()
            e.Handled = True
        End If
        ''If e.KeyValue = 40 Then
        ''    If dgvConsignmentStockCode.SelectedRows.Count = 0 Then
        ''        dgvConsignmentStockCode.Rows(0).Selected = True
        ''    Else
        ''        If dgvConsignmentStockCode.SelectedRows(0).Index < (dgvConsignmentStockCode.Rows.Count - 1) Then
        ''            Dim intSelectedIndex As Integer = dgvConsignmentStockCode.SelectedRows(0).Index
        ''            dgvConsignmentStockCode.ClearSelection()
        ''            dgvConsignmentStockCode.Rows(intSelectedIndex + 1).Selected = True
        ''        End If
        ''    End If
        ''End If
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvConsignmentStockCode, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvConsignmentStockCode, e)
        'End If

    End Sub

    ''Public Sub KeyDownEvent(ByVal GridName As DataGridView, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''    ' If e.KeyValue = 40 Then
    ''    If GridName.SelectedRows.Count = 0 Then
    ''        GridName.Rows(0).Selected = True
    ''    Else
    ''        If GridName.SelectedRows(0).Index < (GridName.Rows.Count - 1) Then
    ''            Dim intSelectedIndex As Integer = GridName.SelectedRows(0).Index
    ''            GridName.ClearSelection()
    ''            GridName.Rows(intSelectedIndex + 1).Selected = True
    ''        End If
    ''    End If
    ''    ' End If
    ''End Sub

    Private Sub ConsignmentStockLookUp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

End Class
    