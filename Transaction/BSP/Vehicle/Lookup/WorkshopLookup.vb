Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class WorkshopLookup
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim objValidator As Validator
    Dim _SearchCodePPT As SearchCodePPT
    Dim _SearchCodeBOL As SearchCodeBOL

    Public _lwsCode As String = String.Empty
    Public ReadOnly Property lWSCode() As String
        Get
            Return _lwsCode
        End Get
    End Property

    Public _lwsId As String = String.Empty
    Public ReadOnly Property lWSID() As String
        Get
            Return _lwsId
        End Get
    End Property

    Public _lwsModel As String = String.Empty
    Public ReadOnly Property lWSModel() As String
        Get
            Return _lwsModel
        End Get
    End Property

    Public _lwsName As String = String.Empty
    Public ReadOnly Property lWSName() As String
        Get
            Return _lwsName
        End Get
    End Property

#Region "Events"

    Private Sub SearchWorkshop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboVHCategory()
        BindWorkshopCodeBySearchInput()
    End Sub

    Private Sub btnVHNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVHNoSearch.Click
        'If CheckRequiredFieldsOfWorkshopSearch() Then
        BindWorkshopCodeBySearchInput()
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'GetWorkshopCode(fromFormName, String.Empty)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvWorkshop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvWorkshop.KeyDown
        If dgvWorkshop.CurrentRow IsNot Nothing And dgvWorkshop.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                'GetWorkshopCode(fromFormName, Me.dgvWorkshop.CurrentRow.Cells("WorkshopCode").Value)
                Me.DialogResult = DialogResult.OK
                _lwsId = Me.dgvWorkshop.SelectedRows(0).Cells("dgclWorkshopVHID").Value
                _lwsCode = Me.dgvWorkshop.SelectedRows(0).Cells("dgclWorkshopVHID").Value
                _lwsName = Me.dgvWorkshop.SelectedRows(0).Cells("dgclCategory").Value
                _lwsModel = Me.dgvWorkshop.SelectedRows(0).Cells("dgclVHModel").Value
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvWorkshop.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub
#End Region

#Region "Functions"
    Private Sub BindWorkshopCodeBySearchInput()
        _SearchCodePPT = New SearchCodePPT()
        _SearchCodeBOL = New SearchCodeBOL

        'If Me.rdoWorkshopCode.Checked Then
        '    _SearchCodePPT.psSearchBy = Me.rdoWorkshopCode.Text
        'ElseIf Me.rdoModel.Checked Then
        '    _SearchCodePPT.psSearchBy = Me.rdoModel.Text
        'Else
        '    _SearchCodePPT.psSearchBy = Me.rdoName.Text
        'End If

        '_SearchCodePPT.psSearchTerm = Me.txtWorkshopSearch.Text

        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID
        _SearchCodePPT.psVHID = IIf(txtVHNoSearch.Text.Trim = String.Empty, Nothing, txtVHNoSearch.Text.Trim)
        _SearchCodePPT.psCategory = IIf(cmbVHCategory.SelectedIndex = 0, Nothing, cmbVHCategory.SelectedValue)
        _SearchCodePPT.psModel = IIf(txtVehicleName.Text.Trim = String.Empty, Nothing, txtVehicleName.Text.Trim)
        _SearchCodePPT.pdLoggedInYear = GlobalPPT.intLoginYear

        'dsWorkshopCode = _SearchCodeBOL.GetSearchWorkshop(_SearchCodePPT)
        Dim dtSearchCode As DataTable
        dtSearchCode = _SearchCodeBOL.GetSearchWorkshop(_SearchCodePPT)
        Me.dgvWorkshop.AutoGenerateColumns = False
        Me.dgvWorkshop.DataSource = dtSearchCode
        Me.dgvWorkshop.ClearSelection()

        If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And txtVHNoSearch.Text.Trim <> String.Empty Then
            MsgBox("No record found.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If
    End Sub

    Private Sub GetWorkshopCode(ByVal lsFormName As String, ByVal lsValue As String)
        Select Case (lsFormName)
            Case "WorkshopLog"
                If lsValue <> String.Empty Then
                    'WorkshopLog.txtWorkshopCode.Text = lsValue
                    'WorkshopLog.BindWorkshopLogDetailsByWorkshopCode(WorkshopLog.txtWorkshopCode.Text.Trim, New Date(WorkshopLog.dtpDate.Value.Year, WorkshopLog.dtpDate.Value.Month, WorkshopLog.dtpDate.Value.Day))
                End If
                'Me.Close()
                'WorkshopLog.Show()
        End Select
    End Sub

    Private Sub FillComboVHCategory()
        _SearchCodeBOL = New SearchCodeBOL
        _SearchCodePPT = New SearchCodePPT
        _SearchCodePPT.pcType = "W"
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

#End Region

    Private Sub dgvWorkshop_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvWorkshop.MouseDoubleClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvWorkshop.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvWorkshop.CurrentRow.Index >= 0 And dgvWorkshop.CurrentCell.ColumnIndex >= 0 And dgvWorkshop.CurrentRow.Selected Then
            'GetWorkshopCode(fromFormName, Me.dgvWorkshop.Rows(e.RowIndex).Cells("WorkshopCode").Value)
            Me.DialogResult = DialogResult.OK
            _lwsId = Me.dgvWorkshop.SelectedRows(0).Cells("dgclWorkshopVHID").Value
            _lwsCode = Me.dgvWorkshop.SelectedRows(0).Cells("dgclWorkshopVHID").Value
            _lwsName = Me.dgvWorkshop.SelectedRows(0).Cells("dgclCategory").Value
            _lwsModel = Me.dgvWorkshop.SelectedRows(0).Cells("dgclVHModel").Value
            Me.Close()
        End If

    End Sub

End Class