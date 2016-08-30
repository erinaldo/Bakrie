' Programmer: Dadang Adi Hendradi
' Created   : Senin, 28 Sep 2009, 17:39
' Modified  : Senin, 16 Nov 2009, 23:14
'           : Rice Advance hanya utk KHL
' Place     : Balikpapan
'

Imports Common_PPT ' Thursday, 10 Sep 2009, 01:02
Imports CheckRoll_DAL

Imports System.Globalization
Imports System.Threading

Public Class RicePayment

    Private RicePaymentTableAdapter As New CheckRoll_DAL.RicePayment_DAL()
    Private DT_RicePayment As DataTable

    Private RicePaymentDetTableAdapter As New CheckRoll_DAL.RicePaymentDetails_DAL()
    Dim DT_RicePaymentDet As DataTable

    Private DT_RicePaymentView As DataTable

    Private dHK As Decimal = 0
    Private dCatuMax As Decimal = 0
    Private dRiceIssueQty As Decimal = 0
    Private dNoOfChildren As Decimal = 0

    Private dRAEmployee As Decimal = 0
    Private dRAWifeOrHusband As Decimal = 0
    Private dRAChild As Decimal = 0

    Private RiceID As String = String.Empty
    Private RiceDate As Integer

    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RicePayment))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDate.Text = rm.GetString("lblDate.Text")
            lblCategory.Text = rm.GetString("lblCategory.Text")

            lblNIK.Text = rm.GetString("lblNIK.Text")
            lblName.Text = rm.GetString("lblName.Text")
            lblHK.Text = rm.GetString("lblHK.Text")
            'lblAmount.Text = rm.GetString("lblAmount.Text")
            btnGenerate.Text = rm.GetString("btnGenerate.Text")

            tcRicePayment.TabPages(0).Text = rm.GetString("tcRicePayment.TabPages(0).Text")
            tcRicePayment.TabPages(1).Text = rm.GetString("tcRicePayment.TabPages(1).Text")

            'lblViewDate.Text = rm.GetString("lblViewDate.Text")
            lblViewCategory.Text = rm.GetString("lblViewCategory.Text")
            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

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

    Private Sub RicePayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Kamis, 10 Sep 2009, 01:04
        SetUICulture(GlobalPPT.strLang)

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()

        'Senin, 28 Sep 2009, 17:46
        '''''
        ' RicePayment
        DT_RicePayment = RicePaymentTableAdapter.CRRicePaymentSelect( _
            dtpAdvProcessingDate.Value, "", _
            GlobalPPT.strEstateID, "0")

        dgvRicePayment.DataSource = DT_RicePayment

        'Selasa, 29 Sep 2009, 22:55
        ' RicePaymentDet
        DT_RicePaymentDet = RicePaymentDetTableAdapter.RicePaymentDetSelect( _
        RiceID, _
        GlobalPPT.strEstateID)
        dgvRicePaymentDet.DataSource = DT_RicePaymentDet
        ManagedgvRicePaymentDetcolumn()

        ReadTaxAndRiceSetup()

        DT_RicePaymentView = RicePaymentTableAdapter.CRRicePaymentSelect( _
        dtpAdvProcessingDateView.Value, "", _
        GlobalPPT.strEstateID, "0")
        dgvRicePaymentView.DataSource = DT_RicePaymentView
        ManagedgvRicePaymentViewColumn()

        tcRicePayment.SelectedTab = tabView

        dtpAdvProcessingDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpAdvProcessingDate.MaxDate = GlobalPPT.FiscalYearToDate

        dtpAdvProcessingDateView.MinDate = GlobalPPT.FiscalYearFromDate
        dtpAdvProcessingDateView.MaxDate = GlobalPPT.FiscalYearToDate

        If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
            dtpAdvProcessingDate.Value = Now()
            dtpAdvProcessingDateView.Value = Now()
        End If
        dgvRicePaymentDet.DefaultCellStyle.BackColor = Color.White
        dgvRicePaymentView.DefaultCellStyle.BackColor = Color.White

        ' Senin, 16 Nov 2009, 23:15
        ' Rice Advance hanya untuk KHT saja
        CboCategory.SelectedIndex = 0
        cboCategoryView.SelectedIndex = 0

        ClearInput()
        dtpAdvProcessingDateView.Focus()
    End Sub


    Private Sub ReadTaxAndRiceSetup()
        ' Selasa, 29 Sep 2009, 15:55
        Dim DT As DataTable

        DT = RicePayment_DAL.TaxAndRiceSetupSelect()

        If DT.Rows.Count > 0 Then
            If DT.Rows(0).IsNull("RAEmployee") Then
                lblRAEmployee.Text = "0"
            Else
                lblRAEmployee.Text = DT.Rows(0).Item("RAEmployee").ToString()
            End If

            If DT.Rows(0).IsNull("RAHusbandOrWife") Then
                lblRAHusbandOrWife.Text = "0"
            Else
                lblRAHusbandOrWife.Text = DT.Rows(0).Item("RAHusbandOrWife").ToString()
            End If

            If DT.Rows(0).IsNull("RAChild") Then
                lblRAChild.Text = "0"
            Else
                lblRAChild.Text = DT.Rows(0).Item("RAChild").ToString()
            End If

        Else
            MessageBox.Show("Tax And Rice setup has not yet been properly setup" + vbCrLf + _
                            "process will fail if continue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub btnSearchName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        ' Selasa, 29 Sep 2009, 16:16
        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select Category First", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim EmpCategory As String = CboCategory.SelectedItem.ToString()
        Dim NikNameByCategoryLookup_Form As New NIKByTeamCategoryLookUp()

        NikNameByCategoryLookup_Form.Category = EmpCategory
        NikNameByCategoryLookup_Form.ShowDialog()


        If NikNameByCategoryLookup_Form.DialogResult = Windows.Forms.DialogResult.OK Then
            txtNIK.Text = NikNameByCategoryLookup_Form.EmpCode
            txtName.Text = NikNameByCategoryLookup_Form.EmpName

            lblEmpCode.Text = NikNameByCategoryLookup_Form.EmpCode
            lblEmpID.Text = NikNameByCategoryLookup_Form.EmpID

            getEmpRicePayment()
        End If

    End Sub

    Private Sub getEmpRicePayment()
        ' Rabu, 30 Sep 2009, 05:03

        'check
        dHK = 0
        dCatuMax = 0
        dRiceIssueQty = 0
        dNoOfChildren = 0

        dRAEmployee = 0
        dRAWifeOrHusband = 0
        dRAChild = 0

        Dim NoOfDay As Integer = 0
        Dim NoOfPH As Integer = 0
        Dim NoOfRestDay As Integer = 4 ' anggap restday dalam satu bulan 4 hari
        Dim WorkingDays As Integer = 0

        'stanley@03-11-2011
        Dim NoOfPHFallonSun As Integer = 0

        Dim FromDate As Date
        Dim ToDT As Date

        Dim DT_Fiscalyear As DataTable

        DT_Fiscalyear = AdvancePayment_DAL.FiscalYear(dtpAdvProcessingDate.Value.Year, dtpAdvProcessingDate.Value.Month)

        If DT_Fiscalyear.Rows.Count = 0 Then
            MessageBox.Show("Fiscal Year has not yet been setup", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return
        End If

        FromDate = DT_Fiscalyear.Rows(0).Item("FromDT")
        ToDT = DT_Fiscalyear.Rows(0).Item("ToDT")

        Dim ts As TimeSpan
        ts = ToDT - FromDate

        NoOfDay = ts.Days + 1
        NoOfPH = RicePaymentDetails_DAL.CRNoOfPHInThisMonthYear( _
            dtpAdvProcessingDate.Value.Month, dtpAdvProcessingDate.Value.Year)

        'stanley@03-11-2011
        NoOfPHFallonSun = RicePaymentDetails_DAL.CRNoOfPHFallOnSundayInThisMonthYear( _
            dtpAdvProcessingDate.Value.Month, dtpAdvProcessingDate.Value.Year)

        'WorkingDays = NoOfDay - NoOfPH - NoOfRestDay
        'stanley@03-11-2011
        WorkingDays = NoOfDay - NoOfPH - NoOfRestDay + NoOfPHFallonSun

        Dim DT_HK As DataTable
        DT_HK = AdvancePayment_DAL.CRSumHKForAdvancePayment(FromDate, dtpAdvProcessingDate.Value, _
                                                       lblEmpID.Text, lblEmpCode.Text)
        If DT_HK.Rows.Count > 0 Then
            dHK = DT_HK.Rows(0).Item("HK")
        End If

        txtHk.Text = dHK.ToString()

        Dim DT_EMPINFO As DataTable = RicePaymentDetTableAdapter.getEmpInfo( _
        lblEmpID.Text, GlobalPPT.strEstateID)

        Dim bWifeGotRice = True

        If DT_EMPINFO.Rows.Count > 0 Then

            ' apakah istri atau suami dapat beras
            If DT_EMPINFO.Rows(0).IsNull("WifeEmpWithREA") Then
                bWifeGotRice = False
            ElseIf DT_EMPINFO.Rows(0).Item("WifeEmpWithRea").ToString() = "Y" Then
                bWifeGotRice = False
            End If

            If DT_EMPINFO.Rows(0).IsNull("WifeNotStayinREA") Then
                bWifeGotRice = False
            ElseIf DT_EMPINFO.Rows(0).Item("WifeNotStayinREA").ToString() = "Y" Then
                bWifeGotRice = False
            End If

            ' hitung jml anak
            If DT_EMPINFO.Rows(0).IsNull("NoOfChildrenForTax") Then
                dNoOfChildren = 0
            Else
                dNoOfChildren = DT_EMPINFO.Rows(0).Item("NoOfChildrenForTax").ToString()
            End If
        End If

        dRAEmployee = FormatNumber(Val(lblRAEmployee.Text), 2)

        If bWifeGotRice Then
            dRAWifeOrHusband = FormatNumber(Val(lblRAHusbandOrWife.Text), 2)
        End If

        dRAChild = dNoOfChildren * FormatNumber(Val(lblRAChild.Text), 2)

        dCatuMax = dRAEmployee + dRAWifeOrHusband + dRAChild
        txtRiceMax.Text = dCatuMax.ToString()

        dRiceIssueQty = Math.Round((dHK / WorkingDays) * dCatuMax)

        txtRiceIssueQty.Text = dRiceIssueQty.ToString()

        btnAdd.Focus()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' Selasa, 29 Sep 2009, 22:36
        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("You must select Category", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If lblEmpCode.Text = String.Empty Or _
            lblEmpID.Text = String.Empty Then

            MessageBox.Show("You must select Employee Name or NIK", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        'If dHK = 0 Then

        '    MessageBox.Show("Your HK is 0", "Information", _
        '                MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return

        'End If

        ' Check apakah record RicePayment sudah ada ditable
        ' jika belum ada insert kan
        If DT_RicePayment.Rows.Count = 0 Then

            InsertRicePayment()
            RicePaymentTableAdapter.Update(DT_RicePayment)
            dgvRicePayment.DataSource = DT_RicePayment

            RiceID = DT_RicePayment.Rows(0).Item("RiceID").ToString()

        End If

        If FindEmpIDInRicePaymentDet() <> -1 Then
            MessageBox.Show("Employee already in grid, please check", "Information", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            InsertRicePaymentDet()
            ClearInput()
            MessageBox.Show("Data successfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub ClearInput()
        ' Selasa, 29 Sep 2009, 23:29
        txtNIK.Text = String.Empty
        txtName.Text = String.Empty

        lblEmpCode.Text = String.Empty
        lblEmpID.Text = String.Empty

        dHK = 0
        dCatuMax = 0
        dRiceIssueQty = 0

        txtHk.Text = dHK.ToString()
        txtRiceMax.Text = dCatuMax.ToString()
        txtRiceIssueQty.Text = dRiceIssueQty.ToString()
    End Sub

    Private Sub InsertRicePayment()
        ' Selasa, 29 Sep 2009, 22:39
        Dim NewRow As System.Data.DataRow

        NewRow = DT_RicePayment.NewRow()

        NewRow.Item("EstateID") = GlobalPPT.strEstateID
        NewRow.Item("EstateCode") = GlobalPPT.strEstateCode
        NewRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        NewRow.Item("RiceProcessingDate") = dtpAdvProcessingDate.Value
        NewRow.Item("Category") = CboCategory.SelectedItem.ToString()
        NewRow.Item("CreatedBy") = GlobalPPT.strUserName
        NewRow.Item("CreatedOn") = Now()
        NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
        NewRow.Item("ModifiedOn") = Now()

        DT_RicePayment.Rows.Add(NewRow)

    End Sub

    Private Sub InsertRicePaymentDet()
        ' Selasa, 29 Sep 2009, 23:18
        'Insert DETAIL
        Dim NewRow As System.Data.DataRow

        NewRow = DT_RicePaymentDet.NewRow()

        NewRow.Item("RiceProcessingDate") = DT_RicePayment.Rows(0).Item("RiceProcessingDate").ToString()
        NewRow.Item("Category") = DT_RicePayment.Rows(0).Item("Category").ToString()
        NewRow.Item("EmpCode") = lblEmpCode.Text
        NewRow.Item("EmpName") = txtName.Text

        NewRow.Item("RiceID") = RiceID
        NewRow.Item("EstateID") = GlobalPPT.strEstateID
        NewRow.Item("EstateCode") = GlobalPPT.strEstateCode
        NewRow.Item("EmpID") = lblEmpID.Text
        NewRow.Item("Mandays") = txtHk.Text
        NewRow.Item("RiceMax") = txtRiceMax.Text
        NewRow.Item("RiceIssueQty") = txtRiceIssueQty.Text
        NewRow.Item("CreatedBy") = GlobalPPT.strUserName
        NewRow.Item("CreatedOn") = Now()
        NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
        NewRow.Item("ModifiedOn") = Now()

        DT_RicePaymentDet.Rows.Add(NewRow)

    End Sub

    Private Function FindEmpIDInRicePaymentDet() As Integer
        ' Selasa, 29 Sep 2009, 23:24
        Dim rowIndex As Integer = -1

        If DT_RicePaymentDet IsNot Nothing Then
            For row As Integer = 0 To dgvRicePaymentDet.Rows.Count - 1
                If dgvRicePaymentDet.Rows(row).Cells("EmpID").Value = lblEmpID.Text Then
                    rowIndex = row
                End If
            Next
        End If

        Return rowIndex

    End Function

    Private Sub CboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCategory.SelectedIndexChanged
        ' Selasa, 29 Sep 2009, 23:01
        If CboCategory.SelectedIndex = -1 Then
            Return
        End If

        getRicePaymentInfo()
        btnGenerate.Focus()

        ' RicePayment_DAL.CRRiceDelete()


    End Sub

    Private Sub getRicePaymentInfo()
        ' Selasa, 29 Sep 2009, 23:02
        Cursor = Cursors.WaitCursor

        getRicePayment()
        getRicePaymentDet()

        Cursor = Cursors.Default
    End Sub

    Private Sub getRicePayment()
        ' Selasa, 29 Sep 2009, 23:03
        Dim category As String = CboCategory.SelectedItem.ToString()

        DT_RicePayment = RicePaymentTableAdapter.CRRicePaymentSelect( _
        dtpAdvProcessingDate.Value, _
        category, _
        GlobalPPT.strEstateID, "0")

        dgvRicePayment.DataSource = DT_RicePayment
    End Sub

    Private Sub getRicePaymentDet()
        ' Selasa, 29 Sep 2009, 23:06
        If DT_RicePayment.Rows.Count > 0 Then
            RiceID = DT_RicePayment.Rows(0).Item("RiceID").ToString()
        Else
            RiceID = String.Empty
        End If

        DT_RicePaymentDet = RicePaymentDetTableAdapter.RicePaymentDetSelect( _
        RiceID, _
        GlobalPPT.strEstateID)

        dgvRicePaymentDet.DataSource = DT_RicePaymentDet
        ManagedgvRicePaymentDetcolumn()
    End Sub

    Private Sub ManagedgvRicePaymentDetcolumn()
        ' Selasa, 29 Sep 2009, 23:38
        dgvRicePaymentDet.Columns("ID").Visible = False
        dgvRicePaymentDet.Columns("EstateID").Visible = False
        dgvRicePaymentDet.Columns("EstateCode").Visible = False
        dgvRicePaymentDet.Columns("RiceID").Visible = False
        dgvRicePaymentDet.Columns("RiceDetID").Visible = False
        dgvRicePaymentDet.Columns("RPDColumnConcurrencyId").Visible = False
        dgvRicePaymentDet.Columns("CreatedBy").Visible = False
        dgvRicePaymentDet.Columns("CreatedOn").Visible = False
        dgvRicePaymentDet.Columns("ModifiedBy").Visible = False
        dgvRicePaymentDet.Columns("ModifiedOn").Visible = False
        dgvRicePaymentDet.Columns("EmpID").Visible = False
        dgvRicePaymentDet.Columns(5).Visible = False
    End Sub

    Private Sub ManagedgvRicePaymentViewColumn()
        ' Rabu, 30 Sep 2009, 03:59
        dgvRicePaymentView.Columns("RPViewColumnConcurrencyId").Visible = False

        dgvRicePaymentView.Columns("RiceID").Visible = False
        dgvRicePaymentView.Columns("EstateID").Visible = False
        dgvRicePaymentView.Columns("ActiveMonthYearID").Visible = False
        dgvRicePaymentView.Columns("EstateCode").Visible = False

        dgvRicePaymentView.Columns("CreatedBy").Visible = False
        dgvRicePaymentView.Columns("CreatedOn").Visible = False
        dgvRicePaymentView.Columns("ModifiedBy").Visible = False
        dgvRicePaymentView.Columns("ModifiedOn").Visible = False

    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        ' Selasa, 29 Sep 2009, 23:45
        If MessageBox.Show("Are you sure want to save to database", "Save", MessageBoxButtons.OKCancel, _
            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        SaveRicePaymentDet()
        getRicePaymentView()
    End Sub

    Private Sub SaveRicePaymentDet()
        ' Selasa, 29 Sep 2009, 23:46
        Dim RecordAffected As Integer

        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Category must be selected", "Checkroll", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblProcessMsg.Text = "Saving..."
        lblProcessMsg.Visible = True
        lblProcessMsg.Refresh()

        RecordAffected = RicePaymentDetTableAdapter.Update(DT_RicePaymentDet)
        'Selasa, 22 Dec 2009, 16:24
        Dim category As String = CboCategory.SelectedItem.ToString()
        RicePayment_DAL.CRRiceAdvanceLog(category)

        If RecordAffected > 0 Then
            ' By Dadang Adi H
            ' Jum'at, 1 Jan 2010, 13:17
            CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
            ' END Jum'at, 1 Jan 2010, 13:17

            MessageBox.Show("Rice Payment successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        lblProcessMsg.Visible = False
    End Sub

    Private Sub cmsRicePaymentDet_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsRicePaymentDet.Opening
        ' Rabu, 30 Sep 2009, 00:10
        If dgvRicePaymentDet.Rows.Count = 0 Then
            cmsRicePaymentDet.Items(0).Enabled = False
        ElseIf dgvRicePaymentDet.Rows.Count > 0 And dgvRicePaymentDet.CurrentCell IsNot Nothing Then
            cmsRicePaymentDet.Items(0).Enabled = True
        End If

    End Sub

    Private Sub DeleteMIRicePaymentDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMIRicePaymentDet.Click
        ' Rabu, 30 Sep 2009, 00:12
        If dgvRicePaymentDet.Rows.Count = 0 Or dgvRicePaymentDet.CurrentCell Is Nothing Then
            Return
        End If

        Dim rowIndex As Integer = dgvRicePaymentDet.CurrentCell.RowIndex
        Dim empname As String = dgvRicePaymentDet.Rows(rowIndex).Cells("RPDColumnEmpName").Value.ToString()
        Dim empnik As String = dgvRicePaymentDet.Rows(rowIndex).Cells("RPDColumnEmpCode").Value.ToString()

        If MessageBox.Show("Yout are about to delete the selected record." + vbCrLf + _
                           "Are you sure want to delete this record:" + vbCrLf + _
            "NIK    : " + empnik + vbCrLf + _
            "NAME : " + empname, "Delete", MessageBoxButtons.OKCancel, _
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        DeleteRicePaymentDet()

    End Sub

    Private Sub DeleteRicePaymentDet()
        ' Rabu, 30 Sep 2009, 00:14
        If dgvRicePaymentDet.Rows(dgvRicePaymentDet.CurrentCell.RowIndex).Cells("RiceDetID").Value Is System.DBNull.Value Then
            dgvRicePaymentDet.Rows.RemoveAt(dgvRicePaymentDet.CurrentCell.RowIndex)
        Else
            DT_RicePaymentDet.Rows(dgvRicePaymentDet.CurrentCell.RowIndex).Delete()
        End If

        MessageBox.Show("Data successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub RicePayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Rabu, 30 Sep 2009, 00:17
        Dim ModifiedRow As DataRow() = DT_RicePaymentDet.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_RicePaymentDet.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_RicePaymentDet.Select(Nothing, Nothing, DataViewRowState.Deleted)

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
                SaveRicePaymentDet()
                Cursor = Cursors.Default
            Else
                RicePayment_DAL.CRRiceDelete()
            End If

        End If

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        ' Rabu, 30 Sep 2009, 00:29

        If CboCategory.SelectedIndex = -1 Then
            MessageBox.Show("You must select Category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        'If MessageBox.Show("Do you want to process Generated Rice Payment", "Advance Rice", _
        '           MessageBoxButtons.OKCancel, _
        '           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
        '    Return
        'End If
        '=================================================================================================
        'Delete for Advance if Exist
        '============================


        If dgvRicePaymentDet.Rows.Count > 0 Then

            Cursor = Cursors.WaitCursor
            lblProcessMsg.Text = "Deleting..."
            lblProcessMsg.Visible = True
            lblProcessMsg.Refresh()

            ' Alhamdulillahirobbilaalamin
            ' Sabtu, 12 Des 2009, 18:24
            Dim rows() = ToArray(DT_RicePaymentDet.Rows)
            Dim dr As DataRow

            For Each dr In rows
                dr.Delete()
                dr.EndEdit()
            Next

            Dim RecordAffected As Integer = RicePaymentDetTableAdapter.Update(DT_RicePaymentDet)

            Cursor = Cursors.Default
        End If

        If dgvRicePayment.Rows.Count > 0 Then
            'DT_RicePayment.Clear()
            DT_RicePayment.Rows(0).Delete()
            RicePaymentTableAdapter.Update(DT_RicePayment)
        End If
        '================================================================================================
        lblProcessMsg.Text = "Processing..."
        GenerateRicePayment()
    End Sub

    Function ToArray(ByVal collection As DataRowCollection) As DataRow()
        ' Alhamdulillahirobbiaalamiin
        ' By Dadang Adi Hendradi
        ' Sabtu, 12 Des 2009, 18:23
        Dim result(collection.Count - 1) As DataRow

        collection.CopyTo(result, 0)
        Return result
    End Function

    Private Sub GenerateRicePayment()
        ' Rabu, 30 Sep 2009, 00:44
        Dim RiceProcessingDate As Date
        Dim Category As String = String.Empty

        Category = CboCategory.SelectedItem.ToString()
        'AdvProcessingDate = dtpAdvProcessingDate.Value

        Dim DT_Emp As DataTable
        'DT_Emp = RicePaymentDetTableAdapter.CRNikNameByCategorySelect(GlobalPPT.strEstateID, "", "", Category)
        ' Selasa, 17 Nov 2009, 00:29
        ' Sekarang ngambil dari AttendanceSummary table
        DT_Emp = AdvancePaymentDet_DAL.CRAttendanceSummarySelect(Category)

        If DT_Emp.Rows.Count = 0 Then

            MessageBox.Show("No Employee in " + Category + " Category." + vbCrLf + _
                            "Please check Employee Master", "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        DT_RicePayment = RicePaymentTableAdapter.CRRicePaymentSelect( _
        dtpAdvProcessingDate.Value, _
        Category, _
        GlobalPPT.strEstateID, "0")


        If DT_RicePayment.Rows.Count = 0 Then

            InsertRicePayment()
            RicePaymentTableAdapter.Update(DT_RicePayment)
            dgvRicePayment.DataSource = DT_RicePayment

            RiceID = DT_RicePayment.Rows(0).Item("RiceID").ToString()

        Else
            ' jika sudah ada
            'RiceProcessingDate = DT_RicePayment.Rows(0).Item("RiceProcessingDate")
            'If MessageBox.Show("Data already exist for this month:" + vbCrLf + _
            '                "Advance Processing Date is: " + RiceProcessingDate.ToString("dd/MM/yyyy") + vbCrLf + _
            '                "Are you sure want to process to this date", "Warning", _
            '                 MessageBoxButtons.OKCancel, _
            '                 MessageBoxIcon.Question, _
            '                 MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            '    Return
            'End If
        End If


        '///
        'Fiscal Year
        Dim FromDate As Date
        Dim ToDT As Date
        Dim DT_Fiscalyear As DataTable

        RiceProcessingDate = DT_RicePayment.Rows(0).Item("RiceProcessingDate")

        DT_Fiscalyear = AdvancePayment_DAL.FiscalYear( _
            RiceProcessingDate.Year, RiceProcessingDate.Month)

        lblProcessMsg.Visible = True
        lblProcessMsg.Refresh()

        If DT_Fiscalyear.Rows.Count = 0 Then
            MessageBox.Show("Fiscal Year has not yet been setup", "Information", MessageBoxButtons.OK, _
                             MessageBoxIcon.Information)
            Return
        End If

        FromDate = DT_Fiscalyear.Rows(0).Item("FromDT")
        ToDT = DT_Fiscalyear.Rows(0).Item("ToDT")

        Dim ts As TimeSpan
        Dim NoOfDay As Integer = 0
        Dim NoOfDayInMonthInFiscalYear = 0
        Dim NoOfPublicHoliday As Integer = 0
        Dim WorkingDays As Integer = 0
        'Dim NoOfRestDay As Integer = 4 ' anggap restday dalam satu bulan 4 hari

        'fixed on 2 July 2013 -- first day and last day of month is sunday
        Dim NoOfRestDay As Integer = DateDiff(DateInterval.Weekday, FromDate, ToDT) _
            + (IIf(FromDate.ToString("dddd").ToUpper = "SUNDAY", 1, 0)) _
            + (IIf(ToDT.ToString("dddd").ToUpper = "SUNDAY", 1, 0)) '1 for last date is sunday


        'stanley@03-11-2011
        Dim NoOfPHFallonSun As Integer = 0

        ts = ToDT - FromDate

        'following line commented on 2 July 2013
        'NoOfDay = ts.Days  + 1

        NoOfDay = ts.Days
        NoOfDayInMonthInFiscalYear = ts.Days + 1
        NoOfPublicHoliday = RicePaymentDetails_DAL.CRNoOfPHInThisMonthYear( _
            RiceProcessingDate.Month, RiceProcessingDate.Year)

        'stanley@03-11-2011
        NoOfPHFallonSun = RicePaymentDetails_DAL.CRNoOfPHFallOnSundayInThisMonthYear( _
            RiceProcessingDate.Month, RiceProcessingDate.Year)

        'WorkingDays = NoOfDayInMonthInFiscalYear - NoOfPublicHoliday - NoOfRestDay
        '' Jum'at, 19 Mar 2010, 08:53
        '05-08-2011 WorkingDays = RicePayment_DAL.CRGetWorkingDays()
        'WorkingDays = NoOfDay - NoOfPublicHoliday - NoOfRestDay
        'stanley@03-11-2011
        WorkingDays = NoOfDay - NoOfPublicHoliday - NoOfRestDay + NoOfPHFallonSun
        ' END Fiscal Year
        '///


        Cursor = Cursors.WaitCursor

        DT_RicePaymentDet = RicePaymentDetTableAdapter.RicePaymentDetSelect( _
        RiceID, _
        GlobalPPT.strEstateID)
        Dim k As New Integer

        For Each EmpRow As DataRow In DT_Emp.Rows

            Dim bFound As Boolean = False

            'For Each RicePaymentDetRow As DataRow In DT_RicePaymentDet.Rows

            '    If EmpRow.Item("EmpID").ToString() = RicePaymentDetRow.Item("EmpID").ToString() Then
            '        'jika Employee sudah ada di RicePaymentDet
            '        'keluar
            '        bFound = True
            '        Exit For
            '    End If

            'Next RicePaymentDetRow

            'For Testing only
            'If EmpRow.Item("EmpName") = "PURNOMO" Then
            '    MessageBox.Show(EmpRow.Item("EmpName").ToString())
            'End If

            If Not bFound Then

                Dim DT_HK As DataTable
                ' Kamis, 25 Mar 2010, 23:42
                DT_HK = RicePayment_DAL.CRGetTotalAttendanceForRiceAdvance( _
                    FromDate, _
                    DT_RicePayment.Rows(0).Item("RiceProcessingDate"), _
                    EmpRow.Item("EmpID").ToString(), _
                    "")

                dHK = 0

                If Not DT_HK Is Nothing Then

                    If DT_HK.Rows.Count > 0 Then
                        dHK = DT_HK.Rows(0).Item("TotalAttendance")
                    End If

                End If

                Dim DT_EmpInfo As DataTable

                DT_EmpInfo = RicePaymentDetTableAdapter.getEmpInfo( _
                EmpRow.Item("EmpID").ToString(), _
                GlobalPPT.strEstateID)

                Dim bWifeGotRice = True

                If DT_EmpInfo.Rows.Count > 0 Then

                    ' apakah istri atau suami dapat beras
                    If DT_EmpInfo.Rows(0).IsNull("WifeEmpWithREA") Then
                        bWifeGotRice = False
                    ElseIf DT_EmpInfo.Rows(0).Item("WifeEmpWithRea").ToString() = "Y" Then
                        bWifeGotRice = False
                    End If

                    If DT_EmpInfo.Rows(0).IsNull("WifeNotStayinREA") Then
                        bWifeGotRice = False
                    ElseIf DT_EmpInfo.Rows(0).Item("WifeNotStayinREA").ToString() = "Y" Then
                        bWifeGotRice = False
                    End If


                    If DT_EmpInfo.Rows(0).Item("WifeStayinREAReceivesRice").ToString() = "Y" Then
                        bWifeGotRice = True
                    Else
                        bWifeGotRice = False
                    End If


                    ' hitung jml anak
                    If DT_EmpInfo.Rows(0).IsNull("NoOfChildrenForTax") Then
                        dNoOfChildren = 0
                    Else
                        dNoOfChildren = DT_EmpInfo.Rows(0).Item("NoOfChildrenForTax").ToString()
                    End If
                End If

                dRAEmployee = 0
                dRAWifeOrHusband = 0
                dRAChild = 0

                dRAEmployee = FormatNumber(Val(lblRAEmployee.Text), 2)

                If bWifeGotRice Then
                    dRAWifeOrHusband = FormatNumber(Val(lblRAHusbandOrWife.Text), 2)
                Else
                    dRAWifeOrHusband = 0
                End If

                dRAChild = dNoOfChildren * FormatNumber(Val(lblRAChild.Text), 2)

                dCatuMax = 0
                dRiceIssueQty = 0

                dCatuMax = dRAEmployee + dRAWifeOrHusband + dRAChild
                k = k + 1

                If k = 24 Then
                    dCatuMax = dRAEmployee + dRAWifeOrHusband + dRAChild
                End If

                ' Sabtu, 12 Des 2009, 00:11 
                'Permasalahan RANN 05 Desember 2009_Update_By_Batricorsila.doc

                'dRiceIssueQty = Math.Round((dHK / WorkingDays) * dCatuMax)
                dRiceIssueQty = (dHK / WorkingDays) * dCatuMax

                Dim dcTemp As Decimal = Math.Round(dRiceIssueQty, 2)

                ' Kamis, 25 Mar 2010, 23:54
                'For Testing only
                'If EmpRow.Item("EmpName") = "Ramli K" Then
                '    MessageBox.Show(EmpRow.Item("EmpName").ToString())
                'End If

                'Palani
                'dRiceIssueQty = Math.Round(dRiceIssueQty, 0)
                dRiceIssueQty = Math.Round(dcTemp, 0)

                ' END Kamis, 25 Mar 2010, 23:54

                'Dim Hasil As Decimal = 0
                'Dim pecahan As Decimal = 0
                'Dim Integral As Decimal = 0

                'Integral = Math.Truncate(dRiceIssueQty)
                'pecahan = dRiceIssueQty - Integral

                'If pecahan < 0.5 And pecahan > 0.0 Then
                '    pecahan = 0.5
                '    dRiceIssueQty = Integral + pecahan

                'ElseIf pecahan > 0.5 Then
                '    dRiceIssueQty = Integral + 1.0

                'End If
                ' END Sabtu, 12 Des 2009, 00:11 

                Dim NewRow As System.Data.DataRow

                NewRow = DT_RicePaymentDet.NewRow()

                NewRow.Item("RiceProcessingDate") = DT_RicePayment.Rows(0).Item("RiceProcessingDate")
                NewRow.Item("Category") = DT_RicePayment.Rows(0).Item("Category").ToString()
                NewRow.Item("EmpCode") = EmpRow.Item("EmpCode").ToString()
                NewRow.Item("EmpName") = EmpRow.Item("EmpName").ToString()

                NewRow.Item("RiceID") = RiceID
                NewRow.Item("EstateID") = GlobalPPT.strEstateID
                NewRow.Item("EstateCode") = GlobalPPT.strEstateCode
                NewRow.Item("EmpID") = EmpRow.Item("EmpID").ToString()
                NewRow.Item("Mandays") = dHK
                NewRow.Item("RiceMax") = dCatuMax
                ' NewRow.Item("RiceIssueQty") = dRiceIssueQty
                NewRow.Item("RiceIssueQty") = dCatuMax / 2
                NewRow.Item("CreatedBy") = GlobalPPT.strUserName
                NewRow.Item("CreatedOn") = Now()
                NewRow.Item("ModifiedBy") = GlobalPPT.strUserName
                NewRow.Item("ModifiedOn") = Now()

                DT_RicePaymentDet.Rows.Add(NewRow)

            End If 'Not bFound

        Next EmpRow
        dgvRicePaymentDet.DataSource = DT_RicePaymentDet

        lblProcessMsg.Visible = False

        Cursor = Cursors.Default

        'MessageBox.Show("Processsing Rice Payment for " + _
        '        RiceProcessingDate.ToString("dd/MM/yyyy") + " finished", _
        '        "Information", _
        '        MessageBoxButtons.OK, _
        '        MessageBoxIcon.Information)

        'MessageBox.Show("Processsing Rice Payment for " + _
        '        dtpAdvProcessingDate.Value.ToString("dd/MM/yyyy") + " finished", _
        '        "Information", _
        '        MessageBoxButtons.OK, _
        '        MessageBoxIcon.Information)

    End Sub

    Private Sub btnSearchView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchView.Click
        ' Rabu, 30 Sep 2009, 03:51
        'If cboCategoryView.SelectedIndex = -1 Then
        '    MessageBox.Show("Please select category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        getRicePaymentView()
        If dgvRicePaymentView.Rows.Count = 0 Then
            MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub getRicePaymentView()
        ' Rabu, 30 Sep 2009, 03:52
        Dim category As String
        If cboCategoryView.SelectedItem Is Nothing Then
            category = ""
        Else
            category = cboCategoryView.SelectedItem.ToString()
        End If


        If chkDate.Checked = True Then
            RiceDate = 1
        Else
            RiceDate = 0
        End If

        DT_RicePaymentView = RicePaymentTableAdapter.CRRicePaymentSelect( _
        dtpAdvProcessingDateView.Value, category, _
        GlobalPPT.strEstateID, RiceDate)
        dgvRicePaymentView.DataSource = DT_RicePaymentView


    End Sub

    Private Sub dgvRicePaymentView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRicePaymentView.CellDoubleClick
        ' Rabu, 30 Sep 2009, 04:02
        If dgvRicePaymentView.Rows.Count > 0 Then
            If dgvRicePaymentView.CurrentCell IsNot Nothing Then

                If cboCategoryView.SelectedIndex <> -1 Then
                    SelectRicePaymentFromView()
                End If

            End If
        End If
    End Sub

    Private Sub SelectRicePaymentFromView()
        ' Rabu, 30 Sep 2009, 04:07
        dtpAdvProcessingDate.Value = _
        dgvRicePaymentView.Rows(dgvRicePaymentView.CurrentCell.RowIndex).Cells("RPViewColumnRiceProcessingDate").Value
        CboCategory.SelectedIndex = cboCategoryView.SelectedIndex

        tcRicePayment.SelectedTab = tabAdvancePayment

    End Sub


    Private Sub btnNameFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNameFind.Click
        ' Rabu, 30 Sep 2009, 04:28
        FindByName()
    End Sub

    Private Sub FindByName()
        ' Rabu, 30 Sep 2009, 04:54
        If dgvRicePaymentDet.Rows.Count = 0 Then
            Return
        End If

        Dim rowIndex As Integer

        rowIndex = FindEmp(txtNameFind.Text, "RPDColumnEmpName")
        If (rowIndex <> -1) Then
            dgvRicePaymentDet.CurrentCell = dgvRicePaymentDet.Rows(rowIndex).Cells("RPDColumnEmpName")
        End If

    End Sub


    Private Function FindEmp(ByVal StrFind As String, ByVal columnName As String) As Integer
        ' Rabu, 30 Sep 2009, 04:28
        Dim CellValue As String
        Dim rowIndex As Integer = -1

        For i As Integer = 0 To dgvRicePaymentDet.Rows.Count - 1

            CellValue = dgvRicePaymentDet.Rows(i).Cells(columnName).Value.ToString()
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

    Private Sub btnNIKFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNIKFind.Click
        ' Rabu, 30 Sep 2009, 04:54
        FindByNIK()
    End Sub

    Private Sub FindByNIK()
        ' Rabu, 30 Sep 2009, 04:54
        If dgvRicePaymentDet.Rows.Count = 0 Then
            Return
        End If

        Dim rowIndex As Integer

        rowIndex = FindEmp(txtNIKFind.Text, "RPDColumnEmpCode")
        If (rowIndex <> -1) Then
            dgvRicePaymentDet.CurrentCell = dgvRicePaymentDet.Rows(rowIndex).Cells("RPDColumnEmpCode")
        End If

    End Sub

    Private Sub txtNameFind_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNameFind.KeyDown
        ' Rabu, 30 Sep 2009, 04:56
        If e.KeyCode = Keys.Enter Then
            FindByName()
        End If
    End Sub

    Private Sub txtNIKFind_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIKFind.KeyDown
        ' Rabu, 30 Sep 2009, 04:56
        If e.KeyCode = Keys.Enter Then
            FindByNIK()
        End If
    End Sub

    Private Sub txtNIK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNIK.KeyDown
        ' Rabu, 30 Sep 2009, 05:06

        If e.KeyCode = Keys.Enter Then

            If CboCategory.SelectedIndex = -1 Then
                MessageBox.Show("Please select Category First", "Information", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim empcategory As String
            empcategory = CboCategory.SelectedItem.ToString()

            Dim DT_EMP As DataTable
            DT_EMP = RicePaymentDetTableAdapter.CRNikNameByCategorySelect(GlobalPPT.strEstateID, txtNIK.Text, "", empcategory)


            If DT_EMP.Rows.Count = 0 Or DT_EMP.Rows.Count > 1 Then
                'lblEmpCode.Text = "NOTVALID"
                'lblEmpID.Text = "NOTVALID"
                'txtName.Text = ""

                'dHK = 0
                'dCatuMax = 0
                'dRiceIssueQty = 0

                'txtHk.Text = "0"
                'txtRiceMax.Text = "0"
                'txtRiceIssueQty.Text = "0"
                ClearInput()
                MessageBox.Show("NIK not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtName.Focus()

            ElseIf DT_EMP.Rows.Count = 1 Then
                lblEmpCode.Text = DT_EMP.Rows(0).Item("EmpCode").ToString()
                lblEmpID.Text = DT_EMP.Rows(0).Item("EmpID").ToString()

                txtName.Text = DT_EMP.Rows(0).Item("EmpName").ToString()
                getEmpRicePayment()
            End If

        End If

    End Sub


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Rabu, 30 Sep 2009, 06:13
        ClearInput()
        txtNIK.Focus()
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        ' Senin, 5 Oct 2009, 18:13
        MessageBox.Show("Under construction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return

    End Sub

    Private Sub tabAdvancePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabAdvancePayment.Click

    End Sub

    Private Sub tcRicePayment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRicePayment.SelectedIndexChanged
        If tcRicePayment.SelectedIndex = 1 Then
            chkDate.Checked = False
            dtpAdvProcessingDateView.Value = GlobalPPT.FiscalYearToDate
            cboCategoryView.SelectedIndex = -1
            getRicePaymentView()
            dtpAdvProcessingDateView.Focus()
        ElseIf tcRicePayment.SelectedIndex = 0 Then
            dtpAdvProcessingDate.Focus()
        End If
    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        dtpAdvProcessingDateView.Enabled = chkDate.Checked
    End Sub

    Private Sub RicePayment_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

End Class