Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Threading
Imports System.Reflection
Imports Common_PPT.DatabaseMasterPPT

Public Class LoginFrm

    Private EstateALL_ As EstatePPT()
    Private _userPPT As New Common_PPT.GlobalPPT()
    Dim lbpageload As Boolean = True
    Dim strResult As String
    Dim intAMonth As Integer
    Dim strYear As String
    Dim strActiveMonthYearID As String
    Dim strVersionNo As String = String.Empty

    Sub LoadDBList()
        ' load all DB Serves set on Application Settings
        'Dim xDS As New DBConfig
        'Dim ConfigPathname As String = Application.StartupPath + "\BSP.exe.DBConfig"
        'xDS.ReadXml(ConfigPathname, System.Data.XmlReadMode.IgnoreSchema)

        'For Each xRow As DBConfig.DBListRow In xDS.DBList.Rows
        '    cmbServer.Items.Add(xRow.DBName)
        'Next
        Dim dbList As New List(Of DatabaseList)
        dbList = DatabaseMasterBOL.GetDataseList()

        cmbServer.DataSource = dbList
        cmbServer.DisplayMember = "DBName"
        cmbServer.ValueMember = "ID"

    End Sub

    Private Sub LoginFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim createDate As String
        Dim fileInfo As System.IO.FileInfo

        fileInfo = New System.IO.FileInfo(Assembly.GetExecutingAssembly().Location)
        createDate = fileInfo.CreationTime.ToString("dd-MM-yyyy")

        lblVersionNo.Text = "" & ConfigurationManager.AppSettings.Item("oVersionNo").Trim().ToString & " | " + createDate

        Me.cmbLanguage.SelectedIndex = 0

        SetUICulture(GlobalPPT.strLang)

        LoadDBList()
        If cmbServer.Items.Count > 0 Then cmbServer.SelectedIndex = 0

        InitializeLogin()

    End Sub


    Sub InitializeLogin()
        Try
            FillEstateName()

            GlobalPPT.psEstateType = GlobalBOL.EstateTypeSelect()
            GlobalPPT.strUserName = txtUName.Text
            GlobalPPT.strEstateIDCode = cmbEstate.SelectedValue.ToString
            GlobalPPT.straIdAndCode = GlobalPPT.strEstateIDCode.Split("*".ToCharArray(), 2)
            GlobalPPT.strEstateCode = GlobalPPT.straIdAndCode(1).ToString

            PopulateYears(GlobalPPT.strEstateID, GlobalPPT.strEstateCode, GlobalPPT.strUserName)

            'To get Default Accounts Active Month, Year and ActiveMonthYearID.
            GetActiveYearMonth(GlobalPPT.strEstateID, 6)

            lbpageload = False
        Catch ex As Exception
            ' database error, maybe
            Dim appSettings As New AppSetting()
            If appSettings.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
                End
                'LoadDBList()
                'InitializeLogin()
            End If
        End Try

    End Sub

    Private Function ValidateSelectedMonthYear() As String

        Dim obj As New EstateBOL
        Dim intAMonth As Integer

        Dim intAYear As Integer
        Dim dsActive As New DataSet

        Dim strResult As String = ""

        'strResult = "A" 'Both Reports and Transaction

        Dim intSelectedMonth As Integer
        Dim intSelectedYear As Integer

        'BY Default accounts module active month, year and activemonthYearid
        dsActive = obj.GetActiveYearMonth(GlobalPPT.strEstateID, 6)

        If dsActive.Tables(0).Rows.Count > 0 Then

            intAYear = CType(dsActive.Tables(0).Rows(0).Item(0).ToString, Integer)
            intAMonth = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)

        End If

        intSelectedMonth = (lstAMonth.SelectedIndex) + 1
        intSelectedYear = CType(lstAyear.SelectedValue.ToString, Integer)

        'AN07042009 - <<START>> Added by anand

        If intSelectedYear > intAYear Then
            If intSelectedMonth = intAMonth + 4 Then
                strResult = "T"
            ElseIf intSelectedMonth > intAMonth + 4 Then
                strResult = "E"
            End If
        ElseIf intSelectedYear = intAYear Then
            If intSelectedMonth < intAMonth Then
                strResult = "R"
            ElseIf intSelectedMonth = intAMonth Then
                strResult = "A"
            ElseIf intSelectedMonth = intAMonth + 4 Then
                strResult = "T"
            ElseIf intSelectedMonth > intAMonth + 4 Then
                strResult = "E"
            End If
        End If
        'AN07042009 - <<END>> Added by anand

        'AN07042009 - <<START>> commented by anand

        'If intSelectedYear > intAYear Then
        '    If intSelectedMonth = 1 Then
        '        strResult = "T"

        '    Else
        '        strResult = "E"

        '    End If

        '    strMenuType = strResult
        '    Return strResult

        'End If

        'If intSelectedYear = intAYear Then
        '    If intSelectedMonth = intAMonth Then
        '        strResult = "A"

        '    ElseIf intSelectedMonth = (intAMonth + 1) Then
        '        strResult = "T"

        '    ElseIf intSelectedMonth > (intAMonth + 1) Then
        '        strResult = "E"

        '    Else
        '        strResult = "R"

        '    End If

        '    strMenuType = strResult
        '    Return strResult

        'End If

        'strResult = "R"

        'AN07042009 - <<END>> commented by anand

        _userPPT.strMenuType = strResult

        Return strResult

    End Function

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim ds As New DataSet

        If ValidateForm() Then

            Dim dt As New DataTable
            Dim objUserPPT As New UserMasterPPT
            Dim objEstatePPT As New EstatePPT
            Dim objLoginBOL As New LoginBOL
            Dim objEstateBOL As New EstateBOL

            'this lines by Rajkumar
            With objEstatePPT
                .Ayear = lstAyear.SelectedValue
            End With

            ds = objLoginBOL.FiscalYearAllRecordsIsExist(objEstatePPT)

            If ds.Tables(0).Rows.Count = 12 Then

                With objUserPPT
                    .UserName = Me.txtUName.Text
                    .TmpPass = Me.txtPass.Text
                End With

                objUserPPT = objLoginBOL.LoginUser(objUserPPT)

                If objUserPPT.UserID Is Nothing Then
                    MsgBox("Invalid Credentials, Login Failed.")
                Else
                    GlobalPPT.strUID = objUserPPT.UserID
                    GlobalPPT.strDesgID = objUserPPT.DesgID
                    GlobalPPT.strDisplayName = objUserPPT.DispName
                    GlobalPPT.strDesgLevel = objUserPPT.DLevel
                    strResult = ValidateSelectedMonthYear()

                    Select Case strResult
                        Case "A"
                            'MsgBox("both")

                        Case "T"
                            'MsgBox("Transaction")

                        Case "R"
                            'MsgBox("Report")

                        Case "E"
                            MsgBox("User can access only one month forward than Active Month")
                            Exit Sub
                    End Select
                    If VersionCheck() = False Then
                        MsgBox("The current application and database version do not match, please check with your administrator", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    Me.Hide()
                    Dim frmMDI As New MDIParent
                    GlobalPPT.strUserName = Me.txtUName.Text
                    GlobalPPT.strEstateName = Me.cmbEstate.Text
                    GlobalPPT.strEstateIDCode = cmbEstate.SelectedValue.ToString
                    GlobalPPT.strEstateCode = GlobalPPT.straIdAndCode(1).ToString
                    GlobalPPT.strEstateID = GlobalPPT.straIdAndCode(0).ToString
                    GlobalPPT.intLoginYear = Me.lstAyear.Text
                    GlobalPPT.strLoginMonth = Me.lstAMonth.Text

                    Dim selectedEstate As EstatePPT = cmbEstate.SelectedItem
                    GlobalPPT.strEstateAbbrev = selectedEstate.EstateAbbreviation

                    GlobalPPT.IntLoginMonth = Trim$(Mid$(GlobalPPT.strLoginMonth, 1, InStr(GlobalPPT.strLoginMonth, "-") - 1))

                    GlobalPPT.IntActiveMonth = intAMonth
                    GlobalPPT.intActiveYear = strYear
                    GlobalPPT.strActMthYearID = strActiveMonthYearID

                    With objUserPPT
                        .FiscalMonth = GlobalPPT.IntLoginMonth
                        .FiscalYear = lstAyear.Text
                    End With
                    dt = objLoginBOL.FiscalYearDate(objUserPPT)
                    If dt.Rows.Count <> 0 Then
                        GlobalPPT.FiscalYearFromDate = dt.Rows(0).Item("FromDT")
                        GlobalPPT.FiscalYearToDate = dt.Rows(0).Item("TODT")
                    End If

                    frmMDI.Text = lblTitle.Text + " - " + GlobalPPT.strEstateName
                    frmMDI.Show()
                End If

                PopulateYears(GlobalPPT.strEstateID, GlobalPPT.strEstateCode, GlobalPPT.strUserName)

                'Default accounts module active month year.
                GetActiveYearMonth(GlobalPPT.strEstateID, 6)

            Else
                MsgBox("Please Insert Valid Data in Fiscal Year Screen")
            End If

        End If

    End Sub

    Private Function ValidateForm() As Boolean

        If Me.txtUName.Text.Trim = String.Empty Then
            MessageBox.Show("This field is required.", "User Name")
            Me.txtUName.Focus()
            Return False
        End If

        If Me.txtPass.Text.Trim = String.Empty Then
            MessageBox.Show("This field is required.", "Password")
            Return False
        End If

        'If Me.cmbEstate.SelectedIndex = 0 Then
        '    MessageBox.Show("This field is required.", "Estate")
        '    Return False
        'End If

        Return True

    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click        
        End
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LoginFrm))

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblUname.Text = rm.GetString("lblUname.Text")
            lblLanguage.Text = rm.GetString("lblLanguage.Text")
            lblPass.Text = rm.GetString("lblPass.Text")
            btnLogin.Text = rm.GetString("btnLogin.Text")
            btnCancel.Text = rm.GetString("btnCancel.Text")
            Me.lblEstate.Text = rm.GetString("lblEstate.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLanguage.SelectedIndexChanged

        If cmbLanguage.SelectedItem = "Bahasa Indonesia" Then
            GlobalPPT.strLang = "ms"
        Else
            GlobalPPT.strLang = "en"
        End If

        SetUICulture(GlobalPPT.strLang)

    End Sub

    Private Sub cmbEstate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstate.SelectedIndexChanged

        If lbpageload = False Then

            GlobalPPT.strEstateIDCode = cmbEstate.SelectedValue.ToString
            GlobalPPT.straIdAndCode = GlobalPPT.strEstateIDCode.Split("*".ToCharArray(), 2)
            GlobalPPT.strUserName = Me.txtUName.Text
            GlobalPPT.strUserName = Me.txtUName.Text
            GlobalPPT.strEstateCode = GlobalPPT.straIdAndCode(1).ToString
            GlobalPPT.strEstateID = GlobalPPT.straIdAndCode(0).ToString
            PopulateActiveYears(GlobalPPT.strEstateID, GlobalPPT.strEstateCode, GlobalPPT.strUserName, GlobalPPT.strUserName)
            GetActiveYearMonth(GlobalPPT.strEstateID, 6)
            GlobalPPT.psEstateType = GlobalBOL.EstateTypeSelect()

        End If

    End Sub

    Private Sub FillEstateName()

        Dim obj As New EstateBOL
        EstateALL_ = obj.getEstatemaster()

        With cmbEstate
            .DataSource = EstateALL_
            .DisplayMember = "EstatecodeName"
            .ValueMember = "EstateIDCode"
        End With

        GlobalPPT.strEstateIDCode = cmbEstate.SelectedValue.ToString
        GlobalPPT.straIdAndCode = GlobalPPT.strEstateIDCode.Split("*".ToCharArray(), 2)

        GlobalPPT.strEstateCode = GlobalPPT.straIdAndCode(1).ToString
        GlobalPPT.strEstateID = GlobalPPT.straIdAndCode(0).ToString

    End Sub

    Private Sub PopulateActiveYears(ByVal strEstateId As String, ByVal strEstateCode As String, ByVal strUserName As String, ByVal strUser As String)
        Dim intAYear As Integer
        Dim intAMonth As Integer
        Dim obj As New EstateBOL
        Dim dtblYears As New DataTable

        intAYear = CType(Today.Year, Integer)
        intAMonth = CType(Today.Month, Integer)

        dtblYears = obj.GetActiveYears(strEstateId, strEstateCode, intAYear, intAMonth, strUserName, strUser)

        With lstAyear
            .DataSource = dtblYears
            .DisplayMember = "AYear"
            .ValueMember = "AYear"

        End With

    End Sub

    Private Sub PopulateYears(ByVal strEstateId As String, ByVal strEstateCode As String, ByVal strUserName As String)

        Dim intAYear As Integer
        Dim intAMonth As Integer
        Dim obj As New EstateBOL
        Dim dtblYears As New DataTable

        intAYear = CType(Today.Year, Integer)
        intAMonth = CType(Today.Month, Integer)

        dtblYears = obj.GetYears(strEstateId, strEstateCode, intAYear, intAMonth, strUserName)

        With lstAyear

            .DataSource = dtblYears
            .DisplayMember = "AYear"
            .ValueMember = "AYear"

        End With

    End Sub

    Private Sub GetActiveYearMonth(ByVal strEstateId As String, ByVal ModID As Integer)

        Dim obj As New EstateBOL
        Dim dsActive As New DataSet
        Dim intCount As Integer
        Dim drvListItem As DataRowView

        dsActive = obj.GetActiveYearMonth(strEstateId, ModID)

        If dsActive.Tables(0).Rows.Count > 0 Then

            strYear = dsActive.Tables(0).Rows(0).Item(0).ToString
            strActiveMonthYearID = dsActive.Tables(0).Rows(0).Item(2).ToString
            intCount = 0

            For Each drvListItem In lstAyear.Items
                If strYear = drvListItem.Item(0).ToString Then
                    Exit For
                End If
                intCount = intCount + 1
            Next

            intAMonth = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)
            lstAMonth.SelectedIndex = intAMonth - 1

            ''Added by arul ,for selecting the active year by default in the login form - code start

            Dim intActiveYear As Integer
            intActiveYear = CType(dsActive.Tables(0).Rows(0).Item(0).ToString, Integer)
            lstAyear.Text = intActiveYear

            ''Added by arul ,for selecting the active year by default in the login form - code end

        End If

    End Sub

    Private Sub GetEstate(ByVal strEstateId As String)

        Dim obj As New EstateBOL
        Dim intAMonth As Integer
        Dim strYear As String
        Dim dsActive As New DataSet
        Dim intCount As Integer
        Dim drvListItem As DataRowView

        dsActive = obj.GetActiveYearMonth(strEstateId, 6)

        If dsActive.Tables(0).Rows.Count > 0 Then

            strYear = dsActive.Tables(0).Rows(0).Item(0).ToString
            intCount = 0

            For Each drvListItem In lstAyear.Items
                If strYear = drvListItem.Item(0).ToString Then
                    Exit For
                End If
                intCount = intCount + 1
            Next

            intAMonth = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)
            lstAMonth.SelectedIndex = intAMonth - 1

        End If
    End Sub

    Private Sub lblLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLanguage.Click

    End Sub

    Private Sub cmbServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServer.SelectedIndexChanged
        If Not cmbServer.SelectedItem Is Nothing Then
            Dim selectedDB As DatabaseList = cmbServer.SelectedItem
            GlobalPPT.SelectedDatabaseID = selectedDB.ID
            InitializeLogin()
        End If
    End Sub

    Private Sub lblVersionNo_Click(sender As System.Object, e As System.EventArgs) Handles lblVersionNo.Click
        System.Diagnostics.Process.Start(Application.StartupPath + "\Changelog.txt")
    End Sub

    'Checks if app version and db version is correct
    Public Function VersionCheck() As Boolean
        Dim obj As New LoginBOL
        Dim dsActive As New DataSet

        dsActive = obj.GetDbVersion()

        If dsActive.Tables(0).Rows.Count > 0 Then
            If dsActive.Tables(0).Rows(0)("vcMajorRelease") = ConfigurationManager.AppSettings.Item("oVersionNo").Trim().ToString Then
                VersionCheck = True
            Else
                VersionCheck = False

            End If
        Else
            VersionCheck = False
        End If

    End Function

End Class