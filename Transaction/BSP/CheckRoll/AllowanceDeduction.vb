Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports CheckRoll_DAL
Imports Common_PPT
Imports BSP.CheckRoll.Import

Public Class AllowanceDeduction
    Public lNIK As String = String.Empty
    Public lEmpName As String = String.Empty
    Public LEmpId As String = String.Empty

    Public LADCode As String = String.Empty
    Public LADCoaID As String = String.Empty
    Public LADDescp As String = String.Empty
    Public LAllDedID As String = String.Empty
    Public LType As String = String.Empty
    Public hasil As Boolean

    Private AllowanceDeductionAdapter As AllowanceDeduction_Dal
    Public DTAllowance_Table As DataTable = New DataTable
    Public DTDeduction_Table As DataTable = New DataTable
    Public Shared AttDate As Date


    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AllowanceDeduction))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblNIK.Text = rm.GetString("lblNIK.Text")
            lblName.Text = rm.GetString("lblName.Text")
            lblCoaCode.Text = rm.GetString("lblCoaCode.Text")
            lblAmount.Text = rm.GetString("lblAmount.Text")

            lblMultiplePeriod.Text = rm.GetString("lblMultiplePeriod.Text")
            lblStartDate.Text = rm.GetString("lblStartDate.Text")
            lblEndDate.Text = rm.GetString("lblEndDate.Text")


            tcAllowanceDeduction.TabPages(0).Text = rm.GetString("tcAllowanceDeduction.TabPages(0).Text")
            tcAllowanceDeduction.TabPages(1).Text = rm.GetString("tcAllowanceDeduction.TabPages(1).Text")

            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")
            chkNIK.Text = rm.GetString("lblMonthView.Text")
            chkAllDedCode.Text = rm.GetString("lblCodeView.Text")

            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub

    Private Sub AllowanceDeduction_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        
        If txtChange.Text = "Update" Or txtChange.Text = "Delete " Then
            Dim jwb As String
            jwb = MsgBox("Your data has not been saved yet, do you want to save data?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If jwb = 6 Then
                '==================
                Dim jwab As String
                jwab = MsgBox("Are You Really Want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
                If jwab = 6 Then
                    Try
                        AllowanceDeductionAdapter.Update(DTAllowance_Table)
                        AllowanceDeductionAdapter.Update(DTDeduction_Table)
                        'If dgvAllowance.Rows.Count > 0 Then
                        '    AllowanceDeductionAdapter.Update(DTAllowance_Table)
                        'End If
                        'If dgvDeduction.Rows.Count > 0 Then
                        '    AllowanceDeductionAdapter.Update(DTDeduction_Table)
                        'End If

                        btnAdd.Visible = True
                        btnUpdate.Visible = False
                        clearall()
                        DTAllowance_Table.Clear()
                        DTDeduction_Table.Clear()
                        MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        txtChange.Text = ""
                        btnSaveAll.Enabled = False
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                    End Try
                End If
                '==================
            End If

        End If

    End Sub
    Private Sub AllowanceDeduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtStartView.Value = GlobalPPT.FiscalYearFromDate
        DtEndView.Value = GlobalPPT.FiscalYearToDate


        lblEmpID.Text = ""
        lblAllDedID.Text = ""

        'If Val((GlobalPPT.IntLoginMonth.ToString.Substring(0, Len(GlobalPPT.IntLoginMonth.ToString))).ToString()) > Val(GlobalPPT.IntActiveMonth.ToString) Then
        '    MsgBox("Your transaction has not been closed yet, In the future this screen will be disabled", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        'ElseIf Val((GlobalPPT.IntLoginMonth.ToString.Substring(0, Len(GlobalPPT.IntLoginMonth.ToString))).ToString()) < Val(GlobalPPT.IntActiveMonth.ToString) Then
        '    MsgBox("Your transaction has been closed, Only View Report Screen will be enabled in the future", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
        'ElseIf Val((GlobalPPT.IntLoginMonth.ToString.Substring(0, Len(GlobalPPT.IntLoginMonth.ToString))).ToString()) = Val(GlobalPPT.IntActiveMonth.ToString) Then

        AllowanceDeductionAdapter = New AllowanceDeduction_Dal
        Me.tcAllowanceDeduction.SelectedTab = tabView
        'Kamis, 10 Sep 2009, 01:59
        SetUICulture(GlobalPPT.strLang)

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()

        '=================================
        Try
            DTAllowance_Table.Clear()
            DTDeduction_Table.Clear()
            DTAllowance_Table = AllowanceDeduction_Dal.EmpAllowanceDeductionisSelect(lblEmpAllowDedID.Text.Trim)
            DTDeduction_Table = AllowanceDeduction_Dal.EmpAllowanceDeductionisSelect(lblEmpAllowDedID.Text.Trim)
            dgvAllowance.DataSource = DTAllowance_Table
            dgvDeduction.DataSource = DTDeduction_Table

            Dim DTALLDEDALL As DataTable
            DTALLDEDALL = AllowanceDeduction_Dal.EmpAllowanceDeductionisView(DtStartView.Value, DtEndView.Value, lblEmpID.Text.Trim, lblEmpAllowDedID.Text.Trim)
            dgvAllDedView.DataSource = DTALLDEDALL


            ArrangeView()

            DtStartView.MinDate = GlobalPPT.FiscalYearFromDate
            DtStartView.MaxDate = GlobalPPT.FiscalYearToDate
            DtEndView.MinDate = GlobalPPT.FiscalYearFromDate
            DtEndView.MaxDate = GlobalPPT.FiscalYearToDate
            dtAD.MinDate = GlobalPPT.FiscalYearFromDate
            dtAD.MaxDate = GlobalPPT.FiscalYearToDate

            If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
                DtStartView.Value = Now()
                DtEndView.Value = Now()
                dtAD.Value = Now()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'dgvAllowance.DefaultCellStyle.BackColor = Color.White
        'dgvDeduction.DefaultCellStyle.BackColor = Color.White
        'dgvAllDedView.DefaultCellStyle.BackColor = Color.White


        dgvAllowance.DefaultCellStyle.BackColor = Color.WhiteSmoke
        dgvDeduction.DefaultCellStyle.BackColor = Color.WhiteSmoke
        dgvAllDedView.DefaultCellStyle.BackColor = Color.WhiteSmoke


        DtStartView.Focus()

    End Sub
    Public Sub clear()
        txtCoaCode.Text = ""
        lblCoaDesc.Text = ""
        txtAmount.Text = ""
        lblAllDedID.Text = ""
        lblType.Text = ""
        lblEmpAllowDedID.Text = ""

    End Sub
    Public Sub clearall()
        txtnik.Text = ""
        txtname.Text = ""
        txtCoaCode.Text = ""
        lblCoaDesc.Text = ""
        txtAmount.Text = ""
        lblAllDedID.Text = ""
        lblType.Text = ""
        lblEmpAllowDedID.Text = ""

    End Sub

    Public Sub ArrangeView()

        'Arrange View Grid Allowance
        '========================
        dgvAllowance.Columns.Item("Emp Allow Ded ID").Visible = False
        dgvAllowance.Columns.Item("Estate ID").Visible = False
        dgvAllowance.Columns.Item("Estate Code").Visible = False
        dgvAllowance.Columns.Item("Employee ID").Visible = False
        dgvAllowance.Columns.Item("Allow Ded ID").Visible = False
        dgvAllowance.Columns.Item("Type").Visible = False
        dgvAllowance.Columns.Item("COA ID").Visible = False
        dgvAllowance.Columns.Item("COA Code").Visible = False
        dgvAllowance.Columns.Item("COA Descp").Visible = False
        dgvAllowance.Columns.Item("Created By").Visible = False
        dgvAllowance.Columns.Item("Created On").Visible = False
        dgvAllowance.Columns.Item("Modified By").Visible = False
        dgvAllowance.Columns.Item("Modified On").Visible = False

        'Arrange View Grid Deduction
        '========================
        dgvDeduction.Columns.Item("Emp Allow Ded ID").Visible = False
        dgvDeduction.Columns.Item("Estate ID").Visible = False
        dgvDeduction.Columns.Item("Estate Code").Visible = False
        dgvDeduction.Columns.Item("Employee ID").Visible = False
        dgvDeduction.Columns.Item("Allow Ded ID").Visible = False
        dgvDeduction.Columns.Item("Type").Visible = False
        dgvDeduction.Columns.Item("COA ID").Visible = False
        dgvDeduction.Columns.Item("COA Code").Visible = False
        dgvDeduction.Columns.Item("COA Descp").Visible = False
        dgvDeduction.Columns.Item("Created By").Visible = False
        dgvDeduction.Columns.Item("Created On").Visible = False
        dgvDeduction.Columns.Item("Modified By").Visible = False
        dgvDeduction.Columns.Item("Modified On").Visible = False

        'Arrange View Grid Deduction
        '========================
        dgvAllDedView.Columns.Item("Emp Allow Ded ID").Visible = False
        dgvAllDedView.Columns.Item("Estate ID").Visible = False
        dgvAllDedView.Columns.Item("Estate Code").Visible = False
        dgvAllDedView.Columns.Item("Employee ID").Visible = False
        dgvAllDedView.Columns.Item("Allow Ded ID").Visible = False
        dgvAllDedView.Columns.Item("Type").Visible = False
        dgvAllDedView.Columns.Item("COA ID").Visible = False
        dgvAllDedView.Columns.Item("COA Code").Visible = False
        dgvAllDedView.Columns.Item("COA Descp").Visible = False
        dgvAllDedView.Columns.Item("Created By").Visible = False
        dgvAllDedView.Columns.Item("Created On").Visible = False
        dgvAllDedView.Columns.Item("Modified By").Visible = False
        dgvAllDedView.Columns.Item("Modified On").Visible = False

    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If txtChange.Text = "Update" Or txtChange.Text = "Delete " Then
            Dim jwb As String
            jwb = MsgBox("Your data has not been saved yet, do you still want to close screen?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If jwb = 6 Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub
    Private Sub chkMulti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMulti.CheckedChanged
        If chkMulti.Checked = True Then
            msktxtStartDate.Enabled = True
            msktxtEndDate.Enabled = True
        ElseIf chkMulti.Checked = False Then
            msktxtStartDate.Enabled = False
            msktxtEndDate.Enabled = False
        End If
    End Sub

    Private Sub btnSearchactivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchactivity.Click
        NIKLookUp.Parameter.Text = ""
        AttDate = dtAD.Value
        Dim tanggal, bulan, tahun As String
        Dim Edate, Sdate As String

        tanggal = (Date.DaysInMonth(Year(dtAD.Value), Month(dtAD.Value)).ToString)
        bulan = Month(dtAD.Value).ToString()
        tahun = Year(dtAD.Value).ToString()
        Edate = (bulan + "/" + tanggal + "/" + tahun)
        Sdate = (bulan + "/" + "1" + "/" + tahun)

        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            clearall()
            btnAdd.Visible = True
            btnUpdate.Visible = False
            Try


                Me.lNIK = NIKLookUp._lNIK
                Me.lEmpName = NIKLookUp._lEmpName
                Me.LEmpId = NIKLookUp._lEmpid
                txtnik.Text = lNIK
                txtname.Text = lEmpName
                lblEmpID.Text = LEmpId
                txtCoaCode.Focus()

                '============================================
                'Search for allowance & deduction for current date
                DTAllowance_Table.Clear()
                DTAllowance_Table = AllowanceDeduction_Dal.EmpAllowanceDeductionisExist(Sdate, Edate, lblEmpID.Text.Trim, "A")
                dgvAllowance.DataSource = DTAllowance_Table

                DTDeduction_Table.Clear()
                DTDeduction_Table = AllowanceDeduction_Dal.EmpAllowanceDeductionisExist(Sdate, Edate, lblEmpID.Text.Trim, "D")
                dgvDeduction.DataSource = DTDeduction_Table

                '==========================================

                If DTAllowance_Table.Rows.Count > 0 Or DTDeduction_Table.Rows.Count > 0 Then
                    btnSaveAll.Enabled = True
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        AttDate = "12:00:00 AM"
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AllowanceDeductionLookUp.ShowDialog()
        If AllowanceDeductionLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.LADCode = AllowanceDeductionLookUp._LADCode
            Me.LADDescp = AllowanceDeductionLookUp._LADDescp
            Me.LAllDedID = AllowanceDeductionLookUp._LAllDedID
            Me.LType = AllowanceDeductionLookUp._LType
            Me.LADCoaID = AllowanceDeductionLookUp._LADCoaID
            lblEmpID.Text = LEmpId
            lblCOAID.Text = LADCoaID
            txtCoaCode.Text = LADCode
            lblCoaDesc.Text = LADDescp
            lblAllDedID.Text = LAllDedID
            lblType.Text = LType
            txtAmount.Focus()
        End If
    End Sub

    Private Sub txtnik_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnik.KeyDown
        If txtnik.Text.Trim <> "" Then


            If e.KeyCode = Keys.Enter Then
                If Not txtnik.Text = String.Empty Then
                    AttDate = dtAD.Value

                    Try
                        Dim DTNIKSelect As DataTable
                        DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtnik.Text, String.Empty, "N", "Active", AttDate)
                        'DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtnik.Text, txtname.Text, "N", "Active")
                        If DTNIKSelect.Rows.Count = 1 Then
                            ' By Dadang Adi
                            ' Senin, 30 Nov 2009, 19:00
                            ' There is a bug column employee code does not belong to table
                            ' I see in CRDailyAttendanceNikSelect the EmpCode field have alias NIK
                            ' so, the NIK field I have to use
                            '
                            ' There is a bug column employee name does not belong to table
                            ' I see in CRDailyAttendanceNikSelect the EmpName field have alias Name
                            ' so, tne Name field I have to use

                            txtnik.Text = DTNIKSelect.Rows(0).Item("Nik").ToString()
                            txtname.Text = DTNIKSelect.Rows(0).Item("Name").ToString()

                            'txtnik.Text = DTNIKSelect.Rows(0).Item("Employee code").ToString()
                            'txtname.Text = DTNIKSelect.Rows(0).Item("Employee name").ToString()
                            txtCoaCode.Focus()
                            ' END Senin, 30 Nov 2009, 19:00
                        Else
                            MsgBox("NIK is not valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                            '  btnSearchactivity.Focus()

                            txtnik.Text = ""
                            txtname.Text = ""
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Else
                    txtnik.Focus()

                End If

            End If
            AttDate = "12:00:00 AM"
        Else
            txtname.Focus()
        End If
    End Sub
    Private Function alldedchk() As Boolean
        If Not txtCoaCode.Text = String.Empty Then
            GlobalPPT.strEstateCode.ToString()
            Dim DTAllDedSetup As DataTable
            DTAllDedSetup = AllowanceDeduction_Dal.CRAllowanceDeductionSetupIsExist(txtCoaCode.Text)
            If DTAllDedSetup.Rows.Count >= 1 Then
                txtCoaCode.Text = DTAllDedSetup.Rows(0).Item("AllowDedCode").ToString()
                lblCoaDesc.Text = DTAllDedSetup.Rows(0).Item("Remarks").ToString()
                lblType.Text = DTAllDedSetup.Rows(0).Item("Type").ToString()
                lblAllDedID.Text = DTAllDedSetup.Rows(0).Item("AllowDedID").ToString()
                txtAmount.Focus()
                Return True
            ElseIf DTAllDedSetup.Rows.Count = 0 Then
                MsgBox(" Allowance & Deduction Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                lblCoaDesc.Text = String.Empty
                Return False
            End If
        Else
            Return False
        End If
    End Function


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Try
            If txtnik.Text.Trim = "" Or txtname.Text.Trim = "" Or txtCoaCode.Text.Trim = "" Then
                MsgBox("Complete your data, NIK, Code and Amount are Mandatory Field", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                If Not alldedchk() Then
                    Return
                End If
                If IsNumeric(txtAmount.Text) = False Then
                    txtAmount.Focus()
                End If
                If txtCoaCode.Text = "" Then
                    txtCoaCode.Focus()
                End If
                If txtname.Text = "" Then
                    btnSearchactivity.Focus()
                End If
                If txtnik.Text = "" Then
                    txtnik.Focus()
                End If
            ElseIf txtnik.Text.Trim <> "" And txtname.Text.Trim <> "" And txtCoaCode.Text.Trim <> "" And Val(txtAmount.Text) > 0 Then
                If Not alldedchk() Then
                    Return
                End If
                FindAllDed()
                If hasil = True Then
                    MsgBox("Data has found for current code, Please Update", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    hasil = False
                ElseIf hasil = False Then
                    'caun
                    Dim isExistInRateSetupAddConfigurable As Boolean
                    isExistInRateSetupAddConfigurable = AllowanceDeduction_Dal.RateSetupAddConfigurable(txtCoaCode.Text)
                    If (isExistInRateSetupAddConfigurable) Then
                        MsgBox("Invalid Allowance/Deduction Code, field is auto calculated by system")
                        Exit Sub
                    End If
                    If lblType.Text = "A" Then
                        Dim newdatarow As System.Data.DataRow
                        DTAllowance_Table = dgvAllowance.DataSource
                        newdatarow = DTAllowance_Table.NewRow
                        newdatarow.Item("Estate ID") = GlobalPPT.strEstateID.ToString
                        newdatarow.Item("Estate Code") = GlobalPPT.strEstateCode.ToString
                        newdatarow.Item("Employee Code") = txtnik.Text
                        newdatarow.Item("Employee Name") = txtname.Text
                        newdatarow.Item("Employee ID") = lblEmpID.Text
                        newdatarow.Item("Allow Ded ID") = lblAllDedID.Text
                        newdatarow.Item("Type") = lblType.Text
                        newdatarow.Item("Allow Ded Code") = txtCoaCode.Text
                        newdatarow.Item("Remarks") = lblCoaDesc.Text
                        newdatarow.Item("Employee Code") = txtnik.Text
                        newdatarow.Item("COA Descp") = lblCoaDesc.Text
                        newdatarow.Item("Amount") = FormatNumber(Val(txtAmount.Text), 2)
                        If chkMulti.Checked = True Then
                            newdatarow.Item("Start Date") = msktxtStartDate.Value
                            newdatarow.Item("End Date") = msktxtEndDate.Value
                        ElseIf chkMulti.Checked = False Then
                            newdatarow.Item("Start Date") = dtAD.Value
                            newdatarow.Item("End Date") = dtAD.Value
                        End If
                        newdatarow.Item("Created By") = GlobalPPT.strUserName
                        newdatarow.Item("Created On") = msktxtStartDate.Value
                        newdatarow.Item("Modified By") = GlobalPPT.strUserName
                        newdatarow.Item("Modified On") = msktxtStartDate.Value
                        DTAllowance_Table.Rows.Add(newdatarow)
                        clear()
                        txtCoaCode.Focus()
                        btnSaveAll.Enabled = True
                        btnSaveAll.Focus()
                        txtChange.Text = "ADD"
                    ElseIf lblType.Text = "D" Then
                        Dim newdatarow As System.Data.DataRow
                        DTDeduction_Table = dgvDeduction.DataSource
                        newdatarow = DTDeduction_Table.NewRow
                        newdatarow.Item("Estate ID") = GlobalPPT.strEstateID.ToString
                        newdatarow.Item("Estate Code") = GlobalPPT.strEstateCode.ToString
                        newdatarow.Item("Employee Code") = txtnik.Text
                        newdatarow.Item("Employee Name") = txtname.Text
                        newdatarow.Item("Employee ID") = lblEmpID.Text
                        newdatarow.Item("Allow Ded ID") = lblAllDedID.Text
                        newdatarow.Item("Type") = lblType.Text
                        newdatarow.Item("Allow Ded Code") = txtCoaCode.Text
                        newdatarow.Item("Remarks") = lblCoaDesc.Text
                        newdatarow.Item("COA Id") = lblCOAID.Text
                        newdatarow.Item("Employee Code") = txtnik.Text
                        newdatarow.Item("COA Descp") = lblCoaDesc.Text
                        newdatarow.Item("Amount") = FormatNumber(Val(txtAmount.Text), 2)
                        If chkMulti.Checked = True Then
                            newdatarow.Item("Start Date") = msktxtStartDate.Value
                            newdatarow.Item("End Date") = msktxtEndDate.Value
                        ElseIf chkMulti.Checked = False Then
                            newdatarow.Item("Start Date") = dtAD.Value
                            newdatarow.Item("End Date") = dtAD.Value
                        End If
                        newdatarow.Item("Created By") = GlobalPPT.strUserName
                        newdatarow.Item("Created On") = msktxtStartDate.Value
                        newdatarow.Item("Modified By") = GlobalPPT.strUserName
                        newdatarow.Item("Modified On") = msktxtStartDate.Value
                        DTDeduction_Table.Rows.Add(newdatarow)
                        clear()
                        txtCoaCode.Focus()
                        btnSaveAll.Enabled = True
                        btnSaveAll.Focus()
                        txtChange.Text = "ADD"
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtnik.Text.Trim = "" Or txtname.Text.Trim = "" Or txtCoaCode.Text.Trim = "" Then
            MsgBox("Complete your data, NIK, Code and Amount are Mandatory Field", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            If Not alldedchk() Then
                Return
            End If
            If IsNumeric(txtAmount.Text) = False Then
                txtAmount.Focus()
            End If
            If txtCoaCode.Text = "" Then
                txtCoaCode.Focus()
            End If
            If txtname.Text = "" Then
                btnSearchactivity.Focus()
            End If
            If txtnik.Text = "" Then
                txtnik.Focus()
            End If
        Else
            If Not alldedchk() Then
                Return
            End If
            If lblType.Text = "A" Then
                DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("Employee Code") = txtnik.Text
                DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("Employee Name") = txtname.Text
                DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("COA Code") = txtCoaCode.Text
                DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("COA Descp") = lblCoaDesc.Text
                DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("Amount") = FormatNumber(Val(txtAmount.Text), 2)
                If chkMulti.Checked = True Then
                    DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("Start Date") = msktxtStartDate.Value
                    DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("End Date") = msktxtEndDate.Value
                ElseIf chkMulti.Checked = False Then
                    DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("Start Date") = dtAD.Value
                    DTAllowance_Table.Rows(dgvAllowance.CurrentCell.RowIndex).Item("End Date") = dtAD.Value
                End If
                clear()
                txtChange.Text = "Update"
                btnSaveAll.Enabled = True
                MsgBox("Data successfully updated, click save all to confirm", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                btnSaveAll.Enabled = True
                btnSaveAll.Focus()
                btnAdd.Visible = True
                btnUpdate.Visible = False
            ElseIf lblType.Text = "D" Then
                DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Employee Code") = txtnik.Text
                DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Employee Name") = txtname.Text
                DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Allow Ded Code") = txtCoaCode.Text
                DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Remarks") = lblCoaDesc.Text
                DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Amount") = FormatNumber(Val(txtAmount.Text), 2)
                If chkMulti.Checked = True Then
                    DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Start Date") = msktxtStartDate.Value
                    DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("End Date") = msktxtEndDate.Value
                ElseIf chkMulti.Checked = False Then
                    DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("Start Date") = dtAD.Value
                    DTDeduction_Table.Rows(dgvDeduction.CurrentCell.RowIndex).Item("End Date") = dtAD.Value
                End If
                clear()
                txtChange.Text = "Update"
                MsgBox("Data successfully updated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                btnSaveAll.Enabled = True
                btnSaveAll.Focus()
                btnAdd.Visible = True
                btnUpdate.Visible = False
            End If
        End If






    End Sub

    Private Sub dgvAllowance_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAllowance.DoubleClick
        Try
            txtnik.Text = dgvAllowance.SelectedRows(0).Cells("Employee Code").Value()
            txtname.Text = dgvAllowance.SelectedRows(0).Cells("Employee Name").Value()
            txtCoaCode.Text = dgvAllowance.SelectedRows(0).Cells("Allow Ded Code").Value()
            lblCoaDesc.Text = dgvAllowance.SelectedRows(0).Cells("Remarks").Value()
            txtAmount.Text = dgvAllowance.SelectedRows(0).Cells("Amount").Value()
            msktxtStartDate.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value()
            msktxtEndDate.Value = dgvAllowance.SelectedRows(0).Cells("End Date").Value()

            If dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString > dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                chkMulti.Checked = True
                msktxtStartDate.Enabled = True
                msktxtEndDate.Enabled = True
                msktxtEndDate.Value = dgvAllowance.SelectedRows(0).Cells("End Date").Value
                msktxtStartDate.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value
            ElseIf dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString <= dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                chkMulti.Checked = False
                msktxtStartDate.Enabled = False
                msktxtEndDate.Enabled = False
                dtAD.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value
            End If

            lblType.Text = "A"
            btnAdd.Visible = False
            btnUpdate.Visible = True
            btnSaveAll.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dgvAllowance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAllowance.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtnik.Text = dgvAllowance.SelectedRows(0).Cells("Employee Code").Value()
                txtname.Text = dgvAllowance.SelectedRows(0).Cells("Employee Name").Value()
                txtCoaCode.Text = dgvAllowance.SelectedRows(0).Cells("Allow Ded Code").Value()
                lblCoaDesc.Text = dgvAllowance.SelectedRows(0).Cells("Remarks").Value()
                txtAmount.Text = dgvAllowance.SelectedRows(0).Cells("Amount").Value()
                msktxtStartDate.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value()
                msktxtEndDate.Value = dgvAllowance.SelectedRows(0).Cells("End Date").Value()

                If dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString > dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                    chkMulti.Checked = True
                    msktxtStartDate.Enabled = True
                    msktxtEndDate.Enabled = True
                ElseIf dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString <= dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                    chkMulti.Checked = False
                    msktxtStartDate.Enabled = False
                    msktxtEndDate.Enabled = False
                End If

                lblType.Text = "A"
                btnAdd.Visible = False
                btnUpdate.Visible = True
                btnSaveAll.Enabled = False
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub


    Private Sub dgvDeduction_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDeduction.DoubleClick
        txtnik.Text = dgvDeduction.SelectedRows(0).Cells("Employee Code").Value()
        txtname.Text = dgvDeduction.SelectedRows(0).Cells("Employee Name").Value()
        txtCoaCode.Text = dgvDeduction.SelectedRows(0).Cells("Allow Ded Code").Value()
        lblCoaDesc.Text = dgvDeduction.SelectedRows(0).Cells("Remarks").Value()
        txtAmount.Text = dgvDeduction.SelectedRows(0).Cells("Amount").Value()
        msktxtStartDate.Value = dgvDeduction.SelectedRows(0).Cells("Start Date").Value()
        msktxtEndDate.Value = dgvDeduction.SelectedRows(0).Cells("End Date").Value()

        If dgvDeduction.SelectedRows(0).Cells("End Date").Value().ToString > dgvDeduction.SelectedRows(0).Cells("Start Date").Value() Then
            chkMulti.Checked = True
            msktxtStartDate.Enabled = True
            msktxtEndDate.Enabled = True
            msktxtEndDate.Value = dgvDeduction.SelectedRows(0).Cells("End Date").Value
            msktxtStartDate.Value = dgvDeduction.SelectedRows(0).Cells("Start Date").Value
        ElseIf dgvDeduction.SelectedRows(0).Cells("End Date").Value().ToString <= dgvDeduction.SelectedRows(0).Cells("Start Date").Value() Then
            chkMulti.Checked = False
            msktxtStartDate.Enabled = False
            msktxtEndDate.Enabled = False
            btnSaveAll.Enabled = False
            dtAD.Value = dgvDeduction.SelectedRows(0).Cells("Start Date").Value
        End If

        lblType.Text = "D"
        btnAdd.Visible = False
        btnUpdate.Visible = True
    End Sub

    Private Sub dgvDeduction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDeduction.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtnik.Text = dgvDeduction.SelectedRows(0).Cells("Employee Code").Value()
            txtname.Text = dgvDeduction.SelectedRows(0).Cells("Employee Name").Value()
            txtCoaCode.Text = dgvDeduction.SelectedRows(0).Cells("Allow Ded Code").Value()
            lblCoaDesc.Text = dgvDeduction.SelectedRows(0).Cells("Remarks").Value()
            txtAmount.Text = dgvDeduction.SelectedRows(0).Cells("Amount").Value()
            msktxtStartDate.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value()
            msktxtEndDate.Value = dgvAllowance.SelectedRows(0).Cells("End Date").Value()

            If dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString > dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                chkMulti.Checked = True
                msktxtStartDate.Enabled = True
                msktxtEndDate.Enabled = True
            ElseIf dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString <= dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                chkMulti.Checked = False
                msktxtStartDate.Enabled = False
                msktxtEndDate.Enabled = False
                btnSaveAll.Enabled = False
            End If

            lblType.Text = "D"
            btnAdd.Visible = False
            btnUpdate.Visible = True
        End If

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        If txtname.Text = "" Or txtCoaCode.Text = "" Or Val(txtAmount.Text) = 0 Then
            If txtChange.Text = "" Then
                MsgBox("Please complete your data, NIK, Name, Code, Amount are Mandatory Field ", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                Return
            ElseIf txtChange.Text <> "" Then
                Dim jwb As String
                jwb = MsgBox("Do you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
                If jwb = 6 Then
                    Try
                        AllowanceDeductionAdapter.Update(DTAllowance_Table)
                        AllowanceDeductionAdapter.Update(DTDeduction_Table)
                        btnAdd.Visible = True
                        btnUpdate.Visible = False
                        clearall()
                        DTAllowance_Table.Clear()
                        DTDeduction_Table.Clear()

                        ' By Dadang Adi H
                        ' Jum'at, 1 Jan 2010, 13:17
                        CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                        ' END Jum'at, 1 Jan 2010, 13:17

                        MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        txtChange.Text = ""
                        btnSaveAll.Enabled = False
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                    End Try
                End If
            End If
        ElseIf txtname.Text = "" And txtCoaCode.Text = "" And Val(txtAmount.Text) = 0 Then
            Dim jwb As String
            jwb = MsgBox("Do you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
            If jwb = 6 Then
                Try
                    AllowanceDeductionAdapter.Update(DTAllowance_Table)
                    AllowanceDeductionAdapter.Update(DTDeduction_Table)
                    btnAdd.Visible = True
                    btnUpdate.Visible = False
                    clearall()
                    DTAllowance_Table.Clear()
                    DTDeduction_Table.Clear()

                    ' By Dadang Adi H
                    ' Jum'at, 1 Jan 2010, 13:18
                    CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                    ' END Jum'at, 1 Jan 2010, 13:18

                    MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    txtChange.Text = ""
                    btnSaveAll.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                End Try
            End If
        Else
            Dim jwb As String
            jwb = MsgBox("Do you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
            If jwb = 6 Then
                Try
                    AllowanceDeductionAdapter.Update(DTAllowance_Table)
                    AllowanceDeductionAdapter.Update(DTDeduction_Table)
                    btnAdd.Visible = True
                    btnUpdate.Visible = False
                    clearall()
                    DTAllowance_Table.Clear()
                    DTDeduction_Table.Clear()

                    ' By Dadang Adi H
                    ' Jum'at, 1 Jan 2010, 13:18
                    CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                    ' END Jum'at, 1 Jan 2010, 13:18

                    MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    txtChange.Text = ""
                    btnSaveAll.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                End Try
            End If
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim jwb As String
        jwb = MsgBox("Are you sure want to delete this Data", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
        If jwb = 6 Then
            dgvAllowance.Rows.RemoveAt(dgvAllowance.CurrentRow.Index.ToString)
            txtChange.Text = "Delete"
            MsgBox("Your data has been deleted, please Save All to confirm", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
            btnSaveAll.Enabled = True
            btnSaveAll.Focus()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem1.Click
        Dim jwb As String
        jwb = MsgBox("Are you sure want to delete this Data", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
        If jwb = 6 Then
            Try
                dgvDeduction.Rows.RemoveAt(dgvDeduction.CurrentRow.Index.ToString)
                txtChange.Text = "Delete"
                btnSaveAll.Enabled = True
                btnSaveAll.Focus()
                MsgBox("Your data has been deleted, please Save All to confirm", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            txtnik.Text = dgvAllowance.SelectedRows(0).Cells("Employee Code").Value()
            txtname.Text = dgvAllowance.SelectedRows(0).Cells("Employee Name").Value()
            txtCoaCode.Text = dgvAllowance.SelectedRows(0).Cells("Allow Ded Code").Value()
            lblCoaDesc.Text = dgvAllowance.SelectedRows(0).Cells("Remarks").Value()
            txtAmount.Text = dgvAllowance.SelectedRows(0).Cells("Amount").Value()
            msktxtStartDate.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value()
            msktxtEndDate.Value = dgvAllowance.SelectedRows(0).Cells("End Date").Value()

            If dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString > dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                chkMulti.Checked = True
                msktxtStartDate.Enabled = True
                msktxtEndDate.Enabled = True
                msktxtEndDate.Value = dgvAllowance.SelectedRows(0).Cells("End Date").Value
                msktxtStartDate.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value
            ElseIf dgvAllowance.SelectedRows(0).Cells("End Date").Value().ToString <= dgvAllowance.SelectedRows(0).Cells("Start Date").Value() Then
                chkMulti.Checked = False
                msktxtStartDate.Enabled = False
                msktxtEndDate.Enabled = False
                dtAD.Value = dgvAllowance.SelectedRows(0).Cells("Start Date").Value
            End If

            lblType.Text = "A"
            btnAdd.Visible = False
            btnUpdate.Visible = True
            btnSaveAll.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        txtnik.Text = dgvDeduction.SelectedRows(0).Cells("Employee Code").Value()
        txtname.Text = dgvDeduction.SelectedRows(0).Cells("Employee Name").Value()
        txtCoaCode.Text = dgvDeduction.SelectedRows(0).Cells("Allow Ded Code").Value()
        lblCoaDesc.Text = dgvDeduction.SelectedRows(0).Cells("Remarks").Value()
        txtAmount.Text = dgvDeduction.SelectedRows(0).Cells("Amount").Value()
        msktxtStartDate.Value = dgvDeduction.SelectedRows(0).Cells("Start Date").Value()
        msktxtEndDate.Value = dgvDeduction.SelectedRows(0).Cells("End Date").Value()

        If dgvDeduction.SelectedRows(0).Cells("End Date").Value().ToString > dgvDeduction.SelectedRows(0).Cells("Start Date").Value() Then
            chkMulti.Checked = True
            msktxtStartDate.Enabled = True
            msktxtEndDate.Enabled = True
            msktxtEndDate.Value = dgvDeduction.SelectedRows(0).Cells("End Date").Value
            msktxtStartDate.Value = dgvDeduction.SelectedRows(0).Cells("Start Date").Value
        ElseIf dgvDeduction.SelectedRows(0).Cells("End Date").Value().ToString <= dgvDeduction.SelectedRows(0).Cells("Start Date").Value() Then
            chkMulti.Checked = False
            msktxtStartDate.Enabled = False
            msktxtEndDate.Enabled = False
            btnSaveAll.Enabled = False
            dtAD.Value = dgvDeduction.SelectedRows(0).Cells("Start Date").Value
        End If

        lblType.Text = "D"
        btnAdd.Visible = False
        btnUpdate.Visible = True
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearall()
        btnAdd.Visible = True
        btnUpdate.Visible = False
        btnSaveAll.Enabled = True
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening

    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnAdd.Visible = True Then
                If IsNumeric(txtAmount.Text) = False Then
                    MsgBox("Please key in numeric data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtAmount.Text = ""
                    txtAmount.Focus()
                ElseIf IsNumeric(txtAmount.Text) = True Then
                    btnAdd.Focus()
                End If
            ElseIf btnUpdate.Visible = True Then
                If IsNumeric(txtAmount.Text) = False Then
                    MsgBox("Please key in numeric data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtAmount.Text = ""
                    txtAmount.Focus()
                ElseIf IsNumeric(txtAmount.Text) = True Then
                    btnAdd.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCoaCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCoaCode.KeyDown
        If Not txtCoaCode.Text = String.Empty Then

            Try
                If e.KeyCode = Keys.Enter Then
                    GlobalPPT.strEstateCode.ToString()

                    Dim DTAllDedSetup As DataTable
                    DTAllDedSetup = AllowanceDeduction_Dal.CRAllowanceDeductionSetupIsExist(txtCoaCode.Text)

                    If DTAllDedSetup.Rows.Count = 1 Then
                        txtCoaCode.Text = DTAllDedSetup.Rows(0).Item("AllowDedCode").ToString()
                        lblCoaDesc.Text = DTAllDedSetup.Rows(0).Item("Remarks").ToString()
                        lblType.Text = DTAllDedSetup.Rows(0).Item("Type").ToString()
                        lblAllDedID.Text = DTAllDedSetup.Rows(0).Item("AllowDedID").ToString()
                        txtAmount.Focus()

                    ElseIf DTAllDedSetup.Rows.Count = 0 OrElse DTAllDedSetup.Rows.Count > 1 Then
                        MsgBox(" Allowance & Deduction Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            txtCoaCode.Focus()

        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkNIK.Checked = False Then
            lblEmpID.Text = String.Empty
        ElseIf chkAllDedCode.Checked = False Then
            lblAllDedID.Text = String.Empty
        End If
        Try
            Dim DTALLDEDALL As DataTable
            DTALLDEDALL = AllowanceDeduction_Dal.EmpAllowanceDeductionisView(DtStartView.Value, DtEndView.Value, lblEmpID.Text.Trim, lblAllDedID.Text.Trim)
            dgvAllDedView.DataSource = DTALLDEDALL
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchNIK.Click
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.lNIK = NIKLookUp._lNIK
            Me.lEmpName = NIKLookUp._lEmpName
            Me.LEmpId = NIKLookUp._lEmpid
            txtEmpidView.Text = lNIK
            lblNameView.Text = lEmpName
            lblEmpID.Text = LEmpId
        End If

    End Sub
    Private Sub btnSearchSIVNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSIVNumber.Click
        AllowanceDeductionLookUp.ShowDialog()
        If AllowanceDeductionLookUp.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.LADCode = AllowanceDeductionLookUp._LADCode
            Me.LADDescp = AllowanceDeductionLookUp._LADDescp
            Me.LAllDedID = AllowanceDeductionLookUp._LAllDedID
            Me.LType = AllowanceDeductionLookUp._LType
            Me.LADCoaID = AllowanceDeductionLookUp._LADCoaID
            lblEmpID.Text = LEmpId
            lblCOAID.Text = LADCoaID
            txtAllDedCode.Text = LADCode
            lblAllDedCodeDescpview.Text = LADDescp
            lblAllDedID.Text = LAllDedID
            lblType.Text = LType
            txtAmount.Focus()
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub chkNIK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkNIK.Checked = True Then
            txtAllDedCode.Text = ""
            btnSearchNIK.Enabled = True
            btnSearchSIVNumber.Enabled = False
            lblAllDedCodeDescpview.Text = ""
        End If

    End Sub
    Private Sub chkAllDedCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkAllDedCode.Checked = True Then
            txtEmpidView.Text = ""
            lblEmpID.Text = ""
            btnSearchNIK.Enabled = False
            btnSearchSIVNumber.Enabled = True
            lblNameView.Text = ""
        End If
    End Sub

    Private Sub dgvAllDedView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllDedView.CellContentClick

    End Sub

    Private Sub dgvAllDedView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAllDedView.DoubleClick
        Try
            txtnik.Text = dgvAllDedView.SelectedRows(0).Cells("Employee Code").Value()
            txtname.Text = dgvAllDedView.SelectedRows(0).Cells("Employee Name").Value()
            lblEmpID.Text = dgvAllDedView.SelectedRows(0).Cells("Employee ID").Value()
            txtCoaCode.Text = dgvAllDedView.SelectedRows(0).Cells("Allow Ded Code").Value()
            lblCoaDesc.Text = dgvAllDedView.SelectedRows(0).Cells("Remarks").Value()
            txtAmount.Text = dgvAllDedView.SelectedRows(0).Cells("Amount").Value()

            If dgvAllDedView.SelectedRows(0).Cells("End Date").Value().ToString <> Nothing Then
                msktxtStartDate.Value = dgvAllDedView.SelectedRows(0).Cells("Start Date").Value()
                msktxtEndDate.Value = dgvAllDedView.SelectedRows(0).Cells("End Date").Value()
            ElseIf dgvAllDedView.SelectedRows(0).Cells("End Date").Value().ToString = Nothing Then
                msktxtStartDate.Value = dgvAllDedView.SelectedRows(0).Cells("Start Date").Value()
            End If

            lblType.Text = dgvAllDedView.SelectedRows(0).Cells("Type").Value()
            btnAdd.Visible = False
            btnUpdate.Visible = True

            '===========================
            'Bind  DatagridView Allowance & deduction
            DTAllowance_Table.Clear()
            DTAllowance_Table = AllowanceDeduction_Dal.EmpAllowanceDeductionisExist(DtStartView.Value, DtEndView.Value, lblEmpID.Text.Trim, "A")
            dgvAllowance.DataSource = DTAllowance_Table

            DTDeduction_Table.Clear()
            DTDeduction_Table = AllowanceDeduction_Dal.EmpAllowanceDeductionisExist(DtStartView.Value, DtEndView.Value, lblEmpID.Text.Trim, "D")
            dgvDeduction.DataSource = DTDeduction_Table

            '=======================

            Me.tcAllowanceDeduction.SelectedTab = tabAllowanceDeduction
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DtView_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtStartView.ValueChanged
        dtAD.Value = DtStartView.Value
        If chkPeriod.Checked = False Then
            DtEndView.Value = DtStartView.Value
        End If
    End Sub

    Private Sub FindAllDed()
        Dim i, k As Integer
        hasil = False

        For i = 0 To dgvAllowance.Rows.Count - 1
            If dgvAllowance.Rows(i).Cells("Allow Ded ID").Value = lblAllDedID.Text And dgvAllowance.Rows(i).Cells("End Date").Value = dtAD.Value Then
                hasil = True
            End If
        Next i

        For k = 0 To dgvDeduction.Rows.Count - 1
            If dgvDeduction.Rows(k).Cells("Allow Ded ID").Value = lblAllDedID.Text And dgvDeduction.Rows(k).Cells("End Date").Value = dtAD.Value Then
                hasil = True
            End If
        Next k


    End Sub
    Private Sub chkPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPeriod.CheckedChanged
        'If chkPeriod.Checked = True Then
        '    DtEndView.Enabled = True
        '    DtStartView.Enabled = True
        'ElseIf chkPeriod.Checked = False Then
        '    DtEndView.Enabled = False
        '    DtStartView.Enabled = False
        'End If
        DtEndView.Enabled = True
        DtStartView.Enabled = True

    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        'MsgBox("Under Construction")
        ' By Dadang Adi H
        ' Selasa, 23 Feb 2010, 11:04
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String
        Dim StartDate As String
        Dim EndDate As String

        StartDate = DtStartView.Value.ToString("yyyy/MM/dd")
        'If chkPeriod.Checked = False Then
        '    EndDate = StartDate
        'Else
        EndDate = DtEndView.Value.ToString("yyyy/MM/dd")
        'End If

        ReportName = "CREmpAllowanceDeductionReport"
        report._Source = ReportName
        report._Formula = _
                "{CREmpAllowanceDeductionReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
                "{CREmpAllowanceDeductionReport;1.StartDate} >= #" + StartDate + "# AND " + _
                "{CREmpAllowanceDeductionReport;1.EndDates} <= #" + EndDate + "#"

        If Not String.IsNullOrEmpty(txtAllDedCode.Text) Then
            report._Formula = report._Formula + " AND " + _
                "{CREmpAllowanceDeductionReport;1.AllowDedCode} = '" + txtAllDedCode.Text + "'"
        End If

        If Not String.IsNullOrEmpty(txtEmpidView.Text) Then
            report._Formula = report._Formula + " AND " + _
                "{CREmpAllowanceDeductionReport;1.EmpCode} = '" + txtEmpidView.Text + "'"
        End If

        report.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllDedCode.CheckedChanged
        If chkAllDedCode.Checked = True Then
            chkNIK.Checked = False
            txtEmpidView.Text = String.Empty
            lblEmpID.Text = String.Empty
            btnSearchNIK.Enabled = False
            btnSearchSIVNumber.Enabled = True
            lblNameView.Text = String.Empty
        ElseIf chkAllDedCode.Checked = False Then
            txtAllDedCode.Text = String.Empty
            btnSearchSIVNumber.Enabled = False
            lblAllDedCodeDescpview.Text = String.Empty
            lblAllDedID.Text = String.Empty
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNIK.CheckedChanged
        If chkNIK.Checked = True Then
            chkAllDedCode.Checked = False
            txtAllDedCode.Text = String.Empty
            btnSearchNIK.Enabled = True
            btnSearchSIVNumber.Enabled = False
            lblAllDedCodeDescpview.Text = String.Empty
        ElseIf chkNIK.Checked = False Then
            txtEmpidView.Text = String.Empty
            lblEmpID.Text = String.Empty
            btnSearchNIK.Enabled = False
            lblNameView.Text = String.Empty
            lblEmpID.Text = String.Empty
        End If
    End Sub

    Private Sub tcAllowanceDeduction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcAllowanceDeduction.SelectedIndexChanged
        If tcAllowanceDeduction.SelectedIndex = 1 Then
            DtStartView.Value = GlobalPPT.FiscalYearFromDate
            DtEndView.Value = GlobalPPT.FiscalYearToDate
            chkAllDedCode.Checked = False
            chkNIK.Checked = False
            Dim DTALLDEDALL As DataTable
            DTALLDEDALL = AllowanceDeduction_Dal.EmpAllowanceDeductionisView(DtStartView.Value, DtEndView.Value, lblEmpID.Text.Trim, lblAllDedID.Text.Trim)
            dgvAllDedView.DataSource = DTALLDEDALL
        ElseIf tcAllowanceDeduction.SelectedIndex = 0 Then
            dtAD.Focus()
        End If

    End Sub

    Private Sub txtnik_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnik.Leave

        If Not txtnik.Text = String.Empty Then

            AttDate = dtAD.Value
            Dim DTNIKSelect As DataTable
            DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtnik.Text.Trim, String.Empty, "N", "Active", AttDate)
            'DTNIKSelect = CheckRoll_BOL.LookUpBOL.DailyAttendanceNikSelect(txtnik.Text, txtname.Text, "N", "Active")
            If DTNIKSelect.Rows.Count = 1 Then
                ' By Dadang Adi
                ' Senin, 30 Nov 2009, 19:00
                ' There is a bug column employee code does not belong to table
                ' I see in CRDailyAttendanceNikSelect the EmpCode field have alias NIK
                ' so, the NIK field I have to use
                '
                ' There is a bug column employee name does not belong to table
                ' I see in CRDailyAttendanceNikSelect the EmpName field have alias Name
                ' so, tne Name field I have to use

                txtnik.Text = DTNIKSelect.Rows(0).Item("Nik").ToString()
                txtname.Text = DTNIKSelect.Rows(0).Item("Name").ToString()
                lblEmpID.Text = DTNIKSelect.Rows(0).Item("Employee ID").ToString()
                Me.lNIK = DTNIKSelect.Rows(0).Item("Nik").ToString()
                Me.lEmpName = DTNIKSelect.Rows(0).Item("Name").ToString()
                Me.LEmpId = DTNIKSelect.Rows(0).Item("Employee ID").ToString()

                'txtnik.Text = DTNIKSelect.Rows(0).Item("Employee code").ToString()
                'txtname.Text = DTNIKSelect.Rows(0).Item("Employee name").ToString()
                txtCoaCode.Focus()
                ' END Senin, 30 Nov 2009, 19:00
            Else
                ' MsgBox("NIK is not valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                '  btnSearchactivity.Focus()
                txtnik.Text = ""
                txtname.Text = ""
                lblEmpID.Text = ""
                Me.lNIK = String.Empty
                Me.lEmpName = String.Empty
                Me.LEmpId = String.Empty

            End If
        Else
            txtnik.Text = ""
            txtname.Text = ""
        End If
        AttDate = "12:00:00 AM"
    End Sub
    Private Sub txtCoaCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCoaCode.Leave
        If Not txtCoaCode.Text = String.Empty Then

            GlobalPPT.strEstateCode.ToString()

            Dim DTAllDedSetup As DataTable
            DTAllDedSetup = AllowanceDeduction_Dal.CRAllowanceDeductionSetupIsExist(txtCoaCode.Text.Trim)

            If DTAllDedSetup.Rows.Count >= 1 Then
                txtCoaCode.Text = DTAllDedSetup.Rows(0).Item("AllowDedCode").ToString()
                lblCoaDesc.Text = DTAllDedSetup.Rows(0).Item("Remarks").ToString()
                lblType.Text = DTAllDedSetup.Rows(0).Item("Type").ToString()
                lblAllDedID.Text = DTAllDedSetup.Rows(0).Item("AllowDedID").ToString()
                txtAmount.Focus()

            ElseIf DTAllDedSetup.Rows.Count = 0 Then

                MsgBox(" Allowance & Deduction Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                lblCoaDesc.Text = String.Empty
            End If
        Else
            lblCoaDesc.Text = String.Empty
        End If
    End Sub

    Private Sub AllowanceDeduction_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtAmount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        If Val(txtAmount.Text) > 0 Then


            If btnAdd.Visible = True Then
                If IsNumeric(txtAmount.Text) = False Then
                    MsgBox("Please key in numeric data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtAmount.Text = ""
                    txtAmount.Focus()
                ElseIf IsNumeric(txtAmount.Text) = True Then
                    btnAdd.Focus()
                End If
            ElseIf btnUpdate.Visible = True Then
                If IsNumeric(txtAmount.Text) = False Then
                    MsgBox("Please key in numeric data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtAmount.Text = ""
                    txtAmount.Focus()
                ElseIf IsNumeric(txtAmount.Text) = True Then
                    btnAdd.Focus()
                End If
            End If
        Else
            btnAdd.Focus()
        End If
    End Sub

    Private Sub BtnImport_Click(sender As System.Object, e As System.EventArgs) Handles BtnImport.Click
        ImportAllowance.ShowDialog()
    End Sub
End Class