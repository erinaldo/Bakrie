Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class WSTLookup

    Public strTId As String = String.Empty
    Public strTCode As String = String.Empty
    Public strTValue As String = String.Empty
    Public strTDesc As String = String.Empty
    Public strTAbbrev As String = String.Empty
    Public Shared strTcodeDecide As String = String.Empty

    Private Sub Tlookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Dim objTlookup As New VehicleDistributionPPT
        objTlookup.TDecide = strTcodeDecide
        'Dim ds As New DataSet
        'dgTlookup.AutoGenerateColumns = False
        'ds = StoreIssueVoucherBOL.TlookupSearch(objTlookup, "NO")
        Bind(objTlookup)
        ''If Not ds Is Nothing Then
        ''    If ds.Tables.Count > 0 Then
        ''        If ds.Tables(0).Rows.Count > 0 Then
        ''            dgTlookup.AutoGenerateColumns = False
        ''            lblNoRecord.Visible = False
        ''            dgTlookup.DataSource = ds.Tables(0)
        ''        Else
        ''            dgTlookup.AutoGenerateColumns = False
        ''            lblNoRecord.Visible = True
        ''            dgTlookup.DataSource = ds
        ''        End If
        ''        dgTlookup.Focus()
        ''    End If
        ''End If

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WSTlookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchAnalysisCode.Text = rm.GetString("lblsearchAnalysisCode.Text")
            panTLookup.CaptionText = rm.GetString("panTLookup.CaptionText")
            lblTValue.Text = rm.GetString("lblTValue.Text")
            lblTDesc.Text = rm.GetString("lblTDesc.Text")
            dgTlookup.Columns("TAnalysisId").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisId).HeaderText")
            dgTlookup.Columns("TAnalysisCode").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisCode).HeaderText")
            dgTlookup.Columns("TValue").HeaderText = rm.GetString("dgTlookup.Columns(TValue).HeaderText")
            dgTlookup.Columns("TAnalysisDescp").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisDescp).HeaderText")
            dgTlookup.Columns("TAnalysisAbbrev").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisAbbrev).HeaderText")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgTlookup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTlookup.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub Grid_Click()

        If dgTlookup.RowCount > 0 Then
            Dim objTID As New VehicleDistributionPPT
            strTId = dgTlookup.CurrentRow.Cells("TAnalysisId").Value.ToString() 'TAnalysisId
            strTCode = dgTlookup.CurrentRow.Cells("TAnalysisCode").Value.ToString()
            If Not dgTlookup.CurrentRow.Cells("TValue").Value Is DBNull.Value Then
                strTValue = dgTlookup.CurrentRow.Cells("TValue").Value.ToString()
            Else
                strTValue = String.Empty
            End If
            If Not dgTlookup.CurrentRow.Cells("TAnalysisDescp").Value Is DBNull.Value Then
                strTDesc = dgTlookup.CurrentRow.Cells("TAnalysisDescp").Value.ToString()
            Else
                strTDesc = String.Empty
            End If
            If Not dgTlookup.CurrentRow.Cells("TAnalysisAbbrev").Value Is DBNull.Value Then
                strTAbbrev = dgTlookup.CurrentRow.Cells("TAnalysisAbbrev").Value.ToString()
            Else
                strTAbbrev = String.Empty
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("There is no record to select")
            'Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub

    Private Sub Bind(ByVal objT)

        Dim ds As New DataSet
        ds = VehicleDistributionBOL.TlookupSearch(objT, "NO")
        If (ds.Tables(0).Rows.Count <= 0) Then
            lblNoRecord.Visible = True
            dgTlookup.AutoGenerateColumns = False
            dgTlookup.DataSource = ds.Tables(0)
        Else
            lblNoRecord.Visible = False
            dgTlookup.AutoGenerateColumns = False
            dgTlookup.DataSource = ds.Tables(0)
        End If

    End Sub

    Private Sub btnTSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objT As New VehicleDistributionPPT
        objT.TDecide = strTcodeDecide

        If strTcodeDecide = "T0" Then
            objT.T0Value = txtTValueSearch.Text.Trim()
            objT.T0Desc = txtTDescSearch.Text.Trim()
            Bind(objT)
        ElseIf strTcodeDecide = "T1" Then
            objT.T1Value = txtTValueSearch.Text.Trim()
            objT.T1Desc = txtTDescSearch.Text.Trim()
            Bind(objT)
        ElseIf strTcodeDecide = "T2" Then
            objT.T2Value = txtTValueSearch.Text.Trim()
            objT.T2Desc = txtTDescSearch.Text.Trim()
            Bind(objT)
        ElseIf strTcodeDecide = "T3" Then
            objT.T3Value = txtTValueSearch.Text.Trim()
            objT.T3Desc = txtTDescSearch.Text.Trim()
            Bind(objT)
        ElseIf strTcodeDecide = "T4" Then
            objT.T4Value = txtTValueSearch.Text.Trim()
            objT.T4Desc = txtTDescSearch.Text.Trim()
            Bind(objT)
        End If

        ''ClearAfterSearch()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ClearAfterSearch()

        txtTValueSearch.Text = String.Empty
        txtTDescSearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Public Sub BindTLookup()

        SetUICulture(GlobalPPT.strLang)
        Dim objTlookup As New VehicleDistributionPPT
        ' Dim strEMDN As EstateMillDeliveryNoteFrm
        objTlookup.TDecide = strTcodeDecide
        Dim ds As New DataSet
        'dgTlookup.AutoGenerateColumns = False
        ds = VehicleDistributionBOL.TlookupSearch(objTlookup, "NO")
        ''If ds.Tables(0).Rows.Count > 0 Then
        ''    dgTlookup.DataSource = ds.Tables(0)
        ''End If
        If (ds.Tables(0).Rows.Count <= 0) Then
            lblNoRecord.Visible = True
            dgTlookup.AutoGenerateColumns = False
            dgTlookup.DataSource = ds.Tables(0)
        Else
            lblNoRecord.Visible = False
            dgTlookup.AutoGenerateColumns = False
            dgTlookup.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub dgTlookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgTlookup.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
            e.Handled = True
        End If

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgTlookup, e)
        End If

        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgTlookup, e)
        'End If
        'If e.KeyValue = 40 Then
        '    If dgTlookup.SelectedRows.Count = 0 Then
        '        dgTlookup.Rows(0).Selected = True
        '    Else
        '        If dgTlookup.SelectedRows(0).Index < (dgTlookup.Rows.Count - 1) Then
        '            Dim intSelectedIndex As Integer = dgTlookup.SelectedRows(0).Index

        '            dgTlookup.ClearSelection()
        '            dgTlookup.Rows(intSelectedIndex + 1).Selected = True
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub Tlookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgTlookup_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgTlookup.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgTlookup, e)
        End If

    End Sub
End Class