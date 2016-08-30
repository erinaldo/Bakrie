Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization


Public Class LoadingCPOFrm

    Public lTankID As String = String.Empty
    Public lCropYieldID As String = String.Empty
    Public lLoadingLocationID As String = String.Empty
    Public lStockTankID As String = String.Empty
    Public lLoadTankID As String = String.Empty
    Public lTransTankID As String = String.Empty
    Public lLocationID As String = String.Empty
    Public lTransLocationID As String = String.Empty
    Public lLoadLocationID As String = String.Empty
    Public SaveFlag As Boolean = True
    Public lProductionID As String = String.Empty
    Public lLoadMonthToDate As Double = 0.0
    Public lTransMonthToDate As Double = 0.0
    Public lProductionToDate As Double = 0.0
    Public lProdCurrentReading As Double = 0.0
    Public lProdLoadQty As Double = 0.0
    Public lProdTransQty As Double = 0.0
    Public lProdBFQty As Double = 0.0
    Public isDecimal As Boolean
    Public lresetLoad As Boolean = True
    Public lresetTrans As Boolean = True
    Private LoadMonthCount As Integer
    Public lProdLoadingID As String = String.Empty
    Public rowid As Integer = 0
    Dim objEditDuplicateRecord As Object
    Dim objDeleteDuplicateRecord As Object
    Dim objEditDuplicateSearchRecord As Object
    Dim objDeleteDuplicateSearchRecord As Object
    Dim objCompareDateCheck As Object


    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Shadows mdiparent As New MDIParent

    ''Load CPO'''
    Public btnAddLoadFlag As Boolean = True
    Dim columnLoadCPOAdd As DataColumn
    Dim rowLoadCPOAdd As DataRow
    Dim dtLoadCPOAdd As New DataTable("todgvLoadCPOAdd")
    Public dtLoadAddFlag As Boolean = False

    Public btnAddFlag As Boolean = True
    Public AddFlag As Boolean = True
    Public lLoadTank As String
    Public lLoadLocation As String
    Dim lLoadQty, lTransferQty As Decimal

    Public lProdIdNew As String = String.Empty
    Public lLocationDesc As String = String.Empty
    Public isModifierKey As Boolean
    Dim lLoadCapacity As Decimal = 0

    Dim dsLoadTankNo As DataSet
    Public lCropYieldCode As String = String.Empty
    Dim lLoadQtyPrev As Decimal = 0
    Dim lQtyPrev As Decimal = 0

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim DeleteMultientryStockCPO As New ArrayList
    Dim DeleteMultientryLoadCPO As New ArrayList
    Dim DeleteMultientryTransCPO As New ArrayList
    Dim lDelete As Integer
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LoadingCPOFrm))

    Private Sub LoadingCPOFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSave.Enabled = True And dgvLoadCPODetails.RowCount > 0 And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M97"

            End If
        End If
    End Sub

    Private Sub LoadingCPOFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LoadingCPOFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsButtonClose = False
        GlobalPPT.IsRetainFocus = False
        SetUICulture(GlobalPPT.strLang)



        'edit by suraya 14092012
        'Dim ToDate As Date = Date.Today 
        'dtpCPODate.Value = ToDate
        'dtpCPOViewDate.Value = Date.Today
        'dtpCPODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        'dtpCPODate.MinDate = GlobalPPT.FiscalYearFromDate
        'dtpCPODate.MaxDate = GlobalPPT.FiscalYearToDate
        'Dim TempDate As Date = dtpCPODate.Value
        'Dim NowDate As Date = Now()
        'If Now() >= GlobalPPT.FiscalYearFromDate And dtpCPODate.Value <= GlobalPPT.FiscalYearFromDate Then
        '    dtpCPODate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        'End If

        'Dim ToDate As Date = dtpCPODate.Value
        'dtpCPODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        dtpCPODate.Format = DateTimePickerFormat.Custom 'edit
        dtpCPODate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpCPODate)

        dtpCPOViewDate.Format = DateTimePickerFormat.Custom
        dtpCPOViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpCPOViewDate)

        Dim objCPOPPT As New LoadingCPOPPT
        Dim dsCrop As New DataSet

        dsCrop = LoadingCPOBOL.ProductionCropYieldIDSelect(objCPOPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for CPO, Please insert the record in General Crop Yield")
        End If
        tcLoadingCPO.SelectedTab = tpCPOView

        loadCmbStorage()
        loadCmbLocation()

        dtpCPOViewDate.Enabled = False
        lCropYieldCode = "CPO"

        GetCropYieldID()
        objCPOPPT.CropYieldID = lCropYieldID
        ResetMain()
        Reset()

        CPOGridViewBind()
        dtpCPODate.Focus()
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tcLoadingCPO.TabPages("tpCPOSave").Text = rm.GetString("ttcLoadingCPO.TabPages(tpCPOSave).Text")
            'tcLoadingCPO.TabPages("tpCPOView").Text = rm.GetString("ttcLoadingCPO.TabPages(tpCPOView).Text")

            'chkCPODate.Text = rm.GetString("Date")
            'grpLoadCPO.Text = rm.GetString("LoadCPO")

            'grpLoadCPORecords.Text = rm.GetString("LoadCPORecords")
            'PnlSearch.CaptionText = rm.GetString("SearchLoadingCPO")

            'dgvLoadCPODetails.Columns("dgclLoadStorageNo").HeaderText = rm.GetString("Storage")
            'dgvLoadCPODetails.Columns("dgclToLoading").HeaderText = rm.GetString("To Loading")

            'dgvLoadCPODetails.Columns("dgclLoadQuantity").HeaderText = rm.GetString("Quantity")
            'dgvLoadCPODetails.Columns("dgclLoadMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvLoadCPODetails.Columns("dgclLoadRemarks").HeaderText = rm.GetString("Remarks")

            btnSave.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddLoad.Text = rm.GetString("Add")
            btnResetLoad.Text = rm.GetString("Reset")

            'dgvCPOView.Columns("gvCPODate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub CPOGetLoadTransMonthQty()
        Try
            Dim objCPOPPT As New LoadingCPOPPT
            Dim dsTransLoad As DataSet
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpCPODate.Value
            dsTransLoad = LoadingCPOBOL.CPOGetLoadTransMonthQty(objCPOPPT)
            If dsTransLoad.Tables.Count <> 0 Then

                If dsTransLoad.Tables(0).Rows.Count <> 0 Then
                    'If lresetLoad = True Then
                    If Not dsTransLoad.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
                        Me.txtLoadMonthToDate.Text = dsTransLoad.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        Me.txtLoadMonthToDate.Text = 0.0
                    End If
                    lresetLoad = False
                    ' End If
                    lresetTrans = False
                    'End If
                    'Else
                    '    Me.txtLoadMonthToDate.Text = 0.0
                    '    Me.txtTransMonthToDate.Text = 0.0
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub loadCmbStorage()
        Try

            dsLoadTankNo = LoadingCPOBOL.loadCmbStorage("CPO")

            'For Load Tank

            Dim dr1 As DataRow = dsLoadTankNo.Tables(0).NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            dsLoadTankNo.Tables(0).Rows.InsertAt(dr1, 0)

            'Load CPO
            cmbLoadTank.DataSource = dsLoadTankNo.Tables(0)
            cmbLoadTank.DisplayMember = "TankNo"
            cmbLoadTank.ValueMember = "TankID"

        Catch ex As Exception
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("There is No Tank for This Estate") 'ex.Message)
        End Try
    End Sub

    Private Sub loadCmbLocation()
        Try
            cmbLoadLocation.DataSource = Nothing
            Dim dsLoadLocation As DataSet
            dsLoadLocation = LoadingCPOBOL.loadCmbLocation()
            'Location CPO Combo
            cmbLoadLocation.DataSource = dsLoadLocation.Tables(0)

            cmbLoadLocation.DisplayMember = "LoadingLocationCode"
            cmbLoadLocation.ValueMember = "LoadingLocationID"
            If dsLoadLocation.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg4")
                ''MsgBox("No Records Available for Loading Location ,Please insert the Record inProduction Loading Location")
            End If


            Dim dr As DataRow = dsLoadLocation.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            dsLoadLocation.Tables(0).Rows.InsertAt(dr, 0)
            'dsStockTankNo.AcceptChanges()

            If dsLoadLocation.Tables(0).Rows.Count <> 0 Then
                lLoadingLocationID = dsLoadLocation.Tables(0).Rows(0).Item("LoadingLocationID")
            Else
                lLoadingLocationID = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetCropYieldID()
        Try
            Dim dsCrop As New DataSet
            Dim objCPOPPT As New LoadingCPOPPT
            objCPOPPT.CropYieldCode = lCropYieldCode
            If objCPOPPT.CropYieldCode <> String.Empty Then
                dsCrop = LoadingCPOBOL.GetCropYieldID(objCPOPPT)
            End If
            If dsCrop.Tables.Count <> 0 Then
                If dsCrop.Tables(0).Rows.Count <> 0 Then
                    lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub GetCropYield()
        Try
            Dim dsCropID As New DataSet
            Dim objCPOPPT As New LoadingCPOPPT
            objCPOPPT.TankID = lTankID
            If objCPOPPT.TankID <> String.Empty Then
                dsCropID = LoadingCPOBOL.GetCropYield(objCPOPPT)
            End If
            If dsCropID.Tables.Count <> 0 Then
                If dsCropID.Tables(0).Rows.Count <> 0 Then
                    lCropYieldID = dsCropID.Tables(0).Rows(0).Item("CropYieldID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Function IsCheckValidationLoad()

        If cmbLoadTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg13")
            '' MessageBox.Show("This Field is Required ", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTank.Focus()
            Return False
        End If
        If cmbLoadLocation.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg14")
            ''MessageBox.Show("This Field is Required", "To Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadLocation.Focus()
            Return False
        End If
        If Val(txtLoadQty.Text) = 0 Then
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadQty.Focus()
            Return False
        End If
        If Val(txtLoadMonthToDate.Text) = 0 Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("This Field is Required", "Month To Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadMonthToDate.Focus()
            Return False
        End If
        If Val(txtLoadMonthToDate.Text) < Val(txtLoadQty.Text) Then
            DisplayInfoMessage("Msg17")
            '' MessageBox.Show("Month To Date value cant be lesser than Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadMonthToDate.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub ResetLoad()
        ''''For Stock CPO

        lresetLoad = True
        lresetTrans = False
        If cmbLoadTank.Items.Count > 0 Then
            cmbLoadTank.SelectedIndex = 0
        End If
        If cmbLoadLocation.Items.Count > 0 Then
            cmbLoadLocation.SelectedIndex = 0
        End If
        '  txtLoadBalanceBF.Text = ""
        txtLoadQty.Text = ""
        txtLoadRemarks.Text = ""
        ' lblLoadDescription.Text = "Description"
        ' CPOGetLoadTransMonthQty()
        If GlobalPPT.strLang = "en" Then
            btnAddLoad.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddLoad.Text = "Menambahkan"
        End If
        ''btnAddLoad.Text = "Add"
        btnAddLoadFlag = True
        lLoadQtyPrev = 0
        'btnSave.Enabled = True
        'btnDeleteAll.Enabled = True
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub
    Public Sub ResetMain()

        btnAddFlag = True
       
    End Sub

    Public Sub Reset()
        btnSave.Enabled = True
        btnDeleteAll.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        dtpCPODate.Enabled = True
        'For Load CPO

        'cmbLoadTank.Text = "Select All"
        cmbLoadLocation.Text = ""
        ' txtLoadBalanceBF.Text = ""
        txtLoadQty.Text = ""
        txtLoadMonthToDate.Text = ""

        '''' For Trans CPO
        If cmbLoadTank.Items.Count > 0 Then
            cmbLoadTank.SelectedIndex = 0
        End If


        If cmbLoadLocation.Items.Count > 0 Then
            cmbLoadLocation.SelectedIndex = 0
        End If

        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSave.Text = "Simpan Semua"
        End If
        '' btnSaveAll.Text = "Save All"
        SaveFlag = True
        dtpCPOViewDate.Enabled = False
        chkCPODate.Checked = False

        '''''For Production CPO
        'Dim ToDate As Date = Date.Today
        'dtpCPODate.Value = ToDate
        'dtpCPOViewDate.Value = Date.Today
        'dtpCPODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpCPODate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpCPOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpCPOViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        ClearGridView(dgvLoadCPODetails)

        DeleteMultientryLoadCPO.Clear()

        If dgvCPOView.Rows.Count > 0 Then
            ''''For Loading CPO'''''''
            txtLoadMonthToDate.Enabled = False

        Else
            ''''For Loading CPO'''''''
            txtLoadMonthToDate.Enabled = True
        End If


    End Sub

    Private Sub CPOGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objCPOPPT As New LoadingCPOPPT
            objCPOPPT.CPODate = dtpCPODate.Value
            'loadCmbStorage()
            With objCPOPPT
                If chkCPODate.Checked = True Then
                    dtpCPOViewDate.Enabled = True
                    .CPODate = dtpCPOViewDate.Value 'Format(Me.dtpCPOViewDate.Value, "MM/dd/yyyy")

                    'dtpCPOViewDate.MinDate = GlobalPPT.FiscalYearFromDate
                    'dtpCPOViewDate.MaxDate = GlobalPPT.FiscalYearToDate
                    'Dim TempDate As Date = dtpCPOViewDate.Value
                    'Dim NowDate As Date = Now()
                    'If Now() >= GlobalPPT.FiscalYearFromDate And dtpCPOViewDate.Value <= GlobalPPT.FiscalYearFromDate Then
                    '    dtpCPOViewDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
                    'End If

                    'Dim ToDate As Date = dtpCPOViewDate.Value
                    'dtpCPOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
                Else
                    dtpCPOViewDate.Enabled = False
                    .CPODate = Nothing
                End If
                ' .TankNo = cmbViewTankNo.Text

                'If .TankNo = "--Select All--" Then
                '    .TankNo = ""
                'Else
                '    .TankNo = cmbViewTankNo.Text
                'End If
            End With
            objCPOPPT.CropYieldID = lCropYieldID
            dt = LoadingCPOBOL.GetCPODetails(objCPOPPT)
            'If dt.TableName.Count <> 0 Then
            If dt.Rows.Count <> 0 Then
                dgvCPOView.AutoGenerateColumns = False
                Me.dgvCPOView.DataSource = dt

                'Dim i As Integer = dgvCPOView.Rows.Count
                'lLoadMonthToDate = dgvCPOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value
                'lTransMonthToDate = dgvCPOView.Rows(i - 1).Cells("gvTransMonthToDate").Value
                'MsgBox(dgvCPOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value)
            Else
                ClearGridView(dgvCPOView) '''''clear the records from grid view
                Exit Sub
            End If
            ' End If

        Catch ex As Exception

        End Try
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
    Private Sub UpdateCPOView()

        If dgvCPOView.Rows.Count > 0 Then

            EditCPOView()
            dtpCPODate.Enabled = False
            'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        Else
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditCPOView()

        Try

            Me.cmsCPO.Visible = False
            Dim objCPOPPT As New LoadingCPOPPT
            Dim objCPOBOL As New LoadingCPOBOL
            Dim dt As New DataTable

            'SaveFlag = False
            'lProductionID = Me.dgvCPOView.SelectedRows(0).Cells("gvProductionID").Value
            'lQtyPrev = Me.dgvCPOView.SelectedRows(0).Cells("QtyToday").Value

            lresetLoad = True
            lresetTrans = True


            'If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    If EditToolStripMenuItem.Enabled = True Or AddToolStripMenuItem.Enabled = True Then
            '        btnSave.Enabled = True
            '    Else
            '         btnSave.Enabled = False 
            '    End If
            'End If

            objCPOPPT.CropYieldID = lCropYieldID
            'objCPOPPT.ProductionID = lProductionID
            Dim str As String = Me.dgvCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()
            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)
            objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)
            'CPOGetMonthYearQty()
            'CPOGetTodayQty()
            'CPOGetLoadTransMonthQty()
            dtpCPODate.Value = objCPOPPT.CPODate
            '''' For Load CPO'''
            dgvLoadCPODetails.AutoGenerateColumns = False
            dtLoadCPOAdd = LoadingCPOBOL.GetCPOAddLoadInfo(objCPOPPT)

            SaveFlag = False
            dgvLoadCPODetails.DataSource = dtLoadCPOAdd
            '        dtpCPODate.Value = objCPOPPT.CPODate


            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            CPOGridViewBind()
            Me.tcLoadingCPO.SelectedTab = tpCPOSave
            btnSave.Enabled = False
            btnDeleteAll.Enabled = False

            'Else
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        ' Dim count As Integer
        ' Dim chkdate As String

        If dgvCPOView.RowCount > 0 Then
            rowid = dgvCPOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then

                'chkdate = dgvCPOView.Rows(0).Cells(0).Value




                Dim objCPOPPT As New LoadingCPOPPT
                Dim objCPOBOL As New LoadingCPOBOL
                Dim str As String = Me.dgvCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                ' Dim dt As Date = DirectCast(TypeDescriptor.GetConverter(New DateTime(1990, 5, 6)).ConvertFrom(str), DateTime)
                'dt.ParseExact("dd/MM/yyyy")
                'dt.CustomFormat = "dd/MM/yyyy"
                'objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                objCPOPPT.CropYieldID = lCropYieldID
                dtpCPODate.Value = objCPOPPT.CPODate

                objEditDuplicateSearchRecord = objCPOBOL.SearchDateCheck(objCPOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objCPOBOL.EditDateCheck(objCPOPPT)

                    If objEditDuplicateRecord = 0 Then

                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateCPOView()
                        btnSave.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateCPOView()
                        btnSave.Enabled = True
                        btnDeleteAll.Enabled = True
                    End If
                Else

                    DisplayInfoMessage("Msg92")
                    '' MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowid = 1
                    UpdateCPOView()
                End If

            Else

                DisplayInfoMessage("Msg92")
                '' MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UpdateCPOView()
            End If

        End If  'UpdateCPOView()
    End Sub
    Public Sub GetTankID(ByVal lTankNo As String)
        Try
            Dim dsLoad As DataSet
            Dim objCPOPPT As New LoadingCPOPPT
            Dim objCPOBOL As New LoadingCPOBOL
            objCPOPPT.TankNo = lTankNo
            dsLoad = LoadingCPOBOL.GetTankID(objCPOPPT)
            If dsLoad.Tables.Count <> 0 Then
                If dsLoad.Tables(0).Rows.Count <> 0 Then
                    lTankID = dsLoad.Tables(0).Rows(0).Item("TankID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub GetLocationID(ByVal lLocation As String)
        Try
            Dim dsLocation As DataSet
            Dim objCPOPPT As New LoadingCPOPPT
            objCPOPPT.Descp = lLocation
            dsLocation = LoadingCPOBOL.GetLocationID(objCPOPPT)
            If dsLocation.Tables.Count <> 0 Then
                If dsLocation.Tables(0).Rows.Count <> 0 Then
                    lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                    lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvCPOView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateCPOView()
            End If
        End If


    End Sub
    Private Sub DeleteCPOVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))

        Me.cmsCPO.Visible = False

        Dim objCPOPPT As New LoadingCPOPPT
        Dim objCPOBOL As New LoadingCPOBOL
        ' Dim dt As New DataTable
        If dgvCPOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim str As String = Me.dgvCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()
                ' objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objCPOPPT.CropYieldID = lCropYieldID
                objCPOBOL.Delete_CPODetail(objCPOPPT)
                CPOGridViewBind()
                'Else
                '    MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvCPOView.RowCount > 0 Then

    
            rowid = dgvCPOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then

                Dim objCPOPPT As New LoadingCPOPPT
                Dim objCPOBOL As New LoadingCPOBOL
                Dim str As String = Me.dgvCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()
                'objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objCPOPPT.CropYieldID = lCropYieldID
                dtpCPODate.Value = objCPOPPT.CPODate

                objDeleteDuplicateSearchRecord = objCPOBOL.SearchDateCheck(objCPOPPT)
                If objDeleteDuplicateSearchRecord = 0 Then
                    objDeleteDuplicateRecord = objCPOBOL.EditDateCheck(objCPOPPT)

                    If objDeleteDuplicateRecord = 1 Then
                        DeleteCPOVIew()
                    Else
                        DisplayInfoMessage("Msg141")
                        ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    DisplayInfoMessage("Msg141")
                    ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'DeleteCPOVIew()
                End If

            Else
                DisplayInfoMessage("Msg141")
                ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If


    End Sub
    Private Sub txtLoadQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadQty.KeyPress

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
    Private Sub txtLoadMonthToDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadMonthToDate.KeyPress
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
    Private Sub txtLoadQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoadQty.KeyDown

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

    Private Sub txtLoadMonthToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoadMonthToDate.KeyDown

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

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()

        ResetLoad()
        GlobalPPT.IsRetainFocus = False
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Reset()
        tcLoadingCPO.SelectedTab = tpCPOSave
        ResetLoad()
    End Sub

    Private Sub cmbLoadTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTank.SelectedIndexChanged

        Dim objCPOBOL As New LoadingCPOBOL

        If cmbLoadTank.SelectedIndex <> 0 Then
            Dim lrow As Integer
            lrow = cmbLoadTank.SelectedIndex
            lLoadCapacity = dsLoadTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString
        End If
        'lTankID = Nothing
        'GetTankID(cmbLoadTank.Text)
        Dim objCPOPPT As New LoadingCPOPPT
        'lLoadTankID = lTankID

        'objCPOPPT.ProductionID = lProdIdNew
        'objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString
        'objCPOPPT.CropYieldID = lCropYieldID
        'If cmbLoadLocation.SelectedIndex > 0 Then
        '    objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'End If

        'objCPOPPT.CPODate = dtpCPODate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty And txtLoadQty.Text <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objCPOBOL.DuplicateLoadLocationFirstCheck(objCPOPPT)
        '    If objCheckDuplicateLoadLocation = 0 Then
        '        txtLoadMonthToDate.Enabled = False
        '    Else
        '        txtLoadMonthToDate.Enabled = True
        '    End If
        'End If

        'Kumar Changed
        If cmbLoadTank.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            'LoadTankMonthtoDate()
        End If




    End Sub

    Private Sub LoadTankMonthtoDate()
        If cmbLoadTank.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsLoadMonthTodate As New DataSet
            txtLoadMonthToDate.Text = ""
            txtLoadQty.Text = ""
            LoadMonthCount = 0

            Dim objCPOPPT As New LoadingCPOPPT
            objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString
            objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpCPODate.Value
            dsLoadMonthTodate = LoadingCPOBOL.CPOGetLoadingCPOMonthtodate(objCPOPPT)

            If dsLoadMonthTodate.Tables(0).Rows.Count <> 0 Then
                lLoadMonthToDate = Val(dsLoadMonthTodate.Tables(0).Rows(0).Item("MonthTodate").ToString)
                LoadMonthCount = dsLoadMonthTodate.Tables(1).Rows(0).Item("LoadMonthCount").ToString
            End If

            If LoadMonthCount = 0 Or (LoadMonthCount = 1 And btnAddLoadFlag = False And SaveFlag = False) Then
                txtLoadMonthToDate.Enabled = True
            Else
                txtLoadMonthToDate.Enabled = False
            End If

        Else
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        End If
    End Sub

    Private Sub cmbLoadLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadLocation.SelectedIndexChanged
       

        If cmbLoadLocation.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            LoadTankMonthtoDate()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))
        'If MsgBox(rm.GetString("Msg31"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '    Me.Close()
        'End If
        If dgvLoadCPODetails.RowCount > 0 And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg31"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
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
        ''If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        ''    Me.Close()
        ''End If
    End Sub

    Private Sub btnViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSearch.Click
        If chkCPODate.Checked = False Then
            DisplayInfoMessage("Msg32")
            ''MsgBox("Please Enter Criteria to Search!")
            CPOGridViewBind()

        Else
            CPOGridViewBind()
            If dgvCPOView.RowCount = 0 Then
                DisplayInfoMessage("Msg33")
                '' MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub

    Private Sub chkCPODate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCPODate.CheckedChanged
        If chkCPODate.Checked = True Then
            dtpCPOViewDate.Enabled = True
        Else
            dtpCPOViewDate.Enabled = False
        End If
    End Sub

    Private Sub dgvCPOView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPOView.CellDoubleClick
       
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
                Exit Sub
            End If
        End If
        If dgvCPOView.RowCount > 0 Then

            If (e.RowIndex = 0) Then

                rowid = e.RowIndex
                Dim objCPOPPT As New LoadingCPOPPT
                Dim objCPOBOL As New LoadingCPOBOL
                Dim str As String = Me.dgvCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                ' objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                objCPOPPT.CropYieldID = lCropYieldID

                dtpCPODate.Value = objCPOPPT.CPODate

                objEditDuplicateSearchRecord = objCPOBOL.SearchDateCheck(objCPOPPT)
                If objEditDuplicateSearchRecord = 0 Then

                    objEditDuplicateRecord = objCPOBOL.EditDateCheck(objCPOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateCPOView()
                        btnSave.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateCPOView()
                        btnSave.Enabled = True
                        btnDeleteAll.Enabled = True
                    End If
                Else
                    DisplayInfoMessage("Msg92")
                    ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowid = 1
                    UpdateCPOView()
                End If

            Else
                DisplayInfoMessage("Msg92")
                ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                rowid = e.RowIndex
                UpdateCPOView()
            End If

        End If


    End Sub

    Private Sub txtLoadQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadQty.Leave
        ' Dim objCPOPPT As New CPOProductionPPT
        'Dim ds As DataSet
        'ds = CPOProductionBOL.CPOGetLoadMonthTodate(objCPOPPT)
        'lLoadMonthToDate = ds.Tables(0).Rows(0).Item("MonthToDate")
        'If txtLoadQty.Text <> "" Then  'And lLoadMonthToDate <> String.Empty Then
        '    txtLoadMonthToDate.Text = txtLoadQty.Text + lLoadMonthToDate
        'End If

        'If cmbLoadTank.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" And txtLoadQty.Text <> "" Then
        '    Dim dsLoadMonthTodate As New DataSet
        '    Dim objCPOPPT As New CPOProductionPPT
        '    objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString
        '    objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        '    objCPOPPT.CropYieldID = lCropYieldID
        '    objCPOPPT.CPODate = dtpCPODate.Value
        '    dsLoadMonthTodate = CPOProductionBOL.CPOGetLoadingCPOMonthtodate(objCPOPPT)
        '    If dsLoadMonthTodate.Tables(0).Rows.Count <> 0 Then
        '        If dsLoadMonthTodate.Tables(0).Rows(0).Item("MonthTodate").ToString = "" Then
        '            txtLoadMonthToDate.Enabled = True
        '            txtLoadMonthToDate.Focus()
        '            Exit Sub
        '        End If
        '    End If

        'End If
        'If lLoadCapacity < Val(txtLoadQty.Text) Then
        '    DisplayInfoMessage("Msg34")
        '    ''MsgBox("Quantity Cant be greater than Storage Capacity")
        '    txtLoadQty.Focus()
        'End If
        If txtLoadQty.Text <> "" Then
            If lLoadMonthToDate = 0 And LoadMonthCount >= 1 Then
                txtLoadMonthToDate.Text = Val(txtLoadQty.Text)
            ElseIf SaveFlag = False And LoadMonthCount <= 1 Then
                txtLoadMonthToDate.Text = lLoadMonthToDate
            ElseIf lLoadMonthToDate > 0 And txtLoadQty.Text <> "" And btnAddLoadFlag = True Then
                txtLoadMonthToDate.Text = lLoadMonthToDate + Val(txtLoadQty.Text)
            ElseIf lLoadMonthToDate > 0 And txtLoadQty.Text <> "" And btnAddLoadFlag = False Then
                txtLoadMonthToDate.Text = lLoadMonthToDate + Val(txtLoadQty.Text) - lLoadQtyPrev
            ElseIf txtLoadMonthToDate.Enabled = False Then
                txtLoadMonthToDate.Text = ""
            End If
        Else
            txtLoadMonthToDate.Text = ""
        End If
    End Sub

    Private Sub SaveLoadCPODetail()
        Try
            Dim intRowcount As Integer = dtLoadCPOAdd.Rows.Count
            Dim objCPOPPT As New LoadingCPOPPT
            Dim objCPOBOL As New LoadingCPOBOL
            If Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpCPODate.Value) Then 'Location, Tank Validation 
                ''Duplicate Date Check ''''
                objCPOPPT.CropYieldID = lCropYieldID


                'Dim objCheckDuplicateLoadLocation As Object = 0

                'objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString


                'objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString

                'objCheckDuplicateLoadLocation = objCPOBOL.DuplicateLoadLocationCheck(objCPOPPT)


                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If


                rowLoadCPOAdd = dtLoadCPOAdd.NewRow()

                If intRowcount = 0 And dtLoadAddFlag = False Then
                    Try

                        columnLoadCPOAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        'columnLoadCPOAdd = New DataColumn("LoadBalanceBF", System.Type.[GetType]("System.String"))
                        'dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("LoadMonthToDate", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("LoadTankID", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("CPOProductionDate", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        columnLoadCPOAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)


                        rowLoadCPOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadCPOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        ' rowLoadCPOAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadCPOAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadCPOAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) ' + Val(txtLoadQty.Text)
                        End If

                        rowLoadCPOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadCPOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                        rowLoadCPOAdd("CPOProductionDate") = dtpCPODate.Value
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowLoadCPOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadCPOAdd.Rows.InsertAt(rowLoadCPOAdd, intRowcount)
                        dtLoadAddFlag = True
                    Catch ex As Exception
                        rowLoadCPOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadCPOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        '   rowLoadCPOAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadCPOAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadCPOAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) '+ Val(txtLoadQty.Text)
                        End If
                        rowLoadCPOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadCPOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                        rowLoadCPOAdd("CPOProductionDate") = dtpCPODate.Value
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowLoadCPOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadCPOAdd.Rows.InsertAt(rowLoadCPOAdd, intRowcount)
                        dtLoadAddFlag = True
                    End Try

                Else

                    rowLoadCPOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    rowLoadCPOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                    '   rowLoadCPOAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowLoadCPOAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowLoadCPOAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) '+ Val(txtLoadQty.Text)
                    End If
                    rowLoadCPOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                    rowLoadCPOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                    rowLoadCPOAdd("CPOProductionDate") = dtpCPODate.Value
                    '''''''''''''''''''''''''''''''''''
                    '''''''''''''For Remarks
                    rowLoadCPOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                    dtLoadCPOAdd.Rows.InsertAt(rowLoadCPOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry this Tank No, Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvLoadCPODetails
                .DataSource = dtLoadCPOAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Function LocationExist(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvLoadCPODetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclLoadStorageNo").Value And Location = objDataGridViewRow.Cells("dgclToLoading").Value) Then
                    'And CPODate = objDataGridViewRow.Cells("dgclCPODateLoad").Value Then
                    ' txtStockCode.Text = ""
                    cmbLoadTank.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try
        'End If
    End Function

    Private Sub UpdateLoadCPODetails()
        Try
            Dim intCount As Integer = dgvLoadCPODetails.CurrentRow.Index

            'If lTempTankNo = cmbStockTank.Text Then
            If lLoadTank = cmbLoadTank.Text And lLoadLocation = cmbLoadLocation.Text Then


                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If

                ' dgvLoadCPODetails.Rows(intCount).Cells("dgclBalanceBF").Value = txtLoadBalanceBF.Text

                If Me.txtLoadQty.Text <> Nothing Then
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
                Else
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
                End If
                If Me.txtLoadMonthToDate.Text <> Nothing Then
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
                Else
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
                End If

                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString

                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

                ''btnAddLoad.Text = "Add"
                btnAddLoadFlag = True
                'clear()

            ElseIf Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpCPODate.Value) Then
                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If
                ' dgvLoadCPODetails.Rows(intCount).Cells("dgclBalanceBF").Value = txtLoadBalanceBF.Text
                If Me.txtLoadQty.Text <> Nothing Then
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
                Else
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
                End If
                If Me.txtLoadMonthToDate.Text <> Nothing Then
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
                Else
                    dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
                End If

                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString
                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BindDgvLoadCPODetails()
        'Try
        If dgvLoadCPODetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddLoad.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddLoad.Text = "Memperbarui"
            End If
            ''Me.btnAddLoad.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"

            

            btnAddLoadFlag = False

            cmbLoadTank.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
            lLoadTank = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
            cmbLoadLocation.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            lLoadLocation = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value Then
                lLoadingLocationID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString()
            Else
                lLoadingLocationID = Nothing
            End If
            If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value Then
                lLoadTankID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageID").Value.ToString()
            Else
                lLoadTankID = Nothing
            End If
            If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is DBNull.Value Then
                lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value
            Else
                lProdLoadingID = Nothing
            End If

            ' txtLoadBalanceBF.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclBalanceBF").Value.ToString()

            If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtLoadQty.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
                lLoadQtyPrev = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
            End If

            If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtLoadMonthToDate.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString()
            End If
            'If LoadMonthCount <= 1 And SaveFlag = False Then
            '    txtLoadMonthToDate.Enabled = True
            'End If
            ' AddFlag = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Remarks Fields Add'''''''''''''''''
            txtLoadRemarks.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadRemarks").Value.ToString()


        End If
        'Catch ex As Exception
        ' End Try
    End Sub

    Private Sub dtpCPODate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCPODate.ValueChanged

        Dim objCPOPPT As New LoadingCPOPPT
        Dim objCPOBOL As New LoadingCPOBOL

        Dim objCheckDuplicateRecord As Object = 0
        objCPOPPT.CPODate = dtpCPODate.Value
        objCPOPPT.CropYieldID = lCropYieldID
        objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

        If objCheckDuplicateRecord = 0 Then

            SaveFlag = True
            'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
            'Exit Sub
        End If
        ' CPOProductionMonthYearSelect()
    End Sub

    Private Sub dgvCPOView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCPOView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateCPOView()
            e.Handled = True
        End If
    End Sub

    Private Sub AddLoad_Clicked()
        Try
            'If lLoadCapacity < lLoadQty Then
            '    DisplayInfoMessage("Msg38")
            '    ''MessageBox.Show("Sum of  Quantity(Mt) should be lesser than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtLoadQty.Focus()
            '    Exit Sub
            'End If


            If btnAddLoadFlag = True Then

                If (IsCheckValidationLoad() = False) Then
                    Exit Sub
                Else
                    SaveLoadCPODetail()
                    ResetLoad()
                End If
            ElseIf btnAddLoadFlag = False Then
                If (IsCheckValidationLoad() = False) Then
                    Exit Sub
                Else
                    UpdateLoadCPODetails()
                    'lblStatus.Text = "OPEN"
                    'clear()
                    ResetLoad()
                    If (rowid = 0) Then
                        If (objEditDuplicateRecord = 0) Then

                            btnDeleteAll.Enabled = False
                            btnSave.Enabled = False
                        Else
                            btnDeleteAll.Enabled = True
                            btnSave.Enabled = True
                        End If

                    Else
                        btnDeleteAll.Enabled = False
                        btnSave.Enabled = False
                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLoad.Click
        LoadQtyCheck()

        'If txtLoadQty.Text = Val(0) Then

        '    MessageBox.Show("Qty should not be Zero", "BSP")
        '    txtLoadQty.Focus()
        '    Exit Sub
        'Else
        AddLoad_Clicked()

        'End If



    End Sub

    Private Sub dgvLoadCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadCPODetails.CellDoubleClick

        BindDgvLoadCPODetails()
    End Sub

    Private Sub btnResetLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetLoad.Click
        ResetLoad()
    End Sub

    Private Sub LoadQtyCheck()
        lLoadQty = 0

        If dgvLoadCPODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvLoadCPODetails.Rows
                If objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclLoadStorageID").Value.ToString = cmbLoadTank.SelectedValue.ToString Then
                    lLoadQty = lLoadQty + Val(objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString())
                End If
            Next
        End If

        lLoadQty = lLoadQty + Val(txtLoadQty.Text) - lLoadQtyPrev


    End Sub

    Private Sub tcLoadingCPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLoadingCPO.SelectedIndexChanged
        'If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    If EditToolStripMenuItem.Enabled = True Or AddToolStripMenuItem.Enabled = True Then
        '        btnSave.Enabled = True
        '    Else
        '        btnSave.Enabled = False
        '    End If
        'End If
        CPOGridViewBind()
    End Sub

    Private Sub tcLoadingCPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLoadingCPO.Click
        'If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    If EditToolStripMenuItem.Enabled = True Or AddToolStripMenuItem.Enabled = True Then
        '        btnSave.Enabled = True
        '    Else
        '        btnSave.Enabled = False
        '    End If
        'End If
        If dgvLoadCPODetails.RowCount > 0 And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcLoadingCPO.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ' ResetMain()
                Reset()
                ResetLoad()
                '  ResetTrans()
                CPOGridViewBind()


            End If
        Else
            'ResetMain()
            Reset()
            ResetLoad()
            ' ResetTrans()
            CPOGridViewBind()


        End If
    End Sub

    Private Sub txtLoadMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadMonthToDate.TextChanged
        If Val(txtLoadMonthToDate.Text) = 0 Then
            txtLoadMonthToDate.Text = ""
        End If
    End Sub

    Private Sub LoadCPOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPOEdit.Click
        BindDgvLoadCPODetails()
    End Sub

    Private Sub LoadCPODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPODelete.Click
        If dgvLoadCPODetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvLoadCPODetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridLoadCPO()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridLoadCPO()

        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is Nothing Then
            lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value.ToString
        Else
            lProdLoadingID = String.Empty
        End If



        lDelete = 0
        If lProdLoadingID <> "" Then
            lDelete = DeleteMultientryLoadCPO.Count
            DeleteMultientryLoadCPO.Insert(lDelete, lProdLoadingID)
        End If
        Dim Dr As DataRow
        Dr = dtLoadCPOAdd.Rows.Item(dgvLoadCPODetails.CurrentRow.Index)
        Dr.Delete()
        dtLoadCPOAdd.AcceptChanges()
        lProdLoadingID = ""


    End Sub

    Private Sub DeleteMultiEntryRecordsLoadingCPO()
        Dim objLoadingCPOPPT As New LoadingCPOPPT

        lDelete = DeleteMultientryLoadCPO.Count

        While (lDelete > 0)

            objLoadingCPOPPT.ProdLoadingID = DeleteMultientryLoadCPO(lDelete - 1)

            Dim IntProdLoadingDelete As New Integer
            IntProdLoadingDelete = LoadingCPOBOL.DeleteMultiEntryProdLoading(objLoadingCPOPPT)
            lDelete = lDelete - 1

        End While



    End Sub



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg24")
                ''MsgBox("No Record in Crop yield for CPO, Please insert the record in General Crop Yield")
                Exit Sub
            End If


            If dgvLoadCPODetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If

                If SaveFlag = True Then

                    Dim objCPOPPT As New LoadingCPOPPT
                    Dim objCPOBOL As New LoadingCPOBOL


                    Dim objCheckDuplicateRecord As Object = 0
                    objCPOPPT.CPODate = dtpCPODate.Value
                    objCPOPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    Else
                        objCompareDateCheck = objCPOBOL.CompareCPOPLoadingDateIsExist(objCPOPPT)
                        If objCompareDateCheck = 0 Then
                            DisplayInfoMessage("Msg26")
                            Exit Sub
                        End If
                    End If
                    ''''For Production CPO''''

                    ' Dim StrCPODate As String
                    Dim dsDetails As New DataSet
                    'CPOGetMonthYearQty()
                    'CPOGetTodayQty()
                    ' CPOGetLoadTransMonthQty()
                    objCPOPPT.CropYieldID = lCropYieldID

                    'objCPOPPT.CPODate = Format(txtDate.Text, "dd/MM/yyyy")
                    objCPOPPT.CPODate = dtpCPODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")


                    For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                        ''''''For Load CPO'''''''''''''
                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objCPOPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                        Else
                            objCPOPPT.LoadTankID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                            objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        Else
                            objCPOPPT.LoadingLocationID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                            objCPOPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objCPOPPT.LoadQty = 0.0
                        End If

                        'If Not DataGridViewRowLoad.Cells("dgclBalanceBF").Value Is DBNull.Value Then
                        '    objCPOPPT.LoadBalanceBF = DataGridViewRowLoad.Cells("dgclBalanceBF").Value
                        'Else
                        '    objCPOPPT.LoadBalanceBF = 0.0
                        'End If
                        If Not DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value Then
                            objCPOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                        Else
                            objCPOPPT.LoadMonthToDate = 0.0
                            'objCPOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        End If
                        objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objCPOPPT.CropYieldID = lCropYieldID

                        LoadingCPOBOL.saveCPOLoadProduction(objCPOPPT)
                    Next




                    CPOGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()
                    ResetLoad()

                    GlobalPPT.IsRetainFocus = False
                    'SaveFlag = False
                Else

                    Dim objCPOPPT As New LoadingCPOPPT
                    Dim objCPOBOL As New LoadingCPOBOL
                    'Dim StrCPODate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvCPODetails.Rows

                    objCPOPPT.CropYieldID = lCropYieldID
                    'CPOGetMonthYearQty()
                    'CPOGetTodayQty()
                    'CPOGetLoadTransMonthQty()

                    'objCPOPPT.CPODate = Format(txtDate.Text, "dd/MM/yyyy")
                    objCPOPPT.CPODate = dtpCPODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    ' objCPOPPT.ProductionID = DataGridViewRowMain.Cells("dgclProductionID").Value.ToString
                    'If DataGridViewRowMain.Cells("dgclProductionID").Value.ToString = String.Empty Then


                    For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                        ''''''For Load CPO'''''''''''''
                        objCPOPPT.ProductionID = lProdIdNew
                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objCPOPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                        Else
                            objCPOPPT.LoadTankID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                            objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        Else
                            objCPOPPT.LoadingLocationID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                            objCPOPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objCPOPPT.LoadQty = 0.0
                        End If

                        'If Not DataGridViewRowLoad.Cells("dgclBalanceBF").Value Is DBNull.Value Then
                        '    objCPOPPT.LoadBalanceBF = DataGridViewRowLoad.Cells("dgclBalanceBF").Value
                        'Else
                        '    objCPOPPT.LoadBalanceBF = 0.0
                        'End If


                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then 'DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value And 
                            Dim lLoadMonthdate As String
                            Dim lLoadQty As String
                            lLoadMonthdate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                            lLoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value.ToString()
                            objCPOPPT.LoadMonthToDate = lLoadMonthdate 'Val(lLoadMonthdate) + Val(lLoadQty)

                            'objCPOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objCPOPPT.LoadMonthToDate = 0.0
                        End If
                        '''''''''''''''''''''''''''''''''''''''
                        ''''For Remarks


                        objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objCPOPPT.CropYieldID = lCropYieldID

                        If Not (DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value) Then
                            objCPOPPT.ProdLoadingID = DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value
                        Else
                            objCPOPPT.ProdLoadingID = String.Empty
                        End If


                        If DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value.ToString = String.Empty Then
                            LoadingCPOBOL.saveCPOLoadProduction(objCPOPPT)
                        Else
                            LoadingCPOBOL.UpdateCPOLoadProduction(objCPOPPT)
                        End If

                    Next



                    DeleteMultiEntryRecordsLoadingCPO()


                    ' CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSave.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSave.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    CPOGridViewBind()
                    Reset()

                    ResetLoad()

                    SaveFlag = True

                End If
                ClearGridView(dgvLoadCPODetails)
                GlobalPPT.IsRetainFocus = False
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objCPOPPT As New LoadingCPOPPT
            Dim objCPOBOL As New LoadingCPOBOL

            objCPOPPT.CPODate = dtpCPODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOBOL.Delete_CPODetail(objCPOPPT)
            CPOGridViewBind()
        End Try
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objCPOPPT As New LoadingCPOPPT
        Dim objCPOBOL As New LoadingCPOBOL
        If dgvCPOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ' If lProductionID <> String.Empty Then
                objCPOPPT.CPODate = dtpCPODate.Value
                objCPOPPT.CropYieldID = lCropYieldID
                objCPOBOL.Delete_CPODetail(objCPOPPT)
                CPOGridViewBind()
            End If
        End If


        Reset()

        ResetLoad()

    End Sub

   
    Private Sub dtpCPOViewDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCPOViewDate.ValueChanged

    End Sub
End Class