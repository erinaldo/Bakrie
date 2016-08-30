Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class LoadingPKOFrm

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


    ''Load PKO'''
    Public btnAddLoadFlag As Boolean = True
    Dim columnLoadPKOAdd As DataColumn
    Dim rowLoadPKOAdd As DataRow
    Dim dtLoadPKOAdd As New DataTable("todgvLoadCPOAdd")
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

    Dim DeleteMultientryLoadPKO As New ArrayList

    Dim lDelete As Integer
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LoadingPKOFrm))

    Private Sub LoadingPKOFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSave.Enabled = True And dgvLoadPKODetails.RowCount > 0 And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M421"

            End If
        End If
    End Sub

    Private Sub LoadingPKOFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LoadingPKOFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)

        'Dim ToDate As Date = Date.Today
        'dtpPKODate.Value = ToDate
        'dtpPKOViewDate.Value = Date.Today
        'dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        dtpPKODate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpPKODate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpPKODate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpPKODate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpPKODate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        Dim ToDate As Date = dtpPKODate.Value
        dtpPKODate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        Dim objPKOPPT As New LoadingPKOPPT
        Dim dsCrop As New DataSet

        dsCrop = LoadingPKOBOL.ProductionCropYieldIDSelect(objPKOPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for PKO, Please insert the record in General Crop Yield")
        End If
        tcLoadingPKO.SelectedTab = tpPKOView

        loadCmbStorage()
        loadCmbLocation()

        dtpPKOViewDate.Enabled = False
        lCropYieldCode = "PKO"

        GetCropYieldID()
        objPKOPPT.CropYieldID = lCropYieldID

        Reset()

        PKOGridViewBind()
        dtpPKODate.Focus()


    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            'tcLoadingPKO.TabPages("tpPKOSave").Text = rm.GetString("ttcLoadingPKO.TabPages(tpPKOSave).Text")
            'tcLoadingPKO.TabPages("tpPKOView").Text = rm.GetString("ttcLoadingPKO.TabPages(tpPKOView).Text")

            'chkPKODate.Text = rm.GetString("Date")
            'grpLoadPKO.Text = rm.GetString("LoadPKO")

            'grpLoadPKORecords.Text = rm.GetString("LoadPKORecords")
            'PnlSearch.CaptionText = rm.GetString("SearchLoadingPKO")

            'dgvLoadPKODetails.Columns("dgclLoadStorageNo").HeaderText = rm.GetString("Storage")
            'dgvLoadPKODetails.Columns("dgclToLoading").HeaderText = rm.GetString("To Loading")
            'dgvLoadPKODetails.Columns("dgclLoadQuantity").HeaderText = rm.GetString("Quantity")
            'dgvLoadPKODetails.Columns("dgclLoadMonthDate").HeaderText = rm.GetString("Month Todate")
            'dgvLoadPKODetails.Columns("dgclLoadRemarks").HeaderText = rm.GetString("Remarks")

            btnSave.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddLoad.Text = rm.GetString("Add")
            btnResetLoad.Text = rm.GetString("Reset")

            'dgvPKOView.Columns("gvPKODate").HeaderText = rm.GetString("Date")
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
            Dim objPKOPPT As New LoadingPKOPPT
            Dim dsTransLoad As DataSet
            objPKOPPT.CropYieldID = lCropYieldID
            objPKOPPT.PKODate = dtpPKODate.Value
            dsTransLoad = LoadingPKOBOL.PKOGetLoadTransMonthQty(objPKOPPT)
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

            dsLoadTankNo = LoadingPKOBOL.loadCmbStorage("PKO")

            'For Load Tank

            Dim dr1 As DataRow = dsLoadTankNo.Tables(0).NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            dsLoadTankNo.Tables(0).Rows.InsertAt(dr1, 0)

            'Load PKO
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
            dsLoadLocation = LoadingPKOBOL.loadCmbLocation()
            'Location PKO Combo
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
            Dim objPKOPPT As New LoadingPKOPPT
            objPKOPPT.CropYieldCode = lCropYieldCode
            If objPKOPPT.CropYieldCode <> String.Empty Then
                dsCrop = LoadingPKOBOL.GetCropYieldID(objPKOPPT)
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
            Dim objPKOPPT As New LoadingPKOPPT
            objPKOPPT.TankID = lTankID
            If objPKOPPT.TankID <> String.Empty Then
                dsCropID = LoadingPKOBOL.GetCropYield(objPKOPPT)
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

        lresetLoad = True
        lresetTrans = False
        If cmbLoadTank.Items.Count > 0 Then
            cmbLoadTank.SelectedIndex = 0
        End If
        If cmbLoadLocation.Items.Count > 0 Then
            cmbLoadLocation.SelectedIndex = 0
        End If
        ' txtLoadBalanceBF.Text = ""
        txtLoadQty.Text = ""
        txtLoadRemarks.Text = ""
        ' lblLoadDescription.Text = "Description"
        ' PKOGetLoadTransMonthQty()
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


    Public Sub Reset()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKODate)
        'FormatDateTimePicker(dtpPKODate)
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)
        'FormatDateTimePicker(dtpPKOViewDate)
        dtpPKODate.Enabled = True
        'For Load PKO

        'cmbLoadTank.Text = "Select All"
        cmbLoadLocation.Text = ""
        'txtLoadBalanceBF.Text = ""
        txtLoadQty.Text = ""
        txtLoadMonthToDate.Text = ""

        '''' For Trans PKO
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

        ClearGridView(dgvLoadPKODetails)

        DeleteMultientryLoadPKO.Clear()

        'PKOGetTodayQty()
        'PKOGetMonthYearQty()
        'PKOGetLoadTransMonthQty()
        'UpdateTankMasterBFQty()

        '''''''For Very First Time Entry for MonthTodate , YearTodate'''''''''



        If dgvPKOView.Rows.Count > 0 Then
            ''''For Loading PKO'''''''
            txtLoadMonthToDate.Enabled = False

        Else
            ''''For Loading PKO'''''''
            txtLoadMonthToDate.Enabled = True
        End If

        btnSave.Enabled = True
        btnDeleteAll.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub PKOGridViewBind()
        Try
            Dim dt As New DataTable
            Dim objPKOPPT As New LoadingPKOPPT
            objPKOPPT.PKODate = dtpPKODate.Value
            'loadCmbStorage()
            With objPKOPPT

                'edit by suraya 14092012
                If chkPKODate.Checked = True Then
                    dtpPKOViewDate.Enabled = True
                    .PKODate = dtpPKOViewDate.Value
                Else
                    dtpPKOViewDate.Enabled = False
                    .PKODate = Nothing
                End If
                'dtpPKOViewDate.Format = DateTimePickerFormat.Custom '
                'dtpPKOViewDate.CustomFormat = "dd/MM/yyyy"
                'GlobalBOL.SetDateTimePicker(Me.dtpPKOViewDate)

                'If chkPKODate.Checked = True Then
                '    dtpPKOViewDate.Enabled = True
                '.PKODate = dtpPKOViewDate.Value 'Format(Me.dtpPKOViewDate.Value, "MM/dd/yyyy")

                'dtpPKOViewDate.MinDate = GlobalPPT.FiscalYearFromDate
                'dtpPKOViewDate.MaxDate = GlobalPPT.FiscalYearToDate
                'Dim TempDate As Date = dtpPKOViewDate.Value
                'Dim NowDate As Date = Now()
                'If Now() >= GlobalPPT.FiscalYearFromDate And dtpPKOViewDate.Value <= GlobalPPT.FiscalYearFromDate Then
                '    dtpPKOViewDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
                'End If



                '    Dim ToDate As Date = dtpPKOViewDate.Value
                '    dtpPKOViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

                'Else
                '    dtpPKOViewDate.Enabled = False
                '    .PKODate = Nothing
                'End If
                ' .TankNo = cmbViewTankNo.Text

                'If .TankNo = "--Select All--" Then
                '    .TankNo = ""
                'Else
                '    .TankNo = cmbViewTankNo.Text
                'End If
            End With
            objPKOPPT.CropYieldID = lCropYieldID
            dt = LoadingPKOBOL.GetPKODetails(objPKOPPT)
            'If dt.TableName.Count <> 0 Then
            If dt.Rows.Count <> 0 Then
                dgvPKOView.AutoGenerateColumns = False
                Me.dgvPKOView.DataSource = dt

                'Dim i As Integer = dgvPKOView.Rows.Count
                'lLoadMonthToDate = dgvPKOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value
                'lTransMonthToDate = dgvPKOView.Rows(i - 1).Cells("gvTransMonthToDate").Value
                'MsgBox(dgvPKOView.Rows(i - 1).Cells("gvLoadMonthToDate").Value)
            Else
                ClearGridView(dgvPKOView) '''''clear the records from grid view
                Exit Sub
            End If
            ' End If
            If dgvPKOView.RowCount = 0 Then
                cmsPKO.Visible = False
            End If
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

        If dgvPKOView.Rows.Count > 0 Then

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
            Dim objPKOPPT As New LoadingPKOPPT
            Dim objPKOBOL As New LoadingPKOBOL
            Dim dt As New DataTable

            If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSave.Enabled = True
                End If
            End If

            lresetLoad = True
            lresetTrans = True

            objPKOPPT.CropYieldID = lCropYieldID
            'objPKOPPT.ProductionID = lProductionID
            Dim str As String = CDate(Me.dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")
            'objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)
            objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

            dtpPKODate.Value = objPKOPPT.PKODate
            'PKOGetMonthYearQty()
            'PKOGetTodayQty()
            'PKOGetLoadTransMonthQty()




            '''' For Load PKO'''
            dgvLoadPKODetails.AutoGenerateColumns = False
            dtLoadPKOAdd = LoadingPKOBOL.GetPKOAddLoadInfo(objPKOPPT)

            SaveFlag = False
            dgvLoadPKODetails.DataSource = dtLoadPKOAdd
            '        dtpPKODate.Value = objPKOPPT.PKODate



            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            PKOGridViewBind()
            Me.tcLoadingPKO.SelectedTab = tpPKOSave
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
        If dgvPKOView.RowCount > 0 Then



            rowid = dgvPKOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then


                Dim objPKOPPT As New LoadingPKOPPT
                Dim objPKOBOL As New LoadingPKOBOL
                Dim str As String = CDate(Me.dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                ' objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)



                objPKOPPT.CropYieldID = lCropYieldID
                dtpPKODate.Value = objPKOPPT.PKODate

                objEditDuplicateSearchRecord = objPKOBOL.SearchDateCheck(objPKOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objPKOBOL.EditDateCheck(objPKOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdatePKOView()
                        btnSave.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdatePKOView()
                        btnSave.Enabled = True
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
            Dim objPKOPPT As New LoadingPKOPPT
            Dim objPKOBOL As New LoadingPKOBOL
            objPKOPPT.TankNo = lTankNo
            dsLoad = LoadingPKOBOL.GetTankID(objPKOPPT)
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
            Dim objPKOPPT As New LoadingPKOPPT
            objPKOPPT.Descp = lLocation
            dsLocation = LoadingPKOBOL.GetLocationID(objPKOPPT)
            If dsLocation.Tables.Count <> 0 Then
                If dsLocation.Tables(0).Rows.Count <> 0 Then
                    lLocationID = dsLocation.Tables(0).Rows(0).Item("LoadingLocationID")
                    lLocationDesc = dsLocation.Tables(0).Rows(0).Item("Descp")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgvPKOView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdatePKOView()
            End If
        End If


    End Sub
    Private Sub DeletePKOVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))

        Me.cmsPKO.Visible = False

        Dim objPKOPPT As New LoadingPKOPPT
        Dim objPKOBOL As New LoadingPKOBOL
        ' Dim dt As New DataTable
        If dgvPKOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Dim str As String = CDate(Me.dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                'objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
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
        If dgvPKOView.RowCount > 0 Then


            rowid = dgvPKOView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objPKOPPT As New LoadingPKOPPT
                Dim objPKOBOL As New LoadingPKOBOL
                Dim str As String = CDate(Me.dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")
                'objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objPKOPPT.CropYieldID = lCropYieldID
                dtpPKODate.Value = objPKOPPT.PKODate
                objDeleteDuplicateSearchRecord = objPKOBOL.SearchDateCheck(objPKOPPT)
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
        tcLoadingPKO.SelectedTab = tpPKOSave
        ResetLoad()
    End Sub

    Private Sub cmbLoadTank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoadTank.SelectedIndexChanged

        Dim objPKOBOL As New LoadingPKOBOL

        If cmbLoadTank.SelectedIndex <> 0 Then
            Dim lrow As Integer
            lrow = cmbLoadTank.SelectedIndex
            lLoadCapacity = dsLoadTankNo.Tables(0).Rows(lrow).Item("Capacity").ToString
        End If
        'lTankID = Nothing
        'GetTankID(cmbLoadTank.Text)
        Dim objPKOPPT As New LoadingPKOPPT
        'lLoadTankID = lTankID

        'objPKOPPT.ProductionID = lProdIdNew
        'objPKOPPT.TankID = cmbLoadTank.SelectedValue.ToString
        'objPKOPPT.CropYieldID = lCropYieldID
        'If cmbLoadLocation.SelectedIndex > 0 Then
        '    objPKOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'End If

        'objPKOPPT.PKODate = dtpPKODate.Value
        'If (lLocationID <> String.Empty) And (lTankID <> String.Empty And txtLoadQty.Text <> String.Empty) Then
        '    Dim objCheckDuplicateLoadLocation As Object = 0
        '    objCheckDuplicateLoadLocation = objPKOBOL.DuplicateLoadLocationFirstCheck(objPKOPPT)
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
        If cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" Then

            Dim dsLoadMonthTodate As New DataSet
            txtLoadMonthToDate.Text = ""
            txtLoadQty.Text = ""
            LoadMonthCount = 0

            Dim objPKOPPT As New LoadingPKOPPT
            objPKOPPT.TankID = cmbLoadTank.SelectedValue.ToString
            objPKOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
            objPKOPPT.CropYieldID = lCropYieldID
            objPKOPPT.PKODate = dtpPKODate.Value
            dsLoadMonthTodate = LoadingPKOBOL.PKOGetLoadingPKOMonthtodate(objPKOPPT)

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
        'Dim objPKOBOL As New PKOProductionBOL
        'lLocationID = Nothing
        'GetLocationID(cmbLoadLocation.Text)
        'Dim objPKOPPT As New PKOProductionPPT
        'lLoadLocationID = lLocationID
        ''n.Text = lLocationDesc
        'objPKOPPT.PKODate = dtpPKODate.Value
        'objPKOPPT.ProductionID = lProdIdNew
        'objPKOPPT.TankID = cmbLoadLocation.SelectedValue.ToString
        'objPKOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        'objPKOPPT.CropYieldID = lCropYieldID

        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) Then
        '        Dim objCheckDuplicateLoadLocation As Object = 0
        '        objCheckDuplicateLoadLocation = objPKOBOL.DuplicateLoadLocationFirstCheck(objPKOPPT)
        '        If objCheckDuplicateLoadLocation = 0 Then
        '            txtLoadMonthToDate.Enabled = False
        '        Else
        '            txtLoadMonthToDate.Enabled = True
        '        End If
        '    End If


        '    ''''Month Qty Value '''''''''''''''

        '    Dim dsCrop As New DataSet


        '    If (lLocationID <> String.Empty) And (lTankID <> String.Empty) And (lProdIdNew <> String.Empty) And (lCropYieldID <> String.Empty) Then
        '        dsCrop = PKOProductionBOL.PKOGetLoadVsLocMonthQty(objPKOPPT)
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
        If dgvLoadPKODetails.RowCount > 0 And btnSave.Enabled = True Then
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
            If dgvPKOView.RowCount = 0 Then
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

    Private Sub dgvPKOView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKOView.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
                Exit Sub
            End If
        End If
        If dgvPKOView.RowCount > 0 Then


            If (e.RowIndex = 0) Then

                rowid = e.RowIndex

                Dim objPKOPPT As New LoadingPKOPPT
                Dim objPKOBOL As New LoadingPKOBOL
                Dim str As String = CDate(Me.dgvPKOView.SelectedRows(0).Cells("gvPKODate").Value.ToString()).ToString("yyyy-MM-dd")

                'objPKOPPT.PKODate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                Dim culture As IFormatProvider
                culture = New CultureInfo("en-US", True)
                objPKOPPT.PKODate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                objPKOPPT.CropYieldID = lCropYieldID
                dtpPKODate.Value = objPKOPPT.PKODate

                objEditDuplicateSearchRecord = objPKOBOL.SearchDateCheck(objPKOPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    objEditDuplicateRecord = objPKOBOL.EditDateCheck(objPKOPPT)

                    If objEditDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg92")
                        ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        UpdatePKOView()
                        btnSave.Enabled = False
                        btnDeleteAll.Enabled = False
                    Else
                        UpdatePKOView()
                        btnSave.Enabled = True
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

    Private Sub txtLoadQty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadQty.Leave
        ' Dim objPKOPPT As New PKOProductionPPT
        'Dim ds As DataSet
        'ds = PKOProductionBOL.PKOGetLoadMonthTodate(objPKOPPT)
        'lLoadMonthToDate = ds.Tables(0).Rows(0).Item("MonthToDate")
        'If txtLoadQty.Text <> "" Then  'And lLoadMonthToDate <> String.Empty Then
        '    txtLoadMonthToDate.Text = txtLoadQty.Text + lLoadMonthToDate
        'End If

        'If cmbLoadTank.SelectedIndex <> 0 And cmbLoadLocation.SelectedIndex <> 0 And lCropYieldID <> "" And txtLoadQty.Text <> "" Then
        '    Dim dsLoadMonthTodate As New DataSet
        '    Dim objPKOPPT As New PKOProductionPPT
        '    objPKOPPT.TankID = cmbLoadTank.SelectedValue.ToString
        '    objPKOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString
        '    objPKOPPT.CropYieldID = lCropYieldID
        '    objPKOPPT.PKODate = dtpPKODate.Value
        '    dsLoadMonthTodate = PKOProductionBOL.PKOGetLoadingPKOMonthtodate(objPKOPPT)
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

    Private Sub SaveLoadPKODetail()
        Try
            Dim intRowcount As Integer = dtLoadPKOAdd.Rows.Count
            Dim objPKOPPT As New LoadingPKOPPT
            Dim objPKOBOL As New LoadingPKOBOL
            If Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpPKODate.Value) Then 'Location, Tank Validation 
                ''Duplicate Date Check ''''
                objPKOPPT.CropYieldID = lCropYieldID


                'Dim objCheckDuplicateLoadLocation As Object = 0

                'objPKOPPT.LoadingLocationID = cmbLoadLocation.SelectedValue.ToString


                'objPKOPPT.TankID = cmbLoadTank.SelectedValue.ToString

                'objCheckDuplicateLoadLocation = objPKOBOL.DuplicateLoadLocationCheck(objPKOPPT)


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
                        ' columnLoadPKOAdd = New DataColumn("LoadBalanceBF", System.Type.[GetType]("System.String"))
                        ' dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadQty", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadMonthToDate", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadLocationID", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        columnLoadPKOAdd = New DataColumn("LoadTankID", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)

                        'columnLoadPKOAdd = New DataColumn("PKOProductionDate", System.Type.[GetType]("System.String"))
                        ' dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        columnLoadPKOAdd = New DataColumn("LoadRemarks", System.Type.[GetType]("System.String"))
                        dtLoadPKOAdd.Columns.Add(columnLoadPKOAdd)


                        rowLoadPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadPKOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        'rowLoadPKOAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) ' + Val(txtLoadQty.Text)
                        End If

                        rowLoadPKOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadPKOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                        '  rowLoadPKOAdd("PKOProductionDate") = dtpPKODate.Value
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowLoadPKOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)
                        dtLoadAddFlag = True
                    Catch ex As Exception
                        rowLoadPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                        rowLoadPKOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                        ' rowLoadPKOAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                        If Me.txtLoadQty.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadQty") = Me.txtLoadQty.Text
                        End If
                        If Me.txtLoadMonthToDate.Text <> String.Empty Then
                            rowLoadPKOAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) '+ Val(txtLoadQty.Text)
                        End If
                        rowLoadPKOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                        rowLoadPKOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                        '   rowLoadPKOAdd("PKOProductionDate") = dtpPKODate.Value
                        '''''''''''''''''''''''''''''''''''
                        '''''''''''''For Remarks
                        rowLoadPKOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                        dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)
                        dtLoadAddFlag = True
                    End Try

                Else

                    rowLoadPKOAdd("LoadTankNo") = Me.cmbLoadTank.Text
                    rowLoadPKOAdd("LoadLocation") = Me.cmbLoadLocation.Text

                    'rowLoadPKOAdd("LoadBalanceBF") = Me.txtLoadBalanceBF.Text

                    If Me.txtLoadQty.Text <> String.Empty Then
                        rowLoadPKOAdd("LoadQty") = Me.txtLoadQty.Text
                    End If
                    If Me.txtLoadMonthToDate.Text <> String.Empty Then
                        rowLoadPKOAdd("LoadMonthToDate") = Val(txtLoadMonthToDate.Text) '+ Val(txtLoadQty.Text)
                    End If
                    rowLoadPKOAdd("LoadLocationID") = cmbLoadLocation.SelectedValue.ToString
                    rowLoadPKOAdd("LoadTankID") = cmbLoadTank.SelectedValue.ToString


                    ' rowLoadPKOAdd("PKOProductionDate") = dtpPKODate.Value
                    '''''''''''''''''''''''''''''''''''
                    '''''''''''''For Remarks
                    rowLoadPKOAdd("LoadRemarks") = txtLoadRemarks.Text.Trim

                    dtLoadPKOAdd.Rows.InsertAt(rowLoadPKOAdd, intRowcount)

                End If
            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry this Tank No, Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            With dgvLoadPKODetails
                .DataSource = dtLoadPKOAdd
                .AutoGenerateColumns = False
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Function LocationExist(ByVal Location As String, ByVal TankNo As String, ByVal PKODate As Date) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            'If AddFlag = True Then
            For Each objDataGridViewRow In dgvLoadPKODetails.Rows
                If (TankNo = objDataGridViewRow.Cells("dgclLoadStorageNo").Value And Location = objDataGridViewRow.Cells("dgclToLoading").Value) Then
                    'And PKODate = objDataGridViewRow.Cells("dgclPKODateLoad").Value Then
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

    Private Sub UpdateLoadPKODetails()
        Try
            Dim intCount As Integer = dgvLoadPKODetails.CurrentRow.Index

            'If lTempTankNo = cmbStockTank.Text Then
            If lLoadTank = cmbLoadTank.Text And lLoadLocation = cmbLoadLocation.Text Then


                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadPKODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If

                ' dgvLoadPKODetails.Rows(intCount).Cells("dgclBalanceBF").Value = txtLoadBalanceBF.Text

                If Me.txtLoadQty.Text <> Nothing Then
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
                Else
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
                End If
                If Me.txtLoadMonthToDate.Text <> Nothing Then
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
                Else
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
                End If

                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString

                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

                ''btnAddLoad.Text = "Add"
                btnAddLoadFlag = True
                'clear()

            ElseIf Not LocationExist(cmbLoadLocation.Text, cmbLoadTank.Text, dtpPKODate.Value) Then
                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadStorageNo").Value = cmbLoadTank.Text
                'If Me.lblCapacityValue.Text <> Nothing Then
                dgvLoadPKODetails.Rows(intCount).Cells("dgclToLoading").Value = cmbLoadLocation.Text
                ' End If
                ' dgvLoadPKODetails.Rows(intCount).Cells("dgclBalanceBF").Value = txtLoadBalanceBF.Text
                If Me.txtLoadQty.Text <> Nothing Then
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = Me.txtLoadQty.Text
                Else
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadQuantity").Value = DBNull.Value
                End If
                If Me.txtLoadMonthToDate.Text <> Nothing Then
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = Me.txtLoadMonthToDate.Text
                Else
                    dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadMonthDate").Value = DBNull.Value
                End If

                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadStorageID").Value = cmbLoadTank.SelectedValue.ToString
                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadStorageLocID").Value = cmbLoadLocation.SelectedValue.ToString
                dgvLoadPKODetails.Rows(intCount).Cells("dgclLoadRemarks").Value = txtLoadRemarks.Text.Trim

                ''btnAdd.Text = "Add"
                btnAddFlag = True

            Else
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("Sorry This Tank No , Location already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BindDgvLoadPKODetails()
        'Try
        If dgvLoadPKODetails.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddLoad.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddLoad.Text = "Memperbarui"
            End If
            ''Me.btnAddLoad.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddLoadFlag = False

            cmbLoadTank.Text = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
            lLoadTank = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadStorageNo").Value.ToString()
            cmbLoadLocation.Text = dgvLoadPKODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            lLoadLocation = dgvLoadPKODetails.SelectedRows(0).Cells("dgclToLoading").Value.ToString()
            If Not dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value Then
                lLoadingLocationID = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadStorageLocID").Value.ToString()
            Else
                lLoadingLocationID = Nothing
            End If
            If Not dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value Then
                lLoadTankID = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadStorageID").Value.ToString()
            Else
                lLoadTankID = Nothing
            End If
            If Not dgvLoadPKODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is DBNull.Value Then
                lProdLoadingID = dgvLoadPKODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value
            Else
                lProdLoadingID = Nothing
            End If

            ' txtLoadBalanceBF.Text = dgvLoadPKODetails.SelectedRows(0).Cells("dgclBalanceBF").Value.ToString()

            If Not dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString() Is DBNull.Value Then
                Me.txtLoadQty.Text = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
                lLoadQtyPrev = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadQuantity").Value.ToString()
            End If

            If Not dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString() Is DBNull.Value Then
                Me.txtLoadMonthToDate.Text = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadMonthDate").Value.ToString()
            End If
            'If LoadMonthCount <= 1 And SaveFlag = False Then
            '    txtLoadMonthToDate.Enabled = True
            'End If
            ' AddFlag = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''For Remarks Fields Add'''''''''''''''''
            txtLoadRemarks.Text = dgvLoadPKODetails.SelectedRows(0).Cells("dgclLoadRemarks").Value.ToString()


        End If
        'Catch ex As Exception
        ' End Try
    End Sub

    Private Sub dtpPKODate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPKODate.ValueChanged

        Dim objPKOPPT As New LoadingPKOPPT
        Dim objPKOBOL As New LoadingPKOBOL

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

    Private Sub dgvPKOView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPKOView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdatePKOView()
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
                    SaveLoadPKODetail()
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

    Private Sub dgvLoadPKODetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoadPKODetails.CellDoubleClick

        BindDgvLoadPKODetails()
    End Sub

    Private Sub btnResetLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetLoad.Click
        ResetLoad()
    End Sub

    Private Sub LoadQtyCheck()
        lLoadQty = 0

        If dgvLoadPKODetails.Rows.Count <> 0 Then
            For Each objDataGridViewRow In dgvLoadPKODetails.Rows
                If objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString <> String.Empty And objDataGridViewRow.Cells("dgclLoadStorageID").Value.ToString = cmbLoadTank.SelectedValue.ToString Then
                    lLoadQty = lLoadQty + Val(objDataGridViewRow.Cells("dgclLoadQuantity").Value.ToString())
                End If
            Next
        End If

        lLoadQty = lLoadQty + Val(txtLoadQty.Text) - lLoadQtyPrev


    End Sub

    Private Sub tcLoadingPKO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLoadingPKO.SelectedIndexChanged
        'ResetMain()
        'Reset()
        'ResetLoad()
        'ResetTrans()
        PKOGridViewBind()
    End Sub

    Private Sub tcLoadingPKO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLoadingPKO.Click

        If dgvLoadPKODetails.RowCount > 0 And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcLoadingPKO.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                ' ResetMain()
                Reset()
                ResetLoad()
                '  ResetTrans()
                PKOGridViewBind()


            End If
        Else
            'ResetMain()
            Reset()
            ResetLoad()
            ' ResetTrans()
            PKOGridViewBind()


        End If
    End Sub

    Private Sub txtLoadMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadMonthToDate.TextChanged
        If Val(txtLoadMonthToDate.Text) = 0 Then
            txtLoadMonthToDate.Text = ""
        End If
    End Sub

    Private Sub LoadPKOEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPKOEdit.Click
        BindDgvLoadPKODetails()
    End Sub

    Private Sub LoadPKODelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPKODelete.Click
        If dgvLoadPKODetails.RowCount = 0 Then
            Exit Sub
        ElseIf dgvLoadPKODetails.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridLoadPKO()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridLoadPKO()

        If Not dgvLoadPKODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value Is Nothing Then
            lProdLoadingID = dgvLoadPKODetails.SelectedRows(0).Cells("dgclProdLoadingID1").Value.ToString
        Else
            lProdLoadingID = String.Empty
        End If



        lDelete = 0
        If lProdLoadingID <> "" Then
            lDelete = DeleteMultientryLoadPKO.Count
            DeleteMultientryLoadPKO.Insert(lDelete, lProdLoadingID)
        End If
        Dim Dr As DataRow
        Dr = dtLoadPKOAdd.Rows.Item(dgvLoadPKODetails.CurrentRow.Index)
        Dr.Delete()
        dtLoadPKOAdd.AcceptChanges()
        lProdLoadingID = ""


    End Sub

    Private Sub DeleteMultiEntryRecordsLoadingPKO()
        Dim objLoadingPKOPPT As New LoadingPKOPPT

        lDelete = DeleteMultientryLoadPKO.Count

        While (lDelete > 0)

            objLoadingPKOPPT.ProdLoadingID = DeleteMultientryLoadPKO(lDelete - 1)

            Dim IntProdLoadingDelete As New Integer
            IntProdLoadingDelete = LoadingPKOBOL.DeleteMultiEntryProdLoading(objLoadingPKOPPT)
            lDelete = lDelete - 1

        End While



    End Sub



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If lCropYieldID = "" Then
                DisplayInfoMessage("Msg24")
                ''MsgBox("No Record in Crop yield for PKO, Please insert the record in General Crop Yield")
                Exit Sub
            End If


            If dgvLoadPKODetails.Rows.Count <> 0 Then

                'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                '    Exit Sub
                'End If

                If SaveFlag = True Then

                    Dim objPKOPPT As New LoadingPKOPPT
                    Dim objPKOBOL As New LoadingPKOBOL

                    Dim objCheckDuplicateRecord As Object = 0
                    objPKOPPT.PKODate = dtpPKODate.Value
                    objPKOPPT.CropYieldID = lCropYieldID
                    objCheckDuplicateRecord = objPKOBOL.DuplicateDateCheck(objPKOPPT)

                    If objCheckDuplicateRecord = 0 Then
                        DisplayInfoMessage("Msg26")
                        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                        Exit Sub
                    Else
                        objCompareDateCheck = objPKOBOL.CompareCPOPLoadingDateIsExist(objPKOPPT)
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


                    For Each DataGridViewRowLoad In dgvLoadPKODetails.Rows

                        ''''''For Load PKO'''''''''''''
                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objPKOPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                        Else
                            objPKOPPT.LoadTankID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                            objPKOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        Else
                            objPKOPPT.LoadingLocationID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                            objPKOPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objPKOPPT.LoadQty = 0.0
                        End If

                        'If Not DataGridViewRowLoad.Cells("dgclBalanceBF").Value Is DBNull.Value Then
                        '    objPKOPPT.LoadBalanceBF = DataGridViewRowLoad.Cells("dgclBalanceBF").Value
                        'Else
                        '    objPKOPPT.LoadBalanceBF = 0.0
                        'End If
                        If Not DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value Then
                            objPKOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                        Else
                            objPKOPPT.LoadMonthToDate = 0.0
                            'objPKOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        End If
                        objPKOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objPKOPPT.CropYieldID = lCropYieldID

                        LoadingPKOBOL.savePKOLoadProduction(objPKOPPT)
                    Next




                    PKOGridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()
                    ResetLoad()


                    'SaveFlag = False
                Else

                    Dim objPKOPPT As New LoadingPKOPPT
                    Dim objPKOBOL As New LoadingPKOBOL
                    'Dim StrPKODate As String
                    Dim dsDetails As New DataSet
                    'For Each DataGridViewRowMain In dgvPKODetails.Rows

                    objPKOPPT.CropYieldID = lCropYieldID
                    'PKOGetMonthYearQty()
                    'PKOGetTodayQty()
                    'PKOGetLoadTransMonthQty()

                    'objPKOPPT.PKODate = Format(txtDate.Text, "dd/MM/yyyy")
                    objPKOPPT.PKODate = dtpPKODate.Value 'Format(dtpPKODate.Value, "MM/dd/yyyy")
                    ' objPKOPPT.ProductionID = DataGridViewRowMain.Cells("dgclProductionID").Value.ToString
                    'If DataGridViewRowMain.Cells("dgclProductionID").Value.ToString = String.Empty Then


                    For Each DataGridViewRowLoad In dgvLoadPKODetails.Rows

                        ''''''For Load PKO'''''''''''''
                        objPKOPPT.ProductionID = lProdIdNew
                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString() Is DBNull.Value.ToString() Then
                            objPKOPPT.LoadTankID = DataGridViewRowLoad.Cells("dgclLoadStorageID").Value.ToString()
                        Else
                            objPKOPPT.LoadTankID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString() Is DBNull.Value.ToString() Then
                            objPKOPPT.LoadingLocationID = DataGridViewRowLoad.Cells("dgclLoadStorageLocID").Value.ToString()
                        Else
                            objPKOPPT.LoadingLocationID = Nothing
                        End If

                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then
                            objPKOPPT.LoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objPKOPPT.LoadQty = 0.0
                        End If

                        'If Not DataGridViewRowLoad.Cells("dgclBalanceBF").Value Is DBNull.Value Then
                        '    objPKOPPT.LoadBalanceBF = DataGridViewRowLoad.Cells("dgclBalanceBF").Value
                        'Else
                        '    objPKOPPT.LoadBalanceBF = 0.0
                        'End If


                        If Not DataGridViewRowLoad.Cells("dgclLoadQuantity").Value Is DBNull.Value Then 'DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value Is DBNull.Value And 
                            Dim lLoadMonthdate As String
                            Dim lLoadQty As String
                            lLoadMonthdate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value.ToString()
                            lLoadQty = DataGridViewRowLoad.Cells("dgclLoadQuantity").Value.ToString()
                            objPKOPPT.LoadMonthToDate = lLoadMonthdate 'Val(lLoadMonthdate) + Val(lLoadQty)

                            'objPKOPPT.LoadMonthToDate = DataGridViewRowLoad.Cells("dgclLoadMonthDate").Value + DataGridViewRowLoad.Cells("dgclLoadQuantity").Value
                        Else
                            objPKOPPT.LoadMonthToDate = 0.0
                        End If
                        '''''''''''''''''''''''''''''''''''''''
                        ''''For Remarks


                        objPKOPPT.LoadRemarks = DataGridViewRowLoad.Cells("dgclLoadRemarks").Value.ToString()
                        objPKOPPT.CropYieldID = lCropYieldID

                        If Not (DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value) Then
                            objPKOPPT.ProdLoadingID = DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value
                        Else
                            objPKOPPT.ProdLoadingID = String.Empty
                        End If


                        If DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is Nothing Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value Is DBNull.Value Or DataGridViewRowLoad.Cells("dgclProdLoadingID1").Value.ToString = String.Empty Then
                            LoadingPKOBOL.savePKOLoadProduction(objPKOPPT)
                        Else
                            LoadingPKOBOL.UpdatePKOLoadProduction(objPKOPPT)
                        End If

                    Next



                    DeleteMultiEntryRecordsLoadingPKO()


                    ' PKOProductionBOL.UpdateTankMasterBFQty(objPKOPPT)
                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSave.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSave.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    PKOGridViewBind()
                    Reset()

                    ResetLoad()

                    SaveFlag = True

                End If
                ClearGridView(dgvLoadPKODetails)
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objPKOPPT As New LoadingPKOPPT
            Dim objPKOBOL As New LoadingPKOBOL

            objPKOPPT.PKODate = dtpPKODate.Value
            objPKOPPT.CropYieldID = lCropYieldID
            objPKOBOL.Delete_PKODetail(objPKOPPT)
            PKOGridViewBind()
        End Try
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objPKOPPT As New LoadingPKOPPT
        Dim objPKOBOL As New LoadingPKOBOL
        If dgvPKOView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ' If lProductionID <> String.Empty Then
                objPKOPPT.PKODate = dtpPKODate.Value
                objPKOPPT.CropYieldID = lCropYieldID
                objPKOBOL.Delete_PKODetail(objPKOPPT)
                PKOGridViewBind()
            End If
        End If


        Reset()

        ResetLoad()

    End Sub
End Class