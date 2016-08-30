Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel

Public Class ProductionCenexNFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0
    ' For the Time Calc of Shift Hours : Start
    Dim Start As DateTime = DateTime.Now
    Dim EndTime As DateTime = DateTime.Now
    Dim BreakTime As DateTime = DateTime.Now.Date
    ' For the Time Calc of Shift Hours : End

    Dim CurrentHeader As New ProductionLogCenexPPT

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionCenexNFrm))

    Private Sub ProductionCenexNFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        TabContainerMain.SelectedTab = TabSearch
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

    ''' <summary>
    ''' Display message from resource file
    ''' </summary>
    ''' <param name="lsResourceKey"></param>
    ''' <remarks></remarks>
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim objLCenexPPT As New ProductionLogCenexPPT

        Try
            getObjectFromUI(objLCenexPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        SaveAll(objLCenexPPT)
        'DisplayInfoMessage("Msg02")
        MessageBox.Show("Saved Successfully", "Important Message")
        ResetAllSaveContrls()
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Sub getObjectFromUI(objLCenexPPT)

        With objLCenexPPT
            Try
                .ID = UpdateId
            Catch ex As Exception
                .ID = 0
            End Try

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtassistantcenex.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Assistant")
                Else
                    .LCNXAssistant = txtassistantcenex.Text.Trim()
                End If

            Catch ex As Exception
                Throw New Exception("Invalid Assistant")
            End Try

            Try
                If txtstarttime.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Start Time")
                Else
                    .LCNXStartTime = txtstarttime.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Start Time")
            End Try

            Try
                If txtstoptime.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Stop Time")
                Else
                    .LCNXStopTime = txtstoptime.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Stop Time")
            End Try

            Try
                If txtbreaktimecenex.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Breakdown Time")
                Else
                    .LCNXBdTime = txtbreaktimecenex.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Breakdown Time")
            End Try

            Try
                If txtshifthourscenex.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Shift Hrs")
                Else
                    .LCNXSHrs = txtshifthourscenex.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Shift Hrs")
            End Try

            Try
                If txtcnxprod.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type")
                Else
                    .LCNXProduct = txtcnxprod.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type")
            End Try

            Try
                If txtcnxstor.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM")
                Else
                    .LCNXStorage = txtcnxstor.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM")
            End Try

            Try
                .LCNXWet = Decimal.Parse(txtrecvwet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Received Wet")
            End Try

            Try
                .LCNXDry = txtrecvdry.Text.Trim()
            Catch ex As Exception
                Throw New Exception("Invalid Received Dry")
            End Try

            Try
                If txtrecvprod.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Received Product")
                Else
                    .LCNXProductR = txtrecvprod.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Received Product")
            End Try

            Try
                If txtrecvstor.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage Received")
                Else
                    .LCNXStorageR = txtrecvstor.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage Received")
            End Try

            Try
                .LCNXLPWet = Decimal.Parse(txtlatexprocwet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Latex Process Wet")
            End Try

            Try
                .LCNXLPDry = Decimal.Parse(txtlatexprocdry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Latex Process Dry")
            End Try

            Try
                .LCNXSKDry = Decimal.Parse(txtskimdry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Skim Dry")
            End Try

            Try
                .LCNXSLDry = Decimal.Parse(txtsludge.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Sludge")
            End Try

            Try
                .LCNXLM = Decimal.Parse(txtlimbah.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Limbah")
            End Try

            Try
                .LCNXWS = Decimal.Parse(txtwashing.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Washing")
            End Try

            Try
                .LCNXCNWet = Decimal.Parse(txtconcwet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Concentrated Wet")
            End Try

            Try
                .LCNXCNDry = Decimal.Parse(txtconcdry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Concentrated Dry")
            End Try

            Try
                .LCNXLG = Decimal.Parse(txtlossngain.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Loss/Gain")
            End Try

        End With
    End Sub

    Private Sub SaveAll(objLCenexPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim objLCenexDAL As New ProductionLogCenexDAL
        Dim ds As New DataSet
        ProductionLogCenexDAL.SaveLCNX(objLCenexPPT)

    End Sub

#Region "Time Calculation For Shift Hours"
    ' TO DO : WHOEVER WORKING WITH THE TIME CALC FOR THE SHIFT HOURS START FROM HERE : ADD COMMENTS IF CHANGES ARE MADE
    ' Note: Make the Max Length property of the 3 TextBox's to 5
    ' AGAILE VICTOR : 05/08/2016
    Private Sub txtstarttime_Leave(sender As System.Object, e As System.EventArgs) Handles txtstarttime.Leave
        If txtstarttime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtstarttime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                'DisplayInfoMessage("Msg57")
                MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                txtstarttime.Focus()
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
                txtstarttime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    'DisplayInfoMessage("Msg57")
                    MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                    txtstarttime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    'DisplayInfoMessage("Msg106")
                    MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ", "Important Message")
                    txtstarttime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    'DisplayInfoMessage("Msg76")
                    MessageBox.Show("Minutes Value Cant be greater than 59 ", "Important Message")
                    txtstarttime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    'DisplayInfoMessage("Msg77")
                    MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ", "Important Message")
                    txtstarttime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtstarttime.Text = Hrs + ":" + Min
            Dim h As Integer = Integer.Parse(Hrs)
            Dim m As Integer = Integer.Parse(Min)
            Start = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
            If txtstoptime.Text <> "" Then
                If EndTime <= Start Then
                    Start = Start.AddDays(-1)
                End If
            End If
        End If
        timecalc()
    End Sub

    Private Sub txtstarttime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtstarttime.TextChanged
        Dim Value As String = txtstarttime.Text
        Dim strlen As Integer
        If txtstarttime.Text <> "" Then
            strlen = Len(txtstarttime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtstarttime.Text = Value.Substring(0, strlen - 1)
                    MessageBox.Show("Only Numeric", "Important Message")
                    txtstarttime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtstoptime_Leave(sender As System.Object, e As System.EventArgs) Handles txtstoptime.Leave
        If txtstoptime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtstoptime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                'DisplayInfoMessage("Msg57")
                MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                txtstoptime.Focus()
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
                txtstoptime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    'DisplayInfoMessage("Msg57")
                    MessageBox.Show("User Can enter only HH or HH:MM format", "Important Message")
                    txtstoptime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    'DisplayInfoMessage("Msg106")
                    MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ", "Important Message")
                    txtstoptime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    'DisplayInfoMessage("Msg76")
                    MessageBox.Show("Minutes Value Cant be greater than 59 ", "Important Message")
                    txtstoptime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    'DisplayInfoMessage("Msg77")
                    MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ", "Important Message")
                    txtstoptime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If


            End If

            txtstoptime.Text = Hrs + ":" + Min
            Dim h As Integer = Integer.Parse(Hrs)
            Dim m As Integer = Integer.Parse(Min)
            EndTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
            If txtstarttime.Text <> "" Then
                If EndTime <= Start Then
                    EndTime = EndTime.AddDays(1)
                End If
            End If

        End If
        timecalc()
    End Sub

    Private Sub txtstoptime_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtstoptime.TextChanged
        Dim Value As String = txtstoptime.Text
        Dim strlen As Integer
        If txtstoptime.Text <> "" Then
            strlen = Len(txtstoptime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtstoptime.Text = Value.Substring(0, strlen - 1)
                    MessageBox.Show("Only Numeric", "Important Message")
                    txtstoptime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtbreaktimecenex_Leave(sender As System.Object, e As System.EventArgs) Handles txtbreaktimecenex.Leave
        If txtbreaktimecenex.Text <> "" Then
            Dim va1 As String
            Dim va2 As String
            Dim val1 As String
            Dim val2 As String
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim str1 As String
            Dim strArr() As String
            str = txtbreaktimecenex.Text
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
                txtbreaktimecenex.Focus()
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
                txtbreaktimecenex.Focus()
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
                    txtbreaktimecenex.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    'DisplayInfoMessage("Msg106")
                    MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ", "Important Message")
                    txtbreaktimecenex.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    'DisplayInfoMessage("Msg76")
                    MessageBox.Show("Minutes Value Cant be greater than 59 ", "Important Message")
                    txtbreaktimecenex.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    'DisplayInfoMessage("Msg77")
                    MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ", "Important Message")
                    txtbreaktimecenex.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If


            End If

            txtbreaktimecenex.Text = Hrs + ":" + Min
            Dim h As Integer = Integer.Parse(Hrs)
            Dim m As Integer = Integer.Parse(Min)
            BreakTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
        Else
            txtbreaktimecenex.Text = "00:00"
            Dim h As Integer = Integer.Parse("00")
            Dim m As Integer = Integer.Parse("00")
            BreakTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h, m, 0)
        End If
        timecalc()
    End Sub

    Private Sub txtbreaktimecenex_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtbreaktimecenex.TextChanged
        Dim Value As String = txtbreaktimecenex.Text
        Dim strlen As Integer
        If txtbreaktimecenex.Text <> "" Then
            strlen = Len(txtbreaktimecenex.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtbreaktimecenex.Text = Value.Substring(0, strlen - 1)
                    MessageBox.Show("Only Numeric")
                    txtbreaktimecenex.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub timecalc()
        If txtstarttime.Text <> "" And txtstoptime.Text <> "" And txtbreaktimecenex.Text <> "" Then
            Dim totMin As Long = DateAndTime.DateDiff(DateInterval.Minute, Start, EndTime)
            Dim bh As Long = BreakTime.Hour
            Dim bm As Long = BreakTime.Minute
            totMin -= (BreakTime.Hour * 60 + BreakTime.Minute)
            If totMin >= 60 Then
                Dim hsr As String
                Dim hsrArr() As String
                hsr = CStr(totMin / 60)
                hsrArr = hsr.Split(".")
                'txtshifthourscenex.Text = CStr(CInt(totMin / 60)) + ":" + CStr(totMin Mod 60)
                If CStr(totMin Mod 60).Length = 1 Then
                    txtshifthourscenex.Text = hsrArr(0) + ":0" + CStr(totMin Mod 60)
                Else
                    txtshifthourscenex.Text = hsrArr(0) + ":" + CStr(totMin Mod 60)
                End If
            ElseIf totMin >= 0 And totMin <= 60 Then
                If CStr(totMin Mod 60).Length = 1 Then
                    txtshifthourscenex.Text = "00:0" + CStr(totMin)
                Else
                    txtshifthourscenex.Text = "00:" + CStr(totMin)
                End If

            Else
                'MessageBox.Show("Break Time can't be grater than shift Hrs")
                'To do uncomment the below line if needed
                'shifthrs.Text = "00:00"
                'DisplayInfoMessage("Msg183")
                MessageBox.Show("BreakTime Can't Be Greater Than Shift Hrs ", "Important Message")
                txtbreaktimecenex.Focus()
            End If
        Else
            txtshifthourscenex.Text = String.Empty
        End If
    End Sub

    ' TIME CALC FOR THE SHIFT HOURS END HERE
#End Region

    Private Sub btncnxprod_Click(sender As System.Object, e As System.EventArgs) Handles btncnxprod.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "Cenex NC405/411")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtcnxprod.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btncnxstor_Click(sender As System.Object, e As System.EventArgs) Handles btncnxstor.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "Cenex NC405/411")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtcnxstor.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btncnxstorR_Click(sender As System.Object, e As System.EventArgs) Handles btncnxstorR.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'params(1) = New SqlParameter("@Form", "Cenex NC405/411")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtrecvstor.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btncnxprodR_Click(sender As System.Object, e As System.EventArgs) Handles btncnxprodR.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'params(1) = New SqlParameter("@Form", "Cenex NC405/411")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtrecvprod.Text = frm.Result(0)
        End If
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtassistantcenex.Text = String.Empty
        txtstarttime.Text = String.Empty
        txtstoptime.Text = String.Empty
        txtbreaktimecenex.Text = String.Empty
        txtshifthourscenex.Text = String.Empty
        txtcnxprod.Text = String.Empty
        txtcnxstor.Text = String.Empty
        txtrecvwet.Text = String.Empty
        txtrecvdry.Text = String.Empty
        txtrecvprod.Text = String.Empty
        txtrecvstor.Text = String.Empty
        txtlatexprocwet.Text = String.Empty
        txtlatexprocdry.Text = String.Empty
        txtskimdry.Text = String.Empty
        txtsludge.Text = String.Empty
        txtlimbah.Text = String.Empty
        txtwashing.Text = String.Empty
        txtconcwet.Text = String.Empty
        txtconcdry.Text = String.Empty
        txtlossngain.Text = String.Empty
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Add()
        ResetAllSaveContrls()
    End Sub
    Sub Add()
        Me.TabContainerMain.SelectedTab = TabSave
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub
    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New ProductionLogCenexBOL
        Dim dt As New ObservableCollection(Of ProductionLogCenexPPT)
        Dim SearchObjPPT As ProductionLogCenexPPT = New ProductionLogCenexPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchStor.Text.Trim().Length > 0 Then
            SearchObjPPT.LCNXStorage = txtSearchStor.Text.Trim
        End If
        If txtSearchProd.Text.Trim().Length > 0 Then
            SearchObjPPT.LCNXProduct = txtSearchProd.Text.Trim
        End If
        Try
            dt = New ObservableCollection(Of ProductionLogCenexPPT)(objBOL.GetSearchResults(SearchObjPPT))
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

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedItem()

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub DeleteSelectedItem()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionLogCenexPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        ProductionLogCenexBOL.DeleteLastPLCNX(CurrentHeader)
                        'DisplayInfoMessage("Msg04")
                        MessageBox.Show("Deleted Successfully", "Important Message")
                        GridViewBind()
                    Catch ex As Exception
                        MessageBox.Show("Error: " + ex.Message, "Important Message")
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
    End Sub
    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    EditSelectedItem()
                End If
            End If
        End If

    End Sub

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionLogCenexPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    'UpdateId = CurrentHeader.TransId
                    dtpDate.Text = CurrentHeader.DocDate
                    txtassistantcenex.Text = CurrentHeader.LCNXAssistant
                    txtstarttime.Text = CurrentHeader.LCNXStartTime
                    txtstoptime.Text = CurrentHeader.LCNXStopTime
                    txtbreaktimecenex.Text = CurrentHeader.LCNXBdTime
                    txtshifthourscenex.Text = CurrentHeader.LCNXSHrs
                    txtcnxprod.Text = CurrentHeader.LCNXProduct
                    txtcnxstor.Text = CurrentHeader.LCNXStorage
                    txtrecvwet.Text = CurrentHeader.LCNXWet
                    txtrecvdry.Text = CurrentHeader.LCNXDry
                    txtrecvprod.Text = CurrentHeader.LCNXProductR
                    txtrecvstor.Text = CurrentHeader.LCNXStorageR
                    txtlatexprocwet.Text = CurrentHeader.LCNXLPWet
                    txtlatexprocdry.Text = CurrentHeader.LCNXLPDry
                    txtskimdry.Text = CurrentHeader.LCNXSKDry
                    txtsludge.Text = CurrentHeader.LCNXSLDry
                    txtlimbah.Text = CurrentHeader.LCNXLM
                    txtwashing.Text = CurrentHeader.LCNXWS
                    txtconcwet.Text = CurrentHeader.LCNXCNWet
                    txtconcdry.Text = CurrentHeader.LCNXCNDry
                    txtlossngain.Text = CurrentHeader.LCNXLG
                    TabContainerMain.SelectedTab = TabSave

                End If
            End If
        End If


    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub
End Class