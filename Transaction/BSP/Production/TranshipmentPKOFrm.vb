Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class TranshipmentPKOFrm

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

    '' Trans PKO'''
    Public btnTransAddFlag As Boolean = True
    Dim columnTransPKOAdd As DataColumn
    Dim rowTransPKOAdd As DataRow
    Dim dtTransPKOAdd As New DataTable("todgvTransPKOAdd")
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
    Public PKODate As Date
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
    Dim DeleteMultientryStockPKO As New ArrayList
    Dim DeleteMultientryLoadPKO As New ArrayList
    Dim DeleteMultientryTransPKO As New ArrayList
    Dim lDelete As Integer
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TranshipmentPKOFrm))

    Private Sub TranshipmentPKOFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSaveAll.Enabled = True And dgvTransPKODetails.RowCount > 0 And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M422"

            End If
        End If
    End Sub

    Private Sub TranshipmentPKOFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TranshipmentPKOFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        'Dim ToDate As Date = Date.Today
        ''btnSaveAll.Enabled = True
        'dtpPKODate.Value = ToDate
        'dtpPKOViewDate.Value = Date.Today
        'dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'edit by suraya 14092012
        dtpPKOViewDate.Format = DateTimePickerFormat.Custom '
        dtpPKOViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)

        dtpPKODate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpPKODate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpPKODate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpPKODate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpPKODate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        Dim ToDate As Date = dtpPKODate.Value
        dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        Dim objPKOPPT As New TranshipmentPKOPPT
        Dim dsCrop As New DataSet
        dsCrop = TranshipmentPKOBOL.ProductionCropYieldIDSelect(objPKOPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for PKO, Please insert the record in General Crop Yield")
        End If
        tcTransPKO.SelectedTab = tpPKOView
        loadCmbStorage()
        loadCmbLocation()

        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKODate)
        'FormatDateTimePicker(dtpPKODate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)
        'FormatDateTimePicker(dtpPKOViewDate)


        dtpPKOViewDate.Enabled = False
        lCropYieldCode = "PKO"


        GetCropYieldID()
        objPKOPPT.CropYieldID = lCropYieldID
        ResetMain()
        Reset()
        'PKOGetMonthYearQty()
        ''PKOGetTodayQty()
        'PKOGetLoadTransMonthQty()

        'UpdateTankMasterBFQty()

        PKOGridViewBind()
        dtpPKODate.Focus()


    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tcTransPKO.TabPages("tpPKOSave").Text = rm.GetString("ttcTransPKO.TabPages(tpPKOSave).Text")
            'tcTransPKO.TabPages("tpPKOView").Text = rm.GetString("ttcTransPKO.TabPages(tpPKOView).Text")



            'chkPKODate.Text = rm.GetString("Date")

            ''  grpTransPKO.Text = rm.GetString("LoadPKO")
            'grpTransPKO.Text = rm.GetString("TransPKO")
            ''  grpTransPKORecords.Text = rm.GetString("LoadPKORecords")
            'grpTransPKORecords.Text = rm.GetString("TransPKORecords")


            'PnlSearch.CaptionText = rm.GetString("SearchTransPKO")

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




            'dgvTransPKODetails.Columns("dgclTransStorageNo").HeaderText = rm.GetString("Storage")
            'dgvTransPKODetails.Columns("dgclTranshipLoad").HeaderText = rm.GetString("Transshipment")
            'dgvTransPKODetails.Columns("dgclTranshipQuantity").HeaderText = rm.GetString("Quantity")
            'dgvTransPKODetails.Columns("dgclTransMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvTransPKODetails.Columns("dgclTransRemarks").HeaderText = rm.GetString("Remarks")


            ''lblProStorage.Text = rm.GetString("Storage")
            ''lblProToday.Text = rm.GetString("Today")
            ''lblProMonthdate.Text = rm.GetString("Month Todate")
            ''lblProYeardate.Text = rm.GetString("YearTodate")

            btnSaveAll.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddTrans.Text = rm.GetString("Add")
            btnAddTrans.Text = rm.GetString("Add")

            'dgvTransPKOView.Columns("gvPKODate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")


        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub PKOGetLoadTransMonthQty()
        Try
            Dim objPKOPPT As New TranshipmentPKOPPT
            Dim dsTransLoad As DataSet
            objPKOPPT.CropYieldID = lCropYieldID
            objPKOPPT.PKODate = dtpPKODate.Value
            dsTransLoad = TranshipmentPKOBOL.PKOGetLoadTransMonthQty(objPKOPPT)
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

            dsTransTankNo = TranshipmentPKOBOL.loadCmbStorage("PKO")

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

            'Transhipment PKO Combo
            cmbLoadTrans.DataSource = Nothing
            Dim dsLoadTrans As DataSet
            dsLoadTrans = TranshipmentPKOBOL.loadCmbLocationPKO()
            'Location PKO Combo
            cmbLoadTrans.DataSource = dsLoadTrans.Tables(0)

            cmbLoadTrans.DisplayMember = "LoadingLocationCode"
            cmbLoadTrans.ValueMember = "LoadingLocationID"

            'Trans PKO
            cmbTransTank.DataSource = Nothing
            Dim dsTransTank As DataSet
            dsTransTank = TranshipmentPKOBOL.loadCmbLocationPKO()

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
            Dim objPKOPPT As New TranshipmentPKOPPT
            objPKOPPT.CropYieldCode = lCropYieldCode
            If objPKOPPT.CropYieldCode <> String.Empty Then
                dsCrop = TranshipmentPKOBOL.GetCropYieldID(objPKOPPT)
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
            Dim objPKOPPT As New TranshipmentPKOPPT
            objPKOPPT.TankID = lTankID
            If objPKOPPT.TankID <> String.Empty Then
                dsCropID = TranshipmentPKOBOL.GetCropYield(objPKOPPT)
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
        'If dtpPKODate.Text.Trim = String.Empty Then
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
        ''''For Stock PKO
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
        ' PKOGetLoadTransMonthQty()
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

        dtpPKODate.Enabled = True

        '''' For Trans PKO

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
        dtpPKOViewDate.Enabled = False
        chkPKODate.Checked = False

        '''''For Production PKO
        'Dim ToDate As Date = Date.Today
        'dtpPKODate.Value = ToDate
        'dtpPKOViewDate.Value = Date.Today
        'dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpPKODate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpPKOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpPKOViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)


        ClearGridView(dgvTransPKODetails)

        DeleteMultientryTransPKO.Clear()


        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''
        MonthCount = False
        YearCount = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If dgvTransPKOView.Rows.Count > 0 Then

            ''''For  Transhipment PKO''''''
            txtTransMonthToDate.Enabled = False
        Else

            ''''For  Transhipment PKO''''''
            txtTransMonthToDate.Enabled = True
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub PKOGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objPKOPPT As New TranshipmentPKOPPT
            objPKOPPT.PKODate = dtpPKODate.Value
            'loadCmbStorage()
            With objPKOPPT
                If chkPKODate.Checked = True Then
                    dtpPKOViewDate.Enabled = True
                    .PKODate = dtpPKOViewDate.Value 'Format(Me.dtpPKOViewDate.Value, "MM/dd/yyyy")

                    dtpPKOViewDate.MinDate = GlobalPPT.FiscalYearFromDate
                    dtpPKOViewDate.MaxDate = GlobalPPT.FiscalYearToDate
                    Dim TempDate As Date = dtpPKOViewDate.Value
                    Dim NowDate As Date = Now()
                    If Now() >= GlobalPPT.FiscalYearFromDate And dtpPKOViewDate.Value <= GlobalPPT.FiscalYearFromDate Then
                        dtpPKOViewDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
                    End If

                    Dim ToDate As Date = dtpPKOViewDate.Value
                    dtpPKOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
                Else
                    dtpPKOViewDate.Enabled = False
                    .PKODate = Nothing
                End If
                ' .TankNo = cmbViewTankNo.Text

                'If .TankNo = "--Select All--" Then
                '    .TankNo = ""
                'Else
                '    .TankNo = cmbViewTankNo.Text
                'End If
            End With
            objPKOPPT.CropYieldID = lCropYieldID
            dt = TranshipmentPKOBOL.GetPKODetails(objPKOPPT)
            'If dt.TableName.Count <> 0 Then
            If dt.Rows.Count <> 0 Then
                dgvTransPKOView.AutoGenerateColumns = False
                Me.dgvTransPKOView.DataSource = dt
                'Dim i As Integer = dgvTransPKOView.Rows.Count
                'lLoadMonthToDate = dgvTransPKOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value
                'lTransMonthToDate = dgvTransPKOView.Rows(i - 1).Cells("gvTransMonthToDate").Value
                'MsgBox(dgvTransPKOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value)
            Else
                ClearGridView(dgvTransPKOView) '''''clear the records from grid view
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

    Private Sub UpdatePKOView()

        If dgvTransPKOView.Rows.Count > 0 Then

            EditPKOView()
            dtpPKODate.Enabled = False



            'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        Else
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditPKOView()

        Try

            Me.cmsPKO.Visible = False
            Dim objPKOPPT As New TranshipmentPKOPPT
            Dim objPKOBOL As New TranshipmentPKOBOL
            Dim dt As New DataTable

            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If

            lresetLoad = True
            lresetTrans = True

            objPKOPPT.CropYieldID = lCropYieldID
            '  objPKOPPT.ProductionID = lProductionID
            Dim str As String = CDate(Me.dgvTransPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

            '            objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)
            objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


            dtpPKODate.Value = objPKOPPT.PKODate
            'PKOGetMonthYearQty()
            'PKOGetTodayQty()
            'PKOGetLoadTransMonthQty()


            '''' For Trans PKO'''
            dtTransPKOAdd = TranshipmentPKOBOL.GetPKOAddTransInfo(objPKOPPT)
            dgvTransPKODetails.AutoGenerateColumns = False
            SaveFlag = False
            dgvTransPKODetails.DataSource = dtTransPKOAdd
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            PKOGridViewBind()
            Me.tcTransPKO.SelectedTab = tpPKOSave
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
        If dgvTransPKOView.RowCount > 0 Then


            rowid = dgvTransPKOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then


                Dim objPKOPPT As New TranshipmentPKOPPT
                Dim objPKOBOL As New TranshipmentPKOBOL
                Dim str As String = CDate(Me.dgvTransPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                '            objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objPKOPPT.CropYieldID = lCropYieldID
                dtpPKODate.Value = objPKOPPT.PKODate
                objEditDuplicateSearchRecord = objPKOBOL.TransSearchDateCheck(objPKOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objPKOBOL.EditDateCheck(objPKOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdatePKOView()
                        btnSaveAll.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdatePKOView()
                        btnSaveAll.Enabled = True
                        btnDeleteAll.Enabled = True
                    End If
                Else
                    DisplayInfoMessage("Msg92")
                    ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowid = 1
                    UpdatePKOView()
                End If
            Else
                DisplayInfoMessage("Msg92")
                ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UpdatePKOView()
            End If
        End If
    End Sub


    Public Sub GetTankID(ByVal lTankNo As String)
        Try
            Dim dsLoad As DataSet
            Dim objPKOPPT As New TranshipmentPKOPPT
            Dim objPKOBOL As New TranshipmentPKOBOL
            objPKOPPT.TankNo = lTankNo
            dsLoad = TranshipmentPKOBOL.GetTankID(objPKOPPT)
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
            Dim objPKOPPT As New TranshipmentPKOPPT
            objPKOPPT.Descp = lLocation
            dsLocation = TranshipmentPKOBOL.GetLocationID(objPKOPPT)
            If dsLocation.Tables.Count <> 0 Then
                If dsLocation.Tables(0).Rows.Count <> 0 Then
                    lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                    lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgvTransPKOView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdatePKOView()
            End If
        End If


    End Sub

    Private Sub DeletePKOVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))

        Me.cmsPKO.Visible = False

        Dim objPKOPPT As New TranshipmentPKOPPT
        Dim objPKOBOL As New TranshipmentPKOBOL
        ' Dim dt As New DataTable
        If dgvTransPKOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim str As String = CDate(Me.dgvTransPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                '                objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                objPKOPPT.CropYieldID = lCropYieldID
                objPKOBOL.Delete_PKODetail(objPKOPPT)
                PKOGridViewBind()
                'Else
                '    MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvTransPKOView.RowCount > 0 Then


            rowid = dgvTransPKOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objPKOPPT As New TranshipmentPKOPPT
                Dim objPKOBOL As New TranshipmentPKOBOL
                Dim str As String = CDate(Me.dgvTransPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                '            objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(Str, culture, DateTimeStyles.NoCurrentDateDefault)

                objPKOPPT.CropYieldID = lCropYieldID
                dtpPKODate.Value = objPKOPPT.PKODate

                objDeleteDuplicateSearchRecord = objPKOBOL.TransSearchDateCheck(objPKOPPT)
                If objDeleteDuplicateSearchRecord = 0 Then
                    objDeleteDuplicateRecord = objPKOBOL.EditDateCheck(objPKOPPT)


                    If objDeleteDuplicateRecord = 1 Then
                        DeletePKOVIew()
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
        tcTransPKO.SelectedTab = tpPKOSave
        ResetTrans()
    End Sub

    Private Sub TransTankMonthtoDate()
        If cmbTransTank.SelectedIndex <> 0 And cmbLoadTrans.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsTransMonthTodate As New DataSet
            txtTransMonthToDate.Text = ""
            txtTransQty.Text = ""
            TransMonthCount = 0
            Dim objPKOPPT As New TranshipmentPKOPPT
            objPKOPPT.TankID = cmbTransTank.SelectedValue.ToString
            objPKOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
            objPKOPPT.CropYieldID = lCropYieldID
            objPKOPPT.PKODate = dtpPKODate.Value
            dsTransMonthTodate = TranshipmentPKOBOL.PKOGetTranshipPKOMonthtodate(objPKOPPT)

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
        'Dim objPKOPPT As New PKOProductionPPT
        'lTransTankID = lTankID

        'objPKOPPT.TankID = cmbTransTank.SelectedValue.ToString
        'objPKOPPT.ProductionID = lProdIdNew
        'Dim objPKOBOL As New PKOProductionBOL
        'objPKOPPT.CropYieldID = lCropYieldID
        'objPKOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
        'objPKOPPT.PKODate = dtpPKODate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objPKOBOL.DuplicateTransLocationFirstCheck(objPKOPPT)
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
        '    dsCrop = PKOProductionBOL.PKOGetTransVsLocMonthQty(objPKOPPT)
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
            'Dim objPKOPPT As New PKOProductionPPT
            'lTransLocationID = lLocationID
            ''lblTransDescription.Text = lLocationDesc
            'objPKOPPT.TransLocationID = lLocationID
            'objPKOPPT.TankID = cmbLoadTrans.SelectedValue.ToString
            'objPKOPPT.PKODate = dtpPKODate.Value
            'Dim objPKOBOL As New PKOProductionBOL

            'objPKOPPT.ProductionID = lProdIdNew
            'objPKOPPT.CropYieldID = lCropYieldID
            'objPKOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString

            'If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
            '    Dim objCheckDuplicateLoadLocation As Object = 0
            '    objCheckDuplicateLoadLocation = objPKOBOL.DuplicateTransLocationFirstCheck(objPKOPPT)
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
            '    dsCrop = PKOProductionBOL.PKOGetTransVsLocMonthQty(objPKOPPT)
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

        If dgvTransPKODetails.RowCount > 0 And btnSaveAll.Enabled = True Then
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
        If chkPKODate.Checked = False Then
            DisplayInfoMessage("Msg32")
            ''MsgBox("Please Enter Criteria to Search!")
            PKOGridViewBind()

        Else
            PKOGridViewBind()
            If dgvTransPKOView.RowCount = 0 Then
                DisplayInfoMessage("Msg33")
                '' MsgBox("No record(s) found matching your search criteria.")
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
    Private Sub dgvTransPKOView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransPKOView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSaveAll.Enabled = True
            Else
                btnSaveAll.Enabled = False
                Exit Sub
            End If
        End If
        If dgvTransPKOView.RowCount > 0 Then


            If (e.RowIndex = 0) Then
                rowid = e.RowIndex

                Dim objPKOPPT As New TranshipmentPKOPPT
                Dim objPKOBOL As New TranshipmentPKOBOL
                Dim str As String = CDate(Me.dgvTransPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                '            objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                objPKOPPT.CropYieldID = lCropYieldID
                dtpPKODate.Value = objPKOPPT.PKODate

                objEditDuplicateSearchRecord = objPKOBOL.TransSearchDateCheck(objPKOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objPKOBOL.EditDateCheck(objPKOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdatePKOView()
                        btnSaveAll.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdatePKOView()
                        btnSaveAll.Enabled = True
                        btnDeleteAll.Enabled = True
                    End If
                Else
                    DisplayInfoMessage("Msg92")
                    ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowid = 1
                    UpdatePKOView()
                End If

            Else
                DisplayInfoMessage("Msg92")
                ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                rowid = e.RowIndex
                UpdatePKOView()
            End If

        End If
        ' End If


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
    Private Sub SaveTransPKODetail()
        Try
            Dim objPKOPPT As New TranshipmentPKOPPT
            Dim objPKOBOL As New TranshipmentPKOBOL

            Dim intRowcount As Integer = dtTransPKOAdd.Rows.Count

            'PKOGetTodayQty()

            If Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, dtpPKODate.Value) Then 'Location, Tank Validation 

                'objPKOPPT.CropYieldID = lCropYieldID
                ''Dim objCheckDuplicateRecord As Object = 0
                'objPKOPPT.PKODate = dtpPKODate.Value
                ''objCheckDuplicateRecord = objPKOBOL.DuplicateDateCheck(objPKOPPT)


                'objPKOPPT.LoadingLocationID = cmbLoadTrans.SelectedValue.ToString
                'objPKOPPT.TankID = cmbTransTank.SelectedValue.ToString


                'Dim objCheckDuplicateLoadLocation As Object = 0
                'objCheckDuplicateLoadLocation = objPKOBOL.DuplicateTransLocationCheck(objPKOPPT)
                'If objCheckDuplicateLoadLocation = 0 Then 'objCheckDuplicateRecord = 0 And objCheckDuplicateLoadLocation = 0 And objCheckDuplicateTank = 0 Then
                '    MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If


                rowTransPKOAdd = dtTransPKOAdd.NewRow()

                If intRowcount = 0 And dtTransAddFlag = False Then
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
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
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

                        rowTransPKOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                        rowTransPKOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
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
                        rowTransPKOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                        rowTransPKOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowTransPKOAdd("TransRemarks") = txtTransRemarks.Text.Trim
                        dtTransPKOAdd.Rows.InsertAt(rowTransPKOAdd, intRowcount)

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
                    rowTransPKOAdd("TransTankID") = cmbTransTank.SelectedValue.ToString
                    rowTransPKOAdd("TransLocationID") = cmbLoadTrans.SelectedValue.ToString

                    '''''''''''''''''''''''''''''''''''
                    '''''''''''''For Remarks
                    rowTransPKOAdd("TransRemarks") = txtTransRemarks.Text.Trim
                    dtTransPKOAdd.Rows.InsertAt(rowTransPKOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry this Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvTransPKODetails
                .DataSource = dtTransPKOAdd
                .AutoGenerateColumns = False
            End With




        Catch ex As Exception
        End Try

    End Sub


    Private Function LocationExistTrans(ByVal Location As String, ByVal TankNo As String, ByVal PKODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvTransPKODetails.Rows
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

    Private Sub UpdateTransPKODetails()
        Try
            Dim intCount As Integer = dgvTransPKODetails.CurrentRow.Index

            If lTransTank = cmbTransTank.Text And lloadTrans = cmbLoadTrans.Text Then
                ' If lTempTankNo = cmbStockTank.Text Then

                'StrAdjustDate = Me.dtpAdjustmentDate.Text
                'strAdjustmentDate = New Date(StrAdjustDate.Substring(6, 4), StrAdjustDate.Substring(3, 2), StrAdjustDate.Substring(0, 2))
                'dgvPKODetails.Rows(intCount).Cells("STAAdjustmentDate").Value = strAdjustmentDate

                dgvTransPKODetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvTransPKODetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If
                If Me.txtTransQty.Text <> Nothing Then
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If

                dgvTransPKODetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvTransPKODetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString
                dgvTransPKODetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim

                'If Me.txtMoisture.Text <> Nothing Then
                '    dgvPKODetails.Rows(intCount).Cells("dgclMoisture").Value = Me.txtMoisture.Text
                'End If

                'dgvPKODetails.Rows(intCount).Cells("dgclStockTankID").Value = lStockTankID
                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                ''btnAddTrans.Text = "Add"
                btnTransAddFlag = True
                'clear()

            ElseIf Not LocationExistTrans(cmbLoadTrans.Text, cmbTransTank.Text, PKODate) Then
                dgvTransPKODetails.Rows(intCount).Cells("dgclTransStorageNo").Value = cmbTransTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvTransPKODetails.Rows(intCount).Cells("dgclTranshipLoad").Value = cmbLoadTrans.Text
                ' End If
                If Me.txtTransQty.Text <> Nothing Then
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = Me.txtTransQty.Text
                Else
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTranshipQuantity").Value = DBNull.Value
                End If
                If Me.txtTransMonthToDate.Text <> Nothing Then
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = Me.txtTransMonthToDate.Text
                Else
                    dgvTransPKODetails.Rows(intCount).Cells("dgclTransMonthDate").Value = DBNull.Value
                End If


                dgvTransPKODetails.Rows(intCount).Cells("dgclTransStorageID").Value = cmbTransTank.SelectedValue.ToString
                dgvTransPKODetails.Rows(intCount).Cells("dgclTransStorageLocID").Value = cmbLoadTrans.SelectedValue.ToString
                dgvTransPKODetails.Rows(intCount).Cells("dgclTransRemarks").Value = txtTransRemarks.Text.Trim
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

    Private Sub BindDgvTransPKODetails()
        If dgvTransPKODetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddTrans.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddTrans.Text = "Memperbarui"
            End If
            ''Me.btnAddTrans.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddTransFlag = False

            cmbTransTank.Text = dgvTransPKODetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            lTransTank = dgvTransPKODetails.SelectedRows(0).Cells("dgclTransStorageNo").Value.ToString()
            cmbLoadTrans.Text = dgvTransPKODetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()
            lloadTrans = dgvTransPKODetails.SelectedRows(0).Cells("dgclTranshipLoad").Value.ToString()

            If Not dgvTransPKODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is DBNull.Value Then
                lProdTranshipID = dgvTransPKODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value
            Else
                lProdTranshipID = Nothing
            End If

            If Not dgvTransPKODetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtTransQty.Text = dgvTransPKODetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
                lTransferQtyPrev = dgvTransPKODetails.SelectedRows(0).Cells("dgclTranshipQuantity").Value.ToString()
            End If

            If Not dgvTransPKODetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtTransMonthToDate.Text = dgvTransPKODetails.SelectedRows(0).Cells("dgclTransMonthDate").Value.ToString()
            End If
            ' AddFlag = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Remarks Fields Add'''''''''''''''''
            txtTransRemarks.Text = dgvTransPKODetails.SelectedRows(0).Cells("dgclTransRemarks").Value.ToString()

        End If

    End Sub

    Private Sub dtpPKODate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPKODate.ValueChanged

        Dim objPKOPPT As New TranshipmentPKOPPT
        Dim objPKOBOL As New TranshipmentPKOBOL

        Dim objCheckDuplicateRecord As Object = 0
        objPKOPPT.PKODate = dtpPKODate.Value
        objPKOPPT.CropYieldID = lCropYieldID
        objCheckDuplicateRecord = objPKOBOL.DuplicateDateCheck(objPKOPPT)

        If objCheckDuplicateRecord = 0 Then

            SaveFlag = True
            'MessageBox.Show("Cannot add a Same Tank For the Date. Please try again.")
            'Exit Sub
        End If
        ' PKOProductionMonthYearSelect()
    End Sub

    Private Sub dgvTransPKOView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTransPKOView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdatePKOView()
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

                    SaveTransPKODetail()
                    'If dgvTransPKODetails.Rows.Count <> 0 Then
                    '    For Each objDataGridViewRow In dgvTransPKODetails.Rows
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

    Private Sub dgvTransPKODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransPKODetails.CellDoubleClick

        BindDgvTransPKODetails()

    End Sub

    Private Sub btnResetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetTrans.Click
        ResetTrans()
    End Sub

    Private Sub TransferQtyCheck()
        lTransferQty = 0

        If dgvTransPKODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvTransPKODetails.Rows
                If objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclTransStorageID").Value.ToString = cmbTransTank.SelectedValue.ToString Then
                    lTransferQty = lTransferQty + Val(objDataGridViewRow.Cells("dgclTranshipQuantity").Value.ToString())
                End If
            Next
        End If

        lTransferQty = lTransferQty + Val(txtTransQty.Text) - lTransferQtyPrev



    End Sub

    Private Sub tcTransPKO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransPKO.SelectedIndexChanged
        'ResetMain()
        ' Reset()
        'ResetLoad()
        ' ResetTrans()
        PKOGridViewBind()
    End Sub
    Private Sub tcTransPKO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransPKO.Click

        If dgvTransPKODetails.RowCount > 0 And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcTransPKO.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ' ResetMain()
                Reset()
                'ResetLoad()
                ResetTrans()
                PKOGridViewBind()


            End If
        Else
            'ResetMain()
            Reset()
            'ResetLoad()
            ResetTrans()
            PKOGridViewBind()


        End If
    End Sub
    Private Sub txtTransMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransMonthToDate.TextChanged
        If Val(txtTransMonthToDate.Text) = 0 Then
            txtTransMonthToDate.Text = ""
        End If
    End Sub

    Private Sub TranshipEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipEdit.Click
        BindDgvTransPKODetails()
    End Sub

    Private Sub TranshipDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipDelete.Click
        If dgvTransPKODetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvTransPKODetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridTranshipPKO()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridTranshipPKO()

        If Not dgvTransPKODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is Nothing Then
            lProdTranshipID = dgvTransPKODetails.SelectedRows(0).Cells("dgclProdTranshipID1").Value.ToString
        Else
            lProdTranshipID = String.Empty
        End If



        lDelete = 0
        If lProdTranshipID <> "" Then
            lDelete = DeleteMultientryTransPKO.Count
            DeleteMultientryTransPKO.Insert(lDelete, lProdTranshipID)
        End If
        Dim Dr As DataRow
        Dr = dtTransPKOAdd.Rows.Item(dgvTransPKODetails.CurrentRow.Index)
        Dr.Delete()
        dtTransPKOAdd.AcceptChanges()
        lProdTranshipID = ""


    End Sub

    Private Sub DeleteMultiEntryRecordsTranshipPKO()
        Dim objPKOProductionPPT As New TranshipmentPKOPPT
        lDelete = DeleteMultientryTransPKO.Count

        While (lDelete > 0)

            objPKOProductionPPT.ProdTranshipID = DeleteMultientryTransPKO(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = TranshipmentPKOBOL.DeleteMultiEntryProdTranship(objPKOProductionPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objPKOPPT As New TranshipmentPKOPPT
        Dim objPKOBOL As New TranshipmentPKOBOL
        If dgvTransPKOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                'If lProductionID <> String.Empty Then
                objPKOPPT.PKODate = dtpPKODate.Value
                objPKOPPT.CropYieldID = lCropYieldID
                objPKOBOL.Delete_PKODetail(objPKOPPT)
                PKOGridViewBind()
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
                ''MsgBox("No Record in Crop yield for PKO, Please insert the record in General Crop Yield")
                Exit Sub
            End If

            If dgvTransPKODetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If
                If SaveFlag = True Then

                    Dim objPKOPPT As New TranshipmentPKOPPT
                    Dim objPKOBOL As New TranshipmentPKOBOL
                    Dim objCheckDuplicateRecord As Object = 0
                    objPKOPPT.PKODate = dtpPKODate.Value
                    objPKOPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objPKOBOL.DuplicateDateCheck(objPKOPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    Else
                        objCompareDateCheck = objPKOBOL.CompareCPOPTransDateIsExist(objPKOPPT)
                        If objCompareDateCheck = 0 Then
                            DisplayInfoMessage("Msg26")
                            Exit Sub
                        End If
                    End If
                    ''''For Production PKO''''

                    ' Dim StrPKODate As String
                    Dim dsDetails As New DataSet
                    'PKOGetMonthYearQty()
                    'PKOGetTodayQty()
                    ' PKOGetLoadTransMonthQty()
                    objPKOPPT.CropYieldID = lCropYieldID

                    'objPKOPPT.PKODate = Format(txtDate.Text, "dd/MM/yyyy")
                    objPKOPPT.PKODate = dtpPKODate.Value 'Format(dtpPKODate.Value, "MM/dd/yyyy")
                    ' dsID = TranshipmentPKOBOL.savePKOProduction(objPKOPPT)
                    'If dsID.Tables.Count <> 0 Then
                    '    If dsID.Tables(0).Rows.Count <> 0 Then
                    '        lProductionID = dsID.Tables(0).Rows(0).Item("ProductionID")
                    '    Else
                    '        lProductionID = Nothing
                    '    End If
                    'End If

                    'objPKOPPT.ProductionID = lProductionID


                    For Each DataGridViewRowTrans In dgvTransPKODetails.Rows

                        ''''For Trans PKO''''''''

                        If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objPKOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                        Else
                            objPKOPPT.TransTankID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                            objPKOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                        Else
                            objPKOPPT.TransLocationID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                            objPKOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objPKOPPT.TransQty = 0.0
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value Then
                            'Dim lTransMonthdate As String
                            'Dim lTransQty As String
                            objPKOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                            'lTransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                            'objPKOPPT.TransMonthToDate = Val(lTransMonthdate) ''''+ Val(lTransQty)
                        Else
                            objPKOPPT.TransMonthToDate = 0.0
                            'objPKOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTransQuantity").Value
                        End If
                        '''''''For Remarks'''''''''''''''''''''''''
                        objPKOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''
                        objPKOPPT.CropYieldID = lCropYieldID
                        TranshipmentPKOBOL.savePKOTransProduction(objPKOPPT)
                        '   PKOProductionBOL.UpdateTankMasterBFQty(objPKOPPT)
                    Next


                    PKOGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()

                    ResetTrans()

                    'SaveFlag = False
                Else

                    Dim objPKOPPT As New TranshipmentPKOPPT
                    Dim objPKOBOL As New TranshipmentPKOBOL
                    'Dim StrPKODate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvPKODetails.Rows

                    objPKOPPT.CropYieldID = lCropYieldID
                    'PKOGetMonthYearQty()
                    'PKOGetTodayQty()
                    'PKOGetLoadTransMonthQty()

                    objPKOPPT.PKODate = dtpPKODate.Value

                    'Format(dtpPKODate.Value, "MM/dd/yyyy")
                    ' objPKOPPT.ProductionID = DataGridViewRowMain.Cells("dgclProductionID").Value.ToString
                    'If DataGridViewRowMain.Cells("dgclProductionID").Value.ToString = String.Empty Then
                    'If lProdIdNew = String.Empty Then
                    '    PKOProductionBOL.savePKOProduction(objPKOPPT)
                    'Else
                    '    PKOProductionBOL.UpdatePKOProduction(objPKOPPT)
                    'End If

                    ' Next


                    For Each DataGridViewRowTrans In dgvTransPKODetails.Rows

                        ''''For Trans PKO''''''''

                        If Not DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objPKOPPT.TransTankID = DataGridViewRowTrans.Cells("dgclTransStorageID").Value.ToString()
                        Else
                            objPKOPPT.TransTankID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString() Is DBNull.Value Then
                            objPKOPPT.TransLocationID = DataGridViewRowTrans.Cells("dgclTransStorageLocID").Value.ToString()
                        Else
                            objPKOPPT.TransLocationID = Nothing
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then
                            objPKOPPT.TransQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objPKOPPT.TransQty = 0.0
                        End If
                        If Not DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value Is DBNull.Value Then 'DataGridViewRowTrans.Cells("dgclTransMonthDate").Value Is DBNull.Value And 
                            Dim lLoadMonthdate As String
                            Dim lLoadQty As String
                            lLoadMonthdate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value.ToString()
                            lLoadQty = DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value.ToString()
                            objPKOPPT.TransMonthToDate = Val(lLoadMonthdate) '+ Val(lLoadQty)

                            'objPKOPPT.TransMonthToDate = DataGridViewRowTrans.Cells("dgclTransMonthDate").Value + DataGridViewRowTrans.Cells("dgclTranshipQuantity").Value
                        Else
                            objPKOPPT.TransMonthToDate = 0.0
                        End If

                        objPKOPPT.CropYieldID = lCropYieldID

                        '''''''''''''''''''''''''''''''''''''''
                        ''''For Remarks
                        objPKOPPT.TransRemarks = DataGridViewRowTrans.Cells("dgclTransRemarks").Value.ToString


                        If Not (DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value) Then
                            objPKOPPT.ProdTranshipID = DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value
                        Else
                            objPKOPPT.ProdTranshipID = String.Empty
                        End If

                        If DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is Nothing Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value Is DBNull.Value Or DataGridViewRowTrans.Cells("dgclProdTranshipID1").Value.ToString = String.Empty Then
                            TranshipmentPKOBOL.savePKOTransProduction(objPKOPPT)
                        Else
                            TranshipmentPKOBOL.UpdatePKOTransProduction(objPKOPPT)
                        End If

                    Next


                    DeleteMultiEntryRecordsTranshipPKO()

                    ' PKOProductionBOL.UpdateTankMasterBFQty(objPKOPPT)
                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    PKOGridViewBind()
                    Reset()


                    ResetTrans()
                    SaveFlag = True

                End If
                ClearGridView(dgvTransPKODetails)

            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objPKOPPT As New TranshipmentPKOPPT
            Dim objPKOBOL As New TranshipmentPKOBOL

            objPKOPPT.PKODate = dtpPKODate.Value
            objPKOPPT.CropYieldID = lCropYieldID
            ' objPKOBOL.Delete_PKODetail(objPKOPPT)
            PKOGridViewBind()
        End Try
    End Sub

    Private Sub dgvTransPKOView_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdatePKOView()
            End If
        End If
    End Sub

End Class