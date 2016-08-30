Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class VHMasterLookup

    '    Dim objValidator As Validator
    Dim _SearchCodePPT As SearchCodePPT
    Dim _SearchCodeBOL As SearchCodeBOL

#Region "Properties"
    Public _lvhCode As String = String.Empty

    Public ReadOnly Property lVHCode() As String
        Get
            Return _lvhCode
        End Get
    End Property

    Public _lvhId As String = String.Empty
    Public ReadOnly Property lVHID() As String
        Get
            Return _lvhId
        End Get
    End Property

    Public _lvhModel As String = String.Empty
    Public ReadOnly Property lVHModel() As String
        Get
            Return _lvhModel
        End Get
    End Property

    Public _lvhName As String = String.Empty
    Public ReadOnly Property lVHName() As String
        Get
            Return _lvhName
        End Get
    End Property

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        'If CheckRequiredFields() Then
        LoadVehicleCode()

        'End If

    End Sub
#End Region

#Region "Events"

    Private Sub VehicleLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVehicleCode()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvVehicleDetails_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvVehicleDetails.MouseDoubleClick
        'Dim lsVehicleCode As String

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvVehicleDetails.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvVehicleDetails.CurrentRow.Index >= 0 And dgvVehicleDetails.CurrentCell.ColumnIndex >= 0 And dgvVehicleDetails.CurrentRow.Selected Then
            Me.DialogResult = DialogResult.OK
            '_lvhId = Me.dgvVehicleDetails.SelectedRows(0).Cells("WorkshopID").Value
            _lvhCode = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHWSCode").Value
            _lvhName = Me.dgvVehicleDetails.SelectedRows(0).Cells("Category").Value
            _lvhModel = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHModel").Value
            Me.Close()
        End If
    End Sub

    Private Sub dgvVehicleDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVehicleDetails.KeyDown
        If dgvVehicleDetails.CurrentRow IsNot Nothing And dgvVehicleDetails.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                'GetWorkshopCode(fromFormName, Me.dgWorkshop.CurrentRow.Cells("WorkshopCode").Value)
                Me.DialogResult = DialogResult.OK
                '_lvhId = Me.dgvVehicleDetails.SelectedRows(0).Cells("WorkshopID").Value
                _lvhCode = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHWSCode").Value
                _lvhName = Me.dgvVehicleDetails.SelectedRows(0).Cells("Category").Value
                _lvhModel = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHModel").Value
                Me.Close()
            End If
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub LoadVehicleCode()

        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        If (rbVehicleCode.Checked) Then
            _SearchCodePPT.psSearchBy = rbVehicleCode.Text
        ElseIf (rbName.Checked) Then
            _SearchCodePPT.psSearchBy = rbName.Text
        ElseIf (rbModel.Checked) Then
            _SearchCodePPT.psSearchBy = rbModel.Text
        End If

        If txtSearchBy.Text.Trim <> String.Empty Then
            _SearchCodePPT.psSearchTerm = txtSearchBy.Text.Trim
        End If

        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID
        _SearchCodePPT.pdLoggedInYear = GlobalPPT.intLoginYear

        Dim dt As DataTable = _SearchCodeBOL.GetSearchVehicle(_SearchCodePPT)

        dgvVehicleDetails.AutoGenerateColumns = False
        dgvVehicleDetails.DataSource = dt

        If (dt Is Nothing Or dt.Rows.Count = 0) And txtSearchBy.Text <> String.Empty Then
            txtSearchBy.Focus()
            MsgBox("No record found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        End If

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvVehicleDetails.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    'Function CheckRequiredFields() As Boolean
    '    lsMessage = String.Empty
    '    objVal = New clsValidator
    '    If Not objVal.RequiredFieldValidator(txtSearchBy.Text) Then
    '        lsMessage += objVal.Required(txtSearchBy.Text, "TextBox", "Please enter criteria to search" & vbCrLf & "")
    '        MsgBox(lsMessage, Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

#End Region

End Class