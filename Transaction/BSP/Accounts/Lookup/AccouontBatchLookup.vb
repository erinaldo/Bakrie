Imports Accounts_PPT
Imports Accounts_BOL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class AccouontBatchLookup

    Public strLedgerType As String = String.Empty
    Public strLedgerSetUpId As String = String.Empty

    Private Sub btnLedgerTypeSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLedgerTypeSearch.Click
        Dim objLedgerBatch As New AccountBatchPPT
        objLedgerBatch.LedgerType = txtLedgerTypeSearch.Text.Trim()

        If (Accounts_BOL.AccountBatchBOL.LedgerTypeSearch(objLedgerBatch).Tables(0).Rows.Count <= 0) Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("No Records Found")
            dgLedgerType.DataSource = Accounts_BOL.AccountBatchBOL.LedgerTypeSearch(objLedgerBatch).Tables(0)
            txtLedgerTypeSearch.Text = String.Empty
        Else
            dgLedgerType.DataSource = Accounts_BOL.AccountBatchBOL.LedgerTypeSearch(objLedgerBatch).Tables(0)

        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccouontBatchLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        txtLedgerTypeSearch.Text = String.Empty

        Me.Close()
    End Sub


    Private Sub LedgerBatchLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        Dim objLedgerBatch As New AccountBatchPPT
        dgLedgerType.DataSource = Accounts_BOL.AccountBatchBOL.LedgerTypeSearch(objLedgerBatch).Tables(0)
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccouontBatchLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            
            lblsearchLedgerType.Text = rm.GetString("lblsearchLedgerType.Text")

            dgLedgerType.Columns("LedgerType").HeaderText = rm.GetString("dgLedgerType.Columns(LedgerType).HeaderText")
            dgLedgerType.Columns("LedgerDescription").HeaderText = rm.GetString("dgLedgerType.Columns(LedgerDescription).HeaderText")

            panLedgerBatchLookUp.CaptionText = rm.GetString("panLedgerBatchLookUp.CaptionText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgLedgerType_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLedgerType.CellDoubleClick

        Dim objLedgerBatch As New AccountBatchFrm

        strLedgerType = dgLedgerType.CurrentRow.Cells("LedgerType").Value.ToString()
        strLedgerSetUpId = dgLedgerType.CurrentRow.Cells("LedgerSetupId").Value.ToString()

        Me.Close()

    End Sub
End Class