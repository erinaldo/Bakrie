Imports CheckRoll_BOL
Imports Common_PPT
Imports CheckRoll_PPT

Public Class TPHGrading

    Dim formLoaded As Boolean = False

    Private Sub TPHGrading_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)

        txtLocation.Text = GlobalPPT.strEstateName
        LoadDivision()

        dtpDocumentDate.Format = DateTimePickerFormat.Custom
        dtpDocumentDate.CustomFormat = " "
        dtpDocumentDate.MinDate = DateSerial(2014, 1, 1)
        dtpDocumentDate.Value = dtpDocumentDate.MinDate
        dtpDocumentDate.Checked = False

        ShowGradingData()

        formLoaded = True
    End Sub

    Sub ShowGradingData()
        DgvView.AutoGenerateColumns = False
        DgvView.DataSource = TPHGrading_BOL.TPHGradingSelect()
    End Sub

    Sub SumGradingQuality()
        If Not formLoaded Then Return

        If Not IsNumeric(txtMentah.Text) Then
            MessageBox.Show("'Mentah' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMentah.Focus()
            Return
        ElseIf Not IsNumeric(txtKurangMatang.Text) Then
            MessageBox.Show("'Kurang Matang' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtKurangMatang.Focus()
            Return
        ElseIf Not IsNumeric(txtMatang.Text) Then
            MessageBox.Show("'Matang' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMatang.Focus()
            Return
        ElseIf Not IsNumeric(txtTerlaluMatang.Text) Then
            MessageBox.Show("'Terlalu Matang' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTerlaluMatang.Focus()
            Return
        ElseIf Not IsNumeric(txtBuahBusuk.Text) Then
            MessageBox.Show("'Buah Busuk' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBuahBusuk.Focus()
            Return
        Else
            'all fields are valid so SUM up
            txtCalculatedTotalBunches.Text = CInt(txtMentah.Text) +
                CInt(txtKurangMatang.Text) +
                CInt(txtMatang.Text) +
                CInt(txtTerlaluMatang.Text) +
                CInt(txtBuahBusuk.Text)
        End If
    End Sub

    Sub LoadDivision()
        Dim dataView As New DataView(TPHGrading_BOL.GetDivisions(GlobalPPT.strEstateID))
        dataView.Sort = " DivName ASC"

        cmbDivision.DisplayMember = "DivName"
        cmbDivision.ValueMember = "DivID"
        cmbDivision.DataSource = dataView.ToTable()
    End Sub

    Sub LoadSubblocks(ByVal DivisionID As String)
        Dim dataView As New DataView(TPHGrading_BOL.GetBlocks(GlobalPPT.strEstateID, DivisionID))
        dataView.Sort = " BlockName ASC"

        cmbBlock.DisplayMember = "BlockName"
        cmbBlock.ValueMember = "BlockID"
        cmbBlock.DataSource = dataView
    End Sub

    Sub LoadTPH(ByVal BlockID As String)
        Dim dataView As New DataView(TPHGrading_BOL.GetTPH(GlobalPPT.strEstateID, BlockID))
        dataView.Sort = " TPH ASC"

        cmbTPH.DisplayMember = "TPH"
        cmbTPH.ValueMember = "id"
        cmbTPH.DataSource = dataView
        cmbTPH.SelectedIndex = -1
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If ValidateTPHGrading() Then
            Dim _TPHGrading As New TPHGrading_PPT
            _TPHGrading.DocumentSerial = txtDocumentSerial.Text
            _TPHGrading.DocumentDate = dtpDocumentDate.Value
            _TPHGrading.DivID = cmbDivision.SelectedValue
            _TPHGrading.AskepAssistant = txtAssitant.Text

            _TPHGrading.BlockID = cmbBlock.SelectedValue
            _TPHGrading.TPHID = cmbTPH.SelectedValue
            _TPHGrading.Mentah = txtMentah.Text
            _TPHGrading.KurangMatang = txtKurangMatang.Text
            _TPHGrading.Matang = txtMatang.Text
            _TPHGrading.TerlaluMatang = txtTerlaluMatang.Text
            _TPHGrading.BuahBusuk = txtBuahBusuk.Text
            _TPHGrading.TotalBunches = txtTotalBunches.Text
            _TPHGrading.CalculatedTotalBunches = txtCalculatedTotalBunches.Text
            _TPHGrading.Brondolan = txtBrondolan.Text
            _TPHGrading.LongStalk = txtLongStalk.Text
            _TPHGrading.NonVCutStalks = txtNonVCutStalks.Text
            _TPHGrading.DRC = cmbTPH.Text

            If btnSave.Text = "Save" Then

                _TPHGrading.TPHGradingID = 0

                If TPHGrading_BOL.TPHGradingDocumentNoExist(_TPHGrading.DocumentSerial) Then
                    MessageBox.Show("Document Number already exist!", "Document Number Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                Else
                    TPHGrading_BOL.TPHGradingSave(_TPHGrading)

                    Dim DataGridViewRow As DataGridViewRow
                    For Each DataGridViewRow In dgvDetailTPH.Rows
                        With _TPHGrading
                            .TPHID = DataGridViewRow.Cells("dgcTPH").Value
                            .DRC = DataGridViewRow.Cells("dgcDRC").Value
                        End With
                        TPHGrading_BOL.TPHGradingDetailSave(_TPHGrading)
                    Next

                    ClearGrading()

                    'btnDeleteTPHGrading.Enabled = True
                    'btnSave.Text = "Update"
                    MessageBox.Show("TPH Grading data saved!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                
            Else
                'update TPH Grading
                _TPHGrading.TPHGradingID = CInt(lblTPHGradingID.Text)

                TPHGrading_BOL.TPHGradingSave(_TPHGrading)
                Dim DataGridViewRow As DataGridViewRow
                For Each DataGridViewRow In dgvDetailTPH.Rows
                    With _TPHGrading
                        .TPHID = DataGridViewRow.Cells("dgcTPH").Value
                        .DRC = DataGridViewRow.Cells("dgcDRC").Value
                    End With
                    TPHGrading_BOL.TPHGradingDetailSave(_TPHGrading)
                Next
                ClearGrading()

                MessageBox.Show("TPH Grading data updated", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ShowGradingData()

        End If

    End Sub


    Function ValidateTPHGrading() As Boolean
        If txtDocumentSerial.Text.Length = 0 Then
            MessageBox.Show("Document Serial is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumentSerial.Focus()
            Return False
        ElseIf dtpDocumentDate.Checked = False Then
            MessageBox.Show("Document Date is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtpDocumentDate.Focus()
            Return False
        ElseIf cmbDivision.SelectedValue Is Nothing Then
            MessageBox.Show("Division is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbDivision.Focus()
            Return False
        ElseIf txtAssitant.Text.Length = 0 Then
            MessageBox.Show("Askep, Assistant or Person Acting is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAssitant.Focus()
            Return False

        ElseIf cmbBlock.SelectedValue Is Nothing Then
            MessageBox.Show("Field No is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbBlock.Focus()
            Return False
        ElseIf cmbTPH.SelectedValue Is Nothing Then
            MessageBox.Show("TPH is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cmbTPH.Focus()
            Return False
        ElseIf Not IsNumeric(txtBrondolan.Text) Then
            MessageBox.Show("'Brondolan' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBrondolan.Focus()
            Return False
        ElseIf Not IsNumeric(txtLongStalk.Text) Then
            MessageBox.Show("'Long Stalk' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLongStalk.Focus()
            Return False
        ElseIf Not IsNumeric(txtNonVCutStalks.Text) Then
            MessageBox.Show("'Non V Cut Stalks' accepts Numeric Values Only", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNonVCutStalks.Focus()
            Return False
        ElseIf txtCalculatedTotalBunches.Text <> txtTotalBunches.Text Then
            If MessageBox.Show("Total Bunches and Calculated total bunches are different. Do you still want to proceed?", "Total bunches and calculated total bunches are different!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Return False
            Else
                Return True
            End If
        ElseIf txtCalculatedTotalBunches.Text.ToString() = "0" Then
            If MessageBox.Show("All Grading values are zero. Do you still want to proceed?", "Do you want to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function


    Private Sub cmbDivision_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDivision.SelectedIndexChanged
        If Not (cmbDivision.SelectedValue Is Nothing) Then
            Dim row As DataRowView = cmbDivision.SelectedItem
            txtAssitant.Text = row("AsstName")
            LoadSubblocks(cmbDivision.SelectedValue)
            cmbBlock.SelectedIndex = -1
        End If

    End Sub

    Private Sub cmbBlock_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbBlock.SelectedIndexChanged
        If Not (cmbBlock.SelectedValue Is Nothing) Then
            LoadTPH(cmbBlock.SelectedValue)
        End If
    End Sub

    Sub ShowTPHGradingRecord(ByVal EstateID As String, ByVal TPHGradingID As String)
        Dim dt As DataTable = TPHGrading_BOL.TPHGradingSelect(EstateID, TPHGradingID)
        If dt.Rows.Count > 0 Then
            lblTPHGradingID.Text = dt.Rows(0)("TPHGradingID")
            txtDocumentSerial.Text = dt.Rows(0)("DocumentSerial")
            dtpDocumentDate.Checked = True
            dtpDocumentDate.Value = dt.Rows(0)("DocumentDate")
            cmbDivision.SelectedValue = dt.Rows(0)("DivID")
            txtAssitant.Text = dt.Rows(0)("AskepAssistant")
            cmbBlock.SelectedValue = dt.Rows(0)("BlockID")
            cmbTPH.SelectedValue = dt.Rows(0)("TPHID")

            txtMentah.Text = dt.Rows(0)("Mentah")
            txtKurangMatang.Text = dt.Rows(0)("KurangMatang")
            txtMatang.Text = dt.Rows(0)("Matang")
            txtTerlaluMatang.Text = dt.Rows(0)("TerlaluMatang")
            txtBuahBusuk.Text = dt.Rows(0)("BuahBusuk")
            txtTotalBunches.Text = dt.Rows(0)("TotalBunches")
            txtCalculatedTotalBunches.Text = dt.Rows(0)("CalculatedTotalBunches")
            txtBrondolan.Text = dt.Rows(0)("Brondolan")
            txtLongStalk.Text = dt.Rows(0)("LongStalk")
            txtNonVCutStalks.Text = dt.Rows(0)("NonVCutStalks")

            Dim dtDetail As DataTable = TPHGrading_BOL.TPHGradingDetailSelect(TPHGradingID)
            dgvDetailTPH.DataSource = dtDetail

            btnSave.Text = "Update"
            btnDeleteTPHGrading.Enabled = True
        End If

    End Sub


    Sub CheckTPHExist()
        'If Not (cmbTPH.SelectedValue Is Nothing) Then
        '    If TPHGrading_BOL.TPHGradingCheckExist(dtpDocumentDate.Value, cmbTPH.SelectedValue) = True Then
        '        btnSave.Enabled = False
        '        MessageBox.Show("TPH Grading data exist for " & cmbTPH.Text & " on " & dtpDocumentDate.Value.ToString("dd MMM yyyy"), "Record Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Else
        '        btnSave.Enabled = True

        '    End If
        'End If
    End Sub

    Private Sub cmbTPH_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cmbTPH.SelectionChangeCommitted
        CheckTPHExist()
    End Sub


    Private Sub dtpReceptionDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDocumentDate.ValueChanged
        If dtpDocumentDate.Value > dtpDocumentDate.MinDate Then
            dtpDocumentDate.Format = DateTimePickerFormat.Custom
            dtpDocumentDate.CustomFormat = "yyyy-MM-dd"
            dtpDocumentDate.Value = dtpDocumentDate.Value
        Else
            dtpDocumentDate.Format = DateTimePickerFormat.Custom
            dtpDocumentDate.CustomFormat = " "
            dtpDocumentDate.Value = dtpDocumentDate.MinDate
            dtpDocumentDate.Checked = False
        End If
        CheckTPHExist()
    End Sub

    Private Sub dtpReceptionDate_DropDown(ByVal sender As Object, ByVal e As EventArgs) Handles dtpDocumentDate.DropDown
        RemoveHandler dtpDocumentDate.ValueChanged, AddressOf dtpReceptionDate_ValueChanged
    End Sub

    Private Sub dtpReceptionDate_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDocumentDate.CloseUp
        AddHandler dtpDocumentDate.ValueChanged, AddressOf dtpReceptionDate_ValueChanged
        Call dtpReceptionDate_ValueChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub txtNIK_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNIK.TextChanged
        'Dim EmpName As String = TPHGrading_BOL.GetEmployeeName(txtNIK.Text)
        'If (EmpName.Length > 0) Then
        '    txtAssitant.Text = EmpName
        'Else
        '    txtAssitant.Text = ""
        'End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TPHGrading))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

        Catch
            ''display a message if the culture is not supported
            ''try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMentah_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMentah.TextChanged
        SumGradingQuality()
    End Sub

    Private Sub txtKurangMatang_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtKurangMatang.TextChanged
        SumGradingQuality()
    End Sub

    Private Sub txtMatang_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMatang.TextChanged
        SumGradingQuality()
    End Sub

    Private Sub txtTerlaluMatang_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTerlaluMatang.TextChanged
        SumGradingQuality()
    End Sub

    Private Sub txtBuahBusuk_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuahBusuk.TextChanged
        SumGradingQuality()
    End Sub

    
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ClearGrading()
    End Sub

    Sub ClearGrading()
        txtDocumentSerial.Text = ""
        dtpDocumentDate.Format = DateTimePickerFormat.Custom
        dtpDocumentDate.CustomFormat = " "
        dtpDocumentDate.Value = dtpDocumentDate.MinDate
        dtpDocumentDate.Checked = False

        cmbDivision.SelectedIndex = -1
        cmbBlock.DataSource = Nothing
        cmbTPH.DataSource = Nothing
        txtNIK.Text = ""
        txtAssitant.Text = ""
        btnSave.Text = "Save"

        txtMentah.Text = "0"
        txtKurangMatang.Text = "0"
        txtMatang.Text = "0"
        txtTerlaluMatang.Text = "0"
        txtBuahBusuk.Text = "0"
        txtTotalBunches.Text = "0"
        txtCalculatedTotalBunches.Text = "0"
        txtBrondolan.Text = "0"
        txtLongStalk.Text = "0"
        txtNonVCutStalks.Text = "0"

        btnDeleteTPHGrading.Enabled = False
    End Sub


    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        DgvView.AutoGenerateColumns = False
        DgvView.DataSource = TPHGrading_BOL.TPHGradingSelectByDate(dtpStartDate.Value, dtpEndDate.Value)
    End Sub

    Private Sub DgvView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvView.CellDoubleClick
        If DgvView.Rows(e.RowIndex).Cells("colTPHGradingID").Value <> Nothing Then
            tcFFBQualityControl.SelectedTab = tabEntry
            ShowTPHGradingRecord(GlobalPPT.strEstateID, DgvView.Rows(e.RowIndex).Cells("colTPHGradingID").Value)
        End If
    End Sub

    Private Sub btnDeleteTPHGrading_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteTPHGrading.Click
        If (MessageBox.Show("Are you sure you want to delete the current record?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            If TPHGrading_BOL.TPHGradingDelete(lblTPHGradingID.Text) = "1" Then
                ClearGrading()

                ShowGradingData()

                MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If

    End Sub

    Dim dtTPHDetails As New DataTable("todgvDetailTPH")
    Dim rowTPHDetails As DataRow
    Dim columnTPHDetails As DataColumn
    Public DTFlag As Boolean = False
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If txtDRC.Text = String.Empty Then
            MessageBox.Show("DRC is required", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDRC.Focus()
        Else
            Dim intRowCount As Integer = dtTPHDetails.Rows.Count
            rowTPHDetails = dtTPHDetails.NewRow()
            If intRowCount = 0 And DTFlag = False Then
                columnTPHDetails = New DataColumn("TPH", System.Type.[GetType]("System.String"))
                dtTPHDetails.Columns.Add(columnTPHDetails)
                columnTPHDetails = New DataColumn("DRC", System.Type.[GetType]("System.String"))
                dtTPHDetails.Columns.Add(columnTPHDetails)

                If cmbTPH.Text.Trim.ToString <> String.Empty Then
                    rowTPHDetails("TPH") = cmbTPH.Text.ToString()
                Else
                    rowTPHDetails("TPH") = String.Empty
                End If
                If txtDRC.Text.Trim <> String.Empty Then
                    rowTPHDetails("DRC") = txtDRC.Text.ToString()
                Else
                    rowTPHDetails("DRC") = String.Empty
                End If
                dtTPHDetails.Rows.InsertAt(rowTPHDetails, intRowCount)
                DTFlag = True
            Else
                If cmbTPH.Text.Trim <> String.Empty Then
                    rowTPHDetails("TPH") = cmbTPH.Text.ToString()
                Else
                    rowTPHDetails("TPH") = String.Empty
                End If
                If txtDRC.Text.Trim <> String.Empty Then
                    rowTPHDetails("DRC") = txtDRC.Text.ToString()
                Else
                    rowTPHDetails("DRC") = String.Empty
                End If
                dtTPHDetails.Rows.InsertAt(rowTPHDetails, intRowCount)
            End If

            With dgvDetailTPH
                .AutoGenerateColumns = False
                .DataSource = dtTPHDetails
            End With
        End If
    End Sub
End Class