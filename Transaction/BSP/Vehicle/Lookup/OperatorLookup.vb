Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
'Trk 1 Don't clear the controls on search
Public Class OperatorLookup

    Dim objValidator As Validator
    Dim _SearchCodePPT As SearchCodePPT
    Dim _SearchCodeBOL As SearchCodeBOL

    Public _lEmpCode As String = String.Empty
    Public ReadOnly Property lEmpCode() As String
        Get
            Return _lEmpCode
        End Get
    End Property

    Public _lEmpId As String = String.Empty
    Public ReadOnly Property lEmpId() As String
        Get
            Return _lEmpId
        End Get
    End Property

    Public _lEmpName As String = String.Empty
    Public ReadOnly Property lEmpName() As String
        Get
            Return _lEmpName
        End Get
    End Property


#Region "Events"

    Private Sub SearchOperator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadOperatorCodeAndName()
    End Sub

    Private Sub btnDIVSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperatorSearch.Click
        LoadOperatorCodeAndName()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'GetOperatorCode(String.Empty, String.Empty)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvOperatorCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOperatorCode.KeyDown
        If dgvOperatorCode.CurrentRow IsNot Nothing And dgvOperatorCode.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                'GetOperatorCode(Convert.ToString(dgvOperatorCode.CurrentRow.Cells("EmpCode").Value), Convert.ToString(dgvOperatorCode.CurrentRow.Cells("EmpName").Value))
                Me.DialogResult = DialogResult.OK
                _lEmpId = Me.dgvOperatorCode.SelectedRows(0).Cells("dgclEmpID").Value
                _lEmpCode = Me.dgvOperatorCode.SelectedRows(0).Cells("dgclEmpCode").Value
                _lEmpName = Me.dgvOperatorCode.SelectedRows(0).Cells("dgclEmpName").Value
                Me.Close()
            End If
        End If

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvOperatorCode.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    Private Sub dgvOperatorCode_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvOperatorCode.MouseDoubleClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvOperatorCode.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvOperatorCode.CurrentRow.Index >= 0 And dgvOperatorCode.CurrentCell.ColumnIndex >= 0 And dgvOperatorCode.CurrentRow.Selected Then
            Me.DialogResult = DialogResult.OK
            'GetOperatorCode(Convert.ToString(dgvOperatorCode.Rows(e.RowIndex).Cells("EmpCode").Value), Convert.ToString(dgvOperatorCode.Rows(e.RowIndex).Cells("EmpName").Value))
            _lEmpId = Me.dgvOperatorCode.SelectedRows(0).Cells("dgclEmpID").Value
            _lEmpCode = Me.dgvOperatorCode.SelectedRows(0).Cells("dgclEmpCode").Value
            _lEmpName = Me.dgvOperatorCode.SelectedRows(0).Cells("dgclEmpName").Value
            Me.Close()
        End If
    End Sub

#End Region

#Region "Functions"
    Private Sub LoadOperatorCodeAndName()
        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        _SearchCodePPT.psEmpCode = txtOperatorCodeSearch.Text.Trim
        _SearchCodePPT.psEmpName = txtOperatorNameSearch.Text.Trim
        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        Dim dtOperatorCode As DataTable = _SearchCodeBOL.GetSearchOperator(_SearchCodePPT)
        dgvOperatorCode.AutoGenerateColumns = False
        dgvOperatorCode.DataSource = dtOperatorCode
        dgvOperatorCode.ClearSelection()

        If (dtOperatorCode Is Nothing Or dtOperatorCode.Rows.Count = 0) And (txtOperatorCodeSearch.Text.Trim <> String.Empty OrElse txtOperatorNameSearch.Text.Trim <> String.Empty) Then
            MsgBox("No record found.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If

        'Trk 1
        'txtOperatorCodeSearch.Text = String.Empty
        'txtOperatorNameSearch.Text = String.Empty

    End Sub

    Private Sub GetOperatorCode(ByVal lsOperatorCode As String, ByVal lsOperatorname As String)
        'Select Case (formName)
        '    'Case "VehicleRunningLog"
        '    '    VehicleRunningLog.txtDIV.Text = Convert.ToString(dgvOperatorCode.Rows(e.RowIndex).Cells("DIVCode").Value)
        '    '    Me.Hide()
        '    '    VehicleRunningLog.Show()
        '    Case "WorkshopLog"
        '        If lsOperatorCode <> String.Empty Then
        '            'WorkshopLog.txtOperatorCode.Text = lsOperatorCode 'Convert.ToString(dgvOperatorCode.Rows(e.RowIndex).Cells("EmpCode").Value)
        '            'WorkshopLog.txtOperatorName.Text = lsOperatorname 'Convert.ToString(dgvOperatorCode.Rows(e.RowIndex).Cells("EmpName").Value)
        '        End If
        '        Me.Hide()
        '        'WorkshopLog.Show()
        '        'Case "VehicleDistribution"
        '        '    VehicleDistribution.txtOperatorCode.Text = Convert.ToString(dgvOperatorCode.Rows(e.RowIndex).Cells("DIVCode").Value)
        '        '    Me.Hide()
        '        '    VehicleDistribution.Show()
        'End Select
    End Sub
#End Region

End Class
