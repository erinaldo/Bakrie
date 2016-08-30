Imports Vehicle_BOL
Imports Vehicle_PPT
Imports Common_PPT

Public Class VehicleRunningBatchFrm


#Region "localVariablesAndClassDeclarations"
    Dim _Val As Validator
    Dim lsMessage As String
    Dim _VehicleRunningBatchPPT As VehicleRunningBatchPPT
    Dim _VehicleRunningBatchBOL As VehicleRunningBatchBOL
    Dim liID As Integer 'For storing the Edited OR Deleted ID
    Private dateIsChangedByUser As Boolean = False 'Stop and previnting from fring an event on dtpDate on DateChanged
    Dim lbConcurrencyID As Byte() = New Byte(7) {}
    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,3})?$")
    'To make sure that decimal should not ends with "." while save or update
    Dim decimalNotEndsWithPeriod As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,1})?[^\.]$")
    'Dim reValidateTime As New System.Text.RegularExpressions.Regex("([0-1]\d|2[0-3]).([0-5]\d)")
    Dim reValidateTime As New System.Text.RegularExpressions.Regex("^(([0-1][0-9])|([2][0-3]))[.]([0-5][0-9])$")
    Shared dsVRB As DataSet
    'Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("[0-9]{0,15}(\.[0-9]{0,1})?")
    Shared dsVehicleBatchDetails As DataSet

#End Region

