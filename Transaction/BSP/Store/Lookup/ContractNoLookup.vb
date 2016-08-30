Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class ContractNoLookup

    Public strContractId As String = String.Empty
    Public strContractNo As String = String.Empty
    Public strContractName As String = String.Empty
    Public strContractCOAID As String = String.Empty
    Public strContractCOACode As String = String.Empty
    Public strContractCOADescp As String = String.Empty
    Public strContractOldCOACode As String = String.Empty

    Private Sub ContractNoLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        Dim objContractID As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.ContractIDSearch(objContractID, "NO")
        dgContractNo.AutoGenerateColumns = False
        dgContractNo.DataSource = ds.Tables(0)
    End Sub

    Private Sub btnContractNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContractNoSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim ds As New DataSet
        Dim objContractID As New StoreIssueVoucherPPT
        objContractID.ContractNo = txtContractNoSearch.Text.Trim()
        objContractID.ContractName = txtContractNameSearch.Text.Trim()

        If (StoreIssueVoucherBOL.ContractIDSearch(objContractID, "NO").Tables(0).Rows.Count <= 0) Then
            lblNoRecord.Visible = True
            dgContractNo.AutoGenerateColumns = False
            dgContractNo.DataSource = Nothing
        Else
            ds = StoreIssueVoucherBOL.ContractIDSearch(objContractID, "NO")
            lblNoRecord.Visible = False
            dgContractNo.AutoGenerateColumns = False
            dgContractNo.DataSource = ds.Tables(0)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ''Dim frmSIV As New StoreIssueVoucherFrm
        ''If frmSIV.txtContractNo.Text.Trim = String.Empty Then
        ''    frmSIV.lblContractorValue.Text = String.Empty
        ''    frmSIV.btnSearchAccountCode.Enabled = True
        ''    frmSIV.txtAccountCode.Enabled = True
        ''    frmSIV.txtAccountCode.Text = String.Empty
        ''    frmSIV.psSIVAccountID = String.Empty
        ''End If
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgContractNo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgContractNo.CellDoubleClick

        Grid_Click()

    End Sub
    Private Sub Grid_Click()

        Dim objContractID As New StoreIssueVoucherPPT
        If dgContractNo.RowCount <> 0 Then
            strContractId = dgContractNo.CurrentRow.Cells("ContractID").Value.ToString()
            strContractNo = dgContractNo.CurrentRow.Cells("ContractNo").Value.ToString()
            strContractName = dgContractNo.CurrentRow.Cells("ContractName").Value.ToString()
            strContractCOAID = dgContractNo.CurrentRow.Cells("ContractCOAID").Value.ToString()
            If Not dgContractNo.CurrentRow.Cells("ContractCOACode").Value Is DBNull.Value Then
                strContractCOACode = dgContractNo.CurrentRow.Cells("ContractCOACode").Value.ToString()
            Else
                strContractCOACode = String.Empty
            End If
            If Not dgContractNo.CurrentRow.Cells("ContractCOADescp").Value Is DBNull.Value Then
                strContractCOADescp = dgContractNo.CurrentRow.Cells("ContractCOADescp").Value.ToString()
            Else
                strContractCOADescp = String.Empty
            End If
            If Not dgContractNo.CurrentRow.Cells("ContractOldCOACode").Value Is Nothing Then 'dbnull not working for this
                strContractOldCOACode = dgContractNo.CurrentRow.Cells("ContractOldCOACode").Value.ToString()
            Else
                strContractOldCOACode = String.Empty
            End If
            'chk data property name b4 running
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("There is no record to select")
        End If

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ContractNoLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchContractNo.Text = rm.GetString("lblsearchContractNo.Text")
            panContractNoLookUp.CaptionText = rm.GetString("panContractNoLookUp.CaptionText")

            ''dgContractNo.Columns("ContractID").HeaderText = rm.GetString("dgContractNo.Columns(ContractID).HeaderText")
            dgContractNo.Columns("ContractNo").HeaderText = rm.GetString("dgContractNo.Columns(ContractNo).HeaderText")
            dgContractNo.Columns("ContractName").HeaderText = rm.GetString("dgContractNo.Columns(ContractName).HeaderText")
            lblContName.Text = rm.GetString("lblContName.Text")
            lblContNo.Text = rm.GetString("lblContNo.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgContractNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgContractNo.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
            e.Handled = True
        End If

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgContractNo, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgContractNo, e)
        'End If

    End Sub

    Private Sub ContractNoLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgContractNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgContractNo.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgContractNo, e)
        End If

    End Sub
End Class