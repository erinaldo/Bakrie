Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient

Public Class SenderReceiverLocLookup

    Public _lSenderLocation As String = String.Empty
    Public _lSenderLocationID As String = String.Empty
    Public _lT0 As String = String.Empty
    Public _lT1 As String = String.Empty
    Public _lT2 As String = String.Empty
    Public _lT3 As String = String.Empty
    Public _lT4 As String = String.Empty

    Private Sub SenderReceiverLocLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BindSenderLocation()
    End Sub

    Public Sub BindSenderLocation()

        Dim dt As New DataTable
        Dim objITNINPPT As New InternalTransferNoteINPPT
        Dim objITNINBOL As New InternalTransferNoteINBOL

        Dim objITNOutPPT As New InternalTransferNoteOUTPPT
        Dim objITNOutBOL As New InternalTransferNoteOUTBOL
        'objITNINPPT.StockCode = txtSenderLocsearch.Text.Trim
        'objITNOutPPT.StockCode = txtSenderLocsearch.Text.Trim

        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M8" Then
            objITNINPPT.SendersLocationSearch = txtSenderLocsearch.Text.Trim
            dt = objITNINBOL.STITNInSendLocGet(objITNINPPT)
        ElseIf mdiparent.strMenuID = "M9" Then
            objITNOutPPT.ReceivedLocationSearch = txtSenderLocsearch.Text.Trim
            dt = objITNOutBOL.STITNOutRecLocGet(objITNOutPPT)
        ElseIf mdiparent.strMenuID = "M19" Then
            objITNINPPT.SendersLocationSearch = txtSenderLocsearch.Text.Trim
            dt = objITNINBOL.STITNInSendLocGet(objITNINPPT)
        ElseIf mdiparent.strMenuID = "M120" Then
            objITNOutPPT.ReceivedLocationSearch = txtSenderLocsearch.Text.Trim
            dt = objITNOutBOL.STITNOutRecLocGet(objITNOutPPT)
        End If
        dgvSenderLocation.AutoGenerateColumns = False
        dgvSenderLocation.DataSource = dt
        txtSenderLocsearch.Text = String.Empty

    End Sub

    Private Sub dgvSenderLocation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSenderLocation.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ClearAfterSearch()

        txtSenderLocsearch.Text = String.Empty

    End Sub

    Private Sub btnSenderLocSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSenderLocSearch.Click

        BindSenderLocation()

    End Sub

    Private Sub SenderReceiverLocLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub Grid_Click()

        If dgvSenderLocation.Rows.Count > 0 Then
            _lSenderLocation = dgvSenderLocation.SelectedRows(0).Cells("dgclLocation").Value

            _lSenderLocationID = dgvSenderLocation.SelectedRows(0).Cells("dgclSupplierLocationID").Value

            If Not dgvSenderLocation.SelectedRows(0).Cells("dgclT0").Value Is DBNull.Value Then
                _lT0 = dgvSenderLocation.SelectedRows(0).Cells("dgclT0").Value
            Else
                _lT0 = String.Empty
            End If
            If Not dgvSenderLocation.SelectedRows(0).Cells("dgclT1").Value Is DBNull.Value Then
                _lT1 = dgvSenderLocation.SelectedRows(0).Cells("dgclT1").Value
            Else
                _lT1 = String.Empty
            End If
            If Not dgvSenderLocation.SelectedRows(0).Cells("dgclT2").Value Is DBNull.Value Then
                _lT2 = dgvSenderLocation.SelectedRows(0).Cells("dgclT2").Value
            Else
                _lT2 = String.Empty
            End If
            If Not dgvSenderLocation.SelectedRows(0).Cells("dgclT3").Value Is DBNull.Value Then
                _lT3 = dgvSenderLocation.SelectedRows(0).Cells("dgclT3").Value
            Else
                _lT3 = String.Empty
            End If
            If Not dgvSenderLocation.SelectedRows(0).Cells("dgclT4").Value Is DBNull.Value Then
                _lT4 = dgvSenderLocation.SelectedRows(0).Cells("dgclT4").Value
            Else
                _lT4 = String.Empty
            End If

            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub dgvSenderLocation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSenderLocation.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
        End If
        e.Handled = True

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvSenderLocation, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvSenderLocation, e)
        'End If
    End Sub

End Class