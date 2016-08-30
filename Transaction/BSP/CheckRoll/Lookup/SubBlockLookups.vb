'/******************************
'
' By Dadang Adi Hendradi
' Jum'at, 4 Sep 2009, 15:24
'
'/******************************
Imports CheckRoll_DAL
Imports Common_PPT

Public Class SubBlockLookups

    Private _BlockID As String
    Private _BlockName As String = System.DBNull.Value.ToString()
    Private _DivID As String
    Private _DIV As String
    Private _YOPID As String
    Private _YOP As String
    Private _BlockStatus As String = String.Empty

    Public Sub New(ByVal _subBlockName As String)
        ' Sabtu, 5 Sep 2009, 17:46
        InitializeComponent()
        SubBlockName = _subBlockName
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SubBlockLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Jum'at, 4 Sep 2009, 15:24
        dgvSubBlock.DataSource = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(SubBlockName)
        dgvSubBlock.Focus()
        ManageGridColumn()
        dgvSubBlock.DefaultCellStyle.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub ManageGridColumn()
        ' Wednesday, 14 Oct 2009
        dgvSubBlock.Columns("bmColumnDIVName").DisplayIndex = 0
        dgvSubBlock.Columns("bmColumnYOP").DisplayIndex = 1
        dgvSubBlock.Columns("bmColumnBlockName").DisplayIndex = 2

    End Sub

    Private Sub dgvSubBlock_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSubBlock.SelectionChanged
        ' Jum'at, 4 Sep 2009, 16:21
        If (dgvSubBlock.Rows.Count = 0) Then
            Return
        End If

        If dgvSubBlock.CurrentCell Is Nothing Then
            Return
        End If

    End Sub

    Public Property SubBlockName() As String
        ' Jum'at, 4 Sep 2009, 20:56

        Get
            Return _BlockName
        End Get
        Set(ByVal value As String)
            _BlockName = value
        End Set
    End Property

    Public Property BlockID() As String
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)
            _BlockID = value
        End Set
    End Property

    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property

    Public Property DIV() As String
        ' Jum'at, 4 Sep 2009, 21:00
        Get
            Return _DIV
        End Get
        Set(ByVal value As String)
            _DIV = value
        End Set
    End Property

    Public Property YOPID() As String
        Get
            Return _YOPID
        End Get
        Set(ByVal value As String)
            _YOPID = value
        End Set
    End Property

    Public Property YOP() As String

        ' Jum'at, 4 Sep 2009, 21:01
        Get
            Return _YOP
        End Get
        Set(ByVal value As String)
            _YOP = value
        End Set
    End Property

    Public Property SubBlockID() As String
        ' Jum'at, 4 Sep 2009, 21:02
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)
            _BlockID = value
        End Set
    End Property

    Public Property BlockStatus() As String
        Get
            Return _BlockStatus
        End Get
        Set(ByVal value As String)
            _BlockStatus = value
        End Set
    End Property

    Private Sub dgvSubBlock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSubBlock.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectOneRow()

        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub SelectOneRow()
        If dgvSubBlock.Rows.Count > 0 Then
            If Not dgvSubBlock.CurrentCell Is Nothing Then

                Dim rowIndex As Integer = dgvSubBlock.CurrentCell.RowIndex

                Me.SubBlockName = dgvSubBlock.Rows(rowIndex).Cells("bmColumnBlockName").Value.ToString()
                BlockID = dgvSubBlock.CurrentCell.OwningRow.Cells("bmColumnBlockID").Value.ToString()

                DivID = dgvSubBlock.CurrentCell.OwningRow.Cells("bmColumnDivID").Value.ToString()
                DIV = dgvSubBlock.CurrentCell.OwningRow.Cells("bmColumnDivName").Value.ToString()

                YOPID = dgvSubBlock.CurrentCell.OwningRow.Cells("bmColumnYOPID").Value.ToString()
                YOP = dgvSubBlock.CurrentCell.OwningRow.Cells("bmColumnYOP").Value.ToString()

                BlockStatus = dgvSubBlock.CurrentCell.OwningRow.Cells("bmColumnBlockStatus").Value.ToString()
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtSubBlockName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubBlockName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SubBlockName = txtSubBlockName.Text
            SearchBySubBlockName()
        End If
    End Sub

    Private Sub SearchBySubBlockName()
        SubBlockName = txtSubBlockName.Text.Trim
        dgvSubBlock.DataSource = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(SubBlockName)
        dgvSubBlock.Focus()
    End Sub

    Private Sub dgvSubBlock_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubBlock.CellDoubleClick
        SelectOneRow()
    End Sub

    Private Sub dgvSubBlock_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubBlock.CellContentClick

    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        SearchBySubBlockName()
    End Sub
End Class