Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class Accountlookup

    Public strAcctcode As String = String.Empty
    Public strAcctId As String = String.Empty ''COAID
    Public strAcctDescp As String = String.Empty

    Private Sub Accountlookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetUICulture(GlobalPPT.strLang)
        Dim objAcctID As New StoreIssueVoucherPPT
        Dim ds As New DataSet

        ds = StoreIssueVoucherBOL.AcctlookupSearch(objAcctID, "NO")
        dgAccountcode.DataSource = ds.Tables(0)
        dgAccountcode.Columns("EstateID").Visible = False

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Accountlookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchAcctNo.Text = rm.GetString("lblsearchAcctNo.Text")
            panAcctLookUp.CaptionText = rm.GetString("panAcctLookUp.CaptionText")

            dgAccountcode.Columns("AccountID").HeaderText = rm.GetString("dgAccountcode.Columns(AccountID).HeaderText")
            dgAccountcode.Columns("AccountCode").HeaderText = rm.GetString("dgAccountcode.Columns(AccountCode).HeaderText")
            dgAccountcode.Columns("AccountDescription").HeaderText = rm.GetString("dgAccountcode.Columns(AccountDescription).HeaderText")

            lblAcctcode.Text = rm.GetString("lblAcctcode.Text")
            lblAcctDesc.Text = rm.GetString("lblAcctDesc.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSerach()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ClearAfterSerach()

        txtAccountCodeSearch.Text = String.Empty
        txtAccountDescSearch.Text = String.Empty

    End Sub

    Private Sub dgAccountcode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAccountcode.CellDoubleClick

        Grid_Clicked()

    End Sub

    Private Sub Grid_Clicked()

        If dgAccountcode.RowCount <> 0 Then
            Dim objAcctID As New StoreIssueVoucherPPT
            strAcctId = dgAccountcode.CurrentRow.Cells("AccountId").Value.ToString() 'COAID
            strAcctcode = dgAccountcode.CurrentRow.Cells("AccountCode").Value.ToString()
            strAcctDescp = dgAccountcode.CurrentRow.Cells("AccountDescription").Value.ToString()
            DialogResult = DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            ''MessageBox.Show("There is no record to select")
        End If

    End Sub

    Private Sub btnAccountcodeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountcodeSearch.Click

        Dim ds As New DataSet
        Dim objAcctCode As New StoreIssueVoucherPPT
        objAcctCode.COACode = txtAccountCodeSearch.Text.Trim()
        objAcctCode.COADescp = txtAccountDescSearch.Text.Trim()

        If (StoreIssueVoucherBOL.AcctlookupSearch(objAcctCode, "NO").Tables(0).Rows.Count <= 0) Then
            DisplayInfoMessage("msg02")
            ''MessageBox.Show("No Records Found")
            dgAccountcode.DataSource = ds
            dgAccountcode.Columns("EstateID").Visible = False
        Else
            ds = StoreIssueVoucherBOL.AcctlookupSearch(objAcctCode, "NO")
            dgAccountcode.DataSource = ds.Tables(0)
            dgAccountcode.Columns("EstateID").Visible = False
        End If

    End Sub

    Private Sub dgAccountcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgAccountcode.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Clicked()
        End If
        e.Handled = True
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgAccountcode, e)
        End If
        ''If e.KeyValue = 40 Then
        ''    If dgAccountcode.SelectedRows.Count = 0 Then
        ''        dgAccountcode.Rows(0).Selected = True
        ''    Else
        ''        If dgAccountcode.SelectedRows(0).Index < (dgAccountcode.Rows.Count - 1) Then
        ''            Dim intSelectedIndex As Integer = dgAccountcode.SelectedRows(0).Index
        ''            dgAccountcode.ClearSelection()
        ''            dgAccountcode.Rows(intSelectedIndex + 1).Selected = True
        ''        End If
        ''    End If
        ''End If

    End Sub

    Private Sub Accountlookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgAccountcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgAccountcode.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgAccountcode, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Accountlookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class
