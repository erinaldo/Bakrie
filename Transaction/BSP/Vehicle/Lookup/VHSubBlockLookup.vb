Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class VHSubBlockLookup

    Dim _SearchCodePPT As SearchCodePPT
    Dim _SearchCodeBOL As SearchCodeBOL

    Dim lsDIVCode As String
    Dim lsYOPCode As String

    Public _lyopCode As String = String.Empty
    Public ReadOnly Property lYOPCode() As String
        Get
            Return _lyopCode
        End Get
    End Property

    Public _lsbCode As String = String.Empty
    Public ReadOnly Property lSBCode() As String
        Get
            Return _lsbCode
        End Get
    End Property

    Public _ldivCode As String = String.Empty
    Public ReadOnly Property lDivCode() As String
        Get
            Return _ldivCode
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.

        'Me.dgVehicleBatchDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        'The above line is added to make column header wrapt to be false.
        InitializeComponent()

    End Sub

    Public Sub New(ByVal lsDIV As String, ByVal lsYOP As String)
        Me.InitializeComponent()
        'lsFormCall = lsFormCallParam
        lsDIVCode = lsDIV
        lsYOPCode = lsYOP
    End Sub

    Private Sub SubBlockLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        If rbSubBlock.Checked Then
            _SearchCodePPT.psSearchBy = "SubBlock"

            If lsDIVCode <> String.Empty Then
                _SearchCodePPT.psDIVCode = lsDIVCode
            End If

            If lsYOPCode <> String.Empty Then
                _SearchCodePPT.psYOPCode = lsYOPCode
            End If



            'Select Case lsNameOfForm
            '    Case "VehicleRunningLog"
            '        If VehicleRunningLog.txtDIV.Text.Trim <> String.Empty Then
            '            _SearchCodePPT.psDIVCode = VehicleRunningLog.txtDIV.Text.Trim
            '        End If

            '        If VehicleRunningLog.txtYOP.Text.Trim <> String.Empty Then
            '            _SearchCodePPT.psYOPCode = VehicleRunningLog.txtYOP.Text.Trim
            '        End If
            '    Case "VehicleDistribution"
            '        If VehicleDistribution.txtDIV.Text.Trim <> String.Empty Then
            '            _SearchCodePPT.psDIVCode = VehicleDistribution.txtDIV.Text.Trim
            '        End If

            '        If VehicleDistribution.txtYOP.Text.Trim <> String.Empty Then
            '            _SearchCodePPT.psYOPCode = VehicleDistribution.txtYOP.Text.Trim
            '        End If
            '    Case "WorkshopLog"
            '        If WorkshopLog.txtDIV.Text.Trim <> String.Empty Then
            '            _SearchCodePPT.psDIVCode = WorkshopLog.txtDIV.Text.Trim
            '        End If

            '        If WorkshopLog.txtYOP.Text.Trim <> String.Empty Then
            '            _SearchCodePPT.psYOPCode = WorkshopLog.txtYOP.Text.Trim
            '        End If
            'End Select


        End If

        _SearchCodePPT.psSearchTerm = "OnLoad"

        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID


        Dim dtSearchCode As DataTable = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)
        dgvSubBlockCode.AutoGenerateColumns = False
        dgvSubBlockCode.DataSource = dtSearchCode
        dgvSubBlockCode.ClearSelection()

        If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And txtSearchBy.Text.Trim <> String.Empty Then
            MsgBox("No sub-block found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If

    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        If rbSubBlock.Checked Then

            If txtSearchBy.Text.Trim <> String.Empty Then
                _SearchCodePPT.psSubBlockCode = txtSearchBy.Text.Trim
            End If

        ElseIf rbYOPCode.Checked Then

            If txtSearchBy.Text.Trim <> String.Empty Then
                _SearchCodePPT.psYOPCode = txtSearchBy.Text.Trim
            End If

        ElseIf rbDIVCode.Checked Then
            If txtSearchBy.Text.Trim <> String.Empty Then
                _SearchCodePPT.psDIVCode = txtSearchBy.Text.Trim
            End If

        End If

        _SearchCodePPT.psSearchTerm = "OnGo"

        '_SearchCodePPT.psSubBlockCodeOrName = txtSearchBy.Text
        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        Dim dtSearchCode As DataTable = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)
        dgvSubBlockCode.AutoGenerateColumns = False
        dgvSubBlockCode.DataSource = dtSearchCode
        dgvSubBlockCode.ClearSelection()

        If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And txtSearchBy.Text.Trim <> String.Empty Then
            MsgBox("No sub-block found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If

    End Sub




    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvSubBlockCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSubBlockCode.KeyDown
        If dgvSubBlockCode.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                e.Handled = True

                Me.DialogResult = DialogResult.OK
                _ldivCode = Convert.ToString(dgvSubBlockCode.CurrentRow.Cells("Div").Value)
                _lyopCode = Convert.ToString(dgvSubBlockCode.CurrentRow.Cells("YOP").Value)
                _lsbCode = Convert.ToString(dgvSubBlockCode.CurrentRow.Cells("BlockName").Value)
                Me.Close()


            End If
        End If
    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvSubBlockCode.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    Private Sub dgvSubBlockCode_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvSubBlockCode.MouseDoubleClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvSubBlockCode.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvSubBlockCode.CurrentRow.Index >= 0 And dgvSubBlockCode.CurrentCell.ColumnIndex >= 0 And dgvSubBlockCode.CurrentRow.Selected Then
            Me.DialogResult = DialogResult.OK
            _ldivCode = Convert.ToString(dgvSubBlockCode.CurrentRow.Cells("Div").Value)
            _lyopCode = Convert.ToString(dgvSubBlockCode.CurrentRow.Cells("YOP").Value)
            _lsbCode = Convert.ToString(dgvSubBlockCode.CurrentRow.Cells("BlockName").Value)
            Me.Close()
        End If

    End Sub
End Class