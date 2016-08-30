Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class TranshipmentKernelFrm

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
    Public rowid As Integer = 0
    Dim objEditDuplicateRecord As Object
    Dim objDeleteDuplicateRecord As Object
    Dim objEditDuplicateSearchRecord As Object
    Dim objDeleteDuplicateSearchRecord As Object
    Dim objCompareDateCheck As Object

    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")

    Private TransMonthCount As Integer

    '' Trans Kernel'''
    Public btnTransAddFlag As Boolean = True
    Dim columnTransKernelAdd As DataColumn
    Dim rowTransKernelAdd As DataRow
    Dim dtTransKernelAdd As New DataTable("todgvTransKernelAdd")
    Public dtTransAddFlag As Boolean = False
    Public lTempTankNo As String = String.Empty
    Public lProdStockID As String = String.Empty
    Public lProdTranshipID As String = String.Empty
    Public lProdLoadingID As String = String.Empty
    Public isModifierKey As Boolean
    Public lLoadTank As String
    Public lLoadLocation As String
    Public lTransTank As String
    Public lloadTrans As String
    Public btnAddTransFlag As Boolean = True
    Public KernelDate As Date
    Public lProdIdNew As String = String.Empty
    Public lCropYieldCode As String = String.Empty
    Public lLocationDesc As String = String.Empty
    Public lTempProductionID As String = String.Empty
    Public lLoadVsLoc As String = String.Empty

    Public lCurrentReadingToday As Double = 0.0
    Public lLoadQtyToday As Double = 0.0
    Public lTransQtyToday As Double = 0.0

    Public lBalanceToday As Double = 0.0
    Public lTodayQty As Double = 0.0
    Dim dsStockTankNo As DataSet
    Dim dsLoadTankNo As DataSet
    Dim dsTransTankNo As DataSet
    Dim lProductionToday As Decimal = 0
    Dim lLoadCapacity As Decimal = 0
    Dim lTransCapacity As Decimal = 0
    Dim lLoadQty, lTransferQty As Decimal
    Dim lLoadQtyPrev As Decimal = 0
    Dim lTransferQtyPrev As Decimal = 0
    Dim lProductionMonth As Decimal = 0
    Dim lProductionYear As Decimal = 0
    Dim MonthCount As Integer
    Dim YearCount As Integer
    Dim lQtyPrev As Decimal = 0

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim DeleteMultientryStockKernel As New ArrayList
    Dim DeleteMultientryLoadKernel As New ArrayList
    Dim DeleteMultientryTransKernel As New ArrayList
    Dim lDelete As Integer
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TranshipmentKernelFrm))

    Private Sub TranshipmentKernelFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dgvTransKernelDetails.RowCount > 0 And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M424"

            End If
        End If
    End Sub

    Private Sub TranshipmentKernelFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TranshipmentKernelFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsButtonClose = False
        GlobalPPT.IsRetainFocus = False
        SetUICulture(GlobalPPT.strLang)

        dtpKernelDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpKernelDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpKernelDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpKernelDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpKernelDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        Dim ToDate As Date = dtpKernelDate.Value

        dtpKernelDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        Dim objKernelPPT As New TranshipmentKernelPPT
        Dim dsCrop As New DataSet
        dsCrop = TranshipmentKernelBOL.ProductionCropYieldIDSelect(objKernelPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for Kernel, Please insert the record in General Crop Yield")
        End If
        tcTransKernel.SelectedTab = tpKernelView
        loadCmbStorage()
        loadCmbLocation()

        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernelDate)
        'FormatDateTimePicker(dtpKernelDate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernelViewDate)
        'FormatDateTimePicker(dtpKernelViewDate)


        dtpKernelViewDate.Enabled = False
        lCropYieldCode = "Kernel"


        GetCropYieldID()
        objKernelPPT.CropYieldID = lCropYieldID
        ResetMain()
        Reset()
        'KernelGetMonthYearQty()
        ''KernelGetTodayQty()
        'KernelGetLoadTransMonthQty()

        'UpdateTankMasterBFQty()

        KernelGridViewBind()
        dtpKernelDate.Focus()


    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tcTransKernel.TabPages("tpKernelSave").Text = rm.GetString("ttcTransKernel.TabPages(tpKernelSave).Text")
            'tcTransKernel.TabPages("tpKernelView").Text = rm.GetString("ttcTransKernel.TabPages(tpKernelView).Text")

            'chkKernelDate.Text = rm.GetString("Date")

            'grpTransKernel.Text = rm.GetString("LoadKernel")
            'grpTransKernel.Text = rm.GetString("TransKernel")
            'grpTransKernelRecords.Text = rm.GetString("LoadKernelRecords")
            'grpTransKernelRecords.Text = rm.GetString("TransKernelRecords")


            'PnlSearch.CaptionText = rm.GetString("SearchTransferKernel")

            ''lblSearchBy.Text = rm.GetString("SearchBy")
            ''lblDate.Text = rm.GetString("Date")
            ''lblStockStorage.Text = rm.GetString("Storage")
            ''lblCapacity.Text = rm.GetString("Capacity (Mt)")
            ''lblBalance.Text = rm.GetString("Balance B/F(MT)")
            ''lblCurrentReading.Text = rm.GetString("Current Reading (Mt)")
            ''lblMeasurement.Text = rm.GetString("Measurement (Cm)")
            ''lblTemperature.Text = rm.GetString("Temperature")
            ''lblFFA.Text = rm.GetString("FFA")
            ''lblMoisture.Text = rm.GetString("Moisture")
            ''lblDirt.Text = rm.GetString("Dirt")





            ''lblLoadStorage.Text = rm.GetString("Storage")
            ''lblTransStorage.Text = rm.GetString("Storage")
            ''lblLoadQty.Text = rm.GetString("Quantity")
            ''lblTransQty.Text = rm.GetString("Quantity")
            ''lblToLoading.Text = rm.GetString("To Loading")
            ''lblRemarks.Text = rm.GetString("Remarks")
            ''lblLoadMonthDate.Text = rm.GetString("Month Todate")
            ''lblTransToLoading.Text = rm.GetString("Transshipment")
            ''Label7.Text = rm.GetString("Remarks")
            ''lblTransMonthDate.Text = rm.GetString("Month Todate")

            btnAddTrans.Text = rm.GetString("Add")
            btnResetTrans.Text = rm.GetString("Reset")




            'dgvTransKernelDetails.Columns("dgclTransStorageNo").HeaderText = rm.GetString("Storage")
            'dgvTransKernelDetails.Columns("dgclTranshipLoad").HeaderText = rm.GetString("Transshipment")
            'dgvTransKernelDetails.Columns("dgclTranshipQuantity").HeaderText = rm.GetString("Quantity")
            'dgvTransKernelDetails.Columns("dgclTransMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvTransKernelDetails.Columns("dgclTransRemarks").HeaderText = rm.GetString("Remarks")


            ''lblProStorage.Text = rm.GetString("Storage")
            ''lblProToday.Text = rm.GetString("Today")
            ''lblProMonthdate.Text = rm.GetString("Month Todate")
            ''lblProYeardate.Text = rm.GetString("YearTodate")

            btnSaveAll.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddTrans.Text = rm.GetString("Add")
            btnAddTrans.Text = rm.GetString("Add")

            'dgvTransKernelView.Columns("gvKernelDate").HeaderText = rm.GetString("Date")
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
            Dim objKernelPPT As New TranshipmentKernelPPT
            Dim dsTransLoad As DataSet
            objKernelPPT.CropYieldID = lCropYieldID
            objKernelPPT.KernelDate = dtpKernelDate.Value
            dsTransLoad = TranshipmentKernelBOL.KernelGetLoadTransMonthQty(objKernelPPT)
            If dsTransLoad.Tables.Count <> 0 Then

                If dsTransLoad.Tables(0).Rows.Count <> 0 Then

                    If Not dsTransLoad.Tables(1).Rows(0).Item("MonthTodate") Is DBNull.Value Then
                        Me.txtTransMonthToDate.Text = dsTransLoad.Tables(1).Rows(0).Item("MonthTodate")
                    Else
                        Me.txtTransMonthToDate.Text = 0.0
                    End If
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

            dsTransTankNo = TranshipmentKernelBOL.loadCmbStorage("Kernel")

            Dim dr2 As DataRow = dsTransTankNo.Tables(0).NewRow()
            dr2(0) = "--Select--"
            dr2(1) = "--Select--"
            dsTransTankNo.Tables(0).Rows.InsertAt(dr2, 0)
            'dsStockTankNo.AcceptChanges()

        Catch ex As Exception
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("There is No Tank for This Estate") 'ex.Message)
        End Try
    End Sub

    Private Sub loadCmbLocation()
        Try

            'Transhipment Kernel Combo
            cmbLoadTrans.DataSource = Nothing
            Dim dsLoadTrans As DataSet
            dsLoadTrans = TranshipmentKernelBOL.loadCmbLocation()
            'Location Kernel Combo
            cmbLoadTrans.DataSource = dsLoadTrans.Tables(0)

            cmbLoadTrans.DisplayMember = "LoadingLocationCode"
            cmbLoadTrans.ValueMember = "LoadingLocationID"

            'Trans Kernel
            cmbTransTank.DataSource = Nothing
            Dim dsTransTank As DataSet
            dsTransTank = TranshipmentKernelBOL.loadCmbLocation()

            cmbTransTank.DataSource = dsTransTank.Tables(1)
            'cmbTransTank.DisplayMember = "LoadingLocationCode"
            'cmbTransTank.ValueMember = "LoadingLocationID"

            cmbTransTank.DisplayMember = "KernelStorageCode"
            cmbTransTank.ValueMember = "KernelStorageID"

            Dim dr1 As DataRow = dsLoadTrans.Tables(0).NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            dsLoadTrans.Tables(0).Rows.InsertAt(dr1, 0)

            Dim dr2 As DataRow = dsTransTank.Tables(1).NewRow()
            dr2(0) = "--Select--"
            dr2(1) = "--Select--"
            dsTransTank.Tables(1).Rows.InsertAt(dr2, 0)
            'dsStockTankNo.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub GetCropYieldID()
        Try
            Dim dsCrop As New DataSet
            Dim objKernelPPT As New TranshipmentKernelPPT
            objKernelPPT.CropYieldCode = lCropYieldCode
            If objKernelPPT.CropYieldCode <> String.Empty Then
                dsCrop = TranshipmentKernelBOL.GetCropYieldID(objKernelPPT)
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
            Dim objKernelPPT As New TranshipmentKernelPPT
            objKernelPPT.TankID = lTankID
            If objKernelPPT.TankID <> String.Empty Then
                dsCropID = TranshipmentKernelBOL.GetCropYield(objKernelPPT)
            End If
            If dsCropID.Tables.Count <> 0 Then
                If dsCropID.Tables(0).Rows.Count <> 0 Then
                    lCropYieldID = dsCropID.Tables(0).Rows(0).Item("CropYieldID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Function IsCheckValidationTrans()
        'If dtpKernelDate.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please check Production Date", " Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        If cmbTransTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg18")
            ''MessageBox.Show("This Field is Required", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTransTank.Focus()
            Return False
        End If
        If cmbLoadTrans.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg19")
            ''MessageBox.Show("This Field is Required", "Transshipment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        If Val(txtTransQty.Text) = 0 Then
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransQty.Focus()
            Return False
        End If
        If Val(txtTransMonthToDate.Text) = 0 Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("This Field is Required", "Month To Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransMonthToDate.Focus()
            Return False
        End If

        If cmbLoadTrans.Text = cmbTransTank.Text Then
            DisplayInfoMessage("Msg20")
            ''MessageBox.Show("Loading and Transshipment cant be same ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        If Val(txtTransMonthToDate.Text) < Val(txtTransQty.Text) Then
            DisplayInfoMessage("Msg21")
            '' MessageBox.Show("Month To Date value cant be lesser than Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransMonthToDate.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub ResetTrans()
        ''''For Stock Kernel
        lresetLoad = False
        lresetTrans = True
        If cmbTransTank.Items.Count > 0 Then
            cmbTransTank.SelectedIndex = 0
        End If
        If cmbLoadTrans.Items.Count > 0 Then
            cmbLoadTrans.SelectedIndex = 0
        End If

        txtTransQty.Text = ""
        txtTransRemarks.Text = ""
        'lblTransDescription.Text = "Description"
        ' KernelGetLoadTransMonthQty()
        If GlobalPPT.strLang = "en" Then
            btnAddTrans.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddTrans.Text = "Menambahkan"
        End If
        '' btnAddTrans.Text = "Add"
        btnAddTransFlag = True
        lTransferQtyPrev = 0
      

    End Sub
    Public Sub ResetMain()

        ' btnAddFlag = True
        
    End Sub
    Public Sub Reset()

        dtpKernelDate.Enabled = True

        '''' For Trans Kernel

        If cmbTransTank.Items.Count > 0 Then
            cmbTransTank.SelectedIndex = 0
        End If

        If cmbLoadTrans.Items.Count > 0 Then
            cmbLoadTrans.SelectedIndex = 0
        End If
        txtTransQty.Text = ""
        txtTransMonthToDate.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        '' btnSaveAll.Text = "Save All"
        SaveFlag = True
        dtpKernelViewDate.Enabled = False
        chkKernelDate.Checked = False

        ClearGridView(dgvTransKernelDetails)

        DeleteMultientryTransKernel.Clear()


        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''
        MonthCount = False
        YearCount = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvTransKernelView.Rows.Count > 0 Then

            ''''For  Transhipment Kernel''''''
            txtTransMonthToDate.Enabled = False
        Else

            ''''For  Transhipment Kernel''''''
            txtTransMonthToDate.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub KernelGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objKernelPPT As New TranshipmentKernelPPT
            objKernelPPT.KernelDate = dtpKernelDate.Value
            'loadCmbStorage()
            With objKernelPPT

                'edit by suraya 14092012


                dtpKernelViewDate.Format = DateTimePickerFormat.Custom '
                dtpKernelViewDate.CustomFormat = "dd/MM/yyyy"
                GlobalBOL.SetDateTimePicker(Me.dtpKernelViewDate)

                If chkKernelDate.Checked = True Then
                    dtpKernelViewDate.Enabled = True
                    .KernelDate = dtpKernelViewDate.Value
                Else
                    .KernelDate = Nothing
                End If
                'If chkKernelDate.Checked = True Then
                '    dtpKernelViewDate.Enabled = True
                '    .KernelDate = dtpKernelViewDate.Value 'Format(Me.dtpKernelViewDate.Value, "MM/dd/yyyy")

                '    dtpKernelViewDate.MinDate = GlobalPPT.FiscalYearFromDate
                '    dtpKernelViewDate.MaxDate = GlobalPPT.FiscalYearToDate
                '    Dim TempDate As Date = dtpKernelViewDate.Value
                '    Dim NowDate As Date = Now()
                '    If Now() >= GlobalPPT.FiscalYearFromDate And dtpKernelViewDate.Value <= GlobalPPT.FiscalYearFromDate Then
                '        dtpKernelViewDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
                '    End If

                '    Dim ToDate As Date = dtpKernelViewDate.Value

                '    dtpKernelViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

                'Else
                '    dtpKernelViewDate.Enabled = False
                '    .KernelDate = Nothing
                'End If
                ' .TankNo = cmbViewTankNo.Text

                'If .TankNo = "--Select All--" Then
                '    .TankNo = ""
                'Else
                '    .TankNo = cmbViewTankNo.Text
                'End If
            End With
            objKernelPPT.CropYieldID = lCropYieldID
            dt = TranshipmentKernelBOL.GetKernelDetails(objKernelPPT)
            'If dt.TableName.Count <> 0 Then
            If dt.Rows.Count <> 0 Then
                dgvTransKernelView.AutoGenerateColumns = False
                Me.dgvTransKernelView.DataSource = dt
                'Dim i As Integer = dgvTransKernelView.Rows.Count
                'lLoadMonthToDate = dgvTransKernelView.Rows(i - 1).Cells("gvLoadMonthToDate").Value
                'lTransMonthToDate = dgvTransKernelView.Rows(i - 1).Cells("gvTransMonthToDate").Value
                'MsgBox(dgvTransKernelView.Rows(i - 1).Cells("gvLoadMonthToDate").Value)
            Else
                ClearGridView(dgvTransKernelView) '''''clear the records from grid view
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

        If dgvTransKernelView.Rows.Count > 0 Then

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
            Dim objKernelPPT As New TranshipmentKernelPPT
            Dim objKernelBOL As New TranshipmentKernelBOL
            Dim dt As New DataTable

            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If


            lresetLoad = True
            lresetTrans = True

            objKernelPPT.CropYieldID = lCropYieldID
            '  objKernelPPT.ProductionID = lProductionID
            Dim str As String = Me.dgvTransKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

            '            objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)
            objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)



            dtpKernelDate.Value = objKernelPPT.KernelDate
            'KernelGetMonthYearQty()
            'KernelGetTodayQty()
            'KernelGetLoadTransMonthQty()


            '''' For Trans Kernel'''
            dtTransKernelAdd = TranshipmentKernelBOL.GetKernelAddTransInfo(objKernelPPT)
            dgvTransKernelDetails.AutoGenerateColumns = False
            SaveFlag = False
            dgvTransKernelDetails.DataSource = dtTransKernelAdd
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            KernelGridViewBind()
            Me.tcTransKernel.SelectedTab = tpKernelSave
            btnSaveAll.Enabled = False
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
        If dgvTransKernelView.RowCount > 0 Then



            rowid = dgvTransKernelView.SelectedRows.Item(0).Index

            If (rowid = 0) Then


                Dim objKernelPPT As New TranshipmentKernelPPT
                Dim objKernelBOL As New TranshipmentKernelBOL
                Dim str As String = Me.dgvTransKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                '            objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                objKernelPPT.CropYieldID = lCropYieldID
                dtpKernelDate.Value = objKernelPPT.KernelDate

                objEditDuplicateSearchRecord = objKernelBOL.TransSearchDateCheck(objKernelPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objKernelBOL.EditDateCheck(objKernelPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateKernelView()
                        btnSaveAll.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateKernelView()
                        btnSaveAll.Enabled = True
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
            Dim objKernelPPT As New TranshipmentKernelPPT
            Dim objKernelBOL As New TranshipmentKernelBOL
            objKernelPPT.TankNo = lTankNo
            dsLoad = TranshipmentKernelBOL.GetTankID(objKernelPPT)
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
            Dim objKernelPPT As New TranshipmentKernelPPT
            objKernelPPT.Descp = lLocation
            dsLocation = TranshipmentKernelBOL.GetLocationID(objKernelPPT)
            If dsLocation.Tables.Count <> 0 Then
                If dsLocation.Tables(0).Rows.Count <> 0 Then
                    lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                    lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvTransKernelView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateKernelView()
            End If
        End If


    End Sub

    Private Sub DeleteKernelVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernelProductionFrm))

        Me.cmsKernel.Visible = False

        Dim objKernelPPT As New TranshipmentKernelPPT
        Dim objKernelBOL As New TranshipmentKernelBOL
        ' Dim dt As New DataTable
        If dgvTransKernelView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim str As String = Me.dgvTransKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

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
        If dgvTransKernelView.RowCount > 0 Then



            rowid = dgvTransKernelView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objKernelPPT As New TranshipmentKernelPPT
                Dim objKernelBOL As New TranshipmentKernelBOL
                Dim str As String = Me.dgvTransKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                '            objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                objKernelPPT.CropYieldID = lCropYieldID
                dtpKernelDate.Value = objKernelPPT.KernelDate

                objDeleteDuplicateSearchRecord = objKernelBOL.TransSearchDateCheck(objKernelPPT)
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
                    'DeleteCPOVIew()
                End If
            Else
                DisplayInfoMessage("Msg141")
                ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtTransQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransQty.KeyPress
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

    Private Sub txtTransMonthToDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransMonthToDate.KeyPress
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

    Private Sub txtTransQty_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransQty.KeyDown

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

    Private Sub txtTransMonthToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransMonthToDate.KeyDown

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

        ResetTrans()
        GlobalPPT.IsRetainFocus = False
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Reset()
        tcTransKernel.SelectedTab = tpKernelSave
        ResetTrans()
    End Sub

    Private Sub TransTankMonthtoDate()
        If cmbTransTank.SelectedIndex <> 0 And cmbLoadTrans.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsTransMonthTodate As New DataSet
            txtTransMonthToDate.Text = ""
            txtTransQty.Text = ""
            TransMonthCount = 0
            Dim objKernelPPT As New TranshipmentKernelPPT
            objKernelPPT.TankID = cmbTransTank.SelectedValue.ToString
            objKernelPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
            objKernelPPT.CropYieldID = lCropYieldID
            objKernelPPT.KernelDate = dtpKernelDate.Value
            dsTransMonthTodate = TranshipmentKernelBOL.KernelGetTranshipKernelMonthtodate(objKernelPPT)

            If dsTransMonthTodate.Tables(0).Rows.Count <> 0 Then
                lTransMonthToDate = Val(dsTransMonthTodate.Tables(0).Rows(0).Item("MonthTodate").ToString)
            End If
            TransMonthCount = dsTransMonthTodate.Tables(1).Rows(0).Item("TransMonthCount").ToString

            If TransMonthCount = 0 Or (TransMonthCount = 1 And btnAddTransFlag = False And SaveFlag = False) Then
                txtTransMonthToDate.Enabled = True
            Else
                txtTransMonthToDate.Enabled = False
            End If

        Else
            txtTransMonthToDate.Text = ""
            txtTransMonthToDate.Enabled = True
        End If
    End Sub

    Private Sub cmbTransTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTransTank.SelectedIndexChanged
        'Dim lrow As Integer
        'txtTransQty.Text = ""
        'If cmbTransTank.SelectedIndex <> 0 Then
        '    lrow = cmbTransTank.SelectedIndex
        '    lTransCapacity = dsTransTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString

        'End If


        'lTankID = Nothing
        'GetTankID(cmbTransTank.Text)
        'Dim objKernelPPT As New KernelProductionPPT
        'lTransTankID = lTankID

        'objKernelPPT.TankID = cmbTransTank.SelectedValue.ToString
        'objKernelPPT.ProductionID = lProdIdNew
        'Dim objKernelBOL As New KernelProductionBOL
        'objKernelPPT.CropYieldID = lCropYieldID
        'objKernelPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
        'objKernelPPT.KernelDate = dtpKernelDate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objKernelBOL.DuplicateTransLocationFirstCheck(objKernelPPT)
        '    If objCheckDuplicateLoadLocation = 0 Then
        '        txtTransMonthToDate.Enabled = False
        '    Else
        '        txtTransMonthToDate.Enabled = True
        '    End If
        'End If


        ''''Month Qty Value '''''''''''''''

        'Dim dsCrop As New DataSet
        ''If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lCropYieldID <> String.Empty) Then
        '    dsCrop = KernelProductionBOL.KernelGetTransVsLocMonthQty(objKernelPPT)
        '    If dsCrop.Tables.Count <> 0 Then
        '        If dsCrop.Tables(0).Rows.Count <> 0 Then
        '            lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("Qty")
        '            txtTransMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("Qty")
        '        Else
        '            txtTransMonthToDate.Text = "0"
        '        End If
        '    End If
        'Else
        '    txtTransMonthToDate.Text = "0"
        'End If

        If cmbTransTank.SelectedIndex = 0 Then
            txtTransMonthToDate.Text = ""
            txtTransMonthToDate.Enabled = False
        Else
            ' TransTankMonthtoDate()
        End If


    End Sub

    Private Sub cmbLoadTrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTrans.SelectedIndexChanged
        Try
            'lLocationID = Nothing
            'GetLocationID(cmbLoadTrans.Text)
            'Dim objKernelPPT As New KernelProductionPPT
            'lTransLocationID = lLocationID
            ''lblTransDescription.Text = lLocationDesc
            'objKernelPPT.TransLocationID = lLocationID
            'objKernelPPT.TankID = cmbLoadTrans.SelectedValue.ToString
            'objKernelPPT.KernelDate = dtpKernelDate.Value
            'Dim objKernelBOL As New KernelProductionBOL

            'objKernelPPT.ProductionID = lProdIdNew
            'objKernelPPT.CropYieldID = lCropYieldID
            'objKernelPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString

            'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
            '    Dim objCheckDuplicateLoadLocation As Object = 0
            '    objCheckDuplicateLoadLocation = objKernelBOL.DuplicateTransLocationFirstCheck(objKernelPPT)
            '    If objCheckDuplicateLoadLocation = 0 Then
            '        txtTransMonthToDate.Enabled = False
            '    Else
            '        txtTransMonthToDate.Enabled = True
            '    End If
            'End If

            ''''Month Qty Value '''''''''''''''

            'Dim dsCrop As New DataSet
            ''If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
            'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lCropYieldID <> String.Empty) Then
            '    dsCrop = KernelProductionBOL.KernelGetTransVsLocMonthQty(objKernelPPT)
            '    If dsCrop.Tables.Count <> 0 Then
            '        If dsCrop.Tables(0).Rows.Count <> 0 Then
            '            lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("Qty")
            '            txtTransMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("Qty")
            '        Else
            '            txtTransMonthToDate.Text = "0"
            '        End If
            '    End If
            'Else
            '    txtTransMonthToDate.Text = "0"
            'End If
            If cmbLoadTrans.SelectedIndex = 0 Then
                txtTransMonthToDate.Text = ""
                txtTransMonthToDate.Enabled = False
            Else
                TransTankMonthtoDate()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If dgvTransKernelDetails.RowCount > 0 And btnSaveAll.Enabled = True Then
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
            If dgvTransKernelView.RowCount = 0 Then
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

    Private Sub dgvTransKernelView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransKernelView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSaveAll.Enabled = True
            Else
                btnSaveAll.Enabled = False
                Exit Sub
            End If
        End If
        If dgvTransKernelView.RowCount > 0 Then


            If (e.RowIndex = 0) Then

                rowid = e.RowIndex
                Dim objKernelPPT As New TranshipmentKernelPPT
                Dim objKernelBOL As New TranshipmentKernelBOL
                Dim str As String = Me.dgvTransKernelView.SelectedRows(0).Cells("gvKernelDate").Value.ToString()

                '            objKernelPPT.KernelDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objKernelPPT.KernelDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                objKernelPPT.CropYieldID = lCropYieldID
                dtpKernelDate.Value = objKernelPPT.KernelDate
                objEditDuplicateSearchRecord = objKernelBOL.TransSearchDateCheck(objKernelPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objKernelBOL.EditDateCheck(objKernelPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateKernelView()
                        btnSaveAll.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateKernelView()
                        btnSaveAll.Enabled = True
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

    Private Sub txtTransQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransQty.Leave
        If txtTransQty.Text <> "" Then

            If lTransMonthToDate = 0 And TransMonthCount >= 1 Then
                txtTransMonthToDate.Text = Val(txtTransQty.Text)
            ElseIf SaveFlag = False And TransMonthCount <= 1 Then
                txtTransMonthToDate.Text = lTransMonthToDate
            ElseIf lTransMonthToDate > 0 And txtTransQty.Text <> "" And btnAddTransFlag = True Then
                txtTransMonthToDate.Text = lTransMonthToDate + Val(txtTransQty.Text)
            ElseIf lTransMonthToDate > 0 And txtTransQty.Text <> "" And btnAddTransFlag = False Then
                txtTransMonthToDate.Text = lTransMonthToDate + Val(txtTransQty.Text) - lTransferQtyPrev
            ElseIf txtTransMonthToDate.Enabled = False Then
                txtTransMonthToDate.Text = ""
            End If
        Else
            txtTransMonthToDate.Text = ""
        End If

    End Sub
    Private Sub SaveTransKernelDetail()
        Try
            Dim objKernelPPT As New TranshipmentKernelPPT
            Dim objKernelBOL As New TranshipmentKernelBOL

            Dim intRowcount As Integer = dtTransKernelAdd.Rows.Count

            'KernelGetTodayQty()

            If Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, dtpKernelDate.Value) Then 'Location, Tank Validation 

                'objKernelPPT.CropYieldID = lCropYieldID
                ''Dim objCheckDuplicateRecord As Object = 0
                'objKernelPPT.KernelDate = dtpKernelDate.Value
                ''objCheckDuplicateRecord = objKernelBOL.DuplicateDateCheck(objKernelPPT)


                'objKernelPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
                'objKernelPPT.TankID = cmbTransTank.SelectedValue.ToString


                'Dim objCheckDuplicateLoadLocation As Object = 0
                'objCheckDuplicateLoadLocation = objKernelBOL.DuplicateTransLocationCheck(objKernelPPT)
                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If


                rowTransKernelAdd = dtTransKernelAdd.NewRow()

                If intRowcount = 0 And dtTransAddFlag = False Then
                    Try

                        columnTransKernelAdd = New DataColumn("TransTankNo", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)
                        columnTransKernelAdd = New DataColumn("TransLocation", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)
                        columnTransKernelAdd = New DataColumn("TransQty", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)
                        columnTransKernelAdd = New DataColumn("TransMonthToDate", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)
                        columnTransKernelAdd = New DataColumn("TransTankID", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)
                        columnTransKernelAdd = New DataColumn("TransLocationID", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        columnTransKernelAdd = New DataColumn("TransRemarks", System.Type.[GetType]("System.String"))
                        dtTransKernelAdd.Columns.Add(columnTransKernelAdd)

                        rowTransKernelAdd("TransTankNo") = Me.cmbTransTank.Text
                        rowTransKernelAdd("TransLocation") = Me.cmbLoadTrans.Text

                        If Me.txtTransQty.Text <> String.Empty Then
                            rowTransKernelAdd("TransQty") = Me.txtTransQty.Text
                        End If
                        If Me.txtTransMonthToDate.Text <> String.Empty Then
                            rowTransKernelAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                        End If

                        rowTransKernelAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                        rowTransKernelAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowTransKernelAdd("TransRemarks") = txtTransRemarks.Text.Trim
                        dtTransKernelAdd.Rows.InsertAt(rowTransKernelAdd, intRowcount)
                        dtTransAddFlag = True

                    Catch ex As Exception
                        rowTransKernelAdd("TransTankNo") = Me.cmbTransTank.Text
                        rowTransKernelAdd("TransLocation") = Me.cmbLoadTrans.Text

                        If Me.txtTransQty.Text <> String.Empty Then
                            rowTransKernelAdd("TransQty") = Me.txtTransQty.Text
                        End If
                        If Me.txtTransMonthToDate.Text <> String.Empty Then
                            rowTransKernelAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                        End If
                        rowTransKernelAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                        rowTransKernelAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowTransKernelAdd("TransRemarks") = txtTransRemarks.Text.Trim
                        dtTransKernelAdd.Rows.InsertAt(rowTransKernelAdd, intRowcount)

                    End Try


                Else
                    rowTransKernelAdd("TransTankNo") = Me.cmbTransTank.Text
                    rowTransKernelAdd("TransLocation") = Me.cmbLoadTrans.Text

                    If Me.txtTransQty.Text <> String.Empty Then
                        rowTransKernelAdd("TransQty") = Me.txtTransQty.Text
                    End If
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowTransKernelAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                    End If
                    rowTransKernelAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                    rowTransKernelAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                    '''''''''''''''''''''''''''''''''''
                    '''''''''''''For Remarks
                    rowTransKernelAdd("TransRemarks") = txtTransRemarks.Text.Trim
                    dtTransKernelAdd.Rows.InsertAt(rowTransKernelAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry this Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvTransKernelDetails
                .DataSource = dtTransKernelAdd
                .AutoGenerateColumns = False
            End With




        Catch ex As Exception
        End Try

    End Sub


    Private Function LocationExistTrans(ByVal Location As String, ByVal TankNo As String, ByVal KernelDate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvTransKernelDetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclTransStorageNo").Value And Location = objDataGridViewRow.Cells("dgclTranshipLoad").Value) Then
                    ' txtStockCode.Text = ""
                    cmbTransTank.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try
        'End If
    End Function

    Private Sub UpdateTransKernelDetails()
        Try
            Dim intCount As Integer = dgvTransKernelDetails.CurrentRow.Index

            If lTransTank = cmbTransTank.Text And lloadTrans = cmbLoadTrans.Text Then
                ' If lTempTankNo = cmbStockTank.Text Then

                'StrAdjustDate = Me.dtpAdjustmentDate.Text
                'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                'dgvKernelDetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate

                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If
                If Me.txtTransQty.Text <> Nothing Then
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If

                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim

                'If Me.txtMoisture.Text <> Nothing Then
                '    dgvKernelDetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                'End If

                'dgvKernelDetails.Rows(intCount).Cells("dgclStockTankID").Value = lStockTankID
                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                ''btnAddTrans.Text = "Add"
                btnTransAddFlag = True
                'clear()

            ElseIf Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, KernelDate) Then
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If
                If Me.txtTransQty.Text <> Nothing Then
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransKernelDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If


                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString
                dgvTransKernelDetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim
                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnTransAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                '' MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BindDgvTransKernelDetails()
        If dgvTransKernelDetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddTrans.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddTrans.Text = "Memperbarui"
            End If
            ''Me.btnAddTrans.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddTransFlag = False

            cmbTransTank.Text = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            lTransTank = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            cmbLoadTrans.Text = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()
            lloadTrans = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()

            If Not dgvTransKernelDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is DBNull.Value Then
                lProdTranshipID = dgvTransKernelDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value
            Else
                lProdTranshipID = Nothing
            End If

            If Not dgvTransKernelDetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtTransQty.Text = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
                lTransferQtyPrev = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
            End If

            If Not dgvTransKernelDetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtTransMonthToDate.Text = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString()
            End If
            ' AddFlag = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Remarks Fields Add'''''''''''''''''
            txtTransRemarks.Text = dgvTransKernelDetails.SelectedRows(0).Cells("dgclTransRemarks").Value.ToString()

        End If

    End Sub

    Private Sub dtpKernelDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpKernelDate.ValueChanged

        Dim objKernelPPT As New TranshipmentKernelPPT
        Dim objKernelBOL As New TranshipmentKernelBOL

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

    Private Sub dgvTransKernelView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTransKernelView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateKernelView()
            e.Handled = True
        End If
    End Sub

    Private Sub AddTrans_Clicked()
        Try
            'If lTransCapacity < lTransferQty Then
            '    MessageBox.Show("Sum of  Quantity(Mt) should be lesser than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtTransQty.Focus()
            '    Exit Sub
            'End If

            If btnAddTransFlag = True Then
                'If btnAdd.Text.Trim() = "Add" Then
                If (IsCheckValidationTrans() = False) Then
                    Exit Sub
                Else

                    SaveTransKernelDetail()
                    'If dgvTransKernelDetails.Rows.Count <> 0 Then
                    '    For Each objDataGridViewRow In dgvTransKernelDetails.Rows
                    '        If objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString <> String.Empty Then
                    '            lTransQtyToday = lTransQtyToday + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
                    '        End If
                    '    Next
                    'End If
                    'lTodayQty = lCurrentReadingToday + lLoadQtyToday + lTransQtyToday - lBalanceToday
                    'txtProductionToday.Text = lTodayQty

                    ResetTrans()
                End If
            ElseIf btnAddTransFlag = False Then
                If (IsCheckValidationTrans() = False) Then
                    Exit Sub
                Else
                    UpdateTransKernelDetails()
                    'lblStatus.Text = "OPEN"
                    'clear()
                    ResetTrans()

                    If (rowid = 0) Then
                        If (objEditDuplicateRecord = 0) Then

                            btnDeleteAll.Enabled = False
                            btnSaveAll.Enabled = False
                        Else
                            btnDeleteAll.Enabled = True
                            btnSaveAll.Enabled = True
                        End If
                    Else
                        btnDeleteAll.Enabled = False
                        btnSaveAll.Enabled = False
                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAddTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTrans.Click
        'TransferQtyCheck()
       
        AddTrans_Clicked()


    End Sub

    Private Sub dgvTransKernelDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransKernelDetails.CellDoubleClick

        BindDgvTransKernelDetails()

    End Sub

    Private Sub btnResetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetTrans.Click
        ResetTrans()
    End Sub

    Private Sub TransferQtyCheck()
        lTransferQty = 0

        If dgvTransKernelDetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvTransKernelDetails.Rows
                If objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclTransStorageID").Value.ToString = cmbTransTank.SelectedValue.ToString Then
                    lTransferQty = lTransferQty + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
                End If
            Next
        End If

        lTransferQty = lTransferQty + Val(txtTransQty.Text) - lTransferQtyPrev



    End Sub

    Private Sub tcTransKernel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransKernel.SelectedIndexChanged
        'ResetMain()
        ' Reset()
        'ResetLoad()
        ' ResetTrans()
        KernelGridViewBind()
    End Sub
    Private Sub tcTransKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransKernel.Click

        If dgvTransKernelDetails.RowCount > 0 And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcTransKernel.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ' ResetMain()
                Reset()
                'ResetLoad()
                ResetTrans()
                KernelGridViewBind()


            End If
        Else
            'ResetMain()
            Reset()
            'ResetLoad()
            ResetTrans()
            KernelGridViewBind()


        End If
    End Sub
    Private Sub txtTransMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransMonthToDate.TextChanged
        If Val(txtTransMonthToDate.Text) = 0 Then
            txtTransMonthToDate.Text = ""
        End If
    End Sub

    Private Sub TranshipEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipEdit.Click
        BindDgvTransKernelDetails()
    End Sub

    Private Sub TranshipDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipDelete.Click
        If dgvTransKernelDetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvTransKernelDetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridTranshipKernel()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridTranshipKernel()

        If Not dgvTransKernelDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is Nothing Then
            lProdTranshipID = dgvTransKernelDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value.ToString
        Else
            lProdTranshipID = String.Empty
        End If



        lDelete = 0
        If lProdTranshipID <> "" Then
            lDelete = DeleteMultientryTransKernel.Count
            DeleteMultientryTransKernel.Insert(lDelete, lProdTranshipID)
        End If
        Dim Dr As DataRow
        Dr = dtTransKernelAdd.Rows.Item(dgvTransKernelDetails.CurrentRow.Index)
        Dr.Delete()
        dtTransKernelAdd.AcceptChanges()
        lProdTranshipID = ""


    End Sub

    Private Sub DeleteMultiEntryRecordsTranshipKernel()
        Dim objKernelProductionPPT As New TranshipmentKernelPPT
        lDelete = DeleteMultientryTransKernel.Count

        While (lDelete > 0)

            objKernelProductionPPT.ProdTranshipID = DeleteMultientryTransKernel(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = TranshipmentKernelBOL.DeleteMultiEntryProdTranship(objKernelProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objKernelPPT As New TranshipmentKernelPPT
        Dim objKernelBOL As New TranshipmentKernelBOL
        If dgvTransKernelView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If lProductionID <> String.Empty Then
                objKernelPPT.KernelDate = dtpKernelDate.Value
                objKernelPPT.CropYieldID = lCropYieldID
                objKernelBOL.Delete_KernelDetail(objKernelPPT)
                KernelGridViewBind()
                'End If

            End If
        End If

        Reset()
        ResetTrans()
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click


        Try

            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg24")
                ''MsgBox("No Record in Crop yield for Kernel, Please insert the record in General Crop Yield")
                Exit Sub
            End If

            If dgvTransKernelDetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If
                If SaveFlag = True Then

                    Dim objKernelPPT As New TranshipmentKernelPPT
                    Dim objKernelBOL As New TranshipmentKernelBOL

                    Dim objCheckDuplicateRecord As Object = 0
                    objKernelPPT.KernelDate = dtpKernelDate.Value
                    objKernelPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objKernelBOL.DuplicateDateCheck(objKernelPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    Else
                        objCompareDateCheck = objKernelBOL.CompareCPOPTransDateIsExist(objKernelPPT)
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
                    ' dsID = TranshipmentKernelBOL.saveKernelProduction(objKernelPPT)
                    'If dsID.Tables.Count <> 0 Then
                    '    If dsID.Tables(0).Rows.Count <> 0 Then
                    '        lProductionID = dsID.Tables(0).Rows(0).Item("ProductionID")
                    '    Else
                    '        lProductionID = Nothing
                    '    End If
                    'End If

                    'objKernelPPT.ProductionID = lProductionID


                    For Each DataGridViewRowTrans In dgvTransKernelDetails.Rows

                        ''''For Trans Kernel''''''''

                        If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objKernelPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                        Else
                            objKernelPPT.TransTankID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                            objKernelPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                        Else
                            objKernelPPT.TransLocationID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                            objKernelPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objKernelPPT.TransQty = 0.0
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value Then
                            'Dim lTransMonthdate As String
                            'Dim lTransQty As String
                            objKernelPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                            'lTransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                            'objKernelPPT.TransMonthToDate = Val(lTransMonthdate) ''''+ Val(lTransQty)
                        Else
                            objKernelPPT.TransMonthToDate = 0.0
                            'objKernelPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTransQuantity").Value
                        End If
                        '''''''For Remarks'''''''''''''''''''''''''
                        objKernelPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''
                        objKernelPPT.CropYieldID = lCropYieldID
                        TranshipmentKernelBOL.saveKernelTransProduction(objKernelPPT)
                        '   KernelProductionBOL.UpdateTankMasterBFQty(objKernelPPT)
                    Next


                    KernelGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()

                    ResetTrans()

                    'SaveFlag = False
                Else

                    Dim objKernelPPT As New TranshipmentKernelPPT
                    Dim objKernelBOL As New TranshipmentKernelBOL
                    'Dim StrKernelDate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvKernelDetails.Rows

                    objKernelPPT.CropYieldID = lCropYieldID
                    'KernelGetMonthYearQty()
                    'KernelGetTodayQty()
                    'KernelGetLoadTransMonthQty()

                    objKernelPPT.KernelDate = dtpKernelDate.Value

                    'Format(dtpKernelDate.Value, "MM/dd/yyyy")
                    ' objKernelPPT.ProductionID = DataGridViewRowMain.Cells("dgclProductionID").Value.ToString
                    'If DataGridViewRowMain.Cells("dgclProductionID").Value.ToString = String.Empty Then
                    'If lProdIdNew = String.Empty Then
                    '    KernelProductionBOL.saveKernelProduction(objKernelPPT)
                    'Else
                    '    KernelProductionBOL.UpdateKernelProduction(objKernelPPT)
                    'End If

                    ' Next


                    For Each DataGridViewRowTrans In dgvTransKernelDetails.Rows

                        ''''For Trans Kernel''''''''

                        If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objKernelPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                        Else
                            objKernelPPT.TransTankID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                            objKernelPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                        Else
                            objKernelPPT.TransLocationID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                            objKernelPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objKernelPPT.TransQty = 0.0
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then 'DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value And 
                            Dim lLoadMonthdate As String
                            Dim lLoadQty As String
                            lLoadMonthdate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                            lLoadQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                            objKernelPPT.TransMonthToDate = Val(lLoadMonthdate) '+ Val(lLoadQty)

                            'objKernelPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objKernelPPT.TransMonthToDate = 0.0
                        End If

                        objKernelPPT.CropYieldID = lCropYieldID

                        '''''''''''''''''''''''''''''''''''''''
                        ''''For Remarks
                        objKernelPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString


                        If Not (DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value) Then
                            objKernelPPT.ProdTranshipID = DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value
                        Else
                            objKernelPPT.ProdTranshipID = String.Empty
                        End If

                        If DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value.ToString = String.Empty Then
                            TranshipmentKernelBOL.saveKernelTransProduction(objKernelPPT)
                        Else
                            TranshipmentKernelBOL.UpdateKernelTransProduction(objKernelPPT)
                        End If

                    Next


                    DeleteMultiEntryRecordsTranshipKernel()

                    ' KernelProductionBOL.UpdateTankMasterBFQty(objKernelPPT)
                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    KernelGridViewBind()
                    Reset()


                    ResetTrans()
                    SaveFlag = True

                End If
                ClearGridView(dgvTransKernelDetails)
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objKernelPPT As New TranshipmentKernelPPT
            Dim objKernelBOL As New TranshipmentKernelBOL

            objKernelPPT.KernelDate = dtpKernelDate.Value
            objKernelPPT.CropYieldID = lCropYieldID
            ' objKernelBOL.Delete_KernelDetail(objKernelPPT)
            KernelGridViewBind()
        End Try
    End Sub

   
End Class