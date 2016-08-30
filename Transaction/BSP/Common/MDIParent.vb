Imports System.Windows.Forms
Imports Common_PPT
Imports Common_BOL
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Data.SqlClient
Imports Store_PPT
Imports Store_BOL
Imports Accounts_BOL
Imports System.IO
Imports Production_BOL
Imports System.Diagnostics.Process

Public Class MDIParent

    Dim aProcess As System.Diagnostics.Process
    Private _userPPT As New Common_PPT.GlobalPPT()
    Dim objGlobalPPT As GlobalPPT()

    Dim iModNo As Integer = 0
    Public Shared strMenuID As String = String.Empty
    Private iChildFormNumber As Integer
    'Public Shared IsRetainFocus As Boolean = False

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        iChildFormNumber += 1
        ChildForm.Text = "Window " & iChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Closing")
        Me.Close()
        'MessageBox.Show("Closing")

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Function ValidateSelectedMonthYear(ByVal ModID As Integer) As Boolean

        Dim obj As New EstateBOL
        Dim intAMonth As Integer

        Dim intAYear As Integer
        Dim dsActive As New DataSet
        Dim dsActiveID As New DataSet

        Dim strResult As String = ""

        'strResult = "A" 'Both Reports and Transaction

        Dim intSelectedMonth As Integer
        Dim intSelectedYear As Integer

        'Get active month & year for the selected module
        ModID = IIf(ModID = 5, 4, ModID) 'Get active month & year of WeighBridge for Accounts
        dsActive = obj.GetActiveYearMonth(GlobalPPT.strEstateID, If(ModID = 7, 6, ModID))

        If dsActive.Tables(0).Rows.Count > 0 Then

            intAYear = CType(dsActive.Tables(0).Rows(0).Item(0).ToString, Integer)
            intAMonth = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)

        End If

        intSelectedMonth = GlobalPPT.IntLoginMonth   '(lstAMonth.SelectedIndex) + 1
        intSelectedYear = GlobalPPT.intLoginYear  ' CType(lstAyear.SelectedValue.ToString, Integer)

        GlobalPPT.IntActiveMonth = intAMonth
        GlobalPPT.intActiveYear = intAYear

        'to display this module;s active month and year in status bar label.
        lblAyear.Text = MonthYear(GlobalPPT.IntActiveMonth) + "/" + GlobalPPT.intActiveYear.ToString()

        dsActiveID = obj.GetLoginActiveMonthYearID(GlobalPPT.strEstateID, If(ModID = 7, 6, ModID), intSelectedYear, intSelectedMonth)

        If dsActiveID.Tables(0).Rows.Count > 0 Then
            GlobalPPT.strActMthYearID = dsActiveID.Tables(0).Rows(0).Item("ActiveMonthYearID").ToString
        End If

        'AN07042009 - <<START>> Added by anand - Required to modify(verified on 06/11/2009)

        If ModID = 7 Then  ' Budget module
            If intSelectedYear = intAYear + 1 Then 'Login forward year (1 year greater allowed)
                strResult = "A"  'Transactions & Reports 
            ElseIf intSelectedYear <= intAYear Then
                strResult = "R"  'Reports
            ElseIf intSelectedYear > intAYear + 1 Then 'Login forward year for budget > active year +1
                strResult = "E"  'Not Allowed, "Empty" menu

            End If
        ElseIf ModID = 6 Then ' Accounts Module
            If intSelectedYear = intAYear + 1 Then 'Acccounts module allowed forward year any month
                strResult = "T"  'Transactions 
            ElseIf intSelectedYear > intAYear + 1 Then 'Not allowed greater then 1 year forward.
                strResult = "E"  'Not Allowed, "Empty menu" with messagebox. 
            ElseIf intSelectedYear = intAYear Then
                If intSelectedMonth < intAMonth Then
                    strResult = "R" 'Reports alone
                ElseIf intSelectedMonth = intAMonth Then
                    strResult = "A" ''Transaction & Reports alone
                ElseIf intSelectedMonth = intAMonth + 1 Then
                    strResult = "T"
                ElseIf intSelectedMonth > intAMonth + 1 Then
                    strResult = "E" 'Not Allowed for more then 1 month forward. 
                End If
            Else
                strResult = "R"
            End If
        ElseIf ModID = 8 Then
            strResult = "A"
        Else


            If intSelectedYear > intAYear Then 'Not allowed forward year or month for other modules
                strResult = "E"  'Not Allowed, "Empty menu" with messagebox. 
            ElseIf intSelectedYear < intAYear Then
                strResult = "R" 'Reports alone
            ElseIf intSelectedYear = intAYear Then
                If intSelectedMonth < intAMonth Then
                    strResult = "R" 'Reports alone
                ElseIf intSelectedMonth = intAMonth Then
                    strResult = "A" ''Transaction & Reports alone
                ElseIf intSelectedMonth >= intAMonth + 1 Then
                    strResult = "E" 'Not Allowed, "Empty menu" with messagebox. 
                End If

            End If

        End If
        'AN07042009 - <<END>> Added by anand - modify(verified on 06/11/2009)

        _userPPT.strMenuType = strResult

        Return True

    End Function

    Public Sub CloseAllChilds()
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub tsbtnCheckrollMDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCheckrollMDI.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        PopulateTreeViewControl(1)
        Me.iModNo = 1

    End Sub

    Private Sub tsbtnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnStore.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        PopulateTreeViewControl(2)
        Me.iModNo = 2


    End Sub

    Private Sub tsbtnVehicleMDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnVehicleMDI.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        PopulateTreeViewControl(3)
        Me.iModNo = 3

    End Sub

    Private Sub tsbtnWeighBridge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnWeighBridge.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        PopulateTreeViewControl(4)
        Me.iModNo = 4

    End Sub

    Private Sub tsbtnProductionMDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnProductionMDI.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        PopulateTreeViewControl(5)
        Me.iModNo = 5

    End Sub

    Private Sub tsbtnAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAccounts.Click


        'If MsgBox("you are about to navigate away from the current tab,you may lose unsaved data. are you sure? if yes please click ""ok"" or click ""cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '    GlobalPPT.IsRetainFocus = False
        'Else
        '    e.Cancel = True
        '    Me.Activate()
        '    GlobalPPT.IsRetainFocus = True

        '    'mdiparent.lblMenuName.Text = "IPR"
        'End If

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub

        lblmesg.Visible = False

        PopulateTreeViewControl(6)
        Me.iModNo = 6

    End Sub

    Private Sub tsbtnBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBudget.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        'tvMDIMenu.Nodes.Clear()
        PopulateTreeViewControl(7)
        Me.iModNo = 7

    End Sub

    Private Sub tsbtnAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdmin.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub
        lblmesg.Visible = False
        PopulateTreeViewControl(8)
        Me.iModNo = 8

    End Sub

    Private Sub tsbtnCentral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCentral.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub

        ' lblmesg.Visible = False

        tvMDIMenu.Nodes.Clear()

        ' PopulateTreeViewControl(7)
        'Dim childCentral As New MDICentral()
        'childCentral.MdiParent = Me
        'childCentral.Dock = DockStyle.Fill
        'childCentral.Show()

    End Sub

    Private Sub tsbtnSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSystem.Click

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub

        'lblmesg.Visible = False
        'Dim childSystem As New MDISystem()
        'childSystem.MdiParent = Me
        'childSystem.Dock = DockStyle.Fill
        'childSystem.Show()

    End Sub

    Private Sub tvMDIMenu_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)

    End Sub

    Private Sub MDIParent_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        KillAllExcels()
        aProcess = System.Diagnostics.Process.GetCurrentProcess()
        aProcess.Kill()

    End Sub

    Private Sub MDIParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        MessageBox.Show("Closing")
    End Sub




    Private Sub MDIParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        lblUserName.Text = GlobalPPT.strDisplayName
        lblEstateName.Text = GlobalPPT.strEstateName
        lblAyear.Text = MonthYear(GlobalPPT.IntActiveMonth) + "/" + GlobalPPT.intActiveYear.ToString()
        lblLoginYear.Text = MonthYear(GlobalPPT.IntLoginMonth) + "/" + GlobalPPT.intLoginYear.ToString()
        lblVersionNo.Text = "Version :" + "" & ConfigurationManager.AppSettings.Item("oVersionNo").ToString & ""

    End Sub

    Private Function MonthYear(ByVal number As Integer) As String
        Dim strMonth As String = String.Empty


        Select Case number
            Case 1
                strMonth = "Jan"
            Case 2
                strMonth = "Feb"
            Case 3
                strMonth = "Mar"
            Case 4
                strMonth = "Apr"
            Case 5
                strMonth = "May"
            Case 6
                strMonth = "Jun"
            Case 7
                strMonth = "Jul"
            Case 8
                strMonth = "Aug"
            Case 9
                strMonth = "Sep"
            Case 10
                strMonth = "Oct"
            Case 11
                strMonth = "Nov"
            Case 12
                strMonth = "Dec"
            Case Else
                Exit Select
        End Select
        Return strMonth

    End Function

    'Binding MenuGroup with Menu Items from database to TreeView Control

    Private Sub PopulateTreeViewControl(ByVal ModID As Integer)
        tvMDIMenu.ImageList = ImageList1
        Dim objMDIPPT As New MDIParentPPT
        'If ModID = 8 Then
        '    Exit Sub
        'End If
        'AN06112009 - If Budget module then should take accounts module's month, year.
        ValidateSelectedMonthYear(ModID)
        If _userPPT.strMenuType = "E" Then
            MsgBox("Forward year/month login not allowed for this module", MsgBoxStyle.OkOnly, "BSP")
            tvMDIMenu.Nodes.Clear()
            lblMenuName.Text = String.Empty
            Return
        End If

        objMDIPPT = MDIParentBOL.GetMenuInfo(New MDIParentPPT With {.ModID = ModID}, _userPPT.strMenuType)
        tvMDIMenu.Nodes.Clear()

        Dim parentNode As TreeNode = Nothing
        Dim treeValue As String = Nothing
        parentNode = New TreeNode(objMDIPPT.ModName)
        tvMDIMenu.Font = New Font("Verdana", 8, FontStyle.Regular)


        For i As Integer = 0 To objMDIPPT.arrMenuGroupList.Count - 1

            Dim childNode1 As New TreeNode(objMDIPPT.arrMenuGroupList.Item(i).ToString())
            childNode1.StateImageIndex = 1
            childNode1.SelectedImageIndex = 1
            childNode1.ForeColor = Color.DarkRed

            For intItem As Integer = 0 To objMDIPPT.RowCount - 1
                treeValue = MDIParentPPT.arrListMenu.GetValue(i, 1).ToString()
                If treeValue <> Nothing Then
                    If childNode1.Text = MDIParentPPT.arrListMenu.GetValue(intItem, 1).ToString() Then
                        Dim childNode2 As New TreeNode(MDIParentPPT.arrListMenu.GetValue(intItem, 0).ToString())
                        childNode2.Tag = MDIParentPPT.arrListMenu.GetValue(intItem, 2).ToString()
                        childNode2.SelectedImageIndex = 0

                        childNode1.Nodes.Add(childNode2)
                    End If

                End If
            Next
            parentNode.Nodes.Add(childNode1)

        Next
        tvMDIMenu.Nodes.Add(parentNode)
        tvMDIMenu.ExpandAll()
        parentNode.TreeView.SelectedNode = tvMDIMenu.Nodes(0).FirstNode 'parentNode.FirstNode

    End Sub

    Sub SetUICulture(ByVal culture As String)
        '  get a reference to the ResourceManager for this form

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MDIParent))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tsbtnAccounts.Text = rm.GetString("tsbtnAccounts.Text")
            tsbtnBudget.Text = rm.GetString("tsbtnBudget.Text")
            tsbtnCentral.Text = rm.GetString("tsbtnCentral.Text")
            tsbtnProductionMDI.Text = rm.GetString("tsbtnProductionMDI.Text")
            tsbtnStore.Text = rm.GetString("tsbtnStore.Text")
            tsbtnSystem.Text = rm.GetString("tsbtnSystem.Text")
            tsbtnVehicleMDI.Text = rm.GetString("tsbtnVehicleMDI.Text")
            tsbtnWeighBridge.Text = rm.GetString("tsbtnWeighBridge.Text")
            tsbtnCheckrollMDI.Text = rm.GetString("tsbtnCheckrollMDI.Text")
            lblUserName.Text = rm.GetString("lblUserName.Text")
            'UserMaster.Text = rm.GetString("UserMaster.Text")
            'RoleMaster.Text = rm.GetString("RoleMaster.Text")
            'DesignationMaster.Text = rm.GetString("DesignationMaster.Text")
            'RolePrivilege.Text = rm.GetString("RolePrivilege.Text")
            'ChangePwd.Text = rm.GetString("ChangePwd.Text")
            'Admin.Text = rm.GetString("Admin.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLogoutMDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogoutMDI.Click

        MDIClose()

    End Sub
    Private Sub MDIClose()

        CloseAllChilds()
        If GlobalPPT.IsRetainFocus = True Then Exit Sub

        Dim obj As New LoginFrm
        obj.Show()
        Me.Close()

    End Sub

    Private Sub tvMDIMenu_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMDIMenu.AfterSelect

        'If VehicleDistributionFrm.liIsTableAltered = True  Then

        '    VehicleDistributionFrm.Show ()
        '    Me .Close 

        'End If

        CloseAllChilds()

        'strMenuID = tvMDIMenu.SelectedNode.Tag
        'lblMenuName.Text = tvMDIMenu.SelectedNode.Text.Trim()

        If GlobalPPT.IsRetainFocus = False Then

            strMenuID = tvMDIMenu.SelectedNode.Tag
            lblMenuName.Text = tvMDIMenu.SelectedNode.Text.Trim()

        End If

        If Not strMenuID Is Nothing Then
            strMenuID = strMenuID.ToString().Trim()
        End If

        Dim objUserLoginBL As New Common_BOL.UserLoginBOL
        Select Case Me.iModNo

            Case 1

                If strMenuID = "M374" Then
                    'Dim childCR As New DAWT()
                    Dim childCR As New SalaryEmployee()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M243" Then
                    'Dim childCR As New DAWT()
                    Dim childCR As New DailyTeamActivity() 'Jum'at, 18 Sep 2009, 09:39 malam
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M587" Then
                    'Dim childCR As New DAWT()
                    Dim childCR As New PieceRate() 'Jum'at, 18 Sep 2009, 09:39 malam
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M244" Then
                    'Dim childCR As New DAWT()
                    GlobalPPT.strCategoryField = "OilPalm"
                    Dim childCR As New DailyAttendanceWithTeam() 'Jum'at, 18 Sep 2009, 09:39 malam
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M245" Then
                    'Dim childCR As New DAWT()
                    Dim childCR As New DailyAttendanceNoTeam() 'Jum'at, 18 Sep 2009, 09:39 malam
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M246" Then
                    Dim childCR As New DailyActivityDistributionWithTeam()
                    GlobalPPT.strCategoryField = String.Empty
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                End If

                If strMenuID = "M247" Then
                    Dim childCR As New AllowanceDeduction()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M248" Then
                    Dim childCR As New Censuss()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M249" Then
                    Dim childCR As New AdvancePayment()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M250" Then
                    Dim childCR As New RicePayment()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M584" Then
                    Dim childCR As New PieceRate()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M586" Then
                    Dim childCR As New TPHGrading()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M990" Then
                    Dim childCR As New EstateGrading()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M992" Then
                    Dim childCR As New ClassPenderes()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M991" Then
                    'Dim childCR As New DailyReceptionForRubber()
                    'childCR.MdiParent = Me
                    'childCR.Dock = DockStyle.Fill
                    'childCR.Show()
                    GlobalPPT.strCategoryField = "Rubber"
                    Dim childCR As New DailyAttendanceWithTeam() 'Jum'at, 18 Sep 2009, 09:39 malam
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                '===============================
                'Processing
                '===============================
                If strMenuID = "M202" Then
                    Dim childCR As New MonthEndProcess()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                ' Senin, 28 Dec 2009, 11:01
                ' By Dadang
                If strMenuID = "M283" Then
                    Dim childCR As New THR()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If
                ' END Senin, 28 Dec 2009, 11:01

                ' By Dadang
                ' Kamis, 31 Dec 2009, 12:10
                If strMenuID = "M251" Then

                    'MsgBox("Function Month End Closing NOT Allowed. Please contact administrator.", MsgBoxStyle.OkOnly, "BSP")

                    Dim childCR As New CheckrollMonthEndClosing()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                End If


                If strMenuID = "M910" Then
                    Dim childCR As New DailyAttendanceMandor()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                '========================================================
                'REPORT CHECKROLL
                '========================================================
                If strMenuID = "M252" Then
                    ''MsgBox("Mandor Report Under Construction")
                    ''
                    ''--------------------------
                    '' Rekap Laporan Mandor
                    ''--------------------------
                    ''
                    '' By Dadang Adi H
                    '' Jum'at, 08 Jan 2010, 22:33
                    'Dim childCR As New RekapLaporanMandor()
                    'childCR.MdiParent = Me
                    'childCR.Dock = DockStyle.Fill
                    'childCR.Show()

                    '----------------------------------
                    ' Rekap Laporan Mandor Team Panen
                    '----------------------------------
                    ' By Dadang
                    ' Jum'at, 08 Jan 2010, 22:40
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String


                    ReportName = "CRRekapLapMandorPanenReport"
                    report._Source = ReportName
                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M253" Then

                    Dim childCR As New DailyCostingRpt
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                End If

                If strMenuID = "M254" Then

                    Dim childCR As New MaterialUsageRptFrm()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M255" Then
                    'MsgBox("Advance Check Roll Report BHL/KHT Report Under Construction")
                    '----------------------------------
                    ' Advance Checkroll Report BHL/KHT
                    '----------------------------------
                    ' By Dadang
                    ' Senin, 21 Dec 2009, 10:10
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim Formula As String
                    Dim ReportName As String

                    Formula = "{CRAdvancePaymentReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "CRAdvancePaymentReport"
                    report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M256" Then
                    'MsgBox("Slip Advance Croll BHL/KHT Report Under Construction")
                    '-----------
                    ' Slip Advance Checkroll KHL/KHT
                    '-----------
                    ' By Dadang
                    ' Senin, 15 Feb 2010, 00:35
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRSlipAdvancePaymentReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M257" Then
                    'MsgBox("Rekapitulasi Advance Croll All Team BHL/KHT Report Under Construction")
                    '-------------------------------------------------
                    ' Rekapitulasi Advance Checkroll All Team BHL/KHT
                    '-------------------------------------------------
                    ' By Dadang
                    ' Senin, 21 Dec 2009, 10:17
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim Formula As String
                    Dim ReportName As String

                    Formula = "{CRRekapitulasiAdvancePaymentReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "CRRekapitulasiAdvancePaymentReport"
                    report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M258" Then
                    'MsgBox("Request Advance Salary Money KHL/KHT Report in progress")
                    ' By Dadang
                    ' Senin, 15 Feb 2010, 00:17
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRMoneyDenominationAdvanceCheckrollReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M259" Then
                    'MsgBox("Slip Salary KHL/KHT Report Under Construction")
                    '--------------------------------------
                    ' Slip Salary KHL/KHT Report
                    '--------------------------------------
                    ' Senin, 22 Feb 2010, 17:59
                    ' Place: Balikpapan
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRSlipSalaryReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M281" Then
                    'MsgBox("Money Denomination All Team BHL/KHT Report Under Construction")
                    '--------------------------
                    ' Money Denomination Report
                    '--------------------------
                    ' By Dadang Adi
                    '

                    ' Selasa, 16 Feb 2010, 15:13
                    'Dim DTLogin As DataTable
                    'Dim DTActive As DataTable

                    'Dim ToDateLogin As Nullable(Of Date)
                    'Dim ToDateActive As Nullable(Of Date)

                    'Dim TaskMonitorCompleted As String
                    'Try

                    '    DTLogin = CheckRoll_DAL.AdvancePayment_DAL.FiscalYear(GlobalPPT.intLoginYear, GlobalPPT.IntLoginMonth)
                    '    DTActive = CheckRoll_DAL.AdvancePayment_DAL.FiscalYear(GlobalPPT.intActiveYear, GlobalPPT.IntActiveMonth)

                    '    If DTLogin.Rows.Count > 0 Then
                    '        ToDateLogin = DTLogin.Rows(0).Item("ToDT")
                    '    End If

                    '    If DTActive.Rows.Count > 0 Then
                    '        ToDateActive = DTActive.Rows(0).Item("ToDT")
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    'If Not ToDateLogin Is Nothing And (Not ToDateActive Is Nothing) Then
                    '    If ToDateLogin = ToDateActive Then

                    '        ' By Dadang Adi
                    '        ' Jum'at, 01 Jan 2010, 21:51
                    '        TaskMonitorCompleted = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGETCompleted()

                    '        If String.IsNullOrEmpty(TaskMonitorCompleted) OrElse TaskMonitorCompleted = "N" Then
                    '            MessageBox.Show("Data already changed, please process [Monthly Processing] first to view Salary", _
                    '                            "Checkroll Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '            Return
                    '        End If
                    '        ' END Jum'at, 01 Jan 2010, 21:51
                    '    End If
                    'End If
                    '' END Selasa, 16 Feb 2010, 15:13

                    '' Senin, 15 Feb 2010, 01:04
                    ''Dim TaskMonitorCompleted As String
                    'TaskMonitorCompleted = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGETCompleted()

                    'If String.IsNullOrEmpty(TaskMonitorCompleted) OrElse TaskMonitorCompleted = "N" Then
                    '    MessageBox.Show("Data already changed, please process [Monthly Processing] first to view Report", _
                    '                    "Checkroll Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Return
                    'End If
                    '' END Senin, 15 Feb 2010, 01:04

                    ' Senin, 01 Feb 2010, 00:48
                    ' Place: Balikpapan
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRMoneyDenominationReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                'ANAND -24102009 - commented not required for now.
                'If strMenuID = "M139" Then
                '    MsgBox("Request Advance Salary Money BHL/KHT Report Under Construction")
                'End If

                If strMenuID = "M260" Then
                    ' Kamis, 18 Mar 2010, 14:32
                    '--------------------------
                    ' Daily Attendance Report
                    '--------------------------

                    'MsgBox("Daily Attendance Report in progress")
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRDAReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M261" Then
                    '----------------
                    ' Salary
                    '----------------

                    ' Selasa, 16 Feb 2010, 15:13
                    Dim DTLogin As DataTable
                    Dim DTActive As DataTable

                    Dim ToDateLogin As Nullable(Of Date)
                    Dim ToDateActive As Nullable(Of Date)

                    Try

                        DTLogin = CheckRoll_DAL.AdvancePayment_DAL.FiscalYear(GlobalPPT.intLoginYear, GlobalPPT.IntLoginMonth)
                        DTActive = CheckRoll_DAL.AdvancePayment_DAL.FiscalYear(GlobalPPT.intActiveYear, GlobalPPT.IntActiveMonth)

                        If DTLogin.Rows.Count > 0 Then
                            ToDateLogin = DTLogin.Rows(0).Item("ToDT")
                        End If

                        If DTActive.Rows.Count > 0 Then
                            ToDateActive = DTActive.Rows(0).Item("ToDT")
                        End If
                    Catch ex As Exception

                    End Try

                    If Not ToDateLogin Is Nothing And (Not ToDateActive Is Nothing) Then
                        If ToDateLogin = ToDateActive Then

                            ' By Dadang Adi
                            ' Jum'at, 01 Jan 2010, 21:51
                            Dim TaskMonitorCompleted As String
                            TaskMonitorCompleted = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGETCompleted()

                            If String.IsNullOrEmpty(TaskMonitorCompleted) OrElse TaskMonitorCompleted = "N" Then
                                MessageBox.Show("Data already changed, please process [Monthly Processing] first to view Salary", _
                                                "Checkroll Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            End If
                            ' END Jum'at, 01 Jan 2010, 21:51
                        End If
                    End If
                    ' END Selasa, 16 Feb 2010, 15:13

                    ' By Dadang
                    ' START Kamis, 10 Dec 2009, 18:15
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "Salary"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default
                    ' END Kamis, 10 Dec 2009, 18:15

                    'Dim childCR As New SalaryForm()
                    'childCR.MdiParent = Me
                    'childCR.Dock = DockStyle.Fill
                    'childCR.Show()
                End If

                If strMenuID = "M263" Then
                    'MsgBox("Rekapitulasi Gaji Karyawan Report Under Construction")
                    '------------------------------------
                    ' Rekapitulasi Gaji Karyawan Report
                    '------------------------------------
                    ' By Dadang Adi
                    '

                    ' Selasa, 16 Feb 2010, 15:13
                    Dim DTLogin As DataTable
                    Dim DTActive As DataTable

                    Dim ToDateLogin As Nullable(Of Date)
                    Dim ToDateActive As Nullable(Of Date)

                    Try

                        DTLogin = CheckRoll_DAL.AdvancePayment_DAL.FiscalYear(GlobalPPT.intLoginYear, GlobalPPT.IntLoginMonth)
                        DTActive = CheckRoll_DAL.AdvancePayment_DAL.FiscalYear(GlobalPPT.intActiveYear, GlobalPPT.IntActiveMonth)

                        If DTLogin.Rows.Count > 0 Then
                            ToDateLogin = DTLogin.Rows(0).Item("ToDT")
                        End If

                        If DTActive.Rows.Count > 0 Then
                            ToDateActive = DTActive.Rows(0).Item("ToDT")
                        End If
                    Catch ex As Exception

                    End Try

                    If Not ToDateLogin Is Nothing And (Not ToDateActive Is Nothing) Then
                        If ToDateLogin = ToDateActive Then

                            ' By Dadang Adi
                            ' Jum'at, 01 Jan 2010, 21:51
                            Dim TaskMonitorCompleted As String
                            TaskMonitorCompleted = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGETCompleted()

                            If String.IsNullOrEmpty(TaskMonitorCompleted) OrElse TaskMonitorCompleted = "N" Then
                                'MessageBox.Show("Data already changed, please process [Monthly Processing] first to view report", _
                                '                "Checkroll Report", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                Dim question As DialogResult
                                question = MessageBox.Show("Data already changed, please process [Monthly Processing] first to view report " & vbNewLine & "Continue to Generate Report?", _
                                                    "Checkroll Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                If question = DialogResult.No Then
                                    Return
                                End If
                            End If
                            ' END Jum'at, 01 Jan 2010, 21:51
                        End If
                    End If
                    ' END Selasa, 16 Feb 2010, 15:13

                    ' Senin, 01 Feb 2010, 01:02
                    ' Place: Balikpapan
                    'Dim TaskMonitorCompleted As String
                    'TaskMonitorCompleted = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGETCompleted()

                    'If String.IsNullOrEmpty(TaskMonitorCompleted) OrElse TaskMonitorCompleted = "N" Then
                    '    MessageBox.Show("Data already changed, please process [Monthly Processing] first to view Salary", _
                    '                    "Rekapitulasi Salary Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Return
                    'End If

                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRRekapitulasiGajiKaryawanReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                'If strMenuID = "M263" Then
                '    MsgBox("Rekapitulasi Gaji Karyawan All Team Report Under Construction")
                'End If

                If strMenuID = "M264" Then
                    'MsgBox("Over Time Payment Report Under Construction")
                    '-----------------------------------
                    ' Over Time Payment Report
                    '-----------------------------------
                    ' By Dadang
                    ' Kamis, 24 Dec 2009, 10:49
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    'Dim Formula As String
                    Dim ReportName As String

                    'Formula = "{CROvertimePaymentReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "CROvertimePaymentReport"
                    'report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M375" Then

                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    'Dim Formula As String
                    Dim ReportName As String

                    'Formula = "{CROvertimePaymentReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "CRPremiRubberReport"
                    'report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If



                If strMenuID = "M265" Then
                    'MsgBox("THR Payment Report Under Construction")
                    '--------------------------
                    ' THR Payment Report
                    '--------------------------
                    ' By Dadang Adi
                    '
                    ' Selasa, 29 Dec 2009, 17:41
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRTHRPaymentReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M347" Then
                    'MsgBox("Slip THR")
                    Dim childCR As New THREmployeeReport()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M348" Then
                    'MsgBox("Money Denomination THR Report")
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRMoneyDenominationTHRReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M266" Then
                    'MsgBox("Other Payment Report Under Construction")
                    '---------------------------------------------------------------------------
                    ' Working Distribution Report)
                    '---------------------------------------------------------------------------
                    ' By Dadang Adi
                    '
                    ' Ahad, 10 Jan 2010, 18:54
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CROtherPaymentReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M267" Then
                    
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRSalaryReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default

                End If

                If strMenuID = "M268" Then
                    'MsgBox("Working Distribution Report Under Construction")
                    '---------------------------------------------------------------------------
                    ' Working Distribution Report)
                    '---------------------------------------------------------------------------
                    ' By Dadang Adi
                    '
                    ' Ahad, 10 Jan 2010, 13:16
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim childCR As New WorkingDistributionReportFrm
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M269" Then

                    ' MsgBox("Distribusi Checkroll Report Under Construction")
                    Cursor = Cursors.WaitCursor

                    Dim childCR As New DistribusiCheckrollReport
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M270" Then
                    'MsgBox("Detail Premi Panen (Date/NIK) Report Under Construction")
                End If

                If strMenuID = "M271" Then
                    'MsgBox("Advance Rice Report Under Construction")
                    '--------------------------------------
                    ' Advance Rice Report
                    '--------------------------------------
                    ' Senin, 22 Feb 2010, 17:54
                    ' Place: Balikpapan
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRAdvanceRiceReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M272" Then

                    'MsgBox("Rekapitulasi Advance Croll All Team BHL/KHT Report Under Construction")
                    ' Rice Allowance Report
                    ' By Dadang
                    ' Senin, 21 Dec 2009, 10:17
                    ' Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim Formula As String
                    Dim ReportName As String

                    Formula = "{CRRiceAllowanceReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "CRRiceAllowanceReport"
                    report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default

                End If

                If strMenuID = "M273" Then
                    'MsgBox("ESTATE MONTHLY PRODUCTIVITY (EMPR) Report Under Construction")
                    '----------------------------------
                    ' Estate Monthly Production (EMPR)
                    '----------------------------------
                    ' By Dadang
                    ' Jum'at, 01 Jan 2010, 19:00
                    'Place: Kuala Lumpur
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    'Dim Formula As String
                    Dim ReportName As String

                    'Formula = "{CREstateMonthlyProductionReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "CREstateMonthlyProductionReport"
                    'report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M274" Then
                    'added by Stanley@07-09-2011
                    Dim childCR As New pph21KaryawanReport
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.plReport.CaptionText = "SPT Tahunan PPH PASAL 21"
                    childCR.Show()

                    'MsgBox("SPT Tahunan PPH21 Report Under Construction")
                End If

                If strMenuID = "M275" Then
                    Dim childCR As New pph21KaryawanReport
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.plReport.CaptionText = "PPH21 Karyawan"
                    childCR.Show()

                    'MsgBox("PPH21 Karyawan Report Under Construction")
                End If

                If strMenuID = "M276" Then
                    Dim childCR As New pph21KaryawanReport
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.plReport.CaptionText = "PPH21 Karyawan Yearly Reports"
                    childCR.Show()


                    'MsgBox("PPH21 Final Report Under Construction")
                End If

                If strMenuID = "M277" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRAnalysisHarvestingCostReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M278" Then
                    MsgBox("Harvesting report for the month Report Under Construction")
                End If

                If strMenuID = "M279" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim Formula As String
                    Dim ReportName As String

                    Formula = "{AttendanceSumReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
                    ReportName = "AttendanceSumReport"
                    report._Formula = Formula
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M280" Then
                    'MsgBox("Rekap Premi Mandor dan Krani Report Under Construction")
                    '--------------------------------------
                    ' Rekapitulation Premi Mandor And Krani
                    '--------------------------------------
                    ' Senin, 22 Feb 2010, 17:37
                    ' Place: Balikpapan
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRRecapitulationPremiMandorAndKraniReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M282" Then
                    ' By Dadang
                    ' START Jum'at, 11 Dec 2009, 01:08
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "DetailPremiReport"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default
                    ' END Jum'at, 11 Dec 2009, 01:08

                    'Dim childCR As New DetailPremiPanenForm()
                    'childCR.MdiParent = Me
                    'childCR.Dock = DockStyle.Fill
                    'childCR.Show()

                End If

                If strMenuID = "M285" Then
                    Dim childCR As New CropStatement()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                'PALANI -suraya27/9/2012
                'Weighing Bridge Fruit Weight Details
                If strMenuID = "M312" Then
                    lblmesg.Visible = False
                    'Dim childCR As New WBFruitWtDetails
                    Dim childCR As New AnalyHarvestingCost
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                    Cursor = Cursors.Arrow
                End If

                'palani
                'Checkroll Ledger
                If strMenuID = "M345" Then
                    lblmesg.Visible = False
                    Dim childAcc As New VehicleLedgerFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                    Cursor = Cursors.Arrow
                End If

                'stanley@04-07-2011
                If strMenuID = "M346" Then
                    
                    Cursor = Cursors.WaitCursor

                    Dim childCR As New DistribusiCheckrollSummaryReport
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M585" Then
                    'piece rate transaction report
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRPieceRateReport"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default

                End If

                If strMenuID = "M570" Then
                    Cursor = Cursors.WaitCursor

                    Dim childCR As New KeraniPanenForm
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M376" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRRekapPremiMandorKeraniDeres"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default

                End If

                If strMenuID = "M377" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRDetailPremiDeresReport"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default

                End If

                If strMenuID = "M378" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "AllowanceDeductionSummary"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default

                End If

                If strMenuID = "M379" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "RekapPremiMandor"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default

                End If

                If strMenuID = "M380" Then

                    Dim childCR As New DailyCostingRptByYop
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M381" Then

                    Dim childCR As New Bonus
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M382" Then

                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "RekapSalarySignature"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default
                End If

                If strMenuID = "M383" Then

                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRBonusPaymentReport"
                    report._Source = ReportName

                    report.ShowDialog()
                    Cursor = Cursors.Default
                End If

                If strMenuID = "M384" Then

                    Dim childCR As New BonusEmployeeReport()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M385" Then

                    Dim childCR As New DetailOTProcess()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If


                If strMenuID = "M386" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRAnalysisRubberCostReport"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M387" Then
                    Cursor = Cursors.WaitCursor

                    Dim report As New ViewReport()
                    Dim ReportName As String

                    ReportName = "CRDAMandor"
                    report._Source = ReportName

                    report.ShowDialog()

                    Cursor = Cursors.Default
                End If

                If strMenuID = "M389" Then
                    'Dim childCR As New DAWT()
                    Dim childCR As New SalaryEmployeeByDivision()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If

                If strMenuID = "M390" Then
                    'Dim childCR As New DAWT()
                    Dim childCR As New MoneyDenomByDivision()
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                End If
                'Continue Here

                If strMenuID = "M391" Then
                    Dim childCR As New PPH21Monthly
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()

                    'MsgBox("PPH21 Karyawan Report Under Construction")
                End If

                If strMenuID = "M392" Then
                    Dim childCR As New PPH21Yearly
                    childCR.MdiParent = Me
                    childCR.Dock = DockStyle.Fill
                    childCR.Show()
                    'MsgBox("PPH21 Karyawan Report Under Construction")
                End If
                'Store Menu Start
            Case 2

                'Dim parentNode As TreeNode = Nothing

                If strMenuID = "M1" Then

                    If GlobalPPT.IsRetainFocus = True Then
                        'parentNode.TreeView.SelectedNode = tvMDIMenu.Nodes(0).FirstNode
                        Exit Sub
                    End If

                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M1", UserMasterPPT.RoleID)
                    Dim childStore As New InternalPurchaseRequisitionFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()
                    ' IIf(childStore.IsAccessible=True,tvMDIMenu.Nodes(0).IsSelected 

                ElseIf strMenuID = "M164" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M164", UserMasterPPT.RoleID)
                    Dim childStore As New NonStockIPRFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M2" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M2", UserMasterPPT.RoleID)
                    Dim childStore As New LocalPuchaseOrderFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M3" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M3", UserMasterPPT.RoleID)
                    Dim childStore As New InternalServiceRequisitionFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M4" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M4", UserMasterPPT.RoleID)
                    Dim childStore As New EstateMillDeliveryNoteFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M5" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M5", UserMasterPPT.RoleID)
                    Dim childStore As New StockIssueInterfaceFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M6" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M6", UserMasterPPT.RoleID)
                    Dim childStore As New StoreIssueVoucherFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M7" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M7", UserMasterPPT.RoleID)
                    Dim childStore As New ReturnGoodsNoteFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M8" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M8", UserMasterPPT.RoleID)
                    Dim childStore As New InternalTransferNoteINFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M9" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M9", UserMasterPPT.RoleID)
                    Dim childStore As New InternalTransferNoteOUTFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M10" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M10", UserMasterPPT.RoleID)
                    Dim childStore As New StockAdjustmentFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()


                ElseIf strMenuID = "M18" Then

                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M18", UserMasterPPT.RoleID)
                    Dim childStore As New ConsignmentReceivedFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M118" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New IPRLogFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M310" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New IPRStatusfrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M311" Then


                    lblmesg.Visible = False
                    Dim childAcc As New StoreLedgerSummaryFrm
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                    Cursor = Cursors.Arrow

                ElseIf strMenuID = "M12" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New InternalPurchaseRequisitionApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M165" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New NonStockIPRApprovalFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M13" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New LocalPurchaseOrderApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M14" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New EstateMillDeliveryNoteApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M15" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New StoreIssueVoucherApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M16" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New ReturnGoodsNoteApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M17" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New StockAdjustmentApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M305" Then

                    lblmesg.Visible = False
                    Dim childStore As New ConsignmentReceivedApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                    'ElseIf strMenuID = "M18" Then

                    '    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    '    lblmesg.Visible = True
                    '    lblmesg.Text = objUserLoginBL.AccessUser("M18", UserMasterPPT.RoleID)
                    '    Dim childStore As New ConsignmentReceivedFrm()
                    '    childStore.MdiParent = Me
                    '    childStore.Dock = DockStyle.Fill
                    '    childStore.Show()

                ElseIf strMenuID = "M19" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim childStore As New clsStoreMonthlyProcessing()
                    If MsgBox("You are about to perform monthly processing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                        Me.Cursor = Cursors.WaitCursor
                        childStore.DOStoreMonthlyProcessing()
                        Me.Cursor = Cursors.Arrow
                    Else
                        Exit Sub
                    End If

                ElseIf strMenuID = "M20" Then

                    'If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = False
                    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    Dim dsApprovalCheck As New DataSet
                    dsApprovalCheck = StoreMonthEndClosingBOL.ApprovalCheck(objStoreMonthEndClosingPPT)

                    Dim lsTaskCheck As String = "N"
                    Dim dsTaskCheck As New DataSet
                    dsTaskCheck = StoreMonthEndClosingBOL.TaskConfigTaskCheckGet(objStoreMonthEndClosingPPT)
                    If dsTaskCheck.Tables(0).Rows.Count <> 0 Then
                        lsTaskCheck = dsTaskCheck.Tables(0).Rows(0).Item("CValue")
                    End If

                    If lsTaskCheck = "Y" Then
                        Dim childStore As New StoreMonthEndClosing
                        childStore.MdiParent = Me
                        childStore.Dock = DockStyle.Fill
                        childStore.Show()
                    Else
                        MessageBox.Show("Could not proceed with month end closing ... Please Check Task Config")
                    End If

                ElseIf strMenuID = "M21" Then

                    lblmesg.Visible = False
                    Dim childStore As New StoreIPRReportFrm() 'StoreIPRInTabReport() '
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()
                    'Dim childStore1 As New StoreIPRInTabReport()
                    '' childStore1.MdiParent = Me
                    ''childStore1.Dock = DockStyle.Fill
                    'childStore1.Show()

                ElseIf strMenuID = "M23" Then ' Receiving Summary

                    lblmesg.Visible = False
                    Dim childStore As New StoreGRNReportView
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M11" Then 'Summary Penerimaan

                    lblmesg.Visible = False
                    Dim childStore As New GRNReportInterfaceFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M284" Then

                    lblmesg.Visible = False
                    Dim childStore As New StoreSIVReportFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                    'ElseIf strMenuID = "M66" Then

                    '    'Written by Arul for Store Laporan Stock Report Enhancement Start
                    '    Dim dsStoreMonthlyProcessing As New DataSet
                    '    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    '    objStoreMonthEndClosingPPT.Task = "Store monthly processing"
                    '    dsStoreMonthlyProcessing = StoreMonthlyProcessingBOL.TaskMonitorStatusGet(objStoreMonthEndClosingPPT)
                    '    If Not dsStoreMonthlyProcessing Is Nothing Then
                    '        If dsStoreMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                    '            If MsgBox("Monthly processing not completed yet. Do you want to view the report anyway. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    '                Dim childStore As New StoreLaporanStockReportView
                    '                childStore.MdiParent = Me
                    '                childStore.Dock = DockStyle.Fill
                    '                childStore.Show()
                    '            Else
                    '                Exit Sub
                    '            End If
                    '        ElseIf dsStoreMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then
                    '            Dim childStore As New StoreLaporanStockReportView
                    '            childStore.MdiParent = Me
                    '            childStore.Dock = DockStyle.Fill
                    '            childStore.Show()
                    '        End If
                    '    End If
                    '    'Written by Arul for Store Laporan Stock Report Enhancement End


                ElseIf strMenuID = "M66" Then

                    lblmesg.Visible = False
                    Dim childStore As New LaporanStockReportInterface
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()


                    'ElseIf strMenuID = "M118" Then

                    '    lblmesg.Visible = False
                    '    Dim childStore As New IPRLogFrm()
                    '    childStore.MdiParent = Me
                    '    childStore.Dock = DockStyle.Fill
                    '    childStore.Show()

                ElseIf strMenuID = "M119" Then

                    lblmesg.Visible = False
                    Dim childStore As New InternalTransferNoteINApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M120" Then

                    lblmesg.Visible = False
                    Dim childStore As New InternalTransferNoteOUTApprovalFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                    'ElseIf strMenuID = "M164" Then

                    '    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    '    lblmesg.Visible = True
                    '    lblmesg.Text = objUserLoginBL.AccessUser("M164", UserMasterPPT.RoleID)
                    '    Dim childStore As New NonStockIPRFrm
                    '    childStore.MdiParent = Me
                    '    childStore.Dock = DockStyle.Fill
                    '    childStore.Show()

                    'ElseIf strMenuID = "M165" Then

                    '    lblmesg.Visible = False
                    '    Dim childStore As New NonStockIPRApprovalFrm
                    '    childStore.MdiParent = Me
                    '    childStore.Dock = DockStyle.Fill
                    '    childStore.Show()

                ElseIf strMenuID = "M286" Then

                    lblmesg.Visible = False
                    Dim childAcc As New VehicleLedgerFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                    Cursor = Cursors.Arrow

                ElseIf strMenuID = "M289" Then

                    lblmesg.Visible = False
                    Dim childStore As New SummaryPengeluaranReportInterfaceFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M294" Then

                    lblmesg.Visible = False
                    Dim childStore As New StoreISRReportFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M295" Then

                    lblmesg.Visible = False
                    Dim childStore As New StoreLPOReportFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M303" Then

                    lblmesg.Visible = False
                    Dim childStore As New StoreConsignmentstockmovementsReportFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M304" Then

                    lblmesg.Visible = False
                    Dim childStore As New StoreNonStockIPRReportFrm
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                    'ElseIf strMenuID = "M305" Then

                    '    lblmesg.Visible = False
                    '    Dim childStore As New ConsignmentReceivedApprovalFrm()
                    '    childStore.MdiParent = Me
                    '    childStore.Dock = DockStyle.Fill
                    '    childStore.Show()

                ElseIf strMenuID = "M306" Then

                    lblmesg.Visible = False
                    Dim childStore As New SummaryReportsFrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M308" Then

                    lblmesg.Visible = False
                    Dim childStore As New ITNINReportInterfacefrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                ElseIf strMenuID = "M309" Then

                    lblmesg.Visible = False
                    Dim childStore As New ITNOUTReportInterfacefrm()
                    childStore.MdiParent = Me
                    childStore.Dock = DockStyle.Fill
                    childStore.Show()

                    'ElseIf strMenuID = "M310" Then

                    '    lblmesg.Visible = False
                    '    Dim childStore As New IPRStatusfrm()
                    '    childStore.MdiParent = Me
                    '    childStore.Dock = DockStyle.Fill
                    '    childStore.Show()

                End If

                'Store Menu End

                'Vehicle Menu Start
            Case 3
                If strMenuID = "M69" Then
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M69", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New VehicleRunningLogFrm()
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If

                ElseIf strMenuID = "M70" Then
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M70", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New WorkShopLogFrm()
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If
                ElseIf strMenuID = "M71" Then
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M71", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New VehicleDistributionFrm()
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If
                ElseIf strMenuID = "M72" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M72", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New VehicleRunningLogPostingFrm
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If
                ElseIf strMenuID = "M73" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M73", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New WorkShopLogPostingFrm
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If

                ElseIf strMenuID = "M74" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M74", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New VehicleDistributionPostingFrm
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If

                ElseIf strMenuID = "M75" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M75", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then
                        Dim childVehicle As New VehicleMonthlyProcessingFrm
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                        childVehicle.Close()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If
                ElseIf strMenuID = "M76" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M76", UserMasterPPT.RoleID)
                    Dim _VehicleMonthlyProcessingBOL As New Vehicle_BOL.VehicleMonthlyProcessingBOL
                    Dim liIsClosed As Integer
                    liIsClosed = _VehicleMonthlyProcessingBOL.IsVehicleModuleRecordsApproved()
                    If liIsClosed = 0 Then

                        _VehicleMonthlyProcessingBOL = New Vehicle_BOL.VehicleMonthlyProcessingBOL

                        _VehicleMonthlyProcessingBOL.VehicleApprovalUpdate()

                        Dim childVehicle As New VehicleMonthEndClosingFrm
                        childVehicle.MdiParent = Me
                        childVehicle.Dock = DockStyle.Fill
                        childVehicle.Show()
                        'childVehicle.Close()
                    Else
                        Dim obj As New LoginFrm
                        obj.Show()
                        Me.Hide()
                    End If

                ElseIf strMenuID = "M79" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M79", UserMasterPPT.RoleID)
                    Dim childAcc As New DistribusiBiayaBengkelReportFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                    'lblmesg.Text = objUserLoginBL.AccessUser("M79", UserMasterPPT.RoleID)
                    'Dim childCR As New VehicleViewReport
                    'childCR.MdiParent = Me
                    'childCR.strReportName = "DistribusiBiayaBengkelsReport"
                    'childCR.Dock = DockStyle.Fill
                    'childCR.Show()
                ElseIf strMenuID = "M80" Then
                    lblmesg.Visible = False
                    'lblmesg.Text = objUserLoginBL.AccessUser("M80", UserMasterPPT.RoleID)
                    'Dim dsVehicleMonthlyProcessing As New DataSet
                    'Dim _VehicleMonthlyProcessingPPT As New Vehicle_PPT.VehicleMonthlyProcessingPPT
                    '_VehicleMonthlyProcessingPPT.psTask = "Vehicle monthly processing"
                    'dsVehicleMonthlyProcessing = Vehicle_BOL.VehicleMonthlyProcessingBOL.TaskMonitorStatusGet(_VehicleMonthlyProcessingPPT)
                    'If Not dsVehicleMonthlyProcessing Is Nothing And dsVehicleMonthlyProcessing.Tables(0).Rows.Count > 0 Then
                    '    If dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                    'If MsgBox("Monthly processing not completed yet. Do you want to view the report anyway. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Dim childAcc As New VehicleFarmTractorHEVehicleRunningLogReportFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()

                    ''Dim childCR As New VehicleViewReportInTabRpt
                    ''childCR.MdiParent = Me
                    ''childCR.strReportName = "VehicleFarmTractorHEVehicleRunningLogRpt"
                    ''childCR.Dock = DockStyle.Fill
                    ''childCR.Show()
                    'Else
                    '    Exit Sub
                    'End If
                    'ElseIf dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then

                    '    Dim childAcc As New VehicleFarmTractorHEVehicleRunningLogReportFrm()
                    '    childAcc.MdiParent = Me
                    '    childAcc.Dock = DockStyle.Fill
                    '    childAcc.Show()

                    '    'Dim childCR As New VehicleViewReportInTabRpt
                    '    'childCR.MdiParent = Me
                    '    'childCR.strReportName = "VehicleFarmTractorHEVehicleRunningLogRpt"
                    '    'childCR.Dock = DockStyle.Fill
                    '    'childCR.Show()
                    'End If
                    'End If

                ElseIf strMenuID = "M77" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M77", UserMasterPPT.RoleID)
                    'Dim dsVehicleMonthlyProcessing As New DataSet
                    'Dim _VehicleMonthlyProcessingPPT As New Vehicle_PPT.VehicleMonthlyProcessingPPT
                    '_VehicleMonthlyProcessingPPT.psTask = "Vehicle monthly processing"
                    'dsVehicleMonthlyProcessing = Vehicle_BOL.VehicleMonthlyProcessingBOL.TaskMonitorStatusGet(_VehicleMonthlyProcessingPPT)
                    'If Not dsVehicleMonthlyProcessing Is Nothing And dsVehicleMonthlyProcessing.Tables(0).Rows.Count > 0 Then
                    '    If dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                    '        If MsgBox("Monthly processing not completed yet. Do you want to view the report anyway. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    '            Dim childCR As New VehicleViewReport
                    '            childCR.MdiParent = Me
                    '            childCR.strReportName = "VehicleRunningExpenditureReport"
                    '            childCR.Dock = DockStyle.Fill
                    '            childCR.Show()
                    '        Else
                    '            Exit Sub
                    '        End If
                    '    ElseIf dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then
                    '        Dim childCR As New VehicleViewReport
                    '        childCR.MdiParent = Me
                    '        childCR.strReportName = "VehicleRunningExpenditureReport"
                    '        childCR.Dock = DockStyle.Fill
                    '        childCR.Show()
                    '    End If
                    'End If
                    Dim childAcc As New VehicleRunningExpenditureReportFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()

                ElseIf strMenuID = "M388" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M77", UserMasterPPT.RoleID)
                    'Dim dsVehicleMonthlyProcessing As New DataSet
                    'Dim _VehicleMonthlyProcessingPPT As New Vehicle_PPT.VehicleMonthlyProcessingPPT
                    '_VehicleMonthlyProcessingPPT.psTask = "Vehicle monthly processing"
                    'dsVehicleMonthlyProcessing = Vehicle_BOL.VehicleMonthlyProcessingBOL.TaskMonitorStatusGet(_VehicleMonthlyProcessingPPT)
                    'If Not dsVehicleMonthlyProcessing Is Nothing And dsVehicleMonthlyProcessing.Tables(0).Rows.Count > 0 Then
                    '    If dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                    '        If MsgBox("Monthly processing not completed yet. Do you want to view the report anyway. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    '            Dim childCR As New VehicleViewReport
                    '            childCR.MdiParent = Me
                    '            childCR.strReportName = "VehicleRunningExpenditureReport"
                    '            childCR.Dock = DockStyle.Fill
                    '            childCR.Show()
                    '        Else
                    '            Exit Sub
                    '        End If
                    '    ElseIf dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then
                    '        Dim childCR As New VehicleViewReport
                    '        childCR.MdiParent = Me
                    '        childCR.strReportName = "VehicleRunningExpenditureReport"
                    '        childCR.Dock = DockStyle.Fill
                    '        childCR.Show()
                    '    End If
                    'End If
                    Dim childAcc As New VehicleRunningExpenditureReportFrm2()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()



                ElseIf strMenuID = "M78" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M78", UserMasterPPT.RoleID)
                    'Dim dsVehicleMonthlyProcessing As New DataSet
                    'Dim _VehicleMonthlyProcessingPPT As New Vehicle_PPT.VehicleMonthlyProcessingPPT
                    '_VehicleMonthlyProcessingPPT.psTask = "Vehicle monthly processing"
                    'dsVehicleMonthlyProcessing = Vehicle_BOL.VehicleMonthlyProcessingBOL.TaskMonitorStatusGet(_VehicleMonthlyProcessingPPT)
                    'If Not dsVehicleMonthlyProcessing Is Nothing And dsVehicleMonthlyProcessing.Tables(0).Rows.Count > 0 Then
                    '    If dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                    '        If MsgBox("Monthly processing not completed yet. Do you want to view the report anyway. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    Dim childAcc As New VehicleLedgerFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                    Cursor = Cursors.Arrow



                    'Cursor = Cursors.WaitCursor
                    'Dim objLedRpt As New ReportFunctions
                    'objLedRpt.LedgerReport(3)
                    'Cursor = Cursors.Arrow

                    'Else
                    '    Exit Sub
                    'End If
                    '        ElseIf dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then
                    'LedgerReport(3)
                    '        End If
                    '    End If
                End If



                'Vehicle Menu End

                'WeighBridge Menu Start

            Case 4
                'commented by izzatul 02102012
                If strMenuID = "M81" Then
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M81", UserMasterPPT.RoleID)
                    Dim childWB As New WBTicketNoConfigurationFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                ElseIf strMenuID = "M82" Then
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M82", UserMasterPPT.RoleID)
                    Dim childWB As New WBWeighingInOutFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                ElseIf strMenuID = "M83" Then
                    lblmesg.Visible = False
                    'lblmesg.Text = objUserLoginBL.AccessUser("M85", UserMasterPPT.RoleID)
                    Dim childWB As New RecapitulationFFBReceivedFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()

                ElseIf strMenuID = "M84" Then
                    lblmesg.Visible = False
                    'lblmesg.Text = objUserLoginBL.AccessUser("M84", UserMasterPPT.RoleID)
                    Dim childWB As New WBWeighingTicketReportFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()

                ElseIf strMenuID = "M85" Then
                    lblmesg.Visible = False
                    'lblmesg.Text = objUserLoginBL.AccessUser("M85", UserMasterPPT.RoleID)
                    Dim childWB As New DailyReportFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                ElseIf strMenuID = "M704" Then
                    lblmesg.Visible = False
                    Dim childWB As New WBListingReportFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                ElseIf strMenuID = "M314" Then
                    lblmesg.Visible = False
                    Dim childWB As New WBAverageBunchWeight()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                ElseIf strMenuID = "M588" Then
                    lblmesg.Visible = False
                    Dim childWB As New WBCropReport()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                    'ADDED BY AGAILE ON 27/07/2016 FOR WEIGHBRIDGE RUBBER
                ElseIf strMenuID = "M820" Then
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M820", UserMasterPPT.RoleID)
                    Dim childWB As New WBWeighingInOutRubberFrm()
                    childWB.MdiParent = Me
                    childWB.Dock = DockStyle.Fill
                    childWB.Show()
                End If

                'WeighBridge Menu End
                'Production Menu Start

            Case 5


                If strMenuID = "M86" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M86", UserMasterPPT.RoleID)
                    'Dim childProd As New GradingFFBfrm()
                    Dim childProd As New GradingFFBNewfrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M87" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M87", UserMasterPPT.RoleID)
                    Dim childProd As New CPOProductionFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M88" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M88", UserMasterPPT.RoleID)
                    Dim childProd As New CPOProductionLogFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M89" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M89", UserMasterPPT.RoleID)
                    Dim childProd As New KernalProductionFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M90" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M90", UserMasterPPT.RoleID)
                    Dim childProd As New PKOProductionFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M91" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M91", UserMasterPPT.RoleID)
                    Dim childProd As New PKOProductionLogFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M93" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M93", UserMasterPPT.RoleID)
                    Dim childProd As New DispatchFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M94" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M94", UserMasterPPT.RoleID)
                    Dim childProd As New RainFallRiverLevelFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M287" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M287", UserMasterPPT.RoleID)
                    Dim childProd As New AdviceofCPOLoadingRptFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M288" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M288", UserMasterPPT.RoleID)
                    Dim childProd As New AdviceofPKOLoadingRptFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M96" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M96", UserMasterPPT.RoleID)
                    Dim childProd As New DailyProductionRptFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M98" Then
                    lblmesg.Visible = False
                    Dim childProd As New MonthlyProductionRptFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M95" Then
                    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    Dim lsTaskCheck As String = "N"
                    Dim dsTaskCheck As New DataSet
                    dsTaskCheck = StoreMonthEndClosingBOL.TaskConfigTaskCheckGet(objStoreMonthEndClosingPPT)
                    If dsTaskCheck.Tables(0).Rows.Count <> 0 Then
                        lsTaskCheck = dsTaskCheck.Tables(0).Rows(0).Item("CValue")
                    End If
                    If lsTaskCheck = "Y" Then
                        lblmesg.Visible = False
                        Dim childProd As New ProductionMonthEndClosing()
                        childProd.MdiParent = Me
                        childProd.Dock = DockStyle.Fill
                        childProd.Show()
                    Else
                        MessageBox.Show("Could not proceed Month End Closing ... Please Check Task Config")
                    End If
                ElseIf strMenuID = "M290" Then
                    lblmesg.Visible = False
                    Dim childProd As New DispatchCPOPKORptFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M292" Then
                    lblmesg.Visible = False
                    Dim childProd As New DispatchAnalysisAndStockRptFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M290" Then
                    lblmesg.Visible = False
                    Cursor = Cursors.WaitCursor
                    Dim objRpt As New ReportFunctions
                    objRpt.DispatchCPOPKOReport()
                    Cursor = Cursors.Arrow
                ElseIf strMenuID = "M291" Then
                    lblmesg.Visible = False
                    Dim childProd As New ProductionKCPReportFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M296" Then
                    lblmesg.Visible = False
                    Dim childProd As New DailyProductionReportKCPFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M293" Then
                    lblmesg.Visible = False
                    Dim childProd As New ProductionCPOReportFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M297" Then
                    MessageBox.Show("Work in progress", "Weekly Grading")
                ElseIf strMenuID = "M298" Then
                    MessageBox.Show("Work in progress", "Kernel Intake Statement")
                ElseIf strMenuID = "M299" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M299", UserMasterPPT.RoleID)
                    Dim childProd As New DailyQualityProductionRptFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M92" Then
                    lblmesg.Visible = True
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Text = objUserLoginBL.AccessUser("M92", UserMasterPPT.RoleID)
                    Dim childProd As New LaboratoryAnalysisFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()

                ElseIf strMenuID = "M307" Then
                    lblmesg.Visible = False
                    Dim childProd As New GradingReportInterfaceFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()

                ElseIf strMenuID = "M97" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M97", UserMasterPPT.RoleID)
                    Dim childProd As New LoadingCPOFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M420" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M420", UserMasterPPT.RoleID)
                    Dim childProd As New TranshipmentCPOFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M421" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    Dim childProd As New LoadingPKOFrm
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M421", UserMasterPPT.RoleID)
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M422" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M422", UserMasterPPT.RoleID)
                    Dim childProd As New TranshipmentPKOFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M423" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M423", UserMasterPPT.RoleID)
                    Dim childProd As New TransferKernelFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M424" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M424", UserMasterPPT.RoleID)
                    Dim childProd As New TranshipmentKernelFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M425" Then
                    lblmesg.Visible = False
                    Dim childProd As New MonthGradingInterfaceFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M99" Then
                    lblmesg.Visible = False
                    Dim childProd As New MillworkinghrscpoReportInterfacefrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()

                ElseIf strMenuID = "M193" Then
                    lblmesg.Visible = False
                    Dim childProd As New DispatchDetailsRptFrm
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                ElseIf strMenuID = "M194" Then
                    lblmesg.Visible = False
                    Dim childProd As New KernelInTakeStatementRptInterface
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION LOG CRUMB RUBBER
                ElseIf strMenuID = "M947" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M947", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionCrumbRubberFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY JANE FOR SHOWING THE FORM RAW MATERIAL STORAGE RUBBER
                ElseIf strMenuID = "M944" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M944", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionRawMaterialStorageFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY JANE FOR SHOWING THE FORM PRODUCTION LOG BROWN CREEP
                ElseIf strMenuID = "M949" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M949", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionBrownCreepFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION LOG BSR
                ElseIf strMenuID = "M948" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M948", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionBsrFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY JANE FOR SHOWING THE FORM PRODUCTION LOG RSS
                ElseIf strMenuID = "M950" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M950", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionRSSFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION LOG SIR
                ElseIf strMenuID = "M951" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M951", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionSirNFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY JANE FOR SHOWING THE FORM PRODUCTION LOG CENEX
                ElseIf strMenuID = "M946" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M946", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionCenexNFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY JANE FOR SHOWING THE FORM WIP
                ElseIf strMenuID = "M953" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M953", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionWIPFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION FINISH GOODS
                ElseIf strMenuID = "M954" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M954", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionFinishGoodsFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION TRANSFER
                ElseIf strMenuID = "M952" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M952", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionTransferFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION OFFGRADE
                ElseIf strMenuID = "M945" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M945", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionOffgradeFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION QCD ANALYSIS RAW MATERIAL
                ElseIf strMenuID = "M955" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M955", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionQcdRawFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION QCD ANALYSIS OTHER
                ElseIf strMenuID = "M956" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M956", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionQcdOtherFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION QCD FINISHED CENEX
                ElseIf strMenuID = "M957" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M957", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionQcdCenexFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                    'ADDED BY AGAILE FOR SHOWING THE PRODUCTION QCD FINISHED CRUMB
                ElseIf strMenuID = "M958" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M958", UserMasterPPT.RoleID)
                    Dim childProd As New ProductionQcdCrumbFrm()
                    childProd.MdiParent = Me
                    childProd.Dock = DockStyle.Fill
                    childProd.Show()
                End If




                'Production Menu End


                'Accounts Menu Start
            Case 6
                If strMenuID = "M101" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M101", UserMasterPPT.RoleID)
                    Dim childAcc As New LedgerSetupfrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M102" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M102", UserMasterPPT.RoleID)
                    Dim childAcc As New AccountBatchFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M103" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M103", UserMasterPPT.RoleID)
                    Dim childAcc As New JournalFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M104" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M104", UserMasterPPT.RoleID)
                    Dim childAcc As New PettyCashReceiptFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M105" Then
                    If GlobalPPT.IsRetainFocus = True Then Exit Sub
                    lblmesg.Visible = True
                    lblmesg.Text = objUserLoginBL.AccessUser("M105", UserMasterPPT.RoleID)
                    Dim childAcc As New PettyCashPaymentFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M106" Then
                    lblmesg.Visible = False
                    Dim childAcc As New CashReconcilationReport()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()

                ElseIf strMenuID = "M107" Then
                    lblmesg.Visible = False
                    'lblmesg.Text = objUserLoginBL.AccessUser("M107", UserMasterPPT.RoleID)
                    'Cursor = Cursors.WaitCursor
                    'Dim objLedRpt As New ReportFunctions
                    'objLedRpt.LedgerReport(6)
                    'Cursor = Cursors.Arrow

                    Dim childAcc As New VehicleLedgerFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                    Cursor = Cursors.Arrow


                ElseIf strMenuID = "M108" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M108", UserMasterPPT.RoleID)
                    Dim childAcc As New PettyCashPaymentReportFrm
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M110" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M110", UserMasterPPT.RoleID)
                    Dim childAcc As New AccountApprovalFrm()
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M350" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M350", UserMasterPPT.RoleID)
                    Dim childAcc As New PenerimaanCashReceiptReportFrm
                    childAcc.MdiParent = Me
                    childAcc.Dock = DockStyle.Fill
                    childAcc.Show()
                ElseIf strMenuID = "M111" Then
                    lblmesg.Visible = False
                    lblmesg.Text = objUserLoginBL.AccessUser("M111", UserMasterPPT.RoleID)
                    Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                    Dim lsTaskCheck As String = "N"
                    Dim dsTaskCheck As New DataSet
                    dsTaskCheck = StoreMonthEndClosingBOL.TaskConfigTaskCheckGet(objStoreMonthEndClosingPPT)
                    If dsTaskCheck.Tables(0).Rows.Count <> 0 Then
                        lsTaskCheck = dsTaskCheck.Tables(0).Rows(0).Item("CValue")
                    End If
                    If lsTaskCheck = "Y" Then
                        Dim childAcc As New AccountsMonthEndClosing()
                        childAcc.MdiParent = Me
                        childAcc.Dock = DockStyle.Fill
                        childAcc.Show()
                    Else
                        MessageBox.Show("Could not proceed Month End Closing ... Please Check Task Config")
                    End If
                End If

                'Accounts Menu End

            Case 7
                'Budget Menu Starts
                If strMenuID = "M29" Then
                    MessageBox.Show("Work in progress", "Pink Slip")
                    'Dim childAdmin As New StandardPinkSlipFrm()
                    'childAdmin.MdiParent = Me
                    'childAdmin.Dock = DockStyle.Fill
                    'childAdmin.Show()

                ElseIf strMenuID = "M59" Then
                    MessageBox.Show("Work in progress", "Standard PinkSlip Approval")
                    'Dim childAdmin As New StandardPinkSlipApprovalFrm()
                    'childAdmin.MdiParent = Me
                    'childAdmin.Dock = DockStyle.Fill
                    'childAdmin.Show()
                ElseIf strMenuID = "M1002" Then
                    Dim childAdmin As New CropYieldAndProductionBudgetFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                    'MessageBox.Show("Work in progress", "Crop Yield/Production Budget")
                ElseIf strMenuID = "M30" Then
                    Dim childAdmin As New ExpenditureBudgetByAgeOfPlantingFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M31" Then
                    Dim childAdmin As New AdministrationExpenditureFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M32" Then
                    Dim childAdmin As New CaptialExpenditureFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M33" Then
                    Dim childAdmin As New AgricultureExpenditureFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M34" Then
                    'MessageBox.Show("Work in progress", "Workshop Expenditure")
                    Dim childAdmin As New WorkshopExpenditureFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M35" Then
                    Dim childAdmin As New SalaryAndWagesAdministrationFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M36" Then
                    Dim childAdmin As New OperatingBudgetCostFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M37" Then
                    Dim childAdmin As New OperatingBudgetHourFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M38" Then
                    Dim childAdmin As New CropYieldAndProductionBudgetFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M41" Then
                    Dim childAdmin As New FFBTransportBudgetFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M42" Then
                    Dim childAdmin As New SupervisionPremiumFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M43" Then
                    Dim childAdmin As New FertilizerRequirementBudgetFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                    'Reports, here we go...
                ElseIf strMenuID = "M47" Then
                    MessageBox.Show("Work in progress", "Estate Expenditure Budget By Age Of Planting Report")
                ElseIf strMenuID = "M48" Then
                    MessageBox.Show("Work in progress", "Estate Summary of Expenditure")
                ElseIf strMenuID = "M49" Then
                    MessageBox.Show("Work in progress", "Estate Harvesting Cost Report ")
                ElseIf strMenuID = "M50" Then
                    MessageBox.Show("Work in progress", "Estate Capital Expenditure Report")
                ElseIf strMenuID = "M51" Then
                    MessageBox.Show("Work in progress", "Estate Capital Expenditure Details Report")
                ElseIf strMenuID = "M52" Then
                    MessageBox.Show("Work in progress", "Estate Agricultural Expenditure")
                ElseIf strMenuID = "M53" Then
                    MessageBox.Show("Work in progress", "Estate Analysis of Planning Cost By Task And Subtask")
                ElseIf strMenuID = "M54" Then
                    MessageBox.Show("Work in progress", "Estate Administration Expenditure Report")
                ElseIf strMenuID = "M55" Then
                    MessageBox.Show("Work in progress", "Estate Administration Expenditure Details Report")
                ElseIf strMenuID = "M56" Then
                    MessageBox.Show("Work in progress", "Estate Workshop Administration")
                ElseIf strMenuID = "M57" Then
                    MessageBox.Show("Work in progress", "Estate Workshop Administration Details")
                ElseIf strMenuID = "M58" Then
                    MessageBox.Show("Work in progress", "Estate Operating")
                End If

                'If strMenuID = "M24" Then
                '    Dim childAdmin As New StandardConfiguration()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M25" Then
                '    Dim childAdmin As New StandardPriceListFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M26" Then
                '    Dim childAdmin As New StandardActivityFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M27" Then
                '    Dim childAdmin As New StandardActivityDetailsFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M28" Then
                '    Dim childAdmin As New StandardHarvestingCostFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M29" Then
                '    Dim childAdmin As New StandardPinkSlipFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M30" Then
                '    MessageBox.Show("Work in progress", "Administration Expenditure")
                '    'Dim childAdmin As New AdministrationExpenditureFrm()
                '    'childAdmin.MdiParent = Me
                '    'childAdmin.Dock = DockStyle.Fill
                '    'childAdmin.Show()
                'ElseIf strMenuID = "M31" Then
                '    MessageBox.Show("Work in progress", "Operating BudgetCost")
                '    'Dim childAdmin As New OperatingBudgetCostFrm()
                '    'childAdmin.MdiParent = Me
                '    'childAdmin.Dock = DockStyle.Fill
                '    'childAdmin.Show()
                'ElseIf strMenuID = "M32" Then
                '    MessageBox.Show("Work in progress", "Operating BudgetHour")
                '    'Dim childAdmin As New OperatingBudgetHourFrm()
                '    'childAdmin.MdiParent = Me
                '    'childAdmin.Dock = DockStyle.Fill
                '    'childAdmin.Show()
                'ElseIf strMenuID = "M33" Then
                '    MessageBox.Show("Work in progress", "Captial Expenditure")
                '    'Dim childAdmin As New CaptialExpenditureFrm()
                '    'childAdmin.MdiParent = Me
                '    'childAdmin.Dock = DockStyle.Fill
                '    'childAdmin.Show()
                'ElseIf strMenuID = "M34" Then
                '    MessageBox.Show("Work in progress", "Agriculture Expenditure")
                'ElseIf strMenuID = "M35" Then
                '    MessageBox.Show("Work in progress", "Yield Budget")
                '    'Dim childAdmin As New YieldBudgetFrm()
                '    'childAdmin.MdiParent = Me
                '    'childAdmin.Dock = DockStyle.Fill
                '    'childAdmin.Show()
                'ElseIf strMenuID = "M36" Then
                '    MessageBox.Show("Work in progress", "Tractor Usage Budget")
                'ElseIf strMenuID = "M37" Then
                '    MessageBox.Show("Work in progress", "Transportation Budget")
                'ElseIf strMenuID = "M38" Then
                '    MessageBox.Show("Work in progress", "FFB Transport Budget")
                'ElseIf strMenuID = "M39" Then
                '    MessageBox.Show("Work in progress", "Salary & Wages Administration")
                'ElseIf strMenuID = "M40" Then
                '    MessageBox.Show("Work in progress", "Supervision Premium")
                'ElseIf strMenuID = "M41" Then
                '    MessageBox.Show("Work in progress", "Fertilizer Reguirement Budget")
                'ElseIf strMenuID = "M42" Then
                '    MessageBox.Show("Work in progress", "Mill - Production Budget")
                'ElseIf strMenuID = "M43" Then
                '    MessageBox.Show("Work in progress", "Mill-2 ShiftOperation and Calculation For Overtime")

                '    'Reports, here we go...
                'ElseIf strMenuID = "M44" Then
                '    MessageBox.Show("Work in progress", "Estate Expenditure Budget By Age Of Planting Report")
                'ElseIf strMenuID = "M45" Then
                '    MessageBox.Show("Work in progress", "Estate Summary of Expenditure")
                'ElseIf strMenuID = "M46" Then
                '    MessageBox.Show("Work in progress", "Estate Harvesting Cost Report ")
                'ElseIf strMenuID = "M47" Then
                '    MessageBox.Show("Work in progress", "Estate Capital Expenditure Report")
                'ElseIf strMenuID = "M48" Then
                '    MessageBox.Show("Work in progress", "Estate Capital Expenditure Details Report")
                'ElseIf strMenuID = "M49" Then
                '    MessageBox.Show("Work in progress", "Estate Agricultural Expenditure")
                'ElseIf strMenuID = "M50" Then
                '    MessageBox.Show("Work in progress", "Estate Analysis of Planning Cost By Task And Subtask")
                'ElseIf strMenuID = "M51" Then
                '    MessageBox.Show("Work in progress", "Estate Administration Expenditure Report")
                'ElseIf strMenuID = "M52" Then
                '    MessageBox.Show("Work in progress", "Estate Administration Expenditure Details Report")
                'ElseIf strMenuID = "M53" Then
                '    MessageBox.Show("Work in progress", "Estate Workshop Administration")
                'ElseIf strMenuID = "M54" Then
                '    MessageBox.Show("Work in progress", "Estate Workshop Administration Details")
                'ElseIf strMenuID = "M55" Then
                '    MessageBox.Show("Work in progress", "Estate Operating")



                'ElseIf strMenuID = "M301" Then
                '    MessageBox.Show("Work in progress", "Standard PinkSlip Approval")
                '    'Dim childAdmin As New StandardPinkSlipApprovalFrm()
                '    'childAdmin.MdiParent = Me
                '    'childAdmin.Dock = DockStyle.Fill
                '    'childAdmin.Show()
                'ElseIf strMenuID = "M1001" Then
                '    Dim childAdmin As New MandayRateFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1002" Then
                '    Dim childAdmin As New MonthlyWorkingDaysFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1003" Then
                '    Dim childAdmin As New YearlyWorkingDaysFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1004" Then
                '    Dim childAdmin As New RiceFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1005" Then
                '    Dim childAdmin As New DailyRateStandardFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1006" Then
                '    Dim childAdmin As New StandardCostByAgeOfPlantingFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1007" Then
                '    Dim childAdmin As New AverageBunchWeightFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1008" Then
                '    Dim childAdmin As New IncentiveSchemaBudget()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1009" Then
                '    Dim childAdmin As New BudgetDIVFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1010" Then
                '    Dim childAdmin As New BudgetYOPandBlockSetupFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1011" Then
                '    Dim childAdmin As New QuartelyHarvestingDayConfigFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1012" Then
                '    Dim childAdmin As New HarvestingCostFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'ElseIf strMenuID = "M1013" Then
                '    Dim childAdmin As New YieldBudgetFrm()
                '    childAdmin.MdiParent = Me
                '    childAdmin.Dock = DockStyle.Fill
                '    childAdmin.Show()
                'End If
                'Budget Menu End

            Case 8

                If strMenuID = "M112" Then
                    Dim childAdmin As New DesignationFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M113" Then
                    Dim childAdmin As New RoleMasterFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M114" Then
                    Dim childAdmin As New UserMasterFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M115" Then
                    Dim childAdmin As New RolePrivilegeFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M116" Then
                    Dim childAdmin As New ChangePasswordFrm()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                ElseIf strMenuID = "M117" Then
                    Dim childAdmin As New AppSetting()
                    childAdmin.MdiParent = Me
                    childAdmin.Dock = DockStyle.Fill
                    childAdmin.Show()
                End If

            Case Else

        End Select


    End Sub

    'Private Sub AccountsCashReconcilation()

    '    Cursor = Cursors.WaitCursor
    '    Dim xlApp As Excel.Application
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim sheet As Excel.Worksheet
    '    ' Dim sheet1 As Excel.Worksheet
    '    Dim strServerUserName As String = String.Empty
    '    Dim strServerPassword As String = String.Empty
    '    Dim strDSN As String = String.Empty
    '    Dim StrInitialCatlog As String = String.Empty
    '    Dim ReportDirectory As String = String.Empty
    '    xlApp = New Excel.Application

    '    Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\CashReconcilationReport_Template.xls"

    '    If (File.Exists(TemPath)) Then
    '        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\CashReconcilationReport_Template.xls")
    '    Else
    '        MsgBox("Cash Reconcilation report template missing.Please contact system administrator.")
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

    '    Dim sDirName As String
    '    sDirName = ReportDirectory + ":"
    '    Dim dDir As New DirectoryInfo(sDirName)

    '    If Not dDir.Exists Then
    '        MessageBox.Show("Report directory not found", "BSP")
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Accounts Reports")
    '    ' Determine whether the directory exists.
    '    If Not di.Exists Then
    '        di.Create()
    '    End If

    '    sheet = xlWorkBook.Sheets("Sheet1")
    '    sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDataSource").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""
    '    StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


    '    Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"   
    'Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim da As New SqlDataAdapter
    '    con = New SqlConnection(constr)

    '    con.Open()


    '    cmd.Connection = con
    '    cmd.CommandText = "Accounts.CashReconcilationReport"

    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
    '    cmd.Parameters.AddWithValue("@Amonth", GlobalPPT.IntLoginMonth)
    '    cmd.Parameters.AddWithValue("@AYear", GlobalPPT.intLoginYear)
    '    cmd.Parameters.AddWithValue("@CurrentActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    'cmd.Parameters.AddWithValue("@CurrentActiveMonthYearID", "22r262")

    '    Dim tblAdt As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(ds, "CashReconcilationReport")
    '    Dim objCommonBOl As New GlobalBOL
    '    Dim lTextmonth As String = String.Empty
    '    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

    '    If Not (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth And GlobalPPT.intLoginYear <= GlobalPPT.intActiveYear) Then
    '        lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
    '    ElseIf (GlobalPPT.IntActiveMonth = 1 And GlobalPPT.IntLoginMonth = 12) Then
    '        lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
    '    End If

    '    sheet.Cells(3, 9) = Format(Date.Today, "dd/MM/yyyy")
    '    sheet.Cells(7, 1) = "CASH RECONCILATION  " & lTextmonth & ""
    '    'sheet.Cells(7, 1).font = Color.Blue
    '    sheet.Cells(6, 7) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
    '    sheet.Cells(6, 9) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
    '    Dim lEstate As String
    '    Dim strArray As String()
    '    strArray = GlobalPPT.strEstateName.Split("-")
    '    lEstate = strArray(1)
    '    sheet.Cells(4, 2) = "Estate/Mill :" & lEstate & " "
    '    Dim strMonthlyAccountsRptName As String = String.Empty
    '    strMonthlyAccountsRptName = "CASH RECONCILATION" & "_" & lTextmonth & ""

    '    Dim StrPath As String = "" & sDirName & "\BSP Accounts Reports\" & strMonthlyAccountsRptName & ".xls"


    '    'If ds.Tables(0).Rows.Count = 0 Or ds.Tables(1).Rows.Count = 0 Or ds.Tables(2).Rows.Count = 0 Or ds.Tables(3).Rows.Count = 0 Or ds.Tables(4).Rows.Count = 0 Then
    '    '    xlApp.Visible = True
    '    '    'xlApp.AlertBeforeOverwriting = False
    '    '    sheet.Protect("RANNBSP@2010")
    '    '    If (File.Exists(StrPath)) Then
    '    '        File.Delete(StrPath)
    '    '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '    '    Else
    '    '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '    '    End If
    '    '    Cursor = Cursors.Arrow
    '    '    Exit Sub
    '    'End If

    '    'xlApp.Workbooks.Open(StrPath)

    '    'xlApp.StatusBar = True
    '    'xlApp.Visible = True




    '    If ds.Tables(0) IsNot Nothing And ds.Tables(1) IsNot Nothing And ds.Tables(2) IsNot Nothing And ds.Tables(3) IsNot Nothing And ds.Tables(4) IsNot Nothing Then
    '        Dim LCashOnHand As Decimal = 0
    '        Dim lAuthorizedFloat As Decimal = 0

    '        If ds.Tables(2).Rows.Count <> 0 Then
    '            sheet.Cells(9, 7) = ds.Tables(2).Rows(0).Item("AuthorizedFloat")
    '            LCashOnHand = ds.Tables(2).Rows(0).Item("CashOnHand")
    '            sheet.Cells(10, 7) = ds.Tables(2).Rows(0).Item("CashOnHand")
    '        End If






    '        Dim PCRCount As Integer
    '        PCRCount = ds.Tables(1).Rows.Count
    '        Dim lRowCount As Integer
    '        lRowCount = 13
    '        Dim LrowNo As Integer = 0
    '        Dim lAmount As Decimal = 0
    '        lRowCount = lRowCount + 1

    '        While (PCRCount > 0)

    '            sheet.Cells(lRowCount, 2) = ds.Tables(1).Rows(LrowNo).Item("ReceiptNo")
    '            sheet.Cells(lRowCount, 3) = ds.Tables(1).Rows(LrowNo).Item("ReceiptDate")
    '            sheet.Cells(lRowCount, 4) = "Rp"
    '            sheet.Cells(lRowCount, 5) = ds.Tables(1).Rows(LrowNo).Item("Amount")
    '            lAmount = lAmount + ds.Tables(1).Rows(LrowNo).Item("Amount")
    '            PCRCount = PCRCount - 1
    '            lRowCount = lRowCount + 1
    '            LrowNo = LrowNo + 1

    '        End While
    '        sheet.Cells(lRowCount, 2) = "Amount"
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 6) = "Rp"
    '        sheet.Cells(lRowCount, 7) = lAmount
    '        lRowCount = lRowCount + 1
    '        sheet.Cells(lRowCount, 2) = "Available Cash"
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 6) = "Rp"
    '        Dim lAvailableCash As Decimal = 0
    '        lAvailableCash = lAmount + LCashOnHand
    '        sheet.Cells(lRowCount, 7) = lAvailableCash

    '        lRowCount = lRowCount + 1
    '        sheet.Cells(lRowCount, 2) = "Less Expenditure "
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 6) = "Rp"
    '        Dim lCalcCash As Decimal = 0
    '        If ds.Tables(3).Rows.Count <> 0 Then
    '            sheet.Cells(lRowCount, 7) = ds.Tables(3).Rows(0).Item("TotalPCPwithoutDiscrepancyDescp")

    '            lCalcCash = lAvailableCash - Val(ds.Tables(3).Rows(0).Item("TotalPCPwithoutDiscrepancyDescp"))
    '        End If


    '        lRowCount = lRowCount + 1
    '        sheet.Cells(lRowCount, 2) = "Calculated Cash on Hand"
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 6) = "Rp"

    '        sheet.Cells(lRowCount, 7) = lCalcCash

    '        lRowCount = lRowCount + 3

    '        sheet.Cells(lRowCount, 2) = "Difference"
    '        sheet.Cells(lRowCount, 2).font.bold = True

    '        lRowCount = lRowCount + 1
    '        sheet.Cells(lRowCount, 2) = "Any Disreprancy Explanation"
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 6) = "Rp"

    '        sheet.Cells(lRowCount, 7) = ds.Tables(4).Rows(0).Item("DiscrpDescpAmount")

    '        lRowCount = lRowCount + 1
    '        sheet.Cells(lRowCount, 2) = "Actual"
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 6) = "Rp"
    '        Dim lActualCash As Decimal = 0
    '        lActualCash = lCalcCash - Val(ds.Tables(4).Rows(0).Item("DiscrpDescpAmount"))
    '        sheet.Cells(lRowCount, 7) = lActualCash

    '        lRowCount = lRowCount + 5
    '        sheet.Cells(lRowCount, 2) = "Details of Less Expenditure which is petty cash payment details."
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        lRowCount = lRowCount + 1
    '        sheet.Cells(lRowCount, 2) = "Voucher No."
    '        sheet.Cells(lRowCount, 2).font.bold = True
    '        sheet.Cells(lRowCount, 3) = "Voucher Date."
    '        sheet.Cells(lRowCount, 3).font.bold = True
    '        sheet.Cells(lRowCount, 5) = "Discrepancy Transaction."
    '        sheet.Cells(lRowCount, 5).font.bold = True
    '        sheet.Cells(lRowCount, 7) = "Amount(Rp)."
    '        sheet.Cells(lRowCount, 7).font.bold = True
    '        sheet.Cells(lRowCount, 9) = "Description."
    '        sheet.Cells(lRowCount, 9).font.bold = True

    '        Dim PCPCount As Integer
    '        PCPCount = ds.Tables(0).Rows.Count
    '        Dim lRowCountPCP As Integer
    '        lRowCountPCP = lRowCount + 2
    '        Dim LrowNoPCP As Integer = 0

    '        While (PCPCount > 0)
    '            sheet.Cells(lRowCountPCP, 2) = ds.Tables(0).Rows(LrowNoPCP).Item("VoucherNo")
    '            sheet.Cells(lRowCountPCP, 3) = ds.Tables(0).Rows(LrowNoPCP).Item("VoucherDate")
    '            sheet.Cells(lRowCountPCP, 5) = ds.Tables(0).Rows(LrowNoPCP).Item("DiscrepancyTransaction")
    '            sheet.Cells(lRowCountPCP, 7) = ds.Tables(0).Rows(LrowNoPCP).Item("Amount")
    '            sheet.Cells(lRowCountPCP, 8) = ds.Tables(0).Rows(LrowNoPCP).Item("PayDescp")
    '            PCPCount = PCPCount - 1
    '            lRowCountPCP = lRowCountPCP + 1
    '            LrowNoPCP = LrowNoPCP + 1
    '        End While

    '        lRowCountPCP = lRowCountPCP + 2

    '        sheet.Cells(lRowCountPCP, 2) = "Prepared By :"
    '        sheet.Cells(lRowCountPCP, 5) = "Checked By :"
    '        sheet.Cells(lRowCountPCP, 8) = "Authorized By :"
    '        sheet.Cells(lRowCountPCP, 2).font.bold = True
    '        sheet.Cells(lRowCountPCP, 5).font.bold = True
    '        sheet.Cells(lRowCountPCP, 8).font.bold = True
    '        lRowCountPCP = lRowCountPCP + 1

    '        sheet.Cells(lRowCountPCP, 2) = "_________________"
    '        sheet.Cells(lRowCountPCP, 5) = "_________________"
    '        sheet.Cells(lRowCountPCP, 8) = "_________________"

    '        lRowCountPCP = lRowCountPCP + 4
    '        sheet.Cells(lRowCountPCP, 7) = "Acknowledged By :"
    '        sheet.Cells(lRowCountPCP, 7).font.bold = True
    '        sheet.Cells(lRowCountPCP + 1, 7) = "__________________"

    '        xlApp.StatusBar = True
    '        xlApp.Visible = True
    '        sheet.Protect("RANNBSP@2010")
    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If



    '    End If
    '    Cursor = Cursors.Arrow


    'End Sub


    'Private Sub LedgerReport(ByVal modid As Integer)

    '    Cursor = Cursors.WaitCursor
    '    Dim xlApp As Excel.Application
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim strServerUserName As String = String.Empty
    '    Dim strServerPassword As String = String.Empty
    '    Dim strDSN As String = String.Empty
    '    Dim StrInitialCatlog As String = String.Empty
    '    Dim LedgerFlag As Boolean = True



    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDataSource").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""
    '    StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


    '     Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim cmd1 As New SqlCommand
    '    Dim da As New SqlDataAdapter
    '    con = New SqlConnection(constr)

    '    con.Open()


    '    cmd.Connection = con
    '    cmd.CommandText = "Accounts.LedgerReport"

    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
    '    cmd.Parameters.AddWithValue("@Amonth", GlobalPPT.IntLoginMonth)
    '    cmd.Parameters.AddWithValue("@AYear", GlobalPPT.intLoginYear)
    '    cmd.Parameters.AddWithValue("@Modid", modid)

    '    Dim tblAdt As New SqlDataAdapter
    '    Dim ds As New DataSet
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(ds, "LedgerReport")
    '    Dim ReportDirectory As String = String.Empty
    '    xlApp = New Excel.Application

    '    Dim TemPath As String = Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template.xlsx"

    '    If (File.Exists(TemPath)) Then
    '        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Accounts\Excel\LedgerReport_Template.xlsx")
    '    Else
    '        MsgBox("Ledger report template missing.Please contact system administrator.")
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

    '    Dim sDirName As String
    '    sDirName = ReportDirectory + ":"
    '    Dim dDir As New DirectoryInfo(sDirName)

    '    If Not dDir.Exists Then
    '        MessageBox.Show("Report directory not found", "BSP")
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Accounts Reports")
    '    ' Determine whether the directory exists.
    '    If Not di.Exists Then
    '        di.Create()
    '    End If





    '    Dim LmodName As String = String.Empty
    '    If modid = 6 Then
    '        LmodName = "ACCOUNTS LEDGER"
    '    ElseIf modid = 3 Then
    '        LmodName = "VEHICLE LEDGER"
    '    ElseIf modid = 2 Then
    '        LmodName = "STORE LEDGER"
    '    End If
    '    Dim lTextmonth As String = String.Empty
    '    Dim objCommonBOl As New GlobalBOL

    '    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

    '    If Not (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth And GlobalPPT.intLoginYear <= GlobalPPT.intActiveYear) Then
    '        lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
    '    ElseIf (GlobalPPT.IntActiveMonth = 1 And GlobalPPT.IntLoginMonth = 12) Then
    '        lTextmonth = "" & lTextmonth & "  (PROVISIONAL)"
    '    End If

    '    Dim lEstAbbr As String = ""
    '    If ds.Tables(1).Rows.Count <> 0 Then
    '        lEstAbbr = ds.Tables(1).Rows(0).Item("Abbrevation").ToString()
    '    End If
    '    Dim StrPath As String = ""
    '    If lEstAbbr <> "" Then
    '        StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lEstAbbr & "_" & lTextmonth & ".xls"
    '    Else
    '        StrPath = "" & sDirName & "\BSP Accounts Reports\" & LmodName & "_" & lTextmonth & ".xls"
    '    End If
    '    Dim lEstate As String
    '    Dim strArray As String()
    '    strArray = GlobalPPT.strEstateName.Split("-")
    '    lEstate = strArray(1)

    '    If ds.Tables(0).Rows.Count = 0 Then
    '        Dim sheet As Excel.Worksheet
    '        sheet = xlWorkBook.Sheets("Sheet1")
    '        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '        sheet.Cells(4, 1) = "" & LmodName & " " & lTextmonth & ""
    '        sheet.Cells(2, 1) = "Estate/Mill :" & lEstate
    '        sheet.Cells(2, 14) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
    '        sheet.Cells(2, 16) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If
    '        xlApp.Visible = True
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If
    '    Dim LrowNoLedger As Integer = 0
    '    If ds IsNot Nothing Then
    '        Dim CountLedgerType As Integer = 0
    '        CountLedgerType = ds.Tables(0).Rows.Count
    '        Dim LedgerCount As Integer = 0
    '        LedgerCount = ds.Tables(1).Rows.Count

    '        Dim lLedgerType As String
    '        Dim lLedgerRow As Integer
    '        If CountLedgerType > 0 Then

    '            Dim sheet As Excel.Worksheet
    '            sheet = xlWorkBook.Sheets("Sheet1")
    '            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
    '            Dim sheetNo As Excel.Worksheet
    '            While (CountLedgerType > 0)
    '                sheetNo = xlWorkBook.Worksheets.Add
    '                sheet.UsedRange.Copy(Type.Missing.Value)
    '                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)

    '                lLedgerType = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
    '                lLedgerRow = CountLedgerType - 1
    '                If lEstAbbr <> "" Then
    '                    sheetNo.Name = " " & lEstAbbr & "_" & lLedgerType & " "
    '                Else
    '                    sheetNo.Name = " " & lLedgerType & " "
    '                End If

    '                sheetNo.Cells(2, 1) = "Estate/Mill :" & lEstate & " "


    '                sheetNo.Cells(2, 14) = ds.Tables(1).Rows(0).Item("FromDT").ToString()
    '                sheetNo.Cells(2, 16) = ds.Tables(1).Rows(0).Item("ToDT").ToString()

    '                sheetNo.Cells(4, 1) = "" & LmodName & " " & lTextmonth & ""


    '                Dim lRowCountLedger As Integer
    '                lRowCountLedger = 10


    '                sheetNo.Cells(9, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
    '                sheetNo.Cells(9, 5) = "Journal Consolidation"
    '                sheetNo.Cells(9, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
    '                sheetNo.Cells(9, 9) = lLedgerType
    '                sheetNo.Cells(9, 16) = "1"
    '                LedgerFlag = True

    '                While (LedgerCount > 0 And LedgerFlag = True)
    '                    sheetNo.Cells(lRowCountLedger, 1) = ds.Tables(1).Rows(LrowNoLedger).Item("oldAccountCode")
    '                    sheetNo.Cells(lRowCountLedger, 2) = ds.Tables(1).Rows(LrowNoLedger).Item("AccountCode")
    '                    sheetNo.Cells(lRowCountLedger, 3) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionDate")
    '                    sheetNo.Cells(lRowCountLedger, 4) = ds.Tables(1).Rows(LrowNoLedger).Item("TransactionReference")
    '                    sheetNo.Cells(lRowCountLedger, 5) = ds.Tables(1).Rows(LrowNoLedger).Item("Description")
    '                    sheetNo.Cells(lRowCountLedger, 6) = "" & GlobalPPT.intLoginYear & "/" & GlobalPPT.IntLoginMonth & ""
    '                    sheetNo.Cells(lRowCountLedger, 7) = ds.Tables(1).Rows(LrowNoLedger).Item("Deb")
    '                    sheetNo.Cells(lRowCountLedger, 8) = ds.Tables(1).Rows(LrowNoLedger).Item("BaseAmount")

    '                    sheetNo.Cells(lRowCountLedger, 9) = ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType").ToString()
    '                    sheetNo.Cells(lRowCountLedger, 10) = "" & GlobalPPT.strUserName & ""
    '                    sheetNo.Cells(lRowCountLedger, 11) = ds.Tables(1).Rows(LrowNoLedger).Item("T0")
    '                    sheetNo.Cells(lRowCountLedger, 12) = ds.Tables(1).Rows(LrowNoLedger).Item("T1")
    '                    sheetNo.Cells(lRowCountLedger, 13) = ds.Tables(1).Rows(LrowNoLedger).Item("T2")
    '                    sheetNo.Cells(lRowCountLedger, 14) = ds.Tables(1).Rows(LrowNoLedger).Item("T3")
    '                    sheetNo.Cells(lRowCountLedger, 15) = ds.Tables(1).Rows(LrowNoLedger).Item("T4")
    '                    sheetNo.Cells(lRowCountLedger, 16) = "2"
    '                    LedgerCount = LedgerCount - 1
    '                    lRowCountLedger = lRowCountLedger + 1
    '                    LrowNoLedger = LrowNoLedger + 1

    '                    If LedgerCount > 1 Then
    '                        If lLedgerType <> ds.Tables(1).Rows(LrowNoLedger).Item("LedgerType") Then
    '                            LedgerFlag = False
    '                        End If
    '                    End If

    '                End While

    '                sheetNo.Range("A1").EntireColumn.ColumnWidth = 13
    '                sheetNo.Range("B1").EntireColumn.ColumnWidth = 13
    '                sheetNo.Range("C1").EntireColumn.ColumnWidth = 12
    '                sheetNo.Range("D1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("E1").EntireColumn.ColumnWidth = 35
    '                sheetNo.Range("F1").EntireColumn.ColumnWidth = 13
    '                sheetNo.Range("G1").EntireColumn.ColumnWidth = 16
    '                sheetNo.Range("H1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("I1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("J1").EntireColumn.ColumnWidth = 15
    '                sheetNo.Range("K1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("L1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("M1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("N1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("O1").EntireColumn.ColumnWidth = 10
    '                sheetNo.Range("P1").EntireColumn.ColumnWidth = 15
    '                CountLedgerType = CountLedgerType - 1
    '                sheetNo.Protect("RANNBSP@2010")

    '            End While
    '            sheet.Visible = False
    '            xlApp.Visible = True


    '            If (File.Exists(StrPath)) Then
    '                File.Delete(StrPath)
    '                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '            Else
    '                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '            End If


    '        End If
    '    End If
    '    Cursor = Cursors.Arrow

    'End Sub


    Private Sub ProductionMillWorkingHours()

        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty

        Dim strMonthlyProdRptName As String = String.Empty
        Dim DtotalShifthrs1, DtotalShifthrs2, DtotalShifthrs3, DtotalOperationhrs, DtotalProdHrs, DtotalBreakDownHrs As Decimal
        Dim ltotalShifthrs1, ltotalShifthrs2, ltotalShifthrs3, ltotalOperationhrs, ltotalProdHrs, ltotalBreakDownHrs As Decimal


        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_hours_Report.xlsx")

        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()


        cmd.Connection = con
        cmd.CommandText = "Production.MillWorkingHoursReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "MillWorkingHoursReport")


        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
        strMonthlyProdRptName = "Mill Working Hours Report" & "_" & lTextmonth & ""
        sheet.Cells(5, 1) = "Mill Working Hours Report" & " " & lTextmonth & ""

        sheet.Cells(1, 13) = Format(Date.Today, "dd/MM/yyyy")
        sheet.Cells(3, 11) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
        sheet.Cells(3, 13) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")

        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        sheet.Cells(2, 1) = "Estate/Mill :" & lEstate & " "

        If ds.Tables(0).Rows.Count = 0 Then
            xlApp.Visible = True
            Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\" & strMonthlyProdRptName & ".xls"


            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            Cursor = Cursors.Arrow
            Exit Sub
        End If



        If ds.Tables(0) IsNot Nothing Then



            Dim TotalCount As Integer = 0

            TotalCount = ds.Tables(0).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 13
            Dim LrowNo As Integer = 0

            While (TotalCount > 0)
                Dim lDate As Date
                lDate = ds.Tables(0).Rows(LrowNo).Item("ProductionLogDate").ToString
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1) = lDate
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                Dim lStartTime, lStoptime As DateTime

                If Not ds.Tables(0).Rows(LrowNo).Item("StartTime1") Is DBNull.Value Then

                    lStartTime = ds.Tables(0).Rows(LrowNo).Item("StartTime1")
                    lStoptime = ds.Tables(0).Rows(LrowNo).Item("EndTime1")


                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 2) = strTotalhrs + "." + strTotalMins
                            DtotalShifthrs1 = strTotalhrs + "." + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 2) = strTotalhrs + "." + strTotalMins
                            DtotalShifthrs1 = strTotalhrs + "." + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 2) = strTotalhrs + ".00"
                        DtotalShifthrs1 = strTotalhrs + ".00"
                    End If
                End If


                If Not ds.Tables(0).Rows(LrowNo).Item("StartTime2") Is DBNull.Value Then
                    lStartTime = ds.Tables(0).Rows(LrowNo).Item("StartTime2")
                    lStoptime = ds.Tables(0).Rows(LrowNo).Item("EndTime2")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 3) = strTotalhrs + "." + strTotalMins
                            DtotalShifthrs2 = strTotalhrs + "." + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 3) = strTotalhrs + "." + strTotalMins
                            DtotalShifthrs2 = strTotalhrs + "." + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 3) = strTotalhrs + ".00"
                        DtotalShifthrs2 = strTotalhrs + ".00"
                    End If
                End If
                If Not ds.Tables(0).Rows(LrowNo).Item("StartTime3") Is DBNull.Value Then
                    lStartTime = ds.Tables(0).Rows(LrowNo).Item("StartTime3")
                    lStoptime = ds.Tables(0).Rows(LrowNo).Item("EndTime3")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 4) = strTotalhrs + "." + strTotalMins
                            DtotalShifthrs3 = strTotalhrs + "." + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 4) = strTotalhrs + "." + strTotalMins
                            DtotalShifthrs3 = strTotalhrs + "." + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 4) = strTotalhrs + ".00"
                        DtotalShifthrs3 = strTotalhrs + ".00"
                    End If
                End If

                Dim lTotalHours As String = String.Empty
                lTotalHours = ds.Tables(0).Rows(LrowNo).Item("TotalHours")
                If lTotalHours < 10 Then
                    lTotalHours = "0" + lTotalHours
                End If
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5) = lTotalHours
                DtotalOperationhrs = lTotalHours
                Dim lProductionHours As String = String.Empty
                lProductionHours = ds.Tables(0).Rows(LrowNo).Item("ProductionHours").ToString
                If lProductionHours < 10 Then
                    lProductionHours = "0" + lProductionHours
                End If
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6) = lProductionHours
                DtotalProdHrs = lProductionHours
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                'sheet.Cells(lRowCount, 7) = ds.Tables(0).Rows(LrowNo).Item("TotalHours") - ds.Tables(0).Rows(LrowNo).Item("ProductionHours")

                Dim lBKDownHours As String
                lBKDownHours = ds.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString
                If lBKDownHours < 10 Then
                    lBKDownHours = "0" + lBKDownHours
                End If
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8) = lBKDownHours
                DtotalBreakDownHrs = lBKDownHours
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13) = ds.Tables(0).Rows(LrowNo).Item("Remarks")

                TotalCount = TotalCount - 1
                lRowCount = lRowCount + 1
                LrowNo = LrowNo + 1

                ltotalShifthrs1 = ltotalShifthrs1 + DtotalShifthrs1
                ltotalShifthrs2 = ltotalShifthrs2 + DtotalShifthrs2
                ltotalShifthrs3 = ltotalShifthrs3 + DtotalShifthrs3
                ltotalOperationhrs = ltotalOperationhrs + DtotalOperationhrs
                ltotalProdHrs = ltotalProdHrs + DtotalProdHrs
                ltotalBreakDownHrs = ltotalBreakDownHrs + DtotalBreakDownHrs

                DtotalShifthrs1 = 0
                DtotalShifthrs2 = 0
                DtotalShifthrs3 = 0
                DtotalOperationhrs = 0
                DtotalProdHrs = 0
                DtotalBreakDownHrs = 0

            End While

            'Dim Myrange As Excel.Range
            'Myrange = sheet.Range(lRowCount, 1)
            'Myrange.Font.Bold = True
            sheet.Cells(lRowCount, 1).font.bold = True
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 3).font.bold = True
            sheet.Cells(lRowCount, 4).font.bold = True
            sheet.Cells(lRowCount, 5).font.bold = True
            sheet.Cells(lRowCount, 6).font.bold = True
            sheet.Cells(lRowCount, 7).font.bold = True
            sheet.Cells(lRowCount, 8).font.bold = True
            sheet.Cells(lRowCount, 9).font.bold = True
            sheet.Cells(lRowCount, 10).font.bold = True
            sheet.Cells(lRowCount, 11).font.bold = True
            sheet.Cells(lRowCount, 12).font.bold = True
            sheet.Cells(lRowCount, 13).font.bold = True
            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            'Dim strtotal As String = "Total"
            'sheet.Cells(lRowCount, 1) = Font.Bold

            sheet.Cells(lRowCount, 1) = "Total"

            Dim intMins As Double = 0
            Dim intHrs As Double = 0
            Dim intDiv As Double = 0
            Dim strDiv As String = 0

            If ltotalShifthrs1 <> 0 Then

                intMins = ltotalShifthrs1 * 60
                intHrs = intMins / 60
                intHrs = Fix(intHrs)
                intDiv = intMins Mod 60
                strDiv = intDiv
                Dim StrHrs As String = String.Empty
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                Else
                    StrHrs = intHrs
                End If

                If (intDiv >= 60) Then
                    intMins = intDiv - 60

                    intHrs = intHrs + 1


                    sheet.Cells(lRowCount, 2) = StrHrs.ToString + "." + intMins.ToString
                ElseIf intDiv.ToString.Length = 1 Then
                    sheet.Cells(lRowCount, 2) = StrHrs.ToString + ".0" + intDiv.ToString
                Else
                    sheet.Cells(lRowCount, 2) = StrHrs.ToString + "." + intDiv.ToString
                End If

            Else
                sheet.Cells(lRowCount, 2) = ""
            End If

            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            If ltotalShifthrs2 <> 0 Then

                intMins = ltotalShifthrs2 * 60
                intHrs = intMins / 60
                intHrs = Fix(intHrs)
                intDiv = intMins Mod 60
                strDiv = intDiv
                Dim StrHrs As String = String.Empty
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                Else
                    StrHrs = intHrs
                End If

                If (intDiv >= 60) Then
                    intMins = intDiv - 60

                    intHrs = intHrs + 1


                    sheet.Cells(lRowCount, 3) = StrHrs.ToString + "." + intMins.ToString
                ElseIf intDiv.ToString.Length = 1 Then
                    sheet.Cells(lRowCount, 3) = StrHrs.ToString + ".0" + intDiv.ToString
                Else
                    sheet.Cells(lRowCount, 3) = StrHrs.ToString + "." + intDiv.ToString
                End If

            Else
                sheet.Cells(lRowCount, 3) = ""
            End If

            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            If ltotalShifthrs3 <> 0 Then

                intMins = ltotalShifthrs3 * 60
                intHrs = intMins / 60
                intHrs = Fix(intHrs)
                intDiv = intMins Mod 60
                strDiv = intDiv
                Dim StrHrs As String = String.Empty
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                Else
                    StrHrs = intHrs
                End If

                If (intDiv >= 60) Then
                    intMins = intDiv - 60

                    intHrs = intHrs + 1


                    sheet.Cells(lRowCount, 4) = StrHrs.ToString + "." + intMins.ToString
                ElseIf intDiv.ToString.Length = 1 Then
                    sheet.Cells(lRowCount, 4) = StrHrs.ToString + ".0" + intDiv.ToString
                Else
                    sheet.Cells(lRowCount, 4) = StrHrs.ToString + "." + intDiv.ToString
                End If

            Else
                sheet.Cells(lRowCount, 4) = ""
            End If
            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            If ltotalOperationhrs <> 0 Then

                intMins = ltotalOperationhrs * 60
                intHrs = intMins / 60
                intHrs = Fix(intHrs)
                intDiv = intMins Mod 60
                strDiv = intDiv
                Dim StrHrs As String = String.Empty
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                Else
                    StrHrs = intHrs
                End If

                If (intDiv >= 60) Then
                    intMins = intDiv - 60

                    intHrs = intHrs + 1


                    sheet.Cells(lRowCount, 5) = StrHrs.ToString + "." + intMins.ToString
                ElseIf intDiv.ToString.Length = 1 Then
                    sheet.Cells(lRowCount, 5) = StrHrs.ToString + ".0" + intDiv.ToString
                Else
                    sheet.Cells(lRowCount, 5) = StrHrs.ToString + "." + intDiv.ToString
                End If

            Else
                sheet.Cells(lRowCount, 5) = ""
            End If
            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            If ltotalProdHrs <> 0 Then

                intMins = ltotalProdHrs * 60
                intHrs = intMins / 60
                intHrs = Fix(intHrs)
                intDiv = intMins Mod 60
                strDiv = intDiv
                Dim StrHrs As String = String.Empty
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                Else
                    StrHrs = intHrs
                End If

                If (intDiv >= 60) Then
                    intMins = intDiv - 60

                    intHrs = intHrs + 1


                    sheet.Cells(lRowCount, 6) = StrHrs.ToString + "." + intMins.ToString
                ElseIf intDiv.ToString.Length = 1 Then
                    sheet.Cells(lRowCount, 6) = StrHrs.ToString + ".0" + intDiv.ToString
                Else
                    sheet.Cells(lRowCount, 6) = StrHrs.ToString + "." + intDiv.ToString
                End If

            Else
                sheet.Cells(lRowCount, 6) = ""
            End If
            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            ' sheet.Cells(lRowCount, 7) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            If ltotalBreakDownHrs <> 0 Then

                intMins = ltotalBreakDownHrs * 60
                intHrs = intMins / 60
                intHrs = Fix(intHrs)
                intDiv = intMins Mod 60
                strDiv = intDiv
                Dim StrHrs As String = String.Empty
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                Else
                    StrHrs = intHrs
                End If

                If (intDiv >= 60) Then
                    intMins = intDiv - 60

                    intHrs = intHrs + 1


                    sheet.Cells(lRowCount, 8) = StrHrs.ToString + "." + intMins.ToString
                ElseIf intDiv.ToString.Length = 1 Then
                    sheet.Cells(lRowCount, 8) = StrHrs.ToString + ".0" + intDiv.ToString
                Else
                    sheet.Cells(lRowCount, 8) = StrHrs.ToString + "." + intDiv.ToString
                End If

            Else
                sheet.Cells(lRowCount, 6) = ""
            End If
            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(lRowCount, 9) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(lRowCount, 10) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            ' sheet.Cells(lRowCount, 11) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            ' sheet.Cells(lRowCount, 12) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

            'xlApp.Width = 1280
            xlApp.StatusBar = True
            xlApp.Visible = True

            Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\" & strMonthlyProdRptName & ".xls"


            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

        End If
        Cursor = Cursors.Arrow


    End Sub

    Private Sub ProductionMonthlyReport()

        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty

        Dim sheet As Excel.Worksheet
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\MonthlyProductionReport.xlsx")


        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()


        cmd.Connection = con
        cmd.CommandText = "Production.ProductionSupplierSelect"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)


        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "ProductionSupplierSelect")

        Dim objCommonBOl As New GlobalBOL
        Dim Logmonth As String = String.Empty
        Logmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

        Dim Pageno As Integer
        Pageno = 1
        sheet.Cells(1, 8) = Date.Today
        sheet.Cells(2, 1) = "Estate/Mill :" & GlobalPPT.strEstateName
        sheet.Cells(3, 6) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        sheet.Cells(3, 8) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        sheet.Cells(2, 8) = Pageno
        strMonthlyProdRptName = "PRODUCTION MONTHLY REPORT" & "_" & Logmonth & ""  'ds.Tables(0).Rows(0).Item("ToDT").ToString()
        sheet.Cells(5, 1) = "PRODUCTION MONTHLY REPORT" & " " & Logmonth & ""
        Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\" & strMonthlyProdRptName & ".xls"

        If ds.Tables(0).Rows.Count = 0 Then

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            xlApp.Visible = True
            Cursor = Cursors.Arrow
            Exit Sub
        End If



        If ds IsNot Nothing Then
            Dim CountSupplier As Integer = 0
            CountSupplier = ds.Tables(0).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 13

            Dim psuplierName As String
            Dim pWeighingDate As Date
            Dim pEstate As String
            Dim pSupplierRow As Integer = 0



            If ds.Tables(0).Rows.Count = 0 Then
                xlApp.Visible = True
                Cursor = Cursors.Arrow
                Exit Sub
            End If

            If CountSupplier > 0 Then
                While (CountSupplier > 0)
                    psuplierName = ds.Tables(0).Rows(pSupplierRow).Item("SupplierName").ToString()

                    pEstate = ds.Tables(0).Rows(0).Item("EstateName").ToString()

                    pWeighingDate = Date.Today
                    Dim ds1 As New DataSet
                    ds1 = ProductionMonthEndClosingBOL.ProductionMonthlyReport(psuplierName, pWeighingDate)

                    If ds1.Tables(0).Rows.Count = 0 Then
                        xlApp.Visible = True
                        Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 2) = ds.Tables(0).Rows(pSupplierRow).Item("SupplierName")
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 3) = (ds1.Tables(0).Rows(0).Item("MonthValue") / 1000)
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 5) = (ds1.Tables(1).Rows(0).Item("YearValue") / 1000)
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    lRowCount = lRowCount + 1
                    CountSupplier = CountSupplier - 1
                    pSupplierRow = pSupplierRow + 1
                End While
                'sheet.Visible = True
                xlApp.Visible = True

                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If
            End If
        End If





        Cursor = Cursors.Arrow
    End Sub







    Private Sub KillAllExcels()
        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            proc.Kill()
        Next
    End Sub
End Class