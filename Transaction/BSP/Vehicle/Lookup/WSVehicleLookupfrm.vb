Imports Vehicle_PPT
Imports Vehicle_BOL

Imports Store_PPT
Imports Store_BOL

Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class WSVehicleLookupfrm

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

    Public _lVHDescp As String = String.Empty
    Public ReadOnly Property lVHDescp() As String
        Get
            Return _lVHDescp
        End Get
    End Property
#End Region

#Region "Events"

    Private Sub VehicleLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboVHCategory()
        LoadVehicleCode()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnVHNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVHNoSearch.Click

        If (txtVHNoSearch.Text = String.Empty And txtVehicleModel.Text.Trim = String.Empty And cmbVHCategory.SelectedIndex = 0) Then
            MsgBox("Please enter search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            txtVHNoSearch.Focus()
            ' Return
        End If

        LoadVehicleCode()
    End Sub

    Private Sub dgvVehicleDetails_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvVehicleDetails.MouseDoubleClick
        'Dim lsVehicleCode As String

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvVehicleDetails.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvVehicleDetails.CurrentRow.Index >= 0 And dgvVehicleDetails.CurrentCell.ColumnIndex >= 0 And dgvVehicleDetails.CurrentRow.Selected Then
            Me.DialogResult = DialogResult.OK
            _lvhId = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclVHID").Value
            _lvhCode = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclVHWSCode").Value
            _lvhName = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclCategory").Value
            _lVHDescp = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclDesc").Value
            '_lvhModel = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHModel").Value
            Me.Close()
        End If
    End Sub

    Private Sub dgvVehicleDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVehicleDetails.KeyDown

        If dgvVehicleDetails.RowCount = 0 Then
            Return
        End If

        If dgvVehicleDetails.CurrentRow IsNot Nothing And dgvVehicleDetails.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                'GetWorkshopCode(fromFormName, Me.dgWorkshop.CurrentRow.Cells("WorkshopCode").Value)
                Me.DialogResult = DialogResult.OK
                _lvhId = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHID").Value
                _lvhCode = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclVHWSCode").Value
                _lvhName = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclCategory").Value
                _lVHDescp = Me.dgvVehicleDetails.SelectedRows(0).Cells("dgclDesc").Value
                '   _lvhModel = Me.dgvVehicleDetails.SelectedRows(0).Cells("VHModel").Value
                Me.Close()
            End If
        End If
    End Sub

    Private Sub VHLookupfrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub LoadVehicleCode()

        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID
        _SearchCodePPT.psVHID = IIf(txtVHNoSearch.Text.Trim = String.Empty, Nothing, txtVHNoSearch.Text.Trim)
        _SearchCodePPT.psCategory = IIf(cmbVHCategory.SelectedIndex = 0, Nothing, cmbVHCategory.SelectedValue)
        _SearchCodePPT.psModel = IIf(txtVehicleModel.Text.Trim = String.Empty, Nothing, txtVehicleModel.Text.Trim)
        _SearchCodePPT.pdLoggedInYear = GlobalPPT.intLoginYear

        Dim dt As DataTable = _SearchCodeBOL.GetSearchWSVehicle(_SearchCodePPT)

        dgvVehicleDetails.AutoGenerateColumns = False
        dgvVehicleDetails.DataSource = dt

        If (dt Is Nothing Or dt.Rows.Count = 0) And (txtVHNoSearch.Text <> String.Empty Or txtVehicleModel.Text <> String.Empty Or cmbVHCategory.SelectedIndex > 0) Then
            txtVHNoSearch.Focus()
            MsgBox("No record(s) found matching your search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        End If

        'txtVHNoSearch.Text = String.Empty
        'txtVehicleModel.Text = String.Empty
        'cmbVHCategory.SelectedIndex = 0

    End Sub

    Private Sub FillComboVHCategory()
        _SearchCodeBOL = New SearchCodeBOL
        _SearchCodePPT = New SearchCodePPT
        _SearchCodePPT.pcType = "V"
        Dim dTCategory As DataTable = _SearchCodeBOL.VHNCategoryGet(_SearchCodePPT)

        Try
            Dim dr As DataRow = dTCategory.NewRow()
            dr(0) = "--Select Category--"
            dr(1) = "--Select Category--"
            dTCategory.Rows.InsertAt(dr, 0)
            dTCategory.AcceptChanges()

            'cmbSIVNO.Items.Clear()
            cmbVHCategory.DataSource = Nothing
            cmbVHCategory.DataSource = dTCategory
            cmbVHCategory.DisplayMember = "Category"
            cmbVHCategory.ValueMember = "VHCategoryID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvVehicleDetails.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

#End Region

End Class