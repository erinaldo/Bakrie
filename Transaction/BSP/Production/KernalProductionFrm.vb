Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class KernalProductionFrm
    Public lTankID As String = String.Empty
    Public lKernalStorageID As String = String.Empty
    Public lCropYieldID As String = String.Empty
    Public lLoadingLocationID As String = String.Empty
    Public lStockTankID As String = String.Empty
    Public lLoadTankID As String = String.Empty
    Public lTransTankID As String = String.Empty
    '  Public lLocationID As String = String.Empty
    Public lTransLocationID As String = String.Empty
    Public lLoadLocationID As String = String.Empty
    Public SaveFlag As Boolean = True
    Public lProductionID As String = String.Empty
    Public isDecimal As Boolean
    Public lLoadMonthToDate As Double = 0.0
    Public lTransMonthToDate As Double = 0.0
    Public btnAddFlag As Boolean = True
    Dim columnKernalAdd As DataColumn
    Dim rowKernalAdd As DataRow
    Dim dtKernalAdd As New DataTable("todgvKernalAdd")
    Public dtAddFlag As Boolean = False
    Public AddFlag As Boolean = True
    Public lStockKernelID As String = String.Empty
    Public lProdStockID As String = String.Empty
    Public lProdTranshipID As String = String.Empty
    Public lProdLoadingID As String = String.Empty
    Public lProdCurrentReading As Double = 0.0
    Public isModifierKey As Boolean
    Public lLoadTank As String = String.Empty
    Public lLoadLocation As String = String.Empty
    ''Load CPO'''
    Public btnAddLoadFlag As Boolean = True
    Dim columnLoadKernelAdd As DataColumn
    Dim rowLoadKernelAdd As DataRow
    Dim dtLoadKernelAdd As New DataTable("todgvLoadCPOAdd")
    Public dtLoadAddFlag As Boolean = False
    Public CPODate As Date
    'Public AddFlag As Boolean = True

    '' Trans CPO'''
    Public btnTransAddFlag As Boolean = True
    Dim columnTransKernelAdd As DataColumn
    Dim rowTransKernelAdd As DataRow
    Dim dtTransKernelAdd As New DataTable("todgvTransCPOAdd")
    Public dtTransAddFlag As Boolean = False
    Public lTempKernel As String
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Public lProductionIDNew As String = String.Empty
    Public lTransferKernal As String = String.Empty
    Public lLoadTrans As String = String.Empty
    Public lTranshipKernal As String = String.Empty
    Public lCropYieldCode As String = String.Empty
    Public lresetLoad As Boolean = True
    Public lresetTrans As Boolean = True
    ''For Location Description 
    Public lLocationDesc As String = String.Empty
    Public lTranshipKernelId As String = String.Empty
   ' Public lTransferKernelId As String = String.Empty
    Public lLoadVsLoc As String = String.Empty
    Public lCurrentReadingToday As Double = 0.0
    Public lLoadQtyToday As Double = 0.0
    Public lTransQtyToday As Double = 0.0

    Public lBalanceToday As Double = 0.0
    Public lTodayQty As Double = 0.0
    Dim lProductionToday As Decimal = 0
    Dim dsKernelStockStorage As DataSet
    Dim dsKernelTransferStorage As DataSet
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
    Private lQtyPrev As Decimal = 0

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim DeleteMultientryStockKernel As New ArrayList
    Dim DeleteMultientryLoadKernel As New ArrayList
    Dim DeleteMultientryTransKernel As New ArrayList
    Dim lDelete As Integer
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernalProductionFrm))
    Dim lPrevDayQtyLoad As Decimal = 0.0
    Dim lTotalTranshipQty As Decimal = 0
    Dim LbtnCPOKLoadadd As Boolean = True
    Shadows mdiparent As New MDIParent
    Private lPrevdayPontoonQty As Decimal = 0


    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub
    Private Sub loadCmbStorage()
        Try
            ''''''For Loading Kernel Storage in Stock''''''''''''''
           

            dsKernelStockStorage = KernalProductionBOL.loadCmbKernalCodeDesc()
            dsKernelTransferStorage = KernalProductionBOL.loadCmbKernalCodeDesc()
            

            ''For View Tank'''''
            If dsKernelStockStorage.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg1")
                ''MsgBox("No Records Available for Kernel Storage ,Please insert the Record in Production Kernel Storage")
            End If

            Dim dr As DataRow = dsKernelStockStorage.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(3) = "--Select--"
            dsKernelStockStorage.Tables(0).Rows.InsertAt(dr, 0)
            'dsStockTankNo.AcceptChanges()


            ''''For Stock Tank''''

            Dim dr1 As DataRow = dsKernelTransferStorage.Tables(0).NewRow()
            dr1(4) = "--Select--"
            'dr(1) = "--Select--"
            dsKernelTransferStorage.Tables(0).Rows.InsertAt(dr1, 0)

            'Stock CPO Combo
            cmbStockKernal.DataSource = dsKernelStockStorage.Tables(0)
            cmbStockKernal.DisplayMember = "Code"
            cmbStockKernal.ValueMember = "KernelStorageID"
            'Load CPO
            cmbTransferKernal.DataSource = dsKernelTransferStorage.Tables(0)
            cmbTransferKernal.DisplayMember = "Storage"
            cmbTransferKernal.ValueMember = "KernelStorageID"
           
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub loadCmbLocation()

        cmbLoadLocation.DataSource = Nothing
        Dim dsLoadLocation As DataSet
        dsLoadLocation = CPOProductionBOL.loadCmbLocation()
        'Location CPO Combo
        cmbLoadLocation.DataSource = dsLoadLocation.Tables(0)
        If dsLoadLocation.Tables(0).Rows.Count = 0 Then
            DisplayInfoMessage("Msg2")
            ''MsgBox("No Records Available for Loading Location ,Please insert the Record inProduction Loading Location")
        End If
        cmbLoadLocation.DisplayMember = "LoadingLocationCode"
        cmbLoadLocation.ValueMember = "LoadingLocationID"

        'Transhipment CPO Combo
        cmbLoadTrans.DataSource = Nothing

        Dim dsLoadTrans As DataSet
        dsLoadTrans = CPOProductionBOL.loadCmbLocation()

        cbLoading.DataSource = dsLoadTrans.Tables(0)
        cbLoading.DisplayMember = "LoadingLocationCode"
        cbLoading.ValueMember = "LoadingLocationID"

        Dim dr As DataRow = dsLoadLocation.Tables(0).NewRow()
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        dsLoadLocation.Tables(0).Rows.InsertAt(dr, 0)
        'dsStockTankNo.AcceptChanges()

        Dim dr1 As DataRow = dsLoadTrans.Tables(0).NewRow()
        dr1(0) = "--Select--"
        dr1(1) = "--Select--"
        dsLoadTrans.Tables(0).Rows.InsertAt(dr1, 0)



      
    End Sub
    Sub UpdateTankMasterBFQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim objKernelPPT As New KernalProductionPPT
            Dim dsBFQty As New DataSet
            txtBalance.Text = "0"
            If txtBalance.Enabled = False Then
                '''''For FFb Lorry Processed '''''
                ''YDAY Date Calculation''

                'Dim prevDate As Date = DateAdd(DateInterval.Day, -1, dtpCPOLogDate.Value)
                Dim prevDate As Date = DateAdd(DateInterval.Day, -1, dtpKernalDate.Value)
                objKernelPPT.KernalDate = prevDate
                objKernelPPT.CropYieldID = lCropYieldID

                objKernelPPT.KernalID = lKernalStorageID
                If lKernalStorageID <> String.Empty Then
                    dsBFQty = KernalProductionBOL.UpdateTankMasterBFQty(objKernelPPT)
                End If
                If dsBFQty.Tables(0).Rows.Count <> 0 Then
                    If Not dsBFQty.Tables(0).Rows(0).Item("CurrentReading") Is DBNull.Value Then
                        txtBalance.Text = dsBFQty.Tables(0).Rows(0).Item("CurrentReading")
                    Else
                        txtBalance.Text = String.Empty
                    End If
                Else
                    txtBalance.Enabled = True
                End If


            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function LocationExist(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvLoadKernalDetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclTransferStorage").Value.ToString And Location = objDataGridViewRow.Cells("dgclTransferLoc").Value) Then
                    ' txtStockCode.Text = ""
                    cmbTransferKernal.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try
    End Function
    Private Function LocationExistTrans(ByVal Location As String, ByVal TankNo As String, ByVal CPODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvTransKernalDetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclTransKernelStorage").Value And Location = objDataGridViewRow.Cells("dgclTransLoc").Value) Then
                    ' txtStockCode.Text = ""
                    cmbTranshipKernal.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try

    End Function
    Public Sub GetCropYield()
        Try
            Dim dsCrop As New DataSet
            Dim objKernalPPT As New KernalProductionPPT
            objKernalPPT.TankID = lTankID
            If objKernalPPT.TankID <> String.Empty Then
                dsCrop = KernalProductionBOL.GetCropYield(objKernalPPT)
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
            Dim objKernalPPT As New KernalProductionPPT
            'objKernalPPT.TankNo = cmbStockTank.SelectedValue
            objKernalPPT.TankID = lStockTankID
            If objKernalPPT.TankID <> String.Empty Then
                tankDetailSelect(objKernalPPT.TankID)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ComboKernalValueSelected()

        'Dim ds As New DataSet
        Dim objKernalPPT As New KernalProductionPPT
        'objKernalPPT.TankNo = cmbStockTank.SelectedValue
        objKernalPPT.KernalID = lKernalStorageID
        If objKernalPPT.KernalID <> String.Empty Then
            KernalDetailSelect(objKernalPPT.KernalID)
        End If
       
    End Sub
    Public Sub tankDetailSelect(ByVal lStockTankID As String)
        Try
            Dim ds As New DataSet
            Dim objKernalPPT As New KernalProductionPPT
            objKernalPPT.TankID = lStockTankID
            ds = KernalProductionBOL.tankDetailSelect(objKernalPPT)
            If ds.Tables.Count <> 0 Then
                If ds.Tables(0).Rows.Count <> 0 Then
                    lTankID = ds.Tables(0).Rows(0).Item("TankID")
                    'lblBalanceValue.Text = ds.Tables(0).Rows(0).Item("BFQty")
                    txtBalance.Text = ds.Tables(0).Rows(0).Item("BFQty")
                    lblCapacityValue.Text = ds.Tables(0).Rows(0).Item("Capacity")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub KernalDetailSelect(ByVal lKernalStorageID As String)
        Try
            Dim ds As New DataSet
            Dim objKernalPPT As New KernalProductionPPT
            Dim objCPOBOL As New CPOProductionBOL
            Dim objCPOPPT As New CPOProductionPPT
            objKernalPPT.KernalID = lKernalStorageID
            ds = KernalProductionBOL.KernalDetailSelect(objKernalPPT)

            If ds.Tables(0).Rows.Count <> 0 Then
                lKernalStorageID = ds.Tables(0).Rows(0).Item("KernelStorageID")
                'lblBalanceValue.Text = ds.Tables(0).Rows(0).Item("BFQty")
                'txtBalance.Text = ds.Tables(0).Rows(0).Item("BFQty")
                lblCapacityValue.Text = ds.Tables(0).Rows(0).Item("Capacity")
                If Not ds.Tables(0).Rows(0).Item("Descp") Is DBNull.Value Then
                    lblKernelDescp.Text = ds.Tables(0).Rows(0).Item("Descp")
                Else
                    lblKernelDescp.Text = ""
                End If
            End If

            objCPOPPT.KernalID = lKernalStorageID
            objCPOPPT.CropYieldID = lCropYieldID
            Dim objCheckDuplicateTank As Object = 0
            objCheckDuplicateTank = objCPOBOL.DuplicateKernalFirstCheck(objCPOPPT)
            If objCheckDuplicateTank = 0 Then
                txtBalance.Enabled = False
            Else
                txtBalance.Enabled = True
                txtBalance.Text = ""
                'MessageBox.Show("Cannot add a Same Kernal For the Date. Please try again.")
                'Exit Sub
            End If
            ' UpdateTankMasterBFQty()
        Catch ex As Exception
        End Try
    End Sub
    'Private Sub KernalGetMonthYearQty()
    '    Dim objCPOPPT As New CPOProductionPPT
    '    Dim dsProd As DataSet
    '    objCPOPPT.CropYieldID = lCropYieldID
    '    dsProd = CPOProductionBOL.CPOGetMonthYearQty(objCPOPPT)
    '    If Not dsProd.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '        Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
    '    Else
    '        Me.txtProductionMonth.Text = 0.0
    '    End If
    '    If Not dsProd.Tables(1).Rows(0).Item("YearTodate") Is DBNull.Value Then
    '        Me.txtProductionYear.Text = dsProd.Tables(1).Rows(0).Item("YearTodate")
    '    Else
    '        Me.txtProductionYear.Text = 0.0
    '    End If
    'End Sub
    Public Sub ResetMain()
        ''''For Stock CPO
        If cmbStockKernal.Items.Count > 0 Then
            cmbStockKernal.SelectedIndex = 0
        End If

        'lblCapacityValue.Text = "Capacity"
        'lblBalanceValue.Text = "Balance"
        txtCurrentReading.Text = ""
        txtWriteoff.Text = "0"
        txtReason.Text = ""
        'txtMeasurement.Text = ""
        txtTemparature.Text = ""
        ' txtFFA.Text = ""
        txtMoisture.Text = ""
        txtDirt.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        ''btnAdd.Text = "Add"
        btnAddFlag = True
        lblCapacityValue.Text = ""
        'lblBalanceValue.Text = ""
        txtBalance.Text = ""
        'CPOProductionMonthYearSelect()
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Sub DatePicker()
        ''''''''''''''''''''For Date Restriction ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        dtpKernalDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date

        If dgvKernalView.RowCount <> 0 Then
            Dim ProdDate As Date
            ProdDate = dgvKernalView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
            dtpKernalDate.MinDate = DateAdd(DateInterval.Day, 1, ProdDate)
        Else
            dtpKernalDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        End If

        dtpKernalViewDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        ' Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        dtpKernalViewDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
    Public Sub Reset()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernalDate)
        'FormatDateTimePicker(dtpKernalDate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernalViewDate)
        'FormatDateTimePicker(dtpKernalViewDate)
        dtpKernalDate.Enabled = True
        DtpProductionDate.Enabled = True
        'DatePicker()
        ' dtpKernalDate.Value = Date.Today

        'For Load CPO
        Dim ToDate As Date = Date.Today
        dtpKernalDate.Value = ToDate
        dtpKernalViewDate.Value = Date.Today
        DtpProductionDate.Value = Date.Today
        dtpKernalDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        dtpKernalDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        dtpKernalViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        dtpKernalViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        DtpProductionDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        DtpProductionDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        'cmbLoadTank.Text = "Select All"
        cmbLoadLocation.Text = ""
        txtLoadQty.Text = ""
        txtLoadMonthToDate.Text = ""

        '''' For Trans CPO
        If cmbTransferKernal.Items.Count > 0 Then
            cmbTransferKernal.SelectedIndex = 0
        End If
        If cmbTranshipKernal.Items.Count > 0 Then
            cmbTranshipKernal.SelectedIndex = 0
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

        ''btnSaveAll.Text = "Save All"
        SaveFlag = True
        dtpKernalViewDate.Enabled = False
        chkKernalDate.Checked = False
        lblKernelDescp.Text = ""
        '''''For Production CPO

        txtProductionToday.Text = ""
        txtProductionMonth.Text = ""
        txtProductionYear.Text = ""
        ClearGridView(dgvKernelDetails)
        ClearGridView(dgvLoadKernalDetails)
        ClearGridView(dgvTransKernalDetails)
        ClearGridView(dgvLoadCPODetails)
        DeleteMultientryStockKernel.Clear()
        DeleteMultientryLoadKernel.Clear()
        DeleteMultientryTransKernel.Clear()


        '''''''''For Very first monthtodate , yeartodate checking'''''

        If dgvKernalView.Rows.Count > 0 Then
            txtProductionMonth.Enabled = False
            txtProductionYear.Enabled = False
        Else
            txtProductionMonth.Enabled = True
            txtProductionYear.Enabled = True
        End If
        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvKernalView.Rows.Count > 0 Then
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
        If dgvKernalView.Rows.Count > 0 Then
            ''''For Balance CPO'''''''
            txtBalance.Enabled = False
        Else
            ''''For Balance CPO'''''''
            txtBalance.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Function IsCheckValidationSub()
        If cmbTransferKernal.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTransferKernal.Focus()
            Return False
        End If
        'If cmbTranshipKernal.SelectedIndex = 0 Then
        '    MessageBox.Show(" Storage Field Required For Trans ", " Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbTranshipKernal.Focus()
        '    Return False
        'End If
        If cmbLoadLocation.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg4")
            '' MessageBox.Show("This field is Required", "To Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadLocation.Focus()
            Return False
        End If
        'If cmbLoadTrans.SelectedIndex = 0 Then
        '    MessageBox.Show("Location Field Required  For Transhipment ", "Location", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    cmbLoadTrans.Focus()
        '    Return False
        'End If
        Return True
    End Function
    Private Function IsCheckValidation()
        If cmbStockKernal.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This Field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStockKernal.Focus()
            Return False
        End If
        'If Val(txtCurrentReading.Text) = 0 Then
        '    DisplayInfoMessage("Msg5")
        '    ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtCurrentReading.Focus()
        '    Return False
        'End If

        If txtCurrentReading.Text.Trim = "" Then
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

        If txtBalance.Text = "" Then
            DisplayInfoMessage("Msg161")
            ''MessageBox.Show("This Field is Required", "Current Reading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBalance.Focus()
            Return False
        End If

        If Val(lblCapacityValue.Text) < Val(txtBalance.Text) Then
            DisplayInfoMessage("Msg6")
            ''MessageBox.Show("Balance B/F(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBalance.Focus()
            Return False
        End If

        If Val(lblCapacityValue.Text) < Val(txtCurrentReading.Text) Then
            DisplayInfoMessage("Msg7")
            ''MessageBox.Show("Current Reading(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrentReading.Focus()
            Return False
        End If
        'If Val(txtCurrentReading.Text) < Val(txtBalance.Text) Then
        '    MessageBox.Show("Balance B/F(Mt) cant be greater than Current Reading ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtCurrentReading.Focus()
        '    Return False
        'End If

        Return True
    End Function
    'Public Function Reset()
    '    Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernalDate)
    '    FormatDateTimePicker(dtpKernalDate)
    '    Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpKernalViewDate)
    '    FormatDateTimePicker(dtpKernalViewDate)

    '    ''''For Stock CPO
    '    cmbStockKernal.SelectedIndex = 0
    '    lblCapacityValue.Text = "Capacity"
    '    lblBalanceValue.Text = "Balance"
    '    txtCurrentReading.Text = ""
    '    ' txtMeasurement.Text = ""
    '    txtTemparature.Text = ""
    '    ' txtFFA.Text = ""
    '    txtMoisture.Text = ""
    '    txtDirt.Text = ""

    '    'For Load CPO

    '    cmbTransferKernal.SelectedIndex = 0
    '    cmbLoadLocation.Text = ""
    '    txtLoadQty.Text = ""
    '    txtLoadMonthToDate.Text = ""

    '    '''' For Trans CPO

    '    cmbTranshipKernal.SelectedIndex = 0
    '    cmbLoadLocation.SelectedIndex = 0
    '    cmbLoadTrans.SelectedIndex = 0
    '    'cmbLoadTrans.Text = ""
    '    txtTransQty.Text = ""
    '    txtTransMonthToDate.Text = ""

    '    '''''For Production CPO

    '    txtProductionToday.Text = ""
    '    txtProductionMonth.Text = ""
    '    txtProductionYear.Text = ""
    '    btnSaveAll.Text = "Save"

    'End Function
    Private Sub KernalGridViewBind()

        Dim dt As New DataTable
        Dim objKernalPPT As New CPOProductionPPT
        'objKernalPPT.KernalDate = dtpKernalViewDate.Value
        With objKernalPPT
            If chkKernalDate.Checked = True Then
                dtpKernalViewDate.Enabled = True
                .CPOProductionDate = dtpKernalViewDate.Value 'Format(Me.dtpKernalViewDate.Value, "MM/dd/yyyy")
            Else
                dtpKernalViewDate.Enabled = False
                .CPOProductionDate = Nothing
            End If



        End With
        objKernalPPT.CropYieldID = lCropYieldID
        dt = CPOProductionBOL.GetCPODetails(objKernalPPT)
        If dt.Rows.Count <> 0 Then
            Me.dgvKernalView.DataSource = dt
            dgvKernalView.AutoGenerateColumns = False

        Else
            ClearGridView(dgvKernalView) '''''clear the records from grid view
            Exit Sub
        End If


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
    Private Sub UpdateKernalView()
        If dgvKernalView.Rows.Count > 0 Then
            EditKernalView()
            dtpKernalDate.Enabled = False
            ProductionTodayCalculation()
            'CPOProductionMonthYearSelect()
            'ProductionTodayCalculation()
        Else
            DisplayInfoMessage("Msg8")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub EditKernalView()
        Try
            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If

            Me.tcKernalProduction.SelectedTab = tpKernalSave
            Me.cmsKernal.Visible = False
            Dim objKernalPPT As New KernalProductionPPT
            Dim objKernalBOL As New KernalProductionBOL
            Dim dt As New DataTable
            SaveFlag = False
            'cmbLoadLocation.SelectedIndex = 0
            'cmbLoadTrans.SelectedIndex = 0

            lProductionID = Me.dgvKernalView.SelectedRows(0).Cells("gvProductionID").Value
            lQtyPrev = Me.dgvKernalView.SelectedRows(0).Cells("QtyToday").Value

            objKernalPPT.CropYieldID = lCropYieldID
            objKernalPPT.ProductionID = lProductionID

            'CPOGetLoadTransMonthQty()
            'KernelGetMonthYearQty()
            'KernelGetTodayQty()

            ' Palani
            'Dim str As String = Me.dgvKernalView.SelectedRows(0).Cells("gvCPODate").Value.ToString()
            Dim str As String = dgvKernalView.Rows(dgvKernalView.CurrentCell.RowIndex).Cells("gvCPODate").Value
            dtpKernalDate.Value = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            '  objKernalPPT.KernalDate = DtpProductionDate.Value

            str = Me.dgvKernalView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
            SaveFlag = False
            DtpProductionDate.Value = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            'objKernalPPT.KernelType = Me.dgvKernalView.SelectedRows(0).Cells("gvKernelType").Value.ToString()

            '''' For Stock Kernel'''
            objKernalPPT.KernalDate = DtpProductionDate.Value
            dgvKernelDetails.AutoGenerateColumns = False
            dtKernalAdd = KernalProductionBOL.GetKernalAddInfo(objKernalPPT)
            'If dtKernalAdd.Rows.Count <> 0 Then
            '    lProductionIDNew = dtKernalAdd.Rows(0).Item("ProductionID")
            'End If
            dgvKernelDetails.DataSource = dtKernalAdd
            '  dtpKernalDate.Value = objKernalPPT.KernalDate
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.ProductionID = lProductionID

            '''' For Load CPO'''
            dtLoadKernelAdd = CPOProductionBOL.GetCPOAddLoadInfo(objCPOPPT)
            dgvLoadCPODetails.AutoGenerateColumns = False
            dgvLoadCPODetails.DataSource = dtLoadKernelAdd
            DtpProductionDate.Enabled = False
            'Dim dt As New DataTable
            'Dim objCPOPPT As New CPOProductionPPT
            With objCPOPPT
                .CPOProductionDate = Nothing
            End With
            objCPOPPT.CropYieldID = lCropYieldID
            dt = CPOProductionBOL.GetCPODetails(objCPOPPT)

            If dgvKernalView.SelectedRows(0).Cells("gvProductionDate").Value.ToString() <> dt.Rows(0).Item("productionDate") Then
                btnSaveAll.Enabled = False
                btnDeleteAll.Enabled = False
                ' DisplayInfoMessage("msg177")
                DisplayInfoMessage("msg176")
            End If
            ''''' For load Kernel'''
            'dtLoadKernelAdd = KernalProductionBOL.GetKernelLoadAddInfo(objKernalPPT)
            'dgvLoadKernalDetails.AutoGenerateColumns = False
            'If dtLoadKernelAdd.Rows.Count <> 0 Then
            '    lProductionIDNew = dtLoadKernelAdd.Rows(0).Item("ProductionID")
            'End If
            'dgvLoadKernalDetails.DataSource = dtLoadKernelAdd
            ''        dtpCPODate.Value = objCPOPPT.CPODate

            ''''' For trans kernel'''
            'dtTransKernelAdd = KernalProductionBOL.GetKernelTransAddInfo(objKernalPPT)
            'dgvTransKernalDetails.AutoGenerateColumns = False
            'If dtTransKernelAdd.Rows.Count <> 0 Then
            '    lProductionIDNew = dtTransKernelAdd.Rows(0).Item("ProductionID")
            'End If

            'dgvTransKernalDetails.DataSource = dtTransKernelAdd
            ResetLoadCPO()


            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"



            'If dgvKernalView.SelectedRows.Item(0).Index = 0 Then
            '    btnSaveAll.Enabled = False
            '    btnDeleteAll.Enabled = False
            'End If

            'Else
            '    MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Catch ex As Exception
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Public Sub GetTankID(ByVal lTankNo As String)
        Try
            Dim dsLoad As DataSet
            Dim objKernalPPT As New KernalProductionPPT
            objKernalPPT.TankNo = lTankNo
            dsLoad = KernalProductionBOL.GetTankID(objKernalPPT)
            If dsLoad.Tables.Count <> 0 Then
                If dsLoad.Tables(0).Rows.Count <> 0 Then
                    lTankID = dsLoad.Tables(0).Rows(0).Item("TankID")
                Else
                    lTankID = Nothing
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetKernalID(ByVal lKernalType As String)
        Try
            Dim dsLoadKernal As DataSet
            Dim objKernalPPT As New KernalProductionPPT
            objKernalPPT.KernelType = lKernalType
            dsLoadKernal = KernalProductionBOL.GetKernalID(objKernalPPT)
            If dsLoadKernal.Tables.Count <> 0 Then
                If dsLoadKernal.Tables(0).Rows.Count <> 0 Then
                    lKernalStorageID = dsLoadKernal.Tables(0).Rows(0).Item("KernelStorageID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    'Public Sub GetLocationID(ByVal lLocation As String)
    '    Try
    '        Dim dsLocation As DataSet
    '        Dim objKernalPPT As New KernalProductionPPT
    '        objKernalPPT.Descp = lLocation
    '        dsLocation = KernalProductionBOL.GetLocationID(objKernalPPT)
    '        If dsLocation.Tables.Count <> 0 Then
    '            If dsLocation.Tables(0).Rows.Count <> 0 Then
    '                lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
    '                lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
    '            End If
    '        End If

    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub DeleteKernalVIew()
        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernalProductionFrm))
        Dim dt As New DataTable
        Dim objCPOPPT As New CPOProductionPPT
        With objCPOPPT
            .CPOProductionDate = Nothing
        End With
        objCPOPPT.CropYieldID = lCropYieldID
        dt = CPOProductionBOL.GetCPODetails(objCPOPPT)

        If dgvKernalView.SelectedRows(0).Cells("gvProductionDate").Value.ToString() = dt.Rows(0).Item("productionDate") Then
            Me.cmsKernal.Visible = False

            Dim objKernalPPT As New CPOProductionPPT
            Dim objKernalBOL As New CPOProductionBOL
            '    Dim dt As New DataTable
            If dgvKernalView.Rows.Count > 0 Then

                If MsgBox(rm.GetString("Msg41"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    'objKernalPPT.ProductionID = Me.dgvKernalView.SelectedRows(0).Cells("gvProductionID").Value.ToString()
                    'objKernalPPT.ProdStockID = Me.dgvKernalView.SelectedRows(0).Cells("gvProdStockID").Value.ToString()
                    'objKernalPPT.ProdLoadingID = Me.dgvKernalView.SelectedRows(0).Cells("gvProdLoadingID").Value.ToString()
                    'objKernalPPT.ProdTranshipID = Me.dgvKernalView.SelectedRows(0).Cells("gvProdTranshipID").Value.ToString()
                    'objKernalPPT.StockKernalID = Me.dgvKernalView.SelectedRows(0).Cells("gvStockKernelID").Value.ToString()

                    Dim str As String = Me.dgvKernalView.SelectedRows(0).Cells("gvProductionDate").Value.ToString()
                    ''Me.dgvCPOView.Text = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                    objKernalPPT.CPOProductionDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                    objKernalPPT.CropYieldID = lCropYieldID
                    objKernalBOL.Delete_CPODetail(objKernalPPT)
                    KernalGridViewBind()
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
        If dgvKernalView.RowCount > 0 Then
            DeleteKernalVIew()
        End If

       
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click

        Reset()
        tcKernalProduction.SelectedTab = tpKernalSave
       
    End Sub

    Private Sub tcCPOProduction_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Reset()
    End Sub

    
    Private Sub txtMeasurement_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txtFFA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
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

    Private Sub txtMeasurement_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
    Private Sub txtFFA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
    Private Function IsCheckValidationGrid()
        If dgvKernelDetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("Add The Values in StockKernel Records", "StockKernel Records", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbStockKernal.Focus()
            Return False
        End If
        If Val(txtProductionMonth.Text) < Val(txtProductionToday.Text) Then
            DisplayInfoMessage("Msg10")
            ''MessageBox.Show("Month To Date value cant be lesser than Today Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionMonth.Focus()
            Return False
        End If
        If Val(txtProductionYear.Text) < Val(txtProductionToday.Text) Then
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show("Year To Date value cant be lesser than Today Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionYear.Focus()
            Return False

        End If
        If Val(txtProductionYear.Text) < Val(txtProductionMonth.Text) Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show(" Year To Date value cant be lesser than Month To Date ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProductionYear.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        Try

            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg13")
                '' MsgBox("No Record in Crop yield for Kernel, Please insert the record in General Crop Yield")
                Exit Sub
            End If
            If Not IsCheckValidationGrid() Then Exit Sub

            If lProductionToday < 0 Then
                DisplayInfoMessage("Msg14")
                ''MsgBox("Balance B/F Qty cant be greater than sum of current reading ,Loading Qty and Transhipment Qty")
                Exit Sub
            End If

            If dgvKernelDetails.Rows.Count <> 0 Then
                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If

                If SaveFlag = True Then
                    Dim objKernalPPT As New KernalProductionPPT
                    Dim objCPOPPT As New CPOProductionPPT


                    Dim dsID As DataSet

                    Dim objkernalDAL As New KernalProductionBOL
                    Dim objCPODAL As New CPOProductionBOL

                    Dim objCheckDuplicateRecord As Object = 0
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value
                    objCPOPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objCPODAL.DuplicateDateCheck(objCPOPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg15")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    End If
                    ''''For Production CPO''''

                    ' Dim StrCPODate As String
                    Dim dsDetails As New DataSet

                    'For Each DataGridViewRow In dgvKernelDetails.Rows

                    'KernelGetTodayQty()
                    'KernelGetMonthYearQty()
                    'KernelGetTodayQty()
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


                    objCPOPPT.CPODate = dtpKernalDate.Value
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value

                    dsID = CPOProductionBOL.saveCPOProduction(objCPOPPT)


                    If dsID.Tables.Count <> 0 Then
                        lProductionID = dsID.Tables(0).Rows(0).Item("ProductionID")
                    Else
                        lProductionID = Nothing
                    End If

                    ' Next
                    objKernalPPT.ProductionID = lProductionID
                    For Each DataGridViewRowStock In dgvKernelDetails.Rows
                        ''''For Stock CPO''''''''''''

                        If Not DataGridViewRowStock.Cells("dgclKernelStorageID").Value Is DBNull.Value Then
                            objKernalPPT.StockKernalID = DataGridViewRowStock.Cells("dgclKernelStorageID").Value
                        Else
                            objKernalPPT.StockTankID = ""
                        End If
                        If Not DataGridViewRowStock.Cells("dgclCapacity").Value Is DBNull.Value Then
                            objKernalPPT.Capacity = DataGridViewRowStock.Cells("dgclCapacity").Value
                        Else
                            objKernalPPT.Capacity = 0.0
                        End If
                        If Not DataGridViewRowStock.Cells("dgclBalance").Value Is DBNull.Value Then
                            objKernalPPT.balance = Val(DataGridViewRowStock.Cells("dgclBalance").Value)
                        Else
                            objKernalPPT.balance = 0.0
                        End If
                        objKernalPPT.CurrentReading = DataGridViewRowStock.Cells("dgclCurrentReading").Value

                        If Not DataGridViewRowStock.Cells("dgclWriteoff").Value Is DBNull.Value Then
                            objKernalPPT.Writeoff = Val(DataGridViewRowStock.Cells("dgclWriteoff").Value)
                        Else
                            objKernalPPT.Writeoff = 0.0
                        End If

                        If Not DataGridViewRowStock.Cells("dgclReason").Value Is DBNull.Value Then
                            objKernalPPT.Reason = DataGridViewRowStock.Cells("dgclReason").Value
                        Else
                            objKernalPPT.Reason = String.Empty
                        End If

                        If Not DataGridViewRowStock.Cells("dgclTemperature").Value Is DBNull.Value Then
                            objKernalPPT.Temparature = Val(DataGridViewRowStock.Cells("dgclTemperature").Value)
                        Else
                            objKernalPPT.Temparature = 0.0
                        End If
                      
                        If Not DataGridViewRowStock.Cells("dgclMoisture").Value Is DBNull.Value Then
                            objKernalPPT.Moisture = Val(DataGridViewRowStock.Cells("dgclMoisture").Value)
                        Else
                            objKernalPPT.Moisture = 0.0
                        End If
                        If Not DataGridViewRowStock.Cells("dgclDirtP").Value Is DBNull.Value Then
                            objKernalPPT.Dirt = Val(DataGridViewRowStock.Cells("dgclDirtP").Value)
                        Else
                            objKernalPPT.Dirt = 0.0
                        End If
                        'lCropYieldID = "M1"
                        objKernalPPT.CropYieldID = lCropYieldID
                        KernalProductionBOL.saveKernalStockProduction(objKernalPPT)
                    Next

                    For Each DataGridViewRowLoad In dgvLoadCPODetails.Rows

                        ''''''For Load CPO'''''''''''''
                        objCPOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        objCPOPPT.LoadCurrentReading = DataGridViewRowLoad.Cells("dgclLoadCtReading").Value
                        objCPOPPT.LoadPrevDayReading = DataGridViewRowLoad.Cells("dgclPrevDayReadnig").Value.ToString()
                        objCPOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objCPOPPT.ProductionID = lProductionID
                        objCPOPPT.CropYieldID = lCropYieldID
                        objCPOPPT.ProdLoadingID = lProdLoadingID
                        CPOProductionBOL.CPOProdLoadInsert(objCPOPPT)
                    Next


                    KernalGridViewBind()
                    DisplayInfoMessage("Msg16")
                    ''MsgBox("Data Successfully Saved")
                    Reset()
                    ResetMain()
                    ResetLoadCPO()
                    ResetLoad()
                    ResetTrans()
                    ' SaveFlag = False
                Else
                    Dim objKernalPPT As New KernalProductionPPT
                    Dim objCPOPPT As New CPOProductionPPT

                    Dim objkernalDAL As New KernalProductionBOL
                    Dim objCPODAL As New CPOProductionBOL

                    'Dim objCheckDuplicateRecord As Object = 0
                    'objCPOPPT.CPOProductionDate = DtpProductionDate.Value
                    'objCPOPPT.CropYieldID = lCropYieldID
                    'objCheckDuplicateRecord = objCPODAL.DuplicateDateCheck(objCPOPPT)

                    'If objCheckDuplicateRecord = 0 Then
                    '    DisplayInfoMessage("Msg15")
                    '    ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                    '    Exit Sub
                    'End If
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


                    objCPOPPT.CPODate = dtpKernalDate.Value
                    objCPOPPT.CPOProductionDate = DtpProductionDate.Value
                    objCPOPPT.ProductionID = lProductionID

                    If lProductionID = String.Empty Then
                        CPOProductionBOL.saveCPOProduction(objCPOPPT)
                    Else
                        CPOProductionBOL.UpdateCPOProduction(objCPOPPT)
                    End If
                    ' Next

                    For Each DataGridViewRow In dgvKernelDetails.Rows
                        objKernalPPT.ProductionID = lProductionIDNew
                        If Not DataGridViewRow.Cells("dgclKernelStorageID").Value Is DBNull.Value Then
                            objKernalPPT.StockKernalID = DataGridViewRow.Cells("dgclKernelStorageID").Value
                        Else
                            objKernalPPT.StockKernalID = ""
                        End If

                        If Not DataGridViewRow.Cells("dgclCapacity").Value Is DBNull.Value Then
                            objKernalPPT.Capacity = DataGridViewRow.Cells("dgclCapacity").Value
                        Else
                            objKernalPPT.Capacity = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclBalance").Value Is DBNull.Value Then
                            objKernalPPT.balance = DataGridViewRow.Cells("dgclBalance").Value
                        Else
                            objKernalPPT.balance = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclCurrentReading").Value Is DBNull.Value Then
                            objKernalPPT.CurrentReading = DataGridViewRow.Cells("dgclCurrentReading").Value
                        Else
                            objKernalPPT.CurrentReading = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclWriteoff").Value Is DBNull.Value Then
                            objKernalPPT.Writeoff = Val(DataGridViewRow.Cells("dgclWriteoff").Value)
                        Else
                            objKernalPPT.Writeoff = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclReason").Value Is DBNull.Value Then
                            objKernalPPT.Reason = (DataGridViewRow.Cells("dgclReason").Value)
                        Else
                            objKernalPPT.Reason = String.Empty
                        End If

                        If Not DataGridViewRow.Cells("dgclTemperature").Value Is DBNull.Value Then
                            objKernalPPT.Temparature = DataGridViewRow.Cells("dgclTemperature").Value
                        Else
                            objKernalPPT.Temparature = 0.0
                        End If

                        If Not DataGridViewRow.Cells("dgclMoisture").Value Is DBNull.Value Then
                            objKernalPPT.Moisture = DataGridViewRow.Cells("dgclMoisture").Value
                        Else
                            objKernalPPT.Moisture = 0.0
                        End If
                        If Not DataGridViewRow.Cells("dgclDirtP").Value Is DBNull.Value Then
                            objKernalPPT.Dirt = DataGridViewRow.Cells("dgclDirtP").Value
                        Else
                            objKernalPPT.Dirt = 0.0
                        End If
                        objKernalPPT.CropYieldID = lCropYieldID

                        If Not (DataGridViewRow.Cells("dgclProdStockID").Value Is Nothing Or DataGridViewRow.Cells("dgclProdStockID").Value Is DBNull.Value) Then
                            objKernalPPT.ProdStockID = DataGridViewRow.Cells("dgclProdStockID").Value.ToString()
                        Else
                            objKernalPPT.ProdStockID = String.Empty
                        End If

                        objKernalPPT.ProductionID = lProductionID

                        If objKernalPPT.ProdStockID = String.Empty Then
                            KernalProductionBOL.saveKernalStockProduction(objKernalPPT)
                        Else
                            KernalProductionBOL.UpdateKernalStockProduction(objKernalPPT)
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

                        If lProdLoadingID <> "" Then
                            CPOProductionBOL.CPOProdLoadupdate(objCPOPPT)
                        Else
                            CPOProductionBOL.CPOProdLoadInsert(objCPOPPT)
                        End If

                    Next

                    DeleteMultiEntryRecordsStockKernel()
                    DeleteMultiEntryRecordsLoadingKernel()
                    DeleteMultiEntryRecordsTranshipKernel()


                    DisplayInfoMessage("Msg17")
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If

                    ''btnSaveAll.Text = "Save All"
                    KernalGridViewBind()
                    Reset()
                    ResetMain()
                    ResetLoadCPO()
                    ResetLoad()
                    ResetTrans()
                    SaveFlag = True
                End If
                ClearGridView(dgvLoadKernalDetails)
                GlobalPPT.IsRetainFocus = False
            Else
                DisplayInfoMessage("Msg18")
                ''MessageBox.Show(" No Record to Add", " ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            DisplayInfoMessage("Msg19")
            ''MsgBox("Save Process Failed")
            Exit Sub
        End Try
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        ResetMain()
        ResetLoadCPO()
        GlobalPPT.IsRetainFocus = False
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernalProductionFrm))
        If (dgvKernelDetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg40"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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
    Private Sub cmbStockKernal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStockKernal.SelectedIndexChanged
       
        Dim lrow As Integer
        lrow = cmbStockKernal.SelectedIndex
        lblCapacityValue.Text = dsKernelStockStorage.Tables(0).Rows(lrow).Item("Capacity").ToString
        lblKernelDescp.Text = dsKernelStockStorage.Tables(0).Rows(lrow).Item("Descp").ToString

        txtBalance.Text = ""


        If cmbStockKernal.SelectedIndex <> 0 Then
            Dim DsBalanceBf As New DataSet
            Dim objCPOPPT As New KernalProductionPPT
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.KernalID = cmbStockKernal.SelectedValue.ToString
            objCPOPPT.KernalDate = dtpKernalDate.Value
            DsBalanceBf = KernalProductionBOL.loadCmbStorageBalanceBF(objCPOPPT)

            If DsBalanceBf.Tables(0).Rows.Count <> 0 Then
                txtBalance.Text = DsBalanceBf.Tables(0).Rows(0).Item("BalanceBF").ToString
            End If
            If DsBalanceBf.Tables(1).Rows.Count <> 0 Then
                lPrevdayPontoonQty = DsBalanceBf.Tables(1).Rows(0).Item("PontoonPrevQty").ToString
            End If


            If txtBalance.Text = "" Then
                txtBalance.Enabled = True
            Else
                txtBalance.Enabled = False
            End If

        Else
            txtBalance.Text = ""
            txtBalance.Enabled = False
        End If
    End Sub
    Private Sub cmbTransferKernal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTransferKernal.SelectedIndexChanged
        Dim objCPOBOL As New KernalProductionBOL

        If cmbTransferKernal.SelectedIndex <> 0 Then
            Dim lrow As Integer
            lrow = cmbTransferKernal.SelectedIndex
            lLoadCapacity = dsKernelTransferStorage.Tables(0).Rows(lrow).Item("Capacity").ToString
        End If

        'Kumar Changed
        If cmbTransferKernal.SelectedIndex = 0 Then
            txtLoadMonthToDate.Text = ""
            txtLoadMonthToDate.Enabled = False
        Else
            LoadTankMonthtoDate()
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
    Private Sub cmbTranshipKernal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTranshipKernal.SelectedIndexChanged
        Try
            'txtTransQty.Text = ""
            ''lTankID = Nothing
            ''GetTankID(cmbTranshipKernal.Text)
            ''Dim objKernalPPT As New KernalProductionPPT
            ''lTransTankID = lTankID
            ''objKernalPPT.TransTankID = lTankID
            'lTranshipKernelId = cmbTranshipKernal.SelectedValue

            'Dim objCPOBOL As New CPOProductionBOL
            'Dim objCPOPPT As New CPOProductionPPT

            'Dim objKernelBOL As New KernalProductionBOL
            'Dim objKernelPPT As New KernalProductionPPT
            ''objCPOPPT.TankID = lTankID

            'If cmbTranshipKernal.SelectedIndex <> 0 Then
            '    objKernelPPT.KernalID = cmbTranshipKernal.SelectedValue.ToString
            '    Dim dskernel As New DataSet
            '    dskernel = KernalProductionBOL.KernalDetailSelect(objKernelPPT)
            '    lTransCapacity = dskernel.Tables(0).Rows(0).Item("Capacity")
            'End If

            'objCPOPPT.ProductionID = lProductionIDNew
            'objCPOPPT.KernalID = lTransferKernelId
            'objCPOPPT.CropYieldID = lCropYieldID
            'objCPOPPT.LoadingLocationID = lLocationID
            'objCPOPPT.CPODate = dtpKernalDate.Value

            'If (lLocationID <> String.Empty) And (lTransferKernelId <> String.Empty) Then
            '    Dim objCheckDuplicateLoadLocation As Object = 0
            '    objCheckDuplicateLoadLocation = objCPOBOL.DuplicateKernelTransLocationCheck(objCPOPPT)
            '    If objCheckDuplicateLoadLocation = 0 Then
            '        txtLoadMonthToDate.Enabled = False
            '    Else
            '        txtLoadMonthToDate.Enabled = True
            '    End If
            'End If


            '''''Month Qty Value '''''''''''''''

            'Dim dsCrop As New DataSet
            ''If (lLocationID <> String.Empty) And (lTransferKernelId <> String.Empty) And (lProductionIDNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
            'If (lLocationID <> String.Empty) And (lTransferKernelId <> String.Empty) And (lCropYieldID <> String.Empty) Then
            '    dsCrop = KernalProductionBOL.KernelGetTransVsLocMonthQty(objCPOPPT)
            '    If dsCrop.Tables.Count <> 0 Then
            '        If dsCrop.Tables(0).Rows.Count <> 0 Then
            '            lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
            '            txtTransMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
            '        Else
            '            txtTransMonthToDate.Text = "0"
            '        End If
            '    End If
            'Else
            '    txtTransMonthToDate.Text = "0"
            'End If


            If cmbTranshipKernal.SelectedIndex = 0 Then
                txtTransMonthToDate.Text = ""
                txtTransMonthToDate.Enabled = False
            Else
                TransTankMonthtoDate()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbLoadTrans_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTrans.SelectedIndexChanged
        'lLocationID = Nothing
        'GetLocationID(cmbLoadTrans.Text)
        'Dim objKernalPPT As New KernalProductionPPT
        'lTransLocationID = lLocationID
        ''  lblTranshipDescription.Text = lLocationDesc
        '' objKernalPPT.TransLocationID = lLocationID

        'Dim objCPOBOL As New CPOProductionBOL
        'Dim objCPOPPT As New CPOProductionPPT

        'Dim objKernelBOL As New KernalProductionBOL
        'Dim objKernelPPT As New KernalProductionPPT

        ''objCPOPPT.TankID = lTankID
        'objCPOPPT.ProductionID = lProductionIDNew
        'objCPOPPT.KernalID = lTransferKernelId
        'objCPOPPT.CropYieldID = lCropYieldID
        'objCPOPPT.LoadingLocationID = lLocationID
        'objCPOPPT.CPODate = dtpKernalDate.Value

        'If (lLocationID <> String.Empty) And (lTransferKernelId <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objCPOBOL.DuplicateKernelTransLocationCheck(objCPOPPT)
        '    If objCheckDuplicateLoadLocation = 0 Then
        '        txtLoadMonthToDate.Enabled = False
        '    Else
        '        txtLoadMonthToDate.Enabled = True
        '    End If
        'End If

        '''''Month Qty Value '''''''''''''''

        'Dim dsCrop As New DataSet
        ''If (lLocationID <> String.Empty) And (lTransferKernelId <> String.Empty) And (lProductionIDNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
        'If (lLocationID <> String.Empty) And (lTransferKernelId <> String.Empty) And (lCropYieldID <> String.Empty) Then
        '    dsCrop = KernalProductionBOL.KernelGetTransVsLocMonthQty(objCPOPPT)
        '    If dsCrop.Tables.Count <> 0 Then
        '        If dsCrop.Tables(0).Rows.Count <> 0 Then
        '            lLoadVsLoc = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
        '            txtTransMonthToDate.Text = dsCrop.Tables(0).Rows(0).Item("MonthToDate")
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


    End Sub
    Private Sub chkKernalDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKernalDate.CheckedChanged
        If chkKernalDate.Checked = True Then
            dtpKernalViewDate.Enabled = True
        Else
            dtpKernalViewDate.Enabled = False
        End If
    End Sub
    Private Sub btnViewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSearch.Click


        If chkKernalDate.Checked = False Then
            DisplayInfoMessage("Msg20")
            ''MsgBox("Please Enter Criteria to Search!")
            KernalGridViewBind()

        Else
            KernalGridViewBind()
            If dgvKernalView.RowCount = 0 Then
                DisplayInfoMessage("Msg21")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub
    Private Sub dgvKernalView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernalView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateKernalView()
            End If
        End If


    End Sub
    
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If dgvKernalView.RowCount > 0 Then
            UpdateKernalView()
        End If


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

    Private Sub txtLoadQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadQty.Leave
        If lLoadCapacity < Val(txtLoadQty.Text) Then
            DisplayInfoMessage("Msg22")
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
            ElseIf lTransMonthToDate > 0 And txtTransQty.Text <> "" And btnTransAddFlag = True Then
                txtTransMonthToDate.Text = lTransMonthToDate + Val(txtTransQty.Text)
            ElseIf lTransMonthToDate > 0 And txtTransQty.Text <> "" And btnTransAddFlag = False Then
                txtTransMonthToDate.Text = lTransMonthToDate + Val(txtTransQty.Text) - lTransferQtyPrev
            ElseIf txtTransMonthToDate.Enabled = False Then
                txtTransMonthToDate.Text = ""
            End If
        Else
            txtTransMonthToDate.Text = ""
        End If


    End Sub
    'Public Function ResetMain()
    '    ''''For Stock CPO
    '    cmbStockKernal.SelectedIndex = 0
    '    lblCapacityValue.Text = "Capacity"
    '    lblBalanceValue.Text = "Balance"
    '    txtCurrentReading.Text = ""
    '    'txtMeasurement.Text = ""
    '    txtTemparature.Text = ""
    '    'txtFFA.Text = ""
    '    txtMoisture.Text = ""
    '    txtDirt.Text = ""
    'End Function
    Private Sub Add_Clicked()
        'lCurrentReadingToday = 0.0
        'lLoadQtyToday = 0.0
        'lTransQtyToday = 0.0
        'lBalanceToday = 0.0
        'lTodayQty = 0.0
        If dtpKernalDate.Enabled = True Then

            Dim objKernalPPT As New KernalProductionPPT
            Dim objKernalBOL As New KernalProductionBOL

            Dim objCheckDuplicateRecord As Object = 0
            objKernalPPT.KernalDate = dtpKernalDate.Value
            objKernalPPT.CropYieldID = lCropYieldID
            objCheckDuplicateRecord = objKernalBOL.DuplicateDateCheck(objKernalPPT)

            If objCheckDuplicateRecord = 0 Then
                DisplayInfoMessage("Msg23")
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
                SaveKernalDetail()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetMain()
            End If
        ElseIf btnAddFlag = False Then
            If (IsCheckValidation() = False) Then
                Exit Sub
            Else
                UpdateKernalDetails()
                'lblStatus.Text = "OPEN"
                'clear()
                ResetMain()
            End If
        End If
    End Sub
    Private Sub SaveKernalDetail()
        Try
            Dim intRowcount As Integer = dtKernalAdd.Rows.Count
            'If Not TankNoExist(cmbStockTank.Text) Then 'StockCode Validation 
            If Not KernelExist(cmbStockKernal.Text) Then
                rowKernalAdd = dtKernalAdd.NewRow()

                Dim objCPOPPT As New CPOProductionPPT
                Dim objCPOBOL As New CPOProductionBOL

                '''' For check Duplicate Tank ''''
                'objCPOPPT.CropYieldID = lCropYieldID
                'objCPOPPT.CPODate = dtpKernalDate.Value
                'objCPOPPT.KernalID = lStockKernelID

                'Dim objCheckDuplicateTank As Object = 0
                'objCheckDuplicateTank = objCPOBOL.DuplicateKernalCheck(objCPOPPT)
                'If objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a Same Kernal For the Date. Please try again.")
                '    Exit Sub
                'End If

                If intRowcount = 0 And dtAddFlag = False Then

                    columnKernalAdd = New DataColumn("StockKernalType", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("Capacity", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("Balance", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("CurrentReading", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("Writeoff", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("Reason", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    'columnKernalAdd = New DataColumn("Measurement", System.Type.[GetType]("System.String"))
                    'dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("Temperature", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    'columnKernalAdd = New DataColumn("FFA", System.Type.[GetType]("System.String"))
                    'dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("Moisture", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("KernelStorageID", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)

                    columnKernalAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("TransLocation", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)


                    columnKernalAdd = New DataColumn("TransLocationID", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("TransTankNo", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)



                    columnKernalAdd = New DataColumn("ProdStockID", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    'columnKernalAdd = New DataColumn("ProdTranshipID", System.Type.[GetType]("System.String"))
                    'dtKernalAdd.Columns.Add(columnKernalAdd)
                    'columnKernalAdd = New DataColumn("ProdLoadingID", System.Type.[GetType]("System.String"))
                    'dtKernalAdd.Columns.Add(columnKernalAdd)

                    columnKernalAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("LoadMonth", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("TranshipQty", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)

                    columnKernalAdd = New DataColumn("TranshipMonth", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("prodTodayQty", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("ProdMonthQty", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    columnKernalAdd = New DataColumn("ProdYearQty", System.Type.[GetType]("System.String"))
                    dtKernalAdd.Columns.Add(columnKernalAdd)
                    'columnKernalAdd = New DataColumn("StockKernalType", System.Type.[GetType]("System.String"))
                    'dtKernalAdd.Columns.Add(columnKernalAdd)

                    rowKernalAdd("StockKernalType") = Me.cmbStockKernal.Text
                    If Me.lblCapacityValue.Text <> String.Empty Then
                        rowKernalAdd("Capacity") = Me.lblCapacityValue.Text
                    End If
                    'If Me.lblBalanceValue.Text <> String.Empty Then
                    '    rowKernalAdd("Balance") = Me.lblBalanceValue.Text
                    'End If
                    If Me.txtBalance.Text <> String.Empty Then
                        rowKernalAdd("Balance") = Me.txtBalance.Text
                    End If

                    If Me.txtCurrentReading.Text <> String.Empty Then
                        rowKernalAdd("CurrentReading") = CDbl(Me.txtCurrentReading.Text)
                    End If
                    If Me.txtWriteoff.Text <> String.Empty Then
                        rowKernalAdd("Writeoff") = CDbl(Me.txtWriteoff.Text)
                    End If
                    If Me.txtReason.Text <> String.Empty Then
                        rowKernalAdd("Reason") = CDbl(Me.txtReason.Text)
                    End If

                    If Me.txtTemparature.Text <> String.Empty Then
                        rowKernalAdd("Temperature") = CDbl(Me.txtTemparature.Text)
                    End If

                    If Me.txtMoisture.Text <> String.Empty Then
                        rowKernalAdd("Moisture") = CDbl(Me.txtMoisture.Text)
                    End If
                    If Me.txtDirt.Text <> String.Empty Then
                        rowKernalAdd("DirtP") = CDbl(Me.txtDirt.Text)
                    End If
                    rowKernalAdd("KernelStorageID") = Me.cmbStockKernal.SelectedValue.ToString

                    'rowKernalAdd("LoadLocation") = Me.cmbLoadLocation.Text
                    'rowKernalAdd("TransLocation") = Me.cmbLoadTrans.Text
                    'rowKernalAdd("TransLocation") = Me.cmbTranshipKernal.Text


                    If Me.lProdStockID <> String.Empty Then
                        rowKernalAdd("ProdStockID") = Me.lProdStockID
                    End If

                

                    rowKernalAdd("StockKernalType") = Me.cmbStockKernal.Text


                    dtKernalAdd.Rows.InsertAt(rowKernalAdd, intRowcount)
                    dtAddFlag = True

                Else

                    rowKernalAdd("StockKernalType") = Me.cmbStockKernal.Text
                    If Me.lblCapacityValue.Text <> String.Empty Then
                        rowKernalAdd("Capacity") = Me.lblCapacityValue.Text
                    End If
                    'If Me.lblBalanceValue.Text <> String.Empty Then
                    '    rowKernalAdd("Balance") = Me.lblBalanceValue.Text
                    'End If
                    If Me.txtBalance.Text <> String.Empty Then
                        rowKernalAdd("Balance") = Me.txtBalance.Text
                    End If

                    If Me.txtCurrentReading.Text <> String.Empty Then
                        rowKernalAdd("CurrentReading") = CDbl(Me.txtCurrentReading.Text)
                    End If

                    If Me.txtWriteoff.Text <> String.Empty Then
                        rowKernalAdd("Writeoff") = CDbl(Me.txtWriteoff.Text)
                    End If

                    If Me.txtReason.Text <> String.Empty Then
                        rowKernalAdd("Reason") = CDbl(Me.txtReason.Text)
                    End If

                    If Me.txtTemparature.Text <> String.Empty Then
                        rowKernalAdd("Temperature") = CDbl(Me.txtTemparature.Text)
                    End If

                    If Me.txtMoisture.Text <> String.Empty Then
                        rowKernalAdd("Moisture") = CDbl(Me.txtMoisture.Text)
                    End If
                    If Me.txtDirt.Text <> String.Empty Then
                        rowKernalAdd("DirtP") = CDbl(Me.txtDirt.Text)
                    End If
                    rowKernalAdd("KernelStorageID") = Me.cmbStockKernal.SelectedValue.ToString

                    'rowKernalAdd("LoadLocation") = Me.cmbLoadLocation.Text
                    'rowKernalAdd("TransLocation") = Me.cmbLoadTrans.Text
                    'rowKernalAdd("TransLocation") = Me.cmbTranshipKernal.Text


                    If Me.lProdStockID <> String.Empty Then
                        rowKernalAdd("ProdStockID") = Me.lProdStockID
                    End If



                    rowKernalAdd("StockKernalType") = Me.cmbStockKernal.Text
                    dtKernalAdd.Rows.InsertAt(rowKernalAdd, intRowcount)
                    dtAddFlag = True

                End If
            Else
                DisplayInfoMessage("Msg24")
                ''MessageBox.Show("Sorry this Storage already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvKernelDetails
                .DataSource = dtKernalAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try

    End Sub
    Private Function KernelExist(ByVal Kernel As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvKernelDetails.Rows
                If Kernel = objDataGridViewRow.Cells("dgclStockKernelType").Value.ToString() Then
                    ' txtStockCode.Text = ""
                    cmbStockKernal.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try
    End Function
    Private Sub UpdateKernalDetails()
        Try
            Dim intCount As Integer = dgvKernelDetails.CurrentRow.Index

            If lTempKernel = cmbStockKernal.Text Then
                dgvKernelDetails.Rows(intCount).Cells("dgclStockKernelType").Value = cmbStockKernal.Text
                If Me.lblCapacityValue.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
                End If
                If Me.txtBalance.Text <> Nothing Then
                    '   If Me.lblBalanceValue.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclBalance").Value = Me.txtBalance.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
                End If
                If Me.txtCurrentReading.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
                End If

                If Me.txtWriteoff.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclWriteoff").Value = Me.txtWriteoff.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclWriteoff").Value = DBNull.Value
                End If

                If Me.txtReason.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclReason").Value = Me.txtReason.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclReason").Value = DBNull.Value
                End If

                If Me.txtTemparature.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
                End If

                If Me.txtDirt.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclDirtp").Value = Me.txtDirt.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclDirtp").Value = DBNull.Value
                End If

                If Me.txtMoisture.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
                End If
                dgvKernelDetails.Rows(intCount).Cells("dgclKernelStorageID").Value = cmbStockKernal.SelectedValue.ToString
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True
                'clear()

            ElseIf Not KernelExist(cmbStockKernal.Text) Then
                dgvKernelDetails.Rows(intCount).Cells("dgclStockKernelType").Value = cmbStockKernal.Text
                If Me.lblCapacityValue.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclCapacity").Value = Me.lblCapacityValue.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclCapacity").Value = DBNull.Value
                End If
                'If Me.lblBalanceValue.Text <> Nothing Then
                If Me.txtBalance.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclBalance").Value = Me.txtBalance.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclBalance").Value = DBNull.Value
                End If
                If Me.txtCurrentReading.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclCurrentReading").Value = Me.txtCurrentReading.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclCurrentReading").Value = DBNull.Value
                End If

                If Me.txtWriteoff.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclWriteoff").Value = Me.txtWriteoff.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclWriteoff").Value = DBNull.Value
                End If

                If Me.txtReason.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclReason").Value = Me.txtReason.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclReason").Value = DBNull.Value
                End If

                If Me.txtTemparature.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclTemperature").Value = Me.txtTemparature.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclTemperature").Value = DBNull.Value
                End If
                If Me.txtDirt.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclDirtp").Value = Me.txtDirt.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclDirtp").Value = DBNull.Value
                End If
                If Me.txtMoisture.Text <> Nothing Then
                    dgvKernelDetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                Else
                    dgvKernelDetails.Rows(intCount).Cells("dgclMoisture").Value = DBNull.Value
                End If
                dgvKernelDetails.Rows(intCount).Cells("dgclKernelStorageID").Value = cmbStockKernal.SelectedValue.ToString
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg25")
                ''MessageBox.Show("Sorry this Storage already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Add_Clicked()
        ProductionTodayCalculation()
    End Sub

    Private Sub dgvKernalDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadKernalDetails.CellDoubleClick

        BindDgvLoadKernelDetails()
      
    End Sub
    Private Sub BindDgvKernalDetails()
        Try
            If dgvKernelDetails.Rows.Count > 0 Then
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Update"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Memperbarui"
                End If
                'Me.btnAdd.Text = "Update"
                'Me.btnSaveAll.Text = "Update All"

                cmbStockKernal.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclStockKernelType").Value.ToString()
                lTempKernel = dgvKernelDetails.SelectedRows(0).Cells("dgclStockKernelType").Value.ToString()

                Dim lstrin As String
                lstrin = dgvKernelDetails.SelectedRows(0).Cells("dgclStockKernelType").Value.ToString()
                cmbStockKernal.Text = "Bin"
                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclProdStockID").Value Is DBNull.Value Then
                    lProdStockID = dgvKernelDetails.SelectedRows(0).Cells("dgclProdStockID").Value.ToString()
                Else
                    lProdStockID = Nothing
                End If

                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclCapacity").Value.ToString() Is DBNull.Value Then
                    Me.lblCapacityValue.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclCapacity").Value.ToString()
                End If

                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclBalance").Value.ToString() Is DBNull.Value Then
                    '  Me.lblBalanceValue.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclBalance").Value.ToString()
                    Me.txtBalance.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclBalance").Value.ToString()
                End If
                'If Not dgvKernalDetails.SelectedRows(0).Cells("dgclMeasurement").Value.ToString() Is DBNull.Value Then
                '    Me.txtMeasurement.Text = dgvKernalDetails.SelectedRows(0).Cells("dgclMeasurement").Value.ToString()
                'End If
                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclCurrentReading").Value.ToString() Is DBNull.Value Then
                    Me.txtCurrentReading.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclCurrentReading").Value.ToString()
                End If

                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclWriteoff").Value.ToString() Is DBNull.Value Then
                    Me.txtWriteoff.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclWriteoff").Value.ToString()
                End If

                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclReason").Value.ToString() Is DBNull.Value Then
                    Me.txtReason.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclReason").Value.ToString()
                End If

                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclMoisture").Value.ToString() Is DBNull.Value Then
                    Me.txtMoisture.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclMoisture").Value.ToString()
                End If
                Dim tempstr As String = String.Empty
                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclTemperature").Value.ToString() Is DBNull.Value Then
                    txtTemparature.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclTemperature").Value.ToString()
                End If

                'If Not dgvKernalDetails.SelectedRows(0).Cells("dgclFFA").Value.ToString() Is DBNull.Value Then
                '    Me.txtFFA.Text = dgvKernalDetails.SelectedRows(0).Cells("dgclFFA").Value.ToString()
                'End If

                If Not dgvKernelDetails.SelectedRows(0).Cells("dgclDirtp").Value.ToString() Is DBNull.Value Then
                    txtDirt.Text = dgvKernelDetails.SelectedRows(0).Cells("dgclDirtp").Value.ToString()
                End If

                AddFlag = False
                btnAddFlag = False
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub BindDgvTransKernelDetails()

        If dgvTransKernalDetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddTrans.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddTrans.Text = "Memperbarui"
            End If
            ''Me.btnAddTrans.Text = "Update"
            'Me.btnSaveAll.Text = "Update All"
            btnTransAddFlag = False

            cmbTranshipKernal.Text = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransKernelStorage").Value.ToString()
            lTranshipKernal = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransKernelStorage").Value.ToString()
            If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclProdTranshipID").Value Is DBNull.Value Then
                lProdTranshipID = dgvTransKernalDetails.SelectedRows(0).Cells("dgclProdTranshipID").Value
            Else
                lProdTranshipID = Nothing
            End If


            If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransLoc").Value.ToString() Is DBNull.Value Then
                Me.cmbLoadTrans.Text = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransLoc").Value.ToString()
            End If
            lLoadTrans = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransLoc").Value.ToString()
            If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransMonthtodate").Value.ToString() Is DBNull.Value Then
                Me.txtTransMonthToDate.Text = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransMonthtodate").Value.ToString()
            End If
            If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransferKernelID").Value.ToString() Is DBNull.Value Then
                Me.lTransTankID = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransferKernelID").Value.ToString()
            End If
            If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransferLocID").Value.ToString() Is DBNull.Value Then
                lTransLocationID = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransferLocID").Value.ToString()
            End If
            If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransQty").Value.ToString() Is DBNull.Value Then
                Me.txtTransQty.Text = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransQty").Value.ToString()
                lTransferQtyPrev = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransQty").Value.ToString()
            End If
            ''''For Remarks''''''''''''''''''''
            txtTransRemarks.Text = dgvTransKernalDetails.SelectedRows(0).Cells("dgclTransRemarks").Value.ToString()
            AddFlag = False

            If TransMonthCount = True And SaveFlag = False Then
                txtTransMonthToDate.Enabled = True
            End If

        End If

    End Sub
    Private Sub BindDgvLoadKernelDetails()
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

    Private Sub KernalProductionFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (dgvKernelDetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M89"

            End If
        End If
    End Sub

    Private Sub KernalProductionFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub KernalProductionFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        ' dtpKernalDate.Value = Date.Today
        dtpKernalViewDate.Value = Date.Today
        dtpKernalDate.MaxDate = Date.Today
        DtpProductionDate.MaxDate = Date.Today
        tcKernalProduction.SelectedTab = tpKernalView
        Dim objKernelPPT As New KernalProductionPPT
       
        Dim dsCrop As New DataSet
        dsCrop = KernalProductionBOL.ProductionCropYieldIDSelect(objKernelPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg26")
            '' MsgBox("No Record in Crop yield for kernel , Please insert the record in General Crop Yield")
        End If

        loadCmbStorage()
        loadCmbLocation()
        ' CPOProductionMonthYearSelect()
        dtpKernalViewDate.Enabled = False

        lCropYieldCode = "Kernel"
        GetCropYieldID()
        objKernelPPT.CropYieldID = lCropYieldID
        KernalGridViewBind()

        Dim ToDate As Date = Date.Today
        dtpKernalViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        dtpKernalViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernalProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernalProductionFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tcKernalProduction.TabPages("tpKernalSave").Text = rm.GetString("tcKernalProduction.TabPages(tpKernalSave).Text")
            'tcKernalProduction.TabPages("tpKernalView").Text = rm.GetString("tcKernalProduction.TabPages(tpKernalView).Text")
            'PnlSearch.CaptionText = rm.GetString("SearchKernelProduction")

            'grpStockKernel.Text = rm.GetString("StockKernel")
            'grpKernelStockRecords.Text = rm.GetString("KernelStockRecords")
            'grpTransferKernal.Text = rm.GetString("TransferKernal")
            'grpTranshipKernelRecords.Text = rm.GetString("TranshipKernelRecords")
            'grpKernalProduction.Text = rm.GetString("grKernalProduction")
            'grpTransferKernelRecords.Text = rm.GetString("TransferKernelRecords")
            'grpTranshipKernelRecords.Text = rm.GetString("TranshipKernelRecords")

            ''  chkKernalDate.Text = rm.GetString("Date")
            'chkKernalDate.Text = rm.GetString("ProductionDate")
            'lblProductionDate.Text = rm.GetString("ProductionDate")
            ' ''lblSearchBy.Text = rm.GetString("SearchBy")

            btnAdd.Text = rm.GetString("Add")
            btnResetMain.Text = rm.GetString("Reset")

            'dgvKernelDetails.Columns("dgclStockKernelType").HeaderText = rm.GetString("Storage")
            'dgvKernelDetails.Columns("dgclBalance").HeaderText = rm.GetString("Balance B/F(MT)")
            'dgvKernelDetails.Columns("dgclCapacity").HeaderText = rm.GetString("Capacity (Mt)")
            'dgvKernelDetails.Columns("dgclCurrentReading").HeaderText = rm.GetString("Current Reading (Mt)")
            ''  dgvKernelDetails.Columns("dgclMeasurement").HeaderText = rm.GetString("Measurement (Cm)")
            'dgvKernelDetails.Columns("dgclTemperature").HeaderText = rm.GetString("Temperature")
            '' dgvKernelDetails.Columns("dgclFFA").HeaderText = rm.GetString("FFA")
            'dgvKernelDetails.Columns("dgclMoisture").HeaderText = rm.GetString("Moisture")


            'Label7.Text = rm.GetString("Remarks")
            btnAddTrans.Text = rm.GetString("Add")
            btnAddLoad.Text = rm.GetString("Add")
            btnTransReset.Text = rm.GetString("Reset")
            btnLoadReset.Text = rm.GetString("Reset")


            'dgvLoadKernalDetails.Columns("dgclTransferStorage").HeaderText = rm.GetString("Storage")
            'dgvLoadKernalDetails.Columns("dgclTransferLoc").HeaderText = rm.GetString("To Loading")
            'dgvLoadKernalDetails.Columns("dgclTransferQty").HeaderText = rm.GetString("Quantity")
            'dgvLoadKernalDetails.Columns("dgclMonthTodate").HeaderText = rm.GetString("Month Todate")
            'dgvLoadKernalDetails.Columns("dgclLoadRemarks").HeaderText = rm.GetString("Remarks")

            'dgvTransKernalDetails.Columns("dgclTransKernelStorage").HeaderText = rm.GetString("Storage")
            'dgvTransKernalDetails.Columns("dgclTransLoc").HeaderText = rm.GetString("To Loading")
            ''dgvTransKernalDetails.Columns("dgclTransLoad").HeaderText = rm.GetString("Transshipment")
            'dgvTransKernalDetails.Columns("dgclTransQty").HeaderText = rm.GetString("Quantity")
            'dgvTransKernalDetails.Columns("dgclTransMonthtodate").HeaderText = rm.GetString("Month Todate")
            'dgvTransKernalDetails.Columns("dgclTransRemarks").HeaderText = rm.GetString("Remarks")


            ''lblKernelProduction.Text = rm.GetString("KernalProduction")
            ''lblKernelToday.Text = rm.GetString("Today")
            ''lblProductionMonthTodate.Text = rm.GetString("Month Todate")
            ''lblProductionYearTodate.Text = rm.GetString("YearTodate")

            btnSaveAll.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")

            'dgvKernalView.Columns("gvProductionDate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")
            btnView.Text = rm.GetString("ViewReports")


        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub KernelGetTodayQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.CPODate = dtpKernalDate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            Dim dsCPOToday As DataSet
            'dsCPOToday = CPOProductionBOL.CPOGetTodayQty(objCPOPPT)
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

                    'If dsCPOToday.Tables(2).Rows.Count <> 0 Then
                    '    If Not dsCPOToday.Tables(2).Rows(0).Item("LoadQty") Is DBNull.Value Then
                    '        lLoadQty = dsCPOToday.Tables(2).Rows(0).Item("LoadQty")
                    '        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    '    Else
                    '        lLoadQty = 0.0
                    '    End If
                End If
            Else
                'lLoadQty = 0.0
                'lTransQty = 0.0
                'lBalance = 0.0
                lCurrentReading = 0.0
            End If


            '  Me.txtProductionToday.Text = lCurrentReading
        Catch ex As Exception
        End Try

    End Sub
    Private Sub KernelGetMonthYearQty()
        Try
            Dim objCPOPPT As New CPOProductionPPT
            Dim dsProdStock As DataSet
            Dim dsProdLoad As DataSet
            Dim dsProdtrans As DataSet
            Dim lCurrentReading As Double
            Dim lBalance As Double
            Dim lTransQty As Double
            Dim lLoadQty As Double
            objCPOPPT.CPODate = dtpKernalDate.Value
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
                    lTransQty = 0.0
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
                Else
                    lCurrentReading = 0.0
                End If

                If dsProdStock.Tables(1).Rows.Count <> 0 Then
                    If Not dsProdStock.Tables(1).Rows(0).Item("Balance") Is DBNull.Value Then
                        lBalance = dsProdStock.Tables(1).Rows(0).Item("Balance")
                        'Me.txtProductionMonth.Text = dsProd.Tables(0).Rows(0).Item("MonthTodate")
                    Else
                        lBalance = 0.0
                    End If
                Else
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
    'Private Sub CPOGetLoadTransMonthQty()
    '    Try
    '        Dim objCPOPPT As New CPOProductionPPT
    '        Dim dsTransLoad As DataSet
    '        lCropYieldID = "M4"
    '        objCPOPPT.CropYieldID = lCropYieldID
    '        objCPOPPT.CPODate = dtpKernalDate.Value
    '        dsTransLoad = CPOProductionBOL.CPOGetLoadTransMonthQty(objCPOPPT)

    '        If dsTransLoad.Tables(0).Rows.Count <> 0 Then
    '            If Not dsTransLoad.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '                Me.txtLoadMonthToDate.Text = dsTransLoad.Tables(0).Rows(0).Item("MonthTodate")
    '            Else
    '                Me.txtLoadMonthToDate.Text = 0.0
    '            End If
    '            If Not dsTransLoad.Tables(1).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '                Me.txtTransMonthToDate.Text = dsTransLoad.Tables(1).Rows(0).Item("MonthTodate")
    '            Else
    '                Me.txtTransMonthToDate.Text = 0.0
    '            End If
    '        Else
    '            Me.txtLoadMonthToDate.Text = 0.0
    '            Me.txtTransMonthToDate.Text = 0.0
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Private Sub CPOGetLoadTransMonthQty()
    '    Try
    '        Dim objCPOPPT As New CPOProductionPPT
    '        Dim dsTransLoad As DataSet
    '        'lCropYieldID = "M1"
    '        objCPOPPT.CropYieldID = lCropYieldID
    '        objCPOPPT.CPODate = dtpKernalDate.Value
    '        dsTransLoad = CPOProductionBOL.CPOGetLoadTransMonthQty(objCPOPPT)
    '        If dsTransLoad.Tables.Count <> 0 Then

    '            If dsTransLoad.Tables(0).Rows.Count <> 0 Then
    '                'If lresetLoad = True Then
    '                If Not dsTransLoad.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '                    Me.txtLoadMonthToDate.Text = dsTransLoad.Tables(0).Rows(0).Item("MonthTodate")
    '                Else
    '                    Me.txtLoadMonthToDate.Text = 0.0
    '                End If
    '                lresetLoad = False
    '                'ElseIf lresetTrans = True Then
    '                If Not dsTransLoad.Tables(1).Rows(0).Item("MonthTodate") Is DBNull.Value Then
    '                    Me.txtTransMonthToDate.Text = dsTransLoad.Tables(1).Rows(0).Item("MonthTodate")
    '                Else
    '                    Me.txtTransMonthToDate.Text = 0.0
    '                End If
    '                lresetTrans = False

    '                ' Else
    '                '  Me.txtLoadMonthToDate.Text = 0.0
    '                '  Me.txtTransMonthToDate.Text = 0.0
    '                ' End If
    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub btnResetMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMain.Click

        ResetMain()

    End Sub

    Private Sub dtpKernalDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpKernalDate.ValueChanged
        'KernelGetTodayQty()
        'KernelGetMonthYearQty()
        'CPOGetLoadTransMonthQty()
        'UpdateTankMasterBFQty()
        ' CPOProductionMonthYearSelect()

        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL

        Dim objCheckDuplicateRecord As Object = 0
        objCPOPPT.CPOProductionDate = dtpKernalDate.Value
        objCPOPPT.CropYieldID = lCropYieldID
        objCheckDuplicateRecord = objCPOBOL.DuplicateDateCheck(objCPOPPT)

        If objCheckDuplicateRecord = 0 Then
            GetProductionID(dtpKernalDate.Value)
            SaveFlag = False
        Else
            SaveFlag = True
            'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
            'Exit Sub
        End If


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
                    lProductionIDNew = dsLoad.Tables(0).Rows(0).Item("ProductionID")
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgvKernalView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvKernalView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateKernalView()
            e.Handled = True
        End If
    End Sub
    Public Sub ResetTrans()
        ''''For Stock CPO

        lresetLoad = False
        lresetTrans = True
        If cmbTranshipKernal.Items.Count > 0 Then
            cmbTranshipKernal.SelectedIndex = 0
        End If
        If cmbLoadTrans.Items.Count > 0 Then
            cmbLoadTrans.SelectedIndex = 0
        End If

        txtTransQty.Text = ""
        txtTransRemarks.Text = ""
        ''''''''''For Reset the tranship description
        'lblTranshipDescription.Text = "Description"
        '   CPOGetLoadTransMonthQty()
        If GlobalPPT.strLang = "en" Then
            btnAddTrans.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddTrans.Text = "Menambahkan"
        End If
        ''btnAddTrans.Text = "Add"
        btnTransAddFlag = True
        lTransferQtyPrev = 0
    End Sub
    Public Sub ResetLoad()
        ''''For Stock CPO
        lresetLoad = True
        lresetTrans = False
        If cmbTransferKernal.Items.Count > 0 Then
            cmbTransferKernal.SelectedIndex = 0
        End If
        If cmbLoadLocation.Items.Count > 0 Then
            cmbLoadLocation.SelectedIndex = 0
        End If
        txtLoadRemarks.Text = ""
        txtLoadQty.Text = ""
        ''''For Reset the Description
        ' lblTransferDescription.Text = "Description"
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
    Private Sub SaveLoadKernelDetail()
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL

        Dim intRowcount As Integer = dtLoadKernelAdd.Rows.Count

        If Not LocationExist(cmbLoadLocation.Text, cmbTransferKernal.Text, dtpKernalDate.Value) Then 'Location Validation 

            rowLoadKernelAdd = dtLoadKernelAdd.NewRow()

            If intRowcount = 0 And btnAddLoadFlag = True Then

                Try

                    columnLoadKernelAdd = New DataColumn("LoadTankNo", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadMonthToDate", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadTankID", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("CPOProductionDate", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("Descp", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    ''''''''''For KernelStorageID'''''''''''''''''''
                    columnLoadKernelAdd = New DataColumn("KernelStorageID", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)

                    '''''''''''''''''For Remarks''''''''''''''''''''''''
                    columnLoadKernelAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    ''''''''''''

                    rowLoadKernelAdd("LoadTankNo") = Me.cmbTransferKernal.Text
                    rowLoadKernelAdd("LoadLocation") = Me.cmbLoadLocation.Text

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowLoadKernelAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowLoadKernelAdd("LoadMonthToDate") = Me.txtLoadMonthToDate.Text
                    End If

                    rowLoadKernelAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString


                    rowLoadKernelAdd("CPOProductionDate") = dtpKernalDate.Value
                    ''For Kernel'''''''''''''''''''''''''''
                    rowLoadKernelAdd("KernelStorageID") = cmbTransferKernal.SelectedValue.ToString
                    ''''''''''''For Remarks'''''''''''''''''''
                    rowLoadKernelAdd("LoadRemarks") = txtLoadRemarks.Text.Trim
                    '  rowLoadKernelAdd("Descp") = lblTransferDescription.Text

                    dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)
                    dtLoadAddFlag = True
                Catch ex As Exception
                    rowLoadKernelAdd("LoadTankNo") = Me.cmbTransferKernal.Text
                    rowLoadKernelAdd("LoadLocation") = Me.cmbLoadLocation.Text

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowLoadKernelAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowLoadKernelAdd("LoadMonthToDate") = Me.txtLoadMonthToDate.Text
                    End If
                    rowLoadKernelAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString


                    'If Me.lTransferKernelId <> String.Empty Then
                    '    rowLoadKernelAdd("LoadTankID") = DBNull.Value ' lTransferKernelId 'lLoadTankID
                    'End If
                    rowLoadKernelAdd("CPOProductionDate") = dtpKernalDate.Value

                    ''''''''''For Kernel''''''''''''''''''''''''''''''
                    rowLoadKernelAdd("KernelStorageID") = cmbTransferKernal.SelectedValue.ToString
                    ''rowLoadKernelAdd("KernelStorageID") = lTransferKernelId

                    ''''''''''''For Remarks'''''''''''''''''''
                    rowLoadKernelAdd("LoadRemarks") = txtLoadRemarks.Text.Trim
                    '   rowLoadKernelAdd("Descp") = lblTransferDescription.Text

                    dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)
                    dtLoadAddFlag = True

                End Try

            Else

                rowLoadKernelAdd("LoadTankNo") = Me.cmbTransferKernal.Text
                rowLoadKernelAdd("LoadLocation") = Me.cmbLoadLocation.Text

                If Me.txtLoadQty.Text <> String.Empty Then
                    rowLoadKernelAdd("LoadQty") = Me.txtLoadQty.Text
                End If
                If Me.txtLoadMonthToDate.Text <> String.Empty Then
                    rowLoadKernelAdd("LoadMonthToDate") = Me.txtLoadMonthToDate.Text
                End If
                rowLoadKernelAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString

                rowLoadKernelAdd("CPOProductionDate") = dtpKernalDate.Value

                ''''''''''''For Remarks'''''''''''''''''''
                rowLoadKernelAdd("LoadRemarks") = txtLoadRemarks.Text.Trim
                '    rowLoadKernelAdd("Descp") = lblTransferDescription.Text

                ''''''''''For Kernel''''''''''''''''''''''''''''''
                rowLoadKernelAdd("KernelStorageID") = cmbTransferKernal.SelectedValue.ToString
                'rowLoadKernelAdd("KernelStorageID") = lTransferKernelId

                dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)
                btnAddLoadFlag = True

            End If
        Else
            DisplayInfoMessage("Msg27")
            ''MessageBox.Show("Sorry this Kernel Storage , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        With dgvLoadKernalDetails
            .DataSource = dtLoadKernelAdd
            .AutoGenerateColumns = False
        End With

    End Sub
    Private Function IsCheckValidationLoad()
        'If dtpCPODate.Text.Trim = String.Empty Then
        '    MessageBox.Show(" Please check Production Date", " Date Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return False
        'End If
        If cmbTransferKernal.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is Required", "Storage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTransferKernal.Focus()
            Return False
        End If
        If cmbLoadLocation.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg4")
            ''MessageBox.Show("This field is Required", "To Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadLocation.Focus()
            Return False
        End If
        If txtLoadQty.Text = String.Empty Then
            DisplayInfoMessage("Msg28")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadQty.Focus()
            Return False
        End If
        If txtLoadMonthToDate.Text = String.Empty Then
            DisplayInfoMessage("Msg29")
            ''MessageBox.Show("This Field is Required", "Month To Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadMonthToDate.Focus()
            Return False
        End If
        If Val(txtLoadMonthToDate.Text) < Val(txtLoadQty.Text) Then
            DisplayInfoMessage("Msg30")
            ''MessageBox.Show("Month To Date value cant be lesser than Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If cmbTranshipKernal.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg31")
            ''MessageBox.Show("This field is Required", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbTranshipKernal.Focus()
            Return False
        End If
        If cmbLoadTrans.SelectedIndex = 0 Then
            DisplayInfoMessage("Msg32")
            ''MessageBox.Show("This field is Required", "Transshipment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        If txtTransQty.Text = String.Empty Then
            DisplayInfoMessage("Msg28")
            ''MessageBox.Show("This Field is Required", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransQty.Focus()
            Return False
        End If
        If txtTransMonthToDate.Text = String.Empty Then
            DisplayInfoMessage("Msg29")
            ''MessageBox.Show("This Field is Required", "Month To Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransMonthToDate.Focus()
            Return False
        End If

        If cmbLoadTrans.Text = cmbTranshipKernal.Text Then
            DisplayInfoMessage("Msg33")
            ''MessageBox.Show("Loading and Transshipment cant be same ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbLoadTrans.Focus()
            Return False
        End If
        If Val(txtTransMonthToDate.Text) < Val(txtTransQty.Text) Then
            DisplayInfoMessage("Msg34")
            ''MessageBox.Show("Month To Date value cant be lesser than Quantity ", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTransMonthToDate.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub AddLoad_Clicked()
        If lLoadCapacity < lLoadQty Then
            DisplayInfoMessage("Msg35")
            ''MessageBox.Show("Sum of  Quantity(Mt) should be lesser than Storage Tank Capacity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtLoadQty.Focus()
            Exit Sub
        End If

        If btnAddLoadFlag = True Then
            'If btnAdd.Text.Trim() = "Add" Then
            If (IsCheckValidationLoad() = False) Then
                Exit Sub
            Else
                'Me.txtLPOTotalPrice.Text = CDec(Convert.ToDecimal(txtQty.Text) * CDec(Convert.ToDecimal(txtUnitPrice.Text)))
                SaveLoadKernelDetail()
                'lblStatus.Text = "OPEN"
                'clear()
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
            End If
        End If
    End Sub
    Private Sub UpdateLoadKernelDetails()
        Dim intCount As Integer = dgvLoadKernalDetails.CurrentRow.Index
        If lTransferKernal = cmbTransferKernal.Text And lLoadLocation = cmbLoadLocation.Text Then
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferStorage").Value = cmbTransferKernal.Text
            'If Me.lblCapacityValue.Text <> Nothing Then
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferLoc").Value = cmbLoadLocation.Text
            ' End If
            If Me.txtLoadQty.Text <> Nothing Then
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferQty").Value = Me.txtLoadQty.Text
            Else
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferQty").Value = DBNull.Value
            End If
            If Me.txtLoadMonthToDate.Text <> Nothing Then
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclMonthTodate").Value = Me.txtLoadMonthToDate.Text
            Else
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclMonthTodate").Value = DBNull.Value
            End If

            'dgvLoadKernalDetails.Rows(intCount).Cells("dgclStockKernelID").Value = lTransferKernelId 'lLoadTankID
            dgvLoadKernalDetails.Rows(intCount).Cells("KernelStorageID").Value = cmbTransferKernal.SelectedValue.ToString
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclLoadLocID").Value = cmbLoadLocation.SelectedValue.ToString

            ''''''''''''''''''''For Remarks''''''''''''''''''''''''''''''''''''''
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim
            '    dgvLoadKernalDetails.Rows(intCount).Cells("LoadDescription").Value = lblTransferDescription.Text
            If GlobalPPT.strLang = "en" Then
                btnAddLoad.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddLoad.Text = "Menambahkan"
            End If
            ''btnAddLoad.Text = "Add"
            btnAddLoadFlag = True
            'clear()

        ElseIf Not LocationExist(cmbLoadLocation.Text, cmbTransferKernal.Text, CPODate) Then
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferStorage").Value = cmbTransferKernal.Text
            'If Me.lblCapacityValue.Text <> Nothing Then
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferLoc").Value = cmbLoadLocation.Text
            ' End If
            If Me.txtLoadQty.Text <> Nothing Then
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferQty").Value = Me.txtLoadQty.Text
            Else
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclTransferQty").Value = DBNull.Value
            End If
            If Me.txtLoadMonthToDate.Text <> Nothing Then
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclMonthTodate").Value = Me.txtLoadMonthToDate.Text
            Else
                dgvLoadKernalDetails.Rows(intCount).Cells("dgclMonthTodate").Value = DBNull.Value
            End If
            'dgvLoadKernalDetails.Rows(intCount).Cells("dgclStockKernelID").Value = lTransferKernelId 'lLoadTankID
            dgvLoadKernalDetails.Rows(intCount).Cells("KernelStorageID").Value = cmbTransferKernal.SelectedValue.ToString
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclLoadLocID").Value = cmbLoadLocation.SelectedValue.ToString
            '   dgvLoadKernalDetails.Rows(intCount).Cells("LoadDescription").Value = lblTransferDescription.Text

            ''''''''''''''''''''For Remarks''''''''''''''''''''''''''''''''''''''
            dgvLoadKernalDetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim
            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Menambahkan"
            End If
            ''btnAdd.Text = "Add"
            btnAddFlag = True
            btnAddLoadFlag = True

        Else
            DisplayInfoMessage("Msg36")
            ''MessageBox.Show("Sorry this Storage , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If


    End Sub
    Private Sub SaveTransKernelDetail()
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL

        Dim intRowcount As Integer = dtTransKernelAdd.Rows.Count

        If Not LocationExistTrans(cmbLoadTrans.Text, cmbTranshipKernal.Text, dtpKernalDate.Value) Then 'Location Validation 
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
                    columnTransKernelAdd = New DataColumn("Descp", System.Type.[GetType]("System.String"))
                    dtTransKernelAdd.Columns.Add(columnTransKernelAdd)

                    ''''For KernelStorageID '''''''''''
                    columnTransKernelAdd = New DataColumn("KernelStorageID", System.Type.[GetType]("System.String"))
                    dtTransKernelAdd.Columns.Add(columnTransKernelAdd)


                    ''''For Remarks''''''''''''''''''''''''''''''''''
                    columnTransKernelAdd = New DataColumn("TransRemarks", System.Type.[GetType]("System.String"))
                    dtTransKernelAdd.Columns.Add(columnTransKernelAdd)

                    rowTransKernelAdd("TransTankNo") = Me.cmbTranshipKernal.Text
                    rowTransKernelAdd("TransLocation") = Me.cmbLoadTrans.Text
                    rowTransKernelAdd("TransQty") = Me.txtTransQty.Text
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowTransKernelAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                    End If
                    rowTransKernelAdd("KernelStorageID") = cmbTranshipKernal.SelectedValue.ToString
                    rowTransKernelAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                    ''''For Remarks''''''''''''''''''''''''''''''''''
                    rowTransKernelAdd("TransRemarks") = txtTransRemarks.Text.Trim
                    ' rowTransKernelAdd("Descp") = lblTranshipDescription.Text

                    dtTransKernelAdd.Rows.InsertAt(rowTransKernelAdd, intRowcount)
                    dtTransAddFlag = True
                Catch ex As Exception
                    rowTransKernelAdd("TransTankNo") = Me.cmbTranshipKernal.Text
                    rowTransKernelAdd("TransLocation") = Me.cmbLoadTrans.Text
                    rowTransKernelAdd("TransQty") = Me.txtTransQty.Text
                    If Me.txtTransMonthToDate.Text <> String.Empty Then
                        rowTransKernelAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                    End If
                    rowTransKernelAdd("KernelStorageID") = cmbTranshipKernal.SelectedValue.ToString
                    rowTransKernelAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                    ''''For Remarks''''''''''''''''''''''''''''''''''
                    rowTransKernelAdd("TransRemarks") = txtTransRemarks.Text.Trim
                    ' rowTransKernelAdd("Descp") = lblTranshipDescription.Text

                    dtTransKernelAdd.Rows.InsertAt(rowTransKernelAdd, intRowcount)
                    dtTransAddFlag = True
                End Try

            Else
                rowTransKernelAdd("TransTankNo") = Me.cmbTranshipKernal.Text
                rowTransKernelAdd("TransLocation") = Me.cmbLoadTrans.Text
                rowTransKernelAdd("TransQty") = Me.txtTransQty.Text
                If Me.txtTransMonthToDate.Text <> String.Empty Then
                    rowTransKernelAdd("TransMonthToDate") = Me.txtTransMonthToDate.Text
                End If
                rowTransKernelAdd("KernelStorageID") = cmbTranshipKernal.SelectedValue.ToString
                rowTransKernelAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                ''''For Remarks''''''''''''''''''''''''''''''''''
                rowTransKernelAdd("TransRemarks") = txtTransRemarks.Text.Trim
                ' rowTransKernelAdd("Descp") = lblTranshipDescription.Text

                dtTransKernelAdd.Rows.InsertAt(rowTransKernelAdd, intRowcount)
            End If
        Else
            DisplayInfoMessage("Msg37")
            ''MessageBox.Show("Sorry this Loading Location ,Transshipment Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        With dgvTransKernalDetails
            .DataSource = dtTransKernelAdd
            .AutoGenerateColumns = False
        End With
    End Sub
    Private Sub AddTrans_Clicked()
        'If dgvKernelDetails.Rows.Count <> 0 Then
        '    For Each objDataGridViewRow In dgvKernelDetails.Rows
        '        If objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString <> String.Empty Then
        '            lCurrentReadingToday = lCurrentReadingToday + Val(objDataGridViewRow.Cells("dgclCurrentReading").Value.ToString())
        '        End If
        '    Next
        'End If

        'If dgvLoadKernalDetails.Rows.Count <> 0 Then
        '    For Each objDataGridViewRow In dgvLoadKernalDetails.Rows
        '        If objDataGridViewRow.Cells("dgclTransferQty").Value.ToString <> String.Empty Then
        '            lLoadQtyToday = lLoadQtyToday + Val(objDataGridViewRow.Cells("dgclTransferQty").Value.ToString())
        '        End If
        '    Next
        'End If

        'If lTransCapacity < lTransferQty Then
        '    MessageBox.Show("Sum of  Quantity(Mt) should be lesser than Storage Tank Capacity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    txtTransQty.Focus()
        '    Exit Sub
        'End If


        If btnTransAddFlag = True Then


            'If btnAdd.Text.Trim() = "Add" Then
            If (IsCheckValidationTrans() = False) Then
                Exit Sub
            Else

                SaveTransKernelDetail()
                'If dgvTransKernalDetails.Rows.Count <> 0 Then
                '    For Each objDataGridViewRow In dgvTransKernalDetails.Rows
                '        If objDataGridViewRow.Cells("dgclTransQty").Value.ToString <> String.Empty Then
                '            lTransQtyToday = lTransQtyToday + Val(objDataGridViewRow.Cells("dgclTransQty").Value.ToString())
                '        End If
                '    Next
                'End If
                'lTodayQty = lCurrentReadingToday + lLoadQtyToday + lTransQtyToday - lBalanceToday
                'txtProductionToday.Text = lTodayQty
                ResetTrans()
            End If
        ElseIf btnTransAddFlag = False Then
            If (IsCheckValidationTrans() = False) Then
                Exit Sub
            Else
                UpdateTransKernelDetails()

                ResetTrans()
            End If
        End If
    End Sub
    Private Sub UpdateTransKernelDetails()
        Try
            Dim intCount As Integer = dgvTransKernalDetails.CurrentRow.Index

            If lTranshipKernal = cmbTranshipKernal.Text And lLoadTrans = cmbLoadTrans.Text Then

                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransKernelStorage").Value = cmbTranshipKernal.Text
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransLoc").Value = cmbLoadTrans.Text
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransQty").Value = Me.txtTransQty.Text

                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransKernalDetails.Rows(intCount).Cells("dgclTransMonthtodate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransKernalDetails.Rows(intCount).Cells("dgclTransMonthtodate").Value = DBNull.Value
                End If

                dgvTransKernalDetails.Rows(intCount).Cells("TransKernelStorageID").Value = cmbTranshipKernal.SelectedValue.ToString  'lTransTankID
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransferLocID").Value = cmbLoadTrans.SelectedValue.ToString

                ''''''''''''''''''''For Remarks''''''''''''''''''''''''''''''''''''''
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim
                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                '' btnAddTrans.Text = "Add"
                btnTransAddFlag = True
                'clear()

            ElseIf Not LocationExistTrans(cmbLoadTrans.Text, cmbTranshipKernal.Text, CPODate) Then

                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransKernelStorage").Value = cmbTranshipKernal.Text
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransLoc").Value = cmbLoadTrans.Text
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransQty").Value = Me.txtTransQty.Text

                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransKernalDetails.Rows(intCount).Cells("dgclTransMonthtodate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransKernalDetails.Rows(intCount).Cells("dgclTransMonthtodate").Value = DBNull.Value
                End If

                dgvTransKernalDetails.Rows(intCount).Cells("TransKernelStorageID").Value = cmbTranshipKernal.SelectedValue.ToString  'lTransTankID
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransferLocID").Value = cmbLoadTrans.SelectedValue.ToString
                ''''''''''''''''''''For Remarks''''''''''''''''''''''''''''''''''''''
                dgvTransKernalDetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim
                If GlobalPPT.strLang = "en" Then
                    btnAdd.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAdd.Text = "Menambahkan"
                End If
                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                '' MessageBox.Show("Sorry this Loading Location ,Transshipment Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        'If cmbTranshipKernal.SelectedIndex = 0 Then
        '    MessageBox.Show("This Field is required", "Tranship Kernel")
        '    cmbTranshipKernal.Focus()
        '    Exit Sub
        'End If
        'If cmbLoadTrans.SelectedIndex = 0 Then
        '    MessageBox.Show("This Field is required", "Load Tranship ")
        '    cmbLoadTrans.Focus()
        '    Exit Sub
        'End If
        ' TransferQtyCheck()
        If IsCheckValidationTrans() = False Then
            Exit Sub
        End If

        AddTrans_Clicked()
        ProductionTodayCalculation()
    End Sub

    Private Sub dgvTransKernalDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransKernalDetails.CellDoubleClick

        BindDgvTransKernelDetails()
       
    End Sub
    'Private Sub btnLoadReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ResetLoad()
    'End Sub
    Private Sub btnTransReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransReset.Click
        ResetTrans()
    End Sub
    Private Sub dgvKernelDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelDetails.CellDoubleClick

        BindDgvKernalDetails()
        
    End Sub


    Private Sub LoadTankMonthtoDate()

        If cmbTransferKernal.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsLoadMonthTodate As New DataSet
            txtLoadMonthToDate.Text = ""
            txtLoadQty.Text = ""
            LoadMonthCount = 0

            Dim objCPOPPT As New KernalProductionPPT
            objCPOPPT.KernalID = cmbTransferKernal.SelectedValue.ToString
            objCPOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.KernalDate = dtpKernalDate.Value
            dsLoadMonthTodate = KernalProductionBOL.CPOGetLoadingCPOMonthtodate(objCPOPPT)

            If dsLoadMonthTodate.Tables(0).Rows.Count <> 0 Then
                lLoadMonthToDate = Val(dsLoadMonthTodate.Tables(0).Rows(0).Item("MonthTodate").ToString)
            End If
            LoadMonthCount = dsLoadMonthTodate.Tables(1).Rows(0).Item("LoadMonthCount").ToString

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

        If cmbTranshipKernal.SelectedIndex <> 0 And cmbLoadTrans.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsTransMonthTodate As New DataSet
            txtTransMonthToDate.Text = ""
            txtTransQty.Text = ""
            TransMonthCount = 0
            Dim objCPOPPT As New CPOProductionPPT
            objCPOPPT.TankID = cmbTranshipKernal.SelectedValue.ToString
            objCPOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOPPT.CPODate = dtpKernalDate.Value
            dsTransMonthTodate = CPOProductionBOL.CPOGetTranshipCPOMonthtodate(objCPOPPT)

            If dsTransMonthTodate.Tables(0).Rows.Count <> 0 Then
                lTransMonthToDate = Val(dsTransMonthTodate.Tables(0).Rows(0).Item("MonthTodate").ToString)
            End If
            TransMonthCount = dsTransMonthTodate.Tables(1).Rows(0).Item("TransMonthCount").ToString


            If TransMonthCount = 0 Or (TransMonthCount = 1 And btnTransAddFlag = False And SaveFlag = False) Then
                txtTransMonthToDate.Enabled = True
            Else
                txtTransMonthToDate.Enabled = False
            End If
        Else
            txtTransMonthToDate.Text = ""
            txtTransMonthToDate.Enabled = True
        End If

    End Sub

    'Private Sub CPOProductionMonthYearSelect()

    '    Dim objCPOPPT As New KernalProductionPPT
    '    objCPOPPT.CropYieldID = lCropYieldID
    '    objCPOPPT.KernalDate = dtpKernalDate.Value
    '    Dim DsMonthYearValue As New DataSet
    '    txtProductionMonth.Text = ""
    '    txtProductionYear.Text = ""
    '    DsMonthYearValue = KernalProductionBOL.CPOProductionMonthYeartodate(objCPOPPT)

    '    If DsMonthYearValue.Tables(0).Rows.Count <> 0 Then
    '        txtProductionMonth.Text = DsMonthYearValue.Tables(0).Rows(0).Item("MonthTodate").ToString
    '    End If
    '    If DsMonthYearValue.Tables(1).Rows.Count <> 0 Then
    '        txtProductionYear.Text = DsMonthYearValue.Tables(1).Rows(0).Item("YearTodate").ToString
    '    End If

    '    If Val(txtProductionMonth.Text) <= 0 Then
    '        txtProductionMonth.Text = ""
    '        txtProductionMonth.Enabled = True
    '    Else
    '        txtProductionMonth.Enabled = False

    '    End If

    '    If Val(txtProductionYear.Text) <= 0 Then
    '        txtProductionYear.Text = ""
    '        txtProductionYear.Enabled = True
    '    Else
    '        txtProductionYear.Enabled = False

    '    End If

    'End Sub
    Private Sub ProductionTodayCalculation()
        lCurrentReadingToday = 0
        lLoadQtyToday = 0
        lPrevDayQtyLoad = 0
        lBalanceToday = 0
        If dgvKernelDetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvKernelDetails.Rows
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

        lProductionToday = (lCurrentReadingToday + lLoadQtyToday + lTotalTranshipQty) - (lBalanceToday + lPrevDayQtyLoad)
        txtProductionToday.Text = Math.Round(lProductionToday, 3)
        lPrevdayPontoonQty = 0

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

    Private Sub txtMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMoisture.KeyPress
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

    Private Sub txtBalance_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBalance.KeyDown
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

    Private Sub txtBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBalance.KeyPress
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
        lLoadQty = 0

        If dgvLoadKernalDetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvLoadKernalDetails.Rows
                If objDataGridViewRow.Cells("dgclTransferQty").Value.ToString <> String.Empty And objDataGridViewRow.Cells("KernelStorageID").Value.ToString = cmbTransferKernal.SelectedValue.ToString Then
                    lLoadQty = lLoadQty + Val(objDataGridViewRow.Cells("dgclTransferQty").Value.ToString())
                End If
            Next
        End If

        lLoadQty = lLoadQty + Val(txtLoadQty.Text) - lLoadQtyPrev


    End Sub

    Private Sub TransferQtyCheck()
        lTransferQty = 0

        If dgvTransKernalDetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvTransKernalDetails.Rows
                If objDataGridViewRow.Cells("dgclTransQty").Value.ToString <> String.Empty And objDataGridViewRow.Cells("TransKernelStorageID").Value.ToString = cmbTranshipKernal.SelectedValue.ToString Then
                    lTransferQty = lTransferQty + Val(objDataGridViewRow.Cells("dgclTransQty").Value.ToString())
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

    Private Sub txtBalance_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalance.Leave
        If Val(lblCapacityValue.Text) < Val(txtBalance.Text) Then
            DisplayInfoMessage("Msg38")
            ''MessageBox.Show("Balance B/F(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtCurrentReading_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentReading.Leave
        If Val(lblCapacityValue.Text) < Val(txtCurrentReading.Text) Then
            DisplayInfoMessage("Msg39")
            ''MessageBox.Show("Current Reading(Mt) cant be greater than Storage Tank Capacity", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub tcKernalProduction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcKernalProduction.SelectedIndexChanged
        'ResetMain()
        'Reset()
        'ResetLoad()
        'ResetTrans()
        'commented by palani
        'KernalGridViewBind()
    End Sub

    Private Sub tcKernalProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcKernalProduction.Click
       
        If (dgvKernelDetails.RowCount > 0 Or dgvLoadCPODetails.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcKernalProduction.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ResetMain()
                Reset()
                ResetLoadCPO()
                KernalGridViewBind()

            End If
        Else
            ResetMain()
            Reset()
            ResetLoadCPO()
            KernalGridViewBind()

        End If
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
            objCPOPPT.CPODate = dtpKernalDate.Value
            objCPOPPT.CropYieldID = lCropYieldID
            objCPOBOL.Delete_CPODetail(objCPOPPT)
            KernalGridViewBind()
        End If

        Reset()
        ResetMain()
          ResetLoadCPO()


    End Sub

    Private Sub StockCPOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCPOEdit.Click
        BindDgvKernalDetails()
    End Sub

    Private Sub StockCPODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCPODelete.Click

        If dgvKernelDetails.RowCount = 0 Then

            Exit Sub
        ElseIf dgvKernelDetails.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else

            DeleteMultientrydatagridStockKernel()
        End If




    End Sub

    Private Sub LoadCPOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPOEdit.Click
        BindDgvLoadKernelDetails()
    End Sub

    Private Sub LoadCPODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadCPODelete.Click
        If dgvLoadCPODetails.RowCount = 0 Then

            Exit Sub
        ElseIf dgvLoadCPODetails.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else

            DeleteMultientrydatagridLoadKernel()
        End If


    End Sub

    Private Sub TranshipEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipEdit.Click
        BindDgvTransKernelDetails()
    End Sub

    Private Sub TranshipDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipDelete.Click
        DeleteMultientrydatagridTranshipKernel()
    End Sub


    Private Sub DeleteMultientrydatagridStockKernel()

        If Not dgvKernelDetails.SelectedRows(0).Cells("dgclProdStockID").Value Is Nothing Then
            lProdStockID = dgvKernelDetails.SelectedRows(0).Cells("dgclProdStockID").Value.ToString
        Else
            lProdStockID = String.Empty
        End If

        lDelete = 0
        If lProdStockID <> "" Then
            lDelete = DeleteMultientryStockKernel.Count

            DeleteMultientryStockKernel.Insert(lDelete, lProdStockID)

            ' lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtKernalAdd.Rows.Item(dgvKernelDetails.CurrentRow.Index)
        Dr.Delete()
        dtKernalAdd.AcceptChanges()
        lProdStockID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultientrydatagridLoadKernel()

        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value Is Nothing Then
            lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value.ToString
        Else
            lProdLoadingID = String.Empty
        End If

        lDelete = 0
        If lProdLoadingID <> "" Then
            lDelete = DeleteMultientryLoadKernel.Count
            DeleteMultientryLoadKernel.Insert(lDelete, lProdLoadingID)
        End If
        Dim Dr As DataRow
        Dr = dtLoadKernelAdd.Rows.Item(dgvLoadCPODetails.CurrentRow.Index)
        Dr.Delete()
        dtLoadKernelAdd.AcceptChanges()
        lProdLoadingID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultientrydatagridTranshipKernel()

        If Not dgvTransKernalDetails.SelectedRows(0).Cells("dgclProdTranshipID").Value Is Nothing Then
            lProdTranshipID = dgvTransKernalDetails.SelectedRows(0).Cells("dgclProdTranshipID").Value.ToString
        Else
            lProdTranshipID = String.Empty
        End If



        lDelete = 0
        If lProdTranshipID <> "" Then
            lDelete = DeleteMultientryTransKernel.Count
            DeleteMultientryTransKernel.Insert(lDelete, lProdTranshipID)
        End If
        Dim Dr As DataRow
        Dr = dtTransKernelAdd.Rows.Item(dgvTransKernalDetails.CurrentRow.Index)
        Dr.Delete()
        dtTransKernelAdd.AcceptChanges()
        lProdTranshipID = ""
        ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultiEntryRecordsStockKernel()
        Dim objCPOProductionPPT As New CPOProductionPPT

        lDelete = DeleteMultientryStockKernel.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdStockID = DeleteMultientryStockKernel(lDelete - 1)

            Dim IntProdStockDelete As New Integer
            IntProdStockDelete = CPOProductionBOL.DeleteMultiEntryProdStock(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteMultiEntryRecordsLoadingKernel()
        Dim objCPOProductionPPT As New CPOProductionPPT

        lDelete = DeleteMultientryLoadKernel.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdLoadingID = DeleteMultientryLoadKernel(lDelete - 1)

            Dim IntProdLoadingDelete As New Integer
            IntProdLoadingDelete = CPOProductionBOL.DeleteMultiEntryProdLoading(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteMultiEntryRecordsTranshipKernel()
        Dim objCPOProductionPPT As New CPOProductionPPT
        lDelete = DeleteMultientryTransKernel.Count

        While (lDelete > 0)

            objCPOProductionPPT.ProdTranshipID = DeleteMultientryTransKernel(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = CPOProductionBOL.DeleteMultiEntryProdTranship(objCPOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub grpTranshipKernelRecords_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpTranshipKernelRecords.Enter

    End Sub

    Private Sub btnLoadAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAdd.Click
        AddLoadCPO_Clicked()
        ProductionTodayCalculation()
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
        If txtLoadPrevDayReading.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg161")
            txtLoadPrevDayReading.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub AddLoadCPODetail()

        Dim intRowcount As Integer = dtLoadKernelAdd.Rows.Count
        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL
        If Not LocationExist(cbLoading.Text, cmbLoadTrans.Text, dtpKernalDate.Value) Then 'Location, Tank Validation 


            rowLoadKernelAdd = dtLoadKernelAdd.NewRow()
            If intRowcount = 0 Then
                Try

                    columnLoadKernelAdd = New DataColumn("LoadLocation", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadCtReading", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadPrevDayReading", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)
                    columnLoadKernelAdd = New DataColumn("ProdLoadID", System.Type.[GetType]("System.String"))
                    dtLoadKernelAdd.Columns.Add(columnLoadKernelAdd)

                Catch ex As Exception
                End Try

                rowLoadKernelAdd("LoadLocation") = Me.cbLoading.Text
                rowLoadKernelAdd("LoadCtReading") = Me.txtLoadCtReading.Text
                rowLoadKernelAdd("LoadPrevDayReading") = txtLoadPrevDayReading.Text
                rowLoadKernelAdd("LoadLocationID") = cbLoading.SelectedValue.ToString
                rowLoadKernelAdd("LoadRemarks") = txtLoadCPORemarks.Text.Trim
                rowLoadKernelAdd("ProdLoadID") = ""

                dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)
                dtLoadAddFlag = True


            Else

                rowLoadKernelAdd("LoadLocation") = Me.cbLoading.Text
                rowLoadKernelAdd("LoadCtReading") = Me.txtLoadCtReading.Text
                rowLoadKernelAdd("LoadPrevDayReading") = txtLoadPrevDayReading.Text
                rowLoadKernelAdd("LoadLocationID") = cbLoading.SelectedValue.ToString
                rowLoadKernelAdd("LoadRemarks") = txtLoadCPORemarks.Text.Trim
                rowLoadKernelAdd("ProdLoadID") = ""
                dtLoadKernelAdd.Rows.InsertAt(rowLoadKernelAdd, intRowcount)

            End If
        Else
            DisplayInfoMessage("Msg37")
        End If

        With dgvLoadCPODetails
            .DataSource = dtLoadKernelAdd
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

        ElseIf Not LocationExist(cbLoading.Text, cmbLoadTrans.Text, dtpKernalDate.Value) Then
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

    'Private Sub BindDgvLoadCPODetails()

    '    If dgvLoadCPODetails.Rows.Count > 0 Then
    '        If GlobalPPT.strLang = "en" Then
    '            btnLoadAdd.Text = "Update"
    '        ElseIf GlobalPPT.strLang = "ms" Then
    '            btnLoadAdd.Text = "Memperbarui"
    '        End If
    '        LbtnCPOKLoadadd = False

    '        cbLoading.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
    '        lLoadLocation = dgvLoadCPODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
    '        lLoadingLocationID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString()

    '        If Not dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value Is DBNull.Value Then
    '            lProdLoadingID = dgvLoadCPODetails.SelectedRows(0).Cells("dgclProdLoadID").Value
    '        Else
    '            lProdLoadingID = Nothing
    '        End If

    '        Me.txtLoadCtReading.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadCtReading").Value.ToString()
    '        Me.txtLoadPrevDayReading.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclPrevDayReadnig").Value.ToString()
    '        txtLoadCPORemarks.Text = dgvLoadCPODetails.SelectedRows(0).Cells("dgclLoadRemarks").Value.ToString()


    '    End If

    'End Sub
    Private Sub CPOProductionTranshipqtySelect()
        Dim ds As New DataSet
        Dim objCPOPPT As New CPOProductionPPT
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

    Private Sub dgvLoadCPODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadCPODetails.CellDoubleClick
        BindDgvLoadKernelDetails()
    End Sub

    Private Sub lblCapacityIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCapacityIn.Click

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


End Class