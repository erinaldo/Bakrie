Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class SubBlockLookup

    Public psBlockId As String = String.Empty
    Public psBlockName As String = String.Empty
    Public psYop As String = String.Empty
    Public psYopID As String = String.Empty
    Public psYopName As String = String.Empty
    Public psDIV As String = String.Empty
    Public psDIVID As String = String.Empty
    Public psDIVName As String = String.Empty
    Public psPlantedHect As String = String.Empty
    Public psBlockStatus As String = String.Empty

    Private Sub SubBlockLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Dim objSubBlock As New StoreIssueVoucherPPT
        objSubBlock.BlockStatus = GlobalPPT.psAcctExpenditureType
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.GetSubBlock(objSubBlock, "NO")
        If ds.Tables(0).Rows.Count > 0 Then
            lblNoRecord.Visible = False
            dgSubBlock.AutoGenerateColumns = False
            dgSubBlock.DataSource = ds.Tables(0)
        Else
            lblNoRecord.Visible = True
            dgSubBlock.AutoGenerateColumns = False
            dgSubBlock.DataSource = ds.Tables(0)
        End If
        txtDivSearch.Focus()

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SubBlockLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchSubBlock.Text = rm.GetString("lblsearchSubBlock.Text")
            panSubBlockLookUp.CaptionText = rm.GetString("panSubBlockLookUp.CaptionText")
            lblDivSearch.Text = rm.GetString("lblDivSearch.Text")
            lblYOPSearch.Text = rm.GetString("lblYOPSearch.Text")
            lblBlockName.Text = rm.GetString("lblBlockName.Text")

            dgSubBlock.Columns("dgclBlockName").HeaderText = rm.GetString("dgSubBlock.Columns(dgclBlockName).HeaderText")
            dgSubBlock.Columns("dgclDivName").HeaderText = rm.GetString("dgSubBlock.Columns(dgclDivName).HeaderText")
            dgSubBlock.Columns("dgclYOP").HeaderText = rm.GetString("dgSubBlock.Columns(dgclYOP).HeaderText")
            dgSubBlock.Columns("dgclBlockStatus").HeaderText = rm.GetString("dgSubBlock.Columns(dgclBlockStatus).HeaderText")
            dgSubBlock.Columns("dgclPlantedHect").HeaderText = rm.GetString("dgSubBlock.Columns(dgclPlantedHect).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSubBlockSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubBlockSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objBlockPPt As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        dgSubBlock.DataSource = Nothing
        objBlockPPt.Div = txtDivSearch.Text.Trim()
        objBlockPPt.YOP = txtYOPSearch.Text.Trim()
        objBlockPPt.BlockName = txtBlockNameSearch.Text.Trim()
        objBlockPPt.BlockStatus = GlobalPPT.psAcctExpenditureType
        ds = StoreIssueVoucherBOL.GetSubBlock(objBlockPPt, "NO")

        If (ds.Tables(0).Rows.Count <= 0) Then
            lblNoRecord.Visible = True
            dgSubBlock.AutoGenerateColumns = False
            dgSubBlock.DataSource = ds.Tables(0)
            'dgSubBlock.DataSource = Nothing

        Else
            'ds = StoreIssueVoucherBOL.GetSubBlock(objBlockPPt, "NO")
            lblNoRecord.Visible = False
            dgSubBlock.AutoGenerateColumns = False
            dgSubBlock.DataSource = ds.Tables(0)

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ClearAfterSearch()

        txtBlockNameSearch.Text = String.Empty
        txtDivSearch.Text = String.Empty
        txtYOPSearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        ClearAfterSearch()
        Me.Close()

    End Sub

    Private Sub dgSubBlock_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSubBlock.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub dgSubBlock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Then
            Grid_Click()
        End If
        e.Handled = True

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgSubBlock, e)
        End If



        ''
        'If e.KeyValue = 40 Then
        '    If dgSubBlock.SelectedRows.Count = 0 Then
        '        dgSubBlock.Rows(0).Selected = True
        '    Else
        '        If dgSubBlock.SelectedRows(0).Index < (dgSubBlock.Rows.Count - 1) Then
        '            Dim intSelectedIndex As Integer = dgSubBlock.SelectedRows(0).Index

        '            dgSubBlock.ClearSelection()
        '            dgSubBlock.Rows(intSelectedIndex + 1).Selected = True
        '        End If
        '    End If
        'End If

        'If e.KeyValue = 38 Then
        '    If dgSubBlock.SelectedRows.Count = 0 Then
        '        dgSubBlock.Rows(0).Selected = True
        '    Else
        '        If dgSubBlock.SelectedRows(0).Index < (dgSubBlock.Rows.Count + 1) Then
        '            Dim intSelectedIndex As Integer = dgSubBlock.SelectedRows(0).Index
        '            dgSubBlock.ClearSelection()

        '            If intSelectedIndex > 0 Then
        '                dgSubBlock.Rows(intSelectedIndex - 1).Selected = True
        '            End If
        '        End If
        '    End If
        'End If

        ''

    End Sub

    Private Sub Grid_Click()

        If dgSubBlock.RowCount > 0 Then
            Dim objYOP As New StoreIssueVoucherPPT
            psBlockId = dgSubBlock.CurrentRow.Cells("dgclBlockID").Value.ToString()
            If dgSubBlock.CurrentRow.Cells("dgclBlockName").Value.ToString() <> String.Empty Then
                psBlockName = dgSubBlock.CurrentRow.Cells("dgclBlockName").Value.ToString()
            End If
            psDIVID = dgSubBlock.CurrentRow.Cells("dgclDivID").Value.ToString()
            If dgSubBlock.CurrentRow.Cells("dgclDiv").Value.ToString() <> String.Empty Then
                psDIV = dgSubBlock.CurrentRow.Cells("dgclDiv").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclDivName").Value.ToString() <> String.Empty Then
                psDIVName = dgSubBlock.CurrentRow.Cells("dgclDivName").Value.ToString()
            End If
            psYopID = dgSubBlock.CurrentRow.Cells("dgclYOPID").Value.ToString()
            If dgSubBlock.CurrentRow.Cells("dgclYOP").Value.ToString() <> String.Empty Then
                psYop = dgSubBlock.CurrentRow.Cells("dgclYOP").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclName").Value.ToString() <> String.Empty Then
                psYopName = dgSubBlock.CurrentRow.Cells("dgclName").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclPlantedHect").Value.ToString() <> String.Empty Then
                psPlantedHect = dgSubBlock.CurrentRow.Cells("dgclPlantedHect").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclBlockStatus").Value.ToString() <> String.Empty Then
                psBlockStatus = dgSubBlock.CurrentRow.Cells("dgclBlockStatus").Value.ToString()
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            '' MessageBox.Show("There is no record to select")
        End If

    End Sub

    Private Sub SubBlockLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgSubBlock_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgSubBlock, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SubBlockLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class