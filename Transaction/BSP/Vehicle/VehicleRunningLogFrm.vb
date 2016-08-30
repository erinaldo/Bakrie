Imports Vehicle_BOL
Imports Vehicle_PPT
Imports Common_PPT
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports Store_PPT
Imports Store_BOL

''Trk 1 Show error msg on save
Public Class VehicleRunningLogFrm

#Region "localVariablesAndClassDeclarations"

    Dim _Val As Validator
    Dim lsMessage As String
    Dim _VehicleRunningLogPPT As VehicleRunningLogPPT
    Dim _VehicleRunningLogBOL As VehicleRunningLogBOL

    ''For storing the Edited OR Deleted ID
    Dim liID As Integer

    ''For having old value of Hrs
    Dim ldOldHrs As TimeSpan
    ''For having old value of Kms
    Dim ldOldKms As Decimal

    Dim ObjVehicleDistributionPPT As VehicleDistributionPPT
    Dim ObjVehicleDistributionBOL As VehicleDistributionBOL
    ''For having the value that is going to be edited
    'Dim ltsOutstandingHrs As TimeSpan

    ''For having the value that is going to be edited
    'Dim ldOutstandingKms As Decimal
    ''Stop and previnting from fring an event on dtpDate on DateChanged
    Private dateIsChangedByUser As Boolean = False

    Dim lbConcurrencyID As Byte() = New Byte(7) {}
    Dim isDecimal, isModifierKey As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,2})?$")
    'To make sure that decimal should not ends with "." while save or update
    Dim decimalNotEndsWithOPeriod As New System.Text.RegularExpressions.Regex("^\d{0,16}(\.\d{0,1})?[^\.]$")
    'Dim reValidateTime As New System.Text.RegularExpressions.Regex("^(0[1-9]|1[0-2])(:[0-5]\d){1,2}\s{0}[ap][m]$")
    Dim reValidateTime As New System.Text.RegularExpressions.Regex("^(0[1-9]|1[0-2])(:[0-5]\d){1,2}\s{0}[ap/AP][m/M]$")
    Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)


    Dim psSIVBlockID As String = String.Empty
    Dim psSIVDivID As String = String.Empty
    Dim psSIVYopID As String = String.Empty

    Public Shared VehicleVHWSCode As String
    Public Shared VehicleType As String

    Private Shared lbDateHarvested As Boolean
    Private Shared lbDateCollected As Boolean

    Private Shared lsStartTime As String
    Private Shared lsEndTime As String

    Private lsVHID As String = String.Empty

    Private Shared EditTotalHrs As String
    Private Shared EditTotalKms As String

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

#End Region

