Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class VHYOPLookup

    Dim _SearchCodePPT As SearchCodePPT
    Dim _SearchCodeBOL As SearchCodeBOL

    Dim lsDIVCode As String
    'Dim lsFormCall As String

    Public _lyopCode As String = String.Empty
    Public ReadOnly Property lYOPCode() As String
        Get
            Return _lyopCode
        End Get
    End Property

    Public _lyopId As String = String.Empty
    Public ReadOnly Property lYOPID() As String
        Get
            Return _lyopId
        End Get
    End Property

    Public _lyopDiv As String = String.Empty
    Public ReadOnly Property lYOPDiv() As String
        Get
            Return _lyopDiv
        End Get
    End Property

    Public Sub New(ByVal lsDIV As String)
        Me.InitializeComponent()
        'lsFormCall = lsFormCallParam
        lsDIVCode = lsDIV
    End Sub

    Private Sub YOPLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        _SearchCodePPT.psDIVCode = lsDIVCode
        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        Dim dtSearchCode As DataTable = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)
        dgYOP.AutoGenerateColumns = False
        dgYOP.DataSource = dtSearchCode 'dsYOPCodeAndName.Tables(0)
        dgYOP.ClearSelection()

        If (dtSearchCode Is Nothing OrElse dtSearchCode.Rows.Count = 0) Then
            MsgBox("No YOP found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If

        'If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And (txtYOPSearch.Text.Trim <> String.Empty Or txtYOPNameSearch.Text.Trim <> String.Empty) Then
        '    MsgBox("No YOP found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        'End If

    End Sub

    Private Sub btnYOPSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYOPSearch.Click

        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        _SearchCodePPT.psYOPCode = IIf(txtYOPSearch.Text.Trim = String.Empty, Nothing, txtYOPSearch.Text.Trim)
        _SearchCodePPT.psYOPName = IIf(txtYOPNameSearch.Text.Trim = String.Empty, Nothing, txtYOPNameSearch.Text.Trim)
        _SearchCodePPT.psDIVCode = lsDIVCode
        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        Dim dtSearchCode As DataTable = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)
        dgYOP.AutoGenerateColumns = False
        dgYOP.DataSource = dtSearchCode
        dgYOP.ClearSelection()

        If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And (txtYOPSearch.Text.Trim <> String.Empty Or txtYOPNameSearch.Text.Trim <> String.Empty) Then
            MsgBox("No YOP found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If

    End Sub

    'Private Sub LoadYOPCodeAndName()
    '    _SearchCodePPT = New SearchCodePPT
    '    _SearchCodeBOL = New SearchCodeBOL

    '    If rbDIVCode.Checked Then
    '        _SearchCodePPT.psSearchBy = "DIV"
    '        _SearchCodePPT.psDIVCode = txtSearchBy.Text
    '    ElseIf rbYOPCode.Checked Then
    '        _SearchCodePPT.psSearchBy = "YOP"
    '        _SearchCodePPT.psYOPCode = txtSearchBy.Text
    '    End If

    '    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '    Dim dtSearchCode As DataTable = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)
    '    dgYOP.AutoGenerateColumns = False
    '    dgYOP.DataSource = dtSearchCode
    '    dgYOP.ClearSelection()

    '    If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And (txtYOPSearch.Text.Trim.Text.Trim <> String.Empty Or txtYOPNameSearch.Text.Trim <> String.Empty) Then
    '        MsgBox("No YOP found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
    '    End If

    'End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgYOP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgYOP.KeyDown
        If dgYOP.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                e.Handled = True
                Me.DialogResult = DialogResult.OK
                _lyopCode = Convert.ToString(dgYOP.CurrentRow.Cells("YOPCode").Value)
                _lyopDiv = Convert.ToString(dgYOP.CurrentRow.Cells("Div").Value)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgYOP.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    Private Sub dgYOP_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgYOP.MouseDoubleClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgYOP.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgYOP.CurrentRow.Index >= 0 And dgYOP.CurrentCell.ColumnIndex >= 0 And dgYOP.CurrentRow.Selected Then
            Me.DialogResult = DialogResult.OK
            _lyopCode = Convert.ToString(dgYOP.CurrentRow.Cells("dgclYOP").Value)
            '_lyopDiv = Convert.ToString(dgYOP.CurrentRow.Cells("Div").Value)
            Me.Close()
        End If
    End Sub
End Class