Imports Production_BOL
Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT

Public Class PressNoLookup

    Public _lMachineID As String = String.Empty
    Public _lPressNo As String = String.Empty
    Public _lCapacity As Decimal
    Public _lMachineName As String = String.Empty
    Private Sub PressNo()
        Dim Ds As New DataSet
        Dim ObjPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL
        ObjPKOProductionLogPPT.PressNo = txtPressNoSearch.Text.Trim
        Ds = PKOProductionLogBOL.GetProductionPKOlogPressNo(ObjPKOProductionLogPPT, "No", CPOProductionLogFrm.PressinfoType)
        If Not Ds Is Nothing Then
            dgPressNo.AutoGenerateColumns = False
            dgPressNo.DataSource = Ds.Tables(0)
        End If

        If Ds Is Nothing Then
            lblNoRecord.Visible = True
        Else
            lblNoRecord.Visible = False
        End If
    End Sub

    Private Sub btnPressNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPressNoSearch.Click
        If txtPressNoSearch.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg1")
            ''MsgBox("Please Enter criteria to Search.")
            PressNo()
            Exit Sub
        Else
            PressNo()
            If dgPressNo.RowCount = 0 Then
                DisplayInfoMessage("Msg2")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If


    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PressNoLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _lMachineID = String.Empty
        _lPressNo = String.Empty
        _lCapacity = 0
        _lMachineName = String.Empty
        Me.Close()
    End Sub
    Private Sub dgPressNo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPressNo.CellDoubleClick
        If dgPressNo.Rows.Count > 0 Then
            _lMachineID = dgPressNo.SelectedRows(0).Cells("dgMachineID").Value
            _lPressNo = dgPressNo.SelectedRows(0).Cells("dgMachineCode").Value
            _lCapacity = dgPressNo.SelectedRows(0).Cells("dgCapacity").Value
            _lMachineName = dgPressNo.SelectedRows(0).Cells("dgMachineName").Value
            Me.Close()
        End If
    End Sub

    Private Sub WBTicketLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        txtPressNoSearch.Focus()
        PressNo()

    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PressNoLookup))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            dgPressNo.Columns("dgMachineCode").HeaderText = rm.GetString("dgMachineCode")
            dgPressNo.Columns("dgMachineName").HeaderText = rm.GetString("dgMachineName")
            dgPressNo.Columns("dgCapacity").HeaderText = rm.GetString("dgCapacity")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PressNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPressNoSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPressNoSearch.KeyDown
        'If e.KeyCode = 13 Then
        '    btnWBTicketNoSearch.Focus()
        'End If
    End Sub

    Private Sub dgPress_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgPressNo.KeyDown
        If e.KeyCode = 13 Then
            If dgPressNo.Rows.Count > 0 Then
                _lMachineID = dgPressNo.SelectedRows(0).Cells("dgMachineID").Value
                _lPressNo = dgPressNo.SelectedRows(0).Cells("dgPressNo").Value
                _lCapacity = dgPressNo.SelectedRows(0).Cells("dgCapacity").Value
                _lMachineName = dgPressNo.SelectedRows(0).Cells("dgMachineName").Value
                Me.Close()
            End If
        End If
    End Sub
End Class