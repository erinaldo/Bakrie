'Imports Production_BOL
'Imports Production_PPT

Imports CheckRoll_BOL
Imports CheckRoll_PPT

Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class AnalyHarvestingCost

    Public lTankID As String = String.Empty
    ' Public lCropYieldID As String = String.Empty
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
    Dim dtCPOAdd As New DataTable("todgvCPOAdd")
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
    'Public lCropYieldCode As String = String.Empty
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

    'Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim DeleteMultientryStockKernel As New ArrayList
    Dim DeleteMultientryLoadKernel As New ArrayList
    Dim DeleteMultientryTransKernel As New ArrayList
    Dim lDelete As Integer
    Shadows mdiparent As New MDIParent
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AnalyHarvestingCost))

    'For Grid
    ''Stock CPO'''
    Public btnAddFlag As Boolean = True
    Dim columnCPOAdd As DataColumn
    Dim rowCPOAdd As DataRow
    Public dtAddFlag As Boolean = False
    Public AddFlag As Boolean = True
    Private LoadMonthCount As Integer

 
    Private Sub AnalyHarvestingCost_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dgvWBFruitWt.RowCount > 0 And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
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

    Private Sub AnalyHarvestingCost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub AnalyHarvestingCost_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsButtonClose = False
        GlobalPPT.IsRetainFocus = False
        SetUICulture(GlobalPPT.strLang)
        Dim ToDate As Date = Date.Today
        'dtpKernelDate.Value = ToDate
        FillMonthYear()

        Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT

        tcTransKernel.SelectedTab = tpKernelView

        'Filling the Month Year
        loadMonthYear()

        'Displaying the Current Active Month Year ID
        Dim dt As DataTable
        dt = AnalyHarvestingCostBOL.GetActiveMonthYear(objWBFruitWtDetailsPPT)
        If dt.Rows.Count > 0 Then
            lblMonthYear.Text = dt.Rows(0).Item("MonthYR")
        End If

        'Filling the YOP Combo Box
        loadYOP()

        ResetMain()
        Reset()

        GridViewBind()
        cmbYOP.Focus()

    End Sub

    Private Sub loadYOP()
        Try
            Dim dt As DataTable
            dt = AnalyHarvestingCostBOL.loadCmbYOP()

            Dim dr1 As DataRow = dt.NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            dt.Rows.InsertAt(dr1, 0)

            'Load YOP
            cmbYOP.DataSource = dt
            cmbYOP.DisplayMember = "YOP"
            cmbYOP.ValueMember = "YOPID"

        Catch ex As Exception
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("There is No Tank for This Estate") 'ex.Message)
        End Try
    End Sub

    Private Sub loadMonthYear()
        Try
            Dim dt As DataTable
            dt = AnalyHarvestingCostBOL.loadCmbYOP()

            'Dim dr1 As DataRow = dsLoadYOP.Tables(0).NewRow()
            Dim dr1 As DataRow = dt.NewRow()
            dr1(0) = "--Select--"
            dr1(1) = "--Select--"
            'dsLoadYOP.Tables(0).Rows.InsertAt(dr1, 0)
            dt.Rows.InsertAt(dr1, 0)

            'Load YOP
            cmbYOP.DataSource = dt
            cmbYOP.DisplayMember = "DivYOP"
            cmbYOP.ValueMember = "YOPID"

        Catch ex As Exception
            ''DisplayInfoMessage("Msg3")
            MessageBox.Show("There is No YOP for This Estate")
        End Try
    End Sub

    Private Sub FillMonthYear()
        Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT

        'Displaying the Current Active Month Year ID
        Dim dt As DataTable
        dt = AnalyHarvestingCostBOL.GetActiveMonthYear(objWBFruitWtDetailsPPT)
        If dt.Rows.Count > 0 Then
            lblMonthYear.Text = dt.Rows(0).Item("MonthYR")
        End If
    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            btnAddTrans.Text = rm.GetString("Add")
            btnResetTrans.Text = rm.GetString("Reset")

            btnSaveAll.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")
            btnAddTrans.Text = rm.GetString("Add")
            btnAddTrans.Text = rm.GetString("Add")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(KernelProductionFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub


    Private Function IsCheckValidationTrans()
        If cmbYOP.SelectedIndex = 0 Then
            '' DisplayInfoMessage("Msg13")
            MessageBox.Show("This Field is Required ", "YOP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbYOP.Focus()
            Return False
        End If

        If txtFFBWt.Text = String.Empty Then
            '' DisplayInfoMessage("Msg15")
            MessageBox.Show("This Field is Required", "FFB Weight (Kg)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFFBWt.Focus()
            Return False
        End If

        If txtFFBBunches.Text = String.Empty Then
            '' DisplayInfoMessage("Msg15")
            MessageBox.Show("This Field is Required", "FFB Bunches", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFFBBunches.Focus()
            Return False
        End If

        If txtOtherSeperateWt.Text = String.Empty Then
            txtOtherSeperateWt.Text = "0.000"
        End If

        If txtHarvestorWt.Text = String.Empty Then
            txtHarvestorWt.Text = "0.000"
        End If

        Return True
    End Function

    Public Sub ResetTrans()
        ''''For Stock Kernel
        lresetLoad = False
        lresetTrans = True
        If cmbYOP.Items.Count > 0 Then
            cmbYOP.SelectedIndex = 0
        End If

        txtFFBWt.Text = ""
        txtFFBBunches.Text = ""
        txtOtherSeperateWt.Text = ""
        txtHarvestorWt.Text = ""


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

        'dtpKernelDate.Enabled = True

        '''' For Trans Kernel

        If cmbYOP.Items.Count > 0 Then
            cmbYOP.SelectedIndex = 0
        End If


        txtFFBWt.Text = ""
        txtFFBBunches.Text = ""
        txtOtherSeperateWt.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        '' btnSaveAll.Text = "Save All"
        SaveFlag = True

        '''''For Production Kernel
        Dim ToDate As Date = Date.Today
        'dtpKernelDate.Value = ToDate
        Call FillMonthYear()

        ClearGridView(dgvWBFruitWt)

        DeleteMultientryTransKernel.Clear()

        ''''For Very First Entry for MonthTodate Loading , MonthTodate Tranship''''
        MonthCount = False
        YearCount = False

        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True

        'Palani - Check this and later enable
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub GridViewBind()
        Try
            'Binding the View GRID 
            Dim dt As New DataTable
            Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
            'objWBFruitWtDetailsPPT.MonthYear = lblMonthYear.Text

            dt = AnalyHarvestingCostBOL.GetWBFruitWtRecs(objWBFruitWtDetailsPPT)
            If dt.Rows.Count <> 0 Then
                dgvWBFruitWtDetailsView.AutoGenerateColumns = False
                Me.dgvWBFruitWtDetailsView.DataSource = dt
            Else
                ClearGridView(dgvWBFruitWtDetailsView) '''''clear the records from grid view
                Exit Sub
            End If
            ' End If
            If dgvWBFruitWtDetailsView.RowCount = 0 Then
                CMSLoadCPO.Visible = False
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
        If dgvWBFruitWtDetailsView.Rows.Count > 0 Then
            EditPKOView()
        Else
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EditPKOView()
        Try

            Me.cmsKernel.Visible = False
            Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
            Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL
            Dim dt As New DataTable

            'If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    If EditToolStripMenuItem.Enabled = True Then
            '        btnSaveAll.Enabled = True
            '    End If
            'End If

            lresetLoad = True
            lresetTrans = True

            Dim str As String = Me.dgvWBFruitWtDetailsView.SelectedRows(0).Cells("dgclWBFruitWtID").Value.ToString()

            'objWBFruitWtDetailsPPT.MonthYear = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

            Dim culture As IFormatProvider
            culture = New CultureInfo("en-US", True)

            lblMonthYear.Text = Me.dgvWBFruitWtDetailsView.SelectedRows(0).Cells("dgclMonthYear").Value.ToString()
            lblMonthYear.Tag = str

            objWBFruitWtDetailsPPT.WBFruitWtID = str
            dtCPOAdd = AnalyHarvestingCostBOL.GetWBFruitWt(objWBFruitWtDetailsPPT)

            dgvWBFruitWt.AutoGenerateColumns = False

            SaveFlag = False

            dgvWBFruitWt.DataSource = dtCPOAdd

            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            ''Me.btnSaveAll.Text = "Update All"
            GridViewBind()
            Me.tcTransKernel.SelectedTab = tpKernelSave
            btnSaveAll.Enabled = False
            btnDeleteAll.Enabled = False
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If dgvWBFruitWtDetailsView.RowCount > 0 Then

            rowid = dgvWBFruitWtDetailsView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
                Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL
                Dim str As String = Me.dgvWBFruitWtDetailsView.SelectedRows(0).Cells("dgclMonthYear").Value.ToString()

                'Dim culture As IFormatProvider
                'culture = New CultureInfo("en-US", True)
                'objWBFruitWtDetailsPPT.MonthYear = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

                lblMonthYear.Text = objWBFruitWtDetailsPPT.MonthYear
                'objEditDuplicateSearchRecord = objWBFruitWtDetailsBOL.TransSearchDateCheck(objWBFruitWtDetailsPPT)
                If objEditDuplicateSearchRecord = 0 Then
                    'objEditDuplicateRecord = objWBFruitWtDetailsBOL.EditDateCheck(objWBFruitWtDetailsPPT)
                    objEditDuplicateRecord = 1

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


    Private Sub dgvTransKernelView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    If EditToolStripMenuItem.Enabled = True Then
        '        UpdatePKOView()
        '    End If
        'End If
    End Sub

    Private Sub DeletePKOVIew()
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionFrm))

        Me.CMSLoadCPO.Visible = False

        Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
        Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL
        ' Dim dt As New DataTable
        If dgvWBFruitWtDetailsView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                objWBFruitWtDetailsPPT.MonthYear = Me.dgvWBFruitWtDetailsView.SelectedRows(0).Cells("dgclMonthYear").Value.ToString()
                AnalyHarvestingCostBOL.DeleteWBFruitWt(objWBFruitWtDetailsPPT)

                GridViewBind()
            End If
        End If

    End Sub


    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvWBFruitWtDetailsView.RowCount > 0 Then



            rowid = dgvWBFruitWtDetailsView.SelectedRows.Item(0).Index

            If (rowid = 0) Then
                Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
                Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL
                Dim str As String = Me.dgvWBFruitWtDetailsView.SelectedRows(0).Cells("dgclMonthYear").Value.ToString()

                '            objWBFruitWtDetailsPPT.MonthYear = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))

                'Dim culture As IFormatProvider
                'culture = New CultureInfo("en-US", True)
                'objWBFruitWtDetailsPPT.MonthYear = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)


                'dtpKernelDate.Value = objWBFruitWtDetailsPPT.MonthYear
                lblMonthYear.Text = objWBFruitWtDetailsPPT.MonthYear

                'objDeleteDuplicateSearchRecord = objWBFruitWtDetailsBOL.TransSearchDateCheck(objWBFruitWtDetailsPPT)
                objDeleteDuplicateSearchRecord = 0

                If objDeleteDuplicateSearchRecord = 0 Then
                    'objDeleteDuplicateRecord = objWBFruitWtDetailsBOL.EditDateCheck(objWBFruitWtDetailsPPT)
                    objDeleteDuplicateRecord = 1

                    If objDeleteDuplicateRecord = 1 Then
                        DeletePKOVIew()
                    Else
                        DisplayInfoMessage("Msg141")
                        ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    DisplayInfoMessage("Msg141")
                End If
            Else
                DisplayInfoMessage("Msg141")
                ''MessageBox.Show(" Cannot Delete This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

   

    Private Sub txtTransMonthToDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

   

    Private Sub txtTransMonthToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        If dgvWBFruitWt.RowCount > 0 And btnSaveAll.Enabled = True Then
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


    Private Sub dgvTransKernelView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWBFruitWtDetailsView.CellDoubleClick

        'If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    If EditToolStripMenuItem.Enabled = True Then
        '        btnSaveAll.Enabled = True
        '    Else
        '        btnSaveAll.Enabled = False
        '        Exit Sub
        '    End If
        'End If

        ' Palani - DO not control the record for Editing
        If dgvWBFruitWtDetailsView.RowCount > 0 Then

            'If (e.RowIndex = 0) Then

            rowid = e.RowIndex
            Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
            Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL
            Dim str As String = Me.dgvWBFruitWtDetailsView.SelectedRows(0).Cells("dgclMonthYear").Value.ToString()

            'Dim culture As IFormatProvider
            'culture = New CultureInfo("en-US", True)
            'objWBFruitWtDetailsPPT.MonthYear = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)

            lblMonthYear.Text = objWBFruitWtDetailsPPT.MonthYear
            'objEditDuplicateSearchRecord = objWBFruitWtDetailsBOL.TransSearchDateCheck(objWBFruitWtDetailsPPT)
            If objEditDuplicateSearchRecord = 0 Then
                'objEditDuplicateRecord = objWBFruitWtDetailsBOL.EditDateCheck(objWBFruitWtDetailsPPT)
                objEditDuplicateRecord = 1

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


            'Else
            '    DisplayInfoMessage("Msg92")
            '    ''MessageBox.Show(" Cannot Edit This Record!!!!This Record is used in another Screen", " This Record is used in another Screen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    rowid = e.RowIndex
            '    UpdatePKOView()
            'End If
        End If

    End Sub

    'Private Function LocationExistTrans(ByVal Location As String) As Boolean
    '    Try
    '        Dim objDataGridViewRow As New DataGridViewRow
    '        'If AddFlag = True Then
    '        For Each objDataGridViewRow In dgvWBFruitWt.Rows
    '            If (Location = objDataGridViewRow.Cells("dgclTranshipLoad").Value) Then
    '                ' txtStockCode.Text = ""
    '                cmbYOP.Focus()
    '                Return True
    '            End If
    '        Next
    '        Return False
    '    Catch ex As Exception
    '    End Try
    '    'End If
    'End Function

    Private Sub UpdateLoadPKODetails()
        Try
            Dim intCount As Integer = dgvWBFruitWt.CurrentRow.Index

            If lTransTank = cmbYOP.Text Then 'And lloadTrans = cmbYOP.Text Then

                dgvWBFruitWt.Rows(intCount).Cells("dgclYOP").Value = cmbYOP.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclFFBWt").Value = txtFFBWt.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclFFBBunches").Value = txtFFBBunches.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclOtherSeperate").Value = txtOtherSeperateWt.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclHarvestor").Value = txtHarvestorWt.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclYOPValue").Value = cmbYOP.SelectedValue.ToString

                If GlobalPPT.strLang = "en" Then
                    btnAddTrans.Text = "Add"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnAddTrans.Text = "Menambahkan"
                End If
                ''btnAddTrans.Text = "Add"
                btnTransAddFlag = True
                'clear()

            ElseIf Not TankNoExist(cmbYOP.Text) Then  'LocationExistTrans(cmbYOP.Text) 

                dgvWBFruitWt.Rows(intCount).Cells("dgclYOP").Value = cmbYOP.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclFFBWt").Value = txtFFBWt.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclFFBBunches").Value = txtFFBBunches.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclOtherSeperate").Value = txtOtherSeperateWt.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclHarvestor").Value = txtHarvestorWt.Text
                dgvWBFruitWt.Rows(intCount).Cells("dgclYOPValue").Value = cmbYOP.SelectedValue.ToString

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
        If dgvWBFruitWt.Rows.Count > 0 Then
            If GlobalPPT.strLang = "en" Then
                btnAddTrans.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddTrans.Text = "Memperbarui"
            End If
            btnAddTransFlag = False

            cmbYOP.SelectedValue = dgvWBFruitWt.SelectedRows(0).Cells("dgclYOPValue").Value.ToString() 'Text = dgclYOP
            lTransTank = dgvWBFruitWt.SelectedRows(0).Cells("dgclYOP").Value.ToString()

            txtFFBWt.Text = dgvWBFruitWt.SelectedRows(0).Cells("dgclFFBWt").Value.ToString()
            txtFFBBunches.Text = dgvWBFruitWt.SelectedRows(0).Cells("dgclFFBBunches").Value.ToString()
            txtOtherSeperateWt.Text = dgvWBFruitWt.SelectedRows(0).Cells("dgclOtherSeperate").Value.ToString()
            txtHarvestorWt.Text = dgvWBFruitWt.SelectedRows(0).Cells("dgclHarvestor").Value.ToString()
        End If
    End Sub

    Private Sub dgvTransKernelView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvWBFruitWtDetailsView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdatePKOView()
            e.Handled = True
        End If
    End Sub

    Private Sub AddTrans_Clicked()
        Try

            If btnAddTransFlag = True Then
                'If btnAdd.Text.Trim() = "Add" Then
                If (IsCheckValidationTrans() = False) Then
                    Exit Sub
                Else

                    'SaveTransKernelDetail()
                    SaveLoadPKODetail()

                    ResetTrans()
                End If
            ElseIf btnAddTransFlag = False Then
                If (IsCheckValidationTrans() = False) Then
                    Exit Sub
                Else
                    UpdateLoadPKODetails()

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


    Private Sub SaveLoadPKODetail()
        Try
            Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
            Dim objPKOBOL As New AnalyHarvestingCostBOL
            Dim intRowcount As Integer = dtCPOAdd.Rows.Count

            If Not TankNoExist(cmbYOP.Text) Then
                '''' For check Duplicate YOP ''''

                objWBFruitWtDetailsPPT.YOPID = cmbYOP.SelectedValue.ToString
                objWBFruitWtDetailsPPT.YOP = cmbYOP.Text

                objWBFruitWtDetailsPPT.FFBWt = txtFFBWt.Text
                objWBFruitWtDetailsPPT.FFBBunches = txtFFBBunches.Text

                objWBFruitWtDetailsPPT.OthersWt = txtOtherSeperateWt.Text
                objWBFruitWtDetailsPPT.HarvestersWt = txtHarvestorWt.Text

                rowCPOAdd = dtCPOAdd.NewRow()
                If intRowcount = 0 And dtAddFlag = False Then

                    columnCPOAdd = New DataColumn("YOP", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("FFBWt", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("FFBBunches", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("OthersWt", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("HarvestersWt", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("YOPValue", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)


                    rowCPOAdd("YOP") = cmbYOP.Text
                    rowCPOAdd("FFBWt") = txtFFBWt.Text
                    rowCPOAdd("FFBBunches") = txtFFBBunches.Text
                    rowCPOAdd("OthersWt") = txtOtherSeperateWt.Text
                    rowCPOAdd("HarvestersWt") = txtHarvestorWt.Text
                    rowCPOAdd("YOPValue") = cmbYOP.SelectedValue.ToString

                    dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                    dtAddFlag = True

                Else

                    rowCPOAdd("YOP") = cmbYOP.Text
                    rowCPOAdd("FFBWt") = txtFFBWt.Text
                    rowCPOAdd("FFBBunches") = txtFFBBunches.Text
                    rowCPOAdd("OthersWt") = txtOtherSeperateWt.Text
                    rowCPOAdd("HarvestersWt") = txtHarvestorWt.Text
                    rowCPOAdd("YOPValue") = cmbYOP.SelectedValue.ToString

                    dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)

                End If
            Else
                'DisplayInfoMessage("Msg36")
                MsgBox("YOP already added", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")

            End If
            'ResetMain()

            With dgvWBFruitWt
                .DataSource = dtCPOAdd
                .AutoGenerateColumns = False
            End With

        Catch ex As Exception
        End Try
    End Sub

    Private Function TankNoExist(ByVal TankNo As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvWBFruitWt.Rows
                If TankNo = objDataGridViewRow.Cells("dgclYOP").Value.ToString() Then
                    cmbYOP.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
        End Try
    End Function

    Private Sub btnAddTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTrans.Click
        'TransferQtyCheck()

        AddTrans_Clicked()

    End Sub

    Private Sub dgvTransKernelDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWBFruitWt.CellDoubleClick

        BindDgvTransKernelDetails()

    End Sub

    Private Sub btnResetTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetTrans.Click
        ResetTrans()
    End Sub

    Private Sub tcTransKernel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransKernel.SelectedIndexChanged
        GridViewBind()
        'UpdatePKOView()
    End Sub
    Private Sub tcTransKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcTransKernel.Click

        If dgvWBFruitWt.RowCount > 0 And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tcTransKernel.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                Reset()
                ResetTrans()
                GridViewBind()


            End If
        Else
            Reset()
            ResetTrans()
            GridViewBind()


        End If
    End Sub

    Private Sub TranshipEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipEdit.Click
        BindDgvTransKernelDetails()
    End Sub

    Private Sub TranshipDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranshipDelete.Click
        If dgvWBFruitWt.RowCount = 0 Then
            Exit Sub
        ElseIf dgvWBFruitWt.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridTranshipKernel()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridTranshipKernel()

        If Not dgvWBFruitWt.SelectedRows(0).Cells("dgclProdTranshipID1").Value Is Nothing Then
            lProdTranshipID = dgvWBFruitWt.SelectedRows(0).Cells("dgclProdTranshipID1").Value.ToString
        Else
            lProdTranshipID = String.Empty
        End If

        lDelete = 0
        If lProdTranshipID <> "" Then
            lDelete = DeleteMultientryTransKernel.Count
            DeleteMultientryTransKernel.Insert(lDelete, lProdTranshipID)
        End If
        Dim Dr As DataRow
        Dr = dtCPOAdd.Rows.Item(dgvWBFruitWt.CurrentRow.Index)
        Dr.Delete()
        dtCPOAdd.AcceptChanges()
        lProdTranshipID = ""


    End Sub


    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
        Dim objPKOBOL As New AnalyHarvestingCostBOL
        If dgvWBFruitWtDetailsView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg23"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ' If lProductionID <> String.Empty Then
                'objWBFruitWtDetailsPPT.PKODate = cmbMonthYear.Value
                'objWBFruitWtDetailsPPT.CropYieldID = lCropYieldID
                'objPKOBOL.Delete_PKODetail(objWBFruitWtDetailsPPT)
                GridViewBind()
            End If
        End If

        Reset()
        ResetTrans()
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        Try
            If dgvWBFruitWt.Rows.Count <> 0 Then

                If SaveFlag = True Then

                    Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
                    Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL

                    objWBFruitWtDetailsPPT.MonthYear = lblMonthYear.Text

                    Dim dsResult As DataSet = AnalyHarvestingCostBOL.saveWBFruitWt(objWBFruitWtDetailsPPT)

                    'Capturing the WBFruitWtID field after inserting the parent record
                    objWBFruitWtDetailsPPT.WBFruitWtID = dsResult.Tables(0).Rows(0)(0).ToString()

                    For Each DataGridViewRowLoad In dgvWBFruitWt.Rows

                        objWBFruitWtDetailsPPT.YOP = DataGridViewRowLoad.Cells("dgclYOP").Value.ToString()
                        objWBFruitWtDetailsPPT.FFBWt = DataGridViewRowLoad.Cells("dgclFFBWt").Value.ToString()
                        objWBFruitWtDetailsPPT.FFBBunches = DataGridViewRowLoad.Cells("dgclFFBBunches").Value.ToString()
                        objWBFruitWtDetailsPPT.OthersWt = DataGridViewRowLoad.Cells("dgclOtherSeperate").Value.ToString()
                        objWBFruitWtDetailsPPT.HarvestersWt = DataGridViewRowLoad.Cells("dgclHarvestor").Value.ToString()
                        objWBFruitWtDetailsPPT.YOPID = DataGridViewRowLoad.Cells("dgclYOPValue").Value.ToString()

                        AnalyHarvestingCostBOL.saveWBFruitWtDetails(objWBFruitWtDetailsPPT)

                    Next

                    GridViewBind()
                    DisplayInfoMessage("Msg27")
                    '' MsgBox("Data Successfully Saved")
                    Reset()

                    ResetTrans()

                    'SaveFlag = False
                Else
                    Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
                    Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL

                    objWBFruitWtDetailsPPT.MonthYear = lblMonthYear.Text

                    AnalyHarvestingCostBOL.DeleteWBFruitWt(objWBFruitWtDetailsPPT)


                    Dim dsResult As DataSet = AnalyHarvestingCostBOL.saveWBFruitWt(objWBFruitWtDetailsPPT)

                    'Capturing the WBFruitWtID field after inserting the parent record
                    objWBFruitWtDetailsPPT.WBFruitWtID = dsResult.Tables(0).Rows(0)(0).ToString()

                    For Each DataGridViewRowLoad In dgvWBFruitWt.Rows

                        objWBFruitWtDetailsPPT.YOP = DataGridViewRowLoad.Cells("dgclYOP").Value.ToString()
                        objWBFruitWtDetailsPPT.FFBWt = DataGridViewRowLoad.Cells("dgclFFBWt").Value.ToString()
                        objWBFruitWtDetailsPPT.FFBBunches = DataGridViewRowLoad.Cells("dgclFFBBunches").Value.ToString()
                        objWBFruitWtDetailsPPT.OthersWt = DataGridViewRowLoad.Cells("dgclOtherSeperate").Value.ToString()
                        objWBFruitWtDetailsPPT.HarvestersWt = DataGridViewRowLoad.Cells("dgclHarvestor").Value.ToString()
                        objWBFruitWtDetailsPPT.YOPID = DataGridViewRowLoad.Cells("dgclYOPValue").Value.ToString()

                        AnalyHarvestingCostBOL.saveWBFruitWtDetails(objWBFruitWtDetailsPPT)

                    Next

                    GridViewBind()


                    DisplayInfoMessage("Msg28")
                    ''MsgBox("Data Successfully Updated")
                    If GlobalPPT.strLang = "en" Then
                        btnSaveAll.Text = "Save All"
                    ElseIf GlobalPPT.strLang = "ms" Then
                        btnSaveAll.Text = "Simpan Semua"
                    End If
                    ''btnSaveAll.Text = "Save All"
                    GridViewBind()
                    Reset()


                    ResetTrans()
                    SaveFlag = True

                End If
                ClearGridView(dgvWBFruitWt)
            Else
                DisplayInfoMessage("Msg29")
                '' MessageBox.Show(" No Record to Add", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg30")
            ''MsgBox("Save Process Failed")
            Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
            Dim objWBFruitWtDetailsBOL As New AnalyHarvestingCostBOL

            objWBFruitWtDetailsPPT.MonthYear = lblMonthYear.Text 'dtpKernelDate.Value
            GridViewBind()
        End Try
    End Sub

    Private Sub txtFFBWt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBWt.KeyDown, txtOtherSeperateWt.KeyDown, txtHarvestorWt.KeyDown, txtFFBBunches.KeyDown
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

    Private Sub txtFFBWt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBWt.KeyPress, txtOtherSeperateWt.KeyPress, txtHarvestorWt.KeyPress, txtFFBBunches.KeyPress
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

 
    Private Sub cmbYOP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYOP.SelectedIndexChanged
        If btnAddTransFlag = True Then

            Dim objWBFruitWtDetailsPPT As New AnalyHarvestingCostPPT
            Dim dt As DataTable
            objWBFruitWtDetailsPPT.YOPID = cmbYOP.SelectedValue.ToString()
            dt = AnalyHarvestingCostBOL.GetDADLooseFruitsOther(objWBFruitWtDetailsPPT)
            If dt.Rows.Count > 0 Then
                objWBFruitWtDetailsPPT.OthersWt = dt.Rows(0).Item("DADLooseFruitsOther")
                txtOtherSeperateWt.Text = dt.Rows(0).Item("DADLooseFruitsOther")
            End If

        End If
    End Sub
End Class