#Region "Events"

    ''Windows Form Designer generated code

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.

        'Me.dgVehicleBatchDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        'The above line is added to make column header wrapt to be false.
        InitializeComponent()

    End Sub

    Private Sub VehicleRunningLogFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ddlLocation.DataSource = GlobalPPT.str

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture
        Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("en-US")

        lblBatchValue.Visible = False
        txtBatchValue.Visible = False
        Label2.Visible = False
        btnLookUpDIV.Visible = False

        Dim mdiparent As New MDIParent
        If mdiparent.strMenuID = "M69" Then

            'Setting Default date for the DateTimePicker

            SetUICulture(GlobalPPT.strLang)

            'dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
            'dtpDate.MaxDate = GlobalPPT.FiscalYearToDate

            'dtpSearchBy.MinDate = GlobalPPT.FiscalYearFromDate
            'dtpSearchBy.MaxDate = GlobalPPT.FiscalYearToDate

            'dtpDateHarvested.MinDate = GlobalPPT.FiscalYearFromDate
            'dtpDateHarvested.MaxDate = GlobalPPT.FiscalYearToDate

            'dtpDateCollected.MinDate = GlobalPPT.FiscalYearFromDate
            'dtpDateCollected.MaxDate = GlobalPPT.FiscalYearToDate

            'If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
            '    dtpDate.Value = Now
            '    dtpSearchBy.Value = Now
            'End If

            'dtpDateHarvested.Value = vbNullChar
            'dtpDateCollected.Value = vbNullChar

            ' ResetDTPicker()

            ResetControls("Date")

            'lbDateHarvested = False
            'lbDateCollected = False

            FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)

            GetLocation()

            dgvListOfVehicleLog.Columns("LogDate").DefaultCellStyle.Format = "dd/MM/yyyy"
            dgVehicleCode.Columns("dgvLogDate").DefaultCellStyle.Format = "dd/MM/yyyy"
            'dgvListOfVehicleLog.Columns("StartTime").DefaultCellStyle.Format = "h:mm tt"
            'dgvListOfVehicleLog.Columns("EndTime").DefaultCellStyle.Format = "t"

            tbVehicleRunningLog.SelectedIndex = 1

            'ElseIf mdiparent.strMenuID = "M72" Then
            'tbVehicleRunningLog.SelectedTab = tbpgAdd
            'tbVehicleRunningLog.TabPages.Remove(tpViewVRL)

            chkDate.Focus()

        End If
        If dgvListOfVehicleLog.Rows.Count = 0 Then
            btnActivity.Enabled = False
        Else
            btnActivity.Enabled = True
        End If
    End Sub

    'Private Sub ResetDTPicker()
    '    ResetDateHarvestedDTP()
    '    ResetDateCollectedDTP()
    'End Sub

    'Private Sub ResetDateHarvestedDTP()
    '    With dtpDateHarvested

    '        .Format = DateTimePickerFormat.Custom
    '        .CustomFormat = "X"

    '    End With

    '    ' lbDateHarvested = True

    'End Sub

    'Private Sub ResetDateCollectedDTP()

    '    With dtpDateCollected

    '        .Format = DateTimePickerFormat.Custom
    '        .CustomFormat = "X"

    '    End With

    'End Sub

    Private Sub tbVehicleRunningLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVehicleRunningLog.SelectedIndexChanged
        
        Select Case tbVehicleRunningLog.SelectedIndex
            Case 0
                
                ResetControls("EnableAllControls")
                ResetControls("EnableControls")
                ResetControls("VehicleCode")
                ResetControls("Default")
                ResetControls("Mandatary")
                ResetControls("VehicleRunningData")
                ResetControls("BunchesData")
                ResetControls("ClearGrid")
                ResetControls("Date")
                ResetControls("FFBdeliverytoMill")

                FillVehicleRunningLog(String.Empty)
                dtpDate.Focus()
                If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If
            Case 1
                If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                    MsgBox(PrivilegeError)
                End If
                chkDate.Checked = False
                dtpSearchBy.Enabled = False
                txtVehicleCodeView.Text = String.Empty

                'Called here because if any new vehicle code date in added in vehicle running log
                FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)
                chkDate.Focus()
        End Select

    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        If chkDate.Checked Then
            dtpSearchBy.Enabled = True
            '            dtpSearchBy.Text = dtpSearchBy.MinDate.ToString
        Else
            dtpSearchBy.Enabled = False
            dtpSearchBy.Value = GlobalPPT.FiscalYearFromDate
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If (Not chkDate.Checked) And txtVehicleCodeView.Text.Trim = String.Empty Then 'Show this message when Vehicle code textbox is empty and chkDate is not checked
            'MsgBox("Please enter search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("MsgSearch")
            txtVehicleCodeView.Focus()
            '    Return
            FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)
        Else
            FillVehicleCodeFromVehicleRunningLog(txtVehicleCodeView.Text.Trim, "btnSearch")
        End If

        'Fill the grid only with the filter value


    End Sub

    Private Sub dgVehicleCode_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVehicleCode.MouseClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgVehicleCode.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgVehicleCode.RowCount > 0 Then
            ' Load context menu on right mouse click
            If dgVehicleCode.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then

                Dim ldRect As Rectangle
                Dim lpPosCell As Point

                ldRect = dgVehicleCode.GetCellDisplayRectangle(dgVehicleCode.CurrentCell.ColumnIndex, dgVehicleCode.CurrentRow.Index, True)
                lpPosCell = CType(ldRect.Location, Point)
                Me.cmsView.Show(dgVehicleCode, lpPosCell)

                ' Me.cmsDelete.Show(Me.dgListOfVehicleLog, e.Location)

            End If
        End If
    End Sub

    Private Sub dgVehicleCode_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVehicleCode.MouseDoubleClick
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgVehicleCode.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If


        ResetControls("Date")

        'lbDateHarvested = False
        'lbDateCollected = False

        If dgVehicleCode.CurrentRow.Index >= 0 And dgVehicleCode.CurrentCell.ColumnIndex >= 0 Then
            LoadVehicleRunningLogDataFromView(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value, CDate(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("dgvLogDate").Value))
            OperationalRequiredLabelColor()
        End If

        If Convert.ToString(dgVehicleCode.CurrentRow.Cells("ViewPosted").Value).Equals("Y") Then

            'btnSaveOrUpdate.Text = "Update"

            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Memperbarui"
            End If

            ResetControls("DisableAllControls")
            ResetControls("DisableControls")

            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")

            Return
        Else

            'btnSaveOrUpdate.Text = "Save"
            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Save"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Simpan"
            End If





            ResetControls("EnableAllControls")
            ResetControls("EnableControls")

        End If
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        If dgvListOfVehicleLog.Rows.Count = 0 Then
            btnActivity.Enabled = False
        Else
            btnActivity.Enabled = True
        End If
    End Sub

    'Private Sub dgVehicleCode_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgVehicleCode.CellValueNeeded
    '    If e.RowIndex >= 0 AndAlso e.ColumnIndex = Me.Sno.Index Then
    '        e.Value = e.RowIndex + 1
    '    End If
    'End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgVehicleCode.DataBindingComplete, dgvListOfVehicleLog.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

    Private Sub dgVehicleCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVehicleCode.KeyDown

        If dgVehicleCode.RowCount = 0 Then
            Return
        End If

        If dgVehicleCode.CurrentRow.Index >= 0 And dgVehicleCode.CurrentCell.ColumnIndex >= 0 Then
            If dgVehicleCode.CurrentRow.Selected Then
                If e.KeyCode = 13 Then
                    e.Handled = True
                    'LoadVehicleRunningLogDataFromView()
                    If dgVehicleCode.CurrentRow.Index >= 0 And dgVehicleCode.CurrentCell.ColumnIndex >= 0 Then
                        'LoadVehicleRunningLogDataFromView(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value, CDate(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("dgvLogDate").Value))
                        LoadVehicleRunningLogDataFromView(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value, CDate(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("dgvLogDate").Value))
                        OperationalRequiredLabelColor()
                    End If

                    If Convert.ToString(dgVehicleCode.CurrentRow.Cells("ViewPosted").Value).Equals("Y") Then

                        'btnSaveOrUpdate.Text = "Update"


                        If GlobalPPT.strLang = "en" Then
                            btnSaveOrUpdate.Text = "Update"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveOrUpdate.Text = "Memperbarui"
                        End If

                        ResetControls("DisableAllControls")
                        ResetControls("DisableControls")

                        'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
                        DisplayInfoMessage("MsgPosted")

                        Return
                    Else

                        'btnSaveOrUpdate.Text = "Save"

                        If GlobalPPT.strLang = "en" Then
                            btnSaveOrUpdate.Text = "Save "
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveOrUpdate.Text = "Simpan"
                        End If
                        ResetControls("EnableAllControls")
                        ResetControls("EnableControls")

                    End If


                End If
            End If
        End If

    End Sub

    Private Sub dgVehicleCode_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgVehicleCode.CellFormatting

        If e.ColumnIndex = dgVehicleCode.Columns("ViewPosted").Index Then
            e.FormattingApplied = True
            Dim row As DataGridViewRow = dgVehicleCode.Rows(e.RowIndex)
            Select Case (e.Value.ToString().Trim())
                Case "Y"
                    e.Value = "Yes"
                Case "N"
                    e.Value = "No"
            End Select

        End If

    End Sub

    Private Sub tsmiViewDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiViewDelete.Click
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        cmsView.Visible = False

        If Convert.ToString(dgVehicleCode.CurrentRow.Cells("ViewPosted").Value).Equals("Y") Then
            'MsgBox("Cannot delete this record as it has been already Approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")
            Return
        Else
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogFrm))

            If MsgBox(rm.GetString("DeleteMorePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("This operation might delete more than one record for the selected date and vehicle code. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim ldGetMessage As Integer
                _VehicleRunningLogPPT = New VehicleRunningLogPPT
                _VehicleRunningLogBOL = New VehicleRunningLogBOL

                _VehicleRunningLogPPT.pdLogDate = DirectCast(dgVehicleCode.CurrentRow.Cells("dgvLogDate").Value, Date)
                _VehicleRunningLogPPT.psVHWSCode = dgVehicleCode.CurrentRow.Cells("VHWSCode").Value

                'Global
                '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
                '_VehicleRunningLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

                ldGetMessage = _VehicleRunningLogBOL.DeleteVehicleRunningLogFromView(_VehicleRunningLogPPT)

                'General.ShowMessageFromDataBase(ldGetMessage)

                If ldGetMessage = 3 Then
                    General.ShowMessageFromDataBase(14)
                Else
                    General.ShowMessageFromDataBase(ldGetMessage)
                End If

                'i.e. If record not in use
                If ldGetMessage <> 4 Then

                    ResetControls("Date")

                    FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)

                    chkDate.Focus()

                End If

            End If
        End If
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub tsmiViewAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiViewAdd.Click
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        'lbDateHarvested = False
        'lbDateCollected = False

        LoadVehicleRunningLogDataFromView(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value, CDate(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("dgvLogDate").Value))

        If Convert.ToString(dgVehicleCode.CurrentRow.Cells("ViewPosted").Value).Equals("Y") Then
            ResetControls("DisableAllControls")
            ResetControls("DisableControls")

            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")

            Return
        Else

            'btnSaveOrUpdate.Text = "Save"
            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Save"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Simpan"
            End If
            ResetControls("EnableAllControls")
            ResetControls("EnableControls")

        End If

    End Sub

    'Private Sub ResetDTPicker()
    '    chkDateCollected.Checked = False
    '    chkDateHarvested.Checked = False
    'End Sub

    Private Sub tsmiViewEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiViewEdit.Click
       

        ResetControls("Date")

        'lbDateHarvested = False
        'lbDateCollected = False

        If dgVehicleCode.CurrentRow.Index >= 0 And dgVehicleCode.CurrentCell.ColumnIndex >= 0 Then
            LoadVehicleRunningLogDataFromView(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value, CDate(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("dgvLogDate").Value))
            OperationalRequiredLabelColor()
        End If


        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        'Fill the grid according to the date and the vehicle code

        LoadVehicleRunningLogDataFromView(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value, CDate(dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("dgvLogDate").Value))

        '' ResetControls("DisableAllControls")
        'ResetControls("DisableControls")
        'ResetControls("VehicleCode")
        'ResetControls("Default")
        'ResetDTPicker()
        ''lbDateHarvested = False
        ''lbDateCollected = False
        'ResetControls("Mandatary")
        'ResetControls("VehicleRunningData")
        'ResetControls("BunchesData")

        If Convert.ToString(dgVehicleCode.CurrentRow.Cells("ViewPosted").Value).Equals("Y") Then

            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Memperbarui"
            End If

            ResetControls("DisableAllControls")
            ResetControls("DisableControls")

            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")

            Return
        Else

            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Save"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Simpan"
            End If
            ResetControls("EnableAllControls")
            ResetControls("EnableControls")
            'dgvListOfVehicleLog.Enabled = True

            'liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
            'EditListOfVehicle(liID)
        End If

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub btnSaveOrUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveOrUpdate.Click

        'If txtVehicleCode.Text.Trim = String.Empty Then
        '    MsgBox("Please give Vehicle Code", MsgBoxStyle.OkOnly, "Information")
        '    Return
        'End If

        'If txtVehicleCode.Text.Trim <> String.Empty Then
        '    If Not ValidMandatoryFileds() Then
        '        Return
        '    End If
        'End If

        If txtVehicleCode.Text.Trim <> String.Empty Then
            If IsVHCodePosted() Then
                MsgBox("Cannot add a record for [" + txtVehicleCode.Text.Trim + "] on [ " + dtpDate.Text + "]. As this vehicle running transaction already approved for the day", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
                txtVehicleCode.Focus()
                Return
            End If
        End If

        If Not CheckRequiredFields() Then
            Return
        End If


        If Not ChkDistributionForVH(txtVehicleCode.Text.Trim, New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)) Then
            Return
        End If



        If rbOperational.Checked Then
            If Not CheckRequiredOperationalsFields() Then
                Return
            End If
        End If

        ''Since we are not clearing on leave event we need to have once again
        ''Trk 1
        If Not ValidDataType() Then
            Return
        End If

        ''Trk 1
        If Not ValidDataTypeSize() Then
            Return
        End If

        ''Trk 1
        If Not IsBothHrsAndKrsAreEqual() Then
            Return
        End If

        'If Not ValidatePrimaryKeyFields() Then
        '    Return
        'End If

        If Not IsFieldsRequiredWhenItsPairIsNotEmpty() Then
            Return
        End If

        'If Not IsFieldsValueGreateThanItsPair() Then
        '    Return
        'End If

        'Checking Hrs or Kms greater than batch value
        'Since batchvalue is removed we had commented it
        'If Not IsFieldsValid() Then
        '    Return
        'End If

        'Since batchvalue is removed we had commented it
        'If Not IsBathcValieRequired() Then
        '    Return
        'End If

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        'Global
        '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
        '_VehicleRunningLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
        If GlobalPPT.strLang = "en" Then
            Select Case (btnSaveOrUpdate.Text)

                Case "Save"
                    If Not AssignControlsValuesToPropertiesAndSave(_VehicleRunningLogPPT) Then
                        Return
                    End If
                    If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If
                Case "Update"

                    If Not AssignControlValuesToPropertiesForUpdate(_VehicleRunningLogPPT) Then
                        Return
                    End If
                    If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If
            End Select
        ElseIf GlobalPPT.strLang = "ms" Then
            Select Case (btnSaveOrUpdate.Text)

                Case "Simpan"
                    If Not AssignControlsValuesToPropertiesAndSave(_VehicleRunningLogPPT) Then
                        Return
                    End If
                    If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If
                Case "Memperbarui"

                    If Not AssignControlValuesToPropertiesForUpdate(_VehicleRunningLogPPT) Then
                        Return
                    End If
                    If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
                        MsgBox(PrivilegeError)
                    End If
            End Select
        End If

        'For filling the Viewgrid
        tbVehicleRunningLog.SelectedIndex = 0

        If dgvListOfVehicleLog.Rows.Count = 0 Then
            btnActivity.Enabled = False
        Else
            btnActivity.Enabled = True
        End If
        'FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)

        'FillVehicleRunningLog(_VehicleRunningLogPPT.psVHWSCode)
        'If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If.
    End Sub

    Public Function ChkDistributionForVH(ByVal lsVehicleCode As String, ByVal ldDistributedDateDT As DateTime) As Boolean

        ObjVehicleDistributionPPT = New VehicleDistributionPPT()
        ObjVehicleDistributionBOL = New VehicleDistributionBOL

        ObjVehicleDistributionPPT.psVHID = lsVehicleCode
        ObjVehicleDistributionPPT.pdDistributionDT = ldDistributedDateDT

        Dim ObjVehicleDistributionCollectionList As New DataSet ''List(Of VehicleDistributionCollection)

        ObjVehicleDistributionCollectionList = ObjVehicleDistributionBOL.GetDistributionValueForVehicleCode(ObjVehicleDistributionPPT)

        Dim ObjVehicleDistributionCollection1 As New DataTable
        ObjVehicleDistributionCollection1 = ObjVehicleDistributionCollectionList.Tables(0)
        If ObjVehicleDistributionCollection1.Rows.Count > 0 Then


            Dim ldCurrentBalanceToDistributeKms, ldCurrentKms As Decimal
            Dim ldCurrentBalanceToDistributeHrs, ldCurrentHrs As Decimal

            'Dim strTotalKms As String = txtTotalKms.Text.Trim
            'Dim strTotalHrs As String = txtTotalHours.Text.Trim
            Select Case (txtUOM.Text.Trim)
                Case "Hrs"
                    If txtTotalHours.Text.Trim <> String.Empty Then
                        If EditTotalHrs = String.Empty Then
                            EditTotalHrs = "00:00"
                        End If
                        ' ldCurrentBalanceToDistributeHrs = (GetInTimeValue(GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalHrs").Replace(":", "."))) - GetInTimeValue(GetDataValue(EditTotalHrs).Replace(":", "."))) + GetInTimeValue(GetDataValue(txtTotalHours.Text.Trim).Replace(":", "."))
                        Dim diffSec, diffsec1, diffsec2 As New Integer
                        diffSec = (((Convert.ToDecimal(StringToSec(ObjVehicleDistributionCollection1.Rows(0)("TotalHrs").Replace(":", "."))) - (Convert.ToDecimal(StringToSec(EditTotalHrs).Replace(":", "."))))) + (Convert.ToDecimal(StringToSec(txtTotalHours.Text.Trim.Replace(":", ".")))))
                        ldCurrentBalanceToDistributeHrs = diffSec
                        'Dim ldBalanceToDistributestr As String
                        'ldBalanceToDistributestr = SecToTime(diffSec)
                        '  ldCurrentBalanceToDistributeHrs = Convert.ToDecimal(ldBalanceToDistributestr.Replace(":", "."))

                        diffsec1 = Convert.ToDecimal(StringToSec(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedHrs")))
                        ldCurrentHrs = diffsec1

                        'Dim ldCurrentHrsd As String = GetDataValue(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedHrs"))
                        'ldCurrentHrs = GetInTimeValue(GetDataValue(ldCurrentHrsd))

                        If ldCurrentBalanceToDistributeHrs < ldCurrentHrs Then
                            MsgBox("Total Hrs Cannot be less than Distributed Hrs", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
                            Return False
                        End If
                    End If
                    Return True
                Case "Kms"
                    If txtTotalKms.Text <> String.Empty Then

                        Dim ldTotalKms, ldTotalKmsDistributed, ldEditKms As Decimal
                        If ObjVehicleDistributionCollection1.Rows(0)("TotalKms").ToString <> String.Empty Then
                            ldTotalKms = Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKms"))
                        Else
                            ldTotalKms = 0
                        End If
                        If ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms").ToString <> String.Empty Then
                            ldTotalKmsDistributed = Convert.ToDecimal(ObjVehicleDistributionCollection1.Rows(0)("TotalKmHoursDistributedKms"))
                        Else
                            ldTotalKmsDistributed = 0
                        End If
                        If EditTotalKms <> String.Empty Then
                            ldEditKms = Convert.ToDecimal(EditTotalKms)
                        Else
                            ldEditKms = 0
                        End If

                        ldCurrentKms = Convert.ToDecimal(txtTotalKms.Text.Trim)
                        ldCurrentBalanceToDistributeKms = (ldTotalKms - ldEditKms) + ldCurrentKms
                        If ldCurrentBalanceToDistributeKms < ldTotalKmsDistributed Then
                            MsgBox("Total Kms Cannot be less than Distributed Kms", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
                            Return False

                        End If

                    End If
                    EditTotalHrs = String.Empty
                    EditTotalKms = String.Empty
                    Return True
            End Select
        Else
            Return True
        End If
        Return True
    End Function
    Public Shared Function FormatTimeSpan(ByVal span As TimeSpan) As String
        Return String.Format("{0} {1} {2}", _
                             CInt(Math.Truncate(span.TotalHours)), _
                             span.Minutes, span.Seconds)
    End Function
    Public Shared Function StringToSec(ByVal strValue As String) As String
        If strValue = "0" Then
            strValue = "0:0"
        End If
        Dim sec As Integer = 0
        If strValue.Contains(".") Then
            Dim strArray() As String = strValue.Split(".")
            sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds
        ElseIf strValue.Contains(":") Then
            Dim strArray() As String = strValue.Split(":")
            sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds
        End If
        Return sec
    End Function
    Public Shared Function SecToTime(ByVal strdiff As String) As String
        Dim strTimeH, strTimeM As String
        Dim strTotal As String
        Dim t1 As TimeSpan = TimeSpan.FromSeconds(strdiff)
        strTimeH = CInt(Math.Truncate(t1.TotalHours))
        strTimeM = t1.Minutes


        If strTimeH.Length = 1 Then
            strTimeH = "0" + strTimeH
        End If
        If strTimeM.Length = 1 Then
            strTimeM = "0" + strTimeM
        End If
        strTotal = strTimeH + ":" + strTimeM
        ' strTotal = t1.ToString
        ' strTotal = strTotal.Substring(0, strTotal.LastIndexOf(":"))

        Return strTotal
    End Function
    Function GetInTimeValue(ByVal lsFormValue As String) As TimeSpan
        Dim ldHrsDT As DateTime = DateTime.ParseExact(Format(Convert.ToDecimal(lsFormValue), "0,0.0,0"), "HH.mm", Nothing) '+ DateTime.ParseExact(Format(Convert.ToDecimal(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem), "0,0.0,0"), "HH.mm", Nothing)
        Dim ldHrsValueDT As TimeSpan = New TimeSpan(ldHrsDT.Hour, ldHrsDT.Minute, ldHrsDT.Second)
        Return ldHrsValueDT
    End Function
    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    'ResetControls("VehicleCode")
    '    ResetControls("Date")
    '    ResetControls("EnableControls")
    '    ResetControls("Default")
    '    ResetControls("VehicleCode")
    '    ResetControls("Mandatary")
    '    ResetControls("VehicleRunningData")
    '    ResetControls("BunchesData")
    '    ResetControls("ClearGrid")

    '    OperationalRequiredLabelColor()

    '    tbVehicleRunningLog.SelectTab(1)
    'End Sub

    'Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
    '    'ResetControls("VehicleCode")
    '    ResetControls("Date")
    '    ResetControls("EnableControls")
    '    ResetControls("Default")
    '    ResetControls("VehicleCode")
    '    ResetControls("Mandatary")
    '    ResetControls("VehicleRunningData")
    '    ResetControls("BunchesData")
    '    ResetControls("ClearGrid")
    '    tbVehicleRunningLog.SelectTab(0)
    '    'Called here because if any new vehicle code date in added in vehicle running log
    '    FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)
    'End Sub

    Private Sub rbOperational_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOperational.CheckedChanged

        If rbOperational.Checked Then
            lblVehicleActivity.ForeColor = Color.Red

        Else
            lblVehicleActivity.ForeColor = Color.Black
        End If

        If txtUOM.Text.Trim = "Hrs" Then
            txtStartKms.Enabled = False
            txtEndKms.Enabled = False
            txtTotalKms.Enabled = False
        ElseIf txtUOM.Text.Trim = "Kms" Then

            txtStartKms.Enabled = True
            txtEndKms.Enabled = True
            txtTotalKms.Enabled = True

            lblStartKms.ForeColor = Color.Red
            lblEndKms.ForeColor = Color.Red
        Else
            txtStartKms.Enabled = True
            txtEndKms.Enabled = True
            txtTotalKms.Enabled = True
            'txtStartTime.Enabled = True
            'cmbStartHrs.SelectedIndex = 0
            'cmbStartMin.SelectedIndex = 0
            'cmbStartHrs.Enabled = True
            'cmbStartMin.Enabled = True
            ''txtEndTime.Enabled = True

            'cmbEndHrs.SelectedIndex = -1
            'cmbEndMin.SelectedIndex = -1
            'cmbEndHrs.Enabled = True
            'cmbEndMin.Enabled = True


            txtStartHr.Text = String.Empty
            txtStartMin.Text = String.Empty
            txtEndHr.Text = String.Empty
            txtEndMin.Text = String.Empty

            txtStartHr.Enabled = True
            txtStartMin.Enabled = True
            txtEndHr.Enabled = True
            txtEndMin.Enabled = True


            txtTotalHours.Enabled = True

            lblStartTime.ForeColor = Color.Black
            lblEndTime.ForeColor = Color.Black
            lblStartKms.ForeColor = Color.Black
            lblEndKms.ForeColor = Color.Black
        End If

        If btnSaveOrUpdate.Text = "Update" Then

        End If

        OperationalRequiredLabelColor()

        '  gbBunchesData.Enabled = False

        Select Case txtUOM.Text.Trim
            Case "Hrs"
                'RestColor According to UOM
                lblStartTime.ForeColor = Color.Black
                lblEndTime.ForeColor = Color.Black
                lblTotalHours.ForeColor = Color.Red

                lblStartKms.ForeColor = Color.Black
                lblEndKms.ForeColor = Color.Black
                Exit Select
            Case "Kms"

                'RestColor According to UOM
                lblStartKms.ForeColor = Color.Red
                lblEndKms.ForeColor = Color.Red

                lblStartTime.ForeColor = Color.Black
                lblEndTime.ForeColor = Color.Black
              
                Exit Select

        End Select

    End Sub

    Private Sub rbBreakDown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBreakDown.CheckedChanged

        If rbBreakDown.Checked Then

            'Clear the data in the group box
            ResetControls("VehicleRunningData")
            ResetControls("BunchesData")

            'dtpDateHarvested.Text = dtpDateHarvested.MinDate.ToString
            'dtpDateCollected.Text = dtpDateCollected.MinDate.ToString

            gbVehicleRunningData.Enabled = False
            ' gbBunchesData.Enabled = False
        Else
            gbVehicleRunningData.Enabled = True
            ' gbBunchesData.Enabled = True
        End If

        OperationalRequiredLabelColor()

    End Sub

    Private Sub rbStandBy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbStandBy.CheckedChanged

       
        If rbStandBy.Checked Then

            txtStartKms.Enabled = False
            txtEndKms.Enabled = False
            txtTotalKms.Enabled = False

            'cmbStartHrs.SelectedIndex = 0
            'cmbStartMin.SelectedIndex = 0
            'cmbEndHrs.SelectedIndex = 0
            'cmbEndMin.SelectedIndex = 0
            '

            txtStartHr.Enabled = True
            txtStartMin.Enabled = True
            txtEndHr.Enabled = True
            txtEndMin.Enabled = True

            'txtStartTime.Enabled = True
            'cmbStartHrs.Enabled = True
            'cmbStartMin.Enabled = True
            ''txtEndTime.Enabled = True
            'cmbEndHrs.Enabled = True
            'cmbEndMin.Enabled = True
            txtTotalHours.Enabled = True
            txtShift.Enabled = True

            txtDIV.Enabled = False
            btnLookUpDIV.Enabled = False
            txtYOP.Enabled = False

            'btnLookUpYOP.Enabled = False
            txtSubBlock.Enabled = False
            btnLookUpSubBlock.Enabled = False
            txtVehicleActivity.Enabled = False

            txtStartKms.Text = String.Empty
            txtEndKms.Text = String.Empty
            txtTotalKms.Text = String.Empty

            txtDIV.Text = String.Empty
            txtYOP.Text = String.Empty
            txtSubBlock.Text = String.Empty
            txtVehicleActivity.Text = String.Empty

            'gbBunchesData.Enabled = False
            'txtFFBDeliveryOrderNo.Text = String.Empty
            'txtBunches.Text = String.Empty
            'txtActualBunchesMill.Text = String.Empty
            'txtCollectionPoint.Text = String.Empty
            'txtMillWeight.Text = String.Empty
            'dtpDateHarvested.Text = dtpDateHarvested.MinDate.ToString
            'dtpDateCollected.Text = dtpDateCollected.MinDate.ToString
            'txtDoubleHandledFFB.Text = String.Empty
            'txtWeightedBy.Text = String.Empty
            'txtDispatchedBy.Text = String.Empty

            lblStartKms.Enabled = False
            lblEndKms.Enabled = False
            lblTotalKms.Enabled = False

            lblDIV.Enabled = False
            lblYOP.Enabled = False
            lblSubBlock.Enabled = False
            lblVehicleActivity.Enabled = False

            'If txtUOM.Text.Trim = "Kms" Then
            '    lblStartKms.ForeColor = Color.Black
            '    lblEndKms.ForeColor = Color.Black
            'End If

        Else

            txtStartKms.Enabled = True
            txtEndKms.Enabled = True
            txtTotalKms.Enabled = True

            txtDIV.Enabled = True
            btnLookUpDIV.Enabled = True
            txtYOP.Enabled = True
            'btnLookUpYOP.Enabled = True
            txtSubBlock.Enabled = True
            btnLookUpSubBlock.Enabled = True
            txtVehicleActivity.Enabled = True

            lblStartKms.Enabled = True
            lblEndKms.Enabled = True
            lblTotalKms.Enabled = True
            lblDIV.Enabled = True
            lblYOP.Enabled = True
            lblSubBlock.Enabled = True
            lblVehicleActivity.Enabled = True

            '  gbBunchesData.Enabled = True

            'lblStartKms.ForeColor = Color.Red
            'lblEndKms.ForeColor = Color.Red
            'lblStartTime.ForeColor = Color.Black
            'lblEndTime.ForeColor = Color.Black
        End If



        OperationalRequiredLabelColor()

        Select Case txtUOM.Text.Trim
            Case "Hrs"
                'RestColor According to UOM
                lblStartTime.ForeColor = Color.Black
                lblEndTime.ForeColor = Color.Black
                lblTotalHours.ForeColor = Color.Red

                lblStartKms.ForeColor = Color.Black
                lblEndKms.ForeColor = Color.Black
                Exit Select
            Case "Kms"

                'RestColor According to UOM
                lblStartKms.ForeColor = Color.Red
                lblEndKms.ForeColor = Color.Red

                lblStartTime.ForeColor = Color.Black
                lblEndTime.ForeColor = Color.Black

                Exit Select

        End Select
        If rbStandBy.Checked Then
            lblStartTime.ForeColor = Color.Black
            lblEndTime.ForeColor = Color.Black
            lblTotalHours.ForeColor = Color.Red
        End If
        'Select Case txtUOM.Text.Trim
        '    Case "Hrs"
        '        'RestColor According to UOM
        '        lblStartTime.ForeColor = Color.Red
        '        lblEndTime.ForeColor = Color.Red

        '        'lblStartKms.ForeColor = Color.Black
        '        'lblEndKms.ForeColor = Color.Black


        '        Exit Select
        '    Case "Kms"

        '        'RestColor According to UOM
        '        'lblStartKms.ForeColor = Color.Red
        '        'lblEndKms.ForeColor = Color.Red

        '        lblStartTime.ForeColor = Color.Red
        '        lblEndTime.ForeColor = Color.Red

        '        Exit Select

        'End Select

    End Sub

    Private Sub rbFFBdeliverytoMill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFFBdeliverytoMill.CheckedChanged
        ResetControls("FFBdeliverytoMill")
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        ResetControls("EnableAllControls")
        ResetControls("EnableControls")
        ResetControls("Date")
        ResetControls("VehicleCode")
        ResetControls("Default")
        ResetControls("Mandatary")
        ResetControls("VehicleRunningData")
        ResetControls("BunchesData")
        ResetControls("ClearGrid")

        'ResetControls("FFBdeliverytoMill")

        OperationalRequiredLabelColor()
        EditTotalHrs = String.Empty
        EditTotalKms = String.Empty
        dtpDate.Focus()


        If dgvListOfVehicleLog.Rows.Count = 0 Then
            btnActivity.Enabled = False
        Else
            btnActivity.Enabled = True
        End If

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub dgvListOfVehicleLog_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvListOfVehicleLog.MouseClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvListOfVehicleLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvListOfVehicleLog.RowCount > 0 Then
            ' Load context menu on right mouse click
            If dgvListOfVehicleLog.CurrentRow.Selected = True And e.Button = MouseButtons.Right Then

                Dim ldRect As Rectangle
                Dim lpPosCell As Point

                ldRect = dgvListOfVehicleLog.GetCellDisplayRectangle(dgvListOfVehicleLog.CurrentCell.ColumnIndex, dgvListOfVehicleLog.CurrentRow.Index, True)
                lpPosCell = CType(ldRect.Location, Point)
                Me.cmsDelete.Show(dgvListOfVehicleLog, lpPosCell)

                ' Me.cmsDelete.Show(Me.dgListOfVehicleLog, e.Location)

            End If
        End If

    End Sub

    Private Sub dgvListOfVehicleLog_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvListOfVehicleLog.MouseDoubleClick

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvListOfVehicleLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvListOfVehicleLog.CurrentRow.Index >= 0 And dgvListOfVehicleLog.CurrentCell.ColumnIndex >= 0 Then
            If e.Button = MouseButtons.Left Then


                'Fill the grid according to the date and the vehicle code
                'LoadVehicleRunningLogDataFromView(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("VehicleCode").Value, CDate(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("LogDate").Value))

                liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)

                'ResetControls("DisableAllControls")
                Me.GetBatchValueByVehicleCode(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("VehicleCode").Value, String.Empty, CDate(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("LogDate").Value))

                If pnlEntryArea.Enabled = False Then

                    EditListOfVehicle(liID)

                    Return

                End If

                'ResetControls("DisableControls")
                'ResetControls("VehicleCode")
                'ResetControls("Default")
                'ResetControls("Mandatary")
                'ResetControls("VehicleRunningData")
                'ResetControls("BunchesData")
                'ResetDTPicker()

                'btnSaveOrUpdate.Text = "Update"


                If Convert.ToString(dgvListOfVehicleLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

                    btnSaveOrUpdate.Enabled = False

                    'liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
                    EditListOfVehicle(liID)
                    ResetControls("DisableAllControls")
                    'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
                    ' gbBunchesData.Enabled = False
                    DisplayInfoMessage("MsgPosted")
                    Return
                Else

                    ResetControls("DisableControls")
                    ResetControls("VehicleCode")
                    'ResetControls("Default")
                    ResetControls("Mandatary")
                    ResetControls("VehicleRunningData")
                    ResetControls("BunchesData")
                    'ResetDTPicker()

                    'btnSaveOrUpdate.Text = "Update"

                    If GlobalPPT.strLang = "en" Then
                        btnSaveOrUpdate.Text = "Update"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveOrUpdate.Text = "Memperbarui"
                    End If

                    btnSaveOrUpdate.Enabled = True
                    dgvListOfVehicleLog.Enabled = True

                    'liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
                    EditListOfVehicle(liID)
                End If

                'lbDateHarvested = False
                'lbDateCollected = False

                

            End If
        End If

        btnPrintFFBDO.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub dgvListOfVehicleLog_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListOfVehicleLog.KeyDown

        If dgvListOfVehicleLog.RowCount = 0 Then
            Return
        End If

        If dgvListOfVehicleLog.CurrentRow.Index >= 0 And dgvListOfVehicleLog.CurrentCell.ColumnIndex >= 0 And dgvListOfVehicleLog.CurrentRow.Selected Then

            If e.KeyCode = 13 Then

                e.Handled = True

                If dgvListOfVehicleLog.CurrentRow.Index >= 0 And dgvListOfVehicleLog.CurrentCell.ColumnIndex > 0 Then

                    'If Convert.ToString(dgvListOfVehicleLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then
                    '    'MsgBox("Cannot modify this record as it has been already Approved.", MsgBoxStyle.OkOnly, "Information")
                    '    DisplayInfoMessage("MsgPosted")
                    '    ResetControls("EnableAllControls")
                    '    ResetControls("EnableControls")
                    '    Return
                    'Else

                    '    btnSaveOrUpdate.Text = "Update"

                    '    ResetControls("DisableAllControls")
                    '    ResetControls("DisableControls")
                    '    ResetControls("VehicleCode")
                    '    ResetControls("Default")
                    '    ResetControls("Mandatary")
                    '    ResetControls("VehicleRunningData")
                    '    ResetControls("BunchesData")
                    '    ResetDTPicker()

                    '    liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
                    '    EditListOfVehicle(liID)
                    'End If

                    liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)

                    'ResetControls("DisableAllControls")
                    Me.GetBatchValueByVehicleCode(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("VehicleCode").Value, String.Empty, CDate(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("LogDate").Value))

                    If pnlEntryArea.Enabled = False Then

                        EditListOfVehicle(liID)

                        Return

                    End If

                    'ResetControls("DisableControls")
                    'ResetControls("VehicleCode")
                    'ResetControls("Default")
                    'ResetControls("Mandatary")
                    'ResetControls("VehicleRunningData")
                    'ResetControls("BunchesData")
                    'ResetDTPicker()

                    'btnSaveOrUpdate.Text = "Update"


                    If Convert.ToString(dgvListOfVehicleLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

                        btnSaveOrUpdate.Enabled = False

                        'liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
                        EditListOfVehicle(liID)
                        ResetControls("DisableAllControls")
                        '  gbBunchesData.Enabled = False
                        'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
                        DisplayInfoMessage("MsgPosted")

                        Return
                    Else

                        ResetControls("DisableControls")
                        ResetControls("VehicleCode")
                        ResetControls("Default")
                        ResetControls("Mandatary")
                        ResetControls("VehicleRunningData")
                        ResetControls("BunchesData")
                        '   ResetDTPicker()

                        'btnSaveOrUpdate.Text = "Update"

                        If GlobalPPT.strLang = "en" Then
                            btnSaveOrUpdate.Text = "Update"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveOrUpdate.Text = "Memperbarui"
                        End If


                        btnSaveOrUpdate.Enabled = True
                        dgvListOfVehicleLog.Enabled = True

                        'liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
                        EditListOfVehicle(liID)
                    End If


                End If
                btnPrintFFBDO.Enabled = True
            End If
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        
        'lbDateHarvested = False
        'lbDateCollected = False
        LoadVehicleRunningLogDataFromView(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("VehicleCode").Value, CDate(dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("LogDate").Value))
        If Convert.ToString(dgvListOfVehicleLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

            btnSaveOrUpdate.Enabled = False
            ResetControls("DisableAllControls")
            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            '  gbBunchesData.Enabled = False
            DisplayInfoMessage("MsgPosted")
            Return
        End If

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        
        liID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)

        'lbDateHarvested = False
        'lbDateCollected = False

        EditListOfVehicle(liID)
        If Convert.ToString(dgvListOfVehicleLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then

            btnSaveOrUpdate.Enabled = False
            ResetControls("DisableAllControls")
            'MsgBox("Cannot modify / delete this record as it has been already approved.", MsgBoxStyle.OkOnly, "Information")
            ' gbBunchesData.Enabled = False
            DisplayInfoMessage("MsgPosted")
            Return
        End If

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        
        DeleteVehicleRunningLog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogFrm))
        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

    'Private Sub cmsDelete_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)

    'End Sub

    Private Sub dtpDate_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.DropDown
        Me.dateIsChangedByUser = True
    End Sub

    Private Sub dtpDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.CloseUp
        Me.dateIsChangedByUser = False
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        If dateIsChangedByUser And Not String.IsNullOrEmpty(txtVehicleCode.Text.Trim) Then
            VehicleCodeChangedOrDateChanged()
        End If
    End Sub

    Private Sub ibtnSearchVehicleCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSearchVehicleCode.Click

        'Dim objVehicleLookup As New VehicleLookup()
        'Dim result As DialogResult = objVehicleLookup.ShowDialog()

        'If (result = DialogResult.OK) Then

        '    ResetControls("EnableControls")
        '    ResetControls("VehicleCode")
        '    ResetControls("Default")
        '    ResetControls("Mandatary")
        '    ResetControls("VehicleRunningData")
        '    ResetControls("BunchesData")
        '    ResetControls("ClearGrid")

        '    txtVehicleCode.Text = objVehicleLookup.lVHCode
        '    GetBatchValueByVehicleCode(objVehicleLookup.lVHCode, String.Empty)
        'End If

        Dim _VHLookupfrm As New VHLookupfrm
        '_VHLookupfrm.pcType = "V"
        Dim result As DialogResult = _VHLookupfrm.ShowDialog()
        If (result = DialogResult.OK) Then

            ResetControls("VehicleRunningData")
            ResetControls("EnableAllControls")
            ResetControls("EnableControls")
            ResetControls("VehicleCode")
            ResetControls("Default")
            ResetControls("Mandatary")
            ResetControls("BunchesData")
            ResetControls("ClearGrid")
            '   ResetDTPicker()

            lsVHID = _VHLookupfrm.lVHID

            txtVehicleCode.Text = _VHLookupfrm.lVHCode
            GetBatchValueByVehicleCode(_VHLookupfrm.lVHCode, String.Empty, dtpDate.Value)

            OperationalRequiredLabelColor()
            If dgvListOfVehicleLog.Rows.Count = 0 Then
                btnActivity.Enabled = False
            Else
                btnActivity.Enabled = True
            End If
        End If

    End Sub

    'Private Sub btnLookUpDIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpDIV.Click

    '    Dim _VHDIVLookup As New VHDIVLookup()
    '    Dim result As DialogResult = _VHDIVLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then

    '        txtDIV.Text = _VHDIVLookup.lDivCode

    '    End If

    '    If _VHDIVLookup.lDivCode.Trim <> String.Empty Then
    '        OperationalRequiredLabelColor()

    '        EnableDivYopBlock("YOP", True)
    '        txtYOP.Focus()
    '    End If

    '    'Dim objSearchDiv As SearchDivision
    '    ''Here the form name is passed to the constructior of SearchVehilce class for the Form to know where to return the value
    '    'objSearchDiv = New SearchDivision("VehicleRunningLog")

    '    'Me.Hide()

    '    'objSearchDiv.MdiParent = MDIVehicle
    '    'objSearchDiv.WindowState = FormWindowState.Maximized
    '    'objSearchDiv.Show()

    'End Sub

    'Private Sub btnLookUpYOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpYOP.Click

    '    Dim _VHYOPLookup As New VHYOPLookup(txtDIV.Text.Trim)
    '    '_VHYOPLookup = New YOPLookup(txtDIV.Text.Trim)

    '    Dim result As DialogResult = _VHYOPLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then

    '        txtYOP.Text = _VHYOPLookup.lYOPCode
    '        If _VHYOPLookup.lYOPDiv <> String.Empty Then
    '            txtDIV.Text = _VHYOPLookup.lYOPDiv
    '        End If
    '    End If

    '    If _VHYOPLookup.lYOPDiv.Trim <> String.Empty Then
    '        OperationalRequiredLabelColor()
    '        EnableDivYopBlock("SubBlock", True)
    '        txtSubBlock.Focus()
    '    End If

    '    'Dim objSearchDiv As SearchYOP
    '    ''Here the form name is passed to the constructior of SearchVehilce class for the Form to know where to return the value
    '    'objSearchDiv = New SearchYOP("VehicleRunningLog")

    '    'Me.Hide()

    '    'objSearchDiv.MdiParent = MDIVehicle
    '    'objSearchDiv.WindowState = FormWindowState.Maximized
    '    'objSearchDiv.Show()
    'End Sub

    'Private Sub btnLookUpSubBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpSubBlock.Click

    '    Dim _VHSubBlockLookup As New VHSubBlockLookup(txtDIV.Text.Trim, txtYOP.Text.Trim)
    '    Dim result As DialogResult = _VHSubBlockLookup.ShowDialog()

    '    If (result = DialogResult.OK) Then

    '        txtSubBlock.Text = _VHSubBlockLookup.lSBCode
    '        If _VHSubBlockLookup.lDivCode <> String.Empty Then
    '            txtDIV.Text = _VHSubBlockLookup.lDivCode
    '        End If
    '        If _VHSubBlockLookup.lYOPCode <> String.Empty Then
    '            txtYOP.Text = _VHSubBlockLookup.lYOPCode
    '        End If

    '    End If

    '    If _VHSubBlockLookup.lYOPCode.Trim <> String.Empty Then
    '        OperationalRequiredLabelColor()
    '    End If

    '    'Dim objSearchDiv As SearchSubBlock
    '    ''Here the form name is passed to the constructior of SearchVehilce class for the Form to know where to return the value
    '    'objSearchDiv = New SearchSubBlock("VehicleRunningLog")

    '    'Me.Hide()

    '    'objSearchDiv.MdiParent = MDIVehicle
    '    'objSearchDiv.WindowState = FormWindowState.Maximized
    '    'objSearchDiv.Show()
    'End Sub

    Private Sub ibtnSearchBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpSubBlock.Click
        Dim frmSubBlock As New VHDistributionSubBlockLookup
        GlobalPPT.psAcctExpenditureType = String.Empty
        Dim result As DialogResult = frmSubBlock.ShowDialog()
        If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtSubBlock.Text = frmSubBlock.psBlockName
            'lsVDBlockID = frmSubBlock.psBlockId
            'lblSubBlockStatus.Text = frmSubBlock.psBlockStatus
            Me.txtDIV.Text = frmSubBlock.psDIV
            'lsVDDivID = frmSubBlock.psDIVID
            Me.txtYOP.Text = frmSubBlock.psYop
            'lsVDYopID = frmSubBlock.psYopID
        End If

        OperationalRequiredLabelColor()

    End Sub

    'Private Sub ibtnSearchBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpSubBlock.Click

    '    Dim frmSubBlock As New SubBlockLookup
    '    Dim result As DialogResult = frmSubBlock.ShowDialog()
    '    If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.txtSubBlock.Text = frmSubBlock.psBlockName
    '        psSIVBlockID = frmSubBlock.psBlockId
    '        ''Me.lblSubBlockName.Text = frmSubBlock.psBlockStatus
    '        Me.txtDIV.Text = frmSubBlock.psDIV
    '        psSIVDivID = frmSubBlock.psDIVID
    '        ''Me.lblDivName.Text = frmSubBlock.psDIVName
    '        Me.txtYOP.Text = frmSubBlock.psYop
    '        ''  Me.lblYOPName.Text = frmSubBlock.psYopName
    '        psSIVYopID = frmSubBlock.psYopID
    '    End If

    'End Sub

    'Private Sub btnLookUpDIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpDIV.Click

    '    Dim frmDivLookup As New DivLookup
    '    frmDivLookup.BindDIV(psSIVBlockID)
    '    Dim result As DialogResult = frmDivLookup.ShowDialog()
    '    If frmDivLookup.DialogResult = Windows.Forms.DialogResult.OK Then
    '        Me.txtDIV.Text = frmDivLookup.psDIV
    '        psSIVDivID = frmDivLookup.psDIVID
    '    End If

    'End Sub

    Private Sub btnLookUpContractNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookUpContractNo.Click

        'Dim objContractLookup As New ContractLookup
        'Dim result As DialogResult = objContractLookup.ShowDialog()

        'If (result = DialogResult.OK) Then

        '    txtContractNo.Text = objContractLookup.lContractNo

        'End If

        Dim _ContractNoLookup As New ContractNoLookup
        Dim result As DialogResult = _ContractNoLookup.ShowDialog()
        If (result = DialogResult.OK) Then
            txtContractNo.Text = _ContractNoLookup.strContractNo
        End If

    End Sub

    'For accept only Decimal Numbers
    Private Sub MyTextbox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtStartKms.KeyDown, txtEndKms.KeyDown

        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If
        isModifierKey = False
        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then
            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty
            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    Case Keys.[Decimal], Keys.OemPeriod
                        If txtBox.Text.Trim.Contains(".") Then
                            isDecimal = False
                            Return
                        End If
                        isDecimal = True
                        Return
                    Case Else
                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If
                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
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

    'For accept only Decimal Numbers
    Private Sub MyTextbox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtStartKms.KeyPress, txtEndKms.KeyPress
        If isModifierKey Then
            e.Handled = True
            Return
        End If

        If isDecimal = False Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    'For accept only Numbers
    'Private Sub txtContractNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContractNo.KeyPress
    '    If AscW(e.KeyChar) = 8 Then 'For Back Space
    '        e.Handled = False
    '        Return
    '    End If

    '    e.Handled = Not Char.IsDigit(e.KeyChar)
    'End Sub

    'Private Sub OperationalRequiredLabelColor(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBunches.KeyUp, txtFFBDeliveryOrderNo.KeyUp, txtSubBlock.KeyUp, txtYOP.KeyUp, txtDIV.KeyUp
    '    OperationalRequiredLabelColor()
    'End Sub

    'Private Sub DivSubBlock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.TextChanged, txtDIV.TextChanged
    '    OperationalRequiredLabelColor()
    'End Sub

    Private Sub btnPrintFFBDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintFFBDO.Click
        If GlobalPPT.strLang = "en" Then
            If btnSaveOrUpdate.Text = "Update" And rbFFBdeliverytoMill.Checked = True Then
                FFBDeliveryOrderReport()
                'VehicleTransportFFBReport()
            Else
                DisplayInfoMessage("FFBReportMsg")
                'MessageBox.Show("Report is available only for records of FFB delivered to mill, can be viewed only during update mode.", lblSerialNo.Text, MessageBoxButtons.OK)
            End If
        ElseIf GlobalPPT.strLang = "ms" Then
            If btnSaveOrUpdate.Text = "Memperbarui" And rbFFBdeliverytoMill.Checked = True Then
                FFBDeliveryOrderReport()
                'VehicleTransportFFBReport()
            Else
                DisplayInfoMessage("FFBReportMsg")
                'MessageBox.Show("Report is available only for records of FFB delivered to mill, can be viewed only during update mode.", lblSerialNo.Text, MessageBoxButtons.OK)
            End If

        End If



    End Sub

    Private Sub FFBDeliveryOrderReport()

        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New FFBDeliveryOrderRpt
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsDistibusiRpt As New DataSet
        cmd.Connection = con

        'cmd.CommandText = "[Vehicle].[FFBDeliveryOrderReportGET] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & GlobalPPT.strActMthYearID & "'"
        cmd.CommandText = "[Vehicle].[FFBDeliveryOrderReportGET] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & liID & "'"

        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsDistibusiRpt, "FFBDeliveryOrderReportGET;1")

        'Dim txtEstate, txtFromDate, txtToDate, txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

        'txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)

        'txtFiscal.Text = "FFB DELIVERY ORDER " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        'txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        'txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
        'txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

        If dsDistibusiRpt.Tables(0).Rows.Count > 0 Then

            Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
            Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
            Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
            Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

            Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
            Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

            ParamterField1.ParameterFieldName = "@ActiveMonthYearID"
            ParamterDescreteValue1.Value = GlobalPPT.strActMthYearID
            ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
            ParamterFields.Add(ParamterField1)

            ParamterField2.ParameterFieldName = "@EstateID"
            ParamterDescreteValue2.Value = GlobalPPT.strEstateID
            ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
            ParamterFields.Add(ParamterField2)

            ParamterField3.ParameterFieldName = "@ID"
            ParamterDescreteValue3.Value = liID 'dgvListOfVehicleLog.Rows(dgvListOfVehicleLog.CurrentRow.Index).Cells("ID").Value
            ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
            ParamterFields.Add(ParamterField3)

            Dim vvr As New VehicleProofListReport
            vvr.crvVehicle.ParameterFieldInfo = ParamterFields

            rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
            rpt.SetDataSource(dsDistibusiRpt)
            vvr.crvVehicle.ReportSource = rpt

            vvr.ShowDialog()
        End If
    End Sub

    'Private Sub VehicleTransportFFBReport()

    '    Dim strServerUserName As String = String.Empty
    '    Dim strServerPassword As String = String.Empty
    '    Dim strDSN As String = String.Empty

    '    strDSN = "" & System.Configuration.ConfigurationManager.AppSettings.Item("oDSN").ToString & ""
    '    strServerUserName = "" & System.Configuration.ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
    '    strServerPassword = "" & System.Configuration.ConfigurationManager.AppSettings.Item("oPassword").ToString & ""

    '    Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
    '    Dim con As New Odbc.OdbcConnection
    '    Dim cmd As New Odbc.OdbcCommand
    '    Dim da As New Odbc.OdbcDataAdapter
    '    con = New Odbc.OdbcConnection(constr)
    '    con.Open()

    '    Dim rpt As New VehicleTransportFFBRpt
    '    Dim tblAdt As New Odbc.OdbcDataAdapter
    '    Dim dsVehicleTransportFFBReport As New DataSet
    '    cmd.Connection = con

    '    'cmd.CommandText = "[Vehicle].[FFBDeliveryOrderReportGET] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & GlobalPPT.strActMthYearID & "'"
    '    cmd.CommandText = "[Vehicle].[VehicleTransportFFBReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.IntLoginMonth & "','" & GlobalPPT.intLoginYear & "'"

    '    cmd.CommandType = CommandType.StoredProcedure
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(dsVehicleTransportFFBReport, "VehicleTransportFFBReportGet;1")

    '    Dim txtEstate, txtFromDate, txtToDate, txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

    '    txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)

    '    txtFiscal.Text = "Vehicle Transport FFB " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
    '    txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
    '    txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
    '    txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

    '    If dsVehicleTransportFFBReport.Tables(0).Rows.Count > 0 Then

    '        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
    '        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
    '        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
    '        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

    '        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

    '        ParamterField1.ParameterFieldName = "@EstateID"
    '        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
    '        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
    '        ParamterFields.Add(ParamterField1)

    '        ParamterField2.ParameterFieldName = "@LogedInMonth"
    '        ParamterDescreteValue2.Value = GlobalPPT.IntLoginMonth
    '        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
    '        ParamterFields.Add(ParamterField2)

    '        ParamterField3.ParameterFieldName = "@LogedInYear"
    '        ParamterDescreteValue3.Value = GlobalPPT.intLoginYear
    '        ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
    '        ParamterFields.Add(ParamterField3)

    '        Dim vvr As New VehicleViewReport
    '        vvr.crvVehicle.ParameterFieldInfo = ParamterFields

    '        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
    '        rpt.SetDataSource(dsVehicleTransportFFBReport)
    '        vvr.crvVehicle.ReportSource = rpt

    '        vvr.ShowDialog()
    '    End If
    'End Sub

    Private Sub VehicleRunningLogFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub chkDateCollected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkDateCollected.Checked Then
    '        dtpDateCollected.Enabled = True
    '        dtpDateCollected.Text = Date.Now
    '    Else
    '        dtpDateCollected.Enabled = False
    '        dtpDateCollected.Text = Date.Now
    '    End If
    'End Sub

    'Private Sub chkDateHarvested_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkDateHarvested.Checked Then
    '        dtpDateHarvested.Enabled = True
    '        dtpDateHarvested.Text = Date.Now
    '    Else
    '        dtpDateHarvested.Enabled = False
    '        dtpDateHarvested.Text = Date.Now
    '    End If
    'End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        'Dim ObjRecordExist As New Object
        'Dim _VehicleRunningLogPPT As New VehicleRunningLogPPT
        'Dim _VehicleRunningLogBOL As New VehicleRunningLogBOL
        'ObjRecordExist = _VehicleRunningLogBOL.VHRunningLogRecordIsExist(_VehicleRunningLogPPT)

        'If ObjRecordExist = 0 Then
        '    MsgBox("No Records Available!")
        'Else
        Dim childCR As New VehicleProofListReport
        childCR.strReportName = "VehicleRunningLogRpt"
        childCR.ShowDialog()

        'VehicleRunningLogRpt.ShowDialog()

        'End If

    End Sub

    Private Sub txtFFBDeliveryOrderNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OperationalRequiredLabelColor()
    End Sub

    Private Sub txtStartHr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartHr.Leave
        If txtStartHr.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([01]\d|2[0123])$")
            If Not rtime.IsMatch(txtStartHr.Text.Trim) Then
                DisplayInfoMessage("IStartHrs")
                txtStartHr.Focus()
            End If
        End If
        If txtStartHr.Text.Trim <> String.Empty And txtStartMin.Text.Trim <> String.Empty Then
            lsStartTime = String.Format("{0:00}", Convert.ToInt32(txtStartHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtStartMin.Text.Trim))
            CalculateMeridianAndTotalHrs()
        Else
            lsStartTime = String.Empty
            txtTotalHours.Text = String.Empty
        End If
    End Sub

    Private Sub txtStartMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartMin.Leave
        If txtStartMin.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([0-5][0-9])$")
            If Not rtime.IsMatch(txtStartMin.Text.Trim) Then
                DisplayInfoMessage("IStartMin")
                txtStartMin.Focus()
            End If
        End If
        If txtStartHr.Text.Trim <> String.Empty And txtStartMin.Text.Trim <> String.Empty Then
            lsStartTime = String.Format("{0:00}", Convert.ToInt32(txtStartHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtStartMin.Text.Trim))
            CalculateMeridianAndTotalHrs()
        Else
            lsStartTime = String.Empty
            txtTotalHours.Text = String.Empty
        End If
    End Sub

    Private Sub txtEndHr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndHr.Leave
        If txtEndHr.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([01]\d|2[0123])$")
            If Not rtime.IsMatch(txtEndHr.Text.Trim) Then
                DisplayInfoMessage("IEndHrs")
                txtEndHr.Focus()
            End If
        End If

        If txtEndHr.Text.Trim <> String.Empty And txtEndMin.Text.Trim <> String.Empty Then
            lsEndTime = String.Format("{0:00}", Convert.ToInt32(txtEndHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtEndMin.Text.Trim))
            CalculateMeridianAndTotalHrs()
        Else
            lsEndTime = String.Empty
            txtTotalHours.Text = String.Empty
        End If
    End Sub

    Private Sub txtEndMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndMin.Leave
        If txtEndMin.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("^([0-5][0-9])$")
            If Not rtime.IsMatch(txtEndMin.Text.Trim) Then
                DisplayInfoMessage("IEndMin")
                txtEndMin.Focus()
            End If
        End If

        If txtEndHr.Text.Trim <> String.Empty And txtEndMin.Text.Trim <> String.Empty Then
            lsEndTime = String.Format("{0:00}", Convert.ToInt32(txtEndHr.Text.Trim)) + ":" + String.Format("{0:00}", Convert.ToInt32(txtEndMin.Text.Trim))
            CalculateMeridianAndTotalHrs()
        Else
            lsEndTime = String.Empty
            txtTotalHours.Text = String.Empty
        End If
    End Sub

    Private Sub txtTotalHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalHours.KeyPress
        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 58 And Asc(e.KeyChar) <> 8 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub txtTotalHours_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalHours.Leave
        If txtTotalHours.Text.Trim <> String.Empty Then
            Dim rtime As New System.Text.RegularExpressions.Regex("[0-9]:[0-5][0-9]$")
            If Not rtime.IsMatch(txtTotalHours.Text.Trim) Then
                DisplayInfoMessage("ITimeFormat")
                txtTotalHours.Focus()
            End If
        Else
            txtStartHr.Enabled = True
            txtStartMin.Enabled = True
            txtEndHr.Enabled = True
            txtEndMin.Enabled = True
        End If

    End Sub
    Private Sub txtTotalHours_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalHours.KeyDown
        If e.KeyCode = Keys.Enter Then

        Else

            txtStartHr.Enabled = False
            txtStartMin.Enabled = False
            txtEndHr.Enabled = False
            txtEndMin.Enabled = False
            txtStartHr.Text = String.Empty
            txtStartMin.Text = String.Empty
            txtEndHr.Text = String.Empty
            txtEndMin.Text = String.Empty
            lsStartTime = String.Empty
            lsEndTime = String.Empty
            txtShift.Text = String.Empty
           

        End If
        
    End Sub

    'Private Sub cmbStartHrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbStartHrs.SelectedIndex > -1 And cmbStartMin.SelectedIndex > -1 Then
    '        lsStartTime = String.Format("{0:00}", Convert.ToInt32(cmbStartHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbStartMin.Text))
    '        CalculateMeridianAndTotalHrs()
    '    Else
    '        lsStartTime = String.Empty
    '    End If


    '    If lsStartTime <> String.Empty And lsEndTime <> String.Empty Then

    '    End If

    'End Sub

    'Private Sub cmbStartMin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbStartHrs.SelectedIndex > -1 And cmbStartMin.SelectedIndex > -1 Then
    '        lsStartTime = String.Format("{0:00}", Convert.ToInt32(cmbStartHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbStartMin.Text))
    '        CalculateMeridianAndTotalHrs()
    '    Else
    '        lsStartTime = String.Empty
    '    End If
    'End Sub

    'Private Sub cmbEndHrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbEndHrs.SelectedIndex > -1 And cmbEndMin.SelectedIndex > -1 Then
    '        lsEndTime = String.Format("{0:00}", Convert.ToInt32(cmbEndHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbEndMin.Text))
    '        CalculateMeridianAndTotalHrs()
    '    Else
    '        lsEndTime = String.Empty
    '    End If
    'End Sub

    'Private Sub cmbEndMin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbEndHrs.SelectedIndex > -1 And cmbEndMin.SelectedIndex > -1 Then
    '        lsEndTime = String.Format("{0:00}", Convert.ToInt32(cmbEndHrs.Text)) + ":" + String.Format("{0:00}", Convert.ToInt32(cmbEndMin.Text))
    '        CalculateMeridianAndTotalHrs()
    '    Else
    '        lsEndTime = String.Empty
    '    End If
    'End Sub

#End Region

#Region "Functions"

    Private Sub LoadVehicleRunningLogDataFromView(ByVal lsVheicleCode As String, ByVal ldDate As Date)

        ResetControls("EnableAllControls")
        ResetControls("EnableControls")
        ResetControls("VehicleCode")
        ResetControls("Default")
        ResetControls("Mandatary")
        ResetControls("VehicleRunningData")
        ResetControls("BunchesData")
        ResetControls("ClearGrid")

        tbVehicleRunningLog.SelectedIndex = 0
        'ResetControls("Date")

        Me.GetBatchValueByVehicleCode(lsVheicleCode, String.Empty, ldDate)

        ResetControls("FFBdeliverytoMill")

        'Commented for the change that after delete and update show the edit tab like when we comes from the View tab

        'If dgVehicleCode.CurrentRow.Index >= 0 And dgVehicleCode.CurrentCell.ColumnIndex >= 0 Then

        '    'Dim lsVheicleCode As String = dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("psVHWSCode").Value

        '    Dim lsVheicleCode As String
        '    lsVheicleCode = dgVehicleCode.Rows(dgVehicleCode.CurrentRow.Index).Cells("VHWSCode").Value

        '    ResetControls("EnableControls")
        '    ResetControls("VehicleCode")
        '    ResetControls("Default")
        '    ResetControls("Mandatary")
        '    ResetControls("VehicleRunningData")
        '    ResetControls("BunchesData")
        '    ResetControls("ClearGrid")

        '    Me.GetBatchValueByVehicleCode(lsVheicleCode, String.Empty)
        '    tbVehicleRunningLog.SelectTab(1)
        'End If
        If dgvListOfVehicleLog.Rows.Count = 0 Then
            btnActivity.Enabled = False
        Else
            btnActivity.Enabled = True
        End If
    End Sub

    Public Sub ResetControls(ByVal lsGroup As String)

        Select Case lsGroup

            Case "EnableControls"
                ibtnSearchVehicleCode.Enabled = True
                dtpDate.Enabled = True
                txtVehicleCode.Enabled = True
                btnSaveOrUpdate.Enabled = True
                btnPrintFFBDO.Enabled = True
                Exit Select

            Case "DisableControls"
                ibtnSearchVehicleCode.Enabled = False
                dtpDate.Enabled = False
                txtVehicleCode.Enabled = False
                Exit Select

            Case "Date"

                'General.SetVehicleDateTimePicker(dtpDate, "Vehicle", "VHRunningLog", "LogDate")
                'General.SetVehicleDateTimePicker(dtpSearchBy, "Vehicle", "VHRunningLog", "LogDate")

                Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpDate)
                Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpSearchBy)

                ' ResetDTPicker()

                'ResetDTPicker()

                'dtpDateHarvested.Text = Date.Now
                'dtpDateCollected.Text = Date.Now
                'dtpSearchBy.Text = dtpSearchBy.MinDate.ToString
                'dtpDate.Text = dtpDate.MinDate.ToString
                'dtpDateHarvested.Text = dtpDateHarvested.MinDate.ToString
                'dtpDateCollected.Text = dtpDateCollected.MinDate.ToString
                Exit Select

                'Because if we leave for txtVehicleCode it will clear
            Case "VehicleCode"
                txtVehicleCode.Text = String.Empty
                Exit Select

            Case "Default"
                'txtVehicleCode.Text = String.Empty
                txtBatchValue.Text = String.Empty
                txtVehicleDescription.Text = String.Empty
                txtVehicleModel.Text = String.Empty
                txtUOM.Text = String.Empty
                txtOperatedBy.Text = String.Empty
                txtVehicleRegNo.Text = String.Empty
                txtContractNo.Text = String.Empty
                rbOperational.Checked = True
                ' gbBunchesData.Enabled = False
                rbBreakDown.Checked = False
                rbStandBy.Checked = False
                rbFFBdeliverytoMill.Checked = False

                'cmbStartHrs.SelectedIndex = -1
                'cmbStartMin.SelectedIndex = -1
                'cmbEndHrs.SelectedIndex = -1
                'cmbEndMin.SelectedIndex = -1

                txtStartHr.Text = String.Empty
                txtStartMin.Text = String.Empty
                txtEndHr.Text = String.Empty
                txtEndMin.Text = String.Empty
                txtStartHr.Enabled = True
                txtStartMin.Enabled = True
                txtEndHr.Enabled = True
                txtEndMin.Enabled = True


                lsStartTime = String.Empty
                lsEndTime = String.Empty
                lblStartTime.ForeColor = Color.Black
                lblEndTime.ForeColor = Color.Black
                lblTotalHours.ForeColor = Color.Black
                lblStartKms.ForeColor = Color.Black
                lblEndKms.ForeColor = Color.Black


                If ddlLocation.Items.Count = 0 Then
                    ddlLocation.SelectedIndex = -1
                Else
                    ddlLocation.SelectedIndex = 0
                End If

                'btnSaveOrUpdate.Text = "Save"

                If GlobalPPT.strLang = "en" Then
                    btnSaveOrUpdate.Text = "Save"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveOrUpdate.Text = "Simpan"
                End If

                Exit Select

                'ResetDTPicker()

            Case "Mandatary"
                txtContractNo.Text = String.Empty
                txtRemarks.Text = String.Empty
                Exit Select

            Case "VehicleRunningData"
                txtStartKms.Text = String.Empty
                txtEndKms.Text = String.Empty
                txtTotalKms.Text = String.Empty

                txtStartHr.Text = String.Empty
                txtStartMin.Text = String.Empty
                txtEndHr.Text = String.Empty
                txtEndMin.Text = String.Empty

                txtStartHr.Enabled = True
                txtStartMin.Enabled = True
                txtEndHr.Enabled = True
                txtEndMin.Enabled = True

                'cmbStartHrs.SelectedIndex = -1
                'cmbStartMin.SelectedIndex = -1
                'cmbEndHrs.SelectedIndex = -1
                'cmbEndMin.SelectedIndex = -1

                lsStartTime = String.Empty
                lsEndTime = String.Empty
                txtTotalHours.Text = String.Empty
                txtShift.Text = String.Empty
                txtDIV.Text = String.Empty
                txtYOP.Text = String.Empty
                txtSubBlock.Text = String.Empty
                txtVehicleActivity.Text = String.Empty
                txtRemarks.Text = String.Empty
                Exit Select

            Case "BunchesData"
                'txtFFBDeliveryOrderNo.Text = String.Empty
                'txtBunches.Text = String.Empty
                'txtActualBunchesMill.Text = String.Empty
                'txtCollectionPoint.Text = String.Empty
                'txtMillWeight.Text = String.Empty
                'txtDoubleHandledFFB.Text = String.Empty
                'txtWeightedBy.Text = String.Empty
                'txtDispatchedBy.Text = String.Empty
                Exit Select

                'Clear the DataGrid
            Case "ClearGrid"

                ClearGridView(dgvListOfVehicleLog)

                '_VehicleRunningLogCollection = New VehicleRunningLogCollection

                'With dgvListOfVehicleLog
                '    .AutoGenerateColumns = False
                '    .DataSource = _VehicleRunningLogCollection
                'End With

                'For n As Integer = 0 To dgvListOfVehicleLog.Rows.Count - 1
                '    If dgvListOfVehicleLog.Rows(0).IsNewRow = False Then
                '        dgvListOfVehicleLog.Rows.RemoveAt(0)
                '    End If
                'Next

                Exit Select

            Case "DisableAllControls"
                grpDefault.Enabled = False
                gbVehicleRunningData.Enabled = False
                'If rbFFBdeliverytoMill.Checked = False Then
                '    gbBunchesData.Enabled = False
                'Else
                '    gbBunchesData.Enabled = True
                'End If

                txtRemarks.Enabled = False
                btnSaveOrUpdate.Enabled = False
                Exit Select

            Case "EnableAllControls"
                grpDefault.Enabled = True
                gbVehicleRunningData.Enabled = True
                'gbBunchesData.Enabled = True
                If rbFFBdeliverytoMill.Checked = False Then
                    ' gbBunchesData.Enabled = False
                Else
                    ' gbBunchesData.Enabled = True
                End If
                txtRemarks.Enabled = True
                btnSaveOrUpdate.Enabled = True
                Exit Select


            Case "FFBdeliverytoMill"

                Select Case (rbFFBdeliverytoMill.Checked)
                    Case True

                        If rbFFBdeliverytoMill.Checked = True Then
                            If txtUOM.Text.Trim = "Hrs" Then
                                txtStartKms.Enabled = False
                                txtEndKms.Enabled = False
                            End If
                        End If
                        ' gbBunchesData.Enabled = True

                        lblDIV.ForeColor = Color.Red
                        lblYOP.ForeColor = Color.Red
                        lblSubBlock.ForeColor = Color.Red
                        'lblSerialNo.ForeColor = Color.Red
                        'lblBunches.ForeColor = Color.Red

                        Exit Select
                    Case False
                        ResetControls("BunchesData")

                        lblDIV.ForeColor = Color.Black
                        lblYOP.ForeColor = Color.Black
                        lblSubBlock.ForeColor = Color.Black
                        'lblSerialNo.ForeColor = Color.Black
                        'lblBunches.ForeColor = Color.Black

                        'gbBunchesData.Enabled = False
                        Exit Select
                End Select

        End Select

    End Sub

    'Called on Page_Load
    'Back button Press
    'Go button click
    'When tab index changed
    'After Save Or update Button press

    Private Sub FillVehicleCodeFromVehicleRunningLog(ByVal lsVehicleCode As String, ByVal lsSender As String)

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        _VehicleRunningLogPPT.psVHWSCode = lsVehicleCode

        'If rbDate.Checked Then
        '    _VehicleRunningLogPPT.psSearchBy = "Date"
        '    _VehicleRunningLogPPT.pdLogDate = New Date(dtpSearchBy.Value.Year, dtpSearchBy.Value.Month, dtpSearchBy.Value.Day) 'DateTime.Parse(txtVehicleCodeView.Text.Trim, culture, DateTimeStyles.NoCurrentDateDefault)
        'ElseIf rbVehicleCode.Checked And txtVehicleCodeView.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.psSearchBy = "Vehicle Code"
        '    _VehicleRunningLogPPT.pdLogDate = CDate("1/1/1753")
        'Else
        '    _VehicleRunningLogPPT.psSearchBy = String.Empty
        '    _VehicleRunningLogPPT.pdLogDate = CDate("1/1/1753")
        'End If

        If chkDate.Checked Then
            _VehicleRunningLogPPT.psSearchBy = "Date"
            _VehicleRunningLogPPT.pdLogDate = New Date(dtpSearchBy.Value.Year, dtpSearchBy.Value.Month, dtpSearchBy.Value.Day) 'DateTime.Parse(txtVehicleCodeView.Text.Trim, culture, DateTimeStyles.NoCurrentDateDefault)
        Else

            _VehicleRunningLogPPT.pdLogDate = CDate("1/1/1753")
        End If


        'Global
        '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
        '_VehicleRunningLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        Dim dtVehicleCode As DataTable = _VehicleRunningLogBOL.GetVehicleCodeForView(_VehicleRunningLogPPT)

        With dgVehicleCode
            .AutoGenerateColumns = False
            .DataSource = dtVehicleCode
        End With

        'dgVehicleCode.DataSource = _VehicleRunningLogCollection
        dgVehicleCode.ClearSelection()

        If (dtVehicleCode Is Nothing Or dtVehicleCode.Rows.Count = 0) And lsSender <> String.Empty Then

            If chkDate.Checked Then
                'MsgBox("No record(s) found matching your search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("MsgNoRecords")
                'dtpSearchBy.Text = Date.Now
                dtpSearchBy.Focus()
            Else
                If txtVehicleCodeView.Text.Trim <> String.Empty Then
                    'MsgBox("No record(s) found matching your search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    DisplayInfoMessage("MsgNoRecords")
                    'txtVehicleCodeView.Text = String.Empty
                    'Else 'Show this message when Vehicle code textbox is empty and chkDate is not checked
                    '    MsgBox("Please enter search criteria.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    '    txtVehicleCodeView.Text = String.Empty
                End If

                txtVehicleCodeView.Focus()
            End If
        End If

        'tbVehicleRunningLog.SelectedIndex = 1

    End Sub

    Private Sub FillVehicleRunningLog(ByRef lsVHWSCode As String)

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        '_VehicleRunningLogPPT.psVHWSCode = lsVehicleCode

        'Global
        _VehicleRunningLogPPT.psVHWSCode = lsVHWSCode
        '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
        '_VehicleRunningLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

        Dim dsVehicleRunningLog As DataSet = _VehicleRunningLogBOL.GetBatchValueByVehicleCodeLog(_VehicleRunningLogPPT)

        With dgvListOfVehicleLog
            .AutoGenerateColumns = False
            .DataSource = dsVehicleRunningLog.Tables(1)
        End With

        dgvListOfVehicleLog.Columns("StartTime").DefaultCellStyle.Format = "hh:mm t"
        dgvListOfVehicleLog.Columns("EndTime").DefaultCellStyle.Format = "hh:mm t"

        'dgVehicleCode.DataSource = _VehicleRunningLogCollection
        dgvListOfVehicleLog.ClearSelection()

    End Sub

    ''Called from VehicleCode Grid cell click
    ''Called from VehicleCode Text box leave
    ''Called from Calander date changed
    ''Called from search Page

    ''Public Sub GetBatchValueByVehicleCode(ByVal logDate As DateTime, ByVal vehicleCode As String)
    Public Sub GetBatchValueByVehicleCode(ByVal vehicleCode As String, ByVal lspSender As String, ByVal ldDate As Date)

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        'Date is passed because of getting outstanding batch value 
        '_VehicleRunningLogPPT.pdLogDate = New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)
        _VehicleRunningLogPPT.psVHWSCode = vehicleCode
        '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
        '_VehicleRunningLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
        _VehicleRunningLogPPT.pdLogDate = ldDate

        Dim dsVehicleCode As DataSet = _VehicleRunningLogBOL.GetBatchValueByVehicleCodeLog(_VehicleRunningLogPPT)

        ' dsBatchValue = _VehicleRunningLogBOL.GetBatchValueByVehicleCodeLog(_VehicleRunningLogPPT)

        If dsVehicleCode Is Nothing Then
            Return
        End If

        If dsVehicleCode.Tables(0) IsNot Nothing And dsVehicleCode.Tables(0).Rows.Count > 0 Then

            'Since it is also called from Search form, when we didn't fill the vehicle code
            txtVehicleCode.Text = vehicleCode

            'Removed
            'If dsVehicleCode.Tables(0).Rows(0)("VHBatchValue") > 0 Then
            '    txtBatchValue.Text = Format(Convert.ToDecimal(dsVehicleCode.Tables(0).Rows(0)("VHBatchValue")), "0,0.0,0")
            'Else
            '    txtBatchValue.Text = String.Empty
            'End If
            'dsBatchValue.Tables(0).Rows(0)(0).ToString

            dtpDate.Text = ldDate

            txtVehicleDescription.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("VHDescp")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("VHDescp"))
            txtVehicleModel.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("VHModel")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("VHModel"))
            txtOperatedBy.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("EmpName")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("EmpName"))
            txtVehicleRegNo.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("RegNo")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("RegNo"))
            txtUOM.Text = dsVehicleCode.Tables(0).Rows(0)("UOM")

            Select Case txtUOM.Text.Trim
                Case "Hrs"
                    txtStartKms.Text = String.Empty
                    txtStartKms.Enabled = False

                    txtEndKms.Text = String.Empty
                    txtEndKms.Enabled = False

                    txtTotalKms.Text = String.Empty
                    txtTotalKms.Enabled = False

                    'RestColor According to UOM
                    'lblStartTime.ForeColor = Color.Red
                    'lblEndTime.ForeColor = Color.Red

                    lblStartTime.ForeColor = Color.Black
                    lblEndTime.ForeColor = Color.Black

                    lblStartKms.ForeColor = Color.Black
                    lblEndKms.ForeColor = Color.Black

                    txtStartHr.Enabled = True
                    txtStartMin.Enabled = True
                    txtEndHr.Enabled = True
                    txtEndMin.Enabled = True
                    lblTotalHours.ForeColor = Color.Red

                    Exit Select
                Case "Kms"

                    txtStartKms.Text = String.Empty
                    txtStartKms.Enabled = True

                    txtEndKms.Text = String.Empty
                    txtEndKms.Enabled = True

                    txtTotalKms.Text = String.Empty
                    txtTotalKms.Enabled = True


                    'RestColor According to UOM
                    lblStartKms.ForeColor = Color.Red
                    lblEndKms.ForeColor = Color.Red

                    lblStartTime.ForeColor = Color.Black
                    lblEndTime.ForeColor = Color.Black

                    txtStartHr.Enabled = True
                    txtStartMin.Enabled = True
                    txtEndHr.Enabled = True
                    txtEndMin.Enabled = True
                    lblTotalHours.ForeColor = Color.Black


                    Exit Select

            End Select

            With dgvListOfVehicleLog
                .AutoGenerateColumns = False
                .DataSource = dsVehicleCode.Tables(1)
            End With

            dgvListOfVehicleLog.ClearSelection()


            'If dsVehicleCode.Tables(2) IsNot Nothing And dsVehicleCode.Tables(2).Rows.Count > 0 Then

            '    btnPrintFFBDO.Enabled = True

            '    Select Case txtUOM.Text.Trim
            '        Case "Hrs"
            '            ltsOutstandingHrs = dsVehicleCode.Tables(2).Rows(0)("OutStandingHrs")
            '            'MsgBox(Convert.ToString(_VehicleRunningLogCollection(0).pdOutStandingHrs))
            '            Exit Select
            '        Case "Kms"
            '            ldOutstandingKms = dsVehicleCode.Tables(2).Rows(0)("OutStandingKms")
            '            Exit Select
            '    End Select
            'Else
            '    btnPrintFFBDO.Enabled = False
            '    ltsOutstandingHrs = New TimeSpan(0, 0, 0)
            '    ldOutstandingKms = 0D
            'End If

        Else
            ''Change
            'txtVehicleCode.Text = String.Empty
            txtBatchValue.Text = String.Empty
            txtVehicleDescription.Text = String.Empty
            txtVehicleModel.Text = String.Empty
            txtOperatedBy.Text = String.Empty
            txtVehicleRegNo.Text = String.Empty
            txtUOM.Text = String.Empty
            txtStartKms.Enabled = True

            'VehicleCode Text box leave, Calander date changed. Since here only value given manually

            ''Commented For the issue for Steps for validation
            'If lspSender <> String.Empty Then

            '    txtVehicleCode.Focus()
            '    MsgBox("Sorry, no such vehicle code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")

            'End If

        End If

    End Sub

    Public Sub ShowRunningDetailsByVehicleCodeAndDate(ByVal vehicleCode As String, ByVal ldDate As Date)

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        _VehicleRunningLogPPT.psVHWSCode = vehicleCode
        _VehicleRunningLogPPT.pdLogDate = ldDate

        Dim dsVehicleCode As DataSet = _VehicleRunningLogBOL.GetBatchValueByVehicleCodeLog(_VehicleRunningLogPPT)

        If dsVehicleCode Is Nothing Then
            Return
        End If

        If dsVehicleCode.Tables(0) IsNot Nothing And dsVehicleCode.Tables(0).Rows.Count > 0 Then

            'Since it is also called from Search form, when we didn't fill the vehicle code
            txtVehicleCode.Text = vehicleCode

            'Removed
            'If dsVehicleCode.Tables(0).Rows(0)("VHBatchValue") > 0 Then
            '    txtBatchValue.Text = Format(Convert.ToDecimal(dsVehicleCode.Tables(0).Rows(0)("VHBatchValue")), "0,0.0,0")
            'Else
            '    txtBatchValue.Text = String.Empty
            'End If
            'dsBatchValue.Tables(0).Rows(0)(0).ToString

            dtpDate.Text = ldDate

            txtVehicleDescription.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("VHDescp")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("VHDescp"))
            txtVehicleModel.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("VHModel")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("VHModel"))
            txtOperatedBy.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("EmpName")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("EmpName"))
            txtVehicleRegNo.Text = IIf(IsDBNull(dsVehicleCode.Tables(0).Rows(0)("RegNo")), String.Empty, dsVehicleCode.Tables(0).Rows(0)("RegNo"))
            txtUOM.Text = dsVehicleCode.Tables(0).Rows(0)("UOM")

            With dgvListOfVehicleLog
                .AutoGenerateColumns = False
                .DataSource = dsVehicleCode.Tables(1)
            End With

            dgvListOfVehicleLog.ClearSelection()

            If dgvListOfVehicleLog.Rows.Count = 0 Then
                btnActivity.Enabled = False
            Else
                btnActivity.Enabled = True
            End If
        End If

    End Sub

    Private Sub DeleteVehicleRunningLog()

        cmsDelete.Visible = False

        If Convert.ToString(dgvListOfVehicleLog.CurrentRow.Cells("Posted").Value).Equals("Y") Then
            'MsgBox("Cannot delete this record as it has been already Approved.", MsgBoxStyle.OkOnly, "Information")
            DisplayInfoMessage("MsgPosted")
            ' ResetControls("EnableAllControls")
            ' ResetControls("EnableControls")
            Return
        Else
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogFrm))
            If MsgBox(rm.GetString("DeletePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If MsgBox("You are about to delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim ldGetMessage As Integer
                _VehicleRunningLogPPT = New VehicleRunningLogPPT
                _VehicleRunningLogBOL = New VehicleRunningLogBOL

                _VehicleRunningLogPPT.piID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)
                _VehicleRunningLogPPT.psVHWSCode = dgvListOfVehicleLog.CurrentRow.Cells("VehicleCode").Value
                _VehicleRunningLogPPT.pdLogDate = CDate(dgvListOfVehicleLog.CurrentRow.Cells("LogDate").Value)

                'Global
                '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
                '_VehicleRunningLogPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID

                ldGetMessage = _VehicleRunningLogBOL.DeleteVehicleRunningLog(_VehicleRunningLogPPT)

                General.ShowMessageFromDataBase(ldGetMessage)

                'i.e. If record not in use
                If ldGetMessage <> 4 Then

                    LoadVehicleRunningLogDataFromView(_VehicleRunningLogPPT.psVHWSCode, _VehicleRunningLogPPT.pdLogDate)

                    'Commented for the issue 
                    '2. Deleting While in Update mode - change similar to: click a record from view tab grid and come to entry tab screen. use this state of screen after updation of a record.

                    ''dgvListOfVehicleLog.Rows.Remove(dgvListOfVehicleLog.CurrentRow)

                    'ResetControls("Mandatary")
                    'ResetControls("VehicleRunningData")
                    'ResetControls("BunchesData")

                    ''Refill the grid once again after deletion
                    'Me.GetBatchValueByVehicleCode(_VehicleRunningLogPPT.psVHWSCode, String.Empty)

                    'If dgvListOfVehicleLog.RowCount > 0 Then
                    '    dgvListOfVehicleLog.CurrentRow.Selected = True
                    '    EditListOfVehicle(DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer))
                    'End If

                End If

            End If
        End If

    End Sub

    Private Sub VehicleCodeChangedOrDateChanged()
        If Not String.IsNullOrEmpty(txtVehicleCode.Text.Trim) Then
            Me.GetBatchValueByVehicleCode(txtVehicleCode.Text.Trim, "Leaving from vehicle code or date changed", dtpDate.Value)
        End If
    End Sub

    Private Sub GetLocation()

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        '_VehicleRunningLogPPT.psEstateID = GlobalPPT.strEstateID
        Dim dtLocation As DataTable = _VehicleRunningLogBOL.LocationGet(_VehicleRunningLogPPT)

        If dtLocation IsNot Nothing And dtLocation.Rows.Count > 0 Then

            Dim dr As DataRow = dtLocation.NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            dtLocation.Rows.InsertAt(dr, 0)
            dtLocation.AcceptChanges()


            'Dim _VehicleRunningLogPPT As VehicleRunningLogPPT = New VehicleRunningLogPPT
            '_VehicleRunningLogPPT.psDistributionSetupID = String.Empty
            '_VehicleRunningLogPPT.psDistributionDescp = "--Select--"
            'dtLocation.Insertat(0, _VehicleRunningLogPPT)

        End If

        With ddlLocation
            .DataSource = dtLocation
            .DisplayMember = "DistributionDescp"
            .ValueMember = "DistributionSetupID"
        End With

    End Sub
    Public Function GetDataValue(ByVal o As Object) As Object

        If o Is Nothing OrElse o Is DBNull.Value OrElse String.Empty.Equals(o) Then
            Return String.Empty
        Else
            Return o
        End If

    End Function
    Function IsVHCodePosted() As Boolean
        Dim dtVehicleRunningLog As DataTable = dgvListOfVehicleLog.DataSource

        Dim lsIsPosted As String = "VHWSCode='" & txtVehicleCode.Text.Trim & "' AND LogDate = '#" & dtpDate.Value & "#' AND POSTED = 'Y'"

        Dim dr() As DataRow = dtVehicleRunningLog.Select(lsIsPosted)

        Return IIf(dr.Count = 0, False, True)

    End Function


    Function CheckRequiredFields() As Boolean

        _Val = New Validator

        If Not _Val.RequiredFieldValidator(txtVehicleCode.Text.Trim) Then
            'lsErrorMsg.Append("Vehicle Code required.")

            'MessageBox.Show("This field is required.", lblVehicleCode.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RField")
            txtVehicleCode.Focus()
            Return False

        End If

        If Not _Val.RequiredFieldValidator(rbOperational.Checked, rbStandBy.Checked, rbBreakDown.Checked, rbFFBdeliverytoMill.Checked) Then
            'lsErrorMsg.Append(Environment.NewLine + "Status field is required.")
            'MessageBox.Show("This field is required.", lblStatus.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RField")
            rbOperational.Focus()
            'rbOperational.Checked = False
            Return False
        End If

        If rbBreakDown.Checked = False Then

           
            Select Case txtUOM.Text.Trim
                Case "Hrs"

                 

                    If txtStartMin.Text.Trim <> String.Empty And txtStartHr.Text.Trim = String.Empty Then
                        DisplayInfoMessage("RStartMtsSelect")
                        txtStartHr.Focus()
                        Return False
                    End If

                    If txtStartMin.Text.Trim = String.Empty And txtStartHr.Text.Trim <> String.Empty Then
                        DisplayInfoMessage("RStartHrsSelect")
                        txtStartMin.Focus()
                        Return False
                    End If

                    If txtEndMin.Text.Trim <> String.Empty And txtEndHr.Text.Trim = String.Empty Then
                        DisplayInfoMessage("REndMtsSelect")
                        txtEndHr.Focus()
                        Return False
                    End If

                    If txtEndMin.Text.Trim = String.Empty And txtEndHr.Text.Trim <> String.Empty Then
                        DisplayInfoMessage("REndHrsSelect")
                        txtEndMin.Focus()
                        Return False
                    End If

                    If txtStartMin.Text.Trim <> String.Empty Then
                        If txtStartHr.Text.Trim = String.Empty Then
                            DisplayInfoMessage("REndTimeSelect")
                            txtEndHr.Focus()
                            Return False
                        End If

                        If txtStartMin.Text.Trim = String.Empty Then
                            DisplayInfoMessage("REndTimeSelect")
                            txtEndMin.Focus()
                            Return False
                        End If
                    End If


                    If txtStartMin.Text.Trim <> String.Empty Then
                        If txtStartHr.Text.Trim = String.Empty Then
                            DisplayInfoMessage("RStartTimeSelect")
                            txtStartHr.Focus()
                            Return False
                        End If

                        If txtStartMin.Text.Trim = String.Empty Then
                            DisplayInfoMessage("RStartTimeSelect")
                            txtStartMin.Focus()
                            Return False
                        End If
                    End If

                    If txtTotalHours.Text.Trim = String.Empty Then
                        DisplayInfoMessage("RField")
                        txtTotalHours.Focus()
                        Return False
                    End If

                    Dim rtime As New System.Text.RegularExpressions.Regex("[0-9]:[0-5][0-9]$")
                    If Not rtime.IsMatch(txtTotalHours.Text.Trim) Then
                        DisplayInfoMessage("ITimeFormat")
                        txtTotalHours.Focus()
                        Return False
                    End If
                    'If lsStartTime = String.Empty Then

                    '    If txtStartHr.Text.Trim = String.Empty Then
                    '        'If cmbStartHrs.SelectedIndex = -1 Then
                    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")
                    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '        DisplayInfoMessage("RField")
                    '        txtStartHr.Focus()
                    '        'cmbStartHrs.Focus()
                    '        Return False
                    '    End If
                    '    If txtStartMin.Text.Trim = String.Empty Then
                    '        'If cmbStartMin.SelectedIndex = -1 Then
                    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")
                    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '        DisplayInfoMessage("RField")
                    '        txtStartMin.Focus()
                    '        'cmbStartMin.Focus()
                    '        Return False
                    '    End If

                    'End If

                    'If lsEndTime = String.Empty Then
                    '    If txtEndHr.Text.Trim = String.Empty Then
                    '        'If cmbEndHrs.SelectedIndex = -1 Then
                    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '        DisplayInfoMessage("RField")
                    '        txtEndHr.Focus()
                    '        'cmbEndHrs.Focus()
                    '        Return False
                    '    End If

                    '    If txtEndMin.Text.Trim = String.Empty Then
                    '        'If cmbEndMin.SelectedIndex = -1 Then
                    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")
                    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                    '        DisplayInfoMessage("RField")
                    '        txtEndMin.Focus()
                    '        ' cmbEndMin.Focus()
                    '        Return False
                    '    End If

                    '    ''lsErrorMsg.Append(Environment.NewLine + "End Time required.")

                    '    'MessageBox.Show("This field is required.", lblEndTime.Text, MessageBoxButtons.OK)
                    '    ''txtEndTime.Focus()
                    '    'cmbEndHrs.Focus()
                    '    'Return False

                    'End If

                Case "Kms"

                    If rbStandBy.Checked = False Then

                        If txtStartKms.Text = String.Empty Then
                            'lsErrorMsg.Append(Environment.NewLine + "Start Kms required.")

                            'MessageBox.Show("This field is required.", lblStartKms.Text, MessageBoxButtons.OK)
                            DisplayInfoMessage("RField")
                            txtStartKms.Focus()
                            Return False

                        End If

                        If txtEndKms.Text = String.Empty Then
                            'lsErrorMsg.Append(Environment.NewLine + "End Kms required.")

                            'MessageBox.Show("This field is required.", lblEndKms.Text, MessageBoxButtons.OK)
                            DisplayInfoMessage("RField")
                            txtEndKms.Focus()
                            Return False

                        End If

                    End If

                    If rbStandBy.Checked = True Then

                        If txtTotalHours.Text.Trim = String.Empty Then
                            DisplayInfoMessage("RField")
                            txtTotalHours.Focus()
                            Return False
                        End If

                        Dim rtime As New System.Text.RegularExpressions.Regex("[0-9]:[0-5][0-9]$")
                        If Not rtime.IsMatch(txtTotalHours.Text.Trim) Then
                            DisplayInfoMessage("ITimeFormat")
                            txtTotalHours.Focus()
                            Return False
                        End If
                        'If lsStartTime = String.Empty Then
                        '    If txtStartHr.Text.Trim = String.Empty Then
                        '        'If cmbStartHrs.SelectedIndex = -1 Then
                        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")
                        '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '        DisplayInfoMessage("RField")
                        '        txtStartHr.Focus()
                        '        'cmbStartHrs.Focus()
                        '        Return False
                        '    End If
                        '    If txtStartMin.Text.Trim = String.Empty Then
                        '        'If cmbStartMin.SelectedIndex = -1 Then
                        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")
                        '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '        DisplayInfoMessage("RField")
                        '        txtStartMin.Focus()
                        '        'cmbStartMin.Focus()
                        '        Return False
                        '    End If

                        'End If

                        'If lsEndTime = String.Empty Then
                        '    If txtEndHr.Text.Trim = String.Empty Then
                        '        'If cmbEndHrs.SelectedIndex = -1 Then
                        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                        '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '        DisplayInfoMessage("RField")
                        '        txtEndHr.Focus()
                        '        'cmbEndHrs.Focus()
                        '        Return False
                        '    End If

                        '    If txtEndMin.Text.Trim = String.Empty Then
                        '        'If cmbEndMin.SelectedIndex = -1 Then
                        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")
                        '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '        DisplayInfoMessage("RField")
                        '        txtEndMin.Focus()
                        '        ' cmbEndMin.Focus()
                        '        Return False
                        '    End If


                        '    '    If cmbStartHrs.SelectedIndex = -1 Then
                        '    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                        '    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '    '        DisplayInfoMessage("RField")
                        '    '        'txtStartTime.Focus()
                        '    '        cmbStartHrs.Focus()
                        '    '        Return False
                        '    '    End If

                        '    '    If cmbStartMin.SelectedIndex = -1 Then
                        '    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                        '    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '    '        DisplayInfoMessage("RField")
                        '    '        'txtStartTime.Focus()
                        '    '        cmbStartMin.Focus()
                        '    '        Return False
                        '    '    End If

                        '    'End If

                        '    'If lsEndTime = String.Empty Then

                        '    '    If cmbStartHrs.SelectedIndex = -1 Then
                        '    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                        '    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '    '        DisplayInfoMessage("RField")
                        '    '        'txtStartTime.Focus()
                        '    '        cmbEndHrs.Focus()
                        '    '        Return False
                        '    '    End If

                        '    '    If cmbStartMin.SelectedIndex = -1 Then
                        '    '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

                        '    '        'MessageBox.Show("This field is required.", lblStartTime.Text, MessageBoxButtons.OK)
                        '    '        DisplayInfoMessage("RField")
                        '    '        'txtStartTime.Focus()
                        '    '        cmbEndMin.Focus()
                        '    '        Return False
                        '    '    End If

                        '    '' ''lsErrorMsg.Append(Environment.NewLine + "End Time required.")

                        '    ' ''MessageBox.Show("This field is required.", lblEndTime.Text, MessageBoxButtons.OK)
                        '    '' ''txtEndTime.Focus()
                        '    ' ''cmbEndHrs.Focus()
                        '    ' ''Return False

                        'End If


                    End If


            End Select

            If lsStartTime = "00:00" Then
                DisplayInfoMessage("RTime")
                ' cmbStartMin.Focus()
                txtStartMin.Focus()
                Return False
            End If

        End If

       

        'If cmbStartMin.SelectedIndex > -1 And cmbStartHrs.SelectedIndex = -1 Then
        '    'MessageBox.Show("This field is required when Start Minutes selected.", "Start Hrs", MessageBoxButtons.OK)
        '    DisplayInfoMessage("RStartMtsSelect")
        '    cmbStartHrs.Focus()
        '    Return False
        'End If


        'If cmbStartHrs.SelectedIndex > -1 And cmbStartMin.SelectedIndex = -1 Then
        '    'MessageBox.Show("This field is required when Starting Hrs selected.", "Start Min", MessageBoxButtons.OK)
        '    DisplayInfoMessage("RStartHrsSelect")
        '    cmbStartMin.Focus()
        '    Return False
        'End If

        'If cmbEndMin.SelectedIndex > -1 And cmbEndHrs.SelectedIndex = -1 Then
        '    'MessageBox.Show("This field is required when End Minutes selected.", "End Hrs", MessageBoxButtons.OK)
        '    DisplayInfoMessage("REndMtsSelect")
        '    cmbEndHrs.Focus()
        '    Return False
        'End If

        'If cmbEndHrs.SelectedIndex > -1 And cmbEndMin.SelectedIndex = -1 Then
        '    'MessageBox.Show("This field is required when End Hrs selected.", "End Min", MessageBoxButtons.OK)
        '    DisplayInfoMessage("REndHrsSelect")
        '    cmbEndMin.Focus()
        '    Return False
        'End If

      

        'If cmbStartMin.SelectedIndex > -1 Then
        '    If cmbStartHrs.SelectedIndex = -1 Then
        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

        '        'MessageBox.Show("This field is required when End time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
        '        DisplayInfoMessage("REndTimeSelect")
        '        'txtStartTime.Focus()
        '        cmbEndHrs.Focus()
        '        Return False
        '    End If

        '    If cmbStartMin.SelectedIndex = -1 Then
        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

        '        'MessageBox.Show("This field is required when End time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
        '        DisplayInfoMessage("REndTimeSelect")
        '        'txtStartTime.Focus()
        '        cmbEndMin.Focus()
        '        Return False
        '    End If
        'End If

        'If cmbStartMin.SelectedIndex > -1 Then
        '    If cmbStartHrs.SelectedIndex = -1 Then
        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

        '        'MessageBox.Show("This field is required when Start time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
        '        DisplayInfoMessage("RStartTimeSelect")
        '        'txtStartTime.Focus()
        '        cmbStartHrs.Focus()
        '        Return False
        '    End If

        '    If cmbStartMin.SelectedIndex = -1 Then
        '        'lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

        '        'MessageBox.Show("This field is required when Start time is selected.", lblStartTime.Text, MessageBoxButtons.OK)
        '        DisplayInfoMessage("RStartTimeSelect")
        '        'txtStartTime.Focus()
        '        cmbStartMin.Focus()
        '        Return False
        '    End If
        'End If


        If lblDIV.ForeColor = Color.Red Then

            'If txtDIV.Text.Trim = String.Empty Then
            '    'lsErrorMsg.Append(Environment.NewLine + "DIV field is required.")

            '    MessageBox.Show("This field is required.", lblDIV.Text, MessageBoxButtons.OK)
            '    txtDIV.Focus()
            '    Return False

            'End If

            If txtSubBlock.Text.Trim = String.Empty Then
                'lsErrorMsg.Append(Environment.NewLine + "Sub-Block field is required.")

                'MessageBox.Show("This field is required.", lblSubBlock.Text, MessageBoxButtons.OK)
                DisplayInfoMessage("RField")
                txtSubBlock.Focus()
                Return False

            End If

        End If

        'To form an aline we placed here. since it is between If lblDIV.ForeColor = Color.Red Then
        If lblVehicleActivity.ForeColor = Color.Red Then
            If txtVehicleActivity.Text.Trim = String.Empty Then
                'lsErrorMsg.Append(Environment.NewLine + "Vehicle Activity field is required.")

                'MessageBox.Show("This field is required.", lblVehicleActivity.Text, MessageBoxButtons.OK)
                DisplayInfoMessage("RField")
                txtVehicleActivity.Focus()
                Return False

            End If
        End If

        'If lblDIV.ForeColor = Color.Red And rbFFBdeliverytoMill.Checked Then
        '    If txtBunches.Text.Trim = String.Empty Then
        '        'lsErrorMsg.Append(Environment.NewLine + "Bunches is required.")
        '        'MessageBox.Show("This field is required.", lblBunches.Text, MessageBoxButtons.OK)
        '        DisplayInfoMessage("RField")
        '        txtBunches.Focus()
        '        Return False
        '    End If
        '    If txtFFBDeliveryOrderNo.Text.Trim = String.Empty Then
        '        'lsErrorMsg.Append(Environment.NewLine + "FFB Delivery Order No field is required.")
        '        'MessageBox.Show("This field is required.", lblSerialNo.Text, MessageBoxButtons.OK)
        '        DisplayInfoMessage("RField")
        '        txtFFBDeliveryOrderNo.Focus()
        '        Return False
        '    End If
        ' End If
        Return True
    End Function

    'Function CheckRequiredFields() As Boolean

    '    _Val = New Validator
    '    Dim lsErrorMsg As System.Text.StringBuilder = New System.Text.StringBuilder

    '    If Not _Val.RequiredFieldValidator(txtVehicleCode.Text.Trim) Then
    '        lsErrorMsg.Append("Vehicle Code required.")
    '    End If

    '    If Not _Val.RequiredFieldValidator(rbOperational.Checked, rbStandBy.Checked, rbBreakDown.Checked) Then
    '        lsErrorMsg.Append(Environment.NewLine + "Status field is required.")
    '    End If

    '    If rbBreakDown.Checked = False Then

    '        Select Case txtUOM.Text.Trim
    '            Case "Hrs"

    '                If txtStartTime.Text = String.Empty Then
    '                    lsErrorMsg.Append(Environment.NewLine + "Start Time required.")

    '                End If

    '                If txtEndTime.Text = String.Empty Then
    '                    lsErrorMsg.Append(Environment.NewLine + "End Time required.")

    '                End If

    '            Case "Kms"

    '                If rbStandBy.Checked = False Then

    '                    If txtStartKms.Text = String.Empty Then
    '                        lsErrorMsg.Append(Environment.NewLine + "Start Kms required.")

    '                    End If

    '                    If txtEndKms.Text = String.Empty Then
    '                        lsErrorMsg.Append(Environment.NewLine + "End Kms required.")

    '                    End If

    '                End If

    '        End Select
    '    End If

    '    If lblDIV.ForeColor = Color.Red Then

    '        If txtDIV.Text.Trim = String.Empty Then
    '            lsErrorMsg.Append(Environment.NewLine + "DIV field is required.")
    '        End If

    '        If txtSubBlock.Text.Trim = String.Empty Then
    '            lsErrorMsg.Append(Environment.NewLine + "Sub-Block field is required.")
    '        End If

    '    End If

    '    'To form an aline we placed here. since it is between If lblDIV.ForeColor = Color.Red Then
    '    If lblVehicleActivity.ForeColor = Color.Red Then
    '        If txtVehicleActivity.Text.Trim = String.Empty Then
    '            lsErrorMsg.Append(Environment.NewLine + "Vehicle Activity field is required.")
    '        End If
    '    End If

    '    If lblDIV.ForeColor = Color.Red Then

    '        If txtBunches.Text.Trim = String.Empty Then
    '            lsErrorMsg.Append(Environment.NewLine + "Bunches is required.")
    '        End If

    '        If txtFFBDeliveryOrderNo.Text.Trim = String.Empty Then
    '            lsErrorMsg.Append(Environment.NewLine + "FFB Delivery Order No field is required.")
    '        End If

    '    End If


    '    If lsErrorMsg.Length = 0 Then
    '        Return True
    '    Else
    '        MsgBox(lsErrorMsg.ToString.TrimStart(Environment.NewLine))
    '        Return False
    '    End If

    'End Function

    'Function ValidMandatoryFileds() As Boolean

    '    Select Case General.IsVHWSCodeExist("V", txtVehicleCode.Text.Trim)
    '        Case 0
    '            MsgBox("Sorry, no such vehicle code exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '            Return False
    '            Exit Select
    '        Case 1
    '            MsgBox("This vehicle code does not belong to this estate.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '            Return False
    '            Exit Select
    '        Case 2
    '            Return True
    '            Exit Select
    '    End Select

    'End Function

    Function ValidDataType() As Boolean

        Dim lsErrorMsg As System.Text.StringBuilder = New System.Text.StringBuilder

        If (txtStartKms.Text.Trim <> String.Empty And Not IsNumeric(txtStartKms.Text.Trim)) Then
            'MsgBox("Please input valid number in start kms field.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("INumeric")
            txtStartKms.Focus()
            txtTotalKms.Text = String.Empty
            Return False

        End If

        If (txtEndKms.Text.Trim <> String.Empty And Not IsNumeric(txtEndKms.Text.Trim)) Then

            'MsgBox("Please input valid number in end kms field.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("INumeric")
            txtEndKms.Focus()
            txtTotalKms.Text = String.Empty
            Return False

        End If

        'Commented for 12 hrs format to 24 hrs format
        'If Not reValidateTime.IsMatch(lsStartTime.Trim) And lsStartTime.Trim <> String.Empty Then

        '    'MsgBox("Start Time - Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    MsgBox("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    'txtStartTime.Focus()
        '    cmbStartHrs.Focus()
        '    txtTotalHours.Text = String.Empty
        '    txtShift.Text = String.Empty
        '    Return False

        'End If

        'If Not reValidateTime.IsMatch(lsEndTime.Trim) And lsEndTime.Trim <> String.Empty Then

        '    'MsgBox("End Time - Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    MsgBox("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    'txtEndTime.Focus()
        '    cmbEndHrs.Focus()
        '    txtTotalHours.Text = String.Empty
        '    txtShift.Text = String.Empty
        '    Return False

        'End If

        'If txtBunches.Text.Trim <> String.Empty And Not IsNumeric(txtBunches.Text.Trim) Then
        '    'MsgBox("Bunche’s value should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    DisplayInfoMessage("INumeric")
        '    txtBunches.Focus()
        '    Return False
        '    'ElseIf Not reDecimalPlaces.IsMatch(txtBunches.Text.Trim) Then
        '    '    'ElseIf Not decimalNotEndsWithOPeriod.IsMatch(txtBunches.Text.Trim) Then
        '    '    lsMessage += "Bunches - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If

        'If txtActualBunchesMill.Text.Trim <> String.Empty And Not IsNumeric(txtActualBunchesMill.Text.Trim) Then
        '    'MsgBox("Actual bunches mill value should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    DisplayInfoMessage("INumeric")
        '    txtActualBunchesMill.Focus()
        '    Return False
        '    'ElseIf Not reDecimalPlaces.IsMatch(txtActualBunchesMill.Text.Trim) Then
        '    '    'ElseIf Not decimalNotEndsWithOPeriod.IsMatch(txtActualBunchesMill.Text.Trim) Then
        '    '    lsMessage += "Actual bunches mill - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If


        'If txtMillWeight.Text.Trim <> String.Empty And Not IsNumeric(txtMillWeight.Text.Trim) Then
        '    'MsgBox("Mill weight value should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    DisplayInfoMessage("INumeric")
        '    txtMillWeight.Focus()
        '    Return False
        '    'ElseIf Not reDecimalPlaces.IsMatch(txtMillWeight.Text.Trim) Then
        '    '    'ElseIf Not decimalNotEndsWithOPeriod.IsMatch(txtMillWeight.Text.Trim) Then
        '    '    lsMessage += "Mill weight - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If

        Return True

    End Function

    Function ValidDataTypeSize() As Boolean

        If txtStartKms.Text.Trim <> String.Empty And Not reDecimalPlaces.IsMatch(txtStartKms.Text.Trim) Then
            'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("IKmsFormat")
            'MsgBox("Start Kms - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            txtStartKms.Focus()
            Return False

        End If

        If txtEndKms.Text.Trim <> String.Empty And Not reDecimalPlaces.IsMatch(txtEndKms.Text.Trim) Then
            'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            DisplayInfoMessage("IKmsFormat")
            'MsgBox("End Kms - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            txtEndKms.Focus()
            Return False
        End If

        'If Not reDecimalPlaces.IsMatch(txtBunches.Text.Trim) Then
        '    'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    DisplayInfoMessage("IKmsFormat")
        '    'MsgBox("Bunches - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    txtBunches.Focus()
        '    Return False
        'End If

        'If Not reDecimalPlaces.IsMatch(txtActualBunchesMill.Text.Trim) Then
        '    'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    DisplayInfoMessage("IKmsFormat")
        '    'MsgBox("Actual bunches mill - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    txtActualBunchesMill.Focus()
        '    Return False
        'End If

        'If Not reDecimalPlaces.IsMatch(txtMillWeight.Text.Trim) Then
        '    'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    DisplayInfoMessage("IKmsFormat")
        '    'MsgBox("Mill weight - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    txtMillWeight.Focus()
        '    Return False
        'End If

        Return True

    End Function

    Function IsBothHrsAndKrsAreEqual() As Boolean

      
        'Dim rtime As New System.Text.RegularExpressions.Regex("[0-9][0-9][0-9]\:[0-5][0-9]")
        'If Not rtime.IsMatch(txtTotalHours.Text.Trim) Then
        '    Dim rtime1 As New System.Text.RegularExpressions.Regex("[0-9][0-9]\:[0-5][0-9]")
        '    If Not rtime1.IsMatch(txtTotalHours.Text.Trim) Then
        '        ' MessageBox.Show("Please provide the time in hh:mm format", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '        DisplayInfoMessage("ITotalHrs")
        '        txtTotalHours.Focus()
        '        Return False
        '    End If
        '    'End If
        'End If



        If txtStartKms.Text.Trim <> String.Empty And txtEndKms.Text.Trim <> String.Empty Then
            If txtStartKms.Text.Trim = txtEndKms.Text.Trim Then

                'MsgBox("Start kms value should not be equal to end kms value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IStartEndKmsEqual")
                txtTotalKms.Text = String.Empty
                txtEndKms.Focus()
                Return False

            ElseIf Convert.ToDecimal(txtStartKms.Text.Trim) > Convert.ToDecimal(txtEndKms.Text.Trim) Then

                'MsgBox("Start kms value should be less than end kms value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IStartEndKms")
                txtTotalKms.Text = String.Empty
                txtStartKms.Focus()
                Return False

            End If
        End If




        If lsStartTime.Trim <> String.Empty And lsEndTime.Trim <> String.Empty Then

            If DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) = DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
                'MsgBox("Start hrs value should not equlal to end hrs value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IStartEndHrsEqual")
                'txtTotalHours.Text = String.Empty
                'txtShift.Text = String.Empty
                'txtEndTime.Focus()
                'cmbStartHrs.Focus()
                txtStartHr.Focus()
                Return False
            ElseIf DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) > DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
                'MsgBox("Start hrs value should be less than end hrs value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                DisplayInfoMessage("IStartEndHrs")
                'txtTotalHours.Text = String.Empty
                'txtShift.Text = String.Empty
                'txtStartTime.Focus()
                'cmbStartHrs.Focus()
                txtStartHr.Focus()
                Return False
                ' Else
                'txtTotalHours.Text = Convert.ToString(DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)

                ''Dim lsMeridian As String = DateTime.ParseExact(lsStartTime, "HHmmtt", Globalization.CultureInfo.InvariantCulture)

                ''Select Case lsMeridian.Trim.Substring(lsMeridian.Trim.Length - 2, 2).ToLower
                ''    Case "am"
                ''        txtShift.Text = "Morning"
                ''        Exit Select
                ''    Case "pm"
                ''        txtShift.Text = "Afternoon"
                ''        Exit Select
                ''End Select
            End If
        Else 'Called when clearing any of the start and end of text box
            'txtTotalHours.Text = String.Empty
            txtShift.Text = String.Empty
        End If


        Return True

    End Function

    'Function ValidatePrimaryKeyFields() As Boolean
    '    If txtContractNo.Text.Trim <> String.Empty Then
    '        'Select Case ValidateDivYopSubBlockAndContractNumber("ContractNumber", txtContactNo.Text.Trim)
    '        Select Case General.ValidateForeignKeyFields("ContractNumber", txtContractNo.Text.Trim)

    '            Case 0
    '                txtContractNo.Focus()
    '                MsgBox("Sorry, no such Contract number value does not exist in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return False

    '                'cURRENTLY COMMENTED
    '            Case 1
    '                txtContractNo.Focus()
    '                MsgBox("Sorry, this contract number value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                Return False
    '            Case 2

    '                ''Case False
    '                ''    MsgBox("Contract number value does not exist in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                ''    txtContractNo.Focus()
    '                ''    Return False
    '        End Select
    '    End If

    '    If ddlLocation.SelectedIndex = 0 Or ddlLocation.SelectedIndex = -1 Then
    '        If txtDIV.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("Division", txtDIV.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("Division", txtDIV.Text.Trim)
    '                'Case False
    '                '    MsgBox("Sorry, no such DIV value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                '    txtDIV.Focus()
    '                '    Return False

    '                Case 0
    '                    txtDIV.Focus()
    '                    MsgBox("Sorry, no such DIV value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    Return False
    '                    'Case 1
    '                    '    txtDIV.Focus()
    '                    '    MsgBox("Sorry, this DIV value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    '    Return False

    '            End Select
    '        End If

    '        If txtYOP.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("YOP", txtYOP.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("YOP", txtYOP.Text.Trim)
    '                'Case False
    '                '    MsgBox("Sorry, no such YOP value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                '    txtYOP.Focus()
    '                '    Return False

    '                Case 0
    '                    txtYOP.Focus()
    '                    MsgBox("Sorry, no such YOP value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    Return False
    '                Case 1
    '                    txtYOP.Focus()
    '                    MsgBox("Sorry, this YOP value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    Return False

    '                Case 2

    '                    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
    '                    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL

    '                    _SearchCodePPT.psSearchBy = "YOP"

    '                    _SearchCodePPT.psYOPCode = txtYOP.Text.Trim

    '                    If txtDIV.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
    '                    End If

    '                    _SearchCodePPT.psSearchTerm = "OnGo"
    '                    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '                    Dim dtSearchCode As DataTable = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)

    '                    'If _SearchCodeCollection.Count = 0 And txtDIV.Text.Trim = String.Empty Then
    '                    '    MsgBox("Sorry, no such YOP value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    '    txtYOP.Focus()
    '                    '    Return False
    '                    'End If

    '                    If dtSearchCode.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty Then
    '                        txtYOP.Focus()
    '                        MsgBox("Sorry YOP value does not correspond with the DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        Return False
    '                    End If

    '            End Select
    '        End If

    '        If txtSubBlock.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("Sub-Block", txtSubBlock.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("Sub-Block", txtSubBlock.Text.Trim)
    '                'Case False
    '                '    MsgBox("Sorry, no such Sub-Block value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                '    txtSubBlock.Focus()
    '                '    Return False

    '                Case 0
    '                    txtSubBlock.Focus()
    '                    MsgBox("Sorry, no such Sub-Block value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    Return False
    '                Case 1
    '                    txtSubBlock.Focus()
    '                    MsgBox("Sorry, this Sub-Block value does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    Return False
    '                Case 2

    '                    '  Dim dsSubBlockCodeAndName As DataSet
    '                    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
    '                    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
    '                    Dim dtSearchCode As DataTable

    '                    If txtDIV.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
    '                    End If

    '                    If txtYOP.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psYOPCode = txtYOP.Text.Trim
    '                    End If

    '                    _SearchCodePPT.psSubBlockCode = txtSubBlock.Text.Trim
    '                    _SearchCodePPT.psSearchTerm = "OnGo"
    '                    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '                    dtSearchCode = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)

    '                    If dtSearchCode.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim <> String.Empty Then
    '                        MsgBox("Sub-Block value does not correspond with the YOP and DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()
    '                        Return False
    '                    ElseIf dtSearchCode.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty And txtYOP.Text.Trim <> String.Empty Then
    '                        txtSubBlock.Focus()
    '                        MsgBox("Sub-Block value does not correspond with the YOP value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        Return False
    '                    ElseIf dtSearchCode.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim = String.Empty Then
    '                        txtSubBlock.Focus()
    '                        MsgBox("Sub-Block value does not correspond with the DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        Return False
    '                    End If

    '            End Select
    '        End If
    '    End If

    '    Return True

    'End Function

    'Function ValidatePrimaryKeyFields() As Boolean
    '    If txtContractNo.Text.Trim <> String.Empty Then
    '        'Select Case ValidateDivYopSubBlockAndContractNumber("ContractNumber", txtContactNo.Text.Trim)
    '        Select Case General.ValidateForeignKeyFields("ContractNumber", txtContractNo.Text.Trim)
    '            Case False
    '                MsgBox("Contract number value does not exist in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                txtContractNo.Focus()
    '                Return False
    '        End Select
    '    End If

    '    If ddlLocation.SelectedIndex = 0 Or ddlLocation.SelectedIndex = -1 Then
    '        If txtDIV.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("Division", txtDIV.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("Division", txtDIV.Text.Trim)
    '                Case False
    '                    MsgBox("Sorry, no such DIV value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    txtDIV.Focus()
    '                    Return False
    '            End Select
    '        End If

    '        If txtYOP.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("YOP", txtYOP.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("YOP", txtYOP.Text.Trim)
    '                Case False
    '                    MsgBox("Sorry, no such YOP value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    txtYOP.Focus()
    '                    Return False
    '                Case True

    '                    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
    '                    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
    '                    Dim dtYop As DataTable

    '                    _SearchCodePPT.psSearchBy = "YOP"

    '                    _SearchCodePPT.psYOPCode = txtYOP.Text.Trim

    '                    If txtDIV.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
    '                    End If

    '                    _SearchCodePPT.psSearchTerm = "OnGo"
    '                    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '                    dtYop = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)

    '                    If dtYop.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty Then
    '                        MsgBox("Sorry, no such YOP value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtYOP.Focus()
    '                        Return False
    '                    End If

    '                    If dtYop.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty Then
    '                        MsgBox("YOP value does not correspond with the DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtYOP.Focus()
    '                        Return False
    '                    End If

    '            End Select
    '        End If

    '        If txtSubBlock.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("Sub-Block", txtSubBlock.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("Sub-Block", txtSubBlock.Text.Trim)
    '                Case False
    '                    MsgBox("Sorry, no such Sub-Block value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    txtSubBlock.Focus()
    '                    Return False
    '                Case True

    '                    '  Dim dsSubBlockCodeAndName As DataSet
    '                    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
    '                    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
    '                    Dim dtSubBlock As DataTable

    '                    If txtDIV.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
    '                    End If

    '                    If txtYOP.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psYOPCode = txtYOP.Text.Trim
    '                    End If

    '                    _SearchCodePPT.psSubBlockCode = txtSubBlock.Text.Trim
    '                    _SearchCodePPT.psSearchTerm = "OnGo"
    '                    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '                    dtSubBlock = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)

    '                    If dtSubBlock.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim <> String.Empty Then
    '                        MsgBox("Sub-Block value does not correspond with the YOP and DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()
    '                        Return False
    '                    ElseIf dtSubBlock.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty And txtYOP.Text.Trim <> String.Empty Then
    '                        MsgBox("Sub-Block value does not correspond with the YOP value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()
    '                        Return False
    '                    ElseIf dtSubBlock.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim = String.Empty Then

    '                        MsgBox("Sub-Block value does not correspond with the DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()
    '                        Return False
    '                    End If

    '            End Select
    '        End If
    '    End If

    '    Return True

    'End Function

    Function IsFieldsRequiredWhenItsPairIsNotEmpty() As Boolean

        If txtStartKms.Text.Trim = String.Empty And txtEndKms.Text.Trim <> String.Empty Then
            'MsgBox("Start kms required when end kms is filled.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")

            'MessageBox.Show("Start kms required when end kms is filled.", lblStartKms.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RStartKm")

            txtStartKms.Focus()
            Return False
        End If

        If txtStartKms.Text.Trim <> String.Empty And txtEndKms.Text.Trim = String.Empty Then
            ''MsgBox("End kms required when start kms is filled.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")

            'MessageBox.Show("End kms required when start kms is filled.", lblEndKms.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("REndKm")

            txtEndKms.Focus()
            Return False
        End If

        If lsStartTime.Trim = String.Empty And lsEndTime.Trim <> String.Empty Then
            'MsgBox("Start time required when end time is filled.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MessageBox.Show("Start time required when end time is filled.", lblStartTime.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RStartHr")

            'txtStartTime.Focus()
            'cmbStartHrs.Focus()
            txtStartHr.Focus()
            Return False
        End If

        If lsStartTime.Trim <> String.Empty And lsEndTime.Trim = String.Empty Then
            'MsgBox("End time required when start time is filled.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MessageBox.Show("End time required when start time is filled.", lblEndTime.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("REndHr")

            'txtEndTime.Focus()
            'cmbEndHrs.Focus()
            txtEndMin.Focus()

            Return False
        End If

        Return True

    End Function

    'Function IsFieldsValueGreateThanItsPair() As Boolean

    '    Select Case btnSaveOrUpdate.Text
    '        Case "Save"

    '            Select Case txtUOM.Text.Trim
    '                Case "Hrs"

    '                    If txtTotalHours.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then
    '                        Dim ldBatchValue As TimeSpan = General.GetInTimeFormat(Convert.ToString(Convert.ToDecimal(txtBatchValue.Text.Trim)).Replace(".", ":"))
    '                        Dim ldCurrentValue As TimeSpan = General.GetInTimeFormat(txtTotalHours.Text.Trim).Add(ltsOutstandingHrs)
    '                        '                            MsgBox(Convert.ToString(ldCurrentValue))
    '                        'MsgBox(Convert.ToString(ldBatchValue))
    '                        If ldCurrentValue > ldBatchValue Then
    '                            lsMessage += "Total hrs (TotalHrs) entered is greater than batch value." & vbCrLf
    '                            txtStartTime.Focus()
    '                        End If
    '                    End If
    '                    Exit Select
    '                Case "Kms"

    '                    If txtTotalKms.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then
    '                        If (ldOutstandingKms + Convert.ToDecimal(txtTotalKms.Text.Trim)) > Convert.ToDecimal(txtBatchValue.Text.Trim) Then
    '                            lsMessage += "Total kms (TotalKms) entered is greater than batch value." & vbCrLf
    '                            txtStartKms.Focus()
    '                        End If
    '                    End If
    '                    Exit Select
    '            End Select

    '            Exit Select
    '        Case "Update"

    '            Select Case txtUOM.Text.Trim
    '                Case "Hrs"
    '                    'Add current modified time - previous added time
    '                    If txtTotalHours.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then

    '                        Dim ldOutstanding_time As TimeSpan = ltsOutstandingHrs.Subtract(ldOldHrs).Add(General.GetInTimeFormat(txtTotalHours.Text.Trim))
    '                        Dim ldTotal_time As TimeSpan = General.GetInTimeFormat(Convert.ToString(Convert.ToDecimal(txtBatchValue.Text.Trim)).Replace(".", ":"))

    '                        'If ltsOutstandingHrs.Subtract(ldOldHrs).Add(General.GetInTimeFormat(txtTotalHours.Text.Trim).Subtract(ltsOutstandingHrs)) > General.GetInTimeFormat(Convert.ToString(Convert.ToDecimal(txtBatchValue.Text.Trim)).Replace(".", ":")) Then
    '                        If ldOutstanding_time > ldTotal_time Then
    '                            lsMessage += "Total hrs (TotalHrs) entered is greater than batch value." & vbCrLf
    '                            txtStartTime.Focus()
    '                        End If
    '                    End If
    '                    Exit Select
    '                Case "Kms"
    '                    If txtTotalKms.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then
    '                        If (ldOutstandingKms - ldOldKms + Convert.ToDecimal(txtTotalKms.Text.Trim)) > Convert.ToDecimal(txtBatchValue.Text.Trim) Then
    '                            lsMessage += "Total kms (TotalKms) entered is greater than batch value." & vbCrLf
    '                            txtStartKms.Focus()
    '                        End If
    '                    End If
    '                    Exit Select
    '            End Select

    '            Exit Select
    '    End Select

    '    Return True
    'End Function

    Function IsFieldsValid() As Boolean
        lsMessage = String.Empty
        Dim lsIsValidTime As String = String.Empty
        Dim lsValidKms As String = String.Empty
        _Val = New Validator
        ' Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")

        'If txtContractNo.Text.Trim <> String.Empty Then
        '    'Select Case ValidateDivYopSubBlockAndContractNumber("ContractNumber", txtContactNo.Text.Trim)
        '    Select Case General.ValidateForeignKeyFields("ContractNumber", txtContractNo.Text.Trim)
        '        Case False
        '            lsMessage += "Contract number value does not exist in the database." & vbCrLf
        '            Exit Select
        '    End Select
        'End If

        ' '' '' ''Select Case btnSaveOrUpdate.Text
        ' '' '' ''    Case "Save"

        ' '' '' ''        Select Case txtUOM.Text.Trim
        ' '' '' ''            Case "Hrs"

        ' '' '' ''                If txtTotalHours.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then
        ' '' '' ''                    Dim ldBatchValue As TimeSpan = General.GetInTimeFormat(Convert.ToString(Convert.ToDecimal(txtBatchValue.Text.Trim)).Replace(".", ":"))
        ' '' '' ''                    Dim ldCurrentValue As TimeSpan = General.GetInTimeFormat(txtTotalHours.Text.Trim).Add(ltsOutstandingHrs)
        ' '' '' ''                    '                            MsgBox(Convert.ToString(ldCurrentValue))
        ' '' '' ''                    'MsgBox(Convert.ToString(ldBatchValue))
        ' '' '' ''                    If ldCurrentValue > ldBatchValue Then
        ' '' '' ''                        lsMessage += "Total hrs (TotalHrs) entered is greater than batch value." & vbCrLf
        ' '' '' ''                        txtStartTime.Focus()
        ' '' '' ''                    End If
        ' '' '' ''                End If
        ' '' '' ''                Exit Select
        ' '' '' ''            Case "Kms"

        ' '' '' ''                If txtTotalKms.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then
        ' '' '' ''                    If (ldOutstandingKms + Convert.ToDecimal(txtTotalKms.Text.Trim)) > Convert.ToDecimal(txtBatchValue.Text.Trim) Then
        ' '' '' ''                        lsMessage += "Total kms (TotalKms) entered is greater than batch value." & vbCrLf
        ' '' '' ''                        txtStartKms.Focus()
        ' '' '' ''                    End If
        ' '' '' ''                End If
        ' '' '' ''                Exit Select
        ' '' '' ''        End Select

        ' '' '' ''        Exit Select
        ' '' '' ''    Case "Update"

        ' '' '' ''        Select Case txtUOM.Text.Trim
        ' '' '' ''            Case "Hrs"
        ' '' '' ''                'Add current modified time with OutstandingHrs - previous added time
        ' '' '' ''                If txtTotalHours.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then

        ' '' '' ''                    'MsgBox(ltsOutstandingHrs)
        ' '' '' ''                    'MsgBox(ldOldHrs)
        ' '' '' ''                    'MsgBox(General.GetInTimeFormat(txtTotalHours.Text.Trim))

        ' '' '' ''                    Dim ldOutstanding_time As TimeSpan = ltsOutstandingHrs.Subtract(ldOldHrs).Add(General.GetInTimeFormat(txtTotalHours.Text.Trim))
        ' '' '' ''                    Dim ldTotal_time As TimeSpan = General.GetInTimeFormat(Convert.ToString(Convert.ToDecimal(txtBatchValue.Text.Trim)).Replace(".", ":"))

        ' '' '' ''                    'If ltsOutstandingHrs.Subtract(ldOldHrs).Add(General.GetInTimeFormat(txtTotalHours.Text.Trim).Subtract(ltsOutstandingHrs)) > General.GetInTimeFormat(Convert.ToString(Convert.ToDecimal(txtBatchValue.Text.Trim)).Replace(".", ":")) Then
        ' '' '' ''                    If ldOutstanding_time > ldTotal_time Then
        ' '' '' ''                        lsMessage += "Total hrs (TotalHrs) entered is greater than batch value." & vbCrLf
        ' '' '' ''                        txtStartTime.Focus()
        ' '' '' ''                    End If
        ' '' '' ''                End If
        ' '' '' ''                Exit Select
        ' '' '' ''            Case "Kms"
        ' '' '' ''                If txtTotalKms.Text.Trim <> String.Empty And txtBatchValue.Text.Trim <> String.Empty Then
        ' '' '' ''                    If (ldOutstandingKms - ldOldKms + Convert.ToDecimal(txtTotalKms.Text.Trim)) > Convert.ToDecimal(txtBatchValue.Text.Trim) Then
        ' '' '' ''                        lsMessage += "Total kms (TotalKms) entered is greater than batch value." & vbCrLf
        ' '' '' ''                        txtStartKms.Focus()
        ' '' '' ''                    End If
        ' '' '' ''                End If
        ' '' '' ''                Exit Select
        ' '' '' ''        End Select

        ' '' '' ''        Exit Select
        ' '' '' ''End Select

        ''Changed
        'If (txtStartKms.Text.Trim <> String.Empty And Not IsNumeric(txtStartKms.Text.Trim)) Then
        '    lsValidKms += "Please input valid number in start kms field." & vbCrLf
        '    txtTotalKms.Text = String.Empty
        'End If

        'If (txtEndKms.Text.Trim <> String.Empty And Not IsNumeric(txtEndKms.Text.Trim)) Then
        '    lsValidKms += "Please input valid number in end kms field." & vbCrLf
        '    txtTotalKms.Text = String.Empty
        'End If


        'If lsValidKms = String.Empty Then

        'If txtStartKms.Text.Trim <> String.Empty And Not reDecimalPlaces.IsMatch(txtStartKms.Text.Trim) Then
        '    'If Not decimalNotEndsWithOPeriod.IsMatch(txtStartKms.Text.Trim) Then
        '    lsMessage += "Start Kms - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If

        'If txtEndKms.Text.Trim <> String.Empty And Not reDecimalPlaces.IsMatch(txtEndKms.Text.Trim) Then
        '    'If Not decimalNotEndsWithOPeriod.IsMatch(txtEndKms.Text.Trim) Then
        '    lsMessage += "End Kms - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If

        'If txtStartKms.Text.Trim <> String.Empty And txtEndKms.Text.Trim <> String.Empty Then
        '    If txtStartKms.Text.Trim = txtEndKms.Text.Trim Then
        '        lsMessage += "Start kms value should not be equal to end kms value." & vbCrLf
        '    ElseIf Convert.ToDecimal(txtStartKms.Text.Trim) > Convert.ToDecimal(txtEndKms.Text.Trim) Then
        '        lsMessage += "Start kms value should be less than end kms value." & vbCrLf
        '    End If
        'End If

        'Else
        '    lsMessage += lsValidKms
        'End If

        'If lsValidKms = String.Empty Then
        '    If txtStartKms.Text.Trim <> String.Empty Then
        '        If Convert.ToDecimal(txtStartKms.Text.Trim) < Convert.ToDecimal(txtEndKms.Text.Trim) Then
        '            'If txtStartKms.Text.Trim <> txtEndKms.Text.Trim Then
        '            If Not reDecimalPlaces.IsMatch(txtStartKms.Text.Trim) Then
        '                'If Not decimalNotEndsWithOPeriod.IsMatch(txtStartKms.Text.Trim) Then
        '                lsMessage += "Start Kms - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        '            End If

        '            If Not reDecimalPlaces.IsMatch(txtEndKms.Text.Trim) Then
        '                'If Not decimalNotEndsWithOPeriod.IsMatch(txtEndKms.Text.Trim) Then
        '                lsMessage += "End Kms - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        '            End If
        '        ElseIf txtStartKms.Text.Trim = txtEndKms.Text.Trim Then
        '            lsMessage += "Start Kms value should not be equal to End Kms value." & vbCrLf
        '        ElseIf Convert.ToDecimal(txtStartKms.Text.Trim) > Convert.ToDecimal(txtEndKms.Text.Trim) Then
        '            lsMessage += "Start Kms value should be less than End Kms value." & vbCrLf
        '        End If
        '    End If

        'Else
        '    lsMessage += lsValidKms
        'End If


        'Dim Expression As New System.Text.RegularExpressions.Regex("^ *(1[0-2]|[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$")

        'Change
        'If Not reValidateTime.IsMatch(lsStartTime.Trim) And lsStartTime.Trim <> String.Empty Then
        '    lsIsValidTime += "Start Time - Invalid time format. Please input time in HH:MMam/pm [12hrs] format." & vbCrLf
        '    txtTotalHours.Text = String.Empty
        '    txtShift.Text = String.Empty
        'End If

        'If Not reValidateTime.IsMatch(lsEndTime.Trim) And txtEndTime.Text.Trim <> String.Empty Then
        '    lsIsValidTime += "End Time - Invalid time format. Please input time in HH:MMam/pm [12hrs] format." & vbCrLf
        '    txtTotalHours.Text = String.Empty
        '    txtShift.Text = String.Empty
        'End If




        'If lsIsValidTime = String.Empty Then
        '    If lsStartTime.Trim <> String.Empty And txtEndTime.Text.Trim <> String.Empty Then

        '        'Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)

        '        If DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) = DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
        '            lsMessage += "Start hrs value should not equlal to end hrs value." & vbCrLf
        '            txtTotalHours.Text = String.Empty
        '            txtShift.Text = String.Empty
        '        ElseIf DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) > DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
        '            lsMessage += "Start hrs value should be less than end hrs value." & vbCrLf
        '            txtTotalHours.Text = String.Empty
        '            txtShift.Text = String.Empty
        '        Else
        '            txtTotalHours.Text = Convert.ToString(DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
        '            Select Case lsStartTime.Trim.Substring(lsStartTime.Trim.Length - 2, 2).ToLower
        '                Case "am"
        '                    txtShift.Text = "Morning"
        '                    Exit Select
        '                Case "pm"
        '                    txtShift.Text = "Afternoon"
        '                    Exit Select
        '            End Select
        '        End If
        '    Else
        '        txtTotalHours.Text = String.Empty
        '        txtShift.Text = String.Empty
        '    End If
        'Else
        '    txtTotalHours.Text = String.Empty
        '    txtShift.Text = String.Empty
        '    lsMessage += lsIsValidTime
        'End If




        'If lsIsValidTime = String.Empty Then
        '    If lsStartTime.Trim <> String.Empty Then

        '        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        '        'Dim Expression As New System.Text.RegularExpressions.Regex("^ *(1[0-2]|[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$")


        '        If reValidateTime.IsMatch(lsStartTime.Trim) Then

        '            If lsStartTime.Trim <> String.Empty And txtEndTime.Text.Trim <> String.Empty Then

        '                If lsStartTime.Trim <> txtEndTime.Text.Trim Then

        '                    If DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) <= DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
        '                        lsMessage += "Start Hrs value should be less than End Hrs value." & vbCrLf

        '                    Else
        '                        txtTotalHours.Text = Convert.ToString(DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
        '                        Select Case lsStartTime.Trim.Substring(lsStartTime.Trim.Length - 2, 2).ToLower
        '                            Case "am"
        '                                txtShift.Text = "Morning"
        '                                Exit Select
        '                            Case "pm"
        '                                txtShift.Text = "Afternoon"
        '                                Exit Select
        '                        End Select
        '                    End If
        '                Else
        '                    lsMessage += "Start Hrs value should not equlal to End Hrs value." & vbCrLf
        '                End If
        '            End If
        '        Else


        '            lsMessage += "Start Time - Invalid time format.Please input time in HH:MMam/pm format.." & vbCrLf

        '        End If
        '    End If


        '    If txtEndTime.Text.Trim <> String.Empty Then

        '        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        '        'Dim Expression As New System.Text.RegularExpressions.Regex("^ *(1[0-2]|[1-9]):[0-5][0-9] *(a|p|A|P)(m|M) *$")

        '        'Dim Expression As New System.Text.RegularExpressions.Regex("^([ 01]?[0-9]|2[0-3])(:([0-5][0-9])) *(a|p|A|P)(m|M) *$")

        '        If reValidateTime.IsMatch(txtEndTime.Text.Trim) Then

        '            If Not lsMessage.Contains("Start Hrs value should not equlal to End Hrs value.") Then
        '                If lsStartTime.Trim <> String.Empty And txtEndTime.Text.Trim <> String.Empty Then
        '                    If DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) <= DateTime.Parse(txtStartTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then
        '                        If Not lsMessage.Contains("Start Hrs value should be less than End Hrs value.") Then
        '                            lsMessage += "Start Hrs value should be less than End Hrs value." & vbCrLf
        '                        End If
        '                    Else
        '                        txtTotalHours.Text = Convert.ToString(DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(txtStartTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
        '                        Select Case txtStartTime.Text.Trim.Substring(txtStartTime.Text.Trim.Length - 2, 2).ToLower
        '                            Case "am"
        '                                txtShift.Text = "Morning"
        '                                Exit Select
        '                            Case "pm"
        '                                txtShift.Text = "Afternoon"
        '                                Exit Select
        '                        End Select
        '                    End If
        '                End If
        '            End If
        '        Else

        '            lsMessage += "End Time - Invalid time format.Please input time in HH:MMam/pm format.." & vbCrLf

        '        End If
        '    End If
        'Else
        '    lsMessage += lsIsValidTime
        'End If


        ''Change
        'If ddlLocation.SelectedIndex = 0 Or ddlLocation.SelectedIndex = -1 Then
        '    If txtDIV.Text.Trim <> String.Empty Then
        '        'Select Case ValidateDivYopSubBlockAndContractNumber("Division", txtDIV.Text.Trim)
        '        Select Case General.ValidateForeignKeyFields("Division", txtDIV.Text.Trim)
        '            Case False
        '                lsMessage += "Sorry, no such DIV value exists in the database." & vbCrLf
        '                Exit Select
        '        End Select
        '    End If

        '    If txtYOP.Text.Trim <> String.Empty Then
        '        'Select Case ValidateDivYopSubBlockAndContractNumber("YOP", txtYOP.Text.Trim)
        '        Select Case General.ValidateForeignKeyFields("YOP", txtYOP.Text.Trim)
        '            Case False
        '                lsMessage += "Sorry, no such YOP value exists in the database." & vbCrLf
        '                Exit Select
        '            Case True

        '                Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
        '                Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
        '                Dim _SearchCodeCollection As SearchCodeCollection

        '                _SearchCodePPT.psSearchBy = "YOP"

        '                _SearchCodePPT.psYOPCode = txtYOP.Text.Trim

        '                If txtDIV.Text.Trim <> String.Empty Then
        '                    _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
        '                End If

        '                _SearchCodePPT.psSearchTerm = "OnGo"
        '                _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        '                _SearchCodeCollection = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)

        '                If _SearchCodeCollection.Count = 0 And txtDIV.Text.Trim = String.Empty Then
        '                    lsMessage += "Sorry, no such YOP value exists in the database." & vbCrLf
        '                ElseIf _SearchCodeCollection.Count = 0 And txtDIV.Text.Trim <> String.Empty Then
        '                    lsMessage += "YOP value does not correspond with the DIV value." & vbCrLf
        '                End If
        '                Exit Select

        '        End Select
        '    End If

        '    If txtSubBlock.Text.Trim <> String.Empty Then
        '        'Select Case ValidateDivYopSubBlockAndContractNumber("Sub-Block", txtSubBlock.Text.Trim)
        '        Select Case General.ValidateForeignKeyFields("Sub-Block", txtSubBlock.Text.Trim)
        '            Case False
        '                lsMessage += "Sorry, no such Sub-Block value exists in the database." & vbCrLf
        '                Exit Select
        '            Case True

        '                '  Dim dsSubBlockCodeAndName As DataSet
        '                Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
        '                Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
        '                Dim _SearchCodeCollection As SearchCodeCollection

        '                If txtDIV.Text.Trim <> String.Empty Then
        '                    _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
        '                End If

        '                If txtYOP.Text.Trim <> String.Empty Then
        '                    _SearchCodePPT.psYOPCode = txtYOP.Text.Trim
        '                End If

        '                _SearchCodePPT.psSubBlockCode = txtSubBlock.Text.Trim
        '                _SearchCodePPT.psSearchTerm = "OnGo"
        '                _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

        '                _SearchCodeCollection = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)

        '                If _SearchCodeCollection.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim <> String.Empty Then
        '                    lsMessage += "Sub-Block value does not correspond with the YOP and DIV value." & vbCrLf
        '                ElseIf _SearchCodeCollection.Count = 0 And txtDIV.Text.Trim = String.Empty And txtYOP.Text.Trim <> String.Empty Then
        '                    lsMessage += "Sub-Block value does not correspond with the YOP and DIV value." & vbCrLf
        '                ElseIf _SearchCodeCollection.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim = String.Empty Then
        '                    lsMessage += "Sub-Block value does not correspond with the DIV value." & vbCrLf
        '                End If
        '                Exit Select

        '        End Select
        '    End If
        'End If

        'If txtBunches.Text.Trim <> String.Empty And Not IsNumeric(txtBunches.Text.Trim) Then
        '    lsMessage += "Bunche’s value should be numeric." & vbCrLf
        'ElseIf Not reDecimalPlaces.IsMatch(txtBunches.Text.Trim) Then
        '    'ElseIf Not decimalNotEndsWithOPeriod.IsMatch(txtBunches.Text.Trim) Then
        '    lsMessage += "Bunches - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If

        'If txtActualBunchesMill.Text.Trim <> String.Empty And Not IsNumeric(txtActualBunchesMill.Text.Trim) Then
        '    lsMessage += "Actual bunches mill value should be numeric." & vbCrLf
        'ElseIf Not reDecimalPlaces.IsMatch(txtActualBunchesMill.Text.Trim) Then
        '    'ElseIf Not decimalNotEndsWithOPeriod.IsMatch(txtActualBunchesMill.Text.Trim) Then
        '    lsMessage += "Actual bunches mill - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If


        'If txtMillWeight.Text.Trim <> String.Empty And Not IsNumeric(txtMillWeight.Text.Trim) Then
        '    lsMessage += "Mill weight value should be numeric." & vbCrLf
        'ElseIf Not reDecimalPlaces.IsMatch(txtMillWeight.Text.Trim) Then
        '    'ElseIf Not decimalNotEndsWithOPeriod.IsMatch(txtMillWeight.Text.Trim) Then
        '    lsMessage += "Mill weight - Please check that the precedence is 16 digits and the decimal is 2 digits." & vbCrLf
        'End If

        If lsMessage <> String.Empty Then
            MsgBox(lsMessage, Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            Return False
        Else
            Return True
        End If

    End Function

    'Function IsBathcValieRequired() As Boolean

    '    If txtBatchValue.Text.Trim = String.Empty Then
    '        MsgBox("Please input batch value in vehicle running batch screen.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        Return False
    '    End If

    '    Return True

    'End Function

    'Function ValidateDivYopSubBlockAndContractNumber(ByVal lsFileldName As String, ByVal lsFieldValue As String) As Boolean

    '    Dim isValid As Boolean

    '    isValid = True

    '    Dim objWorshopLogProp As clsWorshopLogProp
    '    objWorshopLogProp = New clsWorshopLogProp
    '    objWorshopLogProp.psEstateID = GlobalPPT.strEstateID
    '    objWorshopLogProp.psFieldName = lsFileldName
    '    objWorshopLogProp.psFieldValue = lsFieldValue
    '    Select Case objWorshopLogProp.GetIsValidKey(objWorshopLogProp)
    '        Case 0
    '            isValid = False
    '    End Select

    '    Return isValid

    'End Function

    Private Function AssignControlsValuesToPropertiesAndSave(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Boolean

        Dim liMessageValue As Integer
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        '_VehicleRunningLogPPT.pdLogDate = New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)
        '_VehicleRunningLogPPT.psVHWSCode = txtVehicleCode.Text.Trim

        'If txtBatchValue.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piBatchValue = Convert.ToDecimal(txtBatchValue.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piBatchValue = 0D
        'End If

        '_VehicleRunningLogPPT.piContractNumber = txtContractNo.Text.Trim

        'If ddlLocation.SelectedIndex > 0 Then
        '    _VehicleRunningLogPPT.psDistributionSetupID = ddlLocation.SelectedValue
        'End If

        'If rbBreakDown.Checked Then
        '    _VehicleRunningLogPPT.pcStatus = "B"
        'ElseIf rbOperational.Checked Then
        '    _VehicleRunningLogPPT.pcStatus = "O"
        'ElseIf rbStandBy.Checked Then
        '    _VehicleRunningLogPPT.pcStatus = "S"
        'End If

        SaveOrUpdateDefaultValueAssignment(_VehicleRunningLogPPT)


        Select Case (_VehicleRunningLogPPT.pcStatus).ToString.ToUpper
            Case "O", "F"
                SaveOrUpdateStatuesOperational(_VehicleRunningLogPPT)
                Exit Select
            Case "B"
                SaveOrUpdateStatuesBreakDown(_VehicleRunningLogPPT)
                Exit Select
            Case "S"
                SaveOrUpdateStatuesStandBy(_VehicleRunningLogPPT)
                Exit Select
        End Select

        'Select Case txtStartKms.Text.Trim
        '    Case String.Empty
        '        _VehicleRunningLogPPT.piStartKms = 0D
        '        Exit Select
        '    Case txtStartKms.Text.Trim
        '        _VehicleRunningLogPPT.piStartKms = Convert.ToDecimal(txtStartKms.Text.Trim)
        '        Exit Select
        'End Select

        'Select Case txtEndKms.Text.Trim
        '    Case String.Empty
        '        _VehicleRunningLogPPT.piEndKms = 0D
        '        Exit Select
        '    Case txtEndKms.Text.Trim
        '        _VehicleRunningLogPPT.piEndKms = Convert.ToDecimal(txtEndKms.Text.Trim)
        '        Exit Select
        'End Select

        'Select Case txtTotalKms.Text.Trim
        '    Case String.Empty
        '        _VehicleRunningLogPPT.piTotalKm = 0D
        '        Exit Select
        '    Case txtTotalKms.Text.Trim
        '        _VehicleRunningLogPPT.piTotalKm = Convert.ToDecimal(txtTotalKms.Text.Trim)
        '        Exit Select
        'End Select


        'Select Case txtStartTime.Text.Trim
        '    Case String.Empty
        '        Exit Select
        '    Case txtStartTime.Text.Trim
        '        _VehicleRunningLogPPT.pdStartTimeDT = General.GetInTimeFormat(txtStartTime.Text.Trim)
        '        Exit Select

        'End Select

        'Select Case txtEndTime.Text.Trim
        '    Case String.Empty
        '        Exit Select
        '    Case txtEndTime.Text.Trim
        '        _VehicleRunningLogPPT.pdEndTimeDT = General.GetInTimeFormat(txtEndTime.Text.Trim)
        '        Exit Select

        'End Select

        'Select Case txtTotalHours.Text.Trim
        '    Case String.Empty
        '        Exit Select
        '    Case txtTotalHours.Text.Trim
        '        _VehicleRunningLogPPT.pdTotalHrsDT = General.GetInTimeFormat(txtTotalHours.Text.Trim)
        '        Exit Select

        'End Select

        'If txtShift.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.pcShift = txtShift.Text.Trim.Substring(0, 1)
        'End If

        '_VehicleRunningLogPPT.psDivID = txtDIV.Text.Trim
        '_VehicleRunningLogPPT.psYOPID = txtYOP.Text.Trim
        '_VehicleRunningLogPPT.psBlockID = txtSubBlock.Text.Trim
        '_VehicleRunningLogPPT.psActivity = txtVehicleActivity.Text.Trim

        '_VehicleRunningLogPPT.psFFBDeliveryOrderNo = txtFFBDeliveryOrderNo.Text.Trim

        'If txtBunches.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piBunches = Convert.ToDecimal(txtBunches.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piBunches = 0D
        'End If

        'If txtActualBunchesMill.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piActualBunchesMill = Convert.ToDecimal(txtActualBunchesMill.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piActualBunchesMill = 0D
        'End If

        '_VehicleRunningLogPPT.psCollectionPoint = txtCollectionPoint.Text.Trim

        'If txtMillWeight.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piMillWeight = Convert.ToDecimal(txtMillWeight.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piMillWeight = 0D
        'End If

        '_VehicleRunningLogPPT.pdDateHarvestedDT = New Date(dtpDateHarvested.Value.Year, dtpDateHarvested.Value.Month, dtpDateHarvested.Value.Day)
        '_VehicleRunningLogPPT.pdDateCollectedDT = New Date(dtpDateCollected.Value.Year, dtpDateCollected.Value.Month, dtpDateCollected.Value.Day)
        '_VehicleRunningLogPPT.psDoubleHandledFFB = txtDoubleHandledFFB.Text.Trim

        '_VehicleRunningLogPPT.psWeightedBy = txtWeightedBy.Text.Trim
        '_VehicleRunningLogPPT.psDispatchedBy = txtDispatchedBy.Text.Trim
        ''Global
        '_VehicleRunningLogPPT.psCreatedBy = GlobalPPT.psCreatedBy

        _VehicleRunningLogPPT.psVHRLRemarks = txtRemarks.Text.Trim

        liMessageValue = _VehicleRunningLogBOL.SaveVehicleRunningLog(_VehicleRunningLogPPT)

        If liMessageValue = 12 Then ''Code 4 - Unable to save/update the record.
            DisplayInfoMessage("UsedVehicleSomeWhere")
        ElseIf liMessageValue = 11 Then
            If txtUOM.Text = "Kms" Then
                DisplayInfoMessage("Msg11")
            Else
                DisplayInfoMessage("Msg12")
            End If
        ElseIf liMessageValue = 14 Then
            DisplayInfoMessage("Msg12")
        ElseIf liMessageValue = 15 Then
            DisplayInfoMessage("BreakDownOnlyone")

        Else
            General.ShowMessageFromDataBase(liMessageValue)
        End If

        '        General.ShowMessageFromDataBase(liMessageValue)

        'If duplicate record don't go to view tab
        If liMessageValue = 10 OrElse liMessageValue = 11 OrElse liMessageValue = 14 OrElse liMessageValue = 12 OrElse liMessageValue = 13 Then
            Select Case liMessageValue
                Case 11
                    txtStartKms.Focus()
                    Return False
                    Exit Select
                Case 12 Or 14
                    'txtStartTime.Focus()
                    'cmbStartHrs.Focus()
                    txtStartHr.Focus()
                    Return False
                    Exit Select
                Case 13
                    ' txtFFBDeliveryOrderNo.Focus()
                    Return False
                    Exit Select
            End Select
            'If any message return

        End If

        ResetControls("DisableControls")
        ResetControls("VehicleRunningData")
        ResetControls("BunchesData")

        'tbVehicleRunningLog.SelectedIndex = 0

        'Called here because if any new vehicle code date in added in vehicle running log
        'FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)
        ShowRunningDetailsByVehicleCodeAndDate(txtVehicleCode.Text.Trim, dtpDate.Value)
        Return True

        'ShowMessageFromDataBaseForSave(_VehicleRunningLogPPT.SaveVehicleRunningBatch(_VehicleRunningLogPPT))

        'Refill the grid
        'RefilGrid(New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day), _VehicleRunningLogPPT.psVHID)
    End Function

    Private Function SaveOrUpdateDefaultValueAssignment(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT)

        _VehicleRunningLogPPT.pdLogDate = New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)
        _VehicleRunningLogPPT.psVHWSCode = txtVehicleCode.Text.Trim
        _VehicleRunningLogPPT.NIK = txtNIK.Text
        _VehicleRunningLogPPT.DriverName = txtDriverName.Text
        If txtBatchValue.Text.Trim <> String.Empty Then
            _VehicleRunningLogPPT.piBatchValue = Convert.ToDecimal(txtBatchValue.Text.Trim)
        Else
            _VehicleRunningLogPPT.piBatchValue = 0D
        End If

        _VehicleRunningLogPPT.psContractNo = txtContractNo.Text.Trim

        If ddlLocation.SelectedIndex > 0 Then
            _VehicleRunningLogPPT.psDistributionSetupID = ddlLocation.SelectedValue
        End If

        If rbBreakDown.Checked Then
            _VehicleRunningLogPPT.pcStatus = "B"
        ElseIf rbOperational.Checked Then
            _VehicleRunningLogPPT.pcStatus = "O"
        ElseIf rbStandBy.Checked Then
            _VehicleRunningLogPPT.pcStatus = "S"
        ElseIf rbFFBdeliverytoMill.Checked Then
            _VehicleRunningLogPPT.pcStatus = "F"
        End If

        Return _VehicleRunningLogPPT

    End Function

    Private Function SaveOrUpdateStatuesOperational(ByVal _VehicleRunningLogPPT)
        Select Case txtStartKms.Text.Trim
            Case String.Empty
                _VehicleRunningLogPPT.piStartKms = 0D
                Exit Select
            Case txtStartKms.Text.Trim
                _VehicleRunningLogPPT.piStartKms = Convert.ToDecimal(txtStartKms.Text.Trim)
                Exit Select
        End Select

        Select Case txtEndKms.Text.Trim
            Case String.Empty
                _VehicleRunningLogPPT.piEndKms = 0D
                Exit Select
            Case txtEndKms.Text.Trim
                _VehicleRunningLogPPT.piEndKms = Convert.ToDecimal(txtEndKms.Text.Trim)
                Exit Select
        End Select

        Select Case txtTotalKms.Text.Trim
            Case String.Empty
                _VehicleRunningLogPPT.piTotalKm = 0D
                Exit Select
            Case txtTotalKms.Text.Trim
                _VehicleRunningLogPPT.piTotalKm = Convert.ToDecimal(txtTotalKms.Text.Trim)
                Exit Select
        End Select


        Select Case lsStartTime.Trim
            Case String.Empty

                Exit Select
            Case lsStartTime.Trim
                _VehicleRunningLogPPT.pdStartTimeDT = General.GetInTimeFormat(lsStartTime.Trim)
                Exit Select

        End Select

        Select Case lsEndTime.Trim
            Case String.Empty
                Exit Select
            Case lsEndTime.Trim
                _VehicleRunningLogPPT.pdEndTimeDT = General.GetInTimeFormat(lsEndTime.Trim)
                Exit Select

        End Select

        Select Case txtTotalHours.Text.Trim
            Case String.Empty
                _VehicleRunningLogPPT.psTotalHrs = "00:00"
                Exit Select
            Case txtTotalHours.Text.Trim
                _VehicleRunningLogPPT.psTotalHrs = txtTotalHours.Text.Trim
                '_VehicleRunningLogPPT.pdTotalHrsDT = General.GetInTimeFormat(txtTotalHours.Text.Trim)
                Exit Select


        End Select

        If txtShift.Text.Trim <> String.Empty Then
            _VehicleRunningLogPPT.pcShift = txtShift.Text.Trim.Substring(0, 1)
        End If

        _VehicleRunningLogPPT.psDivID = txtDIV.Text.Trim
        _VehicleRunningLogPPT.psYOPID = txtYOP.Text.Trim
        _VehicleRunningLogPPT.psBlockID = txtSubBlock.Text.Trim
        _VehicleRunningLogPPT.psActivity = txtVehicleActivity.Text.Trim

        '_VehicleRunningLogPPT.psFFBDeliveryOrderNo = txtFFBDeliveryOrderNo.Text.Trim

        'If txtBunches.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piBunches = Convert.ToDecimal(txtBunches.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piBunches = 0D
        'End If

        'If txtActualBunchesMill.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piActualBunchesMill = Convert.ToDecimal(txtActualBunchesMill.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piActualBunchesMill = 0D
        'End If

        '_VehicleRunningLogPPT.psCollectionPoint = txtCollectionPoint.Text.Trim

        'If txtMillWeight.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piMillWeight = Convert.ToDecimal(txtMillWeight.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piMillWeight = 0D
        'End If

        'If chkDateHarvested.Checked Then
        '    _VehicleRunningLogPPT.pdDateHarvestedDT = New Date(dtpDateHarvested.Value.Year, dtpDateHarvested.Value.Month, dtpDateHarvested.Value.Day)
        'Else
        '    _VehicleRunningLogPPT.pdDateHarvestedDT = CDate("1/1/1753")
        'End If

        'If chkDateCollected.Checked Then
        '    _VehicleRunningLogPPT.pdDateCollectedDT = New Date(dtpDateCollected.Value.Year, dtpDateCollected.Value.Month, dtpDateCollected.Value.Day)
        'Else
        '    _VehicleRunningLogPPT.pdDateCollectedDT = CDate("1/1/1753")
        'End If

        ''_VehicleRunningLogPPT.pdDateHarvestedDT = New Date(dtpDateHarvested.Value.Year, dtpDateHarvested.Value.Month, dtpDateHarvested.Value.Day)
        ''_VehicleRunningLogPPT.pdDateCollectedDT = New Date(dtpDateCollected.Value.Year, dtpDateCollected.Value.Month, dtpDateCollected.Value.Day)
        '_VehicleRunningLogPPT.psDoubleHandledFFB = txtDoubleHandledFFB.Text.Trim

        '_VehicleRunningLogPPT.psWeightedBy = txtWeightedBy.Text.Trim
        '_VehicleRunningLogPPT.psDispatchedBy = txtDispatchedBy.Text.Trim
        '_VehicleRunningLogPPT.psVHRLRemarks = txtRemarks.Text.Trim
        ''Global
        ''_VehicleRunningLogPPT.psCreatedBy = GlobalPPT.strUserName
        'Return _VehicleRunningLogPPT
    End Function

    Private Function SaveOrUpdateStatuesBreakDown(ByVal _VehicleRunningLogPPT)
        _VehicleRunningLogPPT.pdDateHarvestedDT = New Date(1753, 1, 1)
        _VehicleRunningLogPPT.pdDateCollectedDT = New Date(1753, 1, 1)
        Return _VehicleRunningLogPPT
    End Function

    Private Function SaveOrUpdateStatuesStandBy(ByVal _VehicleRunningLogPPT)

        Select Case lsStartTime.Trim
            Case String.Empty
                Exit Select
            Case lsStartTime.Trim
                _VehicleRunningLogPPT.pdStartTimeDT = General.GetInTimeFormat(lsStartTime.Trim)
                Exit Select

        End Select

        Select Case lsEndTime.Trim
            Case String.Empty
                Exit Select
            Case lsEndTime.Trim
                _VehicleRunningLogPPT.pdEndTimeDT = General.GetInTimeFormat(lsEndTime.Trim)
                Exit Select

        End Select

        Select Case txtTotalHours.Text.Trim
            Case String.Empty
                _VehicleRunningLogPPT.psTotalHrs = "00:00"
                Exit Select
            Case txtTotalHours.Text.Trim
                _VehicleRunningLogPPT.psTotalHrs = txtTotalHours.Text.Trim
                '_VehicleRunningLogPPT.pdTotalHrsDT = General.GetInTimeFormat(txtTotalHours.Text.Trim)
                Exit Select

        End Select

        If txtShift.Text.Trim <> String.Empty Then
            _VehicleRunningLogPPT.pcShift = txtShift.Text.Trim.Substring(0, 1)
        End If

        'Setting the default Date
        _VehicleRunningLogPPT.pdDateHarvestedDT = New Date(1753, 1, 1)
        _VehicleRunningLogPPT.pdDateCollectedDT = New Date(1753, 1, 1)

        Return _VehicleRunningLogPPT
    End Function

    Private Function AssignControlValuesToPropertiesForUpdate(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Boolean

        Dim liMessageValue As Integer
        _VehicleRunningLogBOL = New VehicleRunningLogBOL

        _VehicleRunningLogPPT.piID = liID

        SaveOrUpdateDefaultValueAssignment(_VehicleRunningLogPPT)

        Select Case (_VehicleRunningLogPPT.pcStatus).ToString.ToUpper
            Case "O", "F"
                SaveOrUpdateStatuesOperational(_VehicleRunningLogPPT)
                Exit Select
            Case "B"
                SaveOrUpdateStatuesBreakDown(_VehicleRunningLogPPT)
                Exit Select
            Case "S"
                SaveOrUpdateStatuesStandBy(_VehicleRunningLogPPT)
                Exit Select
        End Select

        '_VehicleRunningLogPPT.pdLogDate = New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)
        '_VehicleRunningLogPPT.psVHWSCode = txtVehicleCode.Text.Trim

        'If txtBatchValue.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piBatchValue = Convert.ToDecimal(txtBatchValue.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piBatchValue = 0D
        'End If

        '_VehicleRunningLogPPT.piContractNumber = txtContractNo.Text.Trim

        'If ddlLocation.SelectedIndex > 0 Then
        '    _VehicleRunningLogPPT.psDistributionSetupID = ddlLocation.SelectedValue
        'End If

        'Select Case txtStartKms.Text.Trim
        '    Case String.Empty
        '        _VehicleRunningLogPPT.piStartKms = 0D
        '        Exit Select
        '    Case txtStartKms.Text
        '        _VehicleRunningLogPPT.piStartKms = Convert.ToDecimal(txtStartKms.Text.Trim)
        '        Exit Select
        'End Select

        'Select Case txtEndKms.Text.Trim
        '    Case String.Empty
        '        _VehicleRunningLogPPT.piEndKms = 0D
        '        Exit Select
        '    Case txtEndKms.Text
        '        _VehicleRunningLogPPT.piEndKms = Convert.ToDecimal(txtEndKms.Text.Trim)
        '        Exit Select
        'End Select

        'Select Case txtTotalKms.Text.Trim
        '    Case String.Empty
        '        _VehicleRunningLogPPT.piTotalKm = 0D
        '        Exit Select
        '    Case txtTotalKms.Text
        '        _VehicleRunningLogPPT.piTotalKm = Convert.ToDecimal(txtTotalKms.Text.Trim)
        '        Exit Select
        'End Select


        'Select Case txtStartTime.Text.Trim
        '    Case String.Empty
        '        Exit Select
        '    Case txtStartTime.Text.Trim
        '        _VehicleRunningLogPPT.pdStartTimeDT = General.GetInTimeFormat(txtStartTime.Text.Trim)
        '        Exit Select

        'End Select

        'Select Case txtEndTime.Text.Trim
        '    Case String.Empty
        '        Exit Select
        '    Case txtEndTime.Text.Trim
        '        _VehicleRunningLogPPT.pdEndTimeDT = General.GetInTimeFormat(txtEndTime.Text.Trim)
        '        Exit Select

        'End Select

        'Select Case txtTotalHours.Text.Trim
        '    Case String.Empty
        '        Exit Select
        '    Case txtTotalHours.Text.Trim
        '        _VehicleRunningLogPPT.pdTotalHrsDT = General.GetInTimeFormat(txtTotalHours.Text.Trim)
        '        Exit Select

        'End Select


        'If txtShift.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.pcShift = txtShift.Text.Trim.Substring(0, 1)
        'End If

        '_VehicleRunningLogPPT.psDivID = txtDIV.Text.Trim
        '_VehicleRunningLogPPT.psYOPID = txtYOP.Text.Trim
        '_VehicleRunningLogPPT.psBlockID = txtSubBlock.Text.Trim
        '_VehicleRunningLogPPT.psActivity = txtVehicleActivity.Text.Trim

        'If rbBreakDown.Checked Then
        '    _VehicleRunningLogPPT.pcStatus = "B"
        'ElseIf rbOperational.Checked Then
        '    _VehicleRunningLogPPT.pcStatus = "O"
        'ElseIf rbStandBy.Checked Then
        '    _VehicleRunningLogPPT.pcStatus = "S"
        'End If

        '_VehicleRunningLogPPT.psFFBDeliveryOrderNo = txtFFBDeliveryOrderNo.Text.Trim

        'If txtBunches.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piBunches = Convert.ToDecimal(txtBunches.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piBunches = 0D
        'End If

        'If txtActualBunchesMill.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piActualBunchesMill = Convert.ToDecimal(txtActualBunchesMill.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piActualBunchesMill = 0D
        'End If

        '_VehicleRunningLogPPT.psCollectionPoint = txtCollectionPoint.Text.Trim

        'If txtMillWeight.Text.Trim <> String.Empty Then
        '    _VehicleRunningLogPPT.piMillWeight = Convert.ToDecimal(txtMillWeight.Text.Trim)
        'Else
        '    _VehicleRunningLogPPT.piMillWeight = 0D
        'End If

        '_VehicleRunningLogPPT.pdDateHarvestedDT = New Date(dtpDateHarvested.Value.Year, dtpDateHarvested.Value.Month, dtpDateHarvested.Value.Day)
        '_VehicleRunningLogPPT.pdDateCollectedDT = New Date(dtpDateCollected.Value.Year, dtpDateCollected.Value.Month, dtpDateCollected.Value.Day)
        '_VehicleRunningLogPPT.psDoubleHandledFFB = txtDoubleHandledFFB.Text.Trim

        '_VehicleRunningLogPPT.psWeightedBy = txtWeightedBy.Text.Trim
        '_VehicleRunningLogPPT.psDispatchedBy = txtDispatchedBy.Text.Trim
        _VehicleRunningLogPPT.psVHRLRemarks = txtRemarks.Text.Trim
        'Global
        '_VehicleRunningLogPPT.psModifiedBy = GlobalPPT.strUserName
        _VehicleRunningLogPPT.piConcurrencyId = lbConcurrencyID

        liMessageValue = _VehicleRunningLogBOL.UpdateVehicleRunningLog(_VehicleRunningLogPPT)

        If liMessageValue = 12 Then ''Code 4 - Unable to save/update the record.
            DisplayInfoMessage("UsedVehicleSomeWhere")
        ElseIf liMessageValue = 11 Then
            If txtUOM.Text = "Kms" Then
                DisplayInfoMessage("Msg11")
            Else
                DisplayInfoMessage("Msg12")
            End If
        ElseIf liMessageValue = 14 Then
            DisplayInfoMessage("Msg12")
        ElseIf liMessageValue = 15 Then
            DisplayInfoMessage("BreakDownOnlyone")
        Else
            General.ShowMessageFromDataBase(liMessageValue)
        End If

        'General.ShowMessageFromDataBase(liMessageValue)

        'If duplicate record don't go to view tab
        If liMessageValue = 10 OrElse liMessageValue = 11 OrElse liMessageValue = 14 OrElse liMessageValue = 12 OrElse liMessageValue = 13 Then
            Select Case liMessageValue
                Case 11
                    txtStartKms.Focus()
                    Return False
                    Exit Select
                Case 12 Or 14
                    '                    txtStartTime.Focus()
                    'cmbStartHrs.Focus()
                    txtStartHr.Focus()
                    Return False
                    Exit Select
                Case 13
                    ' txtFFBDeliveryOrderNo.Focus()
                    Return False
                    Exit Select
            End Select

            Return True

        End If

        'Is called on tab index changed
        ResetControls("DisableControls")
        ResetControls("VehicleRunningData")
        ResetControls("BunchesData")
        If GlobalPPT.strLang = "en" Then
            btnSaveOrUpdate.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveOrUpdate.Text = "Simpan"
        End If
        'btnSaveOrUpdate.Text = "Save"
        ' tbVehicleRunningLog.SelectedIndex = 0
        ShowRunningDetailsByVehicleCodeAndDate(txtVehicleCode.Text.Trim, dtpDate.Value)

        Return True
        'No need to call since the event already called
        'FillVehicleCodeFromVehicleRunningLog(String.Empty, String.Empty)
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Function

    Sub EditListOfVehicle(ByVal piId As Integer)
        'Sub EditListOfVehicle()
        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


        btnActivity.Enabled = False
        

        _VehicleRunningLogPPT = New VehicleRunningLogPPT
        _VehicleRunningLogBOL = New VehicleRunningLogBOL
        Dim dsVehicleRunningLog As DataSet

        _VehicleRunningLogPPT.piID = piId
        '_VehicleRunningLogPPT.piID = DirectCast(dgvListOfVehicleLog.CurrentRow.Cells("Id").Value, Integer)


        dsVehicleRunningLog = _VehicleRunningLogBOL.GetRunningLodDetailsByIdDuringEdit(_VehicleRunningLogPPT)

        ' dsBatchValue = _VehicleRunningLogBOL.GetBatchValueByVehicleCodeLog(_VehicleRunningLogPPT)

        '''''''''''''''''_VehicleRunningLogCollection = tempList.Item(0)

        '1
        'If dsEditableData.Tables(0).Rows.Count > 0 Then

        'Since after Delete we call the function and we set selection is false in DataBindingComplete
        'dgvListOfVehicleLog.CurrentRow.Selected = True

        If dsVehicleRunningLog.Tables(0) IsNot Nothing And dsVehicleRunningLog.Tables(0).Rows.Count > 0 Then

            Dim ldDateDt As DateTime

            lbConcurrencyID = dsVehicleRunningLog.Tables(0).Rows(0)("ConcurrencyId")

            ldDateDt = dsVehicleRunningLog.Tables(0).Rows(0)("LogDate")

            dtpDate.Value = New Date(ldDateDt.Year, ldDateDt.Month, ldDateDt.Day)
            txtVehicleCode.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("VHWSCode")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("VHWSCode"))
            txtVehicleActivity.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("Activity")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("Activity"))
            'Convert - For replacing ,
            'Since batchvalue is removed we had commented it
            'txtBatchValue.Text = Convert.ToString(dsVehicleRunningLog.Tables(0).Rows(0)("VHBatchValue")).Replace(",", String.Empty)
            txtVehicleDescription.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("VHDescp")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("VHDescp"))
            txtVehicleModel.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("VHModel")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("VHModel"))
            txtContractNo.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("ContractNo")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("ContractNo"))

            Select Case dsVehicleRunningLog.Tables(0).Rows(0)("UOM")
                Case "H"
                    txtUOM.Text = "Hrs"
                    Exit Select
                Case "K"
                    txtUOM.Text = "Kms"
                    Exit Select
            End Select

            If Not IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("DistributionSetupID")) Then
                ddlLocation.SelectedValue = dsVehicleRunningLog.Tables(0).Rows(0)("DistributionSetupID")
            Else
                If ddlLocation.Items.Count = 0 Then
                    ddlLocation.SelectedIndex = -1
                Else
                    ddlLocation.SelectedIndex = 0
                End If
            End If

            'Since data not entered while saving
            If dsVehicleRunningLog.Tables(0).Rows(0)("StartTime") <> dsVehicleRunningLog.Tables(0).Rows(0)("EndTime") Then

                Dim lsStartTempTime As String = dsVehicleRunningLog.Tables(0).Rows(0)("StartTime").ToString()

                Dim splitStartTime() As String = lsStartTempTime.Split(":")

                Dim lsEndTempTime As String = dsVehicleRunningLog.Tables(0).Rows(0)("EndTime").ToString()
                Dim splitEndTime() As String = lsEndTempTime.Split(":")

                lsStartTime = dsVehicleRunningLog.Tables(0).Rows(0)("StartTime").ToString()
                lsEndTime = dsVehicleRunningLog.Tables(0).Rows(0)("EndTime").ToString()
                'txtTotalHours.Text = dsVehicleRunningLog.Tables(0).Rows(0)("TotalHrs").ToString().Substring(0, 5)

                'txtTotalHours.Text = dsVehicleRunningLog.Tables(0).Rows(0)("TotalHrs").ToString()

                txtStartHr.Text = splitStartTime(0)
                txtStartMin.Text = splitStartTime(1)

                txtEndHr.Text = splitEndTime(0)
                txtEndMin.Text = splitEndTime(1)


                '' cmbEndHrs.SelectedIndex = Convert.ToInt32(splitEndTime(0)) ' - 1
                'cmbEndHrs.SelectedIndex = cmbEndHrs.FindString(splitEndTime(0))
                'If splitEndTime(1).StartsWith(0) Then
                '    cmbEndMin.SelectedIndex = cmbEndMin.FindString(splitEndTime(1))
                'Else
                '    cmbEndMin.SelectedIndex = cmbEndMin.FindString(Convert.ToInt32(splitEndTime(1)))
                'End If
                '' cmbEndMin.SelectedIndex = cmbEndMin.FindString(Convert.ToInt32(splitEndTime(1)))

                ''Here only event fired
                ''cmbStartHrs.SelectedIndex = Convert.ToInt32(splitStartTime(0)) ' - 1
                'cmbStartHrs.SelectedIndex = cmbStartHrs.FindString(splitStartTime(0))
                'If splitStartTime(1).StartsWith(0) Then
                '    cmbStartMin.SelectedIndex = cmbStartMin.FindString(splitStartTime(1))
                'Else
                '    cmbStartMin.SelectedIndex = cmbStartMin.FindString(Convert.ToInt32(splitStartTime(1)))
                'End If
                '' cmbStartMin.SelectedIndex = cmbStartMin.FindString(Convert.ToInt32(splitStartTime(1)))
                ''Else
                ''    cmbStartHrs.SelectedIndex = 1
                ''    cmbStartMin.SelectedIndex = 1
                ''    cmbEndHrs.SelectedIndex = 1
                ''    cmbEndMin.SelectedIndex = 1

            End If
            txtTotalHours.Text = dsVehicleRunningLog.Tables(0).Rows(0)("TotalHrs").ToString()
            EditTotalHrs = dsVehicleRunningLog.Tables(0).Rows(0)("TotalHrs").ToString()
            'Since data not entered while saving
            If Convert.ToDouble(dsVehicleRunningLog.Tables(0).Rows(0)("StartKms")) <> Convert.ToDouble(dsVehicleRunningLog.Tables(0).Rows(0)("EndKms")) Then
                txtStartKms.Text = dsVehicleRunningLog.Tables(0).Rows(0)("StartKms")
                txtEndKms.Text = dsVehicleRunningLog.Tables(0).Rows(0)("EndKms")
                txtTotalKms.Text = Format(Convert.ToDecimal(dsVehicleRunningLog.Tables(0).Rows(0)("TotalKm")), "0,0.0,0")
                EditTotalKms = Format(Convert.ToDecimal(dsVehicleRunningLog.Tables(0).Rows(0)("TotalKm")), "0,0.0,0")
            End If

            txtOperatedBy.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("EmpName")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("EmpName"))
            txtVehicleRegNo.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("RegNo")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("RegNo"))

            Select Case (dsVehicleRunningLog.Tables(0).Rows(0)("MorningEvening"))
                Case "M"
                    txtShift.Text = "Morning"
                    Exit Select
                Case "A"
                    txtShift.Text = "AfterNoon"
                    Exit Select
            End Select

            txtDIV.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("Div")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("Div"))
            txtYOP.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("YOP")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("YOP"))
            txtSubBlock.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("BlockName")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("BlockName"))
            txtVehicleActivity.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("Activity")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("Activity"))

            OperationalRequiredLabelColor()

            Select Case dsVehicleRunningLog.Tables(0).Rows(0)("Status")
                Case "B"
                    rbBreakDown.Checked = True
                    Exit Select
                Case "O"
                    rbOperational.Checked = True
                    'gbBunchesData.Enabled = False
                    Exit Select
                Case "S"
                    rbStandBy.Checked = True
                    Exit Select
                Case "F"
                    rbFFBdeliverytoMill.Checked = True
                    ResetControls("FFBdeliverytoMill")
                    Exit Select
            End Select

            'txtFFBDeliveryOrderNo.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("FFBDeliveryOrderNo")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("FFBDeliveryOrderNo"))
            'txtBunches.Text = IIf(Convert.ToDecimal(dsVehicleRunningLog.Tables(0).Rows(0)("Bunches")) = 0D, String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("Bunches"))

            'txtActualBunchesMill.Text = IIf(Convert.ToDecimal(dsVehicleRunningLog.Tables(0).Rows(0)("ActualBunch")) = 0D, String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("ActualBunch"))
            'txtCollectionPoint.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("CollectionPoint")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("CollectionPoint"))
            'txtMillWeight.Text = IIf(Convert.ToDecimal(dsVehicleRunningLog.Tables(0).Rows(0)("MillWeight")) = 0D, String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("MillWeight"))

            ''Changed for the function SaveOrUpdateStatuesStandBy, SaveOrUpdateStatuesBreakDown created
            'Select Case dsVehicleRunningLog.Tables(0).Rows(0)("DateCollected")
            '    Case "1/1/1753 12:00:00 AM"
            '        dtpDateCollected.Text = dtpDateCollected.MinDate.ToString
            '    Case Else
            '        chkDateCollected.Checked = True
            '        chkDateCollected.Enabled = True
            '        dtpDateCollected.Text = dsVehicleRunningLog.Tables(0).Rows(0)("DateCollected")
            'End Select

            'Select Case dsVehicleRunningLog.Tables(0).Rows(0)("DateHarvested")
            '    Case "1/1/1753 12:00:00 AM"
            '        dtpDateHarvested.Text = dtpDateHarvested.MinDate.ToString
            '    Case Else
            '        chkDateHarvested.Checked = True
            '        dtpDateCollected.Enabled = True
            '        dtpDateHarvested.Text = dsVehicleRunningLog.Tables(0).Rows(0)("DateHarvested")
            'End Select


            'txtDoubleHandledFFB.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("DoubleHandledFFB")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("DoubleHandledFFB"))
            'txtWeightedBy.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("WeighedBy")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("WeighedBy"))
            'txtDispatchedBy.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("DispatchedBy")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("DispatchedBy"))
            'txtRemarks.Text = IIf(IsDBNull(dsVehicleRunningLog.Tables(0).Rows(0)("Remarks")), String.Empty, dsVehicleRunningLog.Tables(0).Rows(0)("Remarks"))

            'btnSaveOrUpdate.Text = "Update"

            If GlobalPPT.strLang = "en" Then
                btnSaveOrUpdate.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveOrUpdate.Text = "Memperbarui"
            End If



            If rbFFBdeliverytoMill.Checked = True Then
                btnPrintFFBDO.Enabled = True
            Else
                btnPrintFFBDO.Enabled = False
            End If


            'btnPrintFFBDO.Visible = True
            'dgListOfVehicleLog.Enabled = False

            '''''''''''''''''''''''''_VehicleRunningLogCollection = tempList.Item(1)

            'Select Case txtUOM.Text.Trim
            '    Case "Hrs"

            '        ltsOutstandingHrs = dsVehicleRunningLog.Tables(1).Rows(0)("OutStandingHrs")
            '        '                    MsgBox(Convert.ToString(ltsOutstandingHrs))
            '        'Get the Assigned hours --Tables(0)
            '        '                    ldOldHrs = General.GetInTimeFormat(Convert.ToString(_VehicleRunningLogCollection(0).pdTotalHrsDT))
            '        ldOldHrs = General.GetInTimeFormat(txtTotalHours.Text.Trim)
            '        'MsgBox(Convert.ToString(ldOldHrs))
            '        Exit Select
            '    Case "Kms"
            '        ldOutstandingKms = dsVehicleRunningLog.Tables(1).Rows(0)("OutStandingKms")

            '        If txtTotalKms.Text.Trim <> String.Empty Then
            '            ldOldKms = Convert.ToDecimal(txtTotalKms.Text.Trim)
            '        End If
            '        Exit Select
            'End Select

            ' 1 Else

            ' 1     MsgBox("Please Give Batch Value in the Form Vehicle Running Batch", MsgBoxStyle.OkOnly, "Information")
            ' 1 End If

            Dim mdiparent As New MDIParent
            If mdiparent.strMenuID = "M72" Then
                tbVehicleRunningLog.SelectedTab = tbpgAdd
                tbVehicleRunningLog.TabPages.Remove(tpViewVRL)

            End If

            'Else
            '    MsgBox("Please give batch value in the form Vehicle Running Batch", MsgBoxStyle.OkOnly, "Information")
        End If
        'Dim vhc As New VehicleRunningLogPostingFrm()
        '.Text = "siva"

        If Not objUserLoginBOl.Privilege(btnSaveOrUpdate, tsmiViewAdd, tsmiViewEdit, tsmiViewDelete, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Function ConvertToLocalTime(ByVal psTime As String) As String
        Dim dd As DateTime = DateTime.Parse(psTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
        Return Format((dd.Hour.ToString & ":" & dd.Minute.ToString & dd.ToString.Substring(dd.ToString.Length - 2, 2)), "{0:hh:mm tt}")
    End Function

    Private Sub ResetViewTab()
        For n As Integer = 0 To dgVehicleCode.Rows.Count - 1
            If dgVehicleCode.Rows(0).IsNewRow = False Then
                dgVehicleCode.Rows.RemoveAt(0)
            End If
        Next

        txtVehicleCodeView.Text = String.Empty
    End Sub

    Private Sub OperationalRequiredLabelColor()
        'If txtDIV.Text.Trim <> String.Empty OrElse txtYOP.Text.Trim <> String.Empty OrElse txtSubBlock.Text.Trim <> String.Empty OrElse txtFFBDeliveryOrderNo.Text.Trim <> String.Empty OrElse txtBunches.Text.Trim <> String.Empty Then
        '    lblDIV.ForeColor = Color.Red
        '    lblYOP.ForeColor = Color.Red
        '    lblSubBlock.ForeColor = Color.Red
        '    lblSerialNo.ForeColor = Color.Red
        '    lblBunches.ForeColor = Color.Red
        'Else
        '    lblDIV.ForeColor = Color.Black
        '    lblYOP.ForeColor = Color.Black
        '    lblSubBlock.ForeColor = Color.Black
        '    lblSerialNo.ForeColor = Color.Black
        '    lblBunches.ForeColor = Color.Black
        'End If
    End Sub

    Private Function CheckRequiredOperationalsFields() As Boolean

        'Dim lsbRequired As System.Text.StringBuilder = New System.Text.StringBuilder

        If lblDIV.ForeColor = Color.Red And txtDIV.Text.Trim = String.Empty Then
            'MsgBox("This field is required.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'lsbRequired.Append("Division required.")

            'MessageBox.Show("This field is required.", lblDIV.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RField")
            txtDIV.Focus()
            Return False
        End If

        If lblYOP.ForeColor = Color.Red And txtYOP.Text.Trim = String.Empty Then
            'lsbRequired.Append(Environment.NewLine + "YOP required.")
            'MessageBox.Show("This field is required.", lblYOP.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RField")
            txtYOP.Focus()
            Return False
        End If

        If lblSubBlock.ForeColor = Color.Red And txtSubBlock.Text.Trim = String.Empty Then
            'lsbRequired.Append(Environment.NewLine + "Sub-Block required.")
            'MessageBox.Show("This field is required.", lblSubBlock.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RField")
            txtSubBlock.Focus()
            Return False
        End If

        If lblVehicleActivity.ForeColor = Color.Red And txtVehicleActivity.Text.Trim = String.Empty Then
            'lsbRequired.Append(Environment.NewLine + "Vehicle Activity required.")
            'MessageBox.Show("This field is required.", lblVehicleActivity.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("RField")
            txtVehicleActivity.Focus()
            Return False
        End If

        'If lblSerialNo.ForeColor = Color.Red And txtFFBDeliveryOrderNo.Text.Trim = String.Empty And txtFFBDeliveryOrderNo.Enabled = True Then
        '    'lsbRequired.Append(Environment.NewLine + "FFB Delivery Order No required.")
        '    'MessageBox.Show("This field is required.", lblSerialNo.Text, MessageBoxButtons.OK)
        '    DisplayInfoMessage("RField")
        '    txtFFBDeliveryOrderNo.Focus()
        '    Return False
        'End If

        'If lblBunches.ForeColor = Color.Red And txtBunches.Text.Trim = String.Empty And txtBunches.Enabled = True Then
        '    'lsbRequired.Append(Environment.NewLine + "Bunches required.")
        '    'MessageBox.Show("This field is required.", lblBunches.Text, MessageBoxButtons.OK)
        '    DisplayInfoMessage("RField")
        '    txtBunches.Focus()
        '    Return False
        'End If

        'If lsbRequired.Length = 0 Then
        '    Return True
        'Else
        '    MsgBox(lsbRequired.ToString.TrimStart(Environment.NewLine), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '    Return False
        'End If

        Return True

    End Function

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
                'If grdname.Rows.Count - 1 Then
                '    grdname.Rows.RemoveAt(0)
                'End If
            Next
        End If
    End Sub

    Private Sub CalculateMeridianAndTotalHrs()
        If lsStartTime <> String.Empty And lsEndTime <> String.Empty Then
            Dim h() As String = lsStartTime.Split(":")
            Dim ts As New TimeSpan(h(0), h(1), 0)

            If Convert.ToInt32(h(0)) >= 12 Then
                txtShift.Text = "Afternoon"
            Else
                txtShift.Text = "Morning"
            End If

            Dim tsStart As New TimeSpan(h(0), h(1), 0)

            h = lsEndTime.Split(":")

            Dim tsEnd As New TimeSpan(h(0), h(1), 0)
            Dim lsTempTotTime = tsEnd.Subtract(tsStart).ToString()
            txtTotalHours.Text = lsTempTotTime.Substring(0, lsTempTotTime.LastIndexOf(":"))

        End If

        '    Dim lsMeridian As String = CDate(Format(lsStartTime, "hh:mm tt"))

        '    Select Case lsMeridian.Trim.Substring(lsMeridian.Trim.Length - 2, 2).ToLower
        '        Case "am"
        '            txtShift.Text = "Morning"
        '            Exit Select
        '        Case "pm"
        '            txtShift.Text = "Afternoon"
        '            Exit Select
        '    End Select

        'Else
        '    txtTotalHours.Text = String.Empty
        'End If

    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tab
            tbVehicleRunningLog.TabPages("tbpgAdd").Text = rm.GetString("tbVehicleRunningLog.TabPages(tbpgAdd).Text")
            tbVehicleRunningLog.TabPages("tpViewVRL").Text = rm.GetString("tbVehicleRunningLog.TabPages(tpViewVRL).Text")

            'Button
            btnReset.Text = rm.GetString("btnReset.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSaveOrUpdate.Text = rm.GetString("btnSaveOrUpdate.Text")
            btnPrintFFBDO.Text = rm.GetString("btnPrintFFBDO.Text")
            'label
            lblDate.Text = rm.GetString("lblDate.Text")
            lblVehicleCode.Text = rm.GetString("lblVehicleCode.Text")
            lblBatchValue.Text = rm.GetString("lblBatchValue.Text")
            lblVehicleDescription.Text = rm.GetString("lblVehicleDescription.Text")
            lblVehicleModel.Text = rm.GetString("lblVehicleModel.Text")
            lblUOM.Text = rm.GetString("lblUOM.Text")
            lblOperatedBy.Text = rm.GetString("lblOperatedBy.Text")
            lblVehicleRegNo.Text = rm.GetString("lblVehicleRegNo.Text")
            lblContractNo.Text = rm.GetString("lblContractNo.Text")
            lblStatus.Text = rm.GetString("lblStatus.Text")
            rbOperational.Text = rm.GetString("rbOperational.Text")
            rbBreakDown.Text = rm.GetString("rbBreakDown.Text")
            rbStandBy.Text = rm.GetString("rbStandBy.Text")
            lblLocation.Text = rm.GetString("lblLocation.Text")
            gbVehicleRunningData.Text = rm.GetString("gbVehicleRunningData.Text")
            lblStartKms.Text = rm.GetString("lblStartKms.Text")
            lblEndKms.Text = rm.GetString("lblEndKms.Text")
            lblTotalKms.Text = rm.GetString("lblTotalKms.Text")
            lblStartTime.Text = rm.GetString("lblStartTime.Text")
            lblEndTime.Text = rm.GetString("lblEndTime.Text")
            lblTotalHours.Text = rm.GetString("lblTotalHours.Text")
            lblShift.Text = rm.GetString("lblShift.Text")
            lblDIV.Text = rm.GetString("lblDIV.Text")
            lblYOP.Text = rm.GetString("lblYOP.Text")
            lblSubBlock.Text = rm.GetString("lblSubBlock.Text")
            lblVehicleActivity.Text = rm.GetString("lblVehicleActivity.Text")
            'gbBunchesData.Text = rm.GetString("gbBunchesData.Text")
            'lblBunches.Text = rm.GetString("lblBunches.Text")
            'lblMillWeight.Text = rm.GetString("lblMillWeight.Text")
            'lblDoubleHandledFFB.Text = rm.GetString("lblDoubleHandledFFB.Text")
            'lblSerialNo.Text = rm.GetString("lblSerialNo.Text")
            'lblDateHarvested.Text = rm.GetString("lblDateHarvested.Text")
            'lblWeightedBy.Text = rm.GetString("lblWeightedBy.Text")
            'lblActualBunchesMill.Text = rm.GetString("lblActualBunchesMill.Text")
            'lblDateCollected.Text = rm.GetString("lblDateCollected.Text")
            'lblDispatchedBy.Text = rm.GetString("lblDispatchedBy.Text")
            'lblCollectionPoint.Text = rm.GetString("lblCollectionPoint.Text")
            lblRemarks.Text = rm.GetString("lblRemarks.Text")

            gbListOfVehicleLog.Text = rm.GetString("gbListOfVehicleLog.Text")


            'GridView
            dgvListOfVehicleLog.Columns("LogDate").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(LogDate).HeaderText")
            dgvListOfVehicleLog.Columns("VehicleCode").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(VehicleCode).HeaderText")
            dgvListOfVehicleLog.Columns("StartTime").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(StartTime).HeaderText")
            dgvListOfVehicleLog.Columns("EndTime").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(EndTime).HeaderText")
            dgvListOfVehicleLog.Columns("TotalHrs").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(TotalHrs).HeaderText")
            dgvListOfVehicleLog.Columns("Activity").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(Activity).HeaderText")
            dgvListOfVehicleLog.Columns("StartKms").HeaderText = rm.GetString("lblStartKms.Text")
            dgvListOfVehicleLog.Columns("EndKms").HeaderText = rm.GetString("lblEndKms.Text")
            dgvListOfVehicleLog.Columns("TotalKms").HeaderText = rm.GetString("lblTotalKms.Text")

            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value= ""
            '  For Each DataGridViewRow In dgvPostingNonPostedVehicleDistribution.Rows
            'DataGridViewRow.Cells("Approvel").Value.ToString()
            'Next
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value = rm.GetString("dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item(Approvel).Value")

            PnlSearch.CaptionText = rm.GetString("pnlSearch")
            lblSearchby.Text = rm.GetString("lblSearchby.Text")
            chkDate.Text = rm.GetString("chkDate.Text")
            lblViewVehicleCode.Text = rm.GetString("lblViewVehicleCode.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            'dgVehicleCode.Columns("Sno").HeaderText = rm.GetString("dgVehicleCode.Columns(Sno).HeaderText")
            dgVehicleCode.Columns("dgvLogDate").HeaderText = rm.GetString("dgvListOfVehicleLog.Columns(LogDate).HeaderText")
            dgVehicleCode.Columns("VHWSCode").HeaderText = rm.GetString("dgVehicleCode.Columns(VHWSCode).HeaderText")
            dgVehicleCode.Columns("ViewPosted").HeaderText = rm.GetString("HeaderGrid")
            btnViewReport.Text = rm.GetString("Report")
            'ViewPosted



            cmsDelete.Items.Item(0).Text = rm.GetString("cmsDelete.Items.Item(0).Text")
            cmsDelete.Items.Item(1).Text = rm.GetString("cmsDelete.Items.Item(1).Text")
            cmsDelete.Items.Item(2).Text = rm.GetString("cmsDelete.Items.Item(2).Text")
            cmsView.Items.Item(0).Text = rm.GetString("cmsDelete.Items.Item(0).Text")
            cmsView.Items.Item(1).Text = rm.GetString("cmsDelete.Items.Item(1).Text")
            cmsView.Items.Item(2).Text = rm.GetString("cmsDelete.Items.Item(2).Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Validation"

    Private Sub txtVehicleCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleCode.Leave

        If txtVehicleCode.Text.Trim <> String.Empty Then
            Select Case General.IsVHWSCodeExist("V", txtVehicleCode.Text.Trim)
                Case 0
                    'MsgBox("Sorry, no such vehicle code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    'MessageBox.Show("Sorry, no such vehicle code exists in the database.", lblVehicleCode.Text, MessageBoxButtons.OK)
                    DisplayInfoMessage("IVehicle")
                    txtVehicleCode.Text = String.Empty
                    txtVehicleCode.Focus()
                    Return
                Case 1
                    'MsgBox("Sorry, this vehicle code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    'MessageBox.Show("Sorry, this vehicle code does not belong to this estate.", lblVehicleCode.Text, MessageBoxButtons.OK)
                    DisplayInfoMessage("IVehicleEstate")
                    txtVehicleCode.Text = String.Empty
                    txtVehicleCode.Focus()
                    Return
            End Select
        Else
            ResetControls("Default")
            ResetControls("Mandatary")
            ResetControls("VehicleRunningData")
            ResetControls("BunchesData")
            ResetControls("ClearGrid")
        End If

        If txtVehicleCode.Text.Trim <> String.Empty Then

            ResetControls("Default")
            ResetControls("Mandatary")
            ResetControls("VehicleRunningData")
            ResetControls("BunchesData")
            ResetControls("ClearGrid")

            VehicleCodeChangedOrDateChanged()

        End If

    End Sub

    Private Sub txtContractNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractNo.Leave
        If txtContractNo.Text.Trim <> String.Empty Then
            'Select Case ValidateDivYopSubBlockAndContractNumber("ContractNumber", txtContactNo.Text.Trim)
            Select Case General.ValidateForeignKeyFields("ContractNumber", txtContractNo.Text.Trim)

                Case 0
                    'MsgBox("Sorry, no such vehicle code exists in the database. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    'MessageBox.Show("Sorry, no such Contract number exists in the database.", lblContractNo.Text, MessageBoxButtons.OK)
                    DisplayInfoMessage("IContractNo")
                    txtContractNo.Text = String.Empty
                    txtContractNo.Focus()
                    Return
                Case 1
                    'MsgBox("Sorry, this vehicle code does not belong to this estate. ", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    'MessageBox.Show("Sorry, this Contract number does not belong to this estate.", lblContractNo.Text, MessageBoxButtons.OK)
                    DisplayInfoMessage("IContractEstate")
                    txtContractNo.Text = String.Empty
                    txtContractNo.Focus()
                    Return

                    'Case False
                    '    'MsgBox("Contract number value does not exist in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                    '    MessageBox.Show("Contract number value does not exist in the database.", lblContractNo.Text, MessageBoxButtons.OK)
                    '    txtContractNo.Text = String.Empty
                    '    txtContractNo.Focus()
            End Select
        End If
    End Sub

    Private Sub ValidateKms(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartKms.Leave, txtEndKms.Leave

        Dim txtKms As TextBox = sender
        Dim lsValidKms As String = String.Empty
        Dim lSender As TextBox = DirectCast(sender, TextBox)

        '''''' ValidDataType
        If (txtStartKms.Text.Trim <> String.Empty And Not IsNumeric(txtStartKms.Text.Trim)) Then
            'MsgBox("Please input valid number in start kms field.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")

            'MessageBox.Show("This field should be numeric.", lblStartKms.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("INumeric")

            txtStartKms.Text = String.Empty
            txtTotalKms.Text = String.Empty
            txtStartKms.Focus()
            Return

        End If

        If (txtEndKms.Text.Trim <> String.Empty And Not IsNumeric(txtEndKms.Text.Trim)) Then

            'MsgBox("Please input valid number in end kms field.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MsgBox("This field should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MessageBox.Show("This field should be numeric.", lblEndKms.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("INumeric")
            txtEndKms.Text = String.Empty
            txtTotalKms.Text = String.Empty
            txtEndKms.Focus()
            Return

        End If

        ''''''''''''''''ValidDataTypeSize
        If txtStartKms.Text.Trim <> String.Empty And Not reDecimalPlaces.IsMatch(txtStartKms.Text.Trim) Then
            'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MsgBox("Start Kms - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MessageBox.Show("Please check that the precedence is 16 digits and the decimal is 2 digits.", lblStartKms.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("IKmsFormat")
            txtStartKms.Text = String.Empty
            txtTotalKms.Text = String.Empty
            txtStartKms.Focus()
            Return

        End If

        If txtEndKms.Text.Trim <> String.Empty And Not reDecimalPlaces.IsMatch(txtEndKms.Text.Trim) Then
            'MsgBox("Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MsgBox("End Kms - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
            'MessageBox.Show("Please check that the precedence is 16 digits and the decimal is 2 digits.", lblEndKms.Text, MessageBoxButtons.OK)
            DisplayInfoMessage("IKmsFormat")
            txtEndKms.Text = String.Empty
            txtTotalKms.Text = String.Empty
            txtEndKms.Focus()
            Return
        End If

        '''''IsBothHrsAndKrsAreEqual
        If txtStartKms.Text.Trim <> String.Empty And txtEndKms.Text.Trim <> String.Empty Then
            If txtStartKms.Text.Trim = txtEndKms.Text.Trim Then

                'MsgBox("Start kms value should not be equal to end kms value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")

                'MessageBox.Show("Start kms value should not be equal to end kms value.", lblStartKms.Text, MessageBoxButtons.OK)
                DisplayInfoMessage("IStartEndKmsEqual")

                Select Case DirectCast(sender, TextBox).Name
                    Case "txtStartKms"
                        txtStartKms.Text = String.Empty
                        'txtStartKms.Focus()

                    Case "txtEndKms"
                        txtEndKms.Text = String.Empty
                        'txtEndKms.Focus()
                End Select

                txtTotalKms.Text = String.Empty
                'txtEndKms.Focus()
                Return

            ElseIf Convert.ToDecimal(txtStartKms.Text.Trim) > Convert.ToDecimal(txtEndKms.Text.Trim) Then

                'MsgBox("Start kms value should be less than end kms value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                'MessageBox.Show("End kms value should be more than Start kms value.", lblStartKms.Text, MessageBoxButtons.OK)
                DisplayInfoMessage("IEndStartKms")
                txtTotalKms.Text = String.Empty
                'txtStartKms.Focus()
                Return

            End If
        End If

        ''''IsFieldsRequiredWhenItsPairIsNotEmpty
        'Select Case lSender.Name
        '    Case "txtStartKms"
        '        If txtStartKms.Text.Trim = String.Empty And txtEndKms.Text.Trim <> String.Empty Then
        '            MsgBox("Start kms required when end kms is not empty.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            txtStartKms.Focus()
        '            txtTotalKms.Text = String.Empty
        '            Return
        '        End If
        '    Case "txtEndKms"
        '        If txtStartKms.Text.Trim <> String.Empty And txtEndKms.Text.Trim = String.Empty Then
        '            MsgBox("Ems kms required when start kms is not empty.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        '            txtEndKms.Focus()
        '            txtTotalKms.Text = String.Empty
        '            Return
        '        End If
        'End Select


        ''''' Calculation
        If (txtKms.Text.Trim = String.Empty Or IsNumeric(txtKms.Text.Trim)) Then

            If txtStartKms.Text.Trim <> String.Empty And txtEndKms.Text <> String.Empty Then

                If CDec(txtEndKms.Text.Trim) > CDec(txtStartKms.Text.Trim) Then

                    txtTotalKms.Text = CDec(txtEndKms.Text.Trim) - CDec(txtStartKms.Text.Trim)
                End If
            Else
                txtTotalKms.Text = String.Empty
            End If

        End If
    End Sub


    Private Sub ValidateTime(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim lSender As TextBox = DirectCast(sender, TextBox)

        'If both are same time
        If lsStartTime.Trim <> String.Empty And lsEndTime.Trim <> String.Empty Then
            If lsStartTime.Trim = lsEndTime.Trim Then
                txtTotalHours.Text = String.Empty
                txtShift.Text = String.Empty
                Select Case DirectCast(sender, TextBox).Name
                    Case "txtStartTime"
                        lsStartTime = String.Empty
                        'txtStartTime.Focus()
                    Case "txtEndTime"
                        lsEndTime = String.Empty
                        'txtEndTime.Focus()
                End Select

                'MsgBox("Start Time should not be equal to End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                'MessageBox.Show("Start Time should be earlier than End Time.", lblStartTime.Text, MessageBoxButtons.OK)
                DisplayInfoMessage("IStartEndTime")

                Return

            ElseIf Convert.ToDateTime(lsStartTime.Trim) > Convert.ToDateTime(lsEndTime.Trim) Then

                'MsgBox("Start Time should be less than End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
                'MessageBox.Show("Start Time should be earlier than End Time.", lblStartTime.Text, MessageBoxButtons.OK)
                DisplayInfoMessage("IStartEndTime")
                txtTotalHours.Text = String.Empty

                Select Case DirectCast(sender, TextBox).Name
                    Case "txtStartTime"
                        '              txtStartTime.Focus()
                        'txtStartTime.Text = String.Empty
                    Case "txtEndTime"
                        '              txtEndTime.Focus()
                        'txtEndTime.Text = String.Empty
                End Select

                Return

            End If
        End If

        '''''Calculation
        If lsStartTime.Trim <> String.Empty And lsEndTime.Trim <> String.Empty Then
            If DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) < DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then

                txtTotalHours.Text = Convert.ToString(DateTime.Parse(lsEndTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(lsStartTime.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)

                Dim dtTime As DateTime = Convert.ToDateTime(String.Format("T = {0:T}", lsEndTime + ":00"))

                Select Case String.Format("{0:t tt}", dtTime.ToString("T"))
                    Case "am"
                        txtShift.Text = "Morning"
                        Exit Select
                    Case "pm"
                        txtShift.Text = "Afternoon"
                        Exit Select
                End Select

            Else
                txtTotalHours.Text = String.Empty
                txtShift.Text = String.Empty
                Return
            End If
        End If

    End Sub

    'Private Sub ValidateTime(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim lSender As TextBox = DirectCast(sender, TextBox)

    '    ''''ValidDataType
    '    If Not reValidateTime.IsMatch(lsStartTime.Trim) And lsStartTime.Trim <> String.Empty Then
    '        txtTotalHours.Text = String.Empty
    '        txtShift.Text = String.Empty

    '        'MsgBox("Invalid Start Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        MessageBox.Show("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", lblStartTime.Text, MessageBoxButtons.OK)

    '        txtStartTime.Text = String.Empty
    '        txtStartTime.Focus()

    '        Return
    '    End If

    '    If Not reValidateTime.IsMatch(txtEndTime.Text.Trim) And txtEndTime.Text.Trim <> String.Empty Then
    '        txtTotalHours.Text = String.Empty
    '        txtShift.Text = String.Empty

    '        'MsgBox("Invalid End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        MessageBox.Show("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", lblEndTime.Text, MessageBoxButtons.OK)
    '        txtEndTime.Text = String.Empty
    '        txtEndTime.Focus()
    '        Return
    '    End If

    '    ''''''''''ValidDataTypeSize
    '    If Not reValidateTime.IsMatch(txtStartTime.Text.Trim) And txtStartTime.Text.Trim <> String.Empty Then

    '        'MsgBox("Start Time - Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MsgBox("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        MessageBox.Show("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", lblStartTime.Text, MessageBoxButtons.OK)
    '        txtStartTime.Text = String.Empty
    '        txtTotalHours.Text = String.Empty
    '        txtShift.Text = String.Empty
    '        txtStartTime.Focus()
    '        Return
    '    End If

    '    If Not reValidateTime.IsMatch(txtEndTime.Text.Trim) And txtEndTime.Text.Trim <> String.Empty Then

    '        'MsgBox("End Time - Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MsgBox("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        MessageBox.Show("Invalid time format. Please input time in HH:MMam/pm [12hrs] format.", lblEndTime.Text, MessageBoxButtons.OK)
    '        txtEndTime.Text = String.Empty
    '        txtTotalHours.Text = String.Empty
    '        txtShift.Text = String.Empty
    '        txtEndTime.Focus()
    '        Return
    '    End If

    '    'If both are same time
    '    If txtStartTime.Text.Trim <> String.Empty And txtEndTime.Text.Trim <> String.Empty Then
    '        If txtStartTime.Text.Trim = txtEndTime.Text.Trim Then
    '            txtTotalHours.Text = String.Empty
    '            txtShift.Text = String.Empty
    '            Select Case DirectCast(sender, TextBox).Name
    '                Case "txtStartTime"
    '                    txtStartTime.Text = String.Empty
    '                    'txtStartTime.Focus()
    '                Case "txtEndTime"
    '                    txtEndTime.Text = String.Empty
    '                    'txtEndTime.Focus()
    '            End Select

    '            'MsgBox("Start Time should not be equal to End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '            MessageBox.Show("Start Time should be earlier than End Time.", lblStartTime.Text, MessageBoxButtons.OK)

    '            Return

    '        ElseIf Convert.ToDateTime(txtStartTime.Text.Trim) > Convert.ToDateTime(txtEndTime.Text.Trim) Then

    '            'MsgBox("Start Time should be less than End Time.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '            MessageBox.Show("Start Time should be earlier than End Time.", lblStartTime.Text, MessageBoxButtons.OK)
    '            txtTotalHours.Text = String.Empty

    '            Select Case DirectCast(sender, TextBox).Name
    '                Case "txtStartTime"
    '                    '              txtStartTime.Focus()
    '                    'txtStartTime.Text = String.Empty
    '                Case "txtEndTime"
    '                    '              txtEndTime.Focus()
    '                    'txtEndTime.Text = String.Empty
    '            End Select

    '            Return

    '        End If
    '    End If

    '    ''''''IsFieldsRequiredWhenItsPairIsNotEmpty
    '    'Select Case lSender.Name
    '    '    Case "txtStartTime"
    '    '        If txtStartTime.Text.Trim = String.Empty And txtEndTime.Text.Trim <> String.Empty Then
    '    '            MsgBox("Start time required when end time is not empty.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '    '            txtStartTime.Focus()
    '    '            Return
    '    '        End If
    '    '    Case "txtEndTime"
    '    '        If txtStartTime.Text.Trim <> String.Empty And txtEndTime.Text.Trim = String.Empty Then
    '    '            MsgBox("End time required when start time is not empty.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '    '            txtEndTime.Focus()
    '    '            Return
    '    '        End If
    '    'End Select

    '    '''''Calculation
    '    If txtStartTime.Text.Trim <> String.Empty And txtEndTime.Text.Trim <> String.Empty Then
    '        If DateTime.Parse(txtStartTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) < DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) Then

    '            txtTotalHours.Text = Convert.ToString(DateTime.Parse(txtEndTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault) - DateTime.Parse(txtStartTime.Text.Trim, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)).Substring(0, 5)
    '            Select Case txtStartTime.Text.Trim.Substring(txtStartTime.Text.Trim.Length - 2, 2).ToLower
    '                Case "am"
    '                    txtShift.Text = "Morning"
    '                    Exit Select
    '                Case "pm"
    '                    txtShift.Text = "Afternoon"
    '                    Exit Select
    '            End Select

    '        Else
    '            txtTotalHours.Text = String.Empty
    '            txtShift.Text = String.Empty
    '            Return
    '        End If
    '    End If

    'End Sub

    'Private Sub txtDIV_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDIV.Leave
    '    If ddlLocation.SelectedIndex = 0 Or ddlLocation.SelectedIndex = -1 Then
    '        If txtDIV.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("Division", txtDIV.Text.Trim)

    '            Dim isValid As Integer = General.ValidateForeignKeyFields("Division", txtDIV.Text.Trim)

    '            Select Case isValid
    '                Case 0
    '                    MsgBox("Sorry, no such DIV value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    txtDIV.Text = String.Empty
    '                    txtDIV.Focus()
    '                    'Case 1
    '                    '    EnableDivYopBlock("YOP", True)
    '                    '    txtYOP.Focus()
    '            End Select
    '        Else
    '            'EnableDivYopBlock("YOP", False)
    '            'EnableDivYopBlock("SubBlock", False)
    '        End If
    '    End If

    'End Sub

    'Private Sub txtYOP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYOP.Leave
    '    If ddlLocation.SelectedIndex = 0 Or ddlLocation.SelectedIndex = -1 Then

    '        If txtYOP.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("YOP", txtYOP.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("YOP", txtYOP.Text.Trim)
    '                Case 0
    '                    MsgBox("Sorry, no such YOP value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    txtYOP.Text = String.Empty
    '                    txtYOP.Focus()
    '                Case 1

    '                    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
    '                    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
    '                    Dim dtYop As DataTable
    '                    Dim lsErrorMsg As String = String.Empty

    '                    _SearchCodePPT.psSearchBy = "YOP"

    '                    _SearchCodePPT.psYOPCode = txtYOP.Text.Trim

    '                    If txtDIV.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
    '                    End If

    '                    _SearchCodePPT.psSearchTerm = "OnGo"
    '                    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '                    dtYop = _SearchCodeBOL.GetYearOfPlanning(_SearchCodePPT)

    '                    If dtYop.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty Then
    '                        lsErrorMsg = "Sorry, no such YOP value exists in the database."

    '                    End If

    '                    If dtYop.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty Then
    '                        lsErrorMsg = Environment.NewLine + "YOP value does not correspond with the DIV value."
    '                    End If

    '                    If lsErrorMsg <> String.Empty Then
    '                        MsgBox(lsErrorMsg, Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtYOP.Text = String.Empty
    '                        txtYOP.Focus()
    '                        '    EnableDivYopBlock("SubBlock", False)
    '                        'Else
    '                        '    EnableDivYopBlock("SubBlock", True)
    '                        '    txtSubBlock.Focus()
    '                    End If

    '            End Select
    '        Else
    '            'EnableDivYopBlock("SubBlock", False)
    '        End If
    '    End If
    'End Sub

    'Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave
    '    If ddlLocation.SelectedIndex = 0 Or ddlLocation.SelectedIndex = -1 Then
    '        If txtSubBlock.Text.Trim <> String.Empty Then
    '            'Select Case ValidateDivYopSubBlockAndContractNumber("Sub-Block", txtSubBlock.Text.Trim)
    '            Select Case General.ValidateForeignKeyFields("Sub-Block", txtSubBlock.Text.Trim)
    '                Case False
    '                    MsgBox("Sorry, no such Sub-Block value exists in the database.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                    txtSubBlock.Text = String.Empty
    '                    txtSubBlock.Focus()
    '                Case True

    '                    '  Dim dsSubBlockCodeAndName As DataSet
    '                    Dim _SearchCodePPT As SearchCodePPT = New SearchCodePPT
    '                    Dim _SearchCodeBOL As SearchCodeBOL = New SearchCodeBOL
    '                    Dim dtSubBlock As DataTable

    '                    If txtDIV.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psDIVCode = txtDIV.Text.Trim
    '                    End If

    '                    If txtYOP.Text.Trim <> String.Empty Then
    '                        _SearchCodePPT.psYOPCode = txtYOP.Text.Trim
    '                    End If

    '                    _SearchCodePPT.psSubBlockCode = txtSubBlock.Text.Trim
    '                    _SearchCodePPT.psSearchTerm = "OnGo"
    '                    _SearchCodePPT.psEstateID = GlobalPPT.strEstateID

    '                    dtSubBlock = _SearchCodeBOL.GetSubBlock(_SearchCodePPT)

    '                    If dtSubBlock.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim <> String.Empty Then
    '                        MsgBox("Sub-Block value does not correspond with the YOP and DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()

    '                    ElseIf dtSubBlock.Rows.Count = 0 And txtDIV.Text.Trim = String.Empty And txtYOP.Text.Trim <> String.Empty Then
    '                        MsgBox("Sub-Block value does not correspond with the YOP value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()

    '                    ElseIf dtSubBlock.Rows.Count = 0 And txtDIV.Text.Trim <> String.Empty And txtYOP.Text.Trim = String.Empty Then

    '                        MsgBox("Sub-Block value does not correspond with the DIV value.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '                        txtSubBlock.Focus()

    '                    End If

    '            End Select
    '        End If
    '    End If

    'End Sub

    'Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave

    '    If txtSubBlock.Text.Trim() <> String.Empty And txtSubBlock.Enabled = True Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.BlockName = txtSubBlock.Text.Trim()
    '        objSIV.BlockStatus = GlobalPPT.psAcctExpenditureType
    '        ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            'MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
    '            MessageBox.Show("Invalid SubBlock,Please Choose it from look up.", lblSubBlock.Text, MessageBoxButtons.OK)
    '            txtSubBlock.Text = String.Empty
    '            psSIVBlockID = String.Empty
    '            'lblSubBlockName.Text = String.Empty
    '            Me.txtDIV.Text = String.Empty
    '            psSIVDivID = String.Empty
    '            'Me.lblDivName.Text = String.Empty
    '            Me.txtYOP.Text = String.Empty
    '            'Me.lblYOPName.Text = String.Empty
    '            psSIVYopID = String.Empty
    '            txtSubBlock.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
    '                txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
    '            End If
    '            psSIVBlockID = ds.Tables(0).Rows(0).Item("BlockID")
    '            If ds.Tables(0).Rows(0).Item("BlockStatus") <> String.Empty Then
    '                'lblSubBlockName.Text = ds.Tables(0).Rows(0).Item("BlockStatus")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
    '                Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
    '            End If
    '            psSIVDivID = ds.Tables(0).Rows(0).Item("DivID")
    '            If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
    '                'Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
    '                Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("Name") <> String.Empty Then
    '                'Me.lblYOPName.Text = ds.Tables(0).Rows(0).Item("Name")
    '            End If
    '            psSIVYopID = ds.Tables(0).Rows(0).Item("YOPID")
    '        End If
    '    ElseIf txtSubBlock.Text.Trim() = String.Empty And txtSubBlock.Enabled = True Then
    '        ClearSubBlock()
    '    End If

    '    OperationalRequiredLabelColor()

    'End Sub

    Private Sub txtSubBlock_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave

        If txtSubBlock.Text.Trim() <> String.Empty And txtSubBlock.Enabled = True Then
            Dim ds As New DataSet
            Dim objSIV As New StoreIssueVoucherPPT
            objSIV.BlockName = txtSubBlock.Text.Trim()
            objSIV.BlockStatus = GlobalPPT.psAcctExpenditureType
            ds = StoreIssueVoucherBOL.GetSubBlock(objSIV, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

                'MsgBox(rm.GetString("ISubBlock"), Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, lblSubBlock.Text)
                DisplayInfoMessage("ISubBlock")
                'MessageBox.Show("Invalid SubBlock,Please Choose it from look up")
                txtSubBlock.Text = String.Empty
                Me.txtDIV.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                Exit Sub

            Else
                If ds.Tables(0).Rows(0).Item("BlockName") <> String.Empty Then
                    txtSubBlock.Text = ds.Tables(0).Rows(0).Item("BlockName")
                End If

                If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
                    Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
                End If

                If ds.Tables(0).Rows(0).Item("YOP") <> String.Empty Then
                    Me.txtYOP.Text = ds.Tables(0).Rows(0).Item("YOP")
                End If

                'Clear and Readonly vhno,vhdetailscostcode and odo reading if sub block left empty
            End If
        ElseIf txtSubBlock.Text.Trim() = String.Empty Then
            txtSubBlock.Text = String.Empty
            Me.txtDIV.Text = String.Empty
            Me.txtYOP.Text = String.Empty
        End If
    End Sub

    'Private Sub txtDiv_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDIV.Leave

    '    If txtDIV.Text.Trim() <> String.Empty Then
    '        Dim ds As New DataSet
    '        Dim objSIV As New StoreIssueVoucherPPT
    '        objSIV.Div = txtDIV.Text.Trim()
    '        objSIV.BlockID = psSIVBlockID
    '        ds = StoreIssueVoucherBOL.GetDIV(objSIV, "YES")
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            'MessageBox.Show("This block does not belongs to selected division, Please Choose it from look up")
    '            MessageBox.Show("This block does not belongs to selected division, Please Choose it from look up.", lblDIV.Text, MessageBoxButtons.OK)
    '            txtDIV.Text = String.Empty
    '            'lblDivName.Text = String.Empty
    '            psSIVDivID = String.Empty
    '            txtDIV.Focus()
    '            Exit Sub
    '        Else
    '            If ds.Tables(0).Rows(0).Item("Div") <> String.Empty Then
    '                Me.txtDIV.Text = ds.Tables(0).Rows(0).Item("Div")
    '            End If
    '            If ds.Tables(0).Rows(0).Item("DivName") <> String.Empty Then
    '                'Me.lblDivName.Text = ds.Tables(0).Rows(0).Item("DivName")
    '            End If
    '            psSIVDivID = ds.Tables(0).Rows(0).Item("DivID")
    '        End If
    '    Else
    '        txtDIV.Text = String.Empty
    '        'lblDivName.Text = String.Empty
    '        psSIVDivID = String.Empty
    '    End If

    '    OperationalRequiredLabelColor()

    'End Sub

    'Private Sub txtBunches_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If txtBunches.Text.Trim <> String.Empty And Not IsNumeric(txtBunches.Text.Trim) Then
    '        'MsgBox("Bunche’s value should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MessageBox.Show("This field should be numeric.", lblBunches.Text, MessageBoxButtons.OK)
    '        DisplayInfoMessage("INumeric")
    '        txtBunches.Focus()
    '        txtBunches.Text = String.Empty
    '        Return
    '    End If

    '    If Not reDecimalPlaces.IsMatch(txtBunches.Text.Trim) Then
    '        'MsgBox("Bunches - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MessageBox.Show("Please check that the precedence is 16 digits and the decimal is 2 digits.", lblBunches.Text, MessageBoxButtons.OK)
    '        DisplayInfoMessage("IKmsFormat")
    '        txtBunches.Focus()
    '        txtBunches.Text = String.Empty
    '        Return
    '    End If

    '    If txtBunches.Text.Trim <> String.Empty Then
    '        OperationalRequiredLabelColor()
    '    End If

    'End Sub

    'Private Sub txtActualBunchesMill_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If txtActualBunchesMill.Text.Trim <> String.Empty And Not IsNumeric(txtActualBunchesMill.Text.Trim) Then
    '        'MsgBox("Actual bunches mill value should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MessageBox.Show("This field should be numeric.", lblActualBunchesMill.Text, MessageBoxButtons.OK)
    '        DisplayInfoMessage("INumeric")
    '        txtActualBunchesMill.Focus()
    '        txtActualBunchesMill.Text = String.Empty
    '        Return
    '    End If

    '    If Not reDecimalPlaces.IsMatch(txtActualBunchesMill.Text.Trim) Then
    '        'MsgBox("Actual bunches mill - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MessageBox.Show("Please check that the precedence is 16 digits and the decimal is 2 digits.", lblActualBunchesMill.Text, MessageBoxButtons.OK)
    '        DisplayInfoMessage("IKmsFormat")
    '        txtActualBunchesMill.Focus()
    '        txtActualBunchesMill.Text = String.Empty
    '        Return
    '    End If

    'End Sub

    'Private Sub txtMillWeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtMillWeight.Text.Trim <> String.Empty And Not IsNumeric(txtMillWeight.Text.Trim) Then
    '        'MsgBox("Mill weight value should be numeric.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MessageBox.Show("This field should be numeric.", lblMillWeight.Text, MessageBoxButtons.OK)
    '        DisplayInfoMessage("INumeric")
    '        txtMillWeight.Text = String.Empty
    '        txtMillWeight.Focus()
    '        Return
    '    End If

    '    If Not reDecimalPlaces.IsMatch(txtMillWeight.Text.Trim) Then
    '        'MsgBox("Mill weight - Please check that the precedence is 16 digits and the decimal is 2 digits.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
    '        'MessageBox.Show("Please check that the precedence is 16 digits and the decimal is 2 digits.", lblMillWeight.Text, MessageBoxButtons.OK)
    '        DisplayInfoMessage("IKmsFormat")
    '        txtMillWeight.Text = String.Empty
    '        txtMillWeight.Focus()
    '        Return
    '    End If

    ' End Sub

    Private Sub ClearSubBlock()
        txtSubBlock.Text = String.Empty
        psSIVBlockID = String.Empty
        'lblSubBlockName.Text = String.Empty
        Me.txtDIV.Text = String.Empty
        psSIVDivID = String.Empty
        'Me.lblDivName.Text = String.Empty
        Me.txtYOP.Text = String.Empty
        'Me.lblYOPName.Text = String.Empty
        psSIVYopID = String.Empty
        ''
    End Sub

    'Private Sub EnableDivYopBlock(ByVal lsWhat As String, ByVal lbEnabl As Boolean)
    '    Select Case lsWhat
    '        Case "YOP"
    '            Select Case lbEnabl
    '                Case True
    '                    txtYOP.Enabled = True
    '                    ' btnLookUpYOP.Enabled = True
    '                Case False
    '                    txtYOP.Enabled = False
    '                    txtYOP.Text = String.Empty
    '                    'btnLookUpYOP.Enabled = False
    '            End Select

    '        Case "SubBlock"
    '            Select Case lbEnabl
    '                Case True
    '                    txtSubBlock.Enabled = True
    '                    btnLookUpSubBlock.Enabled = True
    '                Case False
    '                    txtSubBlock.Enabled = False
    '                    txtSubBlock.Text = String.Empty
    '                    btnLookUpSubBlock.Enabled = False
    '            End Select
    '    End Select
    'End Sub



#End Region

    'Private Sub dtpDateHarvested_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateHarvested.ValueChanged

    '    'If Not lbDateHarvested Then
    '    With dtpDateHarvested

    '        .Format = DateTimePickerFormat.Short
    '        .CustomFormat = "dd/MM/yyyy"
    '    End With
    '    'End If

    '    'lbDateHarvested = False

    'End Sub

    'Private Sub dtpDateCollected_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateCollected.ValueChanged

    '    'If Not lbDateCollected Then
    '    With dtpDateCollected
    '        .Format = DateTimePickerFormat.Short
    '        .CustomFormat = "dd/MM/yyyy"
    '    End With
    '    'End If

    'End Sub

    'Private Sub cmbStartHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartHrs.Leave
    '    If cmbStartMin.SelectedIndex > -1 And cmbStartHrs.SelectedIndex = -1 Then
    '        MessageBox.Show("This field is required when Start Minutes selected.", lblSerialNo.Text, MessageBoxButtons.OK)
    '        'cmbStartHrs.Focus()
    '    End If
    'End Sub

    'Private Sub cmbStartMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStartMin.Leave
    '    If cmbStartHrs.SelectedIndex > -1 And cmbStartMin.SelectedIndex = -1 Then
    '        MessageBox.Show("This field is required when Starting Hrs selected.", lblSerialNo.Text, MessageBoxButtons.OK)
    '        'cmbStartMin.Focus()
    '    End If
    'End Sub

    'Private Sub cmbEndHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEndHrs.Leave
    '    If cmbEndMin.SelectedIndex > -1 And cmbEndHrs.SelectedIndex = -1 Then
    '        MessageBox.Show("This field is required when End Minutes selected.", lblSerialNo.Text, MessageBoxButtons.OK)
    '        'cmbEndHrs.Focus()
    '    End If
    'End Sub

    'Private Sub cmbEndMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEndMin.Leave
    '    If cmbEndHrs.SelectedIndex > -1 And cmbEndMin.SelectedIndex = -1 Then
    '        MessageBox.Show("This field is required when End Hrs selected.", lblSerialNo.Text, MessageBoxButtons.OK)
    '        'cmbEndMin.Focus()
    '    End If
    'End Sub






    Private Sub tbVehicleRunningLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVehicleRunningLog.Click
        If dgvListOfVehicleLog.Rows.Count = 0 Then
            btnActivity.Enabled = False
        Else
            btnActivity.Enabled = True
        End If

    End Sub

    Private Sub btnActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivity.Click


        If dgvListOfVehicleLog.Rows.Count = 0 Then
            Return
        End If
        VHDistributeActivity()
    End Sub

    Private Sub VHDistributeActivity()

        Dim VehicleDistributionForm As VehicleDistributionFrm = New VehicleDistributionFrm

        VehicleDistributionForm.MdiParent = Me.MdiParent()
        VehicleDistributionForm.Dock = DockStyle.Fill

        VehicleDistributionForm.Show(dtpDate.Value, _
                                       txtVehicleCode.Text.Trim, _
                                        txtUOM.Text.Trim, _
                                        lsVHID, _
                                       Me.MdiParent)

    End Sub


    Private Sub btnNIK_Click(sender As System.Object, e As System.EventArgs) Handles btnNIK.Click
        Dim frmSubBlock As New NIKLookUp
        Dim result As DialogResult = frmSubBlock.ShowDialog()
        If frmSubBlock.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtNIK.Text = frmSubBlock._lNIK
            txtDriverName.Text = frmSubBlock._lEmpName
        End If
        'Dim SubBlockLookupForm As TeamLookUps = New TeamLookUps()
        'SubBlockLookupForm.ShowDialog()
        'If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
        '    txtNIK.Text = SubBlockLookupForm.MandorID
        '    txtDriverName.Text = SubBlockLookupForm.MandorEmpName
        'End If
    End Sub
End Class

