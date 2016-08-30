Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class VHDIVLookup

    Dim _SearchCodePPT As SearchCodePPT
    Dim _SearchCodeBOL As SearchCodeBOL

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

    Private Sub btnDIVSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDIVSearch.Click

        LoadDivCodeAndName()

    End Sub

    Private Sub LoadDivCodeAndName()
        _SearchCodePPT = New SearchCodePPT
        _SearchCodeBOL = New SearchCodeBOL

        _SearchCodePPT.psDIVCode = txtDIVSearch.Text
        _SearchCodePPT.psDIVName = txtDivNameSearch.Text
        _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        Dim dtSearchCode As DataTable = _SearchCodeBOL.GetSearchDivision(_SearchCodePPT)
        dgDIV.AutoGenerateColumns = False
        dgDIV.DataSource = dtSearchCode
        dgDIV.ClearSelection()

        If (dtSearchCode Is Nothing Or dtSearchCode.Rows.Count = 0) And (txtDIVSearch.Text.Trim <> String.Empty OrElse txtDivNameSearch.Text.Trim <> String.Empty) Then
            MsgBox("No division found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgDIV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDIV.KeyDown
        If dgDIV.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                e.Handled = True

                Me.DialogResult = DialogResult.OK
                _ldivCode = Convert.ToString(dgDIV.CurrentRow.Cells("Div").Value)
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgDIV.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    Private Sub dgDIV_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgDIV.MouseDoubleClick
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgDIV.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgDIV.CurrentRow.Index >= 0 And dgDIV.CurrentCell.ColumnIndex >= 0 And dgDIV.CurrentRow.Selected Then
            Me.DialogResult = DialogResult.OK
            _ldivCode = Convert.ToString(dgDIV.CurrentRow.Cells("dgclDiv").Value)
            Me.Close()

        End If
    End Sub

    Private Sub DIVLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDivCodeAndName()
    End Sub
End Class
