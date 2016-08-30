Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports System.Data.SqlClient
Imports Common_DAL

Public Class CommonLookUp

    Private _Proc As String = String.Empty
    Private _Params() As SqlParameter
    Private _HideFirstID As Boolean = False
    Private _SearchColumn As Integer = 0
    Private _ResultCount As Integer = 1

    Public Result As List(Of Object) = New List(Of Object)
    Dim rm As System.Resources.ResourceManager


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtSearchValue.Text = String.Empty
        DialogResult = DialogResult.Cancel
    End Sub

    Public Sub New(ByVal proc As String, ByVal params() As SqlParameter, Optional ByVal outputCount As Integer = 1, Optional ByVal hideFirstColumn As Boolean = False)
        InitializeComponent()
        _Proc = proc
        _Params = params
        _HideFirstID = hideFirstColumn
        _ResultCount = outputCount
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        rm = New System.Resources.ResourceManager(GetType(CommonLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CommonLookUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        If (_Proc.Length <= 0) Then
            DisplayInfoMessage("Msg3")
        Else
            LoadSearch()
        End If
    End Sub


    Private Sub dgvResult_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResult.CellDoubleClick

        If (e.RowIndex >= 0) Then
            SelectResult()
        End If

    End Sub

    Sub SelectResult()
        DialogResult = Windows.Forms.DialogResult.OK

        For index = 0 To _ResultCount - 1
            Try
                Result.Add(dgvResult.SelectedRows(0).Cells(index).Value)
            Catch ex As Exception
                Result.Add(Nothing)
            End Try
        Next

        Me.Close()
    End Sub


    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub dgvResult_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvResult.KeyPress
        SelectResult()
    End Sub

    Sub Search()
        Dim rowfilter As String = String.Empty
        Try
            If (dgvResult.Columns.Count <= 0) Then
                Return
            End If
            If (dgvResult.Columns(_SearchColumn).ValueType.ToString() = "System.String") Then
                rowfilter = String.Format("[{0}] like '%{1}%'", dgvResult.Columns(_SearchColumn).Name, txtSearchValue.Text)
            Else
                rowfilter = String.Format("[{0}] = {1}", dgvResult.Columns(_SearchColumn).Name, txtSearchValue.Text)
            End If
            Dim dt As DataTable = dgvResult.DataSource
            dt.DefaultView.RowFilter = rowfilter
            dgvResult.Focus()
        Catch ex As Exception
            MsgBox("Error in Search: " + ex.Message)
        End Try
    End Sub
    Sub LoadSearch()
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        dt = (dgvResult.DataSource)

        Dim ds As DataSet = Nothing
        Try
            ds = objdb.ExecQuery(_Proc, _Params, False)
        Catch ex As Exception
            MsgBox("Error in retriving data. Please check. Detail: " + ex.Message)
            Me.Close()
        End Try
        If (Not (ds Is Nothing) And ds.Tables.Count > 0) Then
            dgvResult.DataSource = ds.Tables(0)
            If (dgvResult.ColumnCount > 0) Then

                If (dgvResult.ColumnCount < Result.Count) Then
                    MsgBox("Invalid number of columns in data(" + dgvResult.ColumnCount + ") than the expected number of result(" + Result.Count + ")")
                End If

                dgvResult.Columns(0).Visible = Not _HideFirstID
                _SearchColumn = 0
                lblSearchField.Text = "Search " + dgvResult.Columns(0).Name
                Me.Text = "Select " + dgvResult.Columns(0).Name
                dgvResult.Focus()
            End If
        End If
    End Sub

    Private Sub dgvResult_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvResult.ColumnHeaderMouseDoubleClick
        _SearchColumn = e.ColumnIndex
        lblSearchField.Text = "Search " + dgvResult.Columns(e.ColumnIndex).Name
    End Sub

    Private Sub txtSearchValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchValue.KeyPress
        If (e.KeyChar = Convert.ChangeType(Keys.Enter, GetType(Char))) Then
            Search()
        End If
    End Sub
End Class