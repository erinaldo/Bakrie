Imports Production_BOL
Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT

Public Class WBTicketLookup

    Public _lWBTicketNo As String = String.Empty
    Public _lWeighingID As String = String.Empty

    Private Sub WBTicketNo()
        Dim Ds As New DataSet
        Dim ObjGradingFFBPPT As New GradingFFBPPT
        Dim ObjGradingFFBBOL As New GradingFFBBOL
        ObjGradingFFBPPT.WBTicketNo = txtWBTicketNoSearch.Text.Trim
        Ds = ObjGradingFFBBOL.WBTicketNoLookupSearch(ObjGradingFFBPPT, "No")
        If Not Ds Is Nothing Then
            dgWBTicketNo.AutoGenerateColumns = False
            dgWBTicketNo.DataSource = Ds.Tables(0)
        End If

        If Ds Is Nothing Then
            lblNoRecord.Visible = True
        Else
            lblNoRecord.Visible = False
        End If
    End Sub

    Private Sub btnWBTicketNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWBTicketNoSearch.Click
        If txtWBTicketNoSearch.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg1")
            ''MsgBox("Please Enter criteria to Search.")
            WBTicketNo()
            Exit Sub
        Else
            WBTicketNo()
            If dgWBTicketNo.RowCount = 0 Then
                DisplayInfoMessage("Msg2")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If


    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBTicketLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _lWBTicketNo = String.Empty
        _lWeighingID = String.Empty
        Me.Close()
    End Sub
    Private Sub dgWBTicketNo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgWBTicketNo.CellDoubleClick
        If dgWBTicketNo.Rows.Count > 0 Then
            _lWBTicketNo = dgWBTicketNo.SelectedRows(0).Cells("dgWBTicket").Value
            _lWeighingID = dgWBTicketNo.SelectedRows(0).Cells("dgWeighingID").Value
            Me.Close()
        End If
    End Sub

    Private Sub WBTicketLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        txtWBTicketNoSearch.Focus()
        WBTicketNo()

    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBTicketLookup))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            dgWBTicketNo.Columns("dgWBTicket").HeaderText = rm.GetString("dgWBTicket")


        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WBTicketLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtWBTicketNoSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWBTicketNoSearch.KeyDown
        'If e.KeyCode = 13 Then
        '    btnWBTicketNoSearch.Focus()
        'End If
    End Sub

    Private Sub dgWBTicketNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgWBTicketNo.KeyDown
        If e.KeyCode = 13 Then
            If dgWBTicketNo.Rows.Count > 0 Then
                _lWBTicketNo = dgWBTicketNo.SelectedRows(0).Cells("dgWBTicket").Value
                _lWeighingID = dgWBTicketNo.SelectedRows(0).Cells("dgWeighingID").Value
                Me.Close()
            End If
        End If
    End Sub
End Class