Imports Accounts_BOL
Imports Accounts_PPT
Imports System.Data.SqlClient
Imports Common_PPT

Public Class UOMLookup

    Public _lUOM As String = String.Empty
    Public _lUOMID As String = String.Empty
    Public _lDescp As String = String.Empty

    Private Sub UOMSearch()
        Dim Ds As New DataSet
        Dim ObjPettyCashPaymentPPT As New PettyCashPaymentPPT
        Dim ObjPettyCashPaymentBOL As New PettyCashPaymentBOL
        ObjPettyCashPaymentPPT.UOM = txtUOMSearch.Text.Trim
        Ds = ObjPettyCashPaymentBOL.UOMLookupSearch(ObjPettyCashPaymentPPT, "No")
        If Not Ds Is Nothing Then
            dgUOM.AutoGenerateColumns = False
            dgUOM.DataSource = Ds.Tables(0)
        End If

        If Ds Is Nothing Then
            lblNoRecord.Visible = True
        Else
            lblNoRecord.Visible = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtUOMSearch.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg1")
            ''MsgBox("Please Enter criteria to Search.")
            UOMSearch()
            Exit Sub
        Else
            UOMSearch()
            If dgUOM.RowCount = 0 Then
                DisplayInfoMessage("Msg2")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If


    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UOMLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _lDescp = String.Empty
        _lUOM = String.Empty
        _lUOMID = String.Empty
        Me.Close()
    End Sub
    Private Sub dgUOM_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUOM.CellDoubleClick
        If dgUOM.Rows.Count > 0 Then
            _lDescp = dgUOM.SelectedRows(0).Cells("dgDescp").Value
            _lUOMID = dgUOM.SelectedRows(0).Cells("dgUOMID").Value
            _lUOM = dgUOM.SelectedRows(0).Cells("dgUnit").Value
            Me.Close()
        End If
    End Sub

    Private Sub UOMLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        txtUOMSearch.Focus()
        UOMSearch()

    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(UOMLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchDiv.Text = rm.GetString("lblsearchDiv.Text")
            panUOMLookup.CaptionText = rm.GetString("panUOMLookup.CaptionText")
            lblWBTicketSearch.Text = rm.GetString("lblWBTicketSearch.Text")
            lblNoRecord.Text = rm.GetString("lblNoRecord.Text")
            dgUOM.Columns("dgUnit").HeaderText = rm.GetString("dgLedgerNo.Columns(dgUnit).HeaderText")
            dgUOM.Columns("dgDescp").HeaderText = rm.GetString("dgLedgerNo.Columns(dgDescp).HeaderText")
            'dgLedgerNo.Columns("dgclAccBatchID").HeaderText = rm.GetString("dgLedgerNo.Columns(dgclAccBatchID).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UOMLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtUOMSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUOMSearch.KeyDown
        'If e.KeyCode = 13 Then
        '    btnWBTicketNoSearch.Focus()
        'End If
    End Sub

    Private Sub dgUOM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgUOM.KeyDown
        If e.KeyCode = 13 Then
            If dgUOM.Rows.Count > 0 Then
                _lDescp = dgUOM.SelectedRows(0).Cells("dgDescp").Value
                _lUOMID = dgUOM.SelectedRows(0).Cells("dgUOMID").Value
                _lUOM = dgUOM.SelectedRows(0).Cells("dgUnit").Value
                Me.Close()
            End If
        End If
    End Sub


End Class