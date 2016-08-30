Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class TranshipmentCPOFrm
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

    '' Trans CPO'''
    Public btnTransAddFlag As Boolean = True
    Dim columnTransCPOAdd As DataColumn
    Dim rowTransCPOAdd As DataRow
    Dim dtTransCPOAdd As New DataTable("todgvTransCPOAdd")
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
    Public CPODate As Date
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
    Dim DeleteMultientryStockCPO As New ArrayList
    Dim DeleteMultientryLoadCPO As New ArrayList
    Dim DeleteMultientryTransCPO As New ArrayList
    Dim lDelete As Integer
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TranshipmentCPOFrm))
    Shadows mdiparent As New MDIParent

    Private Sub TranshipmentCPOFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dgvTransCPODetails.RowCount > 0 And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M420"

            End If
        End If
    End Sub

    Private Sub TranshipmentCPOFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TranshipmentCPOFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If


        dtpCPODate.Format = DateTimePickerFormat.Custom '
        dtpCPODate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpCPODate)

        dtpCPOViewDate.Format = DateTimePickerFormat.Custom '
        dtpCPOViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpCPOViewDate)
        'Dim ToDate As Date = Date.Today
        ''btnSaveAll.Enabled = True
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

        Dim objCPOPPT As New TranshipmentCPOPPT
        Dim dsCrop As New DataSet
        dsCrop = TranshipmentCPOBOL.ProductionCropYieldIDSelect(objCPOPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for CPO, Please insert the record in General Crop Yield")
        End If
        tcTransCPO.SelectedTab = tpCPOView
        loadCmbStorage()
        loadCmbLocation()

        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpCPODate)
        'FormatDateTimePicker(dtpCPODate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpCPOViewDate)
        'FormatDateTimePicker(dtpCPOViewDate)

        dtpCPOViewDate.Enabled = False
        lCropYieldCode = "CPO"

        GetCropYieldID()
        objCPOPPT.CropYieldID = lCropYieldID
        ResetMain()
        Reset()
        'CPOGetMonthYearQty()
        ''CPOGetTodayQty()
        'CPOGetLoadTransMonthQty()

        'UpdateTankMasterBFQty()

        CPOGridViewBind()
        dtpCPODate.Focus()
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tcTransCPO.TabPages("tpCPOSave").Text = rm.GetString("ttcTransCPO.TabPages(tpCPOSave).Text")
            'tcTransCPO.TabPages("tpCPOView").Text = rm.GetString("ttcTransCPO.TabPages(tpCPOView).Text")

            'chkCPODate.Text = rm.GetString("Date")

            'grpTransCPO.Text = rm.GetString("LoadCPO")
            'grpTransCPO.Text = rm.GetString("TransCPO")
            'grpTransCPORecords.Text = rm.GetString("LoadCPORecords")
            'grpTransCPORecords.Text = rm.GetString("TransCPORecords")


            'PnlSearch.CaptionText = rm.GetString("SearchTransCPO")

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
            ''lblTransToLoading.Text = rm.GetString("Transhipment")
            ''Label7.Text = rm.GetString("Remarks")
            ''lblTransMonthDate.Text = rm.GetString("Month Todate")

            btnAddTrans.Text = rm.GetString("Add")
            btnResetTrans.Text = rm.GetString("Reset")


            

            'dgvTransCPODetails.Columns("dgclTransStorageNo").HeaderText = rm.GetString("Storage")
            'dgvTransCPODetails.Columns("dgclTranshipLoad").HeaderText = rm.GetString("Transhipment")
            'dgvTransCPODetails.Columns("dgclTranshipQuantity").HeaderText = rm.GetString("Quantity")
            'dgvTransCPODetails.Columns("dgclTransMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvTransCPODetails.Columns("dgclTransRemarks").HeaderText = rm.GetString("Remarks")


            ''lblProStorage.Text = rm.GetString("Storage")
            ''lblProToday.Text = rm.GetString("Today")
            ''lblProMonthdate.Text = rm.GetString("Month Todate")
            ''lblProYeardate.Text = rm.GetString("YearTodate")

            btnSaveAll.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddTrans.Text = rm.GetString("Add")
            btnAddTrans.Text = rm.GetString("Add")

            'dgvTransCPOView.Columns("gvCPODate").HeaderText = rm.GetString("Date")
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
            Dim objCPOPPT As New TranshipmentCPOPPT
            Dim dsTransLoad As DataSet
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpCPODate.Value
            dsTransLoad = TranshipmentCPOBOL.CPOGetLoadTransMonthQty(objCPOPPT)
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

            dsTransTankNo = CPOProductionBOL.loadCmbStorage("CPO")

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

            'Transhipment CPO Combo
            cmbLoadTrans.DataSource = Nothing
            Dim dsLoadTrans As DataSet
            dsLoadTrans = TranshipmentCPOBOL.loadCmbLocation()
            'Location CPO Combo
            cmbLoadTrans.DataSource = dsLoadTrans.Tables(0)

            cmbLoadTrans.DisplayMember = "LoadingLocationCode"
            cmbLoadTrans.ValueMember = "LoadingLocationID"

            'Trans CPO
            cmbTransTank.DataSource = Nothing
            Dim dsTransTank As DataSet
            dsTransTank = TranshipmentCPOBOL.loadCmbLocation()

            cmbTransTank.DataSource = dsTransTank.Tables(1)
            cmbTransTank.DisplayMember = "LoadingLocationCode"
            cmbTransTank.ValueMember = "LoadingLocationID"


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
            Dim objCPOPPT As New TranshipmentCPOPPT
            objCPOPPT.CropYieldCode = lCropYieldCode
            If objCPOPPT.CropYieldCode <> String.Empty Then
                dsCrop = TranshipmentCPOBOL.GetCropYieldID(objCPOPPT)
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
            Dim objCPOPPT As New TranshipmentCPOPPT
            objCPOPPT.TankID = lTankID
            If objCPOPPT.TankID <> String.Empty Then
                dsCropID = TranshipmentCPOBOL.GetCropYield(objCPOPPT)
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
        'If dtpCPODate.Text.Trim = String.Empty Then
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
            ''MessageBox.Show("This Field is Required", "Transhipment", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            ''MessageBox.Show("Loading and Transhipment cant be same ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        ''''For Stock CPO
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
        ' CPOGetLoadTransMonthQty()
        If GlobalPPT.strLang = "en" Then
            btnAddTrans.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddTrans.Text = "Menambahkan"
        End If
        '' btnAddTrans.Text = "Add"
        btnAddTransFlag = True
        lTransferQtyPrev = 0
        'btnSaveAll.Enabled = True
        'btnDeleteAll.Enabled = True

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub
    Public Sub ResetMain()

        ' btnAddFlag = True
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Public Sub Reset()

        dtpCPODate.Enabled = True

        '''' For Trans CPO
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
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


        ClearGridView(dgvTransCPODetails)

        DeleteMultientryTransCPO.Clear()


        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''
        MonthCount = False
        YearCount = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvTransCPOView.Rows.Count > 0 Then

            ''''For  Transhipment CPO''''''
            txtTransMonthToDate.Enabled = False
        Else

            ''''For  Transhipment CPO''''''
            txtTransMonthToDate.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub CPOGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objCPOPPT As New TranshipmentCPOPPT
            objCPOPPT.CPODate = dtpCPODate.Value
            'loadCmbStorage()
            With objCPOPPT
                If chkCPODate.Checked = True Then
                    dtpCPOViewDate.Enabled = True
                    .CPODate = dtpCPOViewDate.Value 'Format(Me.dtpCPOViewDate.Value, "MM/dd/yyyy")

                    dtpCPOViewDate.MinDate = GlobalPPT.FiscalYearFromDate
                    dtpCPOViewDate.MaxDate = GlobalPPT.FiscalYearToDate
                    Dim TempDate As Date = dtpCPOViewDate.Value
                    Dim NowDate As Date = Now()
                    If Now() >= GlobalPPT.FiscalYearFromDate And dtpCPOViewDate.Value <= GlobalPPT.FiscalYearFromDate Then
                        dtpCPOViewDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
                    End If

                    Dim ToDate As Date = dtpCPOViewDate.Value
                    dtpCPOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

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
            dt = TranshipmentCPOBOL.GetCPODetails(objCPOPPT)
            'If dt.TableName.Count <> 0 Then
            If dt.Rows.Count <> 0 Then
                dgvTransCPOView.AutoGenerateColumns = False
                Me.dgvTransCPOView.DataSource = dt
                'Dim i As Integer = dgvTransCPOView.Rows.Count
                'lLoadMonthToDate = dgvTransCPOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value
                'lTransMonthToDate = dgvTransCPOView.Rows(i - 1).Cells("gvTransMonthToDate").Value
                'MsgBox(dgvTransCPOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value)
            Else
                ClearGridView(dgvTransCPOView) '''''clear the records from grid view
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

        If dgvTransCPOView.Rows.Count > 0 Then

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
            Dim objCPOPPT As New TranshipmentCPOPPT
            Dim objCPOBOL As New TranshipmentCPOBOL
            Dim dt As New DataTable

            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If

            lresetLoad = True
            lresetTrans = True

            objCPOPPT.CropYieldID = lCropYieldID
            '  objCPOPPT.ProductionID = lProductionID
            Dim str As String = Me.dgvTransCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

            'objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            'str = str.Substring(6, 4) & "/" & str.Substring(3, 2) & "/" & str.Substring(0, 2)

            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)
            objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

            dtpCPODate.Value = objCPOPPT.CPODate
            'CPOGetMonthYearQty()
            'CPOGetTodayQty()
            'CPOGetLoadTransMonthQty()


            '''' For Trans CPO'''
            dtTransCPOAdd = TranshipmentCPOBOL.GetCPOAddTransInfo(objCPOPPT)
            dgvTransCPODetails.AutoGenerateColumns = False
            SaveFlag = False
            dgvTransCPODetails.DataSource = dtTransCPOAdd
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            CPOGridViewBind()
            Me.tcTransCPO.SelectedTab = tpCPOSave
            btnSaveAll.Enabled = False
            btnDeleteAll.Enabled = False
            'Else
            'MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If dgvTransCPOView.RowCount > 0 Then



            rowid = dgvTransCPOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then


                Dim objCPOPPT As New TranshipmentCPOPPT
                Dim objCPOBOL As New TranshipmentCPOBOL
                Dim str As String = Me.dgvTransCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

                '            objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                objCPOPPT.CropYieldID = lCropYieldID
                dtpCPODate.Value = objCPOPPT.CPODate

                objEditDuplicateSearchRecord = objCPOBOL.TransSearchDateCheck(objCPOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objCPOBOL.EditDateCheck(objCPOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateCPOView()
                        btnSaveAll.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateCPOView()
                        btnSaveAll.Enabled = True
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
                UpdateCPOView()
            End If
        End If
    End Sub


    Public Sub GetTankID(ByVal lTankNo As String)
        Try
            Dim dsLoad As DataSet
            Dim objCPOPPT As New TranshipmentCPOPPT
            Dim objCPOBOL As New TranshipmentCPOBOL
            objCPOPPT.TankNo = lTankNo
            dsLoad = TranshipmentCPOBOL.GetTankID(objCPOPPT)
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
            Dim objCPOPPT As New TranshipmentCPOPPT
            objCPOPPT.Descp = lLocation
            dsLocation = TranshipmentCPOBOL.GetLocationID(objCPOPPT)
            If dsLocation.Tables.Count <> 0 Then
                If dsLocation.Tables(0).Rows.Count <> 0 Then
                    lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                    lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    
    Private Sub dgvTransCPOView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateCPOView()
            End If
        End If


    End Sub

    Private Sub DeleteCPOVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))

        Me.cmsCPO.Visible = False

        Dim objCPOPPT As New TranshipmentCPOPPT
        Dim objCPOBOL As New TranshipmentCPOBOL
        ' Dim dt As New DataTable
        If dgvTransCPOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim str As String = Me.dgvTransCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

                'objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
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
        If dgvTransCPOView.RowCount > 0 Then


            rowid = dgvTransCPOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objCPOPPT As New TranshipmentCPOPPT
                Dim objCPOBOL As New TranshipmentCPOBOL
                Dim str As String = Me.dgvTransCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

                'objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objCPOPPT.CropYieldID = lCropYieldID
                dtpCPODate.Value = objCPOPPT.CPODate

                objDeleteDuplicateSearchRecord = objCPOBOL.TransSearchDateCheck(objCPOPPT)
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
        tcTransCPO.SelectedTab = tpCPOSave
        ResetTrans()
    End Sub

    Private Sub TransTankMonthtoDate()
        If cmbTransTank.SelectedIndex <> 0 And cmbLoadTrans.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsTransMonthTodate As New DataSet
            txtTransMonthToDate.Text = ""
            txtTransQty.Text = ""
            TransMonthCount = 0
            Dim objCPOPPT As New TranshipmentCPOPPT
            objCPOPPT.TankID = cmbTransTank.SelectedValue.ToString
            objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpCPODate.Value
            dsTransMonthTodate = TranshipmentCPOBOL.CPOGetTranshipCPOMonthtodate(objCPOPPT)

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
        'Dim objCPOPPT As New CPOProductionPPT
        'lTransTankID = lTankID

        'objCPOPPT.TankID = cmbTransTank.SelectedValue.ToString
        'objCPOPPT.ProductionID = lProdIdNew
        'Dim objCPOBOL As New CPOProductionBOL
        'objCPOPPT.CropYieldID = lCropYieldID
        'objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
        'objCPOPPT.CPODate = dtpCPODate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objCPOBOL.DuplicateTransLocationFirstCheck(objCPOPPT)
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
        '    dsCrop = CPOProductionBOL.CPOGetTransVsLocMonthQty(objCPOPPT)
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
            'Dim objCPOPPT As New CPOProductionPPT
            'lTransLocationID = lLocationID
            ''lblTransDescription.Text = lLocationDesc
            'objCPOPPT.TransLocationID = lLocationID
            'objCPOPPT.TankID = cmbLoadTrans.SelectedValue.ToString
            'objCPOPPT.CPODate = dtpCPODate.Value
            'Dim objCPOBOL As New CPOProductionBOL

            'objCPOPPT.ProductionID = lProdIdNew
            'objCPOPPT.CropYieldID = lCropYieldID
            'objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString

            'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
            '    Dim objCheckDuplicateLoadLocation As Object = 0
            '    objCheckDuplicateLoadLocation = objCPOBOL.DuplicateTransLocationFirstCheck(objCPOPPT)
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
            '    dsCrop = CPOProductionBOL.CPOGetTransVsLocMonthQty(objCPOPPT)
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
        If dgvTransCPODetails.RowCount > 0 And btnSaveAll.Enabled = True Then
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
        If chkCPODate.Checked = False Then
            DisplayInfoMessage("Msg32")
            ''MsgBox("Please Enter Criteria to Search!")
            CPOGridViewBind()

        Else
            CPOGridViewBind()
            If dgvTransCPOView.RowCount = 0 Then
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
    
    Private Sub dgvTransCPOView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransCPOView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSaveAll.Enabled = True
            Else
                btnSaveAll.Enabled = False
                Exit Sub
            End If
        End If
        If dgvTransCPOView.RowCount > 0 Then
            If (e.RowIndex = 0) Then

                rowid = e.RowIndex
                Dim objCPOPPT As New TranshipmentCPOPPT
                Dim objCPOBOL As New TranshipmentCPOBOL
                Dim str As String = Me.dgvTransCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()

                'objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                'str = str.Substring(5, 4) & "/" & str.Substring(3, 2) & "/" & str.Substring(0, 2)

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objCPOPPT.CPODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objCPOPPT.CropYieldID = lCropYieldID
                dtpCPODate.Value = objCPOPPT.CPODate

                objEditDuplicateSearchRecord = objCPOBOL.TransSearchDateCheck(objCPOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objCPOBOL.EditDateCheck(objCPOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdateCPOView()
                        btnSaveAll.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdateCPOView()
                        btnSaveAll.Enabled = True
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
    Private Sub SaveTransCPODetail()
        Try
            Dim objCPOPPT As New TranshipmentCPOPPT
            Dim objCPOBOL As New TranshipmentCPOBOL

            Dim intRowcount As Integer = dtTransCPOAdd.Rows.Count

            'CPOGetTodayQty()

            If Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, dtpCPODate.Value) Then 'Location, Tank Validation 

                'objCPOPPT.CropYieldID = lCropYieldID
                ''Dim objCheckDuplicateRecord As Object = 0
                'objCPOPPT.CPODate = dtpCPODate.Value
                ''objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)


                'objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
                'objCPOPPT.TankID = cmbTransTank.SelectedValue.ToString


                'Dim objCheckDuplicateLoadLocation As Object = 0
                'objCheckDuplicateLoadLocation = objCPOBOL.DuplicateTransLocationCheck(objCPOPPT)
                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If


                rowTransCPOAdd = dtTransCPOAdd.NewRow()

                If intRowcount = 0 And dtTransAddFlag = False Then
                    Try

                        columnTransCPOAdd = New DataColumn("TransTankNo", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)
                        columnTransCPOAdd = New DataColumn("TransLocation", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)
                        columnTransCPOAdd = New DataColumn("TransQty", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)
                        columnTransCPOAdd = New DataColumn("TransMonthToDate", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)
                        columnTransCPOAdd = New DataColumn("TransTankID", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)
                        columnTransCPOAdd = New DataColumn("TransLocationID", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        columnTransCPOAdd = New DataColumn("TransRemarks", System.Type.[GetType]("System.String"))
                        dtTransCPOAdd.Columns.Add(columnTransCPOAdd)

                        rowTransCPOAdd("TransTankNo") = Me.cmbTransTank.Text
                        rowTransCPOAdd("TransLocation") = Me.cmbLoadTrans.Text

                        If Me.txtTransQty.Text <> String.Empty Then
                            rowTransCPOAdd("TransQty") = Me.txtTransQty.Text
                        End If
                        If Me.txtTransMonthToDate.Text <> String.Empty Then
                            rowTransCPOAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                        End If

                        rowTransCPOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                        rowTransCPOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowTransCPOAdd("TransRemarks") = txtTransRemarks.Text.Trim
                        dtTransCPOAdd.Rows.InsertAt(rowTransCPOAdd, intRowcount)
                        dtTransAddFlag = True

                    Catch ex As Exception
                        rowTransCPOAdd("TransTankNo") = Me.cmbTransTank.Text
                        rowTransCPOAdd("TransLocation") = Me.cmbLoadTrans.Text

                        If Me.txtTransQty.Text <> String.Empty Then
                            rowTransCPOAdd("TransQty") = Me.txtTransQty.Text
                        End If
                        If Me.txtTransMonthToDate.Text <> String.Empty Then
                            rowTransCPOAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                        End If
                        rowTransCPOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                        rowTransCPOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowTransCPOAdd("TransRemarks") = txtTransRemarks.Text.Trim
                        dtTransCPOAdd.Rows.InsertAt(rowTransCPOAdd, intRowcount)

                    End Try


                Else
                    rowTransCPOAdd("TransTankNo") = Me.cmbTransTank.Text
                    rowTransCPOAdd("TransLocation") = Me.cmbLoadTrans.Text

                    If Me.txtTransQty.Text <> String.Empty Then
                        rowTransCPOAdd("TransQty") = Me.txtTransQty.Text
                    End If
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowTransCPOAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                    End If
                    rowTransCPOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                    rowTransCPOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                    '''''''''''''''''''''''''''''''''''
                    '''''''''''''For Remarks
                    rowTransCPOAdd("TransRemarks") = txtTransRemarks.Text.Trim
                    dtTransCPOAdd.Rows.InsertAt(rowTransCPOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry this Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvTransCPODetails
                .DataSource = dtTransCPOAdd
                .AutoGenerateColumns = False
            End With




        Catch ex As Exception
        End Try

    End Sub


    Private Function LocationExistTrans(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvTransCPODetails.Rows
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

    Private Sub UpdateTransCPODetails()
        Try
            Dim intCount As Integer = dgvTransCPODetails.CurrentRow.Index

            If lTransTank = cmbTransTank.Text And lloadTrans = cmbLoadTrans.Text Then
                ' If lTempTankNo = cmbStockTank.Text Then

                'StrAdjustDate = Me.dtpAdjustmentDate.Text
                'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                'dgvCPODetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate

                dgvTransCPODetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvTransCPODetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If
                If Me.txtTransQty.Text <> Nothing Then
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If

                dgvTransCPODetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvTransCPODetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString
                dgvTransCPODetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim

                'If Me.txtMoisture.Text <> Nothing Then
                '    dgvCPODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                'End If

                'dgvCPODetails.Rows(intCount).Cells("dgclStockTankID").Value = lStockTankID
                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                ''btnAddTrans.Text = "Add"
                btnTransAddFlag = True
                'clear()

            ElseIf Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, CPODate) Then
                dgvTransCPODetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvTransCPODetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If
                If Me.txtTransQty.Text <> Nothing Then
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransCPODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If


                dgvTransCPODetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvTransCPODetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString
                dgvTransCPODetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim
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

    Private Sub BindDgvTransCPODetails()
        If dgvTransCPODetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddTrans.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddTrans.Text = "Memperbarui"
            End If
            ''Me.btnAddTrans.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddTransFlag = False

            cmbTransTank.Text = dgvTransCPODetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            lTransTank = dgvTransCPODetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            cmbLoadTrans.Text = dgvTransCPODetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()
            lloadTrans = dgvTransCPODetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()

            If Not dgvTransCPODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is DBNull.Value Then
                lProdTranshipID = dgvTransCPODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value
            Else
                lProdTranshipID = Nothing
            End If

            If Not dgvTransCPODetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtTransQty.Text = dgvTransCPODetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
                lTransferQtyPrev = dgvTransCPODetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
            End If

            If Not dgvTransCPODetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtTransMonthToDate.Text = dgvTransCPODetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString()
            End If
            ' AddFlag = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Remarks Fields Add'''''''''''''''''
            txtTransRemarks.Text = dgvTransCPODetails.SelectedRows(0).Cells("dgclTransRemarks").Value.ToString()

        End If

    End Sub

    Private Sub dtpCPODate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCPODate.ValueChanged

        Dim objCPOPPT As New TranshipmentCPOPPT
        Dim objCPOBOL As New TranshipmentCPOBOL

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

    Private Sub dgvTransCPOView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTransCPOView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateCPOView()
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

                    SaveTransCPODetail()
                    'If dgvTransCPODetails.Rows.Count <> 0 Then
                    '    For Each objDataGridViewRow In dgvTransCPODetails.Rows
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
                    UpdateTransCPODetails()
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

        
        AddTrans_Clicked()



        'TransferQtyCheck()

        
    End Sub

    Private Sub dgvTransCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransCPODetails.CellDoubleClick

        BindDgvTransCPODetails()

    End Sub

    Private Sub btnResetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetTrans.Click
        ResetTrans()
    End Sub

    Private Sub TransferQtyCheck()
        lTransferQty = 0

        If dgvTransCPODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvTransCPODetails.Rows
                If objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclTransStorageID").Value.ToString = cmbTransTank.SelectedValue.ToString Then
                    lTransferQty = lTransferQty + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
                End If
            Next
        End If

        lTransferQty = lTransferQty + Val(txtTransQty.Text) - lTransferQtyPrev



    End Sub

    Private Sub tcTransCPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransCPO.SelectedIndexChanged
        'ResetMain()
        ' Reset()
        'ResetLoad()
        ' ResetTrans()
        CPOGridViewBind()
    End Sub
    Private Sub tcTransCPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransCPO.Click

        If dgvTransCPODetails.RowCount > 0 And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcTransCPO.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ' ResetMain()
                Reset()
                'ResetLoad()
                ResetTrans()
                CPOGridViewBind()


            End If
        Else
            'ResetMain()
            Reset()
            'ResetLoad()
            ResetTrans()
            CPOGridViewBind()


        End If
    End Sub
    Private Sub txtTransMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransMonthToDate.TextChanged
        If Val(txtTransMonthToDate.Text) = 0 Then
            txtTransMonthToDate.Text = ""
        End If
    End Sub

    Private Sub TranshipEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipEdit.Click
        BindDgvTransCPODetails()
    End Sub

    Private Sub TranshipDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipDelete.Click
        If dgvTransCPODetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvTransCPODetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridTranshipCPO()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridTranshipCPO()

        If Not dgvTransCPODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is Nothing Then
            lProdTranshipID = dgvTransCPODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value.ToString
        Else
            lProdTranshipID = String.Empty
        End If



        lDelete = 0
        If lProdTranshipID <> "" Then
            lDelete = DeleteMultientryTransCPO.Count
            DeleteMultientryTransCPO.Insert(lDelete, lProdTranshipID)
        End If
        Dim Dr As DataRow
        Dr = dtTransCPOAdd.Rows.Item(dgvTransCPODetails.CurrentRow.Index)
        Dr.Delete()
        dtTransCPOAdd.AcceptChanges()
        lProdTranshipID = ""


    End Sub

    Private Sub DeleteMultiEntryRecordsTranshipCPO()
        Dim objCPOProductionPPT As New TranshipmentCPOPPT
        lDelete = DeleteMultientryTransCPO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdTranshipID = DeleteMultientryTransCPO(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = TranshipmentCPOBOL.DeleteMultiEntryProdTranship(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objCPOPPT As New TranshipmentCPOPPT
        Dim objCPOBOL As New TranshipmentCPOBOL
        If dgvTransCPOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If lProductionID <> String.Empty Then
                objCPOPPT.CPODate = dtpCPODate.Value
                objCPOPPT.CropYieldID = lCropYieldID
                objCPOBOL.Delete_CPODetail(objCPOPPT)
                CPOGridViewBind()
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
                ''MsgBox("No Record in Crop yield for CPO, Please insert the record in General Crop Yield")
                Exit Sub
            End If

            If dgvTransCPODetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If
                If SaveFlag = True Then

                    Dim objCPOPPT As New TranshipmentCPOPPT
                    Dim objCPOBOL As New TranshipmentCPOBOL


                    Dim objCheckDuplicateRecord As Object = 0
                    objCPOPPT.CPODate = dtpCPODate.Value
                    objCPOPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    Else
                        objCompareDateCheck = objCPOBOL.CompareCPOPTransDateIsExist(objCPOPPT)
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
                    ' dsID = TranshipmentCPOBOL.saveCPOProduction(objCPOPPT)
                    'If dsID.Tables.Count <> 0 Then
                    '    If dsID.Tables(0).Rows.Count <> 0 Then
                    '        lProductionID = dsID.Tables(0).Rows(0).Item("ProductionID")
                    '    Else
                    '        lProductionID = Nothing
                    '    End If
                    'End If

                    'objCPOPPT.ProductionID = lProductionID


                    For Each DataGridViewRowTrans In dgvTransCPODetails.Rows

                        ''''For Trans CPO''''''''

                        If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objCPOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                        Else
                            objCPOPPT.TransTankID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                            objCPOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                        Else
                            objCPOPPT.TransLocationID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                            objCPOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objCPOPPT.TransQty = 0.0
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value Then
                            'Dim lTransMonthdate As String
                            'Dim lTransQty As String
                            objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                            'lTransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                            'objCPOPPT.TransMonthToDate = Val(lTransMonthdate) ''''+ Val(lTransQty)
                        Else
                            objCPOPPT.TransMonthToDate = 0.0
                            'objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTransQuantity").Value
                        End If
                        '''''''For Remarks'''''''''''''''''''''''''
                        objCPOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''
                        objCPOPPT.CropYieldID = lCropYieldID
                        TranshipmentCPOBOL.saveCPOTransProduction(objCPOPPT)
                        '   CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                    Next


                    CPOGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()

                    ResetTrans()
                    GlobalPPT.IsRetainFocus = False
                    'SaveFlag = False
                Else

                    Dim objCPOPPT As New TranshipmentCPOPPT
                    Dim objCPOBOL As New TranshipmentCPOBOL
                    'Dim StrCPODate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvCPODetails.Rows

                    objCPOPPT.CropYieldID = lCropYieldID
                    'CPOGetMonthYearQty()
                    'CPOGetTodayQty()
                    'CPOGetLoadTransMonthQty()

                    objCPOPPT.CPODate = dtpCPODate.Value

                    'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    ' objCPOPPT.ProductionID = DataGridViewRowMain.Cells("dgclProductionID").Value.ToString
                    'If DataGridViewRowMain.Cells("dgclProductionID").Value.ToString = String.Empty Then
                    'If lProdIdNew = String.Empty Then
                    '    CPOProductionBOL.saveCPOProduction(objCPOPPT)
                    'Else
                    '    CPOProductionBOL.UpdateCPOProduction(objCPOPPT)
                    'End If

                    ' Next


                    For Each DataGridViewRowTrans In dgvTransCPODetails.Rows

                        ''''For Trans CPO''''''''

                        If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objCPOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                        Else
                            objCPOPPT.TransTankID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                            objCPOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                        Else
                            objCPOPPT.TransLocationID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                            objCPOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objCPOPPT.TransQty = 0.0
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then 'DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value And 
                            Dim lLoadMonthdate As String
                            Dim lLoadQty As String
                            lLoadMonthdate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                            lLoadQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                            objCPOPPT.TransMonthToDate = Val(lLoadMonthdate) '+ Val(lLoadQty)

                            'objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objCPOPPT.TransMonthToDate = 0.0
                        End If

                        objCPOPPT.CropYieldID = lCropYieldID

                        '''''''''''''''''''''''''''''''''''''''
                        ''''For Remarks
                        objCPOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString


                        If Not (DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value) Then
                            objCPOPPT.ProdTranshipID = DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value
                        Else
                            objCPOPPT.ProdTranshipID = String.Empty
                        End If

                        If DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value.ToString = String.Empty Then
                            TranshipmentCPOBOL.saveCPOTransProduction(objCPOPPT)
                        Else
                            TranshipmentCPOBOL.UpdateCPOTransProduction(objCPOPPT)
                        End If

                    Next


                    DeleteMultiEntryRecordsTranshipCPO()

                    ' CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    CPOGridViewBind()
                    Reset()


                    ResetTrans()
                    SaveFlag = True
                    GlobalPPT.IsRetainFocus = False
                End If
                ClearGridView(dgvTransCPODetails)
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objCPOPPT As New TranshipmentCPOPPT
            Dim objCPOBOL As New TranshipmentCPOBOL

            objCPOPPT.CPODate = dtpCPODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            ' objCPOBOL.Delete_CPODetail(objCPOPPT)
            CPOGridViewBind()
        End Try
    End Sub

    Private Sub PnlSearch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PnlSearch.Paint

    End Sub
End Class