Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.IO
Imports System.Globalization
Imports System .Text 

Public Class CPOProductionLogFrm
    Public SaveFlag As Boolean = True
    Public lShift1 As String
    Public lShift2 As String
    Public lShift3 As String
    Public lStartTime As String
    Public lStopTime As String
    Public lTotalBreakdown As String
    Public lOERCPOQty As Double
    Public lOERKernelQty As Double
    Public lCPOProductionLogID As String
    Dim isDecimal, isModifierKey As Boolean
    Public lHrs As String
    Public lmin As String
    Public lAMPM As String
    Dim dtCPOAdd As New DataTable("todgvCPOAdd")
    Public dtCPOProduction As New DataTable
    Public btnAddFlag As Boolean = True
    Dim columnCPOAdd As DataColumn
    Dim rowCPOAdd As DataRow
    Public dtAddFlag As Boolean = False
    Public AddFlag As Boolean = True
    Public lTempShift As String = String.Empty
    Public dataTFlag As Boolean = False
    Public lSHrs As Decimal = 0.0
    Public lShiftHrs As String = String.Empty
    Dim lbtnAddShift As String = String.Empty
    Dim lHrsStartTime As Integer
    Dim lminStartTime As Integer
    Dim lHrsStopTime As Integer
    Dim lminStopTime As Integer
   
    '   Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,3})?$")
    Dim is3Decimal As Boolean
    Dim re3DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")

    ' Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,0})?$")

    Dim timeFormat As New System.Text.RegularExpressions.Regex("([0-1]?[0-9]|2[0-3]):([0-5]?[0-9]):([0-5]?[0-9])")
    ''For Press Info''''''''''''

    Dim lMachineID As String = String.Empty
    Dim columnPressInfoAdd, ColumnKerRecdAdd As DataColumn
    Dim lbtnAddPressInfo As String = String.Empty
    Dim dtPressInfo As New DataTable("todgPressInfo")
    Dim lProductionLogPressID As String = String.Empty
    Dim lPress As String = String.Empty
    Dim rowMultipleEntryAddKerRecd, rowMultipleEntryPressInfo As DataRow
    Dim lTotalOPHoursStage1 As String = "00:00"
    Dim lTotalOPHoursStage2 As String = "00:00"
    Dim is2Decimal As Boolean
    Dim re2DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim lTotalOPHours As String = String.Empty
    Dim lTotalOPHoursMonth As String = String.Empty
    Dim lTotalOPHoursYear As String = String.Empty
    Public lCPOProductionToday As Decimal = 0
    Dim lstage As String
    Dim lCPOMonth, lCPOYear, lKernelMonth, lKernelYear As Decimal
    Dim lCropYieldID, lCropYieldIDKernel As String
    Dim lBalnceCF As Decimal = 0
    Public Shared PressinfoType As String = String.Empty
    Dim ltotalShifthrs2 As String = "00:00"
    Dim ltotalShifthrs1 As String = "00:00"
    Dim ltotalShifthrs3 As String = "00:00"
    Dim lShifthoursCalc As String = "00:00"
    Dim lmonthValuehrs As String = "00:00"
    Dim lYearValue As String = "00:00"
    Private MonthCount As Integer
    Private YearCount As Integer
    Private lPrevHrs As String = "00:00"
    Private lFFBMonth As Decimal = 0
    Private lFFBYear As Decimal = 0
    Private lFFBReceivedMonth As Decimal = 0
    Private lFFBReceivedYear As Decimal = 0
    Private lLryMonth, lLryYear As Integer
    Private lLryWtMonth As Decimal = 0
    Private lLryWtYear As Decimal = 0
    Private lKLMonth As Decimal = 0
    Private lKLYear As Decimal = 0
    Dim lEBDMonth As String = "00:00"
    Dim lEBDYear As String = "00:00"
    Dim lEPHrsMonth As String = "00:00"
    Dim lEPHrsyear As String = "00:00"
    Dim lMBDMonth As String = "00:00"
    Dim lMBDYear As String = "00:00"
    Dim lPBDMonth As String = "00:00"
    Dim lPBDYear As String = "00:00"
    Dim lTBDMonth As String = "00:00"
    Dim lTBDYear As String = "00:00"
    Dim lmonthValuehrsSumm As String = "00:00"
    Dim lYearValueSumm As String = "00:00"
    Private MonthCountSumm As Integer
    Private YearCountSumm As Integer
    Private lTotalHrs As Decimal
    Private stage2PressSummaryID, stage1PressSummaryID As String
    Private PrevStage1TPH As String = "00:00"
    Private PrevStage2TPH As String = "00:00"

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim lstageCountMonth, lstageCountYear As Integer
    Dim lPrevFFB, lPrevKl, lPrevFFBReceived As Decimal
    Dim lPrevlry As Integer
    Dim lPrevMBD, lPrevEBD, lPrevPBD As String

    Dim lDelete As Integer
    Dim DeleteMultientryPressInfo As New ArrayList
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionLogFrm))
    Shadows mdiparent As New MDIParent





    Private Sub StartDatefunction()


    End Sub
    Private Sub StopDatefunction()

    End Sub
    Private Sub KernelGetTodayQty()

        Dim objCPOPPT As New CPOProductionPPT
        Dim dsCPOToday As DataSet
        objCPOPPT.CropYieldID = lCropYieldIDKernel
        objCPOPPT.CPODate = dtpCPOLogDate.Value
        dsCPOToday = CPOProductionBOL.CPOGetTodayQty(objCPOPPT)
        If Not dsCPOToday Is Nothing Then
            If dsCPOToday.Tables(0).Rows.Count <> 0 Then
                If Not dsCPOToday.Tables(0).Rows(0).Item("QtyToday") Is DBNull.Value Then
                    Me.txtKernalProduction.Text = dsCPOToday.Tables(0).Rows(0).Item("QtyToday")
                Else
                    Me.txtKernalProduction.Text = 0.0
                End If
            End If
        End If

    End Sub
    
    Private Sub CPOGetMonthYearQty()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdQty As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdQty = CPOProductionLogBOL.CPOGetMonthYearQty(objCPOLogPPT)



        If dsProdQty.Tables(6).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs") Is DBNull.Value Then
                lmonthValuehrs = dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs")
                lmonthValuehrs = ToModifyTime(lmonthValuehrs)
            End If
        End If
        If dsProdQty.Tables(13).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs") Is DBNull.Value Then
                lYearValue = dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs")
                lYearValue = ToModifyTime(lYearValue)
            End If
        End If

        MonthCount = dsProdQty.Tables(14).Rows(0).Item("MonthCountHrs")
        YearCount = dsProdQty.Tables(15).Rows(0).Item("YearCountHrs")

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

        If MonthCount = 0 Or (MonthCount = 1 And SaveFlag = False) Then
            txtFFBMonth.Enabled = True
            txtFFBMonthToDate.Enabled = True
            txtLryMonth.Enabled = True
            txtKlMonth.Enabled = True
            txtEBDMonth.Enabled = True
            txtMBDMonth.Enabled = True
            txtPBDMonth.Enabled = True

            txtFFBYear.Enabled = True
            txtFFBYearToDate.Enabled = True
            txtLryYear.Enabled = True
            txtKlYear.Enabled = True
            txtEBDYear.Enabled = True
            txtMBDYear.Enabled = True
            txtPBDYear.Enabled = True



            txtProductionMonth.Enabled = True
        Else
            txtProductionMonth.Enabled = False

            txtFFBMonth.Enabled = False
            txtFFBMonthToDate.Enabled = False
            txtLryMonth.Enabled = False
            txtKlMonth.Enabled = False
            txtEBDMonth.Enabled = False
            txtMBDMonth.Enabled = False
            txtPBDMonth.Enabled = False

            txtFFBYear.Enabled = False
            txtFFBYearToDate.Enabled = False
            txtLryYear.Enabled = False
            txtKlYear.Enabled = False
            txtEBDYear.Enabled = False
            txtMBDYear.Enabled = False
            txtPBDYear.Enabled = False

        End If




        

    End Sub
    Private Sub CPOGetMonthYearElectricalBD()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdEBD As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdEBD = CPOProductionLogBOL.CPOGetMonthYearElectricalBD(objCPOLogPPT)


        If Not dsProdEBD.Tables(6).Rows(0).Item("ElectricalBDMTD") Is DBNull.Value Then
            lEBDMonth = dsProdEBD.Tables(6).Rows(0).Item("ElectricalBDMTD")
            lEBDMonth = ToModifyTime(lEBDMonth)
            txtEBDMonth.Text = lEBDMonth
        End If
        If Not dsProdEBD.Tables(13).Rows(0).Item("ElectricalBDYTD") Is DBNull.Value Then
            lEBDYear = dsProdEBD.Tables(13).Rows(0).Item("ElectricalBDYTD")
            lEBDYear = ToModifyTime(lEBDYear)
            txtEBDYear.Text = lEBDYear
        End If


    End Sub
    Private Sub CPOGetMonthYearEPHours()

        'Dim objCPOLogPPT As New CPOProductionLogPPT
        'Dim dsProdEPH As DataSet
        'objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        'dsProdEPH = CPOProductionLogBOL.CPOGetMonthYearEPHours(objCPOLogPPT)

        'If Not dsProdEPH.Tables(2).Rows(0).Item("MonthTodate") Is DBNull.Value Then
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" And txtTBDMonth.Text <> "" And txtTBDMonth.Text <> "00:00" Then
            lEPHrsMonth = ToSubHours(txtMonthTodate.Text, txtTBDMonth.Text)
            lEPHrsMonth = ToModifyTime(lEPHrsMonth)
            txtEPHrsMonth.Text = lEPHrsMonth
        ElseIf txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then
            txtEPHrsMonth.Text = txtMonthTodate.Text
        End If
      
        'End If
        '' If Not dsProdEPH.Tables(5).Rows(0).Item("YearTodate") Is DBNull.Value Then
        'lEPHrsyear = dsProdEPH.Tables(5).Rows(0).Item("YearTodate")
        'lEPHrsyear = ToModifyTime(lEPHrsyear)
        'txtEPHrsYear.Text = lEPHrsyear
        '' End If
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" And txtTBDYear.Text <> "" And txtTBDYear.Text <> "00:00" Then
            lEPHrsyear = ToSubHours(txtYearTodate.Text, txtTBDYear.Text)
            lEPHrsyear = ToModifyTime(lEPHrsyear)
            txtEPHrsYear.Text = lEPHrsyear
        ElseIf txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then
            txtEPHrsYear.Text = txtYearTodate.Text
        End If

        '''''for 2 digit hours'''
        'If Val(txtEPHrsMonth.Text < 10) Then
        '    txtEPHrsMonth.Text = "0" + txtEPHrsMonth.Text
        ' If
        'If Val(txtEPHrsYear.Text < 10) Then
        '    txtEPHrsYear.Text = "0" + txtEPHrsYear.Text
        ' If


    End Sub
    Private Sub CPOGetMonthYearFFB()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdFFB As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdFFB = CPOProductionLogBOL.CPOGetMonthYearFFB(objCPOLogPPT)


        If Not dsProdFFB.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
            lFFBMonth = dsProdFFB.Tables(0).Rows(0).Item("MonthTodate")
            lFFBReceivedMonth = dsProdFFB.Tables(0).Rows(0).Item("FFBReceivedMTD")
            txtFFBMonth.Text = lFFBMonth
            txtFFBMonthToDate.Text = lFFBReceivedMonth
        Else
            lFFBMonth = 0
            lFFBReceivedMonth = 0
        End If

        If Not dsProdFFB.Tables(1).Rows(0).Item("YearTodate") Is DBNull.Value Then
            lFFBYear = dsProdFFB.Tables(1).Rows(0).Item("YearTodate")
            txtFFBYear.Text = lFFBYear
            lFFBReceivedYear = dsProdFFB.Tables(1).Rows(0).Item("FFBReceivedYTD")
            txtFFBYearToDate.Text = lFFBReceivedYear
        Else
            lFFBYear = 0
            lFFBReceivedYear = 0
        End If




    End Sub
   
    Private Sub CPOGetMonthYearKER()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdKER As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdKER = CPOProductionLogBOL.CPOGetMonthYearKER(objCPOLogPPT)

        If dsProdKER.Tables(0).Rows.Count > 0 Then
            lKernelMonth = dsProdKER.Tables(0).Rows(0).Item("MonthValuesQtyTodayKernel")
            lKernelYear = dsProdKER.Tables(0).Rows(0).Item("YearValuesQtyTodayKernel")
        Else
            lKernelMonth = 0
            lKernelYear = 0

        End If
       




    End Sub
    Private Sub CPOGetMonthYearLorry()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdLry As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdLry = CPOProductionLogBOL.CPOGetMonthYearLorry(objCPOLogPPT)


        If Not dsProdLry.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
            lLryMonth = dsProdLry.Tables(0).Rows(0).Item("MonthTodate")
            txtLryMonth.Text = lLryMonth
        Else
            lLryMonth = 0

        End If

        If Not dsProdLry.Tables(1).Rows(0).Item("YearTodate") Is DBNull.Value Then
            lLryYear = dsProdLry.Tables(1).Rows(0).Item("YearTodate")
            txtLryYear.Text = lLryYear
        Else
            lLryYear = 0
        End If




    End Sub
    Private Sub CPOGetMonthYearLorryWeight()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdWt As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdWt = CPOProductionLogBOL.CPOGetMonthYearLorryWeight(objCPOLogPPT)


        If Not dsProdWt.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
            lLryWtMonth = dsProdWt.Tables(0).Rows(0).Item("MonthTodate")
        Else
            lLryWtMonth = 0
        End If
        If Not dsProdWt.Tables(1).Rows(0).Item("YearTodate") Is DBNull.Value Then
            lLryWtYear = dsProdWt.Tables(1).Rows(0).Item("YearTodate")
        Else
            lLryWtYear = 0
        End If


    End Sub
    Private Sub CPOGetMonthYearLossKernel()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdKl As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdKl = CPOProductionLogBOL.CPOGetMonthYearLossKernel(objCPOLogPPT)


        If Not dsProdKl.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
            lKLMonth = dsProdKl.Tables(0).Rows(0).Item("MonthTodate")
            txtKlMonth.Text = Format(lKLMonth, "0.000")
        Else
            lKLMonth = 0
        End If
        If Not dsProdKl.Tables(1).Rows(0).Item("YearTodate") Is DBNull.Value Then
            lKLYear = dsProdKl.Tables(1).Rows(0).Item("YearTodate")
            txtKlYear.Text = Format(lKLYear, "0.000")
        Else
            lKLYear = 0
        End If

    End Sub
    Private Sub CPOGetMonthYearMechanicalBD()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdMBD As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdMBD = CPOProductionLogBOL.CPOGetMonthYearMechanicalBD(objCPOLogPPT)


        If Not dsProdMBD.Tables(6).Rows(0).Item("MechanicalBDMTD") Is DBNull.Value Then
            lMBDMonth = dsProdMBD.Tables(6).Rows(0).Item("MechanicalBDMTD")
            lMBDMonth = ToModifyTime(lMBDMonth)
            txtMBDMonth.Text = lMBDMonth


        End If
        If Not dsProdMBD.Tables(13).Rows(0).Item("MechanicalBDYTD") Is DBNull.Value Then
            lMBDYear = dsProdMBD.Tables(13).Rows(0).Item("MechanicalBDYTD")
            lMBDYear = ToModifyTime(lMBDYear)
            txtMBDYear.Text = lMBDYear
        End If





    End Sub
    Private Sub CPOGetMonthYearOER()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdOER As DataSet
        objCPOLogPPT.CropYieldID = lCropYieldID
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdOER = CPOProductionLogBOL.CPOGetMonthYearOER(objCPOLogPPT)

        If dsProdOER.Tables(0).Rows.Count > 0 Then
            lCPOMonth = dsProdOER.Tables(0).Rows(0).Item("MonthValuesQtyTodayCPO")
            lCPOYear = dsProdOER.Tables(0).Rows(0).Item("YearValuesQtyTodayCPO")
        Else
            lCPOMonth = 0
            lCPOYear = 0

        End If
       





    End Sub
    Private Sub CPOGetMonthYearProcessingBD()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdPBD As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdPBD = CPOProductionLogBOL.CPOGetMonthYearProcessingBD(objCPOLogPPT)

        If Not dsProdPBD.Tables(6).Rows(0).Item("ProcessingBDMTD") Is DBNull.Value Then
            lPBDMonth = dsProdPBD.Tables(6).Rows(0).Item("ProcessingBDMTD")
            lPBDMonth = ToModifyTime(lPBDMonth)
            txtPBDMonth.Text = lPBDMonth
        End If

        If Not dsProdPBD.Tables(13).Rows(0).Item("ProcessingBDYTD") Is DBNull.Value Then
            lPBDYear = dsProdPBD.Tables(13).Rows(0).Item("ProcessingBDYTD")
            lPBDYear = ToModifyTime(lPBDYear)
            txtPBDYear.Text = lPBDYear
        End If




    End Sub
    Private Sub CPOGetMonthYearThroughput()

        'Dim objCPOLogPPT As New CPOProductionLogPPT
        'Dim dsProdTpt As DataSet
        'objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        'dsProdTpt = CPOProductionLogBOL.CPOGetMonthYearThroughput(objCPOLogPPT)

        'If dsProdTpt.Tables(0).Rows.Count <> 0 Then
        '    If Not dsProdTpt.Tables(0).Rows(0).Item("MonthTodate") Is DBNull.Value Then
        '        Me.txtTpMonth.Text = dsProdTpt.Tables(0).Rows(0).Item("MonthTodate")
        '    Else
        '        Me.txtTpMonth.Text = ""
        '    End If
        '    If Not dsProdTpt.Tables(1).Rows(0).Item("YearTodate") Is DBNull.Value Then
        '        Me.txtTpYear.Text = dsProdTpt.Tables(1).Rows(0).Item("YearTodate")
        '    Else
        '        Me.txtTpYear.Text = ""
        '    End If
        'End If



    End Sub
    Private Sub CPOGetMonthYearTotalBD()


        lTBDMonth = ToaddHours(txtMBDMonth.Text, txtEBDMonth.Text)
        lTBDMonth = ToaddHours(lTBDMonth, txtPBDMonth.Text)
        lTBDMonth = ToModifyTime(lTBDMonth)
        txtTBDMonth.Text = lTBDMonth
       
        lTBDYear = ToaddHours(txtMBDYear.Text, txtEBDYear.Text)
        lTBDYear = ToaddHours(lTBDYear, txtPBDYear.Text)
        lTBDYear = ToModifyTime(lTBDYear)
        txtTBDYear.Text = lTBDYear

    End Sub
    Private Sub CPOGetFFBNetWeight()

        txtFFBReceived.Text = "0"
        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsFFB As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsFFB = CPOProductionLogBOL.CPOGetFFBNetWeight(objCPOLogPPT)

        If dsFFB.Tables(0).Rows.Count <> 0 Then
            If Not dsFFB.Tables(0).Rows(0).Item("NetWeight") Is DBNull.Value Then
                Me.txtFFBReceived.Text = Val(dsFFB.Tables(0).Rows(0).Item("NetWeight"))
                '   txtFFBReceived.Text = Val(txtFFBReceived.Text) / 1000
            Else
                Me.txtFFBReceived.Text = 0
            End If
        End If


    End Sub
    Private Sub FormatDateTimePicker(ByVal dtpName)
        dtpName.Format = DateTimePickerFormat.Custom
        dtpName.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub CPOProductionLogFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (dgvCPOLogDetails.RowCount > 0 Or dgPressInfo.RowCount > 0) And btnSave.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M88"

            End If
        End If
    End Sub
    Private Sub CPOProductionLogFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CPOProductionLogFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        ' btnSave.Enabled = False
        dtpCPOLogDate.Enabled = True
        Dim objCPOLogPPT As New CPOProductionLogPPT
        '  Dim dsFFBLorry As New DataSet
        ''''''' For line1 in Press Info Tab''''''''
        ddlStage.SelectedIndex = 0
        '''''''''''''''''''''''''''''''''''''''''''

        Dim objCPOPPT As New CPOProductionPPT
        Dim dsCrop As New DataSet
        dsCrop = CPOProductionBOL.ProductionCropYieldIDSelect(objCPOPPT)
        If dsCrop.Tables(0).Rows.Count <> 0 Then
            lCropYieldID = dsCrop.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg1")
            ''MsgBox("No Record in Crop yield for CPO , Please insert the record in General Crop Yield")
        End If

        Dim objKernelPPT As New KernalProductionPPT
        Dim dsCropK As New DataSet
        dsCropK = KernalProductionBOL.ProductionCropYieldIDSelect(objKernelPPT)
        If dsCropK.Tables(0).Rows.Count <> 0 Then
            lCropYieldIDKernel = dsCropK.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg2")
            ''MsgBox("No Record in Crop yield for Kernel , Please insert the record in General Crop Yield")
        End If
        Clear()
        ClearGridView(dgPressInfo)
        ClearLogExpress()
        ClearShift()
        StartDatefunction()
        StopDatefunction()

        'StartDatefunction()
        'StopDatefunction()
        txtTotalHours.Text = ""
        CPOGetMonthYearQty()

        'edit
        'dtpCPOLogDate.Value = Date.Today
        'dtpCPOLogViewDate.Value = Date.Today

        BalanceBF()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpCPOLogDate)
        'FormatDateTimePicker(dtpCPOLogDate)
        CPOGetMonthYearFFB()
        CPOGetFFBNetWeight()
        KernelGetTodayQty()
        CPOLogFFBLorryProcessed()
        txtBudget.Text = 0
        txtFFBVariance.Text = 0
        txtFFBMonthToDate.Text = 0
        CPOGetMonthYearElectricalBD()
        CPOGetMonthYearMechanicalBD()
        CPOGetMonthYearProcessingBD()


        CPOGetMonthYearEPHours()
        CPOGetMonthYearTotalBD()

        tcCPOProductionLog.SelectedTab = tpCPOProductionView
        CPOLogGridViewBind()

        cboShift.SelectedIndex = 0
        ddlStage.SelectedIndex = 0
        ddlScrewStatus.SelectedIndex = 0
        ClearGridView(dgPressInfo)
        'DatePicker()

    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            ''lblDate.Text = rm.GetString("Date")
            ''Label164.Text = rm.GetString("SearchBy")

            ''Label17.Text = rm.GetString("Shift")
            ''lblAssistant.Text = rm.GetString("Assistant")
            ''lblMandor.Text = rm.GetString("Mandore")
            ''lblStartTime.Text = rm.GetString("StartTime")
            ''lblStopTime.Text = rm.GetString("StopTime")
            ' lShiftHours.Text = rm.GetString("ShiftHrs")
            ''lblFFBProcessed.Text = rm.GetString("FFBProcessed")
            ''lblLorryProcessed.Text = rm.GetString("LorryProcessed")
            btnAddShift.Text = rm.GetString("Add")
            btnResetShift.Text = rm.GetString("Reset")

            'dgvCPOLogDetails.Columns("Shift").HeaderText = rm.GetString("Shift")
            'dgvCPOLogDetails.Columns("Assistant").HeaderText = rm.GetString("Assistant")
            'dgvCPOLogDetails.Columns("Mandore").HeaderText = rm.GetString("Mandore")
            'dgvCPOLogDetails.Columns("Start_Time").HeaderText = rm.GetString("StartTime")
            'dgvCPOLogDetails.Columns("Stop_Time").HeaderText = rm.GetString("StopTime")
            'dgvCPOLogDetails.Columns("ShiftHours").HeaderText = rm.GetString("ShiftHrs")
            'dgvCPOLogDetails.Columns("FFB_Processed").HeaderText = rm.GetString("FFBProcessed")
            'dgvCPOLogDetails.Columns("Lorry_Processed").HeaderText = rm.GetString("LorryProcessed")
            ' ''lblTotalHours.Text = rm.GetString("Totalhours")
            ''lblMonthTodate.Text = rm.GetString("MonthtoDate")
            ''lblYearTodate.Text = rm.GetString("YearTodate")


            ''lblBalanceToday.Text = rm.GetString("Today")
            ''lblBalanceLorry.Text = rm.GetString("NoOfLorry")
            ''lblFFBReceived.Text = rm.GetString("FFBreceived")
            ''lblBudget.Text = rm.GetString("Budget")
            ''lblFFBNoofLorry.Text = rm.GetString("NoOfLorry")
            ''lblBudgetMonthdate.Text = rm.GetString("MonthtoDate")
            ''lblVariance.Text = rm.GetString("Variance")
            ''lblFFB.Text = rm.GetString("FFB")
            ''lblNoOfLorry.Text = rm.GetString("NoOfLorry")
            ''lblUnFFB.Text = rm.GetString("FFB")
            ''lblUnNoOfLorry.Text = rm.GetString("NoOfLorry")
            ''lblKernelProduction.Text = rm.GetString("KernelProduction")
            ''lblLossOnKernel.Text = rm.GetString("LossonKernel")



            ''lblToday.Text = rm.GetString("Today")
            ''lblMonthDate.Text = rm.GetString("MonthtoDate")
            ''lblYearDate.Text = rm.GetString("YearTodate")
            ''lblProcessedFFB.Text = rm.GetString("FFBProcessed")
            ''lblNoOfLorryInfo.Text = rm.GetString("NoOfLorry")
            ''lblAvgLorryWeight.Text = rm.GetString("AverageLorryWeight")
            ''lblLossOnKernelInfo.Text = rm.GetString("LossonKernel")
            ''lblMBD.Text = rm.GetString("MechanicalBreakDown")
            ''lblEBD.Text = rm.GetString("ElectricalBreakDown")
            ''lblPBD.Text = rm.GetString("ProcessingBreakDown")
            ''lblTBD.Text = rm.GetString("TotalBreakDown")
            ''lblEPH.Text = rm.GetString("ElectricalBreakDown")
            ''lblThroughput.Text = rm.GetString("Throughput")
            ''lblAvgPressThroughPut.Text = rm.GetString("AveragePressThroughput")
            ''lblOER.Text = rm.GetString("OER")
            ''lblKER.Text = rm.GetString("KER")
            ''lblRemarks.Text = rm.GetString("Remarks")

            ''lblStage.Text = rm.GetString("Stage")
            ''lblOPHrs.Text = rm.GetString("Op.Hrs")
            ''lblMeterTo.Text = rm.GetString("MeterTo")
            ''lblAgeOfscrew.Text = rm.GetString("AgeOfscrew")
            ''lblMeterFrom.Text = rm.GetString("MeterFrom")
            ''lblScrewStatus.Text = rm.GetString("ScrewsStatus")
            ''lblPressNo.Text = rm.GetString("PressNo")
            ''lblCapacity.Text = rm.GetString("Capacity")

            btnAddPressInfo.Text = rm.GetString("Add")
            btnResetPressinfo.Text = rm.GetString("Reset")


            'dgPressInfo.Columns("dgMeStage").HeaderText = rm.GetString("Stage")
            'dgPressInfo.Columns("dgMeScrewAge").HeaderText = rm.GetString("AgeOfscrew")
            'dgPressInfo.Columns("dgMePressNo").HeaderText = rm.GetString("PressNo")
            'dgPressInfo.Columns("dgMeCapacity").HeaderText = rm.GetString("Capacity")
            'dgPressInfo.Columns("dgMeOPHrs").HeaderText = rm.GetString("Op.Hrs")
            'dgPressInfo.Columns("dgMeMeterFrom").HeaderText = rm.GetString("MeterFrom")
            'dgPressInfo.Columns("dgMeMeterTo").HeaderText = rm.GetString("MeterTo")
            'dgPressInfo.Columns("dgMeScrewStatus").HeaderText = rm.GetString("ScrewsStatus")


            ''lblTotalHoursPress.Text = rm.GetString("TotalhoursPress")
            ''lvlAvgpresstp.Text = rm.GetString("AveragePressThroughput")
            ''lblCakeProcess.Text = rm.GetString("CakeProcess")
            ''lblPressToday.Text = rm.GetString("Today")
            ''lblPressMonth.Text = rm.GetString("MonthtoDate")
            ''lblPressYear.Text = rm.GetString("YearTodate")
            ''lblTotalPressHours.Text = rm.GetString("TotalhoursPress")
            ''lblAveragePressThroughput.Text = rm.GetString("AveragePressThroughput")
            ''lblUtilisation.Text = rm.GetString("Utilisation")

            ''lblTotalPHStage1.Text = rm.GetString("Stage1")
            ''lblTotalPHStage2.Text = rm.GetString("Stage2")
            ''lblAvgPressStage1.Text = rm.GetString("Stage1")
            ''lblAvgPressStage2.Text = rm.GetString("Stage2")
            ''lblUtilisationStage1.Text = rm.GetString("Stage1")
            ''lblUtilisationStage2.Text = rm.GetString("Stage2")



            btnSave.Text = rm.GetString("SaveAll")
            btnReset.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")

            'chkCPOLogDate.Text = rm.GetString("Date")
            'dgvCPOView.Columns("gvCPODate").HeaderText = rm.GetString("Date")
            btnViewSearch.Text = rm.GetString("ViewSearch")
            btnView.Text = rm.GetString("ViewReports")

        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CPOLogFFBLorryProcessed()


        'Dim objCPOLogPPT As New CPOProductionLogPPT
        'Dim dsFFBLorry As New DataSet
        'txtTodayFFB.Text = "0"

        ''''''For FFb Lorry Processed '''''
        ' ''YDAY Date Calculation''


        'objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value

        'dsFFBLorry = CPOProductionLogBOL.CPOLogFFBLorryProcessed(objCPOLogPPT)
        'If dsFFBLorry.Tables(0).Rows.Count <> 0 Then
        '    If Not dsFFBLorry.Tables(0).Rows(0).Item("BalanceFFBCFQty") Is DBNull.Value Then
        '        txtTodayFFB.Text = dsFFBLorry.Tables(0).Rows(0).Item("BalanceFFBCFQty")
        '    Else
        '        txtTodayFFB.Text = String.Empty
        '    End If
        '    If Not dsFFBLorry.Tables(0).Rows(0).Item("BalanceFFBCFNoLorry") Is DBNull.Value Then
        '        txtNoOfLorry.Text = dsFFBLorry.Tables(0).Rows(0).Item("BalanceFFBCFNoLorry")
        '    Else
        '        txtNoOfLorry.Text = String.Empty
        '    End If

        '    txtTodayFFB.Enabled = true
        '    txtNoOfLorry.Enabled = False
        'Else
        '    txtTodayFFB.Enabled = True
        '    txtNoOfLorry.Enabled = True
        'End If
        ''Else



    End Sub

    Private Sub txtFFBReceived_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBReceived.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub
    Private Sub txtFFBReceived_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBReceived.Leave
        BalanceCFCalculation()
    End Sub
    Private Function IsCheckValidation()
        If (txtFFBProcessed.Text.Trim = "") Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is Required", "FFB Processed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tcCPOLog.SelectedTab = tbProduction
            txtFFBProcessed.Focus()
            Return False
        End If
        If (txtLorryProcessed.Text.Trim = "") Then
            DisplayInfoMessage("Msg4")
            ''MessageBox.Show("This field is Required", "Lorry Processed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tcCPOLog.SelectedTab = tbProduction
            txtLorryProcessed.Focus()
            Return False
        End If

        If cboShift.Text = "" Or cboShift.Text = "--Select Shift--" Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This field is Required", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tcCPOLog.SelectedTab = tbProduction
            'txtLorryProcessed.Focus()
            Return False
        End If

       
        Return True
    End Function

    Public Sub FindTotalhrs()


        ''  If Not Val(cmbCPOLogStopHrs.Text) = Val(cmbCPOLogStartHrs.Text) Then
        '''''For Hours''''''

        'Dim strTotalhrs As String = String.Empty

        'If Val(cmbCPOLogStopHrs.Text) > Val(cmbCPOLogStartHrs.Text) Then
        '    strTotalhrs = Val(cmbCPOLogStopHrs.Text) - Val(cmbCPOLogStartHrs.Text)
        'ElseIf Val(cmbCPOLogStartHrs.Text) > Val(cmbCPOLogStopHrs.Text) Then
        '    strTotalhrs = 24 - Val(cmbCPOLogStartHrs.Text) + Val(cmbCPOLogStopHrs.Text)
        'ElseIf Val(cmbCPOLogStopMin.Text) < Val(cmbCPOLogStartMin.Text) Then
        '    strTotalhrs = 24
        'Else
        '    strTotalhrs = 0
        'End If
        '''''For Mins''''''
        'Dim strTotalMins As String = 0
        'If Val(cmbCPOLogStopMin.Text) > Val(cmbCPOLogStartMin.Text) Then
        '    strTotalMins = Val(cmbCPOLogStopMin.Text) - Val(cmbCPOLogStartMin.Text)

        'ElseIf Val(cmbCPOLogStartMin.Text) > Val(cmbCPOLogStopMin.Text) Then
        '    strTotalMins = 60 - Val(cmbCPOLogStartMin.Text) + Val(cmbCPOLogStopMin.Text)
        '    strTotalhrs = Val(strTotalhrs) - 1

        'Else
        '    strTotalMins = "00"
        'End If
        'If Val(strTotalhrs) < 10 Then
        '    strTotalhrs = "0" + strTotalhrs
        'End If
        'If strTotalMins = "5" Then
        '    strTotalMins = "05"
        'End If
        'If strTotalhrs <> Nothing Then
        '    txtShiftHrs.Text = strTotalhrs + ":" + strTotalMins
        '    lShiftHrs = txtShiftHrs.Text
        'Else
        '    strTotalhrs = "00"
        '    txtShiftHrs.Text = strTotalhrs + ":" + strTotalMins
        '    lShiftHrs = Val(txtShiftHrs.Text)
        'End If
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionLogFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub GetProductionLogShifts()


        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim objCPOLogBOL As New CPOProductionLogBOL

        objCPOLogPPT.CPOProductionLogID = lCPOProductionLogID

        Dim ds As New DataSet

        'ds = PKOProductionLogBOL.GetPKOProductionLogShiftSelect(objPKOProductionLogPPT)
        'ds = CPOProductionLogBOL.GetCPOLogShiftInfo(objCPOLogPPT)
        ds = CPOProductionLogBOL.GetCPOLogShiftInfo(objCPOLogPPT)

        If ds.Tables(0).Rows.Count <> 0 And ds IsNot Nothing Then

            Dim lTableCount As Integer = 0

            If ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 3
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString = String.Empty Then
                lTableCount = 2
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 2
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString = String.Empty Then
                lTableCount = 1
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 2
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString = String.Empty Then
                lTableCount = 1
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 1
            End If


            Dim lintrowcount As Integer = 0
            Dim lShift1String, lShift2String, lShift3String As String
            lShift1String = "False"
            lShift2String = "False"
            lShift3String = "False"


            While (lTableCount > 0)

                Dim intRowcount As Integer = dtCPOAdd.Rows.Count


                rowCPOAdd = dtCPOAdd.NewRow()

                If lintrowcount = 0 Then

                    Try

                    

                        columnCPOAdd = New DataColumn("Shift", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("Assistant", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("Mandore", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("StartTime", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("EndTime", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("TotalBreakdown", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("ShiftHours", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("FFBProcessed", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                        columnCPOAdd = New DataColumn("LorryProcessed", System.Type.[GetType]("System.String"))
                        dtCPOAdd.Columns.Add(columnCPOAdd)
                    Catch ex As Exception

                    End Try


                    If ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty Then

                        rowCPOAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift1").ToString
                        rowCPOAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID1").ToString
                        rowCPOAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID1").ToString
                        rowCPOAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        rowCPOAdd("EndTime") = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        rowCPOAdd("TotalBreakdown") = ds.Tables(0).Rows(0).Item("TotalBreakdown1").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShiftHrs = strTotalhrs + ":" + strTotalMins
                        rowCPOAdd("ShiftHours") = lShiftHrs

                        rowCPOAdd("FFBProcessed") = ds.Tables(0).Rows(0).Item("FFBProcessedEst1").ToString
                        rowCPOAdd("LorryProcessed") = ds.Tables(0).Rows(0).Item("LorryProcessedEst1").ToString
                        dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                        lShift1String = "True"
                    ElseIf ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty Then
                        rowCPOAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift2").ToString
                        rowCPOAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID2").ToString
                        rowCPOAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID2").ToString
                        rowCPOAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        rowCPOAdd("EndTime") = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        rowCPOAdd("TotalBreakdown") = ds.Tables(0).Rows(0).Item("TotalBreakdown2").ToString

                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShiftHrs = strTotalhrs + ":" + strTotalMins
                        rowCPOAdd("ShiftHours") = lShiftHrs
                        rowCPOAdd("FFBProcessed") = ds.Tables(0).Rows(0).Item("FFBProcessedEst2").ToString
                        rowCPOAdd("LorryProcessed") = ds.Tables(0).Rows(0).Item("LorryProcessedEst2").ToString
                        dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                        lShift2String = "True"

                    ElseIf ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                        rowCPOAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift3").ToString
                        rowCPOAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID3").ToString
                        rowCPOAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID3").ToString
                        rowCPOAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        rowCPOAdd("EndTime") = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        rowCPOAdd("TotalBreakdown") = ds.Tables(0).Rows(0).Item("TotalBreakdown3").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShiftHrs = strTotalhrs + ":" + strTotalMins
                        rowCPOAdd("ShiftHours") = lShiftHrs

                        rowCPOAdd("FFBProcessed") = ds.Tables(0).Rows(0).Item("FFBProcessedEst3").ToString
                        rowCPOAdd("LorryProcessed") = ds.Tables(0).Rows(0).Item("LorryProcessedEst3").ToString
                        dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                        lShift3String = "True"
                    End If

                Else

                    If ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And lShift1String <> "True" Then
                        rowCPOAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift1").ToString
                        rowCPOAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID1").ToString
                        rowCPOAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID1").ToString
                        rowCPOAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        rowCPOAdd("EndTime") = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        rowCPOAdd("TotalBreakdown") = ds.Tables(0).Rows(0).Item("TotalBreakdown1").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShiftHrs = strTotalhrs + ":" + strTotalMins
                        rowCPOAdd("ShiftHours") = lShiftHrs


                        rowCPOAdd("FFBProcessed") = ds.Tables(0).Rows(0).Item("FFBProcessedEst1").ToString
                        rowCPOAdd("LorryProcessed") = ds.Tables(0).Rows(0).Item("LorryProcessedEst1").ToString
                        dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                        lShift1String = "True"



                    ElseIf ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And lShift2String <> "True" Then
                        rowCPOAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift2").ToString
                        rowCPOAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID2").ToString
                        rowCPOAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID2").ToString
                        rowCPOAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        rowCPOAdd("EndTime") = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        rowCPOAdd("TotalBreakdown") = ds.Tables(0).Rows(0).Item("TotalBreakdown2").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShiftHrs = strTotalhrs + ":" + strTotalMins
                        rowCPOAdd("ShiftHours") = lShiftHrs

                        rowCPOAdd("FFBProcessed") = ds.Tables(0).Rows(0).Item("FFBProcessedEst2").ToString
                        rowCPOAdd("LorryProcessed") = ds.Tables(0).Rows(0).Item("LorryProcessedEst2").ToString
                        dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                        lShift2String = "True"


                    ElseIf ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty And lShift3String <> "True" Then
                        rowCPOAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift3").ToString
                        rowCPOAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID3").ToString
                        rowCPOAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID3").ToString
                        rowCPOAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        rowCPOAdd("EndTime") = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        rowCPOAdd("TotalBreakdown") = ds.Tables(0).Rows(0).Item("TotalBreakdown3").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShiftHrs = strTotalhrs + ":" + strTotalMins
                        rowCPOAdd("ShiftHours") = lShiftHrs

                        rowCPOAdd("FFBProcessed") = ds.Tables(0).Rows(0).Item("FFBProcessedEst3").ToString
                        rowCPOAdd("LorryProcessed") = ds.Tables(0).Rows(0).Item("LorryProcessedEst3").ToString
                        dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)
                        lShift3String = "True"
                    End If

                End If
                lintrowcount = lintrowcount + 1
                lTableCount = lTableCount - 1
            End While

            'txtFFBToday.Text = ds.Tables(0).Rows(0).Item("KernelProcessedEST1").ToString + ds.Tables(0).Rows(0).Item("KernelProcessedEST2").ToString + ds.Tables(0).Rows(0).Item("KernelProcessedEST3").ToString

            btnAddFlag = True

            With dgvCPOLogDetails

                .AutoGenerateColumns = False
                .DataSource = dtCPOAdd
                'TotalHourShiftsKernelProcessedCalculation()

            End With

        End If



    End Sub
    Private Sub TotalHourShiftsKernelProcessedCalculation()

        Dim objDataGridViewRow As New DataGridViewRow
        Dim lFFBProcessed As Decimal = 0
        Dim lLorryProcessed As Decimal = 0
        lShifthoursCalc = "00:00"

        For Each objDataGridViewRow In dgvCPOLogDetails.Rows

            If objDataGridViewRow.Cells("Shifthours").Value.ToString <> String.Empty Then
                Dim lCominValue As String = "00:00"
                lCominValue = objDataGridViewRow.Cells("Shifthours").Value

                lShifthoursCalc = lShifthoursCalc
                'Dim ProcessHrs As String
                Dim strArr As String()
                Dim strArr1 As String()

                Dim Str, Str1 As String
                Str = lCominValue
                strArr = Str.Split(":")
                Str1 = lShifthoursCalc
                strArr1 = Str1.Split(":")

                Dim Lhrs, lmin As Integer
                Lhrs = CInt(strArr(0)) + CInt(strArr1(0))

                lmin = CInt(strArr(1)) + CInt(strArr1(1))
                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If
                Dim Strhrs As String = "00"
                Dim StrMin As String = "00"

                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If
                lShifthoursCalc = Strhrs + ":" + StrMin
            End If

        Next

        For Each objDataGridViewRow In dgvCPOLogDetails.Rows

            If objDataGridViewRow.Cells("FFB_Processed").Value.ToString <> String.Empty Then
                lFFBProcessed = lFFBProcessed + Val(objDataGridViewRow.Cells("FFB_Processed").Value.ToString())

            End If
            If objDataGridViewRow.Cells("Lorry_Processed").Value.ToString <> String.Empty Then
                lLorryProcessed = lLorryProcessed + Val(objDataGridViewRow.Cells("Lorry_Processed").Value.ToString())

            End If
        Next

        txtProcessedFFBToday.Text = lFFBProcessed
        txtProcessedLorry.Text = lLorryProcessed
        txtTotalShiftFFBProcessed.Text = lFFBProcessed
        txtTotalShiftLorryProcessed.Text = lLorryProcessed
        txtTotalHours.Text = lShifthoursCalc
        txtEPHrsToday.Text = lShifthoursCalc


    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim objCPOLogPPT As New CPOProductionLogPPT

        Dim ds As DataSet

        If dgvCPOLogDetails.RowCount = 0 Then
            DisplayInfoMessage("Msg6")
            ''MessageBox.Show("Shift information Record is required", "Shift")
            tcCPOLog.SelectedIndex = 0
            cboShift.Focus()
            Exit Sub
        End If
        If txtMonthTodate.Text = "" Then
            DisplayInfoMessage("Msg7")
            ''MessageBox.Show("This field is required", "Month To Date")
            txtMonthTodate.Focus()
            Exit Sub
        End If
        If txtYearTodate.Text = "" Then
            DisplayInfoMessage("Msg8")
            ''MessageBox.Show("This field is required", "Year To Date")
            txtYearTodate.Focus()
            Exit Sub
        End If

        If Val(txtFFBMonthToDate.Text) = 0 Then
            DisplayInfoMessage("Msg711")
            ''MessageBox.Show("This field is required", "Month To Date")
            txtFFBMonthToDate.Focus()
            Exit Sub
        End If
        If Val(txtFFBYearToDate.Text) = 0 Then
            DisplayInfoMessage("Msg811")
            ''MessageBox.Show("This field is required", "Year To Date")
            txtFFBYearToDate.Focus()
            Exit Sub
        End If


        If Val(txtProcessedFFBToday.Text) < 0 Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("This field is required", "FFB Processed")
            txtProcessedFFBToday.Focus()
            Exit Sub
        End If

        If txtProcessedLorry.Text = "" Then
            txtProcessedLorry.Text = "0"
        End If

        'If Val(txtProcessedLorry.Text) = 0 Then
        '    DisplayInfoMessage("Msg10")
        '    ''MessageBox.Show("This field is required", "No of Lorry Processed")
        '    txtProcessedLorry.Focus()
        '    Exit Sub
        'End If



        If lBalnceCF < 0 Then
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show("FFB Processed should be less than sum of balance b/f and ffb received", "BSP")
            txtFFBReceived.Focus()
            Exit Sub
        End If
        If txtEPHrsToday.Text = "00:00" Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show("Effective processing hours cant be 0,then there can be no FFB processed.", "BSP")
            txtMBToday.Focus()
            Exit Sub
        End If
        If txtTPHTodaystage1.Text <> "" Then
            If txtTPHMonthTodateStage1.Text = "00:00" Or txtTPHMonthTodateStage1.Text = "" Then
                DisplayInfoMessage("Msg13")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 1")
                txtTPHMonthTodateStage1.Focus()
                Exit Sub
            End If

            If txtTPHYearTodateStage1.Text = "00:00" Or txtTPHYearTodateStage1.Text = "" Then
                DisplayInfoMessage("Msg14")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 2")
                txtTPHYearTodateStage1.Focus()
                Exit Sub
            End If

        End If

        If txtStage2TodayTPH.Text <> "" Then
            If txtStage2monthTodate.Text = "00:00" Or txtStage2monthTodate.Text = "" Then
                DisplayInfoMessage("Msg14")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 2")
                txtStage2monthTodate.Focus()
                Exit Sub
            End If

            If txtStage2yearTodate.Text = "00:00" Or txtStage2yearTodate.Text = "" Then
                DisplayInfoMessage("Msg14")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 2")
                txtStage2yearTodate.Focus()
                Exit Sub
            End If

        End If


        If txtMonthTodate.Enabled = True Then
            If txtMonthTodate.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtMonthTodate.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTotalHours.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg15")
                    ''MessageBox.Show("Month To Date Hrs cant be lesser than Total Hrs")
                    txtMonthTodate.Focus()
                    Exit Sub
                End If
            End If

        End If
        If txtYearTodate.Enabled = True Then
            If txtYearTodate.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtYearTodate.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTotalHours.Text
                strArrTotal = strTotal.Split(":")

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtMonthTodate.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg16")
                    ''MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
                    txtYearTodate.Focus()
                    Exit Sub
                End If

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg17")
                    ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                    txtYearTodate.Focus()
                    Exit Sub
                End If
            End If
        End If

        'Sai Comment
        'If Val(txtFFBToday.Text) > Val(txtFFBMonth.Text) Then
        '    DisplayInfoMessage("Msg18")
        '    ''MessageBox.Show("FFB Processed Month to date Value should be greater than FFB Processed today qty")
        '    txtFFBMonth.Focus()
        '    Exit Sub
        'End If
        If Val(txtFFBYear.Text) < Val(txtFFBToday.Text) Then
            DisplayInfoMessage("Msg19")
            ''MessageBox.Show(" FFB Processed Year to date Value should be greater than FFB Processed today qty")
            txtFFBYear.Focus()
            Exit Sub
        End If

        If Val(txtFFBYear.Text) < Val(txtFFBMonth.Text) Then
            DisplayInfoMessage("Msg20")
            ''MessageBox.Show("FFB Processed Year to date Value should be greater than FFB Processed month to date")
            txtFFBYear.Focus()
            Exit Sub
        End If

        If txtFFBMonthToDate.Enabled = True Then
            'Sai Comment
            'If Val(txtFFBReceived.Text) > Val(txtFFBMonthToDate.Text) Then
            '    DisplayInfoMessage("Msg181")
            '    ''MessageBox.Show("FFB Processed Month to date Value should be greater than FFB Processed today qty")
            '    txtFFBMonth.Focus()
            '    Exit Sub
            'End If
            If Val(txtFFBYearToDate.Text) < Val(txtFFBReceived.Text) Then
                DisplayInfoMessage("Msg191")
                ''MessageBox.Show(" FFB Processed Year to date Value should be greater than FFB Processed today qty")
                txtFFBYear.Focus()
                Exit Sub
            End If

            If Val(txtFFBYearToDate.Text) < Val(txtFFBMonthToDate.Text) Then
                DisplayInfoMessage("Msg201")
                ''MessageBox.Show("FFB Processed Year to date Value should be greater than FFB Processed month to date")
                txtFFBYear.Focus()
                Exit Sub
            End If


        End If



        If Val(txtLryToday.Text) > Val(txtLryMonth.Text) Then
            DisplayInfoMessage("Msg21")
            '' MessageBox.Show("No Of Lorry Month to date Value should be greater than No Of Lorry today qty")
            txtLryMonth.Focus()
            Exit Sub
        End If
        If Val(txtLryYear.Text) < Val(txtLryToday.Text) Then
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show("No Of Lorry Year to date Value should be greater than No Of Lorry today qty")
            txtLryYear.Focus()
            Exit Sub
        End If

        If Val(txtLryYear.Text) < Val(txtLryMonth.Text) Then
            DisplayInfoMessage("Msg23")
            ''MessageBox.Show("No Of Lorry Year to date Value should be greater than No Of Lorry month to date")
            txtLryYear.Focus()
            Exit Sub
        End If


        If Val(txtFFBToday.Text) <> 0 Then
            If Val(txtFFBMonth.Text) = 0 Then
                DisplayInfoMessage("Msg24")
                ''MessageBox.Show("This field is required", "FFB Processed Month")
                txtFFBMonth.Focus()
                Exit Sub
            End If

            If Val(txtFFBYear.Text) = 0 Then
                DisplayInfoMessage("Msg25")
                '' MessageBox.Show("This field is required", "FFB Processed Year")
                txtFFBYear.Focus()
                Exit Sub
            End If
        End If
        If Val(txtLryToday.Text) <> 0 Then

            If Val(txtLryMonth.Text) = 0 Then
                DisplayInfoMessage("Msg26")
                '' MessageBox.Show("This field is required", "No of Month")
                txtLryMonth.Focus()
                Exit Sub
            End If
            If Val(txtLryYear.Text) = 0 Then
                DisplayInfoMessage("Msg27")
                ''MessageBox.Show("This field is required", "No of Year")
                txtLryYear.Focus()
                Exit Sub
            End If

        End If

        If Val(txtKlToday.Text) <> 0 Then

            If Val(txtKlMonth.Text) = 0 Then
                DisplayInfoMessage("Msg28")
                '' MessageBox.Show("This field is required", "Loss On Kernel Month")
                txtKlMonth.Focus()
                Exit Sub
            End If

            If Val(txtKlYear.Text) = 0 Then
                DisplayInfoMessage("Msg29")
                ''MessageBox.Show("This field is required", "Loss On Kernel Year")
                txtKlYear.Focus()
                Exit Sub
            End If

        End If

        If txtMBToday.Text <> "" And txtMBToday.Text <> "00:00" Then
            If txtMBDMonth.Text = "" Then
                DisplayInfoMessage("Msg30")
                ''MessageBox.Show("This field is required", "Mechanical Breakdown Month")
                txtMBDMonth.Focus()
                Exit Sub
            End If

            If txtMBDYear.Text = "" Then
                DisplayInfoMessage("Msg31")
                ''MessageBox.Show("This field is required", "Mechanical Breakdown Year")
                txtMBDYear.Focus()
                Exit Sub
            End If
        End If

        If txtEBDToday.Text <> "" And txtEBDToday.Text <> "00:00" Then

            If txtEBDMonth.Text = "" Then
                DisplayInfoMessage("Msg32")
                ''MessageBox.Show("This field is required", "Electrical Breakdown Month")
                txtEBDMonth.Focus()
                Exit Sub
            End If

            If txtEBDYear.Text = "" Then
                DisplayInfoMessage("Msg33")
                ''MessageBox.Show("This field is required", "Electrical Breakdown Year")
                txtEBDYear.Focus()
                Exit Sub
            End If

        End If
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            If txtPBDMonth.Text = "" Then
                DisplayInfoMessage("Msg34")
                '' MessageBox.Show("This field is required", "Processing Breakdown Month")
                txtPBDMonth.Focus()
                Exit Sub
            End If

            If txtPBDYear.Text = "" Then
                DisplayInfoMessage("Msg35")
                ''MessageBox.Show("This field is required", "Processing Breakdown Year")
                txtPBDYear.Focus()
                Exit Sub
            End If

        End If



        If Val(txtKlToday.Text) > Val(txtKlMonth.Text) Then
            DisplayInfoMessage("Msg36")
            ''MessageBox.Show("Loss Of Kernel Month to date Value should be greater than Loss Of Kernel today qty")
            txtKlMonth.Focus()
            Exit Sub
        End If
        If Val(txtKlYear.Text) < Val(txtKlToday.Text) Then
            DisplayInfoMessage("Msg37")
            '' MessageBox.Show("Loss Of Kernel Year to date Value should be greater than Loss Of Kernel today qty")
            txtKlYear.Focus()
            Exit Sub
        End If

        If Val(txtKlYear.Text) < Val(txtKlMonth.Text) Then
            DisplayInfoMessage("Msg38")
            ''MessageBox.Show("Loss Of Kernel Year to date Value should be greater than Loss Of Kernel month to date")
            txtKlYear.Focus()
            Exit Sub
        End If

        '  If txtMBDMonth.Enabled = True Then
        If txtTBDToday.Text <> "" And txtTotalHours.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtTotalHours.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTBDToday.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg64")
                ''MessageBox.Show("Mechanical Breakdown Month To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                txtMBDMonth.Focus()
                Exit Sub
            End If
        End If

        '   End If


        If txtMonthTodate.Enabled = True Then
            If txtMonthTodate.Text <> "" And txtTBDMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtMonthTodate.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTBDMonth.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg109")
                    ''MessageBox.Show("Mechanical Breakdown Month To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                    txtMBDMonth.Focus()
                    Exit Sub
                End If
            End If

        End If


        If txtYearTodate.Enabled = True Then
            If txtYearTodate.Text <> "" And txtTBDYear.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtYearTodate.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTBDYear.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg1091")
                    ''MessageBox.Show("Mechanical Breakdown Month To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                    txtMBDMonth.Focus()
                    Exit Sub
                End If
            End If

        End If





        If txtMBDMonth.Enabled = True Then
            If txtMBDMonth.Text <> "" And txtMBToday.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtMBDMonth.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtMBToday.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg39")
                    ''MessageBox.Show("Mechanical Breakdown Month To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                    txtMBDMonth.Focus()
                    Exit Sub
                End If
            End If

        End If
        If txtMBDYear.Enabled = True Then
            If txtMBDYear.Text <> "" And txtMBDMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtMBDYear.Text
                strArr = str.Split(":")
                If txtMBToday.Text <> "" Then
                    Dim strTotal As String
                    Dim strArrTotal() As String
                    strTotal = txtMBToday.Text
                    strArrTotal = strTotal.Split(":")

                    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                        DisplayInfoMessage("Msg40")
                        ''MessageBox.Show(" Mechanical Breakdown Year To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                        txtMBDYear.Focus()
                        Exit Sub
                    End If
                End If

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtMBDMonth.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg41")
                    ''MessageBox.Show(" Mechanical Breakdown Year To Date Hrs cant be lesser than Mechanical Breakdown Month To Date Hrs")
                    txtMBDYear.Focus()
                    Exit Sub
                End If
            End If
        End If

        If txtEBDMonth.Enabled = True Then
            If txtEBDMonth.Text <> "" And txtEBDToday.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtEBDMonth.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtEBDToday.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg42")
                    ''MessageBox.Show("Electrical Breakdown Month To Date Hrs cant be lesser than Electrical Breakdown Today Hrs")
                    txtEBDMonth.Focus()
                    Exit Sub
                End If
            End If

        End If
        If txtEBDYear.Enabled = True Then
            If txtEBDYear.Text <> "" And txtEBDMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtEBDYear.Text
                strArr = str.Split(":")
                If txtEBDToday.Text <> "" Then
                    Dim strTotal As String
                    Dim strArrTotal() As String
                    strTotal = txtEBDToday.Text
                    strArrTotal = strTotal.Split(":")

                    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                        DisplayInfoMessage("Msg43")
                        ''MessageBox.Show(" Electrical BreakdownYear To Date Hrs cant be lesser than Electrical Breakdown Today Hrs")
                        txtEBDYear.Focus()
                        Exit Sub
                    End If
                End If

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtEBDMonth.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg44")
                    ''MessageBox.Show("Electrical Breakdown Year To Date Hrs cant be lesser than Electrical Breakdown Month To Date Hrs")
                    txtEBDYear.Focus()
                    Exit Sub
                End If
            End If
        End If

        If txtPBDMonth.Enabled = True Then
            If txtPBDMonth.Text <> "" And txtPBDToday.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtPBDMonth.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtPBDToday.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg45")
                    '' MessageBox.Show("Processing Breakdown Month To Date Hrs cant be lesser than Processing Breakdown Today Hrs")
                    txtPBDMonth.Focus()
                    Exit Sub
                End If
            End If

        End If
        If txtPBDYear.Enabled = True Then
            If txtPBDYear.Text <> "" And txtPBDMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtPBDYear.Text
                strArr = str.Split(":")
                If txtPBDToday.Text <> "" Then
                    Dim strTotal As String
                    Dim strArrTotal() As String
                    strTotal = txtPBDToday.Text
                    strArrTotal = strTotal.Split(":")

                    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                        DisplayInfoMessage("Msg46")
                        ''MessageBox.Show("Processing Breakdown Year To Date Hrs cant be lesser than Processing Breakdown Today Hrs")
                        txtPBDYear.Focus()
                        Exit Sub
                    End If
                End If

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtPBDMonth.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg47")
                    ''MessageBox.Show("Processing Breakdown Year To Date Hrs cant be lesser than Processing Breakdown Month To Date Hrs")
                    txtPBDYear.Focus()
                    Exit Sub
                End If
            End If
        End If

        If txtTPHTodaystage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg48")
                ''MessageBox.Show("Press Info Month To Date Hrs cant be lesser than Press Info Total Hrs")
                txtTPHMonthTodateStage1.Focus()
                txtTPHMonthTodateStage1.Enabled = True
                Exit Sub
            End If
        End If
        If txtTPHTodaystage1.Text <> "" And txtTPHYearTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtTPHMonthTodateStage1.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg49")
                ''MessageBox.Show(" Press Info Line 1 Year To Date Hrs cant be lesser than Press Info Line 1 Total Hrs")
                txtTPHYearTodateStage1.Focus()
                txtTPHYearTodateStage1.Enabled = True
                Exit Sub
            End If

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg50")
                ''MessageBox.Show(" Press Info Line 1 Year To Date Hrs cant be lesser than Press Info Line 1 Month To Date Hrs")
                txtTPHYearTodateStage1.Focus()
                txtTPHYearTodateStage1.Enabled = True
                Exit Sub
            End If
        End If

        If txtStage2TodayTPH.Text <> "" And txtStage2monthTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg51")
                ''MessageBox.Show(" Press Info Line 2 Month To Date Hrs cant be lesser than Press Info Line 2 Total Hrs")
                txtStage2monthTodate.Focus()
                txtStage2monthTodate.Enabled = True
                Exit Sub
            End If
        End If
        If txtStage2TodayTPH.Text <> "" And txtStage2yearTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtStage2monthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg52")
                ''MessageBox.Show(" Press Info Line 2 Year To Date Hrs cant be lesser than Press Info Line 2 Total Hrs")
                txtStage2yearTodate.Focus()
                txtStage2yearTodate.Enabled = True
                Exit Sub
            End If

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg53")
                ''MessageBox.Show(" Press Info Line 2 Year To Date Hrs cant be lesser than Press Info Line 2 Month To Date Hrs")
                txtStage2yearTodate.Focus()
                txtStage2yearTodate.Enabled = True
                Exit Sub
            End If
        End If
        'Sai Comment
        'If txtMonthTodate.Enabled = True Then
        '    Dim strArr() As String
        '    Dim str As String
        '    str = txtMonthTodate.Text
        '    strArr = str.Split(":")
        '    If CInt(strArr(0) >= 744) Then
        '        DisplayInfoMessage("Msg120")
        '        txtMonthTodate.Focus()
        '        Exit Sub
        '    End If
        '    str = txtYearTodate.Text
        '    strArr = str.Split(":")
        '    If CInt(strArr(0) >= 8760) Then
        '        DisplayInfoMessage("Msg121")
        '        txtYearTodate.Focus()
        '        Exit Sub
        '    End If
        'End If

       




        'If MsgBox(rm.GetString("Msg621"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If

        'If dgvCPOView.RowCount <> 0 Then
        '    If dgvCPOLogView.CurrentRow.Index <> 0 Then
        '        MsgBox("User can update only Last record")
        '        Exit Sub
        '    End If
        'End If

       

        If SaveFlag = True Then

            objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
            Dim ObjRecordExist As Object
            ObjRecordExist = CPOProductionLogBOL.DuplicateDateCheck(objCPOLogPPT)

            If ObjRecordExist = 0 Then
                DisplayInfoMessage("Msg54")
                ''MsgBox("Cannot Add Record(s)in Same Date!")
                Exit Sub
            End If


            Dim dsDetails As New DataSet

            lStartTime = txtStartTime.Text
            lStopTime = txtStopTime.Text

           
            With objCPOLogPPT
                objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value ' Format(dtpCPOLogDate.Value, "MM/dd/yyyy")
                objCPOLogPPT.CropYieldID = lCropYieldID


                If txtTotalHours.Text <> Nothing Then
                    objCPOLogPPT.TotalHours = txtTotalHours.Text
                End If
                If txtMonthTodate.Text <> String.Empty Then
                    objCPOLogPPT.MonthToDateHrs = txtMonthTodate.Text
                End If
                If txtYearTodate.Text <> String.Empty Then
                    objCPOLogPPT.YeartoDateHrs = txtYearTodate.Text
                End If
                If txtTodayFFB.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBBFQty = txtTodayFFB.Text
                End If
                If txtNoOfLorry.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBBFNoLorry = txtNoOfLorry.Text
                End If
                If txtFFBReceived.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceived = txtFFBReceived.Text
                End If
                If txtFFbNoOfLorry.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceivedLorry = txtFFbNoOfLorry.Text
                End If
                If txtFFBMonthToDate.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceivedMTD = txtFFBMonthToDate.Text
                End If
                If txtFFBYearToDate.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceivedYTD = txtFFBYearToDate.Text
                End If

                If txtProcessedFFBToday.Text <> String.Empty Then
                    objCPOLogPPT.FFBProcessedACT = txtProcessedFFBToday.Text
                End If
                If txtProcessedLorry.Text <> String.Empty Then
                    objCPOLogPPT.LorryProcessedACT = txtProcessedLorry.Text
                End If
                If txtUnProcessedFFB.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBCFQty = txtUnProcessedFFB.Text
                End If
                If txtUnProcessedLorry.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBCFNoLorry = txtUnProcessedLorry.Text
                End If
                If txtKernalProduction.Text <> String.Empty Then
                    objCPOLogPPT.KernelProduction = txtKernalProduction.Text
                End If
                If txtLossOnKernal.Text <> String.Empty Then
                    objCPOLogPPT.LossOfKernel = txtLossOnKernal.Text
                End If
                If txtLryWtToday.Text <> String.Empty Then
                    objCPOLogPPT.AvgLorryWeight = txtLryWtToday.Text
                End If
                If txtMBToday.Text <> String.Empty Then
                    objCPOLogPPT.MechanicalBD = txtMBToday.Text
                Else
                    objCPOLogPPT.MechanicalBD = "00:00"
                End If
                If txtEBDToday.Text <> String.Empty Then
                    objCPOLogPPT.ElectricalBD = txtEBDToday.Text
                Else
                    objCPOLogPPT.ElectricalBD = "00:00"
                End If
                If txtPBDToday.Text <> String.Empty Then
                    objCPOLogPPT.ProcessingBD = txtPBDToday.Text
                Else
                    objCPOLogPPT.ProcessingBD = "00:00"
                End If
                'If txtKlToday.Text <> String.Empty Then
                '    objCPOLogPPT.LossOfKernel = Math.Round(CDbl(Val(txtKlToday.Text)), 2)
                'End If
                If txtTBDToday.Text <> String.Empty Then
                    objCPOLogPPT.TotalBD = txtTBDToday.Text
                Else
                    objCPOLogPPT.TotalBD = "00:00"
                End If
                If txtEPHrsToday.Text <> String.Empty Then
                    objCPOLogPPT.EffectiveProcessingHours = txtEPHrsToday.Text
                End If
                If txtTpToday.Text <> String.Empty Then
                    objCPOLogPPT.Throughput = Math.Round(CDbl(Val(txtTpToday.Text)), 3)
                End If

                If txtOERToday.Text <> String.Empty Then
                    objCPOLogPPT.OER = Math.Round(CDbl(Val(txtOERToday.Text)), 2)
                End If

                If txtKERToday.Text <> String.Empty Then
                    objCPOLogPPT.KER = Math.Round(CDbl(Val(txtKERToday.Text)), 2)
                End If
                If txtLogRemarks.Text <> String.Empty Then
                    objCPOLogPPT.Remarks = txtLogRemarks.Text.Trim
                End If

                '' newly added on may 13
                If txtFFBMonth.Text <> String.Empty Then
                    objCPOLogPPT.FFBProcessedMTD = txtFFBMonth.Text
                End If

                If txtLryMonth.Text <> String.Empty Then
                    objCPOLogPPT.LorryProcessedMTD = txtLryMonth.Text
                End If

                If txtKlMonth.Text <> String.Empty Then
                    objCPOLogPPT.LossOfKernelMTD = txtKlMonth.Text
                End If
                If txtMBDMonth.Text <> String.Empty Then
                    objCPOLogPPT.MechanicalBDMTD = txtMBDMonth.Text
                End If
                If txtEBDMonth.Text <> String.Empty Then
                    objCPOLogPPT.ElectricalBDMTD = txtEBDMonth.Text
                End If
                If txtPBDMonth.Text <> String.Empty Then
                    objCPOLogPPT.ProcessingBDMTD = txtPBDMonth.Text
                End If

                If txtFFBYear.Text <> String.Empty Then
                    objCPOLogPPT.FFBProcessedYTD = txtFFBYear.Text
                End If

                If txtLryYear.Text <> String.Empty Then
                    objCPOLogPPT.LorryProcessedYTD = txtLryYear.Text
                End If

                If txtKlYear.Text <> String.Empty Then
                    objCPOLogPPT.LossOfKernelYTD = txtKlYear.Text
                End If
                If txtMBDYear.Text <> String.Empty Then
                    objCPOLogPPT.MechanicalBDYTD = txtMBDYear.Text
                End If
                If txtEBDYear.Text <> String.Empty Then
                    objCPOLogPPT.ElectricalBDYTD = txtEBDYear.Text
                End If
                If txtPBDYear.Text <> String.Empty Then
                    objCPOLogPPT.ProcessingBDYTD = txtPBDYear.Text
                End If

                ds = CPOProductionLogBOL.saveCPOLogProduction(objCPOLogPPT)
                If ds.Tables(0).Rows.Count <> 0 And ds IsNot Nothing Then
                    lCPOProductionLogID = ds.Tables(0).Rows(0).Item("CPOProductionLogID").ToString
                End If
                ' CPOProductionLogBOL.UpdateTankMasterBFQty(objCPOLogPPT)
            End With
            'Next
            'CPOGridViewBind()

            ''For Storing Shift Details 

            Dim dsLogDetails As New DataSet
            For Each DataGridViewRow In dgvCPOLogDetails.Rows
                With objCPOLogPPT
                    If DataGridViewRow.Cells("Shift").Value = 1 Then
                        .CPOProductionLogID = ds.Tables(0).Rows(0).Item("CPOProductionLogID")
                        .Shift1 = DataGridViewRow.Cells("Shift").Value.ToString()
                        .AssistantEmpID1 = DataGridViewRow.Cells("Assistant").Value.ToString()
                        .MandoreEmpID1 = DataGridViewRow.Cells("Mandore").Value.ToString()
                        .StartTime1 = DataGridViewRow.Cells("Start_Time").Value.ToString()
                        .StopTime1 = DataGridViewRow.Cells("Stop_Time").Value.ToString()
                        .TotalBreakdown1 = DataGridViewRow.Cells("TotalBreakdown").Value.ToString()
                        .FFBProcessedEST1 = DataGridViewRow.Cells("FFB_Processed").Value.ToString()
                        .LorryProcessedEST1 = DataGridViewRow.Cells("Lorry_Processed").Value.ToString()
                    End If
                    If DataGridViewRow.Cells("Shift").Value = 2 Then

                        .Shift3 = ""
                        .AssistantEmpID3 = ""
                        .MandoreEmpID3 = ""
                        '.StartTime3 = ""
                        '.StopTime3 = ""
                        .FFBProcessedEST3 = 0.0
                        .LorryProcessedEST3 = 0

                        .CPOProductionLogID = ds.Tables(0).Rows(0).Item("CPOProductionLogID")
                        .Shift2 = DataGridViewRow.Cells("Shift").Value.ToString()
                        .AssistantEmpID2 = DataGridViewRow.Cells("Assistant").Value.ToString()
                        .MandoreEmpID2 = DataGridViewRow.Cells("Mandore").Value.ToString()
                        .StartTime2 = DataGridViewRow.Cells("Start_Time").Value.ToString()
                        .StopTime2 = DataGridViewRow.Cells("Stop_Time").Value.ToString()
                        .TotalBreakdown2 = DataGridViewRow.Cells("TotalBreakdown").Value.ToString()
                        .FFBProcessedEST2 = DataGridViewRow.Cells("FFB_Processed").Value.ToString()
                        .LorryProcessedEST2 = DataGridViewRow.Cells("Lorry_Processed").Value.ToString()
                    End If
                    If DataGridViewRow.Cells("Shift").Value = 3 Then
                        .CPOProductionLogID = ds.Tables(0).Rows(0).Item("CPOProductionLogID")
                        .Shift3 = DataGridViewRow.Cells("Shift").Value.ToString()
                        .AssistantEmpID3 = DataGridViewRow.Cells("Assistant").Value.ToString()
                        .MandoreEmpID3 = DataGridViewRow.Cells("Mandore").Value.ToString()
                        .StartTime3 = DataGridViewRow.Cells("Start_Time").Value.ToString()
                        .StopTime3 = DataGridViewRow.Cells("Stop_Time").Value.ToString()
                        .TotalBreakdown3 = DataGridViewRow.Cells("TotalBreakdown").Value.ToString()
                        .FFBProcessedEST3 = DataGridViewRow.Cells("FFB_Processed").Value.ToString()
                        .LorryProcessedEST3 = DataGridViewRow.Cells("Lorry_Processed").Value.ToString()
                    End If

                End With

                dsLogDetails = CPOProductionLogBOL.saveCPOLogShift(objCPOLogPPT)


            Next
            ''For Press Tab Saved ''''''''''''''''

            If dgPressInfo.RowCount <> 0 And lCPOProductionLogID <> String.Empty Then

                For Each DataGridViewRow In dgPressInfo.Rows
                    Dim ObjPKOProductionLogPPTMe As New CPOProductionLogPPT
                    Dim ObjPKOProductionLogBOLMe As New CPOProductionLogBOL
                    With ObjPKOProductionLogPPTMe
                        .CPOProductionLogID = lCPOProductionLogID
                        .StagePress = DataGridViewRow.Cells("dgmeStage").Value.ToString()
                        If DataGridViewRow.Cells("dgMeScrewAge").Value.ToString() <> "" Then
                            Dim lstr As String
                            lstr = DataGridViewRow.Cells("dgMeScrewAge").Value.ToString()
                            .ScrewAge = lstr.Replace(":", ".")
                        End If
                        '.ScrewAge = IIf(DataGridViewRow.Cells("dgMeScrewAge").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMescrewAge").Value.ToString())
                        .MachineID = DataGridViewRow.Cells("dgMeMachineID").Value.ToString()
                        .MeterFrom = IIf(DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString())
                        .MeterTo = IIf(DataGridViewRow.Cells("dgMeMeterTo").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterTo").Value.ToString())
                        .OPHrs = DataGridViewRow.Cells("dgmeOPHrs").Value.ToString()
                        .ScrewStatus = DataGridViewRow.Cells("dgmeScrewStatus").Value.ToString()
                        .PCage = ""
                    End With
                    Dim dsKer As DataSet
                    dsKer = CPOProductionLogBOL.SaveProductionCPOLogPress(ObjPKOProductionLogPPTMe)
                Next

            End If

            Dim ObjCPOProductionLogPPTMe2 As New CPOProductionLogPPT
            Dim ObjCPOProductionLogBOLMe2 As New CPOProductionLogBOL
            With ObjCPOProductionLogPPTMe2
                .CPOProductionLogID = lCPOProductionLogID
                .StagePress = "Line 1"
                If txtTPHTodaystage1.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtTPHTodaystage1.Text.Trim
                End If

                If txtTPHMonthTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtTPHMonthTodateStage1.Text
                End If

                If txtTPHYearTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtTPHYearTodateStage1.Text
                End If

                .AvgPressThrToday = Val(txtAPTstage1today.Text)
                .AvgPressThrMTD = Val(txtAPHstage1monthtodate.Text)
                .AvgPressThrYTD = Val(txtAPTstage1yeartodate.Text)
                .UtilizationToday = Val(txtutilstage1today.Text)
                .UtilizationMTD = Val(txtutilstage1monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage1yeartodate.Text)
            End With
            Dim dsKerSumm As DataSet
            dsKerSumm = CPOProductionLogBOL.SaveCPOProductionPressSummary(ObjCPOProductionLogPPTMe2)


            Dim ObjCPOProductionLogPPTMe1 As New CPOProductionLogPPT
            Dim ObjCPOProductionLogBOLMe1 As New CPOProductionLogBOL
            With ObjCPOProductionLogPPTMe1
                .CPOProductionLogID = lCPOProductionLogID
                .StagePress = "Line 2"
                If txtStage2TodayTPH.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtStage2TodayTPH.Text.Trim
                End If

                If txtStage2monthTodate.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtStage2monthTodate.Text
                End If

                If txtStage2yearTodate.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtStage2yearTodate.Text
                End If


                .AvgPressThrToday = Val(txtAPTstage2today.Text)
                .AvgPressThrMTD = Val(txtAPTstage2monthtodae.Text)
                .AvgPressThrYTD = Val(txtAPTStage2yeartodate.Text)
                .UtilizationToday = Val(txtutilstage2.Text)
                .UtilizationMTD = Val(txtutilstage2monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage2yeartodate.Text)
            End With
            Dim dsKerSumm1 As DataSet
            dsKerSumm1 = CPOProductionLogBOL.SaveCPOProductionPressSummary(ObjCPOProductionLogPPTMe1)


            DisplayInfoMessage("Msg55")
            '' MsgBox("Data Successfully Saved")
            Clear()
            CPOLogFFBLorryProcessed()
            ClearGridView(dgPressInfo)
            CPOLogGridViewBind()
            'SaveFlag = False

        Else
            ' Dim StrCPODate As String
            Dim dsDetails As New DataSet
            'lHrs = cmbCPOLogStartHrs.Text
            'lmin = cmbCPOLogStartMin.Text
            '' lAMPM = cmbCPOLogStartAMPM.Text

            lStartTime = txtStartTime.Text

            'lHrs = cmbCPOLogStopHrs.Text
            'lmin = cmbCPOLogStopMin.Text
            '' lAMPM = cmbCPOLogStopAMPM.Text
            lStopTime = txtStopTime.Text
            lTotalBreakdown = txtTotalBrkdown.Text

            With objCPOLogPPT

                objCPOLogPPT.CPOProductionLogID = lCPOProductionLogID 'Me.dgvCPOLogView.Rows(0).Cells("dgclCPOProductionLogID").Value.ToString()
                objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value 'Format(dtpCPOLogDate.Value, "MM/dd/yyyy")
                objCPOLogPPT.CropYieldID = lCropYieldID

                If txtTotalHours.Text <> String.Empty Then
                    objCPOLogPPT.TotalHours = txtTotalHours.Text
                End If
                If txtMonthTodate.Text <> String.Empty Then
                    objCPOLogPPT.MonthToDateHrs = txtMonthTodate.Text
                End If
                If txtYearTodate.Text <> String.Empty Then
                    objCPOLogPPT.YeartoDateHrs = txtYearTodate.Text
                End If
                If txtTodayFFB.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBBFQty = txtTodayFFB.Text
                End If
                If txtNoOfLorry.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBBFNoLorry = txtNoOfLorry.Text
                End If
                If txtFFBReceived.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceived = txtFFBReceived.Text
                End If
                If txtFFbNoOfLorry.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceivedLorry = txtFFbNoOfLorry.Text
                End If
                If txtFFBMonthToDate.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceivedMTD = txtFFBMonthToDate.Text
                End If
                If txtFFBYearToDate.Text <> String.Empty Then
                    objCPOLogPPT.FFBReceivedYTD = txtFFBYearToDate.Text
                End If
                If txtProcessedFFBToday.Text <> String.Empty Then
                    objCPOLogPPT.FFBProcessedACT = txtProcessedFFBToday.Text
                End If
                If txtProcessedLorry.Text <> String.Empty Then
                    objCPOLogPPT.LorryProcessedACT = txtProcessedLorry.Text
                End If
                If txtUnProcessedFFB.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBCFQty = txtUnProcessedFFB.Text
                End If
                If txtUnProcessedLorry.Text <> String.Empty Then
                    objCPOLogPPT.BalanceFFBCFNoLorry = txtUnProcessedLorry.Text
                End If
                If txtKernalProduction.Text <> String.Empty Then
                    objCPOLogPPT.KernelProduction = txtKernalProduction.Text
                End If
                If txtLossOnKernal.Text <> String.Empty Then
                    objCPOLogPPT.LossOfKernel = txtLossOnKernal.Text
                    'objCPOLogPPT.LossOfKernel
                End If
                If txtLryWtToday.Text <> String.Empty Then
                    objCPOLogPPT.AvgLorryWeight = txtLryWtToday.Text
                End If
                If txtMBToday.Text <> String.Empty Then
                    objCPOLogPPT.MechanicalBD = txtMBToday.Text
                End If
                'If txtKlToday.Text <> String.Empty Then
                '    objCPOLogPPT.LossOfKernel = Math.Round(CDbl(Val(txtKlToday.Text)), 3)
                'End If
                If txtEBDToday.Text <> String.Empty Then
                    objCPOLogPPT.ElectricalBD = txtEBDToday.Text
                End If
                If txtPBDToday.Text <> String.Empty Then
                    objCPOLogPPT.ProcessingBD = txtPBDToday.Text
                End If
                If txtTBDToday.Text <> String.Empty Then
                    objCPOLogPPT.TotalBD = txtTBDToday.Text
                End If
                If txtEPHrsToday.Text <> String.Empty Then
                    objCPOLogPPT.EffectiveProcessingHours = txtEPHrsToday.Text
                End If
                If txtTpToday.Text <> String.Empty Then
                    objCPOLogPPT.Throughput = Math.Round(CDbl(Val(txtTpToday.Text)), 3)
                End If

                If txtOERToday.Text <> String.Empty Then
                    objCPOLogPPT.OER = Math.Round(CDbl(Val(txtOERToday.Text)), 2)
                End If
                If txtKERToday.Text <> String.Empty Then
                    objCPOLogPPT.KER = Math.Round(CDbl(Val(txtKERToday.Text)), 2)
                End If
                If txtLogRemarks.Text <> String.Empty Then
                    objCPOLogPPT.Remarks = txtLogRemarks.Text.Trim
                End If

                '' newly added on may 13
                If txtFFBMonth.Text <> String.Empty Then
                    objCPOLogPPT.FFBProcessedMTD = txtFFBMonth.Text
                End If

                If txtLryMonth.Text <> String.Empty Then
                    objCPOLogPPT.LorryProcessedMTD = txtLryMonth.Text
                End If

                If txtKlMonth.Text <> String.Empty Then
                    objCPOLogPPT.LossOfKernelMTD = txtKlMonth.Text
                End If
                If txtMBDMonth.Text <> String.Empty Then
                    objCPOLogPPT.MechanicalBDMTD = txtMBDMonth.Text
                End If
                If txtEBDMonth.Text <> String.Empty Then
                    objCPOLogPPT.ElectricalBDMTD = txtEBDMonth.Text
                End If
                If txtPBDMonth.Text <> String.Empty Then
                    objCPOLogPPT.ProcessingBDMTD = txtPBDMonth.Text
                End If

                If txtFFBYear.Text <> String.Empty Then
                    objCPOLogPPT.FFBProcessedYTD = txtFFBYear.Text
                End If

                If txtLryYear.Text <> String.Empty Then
                    objCPOLogPPT.LorryProcessedYTD = txtLryYear.Text
                End If

                If txtKlYear.Text <> String.Empty Then
                    objCPOLogPPT.LossOfKernelYTD = txtKlYear.Text
                End If
                If txtMBDYear.Text <> String.Empty Then
                    objCPOLogPPT.MechanicalBDYTD = txtMBDYear.Text
                End If
                If txtEBDYear.Text <> String.Empty Then
                    objCPOLogPPT.ElectricalBDYTD = txtEBDYear.Text
                End If
                If txtPBDYear.Text <> String.Empty Then
                    objCPOLogPPT.ProcessingBDYTD = txtPBDYear.Text
                End If

                CPOProductionLogBOL.UpdateCPOProductionLog(objCPOLogPPT)
                ' CPOProductionLogBOL.UpdateTankMasterBFQty(objCPOLogPPT)
            End With
            'Next

            Dim dsLogDetails As New DataSet
            For Each DataGridViewRow In dgvCPOLogDetails.Rows
                With objCPOLogPPT
                    If DataGridViewRow.Cells("Shift").Value = 1 Then


                        .CPOProductionLogID = lCPOProductionLogID ''DataGridViewRow.Cells("CPOProductionLogID").Value.ToString() 'ds.Tables(0).Rows(0).Item("CPOProductionLogID")
                        .Shift1 = DataGridViewRow.Cells("Shift").Value.ToString()
                        .AssistantEmpID1 = DataGridViewRow.Cells("Assistant").Value.ToString()
                        .MandoreEmpID1 = DataGridViewRow.Cells("Mandore").Value.ToString()
                        .StartTime1 = DataGridViewRow.Cells("Start_Time").Value.ToString()
                        .StopTime1 = DataGridViewRow.Cells("Stop_Time").Value.ToString()
                        .TotalBreakdown1 = DataGridViewRow.Cells("TotalBreakdown").Value.ToString()
                        .FFBProcessedEST1 = DataGridViewRow.Cells("FFB_Processed").Value.ToString()
                        .LorryProcessedEST1 = DataGridViewRow.Cells("Lorry_Processed").Value.ToString()
                    End If
                    If DataGridViewRow.Cells("Shift").Value = 2 Then


                        .Shift3 = ""
                        .AssistantEmpID3 = ""
                        .MandoreEmpID3 = ""
                        '.StartTime3 = ""
                        '.StopTime3 = ""
                        .FFBProcessedEST3 = 0.0
                        .LorryProcessedEST3 = 0

                        .CPOProductionLogID = lCPOProductionLogID ''DataGridViewRow.Cells("CPOProductionLogID").Value.ToString() 'ds.Tables(0).Rows(0).Item("CPOProductionLogID")
                        .Shift2 = DataGridViewRow.Cells("Shift").Value.ToString()
                        .AssistantEmpID2 = DataGridViewRow.Cells("Assistant").Value.ToString()
                        .MandoreEmpID2 = DataGridViewRow.Cells("Mandore").Value.ToString()
                        .StartTime2 = DataGridViewRow.Cells("Start_Time").Value.ToString()
                        .StopTime2 = DataGridViewRow.Cells("Stop_Time").Value.ToString()
                        .TotalBreakdown2 = DataGridViewRow.Cells("TotalBreakdown").Value.ToString()
                        .FFBProcessedEST2 = DataGridViewRow.Cells("FFB_Processed").Value.ToString()
                        .LorryProcessedEST2 = DataGridViewRow.Cells("Lorry_Processed").Value.ToString()
                    End If
                    If DataGridViewRow.Cells("Shift").Value = 3 Then


                        .CPOProductionLogID = lCPOProductionLogID ''DataGridViewRow.Cells("CPOProductionLogID").Value.ToString() 'ds.Tables(0).Rows(0).Item("CPOProductionLogID")
                        .Shift3 = DataGridViewRow.Cells("Shift").Value.ToString()
                        .AssistantEmpID3 = DataGridViewRow.Cells("Assistant").Value.ToString()
                        .MandoreEmpID3 = DataGridViewRow.Cells("Mandore").Value.ToString()
                        .StartTime3 = DataGridViewRow.Cells("Start_Time").Value.ToString()
                        .StopTime3 = DataGridViewRow.Cells("Stop_Time").Value.ToString()
                        .TotalBreakdown3 = DataGridViewRow.Cells("TotalBreakdown").Value.ToString()
                        .FFBProcessedEST3 = DataGridViewRow.Cells("FFB_Processed").Value.ToString()
                        .LorryProcessedEST3 = DataGridViewRow.Cells("Lorry_Processed").Value.ToString()
                    End If

                End With

                If lCPOProductionLogID <> String.Empty Then 'DataGridViewRow.Cells("CPOProductionLogID").Value.ToString() <> String.Empty Then
                    dsDetails = CPOProductionLogBOL.UpdateCPOLogShift(objCPOLogPPT)
                Else
                    dsDetails = CPOProductionLogBOL.saveCPOLogShift(objCPOLogPPT)
                End If
            Next

            ''''For PressInfo Update'''''''''''''


            If dgPressInfo.RowCount <> 0 And lCPOProductionLogID <> String.Empty Then

                For Each DataGridViewRow In dgPressInfo.Rows
                    Dim ObjCPOProductionLogPPTMe As New CPOProductionLogPPT
                    Dim ObjCPOProductionLogBOLMe As New CPOProductionLogBOL
                    With ObjCPOProductionLogPPTMe
                        If DataGridViewRow.Cells("dgMeProductionLogPressID").Value IsNot Nothing Then
                            .ProductionLogPressID = DataGridViewRow.Cells("dgMeProductionLogPressID").Value.ToString()
                        Else
                            .ProductionLogPressID = Nothing
                        End If

                        .CPOProductionLogID = lCPOProductionLogID
                        .StagePress = DataGridViewRow.Cells("dgmeStage").Value.ToString()
                        If DataGridViewRow.Cells("dgMeScrewAge").Value.ToString() <> "" Then
                            Dim lstr As String
                            lstr = DataGridViewRow.Cells("dgMeScrewAge").Value.ToString()
                            .ScrewAge = lstr.Replace(":", ".")
                        End If
                        .MachineID = DataGridViewRow.Cells("dgMeMachineID").Value.ToString()
                        .MeterFrom = IIf(DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString())
                        .MeterTo = IIf(DataGridViewRow.Cells("dgMeMeterTo").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterTo").Value.ToString())
                        .OPHrs = DataGridViewRow.Cells("dgmeOPHrs").Value.ToString()
                        .ScrewStatus = DataGridViewRow.Cells("dgmeScrewStatus").Value.ToString()
                        .PCage = ""
                    End With
                    Dim dsKer As DataSet
                    If ObjCPOProductionLogPPTMe.ProductionLogPressID <> String.Empty Then
                        dsKer = ObjCPOProductionLogBOLMe.UpdateProductionCPOLogPress(ObjCPOProductionLogPPTMe)
                    Else
                        dsKer = CPOProductionLogBOL.SaveProductionCPOLogPress(ObjCPOProductionLogPPTMe)
                    End If

                Next

            End If
            Dim ObjCPOProductionLogPPTMe2 As New CPOProductionLogPPT
            Dim ObjCPOProductionLogBOLMe2 As New CPOProductionLogBOL
            With ObjCPOProductionLogPPTMe2
                .CPOProductionLogID = lCPOProductionLogID
                .StagePress = "Line 1"
                If txtTPHTodaystage1.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtTPHTodaystage1.Text.Trim
                End If

                If txtTPHMonthTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtTPHMonthTodateStage1.Text
                End If

                If txtTPHYearTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtTPHYearTodateStage1.Text
                End If

                .AvgPressThrToday = Val(txtAPTstage1today.Text)
                .AvgPressThrMTD = Val(txtAPHstage1monthtodate.Text)
                .AvgPressThrYTD = Val(txtAPTstage1yeartodate.Text)
                .UtilizationToday = Val(txtutilstage1today.Text)
                .UtilizationMTD = Val(txtutilstage1monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage1yeartodate.Text)
                .PressSummaryID = stage1PressSummaryID

            End With
            Dim dsKerSumm As DataSet
            If ObjCPOProductionLogPPTMe2.PressSummaryID = "" Then
                dsKerSumm = CPOProductionLogBOL.SaveCPOProductionPressSummary(ObjCPOProductionLogPPTMe2)
            Else
                dsKerSumm = ObjCPOProductionLogBOLMe2.UpdateCPOProductionPressSummary(ObjCPOProductionLogPPTMe2)
            End If


            Dim ObjCPOProductionLogPPTMe1 As New CPOProductionLogPPT
            Dim ObjCPOProductionLogBOLMe1 As New CPOProductionLogBOL
            With ObjCPOProductionLogPPTMe1
                .CPOProductionLogID = lCPOProductionLogID
                .StagePress = "Line 2"
                If txtStage2TodayTPH.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtStage2TodayTPH.Text.Trim
                End If

                If txtStage2monthTodate.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtStage2monthTodate.Text
                End If

                If txtStage2yearTodate.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtStage2yearTodate.Text
                End If


                .AvgPressThrToday = Val(txtAPTstage2today.Text)
                .AvgPressThrMTD = Val(txtAPTstage2monthtodae.Text)
                .AvgPressThrYTD = Val(txtAPTStage2yeartodate.Text)
                .UtilizationToday = Val(txtutilstage2.Text)
                .UtilizationMTD = Val(txtutilstage2monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage2yeartodate.Text)
                .PressSummaryID = stage2PressSummaryID

            End With
            Dim dsKerSumm1 As DataSet
            If ObjCPOProductionLogPPTMe1.PressSummaryID = "" Then
                dsKerSumm1 = CPOProductionLogBOL.SaveCPOProductionPressSummary(ObjCPOProductionLogPPTMe1)
            Else
                dsKerSumm1 = ObjCPOProductionLogBOLMe1.UpdateCPOProductionPressSummary(ObjCPOProductionLogPPTMe1)
            End If
            DeleteMultiEntryRecordsPressInfo()

            CPOLogGridViewBind()
            DisplayInfoMessage("Msg56")
            ''MsgBox("Data Successfully Updated")
            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Save All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Simpan Semua"
            End If

            ''btnSave.Text = "Save All"
            Clear()
            ClearGridView(dgPressInfo)
            CPOLogFFBLorryProcessed()
            SaveFlag = True
        End If
        dataTFlag = True
        GlobalPPT.IsRetainFocus = False

        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    'Private Sub DatePicker() 
    '    ''''''''''''''''''''For Date Restriction ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    'edit 120912 by suraya
    '    'dtpCPOLogDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
    '    'Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date


    '    'dtpCPOLogViewDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
    '    ' Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date

    '    'If dgvCPOView.RowCount <> 0 Then
    '    '    Dim ProdDate As Date
    '    '    ProdDate = dgvCPOLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString()
    '    '    dtpCPOLogDate.MinDate = DateAdd(DateInterval.Day, 1, ProdDate)
    '    'Else
    '    'dtpCPOLogDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
    '    'End If

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'End Sub

    Private Sub Clear()
        'Common_BOL.GlobalBOL.SetDateTimePicker(Me.dtpCPOLogDate)
        'FormatDateTimePicker(dtpCPOLogDate)
        cboShift.Text = "--End Select Shift--"

        lPrevFFBReceived = 0
        lPrevFFB = 0
        lPrevKl = 0
        lPrevlry = 0
        lPrevMBD = "00:00"
        lPrevEBD = "00:00"
        lPrevPBD = "00:00"
        dtpCPOLogDate.Enabled = True
        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSave.Text = "Simpan Semua"
        End If
        btnSave.Enabled = True
        btnDeleteAll.Enabled = True
        ''btnSave.Text = "Save All"
        tcCPOLog.SelectedTab = tbProduction
        StartDatefunction()
        StopDatefunction()
        txtAssistant.Text = ""
        txtMandor.Text = ""
        txtTotalHours.Text = ""
        txtFFBProcessed.Text = ""
        txtLorryProcessed.Text = ""
        txtMonthTodate.Text = ""
        txtYearTodate.Text = ""
        'txtTodayFFB.Text = ""
        'txtNoOfLorry.Text = ""
        'txtFFBReceived.Text = ""
        txtBudget.Text = ""
        txtFFbNoOfLorry.Text = ""
        txtFFBMonthToDate.Text = ""
        txtFFBYearToDate.Text = ""
        txtKlToday.Text = ""
        txtFFBVariance.Text = ""
        txtProcessedFFBToday.Text = ""
        txtProcessedLorry.Text = ""
        txtUnProcessedFFB.Text = ""
        txtUnProcessedLorry.Text = ""
        txtTotalShiftFFBProcessed.Text = ""
        txtTotalShiftLorryProcessed.Text = ""
        txtKernalProduction.Text = ""
        txtLryToday.Text = ""
        txtLossOnKernal.Text = ""
        txtMBToday.Text = ""
        txtEBDToday.Text = ""
        txtPBDToday.Text = ""
        txtTBDToday.Text = ""
        txtLossOnKernal.Text = ""
        txtEPHrsToday.Text = ""
        txtTpToday.Text = ""
        txtAvgTpToday.Text = ""
        txtOERToday.Text = ""
        txtKERToday.Text = ""
        ''monthtodate fields
        txtFFBMonth.Text = ""
        txtLryMonth.Text = ""
        txtLryWtMonth.Text = ""
        txtKlMonth.Text = ""
        txtMBDMonth.Text = ""
        txtEBDMonth.Text = ""
        txtPBDMonth.Text = ""
        txtTBDMonth.Text = ""
        txtEPHrsMonth.Text = ""
        txtTpMonth.Text = ""
        txtAvgTpMonth.Text = ""
        txtOERMonth.Text = ""
        txtKERMonth.Text = ""

        ''yeartodate fields
        txtFFBYear.Text = ""
        txtLryYear.Text = ""
        txtLryWtYear.Text = ""
        txtKlYear.Text = ""
        txtMBDYear.Text = ""
        txtEBDYear.Text = ""
        txtPBDYear.Text = ""
        txtTBDYear.Text = ""
        txtEPHrsYear.Text = ""
        txtTpYear.Text = ""
        txtAvgTpYear.Text = ""
        txtOERYear.Text = ""
        txtKERYear.Text = ""


        DeleteMultientryPressInfo.Clear()


        'chkShift1.Checked = False
        'chkShift2.Checked = False
        'chkShift3.Checked = False
        chkCPOLogDate.Checked = False
        dtpCPOLogViewDate.Enabled = False

        txtTotalHoursPress.Text = ""
        txtAvgPressThroughput.Text = ""
        txtCakeProcess.Text = ""
        txtTPHTodaystage1.Text = String.Empty
        txtStage2TodayTPH.Text = String.Empty
        txtAPTstage1today.Text = String.Empty
        txtAPTstage2today.Text = String.Empty
        txtutilstage1today.Text = String.Empty
        txtutilstage2.Text = String.Empty

        ''Month

        txtTPHMonthTodateStage1.Text = String.Empty
        txtStage2monthTodate.Text = String.Empty
        txtAPHstage1monthtodate.Text = String.Empty
        txtAPTstage2monthtodae.Text = String.Empty
        txtutilstage1monthtodate.Text = String.Empty
        txtutilstage2monthtodate.Text = String.Empty

        ''year

        txtTPHYearTodateStage1.Text = String.Empty
        txtStage2yearTodate.Text = String.Empty
        txtAPTstage1yeartodate.Text = String.Empty
        txtAPTStage2yeartodate.Text = String.Empty
        txtutilstage1yeartodate.Text = String.Empty
        txtutilstage2yeartodate.Text = String.Empty

        txtBudget.Text = 0.0
        ' txtFFBMonthToDate.Text = 0.0
        txtFFBVariance.Text = 0.0
        ClearGridView(dgvCPOLogDetails)
        txtLogRemarks.Text = ""

        SaveFlag = True

        ' DatePicker()

        'edit by suraya 12-09-12
        'Dim ToDate As Date = Date.Today
        'dtpCPOLogDate.Value = Date.Today
        'dtpCPOLogViewDate.Value = Date.Today
        'dtpCPOLogDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpCPOLogDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpCPOLogViewDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        'dtpCPOLogViewDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)


        dtpCPOLogDate.Format = DateTimePickerFormat.Custom 'edit
        dtpCPOLogDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpCPOLogDate)

        dtpCPOLogViewDate.Format = DateTimePickerFormat.Custom
        dtpCPOLogViewDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpCPOLogViewDate)

        '''''''''''''''''''''For Date Restriction ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'dtpCPOLogDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        'Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        'dtpCPOLogDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'If dgvCPOLogView.Rows.Count > 0 Then
        '    txtNoOfLorry.Enabled = False
        '    txtTodayFFB.Enabled = true
        'Else
        '    txtNoOfLorry.Enabled = True
        '    txtTodayFFB.Enabled = True
        'End If
        CPOGetMonthYearQty()
        BalanceBF()
        GetTPHMonth()
        GetTPHYear()
        GetPKOProductionLogPressOPHrsValue()
        CPOGetFFBNetWeight()
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Clear()
        ClearGridView(dgPressInfo)
        ClearLogExpress()
        ClearShift()
        StartDatefunction()
        StopDatefunction()
        GlobalPPT.IsRetainFocus = False

    End Sub
   
    Private Sub txtPBDToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBDToday.Leave

        If txtPBDToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtPBDToday.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then

                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtPBDToday.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If Hrs > 24 Then
                DisplayInfoMessage("Msg58")
                ''MessageBox.Show("Breakdown Hrs cant be greater than  24")
                txtPBDToday.Focus()
                Exit Sub
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg59")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtPBDToday.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtPBDToday.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtPBDToday.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtPBDToday.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtPBDToday.Text = Hrs + ":" + Min
        End If
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"


        If txtMBToday.Text <> "" Then
            lMechaniclBD = txtMBToday.Text
        End If
        If txtEBDToday.Text <> "" Then
            lelectriclBD = txtEBDToday.Text
        End If
        If txtPBDToday.Text <> "" Then
            lProcessBK = txtPBDToday.Text
        End If
        lBDCalculation = ToaddHours(lelectriclBD, lMechaniclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lProcessBK)

        If lBDCalculation <> "" Then
            Dim str As String
            Dim strArr() As String
            str = lBDCalculation
            strArr = str.Split(":")

            If strArr(0) > 24 Then
                DisplayInfoMessage("Msg63")
                ''MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
                txtPBDToday.Focus()
                Exit Sub
            End If
        End If

        ' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        If (txtMBToday.Text <> "" Or txtEBDToday.Text <> "" Or txtPBDToday.Text <> "") Then
            txtTBDToday.Text = lBDCalculation
        Else
            txtTBDToday.Text = ""
        End If

        If txtTBDToday.Text <> "" Then

            Dim HrsB As String = "00"
            Dim MinB As String = "00"
            Dim strB As String
            Dim strArrB() As String
            'Dim count As Integer
            strB = txtTBDToday.Text
            strArrB = strB.Split(":")

            If strArrB(0).Length = 1 Then
                HrsB = "0" + strArrB(0)
            ElseIf strArrB(0) <> "" Then
                HrsB = strArrB(0)
            End If
            MinB = strArrB(1)
            txtTBDToday.Text = HrsB + ":" + MinB
        End If
        If txtTBDToday.Text <> String.Empty And txtTBDToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))

            lmin = CInt(strArr2(1)) - CInt(strArr1(1))
            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg64")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtPBDToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg64")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtPBDToday.Focus()
                Exit Sub
            End If

            If txtTBDToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))

                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))
                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If

                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then
            txtEPHrsToday.Text = txtTotalHours.Text
        Else
            txtEPHrsToday.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsToday.Text <> "" And txtEPHrsToday.Text <> "00:00" And Len(txtEPHrsToday.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtTotalHours.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If
        If txtPBDMonth.Enabled = False Then
            If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then
                'txtPBDMonth.Text = ToSubHours(ToaddHours(lPBDMonth, txtPBDToday.Text), lPrevPBD)
                'txtPBDYear.Text = ToSubHours(ToaddHours(lPBDYear, txtPBDToday.Text), lPrevPBD)
                txtPBDMonth.Text = ToaddHours(lPBDMonth, txtPBDToday.Text)
                txtPBDYear.Text = ToaddHours(lPBDYear, txtPBDToday.Text)
            Else
                txtPBDMonth.Text = lPBDMonth
                txtPBDYear.Text = lPBDYear
            End If
        End If

        If SaveFlag = False And txtPBDToday.Text = "" And lPrevPBD = lPBDMonth Then
            txtPBDMonth.Text = ""
        End If

        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpToday.Text = Math.Round((Val(txtProcessedFFBToday.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpToday.Text = ""
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpToday.Text = Math.Round(Val(txtProcessedFFBToday.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpToday.Text = ""
        End If


    End Sub
    Private Sub CPOGetTodayQtyForOERKernel()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdOERKernel As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        dsProdOERKernel = CPOProductionLogBOL.CPOGetTodayQtyForOERKernel(objCPOLogPPT)

        If dsProdOERKernel.Tables(0).Rows.Count <> 0 Then
            If Not dsProdOERKernel.Tables(0).Rows(0).Item("Today") Is DBNull.Value Then
                Me.txtKERToday.Text = dsProdOERKernel.Tables(0).Rows(0).Item("Today")
            Else
                Me.txtKERToday.Text = "0"
            End If
        Else
            Me.txtKERToday.Text = "0"
        End If



    End Sub
    Private Sub CPOGetTodayQtyForOERCPO()

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdOERCPO As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        objCPOLogPPT.CropYieldID = lCropYieldID
        dsProdOERCPO = CPOProductionLogBOL.CPOGetTodayQtyForOERCPO(objCPOLogPPT)
        If dsProdOERCPO.Tables(0).Rows.Count <> 0 Then
            If Not dsProdOERCPO.Tables(0).Rows(0).Item("Today") Is DBNull.Value Then
                lOERCPOQty = dsProdOERCPO.Tables(0).Rows(0).Item("Today")
            End If
        End If



    End Sub


    Private Sub txtMBToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMBToday.Leave


        If txtMBToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMBToday.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg65")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMBToday.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If Hrs > 24 Then
                DisplayInfoMessage("Msg66")
                ''MessageBox.Show("Breakdown Hrs cant be greater than  24")
                txtMBToday.Focus()
                Exit Sub
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg67")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMBToday.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg68")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMBToday.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg69")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMBToday.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg70")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMBToday.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtMBToday.Text = Hrs + ":" + Min
        End If
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"


        If txtMBToday.Text <> "" Then
            lMechaniclBD = txtMBToday.Text
        End If
        If txtEBDToday.Text <> "" Then
            lelectriclBD = txtEBDToday.Text
        End If
        If txtPBDToday.Text <> "" Then
            lProcessBK = txtPBDToday.Text
        End If
        lBDCalculation = ToaddHours(lProcessBK, lelectriclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If lBDCalculation <> "" Then
            Dim str As String
            Dim strArr() As String
            str = lBDCalculation
            strArr = str.Split(":")

            If strArr(0) > 24 Then
                DisplayInfoMessage("Msg71")
                ''MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
                txtMBToday.Focus()
                Exit Sub
            End If
        End If

        ' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        If (txtMBToday.Text <> "" Or txtEBDToday.Text <> "" Or txtPBDToday.Text <> "") Then
            txtTBDToday.Text = lBDCalculation
        Else
            txtTBDToday.Text = ""
        End If

        If txtTBDToday.Text <> "" Then

            Dim HrsB As String = "00"
            Dim MinB As String = "00"
            Dim strB As String
            Dim strArrB() As String
            'Dim count As Integer
            strB = txtTBDToday.Text
            strArrB = strB.Split(":")

            If strArrB(0).Length = 1 Then
                HrsB = "0" + strArrB(0)
            ElseIf strArrB(0) <> "" Then
                HrsB = strArrB(0)
            End If
            MinB = strArrB(1)
            txtTBDToday.Text = HrsB + ":" + MinB
        End If

        If txtTBDToday.Text <> String.Empty And txtTBDToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))

            lmin = CInt(strArr2(1)) - CInt(strArr1(1))
            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg64")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtMBToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg64")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtMBToday.Focus()
                Exit Sub
            End If

            If txtTBDToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))

                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If


                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then
            txtEPHrsToday.Text = txtTotalHours.Text
        Else
            txtEPHrsToday.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsToday.Text <> "" And txtEPHrsToday.Text <> "00:00" And Len(txtEPHrsToday.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtTotalHours.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If txtMBDMonth.Enabled = False Then
            If txtMBToday.Text <> "" And txtMBToday.Text <> "00:00" Then
                txtMBDMonth.Text = ToaddHours(lMBDMonth, txtMBToday.Text)
                txtMBDYear.Text = ToaddHours(lMBDYear, txtMBToday.Text)
            Else
                txtMBDMonth.Text = lMBDMonth
                txtMBDYear.Text = lMBDYear
            End If
        End If
        If SaveFlag = False And txtMBToday.Text = "" And lPrevMBD = lMBDMonth Then
            txtMBDMonth.Text = ""
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpToday.Text = Math.Round((Val(txtProcessedFFBToday.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpToday.Text = ""
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpToday.Text = Math.Round(Val(txtProcessedFFBToday.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpToday.Text = ""
        End If

       
    End Sub
    Private Sub txtEBDToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEBDToday.Leave


        If txtEBDToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEBDToday.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg72")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtEBDToday.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If Hrs > 24 Then
                DisplayInfoMessage("Msg73")
                ''MessageBox.Show("Breakdown Hrs cant be greater than  24")
                txtEBDToday.Focus()
                Exit Sub
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg74")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtEBDToday.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtEBDToday.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtEBDToday.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtEBDToday.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtEBDToday.Text = Hrs + ":" + Min
        End If
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"


        If txtMBToday.Text <> "" Then
            lMechaniclBD = txtMBToday.Text
        End If
        If txtEBDToday.Text <> "" Then
            lelectriclBD = txtEBDToday.Text
        End If
        If txtPBDToday.Text <> "" Then
            lProcessBK = txtPBDToday.Text
        End If
        lBDCalculation = ToaddHours(lProcessBK, lMechaniclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lelectriclBD)

        If lBDCalculation <> "" Then
            Dim str As String
            Dim strArr() As String
            str = lBDCalculation
            strArr = str.Split(":")

            If strArr(0) > 24 Then
                DisplayInfoMessage("Msg78")
                ''MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
                txtEBDToday.Focus()
                Exit Sub
            End If
        End If

        ' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        If (txtMBToday.Text <> "" Or txtEBDToday.Text <> "" Or txtPBDToday.Text <> "") Then
            txtTBDToday.Text = lBDCalculation
        Else
            txtTBDToday.Text = ""
        End If


        If txtTBDToday.Text <> "" Then

            Dim HrsB As String = "00"
            Dim MinB As String = "00"
            Dim strB As String
            Dim strArrB() As String
            'Dim count As Integer
            strB = txtTBDToday.Text
            strArrB = strB.Split(":")

            If strArrB(0).Length = 1 Then
                HrsB = "0" + strArrB(0)
            ElseIf strArrB(0) <> "" Then
                HrsB = strArrB(0)
            End If
            MinB = strArrB(1)
            txtTBDToday.Text = HrsB + ":" + MinB
        End If
        If txtTBDToday.Text <> String.Empty And txtTBDToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))


            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg64")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtEBDToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg64")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtEBDToday.Focus()
                Exit Sub
            End If

           

            If txtTBDToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer
                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then
            txtEPHrsToday.Text = txtTotalHours.Text
        Else
            txtEPHrsToday.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsToday.Text <> "" And txtEPHrsToday.Text <> "00:00" And Len(txtEPHrsToday.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtTotalHours.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If txtEBDMonth.Enabled = False Then
            If txtEBDToday.Text <> "" And txtEBDToday.Text <> "00:00" Then
                txtEBDMonth.Text = ToaddHours(lEBDMonth, txtEBDToday.Text)
                txtEBDYear.Text = ToaddHours(lEBDYear, txtEBDToday.Text)
            Else
                txtEBDMonth.Text = lEBDMonth
                txtEBDYear.Text = lEBDYear
            End If
        End If

        If SaveFlag = False And txtEBDToday.Text = "" And lPrevEBD = lEBDMonth Then
            txtEBDMonth.Text = ""
        End If

        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpToday.Text = Math.Round((Val(txtProcessedFFBToday.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpToday.Text = ""
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpToday.Text = Math.Round(Val(txtProcessedFFBToday.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpToday.Text = ""
        End If


    End Sub
    Private Sub txtKlToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlToday.Leave
        If Val(txtFFBMonth.Text) <> 0 And lCPOMonth <> 0 And txtKlToday.Text <> "" Then
            txtOERMonth.Text = Math.Round(lCPOMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)

        ElseIf Val(txtFFBMonth.Text) <> 0 And lCPOMonth <> 0 Then
            txtOERMonth.Text = Math.Round(lCPOMonth * 100 / Val(txtFFBMonth.Text), 2)

        Else
            txtOERMonth.Text = ""
        End If

        If Val(txtFFBMonth.Text) <> 0 And lKernelMonth <> 0 And txtKlToday.Text <> "" Then
            'txtKERMonth.Text = Math.Round(lKernelMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)
            txtKERMonth.Text = Math.Round(lKernelMonth * 100 / Val(txtFFBMonth.Text), 2)

        ElseIf Val(txtFFBMonth.Text) <> 0 And lKernelMonth <> 0 Then
            txtKERMonth.Text = Math.Round(lKernelMonth * 100 / Val(txtFFBMonth.Text), 2)
            
        Else
            txtKERMonth.Text = ""
        End If
    End Sub
    Private Sub CPOLogGridViewBind()

        Dim dt As New DataTable
        Dim objCPOLogPPT As New CPOProductionLogPPT
        objCPOLogPPT.ProductionLogDate = dtpCPOLogViewDate.Value
        objCPOLogPPT.CropYieldID = lCropYieldID

        With objCPOLogPPT
            If chkCPOLogDate.Checked = True Then
                dtpCPOViewDate.Enabled = True
                .ProductionLogDate = dtpCPOLogViewDate.Value 'Format(Me.dtpCPOViewDate.Value, "MM/dd/yyyy")
            Else
                dtpCPOLogViewDate.Enabled = False
                .ProductionLogDate = Nothing
            End If

        End With
        dt = CPOProductionLogBOL.GetCPOLogDetails(objCPOLogPPT)

        If dt.Rows.Count <> 0 Then
            dgvCPOLogView.AutoGenerateColumns = False
            Me.dgvCPOLogView.DataSource = dt
        Else
            ClearGridView(dgvCPOLogView) '''''clear the records from grid view
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
    Private Sub dgvCPOLogView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPOLogView.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateCPOLogView()
            End If
        End If



    End Sub
    Private Sub UpdateCPOLogView()

        'If dgvCPOView.SelectedRows(0).Cells("gvstatus").Value <> "OPEN" And dgvCPOView.SelectedRows(0).Cells("gvstatus").Value <> "REJECTED" Then
        EditCPOLogView()
        dtpCPOLogDate.Enabled = False


    End Sub
  
    Private Sub EditCPOLogView()

        If dgvCPOLogView.Rows.Count > 0 Then
            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If

            tcCPOLog.SelectedTab = tbProduction

            Reset()
            Me.cmsCPOLog.Visible = False
            Dim objCPOLogPPT As New CPOProductionLogPPT
            Dim objCPOBOL As New CPOProductionBOL
            lPrevHrs = "00:00"
            Dim dt As New DataTable
            SaveFlag = False
            lCPOProductionLogID = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclCPOProductionLogID").Value
            Dim str As String = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString()
            objCPOLogPPT.ProductionLogDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
            If objCPOLogPPT.ProductionLogDate <> dtpCPOLogDate.Value Then
                dtpCPOLogDate.Value = objCPOLogPPT.ProductionLogDate
            Else
                CPOGetMonthYearFFB()
            End If

            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Update Semua"
            End If
            ''btnSave.Text = "Update All"
            lPrevHrs = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTotalHours").Value



            GetProductionLogShifts()
            TotalHourShiftsKernelProcessedCalculation()


            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTodayFFB").Value Is DBNull.Value Then ' Or dgvCPOLogView.SelectedRows(0).Cells("dgclTodayFFB").Value = 0.0 Then
                txtTodayFFB.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTodayFFB").Value Is DBNull.Value Then
                txtTodayFFB.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTodayFFB").Value

            End If

           

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclNoOfLorry").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclNoOfLorry").Value = 0.0 Then
                txtNoOfLorry.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclNoOfLorry").Value Is DBNull.Value Then
                txtNoOfLorry.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclNoOfLorry").Value

            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFBReceived").Value Is DBNull.Value Then ' Or dgvCPOLogView.SelectedRows(0).Cells("dgclFFBReceived").Value = 0.0 Then
                txtFFBReceived.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFBReceived").Value Is DBNull.Value Then
                lPrevFFBReceived = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFBReceived").Value
                txtFFBReceived.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFBReceived").Value
            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFbNoOfLorry").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclFFbNoOfLorry").Value = 0.0 Then
                txtFFbNoOfLorry.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFbNoOfLorry").Value Is DBNull.Value Then
                txtFFbNoOfLorry.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclFFbNoOfLorry").Value
            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value = 0.0 Then
                txtProcessedFFBToday.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value Is DBNull.Value Then
                lPrevFFB = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value
                txtProcessedFFBToday.Text = ""
                txtProcessedFFBToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value
                txtFFBToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value

            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedLorry").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedLorry").Value = 0.0 Then
                txtProcessedLorry.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedLorry").Value Is DBNull.Value Then
                lPrevlry = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedLorry").Value
                txtProcessedLorry.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedLorry").Value
                txtLryToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedLorry").Value

            End If
            CPOGetMonthYearLorry()
            If txtLryMonth.Enabled = False Then
                If Val(txtLryToday.Text) > 0 Then
                    txtLryMonth.Text = lLryMonth + Val(txtLryToday.Text) - lPrevlry
                    txtLryYear.Text = lLryYear + Val(txtLryToday.Text) - lPrevlry
                Else
                    txtLryMonth.Text = lLryMonth
                    txtLryYear.Text = lLryYear
                End If
            
            End If
         
            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedFFB").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedFFB").Value = 0.0 Then
                txtUnProcessedFFB.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedFFB").Value Is DBNull.Value Then
                txtUnProcessedFFB.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedFFB").Value
            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedLorry").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedLorry").Value = 0.0 Then
                txtUnProcessedLorry.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedLorry").Value Is DBNull.Value Then
                txtUnProcessedLorry.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclUnProcessedLorry").Value
            End If


            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLossOnKernal").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclLossOnKernal").Value = 0.0 Then
                txtLossOnKernal.Text = Nothing
                txtKlToday.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLossOnKernal").Value Is DBNull.Value Then
                lPrevKl = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLossOnKernal").Value
                txtLossOnKernal.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLossOnKernal").Value
                txtKlToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLossOnKernal").Value

            End If


            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLryWtToday").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclLryWtToday").Value = 0.0 Then
                txtLryWtToday.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLryWtToday").Value Is DBNull.Value Then
                txtLryWtToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclLryWtToday").Value
            End If
            If Val(txtLryMonth.Text) > 0 And Val(txtFFBMonth.Text) > 0 Then
                txtLryWtMonth.Text = Math.Round(Val(txtFFBMonth.Text) / Val(txtLryMonth.Text), 3)
            Else
                txtLryWtMonth.Text = ""
            End If

            If Val(txtLryYear.Text) > 0 And Val(txtFFBYear.Text) > 0 Then
                txtLryWtYear.Text = Math.Round(Val(txtFFBYear.Text) / Val(txtLryYear.Text), 3)
            Else
                txtLryWtYear.Text = ""
            End If


            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBToday").Value Is DBNull.Value Then ' Or dgvCPOLogView.SelectedRows(0).Cells("dgclMBToday").Value = 0.0 Then
                txtMBToday.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBToday").Value Is DBNull.Value Then
                txtMBToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBToday").Value
                lPrevMBD = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBToday").Value
               
               
            End If
            CPOGetMonthYearMechanicalBD()
            If txtMBDMonth.Enabled = False Then
                If txtMBToday.Text <> "" And txtMBToday.Text <> "00:00" Then
                    txtMBDMonth.Text = ToaddHours(lMBDMonth, txtMBToday.Text)
                    txtMBDYear.Text = ToaddHours(lMBDYear, txtMBToday.Text)
                Else
                    txtMBDMonth.Text = lMBDMonth
                    txtMBDYear.Text = lMBDYear
                End If
            End If


            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDToday").Value Is DBNull.Value Then ' Or dgvCPOLogView.SelectedRows(0).Cells("dgclEBDToday").Value = 0.0 Then
                txtEBDToday.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDToday").Value Is DBNull.Value Then
                txtEBDToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDToday").Value
                lPrevEBD = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDToday").Value
            End If
            CPOGetMonthYearElectricalBD()
            If txtEBDMonth.Enabled = False Then
                If txtEBDToday.Text <> "" And txtEBDToday.Text <> "00:00" Then
                    txtEBDMonth.Text = ToaddHours(lEBDMonth, txtEBDToday.Text)
                    txtEBDYear.Text = ToaddHours(lEBDYear, txtEBDToday.Text)
                Else
                    txtEBDMonth.Text = lEBDMonth
                    txtEBDYear.Text = lEBDYear
                End If
            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDToday").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclPBDToday").Value = 0.0 Then
                txtPBDToday.Text = Nothing

            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDToday").Value Is DBNull.Value Then
                txtPBDToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDToday").Value
                lPrevPBD = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDToday").Value
            End If
            CPOGetMonthYearProcessingBD()
            If txtPBDMonth.Enabled = False Then
                If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then
                    txtPBDMonth.Text = ToaddHours(lPBDMonth, txtPBDToday.Text)
                    txtPBDYear.Text = ToaddHours(lPBDYear, txtPBDToday.Text)
                Else
                    txtPBDMonth.Text = lPBDMonth
                    txtPBDYear.Text = lPBDYear
                End If
            Else
                If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBDMonth").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclMBDMonth").Value = 0.0 Then
                    txtMBDMonth.Text = Nothing
                ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBDMonth").Value Is DBNull.Value Then
                    txtMBDMonth.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBDMonth").Value
                End If

                If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDMonth").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclEBDMonth").Value = 0.0 Then
                    txtEBDMonth.Text = Nothing
                ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDMonth").Value Is DBNull.Value Then
                    txtEBDMonth.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDMonth").Value
                End If

                If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDMonth").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclPBDMonth").Value = 0.0 Then
                    txtPBDMonth.Text = Nothing
                ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDMonth").Value Is DBNull.Value Then
                    txtPBDMonth.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDMonth").Value
                End If
                If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBDYear").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclMBDYear").Value = 0.0 Then
                    txtMBDYear.Text = Nothing
                ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBDYear").Value Is DBNull.Value Then
                    txtMBDYear.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclMBDYear").Value
                End If

                If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDYear").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclEBDYear").Value = 0.0 Then
                    txtEBDYear.Text = Nothing
                ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDYear").Value Is DBNull.Value Then
                    txtEBDYear.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDYear").Value
                End If

                If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDYear").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclPBDYear").Value = 0.0 Then
                    txtPBDYear.Text = Nothing
                ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDYear").Value Is DBNull.Value Then
                    txtPBDYear.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclPBDYear").Value
                End If
            End If

            If Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTBDToday").Value Is DBNull.Value Then 'Or dgvCPOLogView.SelectedRows(0).Cells("dgclTBDToday").Value = 0.0 Then
                txtTBDToday.Text = Nothing
            ElseIf Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTBDToday").Value Is DBNull.Value Then
                txtTBDToday.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclTBDToday").Value
            End If

            
            If Not Me.dgvCPOLogView.SelectedRows(0).Cells("dgclEBDMonth").Value Is DBNull.Value Then
                txtLogRemarks.Text = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclRemarks").Value.ToString
            End If

            Me.tcCPOProductionLog.SelectedTab = tpCPOProductionSave

            GetPKOLogPress()
            TPH()
          
            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "UpdateAll"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            ' Dim dt As New DataTable
            ' Dim objCPOLogPPT As New CPOProductionLogPPT
            '  objCPOLogPPT.ProductionLogDate = dtpCPOLogViewDate.Value
            objCPOLogPPT.CropYieldID = lCropYieldID

            With objCPOLogPPT
                .ProductionLogDate = Nothing

            End With
            dt = CPOProductionLogBOL.GetCPOLogDetails(objCPOLogPPT)

            If dgvCPOLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString() <> dt.Rows(0).Item("productionDate") Then
                btnSave.Enabled = False
                btnDeleteAll.Enabled = False
                ' DisplayInfoMessage("msg177")
                DisplayInfoMessage("msg176")
            End If


            CPOLogGridViewBind()



        Else
            DisplayInfoMessage("Msg79")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub
    Private Sub GetPKOLogPress()

        Dim objCPOProductionLogPPT As New CPOProductionLogPPT
        Dim objCPOProductionLogBOL As New CPOProductionBOL

        objCPOProductionLogPPT.CPOProductionLogID = lCPOProductionLogID

        Dim dt As New DataTable

        dt = CPOProductionLogBOL.GetCPOProductionLogPress(objCPOProductionLogPPT)

        If dt.Rows.Count <> 0 And dt IsNot Nothing Then
            dgPressInfo.AutoGenerateColumns = False
            dgPressInfo.DataSource = dt
            dtPressInfo = dt

        End If


    End Sub
    Private Sub TPH()

        Try
            Dim objDataGridViewRow As New DataGridViewRow
            ' txtTotalHoursPress.Text = ""
            lTotalOPHoursStage1 = "00:00"
            lTotalOPHoursStage2 = "00:00"
            txtTotalHoursPress.Text = ""
            For Each objDataGridViewRow In dgPressInfo.Rows
                If objDataGridViewRow.Cells("dgMestage").Value.ToString = "Line 1" And objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString <> "" Then
                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString()
                    lTotalOPHoursStage1 = lTotalOPHoursStage1
                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = lTotalOPHoursStage1
                    strArr = Str.Split(":")
                    Str1 = lCominValue
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"

                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lTotalOPHoursStage1 = Strhrs + ":" + StrMin
                ElseIf objDataGridViewRow.Cells("dgMestage").Value.ToString = "Line 2" And objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString <> "" Then

                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString()
                    lTotalOPHoursStage2 = lTotalOPHoursStage2
                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str1 = lTotalOPHoursStage2
                    strArr = Str1.Split(":")
                    Str = lCominValue
                    strArr1 = Str.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"


                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lTotalOPHoursStage2 = Strhrs + ":" + StrMin
                End If
            Next
            If lTotalOPHoursStage1 <> "00:00" Or lTotalOPHoursStage2 <> "00:00" Then

                Dim strArr(), strArr1() As String
                Dim Str, Str1 As String
                Str1 = lTotalOPHoursStage2
                strArr = Str1.Split(":")
                Str = lTotalOPHoursStage1
                strArr1 = Str.Split(":")

                Dim Lhrs, lmin As Integer

                Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If
                Dim Strhrs As String = "00"
                Dim StrMin As String = "00"



                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If
                txtTotalHoursPress.Text = Convert.ToString(Strhrs) + ":" + Convert.ToString(StrMin)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

        UpdateCPOLogView()
    End Sub
    Private Sub DeleteCPOLogVIew()
        '   Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CPOProductionLogFrm))
        Dim dt As New DataTable
        Dim objCPOLogPPT As New CPOProductionLogPPT
        objCPOLogPPT.ProductionLogDate = dtpCPOLogViewDate.Value
        objCPOLogPPT.CropYieldID = lCropYieldID

        With objCPOLogPPT
            .ProductionLogDate = Nothing

        End With
        dt = CPOProductionLogBOL.GetCPOLogDetails(objCPOLogPPT)

        If dgvCPOLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString() = dt.Rows(0).Item("productionDate") Then
            Me.cmsCPOLog.Visible = False
            'Dim objCPOLogPPT As New CPOProductionLogPPT
            Dim objCPOLogBOL As New CPOProductionLogBOL
            ' Dim dt As New DataTable
            If dgvCPOLogView.Rows.Count > 0 Then
                lCPOProductionLogID = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclCPOProductionLogID").Value.ToString()
                If MsgBox(rm.GetString("Msg110"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"":", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    'Dim str As String = Me.dgvCPOLogView.SelectedRows(0).Cells("gvCPODate").Value.ToString()
                    'objCPOLogPPT.ProductionLogDate = New Date(str.Substring(6, 4), str.Substring(3, 2), str.Substring(0, 2))
                    objCPOLogPPT.CPOProductionLogID = lCPOProductionLogID
                    objCPOLogBOL.Delete_CPOLogDetail(objCPOLogPPT)
                    CPOLogFFBLorryProcessed()
                    CPOLogGridViewBind()
                End If
            Else
                DisplayInfoMessage("Msg81")
                ''MessageBox.Show(" No Record to Delete", " Please End Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Else
            DisplayInfoMessage("msg177")
            '  DisplayInfoMessage("msg176")
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvCPOLogView.RowCount > 0 Then
            DeleteCPOLogVIew()
        End If


    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkCPODate.Checked = False Then
            DisplayInfoMessage("Msg82")
            ''MsgBox("Please Enter Criteria to Search!")
            CPOLogGridViewBind()

        Else
            CPOLogGridViewBind()
            If dgvCPOView.RowCount = 0 Then
                DisplayInfoMessage("Msg83")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If

    End Sub

   
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If (dgvCPOLogDetails.RowCount > 0 Or dgPressInfo.RowCount > 0) And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg80"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
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




    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Clear()
        tcCPOProductionLog.SelectedTab = tpCPOProductionSave
    End Sub
    Private Sub chkCPOLogDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCPOLogDate.CheckedChanged
        If chkCPOLogDate.Checked = True Then
            dtpCPOLogViewDate.Enabled = True
        Else
            dtpCPOLogViewDate.Enabled = False
        End If
    End Sub

    Private Sub txtFFBProcessed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBProcessed.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub



    Private Sub txtFFBProcessed_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBProcessed.Leave
        FindTotalhrs()
    End Sub

 

    Private Sub cmbCPOLogStartMin_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'FindTotalhrs()
        CPOGetMonthYearQty()


        'FindTotalTime()
    End Sub

    Private Sub cmbCPOLogStopHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FindTotalhrs()
        ' CPOGetMonthYearQty()


        ' FindTotalTime()
    End Sub



    Private Sub txtEBDToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEBDToday.TextChanged

        If txtEBDToday.Text <> "" Then
            Dim Value As String = txtEBDToday.Text
            Dim strlen As Integer
            strlen = Len(txtEBDToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtEBDToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtEBDToday.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtPBDToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBDToday.TextChanged


        If txtPBDToday.Text <> "" Then
            Dim Value As String = txtPBDToday.Text
            Dim strlen As Integer
            strlen = Len(txtPBDToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtPBDToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtPBDToday.Focus()
                End If
            Next
        End If
    End Sub
    Private Sub tcCPOLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCPOLog.SelectedIndexChanged
        KernelGetTodayQty()

        If tcCPOLog.SelectedIndex = 2 Then
            If txtProcessedFFBToday.Text <> "" Then
                txtFFBToday.Text = Math.Round(CDbl(Val(txtProcessedFFBToday.Text)), 3)
            End If
            If txtProcessedLorry.Text <> "" Then
                txtLryToday.Text = Val(txtProcessedLorry.Text)
            End If
            If txtLossOnKernal.Text <> "" Then
                txtKlToday.Text = CDbl(Val(txtLossOnKernal.Text))
            End If

            If Val(txtFFBToday.Text) > 0 And Val(txtLryToday.Text) > 0 Then
                txtLryWtToday.Text = Math.Round(CDbl(Val(txtFFBToday.Text)) / Val(txtLryToday.Text), 3) 'CDbl(Val(txtFFBToday.Text)) / CDbl(Val(txtLryToday.Text))
                'If txtLryWtToday.Text = "NaN" Or txtLryWtToday.Text = "Infinity" Then
                '    txtLryWtToday.Text = "0"
                'End If
            Else
                txtLryWtToday.Text = ""
            End If
        End If
        If tcCPOLog.SelectedIndex = 1 Then
            If txtKernalProduction.Text = String.Empty Then
                txtLossOnKernal.Enabled = False
            Else
                txtLossOnKernal.Enabled = True
            End If
        End If

        If tcCPOLog.SelectedIndex >= 2 Then
            If txtLryMonth.Enabled = False Then
                If Val(txtLryToday.Text) > 0 Then
                    txtLryMonth.Text = lLryMonth + Val(txtLryToday.Text) - lPrevlry
                    txtLryYear.Text = lLryYear + Val(txtLryToday.Text) - lPrevlry
                Else
                    txtLryMonth.Text = lLryMonth
                    txtLryYear.Text = lLryYear
                End If
            End If

            CPOGetMonthYearQty()

            If txtMBDMonth.Enabled = False Then
                If txtMBToday.Text <> "" And txtMBToday.Text <> "00:00" Then
                    txtMBDMonth.Text = ToaddHours(lMBDMonth, txtMBToday.Text)
                    txtMBDYear.Text = ToaddHours(lMBDYear, txtMBToday.Text)
                Else
                    txtMBDMonth.Text = lMBDMonth
                    txtMBDYear.Text = lMBDYear
                End If
            End If

            If txtEBDMonth.Enabled = False Then
                If txtEBDToday.Text <> "" And txtEBDToday.Text <> "00:00" Then
                    txtEBDMonth.Text = ToaddHours(lEBDMonth, txtEBDToday.Text)
                    txtEBDYear.Text = ToaddHours(lEBDYear, txtEBDToday.Text)
                Else
                    txtEBDMonth.Text = lEBDMonth
                    txtEBDYear.Text = lEBDYear
                End If
            End If

            If txtPBDMonth.Enabled = False Then
                If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then
                    txtPBDMonth.Text = ToaddHours(lPBDMonth, txtPBDToday.Text)
                    txtPBDYear.Text = ToaddHours(lPBDYear, txtPBDToday.Text)
                Else
                    txtPBDMonth.Text = lPBDMonth
                    txtPBDYear.Text = lPBDYear
                End If
            End If
            BreakdownMonthCalculation()
            BreakdownYearCalculation()

            If txtTBDMonth.Text <> String.Empty And txtMonthTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtMonthTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDMonth.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer



                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If


                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsMonth.Text = Strhrs2 + ":" + StrMin2
            ElseIf txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then
                txtEPHrsMonth.Text = txtMonthTodate.Text
            Else
                txtEPHrsMonth.Text = "00:00"
            End If

            If txtTBDYear.Text <> String.Empty And txtYearTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtYearTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDYear.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer
                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If


                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsYear.Text = Strhrs2 + ":" + StrMin2
            ElseIf txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then
                txtEPHrsYear.Text = txtYearTodate.Text
            Else
                txtEPHrsYear.Text = "00:00"
            End If

            Dim lEffectiveHrsDec As Decimal
            If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                str3 = txtEPHrsMonth.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lEffectiveHrsDec = Hrs1 + lmin1


            End If

            Dim lProcessHrsDec As Decimal
            If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = txtPBDMonth.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lProcessHrsDec = Hrs1 + lmin1

            End If

            Dim lTotalHrsDec As Decimal
            If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = txtMonthTodate.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lTotalHrsDec = Hrs1 + lmin1
            ElseIf lmonthValuehrs <> "" And lmonthValuehrs <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = lmonthValuehrs
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lTotalHrsDec = Hrs1 + lmin1

            End If

            If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

                txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
            Else
                txtTpMonth.Text = ""
            End If


            If Val(txtFFBMonth.Text) <> 0 And lTotalHrsDec > 0 Then
                txtAvgTpMonth.Text = Math.Round(Val(txtFFBMonth.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
            Else
                txtAvgTpMonth.Text = ""
            End If
            lEffectiveHrsDec = 0
            lTotalHrsDec = 0
            lProcessHrsDec = 0
            ' Dim lEffectiveHrsDec As Decimal
            If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = txtEPHrsYear.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lEffectiveHrsDec = Hrs1 + lmin1


            End If

            ' Dim lProcessHrsDec As Decimal
            If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = txtPBDYear.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lProcessHrsDec = Hrs1 + lmin1

            End If

            '  Dim lTotalHrsDec As Decimal
            If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = txtYearTodate.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lTotalHrsDec = Hrs1 + lmin1
            ElseIf lYearValue <> "" And lYearValue <> "00:00" Then
                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = lYearValue
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lTotalHrsDec = Hrs1 + lmin1


            End If

            If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

                txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
            Else
                txtTpYear.Text = ""
            End If


            If Val(txtFFBYear.Text) <> 0 And lTotalHrsDec > 0 Then
                txtAvgTpYear.Text = Math.Round(Val(txtFFBYear.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
            Else
                txtAvgTpYear.Text = ""
            End If

            If tcCPOLog.SelectedIndex = 3 Then
                summCalcMonthStage1()
                summCalcMonthStage2()
                SummCalcstage1Year()
                SummCalcstage2Year()

            End If
        End If

    End Sub

    Private Sub dgvCPOLogView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCPOLogView.KeyDown
        If e.KeyCode = Keys.Return Then
            UpdateCPOLogView()
            e.Handled = True
        End If
    End Sub

    Private Sub txtFFbNoOfLorry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFbNoOfLorry.KeyPress
        KeyPressDecimal(sender, e)
    End Sub

    Private Sub SaveCPODetail()

        Dim objCPOPPT As New CPOProductionPPT
        Dim objCPOBOL As New CPOProductionBOL
        Dim intRowcount As Integer = dtCPOAdd.Rows.Count

        'lHrs = cmbCPOLogStartHrs.Text
        'lmin = cmbCPOLogStartMin.Text
        ''lAMPM = cmbCPOLogStartAMPM.Text

        lStartTime = txtStartTime.Text

        'lHrs = cmbCPOLogStopHrs.Text
        'lmin = cmbCPOLogStopMin.Text
        '' lAMPM = cmbCPOLogStopAMPM.Text
        lStopTime = txtStopTime.Text
        lTotalBreakdown = txtTotalBrkdown.Text



        If Not ShiftExist(cboShift.Text) Then

            '''' For check Duplicate Tank ''''

            rowCPOAdd = dtCPOAdd.NewRow()
            'rowCPOAdd = dtCPOProduction.NewRow()


            If intRowcount = 0 And btnAddFlag = True Then
                Try


                    columnCPOAdd = New DataColumn("Shift", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Assistant", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("Mandore", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("StartTime", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("EndTime", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("FFBProcessed", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("LorryProcessed", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("ShiftHours", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)
                    columnCPOAdd = New DataColumn("TotalBreakdown", System.Type.[GetType]("System.String"))
                    dtCPOAdd.Columns.Add(columnCPOAdd)

                Catch ex As Exception
                End Try
                rowCPOAdd("Shift") = Me.cboShift.Text
                rowCPOAdd("Assistant") = Me.txtAssistant.Text
                rowCPOAdd("Mandore") = Me.txtMandor.Text
                rowCPOAdd("StartTime") = lStartTime
                rowCPOAdd("EndTime") = lStopTime
                rowCPOAdd("FFBProcessed") = Me.txtFFBProcessed.Text
                rowCPOAdd("LorryProcessed") = Me.txtLorryProcessed.Text
                rowCPOAdd("ShiftHours") = Me.txtShiftHrs.Text
                rowCPOAdd("TotalBreakdown") = Me.txtTotalBrkdown.Text
                dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)

            Else

                rowCPOAdd("Shift") = Me.cboShift.Text
                rowCPOAdd("Assistant") = Me.txtAssistant.Text
                rowCPOAdd("Mandore") = Me.txtMandor.Text
                rowCPOAdd("StartTime") = lStartTime
                rowCPOAdd("EndTime") = lStopTime
                rowCPOAdd("FFBProcessed") = Me.txtFFBProcessed.Text
                rowCPOAdd("LorryProcessed") = Me.txtLorryProcessed.Text
                rowCPOAdd("ShiftHours") = Me.txtShiftHrs.Text
                rowCPOAdd("TotalBreakdown") = Me.txtTotalBrkdown.Text
                dtCPOAdd.Rows.InsertAt(rowCPOAdd, intRowcount)

                btnAddFlag = True


            End If

        Else
            DisplayInfoMessage("Msg85")
            ''MessageBox.Show("Sorry this Shift already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        With dgvCPOLogDetails
            ' .AutoGenerateColumns = False
            .DataSource = dtCPOAdd
            TotalHourShiftsKernelProcessedCalculation()
            ResetMain()
            ClearShift()
            StartDatefunction()
            StopDatefunction()
        End With


    End Sub
    Private Function ShiftExist(ByVal Shift As String) As Boolean

        Dim objDataGridViewRow As New DataGridViewRow
        'If AddFlag = True Then
        For Each objDataGridViewRow In dgvCPOLogDetails.Rows
            If Shift = objDataGridViewRow.Cells("Shift").Value.ToString() Then
                ' txtStockCode.Text = ""
                cboShift.Focus()
                Return True
            End If
        Next
        Return False


        ' If
    End Function
    Private Sub UpdateCPODetails()

        Dim intCount As Integer = dgvCPOLogDetails.CurrentRow.Index
        'Dim lHrsStartTime As String
        'Dim lminStartTime As String
        'Dim lHrsStopTime As String
        'Dim lminStopTime As String
        'Dim lStartTime As String
        'Dim lStopTime As String
        'lHrsStartTime = cmbCPOLogStartHrs.Text
        'lminStartTime = cmbCPOLogStartMin.Text

        'lHrsStopTime = cmbCPOLogStopHrs.Text
        'lminStopTime = cmbCPOLogStopMin.Text

        'If lminStartTime < 10 And lminStartTime.Length = 1 Then
        '    lminStartTime = "0" + lminStartTime
        'End If
        'If lminStopTime < 10 And lminStopTime.Length = 1 Then
        '    lminStopTime = "0" + lminStopTime
        'End If


        lStartTime = txtStartTime.Text
        lStopTime = txtStopTime.Text
        lTotalBreakdown = txtTotalBrkdown.Text

        If lTempShift = cboShift.Text Then


            dgvCPOLogDetails.Rows(intCount).Cells("Shift").Value = cboShift.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Assistant").Value = txtAssistant.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Mandore").Value = txtMandor.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Start_Time").Value = lStartTime
            dgvCPOLogDetails.Rows(intCount).Cells("Stop_Time").Value = lStopTime
            dgvCPOLogDetails.Rows(intCount).Cells("TotalBreakdown").Value = lTotalBreakdown
            dgvCPOLogDetails.Rows(intCount).Cells("ShiftHours").Value = txtShiftHrs.Text
            dgvCPOLogDetails.Rows(intCount).Cells("FFB_Processed").Value = txtFFBProcessed.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Lorry_Processed").Value = txtLorryProcessed.Text

            If GlobalPPT.strLang = "en" Then
                btnAddShift.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddShift.Text = "Menambahkan"
            End If

            ''btnAddShift.Text = "Add"
            btnAddFlag = True
            ClearShift()
            StartDatefunction()
            StopDatefunction()
            'clear()
            TotalHourShiftsKernelProcessedCalculation()
            ResetMain()
        ElseIf Not ShiftExist(cboShift.Text) Then

            dgvCPOLogDetails.Rows(intCount).Cells("Shift").Value = cboShift.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Assistant").Value = txtAssistant.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Mandore").Value = txtMandor.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Start_Time").Value = lStartTime
            dgvCPOLogDetails.Rows(intCount).Cells("Stop_Time").Value = lStopTime
            dgvCPOLogDetails.Rows(intCount).Cells("TotalBreakdown").Value = lTotalBreakdown
            dgvCPOLogDetails.Rows(intCount).Cells("ShiftHours").Value = txtShiftHrs.Text
            dgvCPOLogDetails.Rows(intCount).Cells("FFB_Processed").Value = txtFFBProcessed.Text
            dgvCPOLogDetails.Rows(intCount).Cells("Lorry_Processed").Value = txtLorryProcessed.Text
            If GlobalPPT.strLang = "en" Then
                btnAddShift.Text = "Add"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddShift.Text = "Menambahkan"
            End If


            ''btnAddShift.Text = "Add"
            btnAddFlag = True
            ClearShift()
            StartDatefunction()
            StopDatefunction()
            TotalHourShiftsKernelProcessedCalculation()
            ResetMain()
        Else
            DisplayInfoMessage("Msg85")
            ''MessageBox.Show("Sorry This Shift already exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboShift.Focus()
        End If

        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

    End Sub
    Public Sub ResetMain()
        ''''For Stock CPO
        If cboShift.Items.Count > 0 Then
            cboShift.SelectedIndex = 0
        End If
        txtAssistant.Text = ""
        txtMandor.Text = ""
        txtFFBProcessed.Text = ""
        txtLorryProcessed.Text = ""
        StartDatefunction()
        StopDatefunction()
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If

        ''btnAdd.Text = "Add"
        btnAddFlag = True
    End Sub
    Private Sub Add_Clicked()


        If cboShift.Text = "--Select Shift--" Then
            DisplayInfoMessage("Msg86")
            ''MessageBox.Show("This field is required", "Shift")
            cboShift.Focus()
            Exit Sub
        End If

       
        If txtStartTime.Text = "" Then
            DisplayInfoMessage("Msg188")
            ''MessageBox.Show("This field is required", "Lorry Processed")
            txtStartTime.Focus()
            Exit Sub
        End If
        If txtStopTime.Text = "" Then
            DisplayInfoMessage("Msg187")
            ''MessageBox.Show("This field is required", "FFB Processed")
            txtStopTime.Focus()
            Exit Sub
        End If
        If txtTotalBrkdown.Text = "" Then
            DisplayInfoMessage("Msg189")
            ''MessageBox.Show("This field is required", "Total Breakdown")
            txtTotalBrkdown.Focus()
            Exit Sub
        End If



        If Val(txtFFBProcessed.Text) < 0 Then
            DisplayInfoMessage("Msg87")
            ''MessageBox.Show("This field is required", "FFB Processed")
            txtFFBProcessed.Focus()
            Exit Sub
        End If

        If Val(txtLorryProcessed.Text) < 0 Then
            DisplayInfoMessage("Msg88")
            ''MessageBox.Show("This field is required", "Lorry Processed")
            txtLorryProcessed.Focus()
            Exit Sub
        End If




        'lHrsStartTime = cmbCPOLogStartHrs.Text
        'lminStartTime = cmbCPOLogStartMin.Text

        'lHrsStopTime = cmbCPOLogStopHrs.Text
        'lminStopTime = cmbCPOLogStopMin.Text
        'Dim lStartTime As String
        'Dim lStopTime As String
        'lStartTime = txtStartTime.Text
        'lStopTime = txtStopTime.Text

        'If lStartTime = lStopTime Then
        '    DisplayInfoMessage("Msg89")
        '    ''MsgBox("Start Time and Stop Time cannot be equal, Please the change the Time")
        '    Exit Sub
        'End If

        Dim strArr7() As String
        Dim str7 As String
        str7 = txtStartTime.Text
        strArr7 = str7.Split(":")
        If CInt(strArr7(0)) >= 24 Then
            DisplayInfoMessage("Msg179")
            txtStartTime.Focus()
            Exit Sub
        End If

        str7 = txtStopTime.Text
        strArr7 = str7.Split(":")
        If CInt(strArr7(0)) >= 24 Then
            DisplayInfoMessage("Msg180")
            txtStartTime.Focus()
            Exit Sub
        End If

        If txtShiftHrs.Text <> "" Then
            Dim strArr() As String
            Dim str As String
            str = txtShiftHrs.Text
            strArr = str.Split(":")

            If CInt(strArr(0)) > 24 Or (CInt(strArr(0)) = 24 And CInt(strArr(1)) <> 0) Then
                DisplayInfoMessage("Msg178")
                txtStopTime.Focus()
                Exit Sub
            End If
        End If



        Dim objCPOLogPPT As New CPOProductionLogPPT
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        If dtpCPOLogDate.Enabled = True Then
            Dim ObjRecordExist As Object
            ObjRecordExist = CPOProductionLogBOL.DuplicateDateCheck(objCPOLogPPT)

            If ObjRecordExist = 0 Then
                DisplayInfoMessage("Msg90")
                ''MsgBox("Cannot Add Record(s)in Same Date!")
                Exit Sub
            End If
        End If

        Dim lShiftHours As String = "00:00"
        lShiftHours = txtShiftHrs.Text

        If dgvCPOLogDetails.Rows.Count <> 0 And btnAddFlag = True Then
            For Each objDataGridViewRow In dgvCPOLogDetails.Rows
                If objDataGridViewRow.Cells("ShiftHours").Value.ToString <> String.Empty Then
                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("ShiftHours").Value.ToString()
                    lShiftHours = lShiftHours

                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = lShiftHours
                    strArr = Str.Split(":")
                    Str1 = lCominValue
                    strArr1 = Str1.Split(":")
                    Dim Lhrs, lmin As Integer


                    Lhrs = CInt(strArr(0)) + CInt(strArr1(0))

                    lmin = CInt(strArr(1)) + CInt(strArr1(1))


                    If Lhrs > 24 Then
                        DisplayInfoMessage("Msg91")
                        ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                        Exit Sub
                    ElseIf Lhrs = 24 And lmin > 0 Then
                        DisplayInfoMessage("Msg91")
                        ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                        Exit Sub
                    Else
                        If lmin >= 60 Then
                            lmin = lmin - 60
                            Lhrs = Lhrs + 1
                        End If
                        Dim Strhrs As String = "00"
                        Dim StrMin As String = "00"

                        If Lhrs < 10 Then
                            Strhrs = "0" + Convert.ToString(Lhrs)
                        Else
                            Strhrs = Lhrs
                        End If

                        If lmin < 10 Then
                            StrMin = "0" + Convert.ToString(lmin)
                        Else
                            StrMin = lmin
                        End If
                        lShiftHours = Strhrs + ":" + StrMin
                    End If
                End If
            Next
        ElseIf btnAddFlag = False Then
            For Each objDataGridViewRow In dgvCPOLogDetails.Rows
                If objDataGridViewRow.Cells("ShiftHours").Value.ToString <> String.Empty Then
                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("ShiftHours").Value.ToString()
                    lShiftHours = lShiftHours

                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String

                    Str = lShiftHours
                    strArr = Str.Split(":")
                    Str1 = lCominValue
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer
                    Lhrs = CInt(strArr(0)) + CInt(strArr1(0))
                    lmin = CInt(strArr(1)) + CInt(strArr1(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"

                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lShiftHours = Strhrs + ":" + StrMin
                End If

            Next

            Dim strArr2(), strArr3() As String
            Dim Str2, Str3 As String
            Str2 = lShiftHours
            strArr2 = Str2.Split(":")
            Str3 = dgvCPOLogDetails.SelectedRows(0).Cells("ShiftHours").Value.ToString
            strArr3 = Str3.Split(":")

            Dim Lhrs1, lmin1 As Integer

            Lhrs1 = strArr2(0) - strArr3(0)

            If strArr3(1) > strArr2(1) Then
                lmin1 = strArr3(1) - strArr2(1)
                Lhrs1 = Lhrs1 - 1
            ElseIf strArr3(1) < strArr2(1) Then
                lmin1 = strArr2(1) - strArr3(1)
            End If
            Dim Strhrs1 As String = "00"
            Dim StrMin1 As String = "00"

            If Lhrs1 > 24 Then
                DisplayInfoMessage("Msg92")
                ''MsgBox("Shift Hrs Cant be greater than 24 hrs ")
                Exit Sub
            ElseIf Lhrs1 = 24 And lmin1 > 0 Then
                DisplayInfoMessage("Msg92")
                ''MsgBox("Shift Hrs Cant be greater than 24 hrs ")
                Exit Sub
            Else
                If Lhrs1 < 10 Then
                    Strhrs1 = "0" + Convert.ToString(Lhrs1)
                Else
                    Strhrs1 = Lhrs1
                End If

                If lmin1 < 10 Then
                    StrMin1 = "0" + Convert.ToString(lmin1)
                Else
                    StrMin1 = lmin1
                End If

                lShiftHours = Strhrs1 + ":" + StrMin1
            End If
        Else
            lShiftHours = "00:00"

        End If

        If btnAddFlag = True Then
            SaveCPODetail()

        ElseIf btnAddFlag = False Then
            UpdateCPODetails()

        End If

    End Sub
    Private Sub btnAddShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddShift.Click
        Add_Clicked()

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

        txtMonthTodate.Text = dateMonth & ":00"
        txtYearTodate.Text = (dateCalculate * 24) & ":00"
    End Sub
    Private Sub BindDgvCPOLogShiftDetails()


        If dgvCPOLogDetails.Rows.Count > 0 Then

            If GlobalPPT.strLang = "en" Then
                btnAddShift.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddShift.Text = "Memperbarui"
            End If
            ''Me.btnAddShift.Text = "Update"
            ' Me.btnSaveAll.Text = "Update All"
            btnAddFlag = False


            cboShift.Text = dgvCPOLogDetails.SelectedRows(0).Cells("Shift").Value.ToString()
            lTempShift = dgvCPOLogDetails.SelectedRows(0).Cells("Shift").Value.ToString()
            txtAssistant.Text = dgvCPOLogDetails.SelectedRows(0).Cells("Assistant").Value.ToString()
            txtMandor.Text = dgvCPOLogDetails.SelectedRows(0).Cells("Mandore").Value.ToString()
            txtFFBProcessed.Text = dgvCPOLogDetails.SelectedRows(0).Cells("FFB_Processed").Value.ToString()
            txtLorryProcessed.Text = dgvCPOLogDetails.SelectedRows(0).Cells("Lorry_Processed").Value.ToString()
            'lStartTime = dgvCPOLogDetails.SelectedRows(0).Cells("Start_Time").Value.ToString()
            'lStopTime = dgvCPOLogDetails.SelectedRows(0).Cells("Stop_Time").Value.ToString()
            Dim lStartTime As String
            Dim lStopTime As String
            Dim lTotalBreakdown As String
            lStartTime = dgvCPOLogDetails.SelectedRows(0).Cells("Start_Time").Value.ToString()
            lStopTime = dgvCPOLogDetails.SelectedRows(0).Cells("Stop_Time").Value.ToString()
            If Not dgvCPOLogDetails.SelectedRows(0).Cells("TotalBreakdown").Value Is Nothing Then
                lTotalBreakdown = dgvCPOLogDetails.SelectedRows(0).Cells("TotalBreakdown").Value.ToString()
                'lTotalBreakdown = lTotalBreakdown.Replace("#", "")
                'lTotalBreakdown = lTotalBreakdown.Substring(0, 5)
                txtTotalBrkdown.Text = lTotalBreakdown
            End If

            lStartTime = lStartTime.Replace("#", "")
            lStartTime = lStartTime.Substring(0, 5)
            txtStartTime.Text = lStartTime

            lStopTime = lStopTime.Replace("#", "")
            lStopTime = lStopTime.Substring(0, 5)
            txtStopTime.Text = lStopTime

           
            timeCalculation()
            'If lStartTime.Hour = 0 Then
            '    cmbCPOLogStartHrs.Text = "00"
            'ElseIf lStartTime.Hour < 10 Then
            '    cmbCPOLogStartHrs.Text = "0" + CStr(lStartTime.Hour)
            'Else
            '    cmbCPOLogStartHrs.Text = lStartTime.Hour
            'End If
            'If lStopTime.Hour = 0 Then
            '    cmbCPOLogStopHrs.Text = "00"
            'ElseIf lStopTime.Hour < 10 Then
            '    cmbCPOLogStopHrs.Text = "0" + CStr(lStopTime.Hour)
            'Else
            '    cmbCPOLogStopHrs.Text = lStopTime.Hour
            'End If

            'If lStartTime.Minute = 0 Then
            '    cmbCPOLogStartMin.Text = "00"
            'ElseIf lStartTime.Minute = 5 Then
            '    cmbCPOLogStartMin.Text = "05"
            'Else
            '    cmbCPOLogStartMin.Text = lStartTime.Minute
            'End If
            'If lStopTime.Minute = 0 Then
            '    cmbCPOLogStopMin.Text = "00"
            'ElseIf lStopTime.Minute = 5 Then
            '    cmbCPOLogStopMin.Text = "05"
            'Else
            '    cmbCPOLogStopMin.Text = lStopTime.Minute
            'End If

            'btnAddFlag = False


        End If


    End Sub
    Private Sub dgvCPOLogDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPOLogDetails.CellDoubleClick
        ClearShift()
        StartDatefunction()
        StopDatefunction()
        BindDgvCPOLogShiftDetails()
    End Sub
    Private Sub btnPressNoLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPressNoLookup.Click
        PressinfoType = "Line"
        Dim frmPressNo As New PressNoLookup
        frmPressNo.ShowDialog()
        If frmPressNo._lMachineID <> String.Empty Then
            Me.txtPressNo.Text = frmPressNo._lPressNo
            ' If frmPressNo._lCapacity <> 0 Then
            Me.txtCapacity.Text = frmPressNo._lCapacity
            'End If
            lMachineID = frmPressNo._lMachineID
            lblPressNoDescp.Text = frmPressNo._lMachineName
        End If
        PressinfoType = ""
    End Sub

    Private Sub btnAddPressInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPressInfo.Click

        If Me.txtPressNo.Text.Trim = "" Then
            DisplayInfoMessage("Msg93")
            ''MessageBox.Show("This Field Required", "Press No")
            txtPressNo.Focus()
            Exit Sub
        End If
        If Me.txtOPHrs.Text.Trim = "" Then
            DisplayInfoMessage("Msg94")
            ''MessageBox.Show("This Field Required", "Op. Hrs")
            txtOPHrs.Focus()
            Exit Sub
        End If

        If lbtnAddPressInfo <> "Update" Then
            AddMultipleEntryDataPressInfo()
        Else
            UpDateMultipleEntryDataPressInfo()
        End If
        TPH()
    End Sub

    Private Function PressNoExist(ByVal PressNo As String, ByVal Stage As String) As Boolean

        Dim objDataGridViewRow As New DataGridViewRow
        For Each objDataGridViewRow In dgPressInfo.Rows
            If PressNo = objDataGridViewRow.Cells("dgMeMachineID").Value.ToString() And Stage = objDataGridViewRow.Cells("dgMeStage").Value.ToString() Then
                'ddlStage.SelectedIndex = 0
                'ddlStage.Focus()
                txtPressNo.Focus()
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub OPhrsCal()
        If Val(txtMeterFrom.Text) > 0 And Val(txtMeterTo.Text) > 0 Then
            txtOPHrs.Text = Val(txtMeterTo.Text) - Val(txtMeterFrom.Text)
        End If
    End Sub
    Private Sub AddMultipleEntryDataPressInfo()

        Dim intRowcount As Integer = dtPressInfo.Rows.Count
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL





        If Not PressNoExist(lMachineID, ddlStage.Text) Then

            rowMultipleEntryPressInfo = dtPressInfo.NewRow()
            If intRowcount = 0 And lbtnAddPressInfo = "Add" Then
                Try



                    'Add the Data column to the datatable first time 
                    columnPressInfoAdd = New DataColumn("ProductionLogPressID", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("Stage", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("ScrewAge", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("MachineID", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("PressNo", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("PressNoDescp", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("MeterFrom", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("MeterTo", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("OPHrs", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("ScrewStatus", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)
                    columnPressInfoAdd = New DataColumn("Capacity", System.Type.[GetType]("System.String"))
                    dtPressInfo.Columns.Add(columnPressInfoAdd)


                Catch ex As Exception

                End Try

                ' rowMultipleEntryPressInfo("ProductionLogPressID") = lProductionLogPressID
                rowMultipleEntryPressInfo("Stage") = ddlStage.Text
                rowMultipleEntryPressInfo("OPHrs") = txtOPHrs.Text
                If txtCapacity.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("Capacity") = txtCapacity.Text
                End If
                If txtPressNo.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("PressNo") = txtPressNo.Text
                    rowMultipleEntryPressInfo("MachineID") = lMachineID
                    rowMultipleEntryPressInfo("PressNoDescp") = lblPressNoDescp.Text
                End If
                If ddlScrewStatus.Text <> "--End Select--" Then
                    rowMultipleEntryPressInfo("ScrewStatus") = ddlScrewStatus.Text
                End If
                If txtAgeOfScrew.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("ScrewAge") = txtAgeOfScrew.Text
                End If
                If txtMeterFrom.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("MeterFrom") = txtMeterFrom.Text
                End If

                If txtMeterTo.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("MeterTo") = txtMeterTo.Text
                End If

                dtPressInfo.Rows.InsertAt(rowMultipleEntryPressInfo, intRowcount)
                dgPressInfo.AutoGenerateColumns = False


            Else

                ' rowMultipleEntryPressInfo("ProductionLogPressID") = lProductionLogPressID
                rowMultipleEntryPressInfo("Stage") = ddlStage.Text
                rowMultipleEntryPressInfo("OPHrs") = txtOPHrs.Text

                If txtCapacity.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("Capacity") = txtCapacity.Text
                End If
                If txtPressNo.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("PressNo") = txtPressNo.Text
                    rowMultipleEntryPressInfo("MachineID") = lMachineID
                    rowMultipleEntryPressInfo("PressNoDescp") = lblPressNoDescp.Text
                End If
                If ddlScrewStatus.Text <> "--End Select--" Then
                    rowMultipleEntryPressInfo("ScrewStatus") = ddlScrewStatus.Text
                End If
                If txtAgeOfScrew.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("ScrewAge") = txtAgeOfScrew.Text
                End If
                If txtMeterFrom.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("MeterFrom") = txtMeterFrom.Text
                End If

                If txtMeterTo.Text <> String.Empty Then
                    rowMultipleEntryPressInfo("MeterTo") = txtMeterTo.Text
                End If

                dtPressInfo.Rows.InsertAt(rowMultipleEntryPressInfo, intRowcount)
                dgPressInfo.AutoGenerateColumns = False
            End If

            dgPressInfo.DataSource = dtPressInfo
            dgPressInfo.AutoGenerateColumns = False
            ClearLogExpress()
        Else
            DisplayInfoMessage("Msg95")
            '' MsgBox("Line and PressNo Already Exists")
            'ddlStage.Focus()
            txtPressNo.Focus()
        End If


    End Sub

    Private Sub UpDateMultipleEntryDataPressInfo()

        '  Dim intRowcount As Integer = dgPressInfo.Rows.Count
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL




        'If Me.ddlStage.Text = "--End Select--" Then
        '    MessageBox.Show("This Field Required", "Stage")
        '    ddlStage.Focus()
        '    Exit Sub
        'End If
        'If Me.txtOPHrs.Text = "" Then
        '    MessageBox.Show("This Field Required", "OP Hrs")
        '    txtOPHrs.Focus()
        '    Exit Sub
        'End If


        If lPress = lMachineID And lstage = ddlStage.Text Then
            Dim intCount As Integer = dgPressInfo.CurrentRow.Index

            If lProductionLogPressID <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeProductionLogPressID").Value = lProductionLogPressID
            End If


            dgPressInfo.Rows(intCount).Cells("dgMeOPHrs").Value = txtOPHrs.Text
            dgPressInfo.Rows(intCount).Cells("dgMeStage").Value = ddlStage.Text
            If txtPressNo.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMePressNo").Value = txtPressNo.Text
                dgPressInfo.Rows(intCount).Cells("dgMeMachineID").Value = lMachineID
                dgPressInfo.Rows(intCount).Cells("dgMePressNoDescp").Value = lblPressNoDescp.Text
            End If
            If txtCapacity.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeCapacity").Value = txtCapacity.Text
            End If

            If ddlScrewStatus.Text <> "--End Select--" Then
                dgPressInfo.Rows(intCount).Cells("dgMeScrewStatus").Value = ddlScrewStatus.Text
            End If
            If txtAgeOfScrew.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeScrewAge").Value = txtAgeOfScrew.Text
            End If
            If txtMeterFrom.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeMeterFrom").Value = txtMeterFrom.Text
            End If

            If txtMeterTo.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeMeterTo").Value = txtMeterTo.Text
            End If
            ClearLogExpress()
        ElseIf Not PressNoExist(lMachineID, ddlStage.Text) Then
            Dim intCount As Integer = dgPressInfo.CurrentRow.Index

            If lProductionLogPressID <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeProductionLogPressID").Value = lProductionLogPressID
            End If


            dgPressInfo.Rows(intCount).Cells("dgMeOPHrs").Value = txtOPHrs.Text
            dgPressInfo.Rows(intCount).Cells("dgMeStage").Value = ddlStage.Text
            If txtPressNo.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMePressNo").Value = txtPressNo.Text
                dgPressInfo.Rows(intCount).Cells("dgMeMachineID").Value = lMachineID
                dgPressInfo.Rows(intCount).Cells("dgMePressNoDescp").Value = lblPressNoDescp.Text
            End If
            If txtCapacity.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeCapacity").Value = txtCapacity.Text
            End If
            If ddlScrewStatus.Text <> "--End Select--" Then
                dgPressInfo.Rows(intCount).Cells("dgMeScrewStatus").Value = ddlScrewStatus.Text
            End If
            If txtAgeOfScrew.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeScrewAge").Value = txtAgeOfScrew.Text
            End If
            If txtMeterFrom.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeMeterFrom").Value = txtMeterFrom.Text
            End If

            If txtMeterTo.Text <> String.Empty Then
                dgPressInfo.Rows(intCount).Cells("dgMeMeterTo").Value = txtMeterTo.Text
            End If

            ClearLogExpress()
        Else
            DisplayInfoMessage("Msg95")
            ''MsgBox("Line and Press No Already Exists")
            ddlStage.Focus()
        End If

    End Sub
    Private Sub ClearLogExpress()
        ddlStage.SelectedIndex = 0
        txtOPHrs.Text = String.Empty
        txtCapacity.Text = String.Empty
        txtAgeOfScrew.Text = String.Empty
        txtMeterFrom.Text = String.Empty
        ddlScrewStatus.SelectedIndex = 0
        txtPressNo.Text = String.Empty
        txtMeterTo.Text = String.Empty
        lblPressNoDescp.Text = String.Empty
        lMachineID = String.Empty
        lbtnAddPressInfo = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAddPressInfo.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddPressInfo.Text = "Menambahkan"
        End If

        ''btnAddPressInfo.Text = "Add"
        PrevStage1TPH = "00:00"
        PrevStage2TPH = "00:00"

    End Sub

    Private Sub btnResetPressinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPressinfo.Click
        ClearLogExpress()
        ddlStage.Focus()
    End Sub

    Private Sub txtAgeOfScrew_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAgeOfScrew.KeyDown
        'KeyDown2Decimal(sender, e)
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


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal) Then
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

    Private Sub txtAgeOfScrew_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgeOfScrew.KeyPress
        'KeyPress2Decimal(sender, e)
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

    Private Sub txtPressNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPressNo.KeyDown
        '  KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtOPHrs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtOPHrs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMeterFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeterFrom.KeyDown

    End Sub

    Private Sub txtMeterFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeterFrom.KeyPress

    End Sub

    Private Sub txtCapacity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCapacity.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtCapacity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapacity.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMeterTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeterTo.KeyDown
    End Sub

    Private Sub txtMeterTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeterTo.KeyPress
    End Sub

    Private Sub txtPressNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressNo.Leave
        If txtPressNo.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            objPKOProductionLogPPT.PressNo = txtPressNo.Text.Trim()
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            ds = PKOProductionLogBOL.GetProductionPKOlogPressNo(objPKOProductionLogPPT, "YES", "Line")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg96")
                ''MessageBox.Show("Invalid Press No,Please Choose it from look up")
                txtPressNo.Text = String.Empty
                txtCapacity.Text = String.Empty
                lblPressNoDescp.Text = String.Empty
                lMachineID = String.Empty
                txtPressNo.Focus()
                Exit Sub
            Else

                If ds.Tables(0).Rows(0).Item("MachineCode").ToString() <> String.Empty Then
                    txtPressNo.Text = ds.Tables(0).Rows(0).Item("MachineCode")
                End If
                If ds.Tables(0).Rows(0).Item("MachineID").ToString() <> String.Empty Then
                    lMachineID = ds.Tables(0).Rows(0).Item("MachineID")
                End If
                If ds.Tables(0).Rows(0).Item("MachineName").ToString() <> String.Empty Then
                    lblPressNoDescp.Text = ds.Tables(0).Rows(0).Item("MachineName")
                End If
                If ds.Tables(0).Rows(0).Item("Capacity").ToString() <> String.Empty Then
                    txtCapacity.Text = ds.Tables(0).Rows(0).Item("Capacity")
                End If
            End If
        Else
            txtPressNo.Text = String.Empty
            txtCapacity.Text = String.Empty
            lblPressNoDescp.Text = String.Empty
            lMachineID = String.Empty
        End If
    End Sub

    Private Sub txtTotalHoursPress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalHoursPress.TextChanged
        Dim lTotalOPHrs As Decimal
        If txtTotalHoursPress.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTotalHoursPress.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTotalOPHrs = Hrs + lmin


        End If

        If txtProcessedFFBToday.Text <> String.Empty And lTotalOPHrs > 0 Then
            txtAvgPressThroughput.Text = Math.Round(Val(txtProcessedFFBToday.Text) / lTotalOPHrs, 2)
        Else
            txtAvgPressThroughput.Text = ""
        End If

        If txtProcessedFFBToday.Text <> String.Empty Then
            txtCakeProcess.Text = Val(txtProcessedFFBToday.Text) - Val(txtKernalProduction.Text)
        Else
            txtCakeProcess.Text = ""
        End If

        If Convert.ToString(lTotalOPHoursStage1) <> "" And lTotalOPHoursStage1 <> "00:00" Then
            txtTPHTodaystage1.Text = Convert.ToString(lTotalOPHoursStage1)
        Else
            txtTPHTodaystage1.Text = ""
        End If

        If Convert.ToString(lTotalOPHoursStage2) <> "" And lTotalOPHoursStage2 <> "00:00" Then
            txtStage2TodayTPH.Text = Convert.ToString(lTotalOPHoursStage2)
        Else
            txtStage2TodayTPH.Text = ""
        End If





    End Sub

    Private Sub txtTPHMonthTodateStage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTPHMonthTodateStage1.Leave
        If txtTPHMonthTodateStage1.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg97")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtTPHMonthTodateStage1.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Hrs cant be greater than  24")
            '    txtTPHMonthTodateStage1.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg97")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg98")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtTPHMonthTodateStage1.Text = Hrs + ":" + Min
        End If
        summCalcMonthStage1()
        'If txtTPHYearTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "" Then

        '    Dim strTotal As String
        '    Dim strArrTotal() As String
        '    strTotal = txtTPHYearTodateStage1.Text
        '    strArrTotal = strTotal.Split(":")
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = txtTPHMonthTodateStage1.Text
        '    strArr = str.Split(":")

        '    'If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
        '    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
        '        MessageBox.Show("Month To Date Hrs cant be lesser than Year To Date Hrs")
        '        ' txtTPHMonthTodateStage1.Focus()
        '        Exit Sub
        '    End If
        'End If
        If txtTPHMonthTodateStage1.Text <> "" And txtTPHTodaystage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg99")
                ''MessageBox.Show("Press Info Line 1 Month To Date Hrs cant be lesser than Press Info Line 1 Total Hrs")
                ' txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
        If txtTPHYearTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtTPHMonthTodateStage1.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg100")
                ''MessageBox.Show("Press Info Line 1 Year To Date Hrs cant be lesser than Press Info Line 1 Month To Date Hrs")
                '  txtMonthTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtTPHMonthTodateStage1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHMonthTodateStage1.TextChanged

        If txtTPHMonthTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Enabled = True Then
            Dim Value As String = txtTPHMonthTodateStage1.Text
            Dim strlen As Integer
            strlen = Len(txtTPHMonthTodateStage1.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtTPHMonthTodateStage1.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtTPHMonthTodateStage1.Focus()
                End If
            Next
            'If Val(txtTPHMonthTodateStage1.Text) >= 744 Then
            '    DisplayInfoMessage("Msg120")
            '    '  MsgBox("Month To date Hrs cant be greater than 744 hrs")
            '    txtTPHMonthTodateStage1.Focus()
            'End If

        End If

        If txtTPHMonthTodateStage1.Text = "" Then
            txtAPHstage1monthtodate.Text = ""
            txtutilstage1monthtodate.Text = ""
        End If
        If MonthCount >= 1 Then
            If txtTPHMonthTodateStage1.Enabled = False Then
                summCalcMonthStage1()
            End If
        End If
        If MonthCount <= 1 And txtTPHMonthTodateStage1.Text = "00:00" Then
            txtTPHMonthTodateStage1.Text = ""
        End If
    End Sub
    Private Sub summCalcMonthStage2()
        Dim lTPHMonthTodatestage2, lMonthTodateHrs As Decimal
        If txtStage2monthTodate.Text <> "00:00" And txtStage2monthTodate.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHMonthTodatestage2 = Hrs + lmin

        End If
        If txtEPHrsMonth.Text <> "00:00" And txtEPHrsMonth.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEPHrsMonth.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lMonthTodateHrs = Hrs + lmin

        End If

        If Val(txtFFBMonth.Text) <> 0 And lTPHMonthTodatestage2 > 0 Then
            txtAPTstage2monthtodae.Text = Math.Round(Val(txtFFBMonth.Text) / lTPHMonthTodatestage2, 2)
        Else
            txtAPTstage2monthtodae.Text = ""
        End If
        If lMonthTodateHrs > 0 And lTPHMonthTodatestage2 > 0 Then
            If ToCaculateTotalPress("Line 2") <> 0 Then
                txtutilstage2monthtodate.Text = Math.Round(lTPHMonthTodatestage2 * 100 / (lMonthTodateHrs * (ToCaculateTotalPress("Line 2") + lstageCountMonth)), 2)
            ElseIf lstageCountMonth <> 0 Then
                txtutilstage2monthtodate.Text = Math.Round(lTPHMonthTodatestage2 * 100 / (lMonthTodateHrs * lstageCountMonth), 2)
            End If
        Else
            txtutilstage2monthtodate.Text = ""
        End If
    End Sub
    Private Sub summCalcMonthStage1()
        Dim lTPHMonthTodateStage1, lMonthTodateHrs As Decimal
        If txtTPHMonthTodateStage1.Text <> "00:00" And txtTPHMonthTodateStage1.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHMonthTodateStage1 = Hrs + lmin

        End If
        If txtEPHrsMonth.Text <> "00:00" And txtEPHrsMonth.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEPHrsMonth.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lMonthTodateHrs = Hrs + lmin

        End If
        'If lTotalOPHoursMonth = "00:00" Then
        '    lTotalOPHoursMonth = txtTotalHoursPress.Text
        'End If
        'If lTotalOPHoursMonth <> "00:00" And lTotalOPHoursMonth <> "" Then
        '    Dim Hrs As Integer
        '    Dim Min As Integer
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = lTotalOPHoursMonth
        '    strArr = str.Split(":")
        '    Hrs = strArr(0)
        '    Min = strArr(1)

        '    Min = (Min / 60) *100
        '    Dim lmin As String
        '    lmin = "." + Convert.ToString(Min)

        '    llTotalOPHoursMonth = Hrs + lmin

        'End If
        If Val(txtFFBMonth.Text) <> 0 And lTPHMonthTodateStage1 > 0 Then
            txtAPHstage1monthtodate.Text = Math.Round(Val(txtFFBMonth.Text) / lTPHMonthTodateStage1, 2)
        Else
            txtAPHstage1monthtodate.Text = ""
        End If
        If lMonthTodateHrs > 0 And lTPHMonthTodateStage1 > 0 Then
            If ToCaculateTotalPress("Line 1") <> 0 Then
                txtutilstage1monthtodate.Text = Math.Round(lTPHMonthTodateStage1 * 100 / (lMonthTodateHrs * (ToCaculateTotalPress("Line 1") + lstageCountMonth)), 2)
            ElseIf lstageCountMonth <> 0 Then
                txtutilstage1monthtodate.Text = Math.Round(lTPHMonthTodateStage1 * 100 / (lMonthTodateHrs * lstageCountMonth), 2)
            End If
                 Else
            txtutilstage1monthtodate.Text = ""
        End If
    End Sub

    Private Sub txtStage2monthTodate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStage2monthTodate.Leave
        If txtStage2monthTodate.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg67")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtStage2monthTodate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtStage2monthTodate.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg67")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg68")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg69")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg70")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtStage2monthTodate.Text = Hrs + ":" + Min

        End If
        'If txtStage2yearTodate.Text <> "" And txtStage2monthTodate.Text <> "" Then

        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = txtStage2yearTodate.Text
        '    strArr = str.Split(":")

        '    Dim strTotal As String
        '    Dim strArrTotal() As String
        '    strTotal = txtStage2monthTodate.Text
        '    strArrTotal = strTotal.Split(":")

        '    'If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
        '    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
        '        MessageBox.Show("Month To Date Hrs cant be lesser than Year To Date Hrs")
        '        txtStage2monthTodate.Focus()
        '        Exit Sub
        '    End If


        'End If
        summCalcMonthStage2()
        If txtStage2monthTodate.Text <> "" And txtStage2TodayTPH.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg101")
                ''MessageBox.Show("Press Info Line 2 Month To Date Hrs cant be lesser than Press Info Line 2 Total Hrs")
                ' txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
        If txtStage2yearTodate.Text <> "" And txtStage2monthTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtStage2monthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg102")
                ''MessageBox.Show("Press Info Line 2 Year To Date Hrs cant be lesser than Press Info Line 2 Month To Date Hrs")
                '  txtMonthTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtStage2monthTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2monthTodate.TextChanged

        If txtStage2monthTodate.Text <> "" And txtStage2monthTodate.Enabled = True Then
            Dim Value As String = txtStage2monthTodate.Text
            Dim strlen As Integer
            strlen = Len(txtStage2monthTodate.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStage2monthTodate.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtStage2monthTodate.Focus()
                End If
            Next

            'If Val(txtStage2monthTodate.Text) >= 744 Then
            '    DisplayInfoMessage("Msg120")
            '    '  MsgBox("Month To date Hrs cant be greater than 744 hrs")
            '    txtStage2monthTodate.Focus()
            'End If
        End If
        If txtStage2monthTodate.Text = "" Then
            txtAPTstage2monthtodae.Text = ""
            txtutilstage2monthtodate.Text = ""
        End If
        If MonthCount >= 1 Then
            If txtTPHMonthTodateStage1.Enabled = False Then
                summCalcMonthStage2()
            End If
        End If
        If MonthCount <= 1 And txtStage2monthTodate.Text = "00:00" Then
            txtStage2monthTodate.Text = ""
        End If

    End Sub

    Private Sub GetTPHMonth()

        'Dim objPKOProductionLogPPT As New CPOProductionLogPPT
        'Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        'Dim dsTPH As New DataSet
        'objPKOProductionLogPPT.ProductionLogDate = dtpCPOLogDate.Value

        'dsTPH = CPOProductionLogBOL.GetCPOProductionLogPressMonthValue(objPKOProductionLogPPT)

        'If dsTPH.Tables(2).Rows.Count <> 0 And dsTPH IsNot Nothing Then
        '    txtTPHMonthTodateStage1.Text = dsTPH.Tables(2).Rows(0).Item("MonthValuesHrsstage1").ToString
        'Else
        '    txtTPHMonthTodateStage1.Text = ""
        'End If
        'If dsTPH.Tables(5).Rows.Count <> 0 And dsTPH IsNot Nothing Then
        '    txtStage2monthTodate.Text = dsTPH.Tables(5).Rows(0).Item("MonthValuesHrsstage2").ToString
        'Else
        '    txtStage2monthTodate.Text = ""
        'End If

    End Sub

    Private Sub GetTPHYear()

        'Dim objCPOProductionLogPPT As New CPOProductionLogPPT
        'Dim objCPOOProductionLogBOL As New CPOProductionLogBOL
        'Dim dsTPH As New DataSet
        'objCPOProductionLogPPT.ProductionLogDate = dtpCPOLogDate.Value

        'dsTPH = CPOProductionLogBOL.GetCPOProductionLogPressYearValue(objCPOProductionLogPPT)

        'If dsTPH.Tables(3).Rows.Count <> 0 And dsTPH IsNot Nothing Then
        '    txtTPHYearTodateStage1.Text = dsTPH.Tables(3).Rows(0).Item("yearValuesHrsstage1").ToString
        'Else
        '    txtTPHYearTodateStage1.Text = ""
        'End If
        'If dsTPH.Tables(6).Rows.Count <> 0 And dsTPH IsNot Nothing Then
        '    txtStage2yearTodate.Text = dsTPH.Tables(6).Rows(0).Item("yearValuesHrsstage2").ToString
        'Else
        '    txtStage2yearTodate.Text = ""
        'End If


    End Sub
    Private Sub GetCPOProductionTodayValues()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        Dim ds As New DataSet
        Dim dsToday As New DataSet
        objPKOProductionLogPPT.ProductionLogDate = dtpCPOLogDate.Value

        ' ds = PKOProductionLogBOL.GetPKOProductionlogPKOMonthYearValue(objPKOProductionLogPPT)
        dsToday = PKOProductionLogBOL.GetPKOProductionlogPKOTodayValue(objPKOProductionLogPPT)
        If dsToday.Tables(0).Rows.Count <> 0 And dsToday IsNot Nothing Then
            If Not dsToday.Tables(0).Rows(0).Item("QtyToday") Is DBNull.Value Then
                lCPOProductionToday = dsToday.Tables(0).Rows(0).Item("QtyToday")
            End If
        Else
            lCPOProductionToday = 0.0
        End If
        'If ds.Tables(0).Rows.Count <> 0 And ds IsNot Nothing Then
        '    If Not ds.Tables(0).Rows(0).Item("QtyMonthToDate") Is DBNull.Value Then
        '        txtPKOProductionMonthTodate.Text = ds.Tables(0).Rows(0).Item("QtyMonthToDate").ToString
        '        txtPKOProductionYear.Text = ds.Tables(0).Rows(0).Item("QtyYearToDate").ToString
        '     If

        'Else
        '    txtPKOProductionMonthTodate.Text = "0"
        '    txtPKOProductionYear.Text = "0"
        ' If

    End Sub
    Private Sub txtStage2yearTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2yearTodate.TextChanged
        If txtStage2yearTodate.Text <> "" And txtStage2yearTodate.Enabled = True Then
            Dim Value As String = txtStage2yearTodate.Text
            Dim strlen As Integer
            strlen = Len(txtStage2yearTodate.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStage2yearTodate.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtStage2yearTodate.Focus()
                End If
            Next
            If Val(txtStage2yearTodate.Text) >= 8760 Then
                DisplayInfoMessage("Msg121")
                txtStage2yearTodate.Focus()
            End If



        End If
        If txtStage2yearTodate.Text = "" Then
            txtAPTStage2yeartodate.Text = ""
            txtutilstage2yeartodate.Text = ""
        End If
        If YearCount >= 1 Then
            If txtStage2yearTodate.Enabled = False Then
                SummCalcstage2Year()
            End If
        End If
        If MonthCount <= 1 And txtStage2yearTodate.Text = "00:00" Then
            txtStage2yearTodate.Text = ""
        End If
    End Sub
    Private Sub SummCalcstage1Year()
        Dim lTPHYearTodateStage1, lYearTodateHrs As Decimal
        If txtTPHYearTodateStage1.Text <> "00:00" And txtTPHYearTodateStage1.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHYearTodateStage1 = Hrs + lmin

        End If
        If txtEPHrsYear.Text <> "00:00" And txtEPHrsYear.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEPHrsYear.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lYearTodateHrs = Hrs + lmin

        End If
        'If lTotalOPHoursYear = "00:00" Then
        '    lTotalOPHoursYear = txtTotalHoursPress.Text
        'End If

        'If lTotalOPHoursYear <> "00:00" And lTotalOPHoursYear <> "" Then
        '    Dim Hrs As Integer
        '    Dim Min As Integer
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = lTotalOPHoursYear
        '    strArr = str.Split(":")
        '    Hrs = strArr(0)
        '    Min = strArr(1)

        '    Min = (Min / 60) *100
        '    Dim lmin As String
        '    lmin = "." + Convert.ToString(Min)

        '    llTotalOPHoursYear = Hrs + lmin

        'End If
        If Val(txtFFBYear.Text) <> 0 And lTPHYearTodateStage1 > 0 Then
            txtAPTstage1yeartodate.Text = Math.Round(Val(txtFFBYear.Text) / lTPHYearTodateStage1, 2)
        Else
            txtAPTstage1yeartodate.Text = ""
        End If
        If lYearTodateHrs > 0 And lTPHYearTodateStage1 > 0 Then
            If ToCaculateTotalPress("Line 1") <> 0 Then
                txtutilstage1yeartodate.Text = Math.Round(lTPHYearTodateStage1 * 100 / (lYearTodateHrs * (ToCaculateTotalPress("Line 1") + lstageCountYear)), 2)
            ElseIf lstageCountYear <> 0 Then
                txtutilstage1yeartodate.Text = Math.Round(lTPHYearTodateStage1 * 100 / (lYearTodateHrs * lstageCountYear), 2)
            End If
        Else
            txtutilstage1yeartodate.Text = ""
        End If
    End Sub
    Private Sub SummCalcstage2Year()
        Dim lTPHYearTodatestage2, lYearTodateHrs As Decimal
        If txtStage2yearTodate.Text <> "00:00" And txtStage2yearTodate.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHYearTodatestage2 = Hrs + lmin

        End If
        If txtEPHrsYear.Text <> "00:00" And txtEPHrsYear.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEPHrsYear.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lYearTodateHrs = Hrs + lmin

        End If
        'If lTotalOPHoursYear <> "00:00" And lTotalOPHoursYear <> "" Then
        '    Dim Hrs As Integer
        '    Dim Min As Integer
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = lTotalOPHoursYear
        '    strArr = str.Split(":")
        '    Hrs = strArr(0)
        '    Min = strArr(1)

        '    Min = (Min / 60) *100
        '    Dim lmin As String
        '    lmin = "." + Convert.ToString(Min)

        '    llTotalOPHoursYear = Hrs + lmin

        'End If
        If Val(txtFFBYear.Text) <> 0 And lTPHYearTodatestage2 > 0 Then
            txtAPTStage2yeartodate.Text = Math.Round(Val(txtFFBYear.Text) / lTPHYearTodatestage2, 2)
        Else
            txtAPTStage2yeartodate.Text = ""
        End If
        If lYearTodateHrs > 0 And lTPHYearTodatestage2 > 0 Then
            If ToCaculateTotalPress("Line 2") <> 0 Then
                txtutilstage2yeartodate.Text = Math.Round(lTPHYearTodatestage2 * 100 / (lYearTodateHrs * (ToCaculateTotalPress("Line 2") + lstageCountYear)), 2)
            ElseIf lstageCountYear <> 0 Then
                txtutilstage2yeartodate.Text = Math.Round(lTPHYearTodatestage2 * 100 / (lYearTodateHrs * lstageCountYear), 2)
            End If
        Else
            txtutilstage2yeartodate.Text = ""
        End If
    End Sub

    Private Sub GetPKOProductionLogPressOPHrsValue()


        Dim objppt As New CPOProductionLogPPT
        Dim ObjBOL As New CPOProductionLogBOL

        Dim ds As New DataSet
        objppt.ProductionLogDate = dtpCPOLogDate.Value
        ds = CPOProductionLogBOL.GetPKOProductionLogPressOPHrsValue(objppt)


        If ds.Tables(2).Rows.Count <> 0 And ds IsNot Nothing Then
            If Not ds.Tables(2).Rows(0).Item("MonthValuesOPPressHrs") Is DBNull.Value Then
                lTotalOPHoursMonth = ds.Tables(2).Rows(0).Item("MonthValuesOPPressHrs").ToString
            End If

            If Not ds.Tables(5).Rows(0).Item("YearValuesOPPressHrs") Is DBNull.Value Then
                lTotalOPHoursYear = ds.Tables(5).Rows(0).Item("YearValuesOPPressHrs").ToString
            End If
        End If


    End Sub

    Private Sub txtTPHYearTodateStage1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHYearTodateStage1.TextChanged
        If txtTPHYearTodateStage1.Text <> "" And txtTPHYearTodateStage1.Enabled = True Then
            Dim Value As String = txtTPHYearTodateStage1.Text
            Dim strlen As Integer
            strlen = Len(txtTPHYearTodateStage1.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtTPHYearTodateStage1.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtTPHYearTodateStage1.Focus()
                End If
            Next

            If Val(txtTPHYearTodateStage1.Text) >= 8760 Then
                DisplayInfoMessage("Msg121")
                txtTPHYearTodateStage1.Focus()
            End If

        End If
        If txtTPHYearTodateStage1.Text = "" Then
            txtAPTstage1yeartodate.Text = ""
            txtutilstage1yeartodate.Text = ""
        End If
        If YearCount >= 1 Then
            If txtTPHYearTodateStage1.Enabled = False Then
                SummCalcstage1Year()
            End If
        End If
        If MonthCount <= 1 And txtTPHYearTodateStage1.Text = "00:00" Then
            txtTPHYearTodateStage1.Text = ""
        End If

    End Sub


    Private Sub cmbCPOLogStartMin_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindTotalhrs()
    End Sub

    Private Sub cmbCPOLogStopMin_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindTotalhrs()
    End Sub

    Private Sub cmbCPOLogStartHrs_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindTotalhrs()
    End Sub

    Private Sub cmbCPOLogStopHrs_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindTotalhrs()
    End Sub
    Private Sub ClearShift()
        cboShift.SelectedIndex = 0
        txtAssistant.Text = String.Empty
        txtMandor.Text = String.Empty
        txtFFBProcessed.Text = String.Empty
        txtLorryProcessed.Text = String.Empty
        txtShiftHrs.Text = String.Empty
        txtStartTime.Text = String.Empty
        txtStopTime.Text = String.Empty
        txtTotalBrkdown.Text = String.Empty
        lbtnAddShift = "Add"
        btnAddFlag = True
        If GlobalPPT.strLang = "en" Then
            btnAddShift.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddShift.Text = "Menambahkan"
        End If
        ''btnAddShift.Text = "Add"
    End Sub

    Private Sub btnResetShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetShift.Click
        ClearShift()
        StartDatefunction()
        StopDatefunction()
        cboShift.Focus()
    End Sub
    Private Sub MultipleDateEntryValuesPressInfo()

        If dgPressInfo.RowCount > 0 Then



            ClearLogExpress()
            If GlobalPPT.strLang = "en" Then
                btnAddPressInfo.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddPressInfo.Text = "Memperbarui"
            End If

            ''btnAddPressInfo.Text = "Update"
            lbtnAddPressInfo = "Update"
            If dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value IsNot Nothing Then 'Or dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value.ToString <> String.Empty Then
                Me.lProductionLogPressID = dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value.ToString
            Else
                lProductionLogPressID = Nothing
            End If


            Me.ddlStage.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeStage").Value.ToString
            lstage = Me.dgPressInfo.SelectedRows(0).Cells("dgMeStage").Value.ToString

            txtPressNo.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMePressNo").Value.ToString
            lPress = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMachineID").Value.ToString
            txtAgeOfScrew.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeScrewAge").Value.ToString
            lMachineID = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMachineID").Value.ToString
            txtCapacity.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeCapacity").Value.ToString
            lblPressNoDescp.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMePressNoDescp").Value.ToString
            txtOPHrs.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeOPHrs").Value.ToString

            If Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterFrom").Value.ToString <> String.Empty Then
                txtMeterFrom.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterFrom").Value.ToString
            End If

            If Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterTo").Value.ToString <> String.Empty Then
                txtMeterTo.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterTo").Value.ToString
            End If
            If Me.dgPressInfo.SelectedRows(0).Cells("dgMeScrewStatus").Value.ToString <> "--End Select--" Then
                ddlScrewStatus.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeScrewStatus").Value.ToString
            End If

        End If

    End Sub

    Private Sub dgPressInfo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPressInfo.CellDoubleClick
        ClearLogExpress()
        MultipleDateEntryValuesPressInfo()
    End Sub
    Private Sub txtFFbNoOfLorry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFFbNoOfLorry.TextChanged
        ''''For UnBalanced FFB 


    End Sub

    Private Sub txtMeterFrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeterFrom.Leave
        If txtMeterFrom.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMeterFrom.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg65")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMeterFrom.Focus()
                Exit Sub
            End If

            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg65")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMeterFrom.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg65")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMeterFrom.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg69")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMeterFrom.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg70")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMeterFrom.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg105")
                    '' MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtMeterFrom.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMeterFrom.Text = Hrs + ":" + Min
        End If

        If txtMeterFrom.Text <> String.Empty And txtMeterTo.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMeterTo.Text
            strArr = Str.Split(":")
            Str1 = txtMeterFrom.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr(0)) - CInt(strArr1(0))
            lmin = CInt(strArr(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
            'lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

            'If lmin2 < 0 Then
            '    lmin2 = lmin2 + 60
            '    Lhrs2 = Lhrs2 - 1
            'End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs > 24 Then
                DisplayInfoMessage("Msg103")
                '' MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterFrom.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg103")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterFrom.Focus()
            ElseIf Lhrs < 0 Then
                DisplayInfoMessage("Msg104")
                '' MsgBox("Meter To Value should be greater than Meter From")
                txtOPHrs.Text = ""
                txtMeterFrom.Focus()
            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtOPHrs.Text = Strhrs + ":" + StrMin
            End If
        Else
            txtOPHrs.Text = "00:00"

        End If
    End Sub

    Private Sub txtMeterFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterFrom.TextChanged
        If txtMeterFrom.Text <> "" Then
            Dim Value As String = txtMeterFrom.Text
            Dim strlen As Integer
            strlen = Len(txtMeterFrom.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMeterFrom.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter Numeric Values only")
                    txtMeterFrom.Focus()
                End If
            Next
        End If



    End Sub

    Private Sub txtMeterTo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeterTo.Leave
        If txtMeterTo.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMeterTo.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg74")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMeterTo.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg74")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMeterTo.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg74")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMeterTo.Focus()
                    Exit Sub
                End If



                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMeterTo.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMeterTo.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg105")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtMeterTo.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMeterTo.Text = Hrs + ":" + Min
        End If

        If txtMeterFrom.Text <> String.Empty And txtMeterTo.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMeterTo.Text
            strArr = Str.Split(":")
            Str1 = txtMeterFrom.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr(0)) - CInt(strArr1(0))
            lmin = CInt(strArr(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
            'lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

            'If lmin2 < 0 Then
            '    lmin2 = lmin2 + 60
            '    Lhrs2 = Lhrs2 - 1
            'End If
            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs > 24 Then
                DisplayInfoMessage("Msg103")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterTo.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg103")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterTo.Focus()
            ElseIf Lhrs < 0 Then
                DisplayInfoMessage("Msg104")
                ''MsgBox("Meter To Value should be greater than Meter From")
                txtOPHrs.Text = ""
                txtMeterTo.Focus()
            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtOPHrs.Text = Strhrs + ":" + StrMin
            End If
        Else
            txtOPHrs.Text = "00:00"

        End If
    End Sub

    Private Sub txtMeterTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterTo.TextChanged
        If txtMeterTo.Text <> "" Then
            Dim Value As String = txtMeterTo.Text
            Dim strlen As Integer
            strlen = Len(txtMeterTo.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMeterTo.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please Enter numeric values only")
                    txtMeterTo.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtProcessedFFB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessedFFBToday.TextChanged
        BalanceCFCalculation()
        If txtProcessedFFBToday.Text <> "" Then
            txtFFBToday.Text = txtProcessedFFBToday.Text
        Else
            txtFFBToday.Text = ""
        End If

        Dim lTotalOPHrs, lTPHTodaystage1, lTPHTodaystage2 As Decimal
        If txtTotalHoursPress.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTotalHoursPress.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTotalOPHrs = Hrs + lmin


        End If

        If txtProcessedFFBToday.Text <> String.Empty And lTotalOPHrs > 0 Then
            txtAvgPressThroughput.Text = Math.Round(Val(txtProcessedFFBToday.Text) / lTotalOPHrs, 2)
        Else
            txtAvgPressThroughput.Text = ""
        End If

        If dgPressInfo.RowCount > 0 Then

            If Convert.ToString(lTotalOPHoursStage1) <> "" And lTotalOPHoursStage1 <> "00:00" Then
                txtTPHTodaystage1.Text = Convert.ToString(lTotalOPHoursStage1)
            Else
                txtTPHTodaystage1.Text = ""
            End If

            If Convert.ToString(lTotalOPHoursStage2) <> "" And lTotalOPHoursStage2 <> "00:00" Then
                txtStage2TodayTPH.Text = Convert.ToString(lTotalOPHoursStage2)
            Else
                txtStage2TodayTPH.Text = ""
            End If

            If txtTPHTodaystage1.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtTPHTodaystage1.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTPHTodaystage1 = Hrs + lmin
            End If
            If txtStage2TodayTPH.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtStage2TodayTPH.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTPHTodaystage2 = Hrs + lmin
            End If

            If Val(txtProcessedFFBToday.Text) <> 0 And lTPHTodaystage1 > 0 Then
                txtAPTstage1today.Text = Math.Round(Val(txtProcessedFFBToday.Text) / lTPHTodaystage1, 2)
            Else
                txtAPTstage1today.Text = ""
            End If
            If Val(txtProcessedFFBToday.Text) <> 0 And lTPHTodaystage2 > 0 Then
                txtAPTstage2today.Text = Math.Round(Val(txtProcessedFFBToday.Text) / lTPHTodaystage2, 2)
            Else
                txtAPTstage2today.Text = ""
            End If
            If txtEPHrsToday.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtEPHrsToday.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTotalHrs = Hrs + lmin


            End If
            If txtTotalHoursPress.Text <> String.Empty And lTotalHrs > 0 And lTPHTodaystage1 > 0 And lTotalOPHrs > 0 Then
                txtutilstage1today.Text = Math.Round(lTotalOPHrs * 100 / (lTotalHrs * lTPHTodaystage1), 2)
            Else
                txtutilstage1today.Text = ""
            End If

            If txtTotalHoursPress.Text <> String.Empty And lTotalHrs > 0 And lTotalOPHrs > 0 And lTPHTodaystage2 > 0 Then
                txtutilstage2.Text = Math.Round(lTotalOPHrs * 100 / (lTotalHrs * lTPHTodaystage2), 2)
            Else
                txtutilstage2.Text = ""
            End If

        End If
    End Sub

    Private Sub txtFFBMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBMonth.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtFFBMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBMonth.TextChanged
        AvgLorrywtCalc()
        If txtFFBMonth.Enabled = False Then
            txtFFBMonth.Text = Format(Val(txtFFBMonth.Text), "0.000")
        End If
        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            str3 = txtEPHrsMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtMonthTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1
        ElseIf lmonthValuehrs <> "" And lmonthValuehrs <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = lmonthValuehrs
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1

        End If

        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpMonth.Text = ""
        End If


        If Val(txtFFBMonth.Text) <> 0 And lTotalHrsDec > 0 Then
            txtAvgTpMonth.Text = Math.Round(Val(txtFFBMonth.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpMonth.Text = ""
        End If


        If Val(txtFFBMonth.Text) <> 0 And lCPOMonth <> 0 Then
            'txtOERMonth.Text = Math.Round(lCPOMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)
            txtOERMonth.Text = Math.Round(lCPOMonth * 100 / (Val(txtFFBMonth.Text)), 2)
        Else
            txtOERMonth.Text = ""
        End If

        If Val(txtFFBMonth.Text) <> 0 And lKernelMonth <> 0 Then
            'txtKERMonth.Text = Math.Round(lKernelMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)
            txtKERMonth.Text = Math.Round(lKernelMonth * 100 / Val(txtFFBMonth.Text), 2)
        Else
            txtKERMonth.Text = ""
        End If

    End Sub

   

    Private Sub txtFFBYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBYear.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtFFBYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBYear.TextChanged
        AvgLorrywtCalc()
        CPOGetMonthYearQty()
        If txtFFBYear.Enabled = False Then
            txtFFBYear.Text = Format(Val(txtFFBYear.Text), "0.000")
        End If
        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtYearTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1
        ElseIf lYearValue <> "" And lYearValue <> "00:00" Then
            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = lYearValue
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpYear.Text = ""
        End If


        If Val(txtFFBYear.Text) <> 0 And lTotalHrsDec > 0 Then
            txtAvgTpYear.Text = Math.Round(Val(txtFFBYear.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpYear.Text = ""
        End If


        CPOGetMonthYearOER()

        If Val(txtFFBYear.Text) <> 0 And lCPOYear <> 0 Then
            txtOERYear.Text = Math.Round(lCPOYear * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text)), 2)

        Else
            txtOERYear.Text = ""
        End If
        CPOGetMonthYearKER()

        If Val(txtFFBYear.Text) <> 0 And lKernelYear <> 0 Then
            txtKERYear.Text = Math.Round(lKernelYear * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text)), 2)

        Else
            txtKERYear.Text = ""
        End If
    End Sub


    Private Sub BalanceBF()
        Dim Ds As New DataSet
        Dim objCPOLogPPT As New CPOProductionLogPPT
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        Ds = CPOProductionLogBOL.CPOProductionLogBalanceBF(objCPOLogPPT)
        If Ds.Tables(0).Rows.Count <> 0 Then
            txtTodayFFB.Text = Ds.Tables(0).Rows(0).Item("BalanceBF").ToString
            txtNoOfLorry.Text = Ds.Tables(0).Rows(0).Item("BalanceLorry").ToString

            If Val(Ds.Tables(1).Rows(0).Item("Monthcount").ToString) = 0 Or (Val(Ds.Tables(1).Rows(0).Item("Monthcount").ToString) = 1 And SaveFlag = False) Then
                txtTodayFFB.Enabled = True
                txtNoOfLorry.Enabled = True
            Else
                txtTodayFFB.Enabled = False
                txtNoOfLorry.Enabled = False
            End If

        Else
            txtTodayFFB.Enabled = True
            txtNoOfLorry.Enabled = True
            txtTodayFFB.Text = ""
            txtNoOfLorry.Text = ""
        End If

    End Sub

    Private Sub BalanceCFCalculation()
        lBalnceCF = 0
        lBalnceCF = (Val(txtTodayFFB.Text) + Val(txtFFBReceived.Text)) - Val(txtProcessedFFBToday.Text)
        If lBalnceCF > 0 Then
            txtUnProcessedFFB.Text = lBalnceCF
        Else
            txtUnProcessedFFB.Text = ""
        End If


    End Sub

    Private Sub txtTodayFFB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTodayFFB.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub


    Private Sub txtTodayFFB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTodayFFB.Leave
        BalanceCFCalculation()
    End Sub


    Private Sub dtpCPOLogDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCPOLogDate.ValueChanged
        ' CPOGetMonthYearQty()
        CPOGetMonthYearFFB()
        CPOGetTodayQtyForOERCPO()
        GetPKOProductionLogPressOPHrsValue()
        BalanceBF()
        CPOGetMonthYearMechanicalBD()
        CPOGetMonthYearElectricalBD()
        CPOGetMonthYearProcessingBD()
        CPOGetMonthYearEPHours()
        CPOGetMonthYearKER()
        CPOGetMonthYearLorry()
        CPOGetMonthYearLorryWeight()
        CPOGetMonthYearLossKernel()

        CPOGetMonthYearOER()


        CPOGetMonthYearTotalBD()
        CPOGetMonthYearThroughput()
        CPOLogFFBLorryProcessed()
        CPOGetFFBNetWeight()

        'GetTPHYear()
        Me.txtFFBMonth.Text = ""
        Me.txtFFBYear.Text = ""
        CPOGetMonthYearFFB()
        KernelGetTodayQty()
        CPOGetMonthYearQtySumm("Line 1")
        CPOGetMonthYearQtySumm("Line 2")
    End Sub




    Private Sub txtFFBToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBToday.TextChanged
        If Val(txtFFBToday.Text) <> 0 Then
            txtFFBToday.Text = Format(Val(txtFFBToday.Text), "0.000")
        End If
        '  CPOGetMonthYearFFB()
        'lPrevFFB = Me.dgvCPOLogView.SelectedRows(0).Cells("dgclProcessedFFB").Value
        If txtFFBMonth.Enabled = False Then
            If Val(txtFFBToday.Text) > 0 Then
                txtFFBMonth.Text = lFFBMonth + Val(txtFFBToday.Text) - lPrevFFB
                txtFFBYear.Text = lFFBYear + Val(txtFFBToday.Text) - lPrevFFB
                'txtFFBMonth.Text = Val(txtFFBToday.Text) - lPrevFFB
                'txtFFBYear.Text = Val(txtFFBToday.Text) - lPrevFFB
            Else
                txtFFBMonth.Text = lFFBMonth
                txtFFBYear.Text = lFFBYear
            End If
        End If




        If lOERCPOQty > 0 And Val(txtFFBToday.Text) <> 0 Then
            'txtOERToday.Text = Math.Round((lOERCPOQty / (Val(txtFFBToday.Text) - Val(txtKlToday.Text))) * 100, 2)
            txtOERToday.Text = Math.Round((lOERCPOQty / (Val(txtFFBToday.Text))) * 100, 2)

        Else
            txtOERToday.Text = ""
        End If

        If Val(txtKernalProduction.Text) > 0 And Val(txtFFBToday.Text) > 0 Then
            'txtKERToday.Text = Math.Round((Val(txtKernalProduction.Text) / (Val(txtFFBToday.Text) - Val(txtKlToday.Text))) * 100, 2)
            txtKERToday.Text = Math.Round(Val(txtKernalProduction.Text) / Val(txtFFBToday.Text) * 100, 2)
        Else
            txtKERToday.Text = ""
        End If
    End Sub

    Private Sub txtMonthTodate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonthTodate.Leave
        If txtMonthTodate.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtMonthTodate.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMonthTodate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMonthTodate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg106")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMonthTodate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMonthTodate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMonthTodate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtMonthTodate.Text = Hrs + ":" + Min
        End If
        If txtMonthTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMonthTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTotalHours.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg15")
                ''MessageBox.Show("Month To Date Hrs cant be lesser than Total Hrs")
                ' txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
        If txtYearTodate.Text <> "" And txtMonthTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodate.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtMonthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg17")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                '  txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtMonthTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonthTodate.TextChanged

        If txtMonthTodate.Enabled = True Then
            Dim Value As String = txtMonthTodate.Text
            Dim strlen As Integer

            If txtMonthTodate.Text <> "" Then
                strlen = Len(txtMonthTodate.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtMonthTodate.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter numeric values only ")
                        txtMonthTodate.Focus()
                    End If
                Next
            End If
            'If Val(txtMonthTodate.Text) >= 744 Then
            '    DisplayInfoMessage("Msg120")
            '    '  MsgBox("Month To date Hrs cant be greater than 744 hrs")
            '    txtMonthTodate.Focus()
            'End If
        End If

    End Sub

    Private Sub txtYearTodate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYearTodate.Leave

        If txtYearTodate.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg72")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtYearTodate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg72")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtYearTodate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg106")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtYearTodate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg69")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtYearTodate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtYearTodate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtYearTodate.Text = Hrs + ":" + Min
        End If
        If txtYearTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTotalHours.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg16")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
                'txtYearTodate.Focus()
                Exit Sub
            End If
        End If
        If txtMonthTodate.Text <> "" And txtYearTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodate.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtMonthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg17")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                ' txtYearTodate.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtYearTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYearTodate.TextChanged
        If txtYearTodate.Enabled = True Then
            If txtYearTodate.Text <> "" Then
                Dim Value As String = txtYearTodate.Text
                Dim strlen As Integer
                strlen = Len(txtYearTodate.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtYearTodate.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter numeric values only ")
                        txtYearTodate.Focus()
                    End If
                Next
            End If
            If Val(txtYearTodate.Text) > 8760 Then
                DisplayInfoMessage("Msg121")
                txtYearTodate.Focus()
            End If


        End If
    End Sub


    Private Sub btnMonthlyRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonthlyRpt.Click
        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty


        Dim strMonthlyProdRptName As String = String.Empty
        Dim DtotalShifthrs1 As String = "00:00"

        Dim DtotalShifthrs2 As String = "00:00"

        Dim DtotalShifthrs3 As String = "00:00"


        xlApp = New Excel.Application

        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Mill_Working_hours_Month_Report_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_hours_Month_Report_Template.xls")
        Else
            DisplayInfoMessage("Msg107")
            ''MsgBox("Mill working hours report template missing.Please contact system administrator.")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            DisplayInfoMessage("Msg108")
            ''MessageBox.Show("Report directory not found", "BSP")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Production Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()


        cmd.Connection = con
        cmd.CommandText = "Production.MillWorkingHoursReport1"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "MillWorkingHoursReport")


        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
        strMonthlyProdRptName = "Mill Working Hours Report" & "_" & lTextmonth & ""
        sheet.Cells(5, 1) = "Mill Working Hours Report" & " " & lTextmonth & ""


        sheet.Cells(1, 13) = Format(Date.Today, "dd/MM/yyyy")
        sheet.Cells(3, 11) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
        sheet.Cells(3, 13) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        Dim strArray As String()
        Dim lestate As String
        strArray = GlobalPPT.strEstateName.Split("-")
        lestate = strArray(1)
        sheet.Cells(2, 1) = "Estate/Mill :" & lestate & " "

        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"

        'If ds.Tables(0).Rows.Count = 0 Then
        '    If (File.Exists(StrPath)) Then
        '        File.Delete(StrPath)
        '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        '    Else
        '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        '    End If

        '    xlApp.Visible = True
        '    Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        If ds.Tables(0) IsNot Nothing Then


            Dim TotalCount As Integer = 0

            TotalCount = ds.Tables(0).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 13
            Dim LrowNo As Integer = 0

            While (TotalCount > 0)

                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1) = ds.Tables(0).Rows(LrowNo).Item("ProductionLogDate").ToString
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                Dim lStartTime, lStoptime As DateTime

                If Not ds.Tables(0).Rows(LrowNo).Item("StartTime1") Is DBNull.Value Then

                    lStartTime = ds.Tables(0).Rows(LrowNo).Item("StartTime1")
                    lStoptime = ds.Tables(0).Rows(LrowNo).Item("EndTime1")


                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
                            '   DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
                            DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 2) = strTotalhrs + ":00"
                        DtotalShifthrs1 = strTotalhrs + ":00"
                    End If
                End If


                If Not ds.Tables(0).Rows(LrowNo).Item("StartTime2") Is DBNull.Value Then
                    lStartTime = ds.Tables(0).Rows(LrowNo).Item("StartTime2")
                    lStoptime = ds.Tables(0).Rows(LrowNo).Item("EndTime2")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
                            DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
                            DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 3) = strTotalhrs + ":00"
                        DtotalShifthrs2 = strTotalhrs + ":00"
                    End If
                End If
                If Not ds.Tables(0).Rows(LrowNo).Item("StartTime3") Is DBNull.Value Then
                    lStartTime = ds.Tables(0).Rows(LrowNo).Item("StartTime3")
                    lStoptime = ds.Tables(0).Rows(LrowNo).Item("EndTime3")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
                            DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
                            DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 4) = strTotalhrs + ":00"
                        DtotalShifthrs3 = strTotalhrs + ":00"
                    End If
                End If

                Dim lTotalHours As String = String.Empty
                lTotalHours = ds.Tables(0).Rows(LrowNo).Item("TotalHours")
                'If lTotalHours < 10 Then
                '    lTotalHours = "0" + lTotalHours
                'End If
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5) = lTotalHours
                '  DtotalOperationhrs = lTotalHours
                Dim lProductionHours As String = String.Empty
                lProductionHours = ds.Tables(0).Rows(LrowNo).Item("ProductionHours").ToString
                'If lProductionHours < 10 Then
                '    lProductionHours = "0" + lProductionHours
                'End If
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6) = lProductionHours
                '  DtotalProdHrs = lProductionHours
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                'sheet.Cells(lRowCount, 7) = ds.Tables(0).Rows(LrowNo).Item("TotalHours") - ds.Tables(0).Rows(LrowNo).Item("ProductionHours")

                Dim lBKDownHours As String = ""
                If ds.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString <> "" Then
                    lBKDownHours = ds.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString
                    'If lBKDownHours < 10 Then
                    '    lBKDownHours = "0" + lBKDownHours
                    'End If
                    sheet.Cells(lRowCount, 8) = lBKDownHours
                    '  DtotalBreakDownHrs = lBKDownHours
                End If

                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13) = ds.Tables(0).Rows(LrowNo).Item("Remarks")

                TotalCount = TotalCount - 1
                lRowCount = lRowCount + 1
                LrowNo = LrowNo + 1

                If DtotalShifthrs1 <> "" And DtotalShifthrs1 <> "00:00" Then

                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = DtotalShifthrs1
                    strArr = Str.Split(":")
                    Str1 = ltotalShifthrs1
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs2 As String = "00"
                    Dim StrMin2 As String = "00"


                    If Lhrs < 10 Then
                        Strhrs2 = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs2 = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin2 = "0" + Convert.ToString(lmin)
                    Else
                        StrMin2 = lmin
                    End If

                    ltotalShifthrs1 = Strhrs2 + ":" + StrMin2
                End If
                DtotalShifthrs1 = "00:00"

                If DtotalShifthrs2 <> "" And DtotalShifthrs2 <> "00:00" Then

                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = DtotalShifthrs2
                    strArr = Str.Split(":")
                    Str1 = ltotalShifthrs2
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs2 As String = "00"
                    Dim StrMin2 As String = "00"


                    If Lhrs < 10 Then
                        Strhrs2 = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs2 = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin2 = "0" + Convert.ToString(lmin)
                    Else
                        StrMin2 = lmin
                    End If

                    ltotalShifthrs2 = Strhrs2 + ":" + StrMin2
                End If
                DtotalShifthrs2 = "00:00"


                If DtotalShifthrs3 <> "" And DtotalShifthrs3 <> "00:00" Then

                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = DtotalShifthrs3
                    strArr = Str.Split(":")
                    Str1 = ltotalShifthrs3
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs2 As String = "00"
                    Dim StrMin2 As String = "00"


                    If Lhrs < 10 Then
                        Strhrs2 = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs2 = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin2 = "0" + Convert.ToString(lmin)
                    Else
                        StrMin2 = lmin
                    End If

                    ltotalShifthrs3 = Strhrs2 + ":" + StrMin2
                End If
                DtotalShifthrs3 = "00:00"


            End While


            sheet.Cells(lRowCount, 1).font.bold = True
            sheet.Cells(lRowCount, 2).font.bold = True
            sheet.Cells(lRowCount, 3).font.bold = True
            sheet.Cells(lRowCount, 4).font.bold = True
            sheet.Cells(lRowCount, 5).font.bold = True
            sheet.Cells(lRowCount, 6).font.bold = True
            sheet.Cells(lRowCount, 7).font.bold = True
            sheet.Cells(lRowCount, 8).font.bold = True
            sheet.Cells(lRowCount, 9).font.bold = True
            sheet.Cells(lRowCount, 10).font.bold = True
            sheet.Cells(lRowCount, 11).font.bold = True
            sheet.Cells(lRowCount, 12).font.bold = True
            sheet.Cells(lRowCount, 13).font.bold = True
            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            'Dim strtotal As String = "Total"
            'sheet.Cells(lRowCount, 1) = Font.Bold

            sheet.Cells(lRowCount, 1) = "Total"

            Dim intMins As Integer = 0
            Dim intHrs As Integer = 0
            Dim StrMin As String = "00"
            Dim strHrs As String = "00"
            'Dim ltotalShift1hrs, ltotalShift2hrs, ltotalShift3hrs As Integer

            'ltotalShift1hrs = Math.Abs(ds.Tables(3).Rows(0).Item("TotalShift1Min"))
            'ltotalShift2hrs = Math.Abs(ds.Tables(3).Rows(0).Item("TotalShift2Min"))
            'ltotalShift3hrs = Math.Abs(ds.Tables(3).Rows(0).Item("TotalShift3Min"))

            'If ltotalShift1hrs > 0 Then
            '    intHrs = ltotalShift1hrs / 60
            '    intMins = ltotalShift1hrs Mod 60
            '    If intHrs < 10 Then
            '        strHrs = "0" + CStr(intHrs)
            '    Else
            '        strHrs = CStr(intHrs)
            '    End If

            '    If intMins < 10 Then
            '        StrMin = "0" + CStr(intMins)
            '    Else
            '        StrMin = CStr(intMins)
            '    End If

            '    sheet.Cells(lRowCount, 2) = strHrs + ":" + StrMin
            'Else
            '    sheet.Cells(lRowCount, 2) = ""
            'End If

            'If ltotalShift2hrs > 0 Then
            '    intHrs = ltotalShift2hrs / 60
            '    intMins = ltotalShift2hrs Mod 60
            '    If intHrs < 10 Then
            '        strHrs = "0" + CStr(intHrs)
            '    Else
            '        strHrs = CStr(intHrs)
            '    End If

            '    If intMins < 10 Then
            '        StrMin = "0" + CStr(intMins)
            '    Else
            '        StrMin = CStr(intMins)
            '    End If

            '    sheet.Cells(lRowCount, 3) = strHrs + ":" + StrMin
            'Else
            '    sheet.Cells(lRowCount, 3) = ""
            'End If
            'If ltotalShift3hrs > 0 Then
            '    intHrs = ltotalShift3hrs / 60
            '    intMins = ltotalShift3hrs Mod 60
            '    If intHrs < 10 Then
            '        strHrs = "0" + CStr(intHrs)
            '    Else
            '        strHrs = CStr(intHrs)
            '    End If

            '    If intMins < 10 Then
            '        StrMin = "0" + CStr(intMins)
            '    Else
            '        StrMin = CStr(intMins)
            '    End If

            '    sheet.Cells(lRowCount, 4) = strHrs + ":" + StrMin
            'Else
            '    sheet.Cells(lRowCount, 4) = ""
            'End If

            If ltotalShifthrs1 <> "00:00" Then
                sheet.Cells(lRowCount, 2) = ltotalShifthrs1
            End If
            If ltotalShifthrs2 <> "00:00" Then
                sheet.Cells(lRowCount, 3) = ltotalShifthrs2
            End If
            If ltotalShifthrs3 <> "00:00" Then
                sheet.Cells(lRowCount, 4) = ltotalShifthrs3
            End If
            ltotalShifthrs1 = "00:00"
            ltotalShifthrs2 = "00:00"
            ltotalShifthrs3 = "00:00"

            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            Dim ltotalHrs As String = "00:00"
            ltotalHrs = ds.Tables(13).Rows(0).Item("TotalHours").ToString

            If ltotalHrs <> "" Then

                Dim Hrs As String = "00"
                Dim Min As String = "00"
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = ltotalHrs
                strArr = str.Split(":")


                If strArr(0).Length = 1 Then
                    Hrs = "0" + strArr(0)
                ElseIf strArr(0) <> "" Then
                    Hrs = strArr(0)
                End If

                Min = strArr(1)
                ltotalHrs = Hrs + ":" + Min
            End If


            sheet.Cells(lRowCount, 5) = ltotalHrs

            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

            Dim ltotalProductionHrs As String = "00:00"
            ltotalProductionHrs = ds.Tables(10).Rows(0).Item("TotalProductionHours").ToString
            If ltotalProductionHrs <> "" Then

                Dim Hrs As String = "00"
                Dim Min As String = "00"
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = ltotalProductionHrs
                strArr = str.Split(":")


                If strArr(0).Length = 1 Then
                    Hrs = "0" + strArr(0)
                ElseIf strArr(0) <> "" Then
                    Hrs = strArr(0)
                End If

                Min = strArr(1)
                ltotalProductionHrs = Hrs + ":" + Min
            End If
            sheet.Cells(lRowCount, 6) = ltotalProductionHrs

            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            Dim ltotalBDHrs As String = "00:00"
            ltotalBDHrs = ds.Tables(7).Rows(0).Item("TotalBreakDownHours").ToString
            If ltotalBDHrs <> "" Then

                Dim Hrs As String = "00"
                Dim Min As String = "00"
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = ltotalBDHrs
                strArr = str.Split(":")
                If strArr(0).Length = 1 Then
                    Hrs = "0" + strArr(0)
                ElseIf strArr(0) <> "" Then
                    Hrs = strArr(0)
                End If

                Min = strArr(1)
                ltotalBDHrs = Hrs + ":" + Min
            End If

            sheet.Cells(lRowCount, 8) = ltotalBDHrs



            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            ' sheet.Cells(lRowCount, 11) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            ' sheet.Cells(lRowCount, 12) = ds.Tables(0).Rows(LrowNo).Item("Remarks")
            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

            '  Dim StrPath As String = Application.StartupPath & "\Reportskumar\" & strMonthlyProdRptName & ".xls"
            sheet.Protect("RANNBSP@2010")
            xlApp.Visible = True
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

            ' xlApp.Workbooks.Open(StrPath)


        End If

        Cursor = Cursors.Arrow
    End Sub

    Private Sub txtTpToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTpToday.TextChanged
        If Val(txtTpToday.Text) <> 0 Then
            txtTpToday.Text = Format(Val(txtTpToday.Text), "0.00")
        End If

        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsToday.Text <> "" And txtEPHrsToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtTotalHours.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpToday.Text = Math.Round(Val(txtProcessedFFBToday.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpToday.Text = ""
        End If

        If lOERCPOQty <> 0 And Val(txtFFBToday.Text) <> 0 Then
            txtOERToday.Text = Math.Round((lOERCPOQty / (Val(txtFFBToday.Text) - Val(txtKlToday.Text))) * 100, 2)

        Else
            txtOERToday.Text = ""
        End If

        If Val(txtKernalProduction.Text) <> 0 And Val(txtFFBToday.Text) <> 0 Then
            'txtKERToday.Text = Math.Round((Val(txtKernalProduction.Text) / (Val(txtFFBToday.Text) - Val(txtKlToday.Text))) * 100, 2)
            txtKERToday.Text = Math.Round(Val(txtKernalProduction.Text) / Val(txtFFBToday.Text) * 100, 2)
        Else
            txtKERToday.Text = ""
        End If

    End Sub

    Private Sub txtEPHrsToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPHrsToday.TextChanged
        If txtTBDToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr4(), strArr3() As String
            Dim Str4, Str3 As String
            Str4 = txtTotalHours.Text
            strArr4 = Str4.Split(":")
            Str3 = txtTBDToday.Text
            strArr3 = Str3.Split(":")

            Dim Lhrs2, lmin2 As Integer


            Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
            lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

            If lmin2 < 0 Then
                lmin2 = lmin2 + 60
                Lhrs2 = Lhrs2 - 1
            End If


            Dim Strhrs2 As String = "00"
            Dim StrMin2 As String = "00"


            If Lhrs2 < 10 Then
                Strhrs2 = "0" + Convert.ToString(Lhrs2)
            Else
                Strhrs2 = Lhrs2
            End If

            If lmin2 < 10 Then
                StrMin2 = "0" + Convert.ToString(lmin2)
            Else
                StrMin2 = lmin2
            End If

            txtEPHrsToday.Text = Strhrs2 + ":" + StrMin2
        ElseIf txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then
            txtEPHrsToday.Text = txtTotalHours.Text
        Else
            txtEPHrsToday.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsToday.Text <> "" And txtEPHrsToday.Text <> "00:00" And Len(txtEPHrsToday.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtTotalHours.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpToday.Text = Math.Round((Val(txtProcessedFFBToday.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpToday.Text = ""
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpToday.Text = Math.Round(Val(txtProcessedFFBToday.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpToday.Text = ""
        End If
    End Sub


    Private Sub txtTBDToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTBDToday.TextChanged
        If txtTBDToday.Text <> String.Empty And txtTBDToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg64")
                '' MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtEBDToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg64")
                '' MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtEBDToday.Focus()
                Exit Sub
            End If


            If txtTBDToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer


                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then
            txtEPHrsToday.Text = txtTotalHours.Text
        Else
            txtEPHrsToday.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsToday.Text <> "" And txtEPHrsToday.Text <> "00:00" And Len(txtEPHrsToday.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDToday.Text <> "" And txtPBDToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtTotalHours.Text <> "" And txtTotalHours.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtTotalHours.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If


        If txtMBDMonth.Enabled = False Then
            If txtTBDToday.Text <> "" And txtTBDToday.Text <> "00:00" Then
                txtTBDMonth.Text = ToaddHours(lTBDMonth, txtTBDToday.Text)
                txtTBDYear.Text = ToaddHours(lTBDYear, txtTBDToday.Text)
            Else
                txtTBDMonth.Text = ""
                txtTBDYear.Text = ""
            End If
        End If

        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpToday.Text = Math.Round((Val(txtProcessedFFBToday.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpToday.Text = ""
        End If


        If Val(txtProcessedFFBToday.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpToday.Text = Math.Round(Val(txtProcessedFFBToday.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpToday.Text = ""
        End If

        If lOERCPOQty <> 0 And Val(txtFFBToday.Text) <> 0 Then
            txtOERToday.Text = Math.Round((lOERCPOQty / (Val(txtFFBToday.Text) - Val(txtKlToday.Text))) * 100, 2)

        Else
            txtOERToday.Text = ""
        End If

        If Val(txtKernalProduction.Text) <> 0 And Val(txtFFBToday.Text) <> 0 Then
            'txtKERToday.Text = Math.Round((Val(txtKernalProduction.Text) / (Val(txtFFBToday.Text) - Val(txtKlToday.Text))) * 100, 2)
            txtKERToday.Text = Math.Round(Val(txtKernalProduction.Text) / Val(txtFFBToday.Text) * 100, 2)
        Else
            txtKERToday.Text = ""
        End If

    End Sub


    Private Sub txtOPHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOPHrs.Leave
        If txtOPHrs.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtOPHrs.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg65")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtOPHrs.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If



            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg65")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtOPHrs.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg65")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtOPHrs.Focus()
                    Exit Sub
                End If

                If strArr(0) > 24 Or (strArr(0) = 24 And strArr(1) > 0) Then
                    DisplayInfoMessage("Msg103")
                    ''MessageBox.Show("Op Hrs cant be greater than 24 hrs")
                    txtOPHrs.Focus()
                    Exit Sub

                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtOPHrs.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtOPHrs.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg105")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtOPHrs.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtOPHrs.Text = Hrs + ":" + Min
        End If
    End Sub

    Private Sub txtOPHrs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOPHrs.TextChanged
        If txtOPHrs.Text <> "" Then
            Dim Value As String = txtOPHrs.Text
            Dim strlen As Integer
            strlen = Len(txtOPHrs.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtOPHrs.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    '' MsgBox("Please Enter numeric values only")
                    txtOPHrs.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtTotalHours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalHours.TextChanged
        If txtTotalHours.Text <> "" Then
            CPOGetMonthYearQty()
            If lShifthoursCalc <> "00:00" And lmonthValuehrs <> "00:00" And MonthCount > 1 And SaveFlag = True Then
                txtMonthTodate.Text = ToaddHours(lShifthoursCalc, lmonthValuehrs)
            ElseIf lShifthoursCalc <> "00:00" And lmonthValuehrs <> "00:00" And MonthCount > 1 And SaveFlag = False Then
                txtMonthTodate.Text = ToaddHours(lShifthoursCalc, lmonthValuehrs)
                txtMonthTodate.Enabled = False
            ElseIf lmonthValuehrs <> "00:00" And MonthCount = 1 And SaveFlag = False Then
                txtMonthTodate.Text = lmonthValuehrs
                txtMonthTodate.Enabled = True
            ElseIf lmonthValuehrs <> "00:00" And MonthCount = 1 And SaveFlag = True Then
                txtMonthTodate.Text = ToaddHours(lShifthoursCalc, lmonthValuehrs)
                txtMonthTodate.Enabled = False
            ElseIf lmonthValuehrs = "00:00" And MonthCount >= 1 Then
                txtMonthTodate.Text = lShifthoursCalc
                txtMonthTodate.Enabled = False
            ElseIf txtMonthTodate.Text <> "" Then
                txtMonthTodate.Enabled = True
            Else
                txtMonthTodate.Text = ""
                txtMonthTodate.Enabled = True
            End If

            If lShifthoursCalc <> "00:00" And lYearValue <> "00:00" And YearCount > 1 And SaveFlag = True Then
                txtYearTodate.Text = ToaddHours(lShifthoursCalc, lYearValue)
            ElseIf lShifthoursCalc <> "00:00" And lYearValue <> "00:00" And YearCount > 1 And SaveFlag = False Then
                txtYearTodate.Text = ToaddHours(lShifthoursCalc, lYearValue)
                txtYearTodate.Enabled = False
            ElseIf lYearValue <> "00:00" And YearCount = 1 And SaveFlag = False Then
                txtYearTodate.Text = lYearValue
                txtYearTodate.Enabled = True
            ElseIf lYearValue <> "00:00" And YearCount = 1 And SaveFlag = True Then
                txtYearTodate.Text = ToaddHours(lShifthoursCalc, lYearValue)
                txtYearTodate.Enabled = False
            ElseIf lYearValue = "00:00" And YearCount >= 1 Then
                txtYearTodate.Text = lShifthoursCalc
                txtYearTodate.Enabled = False
            ElseIf txtYearTodate.Text <> "" Then
                txtYearTodate.Enabled = True
            Else
                txtYearTodate.Text = ""
                txtYearTodate.Enabled = True
            End If

            If txtMBToday.Text = "" And txtEBDToday.Text = "" And txtPBDToday.Text = "" Then
                txtEPHrsToday.Text = txtTotalHours.Text
            End If


        End If

    End Sub

    Private Function ToaddHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) + CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) + CInt(strArr3(1))

        If lmin2 >= 60 Then
            lmin2 = lmin2 - 60
            Lhrs2 = Lhrs2 + 1
        End If
        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If
        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function


    Private Function ToSubHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

        If lmin2 < 0 Then
            lmin2 = 60 + lmin2
            Lhrs2 = Lhrs2 - 1
        End If

        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If

        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function

    Private Sub txtLryToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLryToday.TextChanged

        CPOGetMonthYearLorry()
        If txtLryMonth.Enabled = False Then
            If Val(txtLryToday.Text) > 0 Then
                txtLryMonth.Text = lLryMonth + Val(txtLryToday.Text) - lPrevlry
                txtLryYear.Text = lLryYear + Val(txtLryToday.Text) - lPrevlry
            Else
                txtLryMonth.Text = lLryMonth
                txtLryYear.Text = lLryYear
            End If
        End If
    End Sub

    Private Sub txtLryWtToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLryWtToday.TextChanged
        AvgLorrywtCalc()
    End Sub

    Private Sub AvgLorrywtCalc()
        If Val(txtLryMonth.Text) > 0 And Val(txtFFBMonth.Text) > 0 Then
            txtLryWtMonth.Text = Math.Round(Val(txtFFBMonth.Text) / Val(txtLryMonth.Text), 3)

        Else
            txtLryWtMonth.Text = ""
        End If
        txtLryWtMonth.Text = Format(Val(txtLryWtMonth.Text), "0.000")
        txtLryWtToday.Text = Format(Val(txtLryWtToday.Text), "0.000")
        If Val(txtLryYear.Text) > 0 And Val(txtFFBYear.Text) > 0 Then
            txtLryWtYear.Text = Math.Round(Val(txtFFBYear.Text) / Val(txtLryYear.Text), 3)
        Else
            txtLryWtYear.Text = ""
        End If
        txtLryWtMonth.Text = Format(Val(txtLryWtMonth.Text), "0.000")
    End Sub

    Private Sub txtKlToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlToday.TextChanged
        If txtKlMonth.Enabled = False Then
            If Val(txtKlToday.Text) > 0 Then
                txtKlMonth.Text = Format(lKLMonth + Val(txtKlToday.Text) - lPrevKl, "0.000")
                txtKlYear.Text = Format(lKLYear + Val(txtKlToday.Text) - lPrevKl, "0.000")
                'txtKlToday.Text = Format(Val(txtKlToday.Text), "0.000")
            Else
                txtKlMonth.Text = Format(lKLMonth, "0.000")
                txtKlYear.Text = Format(lKLYear, "0.000")
            End If
        End If
        txtKlToday.Text = Format(Val(txtKlToday.Text), "0.000")

    End Sub

    Private Sub txtEPHrsMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPHrsMonth.TextChanged
        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            str3 = txtEPHrsMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtMonthTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1
        ElseIf lmonthValuehrs <> "" And lmonthValuehrs <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = lmonthValuehrs
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1

        End If

        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpMonth.Text = ""
        End If


        If Val(txtFFBMonth.Text) <> 0 And lTotalHrsDec > 0 Then
            txtAvgTpMonth.Text = Math.Round(Val(txtFFBMonth.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpMonth.Text = ""
        End If

        '  CPOGetMonthYearOER()

        'If Val(txtFFBMonth.Text) <> 0 And lCPOMonth <> 0 Then
        '    txtOERMonth.Text = Math.Round(lCPOMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)

        'Else
        '    txtOERMonth.Text = ""
        'End If

        'If Val(txtFFBMonth.Text) <> 0 And lKernelMonth <> 0 Then
        '    txtKERMonth.Text = Math.Round(lKernelMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)
        'Else
        '    txtKERMonth.Text = ""
        'End If
    End Sub

    Private Sub txtEPHrsYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPHrsYear.TextChanged
        CPOGetMonthYearQty()
        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtYearTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1
        ElseIf lYearValue <> "" And lYearValue <> "00:00" Then
            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = lYearValue
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpYear.Text = ""
        End If


        If Val(txtFFBYear.Text) <> 0 And lTotalHrsDec > 0 Then
            txtAvgTpYear.Text = Math.Round(Val(txtFFBYear.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpYear.Text = ""
        End If



    End Sub

    Private Sub CPOGetMonthYearQtySumm(ByVal Stage As String)

        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim dsProdQty As DataSet
        objCPOLogPPT.ProductionLogDate = dtpCPOLogDate.Value
        objCPOLogPPT.StagePress = Stage
        dsProdQty = CPOProductionLogBOL.CPOGetMonthYearQtySumm(objCPOLogPPT)
        lmonthValuehrsSumm = "00:00"
        lYearValueSumm = "00:00"
        MonthCountSumm = 0
        YearCountSumm = 0
        stage1PressSummaryID = ""
        stage1PressSummaryID = ""
        lstageCountMonth = 0
        lstageCountYear = 0

        lstageCountMonth = dsProdQty.Tables(18).Rows(0).Item("StageMonthCount")
        lstageCountYear = dsProdQty.Tables(19).Rows(0).Item("StageYearCount")
        If dsProdQty.Tables(6).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs") Is DBNull.Value Then
                lmonthValuehrsSumm = dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs")
                lmonthValuehrsSumm = ToModifyTime(lmonthValuehrsSumm)
                If Stage = "Line 1" Then
                    If txtTPHMonthTodateStage1.Enabled = False Then
                        txtTPHMonthTodateStage1.Text = lmonthValuehrsSumm
                    End If
                    ' summCalcMonthStage1()
                Else
                    If txtStage2monthTodate.Enabled = False Then
                        txtStage2monthTodate.Text = lmonthValuehrsSumm
                    End If
                    '   summCalcMonthStage2()
                End If
            End If
        End If
        If dsProdQty.Tables(13).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs") Is DBNull.Value Then
                lYearValueSumm = dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs")
                lYearValueSumm = ToModifyTime(lYearValueSumm)
                If Stage = "Line 1" Then
                    If txtTPHYearTodateStage1.Enabled = False Then
                        txtTPHYearTodateStage1.Text = lYearValueSumm
                    End If

                    '   SummCalcstage1Year()
                Else
                    If txtStage2yearTodate.Enabled = False Then
                        txtStage2yearTodate.Text = lYearValueSumm
                    End If
                    '  SummCalcstage2Year()
                End If
            End If
        End If

        MonthCountSumm = dsProdQty.Tables(14).Rows(0).Item("MonthCountHrs")
        YearCountSumm = dsProdQty.Tables(15).Rows(0).Item("YearCountHrs")



        If dsProdQty.Tables(16).Rows.Count <> 0 Then
            stage1PressSummaryID = dsProdQty.Tables(16).Rows(0).Item("stage1PressSummaryID")
            PrevStage1TPH = dsProdQty.Tables(16).Rows(0).Item("Stage1TPH")
        Else
            stage1PressSummaryID = ""
        End If
        If dsProdQty.Tables(17).Rows.Count <> 0 Then
            stage2PressSummaryID = dsProdQty.Tables(17).Rows(0).Item("stage2PressSummaryID")
            PrevStage2TPH = dsProdQty.Tables(17).Rows(0).Item("Stage2TPH")
        Else
            stage2PressSummaryID = ""
        End If


        If MonthCountSumm = 0 Or (MonthCountSumm = 1 And SaveFlag = False) Then
            txtTPHMonthTodateStage1.Enabled = True
            txtTPHYearTodateStage1.Enabled = True
            txtStage2monthTodate.Enabled = True
            txtStage2yearTodate.Enabled = True
        Else
            txtTPHMonthTodateStage1.Enabled = False
            txtTPHYearTodateStage1.Enabled = False
            txtStage2monthTodate.Enabled = False
            txtStage2yearTodate.Enabled = False
        End If


    End Sub

    Private Sub txtTPHTodaystage1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHTodaystage1.TextChanged
        If txtTPHTodaystage1.Text <> "" And dgPressInfo.RowCount > 0 Then
            CPOGetMonthYearQtySumm("Line 1")
            If lTotalOPHoursStage1 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And SaveFlag = True Then
                txtTPHMonthTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lmonthValuehrsSumm)
            ElseIf lTotalOPHoursStage1 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And SaveFlag = False Then
                txtTPHMonthTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lmonthValuehrsSumm)
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And SaveFlag = False Then
                txtTPHMonthTodateStage1.Text = lmonthValuehrsSumm
                txtTPHMonthTodateStage1.Enabled = True
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And SaveFlag = True Then
                txtTPHMonthTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lmonthValuehrsSumm)
                txtTPHMonthTodateStage1.Enabled = False

            ElseIf lmonthValuehrsSumm = "00:00" And txtTPHMonthTodateStage1.Enabled = False Then
                txtTPHMonthTodateStage1.Text = lTotalOPHoursStage1
            ElseIf txtTPHMonthTodateStage1.Text <> "" Then

            Else
                txtTPHMonthTodateStage1.Text = String.Empty
                txtTPHMonthTodateStage1.Enabled = True
            End If

            If lTotalOPHoursStage1 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And SaveFlag = True Then
                txtTPHYearTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lYearValueSumm)
            ElseIf lTotalOPHoursStage1 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And SaveFlag = False Then
                txtTPHYearTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lYearValueSumm)
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And SaveFlag = False Then
                txtTPHYearTodateStage1.Text = lYearValueSumm
                txtTPHYearTodateStage1.Enabled = True
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And SaveFlag = True Then
                txtTPHYearTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lYearValueSumm)
                txtTPHYearTodateStage1.Enabled = False
            ElseIf lYearValueSumm = "00:00" And txtTPHYearTodateStage1.Enabled = False Then
                txtTPHYearTodateStage1.Text = lTotalOPHoursStage1
            ElseIf txtTPHYearTodateStage1.Text <> "" Then
            Else
                txtTPHYearTodateStage1.Text = String.Empty
                txtTPHYearTodateStage1.Enabled = True
            End If
            Dim lTPHTodaystage1 As Decimal

            If txtTPHTodaystage1.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtTPHTodaystage1.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTPHTodaystage1 = Hrs + lmin
            End If
            'If txtTotalHoursPress.Text <> "" Then
            '    Dim Hrs As Integer
            '    Dim Min As Integer
            '    Dim str As String
            '    Dim strArr() As String
            '    'Dim count As Integer
            '    str = txtTotalHoursPress.Text
            '    strArr = str.Split(":")
            '    Hrs = strArr(0)
            '    Min = strArr(1)

            '    Min = (Min / 60) *100
            '    Dim lmin As String
            '    lmin = "." + Convert.ToString(Min)

            '    lTotalOPHrs = Hrs + lmin

            'End If
            If Val(txtProcessedFFBToday.Text) <> 0 And lTPHTodaystage1 > 0 Then
                txtAPTstage1today.Text = Math.Round(Val(txtProcessedFFBToday.Text) / lTPHTodaystage1, 2)
            Else
                txtAPTstage1today.Text = ""
            End If

            If txtEPHrsToday.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtEPHrsToday.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTotalHrs = Hrs + lmin
            End If

            If lTotalHrs > 0 And lTPHTodaystage1 > 0 And (ToCaculateTotalPress("Line 1")) Then
                txtutilstage1today.Text = Math.Round(lTPHTodaystage1 * 100 / (lTotalHrs * ToCaculateTotalPress("Line 1")), 2)
            Else
                txtutilstage1today.Text = ""
            End If
        Else
            txtAPTstage1today.Text = ""
            txtutilstage1today.Text = ""
        End If

        'If txtTPHTodaystage1.Text = "" Then
        '    txtTPHMonthTodateStage1.Enabled = False
        '    txtTPHYearTodateStage1.Enabled = False
        'End If

        'If txtStage2TodayTPH.Text = "" Then
        '    txtStage2monthTodate.Enabled = False
        '    txtStage2yearTodate.Enabled = False
        'End If

    End Sub

    Private Sub txtStage2TodayTPH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2TodayTPH.TextChanged
        If txtStage2TodayTPH.Text <> "" And dgPressInfo.RowCount > 0 Then
            CPOGetMonthYearQtySumm("Line 2")
            If lTotalOPHoursStage2 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And SaveFlag = True Then
                txtStage2monthTodate.Text = ToaddHours(lTotalOPHoursStage2, lmonthValuehrsSumm)
            ElseIf lTotalOPHoursStage2 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And SaveFlag = False Then
                txtStage2monthTodate.Text = ToaddHours(lTotalOPHoursStage2, lmonthValuehrsSumm)
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And SaveFlag = False Then
                txtStage2monthTodate.Text = lmonthValuehrsSumm
                txtStage2monthTodate.Enabled = True
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And SaveFlag = True Then
                txtStage2monthTodate.Text = ToaddHours(lTotalOPHoursStage2, lmonthValuehrsSumm)
                txtStage2monthTodate.Enabled = False
            ElseIf txtStage2monthTodate.Enabled = False And lmonthValuehrsSumm = "00:00" Then
                txtStage2monthTodate.Text = lTotalOPHoursStage2
            ElseIf txtStage2monthTodate.Text <> "" Then
            Else
                txtStage2monthTodate.Text = String.Empty
                txtStage2monthTodate.Enabled = True
            End If

            If lTotalOPHoursStage2 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And SaveFlag = True Then
                txtStage2yearTodate.Text = ToaddHours(lTotalOPHoursStage2, lYearValueSumm)
            ElseIf lTotalOPHoursStage2 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And SaveFlag = False Then
                txtStage2yearTodate.Text = ToaddHours(lTotalOPHoursStage2, lYearValueSumm)
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And SaveFlag = False Then
                txtStage2yearTodate.Text = lYearValueSumm
                txtStage2yearTodate.Enabled = True
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And SaveFlag = True Then
                txtStage2yearTodate.Text = ToaddHours(lTotalOPHoursStage2, lYearValueSumm)
                txtStage2yearTodate.Enabled = False
            ElseIf txtStage2yearTodate.Enabled = False And lYearValueSumm = "00:00" Then
                txtStage2yearTodate.Text = lTotalOPHoursStage2
            ElseIf txtStage2yearTodate.Text <> "" Then
            Else
                txtStage2yearTodate.Text = String.Empty
                txtStage2yearTodate.Enabled = True
            End If
            Dim lTPHTodaystage2, lTotalHrs As Decimal

            If txtStage2TodayTPH.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtStage2TodayTPH.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTPHTodaystage2 = Hrs + lmin
            End If

            If txtEPHrsToday.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtEPHrsToday.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTotalHrs = Hrs + lmin


            End If
            If Val(txtProcessedFFBToday.Text) <> 0 And lTPHTodaystage2 > 0 Then
                txtAPTstage2today.Text = Math.Round(Val(txtProcessedFFBToday.Text) / lTPHTodaystage2, 2)
            Else
                txtAPTstage2today.Text = ""
            End If
            If lTotalHrs > 0 And lTPHTodaystage2 > 0 And ToCaculateTotalPress("Line 2") <> 0 Then
                txtutilstage2.Text = Math.Round(lTPHTodaystage2 * 100 / (lTotalHrs * ToCaculateTotalPress("Line 2")), 2)
            Else
                txtutilstage2.Text = ""
            End If
        Else
            txtAPTstage2today.Text = ""
            txtutilstage2.Text = ""
        End If

        'If txtStage2TodayTPH.Text = "" Then
        '    txtStage2monthTodate.Enabled = False
        '    txtStage2yearTodate.Enabled = False
        'End If
        'If txtTPHTodaystage1.Text = "" Then
        '    txtTPHMonthTodateStage1.Enabled = False
        '    txtTPHYearTodateStage1.Enabled = False
        'End If
    End Sub

    Private Sub txtTPHYearTodateStage1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHYearTodateStage1.Leave
        If txtTPHYearTodateStage1.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg74")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtTPHYearTodateStage1.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtTPHYearTodateStage1.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then


                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg74")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtTPHYearTodateStage1.Text = Hrs + ":" + Min
        End If
        SummCalcstage1Year()
        'If txtTPHYearTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "" Then

        '    Dim strTotal As String
        '    Dim strArrTotal() As String
        '    strTotal = txtTPHTodaystage1.Text
        '    strArrTotal = strTotal.Split(":")

        '    Dim strMonth As String
        '    Dim strArrMonth() As String
        '    strMonth = txtTPHYearTodateStage1.Text
        '    strArrMonth = strMonth.Split(":")

        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = txtTPHMonthTodateStage1.Text
        '    strArr = str.Split(":")

        '    'If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
        '    If Val(strArr(0)) > Val(strArrTotal(0)) Or (Val(strArr(0)) >= Val(strArrTotal(0)) And Val(strArr(1)) > Val(strArrTotal(1))) Then
        '        MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
        '        '  txtTPHYearTodateStage1.Focus()
        '        Exit Sub
        '    End If

        '    'If strArr(0) < strArrMonth(0) Or (strArr(0) <= strArrMonth(0) And strArr(1) < strArrMonth(1)) Then
        '    If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
        '        MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
        '        ' txtTPHYearTodateStage1.Focus()
        '        Exit Sub
        '    End If

        'End If
        If txtTPHYearTodateStage1.Text <> "" And txtTPHTodaystage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg49")
                ''MessageBox.Show("Press Info Line 1 Year To Date Hrs cant be lesser than Press Info Line 1 Total Hrs")
                'txtYearTodate.Focus()
                Exit Sub
            End If
        End If
        If txtTPHMonthTodateStage1.Text <> "" And txtTPHYearTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtTPHMonthTodateStage1.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg50")
                ''MessageBox.Show("Press Info Line 1 Year To Date Hrs cant be lesser than Press Info Line 1 Month To Date Hrs")
                ' txtYearTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtStage2yearTodate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2yearTodate.Leave
        If txtStage2yearTodate.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg59")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtStage2yearTodate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtStage2yearTodate.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg59")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtStage2yearTodate.Text = Hrs + ":" + Min
        End If
        SummCalcstage2Year()
        'If txtStage2yearTodate.Text <> "" Then
        '    Dim strTotal As String
        '    Dim strArrTotal() As String
        '    strTotal = txtStage2TodayTPH.Text
        '    strArrTotal = strTotal.Split(":")

        '    Dim strMonth As String
        '    Dim strArrMonth() As String
        '    strMonth = txtStage2monthTodate.Text
        '    strArrMonth = strMonth.Split(":")

        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = txtStage2yearTodate.Text
        '    strArr = str.Split(":")


        '    'If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
        '    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
        '        MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
        '        txtStage2yearTodate.Focus()
        '        Exit Sub
        '    End If

        '    'If strArr(0) < strArrMonth(0) Or (strArr(0) <= strArrMonth(0) And strArr(1) < strArrMonth(1)) Then
        '    If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
        '        MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
        '        txtStage2yearTodate.Focus()
        '        Exit Sub
        '    End If
        'End If

        If txtStage2yearTodate.Text <> "" And txtStage2TodayTPH.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg52")
                ''MessageBox.Show("Press Info Line 2 Year To Date Hrs cant be lesser than Press Info Line 2 Total Hrs")
                'txtYearTodate.Focus()
                Exit Sub
            End If
        End If
        If txtStage2monthTodate.Text <> "" And txtStage2yearTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtStage2monthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg53")
                ''MessageBox.Show("Press Info Line 2 Year To Date Hrs cant be lesser than Press Info Line 2 Month To Date Hrs")
                ' txtYearTodate.Focus()
                Exit Sub
            End If
        End If


    End Sub

    Private Function ToCaculateTotalPress(ByVal Line As String)

        Dim lPresstotal As Integer = 0
        For Each objDataGridViewRow In dgPressInfo.Rows

            If objDataGridViewRow.Cells("dgMeStage").Value.ToString = Line Then
                lPresstotal = lPresstotal + 1
            End If
        Next
        Return lPresstotal

    End Function

    Private Function ToModifyTime(ByVal ModifyTime As String)
        Dim Hrs As String = "00"
        Dim Min As String = "00"
        Dim str As String
        Dim strArr() As String
        str = ModifyTime
        strArr = str.Split(":")
        If strArr(0).Length = 1 Then
            Hrs = "0" + strArr(0)
        Else
            Hrs = strArr(0)
        End If
        Min = strArr(1)
        ModifyTime = Hrs + ":" + Min
        Return ModifyTime
    End Function


    Private Sub txtOERToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOERToday.TextChanged
        If Val(txtOERToday.Text) > 0 Then
            txtOERToday.Text = Format(Val(txtOERToday.Text), "0.00")
        End If

    End Sub

    Private Sub txtOERMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOERMonth.TextChanged
        If Val(txtOERMonth.Text) > 0 Then
            txtOERMonth.Text = Format(Val(txtOERMonth.Text), "0.00")
        End If

    End Sub

    Private Sub txtOERYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOERYear.TextChanged
        If Val(txtOERYear.Text) > 0 Then
            txtOERYear.Text = Format(Val(txtOERYear.Text), "0.00")
        End If

    End Sub

    Private Sub txtKERToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKERToday.TextChanged
        If Val(txtKERToday.Text) > 0 Then
            txtKERToday.Text = Format(Val(txtKERToday.Text), "0.00")
        End If

    End Sub

    Private Sub txtKERMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKERMonth.TextChanged
        If Val(txtKERMonth.Text) > 0 Then
            txtKERMonth.Text = Format(Val(txtKERMonth.Text), "0.00")
        End If

    End Sub

    Private Sub txtKERYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKERYear.TextChanged
        If Val(txtKERYear.Text) > 0 Then
            txtKERYear.Text = Format(Val(txtKERYear.Text), "0.00")
        End If

    End Sub

    Private Sub txtAgeOfScrew_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgeOfScrew.Leave
        If txtAgeOfScrew.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtAgeOfScrew.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg59")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtAgeOfScrew.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If



            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg59")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg59")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                End If

                'If strArr(0) > 24 Or (strArr(0) = 24 And strArr(1) > 0) Then
                '    MessageBox.Show("Op Hrs cant be greater than 24 hrs")
                '    txtAgeOfScrew.Focus()
                '    Exit Sub

                'End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg105")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtAgeOfScrew.Text = Hrs + ":" + Min
        End If
    End Sub

    Private Sub txtAgeOfScrew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAgeOfScrew.TextChanged
        If txtAgeOfScrew.Text <> "" Then
            Dim Value As String = txtAgeOfScrew.Text
            Dim strlen As Integer
            strlen = Len(txtAgeOfScrew.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtAgeOfScrew.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please Enter numeric values only")
                    txtAgeOfScrew.Focus()
                End If
            Next
        End If
    End Sub


    Private Sub BreakdownMonthCalculation()
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMBDMonth.Text <> "" Then
            lMechaniclBD = txtMBDMonth.Text
        End If
        If txtEBDMonth.Text <> "" Then
            lelectriclBD = txtEBDMonth.Text
        End If
        If txtPBDMonth.Text <> "" Then
            lProcessBK = txtPBDMonth.Text
        End If
        lBDCalculation = ToaddHours(lProcessBK, lelectriclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        ' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        If (txtMBDMonth.Text <> "" Or txtEBDMonth.Text <> "" Or txtPBDMonth.Text <> "") Then
            txtTBDMonth.Text = lBDCalculation
            'If txtMonthTodate.Text <> "" Then
            '    txtEPHrsMonth.Text = ToSubHours(txtMonthTodate.Text, lBDCalculation)
            'End If

        Else
            txtTBDMonth.Text = ""
        End If
    End Sub
    Private Sub BreakdownYearCalculation()
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMBDYear.Text <> "" Then
            lMechaniclBD = txtMBDYear.Text
        End If
        If txtEBDYear.Text <> "" Then
            lelectriclBD = txtEBDYear.Text
        End If
        If txtPBDYear.Text <> "" Then
            lProcessBK = txtPBDYear.Text
        End If
        lBDCalculation = ToaddHours(lProcessBK, lelectriclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        ' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        If (txtMBDYear.Text <> "" Or txtEBDYear.Text <> "" Or txtPBDYear.Text <> "") Then
            txtTBDYear.Text = lBDCalculation
            'If txtYearTodate.Text <> "" Then
            '    txtEPHrsYear.Text = ToSubHours(txtYearTodate.Text, lBDCalculation)
            'End If
        Else
            txtTBDYear.Text = ""
        End If
    End Sub
    Private Sub txtMBDMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMBDMonth.Leave
        If txtMBDMonth.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMBDMonth.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMBDMonth.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMBDMonth.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMBDMonth.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMBDMonth.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMBDMonth.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtMBDMonth.Text = Hrs + ":" + Min
        End If
        'Dim lBDCalculation As String = "00:00"
        'Dim lMechaniclBD As String = "00:00"
        'Dim lelectriclBD As String = "00:00"
        'Dim lProcessBK As String = "00:00"


        'If txtMBDMonth.Text <> "" Then
        '    lMechaniclBD = txtMBDMonth.Text
        'End If
        'If txtEBDMonth.Text <> "" Then
        '    lelectriclBD = txtEBDMonth.Text
        'End If
        'If txtPBDMonth.Text <> "" Then
        '    lProcessBK = txtPBDMonth.Text
        'End If
        'lBDCalculation = ToaddHours(lProcessBK, lelectriclBD)
        'lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        ' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        'If (txtMBDMonth.Text <> "" Or txtEBDMonth.Text <> "" Or txtPBDMonth.Text <> "") Then
        '    txtTBDMonth.Text = lBDCalculation
        'Else
        '    txtTBDMonth.Text = ""
        'End If
        BreakdownMonthCalculation()

        'If txtTBDMonth.Text <> "" Then

        '    Dim HrsB As String = "00"
        '    Dim MinB As String = "00"
        '    Dim strB As String
        '    Dim strArrB() As String
        '    'Dim count As Integer
        '    strB = txtTBDMonth.Text
        '    strArrB = strB.Split(":")

        '    If strArrB(0).Length = 1 Then
        '        HrsB = "0" + strArrB(0)
        '    ElseIf strArrB(0) <> "" Then
        '        HrsB = strArrB(0)
        '    End If
        '    MinB = strArrB(1)
        '    txtTBDMonth.Text = HrsB + ":" + MinB
        'End If

        If txtTBDMonth.Text <> String.Empty And txtTBDMonth.Text <> "00:00" And txtMonthTodate.Text <> String.Empty And txtMonthTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If




            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtMBDMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtMBDMonth.Focus()
                Exit Sub
            End If

            If txtTBDMonth.Text <> String.Empty And txtMonthTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtMonthTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDMonth.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer



                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsMonth.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then
            txtEPHrsMonth.Text = txtMonthTodate.Text
        Else
            txtEPHrsMonth.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" And Len(txtEPHrsMonth.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtMonthTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        'If txtMBDMonth.Text <> "" And txtMBDMonth.Text <> "00:00" Then
        '    txtMBDMonth.Text = ToaddHours(lMBDMonth, txtMBDMonth.Text)
        '    txtMBDYear.Text = ToaddHours(lMBDYear, txtMBDMonth.Text)
        'Else
        '    txtMBDMonth.Text = lMBDMonth
        '    txtMBDYear.Text = lMBDYear
        'End If

        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpMonth.Text = ""
        End If


        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpMonth.Text = Math.Round(Val(txtFFBMonth.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpMonth.Text = ""
        End If


    End Sub

    Private Sub txtMBDMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMBDMonth.TextChanged


        If txtMBDMonth.Enabled = False Then
            BreakdownMonthCalculation()
        Else
            If txtMBDMonth.Text <> "" Then
                Dim Value As String = txtMBDMonth.Text
                Dim strlen As Integer
                strlen = Len(txtMBDMonth.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtMBDMonth.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter only numeric  values")
                        txtMBDMonth.Focus()
                    End If
                Next
            End If


        End If
    End Sub

    Private Sub txtEBDMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEBDMonth.Leave
        If txtEBDMonth.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEBDMonth.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtEBDMonth.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If


            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtEBDMonth.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtEBDMonth.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtEBDMonth.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg70")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtEBDMonth.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtEBDMonth.Text = Hrs + ":" + Min
        End If
        'Dim lBDCalculation As String = "00:00"
        'Dim lMechaniclBD As String = "00:00"
        'Dim lelectriclBD As String = "00:00"
        'Dim lProcessBK As String = "00:00"


        'If txtMBDMonth.Text <> "" Then
        '    lMechaniclBD = txtMBDMonth.Text
        'End If
        'If txtEBDMonth.Text <> "" Then
        '    lelectriclBD = txtEBDMonth.Text
        'End If
        'If txtPBDMonth.Text <> "" Then
        '    lProcessBK = txtPBDMonth.Text
        'End If
        'lBDCalculation = ToaddHours(lProcessBK, lMechaniclBD)
        'lBDCalculation = ToaddHours(lBDCalculation, lelectriclBD)

        '' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        'If (txtMBDMonth.Text <> "" Or txtEBDMonth.Text <> "" Or txtPBDMonth.Text <> "") Then
        '    txtTBDMonth.Text = lBDCalculation
        'Else
        '    txtTBDMonth.Text = ""
        'End If

        BreakdownMonthCalculation()

        'If txtTBDMonth.Text <> "" Then

        '    Dim HrsB As String = "00"
        '    Dim MinB As String = "00"
        '    Dim strB As String
        '    Dim strArrB() As String
        '    'Dim count As Integer
        '    strB = txtTBDMonth.Text
        '    strArrB = strB.Split(":")

        '    If strArrB(0).Length = 1 Then
        '        HrsB = "0" + strArrB(0)
        '    ElseIf strArrB(0) <> "" Then
        '        HrsB = strArrB(0)
        '    End If
        '    MinB = strArrB(1)
        '    txtTBDMonth.Text = HrsB + ":" + MinB
        'End If
        If txtTBDMonth.Text <> String.Empty And txtTBDMonth.Text <> "00:00" And txtMonthTodate.Text <> String.Empty And txtMonthTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If



            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtEBDMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtEBDMonth.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtMonthTodate.Text <> String.Empty And txtTBDMonth.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtMonthTodate.Text) - TimeSpan.Parse(txtTBDMonth.Text)
            '    txtEBDMonth.Text = Convert.ToString(lEffectiveHrs)
            ' If

            If txtTBDMonth.Text <> String.Empty And txtMonthTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtMonthTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDMonth.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer


                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsMonth.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then
            txtEPHrsMonth.Text = txtMonthTodate.Text
        Else
            txtEPHrsMonth.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" And Len(txtEPHrsMonth.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtMonthTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If
        'If txtEBDMonth.Text <> "" And txtEBDMonth.Text <> "00:00" Then
        '    txtEBDMonth.Text = ToaddHours(lEBDMonth, txtEBDMonth.Text)
        '    txtEBDYear.Text = ToaddHours(lEBDYear, txtEBDMonth.Text)
        'Else
        '    txtEBDMonth.Text = lEBDMonth
        '    txtEBDYear.Text = lEBDYear
        'End If

        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpMonth.Text = ""
        End If


        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpMonth.Text = Math.Round(Val(txtFFBMonth.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpMonth.Text = ""
        End If

        'If lOERCPOQty <> 0 And Val(txtFFBMonth.Text) <> 0 Then
        '    txtOERMonth.Text = Math.Round((lOERCPOQty * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text))), 2)
        'Else
        '    txtOERMonth.Text = ""
        'End If

        'If Val(txtKernalProduction.Text) <> 0 And Val(txtFFBMonth.Text) <> 0 Then
        '    txtKERMonth.Text = Math.Round((Val(txtKernalProduction.Text) * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text))), 2)
        'Else
        '    txtKERMonth.Text = ""
        'End If
    End Sub

    Private Sub txtEBDMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEBDMonth.TextChanged

        If txtEBDMonth.Enabled = False Then
            BreakdownMonthCalculation()
        Else

            If txtEBDMonth.Text <> "" Then
                Dim Value As String = txtEBDMonth.Text
                Dim strlen As Integer
                strlen = Len(txtEBDMonth.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtEBDMonth.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter only numeric  values")
                        txtEBDMonth.Focus()
                    End If
                Next
            End If


        End If
    End Sub

    Private Sub txtPBDMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPBDMonth.Leave
        If txtPBDMonth.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtPBDMonth.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtPBDMonth.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtPBDMonth.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtPBDMonth.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtPBDMonth.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtPBDMonth.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtPBDMonth.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtPBDMonth.Text = Hrs + ":" + Min
        End If
        'Dim lBDCalculation As String = "00:00"
        'Dim lMechaniclBD As String = "00:00"
        'Dim lelectriclBD As String = "00:00"
        'Dim lProcessBK As String = "00:00"


        'If txtMBDMonth.Text <> "" Then
        '    lMechaniclBD = txtMBDMonth.Text
        'End If
        'If txtEBDMonth.Text <> "" Then
        '    lelectriclBD = txtEBDMonth.Text
        'End If
        'If txtPBDMonth.Text <> "" Then
        '    lProcessBK = txtPBDMonth.Text
        'End If
        'lBDCalculation = ToaddHours(lelectriclBD, lMechaniclBD)
        'lBDCalculation = ToaddHours(lBDCalculation, lProcessBK)

        ''If lBDCalculation <> "" Then
        ''    Dim str As String
        ''    Dim strArr() As String
        ''    str = lBDCalculation
        ''    strArr = str.Split(":")

        ''    If strArr(0) > 24 Then
        ''        MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
        ''        txtPBDMonth.Focus()
        ''        Exit Sub
        ''    End If
        ''End If

        '' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        'If (txtMBDMonth.Text <> "" Or txtEBDMonth.Text <> "" Or txtPBDMonth.Text <> "") Then
        '    txtTBDMonth.Text = lBDCalculation
        'Else
        '    txtTBDMonth.Text = ""
        'End If


        'If txtTBDMonth.Text <> "" Then

        '    Dim HrsB As String = "00"
        '    Dim MinB As String = "00"
        '    Dim strB As String
        '    Dim strArrB() As String
        '    'Dim count As Integer
        '    strB = txtTBDMonth.Text
        '    strArrB = strB.Split(":")

        '    If strArrB(0).Length = 1 Then
        '        HrsB = "0" + strArrB(0)
        '    ElseIf strArrB(0) <> "" Then
        '        HrsB = strArrB(0)
        '    End If
        '    MinB = strArrB(1)
        '    txtTBDMonth.Text = HrsB + ":" + MinB
        'End If
        BreakdownMonthCalculation()

        If txtTBDMonth.Text <> String.Empty And txtTBDMonth.Text <> "00:00" And txtMonthTodate.Text <> String.Empty And txtMonthTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtPBDMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtPBDMonth.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtMonthTodate.Text <> String.Empty And txtTBDMonth.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtMonthTodate.Text) - TimeSpan.Parse(txtTBDMonth.Text)
            '    txtEBDMonth.Text = Convert.ToString(lEffectiveHrs)
            ' If

            If txtTBDMonth.Text <> String.Empty And txtMonthTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtMonthTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDMonth.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsMonth.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then
            txtEPHrsMonth.Text = txtMonthTodate.Text
        Else
            txtEPHrsMonth.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" And Len(txtEPHrsMonth.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtMonthTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If
        'If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then
        '    txtPBDMonth.Text = ToaddHours(lPBDMonth, txtPBDMonth.Text)
        '    txtPBDYear.Text = ToaddHours(lPBDYear, txtPBDMonth.Text)
        'Else
        '    txtPBDMonth.Text = lPBDMonth
        '    txtPBDYear.Text = lPBDYear
        'End If


        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpMonth.Text = ""
        End If


        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpMonth.Text = Math.Round(Val(txtFFBMonth.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpMonth.Text = ""
        End If

    End Sub

    Private Sub txtPBDMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBDMonth.TextChanged

        If txtPBDMonth.Enabled = False Then
            BreakdownMonthCalculation()
        Else
            If txtPBDMonth.Text <> "" Then
                Dim Value As String = txtPBDMonth.Text
                Dim strlen As Integer
                strlen = Len(txtPBDMonth.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtPBDMonth.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter only numeric  values")
                        txtPBDMonth.Focus()
                    End If
                Next
            End If


        End If
    End Sub

    Private Sub txtMBDYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMBDYear.Leave
        If txtMBDYear.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMBDYear.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg59")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMBDYear.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg59")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMBDYear.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMBDYear.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    '' MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMBDYear.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMBDYear.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtMBDYear.Text = Hrs + ":" + Min
        End If
        'Dim lBDCalculation As String = "00:00"
        'Dim lMechaniclBD As String = "00:00"
        'Dim lelectriclBD As String = "00:00"
        'Dim lProcessBK As String = "00:00"


        'If txtMBDYear.Text <> "" Then
        '    lMechaniclBD = txtMBDYear.Text
        'End If
        'If txtEBDYear.Text <> "" Then
        '    lelectriclBD = txtEBDYear.Text
        'End If
        'If txtPBDYear.Text <> "" Then
        '    lProcessBK = txtPBDYear.Text
        'End If
        'lBDCalculation = ToaddHours(lProcessBK, lelectriclBD)
        'lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        '' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        'If (txtMBDYear.Text <> "" Or txtEBDYear.Text <> "" Or txtPBDYear.Text <> "") Then
        '    txtTBDYear.Text = lBDCalculation
        'Else
        '    txtTBDYear.Text = ""
        'End If
        BreakdownYearCalculation()
        'If txtTBDYear.Text <> "" Then

        '    Dim HrsB As String = "00"
        '    Dim MinB As String = "00"
        '    Dim strB As String
        '    Dim strArrB() As String
        '    'Dim count As Integer
        '    strB = txtTBDYear.Text
        '    strArrB = strB.Split(":")

        '    If strArrB(0).Length = 1 Then
        '        HrsB = "0" + strArrB(0)
        '    ElseIf strArrB(0) <> "" Then
        '        HrsB = strArrB(0)
        '    End If
        '    MinB = strArrB(1)
        '    txtTBDYear.Text = HrsB + ":" + MinB
        'End If

        If txtTBDYear.Text <> String.Empty And txtTBDYear.Text <> "00:00" And txtYearTodate.Text <> String.Empty And txtYearTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg1091")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                txtMBDYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg1091")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                txtMBDYear.Focus()
                Exit Sub
            End If

            If txtTBDYear.Text <> String.Empty And txtYearTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtYearTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDYear.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer


                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If

                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsYear.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then
            txtEPHrsYear.Text = txtYearTodate.Text
        Else
            txtEPHrsYear.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" And Len(txtEPHrsYear.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtYearTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        'If txtMBDYear.Text <> "" And txtMBDYear.Text <> "00:00" Then
        '    txtMBDYear.Text = ToaddHours(lMBDYear, txtMBDYear.Text)
        '    txtMBDYear.Text = ToaddHours(lMBDYear, txtMBDYear.Text)
        'Else
        '    txtMBDYear.Text = lMBDYear
        '    txtMBDYear.Text = lMBDYear
        'End If

        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpYear.Text = ""
        End If


        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpYear.Text = Math.Round(Val(txtFFBYear.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpYear.Text = ""
        End If

        'If lOERCPOQty <> 0 And Val(txtFFBYear.Text) <> 0 Then
        '    txtOERYear.Text = Math.Round((lOERCPOQty * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text))), 2)

        'Else
        '    txtOERYear.Text = ""
        'End If

        'If Val(txtKernalProduction.Text) <> 0 And Val(txtFFBYear.Text) <> 0 Then
        '    txtKERYear.Text = Math.Round((Val(txtKernalProduction.Text) * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text))), 2)

        'Else
        '    txtKERYear.Text = ""
        'End If
    End Sub

    Private Sub txtMBDYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMBDYear.TextChanged

        If txtEBDYear.Enabled = False Then
            BreakdownYearCalculation()
        Else
            If txtMBDYear.Text <> "" Then
                Dim Value As String = txtMBDYear.Text
                Dim strlen As Integer
                strlen = Len(txtMBDYear.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtMBDYear.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter only numeric  values")
                        txtMBDYear.Focus()
                    End If
                Next
            End If


        End If
    End Sub

    Private Sub txtEBDYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEBDYear.Leave
        If txtEBDYear.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEBDYear.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtEBDYear.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If


            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtEBDYear.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtEBDYear.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtEBDYear.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtEBDYear.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtEBDYear.Text = Hrs + ":" + Min
        End If
        'Dim lBDCalculation As String = "00:00"
        'Dim lMechaniclBD As String = "00:00"
        'Dim lelectriclBD As String = "00:00"
        'Dim lProcessBK As String = "00:00"


        'If txtMBDYear.Text <> "" Then
        '    lMechaniclBD = txtMBDYear.Text
        'End If
        'If txtEBDYear.Text <> "" Then
        '    lelectriclBD = txtEBDYear.Text
        'End If
        'If txtPBDYear.Text <> "" Then
        '    lProcessBK = txtPBDYear.Text
        'End If
        'lBDCalculation = ToaddHours(lProcessBK, lMechaniclBD)
        'lBDCalculation = ToaddHours(lBDCalculation, lelectriclBD)

        '' lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

        'If (txtMBDYear.Text <> "" Or txtEBDYear.Text <> "" Or txtPBDYear.Text <> "") Then
        '    txtTBDYear.Text = lBDCalculation
        'Else
        '    txtTBDYear.Text = ""
        'End If
        BreakdownYearCalculation()

        'If txtTBDYear.Text <> "" Then

        '    Dim HrsB As String = "00"
        '    Dim MinB As String = "00"
        '    Dim strB As String
        '    Dim strArrB() As String
        '    'Dim count As Integer
        '    strB = txtTBDYear.Text
        '    strArrB = strB.Split(":")

        '    If strArrB(0).Length = 1 Then
        '        HrsB = "0" + strArrB(0)
        '    ElseIf strArrB(0) <> "" Then
        '        HrsB = strArrB(0)
        '    End If
        '    MinB = strArrB(1)
        '    txtTBDYear.Text = HrsB + ":" + MinB
        'End If
        If txtTBDYear.Text <> String.Empty And txtTBDYear.Text <> "00:00" And txtYearTodate.Text <> String.Empty And txtYearTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                txtEBDYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                txtEBDYear.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtYearTodate.Text <> String.Empty And txtTBDYear.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtYearTodate.Text) - TimeSpan.Parse(txtTBDYear.Text)
            '    txtEBDYear.Text = Convert.ToString(lEffectiveHrs)
            ' If

            If txtTBDYear.Text <> String.Empty And txtYearTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtYearTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDYear.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer


                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsYear.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then
            txtEPHrsYear.Text = txtYearTodate.Text
        Else
            txtEPHrsYear.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" And Len(txtEPHrsYear.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtYearTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If
        'If txtEBDYear.Text <> "" And txtEBDYear.Text <> "00:00" Then
        '    txtEBDYear.Text = ToaddHours(lEBDYear, txtEBDYear.Text)
        '    txtEBDYear.Text = ToaddHours(lEBDYear, txtEBDYear.Text)
        'Else
        '    txtEBDYear.Text = lEBDYear
        '    txtEBDYear.Text = lEBDYear
        'End If

        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpYear.Text = ""
        End If


        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpYear.Text = Math.Round(Val(txtFFBYear.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpYear.Text = ""
        End If

        'If lOERCPOQty <> 0 And Val(txtFFBYear.Text) <> 0 Then
        '    txtOERYear.Text = Math.Round((lOERCPOQty * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text))), 2)
        'Else
        '    txtOERYear.Text = ""
        'End If

        'If Val(txtKernalProduction.Text) <> 0 And Val(txtFFBYear.Text) <> 0 Then
        '    txtKERYear.Text = Math.Round((Val(txtKernalProduction.Text) * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text))), 2)
        'Else
        '    txtKERYear.Text = ""
        'End If
    End Sub

    Private Sub txtEBDYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEBDYear.TextChanged

        If txtEBDYear.Enabled = False Then
            BreakdownYearCalculation()
        Else

            If txtEBDYear.Text <> "" Then
                Dim Value As String = txtEBDYear.Text
                Dim strlen As Integer
                strlen = Len(txtEBDYear.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtEBDYear.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter only numeric  values")
                        txtEBDYear.Focus()
                    End If
                Next
            End If


        End If
    End Sub

    Private Sub txtPBDYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPBDYear.Leave
        If txtPBDYear.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtPBDYear.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtPBDYear.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtPBDYear.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtPBDYear.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg60")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtPBDYear.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg61")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtPBDYear.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg62")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtPBDYear.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtPBDYear.Text = Hrs + ":" + Min
        End If
        BreakdownYearCalculation()

        'If txtTBDYear.Text <> "" Then

        '    Dim HrsB As String = "00"
        '    Dim MinB As String = "00"
        '    Dim strB As String
        '    Dim strArrB() As String
        '    'Dim count As Integer
        '    strB = txtTBDYear.Text
        '    strArrB = strB.Split(":")

        '    If strArrB(0).Length = 1 Then
        '        HrsB = "0" + strArrB(0)
        '    ElseIf strArrB(0) <> "" Then
        '        HrsB = strArrB(0)
        '    End If
        '    MinB = strArrB(1)
        '    txtTBDYear.Text = HrsB + ":" + MinB
        'End If
        If txtTBDYear.Text <> String.Empty And txtTBDYear.Text <> "00:00" And txtYearTodate.Text <> String.Empty And txtYearTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = strArr2(0) - strArr1(0)


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg109")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                txtPBDYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg109")
                '' MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                txtPBDYear.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtYearTodate.Text <> String.Empty And txtTBDYear.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtYearTodate.Text) - TimeSpan.Parse(txtTBDYear.Text)
            '    txtEBDYear.Text = Convert.ToString(lEffectiveHrs)
            ' If

            If txtTBDYear.Text <> String.Empty And txtYearTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtYearTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDYear.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer


                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If

                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsYear.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then
            txtEPHrsYear.Text = txtYearTodate.Text
        Else
            txtEPHrsYear.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" And Len(txtEPHrsYear.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtYearTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpYear.Text = ""
        End If


        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then
            txtAvgTpYear.Text = Math.Round(Val(txtFFBYear.Text) / (lTotalHrsDec - lProcessHrsDec), 2)
        Else
            txtAvgTpYear.Text = ""
        End If


    End Sub

    Private Sub txtPBDYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBDYear.TextChanged


        If txtPBDYear.Enabled = False Then
            BreakdownYearCalculation()
        Else

            If txtPBDYear.Text <> "" Then
                Dim Value As String = txtPBDYear.Text
                Dim strlen As Integer
                strlen = Len(txtPBDYear.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtPBDYear.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg84")
                        ''MsgBox("Please enter only numeric  values")
                        txtPBDYear.Focus()
                    End If
                Next
            End If


        End If
    End Sub

    Private Sub txtMBToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMBToday.TextChanged
        If txtMBToday.Text <> "" Then
            Dim Value As String = txtMBToday.Text
            Dim strlen As Integer
            strlen = Len(txtMBToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMBToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    ''MsgBox("Please enter only numeric  values")
                    txtMBToday.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtLryMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLryMonth.KeyPress
        KeyPressDecimal(sender, e)
    End Sub


    Private Sub txtLryMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLryMonth.TextChanged
        AvgLorrywtCalc()
    End Sub

    Private Sub txtLryYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLryYear.KeyPress
        KeyPressDecimal(sender, e)
    End Sub

    Private Sub txtLryYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLryYear.TextChanged
        AvgLorrywtCalc()
    End Sub

    Private Sub txtTotalShiftFFBProcessed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalShiftFFBProcessed.TextChanged
        If Val(txtTotalShiftFFBProcessed.Text) <> 0 Then
            txtTotalShiftFFBProcessed.Text = Format(Val(txtTotalShiftFFBProcessed.Text), "0.000")
        End If
    End Sub

    Private Sub txtLryWtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLryWtYear.TextChanged
        If Val(txtLryWtYear.Text) <> 0 Then
            txtLryWtYear.Text = Format(Val(txtLryWtYear.Text), "0.000")
        End If
    End Sub

    Private Sub txtTodayFFB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTodayFFB.TextChanged
        If Val(txtTodayFFB.Text) <> 0 And txtTodayFFB.Enabled = False Then
            txtTodayFFB.Text = Format(Val(txtTodayFFB.Text), "0.000")
        End If
    End Sub

    Private Sub txtTBDMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTBDMonth.TextChanged

        If txtTBDMonth.Text <> String.Empty And txtTBDMonth.Text <> "00:00" And txtMonthTodate.Text <> String.Empty And txtMonthTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = strArr2(0) - strArr1(0)


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                Exit Sub
            End If


            If txtTBDMonth.Text <> String.Empty And txtMonthTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtMonthTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDMonth.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = strArr4(0) - strArr3(0)
                lmin2 = strArr4(1) - strArr3(1)

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If


                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsMonth.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then
            txtEPHrsMonth.Text = txtMonthTodate.Text
        Else
            txtEPHrsMonth.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsMonth.Text <> "" And txtEPHrsMonth.Text <> "00:00" And Len(txtEPHrsMonth.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDMonth.Text <> "" And txtPBDMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtMonthTodate.Text <> "" And txtMonthTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtMonthTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If Val(txtFFBMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpMonth.Text = Math.Round((Val(txtFFBMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpMonth.Text = ""
        End If

    End Sub

    Private Sub txtTBDYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTBDYear.TextChanged
        If txtTBDYear.Text <> String.Empty And txtTBDYear.Text <> "00:00" And txtYearTodate.Text <> String.Empty And txtYearTodate.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodate.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTBDYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                Exit Sub
            End If



            If txtTBDYear.Text <> String.Empty And txtYearTodate.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtYearTodate.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTBDYear.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = strArr4(0) - strArr3(0)
                lmin2 = strArr4(1) - strArr3(1)

                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"
                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If

                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEPHrsYear.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then
            txtEPHrsYear.Text = txtYearTodate.Text
        Else
            txtEPHrsYear.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEPHrsYear.Text <> "" And txtEPHrsYear.Text <> "00:00" And Len(txtEPHrsYear.Text) <> 3 Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEPHrsYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If

        Dim lProcessHrsDec As Decimal
        If txtPBDYear.Text <> "" And txtPBDYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtPBDYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lProcessHrsDec = Hrs1 + lmin1

        End If

        Dim lTotalHrsDec As Decimal
        If txtYearTodate.Text <> "" And txtYearTodate.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtYearTodate.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lTotalHrsDec = Hrs1 + lmin1


        End If

        If Val(txtFFBYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtTpYear.Text = Math.Round((Val(txtFFBYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtTpYear.Text = ""
        End If
    End Sub

    Private Sub txtKlMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKlMonth.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub


    Private Sub txtKlMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlMonth.TextChanged
        If Val(txtFFBMonth.Text) <> 0 And lCPOMonth <> 0 Then
            txtOERMonth.Text = Math.Round(lCPOMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)

        Else
            txtOERMonth.Text = ""
        End If

        If Val(txtFFBMonth.Text) <> 0 And lKernelMonth <> 0 Then
            'txtKERMonth.Text = Math.Round(lKernelMonth * 100 / (Val(txtFFBMonth.Text) - Val(txtKlMonth.Text)), 2)
            txtKERMonth.Text = Math.Round(lKernelMonth * 100 / Val(txtFFBMonth.Text), 2)
        Else
            txtKERMonth.Text = ""
        End If
    End Sub

    Private Sub txtKlYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKlYear.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKlYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlYear.TextChanged
        If Val(txtFFBYear.Text) <> 0 And lCPOYear <> 0 Then
            txtOERYear.Text = Math.Round(lCPOYear * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text)), 2)

        Else
            txtOERYear.Text = ""
        End If
        CPOGetMonthYearKER()

        If Val(txtFFBYear.Text) <> 0 And lKernelYear <> 0 Then
            txtKERYear.Text = Math.Round(lKernelYear * 100 / (Val(txtFFBYear.Text) - Val(txtKlYear.Text)), 2)

        Else
            txtKERYear.Text = ""
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


    Private Sub KeyPressDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub KeyDownDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

                        If txtBox.Text.Trim.Contains("") Then
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

    Private Sub txtFFBProcessed_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBProcessed.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtLorryProcessed_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLorryProcessed.KeyDown
        KeyDownDecimal(sender, e)
    End Sub

    Private Sub txtLorryProcessed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLorryProcessed.KeyPress
        KeyPressDecimal(sender, e)
    End Sub

    Private Sub txtTodayFFB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTodayFFB.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtNoOfLorry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoOfLorry.KeyDown
        KeyDownDecimal(sender, e)
    End Sub

    Private Sub txtNoOfLorry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfLorry.KeyPress
        KeyPressDecimal(sender, e)
    End Sub

    Private Sub txtFFBReceived_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBReceived.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtFFbNoOfLorry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFbNoOfLorry.KeyDown
        KeyDownDecimal(sender, e)
    End Sub

    Private Sub txtUnProcessedFFB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnProcessedFFB.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtUnProcessedFFB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnProcessedFFB.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtUnProcessedLorry_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnProcessedLorry.KeyDown
        KeyDownDecimal(sender, e)
    End Sub

    Private Sub txtUnProcessedLorry_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnProcessedLorry.KeyPress
        KeyPressDecimal(sender, e)
    End Sub

    Private Sub txtLossOnKernal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLossOnKernal.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtLossOnKernal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLossOnKernal.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtFFBMonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBMonth.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtFFBYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBYear.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKlMonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKlMonth.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKlYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKlYear.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtLryMonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLryMonth.KeyDown
        KeyDownDecimal(sender, e)
    End Sub

    Private Sub txtLryYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLryYear.KeyDown
        KeyDownDecimal(sender, e)
    End Sub

    Private Sub txtTotalShiftLorryProcessed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalShiftLorryProcessed.TextChanged
        If txtProcessedLorry.Text <> "" Then
            txtLryToday.Text = Val(txtProcessedLorry.Text)
        Else
            txtLryToday.Text = ""
        End If
    End Sub

    Private Sub txtLossOnKernal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLossOnKernal.Leave
        If txtLossOnKernal.Text <> "" Then
            txtKlToday.Text = CDbl(Val(txtLossOnKernal.Text))
        Else
            txtKlToday.Text = ""
        End If

        If txtKlMonth.Enabled = False Then
            If Val(txtKlToday.Text) > 0 Then
                txtKlMonth.Text = Format(lKLMonth + Val(txtKlToday.Text) - lPrevKl, "0.000")
                txtKlYear.Text = Format(lKLYear + Val(txtKlToday.Text) - lPrevKl, "0.000")
                'txtKlToday.Text = Format(Val(txtKlToday.Text), "0.000")
            Else
                txtKlMonth.Text = Format(lKLMonth, "0.000")
                txtKlYear.Text = Format(lKLYear, "0.000")
            End If
        End If
    End Sub

    Private Sub txtTpMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTpMonth.TextChanged
        If Val(txtTpMonth.Text) <> 0 Then
            txtTpMonth.Text = Format(Val(txtTpMonth.Text), "0.00")
        End If
    End Sub

    Private Sub txtTpYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTpYear.TextChanged
        If Val(txtTpYear.Text) <> 0 Then
            txtTpYear.Text = Format(Val(txtTpYear.Text), "0.00")
        End If
    End Sub

    Private Sub txtAvgTpToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAvgTpToday.TextChanged
        If Val(txtAvgTpToday.Text) <> 0 Then
            txtAvgTpToday.Text = Format(Val(txtAvgTpToday.Text), "0.00")
        End If
    End Sub

    Private Sub txtAvgTpMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAvgTpMonth.TextChanged
        If Val(txtAvgTpMonth.Text) <> 0 Then
            txtAvgTpMonth.Text = Format(Val(txtAvgTpMonth.Text), "0.00")
        End If
    End Sub

    Private Sub txtAvgTpYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAvgTpYear.TextChanged
        If Val(txtAvgTpYear.Text) <> 0 Then
            txtAvgTpYear.Text = Format(Val(txtAvgTpYear.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage1today_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage1today.TextChanged
        If Val(txtAPTstage1today.Text) <> 0 Then
            txtAPTstage1today.Text = Format(Val(txtAPTstage1today.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPHstage1monthtodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPHstage1monthtodate.TextChanged
        If Val(txtAPHstage1monthtodate.Text) <> 0 Then
            txtAPHstage1monthtodate.Text = Format(Val(txtAPHstage1monthtodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage1yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage1yeartodate.TextChanged
        If Val(txtAPTstage1yeartodate.Text) <> 0 Then
            txtAPTstage1yeartodate.Text = Format(Val(txtAPTstage1yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage2today_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage2today.TextChanged
        If Val(txtAPTstage2today.Text) <> 0 Then
            txtAPTstage2today.Text = Format(Val(txtAPTstage2today.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage2monthtodae_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage2monthtodae.TextChanged
        If Val(txtAPTstage2monthtodae.Text) <> 0 Then
            txtAPTstage2monthtodae.Text = Format(Val(txtAPTstage2monthtodae.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTStage2yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTStage2yeartodate.TextChanged
        If Val(txtAPTStage2yeartodate.Text) <> 0 Then
            txtAPTStage2yeartodate.Text = Format(Val(txtAPTStage2yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage1today_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage1today.TextChanged
        If Val(txtutilstage1today.Text) <> 0 Then
            txtutilstage1today.Text = Format(Val(txtutilstage1today.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage1monthtodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage1monthtodate.TextChanged
        If Val(txtutilstage1monthtodate.Text) <> 0 Then
            txtutilstage1monthtodate.Text = Format(Val(txtutilstage1monthtodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage1yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage1yeartodate.TextChanged
        If Val(txtutilstage1yeartodate.Text) <> 0 Then
            txtutilstage1yeartodate.Text = Format(Val(txtutilstage1yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage2.TextChanged
        If Val(txtutilstage2.Text) <> 0 Then
            txtutilstage2.Text = Format(Val(txtutilstage2.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage2monthtodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage2monthtodate.TextChanged
        If Val(txtutilstage2monthtodate.Text) <> 0 Then
            txtutilstage2monthtodate.Text = Format(Val(txtutilstage2monthtodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage2yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage2yeartodate.TextChanged
        If Val(txtutilstage2yeartodate.Text) <> 0 Then
            txtutilstage2yeartodate.Text = Format(Val(txtutilstage2yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub ShiftLogDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShiftLogDelete.Click




        ClearShift()
        StartDatefunction()
        StopDatefunction()
        BindDgvCPOLogShiftDetails()
    End Sub

    Private Sub ShiftLogEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShiftLogEdit.Click

        If dgvCPOLogDetails.RowCount = 0 Then

            Exit Sub
        ElseIf dgvCPOLogDetails.RowCount = 1 Then
            DisplayInfoMessage("Msg911")
            Exit Sub
        Else

            DeleteMultientrydatagridShift()
        End If

    End Sub

    Private Sub PressInfoedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PressInfoedit.Click
        ClearLogExpress()
        MultipleDateEntryValuesPressInfo()
    End Sub

    Private Sub PressInfoDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PressInfoDelete.Click
        If dgPressInfo.RowCount = 0 Then
            Exit Sub
        ElseIf dgPressInfo.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg911")
            Exit Sub
        Else
            DeleteMultientrydatagridPressInfo()
        End If
    End Sub

    Private Sub DeleteMultientrydatagridShift()

        Dim Dr As DataRow
        Dr = dtCPOAdd.Rows.Item(dgvCPOLogDetails.CurrentRow.Index)
        Dr.Delete()
        dtCPOAdd.AcceptChanges()
        TotalHourShiftsKernelProcessedCalculation()
        ResetMain()
        ClearShift()
        StartDatefunction()
        StopDatefunction()

    End Sub

    Private Sub DeleteMultientrydatagridPressInfo()

        If Not dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value Is Nothing Then
            lProductionLogPressID = dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value.ToString
        Else
            lProductionLogPressID = String.Empty
        End If

        lDelete = 0
        If lProductionLogPressID <> "" Then
            lDelete = DeleteMultientryPressInfo.Count

            DeleteMultientryPressInfo.Insert(lDelete, lProductionLogPressID)

            ' lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtPressInfo.Rows.Item(dgPressInfo.CurrentRow.Index)
        Dr.Delete()
        dtPressInfo.AcceptChanges()
        lProductionLogPressID = ""
        TPH()

    End Sub

    Private Sub DeleteMultiEntryRecordsPressInfo()
        Dim objCPOProductionLogPPT As New CPOProductionLogPPT
        lDelete = DeleteMultientryPressInfo.Count

        While (lDelete > 0)

            objCPOProductionLogPPT.ProductionLogPressID = DeleteMultientryPressInfo(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = CPOProductionLogBOL.CPOProductionLogPressMultiEntryDelete(objCPOProductionLogPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objCPOLogPPT As New CPOProductionLogPPT
        Dim objCPOLogBOL As New CPOProductionLogBOL
        objCPOLogPPT.CPOProductionLogID = lCPOProductionLogID
        objCPOLogBOL.Delete_CPOLogDetail(objCPOLogPPT)
        CPOLogFFBLorryProcessed()
        CPOLogGridViewBind()
        Clear()
        ClearGridView(dgPressInfo)
        ClearLogExpress()
        ClearShift()
        StartDatefunction()
        StopDatefunction()


    End Sub

    Private Sub tcCPOProductionLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCPOProductionLog.Click
        If (dgvCPOLogDetails.RowCount > 0 Or dgPressInfo.RowCount > 0) And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                'tcCPOProductionLog.SelectedIndex = 0
                Me.tcCPOProductionLog.SelectedTab = tpCPOProductionSave
                tcCPOLog.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else

                Clear()
                ClearLogExpress()
                ClearShift()
                ClearGridView(dgPressInfo)
                tcCPOLog.SelectedIndex = 0
                chkCPOLogDate.Checked = False
                dtpCPOLogViewDate.Enabled = False
                CPOLogGridViewBind()

                'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                '    MsgBox(PrivilegeError)
                'End If
            End If
        Else
            Clear()
            ClearLogExpress()
            ClearShift()
            ClearGridView(dgPressInfo)
            tcCPOLog.SelectedIndex = 0
            CPOLogGridViewBind()
        End If
    End Sub

    Private Sub txtStartTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartTime.Leave
        If txtStartTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtStartTime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtStartTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If CInt(strArr(0)) >= 24 Then
                DisplayInfoMessage("Msg179")
                txtStartTime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    '  MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtStartTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg106")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStartTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStartTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStartTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtStartTime.Text = Hrs + ":" + Min
        End If
        timeCalculation()
        'If txtStartTime.Text <> "" Then
        '    Dim str As String
        '    Dim strArr() As String
        '    str = txtStartTime.Text
        '    strArr = str.Split(":")

        '    If CInt(strArr(0)) > 24 Or (CInt(strArr(0)) = 24 And CInt(strArr(1)) <> 0) Then
        '        DisplayInfoMessage("Msg178")
        '        txtStartTime.Focus()
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub txtStartTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartTime.TextChanged
        Dim Value As String = txtStartTime.Text
        Dim strlen As Integer
        If txtStartTime.Text <> "" Then
            strlen = Len(txtStartTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStartTime.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    txtStartTime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtStopTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStopTime.Leave
        If txtStopTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtStopTime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtStopTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If CInt(strArr(0)) >= 24 Then
                DisplayInfoMessage("Msg180")
                txtStopTime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    '  MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtStopTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg106")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStopTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStopTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStopTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If


            End If

            txtStopTime.Text = Hrs + ":" + Min
        End If
        timeCalculation()
        'If txtStopTime.Text <> "" Then
        '    Dim str As String
        '    Dim strArr() As String
        '    str = txtStopTime.Text
        '    strArr = str.Split(":")

        '    If CInt(strArr(0)) > 24 Or (CInt(strArr(0)) = 24 And CInt(strArr(1)) <> 0) Then
        '        DisplayInfoMessage("Msg178")
        '        txtStopTime.Focus()
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub txtStopTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStopTime.TextChanged
        Dim Value As String = txtStopTime.Text
        Dim strlen As Integer
        If txtStopTime.Text <> "" Then
            strlen = Len(txtStopTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStopTime.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    txtStopTime.Focus()
                End If
            Next
        End If

    End Sub

    Private Sub timeCalculation()
        If txtStartTime.Text <> "" And txtStopTime.Text <> "" Then
            Dim strArr4(), strArr3() As String
            Dim Str4, Str3 As String
            Str4 = txtStopTime.Text
            strArr4 = Str4.Split(":")
            Str3 = txtStartTime.Text
            strArr3 = Str3.Split(":")
            Dim strTotalMins As String = 0
            Dim strTotalhrs As String = String.Empty

            If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                'For Hours

                strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                If strTotalhrs < 0 Then
                    strTotalhrs = Val(strTotalhrs) + 24
                End If
            ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) > Val(CInt(strArr3(1))) Then
                strTotalhrs = "0"
            ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) < Val(CInt(strArr3(1))) Then
                strTotalhrs = "24"
            ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                strTotalhrs = "24"
            Else
                strTotalhrs = "0"
            End If

            If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                'For Mins
                strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                If Val(strTotalMins) < 0 Then
                    strTotalMins = Val(strTotalMins) + 60
                    strTotalhrs = Val(strTotalhrs) - 1
                End If
            Else
                strTotalMins = "0"
            End If


            If Val(strTotalhrs) < 10 Then
                strTotalhrs = "0" + strTotalhrs
            End If
            If Val(strTotalMins) < 10 Then
                strTotalMins = "0" + strTotalMins
            End If

            ' If strTotalhrs <> Nothing Then
            txtShiftHrs.Text = strTotalhrs + ":" + strTotalMins
            lShiftHrs = txtShiftHrs.Text
            'Else
            '    strTotalhrs = "00"
            '    txtShiftHrs.Text = strTotalhrs + ":" + strTotalMins
            '    lShiftHrs = Val(txtShiftHrs.Text)
            'End If


        End If


    End Sub


    Private Sub txtFFBMonthToDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBMonthToDate.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtFFBMonthToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBMonthToDate.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtFFBYearToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBYearToDate.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtFFBYearToDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBYearToDate.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtFFBReceived_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBReceived.TextChanged
        If txtFFBMonthToDate.Enabled = False Then
            If Val(txtFFBReceived.Text) > 0 Then
                txtFFBMonthToDate.Text = lFFBReceivedMonth + Val(txtFFBReceived.Text) - lPrevFFBReceived
                txtFFBYearToDate.Text = lFFBReceivedYear + Val(txtFFBReceived.Text) - lPrevFFBReceived
            Else
                txtFFBMonthToDate.Text = lFFBReceivedMonth
                txtFFBYearToDate.Text = lFFBReceivedYear
            End If
        End If

    End Sub

    Private Sub txtFFBMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBMonthToDate.TextChanged
        If txtFFBMonthToDate.Enabled = False Then
            txtFFBMonthToDate.Text = Format(Val(txtFFBMonthToDate.Text), "0.000")
        End If
    End Sub

    Private Sub txtFFBYearToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBYearToDate.TextChanged
        If txtFFBYearToDate.Enabled = False Then
            txtFFBYearToDate.Text = Format(Val(txtFFBYearToDate.Text), "0.000")
        End If
    End Sub

    Private Sub txtTotalBrkdown_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalBrkdown.Leave
        If txtTotalBrkdown.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtTotalBrkdown.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtTotalBrkdown.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If CInt(strArr(0)) >= 24 Then
                DisplayInfoMessage("Msg182")
                txtTotalBrkdown.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg57")
                    '  MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtTotalBrkdown.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg106")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtTotalBrkdown.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtTotalBrkdown.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtTotalBrkdown.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If


            End If

            txtTotalBrkdown.Text = Hrs + ":" + Min
        Else
            txtTotalBrkdown.Text = "00:00"
        End If
    End Sub

    Private Sub txtTotalBrkdown_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalBrkdown.TextChanged
        Dim Value As String = txtTotalBrkdown.Text
        Dim strlen As Integer
        If txtTotalBrkdown.Text <> "" Then
            strlen = Len(txtTotalBrkdown.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtTotalBrkdown.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    txtTotalBrkdown.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub dgvCPOLogDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPOLogDetails.CellContentClick

    End Sub

    Private Sub dgvCPOLogView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCPOLogView.CellContentClick

    End Sub
End Class