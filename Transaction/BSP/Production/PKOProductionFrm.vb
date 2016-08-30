Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class PKOProductionFrm
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
    Public isDecimal As Boolean

    ''For Stock PKO

    Public btnAddFlag As Boolean = True
    Dim columnPKOAdd As DataColumn
    Dim rowPKOAdd As DataRow
    Dim dtPKOAdd As New DataTable("todgvPKOAdd")
    Public dtAddFlag As Boolean = False
    Private lPrevdayPontoonQty As Decimal = 0
    ''Load PKO'''
    Public btnAddLoadFlag As Boolean = True
    Dim columnLoadPKOAdd As DataColumn
    Dim rowLoadPKOAdd As DataRow
    Dim dtLoadPKOAdd As New DataTable("todgvLoadCPOAdd")
    Public dtLoadAddFlag As Boolean = False
    'Public AddFlag As Boolean = True

    '' Trans PKO'''
    Public btnAddTransFlag As Boolean = True
    Dim columnTransPKOAdd As DataColumn
    Dim rowTransPKOAdd As DataRow
    Dim dtTransPKOAdd As New DataTable("todgvTransCPOAdd")
    Public dtTransAddFlag As Boolean = False

    Public CPODate As Date
    Public AddFlag As Boolean = True
    Public isModifierKey As Boolean
    Public lProdCurrentReading As Double = 0.0
    Public lProdStockID As String = String.Empty
    Public lProdTranshipID As String = String.Empty
    Public lProdLoadingID As String = String.Empty

    Public lLoadTank As String
    Public lLoadLocation As String
    Public lTransTank As String
    Public lloadTrans As String
    Public lProdIdNew As String
    Public lTempTankNo As String
    Public lresetLoad As Boolean = True
    Public lresetTrans As Boolean = True

    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Public lCropYieldCode As String = String.Empty
    Public lLocationDesc As String = String.Empty
    Public lLoadVsLoc As String = String.Empty

    Public lCurrentReadingToday As Double = 0.0
    Public lLoadQtyToday As Double = 0.0
    Public lTransQtyToday As Double = 0.0

    Public lBalanceToday As Double = 0.0
    Public lTodayQty As Double = 0.0
    Dim lProductionToday As Decimal = 0
    Dim dsStockTankNo As New DataSet
    Dim dsLoadTankNo As New DataSet
    Dim dsTransTankNo As New DataSet
    Dim dsStockViewTankNo As DataSet
    Dim lLoadCapacity As Decimal = 0
    Dim lTransCapacity As Decimal = 0
    Dim lLoadQty, lTransferQty As Decimal
    Dim lLoadQtyPrev As Decimal = 0
    Dim lTransferQtyPrev As Decimal = 0
    Dim lProductionMonth As Decimal = 0
    Dim lProductionYear As Decimal = 0
    Dim MonthCount As Integer
    Dim YearCount As Integer
    Private LoadMonthCount As Integer
    Private TransMonthCount As Integer
    Public lLoadMonthToDate As Double = 0.0
    Public lTransMonthToDate As Double = 0.0
    Private lQtyPrev As Decimal = 0

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Dim DeleteMultientryStockPKO As New ArrayList
    Dim DeleteMultientryLoadPKO As New ArrayList
    Dim DeleteMultientryTransPKO As New ArrayList
    Dim lDelete As Integer
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))
    Dim lPrevDayQtyLoad As Decimal = 0
    Dim lTotalTranshipQty As Decimal = 0
    Dim LbtnPKOLoadadd As Boolean = True
    Shadows mdiparent As New MDIParent

    Private Sub PKOProductionFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (dgvPKODetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M90"

            End If
        End If
    End Sub

    Private Sub PKOProductionFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PKOProductionFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        Reset()
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        Try
            'Dim ToDate As Date = Date.Today
            'dtpPKODate.Value = ToDate
            'dtpPKOViewDate.Value = Date.Today
            'dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
            'tcPKOProduction.SelectedTab = tpPKOView
            ' CPOProductionMonthYearSelect()
            'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKODate)
            'FormatDateTimePicker(dtpPKODate)
            'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)
            'FormatDateTimePicker(dtpPKOViewDate)

            Dim objPKOPPT As New PKOProductionPPT
            Dim dsCrop As New DataSet
            dsCrop = PKOProductionBOL.ProductionCropYieldIDSelect(objPKOPPT)
            If dsCrop.Tables(0).Rows.Count <> 0 Then
                lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
            Else
                DisplayInfoMessage("Msg1")
                ''MsgBox("No Record in Crop yield for PKO , Please insert the record in General Crop Yield")
                Me.Close()
            End If
            loadCmbStorage()
            loadCmbLocation()
            dtpPKOViewDate.Enabled = False
            cmbStockTank.Text = "Select All"
            ' dtpCPODate.Text = Format(Today, "dd/MM/yyyy")
            cmbLoadTank.Text = "Select All"
            cmbTransTank.Text = "Select All"
            cmbLoadLocation.Text = "Select All"
            cmbLoadTrans.Text = "Select All"
            lCropYieldCode = "PKO"
            GetCropYieldID()
            objPKOPPT.CropYieldID = lCropYieldID
            'CPOGetLoadTransMonthQty()
            'PKOGetMonthYearQty()
            'PKOGetTodayQty()
            tcPKOProduction.SelectedIndex = 1
            ' UpdateTankMasterBFQty()
            cmbStockTank.SelectedIndex = 0
            'cmbViewTankNo.SelectedIndex = 0
            PKOGridViewBind()
        Catch ex As Exception
            DisplayInfoMessage("Msg2")
            '' MessageBox.Show("There is No Tank for This Estate")
        End Try
    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        '   Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'chkPKODate.Text = rm.GetString("ProductionDate")
            ''Label45.Text = rm.GetString("SearchBy")

            'tcPKOProduction.TabPages("tpPKOSave").Text = rm.GetString("tcPKOProduction.TabPages(tpPKOSave).Text")
            'tcPKOProduction.TabPages("tpPKOView").Text = rm.GetString("tcPKOProduction.TabPages(tpPKOView).Text")

            'PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText")
            'lblProductionDate.Text = rm.GetString("ProductionDate")

            'grpStockPKO.Text = rm.GetString("grpStockPKO.Text")
            'grpStockPKORecords.Text = rm.GetString("grpStockPKORecords.Text")
            'grpLoadPKO.Text = rm.GetString("grpLoadPKO.Text")
            'grpTranshipPKO.Text = rm.GetString("grpTranshipPKO.Text")
            'gpLoadPKO.Text = rm.GetString("grpLoadPKORecords.Text")
            'grpTransPKORecords.Text = rm.GetString("grpTransPKORecords.Text")
            'grpProPKORecords.Text = rm.GetString("grpProPKORecords.Text")

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

            btnResetLoad.Text = rm.GetString("Reset")
            btnResetTrans.Text = rm.GetString("Reset")
            btnResetMain.Text = rm.GetString("Reset")
            btnReset.Text = rm.GetString("ResetAll")

            btnAdd.Text = rm.GetString("Add")
            btnAddLoad.Text = rm.GetString("Add")
            btnAddTrans.Text = rm.GetString("Add")
            btnSaveAll.Text = rm.GetString("SaveAll")

            btnClose.Text = rm.GetString("Close")


            'dgvPKODetails.Columns("dgclStorage").HeaderText = rm.GetString("Storage")
            'dgvPKODetails.Columns("dgclBalance").HeaderText = rm.GetString("Balance B/F(MT)")
            'dgvPKODetails.Columns("dgclCapacity").HeaderText = rm.GetString("Capacity (Mt)")
            'dgvPKODetails.Columns("dgclCurrentReading").HeaderText = rm.GetString("Current Reading (Mt)")
            'dgvPKODetails.Columns("dgclMeasurement").HeaderText = rm.GetString("Measurement (Cm)")
            'dgvPKODetails.Columns("dgclTemperature").HeaderText = rm.GetString("Temperature")
            'dgvPKODetails.Columns("dgclFFA").HeaderText = rm.GetString("FFA")
            'dgvPKODetails.Columns("dgclMoisture").HeaderText = rm.GetString("Moisture")


            ' ''lblLoadStorage.Text = rm.GetString("Storage")
            ''lblTransStorage.Text = rm.GetString("Storage")
            ''lblLoadQty.Text = rm.GetString("Quantity")
            ''lblTransQty.Text = rm.GetString("Quantity")
            ''lblToLoading.Text = rm.GetString("To Loading")
            ''Label5.Text = rm.GetString("Remarks")
            ''lblLoadMonthDate.Text = rm.GetString("Month Todate")
            ''lblTransToLoading.Text = rm.GetString("Transshipment")
            ''Label8.Text = rm.GetString("Remarks")
            ''lblTransMonthDate.Text = rm.GetString("Month Todate")

            btnAddTrans.Text = rm.GetString("Add")
            btnResetTrans.Text = rm.GetString("Reset")


            'dgvLoadCPODetails.Columns("dgclLoadStorageNo").HeaderText = rm.GetString("Storage")
            'dgvLoadCPODetails.Columns("dgclToLoading").HeaderText = rm.GetString("To Loading")
            'dgvLoadCPODetails.Columns("dgclLoadQuantity").HeaderText = rm.GetString("Quantity")
            'dgvLoadCPODetails.Columns("dgclLoadMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvLoadCPODetails.Columns("dgclLoadRemarks").HeaderText = rm.GetString("Remarks")

            'dgvPKOTransDetails.Columns("dgclTransStorageNo").HeaderText = rm.GetString("Storage")
            'dgvPKOTransDetails.Columns("dgclTranshipLoad").HeaderText = rm.GetString("Transshipment")
            'dgvPKOTransDetails.Columns("dgclTranshipQuantity").HeaderText = rm.GetString("Quantity")
            'dgvPKOTransDetails.Columns("dgclTransMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvPKOTransDetails.Columns("dgclTransRemarks").HeaderText = rm.GetString("Remarks")


            ''lblProStorage.Text = rm.GetString("Storage")
            ''lblProToday.Text = rm.GetString("Today")
            ''lblProMonthdate.Text = rm.GetString("Month Todate")
            ''lblProYeardate.Text = rm.GetString("YearTodate")

            'dgvPKOView.Columns("gvPKODate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")
            btnView.Text = rm.GetString("ViewReports")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    'Private Sub CPOGetLoadTransMonthQty()
    '    Try
    '        Dim objCPOPPT As New CPOProductionPPT
    '        Dim dsTransLoad As DataSet
    '        lCropYieldID = "M2"
    '        objCPOPPT.CropYieldID = lCropYieldID
    '        objCPOPPT.CPODate = dtpPKODate.Value
    '        dsTransLoad = CPOProductionBOL.CPOGetLoadTransMonthQty(objCPOPPT)
    '        If dsTransLoad.Tables.Count <> 0 Then
    '            If dsTransLoad.Tables(0).Rows.Count <> 0 Then
    '                If Not dsTransLoad.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '                    Me.txtLoadMonthToDate.Text = dsTransLoad.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    Me.txtLoadMonthToDate.Text = 0.0
    '                End If
    '                If Not dsTransLoad.Tables(1).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '                    Me.txtTransMonthToDate.Text = dsTransLoad.Tables(1).Rows(0).Item("MonthTodate")
    '                Else
    '                    Me.txtTransMonthToDate.Text = 0.0
    '                End If
    '            End If
    '        Else
    '            Me.txtLoadMonthToDate.Text = 0.0
    '            Me.txtTransMonthToDate.Text = 0.0
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub CPOGetLoadTransMonthQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim dsTransLoad As DataSet
            ' lCropYieldID = "M1"
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpPKODate.Value
            dsTransLoad = CPOProductionBOL.CPOGetLoadTransMonthQty(objCPOPPT)
            If dsTransLoad.Tables.Count <> 0 Then

                If dsTransLoad.Tables(0).Rows.Count <> 0 Then
                    'If lresetLoad = True Then
                    If Not dsTransLoad.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
                        Me.txtLoadMonthToDate.Text = dsTransLoad.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        Me.txtLoadMonthToDate.Text = 0.0
                    End If
                    'lresetLoad = False
                    'ElseIf lresetTrans = True Then
                    If Not dsTransLoad.Tables(1).Rows(0).Item("MonthTodate") Is DBNull.Value Then
                        Me.txtTransMonthToDate.Text = dsTransLoad.Tables(1).Rows(0).Item("MonthTodate")
                    Else
                        Me.txtTransMonthToDate.Text = 0.0
                    End If
                    ' lresetTrans = False

                    'Else
                    '   Me.txtLoadMonthToDate.Text = 0.0
                    '  Me.txtTransMonthToDate.Text = 0.0
                    'End If
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
            cmbStockTank.DataSource = Nothing


            dsStockTankNo = CPOProductionBOL.loadCmbStorage("PKO")
            dsLoadTankNo = CPOProductionBOL.loadCmbStorage("PKO")
            dsTransTankNo = CPOProductionBOL.loadCmbStorage("PKO")
            dsStockViewTankNo = CPOProductionBOL.loadCmbStorage("PKO")

            If dsStockTankNo.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg3")
                ''MsgBox("No Records Available for Tank Master ,Please insert the Record in Production Tank Master")
            End If

            'Stock CPO Combo
            cmbStockTank.DataSource = dsStockTankNo.Tables(0)
            cmbStockTank.DisplayMember = "TankNo"
            cmbStockTank.ValueMember = "TankID"
            'Load CPO
            cmbLoadTank.DataSource = dsLoadTankNo.Tables(0)
            cmbLoadTank.DisplayMember = "TankNo"
            cmbLoadTank.ValueMember = "TankID"

            ''Stock View CPO Combo
            'cmbViewTankNo.DataSource = dsStockViewTankNo.Tables(0)
            'cmbViewTankNo.DisplayMember = "TankNo"
            'cmbViewTankNo.ValueMember = "TankNo"


            Dim dr As DataRow = dsStockViewTankNo.Tables(0).NewRow()
            dr(0) = "--Select All--"
            dr(1) = "--Select All--"
            dsStockViewTankNo.Tables(0).Rows.InsertAt(dr, 0)
            'dsStockTankNo.AcceptChanges()


            ''''For Stock Tank''''    
            Dim dr1 As DataRow = dsStockTankNo.Tables(0).NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            dsStockTankNo.Tables(0).Rows.InsertAt(dr1, 0)
            'dsStockTankNo.AcceptChanges()

            ''''''For Load Tank'''

            Dim dr2 As DataRow = dsLoadTankNo.Tables(0).NewRow()
            dr2(0) = "--Select--"
            dr2(1) = "--Select--"
            dsLoadTankNo.Tables(0).Rows.InsertAt(dr2, 0)
            'dsStockTankNo.AcceptChanges()
            'dsStockTankNo.AcceptChanges()
            lStockTankID = dsStockTankNo.Tables(0).Rows(0).Item("TankID")
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub loadCmbLocation()
        Try
            cmbLoadLocation.DataSource = Nothing
            Dim dsLoadLocation As DataSet
            dsLoadLocation = CPOProductionBOL.loadCmbLocation()
            'Location CPO Combo
            cbLoading.DataSource = dsLoadLocation.Tables(0)

            cbLoading.DisplayMember = "LoadingLocationCode"
            cbLoading.ValueMember = "LoadingLocationID"


            If dsLoadLocation.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg4")
                ''MsgBox("No Records Available for Loading Location ,Please insert the Record inProduction Loading Location")
            End If

            Dim dr As DataRow = dsLoadLocation.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            dsLoadLocation.Tables(0).Rows.InsertAt(dr, 0)
            cbLoading.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub GetCropYield()
        Try
            Dim dsCrop As New DataSet
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.TankID = lTankID
            If objCPOPPT.TankID <> String.Empty Then
                dsCrop = CPOProductionBOL.GetCropYield(objCPOPPT)
            End If
            If dsCrop.Tables.Count <> 0 Then
                If dsCrop.Tables(0).Rows.Count <> 0 Then
                    lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetCropYieldID()
        Try
            Dim dsCropID As New DataSet
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.CropYieldCode = lCropYieldCode
            If objCPOPPT.CropYieldCode <> String.Empty Then
                dsCropID = CPOProductionBOL.GetCropYieldID(objCPOPPT)
            End If
            If dsCropID.Tables.Count <> 0 Then
                If dsCropID.Tables(0).Rows.Count <> 0 Then
                    lCropYieldID = dsCropID.Tables(0).Rows(0).Item("CropYieldID")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ComboValueSelected()
        Try
            'Dim ds As New DataSet
            Dim objCPOPPT As New CPOProductionPPT
            'objPKOPPT.TankNo = cmbStockTank.SelectedValue
            objCPOPPT.TankID = lStockTankID
            If objCPOPPT.TankID <> String.Empty Then
                tankDetailSelect(objCPOPPT.TankID)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub tankDetailSelect(ByVal lStockTankID As String)
        Try
            Dim ds As New DataSet
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            objCPOPPT.TankID = lStockTankID
            ds = CPOProductionBOL.tankDetailSelect(objCPOPPT)
            If ds.Tables.Count <> 0 Then
                If ds.Tables(0).Rows.Count <> 0 Then
                    lTankID = ds.Tables(0).Rows(0).Item("TankID")
                    'lblBalanceValue.Text = ds.Tables(0).Rows(0).Item("BFQty")
                    'txtBalance.Text = ds.Tables(0).Rows(0).Item("BFQty")
                    lblCapacityValue.Text = ds.Tables(0).Rows(0).Item("Capacity")
                End If
            End If

            objCPOPPT.CropYieldID = lCropYieldID
            Dim objCheckDuplicateTank As Object = 0
            objCheckDuplicateTank = objCPOBOL.DuplicateTankFirstCheck(objCPOPPT)
            If objCheckDuplicateTank = 0 Then
                txtPrevDayReading.Enabled = False
            Else
                txtPrevDayReading.Enabled = True
                txtPrevDayReading.Text = "0.000"
            End If
            UpdateTankMasterBFQty()

        Catch ex As Exception
        End Try
    End Sub
    Private Function IsCheckValidation()
        'If dtpCPODate.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please check Production Date", " Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        If cmbStockTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This Field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStockTank.Focus()
            Return False
        End If

        'If Val(txtCurrentReading.Text) = 0 Then
        '    DisplayInfoMessage("Msg6")
        '    ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtCurrentReading.Focus()
        '    Return False
        'End If

        If Not IsNumeric(txtWriteoff.Text) Then
            MessageBox.Show("Write off value should be numeric", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWriteoff.Focus()
            Return False
        ElseIf CDbl(txtWriteoff.Text) > 0 And txtReason.Text.Length = 0 Then
            MessageBox.Show("Reason should be entered if you have entered the Write off value", "Information not completed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWriteoff.Focus()
            Return False
        End If

        If txtCurrentReading.Text.Trim() = "" Then
            DisplayInfoMessage("Msg92")
            ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrentReading.Focus()
            Return False
        End If

        If txtPrevDayReading.Text = "" Then
            DisplayInfoMessage("Msg161")
            ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrevDayReading.Focus()
            Return False
        End If
        If Val(lblCapacityValue.Text) < Val(txtPrevDayReading.Text) Then
            DisplayInfoMessage("Msg7")
            ''MessageBox.Show("Balance B/F(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrevDayReading.Focus()
            Return False
        End If

        If Val(lblCapacityValue.Text) < Val(txtCurrentReading.Text) Then
            DisplayInfoMessage("Msg8")
            ''MessageBox.Show("Current Reading(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrentReading.Focus()
            Return False
        End If
        'If Val(txtCurrentReading.Text) < Val(txtBalance.Text) Then
        '    MessageBox.Show("Balance B/F(Mt) cant be greater than Current Reading ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtCurrentReading.Focus()
        '    Return False
        'End If

        'If cmbTransTank.Text = "Select All" Then
        '    MessageBox.Show(" Please Select Storage For Trans ", " Tank Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbTransTank.Focus()
        '    Return False
        'End If
        'If cmbLoadLocation.Text = "Select All" Then
        '    MessageBox.Show(" Please Select Location For Load ", " Location Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbLoadLocation.Focus()
        '    Return False
        'End If
        'If cmbLoadTrans.Text = "Select All" Then
        '    MessageBox.Show(" Please Select Location For Trans ", " Location Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbLoadTrans.Focus()
        '    Return False
        'End If
        Return True
    End Function
    Public Sub Reset()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKODate)
        'FormatDateTimePicker(dtpPKODate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)
        'FormatDateTimePicker(dtpPKOViewDate)
        dtpPKODate.Enabled = True
        ''''For Stock PKO
        'cmbStockTank.Text = "Select All"
        lblCapacityValue.Text = ""
        'lblBalanceValue.Text = ""
        txtPrevDayReading.Text = ""
        txtCurrentReading.Text = ""
        txtMeasurement.Text = ""
        txtTemparature.Text = ""
        txtFFA.Text = ""
        txtMoisture.Text = ""
        txtDirt.Text = ""
        Dim ToDate As Date = Date.Today
        dtpPKODate.Value = ToDate
        dtpPKOViewDate.Value = Date.Today
        DtpProductionDate.Value = Date.Today

        dtpPKOViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        dtpPKOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)


        dtpPKODate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        dtpPKODate.Enabled = True
        DtpProductionDate.Enabled = True

        DtpProductionDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        DtpProductionDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)




        'If dgvPKOView.RowCount <> 0 Then
        '    Dim ProdDate As Date
        '    Dim PrdDate() As String
        '    Dim ProdDatestring As String
        '    ProdDatestring = dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value

        '    PrdDate = ProdDatestring.Split("/")

        '    ProdDate = PrdDate(1) + "/" + PrdDate(0) + "/" + PrdDate(2)

        '    dtpPKODate.MinDate = DateAdd(DateInterval.Day, 1, ProdDate)
        'Else
        '    dtpPKODate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        'End If


        dtpPKOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpPKOViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        'For Load PKO
        MonthCount = 0
        YearCount = 0

        '  cmbLoadLocation.Text = ""
        txtLoadQty.Text = ""
        txtLoadMonthToDate.Text = ""

        '''' For Trans PKO

        If cmbLoadTank.Items.Count > 0 Then
            cmbLoadTank.SelectedIndex = 0
        End If
        If cmbTransTank.Items.Count > 0 Then
            cmbTransTank.SelectedIndex = 0
        End If
        If cmbLoadLocation.Items.Count > 0 Then
            cmbLoadLocation.SelectedIndex = 0
        End If
        If cmbLoadTrans.Items.Count > 0 Then
            cmbLoadTrans.SelectedIndex = 0
        End If

        'cmbLoadTrans.Text = ""
        txtTransQty.Text = ""
        txtTransMonthToDate.Text = ""

        '''''For Production PKO

        txtProductionToday.Text = ""
        txtProductionMonth.Text = ""
        txtProductionYear.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        ''btnSaveAll.Text = "Save All"
        SaveFlag = True
        chkPKODate.Checked = False
        dtpPKOViewDate.Enabled = False

        ClearGridView(dgvPKODetails)
        ClearGridView(dgvLoadCPODetails)
        ClearGridView(dgvPKOTransDetails)

        'PKOGetMonthYearQty()
        'CPOGetLoadTransMonthQty()
        'UpdateTankMasterBFQty()
        '''''''''For Very first monthtodate , yeartodate checking'''''

        If dgvPKOView.Rows.Count > 0 Then
            txtProductionMonth.Enabled = False
            txtProductionYear.Enabled = False
        Else
            txtProductionMonth.Enabled = True
            txtProductionYear.Enabled = True
        End If

        DeleteMultientryStockPKO.Clear()
        DeleteMultientryLoadPKO.Clear()
        DeleteMultientryTransPKO.Clear()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvPKOView.Rows.Count > 0 Then
            ''''For Loading CPO'''''''
            txtLoadMonthToDate.Enabled = False
            ''''For  Transhipment CPO''''''
            txtTransMonthToDate.Enabled = False
        Else
            ''''For Loading CPO'''''''
            txtLoadMonthToDate.Enabled = True
            ''''For  Transhipment CPO''''''
            txtTransMonthToDate.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''For Very First Entry for Balance 

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvPKOView.Rows.Count > 0 Then
            ''''For Balance CPO'''''''
            txtPrevDayReading.Enabled = False
        Else
            ''''For Balance CPO'''''''
            txtPrevDayReading.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '  Dim objCPOPPT As New CPOProductionPPT
        'Dim objCPOBOL As New CPOProductionBOL

        'Dim objCheckDuplicateRecord As Object = 0
        'objCPOPPT.CPOProductionDate = DtpProductionDate.Value
        'objCPOPPT.CropYieldID = lCropYieldID
        'objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

        'If objCheckDuplicateRecord = 0 Then
        '    GetProductionID(dtpPKODate.Value)
        '    SaveFlag = False
        'Else
        '    SaveFlag = True
        '    'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
        '    'Exit Sub
        'End If
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Private Sub PKOGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objPKOPPT As New CPOProductionPPT
            objPKOPPT.CPOProductionDate = dtpPKOViewDate.Value
            With objPKOPPT
                If chkPKODate.Checked = True Then
                    dtpPKOViewDate.Enabled = True
                    .CPOProductionDate = dtpPKOViewDate.Value 'Format(Me.dtpPKOViewDate.Value, "MM/dd/yyyy")
                Else
                    dtpPKOViewDate.Enabled = False
                    .CPOProductionDate = Nothing
                End If

                .CropYieldID = lCropYieldID
            End With

            dt = CPOProductionBOL.GetCPODetails(objPKOPPT)
            If dt.Rows.Count <> 0 Then
                Me.dgvPKOView.DataSource = dt
                dgvPKOView.AutoGenerateColumns = False

            Else
                ClearGridView(dgvPKOView) '''''clear the records from grid view
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub UpdateTankMasterBFQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim dsBFQty As New DataSet
            txtPrevDayReading.Text = "0"
            If txtPrevDayReading.Enabled = False Then
                '''''For FFb Lorry Processed '''''
                ''YDAY Date Calculation''

                'Dim prevDate As Date = DateAdd(DateInterval.Day, -1, dtpCPOLogDate.Value)
                'Dim prevDate As Date = DateAdd(DateInterval.Day, -1, dtpPKODate.Value)
                objCPOPPT.CPODate = dtpPKODate.Value
                objCPOPPT.CropYieldID = lCropYieldID
                If lTankID <> String.Empty Then
                    objCPOPPT.TankID = lTankID
                End If
                '  dsBFQty = CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                If dsBFQty.Tables(0).Rows.Count <> 0 Then
                    If Not dsBFQty.Tables(0).Rows(0).Item("CurrentReading") Is DBNull.Value Then
                        txtPrevDayReading.Text = dsBFQty.Tables(0).Rows(0).Item("CurrentReading")
                    Else
                        txtPrevDayReading.Text = String.Empty
                    End If

                    '                    txtTodayFFB.Enabled = False
                    '                   txtNoOfLorry.Enabled = False
                End If


            End If
        Catch ex As Exception
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        Try
            If grdname.Rows.Count <> 0 Then
                Dim objDataGridViewRow As New DataGridViewRow

                For iCount As Integer = 1 To grdname.Rows.Count
                    grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
                Next
                If grdname.Rows.Count = 1 Then
                    grdname.Rows.RemoveAt(0)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSearch.Click

        If chkPKODate.Checked = False Then
            DisplayInfoMessage("Msg9")
            ''MsgBox("Please Enter Criteria to Search!")
            PKOGridViewBind()

        Else
            PKOGridViewBind()
            If dgvPKOView.RowCount = 0 Then
                DisplayInfoMessage("Msg10")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub
    Private Sub chkPKODate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPKODate.CheckedChanged
        If chkPKODate.Checked = True Then
            dtpPKOViewDate.Enabled = True
        Else
            dtpPKOViewDate.Enabled = False
        End If
    End Sub
    Private Sub cmbStockTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStockTank.SelectedIndexChanged

        lTankID = Nothing
        GetTankID(cmbStockTank.Text)
        Dim objPKOPPT As New PKOProductionPPT
        lStockTankID = lTankID
        objPKOPPT.StockTankID = lTankID
        ComboValueSelected()

        txtPrevDayReading.Text = ""

        Dim lrow As Integer
        lrow = cmbStockTank.SelectedIndex
        lblCapacityValue.Text = dsStockTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString
        txtPrevDayReading.Text = ""

        If cmbStockTank.SelectedIndex <> 0 Then
            Dim DsBalanceBf As New DataSet
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.TankID = cmbStockTank.SelectedValue.ToString
            objCPOPPT.CPOProductionDate = DtpProductionDate.Value
            DsBalanceBf = CPOProductionBOL.loadCmbStorageBalanceBF(objCPOPPT)

            If DsBalanceBf.Tables(0).Rows.Count <> 0 Then 'first time the PrevDayReading should take from the tank master 'Added by shankar D on 16-Oct-12
                txtPrevDayReading.Text = DsBalanceBf.Tables(0).Rows(0).Item("BalanceBF").ToString
            Else
                If (dsStockTankNo.Tables(0).Select("TankID='" + cmbStockTank.SelectedValue.ToString + "'").Length > 0) Then txtPrevDayReading.Text = dsStockTankNo.Tables(0).Select("TankID='" + cmbStockTank.SelectedValue.ToString + "'")(0)("BFqty")
            End If
            If DsBalanceBf.Tables(1).Rows.Count <> 0 Then
                lPrevdayPontoonQty = DsBalanceBf.Tables(1).Rows(0).Item("PontoonPrevQty").ToString
            End If


            If txtPrevDayReading.Text = "" Then
                txtPrevDayReading.Enabled = True
            Else
                txtPrevDayReading.Enabled = False
            End If

        Else
            txtPrevDayReading.Text = ""
            txtPrevDayReading.Enabled = False
        End If

    End Sub
    Private Function IsCheckValidationSub()
        If cmbLoadTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This Field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTank.Focus()
            Return False
        End If
        If cmbTransTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg6")
            ''MessageBox.Show("This Field is Required", " Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTransTank.Focus()
            Return False
        End If
        If cmbLoadLocation.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show("This Field is Required", "To Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadLocation.Focus()
            Return False
        End If
        If cmbLoadTrans.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show("This Field is Required", "To Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function IsCheckValidationGrid()
        If dgvPKODetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show("Add The Values in StockCPO Records", "StockCPO Records", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStockTank.Focus()
            Return False
        End If
        If Val(txtProductionMonth.Text) < Val(txtProductionToday.Text) Then
            DisplayInfoMessage("Msg13")
            '' MessageBox.Show("Month To Date value cant be lesser than Today Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionMonth.Focus()
            Return False
        End If
        If Val(txtProductionYear.Text) < Val(txtProductionToday.Text) Then
            DisplayInfoMessage("Msg14")
            ''MessageBox.Show("Year To Date value cant be lesser than Today Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionYear.Focus()
            Return False
        End If
        If Val(txtProductionYear.Text) < Val(txtProductionMonth.Text) Then
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show("Year To Date value cant be lesser than Month To Date ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionYear.Focus()
            Return False
        End If
        'If dgvPKOTransDetails.Rows.Count = 0 Then
        '    MessageBox.Show("Add The Values in TransCPO Records", "TransCPO Records", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbTransTank.Focus()
        '    Return False
        'End If
        Return True
    End Function
    Private Sub PKOGetMonthYearQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim dsProdStock As DataSet
            Dim dsProdLoad As DataSet
            Dim dsProdtrans As DataSet
            Dim lCurrentReading As Double
            Dim lBalance As Double
            Dim lTransQty As Double
            Dim lLoadQty As Double
            objCPOPPT.CPODate = dtpPKODate.Value
            objCPOPPT.CropYieldID = lCropYieldID

            dsProdStock = CPOProductionBOL.CPOGetStockMonthYearQty(objCPOPPT)
            dsProdLoad = CPOProductionBOL.CPOGetLoadMonthYearQty(objCPOPPT)
            dsProdtrans = CPOProductionBOL.CPOGetTransMonthYearQty(objCPOPPT)

            If dsProdStock.Tables.Count <> 0 Then
                If dsProdStock.Tables(0).Rows.Count <> 0 Then
                    If Not dsProdStock.Tables(0).Rows(0).Item("CurrentReading") Is DBNull.Value Then
                        lCurrentReading = dsProdStock.Tables(0).Rows(0).Item("CurrentReading")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lCurrentReading = 0.0
                    End If

                    If Not dsProdStock.Tables(0).Rows(0).Item("Balance") Is DBNull.Value Then
                        lBalance = dsProdStock.Tables(0).Rows(0).Item("Balance")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lBalance = 0.0
                    End If
                Else
                    lCurrentReading = 0.0
                    lBalance = 0.0
                End If
            End If

            If dsProdtrans.Tables.Count <> 0 Then
                If dsProdtrans.Tables(0).Rows.Count <> 0 Then
                    If Not dsProdtrans.Tables(0).Rows(0).Item("TransQty") Is DBNull.Value Then
                        lTransQty = dsProdtrans.Tables(0).Rows(0).Item("TransQty")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lTransQty = 0.0
                    End If
                Else
                End If
            End If
            If dsProdLoad.Tables.Count <> 0 Then
                If dsProdLoad.Tables(0).Rows.Count <> 0 Then
                    If Not dsProdLoad.Tables(0).Rows(0).Item("LoadQty") Is DBNull.Value Then
                        lLoadQty = dsProdLoad.Tables(0).Rows(0).Item("LoadQty")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lLoadQty = 0.0
                    End If
                Else
                    lLoadQty = 0.0
                End If
            End If

            Me.txtProductionMonth.Text = lCurrentReading + lTransQty + lLoadQty - lBalance

            ''''''For year'''''''''''
            If dsProdStock.Tables.Count <> 0 Then
                If dsProdStock.Tables(1).Rows.Count <> 0 Then
                    If Not dsProdStock.Tables(1).Rows(0).Item("CurrentReading") Is DBNull.Value Then
                        lCurrentReading = dsProdStock.Tables(1).Rows(0).Item("CurrentReading")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lCurrentReading = 0.0
                    End If

                    If Not dsProdStock.Tables(1).Rows(0).Item("Balance") Is DBNull.Value Then
                        lBalance = dsProdStock.Tables(1).Rows(0).Item("Balance")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lBalance = 0.0
                    End If
                Else
                    lCurrentReading = 0.0
                    lBalance = 0.0
                End If
            End If
            If dsProdtrans.Tables.Count <> 0 Then
                If dsProdtrans.Tables(1).Rows.Count <> 0 Then
                    If Not dsProdtrans.Tables(1).Rows(0).Item("TransQty") Is DBNull.Value Then
                        lTransQty = dsProdtrans.Tables(1).Rows(0).Item("TransQty")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lTransQty = 0.0
                    End If
                Else
                    lTransQty = 0.0
                End If
            End If

            If dsProdLoad.Tables.Count <> 0 Then
                If dsProdLoad.Tables(1).Rows.Count <> 0 Then
                    If Not dsProdLoad.Tables(1).Rows(0).Item("LoadQty") Is DBNull.Value Then
                        lLoadQty = dsProdLoad.Tables(1).Rows(0).Item("LoadQty")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lLoadQty = 0.0
                    End If
                Else
                    lLoadQty = 0.0
                End If
            End If

            Me.txtProductionYear.Text = lCurrentReading + lTransQty + lLoadQty - lBalance
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PKOGetTodayQty()
        Try

            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.CPODate = dtpPKODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            Dim dsCPOToday As DataSet
            dsCPOToday = CPOProductionBOL.CPOGetTodayQty(objCPOPPT)
            Dim lCurrentReading As Double
            'Dim lBalance As Double
            'Dim lTransQty As Double
            'Dim lLoadQty As Double
            objCPOPPT.CropYieldID = lCropYieldID
            dsCPOToday = CPOProductionBOL.CPOGetTodayQty(objCPOPPT)
            If dsCPOToday.Tables.Count <> 0 Then
                If dsCPOToday.Tables(0).Rows.Count <> 0 Then
                    If Not dsCPOToday.Tables(0).Rows(0).Item("QtyToday") Is DBNull.Value Then
                        lCurrentReading = dsCPOToday.Tables(0).Rows(0).Item("QtyToday")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lCurrentReading = 0.0
                    End If

                    '    If Not dsCPOToday.Tables(0).Rows(0).Item("Balance") Is DBNull.Value Then
                    '        lBalance = dsCPOToday.Tables(0).Rows(0).Item("Balance")
                    '        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    '    Else
                    '        lBalance = 0.0
                    '    End If
                    'End If
                    'If dsCPOToday.Tables(1).Rows.Count <> 0 Then
                    '    If Not dsCPOToday.Tables(1).Rows(0).Item("TransQty") Is DBNull.Value Then
                    '        lTransQty = dsCPOToday.Tables(1).Rows(0).Item("TransQty")
                    '        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    '    Else
                    '        lTransQty = 0.0
                    '    End If
                    'End If
                    'If Not dsCPOToday.Tables(2).Rows.Count Then
                    '    If Not dsCPOToday.Tables(2).Rows(0).Item("LoadQty") Is DBNull.Value Then
                    '        lLoadQty = dsCPOToday.Tables(2).Rows(0).Item("LoadQty")
                    '        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    '    Else
                    '        lLoadQty = 0.0
                    '    End If
                End If
            Else
                lCurrentReading = 0.0
                'lLoadQty = 0.0
                'lTransQty = 0.0
                'lBalance = 0.0
            End If

            Me.txtProductionToday.Text = lCurrentReading
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        Try

            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg16")
                ''MsgBox("No Record in Crop yield for PKO , Please insert the record in General Crop Yield")
                Exit Sub
            End If
            If Not IsCheckValidationGrid() Then Exit Sub
            If lProductionToday < 0 Then
                DisplayInfoMessage("Msg17")
                ''MsgBox("Balance B/F Qty cant be greater than sum of current reading ,Loading Qty and Transhipment Qty")
                Exit Sub
            End If



            If dgvPKODetails.Rows.Count <> 0 Then
                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If

                If SaveFlag = True Then
                    ''''For Production CPO''''
                    Dim objCPOPPT As New CPOProductionPPT
                    Dim objPKOPPT As New PKOProductionPPT
                    Dim objPKOBOL As New PKOProductionBOL

                    Dim dsID As DataSet



                    'Dim StrCPODate As String
                    Dim dsDetails As New DataSet
                    objCPOPPT.CPODate = dtpPKODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value

                    objCPOPPT.CropYieldID = lCropYieldID
                    If txtProductionToday.Text <> String.Empty Then
                        objCPOPPT.ProductionToday = txtProductionToday.Text
                    Else
                        objCPOPPT.ProductionToday = 0.0
                    End If
                    If txtProductionMonth.Text <> String.Empty Then
                        objCPOPPT.ProductionMonth = txtProductionMonth.Text
                    Else
                        objCPOPPT.ProductionMonth = 0.0
                    End If
                    If txtProductionYear.Text <> String.Empty Then
                        objCPOPPT.ProductionYear = txtProductionYear.Text
                    Else
                        objCPOPPT.ProductionYear = 0.0
                    End If
                    'objCPOPPT.CPODate = Format(txtDate.Text, "dd/MM/yyyy")
                    '  objCPOPPT.CPODate = dtpPKODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")

                    dsID = CPOProductionBOL.saveCPOProduction(objCPOPPT)
                    If dsID.Tables(0).Rows.Count <> 0 Then
                        lProductionID = dsID.Tables(0).Rows(0).Item("ProductionID")
                    Else
                        lProductionID = Nothing
                    End If


                    objCPOPPT.ProductionID = lProductionID

                    For Each DataGridViewRow In dgvPKODetails.Rows
                        ''''For Stock CPO''''''''''''

                        objCPOPPT.StockTankID = DataGridViewRow.Cells("dgclStockTankID").Value.ToString()


                        If Not DataGridViewRow.Cells("dgclCapacity").Value Is DBNull.Value Then
                            objCPOPPT.Capacity = DataGridViewRow.Cells("dgclCapacity").Value
                        Else
                            objCPOPPT.Capacity = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclBalance").Value Is DBNull.Value Then
                            objCPOPPT.PrevDayReading = Val(DataGridViewRow.Cells("dgclBalance").Value)
                        Else
                            objCPOPPT.PrevDayReading = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclCurrentReading").Value Is DBNull.Value Then
                            objCPOPPT.CurrentReading = DataGridViewRow.Cells("dgclCurrentReading").Value
                        Else
                            objCPOPPT.CurrentReading = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclWriteoff").Value Is DBNull.Value Then
                            objCPOPPT.Writeoff = DataGridViewRow.Cells("dgclWriteoff").Value
                        Else
                            objCPOPPT.Writeoff = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclReason").Value Is DBNull.Value Then
                            objCPOPPT.Reason = DataGridViewRow.Cells("dgclReason").Value
                        Else
                            objCPOPPT.Reason = String.Empty
                        End If

                        If Not DataGridViewRow.Cells("dgclMeasurement").Value Is DBNull.Value Then
                            objCPOPPT.Measurement = Val(DataGridViewRow.Cells("dgclMeasurement").Value)
                        Else
                            objCPOPPT.Measurement = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclTemperature").Value Is DBNull.Value Then
                            objCPOPPT.Temparature = Val(DataGridViewRow.Cells("dgclTemperature").Value)
                        Else
                            objCPOPPT.Temparature = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclFFA").Value Is DBNull.Value Then
                            objCPOPPT.FFA = Val(DataGridViewRow.Cells("dgclFFA").Value)
                        Else
                            objCPOPPT.FFA = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclMoisture").Value Is DBNull.Value Then
                            objCPOPPT.Moisture = Val(DataGridViewRow.Cells("dgclMoisture").Value)
                        Else
                            objCPOPPT.Moisture = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclDirt").Value Is DBNull.Value Then
                            objCPOPPT.Dirt = Val(DataGridViewRow.Cells("dgclDirt").Value)
                        Else
                            objCPOPPT.Dirt = 0.0
                        End If
                        'lCropYieldID = "M1"
                        objCPOPPT.CropYieldID = lCropYieldID
                        objCPOPPT.ProductionID = lProductionID
                        CPOProductionBOL.saveCPOStockProduction(objCPOPPT)

                    Next


                    For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                        ''''''For Load CPO'''''''''''''
                        objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        objCPOPPT.LoadCurrentReading = DataGridViewRowLoad.Cells("dgclLoadCtReading").Value
                        objCPOPPT.LoadPrevDayReading = DataGridViewRowLoad.Cells("dgclPrevDayReadnig").Value.ToString()
                        objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objCPOPPT.ProductionID = lProductionID
                        objCPOPPT.CropYieldID = lCropYieldID

                        CPOProductionBOL.CPOProdLoadInsert(objCPOPPT)
                    Next

                    'For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                    '    ''''''For Load CPO'''''''''''''

                    '    objCPOPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()



                    '    objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()


                    '    If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                    '        objCPOPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                    '    Else
                    '        objCPOPPT.LoadQty = 0.0
                    '    End If
                    '    If Not DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value Then
                    '        objCPOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value
                    '    Else
                    '        objCPOPPT.LoadMonthToDate = 0.0
                    '    End If

                    '    ''''For Remarks'''''''''''''''''''''''''''''''''''''''''
                    '    objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()

                    '    objCPOPPT.CropYieldID = lCropYieldID

                    '    CPOProductionBOL.saveCPOLoadProduction(objCPOPPT)
                    'Next


                    'For Each DataGridViewRowTrans In dgvPKOTransDetails.Rows

                    '    ''''For Trans CPO''''''''


                    '    objCPOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()


                    '    objCPOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()

                    '    If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                    '        objCPOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                    '    Else
                    '        objCPOPPT.TransQty = 0.0
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value Then
                    '        objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value
                    '    Else
                    '        objCPOPPT.TransMonthToDate = 0.0
                    '    End If


                    '    '''''For Remarks'''''''''''''''''''''''''''
                    '    objCPOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString()

                    '    objCPOPPT.CropYieldID = lCropYieldID
                    '    CPOProductionBOL.saveCPOTransProduction(objCPOPPT)
                    '    ' CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                    'Next


                    PKOGridViewBind()
                    DisplayInfoMessage("Msg19")
                    ''MsgBox("Data Successfully Saved")
                    Reset()
                    ResetMain()
                    ResetLoad()
                    ResetLoadPKO()
                    'SaveFlag = False
                Else

                    'Dim StrCPODate As String
                    Dim dsDetails As New DataSet
                    ' For Each DataGridViewRowMain In dgvPKODetails.Rows
                    Dim objCPOPPT As New CPOProductionPPT
                    Dim objPKOPPT As New PKOProductionPPT
                    Dim objPKOBOL As New PKOProductionBOL

                    objCPOPPT.CropYieldID = lCropYieldID
                 
                    If txtProductionToday.Text <> String.Empty Then
                        objCPOPPT.ProductionToday = txtProductionToday.Text
                    Else
                        objCPOPPT.ProductionToday = 0.0
                    End If
                    If txtProductionMonth.Text <> String.Empty Then
                        objCPOPPT.ProductionMonth = txtProductionMonth.Text
                    Else
                        objCPOPPT.ProductionMonth = 0.0
                    End If
                    If txtProductionYear.Text <> String.Empty Then
                        objCPOPPT.ProductionYear = txtProductionYear.Text
                    Else
                        objCPOPPT.ProductionYear = 0.0
                    End If


                    ' objCPOPPT.CPODate = dtpPKODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    objCPOPPT.ProductionID = lProductionID
                    objCPOPPT.CPODate = dtpPKODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value



                    CPOProductionBOL.UpdateCPOProduction(objCPOPPT)


                    ' Next

                    For Each DataGridViewRow In dgvPKODetails.Rows

                        ''''For Stock CPO''''''''''''
                        objCPOPPT.ProductionID = lProdIdNew
                        If Not DataGridViewRow.Cells("dgclStockTankID").Value.ToString Is DBNull.Value Then
                            objCPOPPT.StockTankID = DataGridViewRow.Cells("dgclStockTankID").Value.ToString()
                        Else
                            objCPOPPT.StockTankID = ""
                        End If

                        If Not DataGridViewRow.Cells("dgclCapacity").Value Is DBNull.Value Then
                            objCPOPPT.Capacity = DataGridViewRow.Cells("dgclCapacity").Value
                        Else
                            objCPOPPT.Capacity = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclBalance").Value Is DBNull.Value Then
                            objCPOPPT.PrevDayReading = Val(DataGridViewRow.Cells("dgclBalance").Value)
                        Else
                            objCPOPPT.PrevDayReading = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclCurrentReading").Value Is DBNull.Value Then
                            objCPOPPT.CurrentReading = Val(DataGridViewRow.Cells("dgclCurrentReading").Value)
                        Else
                            objCPOPPT.CurrentReading = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclWriteoff").Value Is DBNull.Value Then
                            objCPOPPT.Writeoff = DataGridViewRow.Cells("dgclWriteoff").Value
                        Else
                            objCPOPPT.Writeoff = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclReason").Value Is DBNull.Value Then
                            objCPOPPT.Reason = DataGridViewRow.Cells("dgclReason").Value
                        Else
                            objCPOPPT.Reason = String.Empty
                        End If

                        If Not DataGridViewRow.Cells("dgclMeasurement").Value Is DBNull.Value Then
                            objCPOPPT.Measurement = Val(DataGridViewRow.Cells("dgclMeasurement").Value)
                        Else
                            objCPOPPT.Measurement = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclTemperature").Value Is DBNull.Value Then
                            objCPOPPT.Temparature = Val(DataGridViewRow.Cells("dgclTemperature").Value)
                        Else
                            objCPOPPT.Temparature = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclFFA").Value Is DBNull.Value Then
                            objCPOPPT.FFA = Val(DataGridViewRow.Cells("dgclFFA").Value)
                        Else
                            objCPOPPT.FFA = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclMoisture").Value Is DBNull.Value Then
                            objCPOPPT.Moisture = Val(DataGridViewRow.Cells("dgclMoisture").Value)
                        Else
                            objCPOPPT.Moisture = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclDirt").Value Is DBNull.Value Then
                            objCPOPPT.Dirt = Val(DataGridViewRow.Cells("dgclDirt").Value)
                        Else
                            objCPOPPT.Dirt = 0.0
                        End If
                        'lCropYieldID = "M1"
                        objCPOPPT.CropYieldID = lCropYieldID

                        'objCPOPPT.ProdStockID = DataGridViewRow.Cells("dgclProdStockID").Value

                        If Not (DataGridViewRow.Cells("dgclProdStockID").Value Is Nothing Or DataGridViewRow.Cells("dgclProdStockID").Value Is DBNull.Value) Then
                            objCPOPPT.ProdStockID = DataGridViewRow.Cells("dgclProdStockID").Value.ToString()
                        Else
                            objCPOPPT.ProdStockID = String.Empty
                        End If
                        objCPOPPT.ProductionID = lProductionID
                        If objCPOPPT.ProdStockID = String.Empty Then
                            CPOProductionBOL.saveCPOStockProduction(objCPOPPT)
                        Else
                            CPOProductionBOL.UpdateCPOStockProduction(objCPOPPT)
                        End If
                    Next
                    For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                        ''''''For Load CPO'''''''''''''
                        objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        objCPOPPT.LoadCurrentReading = DataGridViewRowLoad.Cells("dgclLoadCtReading").Value
                        objCPOPPT.LoadPrevDayReading = DataGridViewRowLoad.Cells("dgclPrevDayReadnig").Value
                        objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objCPOPPT.ProductionID = lProductionID
                        objCPOPPT.CropYieldID = lCropYieldID
                        lProdLoadingID = DataGridViewRowLoad.Cells("dgclProdLoadID").Value.ToString()
                        objCPOPPT.ProdLoadingID = lProdLoadingID
                        If lProdLoadingID <> "" Then
                            CPOProductionBOL.CPOProdLoadupdate(objCPOPPT)
                        Else
                            CPOProductionBOL.CPOProdLoadInsert(objCPOPPT)
                        End If

                    Next

                    DeleteMultiEntryRecordsStockPKO()
                    DeleteMultiEntryRecordsLoadingPKO()
                    DeleteMultiEntryRecordsTranshipPKO()

                    '  CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                    DisplayInfoMessage("Msg20")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    PKOGridViewBind()
                    Reset()
                    ResetMain()
                    ResetLoad()
                    ResetLoadPKO()
                    'ResetTrans()
                    SaveFlag = True
                    txtProductionToday.Text = ""
                End If
                ClearGridView(dgvPKODetails)
            Else
                DisplayInfoMessage("Msg21")
                ''MessageBox.Show(" No Record to Add", " ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            DisplayInfoMessage("Msg22")
            '' MsgBox("Save Process Failed")
            'Dim objCPOPPT As New CPOProductionPPT
            'Dim objCPOBOL As New CPOProductionBOL

            'objCPOPPT.CPODate = dtpPKODate.Value
            'objCPOPPT.CropYieldID = lCropYieldID
            'objCPOBOL.Delete_CPODetail(objCPOPPT)
            'PKOGridViewBind()

        End Try

    End Sub
    Private Sub UpdatePKOView()
        If dgvPKOView.Rows.Count > 0 Then
            EditPKOView()
            dtpPKODate.Enabled = False
            DtpProductionDate.Enabled = False
            ProductionTodayCalculation()

        Else
            DisplayInfoMessage("Msg23")

        End If

    End Sub
    Private Sub EditPKOView()

        Me.cmsPKO.Visible = False
        'Dim objPKOPPT As New PKOProductionPPT
        'Dim objPKOBOL As New PKOProductionBOL
        Dim objCPOPPT As New CPOProductionPPT
        Dim dt As New DataTable
        SaveFlag = False
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSaveAll.Enabled = True
            End If
        End If

        lProductionID = Me.dgvPKOView.SelectedRows(0).Cells("gvProductionID").Value
        lQtyPrev = Me.dgvPKOView.SelectedRows(0).Cells("QtyToday").Value

        ''objPKOPPT.StockTankID = Me.dgvPKOView.SelectedRows(0).Cells("gvStockTankID").Value

        objCPOPPT.CropYieldID = lCropYieldID
        Dim str As String = Me.dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()
        objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
        dtpPKODate.Value = objCPOPPT.CPODate
        '''' For Stock CPO'''

        str = Me.dgvPKOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
        objCPOPPT.CPOProductionDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
        DtpProductionDate.Value = objCPOPPT.CPOProductionDate
        objCPOPPT.ProductionID = lProductionID



        dtPKOAdd = CPOProductionBOL.GetCPOAddStockInfo(objCPOPPT)
        dgvPKODetails.AutoGenerateColumns = False
        dgvPKODetails.DataSource = dtPKOAdd

        '''' For Stock CPO'''
        dtLoadPKOAdd = CPOProductionBOL.GetCPOAddLoadInfo(objCPOPPT)
        dgvLoadCPODetails.AutoGenerateColumns = False
        dgvLoadCPODetails.DataSource = dtLoadPKOAdd


        '        dtpCPODate.Value = objCPOPPT.CPODate


        ''''' For Stock CPO'''
        'dtTransPKOAdd = CPOProductionBOL.GetCPOAddTransInfo(objCPOPPT)
        'dgvPKOTransDetails.AutoGenerateColumns = False
        'If dtTransPKOAdd.Rows.Count <> 0 Then
        '    lProdIdNew = dtTransPKOAdd.Rows(0).Item("ProductionID")
        'End If

        'dgvPKOTransDetails.DataSource = dtTransPKOAdd

        'dtpPKODate.Value = objPKOPPT.PKODate

        'Dim dt As New DataTable
        'Dim objCPOPPT As New CPOProductionPPT
        With objCPOPPT
            .CPOProductionDate = Nothing
        End With
        objCPOPPT.CropYieldID = lCropYieldID
        dt = CPOProductionBOL.GetCPODetails(objCPOPPT)

        If dgvPKOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString() <> dt.Rows(0).Item("productionDate") Then
            btnSaveAll.Enabled = False
            btnDeleteAll.Enabled = False
            ' DisplayInfoMessage("msg177")
            DisplayInfoMessage("msg176")
        End If


        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Update All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Update Semua"
        End If
        ''Me.btnSaveAll.Text = "Update All"
        PKOGridViewBind()
        Me.tcPKOProduction.SelectedTab = tpPKOSave

    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        UpdatePKOView()

    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        ResetMain()
        ResetLoadPKO()
        GlobalPPT.IsRetainFocus = False
        'ResetLoad()
        'ResetTrans()
    End Sub
    Public Sub GetTankID(ByVal lTankNo As String)

        Dim dsLoad As DataSet
        Dim objPKOPPT As New PKOProductionPPT
        objPKOPPT.TankNo = lTankNo
        dsLoad = PKOProductionBOL.GetTankID(objPKOPPT)
        If dsLoad.Tables.Count <> 0 Then
            If dsLoad.Tables(0).Rows.Count <> 0 Then
                lTankID = dsLoad.Tables(0).Rows(0).Item("TankID")
            End If
        End If

    End Sub
    Public Sub GetLocationID(ByVal lLocation As String)

        Dim dsLocation As DataSet
        Dim objPKOPPT As New PKOProductionPPT
        objPKOPPT.Descp = lLocation
        dsLocation = PKOProductionBOL.GetLocationID(objPKOPPT)
        If dsLocation.Tables.Count <> 0 Then
            If dsLocation.Tables(0).Rows.Count <> 0 Then
                lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
            End If
        End If

    End Sub
    Private Sub cmbLoadTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTank.SelectedIndexChanged
        Dim objCPOBOL As New CPOProductionBOL

        If cmbLoadTank.SelectedIndex <> 0 Then
            Dim lrow As Integer
            lrow = cmbLoadTank.SelectedIndex
            lLoadCapacity = dsLoadTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString


        End If




        'lTankID = Nothing
        'GetTankID(cmbLoadTank.Text)
        'Dim objCPOPPT As New CPOProductionPPT
        '' lLoadTankID = lTankID

        'objCPOPPT.ProductionID = lProdIdNew
        'objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString
        'objCPOPPT.CropYieldID = lCropYieldID
        'If cmbLoadLocation.SelectedIndex > 0 Then
        '    objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'End If

        'objCPOPPT.CPODate = dtpPKODate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty And txtLoadQty.Text <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objCPOBOL.DuplicateLoadLocationFirstCheck(objCPOPPT)
        '    If objCheckDuplicateLoadLocation = 0 Then
        '        txtLoadMonthToDate.Enabled = False
        '    Else
        '        txtLoadMonthToDate.Enabled = True
        '    End If
        'End If


        '    ''''Month Qty Value '''''''''''''''

        '    Dim dsCrop As New DataSet
        '    'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lCropYieldID <> String.Empty) Then
        '        dsCrop = CPOProductionBOL.CPOGetLoadVsLocMonthQty(objCPOPPT)
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

        ''Kumar Changed
        If cmbLoadTank.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            LoadTankMonthtoDate()
        End If

    End Sub
    Private Sub cmbTransTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTransTank.SelectedIndexChanged
        Try
            txtTransQty.Text = ""
            If cmbTransTank.SelectedIndex <> 0 Then
                Dim lrow As Integer
                lrow = cmbTransTank.SelectedIndex
                lTransCapacity = dsTransTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString
            End If

            Dim objCPOPPT As New CPOProductionPPT
            lTankID = Nothing
            GetTankID(cmbTransTank.Text)
            Dim objPKOPPT As New PKOProductionPPT
            lTransTankID = lTankID
            objPKOPPT.TransTankID = lTankID
            objCPOPPT.CPODate = dtpPKODate.Value
            objCPOPPT.TankID = lTankID
            objCPOPPT.ProductionID = lProdIdNew
            Dim objCPOBOL As New CPOProductionBOL
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.LoadingLocationID = lLocationID

            If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
                Dim objCheckDuplicateLoadLocation As Object = 0
                objCheckDuplicateLoadLocation = objCPOBOL.DuplicateTransLocationFirstCheck(objCPOPPT)
                If objCheckDuplicateLoadLocation = 0 Then
                    txtTransMonthToDate.Enabled = False
                Else
                    txtTransMonthToDate.Enabled = True
                End If
            End If


            '''''Month Qty Value '''''''''''''''

            'Dim dsCrop As New DataSet
            'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
            '    dsCrop = CPOProductionBOL.CPOGetTransVsLocMonthQty(objCPOPPT)
            '    If dsCrop.Tables.Count <> 0 Then
            '        If dsCrop.Tables(0).Rows.Count <> 0 Then
            '            lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
            '            txtTransMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
            '        Else
            '            txtTransMonthToDate.Text = "0"
            '        End If
            '    End If
            'End If
            If cmbTransTank.SelectedIndex = 0 Then
                txtTransMonthToDate.Text = ""
                txtTransMonthToDate.Enabled = False
            Else
                TransTankMonthtoDate()
            End If

        Catch ex As Exception
        End Try
    End Sub
    'Private Sub dgvPKOView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvPKOView.DoubleClick
    '    UpdatePKOView()
    'End Sub

    Private Sub cmbLoadLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadLocation.SelectedIndexChanged
        If cmbLoadLocation.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            LoadTankMonthtoDate()
        End If
    End Sub
    Private Sub cmbLoadTrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTrans.SelectedIndexChanged
        Try
            Dim objCPOPPT As New CPOProductionPPT

            lLocationID = Nothing
            GetLocationID(cmbLoadTrans.Text)
            Dim objPKOPPT As New PKOProductionPPT
            lTransLocationID = lLocationID
            'lblTranshipDescription.Text = lLocationDesc
            objPKOPPT.TransLocationID = lLocationID
            objCPOPPT.CPODate = dtpPKODate.Value
            Dim objCPOBOL As New CPOProductionBOL

            objCPOPPT.ProductionID = lProdIdNew
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.LoadingLocationID = lLocationID

            If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
                Dim objCheckDuplicateLoadLocation As Object = 0
                objCheckDuplicateLoadLocation = objCPOBOL.DuplicateTransLocationFirstCheck(objCPOPPT)
                If objCheckDuplicateLoadLocation = 0 Then
                    txtTransMonthToDate.Enabled = False
                Else
                    txtTransMonthToDate.Enabled = True
                End If
            End If

            '''''Month Qty Value '''''''''''''''

            'Dim dsCrop As New DataSet
            'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
            '    dsCrop = CPOProductionBOL.CPOGetTransVsLocMonthQty(objCPOPPT)
            '    If dsCrop.Tables.Count <> 0 Then
            '        If dsCrop.Tables(0).Rows.Count <> 0 Then
            '            lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
            '            txtTransMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
            '        Else
            '            txtTransMonthToDate.Text = "0"
            '        End If
            '    End If
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

        '' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))
        'If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        '    Me.Close()
        'End If

        If (dgvPKODetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg37"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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
    Private Sub dgvPKOView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKOView.CellDoubleClick



        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdatePKOView()
            End If
        End If

    End Sub
    Private Sub DeletePKOVIew()
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))
        Dim dt As New DataTable
        Dim objCPOPPT As New CPOProductionPPT
        With objCPOPPT
            .CPOProductionDate = Nothing
        End With
        objCPOPPT.CropYieldID = lCropYieldID
        dt = CPOProductionBOL.GetCPODetails(objCPOPPT)

        If dgvPKOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString() = dt.Rows(0).Item("productionDate") Then

            Me.cmsPKO.Visible = False

            ' Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            '  Dim dt As New DataTable
            If dgvPKOView.Rows.Count > 0 Then
                If MsgBox(rm.GetString("Msg38"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Dim str As String = Me.dgvPKOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
                    ''Me.dgvCPOView.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                    objCPOPPT.CPOProductionDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                    objCPOPPT.CropYieldID = lCropYieldID
                    objCPOBOL.Delete_CPODetail(objCPOPPT)
                    PKOGridViewBind()
                    'Else
                    '    MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            DisplayInfoMessage("msg177")
            '  DisplayInfoMessage("msg176")
        End If

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvPKOView.RowCount > 0 Then
            DeletePKOVIew()

        End If
       
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Reset()
        tcPKOProduction.SelectedTab = tpPKOSave
    End Sub
    Private Sub tcPKOProduction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcPKOProduction.Click

        If (dgvPKODetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcPKOProduction.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ResetMain()
                Reset()
                ResetLoadPKO()
                'ResetLoad()
                'ResetTrans()
                PKOGridViewBind()


            End If
        Else
            ResetMain()
            Reset()
            ResetLoadPKO()
            'ResetLoad()
            'ResetTrans()
            PKOGridViewBind()


        End If
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)
    End Sub
    Private Sub txtCurrentReading_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCurrentReading.KeyDown
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
    Private Sub txtCurrentReading_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrentReading.KeyPress
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

    Private Sub txtMeasurement_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeasurement.KeyPress
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

    Private Sub txtTemparature_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTemparature.KeyPress
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

    Private Sub txtFFA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFA.KeyPress
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

    Private Sub txtMoisture_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMoisture.KeyPress
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

    Private Sub txtDirt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDirt.KeyPress
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

    Private Sub txtLoadMonthToDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadMonthToDate.KeyPress, txtTransQty.KeyPress
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
    Private Sub txtTransQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txtProductionToday_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionToday.KeyPress
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

    Private Sub txtProductionMonth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionMonth.KeyPress
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
    Private Sub txtProductionYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionYear.KeyPress
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

    Private Sub txtMeasurement_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeasurement.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtTemparature_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTemparature.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtFFA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFA.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMoisture.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtDirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDirt.KeyDown
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
                        ' isDecimal = twoDecimalPlaces.IsMatch(text)
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

    Private Sub txtProductionToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionToday.KeyDown
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
                        isDecimal = twoDecimalPlaces.IsMatch(text)
                End Select
            Else
                isDecimal = False
                Return
            End If
        Else
            isDecimal = True
        End If
    End Sub

    Private Sub txtProductionMonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionMonth.KeyDown
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

    Private Sub txtProductionYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionYear.KeyDown
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
    Private Sub SavePKODetail()
        Try
            Dim intRowcount As Integer = dtPKOAdd.Rows.Count
            If Not TankNoExist(cmbStockTank.Text) Then 'Tank Validation 

                Dim objCPOPPT As New CPOProductionPPT
                Dim objCPOBOL As New CPOProductionBOL
                ''''For check Duplicate Tank ''''
                objCPOPPT.CropYieldID = lCropYieldID
                objCPOPPT.CPODate = dtpPKODate.Value
                'Dim objCheckDuplicateTank As Object = 0
                'objCPOPPT.TankID = cmbStockTank.SelectedValue.ToString()
                'objCheckDuplicateTank = objCPOBOL.DuplicateStockTankCheck(objCPOPPT)

                ''Dim objCheckDuplicateRecord As Object = 0
                ''objCPOPPT.CPODate = dtpPKODate.Value
                ''objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                'If objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
                '    Exit Sub
                'End If

                rowPKOAdd = dtPKOAdd.NewRow()

                If intRowcount = 0 And dtAddFlag = False Then

                    columnPKOAdd = New DataColumn("StockTankNo", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Capacity", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Balance", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("CurrentReading", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Writeoff", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Reason", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Measurement", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Temperature", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("FFA", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("Moisture", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("StockTankID", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)

                    columnPKOAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("TransTankNo", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)

                    columnPKOAdd = New DataColumn("ProdStockID", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    'columnPKOAdd = New DataColumn("ProdTranshipID", System.Type.[GetType]("System.String"))
                    'dtPKOAdd.Columns.Add(columnPKOAdd)

                    'columnPKOAdd = New DataColumn("ProdLoadingID", System.Type.[GetType]("System.String"))
                    'dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)

                    columnPKOAdd = New DataColumn("LoadMonth", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("TranshipQty", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)

                    columnPKOAdd = New DataColumn("TranshipMonth", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("prodTodayQty", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)

                    columnPKOAdd = New DataColumn("ProdMonthQty", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("ProdYearQty", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)

                    columnPKOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)
                    columnPKOAdd = New DataColumn("TransLocationID", System.Type.[GetType]("System.String"))
                    dtPKOAdd.Columns.Add(columnPKOAdd)


                    rowPKOAdd("StockTankNo") = Me.cmbStockTank.Text
                    rowPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    rowPKOAdd("TransTankNo") = Me.cmbTransTank.Text

                    If Me.lblCapacityValue.Text <> String.Empty Then
                        rowPKOAdd("Capacity") = Me.lblCapacityValue.Text
                    End If
                    'If Me.lblBalanceValue.Text <> String.Empty Then
                    '    rowPKOAdd("Balance") = Me.lblBalanceValue.Text
                    'End If

                    If Me.txtPrevDayReading.Text <> String.Empty Then
                        rowPKOAdd("Balance") = Me.txtPrevDayReading.Text
                    End If

                    If Me.txtCurrentReading.Text <> String.Empty Then
                        rowPKOAdd("CurrentReading") = CDbl(Me.txtCurrentReading.Text)
                    End If

                    If Me.txtWriteoff.Text <> String.Empty Then
                        rowPKOAdd("Writeoff") = CDbl(Me.txtWriteoff.Text)
                    End If

                    If Me.txtReason.Text <> String.Empty Then
                        rowPKOAdd("Reason") = CDbl(Me.txtReason.Text)
                    End If

                    If Me.txtMeasurement.Text <> String.Empty Then
                        rowPKOAdd("Measurement") = CDbl(Me.txtMeasurement.Text)
                    End If
                    If Me.txtTemparature.Text <> String.Empty Then
                        rowPKOAdd("Temperature") = CDbl(Me.txtTemparature.Text)
                    End If
                    If Me.txtFFA.Text <> String.Empty Then
                        rowPKOAdd("FFA") = CDbl(Me.txtFFA.Text)
                    End If

                    If Me.txtMoisture.Text <> String.Empty Then
                        rowPKOAdd("Moisture") = CDbl(Me.txtMoisture.Text)
                    End If
                    If Me.txtDirt.Text <> String.Empty Then
                        rowPKOAdd("DirtP") = txtDirt.Text
                    End If


                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowPKOAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowPKOAdd("LoadMonth") = Me.txtLoadMonthToDate.Text
                    End If
                    If Me.txtTransQty.Text <> String.Empty Then
                        rowPKOAdd("TranshipQty") = CDbl(Me.txtTransQty.Text)
                    End If
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowPKOAdd("TranshipMonth") = CDbl(Me.txtTransMonthToDate.Text)
                    End If
                    If Me.txtProductionToday.Text <> String.Empty Then
                        rowPKOAdd("prodTodayQty") = CDbl(Me.txtProductionToday.Text)
                    End If
                    If Me.txtProductionMonth.Text <> String.Empty Then
                        rowPKOAdd("ProdMonthQty") = CDbl(Me.txtProductionMonth.Text)
                    End If

                    If Me.txtProductionYear.Text <> String.Empty Then
                        rowPKOAdd("ProdYearQty") = CDbl(Me.txtProductionYear.Text)
                    End If

                    rowPKOAdd("StockTankID") = Me.lStockTankID

                    rowPKOAdd("ProdStockID") = Me.lProdStockID
                    'rowPKOAdd("ProdTranshipID") = Me.lProdTranshipID
                    'rowPKOAdd("ProdLoadingID") = Me.lProdLoadingID
                    rowPKOAdd("TransLocationID") = Me.lLoadLocationID
                    rowPKOAdd("LoadLocationID") = Me.lTransLocationID

                    dtPKOAdd.Rows.InsertAt(rowPKOAdd, intRowcount)
                    dtAddFlag = True

                Else

                    rowPKOAdd("StockTankNo") = Me.cmbStockTank.Text
                    'rowPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    'rowPKOAdd("TransTankNo") = Me.cmbTransTank.Text

                    If Me.lblCapacityValue.Text <> String.Empty Then
                        rowPKOAdd("Capacity") = Me.lblCapacityValue.Text
                    End If
                    'If Me.lblBalanceValue.Text <> String.Empty Then
                    '    rowPKOAdd("Balance") = Me.lblBalanceValue.Text
                    'End If

                    If Me.txtPrevDayReading.Text <> String.Empty Then
                        rowPKOAdd("Balance") = Me.txtPrevDayReading.Text
                    End If

                    If Me.txtCurrentReading.Text <> String.Empty Then
                        rowPKOAdd("CurrentReading") = CDbl(Me.txtCurrentReading.Text)
                    End If

                    If Me.txtWriteoff.Text <> String.Empty Then
                        rowPKOAdd("Writeoff") = CDbl(Me.txtWriteoff.Text)
                    End If

                    If Me.txtReason.Text <> String.Empty Then
                        rowPKOAdd("Reason") = CDbl(Me.txtReason.Text)
                    End If

                    If Me.txtMeasurement.Text <> String.Empty Then
                        rowPKOAdd("Measurement") = CDbl(Me.txtMeasurement.Text)
                    End If
                    If Me.txtTemparature.Text <> String.Empty Then
                        rowPKOAdd("Temperature") = CDbl(Me.txtTemparature.Text)
                    End If
                    If Me.txtFFA.Text <> String.Empty Then
                        rowPKOAdd("FFA") = CDbl(Me.txtFFA.Text)
                    End If

                    If Me.txtMoisture.Text <> String.Empty Then
                        rowPKOAdd("Moisture") = CDbl(Me.txtMoisture.Text)
                    End If
                    If Me.txtDirt.Text <> String.Empty Then
                        rowPKOAdd("DirtP") = txtDirt.Text
                    End If

                    rowPKOAdd("StockTankID") = Me.lStockTankID
                    rowPKOAdd("ProdStockID") = Me.lProdStockID
                    'rowPKOAdd("ProdTranshipID") = Me.lProdTranshipID
                    'rowPKOAdd("ProdLoadingID") = Me.lProdLoadingID
                    'rowPKOAdd("TransLocationID") = Me.lLoadLocationID
                    'rowPKOAdd("LoadLocationID") = Me.lTransLocationID

                    dtPKOAdd.Rows.InsertAt(rowPKOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg24")
                ''MessageBox.Show("Sorry this Tank No already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvPKODetails
                .DataSource = dtPKOAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try

    End Sub
    Public Sub ResetMain()
        ''''For Stock CPO
        If cmbStockTank.Items.Count > 0 Then
            cmbStockTank.SelectedIndex = 0
        End If
        lblCapacityValue.Text = ""
        ' lblBalanceValue.Text = ""
        txtPrevDayReading.Text = ""
        txtCurrentReading.Text = ""
        txtWriteoff.Text = "0"
        txtReason.Text = ""
        txtMeasurement.Text = ""
        txtTemparature.Text = ""
        txtFFA.Text = ""
        txtMoisture.Text = ""
        txtDirt.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        ''btnAdd.Text = "Add"
        btnAddFlag = True
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub Add_Clicked()
        lCurrentReadingToday = 0.0
        lLoadQtyToday = 0.0
        lTransQtyToday = 0.0
        lBalanceToday = 0.0
        lTodayQty = 0.0
        Dim objPKOPPT As New CPOProductionPPT
        Dim objPKOBOL As New CPOProductionBOL

        If dtpPKODate.Enabled = True Then
            Dim objCheckDuplicateRecord As Object = 0
            objPKOPPT.CPOProductionDate = DtpProductionDate.Value
            objPKOPPT.CropYieldID = lCropYieldID
            objCheckDuplicateRecord = objPKOBOL.DuplicateDateCheck(objPKOPPT)

            If objCheckDuplicateRecord = 0 Then
                DisplayInfoMessage("Msg25")
                ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                Exit Sub
            End If
        End If

        If btnAddFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (IsCheckValidation() = False) Then
                Exit Sub
            Else
                'Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))
                SavePKODetail()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetMain()
            End If
        ElseIf btnAddFlag = False Then
            If (IsCheckValidation() = False) Then
                Exit Sub
            Else
                UpdatePKODetails()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetMain()
            End If
        End If
    End Sub
    Private Sub UpdatePKODetails()
        Try
            Dim intCount As Integer = dgvPKODetails.CurrentRow.Index

            If lTempTankNo = cmbStockTank.Text Then

                dgvPKODetails.Rows(intCount).Cells("dgclStorage").Value = cmbStockTank.Text
                If Me.lblCapacityValue.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
                End If
                'If Me.lblBalanceValue.Text <> Nothing Then
                If Me.txtPrevDayReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = Me.txtPrevDayReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
                End If
                If Me.txtCurrentReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
                End If

                If Me.txtWriteoff.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclWriteoff").Value = Me.txtWriteoff.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclWriteoff").Value = DBNull.Value
                End If

                If Me.txtReason.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclReason").Value = Me.txtReason.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclReason").Value = DBNull.Value
                End If

                If Me.txtTemparature.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
                End If
                If Me.txtMeasurement.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = Me.txtMeasurement.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = DBNull.Value
                End If
                If Me.txtFFA.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = Me.txtFFA.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = DBNull.Value
                End If
                If Me.txtDirt.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = txtDirt.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = DBNull.Value
                End If
                If Me.txtMoisture.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
                End If

                dgvPKODetails.Rows(intCount).Cells("dgclStockTankID").Value = cmbStockTank.SelectedValue.ToString
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True
                'clear()

            ElseIf Not TankNoExist(cmbStockTank.Text) Then

                dgvPKODetails.Rows(intCount).Cells("dgclStorage").Value = cmbStockTank.Text

                If Me.lblCapacityValue.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
                End If
                'If Me.lblBalanceValue.Text <> Nothing Then
                If Me.txtPrevDayReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = Me.txtPrevDayReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
                End If
                If Me.txtCurrentReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
                End If

                If Me.txtWriteoff.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclWriteoff").Value = Me.txtWriteoff.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclWriteoff").Value = DBNull.Value
                End If

                If Me.txtReason.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclReason").Value = Me.txtReason.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclReason").Value = DBNull.Value
                End If

                If Me.txtTemparature.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
                End If
                If Me.txtMeasurement.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = Me.txtMeasurement.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = DBNull.Value
                End If
                If Me.txtFFA.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = Me.txtFFA.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = DBNull.Value
                End If
                If Me.txtDirt.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = txtDirt.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = DBNull.Value
                End If
                If Me.txtMoisture.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
                End If

                dgvPKODetails.Rows(intCount).Cells("dgclStockTankID").Value = cmbStockTank.SelectedValue.ToString
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg24")
                ''MessageBox.Show("Sorry This Tank No already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        ' PKOGetMonthYearQty() 'For MonthTodate , YearTodate Calculation
        Add_Clicked()
        ProductionTodayCalculation()

    End Sub

    Private Sub btnResetMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMain.Click
        ResetMain()
    End Sub

    Private Sub dgvCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKODetails.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                BindDgvPKODetails()
            End If
        End If



    End Sub
    Private Sub BindDgvPKODetails()
        Try
            If dgvPKODetails.Rows.Count > 0 Then
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Update"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Memperbarui"
                End If
                ''Me.btnAdd.Text = "Update"
                'Me.btnSaveAll.Text = "Update All"
                ' Dim tempGrid As String

                cmbStockTank.Text = dgvPKODetails.SelectedRows(0).Cells("dgclStorage").Value.ToString()
                lTempTankNo = dgvPKODetails.SelectedRows(0).Cells("dgclStorage").Value.ToString()

                If dgvPKODetails.SelectedRows(0).Cells("dgclProdStockID").Value <> String.Empty Then
                    lProdStockID = dgvPKODetails.SelectedRows(0).Cells("dgclProdStockID").Value.ToString()
                Else
                    lProdStockID = String.Empty
                End If

                If Not dgvPKODetails.SelectedRows(0).Cells("dgclCapacity").Value.ToString() Is DBNull.Value Then
                    Me.lblCapacityValue.Text = dgvPKODetails.SelectedRows(0).Cells("dgclCapacity").Value.ToString()
                End If
                If Not dgvPKODetails.SelectedRows(0).Cells("dgclBalance").Value.ToString() Is DBNull.Value Then
                    ' Me.lblBalanceValue.Text = dgvPKODetails.SelectedRows(0).Cells("dgclBalance").Value.ToString()
                    Me.txtPrevDayReading.Text = dgvPKODetails.SelectedRows(0).Cells("dgclBalance").Value.ToString()
                End If
                If Not dgvPKODetails.SelectedRows(0).Cells("dgclMeasurement").Value.ToString() Is DBNull.Value Then
                    Me.txtMeasurement.Text = dgvPKODetails.SelectedRows(0).Cells("dgclMeasurement").Value.ToString()
                End If
                If Not dgvPKODetails.SelectedRows(0).Cells("dgclCurrentReading").Value.ToString() Is DBNull.Value Then
                    Me.txtCurrentReading.Text = dgvPKODetails.SelectedRows(0).Cells("dgclCurrentReading").Value.ToString()
                End If

                If Not dgvPKODetails.SelectedRows(0).Cells("dgclWriteoff").Value.ToString() Is DBNull.Value Then
                    Me.txtWriteoff.Text = dgvPKODetails.SelectedRows(0).Cells("dgclWriteoff").Value.ToString()
                End If

                If Not dgvPKODetails.SelectedRows(0).Cells("dgclReason").Value.ToString() Is DBNull.Value Then
                    Me.txtReason.Text = dgvPKODetails.SelectedRows(0).Cells("dgclReason").Value.ToString()
                End If

                If Not dgvPKODetails.SelectedRows(0).Cells("dgclMoisture").Value.ToString() Is DBNull.Value Then
                    Me.txtMoisture.Text = dgvPKODetails.SelectedRows(0).Cells("dgclMoisture").Value.ToString()
                End If
                Dim tempstr As String = String.Empty
                If Not dgvPKODetails.SelectedRows(0).Cells("dgclTemperature").Value.ToString() Is DBNull.Value Then
                    txtTemparature.Text = dgvPKODetails.SelectedRows(0).Cells("dgclTemperature").Value.ToString()
                End If

                If Not dgvPKODetails.SelectedRows(0).Cells("dgclFFA").Value.ToString() Is DBNull.Value Then
                    Me.txtFFA.Text = dgvPKODetails.SelectedRows(0).Cells("dgclFFA").Value.ToString()
                End If

                If Not dgvPKODetails.SelectedRows(0).Cells("dgclDirt").Value.ToString() Is DBNull.Value Then
                    txtDirt.Text = dgvPKODetails.SelectedRows(0).Cells("dgclDirt").Value.ToString()
                End If

                AddFlag = False
                btnAddFlag = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgvPKOView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPKOView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdatePKOView()
            e.Handled = True
        End If
    End Sub
    Private Sub SaveLoadPKODetail()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL

            Dim intRowcount As Integer = dtLoadPKOAdd.Rows.Count

            If Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpPKODate.Value) Then 'Location Validation 
                objCPOPPT.CropYieldID = lCropYieldID
                'Dim objCheckDuplicateRecord As Object = 0
                objCPOPPT.CPODate = dtpPKODate.Value
                'objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                'Dim objCheckDuplicateLoadLocation As Object = 0

                'objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
                'objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString

                'objCheckDuplicateLoadLocation = objCPOBOL.DuplicateLoadLocationCheck(objCPOPPT)

                ''Dim objCheckDuplicateTank As Object = 0
                ''objCPOPPT.TankID = lLoadTankID
                ''objCheckDuplicateTank = objCPOBOL.DuplicateLoadTankCheck(objCPOPPT)

                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If

                rowLoadPKOAdd = dtLoadPKOAdd.NewRow()

                If intRowcount = 0 And dtLoadAddFlag = False Then
                    Try

                        columnLoadPKOAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadMonthToDate", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadTankID", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)

                        ''''For Remarks ''''''''''''''''''''''
                        columnLoadPKOAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)


                        rowLoadPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadPKOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadMonthToDate") = Me.txtLoadMonthToDate.Text
                        End If

                        rowLoadPKOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadPKOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString

                        ''''For Remarks''''''''''''''''''
                        rowLoadPKOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim


                        dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)
                        dtLoadAddFlag = True

                    Catch ex As Exception
                        rowLoadPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadPKOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadMonthToDate") = Me.txtLoadMonthToDate.Text
                        End If
                        rowLoadPKOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadPKOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString

                        ''''For Remarks''''''''''''''''''
                        rowLoadPKOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)
                        dtLoadAddFlag = True
                    End Try


                Else

                    rowLoadPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    rowLoadPKOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowLoadPKOAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowLoadPKOAdd("LoadMonthToDate") = Me.txtLoadMonthToDate.Text
                    End If
                    rowLoadPKOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                    rowLoadPKOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString

                    dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)

                    ''''For Remarks''''''''''''''''''
                    rowLoadPKOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                End If
            Else

                DisplayInfoMessage("Msg25")
                ''MessageBox.Show("Sorry this Tank No, Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvLoadCPODetails
                .DataSource = dtLoadPKOAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SaveTransPKODetail()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            Dim intRowcount As Integer = dtTransPKOAdd.Rows.Count

            If Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, dtpPKODate.Value) Then 'Location Validation 

                ''Dim objCheckDuplicateRecord As Object = 0
                'objCPOPPT.CPODate = dtpPKODate.Value
                ''objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                'Dim objCheckDuplicateLoadLocation As Object = 0


                'objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
                'objCPOPPT.TankID = cmbTransTank.SelectedValue.ToString


                'objCheckDuplicateLoadLocation = objCPOBOL.DuplicateTransLocationCheck(objCPOPPT)

                'Dim objCheckDuplicateTank As Object = 0
                'objCPOPPT.TankID = lTransTankID
                'objCheckDuplicateTank = objCPOBOL.DuplicateTransTankCheck(objCPOPPT)

                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If

                rowTransPKOAdd = dtTransPKOAdd.NewRow()

                If intRowcount = 0 And btnAddTransFlag = True Then
                    Try

                        columnTransPKOAdd = New DataColumn("TransTankNo", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)
                        columnTransPKOAdd = New DataColumn("TransLocation", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)
                        columnTransPKOAdd = New DataColumn("TransQty", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)
                        columnTransPKOAdd = New DataColumn("TransMonthToDate", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)
                        columnTransPKOAdd = New DataColumn("TransTankID", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)
                        columnTransPKOAdd = New DataColumn("TransLocationID", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)

                        ''''For Remarks'''''''''''''''''''''''''''''
                        columnTransPKOAdd = New DataColumn("TransRemarks", System.Type.[GetType]("System.String"))
                        dtTransPKOAdd.Columns.Add(columnTransPKOAdd)


                        rowTransPKOAdd("TransTankNo") = Me.cmbTransTank.Text
                        rowTransPKOAdd("TransLocation") = Me.cmbLoadTrans.Text

                        If Me.txtTransQty.Text <> String.Empty Then
                            rowTransPKOAdd("TransQty") = Me.txtTransQty.Text
                        End If
                        If Me.txtTransMonthToDate.Text <> String.Empty Then
                            rowTransPKOAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                        End If

                        rowTransPKOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString
                        rowTransPKOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString

                        '''''For Remarks'''''''''''''''''''''''''
                        rowTransPKOAdd("TransRemarks") = txtTransRemarks.Text.Trim

                        dtTransPKOAdd.Rows.InsertAt(rowTransPKOAdd, intRowcount)
                        dtTransAddFlag = True
                    Catch ex As Exception
                        rowTransPKOAdd("TransTankNo") = Me.cmbTransTank.Text
                        rowTransPKOAdd("TransLocation") = Me.cmbLoadTrans.Text

                        If Me.txtTransQty.Text <> String.Empty Then
                            rowTransPKOAdd("TransQty") = Me.txtTransQty.Text
                        End If
                        If Me.txtTransMonthToDate.Text <> String.Empty Then
                            rowTransPKOAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                        End If

                        rowTransPKOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString
                        rowTransPKOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString



                        '''''For Remarks'''''''''''''''''''''''''
                        rowTransPKOAdd("TransRemarks") = txtTransRemarks.Text.Trim

                        dtTransPKOAdd.Rows.InsertAt(rowTransPKOAdd, intRowcount)
                        dtTransAddFlag = True
                    End Try

                Else
                    rowTransPKOAdd("TransTankNo") = Me.cmbTransTank.Text
                    rowTransPKOAdd("TransLocation") = Me.cmbLoadTrans.Text

                    If Me.txtTransQty.Text <> String.Empty Then
                        rowTransPKOAdd("TransQty") = Me.txtTransQty.Text
                    End If
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowTransPKOAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                    End If

                    rowTransPKOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString
                    rowTransPKOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString


                    '''''For Remarks'''''''''''''''''''''''''
                    rowTransPKOAdd("TransRemarks") = txtTransRemarks.Text.Trim

                    dtTransPKOAdd.Rows.InsertAt(rowTransPKOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg26")
                ''MessageBox.Show("Sorry this Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvPKOTransDetails
                .DataSource = dtTransPKOAdd
                .AutoGenerateColumns = False
            End With

            'If dgvPKODetails.Rows.Count <> 0 Then
            '    For Each objDataGridViewRow In dgvPKODetails.Rows
            '        If objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString <> String.Empty Then
            '            lCurrentReadingToday = lCurrentReadingToday + Val(objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString())
            '        End If
            '    Next
            'End If

            'If dgvLoadCPODetails.Rows.Count <> 0 Then
            '    For Each objDataGridViewRow In dgvLoadCPODetails.Rows
            '        If objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString <> String.Empty Then
            '            lLoadQtyToday = lLoadQtyToday + Val(objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString())
            '        End If
            '    Next
            'End If

            'If dgvPKOTransDetails.Rows.Count <> 0 Then
            '    For Each objDataGridViewRow In dgvPKOTransDetails.Rows
            '        If objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString <> String.Empty Then
            '            lTransQtyToday = lTransQtyToday + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
            '        End If
            '    Next
            'End If
            'lTodayQty = lCurrentReadingToday + lLoadQtyToday + lTransQtyToday - lBalanceToday
            'txtProductionToday.Text = lTodayQty

        Catch ex As Exception
        End Try
    End Sub
    Private Function LocationExist(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvLoadCPODetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclLoadStorageNo").Value And Location = objDataGridViewRow.Cells("dgclToLoading").Value) Then
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
    Private Function LocationExistTrans(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvPKOTransDetails.Rows
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
    Private Function TankNoExist(ByVal TankNo As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvPKODetails.Rows
                If TankNo = objDataGridViewRow.Cells("dgclStorage").Value.ToString() Then
                    ' txtStockCode.Text = ""
                    cmbStockTank.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try
        'End If
    End Function
    Private Sub UpdateCPODetails()
        Try
            Dim intCount As Integer = dgvPKODetails.CurrentRow.Index

            If lTempTankNo = cmbStockTank.Text Then

                'StrAdjustDate = Me.dtpAdjustmentDate.Text
                'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                'dgvCPODetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate

                dgvPKODetails.Rows(intCount).Cells("dgclStorage").Value = cmbStockTank.Text

                If Me.lblCapacityValue.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
                End If
                ' If Me.lblBalanceValue.Text <> Nothing Then
                If Me.txtPrevDayReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = Me.txtPrevDayReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
                End If
                If Me.txtCurrentReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
                End If
                If Me.txtTemparature.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
                End If
                If Me.txtMeasurement.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = Me.txtMeasurement.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = DBNull.Value
                End If
                If Me.txtFFA.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = Me.txtFFA.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = DBNull.Value
                End If
                If Me.txtDirt.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = txtDirt.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = DBNull.Value
                End If
                If Me.txtMoisture.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
                End If

                dgvPKODetails.Rows(intCount).Cells("dgclStockTankID").Value = cmbStockTank.SelectedValue.ToString
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True
                'clear()

            ElseIf Not TankNoExist(cmbStockTank.Text) Then
                dgvPKODetails.Rows(intCount).Cells("dgclStorage").Value = cmbStockTank.Text
                If Me.lblCapacityValue.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
                End If
                'If Me.lblBalanceValue.Text <> Nothing Then
                If Me.txtPrevDayReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = Me.txtPrevDayReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
                End If
                If Me.txtCurrentReading.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
                End If
                If Me.txtTemparature.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
                End If
                If Me.txtMeasurement.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = Me.txtMeasurement.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMeasurement").Value = DBNull.Value
                End If
                If Me.txtFFA.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = Me.txtFFA.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclFFA").Value = DBNull.Value
                End If
                If Me.txtDirt.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = txtDirt.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclDirt").Value = DBNull.Value
                End If
                If Me.txtMoisture.Text <> Nothing Then
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                Else
                    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
                End If

                dgvPKODetails.Rows(intCount).Cells("dgclStockTankID").Value = cmbStockTank.SelectedValue.ToString
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg24")
                ''MessageBox.Show("Sorry This Tank No already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub UpdateLoadPKODetails()
        'Try
        '    Dim intCount As Integer = dgvLoadCPODetails.CurrentRow.Index

        '    'If lTempTankNo = cmbStockTank.Text Then
        '    If lLoadTank = cmbLoadTank.Text And lLoadLocation = cmbLoadLocation.Text Then

        '        'StrAdjustDate = Me.dtpAdjustmentDate.Text
        '        'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
        '        'dgvCPODetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate

        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
        '        'If Me.lblCapacityValue.Text <> Nothing Then
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
        '        ' End If
        '        If Me.txtLoadQty.Text <> Nothing Then
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
        '        Else
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
        '        End If
        '        If Me.txtLoadMonthToDate.Text <> Nothing Then
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
        '        Else
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
        '        End If

        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString

        '        ''''For Remarks''''''''''''''''
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

        '        If GlobalPPT.strLang = "en" Then
        '            btnAddLoad.Text = "Add"
        '        ElseIf GlobalPPT.strLang = "ms" Then
        '            btnAddLoad.Text = "Menambahkan"
        '        End If

        '        ''btnAddLoad.Text = "Add"
        '        btnAddLoadFlag = True
        '        'clear()

        '    ElseIf Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, CPODate) Then
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
        '        'If Me.lblCapacityValue.Text <> Nothing Then
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
        '        ' End If
        '        If Me.txtLoadQty.Text <> Nothing Then
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
        '        Else
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
        '        End If
        '        If Me.txtLoadMonthToDate.Text <> Nothing Then
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
        '        Else
        '            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
        '        End If
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString



        '        ''''For Remarks''''''''''''''''
        '        dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim
        '        If GlobalPPT.strLang = "en" Then
        '            btnAdd.Text = "Add"
        '        ElseIf GlobalPPT.strLang = "ms" Then
        '            btnAdd.Text = "Menambahkan"
        '        End If
        '        ''btnAdd.Text = "Add"
        '        btnAddFlag = True

        '    Else

        '        DisplayInfoMessage("Msg26")
        '        '' MessageBox.Show("Sorry This Tank No, Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub UpdateTransPKODetails()
        Try
            Dim intCount As Integer = dgvPKOTransDetails.CurrentRow.Index

            ' If lTempTankNo = cmbStockTank.Text Then
            If lTransTank = cmbTransTank.Text And lloadTrans = cmbLoadTrans.Text Then

                'StrAdjustDate = Me.dtpAdjustmentDate.Text
                'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                'dgvCPODetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate

                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If

                If Me.txtTransQty.Text <> Nothing Then
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If

                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString

                ''''For Remarks '''''''''''''''''''''''''''''''
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim

                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                ''btnAddTrans.Text = "Add"
                btnAddTransFlag = True
                'clear()

            ElseIf Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, CPODate) Then
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If

                If Me.txtTransQty.Text <> Nothing Then
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvPKOTransDetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If

                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString



                ''''For Remarks '''''''''''''''''''''''''''''''
                dgvPKOTransDetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim

                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg26")
                ''MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function IsCheckValidationLoad()
        'If dtpCPODate.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please check Production Date", " Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        If cmbLoadTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadLocation.Focus()
            Return False
        End If
        If cmbLoadLocation.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg11")
            '' MessageBox.Show("This field is Required", "To Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadLocation.Focus()
            Return False
        End If

        If txtLoadQty.Text = String.Empty Then
            DisplayInfoMessage("Msg27")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadQty.Focus()
            Return False
        End If
        If txtLoadMonthToDate.Text = String.Empty Then
            DisplayInfoMessage("Msg28")
            ''MessageBox.Show("This Field is Required", "Month To Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadMonthToDate.Focus()
            Return False
        End If
        If Val(txtLoadMonthToDate.Text) < Val(txtLoadQty.Text) Then
            DisplayInfoMessage("Msg13")
            '' MessageBox.Show("Month To Date value cant be lesser than Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadMonthToDate.Focus()
            Return False
        End If

        Return True
    End Function
    Private Function IsCheckValidationTrans()
        'If dtpCPODate.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please check Production Date", " Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        If cmbTransTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg29")
            ''MessageBox.Show("This field is Required", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTransTank.Focus()
            Return False
        End If
        If cmbLoadTrans.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg30")
            ''MessageBox.Show("This field is Required", "Transshipment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        If txtTransQty.Text = String.Empty Then
            DisplayInfoMessage("Msg27")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransQty.Focus()
            Return False
        End If
        If txtTransMonthToDate.Text = String.Empty Then
            DisplayInfoMessage("Msg28")
            ''MessageBox.Show("This Field is Required", "Month To Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransMonthToDate.Focus()
            Return False
        End If

        If cmbLoadTrans.Text = cmbTransTank.Text Then
            DisplayInfoMessage("Msg31")
            ''MessageBox.Show("Loading and Transshipment cant be same ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If

        If Val(txtTransMonthToDate.Text) < Val(txtTransQty.Text) Then
            DisplayInfoMessage("Msg32")
            ''MessageBox.Show("Month To Date value cant be lesser than Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransMonthToDate.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub AddLoad_Clicked()
        If lLoadCapacity < lLoadQty Then
            DisplayInfoMessage("Msg33")
            '' MessageBox.Show("Sum of  Quantity(Mt) should be lesser than Storage Tank Capacity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadQty.Focus()
            Exit Sub
        End If

        If btnAddLoadFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (IsCheckValidationLoad() = False) Then
                Exit Sub
            Else
                'Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))
                SaveLoadPKODetail()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetLoad()
            End If
        ElseIf btnAddLoadFlag = False Then
            If (IsCheckValidationLoad() = False) Then
                Exit Sub
            Else
                UpdateLoadPKODetails()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetLoad()
            End If
        End If
    End Sub
    Private Sub AddTrans_Clicked()

        'If dgvPKODetails.Rows.Count <> 0 Then
        '    For Each objDataGridViewRow In dgvPKODetails.Rows
        '        If objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString <> String.Empty Then
        '            lCurrentReadingToday = lCurrentReadingToday + Val(objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString())
        '        End If
        '    Next
        'End If

        'If dgvLoadCPODetails.Rows.Count <> 0 Then
        '    For Each objDataGridViewRow In dgvLoadCPODetails.Rows
        '        If objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString <> String.Empty Then
        '            lLoadQtyToday = lLoadQtyToday + Val(objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString())
        '        End If
        '    Next
        'End If

        'If lTransCapacity < lTransferQty Then
        '    MessageBox.Show("Sum of  Quantity(Mt) should be lesser than Storage Tank Capacity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtTransQty.Focus()
        '    Exit Sub
        'End If


        If btnAddTransFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (IsCheckValidationTrans() = False) Then
                Exit Sub
            Else

                SaveTransPKODetail()
                'If dgvPKOTransDetails.Rows.Count <> 0 Then
                '    For Each objDataGridViewRow In dgvPKOTransDetails.Rows
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
                UpdateTransPKODetails()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetTrans()
            End If
        End If
    End Sub
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
        txtLoadQty.Text = ""
        txtLoadRemarks.Text = ""
        'lblLoadingDescription.Text = "Description"
        'CPOGetLoadTransMonthQty()
        If GlobalPPT.strLang = "en" Then
            btnAddLoad.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddLoad.Text = "Menambahkan"
        End If
        ''btnAddLoad.Text = "Add"
        btnAddLoadFlag = True
        lLoadQtyPrev = 0
    End Sub
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
        'lblTranshipDescription.Text = "Description"
        '  CPOGetLoadTransMonthQty()
        If GlobalPPT.strLang = "en" Then
            btnAddTrans.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddTrans.Text = "Menambahkan"
        End If
        ''btnAddTrans.Text = "Add"
        btnAddTransFlag = True
        lTransferQtyPrev = 0
    End Sub
    Private Sub btnAddLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLoad.Click
        LoadQtyCheck()
        AddLoad_Clicked()
        ProductionTodayCalculation()
    End Sub
    Private Sub btnAddTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTrans.Click
        'TransferQtyCheck()
        AddTrans_Clicked()
        ProductionTodayCalculation()
    End Sub
    Private Sub btnResetLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetLoad.Click
        ResetLoadPKO()
    End Sub
    Private Sub btnResetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetTrans.Click
        ResetTrans()
    End Sub
    'Private Sub BindDgvLoadPKODetails()

    '    If dgvLoadCPODetails.Rows.Count > 0 Then

    '        If GlobalPPT.strLang = "en" Then
    '            btnAddLoad.Text = "Update"
    '        ElseIf GlobalPPT.strLang = "ms" Then
    '            btnAddLoad.Text = "Memperbarui"
    '        End If
    '        ''Me.btnAddLoad.Text = "Update"
    '        ' Me.btnSaveAll.Text = "Update All"
    '        btnAddLoadFlag = False

    '        cmbLoadTank.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
    '        lLoadTank = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
    '        cmbLoadLocation.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
    '        lLoadLocation = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
    '        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is DBNull.Value Then
    '            lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value
    '        Else
    '            lProdLoadingID = Nothing
    '        End If
    '        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString() Is DBNull.Value Then
    '            Me.txtLoadQty.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
    '            lLoadQtyPrev = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
    '        End If

    '        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString() Is DBNull.Value Then
    '            Me.txtLoadMonthToDate.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString()
    '        End If

    '        ''''For Remarks''''''''
    '        Me.txtLoadRemarks.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadRemarks").Value.ToString()

    '        If LoadMonthCount = 1 And SaveFlag = False Then
    '            txtLoadMonthToDate.Enabled = True
    '        End If
    '        ' AddFlag = False

    '    End If

    'End Sub
    Private Sub BindDgvTransPKODetails()

        If dgvPKOTransDetails.Rows.Count > 0 Then

            If GlobalPPT.strLang = "en" Then
                btnAddTrans.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddTrans.Text = "Memperbarui"
            End If
            ''Me.btnAddTrans.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddTransFlag = False

            cmbTransTank.Text = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            lTransTank = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            cmbLoadTrans.Text = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()
            lloadTrans = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()
            If Not dgvPKOTransDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is DBNull.Value Then
                lProdTranshipID = dgvPKOTransDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value
            Else
                lProdTranshipID = Nothing
            End If
            If Not dgvPKOTransDetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtTransQty.Text = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
                lTransferQtyPrev = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
            End If

            If Not dgvPKOTransDetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtTransMonthToDate.Text = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString()
            End If
            ' AddFlag = False

            ''''For Remarks''''''''
            Me.txtTransRemarks.Text = dgvPKOTransDetails.SelectedRows(0).Cells("dgclTransRemarks").Value.ToString()
            If TransMonthCount = 1 And SaveFlag = False Then
                txtTransMonthToDate.Enabled = True
            End If

        End If

    End Sub
    Private Sub dgvPKOLoadDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        BindDgvLoadPKODetails()


    End Sub

    Private Sub dgvPKOTransDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKOTransDetails.CellDoubleClick

        BindDgvTransPKODetails()
    End Sub
    Public Sub GetProductionID(ByVal CPOProductionDate As Date)
        Try
            Dim dsLoad As DataSet
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            objCPOPPT.CPODate = CPOProductionDate
            objCPOPPT.CropYieldID = lCropYieldID
            dsLoad = CPOProductionBOL.GetProductionID(objCPOPPT)
            If dsLoad.Tables.Count <> 0 Then
                If dsLoad.Tables(0).Rows.Count <> 0 Then
                    ' lTempProductionID = dsLoad.Tables(0).Rows(0).Item("ProductionID")
                    lProdIdNew = dsLoad.Tables(0).Rows(0).Item("ProductionID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub dtpPKODate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPKODate.ValueChanged
        ''PKOGetTodayQty()
        ''PKOGetMonthYearQty()
        ''CPOGetLoadTransMonthQty()
        ''UpdateTankMasterBFQty()

        'Dim objCPOPPT As New CPOProductionPPT
        'Dim objCPOBOL As New CPOProductionBOL

        'Dim objCheckDuplicateRecord As Object = 0
        'objCPOPPT.CPODate = dtpPKODate.Value
        'objCPOPPT.CropYieldID = lCropYieldID
        'objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

        'If objCheckDuplicateRecord = 0 Then
        '    GetProductionID(dtpPKODate.Value)
        '    SaveFlag = False
        'Else
        '    SaveFlag = True
        '    'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
        '    'Exit Sub
        'End If
        ''CPOProductionMonthYearSelect()

    End Sub


    Private Sub LoadTankMonthtoDate()
        If cmbLoadTank.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex > 0 And lCropYieldID <> "" Then

            Dim dsLoadMonthTodate As New DataSet
            txtLoadMonthToDate.Text = ""
            txtLoadQty.Text = ""
            LoadMonthCount = 0

            'Dim objCPOPPT As New CPOProductionPPT
            'objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString
            'objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
            'objCPOPPT.CropYieldID = lCropYieldID
            'objCPOPPT.CPODate = dtpPKODate.Value
            'dsLoadMonthTodate = CPOProductionBOL.CPOGetLoadingCPOMonthtodate(objCPOPPT)

            'If dsLoadMonthTodate.Tables(0).Rows.Count <> 0 Then
            '    lLoadMonthToDate = Val(dsLoadMonthTodate.Tables(0).Rows(0).Item("MonthTodate").ToString)
            'End If
            'LoadMonthCount = dsLoadMonthTodate.Tables(1).Rows(0).Item("LoadMonthCount").ToString

            'If LoadMonthCount = 0 Or (LoadMonthCount = 1 And btnAddLoadFlag = False And SaveFlag = False) Then
            '    txtLoadMonthToDate.Enabled = True
            'Else
            '    txtLoadMonthToDate.Enabled = False
            'End If

        Else
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        End If
    End Sub
    Private Sub TransTankMonthtoDate()
        If cmbTransTank.SelectedIndex <> 0 And cmbLoadTrans.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsTransMonthTodate As New DataSet
            txtTransMonthToDate.Text = ""
            txtTransQty.Text = ""
            TransMonthCount = 0
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.TankID = cmbTransTank.SelectedValue.ToString
            objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpPKODate.Value
            dsTransMonthTodate = CPOProductionBOL.CPOGetTranshipCPOMonthtodate(objCPOPPT)

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

    Private Sub CPOProductionMonthYearSelect()

        Dim objCPOPPT As New CPOProductionPPT
        objCPOPPT.CropYieldID = lCropYieldID
        objCPOPPT.CPOProductionDate = DtpProductionDate.Value
        Dim DsMonthYearValue As New DataSet
        txtProductionMonth.Text = ""
        txtProductionYear.Text = ""
        MonthCount = 0
        YearCount = 0
        DsMonthYearValue = CPOProductionBOL.CPOProductionMonthYeartodate(objCPOPPT)

        If DsMonthYearValue.Tables(0).Rows.Count <> 0 Then
            lProductionMonth = DsMonthYearValue.Tables(0).Rows(0).Item("MonthTodate").ToString
        End If
        MonthCount = DsMonthYearValue.Tables(2).Rows(0).Item("MonthCount").ToString
        If DsMonthYearValue.Tables(1).Rows.Count <> 0 Then
            lProductionYear = DsMonthYearValue.Tables(1).Rows(0).Item("YearTodate").ToString
        End If
        YearCount = DsMonthYearValue.Tables(3).Rows(0).Item("YearCount").ToString

        If MonthCount = 0 Or (MonthCount = 1 And SaveFlag = False) Then
            txtProductionMonth.Enabled = True
        Else
            txtProductionMonth.Enabled = False
        End If

        If YearCount = 0 Or (YearCount = 1 And SaveFlag = False) Then
            txtProductionYear.Enabled = True
        Else
            txtProductionYear.Enabled = False

        End If
    End Sub

    Private Sub ProductionTodayCalculation()
        lCurrentReadingToday = 0
        lLoadQtyToday = 0
        lPrevDayQtyLoad = 0
        lBalanceToday = 0
        If dgvPKODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvPKODetails.Rows
                If objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString <> String.Empty Then
                    lCurrentReadingToday = lCurrentReadingToday + Val(objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString())
                    lBalanceToday = lBalanceToday + Val(objDataGridViewRow.Cells("dgclBalance").Value.ToString())
                End If
            Next
        End If

        If dgvLoadCPODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvLoadCPODetails.Rows
                If objDataGridViewRow.Cells("dgclLoadCtReading").Value.ToString <> String.Empty Then
                    lLoadQtyToday = lLoadQtyToday + Val(objDataGridViewRow.Cells("dgclLoadCtReading").Value.ToString())
                    lPrevDayQtyLoad = lPrevDayQtyLoad + Val(objDataGridViewRow.Cells("dgclPrevDayReadnig").Value.ToString())
                End If
            Next
        End If

        If lPrevDayQtyLoad = 0 Then
            lPrevDayQtyLoad = lPrevdayPontoonQty
        End If
        CPOProductionTranshipqtySelect()

        lProductionToday = (lCurrentReadingToday + lLoadQtyToday + lTotalTranshipQty) - (lBalanceToday) - (lPrevDayQtyLoad)
        txtProductionToday.Text = Math.Round(lProductionToday, 3)
        lPrevdayPontoonQty = 0
    End Sub
    Private Sub CPOProductionTranshipqtySelect()
        Dim ds As New DataSet
        Dim objCPOPPT As New CPOProductionPPT
        '  Dim objCPOPPT As New CPOProductionPPT
        objCPOPPT.CPOProductionDate = DtpProductionDate.Value
        objCPOPPT.CropYieldID = lCropYieldID

        ds = CPOProductionBOL.CPOProductionTranshipqtySelect(objCPOPPT)
        If ds.Tables(0).Rows.Count <> 0 Then
            lTotalTranshipQty = Val(ds.Tables(0).Rows(0).Item("Qty"))
        Else
            lTotalTranshipQty = 0

        End If
    End Sub


    Private Sub txtLoadQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadQty.Leave
        If lLoadCapacity < Val(txtLoadQty.Text) Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("Quantity Cant be greater than Storage Capacity")
            txtLoadQty.Focus()
        End If

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

    Private Sub txtBalance_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrevDayReading.KeyDown
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

    Private Sub txtBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrevDayReading.KeyPress
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
    Private Sub LoadQtyCheck()
        'lLoadQty = 0

        'If dgvLoadCPODetails.Rows.Count <> 0 Then
        '    For Each objDataGridViewRow In dgvLoadCPODetails.Rows
        '        If objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclLoadStorageID").Value.ToString = cmbLoadTank.SelectedValue.ToString Then
        '            lLoadQty = lLoadQty + Val(objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString())
        '        End If
        '    Next
        'End If

        'lLoadQty = lLoadQty + Val(txtLoadQty.Text) - lLoadQtyPrev


    End Sub

    Private Sub TransferQtyCheck()
        lTransferQty = 0

        If dgvPKOTransDetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvPKOTransDetails.Rows
                If objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclTransStorageID").Value.ToString = cmbTransTank.SelectedValue.ToString Then
                    lTransferQty = lTransferQty + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
                End If
            Next
        End If

        lTransferQty = lTransferQty + Val(txtTransQty.Text) - lTransferQtyPrev



    End Sub

    Private Sub txtProductionToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionToday.TextChanged
        If Val(txtProductionToday.Text) > 0 Then
            '  ProductionTodayCalculation()
            CPOProductionMonthYearSelect()
            If lProductionToday > 0 And lProductionMonth > 0 And MonthCount > 1 And SaveFlag = True Then
                txtProductionMonth.Text = lProductionToday + lProductionMonth
            ElseIf lProductionToday > 0 And lProductionMonth > 0 And MonthCount > 1 And SaveFlag = False Then
                txtProductionMonth.Text = lProductionToday + lProductionMonth - lQtyPrev
            ElseIf lProductionMonth > 0 And MonthCount = 1 And SaveFlag = False Then
                txtProductionMonth.Text = lProductionMonth
                txtProductionMonth.Enabled = True
            ElseIf lProductionMonth > 0 And MonthCount = 1 And SaveFlag = True Then
                txtProductionMonth.Text = lProductionToday + lProductionMonth
            ElseIf lProductionMonth = 0 And MonthCount >= 1 Then
                txtProductionMonth.Text = lProductionToday
            Else
                txtProductionMonth.Text = ""
                txtProductionMonth.Enabled = True
            End If
            If lProductionToday > 0 And lProductionYear > 0 And YearCount > 1 And SaveFlag = True Then
                txtProductionYear.Text = lProductionToday + lProductionYear
            ElseIf lProductionToday > 0 And lProductionYear > 0 And YearCount > 1 And SaveFlag = False Then
                txtProductionYear.Text = lProductionToday + lProductionYear - lQtyPrev
            ElseIf lProductionYear > 0 And YearCount = 1 And SaveFlag = False Then
                txtProductionYear.Text = lProductionYear
                txtProductionYear.Enabled = True
            ElseIf lProductionYear > 0 And YearCount = 1 And SaveFlag = True Then
                txtProductionYear.Text = lProductionToday + lProductionYear
            ElseIf lProductionYear = 0 And YearCount >= 1 Then
                txtProductionYear.Text = lProductionToday
            Else
                txtProductionYear.Text = ""
                txtProductionYear.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtBalance_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrevDayReading.Leave
        If Val(lblCapacityValue.Text) < Val(txtPrevDayReading.Text) Then
            DisplayInfoMessage("Msg35")
            ''MessageBox.Show("Balance B/F(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub

    Private Sub txtCurrentReading_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentReading.Leave
        If Val(lblCapacityValue.Text) < Val(txtCurrentReading.Text) Then
            DisplayInfoMessage("Msg36")
            ''MessageBox.Show("Current Reading(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

   
    Private Sub tcPKOProduction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcPKOProduction.SelectedIndexChanged
        'ResetMain()
        'Reset()
        'ResetLoad()
        'ResetTrans()
        ' PKOGridViewBind()
    End Sub

    Private Sub txtLoadMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadMonthToDate.TextChanged
        If Val(txtLoadMonthToDate.Text) = 0 Then
            txtLoadMonthToDate.Text = ""
        End If
    End Sub

    Private Sub txtTransMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransMonthToDate.TextChanged
        If Val(txtTransMonthToDate.Text) = 0 Then
            txtTransMonthToDate.Text = ""
        End If
    End Sub

   
    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL

        If lProductionID <> String.Empty Then
            objCPOPPT.CPODate = dtpPKODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOBOL.Delete_CPODetail(objCPOPPT)
            PKOGridViewBind()
        End If


        Reset()
        ResetMain()
        ResetLoad()
        ResetTrans()
    End Sub

    Private Sub StockCPOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCPOEdit.Click
        BindDgvPKODetails()
    End Sub

    Private Sub StockCPODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCPODelete.Click
        If dgvPKODetails.RowCount = 0 Then

            Exit Sub
        ElseIf dgvPKODetails.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridStockPKO()
            ProductionTodayCalculation()
        End If
 
    End Sub

    Private Sub LoadCPOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPOEdit.Click
        BindDgvLoadPKODetails()
    End Sub

    Private Sub LoadCPODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPODelete.Click
        If dgvLoadCPODetails.RowCount = 0 Then

            Exit Sub
        ElseIf dgvLoadCPODetails.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else

            DeleteMultientrydatagridLoadPKO()
            ProductionTodayCalculation()
        End If

    End Sub

    Private Sub TranshipEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipEdit.Click
        BindDgvTransPKODetails()
    End Sub

    Private Sub TranshipDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipDelete.Click
        DeleteMultientrydatagridTranshipPKO()
    End Sub



    Private Sub DeleteMultientrydatagridStockPKO()

        If Not dgvPKODetails.SelectedRows(0).Cells("dgclProdStockID").Value Is Nothing Then
            lProdStockID = dgvPKODetails.SelectedRows(0).Cells("dgclProdStockID").Value.ToString
        Else
            lProdStockID = String.Empty
        End If

        lDelete = 0
        If lProdStockID <> "" Then
            lDelete = DeleteMultientryStockPKO.Count

            DeleteMultientryStockPKO.Insert(lDelete, lProdStockID)

            ' lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtPKOAdd.Rows.Item(dgvPKODetails.CurrentRow.Index)
        Dr.Delete()
        dtPKOAdd.AcceptChanges()
        lProdStockID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultientrydatagridLoadPKO()

        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value Is Nothing Then
            lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value.ToString
        Else
            lProdLoadingID = String.Empty
        End If



        lDelete = 0
        If lProdLoadingID <> "" Then
            lDelete = DeleteMultientryLoadPKO.Count
            DeleteMultientryLoadPKO.Insert(lDelete, lProdLoadingID)
        End If
        Dim Dr As DataRow
        Dr = dtLoadPKOAdd.Rows.Item(dgvLoadCPODetails.CurrentRow.Index)
        Dr.Delete()
        dtLoadPKOAdd.AcceptChanges()
        lProdLoadingID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultientrydatagridTranshipPKO()

        If Not dgvPKOTransDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is Nothing Then
            lProdTranshipID = dgvPKOTransDetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value.ToString
        Else
            lProdTranshipID = String.Empty
        End If



        lDelete = 0
        If lProdTranshipID <> "" Then
            lDelete = DeleteMultientryTransPKO.Count
            DeleteMultientryTransPKO.Insert(lDelete, lProdTranshipID)
        End If
        Dim Dr As DataRow
        Dr = dtTransPKOAdd.Rows.Item(dgvPKOTransDetails.CurrentRow.Index)
        Dr.Delete()
        dtTransPKOAdd.AcceptChanges()
        lProdTranshipID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultiEntryRecordsStockPKO()
        Dim objCPOProductionPPT As New CPOProductionPPT

        lDelete = DeleteMultientryStockPKO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdStockID = DeleteMultientryStockPKO(lDelete - 1)

            Dim IntProdStockDelete As New Integer
            IntProdStockDelete = CPOProductionBOL.DeleteMultiEntryProdStock(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteMultiEntryRecordsLoadingPKO()
       Dim objCPOProductionPPT As New CPOProductionPPT
        lDelete = DeleteMultientryLoadPKO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdLoadingID = DeleteMultientryLoadPKO(lDelete - 1)

            Dim IntProdLoadingDelete As New Integer
            IntProdLoadingDelete = CPOProductionBOL.DeleteMultiEntryProdLoading(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteMultiEntryRecordsTranshipPKO()
        Dim objCPOProductionPPT As New CPOProductionPPT
        lDelete = DeleteMultientryTransPKO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdTranshipID = DeleteMultientryTransPKO(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = CPOProductionBOL.DeleteMultiEntryProdTranship(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub


    Private Sub btnLoadAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAdd.Click
        AddLoadCPO_Clicked()
        ProductionTodayCalculation()
    End Sub

    Private Sub AddLoadCPO_Clicked()
        If LbtnPKOLoadadd = True Then
            If (IsCheckValidationLoad_PKO() = True) Then
                AddLoadPKODetail()
                ResetLoadPKO()
            End If
        Else
            If (IsCheckValidationLoad_PKO() = True) Then
                UpdatePKOLoadDetails()
                ResetLoadPKO()
            End If

        End If
    End Sub


    Private Sub UpdatePKOLoadDetails()

        Dim intCount As Integer = dgvLoadCPODetails.CurrentRow.Index

        If lLoadLocation = cbLoading.Text Then
            dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cbLoading.Text
            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadCtReading").Value = Me.txtLoadCtReading.Text
            dgvLoadCPODetails.Rows(intCount).Cells("dgclPrevDayReadnig").Value = Me.txtLoadPrevDayReading.Text
            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cbLoading.SelectedValue.ToString
            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadCPORemarks.Text.Trim
            dgvLoadCPODetails.Rows(intCount).Cells("dgclProdLoadID").Value = lProdLoadingID

            If GlobalPPT.strLang = "en" Then
                btnLoadAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnLoadAdd.Text = "Menambahkan"
            End If

        ElseIf Not LocationExist(cbLoading.Text, cmbLoadTank.Text, dtpPKODate.Value) Then
            dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cbLoading.Text
            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadCtReading").Value = Me.txtLoadCtReading.Text
            dgvLoadCPODetails.Rows(intCount).Cells("dgclPrevDayReadnig").Value = Me.txtLoadPrevDayReading.Text
            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cbLoading.SelectedValue.ToString
            dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadCPORemarks.Text.Trim
            dgvLoadCPODetails.Rows(intCount).Cells("dgclProdLoadID").Value = lProdLoadingID

            If GlobalPPT.strLang = "en" Then
                btnLoadAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnLoadAdd.Text = "Menambahkan"
            End If
        Else
            DisplayInfoMessage("Msg37")
        End If
        LbtnPKOLoadadd = True
    End Sub
    Public Sub ResetLoadPKO()

        If cbLoading.Items.Count > 0 Then
            cbLoading.SelectedIndex = 0
        End If
        txtLoadPrevDayReading.Text = ""
        txtLoadCPORemarks.Text = ""
        txtLoadCtReading.Text = ""
        LbtnPKOLoadadd = True
        If GlobalPPT.strLang = "en" Then
            btnLoadAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnLoadAdd.Text = "Menambahkan"
        End If

    End Sub
    Private Function IsCheckValidationLoad_PKO()

        If cbLoading.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg29")
            cbLoading.Focus()
            Return False
        End If
        If txtLoadCtReading.Text.Trim = "" Then
            DisplayInfoMessage("Msg6")
            txtLoadCtReading.Focus()
            Return False
        End If
        If txtLoadPrevDayReading.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg161")
            txtLoadPrevDayReading.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub AddLoadPKODetail()

        Dim intRowcount As Integer = dtLoadPKOAdd.Rows.Count
        Dim objPKOPPT As New PKOProductionPPT
        Dim objPKOBOL As New PKOProductionBOL
        If Not LocationExist(cbLoading.Text, cmbLoadTank.Text, dtpPKODate.Value) Then 'Location, Tank Validation 


            rowLoadPKOAdd = dtLoadPKOAdd.NewRow()
            If intRowcount = 0 Then
                Try

                    columnLoadPKOAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                    dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                    columnLoadPKOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                    columnLoadPKOAdd = New DataColumn("LoadCtReading", System.Type.[GetType]("System.String"))
                    dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                    columnLoadPKOAdd = New DataColumn("LoadPrevDayReading", System.Type.[GetType]("System.String"))
                    dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                    columnLoadPKOAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                    dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                    columnLoadPKOAdd = New DataColumn("ProdLoadID", System.Type.[GetType]("System.String"))
                    dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)

                Catch ex As Exception
                End Try

                rowLoadPKOAdd("LoadLocation") = Me.cbLoading.Text
                rowLoadPKOAdd("LoadCtReading") = Me.txtLoadCtReading.Text
                rowLoadPKOAdd("LoadPrevDayReading") = txtLoadPrevDayReading.Text
                rowLoadPKOAdd("LoadLocationID") = cbLoading.SelectedValue.ToString
                rowLoadPKOAdd("LoadRemarks") = txtLoadCPORemarks.Text.Trim
                rowLoadPKOAdd("ProdLoadID") = ""

                dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)
                dtLoadAddFlag = True


            Else

                rowLoadPKOAdd("LoadLocation") = Me.cbLoading.Text
                rowLoadPKOAdd("LoadCtReading") = Me.txtLoadCtReading.Text
                rowLoadPKOAdd("LoadPrevDayReading") = txtLoadPrevDayReading.Text
                rowLoadPKOAdd("LoadLocationID") = cbLoading.SelectedValue.ToString
                rowLoadPKOAdd("LoadRemarks") = txtLoadCPORemarks.Text.Trim
                rowLoadPKOAdd("ProdLoadID") = ""
                dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)

            End If
        Else
            DisplayInfoMessage("Msg37")
        End If

        With dgvLoadCPODetails
            .DataSource = dtLoadPKOAdd
            .AutoGenerateColumns = False
        End With

    End Sub
    Private Sub BindDgvLoadPKODetails()

        If dgvLoadCPODetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnLoadAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnLoadAdd.Text = "Memperbarui"
            End If
            LbtnPKOLoadadd = False

            cbLoading.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            lLoadLocation = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            lLoadingLocationID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString()

            If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value Is DBNull.Value Then
                lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value
            Else
                lProdLoadingID = Nothing
            End If

            Me.txtLoadCtReading.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadCtReading").Value.ToString()
            Me.txtLoadPrevDayReading.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclPrevDayReadnig").Value.ToString()
            txtLoadCPORemarks.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadRemarks").Value.ToString()


        End If

    End Sub


    Private Sub dgvLoadCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadCPODetails.CellDoubleClick
        BindDgvLoadPKODetails()
    End Sub


    Private Sub txtLoadCtReading_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoadCtReading.KeyDown
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

    Private Sub txtLoadCtReading_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadCtReading.KeyPress
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

    Private Sub txtLoadPrevDayReading_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoadPrevDayReading.KeyDown
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

    Private Sub txtLoadPrevDayReading_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoadPrevDayReading.KeyPress
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

    Private Sub LoadPKOPrevDayQty()

        If cbLoading.SelectedIndex <> 0 And lCropYieldID <> "" Then
            Dim lLoadPrevDayQty As Decimal = 0

            Dim dsLoadMonthTodate As New DataSet
            txtLoadPrevDayReading.Text = ""
            Dim objCPOPPT As New CPOProductionPPT

            objCPOPPT.LoadingLocationID = cbLoading.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPOProductionDate = DtpProductionDate.Value

            dsLoadMonthTodate = CPOProductionBOL.CPOGetLoadingCPOMonthtodate(objCPOPPT)

            If dsLoadMonthTodate.Tables(0).Rows.Count <> 0 Then
                lLoadPrevDayQty = dsLoadMonthTodate.Tables(0).Rows(0).Item("PrevDayQty").ToString
            End If

            If lLoadPrevDayQty > 0 Then
                txtLoadPrevDayReading.Text = lLoadPrevDayQty
                txtLoadPrevDayReading.Enabled = False
            Else
                txtLoadPrevDayReading.Text = ""
                txtLoadPrevDayReading.Enabled = True
            End If
        Else
            txtLoadPrevDayReading.Text = ""
            txtLoadPrevDayReading.Enabled = True

        End If




    End Sub
  
    Private Sub cbLoading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLoading.SelectedIndexChanged
        LoadPKOPrevDayQty()
    End Sub

    Private Sub btnLoadReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadReset.Click
        ResetLoadPKO()
    End Sub

    Private Sub txtProductionMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionMonth.TextChanged
        If Val(txtProductionMonth.Text) > 0 And txtProductionMonth.Enabled = False Then
            txtProductionMonth.Text = Format(Val(txtProductionMonth.Text), "0.000")
        End If
    End Sub

    Private Sub txtProductionYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionYear.TextChanged
        If Val(txtProductionYear.Text) > 0 And txtProductionYear.Enabled = False Then
            txtProductionYear.Text = Format(Val(txtProductionYear.Text), "0.000")
        End If
    End Sub

    Private Sub grpStockPKORecords_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpStockPKORecords.Enter

    End Sub

    Private Sub txtTemparature_Leave(sender As System.Object, e As System.EventArgs) Handles txtTemparature.Leave
        If (txtMeasurement.Text.Trim <> "" And txtTemparature.Text.Trim <> "" And cmbStockTank.SelectedValue.ToString.Trim.ToLower <> "--select--") Then
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            objCPOPPT.Measurement = txtMeasurement.Text
            objCPOPPT.Temparature = txtTemparature.Text
            objCPOPPT.TankID = cmbStockTank.SelectedValue
            txtCurrentReading.Text = objCPOBOL.CalculateCurrentReading(objCPOPPT).ToString
        Else
            If cmbStockTank.SelectedValue.ToString.ToLower.Trim = "--select--" Then
                MessageBox.Show("Please select the tank", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTemparature.Text = ""
            End If
        End If
    End Sub
End Class