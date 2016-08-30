Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class StationLookup

    Public psStationId As String = String.Empty
    Public psStationCode As String = String.Empty
    Public psStationDesc As String = String.Empty
    Public psRGNStockCOAIDValue As String = String.Empty
    Public psRGNVarianceCOAIDValue As String = String.Empty

    Private Sub StationLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Dim objStation As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.GetStation(objStation, "NO")
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgStation.AutoGenerateColumns = False
                dgStation.DataSource = ds.Tables(0)
            End If
        End If

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StationLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchStation.Text = rm.GetString("lblsearchStation.Text")
            panStationLookUp.CaptionText = rm.GetString("panStationLookUp.CaptionText")

            lblStationCode.Text = rm.GetString("lblStationCode.Text")
            lblStationDesc.Text = rm.GetString("lblStationDesc.Text")
            dgStation.Columns("dgclStationID").HeaderText = rm.GetString("dgStation.Columns(dgclStationID).HeaderText")
            dgStation.Columns("dgclStationCode").HeaderText = rm.GetString("dgStation.Columns(dgclStationCode).HeaderText")
            dgStation.Columns("dgclStationDescp").HeaderText = rm.GetString("dgStation.Columns(dgclStationDescp).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearAfterSearch()

        txtStationSearch.Text = String.Empty
        txtStationDescSearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        ClearAfterSearch()
        Me.Close()

    End Sub

    Private Sub btnStationSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStationSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objStationPPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objStationPPT.Stationcode = txtStationSearch.Text.Trim()
        objStationPPT.StationDesc = txtStationDescSearch.Text.Trim()
        ds = StoreIssueVoucherBOL.GetStation(objStationPPT, "NO")
        If Not ds Is Nothing Then
            If (ds.Tables(0).Rows.Count <= 0) Then
                lblNoRecord.Visible = True
                'dgStation.Visible = False
                dgStation.DataSource = ds.Tables(0)
            Else
                lblNoRecord.Visible = False
                dgStation.Visible = True
                dgStation.AutoGenerateColumns = False
                dgStation.DataSource = ds.Tables(0)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgStation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStation.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub StationLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Grid_Click()

        If dgStation.RowCount <> 0 Then
            Dim objYOP As New StoreIssueVoucherPPT
            psStationId = dgStation.CurrentRow.Cells("dgclStationID").Value.ToString()
            psStationCode = dgStation.CurrentRow.Cells("dgclStationCode").Value.ToString()
            psStationDesc = dgStation.CurrentRow.Cells("dgclStationDescp").Value.ToString()
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            '' MessageBox.Show("There is no record to select")
        End If

    End Sub

    Private Sub dgStation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgStation.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
            e.Handled = True
        End If
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgStation, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgStation, e)
        'End If
    End Sub

    Private Sub dgStation_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgStation.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgStation, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StationLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class