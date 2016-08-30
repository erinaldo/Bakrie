'
'
' Programmer: Dadang Adi Hendradi
' Created   : Sabtu, 26 Sep 2009, 02:28
' Modified  : Monday, 16 Nov 2009, 00:03
' Place     : Balikpapan
'

Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports CheckRoll_PPT
Imports Common_BOL  ' 09-11-2012
Imports Common_PPT
' Thursday, 10 Sep 2009, 00:20
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms.VisualStyles

Public Class EstateGrading

    Private AdvancePaymentTableAdapter As New CheckRoll_DAL.AdvancePayment_DAL()
    Private DT_AdvancePayment As DataTable

    Private AdvancePaymentDetTableAdapter As New CheckRoll_DAL.AdvancePaymentDet_DAL()
    Private DT_AdvancePaymentDet As DataTable

    Private DT_AdvancePaymentDetView As DataTable

    Private dHK As Decimal = 0
    Private dAdvancePremium As Decimal = 0
    Private dAmount As Decimal = 0

    ' Rabu, 18 Nov 2009, 18:45
    Private dJHTEmployee As Decimal = 0
    Private dJamsostek As Decimal = 0
    Private dBalanceAdvancePayment As Decimal = 0
    Private dAdvancePayment As Decimal = 0
    Private dAdvanvePaymentFormula As Decimal = 0

    Private AdvancePaymentID As String = String.Empty

    ' Sabtu, 13 Feb 2010, 22:49, 22:30
    Private dRiceDividerDays As Decimal = 0
    ' END Sabtu, 13 Feb 2010, 22:49, 22:30

    ' Ahad, 14 Mar 2010, 00:52
    Private dBasicRate As Decimal = 0

    ' Senin, 23 Nov 2009, 11:36
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False

    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdvancePayment))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            'lblDate.Text = rm.GetString("lblDate.Text")
            'lblCategory.Text = rm.GetString("lblCategory.Text")
            'lblAPremium.Text = rm.GetString("lblAPremium.Text")

            'lblNIK.Text = rm.GetString("lblNIK.Text")
            'lblName.Text = rm.GetString("lblName.Text")
            'lblHK.Text = rm.GetString("lblHK.Text")
            'lblAmount.Text = rm.GetString("lblAmount.Text")
            'btnGenerate.Text = rm.GetString("btnGenerate.Text")

            'tcAdvancePayment.TabPages(0).Text = rm.GetString("tcAdvancePayment.TabPages(0).Text")
            'tcAdvancePayment.TabPages(1).Text = rm.GetString("tcAdvancePayment.TabPages(1).Text")
            ''lblViewDate.Text = rm.GetString("lblViewDate.Text")
            'pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

            ''btnUpdate.Text = rm.GetString("btnAdd.Text")
            'btnReset.Text = rm.GetString("btnReset.Text")
            'btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            'btnClose.Text = rm.GetString("btnClose.Text")
            'btnSearchView.Text = rm.GetString("btnSearch.Text")
            'btnViewReport.Text = rm.GetString("btnViewReport.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub

    Dim dtEGDetails As New DataTable("todgvEstateGrading")
    Dim rowEGDetails As DataRow
    Dim columnEGDetails As DataColumn
    Public DTFlag As Boolean = False
    Private AddFlag As Boolean = True

    Private Sub btnAdd_Click_1(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If txtEstate.Text.Trim() = String.Empty Or txtAfdeling.Text.Trim() = String.Empty Or txtMandor.Text.Trim() = String.Empty Or txtGangTeam.Text.Trim() = String.Empty Or txtFieldNo.Text.Trim() = String.Empty Or txtGred.Text.Trim() = String.Empty Then
            DisplayInfoMessage("Fill All Column!")
        Else
            If AddFlag = True Then
                SaveList()
            Else
                UpdateList()
            End If
        End If
    End Sub

    Private Sub ReadDataForm()
        rowEGDetails("Month") = dtpMonth.Value.ToString()

        If txtEstate.Text.Trim <> String.Empty Then
            rowEGDetails("Estate") = txtEstate.Text.ToString()
        Else
            rowEGDetails("Estate") = String.Empty
        End If

        If txtAfdeling.Text.Trim <> String.Empty Then
            rowEGDetails("Afdeling") = txtAfdeling.Text.ToString()
        Else
            rowEGDetails("Afdeling") = String.Empty
        End If

        If txtMandor.Text.Trim <> String.Empty Then
            rowEGDetails("Mandor") = txtMandor.Text.ToString()
        Else
            rowEGDetails("Mandor") = String.Empty
        End If

        If txtGangTeam.Text.Trim <> String.Empty Then
            rowEGDetails("GangTeam") = txtGangTeam.Text.ToString()
        Else
            rowEGDetails("GangTeam") = String.Empty
        End If

        If txtFieldNo.Text.Trim <> String.Empty Then
            rowEGDetails("FieldNo") = txtFieldNo.Text.ToString()
        Else
            rowEGDetails("FieldNo") = String.Empty
        End If

        If txtGred.Text.Trim <> String.Empty Then
            rowEGDetails("Gred") = txtGred.Text.ToString()
        Else
            rowEGDetails("Gred") = String.Empty
        End If
    End Sub

    Private Sub UpdateList()
        Dim dgvRow As Integer
        If AddFlag = False And dgvEstateGrading.Rows.Count > 0 Then
            dgvRow = dgvEstateGrading.CurrentRow.Index
            dtEGDetails.Rows.RemoveAt(dgvRow)
            rowEGDetails = dtEGDetails.NewRow()
            ReadDataForm()
            dtEGDetails.Rows.InsertAt(rowEGDetails, dgvRow)
            dgvEstateGrading.DataSource = dtEGDetails
            Clear()
            AddFlag = True
        End If
    End Sub

    Private Sub SaveList()
        Dim intRowcount As Integer = dtEGDetails.Rows.Count
        'Dim i As Integer = dgvEstateGrading.Rows.Count

        rowEGDetails = dtEGDetails.NewRow()
        If intRowcount = 0 And DTFlag = False Then
            columnEGDetails = New DataColumn("Month", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)
            columnEGDetails = New DataColumn("Estate", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)
            columnEGDetails = New DataColumn("Afdeling", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)
            columnEGDetails = New DataColumn("Mandor", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)
            columnEGDetails = New DataColumn("GangTeam", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)
            columnEGDetails = New DataColumn("FieldNo", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)
            columnEGDetails = New DataColumn("Gred", System.Type.[GetType]("System.String"))
            dtEGDetails.Columns.Add(columnEGDetails)

            ReadDataForm()
            dtEGDetails.Rows.InsertAt(rowEGDetails, intRowcount)
            DTFlag = True
        Else
            ReadDataForm()
            dtEGDetails.Rows.InsertAt(rowEGDetails, intRowcount)
        End If

        With dgvEstateGrading
            .AutoGenerateColumns = False
            .DataSource = dtEGDetails
            Clear()
        End With
    End Sub

    Private Sub ClearGrid()
        dgvEstateGrading.DataSource = Nothing
        dtEGDetails.Clear()
    End Sub

    Private Sub Clear()
        txtEstate.Clear()
        txtAfdeling.Clear()
        txtMandor.Clear()
        txtGangTeam.Clear()
        txtFieldNo.Clear()
        txtGred.Clear()
        lblEstateValue.Text = String.Empty
        lblAfdelingValue.Text = String.Empty
        LblMandorValue.Text = String.Empty
        lblGangTeamValue.Text = String.Empty
        lblFieldNoValue.Text = String.Empty
        lblGredValue.Text = String.Empty
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        If dgvEstateGrading.DataSource.Rows.Count = 0 Then
            DisplayInfoMessage("Fill the Form")
        Else
            Dim DataGridViewRow As DataGridViewRow
            Dim objEstateGradingPPT As New EstateGradingPPT
            Dim objEstateGradingBOL As New EstateGradingBOL
            Dim rowsAffected As Integer = 0
            For Each DataGridViewRow In dgvEstateGrading.Rows
                With objEstateGradingPPT
                    .Month = DataGridViewRow.Cells("dgcMonth").Value.ToString()
                    .Estate = DataGridViewRow.Cells("dgcEstate").Value.ToString()
                    .Afdeling = DataGridViewRow.Cells("dgcAfdeling").Value.ToString()
                    .Mandor = DataGridViewRow.Cells("dgcMandor").Value.ToString()
                    .GangTeam = DataGridViewRow.Cells("dgcGangTeam").Value.ToString()
                    .FieldNo = DataGridViewRow.Cells("dgcFieldNo").Value.ToString()
                    .Gred = DataGridViewRow.Cells("dgcGred").Value.ToString()
                End With

                rowsAffected = objEstateGradingBOL.Save_EstateGrading(objEstateGradingPPT)
                If rowsAffected = 0 Then
                    DisplayInfoMessage("Data Failed Saved!")
                End If
            Next
            If rowsAffected = 1 Then
                DisplayInfoMessage("Data Successfull Saved!")
            End If
            Clear()
            ClearGrid()
        End If
    End Sub

    Private Sub DisplayInfoMessage(message As String)
        MsgBox(message, Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub dgvEstateGrading_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEstateGrading.CellDoubleClick
        dtpMonth.Value = dgvEstateGrading.SelectedRows(0).Cells("dgcMonth").Value
        txtEstate.Text = dgvEstateGrading.SelectedRows(0).Cells("dgcEstate").Value
        txtAfdeling.Text = dgvEstateGrading.SelectedRows(0).Cells("dgcAfdeling").Value
        txtMandor.Text = dgvEstateGrading.SelectedRows(0).Cells("dgcMandor").Value
        txtGangTeam.Text = dgvEstateGrading.SelectedRows(0).Cells("dgcGangTeam").Value
        txtFieldNo.Text = dgvEstateGrading.SelectedRows(0).Cells("dgcFieldNo").Value
        txtGred.Text = dgvEstateGrading.SelectedRows(0).Cells("dgcGred").Value
        AddFlag = False
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Clear()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles BtnEstateLookUp.Click
        Dim SubBlockLookupForm As EstateLookup = New EstateLookup()
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtEstate.Text = SubBlockLookupForm._LEstateCode
            lblEstateValue.Text = SubBlockLookupForm._LEstateName
        End If
    End Sub

    Private Sub BtnAfdelingLookUp_Click(sender As System.Object, e As System.EventArgs) Handles BtnAfdelingLookUp.Click
        Dim SubBlockLookupForm As DivLookup = New DivLookup()
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtAfdeling.Text = SubBlockLookupForm.psDIVID
            lblAfdelingValue.Text = SubBlockLookupForm.psDIVName
        End If
    End Sub

    Private Sub BtnMasterLookUp_Click(sender As System.Object, e As System.EventArgs) Handles BtnMasterLookUp.Click
        'AttDate = dtpRDate.Value
        NIKLookUp._Mandor = "M"
        NIKLookUp.cmbMandorKrani.Text = "Mandor"
        NIKLookUp.cmbMandorKrani.Enabled = False
        NIKLookUp.ShowDialog()

        If NIKLookUp.DialogResult = Windows.Forms.DialogResult.OK Then

            Me.txtMandor.Text = NIKLookUp._lNIK
            Me.LblMandorValue.Text = NIKLookUp._lEmpName
        End If
        'Dim SubBlockLookupForm As TeamLookUps = New TeamLookUps()
        'SubBlockLookupForm.ShowDialog()
        'If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
        '    txtMandor.Text = SubBlockLookupForm.MandorID
        '    LblMandorValue.Text = SubBlockLookupForm.MandorEmpName
        'End If
    End Sub

    Private Sub BtnGangLookUp_Click(sender As System.Object, e As System.EventArgs) Handles BtnGangLookUp.Click
        Dim SubBlockLookupForm As TeamLookUps = New TeamLookUps()
        SubBlockLookupForm.DDate = dtpMonth.Value
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtGangTeam.Text = SubBlockLookupForm.GangMasterID
            lblGangTeamValue.Text = SubBlockLookupForm.GangName
        End If
    End Sub

    Private Sub BtnFieldNoLookUp_Click(sender As System.Object, e As System.EventArgs) Handles BtnFieldNoLookUp.Click
        Dim SubBlockLookupForm As SubBlockLookup = New SubBlockLookup()
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtFieldNo.Text = SubBlockLookupForm.psBlockId
            lblFieldNoValue.Text = SubBlockLookupForm.psBlockName
        End If
    End Sub

    Private Sub BtnGredLookUp_Click(sender As System.Object, e As System.EventArgs) Handles BtnGredLookUp.Click
        Dim SubBlockLookupForm As GradeLookup = New GradeLookup()
        SubBlockLookupForm.ShowDialog()
        If SubBlockLookupForm.DialogResult = Windows.Forms.DialogResult.OK Then
            txtGred.Text = SubBlockLookupForm._GradeID
            lblGredValue.Text = SubBlockLookupForm._GradeName
        End If
    End Sub
End Class