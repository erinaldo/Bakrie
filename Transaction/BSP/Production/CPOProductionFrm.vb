Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class CPOProductionFrm
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
    Public lPrevdayPontoonQty As Decimal = 0.0

    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")

    ''Stock CPO'''
    Public btnAddFlag As Boolean = True
    Dim columnCPOAdd As DataColumn
    Dim rowCPOAdd As DataRow
    Dim dtCPOAdd As New DataTable("todgvCPOAdd")
    Public dtAddFlag As Boolean = False
    Public AddFlag As Boolean = True
    Private LoadMonthCount As Integer
    Private TransMonthCount As Integer

    ''Load CPO'''
    Public btnAddLoadFlag As Boolean = True
    Dim columnLoadCPOAdd As DataColumn
    Dim rowLoadCPOAdd As DataRow
    Dim dtLoadCPOAdd As New DataTable("todgvLoadCPOAdd")
    Public dtLoadAddFlag As Boolean = False
    'Public AddFlag As Boolean = True

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
    Public lPrevDayQtyLoad As Double = 0.0

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
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))
    Dim LbtnCPOKLoadadd As Boolean = True
    Dim lTotalTranshipQty As Decimal = 0
    Shadows mdiparent As New MDIParent


    Private Sub CPOProductionFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (dgvCPODetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M87"

            End If
        End If
    End Sub


    Private Sub CPOProductionFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CurrentReading()

    End Sub

    Private Sub CPOProductionFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        'Dim ToDate As Date = Date.Today
        'dtpCPODate.Value = ToDate
        'dtpCPOViewDate.Value = Date.Today
        'dtpCPODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        Dim objCPOPPT As New CPOProductionPPT

        Dim dsCrop As New DataSet
        dsCrop = CPOProductionBOL.ProductionCropYieldIDSelect(objCPOPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for CPO, Please insert the record in General Crop Yield")
        End If
        tcCPOProduction.SelectedTab = tpCPOView
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

            'tcCPOProduction.TabPages("tpCPOSave").Text = rm.GetString("ttcCPOProduction.TabPages(tpCPOSave).Text")
            'tcCPOProduction.TabPages("tpCPOView").Text = rm.GetString("ttcCPOProduction.TabPages(tpCPOView).Text")

            'chkCPODate.Text = rm.GetString("ProductionDate")
            'lblProductionDate.Text = rm.GetString("ProductionDate")
            'grpStockCPO.Text = rm.GetString("StockCPO")
            'grpStockCPORecords.Text = rm.GetString("StockCPORecords")
            'gpLoadCPO.Text = rm.GetString("LoadCPO")
            'grpTransCPO.Text = rm.GetString("TransCPO")
            ''   grpLoadCPORecords.Text = rm.GetString("LoadCPORecords")
            'grpTransCPORecords.Text = rm.GetString("TransCPORecords")
            'grpProCPORecords.Text = rm.GetString("ProCPORecords")

            'PnlSearch.CaptionText = rm.GetString("SearchCPOProduction")

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


            btnAdd.Text = rm.GetString("Add")
            btnResetMain.Text = rm.GetString("Reset")

            'dgvCPODetails.Columns("dgclStorage").HeaderText = rm.GetString("Storage")
            'dgvCPODetails.Columns("dgclBalance").HeaderText = rm.GetString("Balance B/F(MT)")
            'dgvCPODetails.Columns("dgclCapacity").HeaderText = rm.GetString("Capacity (Mt)")
            'dgvCPODetails.Columns("dgclCurrentReading").HeaderText = rm.GetString("Current Reading (Mt)")
            'dgvCPODetails.Columns("dgclMeasurement").HeaderText = rm.GetString("Measurement (Cm)")
            'dgvCPODetails.Columns("dgclTemperature").HeaderText = rm.GetString("Temperature")
            'dgvCPODetails.Columns("dgclFFA").HeaderText = rm.GetString("FFA")
            'dgvCPODetails.Columns("dgclMoisture").HeaderText = rm.GetString("Moisture")


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


            '  dgvLoadCPODetails.Columns("dgclLoadStorageNo").HeaderText = rm.GetString("Storage")
            ' dgvLoadCPODetails.Columns("dgclToLoading").HeaderText = rm.GetString("To Loading")
            'dgvLoadCPODetails.Columns("dgclLoadQuantity").HeaderText = rm.GetString("Quantity")
            'dgvLoadCPODetails.Columns("dgclLoadMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvLoadCPODetails.Columns("dgclLoadRemarks").HeaderText = rm.GetString("Remarks")

            'dgvTransCPODetails.Columns("dgclTransStorageNo").HeaderText = rm.GetString("Storage")
            'dgvTransCPODetails.Columns("dgclTranshipLoad").HeaderText = rm.GetString("Transshipment")
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
            btnAddLoad.Text = rm.GetString("Add")
            btnAddTrans.Text = rm.GetString("Add")

            ' dgvCPOView.Columns("gvCPODate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")
            btnView.Text = rm.GetString("ViewReports")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    'Private Sub CPOGetMonthYearQty()
    '    Try
    '        Dim objCPOPPT As New CPOProductionPPT
    '        Dim dsProdStock As DataSet
    '        Dim dsProdLoad As DataSet
    '        Dim dsProdtrans As DataSet
    '        Dim lCurrentReading As Double
    '        Dim lBalance As Double
    '        Dim lTransQty As Double
    '        Dim lLoadQty As Double
    '        objCPOPPT.CPODate = dtpCPODate.Value
    '        objCPOPPT.CropYieldID = lCropYieldID

    '        dsProdStock = CPOProductionBOL.CPOGetStockMonthYearQty(objCPOPPT)
    '        dsProdLoad = CPOProductionBOL.CPOGetLoadMonthYearQty(objCPOPPT)
    '        dsProdtrans = CPOProductionBOL.CPOGetTransMonthYearQty(objCPOPPT)

    '        If dsProdStock.Tables.Count <> 0 Then  '''''''For Table Check 

    '            If dsProdStock.Tables(0).Rows.Count <> 0 Then

    '                If Not dsProdStock.Tables(0).Rows(0).Item("CurrentReading") Is DBNull.Value Then
    '                    lCurrentReading = dsProdStock.Tables(0).Rows(0).Item("CurrentReading")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lCurrentReading = Val(txtCurrentReading.Text)
    '                End If

    '                If Not dsProdStock.Tables(0).Rows(0).Item("Balance") Is DBNull.Value Then
    '                    lBalance = dsProdStock.Tables(0).Rows(0).Item("Balance")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lBalance = Val(txtBalance.Text) ' Val(lblBalanceValue.Text)
    '                End If

    '            Else
    '                lCurrentReading = 0.0
    '                lBalance = 0.0
    '            End If

    '        End If  '''''''For Table Check 

    '        If dsProdtrans.Tables.Count <> 0 Then  '''''''For Table Check 
    '            If dsProdtrans.Tables(0).Rows.Count <> 0 Then
    '                If Not dsProdtrans.Tables(0).Rows(0).Item("TransQty") Is DBNull.Value Then
    '                    lTransQty = dsProdtrans.Tables(0).Rows(0).Item("TransQty")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lTransQty = Val(txtTransQty.Text)
    '                End If
    '            Else
    '                lTransQty = 0.0
    '            End If

    '        End If  '''''''For Table Check 

    '        If dsProdLoad.Tables.Count <> 0 Then  '''''''For Table Check 
    '            If dsProdLoad.Tables(0).Rows.Count <> 0 Then
    '                If Not dsProdLoad.Tables(0).Rows(0).Item("LoadQty") Is DBNull.Value Then
    '                    lLoadQty = dsProdLoad.Tables(0).Rows(0).Item("LoadQty")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lLoadQty = Val(txtLoadQty.Text)
    '                End If
    '            Else
    '                lLoadQty = 0.0
    '            End If
    '        End If '''''''For Table Check 

    '        Me.txtProductionMonth.Text = lCurrentReading + lTransQty + lLoadQty - lBalance

    '        ''''''For year'''''''''''
    '        If dsProdStock.Tables.Count <> 0 Then  '''''''For Table Check 
    '            If dsProdStock.Tables(1).Rows.Count <> 0 Then
    '                If Not dsProdStock.Tables(1).Rows(0).Item("CurrentReading") Is DBNull.Value Then
    '                    lCurrentReading = dsProdStock.Tables(1).Rows(0).Item("CurrentReading")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lCurrentReading = Val(txtCurrentReading.Text)
    '                End If

    '                If Not dsProdStock.Tables(1).Rows(0).Item("Balance") Is DBNull.Value Then
    '                    lBalance = dsProdStock.Tables(1).Rows(0).Item("Balance")
    '                    'lBalance = Val(lblBalanceValue.Text)
    '                Else
    '                    lBalance = 0.0
    '                End If
    '            Else
    '                lCurrentReading = 0.0
    '                lBalance = 0.0
    '            End If
    '        End If

    '        If dsProdtrans.Tables.Count <> 0 Then  '''''''For Table Check 
    '            If dsProdtrans.Tables(1).Rows.Count <> 0 Then
    '                If Not dsProdtrans.Tables(1).Rows(0).Item("TransQty") Is DBNull.Value Then
    '                    lTransQty = dsProdtrans.Tables(1).Rows(0).Item("TransQty")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lTransQty = Val(txtTransQty.Text)
    '                End If
    '            Else
    '                lTransQty = 0.0
    '            End If
    '        End If

    '        If dsProdLoad.Tables.Count <> 0 Then  '''''''For Table Check 
    '            If dsProdLoad.Tables(1).Rows.Count <> 0 Then
    '                If Not dsProdLoad.Tables(1).Rows(0).Item("LoadQty") Is DBNull.Value Then
    '                    lLoadQty = dsProdLoad.Tables(1).Rows(0).Item("LoadQty")
    '                    'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    lLoadQty = Val(txtLoadQty.Text)
    '                End If
    '            Else
    '                lLoadQty = 0.0
    '            End If
    '        End If
    '        Me.txtProductionYear.Text = lCurrentReading + lTransQty + lLoadQty - lBalance
    '    Catch ex As Exception
    '    End Try

    'End Sub
    Private Sub CPOGetTodayQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.CPODate = dtpCPODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            Dim dsCPOToday As DataSet
            dsCPOToday = CPOProductionBOL.CPOGetTodayQty(objCPOPPT)
            Dim lCurrentReading As Double
            'Dim lBalance As Double
            'Dim lTransQty As Double
            'Dim lLoadQty As Double

            If dsCPOToday.Tables.Count <> 0 Then  '''''''For Table Check 
                If dsCPOToday.Tables(0).Rows.Count <> 0 Then
                    If Not dsCPOToday.Tables(0).Rows(0).Item("QtyToday") Is DBNull.Value Then
                        lCurrentReading = dsCPOToday.Tables(0).Rows(0).Item("QtyToday")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lCurrentReading = Val(txtCurrentReading.Text)
                    End If

                    '        If Not dsCPOToday.Tables(0).Rows(0).Item("Balance") Is DBNull.Value Then
                    '            lBalance = dsCPOToday.Tables(0).Rows(0).Item("Balance")
                    '        End If

                    '        If dsCPOToday.Tables(1).Rows.Count <> 0 Then
                    '            If Not dsCPOToday.Tables(1).Rows(0).Item("TransQty") Is DBNull.Value Then
                    '                lTransQty = dsCPOToday.Tables(1).Rows(0).Item("TransQty")

                    '            Else
                    '                lTransQty = Val(txtTransQty.Text)
                    '            End If
                    '        End If

                    '        If dsCPOToday.Tables(2).Rows.Count <> 0 Then
                    '            If Not dsCPOToday.Tables(2).Rows(0).Item("LoadQty") Is DBNull.Value Then
                    '                lLoadQty = dsCPOToday.Tables(2).Rows(0).Item("LoadQty")
                    '                'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    '            Else
                    '                lLoadQty = Val(txtLoadQty.Text)
                    '            End If
                    '        End If
                    '    Else
                    '        lCurrentReading = 0.0
                    '        lLoadQty = 0.0
                    '        lTransQty = 0.0
                    '        lBalance = 0.0
                End If
            End If
            ' Me.txtProductionToday.Text = lCurrentReading
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CPOGetLoadTransMonthQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim dsTransLoad As DataSet
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpCPODate.Value
            dsTransLoad = CPOProductionBOL.CPOGetLoadTransMonthQty(objCPOPPT)
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

                    'Else
                    ' If lresetTrans = True Then
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
            
            cmbStockTank.DataSource = Nothing

            'Dim dsStockViewTankNo As DataSet

            dsStockTankNo = CPOProductionBOL.loadCmbStorage("CPO")
            dsLoadTankNo = CPOProductionBOL.loadCmbStorage("CPO")
            dsTransTankNo = CPOProductionBOL.loadCmbStorage("CPO")
            'dsStockViewTankNo = CPOProductionBOL.loadCmbStorage()

            'Stock CPO Combo
            cmbStockTank.DataSource = dsStockTankNo.Tables(0)
            cmbStockTank.DisplayMember = "TankNo"
            cmbStockTank.ValueMember = "TankID"

            If dsStockTankNo.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg2")
                ''MsgBox("No Records Available for Tank Master ,Please insert the Record in Production Tank Master")
            End If

            ''''For Stock Tank''''

            Dim dr As DataRow = dsStockTankNo.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            dsStockTankNo.Tables(0).Rows.InsertAt(dr, 0)
            'dsStockTankNo.AcceptChanges()


            ''''''For Load Tank'''

            Dim dr1 As DataRow = dsLoadTankNo.Tables(0).NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            dsLoadTankNo.Tables(0).Rows.InsertAt(dr1, 0)
            'dsStockTankNo.AcceptChanges()



            Dim dr2 As DataRow = dsTransTankNo.Tables(0).NewRow()
            dr2(0) = "--Select--"
            dr2(1) = "--Select--"
            dsTransTankNo.Tables(0).Rows.InsertAt(dr2, 0)
            'dsStockTankNo.AcceptChanges()


            'Load CPO
            cmbLoadTank.DataSource = dsLoadTankNo.Tables(0)
            cmbLoadTank.DisplayMember = "TankNo"
            cmbLoadTank.ValueMember = "TankID"

            lStockTankID = dsStockTankNo.Tables(0).Rows(0).Item("TankID")
        Catch ex As Exception
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("There is No Tank for This Estate") 'ex.Message)
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
            ''Transhipment CPO Combo
            'cmbLoadTrans.DataSource = Nothing
            'Dim dsLoadTrans As DataSet
            'dsLoadTrans = CPOProductionBOL.loadCmbLocation()
            ''Location CPO Combo
            'cmbLoadTrans.DataSource = dsLoadTrans.Tables(0)

            'cmbLoadTrans.DisplayMember = "LoadingLocationCode"
            'cmbLoadTrans.ValueMember = "LoadingLocationID"

            ''Trans CPO
            'cmbTransTank.DataSource = Nothing
            'Dim dsTransTank As DataSet
            'dsTransTank = CPOProductionBOL.loadCmbLocation()

            'cmbTransTank.DataSource = dsTransTank.Tables(0)
            'cmbTransTank.DisplayMember = "LoadingLocationCode"
            'cmbTransTank.ValueMember = "LoadingLocationID"

            Dim dr As DataRow = dsLoadLocation.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            dsLoadLocation.Tables(0).Rows.InsertAt(dr, 0)
            cbLoading.SelectedIndex = 0
            'dsStockTankNo.AcceptChanges()


            'Dim dr1 As DataRow = dsLoadTrans.Tables(0).NewRow()
            'dr1(0) = "--Select--"
            'dr1(1) = "--Select--"
            'dsLoadTrans.Tables(0).Rows.InsertAt(dr1, 0)

            'Dim dr2 As DataRow = dsTransTank.Tables(0).NewRow()
            'dr2(0) = "--Select--"
            'dr2(1) = "--Select--"
            'dsTransTank.Tables(0).Rows.InsertAt(dr2, 0)
            ''dsStockTankNo.AcceptChanges()



            'If dsLoadLocation.Tables(0).Rows.Count <> 0 Then
            '    lLoadingLocationID = dsLoadLocation.Tables(0).Rows(0).Item("LoadingLocationID")
            'Else
            '    lLoadingLocationID = Nothing
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub GetCropYieldID()
        Try
            Dim dsCrop As New DataSet
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.CropYieldCode = lCropYieldCode
            If objCPOPPT.CropYieldCode <> String.Empty Then
                dsCrop = CPOProductionBOL.GetCropYieldID(objCPOPPT)
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
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.TankID = lTankID
            If objCPOPPT.TankID <> String.Empty Then
                dsCropID = CPOProductionBOL.GetCropYield(objCPOPPT)
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
            'objCPOPPT.TankNo = cmbStockTank.SelectedValue
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
    Private Function IsCheckValidationGrid()
        If dgvCPODetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("Add The Values in StockCPO Records", "StockCPO Records", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStockTank.Focus()
            Return False
        End If
        If Val(txtProductionMonth.Text) < Val(txtProductionToday.Text) Then
            DisplayInfoMessage("Msg6")
            ''MessageBox.Show("Month To Date value cant be lesser than Today Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionMonth.Focus()
            Return False
        End If
        If Val(txtProductionYear.Text) < Val(txtProductionToday.Text) Then
            DisplayInfoMessage("Msg7")
            ''MessageBox.Show("Year To Date value cant be lesser than Today Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionYear.Focus()
            Return False
        End If
        If Val(txtProductionYear.Text) < Val(txtProductionMonth.Text) Then
            DisplayInfoMessage("Msg8")
            ''MessageBox.Show("Year To Date value cant be lesser than Month To Date ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionYear.Focus()
            Return False
        End If
        Return True
    End Function
    Private Function IsCheckValidation()

        If cmbStockTank.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg9")
            '' MessageBox.Show("This Field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStockTank.Focus()
            Return False
        End If


        'If Val(txtCurrentReading.Text) = 0 Then
        '    DisplayInfoMessage("Msg15")
        '    ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtCurrentReading.Focus()
        '    Return False
        'End If

        If txtCurrentReading.Text.Trim() = "" Then
            DisplayInfoMessage("Msg92")
            ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrentReading.Focus()
            Return False
        End If

        If Not IsNumeric(txtWriteoff.Text) Then
            MessageBox.Show("Write off value should be numeric", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWriteoff.Focus()
            Return False
        ElseIf CDbl(txtWriteoff.Text) > 0 And txtReason.Text.Length = 0 Then
            MessageBox.Show("Reason should be entered if you have entered the Write off value", "Information not completed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWriteoff.Focus()
            Return False
        End If

        If txtPrevDayReading.Text = "" Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrevDayReading.Focus()
            Return False
        End If


        If Val(lblCapacityValue.Text) < Val(txtPrevDayReading.Text) Then
            DisplayInfoMessage("Msg11")
            'MessageBox.Show("Balance B/F(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPrevDayReading.Focus()
            Return False
        End If

        If Val(lblCapacityValue.Text) < Val(txtCurrentReading.Text) Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show("Current Reading(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrentReading.Focus()
            Return False
        End If


        Return True
    End Function
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
        If txtLoadQty.Text = String.Empty Then
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadQty.Focus()
            Return False
        End If
        If txtLoadMonthToDate.Text = String.Empty Then
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
            ''MessageBox.Show("This Field is Required", "Transshipment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        If txtTransQty.Text = String.Empty Then
            DisplayInfoMessage("Msg15")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransQty.Focus()
            Return False
        End If
        If txtTransMonthToDate.Text = String.Empty Then
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
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

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
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Public Sub Reset()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpCPODate)
        'FormatDateTimePicker(dtpCPODate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpCPOViewDate)
        'FormatDateTimePicker(dtpCPOViewDate)
        dtpCPODate.Enabled = True
        'For Load CPO
        DtpProductionDate.Enabled = True
        'cmbLoadTank.Text = "Select All"
        cmbLoadLocation.Text = ""
        txtLoadQty.Text = ""
        txtLoadMonthToDate.Text = ""

        '''' For Trans CPO
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
        Dim ToDate As Date = Date.Today
        dtpCPOViewDate.Value = Date.Today
        DtpProductionDate.Value = ToDate
        dtpCPODate.Value = Date.Today
        

        dtpCPODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        DtpProductionDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        DtpProductionDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        
        dtpCPODate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)


        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True


        dtpCPOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        dtpCPOViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        txtProductionToday.Text = ""
        ClearGridView(dgvCPODetails)
        ClearGridView(dgvLoadCPODetails)
        ClearGridView(dgvTransCPODetails)

        DeleteMultientryStockCPO.Clear()
        DeleteMultientryLoadCPO.Clear()
        DeleteMultientryTransCPO.Clear()


        '''''''For Very First Time Entry for MonthTodate , YearTodate'''''''''

        If dgvCPOView.Rows.Count > 0 Then
            txtProductionMonth.Enabled = False
            txtProductionYear.Enabled = False
        Else
            txtProductionMonth.Enabled = True
            txtProductionYear.Enabled = True
        End If
        txtProductionMonth.Text = ""
        txtProductionYear.Text = ""
        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''
        MonthCount = False
        YearCount = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvCPOView.Rows.Count > 0 Then
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
        If dgvCPOView.Rows.Count > 0 Then
            ''''For Balance CPO'''''''
            txtPrevDayReading.Enabled = False
        Else
            ''''For Balance CPO'''''''
            txtPrevDayReading.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL


        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Private Sub CPOGridViewBind()

        Dim dt As New DataTable
        Dim objCPOPPT As New CPOProductionPPT
        With objCPOPPT
            If chkCPODate.Checked = True Then
                dtpCPOViewDate.Enabled = True
                .CPOProductionDate = dtpCPOViewDate.Value 'Format(Me.dtpCPOViewDate.Value, "MM/dd/yyyy")
            Else
                dtpCPOViewDate.Enabled = False
                .CPOProductionDate = Nothing
            End If

        End With
        objCPOPPT.CropYieldID = lCropYieldID
        dt = CPOProductionBOL.GetCPODetails(objCPOPPT)
        If dt.Rows.Count <> 0 Then
            Me.dgvCPOView.DataSource = dt
            dgvCPOView.AutoGenerateColumns = False
        Else
            ClearGridView(dgvCPOView) '''''clear the records from grid view
            Exit Sub
        End If
        ' End If

        
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
            DtpProductionDate.Enabled = False
            ProductionTodayCalculation()
        Else
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If






    End Sub
    Private Sub EditCPOView()


        ResetMain()
        Me.cmsCPO.Visible = False
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL
        Dim dt As New DataTable
        SaveFlag = False
        lProductionID = Me.dgvCPOView.SelectedRows(0).Cells("gvProductionID").Value
        lQtyPrev = Me.dgvCPOView.SelectedRows(0).Cells("QtyToday").Value
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSaveAll.Enabled = True
            End If
        End If
        lresetLoad = True
        lresetTrans = True

        objCPOPPT.CropYieldID = lCropYieldID
        objCPOPPT.ProductionID = lProductionID
        Dim str As String
        '  dtpCPODate.Value = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

        '   dtpCPODate.Value = objCPOPPT.CPODate

        str = Me.dgvCPOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
        objCPOPPT.CPOProductionDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

        DtpProductionDate.Value = objCPOPPT.CPOProductionDate

        str = Me.dgvCPOView.SelectedRows(0).Cells("gvCPODate").Value.ToString()
        objCPOPPT.CPODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

        'dtpCPODate.Value = Format(objCPOPPT.CPODate, "MM/dd/yyyy")
        dtpCPODate.Value = Format(objCPOPPT.CPODate, "yyyy-MM-dd")

        ''''For Stock CPO

        dtCPOAdd = CPOProductionBOL.GetCPOAddStockInfo(objCPOPPT)
        dgvCPODetails.AutoGenerateColumns = False
        dgvCPODetails.DataSource = dtCPOAdd
        '    dtpCPODate.Value = objCPOPPT.CPODate

        '''' For Load CPO'''
        dtLoadCPOAdd = CPOProductionBOL.GetCPOAddLoadInfo(objCPOPPT)
        dgvLoadCPODetails.AutoGenerateColumns = False
        dgvLoadCPODetails.DataSource = dtLoadCPOAdd

        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Update All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Update Semua"
        End If
        'Dim dt As New DataTable
        'Dim objCPOPPT As New CPOProductionPPT
        With objCPOPPT
            .CPOProductionDate = Nothing
        End With
        objCPOPPT.CropYieldID = lCropYieldID
        dt = CPOProductionBOL.GetCPODetails(objCPOPPT)

        If dgvCPOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString() <> dt.Rows(0).Item("productionDate") Then
            btnSaveAll.Enabled = False
            btnDeleteAll.Enabled = False
            ' DisplayInfoMessage("msg177")
            DisplayInfoMessage("msg176")
        End If

        ' CPOGridViewBind()
        SaveFlag = False
        Me.tcCPOProduction.SelectedTab = tpCPOSave


    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        UpdateCPOView()
    End Sub

    Public Sub GetTankID(ByVal lTankNo As String)
        Try
            Dim dsLoad As DataSet
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            objCPOPPT.TankNo = lTankNo
            dsLoad = CPOProductionBOL.GetTankID(objCPOPPT)
            If dsLoad.Tables.Count <> 0 Then
                If dsLoad.Tables(0).Rows.Count <> 0 Then
                    lTankID = dsLoad.Tables(0).Rows(0).Item("TankID")
                End If
            End If

        Catch ex As Exception
        End Try
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
    Public Sub GetLocationID(ByVal lLocation As String)
        Try
            Dim dsLocation As DataSet
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.Descp = lLocation
            dsLocation = CPOProductionBOL.GetLocationID(objCPOPPT)
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
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateCPOView()
            End If
        End If


    End Sub
    Private Sub DeleteCPOVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))
        If dgvCPOView.RowCount > 0 Then

            Dim dt As New DataTable
            Dim objCPOPPT As New CPOProductionPPT
            With objCPOPPT
                .CPOProductionDate = Nothing
            End With
            objCPOPPT.CropYieldID = lCropYieldID
            dt = CPOProductionBOL.GetCPODetails(objCPOPPT)

            If dgvCPOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString() = dt.Rows(0).Item("productionDate") Then

                Me.cmsCPO.Visible = False
                ' Dim objCPOPPT As New CPOProductionPPT
                Dim objCPOBOL As New CPOProductionBOL
                ' Dim dt As New DataTable
                If dgvCPOView.Rows.Count > 0 Then
                    If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                        ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                        Dim str As String = Me.dgvCPOView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
                        objCPOPPT.CPOProductionDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                        objCPOPPT.CropYieldID = lCropYieldID
                        objCPOBOL.Delete_CPODetail(objCPOPPT)
                        CPOGridViewBind()
                    End If
                End If
            Else
                DisplayInfoMessage("msg177")
            End If
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        DeleteCPOVIew()

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
                        'isDecimal = twoDecimalPlaces.IsMatch(text)
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
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        ResetMain()
        ResetLoadCPO()
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Reset()
        tcCPOProduction.SelectedTab = tpCPOSave
    End Sub
    Private Sub cmbStockTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStockTank.SelectedIndexChanged
       
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

    Private Sub cmbLoadTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTank.SelectedIndexChanged

        Dim objCPOBOL As New CPOProductionBOL

        If cmbLoadTank.SelectedIndex <> 0 Then
            Dim lrow As Integer
            lrow = cmbLoadTank.SelectedIndex
            lLoadCapacity = dsLoadTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString
        End If
        'lTankID = Nothing
        'GetTankID(cmbLoadTank.Text)
        Dim objCPOPPT As New CPOProductionPPT
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
            LoadTankMonthtoDate()
        End If




    End Sub

    Private Sub LoadTankMonthtoDate()
        If cmbLoadTank.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsLoadMonthTodate As New DataSet
            txtLoadMonthToDate.Text = ""
            txtLoadQty.Text = ""
            LoadMonthCount = 0

            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.TankID = cmbLoadTank.SelectedValue.ToString
            objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpCPODate.Value
            dsLoadMonthTodate = CPOProductionBOL.CPOGetLoadingCPOMonthtodate(objCPOPPT)

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
            objCPOPPT.CPODate = dtpCPODate.Value
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
            TransTankMonthtoDate()
        End If


    End Sub
    Private Sub cmbLoadLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadLocation.SelectedIndexChanged
        'Try
        'Dim objCPOBOL As New CPOProductionBOL
        'lLocationID = Nothing
        'GetLocationID(cmbLoadLocation.Text)
        'Dim objCPOPPT As New CPOProductionPPT
        'lLoadLocationID = lLocationID
        ''n.Text = lLocationDesc
        'objCPOPPT.CPODate = dtpCPODate.Value
        'objCPOPPT.ProductionID = lProdIdNew
        'objCPOPPT.TankID = cmbLoadLocation.SelectedValue.ToString
        'objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'objCPOPPT.CropYieldID = lCropYieldID

        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
        '        Dim objCheckDuplicateLoadLocation As Object = 0
        '        objCheckDuplicateLoadLocation = objCPOBOL.DuplicateLoadLocationFirstCheck(objCPOPPT)
        '        If objCheckDuplicateLoadLocation = 0 Then
        '            txtLoadMonthToDate.Enabled = False
        '        Else
        '            txtLoadMonthToDate.Enabled = True
        '        End If
        '    End If


        '    ''''Month Qty Value '''''''''''''''

        '    Dim dsCrop As New DataSet


        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
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

        If cmbLoadLocation.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            LoadTankMonthtoDate()
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
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        Try

            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg24")
                ''MsgBox("No Record in Crop yield for CPO, Please insert the record in General Crop Yield")
                Exit Sub
            End If

            If Val(txtProductionToday.Text) < 0 Then
                DisplayInfoMessage("Msg25")
                '' MsgBox("Balance B/F Qty cant be greater than sum of current reading ,Loading Qty and Transhipment Qty")
                Exit Sub
            End If
            If Not IsCheckValidationGrid() Then Exit Sub

            Dim strTranshipmentPendingRecds As String = TranshipmentPendingRecds()
            If strTranshipmentPendingRecds <> "" Then
                MsgBox(strTranshipmentPendingRecds & Chr(13) & Chr(10) & Chr(13) & Chr(10) & " - " & "Stock CPO (Pontoon), Current Reading value need to be updated", MsgBoxStyle.OkOnly, "Transhipment records available for : " & DtpProductionDate.Text)
                Exit Sub
            End If

            If dgvCPODetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If

                If SaveFlag = True Then

                    Dim objCPOPPT As New CPOProductionPPT
                    Dim objCPOBOL As New CPOProductionBOL
                    Dim dsID As DataSet

                    Dim objCheckDuplicateRecord As Object = 0
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value
                    objCPOPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    End If
                    ''''For Production CPO''''

                    ' Dim StrCPODate As String
                    Dim dsDetails As New DataSet
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
                    objCPOPPT.CPODate = dtpCPODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value

                    dsID = CPOProductionBOL.saveCPOProduction(objCPOPPT)

                    If dsID.Tables.Count <> 0 Then
                        If dsID.Tables(0).Rows.Count <> 0 Then
                            lProductionID = dsID.Tables(0).Rows(0).Item("ProductionID")
                        Else
                            lProductionID = Nothing
                        End If
                    End If

                    objCPOPPT.ProductionID = lProductionID

                    For Each DataGridViewRow In dgvCPODetails.Rows
                        ''''For Stock CPO''''''''''''
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

                        objCPOPPT.BeritaAcara = txtBeritaAcara.Text

                        'lCropYieldID = "M1"
                        objCPOPPT.CropYieldID = lCropYieldID

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


                    'For Each DataGridViewRowTrans In dgvTransCPODetails.Rows

                    '    ''''For Trans CPO''''''''

                    '    If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                    '        objCPOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                    '    Else
                    '        objCPOPPT.TransTankID = Nothing
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                    '        objCPOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                    '    Else
                    '        objCPOPPT.TransLocationID = Nothing
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                    '        objCPOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                    '    Else
                    '        objCPOPPT.TransQty = 0.0
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value Then
                    '        'Dim lTransMonthdate As String
                    '        'Dim lTransQty As String
                    '        objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                    '        'lTransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                    '        'objCPOPPT.TransMonthToDate = Val(lTransMonthdate) ''''+ Val(lTransQty)
                    '    Else
                    '        objCPOPPT.TransMonthToDate = 0.0
                    '        'objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTransQuantity").Value
                    '    End If
                    '    '''''''For Remarks'''''''''''''''''''''''''
                    '    objCPOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString()
                    '    ''''''''''''''''''''''''''''''''''''''''''''
                    '    objCPOPPT.CropYieldID = lCropYieldID
                    '    CPOProductionBOL.saveCPOTransProduction(objCPOPPT)
                    '    '   CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
                    'Next


                    CPOGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()
                    ResetMain()
                    ResetLoad()
                    ResetLoadCPO()
                    ' ResetLoad()
                    ' ResetTrans()

                    'SaveFlag = False
                Else

                    Dim objCPOPPT As New CPOProductionPPT
                    Dim objCPOBOL As New CPOProductionBOL
                    'Dim StrCPODate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvCPODetails.Rows

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
                    objCPOPPT.ProductionID = lProductionID

                    objCPOPPT.CPODate = dtpCPODate.Value 'Format(dtpCPODate.Value, "MM/dd/yyyy")
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value
                    If lProductionID = String.Empty Then
                        CPOProductionBOL.saveCPOProduction(objCPOPPT)
                    Else
                        CPOProductionBOL.UpdateCPOProduction(objCPOPPT)
                    End If


                    For Each DataGridViewRow In dgvCPODetails.Rows

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

                        If Not (DataGridViewRow.Cells("dgclProdStockID").Value Is Nothing Or DataGridViewRow.Cells("dgclProdStockID").Value Is DBNull.Value) Then
                            objCPOPPT.ProdStockID = DataGridViewRow.Cells("dgclProdStockID").Value.ToString()
                        Else
                            objCPOPPT.ProdStockID = String.Empty
                        End If

                        If DataGridViewRow.Cells("dgclProdStockID").Value Is Nothing Or DataGridViewRow.Cells("dgclProdStockID").Value Is DBNull.Value Or DataGridViewRow.Cells("dgclProdStockID").Value.ToString = String.Empty Then
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


                    'For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                    '    ''''''For Load CPO'''''''''''''
                    '    objCPOPPT.ProductionID = lProdIdNew
                    '    If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                    '        objCPOPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                    '    Else
                    '        objCPOPPT.LoadTankID = Nothing
                    '    End If

                    '    If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                    '        objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                    '    Else
                    '        objCPOPPT.LoadingLocationID = Nothing
                    '    End If

                    '    If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                    '        objCPOPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                    '    Else
                    '        objCPOPPT.LoadQty = 0.0
                    '    End If
                    '    If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then 'DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value And 
                    '        Dim lLoadMonthdate As String
                    '        Dim lLoadQty As String
                    '        lLoadMonthdate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                    '        lLoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value.ToString()
                    '        objCPOPPT.LoadMonthToDate = lLoadMonthdate 'Val(lLoadMonthdate) + Val(lLoadQty)

                    '        'objCPOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                    '    Else
                    '        objCPOPPT.LoadMonthToDate = 0.0
                    '    End If
                    '    '''''''''''''''''''''''''''''''''''''''
                    '    ''''For Remarks


                    '    objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                    '    objCPOPPT.CropYieldID = lCropYieldID

                    '    If Not (DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value) Then
                    '        objCPOPPT.ProdLoadingID = DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value
                    '    Else
                    '        objCPOPPT.ProdLoadingID = String.Empty
                    '    End If


                    '    If DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value.ToString = String.Empty Then
                    '        CPOProductionBOL.saveCPOLoadProduction(objCPOPPT)
                    '    Else
                    '        CPOProductionBOL.UpdateCPOLoadProduction(objCPOPPT)
                    '    End If

                    'Next

                    'For Each DataGridViewRowTrans In dgvTransCPODetails.Rows

                    '    ''''For Trans CPO''''''''
                    '    objCPOPPT.ProductionID = lProdIdNew
                    '    If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                    '        objCPOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                    '    Else
                    '        objCPOPPT.TransTankID = Nothing
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                    '        objCPOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                    '    Else
                    '        objCPOPPT.TransLocationID = Nothing
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                    '        objCPOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                    '    Else
                    '        objCPOPPT.TransQty = 0.0
                    '    End If
                    '    If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then 'DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value And 
                    '        Dim lLoadMonthdate As String
                    '        Dim lLoadQty As String
                    '        lLoadMonthdate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                    '        lLoadQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                    '        objCPOPPT.TransMonthToDate = Val(lLoadMonthdate) '+ Val(lLoadQty)

                    '        'objCPOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                    '    Else
                    '        objCPOPPT.TransMonthToDate = 0.0
                    '    End If

                    '    objCPOPPT.CropYieldID = lCropYieldID

                    '    '''''''''''''''''''''''''''''''''''''''
                    '    ''''For Remarks
                    '    objCPOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString


                    '    If Not (DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value) Then
                    '        objCPOPPT.ProdTranshipID = DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value
                    '    Else
                    '        objCPOPPT.ProdTranshipID = String.Empty
                    '    End If

                    '    If DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value.ToString = String.Empty Then
                    '        CPOProductionBOL.saveCPOTransProduction(objCPOPPT)
                    '    Else
                    '        CPOProductionBOL.UpdateCPOTransProduction(objCPOPPT)
                    '    End If

                    'Next

                    DeleteMultiEntryRecordsStockCPO()
                    DeleteMultiEntryRecordsLoadingCPO()
                    'DeleteMultiEntryRecordsTranshipCPO()

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
                    ResetMain()
                    ResetLoad()
                    ResetLoadCPO()
                    'ResetLoad()
                    'ResetTrans()
                    SaveFlag = True
                    txtProductionToday.Text = ""
                End If
                ClearGridView(dgvCPODetails)
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL

            objCPOPPT.CPODate = dtpCPODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOBOL.Delete_CPODetail(objCPOPPT)
            CPOGridViewBind()
        End Try
    End Sub


    Private Function TranshipmentPendingRecds() As String
        Dim strResult As String = ""

        Try
            Dim objCPOPPT As New TranshipmentCPOPPT
            Dim objCPOBOL As New TranshipmentCPOBOL

            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = DtpProductionDate.Value

            Dim dtTransCPOAdd As DataTable = TranshipmentCPOBOL.GetCPOAddTransInfo(objCPOPPT)
            Dim drTemp As DataRow

            Dim ZeroQtyAdded As Boolean


            If dtTransCPOAdd.Rows.Count > 0 Then
                For Each drTemp In dtTransCPOAdd.Rows
                    ZeroQtyAdded = False

                    For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows
                        If drTemp("TransTankNo") = DataGridViewRowLoad.Cells("dgclToLoading").Value.ToString() Then
                            ZeroQtyAdded = True
                        End If
                    Next

                    If (ZeroQtyAdded = False) Then
                        strResult += IIf(strResult = "", drTemp("TransTankNo"), Chr(13) & Chr(10) & drTemp("TransTankNo"))
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        TranshipmentPendingRecds = strResult
    End Function

    Sub UpdateTankMasterBFQty()
        'Try
        '    Dim objCPOPPT As New CPOProductionPPT
        '    Dim dsBFQty As New DataSet
        '    ' txtBalance.Text = "0"
        '    If txtBalance.Enabled = False Then
        '        '''''For Balance Processed '''''
        '        ''YDAY Date Calculation''

        '        'Dim prevDate As Date = DateAdd(DateInterval.Day, -1, dtpCPOLogDate.Value)
        '        'Dim prevDate As Date = DateAdd(DateInterval.Day, -1, dtpCPODate.Value)
        '        objCPOPPT.CPODate = dtpCPODate.Value
        '        objCPOPPT.CropYieldID = lCropYieldID
        '        objCPOPPT.TankID = lTankID
        '        If lTankID <> String.Empty Then
        '            dsBFQty = CPOProductionBOL.UpdateTankMasterBFQty(objCPOPPT)
        '        End If
        '        If dsBFQty.Tables(1).Rows.Count <> 0 Then
        '            If Not dsBFQty.Tables(1).Rows(0).Item("CurrentReading") Is DBNull.Value Then
        '                txtBalance.Text = dsBFQty.Tables(1).Rows(0).Item("CurrentReading")
        '            Else
        '                txtBalance.Text = String.Empty
        '            End If

        '            '                    txtTodayFFB.Enabled = False
        '            '                   txtNoOfLorry.Enabled = False
        '        End If


        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionFrm))

        If (dgvCPODetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg31"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateCPOView()
            End If
        End If


    End Sub
    Private Sub tcCPOProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCPOProduction.Click

        If (dgvCPODetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcCPOProduction.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ResetMain()
                Reset()
                ResetLoad()
                ResetTrans()
                CPOGridViewBind()


            End If
        Else
            ResetMain()
            Reset()
            ResetLoad()
            ResetTrans()
            CPOGridViewBind()


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
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'If txtCurrentReading.Text = Val(0) Then

        '    MessageBox.Show("Current Reading should not be Zero", "BSP")
        '    txtCurrentReading.Focus()
        '    Exit Sub
        'Else
        Add_Clicked()
        ProductionTodayCalculation()

        'End If
        ' CPOGetMonthYearQty() 'For MonthTodate , YearTodate Calculation




    End Sub
    'Private Function checkValues() As Boolean

    '    If (txtAdjQty.Text = "") Then
    '        If txtAdjValue.Text = "" Then
    '            MessageBox.Show("Adjustment Qty/Adjustment Value must be entered  ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtAdjQty.Focus()
    '            Return False
    '        End If
    '    End If

    '    If (txtStockCode.Text.Trim = "") Then
    '        MessageBox.Show("Stock Code not Selected", "Please select Stock Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtStockCode.Focus()
    '        Return False
    '    End If
    '    Return True

    'End Function

    Private Sub Add_Clicked()

        If btnAddFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (IsCheckValidation() = False) Then
                Exit Sub
            Else
                'Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))
                SaveCPODetail()
                'lblStatus.Text = "OPEN"
                'clear()

            End If
        ElseIf btnAddFlag = False Then
            If (IsCheckValidation() = False) Then
                Exit Sub
            Else
                UpdateCPODetails()
                'lblStatus.Text = "OPEN"
                'clear()

            End If
        End If
    End Sub
    Private Sub SaveCPODetail()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            Dim intRowcount As Integer = dtCPOAdd.Rows.Count
            If dtpCPODate.Enabled = True Then
                Dim objCheckDuplicateRecord As Object = 0
                objCPOPPT.CPOProductionDate = DtpProductionDate.Value
                objCPOPPT.CropYieldID = lCropYieldID
                objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

                If objCheckDuplicateRecord = 0 Then
                    DisplayInfoMessage("Msg35")
                    ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                    Exit Sub
                End If
            End If

            If Not TankNoExist(cmbStockTank.Text) Then

                '''' For check Duplicate Tank ''''
                objCPOPPT.CropYieldID = lCropYieldID
                objCPOPPT.CPODate = dtpCPODate.Value
                objCPOPPT.TankID = cmbStockTank.SelectedValue.ToString

                rowCPOAdd = dtCPOAdd.NewRow()
                If intRowcount = 0 And dtAddFlag = False Then

                    columnCPOAdd = New DataColumn("StockTankNo", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Capacity", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Balance", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("CurrentReading", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Writeoff", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Reason", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Measurement", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Temperature", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("FFA", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Moisture", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("StockTankID", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    columnCPOAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("TransTankNo", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)


                    columnCPOAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    columnCPOAdd = New DataColumn("LoadMonth", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("TranshipQty", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    columnCPOAdd = New DataColumn("TranshipMonth", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("prodTodayQty", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    columnCPOAdd = New DataColumn("ProdMonthQty", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("ProdYearQty", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    columnCPOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("TransLocationID", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    columnCPOAdd = New DataColumn("BeritaAcara", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                    rowCPOAdd("StockTankNo") = Me.cmbStockTank.Text
                    rowCPOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    rowCPOAdd("TransTankNo") = Me.cmbTransTank.Text

                    If Me.lblCapacityValue.Text <> String.Empty Then
                        rowCPOAdd("Capacity") = Me.lblCapacityValue.Text
                    End If

                    If Me.txtPrevDayReading.Text <> String.Empty Then
                        rowCPOAdd("Balance") = Me.txtPrevDayReading.Text
                    End If

                    If Me.txtCurrentReading.Text <> String.Empty Then
                        rowCPOAdd("CurrentReading") = Me.txtCurrentReading.Text.Trim
                    End If
                    If Me.txtWriteoff.Text <> String.Empty Then
                        rowCPOAdd("Writeoff") = Me.txtWriteoff.Text.Trim
                    End If

                    rowCPOAdd("BeritaAcara") = txtBeritaAcara.Text

                    If Me.txtReason.Text <> String.Empty Then
                        rowCPOAdd("Reason") = Me.txtReason.Text.Trim
                    End If
                    If Me.txtMeasurement.Text <> String.Empty Then
                        rowCPOAdd("Measurement") = Me.txtMeasurement.Text.Trim
                    End If
                    If Me.txtTemparature.Text <> String.Empty Then
                        rowCPOAdd("Temperature") = Me.txtTemparature.Text.Trim
                    End If
                    If Me.txtFFA.Text <> String.Empty Then
                        rowCPOAdd("FFA") = Me.txtFFA.Text.Trim
                    End If

                    If Me.txtMoisture.Text <> String.Empty Then
                        rowCPOAdd("Moisture") = Me.txtMoisture.Text.Trim
                    End If
                    If Me.txtDirt.Text <> String.Empty Then
                        rowCPOAdd("DirtP") = txtDirt.Text.Trim
                    End If

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowCPOAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowCPOAdd("LoadMonth") = Me.txtLoadMonthToDate.Text
                    End If
                    If Me.txtTransQty.Text <> String.Empty Then
                        rowCPOAdd("TranshipQty") = CDbl(Me.txtTransQty.Text)
                    End If
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowCPOAdd("TranshipMonth") = CDbl(Me.txtTransMonthToDate.Text)
                    End If
                    If Me.txtProductionToday.Text <> String.Empty Then
                        rowCPOAdd("prodTodayQty") = CDbl(Me.txtProductionToday.Text)
                    End If
                    If Me.txtProductionMonth.Text <> String.Empty Then
                        rowCPOAdd("ProdMonthQty") = CDbl(Me.txtProductionMonth.Text)
                    End If

                    If Me.txtProductionYear.Text <> String.Empty Then
                        rowCPOAdd("ProdYearQty") = CDbl(Me.txtProductionYear.Text)
                    End If

                    rowCPOAdd("StockTankID") = cmbStockTank.SelectedValue.ToString

                    dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                    dtAddFlag = True

                Else

                    rowCPOAdd("StockTankNo") = Me.cmbStockTank.Text

                    If Me.lblCapacityValue.Text <> String.Empty Then
                        rowCPOAdd("Capacity") = Me.lblCapacityValue.Text
                    End If

                    If Me.txtPrevDayReading.Text <> String.Empty Then
                        rowCPOAdd("Balance") = Me.txtPrevDayReading.Text
                    End If

                    If Me.txtCurrentReading.Text <> String.Empty Then
                        rowCPOAdd("CurrentReading") = CDbl(Me.txtCurrentReading.Text)
                    End If
                    If Me.txtWriteoff.Text <> String.Empty Then
                        rowCPOAdd("Writeoff") = CDbl(Me.txtWriteoff.Text)
                    End If
                    ' rowCPOAdd("BeritaAcara") = txtBeritaAcara.Text
                    If Me.txtReason.Text <> String.Empty Then
                        rowCPOAdd("Reason") = CDbl(Me.txtReason.Text)
                    End If
                    If Me.txtMeasurement.Text <> String.Empty Then
                        rowCPOAdd("Measurement") = CDbl(Me.txtMeasurement.Text)
                    End If
                    If Me.txtTemparature.Text <> String.Empty Then
                        rowCPOAdd("Temperature") = CDbl(Me.txtTemparature.Text)
                    End If
                    If Me.txtFFA.Text <> String.Empty Then
                        rowCPOAdd("FFA") = CDbl(Me.txtFFA.Text)
                    End If

                    If Me.txtMoisture.Text <> String.Empty Then
                        rowCPOAdd("Moisture") = CDbl(Me.txtMoisture.Text)
                    End If
                    If Me.txtDirt.Text <> String.Empty Then
                        rowCPOAdd("DirtP") = Me.txtDirt.Text
                    End If


                    rowCPOAdd("StockTankID") = cmbStockTank.SelectedValue.ToString
                    dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg36")
            End If
            ResetMain()
            With dgvCPODetails
                .DataSource = dtCPOAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SaveLoadCPODetail()
        Try
            Dim intRowcount As Integer = dtLoadCPOAdd.Rows.Count
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            If Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpCPODate.Value) Then 'Location, Tank Validation 
                ''Duplicate Date Check ''''
                objCPOPPT.CropYieldID = lCropYieldID
                rowLoadCPOAdd = dtLoadCPOAdd.NewRow()

                If intRowcount = 0 And dtLoadAddFlag = False Then
                    Try

                        columnLoadCPOAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                        columnLoadCPOAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                        dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
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
    Private Sub SaveTransCPODetail()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim objCPOBOL As New CPOProductionBOL

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
    Private Function TankNoExist(ByVal TankNo As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvCPODetails.Rows
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
    Private Function LocationExist(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean

        Dim objDataGridViewRow As New DataGridViewRow

        For Each objDataGridViewRow In dgvLoadCPODetails.Rows
            If (Location = objDataGridViewRow.Cells("dgclToLoading").Value) Then
                cmbLoadTank.Focus()
                Return True
            End If
        Next
        Return False

    End Function
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

    Private Sub UpdateCPODetails()
        Dim intCount As Integer = dgvCPODetails.CurrentRow.Index

        If lTempTankNo = cmbStockTank.Text Then


            dgvCPODetails.Rows(intCount).Cells("dgclStorage").Value = cmbStockTank.Text
            If Me.lblCapacityValue.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
            End If
            If Me.txtPrevDayReading.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclBalance").Value = txtPrevDayReading.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
            End If
            If Me.txtCurrentReading.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
            End If
            If Me.txtWriteoff.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclWriteoff").Value = Me.txtWriteoff.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclWriteoff").Value = DBNull.Value
            End If

            dgvCPODetails.Rows(intCount).Cells("dgcBeritaAcara").Value = txtBeritaAcara.Text

            If Me.txtReason.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclReason").Value = Me.txtReason.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclReason").Value = DBNull.Value
            End If
            If Me.txtTemparature.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
            End If
            If Me.txtMeasurement.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclMeasurement").Value = Me.txtMeasurement.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclMeasurement").Value = DBNull.Value
            End If
            If Me.txtFFA.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclFFA").Value = Me.txtFFA.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclFFA").Value = DBNull.Value
            End If
            If Me.txtDirt.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclDirt").Value = Me.txtDirt.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclDirt").Value = DBNull.Value
            End If
            If Me.txtMoisture.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
            End If

            dgvCPODetails.Rows(intCount).Cells("dgclStockTankID").Value = cmbStockTank.SelectedValue.ToString
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            btnAddFlag = True
            ResetMain()
        ElseIf Not TankNoExist(cmbStockTank.Text) Then

            dgvCPODetails.Rows(intCount).Cells("dgclStorage").Value = cmbStockTank.Text
            If Me.lblCapacityValue.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
            End If
            If Me.txtPrevDayReading.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclBalance").Value = txtPrevDayReading.Text 'Me.lblBalanceValue.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
            End If
            If Me.txtCurrentReading.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
            End If
            If Me.txtWriteoff.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclWriteoff").Value = Me.txtWriteoff.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclWriteoff").Value = DBNull.Value
            End If
            dgvCPODetails.Rows(intCount).Cells("dgcBeritaAcara").Value = txtBeritaAcara.Text
            If Me.txtReason.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclReason").Value = Me.txtReason.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclReason").Value = DBNull.Value
            End If

            If Me.txtTemparature.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
            End If

            If Me.txtMeasurement.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclMeasurement").Value = Me.txtMeasurement.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclMeasurement").Value = DBNull.Value
            End If

            If Me.txtFFA.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclFFA").Value = Me.txtFFA.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclFFA").Value = DBNull.Value
            End If

            If Me.txtDirt.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclDirt").Value = Me.txtDirt.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclDirt").Value = DBNull.Value
            End If
            If Me.txtMoisture.Text <> Nothing Then
                dgvCPODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
            Else
                dgvCPODetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
            End If

            dgvCPODetails.Rows(intCount).Cells("dgclStockTankID").Value = cmbStockTank.SelectedValue.ToString
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            btnAddFlag = True
            ResetMain()
        Else
            DisplayInfoMessage("Msg36")
        End If

    End Sub
    Private Sub UpdateLoadCPODetails()
        Try
            Dim intCount As Integer = dgvLoadCPODetails.CurrentRow.Index

            'If lTempTankNo = cmbStockTank.Text Then
            If lLoadTank = cmbLoadTank.Text And lLoadLocation = cmbLoadLocation.Text Then


                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If
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
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAddLoad.Text = "Add"
                btnAddLoadFlag = True
                'clear()

            ElseIf Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpCPODate.Value) Then
                dgvLoadCPODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadCPODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If
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
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub
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
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                '' MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgvCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPODetails.CellDoubleClick

        BindDgvCPODetails()

    End Sub
    Private Sub BindDgvCPODetails()
        Try
            If dgvCPODetails.Rows.Count > 0 Then
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Update"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Memperbarui"
                End If
                ''Me.btnAdd.Text = "Update"
                ' Me.btnSaveAll.Text = "Update All"

                cmbStockTank.Text = dgvCPODetails.SelectedRows(0).Cells("dgclStorage").Value.ToString()
                lTempTankNo = dgvCPODetails.SelectedRows(0).Cells("dgclStorage").Value.ToString()
                If Not dgvCPODetails.SelectedRows(0).Cells("dgclProdStockID").Value Is DBNull.Value Then
                    lProdStockID = dgvCPODetails.SelectedRows(0).Cells("dgclProdStockID").Value
                Else
                    lProdStockID = Nothing
                End If

                If Not dgvCPODetails.SelectedRows(0).Cells("dgclCapacity").Value.ToString() Is DBNull.Value Then
                    Me.lblCapacityValue.Text = dgvCPODetails.SelectedRows(0).Cells("dgclCapacity").Value.ToString()
                End If

                If Not dgvCPODetails.SelectedRows(0).Cells("dgclBalance").Value.ToString() Is DBNull.Value Then
                    Me.txtPrevDayReading.Text = dgvCPODetails.SelectedRows(0).Cells("dgclBalance").Value.ToString()
                    'Me.lblBalanceValue.Text = dgvCPODetails.SelectedRows(0).Cells("dgclBalance").Value.ToString()
                End If
                If Not dgvCPODetails.SelectedRows(0).Cells("dgclMeasurement").Value.ToString() Is DBNull.Value Then
                    Me.txtMeasurement.Text = dgvCPODetails.SelectedRows(0).Cells("dgclMeasurement").Value.ToString()
                End If
                If Not dgvCPODetails.SelectedRows(0).Cells("dgclCurrentReading").Value.ToString() Is DBNull.Value Then
                    Me.txtCurrentReading.Text = dgvCPODetails.SelectedRows(0).Cells("dgclCurrentReading").Value.ToString()
                End If
                If Not dgvCPODetails.SelectedRows(0).Cells("dgclWriteoff").Value.ToString() Is DBNull.Value Then
                    Me.txtWriteoff.Text = dgvCPODetails.SelectedRows(0).Cells("dgclWriteoff").Value.ToString()
                End If
                If Not dgvCPODetails.SelectedRows(0).Cells("dgclReason").Value.ToString() Is DBNull.Value Then
                    Me.txtReason.Text = dgvCPODetails.SelectedRows(0).Cells("dgclReason").Value.ToString()
                End If

                If Not dgvCPODetails.SelectedRows(0).Cells("dgclMoisture").Value.ToString() Is DBNull.Value Then
                    Me.txtMoisture.Text = dgvCPODetails.SelectedRows(0).Cells("dgclMoisture").Value.ToString()
                End If
                Dim tempstr As String = String.Empty
                If Not dgvCPODetails.SelectedRows(0).Cells("dgclTemperature").Value.ToString() Is DBNull.Value Then
                    txtTemparature.Text = dgvCPODetails.SelectedRows(0).Cells("dgclTemperature").Value.ToString()
                End If

                If Not dgvCPODetails.SelectedRows(0).Cells("dgclFFA").Value.ToString() Is DBNull.Value Then
                    Me.txtFFA.Text = dgvCPODetails.SelectedRows(0).Cells("dgclFFA").Value.ToString()
                End If

                If Not dgvCPODetails.SelectedRows(0).Cells("dgclDirt").Value.ToString() Is DBNull.Value Then
                    txtDirt.Text = dgvCPODetails.SelectedRows(0).Cells("dgclDirt").Value.ToString()
                End If

                If Not IsDBNull(dgvCPODetails.SelectedRows(0).Cells("dgcBeritaAcara").Value) Then
                    txtBeritaAcara.Text = dgvCPODetails.SelectedRows(0).Cells("dgcBeritaAcara").Value
                End If

                AddFlag = False
                btnAddFlag = False
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

        'Dim objCPOPPT As New CPOProductionPPT
        'Dim objCPOBOL As New CPOProductionBOL

        'Dim objCheckDuplicateRecord As Object = 0
        'objCPOPPT.CPODate = dtpCPODate.Value
        'objCPOPPT.CropYieldID = lCropYieldID
        'objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

        'If objCheckDuplicateRecord = 0 Then
        '    GetProductionID(dtpCPODate.Value)
        '    SaveFlag = False
        'Else
        '    SaveFlag = True
        '    'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
        '    'Exit Sub
        'End If
        '' CPOProductionMonthYearSelect()
    End Sub
    Private Sub btnResetMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMain.Click
        ResetMain()
    End Sub
    Private Sub dgvCPOView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCPOView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateCPOView()
            e.Handled = True
        End If
    End Sub
    Private Sub AddLoad_Clicked()

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
                ResetLoad()
            End If
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
                    '            lPrevDayQtyLoad = lPrevDayQtyLoad + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
                    '        End If
                    '    Next
                    'End If
                    'lTodayQty = lCurrentReadingToday + lLoadQtyToday + lPrevDayQtyLoad - lBalanceToday
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
                End If
            End If
        Catch ex As Exception
        End Try
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

    Private Sub dgvLoadCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadCPODetails.CellDoubleClick

        BindDgvLoadCPODetails()
    End Sub
    Private Sub dgvTransCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransCPODetails.CellDoubleClick

        BindDgvTransCPODetails()

    End Sub

    Private Sub btnResetLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetLoad.Click
        ResetLoad()
    End Sub

    Private Sub btnResetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetTrans.Click
        ResetTrans()
    End Sub

    Private Sub txtBalance_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrevDayReading.KeyDown
        Try
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
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrevDayReading.KeyPress
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
        If dgvCPODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvCPODetails.Rows
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

        'lProductionToday = (lCurrentReadingToday + lLoadQtyToday + lTotalTranshipQty) - (lBalanceToday + lPrevDayQtyLoad)
        lProductionToday = (lCurrentReadingToday + lLoadQtyToday) - (lBalanceToday)
        txtProductionToday.Text = Math.Round(lProductionToday, 3)
        'Production Month only Calculates when save
        If Me.txtProductionMonth.Text = "" Then
            Me.txtProductionMonth.Text = txtProductionToday.Text
            Me.txtProductionYear.Text = txtProductionToday.Text
        End If
        lPrevdayPontoonQty = 0

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

            'If SaveFlag = False And MonthCount <= 1 Then
            '    txtProductionMonth.Text = lProductionMonth
            'ElseIf lProductionMonth = 0 And MonthCount > 1 Then
            '    txtProductionMonth.Text = lProductionToday
            'ElseIf lProductionMonth > 0 And lProductionToday > 0 And btnAddLoadFlag = True Then
            '    txtProductionMonth.Text = lProductionMonth + lProductionToday
            'ElseIf lProductionMonth > 0 And lProductionToday > 0 And btnAddLoadFlag = False Then
            '    txtProductionMonth.Text = lProductionMonth + lProductionToday - lLoadQtyPrev
            'ElseIf txtProductionMonth.Enabled = False Then
            '    txtProductionMonth.Text = ""
            'End If
        End If
    End Sub


    Private Sub txtBalance_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrevDayReading.Leave
        If Val(lblCapacityValue.Text) < Val(txtPrevDayReading.Text) Then
            DisplayInfoMessage("Msg39")
            ''MessageBox.Show("Balance B/F(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtCurrentReading_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentReading.Leave
        'If Val(lblCapacityValue.Text) < Val(txtCurrentReading.Text) Then
        '    MessageBox.Show("Current Reading(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

   
    Private Sub tcCPOProduction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCPOProduction.SelectedIndexChanged
        'ResetMain()
        'Reset()
        'ResetLoad()
        'ResetTrans()
        ' CPOGridViewBind()
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

  
    Private Sub StockCPOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCPOEdit.Click
        BindDgvCPODetails()
    End Sub

    Private Sub StockCPODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCPODelete.Click
        If dgvCPODetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvCPODetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridStockCPO()
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
    Private Sub DeleteMultientrydatagridStockCPO()

        If Not dgvCPODetails.SelectedRows(0).Cells("dgclProdStockID").Value Is Nothing Then
            lProdStockID = dgvCPODetails.SelectedRows(0).Cells("dgclProdStockID").Value.ToString
        Else
            lProdStockID = String.Empty
        End If

        lDelete = 0
        If lProdStockID <> "" Then
            lDelete = DeleteMultientryStockCPO.Count

            DeleteMultientryStockCPO.Insert(lDelete, lProdStockID)

            ' lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtCPOAdd.Rows.Item(dgvCPODetails.CurrentRow.Index)
        Dr.Delete()
        dtCPOAdd.AcceptChanges()
        lProdStockID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultientrydatagridLoadCPO()

        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value Is Nothing Then
            lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value.ToString
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
        ProductionTodayCalculation()

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
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultiEntryRecordsStockCPO()
        Dim objCPOProductionPPT As New CPOProductionPPT

        lDelete = DeleteMultientryStockCPO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdStockID = DeleteMultientryStockCPO(lDelete - 1)

            Dim IntProdStockDelete As New Integer
            IntProdStockDelete = CPOProductionBOL.DeleteMultiEntryProdStock(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteMultiEntryRecordsLoadingCPO()
        Dim objCPOProductionPPT As New CPOProductionPPT

        lDelete = DeleteMultientryLoadCPO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdLoadingID = DeleteMultientryLoadCPO(lDelete - 1)

            Dim IntProdLoadingDelete As New Integer
            IntProdLoadingDelete = CPOProductionBOL.DeleteMultiEntryProdLoading(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteMultiEntryRecordsTranshipCPO()
        Dim objCPOProductionPPT As New CPOProductionPPT
        lDelete = DeleteMultientryTransCPO.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdTranshipID = DeleteMultientryTransCPO(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = CPOProductionBOL.DeleteMultiEntryProdTranship(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL

        If lProductionID <> String.Empty Then
            objCPOPPT.CPODate = dtpCPODate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOBOL.Delete_CPODetail(objCPOPPT)
            CPOGridViewBind()
        End If
       
       
        Reset()
        ResetMain()
        ResetLoadCPO()
        'ResetLoad()
        'ResetTrans()
    End Sub


    '' Modified by kumar to add Load Groupbox





    Private Sub btnLoadAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAdd.Click

        'If txtLoadCtReading.Text = Val(0) Then

        '    MessageBox.Show("Current Reading should not be Zero", "BSP")
        '    txtLoadCtReading.Focus()
        '    Exit Sub
        'ElseIf txtLoadPrevDayReading.Text = Val(0) Then
        '    MessageBox.Show("Previous Day Reading should not be Zero", "BSP")
        '    txtLoadCtReading.Focus()
        '    Exit Sub
        'Else
        AddLoadCPO_Clicked()
        ProductionTodayCalculation()

        'End If

        Dim dateMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 24

        Dim dateCalculate = 0
        For i As Integer = 1 To 12
            Dim month = i
            Dim daysinMonth = DateTime.DaysInMonth(DateTime.Now.Year, month)
            dateCalculate = dateCalculate + daysinMonth
            Debug.Print("=> " & daysinMonth)
        Next

        Debug.Print(dateMonth.ToString())
        Debug.Print((dateCalculate * 24).ToString())

        Dim monthToMt = dateMonth * 60
        Dim yearToMt = (dateCalculate * 24) * 60

        txtProductionMonth.Text = monthToMt & ":00"
        txtProductionYear.Text = yearToMt & ":00"


 
    End Sub

    Private Sub btnLoadReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadReset.Click
        ResetLoadCPO()
    End Sub

    Private Sub AddLoadCPO_Clicked()
        If LbtnCPOKLoadadd = True Then
            If (IsCheckValidationLoad_CPO() = True) Then
                AddLoadCPODetail()
                ResetLoadCPO()
            End If
        Else
            If (IsCheckValidationLoad_CPO() = True) Then
                UpdateCPOLoadDetails()
                ResetLoadCPO()
            End If

        End If


    End Sub
    Public Sub ResetLoadCPO()

        If cbLoading.Items.Count > 0 Then
            cbLoading.SelectedIndex = 0
        End If
        txtLoadPrevDayReading.Text = ""
        txtLoadCPORemarks.Text = ""
        txtLoadCtReading.Text = ""
        LbtnCPOKLoadadd = True
        If GlobalPPT.strLang = "en" Then
            btnLoadAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnLoadAdd.Text = "Menambahkan"
        End If

    End Sub
    Private Function IsCheckValidationLoad_CPO()

        If cbLoading.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg14")
            cbLoading.Focus()
            Return False
        End If
        If txtLoadCtReading.Text.Trim = "" Then
            DisplayInfoMessage("Msg15")
            txtLoadCtReading.Focus()
            Return False
        End If
        If txtLoadPrevDayReading.Text.Trim = "" Then
            DisplayInfoMessage("Msg16")
            txtLoadPrevDayReading.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub AddLoadCPODetail()

        Dim intRowcount As Integer = dtLoadCPOAdd.Rows.Count
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL
        If Not LocationExist(cbLoading.Text, cmbLoadTank.Text, dtpCPODate.Value) Then 'Location, Tank Validation 


            rowLoadCPOAdd = dtLoadCPOAdd.NewRow()
            If intRowcount = 0 Then
                Try

                    columnLoadCPOAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                    dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                    columnLoadCPOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                    columnLoadCPOAdd = New DataColumn("LoadCtReading", System.Type.[GetType]("System.String"))
                    dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                    columnLoadCPOAdd = New DataColumn("LoadPrevDayReading", System.Type.[GetType]("System.String"))
                    dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                    columnLoadCPOAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                    dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)
                    columnLoadCPOAdd = New DataColumn("ProdLoadID", System.Type.[GetType]("System.String"))
                    dtLoadCPOAdd.Columns.Add(columnLoadCPOAdd)

                Catch ex As Exception
                End Try

                rowLoadCPOAdd("LoadLocation") = Me.cbLoading.Text
                rowLoadCPOAdd("LoadCtReading") = Me.txtLoadCtReading.Text
                rowLoadCPOAdd("LoadPrevDayReading") = txtLoadPrevDayReading.Text
                rowLoadCPOAdd("LoadLocationID") = cbLoading.SelectedValue.ToString
                rowLoadCPOAdd("LoadRemarks") = txtLoadCPORemarks.Text.Trim
                rowLoadCPOAdd("ProdLoadID") = ""

                dtLoadCPOAdd.Rows.InsertAt(rowLoadCPOAdd, intRowcount)
                dtLoadAddFlag = True


            Else

                rowLoadCPOAdd("LoadLocation") = Me.cbLoading.Text
                rowLoadCPOAdd("LoadCtReading") = Me.txtLoadCtReading.Text
                rowLoadCPOAdd("LoadPrevDayReading") = txtLoadPrevDayReading.Text
                rowLoadCPOAdd("LoadLocationID") = cbLoading.SelectedValue.ToString
                rowLoadCPOAdd("LoadRemarks") = txtLoadCPORemarks.Text.Trim
                rowLoadCPOAdd("ProdLoadID") = ""
                dtLoadCPOAdd.Rows.InsertAt(rowLoadCPOAdd, intRowcount)

            End If
        Else
            DisplayInfoMessage("Msg37")
        End If

        With dgvLoadCPODetails
            .DataSource = dtLoadCPOAdd
            .AutoGenerateColumns = False
        End With
       
    End Sub

    Private Sub UpdateCPOLoadDetails()

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

        ElseIf Not LocationExist(cbLoading.Text, cmbLoadTank.Text, dtpCPODate.Value) Then
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
        LbtnCPOKLoadadd = True
    End Sub

    Private Sub BindDgvLoadCPODetails()

        If dgvLoadCPODetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnLoadAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnLoadAdd.Text = "Memperbarui"
            End If
            LbtnCPOKLoadadd = False

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

    Private Sub DtpProductionDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpProductionDate.ValueChanged
        ProductionTodayCalculation()
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


    Private Sub LoadCPOPrevDayQty()

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
        LoadCPOPrevDayQty()
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

    Private Sub txtTemparature_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemparature.Leave
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