#Region "Events"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub VehicleRunningBatchFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Check for database connection in start up

        'Setting Default date for the DateTimePicker

        dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDate.MaxDate = GlobalPPT.FiscalYearToDate

        dtpSearchBy.MinDate = GlobalPPT.FiscalYearFromDate
        dtpSearchBy.MaxDate = GlobalPPT.FiscalYearToDate

        ResetControls("Date")

        dgvVehicleBatchDetails.Columns("VHBatchDT").DefaultCellStyle.Format = "dd/MM/yyyy"
        dgvVehicleBatchDetails.Columns("VHRBatchHrsKm").DefaultCellStyle.Format = "0,0.0,0"

        tcVehicleRunningBatch.SelectTab(1)
        LoadVehicleCode(String.Empty, String.Empty)
        dtpDate.Focus()

    End Sub

    Private Sub ibtnSearchVehicleCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchVehicleCode.Click

        Dim objVHLookup As New VHLookup()
        Dim result As DialogResult = objVHLookup.ShowDialog()

        If (result = DialogResult.OK) Then

            txtVehicleCode.Text = objVHLookup.lVHCode
            LoadBatchDetails(objVHLookup.lVHCode)

        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        LoadVehicleCode(txtVehicleCodeView.Text.Trim, "Search")

    End Sub

    Private Sub btnSaveOrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveOrUpdate.Click

        If Not CheckRequiredFields() Then
            Return
        End If

        If Not CheckIsNumericAndValidTime() Then
            Return
        End If

        If Not ValidVehicleCode() Then
            Return
        End If

        Dim liMessageValue As Integer

        _VehicleRunningBatchBOL = New VehicleRunningBatchBOL

        _VehicleRunningBatchPPT.psVHWSCode = txtVehicleCode.Text.Trim
        _VehicleRunningBatchPPT.pdVHBatchDT = New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)

        _VehicleRunningBatchPPT.piVHBatchValue = Convert.ToDecimal(txtBatchValue.Text.Trim)
        'Global
        _VehicleRunningBatchPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleRunningBatchPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        If btnSaveOrUpdate.Text = "Save" Then

            'Global

            _VehicleRunningBatchPPT.psCreateBy = GlobalPPT.strUserName

            liMessageValue = _VehicleRunningBatchBOL.SaveVehicleRunningBatch(_VehicleRunningBatchPPT)

            General.ShowMessageFromDataBase(liMessageValue)

            If liMessageValue = 10 Then
                Return
            End If

            'FillBatchGridByVehicleCode(_VehicleRunningBatchPPT.psVHID)

        ElseIf btnSaveOrUpdate.Text = "Update" Then

            'Global
            _VehicleRunningBatchPPT.psCreateBy = GlobalPPT.strUserName
            _VehicleRunningBatchPPT.piID = liID
            _VehicleRunningBatchPPT.piConcurrencyId = lbConcurrencyID

            liMessageValue = _VehicleRunningBatchBOL.UpdateVehicleRunningBatch(_VehicleRunningBatchPPT)

            General.ShowMessageFromDataBase(liMessageValue)

            If liMessageValue = 10 Then
                Return
            End If

        End If

        ResetControls("Enable")
        ResetControls(String.Empty)

        tcVehicleRunningBatch.SelectTab(0)
        'LoadVehicleCode(String.Empty, String.Empty)
        LoadBatchDetails(String.Empty)
        txtVehicleCodeView.Focus()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetControls(String.Empty)
        ResetControls("Enable")
        ResetControls("Date")

        txtVehicleCodeView.Focus()

    End Sub

    'Private Sub tcVehicleRunningBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcVehicleRunningBatch.SelectedIndexChanged

    '    Select Case tcVehicleRunningBatch.SelectedIndex
    '        Case 0
    '            ResetControls(String.Empty)
    '            LoadBatchDetails(String.Empty)
    '        Case 1
    '            rbVehicleCode.Checked = True
    '            dtpSearchBy.Visible = False
    '            txtVehicleCodeView.Visible = True
    '            txtVehicleCodeView.Text = String.Empty

    '            LoadVehicleCode(String.Empty, String.Empty)
    '    End Select

    'End Sub

    Private Sub tcVehicleRunningBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcVehicleRunningBatch.Click
        Select Case tcVehicleRunningBatch.SelectedIndex
            Case 0
                ResetControls(String.Empty)
                LoadBatchDetails(String.Empty)
            Case 1
                rbVehicleCode.Checked = True
                dtpSearchBy.Visible = False
                txtVehicleCodeView.Visible = True
                txtVehicleCodeView.Text = String.Empty

                LoadVehicleCode(String.Empty, String.Empty)
        End Select
    End Sub

    Private Sub cmsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDelete.Click
        DeleteVehicleRunningBatch()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to close this screen? If yes please click ""OK"" or click ""Cancel"" ", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

    Private Sub SearchByCodeOrDate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVehicleCode.Click, rbDate.Click
        If rbDate.Checked Then
            dtpSearchBy.Visible = True
            txtVehicleCodeView.Visible = False
            txtVehicleCodeView.Text = String.Empty

            dtpSearchBy.Text = dtpSearchBy.MinDate.ToString

        End If

        If rbVehicleCode.Checked Then
            dtpSearchBy.Visible = False
            txtVehicleCodeView.Visible = True
        End If
    End Sub

    Private Sub cmsDelete_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles cmsDelete.PreviewKeyDown
        If e.KeyCode = 46 Or e.KeyCode = 110 Then
            DeleteVehicleRunningBatch()
        End If
    End Sub

    Private Sub txtVehicleCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave

        If txtVehicleCode.Text.Trim <> String.Empty Then
            If ValidVehicleCode() Then
                FillBatchGridByVehicleCode(txtVehicleCode.Text)
            End If
        Else
            ResetControls("ClearGrid")
            ResetControls(String.Empty)
        End If
    End Sub

    Private Sub txtBatchValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBatchValue.KeyDown

        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            isDecimal = False
                            Return
                        End If

                        isDecimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        isDecimal = reDecimalPlaces.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtBatchValue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBatchValue.KeyPress

        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    '    ResetControls(String.Empty)
    '    ResetControls("Enable")
    '    ResetControls("Date")

    '    tbVehicleRunningBatch.SelectTab(1)

    '    txtVehicleCode.Focus()

    'End Sub

    'Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
    '    txtVehicleCodeView.Text = String.Empty
    '    LoadVehicleCode(String.Empty, String.Empty)
    '    tbVehicleRunningBatch.SelectTab(0)

    '    ResetControls(String.Empty)
    '    ResetControls("Enable")
    '    ResetControls("Date")

    'End Sub

