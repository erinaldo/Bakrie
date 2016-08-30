Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class TransferKernelFrm

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
    Dim dsKernelTransferStorage As DataSet
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


    ''Load Kernel'''
    Public btnAddLoadFlag As Boolean = True
    Dim columnLoadKernelAdd As DataColumn
    Dim rowLoadKernelAdd As DataRow
    Dim dtLoadKernelAdd As New DataTable("todgvLoadKernelAdd")
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
    Dim DeleteMultientryStockKernel As New ArrayList
    Dim DeleteMultientryLoadKernel As New ArrayList
    Dim DeleteMultientryTransKernel As New ArrayList
    Dim lDelete As Integer
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TransferKernelFrm))

    Private Sub TransferKernelFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dgvLoadKernelDetails.RowCount > 0 And btnSave.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M423"

            End If
        End If
    End Sub

    Private Sub TransferKernelFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TransferKernelFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)


        'edit by suraya 12-09-12
        'dtpKernelDate.MinDate = GlobalPPT.FiscalYearFromDate
        'dtpKernelDate.MaxDate = GlobalPPT.FiscalYearToDate

        'Dim TempDate As Date = dtpKernelDate.Value
        'Dim NowDate As Date = Now()
        'If Now() >= GlobalPPT.FiscalYearFromDate And dtpKernelDate.Value <= GlobalPPT.FiscalYearFromDate Then
        '    dtpKernelDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        'End If

        'Dim ToDate As Date = dtpKernelDate.Value
        'dtpKernelDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        dtpKernelDate.Format = DateTimePickerFormat.Custom
        dtpKernelDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpKernelDate)

        dtpKernelViewDate.Format = DateTimePickerFormat.Custom
        dtpKernelViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpKernelViewDate)

        Dim objKernelPPT As New TransferKernelPPT
        Dim dsCrop As New DataSet

        dsCrop = TransferKernelBOL.ProductionCropYieldIDSelect(objKernelPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for Kernel, Please insert the record in General Crop Yield")
        End If
        tcLoadingKernel.SelectedTab = tpKernelView

        loadCmbStorage()
        loadCmbLocation()

        dtpKernelViewDate.Enabled = False
        lCropYieldCode = "Kernel"

        GetCropYieldID()
        objKernelPPT.CropYieldID = lCropYieldID
        ResetMain()
        Reset()

        KernelGridViewBind()
        dtpKernelDate.Focus()
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tcLoadingKernel.TabPages("tpKernelSave").Text = rm.GetString("TransferKernal")
            'tcLoadingKernel.TabPages("tpKernelView").Text = rm.GetString("ttcLoadingKernel.TabPages(tpKernelView).Text")

            'chkKernelDate.Text = rm.GetString("Date")
            'grpLoadKernel.Text = rm.GetString("TransferKernal")

            'grpLoadKernelRecords.Text = rm.GetString("TransferKernelRecords")
            'PnlSearch.CaptionText = rm.GetString("SearchTransferKernel")





            'dgvLoadKernelDetails.Columns("dgclLoadStorageNo").HeaderText = rm.GetString("Storage")
            'dgvLoadKernelDetails.Columns("dgclToLoading").HeaderText = rm.GetString("To Loading")

            'dgvLoadKernelDetails.Columns("dgclLoadQuantity").HeaderText = rm.GetString("Quantity")
            'dgvLoadKernelDetails.Columns("dgclLoadMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvLoadKernelDetails.Columns("dgclLoadRemarks").HeaderText = rm.GetString("Remarks")



            btnSave.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddLoad.Text = rm.GetString("Add")
            btnResetLoad.Text = rm.GetString("Reset")


            'dgvKernelView.Columns("gvKernelDate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")


        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernelProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub KernelGetLoadTransMonthQty()
        Try
            Dim objKernelPPT As New TransferKernelPPT
            Dim dsTransLoad As DataSet
            objKernelPPT.CropYieldID = lCropYieldID
            objKernelPPT.KernelDate = dtpKernelDate.Value
            dsTransLoad = TransferKernelBOL.KernelGetLoadTransMonthQty(objKernelPPT)
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
        'Try

        '    dsLoadTankNo = TransferKernelBOL.loadCmbStorage("Kernel")

        '    'For Load Tank

        '    Dim dr1 As DataRow = dsLoadTankNo.Tables(0).NewRow()
        '    dr1(0) = "--Select--"
        '    dr1(1) = "--Select--"
        '    dsLoadTankNo.Tables(0).Rows.InsertAt(dr1, 0)

        '    'Load Kernel
        '    cmbLoadTank.DataSource = dsLoadTankNo.Tables(0)
        '    cmbLoadTank.DisplayMember = "TankNo"
        '    cmbLoadTank.ValueMember = "TankID"

        'Catch ex As Exception
        '    DisplayInfoMessage("Msg3")
        '    ''MessageBox.Show("There is No Tank for This Estate") 'ex.Message)
        'End Try

        dsKernelTransferStorage = TransferKernelBOL.loadCmbKernalCodeDesc()

        'dsKernelTransferStorage = KernalProductionBOL.loadCmbKernalCodeDesc()

        Dim dr1 As DataRow = dsKernelTransferStorage.Tables(0).NewRow()
        dr1(4) = "--Select--"
        'dr(1) = "--Select--"
        dsKernelTransferStorage.Tables(0).Rows.InsertAt(dr1, 0)

        'Load CPO
        cmbLoadTank.DataSource = dsKernelTransferStorage.Tables(0)
        cmbLoadTank.DisplayMember = "Storage"
        cmbLoadTank.ValueMember = "KernelStorageID"



    End Sub

    Private Sub loadCmbLocation()
        Try
            cmbLoadLocation.DataSource = Nothing
            Dim dsLoadLocation As DataSet
            dsLoadLocation = TransferKernelBOL.loadCmbLocation()
            'Location Kernel Combo
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
            Dim objKernelPPT As New TransferKernelPPT
            objKernelPPT.CropYieldCode = lCropYieldCode
            If objKernelPPT.CropYieldCode <> String.Empty Then
                dsCrop = TransferKernelBOL.GetCropYieldID(objKernelPPT)
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
            Dim objKernelPPT As New TransferKernelPPT
            objKernelPPT.TankID = lTankID
            If objKernelPPT.TankID <> String.Empty Then
                dsCropID = TransferKernelBOL.GetCropYield(objKernelPPT)
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
        ''''For Stock Kernel

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
        ' KernelGetLoadTransMonthQty()
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
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Public Sub Reset()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernelDate)
        'FormatDateTimePicker(dtpKernelDate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernelViewDate)
        'FormatDateTimePicker(dtpKernelViewDate)
        dtpKernelDate.Enabled = True
        'For Load Kernel

        'cmbLoadTank.Text = "Select All"
        cmbLoadLocation.Text = ""
        ' txtLoadBalanceBF.Text = ""
        txtLoadQty.Text = ""
        txtLoadMonthToDate.Text = ""

        '''' For Trans Kernel
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
        dtpKernelViewDate.Enabled = False
        chkKernelDate.Checked = False

        '''''For Production Kernel
        'Dim ToDate As Date = Date.Today
        'dtpKernelDate.Value = ToDate
        'dtpKernelViewDate.Value = Date.Today
        'dtpKernelDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpKernelDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpKernelViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpKernelViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        ClearGridView(dgvLoadKernelDetails)

        DeleteMultientryLoadKernel.Clear()

        'KernelGetTodayQty()
        'KernelGetMonthYearQty()
        'KernelGetLoadTransMonthQty()
        'UpdateTankMasterBFQty()

        '''''''For Very First Time Entry for MonthTodate , YearTodate'''''''''



        If dgvKernelView.Rows.Count > 0 Then
            ''''For Loading Kernel'''''''
            txtLoadMonthToDate.Enabled = False

        Else
            ''''For Loading Kernel'''''''
            txtLoadMonthToDate.Enabled = True
        End If

        btnSave.Enabled = True
        btnDeleteAll.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub KernelGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objKernelPPT As New TransferKernelPPT
            objKernelPPT.KernelDate = dtpKernelDate.Value
            'loadCmbStorage()
            With objKernelPPT
                If chkKernelDate.Checked = True Then
                    dtpKernelViewDate.Enabled = True
                    .KernelDate = dtpKernelViewDate.Value 'Format(Me.dtpKernelViewDate.Value, "MM/dd/yyyy")

                    dtpKernelViewDate.MinDate = GlobalPPT.FiscalYearFromDate
                    dtpKernelViewDate.MaxDate = GlobalPPT.FiscalYearToDate
                    Dim TempDate As Date = dtpKernelViewDate.Value
                    Dim NowDate As Date = Now()
                    If Now() >= GlobalPPT.FiscalYearFromDate And dtpKernelViewDate.Value <= GlobalPPT.FiscalYearFromDate Then
                        dtpKernelViewDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
                    End If

                    Dim ToDate As Date = dtpKernelViewDate.Value
                    dtpKernelViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

                Else
                    dtpKernelViewDate.Enabled = False
                    .KernelDate = Nothing
                End If
                ' .TankNo = cmbViewTankNo.Text

                'If .TankNo = "--Select All--" Then
                '    .TankNo = ""
                'Else
                '    .TankNo = cmbViewTankNo.Text
                'End If
            End With
            objKernelPPT.CropYieldID = lCropYieldID
            dt = TransferKernelBOL.GetKernelDetails(objKernelPPT)
            'If dt.TableName.Count <> 0 Then
            If dt.Rows.Count <> 0 Then
                dgvKernelView.AutoGenerateColumns = False
                Me.dgvKernelView.DataSource = dt

                'Dim i As Integer = dgvKernelView.Rows.Count
                'lLoadMonthToDate = dgvKernelView.Rows(i - 1).Cells("gvLoadMonthToDate").Value
                'lTransMonthToDate = dgvKernelView.Rows(i - 1).Cells("gvTransMonthToDate").Value
                'MsgBox(dgvKernelView.Rows(i - 1).Cells("gvLoadMonthToDate").Value)
            Else
                ClearGridView(dgvKernelView) '''''clear the records from grid view
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
    Private Sub UpdateKernelView()

        If dgvKernelView.Rows.Count > 0 Then

            EditKernelView()
            dtpKernelDate.Enabled = False



            'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        Else
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditKernelView()

        Try

            Me.cmsKernel.Visible = False
            Dim objKernelPPT As New TransferKernelPPT
            Dim objKernelBOL As New TransferKernelBOL
            Dim dt As New DataTable

            If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSave.Enabled = True
                End If
            End If


            lresetLoad = True
            lresetTrans = True

            objKernelPPT.CropYieldID = lCropYieldID
            'objKernelPPT.ProductionID = lProductionID
            Dim str As String = Me.dgvKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

            'objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)
            objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)



            dtpKernelDate.Value = objKernelPPT.KernelDate
            'KernelGetMonthYearQty()
            'KernelGetTodayQty()
            'KernelGetLoadTransMonthQty()




            '''' For Load Kernel'''
            dgvLoadKernelDetails.AutoGenerateColumns = False
            dtLoadKernelAdd = TransferKernelBOL.GetKernelAddLoadInfo(objKernelPPT)

            SaveFlag = False
            dgvLoadKernelDetails.DataSource = dtLoadKernelAdd
            '        dtpKernelDate.Value = objKernelPPT.KernelDate



            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            KernelGridViewBind()
            Me.tcLoadingKernel.SelectedTab = tpKernelSave
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
        If dgvKernelView.RowCount > 0 Then

            rowid = dgvKernelView.SelectedRows.Item(0).Index()

            If (rowid = 0) Then

                Dim objKernelPPT As New TransferKernelPPT
                Dim objKernelBOL As New TransferKernelBOL
                Dim str As String = Me.dgvKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                'objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)



                objKernelPPT.CropYieldID = lCropYieldID
                dtpKernelDate.Value = objKernelPPT.KernelDate

                objEditDuplicateSearchRecord = objKernelBOL.SearchDateCheck(objKernelPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objKernelBOL.EditDateCheck(objKernelPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateKernelView()
                        btnSave.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateKernelView()
                        btnSave.Enabled = True
                        btnDeleteAll.Enabled = True
                    End If

                Else
                    DisplayInfoMessage("Msg92")
                    ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowid = 1
                    UpdateKernelView()
                End If
            Else
                DisplayInfoMessage("Msg92")
                ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UpdateKernelView()
            End If
        End If

    End Sub
    Public Sub GetTankID(ByVal lTankNo As String)
        Try
            Dim dsLoad As DataSet
            Dim objKernelPPT As New TransferKernelPPT
            Dim objKernelBOL As New TransferKernelBOL
            objKernelPPT.TankNo = lTankNo
            dsLoad = TransferKernelBOL.GetTankID(objKernelPPT)
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
            Dim objKernelPPT As New TransferKernelPPT
            objKernelPPT.Descp = lLocation
            dsLocation = TransferKernelBOL.GetLocationID(objKernelPPT)
            If dsLocation.Tables.Count <> 0 Then
                If dsLocation.Tables(0).Rows.Count <> 0 Then
                    lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                    lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvKernelView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateKernelView()
            End If
        End If


    End Sub
    Private Sub DeleteKernelVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernelProductionFrm))

        Me.cmsKernel.Visible = False

        Dim objKernelPPT As New TransferKernelPPT
        Dim objKernelBOL As New TransferKernelBOL
        ' Dim dt As New DataTable
        If dgvKernelView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim str As String = Me.dgvKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                '                objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objKernelPPT.CropYieldID = lCropYieldID
                objKernelBOL.Delete_KernelDetail(objKernelPPT)
                KernelGridViewBind()
                'Else
                '    MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvKernelView.RowCount > 0 Then


            rowid = dgvKernelView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objKernelPPT As New TransferKernelPPT
                Dim objKernelBOL As New TransferKernelBOL
                Dim str As String = Me.dgvKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                '            objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objKernelPPT.CropYieldID = lCropYieldID
                dtpKernelDate.Value = objKernelPPT.KernelDate

                objDeleteDuplicateSearchRecord = objKernelBOL.SearchDateCheck(objKernelPPT)
                If objDeleteDuplicateSearchRecord = 0 Then
                    objDeleteDuplicateRecord = objKernelBOL.EditDateCheck(objKernelPPT)

                    If objDeleteDuplicateRecord = 1 Then
                        DeleteKernelVIew()
                    Else
                        DisplayInfoMessage("Msg141")
                        ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    DisplayInfoMessage("Msg141")
                    ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Else
                DisplayInfoMessage("Msg141")
                ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ' DeleteKernelVIew()
        End If
    End Sub
    Private Sub txtLoadQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadQty.KeyPress

        If isModifierKey Then
            e.Handled = True
            Return
        End If
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
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
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            isDecimal = False
                            Return
                        End If

                        isDecimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
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
        tcLoadingKernel.SelectedTab = tpKernelSave
        ResetLoad()
    End Sub

    Private Sub cmbLoadTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTank.SelectedIndexChanged

        Dim objKernelBOL As New TransferKernelBOL

        If cmbLoadTank.SelectedIndex <> 0 Then
            Dim lrow As Integer
            lrow = cmbLoadTank.SelectedIndex
            lLoadCapacity = dsKernelTransferStorage.Tables(0).Rows(lrow).Item("Capacity").ToString
        End If
        'lTankID = Nothing
        'GetTankID(cmbLoadTank.Text)
        Dim objKernelPPT As New TransferKernelPPT
        'lLoadTankID = lTankID

        'objKernelPPT.ProductionID = lProdIdNew
        'objKernelPPT.TankID = cmbLoadTank.SelectedValue.ToString
        'objKernelPPT.CropYieldID = lCropYieldID
        'If cmbLoadLocation.SelectedIndex > 0 Then
        '    objKernelPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'End If

        'objKernelPPT.KernelDate = dtpKernelDate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty And txtLoadQty.Text <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objKernelBOL.DuplicateLoadLocationFirstCheck(objKernelPPT)
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

            Dim objKernelPPT As New TransferKernelPPT
            objKernelPPT.TankID = cmbLoadTank.SelectedValue.ToString
            objKernelPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
            objKernelPPT.CropYieldID = lCropYieldID
            objKernelPPT.KernelDate = dtpKernelDate.Value
            dsLoadMonthTodate = TransferKernelBOL.KernelGetLoadingKernelMonthtodate(objKernelPPT)

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
        'Try
        'Dim objKernelBOL As New KernelProductionBOL
        'lLocationID = Nothing
        'GetLocationID(cmbLoadLocation.Text)
        'Dim objKernelPPT As New KernelProductionPPT
        'lLoadLocationID = lLocationID
        ''n.Text = lLocationDesc
        'objKernelPPT.KernelDate = dtpKernelDate.Value
        'objKernelPPT.ProductionID = lProdIdNew
        'objKernelPPT.TankID = cmbLoadLocation.SelectedValue.ToString
        'objKernelPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'objKernelPPT.CropYieldID = lCropYieldID

        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
        '        Dim objCheckDuplicateLoadLocation As Object = 0
        '        objCheckDuplicateLoadLocation = objKernelBOL.DuplicateLoadLocationFirstCheck(objKernelPPT)
        '        If objCheckDuplicateLoadLocation = 0 Then
        '            txtLoadMonthToDate.Enabled = False
        '        Else
        '            txtLoadMonthToDate.Enabled = True
        '        End If
        '    End If


        '    ''''Month Qty Value '''''''''''''''

        '    Dim dsCrop As New DataSet


        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
        '        dsCrop = KernelProductionBOL.KernelGetLoadVsLocMonthQty(objKernelPPT)
        '        If dsCrop.Tables.Count <> 0 Then
        '            If dsCrop.Tables(0).Rows.Count <> 0 Then
        '                lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("Qty")
        '                txtLoadMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("Qty")
        '            Else
        '                txtLoadMonthToDate.Text = "0"
        '            End If
        '        End If
        '    Else
        '        txtLoadMonthToDate.Text = "0"
        '    End If


        'Catch ex As Exception
        'End Try

        If cmbLoadLocation.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            LoadTankMonthtoDate()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If dgvLoadKernelDetails.RowCount > 0 And btnSave.Enabled = True Then
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
    End Sub

    Private Sub btnViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSearch.Click
        If chkKernelDate.Checked = False Then
            DisplayInfoMessage("Msg32")
            ''MsgBox("Please Enter Criteria to Search!")
            KernelGridViewBind()
        Else
            KernelGridViewBind()
            If dgvKernelView.RowCount = 0 Then
                DisplayInfoMessage("Msg33")
                '' MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub

    Private Sub chkKernelDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKernelDate.CheckedChanged
        If chkKernelDate.Checked = True Then
            dtpKernelViewDate.Enabled = True
        Else
            dtpKernelViewDate.Enabled = False
        End If
    End Sub

    Private Sub dgvKernelView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelView.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
                Exit Sub
            End If
        End If
        If dgvKernelView.RowCount > 0 Then


            If (e.RowIndex = 0) Then

                rowid = e.RowIndex
                Dim objKernelPPT As New TransferKernelPPT
                Dim objKernelBOL As New TransferKernelBOL
                Dim str As String = Me.dgvKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                '            objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))


                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objKernelPPT.CropYieldID = lCropYieldID
                dtpKernelDate.Value = objKernelPPT.KernelDate

                objEditDuplicateSearchRecord = objKernelBOL.SearchDateCheck(objKernelPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objKernelBOL.EditDateCheck(objKernelPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateKernelView()
                        btnSave.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateKernelView()
                        btnSave.Enabled = True
                        btnDeleteAll.Enabled = True
                    End If
                Else
                    DisplayInfoMessage("Msg92")
                    ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowid = 1
                    UpdateKernelView()
                End If
            Else
                DisplayInfoMessage("Msg92")
                ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                rowid = e.RowIndex
                UpdateKernelView()
            End If

        End If



    End Sub

    Private Sub txtLoadQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadQty.Leave
        ' Dim objKernelPPT As New KernelProductionPPT
        'Dim ds As DataSet
        'ds = KernelProductionBOL.KernelGetLoadMonthTodate(objKernelPPT)
        'lLoadMonthToDate = ds.Tables(0).Rows(0).Item("MonthToDate")
        'If txtLoadQty.Text <> "" Then  'And lLoadMonthToDate <> String.Empty Then
        '    txtLoadMonthToDate.Text = txtLoadQty.Text + lLoadMonthToDate
        'End If

        'If cmbLoadTank.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" And txtLoadQty.Text <> "" Then
        '    Dim dsLoadMonthTodate As New DataSet
        '    Dim objKernelPPT As New KernelProductionPPT
        '    objKernelPPT.TankID = cmbLoadTank.SelectedValue.ToString
        '    objKernelPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        '    objKernelPPT.CropYieldID = lCropYieldID
        '    objKernelPPT.KernelDate = dtpKernelDate.Value
        '    dsLoadMonthTodate = KernelProductionBOL.KernelGetLoadingKernelMonthtodate(objKernelPPT)
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

    Private Sub SaveLoadKernelDetail()
        Try
            Dim intRowcount As Integer = dtLoadKernelAdd.Rows.Count
            Dim objKernelPPT As New TransferKernelPPT
            Dim objKernelBOL As New TransferKernelBOL
            If Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpKernelDate.Value) Then 'Location, Tank Validation 
                ''Duplicate Date Check ''''
                objKernelPPT.CropYieldID = lCropYieldID


                'Dim objCheckDuplicateLoadLocation As Object = 0

                'objKernelPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString


                'objKernelPPT.TankID = cmbLoadTank.SelectedValue.ToString

                'objCheckDuplicateLoadLocation = objKernelBOL.DuplicateLoadLocationCheck(objKernelPPT)


                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If


                rowLoadKernelAdd = dtLoadKernelAdd.NewRow()

                If intRowcount = 0 And dtLoadAddFlag = False Then
                    Try

                        columnLoadKernelAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        columnLoadKernelAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        'columnLoadKernelAdd = New DataColumn("LoadBalanceBF", System.Type.[GetType]("System.String"))
                        'dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        columnLoadKernelAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        columnLoadKernelAdd = New DataColumn("LoadMonthToDate", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        columnLoadKernelAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        columnLoadKernelAdd = New DataColumn("LoadTankID", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        'columnLoadKernelAdd = New DataColumn("KernelProductionDate", System.Type.[GetType]("System.String"))
                        'dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        columnLoadKernelAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                        dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)


                        rowLoadKernelAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadKernelAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        ' rowLoadKernelAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadKernelAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadKernelAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) ' + Val(txtLoadQty.Text)
                        End If

                        rowLoadKernelAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadKernelAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                        'rowLoadKernelAdd("KernelProductionDate") = dtpKernelDate.Value
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowLoadKernelAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)
                        dtLoadAddFlag = True
                    Catch ex As Exception
                        rowLoadKernelAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadKernelAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        '   rowLoadKernelAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadKernelAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadKernelAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) '+ Val(txtLoadQty.Text)
                        End If
                        rowLoadKernelAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadKernelAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                        'rowLoadKernelAdd("KernelProductionDate") = dtpKernelDate.Value
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowLoadKernelAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)
                        dtLoadAddFlag = True
                    End Try

                Else

                    rowLoadKernelAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    rowLoadKernelAdd("LoadLocation") = Me.cmbLoadLocation.Text

                    '   rowLoadKernelAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowLoadKernelAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowLoadKernelAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) '+ Val(txtLoadQty.Text)
                    End If
                    rowLoadKernelAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                    rowLoadKernelAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                    'rowLoadKernelAdd("KernelProductionDate") = dtpKernelDate.Value
                    '''''''''''''''''''''''''''''''''''
                    '''''''''''''For Remarks
                    rowLoadKernelAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                    dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry this Tank No, Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvLoadKernelDetails
                .DataSource = dtLoadKernelAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Function LocationExist(ByVal Location As String, ByVal TankNo As String, ByVal KernelDate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvLoadKernelDetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclLoadStorageNo").Value And Location = objDataGridViewRow.Cells("dgclToLoading").Value) Then
                    'And KernelDate = objDataGridViewRow.Cells("dgclKernelDateLoad").Value Then
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

    Private Sub UpdateLoadKernelDetails()
        Try
            Dim intCount As Integer = dgvLoadKernelDetails.CurrentRow.Index

            'If lTempTankNo = cmbStockTank.Text Then
            If lLoadTank = cmbLoadTank.Text And lLoadLocation = cmbLoadLocation.Text Then


                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadKernelDetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If

                ' dgvLoadKernelDetails.Rows(intCount).Cells("dgclBalanceBF").Value = txtLoadBalanceBF.Text

                If Me.txtLoadQty.Text <> Nothing Then
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
                Else
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
                End If
                If Me.txtLoadMonthToDate.Text <> Nothing Then
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
                Else
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
                End If

                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString

                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

                ''btnAddLoad.Text = "Add"
                btnAddLoadFlag = True
                'clear()

            ElseIf Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpKernelDate.Value) Then
                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadKernelDetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If
                ' dgvLoadKernelDetails.Rows(intCount).Cells("dgclBalanceBF").Value = txtLoadBalanceBF.Text
                If Me.txtLoadQty.Text <> Nothing Then
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
                Else
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
                End If
                If Me.txtLoadMonthToDate.Text <> Nothing Then
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
                Else
                    dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
                End If

                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString
                dgvLoadKernelDetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BindDgvLoadKernelDetails()
        'Try
        If dgvLoadKernelDetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddLoad.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddLoad.Text = "Memperbarui"
            End If
            ''Me.btnAddLoad.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddLoadFlag = False

            cmbLoadTank.Text = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()

            lLoadTank = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
            cmbLoadLocation.Text = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            lLoadLocation = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()


            If Not dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value Then
                lLoadingLocationID = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString()
            Else
                lLoadingLocationID = Nothing
            End If
            If Not dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value Then
                lLoadTankID = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadStorageID").Value.ToString()
            Else
                lLoadTankID = Nothing
            End If
            If Not dgvLoadKernelDetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is DBNull.Value Then
                lProdLoadingID = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value
            Else
                lProdLoadingID = Nothing
            End If

            ' txtLoadBalanceBF.Text = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclBalanceBF").Value.ToString()

            If Not dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtLoadQty.Text = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
                lLoadQtyPrev = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
            End If

            If Not dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtLoadMonthToDate.Text = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString()
            End If
            'If LoadMonthCount <= 1 And SaveFlag = False Then
            '    txtLoadMonthToDate.Enabled = True
            'End If
            ' AddFlag = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Remarks Fields Add'''''''''''''''''
            txtLoadRemarks.Text = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclLoadRemarks").Value.ToString()


        End If
        'Catch ex As Exception
        ' End Try
    End Sub

    Private Sub dtpKernelDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpKernelDate.ValueChanged

        Dim objKernelPPT As New TransferKernelPPT
        Dim objKernelBOL As New TransferKernelBOL

        Dim objCheckDuplicateRecord As Object = 0
        objKernelPPT.KernelDate = dtpKernelDate.Value
        objKernelPPT.CropYieldID = lCropYieldID
        objCheckDuplicateRecord = objKernelBOL.DuplicateDateCheck(objKernelPPT)

        If objCheckDuplicateRecord = 0 Then
            SaveFlag = True
            'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
            'Exit Sub
        End If
        ' KernelProductionMonthYearSelect()
    End Sub

    Private Sub dgvKernelView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvKernelView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateKernelView()
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
                    SaveLoadKernelDetail()
                    ResetLoad()
                End If
            ElseIf btnAddLoadFlag = False Then
                If (IsCheckValidationLoad() = False) Then
                    Exit Sub
                Else
                    UpdateLoadKernelDetails()
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
       
        AddLoad_Clicked()





    End Sub

    Private Sub dgvLoadKernelDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadKernelDetails.CellDoubleClick

        BindDgvLoadKernelDetails()
    End Sub

    Private Sub btnResetLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetLoad.Click
        ResetLoad()
    End Sub

    Private Sub LoadQtyCheck()
        lLoadQty = 0

        If dgvLoadKernelDetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvLoadKernelDetails.Rows
                If objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclLoadStorageID").Value.ToString = cmbLoadTank.SelectedValue.ToString Then
                    lLoadQty = lLoadQty + Val(objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString())
                End If
            Next
        End If

        lLoadQty = lLoadQty + Val(txtLoadQty.Text) - lLoadQtyPrev


    End Sub

    Private Sub tcLoadingKernel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLoadingKernel.SelectedIndexChanged
        'ResetMain()
        'Reset()
        'ResetLoad()
        'ResetTrans()
        KernelGridViewBind()
    End Sub

    Private Sub tcLoadingKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLoadingKernel.Click

        If dgvLoadKernelDetails.RowCount > 0 And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcLoadingKernel.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ' ResetMain()
                Reset()
                ResetLoad()
                '  ResetTrans()
                KernelGridViewBind()


            End If
        Else
            'ResetMain()
            Reset()
            ResetLoad()
            ' ResetTrans()
            KernelGridViewBind()


        End If
    End Sub

    Private Sub txtLoadMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadMonthToDate.TextChanged
        If Val(txtLoadMonthToDate.Text) = 0 Then
            txtLoadMonthToDate.Text = ""
        End If
    End Sub

    Private Sub LoadKernelEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPOEdit.Click
        BindDgvLoadKernelDetails()
    End Sub

    Private Sub LoadKernelDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPODelete.Click
        If dgvLoadKernelDetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvLoadKernelDetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridLoadKernel()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridLoadKernel()

        If Not dgvLoadKernelDetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is Nothing Then
            lProdLoadingID = dgvLoadKernelDetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value.ToString
        Else
            lProdLoadingID = String.Empty
        End If



        lDelete = 0
        If lProdLoadingID <> "" Then
            lDelete = DeleteMultientryLoadKernel.Count
            DeleteMultientryLoadKernel.Insert(lDelete, lProdLoadingID)
        End If
        Dim Dr As DataRow
        Dr = dtLoadKernelAdd.Rows.Item(dgvLoadKernelDetails.CurrentRow.Index)
        Dr.Delete()
        dtLoadKernelAdd.AcceptChanges()
        lProdLoadingID = ""


    End Sub

    Private Sub DeleteMultiEntryRecordsLoadingKernel()
        Dim objTransferKernelPPT As New TransferKernelPPT

        lDelete = DeleteMultientryLoadKernel.Count

        While (lDelete > 0)

            objTransferKernelPPT.ProdLoadingID = DeleteMultientryLoadKernel(lDelete - 1)

            Dim IntProdLoadingDelete As New Integer
            IntProdLoadingDelete = TransferKernelBOL.DeleteMultiEntryProdLoading(objTransferKernelPPT)
            lDelete = lDelete - 1

        End While



    End Sub



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg24")
                ''MsgBox("No Record in Crop yield for Kernel, Please insert the record in General Crop Yield")
                Exit Sub
            End If


            If dgvLoadKernelDetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If

                If SaveFlag = True Then

                    Dim objKernelPPT As New TransferKernelPPT
                    Dim objKernelBOL As New TransferKernelBOL


                    Dim objCheckDuplicateRecord As Object = 0
                    objKernelPPT.KernelDate = dtpKernelDate.Value
                    objKernelPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objKernelBOL.DuplicateDateCheck(objKernelPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    Else
                        objCompareDateCheck = objKernelBOL.CompareCPOPLoadingDateIsExist(objKernelPPT)
                        If objCompareDateCheck = 0 Then
                            DisplayInfoMessage("Msg26")
                            Exit Sub
                        End If
                    End If
                    ''''For Production Kernel''''

                    ' Dim StrKernelDate As String
                    Dim dsDetails As New DataSet
                    'KernelGetMonthYearQty()
                    'KernelGetTodayQty()
                    ' KernelGetLoadTransMonthQty()
                    objKernelPPT.CropYieldID = lCropYieldID

                    'objKernelPPT.KernelDate = Format(txtDate.Text, "dd/MM/yyyy")
                    objKernelPPT.KernelDate = dtpKernelDate.Value 'Format(dtpKernelDate.Value, "MM/dd/yyyy")


                    For Each DataGridViewRowLoad In dgvLoadKernelDetails.Rows

                        ''''''For Load Kernel'''''''''''''
                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objKernelPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                        Else
                            objKernelPPT.LoadTankID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                            objKernelPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        Else
                            objKernelPPT.LoadingLocationID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                            objKernelPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objKernelPPT.LoadQty = 0.0
                        End If

                        'If Not DataGridViewRowLoad.Cells("dgclBalanceBF").Value Is DBNull.Value Then
                        '    objKernelPPT.LoadBalanceBF = DataGridViewRowLoad.Cells("dgclBalanceBF").Value
                        'Else
                        '    objKernelPPT.LoadBalanceBF = 0.0
                        'End If
                        If Not DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value Then
                            objKernelPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                        Else
                            objKernelPPT.LoadMonthToDate = 0.0
                            'objKernelPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        End If
                        objKernelPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objKernelPPT.CropYieldID = lCropYieldID

                        TransferKernelBOL.saveKernelLoadProduction(objKernelPPT)
                    Next




                    KernelGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()
                    ResetLoad()


                    'SaveFlag = False
                Else

                    Dim objKernelPPT As New TransferKernelPPT
                    Dim objKernelBOL As New TransferKernelBOL
                    'Dim StrKernelDate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvKernelDetails.Rows

                    objKernelPPT.CropYieldID = lCropYieldID
                    'KernelGetMonthYearQty()
                    'KernelGetTodayQty()
                    'KernelGetLoadTransMonthQty()

                    'objKernelPPT.KernelDate = Format(txtDate.Text, "dd/MM/yyyy")
                    objKernelPPT.KernelDate = dtpKernelDate.Value 'Format(dtpKernelDate.Value, "MM/dd/yyyy")
                    ' objKernelPPT.ProductionID = DataGridViewRowMain.Cells("dgclProductionID").Value.ToString
                    'If DataGridViewRowMain.Cells("dgclProductionID").Value.ToString = String.Empty Then


                    For Each DataGridViewRowLoad In dgvLoadKernelDetails.Rows

                        ''''''For Load Kernel'''''''''''''
                        objKernelPPT.ProductionID = lProdIdNew
                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objKernelPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                        Else
                            objKernelPPT.LoadTankID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                            objKernelPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        Else
                            objKernelPPT.LoadingLocationID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                            objKernelPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objKernelPPT.LoadQty = 0.0
                        End If

                        'If Not DataGridViewRowLoad.Cells("dgclBalanceBF").Value Is DBNull.Value Then
                        '    objKernelPPT.LoadBalanceBF = DataGridViewRowLoad.Cells("dgclBalanceBF").Value
                        'Else
                        '    objKernelPPT.LoadBalanceBF = 0.0
                        'End If


                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then 'DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value And 
                            Dim lLoadMonthdate As String
                            Dim lLoadQty As String
                            lLoadMonthdate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                            lLoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value.ToString()
                            objKernelPPT.LoadMonthToDate = lLoadMonthdate 'Val(lLoadMonthdate) + Val(lLoadQty)

                            'objKernelPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objKernelPPT.LoadMonthToDate = 0.0
                        End If
                        '''''''''''''''''''''''''''''''''''''''
                        ''''For Remarks


                        objKernelPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objKernelPPT.CropYieldID = lCropYieldID

                        If Not (DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value) Then
                            objKernelPPT.ProdLoadingID = DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value
                        Else
                            objKernelPPT.ProdLoadingID = String.Empty
                        End If


                        If DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value.ToString = String.Empty Then
                            TransferKernelBOL.saveKernelLoadProduction(objKernelPPT)
                        Else
                            TransferKernelBOL.UpdateKernelLoadProduction(objKernelPPT)
                        End If

                    Next



                    DeleteMultiEntryRecordsLoadingKernel()


                    ' KernelProductionBOL.UpdateTankMasterBFQty(objKernelPPT)
                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSave.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSave.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    KernelGridViewBind()
                    Reset()

                    ResetLoad()

                    SaveFlag = True

                End If
                ClearGridView(dgvLoadKernelDetails)
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objKernelPPT As New TransferKernelPPT
            Dim objKernelBOL As New TransferKernelBOL

            objKernelPPT.KernelDate = dtpKernelDate.Value
            objKernelPPT.CropYieldID = lCropYieldID
            objKernelBOL.Delete_KernelDetail(objKernelPPT)
            KernelGridViewBind()
        End Try
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objKernelPPT As New TransferKernelPPT
        Dim objKernelBOL As New TransferKernelBOL
        If dgvKernelView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ' If lProductionID <> String.Empty Then
                objKernelPPT.KernelDate = dtpKernelDate.Value
                objKernelPPT.CropYieldID = lCropYieldID
                objKernelBOL.Delete_KernelDetail(objKernelPPT)
                KernelGridViewBind()
            End If
        End If


        Reset()

        ResetLoad()

    End Sub

   
End Class