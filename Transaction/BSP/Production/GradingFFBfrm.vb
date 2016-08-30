Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Math
Public Class GradingFFBfrm

    Private lWeighingID As String = String.Empty
    Private lgradingID As String = String.Empty
    Private lWBTicketNo As String = String.Empty
    Dim isModifierKey As Boolean
    ' Dim is2Decimal As Boolean
    ' Dim re2DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim is3Decimal As Boolean
    Dim re3DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,0})?$")
    Dim is3kgDecimal As Boolean
    Dim re3kgDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")

    Private lLooseFruitorBunch, lUnripeFruitJJ, lUnderRipeJJ, lRipeFruitJJ, lOverRipeFruitJJ, lEmptyBunchFruitJJ As Integer
    Private lTotalNormalFruitsJJ, lParthenocarpicJJ, lHardBunchJJ, lTotalAbnormalFruitsJJ As Integer
    Private lGrandTotalJJ, lUndamageTotalBunch, lLightDamageTotalBunch, lTotalBunch, lDamageTotalBunch As Integer
    Private lBtnSave As String = String.Empty
    Dim lHrs As Integer
    Dim lmin As Integer
    '  Dim lAMPM As String = String.Empty
    Public Shared StrFrmName As String = String.Empty
    Dim DecimalCheck As Boolean = False

    Dim isDecimal As Boolean
    Dim reDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,3})?$")
    Dim twoDecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,2})?$")

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingFFBfrm))
    Dim mdiparent As New MDIParent

    Public Sub Clear()
        gpProductionGradingFFB1.Enabled = True
        txtProductionWBTicketNo.Text = String.Empty
        txtProductionMinMaturity.Text = String.Empty
        txtProductionLooseFruitorBunch.Text = String.Empty
        txtProductionUnripeFruitJJ.Text = String.Empty
        txtProductionUnripeFruitPercentage.Text = String.Empty
        txtProductionUnderRipeJJ.Text = String.Empty
        txtProductionUnderRipePercentage.Text = String.Empty
        txtProductionRipeFruitJJ.Text = String.Empty
        txtProductionRipeFruitPercentage.Text = String.Empty
        txtProductionOverRipeFruitJJ.Text = String.Empty
        txtProductionOverRipeFruitPercentage.Text = String.Empty
        txtProductionEmptyBunchFruitJJ.Text = String.Empty
        txtProductionEmptyBunchFruitPercentage.Text = String.Empty
        txtProductionTotalNormalFruitsJJ.Text = String.Empty
        txtProductionParthenocarpicJJ.Text = String.Empty
        txtProductionParthenocarpicPercentage.Text = String.Empty
        txtProductionHardBunchJJ.Text = String.Empty
        txtProductionHardBunchPercentage.Text = String.Empty
        txtProductionTotalAbnormalFruitsJJ.Text = String.Empty
        txtProductionTotalAbnormalFruitsPercentage.Text = String.Empty
        txtProductionLooseFruit.Text = String.Empty
        txtProductionKgofFruitLoose.Text = String.Empty
        txtProductionUndamageTotalBunch.Text = String.Empty
        txtProductionLightDamageTotalBunch.Text = String.Empty
        txtProductionDamageTotalBunch.Text = String.Empty
        txtProductionDamagePercentage.Text = String.Empty
        txtProductionUndamagePercentage.Text = String.Empty
        txtProductionLightDamagePercentage.Text = String.Empty
        txtProductionTotalBunch.Text = String.Empty
        txtProductionTotalPercentage.Text = String.Empty
        txtProductionTotalNormalFruitsPercentage.Text = String.Empty
        txtProductionGrandTotalJJ.Text = String.Empty
        txtProductionGrandTotalPercentage.Text = String.Empty
        txtProductionComment.Text = String.Empty
        txtBatuKerikil.Text = String.Empty
        lWeighingID = String.Empty
        lgradingID = String.Empty
        ClearGridView(dgvBlock)
        lLooseFruitorBunch = 0
        lUnripeFruitJJ = 0
        lUnderRipeJJ = 0
        lRipeFruitJJ = 0
        lOverRipeFruitJJ = 0
        lEmptyBunchFruitJJ = 0
        lTotalNormalFruitsJJ = 0
        lParthenocarpicJJ = 0
        lHardBunchJJ = 0
        lTotalAbnormalFruitsJJ = 0
        lGrandTotalJJ = 0
        lUndamageTotalBunch = 0
        lLightDamageTotalBunch = 0
        lTotalBunch = 0
        lDamageTotalBunch = 0

  

        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSave.Text = "Simpan"
        End If

        lBtnSave = "Save"
        'btnSave.Text = "Save"

        Datefunction()
        txtWBTicketNoSearch.Focus()
        txtWBTicketNoSearch.Text = ""
        chkGradingDate.Checked = False

        dtpViewGradingDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtProductionGradingDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        dtProductionGradingDate.Value = Date.Today
        dtpViewGradingDate.Value = Date.Today
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        dtpViewGradingDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtProductionGradingDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        'dtProductionGradingDate.Value = Format(dtProductionGradingDate.Value, "dd/MM/yyyy")
        'dtpViewGradingDate.Value = Format(dtpViewGradingDate.Value, "dd/MM/yyyy")

    End Sub
    Private Sub Datefunction()


        Dim lDate As String
        lDate = "" & TimeOfDay.Hour & ":" & TimeOfDay.Minute & ""
        txtGradingTime.Text = lDate


    End Sub
    Private Sub ClearDataGridText()
        txtProductionSupplier.Text = String.Empty
        txtProductionNetWeight.Text = String.Empty
        txtProductionArrivedDate.Text = String.Empty
        txtProductionVehicle.Text = String.Empty
        txtProductionTotalBunches.Text = String.Empty
        txtProductionFFBDeliveryOrderNo.Text = String.Empty
        txtProductionArrivedTime.Text = String.Empty
        txtProductionDriver.Text = String.Empty
        txtProductionNoTrip.Text = String.Empty
    End Sub

    Public Sub ClearGridView(ByVal grdname As DataGridView)
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

    Private Sub TargetValues()


        Dim dsGradeTarget As New DataSet
        Dim ObjGradeTargetPPT As New GradingFFBPPT
        Dim ObjGradeTargetBOL As New GradingFFBBOL
        dsGradeTarget = ObjGradeTargetBOL.GetGradeValues(ObjGradeTargetPPT)
        If dsGradeTarget.Tables(0).Rows.Count <> 0 Then

            Dim obj As Object = "<="
            Dim objPer As Object = "%"
            Dim ObjGt As Object = ">="
            Dim TempInt As Integer

            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdUnripeBunch").ToString
            If TempInt > 0 Then
                txtProductionUnripeFruitTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionUnripeFruitTarget.Text = 0
            End If

            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdUnderripeBunch").ToString
            If TempInt > 0 Then
                txtProductionUnderRipeTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionUnderRipeTarget.Text = 0
            End If

            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdRipeBunch").ToString
            If TempInt > 0 Then
                txtProductionRipeFruitTarget.Text = String.Concat(ObjGt, TempInt, objPer)
            Else
                txtProductionRipeFruitTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdOvrRipeBunch").ToString
            If TempInt > 0 Then
                txtProductionOverRipeFruitTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionOverRipeFruitTarget.Text = 0
            End If

            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdEmtBunch").ToString
            If TempInt > 0 Then
                txtProductionEmptyBunchFruitTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionEmptyBunchFruitTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdTotNrmFruit").ToString
            If TempInt > 0 Then
                txtProductionTotalNormalFruitsTarget.Text = String.Concat(ObjGt, TempInt, objPer)
            Else
                txtProductionTotalNormalFruitsTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdParthenocarpy").ToString
            If TempInt > 0 Then
                txtProductionParthenocarpicTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionParthenocarpicTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdHardBunch").ToString
            If TempInt > 0 Then
                txtProductionHardBunchTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionHardBunchTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdTotAbnormal").ToString
            If TempInt > 0 Then
                txtProductionTotalAbnormalFruitsTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionTotalAbnormalFruitsTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdGrandTotal").ToString
            txtProductionGrandTotalTarget.Text = TempInt

            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdUndamage").ToString
            If TempInt > 0 Then
                txtProductionUndamageTarget.Text = String.Concat(ObjGt, TempInt, objPer)
            Else
                txtProductionUndamageTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdLightDamage").ToString
            If TempInt > 0 Then
                txtProductionLightDamageTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionLightDamageTarget.Text = 0
            End If


            TempInt = dsGradeTarget.Tables(0).Rows(0).Item("GrdDamage").ToString
            If TempInt > 0 Then
                txtProductionDamageTarget.Text = String.Concat(obj, TempInt, objPer)
            Else
                txtProductionDamageTarget.Text = 0
            End If

            txtProductionTotalTarget.Text = Val(dsGradeTarget.Tables(0).Rows(0).Item("GrdUndamage").ToString) + Val(dsGradeTarget.Tables(0).Rows(0).Item("GrdLightDamage").ToString) + Val(dsGradeTarget.Tables(0).Rows(0).Item("GrdDamage").ToString)
        Else
            DisplayInfoMessage("Msg1")

            '' MsgBox("Please insert a record in Standard Operational Procedure (Production) screen in Web Application to proceed.")
        End If


        

    End Sub
    Private Sub BlockDetails()
        Dim ds As New DataSet
        Dim ObjGradeTargetPPT As New GradingFFBPPT
        Dim ObjGradeTargetBOL As New GradingFFBBOL
        ObjGradeTargetPPT.WBTicketNo = txtProductionWBTicketNo.Text
        ds = ObjGradeTargetBOL.GetBlockDetailValues(ObjGradeTargetPPT)
        dgvBlock.AutoGenerateColumns = False
        dgvBlock.DataSource = ds.Tables(0)
        ClearDataGridText()
        If dgvBlock.Rows.Count > 0 Then
            txtProductionSupplier.Text = dgvBlock.SelectedRows(0).Cells("dgbSupplier").Value.ToString
            txtProductionNetWeight.Text = dgvBlock.SelectedRows(0).Cells("dgbNetWeight").Value.ToString

            If Not dgvBlock.SelectedRows(0).Cells("dgbWeighingDate").Value Is DBNull.Value Then
                txtProductionArrivedDate.Text = Format(dgvBlock.SelectedRows(0).Cells("dgbWeighingDate").Value, "dd/MM/yyyy")
            Else
                txtProductionArrivedDate.Text = String.Empty
            End If
            'Dim lAMPM As String
            'If dgvBlock.SelectedRows(0).Cells("dgclSection").Value.ToString = "Morning" Then
            '    lAMPM = "AM"
            'Else
            '    lAMPM = "PM"
            'End If
            txtProductionVehicle.Text = dgvBlock.SelectedRows(0).Cells("dgbVehicleNo").Value.ToString
            txtProductionTotalBunches.Text = dgvBlock.SelectedRows(0).Cells("dgbTotalBunches").Value.ToString
            txtProductionFFBDeliveryOrderNo.Text = dgvBlock.SelectedRows(0).Cells("dgbFFBDeliveryOrderNo").Value.ToString
            txtProductionArrivedTime.Text = "" & dgvBlock.SelectedRows(0).Cells("dgbWeighinTime").Value.ToString
            txtProductionDriver.Text = dgvBlock.SelectedRows(0).Cells("dgbDriverName").Value.ToString
            txtProductionNoTrip.Text = dgvBlock.SelectedRows(0).Cells("dgbNoTrip").Value.ToString
        End If

        Dim lSumTotalBunches As Decimal = 0
        For Each GridViewRow In dgvBlock.Rows
            lSumTotalBunches = lSumTotalBunches + IIf(GridViewRow.cells("dgbTotalBunches").value Is DBNull.Value, 0, GridViewRow.cells("dgbTotalBunches").value.ToString())
        Next
        If lSumTotalBunches <> 0 Then
            txtProductionTotalBunches.Text = lSumTotalBunches
        End If

    End Sub

    Private Sub GradingFFBfrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnSave.Enabled = True And txtProductionWBTicketNo.Text <> "" And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M86"

            End If
        End If
    End Sub

    Private Sub GradingFFBfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        Clear()
        TargetValues()
        BindDataGrid()
        tabGradingFFB.SelectedTab = tbView
    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingFFBfrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            'tabGradingFFB.TabPages("tbGradingFFB").Text = rm.GetString("tbGradingFFB.TabPages(tbGradingFFB).Text")
            'tabGradingFFB.TabPages("tbView").Text = rm.GetString("tbGradingFFB.TabPages(tbView).Text")
            'PnlSearch.CaptionText = rm.GetString("PnlSearch.CaptionText")

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            ''lblProductionWBTicketNo.Text = rm.GetString("lblProductionWBTicketNo")
            ''lblWBTicketNoSearch.Text = rm.GetString("lblProductionWBTicketNo")
            ''lblProductionComment.Text = rm.GetString("lblProductionComment")
            ''lblProductionDamage.Text = rm.GetString("lblProductionDamage")
            ''lblProductionEmptyBunchFruit.Text = rm.GetString("lblProductionEmptyBunchFruit")
            ''lblProductionFFBDeliveryOrderNo.Text = rm.GetString("lblProductionFFBDeliveryOrderNo")
            ''lblProductionGradingDate.Text = rm.GetString("lblProductionGradingDate")
            ' chkGradingDate.Text = rm.GetString("lblProductionGradingDate")
            ''lblProductionGradingTime.Text = rm.GetString("lblProductionGradingTime")
            ''lblProductionGrandTotal.Text = rm.GetString("lblProductionGrandTotal")
            ''lblProductionHardBunch.Text = rm.GetString("lblProductionHardBunch")
            ''lblProductionKgofFruitLoose.Text = rm.GetString("lblProductionKgofFruitLoose")
            ''lblProductionLightDamage.Text = rm.GetString("lblProductionLightDamage")
            ''lblProductionLooseFruit.Text = rm.GetString("lblProductionLooseFruit")
            ''lblProductionLooseFruitBunches.Text = rm.GetString("lblProductionLooseFruitBunches")
            ''lblProductionMinMaturity.Text = rm.GetString("lblProductionMinMaturity")
            ''lblProductionNetArrivedDate.Text = rm.GetString("lblProductionNetArrivedDate")
            ''lblProductionNetArrivedTime.Text = rm.GetString("lblProductionNetArrivedTime")
            ''lblProductionNetDriver.Text = rm.GetString("lblProductionNetDriver")
            ''lblProductionNetNoTrip.Text = rm.GetString("lblProductionNetNoTrip")
            ''lblProductionNetVehicle.Text = rm.GetString("lblProductionNetVehicle")
            ''lblProductionNetWeight.Text = rm.GetString("lblProductionNetWeight")
            ''lblProductionOverRipeFruit.Text = rm.GetString("lblProductionOverRipeFruit")
            ''lblProductionParthenocarpic.Text = rm.GetString("lblProductionParthenocarpic")
            ''lblProductionRipeFruit.Text = rm.GetString("lblProductionRipeFruit")
            ''lblProductionSupplier.Text = rm.GetString("lblProductionSupplier")
            ''lblProductionTotal.Text = rm.GetString("lblProductionTotal")
            ''lblProductionTotalAbnormalFruits.Text = rm.GetString("lblProductionTotalAbnormalFruits")
            ''lblProductionTotalBunches.Text = rm.GetString("lblProductionTotalBunches")
            ''lblProductionTotalNormalFruits.Text = rm.GetString("lblProductionTotalNormalFruits")
            ''lblProductionUndamage.Text = rm.GetString("lblProductionUndamage")
            ''lblProductionUnderRipe.Text = rm.GetString("lblProductionUnderRipe")
            ''lblProductionUnripeFruit.Text = rm.GetString("lblProductionUnripeFruit")
            ''lblProductionWBTicketNo.Text = rm.GetString("lblProductionWBTicketNo")

            '.Columns("DgclDiv").HeaderText = rm.GetString("Div")
            'dgvBlock.Columns("DgclYOP").HeaderText = rm.GetString("YOP")
            'dgvBlock.Columns("dgclBlock").HeaderText = rm.GetString("SubBlock")

            btnResetIB.Text = rm.GetString("Reset")
            btnSave.Text = rm.GetString("Save")
            btnClose.Text = rm.GetString("Close")
            ''lblsearchBy.Text = rm.GetString("SearchBy")
            'dgvGradingFFBView.Columns("dgclWBTicketNo").HeaderText = rm.GetString("dgProductionWBTicketNo")
            'dgvGradingFFBView.Columns("dgclGradingDate").HeaderText = rm.GetString("dgProductionGradingDate")
            btnSearch.Text = rm.GetString("ViewSearch")
            btnviewReport.Text = rm.GetString("ViewReports")
        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingFFBfrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnWBTicketNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWBTicketNo.Click
        Dim frmWBTicketNo As New WBTicketLookup
        frmWBTicketNo.ShowDialog()
        If frmWBTicketNo._lWeighingID <> String.Empty Then
            Me.txtProductionWBTicketNo.Text = frmWBTicketNo._lWBTicketNo
            lWeighingID = frmWBTicketNo._lWeighingID
            BlockDetails()
        End If
    End Sub


    Private Sub txtProductionWBTicketNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionWBTicketNo.Leave
        If txtProductionWBTicketNo.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objGradingFFBPPT As New GradingFFBPPT
            objGradingFFBPPT.WBTicketNo = txtProductionWBTicketNo.Text.Trim()
            Dim objGradingFFBBOL As New GradingFFBBOL
            ds = objGradingFFBBOL.WBTicketNoLookupSearch(objGradingFFBPPT, "YES")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg2")
                ''MessageBox.Show("Invalid WBTicket No,Please Choose it from look up")
                txtProductionWBTicketNo.Text = String.Empty
                lWeighingID = String.Empty
                txtProductionWBTicketNo.Focus()
                BlockDetails()
                Exit Sub
            Else
                If ds.Tables(0).Rows(0).Item("WBTicketNo").ToString() <> String.Empty Then
                    txtProductionWBTicketNo.Text = ds.Tables(0).Rows(0).Item("WBTicketNo")
                End If
                If ds.Tables(0).Rows(0).Item("WeighingID").ToString() <> String.Empty Then
                    lWeighingID = ds.Tables(0).Rows(0).Item("WeighingID")
                End If
                BlockDetails()
            End If
        Else
            txtProductionWBTicketNo.Text = String.Empty
            lWeighingID = String.Empty
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

                        If txtBox.Text.Trim.Contains("") Then
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
Private Sub KeyDown3kgDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
                            is3kgDecimal = False
                            Return
                        End If

                        is3kgDecimal = True
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

                        is3kgDecimal = re3kgDecimalPlaces.IsMatch(text)

                End Select
            Else
                is3kgDecimal = False
                Return
            End If

        Else
            is3kgDecimal = True
        End If

    End Sub
    Private Sub KeyPress3kgDecimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is3kgDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub txtProductionUnripeFruitJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionUnripeFruitJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionUnripeFruitJJ_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionUnripeFruitJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub
    Private Sub txtProductionUnderRipeJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionUnderRipeJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionUnderRipeJJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionUnderRipeJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub
    Private Sub txtProductionRipeFruitJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionRipeFruitJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionRipeFruitJJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionRipeFruitJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionOverRipeFruitJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionOverRipeFruitJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionOverRipeFruitJJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionOverRipeFruitJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionEmptyBunchFruitJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionEmptyBunchFruitJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionEmptyBunchFruitJJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionEmptyBunchFruitJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionParthenocarpicJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionParthenocarpicJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionParthenocarpicJJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionParthenocarpicJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionHardBunchJJ_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionHardBunchJJ.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionHardBunchJJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionHardBunchJJ.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub
    Private Sub txtProductionLooseFruit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionLooseFruit.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionLooseFruit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionLooseFruit.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionKgofFruitLoose_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionKgofFruitLoose.KeyDown
        KeyDown3kgDecimal(sender, e)
    End Sub

    Private Sub txtProductionKgofFruitLoose_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionKgofFruitLoose.KeyPress
        KeyPress3kgDecimal(sender, e)
    End Sub

    Private Sub txtProductionUndamageTotalBunch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionUndamageTotalBunch.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub
    Private Sub txtProductionUndamageTotalBunch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionUndamageTotalBunch.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionLightDamageTotalBunch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionLightDamageTotalBunch.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionLightDamageTotalBunch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionLightDamageTotalBunch.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionDamageTotalBunch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionDamageTotalBunch.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionDamageTotalBunch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionDamageTotalBunch.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionTotalBunch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionTotalBunch.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtProductionTotalBunch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionTotalBunch.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtProductionUnripeFruitJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionUnripeFruitJJ.TextChanged
        If txtProductionUnripeFruitJJ.Text <> String.Empty Then
            lUnripeFruitJJ = txtProductionUnripeFruitJJ.Text
        Else
            lUnripeFruitJJ = 0
        End If
        lTotalNormalFruitsJJ = lUnderRipeJJ + lRipeFruitJJ + lOverRipeFruitJJ + lEmptyBunchFruitJJ + lUnripeFruitJJ + lLooseFruitorBunch
        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsJJ.Text = lTotalNormalFruitsJJ
        Else
            txtProductionTotalNormalFruitsJJ.Text = 0
        End If

    End Sub

    Private Sub txtProductionUnderRipeJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionUnderRipeJJ.TextChanged
        If txtProductionUnderRipeJJ.Text <> String.Empty Then
            lUnderRipeJJ = txtProductionUnderRipeJJ.Text
        Else
            lUnderRipeJJ = 0
        End If
        lTotalNormalFruitsJJ = lUnderRipeJJ + lRipeFruitJJ + lOverRipeFruitJJ + lEmptyBunchFruitJJ + lUnripeFruitJJ + lLooseFruitorBunch
        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsJJ.Text = lTotalNormalFruitsJJ
        Else
            txtProductionTotalNormalFruitsJJ.Text = 0
        End If
    End Sub

    Private Sub txtProductionRipeFruitJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionRipeFruitJJ.TextChanged
        If txtProductionRipeFruitJJ.Text <> String.Empty Then
            lRipeFruitJJ = txtProductionRipeFruitJJ.Text
        Else
            lRipeFruitJJ = 0
        End If
        lTotalNormalFruitsJJ = lUnderRipeJJ + lRipeFruitJJ + lOverRipeFruitJJ + lEmptyBunchFruitJJ + lUnripeFruitJJ + lLooseFruitorBunch
        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsJJ.Text = lTotalNormalFruitsJJ
        Else
            txtProductionTotalNormalFruitsJJ.Text = 0
        End If
    End Sub

    Private Sub txtProductionOverRipeFruitJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionOverRipeFruitJJ.TextChanged
        If txtProductionOverRipeFruitJJ.Text <> String.Empty Then
            lOverRipeFruitJJ = txtProductionOverRipeFruitJJ.Text
        Else
            lOverRipeFruitJJ = 0
        End If
        lTotalNormalFruitsJJ = lUnderRipeJJ + lRipeFruitJJ + lOverRipeFruitJJ + lEmptyBunchFruitJJ + lUnripeFruitJJ + lLooseFruitorBunch
        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsJJ.Text = lTotalNormalFruitsJJ
        Else
            txtProductionTotalNormalFruitsJJ.Text = 0
        End If
    End Sub

    Private Sub txtProductionEmptyBunchFruitJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionEmptyBunchFruitJJ.TextChanged
        If txtProductionEmptyBunchFruitJJ.Text <> String.Empty Then
            lEmptyBunchFruitJJ = txtProductionEmptyBunchFruitJJ.Text
        Else
            lEmptyBunchFruitJJ = 0
        End If
        lTotalNormalFruitsJJ = lUnderRipeJJ + lRipeFruitJJ + lOverRipeFruitJJ + lEmptyBunchFruitJJ + lUnripeFruitJJ + lLooseFruitorBunch
        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsJJ.Text = lTotalNormalFruitsJJ
        Else
            txtProductionTotalNormalFruitsJJ.Text = 0
        End If
    End Sub

    Private Sub txtProductionLooseFruitorBunch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionLooseFruitorBunch.KeyPress
        'KeyPress3Decimal(sender, e)
        'if the decimal digits reaches more than 2 digits then stop entering
        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If

    End Sub


    Private Sub txtProductionLooseFruitorBunch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionLooseFruitorBunch.TextChanged
        If txtProductionLooseFruitorBunch.Text <> String.Empty Then
            lLooseFruitorBunch = txtProductionLooseFruitorBunch.Text
        Else
            lLooseFruitorBunch = 0
        End If
        lTotalNormalFruitsJJ = lUnderRipeJJ + lRipeFruitJJ + lOverRipeFruitJJ + lEmptyBunchFruitJJ + lUnripeFruitJJ + lLooseFruitorBunch
        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsJJ.Text = lTotalNormalFruitsJJ
        Else
            txtProductionTotalNormalFruitsJJ.Text = 0
        End If
    End Sub
    Private Sub txtProductionTotalNormalFruitsJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionTotalNormalFruitsJJ.TextChanged

        If lTotalNormalFruitsJJ <> 0 Or lTotalAbnormalFruitsJJ <> 0 Then
            txtProductionGrandTotalJJ.Text = Round((lTotalNormalFruitsJJ + lTotalAbnormalFruitsJJ), 2)
        Else
            txtProductionGrandTotalJJ.Text = 0
        End If
        If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsPercentage.Text = Round((lTotalNormalFruitsJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionTotalNormalFruitsPercentage.Text = 0
        End If
        If lTotalAbnormalFruitsJJ > 0 And txtProductionGrandTotalJJ.Text <> "" And Val(txtProductionGrandTotalJJ.Text) <> 0 Then
            txtProductionTotalAbnormalFruitsPercentage.Text = Round((txtProductionTotalAbnormalFruitsJJ.Text / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionTotalAbnormalFruitsPercentage.Text = 0
        End If

        If Val(txtProductionGrandTotalJJ.Text) <> 0 Then
            If lUnripeFruitJJ > 0 And Val(txtProductionGrandTotalJJ.Text) <> 0 Then
                txtProductionUnripeFruitPercentage.Text = Round((lUnripeFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionUnripeFruitPercentage.Text = 0
            End If
            If lUnderRipeJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionUnderRipePercentage.Text = Round((lUnderRipeJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionUnderRipePercentage.Text = 0
            End If
            If lRipeFruitJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionRipeFruitPercentage.Text = Round((lRipeFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionRipeFruitPercentage.Text = 0
            End If
            If lOverRipeFruitJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionOverRipeFruitPercentage.Text = Round((lOverRipeFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionOverRipeFruitPercentage.Text = 0
            End If
            If lEmptyBunchFruitJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionEmptyBunchFruitPercentage.Text = Round((lEmptyBunchFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionEmptyBunchFruitPercentage.Text = 0
            End If
        Else
            txtProductionUnripeFruitPercentage.Text = ""
            txtProductionUnderRipePercentage.Text = ""
            txtProductionRipeFruitPercentage.Text = ""
            txtProductionOverRipeFruitPercentage.Text = ""
            txtProductionEmptyBunchFruitPercentage.Text = ""
            txtProductionTotalNormalFruitsPercentage.Text = ""
        End If

        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsPercentage.Text = Round((lTotalNormalFruitsJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionTotalNormalFruitsPercentage.Text = 0
        End If
    End Sub

    Private Sub txtProductionMinMaturity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionMinMaturity.KeyDown
        KeyDown3kgDecimal(sender, e)
    End Sub

    Private Sub txtProductionMinMaturity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProductionMinMaturity.KeyPress
        KeyPress3kgDecimal(sender, e)
    End Sub

    Private Sub txtProductionLooseFruitorBunch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionLooseFruitorBunch.KeyDown
        'KeyDown3Decimal(sender, e)


        If e.Modifiers = Keys.Alt OrElse e.Modifiers = Keys.Insert OrElse e.Modifiers = Keys.Shift OrElse e.Modifiers = Keys.Control Then
            Return
        End If

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

        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{Tab}")
        End If

    End Sub

    Private Sub txtProductionParthenocarpicJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionParthenocarpicJJ.TextChanged
        If txtProductionParthenocarpicJJ.Text <> String.Empty And Val(txtProductionParthenocarpicJJ.Text) <> 0 Then
            lParthenocarpicJJ = txtProductionParthenocarpicJJ.Text
            txtProductionParthenocarpicPercentage.Text = Round((lParthenocarpicJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionParthenocarpicPercentage.Text = 0
            lParthenocarpicJJ = 0
        End If
        lTotalAbnormalFruitsJJ = lParthenocarpicJJ + lHardBunchJJ
        If lTotalAbnormalFruitsJJ > 0 Then
            txtProductionTotalAbnormalFruitsJJ.Text = lTotalAbnormalFruitsJJ
        Else
            txtProductionTotalAbnormalFruitsJJ.Text = 0
        End If
    End Sub

    Private Sub txtProductionHardBunchJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionHardBunchJJ.TextChanged
        If txtProductionHardBunchJJ.Text <> String.Empty And Val(txtProductionHardBunchJJ.Text) <> 0 Then
            lHardBunchJJ = txtProductionHardBunchJJ.Text
            txtProductionHardBunchPercentage.Text = Round((lHardBunchJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            lHardBunchJJ = 0
            txtProductionHardBunchPercentage.Text = 0
        End If
        lTotalAbnormalFruitsJJ = lParthenocarpicJJ + lHardBunchJJ
        If lTotalAbnormalFruitsJJ > 0 Then
            txtProductionTotalAbnormalFruitsJJ.Text = lTotalAbnormalFruitsJJ
        Else
            txtProductionTotalAbnormalFruitsJJ.Text = 0
        End If
    End Sub


    Private Sub txtProductionTotalAbnormalFruitsJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionTotalAbnormalFruitsJJ.TextChanged
        If lTotalNormalFruitsJJ <> 0 Or lTotalAbnormalFruitsJJ <> 0 Then
            txtProductionGrandTotalJJ.Text = Round((lTotalNormalFruitsJJ + lTotalAbnormalFruitsJJ), 2)
        Else
            txtProductionGrandTotalJJ.Text = 0
        End If
        If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsPercentage.Text = Round((lTotalNormalFruitsJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionTotalNormalFruitsPercentage.Text = 0
        End If
        If lTotalAbnormalFruitsJJ > 0 And txtProductionGrandTotalJJ.Text <> "" And Val(txtProductionGrandTotalJJ.Text) <> 0 Then
            txtProductionTotalAbnormalFruitsPercentage.Text = Round((txtProductionTotalAbnormalFruitsJJ.Text / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionTotalAbnormalFruitsPercentage.Text = 0
        End If


        If Val(txtProductionGrandTotalJJ.Text) <> 0 Then
            If lUnripeFruitJJ > 0 And Val(txtProductionGrandTotalJJ.Text) <> 0 Then
                txtProductionUnripeFruitPercentage.Text = Round((lUnripeFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionUnripeFruitPercentage.Text = 0
            End If
            If lUnderRipeJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionUnderRipePercentage.Text = Round((lUnderRipeJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionUnderRipePercentage.Text = 0
            End If
            If lRipeFruitJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionRipeFruitPercentage.Text = Round((lRipeFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionRipeFruitPercentage.Text = 0
            End If
            If lOverRipeFruitJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionOverRipeFruitPercentage.Text = Round((lOverRipeFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionOverRipeFruitPercentage.Text = 0
            End If
            If lEmptyBunchFruitJJ > 0 And Val(txtProductionTotalNormalFruitsJJ.Text) <> 0 Then
                txtProductionEmptyBunchFruitPercentage.Text = Round((lEmptyBunchFruitJJ / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
            Else
                txtProductionEmptyBunchFruitPercentage.Text = 0
            End If
        Else
            txtProductionUnripeFruitPercentage.Text = ""
            txtProductionUnderRipePercentage.Text = ""
            txtProductionRipeFruitPercentage.Text = ""
            txtProductionOverRipeFruitPercentage.Text = ""
            txtProductionEmptyBunchFruitPercentage.Text = ""
            txtProductionTotalNormalFruitsPercentage.Text = ""
        End If

        If lTotalNormalFruitsJJ > 0 Then
            txtProductionTotalNormalFruitsPercentage.Text = Round((lTotalNormalFruitsJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionTotalNormalFruitsPercentage.Text = 0
        End If


    End Sub

    Private Sub txtProductionGrandTotalJJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionGrandTotalJJ.TextChanged
        If txtProductionGrandTotalJJ.Text <> String.Empty And lParthenocarpicJJ <> 0 Then
            txtProductionParthenocarpicPercentage.Text = Round((lParthenocarpicJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        End If
        If txtProductionGrandTotalJJ.Text <> String.Empty And lHardBunchJJ <> 0 Then
            txtProductionHardBunchPercentage.Text = Round((lHardBunchJJ / txtProductionGrandTotalJJ.Text) * 100, 2)
        End If

        If Val(txtProductionGrandTotalJJ.Text) > 0 Then
            txtProductionGrandTotalPercentage.Text = 100
        Else
            txtProductionGrandTotalPercentage.Text = 0
        End If

        If lTotalNormalFruitsJJ > 0 Or lTotalAbnormalFruitsJJ > 0 Then
            txtProductionGrandTotalJJ.Text = Math.Round((lTotalNormalFruitsJJ + lTotalAbnormalFruitsJJ), 2)
        End If
        If Val(txtProductionGrandTotalJJ.Text) = 0 And txtProductionGrandTotalJJ.Text <> "" Then
            txtProductionUndamagePercentage.Text = 0
            txtProductionLightDamagePercentage.Text = 0
            txtProductionDamagePercentage.Text = 0
        Else
            If lUndamageTotalBunch > 0 Then
                txtProductionUndamagePercentage.Text = Round((lUndamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
            End If
            If lDamageTotalBunch > 0 Then
                txtProductionDamagePercentage.Text = Round((lDamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
            End If
            If lLightDamageTotalBunch > 0 Then
                txtProductionLightDamagePercentage.Text = Round((lLightDamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
            End If
        End If

        If Val(txtProductionTotalBunch.Text) <> 0 And Val(txtProductionGrandTotalJJ.Text) <> 0 And txtProductionTotalBunch.Text <> "" And txtProductionGrandTotalJJ.Text <> "" Then
            txtProductionTotalPercentage.Text = Math.Round((Val(txtProductionTotalBunch.Text) / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
        ElseIf txtProductionTotalBunch.Text = "" And txtProductionGrandTotalJJ.Text = "" Then
            txtProductionTotalPercentage.Text = ""
        Else
            txtProductionTotalPercentage.Text = "0"
        End If


    End Sub

    Private Sub txtProductionUndamageTotalBunch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionUndamageTotalBunch.TextChanged
        If txtProductionUndamageTotalBunch.Text <> String.Empty Then
            lUndamageTotalBunch = txtProductionUndamageTotalBunch.Text
        Else
            lUndamageTotalBunch = 0
        End If
        lTotalBunch = lUndamageTotalBunch + lDamageTotalBunch + lLightDamageTotalBunch
        If lTotalBunch > 0 Then
            txtProductionTotalBunch.Text = lTotalBunch
        Else
            txtProductionTotalBunch.Text = 0
        End If
        If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lUndamageTotalBunch <> 0 Then
            txtProductionUndamagePercentage.Text = Round((lUndamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionUndamagePercentage.Text = 0
        End If

    End Sub

    Private Sub txtProductionLightDamageTotalBunch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionLightDamageTotalBunch.TextChanged
        If txtProductionLightDamageTotalBunch.Text <> String.Empty Then
            lLightDamageTotalBunch = txtProductionLightDamageTotalBunch.Text
        Else
            lLightDamageTotalBunch = 0
        End If
        lTotalBunch = lUndamageTotalBunch + lDamageTotalBunch + lLightDamageTotalBunch
        If lTotalBunch > 0 Then
            txtProductionTotalBunch.Text = lTotalBunch
        Else
            txtProductionTotalBunch.Text = 0
        End If
        If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lLightDamageTotalBunch <> 0 Then
            txtProductionLightDamagePercentage.Text = Round((lLightDamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionLightDamagePercentage.Text = 0
        End If
    End Sub

    Private Sub txtProductionDamageTotalBunch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionDamageTotalBunch.TextChanged
        If txtProductionDamageTotalBunch.Text <> String.Empty Then
            lDamageTotalBunch = txtProductionDamageTotalBunch.Text
        Else
            lDamageTotalBunch = 0
        End If
        lTotalBunch = lUndamageTotalBunch + lDamageTotalBunch + lLightDamageTotalBunch
        If lTotalBunch > 0 Then
            txtProductionTotalBunch.Text = lTotalBunch
        Else
            txtProductionTotalBunch.Text = 0
        End If
        If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lDamageTotalBunch <> 0 Then
            txtProductionDamagePercentage.Text = Round((lDamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
        Else
            txtProductionDamagePercentage.Text = 0
        End If

    End Sub

    Private Sub txtProductionTotalBunch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionTotalBunch.TextChanged
        If txtProductionTotalBunch.Text <> String.Empty Then
            If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lUndamageTotalBunch <> 0 Then
                txtProductionUndamagePercentage.Text = Round((lUndamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
            Else
                txtProductionUndamagePercentage.Text = 0
            End If
            If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lLightDamageTotalBunch <> 0 Then
                txtProductionLightDamagePercentage.Text = Round((lLightDamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
            Else
                txtProductionLightDamagePercentage.Text = 0
            End If
            If txtProductionGrandTotalJJ.Text <> String.Empty And Val(txtProductionGrandTotalJJ.Text) <> 0 And lDamageTotalBunch <> 0 Then
                txtProductionDamagePercentage.Text = Round((lDamageTotalBunch / txtProductionGrandTotalJJ.Text) * 100, 2)
            Else
                txtProductionDamagePercentage.Text = 0
            End If
        End If
        If Val(txtProductionTotalBunch.Text) <> 0 And Val(txtProductionGrandTotalJJ.Text) <> 0 And txtProductionTotalBunch.Text <> "" And txtProductionGrandTotalJJ.Text <> "" Then
            txtProductionTotalPercentage.Text = Math.Round((Val(txtProductionTotalBunch.Text) / Val(txtProductionGrandTotalJJ.Text)) * 100, 2)
        ElseIf txtProductionTotalBunch.Text = "" And txtProductionGrandTotalJJ.Text = "" Then
            txtProductionTotalPercentage.Text = ""
        Else
            txtProductionTotalPercentage.Text = "0"
        End If

    End Sub
    Private Sub SaveDatas()
        Dim ds As New DataSet

        Dim ObjGradingFFBPPT As New GradingFFBPPT
        Dim ObjGradingFFBBOL As New GradingFFBBOL
        With ObjGradingFFBPPT
            '    .WBTicketNo = txtProductionWBTicketNo.Text
            '    Dim objExists As Object
            '    objExists = ObjGradingFFBBOL.DuplicateGradingFFBCheck(ObjGradingFFBPPT)
            '    If objExists = 0 Then
            '        MsgBox("Cannot add a record for WBTicket no. Please  again with a different WBTicket no.")
            '        Exit Sub
            '    End If

            .WeighingID = lWeighingID
            .GradingDate = dtProductionGradingDate.Value
            'lHrs = cmbHrs.Text
            'lmin = cmbMin.Text

            .GradingTime = txtGradingTime.Text
            If txtProductionMinMaturity.Text <> String.Empty Then
                .MinMaturity = txtProductionMinMaturity.Text
            End If


            If txtProductionLooseFruitorBunch.Text <> String.Empty Then
                .LosseFruitPerBunche = txtProductionLooseFruitorBunch.Text
            End If
            If txtProductionUnripeFruitJJ.Text <> String.Empty Then
                .UnripeFruitJ = txtProductionUnripeFruitJJ.Text
            End If
            If txtProductionUnripeFruitPercentage.Text <> String.Empty Then
                .UnripeFruitP = txtProductionUnripeFruitPercentage.Text
            End If
            .UnripeFruitT = txtProductionUnripeFruitTarget.Text

            If txtProductionUnderRipeJJ.Text <> String.Empty Then
                .UnderripeJ = txtProductionUnderRipeJJ.Text
            End If
            If txtProductionUnderRipePercentage.Text <> String.Empty Then
                .UnderripeP = txtProductionUnderRipePercentage.Text
            End If
            .UnderripeT = txtProductionUnderRipeTarget.Text
            If txtProductionRipeFruitJJ.Text <> String.Empty Then
                .RipeFruitJ = txtProductionRipeFruitJJ.Text
            End If
            If txtProductionRipeFruitPercentage.Text <> String.Empty Then
                .RipeFruitP = txtProductionRipeFruitPercentage.Text
            End If
            .RipeFruitT = txtProductionRipeFruitTarget.Text
            If txtProductionOverRipeFruitJJ.Text <> String.Empty Then
                .OverRipeFruitJ = txtProductionOverRipeFruitJJ.Text
            End If
            If txtProductionOverRipeFruitPercentage.Text <> String.Empty Then
                .OverRipeFruitP = txtProductionOverRipeFruitPercentage.Text
            End If
            .OverRipeFruitT = txtProductionOverRipeFruitTarget.Text

            If txtProductionEmptyBunchFruitJJ.Text <> String.Empty Then
                .EmptyBunchFruitJ = txtProductionEmptyBunchFruitJJ.Text
            End If
            If txtProductionEmptyBunchFruitPercentage.Text <> String.Empty Then
                .EmptyBunchFruitP = txtProductionEmptyBunchFruitPercentage.Text
            End If
            .EmptyBunchFruitT = txtProductionEmptyBunchFruitTarget.Text

            If txtProductionTotalNormalFruitsJJ.Text <> String.Empty Then
                .TotalNormalFruitsJ = txtProductionTotalNormalFruitsJJ.Text
            End If
            If txtProductionTotalNormalFruitsPercentage.Text <> String.Empty Then
                .TotalNormalFruitsP = txtProductionTotalNormalFruitsPercentage.Text
            End If
            .TotalNormalFruitsT = txtProductionTotalNormalFruitsTarget.Text

            If txtProductionParthenocarpicJJ.Text <> String.Empty Then
                .PartheJ = txtProductionParthenocarpicJJ.Text
            End If
            If txtProductionParthenocarpicPercentage.Text <> String.Empty Then
                .PartheP = txtProductionParthenocarpicPercentage.Text
            End If
            .PartheT = txtProductionParthenocarpicTarget.Text

            If txtProductionHardBunchJJ.Text <> String.Empty Then
                .HardBunchJ = txtProductionHardBunchJJ.Text
            End If
            If txtProductionHardBunchPercentage.Text <> String.Empty Then
                .HardBunchP = txtProductionHardBunchPercentage.Text
            End If
            .HardBunchT = txtProductionHardBunchTarget.Text

            If txtProductionTotalAbnormalFruitsJJ.Text <> String.Empty Then
                .TotalAbnormalFruitsJ = txtProductionTotalAbnormalFruitsJJ.Text
            End If
            If txtProductionTotalAbnormalFruitsPercentage.Text <> String.Empty Then
                .TotalAbnormalFruitsP = txtProductionTotalAbnormalFruitsPercentage.Text
            End If
            .TotalAbnormalFruitsT = txtProductionTotalAbnormalFruitsTarget.Text

            If txtProductionGrandTotalJJ.Text <> String.Empty Then
                .GTActualBunchesJ = txtProductionGrandTotalJJ.Text
            End If
            If txtProductionGrandTotalPercentage.Text <> String.Empty Then
                .GTActualBunchesP = txtProductionGrandTotalPercentage.Text
            End If
            .GTActualBunchesT = txtProductionGrandTotalTarget.Text
            If txtProductionLooseFruit.Text <> String.Empty Then
                .LooseFruitsP = txtProductionLooseFruit.Text
            End If
            If txtProductionKgofFruitLoose.Text <> String.Empty Then
                .KgOfLooseFruit = txtProductionKgofFruitLoose.Text
            End If
            'If txtProductionUndamageTotalBunch.Text <> String.Empty Then
            '    .UnDamageJ = txtProductionUndamageTotalBunch.Text
            'End If
            'If txtProductionUndamagePercentage.Text <> String.Empty Then
            '    .UnDamageP = txtProductionUndamagePercentage.Text
            'End If
            '.UnDamageT = txtProductionUndamageTarget.Text

            If txtProductionLightDamageTotalBunch.Text <> String.Empty Then
                .LightDamageJ = txtProductionLightDamageTotalBunch.Text
            End If
            If txtProductionLightDamagePercentage.Text <> String.Empty Then
                .LightDamageP = txtProductionLightDamagePercentage.Text
            End If
            .LightDamageT = txtProductionLightDamageTarget.Text

            'If txtProductionDamageTotalBunch.Text <> String.Empty Then
            '    .DamageJ = txtProductionDamageTotalBunch.Text
            'End If
            'If txtProductionDamagePercentage.Text <> String.Empty Then
            '    .DamageP = txtProductionDamagePercentage.Text
            'End If
            '.DamageT = txtProductionDamageTarget.Text

            If txtProductionTotalBunch.Text <> String.Empty Then
                .TotalJ = txtProductionTotalBunch.Text
                .TotalP = txtProductionTotalPercentage.Text
            End If
            .TotalT = txtProductionTotalTarget.Text

            If txtBatuKerikil.Text <> String.Empty Then
                .BatuKerikil = txtBatuKerikil.Text.Trim
            End If

            If txtProductionComment.Text <> String.Empty Then
                .Comment = txtProductionComment.Text.Trim
            End If

        End With

        ds = GradingFFBBOL.saveGradingFFB(ObjGradingFFBPPT)

        If ds Is Nothing Then
            DisplayInfoMessage("Msg3")
            '' MsgBox("Failed to save database")
        Else
            Clear()
            ClearDataGridText()
            ClearGridView(dgvBlock)
            BindDataGrid()
            DisplayInfoMessage("Msg4")
            ''MsgBox("Data Successfully Saved!")
        End If
        GlobalPPT.IsRetainFocus = False

    End Sub
    Private Sub UpdateDatas()
        Dim ds As New DataSet

        Dim ObjGradingFFBPPT As New GradingFFBPPT
        Dim ObjGradingFFBBOL As New GradingFFBBOL
        With ObjGradingFFBPPT
            .WBTicketNo = txtProductionWBTicketNo.Text
            If lWBTicketNo <> txtProductionWBTicketNo.Text Then
                Dim objExists As Object
                objExists = ObjGradingFFBBOL.DuplicateGradingFFBCheck(ObjGradingFFBPPT)
                If objExists = 0 Then
                    DisplayInfoMessage("Msg5")
                    ''MsgBox("Cannot add a record for WBTicket no. Please  again with a different WBTicket no.")
                    Exit Sub
                End If
            End If


            .GradingID = lgradingID
            .WeighingID = lWeighingID
            .GradingDate = dtProductionGradingDate.Value
        

            .GradingTime = txtGradingTime.Text
            If txtProductionMinMaturity.Text <> String.Empty Then
                .MinMaturity = txtProductionMinMaturity.Text
            End If
            If txtProductionLooseFruitorBunch.Text <> String.Empty Then
                .LosseFruitPerBunche = txtProductionLooseFruitorBunch.Text
            End If
            If txtProductionUnripeFruitJJ.Text <> String.Empty Then
                .UnripeFruitJ = txtProductionUnripeFruitJJ.Text
            End If
            If txtProductionUnripeFruitPercentage.Text <> String.Empty Then
                .UnripeFruitP = txtProductionUnripeFruitPercentage.Text
            End If
            .UnripeFruitT = txtProductionUnripeFruitTarget.Text

            If txtProductionUnderRipeJJ.Text <> String.Empty Then
                .UnderripeJ = txtProductionUnderRipeJJ.Text
            End If
            If txtProductionUnderRipePercentage.Text <> String.Empty Then
                .UnderripeP = txtProductionUnderRipePercentage.Text
            End If
            .UnderripeT = txtProductionUnderRipeTarget.Text
            If txtProductionRipeFruitJJ.Text <> String.Empty Then
                .RipeFruitJ = txtProductionRipeFruitJJ.Text
            End If
            If txtProductionRipeFruitPercentage.Text <> String.Empty Then
                .RipeFruitP = txtProductionRipeFruitPercentage.Text
            End If
            .RipeFruitT = txtProductionRipeFruitTarget.Text
            If txtProductionOverRipeFruitJJ.Text <> String.Empty Then
                .OverRipeFruitJ = txtProductionOverRipeFruitJJ.Text
            End If
            If txtProductionOverRipeFruitPercentage.Text <> String.Empty Then
                .OverRipeFruitP = txtProductionOverRipeFruitPercentage.Text
            End If
            .OverRipeFruitT = txtProductionOverRipeFruitTarget.Text

            If txtProductionEmptyBunchFruitJJ.Text <> String.Empty Then
                .EmptyBunchFruitJ = txtProductionEmptyBunchFruitJJ.Text
            End If
            If txtProductionEmptyBunchFruitPercentage.Text <> String.Empty Then
                .EmptyBunchFruitP = txtProductionEmptyBunchFruitPercentage.Text
            End If
            .EmptyBunchFruitT = txtProductionEmptyBunchFruitTarget.Text

            If txtProductionTotalNormalFruitsJJ.Text <> String.Empty Then
                .TotalNormalFruitsJ = txtProductionTotalNormalFruitsJJ.Text
            End If
            If txtProductionTotalNormalFruitsPercentage.Text <> String.Empty Then
                .TotalNormalFruitsP = txtProductionTotalNormalFruitsPercentage.Text
            End If
            .TotalNormalFruitsT = txtProductionTotalNormalFruitsTarget.Text

            If txtProductionParthenocarpicJJ.Text <> String.Empty Then
                .PartheJ = txtProductionParthenocarpicJJ.Text
            End If
            If txtProductionParthenocarpicPercentage.Text <> String.Empty Then
                .PartheP = txtProductionParthenocarpicPercentage.Text
            End If
            .PartheT = txtProductionParthenocarpicTarget.Text

            If txtProductionHardBunchJJ.Text <> String.Empty Then
                .HardBunchJ = txtProductionHardBunchJJ.Text
            End If
            If txtProductionHardBunchPercentage.Text <> String.Empty Then
                .HardBunchP = txtProductionHardBunchPercentage.Text
            End If
            .HardBunchT = txtProductionHardBunchTarget.Text

            If txtProductionTotalAbnormalFruitsJJ.Text <> String.Empty Then
                .TotalAbnormalFruitsJ = txtProductionTotalAbnormalFruitsJJ.Text
            End If
            If txtProductionTotalAbnormalFruitsPercentage.Text <> String.Empty Then
                .TotalAbnormalFruitsP = txtProductionTotalAbnormalFruitsPercentage.Text
            End If
            .TotalAbnormalFruitsT = txtProductionTotalAbnormalFruitsTarget.Text

            If txtProductionGrandTotalJJ.Text <> String.Empty Then
                .GTActualBunchesJ = txtProductionGrandTotalJJ.Text
            End If
            If txtProductionGrandTotalPercentage.Text <> String.Empty Then
                .GTActualBunchesP = txtProductionGrandTotalPercentage.Text
            End If
            .GTActualBunchesT = txtProductionGrandTotalTarget.Text
            If txtProductionLooseFruit.Text <> String.Empty Then
                .LooseFruitsP = txtProductionLooseFruit.Text
            End If
            If txtProductionKgofFruitLoose.Text <> String.Empty Then
                .KgOfLooseFruit = txtProductionKgofFruitLoose.Text
            End If
            'If txtProductionUndamageTotalBunch.Text <> String.Empty Then
            '    .UnDamageJ = txtProductionUndamageTotalBunch.Text
            'End If
            'If txtProductionUndamagePercentage.Text <> String.Empty Then
            '    .UnDamageP = txtProductionUndamagePercentage.Text
            'End If
            '.UnDamageT = txtProductionUndamageTarget.Text

            If txtProductionLightDamageTotalBunch.Text <> String.Empty Then
                .LightDamageJ = txtProductionLightDamageTotalBunch.Text
            End If
            If txtProductionLightDamagePercentage.Text <> String.Empty Then
                .LightDamageP = txtProductionLightDamagePercentage.Text
            End If
            .LightDamageT = txtProductionLightDamageTarget.Text

            'If txtProductionDamageTotalBunch.Text <> String.Empty Then
            '    .DamageJ = txtProductionDamageTotalBunch.Text
            'End If
            'If txtProductionDamagePercentage.Text <> String.Empty Then
            '    .DamageP = txtProductionDamagePercentage.Text
            'End If
            '.DamageT = txtProductionDamageTarget.Text

            If txtProductionTotalBunch.Text <> String.Empty Then
                .TotalJ = txtProductionTotalBunch.Text
                .TotalP = txtProductionTotalPercentage.Text
            End If
            .TotalT = txtProductionTotalTarget.Text
            If txtBatuKerikil.Text <> String.Empty Then
                .BatuKerikil = txtBatuKerikil.Text.Trim
            End If

            If txtProductionComment.Text <> String.Empty Then
                .Comment = txtProductionComment.Text.Trim
            End If
        End With

        ds = ObjGradingFFBBOL.UpdateGradingFFB(ObjGradingFFBPPT)

        If ds Is Nothing Then
            DisplayInfoMessage("Msg3")
            'MsgBox("Failed to save database")
        Else
            Clear()
            ClearDataGridText()
            ClearGridView(dgvBlock)
            BindDataGrid()
            DisplayInfoMessage("Msg6")
            '' MsgBox("Data Successfully Updated!")
        End If
        GlobalPPT.IsRetainFocus = False
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtProductionWBTicketNo.Text = String.Empty Then
            DisplayInfoMessage("Msg7")
            'MessageBox.Show("This field is required.", "WBWicket No")
            txtProductionWBTicketNo.Focus()
            Exit Sub
        End If

        If txtGradingTime.Text = String.Empty Then
            DisplayInfoMessage("Msg80")
            'MessageBox.Show("This field is required.", "WBWicket No")
            txtGradingTime.Focus()
            Exit Sub
        End If

        If txtProductionTotalNormalFruitsJJ.Text = String.Empty Or Val(txtProductionTotalNormalFruitsJJ.Text) = 0 Then
            DisplayInfoMessage("Msg8")
            'MessageBox.Show("This field is required.", "Total Normal Fruits")
            txtProductionUnripeFruitJJ.Focus()
            Exit Sub
        End If


        'If Val(txtProductionTotalBunches.Text) <> (Val(txtProductionGrandTotalJJ.Text) + Val(txtProductionTotalBunch.Text)) Then
        '    MessageBox.Show("Sum of Grand Total(Actual Bunches) and Total of Rat Bitten should be equal to Total Bunches.", "BSP")
        '    txtProductionUnripeFruitJJ.Focus()
        '    Exit Sub
        'End If

        If Val(txtProductionNetWeight.Text) < Val(txtProductionKgofFruitLoose.Text) Then
            DisplayInfoMessage("Msg9")
            'MessageBox.Show("Kg of Fruit Loose should be Less than Net Weight(Kgs).", "BSP")
            txtProductionKgofFruitLoose.Focus()
            Exit Sub
        End If

        'If MsgBox(rm.GetString("Msg62"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If

        If lBtnSave = "Save" Then
            SaveDatas()
        Else
            UpdateDatas()
        End If

    End Sub

    Private Sub btnResetIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetIB.Click
        Clear()
        ClearGridView(dgvBlock)
        ClearDataGridText()
        txtProductionWBTicketNo.Focus()
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If txtProductionWBTicketNo.Text <> "" And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg10"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
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
    Private Sub BindDataGrid()

        Dim objGradingFFBPPT As New GradingFFBPPT
        Dim objGradingFFBBOL As New GradingFFBBOL
        Dim dt As New DataTable

        With objGradingFFBPPT

            If chkGradingDate.Checked = True Then
                dtpViewGradingDate.Enabled = True
                .lGradingDate = Format(Me.dtpViewGradingDate.Value, "yyyy/MM/dd")
            Else
                dtpViewGradingDate.Enabled = False
                .lGradingDate = "01/01/1900"

            End If
            .WBTicketNo = Me.txtWBTicketNoSearch.Text.Trim
        End With

        dt = objGradingFFBBOL.GetGradingFFB(objGradingFFBPPT)
        If dt.Rows.Count <> 0 Then

            dgvGradingFFBView.AutoGenerateColumns = False
            Me.dgvGradingFFBView.DataSource = dt
        Else
            ClearGridView(dgvGradingFFBView) '''''clear the records from grid view
            ' lblView.Visible = True
            Exit Sub
        End If



    End Sub

    Private Sub chkGradingDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGradingDate.CheckedChanged
        If chkGradingDate.Checked = True Then
            dtpViewGradingDate.Enabled = True
        Else
            dtpViewGradingDate.Enabled = False
        End If
    End Sub
    Private Sub UpdateGradingFFB()


        If dgvGradingFFBView.Rows.Count > 0 Then

            If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSave.Enabled = True
                End If
            End If


            lgradingID = dgvGradingFFBView.SelectedRows(0).Cells("dgclgradingID").Value.ToString
            txtProductionWBTicketNo.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclWBTicketNo").Value.ToString
            lWBTicketNo = dgvGradingFFBView.SelectedRows(0).Cells("dgclWBTicketNo").Value.ToString
            lWeighingID = dgvGradingFFBView.SelectedRows(0).Cells("dgclWeighingID").Value.ToString
            dtProductionGradingDate.Value = dgvGradingFFBView.SelectedRows(0).Cells("dgclGradingDate").Value.ToString
            Dim lTime As String
            lTime = dgvGradingFFBView.SelectedRows(0).Cells("dgclGradingTime").Value.ToString
            lTime = lTime.Replace("#", "")
            lTime = lTime.Substring(0, 5)
            txtGradingTime.Text = lTime

            txtProductionMinMaturity.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclMinMaturity").Value.ToString

            lLooseFruitorBunch = dgvGradingFFBView.SelectedRows(0).Cells("dgclLosseFruitPerBunche").Value.ToString
            lUnripeFruitJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnRipeFruitJ").Value.ToString
            lUnderRipeJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnderripeJ").Value.ToString
            lRipeFruitJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclRipeFruitJ").Value.ToString
            lOverRipeFruitJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclOverRipeFruitJ").Value.ToString
            lEmptyBunchFruitJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclEmptyBunchFruitJ").Value.ToString
            lParthenocarpicJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclPartheJ").Value.ToString
            lHardBunchJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclHardBunchJ").Value.ToString
            txtProductionLooseFruit.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLooseFruitsP").Value.ToString
            txtProductionKgofFruitLoose.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclKgOfLooseFruit").Value.ToString
            lUndamageTotalBunch = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnDamageJ").Value.ToString
            lDamageTotalBunch = dgvGradingFFBView.SelectedRows(0).Cells("dgclDamageJ").Value.ToString
            lLightDamageTotalBunch = dgvGradingFFBView.SelectedRows(0).Cells("dgclLightDamageJ").Value.ToString

            txtProductionLooseFruitorBunch.Text = lLooseFruitorBunch
            txtProductionUnripeFruitJJ.Text = lUnripeFruitJJ
            txtProductionUnderRipeJJ.Text = lUnderRipeJJ
            txtProductionRipeFruitJJ.Text = lRipeFruitJJ
            txtProductionOverRipeFruitJJ.Text = lOverRipeFruitJJ
            txtProductionEmptyBunchFruitJJ.Text = lEmptyBunchFruitJJ
            txtProductionParthenocarpicJJ.Text = lParthenocarpicJJ
            txtProductionHardBunchJJ.Text = lHardBunchJJ
            txtProductionUndamageTotalBunch.Text = lUndamageTotalBunch
            txtProductionDamageTotalBunch.Text = lDamageTotalBunch
            txtProductionLightDamageTotalBunch.Text = lLightDamageTotalBunch

            txtProductionComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclComment").Value.ToString
            txtBatuKerikil.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclBatuKerikil").Value.ToString



            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Memperbarui"
            End If

            'btnSave.Text = "Update"
            lBtnSave = "Update"

            BlockDetails()
            Me.tabGradingFFB.SelectedTab = tbGradingFFB
            txtProductionMinMaturity.Focus()
            gpProductionGradingFFB1.Enabled = False
        Else
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub dgvGradingFFBView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGradingFFBView.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateGradingFFB()
            End If
        End If



        ' tabGradingFFB.SelectedTab = tbGradingFFB
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tabGradingFFB.SelectedTab = tbGradingFFB
        Clear()
        ClearDataGridText()
        ClearGridView(dgvBlock)
        txtProductionWBTicketNo.Focus()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        UpdateGradingFFB()
        tabGradingFFB.SelectedTab = tbGradingFFB
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If


        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingFFBfrm))
        Dim objGradingFFBPPT As New GradingFFBPPT
        Dim objGradingFFBBOL As New GradingFFBBOL
        Dim dt As New DataTable
        If dgvGradingFFBView.Rows.Count > 0 Then
            If MsgBox(rm.GetString("Msg12"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                lgradingID = Me.dgvGradingFFBView.SelectedRows(0).Cells("dgclGradingID").Value.ToString()
                With objGradingFFBPPT
                    .GradingID = lgradingID
                End With
                objGradingFFBBOL.DeleteGradingFFB(objGradingFFBPPT)
                BindDataGrid()
                DisplayInfoMessage("Msg13")
                'MsgBox("Data Successfully Deleted!")
            End If
        Else
            DisplayInfoMessage("Msg14")
            ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtWBTicketNoSearch.Text.Trim = String.Empty And chkGradingDate.Checked = False Then
            DisplayInfoMessage("Msg15")
            ''MsgBox("Please Enter Criteria to Search!")
            BindDataGrid()
            Exit Sub
        Else
            BindDataGrid()
            If dgvGradingFFBView.RowCount = 0 Then
                DisplayInfoMessage("Msg16")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If

       
    End Sub

    Private Sub tabGradingFFB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabGradingFFB.Click
        If txtProductionWBTicketNo.Text <> "" And btnSave.Enabled = True Then
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tabGradingFFB.SelectedIndex = 0
                GlobalPPT.IsRetainFocus = False
            Else
                Clear()
                ClearDataGridText()
                ClearGridView(dgvBlock)
                BindDataGrid()
            End If
        Else
            Clear()
            ClearDataGridText()
            ClearGridView(dgvBlock)
            BindDataGrid()
        End If
    End Sub



    Private Sub GradingFFBfrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    'Private Sub dgvBlock_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBlock.CellDoubleClick
    '    If dgvBlock.Rows.Count > 0 Then
    '        txtProductionSupplier.Text = dgvBlock.SelectedRows(0).Cells("dgbSupplier").Value.ToString
    '        txtProductionNetWeight.Text = dgvBlock.SelectedRows(0).Cells("dgbNetWeight").Value.ToString

    '        If Not dgvBlock.SelectedRows(0).Cells("dgbWeighingDate").Value Is DBNull.Value Then
    '            txtProductionArrivedDate.Text = Format(dgvBlock.SelectedRows(0).Cells("dgbWeighingDate").Value, "dd/MM/yyyy")
    '        Else
    '            txtProductionArrivedDate.Text = String.Empty
    '        End If
    '        If dgvBlock.SelectedRows(0).Cells("dgclSection").Value.ToString = "Morning" Then
    '            lAMPM = "AM"
    '        Else
    '            lAMPM = "PM"
    '        End If


    '        txtProductionVehicle.Text = dgvBlock.SelectedRows(0).Cells("dgbVehicleNo").Value.ToString
    '        txtProductionTotalBunches.Text = dgvBlock.SelectedRows(0).Cells("dgbTotalBunches").Value.ToString
    '        txtProductionFFBDeliveryOrderNo.Text = dgvBlock.SelectedRows(0).Cells("dgbFFBDeliveryOrderNo").Value.ToString
    '        txtProductionArrivedTime.Text = "" & dgvBlock.SelectedRows(0).Cells("dgbWeighinTime").Value.ToString & " " & lAMPM & " "
    '        txtProductionDriver.Text = dgvBlock.SelectedRows(0).Cells("dgbDriverName").Value.ToString
    '        txtProductionNoTrip.Text = dgvBlock.SelectedRows(0).Cells("dgbNoTrip").Value.ToString
    '    End If
    'End Sub

    Private Sub txtProductionWBTicketNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProductionWBTicketNo.KeyDown
        If e.KeyCode = 13 Then
            If txtProductionWBTicketNo.Text <> String.Empty Then
                dtProductionGradingDate.Focus()
            End If
        End If
    End Sub

   
    Private Sub txtProductionWBTicketNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionWBTicketNo.TextChanged
        If txtProductionWBTicketNo.Text = "" Then
            ClearDataGridText()
            ClearGridView(dgvBlock)
        End If
    End Sub

    Private Sub dgvGradingFFBView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvGradingFFBView.KeyDown
        If e.KeyCode = 13 Then
            UpdateGradingFFB()
        End If
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        

        Dim ObjRecordExist As New Object
        Dim ObjGradingPPT As New GradingFFBPPT
        Dim ObjGradingBOL As New GradingFFBBOL
        ObjRecordExist = ObjGradingBOL.GradingFFBRecordIsExisT(ObjGradingPPT)

        If ObjRecordExist = 0 Then
            DisplayInfoMessage("Msg17")
            ''MsgBox("No Record(s) Available!")
        Else

            StrFrmName = "Grading FFB"
            ReportODBCMethod.ShowDialog()
            StrFrmName = ""
        End If
    End Sub

   
    Private Sub txtProductionKgofFruitLoose_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionKgofFruitLoose.TextChanged
        If txtProductionKgofFruitLoose.Text <> String.Empty And txtProductionNetWeight.Text <> String.Empty Then
            txtProductionLooseFruit.Text = Math.Round((Val(txtProductionKgofFruitLoose.Text) / Val(txtProductionNetWeight.Text)) * 100, 2)
        Else
            txtProductionLooseFruit.Text = ""
        End If
    End Sub

   
    Private Sub txtProductionNetWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionNetWeight.TextChanged
        If txtProductionKgofFruitLoose.Text <> String.Empty And txtProductionNetWeight.Text <> String.Empty Then
            txtProductionLooseFruit.Text = Math.Round((Val(txtProductionKgofFruitLoose.Text) / Val(txtProductionNetWeight.Text)) * 100, 2)
        Else
            txtProductionLooseFruit.Text = ""
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

    Private Sub txtProductionMinMaturity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionMinMaturity.Leave
        DecimalIdenCheck(txtProductionMinMaturity)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg18")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtProductionMinMaturity.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtProductionKgofFruitLoose_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionKgofFruitLoose.Leave
        DecimalIdenCheck(txtProductionKgofFruitLoose)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg18")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtProductionKgofFruitLoose.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtBatuKerikil_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBatuKerikil.KeyDown
        KeyDown3kgDecimal(sender, e)
    End Sub

    Private Sub txtBatuKerikil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBatuKerikil.KeyPress
        KeyPress3kgDecimal(sender, e)
    End Sub

    Private Sub txtGradingTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGradingTime.Leave
        If txtGradingTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtGradingTime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg57")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtGradingTime.Focus()
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
                    '  MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtGradingTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg106")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtGradingTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtGradingTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg77")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtGradingTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtGradingTime.Text = Hrs + ":" + Min
        End If

        If txtGradingTime.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtGradingTime.Text
            strArr = str.Split(":")

            If CInt(strArr(0)) >= 24 Then
                DisplayInfoMessage("Msg78")
                txtGradingTime.Focus()
                Exit Sub
            End If
        End If




    End Sub

    Private Sub txtGradingTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGradingTime.TextChanged
        Dim Value As String = txtGradingTime.Text
        Dim strlen As Integer
        If txtGradingTime.Text <> "" Then
            strlen = Len(txtGradingTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtGradingTime.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg84")
                    txtGradingTime.Focus()
                End If
            Next
        End If
    End Sub

  
    Private Sub t_Enter(sender As System.Object, e As System.EventArgs) Handles t.Enter

    End Sub
End Class