#Region "DataGrids"
    'Fill the grid in the TabPage(Vehicle Running Batch) for the vehicle code send from the grid in the TabPage(View)
    Private Sub dgvVehicleCode_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvVehicleCode.MouseDoubleClick

        'For checking whether it is grid header or cell
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvVehicleCode.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvVehicleCode.CurrentRow.Index >= 0 Then

            FillBatchGridByVehicleCode(dgvVehicleCode.Rows(dgvVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value)

        End If

    End Sub

    Private Sub dgvVehicleCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVehicleCode.KeyDown

        If dgvVehicleCode.CurrentRow.Selected Then
            If e.KeyCode = 13 Then
                e.Handled = True
                FillBatchGridByVehicleCode(dgvVehicleCode.Rows(dgvVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value)
            End If
        End If

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvVehicleCode.DataBindingComplete, dgvVehicleBatchDetails.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    Private Sub dgvVehicleCode_CellValueNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvVehicleCode.CellValueNeeded
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = Me.SNo.Index Then
            e.Value = e.RowIndex + 1
        End If
    End Sub

    Private Sub dgvVehicleBatchDetails_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvVehicleBatchDetails.MouseDoubleClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvVehicleBatchDetails.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvVehicleBatchDetails.CurrentRow.Index >= 0 And dgvVehicleBatchDetails.CurrentCell.ColumnIndex >= 0 Then

            If e.Button = MouseButtons.Left Then
                EditVehicleRunningBatch()
            End If
        End If

    End Sub

    Private Sub dgvVehicleBatchDetails_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvVehicleBatchDetails.MouseClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvVehicleBatchDetails.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvVehicleBatchDetails.CurrentRow.Index >= 0 And dgvVehicleBatchDetails.CurrentCell.ColumnIndex >= 0 Then

            ' Load context menu on right mouse click
            If dgvVehicleBatchDetails.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then

                Dim ldRect As Rectangle
                Dim lpPosCell As Point

                ldRect = dgvVehicleBatchDetails.GetCellDisplayRectangle(dgvVehicleBatchDetails.CurrentCell.ColumnIndex, dgvVehicleBatchDetails.CurrentRow.Index, True)
                lpPosCell = CType(ldRect.Location, Point)
                Me.cmsDelete.Show(dgvVehicleBatchDetails, lpPosCell)
                ' Me.cmsDelete.Show(Me.dgVehicleBatchDetails, dgVehicleBatchDetails.SelectedRows)
                'Me.cmsDelete.Show(Me.dgVehicleBatchDetails, e.Location)

            End If

        End If
    End Sub

    Private Sub dgvVehicleBatchDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVehicleBatchDetails.KeyDown

        If dgvVehicleBatchDetails.CurrentRow.Index >= 0 And dgvVehicleBatchDetails.CurrentCell.ColumnIndex >= 0 And dgvVehicleBatchDetails.CurrentRow.Selected Then

            Select Case e.KeyCode
                Case 13
                    e.Handled = True
                    EditVehicleRunningBatch()

                Case 46 OrElse 110

                    DeleteVehicleRunningBatch()
            End Select

            'If e.KeyCode = 13 Then
            '    e.Handled = True
            '    EditVehicleRunningBatch()
            'End If
        End If

    End Sub

#End Region

#End Region

#Region "Function"

    Private Sub ResetControls(ByVal lsOption As String)

        Select Case lsOption
            Case "Enable"
                dtpDate.Enabled = True
                txtVehicleCode.ReadOnly = True
                ibtnSearchVehicleCode.Enabled = True

            Case "Disable"
                dtpDate.Enabled = False
                txtVehicleCode.ReadOnly = False
                ibtnSearchVehicleCode.Enabled = False

            Case "ClearGrid"
                'Clear the DataGrid
                'For n As Integer = 0 To dgvVehicleBatchDetails.Rows.Count - 1
                '    If dgvVehicleBatchDetails.Rows(0).IsNewRow = False Then
                '        dgvVehicleBatchDetails.Rows.RemoveAt(0)
                '    End If
                'Next

                dsVRB.Tables(0).Clear()

                With dgvVehicleCode
                    .AutoGenerateColumns = False
                    .DataSource = dsVRB.Tables(0)
                End With


            Case "Date"
                dtpDate.Text = dtpDate.MinDate.ToString

                ''Commented For the issue for Steps for validation
            Case Else
                '                btnSaveOrUpdate.Text = "Save"
                btnSaveOrUpdate.Text = "Save"

                txtVehicleCode.Text = String.Empty
                txtBatchValue.Text = String.Empty
                lblHrsOrKms.Text = String.Empty

                If dsVRB IsNot Nothing Then
                    dsVRB.Tables(0).Clear()
                    With dgvVehicleCode
                        .AutoGenerateColumns = False
                        .DataSource = dsVRB.Tables(0)
                    End With
                End If

        End Select

    End Sub

    Function LoadVehicleCode(ByVal lsVehicleCode As String, ByVal lsSender As String) As Boolean

        _VehicleRunningBatchPPT = New VehicleRunningBatchPPT
        _VehicleRunningBatchBOL = New VehicleRunningBatchBOL
        'Global
        _VehicleRunningBatchPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleRunningBatchPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        If rbDate.Checked Then
            _VehicleRunningBatchPPT.psSearchBy = "Date"
            _VehicleRunningBatchPPT.pdVHBatchDT = New Date(dtpSearchBy.Value.Year, dtpSearchBy.Value.Month, dtpSearchBy.Value.Day) 'DateTime.Parse(txtVehicleCodeView.Text.Trim, culture, DateTimeStyles.NoCurrentDateDefault)
        ElseIf rbVehicleCode.Checked And txtVehicleCodeView.Text.Trim <> String.Empty Then
            _VehicleRunningBatchPPT.psSearchBy = "Vehicle Code"
            _VehicleRunningBatchPPT.psVHWSCode = txtVehicleCodeView.Text.Trim
            _VehicleRunningBatchPPT.pdVHBatchDT = CDate("1/1/1753")
        Else
            _VehicleRunningBatchPPT.psSearchBy = String.Empty
            _VehicleRunningBatchPPT.pdVHBatchDT = CDate("1/1/1753")
        End If

        dsVRB = _VehicleRunningBatchBOL.GetVehicleCodeList(_VehicleRunningBatchPPT)

        With dgvVehicleCode
            .AutoGenerateColumns = False
            .DataSource = dsVRB.Tables(0)
        End With

        dgvVehicleCode.ClearSelection()

        If (dsVRB Is Nothing Or dsVRB.Tables(0).Rows.Count = 0) And lsSender <> String.Empty Then

            If rbDate.Checked Then
                MsgBox("Sorry, no data available for the selected date.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                'dtpSearchBy.Text = Date.Now
                dtpSearchBy.Focus()
            ElseIf rbVehicleCode.Checked Then
                If txtVehicleCodeView.Text.Trim <> String.Empty Then
                    MsgBox("Sorry, no such vehicle code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    txtVehicleCodeView.Text = String.Empty
                Else
                    MsgBox("Sorry, no vehicle code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                End If

                txtVehicleCodeView.Focus()
            End If

            'If lsVehicleCode <> String.Empty Then
            '    MsgBox("Vehicle Code Is Not Available", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
            'Else
            '    MsgBox("No records to display", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
            'End If

            Return False
        End If
        Return True
    End Function

    Private Sub LoadBatchDetails(ByVal lsVehicleCode As String)

        _VehicleRunningBatchPPT = New VehicleRunningBatchPPT
        _VehicleRunningBatchBOL = New VehicleRunningBatchBOL
        'Global
        _VehicleRunningBatchPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleRunningBatchPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        dsVRB = _VehicleRunningBatchBOL.GetBatchDetailsVehicleCode(_VehicleRunningBatchPPT)

        With dgvVehicleBatchDetails
            .AutoGenerateColumns = False
            .DataSource = dsVRB.Tables(1)
        End With

        dgvVehicleBatchDetails.ClearSelection()

    End Sub

    'Called when cell click in grid
    'Called From Vehicle Code Text box Leave Event
    'Called From Search Vehicle Form when cell click in grid
    Public Sub FillBatchGridByVehicleCode(ByVal VehicleCode As String)

        ResetControls(String.Empty)
        ResetControls("Date")

        txtVehicleCode.Text = VehicleCode

        _VehicleRunningBatchPPT = New VehicleRunningBatchPPT
        _VehicleRunningBatchBOL = New VehicleRunningBatchBOL

        _VehicleRunningBatchPPT.psVHWSCode = VehicleCode
        'Global
        _VehicleRunningBatchPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleRunningBatchPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        dsVehicleBatchDetails = _VehicleRunningBatchBOL.GetBatchDetailsVehicleCode(_VehicleRunningBatchPPT)

        With dgvVehicleBatchDetails
            .AutoGenerateColumns = False
            .DataSource = dsVehicleBatchDetails.Tables(1)
        End With

        dgvVehicleBatchDetails.ClearSelection()

        'Added when table is empty
        If dsVehicleBatchDetails.Tables(0) IsNot Nothing And dsVehicleBatchDetails.Tables(0).Rows.Count > 0 Then

            'Removed when table is empty
            'Dim _VehicleRunningBatchCollection As VehicleRunningBatchCollection = tempList.Item(0)

            txtVehicleCode.Text = dsVehicleBatchDetails.Tables(0).Rows(0)("VHWSCode")
            Select Case dsVehicleBatchDetails.Tables(0).Rows(0)("UOM")
                Case "H"
                    lblHrsOrKms.Text = "Hrs"
                    txtBatchValue.MaxLength = 5
                Case "K"
                    lblHrsOrKms.Text = "Kms"
                    txtBatchValue.MaxLength = 19
            End Select

        Else
            lblHrsOrKms.Text = String.Empty

        End If

        tcVehicleRunningBatch.SelectTab(0)
    End Sub

    Private Sub EditVehicleRunningBatch()

        'Since after Delete we call the function and we set selection is false in DataBindingComplete
        dgvVehicleBatchDetails.CurrentRow.Selected = True

        _VehicleRunningBatchPPT = New VehicleRunningBatchPPT
        _VehicleRunningBatchBOL = New VehicleRunningBatchBOL

        _VehicleRunningBatchPPT.piID = DirectCast(dgvVehicleBatchDetails.CurrentRow.Cells("ID").Value, Integer)
        _VehicleRunningBatchPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleRunningBatchPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        liID = _VehicleRunningBatchPPT.piID

        dsVehicleBatchDetails = _VehicleRunningBatchBOL.GetVehicleRunningBatchDuringEdit(_VehicleRunningBatchPPT)

        If dsVehicleBatchDetails IsNot Nothing And dsVehicleBatchDetails.Tables(0).Rows.Count > 0 Then
            dtpDate.Text = dsVehicleBatchDetails.Tables(0).Rows(0)("VHBatchDT")
            txtVehicleCode.Text = dsVehicleBatchDetails.Tables(0).Rows(0)("VHWSCode")
            txtBatchValue.Text = Format(Convert.ToDecimal(dsVehicleBatchDetails.Tables(0).Rows(0)("VHBatchValue")), "0,0.0,0").Replace(",", String.Empty)
            lbConcurrencyID = dsVehicleBatchDetails.Tables(0).Rows(0)("ConcurrencyId")
        End If

        ResetControls("Disable")

        btnSaveOrUpdate.Text = "Update"

    End Sub

    Private Sub DeleteVehicleRunningBatch()

        cmsDelete.Visible = False

        If MsgBox("You are about to delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

            Dim ldGetMessage As Integer

            _VehicleRunningBatchPPT = New VehicleRunningBatchPPT
            _VehicleRunningBatchBOL = New VehicleRunningBatchBOL
            _VehicleRunningBatchPPT.piID = DirectCast(dgvVehicleBatchDetails.CurrentRow.Cells("ID").Value, Integer)
            _VehicleRunningBatchPPT.psVHWSCode = dgvVehicleBatchDetails.CurrentRow.Cells("VehicleCode").Value

            'Global
            _VehicleRunningBatchPPT.psEstateID = GlobalPPT.strEstateID
            _VehicleRunningBatchPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

            ldGetMessage = _VehicleRunningBatchBOL.DeleteVehicleRunningBatch(_VehicleRunningBatchPPT)

            General.ShowMessageFromDataBase(ldGetMessage)

            ' cmsDelete.Visible = False

            'i.e. If record not in use
            If ldGetMessage <> 4 Then

                FillBatchGridByVehicleCode(_VehicleRunningBatchPPT.psVHWSCode)

                'Commented for the change that after delete and update show the edit tab like when we comes from the View tab

                ''dgvVehicleBatchDetails.Rows.Remove(dgvVehicleBatchDetails.CurrentRow)

                ''Refill the grid once again after deletion
                'FillBatchGridByVehicleCode(_VehicleRunningBatchPPT.psVHWSCode)
                ''FillBatchGridByVehicleCode(dgvVehicleCode.Rows(dgvVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value)

                'txtBatchValue.Text = String.Empty

                'If dgvVehicleBatchDetails.RowCount > 0 Then
                '    EditVehicleRunningBatch()
                'End If

            End If

            'btnSaveOrUpdate.Text = "Save"

            'tbVehicleRunningBatch.SelectTab(0)

            'ResetControls()
        End If
    End Sub

    Private Function IsColumnExists(ByVal columnName As String, ByVal table As DataTable) As Boolean
        Dim columns As DataColumnCollection = table.Columns

        Select Case columns.Contains(columnName)
            Case True
                Return True
            Case False
                Return False
        End Select
    End Function

    Function CheckRequiredFields() As Boolean
        lsMessage = String.Empty
        _Val = New Validator

        If txtVehicleCode.Text.Trim = String.Empty Then
            'Since Operator Name is required Field and we get it only from VehicleCode

            MsgBox("This field is required.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            txtVehicleCode.Focus()
            Return False
        End If

        If txtBatchValue.Text.Trim = String.Empty Then

            MsgBox("This field is required.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            txtBatchValue.Focus()
            Return False

        End If

        Return True

    End Function

    Private Function CheckIsNumericAndValidTime() As Boolean

        If txtBatchValue.Text <> String.Empty And Not IsNumeric(txtBatchValue.Text) Then
            MsgBox("Please make sure that you have entered a numeric value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            txtBatchValue.Focus()
            Return False

        End If

        Select Case lblHrsOrKms.Text.Trim
            Case "Kms"

                If Not decimalNotEndsWithPeriod.IsMatch(txtBatchValue.Text.Trim) Then
                    MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    txtBatchValue.Focus()
                    Return False
                End If

            Case "Hrs"

                If Not reValidateTime.IsMatch(txtBatchValue.Text.Trim) Then
                    MsgBox("Your batch value has to be in the format of HH.MM [24hrs] (Example: 01.55) and not greater than 23.59.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    txtBatchValue.Focus()
                    Return False
                ElseIf General.GetInTimeFormat(txtBatchValue.Text.Replace(".", ":").Trim) = General.GetInTimeFormat("00:00:00") Then
                    MsgBox("Your time should be greater than a minute.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    txtBatchValue.Focus()
                    Return False
                End If

        End Select

        Return True

    End Function

    Function ValidVehicleCode() As Boolean

        Dim i As Integer = General.IsVHWSCodeExist("V", txtVehicleCode.Text.Trim)

        Select Case i
            Case 0
                MsgBox("Sorry, no such vehicle code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                txtVehicleCode.Focus()
                Return False
                Exit Select
            Case 1
                MsgBox("This vehicle code does not belong to this estate.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                txtVehicleCode.Focus()
                Return False
                Exit Select
            Case 2
                Return True
                Exit Select
        End Select

    End Function

#End Region


End Class