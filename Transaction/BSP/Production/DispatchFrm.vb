Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient



Public Class DispatchFrm

    Public lCPOProductID As String = String.Empty
    Public lPKOProductID As String = String.Empty
    Public lKernelProductID As String = String.Empty
    Dim rowMultipleEntryAddCPO, rowMultipleEntryAddPKO, rowMultipleEntryAddKernel As DataRow
    Dim dtCPO As New DataTable("todgCPO")
    Dim dtPKO As New DataTable("todgCPO")
    Dim dtKernel As New DataTable("todgCPO")
    Dim columnCPOAdd As DataColumn
    Dim rowCPOAdd As DataRow
    ' Dim dtCPO As New DataTable("todgPKO")
    Dim columnPKOAdd As DataColumn
    Dim rowPKOAdd As DataRow
    ' Dim dtCPO As New DataTable("todgKernel")
    Dim columnKernelAdd As DataColumn
    Dim rowKernelAdd As DataRow
    Dim lbtnAddCPO As String = String.Empty
    Dim lbtnAddPKO As String = String.Empty
    Dim lbtnAddKernel As String = String.Empty
    Dim lDispatchDetailID As String = String.Empty
    Dim lDispatchID As String = String.Empty
    Dim isModifierKey As Boolean
    Dim is3Decimal As Boolean
    Dim is2Decimal As Boolean
    Dim is2TempDecimal As Boolean
    Dim re3DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim re2DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim re2TempDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,3}(\.\d{0,2})?$")
    Dim lHrs As Integer
    Dim lMin As Integer
    Dim lAMPM As String
    Dim lbtnsaveCPO, lbtnsavePKO, lBtnsaveKernel As String
    Dim lCPOPosition, lPKOPosition, lKernelPosition As String
    Dim lSelectedIndexCalc As Boolean = True
    Dim lLoadingCPO, lLoadingPKO, lLoadingKernel As String
    Public Shared StrFrmName As String = String.Empty
    Dim dtCPOLoading As New DataTable
    Dim dtPKOLocation As New DataTable
    Dim dtKernelLocation As New DataTable
    Dim DecimalCheck As Boolean = False

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim DeleteMultientryCPO As New ArrayList
    Dim lDelete As Integer
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DispatchFrm))
    Shadows mdiparent As New MDIParent

    Public Sub ClearCPO()
        txtCPOMillWeight.Text = String.Empty
        txtCPOBAPNo.Text = String.Empty
        'txtCPOShipPontoon.Text = String.Empty
        Datefunction()
        cmbCPOLoadingLocation.SelectedIndex = 0
        grpCPO.Enabled = True
        CPOBFQty = 0
        If GlobalPPT.strLang = "en" Then
            btnSaveCPO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveCPO.Text = "Simpan"
        End If


        ''btnSaveCPO.Text = "Save"
        lbtnsaveCPO = "Save All"
        ' GetCPOLocationValues()
        SearchDispatch()
        dtpCPODate.Enabled = True
        dtpCPODate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpCPODOA.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpCPODOL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpCPODCL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpCPODepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpViewDispatchDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)

        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        dtpCPODate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpCPODOA.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpCPODOL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpCPODCL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpCPODepature.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtpViewDispatchDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

        DeleteMultientryCPO.Clear()


        dtpCPODate.Value = Date.Today
        dtpCPODOA.Value = Date.Today
        dtpCPODOL.Value = Date.Today
        dtpCPODCL.Value = Date.Today
        dtpCPODepature.Value = Date.Today
        dtpViewDispatchDate.Value = Date.Today
        Me.txtBuyerName.Text = String.Empty
        Me.txtKontrakNo.Text = String.Empty
        Me.txtNoOrderPenyerahan.Text = String.Empty
        Me.txtNoOrderInstruksi.Text = String.Empty
        Me.txtJumlahKontrak.Text = 0
        Me.txtNoSIM.Text = String.Empty
        Me.txtNoTrukTanki.Text = String.Empty
        Me.txtNoSeal.Text = String.Empty
        Me.txtDriverName.Text = String.Empty
        Me.txtTransporterName.Text = String.Empty
        Me.txtSPBNo.Text = String.Empty
        Me.cmbTermofSales.Text = String.Empty

        If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Public Sub ClearMultientryCPO()
        ' cmbCPOPosition.SelectedIndex = 1
        txtCPOFFA.Text = String.Empty
        txtCPOMoisture.Text = String.Empty
        txtCPODirt.Text = String.Empty
        txtCPOTemperature.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnCPOAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnCPOAdd.Text = "Menambahkan"
        End If

        lbtnAddCPO = "Add"
        'btnCPOAdd.Text = "Add"
        lDispatchDetailID = ""
    End Sub
    Public Sub ClearPKO()
        PKOBfQty = 0
        txtPKOMillWeight.Text = String.Empty
        txtPKOBAPNo.Text = String.Empty
        txtPKOShipPontoon.Text = String.Empty
        cmbPKOLoadingLocation.SelectedIndex = 0
        Datefunction()
        grpPKO.Enabled = True
        DeleteMultientryCPO.Clear()
        If GlobalPPT.strLang = "en" Then
            btnSaveCPO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveCPO.Text = "Simpan"
        End If


        ''btnSaveCPO.Text = "Save"
        lbtnsavePKO = "Save All"
        'GetPKOLocationValues()
        SearchDispatch()
        dtpPKODate.Enabled = True
        dtpPKODate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpPKODOA.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpPKODOL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpPKODCL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpPKODepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpPKODepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)

        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        dtpPKODate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpPKODOA.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpPKODOL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpPKODCL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpPKODepature.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtpViewDispatchDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)


        dtpPKODate.Value = Date.Today
        dtpPKODOA.Value = Date.Today
        dtpPKODOL.Value = Date.Today
        dtpPKODCL.Value = Date.Today
        dtpPKODepature.Value = Date.Today
        dtpPKODepature.Value = Date.Today

        If GlobalPPT.strLang = "en" Then
            btnSavePKO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSavePKO.Text = "Simpan"
        End If


        'btnSavePKO.Text = "Save"
        lbtnsavePKO = "Save All"
        If Not objUserLoginBOl.Privilege(btnSavePKO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub
    Public Sub ClearMultientryPKO()
        ' cmbPKOPosition.SelectedIndex = 0
        txtPKOFFA.Text = String.Empty
        txtPKOMoisture.Text = String.Empty
        txtPKODirt.Text = String.Empty
        txtPKOTemperature.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnPKOAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnPKOAdd.Text = "Menambahkan"
        End If

        lbtnAddPKO = "Add"
        ''btnPKOAdd.Text = "Add"
        lDispatchDetailID = ""

    End Sub
    Public Sub ClearKernel()
        txtKernelMillWeight.Text = String.Empty
        Datefunction()
        grpKernel.Enabled = True
        If GlobalPPT.strLang = "en" Then
            btnSaveCPO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveCPO.Text = "Simpan"
        End If

        DeleteMultientryCPO.Clear()
        ''btnSaveCPO.Text = "Save"
        lBtnsaveKernel = "Save All"
        cmbKernelLoadingLocation.SelectedIndex = 0
        SearchDispatch()
        dtpKernelDate.Enabled = True
        dtpKernelDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpKernelDOA.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpKernelDOL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpKernelDCL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtpKernelDepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)


        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        dtpKernelDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpKernelDOA.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpKernelDOL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpKernelDCL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpKernelDepature.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtpViewDispatchDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

        dtpKernelDate.Value = Date.Today
        dtpKernelDOA.Value = Date.Today
        dtpKernelDOL.Value = Date.Today
        dtpKernelDCL.Value = Date.Today
        dtpKernelDepature.Value = Date.Today

        txtBuyerNameKernel.Text = String.Empty
        txtNoOrderInstruksiKernel.Text = String.Empty
        txtKontrakNoKernel.Text = String.Empty
        txtNoOrderPenyerahanKernel.Text = String.Empty
        txtJumlahKontrakKernel.Text = 0
        txtNoSimKernel.Text = String.Empty
        txtNoTrukKernel.Text = String.Empty
        txtNoKunciKernel.Text = String.Empty
        txtDriverNameKernel.Text = String.Empty
        txtTransporterNameKernel.Text = String.Empty


        If GlobalPPT.strLang = "en" Then
            btnSaveKernel.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveKernel.Text = "Simpan "
        End If

        ''btnSaveKernel.Text = "Save"
        lBtnsaveKernel = "Save All"
        If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub
    Public Sub ClearMultientryKernel()
        'cmbKernelPosition.SelectedIndex = 0
        txtKernelMoisture.Text = String.Empty
        txtKernelDirt.Text = String.Empty
        txtKernelTemperature.Text = String.Empty
        txtKernelBroken.Text = String.Empty
        lbtnAddKernel = "Add"
        If GlobalPPT.strLang = "en" Then
            btnKernalAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnKernalAdd.Text = "Menambahkan"
        End If
        ''btnKernalAdd.Text = "Add"
        lDispatchDetailID = ""
    End Sub

    Private Sub Datefunction()



        cmbCPODOAHrs.Text = TimeOfDay.Hour
        cmbCPODOLHrs.Text = TimeOfDay.Hour
        cmbCPODCLHrs.Text = TimeOfDay.Hour
        cmbCPODepatureHrs.Text = TimeOfDay.Hour

        cmbPKODOAHrs.Text = TimeOfDay.Hour
        cmbPKODOLHrs.Text = TimeOfDay.Hour
        cmbPKODCLHrs.Text = TimeOfDay.Hour
        cmbPKODepatureHrs.Text = TimeOfDay.Hour

        cmbKernelDOAHrs.Text = TimeOfDay.Hour
        cmbKernelDOLHrs.Text = TimeOfDay.Hour
        cmbKernelDCLHrs.Text = TimeOfDay.Hour
        cmbKernelDepatureHrs.Text = TimeOfDay.Hour

        If TimeOfDay.Minute < 5 Then
            cmbCPODOAMin.Text = "00"
            cmbCPODOLMin.Text = "00"
            cmbCPODCLMin.Text = "00"
            cmbCPODepatureMin.Text = "00"

            cmbPKODOAMin.Text = "00"
            cmbPKODOLMin.Text = "00"
            cmbPKODCLMin.Text = "00"
            cmbPKODepatureMin.Text = "00"

            cmbKernelDOAMin.Text = "00"
            cmbKernelDOLMin.Text = "00"
            cmbKernelDCLMin.Text = "00"
            cmbKernelDepatureMin.Text = "00"
        ElseIf TimeOfDay.Minute >= 5 And TimeOfDay.Minute < 10 Then
            cmbCPODOAMin.Text = "05"
            cmbCPODOLMin.Text = "05"
            cmbCPODCLMin.Text = "05"
            cmbCPODepatureMin.Text = "05"

            cmbPKODOAMin.Text = "05"
            cmbPKODOLMin.Text = "05"
            cmbPKODCLMin.Text = "05"
            cmbPKODepatureMin.Text = "05"

            cmbKernelDOAMin.Text = "05"
            cmbKernelDOLMin.Text = "05"
            cmbKernelDCLMin.Text = "05"
            cmbKernelDepatureMin.Text = "05"

        ElseIf TimeOfDay.Minute >= 10 And TimeOfDay.Minute < 15 Then
            cmbCPODOAMin.Text = "10"
            cmbCPODOLMin.Text = "10"
            cmbCPODCLMin.Text = "10"
            cmbCPODepatureMin.Text = "10"

            cmbPKODOAMin.Text = "10"
            cmbPKODOLMin.Text = "10"
            cmbPKODCLMin.Text = "10"
            cmbPKODepatureMin.Text = "10"

            cmbKernelDOAMin.Text = "10"
            cmbKernelDOLMin.Text = "10"
            cmbKernelDCLMin.Text = "10"
            cmbKernelDepatureMin.Text = "10"

        ElseIf TimeOfDay.Minute >= 15 And TimeOfDay.Minute < 20 Then
            cmbCPODOAMin.Text = "15"
            cmbCPODOLMin.Text = "15"
            cmbCPODCLMin.Text = "15"
            cmbCPODepatureMin.Text = "15"

            cmbPKODOAMin.Text = "15"
            cmbPKODOLMin.Text = "15"
            cmbPKODCLMin.Text = "15"
            cmbPKODepatureMin.Text = "15"

            cmbKernelDOAMin.Text = "15"
            cmbKernelDOLMin.Text = "15"
            cmbKernelDCLMin.Text = "15"
            cmbKernelDepatureMin.Text = "15"
        ElseIf TimeOfDay.Minute >= 20 And TimeOfDay.Minute < 25 Then
            cmbCPODOAMin.Text = "20"
            cmbCPODOLMin.Text = "20"
            cmbCPODCLMin.Text = "20"
            cmbCPODepatureMin.Text = "20"

            cmbPKODOAMin.Text = "20"
            cmbPKODOLMin.Text = "20"
            cmbPKODCLMin.Text = "20"
            cmbPKODepatureMin.Text = "20"

            cmbKernelDOAMin.Text = "20"
            cmbKernelDOLMin.Text = "20"
            cmbKernelDCLMin.Text = "20"
            cmbKernelDepatureMin.Text = "20"
        ElseIf TimeOfDay.Minute >= 25 And TimeOfDay.Minute < 30 Then
            cmbCPODOAMin.Text = "25"
            cmbCPODOLMin.Text = "25"
            cmbCPODCLMin.Text = "25"
            cmbCPODepatureMin.Text = "25"

            cmbPKODOAMin.Text = "25"
            cmbPKODOLMin.Text = "25"
            cmbPKODCLMin.Text = "25"
            cmbPKODepatureMin.Text = "25"

            cmbKernelDOAMin.Text = "25"
            cmbKernelDOLMin.Text = "25"
            cmbKernelDCLMin.Text = "25"
            cmbKernelDepatureMin.Text = "25"
        ElseIf TimeOfDay.Minute >= 30 And TimeOfDay.Minute < 35 Then
            cmbCPODOAMin.Text = "30"
            cmbCPODOLMin.Text = "30"
            cmbCPODCLMin.Text = "30"
            cmbCPODepatureMin.Text = "30"

            cmbPKODOAMin.Text = "30"
            cmbPKODOLMin.Text = "30"
            cmbPKODCLMin.Text = "30"
            cmbPKODepatureMin.Text = "30"

            cmbKernelDOAMin.Text = "30"
            cmbKernelDOLMin.Text = "30"
            cmbKernelDCLMin.Text = "30"
            cmbKernelDepatureMin.Text = "30"

        ElseIf TimeOfDay.Minute >= 35 And TimeOfDay.Minute < 40 Then
            cmbCPODOAMin.Text = "35"
            cmbCPODOLMin.Text = "35"
            cmbCPODCLMin.Text = "35"
            cmbCPODepatureMin.Text = "35"

            cmbPKODOAMin.Text = "35"
            cmbPKODOLMin.Text = "35"
            cmbPKODCLMin.Text = "35"
            cmbPKODepatureMin.Text = "35"

            cmbKernelDOAMin.Text = "35"
            cmbKernelDOLMin.Text = "35"
            cmbKernelDCLMin.Text = "35"
            cmbKernelDepatureMin.Text = "35"
        ElseIf TimeOfDay.Minute >= 40 And TimeOfDay.Minute < 45 Then
            cmbCPODOAMin.Text = "40"
            cmbCPODOLMin.Text = "40"
            cmbCPODCLMin.Text = "40"
            cmbCPODepatureMin.Text = "40"

            cmbPKODOAMin.Text = "40"
            cmbPKODOLMin.Text = "40"
            cmbPKODCLMin.Text = "40"
            cmbPKODepatureMin.Text = "40"

            cmbKernelDOAMin.Text = "40"
            cmbKernelDOLMin.Text = "40"
            cmbKernelDCLMin.Text = "40"
            cmbKernelDepatureMin.Text = "40"
        ElseIf TimeOfDay.Minute >= 45 And TimeOfDay.Minute < 50 Then
            cmbCPODOAMin.Text = "45"
            cmbCPODOLMin.Text = "45"
            cmbCPODCLMin.Text = "45"
            cmbCPODepatureMin.Text = "45"

            cmbPKODOAMin.Text = "45"
            cmbPKODOLMin.Text = "45"
            cmbPKODCLMin.Text = "45"
            cmbPKODepatureMin.Text = "45"

            cmbKernelDOAMin.Text = "45"
            cmbKernelDOLMin.Text = "45"
            cmbKernelDCLMin.Text = "45"
            cmbKernelDepatureMin.Text = "45"

        ElseIf TimeOfDay.Minute >= 50 And TimeOfDay.Minute < 55 Then
            cmbCPODOAMin.Text = "50"
            cmbCPODOLMin.Text = "50"
            cmbCPODCLMin.Text = "50"
            cmbCPODepatureMin.Text = "50"

            cmbPKODOAMin.Text = "50"
            cmbPKODOLMin.Text = "50"
            cmbPKODCLMin.Text = "50"
            cmbPKODepatureMin.Text = "50"

            cmbKernelDOAMin.Text = "50"
            cmbKernelDOLMin.Text = "50"
            cmbKernelDCLMin.Text = "50"
            cmbKernelDepatureMin.Text = "50"
        ElseIf TimeOfDay.Minute >= 55 And TimeOfDay.Minute < 60 Then
            cmbCPODOAMin.Text = "55"
            cmbCPODOLMin.Text = "55"
            cmbCPODCLMin.Text = "55"
            cmbCPODepatureMin.Text = "55"

            cmbPKODOAMin.Text = "55"
            cmbPKODOLMin.Text = "55"
            cmbPKODCLMin.Text = "55"
            cmbPKODepatureMin.Text = "55"

            cmbKernelDOAMin.Text = "55"
            cmbKernelDOLMin.Text = "55"
            cmbKernelDCLMin.Text = "55"
            cmbKernelDepatureMin.Text = "55"
        End If
    End Sub

    Private Sub GetProductIDValues()
        Dim ds As New DataSet
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDisPatchBOL As New DispatchBOL
        ds = DispatchBOL.GetProductIDValues(objDispatchPPT)

        If ds.Tables(0).Rows.Count = 0 Then
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Records Available for CPO ,PKO AND Kernel,Please insert the Record in Weighbridge Product Master")
        Else
            If ds.Tables(0).Rows(0).Item("CPOProductID") Is DBNull.Value Then
                DisplayInfoMessage("Msg2")
                ''MsgBox("No Records Available for CPO,Please insert the Record in Weighbridge Product Master")
            ElseIf ds.Tables(0).Rows(0).Item("CPOProductID") <> String.Empty Then
                lCPOProductID = ds.Tables(0).Rows(0).Item("CPOProductID")
            End If

            If ds.Tables(0).Rows(0).Item("PKOProductID") Is DBNull.Value Then
                DisplayInfoMessage("Msg3")
                ''MsgBox("No Records Available for PKO,Please insert the Record in Weighbridge Product Master")
            ElseIf ds.Tables(0).Rows(0).Item("PKOProductID") <> String.Empty Then
                lPKOProductID = ds.Tables(0).Rows(0).Item("PKOProductID")
            End If

            If ds.Tables(0).Rows(0).Item("KernelProductID") Is DBNull.Value Then
                DisplayInfoMessage("Msg4")
                ''MsgBox("No Records Available for Kernel,Please insert the Record in Weighbridge Product Master")
            ElseIf ds.Tables(0).Rows(0).Item("KernelProductID") <> String.Empty Then
                lKernelProductID = ds.Tables(0).Rows(0).Item("KernelProductID")
            End If
        End If

    End Sub
    Private Sub GetCPOLocationValues()

        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDisPatchBOL As New DispatchBOL
        'dtCPOLoading = DispatchBOL.GetLocationValues(objDispatchPPT)
        dtCPOLoading = DispatchBOL.GetTankMaster()

        If dtCPOLoading.Rows.Count = 0 Then
            DisplayInfoMessage("Msg5")
            ''MsgBox("No Records Available for Loading Location ,Please insert the Record in Production Loading Location")
        End If
        Dim dr As DataRow = dtCPOLoading.NewRow()
        'dr(0) = "--Select--"
        'dr(1) = "--Select--"
        'dtCPOLoading.Rows.InsertAt(dr, 0)
        cmbCPOLoadingLocation.DataSource = dtCPOLoading
        cmbCPOLoadingLocation.DisplayMember = "TankNo"
        cmbCPOLoadingLocation.ValueMember = "TankNo"
        cmbCPOLoadingLocation.SelectedIndex = 0


    End Sub
    Private Sub GetPKOLocationValues()

        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDisPatchBOL As New DispatchBOL
        'dtPKOLocation = DispatchBOL.GetLocationValues(objDispatchPPT)
        dtPKOLocation = DispatchBOL.GetTankMaster()

        'Dim dr As DataRow = dtPKOLocation.NewRow()
        'dr(1) = "--Select--"
        'dtPKOLocation.Rows.InsertAt(dr, 0)
        cmbPKOLoadingLocation.DataSource = dtPKOLocation
        cmbPKOLoadingLocation.DisplayMember = "TankNo"
        cmbPKOLoadingLocation.ValueMember = "TankNo"
        cmbPKOLoadingLocation.SelectedIndex = 0



    End Sub
    Private Sub GetKernelLocationValues()

        Dim objDispatchPPT As New DispatchPPT
        'Dim ObjDisPatchBOL As New DispatchBOL
        'dtKernelLocation = DispatchBOL.GetLocationValues(objDispatchPPT)

        'cmbKernelLoadingLocation.DataSource = dtKernelLocation
        dtKernelLocation = DispatchBOL.GetKernelStorage()

        cmbKernelLoadingLocation.DataSource = dtKernelLocation
        cmbKernelLoadingLocation.DisplayMember = "Code"
        cmbKernelLoadingLocation.ValueMember = "Code"
        cmbKernelLoadingLocation.SelectedIndex = 0

        'Dim dr As DataRow = dtKernelLocation.NewRow()
        'dr(1) = "--Select--"
        'dtKernelLocation.Rows.InsertAt(dr, 0)
        'cmbKernelLoadingLocation.DataSource = dtKernelLocation
        'cmbKernelLoadingLocation.DisplayMember = "LoadingLocationCode"
        'cmbKernelLoadingLocation.ValueMember = "LoadingLocationID"
        'cmbKernelLoadingLocation.SelectedIndex = 0


    End Sub
    Private Function CPOPositionExist(ByVal CPOPosition As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvCPO.Rows
                If CPOPosition = objDataGridViewRow.Cells("dgmeCPOPosition").Value.ToString() Then
                    cmbCPOPosition.SelectedIndex = 0
                    cmbCPOPosition.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function


    Private Sub AddMultipleEntryDataCPO()

        Dim intRowcount As Integer = dtCPO.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try


            'If dtpCPODate.Enabled = True Then
            '    With objDispatchPPT
            '        .ProductID = lCPOProductID
            '    End With
            '    Dim objCheckDuplicateRecord As Object = 0
            '    objDispatchPPT.DispatchDate = dtpCPODate.Value
            '    objCheckDuplicateRecord = ObjDispatchBOL.DuplicateDateCheck(objDispatchPPT)
            '    If (objCheckDuplicateRecord = 0) Then
            '        DisplayInfoMessage("Msg6")
            '        '' MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
            '        Exit Sub
            '    End If
            'End If
            objDispatchPPT.Position = cmbCPOPosition.Text

            If Not CPOPositionExist(objDispatchPPT.Position) Then
                rowMultipleEntryAddCPO = dtCPO.NewRow()
                If intRowcount = 0 And lbtnAddCPO = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnCPOAdd = New DataColumn("DispatchDetailID", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("Position", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("FFAP", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("MoistureP", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("Temp", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("BrokenKernel", System.Type.[GetType]("System.String"))
                        dtCPO.Columns.Add(columnCPOAdd)



                        rowMultipleEntryAddCPO("DispatchDetailID") = lDispatchDetailID
                        rowMultipleEntryAddCPO("Position") = cmbCPOPosition.Text
                        rowMultipleEntryAddCPO("FFAP") = txtCPOFFA.Text
                        rowMultipleEntryAddCPO("MoistureP") = txtCPOMoisture.Text
                        rowMultipleEntryAddCPO("DirtP") = txtCPODirt.Text
                        rowMultipleEntryAddCPO("Temp") = txtCPOTemperature.Text

                        dtCPO.Rows.InsertAt(rowMultipleEntryAddCPO, intRowcount)
                        dgvCPO.AutoGenerateColumns = False
                        '  grpCPO.Enabled = False
                        ' grpCPO.Enabled = False
                        'grpKernel.Enabled = False
                    Catch ex As Exception

                        If lDispatchDetailID <> String.Empty Then
                            rowMultipleEntryAddCPO("DispatchDetailID") = lDispatchDetailID
                        End If


                        rowMultipleEntryAddCPO("Position") = cmbCPOPosition.Text
                        If txtCPOFFA.Text <> String.Empty Then
                            rowMultipleEntryAddCPO("FFAP") = txtCPOFFA.Text
                        End If
                        If txtCPOMoisture.Text <> String.Empty Then
                            rowMultipleEntryAddCPO("MoistureP") = txtCPOMoisture.Text
                        End If
                        If txtCPODirt.Text <> String.Empty Then
                            rowMultipleEntryAddCPO("DirtP") = txtCPODirt.Text
                        End If
                        If txtCPOTemperature.Text <> String.Empty Then
                            rowMultipleEntryAddCPO("Temp") = txtCPOTemperature.Text
                        End If

                        dtCPO.Rows.InsertAt(rowMultipleEntryAddCPO, intRowcount)
                        dgvCPO.AutoGenerateColumns = False
                        ' grpCPO.Enabled = False
                        ' grpCPO.Enabled = False
                        'grpKernel.Enabled = False
                    End Try

                Else

                    If lDispatchDetailID <> String.Empty Then
                        rowMultipleEntryAddCPO("DispatchDetailID") = lDispatchDetailID
                    End If

                    rowMultipleEntryAddCPO("Position") = cmbCPOPosition.Text
                    If txtCPOFFA.Text <> String.Empty Then
                        rowMultipleEntryAddCPO("FFAP") = txtCPOFFA.Text
                    End If
                    If txtCPOMoisture.Text <> String.Empty Then
                        rowMultipleEntryAddCPO("MoistureP") = txtCPOMoisture.Text
                    End If
                    If txtCPODirt.Text <> String.Empty Then
                        rowMultipleEntryAddCPO("DirtP") = txtCPODirt.Text
                    End If
                    If txtCPOTemperature.Text <> String.Empty Then
                        rowMultipleEntryAddCPO("Temp") = txtCPOTemperature.Text
                    End If
                    dtCPO.Rows.InsertAt(rowMultipleEntryAddCPO, intRowcount)
                    dgvCPO.AutoGenerateColumns = False
                    'grpCPO.Enabled = False
                    ' grpCPO.Enabled = False
                    'grpKernel.Enabled = False
                End If

                dgvCPO.DataSource = dtCPO
                dgvCPO.AutoGenerateColumns = False
                ClearMultientryCPO()
                cmbCPOPosition.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Position  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesCPO()

        If dgvCPO.RowCount > 0 Then

            ClearMultientryCPO()

            If GlobalPPT.strLang = "en" Then
                btnCPOAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnCPOAdd.Text = "Memperbarui"
            End If
            ''btnCPOAdd.Text = "Update"
            lbtnAddCPO = "Update"

            If Not lbtnsaveCPO = "Save All" Then
                If dgvCPO.SelectedRows(0).Cells("dgMeCPODispatchDetailID").Value IsNot Nothing Or dgvCPO.SelectedRows(0).Cells("dgMeCPODispatchDetailID").Value.ToString <> String.Empty Then
                    Me.lDispatchDetailID = dgvCPO.SelectedRows(0).Cells("dgMeCPODispatchDetailID").Value.ToString
                End If
            End If
            Me.cmbCPOPosition.Text = Me.dgvCPO.SelectedRows(0).Cells("dgmeCPOPosition").Value.ToString
            lCPOPosition = Me.dgvCPO.SelectedRows(0).Cells("dgmeCPOPosition").Value.ToString
            If Me.dgvCPO.SelectedRows(0).Cells("dgmeCPOFFA").Value.ToString <> String.Empty Then
                txtCPOFFA.Text = Me.dgvCPO.SelectedRows(0).Cells("dgmeCPOFFA").Value.ToString
            End If
            If Me.dgvCPO.SelectedRows(0).Cells("dgMeCPOMoisture").Value.ToString <> String.Empty Then
                txtCPOMoisture.Text = Me.dgvCPO.SelectedRows(0).Cells("dgMeCPOMoisture").Value.ToString
            End If
            If Me.dgvCPO.SelectedRows(0).Cells("dgMeCPODirt").Value.ToString <> String.Empty Then
                txtCPODirt.Text = Me.dgvCPO.SelectedRows(0).Cells("dgMeCPODirt").Value.ToString
            End If
            If Me.dgvCPO.SelectedRows(0).Cells("dgMeCPOTemp").Value.ToString <> String.Empty Then
                txtCPOTemperature.Text = Me.dgvCPO.SelectedRows(0).Cells("dgMeCPOTemp").Value.ToString()
            End If
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub
    Private Sub UpDateMultipleEntryDataCPO()

        ' Dim intRowcount As Integer = dgvCPO.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try


            objDispatchPPT.Position = cmbCPOPosition.Text



            If lCPOPosition = cmbCPOPosition.Text Then
                Dim intCount As Integer = dgvCPO.CurrentRow.Index
                dgvCPO.Rows(intCount).Cells("dgMeCPODispatchDetailID").Value = lDispatchDetailID
                dgvCPO.Rows(intCount).Cells("dgmeCPOPosition").Value = cmbCPOPosition.Text
                If txtCPOFFA.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgmeCPOFFA").Value = txtCPOFFA.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgmeCPOFFA").Value = DBNull.Value
                End If
                If txtCPOMoisture.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgMeCPOMoisture").Value = txtCPOMoisture.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgMeCPOMoisture").Value = DBNull.Value
                End If
                If txtCPODirt.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgMeCPODirt").Value = txtCPODirt.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgMeCPODirt").Value = DBNull.Value
                End If

                If txtCPOTemperature.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgMeCPOTemp").Value = txtCPOTemperature.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgMeCPOTemp").Value = DBNull.Value
                End If


                'dtCPO.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                'dgvCPO.DataSource = dtCPO
                'dgvCPO.AutoGenerateColumns = False
                'grpCPO.Enabled = False
                ClearMultientryCPO()
                cmbCPOPosition.SelectedIndex = 0
            ElseIf Not CPOPositionExist(objDispatchPPT.Position) Then
                Dim intCount As Integer = dgvCPO.CurrentRow.Index

                dgvCPO.Rows(intCount).Cells("dgMeCPODispatchDetailID").Value = lDispatchDetailID
                dgvCPO.Rows(intCount).Cells("dgmeCPOPosition").Value = cmbCPOPosition.Text
                If txtCPOFFA.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgmeCPOFFA").Value = txtCPOFFA.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgmeCPOFFA").Value = DBNull.Value
                End If
                If txtCPOMoisture.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgMeCPOMoisture").Value = txtCPOMoisture.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgMeCPOMoisture").Value = DBNull.Value
                End If
                If txtCPODirt.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgMeCPODirt").Value = txtCPODirt.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgMeCPODirt").Value = DBNull.Value
                End If

                If txtCPOTemperature.Text <> String.Empty Then
                    dgvCPO.Rows(intCount).Cells("dgMeCPOTemp").Value = txtCPOTemperature.Text
                Else
                    dgvCPO.Rows(intCount).Cells("dgMeCPOTemp").Value = DBNull.Value
                End If

                'dtCPO.Rows.InsertAt(rowMultipleEntryAdd, intRowcount)
                'dgvCPO.DataSource = dtCPO
                'dgvCPO.AutoGenerateColumns = False
                'grpCPO.Enabled = False
                ClearMultientryCPO()
                cmbCPOPosition.SelectedIndex = 0

            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Position  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesPKO()

        If dgvPKO.RowCount > 0 Then

            ClearMultientryPKO()

            If GlobalPPT.strLang = "en" Then
                btnPKOAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnPKOAdd.Text = "Memperbarui"
            End If
            ''btnPKOAdd.Text = "Update"
            lbtnAddPKO = "Update"

            If Not lbtnsavePKO = "Save All" Then
                If dgvPKO.SelectedRows(0).Cells("dgMePKODispatchDetailID").Value IsNot Nothing Or dgvPKO.SelectedRows(0).Cells("dgMePKODispatchDetailID").Value.ToString <> String.Empty Then
                    Me.lDispatchDetailID = dgvPKO.SelectedRows(0).Cells("dgMePKODispatchDetailID").Value.ToString
                End If
            End If
            Me.cmbPKOPosition.Text = Me.dgvPKO.SelectedRows(0).Cells("dgmePKOPosition").Value.ToString
            lPKOPosition = Me.dgvPKO.SelectedRows(0).Cells("dgmePKOPosition").Value.ToString
            If Me.dgvPKO.SelectedRows(0).Cells("dgmePKOFFA").Value.ToString <> String.Empty Then
                txtPKOFFA.Text = Me.dgvPKO.SelectedRows(0).Cells("dgmePKOFFA").Value.ToString
            End If
            If Me.dgvPKO.SelectedRows(0).Cells("dgMePKOMoisture").Value.ToString <> String.Empty Then
                txtPKOMoisture.Text = Me.dgvPKO.SelectedRows(0).Cells("dgMePKOMoisture").Value.ToString
            End If
            If Me.dgvPKO.SelectedRows(0).Cells("dgMePKODirt").Value.ToString <> String.Empty Then
                txtPKODirt.Text = Me.dgvPKO.SelectedRows(0).Cells("dgMePKODirt").Value.ToString
            End If
            If Me.dgvPKO.SelectedRows(0).Cells("dgMePKOTemp").Value.ToString <> String.Empty Then
                txtPKOTemperature.Text = Me.dgvPKO.SelectedRows(0).Cells("dgMePKOTemp").Value.ToString()
            End If
        End If

    End Sub
    Private Sub UpDateMultipleEntryDataPKO()

        Dim intRowcount As Integer = dgvPKO.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try


            objDispatchPPT.Position = cmbPKOPosition.Text

            If lPKOPosition = cmbPKOPosition.Text Then
                Dim intCount As Integer = dgvPKO.CurrentRow.Index
                dgvPKO.Rows(intCount).Cells("dgMePKODispatchDetailID").Value = lDispatchDetailID
                dgvPKO.Rows(intCount).Cells("dgmePKOPosition").Value = cmbPKOPosition.Text
                If txtPKOFFA.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgmePKOFFA").Value = txtPKOFFA.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgmePKOFFA").Value = DBNull.Value
                End If
                If txtPKOMoisture.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgMePKOMoisture").Value = txtPKOMoisture.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgMePKOMoisture").Value = DBNull.Value
                End If
                If txtPKODirt.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgMePKODirt").Value = txtPKODirt.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgMePKODirt").Value = DBNull.Value
                End If
                If txtPKOTemperature.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgMePKOTemp").Value = txtPKOTemperature.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgMePKOTemp").Value = DBNull.Value
                End If

                ClearMultientryPKO()
                cmbPKOPosition.SelectedIndex = 0
            ElseIf Not PKOPositionExist(objDispatchPPT.Position) Then
                Dim intCount As Integer = dgvPKO.CurrentRow.Index

                dgvPKO.Rows(intCount).Cells("dgMePKODispatchDetailID").Value = lDispatchDetailID
                dgvPKO.Rows(intCount).Cells("dgmePKOPosition").Value = cmbPKOPosition.Text
                If txtPKOFFA.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgmePKOFFA").Value = txtPKOFFA.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgmePKOFFA").Value = DBNull.Value
                End If
                If txtPKOMoisture.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgMePKOMoisture").Value = txtPKOMoisture.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgMePKOMoisture").Value = DBNull.Value
                End If
                If txtPKODirt.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgMePKODirt").Value = txtPKODirt.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgMePKODirt").Value = DBNull.Value
                End If
                If txtPKOTemperature.Text <> String.Empty Then
                    dgvPKO.Rows(intCount).Cells("dgMePKOTemp").Value = txtPKOTemperature.Text
                Else
                    dgvPKO.Rows(intCount).Cells("dgMePKOTemp").Value = DBNull.Value
                End If

                ClearMultientryPKO()
                cmbPKOPosition.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                'MsgBox("Position  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MultipleDateEntryValuesKernel()

        If dgvKernel.RowCount > 0 Then

            ClearMultientryKernel()

            If GlobalPPT.strLang = "en" Then
                btnKernalAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnKernalAdd.Text = "Memperbarui"
            End If
            ''btnKernalAdd.Text = "Update"
            lbtnAddKernel = "Update"


            If Not lBtnsaveKernel = "Save All" Then
                If dgvKernel.SelectedRows(0).Cells("dgMeKernelDispatchDetailID").Value IsNot Nothing Or dgvKernel.SelectedRows(0).Cells("dgMeKernelDispatchDetailID").Value.ToString <> String.Empty Then
                    Me.lDispatchDetailID = dgvKernel.SelectedRows(0).Cells("dgMeKernelDispatchDetailID").Value.ToString
                End If
            End If
            Me.cmbKernelPosition.Text = Me.dgvKernel.SelectedRows(0).Cells("dgmeKernelPosition").Value.ToString
            lKernelPosition = Me.dgvKernel.SelectedRows(0).Cells("dgmeKernelPosition").Value.ToString

            If Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelMoisture").Value.ToString <> String.Empty Then
                txtKernelMoisture.Text = Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelMoisture").Value.ToString
            End If
            If Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelDirt").Value.ToString <> String.Empty Then
                txtKernelDirt.Text = Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelDirt").Value.ToString
            End If
            If Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelTemp").Value.ToString <> String.Empty Then
                txtKernelTemperature.Text = Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelTemp").Value.ToString()
            End If
            If Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelBrokenKernel").Value.ToString <> String.Empty Then
                txtKernelBroken.Text = Me.dgvKernel.SelectedRows(0).Cells("dgMeKernelBrokenKernel").Value.ToString()
            End If
        End If

    End Sub
    Private Sub UpDateMultipleEntryDataKernel()

        Dim intRowcount As Integer = dgvKernel.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try



            objDispatchPPT.Position = cmbKernelPosition.Text

            If lKernelPosition = cmbKernelPosition.Text Then
                Dim intCount As Integer = dgvKernel.CurrentRow.Index
                dgvKernel.Rows(intCount).Cells("dgMeKernelDispatchDetailID").Value = lDispatchDetailID
                dgvKernel.Rows(intCount).Cells("dgmeKernelPosition").Value = cmbKernelPosition.Text

                If txtKernelMoisture.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelMoisture").Value = txtKernelMoisture.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelMoisture").Value = DBNull.Value
                End If
                If txtKernelDirt.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelDirt").Value = txtKernelDirt.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelDirt").Value = DBNull.Value
                End If

                If txtKernelTemperature.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelTemp").Value = txtKernelTemperature.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelTemp").Value = DBNull.Value
                End If

                If txtKernelBroken.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelBrokenKernel").Value = txtKernelBroken.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelBrokenKernel").Value = DBNull.Value
                End If



                ClearMultientryKernel()
                cmbKernelPosition.SelectedIndex = 0
            ElseIf Not KernelPositionExist(objDispatchPPT.Position) Then
                Dim intCount As Integer = dgvKernel.CurrentRow.Index

                dgvKernel.Rows(intCount).Cells("dgMeKernelDispatchDetailID").Value = lDispatchDetailID
                dgvKernel.Rows(intCount).Cells("dgmeKernelPosition").Value = cmbKernelPosition.Text
                If txtKernelMoisture.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelMoisture").Value = txtKernelMoisture.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelMoisture").Value = DBNull.Value
                End If
                If txtKernelDirt.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelDirt").Value = txtKernelDirt.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelDirt").Value = DBNull.Value
                End If

                If txtKernelTemperature.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelTemp").Value = txtKernelTemperature.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelTemp").Value = DBNull.Value
                End If

                If txtKernelBroken.Text <> String.Empty Then
                    dgvKernel.Rows(intCount).Cells("dgMeKernelBrokenKernel").Value = txtKernelBroken.Text
                Else
                    dgvKernel.Rows(intCount).Cells("dgMeKernelBrokenKernel").Value = DBNull.Value
                End If


                ClearMultientryKernel()
                cmbKernelPosition.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Position  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DispatchFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (dgvCPO.Rows.Count > 0 Or dgvPKO.RowCount > 0 Or dgvKernel.RowCount > 0) And btnSaveCPO.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M93"
            End If
        End If
    End Sub

    Private Sub DispatchFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        'GlobalBOL.SetDateTimePicker(dtpCPODate)
        'GlobalBOL.SetDateTimePicker(dtpCPODOA)
        'GlobalBOL.SetDateTimePicker(dtpCPODOL)
        'GlobalBOL.SetDateTimePicker(dtpCPODCL)
        'GlobalBOL.SetDateTimePicker(dtpCPODepature)
        'GlobalBOL.SetDateTimePicker(dtpViewDispatchDate)
        'GlobalBOL.SetDateTimePicker(dtpPKODate)
        'GlobalBOL.SetDateTimePicker(dtpPKODOA)
        'GlobalBOL.SetDateTimePicker(dtpPKODOL)
        'GlobalBOL.SetDateTimePicker(dtpPKODCL)
        'GlobalBOL.SetDateTimePicker(dtpPKODepature)
        'GlobalBOL.SetDateTimePicker(dtpKernelDate)
        'GlobalBOL.SetDateTimePicker(dtpKernelDOA)
        'GlobalBOL.SetDateTimePicker(dtpKernelDOL)
        'GlobalBOL.SetDateTimePicker(dtpKernelDCL)
        'GlobalBOL.SetDateTimePicker(dtpKernelDepature)
        'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        SetUICulture(GlobalPPT.strLang)
        GetProductIDValues()
        GetCPOLocationValues()
        GetPKOLocationValues()
        GetKernelLocationValues()
        ClearCPO()
        ClearKernel()
        ClearPKO()
        ClearMultientryCPO()
        ClearMultientryKernel()
        ClearMultientryPKO()
        tpDispatch.SelectedTab = tbCPO
        dtpCPODate.Focus()
        chkDisPatchDate.Checked = False
        cmbDispatchSearch.SelectedIndex = 0
        cmbCPOPosition.SelectedIndex = 0
        cmbPKOPosition.SelectedIndex = 0
        cmbKernelPosition.SelectedIndex = 0
        tbMainfrm.SelectedIndex = 1

    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tbMainfrm.TabPages("MainTab").Text = rm.GetString("tbMainfrm.TabPages(MainTab).Text")
            'tbMainfrm.TabPages("tbView").Text = rm.GetString("tbMainfrm.TabPages(tbView).Text")


            ''lblCPODate.Text = rm.GetString("Date")
            ''lblCPOBAPNo.Text = rm.GetString("BAPNo")
            ''lblCPOShipPontoon.Text = rm.GetString("ShipPontoon")
            ''lblCPODOA.Text = rm.GetString("DateofArrival")
            ''lblCPODOL.Text = rm.GetString("DateofLoading")
            ''lblCPODCL.Text = rm.GetString("DatecompletedLoading")
            ''lblCPODepature.Text = rm.GetString("Departure")
            ''lblMillWeight.Text = rm.GetString("MillWeight")
            ''lblLoadingLocation.Text = rm.GetString("LoadingLocation")
            ''lblCPODOATime.Text = rm.GetString("Time")
            ''lblCPODOLTime.Text = rm.GetString("Time")
            ''lblCPODCLTime.Text = rm.GetString("Time")
            ''lblCPODepatureTime.Text = rm.GetString("Time")
            ''lblCPOPosition.Text = rm.GetString("Position")
            ''lblCPODirt.Text = rm.GetString("Dirt")
            ''lblCPOFFA.Text = rm.GetString("FFA")
            ''lblCPOTemp.Text = rm.GetString("Temperature")
            ''lblCPOMoisture.Text = rm.GetString("Moisture")

            'dgvCPO.Columns("dgmeCPOPosition").HeaderText = rm.GetString("Position")
            'dgvCPO.Columns("dgmeCPOFFA").HeaderText = rm.GetString("FFA")
            'dgvCPO.Columns("dgMeCPOMoisture").HeaderText = rm.GetString("Moisture")
            'dgvCPO.Columns("dgMeCPODirt").HeaderText = rm.GetString("Dirt")
            'dgvCPO.Columns("dgMeCPOTemp").HeaderText = rm.GetString("Temperature")

            btnCPOReset.Text = rm.GetString("Reset")
            btnCPOAdd.Text = rm.GetString("Add")
            btnCPOHeaderReset.Text = rm.GetString("Reset")
            btnPKOHeaderReset.Text = rm.GetString("Reset")
            btnKernelHeaderReset.Text = rm.GetString("Reset")
            btnCPOResetAll.Text = rm.GetString("Reset")
            btnPKOReset.Text = rm.GetString("Reset")
            btnResetPKO.Text = rm.GetString("Reset")



            ''lblPKODate.Text = rm.GetString("Date")
            ''lblPKOBAPNo.Text = rm.GetString("BAPNo")
            ''lblPKOShipPontoon.Text = rm.GetString("ShipPontoon")
            ''lblPKODOA.Text = rm.GetString("DateofArrival")
            ''lblPKODOL.Text = rm.GetString("DateofLoading")
            ''lblPKODCL.Text = rm.GetString("DatecompletedLoading")
            ''lblPKODepature.Text = rm.GetString("Departure")
            ''lblPKOMillWeight.Text = rm.GetString("MillWeight")
            ''lblPKOLoadingLocation.Text = rm.GetString("LoadingLocation")
            ''lblPKODOATime.Text = rm.GetString("Time")
            ''lblPKODOLTime.Text = rm.GetString("Time")
            ''lblPKODCLTime.Text = rm.GetString("Time")
            ''lblPKODepatureTime.Text = rm.GetString("Time")
            ''lblPKOPosition.Text = rm.GetString("Position")
            ''lblPKODirt.Text = rm.GetString("Dirt")
            ''lblPKOFFA.Text = rm.GetString("FFA")
            ''lblPKOTemp.Text = rm.GetString("Temperature")
            ''lblPKOMoisture.Text = rm.GetString("Moisture")

            'dgvPKO.Columns("dgmePKOPosition").HeaderText = rm.GetString("Position")
            'dgvPKO.Columns("dgmePKOFFA").HeaderText = rm.GetString("FFA")
            'dgvPKO.Columns("dgMePKOMoisture").HeaderText = rm.GetString("Moisture")
            'dgvPKO.Columns("dgMePKODirt").HeaderText = rm.GetString("Dirt")
            'dgvPKO.Columns("dgMePKOTemp").HeaderText = rm.GetString("Temperature")

            btnPKOReset.Text = rm.GetString("Reset")
            btnPKOAdd.Text = rm.GetString("Add")


            ''lblKernalDate.Text = rm.GetString("Date")
            ''lblKernalMillWeight.Text = rm.GetString("MillWeight")
            ''lblKernalLoadingLocation.Text = rm.GetString("LoadingLocation")
            ''lblKernalDOA.Text = rm.GetString("DateofArrival")
            ''lblKernalDOL.Text = rm.GetString("DateofLoading")
            ''lblKernalDCL.Text = rm.GetString("DatecompletedLoading")
            ''lblKernalDepature.Text = rm.GetString("Departure")
            ''lblKernalDOAtime.Text = rm.GetString("Time")
            ''lblKernalDOLTime.Text = rm.GetString("Time")
            ''lblKernalDCLTime.Text = rm.GetString("Time")
            ''lblKernelDepatureTime.Text = rm.GetString("Time")
            ''lblKernelPosition.Text = rm.GetString("Position")
            ''lblKernalDirt.Text = rm.GetString("Dirt")
            '' ''lblKernalFFA.Text = rm.GetString("FFA")
            ''lblKernalTemp.Text = rm.GetString("Temperature")
            ''lblKernelMoisture.Text = rm.GetString("Moisture")
            btnKernalReset.Text = rm.GetString("Reset")
            btnKernalAdd.Text = rm.GetString("Add")

            btnSaveKernel.Text = rm.GetString("Save")
            btnResetKernel.Text = rm.GetString("Reset")
            btnCloseKernel.Text = rm.GetString("Close")

            'dgvKernel.Columns("DgMeKernelPosition").HeaderText = rm.GetString("Position")
            'dgvKernel.Columns("dgmeKernelFFA").HeaderText = rm.GetString("FFA")
            'dgvKernel.Columns("dgMeKernelMoisture").HeaderText = rm.GetString("Moisture")
            'dgvKernel.Columns("dgMeKernelDirt").HeaderText = rm.GetString("Dirt")
            'dgvKernel.Columns("dgMeKernelTemp").HeaderText = rm.GetString("Temperature")

            'dgvKernel.Columns("DgMeKernelPosition").HeaderText = rm.GetString("Position")
            'dgvKernel.Columns("dgMeKernelMoisture").HeaderText = rm.GetString("Moisture")
            'dgvKernel.Columns("dgMeKernelDirt").HeaderText = rm.GetString("Dirt")
            'dgvKernel.Columns("dgMeKernelBrokenKernel").HeaderText = rm.GetString("BrokenKernel")
            'dgvKernel.Columns("dgMeKernelTemp").HeaderText = rm.GetString("Temperature")

            btnSaveCPO.Text = rm.GetString("Save")
            btnResetCPO.Text = rm.GetString("Reset")
            btnCloseCPO.Text = rm.GetString("Close")
            ''lblsearchBy.Text = rm.GetString("SearchBy")
            'chkDisPatchDate.Text = rm.GetString("Date")
            ' ''lblDispatchType.Text = rm.GetString("Type")
            'dgvViewDispatch.Columns("dgViewDispatchType").HeaderText = rm.GetString("Type")
            'dgvViewDispatch.Columns("dgviewDispatchDate").HeaderText = rm.GetString("Date")
            btnSearch.Text = rm.GetString("ViewSearch")
            btnviewReport.Text = rm.GetString("ViewReports")
        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DispatchFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub btnCPOAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCPOAdd.Click


        If Me.cmbCPOPosition.Text = "--Select--" Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("This Field Required", "Position")
            cmbCPOPosition.Focus()
            Exit Sub
        End If

        If lbtnAddCPO <> "Update" Then
            AddMultipleEntryDataCPO()

        Else
            UpDateMultipleEntryDataCPO()

        End If


    End Sub

    Private Sub btnCPOReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCPOReset.Click
        'ClearGridView(dgvCPO)
        cmbCPOPosition.SelectedIndex = 0
        ClearMultientryCPO()
    End Sub

    Private Function PKOPositionExist(ByVal PKOPosition As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvPKO.Rows
                If PKOPosition = objDataGridViewRow.Cells("dgmePKOPosition").Value.ToString() Then
                    cmbPKOPosition.SelectedIndex = 0
                    cmbPKOPosition.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function


    Private Sub AddMultipleEntryDataPKO()

        Dim intRowcount As Integer = dtPKO.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try


            'If dtpPKODate.Enabled = True Then
            '    With objDispatchPPT
            '        .ProductID = lPKOProductID
            '    End With
            '    Dim objCheckDuplicateRecord As Object = 0
            '    objDispatchPPT.DispatchDate = dtpPKODate.Value
            '    objCheckDuplicateRecord = ObjDispatchBOL.DuplicateDateCheck(objDispatchPPT)
            '    If (objCheckDuplicateRecord = 0) Then
            '        DisplayInfoMessage("Msg8")
            '        ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
            '        Exit Sub
            '    End If
            'End If
            objDispatchPPT.Position = cmbPKOPosition.Text

            If Not PKOPositionExist(objDispatchPPT.Position) Then
                rowMultipleEntryAddPKO = dtPKO.NewRow()
                If intRowcount = 0 And lbtnAddPKO = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnPKOAdd = New DataColumn("DispatchDetailID", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("Position", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("FFAP", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("MoistureP", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("Temp", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("BrokenKernel", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)
                        columnPKOAdd = New DataColumn("DispatchDetailID", System.Type.[GetType]("System.String"))
                        dtPKO.Columns.Add(columnPKOAdd)


                        rowMultipleEntryAddPKO("DispatchDetailID") = lDispatchDetailID
                        rowMultipleEntryAddPKO("Position") = cmbPKOPosition.Text
                        rowMultipleEntryAddPKO("FFAP") = txtPKOFFA.Text
                        rowMultipleEntryAddPKO("MoistureP") = txtPKOMoisture.Text
                        rowMultipleEntryAddPKO("DirtP") = txtPKODirt.Text
                        rowMultipleEntryAddPKO("Temp") = txtPKOTemperature.Text

                        dtPKO.Rows.InsertAt(rowMultipleEntryAddPKO, intRowcount)
                        dgvPKO.AutoGenerateColumns = False
                        ' grpPKO.Enabled = False
                        ' grpCPO.Enabled = False
                        'grpKernel.Enabled = False
                    Catch ex As Exception
                        If lDispatchDetailID <> String.Empty Then
                            rowMultipleEntryAddPKO("DispatchDetailID") = lDispatchDetailID
                        End If

                        rowMultipleEntryAddPKO("Position") = cmbPKOPosition.Text
                        If txtPKOFFA.Text <> String.Empty Then
                            rowMultipleEntryAddPKO("FFAP") = txtPKOFFA.Text
                        End If
                        If txtPKOMoisture.Text <> String.Empty Then
                            rowMultipleEntryAddPKO("MoistureP") = txtPKOMoisture.Text
                        End If
                        If txtPKODirt.Text <> String.Empty Then
                            rowMultipleEntryAddPKO("DirtP") = txtPKODirt.Text
                        End If
                        If txtPKOTemperature.Text <> String.Empty Then
                            rowMultipleEntryAddPKO("Temp") = txtPKOTemperature.Text
                        End If
                        dtPKO.Rows.InsertAt(rowMultipleEntryAddPKO, intRowcount)
                        dgvPKO.AutoGenerateColumns = False
                        ' grpPKO.Enabled = False
                        ' grpCPO.Enabled = False
                        'grpKernel.Enabled = False
                    End Try

                Else
                    If lDispatchDetailID <> String.Empty Then
                        rowMultipleEntryAddPKO("DispatchDetailID") = lDispatchDetailID
                    End If


                    rowMultipleEntryAddPKO("Position") = cmbPKOPosition.Text
                    If txtPKOFFA.Text <> String.Empty Then
                        rowMultipleEntryAddPKO("FFAP") = txtPKOFFA.Text
                    End If
                    If txtPKOMoisture.Text <> String.Empty Then
                        rowMultipleEntryAddPKO("MoistureP") = txtPKOMoisture.Text
                    End If
                    If txtPKODirt.Text <> String.Empty Then
                        rowMultipleEntryAddPKO("DirtP") = txtPKODirt.Text
                    End If
                    If txtPKOTemperature.Text <> String.Empty Then
                        rowMultipleEntryAddPKO("Temp") = txtPKOTemperature.Text
                    End If
                    dtPKO.Rows.InsertAt(rowMultipleEntryAddPKO, intRowcount)
                    dgvPKO.AutoGenerateColumns = False
                    ' grpPKO.Enabled = False
                    ' grpCPO.Enabled = False
                    'grpKernel.Enabled = False
                End If

                dgvPKO.DataSource = dtPKO
                dgvPKO.AutoGenerateColumns = False
                ClearMultientryPKO()
                cmbPKOPosition.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Position  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnPKOAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPKOAdd.Click

        If Me.cmbPKOPosition.Text = "--Select--" Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("This Field Required", "Position")
            cmbPKOPosition.Focus()
            Exit Sub
        End If

        If lbtnAddPKO <> "Update" Then
            AddMultipleEntryDataPKO()

        Else
            UpDateMultipleEntryDataPKO()

        End If


    End Sub

    Private Sub btnPKOReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPKOReset.Click
        ClearMultientryPKO()
        cmbCPOPosition.SelectedIndex = 0
    End Sub
    Private Function KernelPositionExist(ByVal KernelPosition As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvKernel.Rows
                If KernelPosition = objDataGridViewRow.Cells("dgmeKernelPosition").Value.ToString() Then
                    cmbKernelPosition.SelectedIndex = 0
                    cmbKernelPosition.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function


    Private Sub AddMultipleEntryDataKernel()

        Dim intRowcount As Integer = dtKernel.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try


            If dtpKernelDate.Enabled = True Then


                'With objDispatchPPT
                '    .ProductID = lKernelProductID
                'End With
                'Dim objCheckDuplicateRecord As Object = 0
                'objDispatchPPT.DispatchDate = dtpKernelDate.Value
                'objCheckDuplicateRecord = ObjDispatchBOL.DuplicateDateCheck(objDispatchPPT)
                'If (objCheckDuplicateRecord = 0) Then
                '    DisplayInfoMessage("Msg8")
                '    ''MessageBox.Show("Cannot add a record for Date. Please try again with a different Date.")
                '    Exit Sub
                'End If
            End If
            objDispatchPPT.Position = cmbKernelPosition.Text

            If Not KernelPositionExist(objDispatchPPT.Position) Then
                rowMultipleEntryAddKernel = dtKernel.NewRow()
                If intRowcount = 0 And lbtnAddKernel = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnKernelAdd = New DataColumn("DispatchDetailID", System.Type.[GetType]("System.String"))
                        dtKernel.Columns.Add(columnKernelAdd)
                        columnKernelAdd = New DataColumn("Position", System.Type.[GetType]("System.String"))
                        dtKernel.Columns.Add(columnKernelAdd)
                        columnKernelAdd = New DataColumn("MoistureP", System.Type.[GetType]("System.String"))
                        dtKernel.Columns.Add(columnKernelAdd)
                        columnKernelAdd = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtKernel.Columns.Add(columnKernelAdd)
                        columnKernelAdd = New DataColumn("BrokenKernel", System.Type.[GetType]("System.String"))
                        dtKernel.Columns.Add(columnKernelAdd)
                        columnKernelAdd = New DataColumn("Temp", System.Type.[GetType]("System.String"))
                        dtKernel.Columns.Add(columnKernelAdd)

                        rowMultipleEntryAddKernel("DispatchDetailID") = lDispatchDetailID
                        rowMultipleEntryAddKernel("Position") = cmbKernelPosition.Text
                        rowMultipleEntryAddKernel("MoistureP") = txtKernelMoisture.Text
                        rowMultipleEntryAddKernel("DirtP") = txtKernelDirt.Text
                        rowMultipleEntryAddKernel("BrokenKernel") = txtKernelBroken.Text
                        rowMultipleEntryAddKernel("Temp") = txtKernelTemperature.Text

                        dtKernel.Rows.InsertAt(rowMultipleEntryAddKernel, intRowcount)
                        dgvKernel.AutoGenerateColumns = False
                        'grpKernel.Enabled = False
                        'grpPKO.Enabled = False
                        'grpCPO.Enabled = False
                    Catch ex As Exception
                        If lDispatchDetailID <> String.Empty Then
                            rowMultipleEntryAddKernel("DispatchDetailID") = lDispatchDetailID
                        End If
                        rowMultipleEntryAddKernel("Position") = cmbKernelPosition.Text
                        If txtKernelMoisture.Text <> String.Empty Then
                            rowMultipleEntryAddKernel("MoistureP") = txtKernelMoisture.Text
                        End If
                        If txtKernelDirt.Text <> String.Empty Then
                            rowMultipleEntryAddKernel("DirtP") = txtKernelDirt.Text
                        End If
                        If txtKernelTemperature.Text <> String.Empty Then
                            rowMultipleEntryAddKernel("Temp") = txtKernelTemperature.Text
                        End If
                        If txtKernelBroken.Text <> String.Empty Then
                            rowMultipleEntryAddKernel("BrokenKernel") = txtKernelBroken.Text
                        End If

                        dtKernel.Rows.InsertAt(rowMultipleEntryAddKernel, intRowcount)
                        dgvKernel.AutoGenerateColumns = False
                        ' grpKernel.Enabled = False
                        'grpPKO.Enabled = False
                        'grpCPO.Enabled = False

                    End Try

                Else
                    If lDispatchDetailID <> String.Empty Then
                        rowMultipleEntryAddKernel("DispatchDetailID") = lDispatchDetailID
                    End If
                    rowMultipleEntryAddKernel("Position") = cmbKernelPosition.Text
                    If txtKernelMoisture.Text <> String.Empty Then
                        rowMultipleEntryAddKernel("MoistureP") = txtKernelMoisture.Text
                    End If
                    If txtKernelDirt.Text <> String.Empty Then
                        rowMultipleEntryAddKernel("DirtP") = txtKernelDirt.Text
                    End If
                    If txtKernelTemperature.Text <> String.Empty Then
                        rowMultipleEntryAddKernel("Temp") = txtKernelTemperature.Text
                    End If
                    If txtKernelBroken.Text <> String.Empty Then
                        rowMultipleEntryAddKernel("BrokenKernel") = txtKernelBroken.Text
                    End If


                    dtKernel.Rows.InsertAt(rowMultipleEntryAddKernel, intRowcount)
                    dgvKernel.AutoGenerateColumns = False
                    ' grpKernel.Enabled = False
                    'grpPKO.Enabled = False
                    'grpCPO.Enabled = False
                End If

                dgvKernel.DataSource = dtKernel
                dgvKernel.AutoGenerateColumns = False
                ClearMultientryKernel()
                cmbKernelPosition.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Position  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnKernalAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernalAdd.Click

        If Me.cmbKernelPosition.Text = "--Select--" Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("This Field Required", "Position")
            cmbKernelPosition.Focus()
            Exit Sub
        End If

        If lbtnAddKernel <> "Update" Then
            AddMultipleEntryDataKernel()

        Else
            UpDateMultipleEntryDataKernel()

        End If

    End Sub

    Private Sub btnKernalReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernalReset.Click
        ClearMultientryKernel()
        cmbKernelPosition.SelectedIndex = 0
    End Sub

    Private Sub SaveDatasCPO()

        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        With ObjDispatchPPT
            .ProductID = lCPOProductID
            .DispatchDate = Me.dtpCPODate.Value
            .BAPNo = Me.txtCPOBAPNo.Text
            '.ShipPontoon = txtCPOShipPontoon.Text
            .DOA = Me.dtpCPODOA.Value
            .DOL = Me.dtpCPODOL.Value
            .DCL = Me.dtpCPODCL.Value
            .DepatureDate = Me.dtpCPODepature.Value
            lHrs = cmbCPODOAHrs.Text
            lMin = cmbCPODOAMin.Text

            .DOATime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbCPODOLHrs.Text
            lMin = cmbCPODOLMin.Text

            .DOLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbCPODCLHrs.Text
            lMin = cmbCPODCLMin.Text

            .DCLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbCPODepatureHrs.Text
            lMin = cmbCPODepatureMin.Text

            .Depaturetime = " " & lHrs & ":" & lMin & " "
            .MillWeight = txtCPOMillWeight.Text
            If cmbCPOLoadingLocation.Text <> "--Select--" And cmbCPOLoadingLocation.Text <> "" Then
                .LoadingLocationID = cmbCPOLoadingLocation.SelectedValue.ToString
            Else
                .LoadingLocationID = ""
            End If
            .BuyerName = txtBuyerName.Text
            .KontrakNo = txtKontrakNo.Text
            .NoPenyerahan = txtNoOrderPenyerahan.Text
            .NoInstruksi = txtNoOrderInstruksi.Text
            If txtJumlahKontrak.Text = "" Then
                .JumlahKontrak = 0
            Else
                .JumlahKontrak = txtJumlahKontrak.Text
            End If
            .NoSim = txtNoSIM.Text
            .NoTruk = txtNoTrukTanki.Text
            .SealNo = txtNoSeal.Text
            .DriverName = txtDriverName.Text
            .TransporterNo = txtTransporterName.Text
            .SPBNo = txtSPBNo.Text
            .TermofSales = cmbTermofSales.Text
        End With
        Dim dsCPO As New DataSet
        dsCPO = DispatchBOL.SaveDispatch(ObjDispatchPPT)
        lDispatchID = dsCPO.Tables(0).Rows(0).Item("DispatchID")
        Dim ds As New DataSet

        For Each DataGridViewRow In dgvCPO.Rows
            Dim ObjDispatchPPTMe As New DispatchPPT
            Dim ObjDispatchBOLMe As New DispatchBOL
            With ObjDispatchPPTMe
                .DispatchID = lDispatchID
                .Position = DataGridViewRow.Cells("dgmeCPOPosition").Value.ToString()
                .FFAP = IIf(DataGridViewRow.Cells("dgmeCPOFFA").Value.ToString() = "", 0, DataGridViewRow.Cells("dgmeCPOFFA").Value.ToString())
                .MoistureP = IIf(DataGridViewRow.Cells("dgMeCPOMoisture").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeCPOMoisture").Value.ToString())
                .DirtP = IIf(DataGridViewRow.Cells("dgMeCPODirt").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeCPODirt").Value.ToString())
                .Temp = IIf(DataGridViewRow.Cells("DgMeCPOTemp").Value.ToString() = "", 0, DataGridViewRow.Cells("DgMeCPOTemp").Value.ToString())
                .BrokenKernel = 0
            End With

            ds = DispatchBOL.SaveDispatchDetail(ObjDispatchPPTMe)
        Next

        If ds Is Nothing Then
            DisplayInfoMessage("Msg10")
            ''MsgBox("Failed to save database")
        Else
            ClearCPO()
            ClearMultientryCPO()
            ClearGridView(dgvCPO)
            If cmbCPOLoadingLocation.Items.Count <> 0 Then
                cmbCPOLoadingLocation.SelectedIndex = 0
            End If
            DisplayInfoMessage("Msg11")
            ''MsgBox("CPO Data(s) Successfully Saved!")

        End If
        'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub UpDateDatasCPO()

        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        With ObjDispatchPPT
            .DispatchID = lDispatchID
            .ProductID = lCPOProductID
            .DispatchDate = Me.dtpCPODate.Value
            .BAPNo = Me.txtCPOBAPNo.Text
            '.ShipPontoon = txtCPOShipPontoon.Text
            .DOA = Me.dtpCPODOA.Value
            .DOL = Me.dtpCPODOL.Value
            .DCL = Me.dtpCPODCL.Value
            .DepatureDate = Me.dtpCPODepature.Value
            lHrs = cmbCPODOAHrs.Text
            lMin = cmbCPODOAMin.Text

            .DOATime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbCPODOLHrs.Text
            lMin = cmbCPODOLMin.Text

            .DOLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbCPODCLHrs.Text
            lMin = cmbCPODCLMin.Text

            .DCLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbCPODepatureHrs.Text
            lMin = cmbCPODepatureMin.Text

            .Depaturetime = " " & lHrs & ":" & lMin & " "
            .MillWeight = txtCPOMillWeight.Text
            If cmbCPOLoadingLocation.Text <> "--Select--" And cmbCPOLoadingLocation.Text <> "" Then
                .LoadingLocationID = cmbCPOLoadingLocation.SelectedValue.ToString
            Else
                .LoadingLocationID = ""
            End If
            .BuyerName = txtBuyerName.Text
            .KontrakNo = txtKontrakNo.Text
            .NoPenyerahan = txtNoOrderPenyerahan.Text
            .NoInstruksi = txtNoOrderInstruksi.Text
            If txtJumlahKontrak.Text = "" Then
                .JumlahKontrak = 0
            Else
                .JumlahKontrak = txtJumlahKontrak.Text
            End If
            .NoSim = txtNoSIM.Text
            .NoTruk = txtNoTrukTanki.Text
            .SealNo = txtNoSeal.Text
            .DriverName = txtDriverName.Text
            .TransporterNo = txtTransporterName.Text
            .SPBNo = txtSPBNo.Text
            .TermofSales = cmbTermofSales.Text
        End With
        Dim dsCPO As New DataSet
        dsCPO = DispatchBOL.UpdateDispatch(ObjDispatchPPT)


        Dim ds As New DataSet
        For Each DataGridViewRow In dgvCPO.Rows
            Dim ObjDispatchPPTMe As New DispatchPPT
            Dim ObjDispatchBOLMe As New DispatchBOL
            With ObjDispatchPPTMe
                .DispatchID = lDispatchID
                .Position = DataGridViewRow.Cells("dgmeCPOPosition").Value.ToString()
                .FFAP = IIf(DataGridViewRow.Cells("dgmeCPOFFA").Value.ToString() = "", 0, DataGridViewRow.Cells("dgmeCPOFFA").Value.ToString())
                .MoistureP = IIf(DataGridViewRow.Cells("dgMeCPOMoisture").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeCPOMoisture").Value.ToString())
                .DirtP = IIf(DataGridViewRow.Cells("dgMeCPODirt").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeCPODirt").Value.ToString())
                .Temp = IIf(DataGridViewRow.Cells("DgMeCPOTemp").Value.ToString() = "", 0, DataGridViewRow.Cells("DgMeCPOTemp").Value.ToString())
                .BrokenKernel = 0
                If Not (DataGridViewRow.Cells("dgMeCPODispatchDetailID").Value.ToString() = "" Or DataGridViewRow.Cells("dgMeCPODispatchDetailID").Value Is DBNull.Value) Then
                    .DispatchDetailID = IIf(DataGridViewRow.Cells("dgMeCPODispatchDetailID").Value.ToString() = "", DBNull.Value, DataGridViewRow.Cells("dgMeCPODispatchDetailID").Value.ToString())
                Else
                    .DispatchDetailID = ""
                End If
            End With

            If ObjDispatchPPTMe.DispatchDetailID Is DBNull.Value Or ObjDispatchPPTMe.DispatchDetailID = "" Then
                ds = DispatchBOL.SaveDispatchDetail(ObjDispatchPPTMe)
            Else
                ds = DispatchBOL.UpDateDispatchDetail(ObjDispatchPPTMe)
            End If

        Next
        DeleteMultiEntryRecordsCPOPKOKernel()

        If ds Is Nothing Then
            DisplayInfoMessage("Msg12")
            ''MsgBox("Failed to save database")
        Else
            ClearCPO()
            ClearMultientryCPO()
            ClearGridView(dgvCPO)
            If cmbCPOLoadingLocation.Items.Count <> 0 Then
                cmbCPOLoadingLocation.SelectedIndex = 0
            End If
            DisplayInfoMessage("Msg13")
            ''MsgBox("CPO Data(s) Successfully Updated!")
            'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If
    End Sub
    Private Sub SaveDatasPKO()



        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        With ObjDispatchPPT
            .ProductID = lPKOProductID
            .DispatchDate = Me.dtpPKODate.Value
            .BAPNo = Me.txtPKOBAPNo.Text
            .ShipPontoon = txtPKOShipPontoon.Text
            .DOA = Me.dtpPKODOA.Value
            .DOL = Me.dtpPKODOL.Value
            .DCL = Me.dtpPKODCL.Value
            .DepatureDate = Me.dtpPKODepature.Value
            Dim lHrs, lMin As Integer

            lHrs = cmbPKODOAHrs.Text
            lMin = cmbPKODOAMin.Text

            .DOATime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbPKODOLHrs.Text
            lMin = cmbPKODOLMin.Text

            .DOLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbPKODCLHrs.Text
            lMin = cmbPKODCLMin.Text

            .DCLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbPKODepatureHrs.Text
            lMin = cmbPKODepatureMin.Text

            .Depaturetime = " " & lHrs & ":" & lMin & " "
            .MillWeight = txtPKOMillWeight.Text
            If cmbPKOLoadingLocation.Text <> "--Select--" And cmbPKOLoadingLocation.Text <> "" Then
                .LoadingLocationID = cmbPKOLoadingLocation.SelectedValue.ToString
            Else
                .LoadingLocationID = ""
            End If
        End With
        Dim dsPKO As New DataSet
        dsPKO = DispatchBOL.SaveDispatch(ObjDispatchPPT)
        lDispatchID = dsPKO.Tables(0).Rows(0).Item("DispatchID")

        Dim ds As New DataSet
        For Each DataGridViewRow In dgvPKO.Rows
            Dim ObjDispatchPPTMe As New DispatchPPT
            Dim ObjDispatchBOLMe As New DispatchBOL
            With ObjDispatchPPT
                .DispatchID = lDispatchID
                .Position = DataGridViewRow.Cells("dgmePKOPosition").Value.ToString()
                .FFAP = IIf(DataGridViewRow.Cells("dgmePKOFFA").Value.ToString() = "", 0, DataGridViewRow.Cells("dgmePKOFFA").Value.ToString())
                .MoistureP = IIf(DataGridViewRow.Cells("dgMePKOMoisture").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMePKOMoisture").Value.ToString())
                .DirtP = IIf(DataGridViewRow.Cells("dgMePKODirt").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMePKODirt").Value.ToString())
                .Temp = IIf(DataGridViewRow.Cells("DgMePKOTemp").Value.ToString() = "", 0, DataGridViewRow.Cells("DgMePKOTemp").Value.ToString())
                .BrokenKernel = 0
            End With
            ds = DispatchBOL.SaveDispatchDetail(ObjDispatchPPT)
        Next

        If ds Is Nothing Then
            DisplayInfoMessage("Msg12")
            ''MsgBox("Failed to save database")
        Else

            ClearPKO()
            ClearMultientryPKO()
            ClearGridView(dgvPKO)
            If cmbPKOLoadingLocation.Items.Count <> 0 Then
                cmbPKOLoadingLocation.SelectedIndex = 0
            End If
            DisplayInfoMessage("Msg15")
            ''MsgBox("PKO Data(s) Successfully Saved!")
            'If Not objUserLoginBOl.Privilege(btnSavePKO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If
    End Sub
    Private Sub UpDateDatasPKO()

        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        With ObjDispatchPPT
            .DispatchID = lDispatchID
            .ProductID = lPKOProductID
            .DispatchDate = Me.dtpPKODate.Value
            .BAPNo = Me.txtPKOBAPNo.Text
            .ShipPontoon = txtPKOShipPontoon.Text
            .DOA = Me.dtpPKODOA.Value
            .DOL = Me.dtpPKODOL.Value
            .DCL = Me.dtpPKODCL.Value
            .DepatureDate = Me.dtpPKODepature.Value
            Dim lHrs, lMin As Integer

            lHrs = cmbPKODOAHrs.Text
            lMin = cmbPKODOAMin.Text

            .DOATime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbPKODOLHrs.Text
            lMin = cmbPKODOLMin.Text

            .DOLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbPKODCLHrs.Text
            lMin = cmbPKODCLMin.Text

            .DCLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbPKODepatureHrs.Text
            lMin = cmbPKODepatureMin.Text

            .Depaturetime = " " & lHrs & ":" & lMin & " "
            .MillWeight = txtPKOMillWeight.Text
            If cmbPKOLoadingLocation.Text <> "--Select--" And cmbPKOLoadingLocation.Text <> "" Then
                .LoadingLocationID = cmbPKOLoadingLocation.SelectedValue.ToString
            Else
                .LoadingLocationID = ""
            End If
        End With
        Dim dsPKO As New DataSet
        dsPKO = DispatchBOL.UpdateDispatch(ObjDispatchPPT)


        Dim ds As New DataSet
        For Each DataGridViewRow In dgvPKO.Rows
            Dim ObjDispatchPPTMe As New DispatchPPT
            Dim ObjDispatchBOLMe As New DispatchBOL
            With ObjDispatchPPTMe
                .DispatchID = lDispatchID
                .Position = DataGridViewRow.Cells("dgmePKOPosition").Value.ToString()
                .FFAP = IIf(DataGridViewRow.Cells("dgmePKOFFA").Value.ToString() = "", 0, DataGridViewRow.Cells("dgmePKOFFA").Value.ToString())
                .MoistureP = IIf(DataGridViewRow.Cells("dgMePKOMoisture").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMePKOMoisture").Value.ToString())
                .DirtP = IIf(DataGridViewRow.Cells("dgMePKODirt").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMePKODirt").Value.ToString())
                .Temp = IIf(DataGridViewRow.Cells("DgMePKOTemp").Value.ToString() = "", 0, DataGridViewRow.Cells("DgMePKOTemp").Value.ToString())
                .BrokenKernel = 0
                Try
                    .DispatchDetailID = IIf(DataGridViewRow.Cells("dgMePKODispatchDetailID").Value.ToString() = "", DBNull.Value, DataGridViewRow.Cells("dgMePKODispatchDetailID").Value.ToString())
                Catch ex As Exception
                End Try


            End With

            If ObjDispatchPPTMe.DispatchDetailID Is DBNull.Value Or ObjDispatchPPTMe.DispatchDetailID = "" Then
                ds = DispatchBOL.SaveDispatchDetail(ObjDispatchPPTMe)
            Else
                ds = DispatchBOL.UpDateDispatchDetail(ObjDispatchPPTMe)
            End If
        Next

        DeleteMultiEntryRecordsCPOPKOKernel()
        If ds Is Nothing Then
            DisplayInfoMessage("Msg12")
            ''MsgBox("Failed to save database")
        Else

            ClearPKO()
            ClearMultientryPKO()
            ClearGridView(dgvPKO)
            If cmbPKOLoadingLocation.Items.Count <> 0 Then
                cmbPKOLoadingLocation.SelectedIndex = 0
            End If
            DisplayInfoMessage("Msg16")
            ''MsgBox("PKO Data(s) Successfully Updated!")
            'If Not objUserLoginBOl.Privilege(btnSavePKO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If
    End Sub

    Private Sub SaveDatasKernel()

        Dim dsKernel As New DataSet

        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        With ObjDispatchPPT
            .ProductID = lKernelProductID
            .DispatchDate = Me.dtpKernelDate.Value
            .BAPNo = ""
            .ShipPontoon = ""
            .DOA = Me.dtpKernelDOA.Value
            .DOL = Me.dtpKernelDOL.Value
            .DCL = Me.dtpKernelDCL.Value
            .DepatureDate = Me.dtpKernelDepature.Value
            Dim lHrs, lMin As Integer

            lHrs = cmbKernelDOAHrs.Text
            lMin = cmbKernelDOAMin.Text

            .DOATime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbKernelDOLHrs.Text
            lMin = cmbKernelDOLMin.Text

            .DOLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbKernelDCLHrs.Text
            lMin = cmbKernelDCLMin.Text

            .DCLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbKernelDepatureHrs.Text
            lMin = cmbKernelDepatureMin.Text

            .Depaturetime = " " & lHrs & ":" & lMin & " "
            .MillWeight = txtKernelMillWeight.Text
            If cmbKernelLoadingLocation.Text <> "--Select--" And cmbKernelLoadingLocation.Text <> "" Then
                .LoadingLocationID = cmbKernelLoadingLocation.SelectedValue.ToString
            Else
                .LoadingLocationID = ""
            End If
            .BuyerName = txtBuyerNameKernel.Text
            .KontrakNo = txtKontrakNoKernel.Text
            .NoPenyerahan = txtNoOrderPenyerahanKernel.Text
            .NoInstruksi = txtNoOrderInstruksiKernel.Text
            If txtJumlahKontrakKernel.Text = "" Then
                .JumlahKontrak = 0
            Else
                .JumlahKontrak = txtJumlahKontrakKernel.Text
            End If
            .NoSim = txtNoSIMKernel.Text
            .NoTruk = txtNoTrukKernel.Text
            .SealNo = txtNoKunciKernel.Text
            .DriverName = txtDriverNameKernel.Text
            .TransporterNo = txtTransporterNameKernel.Text
            .SPBNo = ""
            .TermofSales = ""
        End With

        dsKernel = DispatchBOL.SaveDispatch(ObjDispatchPPT, True)
        lDispatchID = dsKernel.Tables(0).Rows(0).Item("DispatchID")

        Dim ds As New DataSet

        For Each DataGridViewRow In dgvKernel.Rows
            Dim ObjDispatchPPTMe As New DispatchPPT
            Dim ObjDispatchBOLMe As New DispatchBOL
            With ObjDispatchPPT
                .DispatchID = lDispatchID
                .Position = DataGridViewRow.Cells("dgmeKernelPosition").Value.ToString()
                ' .FFAP = IIf(DataGridViewRow.Cells("dgmeKernelFFA").Value.ToString() = "", 0, DataGridViewRow.Cells("dgmeKernelFFA").Value.ToString())
                .MoistureP = IIf(DataGridViewRow.Cells("dgMeKernelMoisture").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeKernelMoisture").Value.ToString())
                .DirtP = IIf(DataGridViewRow.Cells("dgMeKernelDirt").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeKernelDirt").Value.ToString())
                .Temp = IIf(DataGridViewRow.Cells("dgMeKernelTemp").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeKernelTemp").Value.ToString())
                .BrokenKernel = IIf(DataGridViewRow.Cells("dgMeKernelBrokenKernel").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeKernelBrokenKernel").Value.ToString())
            End With
            ds = DispatchBOL.SaveDispatchDetail(ObjDispatchPPT)
        Next

        If ds Is Nothing Then
            DisplayInfoMessage("Msg12")
            ''MsgBox("Failed to save database")
        Else
            ClearKernel()
            ClearMultientryKernel()
            ClearGridView(dgvKernel)
            If cmbKernelLoadingLocation.Items.Count <> 0 Then
                cmbKernelLoadingLocation.SelectedIndex = 0
            End If
            DisplayInfoMessage("Msg17")
            '' MsgBox("Kernel Data(s) Successfully Saved!")
            'If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If
    End Sub
    Private Sub UpDateDatasKernel()
        Dim dsKernel As New DataSet

        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        With ObjDispatchPPT
            .DispatchID = lDispatchID
            .ProductID = lKernelProductID
            .DispatchDate = Me.dtpKernelDate.Value
            .BAPNo = ""
            .ShipPontoon = ""
            .DOA = Me.dtpKernelDOA.Value
            .DOL = Me.dtpKernelDOL.Value
            .DCL = Me.dtpKernelDCL.Value
            .DepatureDate = Me.dtpKernelDepature.Value
            Dim lHrs, lMin As Integer

            lHrs = cmbKernelDOAHrs.Text
            lMin = cmbKernelDOAMin.Text

            .DOATime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbKernelDOLHrs.Text
            lMin = cmbKernelDOLMin.Text

            .DOLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbKernelDCLHrs.Text
            lMin = cmbKernelDCLMin.Text

            .DCLTime = " " & lHrs & ":" & lMin & " "
            lHrs = cmbKernelDepatureHrs.Text
            lMin = cmbKernelDepatureMin.Text

            .Depaturetime = " " & lHrs & ":" & lMin & " "
            .MillWeight = txtKernelMillWeight.Text
            If cmbKernelLoadingLocation.Text <> "--Select--" And cmbKernelLoadingLocation.Text <> "" Then
                .LoadingLocationID = cmbKernelLoadingLocation.SelectedValue.ToString
            Else
                .LoadingLocationID = ""
            End If
            .BuyerName = txtBuyerNameKernel.Text
            .KontrakNo = txtKontrakNoKernel.Text
            .NoPenyerahan = txtNoOrderPenyerahanKernel.Text
            .NoInstruksi = txtNoOrderInstruksiKernel.Text
            If txtJumlahKontrakKernel.Text = "" Then
                .JumlahKontrak = 0
            Else
                .JumlahKontrak = txtJumlahKontrakKernel.Text
            End If
            .NoSim = txtNoSimKernel.Text
            .NoTruk = txtNoTrukKernel.Text
            .SealNo = txtNoKunciKernel.Text
            .DriverName = txtDriverNameKernel.Text
            .TransporterNo = txtTransporterNameKernel.Text
            .SPBNo = ""
            .TermofSales = ""
        End With

        dsKernel = DispatchBOL.UpdateDispatch(ObjDispatchPPT, True)

        Dim ds As New DataSet

        For Each DataGridViewRow In dgvKernel.Rows
            Dim ObjDispatchPPTMe As New DispatchPPT
            Dim ObjDispatchBOLMe As New DispatchBOL
            With ObjDispatchPPTMe
                .DispatchID = lDispatchID
                .Position = DataGridViewRow.Cells("dgmeKernelPosition").Value.ToString()
                ' .FFAP = IIf(DataGridViewRow.Cells("dgmeKernelFFA").Value.ToString() = "", 0, DataGridViewRow.Cells("dgmeKernelFFA").Value.ToString())
                .MoistureP = IIf(DataGridViewRow.Cells("dgMeKernelMoisture").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeKernelMoisture").Value.ToString())
                .DirtP = IIf(DataGridViewRow.Cells("dgMeKernelDirt").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeKernelDirt").Value.ToString())
                .Temp = IIf(DataGridViewRow.Cells("DgMeKernelTemp").Value.ToString() = "", 0, DataGridViewRow.Cells("DgMeKernelTemp").Value.ToString())
                .BrokenKernel = IIf(DataGridViewRow.Cells("DgMeKernelBrokenKernel").Value.ToString() = "", 0, DataGridViewRow.Cells("DgMeKernelBrokenKernel").Value.ToString())
                .DispatchDetailID = DataGridViewRow.Cells("dgMeKernelDispatchDetailID").Value.ToString()
                'If Not DataGridViewRow.Cells("dgMeKernelDispatchDetailID").Value.ToString() Is DBNull.Value Then
                '    .DispatchDetailID = IIf(DataGridViewRow.Cells("dgMeKernelDispatchDetailID").Value.ToString() = "", DBNull.Value, DataGridViewRow.Cells("dgMeKernelDispatchDetailID").Value.ToString())
                'End If
                
            End With

            If ObjDispatchPPTMe.DispatchDetailID = "" Then
                ds = DispatchBOL.SaveDispatchDetail(ObjDispatchPPTMe)
            Else
                ds = DispatchBOL.UpDateDispatchDetail(ObjDispatchPPTMe)
            End If


        Next
        DeleteMultiEntryRecordsCPOPKOKernel()
        If ds Is Nothing Then
            DisplayInfoMessage("Msg12")
            ''MsgBox("Failed to save database")
        Else
            ClearKernel()
            ClearMultientryKernel()
            ClearGridView(dgvKernel)
            If cmbKernelLoadingLocation.Items.Count <> 0 Then
                cmbKernelLoadingLocation.SelectedIndex = 0
            End If
            DisplayInfoMessage("Msg18")
            ''MsgBox("Kernel Data(s) Successfully Updated!")
            'If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            '    MsgBox(PrivilegeError)
            'End If
        End If
    End Sub


    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCPO.Click
        '  If dgvCPO.SelectedRows(0).Cells("dgmeCPOPosition").Value.ToString()
        If dgvCPO.RowCount <> 0 Then
            If Val(txtCPOMillWeight.Text) = 0 Then
                DisplayInfoMessage("Msg19")
                ''MessageBox.Show("This Field Required", "Mill Weight")
                txtCPOMillWeight.Focus()
                Exit Sub
            End If
            If CDbl(txtCPOMillWeight.Text) > CDbl(Me.lblCPOBFQty.Text) Then
                MsgBox("Dispatch Tidak Boleh Lebih Daripada Saldo")
                txtCPOMillWeight.Focus()
                Exit Sub
            End If
            If Me.txtCPOBAPNo.Text.Trim = "" Then
                DisplayInfoMessage("Msg20")
                '' MessageBox.Show("This Field Required", "BAP No.")
                txtCPOBAPNo.Focus()
                Exit Sub
            End If
            'If Me.txtCPOShipPontoon.Text.Trim = "" Then
            '    DisplayInfoMessage("Msg21")
            '    ''MessageBox.Show("This Field Required", "Ship Pontoon")
            '    txtCPOShipPontoon.Focus()
            '    Exit Sub
            'End If

            If lCPOProductID <> String.Empty Then
                If txtCPOMillWeight.Text <> String.Empty Then
                    'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                    '    Exit Sub
                    'End If

                    If lbtnsaveCPO = "Save All" Then
                        SaveDatasCPO()
                        GlobalPPT.IsRetainFocus = False
                    Else
                        UpDateDatasCPO()
                        GlobalPPT.IsRetainFocus = False

                        'If GlobalPPT.strLang = "en" Then
                        '    btnSaveCPO.Text = "Save"
                        'ElseIf GlobalPPT.strLang = "ms" Then
                        '    btnSaveCPO.Text = "Simpan"
                        'End If
                    End If
                    GetCPOLocationValues()
                    cmbCPOPosition.SelectedIndex = 0
                    lSelectedIndexCalc = True
                End If
            Else
                DisplayInfoMessage("Msg22")
                ''MsgBox("No Records Available for CPO ,Please insert the Record in Weighbridge Product Master")
                ClearCPO()
                ClearMultientryCPO()
                ClearGridView(dgvCPO)
            End If

        Else
            DisplayInfoMessage("Msg23")
            ''MsgBox("Please add the Record in Oil Quality")
        End If

        'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        'If Me.txtCPOMillWeight.Text = "" Then
        '    MessageBox.Show("This Field Required", "Mill Weight")
        '    txtCPOMillWeight.Focus()
        '    Exit Sub
        'End If
        'If Me.txtCPOBAPNo.Text = "" Then
        '    MessageBox.Show("This Field Required", "BAP No.")
        '    txtCPOBAPNo.Focus()
        '    Exit Sub
        'End If
        'If Me.txtCPOShipPontoon.Text = "" Then
        '    MessageBox.Show("This Field Required", "Ship Pontoon")
        '    txtCPOShipPontoon.Focus()
        '    Exit Sub
        'End If
        'If Me.cmbCPOPosition.Text = "--Select--" Then
        '    MessageBox.Show("This Field Required", "Position")
        '    cmbCPOPosition.Focus()
        '    Exit Sub
        'End If
        'End If

    End Sub
    Private Sub KeyDown3Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
                            is3Decimal = False
                            Return
                        End If

                        is3Decimal = True
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

                        is3Decimal = re3DecimalPlaces.IsMatch(text)

                End Select
            Else
                is3Decimal = False
                Return
            End If

        Else
            is3Decimal = True
        End If

    End Sub
    Private Sub KeyPress3Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is3Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub txtCPOMillWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOMillWeight.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtCPOMillWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOMillWeight.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtPKOMillWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOMillWeight.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtPKOMillWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOMillWeight.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKernelMillWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelMillWeight.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKernelMillWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelMillWeight.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub
    Private Sub KeyDown2Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
                            is2Decimal = False
                            Return
                        End If

                        is2Decimal = True
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

                        is2Decimal = re2DecimalPlaces.IsMatch(text)

                End Select
            Else
                is2Decimal = False
                Return
            End If

        Else
            is2Decimal = True
        End If

    End Sub
    Private Sub KeyPress2Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is2Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub
    Private Sub KeyDown2TempDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
                            is2TempDecimal = False
                            Return
                        End If

                        is2TempDecimal = True
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

                        is2TempDecimal = re2TempDecimalPlaces.IsMatch(text)

                End Select
            Else
                is2TempDecimal = False
                Return
            End If

        Else
            is2TempDecimal = True
        End If

    End Sub
    Private Sub KeyPress2TempDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is2TempDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub
    Private Sub txtCPOFFA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOFFA.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtCPOFFA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOFFA.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtCPOMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtCPOMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtCPODirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPODirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtCPODirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPODirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtCPOTemperature_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOTemperature.KeyDown
        KeyDown2TempDecimal(sender, e)
    End Sub

    Private Sub txtCPOTemperature_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOTemperature.KeyPress
        KeyPress2TempDecimal(sender, e)
    End Sub

    Private Sub txtPKOFFA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOFFA.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOFFA.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtPKOMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtPKOMoisture_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtPKODirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKODirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtPKODirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKODirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub


    Private Sub txtPKOTemperature_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOTemperature.KeyDown
        KeyDown2TempDecimal(sender, e)
    End Sub

    Private Sub txtPKOTemperature_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOTemperature.KeyPress
        KeyPress2TempDecimal(sender, e)
    End Sub

    Private Sub txtKernelFFA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKernelFFA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKernelMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKernelMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKernelDirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelDirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKernelDirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelDirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKernelBroken_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelBroken.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKernelBroken_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelBroken.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKernelTemperature_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelTemperature.KeyDown
        KeyDown2TempDecimal(sender, e)
    End Sub

    Private Sub txtKernelTemperature_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelTemperature.KeyPress
        KeyPress2TempDecimal(sender, e)
    End Sub


    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetCPO.Click

        ClearCPO()
        ClearMultientryCPO()
        ClearGridView(dgvCPO)
        dtpCPODate.Focus()
        cmbCPOPosition.SelectedIndex = 0
        ClearPKO()
        ClearMultientryPKO()
        ClearGridView(dgvPKO)
        dtpPKODate.Focus()
        cmbPKOPosition.SelectedIndex = 0
        ClearKernel()
        ClearMultientryKernel()
        ClearGridView(dgvKernel)
        dtpKernelDate.Focus()
        cmbKernelPosition.SelectedIndex = 0
        lbtnsaveCPO = "Save All"
        lbtnsavePKO = "Save All"
        lBtnsaveKernel = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveCPO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveCPO.Text = "Simpan"
        End If

        If GlobalPPT.strLang = "en" Then
            btnSavePKO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSavePKO.Text = "Simpan"
        End If
        If GlobalPPT.strLang = "en" Then
            btnSaveKernel.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveKernel.Text = "Simpan"
        End If
        'btnSaveCPO.Text = "Save"
        'btnSavePKO.Text = "Save"
        'btnSaveKernel.Text = "Save"
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseCPO.Click
        If (dgvCPO.Rows.Count > 0 Or dgvPKO.RowCount > 0 Or dgvKernel.RowCount > 0) And btnSaveCPO.Enabled = True Then
            If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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

        End If      'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        '    Me.Close()
        'End If
    End Sub

    Private Sub tpDispatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpDispatch.Click
        If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        If Not objUserLoginBOl.Privilege(btnSavePKO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        'If tpDispatch.SelectedIndex = 1 Or tpDispatch.SelectedIndex = 2 Then
        '    If grpCPO.Enabled = False Then
        '        MsgBox("Please Save/Reset the records for CPO.")
        '        tpDispatch.SelectedTab = tbCPO
        '        Exit Sub
        '    Else
        '        ClearCPO()
        '        ClearMultientryCPO()
        '        ClearGridView(dgvCPO)
        '        cmbCPOLoadingLocation.SelectedIndex = 0
        '    End If
        'End If
        'If tpDispatch.SelectedIndex = 0 Or tpDispatch.SelectedIndex = 2 Then
        '    If grpPKO.Enabled = False Then
        '        MsgBox("Please Save/Reset the records for PKO.")
        '        tpDispatch.SelectedTab = tbPKO
        '        Exit Sub
        '    End If
        'Else
        '    ClearPKO()
        '    ClearMultientryPKO()
        '    ClearGridView(dgvPKO)
        '    cmbPKOLoadingLocation.SelectedIndex = 0
        'End If
        'If tpDispatch.SelectedIndex = 1 Or tpDispatch.SelectedIndex = 0 Then
        '    If grpKernel.Enabled = False Then
        '        MsgBox("Please Save/Reset the records for Kernel.")
        '        tpDispatch.SelectedTab = tbKernel
        '        Exit Sub
        '    Else
        '        ClearKernel()
        '        ClearMultientryKernel()
        '        ClearGridView(dgvKernel)
        '        cmbKernelLoadingLocation.SelectedIndex = 0
        '    End If
        'End If


    End Sub

    Private Sub tpDispatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpDispatch.SelectedIndexChanged
        If tpDispatch.SelectedIndex = 1 Or tpDispatch.SelectedIndex = 2 Then

            If dtpCPODate.Enabled = False Then
                DisplayInfoMessage("Msg25")
                ''MsgBox("Please do Update or Reset All action in CPO Tab before proceeding to other TABs ")
                lSelectedIndexCalc = False
                tpDispatch.SelectedTab = tbCPO
                'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If
                Exit Sub
            End If
        End If
        If tpDispatch.SelectedIndex = 0 Or tpDispatch.SelectedIndex = 2 Then
            If dtpPKODate.Enabled = False Then
                DisplayInfoMessage("Msg26")
                ''MsgBox("Please do Update or Reset All action in PKO Tab before proceeding to other TABs.")
                lSelectedIndexCalc = False
                tpDispatch.SelectedTab = tbPKO
                'If Not objUserLoginBOl.Privilege(btnSavePKO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If
                Exit Sub
            End If
        End If

        If tpDispatch.SelectedIndex = 1 Or tpDispatch.SelectedIndex = 0 Then
            If dtpKernelDate.Enabled = False Then
                DisplayInfoMessage("Msg27")
                ''MsgBox("Please do Update or Reset All action in Kernel Tab before proceeding to other TABs")
                lSelectedIndexCalc = False
                tpDispatch.SelectedTab = tbKernel
                'If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If
                Exit Sub
            End If
        End If




    End Sub

    Private Sub SearchDispatch()
        Dim ObjDispatchPPT As New DispatchPPT

        If cmbDispatchSearch.Text = "CPO" Then
            ObjDispatchPPT.ProductID = lCPOProductID
        ElseIf cmbDispatchSearch.Text = "PKO" Then
            ObjDispatchPPT.ProductID = lPKOProductID
        Else
            ObjDispatchPPT.ProductID = lKernelProductID
        End If

        If chkDisPatchDate.Checked = True Then
            ObjDispatchPPT.lDispatchDate = dtpViewDispatchDate.Value
        Else
            ObjDispatchPPT.lDispatchDate = "01/01/1900"
        End If

        Dim ds As New DataSet
        ds = DispatchBOL.GetDispatchValues(ObjDispatchPPT)
        dgvViewDispatch.DataSource = ds.Tables(0)
        dgvViewDispatch.AutoGenerateColumns = False
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tbMainfrm.SelectedIndex = 0
        tpDispatch.SelectedTab = tbCPO
        dtpCPODate.Focus()
    End Sub
    Private Sub UpDateDispatch()
        'Dim ds As New DataSet
        'Dim ObjDispatchPPT As New DispatchPPT
        If objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                btnSaveCPO.Enabled = True
                btnSavePKO.Enabled = True
                btnSaveKernel.Enabled = True
            End If
        End If

        If cmbDispatchSearch.Text = "CPO" Then
            If dgvViewDispatch.RowCount > 0 Then

                'grpCPO.Enabled = False
                dtpCPODate.Enabled = False

                lDispatchID = dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchID").Value.ToString
                dtpCPODate.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchDate").Value.ToString
                txtCPOBAPNo.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewBAPNo").Value.ToString
                'txtCPOShipPontoon.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewshippontoon").Value.ToString
                txtCPOMillWeight.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewMillWeight").Value.ToString
                cmbCPOLoadingLocation.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewLoadingLocation").Value.ToString
                dtpCPODOA.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOA").Value.ToString
                dtpCPODOL.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOL").Value.ToString
                dtpCPODCL.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDCL").Value.ToString
                dtpCPODepature.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDePature").Value.ToString
                txtBuyerName.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvBuyerName").Value.ToString
                txtKontrakNo.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvKontrakNo").Value.ToString
                txtNoOrderPenyerahan.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoPenyerahan").Value.ToString
                txtNoOrderInstruksi.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoInstruksi").Value.ToString
                txtJumlahKontrak.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvJumlahKontrak").Value.ToString
                txtNoSIM.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoSim").Value.ToString
                txtNoTrukTanki.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoTruk").Value.ToString
                txtNoSeal.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvSealNo").Value.ToString
                txtDriverName.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvDriverName").Value.ToString
                txtTransporterName.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvTransporterNo").Value.ToString
                txtSPBNo.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvSPBNo").Value.ToString
                cmbTermofSales.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvTermofSales").Value.ToString

                Dim lDOATime, lDOLTime, lDCLTime, lDepatureTime As DateTime
                lDOATime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOATime").Value.ToString

                cmbCPODOAHrs.Text = lDOATime.Hour
                If lDOATime.Minute < 5 Then
                    cmbCPODOAMin.Text = "00"
                ElseIf lDOATime.Minute >= 5 And lDOATime.Minute < 10 Then
                    cmbCPODOAMin.Text = "05"
                ElseIf lDOATime.Minute >= 10 And lDOATime.Minute < 15 Then
                    cmbCPODOAMin.Text = "10"
                ElseIf lDOATime.Minute >= 15 And lDOATime.Minute < 20 Then
                    cmbCPODOAMin.Text = "15"
                ElseIf lDOATime.Minute >= 20 And lDOATime.Minute < 25 Then
                    cmbCPODOAMin.Text = "20"
                ElseIf lDOATime.Minute >= 25 And lDOATime.Minute < 30 Then
                    cmbCPODOAMin.Text = "25"
                ElseIf lDOATime.Minute >= 30 And lDOATime.Minute < 35 Then
                    cmbCPODOAMin.Text = "30"
                ElseIf lDOATime.Minute >= 35 And lDOATime.Minute < 40 Then
                    cmbCPODOAMin.Text = "35"
                ElseIf lDOATime.Minute >= 40 And lDOATime.Minute < 45 Then
                    cmbCPODOAMin.Text = "40"
                ElseIf lDOATime.Minute >= 45 And lDOATime.Minute < 50 Then
                    cmbCPODOAMin.Text = "45"
                ElseIf lDOATime.Minute >= 50 And lDOATime.Minute < 55 Then
                    cmbCPODOAMin.Text = "50"
                ElseIf lDOATime.Minute >= 55 And lDOATime.Minute < 60 Then
                    cmbCPODOAMin.Text = "55"
                End If
                lDOLTime = (dgvViewDispatch.SelectedRows(0).Cells("dgViewDOLTime").Value.ToString)


                cmbCPODOLHrs.Text = lDOATime.Hour
                If lDOLTime.Minute < 5 Then
                    cmbCPODOLMin.Text = "00"
                ElseIf lDOLTime.Minute >= 5 And lDOLTime.Minute < 10 Then
                    cmbCPODOLMin.Text = "05"
                ElseIf lDOLTime.Minute >= 10 And lDOLTime.Minute < 15 Then
                    cmbCPODOLMin.Text = "10"
                ElseIf lDOLTime.Minute >= 15 And lDOLTime.Minute < 20 Then
                    cmbCPODOLMin.Text = "15"
                ElseIf lDOLTime.Minute >= 20 And lDOLTime.Minute < 25 Then
                    cmbCPODOLMin.Text = "20"
                ElseIf lDOLTime.Minute >= 25 And lDOLTime.Minute < 30 Then
                    cmbCPODOLMin.Text = "25"
                ElseIf lDOLTime.Minute >= 30 And lDOLTime.Minute < 35 Then
                    cmbCPODOLMin.Text = "30"
                ElseIf lDOLTime.Minute >= 35 And lDOLTime.Minute < 40 Then
                    cmbCPODOLMin.Text = "35"
                ElseIf lDOLTime.Minute >= 40 And lDOLTime.Minute < 45 Then
                    cmbCPODOLMin.Text = "40"
                ElseIf lDOLTime.Minute >= 45 And lDOLTime.Minute < 50 Then
                    cmbCPODOLMin.Text = "45"
                ElseIf lDOLTime.Minute >= 50 And lDOLTime.Minute < 55 Then
                    cmbCPODOLMin.Text = "50"
                ElseIf lDOLTime.Minute >= 55 And lDOLTime.Minute < 60 Then
                    cmbCPODOLMin.Text = "55"
                End If
                lDCLTime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDClTime").Value.ToString
                cmbCPODCLHrs.Text = lDCLTime.Hour

                If lDCLTime.Minute < 5 Then
                    cmbCPODCLMin.Text = "00"
                ElseIf lDCLTime.Minute >= 5 And lDCLTime.Minute < 10 Then
                    cmbCPODCLMin.Text = "05"
                ElseIf lDCLTime.Minute >= 10 And lDCLTime.Minute < 15 Then
                    cmbCPODCLMin.Text = "10"
                ElseIf lDCLTime.Minute >= 15 And lDCLTime.Minute < 20 Then
                    cmbCPODCLMin.Text = "15"
                ElseIf lDCLTime.Minute >= 20 And lDCLTime.Minute < 25 Then
                    cmbCPODCLMin.Text = "20"
                ElseIf lDCLTime.Minute >= 25 And lDCLTime.Minute < 30 Then
                    cmbCPODCLMin.Text = "25"
                ElseIf lDCLTime.Minute >= 30 And lDCLTime.Minute < 35 Then
                    cmbCPODCLMin.Text = "30"
                ElseIf lDCLTime.Minute >= 35 And lDCLTime.Minute < 40 Then
                    cmbCPODCLMin.Text = "35"
                ElseIf lDCLTime.Minute >= 40 And lDCLTime.Minute < 45 Then
                    cmbCPODCLMin.Text = "40"
                ElseIf lDCLTime.Minute >= 45 And lDCLTime.Minute < 50 Then
                    cmbCPODCLMin.Text = "45"
                ElseIf lDCLTime.Minute >= 50 And lDCLTime.Minute < 55 Then
                    cmbCPODCLMin.Text = "50"
                ElseIf lDCLTime.Minute >= 55 And lDCLTime.Minute < 60 Then
                    cmbCPODCLMin.Text = "55"
                End If
                lDepatureTime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDepaturetime").Value.ToString

                cmbCPODepatureHrs.Text = lDepatureTime.Hour

                If lDepatureTime.Minute < 5 Then
                    cmbCPODepatureMin.Text = "00"
                ElseIf lDepatureTime.Minute >= 5 And lDepatureTime.Minute < 10 Then
                    cmbCPODepatureMin.Text = "05"
                ElseIf lDepatureTime.Minute >= 10 And lDepatureTime.Minute < 15 Then
                    cmbCPODepatureMin.Text = "10"
                ElseIf lDepatureTime.Minute >= 15 And lDepatureTime.Minute < 20 Then
                    cmbCPODepatureMin.Text = "15"
                ElseIf lDepatureTime.Minute >= 20 And lDepatureTime.Minute < 25 Then
                    cmbCPODepatureMin.Text = "20"
                ElseIf lDepatureTime.Minute >= 25 And lDepatureTime.Minute < 30 Then
                    cmbCPODepatureMin.Text = "25"
                ElseIf lDepatureTime.Minute >= 30 And lDepatureTime.Minute < 35 Then
                    cmbCPODepatureMin.Text = "30"
                ElseIf lDepatureTime.Minute >= 35 And lDepatureTime.Minute < 40 Then
                    cmbCPODepatureMin.Text = "35"
                ElseIf lDepatureTime.Minute >= 40 And lDepatureTime.Minute < 45 Then
                    cmbCPODepatureMin.Text = "40"
                ElseIf lDepatureTime.Minute >= 45 And lDepatureTime.Minute < 50 Then
                    cmbCPODepatureMin.Text = "45"
                ElseIf lDepatureTime.Minute >= 50 And lDepatureTime.Minute < 55 Then
                    cmbCPODepatureMin.Text = "50"
                ElseIf lDepatureTime.Minute >= 55 And lDepatureTime.Minute < 60 Then
                    cmbCPODepatureMin.Text = "55"
                End If
                tbMainfrm.SelectedTab = MainTab
                tpDispatch.SelectedTab = tbCPO
                dgvCPO.AutoGenerateColumns = False

                BindMultipleEntryDataGrid()




                lbtnsaveCPO = "Update All"

                If GlobalPPT.strLang = "en" Then
                    btnSaveCPO.Text = "Update"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveCPO.Text = "Memperbarui"
                End If

                ''btnSaveCPO.Text = "Update"

                'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If

            End If

        ElseIf cmbDispatchSearch.Text = "PKO" Then

            If dgvViewDispatch.RowCount > 0 Then

                dtpPKODate.Enabled = False
                lDispatchID = dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchID").Value.ToString
                dtpPKODate.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchDate").Value.ToString
                txtPKOBAPNo.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewBAPNo").Value.ToString
                txtPKOShipPontoon.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewshippontoon").Value.ToString
                txtPKOMillWeight.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewMillWeight").Value.ToString
                cmbPKOLoadingLocation.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewLoadingLocation").Value.ToString
                dtpPKODOA.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOA").Value.ToString
                dtpPKODOL.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOL").Value.ToString
                dtpPKODCL.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDCL").Value.ToString
                dtpPKODepature.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDePature").Value.ToString
                Dim lDOATime, lDOLTime, lDCLTime, lDepatureTime As DateTime
                lDOATime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOATime").Value.ToString

                cmbPKODOAHrs.Text = lDOATime.Hour

                If lDOATime.Minute < 5 Then
                    cmbPKODOAMin.Text = "00"
                ElseIf lDOATime.Minute >= 5 And lDOATime.Minute < 10 Then
                    cmbPKODOAMin.Text = "05"
                ElseIf lDOATime.Minute >= 10 And lDOATime.Minute < 15 Then
                    cmbPKODOAMin.Text = "10"
                ElseIf lDOATime.Minute >= 15 And lDOATime.Minute < 20 Then
                    cmbPKODOAMin.Text = "15"
                ElseIf lDOATime.Minute >= 20 And lDOATime.Minute < 25 Then
                    cmbPKODOAMin.Text = "20"
                ElseIf lDOATime.Minute >= 25 And lDOATime.Minute < 30 Then
                    cmbPKODOAMin.Text = "25"
                ElseIf lDOATime.Minute >= 30 And lDOATime.Minute < 35 Then
                    cmbPKODOAMin.Text = "30"
                ElseIf lDOATime.Minute >= 35 And lDOATime.Minute < 40 Then
                    cmbPKODOAMin.Text = "35"
                ElseIf lDOATime.Minute >= 40 And lDOATime.Minute < 45 Then
                    cmbPKODOAMin.Text = "40"
                ElseIf lDOATime.Minute >= 45 And lDOATime.Minute < 50 Then
                    cmbPKODOAMin.Text = "45"
                ElseIf lDOATime.Minute >= 50 And lDOATime.Minute < 55 Then
                    cmbPKODOAMin.Text = "50"
                ElseIf lDOATime.Minute >= 55 And lDOATime.Minute < 60 Then
                    cmbPKODOAMin.Text = "55"
                End If
                lDOLTime = (dgvViewDispatch.SelectedRows(0).Cells("dgViewDOLTime").Value.ToString)


                cmbPKODOLHrs.Text = lDOLTime.Hour
                If lDOLTime.Minute < 5 Then
                    cmbPKODOLMin.Text = "00"
                ElseIf lDOLTime.Minute >= 5 And lDOLTime.Minute < 10 Then
                    cmbPKODOLMin.Text = "05"
                ElseIf lDOLTime.Minute >= 10 And lDOLTime.Minute < 15 Then
                    cmbPKODOLMin.Text = "10"
                ElseIf lDOLTime.Minute >= 15 And lDOLTime.Minute < 20 Then
                    cmbPKODOLMin.Text = "15"
                ElseIf lDOLTime.Minute >= 20 And lDOLTime.Minute < 25 Then
                    cmbPKODOLMin.Text = "20"
                ElseIf lDOLTime.Minute >= 25 And lDOLTime.Minute < 30 Then
                    cmbPKODOLMin.Text = "25"
                ElseIf lDOLTime.Minute >= 30 And lDOLTime.Minute < 35 Then
                    cmbPKODOLMin.Text = "30"
                ElseIf lDOLTime.Minute >= 35 And lDOLTime.Minute < 40 Then
                    cmbPKODOLMin.Text = "35"
                ElseIf lDOLTime.Minute >= 40 And lDOLTime.Minute < 45 Then
                    cmbPKODOLMin.Text = "40"
                ElseIf lDOLTime.Minute >= 45 And lDOLTime.Minute < 50 Then
                    cmbPKODOLMin.Text = "45"
                ElseIf lDOLTime.Minute >= 50 And lDOLTime.Minute < 55 Then
                    cmbPKODOLMin.Text = "50"
                ElseIf lDOLTime.Minute >= 55 And lDOLTime.Minute < 60 Then
                    cmbPKODOLMin.Text = "55"
                End If
                lDCLTime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDCLTime").Value.ToString

                cmbPKODCLHrs.Text = lDCLTime.Hour
                If lDCLTime.Minute < 5 Then
                    cmbPKODCLMin.Text = "00"
                ElseIf lDCLTime.Minute >= 5 And lDCLTime.Minute < 10 Then
                    cmbPKODCLMin.Text = "05"
                ElseIf lDCLTime.Minute >= 10 And lDCLTime.Minute < 15 Then
                    cmbPKODCLMin.Text = "10"
                ElseIf lDCLTime.Minute >= 15 And lDCLTime.Minute < 20 Then
                    cmbPKODCLMin.Text = "15"
                ElseIf lDCLTime.Minute >= 20 And lDCLTime.Minute < 25 Then
                    cmbPKODCLMin.Text = "20"
                ElseIf lDCLTime.Minute >= 25 And lDCLTime.Minute < 30 Then
                    cmbPKODCLMin.Text = "25"
                ElseIf lDCLTime.Minute >= 30 And lDCLTime.Minute < 35 Then
                    cmbPKODCLMin.Text = "30"
                ElseIf lDCLTime.Minute >= 35 And lDCLTime.Minute < 40 Then
                    cmbPKODCLMin.Text = "35"
                ElseIf lDCLTime.Minute >= 40 And lDCLTime.Minute < 45 Then
                    cmbPKODCLMin.Text = "40"
                ElseIf lDCLTime.Minute >= 45 And lDCLTime.Minute < 50 Then
                    cmbPKODCLMin.Text = "45"
                ElseIf lDCLTime.Minute >= 50 And lDCLTime.Minute < 55 Then
                    cmbPKODCLMin.Text = "50"
                ElseIf lDCLTime.Minute >= 55 And lDCLTime.Minute < 60 Then
                    cmbPKODCLMin.Text = "55"
                End If
                lDepatureTime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDepaturetime").Value.ToString

                cmbPKODepatureHrs.Text = lDepatureTime.Hour

                If lDepatureTime.Minute < 5 Then
                    cmbPKODepatureMin.Text = "00"
                ElseIf lDepatureTime.Minute >= 5 And lDepatureTime.Minute < 10 Then
                    cmbPKODepatureMin.Text = "05"
                ElseIf lDepatureTime.Minute >= 10 And lDepatureTime.Minute < 15 Then
                    cmbPKODepatureMin.Text = "10"
                ElseIf lDepatureTime.Minute >= 15 And lDepatureTime.Minute < 20 Then
                    cmbPKODepatureMin.Text = "15"
                ElseIf lDepatureTime.Minute >= 20 And lDepatureTime.Minute < 25 Then
                    cmbPKODepatureMin.Text = "20"
                ElseIf lDepatureTime.Minute >= 25 And lDepatureTime.Minute < 30 Then
                    cmbPKODepatureMin.Text = "25"
                ElseIf lDepatureTime.Minute >= 30 And lDepatureTime.Minute < 35 Then
                    cmbPKODepatureMin.Text = "30"
                ElseIf lDepatureTime.Minute >= 35 And lDepatureTime.Minute < 40 Then
                    cmbPKODepatureMin.Text = "35"
                ElseIf lDepatureTime.Minute >= 40 And lDepatureTime.Minute < 45 Then
                    cmbPKODepatureMin.Text = "40"
                ElseIf lDepatureTime.Minute >= 45 And lDepatureTime.Minute < 50 Then
                    cmbPKODepatureMin.Text = "45"
                ElseIf lDepatureTime.Minute >= 50 And lDepatureTime.Minute < 55 Then
                    cmbPKODepatureMin.Text = "50"
                ElseIf lDepatureTime.Minute >= 55 And lDepatureTime.Minute < 60 Then
                    cmbPKODepatureMin.Text = "55"
                End If

                dgvPKO.AutoGenerateColumns = False
                lbtnsavePKO = "Update All"

                If GlobalPPT.strLang = "en" Then
                    btnSavePKO.Text = "Update"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSavePKO.Text = "Memperbarui"
                End If

                ''btnSavePKO.Text = "Update"
                tbMainfrm.SelectedTab = MainTab
                tpDispatch.SelectedTab = tbPKO
                BindMultipleEntryDataGrid()
                'If Not objUserLoginBOl.Privilege(btnSavePKO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If
            End If


        Else

            If dgvViewDispatch.RowCount > 0 Then
                dtpKernelDate.Enabled = False

                lDispatchID = dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchID").Value.ToString
                dtpKernelDate.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchDate").Value.ToString
                txtKernelMillWeight.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewMillWeight").Value.ToString
                cmbKernelLoadingLocation.Text = dgvViewDispatch.SelectedRows(0).Cells("dgViewLoadingLocation").Value.ToString
                dtpKernelDOA.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOA").Value.ToString
                dtpKernelDOL.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOL").Value.ToString
                dtpKernelDCL.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDCL").Value.ToString
                dtpKernelDepature.Value = dgvViewDispatch.SelectedRows(0).Cells("dgViewDePature").Value.ToString
                txtBuyerNameKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvBuyerName").Value.ToString
                txtKontrakNoKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvKontrakNo").Value.ToString
                txtNoOrderPenyerahanKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoPenyerahan").Value.ToString
                txtNoOrderInstruksiKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoInstruksi").Value.ToString
                txtJumlahKontrakKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvJumlahKontrak").Value.ToString
                txtNoSimKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoSim").Value.ToString
                txtNoTrukKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvNoTruk").Value.ToString
                txtNoKunciKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvSealNo").Value.ToString
                txtDriverNameKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvDriverName").Value.ToString
                txtTransporterNameKernel.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvTransporterNo").Value.ToString
                'txtSPBNo.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvSPBNo").Value.ToString
                'cmbTermofSales.Text = dgvViewDispatch.SelectedRows(0).Cells("dgvTermofSales").Value.ToString




                Dim lDOATime, lDOLTime, lDCLTime, lDepatureTime As DateTime
                lDOATime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDOATime").Value.ToString

                cmbKernelDOAHrs.Text = lDOATime.Hour

                If lDOATime.Minute < 5 Then
                    cmbKernelDOAMin.Text = "00"
                ElseIf lDOATime.Minute >= 5 And lDOATime.Minute < 10 Then
                    cmbKernelDOAMin.Text = "05"
                ElseIf lDOATime.Minute >= 10 And lDOATime.Minute < 15 Then
                    cmbKernelDOAMin.Text = "10"
                ElseIf lDOATime.Minute >= 15 And lDOATime.Minute < 20 Then
                    cmbKernelDOAMin.Text = "15"
                ElseIf lDOATime.Minute >= 20 And lDOATime.Minute < 25 Then
                    cmbKernelDOAMin.Text = "20"
                ElseIf lDOATime.Minute >= 25 And lDOATime.Minute < 30 Then
                    cmbKernelDOAMin.Text = "25"
                ElseIf lDOATime.Minute >= 30 And lDOATime.Minute < 35 Then
                    cmbKernelDOAMin.Text = "30"
                ElseIf lDOATime.Minute >= 35 And lDOATime.Minute < 40 Then
                    cmbKernelDOAMin.Text = "35"
                ElseIf lDOATime.Minute >= 40 And lDOATime.Minute < 45 Then
                    cmbKernelDOAMin.Text = "40"
                ElseIf lDOATime.Minute >= 45 And lDOATime.Minute < 50 Then
                    cmbKernelDOAMin.Text = "45"
                ElseIf lDOATime.Minute >= 50 And lDOATime.Minute < 55 Then
                    cmbKernelDOAMin.Text = "50"
                ElseIf lDOATime.Minute >= 55 And lDOATime.Minute < 60 Then
                    cmbKernelDOAMin.Text = "55"
                End If
                lDOLTime = (dgvViewDispatch.SelectedRows(0).Cells("dgViewDOLTime").Value.ToString)


                cmbKernelDOLHrs.Text = lDOLTime.Hour

                If lDOLTime.Minute < 5 Then
                    cmbKernelDOLMin.Text = "00"
                ElseIf lDOLTime.Minute >= 5 And lDOLTime.Minute < 10 Then
                    cmbKernelDOLMin.Text = "05"
                ElseIf lDOLTime.Minute >= 10 And lDOLTime.Minute < 15 Then
                    cmbKernelDOLMin.Text = "10"
                ElseIf lDOLTime.Minute >= 15 And lDOLTime.Minute < 20 Then
                    cmbKernelDOLMin.Text = "15"
                ElseIf lDOLTime.Minute >= 20 And lDOLTime.Minute < 25 Then
                    cmbKernelDOLMin.Text = "20"
                ElseIf lDOLTime.Minute >= 25 And lDOLTime.Minute < 30 Then
                    cmbKernelDOLMin.Text = "25"
                ElseIf lDOLTime.Minute >= 30 And lDOLTime.Minute < 35 Then
                    cmbKernelDOLMin.Text = "30"
                ElseIf lDOLTime.Minute >= 35 And lDOLTime.Minute < 40 Then
                    cmbKernelDOLMin.Text = "35"
                ElseIf lDOLTime.Minute >= 40 And lDOLTime.Minute < 45 Then
                    cmbKernelDOLMin.Text = "40"
                ElseIf lDOLTime.Minute >= 45 And lDOLTime.Minute < 50 Then
                    cmbKernelDOLMin.Text = "45"
                ElseIf lDOLTime.Minute >= 50 And lDOLTime.Minute < 55 Then
                    cmbKernelDOLMin.Text = "50"
                ElseIf lDOLTime.Minute >= 55 And lDOLTime.Minute < 60 Then
                    cmbKernelDOLMin.Text = "55"
                End If
                lDCLTime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDCLTime").Value.ToString

                cmbKernelDCLHrs.Text = lDCLTime.Hour

                If lDCLTime.Minute < 5 Then
                    cmbKernelDCLMin.Text = "00"
                ElseIf lDCLTime.Minute >= 5 And lDCLTime.Minute < 10 Then
                    cmbKernelDCLMin.Text = "05"
                ElseIf lDCLTime.Minute >= 10 And lDCLTime.Minute < 15 Then
                    cmbKernelDCLMin.Text = "10"
                ElseIf lDCLTime.Minute >= 15 And lDCLTime.Minute < 20 Then
                    cmbKernelDCLMin.Text = "15"
                ElseIf lDCLTime.Minute >= 20 And lDCLTime.Minute < 25 Then
                    cmbKernelDCLMin.Text = "20"
                ElseIf lDCLTime.Minute >= 25 And lDCLTime.Minute < 30 Then
                    cmbKernelDCLMin.Text = "25"
                ElseIf lDCLTime.Minute >= 30 And lDCLTime.Minute < 35 Then
                    cmbKernelDCLMin.Text = "30"
                ElseIf lDCLTime.Minute >= 35 And lDCLTime.Minute < 40 Then
                    cmbKernelDCLMin.Text = "35"
                ElseIf lDCLTime.Minute >= 40 And lDCLTime.Minute < 45 Then
                    cmbKernelDCLMin.Text = "40"
                ElseIf lDCLTime.Minute >= 45 And lDCLTime.Minute < 50 Then
                    cmbKernelDCLMin.Text = "45"
                ElseIf lDCLTime.Minute >= 50 And lDCLTime.Minute < 55 Then
                    cmbKernelDCLMin.Text = "50"
                ElseIf lDCLTime.Minute >= 55 And lDCLTime.Minute < 60 Then
                    cmbKernelDCLMin.Text = "55"
                End If
                lDepatureTime = dgvViewDispatch.SelectedRows(0).Cells("dgViewDepaturetime").Value.ToString

                cmbKernelDepatureHrs.Text = lDepatureTime.Hour

                If lDepatureTime.Minute < 5 Then
                    cmbKernelDepatureMin.Text = "00"
                ElseIf lDepatureTime.Minute >= 5 And lDepatureTime.Minute < 10 Then
                    cmbKernelDepatureMin.Text = "05"
                ElseIf lDepatureTime.Minute >= 10 And lDepatureTime.Minute < 15 Then
                    cmbKernelDepatureMin.Text = "10"
                ElseIf lDepatureTime.Minute >= 15 And lDepatureTime.Minute < 20 Then
                    cmbKernelDepatureMin.Text = "15"
                ElseIf lDepatureTime.Minute >= 20 And lDepatureTime.Minute < 25 Then
                    cmbKernelDepatureMin.Text = "20"
                ElseIf lDepatureTime.Minute >= 25 And lDepatureTime.Minute < 30 Then
                    cmbKernelDepatureMin.Text = "25"
                ElseIf lDepatureTime.Minute >= 30 And lDepatureTime.Minute < 35 Then
                    cmbKernelDepatureMin.Text = "30"
                ElseIf lDepatureTime.Minute >= 35 And lDepatureTime.Minute < 40 Then
                    cmbKernelDepatureMin.Text = "35"
                ElseIf lDepatureTime.Minute >= 40 And lDepatureTime.Minute < 45 Then
                    cmbKernelDepatureMin.Text = "40"
                ElseIf lDepatureTime.Minute >= 45 And lDepatureTime.Minute < 50 Then
                    cmbKernelDepatureMin.Text = "45"
                ElseIf lDepatureTime.Minute >= 50 And lDepatureTime.Minute < 55 Then
                    cmbKernelDepatureMin.Text = "50"
                ElseIf lDepatureTime.Minute >= 55 And lDepatureTime.Minute < 60 Then
                    cmbKernelDepatureMin.Text = "55"
                End If

                dgvKernel.AutoGenerateColumns = False
                lBtnsaveKernel = "Update All"

                If GlobalPPT.strLang = "en" Then
                    btnSaveKernel.Text = "Update"
                ElseIf GlobalPPT.strLang = "ms" Then
                    btnSaveKernel.Text = "Memperbarui"
                End If

                ''btnSaveKernel.Text = "Update"
                tbMainfrm.SelectedTab = MainTab
                tpDispatch.SelectedTab = tbKernel
                BindMultipleEntryDataGrid()
                'If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If

            End If
        End If


    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        UpDateDispatch()
    End Sub
    Private Sub BindMultipleEntryDataGrid()
        Try
            Dim objDispatchPPT As New DispatchPPT
            Dim objDispatchBOL As New DispatchBOL


            With objDispatchPPT
                .DispatchID = lDispatchID
            End With




            If tpDispatch.SelectedIndex = 0 Then
                dtCPO = DispatchBOL.GetDispatchDetailValues(objDispatchPPT)
                If dtCPO.Rows.Count <> 0 Then
                    dgvCPO.AutoGenerateColumns = False
                    dgvCPO.DataSource = dtCPO
                End If
            ElseIf tpDispatch.SelectedIndex = 1 Then
                dtPKO = DispatchBOL.GetDispatchDetailValues(objDispatchPPT)
                If dtPKO.Rows.Count <> 0 Then
                    dgvPKO.AutoGenerateColumns = False
                    dgvPKO.DataSource = dtPKO
                End If
            Else
                dtKernel = DispatchBOL.GetDispatchDetailValues(objDispatchPPT)
                If dtKernel.Rows.Count <> 0 Then
                    dgvKernel.AutoGenerateColumns = False
                    dgvKernel.DataSource = dtKernel
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim objDispatchPPT As New DispatchPPT
        Dim objDispatchBOL As New DispatchBOL
        Dim dt As New DataTable
        If dgvViewDispatch.Rows.Count > 0 Then
            '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DispatchFrm))
            If MsgBox(rm.GetString("Msg28"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''    If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                lDispatchID = Me.dgvViewDispatch.SelectedRows(0).Cells("dgViewDispatchID").Value.ToString()
                With objDispatchPPT
                    .DispatchID = lDispatchID
                End With

                If cmbDispatchSearch.Text = "Kernel" Or cmbDispatchSearch.SelectedText = "Kernel" Then
                    objDispatchBOL.DeleteDispatch(objDispatchPPT, True)
                Else
                    objDispatchBOL.DeleteDispatch(objDispatchPPT, False)
                End If
                SearchDispatch()
                DisplayInfoMessage("Msg29")
                GetCPOLocationValues()
                ''MsgBox("Data Successfully Deleted!")
            End If
        Else
            DisplayInfoMessage("Msg30")
            ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        cmbCPOPosition.Focus()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MultipleDateEntryValuesCPO()
    End Sub



    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        cmbPKOPosition.Focus()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        MultipleDateEntryValuesPKO()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        cmbKernelPosition.Focus()
    End Sub


    Private Sub dgvCPO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPO.CellDoubleClick

        MultipleDateEntryValuesCPO()



    End Sub

    Private Sub dgvPKO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKO.CellDoubleClick


        MultipleDateEntryValuesPKO()

    End Sub

    Private Sub dgvKernel_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernel.CellDoubleClick


        MultipleDateEntryValuesKernel()

    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        MultipleDateEntryValuesKernel()
    End Sub

    Private Sub btnSavePKO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePKO.Click
        If Val(txtPKOMillWeight.Text) = 0 Then
            DisplayInfoMessage("Msg19")
            '' MessageBox.Show("This Field Required", "Mill Weight")
            txtPKOMillWeight.Focus()
            Exit Sub
        End If
        If Me.txtPKOBAPNo.Text.Trim = "" Then
            DisplayInfoMessage("Msg20")
            '' MessageBox.Show("This Field Required", "BAP No.")
            txtPKOBAPNo.Focus()
            Exit Sub
        End If
        If Me.txtPKOShipPontoon.Text.Trim = "" Then
            DisplayInfoMessage("Msg21")
            ''MessageBox.Show("This Field Required", "Ship Pontoon")
            txtPKOShipPontoon.Focus()
            Exit Sub
        End If

        If dgvPKO.RowCount <> 0 Then

            If lPKOProductID <> String.Empty Then
                If txtPKOMillWeight.Text <> String.Empty Then

                    'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                    '    Exit Sub
                    'End If

                    If lbtnsavePKO = "Save All" Then
                        SaveDatasPKO()
                        GlobalPPT.IsRetainFocus = False
                    Else
                        UpDateDatasPKO()
                        GlobalPPT.IsRetainFocus = False

                        If GlobalPPT.strLang = "en" Then
                            btnSaveCPO.Text = "Save"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveCPO.Text = "Simpan"
                        End If

                        ''btnSaveCPO.Text = "Save"
                    End If
                    GetPKOLocationValues()
                    cmbPKOPosition.SelectedIndex = 0
                    lSelectedIndexCalc = True
                End If
            Else
                DisplayInfoMessage("Msg3")
                ''MsgBox("No Records Available for PKO ,Please insert the Record in Weighbridge Product Master")
                ClearPKO()
                ClearMultientryPKO()
                ClearGridView(dgvPKO)
            End If
        Else
            DisplayInfoMessage("Msg23")
            ''MsgBox("Please add the Records in Oil Quality")
            Exit Sub
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub btnSaveKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveKernel.Click
        If dgvKernel.RowCount <> 0 Then
            If Val(txtKernelMillWeight.Text) = 0 Then
                DisplayInfoMessage("Msg19")
                ''MessageBox.Show("This Field Required", "Mill Weight")
                txtKernelMillWeight.Focus()
                Exit Sub
            End If
            If lKernelProductID <> String.Empty Then
                If txtKernelMillWeight.Text <> String.Empty Then
                    'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
                    '    Exit Sub
                    'End If

                    If lBtnsaveKernel = "Save All" Then
                        SaveDatasKernel()
                        GlobalPPT.IsRetainFocus = False
                        GetKernelLocationValues()
                    Else
                        UpDateDatasKernel()
                        GlobalPPT.IsRetainFocus = False
                        GetKernelLocationValues()
                        If GlobalPPT.strLang = "en" Then
                            btnSaveCPO.Text = "Save"
                        ElseIf GlobalPPT.strLang = "ms" Then
                            btnSaveCPO.Text = "Simpan"
                        End If
                        ''btnSaveCPO.Text = "Save"
                    End If
                    cmbKernelPosition.SelectedIndex = 0
                    lSelectedIndexCalc = True
                End If
            Else
                DisplayInfoMessage("Msg4")
                ''MsgBox("No Records Available for Kernel,Please insert the Record in Weighbridge Product Master")
                ClearKernel()
                ClearMultientryKernel()
                ClearGridView(dgvKernel)
            End If
        Else
            DisplayInfoMessage("Msg31")
            ''MsgBox("Please add the Record(s) for Kernel!")
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveKernel, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub

    Private Sub btnResetPKO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPKO.Click
        ClearPKO()
        ClearMultientryPKO()
        ClearGridView(dgvPKO)
        dtpPKODate.Focus()
        cmbPKOPosition.SelectedIndex = 0
        lbtnsavePKO = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSavePKO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSavePKO.Text = "Simpan"
        End If
        ''btnSavePKO.Text = "Save"
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnResetKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetKernel.Click
        lSelectedIndexCalc = True
        ClearKernel()
        ClearMultientryKernel()
        ClearGridView(dgvKernel)
        dtpKernelDate.Focus()
        cmbKernelPosition.SelectedIndex = 0
        lBtnsaveKernel = "Save All"
        If GlobalPPT.strLang = "en" Then
            btnSaveKernel.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveKernel.Text = "Simpan"
        End If
        ''btnSaveKernel.Text = "Save"
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnCloseKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseKernel.Click

        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DispatchFrm))
        If (dgvCPO.Rows.Count > 0 Or dgvPKO.RowCount > 0 Or dgvKernel.RowCount > 0) And btnSaveCPO.Enabled = True Then
            If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
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

    Private Sub btnClosePKO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosePKO.Click
        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DispatchFrm))
        If (dgvCPO.Rows.Count > 0 Or dgvPKO.RowCount > 0 Or dgvKernel.RowCount > 0) And btnSaveCPO.Enabled = True Then
            If MsgBox(rm.GetString("Msg24"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
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
        'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        '    Me.Close()
        'End If
    End Sub

    Private Sub dgvViewDispatch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvViewDispatch.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpDateDispatch()
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchDispatch()
        If dgvViewDispatch.RowCount = 0 Then
            DisplayInfoMessage("Msg32")
            ''MsgBox("No record(s) found matching your search criteria.")
        End If
    End Sub

    Private Sub cmbDispatchSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDispatchSearch.SelectedIndexChanged

        SearchDispatch()
        'If dgvViewDispatch.RowCount = 0 Then
        '    MsgBox("No record(s) found matching your search criteria.")
        'End If
    End Sub

    Private Sub tbMainfrm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMainfrm.Click
        If objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then


            If AddToolStripMenuItem.Enabled = True Then
                btnSaveCPO.Enabled = True
                btnSavePKO.Enabled = True
                btnSaveKernel.Enabled = True
            Else
                btnSaveCPO.Enabled = False
                btnSavePKO.Enabled = False
                btnSaveKernel.Enabled = False

            End If
        End If



        If tbMainfrm.SelectedIndex = 1 Then
            If objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveCPO.Enabled = True
                    btnSavePKO.Enabled = True
                    btnSaveKernel.Enabled = True
                End If
            End If
            If (dgvCPO.Rows.Count > 0 Or dgvPKO.RowCount > 0 Or dgvKernel.RowCount > 0) And btnSaveCPO.Enabled = True Then
                If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                    tbMainfrm.SelectedIndex = 0
                    If dgvCPO.RowCount > 0 Then
                        tpDispatch.SelectedTab = tbCPO
                        btnSaveCPO.Visible = True
                        btnCloseCPO.Visible = True
                        btnResetCPO.Visible = True
                    ElseIf dgvPKO.RowCount > 0 Then
                        tpDispatch.SelectedTab = tbPKO
                        btnSaveCPO.Visible = True
                        btnCloseCPO.Visible = True
                        btnResetCPO.Visible = True
                    Else
                        tpDispatch.SelectedTab = tbKernel
                        btnSaveCPO.Visible = True
                        btnCloseCPO.Visible = True
                        btnResetCPO.Visible = True
                    End If
                    GlobalPPT.IsRetainFocus = False
                Else
                    btnSaveCPO.Visible = True
                    btnCloseCPO.Visible = True
                    btnResetCPO.Visible = True
                    cmbCPOPosition.SelectedIndex = 0
                    cmbPKOPosition.SelectedIndex = 0
                    cmbKernelPosition.SelectedIndex = 0
                    ClearCPO()
                    ClearKernel()
                    ClearPKO()
                    ClearMultientryCPO()
                    ClearMultientryPKO()
                    ClearMultientryKernel()
                    ClearGridView(dgvCPO)
                    ClearGridView(dgvPKO)
                    ClearGridView(dgvKernel)

                End If

            End If
        End If
    End Sub

    Private Sub tbMainfrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMainfrm.SelectedIndexChanged
        'If Not objUserLoginBOl.Privilege(btnSaveCPO, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        'If tbMainfrm.SelectedIndex = 1 Then

        '    chkDisPatchDate.Checked = False
        '    ClearCPO()
        '    ClearKernel()
        '    ClearPKO()
        '    ClearMultientryCPO()
        '    ClearMultientryPKO()
        '    ClearMultientryKernel()
        '    ClearGridView(dgvCPO)
        '    ClearGridView(dgvPKO)
        '    ClearGridView(dgvKernel)
        '    cmbDispatchSearch.SelectedIndex = 0
        '    SearchDispatch()
        '    tpDispatch.SelectedTab = tbCPO
        '    ' tbCPO.Focus()
        '    If cmbCPOLoadingLocation.Items.Count <> 0 Then
        '        cmbCPOLoadingLocation.SelectedIndex = 0
        '    End If
        '    If cmbPKOLoadingLocation.Items.Count <> 0 Then
        '        cmbPKOLoadingLocation.SelectedIndex = 0
        '    End If
        '    If cmbKernelLoadingLocation.Items.Count <> 0 Then
        '        cmbKernelLoadingLocation.SelectedIndex = 0
        '    End If
        '    lSelectedIndexCalc = True

        '    btnSaveCPO.Visible = False
        '    btnCloseCPO.Visible = False
        '    btnResetCPO.Visible = False




        'End If



    End Sub

    Private Sub DispatchFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub chkDisPatchDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDisPatchDate.CheckedChanged
        If chkDisPatchDate.Checked = True Then
            dtpViewDispatchDate.Enabled = True
        Else
            dtpViewDispatchDate.Enabled = False
        End If
    End Sub


    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim ObjRecordExist As New Object
        Dim ObjDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL
        ObjRecordExist = ObjDispatchBOL.DispatchRecordIsExist(ObjDispatchPPT)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg33")
            ''MsgBox("No Record(s) Available!")
        Else

            StrFrmName = "Dispatch"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If
    End Sub

    Private Sub dgvViewDispatch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvViewDispatch.KeyDown
        If e.KeyCode = 13 Then
            UpDateDispatch()
        End If
    End Sub

    Private CPOBFQty As Double = 0
    Private Sub cmbCPOLoadingLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPOLoadingLocation.SelectedIndexChanged
        Dim lrow As Integer
        lrow = cmbCPOLoadingLocation.SelectedIndex
        Dim tempBfQty = cmbCPOLoadingLocation.SelectedItem
        If Not IsDBNull(tempBfQty("BFQty")) Then
            CPOBFQty = tempBfQty("BFQty")
            lblCPOBFQty.Text = CPOBFQty
        End If

        'If Not IsDBNull(dtCPOLoading.Rows(lrow).Item("Descp")) Then
        '    lblLoadingLocationDescpcpo.Text = dtCPOLoading.Rows(lrow).Item("Descp").ToString
        'Else
        lblLoadingLocationDescpcpo.Text = ""
        'End If
        If Not String.IsNullOrEmpty(txtCPOMillWeight.Text) Or Not String.IsNullOrWhiteSpace(txtCPOMillWeight.Text) Then
            txtCPOMillWeight.Text = txtCPOMillWeight.Text - CPOBFQty
        End If

    End Sub
    Private KernelBfQty As Double = 0
    Private Sub cmbKernelLoadingLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKernelLoadingLocation.SelectedIndexChanged
        'Dim lrow As Integer
        'lrow = cmbKernelLoadingLocation.SelectedIndex
        'If lrow = 0 Then
        '    lblLoadingLocationDescpKernel.Text = ""
        'Else
        '    lblLoadingLocationDescpKernel.Text = dtKernelLocation.Rows(lrow).Item("Descp").ToString
        'End If

        Dim lrow As Integer
        lrow = cmbKernelLoadingLocation.SelectedIndex
        Dim tempBfQty = cmbKernelLoadingLocation.SelectedItem
        If Not IsDBNull(tempBfQty("BFQty")) Then
            KernelBfQty = tempBfQty("BFQty")
            lblBFQtyKernel.Text = KernelBfQty
            lblLoadingLocationDescpKernel.Text = tempBfQty("Descp")
        End If

        'If Not IsDBNull(dtCPOLoading.Rows(lrow).Item("Descp")) Then
        '    lblLoadingLocationDescpcpo.Text = dtCPOLoading.Rows(lrow).Item("Descp").ToString
        'Else        
        'End If
        If Not String.IsNullOrEmpty(txtKernelMillWeight.Text) Or Not String.IsNullOrWhiteSpace(txtKernelMillWeight.Text) Then
            txtKernelMillWeight.Text = txtKernelMillWeight.Text - KernelBfQty
        End If


    End Sub

    Private PKOBfQty As Double = 0
    Private Sub cmbPKOLoadingLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPKOLoadingLocation.SelectedIndexChanged
        Dim lrow As Integer
        lrow = cmbPKOLoadingLocation.SelectedIndex
        Dim tempBfQty = cmbPKOLoadingLocation.SelectedItem
        If Not IsDBNull(tempBfQty("BFQty")) Then
            PKOBfQty = tempBfQty("BFQty")
            lblPKOBfQty.Text = PKOBfQty
        End If

        'If Not IsDBNull(dtPKOLocation.Rows(lrow).Item("Descp")) Then
        '    lblLoadingLocationDescpPKO.Text = dtPKOLocation.Rows(lrow).Item("Descp").ToString
        'Else
        lblLoadingLocationDescpPKO.Text = ""
        'End If
        If Not String.IsNullOrEmpty(txtPKOMillWeight.Text) Or Not String.IsNullOrWhiteSpace(txtPKOMillWeight.Text) Then
            txtPKOMillWeight.Text = txtPKOMillWeight.Text - PKOBfQty
        End If

    End Sub

    Private Sub btnCPOHeaderReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCPOHeaderReset.Click
        If lbtnsaveCPO <> "Save All" Then
            txtCPOMillWeight.Text = String.Empty
            txtCPOBAPNo.Text = String.Empty
            'txtCPOShipPontoon.Text = String.Empty
            Datefunction()
            grpCPO.Enabled = True
            SearchDispatch()
            cmbCPOLoadingLocation.SelectedIndex = 0
            dtpCPODOA.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpCPODOL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpCPODCL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpCPODepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpViewDispatchDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)

            Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
            dtpCPODOA.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpCPODOL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpCPODCL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpCPODepature.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpViewDispatchDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

            dtpCPODOA.Value = Date.Today
            dtpCPODOL.Value = Date.Today
            dtpCPODCL.Value = Date.Today
            dtpCPODepature.Value = Date.Today
            dtpViewDispatchDate.Value = Date.Today

            Me.txtBuyerName.Text = String.Empty
            Me.txtKontrakNo.Text = String.Empty
            Me.txtNoOrderPenyerahan.Text = String.Empty
            Me.txtNoOrderInstruksi.Text = String.Empty
            Me.txtJumlahKontrak.Text = 0
            Me.txtNoSIM.Text = String.Empty
            Me.txtNoTrukTanki.Text = String.Empty
            Me.txtNoSeal.Text = String.Empty
            Me.txtDriverName.Text = String.Empty
            Me.txtTransporterName.Text = String.Empty
            Me.txtSPBNo.Text = String.Empty
            Me.cmbTermofSales.Text = String.Empty

            ClearCPO()
        End If


    End Sub

    Private Sub btnPKOHeaderReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPKOHeaderReset.Click

        If lbtnsavePKO <> "Save All" Then
            txtPKOMillWeight.Text = String.Empty
            txtPKOBAPNo.Text = String.Empty
            txtPKOShipPontoon.Text = String.Empty
            Datefunction()
            SearchDispatch()
            cmbPKOLoadingLocation.SelectedIndex = 0
            dtpPKODOA.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpPKODOL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpPKODCL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpPKODepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpPKODepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)

            Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
            dtpPKODOA.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpPKODOL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpPKODCL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpPKODepature.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpViewDispatchDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)


            dtpPKODOA.Value = Date.Today
            dtpPKODOL.Value = Date.Today
            dtpPKODCL.Value = Date.Today
            dtpPKODepature.Value = Date.Today
            dtpPKODepature.Value = Date.Today
        Else
            ClearPKO()
        End If


    End Sub

    Private Sub btnKernelHeaderReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernelHeaderReset.Click
        If lBtnsaveKernel <> "Save All" Then

            txtKernelMillWeight.Text = String.Empty
            Datefunction()
            cmbKernelLoadingLocation.SelectedIndex = 0
            SearchDispatch()
            dtpKernelDOA.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpKernelDOL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpKernelDCL.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
            dtpKernelDepature.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)


            Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
            dtpKernelDOA.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpKernelDOL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpKernelDCL.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpKernelDepature.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
            dtpViewDispatchDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

            dtpKernelDOA.Value = Date.Today
            dtpKernelDOL.Value = Date.Today
            dtpKernelDCL.Value = Date.Today
            dtpKernelDepature.Value = Date.Today

            txtBuyerNameKernel.Text = String.Empty
            txtKontrakNoKernel.Text = String.Empty
            txtNoOrderPenyerahanKernel.Text = String.Empty
            txtJumlahKontrakKernel.Text = 0
            txtNoSimKernel.Text = String.Empty
            txtNoTrukKernel.Text = String.Empty
            txtNoKunciKernel.Text = String.Empty
            txtDriverNameKernel.Text = String.Empty
            txtTransporterNameKernel.Text = String.Empty
            txtNoOrderInstruksiKernel.Text = String.Empty

        Else
            ClearKernel()
        End If
    End Sub
    Private Sub DecimalIdenCheck(ByVal ptxtbox As Object)
        Dim i As Integer
        i = ptxtbox.Text.IndexOf("."c)

        If i > 0 Then
            If ptxtbox.Text.Substring(i).Length = 1 Then
                DecimalCheck = True
            End If
        End If


    End Sub


    Private Sub txtCPOFFA_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPOFFA.Leave
        DecimalIdenCheck(txtCPOFFA)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            '' MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtCPOFFA.Focus()
        End If
        DecimalCheck = False
    End Sub


    Private Sub txtCPOMoisture_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCPOMoisture.Leave
        DecimalIdenCheck(txtCPOMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtCPOMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtCPODirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPODirt.Leave
        DecimalIdenCheck(txtCPODirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg35")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")

            txtCPODirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtCPOTemperature_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPOTemperature.Leave
        DecimalIdenCheck(txtCPOTemperature)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtCPOTemperature.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtPKOFFA_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOFFA.Leave
        DecimalIdenCheck(txtPKOFFA)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtPKOFFA.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtPKOMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOMoisture.Leave
        DecimalIdenCheck(txtPKOMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtPKOMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtPKODirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKODirt.Leave
        DecimalIdenCheck(txtPKODirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg35")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")

            txtPKODirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtPKOTemperature_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOTemperature.Leave
        DecimalIdenCheck(txtPKOTemperature)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtPKOTemperature.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelMoisture.Leave
        DecimalIdenCheck(txtKernelMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtKernelMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelBroken_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelBroken.Leave
        DecimalIdenCheck(txtKernelBroken)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtKernelBroken.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelDirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelDirt.Leave
        DecimalIdenCheck(txtKernelDirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg35")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")

            txtKernelDirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelTemperature_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelTemperature.Leave
        DecimalIdenCheck(txtKernelTemperature)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtKernelTemperature.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelMillWeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelMillWeight.Leave
        DecimalIdenCheck(txtKernelMillWeight)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtKernelMillWeight.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtPKOMillWeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOMillWeight.Leave
        DecimalIdenCheck(txtPKOMillWeight)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")

            txtPKOMillWeight.Focus()
        End If
        DecimalCheck = False

    End Sub

    Private Sub txtCPOMillWeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPOMillWeight.Leave
        DecimalIdenCheck(txtCPOMillWeight)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtCPOMillWeight.Focus()
        End If
        DecimalCheck = False

    End Sub


    Private Sub btnCPOResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCPOResetAll.Click
        ClearCPO()
        ClearMultientryCPO()
        ClearGridView(dgvCPO)
        dtpCPODate.Focus()
        cmbCPOPosition.SelectedIndex = 0
        lbtnsaveCPO = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveCPO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveCPO.Text = "Simpan"
        End If

        ''btnSaveCPO.Text = "Save"
    End Sub


    Private Sub btnDeleteAllCP0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAllCP0.Click
        Dim objDispatchPPT As New DispatchPPT
        Dim objDispatchBOL As New DispatchBOL
        If lDispatchID <> String.Empty Then
            objDispatchPPT.DispatchID = lDispatchID
            objDispatchBOL.DeleteDispatch(objDispatchPPT)

        End If

        ClearCPO()
        ClearMultientryCPO()
        ClearGridView(dgvCPO)
        dtpCPODate.Focus()
        cmbCPOPosition.SelectedIndex = 0
        lbtnsaveCPO = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveCPO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveCPO.Text = "Simpan"
        End If

    End Sub

    Private Sub btnDeleteAllPKO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAllPKO.Click
        Dim objDispatchPPT As New DispatchPPT
        Dim objDispatchBOL As New DispatchBOL
        If lDispatchID <> String.Empty Then
            objDispatchPPT.DispatchID = lDispatchID
            objDispatchBOL.DeleteDispatch(objDispatchPPT)

        End If

        ClearPKO()
        ClearMultientryPKO()
        ClearGridView(dgvPKO)
        dtpPKODate.Focus()
        cmbPKOPosition.SelectedIndex = 0
        lbtnsavePKO = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSavePKO.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSavePKO.Text = "Simpan"
        End If
    End Sub

    Private Sub btnDeleteAllKernel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAllKernel.Click
        Dim objDispatchPPT As New DispatchPPT
        Dim objDispatchBOL As New DispatchBOL
        If lDispatchID <> String.Empty Then
            objDispatchPPT.DispatchID = lDispatchID
            objDispatchBOL.DeleteDispatch(objDispatchPPT)

        End If

        ClearKernel()
        ClearMultientryKernel()
        ClearGridView(dgvKernel)
        dtpKernelDate.Focus()
        cmbKernelPosition.SelectedIndex = 0
        lBtnsaveKernel = "Save All"

        If GlobalPPT.strLang = "en" Then
            btnSaveKernel.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveKernel.Text = "Simpan"
        End If
    End Sub

    Private Sub DeleteKernelMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteKernelMe.Click

        If dgvKernel.RowCount = 0 Then
            Exit Sub
        ElseIf dgvKernel.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridKernel()
        End If

    End Sub

    Private Sub DeletePKOME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePKOME.Click

        If dgvPKO.RowCount = 0 Then
            Exit Sub
        ElseIf dgvPKO.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else

            DeleteMultientrydatagridPKO()
        End If



    End Sub

    Private Sub DeleteCPOME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCPOME.Click

        If dgvCPO.RowCount = 0 Then
            Exit Sub
        ElseIf dgvCPO.RowCount = 1 Then
            DisplayInfoMessage("Msg91")
            Exit Sub
        Else
            DeleteMultientrydatagridCPO()
        End If

    End Sub



    Private Sub DeleteMultientrydatagridCPO()

        If Not dgvCPO.SelectedRows(0).Cells("dgMeCPODispatchDetailID").Value Is Nothing Then
            lDispatchDetailID = dgvCPO.SelectedRows(0).Cells("dgMeCPODispatchDetailID").Value.ToString
        Else
            lDispatchDetailID = String.Empty
        End If

        lDelete = 0
        If lDispatchDetailID <> "" Then
            lDelete = DeleteMultientryCPO.Count
            DeleteMultientryCPO.Insert(lDelete, lDispatchDetailID)
        End If
        Dim Dr As DataRow
        Dr = dtCPO.Rows.Item(dgvCPO.CurrentRow.Index)
        Dr.Delete()
        dtCPO.AcceptChanges()
        lDispatchDetailID = ""
        '  ProductionTodayCalculation()

    End Sub
    Private Sub DeleteMultientrydatagridPKO()

        If Not dgvPKO.SelectedRows(0).Cells("dgMePKODispatchDetailID").Value Is Nothing Then
            lDispatchDetailID = dgvPKO.SelectedRows(0).Cells("dgMePKODispatchDetailID").Value.ToString
        Else
            lDispatchDetailID = String.Empty
        End If

        lDelete = 0
        If lDispatchDetailID <> "" Then
            lDelete = DeleteMultientryCPO.Count
            DeleteMultientryCPO.Insert(lDelete, lDispatchDetailID)
        End If
        Dim Dr As DataRow
        Dr = dtPKO.Rows.Item(dgvPKO.CurrentRow.Index)
        Dr.Delete()
        dtPKO.AcceptChanges()
        lDispatchDetailID = ""
        '  ProductionTodayCalculation()

    End Sub
    Private Sub DeleteMultientrydatagridKernel()

        If Not dgvKernel.SelectedRows(0).Cells("dgMeKernelDispatchDetailID").Value Is Nothing Then
            lDispatchDetailID = dgvKernel.SelectedRows(0).Cells("dgMeKernelDispatchDetailID").Value.ToString
        Else
            lDispatchDetailID = String.Empty
        End If

        lDelete = 0
        If lDispatchDetailID <> "" Then
            lDelete = DeleteMultientryCPO.Count
            DeleteMultientryCPO.Insert(lDelete, lDispatchDetailID)
        End If
        Dim Dr As DataRow
        Dr = dtKernel.Rows.Item(dgvKernel.CurrentRow.Index)
        Dr.Delete()
        dtKernel.AcceptChanges()
        lDispatchDetailID = ""
        '  ProductionTodayCalculation()

    End Sub

    Private Sub DeleteMultiEntryRecordsCPOPKOKernel()
        Dim objDispatchPPT As New DispatchPPT

        lDelete = DeleteMultientryCPO.Count

        While (lDelete > 0)

            objDispatchPPT.DispatchDetailID = DeleteMultientryCPO(lDelete - 1)

            Dim IntProdStockDelete As New Integer
            IntProdStockDelete = DispatchBOL.DeleteMultiEntryCPOPKOKernel(objDispatchPPT)
            lDelete = lDelete - 1

        End While



    End Sub


    Private Sub txtJumlahKontrak_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtJumlahKontrak.Validating
        If Not IsNumeric(txtJumlahKontrak.Text) Then
            txtJumlahKontrak.Text = 0
        End If
    End Sub


    Private Sub txtJumlahKontrakKernel_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtJumlahKontrakKernel.Validating
        If Not IsNumeric(Me.txtJumlahKontrakKernel.Text) Then
            txtJumlahKontrakKernel.Text = 0
        End If
    End Sub

    Private Sub grpKernel_Enter(sender As System.Object, e As System.EventArgs) Handles grpKernel.Enter

    End Sub
End Class