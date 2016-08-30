Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Math
Public Class GradingFFBNewfrm

    Private lWeighingID As String = String.Empty
    Private lgradingID As String = String.Empty
    Private lWBTicketNo As String = String.Empty

    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingFFBfrm))
    Dim mdiparent As New MDIParent

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    Private Sub GradingFFBfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        SetUICulture(GlobalPPT.strLang)
        Clear()
        BindDataGrid()
        tabGradingFFB.SelectedTab = tbView
    End Sub

    Public Sub Clear()
        gpProductionGradingFFB1.Enabled = True
        txtProductionWBTicketNo.Text = String.Empty

        txtProductionTotalBunches.Text = String.Empty

        txtProductionUnripeFruitJJ.Text = String.Empty
        txtProductionUnderRipeJJ.Text = String.Empty
        txtProductionOverRipeFruitJJ.Text = String.Empty
        txtProductionEmptyBunchFruitJJ.Text = String.Empty
        txtProductionLongStalksJJ.Text = String.Empty
        txtProductionFruitLooseKg.Text = String.Empty
        txtProductionDirtStones.Text = String.Empty
        txtProductionSmallBunches.Text = String.Empty
        txtProductionBuahRestan.Text = String.Empty
        'txtProductionHardBunchJJ.Text = String.Empty
        txtProductionParthenocarpicJJ.Text = String.Empty
        txtProductionRatDamageLight.Text = String.Empty

        ' Comments
        txtUnripeComment.Text = String.Empty
        txtUnderRipeComment.Text = String.Empty
        txtOverRipeComment.Text = String.Empty
        txtEmptyBunchesComment.Text = String.Empty
        txtLongStalksComment.Text = String.Empty
        txtLooseFruitComment.Text = String.Empty
        txtDirtStonesComment.Text = String.Empty
        txtSmallBunchesComment.Text = String.Empty
        txtBuahRestanComment.Text = String.Empty
        'txtHardBunchesComment.Text = String.Empty
        txtParthenocarpicComment.Text = String.Empty
        txtRatDamageLComment.Text = String.Empty

        txtProductionRipeJ.Text = String.Empty
        txtProductionRipeComment.Text = String.Empty
        txtProductionBunchStalkNotCutJ.Text = String.Empty
        txtProductionBunchStalkNotCutComment.Text = String.Empty
        txtProductionRottenBunchJ.Text = String.Empty
        txtProductionRottenBunchComment.Text = String.Empty
        txtProductionBuahRestan1to2.Text = String.Empty
        txtProductionBuahRestan1to2Comment.Text = String.Empty


        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSave.Text = "Simpan"
        End If

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

    End Sub
    Private Sub Datefunction()


        Dim lDate As String
        lDate = "" & TimeOfDay.Hour & ":" & TimeOfDay.Minute & ""
        txtGradingTime.Text = lDate


    End Sub
    Private Sub ClearDataGridText()
        txtProductionSupplier.Text = String.Empty
        txtProductionVehicle.Text = String.Empty
        txtProductionTotalBunches.Text = String.Empty
        txtGradingBunches.Text = String.Empty
        txtDocumentNumber.Text = String.Empty
        txtProductionFFBDeliveryOrderNo.Text = String.Empty
        txtProductionDriver.Text = String.Empty
        txtBinNo.Text = String.Empty
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


    
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        '  Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingFFBfrm))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            btnResetIB.Text = rm.GetString("Reset")
            btnSave.Text = rm.GetString("Save")
            btnClose.Text = rm.GetString("Close")
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
            Dim ObjGradeTargetBOL As New GradingFFBBOL
            Dim DocumentNumber As String = ObjGradeTargetBOL.GetGradingDocumentNumber()
            txtDocumentNumber.Text = "LKG" + GlobalPPT.strEstateAbbrev + DocumentNumber
            BlockDetails()
        End If
    End Sub

    Private Sub BlockDetails()
        Dim dt As New DataTable
        Dim ObjGradeTargetPPT As New GradingFFBPPT
        Dim ObjGradeTargetBOL As New GradingFFBBOL
        ObjGradeTargetPPT.WBTicketNo = txtProductionWBTicketNo.Text
        dt = ObjGradeTargetBOL.GetBlockDetailValues(ObjGradeTargetPPT).Tables(0)

        If dt.Rows.Count > 0 Then
            txtProductionSupplier.Text = dt.Rows(0)("Supplier").ToString()
            txtProductionVehicle.Text = dt.Rows(0)("VHNo").ToString()
            txtProductionFFBDeliveryOrderNo.Text = dt.Rows(0)("FFBDeliveryOrderNo").ToString()
            txtProductionDriver.Text = dt.Rows(0)("DriverName").ToString()

            'Dim sumBunches As Object
            'sumBunches = dt.Compute("Sum(TotalBunches)", "")
            'txtProductionTotalBunches.Text = sumBunches.ToString()

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
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

    Private Sub dgvGradingFFBView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGradingFFBView.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateGradingFFB()
            End If
        End If
    End Sub

    Private Sub UpdateGradingFFB()


        If dgvGradingFFBView.Rows.Count > 0 Then
            ClearDataGridText()

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
            txtDocumentNumber.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclDocumentNumber").Value.ToString
            If Not IsDBNull(dgvGradingFFBView.SelectedRows(0).Cells("dgcAbnormal").Value) Then
                txtAbnormalJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgcAbnormal").Value.ToString()
            Else
                txtAbnormalJJ.Text = "0"
            End If

            txtAbnormalComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgcAbnormalComment").Value

            Dim lTime As String
            lTime = dgvGradingFFBView.SelectedRows(0).Cells("dgclGradingTime").Value.ToString
            lTime = lTime.Replace("#", "")
            lTime = lTime.Substring(0, 5)
            txtGradingTime.Text = lTime


            txtProductionUnripeFruitJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnRipeFruitJ").Value.ToString
            txtProductionUnderRipeJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnderripeJ").Value.ToString
            txtProductionOverRipeFruitJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclOverRipeFruitJ").Value.ToString
            txtProductionEmptyBunchFruitJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclEmptyBunchFruitJ").Value.ToString
            txtProductionLongStalksJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLongStalksJ").Value.ToString
            txtProductionFruitLooseKg.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclKgOfLooseFruit").Value.ToString
            txtProductionDirtStones.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclDirtAndStonesJ").Value.ToString
            txtProductionSmallBunches.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclSmallBunchesJ").Value.ToString
            txtProductionBuahRestan.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclBuahRestanJ").Value.ToString
            'txtProductionHardBunchJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclHardBunchJ").Value.ToString
            txtProductionParthenocarpicJJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclPartheJ").Value.ToString
            txtProductionRatDamageLight.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLightDamageJ").Value.ToString

            ' Comments
            txtUnripeComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnripeFruitComment").Value.ToString
            txtUnderRipeComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnderRipeComment").Value.ToString
            txtOverRipeComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclOverRipeFruitComment").Value.ToString
            txtEmptyBunchesComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclEmptyBunchFruitComment").Value.ToString
            txtLongStalksComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLongStalksComment").Value.ToString
            txtLooseFruitComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLooseFruitsComment").Value.ToString
            txtDirtStonesComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclDirtAndStonesComment").Value.ToString
            txtSmallBunchesComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclSmallBunchesComment").Value.ToString
            txtBuahRestanComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclBuahRestanComment").Value.ToString
            'txtHardBunchesComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclHardBunchComment").Value.ToString
            txtParthenocarpicComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclPartheComment").Value.ToString
            txtRatDamageLComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLightDamageComment").Value.ToString

            If Not IsDBNull(dgvGradingFFBView.SelectedRows(0).Cells("dgclTotalGradedBunches").Value) Then
                txtGradingBunches.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclTotalGradedBunches").Value.ToString
            End If

            txtProductionRipeJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclRipeFruitJ").Value
            txtProductionRipeComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("RipeComment").Value
            txtProductionBunchStalkNotCutJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("BunchStalkNotCutJ").Value
            txtProductionBunchStalkNotCutComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("BunchStalkNotCutComment").Value
            txtProductionRottenBunchJ.Text = dgvGradingFFBView.SelectedRows(0).Cells("RottenBunchJ").Value
            txtProductionRottenBunchComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("RottenBunchComment").Value
            txtProductionBuahRestan1to2.Text = dgvGradingFFBView.SelectedRows(0).Cells("BuahRestan1to2J").Value
            txtProductionBuahRestan1to2Comment.Text = dgvGradingFFBView.SelectedRows(0).Cells("BuahRestan1to2Comment").Value

            txtBinNo.Text = dgvGradingFFBView.SelectedRows(0).Cells("BinNumber").Value

            'lRipeFruitJJ = dgvGradingFFBView.SelectedRows(0).Cells("dgclRipeFruitJ").Value.ToString
            'lLooseFruitorBunch = dgvGradingFFBView.SelectedRows(0).Cells("dgclLosseFruitPerBunche").Value.ToString
            'txtProductionLooseFruit.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclLooseFruitsP").Value.ToString
            'lUndamageTotalBunch = dgvGradingFFBView.SelectedRows(0).Cells("dgclUnDamageJ").Value.ToString

            ' = lUnderRipeJJ
            ' = lOverRipeFruitJJ
            ' = lEmptyBunchFruitJJ
            ' = lParthenocarpicJJ
            ' = lHardBunchJJ
            'txtProductionUndamageTotalBunch.Text = lUndamageTotalBunch
            'txtProductionDamageTotalBunch.Text = lDamageTotalBunch
            ' = lLightDamageTotalBunch

            'txtProductionComment.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclComment").Value.ToString
            'txtBatuKerikil.Text = dgvGradingFFBView.SelectedRows(0).Cells("dgclBatuKerikil").Value.ToString



            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSave.Text = "Memperbarui"
            End If

            btnSave.Text = "Update"

            BlockDetails()

            Me.tabGradingFFB.SelectedTab = tbGradingFFB
            'gpProductionGradingFFB1.Enabled = False
            txtProductionWBTicketNo.Focus()
        Else
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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

    Private Sub btnResetIB_Click(sender As Object, e As EventArgs) Handles btnResetIB.Click
        Clear()
        ClearDataGridText()
        txtProductionWBTicketNo.Focus()
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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

        Dim msg As String = "Total Bunches and Auto Total Bunches are different. Do you still want to proceed?"

        If CInt(txtProductionTotalBunches.Text) <> CInt(txtGradingBunches.Text) Then
            If MessageBox.Show(msg, "Total bunches and  Auto Total Bunches are different!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        If btnSave.Text = "Save" Then
            SaveDatas()
        Else
            UpdateDatas()
        End If

    End Sub

    Private Sub SaveDatas()
        Dim ds As New DataSet

        If Not IsNumeric(txtGradingBunches.Text) Then
            MessageBox.Show("Total JJG grading should be numeric", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGradingBunches.Focus()
            Exit Sub
        End If

        Dim ObjGradingFFBPPT As New GradingFFBPPT
        Dim ObjGradingFFBBOL As New GradingFFBBOL
        With ObjGradingFFBPPT

            .DocumentNumber = txtDocumentNumber.Text
            .WeighingID = lWeighingID
            .GradingDate = dtProductionGradingDate.Value
            .GradingTime = txtGradingTime.Text
            If IsNumeric(txtProductionTotalBunches.Text) Then
                .TotalBunches = txtProductionTotalBunches.Text
            Else
                .TotalBunches = 0
            End If

            .TotalGradedBunches = txtGradingBunches.Text
            .BinNumber = txtBinNo.Text

            If txtProductionUnripeFruitJJ.Text <> String.Empty Then
                .UnripeFruitJ = txtProductionUnripeFruitJJ.Text
            End If

            If txtProductionUnderRipeJJ.Text <> String.Empty Then
                .UnderripeJ = txtProductionUnderRipeJJ.Text
            End If

            If txtProductionRipeJ.Text <> String.Empty Then
                .RipeFruitJ = txtProductionRipeJ.Text
            End If

            If txtProductionOverRipeFruitJJ.Text <> String.Empty Then
                .OverRipeFruitJ = txtProductionOverRipeFruitJJ.Text
            End If

            If txtProductionEmptyBunchFruitJJ.Text <> String.Empty Then
                .EmptyBunchFruitJ = txtProductionEmptyBunchFruitJJ.Text
            End If

            If txtProductionLongStalksJJ.Text <> String.Empty Then
                .LongStalksJ = txtProductionLongStalksJJ.Text
            End If

            If txtProductionBunchStalkNotCutJ.Text <> String.Empty Then
                .BunchStalkNotCutJ = txtProductionBunchStalkNotCutJ.Text
            End If

            If txtProductionFruitLooseKg.Text <> String.Empty Then
                .KgOfLooseFruit = txtProductionFruitLooseKg.Text
            End If

            If txtProductionDirtStones.Text <> String.Empty Then
                .DirtAndStonesJ = txtProductionDirtStones.Text
            End If

            If txtProductionSmallBunches.Text <> String.Empty Then
                .SmallBunchesJ = txtProductionSmallBunches.Text
            End If

            If txtProductionBuahRestan.Text <> String.Empty Then
                .BuahRestanJ = txtProductionBuahRestan.Text
            End If

            'If txtProductionHardBunchJJ.Text <> String.Empty Then
            '    .HardBunchJ = txtProductionHardBunchJJ.Text
            'End If
            .HardBunchJ = 0

            If txtProductionParthenocarpicJJ.Text <> String.Empty Then
                .PartheJ = txtProductionParthenocarpicJJ.Text
            End If

            If txtProductionRottenBunchJ.Text <> String.Empty Then
                .RottenBunchJ = txtProductionRottenBunchJ.Text
            End If

            If txtProductionRatDamageLight.Text <> String.Empty Then
                .LightDamageJ = txtProductionRatDamageLight.Text
            End If

            If txtProductionBuahRestan1to2.Text <> String.Empty Then
                .BuahRestan1to2J = txtProductionBuahRestan1to2.Text
            End If

            If txtAbnormalJJ.Text <> String.Empty Then
                .Abnormal = txtAbnormalJJ.Text
            End If

            .UnripeFruitComment = txtUnripeComment.Text
            .UnderRipeComment = txtUnderRipeComment.Text
            .AbnormalComment = txtAbnormalComment.Text
            .RipeComment = txtProductionRipeComment.Text
            .OverRipeFruitComment = txtOverRipeComment.Text
            .EmptyBunchFruitComment = txtEmptyBunchesComment.Text
            .LongStalksComment = txtLongStalksComment.Text
            .BunchStalkNotCutComment = txtProductionBunchStalkNotCutComment.Text
            .LooseFruitsComment = txtLooseFruitComment.Text
            .DirtAndStonesComment = txtDirtStonesComment.Text
            .SmallBunchesComment = txtSmallBunchesComment.Text
            .BuahRestanComment = txtBuahRestanComment.Text
            .HardBunchComment = ""
            .PartheComment = txtParthenocarpicComment.Text
            .RottenBunchComment = txtProductionRottenBunchComment.Text
            .LightDamageComment = txtRatDamageLComment.Text
            .BuahRestan1to2Comment = txtProductionBuahRestan1to2Comment.Text

        End With

        ds = GradingFFBBOL.saveGradingFFB(ObjGradingFFBPPT)

        If ds Is Nothing Then
            DisplayInfoMessage("Msg3")
            '' MsgBox("Failed to save database")
        Else
            Clear()
            ClearDataGridText()
            BindDataGrid()
            DisplayInfoMessage("Msg4")
            ''MsgBox("Data Successfully Saved!")
        End If
        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub UpdateDatas()
        Dim ds As New DataSet

        If Not IsNumeric(txtGradingBunches.Text) Then
            MessageBox.Show("Total JJG grading should be numeric", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGradingBunches.Focus()
            Exit Sub
        End If

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

            .DocumentNumber = txtDocumentNumber.Text
            .GradingID = lgradingID
            .WeighingID = lWeighingID
            .GradingDate = dtProductionGradingDate.Value
            .BinNumber = txtBinNo.Text

            If IsNumeric(txtProductionTotalBunches.Text) Then
                .TotalBunches = txtProductionTotalBunches.Text
            Else
                .TotalBunches = 0
            End If

            .TotalGradedBunches = txtGradingBunches.Text

            .GradingTime = txtGradingTime.Text

            If txtProductionUnripeFruitJJ.Text <> String.Empty Then
                .UnripeFruitJ = txtProductionUnripeFruitJJ.Text
            End If

            If txtProductionUnderRipeJJ.Text <> String.Empty Then
                .UnderripeJ = txtProductionUnderRipeJJ.Text
            End If

            If txtProductionRipeJ.Text <> String.Empty Then
                .RipeFruitJ = txtProductionRipeJ.Text
            End If

            If txtProductionOverRipeFruitJJ.Text <> String.Empty Then
                .OverRipeFruitJ = txtProductionOverRipeFruitJJ.Text
            End If

            If txtProductionEmptyBunchFruitJJ.Text <> String.Empty Then
                .EmptyBunchFruitJ = txtProductionEmptyBunchFruitJJ.Text
            End If

            If txtProductionLongStalksJJ.Text <> String.Empty Then
                .LongStalksJ = txtProductionLongStalksJJ.Text
            End If

            If txtProductionBunchStalkNotCutJ.Text <> String.Empty Then
                .BunchStalkNotCutJ = txtProductionBunchStalkNotCutJ.Text
            End If

            If txtProductionFruitLooseKg.Text <> String.Empty Then
                .KgOfLooseFruit = txtProductionFruitLooseKg.Text
            End If

            If txtProductionDirtStones.Text <> String.Empty Then
                .DirtAndStonesJ = txtProductionDirtStones.Text
            End If

            If txtProductionSmallBunches.Text <> String.Empty Then
                .SmallBunchesJ = txtProductionSmallBunches.Text
            End If

            If txtProductionBuahRestan.Text <> String.Empty Then
                .BuahRestanJ = txtProductionBuahRestan.Text
            End If

            'If txtProductionHardBunchJJ.Text <> String.Empty Then
            '    .HardBunchJ = txtProductionHardBunchJJ.Text
            'End If
            .HardBunchJ = 0

            If txtProductionParthenocarpicJJ.Text <> String.Empty Then
                .PartheJ = txtProductionParthenocarpicJJ.Text
            End If

            If txtProductionRottenBunchJ.Text <> String.Empty Then
                .RottenBunchJ = txtProductionRottenBunchJ.Text
            End If

            If txtProductionRatDamageLight.Text <> String.Empty Then
                .LightDamageJ = txtProductionRatDamageLight.Text
            End If

            If txtProductionBuahRestan1to2.Text <> String.Empty Then
                .BuahRestan1to2J = txtProductionBuahRestan1to2.Text
            End If

            If txtAbnormalJJ.Text <> String.Empty Then
                .Abnormal = txtAbnormalJJ.Text
            End If

            .AbnormalComment = txtAbnormalComment.Text
            .UnripeFruitComment = txtUnripeComment.Text
            .UnderRipeComment = txtUnderRipeComment.Text
            .RipeComment = txtProductionRipeComment.Text
            .OverRipeFruitComment = txtOverRipeComment.Text
            .EmptyBunchFruitComment = txtEmptyBunchesComment.Text
            .LongStalksComment = txtLongStalksComment.Text
            .BunchStalkNotCutComment = txtProductionBunchStalkNotCutComment.Text
            .LooseFruitsComment = txtLooseFruitComment.Text
            .DirtAndStonesComment = txtDirtStonesComment.Text
            .SmallBunchesComment = txtSmallBunchesComment.Text
            .BuahRestanComment = txtBuahRestanComment.Text
            .HardBunchComment = ""
            .PartheComment = txtParthenocarpicComment.Text
            .RottenBunchComment = txtProductionRottenBunchComment.Text
            .LightDamageComment = txtRatDamageLComment.Text
            .BuahRestan1to2Comment = txtProductionBuahRestan1to2Comment.Text
        End With

        ds = ObjGradingFFBBOL.UpdateGradingFFB(ObjGradingFFBPPT)

        If ds Is Nothing Then
            DisplayInfoMessage("Msg3")
            'MsgBox("Failed to save database")
        Else
            Clear()
            ClearDataGridText()
            BindDataGrid()
            DisplayInfoMessage("Msg6")
            '' MsgBox("Data Successfully Updated!")
        End If
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tabGradingFFB.SelectedTab = tbGradingFFB
        Clear()
        ClearDataGridText()
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

    Sub CalculateTotalGradingJJG(sender As Object)
        If Not sender Is Nothing Then
            Dim txtBox As TextBox = sender
            If Not IsNumeric(txtBox.Text) And txtBox.Text.Length > 0 Then
                btnSave.Enabled = False
                MessageBox.Show("Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim totalJJGGrading As Decimal = 0
        If txtProductionUnripeFruitJJ.Text.Length > 0 Then
            totalJJGGrading += txtProductionUnripeFruitJJ.Text
        End If
        If txtProductionUnderRipeJJ.Text.Length > 0 Then
            totalJJGGrading += txtProductionUnderRipeJJ.Text
        End If
        If txtProductionOverRipeFruitJJ.Text.Length > 0 Then
            totalJJGGrading += txtProductionOverRipeFruitJJ.Text
        End If
        If txtProductionEmptyBunchFruitJJ.Text.Length > 0 Then
            totalJJGGrading += txtProductionEmptyBunchFruitJJ.Text
        End If
        If txtProductionRipeJ.Text.Length > 0 Then
            totalJJGGrading += txtProductionRipeJ.Text
        End If
        If txtAbnormalJJ.Text.Length > 0 Then
            totalJJGGrading += txtAbnormalJJ.Text
        End If

        txtProductionTotalBunches.Text = totalJJGGrading.ToString()
        btnSave.Enabled = True
    End Sub

    Private Sub txtProductionUnripeFruitJJ_TextChanged(sender As Object, e As EventArgs) Handles txtProductionUnripeFruitJJ.TextChanged
        CalculateTotalGradingJJG(sender)
    End Sub

    Private Sub txtProductionUnderRipeJJ_TextChanged(sender As Object, e As EventArgs) Handles txtProductionUnderRipeJJ.TextChanged
        CalculateTotalGradingJJG(sender)
    End Sub

    Private Sub txtProductionOverRipeFruitJJ_TextChanged(sender As Object, e As EventArgs) Handles txtProductionOverRipeFruitJJ.TextChanged
        CalculateTotalGradingJJG(sender)
    End Sub

    Private Sub txtProductionEmptyBunchFruitJJ_TextChanged(sender As Object, e As EventArgs) Handles txtProductionEmptyBunchFruitJJ.TextChanged
        CalculateTotalGradingJJG(sender)
    End Sub

    Private Sub txtProductionRipeJ_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductionRipeJ.TextChanged
        CalculateTotalGradingJJG(sender)
    End Sub

    Private Sub txtProductionWBTicketNo_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProductionWBTicketNo.KeyUp
        If e.KeyCode = Keys.Enter Then

            SearchTicktNumber()

        End If
    End Sub

    Sub SearchTicktNumber()
        Dim objGradingFFBPPT As New GradingFFBPPT
        Dim objGradingFFBBOL As New GradingFFBBOL
        Dim dt As New DataTable

        With objGradingFFBPPT
            .WBTicketNo = Me.txtProductionWBTicketNo.Text.Trim
        End With

        dt = objGradingFFBBOL.GetGradingFFBTicket(objGradingFFBPPT)

        If (dt.Rows.Count > 0) Then
            'Grading data already exist
            lgradingID = dt.Rows(0)("GradingID").ToString()
            lWBTicketNo = dt.Rows(0)("WBTicketNo").ToString()
            lWeighingID = dt.Rows(0)("WeighingID").ToString()
            dtProductionGradingDate.Value = dt.Rows(0)("GradingDate").ToString()
            txtDocumentNumber.Text = dt.Rows(0)("DocumentNumber").ToString()

            txtBinNo.Text = dt.Rows(0)("BinNumber").ToString()

            Dim lTime As String
            lTime = dt.Rows(0)("Gradingtime").ToString()
            lTime = lTime.Replace("#", "")
            lTime = lTime.Substring(0, 5)
            txtGradingTime.Text = lTime


            txtProductionUnripeFruitJJ.Text = dt.Rows(0)("UnRipeFruitJ").ToString()
            txtProductionUnderRipeJJ.Text = dt.Rows(0)("UnderripeJ").ToString()
            txtProductionOverRipeFruitJJ.Text = dt.Rows(0)("OverRipeFruitJ").ToString()
            txtProductionEmptyBunchFruitJJ.Text = dt.Rows(0)("EmptyBunchFruitJ").ToString()
            txtProductionLongStalksJJ.Text = dt.Rows(0)("LongStalksJ").ToString()
            txtProductionFruitLooseKg.Text = dt.Rows(0)("KgOfLooseFruit").ToString()
            txtProductionDirtStones.Text = dt.Rows(0)("DirtAndStonesJ").ToString()
            txtProductionSmallBunches.Text = dt.Rows(0)("SmallBunchesJ").ToString()
            txtProductionBuahRestan.Text = dt.Rows(0)("BuahRestanJ").ToString()
            'txtProductionHardBunchJJ.Text = dt.Rows(0)("HardBunchJ").ToString()
            txtProductionParthenocarpicJJ.Text = dt.Rows(0)("PartheJ").ToString()
            txtProductionRatDamageLight.Text = dt.Rows(0)("LightDamageJ").ToString()

            ' Comments
            txtUnripeComment.Text = dt.Rows(0)("UnripeFruitComment").ToString()
            txtUnderRipeComment.Text = dt.Rows(0)("UnderRipeComment").ToString()
            txtOverRipeComment.Text = dt.Rows(0)("OverRipeFruitComment").ToString()
            txtEmptyBunchesComment.Text = dt.Rows(0)("EmptyBunchFruitComment").ToString()
            txtLongStalksComment.Text = dt.Rows(0)("LongStalksComment").ToString()
            txtLooseFruitComment.Text = dt.Rows(0)("LooseFruitsComment").ToString()
            txtDirtStonesComment.Text = dt.Rows(0)("DirtAndStonesComment").ToString()
            txtSmallBunchesComment.Text = dt.Rows(0)("SmallBunchesComment").ToString()
            txtBuahRestanComment.Text = dt.Rows(0)("BuahRestanComment").ToString()
            'txtHardBunchesComment.Text = dt.Rows(0)("HardBunchComment").ToString()
            txtParthenocarpicComment.Text = dt.Rows(0)("PartheComment").ToString()
            txtRatDamageLComment.Text = dt.Rows(0)("LightDamageComment").ToString()

            If Not IsDBNull(dt.Rows(0)("TotalGradedBunches")) Then
                txtGradingBunches.Text = dt.Rows(0)("TotalGradedBunches").ToString()
            End If

            btnSave.Text = "Update"
            BlockDetails()
        Else
            ' not graded

            'objGradingFFBPPT.WBTicketNo = txtWBTicketNoSearch.Text.Trim
            dt = objGradingFFBBOL.WBTicketNoLookupSearch(objGradingFFBPPT, "Yes").Tables(0)

            If dt.Rows.Count > 0 Then

                lWBTicketNo = dt.Rows(0)("WBTicketNo").ToString()
                lWeighingID = dt.Rows(0)("WeighingID").ToString()

                BlockDetails()

                Dim ObjGradeTargetBOL As New GradingFFBBOL
                Dim DocumentNumber As String = ObjGradeTargetBOL.GetGradingDocumentNumber()
                txtDocumentNumber.Text = "LKG" + GlobalPPT.strEstateAbbrev + DocumentNumber
            End If

        End If

    End Sub
    
    Private Sub txtAbnormalJJ_TextChanged(sender As Object, e As System.EventArgs) Handles txtAbnormalJJ.TextChanged
        CalculateTotalGradingJJG(sender)
    End Sub
End Class