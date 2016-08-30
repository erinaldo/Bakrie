Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class RainFallRiverLevelFrm
    Public saveFlag As Boolean = True
    Public isDecimal As Boolean
    Public lRainRiverId As String = String.Empty
    Public lHrs As String
    Public lmin As String
    Public lAMPM As String
    Public isModifierKey As Boolean
    Public lStartTime As String

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Dim timeFormat As New System.Text.RegularExpressions.Regex("([0-1]?[0-9]|2[0-3]):([0-5]?[0-9]):([0-5]?[0-9])")
    'Dim timeFormat As New System.Text.RegularExpressions.Regex("([0-1][0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RainFallRiverLevelFrm))
    Shadows mdiparent As New MDIParent
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If (txtRain.Text <> "" Or txtRiverLevel.Text <> "") And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsRetainFocus = True
                GlobalPPT.IsButtonClose = False
                Exit Sub
            End If
        Else
            Me.Close()
        End If



    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
       
        Reset()
        GlobalPPT.IsRetainFocus = False
    End Sub
    Public Sub Reset()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRainFallDate)
        txtRain.Text = ""
        txtRiverLevel.Text = ""
        dtpRainFallDate.Enabled = True
        chkRainFallDate.Checked = False
        dtpRainFallViewDate.Enabled = False
        StartDatefunction()
        'txtTimeEnter.Text = ""
        'edit by suraya 12-09-12
        'dtpRainFallDate.Value = Date.Today
        'dtpRainFallViewDate.Value = Date.Today
        'dtpRainFallDate.MaxDate = Date.Today
        'dtpRainFallViewDate.MaxDate = Date.Today
        dtpRainFallDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpRainFallViewDate.MinDate = GlobalPPT.FiscalYearFromDate

        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSave.Text = "Simpan"
        End If
        ''btnSave.Text = "Save"
        saveFlag = True
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        '   Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RainFallRiverLevelFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Function IsCheckValidation()
        If dtpRainFallDate.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show(" Please check Date", " Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If


        If Val(txtRain.Text) = 0 And Val(txtRiverLevel.Text) = 0 Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("Either Rain or River Level is Required ", " Rain", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRain.Focus()
            Return False
        End If
      
        'If txtTimeEnter.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please check Time", " Time Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtTimeEnter.Focus()
        '    Return False
        'End If
        Return True
    End Function

    Private Sub RainFallGridViewBind()
        Dim dt As New DataTable
        Dim objRFRPPT As New RainFallRiverPPT
        objRFRPPT.RDate = dtpRainFallDate.Value
        With objRFRPPT
            If chkRainFallDate.Checked = True Then
                dtpRainFallViewDate.Enabled = True
                .RDate = Format(Me.dtpRainFallViewDate.Value, "MM/dd/yyyy")
            Else
                dtpRainFallViewDate.Enabled = False
                .RDate = Nothing
            End If
        End With
        'objCPOPPT.CropYieldID = lCropYieldID

        dt = RainFallRiverBOL.GetRainFallDetails(objRFRPPT)

        If dt.Rows.Count <> 0 Then
            dgvRainFallView.AutoGenerateColumns = False
            Me.dgvRainFallView.DataSource = dt

        Else
            ClearGridView(dgvRainFallView) '''''clear the records from grid view

        End If

    End Sub

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then

            Dim objDataGridViewRow As New DataGridViewRow

            For iCount As Integer = 1 To grdname.Rows.Count
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            If grdname.Rows.Count = 1 Then
                grdname.Rows.RemoveAt(0)
            End If
        End If
    End Sub
   
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objRFRPPT As New RainFallRiverPPT
        Dim objRFRBOL As New RainFallRiverBOL

        If Not IsCheckValidation() Then Exit Sub
        'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If
        If saveFlag = True Then
            ''''For Production CPO''''
            lHrs = cmbCPOLogStartHrs.Text
            lmin = cmbCPOLogStartMin.Text
            'lAMPM = cmbCPOLogStartAMPM.Text

            objRFRPPT.RDate = dtpRainFallDate.Value
            objRFRPPT.RTime = lHrs + ":" + lmin

            ''''For Date Check''''''''''''''''''''''
            Dim objCheckDuplicateDate As Object = 0
            objCheckDuplicateDate = objRFRBOL.DuplicateDateCheck(objRFRPPT)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Time Check''''''''''''''''''''''
            Dim objCheckDuplicateTime As Object = 0
            objCheckDuplicateTime = objRFRBOL.DuplicateTimeCheck(objRFRPPT)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''

            If objCheckDuplicateDate = 0 And objCheckDuplicateTime = 0 Then
                DisplayInfoMessage("Msg3")
                ''MessageBox.Show("Record is available for the same date & time", "BSP")
                Exit Sub
            End If

            'If dtpRainFallDate.Value > Today.Date Then
            '    MessageBox.Show("Please select Today date or Previous date", "BSP")
            '    dtpRainFallDate.Focus()
            '    Exit Sub
            'End If

            If Val(txtRain.Text) + Val(txtRiverLevel.Text) = 0 Then
                DisplayInfoMessage("Msg4")
                ''MessageBox.Show("Enter value in Rain or River Level ,the value must be greater than Zero", "Rain & RiverLevel")
                txtRain.Focus()
                Exit Sub
            End If

            'If Val(txtRiverLevel.Text) = 0 Then
            '    MessageBox.Show("Nulls and Zero are not allowed in this field", "RiverLevel")
            '    txtRiverLevel.Focus()
            '    Exit Sub
            'End If


            lStartTime = " " & lHrs & ":" & lmin '& " " & lAMPM & " "
            objRFRPPT.RTime = lStartTime

            If txtRain.Text <> String.Empty Then
                objRFRPPT.Rain = txtRain.Text
            End If
            If dtpRainFallDate.Text <> String.Empty Then
                objRFRPPT.RDate = dtpRainFallDate.Value
            End If
            If txtRiverLevel.Text <> String.Empty Then
                objRFRPPT.RiverLevel = txtRiverLevel.Text
            End If

            RainFallRiverBOL.saveRainFallRiverDetails(objRFRPPT)
            RainFallGridViewBind()
            DisplayInfoMessage("Msg5")
            ''MsgBox("Data Successfully Saved")
            Reset()
            ' saveFlag = False
        ElseIf saveFlag = False Then

            objRFRPPT.RainRiverId = lRainRiverId

            lHrs = cmbCPOLogStartHrs.Text
            lmin = cmbCPOLogStartMin.Text
            ' lAMPM = cmbCPOLogStartAMPM.Text

            lStartTime = " " & lHrs & ":" & lmin ' & " " & lAMPM & " "
            objRFRPPT.RTime = lStartTime
            If txtRain.Text <> String.Empty Then
                objRFRPPT.Rain = txtRain.Text
            End If
            If dtpRainFallDate.Text <> String.Empty Then
                objRFRPPT.RDate = dtpRainFallDate.Value
            End If
            If txtRiverLevel.Text <> String.Empty Then
                objRFRPPT.RiverLevel = txtRiverLevel.Text
            End If

            RainFallRiverBOL.UpdateRainFallRiverDetails(objRFRPPT)
            DisplayInfoMessage("Msg6")
            ''MsgBox("Data Successfully Updated")

            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Save"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Simpan"
            End If
            ''btnSave.Text = "Save"
            RainFallGridViewBind()
            Reset()
            saveFlag = True

        End If
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub txtRain_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRain.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub
    Private Sub txtRain_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRain.KeyPress
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

    Private Sub txtRiverLevel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRiverLevel.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtRiverLevel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRiverLevel.KeyPress
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
    Private Sub EditRainFallView()
        Me.cmsRainFall.Visible = False
        Dim objRFRPPT As New RainFallRiverPPT
        Dim objRFRBOL As New RainFallRiverBOL
        Dim dt As New DataTable
        saveFlag = False
        Me.tcRainFallRiver.SelectedTab = tpRainFallRiverSave

        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSave.Enabled = True
            End If
        End If


        If dgvRainFallView.Rows.Count > 0 Then
            
            Dim str As String = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRDate").Value.ToString()
            Me.dtpRainFallDate.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            StartTime()
            lRainRiverId = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRainRiverId").Value.ToString()
            ' Me.dtpRainFallDate.Value = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRDate").Value
            'Me.txtTimeEnter.Text = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRTime").Value.ToString()
            'If Me.dgvRainFallView.SelectedRows(0).Cells("dgclRain").Value Is DBNull.Value Or dgvRainFallView.SelectedRows(0).Cells("dgclRain").Value = 0.0 Then
            '    txtRain.Text = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRain").Value.ToString()
            '    'Nothing
            'ElseIf Not Me.dgvRainFallView.SelectedRows(0).Cells("dgclRain").Value Is DBNull.Value Then
            txtRain.Text = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRain").Value.ToString()
            ' End If

            'If Me.dgvRainFallView.SelectedRows(0).Cells("dgclRiverLevel").Value Is DBNull.Value Or dgvRainFallView.SelectedRows(0).Cells("dgclRiverLevel").Value = 0.0 Then
            '    txtRiverLevel.Text = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRiverLevel").Value 'Nothing
            'ElseIf Not Me.dgvRainFallView.SelectedRows(0).Cells("dgclRiverLevel").Value Is DBNull.Value Then
            txtRiverLevel.Text = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRiverLevel").Value
            ' End If
            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Memperbarui"
            End If
            ''Me.btnSave.Text = "Update"
            RainFallGridViewBind()
            saveFlag = False

            If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                MsgBox(PrivilegeError)
            End If

        Else
            DisplayInfoMessage("Msg7")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Sub StartTime()
        Dim ltempStartTime As String
        Dim lsubStartStr As String
        ltempStartTime = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRTime").Value.ToString()
        lsubStartStr = ltempStartTime.Substring(0, 2)
      
        cmbCPOLogStartHrs.Text = lsubStartStr

        lsubStartStr = ""
        ltempStartTime = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRTime").Value.ToString()
        lsubStartStr = ltempStartTime.Substring(3, 2)
        cmbCPOLogStartMin.Text = lsubStartStr
        
    End Sub
    Private Sub DeleteRainFallVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RainFallRiverLevelFrm))
        Me.cmsRainFall.Visible = False

        Dim objRFRPPT As New RainFallRiverPPT
        Dim objRFRBOL As New RainFallRiverBOL
        Dim dt As New DataTable
        If dgvRainFallView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg8"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                objRFRPPT.RainRiverId = Me.dgvRainFallView.SelectedRows(0).Cells("dgclRainRiverId").Value.ToString()

                objRFRBOL.Delete_RainFallDetail(objRFRPPT)
                RainFallGridViewBind()
            End If
        Else
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
    Private Sub UpdateRainFallView()
        'If dgvCPOView.SelectedRows(0).Cells("gvstatus").Value <> "OPEN" And dgvCPOView.SelectedRows(0).Cells("gvstatus").Value <> "REJECTED" Then
        If dgvRainFallView.RowCount > 0 Then
            EditRainFallView()
            dtpRainFallDate.Enabled = False
        Else
            DisplayInfoMessage("Msg10")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        UpdateRainFallView()
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteRainFallVIew()
    End Sub
    Private Sub tcRainFallRiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRainFallRiver.Click
        If (txtRain.Text <> "" Or txtRiverLevel.Text <> "") And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcRainFallRiver.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                Reset()
                RainFallGridViewBind()
            End If
        Else
            Reset()
            RainFallGridViewBind()
        End If



    End Sub
    Private Sub txtTimeEnter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    'Private Sub txtTimeEnter_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim objRFRPPT As New RainFallRiverPPT
    '    Dim txtLength As Integer = txtTimeEnter.Text.Length
    '    If Not timeFormat.IsMatch(txtTimeEnter.Text) Then
    '        If txtTimeEnter.Text.Length < 2 And txtTimeEnter.Text.Length > 1 Then
    '            Dim temp As String = txtTimeEnter.Text + ":00:00"
    '            txtTimeEnter.Text = CDate(temp)
    '            objRFRPPT.RTime = CDate(temp)
    '        ElseIf txtTimeEnter.Text.Length >= 2 Then
    '            If txtTimeEnter.Text.Substring(txtLength - 1, txtLength - 1) = ":" Then
    '                MsgBox("Enter Correct Time Format as HH:MM:SS like " & FormatDateTime(TimeOfDay, DateFormat.LongTime))
    '            Else
    '                Dim temp As String = txtTimeEnter.Text + ":00:00"
    '                txtTimeEnter.Text = CDate(temp)
    '                objRFRPPT.RTime = CDate(temp)
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub cmsRainFall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsRainFall.Click
    '    'If cmsRainFall.Items(0).Selected = True Then
    '    '    MsgBox("Add selected")
    '    'End If

    'End Sub
    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub RainFallRiverLevelFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (txtRain.Text <> "" Or txtRiverLevel.Text <> "") And btnSave.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M94"

            End If
        End If
    End Sub
    Private Sub RainFallRiverLevelFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub RainFallRiverLevelFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        tcRainFallRiver.SelectedTab = tpRainFallView
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRainFallDate)
        'FormatDateTimePicker(dtpRainFallDate)
        'GlobalBOL.SetDateTimePicker(dtpRainFallDate)
        'dtpRainFallDate.Value = Date.Today
        'dtpRainFallViewDate.Value = Date.Today
        'dtpRainFallDate.MaxDate = Date.Today
        'dtpRainFallViewDate.MaxDate = Date.Today
        'StartDatefunction()

        'edit by suraya
        dtpRainFallDate.Format = DateTimePickerFormat.Custom
        dtpRainFallDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpRainFallDate)



        dtpRainFallViewDate.Format = DateTimePickerFormat.Custom
        dtpRainFallViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpRainFallViewDate)

        RainFallGridViewBind()


        'dtpRainFallViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpRainFallViewDate.MaxDate = Date.Today
    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.

            'tcRainFallRiver.TabPages("tpRainFallRiverSave").Text = rm.GetString("tcRainFallRiver.TabPages(tpRainFallRiverSave).Text")
            'tcRainFallRiver.TabPages("tpRainFallView").Text = rm.GetString("tcRainFallRiver.TabPages(tpRainFallView).Text")

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            ''lblDate.Text = rm.GetString("Date")
            ''lblTime.Text = rm.GetString("Time")
            ''lblRain.Text = rm.GetString("Rain")
            ''lblRiverLevel.Text = rm.GetString("River")
            btnReset.Text = rm.GetString("Reset")
            btnSave.Text = rm.GetString("Save")
            btnClose.Text = rm.GetString("Close")
            'Label45.Text = rm.GetString("SearchBy")
            'chkRainFallDate.Text = rm.GetString("Date")
            'dgvRainFallView.Columns("dgclRDate").HeaderText = rm.GetString("Date")
            'dgvRainFallView.Columns("dgclRTime").HeaderText = rm.GetString("Time")
            'dgvRainFallView.Columns("dgclRain").HeaderText = rm.GetString("Rain")
            'dgvRainFallView.Columns("dgclRiverLevel").HeaderText = rm.GetString("River")
            btnViewSearch.Text = rm.GetString("ViewSearch")
            ''btnView.Text = rm.GetString("ViewReports")
        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub StartDatefunction()

        If TimeOfDay.Hour < 10 Then
            cmbCPOLogStartHrs.Text = "0" + CStr(TimeOfDay.Hour)
        Else
            cmbCPOLogStartHrs.Text = TimeOfDay.Hour
        End If

      

        If TimeOfDay.Minute < 5 Then
            cmbCPOLogStartMin.Text = "00"
        ElseIf TimeOfDay.Minute >= 5 And TimeOfDay.Minute < 10 Then
            cmbCPOLogStartMin.Text = "05"
        ElseIf TimeOfDay.Minute >= 10 And TimeOfDay.Minute < 15 Then
            cmbCPOLogStartMin.Text = "10"
        ElseIf TimeOfDay.Minute >= 15 And TimeOfDay.Minute < 20 Then
            cmbCPOLogStartMin.Text = "15"
        ElseIf TimeOfDay.Minute >= 20 And TimeOfDay.Minute < 25 Then
            cmbCPOLogStartMin.Text = "20"
        ElseIf TimeOfDay.Minute >= 25 And TimeOfDay.Minute < 30 Then
            cmbCPOLogStartMin.Text = "25"
        ElseIf TimeOfDay.Minute >= 30 And TimeOfDay.Minute < 35 Then
            cmbCPOLogStartMin.Text = "30"
        ElseIf TimeOfDay.Minute >= 35 And TimeOfDay.Minute < 40 Then
            cmbCPOLogStartMin.Text = "35"
        ElseIf TimeOfDay.Minute >= 40 And TimeOfDay.Minute < 45 Then
            cmbCPOLogStartMin.Text = "40"
        ElseIf TimeOfDay.Minute >= 45 And TimeOfDay.Minute < 50 Then
            cmbCPOLogStartMin.Text = "45"
        ElseIf TimeOfDay.Minute >= 50 And TimeOfDay.Minute < 55 Then
            cmbCPOLogStartMin.Text = "50"
        ElseIf TimeOfDay.Minute >= 55 And TimeOfDay.Minute < 60 Then
            cmbCPOLogStartMin.Text = "55"
        End If

    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tcRainFallRiver.SelectedTab = tpRainFallRiverSave
        Reset()
    End Sub
    Private Sub dgvRainFallView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRainFallView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateRainFallView()
            End If
        End If


    End Sub
    Private Sub chkRainFallDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRainFallDate.CheckedChanged
        If chkRainFallDate.Checked = True Then
            dtpRainFallViewDate.Enabled = True
        Else
            dtpRainFallViewDate.Enabled = False
        End If
    End Sub
    Private Sub btnViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSearch.Click
        If chkRainFallDate.Checked = False Then
            DisplayInfoMessage("Msg11")
            ''MsgBox("Please Enter Criteria to Search!")
            RainFallGridViewBind()
            Exit Sub
        Else
            RainFallGridViewBind()
            If dgvRainFallView.RowCount = 0 Then
                DisplayInfoMessage("Msg12")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub
    Private Sub tcRainFallRiver_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tcRainFallRiver.Selected
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRainFallDate)
        ' Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpRainFallViewDate)
        'Reset()
        '
    End Sub
    Private Sub dgvRainFallView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRainFallView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateRainFallView()
            e.Handled = True
        End If
    End Sub

    Private Sub dtpRainFallDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRainFallDate.ValueChanged
        If dtpRainFallDate.Value > Today.Date Then
            dtpRainFallDate.Value = Date.Today
            Exit Sub
        Else
            Exit Sub
        End If
    End Sub

    
End Class