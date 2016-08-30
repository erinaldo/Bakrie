'
'
' Programmer: Dadang Adi Hendradi
' Created   : Sabtu, 26 Sep 2009, 02:28
' Modified  : Monday, 16 Nov 2009, 00:03
' Place     : Balikpapan
'

Imports CheckRoll_DAL
Imports Common_BOL  ' 09-11-2012
Imports Common_PPT
' Thursday, 10 Sep 2009, 00:20
Imports System.Globalization
Imports System.Threading

Public Class AdvancePayment

    Private AdvancePaymentTableAdapter As New CheckRoll_DAL.AdvancePayment_DAL()
    Private DT_AdvancePayment As DataTable

    Private AdvancePaymentDetTableAdapter As New CheckRoll_DAL.AdvancePaymentDet_DAL()
    Private DT_AdvancePaymentDet As DataTable

    Private DT_AdvancePaymentDetView As DataTable

    Private dHK As Decimal = 0
    Private dAdvancePremium As Decimal = 0
    Private dAmount As Decimal = 0

    ' Rabu, 18 Nov 2009, 18:45
    Private dJHTEmployee As Decimal = 0
    Private dJamsostek As Decimal = 0
    Private dBalanceAdvancePayment As Decimal = 0
    Private dAdvancePayment As Decimal = 0
    Private dAdvanvePaymentFormula As Decimal = 0

    Private AdvancePaymentID As String = String.Empty

    ' Sabtu, 13 Feb 2010, 22:49, 22:30
    Private dRiceDividerDays As Decimal = 0
    ' END Sabtu, 13 Feb 2010, 22:49, 22:30

    ' Ahad, 14 Mar 2010, 00:52
    Private dBasicRate As Decimal = 0

    ' Senin, 23 Nov 2009, 11:36
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False

    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdvancePayment))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDate.Text = rm.GetString("lblDate.Text")
            lblCategory.Text = rm.GetString("lblCategory.Text")
            lblAPremium.Text = rm.GetString("lblAPremium.Text")

            lblNIK.Text = rm.GetString("lblNIK.Text")
            lblName.Text = rm.GetString("lblName.Text")
            lblHK.Text = rm.GetString("lblHK.Text")
            lblAmount.Text = rm.GetString("lblAmount.Text")
            btnGenerate.Text = rm.GetString("btnGenerate.Text")

            tcAdvancePayment.TabPages(0).Text = rm.GetString("tcAdvancePayment.TabPages(0).Text")
            tcAdvancePayment.TabPages(1).Text = rm.GetString("tcAdvancePayment.TabPages(1).Text")
            'lblViewDate.Text = rm.GetString("lblViewDate.Text")
            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

            'btnUpdate.Text = rm.GetString("btnAdd.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSearchView.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub

    Private Sub AdvancePayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Kamis, 10 Sep 2009, 00:19
        SetUICulture(GlobalPPT.strLang)

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()

        'Sabtu, 26 Sep 2009, 20:30
        '''''
        ' AdvancePayment
        DT_AdvancePayment = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
            "01/01/1900", "")

        dgvAdvancePayment.DataSource = DT_AdvancePayment

        '''''
        ' AdvancePaymentDet
        DT_AdvancePaymentDet = AdvancePaymentDetTableAdapter.AdvancePaymentDetSelect( _
            "", _
            GlobalPPT.strEstateID)
        dgvAdvancePaymentDet.DataSource = DT_AdvancePaymentDet
        ManagedgvAdvancePaymentDetColumn()

        DT_AdvancePaymentDetView = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
            dtpAdvProcessingDateView.Value, _
            "")
        dgvAdvancePaymentView.DataSource = DT_AdvancePaymentDetView
        ManagedgvAdvancePaymentViewColumn()

        tcAdvancePayment.SelectedTab = tabView

        If (GlobalPPT.IntLoginMonth < GlobalPPT.IntActiveMonth) Then
            MessageBox.Show("Your  transaction has been closed, only View Report screen will be enabled in the future", _
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        ElseIf GlobalPPT.IntLoginMonth > GlobalPPT.IntActiveMonth Then

            MessageBox.Show("Your Transaction has not been closed yet, in the future this screen will be disabled", _
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        'commented by suraya 09112012
        'dtpAdvProcessingDate.MinDate = GlobalPPT.FiscalYearFromDate
        'dtpAdvProcessingDate.MaxDate = GlobalPPT.FiscalYearToDate

        ''dtpAdvProcessingDateView.MinDate = GlobalPPT.FiscalYearFromDate
        ''dtpAdvProcessingDateView.MaxDate = GlobalPPT.FiscalYearToDate
        'dtpAdvProcessingDateView.MaxDate = GlobalPPT.FiscalYearToDate
        'dtpAdvProcessingDateView.Value = GlobalPPT.FiscalYearToDate


        'If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
        '    dtpAdvProcessingDate.Value = Now
        '    dtpAdvProcessingDateView.Value = Now
        'End If

        'add by suraya 09112012
        dtpAdvProcessingDate.Format = DateTimePickerFormat.Custom
        dtpAdvProcessingDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpAdvProcessingDate)

        dtpAdvProcessingDateView.Format = DateTimePickerFormat.Custom
        dtpAdvProcessingDateView.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpAdvProcessingDateView)

        dgvAdvancePaymentDet.DefaultCellStyle.BackColor = Color.White
        '  dgvAdvancePaymentView.DefaultCellStyle.BackColor = Color.White

        ' Senin, 23 Nov 2009, 02:01
        lblEmpCode.Text = String.Empty
        lblEmpID.Text = String.Empty

        dtpAdvProcessingDateView.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        NIKLookUp.Show()
    End Sub

    Private Sub btnSearchName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        ' Jum'at, 25 Sep 2009, 21:13
        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select Category First", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim EmpCategory As String = CboCategory.SelectedItem.ToString()
        Dim NikNameByCategoryLookup_Form As NIKByTeamCategoryLookUp

        NikNameByCategoryLookup_Form = New NIKByTeamCategoryLookUp()

        NikNameByCategoryLookup_Form.Category = EmpCategory
        NikNameByCategoryLookup_Form.ShowDialog()


        If NikNameByCategoryLookup_Form.DialogResult = Windows.Forms.DialogResult.OK Then
            txtNIK.Text = NikNameByCategoryLookup_Form.EmpCode
            txtName.Text = NikNameByCategoryLookup_Form.EmpName

            lblEmpCode.Text = NikNameByCategoryLookup_Form.EmpCode
            lblEmpID.Text = NikNameByCategoryLookup_Form.EmpID

            getEmpAdvancePayment()
        End If
    End Sub

    Private Sub getEmpAdvancePayment()
        ' Rabu, 30 Sep 2009, 05:43
        Dim FromDate As Date
        Dim DT_Fiscalyear As DataTable

        DT_Fiscalyear = AdvancePayment_DAL.FiscalYear(dtpAdvProcessingDate.Value.Year, dtpAdvProcessingDate.Value.Month)

        If DT_Fiscalyear.Rows.Count = 0 Then
            MessageBox.Show("Fiscal Year has not been setup", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return
        End If

        FromDate = DT_Fiscalyear.Rows(0).Item("FromDT")

        dHK = 0

        Dim DT_HK As DataTable
        DT_HK = AdvancePayment_DAL.CRSumHKForAdvancePayment(FromDate, dtpAdvProcessingDate.Value, _
                                                       lblEmpID.Text, lblEmpCode.Text)
        If DT_HK.Rows.Count > 0 Then
            dHK = DT_HK.Rows(0).Item("HK")
        End If

        txtHK.Text = dHK.ToString()

        dAmount = dAdvancePremium * dHK
        txtAmount.Text = dAmount.ToString("#,##0.00")

        btnUpdate.Focus()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Sabtu, 26 Sep 2009, 20:39

        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("You must select Category", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dAdvancePremium = 0 Then
            MessageBox.Show("Advance Premium has not been setup", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Senin, 23 Nov 2009, 14:03
        ' btnAdd berubah fungsi jd button Update

        'If lblEmpCode.Text = String.Empty Or _
        '    lblEmpID.Text = String.Empty Then
        '    MessageBox.Show("You must select Employee Name or NIK", "Information", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        'If dHK = 0 Then

        '    MessageBox.Show("Your HK is 0", "Information", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return

        'End If

        ' Check apakah record AdvancePayment sudah ada ditable
        ' jika belum ada insert kan
        'If DT_AdvancePayment.Rows.Count = 0 Then

        '    InsertAdvancePayment()
        '    AdvancePaymentTableAdapter.Update(DT_AdvancePayment)
        '    dgvAdvancePayment.DataSource = DT_AdvancePayment

        '    AdvancePaymentID = DT_AdvancePayment.Rows(0).Item("AdvancePaymentID").ToString()

        'End If

        'If FindEmpIDInAdvancePaymentDet() <> -1 Then
        '    MessageBox.Show("Employee already in grid, please check", "Information", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    InsertAdvancePaymentDet()
        '    ClearInput()
        '    MessageBox.Show("Data successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'End If
    End Sub

    Private Sub ClearInput()
        'Ahad, 27 Sep 2009, 00:58
        txtNIK.Text = String.Empty
        lblEmpCode.Text = String.Empty
        lblEmpID.Text = String.Empty
        txtName.Text = String.Empty

        dHK = 0
        dAmount = 0

        txtHK.Text = dHK.ToString()
        txtAmount.Text = dAmount.ToString()
    End Sub

    Private Sub InsertAdvancePayment()
        ' Sabtu, 26 Sep 2009, 20:39
        Dim NewRow As System.Data.DataRow

        NewRow = DT_AdvancePayment.NewRow()

        NewRow.Item("EstateID") = GlobalPPT.strEstateID
        NewRow.Item("EstateCode") = GlobalPPT.strEstateCode
        NewRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        NewRow.Item("AdvProcessingDate") = dtpAdvProcessingDate.Value
        NewRow.Item("Category") = CboCategory.SelectedItem.ToString()
        NewRow.Item("AdvancePremium") = txtAdvancePremium.Text
        NewRow.Item("CreatedBy") = GlobalPPT.strUserName
        NewRow.Item("CreatedOn") = Now()
        NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
        NewRow.Item("ModifiedOn") = Now()


        DT_AdvancePayment.Rows.Add(NewRow)

    End Sub

    Private Sub InsertAdvancePaymentDet()
        'Ahad, 27 Sep 2009, 00:54
        '''''
        'Insert DETAIL
        Dim NewRow As System.Data.DataRow

        ' Rabu, 18 Nov 2009, 19:35
        dAdvancePayment = 0
        dJamsostek = 0
        dAdvanvePaymentFormula = 0
        dAmount = 0

        dAdvancePayment = dAdvancePremium * dHK
        dJamsostek = dAdvancePremium * dHK * dJHTEmployee

        dAdvanvePaymentFormula = dAdvancePayment - dJamsostek

        dAmount = dAdvanvePaymentFormula
        ' END Rabu, 18 Nov 2009, 19:35

        NewRow = DT_AdvancePaymentDet.NewRow()

        NewRow.Item("AdvProcessingDate") = DT_AdvancePayment.Rows(0).Item("AdvProcessingDate").ToString()
        NewRow.Item("Category") = DT_AdvancePayment.Rows(0).Item("Category").ToString()
        NewRow.Item("EmpCode") = lblEmpCode.Text
        NewRow.Item("EmpName") = txtName.Text

        NewRow.Item("AdvancePaymentID") = AdvancePaymentID
        NewRow.Item("AdvancePremium") = txtAdvancePremium.Text
        NewRow.Item("EstateID") = GlobalPPT.strEstateID
        NewRow.Item("EstateCode") = GlobalPPT.strEstateCode
        NewRow.Item("EmpID") = lblEmpID.Text
        NewRow.Item("Mandays") = txtHK.Text
        NewRow.Item("Amount") = txtAmount.Text
        NewRow.Item("CreatedBy") = GlobalPPT.strUserName
        NewRow.Item("CreatedOn") = Now()
        NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
        NewRow.Item("ModifiedOn") = Now()

        DT_AdvancePaymentDet.Rows.Add(NewRow)

    End Sub

    Private Function FindEmpIDInAdvancePaymentDet() As Integer
        'Ahad, 27 Sep 2009, 00:39
        Dim rowIndex As Integer = -1

        If DT_AdvancePaymentDet IsNot Nothing Then
            For row As Integer = 0 To dgvAdvancePaymentDet.Rows.Count - 1

                If dgvAdvancePaymentDet.Rows(row).Cells("EmpID").Value = lblEmpID.Text Then
                    rowIndex = row
                End If
            Next
        End If

        Return rowIndex
    End Function

    Private Sub CboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCategory.SelectedIndexChanged
        ' Sabtu, 26 Sep 2009, 21:48
        If CboCategory.SelectedIndex = -1 Then
            Return
        End If

        cboCategoryView.SelectedIndex = CboCategory.SelectedIndex
        getRateSetup()
        btnGenerate.Focus()

        AdvancePayment_DAL.CRAdvancePaymentDelete()


    End Sub

    Private Sub getRateSetup()
        ' Sabtu, 26 Sep 2009, 21:48

        Dim EmpCategory As String = CboCategory.SelectedItem.ToString()
        Dim DT_RateSetup As DataTable

        If EmpCategory <> "KHT" And EmpCategory <> "KHL" Then
            EmpCategory = "KT"
        End If

        Cursor = Cursors.WaitCursor
        DT_RateSetup = AdvancePayment_DAL.CRRateSetupSelect(EmpCategory)

        dAdvancePremium = 0
        'Rabu, 18 Nov 2009, 18:53
        'Tambah JHTEmployer
        dJHTEmployee = 0

        ' Sabtu, 13 Feb 2010, 22:49, 22:51
        dRiceDividerDays = 0
        ' END Sabtu, 13 Feb 2010, 22:49, 22:51

        ' Ahad, 14 Mar 2010, 00:52
        dBasicRate = 0

        If DT_RateSetup.Rows.Count > 0 Then
            dAdvancePremium = DT_RateSetup.Rows(0).Item("AdvancePremium")

            If Not DT_RateSetup.Rows(0).IsNull("JHT") Then
                dJHTEmployee = Convert.ToDecimal(DT_RateSetup.Rows(0).Item("JHT").ToString())
            End If

            ' Sabtu, 13 Feb 2010, 22:49, 22:53
            If Not DT_RateSetup.Rows(0).IsNull("RiceDividerDays") Then
                dRiceDividerDays = Convert.ToDecimal(DT_RateSetup.Rows(0).Item("RiceDividerDays"))
            End If
            ' END Sabtu, 13 Feb 2010, 22:49, 22:53

            ' Ahad, 14 Mar 2010, 00:52
            If Not DT_RateSetup.Rows(0).IsNull("BasicRate") Then
                dBasicRate = DT_RateSetup.Rows(0).Item("BasicRate")
            End If
        End If

        txtAdvancePremium.Text = dAdvancePremium.ToString("#,##0.00")
        lblJHTEmployee.Text = dJHTEmployee

        Cursor = Cursors.Default

        Cursor = Cursors.WaitCursor
        getAdvancePayment()
        Cursor = Cursors.Default

        Cursor = Cursors.WaitCursor
        getAdvancePaymentDet()
        Cursor = Cursors.Default

    End Sub

    Private Sub getAdvancePayment()
        ' Sabtu, 26 Sep 2009, 22:22
        DT_AdvancePayment = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
            dtpAdvProcessingDate.Value, _
            CboCategory.SelectedItem.ToString())

        dgvAdvancePayment.DataSource = DT_AdvancePayment
    End Sub

    Private Sub getAdvancePaymentDet()
        ' Sabtu, 26 Sep 2009, 23:01

        If DT_AdvancePayment.Rows.Count > 0 Then

            AdvancePaymentID = DT_AdvancePayment.Rows(0).Item("AdvancePaymentID").ToString()
        Else
            AdvancePaymentID = String.Empty
        End If

        DT_AdvancePaymentDet = AdvancePaymentDetTableAdapter.AdvancePaymentDetSelect( _
            AdvancePaymentID, _
            GlobalPPT.strEstateID)

        dgvAdvancePaymentDet.DataSource = DT_AdvancePaymentDet
        ManagedgvAdvancePaymentDetColumn()
    End Sub

    Private Sub ManagedgvAdvancePaymentDetColumn()
        ' Ahad, 27 Sep 2009, 03:33
        dgvAdvancePaymentDet.Columns("ID").Visible = False
        dgvAdvancePaymentDet.Columns("EstateID").Visible = False
        dgvAdvancePaymentDet.Columns("EstateCode").Visible = False
        dgvAdvancePaymentDet.Columns("AdvancePaymentID").Visible = False
        dgvAdvancePaymentDet.Columns("AdvPaymentDetID").Visible = False
        dgvAdvancePaymentDet.Columns("APDColumnConcurrencyId").Visible = False
        dgvAdvancePaymentDet.Columns("CreatedBy").Visible = False
        dgvAdvancePaymentDet.Columns("CreatedOn").Visible = False
        dgvAdvancePaymentDet.Columns("ModifiedBy").Visible = False
        dgvAdvancePaymentDet.Columns("ModifiedOn").Visible = False
        dgvAdvancePaymentDet.Columns("EmpID").Visible = False

        dgvAdvancePaymentDet.Columns("APDColumnMandays").Width = 50
        dgvAdvancePaymentDet.Columns("APDColumnEmpName").Width = 150
    End Sub

    Private Sub ManagedgvAdvancePaymentViewColumn()
        ' Senin, 28 Sep 2009, 00:21
        dgvAdvancePaymentView.Columns("APDViewColumnConcurrencyId").Visible = False

        getAdvancePaymentDetView()
        dgvAdvancePaymentView.Columns("AdvancePaymentID").Visible = False
        dgvAdvancePaymentView.Columns("EstateID").Visible = False
        dgvAdvancePaymentView.Columns("ActiveMonthYearID").Visible = False
        dgvAdvancePaymentView.Columns("EstateCode").Visible = False

        dgvAdvancePaymentView.Columns("CreatedBy").Visible = False
        dgvAdvancePaymentView.Columns("CreatedOn").Visible = False
        dgvAdvancePaymentView.Columns("ModifiedBy").Visible = False
        dgvAdvancePaymentView.Columns("ModifiedOn").Visible = False
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        ' Ahad, 27 Sep 2009, 00:08
        If MessageBox.Show("Are you sure want to save to database", "Save", MessageBoxButtons.OKCancel, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        SaveAdvancePaymentDet()
        getAdvancePaymentDetView()
    End Sub

    Private Sub SaveAdvancePaymentDet()
        ' Ahad, 27 Sep 2009, 00:12
        Dim RecordAffected As Integer

        RecordAffected = AdvancePaymentDetTableAdapter.Update(DT_AdvancePaymentDet)
        If RecordAffected > 0 Then

            ' Jum'at, 1 Jan 2010, 13:22
            CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
            ' END Jum'at, 1 Jan 2010, 13:22

            MessageBox.Show("Advance Payment successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'DT_AdvancePaymentDet.Clear()
        End If

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        ' Ahad, 27 Sep 2009, 01:50
        'Dim i As Integer
        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("You must select Category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If txtAdvancePremium.Text = "" Or txtAdvancePremium.Text = "0" Or dAdvancePremium = 0 Then
            MessageBox.Show("Advance premium has not yet been setup", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Do you want to process Generate Advance Payment?", "Advance Payment", _
                   MessageBoxButtons.OKCancel, _
                   MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If
        '=================================================================================================
        'Delete for Advance if Exist
        '============================
        If dgvAdvancePaymentDet.Rows.Count > 0 Then

            ' Senin, 23 Nov 2009, 15:04

            'While DT_AdvancePaymentDet.Rows.Count > 0
            '    DT_AdvancePaymentDet.Rows(DT_AdvancePaymentDet.Rows.Count - 1).Delete()
            'End While

            Dim rows() = ToArray(DT_AdvancePaymentDet.Rows)
            Dim dr As DataRow

            For Each dr In rows
                dr.Delete()
            Next

            'DT_AdvancePaymentDet.Rows.Clear()
            Dim DeletedRow As DataRow() = DT_AdvancePaymentDet.Select(Nothing, Nothing, DataViewRowState.Deleted)
            Dim RecordAffected As Integer = AdvancePaymentDetTableAdapter.Update(DT_AdvancePaymentDet)

        End If

        If dgvAdvancePayment.Rows.Count > 0 Then
            DT_AdvancePayment.Rows(0).Delete()
            AdvancePaymentTableAdapter.Update(DT_AdvancePayment)
        End If
        '================================================================================================
        GenerateAdvancePayment()
        btnSaveAll.Focus()



        'MessageBox.Show(DT_AdvancePaymentDet.Rows.Count().ToString())
    End Sub

    Function ToArray(ByVal collection As DataRowCollection) As DataRow()
        ' Alhamdulillahirobbiaalamiin
        ' By Dadang Adi Hendradi
        ' Sabtu, 12 Des 2009, 18:23
        Dim result(collection.Count - 1) As DataRow

        collection.CopyTo(result, 0)
        Return result
    End Function

    Private Sub GenerateAdvancePayment()
        ' Rabu, 30 Sep 2009, 3:23
        Dim AdvProcessingDate As Date
        Dim Category As String = String.Empty

        Category = CboCategory.SelectedItem.ToString()

        Dim DT_Emp As DataTable
        'DT_Emp = AdvancePaymentDetTableAdapter.CRNikNameByCategorySelect(GlobalPPT.strEstateID, "", "", Category)


        'Monday, 16 Nov 2009, 00:03
        'DT_Emp = AdvancePaymentDetTableAdapter.CRAttendanceSummarySelect(Category)
        DT_Emp = AdvancePaymentDet_DAL.CRAttendanceSummarySelect(Category)
        'END Monday, 16 Nov 2009, 00:03

        If DT_Emp.Rows.Count = 0 Then

            MessageBox.Show("No Employee in " + Category + " Category." + vbCrLf + _
                            "Please check Employee Master", "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If



        DT_AdvancePayment = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
        dtpAdvProcessingDate.Value, _
        Category)

        If DT_AdvancePayment.Rows.Count = 0 Then

            InsertAdvancePayment()
            AdvancePaymentTableAdapter.Update(DT_AdvancePayment)
            dgvAdvancePayment.DataSource = DT_AdvancePayment

            AdvancePaymentID = DT_AdvancePayment.Rows(0).Item("AdvancePaymentID").ToString()

        Else
            ' Jika sudah ada
            '==========================================================================================
            'AdvProcessingDate = DT_AdvancePayment.Rows(0).Item("AdvProcessingDate")
            'If MessageBox.Show("Data already exist for this month:" + vbCrLf + _
            '                "Advance Processing Date is: " + AdvProcessingDate.ToString("dd/MM/yyyy") + vbCrLf + _
            '                "Are you sure want to process to this date", "Warning", _
            '                 MessageBoxButtons.OKCancel, _
            '                 MessageBoxIcon.Question, _
            '                 MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            '    Return
            'End If

        End If

        Dim FromDate As Date
        Dim DT_Fiscalyear As DataTable

        lblProcessMsg.Visible = True
        lblProcessMsg.Refresh()

        DT_Fiscalyear = AdvancePayment_DAL.FiscalYear(dtpAdvProcessingDate.Value.Year, dtpAdvProcessingDate.Value.Month)

        If DT_Fiscalyear.Rows.Count = 0 Then
            MessageBox.Show("Fiscal Year has not been setup", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return
        End If
        'DT_AdvancePayment.Rows(dgvAdvancePayment.CurrentCell.RowIndex).Item("AdvProcessingDate") = dtpAdvProcessingDate.Value
        FromDate = DT_Fiscalyear.Rows(0).Item("FromDT")

        AdvProcessingDate = DT_AdvancePayment.Rows(0).Item("AdvProcessingDate")

        DT_AdvancePaymentDet = AdvancePaymentDetTableAdapter.AdvancePaymentDetSelect( _
        AdvancePaymentID, _
        GlobalPPT.strEstateID)

        Try

            For Each EmpRow As DataRow In DT_Emp.Rows

                Dim bFound As Boolean = False
                Dim EmpCode As String
                Dim EmpName As String

                EmpCode = EmpRow.Item("EmpCode").ToString()
                EmpName = EmpRow.Item("EmpName").ToString()
                'For Each AdvPDetailRow As DataRow In DT_AdvancePaymentDet.Rows

                '    If EmpRow.Item("EmpID").ToString() = AdvPDetailRow.Item("EmpID") Then
                '        'jika sudah ada di AdvancePaymentDet
                '        'keluar
                '        bFound = True
                '        Exit For
                '    End If


                'Next AdvPDetailRow

                'If Not bFound Then
                Dim NewRow As System.Data.DataRow


                Dim DT_HK As DataTable
                'Sai Hide
                'DT_HK = AdvancePayment_DAL.CRSumHKForAdvancePayment( _
                '    FromDate, DT_AdvancePayment.Rows(0).Item("AdvProcessingDate"), _
                '    EmpRow.Item("EmpID").ToString(), _
                '    "")

                dHK = 1
                'If DT_HK.Rows.Count > 0 Then
                '    dHK = DT_HK.Rows(0).Item("HK")
                'End If

   

                dAdvancePayment = 0
                dJamsostek = 0
                dAdvanvePaymentFormula = 0
                dBalanceAdvancePayment = 0
                dAmount = 0

                dAdvancePayment = dAdvancePremium * dHK

                'If dAdvancePayment > 0 Then
                '    '  dJamsostek = dAdvancePremium * dRiceDividerDays * (dJHTEmployee / 100)
                '    dJamsostek = dBasicRate * dRiceDividerDays * (dJHTEmployee / 100)
                'End If
                '' END Sabtu, 13 Feb 2010, 18:53


                Dim dJamsostekRatusan As Decimal
                Dim dIntegralJamsostek As Decimal

                dJamsostekRatusan = 0
                
                'If dAdvancePayment > 0 Then
                '    dAdvancePayment = (dAdvancePayment * 0.001)
                '    dAdvancePayment = Math.Truncate(dAdvancePayment) * 1000

                'End If



                'If dJamsostek > 1000 Then
                '    dIntegralJamsostek = Math.Truncate(dJamsostek * 0.001)
                '    dJamsostekRatusan = (dJamsostek * 0.001) - dIntegralJamsostek

                '    dIntegralJamsostek = dIntegralJamsostek * 1000
                '    dJamsostekRatusan = dJamsostekRatusan * 1000

                '    dJamsostekRatusan = Math.Round(dJamsostekRatusan, 2)
                '    If dJamsostekRatusan > 0 Then
                '        ' Nilai ratusan dari jamsostek ditambahkan ke nilai advance payment
                '        dAdvancePayment = dAdvancePayment + dJamsostekRatusan
                '    End If
                'End If
                ''END Kamis, 18 Mar 2010, 21:41

                dAmount = dAdvancePayment

                'If dAdvancePayment = 0 Then
                '    dBalanceAdvancePayment = 0
                'Else
                '    'only 4 KHL
                '    If dJamsostek <= 1000 Then
                '        dAdvancePayment = Math.Truncate(dAdvancePayment * 0.001)
                '        dAdvancePayment = dAdvancePayment * 1000
                '    End If

                '    dBalanceAdvancePayment = dAdvancePayment - dJamsostek
                '    End If


                '    Dim Hasil As Decimal = 0
                '    Dim pecahan As Decimal = 0
                '    Dim Integral As Decimal = 0

                '    Integral = Math.Truncate(dBalanceAdvancePayment)
                '    pecahan = dBalanceAdvancePayment - Integral

                '    If pecahan < 0.5 And pecahan > 0.0 Then
                '        pecahan = 0.5
                '        dBalanceAdvancePayment = Integral + pecahan

                '    ElseIf pecahan > 0.5 Then
                '        dBalanceAdvancePayment = Integral + 1.0

                '    End If

                '    ' END Sabtu, 12 Des 2009, 00:30


                    NewRow = DT_AdvancePaymentDet.NewRow()

                    NewRow.Item("AdvProcessingDate") = DT_AdvancePayment.Rows(0).Item("AdvProcessingDate")
                    NewRow.Item("Category") = DT_AdvancePayment.Rows(0).Item("Category").ToString()
                    NewRow.Item("AdvancePremium") = DT_AdvancePayment.Rows(0).Item("AdvancePremium").ToString()
                    NewRow.Item("EmpCode") = EmpCode 'EmpRow.Item("EmpCode").ToString()
                    NewRow.Item("EmpName") = EmpName 'EmpRow.Item("EmpName").ToString()

                    NewRow.Item("AdvancePaymentID") = AdvancePaymentID
                    NewRow.Item("EstateID") = GlobalPPT.strEstateID
                    NewRow.Item("EstateCode") = GlobalPPT.strEstateCode
                    NewRow.Item("EmpID") = EmpRow.Item("EmpID").ToString()
                    NewRow.Item("Mandays") = dHK
                NewRow.Item("Amount") = DT_AdvancePayment.Rows(0).Item("AdvancePremium").ToString()
                    NewRow.Item("CreatedBy") = GlobalPPT.strUserName
                    NewRow.Item("CreatedOn") = Now()
                    NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
                    NewRow.Item("ModifiedOn") = Now()

                    NewRow.Item("DedJamsostek") = dJamsostek
                    'NewRow.Item("BalanceAdvancePayment") = dBalanceAdvancePayment
                NewRow.Item("PaidAmount") = DT_AdvancePayment.Rows(0).Item("AdvancePremium").ToString() ' Senin, 23 Nov 2009, 17:04

                    DT_AdvancePaymentDet.Rows.Add(NewRow)

                    'End If

            Next EmpRow
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        lblProcessMsg.Visible = False

        dgvAdvancePaymentDet.DataSource = DT_AdvancePaymentDet

        'MessageBox.Show("Processsing Advance Payment for month " + _
        '                AdvProcessingDate.ToString("dd/MM/yyyy") + " finish", _
        '                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Ahad, 27 Sep 2009, 16:49

        'btnGenerate.Enabled = True
        'txtNIK.Enabled = True
        'txtName.Enabled = True
        'btnSearchName.Enabled = True

        CboCategory.Enabled = True
        btnGenerate.Enabled = True
        txtAmount.Enabled = False
        btnUpdate.Enabled = False
        btnReset.Enabled = False

        btnNIKFind.Enabled = True
        btnNameFind.Enabled = True

        txtNIKFind.Enabled = True
        txtNameFind.Enabled = True

        dgvAdvancePaymentDet.Enabled = True

        btnSaveAll.Enabled = True
        btnClose.Enabled = True

        'btnReset.Enabled = False
        dtpAdvProcessingDateView.MaxDate = GlobalPPT.FiscalYearToDate
        dtpAdvProcessingDateView.Value = GlobalPPT.FiscalYearToDate

        dgvAdvancePaymentDet.Enabled = True
        ClearInput()
    End Sub

    Private Sub EditAdvancePaymentDet()
        ' Ahad, 27 Sep 2009, 16:38
        Try

            txtNIK.Text = dgvAdvancePaymentDet.CurrentCell.OwningRow.Cells("APDColumnEmpCode").Value.ToString()
            lblEmpCode.Text = dgvAdvancePaymentDet.CurrentCell.OwningRow.Cells("APDColumnEmpCode").Value.ToString()
            lblEmpID.Text = dgvAdvancePaymentDet.CurrentCell.OwningRow.Cells("EmpID").Value.ToString()

            txtName.Text = dgvAdvancePaymentDet.CurrentCell.OwningRow.Cells("APDColumnEmpName").Value.ToString()
            txtHK.Text = dgvAdvancePaymentDet.CurrentCell.OwningRow.Cells("APDColumnMandays").Value.ToString()
            txtAmount.Text = dgvAdvancePaymentDet.CurrentCell.OwningRow.Cells("APDColumnAmount").Value.ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DeleteMIAdvancePaymentDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMIAdvancePaymentDet.Click
        ' Ahad, 27 Sep 2009, 16:54
        If dgvAdvancePaymentDet.Rows.Count = 0 Or dgvAdvancePaymentDet.CurrentCell Is Nothing Then
            Return
        End If

        Dim rowIndex As Integer = dgvAdvancePaymentDet.CurrentCell.RowIndex
        Dim empname As String = dgvAdvancePaymentDet.Rows(rowIndex).Cells("APDColumnEmpName").Value.ToString()
        Dim empnik As String = dgvAdvancePaymentDet.Rows(rowIndex).Cells("APDColumnEmpCode").Value.ToString()

        If MessageBox.Show("Yout are about to delete the selected record." + vbCrLf + _
                           "Are you sure want to delete this record:" + vbCrLf + _
            "NIK    : " + empnik + vbCrLf + _
            "NAME : " + empname, "Delete", MessageBoxButtons.OKCancel, _
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        DeleteAdvancePaymentDet()
    End Sub

    Private Sub DeleteAdvancePaymentDet()
        ' Ahad, 27 Sep 2009, 16:55
        If dgvAdvancePaymentDet.Rows(dgvAdvancePaymentDet.CurrentCell.RowIndex).Cells("AdvPaymentDetID").Value Is System.DBNull.Value Then
            dgvAdvancePaymentDet.Rows.RemoveAt(dgvAdvancePaymentDet.CurrentCell.RowIndex)
        Else
            DT_AdvancePaymentDet.Rows(dgvAdvancePaymentDet.CurrentCell.RowIndex).Delete()
        End If

        MessageBox.Show("Data successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cmsAdvancePaymentDet_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAdvancePaymentDet.Opening
        ' Ahad, 27 Sep 2009, 17:01
        If dgvAdvancePaymentDet.Rows.Count = 0 Then
            cmsAdvancePaymentDet.Items(0).Enabled = False
        ElseIf dgvAdvancePaymentDet.Rows.Count > 0 And dgvAdvancePaymentDet.CurrentCell IsNot Nothing Then
            cmsAdvancePaymentDet.Items(0).Enabled = True
        End If
    End Sub

    Private Sub btnNameFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNameFind.Click
        ' Ahad, 27 Sep 2009, 19:01
        FindByName()
    End Sub

    Private Sub FindByName()
        ' Rabu, 30 Sep 2009, 04:54
        If dgvAdvancePaymentDet.Rows.Count = 0 Then
            Return
        End If

        Dim rowIndex As Integer

        rowIndex = FindEmp(txtNameFind.Text, "APDColumnEmpName")
        If (rowIndex <> -1) Then
            dgvAdvancePaymentDet.CurrentCell = dgvAdvancePaymentDet.Rows(rowIndex).Cells("APDColumnEmpName")
        End If

    End Sub

    Private Function FindEmp(ByVal StrFind As String, ByVal columnName As String) As Integer
        ' Rabu, 30 Sep 2009, 04:28
        Dim CellValue As String
        Dim rowIndex As Integer = -1

        For i As Integer = 0 To dgvAdvancePaymentDet.Rows.Count - 1

            CellValue = dgvAdvancePaymentDet.Rows(i).Cells(columnName).Value.ToString()
            If CellValue.Length < StrFind.Length Then
                Continue For
            End If

            If CellValue.Substring(0, StrFind.Length).ToUpper() = StrFind.ToUpper() Then
                ' ketemu neh
                rowIndex = i
                Exit For
            End If

        Next

        Return rowIndex
    End Function

    Private Function FindItemInAdvancePaymentDetGrid(ByVal GridColumnName As String, ByVal STRFIND As String) As Integer
        ' Ahad, 27 Sep 2009, 19:14
        Dim retValue As Integer = -1
        Dim gridValue As String = String.Empty

        For i As Integer = 0 To dgvAdvancePaymentDet.Rows.Count - 1
            gridValue = dgvAdvancePaymentDet.Rows(i).Cells(GridColumnName).Value.ToString().ToUpper()
            If gridValue = STRFIND.ToUpper() Then
                retValue = i
            End If
        Next

        Return retValue
    End Function

    Private Sub btnNIKFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNIKFind.Click
        ' Ahad, 27 Sep 2009, 22:51
        FindByNIK()
    End Sub

    Private Sub FindByNIK()
        ' Rabu, 30 Sep 2009, 04:54
        If dgvAdvancePaymentDet.Rows.Count = 0 Then
            Return
        End If

        Dim rowIndex As Integer

        rowIndex = FindEmp(txtNIKFind.Text, "APDColumnEmpCode")
        If (rowIndex <> -1) Then
            dgvAdvancePaymentDet.CurrentCell = dgvAdvancePaymentDet.Rows(rowIndex).Cells("APDColumnEmpCode")
        End If

    End Sub

    Private Sub txtNameFind_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNameFind.KeyDown
        ' Ahad, 27 Sep 2009, 22:57
        If e.KeyCode = Keys.Enter Then
            FindByName()
        End If
    End Sub

    Private Sub txtNIK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIK.KeyDown
        ' Ahad, 27 Sep 2009, 23:03
        Dim Category As String = String.Empty

        If e.KeyCode = Keys.Enter Then

            If CboCategory.SelectedIndex = -1 Then
                MessageBox.Show("You must select Category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            If Not txtNIK.Text = String.Empty Then
                Category = CboCategory.SelectedItem.ToString()
                Dim DT_EMP As DataTable
                DT_EMP = AdvancePaymentDetTableAdapter.CRNikNameByCategorySelect(GlobalPPT.strEstateID, txtNIK.Text, "", Category)
                If DT_EMP.Rows.Count = 0 Or DT_EMP.Rows.Count > 1 Then
                    ClearInput()
                    MessageBox.Show("NIK not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNIK.Focus()

                ElseIf DT_EMP.Rows.Count = 1 Then
                    lblEmpCode.Text = DT_EMP.Rows(0).Item("EmpCode").ToString()
                    lblEmpID.Text = DT_EMP.Rows(0).Item("EmpID").ToString()
                    txtName.Text = DT_EMP.Rows(0).Item("EmpName").ToString()
                    getEmpAdvancePayment()

                End If


            End If
        End If

    End Sub

    Private Sub btnSearchView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchView.Click
        ' Senin, 28 Sep 2009, 00:32
        'If cboCategoryView.SelectedIndex = -1 Then
        '    MessageBox.Show("Please select category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        getAdvancePaymentDetView()
        If DT_AdvancePaymentDetView.Rows.Count = 0 Then
            MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub getAdvancePaymentDetView()
        ' Senin, 28 Sep 2009, 00:34
        Dim category As String 

        If cboCategoryView.SelectedItem Is Nothing Then
            category = String.Empty
        Else
            category = cboCategoryView.SelectedItem.ToString
        End If

        If chkDate.Checked = False Then
            DT_AdvancePaymentDetView = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
            "01/01/1900", category)
        Else
            DT_AdvancePaymentDetView = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
            dtpAdvProcessingDateView.Value, category)

        End If

        'DT_AdvancePaymentDetView = AdvancePaymentTableAdapter.AdvancePaymentSelect( _
        '    dtpAdvProcessingDateView.Value, category)

        dgvAdvancePaymentView.DataSource = DT_AdvancePaymentDetView

      
    End Sub

    Private Sub dgvAdvancePaymentView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdvancePaymentView.CellDoubleClick
        ' Senin, 28 Sep 2009, 01:03
        If dgvAdvancePaymentView.RowCount > 0 Then
            If dgvAdvancePaymentView.CurrentCell IsNot Nothing Then

                If cboCategoryView.SelectedIndex <> -1 Then
                    SelectAdvancePaymentFromView()
                End If

            End If
        End If
    End Sub

    Private Sub SelectAdvancePaymentFromView()
        ' Senin, 28 Sep 2009, 01:04
        dtpAdvProcessingDate.Value = _
        dgvAdvancePaymentView.Rows(dgvAdvancePaymentView.CurrentCell.RowIndex).Cells("APDViewColumnAdvProcessingDate").Value

        'CboCategory.SelectedIndex = cboCategoryView.SelectedIndex
        CboCategory.Text = dgvAdvancePaymentView.Rows(dgvAdvancePaymentView.CurrentCell.RowIndex).Cells("APDViewColumnCategory").Value

        getRateSetup() ' Senin, 23 Nov 2009, 17:42
        tcAdvancePayment.SelectedTab = tabAdvancePayment
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        ' Senin, 28 Sep 2009, 01:14
        If e.KeyCode = Keys.Enter Then
            If txtName.Text = "" Then
                btnSearchName.Focus()
            End If
        End If
    End Sub

    Private Sub txtNIKFind_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIKFind.KeyDown
        ' Rabu, 30 Sep 2009, 06:10
        If e.KeyCode = Keys.Enter Then
            FindByNIK()
        End If
    End Sub

    Private Sub AdvancePayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Rabu, 30 Sep 2009, 06:15
        Dim ModifiedRow As DataRow() = DT_AdvancePaymentDet.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_AdvancePaymentDet.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_AdvancePaymentDet.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False

        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_RicePaymentDet
            Modified = True
        End If

        If Modified Then
            If MessageBox.Show("The data has changed," + vbCrLf + _
                            "Do you want to save to database..", "Warning", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                          Windows.Forms.DialogResult.Yes Then
                'save data
                Cursor = Cursors.WaitCursor
                SaveAdvancePaymentDet()
                Cursor = Cursors.Default
            Else
                AdvancePayment_DAL.CRAdvancePaymentDelete()
            End If
        End If

    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        ' Senin, 5 Oct 2009, 18:12
        MessageBox.Show("Under contraction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return

    End Sub

    Private Sub dgvAdvancePaymentDet_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdvancePaymentDet.CellDoubleClick
        ' Senin, 23 Nov 2009, 11:17
        If dgvAdvancePaymentDet.Rows.Count = 0 Then
            Return
        End If
        If dgvAdvancePaymentDet.CurrentCell Is Nothing Then
            Return
        End If

        CboCategory.Enabled = False
        btnGenerate.Enabled = False
        txtAmount.Enabled = True
        btnUpdate.Enabled = True
        btnReset.Enabled = True

        btnNIKFind.Enabled = False
        btnNameFind.Enabled = False

        txtNIKFind.Enabled = False
        txtNameFind.Enabled = False
        dgvAdvancePaymentDet.Enabled = False

        btnSaveAll.Enabled = False
        btnClose.Enabled = False
        DoEdit()
    End Sub

    Private Sub DoEdit()
        ' Senin, 23 Nov 2009, 11:20
        ' Get the Currency Manager by using the BindingContext of the DataGrid
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvAdvancePaymentDet.DataSource, dgvAdvancePaymentDet.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        txtNIK.Text = dr.Item("EmpCode").ToString()
        lblEmpCode.Text = dr.Item("EmpCode").ToString()
        lblEmpID.Text = dr.Item("EmpID").ToString()
        txtName.Text = dr.Item("EmpName").ToString()

        txtHK.Text = dr.Item("Mandays").ToString()
        txtAmount.Text = Convert.ToDecimal(dr.Item("Amount").ToString()).ToString("####.00")
        txtAmount.Focus()
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        ' Senin, 23 Nov 2009, 11:37
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

        'If nonNumberEntered = True Then
        '    btnUpdate.Focus()
        'End If

    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnUpdate.Focus()
            End If
        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ' Senin, 23 Nov 2009, 11:43

        If DoUpdate() Then
            CboCategory.Enabled = True
            btnGenerate.Enabled = True
            txtAmount.Enabled = False
            btnUpdate.Enabled = False
            btnReset.Enabled = False

            btnNIKFind.Enabled = True
            btnNameFind.Enabled = True

            txtNIKFind.Enabled = True
            txtNameFind.Enabled = True

            dgvAdvancePaymentDet.Enabled = True

            btnSaveAll.Enabled = True
            btnClose.Enabled = True

            ClearInput()
        End If
    End Sub

    Private Function DoUpdate() As Boolean
        dAmount = Convert.ToDecimal(txtAmount.Text)
        dHK = Convert.ToDecimal(txtHK.Text)
        If dAmount > dAdvancePremium * dHK Then
            MessageBox.Show("Advance more than Advance Premium x HK !", "Advance Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAmount.Focus()
            Return False
        End If

        Dim retValue As Boolean = True

        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvAdvancePaymentDet.DataSource, dgvAdvancePaymentDet.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row
        ' Sabtu, 13 Feb 2010, 22:27
        ' Angka yg diupdate sekarang angka Advance nya
        dJamsostek = 0
        dBalanceAdvancePayment = 0

        dAmount = Convert.ToDecimal(txtAmount.Text)
        dr.Item("Amount") = txtAmount.Text

        dHK = Convert.ToDecimal(txtHK.Text)
        dAdvancePayment = dAmount * dHK

        If dAmount > dAdvancePremium * dHK Then
            MessageBox.Show("Advance more than Advance Premium x HK !", "Advance Payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAmount.Focus()
            Return False
        End If

        If dAmount > 0 Then

            dJamsostek = dBasicRate * dRiceDividerDays * (dJHTEmployee / 100)
            dBalanceAdvancePayment = dAmount - dJamsostek
        End If

        dr.Item("DedJamsostek") = dJamsostek
        dr.Item("PaidAmount") = dBalanceAdvancePayment
        ' END Sabtu, 13 Feb 2010, 22:27

        Return retValue
    End Function

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        If chkDate.Checked = True Then
            dtpAdvProcessingDateView.Enabled = True
        Else
            dtpAdvProcessingDateView.Enabled = False
        End If
        dtpAdvProcessingDateView.MaxDate = GlobalPPT.FiscalYearToDate
        dtpAdvProcessingDateView.Value = GlobalPPT.FiscalYearToDate
    End Sub

    Private Sub tcAdvancePayment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcAdvancePayment.SelectedIndexChanged
        If tcAdvancePayment.SelectedIndex = 1 Then
            chkDate.Checked = False
            dtpAdvProcessingDateView.Value = GlobalPPT.FiscalYearToDate
            cboCategoryView.SelectedIndex = 0
            getAdvancePaymentDetView()
            dtpAdvProcessingDateView.Focus()
            'AdvancePayment_DAL.CRAdvancePaymentDelete()
            'dgvAdvancePaymentDet.DataSource = Nothing
            'ClearInput()
            'CboCategory.SelectedIndex = -1
            'txtAdvancePremium.Text = String.Empty

        ElseIf tcAdvancePayment.SelectedIndex = 0 Then
            dtpAdvProcessingDate.Focus()
        End If

       
    End Sub

    Private Sub AdvancePayment_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class