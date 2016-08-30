Imports Accounts_PPT
Imports Accounts_BOL
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_BOL
Public Class LedgerNoLookUp

    Public strAccBatchID As String = String.Empty
    Public strLedgerNo As String = String.Empty
    Public strLedgerDescp As String = String.Empty
    Public dblAccBatchTotal As Decimal

            Private Sub LedgerNoLookUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub LedgerNoLookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtLedgerNoSearch.Text = ""
        BindLedgerDataGrid()
        SetUICulture(GlobalPPT.strLang)
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerNoLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchLedgerNo.Text = rm.GetString("lblsearchLedgerNo.Text")
            panLedgerNoLookUp.CaptionText = rm.GetString("panLedgerNoLookUp.CaptionText")

            dgLedgerNo.Columns("dgclLedgerNo").HeaderText = rm.GetString("dgLedgerNo.Columns(dgclLedgerNo).HeaderText")
            dgLedgerNo.Columns("dgclDescp").HeaderText = rm.GetString("dgLedgerNo.Columns(dgclDescp).HeaderText")
            dgLedgerNo.Columns("dgclBatchTotal").HeaderText = rm.GetString("dgLedgerNo.Columns(dgclBatchTotal).HeaderText")
            'dgLedgerNo.Columns("dgclAccBatchID").HeaderText = rm.GetString("dgLedgerNo.Columns(dgclAccBatchID).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BindLedgerDataGrid()
        Dim objLedgerNo As New AccountsApprovalPPT
        With objLedgerNo
            .LedgerNo = Me.txtLedgerNoSearch.Text.Trim
        End With
        Dim dt As New DataTable
        Dim ObjLedgerNoSearch As New AccountsApprovalBOL
        dt = ObjLedgerNoSearch.LedgerNoSearch(objLedgerNo, "NO")

       
        dgLedgerNo.AutoGenerateColumns = False
        dgLedgerNo.DataSource = dt

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerNoLookUp))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnLedgerNoSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLedgerNoSearch.Click

        If txtLedgerNoSearch.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg2")
            ''MsgBox("Please Enter Criteria to Search!")
            BindLedgerDataGrid()
            Exit Sub
        Else
            BindLedgerDataGrid()
            If dgLedgerNo.RowCount = 0 Then
                DisplayInfoMessage("Msg3")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        strAccBatchID = String.Empty
        strLedgerNo = String.Empty
        strLedgerDescp = String.Empty
        dblAccBatchTotal = 0
        Me.Close()

    End Sub

    Private Sub dgLedgerNo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLedgerNo.CellDoubleClick
        Dim objLedgerNo As New JournalPPT
        If dgLedgerNo.RowCount <> 0 Then
            ' strAccBatchID = dgLedgerNo.CurrentRow.Cells("dgclAccBatchID").Value.ToString()
            strLedgerNo = dgLedgerNo.CurrentRow.Cells("dgclLedgerNo").Value.ToString()
            dblAccBatchTotal = dgLedgerNo.CurrentRow.Cells("dgclBatchTotal").Value.ToString()
            Me.Close()
        Else
            DisplayInfoMessage("Msg4")
            ''MessageBox.Show("There is no record to select")
        End If

    End Sub

  
End Class