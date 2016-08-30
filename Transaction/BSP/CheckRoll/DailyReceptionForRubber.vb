'latest

Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports System.Windows.Forms.DataGridView

Imports CheckRoll_PPT
Imports Common_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Imports Store_BOL
Imports Store_PPT


Public Class DailyReceptionForRubber
    Public blNormal As Boolean = True
    Private DailyReceiptionTableAdapter As DailyReceiptionWithTeam_DAL = New DailyReceiptionWithTeam_DAL() ' Senin, 29 Sep 2009, 12:57
    'Private KraniPanenTableAdapter As 
    Private DT_DailyReceiption As System.Data.DataTable = Nothing ' Senin, 29 Sep 2009, 12:49

    ' Private DT_DailyReceiptionWithTeam As System.Data.DataTable = Nothing '28/8/2012

    Dim cmd As SqlCommand
    Private dTotalOT As Decimal = 0
    Private dSumOTHoursGrid As Decimal = 0

    Private rowIndex_dgvDailyReceiption As Integer
    Dim lDeleteCheck As Boolean = False
    Public BlockIDInfo As String = String.Empty
    Private lDelChk As Boolean = False
    ' Selasa, 20 Oct 2009, 17:19
    ' Utk keyboard handling
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False
    Private Deletemodified As Boolean = False
    Private YOPAdd As Boolean = True

    'utk harvested, deducted and paid
    Dim Deducted As Decimal = 0
    Dim Harvested As Decimal = 0
    Dim Paid As Decimal = 0

    'add code by Agung
    '---------------------
    Private DailyDetailPremiAdapter As PremiTargetDAL
    Public DTPremi_Detail As DataTable = New DataTable
    Public Lempid As String = String.Empty

    'Saturday, 25 Oct 2009, 17:20
    Private IsCallingFromDailyAttendanceForm As Boolean = False

    ' Rabu, 24 Mar 2010, 18:29
    ' Tambah Category di parameter
    ' Karena Category dipake diperhitungan MandorPremi dan Krani Premi
    ' yg nilai MandorPremium dan KraniPremium nya diambil dari RateSetup
    Private MandorPremium As Decimal = 0
    Private KraniPremium As Decimal = 0

    Private strPremiHK As Decimal = 0

    Dim DeleteMultientry, DeleteMultientryDailyReception As New ArrayList
    Dim lDelete As Integer
    Dim lReceptionTargetSummaryID As String = String.Empty
    Dim lDailyReceiptionDetID As String = String.Empty
    Dim lDailyReceiptionWithTeamID As String = String.Empty


    Dim dtRubberDetails As New DataTable("todgvDailyReceiption")
    Dim rowRubberDetails As DataRow
    Dim dt As DataTable
    Dim columnRubberDetails As DataColumn
    Public DTFlag As Boolean = False
    Public AddFlag As Boolean = True

    Public Property TeamId() As String


    Private Sub showDailyAttendance()
        Try
            Dim DailyAttendanceWithTeamForm As DailyAttendanceWithTeam = New DailyAttendanceWithTeam()
            DailyAttendanceWithTeamForm.MdiParent = Me.MdiParent
            DailyAttendanceWithTeamForm.Dock = DockStyle.Fill

            ' Use Currency Manager and DataView to retrieve the Current Row

            'DailyAttendanceWithTeamForm.lblDailyTeamActivityID.Text = tempdr.Item("DailyTeamActivityID").ToString()
            'DailyAttendanceWithTeamForm.dtpRDate.Value = tempdr.Item("RDate")
            'DailyAttendanceWithTeamForm.txtTeam.Text = tempTeam
            'DailyAttendanceWithTeam.lSaveUpdate = tempSaveUpdate
            'DailyAttendanceWithTeamForm.dtpRDate.Value = tempRDate
            'DailyAttendanceWithTeamForm.lblActivity.Text = tempdr.Item("Activity").ToString()

            'DailyAttendanceWithTeamForm.lblMandoreID.Text = tempdr.Item("MandoreID").ToString()
            'DailyAttendanceWithTeamForm.lblMandorEmpName.Text = tempdr.Item("Mandor").ToString()

            Dim kraniID As String
            If tempdr.IsNull("KraniID") Then
                kraniID = String.Empty
            Else
                kraniID = tempdr.Item("KraniID").ToString()
            End If

            Dim krani As String
            If tempdr.IsNull("Krani") Then
                krani = String.Empty
            Else
                krani = tempdr.Item("Krani")
            End If

            'DailyAttendanceWithTeamForm.lblGangMasterID.Text = tempdr.Item("GangMasterID")
            '' END Senin, 16 Nov 2009, 19:34

            'DailyAttendanceWithTeamForm.lblEmpCategory.Text = tempdr.Item("Category") 'Ahad, 22 Nov 2009, 23:42
            'DailyAttendanceWithTeamForm.txtTeam.Focus()

            ''======================================
            '' Jum'at, 18 Sep 2009, 21:44

            '' Senin, 21 Sep 2009, 20:59
            '' Sabtu, 17 Oct 2009, 13:26
            '' Sekarang jenis team bukan lagi dari TeamCategory di GangMaster
            '' Tapi diambil dari DailyTeamActivity.Activity ->isinya adalah [PANEN atau LAIN]

            'If DailyAttendanceWithTeamForm.lblActivity.Text.ToUpper = "PANEN" Then
            '    DailyAttendanceWithTeamForm.ForPanenVisible()
            '    DailyAttendanceWithTeamForm.btnActivity.Enabled = False
            'ElseIf DailyAttendanceWithTeamForm.lblActivity.Text.ToUpper = "LAIN" Then
            '    DailyAttendanceWithTeamForm.ForLainVisible()
            '    DailyAttendanceWithTeamForm.btnActivity.Enabled = True
            'End If

            'DailyAttendanceWithTeamForm.showAllTeamMember()
            'DailyAttendanceWithTeamForm.ManageDailyAttendanceGridColumn()
            'DailyAttendanceWithTeamForm.getRateSetup()

            '' By Dadang
            '' Kamis, 11 Feb 2010, 23:27
            'DailyAttendanceWithTeamForm.DTOT_Detail = OTDetailBOL.OTDetailViewTeam(DailyAttendanceWithTeamForm.lblMandoreID.Text, DailyAttendanceWithTeamForm.lblKraniID.Text, DailyAttendanceWithTeamForm.dtpRDate.Value)
            'DailyAttendanceWithTeamForm.DgvOTDetail.DataSource = DailyAttendanceWithTeamForm.DTOT_Detail
            '' By Dadang
            '' Kamis, 11 Feb 2010, 23:27

            ''==========================================
            'If DailyAttendanceWithTeamForm.dgvDailyAttendance.Rows.Count > 0 Then
            '    DailyAttendanceWithTeamForm.dtpRDate.Enabled = False
            'Else
            '    DailyAttendanceWithTeamForm.dtpRDate.Enabled = True
            'End If


            'tcDailyAttendance.SelectedTab = DailyAttendanceWithTeamForm.tabInput
            DailyAttendanceWithTeamForm.tcDailyAttendance.SelectedTab = DailyAttendanceWithTeamForm.tabInput
            DailyAttendanceWithTeamForm.Show(tempRDate, tempTeam, "", "", "", "", "", "", "", tempTeam, tempdr.Item("Activity").ToString(), tempdr.Item("GangMasterID"), tempdr.Item("MandoreID").ToString(), kraniID, tempdr.Item("Mandor").ToString(), krani, tempdr.Item("Category"), "", MdiParent, tempdr)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim tempTeam As String
    Dim tempRDate As DateTime
    Dim tempSaveUpdate As String
    Dim tempdr As DataRow

    Public Overloads Sub Show(DailyReceiptionID As String, dateRubber As DateTime, NIK As String, Name As String, AttCode As String, Location As String, OTHour As String, Afdeling As String, YOP As String, FieldNo As String, parent As IWin32Window, strTeam As String, strRDate As DateTime, strSaveUpdate As String, rowtemp As DataRow, OldNIK As String)
        tempTeam = strTeam
        tempRDate = strRDate
        tempSaveUpdate = strSaveUpdate
        tempdr = rowtemp

        TxtOldNIK.Text = OldNIK
        dtpDate.Value = dateRubber
        txtNIK.Text = NIK
        txtName.Text = Name
        txtAttCode.Text = AttCode
        txtLocation.Text = Location
        txtOTHour.Text = OTHour
        txtAfdeling.Text = Afdeling
        txtYOP.Text = YOP
        txtBlock.Text = FieldNo
        Me.lblDailyReceiptionID.Text = DailyReceiptionID
        Dim DailyRubberBOL As New DailyReceptionForRubberBOL
        dtRubberDetails = DailyRubberBOL.DailyRubberSelect(DailyReceiptionID)
        dgvDailyReceiption.DataSource = dtRubberDetails
        dgvDailyReceiption.Columns("dgvDateRubber").Visible = False
        dgvDailyReceiption.Columns("DailyReceiptionID").Visible = False
        dgvDailyReceiption.Columns("DRRubberID").Visible = False
        Me.MdiParent = parent
        Me.Dock = DockStyle.Fill
        Me.Show()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If txtBlock.Text = String.Empty Or cmbTphNormal.Text = "- Select TPH -" Or cmbTphNormal.Text = String.Empty Then
            DisplayInfoMessage("Please fill all data!")
        Else
            If AddFlag = True Then
                SaveList()
            Else
                UpdateList()
            End If
        End If
    End Sub

    Private Sub UpdateList()
        Dim dgvRow As Integer
        If AddFlag = False And dgvDailyReceiption.Rows.Count > 0 Then
            dgvRow = dgvDailyReceiption.CurrentRow.Index
            dtRubberDetails.Rows.RemoveAt(dgvRow)
            rowRubberDetails = dtRubberDetails.NewRow()
            ReadDataForm()
            dtRubberDetails.Rows.InsertAt(rowRubberDetails, dgvRow)
            dgvDailyReceiption.DataSource = dtRubberDetails
            ClearDetail()
            AddFlag = True
        End If
    End Sub

    Private Sub ReadDataForm()
        If txtNIK.Text.Trim <> String.Empty Then
            rowRubberDetails("NIK") = txtNIK.Text.ToString()
        Else
            rowRubberDetails("NIK") = String.Empty
        End If

        If txtName.Text.Trim <> String.Empty Then
            rowRubberDetails("Name") = txtName.Text.ToString()
        Else
            rowRubberDetails("Name") = String.Empty
        End If

        If txtAttCode.Text.Trim <> String.Empty Then
            rowRubberDetails("AttCode") = txtAttCode.Text.ToString()
        Else
            rowRubberDetails("AttCode") = String.Empty
        End If

        If txtLocation.Text.Trim <> String.Empty Then
            rowRubberDetails("Location") = txtLocation.Text.ToString()
        Else
            rowRubberDetails("Location") = String.Empty
        End If

        If txtOTHour.Text.Trim <> String.Empty Then
            rowRubberDetails("OTHour") = txtOTHour.Text.ToString()
        Else
            rowRubberDetails("OTHour") = String.Empty
        End If

        If txtAfdeling.Text.Trim <> String.Empty Then
            rowRubberDetails("Afdelling") = txtAfdeling.Text.ToString()
        Else
            rowRubberDetails("Afdelling") = String.Empty
        End If

        If txtYOP.Text.Trim <> String.Empty Then
            rowRubberDetails("YOP") = txtYOP.Text.ToString()
        Else
            rowRubberDetails("YOP") = String.Empty
        End If

        If txtBlock.Text.Trim <> String.Empty Then
            rowRubberDetails("FieldNo") = txtBlock.Text.ToString()
        Else
            rowRubberDetails("FieldNo") = String.Empty
        End If

        If cmbTphNormal.Text.Trim <> String.Empty Then
            rowRubberDetails("TPH") = cmbTphNormal.Text.ToString()
        Else
            rowRubberDetails("TPH") = String.Empty
        End If

        If txtLatex.Text.Trim <> String.Empty Then
            rowRubberDetails("Latex") = txtLatex.Text.ToString()
        Else
            rowRubberDetails("Latex") = 0
        End If

        If txtCup.Text.Trim <> String.Empty Then
            rowRubberDetails("CupLump") = txtCup.Text.ToString()
        Else
            rowRubberDetails("CupLump") = 0
        End If

        If txtTreeLace.Text.Trim <> String.Empty Then
            rowRubberDetails("TreeLace") = txtTreeLace.Text.ToString()
        Else
            rowRubberDetails("TreeLace") = 0
        End If

        If txtCoaglum.Text.Trim <> String.Empty Then
            rowRubberDetails("COAglum") = txtCoaglum.Text
        Else
            rowRubberDetails("COAglum") = 0
        End If

        If txtDRC.Text.Trim <> String.Empty Then
            rowRubberDetails("DRC") = txtDRC.Text.ToString()
        Else
            rowRubberDetails("DRC") = 0
        End If

        If txtDRCCuplump.Text.Trim <> String.Empty Then
            rowRubberDetails("DRCCupLump") = txtDRCCuplump.Text
        Else
            rowRubberDetails("DRCCupLump") = 0
        End If

        If txtDRCTreelace.Text.Trim <> String.Empty Then
            rowRubberDetails("DRCTreeLace") = txtDRCTreelace.Text
        Else
            rowRubberDetails("DRCTreeLace") = 0
        End If

        If txtLatexDry.Text.Trim <> String.Empty Then
            rowRubberDetails("Dry") = txtLatexDry.Text.ToString()
        Else
            rowRubberDetails("Dry") = 0
        End If

        If txtCupDry.Text.Trim <> String.Empty Then
            rowRubberDetails("DryCupLump") = txtCupDry.Text
        Else
            rowRubberDetails("DryCupLump") = 0
        End If

        If txtTreeDry.Text.Trim <> String.Empty Then
            rowRubberDetails("DryTreeLace") = txtTreeDry.Text
        Else
            rowRubberDetails("DryTreeLace") = 0
        End If

        If txtDryCoa.Text.Trim() <> String.Empty Then
            rowRubberDetails("DryCoaglum") = txtDryCoa.Text
        Else
            rowRubberDetails("DryCoaglum") = 0
        End If

        If txtDRCCoaglum.Text.Trim <> String.Empty Then
            rowRubberDetails("DRCCoaglum") = txtDRCCoaglum.Text
        Else
            rowRubberDetails("DRCCoaglum") = 0
        End If

    End Sub

    Private Sub SaveList()
        Dim intRowcount As Integer
        intRowcount = dtRubberDetails.Rows.Count

        AddFlag = True

        For i As Integer = 0 To dgvDailyReceiption.RowCount - 1

            Try
                If dtpDate.Value = dgvDailyReceiption.Rows(i).Cells("dgvDateRubber").Value Then
                    DisplayInfoMessage("Record already exists for this date")
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            If txtBlock.Text = dgvDailyReceiption.Rows(i).Cells("dgcFieldNo").Value Then
                DisplayInfoMessage("Field Number already exists for this record")
                Exit Sub
            End If
        Next

        rowRubberDetails = dtRubberDetails.NewRow()
        If (dtRubberDetails.Columns.Count = 20) Then
            columnRubberDetails = New DataColumn("Dry", System.Type.[GetType]("System.String"))
            dtRubberDetails.Columns.Add(columnRubberDetails)
            columnRubberDetails = New DataColumn("DryCupLump", System.Type.[GetType]("System.String"))
            dtRubberDetails.Columns.Add(columnRubberDetails)
            columnRubberDetails = New DataColumn("DryTreeLace", System.Type.[GetType]("System.String"))
            dtRubberDetails.Columns.Add(columnRubberDetails)
            columnRubberDetails = New DataColumn("DryCoaglum", Type.[GetType]("System.String"))
            dtRubberDetails.Columns.Add(columnRubberDetails)
        End If
        If intRowcount = 0 And DTFlag = False And dgvDailyReceiption.RowCount = 0 Then

            'columnRubberDetails = New DataColumn("Name", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("AttCode", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("Location", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("OTHour", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("Afdelling", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("YOP", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("FieldNo", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("TPH", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("Latex", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("CupLump", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)
            'columnRubberDetails = New DataColumn("TreeLace", System.Type.[GetType]("System.String"))
            'dtRubberDetails.Columns.Add(columnRubberDetails)

            ReadDataForm()

            dtRubberDetails.Rows.InsertAt(rowRubberDetails, intRowcount)
            DTFlag = True
        Else
            ReadDataForm()

            dtRubberDetails.Rows.InsertAt(rowRubberDetails, intRowcount)
        End If

        With dgvDailyReceiption
            .AutoGenerateColumns = False
            .DataSource = dtRubberDetails
            ClearDetail()
        End With
    End Sub

    Private Sub ClearGrid()
        dgvDailyReceiption.DataSource = Nothing
    End Sub

    Private Sub ClearDetail()
        txtLatex.Text = "0"
        txtCup.Text = "0"
        txtTreeLace.Text = "0"
        txtCoaglum.Text = "0"
        txtDRC.Text = "0"
        txtDRCTreelace.Text = "0"
        txtDRCCoaglum.Text = "0"
        txtDRCCuplump.Text = "0"
    End Sub

    Private Sub Clear()
        'txtNIK.Clear()
        'txtName.Clear()
        'txtAttCode.Clear()
        'txtLocation.Clear()
        'txtOTHour.Clear()
        txtAfdeling.Clear()
        txtYOP.Clear()
        txtBlock.Clear()
        'cmbTphNormal.Clear()
        txtLatex.Text = "0"
        txtCup.Text = "0"
        txtTreeLace.Text = "0"
        txtCoaglum.Text = "0"
        txtDRC.Text = "0"
        txtDRCTreelace.Text = "0"
        txtDRCCoaglum.Text = "0"
        txtDRCCuplump.Text = "0"
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Clear()
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        If txtBlock.Text = String.Empty Or cmbTphNormal.Text = "- Select TPH -" Or cmbTphNormal.Text = String.Empty Then
            DisplayInfoMessage("Please fill all data!")
        Else
            Dim DataGridViewRow As DataGridViewRow
            Dim objRubberPPT As New DailyReceptionForRubberPPT
            Dim objRubberBOL As New DailyReceptionForRubberBOL
            Dim objRubberDAL As New DailyReceptionForRubberDAL
            Dim rowsAffected As Integer = 0

            If dgvDailyReceiption.RowCount > 0 Then
                objRubberDAL.DeleteRubber(lblDailyReceiptionID.Text)
            End If

            For Each DataGridViewRow In dgvDailyReceiption.Rows
                With objRubberPPT
                    .DailyReceiptionID = lblDailyReceiptionID.Text
                    .NIK = DataGridViewRow.Cells("dgcNIK").Value.ToString()
                    .Name = DataGridViewRow.Cells("dgcName").Value.ToString()
                    .AttCode = DataGridViewRow.Cells("dgcAttCode").Value.ToString()
                    .Location = DataGridViewRow.Cells("dgcLocation").Value.ToString()
                    .OTHour = DataGridViewRow.Cells("dgcOTHour").Value.ToString()
                    .Afdeling = DataGridViewRow.Cells("dgcAfdelling").Value.ToString()
                    .YOP = DataGridViewRow.Cells("dgcYOP").Value.ToString()
                    .Block = DataGridViewRow.Cells("dgcFieldNo").Value.ToString()
                    .TPH = DataGridViewRow.Cells("dgcTPH").Value.ToString()
                    .Latex = DataGridViewRow.Cells("dgcLatex").Value.ToString()
                    .CupLamp = DataGridViewRow.Cells("dgcCuplump").Value.ToString()
                    .TreeLace = DataGridViewRow.Cells("dgcTreelace").Value.ToString()
                    .Coaglum = DataGridViewRow.Cells("dgcCOAglum").Value.ToString()
                    .DRC = DataGridViewRow.Cells("dgcDRC").Value.ToString()
                    .DRCCuplump = DataGridViewRow.Cells("dgcDRCCupLump").Value.ToString()
                    .DRCTreelace = DataGridViewRow.Cells("dgcDRCTreeLace").Value.ToString()
                    .DRCCoaglum = DataGridViewRow.Cells("dgcDRCCOAglum").Value.ToString()
                    .TeamId = TeamId
                    .DateRubber = dtpDate.Value
                End With

                rowsAffected = objRubberBOL.Save_Rubber(objRubberPPT)
                If rowsAffected = 0 Then
                    DisplayInfoMessage("Data Failed Saved!")
                End If
            Next
            If rowsAffected = 1 Then
                DisplayInfoMessage("Data Successfull Saved!")
                'ClearGrid()
            End If
            Clear()
            'Me.Close()
        End If
    End Sub

    Private Sub DisplayInfoMessage(message As String)
        MsgBox(message, Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub dgvDailyReceiption_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDailyReceiption.CellDoubleClick
        txtNIK.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcNIK").Value
        txtName.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcName").Value
        txtAttCode.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcAttCode").Value
        txtLocation.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcLocation").Value
        txtOTHour.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcOTHour").Value
        txtAfdeling.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcAfdelling").Value
        txtYOP.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcYOP").Value
        txtBlock.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcFieldNo").Value
        If cmbTphNormal.Items.Count > 0 Then
            cmbTphNormal.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcTPH").Value
        Else
            cmbTphNormal.Items.Add(dgvDailyReceiption.SelectedRows(0).Cells("dgcTPH").Value)
            cmbTphNormal.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcTPH").Value
        End If

        txtLatex.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcLatex").Value
        txtCup.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcCuplump").Value
        txtTreeLace.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcTreelace").Value
        If IsDBNull(dgvDailyReceiption.SelectedRows(0).Cells("dgcCOAglum").Value) Then
            txtCoaglum.Text = 0
        Else
            txtCoaglum.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcCOAglum").Value
        End If

        txtDRC.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcDRC").Value
        If IsDBNull(dgvDailyReceiption.SelectedRows(0).Cells("dgcDRCCupLump").Value) Then
            txtDRCCuplump.Text = 0
        Else
            txtDRCCuplump.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcDRCCupLump").Value
        End If

        If IsDBNull(dgvDailyReceiption.SelectedRows(0).Cells("dgcDRCTreeLace").Value) Then
            txtDRCTreelace.Text = 0
        Else
            txtDRCTreelace.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcDRCTreeLace").Value
        End If

        If IsDBNull(dgvDailyReceiption.SelectedRows(0).Cells("dgcDRCCOAglum").Value) Then
            txtDRCCoaglum.Text = 0
        Else
            txtDRCCoaglum.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcDRCCOAglum").Value
        End If

        If IsDBNull(dgvDailyReceiption.SelectedRows(0).Cells("dgcDryCoaglum").Value) Then
            txtDryCoa.Text = 0
        Else
            txtDryCoa.Text = dgvDailyReceiption.SelectedRows(0).Cells("dgcDryCoaglum").Value
        End If

        AddFlag = False
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnResetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnResetAll.Click
        Clear()
        ClearGrid()
    End Sub

    Private Sub btnNikLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnNikLookup.Click
        Dim SubBlockLookupForm As VHMasterSubBlockLookup = New VHMasterSubBlockLookup()
        SubBlockLookupForm.cropID = "CropIDRubber"
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtBlock.Text = SubBlockLookupForm.psBlockId
            lblBlockValue.Text = SubBlockLookupForm.psBlockName
            txtAfdeling.Text = SubBlockLookupForm.psDIVID
            lblAfdeling.Text = SubBlockLookupForm.psDIVName
            txtYOP.Text = SubBlockLookupForm.psYopID
            lblYOP.Text = SubBlockLookupForm.psYopName
        End If
    End Sub

    Private Sub DailyReceptionForRubber_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        showDailyAttendance()
    End Sub

    Private Sub DailyReceptionForRubber_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Dim dsLoadTPH As DataTable

        'dsLoadTPH = DailyReceiptionWithTeam_DAL.loadTPH(txtBlock.Text)
        'Dim dr As DataRow
        'dr = dsLoadTPH.NewRow()
        'dr("id") = 0
        'dr("TPH") = "- Select TPH -"
        'dsLoadTPH.Rows.InsertAt(dr, 0)

        'cmbTphNormal.DataSource = dsLoadTPH
        'cmbTphNormal.DisplayMember = "TPH"
        'cmbTphNormal.ValueMember = "id"
        'cmbTphNormal.SelectedIndex = 0
        'ClearGrid()
        txtLocation.Text = GlobalPPT.strEstateName
        txtLatex.Text = "0"
        txtCup.Text = "0"
        txtTreeLace.Text = "0"
        txtCoaglum.Text = "0"
        txtDRC.Text = "0"
        txtDRCTreelace.Text = "0"
        txtDRCCoaglum.Text = "0"
        txtDRCCuplump.Text = "0"

    End Sub

    Private Sub cmbTphNormal_Click(sender As Object, e As System.EventArgs) Handles cmbTphNormal.Click
        Dim dsLoadTPH As DataTable

        If txtBlock.Text <> String.Empty Then
            dsLoadTPH = DailyReceiptionWithTeam_DAL.loadTPH(txtBlock.Text)
            Dim dr As DataRow
            dr = dsLoadTPH.NewRow()
            dr("id") = 0
            dr("TPH") = "- Select TPH -"
            dsLoadTPH.Rows.InsertAt(dr, 0)

            cmbTphNormal.DataSource = dsLoadTPH
            cmbTphNormal.DisplayMember = "TPH"
            cmbTphNormal.ValueMember = "id"
            cmbTphNormal.SelectedIndex = 0
        Else
            DisplayInfoMessage("Fill the Field No")
        End If

    End Sub

    Private Sub txtBlock_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBlock.KeyDown
        If e.KeyCode = Keys.Return Then
            If Me.txtBlock.Text <> "" Then
                GetFieldNo()
            End If
            cmbTphNormal.Focus()
        End If
    End Sub

    Private Sub GetFieldNo()
        Dim objBlockPPt As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objBlockPPt.Div = ""
        objBlockPPt.YOP = ""
        objBlockPPt.BlockName = txtBlock.Text.Trim()
        ds = StoreIssueVoucherBOL.GetSubBlock(objBlockPPt, "YES")
        If ds.Tables(0).Rows.Count > 0 Then
            lblBlockValue.Text = ds.Tables(0).Rows(0).Item("BlockName").ToString()
            txtAfdeling.Text = ds.Tables(0).Rows(0).Item("DivID").ToString()
            lblAfdeling.Text = ds.Tables(0).Rows(0).Item("DivName").ToString()
            txtYOP.Text = ds.Tables(0).Rows(0).Item("YOPID").ToString()
            lblYOP.Text = ds.Tables(0).Rows(0).Item("Name").ToString()
        Else
            DisplayInfoMessage("No Records Found !")
            lblBlockValue.Text = ""
            txtAfdeling.Clear()
            lblAfdeling.Text = ""
            txtYOP.Clear()
            lblYOP.Text = ""
        End If
    End Sub

    Private Sub txtBlock_LostFocus(sender As Object, e As System.EventArgs) Handles txtBlock.LostFocus
        If Me.txtBlock.Text <> "" Then
            GetFieldNo()
        End If
    End Sub

    Private Sub txtDRC_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDRC.KeyDown
        If e.KeyCode = Keys.Return Then
            txtDRCCuplump.Focus()
        End If
    End Sub


    Private Sub txtDRC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDRC.TextChanged
        CalculateDry(txtLatex, txtDRC, txtLatexDry)
    End Sub

    Private Sub CalculateDry(Wet As TextBox, Percent As TextBox, dry As TextBox)
        Try
            If (Not String.IsNullOrEmpty(Wet.Text) And Not String.IsNullOrEmpty(Percent.Text)) Then
                dry.Text = (CDbl(Wet.Text) * CDbl(Percent.Text) / 100)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtLatex_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLatex.KeyDown
        If e.KeyCode = Keys.Return Then
            txtCup.Focus()
        End If
    End Sub

    Private Sub txtLatex_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLatex.TextChanged
        CalculateDry(txtLatex, txtDRC, txtLatexDry)
       
    End Sub

    Private Sub txtCup_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCup.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTreeLace.Focus()
        End If
    End Sub

    Private Sub txtCup_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCup.TextChanged
        CalculateDry(txtCup, txtDRCCuplump, txtCupDry)
    End Sub

    Private Sub txtDRCCuplump_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDRCCuplump.KeyDown
        If e.KeyCode = Keys.Return Then
            txtDRCTreelace.Focus()
        End If
    End Sub

    Private Sub txtDRCCuplump_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDRCCuplump.TextChanged
        CalculateDry(txtCup, txtDRCCuplump, txtCupDry)
    End Sub

    Private Sub txtTreeLace_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTreeLace.KeyDown
        If e.KeyCode = Keys.Return Then
            txtCoaglum.Focus()
        End If
    End Sub

    Private Sub txtTreeLace_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTreeLace.TextChanged
        CalculateDry(txtTreeLace, txtDRCTreelace, txtTreeDry)
    End Sub

    Private Sub txtDRCTreelace_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDRCTreelace.KeyDown
        If e.KeyCode = Keys.Return Then
            txtDRCCoaglum.Focus()
        End If
    End Sub

    Private Sub txtDRCTreelace_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDRCTreelace.TextChanged
        CalculateDry(txtTreeLace, txtDRCTreelace, txtTreeDry)
    End Sub

    Private Sub txtCoaglum_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCoaglum.KeyDown
        If e.KeyCode = Keys.Return Then
            txtDRC.Focus()
        End If
    End Sub

    Private Sub txtCoaglum_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCoaglum.TextChanged
        CalculateDry(txtCoaglum, txtDRCCoaglum, txtDryCoa)
    End Sub

    Private Sub txtDRCCoaglum_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDRCCoaglum.KeyDown
        If e.KeyCode = Keys.Return Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub txtDRCCoaglum_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDRCCoaglum.TextChanged
        CalculateDry(txtCoaglum, txtDRCCoaglum, txtDryCoa)
    End Sub

    Private Sub cmbTphNormal_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbTphNormal.KeyDown
        If e.KeyCode = Keys.Return Then
            txtLatex.Focus()
        End If
    End Sub




End Class