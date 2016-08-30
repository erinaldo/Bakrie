Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Imports System.Linq

Public Class ProductionRSSFrm

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    ' For the Time Calc of Shift Hours : Start
    Dim Start As DateTime = DateTime.Now
    Dim EndTime As DateTime = DateTime.Now
    Dim BreakTime As DateTime = DateTime.Now.Date
    ' For the Time Calc of Shift Hours : End

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionRSSFrm))

    Dim CurrentHeader As New ProductionRSSPPT

    Private Sub ProductionRSSFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        'MsgBox(PrivilegeError)
        'End If

        SetUICulture(GlobalPPT.strLang)
        TabContainerMain.SelectedTab = tabSearchView

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'sample
            'tabLPOContainer.TabPages("tabLPO").Text = rm.GetString("tabLPOContainer.TabPages(tabLPO).Text ")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        Try
            getObjectFromUI(CurrentHeader)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        SaveAll(CurrentHeader)

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Sub getObjectFromUI(objRSSPPT)

        With objRSSPPT

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtAssistant.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Assistant")
                Else
                    .Assistant = txtAssistant.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Assistant")
            End Try

            Try
                If txtStartTime.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Start Time")
                Else
                    .StartTime = txtStartTime.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Start Time")
            End Try

            Try
                If txtEndTime.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Stop Time")
                Else
                    .EndTime = txtEndTime.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Stop Time")
            End Try

            Try
                If txtBreakDownTime.Text.Trim() Is "" Then
                    Throw New Exception("Invalid BreakDown Time")
                Else
                    .BreakdownTime = txtBreakDownTime.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid BreakDown Time")
            End Try

            Try
                If txtShiftHours.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Shift Hours")
                Else
                    .ShiftHours = txtShiftHours.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Shift Hours")
            End Try

            Try
                If txtproduct.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type")
                Else
                    .ProductType = txtproduct.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type")
            End Try

            Try
                If txtstorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM")
                Else
                    .Storage = txtstorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM")
            End Try

            Try
                .LatexProcess = Decimal.Parse(txtLatexProcess.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Latex Process")
            End Try

        End With

    End Sub

    Private Sub SaveAll(objRSSPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim ds As New DataSet
        Try
            ProductionRSSBOL.Save(objRSSPPT)
            'DisplayInfoMessage("Msg04")
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnprod_Click(sender As System.Object, e As System.EventArgs) Handles btnprod.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtproduct.Text = frm.Result(0)
        End If
    End Sub

    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New ProductionRSSBOL
        Dim dt As New ObservableCollection(Of ProductionRSSPPT)

        Dim SearchObjPPT As ProductionRSSPPT = New ProductionRSSPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchAssistant.Text.Trim().Length > 0 Then
            SearchObjPPT.Assistant = txtSearchAssistant.Text.Trim
        End If

        Try
            dt = New ObservableCollection(Of ProductionRSSPPT)(objBOL.GetSearchResults(SearchObjPPT))
        Catch ex As Exception
            MsgBox("Search Failed.")
        End Try

        If Not dt Is Nothing Then
            If dt.Count <> 0 Then
                dgvView.AutoGenerateColumns = False
                Me.dgvView.DataSource = dt
                lblView.Visible = False
            Else
                dgvView.DataSource = Nothing  '''''clear the records from grid view
                lblView.Visible = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub dgvView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
    End Sub

    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    EditSelectedItem()
                End If
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Add()
    End Sub

    Private Sub Add()
        btnAddFlag = True
        CurrentHeader = New ProductionRSSPPT()
        ResetAllSaveContrls()
        Me.TabContainerMain.SelectedTab = tabSave
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtAssistant.Text = String.Empty
        txtStartTime.Text = String.Empty
        txtEndTime.Text = String.Empty
        txtBreakDownTime.Text = String.Empty
        txtShiftHours.Text = String.Empty
        txtLatexProcess.Text = String.Empty
        txtproduct.Text = String.Empty
        txtstorage.Text = String.Empty
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionRSSPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    'txtDocID.Text = CurrentHeader.ID
                    dtpDate.Text = CurrentHeader.DocDate
                    txtAssistant.Text = CurrentHeader.Assistant
                    txtStartTime.Text = CurrentHeader.StartTime
                    txtEndTime.Text = CurrentHeader.EndTime
                    txtBreakDownTime.Text = CurrentHeader.BreakdownTime
                    txtShiftHours.Text = CurrentHeader.ShiftHours
                    txtproduct.Text = CurrentHeader.ProductType
                    txtstorage.Text = CurrentHeader.Storage
                    txtLatexProcess.Text = CurrentHeader.LatexProcess
                    TabContainerMain.SelectedTab = tabSave

                End If
            End If
        End If
    End Sub

    Private Sub btnResetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnResetAll.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DeleteSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionRSSPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.Id
                    Try
                        ProductionRSSBOL.DeleteLastRSS(CurrentHeader)
                        'DisplayInfoMessage("Msg04")
                        MessageBox.Show("Deleted Successfully", "Important Message")
                        GridViewBind()
                    Catch ex As Exception
                        'DisplayInfoMessage("Error: " + ex.Message)
                        MessageBox.Show("Error: " + ex.Message, "Important Message")
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedItem()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub btnSearchSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchSource.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtstorage.Text = frm.Result(0)
        End If
    End Sub

#Region "Time Calculation For Shift Hours"
    ' TO DO : WHOEVER WORKING WITH THE TIME CALC FOR THE SHIFT HOURS START FROM HERE : ADD COMMENTS IF CHANGES ARE MADE
    ' Note: Make the Max Length property of the 3 TextBox's to 5
    Private Sub txtStartTime_Leave(sender As System.Object, e As System.EventArgs) Handles txtStartTime.Leave
        If txtStartTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtStartTime.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                'DisplayInfoMessage("Msg57")
                MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                txtStartTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            ElseIf strArr(0) Is "" Then
                strArr(0) = "00"
            End If

            If CInt(strArr(0)) >= 24 Then
                'DisplayInfoMessage("Msg179")
                MessageBox.Show("Start Time Can't be greater than or equal to 24", "Important Message")
                txtStartTime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    'DisplayInfoMessage("Msg57")
                    MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                    txtStartTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    'DisplayInfoMessage("Msg106")
                    MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ", "Important Message")
                    txtStartTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    'DisplayInfoMessage("Msg76")
                    MessageBox.Show("Minutes Value Cant be greater than 59 ", "Important Message")
                    txtStartTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    'DisplayInfoMessage("Msg77")
                    MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ", "Important Message")
                    txtStartTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtStartTime.Text = Hrs + ":" + Min
            Dim h As Integer = Integer.Parse(Hrs)
            Dim m As Integer = Integer.Parse(Min)
            Start = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
            If txtEndTime.Text <> "" Then
                If EndTime <= Start Then
                    Start = Start.AddDays(-1)
                End If
            End If
        End If
        timecalc()
    End Sub

    Private Sub txtStartTime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtStartTime.TextChanged
        Dim Value As String = txtStartTime.Text
        Dim strlen As Integer
        If txtStartTime.Text <> "" Then
            strlen = Len(txtStartTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStartTime.Text = Value.Substring(0, strlen - 1)
                    MessageBox.Show("Only Numeric", "Important Message")
                    txtStartTime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtEndTime_Leave(sender As System.Object, e As System.EventArgs) Handles txtEndTime.Leave
        If txtEndTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtEndTime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                'DisplayInfoMessage("Msg57")
                MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                txtEndTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            ElseIf strArr(0) Is "" Then
                strArr(0) = "00"
            End If
            If CInt(strArr(0)) >= 24 Then
                'DisplayInfoMessage("Msg180")
                MessageBox.Show("Stop Time Can't be greater than or equal to 24", "Important Message")
                txtEndTime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    'DisplayInfoMessage("Msg57")
                    MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                    txtEndTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    'DisplayInfoMessage("Msg106")
                    MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ", "Important Message")
                    txtEndTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    'DisplayInfoMessage("Msg76")
                    MessageBox.Show("Minutes Value Cant be greater than 59 ", "Important Message")
                    txtEndTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    'DisplayInfoMessage("Msg77")
                    MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ", "Important Message")
                    txtEndTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If


            End If

            txtEndTime.Text = Hrs + ":" + Min
            Dim h As Integer = Integer.Parse(Hrs)
            Dim m As Integer = Integer.Parse(Min)
            EndTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
            If txtStartTime.Text <> "" Then
                If EndTime <= Start Then
                    EndTime = EndTime.AddDays(1)
                End If
            End If

        End If
        timecalc()
    End Sub

    Private Sub txtEndTime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEndTime.TextChanged
        Dim Value As String = txtEndTime.Text
        Dim strlen As Integer
        If txtEndTime.Text <> "" Then
            strlen = Len(txtEndTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtEndTime.Text = Value.Substring(0, strlen - 1)
                    MessageBox.Show("Only Numeric", "Important Message")
                    txtEndTime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtBreakDownTime_Leave(sender As System.Object, e As System.EventArgs) Handles txtBreakDownTime.Leave
        If txtBreakDownTime.Text <> "" Then
            Dim va1 As String
            Dim va2 As String
            Dim val1 As String
            Dim val2 As String
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim str1 As String
            Dim strArr() As String
            str = txtBreakDownTime.Text
            strArr = str.Split(":")
            If strArr.Length = 2 Then
                va1 = strArr(0)
                va2 = strArr(1)
            Else
                va1 = strArr(0)
                va2 = "00"
            End If


            'Dim strArr1() As String = Array.CreateInstance(GetType(String), 0)

            'Dim strArr1() As String
            'str1 = break.Text
            'If str1 <> "" Then
            '    strArr1 = str1.Split(":")
            '    val1 = strArr1(0)
            '    val2 = strArr1(1)
            'Else
            '    val1 = "00"
            '    val2 = "00"
            'End If

            If strArr.Count > 2 Then
                'DisplayInfoMessage("Msg57")
                MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                txtBreakDownTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            ElseIf strArr(0) Is "" Then
                strArr(0) = "00"
                va1 = "00"
            End If
            If CInt(strArr(0)) >= 24 Then
                'DisplayInfoMessage("Msg182")
                MessageBox.Show("Break Time Can't be greater than or equal to 24", "Important Message")
                txtBreakDownTime.Focus()
                Exit Sub
            End If

            'If str1 <> "" Then
            '    'va2 = "00"
            '    If CInt(va1) >= CInt(val1) And CInt(va2) >= CInt(val2) Then
            '        'DisplayInfoMessage("Msg183")
            '        MessageBox.Show("Message 183")
            '        break.Focus()
            '        Exit Sub
            '    End If
            'End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    'DisplayInfoMessage("Msg57")
                    MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                    txtBreakDownTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    'DisplayInfoMessage("Msg106")
                    MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ", "Important Message")
                    txtBreakDownTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    'DisplayInfoMessage("Msg76")
                    MessageBox.Show("Minutes Value Cant be greater than 59 ", "Important Message")
                    txtBreakDownTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    'DisplayInfoMessage("Msg77")
                    MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ", "Important Message")
                    txtBreakDownTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If

            End If

            txtBreakDownTime.Text = Hrs + ":" + Min
            Dim h As Integer = Integer.Parse(Hrs)
            Dim m As Integer = Integer.Parse(Min)
            BreakTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
        Else
            txtBreakDownTime.Text = "00:00"
            Dim h As Integer = Integer.Parse("00")
            Dim m As Integer = Integer.Parse("00")
            BreakTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
        End If
        timecalc()
    End Sub

    Private Sub txtBreakDownTime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBreakDownTime.TextChanged
        Dim Value As String = txtBreakDownTime.Text
        Dim strlen As Integer
        If txtBreakDownTime.Text <> "" Then
            strlen = Len(txtBreakDownTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtBreakDownTime.Text = Value.Substring(0, strlen - 1)
                    MessageBox.Show("Only Numeric")
                    txtBreakDownTime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub timecalc()
        If txtstarttime.Text <> "" And txtEndTime.Text <> "" And txtBreakDownTime.Text <> "" Then
            Dim totMin As Long = DateAndTime.DateDiff(DateInterval.Minute, Start, EndTime)
            Dim bh As Long = BreakTime.Hour
            Dim bm As Long = BreakTime.Minute
            totMin -= (BreakTime.Hour * 60 + BreakTime.Minute)
            If totMin >= 60 Then
                Dim hsr As String
                Dim hsrArr() As String
                hsr = CStr(totMin / 60)
                hsrArr = hsr.Split(".")
                'txtShiftHours.Text = CStr(CInt(totMin / 60)) + ":" + CStr(totMin Mod 60)
                If CStr(totMin Mod 60).Length = 1 Then
                    txtShiftHours.Text = hsrArr(0) + ":0" + CStr(totMin Mod 60)
                Else
                    txtShiftHours.Text = hsrArr(0) + ":" + CStr(totMin Mod 60)
                End If
            ElseIf totMin >= 0 And totMin <= 60 Then
                If CStr(totMin Mod 60).Length = 1 Then
                    txtShiftHours.Text = "00:0" + CStr(totMin)
                Else
                    txtShiftHours.Text = "00:" + CStr(totMin)
                End If

            Else
                'MessageBox.Show("Break Time can't be greater than shift Hrs")
                'To do uncomment the below line if needed
                'shifthrs.Text = "00:00"
                'DisplayInfoMessage("Msg183")
                MessageBox.Show("BreakTime Can't Be Greater Than Shift Hrs ", "Important Message")
                txtBreakDownTime.Focus()
            End If
        Else
            txtShiftHours.Text = String.Empty
        End If
    End Sub

    ' TIME CALC FOR THE SHIFT HOURS END HERE
#End Region
End Class